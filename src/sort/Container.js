import React, { memo } from 'react';
import { Animated, StyleSheet, Text, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Circle, Defs, Ellipse, Path, RadialGradient, Rect, Stop } from 'react-native-svg';
import { F } from '../squishdoku/theme';
import { modelOf } from './models';

// The fridge (or the cupboard), drawn as the real thing it is (models.js:
// a mini fridge up to a restaurant fridge, a bedside cabinet up to a giant
// wardrobe): its body with a lip, what's above and below the inside
// (freezer doors, drawers, a crown, a grille), the lit inside with its
// shelves (glass, wire or wood) and salad drawers, one door or two swinging
// on their hinges, and what it stands on. `door` (Animated, 0 shut → 1 open)
// and `light` (0 → 1, the lamp) are the game's; `inside` is drawn between
// the shelves and the doors (the squishies on show), `slots` marks the
// empty spots. Sizes come from geometry() so the game can hit-test the
// same rects it draws.

export const RING = 3;
export const BORDER = 3;
export const WALL = 8;
export const SHELF = 8;
const LIP = 7;
const FEET = { none: 0, nubs: 7, legs: 16, casters: 16, tapered: 14, balls: 12, buns: 11, bracket: 10 };
// the doors open as far as the room either side allows
const DEGS = [106, 102, 98, 94, 90];
const INSET = RING + BORDER + WALL;

// how far a door `dw` wide, opened `deg` with perspective `p`, reaches past
// its hinge on screen (it turns about the hinge; the perspective, about its
// middle, makes the near edge bigger)
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

// Where everything goes for a `rows` × `cols` `model` in a `w` × `h` area,
// leaving `trayH` at the bottom: big (the user, 2026-10-24: "the fridge
// needs to be bigger"), wider for the bigger models, but with room for the
// open doors ("so we can see the doors"): two doors leave it either side, a
// lone door on its hinge's side. S: one spot's side.
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

// --- little things -------------------------------------------------------------------------

const Fill = ({ colors, start, end, locations }) => <LinearGradient colors={colors} start={start} end={end} locations={locations} style={StyleSheet.absoluteFill} />;
const ACROSS = { start: { x: 0, y: 0 }, end: { x: 1, y: 0 } };
const HEART_D = 'M12 20 C5 14.5 2 11 2 7 C2 4 4.3 2 7 2 C9 2 10.8 3.2 12 5 C13.2 3.2 15 2 17 2 C19.7 2 22 4 22 7 C22 11 19 14.5 12 20 Z';
const STAR_D = 'M12 2.5 L14.6 8.6 L21.2 9.2 L16.2 13.5 L17.7 20 L12 16.6 L6.3 20 L7.8 13.5 L2.8 9.2 L9.4 8.6 Z';

// a bar handle (chrome or brass), upright or lying down
function Bar({ c, style, flat }) {
  return (
    <View style={[styles.bar, style]}>
      <Fill colors={c.handle} {...(flat ? {} : ACROSS)} />
    </View>
  );
}
const Knob = ({ c, size = 16, style }) => (
  <View style={[styles.knob, { width: size, height: size, borderRadius: size / 2 }, style]}>
    <Fill colors={c.handle} />
  </View>
);
// a drawer front with a handle (fridge: a long bar; cupboard: a pull or a knob)
function Drawer({ m, x, y, w, h, knob }) {
  const c = m.c;
  return (
    <View style={[styles.panel, { left: x, top: y, width: w, height: h, borderColor: c.trim, borderRadius: m.kind === 'fridge' ? 8 : 4 }]}>
      <Fill colors={c.door} />
      <View style={styles.panelShine} />
      {m.kind === 'fridge' ? (
        <Bar c={c} flat style={{ left: w * 0.18, right: w * 0.18, top: Math.min(8, h * 0.2), height: 8 }} />
      ) : knob ? (
        <Knob c={c} size={Math.min(14, h * 0.45)} style={{ left: w / 2 - Math.min(14, h * 0.45) / 2 - 2, top: h / 2 - Math.min(14, h * 0.45) / 2 - 2 }} />
      ) : (
        <Bar c={c} flat style={{ left: w / 2 - Math.min(22, w * 0.18), width: Math.min(44, w * 0.36), top: h / 2 - 5, height: 7 }} />
      )}
    </View>
  );
}
// a kick-plate grille: a dark strip with upright slits
function Grille({ x, y, w, h, color }) {
  const n = Math.max(3, Math.floor((w - 12) / 9));
  let d = '';
  for (let i = 0; i < n; i++) {
    const sx = 6 + ((w - 12) * (i + 0.5)) / n;
    d += `M${sx.toFixed(1)} 3 V${h - 3} `;
  }
  return (
    <View style={[styles.grille, { left: x, top: y, width: w, height: h, backgroundColor: color }]}>
      <Svg width={w} height={h}>
        <Path d={d} stroke="rgba(255,255,255,0.28)" strokeWidth={2.4} strokeLinecap="round" />
      </Svg>
    </View>
  );
}
// stainless steel's faint brushed lines
const Brushed = () => (
  <>
    {[0.22, 0.47, 0.78].map((x) => (
      <View key={x} style={[styles.brush, { left: `${x * 100}%` }]} />
    ))}
  </>
);

// --- above the inside ------------------------------------------------------------------

// `w`: the body's face, inside its border; `W` × `h`: the inside's width,
// the space above it; `up`: how much of that the door covers too
function Top({ m, w, W, h, up }) {
  const c = m.c;
  switch (m.top.kind) {
    case 'icebox':
      // a little fridge's freezer box, inside under the door, and a retro
      // one's chrome strip over it
      return (
        <>
          {m.radius[0] > 30 ? (
            <View style={[styles.chromeStrip, { left: WALL + W * 0.2, width: W * 0.6, top: (h - up) * 0.45 - 3, height: 6 }]}>
              <Fill colors={c.handle} />
            </View>
          ) : null}
          <View style={[styles.liner, { left: WALL, top: h - up, width: W, height: up + 12 }]}>
            <Fill colors={[c.inside[0], c.inside[1]]} />
            <View style={[styles.icebox, { borderColor: c.shelf.edge }]}>
              <Fill colors={['#f7fbfe', '#d6e6f0', '#b9cfde']} />
              <View style={styles.frost} />
              <View style={[styles.iceGrip, { backgroundColor: c.shelf.edge }]} />
            </View>
          </View>
        </>
      );
    case 'band':
      return (
        <View style={[styles.leds, { left: w / 2 - 14, top: h / 2 - 4 }]}>
          <View style={[styles.led, { backgroundColor: '#5fd4ff' }]} />
          <View style={[styles.led, { backgroundColor: '#7be884' }]} />
        </View>
      );
    case 'freezer': {
      // the freezer: its own door, the handle on the same side as the fridge's
      const free = m.hinge === 'left' ? 'right' : 'left';
      return (
        <View style={[styles.panel, { left: WALL, top: 4, width: W, height: h - 8, borderColor: c.trim, borderRadius: 10 }]}>
          <Fill colors={c.door} start={{ x: 0, y: 0 }} end={{ x: 1, y: 1 }} />
          <View style={styles.doorShine} />
          <Bar c={c} style={{ [free]: 6, bottom: 6, height: Math.max(16, (h - 8) * 0.45), width: 9 }} />
          <Svg width={20} height={20} viewBox="0 0 24 24" style={{ position: 'absolute', [m.hinge]: 12, top: (h - 8) / 2 - 12 }}>
            {[0, 60, 120].map((a) => (
              <Path key={a} d="M12 2 V22 M12 5 L9.5 3 M12 5 L14.5 3 M12 19 L9.5 21 M12 19 L14.5 21" stroke="#9cc6de" strokeWidth={2} strokeLinecap="round" fill="none" transform={`rotate(${a} 12 12)`} />
            ))}
          </Svg>
        </View>
      );
    }
    case 'header':
      // a restaurant fridge's header: the thermometer and the vents
      return (
        <View style={[styles.header, { left: WALL - 2, top: 4, width: W + 4, height: h - 8, backgroundColor: c.dark }]}>
          <View style={styles.lcd}>
            <Text style={styles.lcdText}>3°C</Text>
          </View>
          <View style={[styles.vents, { width: Math.min(90, W * 0.32) }]}>
            {[0, 1, 2, 3].map((i) => (
              <View key={i} style={styles.vent} />
            ))}
          </View>
        </View>
      );
    case 'drawer':
      return <Drawer m={m} x={WALL} y={5} w={W} h={h - 9} knob />;
    case 'cornice':
      return (
        <>
          <View style={[styles.mould, { top: 0, height: h * 0.42, backgroundColor: c.trim }]} />
          <View style={[styles.mould, { top: h * 0.42, height: h * 0.22, left: 4, right: 4, backgroundColor: c.ring, opacity: 0.35 }]} />
        </>
      );
    case 'star':
      return (
        <View style={[styles.topPanel, { left: WALL - 2, width: W + 4, top: 4, height: h - 8, borderColor: c.trim }]}>
          <Fill colors={[c.body[0], c.body[1]]} />
          <View style={styles.topShine} />
          <View style={[styles.carve, { borderColor: c.trim }]} />
          <Svg width={30} height={30} viewBox="0 0 24 24">
            <Path d={STAR_D} fill="#ffd23a" stroke="#ffffff" strokeWidth={1.8} strokeLinejoin="round" />
          </Svg>
        </View>
      );
    case 'arch': {
      // a carved crown, arched, with a rosette
      const d = `M4 ${h - 3} V${h * 0.62} Q${w / 2} ${-h * 0.35} ${w - 4} ${h * 0.62} V${h - 3} Z`;
      return (
        <Svg width={w} height={h} style={styles.abs}>
          <Path d={d} fill={c.door[1]} stroke={c.trim} strokeWidth={2} />
          <Path d={`M${w * 0.18} ${h * 0.78} Q${w / 2} ${h * 0.05} ${w * 0.82} ${h * 0.78}`} stroke={c.trim} strokeWidth={1.6} fill="none" opacity={0.7} />
          <Circle cx={w / 2} cy={h * 0.5} r={Math.min(9, h * 0.18)} fill={c.trim} stroke={c.dark} strokeWidth={1.4} />
          <Circle cx={w / 2} cy={h * 0.5} r={Math.min(4, h * 0.08)} fill={c.dark} opacity={0.5} />
        </Svg>
      );
    }
    case 'cabinets':
      // a row of little cupboards over the wardrobe
      return (
        <>
          <Drawer m={m} x={WALL} y={4} w={W / 2 - 2} h={h - 8} knob />
          <Drawer m={m} x={WALL + W / 2 + 2} y={4} w={W / 2 - 2} h={h - 8} knob />
        </>
      );
    default:
      // 'lip': the door's top seam
      return <View style={[styles.seam, { left: WALL, width: W, top: h - 3 }]} />;
  }
}

// --- below the inside --------------------------------------------------------------------

function Bottom({ m, W, y, h }) {
  const c = m.c;
  switch (m.bottom.kind) {
    case 'grille':
      return <Grille x={WALL + 2} y={y + 3} w={W - 4} h={h - 6} color={c.dark} />;
    case 'kick':
      return <Grille x={WALL + 6} y={y + 3} w={W - 12} h={h - 6} color={c.trim} />;
    case 'chrome':
      return (
        <View style={[styles.chromeStrip, { left: WALL, width: W, top: y + 3, height: h - 6 }]}>
          <Fill colors={c.handle} />
        </View>
      );
    case 'drawer':
      // the freezer drawer, and the grille under it
      return (
        <>
          <Drawer m={m} x={WALL} y={y + 4} w={W} h={h - 16} />
          <Grille x={WALL + 8} y={y + h - 10} w={W - 16} h={8} color={c.dark} />
        </>
      );
    case 'drawers':
      return (
        <>
          <Drawer m={m} x={WALL} y={y + 4} w={W / 2 - 2} h={h - 16} />
          <Drawer m={m} x={WALL + W / 2 + 2} y={y + 4} w={W / 2 - 2} h={h - 16} />
          <Grille x={WALL + 8} y={y + h - 10} w={W - 16} h={8} color={c.dark} />
        </>
      );
    case 'drawer1':
      return <Drawer m={m} x={WALL} y={y + 4} w={W} h={h - 8} />;
    case 'drawers2':
      return (
        <>
          <Drawer m={m} x={WALL} y={y + 4} w={W / 2 - 2} h={h - 8} />
          <Drawer m={m} x={WALL + W / 2 + 2} y={y + 4} w={W / 2 - 2} h={h - 8} />
        </>
      );
    case 'drawersRow':
      return (
        <>
          {[0, 1, 2].map((k) => (
            <Drawer key={k} m={m} x={WALL + (k * (W + 4)) / 3} y={y + 4} w={(W + 4) / 3 - 4} h={h - 14} knob />
          ))}
          <View style={[styles.plinth, { top: y + h - 7, height: 7, backgroundColor: c.ring }]} />
        </>
      );
    case 'skirt': {
      // a carved apron between the feet
      return (
        <Svg width={W + 2 * WALL} height={h} style={[styles.abs, { top: y }]}>
          <Path d={`M0 0 H${W + 2 * WALL} V${h * 0.45} Q${(W + 2 * WALL) * 0.75} ${h} ${(W + 2 * WALL) / 2} ${h * 0.55} Q${(W + 2 * WALL) * 0.25} ${h} 0 ${h * 0.45} Z`} fill={c.door[2]} stroke={c.trim} strokeWidth={1.6} />
        </Svg>
      );
    }
    case 'plinth':
      return <View style={[styles.plinth, { top: y + 3, height: h - 3, backgroundColor: c.ring, opacity: 0.55 }]} />;
    default:
      // 'base'
      return <View style={[styles.plinth, { top: y + 2, height: h - 2, backgroundColor: 'rgba(0,0,0,0.12)' }]} />;
  }
}

// --- what it stands on ---------------------------------------------------------------------

function Feet({ m, w, h }) {
  const c = m.c;
  const at = [w * 0.13, w * 0.87];
  let shapes;
  switch (m.feet) {
    case 'legs':
      // a retro fridge's splayed chrome legs
      shapes = at.map((x, i) => {
        const s = i ? 1 : -1;
        return <Path key={i} d={`M${x - 6} 0 H${x + 6} L${x + 3 + s * 5} ${h} H${x - 3 + s * 5} Z`} fill="#c9d0d7" stroke="#7d8894" strokeWidth={1.4} strokeLinejoin="round" />;
      });
      break;
    case 'casters':
      shapes = [w * 0.1, w * 0.5, w * 0.9].map((x, i) => (
        <React.Fragment key={i}>
          <Rect x={x - 7} y={0} width={14} height={h * 0.45} rx={2} fill="#4c5560" />
          <Circle cx={x} cy={h - 6} r={6} fill="#22282e" />
          <Circle cx={x} cy={h - 6} r={2.2} fill="#9aa5b1" />
        </React.Fragment>
      ));
      break;
    case 'tapered':
      shapes = at.map((x, i) => <Path key={i} d={`M${x - 7} 0 H${x + 7} L${x + 3} ${h} H${x - 3} Z`} fill={c.feet} />);
      break;
    case 'balls':
      shapes = at.map((x, i) => <Circle key={i} cx={x} cy={h / 2 + 1} r={h / 2 - 1} fill={c.feet} />);
      break;
    case 'buns':
      shapes = at.map((x, i) => <Ellipse key={i} cx={x} cy={h / 2 + 1} rx={15} ry={h / 2 - 1} fill={c.feet} />);
      break;
    case 'bracket':
      shapes = [
        <Path key="l" d={`M3 0 H32 Q20 2 14 ${h} H3 Z`} fill={c.feet} />,
        <Path key="r" d={`M${w - 3} 0 H${w - 32} Q${w - 20} 2 ${w - 14} ${h} H${w - 3} Z`} fill={c.feet} />,
      ];
      break;
    default:
      // 'nubs'
      shapes = at.map((x, i) => <Rect key={i} x={x - 8} y={0} width={16} height={h} rx={4} fill={c.feet} />);
  }
  return (
    <Svg width={w} height={h} style={styles.abs}>
      {shapes}
    </Svg>
  );
}

// --- a door ----------------------------------------------------------------------------

// its handle, by the edge away from the hinge (`free`)
function Handle({ m, free, w, h }) {
  const c = m.c;
  switch (m.handle) {
    case 'recess':
      return (
        <View style={[styles.recess, { [free]: 4, top: h * 0.1, height: Math.max(20, h * 0.5), backgroundColor: c.trim }]}>
          <View style={styles.recessShade} />
        </View>
      );
    case 'lever': {
      const lw = Math.min(46, w * 0.32);
      return (
        <>
          <Bar c={c} flat style={{ [free]: 8, top: h * 0.34, width: lw, height: 11 }} />
          <Knob c={c} size={17} style={{ [free]: 4, top: h * 0.34 - 3 }} />
        </>
      );
    }
    case 'pocket':
      return <Bar c={c} style={{ [free]: 6, top: Math.max(6, h * 0.05), height: Math.max(22, h * 0.26), width: 9 }} />;
    case 'bar':
    case 'long': {
      const long = m.handle === 'long';
      const y0 = h * (long ? 0.16 : 0.12);
      const y1 = h * (long ? 0.62 : 0.66);
      return (
        <>
          <View style={[styles.barShadow, { [free]: 5, top: y0 + 2, height: y1 - y0 }]} />
          <Bar c={c} style={{ [free]: 7, top: y0, height: y1 - y0, width: long ? 11 : 9 }} />
        </>
      );
    }
    case 'pull':
      return <Bar c={c} style={{ [free]: 8, top: h * 0.42, height: Math.max(18, h * 0.16), width: 7 }} />;
    default:
      // 'knob'
      return <Knob c={c} size={16} style={{ [free]: 8, top: h / 2 - 8 }} />;
  }
}

// what's on the door: notes and magnets, a badge, a water dispenser, a
// display, a lock (fridges); panels, cut-outs, a mirror (cupboards).
// `i`: which door (0 the left one or the only one, 1 the right one)
function Deco({ m, i, hinge, w, h }) {
  const c = m.c;
  const free = hinge === 'left' ? 'right' : 'left';
  const out = [];
  for (const d of m.deco) {
    if (d === 'brushed') out.push(<Brushed key={d} />);
    else if (d === 'note') {
      const nw = Math.min(46, w * 0.3, h * 0.55);
      out.push(
        <View key={d} style={[styles.note, { [hinge]: w * 0.2, top: Math.max(8, h * 0.16), width: nw, height: nw * 1.1 }]}>
          <View style={[styles.noteLine, { top: nw * 0.42 }]} />
          <View style={[styles.noteLine, { top: nw * 0.62, right: nw * 0.3 }]} />
          <Svg width={14} height={13} viewBox="0 0 24 22" style={styles.noteMagnet}>
            <Path d={HEART_D} fill="#ff6fae" stroke="#ffffff" strokeWidth={2.4} />
          </Svg>
        </View>,
      );
    } else if (d === 'magnets') {
      // a drawing held up by a magnet, and a star
      const nw = Math.min(54, w * 0.3);
      out.push(
        <React.Fragment key={d}>
          <View style={[styles.note, { [hinge]: w * 0.16, top: h * 0.14, width: nw, height: nw * 0.82, transform: [{ rotate: '5deg' }] }]}>
            <Svg width={nw} height={nw * 0.82} viewBox="0 0 30 24">
              <Circle cx={15} cy={13} r={7} fill="none" stroke="#ff8a3d" strokeWidth={1.8} />
              <Circle cx={12.5} cy={11.5} r={1.1} fill="#45107a" />
              <Circle cx={17.5} cy={11.5} r={1.1} fill="#45107a" />
              <Path d="M12 15 Q15 18 18 15" stroke="#45107a" strokeWidth={1.4} fill="none" strokeLinecap="round" />
            </Svg>
            <View style={[styles.magnetDot, { backgroundColor: '#5fb8ff' }]} />
          </View>
          <Svg width={20} height={20} viewBox="0 0 24 24" style={{ position: 'absolute', [free]: 22, top: h * 0.58 }}>
            <Path d={STAR_D} fill="#ffd23a" stroke="#ffffff" strokeWidth={2} strokeLinejoin="round" />
          </Svg>
        </React.Fragment>,
      );
    } else if (d === 'badge') {
      const bw = Math.min(70, w * 0.44);
      out.push(
        <View key={d} style={[styles.badge, { left: w / 2 - bw / 2, top: Math.max(8, h * 0.08), width: bw }]}>
          <Fill colors={c.handle} />
          <Text style={styles.badgeText} numberOfLines={1}>
            SQUISHY
          </Text>
        </View>,
      );
    } else if (d === 'dispenser' && i === 0) {
      // ice and water, in a dark recess on the left door
      const dh = Math.min(h * 0.3, w * 0.85);
      out.push(
        <View key={d} style={[styles.dispenser, { left: w * 0.2, width: w * 0.6, top: h * 0.14, height: dh }]}>
          <View style={styles.dispLeds}>
            <View style={[styles.led, { backgroundColor: '#5fd4ff' }]} />
            <View style={[styles.led, { backgroundColor: '#5fd4ff', opacity: 0.5 }]} />
          </View>
          <View style={[styles.dispLever, { height: dh * 0.36 }]} />
          <View style={styles.dispTray} />
        </View>,
      );
    } else if (d === 'display' && i === 1) {
      out.push(
        <View key={d} style={[styles.display, { left: w * 0.25, width: w * 0.5, top: h * 0.16 }]}>
          <Text style={styles.displayText}>3°</Text>
          <Svg width={11} height={11} viewBox="0 0 24 24">
            <Path d={HEART_D} fill="#5fd4ff" />
          </Svg>
        </View>,
      );
    } else if (d === 'lock' && i === 0) {
      out.push(
        <View key={d} style={[styles.lock, { [free]: 7, top: h * 0.68 }]}>
          <View style={styles.lockSlot} />
        </View>,
      );
    } else if (d === 'panel') {
      out.push(<View key={d} style={[styles.inset, { borderColor: c.trim, top: 10, bottom: 10 }]} />);
    } else if (d === 'panel2' || (d === 'mirror' && i === 0)) {
      out.push(
        <React.Fragment key={d}>
          <View style={[styles.inset, { borderColor: c.trim, top: 10, height: h * 0.56 - 14 }]} />
          <View style={[styles.inset, { borderColor: c.trim, top: h * 0.56 + 4, bottom: 10 }]} />
        </React.Fragment>,
      );
    } else if (d === 'mirror') {
      out.push(
        <View key={d} style={[styles.mirror, { borderColor: c.trim }]}>
          <Fill colors={['#f4fbff', '#c6e2f5', '#9cc4e4']} start={{ x: 0, y: 0 }} end={{ x: 1, y: 1 }} />
          <View style={[styles.mirrorShine, { left: '18%', top: '8%' }]} />
          <View style={[styles.mirrorShine, { left: '48%', top: '30%', width: 8 }]} />
        </View>,
      );
    } else if (d === 'cutouts') {
      out.push(
        <React.Fragment key={d}>
          <View style={[styles.inset, { borderColor: c.trim, top: 10, bottom: 10 }]} />
          <Svg width={18} height={16} viewBox="0 0 24 22" style={[styles.abs, { top: 16, left: w / 2 - 9 }]}>
            <Path d={i ? STAR_D : HEART_D} fill={c.trim} opacity={0.5} />
          </Svg>
        </React.Fragment>,
      );
    } else if (d === 'arched') {
      const p = 9;
      const r = Math.min(w * 0.3, h * 0.2);
      out.push(
        <Svg key={d} width={w} height={h} style={styles.abs}>
          <Path d={`M${p} ${h - p} V${p + r} Q${w / 2} ${p - r * 0.55} ${w - p} ${p + r} V${h - p} Z`} fill="rgba(0,0,0,0.07)" stroke={c.trim} strokeWidth={2} opacity={0.85} />
          <Circle cx={w / 2} cy={p + r * 0.55} r={3.5} fill={c.trim} />
        </Svg>,
      );
    }
  }
  return out;
}

// The door's outside: the model's finish, a shine, its handle and what's on it.
function DoorFront({ m, i, hinge, w, h }) {
  const c = m.c;
  return (
    <View style={[styles.doorFace, { borderColor: c.trim, borderRadius: doorRadius(m) }]}>
      <Fill colors={c.door} start={{ x: hinge === 'left' ? 0 : 1, y: 0 }} end={{ x: hinge === 'left' ? 1 : 0, y: 1 }} />
      <View style={[styles.doorShine, { [hinge]: 6 }]} />
      <Deco m={m} i={i} hinge={hinge} w={w} h={h} />
      <Handle m={m} free={hinge === 'left' ? 'right' : 'left'} w={w} h={h} />
    </View>
  );
}
const doorRadius = (m) => (m.kind === 'fridge' ? Math.min(10, m.radius[1]) : Math.min(8, m.radius[1]));

// The door's inside (seen when it swings open): a fridge's has its rubber
// seal and the door bins with bottles in; a cupboard's is plain wood.
const BOTTLES = ['#ffffff', '#ff5a4a', '#ffb02e', '#7be884', '#5fb8ff'];
function DoorBack({ m, w, h }) {
  const c = m.c;
  const fridge = m.kind === 'fridge';
  const bins = fridge ? Math.max(1, Math.min(5, Math.round(h / 85))) : 0;
  return (
    <View style={[styles.doorFace, { borderColor: fridge ? '#c9d3dc' : c.trim, borderRadius: doorRadius(m), borderWidth: fridge ? 4 : 2.5 }]}>
      <Fill colors={c.doorInner} />
      {Array.from({ length: bins }, (_, k) => {
        const y = (h * (k + 0.78)) / bins - 6;
        const bh = Math.min(28, (h / bins) * 0.5);
        return (
          <React.Fragment key={k}>
            {[0.2, 0.52].map((x, j) => (
              <View key={j} style={[styles.bottle, { left: `${x * 100}%`, top: y - bh + 4, width: Math.max(8, w * 0.16), height: bh, backgroundColor: BOTTLES[(k * 2 + j) % BOTTLES.length] }]} />
            ))}
            <View style={[styles.doorBin, { top: y, backgroundColor: c.shelf.face, borderColor: c.shelf.edge }]} />
          </React.Fragment>
        );
      })}
      {fridge ? null : <View style={[styles.inset, { borderColor: c.trim, top: 10, bottom: 10, opacity: 0.25 }]} />}
    </View>
  );
}

// One door, `w` × `h` at `x`, turning about its `hinge` edge by `deg`.
// Past 90° its inside shows: swapped by the angle, as Android's
// backfaceVisibility only goes by a view's own turn, not its parent's (the
// open door showed its outside).
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

// --- the inside ------------------------------------------------------------------------

function Inside({ m, g, light, inside, slots }) {
  const c = m.c;
  const { S, W, H, rows, cols, crisper } = g;
  const fridge = m.kind === 'fridge';
  const shelves = Array.from({ length: rows }, (_, r) => (r + 1) * (S + SHELF) - SHELF);
  let wire = '';
  if (c.shelf.wire) shelves.forEach((y) => {
    for (let x = 5; x < W; x += 9) wire += `M${x} ${y + 3} V${y + SHELF - 1} `;
  });
  return (
    <View style={[styles.inside, { left: INSET, top: RING + BORDER + g.top, width: W, height: H + crisper, borderRadius: fridge ? 10 : 4 }]}>
      <Fill colors={c.inside} locations={[0, 0.55, 1]} />
      {fridge ? (
        // the cold air's vents, top middle
        <View style={[styles.airVents, { left: W / 2 - 16 }]}>
          <View style={styles.airVent} />
          <View style={styles.airVent} />
        </View>
      ) : (
        // the back's planks
        Array.from({ length: cols }, (_, k) => <View key={k} style={[styles.plank, { left: (k + 0.5) * S - 1 }]} />)
      )}
      {m.deco.includes('rail') ? (
        <View style={styles.rail}>
          <Fill colors={['#ffffff', '#c9d0d7', '#8995a2']} />
        </View>
      ) : null}
      {/* the lamp */}
      <Animated.View style={[StyleSheet.absoluteFill, { opacity: light }]}>
        <Svg width={W} height={H + crisper} style={StyleSheet.absoluteFill}>
          <Defs>
            <RadialGradient id="lamp" cx="50%" cy="0%" r="75%">
              <Stop offset="0" stopColor={c.lamp} stopOpacity={fridge ? 0.95 : 0.8} />
              <Stop offset="0.5" stopColor={c.lamp} stopOpacity={fridge ? 0.35 : 0.25} />
              <Stop offset="1" stopColor={c.lamp} stopOpacity={0} />
            </RadialGradient>
          </Defs>
          <Rect x={0} y={0} width={W} height={H + crisper} fill="url(#lamp)" />
          {fridge ? <Ellipse cx={W / 2} cy={3} rx={Math.min(28, W * 0.12)} ry={4} fill="#ffffff" /> : null}
        </Svg>
      </Animated.View>
      {/* the shelves: glass, wire or wood */}
      {shelves.map((y, r) => (
        <View key={r} style={[styles.shelf, { top: y, height: SHELF }]}>
          <View style={[styles.shelfTop, { backgroundColor: c.shelf.top }]} />
          <View style={[styles.shelfFace, { backgroundColor: c.shelf.face, borderBottomColor: c.shelf.edge }]} />
        </View>
      ))}
      {wire ? (
        <Svg width={W} height={H} style={styles.abs}>
          <Path d={wire} stroke={c.shelf.edge} strokeWidth={1.2} opacity={0.7} />
        </Svg>
      ) : null}
      {/* the salad drawers */}
      {crisper
        ? [0, 1].map((k) => (
            <View key={k} style={[styles.crisper, { left: k ? W / 2 + 2 : 4, top: H + 2, width: W / 2 - 6, height: crisper - 6, borderColor: c.shelf.edge }]}>
              <View style={[styles.veg, { left: '12%', backgroundColor: k ? '#ff9a3d' : '#7be884', width: crisper * 0.55, height: crisper * 0.5 }]} />
              <View style={[styles.veg, { left: '48%', backgroundColor: k ? '#ff5a4a' : '#3ddc97', width: crisper * 0.45, height: crisper * 0.45 }]} />
              <View style={styles.crisperFront} />
              <View style={styles.crisperGrip} />
            </View>
          ))
        : null}
      {/* the empty spots, while putting them back */}
      {slots
        ? Array.from({ length: rows * cols }, (_, i) => (
            <View
              key={i}
              style={[styles.slotMark, { left: (i % cols) * S + S * 0.1, top: Math.floor(i / cols) * (S + SHELF) + S * 0.1, width: S * 0.8, height: S * 0.8, borderRadius: S * 0.22, borderColor: c.shelf.edge }]}
            />
          ))
        : null}
      {inside}
    </View>
  );
}

// --- the whole thing --------------------------------------------------------------------

// `still`: shut for good, no inside drawn (the map's pictures)
function Container({ m, g, door, light, inside, slots, still = false }) {
  const c = m.c;
  const { W, H, crisper, top, up, bodyW, bodyH, feet } = g;
  const [rt, rb] = m.radius;
  const hd = H + crisper;
  const dh = hd + up;
  const corners = (r0, r1) => ({ borderTopLeftRadius: r0, borderTopRightRadius: r0, borderBottomLeftRadius: r1, borderBottomRightRadius: r1 });
  return (
    <View pointerEvents="none" style={{ width: bodyW, height: bodyH + feet }}>
      {feet ? (
        <View style={[styles.abs, { top: bodyH - 6 }]}>
          <Feet m={m} w={bodyW} h={feet + 6} />
        </View>
      ) : null}
      {/* the body: ring, lip, white border */}
      <View style={[styles.ring, corners(rt, rb), { width: bodyW, height: bodyH, backgroundColor: c.ring }]}>
        <View style={[styles.bodyFace, corners(Math.max(2, rt - RING), Math.max(2, rb - RING))]}>
          <Fill colors={c.body} start={{ x: 0, y: 0 }} end={{ x: 1, y: 1 }} />
          {m.deco.includes('brushed') ? <Brushed /> : null}
          <View style={styles.sideShine} />
          <Top m={m} w={bodyW - 2 * (RING + BORDER)} W={W} h={top} up={g.up} />
          <Bottom m={m} W={W} y={top + hd} h={g.bottom} />
        </View>
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

// --- a small one, for the game picker, the hub cards and the map ----------------------

const SHUT = new Animated.Value(0);
const LIT = new Animated.Value(1);

// A container drawn full size and shrunk to fit `size` wide (a little more
// high): `m` the model (else the theme's BIG one), `rows` × `cols` its
// shelves; `door` (Animated) opens and closes it (it opens to 90° so the
// door stays close), a squishy or two inside. Without `door` it stays shut.
export const MiniContainer = memo(function MiniContainer({ t, m, rows = 2, cols, size = 92, door, uris = [] }) {
  const model = m || modelOf(t ? t.key : 'fridge', 2);
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
  ring: { position: 'absolute', left: 0, top: 0, padding: RING, paddingBottom: RING + LIP },
  bodyFace: { flex: 1, borderWidth: BORDER, borderColor: '#ffffff', overflow: 'hidden' },
  sideShine: { position: 'absolute', left: 3, top: 10, bottom: 10, width: 5, borderRadius: 3, backgroundColor: 'rgba(255,255,255,0.5)' },
  brush: { position: 'absolute', top: 0, bottom: 0, width: 1.5, backgroundColor: 'rgba(255,255,255,0.32)' },
  seam: { position: 'absolute', height: 2, borderRadius: 1, backgroundColor: 'rgba(0,0,0,0.1)' },
  chromeStrip: { position: 'absolute', borderRadius: 4, overflow: 'hidden', borderWidth: 1, borderColor: '#ffffff' },
  leds: { position: 'absolute', flexDirection: 'row', gap: 6 },
  liner: { position: 'absolute', borderTopLeftRadius: 10, borderTopRightRadius: 10, overflow: 'hidden' },
  icebox: { position: 'absolute', left: '8%', right: '8%', top: 6, bottom: 18, borderRadius: 6, borderWidth: 2, overflow: 'hidden', alignItems: 'center', justifyContent: 'flex-end' },
  frost: { position: 'absolute', left: 6, right: 6, top: 4, height: 4, borderRadius: 2, backgroundColor: 'rgba(255,255,255,0.8)' },
  iceGrip: { width: '28%', height: 4, borderRadius: 2, marginBottom: 4 },
  led: { width: 8, height: 8, borderRadius: 4, borderWidth: 1.5, borderColor: '#ffffff' },
  panel: { position: 'absolute', borderWidth: 2, overflow: 'hidden' },
  panelShine: { position: 'absolute', left: 6, right: 6, top: 2, height: 3, borderRadius: 2, backgroundColor: 'rgba(255,255,255,0.55)' },
  header: { position: 'absolute', borderRadius: 6, flexDirection: 'row', alignItems: 'center', justifyContent: 'space-between', paddingHorizontal: 8, borderWidth: 1.5, borderColor: 'rgba(255,255,255,0.35)' },
  lcd: { paddingHorizontal: 6, paddingVertical: 1, borderRadius: 4, backgroundColor: '#0d1114', borderWidth: 1, borderColor: '#56616c' },
  lcdText: { fontFamily: F.display, fontSize: 11, color: '#ff5a4a', includeFontPadding: false, letterSpacing: 0.5 },
  vents: { gap: 3 },
  vent: { height: 2.5, borderRadius: 2, backgroundColor: 'rgba(255,255,255,0.35)' },
  mould: { position: 'absolute', left: 0, right: 0 },
  topPanel: { position: 'absolute', borderRadius: 12, borderWidth: 2, overflow: 'hidden', flexDirection: 'row', alignItems: 'center', justifyContent: 'center' },
  topShine: { position: 'absolute', left: 8, right: 8, top: 3, height: '35%', borderRadius: 8, backgroundColor: 'rgba(255,255,255,0.55)' },
  carve: { position: 'absolute', left: 10, right: 10, top: 6, bottom: 6, borderRadius: 10, borderWidth: 2, opacity: 0.35 },
  plinth: { position: 'absolute', left: 0, right: 0 },
  grille: { position: 'absolute', borderRadius: 4, overflow: 'hidden' },
  bar: { position: 'absolute', borderRadius: 5, overflow: 'hidden', borderWidth: 1.5, borderColor: '#ffffff' },
  barShadow: { position: 'absolute', width: 9, borderRadius: 5, backgroundColor: 'rgba(0,0,0,0.16)' },
  knob: { position: 'absolute', overflow: 'hidden', borderWidth: 2, borderColor: '#ffffff' },
  recess: { position: 'absolute', width: 8, borderRadius: 4, overflow: 'hidden' },
  recessShade: { position: 'absolute', left: 0, top: 0, bottom: 0, width: 3, backgroundColor: 'rgba(0,0,0,0.18)' },
  inside: { position: 'absolute', overflow: 'hidden' },
  airVents: { position: 'absolute', top: 8, width: 32, gap: 3 },
  airVent: { height: 3, borderRadius: 2, backgroundColor: 'rgba(80,120,150,0.22)' },
  plank: { position: 'absolute', top: 0, bottom: 0, width: 2, backgroundColor: 'rgba(120,70,20,0.16)' },
  rail: { position: 'absolute', left: 4, right: 4, top: 4, height: 5, borderRadius: 3, overflow: 'hidden' },
  shelf: { position: 'absolute', left: 0, right: 0 },
  shelfTop: { height: 3 },
  shelfFace: { flex: 1, borderBottomWidth: 2 },
  crisper: { position: 'absolute', borderRadius: 6, borderWidth: 2, overflow: 'hidden', backgroundColor: 'rgba(255,255,255,0.25)' },
  veg: { position: 'absolute', bottom: -3, borderRadius: 999 },
  crisperFront: { ...StyleSheet.absoluteFillObject, backgroundColor: 'rgba(225,242,252,0.55)' },
  crisperGrip: { position: 'absolute', top: 4, alignSelf: 'center', width: '30%', height: 4, borderRadius: 2, backgroundColor: 'rgba(80,120,150,0.3)' },
  slotMark: { position: 'absolute', borderWidth: 2.5, borderStyle: 'dashed' },
  doors: { position: 'absolute' },
  door: { position: 'absolute', top: 0 },
  doorFace: { flex: 1, borderWidth: 2.5, overflow: 'hidden' },
  doorShine: { position: 'absolute', top: 8, bottom: 8, width: 5, borderRadius: 3, backgroundColor: 'rgba(255,255,255,0.6)' },
  doorBin: { position: 'absolute', left: 5, right: 5, height: 10, borderRadius: 3, borderBottomWidth: 2.5 },
  bottle: { position: 'absolute', borderTopLeftRadius: 4, borderTopRightRadius: 4, borderWidth: 1, borderColor: 'rgba(0,0,0,0.12)' },
  note: { position: 'absolute', backgroundColor: '#fffdf2', borderRadius: 2, borderWidth: 1, borderColor: 'rgba(0,0,0,0.08)', transform: [{ rotate: '-6deg' }] },
  noteLine: { position: 'absolute', left: '18%', right: '18%', height: 1.5, backgroundColor: 'rgba(95,184,255,0.7)' },
  noteMagnet: { position: 'absolute', top: -6, left: '35%' },
  magnetDot: { position: 'absolute', top: -5, left: '42%', width: 10, height: 10, borderRadius: 5, borderWidth: 1.5, borderColor: '#ffffff' },
  badge: { position: 'absolute', height: 16, borderRadius: 8, overflow: 'hidden', alignItems: 'center', justifyContent: 'center', borderWidth: 1, borderColor: '#ffffff' },
  badgeText: { fontFamily: F.display, fontSize: 9, letterSpacing: 1.2, color: '#5b6670', includeFontPadding: false },
  dispenser: { position: 'absolute', borderRadius: 8, backgroundColor: '#161c22', borderWidth: 2, borderColor: '#9aa5b1', alignItems: 'center', justifyContent: 'space-between', paddingVertical: 5, overflow: 'hidden' },
  dispLeds: { flexDirection: 'row', gap: 4 },
  dispLever: { width: '34%', borderRadius: 4, backgroundColor: '#56616c' },
  dispTray: { width: '76%', height: 4, borderRadius: 2, backgroundColor: '#56616c' },
  display: { position: 'absolute', height: 20, borderRadius: 5, backgroundColor: '#161c22', borderWidth: 1.5, borderColor: '#9aa5b1', flexDirection: 'row', alignItems: 'center', justifyContent: 'center', gap: 4 },
  displayText: { fontFamily: F.display, fontSize: 11, color: '#5fd4ff', includeFontPadding: false },
  lock: { position: 'absolute', width: 12, height: 12, borderRadius: 6, backgroundColor: '#c9d0d7', borderWidth: 1.5, borderColor: '#56616c', alignItems: 'center', justifyContent: 'center' },
  lockSlot: { width: 1.8, height: 6, backgroundColor: '#56616c' },
  inset: { position: 'absolute', left: 8, right: 8, borderRadius: 4, borderWidth: 2, opacity: 0.45 },
  mirror: { position: 'absolute', left: 8, right: 8, top: 10, bottom: 10, borderRadius: 4, borderWidth: 2, overflow: 'hidden' },
  mirrorShine: { position: 'absolute', width: 14, height: '140%', backgroundColor: 'rgba(255,255,255,0.45)', transform: [{ rotate: '28deg' }] },
});
