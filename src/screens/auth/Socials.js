import React from 'react';
import { StyleSheet, Text, View } from 'react-native';
import Svg, { Circle, Path } from 'react-native-svg';
import { Plaque, FONT, INK } from '../../royal';
import { tap } from './kit';

// Google / Facebook / TikTok sign-in (the web flow in src/firebase/social.js; a provider not set up yet says so):
// three cream buttons in the menu's plaque style, each with its own logo (small SVGs, drawn once).

const GoogleLogo = ({ s }) => (
  <Svg width={s} height={s} viewBox="0 0 24 24">
    <Path d="M21.6 12.2c0-.7-.1-1.4-.2-2H12v3.8h5.4a4.6 4.6 0 0 1-2 3v2.5h3.2c1.9-1.7 3-4.3 3-7.3z" fill="#4285F4" />
    <Path d="M12 22c2.7 0 5-.9 6.6-2.5l-3.2-2.5c-.9.6-2 1-3.4 1a5.9 5.9 0 0 1-5.6-4.1H3.1v2.6A10 10 0 0 0 12 22z" fill="#34A853" />
    <Path d="M6.4 13.9a6 6 0 0 1 0-3.8V7.5H3.1a10 10 0 0 0 0 9z" fill="#FBBC05" />
    <Path d="M12 6c1.5 0 2.8.5 3.8 1.5l2.9-2.9A10 10 0 0 0 3.1 7.5l3.3 2.6A5.9 5.9 0 0 1 12 6z" fill="#EA4335" />
  </Svg>
);
const FacebookLogo = ({ s }) => (
  <Svg width={s} height={s} viewBox="0 0 24 24">
    <Circle cx={12} cy={12} r={11} fill="#1877F2" />
    <Path d="M13.2 19v-6.1h2.1l.3-2.4h-2.4V9c0-.7.2-1.2 1.2-1.2h1.3V5.7c-.2 0-1-.1-1.9-.1-1.9 0-3.1 1.1-3.1 3.2v1.7H8.6v2.4h2.1V19z" fill="#ffffff" />
  </Svg>
);
const TT = 'M14.6 6.5c.4 1.3 1.4 2.2 2.7 2.3v2a4.6 4.6 0 0 1-2.7-.9v4.2a3.6 3.6 0 1 1-3.6-3.6h.4v2.1a1.5 1.5 0 1 0 1.1 1.5V6.5z';
const TikTokLogo = ({ s }) => (
  <Svg width={s} height={s} viewBox="0 0 24 24">
    <Circle cx={12} cy={12} r={11} fill="#111111" />
    <Path d={TT} fill="#25F4EE" transform="translate(-0.5,-0.4)" />
    <Path d={TT} fill="#FE2C55" transform="translate(0.5,0.4)" />
    <Path d={TT} fill="#ffffff" />
  </Svg>
);
const SOCIALS = [
  ['google', 'Google', GoogleLogo],
  ['facebook', 'Facebook', FacebookLogo],
  ['tiktok', 'TikTok', TikTokLogo],
];

export default function Socials({ height, onPick }) {
  const s = Math.round(height * 0.62);
  return (
    <View style={styles.row}>
      {SOCIALS.map(([id, label, Logo]) => (
        <Plaque key={id} variant="pearl" radius={14} onPress={tap(() => onPick(id))} style={[styles.btn, { height }]}>
          <Logo s={s} />
          <Text style={styles.label}>{label}</Text>
        </Plaque>
      ))}
    </View>
  );
}

const styles = StyleSheet.create({
  row: { flexDirection: 'row', gap: 12 },
  btn: { flex: 1, flexDirection: 'row', gap: 8 },
  label: { fontFamily: FONT.display, fontSize: 15, color: INK, includeFontPadding: false },
});
