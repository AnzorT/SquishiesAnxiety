import React, { memo, useId, useMemo } from 'react';
import { Animated, StyleSheet, Text, View } from 'react-native';
import Svg, { Circle, ClipPath, Defs, Ellipse, G, LinearGradient as LG, Path, RadialGradient, Rect, Stop } from 'react-native-svg';
import { F } from '../squishdoku/theme';
import { CHROME, modelOf } from './models';

// The fridge, drawn as the real thing it is (models.js: a mini fridge up to a restaurant fridge), "realistic and high
// detailed" since 2026-11-17 (the user: "the fridges dont look realistic and high detaield enough"): enamel with a
// soft reflection or brushed steel with its grain, bevelled doors with hinge caps, round chrome handles standing off
// on their posts, a rubber gasket and moulded bins full of bottles, cartons and eggs inside each door, and an inside
// with depth: side walls, a ceiling with an LED strip, a ribbed back wall with a vent, glass (or wire) shelves with
// their trims and the shadows under them, and frosted salad drawers with the vegetables showing through. All SVG, so
// it draws at any size. `door` (Animated, 0 shut → 1 open) and `light` (0 → 1, the lamp) are the game's; `inside` is
// drawn between the shelves and the doors (the squishies on show), `slots` marks the empty spots. Sizes come from
// geometry() so the game can hit-test the same rects it draws (unchanged by the redraw).

export const RING = 3;
export const BORDER = 3;
export const WALL = 8;
export const SHELF = 8;
const LIP = 7;
const FEET = { none: 0, nubs: 7, legs: 16, casters: 16 };
// the doors open as far as the room either side allows
const DEGS = [106, 102, 98, 94, 90];
const INSET = RING + BORDER + WALL;

// how far a door `dw` wide, opened `deg` with perspective `p`, reaches past its hinge on screen (it turns about the
// hinge; the perspective, about its middle, makes the near edge bigger)
function reach(dw, deg, p) {
  const a = (deg * Math.PI) / 180;
  const f = p / (p - dw * Math.sin(a));
  return (dw / 2 - dw * Math.cos(a)) * f - dw / 2;
}
const perspOf = (dw) => Math.max(900, Math.round(dw * 5));

// A model's sizes for `rows` × `cols` spots of side S.
function sizes(m, rows, cols, S) {
  const W = S * cols;
  const H = rows * (S + SHELF);
  const top = Math.round(m.top.a + (m.top.b || 0) * S);
  const bottom = Math.round(m.bottom.a + (m.bottom.b || 0) * S);
  const crisper = m.crisper ? Math.round(S * 0.4 + 8) : 0;
  const bodyW = W + 2 * INSET;
  const bodyH = 2 * (RING + BORDER) + LIP + top + H + crisper + bottom;
  const dw = m.doors === 1 ? W : W / 2;
  // (a little fridge's door covers its freezer box too)
  const up = m.top.keep != null ? top - m.top.keep : 0;
  return { S, W, H, rows, cols, top, up, bottom, crisper, bodyW, bodyH, feet: FEET[m.feet] || 0, dw, persp: perspOf(dw), deg: DEGS[0] };
}

// Where everything goes for a `rows` × `cols` `model` in a `w` × `h` area, leaving `trayH` at the bottom: big (the
// user, 2026-10-24: "the fridge needs to be bigger"), wider for the bigger models, but with room for the open doors
// ("so we can see the doors"): two doors leave it either side, a lone door on its hinge's side. S: one spot's side.
export function geometry({ w, h, rows, cols, model: m, trayH, maxS = 96 }) {
  const availH = h - trayH - 10;
  const perS = rows + (m.top.b || 0) + (m.bottom.b || 0) + (m.crisper ? 0.4 : 0);
  const fixed = 2 * (RING + BORDER) + LIP + m.top.a + m.bottom.a + (m.crisper ? 8 : 0) + rows * SHELF + (FEET[m.feet] || 0);
  const S = Math.max(30, Math.floor(Math.min((w * m.share - 2 * INSET) / cols, (availH - fixed) / perS, maxS)));
  const z = sizes(m, rows, cols, S);
  const room = m.doors === 1 ? w - z.bodyW - 8 : (w - z.bodyW) / 2 - 2;
  const deg = DEGS.find((d) => reach(z.dw, d, z.persp) - INSET <= room) || DEGS[DEGS.length - 1];
  const over = Math.max(0, reach(z.dw, deg, z.persp) - INSET);
  const shift = m.doors === 1 ? (m.hinge === 'right' ? -over / 2 : over / 2) : 0;
  const bx = Math.round((w - z.bodyW) / 2 + shift);
  const by = Math.max(4, Math.round((availH - (z.bodyH + z.feet)) / 2) + 2);
  return { ...z, deg, bx, by, ix: bx + INSET, iy: by + RING + BORDER + z.top, model: m.key };
}
export const slotCenter = (g, i) => ({ x: g.ix + (i % g.cols) * g.S + g.S / 2, y: g.iy + Math.floor(i / g.cols) * (g.S + SHELF) + g.S / 2 });
// the slot under a point inside, or -1
export function slotAt(g, x, y) {
  const pad = 12;
  if (x < g.ix - pad || x > g.ix + g.W + pad || y < g.iy - pad || y > g.iy + g.H + pad) return -1;
  const c = Math.max(0, Math.min(g.cols - 1, Math.floor((x - g.ix) / g.S)));
  const r = Math.max(0, Math.min(g.rows - 1, Math.floor((y - g.iy) / (g.S + SHELF))));
  return r * g.cols + c;
}

// --- drawing helpers -------------------------------------------------------------------------------------------------

// each drawing's gradients need their own ids (on the web they share one page)
function useSid() {
  const id = useId();
  return useMemo(() => `f${id.replace(/[^a-zA-Z0-9]/g, '')}`, [id]);
}
const n1 = (v) => Math.round(v * 10) / 10;
// a rounded rect with its own top and bottom corner radii
function rr(x, y, w, h, rt = 0, rb = rt) {
  const a = Math.max(0, Math.min(rt, w / 2, h / 2));
  const b = Math.max(0, Math.min(rb, w / 2, h / 2));
  return `M${n1(x + a)} ${n1(y)}H${n1(x + w - a)}Q${n1(x + w)} ${n1(y)} ${n1(x + w)} ${n1(y + a)}V${n1(y + h - b)}Q${n1(x + w)} ${n1(y + h)} ${n1(x + w - b)} ${n1(y + h)}H${n1(x + b)}Q${n1(x)} ${n1(y + h)} ${n1(x)} ${n1(y + h - b)}V${n1(y + a)}Q${n1(x)} ${n1(y)} ${n1(x + a)} ${n1(y)}Z`;
}
// colours spread evenly over a gradient
const spread = (colors, op = 1) => colors.map((c, i) => <Stop key={i} offset={colors.length > 1 ? i / (colors.length - 1) : 0} stopColor={c} stopOpacity={op} />);

// brushed steel's grain: fine upright lines, some light, some dark, unevenly spaced
function grainOf(x, y, w, h) {
  let lite = '';
  let dark = '';
  for (let k = 0, X = x + 1.2; X < x + w - 0.5; k++, X += 1.4 + ((k * 7) % 5) * 0.55) {
    const seg = `M${n1(X)} ${n1(y)}V${n1(y + h)}`;
    if (k % 3 === 0) dark += seg;
    else if (k % 3 === 1) lite += seg;
  }
  return [lite, dark];
}

// The gradients of a finish (models.js): across the front, a light-to-shade fall top to bottom, the reflection's
// band and the bevel's light; `d` is the shape the grain and the reflection are clipped to.
function MatDefs({ id, f, d }) {
  const steel = f.kind === 'steel';
  return (
    <>
      <LG id={`${id}A`} x1="0" y1="0" x2="1" y2="0">
        {spread(f.across)}
      </LG>
      <LG id={`${id}V`} x1="0" y1="0" x2="0" y2="1">
        <Stop offset="0" stopColor="#ffffff" stopOpacity={steel ? 0.18 : 0.32} />
        <Stop offset="0.3" stopColor="#ffffff" stopOpacity={0} />
        <Stop offset="0.72" stopColor="#000000" stopOpacity={0} />
        <Stop offset="1" stopColor="#000000" stopOpacity={steel ? 0.18 : 0.12} />
      </LG>
      <LG id={`${id}R`} x1="0" y1="0" x2="1" y2="0">
        <Stop offset="0" stopColor="#ffffff" stopOpacity={0} />
        <Stop offset="0.5" stopColor="#ffffff" stopOpacity={1} />
        <Stop offset="1" stopColor="#ffffff" stopOpacity={0} />
      </LG>
      <LG id={`${id}B`} x1="0" y1="0" x2="1" y2="1">
        <Stop offset="0" stopColor="#ffffff" stopOpacity={0.95} />
        <Stop offset="0.4" stopColor="#ffffff" stopOpacity={0.12} />
        <Stop offset="1" stopColor="#000000" stopOpacity={0.4} />
      </LG>
      <ClipPath id={`${id}C`}>
        <Path d={d} />
      </ClipPath>
    </>
  );
}
// a shape `d` (x, y, w, h its box) filled with the finish
function MatFill({ id, f, d, x, y, w, h }) {
  const steel = f.kind === 'steel';
  const band = `M${n1(x + w * 0.5)} ${n1(y)}L${n1(x + w * 0.78)} ${n1(y)}L${n1(x + w * 0.4)} ${n1(y + h)}L${n1(x + w * 0.12)} ${n1(y + h)}Z`;
  const thin = `M${n1(x + w * 0.84)} ${n1(y)}L${n1(x + w * 0.9)} ${n1(y)}L${n1(x + w * 0.52)} ${n1(y + h)}L${n1(x + w * 0.46)} ${n1(y + h)}Z`;
  const [lite, dark] = steel ? grainOf(x, y, w, h) : ['', ''];
  return (
    <>
      <Path d={d} fill={`url(#${id}A)`} />
      <Path d={d} fill={`url(#${id}V)`} />
      <G clipPath={`url(#${id}C)`}>
        {lite ? <Path d={lite} stroke="#ffffff" strokeOpacity={0.16} strokeWidth={0.7} /> : null}
        {dark ? <Path d={dark} stroke="#000000" strokeOpacity={0.09} strokeWidth={0.7} /> : null}
        <Path d={band} fill={`url(#${id}R)`} opacity={steel ? 0.24 : 0.5} />
        <Path d={thin} fill={`url(#${id}R)`} opacity={steel ? 0.14 : 0.26} />
      </G>
    </>
  );
}
// a metal's gradients, across an upright bar (M) and down a lying one (N)
const MetalDefs = ({ id, metal }) => (
  <>
    <LG id={`${id}M`} x1="0" y1="0" x2="1" y2="0">
      {spread(metal)}
    </LG>
    <LG id={`${id}N`} x1="0" y1="0" x2="0" y2="1">
      {spread(metal)}
    </LG>
  </>
);
// a round bar handle standing off the door on two posts, its shadow cast down and right: upright (VBar) or lying
// (HBar)
function VBar({ id, x, y, w, h }) {
  const post = Math.max(5, w * 0.75);
  return (
    <G>
      <Rect x={x + 3} y={y + 5} width={w} height={h} rx={w / 2} fill="#000000" opacity={0.2} />
      <Rect x={x + (w - post) / 2} y={y - 3} width={post} height={9} rx={2} fill={`url(#${id}M)`} stroke="#000000" strokeOpacity={0.3} strokeWidth={0.6} />
      <Rect x={x + (w - post) / 2} y={y + h - 6} width={post} height={9} rx={2} fill={`url(#${id}M)`} stroke="#000000" strokeOpacity={0.3} strokeWidth={0.6} />
      <Rect x={x} y={y + 3} width={w} height={h - 6} rx={w / 2} fill={`url(#${id}M)`} stroke="#000000" strokeOpacity={0.35} strokeWidth={0.7} />
      <Rect x={x + w * 0.32} y={y + 7} width={Math.max(1, w * 0.14)} height={Math.max(2, h - 14)} rx={w * 0.07} fill="#ffffff" opacity={0.8} />
    </G>
  );
}
function HBar({ id, x, y, w, h }) {
  const post = Math.max(5, h * 0.75);
  return (
    <G>
      <Rect x={x + 3} y={y + 4} width={w} height={h} rx={h / 2} fill="#000000" opacity={0.2} />
      <Rect x={x - 3} y={y + (h - post) / 2} width={9} height={post} rx={2} fill={`url(#${id}N)`} stroke="#000000" strokeOpacity={0.3} strokeWidth={0.6} />
      <Rect x={x + w - 6} y={y + (h - post) / 2} width={9} height={post} rx={2} fill={`url(#${id}N)`} stroke="#000000" strokeOpacity={0.3} strokeWidth={0.6} />
      <Rect x={x + 3} y={y} width={w - 6} height={h} rx={h / 2} fill={`url(#${id}N)`} stroke="#000000" strokeOpacity={0.35} strokeWidth={0.7} />
      <Rect x={x + 8} y={y + h * 0.28} width={Math.max(2, w - 16)} height={Math.max(1, h * 0.16)} rx={h * 0.08} fill="#ffffff" opacity={0.8} />
    </G>
  );
}

// --- a panel: the top-freezer's door, a freezer drawer -----------------------------------------------------------

// `x`, `y`, `w`, `h` in its parent's space; its gap to the body shows round it. handle: 'pocket' (a moulded pull on
// `free`'s side) or 'bar' (a long lying bar along the top)
function Panel({ m, x, y, w, h, r = 8, handle, free = 'left', snow }) {
  const id = useSid();
  const f = m.finish;
  const o = 2;
  const face = rr(o + 1, o + 1, w - 2, h - 2, r - 1, r - 1);
  let pull = null;
  if (handle === 'bar') pull = <HBar id={id} x={o + w * 0.16} y={o + Math.min(8, h * 0.18)} w={w * 0.68} h={Math.max(6, Math.min(9, h * 0.2))} />;
  else if (handle === 'pocket') {
    const ph = Math.max(16, h * 0.45);
    const px = free === 'right' ? o + w - 16 : o + 4;
    const py = o + h - ph - 6;
    pull = (
      <G>
        <Rect x={px + 2} y={py + 3} width={12} height={ph} rx={5} fill="#000000" opacity={0.16} />
        <Rect x={px} y={py} width={12} height={ph} rx={5} fill={`url(#${id}M)`} stroke={f.edge} strokeOpacity={0.5} strokeWidth={0.7} />
        <Rect x={px + 3} y={py + 4} width={6} height={ph - 8} rx={3} fill="#000000" opacity={0.3} />
        <Rect x={px + 1.5} y={py + 2} width={1.6} height={ph - 4} rx={0.8} fill="#ffffff" opacity={0.75} />
      </G>
    );
  }
  return (
    <Svg width={w + 2 * o} height={h + 2 * o} style={[styles.abs, { left: x - o, top: y - o }]}>
      <Defs>
        <MatDefs id={id} f={f} d={face} />
        <MetalDefs id={id} metal={m.metal} />
      </Defs>
      <Path d={rr(0, 0, w + 2 * o, h + 2 * o, r + o)} fill={f.seam} opacity={0.9} />
      <Path d={rr(o, o, w, h, r)} fill={f.edge} />
      <MatFill id={id} f={f} d={face} x={o + 1} y={o + 1} w={w - 2} h={h - 2} />
      <Path d={rr(o + 2, o + 2, w - 4, h - 4, r - 2)} fill="none" stroke={`url(#${id}B)`} strokeWidth={1.5} />
      {snow ? (
        <G opacity={0.55}>
          {[0, 60, 120].map((a) => (
            <Path
              key={a}
              d={`M${o + snow.x} ${o + snow.y - 8}V${o + snow.y + 8}M${o + snow.x} ${o + snow.y - 5}l-2.5 -2.5M${o + snow.x} ${o + snow.y - 5}l2.5 -2.5M${o + snow.x} ${o + snow.y + 5}l-2.5 2.5M${o + snow.x} ${o + snow.y + 5}l2.5 2.5`}
              stroke="#7fb2d1"
              strokeWidth={1.6}
              strokeLinecap="round"
              fill="none"
              transform={`rotate(${a} ${o + snow.x} ${o + snow.y})`}
            />
          ))}
        </G>
      ) : null}
      {pull}
    </Svg>
  );
}

// a kick-plate grille: a recess with louvred slats (dark, or in the body's own shade)
function Grille({ m, x, y, w, h, dark }) {
  const n = Math.max(2, Math.floor((h - 2) / 3.4));
  const step = (h - 3) / n;
  return (
    <Svg width={w} height={h} style={[styles.abs, { left: x, top: y }]}>
      <Path d={rr(0, 0, w, h, 3)} fill={dark ? '#11161a' : m.finish.shade} />
      {Array.from({ length: n }, (_, i) => (
        <G key={i}>
          <Rect x={3} y={1.5 + i * step} width={w - 6} height={step * 0.58} rx={1} fill={dark ? '#3b444d' : m.finish.edge} opacity={dark ? 1 : 0.45} />
          <Rect x={3} y={1.5 + i * step} width={w - 6} height={0.8} fill="#ffffff" opacity={dark ? 0.22 : 0.35} />
        </G>
      ))}
    </Svg>
  );
}

// --- above the inside ----------------------------------------------------------------------------------------------

// `w`: the body's face, inside its border; `W` × `h`: the inside's width, the space above it; `up`: how much of that the
// door covers too
function IceBox({ m, w, W, h, up }) {
  const id = useSid();
  const y0 = h - up;
  const bx = WALL + W * 0.07;
  const bw = W * 0.86;
  const by = y0 + 5;
  const bh = Math.max(8, up - 10);
  return (
    <Svg width={w} height={h + 12} style={styles.abs}>
      <Defs>
        <LG id={`${id}al`} x1="0" y1="0" x2="0" y2="1">
          {spread(['#f7fafc', '#dfe6eb', '#bfcad3'])}
        </LG>
        <LG id={`${id}N`} x1="0" y1="0" x2="0" y2="1">
          {spread(CHROME)}
        </LG>
      </Defs>
      {/* a retro fridge's chrome strip on its rounded top */}
      {m.radius[0] > 30 ? (
        <G>
          <Rect x={WALL + W * 0.22 + 2} y={y0 * 0.42} width={W * 0.56} height={7} rx={3.5} fill="#000000" opacity={0.15} />
          <Rect x={WALL + W * 0.22} y={y0 * 0.42 - 3} width={W * 0.56} height={7} rx={3.5} fill={`url(#${id}N)`} stroke="#000000" strokeOpacity={0.3} strokeWidth={0.6} />
        </G>
      ) : null}
      {/* the liner behind the freezer box (inside, under the door) */}
      <Path d={rr(WALL, y0, W, up + 12, 10, 0)} fill={m.liner.back} />
      <Path d={rr(WALL + 4, y0 + 2, W - 8, up + 8, 8, 0)} fill={m.liner.top} opacity={0.8} />
      {/* the freezer box, frosted, its flap and the drip tray under it */}
      <Path d={rr(bx, by, bw, bh, 5)} fill={`url(#${id}al)`} stroke="#8796a2" strokeWidth={1.2} />
      <Path d={`M${n1(bx + 5)} ${n1(by + 3)}Q${n1(bx + bw * 0.3)} ${n1(by + 6.5)} ${n1(bx + bw * 0.5)} ${n1(by + 3)}T${n1(bx + bw - 5)} ${n1(by + 3)}`} stroke="#ffffff" strokeWidth={3} strokeLinecap="round" fill="none" opacity={0.9} />
      <Path d={rr(bx + 3, by + bh * 0.36, bw - 6, bh * 0.58, 3)} fill="#edf2f5" stroke="#9aa8b4" strokeWidth={1} />
      <Rect x={bx + bw * 0.38} y={by + bh * 0.36 + 3} width={bw * 0.24} height={3.2} rx={1.6} fill="#7d8b97" />
      <Rect x={bx + bw * 0.08} y={by + bh * 0.36 + 2} width={bw * 0.2} height={1.4} rx={0.7} fill="#ffffff" opacity={0.9} />
      <Rect x={bx - 2} y={by + bh + 1} width={bw + 4} height={3} rx={1.5} fill="#b2bec8" />
    </Svg>
  );
}

// a restaurant fridge's header: a digital thermometer, a maker's plate and the condenser's louvres
function Header({ m, W, h, w }) {
  const id = useSid();
  const x0 = WALL - 2;
  const pw = W + 4;
  const lw = Math.min(110, W * 0.3);
  const n = 4;
  // the maker's plate, between the thermometer's window and the louvres (none if they leave no room)
  const lcdR = x0 + 8 + 46;
  const louvL = x0 + pw - lw - 8;
  const plW = Math.min(56, louvL - lcdR - 12);
  const plX = (lcdR + louvL) / 2 - plW / 2;
  return (
    <>
      <Svg width={w} height={h} style={styles.abs}>
        <Defs>
          <LG id={`${id}h`} x1="0" y1="0" x2="0" y2="1">
            {spread(['#454d56', '#2a3037', '#1c2126'])}
          </LG>
          <LG id={`${id}p`} x1="0" y1="0" x2="1" y2="0">
            {spread(['#8d97a1', '#e3e7eb', '#b8c0c8', '#f1f3f5', '#9aa4ae'])}
          </LG>
        </Defs>
        <Path d={rr(x0, 3, pw, h - 6, 5)} fill={`url(#${id}h)`} stroke="#0c0f12" strokeWidth={1} />
        <Rect x={x0 + 3} y={4} width={pw - 6} height={1} fill="#ffffff" opacity={0.25} />
        {/* the thermometer's window */}
        <Path d={rr(x0 + 8, h / 2 - 8, 46, 16, 3)} fill="#040506" stroke="#5a6570" strokeWidth={1} />
        <Rect x={x0 + 10} y={h / 2 - 6} width={42} height={2} fill="#ffffff" opacity={0.08} />
        {/* the maker's plate */}
        {plW >= 34 ? <Path d={rr(plX, h / 2 - 6, plW, 12, 2.5)} fill={`url(#${id}p)`} stroke="#3e4852" strokeWidth={0.8} /> : null}
        {plW >= 34 ? [plX + 4, plX + plW - 4].map((cx) => <Circle key={cx} cx={cx} cy={h / 2} r={1.3} fill="#56616c" />) : null}
        {/* the louvres */}
        {Array.from({ length: n }, (_, i) => {
          const y = 7 + i * ((h - 14) / n);
          return (
            <G key={i}>
              <Rect x={x0 + pw - lw - 8} y={y} width={lw} height={(h - 14) / n - 1.5} rx={1} fill="#0b0e11" />
              <Rect x={x0 + pw - lw - 8} y={y} width={lw} height={1.2} fill="#7d8894" opacity={0.7} />
            </G>
          );
        })}
      </Svg>
      <View style={[styles.lcd, { left: x0 + 8, top: h / 2 - 8, width: 46, height: 16 }]}>
        <Text style={styles.lcdText}>3°C</Text>
      </View>
      {plW >= 34 ? (
        <View style={[styles.plateBox, { left: plX + 6, top: h / 2 - 6, width: plW - 12, height: 12 }]}>
          <Text style={styles.plateText} numberOfLines={1}>
            SQUISH
          </Text>
        </View>
      ) : null}
    </>
  );
}

// a slim control strip under the top edge: two status lights and a light bar behind dark glass
function Band({ w, h }) {
  return (
    <Svg width={w} height={h} style={styles.abs}>
      <Path d={rr(w / 2 - 28, h / 2 - 4.5, 56, 9, 4.5)} fill="#0a0d10" opacity={0.88} />
      <Rect x={w / 2 - 25} y={h / 2 - 3.5} width={50} height={1.2} rx={0.6} fill="#ffffff" opacity={0.18} />
      <Circle cx={w / 2 - 17} cy={h / 2} r={2.1} fill="#5fd4ff" />
      <Circle cx={w / 2 - 10} cy={h / 2} r={2.1} fill="#7be884" />
      <Rect x={w / 2 - 3} y={h / 2 - 1} width={22} height={2} rx={1} fill="#5fd4ff" opacity={0.65} />
    </Svg>
  );
}

function Top({ m, w, W, h, up }) {
  switch (m.top.kind) {
    case 'icebox':
      return <IceBox m={m} w={w} W={W} h={h} up={up} />;
    case 'freezer': {
      // the freezer: its own door, the pull on the same side as the fridge's, a snowflake by its hinge
      const free = m.hinge === 'left' ? 'right' : 'left';
      return <Panel m={m} x={WALL} y={3} w={W} h={h - 7} r={10} handle="pocket" free={free} snow={{ x: m.hinge === 'left' ? 18 : W - 18, y: (h - 7) / 2 }} />;
    }
    case 'band':
      return <Band w={w} h={h} />;
    case 'header':
      return <Header m={m} W={W} h={h} w={w} />;
    default:
      return null;
  }
}

// --- below the inside ----------------------------------------------------------------------------------------------

function ChromeStrip({ x, y, w, h }) {
  const id = useSid();
  return (
    <Svg width={w} height={h + 3} style={[styles.abs, { left: x, top: y }]}>
      <Defs>
        <LG id={`${id}N`} x1="0" y1="0" x2="0" y2="1">
          {spread(CHROME)}
        </LG>
      </Defs>
      <Rect x={2} y={3} width={w} height={h} rx={h / 2} fill="#000000" opacity={0.15} />
      <Rect x={0} y={0} width={w} height={h} rx={h / 2} fill={`url(#${id}N)`} stroke="#000000" strokeOpacity={0.3} strokeWidth={0.6} />
      <Rect x={6} y={h * 0.26} width={w - 12} height={Math.max(1, h * 0.14)} rx={1} fill="#ffffff" opacity={0.85} />
    </Svg>
  );
}

function Bottom({ m, W, y, h }) {
  switch (m.bottom.kind) {
    case 'grille':
      return <Grille m={m} x={WALL + 2} y={y + 3} w={W - 4} h={h - 6} dark />;
    case 'kick':
      return <Grille m={m} x={WALL + 6} y={y + 3} w={W - 12} h={h - 6} />;
    case 'chrome':
      return <ChromeStrip x={WALL} y={y + 3} w={W} h={h - 7} />;
    case 'drawer':
      // the freezer drawer, and the grille under it
      return (
        <>
          <Panel m={m} x={WALL} y={y + 4} w={W} h={h - 16} r={8} handle="bar" />
          <Grille m={m} x={WALL + 8} y={y + h - 10} w={W - 16} h={8} dark />
        </>
      );
    case 'drawers':
      return (
        <>
          <Panel m={m} x={WALL} y={y + 4} w={W / 2 - 2} h={h - 16} r={8} handle="bar" />
          <Panel m={m} x={WALL + W / 2 + 2} y={y + 4} w={W / 2 - 2} h={h - 16} r={8} handle="bar" />
          <Grille m={m} x={WALL + 8} y={y + h - 10} w={W - 16} h={8} dark />
        </>
      );
    default:
      return null;
  }
}

// --- what it stands on, and its shadow on the floor ----------------------------------------------------------------

function Feet({ m, w, h }) {
  const id = useSid();
  const at = [w * 0.13, w * 0.87];
  let shapes = null;
  switch (m.feet) {
    case 'legs':
      // a retro fridge's splayed chrome legs, rubber tips
      shapes = at.map((x, i) => {
        const s = i ? 1 : -1;
        return (
          <G key={i}>
            <Path d={`M${n1(x - 7)} 0H${n1(x + 7)}L${n1(x + 3 + s * 5)} ${n1(h - 3)}H${n1(x - 3 + s * 5)}Z`} fill={`url(#${id}M)`} stroke="#3e4852" strokeWidth={0.8} strokeLinejoin="round" />
            <Ellipse cx={x + s * 5} cy={h - 2.5} rx={4.5} ry={2.2} fill="#1d2126" />
          </G>
        );
      });
      break;
    case 'casters':
      shapes = [w * 0.1, w * 0.5, w * 0.9].map((x, i) => (
        <G key={i}>
          <Rect x={x - 9} y={0} width={18} height={4} rx={1.5} fill={`url(#${id}N)`} />
          <Rect x={x - 2} y={4} width={4} height={h * 0.18} fill="#5b6570" />
          <Path d={`M${n1(x - 7)} ${n1(4 + h * 0.18)}H${n1(x + 7)}L${n1(x + 5)} ${n1(h - 6)}H${n1(x - 5)}Z`} fill="#6b7682" stroke="#2f363d" strokeWidth={0.8} />
          <Circle cx={x} cy={h - 7} r={6.5} fill={`url(#${id}W)`} />
          <Circle cx={x} cy={h - 7} r={2.6} fill="#c9d0d7" stroke="#56616c" strokeWidth={0.8} />
          <Path d={`M${n1(x - 4.5)} ${n1(h - 10.5)}Q${n1(x)} ${n1(h - 13.5)} ${n1(x + 4.5)} ${n1(h - 10.5)}`} stroke="#ffffff" strokeOpacity={0.35} strokeWidth={1} fill="none" />
        </G>
      ));
      break;
    case 'nubs':
      shapes = at.map((x, i) => (
        <G key={i}>
          <Path d={rr(x - 9, 0, 18, h, 0, 4)} fill={`url(#${id}R)`} />
          <Rect x={x - 7} y={h - 3} width={14} height={1} rx={0.5} fill="#ffffff" opacity={0.25} />
        </G>
      ));
      break;
    default:
      return null;
  }
  return (
    <Svg width={w} height={h} style={styles.abs}>
      <Defs>
        <LG id={`${id}M`} x1="0" y1="0" x2="1" y2="0">
          {spread(CHROME)}
        </LG>
        <LG id={`${id}N`} x1="0" y1="0" x2="0" y2="1">
          {spread(CHROME)}
        </LG>
        <LG id={`${id}R`} x1="0" y1="0" x2="0" y2="1">
          {spread(['#4a5159', '#23282d', '#0f1214'])}
        </LG>
        <RadialGradient id={`${id}W`} cx="45%" cy="40%" r="60%">
          {spread(['#4b535c', '#22272d', '#0e1013'])}
        </RadialGradient>
      </Defs>
      {shapes}
    </Svg>
  );
}

const FloorShadow = ({ w }) => {
  const id = useSid();
  return (
    <Svg width={w} height={16} style={styles.abs}>
      <Defs>
        <RadialGradient id={`${id}s`} cx="50%" cy="50%" r="50%">
          <Stop offset="0" stopColor="#1a0f08" stopOpacity={0.42} />
          <Stop offset="0.6" stopColor="#1a0f08" stopOpacity={0.18} />
          <Stop offset="1" stopColor="#1a0f08" stopOpacity={0} />
        </RadialGradient>
      </Defs>
      <Ellipse cx={w / 2} cy={8} rx={w / 2} ry={8} fill={`url(#${id}s)`} />
    </Svg>
  );
};

// --- the body ------------------------------------------------------------------------------------------------------

// The cabinet: its outline, the finish with its rounded edges and the bevel's light, the dark base, the gap round the
// opening the doors close over, and the hinge caps.
function Body({ m, g }) {
  const id = useSid();
  const f = m.finish;
  const { bodyW, bodyH, W } = g;
  const [rt, rb] = m.radius;
  const fw = bodyW - 2 * RING;
  const fh = bodyH - 2 * RING - LIP;
  const face = rr(RING, RING, fw, fh, Math.max(2, rt - RING), Math.max(2, rb - RING));
  const doorTop = RING + BORDER + g.top - g.up;
  const dh = g.H + g.crisper + g.up;
  const hinges = m.doors === 1 ? [m.hinge === 'left' ? INSET : INSET + W] : [INSET, INSET + W];
  return (
    <Svg width={bodyW} height={bodyH} style={styles.abs}>
      <Defs>
        <MatDefs id={id} f={f} d={face} />
        <MetalDefs id={id} metal={m.metal} />
        <LG id={`${id}P`} x1="0" y1="0" x2="0" y2="1">
          {spread([f.shade, f.edge])}
        </LG>
      </Defs>
      <Path d={rr(0, 0, bodyW, bodyH, rt, rb)} fill={f.edge} />
      <Path d={rr(RING, bodyH - RING - LIP - 2, fw, LIP + 2, 0, Math.max(1, rb - RING))} fill={`url(#${id}P)`} />
      <MatFill id={id} f={f} d={face} x={RING} y={RING} w={fw} h={fh} />
      <Path d={rr(RING + 1, RING + 1, fw - 2, fh - 2, Math.max(1, rt - RING - 1), Math.max(1, rb - RING - 1))} fill="none" stroke={`url(#${id}B)`} strokeWidth={2} />
      {/* the gap round the doors (and the opening, when they swing open) */}
      <Path d={rr(INSET - 2.5, doorTop - 2.5, W + 5, dh + 5, 7)} fill={f.seam} />
      <Path d={rr(INSET - 1, doorTop - 1, W + 2, dh + 2, 6)} fill="#000000" opacity={0.4} />
      {hinges.map((hx) => (
        <G key={hx}>
          <Path d={rr(hx - 7, doorTop - 6, 14, 5, 2)} fill={`url(#${id}N)`} stroke="#000000" strokeOpacity={0.3} strokeWidth={0.5} />
          <Path d={rr(hx - 7, doorTop + dh + 1, 14, 5, 2)} fill={`url(#${id}N)`} stroke="#000000" strokeOpacity={0.3} strokeWidth={0.5} />
        </G>
      ))}
    </Svg>
  );
}

// --- a door --------------------------------------------------------------------------------------------------------

// its handle, by the edge away from the hinge (`free`)
function HandleArt({ m, id, free, w, h }) {
  const f = m.finish;
  switch (m.handle) {
    case 'recess': {
      // a finger groove moulded into the door's edge
      const gw = 7;
      const x = free === 'right' ? w - gw - 3 : 3;
      const y = h * 0.1;
      const gh = Math.max(20, h * 0.5);
      return (
        <G>
          <Rect x={x} y={y} width={gw} height={gh} rx={3.5} fill={f.shade} />
          <Rect x={free === 'right' ? x : x + gw - 3} y={y + 1} width={3} height={gh - 2} rx={1.5} fill="#000000" opacity={0.3} />
          <Rect x={free === 'right' ? x + gw - 1.4 : x + 0.4} y={y + 2} width={1} height={gh - 4} fill="#ffffff" opacity={0.8} />
          <Rect x={x} y={y} width={gw} height={2} rx={1} fill="#000000" opacity={0.18} />
        </G>
      );
    }
    case 'lever': {
      // a retro chrome lever on its plate
      const lw = Math.min(48, w * 0.34);
      const py = h * 0.34;
      const plateX = free === 'right' ? w - 20 : 6;
      const barX = free === 'right' ? plateX - lw + 10 : plateX + 4;
      return (
        <G>
          <Rect x={plateX + 2} y={py - 13} width={14} height={32} rx={7} fill="#000000" opacity={0.18} />
          <Rect x={plateX} y={py - 15} width={14} height={32} rx={7} fill={`url(#${id}M)`} stroke="#000000" strokeOpacity={0.35} strokeWidth={0.7} />
          <HBar id={id} x={barX} y={py - 4} w={lw} h={9} />
          <Circle cx={free === 'right' ? barX + 2 : barX + lw - 2} cy={py + 0.5} r={6.5} fill={`url(#${id}M)`} stroke="#000000" strokeOpacity={0.35} strokeWidth={0.7} />
          <Circle cx={(free === 'right' ? barX + 2 : barX + lw - 2) - 2} cy={py - 1.5} r={1.8} fill="#ffffff" opacity={0.85} />
        </G>
      );
    }
    case 'pocket': {
      const px = free === 'right' ? w - 16 : 4;
      const py = Math.max(6, h * 0.05);
      const ph = Math.max(22, h * 0.26);
      return (
        <G>
          <Rect x={px + 2} y={py + 3} width={12} height={ph} rx={5} fill="#000000" opacity={0.16} />
          <Rect x={px} y={py} width={12} height={ph} rx={5} fill={`url(#${id}M)`} stroke={f.edge} strokeOpacity={0.5} strokeWidth={0.7} />
          <Rect x={px + 3} y={py + 4} width={6} height={ph - 8} rx={3} fill="#000000" opacity={0.3} />
          <Rect x={px + 1.5} y={py + 2} width={1.6} height={ph - 4} rx={0.8} fill="#ffffff" opacity={0.75} />
        </G>
      );
    }
    case 'bar':
    case 'long': {
      const long = m.handle === 'long';
      const bw = long ? 11 : 8;
      const y0 = h * (long ? 0.16 : 0.12);
      const y1 = h * (long ? 0.62 : 0.66);
      return <VBar id={id} x={free === 'right' ? w - 8 - bw : 8} y={y0} w={bw} h={y1 - y0} />;
    }
    default:
      return null;
  }
}

// what's on the door (its SVG part): a note, a drawing and magnets, a badge and a trim, an ice and water dispenser, a
// display, a lock, a kick plate. `i`: which door (0 the left one or the only one, 1 the right one)
function DecoArt({ m, id, i, hinge, free, w, h }) {
  const f = m.finish;
  const out = [];
  for (const d of m.deco) {
    if (d === 'note') {
      const nw = Math.min(46, w * 0.3, h * 0.55);
      const x = hinge === 'left' ? w * 0.2 : w - w * 0.2 - nw;
      const y = Math.max(8, h * 0.16);
      out.push(
        <G key={d} transform={`rotate(-6 ${n1(x + nw / 2)} ${n1(y + nw / 2)})`}>
          <Rect x={x + 2} y={y + 3} width={nw} height={nw * 1.05} fill="#000000" opacity={0.14} />
          <Rect x={x} y={y} width={nw} height={nw * 1.05} fill="#fff4a8" />
          <Rect x={x} y={y} width={nw} height={nw * 0.18} fill="#ffe86b" />
          {[0.42, 0.58, 0.74].map((k) => (
            <Rect key={k} x={x + nw * 0.16} y={y + nw * k} width={nw * (k > 0.7 ? 0.42 : 0.66)} height={1.4} rx={0.7} fill="#5b7fb0" opacity={0.75} />
          ))}
          <Circle cx={x + nw / 2} cy={y + 1} r={4.5} fill="#e23d4a" />
          <Circle cx={x + nw / 2 - 1.4} cy={y - 0.5} r={1.4} fill="#ffffff" opacity={0.7} />
        </G>,
      );
    } else if (d === 'magnets') {
      // a child's drawing held up by a magnet, a strawberry magnet and a shopping list
      const nw = Math.min(56, w * 0.32);
      const x = hinge === 'left' ? w * 0.14 : w - w * 0.14 - nw;
      const y = h * 0.13;
      const lx = hinge === 'left' ? w * 0.5 : w * 0.5 - nw * 0.62;
      out.push(
        <G key={d}>
          <G transform={`rotate(5 ${n1(x + nw / 2)} ${n1(y + nw * 0.4)})`}>
            <Rect x={x + 2} y={y + 3} width={nw} height={nw * 0.8} fill="#000000" opacity={0.13} />
            <Rect x={x} y={y} width={nw} height={nw * 0.8} fill="#ffffff" />
            <Circle cx={x + nw * 0.24} cy={y + nw * 0.2} r={nw * 0.09} fill="#ffc83a" />
            <Path d={`M${n1(x + nw * 0.08)} ${n1(y + nw * 0.68)}Q${n1(x + nw / 2)} ${n1(y + nw * 0.6)} ${n1(x + nw * 0.92)} ${n1(y + nw * 0.68)}`} stroke="#3ddc97" strokeWidth={2.2} fill="none" strokeLinecap="round" />
            <Circle cx={x + nw * 0.6} cy={y + nw * 0.42} r={nw * 0.15} fill="none" stroke="#ff8a3d" strokeWidth={1.8} />
            <Circle cx={x + nw * 0.55} cy={y + nw * 0.4} r={1} fill="#45107a" />
            <Circle cx={x + nw * 0.65} cy={y + nw * 0.4} r={1} fill="#45107a" />
            <Path d={`M${n1(x + nw * 0.54)} ${n1(y + nw * 0.47)}Q${n1(x + nw * 0.6)} ${n1(y + nw * 0.52)} ${n1(x + nw * 0.66)} ${n1(y + nw * 0.47)}`} stroke="#45107a" strokeWidth={1.1} fill="none" strokeLinecap="round" />
            <Circle cx={x + nw / 2} cy={y + 1} r={4.2} fill="#2f7fd6" />
            <Circle cx={x + nw / 2 - 1.3} cy={y - 0.3} r={1.3} fill="#ffffff" opacity={0.7} />
          </G>
          <G transform={`rotate(-4 ${n1(lx + nw * 0.3)} ${n1(h * 0.52)})`}>
            <Rect x={lx + 2} y={h * 0.44 + 3} width={nw * 0.62} height={nw * 0.9} fill="#000000" opacity={0.12} />
            <Rect x={lx} y={h * 0.44} width={nw * 0.62} height={nw * 0.9} fill="#fdfaf0" />
            {[0.2, 0.36, 0.52, 0.68].map((k) => (
              <Rect key={k} x={lx + nw * 0.08} y={h * 0.44 + nw * k} width={nw * (k > 0.6 ? 0.28 : 0.44)} height={1.3} rx={0.6} fill="#c0392b" opacity={0.7} />
            ))}
            <Path d={`M${n1(lx + nw * 0.31)} ${n1(h * 0.44 - 4)}c-4 0 -6 3 -6 6 0 4 6 8 6 8s6 -4 6 -8c0 -3 -2 -6 -6 -6z`} fill="#ff4a5c" />
            <Path d={`M${n1(lx + nw * 0.31 - 3)} ${n1(h * 0.44 - 4)}l3 2 3 -2`} stroke="#3ddc97" strokeWidth={1.6} fill="none" strokeLinecap="round" />
          </G>
        </G>,
      );
    } else if (d === 'badge') {
      const bw = Math.min(74, w * 0.46);
      const y = Math.max(8, h * 0.08);
      out.push(
        <G key={d}>
          <Rect x={w / 2 - bw / 2 + 1.5} y={y + 2.5} width={bw} height={18} rx={9} fill="#000000" opacity={0.18} />
          <Rect x={w / 2 - bw / 2} y={y} width={bw} height={18} rx={9} fill={`url(#${id}N)`} stroke="#000000" strokeOpacity={0.35} strokeWidth={0.7} />
        </G>,
      );
    } else if (d === 'stripe') {
      out.push(
        <G key={d}>
          <Rect x={7} y={h * 0.9 + 2} width={w - 12} height={4} rx={2} fill="#000000" opacity={0.15} />
          <Rect x={6} y={h * 0.9} width={w - 12} height={4} rx={2} fill={`url(#${id}N)`} />
        </G>,
      );
    } else if (d === 'dispenser' && i === 0) {
      // ice and water: a recess with its controls, a paddle, a light and a drip grille
      const x = w * 0.18;
      const dw = w * 0.64;
      const y = h * 0.13;
      const dh = Math.min(h * 0.3, w * 0.9);
      out.push(
        <G key={d}>
          <Path d={rr(x - 2.5, y - 2.5, dw + 5, dh + 5, 10)} fill={f.seam} />
          <Path d={rr(x, y, dw, dh, 8)} fill={`url(#${id}D)`} />
          <Ellipse cx={x + dw / 2} cy={y + 14} rx={dw * 0.36} ry={8} fill="#5fd4ff" opacity={0.16} />
          <Path d={rr(x + 4, y + 4, dw - 8, 9, 3)} fill="#05070a" stroke="#3a444e" strokeWidth={0.8} />
          <Rect x={x + dw / 2 - 13} y={y + 6.5} width={4} height={4} rx={0.8} fill="#5fd4ff" />
          <Path d={`M${n1(x + dw / 2 - 1)} ${n1(y + 6.3)}q2 2.6 0 4.2q-2 -1.6 0 -4.2z`} fill="#5fd4ff" opacity={0.6} />
          <Circle cx={x + dw / 2 + 10} cy={y + 8.5} r={2} fill="#5fd4ff" opacity={0.6} />
          <Rect x={x + dw * 0.44} y={y + 15} width={dw * 0.12} height={4} rx={1} fill="#6b7682" />
          <Path d={rr(x + dw * 0.3, y + 19, dw * 0.4, dh * 0.42, 4)} fill={`url(#${id}Q)`} stroke="#1c2126" strokeWidth={0.8} />
          <Path d={rr(x + 5, y + dh - 9, dw - 10, 6, 2)} fill="#2c343c" />
          {Array.from({ length: Math.max(3, Math.floor((dw - 14) / 5)) }, (_, k) => (
            <Rect key={k} x={x + 8 + k * 5} y={y + dh - 8} width={2} height={4} rx={1} fill="#0b0e11" />
          ))}
        </G>,
      );
    } else if (d === 'display' && i === 1) {
      out.push(
        <G key={d}>
          <Path d={rr(w * 0.25 - 2, h * 0.16 - 2, w * 0.5 + 4, 26, 7)} fill={f.seam} />
          <Path d={rr(w * 0.25, h * 0.16, w * 0.5, 22, 5)} fill="#05080b" stroke="#3a444e" strokeWidth={0.8} />
          <Rect x={w * 0.25 + 3} y={h * 0.16 + 2} width={w * 0.5 - 6} height={2} rx={1} fill="#ffffff" opacity={0.12} />
        </G>,
      );
    } else if (d === 'lock' && i === 0) {
      const cx = free === 'right' ? w - 15 : 15;
      const cy = h * 0.72;
      out.push(
        <G key={d}>
          <Circle cx={cx + 1.5} cy={cy + 2} r={7} fill="#000000" opacity={0.18} />
          <Circle cx={cx} cy={cy} r={7} fill={`url(#${id}M)`} stroke="#2f363d" strokeWidth={0.8} />
          <Circle cx={cx} cy={cy} r={4.3} fill="#9aa4ae" stroke="#56616c" strokeWidth={0.6} />
          <Rect x={cx - 0.9} y={cy - 2.8} width={1.8} height={5.6} rx={0.9} fill="#2f363d" />
        </G>,
      );
    } else if (d === 'plate') {
      // a kick plate, screwed on
      const ph = Math.max(14, h * 0.1);
      const y = h - ph - 6;
      out.push(
        <G key={d}>
          <Path d={rr(5, y, w - 10, ph, 2)} fill={f.shade} stroke={f.edge} strokeWidth={0.8} />
          <Rect x={7} y={y + 1.5} width={w - 14} height={1} fill="#ffffff" opacity={0.45} />
          {[
            [9, y + 4],
            [w - 9, y + 4],
            [9, y + ph - 4],
            [w - 9, y + ph - 4],
          ].map(([sx, sy]) => (
            <Circle key={`${sx},${sy}`} cx={sx} cy={sy} r={1.6} fill="#c9d0d7" stroke="#3e4852" strokeWidth={0.6} />
          ))}
        </G>,
      );
    }
  }
  return out;
}

// the door's words: a retro badge, a display
function DecoText({ m, i, w, h }) {
  const out = [];
  if (m.deco.includes('badge')) {
    const bw = Math.min(74, w * 0.46);
    out.push(
      <View key="badge" style={[styles.badgeBox, { left: w / 2 - bw / 2, top: Math.max(8, h * 0.08), width: bw, height: 18 }]}>
        <Text style={styles.badgeText} numberOfLines={1}>
          Squishy
        </Text>
      </View>,
    );
  }
  if (m.deco.includes('display') && i === 1)
    out.push(
      <View key="display" style={[styles.displayBox, { left: w * 0.25, top: h * 0.16, width: w * 0.5, height: 22 }]}>
        <Text style={styles.displayText}>3°C</Text>
        <Text style={[styles.displayText, styles.displaySmall]}>ECO</Text>
      </View>,
    );
  return out;
}

// The door's outside: the finish with its bevel and reflection, a little shade on its hinge edge, what's on it and its
// handle.
function DoorFront({ m, i, hinge, w, h }) {
  const id = useSid();
  const f = m.finish;
  const r = doorRadius(m);
  const free = hinge === 'left' ? 'right' : 'left';
  const face = rr(1, 1, w - 2, h - 2, Math.max(1, r - 1));
  return (
    <View style={StyleSheet.absoluteFill}>
      <Svg width={w} height={h} style={styles.abs}>
        <Defs>
          <MatDefs id={id} f={f} d={face} />
          <MetalDefs id={id} metal={m.metal} />
          <LG id={`${id}D`} x1="0" y1="0" x2="0" y2="1">
            {spread(['#262d34', '#151a1f', '#0b0e11'])}
          </LG>
          <LG id={`${id}Q`} x1="0" y1="0" x2="1" y2="0">
            {spread(['#3a424b', '#6b7682', '#4b545e'])}
          </LG>
        </Defs>
        <Path d={rr(0, 0, w, h, r)} fill={f.edge} />
        <MatFill id={id} f={f} d={face} x={1} y={1} w={w - 2} h={h - 2} />
        <Path d={rr(2, 2, w - 4, h - 4, Math.max(1, r - 2))} fill="none" stroke={`url(#${id}B)`} strokeWidth={1.6} />
        <Rect x={hinge === 'left' ? 1 : w - 7} y={2} width={6} height={h - 4} fill="#000000" opacity={0.07} />
        <DecoArt m={m} id={id} i={i} hinge={hinge} free={free} w={w} h={h} />
        <HandleArt m={m} id={id} free={free} w={w} h={h} />
      </Svg>
      <DecoText m={m} i={i} w={w} h={h} />
    </View>
  );
}
const doorRadius = (m) => Math.min(10, m.radius[1]);

// what stands in a door bin: bottles, cartons, a jug, cans, eggs (each standing on `b`, `w` wide and `h` high from `x`)
function Bottle({ x, b, w, h, body, cap, label }) {
  return (
    <G>
      <Path d={`M${n1(x)} ${n1(b)}V${n1(b - h * 0.6)}Q${n1(x)} ${n1(b - h * 0.78)} ${n1(x + w * 0.32)} ${n1(b - h * 0.84)}V${n1(b - h)}H${n1(x + w * 0.68)}V${n1(b - h * 0.84)}Q${n1(x + w)} ${n1(b - h * 0.78)} ${n1(x + w)} ${n1(b - h * 0.6)}V${n1(b)}Z`} fill={body} />
      <Rect x={x + w * 0.26} y={b - h - 3} width={w * 0.48} height={4} rx={1} fill={cap} />
      {label ? <Rect x={x} y={b - h * 0.5} width={w} height={h * 0.24} fill={label} /> : null}
      <Rect x={x + w * 0.16} y={b - h * 0.58} width={Math.max(1, w * 0.12)} height={h * 0.5} rx={0.8} fill="#ffffff" opacity={0.5} />
    </G>
  );
}
function Carton({ x, b, w, h, body, top }) {
  return (
    <G>
      <Rect x={x} y={b - h * 0.84} width={w} height={h * 0.84} fill={body} />
      <Path d={`M${n1(x)} ${n1(b - h * 0.84)}L${n1(x + w / 2)} ${n1(b - h)}L${n1(x + w)} ${n1(b - h * 0.84)}Z`} fill={top} />
      <Rect x={x + w * 0.38} y={b - h - 2} width={w * 0.24} height={3} fill={top} />
      <Rect x={x} y={b - h * 0.56} width={w} height={h * 0.2} fill="#ffffff" opacity={0.85} />
      <Rect x={x + w * 0.08} y={b - h * 0.82} width={Math.max(1, w * 0.14)} height={h * 0.78} fill="#ffffff" opacity={0.28} />
    </G>
  );
}
function Jug({ x, b, w, h }) {
  return (
    <G>
      <Path d={`M${n1(x)} ${n1(b)}V${n1(b - h * 0.7)}Q${n1(x)} ${n1(b - h * 0.86)} ${n1(x + w * 0.3)} ${n1(b - h * 0.88)}V${n1(b - h)}H${n1(x + w * 0.6)}V${n1(b - h * 0.88)}Q${n1(x + w)} ${n1(b - h * 0.86)} ${n1(x + w)} ${n1(b - h * 0.7)}V${n1(b)}Z`} fill="#fbfdff" stroke="#c9d6e0" strokeWidth={0.7} />
      <Path d={`M${n1(x + w * 0.72)} ${n1(b - h * 0.78)}Q${n1(x + w * 1.06)} ${n1(b - h * 0.6)} ${n1(x + w * 0.74)} ${n1(b - h * 0.42)}`} stroke="#dbe5ec" strokeWidth={2} fill="none" />
      <Rect x={x + w * 0.26} y={b - h - 3} width={w * 0.38} height={4} rx={1} fill="#2f7fd6" />
      <Rect x={x + w * 0.1} y={b - h * 0.45} width={w * 0.6} height={h * 0.18} rx={1} fill="#5fb8ff" opacity={0.7} />
    </G>
  );
}
function Can({ x, b, w, h, body }) {
  return (
    <G>
      <Rect x={x} y={b - h} width={w} height={h} rx={w * 0.12} fill={body} />
      <Rect x={x} y={b - h} width={w} height={h * 0.1} rx={w * 0.1} fill="#d6dde3" />
      <Rect x={x + w * 0.16} y={b - h * 0.86} width={Math.max(1, w * 0.16)} height={h * 0.76} fill="#ffffff" opacity={0.45} />
      <Rect x={x} y={b - h * 0.55} width={w} height={h * 0.12} fill="#ffffff" opacity={0.75} />
    </G>
  );
}
function Eggs({ x0, x1, b, s }) {
  const n = Math.max(2, Math.floor((x1 - x0) / (s * 0.7)));
  const step = (x1 - x0) / n;
  return (
    <G>
      {Array.from({ length: n }, (_, k) => (
        <G key={k}>
          <Ellipse cx={x0 + step * (k + 0.5)} cy={b - s * 0.62} rx={s * 0.29} ry={s * 0.38} fill="#fff1db" stroke="#dcc6a0" strokeWidth={0.7} />
          <Ellipse cx={x0 + step * (k + 0.5) - s * 0.09} cy={b - s * 0.76} rx={s * 0.07} ry={s * 0.12} fill="#ffffff" opacity={0.9} />
        </G>
      ))}
    </G>
  );
}
// a bin's things, by which bin it is
function binThings(k, bins, x0, x1, b, h) {
  const W = x1 - x0;
  if (k === 0 && bins >= 2) return <Eggs x0={x0} x1={x1} b={b} s={Math.min(h * 0.95, 24)} />;
  const set = k % 3;
  if (set === 0 || bins === 1)
    return (
      <G>
        <Jug x={x0 + W * 0.02} b={b} w={W * 0.26} h={h} />
        <Carton x={x0 + W * 0.36} b={b} w={W * 0.24} h={h * 0.92} body="#ff9a2e" top="#ffd23a" />
        <Bottle x={x0 + W * 0.7} b={b} w={W * 0.22} h={h * 0.95} body="#e8303f" cap="#ffffff" label="#ffd23a" />
      </G>
    );
  if (set === 1)
    return (
      <G>
        <Bottle x={x0 + W * 0.02} b={b} w={W * 0.22} h={h} body="#9fd8f6" cap="#2f7fd6" label="#5fb8ff" />
        <Can x={x0 + W * 0.32} b={b} w={W * 0.18} h={h * 0.62} body="#e23d4a" />
        <Can x={x0 + W * 0.54} b={b} w={W * 0.18} h={h * 0.62} body="#2fbf71" />
        <Bottle x={x0 + W * 0.76} b={b} w={W * 0.2} h={h * 0.86} body="#ffd23a" cap="#c0392b" />
      </G>
    );
  return (
    <G>
      <Carton x={x0 + W * 0.04} b={b} w={W * 0.26} h={h} body="#ffffff" top="#5fb8ff" />
      <Bottle x={x0 + W * 0.38} b={b} w={W * 0.22} h={h * 0.9} body="#7b3fa0" cap="#ffd23a" label="#ffffff" />
      <Bottle x={x0 + W * 0.68} b={b} w={W * 0.24} h={h * 0.8} body="#3ddc97" cap="#ffffff" />
    </G>
  );
}

// The door's inside (seen when it swings open): its edge, the rubber gasket round it, the moulded liner and the
// bins with what's in them.
function DoorBack({ m, w, h }) {
  const id = useSid();
  const r = doorRadius(m);
  const bins = Math.max(1, Math.min(5, Math.round(h / 85)));
  return (
    <Svg width={w} height={h} style={styles.abs}>
      <Defs>
        <LG id={`${id}l`} x1="0" y1="0" x2="1" y2="0">
          {spread(['#dfe6ec', '#f7f9fb', '#eef2f5', '#d8e0e7'])}
        </LG>
        <LG id={`${id}b`} x1="0" y1="0" x2="0" y2="1">
          <Stop offset="0" stopColor="#e9f6fd" stopOpacity={0.55} />
          <Stop offset="1" stopColor="#9cc9e4" stopOpacity={0.85} />
        </LG>
      </Defs>
      <Path d={rr(0, 0, w, h, r)} fill={m.finish.edge} />
      <Path d={rr(1.5, 1.5, w - 3, h - 3, Math.max(1, r - 1))} fill={`url(#${id}l)`} />
      {/* the gasket */}
      <Path d={rr(4, 4, w - 8, h - 8, Math.max(1, r - 1))} fill="none" stroke="#a6b1bb" strokeWidth={5} />
      <Path d={rr(2.6, 2.6, w - 5.2, h - 5.2, Math.max(1, r - 1))} fill="none" stroke="#dde3e8" strokeWidth={1} />
      <Path d={rr(6.8, 6.8, w - 13.6, h - 13.6, Math.max(1, r - 2))} fill="none" stroke="#76828d" strokeWidth={0.8} opacity={0.7} />
      {/* the moulded panel */}
      <Path d={rr(10, 10, w - 20, h - 20, 6)} fill="#ffffff" opacity={0.6} stroke="#c3cdd5" strokeWidth={1} />
      {Array.from({ length: bins }, (_, k) => {
        const y = (h * (k + 0.78)) / bins - 6;
        const ih = Math.min(34, (h / bins) * 0.62);
        return (
          <G key={k}>
            {binThings(k, bins, 14, w - 14, y + 9, ih)}
            <Path d={rr(9, y - 2, w - 18, 13, 3)} fill={`url(#${id}b)`} stroke="#7aa6c2" strokeWidth={0.9} />
            <Rect x={11} y={y - 1.2} width={w - 22} height={1.4} rx={0.7} fill="#ffffff" opacity={0.95} />
            <Rect x={9} y={y + 11} width={w - 18} height={2} fill="#000000" opacity={0.1} />
          </G>
        );
      })}
    </Svg>
  );
}

// One door, `w` × `h` at `x`, turning about its `hinge` edge by `deg`. Past 90° its inside shows: swapped by the
// angle, as Android's backfaceVisibility only goes by a view's own turn, not its parent's (the open door showed its
// outside).
function Door({ m, i, hinge, x, w, h, door, deg, persp }) {
  const sign = hinge === 'left' ? -1 : 1;
  const rotateY = door.interpolate({ inputRange: [0, 1], outputRange: ['0deg', `${sign * deg}deg`] });
  const transform = [{ perspective: persp }, { translateX: (sign * w) / 2 }, { rotateY }, { translateX: (-sign * w) / 2 }];
  const f = Math.min(0.998, 90 / deg);
  const front = door.interpolate({ inputRange: [0, f, f + 0.001, 1], outputRange: [1, 1, 0, 0] });
  const back = door.interpolate({ inputRange: [0, f, f + 0.001, 1], outputRange: [0, 0, 1, 1] });
  return (
    <Animated.View pointerEvents="none" style={[styles.door, { left: x, width: w, height: h, transform }]}>
      <Animated.View style={[StyleSheet.absoluteFill, { opacity: front }]}>
        <DoorFront m={m} i={i} hinge={hinge} w={w} h={h} />
      </Animated.View>
      <Animated.View style={[StyleSheet.absoluteFill, { opacity: back, transform: [{ scaleX: -1 }] }]}>
        <DoorBack m={m} w={w} h={h} />
      </Animated.View>
    </Animated.View>
  );
}

// --- the inside ----------------------------------------------------------------------------------------------------

// vegetables in a salad drawer: lettuce in the left one, tomatoes and carrots in the right one
function Veg({ k, x, y, w, h }) {
  if (k === 0) {
    const r = Math.min(h * 0.42, w * 0.16);
    return (
      <G>
        {[0.22, 0.45, 0.68].map((u, j) => (
          <G key={u}>
            <Circle cx={x + w * u} cy={y + h * 0.58} r={r * (j === 1 ? 1.15 : 1)} fill={j === 1 ? '#5fc96b' : '#7bdc6f'} />
            <Path d={`M${n1(x + w * u)} ${n1(y + h * 0.58 - r * 0.8)}V${n1(y + h * 0.58 + r * 0.8)}M${n1(x + w * u)} ${n1(y + h * 0.58)}l${n1(-r * 0.5)} ${n1(-r * 0.4)}M${n1(x + w * u)} ${n1(y + h * 0.58)}l${n1(r * 0.5)} ${n1(-r * 0.4)}`} stroke="#c9f5c0" strokeWidth={1} fill="none" />
          </G>
        ))}
        <Circle cx={x + w * 0.88} cy={y + h * 0.66} r={r * 0.7} fill="#9c5fd0" />
      </G>
    );
  }
  const r = Math.min(h * 0.32, w * 0.12);
  return (
    <G>
      {[0.2, 0.42].map((u) => (
        <G key={u}>
          <Circle cx={x + w * u} cy={y + h * 0.62} r={r} fill="#ef3b2d" />
          <Circle cx={x + w * u - r * 0.35} cy={y + h * 0.62 - r * 0.35} r={r * 0.28} fill="#ffffff" opacity={0.6} />
          <Path d={`M${n1(x + w * u - r * 0.4)} ${n1(y + h * 0.62 - r)}l${n1(r * 0.4)} ${n1(r * 0.3)} ${n1(r * 0.4)} ${n1(-r * 0.3)}`} stroke="#2e9e4f" strokeWidth={1.4} fill="none" />
        </G>
      ))}
      {[0.62, 0.8].map((u, j) => (
        <G key={u} transform={`rotate(${j ? 14 : -10} ${n1(x + w * u)} ${n1(y + h * 0.6)})`}>
          <Path d={`M${n1(x + w * u - r * 0.5)} ${n1(y + h * 0.3)}H${n1(x + w * u + r * 0.5)}L${n1(x + w * u)} ${n1(y + h)}Z`} fill="#ff8a1e" />
          <Path d={`M${n1(x + w * u)} ${n1(y + h * 0.3)}l-2.5 -5M${n1(x + w * u)} ${n1(y + h * 0.3)}l2.5 -5M${n1(x + w * u)} ${n1(y + h * 0.3)}v-6`} stroke="#3ddc6a" strokeWidth={1.4} fill="none" strokeLinecap="round" />
        </G>
      ))}
    </G>
  );
}

function Inside({ m, g, light, inside, slots }) {
  const id = useSid();
  const L = m.liner;
  const { S, W, H, rows, cols, crisper } = g;
  const hd = H + crisper;
  const wire = m.shelf === 'wire';
  // how deep it looks: the side walls' width, the ceiling's and the floor's height, a shelf's top seen from above
  const d = Math.max(5, Math.min(14, Math.round(S * 0.12)));
  const bt = d;
  const bb = hd - Math.round(d * 0.7);
  const dd = Math.max(3, d * 0.55);
  const shelves = Array.from({ length: rows }, (_, r) => (r + 1) * (S + SHELF) - SHELF);
  // the back wall's ribs
  let ribs = '';
  const nr = Math.max(2, cols * 2);
  for (let k = 1; k < nr; k++) ribs += `M${n1(d + ((W - 2 * d) * k) / nr)} ${bt}V${bb}`;
  return (
    <View style={[styles.inside, { left: INSET, top: RING + BORDER + g.top, width: W, height: hd }]}>
      <Svg width={W} height={hd} style={styles.abs}>
        <Defs>
          <LG id={`${id}bk`} x1="0" y1="0" x2="0" y2="1">
            {spread([L.top, L.bottom])}
          </LG>
          <LG id={`${id}lw`} x1="0" y1="0" x2="1" y2="0">
            {spread([L.front, L.back])}
          </LG>
          <LG id={`${id}rw`} x1="1" y1="0" x2="0" y2="0">
            {spread([L.front, L.back])}
          </LG>
          <LG id={`${id}cl`} x1="0" y1="0" x2="0" y2="1">
            {spread(['#ffffff', L.back])}
          </LG>
          <LG id={`${id}fl`} x1="0" y1="1" x2="0" y2="0">
            {spread([L.front, L.back])}
          </LG>
          <LG id={`${id}tr`} x1="0" y1="0" x2="0" y2="1">
            {spread(['#ffffff', '#eef3f6', '#c0ccd5'])}
          </LG>
          <LG id={`${id}sh`} x1="0" y1="0" x2="0" y2="1">
            <Stop offset="0" stopColor="#36495a" stopOpacity={0.2} />
            <Stop offset="1" stopColor="#36495a" stopOpacity={0} />
          </LG>
          <LG id={`${id}cr`} x1="0" y1="0" x2="0" y2="1">
            <Stop offset="0" stopColor="#f2fafe" stopOpacity={0.5} />
            <Stop offset="1" stopColor="#a9d2ea" stopOpacity={0.78} />
          </LG>
          <LG id={`${id}rod`} x1="0" y1="0" x2="0" y2="1">
            {spread(CHROME)}
          </LG>
        </Defs>
        <Rect x={0} y={0} width={W} height={hd} fill={L.back} />
        {/* the back wall, its ribs and its vent */}
        <Rect x={d} y={bt} width={W - 2 * d} height={bb - bt} fill={`url(#${id}bk)`} />
        <Path d={ribs} stroke={L.rib} strokeWidth={1} opacity={0.45} />
        <Path d={rr(W / 2 - 20, bt + 3, 40, 9, 3)} fill={L.rib} opacity={0.55} />
        {[0, 1, 2, 3, 4].map((k) => (
          <Rect key={k} x={W / 2 - 16 + k * 7} y={bt + 5} width={4} height={5} rx={1} fill="#7c8d9b" opacity={0.6} />
        ))}
        {/* the ceiling, the side walls and the floor */}
        <Path d={`M0 0H${W}L${W - d} ${bt}H${d}Z`} fill={`url(#${id}cl)`} />
        <Path d={`M0 0L${d} ${bt}V${bb}L0 ${hd}Z`} fill={`url(#${id}lw)`} />
        <Path d={`M${W} 0L${W - d} ${bt}V${bb}L${W} ${hd}Z`} fill={`url(#${id}rw)`} />
        <Path d={`M0 ${hd}L${d} ${bb}H${W - d}L${W} ${hd}Z`} fill={`url(#${id}fl)`} />
        <Path d={`M0 0L${d} ${bt}M${W} 0L${W - d} ${bt}M0 ${hd}L${d} ${bb}M${W} ${hd}L${W - d} ${bb}M${d} ${bt}V${bb}M${W - d} ${bt}V${bb}`} stroke={L.rib} strokeWidth={0.8} opacity={0.7} />
        {/* the LED strip, unlit */}
        <Rect x={d + 4} y={1} width={W - 2 * d - 8} height={3} rx={1.5} fill="#d5e0e7" />
        {/* the shelves: glass or wire, each on its supports, its shadow below it */}
        {shelves.map((y, r) => (
          <G key={r}>
            <Rect x={d} y={y + SHELF} width={W - 2 * d} height={Math.min(12, S * 0.14)} fill={`url(#${id}sh)`} />
            <Path d={`M0 ${n1(y + SHELF * 0.6)}L${d} ${n1(y - dd + 2)}M${W} ${n1(y + SHELF * 0.6)}L${W - d} ${n1(y - dd + 2)}`} stroke={L.rib} strokeWidth={2.4} />
            {wire ? (
              <G>
                <Path
                  d={Array.from({ length: Math.max(3, Math.floor(W / 9)) }, (_, k) => {
                    const x = 4 + (k * (W - 8)) / Math.max(2, Math.floor(W / 9) - 1);
                    return `M${n1(x)} ${n1(y + 1)}L${n1(d + (x / W) * (W - 2 * d))} ${n1(y - dd)}`;
                  }).join('')}
                  stroke="#8f9aa5"
                  strokeWidth={1}
                />
                <Path d={`M${d} ${n1(y - dd)}H${W - d}`} stroke="#8f9aa5" strokeWidth={1.4} />
                <Rect x={0} y={y} width={W} height={3.5} rx={1.75} fill={`url(#${id}rod)`} />
                <Rect x={0} y={y + 5} width={W} height={2} rx={1} fill={`url(#${id}rod)`} opacity={0.85} />
              </G>
            ) : (
              <G>
                <Path d={`M1 ${n1(y)}L${d} ${n1(y - dd)}H${W - d}L${W - 1} ${n1(y)}Z`} fill="#cbe7f5" opacity={0.5} />
                <Path d={`M${d} ${n1(y - dd)}H${W - d}`} stroke="#ffffff" strokeOpacity={0.85} strokeWidth={0.8} />
                <Rect x={0} y={y} width={W} height={SHELF} fill={`url(#${id}tr)`} />
                <Rect x={0} y={y} width={W} height={1.3} fill="#8fd0ec" />
                <Rect x={0} y={y + SHELF - 1} width={W} height={1} fill="#7f909e" opacity={0.75} />
                <Rect x={W * 0.08} y={y + 2.4} width={W * 0.24} height={1.2} rx={0.6} fill="#ffffff" />
              </G>
            )}
          </G>
        ))}
        {/* the salad drawers: the vegetables through their frosted fronts */}
        {crisper
          ? [0, 1].map((k) => {
              const x = k ? W / 2 + 2 : 4;
              const cw = W / 2 - 6;
              const cy = H + 2;
              const ch = crisper - 6;
              return (
                <G key={k}>
                  <Veg k={k} x={x} y={cy} w={cw} h={ch} />
                  <Path d={rr(x, cy, cw, ch, 5)} fill={`url(#${id}cr)`} stroke="#86aac0" strokeWidth={1.2} />
                  <Rect x={x + 3} y={cy + 1.6} width={cw - 6} height={2} rx={1} fill="#ffffff" opacity={0.95} />
                  <Rect x={x + cw * 0.36} y={cy + 5} width={cw * 0.28} height={4} rx={2} fill="#4f6f84" opacity={0.45} />
                  <Path d={`M${n1(x + cw * 0.6)} ${n1(cy + ch - 3)}L${n1(x + cw * 0.74)} ${n1(cy + 6)}M${n1(x + cw * 0.7)} ${n1(cy + ch - 3)}L${n1(x + cw * 0.78)} ${n1(cy + 10)}`} stroke="#ffffff" strokeOpacity={0.55} strokeWidth={1.6} />
                </G>
              );
            })
          : null}
      </Svg>
      {/* the lamp: the LED strip lit and its glow down the inside */}
      <Animated.View pointerEvents="none" style={[StyleSheet.absoluteFill, { opacity: light }]}>
        <Svg width={W} height={hd} style={StyleSheet.absoluteFill}>
          <Defs>
            <RadialGradient id={`${id}lamp`} cx="50%" cy="0%" r="85%">
              <Stop offset="0" stopColor="#ffffff" stopOpacity={0.9} />
              <Stop offset="0.45" stopColor="#f2fbff" stopOpacity={0.32} />
              <Stop offset="1" stopColor="#f2fbff" stopOpacity={0} />
            </RadialGradient>
            <LG id={`${id}led`} x1="0" y1="0" x2="0" y2="1">
              <Stop offset="0" stopColor="#ffffff" stopOpacity={0.95} />
              <Stop offset="1" stopColor="#ffffff" stopOpacity={0} />
            </LG>
          </Defs>
          <Rect x={0} y={0} width={W} height={hd} fill={`url(#${id}lamp)`} />
          <Rect x={d + 4} y={0} width={W - 2 * d - 8} height={12} fill={`url(#${id}led)`} />
          <Rect x={d + 4} y={1} width={W - 2 * d - 8} height={3} rx={1.5} fill="#ffffff" />
        </Svg>
      </Animated.View>
      {/* the empty spots, while putting them back */}
      {slots
        ? Array.from({ length: rows * cols }, (_, i) => (
            <View key={i} style={[styles.slotMark, { left: (i % cols) * S + S * 0.1, top: Math.floor(i / cols) * (S + SHELF) + S * 0.1, width: S * 0.8, height: S * 0.8, borderRadius: S * 0.22 }]} />
          ))
        : null}
      {inside}
    </View>
  );
}

// --- the whole thing -------------------------------------------------------------------------------------------------

// `still`: shut for good, no inside drawn (the map's pictures)
function Container({ m, g, door, light, inside, slots, still = false }) {
  const { W, H, crisper, top, up, bodyW, bodyH, feet } = g;
  const dh = H + crisper + up;
  return (
    <View pointerEvents="none" style={{ width: bodyW, height: bodyH + feet }}>
      {/* its shadow on the floor, then its feet */}
      <View style={[styles.abs, { left: -bodyW * 0.08, top: bodyH + feet - 9, width: bodyW * 1.16, height: 16 }]}>
        <FloorShadow w={bodyW * 1.16} />
      </View>
      {feet ? (
        <View style={[styles.abs, { top: bodyH - 6 }]}>
          <Feet m={m} w={bodyW} h={feet + 6} />
        </View>
      ) : null}
      <Body m={m} g={g} />
      {/* what's above and below the inside, in the face's own space */}
      <View style={[styles.abs, { left: RING + BORDER, top: RING + BORDER, width: bodyW - 2 * (RING + BORDER), height: bodyH - 2 * (RING + BORDER) - LIP }]}>
        <Top m={m} w={bodyW - 2 * (RING + BORDER)} W={W} h={top} up={up} />
        <Bottom m={m} W={W} y={top + H + crisper} h={g.bottom} />
      </View>
      {still ? null : <Inside m={m} g={g} light={light} inside={inside} slots={slots} />}
      {/* the doors */}
      <View style={[styles.doors, { left: INSET, top: RING + BORDER + top - up, width: W, height: dh }]} pointerEvents="none">
        {m.doors === 1 ? (
          <Door m={m} i={0} hinge={m.hinge} x={0} w={W} h={dh} door={door} deg={g.deg} persp={g.persp} />
        ) : (
          <>
            <Door m={m} i={0} hinge="left" x={0} w={W / 2} h={dh} door={door} deg={g.deg} persp={g.persp} />
            <Door m={m} i={1} hinge="right" x={W / 2} w={W / 2} h={dh} door={door} deg={g.deg} persp={g.persp} />
          </>
        )}
      </View>
    </View>
  );
}

export default memo(Container);

// --- a small one, for the game picker and the map ---------------------------------------------------------------------

const SHUT = new Animated.Value(0);
const LIT = new Animated.Value(1);

// A fridge drawn full size and shrunk to fit `size` wide (a little more high): `m` the model (else the BIG one), `rows`
// × `cols` its shelves; `door` (Animated) opens and closes it (it opens to 90° so the door stays close), a squishy or
// two inside. Without `door` it stays shut.
export const MiniContainer = memo(function MiniContainer({ m, rows = 2, cols, size = 92, door, uris = [] }) {
  const model = m || modelOf('fridge', 2);
  const C = cols || (model.doors === 2 ? 4 : 3);
  const g = { ...sizes(model, rows, C, 64), deg: 90 };
  const k = Math.min(size / g.bodyW, (size * 1.3) / (g.bodyH + g.feet));
  const spots = [0, C - 1, C + 1];
  const inside = door
    ? uris.slice(0, 3).map((u, i) => {
        const s = spots[i] % (rows * C);
        return <Animated.Image key={i} source={{ uri: u }} resizeMode="contain" fadeDuration={0} style={[styles.abs, { left: (s % C) * g.S + 6, top: Math.floor(s / C) * (g.S + SHELF) + 6, width: g.S - 12, height: g.S - 12 }]} />;
      })
    : null;
  return (
    <View pointerEvents="none" style={{ width: g.bodyW * k, height: (g.bodyH + g.feet) * k }}>
      <View style={[styles.abs, { left: (g.bodyW * k - g.bodyW) / 2, top: ((g.bodyH + g.feet) * k - (g.bodyH + g.feet)) / 2, transform: [{ scale: k }] }]}>
        <Container m={model} g={g} door={door || SHUT} light={LIT} inside={inside} slots={false} still={!door} />
      </View>
    </View>
  );
});

const styles = StyleSheet.create({
  abs: { position: 'absolute', left: 0, top: 0 },
  inside: { position: 'absolute', overflow: 'hidden', borderRadius: 4 },
  slotMark: { position: 'absolute', borderWidth: 2.5, borderStyle: 'dashed', borderColor: '#9ccbe4' },
  doors: { position: 'absolute' },
  door: { position: 'absolute', top: 0 },
  lcd: { position: 'absolute', alignItems: 'center', justifyContent: 'center' },
  lcdText: { fontFamily: F.display, fontSize: 11, color: '#ff4a3d', includeFontPadding: false, letterSpacing: 0.6 },
  plateBox: { position: 'absolute', alignItems: 'center', justifyContent: 'center' },
  plateText: { fontFamily: F.display, fontSize: 7.5, color: '#3e4852', includeFontPadding: false, letterSpacing: 1.6 },
  badgeBox: { position: 'absolute', alignItems: 'center', justifyContent: 'center' },
  badgeText: { fontFamily: F.display, fontSize: 10.5, fontStyle: 'italic', letterSpacing: 0.6, color: '#2f3a44', includeFontPadding: false },
  displayBox: { position: 'absolute', flexDirection: 'row', alignItems: 'center', justifyContent: 'center', gap: 5 },
  displayText: { fontFamily: F.display, fontSize: 11, color: '#5fd4ff', includeFontPadding: false },
  displaySmall: { fontSize: 7.5, color: '#7be884', letterSpacing: 0.8 },
});
