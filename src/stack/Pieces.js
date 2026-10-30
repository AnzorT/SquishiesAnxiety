import React, { memo } from 'react';
import { Image, StyleSheet, Text, View } from 'react-native';
import Svg, { Defs, Ellipse, Path, RadialGradient, Stop } from 'react-native-svg';
import { F } from '../squishdoku/theme';

// What Squish Stack draws with (SQUISH_STACK.md): a squishy drawn by its
// body (so the next one stands on its head, not on its picture's margin),
// the puffy cushions they sit on, the ★ badge, and the goal card.

// how far a squishy sinks into the one under it (of the lower one's height)
export const OVER = 0.24;

// the cushions, left to right: candy pink, mint, lilac, peach
export const CUSHIONS = [
  { c1: '#ffd9f3', c2: '#ff86d3', ring: '#a3168f' },
  { c1: '#cffff7', c2: '#3fd6c6', ring: '#0b6670' },
  { c1: '#ebdcff', c2: '#a77bff', ring: '#4b1ca0' },
  { c1: '#fff0cf', c2: '#ffb257', ring: '#9c4d06' },
];

// squishy `c` (roster.js castOf) with its body `w` wide: how tall it is
export const bodyH = (c, w) => (w / (c.box[2] - c.box[0])) * c.ar * (c.box[3] - c.box[1]);

// A squishy's picture placed so its body fills a w × bodyH box (a rig
// still's margins hang outside it; a cut-out is just the body).
export const Squishy = memo(function Squishy({ c, w }) {
  const [l, t, r] = c.box;
  const sw = w / (r - l);
  const sh = sw * c.ar;
  return (
    <View style={{ width: w, height: bodyH(c, w) }}>
      <Image source={c.source} fadeDuration={0} style={{ position: 'absolute', left: -l * sw, top: -t * sh, width: sw, height: sh }} />
    </View>
  );
});

// A puffy cushion seen from the front: ring, white piping, a soft face with
// stitching round it and a tuft in the middle, on a lip of its ring colour.
export const Cushion = memo(function Cushion({ w, h, i }) {
  const c = CUSHIONS[i % CUSHIONS.length];
  const lip = 5;
  const id = `stackCush${i}`;
  return (
    <Svg width={w} height={h + lip}>
      <Defs>
        <RadialGradient id={id} cx="50%" cy="26%" rx="62%" ry="78%">
          <Stop offset="0" stopColor={c.c1} />
          <Stop offset="1" stopColor={c.c2} />
        </RadialGradient>
      </Defs>
      <Ellipse cx={w / 2} cy={h / 2 + lip} rx={w / 2 - 1} ry={h / 2 - 1} fill={c.ring} />
      <Ellipse cx={w / 2} cy={h / 2} rx={w / 2 - 1} ry={h / 2 - 1} fill={c.ring} />
      <Ellipse cx={w / 2} cy={h / 2} rx={w / 2 - 3} ry={h / 2 - 3} fill="#ffffff" />
      <Ellipse cx={w / 2} cy={h / 2} rx={w / 2 - 6} ry={h / 2 - 6} fill={`url(#${id})`} />
      <Ellipse cx={w / 2} cy={h / 2} rx={Math.max(4, w / 2 - 14)} ry={Math.max(3, h / 2 - 9)} fill="none" stroke="rgba(255,255,255,0.75)" strokeWidth={2} strokeDasharray="5 4" />
      <Ellipse cx={w / 2} cy={h * 0.56} rx={4.5} ry={3} fill={c.ring} opacity={0.45} />
    </Svg>
  );
});

const STAR_D = 'M12 2.2 L14.9 8.6 L21.8 9.3 L16.6 14 L18.1 20.9 L12 17.4 L5.9 20.9 L7.4 14 L2.2 9.3 L9.1 8.6 Z';
// the ★ under the cushion everyone goes to
export const StarBadge = memo(function StarBadge({ size = 28 }) {
  return (
    <Svg width={size} height={size} viewBox="0 0 24 24">
      <Path d={STAR_D} fill="#b86200" transform="translate(0 1.4)" strokeLinejoin="round" />
      <Path d={STAR_D} fill="#ffd23a" stroke="#ffffff" strokeWidth={1.8} strokeLinejoin="round" />
    </Svg>
  );
});

// The goal: each cushion with the squishies that end up on it, small.
// who[r] is the squishy of size r; goal[r] its cushion.
// The tallest stack fits ROOM points above its cushion (smaller squishies
// when one cushion gets most of them).
const ROOM = 56;
export const GoalCard = memo(function GoalCard({ who, goal, k, star, width = 118 }) {
  const n = who.length;
  const cols = Array.from({ length: k }, (_, p) => p);
  const sized = (m) => (r) => m * (n === 1 ? 1 : 0.5 + (0.5 * r) / (n - 1));
  const tallest = (m) => Math.max(...cols.map((p) => who.reduce((a, c, r) => a + (goal[r] === p ? bodyH(c, sized(m)(r)) * (1 - OVER) : 0), 0)));
  const fit = Math.min(26, (width - 14) / k - 4);
  const maxW = fit * Math.min(1, ROOM / Math.max(1, tallest(fit)));
  return (
    <View style={[styles.goal, { width }]}>
      <Text style={styles.goalLabel}>GOAL</Text>
      <View style={styles.goalRow}>
        {cols.map((p) => (
          <View key={p} style={styles.goalCol}>
            {star === p ? (
              <View style={styles.goalStar}>
                <StarBadge size={12} />
              </View>
            ) : null}
            <View style={[styles.goalCush, { backgroundColor: CUSHIONS[p].c2, borderColor: CUSHIONS[p].ring }]} />
            {who.map((c, r) => r).reverse().filter((r) => goal[r] === p).map((r) => {
              const w = sized(maxW)(r);
              return (
                <View key={r} style={{ marginBottom: -bodyH(who[r], w) * OVER }}>
                  <Squishy c={who[r]} w={w} />
                </View>
              );
            })}
          </View>
        ))}
      </View>
    </View>
  );
});

const styles = StyleSheet.create({
  goal: { alignSelf: 'stretch', backgroundColor: 'rgba(255,255,255,0.95)', borderRadius: 16, borderWidth: 3, borderColor: '#ffffff', paddingHorizontal: 5, paddingTop: 2, paddingBottom: 6, alignItems: 'center' },
  goalLabel: { fontFamily: F.display, fontSize: 10.5, letterSpacing: 1.2, color: '#6b3fa0', includeFontPadding: false },
  goalRow: { flexGrow: 1, alignSelf: 'stretch', flexDirection: 'row', alignItems: 'flex-end', justifyContent: 'space-around', paddingTop: 4 },
  // bottom to top: the cushion, then its squishies, biggest first
  goalCol: { flexDirection: 'column-reverse', alignItems: 'center' },
  goalCush: { width: 22, height: 7, borderRadius: 4, borderWidth: 1.5 },
  goalStar: { position: 'absolute', bottom: -9, zIndex: 2 },
});
