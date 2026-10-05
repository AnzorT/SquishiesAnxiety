// The Hatchery's room: an attic under the roof (the user's 2026-10-03
// review — it used to look like the living room). Drawn in the scene's
// 852×393 units, in the Crib's style: flat fills, #5b3a29 outlines. The
// creatures' pods sit over it in three rows (Scene.js), so the walls stay
// calm and the clutter keeps to the corners.

const INK = '#5b3a29';
const st = (w = 3) => `stroke="${INK}" stroke-width="${w}" stroke-linejoin="round" stroke-linecap="round"`;

// vertical wall planks
const planks = () => {
  let s = '';
  for (let x = 0; x < 852; x += 38) {
    const c = (x / 38) % 3 === 0 ? '#d7a46c' : (x / 38) % 3 === 1 ? '#cf9a62' : '#d39f67';
    s += `<rect x="${x}" y="0" width="38" height="336" fill="${c}"/><path d="M${x} 0 V336" stroke="#a8713f" stroke-width="2"/>`;
    // a knot here and there
    if ((x * 7) % 5 === 0) s += `<ellipse cx="${x + 19}" cy="${120 + ((x * 13) % 150)}" rx="4" ry="2.5" fill="#b07a45"/>`;
  }
  return s;
};

// the floor's boards, in perspective rows
const floorBoards = () => {
  let s = `<rect x="0" y="330" width="852" height="63" fill="#b77a45"/>`;
  [344, 360, 378].forEach((y) => (s += `<path d="M0 ${y} H852" stroke="#94602f" stroke-width="2"/>`));
  for (let x = 30, r = 0; x < 852; x += 96, r++) {
    s += `<path d="M${x + (r % 2) * 40} 330 V344 M${x + 20} 344 V360 M${x + 60 - (r % 2) * 30} 360 V378 M${x + 10} 378 V393" stroke="#94602f" stroke-width="2"/>`;
  }
  return s + `<rect x="0" y="326" width="852" height="8" fill="#8a5530" ${st(2)}/>`;
};

// the roof's underside in the two top corners, boards running down the slope
const roof = (side) => {
  const pts = side < 0 ? '0,0 410,0 0,209' : '852,0 442,0 852,209';
  const clip = `roof${side < 0 ? 'L' : 'R'}`;
  let boards = '';
  for (let k = -400; k < 900; k += 26) boards += side < 0 ? `<path d="M${k} 0 L${k - 410} 209" stroke="#6b4128" stroke-width="2"/>` : `<path d="M${k} 0 L${k + 410} 209" stroke="#6b4128" stroke-width="2"/>`;
  return `<clipPath id="${clip}"><polygon points="${pts}"/></clipPath><polygon points="${pts}" fill="#8a5a38"/><g clip-path="url(#${clip})">${boards}</g>`;
};

const rafter = (x1, y1, x2, y2, w = 22) => {
  const dx = x2 - x1;
  const dy = y2 - y1;
  const L = Math.hypot(dx, dy);
  const nx = (-dy / L) * (w / 2);
  const ny = (dx / L) * (w / 2);
  return `<polygon points="${x1 + nx},${y1 + ny} ${x2 + nx},${y2 + ny} ${x2 - nx},${y2 - ny} ${x1 - nx},${y1 - ny}" fill="#9a6338" ${st()}/><path d="M${x1 + nx * 0.4} ${y1 + ny * 0.4} L${x2 + nx * 0.4} ${y2 + ny * 0.4}" stroke="#b97f4c" stroke-width="3" opacity="0.7"/>`;
};

const box = (x, y, w, h, c = '#d6a96c') =>
  `<rect x="${x}" y="${y}" width="${w}" height="${h}" rx="3" fill="${c}" ${st(2.5)}/><rect x="${x + w / 2 - 5}" y="${y + 1.5}" width="10" height="${h - 3}" fill="#f1e3bd" opacity="0.8"/>`;

const cobweb = (x, y, s) =>
  `<g transform="translate(${x} ${y}) scale(${s} 1)" opacity="0.55" fill="none" stroke="#fff6e6" stroke-width="1.6"><path d="M0 0 L46 0 M0 0 L40 22 M0 0 L22 40 M0 0 L0 46"/><path d="M14 0 Q12 7 12 12 Q7 12 0 14 M30 0 Q27 15 26 22 Q14 26 0 30 M44 0 Q40 24 37 31 Q22 38 0 44"/></g>`;

export const ATTIC_SVG = `<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 852 393" preserveAspectRatio="none">
${planks()}
${roof(-1)}${roof(1)}
<!-- a round window under the ridge -->
<circle cx="426" cy="74" r="34" fill="#9fd8f0" ${st(4)}/>
<path d="M392 74 H460 M426 40 V108" ${st(4)}/>
<circle cx="412" cy="60" r="6" fill="#ffffff" opacity="0.8"/>
<circle cx="426" cy="74" r="40" fill="none" stroke="#9a6338" stroke-width="7"/>
<circle cx="426" cy="74" r="43.5" fill="none" ${st(2.5)}/>
<!-- the rafters, the ridge, the collar beam and the king post -->
${rafter(-10, 214, 430, -10)}${rafter(862, 214, 422, -10)}
${rafter(150, 132, 702, 132, 18)}
<rect x="417" y="0" width="18" height="12" fill="#9a6338" ${st(2.5)}/>
<!-- a bulb on its cord -->
<path d="M250 102 V150" ${st(2)}/>
<circle cx="250" cy="166" r="30" fill="#fff3b0" opacity="0.25"/>
<rect x="245" y="148" width="10" height="9" rx="2" fill="#7d7d84" ${st(2)}/>
<circle cx="250" cy="165" r="9" fill="#fff3b0" ${st(2)}/>
<!-- cobwebs in the corners under the roof -->
${cobweb(0, 209, 1)}${cobweb(852, 209, -1)}
<!-- the clutter: boxes on the left, a trunk and a rolled rug on the right -->
${box(8, 262, 70, 66)}${box(18, 214, 54, 48, '#c4955a')}${box(80, 290, 52, 38, '#c4955a')}
<rect x="742" y="282" width="100" height="48" rx="6" fill="#7aa0c9" ${st(2.5)}/>
<path d="M742 296 Q792 268 842 296" fill="#8fb4da" ${st(2.5)}/>
<path d="M760 284 V330 M824 284 V330" stroke="#e8c26b" stroke-width="5"/>
<rect x="786" y="300" width="14" height="12" rx="2" fill="#e8c26b" ${st(2)}/>
<rect x="690" y="300" width="44" height="28" rx="14" fill="#e88c8c" ${st(2.5)}/>
<circle cx="704" cy="314" r="7" fill="none" stroke="#c46a6a" stroke-width="2"/>
${floorBoards()}
<!-- dust in the window light -->
<path d="M396 108 L330 330 H520 L456 108 Z" fill="#fff6d8" opacity="0.12"/>
</svg>`;
