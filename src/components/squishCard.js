// The squish game's creature since REDESIGN_V6 step 4: the design's "card"
// ("ASMR Creature Squash v5" buildCard). A 2.5-unit plane, 40×40 segments,
// domed a little toward the viewer, carries the creature's front art, and a
// mirrored copy (the same plane turned half round) carries its back art, so
// spinning it shows the back. Both are one mesh over one texture — the atlas
// tools/rig/cards.mjs renders (front left, back right), at the catalog doc's
// `card.url` — so the squish (SquishyToy's vertex-shader dents, pick grid and
// springs) works on it exactly as on a 3D model.
//
// On top of the squish it moves like the design's: every 3 s it steps
// through idle, dance, idle, happy, idle, clean, idle, spin, with the
// creature's own move curves (src/squad/cardMoves.js); it reacts with
// `happy` for 1.6 s after a squish; it sways gently while nobody touches it;
// its squash springs are its own; and its growth stage scales it (Baby
// smaller and rounder), with a crown and a gold glow at Best Friend.
import * as THREE from 'three';
import * as FileSystem from 'expo-file-system';
import CARD_MOVES from '../squad/cardMoves';
import { STAGE_FX } from '../squad/data';

export const CARD_W = 2.5;
const SEG = 40;
const DOME = 0.07;
const DEG = Math.PI / 180;
// the dent for a flat card: shallower than a 3D body's (MODEL_TUNING)
export const CARD_TUNING = { visual: CARD_W, dentDepth: 0.36, dentRadius: 0.3, dentTip: 0.05, fallbackColor: '#ffffff' };

// The front and back planes. Grid point (x, y) on the front has uv (u, v) in
// the left half; its back twin sits at (-x, y, -z) (the plane turned 180°
// about y), with the same (u, v) in the right half, so the back art reads
// the right way round from behind. Same winding: both face outward.
export function cardGeometryData() {
  const n = SEG + 1;
  const half = CARD_W / 2;
  const vertCount = n * n * 2;
  const pos = new Float32Array(vertCount * 3);
  const uv = new Float32Array(vertCount * 2);
  for (let r = 0; r <= SEG; r++) {
    for (let c = 0; c <= SEG; c++) {
      const x = -half + (c / SEG) * CARD_W;
      const y = half - (r / SEG) * CARD_W;
      const nx = x / half;
      const ny = y / half;
      const z = DOME * Math.max(0, 1 - (nx * nx + ny * ny) * 0.5);
      const i = r * n + c;
      const j = n * n + i;
      pos.set([x, y, z], i * 3);
      pos.set([-x, y, -z], j * 3);
      uv.set([(c / SEG) * 0.5, 1 - r / SEG], i * 2);
      uv.set([0.5 + (c / SEG) * 0.5, 1 - r / SEG], j * 2);
    }
  }
  const index = new Uint32Array(SEG * SEG * 6 * 2);
  let k = 0;
  for (const off of [0, n * n]) {
    for (let r = 0; r < SEG; r++) {
      for (let c = 0; c < SEG; c++) {
        const a = off + r * n + c;
        const b = a + 1;
        const d = a + n;
        const e = d + 1;
        index.set([a, d, b, d, e, b], k);
        k += 6;
      }
    }
  }
  const geo = new THREE.BufferGeometry();
  geo.setAttribute('position', new THREE.BufferAttribute(pos, 3));
  geo.setIndex(new THREE.BufferAttribute(index, 1));
  geo.computeVertexNormals();
  const normals = new Float32Array(geo.attributes.normal.array);
  geo.dispose();
  return { basePos: pos, baseNormals: normals, uvArray: uv, indexArray: index, vertCount };
}

// The atlas, downloaded once to the cache (like the GLBs), as a texture.
// PNG: expo-gl decodes texture files with stb_image, which reads no WebP.
const texturePromises = new Map();
export function loadCardTexture(url) {
  if (!texturePromises.has(url)) {
    texturePromises.set(
      url,
      (async () => {
        const dir = `${FileSystem.cacheDirectory}creatureCards/`;
        let h = 5381;
        for (let i = 0; i < url.length; i++) h = ((h << 5) + h) ^ url.charCodeAt(i);
        const path = `${dir}${(h >>> 0).toString(36)}.png`;
        let uri = url;
        try {
          const info = await FileSystem.getInfoAsync(path);
          if (!info.exists) {
            await FileSystem.makeDirectoryAsync(dir, { intermediates: true }).catch(() => {});
            await FileSystem.downloadAsync(url, path);
          }
          uri = path;
        } catch (e) {
          // the loader fetches the URL itself
        }
        const tex = await new Promise((resolve, reject) => new THREE.TextureLoader().load(uri, resolve, undefined, reject));
        // plain data: the card's shader decodes the sRGB itself (CARD_FRAGMENT)
        tex.colorSpace = THREE.NoColorSpace;
        return tex;
      })(),
    );
    // a failed download may be retried next time
    texturePromises.get(url).catch(() => texturePromises.delete(url));
  }
  return texturePromises.get(url);
}

// The card's material: mostly the art itself (emissive, so it keeps the flat
// drawing's colours, as the design's does), plus a dimmed lit part so the
// dents shade; cut out on its alpha. Not tone-mapped: the stage's Neutral
// tone mapping and strong fill light (tuned for the 3D models) washed the
// art out to near white. The design's own numbers (map lit at full, emissive
// 0.45, three r128's lights) don't carry over to three 0.166's lights.
export const CARD_LOOK = { lit: 0.3, self: 0.7 };
export function cardMaterial(map) {
  const mat = new THREE.MeshStandardMaterial({
    map,
    color: new THREE.Color(CARD_LOOK.lit, CARD_LOOK.lit, CARD_LOOK.lit),
    emissive: new THREE.Color('#ffffff'),
    emissiveMap: map,
    emissiveIntensity: CARD_LOOK.self,
    roughness: 0.85,
    metalness: 0,
    alphaTest: 0.5,
    side: THREE.FrontSide,
    toneMapped: false,
  });
  mat.userData.cardDecode = true;
  return mat;
}

// expo-gl uploads an image file as plain RGBA whatever internal format three
// asks for, so an sRGB texture is never decoded and the art came out pale
// (its colours encoded to sRGB twice). The card's shader decodes both of its
// texture reads itself, with three's own inline formula (its video-texture
// path). SquishyToy's installSquishShader applies these.
const DECODE = (v) => `${v} = vec4( mix( pow( ${v}.rgb * 0.9478672986 + vec3( 0.0521327014 ), vec3( 2.4 ) ), ${v}.rgb * 0.0773993808, vec3( lessThanEqual( ${v}.rgb, vec3( 0.04045 ) ) ) ), ${v}.w );`;
export const CARD_FRAGMENT = {
  '#include <map_fragment>': `#ifdef USE_MAP
  vec4 sampledDiffuseColor = texture2D( map, vMapUv );
  ${DECODE('sampledDiffuseColor')}
  diffuseColor *= sampledDiffuseColor;
#endif`,
  '#include <emissivemap_fragment>': `#ifdef USE_EMISSIVEMAP
  vec4 emissiveColor = texture2D( emissiveMap, vEmissiveMapUv );
  ${DECODE('emissiveColor')}
  totalEmissiveRadiance *= emissiveColor.rgb;
#endif`,
};

// --- motion: the design's wave shapes (squish-rig.js wave, creatures-v2.js w2) --------
const TAU = Math.PI * 2;
function bez(x1, y1, x2, y2) {
  return (t) => {
    if (t <= 0) return 0;
    if (t >= 1) return 1;
    let u = t;
    for (let i = 0; i < 8; i++) {
      const x = 3 * (1 - u) * (1 - u) * u * x1 + 3 * (1 - u) * u * u * x2 + u * u * u - t;
      const dx = 3 * (1 - u) * (1 - u) * x1 + 6 * (1 - u) * u * (x2 - x1) + 3 * u * u * (1 - x2);
      if (Math.abs(dx) < 1e-6) break;
      u = Math.min(1, Math.max(0, u - x / dx));
    }
    return 3 * (1 - u) * (1 - u) * u * y1 + 3 * (1 - u) * u * u * y2 + u * u * u;
  };
}
const SOFT = bez(0.45, 0, 0.55, 1);
function wave(c, t) {
  const [b, a, P, ph = 0, sh = 'sin', ex] = c;
  const u = t / P + ph;
  if (sh === 'sq') return b + (a * Math.tanh(4 * Math.sin(TAU * u))) / Math.tanh(4);
  if (sh === 'hop2') {
    const x = (t % P) / P;
    return x < 0.5 ? b + a * Math.abs(Math.sin(TAU * x * 2)) : b;
  }
  if (sh === 'sin') return b + a * Math.sin(TAU * u);
  if (sh === 'cos') return b + a * Math.cos(TAU * u);
  if (sh === 'hop') return b + a * Math.abs(Math.sin(Math.PI * u));
  if (sh === 'spin' || sh === 'pulse') {
    const x = (t % P) / P;
    if (x < ex.start || x > ex.end) return b;
    const v = (x - ex.start) / (ex.end - ex.start);
    return sh === 'spin' ? b + a * SOFT(v) : b + a * Math.sin(Math.PI * v);
  }
  if (sh === 'spinsq') {
    const x = (t % P) / P;
    let f = 0;
    if (x < 0.2) f = -Math.sin((Math.PI * x) / 0.2);
    else if (x < 0.7) f = 0.7 * Math.sin((Math.PI * (x - 0.2)) / 0.5);
    else if (x < 0.9) f = -1.2 * Math.sin((Math.PI * (x - 0.7)) / 0.2);
    return b + a * f;
  }
  if (sh === 'shake') {
    const x = (t % P) / P;
    return x >= ex.win ? b : b + a * Math.sin((TAU * t) / ex.sub) * Math.sin((Math.PI * x) / ex.win);
  }
  return b;
}

const clamp = (v, lo, hi) => Math.max(lo, Math.min(hi, v));

// The card's own state, merged into SquishyToy's: moves, springs, stage, and
// the crown and glow meshes (added to the group).
export function cardState(id, stage, group) {
  const data = CARD_MOVES[String(id)] || { head: 20, moves: null, sq: null };
  const q = data.sq || {};
  const fx = STAGE_FX[stage] || STAGE_FX[1];
  let glowMesh = null;
  const extras = [];
  if (fx.crown) {
    const crownTex = new THREE.TextureLoader().load(require('../../assets/squad/crown.png'));
    crownTex.colorSpace = THREE.SRGBColorSpace;
    const crown = new THREE.Mesh(new THREE.PlaneGeometry(0.62, 0.465), new THREE.MeshBasicMaterial({ map: crownTex, transparent: true, alphaTest: 0.1, side: THREE.DoubleSide }));
    crown.position.set(0.2, ((50 - data.head) / 100) * CARD_W + 0.17, 0.12);
    crown.rotation.z = -0.22;
    group.add(crown);
    glowMesh = new THREE.Mesh(new THREE.CircleGeometry(1.35, 48), new THREE.MeshBasicMaterial({ color: 0xffd24a, transparent: true, opacity: 0.22, depthWrite: false }));
    glowMesh.position.set(0, 0, -0.25);
    group.add(glowMesh);
    extras.push(crown, glowMesh);
  }
  return {
    card: true,
    moves: data.moves,
    seed: Math.random() * 10000,
    reactT: 0,
    stK: [fx.sx, fx.sy],
    stY: -(1 - fx.sy) * CARD_W * 0.46,
    glowMesh,
    cardExtras: extras,
    mv: { sx: 1, sy: 1, rot: 0, tx: 0, ty: 0, spin: 0 },
    sqSt: clamp((q.k || 500) / 1250, 0.15, 0.75),
    sqDp: clamp(0.92 - (q.z || 0.32) * 0.6, 0.6, 0.9),
    sqX: 0.14 * ((q.x || 0.2) / 0.2),
    sqY: 0.26 * ((q.y || 0.26) / 0.26),
    sqR: q.r || 0,
  };
}

// Idle sway while untouched (the design's orbit target), before the group's
// rotation is set.
export function cardSway(s) {
  if (s.mode === null) s.orbitTargetY = Math.sin(s.idlePhase * 0.08) * 0.35;
}

const SEQ = ['idle', 'dance', 'idle', 'happy', 'idle', 'clean', 'idle', 'spin'];
// After the group's squash/rotation are set: the move cycle on top.
export function cardMotion(s, k, sx, sy, sz) {
  const M = s.moves;
  const now = Date.now();
  const react = s.reactT && now - s.reactT < 1600;
  const cyT = now + s.seed;
  const cyU = (cyT % 3000) / 3000;
  const cyM = react ? 'happy' : SEQ[Math.floor(cyT / 3000) % SEQ.length];
  const ch = !M || s.mode === 'poke' ? null : cyM === 'clean' ? null : cyM === 'spin' ? M.happy || M.idle : M[cyM] || M.idle;
  const v = { sx: 1, sy: 1, rot: 0, tx: 0, ty: 0, spin: 0 };
  if (ch) {
    const t = react ? now - s.reactT : now + s.seed;
    for (const key in ch) if (key in v && key !== 'spin') v[key] = wave(ch[key], t);
  }
  if (!react && s.mode !== 'poke' && M && cyM === 'clean') {
    v.rot = 7 * Math.sin(now / 230);
    v.ty = -4 * Math.abs(Math.sin(now / 230));
    v.sx = 1 + 0.03 * Math.sin(now / 115);
  }
  let cySpin = 0;
  if (!react && s.mode !== 'poke' && cyM === 'spin') {
    const e = Math.min(1, cyU / 0.5);
    cySpin = 360 * (e * e * (3 - 2 * e));
    v.ty = -18 * Math.sin(Math.PI * Math.min(1, cyU / 0.5));
  }
  const w = Math.min(1, 0.18 * k);
  const fast = Math.min(1, 0.45 * k);
  for (const key in v) s.mv[key] += (v[key] - s.mv[key]) * (react || !ch ? fast : w);
  s.group.position.set(s.mv.tx * 0.012, -s.mv.ty * 0.012 + s.stY, 0);
  if (s.glowMesh) s.glowMesh.material.opacity = 0.16 + 0.1 * Math.sin(now / 420);
  s.group.rotation.y += Math.sin(s.idlePhase * 0.2) * 0.03 + (s.mv.spin + cySpin) * DEG;
  s.group.rotation.z += -(s.mv.rot + s.sqR * s.globalSquash) * DEG;
  const K = s.stK;
  s.group.scale.set(sx * s.mv.sx * K[0], sy * s.mv.sy * K[1], sz * s.mv.sx * K[0]);
}
