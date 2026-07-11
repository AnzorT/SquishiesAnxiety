import React, { forwardRef, useEffect, useImperativeHandle, useMemo, useRef } from 'react';
import { useFrame, useThree } from '@react-three/fiber';
import * as THREE from 'three';

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
];

const clamp = (v, lo, hi) => Math.max(lo, Math.min(hi, v));

function buildToy(colorDefs, startIndex, strength) {
  const group = new THREE.Group();

  const widthSeg = 44;
  const heightSeg = 30;
  const geo = new THREE.SphereGeometry(1, widthSeg, heightSeg);
  const posAttr = geo.attributes.position;
  const colCount = widthSeg + 1;
  const rowCount = heightSeg + 1;
  const count = posAttr.count;

  const lobeDeg = [0, 72, 144, 216, 288];
  const dir = new THREE.Vector3();
  const downVec = new THREE.Vector3(0, -1, 0);
  for (let i = 0; i < count; i++) {
    const x = posAttr.getX(i);
    const y = posAttr.getY(i);
    const z = posAttr.getZ(i);
    dir.set(x, y, z).normalize();
    const downDot = dir.dot(downVec);
    const azim = Math.atan2(z, x);
    let bump = 0;
    if (downDot > 0.1) {
      for (const Ldeg of lobeDeg) {
        const Lrad = (Ldeg * Math.PI) / 180;
        let diff = Math.abs(azim - Lrad);
        if (diff > Math.PI) diff = Math.PI * 2 - diff;
        bump += 0.22 * Math.exp(-(diff * diff) / (2 * 0.32 * 0.32)) * Math.min(1, downDot * 1.5);
      }
    }
    const scale = 1 + bump;
    posAttr.setXYZ(i, x * scale, y * scale, z * scale);
  }
  geo.computeVertexNormals();

  const basePos = new Float32Array(posAttr.array);
  const vertCount = count;
  const dentAmt = new Float32Array(count);
  const dentTarget = new Float32Array(count);
  const dentVel = new Float32Array(count);

  const current = colorDefs[startIndex];
  // NOTE: MeshPhysicalMaterial (transmission/clearcoat) and the custom
  // radial-gradient ShaderMaterial were dropped in favor of plain
  // MeshStandardMaterial / MeshBasicMaterial — expo-gl's emulated GPU driver
  // on this environment is unreliable with extra shader passes and custom
  // GLSL (intermittent hangs/blank surfaces on context init). The dent
  // physics — the mandatory part — is unaffected by this material choice.
  const bodyMat = new THREE.MeshStandardMaterial({
    color: new THREE.Color(current.mid),
    roughness: 0.32,
    metalness: 0,
    transparent: true,
    opacity: 0.92,
    side: THREE.DoubleSide,
  });

  const bodyMesh = new THREE.Mesh(geo, bodyMat);
  group.add(bodyMesh);

  // highlight decal (soft specular sticker) — flat translucent circle
  const hlMat = new THREE.MeshBasicMaterial({
    color: 0xffffff,
    transparent: true,
    opacity: 0.55,
    depthWrite: false,
  });
  const hlMesh = new THREE.Mesh(new THREE.CircleGeometry(0.3, 24), hlMat);
  hlMesh.position.set(-0.42, 0.5, 0.92);
  hlMesh.rotation.set(-0.1, -0.25, 0.1);
  group.add(hlMesh);

  // eyes
  const eyeMat = new THREE.MeshStandardMaterial({ color: 0x2b2333, roughness: 0.35 });
  const eyeGeo = new THREE.SphereGeometry(0.09, 16, 16);
  const eyeL = new THREE.Mesh(eyeGeo, eyeMat);
  eyeL.position.set(-0.32, 0.28, 0.92);
  eyeL.scale.set(1, 1.25, 0.6);
  const eyeR = eyeL.clone();
  eyeR.position.set(0.32, 0.28, 0.92);
  group.add(eyeL, eyeR);
  const eyeLBase = eyeL.position.clone();
  const eyeRBase = eyeR.position.clone();

  const glintMat = new THREE.MeshBasicMaterial({ color: 0xffffff });
  const glintGeo = new THREE.SphereGeometry(0.025, 8, 8);
  const glintL = new THREE.Mesh(glintGeo, glintMat);
  glintL.position.set(-0.36, 0.33, 0.99);
  const glintR = glintL.clone();
  glintR.position.set(0.28, 0.33, 0.99);
  group.add(glintL, glintR);
  const glintLBase = glintL.position.clone();
  const glintRBase = glintR.position.clone();

  // nose (donut)
  const noseGroup = new THREE.Group();
  noseGroup.position.set(0, 0.02, 1.02);
  const noseMat = new THREE.MeshStandardMaterial({ color: new THREE.Color(current.nose), roughness: 0.4 });
  const noseTorus = new THREE.Mesh(new THREE.TorusGeometry(0.13, 0.055, 16, 32), noseMat);
  noseGroup.add(noseTorus);
  group.add(noseGroup);
  const noseBase = noseGroup.position.clone();

  const featureBases = [eyeLBase, eyeRBase, glintLBase, glintRBase, noseBase];
  const featureDentAmt = new Float32Array(featureBases.length);
  const featureDentVel = new Float32Array(featureBases.length);
  const featureDentTarget = new Float32Array(featureBases.length);

  // contact shadow — flat translucent ellipse
  const shMat = new THREE.MeshBasicMaterial({
    color: 0x5a3c82,
    transparent: true,
    opacity: 0.28,
    depthWrite: false,
  });
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
    noseMat,
    eyeL,
    eyeR,
    glintL,
    glintR,
    basePos,
    vertCount,
    colCount,
    rowCount,
    dentAmt,
    dentTarget,
    dentVel,
    featureBases,
    featureDentAmt,
    featureDentVel,
    featureDentTarget,
    strength,
    selected: startIndex,
    mode: null,
    dragStartWorld: null,
    pressLocalSmoothed: null,
    dragDistanceAccum: 0,
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
    autoRotate: true,
    idleSinceInteract: 0,
    idlePhase: Math.random() * 10,
    blinkTimer: 2 + Math.random() * 3,
    blinkAmt: 0,
    noseSquash: 0,
    noseSquashV: 0,
    noseTarget: 0,
  };
}

function applyDentAtLocalPoint(s, localPoint, depthMul) {
  const maxDent = 0.3 * s.strength * depthMul;
  const sigma = 0.26;
  for (let i = 0; i < s.vertCount; i++) {
    const bx = s.basePos[i * 3];
    const by = s.basePos[i * 3 + 1];
    const bz = s.basePos[i * 3 + 2];
    const dx = bx - localPoint.x;
    const dy = by - localPoint.y;
    const dz = bz - localPoint.z;
    const d2 = dx * dx + dy * dy + dz * dz;
    const fall = Math.exp(-d2 / (2 * sigma * sigma));
    s.dentTarget[i] = maxDent * fall;
  }
  const featureSigma = 0.3;
  for (let j = 0; j < s.featureBases.length; j++) {
    const b = s.featureBases[j];
    const dx = b.x - localPoint.x;
    const dy = b.y - localPoint.y;
    const dz = b.z - localPoint.z;
    const d2 = dx * dx + dy * dy + dz * dz;
    const fall = Math.exp(-d2 / (2 * featureSigma * featureSigma));
    s.featureDentTarget[j] = maxDent * fall * 0.4;
  }
}

function resetDentTargets(s) {
  s.dentTarget.fill(0);
  s.featureDentTarget.fill(0);
}

function raycastHit(s, camera, raycaster, ndcX, ndcY) {
  raycaster.setFromCamera({ x: ndcX, y: ndcY }, camera);
  const hits = raycaster.intersectObjects([s.bodyMesh, s.noseTorus], false);
  return hits.length ? hits[0] : null;
}

function tickPhysics(s, dt) {
  const k = dt * 60;

  s.idlePhase += 0.016 * k;
  s.idleSinceInteract += dt;
  if (s.idleSinceInteract > 1.6 && !s.mode) s.autoRotate = true;

  s.blinkTimer -= dt;
  if (s.blinkTimer <= 0 && s.blinkAmt <= 0.01) {
    s.blinkAmt = 1;
    s.blinkTimer = 2.5 + Math.random() * 3.5;
  }
  s.blinkAmt = Math.max(0, s.blinkAmt - 0.09 * k);

  const dentStiff = 1 - Math.pow(1 - 0.14, k);
  const dentDamp = Math.pow(0.8, k);
  for (let i = 0; i < s.vertCount; i++) {
    s.dentVel[i] += (s.dentTarget[i] - s.dentAmt[i]) * dentStiff;
    s.dentVel[i] *= dentDamp;
    s.dentAmt[i] += s.dentVel[i];
  }

  const prev = s.dentAmt.slice();
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
      s.dentAmt[idx] += ((left + right - 2 * prev[idx]) + (up + down - 2 * prev[idx])) * diffCoef;
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
  s.bodyGeo.computeVertexNormals();

  for (let j = 0; j < s.featureBases.length; j++) {
    s.featureDentVel[j] += (s.featureDentTarget[j] - s.featureDentAmt[j]) * dentStiff;
    s.featureDentVel[j] *= dentDamp;
    s.featureDentAmt[j] += s.featureDentVel[j];
    const factor = clamp(1 - s.featureDentAmt[j] + meanDent * 0.2, 0.92, 1.05);
    const b = s.featureBases[j];
    if (j === 0) s.eyeL.position.set(b.x * factor, b.y * factor, b.z * factor);
    if (j === 1) s.eyeR.position.set(b.x * factor, b.y * factor, b.z * factor);
    if (j === 2) s.glintL.position.set(b.x * factor, b.y * factor, b.z * factor);
    if (j === 3) s.glintR.position.set(b.x * factor, b.y * factor, b.z * factor);
    if (j === 4) s.noseGroup.position.set(b.x * factor, b.y * factor, b.z * factor);
  }

  const squashStiff = 1 - Math.pow(1 - 0.15, k);
  const squashDamp = Math.pow(0.78, k);
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

  if (s.mode !== 'orbit') {
    const orbitDecay = Math.pow(0.93, k);
    s.orbitVelY *= orbitDecay;
    s.orbitVelX *= orbitDecay;
    s.orbitTargetY += s.orbitVelY * k;
    s.orbitTargetX = clamp(s.orbitTargetX + s.orbitVelX * k, -0.9, 0.9);
  }
  if (s.autoRotate) s.orbitTargetY += 0.0026 * k;
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
  const ns = 1 - s.noseSquash * 0.35;
  s.noseGroup.scale.set(ns, ns, ns);

  const blinkScale = 1 - s.blinkAmt * 0.88;
  s.eyeL.scale.y = 1.25 * blinkScale;
  s.eyeR.scale.y = 1.25 * blinkScale;
}

const SquishyToy = forwardRef(function SquishyToy({ startingColorIndex = 0, strength = 1, onSquish, onRelease, onStick, onBoop }, ref) {
  const { camera } = useThree();
  const toyRef = useRef(null);
  const raycaster = useMemo(() => new THREE.Raycaster(), []);

  const built = useMemo(() => buildToy(COLOR_DEFS, startingColorIndex, strength), []);
  useEffect(() => {
    toyRef.current = built;
    return () => {
      built.bodyGeo.dispose();
      built.bodyMat.dispose();
    };
  }, [built]);

  useImperativeHandle(
    ref,
    () => ({
      colorDefs: COLOR_DEFS,
      pointerDown: (ndcX, ndcY) => {
        const s = toyRef.current;
        if (!s) return;
        s.dragDistanceAccum = 0;
        s.autoRotate = false;
        const hit = raycastHit(s, camera, raycaster, ndcX, ndcY);
        if (hit && hit.object === s.noseTorus) {
          s.mode = 'nose';
          s.noseTarget = 1;
          onBoop && onBoop();
        } else if (hit) {
          s.mode = 'poke';
          const local = s.bodyMesh.worldToLocal(hit.point.clone());
          s.dragStartWorld = local;
          applyDentAtLocalPoint(s, local, 1);
          s.globalSquashTarget = 0.32;
          onSquish && onSquish(0.55);
        } else {
          s.mode = 'orbit';
        }
      },
      pointerMove: (ndcX, ndcY, dxScreen, dyScreen) => {
        const s = toyRef.current;
        if (!s || !s.mode) return;
        if (s.mode === 'orbit') {
          s.orbitVelY = s.orbitVelY * 0.55 + dxScreen * 0.009 * 0.45;
          s.orbitVelX = s.orbitVelX * 0.55 + dyScreen * 0.009 * 0.45;
          s.orbitTargetY += s.orbitVelY;
          s.orbitTargetX = clamp(s.orbitTargetX + s.orbitVelX, -0.9, 0.9);
        } else if (s.mode === 'poke') {
          const hit = raycastHit(s, camera, raycaster, ndcX, ndcY);
          let local;
          if (hit && hit.object === s.bodyMesh) {
            local = s.bodyMesh.worldToLocal(hit.point.clone());
          } else {
            local = s.dragStartWorld;
          }
          if (!local) return;
          if (!s.pressLocalSmoothed) s.pressLocalSmoothed = local.clone();
          s.pressLocalSmoothed.lerp(local, 0.55);
          s.dragStartWorld = local;
          applyDentAtLocalPoint(s, s.pressLocalSmoothed, 1);
          const dist = Math.hypot(dxScreen, dyScreen);
          s.dragDistanceAccum += dist;
          if (s.dragDistanceAccum > 16) {
            s.dragDistanceAccum = 0;
            onStick && onStick();
          }
        }
      },
      pointerUp: () => {
        const s = toyRef.current;
        if (!s) return;
        if (s.mode === 'poke') {
          resetDentTargets(s);
          s.globalSquashTarget = 0;
          s.wobbleRotXV += clamp((Math.random() - 0.5) * 0.5, -0.3, 0.3);
          s.wobbleRotZV += clamp((Math.random() - 0.5) * 0.5, -0.3, 0.3);
          onRelease && onRelease(0.55);
          s.pressLocalSmoothed = null;
        } else if (s.mode === 'nose') {
          s.noseTarget = 0;
        }
        s.mode = null;
        s.idleSinceInteract = 0;
      },
      selectColor: (i) => {
        const s = toyRef.current;
        if (!s) return;
        s.selected = i;
        const c = COLOR_DEFS[i];
        s.bodyMat.color.set(c.mid);
        s.noseMat.color.set(c.nose);
      },
    }),
    [camera, raycaster, onSquish, onRelease, onStick, onBoop]
  );

  useFrame((_, delta) => {
    const s = toyRef.current;
    if (!s) return;
    const dt = clamp(delta, 0, 0.05);
    tickPhysics(s, dt);
  });

  return (
    <>
      <primitive object={built.group} />
      <primitive object={built.shadowMesh} />
    </>
  );
});

export default SquishyToy;
