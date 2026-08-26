import React, { forwardRef, useEffect, useImperativeHandle, useMemo, useRef, useState } from 'react';
import { useFrame, useThree } from '@react-three/fiber';
import * as THREE from 'three';
import { CREATURE_VISUALS, PHYS } from '../data/creatures';

// Soft-body dent physics engine — ported line-for-line from "ASMR Creature
// Squash Game.html"'s buildCreature/tickPhysics/applyDentAtLocalPoint (the
// design spec this app now matches exactly): a procedural sphere per
// creature, a per-vertex spring toward a Gaussian dent target with grid
// diffusion (the "jelly wave"), a global squash spring, release wobble, and
// drag-to-orbit — a single-finger drag both dents the body *and* slowly
// spins it (there's no separate two-finger orbit gesture in this design).
// Only the physics-irrelevant plumbing (renderer/canvas setup, replaced by
// @react-three/fiber's <Canvas> in SquishScreen; and the Gaussian dent-shape
// caching, an RN-perf-only optimization — see computeDentFall/applyDentScale
// below — mathematically identical to calling the spec's
// applyDentAtLocalPoint fresh every frame with the same point) differ from
// the source.

const clamp = (v, lo, hi) => Math.max(lo, Math.min(hi, v));

function buildCreature(id) {
  const vis = CREATURE_VISUALS[id] ?? CREATURE_VISUALS[0];
  const group = new THREE.Group();
  const widthSeg = 40;
  const heightSeg = 28;
  const geo = new THREE.SphereGeometry(1, widthSeg, heightSeg);
  const posAttr = geo.attributes.position;
  const colCount = widthSeg + 1;
  const rowCount = heightSeg + 1;
  const count = posAttr.count;
  geo.computeVertexNormals();
  const basePos = new Float32Array(posAttr.array);

  const bodyMat = new THREE.MeshStandardMaterial({
    color: new THREE.Color(vis.color),
    roughness: id === 8 ? 0.12 : 0.34,
    metalness: id === 8 ? 0.25 : 0,
    transparent: false,
    opacity: 1,
    side: THREE.FrontSide,
  });
  const bodyMesh = new THREE.Mesh(geo, bodyMat);
  group.add(bodyMesh);

  const featureBases = [];
  const featureMeshes = [];
  const featureScaleBase = [];
  const addFeature = (mesh, pos, scale) => {
    mesh.position.copy(pos);
    group.add(mesh);
    featureBases.push(pos.clone());
    featureMeshes.push(mesh);
    featureScaleBase.push(scale || new THREE.Vector3(1, 1, 1));
  };

  const darkMat = new THREE.MeshStandardMaterial({ color: 0x0f172a, roughness: 0.4 });
  const eyeStyle = vis.eye;
  const eyeGeo = eyeStyle === 'slit' ? new THREE.BoxGeometry(0.16, 0.06, 0.05) : new THREE.SphereGeometry(0.1, 16, 16);
  const eyeL = new THREE.Mesh(eyeGeo, darkMat);
  const eyeR = eyeL.clone();
  addFeature(eyeL, new THREE.Vector3(-0.32, 0.22, 1.04), new THREE.Vector3(1, eyeStyle === 'slit' ? 1 : 1.25, eyeStyle === 'slit' ? 1 : 0.6));
  addFeature(eyeR, new THREE.Vector3(0.32, 0.22, 1.04), new THREE.Vector3(1, eyeStyle === 'slit' ? 1 : 1.25, eyeStyle === 'slit' ? 1 : 0.6));
  if (eyeStyle === 'round') {
    const glintMat = new THREE.MeshBasicMaterial({ color: 0xffffff });
    const glintGeo = new THREE.SphereGeometry(0.028, 8, 8);
    const glintL = new THREE.Mesh(glintGeo, glintMat);
    const glintR = glintL.clone();
    addFeature(glintL, new THREE.Vector3(-0.37, 0.27, 1.1));
    addFeature(glintR, new THREE.Vector3(0.27, 0.27, 1.1));
  }

  const mouthGeo = new THREE.CylinderGeometry(0.045, 0.045, 0.24, 12);
  const mouth = new THREE.Mesh(mouthGeo, darkMat);
  mouth.rotation.z = Math.PI / 2;
  addFeature(mouth, new THREE.Vector3(0, -0.32, 1.02), new THREE.Vector3(1, 1, 1));

  const accentMat = new THREE.MeshStandardMaterial({ color: new THREE.Color(vis.accent), roughness: 0.4 });
  if (vis.accessory === 'antenna') {
    const stalk = new THREE.Mesh(new THREE.CylinderGeometry(0.02, 0.03, 0.32, 8), accentMat);
    addFeature(stalk, new THREE.Vector3(0.12, 1.08, 0.15));
    const tip = new THREE.Mesh(new THREE.SphereGeometry(0.07, 12, 12), accentMat);
    addFeature(tip, new THREE.Vector3(0.12, 1.26, 0.15));
  } else if (vis.accessory === 'ears' || vis.accessory === 'clouds') {
    const r = vis.accessory === 'clouds' ? 0.34 : 0.22;
    const earL = new THREE.Mesh(new THREE.SphereGeometry(r, 16, 16), accentMat);
    const earR = earL.clone();
    addFeature(earL, new THREE.Vector3(-0.62, 0.55, 0.35));
    addFeature(earR, new THREE.Vector3(0.62, 0.55, 0.35));
  } else if (vis.accessory === 'horns') {
    const hornGeo = new THREE.ConeGeometry(0.08, 0.26, 10);
    const hornL = new THREE.Mesh(hornGeo, accentMat);
    const hornR = hornL.clone();
    addFeature(hornL, new THREE.Vector3(-0.36, 0.98, 0.1));
    addFeature(hornR, new THREE.Vector3(0.36, 0.98, 0.1));
  } else if (vis.accessory === 'spots') {
    const spotGeo = new THREE.SphereGeometry(0.09, 10, 10);
    const spotMat = new THREE.MeshStandardMaterial({ color: 0xffffff, roughness: 0.5, transparent: true, opacity: 0.85 });
    [
      [-0.5, 0.4, 0.6],
      [0.45, -0.1, 0.75],
      [-0.15, -0.55, 0.68],
    ].forEach((p) => {
      const spot = new THREE.Mesh(spotGeo, spotMat);
      addFeature(spot, new THREE.Vector3(p[0], p[1], p[2]), new THREE.Vector3(0.7, 0.7, 0.3));
    });
  } else if (vis.accessory === 'leaves') {
    const leafGeo = new THREE.ConeGeometry(0.08, 0.22, 8);
    [
      [-0.18, 1.05, 0.1],
      [0, 1.1, 0.15],
      [0.18, 1.05, 0.1],
    ].forEach((p) => {
      const leaf = new THREE.Mesh(leafGeo, accentMat);
      addFeature(leaf, new THREE.Vector3(p[0], p[1], p[2]));
    });
  } else if (vis.accessory === 'sparkle') {
    const sparkMat = new THREE.MeshBasicMaterial({ color: 0xfff1f8 });
    const sparkGeo = new THREE.OctahedronGeometry(0.06);
    [
      [-0.5, 0.5, 0.55],
      [0.55, 0.3, 0.5],
      [0, -0.5, 0.7],
    ].forEach((p) => {
      const spark = new THREE.Mesh(sparkGeo, sparkMat);
      addFeature(spark, new THREE.Vector3(p[0], p[1], p[2]));
    });
  } else if (vis.accessory === 'tentacles') {
    const tenGeo = new THREE.CylinderGeometry(0.05, 0.03, 0.4, 8);
    [-0.35, -0.12, 0.12, 0.35].forEach((x) => {
      const t = new THREE.Mesh(tenGeo, accentMat);
      addFeature(t, new THREE.Vector3(x, -1.05, 0.15));
    });
  } else if (vis.accessory === 'flame') {
    const flameGeo = new THREE.ConeGeometry(0.14, 0.34, 12);
    const flameMat = new THREE.MeshStandardMaterial({
      color: new THREE.Color(vis.accent),
      emissive: new THREE.Color(vis.accent),
      emissiveIntensity: 0.5,
      roughness: 0.3,
    });
    const flame = new THREE.Mesh(flameGeo, flameMat);
    addFeature(flame, new THREE.Vector3(0, 1.15, 0.05));
  }

  const shMat = new THREE.MeshBasicMaterial({ color: 0x1a0e38, transparent: true, opacity: 0.35, depthWrite: false });
  const shadowMesh = new THREE.Mesh(new THREE.CircleGeometry(1, 32), shMat);
  shadowMesh.scale.set(1.25, 0.5, 1);
  shadowMesh.position.set(0, -1.3, -0.3);
  shadowMesh.rotation.x = -Math.PI / 2.5;

  return {
    group,
    shadowMesh,
    bodyMesh,
    bodyGeo: geo,
    bodyMat,
    basePos,
    vertCount: count,
    colCount,
    rowCount,
    dentAmt: new Float32Array(count),
    dentTarget: new Float32Array(count),
    dentVel: new Float32Array(count),
    dentScratch: new Float32Array(count),
    dentFall: new Float32Array(count),
    normalsFrameToggle: false,
    featureBases,
    featureMeshes,
    featureScaleBase,
    featureDentAmt: new Float32Array(featureBases.length),
    featureDentVel: new Float32Array(featureBases.length),
    featureDentTarget: new Float32Array(featureBases.length),
    featureDentFall: new Float32Array(featureBases.length),
    eyeL,
    eyeR,
    eyeStyle,
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
  };
}

// The Gaussian falloff shape only depends on the touch point's position, not
// how long it's been held, so — same RN-perf adaptation the rest of this
// file's history has used — it's cached here and only recomputed when the
// point actually moves (pointerDown / pointerMove), instead of every
// rendered frame like the source's applyDentAtLocalPoint does. applyDentScale
// (called every frame from tickPhysics) is then just a cheap rescale of that
// cache by the current depthMul — mathematically identical to the source.
function computeDentFall(s, localPoint) {
  const sigma = 0.16;
  const sigmaFactor = -1 / (2 * sigma * sigma);
  for (let i = 0; i < s.vertCount; i++) {
    const dx = s.basePos[i * 3] - localPoint.x;
    const dy = s.basePos[i * 3 + 1] - localPoint.y;
    const dz = s.basePos[i * 3 + 2] - localPoint.z;
    s.dentFall[i] = Math.exp((dx * dx + dy * dy + dz * dz) * sigmaFactor);
  }
  const featureSigma = 0.24;
  const featureSigmaFactor = -1 / (2 * featureSigma * featureSigma);
  for (let j = 0; j < s.featureBases.length; j++) {
    const b = s.featureBases[j];
    const dx = b.x - localPoint.x;
    const dy = b.y - localPoint.y;
    const dz = b.z - localPoint.z;
    s.featureDentFall[j] = Math.exp((dx * dx + dy * dy + dz * dz) * featureSigmaFactor);
  }
}

function applyDentScale(s, depthMul) {
  const maxDent = 0.3 * PHYS.strength * depthMul;
  for (let i = 0; i < s.vertCount; i++) s.dentTarget[i] = maxDent * s.dentFall[i];
  for (let j = 0; j < s.featureBases.length; j++) s.featureDentTarget[j] = maxDent * s.featureDentFall[j] * 1.1;
}

function resetDentTargets(s) {
  s.dentTarget.fill(0);
  s.featureDentTarget.fill(0);
}

function raycastHit(s, camera, raycaster, ndcX, ndcY) {
  raycaster.setFromCamera({ x: ndcX, y: ndcY }, camera);
  const hits = raycaster.intersectObject(s.bodyMesh, false);
  return hits.length ? hits[0] : null;
}

function tickPhysics(s, dt) {
  const k = dt * 60;

  s.idlePhase += 0.016 * k;
  s.blinkTimer -= dt;
  if (s.eyeStyle === 'round' && s.blinkTimer <= 0 && s.blinkAmt <= 0.01) {
    s.blinkAmt = 1;
    s.blinkTimer = 2.5 + Math.random() * 3.5;
  }
  s.blinkAmt = Math.max(0, s.blinkAmt - 0.09 * k);

  if (s.mode === 'poke' && s.pressLocalSmoothed) {
    s.pressHoldTime += dt;
    applyDentScale(s, 1 + s.pressHoldTime * 2.5);
  }

  const dentStiff = 1 - Math.pow(1 - PHYS.stiff, k);
  const dentDamp = Math.pow(PHYS.damp, k);
  for (let i = 0; i < s.vertCount; i++) {
    s.dentVel[i] += (s.dentTarget[i] - s.dentAmt[i]) * dentStiff;
    s.dentVel[i] *= dentDamp;
    s.dentAmt[i] += s.dentVel[i];
  }

  s.dentScratch.set(s.dentAmt);
  const prev = s.dentScratch;
  const rows = s.rowCount;
  const cols = s.colCount;
  const diffCoef = 0.03 * k;
  for (let r = 0; r < rows; r++) {
    for (let c = 0; c < cols; c++) {
      const idx = r * cols + c;
      const cl = c === 0 ? cols - 1 : c - 1;
      const cr = c === cols - 1 ? 0 : c + 1;
      const left = prev[r * cols + cl];
      const right = prev[r * cols + cr];
      const up = r > 0 ? prev[(r - 1) * cols + c] : prev[idx];
      const down = r < rows - 1 ? prev[(r + 1) * cols + c] : prev[idx];
      s.dentAmt[idx] += (left + right - 2 * prev[idx] + (up + down - 2 * prev[idx])) * diffCoef;
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
    const factor = clamp(1 - s.dentAmt[i] + meanDent * 0.2, 0.45, 1.14);
    posAttr.setXYZ(i, bx * factor, by * factor, bz * factor);
  }
  posAttr.needsUpdate = true;
  // Recomputing normals for every vertex is the priciest call in this loop;
  // the dent moves smoothly frame to frame so refreshing shading normals at
  // half rate isn't noticeable but roughly halves that cost (same RN-perf
  // adaptation this file has always made — see git history).
  s.normalsFrameToggle = !s.normalsFrameToggle;
  if (s.normalsFrameToggle) s.bodyGeo.computeVertexNormals();

  for (let j = 0; j < s.featureBases.length; j++) {
    s.featureDentVel[j] += (s.featureDentTarget[j] - s.featureDentAmt[j]) * dentStiff;
    s.featureDentVel[j] *= dentDamp;
    s.featureDentAmt[j] += s.featureDentVel[j];
    const factor = clamp(1 - s.featureDentAmt[j] * 1.5 + meanDent * 0.2, 0.5, 1.2);
    const squish = clamp(1 - s.featureDentAmt[j] * 0.75, 0.62, 1);
    const b = s.featureBases[j];
    const mesh = s.featureMeshes[j];
    const sb = s.featureScaleBase[j];
    mesh.position.set(b.x * factor, b.y * factor, b.z * factor);
    mesh.scale.set(sb.x * squish, sb.y * squish, sb.z * squish);
  }

  const squashStiff = 1 - Math.pow(1 - 0.4, k);
  const squashDamp = Math.pow(0.72, k);
  s.globalSquashV += (s.globalSquashTarget - s.globalSquash) * squashStiff;
  s.globalSquashV *= squashDamp;
  s.globalSquash += s.globalSquashV;

  const wobbleStiff = 1 - Math.pow(1 - 0.08, k);
  const wobbleDamp = Math.pow(0.87, k);
  s.wobbleRotXV += (0 - s.wobbleRotX) * wobbleStiff;
  s.wobbleRotXV *= wobbleDamp;
  s.wobbleRotX += s.wobbleRotXV;
  s.wobbleRotZV += (0 - s.wobbleRotZ) * wobbleStiff;
  s.wobbleRotZV *= wobbleDamp;
  s.wobbleRotZ += s.wobbleRotZV;

  const orbitDecay = Math.pow(0.93, k);
  s.orbitVelY *= orbitDecay;
  s.orbitVelX *= orbitDecay;
  s.orbitTargetY += s.orbitVelY * k;
  s.orbitTargetX += s.orbitVelX * k;
  if (s.mode === null) s.orbitTargetY = Math.sin(s.idlePhase * 0.08) * 0.35;
  const orbitCatchup = Math.min(1, 0.22 * k);
  s.userRotY += (s.orbitTargetY - s.userRotY) * orbitCatchup;
  s.userRotX += (s.orbitTargetX - s.userRotX) * orbitCatchup;

  const breathe = 1 + Math.sin(s.idlePhase * 0.45) * 0.012;
  const sx = (1 + s.globalSquash * 0.14) * breathe;
  const sy = (1 - s.globalSquash * 0.26) * breathe;
  const sz = (1 + s.globalSquash * 0.14) * breathe;
  s.group.rotation.y = s.userRotY + Math.sin(s.idlePhase * 0.2) * 0.03;
  s.group.rotation.x = s.userRotX + s.wobbleRotX;
  s.group.rotation.z = s.wobbleRotZ;
  s.group.scale.set(sx, sy, sz);

  if (s.eyeStyle === 'round') {
    const blinkScale = 1 - s.blinkAmt * 0.88;
    s.eyeL.scale.y = s.featureScaleBase[0].y * blinkScale;
    s.eyeR.scale.y = s.featureScaleBase[1].y * blinkScale;
  }
}

const SquishyToy = forwardRef(function SquishyToy({ creatureId = '0', onSquish, onRelease }, ref) {
  const { camera } = useThree();
  const toyRef = useRef(null);
  const raycaster = useMemo(() => new THREE.Raycaster(), []);
  const [built, setBuilt] = useState(null);

  useEffect(() => {
    const result = buildCreature(Number(creatureId));
    toyRef.current = result;
    setBuilt(result);
    return () => {
      result.bodyGeo.dispose();
      result.bodyMat.dispose();
      toyRef.current = null;
    };
    // Builds once per mount from whichever creature it started with.
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  useImperativeHandle(
    ref,
    () => ({
      pointerDown: (ndcX, ndcY) => {
        const s = toyRef.current;
        if (!s) return;
        const hit = raycastHit(s, camera, raycaster, ndcX, ndcY);
        if (hit) {
          s.mode = 'poke';
          const local = s.bodyMesh.worldToLocal(hit.point.clone());
          s.dragStartWorld = local;
          s.pressLocalSmoothed = local.clone();
          s.pressHoldTime = 0;
          computeDentFall(s, local);
          applyDentScale(s, 1);
          s.globalSquashTarget = 0.55;
          onSquish && onSquish();
        } else {
          s.mode = null;
        }
      },
      pointerMove: (ndcX, ndcY, dxScreen) => {
        const s = toyRef.current;
        if (!s || s.mode !== 'poke') return;
        s.orbitTargetY += dxScreen * 0.008;
        s.orbitVelY = s.orbitVelY * 0.5 + dxScreen * 0.0015;
        const hit = raycastHit(s, camera, raycaster, ndcX, ndcY);
        const local = hit ? s.bodyMesh.worldToLocal(hit.point.clone()) : s.dragStartWorld;
        if (!local) return;
        if (!s.pressLocalSmoothed) s.pressLocalSmoothed = local.clone();
        s.pressLocalSmoothed.lerp(local, 0.7);
        s.dragStartWorld = local;
        computeDentFall(s, s.pressLocalSmoothed);
      },
      pointerUp: () => {
        const s = toyRef.current;
        if (!s) return { wasPoke: false, holdSeconds: 0 };
        if (s.mode !== 'poke') {
          s.mode = null;
          return { wasPoke: false, holdSeconds: 0 };
        }
        const holdSeconds = s.pressHoldTime;
        resetDentTargets(s);
        s.globalSquashTarget = 0;
        const kick = PHYS.wobbleKick;
        s.wobbleRotXV += clamp((Math.random() - 0.5) * kick, -kick, kick);
        s.wobbleRotZV += clamp((Math.random() - 0.5) * kick, -kick, kick);
        s.pressLocalSmoothed = null;
        s.pressHoldTime = 0;
        s.mode = null;
        onRelease && onRelease(holdSeconds);
        return { wasPoke: true, holdSeconds };
      },
    }),
    [camera, raycaster, onSquish, onRelease]
  );

  useFrame((_, delta) => {
    const s = toyRef.current;
    if (!s) return;
    tickPhysics(s, clamp(delta, 0, 0.05));
  });

  if (!built) return null;

  return (
    <>
      <primitive object={built.group} />
      <primitive object={built.shadowMesh} />
    </>
  );
});

export default SquishyToy;
