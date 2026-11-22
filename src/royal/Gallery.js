import React, { useEffect } from 'react';
import { BackHandler, StyleSheet, Text, View } from 'react-native';
import * as ScreenOrientation from 'expo-screen-orientation';
import { Btn, Icon, InkText, Lettering, Orb, PageBg, PageHeader, Pill, Plaque, Stage, FONT, ICON, INK } from './index';

// Debug builds only: the kit side by side with the menu (REDESIGN_V7 step 0). Open with
//   adb shell am start -a android.intent.action.VIEW -d "com.plushcrush.app://royal" com.plushcrush.app
// The top bar and PLAY sit exactly where the Main Menu draws them, so a screenshot of each can be compared.
const Tab = ({ label, icon, gold }) => (
  <Plaque variant={gold ? 'gold' : 'vel'} tips style={styles.tab}>
    <Icon d={ICON[icon]} size={14} color={gold ? INK : '#ffffff'} width={2.5} drop={false} />
    {gold ? <Text style={styles.tabGold}>{label}</Text> : <InkText size={12.5} style={{ letterSpacing: 0.6 }}>{label}</InkText>}
  </Plaque>
);

export default function RoyalGallery({ onClose }) {
  useEffect(() => {
    ScreenOrientation.lockAsync(ScreenOrientation.OrientationLock.LANDSCAPE).catch(() => {});
    const sub = BackHandler.addEventListener('hardwareBackPress', () => (onClose(), true));
    return () => sub.remove();
  }, [onClose]);
  return (
    <View style={styles.root}>
      <PageBg />
      <Stage>
        {/* the Main Menu's top bar (main-menu.js .mm-top) */}
        <View style={styles.top}>
          <Lettering text="SQUAD" variant="gold" size={30} style={{ marginHorizontal: 2 }} />
          <View style={styles.tabs}>
            <Tab label="CRIBFLUF" icon="house" gold />
            <Tab label="CHARACTERS" icon="grid" />
            <Tab label="SHOP" icon="shop" />
          </View>
          <View style={{ flex: 1 }} />
          <Pill cur="coins" amount={32282} />
          <Pill cur="gems" amount={975} style={{ marginLeft: 9 }} />
          <Orb icon="gear" iconWidth={2.2} style={{ marginLeft: 9 }} onPress={onClose} />
        </View>
        {/* a page header, as the Game Park / Level Pass draw it */}
        <PageHeader title="Royal Kit" note="REDESIGN_V7 step 0 · the menu's look in React Native" onBack={onClose} style={{ top: 58 }} />
        {/* the plaques */}
        <View style={styles.row}>
          {['vel', 'gold', 'bronze', 'wood', 'amy', 'pearl', 'rainbow'].map((v) => (
            <Plaque key={v} variant={v} tips style={styles.chip}>
              <Text style={[styles.chipT, { color: v === 'gold' || v === 'pearl' || v === 'rainbow' ? INK : '#fff' }]}>{v}</Text>
            </Plaque>
          ))}
        </View>
        {/* the lettering */}
        <View style={[styles.row, { top: 168, gap: 12 }]}>
          {['gold', 'goldB', 'white', 'whiteB', 'wood', 'bronze', 'amethyst', 'rainbow'].map((v) => (
            <Lettering key={v} text={v === 'goldB' ? 'Aa' : v.slice(0, 5)} variant={v} size={22} />
          ))}
        </View>
        {/* a card, as the Level Pass's preview */}
        <Plaque variant="vel" radius={22} rim={3.5} ring={2} lip={4} style={styles.card}>
          <Lettering text="LEVEL 7" variant="gold" size={20} />
          <Lettering text="Common Chest" variant="white" size={17} />
          <Text style={styles.cardT}>A chest of new characters</Text>
          <Btn label="CLAIM" size={19} width={196} height={42} glow onPress={() => {}} />
        </Plaque>
        <View style={styles.orbs}>
          <Orb icon="back" />
          <Orb icon="close" />
          <Orb icon="pause" />
          <Orb icon="restart" iconWidth={2.6} />
          </View>
        <View style={[styles.orbs, { top: 292 }]}>
          <Btn label="UNDO" variant="vel" size={15} width={92} height={36} radius={12} />
          <Btn label="HINT" size={15} width={92} height={36} radius={12} />
        </View>
        {/* PLAY, where the menu has it (.mm-card.sq-solo: left 18, bottom 18, 212 x 64) */}
        <Btn label="PLAY" size={34} width={212} height={64} radius={20} glow glint style={styles.play} />
      </Stage>
    </View>
  );
}

const styles = StyleSheet.create({
  root: { ...StyleSheet.absoluteFillObject, backgroundColor: '#24123f', zIndex: 1000, elevation: 1000 },
  top: { position: 'absolute', left: 14, right: 14, top: 9, flexDirection: 'row', alignItems: 'center', gap: 7 },
  tabs: { flexDirection: 'row', gap: 10, paddingHorizontal: 6 },
  tab: { height: 30, paddingHorizontal: 13, flexDirection: 'row', alignItems: 'center', gap: 5 },
  tabGold: { fontFamily: FONT.display, fontSize: 12.5, letterSpacing: 0.6, color: INK, includeFontPadding: false },
  row: { position: 'absolute', left: 30, right: 290, top: 122, flexDirection: 'row', alignItems: 'center', gap: 22 },
  chip: { height: 30, paddingHorizontal: 14 },
  chipT: { fontFamily: FONT.display, fontSize: 13, includeFontPadding: false },
  card: { position: 'absolute', right: 24, top: 120, width: 236, height: 250, paddingVertical: 14, gap: 8, justifyContent: 'flex-start' },
  cardT: { fontFamily: FONT.body, fontSize: 11.5, color: '#eadcff' },
  orbs: { position: 'absolute', left: 250, top: 232, flexDirection: 'row', alignItems: 'center', gap: 16 },
  play: { position: 'absolute', left: 18, bottom: 18 },
});
