// The design's mood faces (squish-rig.js: FACES, eyeSvg, mouthSvg,
// faceInner), ported 1:1. A face is drawn as SVG in the creature's own 0-100
// box, over the faceless body art, from the creature's rig (its catalog doc's
// `rig`: eye centres and radii, mouth position and width, ink colours, the
// face patch the lids match) — see tools/plush-art/render.mjs.
//
// Which face a mood shows (plush-anim.js FACE): null means the drawing's own
// face, with the blink (see PlushCreature in CreatureThumbnail.js).

export const FACE_FOR_MOOD = {
  idle: null,
  ready: null,
  tv: null,
  eat: 'eating',
  full: 'content',
  dance: 'happy',
  wobble: 'happy',
  unlock: 'happy',
  celebrate: 'happy',
  spin: 'happy',
  reveal: 'party',
  happy: 'party',
  jump: 'party',
  sad: 'sad',
  clean: 'content',
  dirty: 'smelly',
  bath: 'content',
  sleep: 'sleep',
};

// eye glyph + mouth glyph per face
const FACES = {
  happy: { e: 'happy', m: 'smile' },
  sad: { e: 'sad', m: 'wobble' },
  angry: { e: 'angry', m: 'pout' },
  hungry: { e: 'look', m: 'o' },
  smelly: { e: 'meh', m: 'wavy' },
  eating: { e: 'happy', m: 'chomp' },
  content: { e: 'closed', m: 'small' },
  sleep: { e: 'closed', m: 'tinyo' },
  squish: { e: 'squish', m: 'wavy' },
  star: { e: 'star', m: 'grin' },
  party: { e: 'happy', m: 'grin' },
};

const n = (v) => +v.toFixed(2);
const hex = (h) => [parseInt(h.slice(1, 3), 16), parseInt(h.slice(3, 5), 16), parseInt(h.slice(5, 7), 16)];
export function mixHex(a, b, t) {
  const A = hex(a);
  const B = hex(b);
  return `#${A.map((v, i) => Math.round(v + (B[i] - v) * t).toString(16).padStart(2, '0')).join('')}`;
}

// The colour of the face patch at height y — what a closed lid shows.
export function lidColor(rig, y) {
  const P = rig.patch;
  return mixHex(P.top, P.bot, Math.min(1, Math.max(0, (y - (P.cy - P.ry)) / (2 * P.ry))));
}

let clipN = 0;

function eyeSvg(type, e, c, side) {
  const ink = c.ink;
  const sc = !!c.sclera;
  const { x, y } = e;
  const R0 = e.r;
  const r = sc ? R0 * 0.72 : R0;
  const sw = n(Math.max(1.3, r * 0.3));
  const st = `fill="none" stroke="${ink}" stroke-width="${sw}" stroke-linecap="round" stroke-linejoin="round"`;
  const lid = lidColor(c, y);
  const dark = (cy, rr) =>
    `<circle cx="${n(x)}" cy="${n(cy)}" r="${n(rr)}" fill="${ink}"/><circle cx="${n(x - rr * 0.3)}" cy="${n(cy - rr * 0.38)}" r="${n(rr * 0.36)}" fill="#fff"/><circle cx="${n(x + rr * 0.36)}" cy="${n(cy + rr * 0.28)}" r="${n(rr * 0.16)}" fill="#fff"/>`;
  const white = (look) => {
    const ir = R0 * c.irisK;
    const iy = y + look * R0 * 0.22;
    return `<circle cx="${n(x)}" cy="${n(y)}" r="${n(R0)}" fill="${c.scleraColor || '#fff'}"/><circle cx="${n(x)}" cy="${n(iy)}" r="${n(ir)}" fill="${c.iris}"/><circle cx="${n(x - ir * 0.32)}" cy="${n(iy - ir * 0.36)}" r="${n(ir * 0.36)}" fill="#fff"/><circle cx="${n(x + ir * 0.38)}" cy="${n(iy + ir * 0.34)}" r="${n(ir * 0.17)}" fill="#fff"/>`;
  };
  const ball = (cy, rr, look = 0) => (sc ? white(look) : dark(cy, rr));
  const rb = sc ? R0 * 0.78 : r;
  const lidded = (pathD, edgeD) => {
    const id = `eclip${clipN++}`;
    return `<clipPath id="${id}"><circle cx="${n(x)}" cy="${n(y)}" r="${n(R0 + 0.2)}"/></clipPath><g clip-path="url(#${id})"><path d="${pathD}" fill="${lid}"/></g><path d="${edgeD}" ${st}/>`;
  };
  switch (type) {
    case 'happy':
      return `<path d="M${n(x - r)} ${n(y + r * 0.35)} Q${n(x)} ${n(y - r * 1.15)} ${n(x + r)} ${n(y + r * 0.35)}" ${st}/>`;
    case 'closed':
      return `<path d="M${n(x - r)} ${n(y - r * 0.1)} Q${n(x)} ${n(y + r * 0.95)} ${n(x + r)} ${n(y - r * 0.1)}" ${st}/>`;
    case 'look':
      return ball(y - r * 0.05, r, -1);
    case 'sad': {
      const brow =
        side === 0
          ? `M${n(x - rb)} ${n(y - rb * 1.3)} Q${n(x)} ${n(y - rb * 1.85)} ${n(x + rb)} ${n(y - rb * 1.3)}`
          : side < 0
            ? `M${n(x - rb * 0.9)} ${n(y - rb * 1.35)} Q${n(x)} ${n(y - rb * 1.55)} ${n(x + rb * 0.8)} ${n(y - rb * 1.95)}`
            : `M${n(x + rb * 0.9)} ${n(y - rb * 1.35)} Q${n(x)} ${n(y - rb * 1.55)} ${n(x - rb * 0.8)} ${n(y - rb * 1.95)}`;
      const gr = sc ? R0 : r;
      const gx = x + gr * 0.55 * (side === 0 ? 1 : -side);
      return `${ball(y, r * 1.02, -1)}<path d="${brow}" fill="none" stroke="${ink}" stroke-width="${n(sw * 0.75)}" stroke-linecap="round"/><ellipse cx="${n(gx)}" cy="${n(y + gr * 0.92)}" rx="${n(gr * 0.2)}" ry="${n(gr * 0.26)}" fill="#cfeeff"/>`;
    }
    case 'angry': {
      if (sc) {
        const Q = R0 * 1.2;
        const lidD =
          side === 0
            ? `M${n(x - Q)} ${n(y - Q)} L${n(x + Q)} ${n(y - Q)} L${n(x + Q)} ${n(y - R0 * 0.75)} L${n(x)} ${n(y - R0 * 0.1)} L${n(x - Q)} ${n(y - R0 * 0.75)}Z`
            : side < 0
              ? `M${n(x - Q)} ${n(y - Q)} L${n(x + Q)} ${n(y - Q)} L${n(x + Q)} ${n(y - R0 * 0.1)} L${n(x - Q)} ${n(y - R0 * 0.8)}Z`
              : `M${n(x - Q)} ${n(y - Q)} L${n(x + Q)} ${n(y - Q)} L${n(x + Q)} ${n(y - R0 * 0.8)} L${n(x - Q)} ${n(y - R0 * 0.1)}Z`;
        const edge =
          side === 0
            ? `M${n(x - R0 * 0.95)} ${n(y - R0 * 0.7)} L${n(x)} ${n(y - R0 * 0.1)} L${n(x + R0 * 0.95)} ${n(y - R0 * 0.7)}`
            : side < 0
              ? `M${n(x - R0 * 0.95)} ${n(y - R0 * 0.78)} L${n(x + R0 * 0.95)} ${n(y - R0 * 0.12)}`
              : `M${n(x + R0 * 0.95)} ${n(y - R0 * 0.78)} L${n(x - R0 * 0.95)} ${n(y - R0 * 0.12)}`;
        return white(0.3) + lidded(lidD, edge);
      }
      const brow =
        side === 0
          ? `M${n(x - r)} ${n(y - r * 1.5)} L${n(x)} ${n(y - r * 1.0)} L${n(x + r)} ${n(y - r * 1.5)}`
          : side < 0
            ? `M${n(x - r * 0.9)} ${n(y - r * 1.55)} L${n(x + r * 0.8)} ${n(y - r * 1.0)}`
            : `M${n(x + r * 0.9)} ${n(y - r * 1.55)} L${n(x - r * 0.8)} ${n(y - r * 1.0)}`;
      return `${dark(y + r * 0.1, r * 0.82)}<path d="${brow}" ${st}/>`;
    }
    case 'meh':
      if (sc) {
        const Q = R0 * 1.2;
        return (
          white(0.45) +
          lidded(
            `M${n(x - Q)} ${n(y - Q)} L${n(x + Q)} ${n(y - Q)} L${n(x + Q)} ${n(y - R0 * 0.05)} L${n(x - Q)} ${n(y - R0 * 0.05)}Z`,
            `M${n(x - R0 * 1.02)} ${n(y - R0 * 0.05)} L${n(x + R0 * 1.02)} ${n(y - R0 * 0.05)}`
          )
        );
      }
      return `<path d="M${n(x - r * 0.9)} ${n(y)} A${n(r * 0.9)} ${n(r * 0.9)} 0 0 0 ${n(x + r * 0.9)} ${n(y)} Z" fill="${ink}"/><path d="M${n(x - r * 1.05)} ${n(y)} L${n(x + r * 1.05)} ${n(y)}" ${st}/><circle cx="${n(x - r * 0.3)}" cy="${n(y + r * 0.35)}" r="${n(r * 0.17)}" fill="#fff"/>`;
    case 'squish': {
      const chev = (cx, dir, rr) => `<path d="M${n(cx - dir * rr * 0.7)} ${n(y - rr * 0.75)} L${n(cx + dir * rr * 0.6)} ${n(y)} L${n(cx - dir * rr * 0.7)} ${n(y + rr * 0.75)}" ${st}/>`;
      if (side === 0) return chev(x - r * 0.55, 1, r * 0.6) + chev(x + r * 0.55, -1, r * 0.6);
      return chev(x, side < 0 ? 1 : -1, r);
    }
    case 'star': {
      const R = r * 1.25;
      const ri = R * 0.42;
      let d = '';
      for (let i = 0; i < 8; i++) {
        const a = -Math.PI / 2 + (i * Math.PI) / 4;
        const rr = i % 2 ? ri : R;
        d += `${i ? 'L' : 'M'}${n(x + Math.cos(a) * rr)} ${n(y + Math.sin(a) * rr)}`;
      }
      return `<path d="${d}Z" fill="#ffd84a" stroke="${ink}" stroke-width="${n(sw * 0.45)}" stroke-linejoin="round"/><circle cx="${n(x - R * 0.18)}" cy="${n(y - R * 0.2)}" r="${n(R * 0.14)}" fill="#fff"/>`;
    }
    default:
      return '';
  }
}

function mouthSvg(type, m, ink, mi) {
  const { x, y, w } = m;
  const hw = w / 2;
  const sw = n(Math.max(1.3, w * 0.12));
  const st = `fill="none" stroke="${ink}" stroke-width="${sw}" stroke-linecap="round"`;
  switch (type) {
    case 'smile':
      return `<path d="M${n(x - hw)} ${n(y)} Q${n(x)} ${n(y + w * 0.85)} ${n(x + hw)} ${n(y)} Z" fill="${mi}"/><ellipse cx="${n(x)}" cy="${n(y + w * 0.29)}" rx="${n(w * 0.19)}" ry="${n(w * 0.1)}" fill="#ff8fb8"/>`;
    case 'grin':
      return `<path d="M${n(x - hw * 1.2)} ${n(y - w * 0.05)} Q${n(x)} ${n(y + w * 1.15)} ${n(x + hw * 1.2)} ${n(y - w * 0.05)} Z" fill="${mi}"/><ellipse cx="${n(x)}" cy="${n(y + w * 0.38)}" rx="${n(w * 0.24)}" ry="${n(w * 0.13)}" fill="#ff8fb8"/>`;
    case 'small':
      return `<path d="M${n(x - hw * 0.55)} ${n(y)} Q${n(x)} ${n(y + w * 0.38)} ${n(x + hw * 0.55)} ${n(y)}" ${st}/>`;
    case 'wobble':
      return `<path d="M${n(x - hw * 0.55)} ${n(y + w * 0.16)} C${n(x - hw * 0.25)} ${n(y - w * 0.1)} ${n(x + hw * 0.25)} ${n(y - w * 0.1)} ${n(x + hw * 0.55)} ${n(y + w * 0.16)}" ${st}/>`;
    case 'pout':
      return `<path d="M${n(x - hw * 0.35)} ${n(y + w * 0.1)} Q${n(x)} ${n(y - w * 0.16)} ${n(x + hw * 0.35)} ${n(y + w * 0.1)}" ${st}/>`;
    case 'o':
      return `<ellipse cx="${n(x)}" cy="${n(y + w * 0.1)}" rx="${n(w * 0.2)}" ry="${n(w * 0.25)}" fill="${mi}"/><ellipse cx="${n(x)}" cy="${n(y + w * 0.24)}" rx="${n(w * 0.12)}" ry="${n(w * 0.07)}" fill="#ff8fb8"/>`;
    case 'chomp':
      return `<g><ellipse cx="${n(x)}" cy="${n(y)}" rx="${n(w * 0.3)}" ry="${n(w * 0.24)}" fill="${mi}"/><ellipse cx="${n(x)}" cy="${n(y + w * 0.12)}" rx="${n(w * 0.16)}" ry="${n(w * 0.08)}" fill="#ff8fb8"/></g>`;
    case 'wavy':
      return `<path d="M${n(x - hw * 0.6)} ${n(y)} Q${n(x - hw * 0.3)} ${n(y - w * 0.13)} ${n(x)} ${n(y)} Q${n(x + hw * 0.3)} ${n(y + w * 0.13)} ${n(x + hw * 0.6)} ${n(y)}" ${st}/>`;
    case 'tinyo':
      return `<ellipse cx="${n(x)}" cy="${n(y)}" rx="${n(w * 0.1)}" ry="${n(w * 0.12)}" fill="${mi}"/>`;
    default:
      return '';
  }
}

// A whole face as an SVG document for the creature's 0-100 box. The drawing
// keeps its own cheeks (the design passes `cheeks: []` here too).
export function faceSvg(rig, faceKey, { mouth = true } = {}) {
  const F = FACES[faceKey] || FACES.happy;
  const single = rig.eyes.length === 1;
  let s = '';
  rig.eyes.forEach((e) => {
    s += eyeSvg(F.e, e, rig, single ? 0 : e.x < 50 ? -1 : 1);
  });
  if (mouth) s += mouthSvg(F.m, rig.mouth, rig.ink, rig.mouthInk);
  return `<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 100 100">${s}</svg>`;
}

// The closed lids for the blink: the drawing's eyes covered in the patch's
// colour (the design scales the eye shapes to a sliver instead; an image
// can't, so the lid comes down over it).
export function lidsSvg(rig) {
  const s = rig.eyes
    .map((e) => `<ellipse cx="${n(e.x)}" cy="${n(e.y)}" rx="${n(e.r * 1.15)}" ry="${n(e.r * 1.15)}" fill="${lidColor(rig, e.y)}"/>`)
    .join('');
  return `<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 100 100">${s}</svg>`;
}
