import React, { forwardRef, useEffect, useImperativeHandle, useMemo, useRef, useState } from 'react';
import { useFrame, useThree } from '@react-three/fiber';
import * as THREE from 'three';
import { Asset } from 'expo-asset';
import { GLTFLoader } from 'three/examples/jsm/loaders/GLTFLoader.js';
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

// ---- Glorp: imported Tripo3D mesh instead of the procedural sphere ----
//
// Glorp (creature id 0) is the one creature this app renders from a real
// AI-generated asset (assets/models/glorp_3d.glb, from Tripo3D) rather than
// buildCreature's hand-built sphere. The rest of the roster is unchanged.
//
// The procedural toys share one UV-sphere with a known rows x cols vertex
// layout, which is what lets tickPhysics's jelly-wave diffusion look up each
// vertex's 4 grid neighbours by index math. An imported mesh has no such
// structure, so it carries its own adjacency list (built once from the
// triangle index buffer) and tickPhysics diffuses across that instead — see
// the `s.neighbors` branch there. Everything else (per-vertex spring toward a
// Gaussian dent target, global squash/wobble, release kick, drag-to-orbit)
// only reasons about vertex positions, so it runs unmodified on any mesh.

const GLORP_MODEL_ID = 0;
const GLORP_ASSET = require('../../assets/models/glorp_3d.glb');
// Glorp's geometry is normalised to the SAME 2-unit diameter as the
// procedural sphere toys, so every physics constant (dent sigma, maxDent,
// the squash clamps) behaves identically. On-screen size is then just a
// uniform scale on the mesh — bump this to make Glorp bigger/smaller on the
// squish stage without touching the physics. 2 == same size as the spheres.
const GLORP_VISUAL = 2.5;

// Cached at module scope — revisiting Glorp in the same session re-parses a
// fresh geometry (so concurrent mounts never share one live position buffer)
// but doesn't re-fetch/re-decode the same ~100KB glb off disk each time.
let glorpGltfPromise = null;
function loadGlorpGltf() {
  if (!glorpGltfPromise) {
    glorpGltfPromise = (async () => {
      const asset = Asset.fromModule(GLORP_ASSET);
      await asset.downloadAsync();
      const response = await fetch(asset.localUri || asset.uri);
      const arrayBuffer = await response.arrayBuffer();
      return new Promise((resolve, reject) => {
        new GLTFLoader().parse(arrayBuffer, '', resolve, reject);
      });
    })();
  }
  return glorpGltfPromise;
}

// Every vertex sharing a triangle with vertex i becomes a neighbour of i —
// the same relationship the sphere grid's left/right/up/down lookup captures,
// derived from real topology instead of assumed row/col math.
function buildAdjacency(indexArray, vertCount) {
  const sets = new Array(vertCount);
  for (let i = 0; i < vertCount; i++) sets[i] = new Set();
  for (let t = 0; t < indexArray.length; t += 3) {
    const a = indexArray[t];
    const b = indexArray[t + 1];
    const c = indexArray[t + 2];
    sets[a].add(b); sets[a].add(c);
    sets[b].add(a); sets[b].add(c);
    sets[c].add(a); sets[c].add(b);
  }
  return sets.map((set) => Uint32Array.from(set));
}

async function buildGlorpCreature() {
  const gltf = await loadGlorpGltf();
  let sourceMesh = null;
  gltf.scene.traverse((obj) => {
    if (!sourceMesh && obj.isMesh) sourceMesh = obj;
  });
  if (!sourceMesh) throw new Error('glorp_3d.glb: no mesh found in scene');

  const geo = sourceMesh.geometry.clone();
  geo.computeBoundingBox();

  // The raw export's pivot sits at its base. Recenter on the bbox centre and
  // normalise so the largest dimension is 2 units — the exact size of the
  // procedural sphere (radius 1). Keeping the physics geometry at that size
  // means the dent sigma / maxDent / squash clamps tuned for the sphere work
  // unchanged; the actual on-screen size is a separate uniform scale on the
  // mesh (GLORP_VISUAL), applied below.
  const rawCenter = new THREE.Vector3();
  geo.boundingBox.getCenter(rawCenter);
  const rawSize = new THREE.Vector3();
  geo.boundingBox.getSize(rawSize);
  const normScale = 2 / (Math.max(rawSize.x, rawSize.y, rawSize.z) || 1);
  const rawPos = geo.attributes.position.array;
  for (let i = 0; i < rawPos.length; i += 3) {
    rawPos[i] = (rawPos[i] - rawCenter.x) * normScale;
    rawPos[i + 1] = (rawPos[i + 1] - rawCenter.y) * normScale;
    rawPos[i + 2] = (rawPos[i + 2] - rawCenter.z) * normScale;
  }
  geo.attributes.position.needsUpdate = true;
  geo.computeVertexNormals();

  const posAttr = geo.attributes.position;
  const count = posAttr.count;
  const basePos = new Float32Array(posAttr.array);
  const indexAttr = geo.getIndex();
  const indexArray = indexAttr ? indexAttr.array : Uint32Array.from({ length: count }, (_, i) => i);
  const neighbors = buildAdjacency(indexArray, count);

  const bodyMat = new THREE.MeshStandardMaterial({
    map: sourceMesh.material && sourceMesh.material.map ? sourceMesh.material.map : null,
    color: sourceMesh.material && sourceMesh.material.map ? 0xffffff : new THREE.Color(CREATURE_VISUALS[0].color),
    roughness: 0.5,
    metalness: 0,
    side: THREE.DoubleSide,
  });
  const bodyMesh = new THREE.Mesh(geo, bodyMat);
  // Physics runs on the 2-unit geometry; this is the only thing that sets
  // Glorp's real on-screen size. Raycasting goes through bodyMesh's world
  // matrix so hit-testing stays correct at any scale.
  bodyMesh.scale.setScalar(GLORP_VISUAL / 2);
  const group = new THREE.Group();
  group.add(bodyMesh);

  const shMat = new THREE.MeshBasicMaterial({ color: 0x1a0e38, transparent: true, opacity: 0.35, depthWrite: false });
  const shadowMesh = new THREE.Mesh(new THREE.CircleGeometry(1, 32), shMat);
  shadowMesh.scale.set(GLORP_VISUAL * 0.62, GLORP_VISUAL * 0.26, 1);
  shadowMesh.position.set(0, -GLORP_VISUAL * 0.52, -0.3);
  shadowMesh.rotation.x = -Math.PI / 2.5;

  return {
    group,
    shadowMesh,
    bodyMesh,
    bodyGeo: geo,
    bodyMat,
    basePos,
    vertCount: count,
    // Grid dims unused — the presence of `neighbors` routes tickPhysics down
    // the topology-agnostic diffusion path instead.
    colCount: 0,
    rowCount: 0,
    neighbors,
    dentAmt: new Float32Array(count),
    dentTarget: new Float32Array(count),
    dentVel: new Float32Array(count),
    dentScratch: new Float32Array(count),
    dentFall: new Float32Array(count),
    normalsFrameToggle: false,
    // No separate face meshes — Glorp's face is in its texture.
    featureBases: [],
    featureMeshes: [],
    featureScaleBase: [],
    featureDentAmt: new Float32Array(0),
    featureDentVel: new Float32Array(0),
    featureDentTarget: new Float32Array(0),
    featureDentFall: new Float32Array(0),
    eyeL: null,
    eyeR: null,
    eyeStyle: 'none',
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
    blinkTimer: 999,
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
  const diffCoef = 0.03 * k;
  if (s.neighbors) {
    // Imported mesh (Glorp) — no assumed row/col grid, so diffuse across each
    // vertex's real triangle-adjacency. Averaged over the neighbour count so
    // the rate doesn't swing with local mesh density, then x4 to land in the
    // same range the 4-neighbour grid branch below produces (so `diffCoef`
    // means roughly the same thing either way).
    for (let i = 0; i < s.vertCount; i++) {
      const nbrs = s.neighbors[i];
      const n = nbrs.length;
      if (!n) continue;
      let acc = 0;
      for (let ni = 0; ni < n; ni++) acc += prev[nbrs[ni]] - prev[i];
      s.dentAmt[i] += (acc / n) * 4 * diffCoef;
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
        s.dentAmt[idx] += (left + right - 2 * prev[idx] + (up + down - 2 * prev[idx])) * diffCoef;
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

  // Rotation is a deliberate two-finger gesture only (see SquishScreen's
  // PanResponder + the `orbit` handle below). No idle auto-spin — the toy
  // holds still until the player actually turns it. While a two-finger drag
  // is live (`mode === 'orbit'`) the momentum isn't decayed; after release it
  // coasts to a stop.
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
  const sx = (1 + s.globalSquash * 0.14) * breathe;
  const sy = (1 - s.globalSquash * 0.26) * breathe;
  const sz = (1 + s.globalSquash * 0.14) * breathe;
  s.group.rotation.y = s.userRotY;
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
    let cancelled = false;
    let result = null;
    const dispose = () => {
      if (!result) return;
      result.bodyGeo.dispose();
      result.bodyMat.dispose();
      if (result.shadowMesh) {
        result.shadowMesh.geometry.dispose();
        result.shadowMesh.material.dispose();
      }
      toyRef.current = null;
    };

    // Procedural creatures build synchronously (unchanged). Glorp loads its
    // Tripo mesh from disk first, so `built` stays null for the brief window
    // before it resolves — every imperative-handle method and useFrame
    // already bails while toyRef.current is null, so that window is safe.
    const isGlorp = Number(creatureId) === GLORP_MODEL_ID;
    const pending = isGlorp
      ? buildGlorpCreature()
      : Promise.resolve(buildCreature(Number(creatureId)));

    pending
      .then((r) => {
        if (cancelled) {
          result = r;
          dispose();
          return;
        }
        result = r;
        toyRef.current = r;
        setBuilt(r);
      })
      .catch((err) => {
        // eslint-disable-next-line no-console
        console.error(`[SquishyToy] failed to build creature ${creatureId}: ${(err && err.stack) || err}`);
        // Glorp's GLB failed to load/parse (e.g. a device fetch quirk) —
        // fall back to the procedural sphere so the stage is never blank and
        // stays fully interactive.
        if (cancelled) return;
        try {
          const fallback = buildCreature(GLORP_MODEL_ID);
          result = fallback;
          toyRef.current = fallback;
          setBuilt(fallback);
        } catch (e2) {
          // eslint-disable-next-line no-console
          console.error(`[SquishyToy] procedural fallback also failed: ${(e2 && e2.stack) || e2}`);
        }
      });

    return () => {
      cancelled = true;
      dispose();
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
        let local;
        if (hit) {
          local = s.bodyMesh.worldToLocal(hit.point.clone());
        } else {
          // Near-miss tap (edge of the body, thin geometry) — still squish.
          // Unproject the touch into the scene and pull it onto the body so
          // the dent lands on the side the finger is nearest to.
          local = s.bodyMesh.worldToLocal(new THREE.Vector3(ndcX, ndcY, 0.5).unproject(camera));
          if (local.length() > 0.85) local.setLength(0.85);
        }
        s.mode = 'poke';
        s.dragStartWorld = local;
        s.pressLocalSmoothed = local.clone();
        s.pressHoldTime = 0;
        computeDentFall(s, local);
        applyDentScale(s, 1);
        s.globalSquashTarget = 0.55;
        onSquish && onSquish();
      },
      pointerMove: (ndcX, ndcY) => {
        const s = toyRef.current;
        if (!s || s.mode !== 'poke') return;
        // A one-finger drag only moves the dent around — it no longer spins
        // the toy (rotation is the two-finger `orbit` gesture).
        const hit = raycastHit(s, camera, raycaster, ndcX, ndcY);
        const local = hit ? s.bodyMesh.worldToLocal(hit.point.clone()) : s.dragStartWorld;
        if (!local) return;
        if (!s.pressLocalSmoothed) s.pressLocalSmoothed = local.clone();
        s.pressLocalSmoothed.lerp(local, 0.7);
        s.dragStartWorld = local;
        computeDentFall(s, s.pressLocalSmoothed);
      },
      // Two-finger drag: turn the toy. dxScreen/dyScreen are the movement of
      // the two fingers' midpoint since the last move event, in screen px.
      orbit: (dxScreen, dyScreen) => {
        const s = toyRef.current;
        if (!s) return;
        s.mode = 'orbit';
        s.orbitTargetY += dxScreen * 0.01;
        s.orbitTargetX += dyScreen * 0.006;
        s.orbitVelY = s.orbitVelY * 0.5 + dxScreen * 0.002;
        s.orbitVelX = s.orbitVelX * 0.5 + dyScreen * 0.0012;
      },
      endOrbit: () => {
        const s = toyRef.current;
        if (s && s.mode === 'orbit') s.mode = null;
      },
      // A second finger landed mid-poke — drop the dent without firing the
      // release reward/wobble, so the gesture can become an orbit instead.
      cancelPoke: () => {
        const s = toyRef.current;
        if (!s) return;
        resetDentTargets(s);
        s.globalSquashTarget = 0;
        s.pressLocalSmoothed = null;
        s.pressHoldTime = 0;
        if (s.mode === 'poke') s.mode = null;
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
