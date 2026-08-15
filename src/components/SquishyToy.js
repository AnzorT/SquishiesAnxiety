import React, { forwardRef, useEffect, useImperativeHandle, useMemo, useRef, useState } from 'react';
import { useFrame, useThree } from '@react-three/fiber';
import * as THREE from 'three';
import { Asset } from 'expo-asset';
import { GLTFLoader } from 'three/examples/jsm/loaders/GLTFLoader.js';

// Ported from the "Squish Buddies" design (Cute Squishies standalone.html) —
// soft-body dent physics: a per-vertex spring field with grid diffusion
// (jelly wave propagation) and volume-conserving puff, plus a global squash
// spring, release wobble, drag-to-orbit with momentum, nose boop, blink and
// idle breathing. This file mirrors that source's `Component` class as
// closely as RN/expo-gl allows — the physics constants are unchanged.

export const COLOR_DEFS = [
  { name: 'Lilac', light: '#EFE0FF', mid: '#B18AE8', deep: '#7C4FC0', nose: '#F4A6C0' },
  { name: 'Blush', light: '#FFE6EF', mid: '#F293B8', deep: '#D85C8C', nose: '#FFD37A' },
  { name: 'Sky', light: '#E1F3FF', mid: '#7EC3EE', deep: '#3E8FCB', nose: '#FFC97A' },
  { name: 'Mint', light: '#E4FBEE', mid: '#7FD9AC', deep: '#3FA873', nose: '#FFB0C6' },
  { name: 'Peach', light: '#FFEEDE', mid: '#F5B27E', deep: '#E0864A', nose: '#8ED0C2' },
  { name: 'Seal', light: '#EDEFF0', mid: '#9AA7AE', deep: '#57666D', nose: '#2B2333' },
  { name: 'Cat', light: '#FBF8F4', mid: '#C9C2B8', deep: '#5B5750', nose: '#B98A82' },
  { name: 'Glitter', light: '#FFEFC2', mid: '#E3A62B', deep: '#A8760F', nose: '#2B2333' },
  { name: 'Cheese', light: '#FFF3D0', mid: '#F3C13D', deep: '#C89A26', nose: '#2B2333' },
];

// Each fill trades off how deep a poke sinks (strength), how fast the dent
// chases its target and decays (stiff/damp), and how hard the buddy wobbles
// on release (wobbleKick). Glitter Bead additionally bursts a few sparkle
// particles from the release point.
export const FILLS = [
  { key: 'foam', name: 'Memory Foam', desc: 'Slow rise, deep hold — presses low and eases back gently.', color: '#D8C8F3', strength: 1.3, stiff: 0.08, damp: 0.86, wobbleKick: 0.12 },
  { key: 'slime', name: 'Slime', desc: 'Fast rebound with a jiggly wobble on release.', color: '#B7E3C8', strength: 1.0, stiff: 0.22, damp: 0.62, wobbleKick: 0.5 },
  { key: 'glitter', name: 'Glitter Bead', desc: 'Shallow squish, quick pop, sparkles on release.', color: '#F7D98C', strength: 0.55, stiff: 0.26, damp: 0.74, wobbleKick: 0.3, sparkle: true },
];

const clamp = (v, lo, hi) => Math.max(lo, Math.min(hi, v));

// How sharp the cheese cube's edges are: 0 would leave it a sphere, 1 a
// hard-edged cube. This blends partway there for a soft, rounded-cube
// silhouette — still clearly a cube, but with the puffy squished-toy look.
const CHEESE_ROUNDNESS = 0.75;

// Sphere→cube surface projection: scale the point by its largest-magnitude
// component so that component becomes exactly ±1, landing it on the
// matching cube face (a direct radial projection onto an enclosing cube —
// sharp edges). Blended with the original sphere point by `roundness` for
// the rounded look. Used both to reshape the cheese's body and to place its
// face features on that same surface.
//
// NOTE: an earlier version of this used the standard cube→SPHERE formula
// (the one from cube-sphere planet-generation writeups) but backwards —
// feeding it sphere points instead of cube points. That formula only
// produces a real cube when it's given cube corners as input; fed sphere
// points, it just returns a barely-shrunk sphere regardless of roundness,
// which is why the cheese looked unchanged no matter how that constant was
// tuned. This is the actual inverse: a max-component radial projection.
function cubifyPoint(x, y, z, roundness) {
  const maxAbs = Math.max(Math.abs(x), Math.abs(y), Math.abs(z), 1e-6);
  const cx = x / maxAbs;
  const cy = y / maxAbs;
  const cz = z / maxAbs;
  return {
    x: x + (cx - x) * roundness,
    y: y + (cy - y) * roundness,
    z: z + (cz - z) * roundness,
  };
}

// A flat triangular prism (not a rounded cone) so cat ears read as clean
// pointed triangles instead of smooth bumps. Built as a unit shape (1 wide,
// 1 tall, 1 thick, centered on its own origin) so it drops into the same
// non-uniform mesh.scale pattern the other appendages (flippers, paws) use.
function makeEarGeo() {
  const shape = new THREE.Shape();
  shape.moveTo(-0.5, 0);
  shape.lineTo(0.5, 0);
  shape.lineTo(0, 1);
  shape.lineTo(-0.5, 0);
  const geo = new THREE.ExtrudeGeometry(shape, { depth: 1, bevelEnabled: false });
  geo.translate(0, -0.5, -0.5);
  return geo;
}

function buildToy(colorDefs, startIndex, fill, species = 'blob') {
  const group = new THREE.Group();
  const isSeal = species === 'seal';
  const isCat = species === 'cat';
  const isSparkle = species === 'sparkle';
  const isCheese = species === 'cheese';
  // Blob buddies stay a true unit sphere. The seal is the same soft-body
  // sphere stretched wide and flattened into a lying-down oval; the cat is
  // only slightly tallened for a sitting-upright look. The dent physics
  // below only ever reasons about distances from this base shape, so
  // reshaping it here is enough; nothing downstream needs to know. The
  // cheese isn't a simple per-axis stretch like the others — it's a full
  // sphere→cube surface remap (see cubifyPoint/placeOnSurface below) — so
  // it's left out of this scale and handled on its own.
  const shapeScale = isSeal ? { x: 1.32, y: 0.8, z: 0.98 } : isCat ? { x: 1.02, y: 1.1, z: 1.02 } : { x: 1, y: 1, z: 1 };
  // Places a point that's expressed in the same terms as the body's base
  // sphere (eyes/nose/mouth positions all still write plain sphere-relative
  // coordinates) onto whatever this species' actual body surface is.
  const placeOnSurface = (x, y, z) =>
    isCheese ? cubifyPoint(x, y, z, CHEESE_ROUNDNESS) : { x: x * shapeScale.x, y: y * shapeScale.y, z: z * shapeScale.z };

  // Segment counts were 44x30 (1395 verts) — a lot of per-vertex spring +
  // diffusion + normal work to redo every single frame on the JS thread.
  // 30x20 (651 verts) reads just as round/smooth at mobile screen sizes and
  // roughly halves that per-frame cost. The seal/cat/cheese get a bit more
  // resolution back for a cleaner-looking coat/hole pattern; only one toy
  // is ever on screen at a time, so the extra per-frame cost stays affordable.
  const widthSeg = isSeal ? 38 : isCat ? 34 : isCheese ? 38 : 30;
  const heightSeg = isSeal ? 26 : isCat ? 24 : isCheese ? 26 : 20;
  const geo = new THREE.SphereGeometry(1, widthSeg, heightSeg);
  const posAttr = geo.attributes.position;
  const colCount = widthSeg + 1;
  const rowCount = heightSeg + 1;
  const count = posAttr.count;

  if (isSeal) {
    // Speckled coat baked as per-vertex colors (layered sine "noise" on the
    // unit-sphere position, thresholded to blotches) rather than an image
    // texture — keeps the toy asset-free like the rest of this file.
    const lightCoat = new THREE.Color('#FBFCFC');
    const spotCoat = new THREE.Color('#2B3338');
    const tmpColor = new THREE.Color();
    const colorArr = new Float32Array(count * 3);
    for (let i = 0; i < count; i++) {
      const x = posAttr.getX(i);
      const y = posAttr.getY(i);
      const z = posAttr.getZ(i);
      const n =
        Math.sin(x * 6.2 + 1.3) * Math.cos(y * 5.4 + 2.1) * Math.sin(z * 7.1 + 0.6) +
        Math.sin(x * 12.4 - y * 9.8 + z * 5.5) * 0.4;
      // Hard cutoff instead of a blended gradient — every vertex is fully
      // light or fully dark, so only the rendered triangle edge shows any
      // in-between color instead of a wide smeared band.
      const blend = n > 0.22 ? 1 : 0;
      tmpColor.copy(lightCoat).lerp(spotCoat, blend);
      colorArr[i * 3] = tmpColor.r;
      colorArr[i * 3 + 1] = tmpColor.g;
      colorArr[i * 3 + 2] = tmpColor.b;
      posAttr.setXYZ(i, x * shapeScale.x, y * shapeScale.y, z * shapeScale.z);
    }
    geo.setAttribute('color', new THREE.BufferAttribute(colorArr, 3));
  }

  if (isCat) {
    // "Seal point" face mask baked as per-vertex colors — a mask needs one
    // clean, well-defined patch rather than scattered blotches, so this uses
    // a smooth distance field (blend ramps up near each center) instead of
    // the seal's noise-based coat above.
    const lightCoat = new THREE.Color('#FBF8F4');
    const maskCoat = new THREE.Color('#5B5750');
    const maskCenters = [
      { x: 0, y: 0.45, z: 0.55, r: 0.8 },
      { x: 0, y: 0.9, z: 0.15, r: 0.55 },
    ];
    const tmpColor = new THREE.Color();
    const colorArr = new Float32Array(count * 3);
    for (let i = 0; i < count; i++) {
      const x = posAttr.getX(i);
      const y = posAttr.getY(i);
      const z = posAttr.getZ(i);
      let maxSigned = -Infinity;
      for (let m = 0; m < maskCenters.length; m++) {
        const mc = maskCenters[m];
        const dx = x - mc.x;
        const dy = y - mc.y;
        const dz = z - mc.z;
        const signed = mc.r - Math.sqrt(dx * dx + dy * dy + dz * dz);
        if (signed > maxSigned) maxSigned = signed;
      }
      const blend = clamp((maxSigned + 0.08) / 0.16, 0, 1);
      tmpColor.copy(lightCoat).lerp(maskCoat, blend);
      colorArr[i * 3] = tmpColor.r;
      colorArr[i * 3 + 1] = tmpColor.g;
      colorArr[i * 3 + 2] = tmpColor.b;
      posAttr.setXYZ(i, x * shapeScale.x, y * shapeScale.y, z * shapeScale.z);
    }
    geo.setAttribute('color', new THREE.BufferAttribute(colorArr, 3));
  }

  if (isCheese) {
    // Cube silhouette via cubifyPoint, then a scattering of round craters
    // carved directly into that surface by pulling nearby vertices inward
    // (real geometry, not baked color) — so the holes actually catch
    // shadow the way a real cheese wedge's holes do, not a flat painted-on
    // circle. Roughly one cluster per cube face, each hole's own radius/
    // depth randomized a little for the size variety in the reference photo.
    // Geometry-only craters read as faint dimples once lit (this GPU's
    // shading is flat, see the material note below), so each hole also
    // bakes a shadow-dark vertex color in the same falloff — same trick
    // the seal/cat coats use — which is what actually makes them read as
    // holes rather than a slightly lumpy surface.
    const HOLE_RADIUS_MULT = 1.3;
    const HOLE_DEPTH_MULT = 2.5;
    const holes = [
      // front (z+)
      { x: -0.4, y: 0.35, z: 0.95, r: 0.22, d: 0.22 },
      { x: 0.3, y: 0.5, z: 0.95, r: 0.15, d: 0.16 },
      { x: 0.55, y: -0.5, z: 0.95, r: 0.2, d: 0.2 },
      { x: -0.55, y: -0.45, z: 0.95, r: 0.13, d: 0.14 },
      { x: 0.62, y: 0.15, z: 0.95, r: 0.1, d: 0.11 },
      { x: -0.62, y: 0.05, z: 0.95, r: 0.09, d: 0.1 },
      { x: 0.1, y: -0.62, z: 0.95, r: 0.1, d: 0.11 },
      // top (y+)
      { x: -0.3, y: 0.95, z: 0.3, r: 0.2, d: 0.19 },
      { x: 0.35, y: 0.95, z: -0.25, r: 0.16, d: 0.16 },
      { x: 0.05, y: 0.95, z: 0.5, r: 0.13, d: 0.13 },
      { x: -0.5, y: 0.95, z: -0.35, r: 0.15, d: 0.15 },
      { x: 0.55, y: 0.95, z: 0.15, r: 0.12, d: 0.12 },
      { x: -0.1, y: 0.95, z: -0.55, r: 0.11, d: 0.11 },
      // right (x+)
      { x: 0.95, y: 0.3, z: 0.3, r: 0.2, d: 0.19 },
      { x: 0.95, y: -0.4, z: 0.1, r: 0.16, d: 0.16 },
      { x: 0.95, y: 0.15, z: -0.45, r: 0.18, d: 0.17 },
      { x: 0.95, y: -0.1, z: 0.55, r: 0.12, d: 0.12 },
      { x: 0.95, y: 0.5, z: -0.1, r: 0.11, d: 0.11 },
      // left (x-)
      { x: -0.95, y: 0.25, z: 0.15, r: 0.18, d: 0.17 },
      { x: -0.95, y: -0.35, z: -0.25, r: 0.15, d: 0.15 },
      { x: -0.95, y: 0.1, z: -0.55, r: 0.12, d: 0.12 },
      { x: -0.95, y: -0.05, z: 0.5, r: 0.11, d: 0.11 },
      // back (z-)
      { x: 0.25, y: 0.3, z: -0.95, r: 0.18, d: 0.16 },
      { x: -0.3, y: -0.25, z: -0.95, r: 0.16, d: 0.15 },
      { x: 0.05, y: -0.55, z: -0.95, r: 0.12, d: 0.12 },
      { x: -0.05, y: 0.6, z: -0.95, r: 0.11, d: 0.11 },
      // bottom (y-) — visible once orbited/tossed around
      { x: 0.2, y: -0.95, z: -0.15, r: 0.16, d: 0.15 },
      { x: -0.25, y: -0.95, z: 0.25, r: 0.14, d: 0.13 },
      { x: 0.05, y: -0.95, z: 0.5, r: 0.12, d: 0.12 },
      { x: -0.5, y: -0.95, z: -0.15, r: 0.11, d: 0.11 },
    ].map((h) => ({ ...h, r: h.r * HOLE_RADIUS_MULT, d: h.d * HOLE_DEPTH_MULT }));
    const maxHoleDepth = Math.max(...holes.map((h) => h.d));
    const cheeseBase = new THREE.Color(colorDefs[startIndex].mid);
    // Real cheese-hole interiors aren't just a darker version of the cheese's
    // own yellow (what offsetHSL gave) — they read as a distinct brown rind
    // fading to near-black in the depths. Two-stop gradient instead of one
    // flat shadow tone, so shallow dimples read brown and only the deepest
    // holes go properly dark. Bold, fairly saturated tones on purpose —
    // muted/desaturated versions just blended into the cheese instead of
    // reading as a hole.
    const holeBrown = new THREE.Color('#5A2E0C');
    const holeDark = new THREE.Color('#0D0600');
    const tmpColor = new THREE.Color();
    const colorArr = new Float32Array(count * 3);
    for (let i = 0; i < count; i++) {
      const x = posAttr.getX(i);
      const y = posAttr.getY(i);
      const z = posAttr.getZ(i);
      const p = cubifyPoint(x, y, z, CHEESE_ROUNDNESS);
      let pull = 0;
      for (let h = 0; h < holes.length; h++) {
        const hole = holes[h];
        const dx = p.x - hole.x;
        const dy = p.y - hole.y;
        const dz = p.z - hole.z;
        const dist = Math.sqrt(dx * dx + dy * dy + dz * dz);
        if (dist < hole.r) {
          const t = 1 - dist / hole.r;
          const holePull = hole.d * t * t;
          if (holePull > pull) pull = holePull;
        }
      }
      const factor = 1 - pull;
      posAttr.setXYZ(i, p.x * factor, p.y * factor, p.z * factor);
      // Crossover at 0.4 (not the midpoint) so brown is just the entry rind
      // and black — the "strong" half of the ask — covers most of each
      // hole's actual depth.
      const t = clamp(pull / maxHoleDepth, 0, 1);
      if (t < 0.4) {
        tmpColor.copy(cheeseBase).lerp(holeBrown, t / 0.4);
      } else {
        tmpColor.copy(holeBrown).lerp(holeDark, (t - 0.4) / 0.6);
      }
      colorArr[i * 3] = tmpColor.r;
      colorArr[i * 3 + 1] = tmpColor.g;
      colorArr[i * 3 + 2] = tmpColor.b;
    }
    geo.setAttribute('color', new THREE.BufferAttribute(colorArr, 3));
  }

  geo.computeVertexNormals();

  const basePos = new Float32Array(posAttr.array);
  const vertCount = count;
  const dentAmt = new Float32Array(count);
  const dentTarget = new Float32Array(count);
  const dentVel = new Float32Array(count);
  // Reused every frame instead of `.slice()`-ing a fresh array each tick —
  // that allocation was garbage-collector pressure on every single frame.
  const dentScratch = new Float32Array(count);
  // Cached Gaussian falloff shape around the current touch point — recomputed
  // only when the point moves (see computeDentFall), not every render frame.
  const dentFall = new Float32Array(count);

  const current = colorDefs[startIndex];
  // The glitter ball is always the "Glitter Bead" fill (shallow squish, quick
  // pop, sparkle burst on release) regardless of whatever fill was passed in
  // — that physics feel and the release sparkles are its whole identity, not
  // a pickable option like it is for the classic blob.
  const resolvedFill = isSparkle ? FILLS[2] : fill;
  // NOTE: MeshPhysicalMaterial (transmission/clearcoat) and the custom
  // radial-gradient ShaderMaterial were dropped in favor of plain
  // MeshStandardMaterial / MeshBasicMaterial — expo-gl's emulated GPU driver
  // on this environment is unreliable with extra shader passes and custom
  // GLSL (intermittent hangs/blank surfaces on context init). The dent
  // physics — the mandatory part — is unaffected by this material choice.
  const usesVertexCoat = isSeal || isCat || isCheese;
  const bodyMat = new THREE.MeshStandardMaterial({
    // Vertex colors carry the seal/cat coat and the cheese's base color +
    // hole shading, so their material color stays neutral white — anything
    // else would tint the baked pattern.
    color: usesVertexCoat ? 0xffffff : new THREE.Color(current.mid),
    vertexColors: usesVertexCoat,
    // Lower roughness (shinier) for the glitter ball than the classic
    // blob — no metalness though (same reason as the flecks: no
    // environment map in this scene means a metallic body would go dark
    // rather than gold). The cheese is matte and fully opaque — real
    // cheese isn't glossy or translucent like the jelly-style buddies.
    roughness: usesVertexCoat ? 0.55 : isSparkle ? 0.08 : 0.18,
    metalness: 0,
    transparent: !usesVertexCoat,
    opacity: usesVertexCoat ? 1 : 0.92,
    side: THREE.DoubleSide,
  });

  const bodyMesh = new THREE.Mesh(geo, bodyMat);
  group.add(bodyMesh);

  // eyes — positions scaled with the body so they still sit on its surface
  // once the seal/cat shape stretches the sphere. The cat gets bigger,
  // rounder eyes (less squished on the z-axis) to match its big-eyed look;
  // the glitter ball and cheese's simple happy-face styles call for
  // something similar, just not quite as exaggerated.
  const isSimpleFace = isSparkle || isCheese;
  const eyeRadius = isCat ? 0.135 : isSimpleFace ? 0.105 : 0.09;
  const eyeAspectY = isCat ? 1.05 : isSimpleFace ? 1.1 : 1.25;
  const eyeAspectZ = isCat ? 0.75 : isSimpleFace ? 0.7 : 0.6;
  const eyeMat = new THREE.MeshStandardMaterial({ color: 0x2b2333, roughness: 0.35 });
  const eyeGeo = new THREE.SphereGeometry(eyeRadius, 16, 16);
  const eyeL = new THREE.Mesh(eyeGeo, eyeMat);
  const eyeLPos = placeOnSurface(-0.32, 0.28, 0.92);
  eyeL.position.set(eyeLPos.x, eyeLPos.y, eyeLPos.z);
  eyeL.scale.set(1, eyeAspectY, eyeAspectZ);
  const eyeR = eyeL.clone();
  const eyeRPos = placeOnSurface(0.32, 0.28, 0.92);
  eyeR.position.set(eyeRPos.x, eyeRPos.y, eyeRPos.z);
  group.add(eyeL, eyeR);
  const eyeLBase = eyeL.position.clone();
  const eyeRBase = eyeR.position.clone();

  const glintMat = new THREE.MeshBasicMaterial({ color: 0xffffff });
  const glintGeo = new THREE.SphereGeometry(isCat ? 0.035 : 0.025, 8, 8);
  const glintL = new THREE.Mesh(glintGeo, glintMat);
  const glintLPos = placeOnSurface(-0.36, 0.33, 0.99);
  glintL.position.set(glintLPos.x, glintLPos.y, glintLPos.z);
  const glintR = glintL.clone();
  const glintRPos = placeOnSurface(0.28, 0.33, 0.99);
  glintR.position.set(glintRPos.x, glintRPos.y, glintRPos.z);
  group.add(glintL, glintR);
  const glintLBase = glintL.position.clone();
  const glintRBase = glintR.position.clone();

  // The seal's nose is unlit (MeshBasicMaterial) so it renders as a flat,
  // fully-saturated black regardless of scene lighting — a lit material
  // picks up ambient/directional light and reads as a soft dark grey smudge
  // instead of a solid black button. The cat's nose is a small lit button
  // too (a thin ring reads like candy, not a muzzle) but doesn't need the
  // unlit trick since it isn't going for a near-black color. The glitter
  // ball and cheese's references have no nose at all (just eyes + a smile)
  // — rather than special-case them out of the shared nose/boop system,
  // they keep a same-size nose mesh made fully transparent: raycasting hits
  // geometry regardless of material opacity, so the boop interaction still
  // works, it's just invisible.
  const noseGroup = new THREE.Group();
  const nosePos = placeOnSurface(0, 0.02, 1.02);
  noseGroup.position.set(nosePos.x, nosePos.y, nosePos.z);
  const noseMat = isSeal
    ? new THREE.MeshBasicMaterial({ color: 0x141414 })
    : new THREE.MeshStandardMaterial({
        color: new THREE.Color(isCat ? '#B98A82' : current.nose),
        roughness: 0.4,
        transparent: isSimpleFace,
        opacity: isSimpleFace ? 0 : 1,
      });
  // A thin torus at seal/cat/sparkle/cheese scale aliased into a blurry
  // smudge on the low-res GPU driver — a small flattened sphere ("button"
  // nose) stays solid and crisp at that size.
  const noseGeo =
    isSeal || isCat || isSimpleFace ? new THREE.SphereGeometry(0.1, 16, 16) : new THREE.TorusGeometry(0.13, 0.055, 16, 32);
  const noseTorus = new THREE.Mesh(noseGeo, noseMat);
  if (isSeal) noseTorus.scale.set(1, 0.75, 0.6);
  if (isCat) noseTorus.scale.set(0.85, 0.7, 0.6);
  noseGroup.add(noseTorus);
  group.add(noseGroup);
  const noseBase = noseGroup.position.clone();

  // Extra appendages (seal flippers/tail, cat ears/paws) — pushed into
  // featureBases below so they get the same per-poke dent response as the
  // eyes/nose (they already rode along with the whole-body squash/rotation
  // via `group`, but a poke landing near one didn't make it react on its
  // own; now it does).
  const appendages = [];
  const addAppendage = (geo, mat, x, y, z, sx, sy, sz, rotZ = 0) => {
    const m = new THREE.Mesh(geo, mat);
    m.position.set(x, y, z);
    m.scale.set(sx, sy, sz);
    m.rotation.z = rotZ;
    group.add(m);
    appendages.push({ mesh: m, base: m.position.clone(), baseScale: new THREE.Vector3(sx, sy, sz) });
    return m;
  };

  if (isSeal) {
    const flipperMat = new THREE.MeshStandardMaterial({ color: new THREE.Color('#3F4B52'), roughness: 0.6 });
    const flipperGeo = new THREE.SphereGeometry(1, 12, 10);
    addAppendage(flipperGeo, flipperMat, -1.05, -0.32, 0.42, 0.3, 0.13, 0.4, 0.55);
    addAppendage(flipperGeo, flipperMat, 1.05, -0.32, 0.42, 0.3, 0.13, 0.4, -0.55);
    // Tail — centered on X (unlike the two side flippers) so it sits in the
    // middle of the back rather than off to one side.
    addAppendage(flipperGeo, flipperMat, 0, -0.1, -0.95, 0.3, 0.14, 0.34, 0);
  }

  if (isCat) {
    // DoubleSide so the ears don't vanish when the toy is orbited around to
    // face away from camera.
    const earMat = new THREE.MeshStandardMaterial({ color: new THREE.Color('#5B5750'), roughness: 0.55, side: THREE.DoubleSide });
    const earGeo = makeEarGeo();
    // Raised further above the crown (vs. a cone half-buried in the head)
    // so the pointed tip clearly reads above the silhouette.
    addAppendage(earGeo, earMat, -0.4, 1.0, 0.18, 0.34, 0.48, 0.16, -0.22);
    addAppendage(earGeo, earMat, 0.4, 1.0, 0.18, 0.34, 0.48, 0.16, 0.22);

    const pawMat = new THREE.MeshStandardMaterial({ color: new THREE.Color('#F0ECE6'), roughness: 0.55 });
    const pawGeo = new THREE.SphereGeometry(1, 12, 10);
    addAppendage(pawGeo, pawMat, -0.4, -0.95, 0.65, 0.32, 0.24, 0.36, 0);
    addAppendage(pawGeo, pawMat, 0.4, -0.95, 0.65, 0.32, 0.24, 0.36, 0);
  }

  let mouthMesh = null;
  const flecks = [];
  if (isSimpleFace) {
    // Smile — a partial torus (an "arc", not a full ring) using MeshBasicMaterial
    // for a flat, fully-saturated line rather than a lit/shaded one. TorusGeometry's
    // arc starts at angle 0 (+X axis) and sweeps counter-clockwise, so this rotation
    // re-centers that arc on the bottom of the ring (angle -90°) to read as a "u"-
    // shaped smile instead of whatever arbitrary slice the default start would draw.
    const mouthArc = Math.PI * 0.6;
    const mouthMat = new THREE.MeshBasicMaterial({ color: 0x2b2333 });
    const mouthGeo = new THREE.TorusGeometry(0.16, 0.028, 8, 24, mouthArc);
    const mouthPos = placeOnSurface(0, -0.12, 0.95);
    mouthMesh = addAppendage(mouthGeo, mouthMat, mouthPos.x, mouthPos.y, mouthPos.z, 1, 1, 1, -Math.PI / 2 - mouthArc / 2);
  }

  if (isSparkle) {
    // Glitter flecks — tiny faceted metallic shards (an octahedron, not a
    // smooth sphere) scattered over the surface via a Fibonacci/golden-angle
    // distribution, each with a random orientation so their flat faces catch
    // the scene's directional lights differently — that per-fleck brightness
    // variation is what actually reads as "sparkle"; uniform matte dots
    // (the first attempt) just looked like flat polka dots regardless of
    // color.
    //
    // Each fleck also tracks the body vertex nearest its resting spot (found
    // once here, a one-time ~40 x vertCount search — negligible next to
    // rebuilding this every frame). tickPhysics then re-applies that
    // vertex's own dent factor to the fleck every frame, so a fleck sitting
    // in a poked patch sinks inward exactly as much as the jelly under it
    // does, instead of floating in place while the surface dents around it.
    // High metalness with no environment map in this scene means almost no
    // diffuse reflectance — metals only show color via specular highlights,
    // so they read as black everywhere except a direct hotspot. Flat
    // metalness: 0 keeps them lit (and reliably white) by the scene's
    // regular ambient/directional lights instead, while low roughness still
    // gives each fleck a shiny specular glint.
    const FLECK_COUNT = 40;
    const fleckMats = [new THREE.MeshStandardMaterial({ color: 0xffffff, metalness: 0, roughness: 0.15 })];
    for (let i = 0; i < FLECK_COUNT; i++) {
      const t = i / (FLECK_COUNT - 1);
      const phi = Math.acos(1 - 2 * t);
      const theta = Math.PI * (1 + Math.sqrt(5)) * i;
      const fx = Math.sin(phi) * Math.cos(theta);
      const fy = Math.cos(phi);
      const fz = Math.sin(phi) * Math.sin(theta);
      const fleckSize = 0.016 + Math.random() * 0.018;
      const bx = fx * 1.015 * shapeScale.x;
      const by = fy * 1.015 * shapeScale.y;
      const bz = fz * 1.015 * shapeScale.z;
      const fleckGeo = new THREE.OctahedronGeometry(fleckSize, 0);
      const fleck = new THREE.Mesh(fleckGeo, fleckMats[i % fleckMats.length]);
      fleck.position.set(bx, by, bz);
      fleck.rotation.set(Math.random() * Math.PI, Math.random() * Math.PI, Math.random() * Math.PI);
      group.add(fleck);

      let nearestIdx = 0;
      let nearestDist = Infinity;
      for (let v = 0; v < vertCount; v++) {
        const dx = basePos[v * 3] - bx;
        const dy = basePos[v * 3 + 1] - by;
        const dz = basePos[v * 3 + 2] - bz;
        const d2 = dx * dx + dy * dy + dz * dz;
        if (d2 < nearestDist) {
          nearestDist = d2;
          nearestIdx = v;
        }
      }
      flecks.push({ mesh: fleck, bx, by, bz, vertIdx: nearestIdx });
    }
  }

  const featureBases = [eyeLBase, eyeRBase, glintLBase, glintRBase, noseBase, ...appendages.map((a) => a.base)];
  const featureDentAmt = new Float32Array(featureBases.length);
  const featureDentVel = new Float32Array(featureBases.length);
  const featureDentTarget = new Float32Array(featureBases.length);
  const featureDentFall = new Float32Array(featureBases.length);

  // contact shadow — flat translucent ellipse
  const shMat = new THREE.MeshBasicMaterial({
    color: isSeal ? 0x3a4750 : isCat ? 0x4a4238 : isCheese ? 0x6b5330 : 0x5a3c82,
    transparent: true,
    opacity: 0.28,
    depthWrite: false,
  });
  const shadowMesh = new THREE.Mesh(new THREE.CircleGeometry(1, 32), shMat);
  shadowMesh.scale.set(isSeal ? 1.5 : isCat ? 1.15 : isCheese ? 1.25 : 1.3, 0.5, 1);
  shadowMesh.position.set(0, -1.35, -0.3);
  shadowMesh.rotation.x = -Math.PI / 2.5;

  const sparkleGroup = new THREE.Group();

  return {
    group,
    shadowMesh,
    bodyMesh,
    bodyGeo: geo,
    bodyMat,
    noseGroup,
    noseTorus,
    noseMat,
    eyeL,
    eyeR,
    glintL,
    glintR,
    eyeAspectY,
    eyeAspectZ,
    appendages,
    mouthMesh,
    flecks,
    basePos,
    vertCount,
    colCount,
    rowCount,
    dentAmt,
    dentTarget,
    dentVel,
    dentScratch,
    dentFall,
    normalsFrameToggle: false,
    featureBases,
    featureDentAmt,
    featureDentVel,
    featureDentTarget,
    featureDentFall,
    fill: resolvedFill,
    sparkleGroup,
    sparkles: [],
    selected: startIndex,
    mode: null,
    dragStartWorld: null,
    pressLocalSmoothed: null,
    pressHoldTime: 0,
    globalSquash: 0,
    globalSquashV: 0,
    globalSquashTarget: 0,
    wobbleRotX: 0,
    wobbleRotXV: 0,
    wobbleRotZ: 0,
    wobbleRotZV: 0,
    userRotY: 0,
    userRotX: 0,
    orbitTargetY: 0,
    orbitTargetX: 0,
    orbitVelY: 0,
    orbitVelX: 0,
    idlePhase: Math.random() * 10,
    blinkTimer: 2 + Math.random() * 3,
    blinkAmt: 0,
    noseSquash: 0,
    noseSquashV: 0,
    noseTarget: 0,
    noseFeatureSquish: 1,
  };
}

// ---- Imported-mesh species (e.g. Cloude, built from a real 3D scan/AI-
// generated asset instead of the procedural sphere above) ----
//
// The procedural toys above all share one sphere geometry with a known
// `rows x cols` UV-sphere vertex layout, which is what lets tickPhysics's
// jelly-wave diffusion step look up each vertex's 4 grid neighbors by simple
// index math. An imported mesh has no such structure — its vertices come in
// whatever order the modeling tool exported them — so it needs its own
// real adjacency list (built once from the mesh's triangle index buffer)
// and a topology-agnostic diffusion step that walks that list instead of
// assuming a grid. See the `s.neighbors` branch in tickPhysics below.
//
// Everything else (the per-vertex spring toward a Gaussian falloff dent
// target, the global squash/wobble, blink, orbit) already only reasons
// about vertex positions/distances, so it works unmodified on any mesh.

const CLOUDE_ASSET = require('../../assets/models/cloude_3d.glb');

// Cached at module scope — re-opening Cloude within the same app session
// re-parses a fresh geometry (see buildCloudeToy) but doesn't re-fetch/
// re-decode the same ~100KB glb off disk every time.
let cloudeGltfPromise = null;
function loadCloudeGltf() {
  if (!cloudeGltfPromise) {
    cloudeGltfPromise = (async () => {
      const asset = Asset.fromModule(CLOUDE_ASSET);
      await asset.downloadAsync();
      const response = await fetch(asset.localUri || asset.uri);
      const arrayBuffer = await response.arrayBuffer();
      return new Promise((resolve, reject) => {
        new GLTFLoader().parse(arrayBuffer, '', resolve, reject);
      });
    })();
  }
  return cloudeGltfPromise;
}

// One-time-per-load adjacency build: every vertex that shares a triangle
// with vertex i is a "neighbor" of i, same relationship the sphere grid's
// left/right/up/down look-up captures, just derived from real topology
// instead of assumed row/col math.
function buildAdjacency(indexArray, vertCount) {
  const neighborSets = new Array(vertCount);
  for (let i = 0; i < vertCount; i++) neighborSets[i] = new Set();
  for (let t = 0; t < indexArray.length; t += 3) {
    const a = indexArray[t];
    const b = indexArray[t + 1];
    const c = indexArray[t + 2];
    neighborSets[a].add(b);
    neighborSets[a].add(c);
    neighborSets[b].add(a);
    neighborSets[b].add(c);
    neighborSets[c].add(a);
    neighborSets[c].add(b);
  }
  return neighborSets.map((set) => Uint32Array.from(set));
}

async function buildCloudeToy(fill) {
  const gltf = await loadCloudeGltf();
  let sourceMesh = null;
  gltf.scene.traverse((obj) => {
    if (!sourceMesh && obj.isMesh) sourceMesh = obj;
  });
  if (!sourceMesh) throw new Error('cloude_3d.glb: no mesh found in scene');

  // Cloned so a second concurrently-open Cloude (fast back-to-back visits)
  // never shares — and fights over — the same live position buffer during
  // dent physics.
  const geo = sourceMesh.geometry.clone();
  geo.computeBoundingBox();

  // Recenter on the model's own bounding-box center and rescale to roughly
  // the same on-screen size as the procedural toys (built on a radius-1
  // sphere centered at the origin) — the raw export's pivot sits at its
  // base (y from 0 upward, not centered) and is about half that size, so
  // without this it renders small and low instead of where SquishScreen's
  // camera actually frames the toy stage.
  const rawCenter = new THREE.Vector3();
  geo.boundingBox.getCenter(rawCenter);
  const rawSize = new THREE.Vector3();
  geo.boundingBox.getSize(rawSize);
  const rawMaxDim = Math.max(rawSize.x, rawSize.y, rawSize.z) || 1;
  const importScale = 2 / rawMaxDim;
  const rawPos = geo.attributes.position.array;
  for (let i = 0; i < rawPos.length; i += 3) {
    rawPos[i] = (rawPos[i] - rawCenter.x) * importScale;
    rawPos[i + 1] = (rawPos[i + 1] - rawCenter.y) * importScale;
    rawPos[i + 2] = (rawPos[i + 2] - rawCenter.z) * importScale;
  }
  geo.attributes.position.needsUpdate = true;
  geo.computeVertexNormals();
  geo.computeBoundingBox();

  const posAttr = geo.attributes.position;
  const vertCount = posAttr.count;
  const basePos = new Float32Array(posAttr.array);

  const indexAttr = geo.getIndex();
  const indexArray = indexAttr ? indexAttr.array : Uint32Array.from({ length: vertCount }, (_, i) => i);
  const neighbors = buildAdjacency(indexArray, vertCount);

  const dentAmt = new Float32Array(vertCount);
  const dentTarget = new Float32Array(vertCount);
  const dentVel = new Float32Array(vertCount);
  const dentScratch = new Float32Array(vertCount);
  const dentFall = new Float32Array(vertCount);

  const sourceMap = sourceMesh.material && sourceMesh.material.map ? sourceMesh.material.map : null;
  const bodyMat = new THREE.MeshStandardMaterial({
    map: sourceMap,
    color: 0xffffff,
    roughness: 0.55,
    metalness: 0,
    side: THREE.DoubleSide,
  });
  const bodyMesh = new THREE.Mesh(geo, bodyMat);

  const group = new THREE.Group();
  group.add(bodyMesh);

  // Invisible placeholders — tickPhysics unconditionally animates eyeL/
  // eyeR (the blink) and raycastHit always tests noseTorus/eyeL/eyeR, so
  // these need to exist even though Cloude's face is painted into its
  // texture rather than built from separate meshes like the other species.
  // Parked well clear of the body so nothing ever actually raycast-hits
  // them — every tap on Cloude resolves to a normal squish poke rather
  // than the nose-boop special case (there's no reliable way to know
  // where the painted nose sits in mesh space without inspecting the UVs,
  // so boop support is left for later rather than guessed at).
  const invisMat = new THREE.MeshBasicMaterial({ transparent: true, opacity: 0 });
  const invisGeo = new THREE.SphereGeometry(0.02, 4, 4);
  const makeInvisible = () => {
    const m = new THREE.Mesh(invisGeo, invisMat);
    m.position.set(0, -1000, 0);
    return m;
  };
  const eyeL = makeInvisible();
  const eyeR = makeInvisible();
  const glintL = makeInvisible();
  const glintR = makeInvisible();
  const noseGroup = new THREE.Group();
  noseGroup.position.set(0, -1000, 0);
  const noseTorus = makeInvisible();
  noseGroup.add(noseTorus);
  group.add(eyeL, eyeR, glintL, glintR, noseGroup);

  // Same fixed shadow the default "blob" species uses — now that the
  // geometry above is recentered/rescaled to that same ~2-unit-diameter
  // convention, there's no need to derive this from Cloude's own bbox.
  const shMat = new THREE.MeshBasicMaterial({ color: 0x5a3c82, transparent: true, opacity: 0.28, depthWrite: false });
  const shadowMesh = new THREE.Mesh(new THREE.CircleGeometry(1, 32), shMat);
  shadowMesh.scale.set(1.3, 0.5, 1);
  shadowMesh.position.set(0, -1.35, -0.3);
  shadowMesh.rotation.x = -Math.PI / 2.5;

  return {
    group,
    shadowMesh,
    bodyMesh,
    bodyGeo: geo,
    bodyMat,
    noseGroup,
    noseTorus,
    noseMat: invisMat,
    eyeL,
    eyeR,
    glintL,
    glintR,
    eyeAspectY: 1,
    eyeAspectZ: 1,
    appendages: [],
    mouthMesh: null,
    flecks: [],
    basePos,
    vertCount,
    neighbors,
    dentAmt,
    dentTarget,
    dentVel,
    dentScratch,
    dentFall,
    normalsFrameToggle: false,
    featureBases: [],
    featureDentAmt: new Float32Array(0),
    featureDentVel: new Float32Array(0),
    featureDentTarget: new Float32Array(0),
    featureDentFall: new Float32Array(0),
    fill,
    sparkleGroup: new THREE.Group(),
    sparkles: [],
    selected: 0,
    mode: null,
    dragStartWorld: null,
    pressLocalSmoothed: null,
    pressHoldTime: 0,
    globalSquash: 0,
    globalSquashV: 0,
    globalSquashTarget: 0,
    wobbleRotX: 0,
    wobbleRotXV: 0,
    wobbleRotZ: 0,
    wobbleRotZV: 0,
    userRotY: 0,
    userRotX: 0,
    orbitTargetY: 0,
    orbitTargetX: 0,
    orbitVelY: 0,
    orbitVelX: 0,
    idlePhase: Math.random() * 10,
    blinkTimer: 2 + Math.random() * 3,
    blinkAmt: 0,
    noseSquash: 0,
    noseSquashV: 0,
    noseTarget: 0,
    noseFeatureSquish: 1,
  };
}

function spawnSparkles(s, localPoint) {
  for (let i = 0; i < 14; i++) {
    const mat = new THREE.MeshBasicMaterial({ color: 0xffffff, transparent: true, opacity: 1 });
    const mesh = new THREE.Mesh(new THREE.SphereGeometry(0.028, 6, 6), mat);
    mesh.position.copy(localPoint);
    const dir = new THREE.Vector3(Math.random() - 0.5, Math.random() - 0.5, Math.random() - 0.5).normalize();
    s.sparkleGroup.add(mesh);
    s.sparkles.push({ mesh, mat, vel: dir.multiplyScalar(1.6 + Math.random() * 1.2), age: 0 });
  }
}

// The Gaussian falloff shape only depends on the touch point's position, not
// on how long it's been held — so it's cached here and recomputed only when
// the point actually moves, instead of on every rendered frame (see
// applyDentScale, which runs per-frame and is a cheap rescale of this cache).
function computeDentFall(s, localPoint) {
  const sigma = 0.3;
  const sigmaFactor = -1 / (2 * sigma * sigma);
  for (let i = 0; i < s.vertCount; i++) {
    const bx = s.basePos[i * 3];
    const by = s.basePos[i * 3 + 1];
    const bz = s.basePos[i * 3 + 2];
    const dx = bx - localPoint.x;
    const dy = by - localPoint.y;
    const dz = bz - localPoint.z;
    const d2 = dx * dx + dy * dy + dz * dz;
    s.dentFall[i] = Math.exp(d2 * sigmaFactor);
  }
  const featureSigma = 0.32;
  const featureSigmaFactor = -1 / (2 * featureSigma * featureSigma);
  for (let j = 0; j < s.featureBases.length; j++) {
    const b = s.featureBases[j];
    const dx = b.x - localPoint.x;
    const dy = b.y - localPoint.y;
    const dz = b.z - localPoint.z;
    const d2 = dx * dx + dy * dy + dz * dz;
    s.featureDentFall[j] = Math.exp(d2 * featureSigmaFactor);
  }
}

function applyDentScale(s, depthMul) {
  const maxDent = 0.7 * s.fill.strength * depthMul;
  for (let i = 0; i < s.vertCount; i++) {
    s.dentTarget[i] = maxDent * s.dentFall[i];
  }
  for (let j = 0; j < s.featureBases.length; j++) {
    s.featureDentTarget[j] = maxDent * s.featureDentFall[j] * 1.15;
  }
}

function resetDentTargets(s) {
  s.dentTarget.fill(0);
  s.featureDentTarget.fill(0);
}

function raycastHit(s, camera, raycaster, ndcX, ndcY) {
  raycaster.setFromCamera({ x: ndcX, y: ndcY }, camera);
  const hits = raycaster.intersectObjects([s.bodyMesh, s.noseTorus, s.eyeL, s.eyeR], false);
  return hits.length ? hits[0] : null;
}

function tickPhysics(s, dt) {
  const k = dt * 60;

  s.idlePhase += 0.016 * k;

  s.blinkTimer -= dt;
  if (s.blinkTimer <= 0 && s.blinkAmt <= 0.01) {
    s.blinkAmt = 1;
    s.blinkTimer = 2.5 + Math.random() * 3.5;
  }
  s.blinkAmt = Math.max(0, s.blinkAmt - 0.09 * k);

  if (s.mode === 'poke' && s.pressLocalSmoothed) {
    s.pressHoldTime += dt;
    const depthMul = 1 + s.pressHoldTime * 1.4;
    applyDentScale(s, depthMul);
  }

  const dentStiff = 1 - Math.pow(1 - s.fill.stiff, k);
  const dentDamp = Math.pow(s.fill.damp, k);
  for (let i = 0; i < s.vertCount; i++) {
    s.dentVel[i] += (s.dentTarget[i] - s.dentAmt[i]) * dentStiff;
    s.dentVel[i] *= dentDamp;
    s.dentAmt[i] += s.dentVel[i];
  }

  s.dentScratch.set(s.dentAmt);
  const prev = s.dentScratch;
  const diffCoef = 0.024 * k;
  if (s.neighbors) {
    // Imported mesh (e.g. Cloude) — no assumed row/col grid, so diffuse
    // across each vertex's real triangle-adjacency instead. Normalized by
    // neighbor count so the diffusion rate doesn't swing with local mesh
    // density, then rescaled by 4 to land in the same range the 4-neighbor
    // grid case below produces, so `diffCoef` means roughly the same thing
    // in both branches.
    for (let i = 0; i < s.vertCount; i++) {
      const nbrs = s.neighbors[i];
      const n = nbrs.length;
      if (!n) continue;
      let sum = 0;
      for (let ni = 0; ni < n; ni++) sum += prev[nbrs[ni]] - prev[i];
      s.dentAmt[i] += (sum / n) * 4 * diffCoef;
    }
  } else {
    const rows = s.rowCount;
    const cols = s.colCount;
    for (let r = 0; r < rows; r++) {
      for (let c = 0; c < cols; c++) {
        const idx = r * cols + c;
        const cl = c === 0 ? cols - 1 : c - 1;
        const cr = c === cols - 1 ? 0 : c + 1;
        const left = prev[r * cols + cl];
        const right = prev[r * cols + cr];
        const up = r > 0 ? prev[(r - 1) * cols + c] : prev[idx];
        const down = r < rows - 1 ? prev[(r + 1) * cols + c] : prev[idx];
        s.dentAmt[idx] += ((left + right - 2 * prev[idx]) + (up + down - 2 * prev[idx])) * diffCoef;
      }
    }
  }

  let sum = 0;
  for (let i = 0; i < s.vertCount; i++) sum += s.dentAmt[i];
  const meanDent = sum / s.vertCount;

  const posAttr = s.bodyGeo.attributes.position;
  for (let i = 0; i < s.vertCount; i++) {
    const bx = s.basePos[i * 3];
    const by = s.basePos[i * 3 + 1];
    const bz = s.basePos[i * 3 + 2];
    const factor = clamp(1 - s.dentAmt[i] + meanDent * 0.2, 0.74, 1.14);
    posAttr.setXYZ(i, bx * factor, by * factor, bz * factor);
  }
  posAttr.needsUpdate = true;
  // Recomputing normals for every vertex is the single priciest call in this
  // loop — the dent moves smoothly frame to frame, so refreshing shading
  // normals at half rate (every other frame) is not noticeable but roughly
  // halves that cost.
  s.normalsFrameToggle = !s.normalsFrameToggle;
  if (s.normalsFrameToggle) {
    s.bodyGeo.computeVertexNormals();
  }

  // Glitter flecks ride the exact dent factor of the body vertex nearest
  // each one's resting spot, so they sink inward/outward in lockstep with
  // the patch of jelly they sit on instead of floating fixed in place.
  for (let i = 0; i < s.flecks.length; i++) {
    const f = s.flecks[i];
    const factor = clamp(1 - s.dentAmt[f.vertIdx] + meanDent * 0.2, 0.74, 1.14);
    f.mesh.position.set(f.bx * factor, f.by * factor, f.bz * factor);
  }

  for (let j = 0; j < s.featureBases.length; j++) {
    s.featureDentVel[j] += (s.featureDentTarget[j] - s.featureDentAmt[j]) * dentStiff;
    s.featureDentVel[j] *= dentDamp;
    s.featureDentAmt[j] += s.featureDentVel[j];
    const factor = clamp(1 - s.featureDentAmt[j] * 1.5 + meanDent * 0.2, 0.5, 1.2);
    const squish = clamp(1 - s.featureDentAmt[j] * 0.75, 0.62, 1);
    const b = s.featureBases[j];
    if (j === 0) {
      s.eyeL.position.set(b.x * factor, b.y * factor, b.z * factor);
      s.eyeL.scale.set(squish, s.eyeAspectY * squish, s.eyeAspectZ * squish);
    }
    if (j === 1) {
      s.eyeR.position.set(b.x * factor, b.y * factor, b.z * factor);
      s.eyeR.scale.set(squish, s.eyeAspectY * squish, s.eyeAspectZ * squish);
    }
    if (j === 2) {
      s.glintL.position.set(b.x * factor, b.y * factor, b.z * factor);
      s.glintL.scale.setScalar(squish);
    }
    if (j === 3) {
      s.glintR.position.set(b.x * factor, b.y * factor, b.z * factor);
      s.glintR.scale.setScalar(squish);
    }
    if (j === 4) {
      s.noseGroup.position.set(b.x * factor, b.y * factor, b.z * factor);
      s.noseFeatureSquish = squish;
    }
    if (j >= 5) {
      const ap = s.appendages[j - 5];
      ap.mesh.position.set(b.x * factor, b.y * factor, b.z * factor);
      ap.mesh.scale.set(ap.baseScale.x * squish, ap.baseScale.y * squish, ap.baseScale.z * squish);
    }
  }

  const squashStiff = 1 - Math.pow(1 - 0.15, k);
  const squashDamp = Math.pow(0.78, k);
  s.globalSquashV += (s.globalSquashTarget - s.globalSquash) * squashStiff;
  s.globalSquashV *= squashDamp;
  s.globalSquash += s.globalSquashV;

  // The mouth's own local-proximity dent (set above, same as any other
  // feature) only shows up when poked right near it. Layering an extra
  // stretch/compress driven by globalSquash — which responds to a poke
  // anywhere on the body, not just nearby — makes the smile visibly react
  // no matter where the toy gets squished, multiplied on top of (not
  // replacing) that local reaction.
  if (s.mouthMesh) {
    s.mouthMesh.scale.x *= 1 + s.globalSquash * 0.6;
    s.mouthMesh.scale.y *= 1 - s.globalSquash * 0.4;
  }

  const wobbleStiff = 1 - Math.pow(1 - 0.08, k);
  const wobbleDamp = Math.pow(0.87, k);
  s.wobbleRotXV += (0 - s.wobbleRotX) * wobbleStiff;
  s.wobbleRotXV *= wobbleDamp;
  s.wobbleRotX += s.wobbleRotXV;
  s.wobbleRotZV += (0 - s.wobbleRotZ) * wobbleStiff;
  s.wobbleRotZV *= wobbleDamp;
  s.wobbleRotZ += s.wobbleRotZV;

  if (s.mode !== 'orbit') {
    const orbitDecay = Math.pow(0.93, k);
    s.orbitVelY *= orbitDecay;
    s.orbitVelX *= orbitDecay;
    s.orbitTargetY += s.orbitVelY * k;
    s.orbitTargetX += s.orbitVelX * k;
  }
  const orbitCatchup = Math.min(1, 0.22 * k);
  s.userRotY += (s.orbitTargetY - s.userRotY) * orbitCatchup;
  s.userRotX += (s.orbitTargetX - s.userRotX) * orbitCatchup;

  const breathe = 1 + Math.sin(s.idlePhase * 0.45) * 0.012;
  const sx = (1 + s.globalSquash * 0.09) * breathe;
  const sy = (1 - s.globalSquash * 0.16) * breathe;
  const sz = (1 + s.globalSquash * 0.09) * breathe;

  s.group.rotation.y = s.userRotY + Math.sin(s.idlePhase * 0.2) * 0.03;
  s.group.rotation.x = s.userRotX + s.wobbleRotX;
  s.group.rotation.z = s.wobbleRotZ;
  s.group.scale.set(sx, sy, sz);

  s.noseSquashV += (s.noseTarget - s.noseSquash) * 0.3;
  s.noseSquashV *= 0.6;
  s.noseSquash += s.noseSquashV;
  const ns = (1 - s.noseSquash * 0.35) * (s.noseFeatureSquish || 1);
  s.noseGroup.scale.set(ns, ns, ns);

  const blinkScale = 1 - s.blinkAmt * 0.88;
  s.eyeL.scale.y = s.eyeAspectY * blinkScale;
  s.eyeR.scale.y = s.eyeAspectY * blinkScale;

  for (let i = s.sparkles.length - 1; i >= 0; i--) {
    const sp = s.sparkles[i];
    sp.age += dt;
    sp.mesh.position.addScaledVector(sp.vel, dt);
    sp.vel.multiplyScalar(0.92);
    const op = Math.max(0, 1 - sp.age / 0.6);
    sp.mat.opacity = op;
    sp.mesh.scale.setScalar(op);
    if (op <= 0) {
      s.sparkleGroup.remove(sp.mesh);
      sp.mat.dispose();
      sp.mesh.geometry.dispose();
      s.sparkles.splice(i, 1);
    }
  }
}

const SquishyToy = forwardRef(function SquishyToy(
  { startingColorIndex = 0, startingFillIndex = 1, species = 'blob', onSquish, onRelease, onBoop },
  ref
) {
  const { camera } = useThree();
  const toyRef = useRef(null);
  const raycaster = useMemo(() => new THREE.Raycaster(), []);
  // Procedural species build synchronously (unchanged); Cloude loads its
  // mesh from disk first, so `built` starts null and the toy just isn't
  // rendered/interactive for the brief window before that resolves — same
  // "not ready yet" shape the rest of this file already null-guards for
  // (toyRef.current starts null too, and every imperative-handle method
  // already bails via `if (!s) return`).
  const [built, setBuilt] = useState(null);

  useEffect(() => {
    let cancelled = false;
    let builtResult = null;

    const buildPromise =
      species === 'cloude'
        ? buildCloudeToy(FILLS[startingFillIndex])
        : Promise.resolve(buildToy(COLOR_DEFS, startingColorIndex, FILLS[startingFillIndex], species));

    buildPromise
      .then((result) => {
        if (cancelled) {
          result.bodyGeo.dispose();
          result.bodyMat.dispose();
          return;
        }
        builtResult = result;
        toyRef.current = result;
        setBuilt(result);
      })
      .catch((err) => {
        // Was previously unhandled — a failed load (bad asset resolution,
        // fetch failure, GLTF parse error) left `built` stuck at null
        // forever with zero indication why, since nothing rendered but
        // nothing crashed either.
        //
        // Logging `err` as a second console.error argument only shows the
        // call site of this catch itself in RN's error overlay — the
        // actual throw site lives on the Error object's own `.stack`,
        // which needs to be pulled out and printed as text explicitly to
        // actually see it.
        // eslint-disable-next-line no-console
        console.error(
          `[SquishyToy] failed to build "${species}": ${(err && err.stack) || err}`
        );
      });

    return () => {
      cancelled = true;
      if (builtResult) {
        builtResult.bodyGeo.dispose();
        builtResult.bodyMat.dispose();
        for (const sp of builtResult.sparkles) {
          sp.mat.dispose();
          sp.mesh.geometry.dispose();
        }
        toyRef.current = null;
      }
    };
    // Mirrors the original useMemo(..., []) — builds once per mount from
    // whatever props it started with, not on every prop change.
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  useImperativeHandle(
    ref,
    () => ({
      colorDefs: COLOR_DEFS,
      pointerDown: (ndcX, ndcY, rotateMode) => {
        const s = toyRef.current;
        if (!s) return;
        if (rotateMode) {
          s.mode = 'orbit';
          return;
        }
        const hit = raycastHit(s, camera, raycaster, ndcX, ndcY);
        if (hit && hit.object === s.noseTorus) {
          s.mode = 'nose';
          s.noseTarget = 1;
          onBoop && onBoop();
        } else if (hit) {
          s.mode = 'poke';
          const local = s.bodyMesh.worldToLocal(hit.point.clone());
          s.dragStartWorld = local;
          s.pressLocalSmoothed = local.clone();
          s.pressHoldTime = 0;
          computeDentFall(s, local);
          applyDentScale(s, 1);
          s.globalSquashTarget = 0.32;
          onSquish && onSquish(0.55);
        } else {
          s.mode = null;
        }
      },
      pointerMove: (ndcX, ndcY, dxScreen, dyScreen) => {
        const s = toyRef.current;
        if (!s || !s.mode) return;
        if (s.mode === 'orbit') {
          s.orbitVelY = s.orbitVelY * 0.55 + dxScreen * 0.009 * 0.45;
          s.orbitVelX = s.orbitVelX * 0.55 + dyScreen * 0.009 * 0.45;
          s.orbitTargetY += s.orbitVelY;
          s.orbitTargetX += s.orbitVelX;
        } else if (s.mode === 'poke') {
          const hit = raycastHit(s, camera, raycaster, ndcX, ndcY);
          let local;
          if (hit && hit.object !== s.noseTorus) {
            local = s.bodyMesh.worldToLocal(hit.point.clone());
          } else {
            local = s.dragStartWorld;
          }
          if (!local) return;
          if (!s.pressLocalSmoothed) s.pressLocalSmoothed = local.clone();
          s.pressLocalSmoothed.lerp(local, 0.55);
          computeDentFall(s, s.pressLocalSmoothed);
          s.dragStartWorld = local;
        }
      },
      // `switchingToOrbit` is true when this teardown is only happening
      // because a second finger just joined mid-poke (SquishScreen tears
      // down poke mode before entering orbit) — not an actual release of
      // the toy, so callers use it to skip release-only feedback like the
      // pop sound.
      pointerUp: (switchingToOrbit = false) => {
        const s = toyRef.current;
        if (!s) return;
        if (s.mode === 'poke') {
          const wasSparkle = s.fill.sparkle;
          const spot = s.pressLocalSmoothed ? s.pressLocalSmoothed.clone() : null;
          resetDentTargets(s);
          s.globalSquashTarget = 0;
          const kick = s.fill.wobbleKick;
          s.wobbleRotXV += clamp((Math.random() - 0.5) * kick, -kick, kick);
          s.wobbleRotZV += clamp((Math.random() - 0.5) * kick, -kick, kick);
          onRelease && onRelease(0.55, switchingToOrbit);
          if (wasSparkle && spot) spawnSparkles(s, spot);
          s.pressLocalSmoothed = null;
          s.pressHoldTime = 0;
        } else if (s.mode === 'nose') {
          s.noseTarget = 0;
        }
        s.mode = null;
      },
      selectColor: (i) => {
        const s = toyRef.current;
        if (!s) return;
        s.selected = i;
        const c = COLOR_DEFS[i];
        s.bodyMat.color.set(c.mid);
        s.noseMat.color.set(c.nose);
      },
      selectFill: (i) => {
        const s = toyRef.current;
        if (!s) return;
        s.fill = FILLS[i];
      },
    }),
    [camera, raycaster, onSquish, onRelease, onBoop]
  );

  useFrame((_, delta) => {
    const s = toyRef.current;
    if (!s) return;
    const dt = clamp(delta, 0, 0.05);
    tickPhysics(s, dt);
  });

  if (!built) return null;

  return (
    <>
      <primitive object={built.group} />
      <primitive object={built.shadowMesh} />
      <primitive object={built.sparkleGroup} />
    </>
  );
});

export default SquishyToy;
