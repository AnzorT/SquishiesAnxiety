import React from 'react';
import { StyleSheet, View } from 'react-native';
import Svg, { Defs, LinearGradient, RadialGradient, Stop, Circle, Path, G } from 'react-native-svg';
import CreatureThumbnail from '../CreatureThumbnail';

// The Key Shop's key: the gold key from the design (brown outline, white
// inner line, gold gradient, 2px brown drop) with its round bow grown into a
// ring that holds the creature — so each row reads as "this creature's key".

const CX = 29; // bow centre
const CY = 29;
const R_OUT = 25; // bow ring, outer edge
const R_IN = 18; // bow ring, inner edge (the creature's window)
const SHAFT_Y = 4; // half the shaft's thickness
const SHAFT_X0 = CX + R_OUT - 0.5;
const SHAFT_X1 = CX + R_OUT + 34;

// shaft with two teeth hanging off it (the design key's bit, stretched)
const SHAFT = [
  `M${SHAFT_X0} ${CY - SHAFT_Y}`,
  `H${SHAFT_X1}`,
  `V${CY + SHAFT_Y}`,
  `H${SHAFT_X1 - 6}`,
  `V${CY + SHAFT_Y + 11}`,
  `H${SHAFT_X1 - 13}`,
  `V${CY + SHAFT_Y}`,
  `H${SHAFT_X1 - 19}`,
  `V${CY + SHAFT_Y + 8}`,
  `H${SHAFT_X1 - 26}`,
  `V${CY + SHAFT_Y}`,
  `H${SHAFT_X0}`,
  'Z',
].join(' ');

const ring = (r) => `M${CX - r} ${CY} a${r} ${r} 0 1 0 ${r * 2} 0 a${r} ${r} 0 1 0 ${-r * 2} 0 Z`;
const BOW = `${ring(R_OUT)} ${ring(R_IN)}`;

const WINDOW_R = R_IN - 2.3; // inside the white inner line

export const KEY_W = SHAFT_X1 + 4;
export const KEY_H = CY + R_OUT + 7; // ring + outline + 2px drop

export default function CreatureKey({ creature, creatureSize = 28 }) {
  return (
    <View style={{ width: KEY_W, height: KEY_H }}>
      <Svg width={KEY_W} height={KEY_H} viewBox={`0 0 ${KEY_W} ${KEY_H}`} style={{ position: 'absolute' }}>
        <Defs>
          <LinearGradient id="ckGold" x1="0" y1="0" x2="0" y2="1">
            <Stop offset="0" stopColor="#fff7b0" />
            <Stop offset="0.5" stopColor="#ffd23a" />
            <Stop offset="1" stopColor="#ff9c0a" />
          </LinearGradient>
          <RadialGradient id="ckWindow" cx={CX} cy={CY - 3} r={R_IN} gradientUnits="userSpaceOnUse">
            <Stop offset="0" stopColor="#ffffff" />
            <Stop offset="0.6" stopColor="#ffe6f7" />
            <Stop offset="1" stopColor="#f5cbff" />
          </RadialGradient>
          <RadialGradient id="ckGlow" cx={CX} cy={CY} r={R_OUT + 8} gradientUnits="userSpaceOnUse">
            <Stop offset="0.6" stopColor="#ffdc5a" stopOpacity={0.55} />
            <Stop offset="1" stopColor="#ffdc5a" stopOpacity={0} />
          </RadialGradient>
        </Defs>
        {/* soft gold glow + the 2px brown drop */}
        <Circle cx={CX} cy={CY} r={R_OUT + 8} fill="url(#ckGlow)" />
        <G stroke="#9c4d06" strokeWidth={5} strokeLinejoin="round" fill="#9c4d06" transform="translate(0,2)">
          <Circle cx={CX} cy={CY} r={R_OUT} />
          <Path d={SHAFT} />
        </G>
        {/* brown outline */}
        <G stroke="#9c4d06" strokeWidth={5} strokeLinejoin="round" fill="none">
          <Circle cx={CX} cy={CY} r={R_OUT} />
          <Path d={SHAFT} />
        </G>
        {/* the creature's window, then the gold key over its rim */}
        <Circle cx={CX} cy={CY} r={R_IN} fill="url(#ckWindow)" />
        <G stroke="#ffffff" strokeWidth={2.2} strokeLinejoin="round" fill="url(#ckGold)">
          <Path d={SHAFT} />
          <Path d={BOW} fillRule="evenodd" />
        </G>
        <Circle cx={CX} cy={CY} r={R_IN - 1.1} fill="none" stroke="#ffffff" strokeWidth={2.4} />
        {/* catch-lights, like the design key's */}
        <Circle cx={CX - 15} cy={CY - 15} r={2.4} fill="#ffffff" />
        <Path d={`M${SHAFT_X0 + 5} ${CY - 1.6} H${SHAFT_X1 - 4}`} stroke="#ffffff" strokeOpacity={0.7} strokeWidth={1.4} strokeLinecap="round" />
      </Svg>
      {/* clipped to the window, so the creature's soft glow doesn't wash
          over the gold */}
      <View style={[styles.window, { left: CX - WINDOW_R, top: CY - WINDOW_R }]}>
        <CreatureThumbnail creature={creature} mood="idle" size={creatureSize} glow={false} />
      </View>
    </View>
  );
}

const styles = StyleSheet.create({
  window: {
    position: 'absolute',
    width: WINDOW_R * 2,
    height: WINDOW_R * 2,
    borderRadius: WINDOW_R,
    overflow: 'hidden',
    alignItems: 'center',
    justifyContent: 'center',
  },
});
