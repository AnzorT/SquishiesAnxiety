import { useEffect, useMemo } from 'react';
import { useFrame, useThree } from '@react-three/fiber';
import * as THREE from 'three';

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

function scaleLights(scene, factor) {
  scene.traverse((obj) => {
    if (obj.isLight) obj.intensity *= factor;
  });
}

export function createSupersampler(renderer, factor) {
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

  return {
    render(scene, camera) {
      if (supported === false) {
        renderer.render(scene, camera);
        return;
      }
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
// useFrame stops R3F's own automatic render) and draws supersampled.
export default function Supersample({ factor = 2 }) {
  const gl = useThree((state) => state.gl);
  const supersampler = useMemo(() => createSupersampler(gl, factor), [gl, factor]);
  useEffect(() => () => supersampler.dispose(), [supersampler]);
  useFrame(({ scene, camera }) => supersampler.render(scene, camera), 1);
  return null;
}
