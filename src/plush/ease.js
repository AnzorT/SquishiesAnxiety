// The design's easing curves (squish-rig.js: EASE, bez, EF) — CSS-style
// cubic beziers solved for y at a given x.

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

export const EF = { bouncy: bez(0.34, 1.56, 0.64, 1), soft: bez(0.45, 0, 0.55, 1), snappy: bez(0.2, 0, 0, 1) };

// `fn(u)` sampled at n + 1 points over 0-1, for an Animated interpolation
export const sample = (n, fn) => Array.from({ length: n + 1 }, (_, i) => fn(i / n));
