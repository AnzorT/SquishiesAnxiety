import React, { useEffect, useRef, useState } from 'react';
import { Animated, Easing, StyleSheet, Text, View } from 'react-native';
import Svg, { Defs, LinearGradient, Stop, Text as SvgText } from 'react-native-svg';
import { candyColors, candyFonts, TITLE_FILLS } from '../../theme/candyTheme';

// The design's sticker title: gradient-filled Fredoka inside a white outline,
// a thinner purple halo outside that, and a hard deep-purple drop underneath.
// React Native text can't take a gradient fill or a stroke, so this draws
// the word as layered SVG text. The SVG needs a concrete width, so an
// invisible RN <Text> with the same font measures the word first.

export default function OutlinedTitle({
  text,
  fill = 'pink', // 'pink' | 'gold' | { colors, locations }
  size = 30,
  outline = 3,
  letterSpacing = 1,
  wobble = false,
  style,
}) {
  const [textW, setTextW] = useState(0);
  const grad = typeof fill === 'string' ? TITLE_FILLS[fill] || TITLE_FILLS.pink : fill;
  const halo = outline + 2;
  const drop = size >= 26 ? 5 : size >= 18 ? 4 : 3;
  const width = Math.ceil(textW + halo * 2 + 2);
  const height = Math.ceil(size * 1.22 + halo * 2 + drop);
  const baseline = halo + size * 0.96;

  const wob = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    if (!wobble) return undefined;
    const loop = Animated.loop(
      Animated.sequence([
        Animated.timing(wob, { toValue: 1, duration: 1300, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
        Animated.timing(wob, { toValue: 0, duration: 1300, easing: Easing.inOut(Easing.sin), useNativeDriver: true }),
      ])
    );
    loop.start();
    return () => loop.stop();
  }, [wobble, wob]);
  const rotate = wob.interpolate({ inputRange: [0, 1], outputRange: ['-3deg', '3deg'] });
  const scale = wob.interpolate({ inputRange: [0, 1], outputRange: [1, 1.05] });

  const common = {
    x: width / 2,
    y: baseline,
    textAnchor: 'middle',
    fontFamily: candyFonts.display,
    fontSize: size,
    letterSpacing,
    strokeLinejoin: 'round',
  };

  return (
    <Animated.View style={[{ alignItems: 'center' }, wobble && { transform: [{ rotate }, { scale }] }, style]}>
      <Text
        style={[styles.measure, { fontSize: size, letterSpacing }]}
        onLayout={(e) => setTextW(e.nativeEvent.layout.width)}
        numberOfLines={1}
      >
        {text}
      </Text>
      {textW > 0 ? (
        <Svg width={width} height={height}>
          <Defs>
            <LinearGradient id="titleFill" x1="0" y1="0" x2="0" y2="1">
              {grad.colors.map((c, i) => (
                <Stop key={`${c}${i}`} offset={grad.locations[i]} stopColor={c} />
              ))}
            </LinearGradient>
          </Defs>
          <SvgText {...common} y={baseline + drop} fill={candyColors.outlineDeep} stroke={candyColors.outlineDeep} strokeWidth={halo * 2}>
            {text}
          </SvgText>
          <SvgText {...common} fill={candyColors.outline} stroke={candyColors.outline} strokeWidth={halo * 2}>
            {text}
          </SvgText>
          <SvgText {...common} fill="#ffffff" stroke="#ffffff" strokeWidth={outline * 2}>
            {text}
          </SvgText>
          <SvgText {...common} fill="url(#titleFill)">
            {text}
          </SvgText>
        </Svg>
      ) : (
        <View style={{ height }} />
      )}
    </Animated.View>
  );
}

// White text with the purple halo + drop used for small headings on the
// stage (nickname, "Getting Ready", section labels). Plain RN text.
export function HaloText({ children, style, numberOfLines }) {
  return (
    <Text style={[styles.halo, style]} numberOfLines={numberOfLines}>
      {children}
    </Text>
  );
}

const styles = StyleSheet.create({
  measure: {
    position: 'absolute',
    opacity: 0,
    fontFamily: candyFonts.display,
    includeFontPadding: false,
  },
  halo: {
    color: '#ffffff',
    fontFamily: candyFonts.display,
    textShadowColor: candyColors.outline,
    textShadowOffset: { width: 0, height: 2 },
    textShadowRadius: 2,
  },
});
