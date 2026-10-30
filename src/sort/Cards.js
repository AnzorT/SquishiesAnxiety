import React, { useEffect, useRef, useState } from 'react';
import { Animated, StyleSheet, Text, View } from 'react-native';
import Svg, { Path } from 'react-native-svg';
import OutlinedTitle from '../components/candy/OutlinedTitle';
import { RaysSpin } from '../components/candy/Decor';
import { CoinIcon } from '../squad/ui';
import sfx from '../audio/sfx';
import { CountUp, FxLayer, PopIn, Rock, SlideIn } from '../squishdoku/fx';
import { Overlay, XpGain, XpPlus } from '../squishdoku/Overlays';
import { BtnLabel, Head, SdButton } from '../squishdoku/ui';
import { F, INK } from '../squishdoku/theme';
import { BLITZ_ROUNDS, HEARTS, TIER_NAMES, clock } from './levels';

// Squish Sort's cards over the game: the win (stars popping in one by one,
// coins counting up), the fail (out of hearts or time), pause, and how to
// play.

const STAR_D = 'M12 2.2 L14.9 8.6 L21.8 9.3 L16.6 14 L18.1 20.9 L12 17.4 L5.9 20.9 L7.4 14 L2.2 9.3 L9.1 8.6 Z';

// a result star popping in (Squish Stack's result card too)
export function Star({ earned, delay, big }) {
  const t = useRef(new Animated.Value(0)).current;
  const fx = useRef(null);
  const size = big ? 74 : 60;
  useEffect(() => {
    const timer = setTimeout(() => earned && fx.current?.burst('gold', size / 2 + 10, size / 2 + 10, 1), delay + 60);
    Animated.spring(t, { toValue: 1, friction: earned ? 3.6 : 7, tension: earned ? 170 : 120, delay, useNativeDriver: true }).start();
    return () => clearTimeout(timer);
  }, [t, delay, earned, size]);
  const scale = t.interpolate({ inputRange: [0, 1], outputRange: [earned ? 0 : 1.5, 1] });
  const rotate = t.interpolate({ inputRange: [0, 1], outputRange: [earned ? '-40deg' : '0deg', '0deg'] });
  return (
    <View style={{ width: size + 20, height: size + 20, alignItems: 'center', justifyContent: 'center', marginTop: big ? -12 : 6 }}>
      {earned ? (
        <Animated.View pointerEvents="none" style={{ position: 'absolute', opacity: t }}>
          <RaysSpin size={size * 1.8} color="#ffe45c" opacity={0.6} />
        </Animated.View>
      ) : null}
      <Animated.View style={{ opacity: t.interpolate({ inputRange: [0, 0.2, 1], outputRange: [0, 1, 1] }), transform: [{ scale }, { rotate }] }}>
        <Svg width={size} height={size} viewBox="0 0 24 24">
          <Path d={STAR_D} fill={earned ? '#b86200' : 'rgba(69,16,122,0.25)'} transform="translate(0 1.2)" strokeLinejoin="round" />
          <Path d={STAR_D} fill={earned ? '#ffd23a' : 'rgba(255,255,255,0.7)'} stroke="#ffffff" strokeWidth={1.6} strokeLinejoin="round" />
          {earned ? <Path d="M8 9.6 L10.4 9.2 L11.3 7" stroke="#fff6c4" strokeWidth={1.4} strokeLinecap="round" fill="none" /> : null}
        </Svg>
      </Animated.View>
      <FxLayer ref={fx} />
    </View>
  );
}

const TITLES = ['', 'SORTED!', 'NICE SORTING!', 'PERFECT MEMORY!'];
const STEP = 480;

// res: { stars, coins, xp, before, after, levelUps, mistakes, ms, unlocked };
// `last`: level 50, no NEXT
export function ResultCard({ visible, res, spec, theme, last, onNext, onReplay, onHub }) {
  const [key, setKey] = useState(0);
  useEffect(() => {
    if (!visible || !res) return undefined;
    setKey((k) => k + 1);
    const timers = [0, 1, 2].map((i) => setTimeout(() => sfx.play(i < res.stars ? `sd_star${i + 1}` : 'sd_starEmpty'), 380 + i * STEP));
    if (res.stars === 3) timers.push(setTimeout(() => sfx.play('sd_perfect'), 380 + 3 * STEP));
    return () => timers.forEach(clearTimeout);
  }, [visible, res]);
  if (!res) return <Overlay visible={false} />;
  const coinsAt = 380 + 3 * STEP + 200;
  return (
    <Overlay visible={visible}>
      <PopIn trigger={key} delay={80}>
        <OutlinedTitle text={TITLES[res.stars]} size={res.stars === 3 ? 27 : 30} fill={res.stars === 3 ? 'gold' : 'pink'} />
      </PopIn>
      <Text style={styles.sub}>{`LEVEL ${spec.lv} · ${TIER_NAMES[spec.tier]} · ${clock(res.ms)}${res.mistakes ? ` · ${res.mistakes} MISTAKE${res.mistakes > 1 ? 'S' : ''}` : ' · NO MISTAKES'}`}</Text>
      {res.stars < 3 && !res.mistakes ? <Text style={styles.hint}>{`Under ${clock(spec.parMs)} for 3 stars!`}</Text> : null}
      <View key={key} style={styles.stars}>
        {[0, 1, 2].map((i) => (
          <Star key={i} earned={i < res.stars} delay={380 + i * STEP} big={i === 1} />
        ))}
      </View>
      <SlideIn trigger={key} delay={coinsAt - 150} dy={20} style={styles.rewardRow}>
        <CoinIcon size={26} />
        <CountUp value={res.coins} delay={coinsAt} ms={800} style={styles.coins} prefix="+" onTick={() => sfx.play('sd_coinTick')} />
        <XpPlus xp={res.xp} />
      </SlideIn>
      <XpGain trigger={key} res={res} delay={coinsAt + 500} />
      {res.unlocked ? (
        <PopIn trigger={key} delay={coinsAt + 500}>
          <Text style={styles.unlocked}>{`LEVEL ${spec.lv + 1} UNLOCKED`}</Text>
        </PopIn>
      ) : null}
      <SlideIn trigger={key} delay={380 + 2 * STEP + 300} dy={30} style={styles.btnRow}>
        <SdButton kind="white" onPress={onHub} sound="sd_select" faceStyle={styles.smallFace}>
          <BtnLabel kind="purple" size={15}>
            MENU
          </BtnLabel>
        </SdButton>
        <SdButton kind="purple" onPress={onReplay} sound="sd_select" faceStyle={styles.smallFace}>
          <BtnLabel kind="purple" size={15}>
            REPLAY
          </BtnLabel>
        </SdButton>
        {!last ? (
          <SdButton kind="green" onPress={onNext} sound="sd_select" faceStyle={styles.bigFace}>
            <BtnLabel kind="green" size={18}>
              NEXT ▶
            </BtnLabel>
          </SdButton>
        ) : null}
      </SlideIn>
    </Overlay>
  );
}

// Out of hearts, or out of time: the right spots were shown on the shelves.
export function FailCard({ visible, reason, uri, onRetry, onHub }) {
  return (
    <Overlay visible={visible} tint="rgba(80,0,30,0.5)">
      <PopIn trigger={visible} delay={60}>
        <OutlinedTitle text={reason === 'time' ? "TIME'S UP!" : 'OH NO!'} size={32} fill="pink" />
      </PopIn>
      <PopIn trigger={visible} delay={220}>
        <Rock deg={8} ms={1800}>
          <Head uri={uri} size={86} dim ring="#ffffff" bg="#efe9f5" />
        </Rock>
      </PopIn>
      <Text style={styles.body}>{reason === 'time' ? 'The clock ran out. You saw where they go. Try again!' : `${HEARTS} mistakes. You saw where they go. Try again!`}</Text>
      <SlideIn trigger={visible} delay={380} style={styles.btnRow}>
        <SdButton kind="white" onPress={onHub} sound="sd_select" faceStyle={styles.smallFace}>
          <BtnLabel kind="purple" size={15}>
            MENU
          </BtnLabel>
        </SdButton>
        <SdButton kind="pink" onPress={onRetry} sound="sd_select" faceStyle={styles.bigFace}>
          <BtnLabel kind="pink" size={18}>
            RETRY
          </BtnLabel>
        </SdButton>
      </SlideIn>
    </Overlay>
  );
}

export function PauseCard({ visible, onResume, onRestart, onQuit }) {
  return (
    <Overlay visible={visible}>
      <OutlinedTitle text="PAUSED" size={30} fill="pink" />
      <Text style={styles.body}>The clock is stopped.</Text>
      <View style={styles.col}>
        <SdButton kind="green" onPress={onResume} sound="sd_resume" faceStyle={styles.wideFace}>
          <BtnLabel kind="green" size={18}>
            RESUME
          </BtnLabel>
        </SdButton>
        <SdButton kind="purple" onPress={onRestart} sound="sd_select" faceStyle={styles.wideFace}>
          <BtnLabel kind="purple" size={16}>
            RESTART LEVEL
          </BtnLabel>
        </SdButton>
        <SdButton kind="white" onPress={onQuit} sound="sd_boardOut" faceStyle={styles.wideFace}>
          <BtnLabel kind="purple" size={16}>
            QUIT
          </BtnLabel>
        </SdButton>
      </View>
    </Overlay>
  );
}

const RULES = [
  ['1', 'Look!', 'The doors open for about 5 seconds. Remember which spot each squishy sits on.'],
  ['2', 'Shake!', 'The doors shut, it shakes and jumps, and everyone tumbles out.'],
  ['3', 'Sort!', 'Drag each squishy back to its spot, or tap it and then tap the spot.'],
  ['!', 'Careful', `${HEARTS} mistakes and it's over. No mistakes and a quick sort: 3 stars.`],
  ['?', 'Clutter', "Food and toys get knocked about by the shake. Don't use them to remember!"],
];
const TWISTS = [
  ['IMPOSTORS', 'Squishies in the tray that were never inside. Leave them out!'],
  ['SNEAKY SWAP', 'Two squishies trade places just before the doors shut. Keep watching!'],
  ['MIXED UP', 'The shake leaves some inside in the wrong spot. Move them to theirs.'],
];

export function RulesCard({ visible, onClose }) {
  return (
    <Overlay visible={visible}>
      <OutlinedTitle text="HOW TO PLAY" size={26} fill="pink" />
      <View style={styles.rules}>
        {RULES.map(([n, title, line]) => (
          <View key={title} style={styles.rule}>
            <View style={styles.ruleNum}>
              <Text style={styles.ruleNumText}>{n}</Text>
            </View>
            <View style={{ flex: 1 }}>
              <Text style={styles.ruleTitle}>{title}</Text>
              <Text style={styles.ruleLine}>{line}</Text>
            </View>
          </View>
        ))}
      </View>
      <Text style={styles.twistHead}>LATER LEVELS ADD TWISTS</Text>
      {TWISTS.map(([name, line]) => (
        <Text key={name} style={styles.twist}>
          <Text style={styles.twistName}>{`${name}  `}</Text>
          {line}
        </Text>
      ))}
      <Text style={styles.twist}>
        <Text style={[styles.twistName, { color: '#1f7a5a' }]}>{'BIGGER AND BIGGER  '}</Text>
        {'Seven sizes, from a mini fridge to a restaurant fridge (and a bedside cabinet to a giant wardrobe), each gaining shelves as you go.'}
      </Text>
      <Text style={styles.twist}>
        <Text style={[styles.twistName, { color: '#0c5a9c' }]}>{'BLITZ ⚡  '}</Text>
        {`${BLITZ_ROUNDS} rounds on one clock that runs while you sort. One mistake and it's back to round 1 (one revive per run).`}
      </Text>
      <SdButton kind="green" onPress={onClose} sound="sd_select" faceStyle={styles.bigFace} style={{ marginTop: 8 }}>
        <BtnLabel kind="green" size={18}>
          GOT IT!
        </BtnLabel>
      </SdButton>
    </Overlay>
  );
}

const styles = StyleSheet.create({
  sub: { fontFamily: F.display, fontSize: 12, letterSpacing: 0.6, color: '#8a5fc0', textAlign: 'center' },
  hint: { fontFamily: F.heavy, fontSize: 11.5, color: '#b86200', textAlign: 'center' },
  stars: { flexDirection: 'row', alignItems: 'center', justifyContent: 'center', marginTop: 4, marginBottom: 8 },
  rewardRow: { flexDirection: 'row', alignItems: 'center', gap: 6 },
  coins: { fontFamily: F.display, fontSize: 28, color: '#b86200', includeFontPadding: false, minWidth: 70 },
  unlocked: { fontFamily: F.display, fontSize: 13, color: '#16a86a', letterSpacing: 0.8 },
  btnRow: { flexDirection: 'row', alignItems: 'flex-start', justifyContent: 'center', gap: 8, marginTop: 6 },
  col: { alignSelf: 'stretch', gap: 4, marginTop: 6 },
  smallFace: { paddingHorizontal: 14, paddingVertical: 10 },
  bigFace: { paddingHorizontal: 22, paddingVertical: 12 },
  wideFace: { paddingVertical: 12 },
  body: { fontFamily: F.heavy, fontSize: 14, color: INK, textAlign: 'center', paddingHorizontal: 6 },
  rules: { alignSelf: 'stretch', gap: 8, marginTop: 4 },
  rule: { flexDirection: 'row', alignItems: 'center', gap: 10 },
  ruleNum: { width: 30, height: 30, borderRadius: 15, backgroundColor: '#ff5cc6', borderWidth: 2.5, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  ruleNumText: { fontFamily: F.display, fontSize: 15, color: '#ffffff', includeFontPadding: false },
  ruleTitle: { fontFamily: F.display, fontSize: 15, color: '#8e1580' },
  ruleLine: { fontFamily: F.heavy, fontSize: 12, lineHeight: 16, color: INK },
  twistHead: { marginTop: 6, fontFamily: F.display, fontSize: 12, letterSpacing: 1, color: '#8a5fc0' },
  twist: { alignSelf: 'stretch', fontFamily: F.heavy, fontSize: 11.5, lineHeight: 15.5, color: INK },
  twistName: { fontFamily: F.display, fontSize: 11.5, color: '#e01e4a' },
});
