// Whole numbers with thousands commas ("12,500"). Same output as
// toLocaleString('en-US') for these, but Hermes' toLocaleString goes through
// Intl and is very slow: profiled at 18% of the JS thread when the Shop
// re-rendered its prices (2026-10-08). Use this for any number on screen.
export function fmtNum(n) {
  const v = Math.round(Number(n) || 0);
  const s = String(Math.abs(v)).replace(/\B(?=(\d{3})+(?!\d))/g, ',');
  return v < 0 ? `-${s}` : s;
}
