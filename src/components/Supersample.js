import { useEffect, useMemo } from 'react';
import { useFrame, useThree } from '@react-three/fiber';
import * as THREE from 'three';
import perf from '../perfProbe';

// Android gets no anti-aliasing from expo-gl: GLView only forwards
// `msaaSamples` on iOS, and `renderbufferStorageMultisample` is
// unimplemented, so three's multisampled render targets can't stand in
// either. Every edge (the silhouette, the dark mouth/eyes against the body)
// rendered as hard pixel steps: the "low settings" look.
//
// Supersampling instead: draw the scene into an offscreen target `factor`
// times larger in each direction, then scale it down onto the screen with
// linear filtering, averaging factor² samples per pixel. Only needs a plain
// (non-multisampled) framebuffer, which expo-gl supports.
// The offscreen target stores 8-bit colour, which clips anything brighter
// than 1.0 — but tone mapping (done in the final on-screen pass, since three
// doesn't tone-map into render targets) needs those overbright values to roll
// highlights off exactly like a direct render. So the offscreen pass runs
// with every light divided by HEADROOM and the final pass multiplies back.
// A power of two, so dividing and restoring intensities is exact.
const HEADROOM = 4;

// Adaptive quality. Rendering at 2x is four times the pixels of a direct
// render, which a mid-range GPU may not finish within a frame; the JS thread
// can't tell, because expo-gl queues GL work to its own thread and never
// waits. So once every PROBE_EVERY frames, right before drawing, one
// blocking GL call (getError, which expo-gl only answers after the GL thread
// has run everything queued before it) measures how far behind that thread
// is. A GPU that keeps up answers in well under a millisecond; one still
// busy with the previous frame takes most of a frame. Two slow probes in a
// row step the factor down (2 → 1.5 → 1); a long clean run steps it back up.
const PROBE_EVERY = 60;
const PROBE_WARMUP = 3; // probes skipped after (re)start: shader compiles, texture uploads
const SLOW_MS = 6;
const CLEAN_MS = 2;
const SLOW_STREAK = 2;
const CLEAN_STREAK = 8;
const FACTOR_STEPS = [2, 1.5, 1];

function scaleLights(scene, factor) {
  scene.traverse((obj) => {
    if (obj.isLight) obj.intensity *= factor;
  });
}

export function createSupersampler(renderer, requestedFactor, adaptive = true) {
  const steps = FACTOR_STEPS.filter((f) => f <= requestedFactor);
  if (!steps.length || steps[0] !== requestedFactor) steps.unshift(requestedFactor);
  let stepIndex = 0;
  let factor = steps[0];

  const target = new THREE.WebGLRenderTarget(1, 1, {
    minFilter: THREE.LinearFilter,
    magFilter: THREE.LinearFilter,
    generateMipmaps: false,
    depthBuffer: true,
  });
  // sRGB storage keeps 8-bit precision in the darker tones, and the
  // downscale then averages in linear light.
  target.texture.colorSpace = THREE.SRGBColorSpace;

  // The target holds the scene over a transparent clear (the stage's
  // gradient shows through the canvas), so its colours are effectively
  // premultiplied by alpha; composite it that way to avoid dark fringes.
  const quadMaterial = new THREE.MeshBasicMaterial({
    map: target.texture,
    color: new THREE.Color(HEADROOM, HEADROOM, HEADROOM),
    transparent: true,
    blending: THREE.CustomBlending,
    blendSrc: THREE.OneFactor,
    blendDst: THREE.OneMinusSrcAlphaFactor,
    depthTest: false,
    depthWrite: false,
  });
  const quadScene = new THREE.Scene();
  quadScene.add(new THREE.Mesh(new THREE.PlaneGeometry(2, 2), quadMaterial));
  const quadCamera = new THREE.OrthographicCamera(-1, 1, 1, -1, 0, 1);

  // R3F native wraps gl.render so every call also runs expo-gl's
  // endFrameEXP, which pushes the frame to the screen. The offscreen pass
  // must not do that (it would show an unfinished frame: flicker), so
  // endFrameEXP is silenced for just that call. Only the final on-screen
  // pass presents. (three defines render per instance, not on the
  // prototype, so there's no unwrapped method to call instead.)
  const ctx = renderer.getContext();
  const noop = () => {};
  const renderWithoutPresenting = (scene, camera) => {
    const present = ctx.endFrameEXP;
    if (!present) {
      renderer.render(scene, camera); // not expo-gl (e.g. a desktop preview)
      return;
    }
    ctx.endFrameEXP = noop;
    try {
      renderer.render(scene, camera);
    } finally {
      ctx.endFrameEXP = present;
    }
  };
  const canSilencePresent = () => {
    const present = ctx.endFrameEXP;
    if (!present) return true;
    try {
      ctx.endFrameEXP = noop;
      return ctx.endFrameEXP === noop;
    } catch (e) {
      return false;
    } finally {
      try {
        ctx.endFrameEXP = present;
      } catch (e) {
        // unwritable: already reported as unsupported above
      }
    }
  };

  const bufferSize = new THREE.Vector2();
  let supported = null; // unknown until the first frame
  let frames = 0;
  let probes = 0;
  let slowStreak = 0;
  let cleanStreak = 0;

  const setStep = (index, why) => {
    stepIndex = index;
    factor = steps[stepIndex];
    slowStreak = 0;
    cleanStreak = 0;
    probes = 0; // warm up again after a resize
    perf.set('ssFactor', factor);
    // eslint-disable-next-line no-console
    console.log(`[Supersample] ${why}: now ${factor}x`);
  };

  const probe = () => {
    if (!adaptive || !ctx.endFrameEXP || steps.length < 2) return;
    if (++frames % PROBE_EVERY !== 0) return;
    const t0 = performance.now();
    ctx.getError();
    const wait = performance.now() - t0;
    perf.set('glWait', wait);
    if (++probes <= PROBE_WARMUP) return;
    if (wait > SLOW_MS) {
      cleanStreak = 0;
      if (++slowStreak >= SLOW_STREAK && stepIndex < steps.length - 1) setStep(stepIndex + 1, `GPU ${wait.toFixed(0)} ms behind`);
    } else if (wait < CLEAN_MS) {
      slowStreak = 0;
      if (++cleanStreak >= CLEAN_STREAK && stepIndex > 0) setStep(stepIndex - 1, 'GPU keeping up');
    } else {
      slowStreak = 0;
      cleanStreak = 0;
    }
  };

  return {
    get factor() {
      return factor;
    },
    render(scene, camera) {
      if (supported === false) {
        renderer.render(scene, camera);
        return;
      }
      probe();
      renderer.getDrawingBufferSize(bufferSize);
      const width = Math.round(bufferSize.x * factor);
      const height = Math.round(bufferSize.y * factor);
      if (target.width !== width || target.height !== height) target.setSize(width, height);

      renderer.setRenderTarget(target);
      if (supported === null) {
        supported = ctx.checkFramebufferStatus(ctx.FRAMEBUFFER) === ctx.FRAMEBUFFER_COMPLETE && canSilencePresent();
        if (!supported) {
          // eslint-disable-next-line no-console
          console.warn('[Supersample] not supported on this device, rendering without anti-aliasing');
          renderer.setRenderTarget(null);
          renderer.render(scene, camera);
          return;
        }
        perf.set('ssFactor', factor);
      }
      scaleLights(scene, 1 / HEADROOM);
      try {
        renderWithoutPresenting(scene, camera);
      } finally {
        scaleLights(scene, HEADROOM);
      }
      renderer.setRenderTarget(null);
      renderer.render(quadScene, quadCamera);
    },
    dispose() {
      target.dispose();
      quadMaterial.dispose();
    },
  };
}

// Drop inside a <Canvas>: takes over R3F's render step (a priority-1
// useFrame stops R3F's own automatic render) and draws supersampled at up to
// `factor`, stepping down on a GPU that can't keep up (see above) unless
// `adaptive` is false.
export default function Supersample({ factor = 2, adaptive = true }) {
  const gl = useThree((state) => state.gl);
  const supersampler = useMemo(() => createSupersampler(gl, factor, adaptive), [gl, factor, adaptive]);
  useEffect(() => () => supersampler.dispose(), [supersampler]);
  useFrame(({ scene, camera }) => {
    perf.frame();
    const t0 = performance.now();
    supersampler.render(scene, camera);
    perf.add('render', performance.now() - t0);
  }, 1);
  return null;
}
