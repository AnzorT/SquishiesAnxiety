import React, { useEffect, useRef, useState } from 'react';
import { Animated, Easing, StyleSheet, Text, View } from 'react-native';
import { LinearGradient } from 'expo-linear-gradient';
import OutlinedTitle from '../components/candy/OutlinedTitle';
import { RaysSpin } from '../components/candy/Decor';
import { CoinIcon } from '../squad/ui';
import sfx from '../audio/sfx';
import { CountUp, FxLayer, PopIn, Rock, SlideIn } from './fx';
import { BtnLabel, Head, SdButton } from './ui';
import { clock } from './levels';
import { F, INK } from './theme';

// The cards over the board: the result (score creatures popping in one by
// one, each with its own bigger sound; PERFECT's stamp; coins counting up;
// the XP bar; a Puzzle Level up), time's up, pause, and Blitz's mistake /
// back-to-level-1 / win cards.

// The dim scrim and a card springing up into the middle.
export function Overlay({ visible, children, tint = 'rgba(40,8,80,0.55)' }) {
  const t = useRef(new Animated.Value(0)).current;
  const [shown, setShown] = useState(visible);
  useEffect(() => {
    if (visible) {
      setShown(true);
      t.setValue(0);
      Animated.spring(t, { toValue: 1, friction: 6.5, tension: 90, useNativeDriver: true }).start();
    } else if (shown) {
      Animated.timing(t, { toValue: 0, duration: 180, easing: Easing.in(Easing.quad), useNativeDriver: true }).start(() => setShown(false));
    }
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [visible]);
  if (!shown) return null;
  return (
    <View style={styles.overlay} pointerEvents={visible ? 'auto' : 'none'}>
      <Animated.View style={[StyleSheet.absoluteFill, { backgroundColor: tint, opacity: t.interpolate({ inputRange: [0, 1], outputRange: [0, 1], extrapolate: 'clamp' }) }]} />
      <Animated.View
        style={[
          styles.card,
          {
            opacity: t.interpolate({ inputRange: [0, 0.3, 1], outputRange: [0, 1, 1], extrapolate: 'clamp' }),
            transform: [{ translateY: t.interpolate({ inputRange: [0, 1], outputRange: [120, 0] }) }, { scale: t.interpolate({ inputRange: [0, 1], outputRange: [0.7, 1] }) }],
          },
        ]}
      >
        <View style={styles.cardRim}>
          <LinearGradient colors={['#fff6fd', '#ffe3f6', '#efd8ff']} locations={[0, 0.55, 1]} style={styles.cardFill}>
            {children}
          </LinearGradient>
        </View>
      </Animated.View>
    </View>
  );
}

// One of the result's three score creatures: an earned one bursts in with
// rays and gold sparks; a missed one thuds in grey.
function Slot({ uri, earned, delay, big }) {
  const t = useRef(new Animated.Value(0)).current;
  const fx = useRef(null);
  const size = big ? 78 : 64;
  useEffect(() => {
    const timer = setTimeout(() => {
      if (earned) {
        fx.current?.burst('gold', size / 2 + 8, size / 2 + 8, 1);
      }
    }, delay + 60);
    Animated.spring(t, { toValue: 1, friction: earned ? 3.6 : 7, tension: earned ? 170 : 120, delay, useNativeDriver: true }).start();
    return () => clearTimeout(timer);
  }, [t, delay, earned, size]);
  const scale = t.interpolate({ inputRange: [0, 1], outputRange: [earned ? 0 : 1.6, 1] });
  const rotate = t.interpolate({ inputRange: [0, 1], outputRange: [earned ? '-30deg' : '0deg', '0deg'] });
  return (
    <View style={{ width: size + 16, height: size + 16, alignItems: 'center', justifyContent: 'center', marginTop: big ? -10 : 6 }}>
      <Head uri={uri} size={size} dim ring="rgba(255,255,255,0.7)" bg="rgba(200,180,230,0.35)" style={{ position: 'absolute' }} />
      {earned ? (
        <Animated.View pointerEvents="none" style={{ position: 'absolute', opacity: t }}>
          <RaysSpin size={size * 1.9} color="#ffe45c" opacity={0.6} />
        </Animated.View>
      ) : null}
      <Animated.View style={{ position: 'absolute', opacity: t.interpolate({ inputRange: [0, 0.2, 1], outputRange: [0, 1, 1] }), transform: [{ scale }, { rotate }] }}>
        {earned ? <Head uri={uri} size={size} ring="#ffd23a" bg="#fffbe6" /> : <Head uri={uri} size={size} dim ring="#cfc3dd" bg="#efe9f5" />}
      </Animated.View>
      <FxLayer ref={fx} />
    </View>
  );
}

// "PERFECT!" slamming down like a stamp.
function Stamp({ delay, text = 'PERFECT!' }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    Animated.timing(t, { toValue: 1, duration: 260, delay, easing: Easing.in(Easing.cubic), useNativeDriver: true }).start();
  }, [t, delay]);
  return (
    <Animated.View
      pointerEvents="none"
      style={[
        styles.stamp,
        {
          opacity: t.interpolate({ inputRange: [0, 0.3, 1], outputRange: [0, 1, 1] }),
          transform: [{ scale: t.interpolate({ inputRange: [0, 1], outputRange: [3.2, 1] }) }, { rotate: t.interpolate({ inputRange: [0, 1], outputRange: ['-30deg', '-9deg'] }) }],
        },
      ]}
    >
      <Text style={styles.stampText}>{text}</Text>
      <Text style={styles.stampSub}>NO ✕ · NO MISTAKES</Text>
    </Animated.View>
  );
}

// The Puzzle XP bar filling from before → after (rolling over on a level up).
function XpBar({ before, after, delay }) {
  const t = useRef(new Animated.Value(0)).current;
  const [lv, setLv] = useState(before.level);
  useEffect(() => {
    const ups = after.level - before.level;
    // the fill runs through each level up, then to where it lands
    const legs = [];
    let from = before.into / before.need;
    for (let i = 0; i < ups; i++) {
      legs.push([from, 1]);
      from = 0;
    }
    legs.push([from, after.into / after.need]);
    t.setValue(legs[0][0]);
    const timer = setTimeout(() => sfx.play('sd_xpFill'), delay);
    Animated.sequence(
      legs.map(([, to], i) =>
        Animated.sequence([
          ...(i > 0 ? [Animated.timing(t, { toValue: 0, duration: 1, useNativeDriver: false })] : []),
          Animated.timing(t, { toValue: to, duration: 650, delay: i === 0 ? delay : 0, easing: Easing.out(Easing.cubic), useNativeDriver: false }),
        ]),
      ),
    ).start();
    const lvTimers = [];
    for (let i = 1; i <= ups; i++) lvTimers.push(setTimeout(() => setLv(before.level + i), delay + i * 651));
    return () => {
      clearTimeout(timer);
      lvTimers.forEach(clearTimeout);
    };
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);
  return (
    <View style={styles.xpRow}>
      <View style={styles.lvBadge}>
        <Text style={styles.lvText}>{lv}</Text>
      </View>
      <View style={styles.xpTrack}>
        <Animated.View style={[styles.xpFill, { width: t.interpolate({ inputRange: [0, 1], outputRange: ['0%', '100%'] }) }]}>
          <LinearGradient colors={['#d9b8ff', '#9a4dff']} style={StyleSheet.absoluteFill} start={{ x: 0, y: 0 }} end={{ x: 1, y: 0 }} />
        </Animated.View>
      </View>
      <Text style={styles.xpLabel}>PUZZLE XP</Text>
    </View>
  );
}

// The result: `res` = { stars, perfect, ms, mistakes, levelCoins, coins, xp,
// levelUps, before, after, unlocked }, `spec` the level, `uris` the three
// score creatures.
export function ResultCard({ visible, res, spec, uris, onNext, onReplay, onMap, last }) {
  const [key, setKey] = useState(0);
  useEffect(() => {
    if (!visible || !res) return undefined;
    setKey((k) => k + 1);
    const timers = [];
    const at = (ms, fn) => timers.push(setTimeout(fn, ms));
    const STEP = 520;
    for (let i = 0; i < 3; i++) at(420 + i * STEP, () => sfx.play(i < res.stars ? `sd_star${i + 1}` : 'sd_starEmpty'));
    if (res.perfect) at(420 + 3 * STEP, () => sfx.play('sd_perfect'));
    if (res.levelUps && res.levelUps.length) at(coinsAt(res) + 900, () => sfx.play('sd_levelUp'));
    return () => timers.forEach(clearTimeout);
  }, [visible, res]);
  if (!res) return <Overlay visible={false} />;
  const STEP = 520;
  const cAt = coinsAt(res);
  const titles = res.perfect ? 'PERFECT SQUISH!' : res.stars === 3 ? 'SQUISHTASTIC!' : res.stars === 2 ? 'NICE ONE!' : 'SOLVED!';
  return (
    <Overlay visible={visible}>
      <PopIn trigger={key} delay={80}>
        <OutlinedTitle text={titles} size={res.perfect ? 26 : 30} fill={res.perfect ? 'gold' : 'pink'} />
      </PopIn>
      <Text style={styles.sub}>{`LEVEL ${spec.lv} · ${spec.n}×${spec.n} · ${clock(res.ms)}${res.mistakes ? ` · ${res.mistakes} MISTAKE${res.mistakes > 1 ? 'S' : ''}` : ''}${spec.head ? ' · HEAD START' : ''}`}</Text>
      <View key={key} style={styles.slots}>
        {[0, 1, 2].map((i) => (
          <Slot key={i} uri={uris[i]} earned={i < res.stars} delay={420 + i * STEP} big={i === 1} />
        ))}
        {res.perfect ? <Stamp delay={420 + 3 * STEP - 120} /> : null}
      </View>
      <SlideIn trigger={key} delay={cAt - 150} dy={20} style={styles.rewardRow}>
        <CoinIcon size={26} />
        <CountUp value={res.levelCoins} delay={cAt} ms={800} style={styles.coins} prefix="+" onTick={() => sfx.play('sd_coinTick')} />
        {res.perfect ? <Text style={styles.mult}>×3</Text> : null}
        <Text style={styles.xpPlus}>{`+${res.xp} XP`}</Text>
      </SlideIn>
      <SlideIn trigger={key} delay={cAt + 300} dy={16}>
        <XpBar key={key} before={res.before} after={res.after} delay={cAt + 500} />
      </SlideIn>
      {res.levelUps && res.levelUps.length ? (
        <PopIn trigger={key} delay={cAt + 900} style={styles.levelUp}>
          <Rock deg={3}>
            <Text style={styles.levelUpText}>{`PUZZLE LEVEL ${res.after.level}!`}</Text>
            <Text style={styles.levelUpSub}>{`+${res.levelUps.reduce((a, u) => a + u.coins, 0)} bonus coins`}</Text>
          </Rock>
        </PopIn>
      ) : null}
      {res.unlocked ? (
        <PopIn trigger={key} delay={cAt + 600}>
          <Text style={styles.unlocked}>{`LEVEL ${spec.lv + 1} UNLOCKED`}</Text>
        </PopIn>
      ) : null}
      <SlideIn trigger={key} delay={420 + 2 * STEP + 300} dy={30} style={styles.btnRow}>
        <SdButton kind="white" onPress={onMap} sound="sd_select" faceStyle={styles.smallFace}>
          <BtnLabel kind="purple" size={15}>MAP</BtnLabel>
        </SdButton>
        <SdButton kind="purple" onPress={onReplay} sound="sd_select" faceStyle={styles.smallFace}>
          <BtnLabel kind="purple" size={15}>REPLAY</BtnLabel>
        </SdButton>
        {!last ? (
          <SdButton kind="green" onPress={onNext} sound="sd_select" faceStyle={styles.bigFace}>
            <BtnLabel kind="green" size={18}>NEXT ▶</BtnLabel>
          </SdButton>
        ) : null}
      </SlideIn>
    </Overlay>
  );
}
const coinsAt = (res) => 420 + 3 * 520 + (res.perfect ? 600 : 100);

// Time's up: the timer-creature snoozing, RETRY or MAP.
export function TimeUpCard({ visible, onRetry, onMap, uri }) {
  return (
    <Overlay visible={visible} tint="rgba(80,0,30,0.5)">
      <PopIn trigger={visible} delay={60}>
        <OutlinedTitle text="TIME'S UP!" size={32} fill="pink" />
      </PopIn>
      <PopIn trigger={visible} delay={220}>
        <Rock deg={8} ms={1800}>
          <Head uri={uri} size={86} dim ring="#ffffff" bg="#efe9f5" />
        </Rock>
      </PopIn>
      <Text style={styles.body}>A fresh board is waiting. Same level, new puzzle!</Text>
      <SlideIn trigger={visible} delay={380} style={styles.btnRow}>
        <SdButton kind="white" onPress={onMap} sound="sd_select" faceStyle={styles.smallFace}>
          <BtnLabel kind="purple" size={15}>MAP</BtnLabel>
        </SdButton>
        <SdButton kind="pink" onPress={onRetry} sound="sd_select" faceStyle={styles.bigFace}>
          <BtnLabel kind="pink" size={18}>RETRY</BtnLabel>
        </SdButton>
      </SlideIn>
    </Overlay>
  );
}

export function PauseCard({ visible, onResume, onRestart, onQuit, blitz }) {
  return (
    <Overlay visible={visible}>
      <PopIn trigger={visible} delay={40}>
        <OutlinedTitle text="PAUSED" size={32} fill="pink" />
      </PopIn>
      <Text style={styles.body}>{blitz ? 'The Blitz clock is frozen. Take a breath!' : 'The clock is frozen. The board is hidden so no peeking!'}</Text>
      <View style={styles.col}>
        <SdButton kind="green" onPress={onResume} sound="sd_resume" faceStyle={styles.wideFace}>
          <BtnLabel kind="green" size={18}>RESUME</BtnLabel>
        </SdButton>
        <SdButton kind="purple" onPress={onRestart} sound="sd_select" faceStyle={styles.wideFace}>
          <BtnLabel kind="purple" size={16}>{blitz ? 'START OVER' : 'NEW BOARD'}</BtnLabel>
        </SdButton>
        <SdButton kind="white" onPress={onQuit} sound="sd_boardOut" faceStyle={styles.wideFace}>
          <BtnLabel kind="purple" size={16}>QUIT</BtnLabel>
        </SdButton>
      </View>
    </Overlay>
  );
}

// Blitz: a mistake with the revive still unused.
export function ReviveCard({ visible, board, adReady, adsFree, onRevive, onGiveUp }) {
  return (
    <Overlay visible={visible} tint="rgba(80,0,30,0.5)">
      <PopIn trigger={visible} delay={40}>
        <OutlinedTitle text="OOPS!" size={34} fill="pink" />
      </PopIn>
      <Text style={styles.body}>{`That's a mistake. Keep your run going on board ${board}?`}</Text>
      <Text style={styles.small}>One revive per run</Text>
      <View style={styles.col}>
        <SdButton kind="gold" onPress={onRevive} disabled={!adsFree && !adReady} sound="sd_select" faceStyle={styles.wideFace}>
          <BtnLabel kind="gold" size={17}>{adsFree ? 'REVIVE (FREE)' : adReady ? '▶ WATCH AD TO REVIVE' : 'LOADING AD…'}</BtnLabel>
        </SdButton>
        <SdButton kind="white" onPress={onGiveUp} sound="sd_select" faceStyle={styles.wideFace}>
          <BtnLabel kind="purple" size={15}>BACK TO LEVEL 1</BtnLabel>
        </SdButton>
      </View>
    </Overlay>
  );
}

// Blitz: the run is over (a mistake, or the clock).
export function BlitzFailCard({ visible, reason, reached, best, onAgain, onQuit }) {
  return (
    <Overlay visible={visible} tint="rgba(80,0,30,0.55)">
      <PopIn trigger={visible} delay={40} from={2.4} twist={-12} friction={6} tension={160}>
        <OutlinedTitle text="BACK TO LEVEL 1!" size={26} fill="pink" />
      </PopIn>
      <Text style={styles.body}>{reason === 'time' ? 'The Blitz clock ran out.' : 'One mistake sends the whole squad home.'}</Text>
      <Text style={styles.small}>{`You reached board ${reached} · best ${Math.max(best, reached)}`}</Text>
      <View style={styles.col}>
        <SdButton kind="cyan" onPress={onAgain} sound="sd_select" faceStyle={styles.wideFace}>
          <BtnLabel kind="cyan" size={18}>GO AGAIN</BtnLabel>
        </SdButton>
        <SdButton kind="white" onPress={onQuit} sound="sd_boardOut" faceStyle={styles.wideFace}>
          <BtnLabel kind="purple" size={15}>QUIT</BtnLabel>
        </SdButton>
      </View>
    </Overlay>
  );
}

export function BlitzWinCard({ visible, res, uris, onAgain, onQuit }) {
  const fx = useRef(null);
  useEffect(() => {
    if (!visible) return undefined;
    const timers = [0, 450, 900].map((ms, i) => setTimeout(() => fx.current?.burst('confetti', 60 + i * 80, 40, 1), ms));
    return () => timers.forEach(clearTimeout);
  }, [visible]);
  if (!res) return <Overlay visible={false} />;
  return (
    <Overlay visible={visible}>
      <PopIn trigger={visible} delay={60}>
        <OutlinedTitle text="BLITZ CHAMPION!" size={26} fill="gold" />
      </PopIn>
      <Text style={styles.sub}>{`10 BOARDS · ${clock(res.ms)}${res.newBest ? ' · NEW BEST!' : ''}`}</Text>
      <View style={styles.slots}>
        {[0, 1, 2].map((i) => (
          <Slot key={i} uri={uris[i]} earned delay={300 + i * 300} big={i === 1} />
        ))}
      </View>
      <SlideIn trigger={visible} delay={1300} dy={20} style={styles.rewardRow}>
        <CoinIcon size={26} />
        <CountUp value={res.coins} delay={1400} ms={1100} style={styles.coins} prefix="+" onTick={() => sfx.play('sd_coinTick')} ticks={14} />
        <Text style={styles.xpPlus}>{`+${res.xp} XP`}</Text>
      </SlideIn>
      <SlideIn trigger={visible} delay={1700} dy={30} style={styles.btnRow}>
        <SdButton kind="white" onPress={onQuit} sound="sd_boardOut" faceStyle={styles.smallFace}>
          <BtnLabel kind="purple" size={15}>DONE</BtnLabel>
        </SdButton>
        <SdButton kind="cyan" onPress={onAgain} sound="sd_select" faceStyle={styles.bigFace}>
          <BtnLabel kind="cyan" size={18}>AGAIN</BtnLabel>
        </SdButton>
      </SlideIn>
      <FxLayer ref={fx} />
    </Overlay>
  );
}


const styles = StyleSheet.create({
  overlay: { ...StyleSheet.absoluteFillObject, alignItems: 'center', justifyContent: 'center', padding: 18, zIndex: 50, elevation: 50 },
  card: { width: '100%', maxWidth: 380, borderRadius: 30, backgroundColor: '#45189a', padding: 3, paddingBottom: 8 },
  cardRim: { borderRadius: 27, backgroundColor: '#ffffff', padding: 3 },
  cardFill: { borderRadius: 24, paddingHorizontal: 16, paddingTop: 18, paddingBottom: 16, alignItems: 'center', gap: 8 },
  sub: { fontFamily: F.display, fontSize: 12.5, letterSpacing: 0.6, color: '#8a5fc0', textAlign: 'center' },
  slots: { flexDirection: 'row', alignItems: 'center', justifyContent: 'center', marginTop: 6, marginBottom: 22 },
  // across the creatures' feet, so they stay in view
  stamp: { position: 'absolute', bottom: -18, alignItems: 'center', borderWidth: 3.5, borderColor: '#e01e4a', borderRadius: 10, paddingHorizontal: 10, paddingVertical: 1, backgroundColor: 'rgba(255,255,255,0.92)' },
  stampText: { fontFamily: F.display, fontSize: 22, color: '#e01e4a', letterSpacing: 2, includeFontPadding: false },
  stampSub: { fontFamily: F.display, fontSize: 8.5, color: '#e01e4a', letterSpacing: 1, marginTop: -2 },
  rewardRow: { flexDirection: 'row', alignItems: 'center', gap: 6 },
  coins: { fontFamily: F.display, fontSize: 28, color: '#b86200', includeFontPadding: false, minWidth: 70 },
  mult: { fontFamily: F.display, fontSize: 16, color: '#e01e4a' },
  xpPlus: { fontFamily: F.display, fontSize: 16, color: '#7a2fd6', marginLeft: 8 },
  xpRow: { flexDirection: 'row', alignItems: 'center', gap: 8, width: 260 },
  lvBadge: { width: 30, height: 30, borderRadius: 15, backgroundColor: '#7a2fd6', borderWidth: 2.5, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  lvText: { fontFamily: F.display, fontSize: 14, color: '#ffffff', includeFontPadding: false },
  xpTrack: { flex: 1, height: 14, borderRadius: 999, backgroundColor: 'rgba(69,16,122,0.18)', borderWidth: 2, borderColor: '#ffffff', overflow: 'hidden' },
  xpFill: { height: '100%', borderRadius: 999, overflow: 'hidden' },
  xpLabel: { fontFamily: F.display, fontSize: 9.5, color: '#8a5fc0', width: 54 },
  levelUp: { alignItems: 'center', backgroundColor: '#7a2fd6', borderRadius: 16, paddingHorizontal: 14, paddingVertical: 5, borderWidth: 3, borderColor: '#ffffff' },
  levelUpText: { fontFamily: F.display, fontSize: 17, color: '#ffffff', textAlign: 'center' },
  levelUpSub: { fontFamily: F.heavy, fontSize: 11, color: '#f0dcff', textAlign: 'center' },
  unlocked: { fontFamily: F.display, fontSize: 13, color: '#16a86a', letterSpacing: 0.8 },
  btnRow: { flexDirection: 'row', alignItems: 'flex-start', justifyContent: 'center', gap: 8, marginTop: 6 },
  col: { alignSelf: 'stretch', gap: 4, marginTop: 6 },
  smallFace: { paddingHorizontal: 14, paddingVertical: 10 },
  bigFace: { paddingHorizontal: 22, paddingVertical: 12 },
  wideFace: { paddingVertical: 12 },
  body: { fontFamily: F.heavy, fontSize: 14, color: INK, textAlign: 'center', paddingHorizontal: 6 },
  small: { fontFamily: F.bold, fontSize: 12, color: '#8a5fc0', textAlign: 'center' },
});
