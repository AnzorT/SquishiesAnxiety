import React from 'react';
import { StyleSheet, Text, View } from 'react-native';

// Text with several hard (unblurred) shadows, like CSS
// `text-shadow: 0 2px 0 #9c4d06, 1px 0 0 #9c4d06, -1px 0 0 #9c4d06` — the
// design's way of outlining button captions, "★ OWNED", tab labels and so on.
// React Native text takes a single shadow, so each one is a copy of the text
// laid exactly under the real one and nudged by its offset.
//
// `shadows`: [[dx, dy, color], …] — listed top-most first, as in CSS.

export const outline3 = (color, down = 2) => [
  [0, down, color],
  [1, 0, color],
  [-1, 0, color],
];

export default function ShadowText({ children, style, shadows = [], numberOfLines, containerStyle }) {
  const flat = StyleSheet.flatten(style) || {};
  // Anything that positions the text belongs on the wrapper, so the copies
  // and the text itself share one box.
  const { margin, marginTop, marginBottom, marginLeft, marginRight, marginHorizontal, marginVertical, alignSelf, position, top, left, right, bottom, ...textStyle } = flat;
  const outer = { margin, marginTop, marginBottom, marginLeft, marginRight, marginHorizontal, marginVertical, alignSelf, position, top, left, right, bottom };
  Object.keys(outer).forEach((k) => outer[k] === undefined && delete outer[k]);
  return (
    <View style={[outer, containerStyle]}>
      {shadows
        .slice()
        .reverse()
        .map(([dx, dy, color], i) => (
          <Text
            key={i}
            numberOfLines={numberOfLines}
            style={[textStyle, styles.copy, { color, textShadowRadius: 0, textShadowColor: 'transparent', transform: [{ translateX: dx }, { translateY: dy }] }]}
            accessibilityElementsHidden
            importantForAccessibility="no-hide-descendants"
          >
            {children}
          </Text>
        ))}
      <Text numberOfLines={numberOfLines} style={[textStyle, { textShadowRadius: 0, textShadowColor: 'transparent' }]}>
        {children}
      </Text>
    </View>
  );
}

const styles = StyleSheet.create({
  copy: { ...StyleSheet.absoluteFillObject },
});
