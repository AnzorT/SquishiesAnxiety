// Changes to the design's "Creature Plush" art, applied by render.mjs on top
// of Creature Plush.dc.html (kept here so re-extracting the zip keeps them).
//
// Each entry replaces one creature's markup (`art`, the design's isC{id}
// block) and can turn off the shared layers drawn over every creature:
// `noBlush` (the pink cheeks) and `noGloss` (the glossy streak + catch-light).
// Everything reuses the design's own pieces — eye, smile, blush, gloss, body
// shading — so the fixed creatures match the rest.

// The design's eye: white ball, purple pupil with two catch-lights.
const eye = (side, x, y, d) =>
  `<div style="position:absolute; ${side}:${x}%; top:${y}%; width:${d}%; height:${d}%; background:radial-gradient(circle at 40% 35%, #ffffff 60%, #f3e6ff 100%); border-radius:50%;"><div style="position:absolute; left:28%; top:28%; width:48%; height:48%; background:radial-gradient(circle at 34% 30%, #ffffff 0 20%, transparent 23%), radial-gradient(circle at 68% 70%, rgba(255,255,255,0.85) 0 10%, transparent 13%), radial-gradient(circle at 50% 60%, #6b2a8f 0%, #2a0f45 70%); border-radius:50%;"></div></div>`;

// The design's open smile with the pink tongue.
const smile = (x, y, w, h) =>
  `<div style="position:absolute; left:${x}%; top:${y}%; width:${w}%; height:${h}%; border-radius:0 0 50% 50%; background:radial-gradient(circle at 50% 20%, #ff8fb8 0 30%, #7a1f4f 70%);"></div>`;

// The design's blush patch.
const blush = (side, x, y, w, h) =>
  `<div style="position:absolute; ${side}:${x}%; top:${y}%; width:${w}%; height:${h}%; border-radius:50%; background:radial-gradient(ellipse, rgba(255,105,170,0.75) 0%, rgba(255,105,170,0) 70%);"></div>`;

// A soft plush spike. The design draws spikes as CSS border triangles sized
// in %, which browsers ignore, so they never showed. This one is a square
// with three round corners, turned so the sharp corner points up, narrowed,
// then tilted `angle` degrees (0 = straight up) to grow out of the body.
// (cx, cy) is its middle in % of the creature box; its round bottom half
// tucks behind the body. Shaded like the body: lit from the top left.
// `shoulder` rounds the two side corners: 50 gives a soft ear, less gives
// straighter sides (a cone); `shine` is the strength of the highlight.
function spike({ cx, cy, size, angle = 0, narrow = 0.7, shoulder = 50, shine = 0.6, light, mid, dark }) {
  const turn = 45 + angle; // the element's own frame is turned this much
  // The body's gradient runs at 160deg on screen; in the turned frame that is:
  const grad = 160 - turn;
  // The body's inset highlight/shade offsets (+x +y = lit from the top left),
  // turned into the element's frame.
  const r = (turn * Math.PI) / 180;
  const off = (dx, dy) => [dx * Math.cos(r) + dy * Math.sin(r), -dx * Math.sin(r) + dy * Math.cos(r)].map((n) => n.toFixed(1) + 'px').join(' ');
  return `<div style="position:absolute; left:${(cx - size / 2).toFixed(2)}%; top:${(cy - size / 2).toFixed(2)}%; width:${size}%; height:${size}%; border-radius:14% ${shoulder}% 50% ${shoulder}%; background:linear-gradient(${grad}deg, ${light} 0%, ${mid} 45%, ${dark} 100%); box-shadow: inset ${off(-3, -4)} 7px rgba(120,30,110,0.2), inset ${off(3, 4)} 7px rgba(255,255,255,${shine}), inset 0 0 0 2px rgba(255,255,255,0.25); transform:rotate(${angle}deg) scaleX(${narrow}) rotate(45deg);"></div>`;
}

// Places a spike on a round body centred at (50, 50): `angle` from straight
// up, its middle `at` % from the centre.
const onBody = (angle, at) => {
  const a = (angle * Math.PI) / 180;
  return { cx: 50 + at * Math.sin(a), cy: 50 - at * Math.cos(a), angle };
};

export const FIXES = {
  // Nubbin: its two horns (they double as ears) are back, it smiles, and it
  // has the design's real eyes instead of two dashes.
  2: {
    art: `
    ${(() => {
      const c = { light: '#fed7aa', mid: '#fb923c', dark: '#c2410c', size: 17, narrow: 0.78 };
      return spike({ ...c, ...onBody(-34, 40) }) + spike({ ...c, ...onBody(34, 40) });
    })()}
    <div style="position:absolute; inset:10%; border-radius:48% 52% 45% 55% / 52% 48% 52% 48%; background:linear-gradient(160deg,#fdba74,#ea580c); box-shadow: inset -8px -12px 22px rgba(120,30,110,0.2), inset 10px 12px 24px rgba(255,255,255,0.65), inset 0 0 0 3px rgba(255,255,255,0.3), 0 14px 26px rgba(234,88,12,0.4);">
      ${eye('left', 27, 37, 16)}
      ${eye('right', 27, 37, 16)}
      ${smile(38, 61, 24, 12)}
    </div>`,
  },

  // Spike: its three spikes are back, growing out of the top of the body.
  4: {
    art: `
    ${(() => {
      const c = { light: '#86efac', mid: '#4ade80', dark: '#16a34a', narrow: 0.6, shoulder: 22, shine: 0.4 };
      return (
        spike({ ...c, size: 16, ...onBody(-38, 41) }) +
        spike({ ...c, size: 16, ...onBody(38, 41) }) +
        spike({ ...c, size: 19, ...onBody(0, 41) })
      );
    })()}
    <div style="position:absolute; inset:10%; border-radius:50%; background:linear-gradient(160deg,#86efac,#16a34a); box-shadow: inset -8px -12px 22px rgba(120,30,110,0.2), inset 10px 12px 24px rgba(255,255,255,0.65), inset 0 0 0 3px rgba(255,255,255,0.3), 0 14px 26px rgba(22,163,74,0.4);">
      ${eye('left', 28, 38, 14)}
      ${eye('right', 28, 38, 14)}
      ${smile(40, 64, 20, 9)}
    </div>`,
  },

  // Puffington: the cheeks sit on the middle puff (the shared blush landed
  // low, where the puffs meet), and it has Mochi's eyes.
  6: {
    noBlush: true,
    art: `
    <div style="position:absolute; left:6%; top:30%; width:44%; height:44%; border-radius:50%; background:linear-gradient(160deg,#e0f2fe,#7dd3fc);"></div>
    <div style="position:absolute; right:6%; top:30%; width:44%; height:44%; border-radius:50%; background:linear-gradient(160deg,#e0f2fe,#7dd3fc);"></div>
    <div style="position:absolute; left:16%; top:14%; width:68%; height:56%; border-radius:50%; background:linear-gradient(160deg,#f0f9ff,#38bdf8); box-shadow: inset -8px -12px 22px rgba(120,30,110,0.18), inset 10px 12px 24px rgba(255,255,255,0.7), inset 0 0 0 3px rgba(255,255,255,0.3), 0 14px 26px rgba(56,189,248,0.4);">
      <div style="position:absolute; left:27%; top:44%; width:17%; height:6%; border-bottom:2px solid #0f172a; transform:rotate(4deg);"></div>
      <div style="position:absolute; right:27%; top:44%; width:17%; height:6%; border-bottom:2px solid #0f172a; transform:rotate(-4deg);"></div>
      ${smile(42, 62, 16, 9)}
      ${blush('left', 11, 56, 22, 14)}
      ${blush('right', 11, 56, 22, 14)}
    </div>`,
  },

  // Cosmo: sits inside its ring. The ring's far half passes behind the body
  // and its near half in front, below the face. The gloss moves onto the
  // body (the shared one floated above it, since Cosmo's body starts low).
  19: {
    noGloss: true,
    art: (() => {
      const ring = (front) =>
        `<div style="position:absolute; left:-4%; top:62%; width:108%; height:20%; border-radius:50%; border:4px solid rgba(196,181,253,0.75); transform:rotate(-14deg);${front ? ' clip-path:inset(50% 0 0 0);' : ''}"></div>`;
      return `
    ${ring(false)}
    <div style="position:absolute; top:24%; bottom:4%; left:14%; right:14%; border-radius:50%; background:radial-gradient(circle at 32% 26%,#6d28d9,#2e1065 78%); box-shadow: inset -8px -12px 22px rgba(120,30,110,0.2), inset 10px 12px 24px rgba(255,255,255,0.65), inset 0 0 0 3px rgba(255,255,255,0.3), 0 0 30px rgba(109,40,217,0.6);">
      <div style="position:absolute; left:14%; top:8%; width:34%; height:18%; border-radius:50%; background:radial-gradient(ellipse at 50% 50%, rgba(255,255,255,0.9) 0%, rgba(255,255,255,0.35) 55%, rgba(255,255,255,0) 72%); transform:rotate(-28deg);"></div>
      <div style="position:absolute; left:64%; top:12%; width:9%; height:9%; border-radius:50%; background:rgba(255,255,255,0.75);"></div>
      <div style="position:absolute; left:22%; top:30%; width:7%; height:7%; background:#fef3c7; border-radius:50%; box-shadow:0 0 8px rgba(254,243,199,0.9);"></div>
      <div style="position:absolute; right:20%; top:34%; width:5%; height:5%; background:#fef3c7; border-radius:50%; box-shadow:0 0 8px rgba(254,243,199,0.9);"></div>
      ${eye('left', 29, 40, 15)}
      ${eye('right', 29, 40, 15)}
      ${smile(42, 62, 16, 8)}
    </div>
    ${ring(true)}`;
    })(),
  },
};
