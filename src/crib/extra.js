// What the Crib has beyond the design's catalogue (catalog.js, generated from
// "Squad Crib v5"), so every room can start out cheap and grow into a
// fancy one (the user's 2026-10-03 rulings):
//
//  · CHEAP — a new first tier for each furniture slot, made from what's
//    lying around: a couch of cardboard boxes, an old TV on a box, a picnic
//    cooler, a washtub, mattresses on the floor, a boombox on a crate, box
//    speakers, a bare bulb, a taped-off square to dance on. The design's
//    tiers move up one.
//  · NEW_SLOTS — the kitchen's snack table (a crate table first; the
//    design's table was part of the room's picture), a rug and a ceiling
//    lamp per room, each in tiers from nothing / a bare bulb up to royal.
//  · THEME_EXTRA — a bare first wall / floor / ceiling (plaster, concrete)
//    before the design's own, a luxurious last one, and a coin price for
//    each (they were free by level).
//  · FIXTURE_DECOR — the rooms' built-in fixtures (bookshelf, windows,
//    clock, oven, neon signs…, cut out by tools/crib-art/fixtures.mjs) as
//    decor to buy and move around.
//
// A piece is drawn from its `svg`, or from a cut-out picture named by `art`
// ('kitchen.table': fixtureArt.js — kept out of here so the rules run in
// Node).
//
// Everything here is in the design's scene units (852×393) and drawing style
// (#5b3a29 outlines, flat fills). home.js merges it into the catalogue.

import { FIXTURE_GEO } from './fixtureGeo.js';

const INK = '#5b3a29';
const S = (w, h, body) => `<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 ${w} ${h}">${body}</svg>`;
const st = (w = 3) => `stroke="${INK}" stroke-width="${w}" stroke-linejoin="round" stroke-linecap="round"`;

// ---- cardboard and crates ------------------------------------------------------
const CARD = '#d6a96c';
const CARD2 = '#c4955a';
const TAPE = '#f1e3bd';
// a cardboard box: front face, its top flaps, a strip of tape
const box = (x, y, w, h, c = CARD) =>
  `<rect x="${x}" y="${y}" width="${w}" height="${h}" rx="3" fill="${c}" ${st()}/>` +
  `<rect x="${x + w / 2 - 6}" y="${y + 1.5}" width="12" height="${h - 3}" fill="${TAPE}" opacity="0.85"/>` +
  `<path d="M${x + 6} ${y + h - 10} h10 M${x + 6} ${y + h - 16} h6" ${st(2)} opacity="0.5"/>`;
const crate = (x, y, w, h) =>
  `<rect x="${x}" y="${y}" width="${w}" height="${h}" rx="2" fill="#c9925a" ${st()}/>` +
  `<path d="M${x} ${y + h / 3} H${x + w} M${x} ${y + (2 * h) / 3} H${x + w}" ${st(2)}/>` +
  `<path d="M${x + 4} ${y + 4} L${x + w - 4} ${y + h - 4}" ${st(2)} opacity="0.55"/>`;
const bulb = (x, len, glow = '#fff3b0') =>
  `<path d="M${x} 0 V${len}" ${st(2)}/><rect x="${x - 4}" y="${len - 2}" width="8" height="8" rx="1.5" fill="#7d7d84" ${st(2)}/>` +
  `<circle cx="${x}" cy="${len + 14}" r="8" fill="${glow}" ${st(2)}/><path d="M${x - 3} ${len + 11} q3 -3 6 0" stroke="#ffffff" stroke-width="2" fill="none"/>`;

// ---- the cheap tiers (scene positions match the design's first tier) -------------
const BOX_COUCH_BACK = S(188, 92, box(6, 26, 84, 64, CARD) + box(98, 34, 84, 56, CARD2) + `<path d="M6 26 L18 12 L94 12 L90 26" fill="#e4bd84" ${st(2.5)}/>`);
// (its seat — the folded blanket — starts where the design's sofas' do, 48
// down, so whoever sits on it shows down to the cushion)
const BOX_COUCH_FRONT = S(
  232,
  82,
  box(16, 58, 100, 22, CARD) +
    box(116, 58, 100, 22, CARD2) +
    `<rect x="26" y="46" width="180" height="16" rx="8" fill="#9fb6c8" ${st()}/>` +
    `<rect x="132" y="48" width="22" height="11" rx="2" fill="#e8c26b" ${st(2)} transform="rotate(-6 143 53)"/>` +
    `<path d="M44 54 h8 M60 54 h8 M76 54 h8" stroke="#6f8696" stroke-width="2" stroke-linecap="round"/>`
);
// seen from behind, like the design's TVs: the screen faces the sofa
const BOX_TV = S(
  200,
  180,
  box(40, 112, 120, 64, CARD) +
    `<path d="M88 66 L70 26 M112 66 L128 30 L140 36" ${st(2.5)} fill="none"/><circle cx="70" cy="25" r="4.5" fill="#d9d9d9" ${st(2)}/>` +
    `<path d="M74 70 H126 L140 84 V108 Q140 114 134 114 H66 Q60 114 60 108 V84 Z" fill="#8f8a86" ${st()}/>` +
    `<path d="M80 86 h40 M80 94 h40 M80 102 h40" stroke="#6a6562" stroke-width="3" stroke-linecap="round"/>` +
    `<path d="M118 112 q-4 16 8 24 q10 6 4 18" stroke="#2a2a33" stroke-width="3" fill="none" stroke-linecap="round"/>`
);
const COOLER = S(
  70,
  110,
  `<rect x="4" y="60" width="62" height="46" rx="6" fill="#5fb6dc" ${st()}/>` +
    `<rect x="2" y="52" width="66" height="14" rx="5" fill="#f4f4f4" ${st()}/>` +
    `<path d="M18 52 Q35 38 52 52" ${st(3)} fill="none"/><circle cx="35" cy="84" r="8" fill="#ffd66b" ${st(2)}/>`
);
const WASHTUB = S(
  280,
  112,
  `<path d="M10 30 H270 L252 104 H28 Z" fill="#b8c4cc" ${st()}/>` +
    `<path d="M16 56 H264 M22 80 H258" stroke="#8f9ba3" stroke-width="2.5"/><path d="M60 40 q8 10 0 20" stroke="#dfe6ea" stroke-width="3" fill="none"/>` +
    `<rect x="4" y="20" width="272" height="16" rx="8" fill="#d6dee3" ${st()}/>` +
    `<rect x="16" y="24" width="248" height="8" rx="4" fill="#a9cbd6"/>` +
    `<path d="M2 28 h-0 M30 104 v6 M250 104 v6" ${st(3)}/>`
);
const MAT_BACK = S(
  184,
  170,
  `<rect x="18" y="80" width="148" height="62" rx="4" fill="${CARD}" ${st()} transform="rotate(-3 92 111)"/>` +
    `<rect x="84" y="82" width="12" height="58" fill="${TAPE}" opacity="0.8" transform="rotate(-3 92 111)"/>` +
    `<rect x="8" y="134" width="168" height="34" rx="9" fill="#e9dfc7" ${st()}/>` +
    `<rect x="24" y="118" width="56" height="26" rx="11" fill="#efe9dd" ${st(2.5)}/><rect x="104" y="118" width="56" height="26" rx="11" fill="#efe9dd" ${st(2.5)}/>` +
    `<ellipse cx="140" cy="152" rx="12" ry="5" fill="#d2c39f" opacity="0.8"/>`
);
// A bed's blanket (drawn in front of the sleepers): pulled up over the
// mattress to just under the pillows, its top folded back into a white sheet
// hem, the sides draping — so whoever sleeps there is tucked in to the chin.
// The design's own blanket was a strip under the mattress, which read as a
// second mattress. One per tier, in the tier's colours (crib-home.js BEDC).
const BLANKET = [
  { fill: '#8fa9b8', patch: true },
  { fill: '#e8d6b8' },
  { fill: '#ffe3a3', check: '#ffb3c7' },
  { fill: '#b7a0e6', dots: '#ffffff' },
  { fill: '#9fd8f0', swirl: '#ffffff' },
  { fill: '#6a3fb0', gold: '#ffd66b' },
];
export const BLANKET_W = 188;
export const BLANKET_H = 44;
export function blanketSvg(tier) {
  const B = BLANKET[Math.max(0, Math.min(BLANKET.length - 1, tier))];
  const body = 'M6 10 Q6 5 12 5 H176 Q182 5 182 10 V35 Q182 42 174 42 H14 Q6 42 6 35 Z';
  let deco = '';
  if (B.check) deco = `<defs><pattern id="c" width="20" height="20" patternUnits="userSpaceOnUse"><rect width="20" height="20" fill="${B.fill}"/><rect width="10" height="10" fill="${B.check}"/><rect x="10" y="10" width="10" height="10" fill="${B.check}"/></pattern></defs><path d="${body}" fill="url(#c)"/>`;
  if (B.dots) deco = [30, 62, 96, 128, 160].map((x, k) => `<circle cx="${x}" cy="${24 + (k % 2) * 9}" r="3" fill="${B.dots}"/>`).join('');
  if (B.swirl) deco = `<path d="M30 30 q8 -10 16 0 q8 -8 14 2 M112 24 q8 -10 16 0 q8 -8 14 2" stroke="${B.swirl}" stroke-width="3" fill="none" stroke-linecap="round"/>`;
  if (B.gold) deco = `<path d="M8 32 H180" stroke="${B.gold}" stroke-width="4"/>`;
  if (B.patch) deco = `<rect x="122" y="20" width="18" height="12" rx="2" fill="#e8a37a" ${st(2)}/>`;
  return S(
    BLANKET_W,
    BLANKET_H,
    `<path d="${body}" fill="${B.fill}" ${st()}/>${deco}<path d="M22 16 q-4 12 0 24 M166 16 q4 12 0 24" stroke="${INK}" stroke-width="2" fill="none" opacity="0.22" stroke-linecap="round"/>` +
      `<path d="${body}" fill="none" ${st()}/><rect x="4" y="2" width="180" height="11" rx="5.5" fill="#ffffff" ${st(2.5)}/>`
  );
}
// where a bed's blanket goes (scene units), from its back piece; the floor
// mattress lies lower than the design's beds
export const blanketAt = (back, tier) => ({ x: back.x - 2, y: tier === 0 ? 274 : 258, w: BLANKET_W, h: BLANKET_H });
// where its two sleepers' feet go (the scene's spots; each sleeper is then
// placed by its own mouth: home.js sleeperY)
export const SLEEPER_Y = (tier) => (tier === 0 ? 300 : 285);
// the blanket's top edge (its hem), scene units
export const blanketTop = (tier) => blanketAt({ x: 0 }, tier).y + 2;
const TAPE_FLOOR = S(200, 172, `<rect x="6" y="20" width="188" height="146" rx="6" fill="rgba(0,0,0,0.12)" stroke="#e8c547" stroke-width="7" stroke-dasharray="26 8"/>`);
const BOOMBOX = S(
  130,
  68,
  crate(25, 36, 80, 30) +
    `<path d="M44 10 Q65 0 86 10" ${st(3)} fill="none"/><rect x="20" y="8" width="90" height="30" rx="7" fill="#4a4a58" ${st()}/>` +
    `<circle cx="38" cy="23" r="9" fill="#2a2a33" ${st(2)}/><circle cx="92" cy="23" r="9" fill="#2a2a33" ${st(2)}/><rect x="54" y="16" width="22" height="10" rx="2" fill="#9fd8c0" ${st(2)}/>`
);
const BOX_SPEAKER = S(40, 52, `<rect x="2" y="2" width="36" height="48" rx="3" fill="${CARD}" ${st()}/><circle cx="20" cy="31" r="10" fill="none" ${st(2.5)} stroke-dasharray="4 3"/><circle cx="20" cy="12" r="4" fill="none" ${st(2)}/>`);
const BARE_BULB = S(20, 64, bulb(10, 40));

const tier0 = (slot, name, effect, o) => ({ id: `${slot}0`, tier: 0, name, lvl: 1, coins: 0, usd: 0, effect, back: [], front: [], ...o });
export const CHEAP = {
  sofa: tier0('sofa', 'Box Couch', '2 seats for TV time', {
    icon: S(232, 116, `<svg x="22" y="0" width="188" height="92" viewBox="0 0 188 92">${BOX_COUCH_BACK.replace(/^<svg[^>]*>|<\/svg>$/g, '')}</svg><svg x="0" y="34" width="232" height="82" viewBox="0 0 232 82">${BOX_COUCH_FRONT.replace(/^<svg[^>]*>|<\/svg>$/g, '')}</svg>`),
    back: [{ svg: BOX_COUCH_BACK, x: 632, y: 146, w: 188, h: 92 }],
    front: [{ svg: BOX_COUCH_FRONT, x: 610, y: 180, w: 232, h: 82 }],
    seats: [
      { x: 694, y: 238 },
      { x: 758, y: 238 },
    ],
  }),
  tv: tier0('tv', 'Box TV', 'Fuzzy picture, slow rest', { icon: BOX_TV, front: [{ svg: BOX_TV, x: 531, y: 206, w: 200, h: 180 }] }),
  fridge: tier0('fridge', 'Picnic Cooler', 'Keeps 3 snacks cold', { icon: COOLER, back: [{ svg: COOLER, x: 20, y: 128, w: 70, h: 110 }] }),
  tub: tier0('tub', 'Washtub', '3 seats · slow wash', {
    icon: WASHTUB,
    front: [{ svg: WASHTUB, x: 286, y: 252, w: 280, h: 112 }],
    seats: [333, 426, 519].map((x) => ({ x, y: 284, style: 'washtub' })),
  }),
  bed: tier0('bed', 'Floor Mattress', 'Naps up to 30 minutes', {
    icon: S(188, 212, `<svg x="2" y="0" width="184" height="170" viewBox="0 0 184 170">${MAT_BACK.replace(/^<svg[^>]*>|<\/svg>$/g, '')}</svg><svg x="0" y="136" width="188" height="44" viewBox="0 0 188 44">${blanketSvg(0).replace(/^<svg[^>]*>|<\/svg>$/g, '')}</svg>`),
    back: [38, 238, 438, 638].map((x) => ({ svg: MAT_BACK, x, y: 138, w: 184, h: 170 })),
    front: [38, 238, 438, 638].map((x) => ({ svg: blanketSvg(0), ...blanketAt({ x }, 0) })),
  }),
  floor: tier0('floor', 'Taped Square', '2 dancers · no lights', {
    icon: TAPE_FLOOR,
    back: [{ svg: TAPE_FLOOR, x: 326, y: 210, w: 200, h: 172 }],
    seats: [
      { x: 376, y: 320 },
      { x: 476, y: 320 },
    ],
  }),
  dj: tier0('dj', 'Boombox Crate', '1 song', { icon: BOOMBOX, back: [{ svg: BOOMBOX, x: 361, y: 130, w: 130, h: 68 }] }),
  speakers: tier0('speakers', 'Box Speakers', 'No effects', {
    icon: BOX_SPEAKER,
    back: [
      { svg: BOX_SPEAKER, x: 40, y: 170, w: 40, h: 52 },
      { svg: BOX_SPEAKER, x: 772, y: 170, w: 40, h: 52, tf: 'scaleX(-1)' },
    ],
  }),
  ball: tier0('ball', 'Bare Bulb', 'No effects', { icon: BARE_BULB, back: [{ svg: BARE_BULB, x: 416, y: 0, w: 20, h: 64 }], classicBall: false }),
};
// what the cheap tiers do (prepended to the catalogue's rates)
export const CHEAP_RATES = { tv: 0.12, beds: 1, fridge: ['marshmallow', 'cookie', 'carrot'], songsN: 1, drain: { speakers: 0, ball: 0 }, bath: { washtub: { mul: 0.5 } } };

// ---- the kitchen table -------------------------------------------------------------
const T = FIXTURE_GEO.kitchen.table; // the design's snack table, x 102 y 274
const CRATE_TABLE = S(T.w, T.h, crate(28, 30, 96, 58) + crate(T.w / 2 - 48, 30, 96, 58) + crate(T.w - 124, 30, 96, 58) + `<rect x="10" y="12" width="${T.w - 20}" height="20" rx="3" fill="#d8a76a" ${st()}/><path d="M${T.w / 3} 14 v16 M${(2 * T.w) / 3} 14 v16" ${st(2)}/>`);
const BANQUET = S(
  T.w,
  T.h,
  [0.18, 0.5, 0.82].map((f) => `<rect x="${T.w * f - 4}" y="6" width="8" height="14" rx="2" fill="#fff3d6" ${st(2)}/><path d="M${T.w * f} 0 q4 3 0 6 q-4 -3 0 -6" fill="#ffb347"/>`).join('') +
    `<rect x="6" y="16" width="${T.w - 12}" height="16" rx="6" fill="#fffaf0" ${st()}/>` +
    `<path d="M14 30 H${T.w - 14} V80 Q${T.w / 2} 92 14 80 Z" fill="#ffffff" ${st()}/>` +
    `<path d="M14 66 Q${T.w / 2} 80 ${T.w - 14} 66" stroke="#e8b84a" stroke-width="6" fill="none"/>` +
    `<path d="M20 40 q20 10 40 0 M${T.w - 60} 40 q20 10 40 0" stroke="#e8b84a" stroke-width="3" fill="none"/>`
);
// Seats at the table: feet 14 below the table's top edge (crate 286, snack
// table 282, banquet 290), so the table hides their lower body and they sit
// at it — the food at their mouths stays above it.
export const TABLE_TOPS = [286, 282, 290]; // per table tier (crate, snack, banquet)
const KITCHEN_SPOTS = (top) => [170, 272, 374, 476, 578, 680].map((x) => ({ x, y: top + 14 }));

// ---- rugs ----------------------------------------------------------------------------
const DOORMAT = S(150, 60, `<rect x="6" y="8" width="138" height="44" rx="6" fill="#a8743f" ${st()}/><rect x="16" y="16" width="118" height="28" rx="3" fill="none" stroke="#7d5229" stroke-width="2.5" stroke-dasharray="6 4"/><path d="M8 52 v6 M20 52 v6 M32 52 v6 M44 52 v6 M56 52 v6 M68 52 v6 M80 52 v6 M92 52 v6 M104 52 v6 M116 52 v6 M128 52 v6 M140 52 v6" ${st(2)}/>`);
const RAG_RUG = S(
  300,
  110,
  `<ellipse cx="150" cy="55" rx="146" ry="51" fill="#8fb4c9" ${st()}/><ellipse cx="150" cy="55" rx="118" ry="40" fill="#e4b96c"/><ellipse cx="150" cy="55" rx="90" ry="30" fill="#d47d6a"/><ellipse cx="150" cy="55" rx="60" ry="20" fill="#9ac08a"/><ellipse cx="150" cy="55" rx="30" ry="10" fill="#f2e2c4"/>`
);
const SHAGGY = S(
  360,
  130,
  `<ellipse cx="180" cy="65" rx="174" ry="58" fill="#ffb8d6" ${st()}/>` +
    Array.from({ length: 34 }, (_, i) => {
      const a = (i / 34) * Math.PI * 2;
      const x = 180 + Math.cos(a) * 174;
      const y = 65 + Math.sin(a) * 58;
      return `<path d="M${x.toFixed(1)} ${y.toFixed(1)} l${(Math.cos(a) * 7).toFixed(1)} ${(Math.sin(a) * 5).toFixed(1)}" stroke="#ff8fc0" stroke-width="5" stroke-linecap="round"/>`;
    }).join('') +
    `<ellipse cx="180" cy="65" rx="140" ry="44" fill="none" stroke="#ffd6e8" stroke-width="6" stroke-dasharray="3 9"/><ellipse cx="180" cy="65" rx="96" ry="28" fill="none" stroke="#ffd6e8" stroke-width="6" stroke-dasharray="3 9"/>`
);
const PERSIAN = S(
  380,
  130,
  `<rect x="6" y="6" width="368" height="118" rx="6" fill="#b8322f" ${st()}/><rect x="18" y="16" width="344" height="98" rx="3" fill="none" stroke="#f2c14e" stroke-width="5"/>` +
    `<rect x="30" y="26" width="320" height="78" rx="2" fill="#1f3f6b"/><path d="M190 32 L240 65 L190 98 L140 65 Z" fill="#f2c14e" ${st(2.5)}/><path d="M190 46 L218 65 L190 84 L162 65 Z" fill="#b8322f"/>` +
    `<circle cx="70" cy="65" r="14" fill="#f2c14e" stroke="#b8322f" stroke-width="3"/><circle cx="310" cy="65" r="14" fill="#f2c14e" stroke="#b8322f" stroke-width="3"/>` +
    Array.from({ length: 19 }, (_, i) => `<path d="M${12 + i * 20} 124 v6 M${12 + i * 20} 0 v6" stroke="#f2e2c4" stroke-width="2.5"/>`).join('')
);
const ROYAL = S(
  420,
  140,
  `<rect x="6" y="6" width="408" height="128" rx="18" fill="#6a2fc4" ${st()}/><rect x="18" y="16" width="384" height="108" rx="12" fill="none" stroke="#ffd23a" stroke-width="6"/>` +
    `<rect x="34" y="30" width="352" height="80" rx="8" fill="#8a4fe0"/>` +
    `<path d="M210 40 l10 18 h20 l-16 12 6 20 -20 -12 -20 12 6 -20 -16 -12 h20 z" fill="#ffd23a" ${st(2)}/>` +
    `<path d="M60 70 q20 -22 40 0 q20 22 40 0 M280 70 q20 -22 40 0 q20 22 40 0" stroke="#ffd23a" stroke-width="4" fill="none"/>` +
    Array.from({ length: 20 }, (_, i) => `<path d="M${16 + i * 20.5} 134 v6" stroke="#ffd23a" stroke-width="3"/>`).join('')
);
// a rug's tiers for one room, centred at (cx, cy) on its floor
const rugTiers = (room, cx, cy) => {
  const at = (w, h) => ({ x: Math.round(cx - w / 2), y: Math.round(cy - h / 2), w, h });
  const braided = FIXTURE_GEO.living.fixtures.rug;
  const t = (i, name, coins, lvl, perk, art) => ({ id: `rug_${room}${i}`, tier: i, name, lvl, coins, usd: 0, effect: perk ? `+${Math.round(perk * 100)}% room bonus` : 'Bare floor', perk, icon: art && art.svg, iconArt: art && art.art, iconAspect: art ? art.w / art.h : 1, back: art ? [art] : [], front: [] });
  return [
    t(0, 'Bare Floor', 0, 1, 0, null),
    t(1, 'Old Doormat', 120, 1, 0.01, { svg: DOORMAT, ...at(150, 60) }),
    t(2, 'Rag Rug', 300, 2, 0.02, { svg: RAG_RUG, ...at(300, 110) }),
    t(3, 'Braided Rug', 700, 3, 0.03, { art: 'living.rug', ...at(Math.round(braided.w * 0.9), Math.round(braided.h * 0.9)) }),
    t(4, 'Shaggy Rug', 1400, 5, 0.05, { svg: SHAGGY, ...at(360, 130) }),
    t(5, 'Persian Rug', 2500, 7, 0.07, { svg: PERSIAN, ...at(380, 130) }),
    t(6, 'Royal Carpet', 4000, 9, 0.1, { svg: ROYAL, ...at(420, 140) }),
  ];
};

// ---- ceiling lamps (they light the room at night) -----------------------------------
const LANTERN = S(60, 110, `<path d="M30 0 V40" ${st(2)}/><ellipse cx="30" cy="70" rx="26" ry="30" fill="#fffaf0" ${st()}/><path d="M8 58 Q30 64 52 58 M6 72 Q30 78 54 72 M10 86 Q30 92 50 86" stroke="#e6d8bc" stroke-width="2.5" fill="none"/><rect x="22" y="36" width="16" height="6" rx="2" fill="#c9925a" ${st(2)}/>`);
const DOME = S(80, 100, `<path d="M40 0 V48" ${st(2)}/><path d="M6 84 Q8 44 40 44 Q72 44 74 84 Z" fill="#5fc3b0" ${st()}/><rect x="4" y="80" width="72" height="8" rx="4" fill="#3f9d8c" ${st(2.5)}/><circle cx="40" cy="92" r="7" fill="#fff3b0" ${st(2)}/>`);
const PENDANTS = S(
  150,
  110,
  [25, 75, 125]
    .map((x, i) => {
      const len = [40, 58, 40][i];
      return `<path d="M${x} 0 V${len}" ${st(2)}/><path d="M${x - 16} ${len + 26} L${x - 8} ${len} H${x + 8} L${x + 16} ${len + 26} Z" fill="${['#ff8fb8', '#ffd66b', '#8fc4f0'][i]}" ${st(2.5)}/><circle cx="${x}" cy="${len + 30}" r="5" fill="#fff3b0" ${st(2)}/>`;
    })
    .join('')
);
const CHANDELIER = S(
  150,
  120,
  `<path d="M75 0 V36" ${st(2.5)}/><path d="M20 70 Q75 108 130 70" fill="none" stroke="#e8b84a" stroke-width="7" stroke-linecap="round"/><path d="M20 70 Q75 108 130 70" fill="none" ${st(2)}/>` +
    `<circle cx="75" cy="40" r="7" fill="#ffd23a" ${st(2)}/><path d="M75 46 V84" stroke="#e8b84a" stroke-width="5"/>` +
    [20, 52, 98, 130].map((x, i) => `<rect x="${x - 4}" y="${[52, 62, 62, 52][i]}" width="8" height="16" rx="2" fill="#fff3d6" ${st(2)}/><path d="M${x} ${[52, 62, 62, 52][i] - 10} q5 5 0 9 q-5 -4 0 -9" fill="#ffb347"/>`).join('')
);
const CRYSTAL = S(
  170,
  140,
  `<path d="M85 0 V30" ${st(2.5)}/><ellipse cx="85" cy="44" rx="58" ry="16" fill="#ffe680" ${st()}/><ellipse cx="85" cy="76" rx="40" ry="12" fill="#ffe680" ${st()}/>` +
    Array.from({ length: 9 }, (_, i) => {
      const x = 33 + i * 13;
      const y = 58 + (i % 2) * 8;
      return `<path d="M${x} ${y} l5 10 -5 10 -5 -10 z" fill="#d6f2ff" ${st(1.8)}/>`;
    }).join('') +
    Array.from({ length: 5 }, (_, i) => {
      const x = 59 + i * 13;
      return `<path d="M${x} 88 l5 12 -5 12 -5 -12 z" fill="#d6f2ff" ${st(1.8)}/>`;
    }).join('') +
    `<path d="M85 92 l7 16 -7 16 -7 -16 z" fill="#ffffff" ${st(2)}/>`
);
const lampTiers = (room, cx) => {
  const t = (i, name, coins, lvl, perk, svg, w, h, ly, r) => ({
    id: `lamp_${room}${i}`,
    tier: i,
    name,
    lvl,
    coins,
    usd: 0,
    effect: i ? `Lights the room · +${Math.round(perk * 100)}% bonus` : 'A dim light at night',
    perk,
    icon: svg,
    back: [{ svg, x: Math.round(cx - w / 2), y: 0, w, h }],
    front: [],
    light: { lx: w / 2, ly, r, c: '255,236,180' },
  });
  return [
    t(0, 'Bare Bulb', 0, 1, 0, BARE_BULB, 20, 64, 54, 70),
    t(1, 'Paper Lantern', 150, 1, 0.01, LANTERN, 60, 110, 70, 110),
    t(2, 'Ceiling Lamp', 400, 2, 0.02, DOME, 80, 100, 90, 140),
    t(3, 'Pendant Trio', 900, 4, 0.04, PENDANTS, 150, 110, 80, 170),
    t(4, 'Chandelier', 2000, 6, 0.06, CHANDELIER, 150, 120, 70, 200),
    t(5, 'Crystal Chandelier', 3500, 8, 0.08, CRYSTAL, 170, 140, 80, 230),
  ];
};

// the new slots, by key (`room` decides where they show)
export const NEW_SLOTS = {
  table: {
    key: 'table',
    room: 'kitchen',
    name: 'Snack table',
    tiers: [
      { id: 'table0', tier: 0, name: 'Crate Table', lvl: 1, coins: 0, usd: 0, effect: '6 seats at the table', icon: CRATE_TABLE, back: [], front: [{ svg: CRATE_TABLE, x: T.x, y: T.y, w: T.w, h: T.h }], seats: KITCHEN_SPOTS(286), perk: 0 },
      { id: 'table1', tier: 1, name: 'Snack Table', lvl: 1, coins: 300, usd: 0, effect: '+3% fuller meals', iconArt: 'kitchen.table', iconAspect: T.w / T.h, back: [], front: [{ art: 'kitchen.table', x: T.x, y: T.y, w: T.w, h: T.h }], seats: KITCHEN_SPOTS(282), perk: 0.03 },
      { id: 'table2', tier: 2, name: 'Banquet Table', lvl: 5, coins: 1800, usd: 0, effect: '+8% fuller meals', icon: BANQUET, back: [], front: [{ svg: BANQUET, x: T.x, y: T.y, w: T.w, h: T.h }], seats: KITCHEN_SPOTS(290), perk: 0.08 },
    ],
  },
  rug_living: { key: 'rug_living', room: 'living', name: 'Rug', tiers: rugTiers('living', 288, 312) },
  rug_kitchen: { key: 'rug_kitchen', room: 'kitchen', name: 'Rug', tiers: rugTiers('kitchen', 426, 340) },
  rug_bath: { key: 'rug_bath', room: 'bath', name: 'Bath mat', tiers: rugTiers('bath', 426, 352) },
  rug_bed: { key: 'rug_bed', room: 'bed', name: 'Rug', tiers: rugTiers('bed', 426, 352) },
  lamp_living: { key: 'lamp_living', room: 'living', name: 'Ceiling lamp', tiers: lampTiers('living', 600) },
  lamp_kitchen: { key: 'lamp_kitchen', room: 'kitchen', name: 'Ceiling lamp', tiers: lampTiers('kitchen', 600) },
  lamp_bath: { key: 'lamp_bath', room: 'bath', name: 'Ceiling lamp', tiers: lampTiers('bath', 300) },
  lamp_bed: { key: 'lamp_bed', room: 'bed', name: 'Ceiling lamp', tiers: lampTiers('bed', 560) },
};

// ---- walls, floors, ceilings -------------------------------------------------------------
// The bare first one (an SVG drawn over the room's own wall / floor /
// ceiling), the design's, and a luxurious last one. `h` is filled in per
// room by home.js (the wall's / floor's height).
const plaster = (base, crack, stain) => (w, h) =>
  S(
    w,
    h,
    `<rect width="${w}" height="${h}" fill="${base}"/>` +
      `<path d="M120 ${h * 0.18} l14 22 -8 16 16 26 M640 ${h * 0.3} l-12 18 10 14 -6 22 M410 ${h * 0.62} l18 10 6 20" stroke="${crack}" stroke-width="2.5" fill="none" stroke-linecap="round"/>` +
      `<ellipse cx="760" cy="${h * 0.22}" rx="44" ry="26" fill="${stain}" opacity="0.5"/><ellipse cx="250" cy="${h * 0.7}" rx="30" ry="16" fill="${stain}" opacity="0.4"/>` +
      `<rect y="${h - 6}" width="${w}" height="6" fill="${crack}" opacity="0.35"/>`
  );
const concrete = (base, seam, dot) => (w, h) =>
  S(
    w,
    h,
    `<rect width="${w}" height="${h}" fill="${base}"/><rect width="${w}" height="${Math.round(h * 0.18)}" fill="rgba(40,20,10,0.12)"/>` +
      [213, 426, 639].map((x) => `<path d="M${x} 0 V${h}" stroke="${seam}" stroke-width="2.5"/>`).join('') +
      `<path d="M0 ${h * 0.55} H${w}" stroke="${seam}" stroke-width="2.5"/>` +
      Array.from({ length: 40 }, (_, i) => `<circle cx="${(i * 197) % w}" cy="${((i * 61) % 100) * h * 0.01}" r="${1.5 + (i % 3)}" fill="${dot}"/>`).join('') +
      `<path d="M520 ${h * 0.3} l30 12 14 26 M90 ${h * 0.75} l26 -6 18 14" stroke="${seam}" stroke-width="2" fill="none"/>`
  );
const bareCeil = (w, h) => S(w, h, `<rect width="${w}" height="${h - 3}" fill="#cfc8bb"/><path d="M300 2 l20 6 14 -3 22 7" stroke="#9c9486" stroke-width="2" fill="none"/><rect y="${h - 3}" width="${w}" height="3" fill="${INK}"/>`);
const damask = (w, h) =>
  S(
    w,
    h,
    `<defs><pattern id="dm" width="64" height="72" patternUnits="userSpaceOnUse"><rect width="64" height="72" fill="#7a1f3d"/><path d="M32 6 C46 18 46 30 32 36 C18 30 18 18 32 6 Z M32 42 C40 50 40 60 32 66 C24 60 24 50 32 42 Z" fill="#c9952f" opacity="0.85"/><circle cx="0" cy="36" r="5" fill="#c9952f" opacity="0.6"/><circle cx="64" cy="36" r="5" fill="#c9952f" opacity="0.6"/></pattern></defs>` +
      `<rect width="${w}" height="${h}" fill="url(#dm)"/><rect y="${h - 26}" width="${w}" height="26" fill="#4a1226"/><rect y="${h - 28}" width="${w}" height="5" fill="#e8b84a"/>`
  );
const goldMarble = (w, h) =>
  S(
    w,
    h,
    `<defs><pattern id="gm" width="120" height="70" patternUnits="userSpaceOnUse"><rect width="120" height="70" fill="#f6f1ea"/><path d="M0 50 C30 30 50 60 80 36 S110 20 120 28" stroke="#d8cfc4" stroke-width="2" fill="none"/><path d="M10 10 C30 18 40 4 60 12" stroke="#e2dad0" stroke-width="1.5" fill="none"/><path d="M0 0 H120 V70" stroke="#e8b84a" stroke-width="3" fill="none"/></pattern></defs>` +
      `<rect width="${w}" height="${h}" fill="url(#gm)"/><rect width="${w}" height="${Math.round(h * 0.16)}" fill="rgba(40,20,10,0.1)"/>`
  );
const goldCoffers = (w, h) =>
  S(w, h, `<rect width="${w}" height="${h - 3}" fill="#e8b84a"/>` + Array.from({ length: Math.ceil(w / 40) }, (_, i) => `<rect x="${i * 40 + 4}" y="3" width="32" height="${h - 9}" rx="2" fill="#f6d27a" stroke="#b8862e" stroke-width="1.5"/>`).join('') + `<rect y="${h - 3}" width="${w}" height="3" fill="${INK}"/>`);

// per kind: the bare one first (free), the luxe one last; prices for the
// design's themes in between (by their position)
export const THEME_EXTRA = {
  wall: {
    first: (room) => ({ name: room === 'dance' ? 'Bare Basement' : 'Bare Plaster', lvl: 1, coins: 0, svg: room === 'dance' ? plaster('#5e5866', '#3f3a46', '#2f2a35') : plaster('#ddd5c6', '#a99d89', '#c2b59c') }),
    last: { name: 'Royal Damask', lvl: 9, coins: 3500, svg: damask },
    prices: [150, 300, 500, 800, 1200, 2000],
  },
  floor: {
    first: () => ({ name: 'Bare Concrete', lvl: 1, coins: 0, svg: concrete('#b9b3aa', '#9b958c', '#a39d94') }),
    last: { name: 'Gold Marble', lvl: 9, coins: 3500, svg: goldMarble },
    prices: [150, 300, 500, 800, 1200, 2000],
  },
  ceil: {
    first: () => ({ name: 'Bare Ceiling', lvl: 1, coins: 0, svg: bareCeil }),
    last: { name: 'Gold Coffers', lvl: 9, coins: 2500, svg: goldCoffers },
    prices: [100, 200, 350, 600, 900, 1400],
  },
};

// ---- the rooms' fixtures, as decor -------------------------------------------------------
// [room, key, name, coins, level, perk, light?]
const FIX = [
  ['living', 'window', 'Curtained Window', 250, 1, 0.02],
  ['living', 'bunting', 'Party Bunting', 120, 1, 0.01],
  ['living', 'painting', 'Landscape Painting', 200, 1, 0.02],
  ['living', 'mirror', 'Oval Mirror', 180, 1, 0.01],
  ['living', 'clock', 'Wall Clock', 150, 1, 0.01],
  ['living', 'vase', 'Flower Vase', 120, 1, 0.01],
  ['living', 'lamp', 'Table Lamp', 220, 1, 0.01, 90],
  ['living', 'dresser', 'Dresser', 400, 2, 0.02],
  ['living', 'bookshelf', 'Bookshelf', 500, 2, 0.03],
  ['kitchen', 'window', 'Kitchen Window', 250, 1, 0.02],
  ['kitchen', 'potrack', 'Pot Rack', 300, 2, 0.02],
  ['kitchen', 'cabinet', 'Wall Cabinet', 450, 2, 0.03],
  ['kitchen', 'oven', 'Oven', 700, 3, 0.04],
  ['bath', 'towel', 'Striped Towel', 120, 1, 0.01],
  ['bath', 'curtain', 'Shower Curtain', 200, 1, 0.02],
  ['bath', 'mirror', 'Round Mirror', 250, 1, 0.02],
  ['bath', 'shelf', 'Towel Shelf', 400, 2, 0.03],
  ['bed', 'sign', 'Sweet Dreams Sign', 200, 1, 0.01],
  ['bed', 'window', 'Bedroom Window', 250, 1, 0.02],
  ['bed', 'moon', 'Paper Moon', 300, 2, 0.02],
  ['bed', 'fairy', 'Fairy Lights', 350, 2, 0.02, 120],
  ['dance', 'partylights', 'Party Lights', 350, 1, 0.02, 140],
  ['dance', 'neonParty', 'Neon Music Sign', 500, 2, 0.03, 110],
  ['dance', 'neonDance', 'Neon DANCE', 600, 3, 0.03, 120],
];
export const FIXTURE_DECOR = FIX.map(([room, key, name, coins, lvl, perk, light]) => {
  const a = FIXTURE_GEO[room].fixtures[key];
  return {
    id: `fx_${room}_${key}`,
    room,
    name,
    perk,
    perkText: `+${Math.round(perk * 100)}% room bonus`,
    lvl,
    coins,
    usd: 0,
    x: a.x,
    y: a.y,
    w: a.w,
    h: a.h,
    art: `${room}.${key}`,
    light: light ? { lx: a.w / 2, ly: a.h / 2, r: light, c: '255,220,170' } : null,
  };
});
