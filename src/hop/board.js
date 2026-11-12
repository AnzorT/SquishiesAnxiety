// Squish Hop's board on the floor (SQUISH_HOP.md): a plane of tiles leaned
// back TILT degrees and seen in perspective, worked out here rather than with
// a 3D transform, so the squishies standing on it, the taps on it and the
// shapes drawn on it all use the same numbers. Pure functions.
//
// Board units: a tile is 1 × 1; (u, v) is a point on the plane, u to the
// right and v toward the front (cell (x, y) covers u x…x+1, v y…y+1); z is the
// height above the plane, in tiles. On screen everything is T points a tile,
// seen from DEPTH tiles away (the prototype's CSS perspective(T × DEPTH)
// rotateX(38deg), turned about the plane's middle).

export const TILT = 38; // degrees (a board can lean less: layout's `tilt`)
export const DEPTH = 13;

// a point on a w × h plane leaned back by an angle with cosine c and sine s,
// relative to its middle on screen, with T = 1: { x, y, s } (s: how big a
// tile looks there)
function unit(w, h, u, v, z = 0, c = Math.cos((TILT * Math.PI) / 180), sn = Math.sin((TILT * Math.PI) / 180)) {
  const X = u - w / 2;
  const Y = v - h / 2;
  const yr = Y * c - z * sn;
  const zr = Y * sn + z * c;
  const s = DEPTH / (DEPTH - zr);
  return { x: X * s, y: yr * s, s };
}

// Where a w × h board goes in an area aw × ah whose floor starts floorY down
// (the room picture's floor line; the board sits in the floor below it, and
// may reach a little above it): { w, h, T, cx, cy } (cx, cy: the plane's
// middle on screen; tilt: how far the board leans back, in degrees).
export function layout(w, h, aw, ah, floorY = 0, tilt = TILT, maxT = 96) {
  const c = Math.cos((tilt * Math.PI) / 180);
  const sn = Math.sin((tilt * Math.PI) / 180);
  const front = unit(w, h, w, h, 0, c, sn);
  const back = unit(w, h, 0, 0, 0, c, sn);
  const uw = 2 * front.x; // the front edge is the widest
  const uh = front.y - back.y;
  const top = Math.max(0, floorY);
  const space = ah - top + ah * 0.06;
  const T = Math.max(26, Math.floor(Math.min((aw - 10) / uw, space / uh, maxT)));
  const bottom = Math.min(ah - 8, top + (ah - top) / 2 + (uh * T) / 2);
  return { w, h, T, cx: aw / 2, cy: bottom - front.y * T, tilt, c, sn };
}

// A point on the board on screen: { x, y, s } (s: points per tile there)
export function project(B, u, v, z = 0) {
  const p = unit(B.w, B.h, u, v, z, B.c, B.sn);
  return { x: B.cx + p.x * B.T, y: B.cy + p.y * B.T, s: p.s * B.T };
}

// The cell under a screen point (on the plane), or -1.
export function cellAt(B, sx, sy) {
  const x = (sx - B.cx) / B.T;
  const y = (sy - B.cy) / B.T;
  const Y = (y * DEPTH) / (DEPTH * B.c + y * B.sn);
  const s = DEPTH / (DEPTH - Y * B.sn);
  const u = x / s + B.w / 2;
  const v = Y + B.h / 2;
  if (u < 0 || v < 0 || u >= B.w || v >= B.h) return -1;
  return Math.floor(v) * B.w + Math.floor(u);
}

// where a squishy stands on cell i (a bit in front of the middle, as it
// looks on a cushion), `z` up
export const standOn = (B, i, z = 0) => project(B, (i % B.w) + 0.5, Math.floor(i / B.w) + 0.56, z);

// --- shapes ------------------------------------------------------------------------

// The outline of a rounded rectangle on the plane (board units: x0, y0 to x1,
// y1, corners of radius r, at height z), on screen, as an SVG path relative
// to (ox, oy).
export function roundRect(B, x0, y0, x1, y1, r, z, ox, oy) {
  const pts = [];
  const seg = 4;
  const corners = [
    [x1 - r, y0 + r, -Math.PI / 2],
    [x1 - r, y1 - r, 0],
    [x0 + r, y1 - r, Math.PI / 2],
    [x0 + r, y0 + r, Math.PI],
  ];
  corners.forEach(([cx, cy, a0]) => {
    for (let k = 0; k <= seg; k++) {
      const a = a0 + (k / seg) * (Math.PI / 2);
      pts.push(project(B, cx + r * Math.cos(a), cy + r * Math.sin(a), z));
    }
  });
  return pts.map((p, k) => `${k ? 'L' : 'M'}${(p.x - ox).toFixed(1)} ${(p.y - oy).toFixed(1)}`).join(' ') + ' Z';
}

// a polyline of board points (at height z) as an SVG path relative to (ox, oy)
export function polyPath(B, pts, z, ox, oy) {
  return pts
    .map(([u, v], k) => {
      const p = project(B, u, v, z);
      return `${k ? 'L' : 'M'}${(p.x - ox).toFixed(1)} ${(p.y - oy).toFixed(1)}`;
    })
    .join(' ');
}

// The box on screen that cell (x, y)'s drawing fits in, up to height z (with
// room for a cushion's lip): { left, top, width, height }
export function cellBox(B, x, y, z = 0, pad = 0.06) {
  const pts = [
    project(B, x - pad, y - pad, z),
    project(B, x + 1 + pad, y - pad, z),
    project(B, x - pad, y + 1 + pad, 0),
    project(B, x + 1 + pad, y + 1 + pad, 0),
    project(B, x - pad, y - pad, 0),
    project(B, x + 1 + pad, y - pad, 0),
  ];
  const left = Math.floor(Math.min(...pts.map((p) => p.x)));
  const top = Math.floor(Math.min(...pts.map((p) => p.y)));
  const right = Math.ceil(Math.max(...pts.map((p) => p.x)));
  const bottom = Math.ceil(Math.max(...pts.map((p) => p.y)));
  return { left, top, width: right - left, height: bottom - top };
}

// the chevron of an arrow cushion (the Crib's back icon, M15 4 L7 12 L15 20 in
// a 24 box, pointing left), turned to point `dir` (0 up, 1 right, 2 down,
// 3 left), `size` tiles across, centred on (u, v): board points
export function chevron(u, v, dir, size) {
  const rot = [Math.PI / 2, Math.PI, -Math.PI / 2, 0][dir];
  const c = Math.cos(rot);
  const s = Math.sin(rot);
  return [
    [15, 4],
    [7, 12],
    [15, 20],
  ].map(([px, py]) => {
    const x = ((px - 12 + 1.2) / 24) * size;
    const y = ((py - 12) / 24) * size;
    return [u + x * c - y * s, v + x * s + y * c];
  });
}
