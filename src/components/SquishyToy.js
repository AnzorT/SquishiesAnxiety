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
import { RoomEnvironment } from 'three/examples/jsm/environments/RoomEnvironment.js';
import { PHYS } from '../data/creatures';

// Used by buildCreature's procedural-sphere path (and prepareModelData's
// no-texture-map fallback tint) whenever the caller doesn't have a real
// visual spec handy — e.g. a GLB that fails to load before its Firestore
// creature doc's `visual` field made it into scope. Matches Glorp's teal.
const DEFAULT_VISUAL = { color: '#2dd4bf', accent: '#0d9488', accessory: 'antenna', eye: 'round' };

// Tripo's viewer lights models with an HDRI-style environment (reflections +
// ambient fill from every direction), which is most of why the same texture
// looks richer there than under our 3 bare directional lights. RoomEnvironment
// is a plain three.js scene (boxes + emissive panels, no image loading), so
// PMREMGenerator can prefilter it straight through the same WebGL context
// expo-gl gives us — no DOM/HDR-file dependency that would break on native.
// Cached per-`gl` (module-level, survives remounts) since prefiltering it is
// not free and the result is identical every time.
let cachedEnvTexture = null;
let cachedEnvGl = null;
function getEnvironmentTexture(gl) {
  if (cachedEnvTexture && cachedEnvGl === gl) return cachedEnvTexture;
  try {
    const pmrem = new THREE.PMREMGenerator(gl);
    const envScene = new RoomEnvironment();
    const renderTarget = pmrem.fromScene(envScene, 0.035);
    pmrem.dispose();
    envScene.dispose();
    cachedEnvTexture = renderTarget.texture;
    cachedEnvGl = gl;
    // eslint-disable-next-line no-console
    console.log('[SquishyToy] environment map generated OK');
  } catch (err) {
    // eslint-disable-next-line no-console
    console.warn('[SquishyToy] environment map generation failed, continuing without it', err);
    cachedEnvTexture = null;
    cachedEnvGl = null;
  }
  return cachedEnvTexture;
}

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
  const colCount = widthSeg + 1;
  const rowCount = heightSeg + 1;
  const count = posAttr.count;
  geo.computeVertexNormals();
  const basePos = new Float32Array(posAttr.array);
  const baseNormals = new Float32Array(geo.attributes.normal.array);

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

  return {
    group,
    shadowMesh,
    bodyMesh,
    bodyGeo: geo,
    bodyMat,
    basePos,
    baseNormals,
    indexArray: geo.index.array,
    boundRadius: computeBoundRadius(basePos),
    vertCount: count,
    colCount,
    rowCount,
    dentAmt: new Float32Array(count),
    dentTarget: new Float32Array(count),
    dentVel: new Float32Array(count),
    dentScratch: new Float32Array(count),
    dentFall: new Float32Array(count),
    dentTargetActive: false,
    atRest: true,
    pendingMove: null,
    pickScratch: null,
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
// Gaussian dent target, global squash/wobble, release kick, drag-to-orbit)
// only reasons about vertex positions, so it runs unmodified on any mesh.

// Every model creature — premade or custom — uses this same tuning: `visual`
// bakes the on-stage size into the geometry (the mesh is recentred +
// rescaled so its largest dimension == this many units; 2 == same size as
// the procedural spheres); `dentSigma`/`dentStrength`/`dentFloor` give it a
// wide/deep/gentle-floored dent feel (the original c9586dd build) vs the
// design sphere's shallow one — see computeDentFall/applyDentScale/
// tickPhysics. `fallbackColor` only matters for the rare mesh with no baked
// texture map (see prepareModelData).
const MODEL_TUNING = { visual: 1.9, dentSigma: 0.3, dentStrength: 2.3, dentFloor: 0.72, fallbackColor: '#2dd4bf' };

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

// Low-poly exports (Tripo retopo included) commonly split a vertex into two
// indices with identical positions wherever a UV or normal seam crosses it,
// so the mesh can still texture correctly. computeVertexNormals() only
// blends face normals across shared indices, so those seam duplicates never
// see each other's face and the seam reads as a hard facet crease. Group
// same-position indices once so their normals can be re-averaged after every
// computeVertexNormals() call, without touching UVs.
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

// The expensive, purely-deterministic half of turning a parsed .glb into a
// squishable mesh: recentre/rescale, normals, weld-group + adjacency
// computation. This is CPU-bound (Set/Map work over every vertex/triangle)
// and depends only on the source asset + tuning config, never on a specific
// toy instance — so it's cacheable per id/url (see loadModelData /
// loadModelDataFromUrl below) and runs once, during LoadingScreen's preload,
// instead of blocking SquishScreen's first mount. buildModelCreature (below)
// does the remaining *cheap* per-instance work (fresh geometry + mesh) so a
// revisit — or the normal preload-then-mount path — never re-pays this cost.
function prepareModelData(id, cfg, gltf) {
  let sourceMesh = null;
  gltf.scene.traverse((obj) => {
    if (!sourceMesh && obj.isMesh) sourceMesh = obj;
  });
  if (!sourceMesh) throw new Error(`3D model ${id}: no mesh found in scene`);

  const geo = sourceMesh.geometry.clone();
  geo.computeBoundingBox();

  // The raw export's pivot sits at its base. Recenter on the bbox centre and
  // bake the on-screen size straight into the geometry (largest dimension ->
  // cfg.visual units). The mesh squishes via the group transform only, so
  // there is no per-vertex physics that cares about the geometry's scale.
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
  geo.computeVertexNormals();

  const posAttr = geo.attributes.position;
  const vertCount = posAttr.count;
  const basePos = new Float32Array(posAttr.array);
  const weldGroups = buildWeldGroups(basePos, vertCount);
  weldNormals(geo.attributes.normal, weldGroups);
  const baseNormals = new Float32Array(geo.attributes.normal.array);
  const uvAttr = geo.attributes.uv;
  const uvArray = uvAttr ? new Float32Array(uvAttr.array) : null;
  const indexAttr = geo.getIndex();
  const indexArray = indexAttr ? indexAttr.array : Uint32Array.from({ length: vertCount }, (_, i) => i);
  const neighbors = buildAdjacency(indexArray, vertCount);
  const map = sourceMesh.material && sourceMesh.material.map ? sourceMesh.material.map : null;
  const fallbackColor = new THREE.Color(cfg.fallbackColor);
  geo.dispose();

  // weldGroups' total vertex count (not just triangle/vertex count) drives
  // tickPhysics's per-frame weldNormals cost — a Tripo photo-to-3D mesh can
  // have far messier UV-seam topology than the curated premade roster even
  // at the same face_limit, so this is the number that actually predicts
  // whether a given model will feel laggy on the squish stage.
  const weldedVertCount = weldGroups.reduce((sum, g) => sum + g.length, 0);
  console.log(
    `[SquishyToy] ${id}: ${vertCount} verts, ${indexArray.length / 3} tris, ` +
      `${weldGroups.length} weld groups (${weldedVertCount} verts welded)`
  );

  return { basePos, baseNormals, uvArray, indexArray, neighbors, weldGroups, vertCount, map, fallbackColor };
}

// Cheap per-instance construction from prepareModelData's cached output: a
// fresh BufferGeometry (position/normal copied since tickPhysics mutates them
// every frame; index/uv shared directly since they're never written to) plus
// fresh material/mesh/group. No clone/normalize/weld/adjacency work here.
function buildModelCreature(id, cfg, modelData) {
  const { basePos, baseNormals, uvArray, indexArray, neighbors, weldGroups, vertCount, map, fallbackColor } = modelData;

  const geo = new THREE.BufferGeometry();
  geo.setAttribute('position', new THREE.BufferAttribute(new Float32Array(basePos), 3));
  geo.setAttribute('normal', new THREE.BufferAttribute(new Float32Array(baseNormals), 3));
  if (uvArray) geo.setAttribute('uv', new THREE.BufferAttribute(uvArray, 2));
  geo.setIndex(new THREE.BufferAttribute(indexArray, 1));

  const bodyMat = new THREE.MeshStandardMaterial({
    map: map || null,
    color: map ? 0xffffff : fallbackColor,
    roughness: 0.5,
    metalness: 0,
    envMapIntensity: 1.4,
    // FrontSide only — DoubleSide let the mesh's back faces show through the
    // front while it deformed, which read as "a second model behind it".
    side: THREE.FrontSide,
    flatShading: false,
  });
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

  return {
    group,
    shadowMesh,
    bodyMesh,
    bodyGeo: geo,
    bodyMat,
    basePos,
    baseNormals,
    indexArray,
    boundRadius: computeBoundRadius(basePos),
    vertCount,
    // Grid dims unused — the presence of `neighbors` routes tickPhysics down
    // the topology-agnostic diffusion path instead.
    colCount: 0,
    rowCount: 0,
    neighbors,
    weldGroups,
    // The imported meshes squish purely by the per-vertex dent (the only
    // thing that renders per frame on the target device — see tickPhysics).
    // These make it a wide, deep, gentle-floored dent like the original
    // c9586dd build, vs the design sphere's shallow one — see MODEL_TUNING.
    dentSigma: cfg.dentSigma,
    dentStrength: cfg.dentStrength,
    dentFloor: cfg.dentFloor,
    dentAmt: new Float32Array(vertCount),
    dentTarget: new Float32Array(vertCount),
    dentVel: new Float32Array(vertCount),
    dentScratch: new Float32Array(vertCount),
    dentFall: new Float32Array(vertCount),
    dentTargetActive: false,
    atRest: true,
    pendingMove: null,
    pickScratch: null,
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
  // Per-creature dent width. Glorp (imported mesh) uses a wide 0.3 like the
  // original c9586dd build; the procedural sphere keeps the design's 0.16.
  const sigma = s.dentSigma ?? 0.16;
  const sigmaFactor = -1 / (2 * sigma * sigma);
  // Arrays hoisted into locals throughout the per-frame/per-touch paths:
  // Hermes has no JIT, so a repeated `s.foo[i]` property lookup inside a
  // hot loop is a real per-vertex cost, not something that gets optimized away.
  const base = s.basePos;
  const fall = s.dentFall;
  const px = localPoint.x;
  const py = localPoint.y;
  const pz = localPoint.z;
  for (let i = 0; i < s.vertCount; i++) {
    const dx = base[i * 3] - px;
    const dy = base[i * 3 + 1] - py;
    const dz = base[i * 3 + 2] - pz;
    fall[i] = Math.exp((dx * dx + dy * dy + dz * dz) * sigmaFactor);
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
  // Glorp (dentStrength ~2.3) gets the deep c9586dd-era dent; the sphere keeps
  // the design's shallower one.
  const maxDent = 0.3 * PHYS.strength * depthMul * (s.dentStrength ?? 1);
  const target = s.dentTarget;
  const fall = s.dentFall;
  for (let i = 0; i < s.vertCount; i++) target[i] = maxDent * fall[i];
  for (let j = 0; j < s.featureBases.length; j++) s.featureDentTarget[j] = maxDent * s.featureDentFall[j] * 1.1;
  s.dentTargetActive = true;
  s.atRest = false;
}

function resetDentTargets(s) {
  s.dentTarget.fill(0);
  s.featureDentTarget.fill(0);
  s.dentTargetActive = false;
}

// Nearest front-facing hit on the body's current (deformed) surface, in the
// mesh's local space — the same answer raycaster.intersectObject gives
// (Möller–Trumbore with FrontSide back-face culling, ported from three's
// Ray.intersectTriangle), but as one flat loop over the typed arrays instead
// of three's per-triangle Vector3 calls and per-hit object allocation, which
// cost several ms per touch event on Hermes.
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

  const pos = s.bodyGeo.attributes.position.array;
  const index = s.indexArray;
  let bestT = Infinity;
  for (let t = 0; t < index.length; t += 3) {
    const a = index[t] * 3;
    const b = index[t + 1] * 3;
    const c = index[t + 2] * 3;
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
    if (DdN >= 0) continue;
    DdN = -DdN;
    const qx = ox - ax;
    const qy = oy - ay;
    const qz = oz - az;
    const DdQxE2 = -(dx * (qy * e2z - qz * e2y) + dy * (qz * e2x - qx * e2z) + dz * (qx * e2y - qy * e2x));
    if (DdQxE2 < 0) continue;
    const DdE1xQ = -(dx * (e1y * qz - e1z * qy) + dy * (e1z * qx - e1x * qz) + dz * (e1x * qy - e1y * qx));
    if (DdE1xQ < 0) continue;
    if (DdQxE2 + DdE1xQ > DdN) continue;
    const QdN = qx * nx + qy * ny + qz * nz;
    if (QdN < 0) continue;
    const hitT = QdN / DdN;
    if (hitT < bestT) bestT = hitT;
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
  // used to be the single most expensive touch path.
  s.bodyMesh.updateWorldMatrix(true, false);
  const m = s.bodyMesh.matrixWorld.elements;
  const v = camera.matrixWorldInverse.elements;
  const p = camera.projectionMatrix.elements;
  const base = s.basePos;
  const n = s.vertCount;
  if (!s.pickScratch) s.pickScratch = new Float64Array(n * 2);
  const scratch = s.pickScratch;
  let minCam = Infinity;
  let maxCam = -Infinity;
  const camX = camera.position.x;
  const camY = camera.position.y;
  const camZ = camera.position.z;
  for (let i = 0; i < n; i++) {
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
  for (let i = 0; i < n; i++) {
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

// bodyGeo.computeVertexNormals() followed by weldNormals(), written as plain
// typed-array arithmetic in the exact same operation order (so the result is
// bit-identical) — without three's per-triangle Vector3/BufferAttribute
// method calls, which made this the most expensive part of every frame.
function computeNormals(s) {
  const pos = s.bodyGeo.attributes.position.array;
  const normalAttr = s.bodyGeo.attributes.normal;
  const nrm = normalAttr.array;
  const index = s.indexArray;
  nrm.fill(0);
  for (let t = 0; t < index.length; t += 3) {
    const a = index[t] * 3;
    const b = index[t + 1] * 3;
    const c = index[t + 2] * 3;
    const bx = pos[b];
    const by = pos[b + 1];
    const bz = pos[b + 2];
    const cbx = pos[c] - bx;
    const cby = pos[c + 1] - by;
    const cbz = pos[c + 2] - bz;
    const abx = pos[a] - bx;
    const aby = pos[a + 1] - by;
    const abz = pos[a + 2] - bz;
    const nx = cby * abz - cbz * aby;
    const ny = cbz * abx - cbx * abz;
    const nz = cbx * aby - cby * abx;
    nrm[a] += nx;
    nrm[a + 1] += ny;
    nrm[a + 2] += nz;
    nrm[b] += nx;
    nrm[b + 1] += ny;
    nrm[b + 2] += nz;
    nrm[c] += nx;
    nrm[c + 1] += ny;
    nrm[c + 2] += nz;
  }
  for (let i = 0; i < nrm.length; i += 3) {
    const x = nrm[i];
    const y = nrm[i + 1];
    const z = nrm[i + 2];
    const inv = 1 / (Math.sqrt(x * x + y * y + z * z) || 1);
    nrm[i] = x * inv;
    nrm[i + 1] = y * inv;
    nrm[i + 2] = z * inv;
  }
  const weldGroups = s.weldGroups;
  if (weldGroups) {
    for (let g = 0; g < weldGroups.length; g++) {
      const group = weldGroups[g];
      let nx = 0;
      let ny = 0;
      let nz = 0;
      for (let k = 0; k < group.length; k++) {
        const o = group[k] * 3;
        nx += nrm[o];
        ny += nrm[o + 1];
        nz += nrm[o + 2];
      }
      const len = Math.hypot(nx, ny, nz) || 1;
      nx /= len;
      ny /= len;
      nz /= len;
      for (let k = 0; k < group.length; k++) {
        const o = group[k] * 3;
        nrm[o] = nx;
        nrm[o + 1] = ny;
        nrm[o + 2] = nz;
      }
    }
  }
  normalAttr.needsUpdate = true;
}

// Once released, the dent springs ring down to effectively nothing within
// about a second. Below this they're far under a pixel, so tickPhysics snaps
// them to exact rest and stops rewriting/re-uploading the vertex + normal
// buffers every frame until the next press (applyDentScale wakes it).
const REST_EPS = 1e-4;

function settleToRest(s) {
  s.dentAmt.fill(0);
  s.dentVel.fill(0);
  const posAttr = s.bodyGeo.attributes.position;
  posAttr.array.set(s.basePos);
  posAttr.needsUpdate = true;
  const normalAttr = s.bodyGeo.attributes.normal;
  normalAttr.array.set(s.baseNormals);
  normalAttr.needsUpdate = true;
  s.atRest = true;
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
    applyDentScale(s, 1 + s.pressHoldTime * 1.6);
  }

  // ---- per-vertex soft body ----
  // This is the ONLY deformation that renders on the target device (writing
  // vertex positions + needsUpdate). Object/group .scale transforms are
  // computed but never repainted here, so the squash IS this dent — a
  // per-vertex pull toward the model centre around the touch point, spread by
  // a jelly-wave diffusion. Same approach as the original c9586dd build.
  const dentStiff = 1 - Math.pow(1 - PHYS.stiff, k);
  const dentDamp = Math.pow(PHYS.damp, k);
  let meanDent = 0;
  // Skipped entirely while the body is settled (see REST_EPS/settleToRest) —
  // nothing below changes a single vertex then, so there's no reason to spend
  // the frame recomputing and re-uploading an unchanged mesh.
  if (!s.atRest) {
    const n = s.vertCount;
    const amt = s.dentAmt;
    const vel = s.dentVel;
    const target = s.dentTarget;
    let motion = 0;
    for (let i = 0; i < n; i++) {
      vel[i] += (target[i] - amt[i]) * dentStiff;
      vel[i] *= dentDamp;
      amt[i] += vel[i];
      const av = amt[i];
      const vv = vel[i];
      if (av > motion) motion = av;
      else if (-av > motion) motion = -av;
      if (vv > motion) motion = vv;
      else if (-vv > motion) motion = -vv;
    }

    s.dentScratch.set(amt);
    const prev = s.dentScratch;
    const diffCoef = 0.03 * k;
    if (s.neighbors) {
      // Imported mesh (Glorp): diffuse across real triangle-adjacency, averaged
      // by neighbour count then x4 to match the grid branch's range.
      const neighbors = s.neighbors;
      for (let i = 0; i < n; i++) {
        const nbrs = neighbors[i];
        const nn = nbrs.length;
        if (!nn) continue;
        const pi = prev[i];
        let acc = 0;
        for (let ni = 0; ni < nn; ni++) acc += prev[nbrs[ni]] - pi;
        amt[i] += (acc / nn) * 4 * diffCoef;
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
          amt[idx] += (left + right - 2 * prev[idx] + (up + down - 2 * prev[idx])) * diffCoef;
        }
      }
    }

    let sum = 0;
    for (let i = 0; i < n; i++) sum += amt[i];
    meanDent = sum / n;

    // Written straight into the attribute's array (what setXYZ does, minus
    // the method call per vertex).
    const posAttr = s.bodyGeo.attributes.position;
    const pos = posAttr.array;
    const base = s.basePos;
    const dentFloor = s.dentFloor ?? 0.45;
    const meanLift = meanDent * 0.2;
    for (let i = 0; i < n; i++) {
      const o = i * 3;
      let factor = 1 - amt[i] + meanLift;
      if (factor > MAX_BULGE) factor = MAX_BULGE;
      if (factor < dentFloor) factor = dentFloor;
      pos[o] = base[o] * factor;
      pos[o + 1] = base[o + 1] * factor;
      pos[o + 2] = base[o + 2] * factor;
    }
    posAttr.needsUpdate = true;
    s.normalsFrameToggle = !s.normalsFrameToggle;
    if (s.normalsFrameToggle) computeNormals(s);

    if (!s.dentTargetActive && motion < REST_EPS) {
      settleToRest(s);
      meanDent = 0;
    }
  }

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

// Memoized so a parent re-render triggered by unrelated state (coin counters,
// timers, etc.) doesn't force React to reconcile this subtree — the per-frame
// squish physics already runs in useFrame and shouldn't compete with that.
const SquishyToy = memo(forwardRef(function SquishyToy({ creatureId = '0', modelUrl, visual, onSquish, onRelease }, ref) {
  const { camera, gl, scene } = useThree();
  const toyRef = useRef(null);
  const raycaster = useMemo(() => new THREE.Raycaster(), []);
  const [built, setBuilt] = useState(null);

  useEffect(() => {
    const envTex = getEnvironmentTexture(gl);
    if (envTex) scene.environment = envTex;
  }, [gl, scene]);

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
        applyDentScale(s, 1);
        s.globalSquashTarget = 0.55;
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
    applyPendingMove(s, camera, raycaster);
    tickPhysics(s, clamp(delta, 0, 0.05));
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
