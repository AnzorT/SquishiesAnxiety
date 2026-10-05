// @refresh reset
// The creature is built once in a useEffect on mount (buildCreature /
// buildModelCreature). Fast Refresh keeps the old built object when you edit
// this file, so tuning changes to the builders or the physics wouldn't show
// without a full reload — this directive makes Fast Refresh remount the
// component (and rebuild the toy) whenever this file changes.
import React, { forwardRef, memo, useEffect, useImperativeHandle, useMemo, useRef, useState } from 'react';
import { useFrame, useThree } from '@react-three/fiber';
import * as THREE from 'three';
import * as FileSystem from 'expo-file-system';
import { GLTFLoader } from 'three/examples/jsm/loaders/GLTFLoader.js';
import { PHYS } from '../data/creatures';
import perf from '../perfProbe';

// Used by buildCreature's procedural-sphere path (and prepareModelData's
// no-texture-map fallback tint) whenever the caller doesn't have a real
// visual spec handy — e.g. a GLB that fails to load before its Firestore
// creature doc's `visual` field made it into scope. Matches Glorp's teal.
const DEFAULT_VISUAL = { color: '#2dd4bf', accent: '#0d9488', accessory: 'antenna', eye: 'round' };

// No environment (reflection) map on purpose. A RoomEnvironment/PMREM map
// used to provide most of the ambient fill here, but on the target phone it
// renders black (it generated without error, yet the creatures came out dark
// and matched a no-environment render exactly), so desktop previews and the
// phone disagreed. The stage is lit by plain lights in SquishScreen instead,
// which every device draws the same way.

// Soft-body dent physics, originally ported from "ASMR Creature Squash
// Game.html"'s buildCreature/tickPhysics/applyDentAtLocalPoint: a spring
// toward a dent target (the "jelly" lag), a global squash spring, release
// wobble, and orbit. The squish now runs on the GPU and moves the whole body
// like a pillow (a wide dent, a swelling rim, the surface pulled into the
// dent, and a whole-body squeeze): the vertex shader evaluates it per vertex
// from a short list of press points, each driven by one scalar spring on the
// JS thread (see "the squish itself" below).

const clamp = (v, lo, hi) => Math.max(lo, Math.min(hi, v));

// Upper clamp on tickPhysics's per-vertex radial factor — also bounds how far
// the deformed surface can reach, which raycastLocal's early-out relies on.
const MAX_BULGE = 1.14;

// Radius of a sphere about the origin that contains the body at any
// deformation (every vertex is base * factor, factor <= MAX_BULGE).
function computeBoundRadius(basePos) {
  let r2 = 0;
  for (let i = 0; i < basePos.length; i += 3) {
    const d2 = basePos[i] * basePos[i] + basePos[i + 1] * basePos[i + 1] + basePos[i + 2] * basePos[i + 2];
    if (d2 > r2) r2 = d2;
  }
  return Math.sqrt(r2) * MAX_BULGE * 1.01;
}

function buildCreature(id, visual) {
  const vis = visual ?? DEFAULT_VISUAL;
  const group = new THREE.Group();
  const widthSeg = 40;
  const heightSeg = 28;
  const geo = new THREE.SphereGeometry(1, widthSeg, heightSeg);
  const posAttr = geo.attributes.position;
  const count = posAttr.count;
  geo.computeVertexNormals();
  const basePos = new Float32Array(posAttr.array);

  const bodyMat = new THREE.MeshStandardMaterial({
    color: new THREE.Color(vis.color),
    roughness: id === 8 ? 0.12 : 0.34,
    metalness: id === 8 ? 0.25 : 0,
    envMapIntensity: 1.4,
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

  const s = {
    group,
    shadowMesh,
    bodyMesh,
    bodyGeo: geo,
    bodyMat,
    basePos,
    indexArray: geo.index.array,
    grid: null,
    boundRadius: computeBoundRadius(basePos),
    vertCount: count,
    sampleStride: 1,
    // Dent shape for the unit-radius procedural sphere — see MODEL_TUNING.
    dentDepth: 1.0,
    dentRadius: 0.76,
    dentRim: 0.4,
    dentRimWidth: 1.6,
    dentPull: 0.62,
    dentPullWidth: 0.7,
    dentSqueeze: 0.14,
    bottomY: -1,
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
    blinkTimer: 2 + Math.random() * 3,
    ...makeSquishState(),
  };
  installSquishShader(bodyMat, s);
  return s;
}

// ---- Imported Tripo3D meshes instead of the procedural sphere ----
//
// Every premade creature (plus a photo-path custom one) renders from a real
// AI-generated asset (a .glb) rather than buildCreature's hand-built sphere.
// The .glb itself now always lives in Firebase Storage — a creature's
// Firestore doc carries its `modelUrl` — rather than being bundled into the
// app; loadGltfFromUrl below caches each one to disk on first use so it's
// still fully playable offline afterward, same as before the migration.
//
// The procedural toys share one UV-sphere with a known rows x cols vertex
// layout, which is what lets tickPhysics's jelly-wave diffusion look up each
// vertex's 4 grid neighbours by index math. An imported mesh has no such
// structure, so it carries its own adjacency list (built once from the
// triangle index buffer) and tickPhysics diffuses across that instead — see
// the `s.neighbors` branch there. Everything else (per-vertex spring toward a
// dent target, global squash/wobble, release kick, drag-to-orbit)
// only reasons about vertex positions, so it runs unmodified on any mesh.

// Every model creature — premade or custom — uses this same tuning: `visual`
// bakes the on-stage size into the geometry (the mesh is recentred +
// rescaled so its largest dimension == this many units; 2 == same size as
// the procedural spheres). The camera (SquishScreen) sees 2.47 units top to
// bottom, so 2.25 fills 91% of the stage; only the very top of a tall
// creature can touch the edge at the peak of a deep pop-out press.
//
// The press squishes it like a head sinking into a pillow, not a finger
// poking a balloon: the whole body gives (see "the squish itself" below and
// computeDentFall / applyDentScale / tickPhysics).
// - `dentDepth`: how deep the middle of the dent goes when held (model units).
// - `dentRadius`: the dent's width (a smooth bell, its sigma). Wide on
//   purpose: the dent covers most of the side that was pressed.
// - `dentRim` / `dentRimWidth`: the ring around the dent rises by this
//   fraction of the depth, over this many times the dent's width, as the
//   pushed-in stuffing goes into the sides.
// - `dentPull` / `dentPullWidth`: the surface around the dent is pulled in
//   toward the press, so the fabric folds into the dent (at most this
//   fraction of the way), over this many times the dent's width. Narrower
//   than the dent so the creature's outline isn't pulled in with it.
// - `dentSqueeze`: the whole body is squeezed along the press direction by up
//   to this fraction, and spreads out sideways by a quarter of that (less
//   than a real volume would: the stage has little room to the sides).
// These are the strongest squish (Squish level 5 in the squish screen's
// settings): the player's level scales the depth, the pull, the squeeze and
// the floor flatten together (`dentUserScale`).
// `fallbackColor` only matters for the rare mesh with no baked texture map
// (see prepareModelData).
// Until 2026-10-05 the dent was a pointed funnel (dentDepth 0.6, a cusp of
// radius 0.33), which read as a spear going into a balloon.
const MODEL_TUNING = {
  visual: 2.25,
  dentDepth: 1.15,
  dentRadius: 0.85,
  dentRim: 0.4,
  dentRimWidth: 1.6,
  dentPull: 0.62,
  dentPullWidth: 0.7,
  dentSqueeze: 0.14,
  fallbackColor: '#2dd4bf',
};

// Creatures that get a soft glossy sheen over their texture, like Tripo's
// viewer shows them. Tripo exports carry no shine data (just a colour
// texture marked matte), so the gloss comes from here. Keyed by Firestore
// creature id: '12' = Bubbles.
const SHINY_CREATURE_IDS = new Set(['12']);

function hashKey(str) {
  let h = 5381;
  for (let i = 0; i < str.length; i++) h = ((h << 5) + h) ^ str.charCodeAt(i);
  return (h >>> 0).toString(36);
}

const remoteGltfPromises = new Map();
function loadGltfFromUrl(url) {
  if (!remoteGltfPromises.has(url)) {
    remoteGltfPromises.set(
      url,
      (async () => {
        const dir = `${FileSystem.cacheDirectory}creatureModels/`;
        const path = `${dir}${hashKey(url)}.glb`;
        try {
          const info = await FileSystem.getInfoAsync(path);
          if (!info.exists) {
            await FileSystem.makeDirectoryAsync(dir, { intermediates: true }).catch(() => {});
            await FileSystem.downloadAsync(url, path);
          }
        } catch (e) {
          // fall through to a direct fetch of the URL below
        }
        const response = await fetch(path).catch(() => fetch(url));
        const arrayBuffer = await response.arrayBuffer();
        return new Promise((resolve, reject) => {
          new GLTFLoader().parse(arrayBuffer, '', resolve, reject);
        });
      })()
    );
  }
  return remoteGltfPromises.get(url);
}

// Cached per url at module scope, one level up from the raw gltf cache
// above — this is what actually makes preloadCreatureModel's promise mean
// "ready to render instantly": it carries the fetch/parse *and*
// prepareModelData's recentre/normals/weld/adjacency work (the CPU-bound part
// that used to run fresh on every SquishScreen mount, after the loading
// screen had already faded out). buildModelCreature then just does cheap
// per-instance geometry/mesh construction from this cached data, so a
// revisit — or the normal preload-then-mount path — never re-pays it.
const remoteModelDataPromises = new Map();
function loadModelDataFromUrl(creatureId, url) {
  if (!remoteModelDataPromises.has(url)) {
    remoteModelDataPromises.set(url, loadGltfFromUrl(url).then((gltf) => prepareModelData(creatureId, MODEL_TUNING, gltf)));
  }
  return remoteModelDataPromises.get(url);
}

// LoadingScreen calls this as soon as a creature is picked, so the .glb
// fetch/parse and the geometry prep both run during the loading animation
// instead of after SquishScreen mounts — otherwise SquishyToy's own
// useEffect is the first thing to ever call loadModelDataFromUrl, and the
// model pops in on the game screen instead of the loading screen. The loader
// caches by url at module scope, so this and SquishyToy's later call share
// the same in-flight/resolved promise — a creature with no modelUrl
// (2D/procedural) resolves immediately.
export function preloadCreatureModel(creature) {
  if (!creature || !creature.modelUrl) return Promise.resolve();
  return loadModelDataFromUrl(creature.id, creature.modelUrl);
}

// Low-poly exports (Tripo retopo included) commonly split a vertex into two
// indices with identical positions wherever a UV or normal seam crosses it,
// so the mesh can still texture correctly. computeVertexNormals() only
// blends face normals across shared indices, so those seam duplicates never
// see each other's face and the seam reads as a hard facet crease. For a
// file without authored normals, group same-position indices so the
// computed rest normals can be re-averaged across the seam.
function buildWeldGroups(basePos, vertCount) {
  const byKey = new Map();
  for (let i = 0; i < vertCount; i++) {
    const key = `${basePos[i * 3].toFixed(4)},${basePos[i * 3 + 1].toFixed(4)},${basePos[i * 3 + 2].toFixed(4)}`;
    let arr = byKey.get(key);
    if (!arr) { arr = []; byKey.set(key, arr); }
    arr.push(i);
  }
  const groups = [];
  for (const arr of byKey.values()) {
    if (arr.length > 1) groups.push(Uint32Array.from(arr));
  }
  return groups;
}

function weldNormals(normalAttr, weldGroups) {
  for (const group of weldGroups) {
    let nx = 0, ny = 0, nz = 0;
    for (let k = 0; k < group.length; k++) {
      nx += normalAttr.getX(group[k]);
      ny += normalAttr.getY(group[k]);
      nz += normalAttr.getZ(group[k]);
    }
    const len = Math.hypot(nx, ny, nz) || 1;
    nx /= len; ny /= len; nz /= len;
    for (let k = 0; k < group.length; k++) normalAttr.setXYZ(group[k], nx, ny, nz);
  }
  normalAttr.needsUpdate = true;
}

// Uniform grid over the rest mesh's triangles, for raycastGrid: each cell
// lists the triangles whose bounding box overlaps it, so a touch only tests
// the few hundred triangles along the finger's ray instead of all ten
// thousand (which cost several ms per touch event on Hermes).
function buildTriangleGrid(basePos, indexArray) {
  const triCount = indexArray.length / 3;
  let minX = Infinity;
  let minY = Infinity;
  let minZ = Infinity;
  let maxX = -Infinity;
  let maxY = -Infinity;
  let maxZ = -Infinity;
  for (let i = 0; i < basePos.length; i += 3) {
    const x = basePos[i];
    const y = basePos[i + 1];
    const z = basePos[i + 2];
    if (x < minX) minX = x;
    if (x > maxX) maxX = x;
    if (y < minY) minY = y;
    if (y > maxY) maxY = y;
    if (z < minZ) minZ = z;
    if (z > maxZ) maxZ = z;
  }
  const pad = 1e-3;
  minX -= pad; minY -= pad; minZ -= pad;
  maxX += pad; maxY += pad; maxZ += pad;
  const n = Math.max(6, Math.min(28, Math.round(Math.cbrt(triCount) * 0.8)));
  const csX = (maxX - minX) / n;
  const csY = (maxY - minY) / n;
  const csZ = (maxZ - minZ) / n;
  const cellCount = n * n * n;
  const cellOffsets = new Uint32Array(cellCount + 1);
  const bounds = new Int32Array(triCount * 6);
  const cellOf = (v, lo, cs) => Math.max(0, Math.min(n - 1, Math.floor((v - lo) / cs)));
  for (let t = 0; t < triCount; t++) {
    const a = indexArray[t * 3] * 3;
    const b = indexArray[t * 3 + 1] * 3;
    const c = indexArray[t * 3 + 2] * 3;
    const x0 = cellOf(Math.min(basePos[a], basePos[b], basePos[c]), minX, csX);
    const x1 = cellOf(Math.max(basePos[a], basePos[b], basePos[c]), minX, csX);
    const y0 = cellOf(Math.min(basePos[a + 1], basePos[b + 1], basePos[c + 1]), minY, csY);
    const y1 = cellOf(Math.max(basePos[a + 1], basePos[b + 1], basePos[c + 1]), minY, csY);
    const z0 = cellOf(Math.min(basePos[a + 2], basePos[b + 2], basePos[c + 2]), minZ, csZ);
    const z1 = cellOf(Math.max(basePos[a + 2], basePos[b + 2], basePos[c + 2]), minZ, csZ);
    bounds[t * 6] = x0; bounds[t * 6 + 1] = x1;
    bounds[t * 6 + 2] = y0; bounds[t * 6 + 3] = y1;
    bounds[t * 6 + 4] = z0; bounds[t * 6 + 5] = z1;
    for (let ix = x0; ix <= x1; ix++) {
      for (let iy = y0; iy <= y1; iy++) {
        for (let iz = z0; iz <= z1; iz++) cellOffsets[(ix * n + iy) * n + iz + 1]++;
      }
    }
  }
  for (let c = 0; c < cellCount; c++) cellOffsets[c + 1] += cellOffsets[c];
  const cursor = new Uint32Array(cellCount);
  const cellTris = new Uint32Array(cellOffsets[cellCount]);
  for (let t = 0; t < triCount; t++) {
    for (let ix = bounds[t * 6]; ix <= bounds[t * 6 + 1]; ix++) {
      for (let iy = bounds[t * 6 + 2]; iy <= bounds[t * 6 + 3]; iy++) {
        for (let iz = bounds[t * 6 + 4]; iz <= bounds[t * 6 + 5]; iz++) {
          const cell = (ix * n + iy) * n + iz;
          cellTris[cellOffsets[cell] + cursor[cell]] = t;
          cursor[cell]++;
        }
      }
    }
  }
  return { n, minX, minY, minZ, maxX, maxY, maxZ, csX, csY, csZ, cellOffsets, cellTris };
}

// Plain packed copy of an interleaved attribute (same values, type and
// normalization).
function deinterleave(attr) {
  const { itemSize, count, offset } = attr;
  const stride = attr.data.stride;
  const src = attr.data.array;
  const out = new src.constructor(count * itemSize);
  for (let i = 0; i < count; i++) {
    for (let k = 0; k < itemSize; k++) out[i * itemSize + k] = src[i * stride + offset + k];
  }
  return new THREE.BufferAttribute(out, itemSize, attr.normalized);
}

// The expensive, purely-deterministic half of turning a parsed .glb into a
// squishable mesh: recentre/rescale, rest normals, the pick grid. It depends
// only on the source asset + tuning config, never on a specific toy
// instance — so it's cacheable per id/url (see loadModelData /
// loadModelDataFromUrl below) and runs once, during LoadingScreen's preload,
// instead of blocking SquishScreen's first mount. buildModelCreature (below)
// does the remaining *cheap* per-instance work (geometry + mesh) so a
// revisit — or the normal preload-then-mount path — never re-pays this cost.
function prepareModelData(id, cfg, gltf) {
  let sourceMesh = null;
  gltf.scene.traverse((obj) => {
    if (!sourceMesh && obj.isMesh) sourceMesh = obj;
  });
  if (!sourceMesh) throw new Error(`3D model ${id}: no mesh found in scene`);

  const geo = sourceMesh.geometry.clone();
  // Some exporters (glTF-Transform, for one) interleave vertex attributes in
  // one shared buffer. On those, `attribute.array` is that whole shared
  // buffer rather than this attribute's own values, and everything below
  // reads/writes `.array` directly — which scrambled every vertex into
  // shards. Tripo exports are already packed, so this is a no-op for them.
  for (const name of Object.keys(geo.attributes)) {
    const attr = geo.attributes[name];
    if (attr.isInterleavedBufferAttribute) geo.setAttribute(name, deinterleave(attr));
  }
  // Tripo exports carry authored smooth normals, which is what Tripo's own
  // viewer shades with, so those are what gets displayed (the squish tilts
  // them analytically in the vertex shader — see SQUISH_VERTEX_GLSL).
  // Normals recomputed from the triangles would bring out every facet, so
  // they're only the fallback for a file without any.
  let fileNormals = null;
  if (geo.attributes.normal) {
    fileNormals = new Float32Array(geo.attributes.normal.array);
    for (let i = 0; i < fileNormals.length; i += 3) {
      const inv = 1 / (Math.hypot(fileNormals[i], fileNormals[i + 1], fileNormals[i + 2]) || 1);
      fileNormals[i] *= inv;
      fileNormals[i + 1] *= inv;
      fileNormals[i + 2] *= inv;
    }
  }
  geo.computeBoundingBox();

  // The raw export's pivot sits at its base. Recenter on the bbox centre and
  // bake the on-screen size straight into the geometry (largest dimension ->
  // cfg.visual units).
  const rawCenter = new THREE.Vector3();
  geo.boundingBox.getCenter(rawCenter);
  const rawSize = new THREE.Vector3();
  geo.boundingBox.getSize(rawSize);
  const normScale = cfg.visual / (Math.max(rawSize.x, rawSize.y, rawSize.z) || 1);
  const rawPos = geo.attributes.position.array;
  for (let i = 0; i < rawPos.length; i += 3) {
    rawPos[i] = (rawPos[i] - rawCenter.x) * normScale;
    rawPos[i + 1] = (rawPos[i + 1] - rawCenter.y) * normScale;
    rawPos[i + 2] = (rawPos[i + 2] - rawCenter.z) * normScale;
  }
  geo.attributes.position.needsUpdate = true;

  const posAttr = geo.attributes.position;
  const vertCount = posAttr.count;
  const basePos = new Float32Array(posAttr.array);
  let baseNormals = fileNormals;
  if (!baseNormals) {
    geo.computeVertexNormals();
    weldNormals(geo.attributes.normal, buildWeldGroups(basePos, vertCount));
    baseNormals = new Float32Array(geo.attributes.normal.array);
  }
  const uvAttr = geo.attributes.uv;
  const uvArray = uvAttr ? new Float32Array(uvAttr.array) : null;
  const indexAttr = geo.getIndex();
  const indexArray = indexAttr ? indexAttr.array : Uint32Array.from({ length: vertCount }, (_, i) => i);
  const grid = buildTriangleGrid(basePos, indexArray);
  const map = sourceMesh.material && sourceMesh.material.map ? sourceMesh.material.map : null;
  const fallbackColor = new THREE.Color(cfg.fallbackColor);
  geo.dispose();

  console.log(`[SquishyToy] ${id}: ${vertCount} verts, ${indexArray.length / 3} tris, ${grid.n}³ pick grid`);

  return { basePos, baseNormals, uvArray, indexArray, grid, vertCount, map, fallbackColor };
}

// ---- the squish itself: a vertex shader ----
//
// A press squishes the toy like a head on a pillow. Every vertex moves, by
// the sum of four parts, all measured on the REST surface:
// 1. the dent: a wide smooth bell pushed in along the press direction,
//    deepest under the finger;
// 2. the rim: a wider, shallower bell in the other direction, so the ring
//    around the dent swells up as the stuffing is pushed aside;
// 3. the pull: the surface around the dent slides in toward the press point
//    (sideways to the press), so the fabric folds into the dent instead of
//    just dipping;
// 4. the squeeze: the whole body is compressed along the press direction and
//    spreads out sideways, so even the far side reacts.
// Each press point is one damped spring on the JS thread (its amplitude);
// when the finger slides, the old spot springs back while the new one grows
// (that superposition is the "jelly" lag).
//
// The mesh never changes on the CPU (that cost 10-20 ms a frame on a 6k-
// vertex Tripo mesh under Hermes). The GPU evaluates the displacement per
// vertex from a short list of press points (position + spring amplitude,
// uSquishPress), and transforms the authored normal by the cofactor of the
// displacement's Jacobian, so shading follows the squish without any
// normal recomputation. tickPhysics only advances one scalar spring per
// press point.
const SQUISH_MAX_PRESSES = 24;

// uSquishDir: press direction * push-in/pop-out sign / lift.
// uSquishDent: x = 1/sigma^2 of the dent, y = pull strength (signed, per
// unit of amplitude), z = overshoot guard on the depth, w = squeeze amount
// (signed). uSquishRim: x = 1/sigma^2 of the rim, y = rim height ratio,
// z = 1/sigma^2 of the pull.
const SQUISH_VERTEX_GLSL = `
#define SQUISH_MAX ${SQUISH_MAX_PRESSES}
uniform vec4 uSquishPress[SQUISH_MAX];
uniform int uSquishCount;
uniform vec3 uSquishDir;
uniform vec4 uSquishDent;
uniform vec3 uSquishRim;
uniform vec3 uWrinkleSize;
varying vec3 vSquishRest;
varying float vSquishShade;
vec3 squishGrad;
vec3 squishPull;
mat3 squishPullJ;
float squishDepth(vec3 p, mat3 sideways) {
  float depth = 0.0;
  squishGrad = vec3(0.0);
  squishPull = vec3(0.0);
  squishPullJ = mat3(0.0);
  for (int j = 0; j < SQUISH_MAX; j++) {
    if (j >= uSquishCount) break;
    vec3 q = p - uSquishPress[j].xyz;
    float qq = dot(q, q);
    float amp = uSquishPress[j].w;
    float dent = exp(-0.5 * qq * uSquishDent.x) * amp;
    float rim = exp(-0.5 * qq * uSquishRim.x) * amp * uSquishRim.y;
    depth += dent - rim;
    squishGrad -= q * (dent * uSquishDent.x - rim * uSquishRim.x);
    vec3 t = sideways * q;
    float k = uSquishDent.y * exp(-0.5 * qq * uSquishRim.z) * amp;
    squishPull -= t * k;
    squishPullJ -= k * (sideways - mat3(t * q.x, t * q.y, t * q.z) * uSquishRim.z);
  }
  return depth;
}
`;

// After three's own "objectNormal = normal": the displaced surface's normal
// is cof(J) * normal for the displacement's Jacobian J (columns c0..c2:
// cof(J) has columns c1 x c2, c2 x c0, c0 x c1). If an extreme press ever
// folds the surface, the rest normal is kept rather than flipping the
// shading.
const SQUISH_NORMAL_GLSL = `
#include <beginnormal_vertex>
vec3 squishAxis = normalize(uSquishDir);
mat3 squishAlong = mat3(squishAxis * squishAxis.x, squishAxis * squishAxis.y, squishAxis * squishAxis.z);
mat3 squishSqueezeJ = uSquishDent.w * (0.25 * mat3(1.0) - 1.25 * squishAlong);
float squishD = squishDepth(position, mat3(1.0) - squishAlong);
{
  vec3 g = squishD < uSquishDent.z ? squishGrad : vec3(0.0);
  mat3 J = mat3(1.0) + mat3(uSquishDir * g.x, uSquishDir * g.y, uSquishDir * g.z) + squishPullJ + squishSqueezeJ;
  vec3 n = cross(J[1], J[2]) * objectNormal.x + cross(J[2], J[0]) * objectNormal.y + cross(J[0], J[1]) * objectNormal.z;
  if (dot(n, objectNormal) > 0.0) objectNormal = normalize(n);
}
`;

// After three's "transformed = position": move the vertex. The squeeze is
// linear in the position (compress along the press, spread sideways by a
// quarter of that), so its Jacobian above is the matrix itself.
const SQUISH_POSITION_GLSL = `
#include <begin_vertex>
transformed += uSquishDir * min(squishD, uSquishDent.z) + squishPull + squishSqueezeJ * position;
vSquishRest = position;
vSquishShade = step(0.0, uSquishDent.y) * clamp(squishD * uWrinkleSize.z, 0.0, 1.0);
`;

// ---- the skin: wrinkles and the dent's shadow (fragment shader) ----
//
// Pressing a squishy stretches its skin toward the finger: thin bright
// creases spread out from the press point across the face and down the
// body, and they fade out slowly after the release, after the shape has
// already sprung back. They're drawn per pixel around the latest press
// point (on the rest surface, so they stay put on the skin): spokes at
// random angles that wiggle and end at random lengths, in three layers,
// with a constant thickness on the
// surface. The long ones start at the press point; the others start a little
// further out (they read as branches); each is jagged and broken in places.
// The dent itself is also shaded darker, the deeper it is.
//
// uWrinkle: xyz = centre (rest space), w = strength 0..1.
// uWrinkleAxis: the press direction. uWrinkleSize: x = reach, y = spoke
// count, z = 1 / the full dent depth (for the dent's shadow).
const SQUISH_FRAGMENT_GLSL = `
uniform vec4 uWrinkle;
uniform vec3 uWrinkleAxis;
uniform vec3 uWrinkleSize;
varying vec3 vSquishRest;
varying float vSquishShade;
float squishHash(float n) { return fract(sin(n * 127.1 + 311.7) * 43758.5453); }
float squishWrinkles() {
  if (uWrinkle.w < 0.003) return 0.0;
  vec3 ax = uWrinkleAxis;
  vec3 q = vSquishRest - uWrinkle.xyz;
  vec3 t = q - ax * dot(q, ax);
  float r = length(t);
  float reach = uWrinkleSize.x;
  if (r > reach || dot(q, ax) > reach * 0.6) return 0.0;
  vec3 u = normalize(cross(ax, abs(ax.y) < 0.9 ? vec3(0.0, 1.0, 0.0) : vec3(1.0, 0.0, 0.0)));
  vec3 v = cross(ax, u);
  float ang = atan(dot(t, v), dot(t, u)) / 6.2831853 + 0.5;
  float sum = 0.0;
  for (int layer = 0; layer < 3; layer++) {
    float fl = float(layer);
    float count = uWrinkleSize.y * (1.0 + fl * 0.9);
    float a = ang * count + fl * 0.37;
    float cell = floor(a);
    float h1 = squishHash(cell + fl * 91.0);
    float h2 = squishHash(cell * 1.7 + 13.0 + fl * 37.0);
    float h3 = squishHash(cell * 2.3 + 71.0 + fl * 17.0);
    float wig = (h1 - 0.5) * 0.3
      + 0.07 * sin(r * (23.0 + 17.0 * h2) + h1 * 40.0)
      + 0.05 * sin(r * (61.0 + 23.0 * h3) + h2 * 20.0);
    float f = abs(fract(a) - 0.5 - wig);
    float spacing = max(r * 6.2831853 / count, 1e-4);
    float w = min(0.007 / spacing, 0.3);
    float line = 1.0 - smoothstep(w * 0.3, w * 1.3, f);
    float r0 = fl * reach * 0.12 * h3;
    float len = reach * (0.18 + 0.7 * h2 * h2) * (1.0 - 0.3 * fl);
    line *= smoothstep(r0, r0 + 0.04, r) * (1.0 - smoothstep(r0 + len * 0.6, r0 + len, r));
    line *= step(0.22, squishHash(cell * 3.1 + floor(r * 14.0) * 7.7 + fl * 5.0));
    sum += line * (0.45 + 0.55 * h3) * (1.0 - 0.3 * fl);
  }
  float fade = smoothstep(0.015, 0.09, length(q)) * (1.0 - smoothstep(0.55, 1.0, length(q) / reach));
  return clamp(sum, 0.0, 1.0) * fade * uWrinkle.w;
}
`;

// After the texture colour: the dent is shaded darker the deeper it is.
const SQUISH_COLOR_GLSL = `
#include <map_fragment>
diffuseColor.rgb *= 1.0 - 0.4 * vSquishShade;
`;

// Before three writes the pixel: the creases catch the light.
const SQUISH_LIGHT_GLSL = `
outgoingLight = mix(outgoingLight, vec3(1.0), squishWrinkles() * 0.7);
#include <opaque_fragment>
`;

// How far the creases reach (times the dent's width), how many long ones
// there are, and how long they take to fade after the release (seconds to
// drop to about a third).
const WRINKLE_REACH = 1.6;
const WRINKLE_SPOKES = 30;
const WRINKLE_FADE = 0.7;

// Hooks the squish into a body material's vertex shader and hands the state
// its uniforms (they exist once three compiles the program — on the first
// render — so tickPhysics writes into them only from then on).
function installSquishShader(material, s) {
  material.customProgramCacheKey = () => 'squish';
  material.onBeforeCompile = (shader) => {
    shader.uniforms.uSquishPress = { value: s.pressUniform };
    shader.uniforms.uSquishCount = { value: 0 };
    shader.uniforms.uSquishDir = { value: new THREE.Vector3(0, 0, -1) };
    shader.uniforms.uSquishDent = { value: new THREE.Vector4(1 / (s.dentRadius * s.dentRadius), 0, s.dentDepth * 1.5, 0) };
    shader.uniforms.uSquishRim = { value: new THREE.Vector3() };
    shader.uniforms.uWrinkle = { value: new THREE.Vector4() };
    shader.uniforms.uWrinkleAxis = { value: new THREE.Vector3(0, 0, -1) };
    shader.uniforms.uWrinkleSize = { value: new THREE.Vector3(s.dentRadius * WRINKLE_REACH, WRINKLE_SPOKES, 1 / s.dentDepth) };
    shader.vertexShader = shader.vertexShader
      .replace('void main() {', `${SQUISH_VERTEX_GLSL}\nvoid main() {`)
      .replace('#include <beginnormal_vertex>', SQUISH_NORMAL_GLSL)
      .replace('#include <begin_vertex>', SQUISH_POSITION_GLSL);
    shader.fragmentShader = shader.fragmentShader
      .replace('void main() {', `${SQUISH_FRAGMENT_GLSL}\nvoid main() {`)
      .replace('#include <map_fragment>', SQUISH_COLOR_GLSL)
      .replace('#include <opaque_fragment>', SQUISH_LIGHT_GLSL);
    s.squishUniforms = shader.uniforms;
  };
}

// The per-toy squish state shared by both builders: the live press points
// (each a spring: `amp` is its dent's middle depth, `meanF` the dent's mean
// over the mesh, for the whole-body puff), the shader's uniform storage, and
// the gesture bookkeeping.
function makeSquishState() {
  return {
    presses: [],
    pressUniform: new Float32Array(SQUISH_MAX_PRESSES * 4),
    squishUniforms: null,
    // Player settings (see the SquishyToy props): the squish level's
    // multiplier on the whole squish, and 1 = push in / -1 = pop out.
    dentUserScale: 1,
    dentSign: 1,
    pressDir: new THREE.Vector3(0, 0, -1),
    // Whole-body puff from the mean push-in, applied on the group transform.
    lift: 1,
    // The whole-body squeeze along the press direction (see the shader).
    squeeze: 0,
    // The skin's creases: strength 0..1, where they centre (rest space) and
    // the press direction they spread around.
    wrinkleAmt: 0,
    wrinkleCenter: new THREE.Vector3(),
    wrinkleAxis: new THREE.Vector3(0, 0, -1),
    dentTargetActive: false,
    atRest: true,
    pendingMove: null,
    pickScratch: null,
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
    blinkAmt: 0,
  };
}

// Cheap per-instance construction from prepareModelData's cached output: a
// BufferGeometry over the cached arrays (nothing here is ever written to —
// the squish happens in the shader) plus fresh material/mesh/group.
function buildModelCreature(id, cfg, modelData) {
  const { basePos, baseNormals, uvArray, indexArray, grid, vertCount, map, fallbackColor } = modelData;

  const geo = new THREE.BufferGeometry();
  geo.setAttribute('position', new THREE.BufferAttribute(basePos, 3));
  geo.setAttribute('normal', new THREE.BufferAttribute(baseNormals, 3));
  if (uvArray) geo.setAttribute('uv', new THREE.BufferAttribute(uvArray, 2));
  geo.setIndex(new THREE.BufferAttribute(indexArray, 1));

  const shiny = SHINY_CREATURE_IDS.has(String(id));
  const matParams = {
    map: map || null,
    color: map ? 0xffffff : fallbackColor,
    roughness: shiny ? 0.3 : 0.5,
    metalness: 0,
    envMapIntensity: 1.4,
    // FrontSide only — DoubleSide let the mesh's back faces show through the
    // front while it deformed, which read as "a second model behind it".
    side: THREE.FrontSide,
    flatShading: false,
  };
  const bodyMat = shiny
    ? new THREE.MeshPhysicalMaterial({ ...matParams, clearcoat: 0.6, clearcoatRoughness: 0.25 })
    : new THREE.MeshStandardMaterial(matParams);
  const bodyMesh = new THREE.Mesh(geo, bodyMat);
  const group = new THREE.Group();
  group.add(bodyMesh);
  // Be explicit: R3F can leave automatic matrix updates off for objects it
  // doesn't own (this group is mutated straight from tickPhysics), which is
  // why the group transform wasn't rendering.
  group.matrixAutoUpdate = true;
  group.matrixWorldAutoUpdate = true;

  const shMat = new THREE.MeshBasicMaterial({ color: 0x1a0e38, transparent: true, opacity: 0.35, depthWrite: false });
  const shadowMesh = new THREE.Mesh(new THREE.CircleGeometry(1, 32), shMat);
  shadowMesh.scale.set(cfg.visual * 0.62, cfg.visual * 0.26, 1);
  shadowMesh.position.set(0, -cfg.visual * 0.52, -0.3);
  shadowMesh.rotation.x = -Math.PI / 2.5;

  const s = {
    group,
    shadowMesh,
    bodyMesh,
    bodyGeo: geo,
    bodyMat,
    basePos,
    indexArray,
    grid,
    boundRadius: computeBoundRadius(basePos),
    vertCount,
    // Vertices sampled for a press point's mean dent (the puff): about
    // 1500 of them, whatever the mesh size.
    sampleStride: Math.max(1, Math.ceil(vertCount / 1500)),
    // Dent shape — see MODEL_TUNING.
    dentDepth: cfg.dentDepth,
    dentRadius: cfg.dentRadius,
    dentRim: cfg.dentRim,
    dentRimWidth: cfg.dentRimWidth,
    dentPull: cfg.dentPull,
    dentPullWidth: cfg.dentPullWidth,
    dentSqueeze: cfg.dentSqueeze,
    bottomY: lowestY(basePos),
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
    blinkTimer: 999,
    ...makeSquishState(),
  };
  installSquishShader(bodyMat, s);
  return s;
}

// The lowest point of the rest mesh: the squash keeps it on the floor.
function lowestY(basePos) {
  let min = 0;
  for (let i = 1; i < basePos.length; i += 3) if (basePos[i] < min) min = basePos[i];
  return min;
}

// The dent's mean over the mesh for a press at (px, py, pz) — what the
// whole-body puff (lift) is driven by. Sampled every `sampleStride`th
// vertex; past the reach the bell is under 0.2% of its middle and skipped.
const FALL_EPS = 2e-3;
function meanFunnel(s, px, py, pz) {
  const invS2 = 1 / (s.dentRadius * s.dentRadius);
  const reach2 = (2 * Math.log(1 / FALL_EPS)) / invS2;
  const base = s.basePos;
  const n = s.vertCount;
  const stride = s.sampleStride;
  let sum = 0;
  let count = 0;
  for (let i = 0; i < n; i += stride) {
    const dx = base[i * 3] - px;
    const dy = base[i * 3 + 1] - py;
    const dz = base[i * 3 + 2] - pz;
    const d2 = dx * dx + dy * dy + dz * dz;
    if (d2 < reach2) sum += Math.exp(-0.5 * d2 * invS2);
    count++;
  }
  return count ? sum / count : 0;
}

// A finger that slides less than this (model units; the body is ~1.9
// across) just moves the current press point along. Further than that and
// a new press point starts while the old one springs back — the lag the
// per-vertex springs used to give.
const PRESS_MOVE_EPS = 0.008;

// The press point moved (pointerDown / the once-per-frame pointerMove).
function computeDentFall(s, localPoint) {
  const px = localPoint.x;
  const py = localPoint.y;
  const pz = localPoint.z;
  const presses = s.presses;
  let current = null;
  for (let j = 0; j < presses.length; j++) if (presses[j].driven) current = presses[j];
  if (current) {
    const dx = current.x - px;
    const dy = current.y - py;
    const dz = current.z - pz;
    if (dx * dx + dy * dy + dz * dz < PRESS_MOVE_EPS * PRESS_MOVE_EPS) {
      current.x = px;
      current.y = py;
      current.z = pz;
      current.meanF = meanFunnel(s, px, py, pz);
    } else {
      current.driven = false;
      current = null;
    }
  }
  if (!current) {
    if (presses.length >= SQUISH_MAX_PRESSES) {
      // Full (a long fast drag): fold the faintest old press into its
      // nearest neighbour rather than dropping its depth outright.
      let weakest = 0;
      for (let j = 1; j < presses.length; j++) {
        if (Math.abs(presses[j].amp) + Math.abs(presses[j].vel) < Math.abs(presses[weakest].amp) + Math.abs(presses[weakest].vel)) weakest = j;
      }
      const w = presses[weakest];
      let nearest = -1;
      let nearestD = Infinity;
      for (let j = 0; j < presses.length; j++) {
        if (j === weakest) continue;
        const d = (presses[j].x - w.x) ** 2 + (presses[j].y - w.y) ** 2 + (presses[j].z - w.z) ** 2;
        if (d < nearestD) { nearestD = d; nearest = j; }
      }
      if (nearest >= 0) {
        presses[nearest].amp += w.amp;
        presses[nearest].vel += w.vel;
      }
      presses.splice(weakest, 1);
    }
    presses.push({ x: px, y: py, z: pz, amp: 0, vel: 0, target: 0, meanF: meanFunnel(s, px, py, pz), driven: true });
  }
  // Push direction: from the touch point straight in toward the body's
  // centre. Every dented vertex moves along this one direction (the pull and
  // the squeeze are measured against it too).
  const len = Math.hypot(px, py, pz);
  if (len > 1e-6) s.pressDir.set(-px / len, -py / len, -pz / len);
  const featureSigma = s.dentRadius;
  const featureSigmaFactor = -1 / (2 * featureSigma * featureSigma);
  for (let j = 0; j < s.featureBases.length; j++) {
    const b = s.featureBases[j];
    const dx = b.x - localPoint.x;
    const dy = b.y - localPoint.y;
    const dz = b.z - localPoint.z;
    s.featureDentFall[j] = Math.exp((dx * dx + dy * dy + dz * dz) * featureSigmaFactor);
  }
}

// A press goes straight to 60% of the full depth, then sinks the rest of the
// way in over about a second of holding, like a head settling into a
// pillow. The whole squish scales together.
function applyDentScale(s, holdSeconds) {
  const tipDepth = s.dentDepth * s.dentUserScale * (0.6 + 0.4 * (1 - Math.exp(-holdSeconds * 1.5)));
  const presses = s.presses;
  for (let j = 0; j < presses.length; j++) presses[j].target = presses[j].driven ? tipDepth : 0;
  for (let j = 0; j < s.featureBases.length; j++) s.featureDentTarget[j] = tipDepth * s.featureDentFall[j] * 1.1;
  s.dentTargetActive = true;
  s.atRest = false;
}

function resetDentTargets(s) {
  const presses = s.presses;
  for (let j = 0; j < presses.length; j++) {
    presses[j].driven = false;
    presses[j].target = 0;
  }
  s.featureDentTarget.fill(0);
  s.dentTargetActive = false;
}

// Möller–Trumbore for one triangle with FrontSide back-face culling, ported
// from three's Ray.intersectTriangle on the flat typed arrays: the ray's
// distance to the hit, or Infinity for a miss.
function triHit(pos, index, t, ox, oy, oz, dx, dy, dz) {
  const a = index[t * 3] * 3;
  const b = index[t * 3 + 1] * 3;
  const c = index[t * 3 + 2] * 3;
  const ax = pos[a];
  const ay = pos[a + 1];
  const az = pos[a + 2];
  const e1x = pos[b] - ax;
  const e1y = pos[b + 1] - ay;
  const e1z = pos[b + 2] - az;
  const e2x = pos[c] - ax;
  const e2y = pos[c + 1] - ay;
  const e2z = pos[c + 2] - az;
  const nx = e1y * e2z - e1z * e2y;
  const ny = e1z * e2x - e1x * e2z;
  const nz = e1x * e2y - e1y * e2x;
  let DdN = dx * nx + dy * ny + dz * nz;
  // >= 0: back-facing (culled — the body is FrontSide) or edge-on.
  if (DdN >= 0) return Infinity;
  DdN = -DdN;
  const qx = ox - ax;
  const qy = oy - ay;
  const qz = oz - az;
  const DdQxE2 = -(dx * (qy * e2z - qz * e2y) + dy * (qz * e2x - qx * e2z) + dz * (qx * e2y - qy * e2x));
  if (DdQxE2 < 0) return Infinity;
  const DdE1xQ = -(dx * (e1y * qz - e1z * qy) + dy * (e1z * qx - e1x * qz) + dz * (e1x * qy - e1y * qx));
  if (DdE1xQ < 0) return Infinity;
  if (DdQxE2 + DdE1xQ > DdN) return Infinity;
  const QdN = qx * nx + qy * ny + qz * nz;
  if (QdN < 0) return Infinity;
  return QdN / DdN;
}

// Nearest front-facing hit along a ray (mesh-local space) using the rest
// mesh's triangle grid: the ray is clipped to the grid's box, then walks the
// cells it passes through in order (Amanatides–Woo), testing each cell's
// triangles once. It can stop as soon as the nearest hit so far is closer
// than the next cell boundary, since everything not yet tested lies beyond.
function raycastGrid(s, ox, oy, oz, dx, dy, dz) {
  const g = s.grid;
  const n = g.n;
  let tEnter = 0;
  let tExit = Infinity;
  if (dx !== 0) {
    let t1 = (g.minX - ox) / dx;
    let t2 = (g.maxX - ox) / dx;
    if (t1 > t2) { const tmp = t1; t1 = t2; t2 = tmp; }
    if (t1 > tEnter) tEnter = t1;
    if (t2 < tExit) tExit = t2;
  } else if (ox < g.minX || ox > g.maxX) return Infinity;
  if (dy !== 0) {
    let t1 = (g.minY - oy) / dy;
    let t2 = (g.maxY - oy) / dy;
    if (t1 > t2) { const tmp = t1; t1 = t2; t2 = tmp; }
    if (t1 > tEnter) tEnter = t1;
    if (t2 < tExit) tExit = t2;
  } else if (oy < g.minY || oy > g.maxY) return Infinity;
  if (dz !== 0) {
    let t1 = (g.minZ - oz) / dz;
    let t2 = (g.maxZ - oz) / dz;
    if (t1 > t2) { const tmp = t1; t1 = t2; t2 = tmp; }
    if (t1 > tEnter) tEnter = t1;
    if (t2 < tExit) tExit = t2;
  } else if (oz < g.minZ || oz > g.maxZ) return Infinity;
  if (tEnter > tExit) return Infinity;

  const px = ox + dx * tEnter;
  const py = oy + dy * tEnter;
  const pz = oz + dz * tEnter;
  let ix = Math.max(0, Math.min(n - 1, Math.floor((px - g.minX) / g.csX)));
  let iy = Math.max(0, Math.min(n - 1, Math.floor((py - g.minY) / g.csY)));
  let iz = Math.max(0, Math.min(n - 1, Math.floor((pz - g.minZ) / g.csZ)));
  const stepX = dx > 0 ? 1 : -1;
  const stepY = dy > 0 ? 1 : -1;
  const stepZ = dz > 0 ? 1 : -1;
  const adx = Math.abs(dx);
  const ady = Math.abs(dy);
  const adz = Math.abs(dz);
  const tDeltaX = adx > 0 ? g.csX / adx : Infinity;
  const tDeltaY = ady > 0 ? g.csY / ady : Infinity;
  const tDeltaZ = adz > 0 ? g.csZ / adz : Infinity;
  let tMaxX = adx > 0 ? tEnter + (dx > 0 ? g.minX + (ix + 1) * g.csX - px : px - (g.minX + ix * g.csX)) / adx : Infinity;
  let tMaxY = ady > 0 ? tEnter + (dy > 0 ? g.minY + (iy + 1) * g.csY - py : py - (g.minY + iy * g.csY)) / ady : Infinity;
  let tMaxZ = adz > 0 ? tEnter + (dz > 0 ? g.minZ + (iz + 1) * g.csZ - pz : pz - (g.minZ + iz * g.csZ)) / adz : Infinity;

  const pos = s.basePos;
  const index = s.indexArray;
  const cellOffsets = g.cellOffsets;
  const cellTris = g.cellTris;
  if (!s.rayStamp) s.rayStamp = new Uint32Array(index.length / 3);
  const stamps = s.rayStamp;
  const stamp = (s.rayStampCounter = (s.rayStampCounter || 0) + 1);
  let bestT = Infinity;
  for (let guard = 3 * n + 3; guard > 0; guard--) {
    const cell = (ix * n + iy) * n + iz;
    for (let k = cellOffsets[cell], k1 = cellOffsets[cell + 1]; k < k1; k++) {
      const tri = cellTris[k];
      if (stamps[tri] === stamp) continue;
      stamps[tri] = stamp;
      const h = triHit(pos, index, tri, ox, oy, oz, dx, dy, dz);
      if (h < bestT) bestT = h;
    }
    let axis;
    let tNext;
    if (tMaxX < tMaxY) {
      if (tMaxX < tMaxZ) { axis = 0; tNext = tMaxX; } else { axis = 2; tNext = tMaxZ; }
    } else if (tMaxY < tMaxZ) { axis = 1; tNext = tMaxY; } else { axis = 2; tNext = tMaxZ; }
    if (bestT <= tNext || tNext > tExit) break;
    if (axis === 0) {
      ix += stepX;
      if (ix < 0 || ix >= n) break;
      tMaxX += tDeltaX;
    } else if (axis === 1) {
      iy += stepY;
      if (iy < 0 || iy >= n) break;
      tMaxY += tDeltaY;
    } else {
      iz += stepZ;
      if (iz < 0 || iz >= n) break;
      tMaxZ += tDeltaZ;
    }
  }
  return bestT;
}

// Nearest front-facing hit on the body's REST (undeformed) surface, in the
// mesh's local space. The dent is measured against the rest positions, and
// picking against the deformed surface let a deep dent "run away" from the
// finger: the ray hit the dent's floor, deep inside, which weakened the
// dent. Imported meshes go through their triangle grid (raycastGrid); the
// procedural sphere just tests every triangle.
const _ray = new THREE.Ray();
const _invWorld = new THREE.Matrix4();
function raycastLocal(s, camera, raycaster, ndcX, ndcY) {
  raycaster.setFromCamera({ x: ndcX, y: ndcY }, camera);
  _ray.copy(raycaster.ray).applyMatrix4(_invWorld.copy(s.bodyMesh.matrixWorld).invert());
  const ox = _ray.origin.x;
  const oy = _ray.origin.y;
  const oz = _ray.origin.z;
  const dx = _ray.direction.x;
  const dy = _ray.direction.y;
  const dz = _ray.direction.z;

  // Ray passes wide of the body's bounding sphere -> no triangle can be hit.
  const tc = -(ox * dx + oy * dy + oz * dz);
  const cx = ox + dx * tc;
  const cy = oy + dy * tc;
  const cz = oz + dz * tc;
  if (cx * cx + cy * cy + cz * cz > s.boundRadius * s.boundRadius) return null;

  let bestT = Infinity;
  if (s.grid) {
    bestT = raycastGrid(s, ox, oy, oz, dx, dy, dz);
  } else {
    const pos = s.basePos;
    const index = s.indexArray;
    for (let t = 0, triCount = index.length / 3; t < triCount; t++) {
      const h = triHit(pos, index, t, ox, oy, oz, dx, dy, dz);
      if (h < bestT) bestT = h;
    }
  }
  if (bestT === Infinity) return null;
  return new THREE.Vector3(ox + dx * bestT, oy + dy * bestT, oz + dz * bestT);
}

// Where on the body a tap landed, in the mesh's local space. Prefers a real
// triangle raycast; when that misses (a tap just off the silhouette, or a
// ray slipping through a hole in an imported mesh) it falls back to the
// nearest *front-facing* base vertex in screen space — so a tap anywhere
// near the toy always dents the surface closest to the finger instead of a
// point floating in the air.
function pickContactLocal(s, camera, raycaster, ndcX, ndcY) {
  const hit = raycastLocal(s, camera, raycaster, ndcX, ndcY);
  if (hit) return hit;

  // Fallback: the same math as Vector3.applyMatrix4(matrixWorld) and
  // .project(camera) per vertex, written out inline, in one pass that caches
  // each vertex's camera distance + screen distance for the selection below.
  // A drag that slides off the toy's edge lands here on every move, so this
  // used to be the single most expensive touch path. On a dense mesh every
  // other vertex is close enough (the press point is smoothed anyway).
  s.bodyMesh.updateWorldMatrix(true, false);
  const m = s.bodyMesh.matrixWorld.elements;
  const v = camera.matrixWorldInverse.elements;
  const p = camera.projectionMatrix.elements;
  const base = s.basePos;
  const n = s.vertCount;
  const stride = n > 3000 ? 2 : 1;
  if (!s.pickScratch) s.pickScratch = new Float64Array(n * 2);
  const scratch = s.pickScratch;
  let minCam = Infinity;
  let maxCam = -Infinity;
  const camX = camera.position.x;
  const camY = camera.position.y;
  const camZ = camera.position.z;
  for (let i = 0; i < n; i += stride) {
    const x = base[i * 3];
    const y = base[i * 3 + 1];
    const z = base[i * 3 + 2];
    let w = 1 / (m[3] * x + m[7] * y + m[11] * z + m[15]);
    const wx = (m[0] * x + m[4] * y + m[8] * z + m[12]) * w;
    const wy = (m[1] * x + m[5] * y + m[9] * z + m[13]) * w;
    const wz = (m[2] * x + m[6] * y + m[10] * z + m[14]) * w;
    const ex = wx - camX;
    const ey = wy - camY;
    const ez = wz - camZ;
    const cd = ex * ex + ey * ey + ez * ez;
    if (cd < minCam) minCam = cd;
    if (cd > maxCam) maxCam = cd;
    w = 1 / (v[3] * wx + v[7] * wy + v[11] * wz + v[15]);
    const vx = (v[0] * wx + v[4] * wy + v[8] * wz + v[12]) * w;
    const vy = (v[1] * wx + v[5] * wy + v[9] * wz + v[13]) * w;
    const vz = (v[2] * wx + v[6] * wy + v[10] * wz + v[14]) * w;
    w = 1 / (p[3] * vx + p[7] * vy + p[11] * vz + p[15]);
    const sx = (p[0] * vx + p[4] * vy + p[8] * vz + p[12]) * w;
    const sy = (p[1] * vx + p[5] * vy + p[9] * vz + p[13]) * w;
    const qx = sx - ndcX;
    const qy = sy - ndcY;
    scratch[i * 2] = cd;
    scratch[i * 2 + 1] = qx * qx + qy * qy;
  }
  const midCam = (minCam + maxCam) / 2;

  let best = -1;
  let bestScreen = Infinity;
  let bestAny = -1;
  let bestAnyScreen = Infinity;
  for (let i = 0; i < n; i += stride) {
    const cd = scratch[i * 2];
    const sd = scratch[i * 2 + 1];
    if (sd < bestAnyScreen) {
      bestAnyScreen = sd;
      bestAny = i;
    }
    if (cd <= midCam && sd < bestScreen) {
      bestScreen = sd;
      best = i;
    }
  }
  const pick = best >= 0 ? best : bestAny;
  if (pick < 0) return null;
  return new THREE.Vector3(s.basePos[pick * 3], s.basePos[pick * 3 + 1], s.basePos[pick * 3 + 2]);
}

// The drag half of a poke. pointerMove only records the latest finger
// position; this does the pick + dent reshape at most once per rendered frame
// (from useFrame), so a burst of touch events can never queue several picks
// between two frames and snowball into lag.
function applyPendingMove(s, camera, raycaster) {
  const move = s.pendingMove;
  if (!move) return;
  s.pendingMove = null;
  if (s.mode !== 'poke') return;
  // A one-finger drag only moves the contact point around — it no longer
  // spins the toy (rotation is the two-finger `orbit` gesture).
  const local = pickContactLocal(s, camera, raycaster, move.x, move.y) || s.dragStartWorld;
  if (!local) return;
  if (!s.pressLocalSmoothed) s.pressLocalSmoothed = local.clone();
  s.pressLocalSmoothed.lerp(local, 0.7);
  s.dragStartWorld = local;
  computeDentFall(s, s.pressLocalSmoothed);
}

// Once released, a press point's spring rings down to effectively nothing
// within about a second. Below this it's far under a pixel, so it's dropped;
// with none left the body is at rest and the shader gets zero press points.
const REST_EPS = 1e-4;

function settleToRest(s) {
  s.presses.length = 0;
  s.lift = 1;
  s.squeeze = 0;
  s.atRest = true;
}

// Writes the live press points into the shader's uniforms (once they exist).
function uploadSquish(s) {
  const u = s.squishUniforms;
  if (!u) return;
  const presses = s.presses;
  const arr = s.pressUniform;
  for (let j = 0; j < presses.length; j++) {
    const pr = presses[j];
    arr[j * 4] = pr.x;
    arr[j * 4 + 1] = pr.y;
    arr[j * 4 + 2] = pr.z;
    arr[j * 4 + 3] = pr.amp;
  }
  u.uSquishCount.value = presses.length;
  const sign = s.dentSign;
  const invLift = 1 / s.lift;
  u.uSquishDir.value.set(s.pressDir.x * sign * invLift, s.pressDir.y * sign * invLift, s.pressDir.z * sign * invLift);
  // Only a guard against runaway spring overshoot; a normal press stays
  // well under it, so it never flattens the tip.
  const fullDepth = s.dentDepth * s.dentUserScale;
  u.uSquishDent.value.set(
    1 / (s.dentRadius * s.dentRadius),
    (s.dentPull / s.dentDepth) * sign * invLift,
    fullDepth * 1.5,
    s.squeeze * sign
  );
  u.uSquishRim.value.set(1 / (s.dentRadius * s.dentRimWidth) ** 2, s.dentRim, 1 / (s.dentRadius * s.dentPullWidth) ** 2);
}

// The skin's creases (see the fragment shader): while the finger is down
// they follow it and grow with the dent (so the squish level scales them
// too); after the release they stay where they were and fade out slowly,
// well after the shape has sprung back.
function tickWrinkles(s, dt) {
  let target = 0;
  if (s.mode === 'poke') {
    const presses = s.presses;
    let ampSum = 0;
    let driven = null;
    for (let j = 0; j < presses.length; j++) {
      ampSum += presses[j].amp;
      if (presses[j].driven) driven = presses[j];
    }
    if (driven) {
      target = clamp(ampSum / s.dentDepth, 0, 1);
      s.wrinkleCenter.set(driven.x, driven.y, driven.z);
      s.wrinkleAxis.copy(s.pressDir);
    }
  }
  const before = s.wrinkleAmt;
  if (target > s.wrinkleAmt) s.wrinkleAmt += (target - s.wrinkleAmt) * Math.min(1, dt * 12);
  else s.wrinkleAmt *= Math.exp(-dt / WRINKLE_FADE);
  if (s.wrinkleAmt < 1e-3) s.wrinkleAmt = 0;
  const u = s.squishUniforms;
  if (!u || (before === 0 && s.wrinkleAmt === 0)) return;
  u.uWrinkle.value.set(s.wrinkleCenter.x, s.wrinkleCenter.y, s.wrinkleCenter.z, s.wrinkleAmt);
  u.uWrinkleAxis.value.copy(s.wrinkleAxis);
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
    applyDentScale(s, s.pressHoldTime);
  }

  // ---- the dent: one damped spring per press point (see the shader notes
  // above). Its depth chases the target while the finger holds it, then
  // rings back to zero — the same spring every vertex used to run.
  const dentStiff = 1 - Math.pow(1 - PHYS.stiff, k);
  const dentDamp = Math.pow(PHYS.damp, k);
  let meanDent = 0;
  if (!s.atRest) {
    const presses = s.presses;
    let motion = 0;
    for (let j = presses.length - 1; j >= 0; j--) {
      const pr = presses[j];
      pr.vel += (pr.target - pr.amp) * dentStiff;
      pr.vel *= dentDamp;
      pr.amp += pr.vel;
      const aa = Math.abs(pr.amp);
      const av = Math.abs(pr.vel);
      if (!pr.driven && aa < REST_EPS && av < REST_EPS) {
        presses.splice(j, 1);
        continue;
      }
      if (aa > motion) motion = aa;
      if (av > motion) motion = av;
      meanDent += pr.amp * pr.meanF;
    }
    // The whole body puffs up slightly with the average push-in (or shrinks
    // slightly with a pop-out), as if that volume went somewhere — on the
    // group transform, below.
    s.lift = Math.min(1 + s.dentSign * meanDent * 0.2, MAX_BULGE);
    // The squeeze follows the presses' springs, so it rings back (and
    // briefly stretches) on release along with the dent.
    let ampSum = 0;
    for (let j = 0; j < presses.length; j++) ampSum += presses[j].amp;
    s.squeeze = clamp((ampSum / s.dentDepth) * s.dentSqueeze, -s.dentSqueeze, s.dentSqueeze * 1.4);
    if (!s.dentTargetActive && (presses.length === 0 || motion < REST_EPS)) {
      settleToRest(s);
      meanDent = 0;
    }
    uploadSquish(s);
  }
  tickWrinkles(s, dt);

  for (let j = 0; j < s.featureBases.length; j++) {
    s.featureDentVel[j] += (s.featureDentTarget[j] - s.featureDentAmt[j]) * dentStiff;
    s.featureDentVel[j] *= dentDamp;
    s.featureDentAmt[j] += s.featureDentVel[j];
    const factor = clamp(1 - s.dentSign * (s.featureDentAmt[j] * 1.5 - meanDent * 0.2), 0.5, 1.2);
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

  // The whole-body squash (flatten on push-in, stretch on pop-out), the
  // puff, breathing, wobble and orbit all ride on the group transform (the
  // group has matrixAutoUpdate on — see buildModelCreature; without it these
  // never repainted).
  const breathe = 1 + Math.sin(s.idlePhase * 0.45) * 0.012;
  const lift = s.lift;
  // The sideways spread is kept small (the shader's squeeze adds its own):
  // the stage is only ~9% wider than the widest creature.
  const sx = (1 + s.globalSquash * 0.05) * breathe * lift;
  const sy = (1 - s.globalSquash * 0.24) * breathe * lift;
  const sz = (1 + s.globalSquash * 0.05) * breathe * lift;
  s.group.rotation.y = s.userRotY;
  s.group.rotation.x = s.userRotX + s.wobbleRotX;
  s.group.rotation.z = s.wobbleRotZ;
  s.group.scale.set(sx, sy, sz);
  // Flattening keeps the bottom on the floor, so the body sinks down under
  // the press instead of shrinking toward its middle. A stretch (the release
  // overshoot) stays centred, so the top doesn't leave the stage.
  s.group.position.y = s.bottomY * (1 - Math.min(sy, 1));

  if (s.eyeStyle === 'round') {
    const blinkScale = 1 - s.blinkAmt * 0.88;
    s.eyeL.scale.y = s.featureScaleBase[0].y * blinkScale;
    s.eyeR.scale.y = s.featureScaleBase[1].y * blinkScale;
  }
}

// Memoized so a parent re-render triggered by unrelated state (coin counters,
// timers, etc.) doesn't force React to reconcile this subtree — the per-frame
// squish physics already runs in useFrame and shouldn't compete with that.
const SquishyToy = memo(forwardRef(function SquishyToy(
  { creatureId = '0', modelUrl, visual, onSquish, onRelease, dentScale = 1, dentOutward = false },
  ref
) {
  const { camera, gl } = useThree();
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

    // A 3D-model creature (every premade one, plus a photo-path custom one)
    // loads its .glb from Firebase Storage via `modelUrl` first, so `built`
    // stays null for the brief window before it resolves — every
    // imperative-handle method and useFrame already bails while
    // toyRef.current is null, so that window is safe. Anything without a
    // modelUrl falls back to the procedural sphere, which builds
    // synchronously.
    const modelId = Number(creatureId);
    let pending;
    if (modelUrl) {
      pending = loadModelDataFromUrl(creatureId, modelUrl).then((modelData) => buildModelCreature(creatureId, MODEL_TUNING, modelData));
    } else {
      pending = Promise.resolve(buildCreature(modelId, visual));
    }

    pending
      .then((r) => {
        if (cancelled) {
          result = r;
          dispose();
          return;
        }
        result = r;
        if (r.bodyMat.map) {
          // Sharpens a lower-res texture at grazing angles/distance for
          // free — filtering cost, not resolution, so it doesn't reintroduce
          // the per-frame CPU cost the poly/texture downsizing fixed.
          r.bodyMat.map.anisotropy = gl.capabilities.getMaxAnisotropy();
          r.bodyMat.map.needsUpdate = true;
        }
        toyRef.current = r;
        setBuilt(r);
      })
      .catch((err) => {
        // eslint-disable-next-line no-console
        console.error(`[SquishyToy] failed to build creature ${creatureId}: ${(err && err.stack) || err}`);
        // The GLB failed to load/parse (e.g. a device fetch quirk) — fall back
        // to the procedural sphere for this creature so the stage is never
        // blank and stays fully interactive.
        if (cancelled) return;
        try {
          const fallback = buildCreature(modelId, visual);
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

  // The player's poke settings (the squish screen's settings popup). Applied
  // live: a change takes effect on the next press, or the current one.
  useEffect(() => {
    const s = toyRef.current;
    if (!s) return;
    s.dentUserScale = dentScale;
    s.dentSign = dentOutward ? -1 : 1;
  }, [built, dentScale, dentOutward]);

  useImperativeHandle(
    ref,
    () => ({
      pointerDown: (ndcX, ndcY) => {
        const s = toyRef.current;
        if (!s) return;
        const local = pickContactLocal(s, camera, raycaster, ndcX, ndcY);
        if (!local) return;
        s.mode = 'poke';
        s.dragStartWorld = local;
        s.pressLocalSmoothed = local.clone();
        s.pressHoldTime = 0;
        s.pendingMove = null;
        computeDentFall(s, local);
        applyDentScale(s, 0);
        // A push-in flattens the whole body; a pop-out stretches it instead.
        // The squish level scales it with the rest of the squish.
        s.globalSquashTarget = 0.55 * s.dentUserScale * s.dentSign;
        onSquish && onSquish();
      },
      // Only records where the finger is now — applyPendingMove (in useFrame)
      // does the actual pick + dent reshape once per frame.
      pointerMove: (ndcX, ndcY) => {
        const s = toyRef.current;
        if (!s || s.mode !== 'poke') return;
        s.pendingMove = { x: ndcX, y: ndcY };
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
        s.pendingMove = null;
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
        // The under-damped spring (see tickPhysics) overshoots on its own —
        // g springs from ~0.85 back through 0 into a tall stretch and bounces
        // down to rest.
        const kick = PHYS.wobbleKick;
        s.wobbleRotXV += clamp((Math.random() - 0.5) * kick, -kick, kick);
        s.wobbleRotZV += clamp((Math.random() - 0.5) * kick, -kick, kick);
        s.pressLocalSmoothed = null;
        s.pressHoldTime = 0;
        s.pendingMove = null;
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
    const t0 = performance.now();
    applyPendingMove(s, camera, raycaster);
    const t1 = performance.now();
    tickPhysics(s, clamp(delta, 0, 0.05));
    perf.add('pick', t1 - t0);
    perf.add('physics', performance.now() - t1);
  });

  if (!built) return null;

  return (
    <>
      <primitive object={built.group} />
      <primitive object={built.shadowMesh} />
    </>
  );
}));

export default SquishyToy;
