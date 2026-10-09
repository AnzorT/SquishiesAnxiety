import React, { memo, useState } from 'react';
import { Pressable, StyleSheet, Text, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Circle, Defs, G, LinearGradient as SvgLinearGradient, Path, Pattern, RadialGradient, Rect, Stop, Text as SvgText } from 'react-native-svg';
import { candyFonts } from '../theme/candyTheme';
import { CoinIcon } from '../squad/ui';
import { fmtNum } from '../format';

// The Crib's HUD, copied from the design ("Squad Crib v5" / "Squad Crib
// Vertical", the <!-- HUD --> block): round 46px buttons with a white rim,
// a three-stop gradient face, a brown ring and a 4px brown lip under it, and
// the design's own icons with their 1.5px drop shadow (a copy of the icon in
// the shadow colour, under it); the gold and red badges; the LV, coins and
// time-of-day pills; and the vertical page's big room title.

const INK = '#5b3a29';

// the faces: [top, 55%, bottom] and the icon's drop-shadow colour
const FACES = {
  pink: [['#ffd0f0', '#ff7fd0', '#d84aa8'], '#8a1f6a'],
  gold: [['#fff2c2', '#ffd36a', '#e8a63a'], '#9c5a12'],
  blue: [['#d6ecff', '#8fc4f0', '#5a92c8'], '#2f5f8f'],
  green: [['#c9e8a8', '#8fc46e', '#5f9a4a'], '#45189a'],
  purple: [['#e9d6ff', '#b38cff', '#8a5fd6'], '#6a3a8a'],
  orange: [['#ffe0b8', '#ffab5c', '#e8862a'], '#9c5a12'],
  yellow: [['#ffe9a8', '#ffd66b', '#f2b84a'], null],
  red: [['#ffab98', '#f2665a', '#d9483e'], '#8e1580'],
};

// ---- the icons (24-unit boxes; `t` paints every part one colour: the shadow copy) ----
const c = (col, t) => t || col;
const ICONS = {
  back: (t) => <Path d="M15 4 L7 12 L15 20" stroke={c('#ffffff', t)} strokeWidth={3.6} fill="none" strokeLinecap="round" strokeLinejoin="round" />,
  music: (t, off) => (
    <>
      <Path d="M9 17V5l10-2v12" stroke={c('#ffffff', t)} strokeWidth={2.6} fill="none" strokeLinejoin="round" strokeLinecap="round" />
      <Circle cx={6.5} cy={17.5} r={3} fill={c('#ffffff', t)} />
      <Circle cx={16.5} cy={15.5} r={3} fill={c('#ffffff', t)} />
      {off ? <Path d="M3 3L21 21" stroke={c('#c0392b', t)} strokeWidth={3} strokeLinecap="round" /> : null}
    </>
  ),
  rotate: (t) => (
    <>
      <Rect x={8} y={6} width={10} height={16} rx={2.5} fill="none" stroke={c('#ffffff', t)} strokeWidth={2.4} />
      <Path d="M4 9 A8 8 0 0 1 12 3 l-1.5 -1.5 M12 3 l-1.5 1.5" stroke={c('#ffffff', t)} strokeWidth={2} fill="none" strokeLinecap="round" strokeLinejoin="round" />
    </>
  ),
  map: (t) => (
    <>
      <Path d="M3 6l6-2 6 2 6-2v14l-6 2-6-2-6 2z" fill={c('#ffffff', t)} />
      <Path d="M9 4v14M15 6v14" stroke={c('#8fc46e', t)} strokeWidth={1.6} />
      <Circle cx={12} cy={10} r={2.4} fill={c('#ff4fbf', t)} />
    </>
  ),
  shop: (t) => (
    <>
      <Path d="M3 9 L4.6 3 H19.4 L21 9 Z" fill={c('#ffffff', t)} />
      <Path d="M8.2 3 L7.4 9 M12 3 V9 M15.8 3 L16.6 9" stroke={c('#8a5fd6', t)} strokeWidth={1.7} />
      <Path d="M3 9 q1.5 2.6 3 0 q1.5 2.6 3 0 q1.5 2.6 3 0 q1.5 2.6 3 0 q1.5 2.6 3 0 q1.5 2.6 3 0Z" fill={c('#ffffff', t)} />
      <Rect x={4.6} y={11.6} width={14.8} height={9.4} rx={1.2} fill="none" stroke={c('#ffffff', t)} strokeWidth={2} />
      <Path d="M7.6 19 V16.6 a1.2 1.2 0 0 1 1.2 -1.2 h6.4 a1.2 1.2 0 0 1 1.2 1.2 V19 Z" fill={c('#ffffff', t)} />
    </>
  ),
  edit: (t) => (
    <>
      <Path d="M4 20 L5 15 L16 4 L20 8 L9 19 Z" fill={c('#ffffff', t)} />
      <Path d="M14 6 L18 10" stroke={c('#e8862a', t)} strokeWidth={2} />
      <Path d="M4 20 L9 19 L5 15 Z" fill={c('#ffd66b', t)} />
    </>
  ),
  daily: () => (
    <>
      <Rect x={4} y={3.5} width={16} height={18} rx={3} fill="#fff6e6" stroke={INK} strokeWidth={2} />
      <Rect x={8.5} y={2} width={7} height={4} rx={1.5} fill="#f2665a" stroke={INK} strokeWidth={1.6} />
      <Path d="M7.5 11l1.6 1.6 3-3" stroke="#4f9a3a" strokeWidth={2} fill="none" strokeLinecap="round" strokeLinejoin="round" />
      <Path d="M13.5 11.5h3.5M7.5 16.5h9.5" stroke={INK} strokeWidth={2} strokeLinecap="round" />
    </>
  ),
  // the kitchen's pantry shop: a basket with an apple and a carrot in it
  pantry: (t) => (
    <>
      <Circle cx={9} cy={8.6} r={3.4} fill={c('#f2665a', t)} />
      <Path d="M9 5.4 q0.6 -2 2.2 -2.4" stroke={c('#4f9a3a', t)} strokeWidth={1.6} fill="none" strokeLinecap="round" />
      <Path d="M14 10 L17.5 3.5" stroke={c('#ff9a3c', t)} strokeWidth={3.2} strokeLinecap="round" />
      <Path d="M17.5 3.5 l1.8 -1.4 M17.5 3.5 l2.2 0.2" stroke={c('#4f9a3a', t)} strokeWidth={1.5} strokeLinecap="round" />
      <Path d="M2.5 10 H21.5 L19.6 20 A2 2 0 0 1 17.6 21.6 H6.4 A2 2 0 0 1 4.4 20 Z" fill={c('#ffffff', t)} />
      <Path d="M8.5 13 V18.6 M12 13 V18.6 M15.5 13 V18.6" stroke={c('#d9483e', t)} strokeWidth={1.7} strokeLinecap="round" />
    </>
  ),
};

export function HudIcon({ name, size = 24, shadow, off = false, turn = false }) {
  const draw = ICONS[name];
  return (
    <Svg width={size} height={size + 2} viewBox="0 0 24 26" style={turn ? { transform: [{ rotate: '90deg' }] } : null}>
      {shadow ? <G transform="translate(0 1.5)">{draw(shadow, off)}</G> : null}
      {draw(null, off)}
    </Svg>
  );
}

// a badge on a button's corner: gold (needs) or red (the daily)
function Badge({ kind, value, round }) {
  const gold = kind === 'gold';
  return (
    <View pointerEvents="none" style={[styles.badgeRing, { backgroundColor: gold ? '#a04a00' : INK }, gold ? styles.badgeAtGold : styles.badgeAtRed]}>
      {gold ? (
        <LinearGradient colors={['#fff6a8', '#ffd83a', '#f08c00']} locations={[0, 0.42, 1]} style={[styles.badgeFace, round && styles.badgeRound]}>
          <Text style={[styles.badgeText, { color: '#7a3d00' }]}>{value}</Text>
        </LinearGradient>
      ) : (
        <View style={[styles.badgeFace, styles.badgeRed]}>
          <Text style={[styles.badgeText, { color: '#ffffff', fontSize: 10 }]}>{value}</Text>
        </View>
      )}
    </View>
  );
}

// a round HUD button: `face` one of FACES, `icon` one of the icons
export function CribButton({ face, icon, size = 46, iconSize = 24, onPress, badge, badgeKind = 'gold', badgeRound = false, dim = false, off = false, turn = false }) {
  const [colors, shadow] = FACES[face] || FACES.pink;
  return (
    <Pressable onPress={onPress} hitSlop={4} style={{ opacity: dim ? 0.45 : 1 }}>
      {({ pressed }) => (
        <View style={{ width: size + 4, height: size + 8, transform: [{ translateY: pressed ? 3 : 0 }] }}>
          <View style={[styles.circle, { top: pressed ? 1 : 4, width: size + 4, height: size + 4, borderRadius: (size + 4) / 2 }]} />
          <View style={[styles.circle, { top: 0, width: size + 4, height: size + 4, borderRadius: (size + 4) / 2 }]} />
          <View style={[styles.face, { width: size, height: size, borderRadius: size / 2 }]}>
            <LinearGradient colors={colors} locations={[0, 0.55, 1]} style={StyleSheet.absoluteFill} />
            <HudIcon name={icon} size={iconSize} shadow={shadow} off={off} turn={turn} />
          </View>
          {badge ? <Badge kind={badgeKind} value={badge} round={badgeRound} /> : null}
        </View>
      )}
    </Pressable>
  );
}

// "LV 3": the gold pill
export function LevelPill({ level }) {
  return (
    <View style={styles.lvRing}>
      <View style={styles.lvFace}>
        <Text style={styles.lvText}>{`LV ${level}`}</Text>
      </View>
    </View>
  );
}

// "1,261 · +4.5/s": the brown glass pill, with v2's coin (the shared coin.svg)
export function CoinsPill({ coins, rate }) {
  const r = rate == null ? '' : ` · ${rate >= 0 ? '+' : ''}${rate.toFixed(1)}/s`;
  return (
    <View style={styles.coins}>
      <CoinIcon size={18} />
      <Text style={styles.coinsText} numberOfLines={1}>{`${fmtNum(Math.max(0, coins))}${r}`}</Text>
    </View>
  );
}

// "● EVENING"
export function PhasePill({ sun, label }) {
  return (
    <View style={styles.phase}>
      <View style={[styles.sun, { backgroundColor: sun }]} />
      <Text style={styles.phaseText}>{label}</Text>
    </View>
  );
}

// The room-switch flash (Crib Vertical v2): white dots every 22px over a
// radial white → lavender → sky blue. The screen fades it in and out.
export const RoomFlash = memo(function RoomFlash() {
  return (
    <Svg width="100%" height="100%">
      <Defs>
        <RadialGradient id="roomFlash" cx="50%" cy="50%" r="71%">
          <Stop offset="0" stopColor="#ffffff" />
          <Stop offset="0.55" stopColor="#e6dcff" />
          <Stop offset="1" stopColor="#8fd0ff" />
        </RadialGradient>
        <Pattern id="roomFlashDots" width={22} height={22} patternUnits="userSpaceOnUse">
          <Circle cx={0} cy={0} r={1.5} fill="rgba(255,255,255,0.9)" />
          <Circle cx={22} cy={0} r={1.5} fill="rgba(255,255,255,0.9)" />
          <Circle cx={0} cy={22} r={1.5} fill="rgba(255,255,255,0.9)" />
          <Circle cx={22} cy={22} r={1.5} fill="rgba(255,255,255,0.9)" />
        </Pattern>
      </Defs>
      <Rect width="100%" height="100%" fill="url(#roomFlash)" />
      <Rect width="100%" height="100%" fill="url(#roomFlashDots)" />
    </Svg>
  );
});

// The vertical page's room title: Fredoka 26, a cream-to-peach gradient
// inside a brown outline with a deeper drop; the line under it in white
// outlined text.
export function RoomTitle({ title, sub }) {
  const [w, setW] = useState(0);
  const size = 26;
  const pad = 4;
  const common = { x: pad, y: pad + size * 0.92, fontFamily: candyFonts.display, fontSize: size, letterSpacing: 0.5, strokeLinejoin: 'round' };
  return (
    <View style={{ minWidth: 0 }}>
      <View style={styles.measureBox} pointerEvents="none">
        <Text style={[styles.measure, { fontSize: size, letterSpacing: 0.5 }]} onLayout={(e) => setW(e.nativeEvent.layout.width)} numberOfLines={1}>
          {title}
        </Text>
      </View>
      {w ? (
        <Svg width={w + pad * 2 + 4} height={size * 1.15 + pad * 2 + 3}>
          <Defs>
            <SvgLinearGradient id="roomTitle" x1="0" y1="0" x2="0" y2="1">
              <Stop offset="0" stopColor="#fffaf0" />
              <Stop offset="0.6" stopColor="#ffe6b8" />
              <Stop offset="1" stopColor="#ffcf80" />
            </SvgLinearGradient>
          </Defs>
          <SvgText {...common} y={common.y + 3} fill={INK} stroke={INK} strokeWidth={5}>
            {title}
          </SvgText>
          <SvgText {...common} fill={INK} stroke={INK} strokeWidth={5}>
            {title}
          </SvgText>
          <SvgText {...common} fill="url(#roomTitle)">
            {title}
          </SvgText>
        </Svg>
      ) : (
        <View style={{ height: size * 1.15 + pad * 2 + 3 }} />
      )}
      {sub ? (
        <Text style={styles.sub} numberOfLines={2}>
          {sub}
        </Text>
      ) : null}
    </View>
  );
}

const styles = StyleSheet.create({
  circle: { position: 'absolute', left: 0, backgroundColor: INK },
  face: { position: 'absolute', left: 2, top: 2, borderWidth: 2.5, borderColor: '#ffffff', overflow: 'hidden', alignItems: 'center', justifyContent: 'center' },
  badgeRing: { position: 'absolute', borderRadius: 11, padding: 1 },
  badgeAtGold: { right: -6, top: -6 },
  badgeAtRed: { right: -5, top: -5 },
  badgeFace: { minWidth: 18, height: 18, paddingHorizontal: 3, borderRadius: 9, borderWidth: 2, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  badgeRound: { minWidth: 18, width: 18, paddingHorizontal: 0 },
  badgeRed: { backgroundColor: '#f2665a' },
  badgeText: { fontFamily: candyFonts.bodyBlack, fontSize: 11, lineHeight: 14, includeFontPadding: false },
  lvRing: { borderRadius: 999, padding: 1.5, backgroundColor: INK },
  lvFace: { borderRadius: 999, borderWidth: 2, borderColor: '#ffffff', backgroundColor: '#ffd66b', paddingHorizontal: 9, paddingVertical: 2 },
  lvText: { fontFamily: candyFonts.display, fontSize: 12, color: INK },
  coins: { flexDirection: 'row', alignItems: 'center', gap: 5, backgroundColor: 'rgba(91,58,41,0.75)', borderWidth: 2, borderColor: 'rgba(255,255,255,0.9)', borderRadius: 999, paddingHorizontal: 12, paddingVertical: 5 },
  coinsText: { fontFamily: candyFonts.bodyHeavy, fontSize: 14, color: '#fff3a0', textShadowColor: '#6a1b9a', textShadowRadius: 0.5, textShadowOffset: { width: 0, height: 1 } },
  phase: { flexDirection: 'row', alignItems: 'center', gap: 6, paddingHorizontal: 11, paddingVertical: 4, borderRadius: 999, backgroundColor: 'rgba(91,58,41,0.75)', borderWidth: 2, borderColor: 'rgba(255,255,255,0.9)' },
  sun: { width: 9, height: 9, borderRadius: 5 },
  phaseText: { fontFamily: candyFonts.bodyBlack, fontSize: 11, color: '#ffffff', letterSpacing: 0.6 },
  measureBox: { position: 'absolute', left: 0, top: 0, width: 1000, opacity: 0 },
  measure: { position: 'absolute', fontFamily: candyFonts.display },
  sub: { fontFamily: candyFonts.bodyBlack, fontSize: 11, color: '#ffffff', letterSpacing: 0.6, marginTop: -2, textShadowColor: INK, textShadowRadius: 1.5, textShadowOffset: { width: 0, height: 1 } },
});
