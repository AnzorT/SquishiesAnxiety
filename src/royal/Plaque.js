import React, { memo } from 'react';
import { Animated, Pressable, StyleSheet, View } from 'react-native';
import Svg, { Defs, RadialGradient, Rect, Stop } from 'react-native-svg';
import { LinearGradient as LG } from 'expo-linear-gradient';
import { usePingPong } from '../components/idleLoop';
import { INK, PLAQUES, TIP } from './theme';

// The menu's plaque (main-menu.js .mm-p + .v-*): a fill inside a gold rim, a dark ink outline, a 3D lip under it, a
// shine along the top, a soft shade at the bottom, and optional diamond tips at both ends (.tip). The same numbers as
// the CSS: rim 2.5, outline 1.6, lip 3.
//
// variant: vel | gold | bronze | wood | amy | pearl | rainbow (theme.js PLAQUES)
// radius: the corner radius (999 = a pill); style: the box (width / height / padding / layout of the children)
// tips: ignored (REDESIGN_V8, the user: no diamond tips anywhere); onPress: a button (it sinks 2 on press, as :active does)

// a CSS angle (0 = up, 90 = right) as the x1 / y1 / x2 / y2 of an SVG gradient over the box
function line(angle) {
  const r = (angle * Math.PI) / 180, dx = Math.sin(r), dy = -Math.cos(r);
  return { x1: 0.5 - dx / 2, y1: 0.5 - dy / 2, x2: 0.5 + dx / 2, y2: 0.5 + dy / 2 };
}

// The fill, all native views (performance, 2026-11-14): react-native-svg renders in software on the UI thread, and a
// big panel was a big software render each time a screen opened. Native gradients and a repeating image tile draw on
// the GPU. Radial fills (vel, amy, pearl) become the vertical gradient they read as on a panel; the faint diamond / wood
// textures are left out (5.5% white; Android's repeating image mode didn't tile them). Exported for other shapes.
// a radial fill as the vertical gradient it shows across a panel (what the box covers of the ellipse)
const LINEAR_OF = {
  amy: [[0, '#e6c8ff'], [0.56, '#a565ff'], [1, '#6f2fd3']],
  pearl: [[0, '#ffffff'], [0.45, '#fff6e6'], [1, '#f6e2c0']],
};
const SPARK = [[0.14, 0.28, 1.2, 0.95], [0.63, 0.72, 1.1, 0.85], [0.86, 0.22, 1.3, 0.9], [0.36, 0.8, 1, 0.7]];
export const Fill = memo(function Fill({ variant = 'vel', top = true, shade = true }) {
  const P = PLAQUES[variant] || PLAQUES.vel;
  const F = P.fill;
  const stops = F.radial ? LINEAR_OF[variant] || F.stops : F.stops;
  const ln = F.radial ? { x1: 0.5, y1: 0, x2: 0.5, y2: 1 } : line(F.angle);
  return (
    <View pointerEvents="none" style={StyleSheet.absoluteFill}>
      <LG colors={stops.map((x) => x[1])} locations={stops.map((x) => x[0])} start={{ x: ln.x1, y: ln.y1 }} end={{ x: ln.x2, y: ln.y2 }} style={StyleSheet.absoluteFill} />
      {P.gloss ? <LG colors={[`rgba(255,255,255,${P.gloss})`, 'rgba(255,255,255,0)']} locations={[0, 0.46]} style={StyleSheet.absoluteFill} /> : null}
      {P.sparkles
        ? SPARK.map(([x, y, r, a], i) => (
            <View key={i} style={{ position: 'absolute', left: `${x * 100}%`, top: `${y * 100}%`, width: r * 2, height: r * 2, marginLeft: -r, marginTop: -r, borderRadius: r, backgroundColor: i === 2 ? '#fff6c8' : '#ffffff', opacity: a }} />
          ))
        : null}
      {P.stripes ? <Grain /> : null}
      {shade ? <LG colors={['rgba(60,30,10,0)', 'rgba(60,30,10,0.3)']} style={styles.shade} /> : null}
      {top ? <View style={styles.topLine} /> : null}
    </View>
  );
});

// the wood's grain (the house buttons' repeating 2 px brown line every ~22 px), as a few native lines
const GRAIN = [0.08, 0.2, 0.33, 0.47, 0.6, 0.74, 0.87];
const Grain = memo(function Grain() {
  return GRAIN.map((x) => <View key={x} style={[styles.grain, { left: `${x * 100}%` }]} />);
});

// a diamond tip (.mm-p.tip::before / ::after): no longer drawn (REDESIGN_V8)
// eslint-disable-next-line no-unused-vars
function Tip({ side }) {
  return (
    <View pointerEvents="none" style={[styles.tip, side === 'l' ? styles.tipL : styles.tipR]}>
      <LG colors={TIP.map((s) => s[1])} locations={TIP.map((s) => s[0])} start={{ x: 0, y: 0 }} end={{ x: 1, y: 1 }} style={styles.tipIn}>
        <View style={styles.tipShine} />
      </LG>
    </View>
  );
}

// A gentle gold glow behind a button, pulsing (@keyframes mmGlow). One native loop (idleLoop.js), which also stops
// while a screen covers this one (LoopsOn); a loop(sequence) was restarted from JS every 1.2 s.
export const Glow = memo(function Glow({ radius = 16, spread = 10 }) {
  const opacity = usePingPong(2400, { from: 0.35, to: 1 });
  return (
    // (a texture of its own: the pulse only fades it, the SVG isn't drawn again)
    <Animated.View pointerEvents="none" renderToHardwareTextureAndroid style={[StyleSheet.absoluteFill, { top: -spread, bottom: -spread, left: -spread, right: -spread, opacity }]}>
      <Svg width="100%" height="100%">
        <Defs>
          <RadialGradient id="royalGlow" cx="50%" cy="50%" rx="50%" ry="50%">
            <Stop offset="0.55" stopColor="#ffd66e" stopOpacity={0.9} />
            <Stop offset="1" stopColor="#ffd66e" stopOpacity={0} />
          </RadialGradient>
        </Defs>
        <Rect x="0" y="0" width="100%" height="100%" rx={radius + spread} fill="url(#royalGlow)" />
      </Svg>
    </Animated.View>
  );
});

function Plaque({ variant = 'vel', radius = 999, rim = 2.5, ring = 1.6, lip = 3, tips = false, glow = false, style, children, onPress, disabled, hitSlop }) {
  const P = PLAQUES[variant] || PLAQUES.vel;
  const inner = Math.max(0, radius - rim);
  const body = (pressed) => (
    <>
      {glow ? <Glow radius={Math.min(radius, 40)} /> : null}
      {/* the lip, the outline, the rim, the fill */}
      <View pointerEvents="none" style={[styles.abs, { top: -ring + lip, bottom: -ring - lip, left: -ring, right: -ring, borderRadius: radius + ring, backgroundColor: INK }]} />
      <View pointerEvents="none" style={[styles.abs, { top: -ring, bottom: -ring, left: -ring, right: -ring, borderRadius: radius + ring, backgroundColor: INK }]} />
      <LG pointerEvents="none" colors={P.rim.map((s) => s[1])} locations={P.rim.map((s) => s[0])} style={[styles.abs, styles.fill0, { borderRadius: radius }]} />
      <View pointerEvents="none" style={[styles.abs, { top: rim, bottom: rim, left: rim, right: rim, borderRadius: inner, overflow: 'hidden' }]}>
        <Fill variant={variant} />
      </View>
      {typeof children === 'function' ? children(pressed) : children}
    </>
  );
  if (!onPress) return <View style={[styles.box, style]}>{body(false)}</View>;
  return (
    <Pressable onPress={onPress} disabled={disabled} hitSlop={hitSlop} style={({ pressed }) => [styles.box, style, pressed && !disabled && styles.down]}>
      {({ pressed }) => body(pressed)}
    </Pressable>
  );
}

export default memo(Plaque);

const styles = StyleSheet.create({
  box: { position: 'relative', alignItems: 'center', justifyContent: 'center' },
  abs: { position: 'absolute' },
  fill0: { top: 0, bottom: 0, left: 0, right: 0 },
  down: { transform: [{ translateY: 2 }] },
  tip: { position: 'absolute', top: '50%', width: 11, height: 11, marginTop: -5.5, backgroundColor: INK, padding: 1.5, transform: [{ rotate: '45deg' }] },
  tipL: { left: -6 },   // (the CSS: 7 left of the padding edge, inside a 2.5 rim)
  tipR: { right: -6 },
  tipIn: { flex: 1 },
  shade: { position: 'absolute', left: 0, right: 0, bottom: 0, height: '15%' },
  topLine: { position: 'absolute', left: 0, right: 0, top: 0, height: 1.5, backgroundColor: 'rgba(255,255,255,0.55)' },
  tipShine: { position: 'absolute', left: 0, top: 0, width: 3, height: 3, backgroundColor: 'rgba(255,255,255,0.8)' },
  grain: { position: 'absolute', top: 0, bottom: 0, width: 2, backgroundColor: 'rgba(107,68,38,0.09)' },
});
