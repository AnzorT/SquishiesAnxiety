import React, { memo, useState } from 'react';
import { StyleSheet, Text, View } from 'react-native';
import Svg, { Defs, G, LinearGradient, Stop, Text as SvgText } from 'react-native-svg';
import { FONT, LETTERING } from './theme';

// The menu's lettering (main-menu.js ft()): Fredoka with a gradient fill, a dark outline, a dark drop under it, a thin
// white shine along the top edges, and (gold) a white sticker edge around it all. Same layers, same widths.
// React Native text can't take a gradient or a stroke, so it's SVG text; an invisible RN <Text> measures the word
// first (as components/candy/OutlinedTitle does), because the SVG needs its width.

// react-native-svg on Android drops an I after an A ("DAILY" → "DALY"); a hair space keeps it (OutlinedTitle.js)
const svgSafe = (t) => String(t).replace(/AI/g, 'A I');
let UID = 0;

function Lettering({ text, variant = 'white', size = 20, style }) {
  const S = LETTERING[variant] || LETTERING.white;
  // the word's width: the menu's first guess (main-menu.js ft) until the measuring copy reports the real one, so the
  // lettering shows at once (a busy JS thread can hold the measurement back for a moment)
  const [measured, setW0] = useState(0);
  const w0 = measured || String(text).length * size * 0.56;
  const [id] = useState(() => 'rl' + ++UID);
  const sw = Math.max(2.4, size * 0.19);
  const ls = size * 0.02;
  const width = Math.ceil(w0 + sw * 2.4 + 4);
  const height = Math.ceil(size * 1.32 + sw);
  const y = size * 0.98 + sw / 2;
  const t = svgSafe(text);
  const common = { x: width / 2, y, textAnchor: 'middle', fontFamily: FONT.display, fontSize: size, letterSpacing: ls, strokeLinejoin: 'round' };
  const n = S.f.length - 1;
  return (
    <View style={[styles.box, style]} pointerEvents="none">
      <View style={styles.measureBox}>
        <Text style={[styles.measure, { fontSize: size, letterSpacing: ls }]} numberOfLines={1} onLayout={(e) => e.nativeEvent.layout.width > 0 && setW0(e.nativeEvent.layout.width)}>
          {text}
        </Text>
      </View>
      {(

        <Svg width={width} height={height} style={styles.svg}>
          <Defs>
            <LinearGradient id={id} x1="0" y1="0" x2={S.h ? '1' : '0'} y2={S.h ? '0' : '1'}>
              {S.f.map((c, i) => (
                <Stop key={i} offset={(i / n).toFixed(2)} stopColor={c} />
              ))}
            </LinearGradient>
          </Defs>
          {S.w ? <SvgText {...common} fill="#ffffff" stroke="#ffffff" strokeWidth={sw * 2.1}>{t}</SvgText> : null}
          <G translateY={size * 0.06}>
            <SvgText {...common} fill={S.o} stroke={S.o} strokeWidth={sw * 1.25}>{t}</SvgText>
          </G>
          {/* the outline under the fill (the CSS draws it with paint-order: stroke) */}
          <SvgText {...common} fill={S.o} stroke={S.o} strokeWidth={sw}>{t}</SvgText>
          <SvgText {...common} fill={`url(#${id})`}>{t}</SvgText>
          <G translateY={-size * 0.03}>
            <SvgText {...common} fill="none" stroke="rgba(255,255,255,0.55)" strokeWidth={size * 0.035}>{t}</SvgText>
          </G>
        </Svg>
      )}
    </View>
  );
}

export default memo(Lettering);

const styles = StyleSheet.create({
  box: { alignItems: 'center', justifyContent: 'center' },
  svg: { overflow: 'visible' },
  measureBox: { position: 'absolute', left: 0, top: 0, width: 4000, opacity: 0, alignItems: 'flex-start' },
  measure: { fontFamily: FONT.display, includeFontPadding: false },
});
