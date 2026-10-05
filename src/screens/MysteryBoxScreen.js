import React, { memo, useCallback, useEffect, useRef, useState } from 'react';
import { Animated, Easing, Pressable, ScrollView, StyleSheet, Text, View } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Defs, RadialGradient, Stop, Rect } from 'react-native-svg';
import { BUTTON_VARIANTS, TIERS, candyColors, candyFonts } from '../theme/candyTheme';
import CandyBackground from '../components/candy/CandyBackground';
import CandyButton, { ButtonText, Shine } from '../components/candy/CandyButton';
import RoundButton, { BackGlyph, BagIcon } from '../components/candy/RoundButton';
import CandyPopup from '../components/candy/CandyPopup';
import CreatureThumbnail from '../components/CreatureThumbnail';
import { boxSettings } from '../economy';
import OutlinedTitle from '../components/candy/OutlinedTitle';
import ShadowText from '../components/candy/ShadowText';
import ShineSweep from '../components/candy/ShineSweep';
import { CoinIcon, CoinPill } from '../components/candy/Coin';
import { SoftPulse } from '../components/candy/Decor';
import GiftBox from '../components/box/GiftBox';
import BoxReveal, { OUTLINE_8 } from '../components/box/BoxReveal';
import Toast from '../components/squad/Toast';
import AdStrip, { AD_H } from '../components/AdStrip';
import useRewardedAd from '../components/useRewardedAd';
import VideoBadge from '../components/candy/VideoBadge';
import { BOX_TAPS, MAX_DOUBLES, SECRET, boxDailyUsed, boxPayMode, boxPrice, boxRoster, canDouble, dailyBoxes, doublesLeft, ownedCount, pullIsPlayable, rollBox, untilNewBoxes } from '../mysteryBox';
import TutTarget from '../tutorial/Target';
import { report } from '../tutorial/store';
import sfx from '../audio/sfx';

// The v3 Mystery Box. Every day the first two boxes cost a video each (free
// with Remove Ads); after that a box costs 500 coins, paid with the OPEN
// button — the only thing that spends coins here. The day's boxes show as
// two chips (a blue ✓ once used), and a countdown says when they're back.
// Then tap the box 10 times fast — each tap must land within 0.4 s of the
// last, or the taps drain away and you start over — and it bursts open to
// give a bundle of one creature's own tokens (a full set puts its key on its
// Home card). The row at the top shows each rarity's chance, and a SECRET
// chip that explains the secret creature. Rules live in src/mysteryBox.js
// and src/economy.js.
// Payments are saved as they happen (payBoxWithAd / payBoxWithCoins in
// firebase/firestore.js); App's onOpen (openBox) hands out the pull in one
// write when the box bursts. None of them waits on the network: the writes
// land in Firestore's local cache.
// Like Home and the squish screen, the ad strip runs along the bottom until
// Remove Ads is bought.

const TAP_WINDOW_MS = 400;
const OPEN_MS = 650;

// ---- rarity chances + the secret -------------------------------------------

const TIER_ORDER = ['Common', 'Rare', 'Epic', 'Legendary', 'Rainbow', 'Golden'];

// "COMMON 50%": the chance a box's tokens are for a creature of that rarity
// (config/mysteryBox, see src/economy.js).
function OddsChip({ tier, pct }) {
  const t = TIERS[tier];
  return (
    <View style={styles.oddsRing}>
      <View style={styles.oddsRim}>
        <LinearGradient colors={t.bg} start={{ x: 0, y: 0 }} end={{ x: 1, y: tier === 'Rainbow' ? 0 : 1 }} style={styles.oddsFace}>
          <Text style={[styles.oddsLabel, { color: t.color }]}>{t.label}</Text>
          <Text style={[styles.oddsPct, { color: t.color }]}>{`${pct}%`}</Text>
        </LinearGradient>
      </View>
    </View>
  );
}

// The last chip: the secret creature, "SECRET ???" until it's found.
function SecretChip({ found, onPress }) {
  const t = TIERS.Secret;
  return (
    <Pressable onPress={onPress} hitSlop={6}>
      <SoftPulse active={!found} to={1.06} halfMs={700}>
        <View style={styles.oddsRing}>
          <View style={styles.oddsRim}>
            <LinearGradient colors={t.bg} start={{ x: 0, y: 0 }} end={{ x: 1, y: 1 }} style={styles.oddsFace}>
              <Text style={[styles.oddsLabel, { color: t.color }]}>SECRET</Text>
              <Text style={[styles.oddsPct, { color: t.color }]}>{found ? '✓' : '???'}</Text>
            </LinearGradient>
          </View>
        </View>
      </SoftPulse>
    </Pressable>
  );
}

const OddsRow = memo(function OddsRow({ secretFound, onSecret }) {
  const odds = boxSettings().rarityOdds;
  return (
    <View>
      <ScrollView horizontal showsHorizontalScrollIndicator={false} contentContainerStyle={styles.odds}>
        {TIER_ORDER.filter((tier) => odds[tier] > 0).map((tier) => (
          <OddsChip key={tier} tier={tier} pct={odds[tier]} />
        ))}
        <SecretChip found={secretFound} onPress={onSecret} />
      </ScrollView>
    </View>
  );
});

// What the SECRET chip opens: a hidden creature, and how to find it.
function SecretPopup({ visible, found, owned, total, secretCreature, onClose }) {
  return (
    <CandyPopup visible={visible} onClose={onClose} maxWidth={320}>
      <View style={styles.secretArt}>
        {secretCreature ? <CreatureThumbnail creature={secretCreature} size={110} locked={!found} wash={found ? 'holo' : null} mood={found ? 'celebrate' : 'sleep'} /> : null}
        {found ? null : (
          <View style={styles.secretMark} pointerEvents="none">
            <OutlinedTitle text="?" fill="gold" size={54} />
          </View>
        )}
      </View>
      <OutlinedTitle text={found ? 'PRISM GLORP' : 'SECRET CREATURE'} fill="pink" size={24} />
      <Text style={styles.secretText}>
        {found
          ? 'You found the secret rainbow Glorp! It lives with your creatures now.'
          : `A secret rainbow creature is hiding in the Mystery Box. Unlock all ${total} creatures, and your next box reveals it!`}
      </Text>
      {found ? null : <Text style={styles.secretCount}>{`YOU HAVE ${owned}/${total}`}</Text>}
      <CandyButton label="GOT IT" variant="blue" size="md" onPress={onClose} style={styles.secretOk} />
    </CandyPopup>
  );
}

// ---- the 10 progress dots and the 0.4 s timer --------------------------------

const TapDot = memo(function TapDot({ filled, drainDelay }) {
  const pop = useRef(new Animated.Value(1)).current;
  const drain = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    if (!filled) return;
    pop.setValue(0);
    Animated.timing(pop, {
      toValue: 1,
      duration: 300,
      easing: Easing.bezier(0, 0, 0.58, 1),
      useNativeDriver: true,
    }).start();
  }, [filled, pop]);
  useEffect(() => {
    if (drainDelay == null) {
      drain.setValue(0);
      return undefined;
    }
    drain.setValue(0);
    const a = Animated.sequence([
      Animated.delay(drainDelay),
      Animated.timing(drain, {
        toValue: 1,
        duration: 450,
        easing: Easing.bezier(0.42, 0, 1, 1),
        useNativeDriver: true,
      }),
    ]);
    a.start();
    return () => a.stop();
  }, [drainDelay, drain]);
  const draining = drainDelay != null;
  const popScale = pop.interpolate({
    inputRange: [0, 0.6, 1],
    outputRange: [0.4, 1.35, 1],
  });
  const drainScale = drain.interpolate({
    inputRange: [0, 0.4, 1],
    outputRange: [1, 1.3, 1],
  });
  const drainY = drain.interpolate({
    inputRange: [0, 0.4, 1],
    outputRange: [0, -4, 0],
  });
  const pinkOpacity = drain.interpolate({
    inputRange: [0, 0.4, 1],
    outputRange: [1, 1, 0],
  });
  const lit = filled || draining;
  return (
    <Animated.View
      style={[
        styles.dotRing,
        lit && styles.dotGlow,
        {
          transform: draining ? [{ translateY: drainY }, { scale: drainScale }] : [{ scale: filled ? popScale : 1 }],
        },
      ]}
    >
      <View style={styles.dotRim}>
        <View style={styles.dotEmpty} />
        {lit ? (
          <Animated.View style={[StyleSheet.absoluteFill, { opacity: draining ? pinkOpacity : 1 }]}>
            <LinearGradient colors={['#ffa8e6', '#ff4fbf']} style={StyleSheet.absoluteFill} />
          </Animated.View>
        ) : null}
      </View>
    </Animated.View>
  );
});

function TimerBar({ running, tapKey }) {
  const t = useRef(new Animated.Value(1)).current;
  const vis = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    Animated.timing(vis, {
      toValue: running ? 1 : 0,
      duration: 200,
      useNativeDriver: true,
    }).start();
    if (!running) return undefined;
    t.setValue(1);
    const a = Animated.timing(t, {
      toValue: 0,
      duration: TAP_WINDOW_MS,
      easing: Easing.linear,
      useNativeDriver: true,
    });
    a.start();
    return () => a.stop();
  }, [running, tapKey, t, vis]);
  // scaleX from the left edge: shift by half the lost width
  const translateX = t.interpolate({
    inputRange: [0, 1],
    outputRange: [-73, 0],
  });
  return (
    <Animated.View style={[styles.timerRing, { opacity: vis }]}>
      <View style={styles.timerTrack}>
        <Animated.View style={[StyleSheet.absoluteFill, { transform: [{ translateX }, { scaleX: t }] }]}>
          <LinearGradient colors={['#fff3a0', '#ff4fbf']} start={{ x: 0, y: 0 }} end={{ x: 1, y: 0 }} style={StyleSheet.absoluteFill} />
        </Animated.View>
      </View>
    </Animated.View>
  );
}

function HintPill({ text, shakeKey, warn }) {
  const t = useRef(new Animated.Value(1)).current;
  useEffect(() => {
    if (!warn) return;
    t.setValue(0);
    Animated.timing(t, {
      toValue: 1,
      duration: 400,
      easing: Easing.bezier(0, 0, 0.58, 1),
      useNativeDriver: true,
    }).start();
  }, [warn, shakeKey, t]);
  const translateX = t.interpolate({
    inputRange: [0, 0.25, 0.75, 1],
    outputRange: [0, -6, 6, 0],
  });
  return (
    <Animated.View style={[styles.hint, { transform: [{ translateX }] }]}>
      <ShadowText style={[styles.hintText, warn && { color: '#fff3a0' }]} shadows={OUTLINE_8('#45107a', 2, 4)}>
        {text}
      </ShadowText>
    </Animated.View>
  );
}

// ---- the white flash when the box bursts -----------------------------------

function Flash({ color }) {
  const t = useRef(new Animated.Value(0)).current;
  const [size, setSize] = useState(null);
  useEffect(() => {
    Animated.timing(t, {
      toValue: 1,
      duration: 900,
      easing: Easing.bezier(0, 0, 0.58, 1),
      useNativeDriver: true,
    }).start();
  }, [t]);
  const opacity = t.interpolate({
    inputRange: [0, 0.12, 1],
    outputRange: [0, 1, 0],
  });
  return (
    <Animated.View pointerEvents="none" style={[StyleSheet.absoluteFill, styles.flash, { opacity }]} onLayout={(e) => setSize(e.nativeEvent.layout)}>
      {size ? (
        <Svg width={size.width} height={size.height}>
          <Defs>
            <RadialGradient
              id="boxFlash"
              cx={size.width / 2}
              cy={size.height * 0.45}
              r={Math.hypot(size.width / 2, size.height * 0.55)}
              gradientUnits="userSpaceOnUse"
            >
              <Stop offset="0" stopColor="#ffffff" />
              <Stop offset="0.35" stopColor="#ffffff" />
              <Stop offset="1" stopColor={color} />
            </RadialGradient>
          </Defs>
          <Rect x="0" y="0" width={size.width} height={size.height} fill="url(#boxFlash)" />
        </Svg>
      ) : null}
    </Animated.View>
  );
}

// ---- today's boxes -----------------------------------------------------

function StepChip({ free, state }) {
  const done = state === 'done';
  const face = done ? BUTTON_VARIANTS.blue : BUTTON_VARIANTS.gold;
  return (
    <SoftPulse active={state === 'now'} to={1.1} halfMs={600} style={state === 'next' ? styles.stepNext : null}>
      <View style={[styles.stepLip, { backgroundColor: face.ring }]}>
        <View style={[styles.stepRing, { backgroundColor: face.ring }]}>
          <View style={styles.stepRim}>
            <LinearGradient colors={face.colors} locations={face.locations} style={styles.stepFace}>
              <Shine />
              {done || free ? (
                <ButtonText ring={face.ring} size={15}>
                  {done ? '✓' : '★'}
                </ButtonText>
              ) : (
                <View style={styles.stepPlay} />
              )}
            </LinearGradient>
          </View>
        </View>
      </View>
    </SoftPulse>
  );
}

// One chip per daily box: a blue ✓ once used, gold ▶ (★ with Remove Ads)
// while still to come, the next one breathing.
const DailyChips = memo(function DailyChips({ used, free, count }) {
  return (
    <View style={styles.steps}>
      {Array.from({ length: count }, (_, i) => (
        <View key={i} style={styles.stepSlot}>
          {i > 0 ? <View style={styles.stepLink} /> : null}
          <StepChip free={free} state={i < used ? 'done' : i === used ? 'now' : 'next'} />
        </View>
      ))}
    </View>
  );
});

// ---- screen --------------------------------------------------------------

export default function MysteryBoxScreen({ profile, creatures = [], onBack, onOpen, onDouble, onVideoBoxWatched, onPayCoins, onSquish, onOpenShop, onUnlockIt }) {
  const insets = useSafeAreaInsets();
  const ad = useRewardedAd();

  const [phase, setPhase] = useState('closed'); // 'closed' | 'opening' | 'reveal'
  const [taps, setTaps] = useState(0);
  const [shakeKey, setShakeKey] = useState(0);
  const [drain, setDrain] = useState(null); // { from } while the taps run out
  const [drainKey, setDrainKey] = useState(0);
  // The pull for the box on screen, rolled ahead of time so the reveal can
  // be built (hidden) before the box bursts. Nothing is visible until then.
  const [pull, setPull] = useState(null);
  const [rollKey, setRollKey] = useState(0);
  const [toast, setToast] = useState(null);
  const [toastKey, setToastKey] = useState(0);
  const [flashKey, setFlashKey] = useState(0);
  // A payment made a moment ago that the profile may not show yet: the box
  // is paid for (a video box, or the coins) and waits to be tapped open.
  const [paidAhead, setPaidAhead] = useState(false);
  const [secretOpen, setSecretOpen] = useState(false);

  const tapsRef = useRef(0);
  const decayRef = useRef(null);
  const drainTimerRef = useRef(null);
  const busyRef = useRef(false);
  const mounted = useRef(true);
  useEffect(() => {
    mounted.current = true;
    sfx.preload(['boxThump', 'boxBell', 'spend', 'fail', 'boxOpen', 'jackpot', 'coinShower']);
    return () => {
      mounted.current = false;
      clearTimeout(decayRef.current);
      clearTimeout(drainTimerRef.current);
    };
  }, []);

  // the profile has caught up with what was paid here
  const boxPending = !!profile?.boxPending;
  useEffect(() => {
    if (boxPending) setPaidAhead(false);
  }, [boxPending]);

  const payMode = paidAhead ? 'paid' : boxPayMode(profile);
  const adsFree = !!profile?.adsFree;
  // the tutorial follows the box (src/tutorial/steps.js)
  useEffect(() => {
    report({ boxPhase: phase, boxPaid: payMode === 'paid' || payMode === 'free' });
  }, [phase, payMode]);
  useEffect(() => () => report({ boxPhase: 'closed', boxPaid: false }), []);
  const dailyUsed = boxDailyUsed(profile);
  // Once today's boxes are used: tick the "back in 5h 12m" countdown (the
  // re-render also notices when the new day arrives).
  const [clock, setClock] = useState(() => new Date());
  useEffect(() => {
    if (payMode !== 'coins') return undefined;
    setClock(new Date());
    const id = setInterval(() => setClock(new Date()), 30000);
    return () => clearInterval(id);
  }, [payMode]);
  const coins = profile?.coins ?? 0;
  // the box's prices (config/mysteryBox); App re-renders when they change
  const price = boxPrice();
  const daily = dailyBoxes();
  const canAfford = coins >= price;
  const roster = boxRoster(creatures);
  const total = roster.length || 20;
  const owned = ownedCount(creatures, profile?.ownedIds ?? []);
  const secretFound = !!profile?.secretFound;
  const firstBox = (profile?.boxOpens ?? 0) === 0;
  // everything the next pull depends on
  const rollState = [
    (profile?.ownedIds ?? []).join(','),
    JSON.stringify(profile?.stickers ?? {}),
    JSON.stringify(profile?.keys ?? {}),
    secretFound,
    firstBox,
  ].join('|');

  // Roll the next box whenever a fresh one is on screen (not mid-tap).
  useEffect(() => {
    if (phase !== 'closed' || tapsRef.current > 0) return;
    setPull(rollBox(creatures, profile));
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [phase, creatures, rollState, rollKey]);

  const showToast = useCallback((msg) => {
    setToast(msg);
    setToastKey((k) => k + 1);
    setTimeout(() => mounted.current && setToast((cur) => (cur === msg ? null : cur)), 2200);
  }, []);

  const resetTaps = useCallback(() => {
    clearTimeout(decayRef.current);
    clearTimeout(drainTimerRef.current);
    tapsRef.current = 0;
    setTaps(0);
    setDrain(null);
  }, []);

  const needCoins = useCallback(() => {
    sfx.play('bonk');
    showToast(`You need ${price} coins for a box — squish to earn more`);
  }, [showToast]);

  // A daily box: one video pays for it.
  const watchVideoBox = useCallback(() => {
    const shown = ad.show(() => {
      onVideoBoxWatched(); // saves the paid box right away
      setPaidAhead(true);
    });
    if (!shown) showToast('The video is still loading — try again in a moment');
  }, [ad, onVideoBoxWatched, showToast]);

  // Today's boxes are used up: charge the coins. The box is then paid for
  // and saved.
  const payCoins = useCallback(() => {
    if (!canAfford) {
      needCoins();
      return;
    }
    if (!onPayCoins()) {
      showToast("Couldn't pay for the box — try again");
      return;
    }
    sfx.play('spend');
    setPaidAhead(true);
  }, [canAfford, onPayCoins, needCoins, showToast]);

  const open = useCallback(() => {
    if (!pull) {
      resetTaps();
      showToast("Couldn't open the box — try again");
      return;
    }
    busyRef.current = true;
    setPhase('opening');
    setFlashKey((k) => k + 1);
    sfx.play('boxOpen');
    const opened = pull;
    const ahead = paidAhead;
    setTimeout(() => {
      busyRef.current = false;
      if (!mounted.current) return;
      setPhase('reveal');
      sfx.play('jackpot');
      if (opened.kind === 'owned') sfx.play('coinShower', { delay: 300 });
      // Save it once the reveal is on screen, so the app re-rendering for
      // the new coins/creature doesn't hold the reveal up.
      setTimeout(() => {
        onOpen(opened, ahead);
        if (mounted.current) setPaidAhead(false);
      }, 80);
    }, OPEN_MS);
  }, [pull, paidAhead, onOpen, resetTaps, showToast]);

  const tapBox = useCallback(() => {
    if (phase !== 'closed' || drain || busyRef.current) return;
    if (tapsRef.current === 0) {
      // Not paid for yet: tapping the box plays its video — coins are only
      // ever spent with the OPEN button.
      if (payMode === 'ad') {
        watchVideoBox();
        return;
      }
      if (payMode === 'coins') {
        if (!canAfford) needCoins();
        else showToast(`Tap OPEN to pay ${price} coins`);
        return;
      }
    }
    const next = tapsRef.current + 1;
    tapsRef.current = next;
    setTaps(next);
    // the design's boxTap: the thump rises 15 Hz a tap, the bell climbs a scale
    sfx.play('boxThump', { rate: (150 + next * 15) / 165 });
    sfx.play('boxBell', { rate: Math.pow(2, [0, 2, 4, 7, 9, 12, 14, 16, 19, 24][Math.min(9, next - 1)] / 12) });
    setShakeKey((k) => k + 1);
    clearTimeout(decayRef.current);
    if (next >= BOX_TAPS) {
      open();
      return;
    }
    // Too slow: the dots drain one by one and the count starts over.
    decayRef.current = setTimeout(() => {
      const from = tapsRef.current;
      if (!from || from >= BOX_TAPS) return;
      setDrain({ from });
      sfx.play('fail');
      setDrainKey((k) => k + 1);
      drainTimerRef.current = setTimeout(
        () => {
          tapsRef.current = 0;
          setTaps(0);
          setDrain(null);
        },
        150 + from * 45 + 350
      );
    }, TAP_WINDOW_MS);
  }, [phase, drain, payMode, canAfford, watchVideoBox, needCoins, showToast, open]);

  const openAnother = useCallback(() => {
    setPhase('closed');
    resetTaps();
    setRollKey((k) => k + 1);
    if (boxPayMode(profile) === 'ad') watchVideoBox();
  }, [profile, resetTaps, watchVideoBox]);

  // DOUBLE IT: a video (none with Remove Ads) for the same prize again,
  // MAX_DOUBLES a day (src/mysteryBox.js)
  const doubles = doublesLeft(profile);
  const showDouble = phase === 'reveal' && canDouble(pull) && doubles > 0 && !!onDouble;
  const double = useCallback(() => {
    const go = () => {
      const doubled = onDouble(pull);
      if (!doubled || !mounted.current) return;
      setPull(doubled);
      sfx.play('jackpot');
      if (doubled.kind === 'coins') sfx.play('coinShower', { delay: 200 });
      showToast(doubled.kind === 'coins' ? `Doubled! +${doubled.amount} coins` : `Doubled! +${doubled.amount} ${doubled.name} tokens`);
    };
    if (adsFree) go();
    else if (!ad.show(go)) showToast('The video is still loading — try again in a moment');
  }, [adsFree, ad, onDouble, pull, showToast]);

  const squish = useCallback(() => {
    if (!pull) return;
    onSquish(pull.kind === 'secret' ? SECRET.id : pull.id);
  }, [pull, onSquish]);
  // tokens came out: its Key Shop row, or — the set just filled — its card
  const openSecret = useCallback(() => setSecretOpen(true), []);
  const closeSecret = useCallback(() => setSecretOpen(false), []);
  const openShop = useCallback(() => onOpenShop(pull && pull.kind === 'tokens' ? pull.id : null), [pull, onOpenShop]);
  const unlockIt = useCallback(() => pull && onUnlockIt(pull.id), [pull, onUnlockIt]);

  // --- labels ---
  const unpaid = phase === 'closed' && taps === 0 && (payMode === 'ad' || payMode === 'coins');
  const hint = drain
    ? 'Too slow! Tap faster'
    : taps > 0 && taps < BOX_TAPS
      ? `Keep tapping! ${taps}/${BOX_TAPS}`
      : taps >= BOX_TAPS
        ? 'One more…'
        : payMode === 'free'
          ? `Free box ${dailyUsed + 1}/${daily} today · tap it!`
          : 'Tap the box to open!';
  const payHint =
    payMode === 'ad'
      ? `Box ${dailyUsed + 1}/${daily} today · watch a video`
      : `New ${adsFree ? 'free' : 'video'} boxes in ${untilNewBoxes(clock)}`;
  const revealCreature = pull && pull.kind !== 'coins' ? creatures.find((c) => c.id === (pull.kind === 'secret' ? SECRET.id : pull.id)) : null;
  const glow = (pull && TIERS[pull.tier]?.glow) || '#ff9fd6';
  const nextMode = boxPayMode(profile);

  let payButton = null;
  if (payMode === 'ad') {
    payButton = (
      <CandyButton variant="gold" size="md" pulse="soft" onPress={watchVideoBox} faceStyle={styles.watchFace}>
        <ShineSweep />
        <View style={styles.watchRow}>
          <VideoBadge />
          <ButtonText ring={BUTTON_VARIANTS.gold.ring} size={17} style={styles.watchLabel}>
            WATCH TO OPEN
          </ButtonText>
        </View>
      </CandyButton>
    );
  } else if (payMode === 'coins' && !canAfford) {
    payButton = (
      <CandyButton variant="grey" size="md" dim onPress={needCoins} faceStyle={styles.payFace}>
        <View style={styles.watchRow}>
          <CoinIcon size={16} />
          <ButtonText ring={BUTTON_VARIANTS.grey.ring} size={16} style={styles.watchLabel}>
            {`${(price - coins).toLocaleString()} MORE COINS`}
          </ButtonText>
        </View>
      </CandyButton>
    );
  } else if (payMode === 'coins') {
    payButton = (
      <CandyButton variant="pink" size="md" pulse="soft" onPress={payCoins} faceStyle={styles.payFace}>
        <ShineSweep />
        <View style={styles.watchRow}>
          <ButtonText ring={BUTTON_VARIANTS.pink.ring} size={18} style={styles.watchLabel}>
            OPEN
          </ButtonText>
          <View style={styles.payDivider} />
          <CoinIcon size={16} />
          <ButtonText ring={BUTTON_VARIANTS.pink.ring} size={18}>
            {String(price)}
          </ButtonText>
        </View>
      </CandyButton>
    );
  }

  return (
    <CandyBackground sparkles style={styles.container}>
      <View style={[styles.header, { paddingTop: insets.top + 16 }]}>
        <TutTarget name="boxBack">
          <RoundButton size={38} onPress={onBack}>
            <BackGlyph />
          </RoundButton>
        </TutTarget>
        <OutlinedTitle text="MYSTERY BOX" fill="pink" size={24} />
        <CoinPill coins={coins} style={styles.coins} />
      </View>

      <OddsRow secretFound={secretFound} onSecret={openSecret} />

      <View style={styles.stage}>
        {pull ? (
          <BoxReveal pull={pull} creature={revealCreature} glow={glow} shown={phase === 'reveal'} />
        ) : null}
        <View style={[styles.closed, phase === 'reveal' && styles.hidden]} pointerEvents={phase === 'closed' ? 'auto' : 'none'}>
          <TutTarget name="boxTap">
            <GiftBox taps={taps} phase={phase === 'closed' ? 'closed' : 'opening'} draining={!!drain} shakeKey={shakeKey} drainKey={drainKey} onPress={tapBox} />
          </TutTarget>
          {unpaid ? (
            <View style={styles.controls}>
              <HintPill text={payHint} />
              <DailyChips used={dailyUsed} free={adsFree} count={daily} />
              <TutTarget name="boxPay">{payButton}</TutTarget>
            </View>
          ) : (
            <View style={styles.controls}>
              <HintPill key={drain ? `d${drainKey}` : 'n'} text={hint} warn={!!drain} shakeKey={drainKey} />
              <View style={styles.dots}>
                {Array.from({ length: BOX_TAPS }, (_, i) => (
                  <TapDot
                    key={drain && i < drain.from ? `d${drainKey}-${i}` : `${i < taps ? 'f' : 'e'}${i}`}
                    filled={!drain && i < taps}
                    drainDelay={drain && i < drain.from ? (drain.from - 1 - i) * 45 : null}
                  />
                ))}
              </View>
              <TimerBar running={taps > 0 && taps < BOX_TAPS && !drain && phase === 'closed'} tapKey={shakeKey} />
            </View>
          )}
        </View>
      </View>

      <View style={[styles.bottom, { paddingBottom: adsFree ? 22 + insets.bottom : 14 }]}>
        <View style={styles.collectionRow}>
          <ShadowText style={styles.collectionText} shadows={OUTLINE_8('#45107a')}>
            COLLECTION
          </ShadowText>
          <ShadowText style={styles.collectionText} shadows={OUTLINE_8('#45107a')}>
            {`${owned}/${total} · SECRET ${secretFound ? '✓' : '?'}`}
          </ShadowText>
        </View>
        <View style={styles.collectionRing}>
          <View style={styles.collectionTrack}>
            <View
              style={{
                width: `${Math.round((owned / total) * 100)}%`,
                height: '100%',
              }}
            >
              <LinearGradient colors={['#ff9fd6', '#c89bff', '#7cc8ff']} start={{ x: 0, y: 0 }} end={{ x: 1, y: 0 }} style={StyleSheet.absoluteFill} />
            </View>
          </View>
        </View>
        {showDouble ? (
          <View style={styles.doubleRow}>
            <CandyButton variant="gold" pulse="soft" onPress={double} style={styles.flex} faceStyle={styles.revealFace}>
              <ShineSweep />
              <View style={styles.watchRow}>
                {adsFree ? null : <VideoBadge w={26} h={18} />}
                <ButtonText ring={BUTTON_VARIANTS.gold.ring} size={15}>
                  DOUBLE IT ×2
                </ButtonText>
              </View>
            </CandyButton>
            <ShadowText style={styles.doubleNote} shadows={OUTLINE_8('#45107a', 1.2, 2.5)}>
              {`${doubles}/${MAX_DOUBLES}
TODAY`}
            </ShadowText>
          </View>
        ) : null}
        {phase === 'reveal' ? (
          <View style={styles.revealButtons}>
            {pullIsPlayable(pull) ? (
              <CandyButton variant="blue" label="SQUISH IT" onPress={squish} style={styles.flex} faceStyle={styles.revealFace} textStyle={styles.revealLabel} />
            ) : pull && pull.complete ? (
              <TutTarget name="revealUnlock" style={styles.flex}>
                <CandyButton variant="gold" label="UNLOCK IT" pulse="soft" onPress={unlockIt} style={styles.flex} faceStyle={styles.revealFace} textStyle={styles.revealLabel} />
              </TutTarget>
            ) : (
              <CandyButton variant="blue" onPress={openShop} style={styles.flex} faceStyle={styles.revealFace}>
                <View style={styles.watchRow}>
                  <BagIcon size={20} />
                  <ButtonText ring={BUTTON_VARIANTS.blue.ring} size={14}>
                    SHOP
                  </ButtonText>
                </View>
              </CandyButton>
            )}
            <CandyButton variant="pink" onPress={openAnother} style={styles.flex} faceStyle={styles.revealFace}>
              <View style={styles.watchRow}>
                <ButtonText ring={BUTTON_VARIANTS.pink.ring} size={14}>
                  OPEN ANOTHER
                </ButtonText>
                {nextMode === 'ad' ? <VideoBadge w={26} h={18} /> : null}
              </View>
            </CandyButton>
          </View>
        ) : null}
      </View>

      {phase !== 'closed' ? <Flash key={flashKey} color={glow} /> : null}
      <SecretPopup
        visible={secretOpen}
        found={secretFound}
        owned={owned}
        total={total}
        secretCreature={creatures.find((c) => c.id === SECRET.id)}
        onClose={closeSecret}
      />
      {adsFree ? null : <AdStrip />}
      {/* above the ad strip */}
      <View pointerEvents="none" style={[styles.toastAt, { bottom: adsFree ? 0 : AD_H + insets.bottom }]}>
        <Toast message={toast} messageKey={toastKey} />
      </View>
    </CandyBackground>
  );
}

const styles = StyleSheet.create({
  container: { flex: 1 },
  flex: { flex: 1 },
  header: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: 12,
    paddingHorizontal: 16,
    paddingBottom: 12,
  },
  coins: { marginLeft: 'auto' },
  oddsRing: { borderRadius: 999, backgroundColor: '#a23ad8', padding: 1.5 },
  oddsRim: { borderRadius: 999, backgroundColor: '#ffffff', padding: 2 },
  oddsFace: {
    flexDirection: 'row',
    alignItems: 'center',
    gap: 5,
    borderRadius: 999,
    paddingVertical: 3,
    paddingHorizontal: 9,
  },
  oddsLabel: {
    fontFamily: candyFonts.display,
    fontSize: 11,
    letterSpacing: 0.6,
    includeFontPadding: false,
  },
  oddsPct: {
    fontFamily: candyFonts.displaySemi,
    fontSize: 11,
    includeFontPadding: false,
  },
  stage: { flex: 1, minHeight: 0, overflow: 'hidden' },
  closed: {
    flex: 1,
    alignItems: 'center',
    justifyContent: 'center',
    gap: 10,
    paddingVertical: 6,
  },
  hidden: { opacity: 0 },
  controls: { alignItems: 'center', gap: 8 },
  watchFace: { paddingVertical: 9, paddingLeft: 12, paddingRight: 20 },
  payFace: { paddingVertical: 9, paddingHorizontal: 22 },
  watchRow: { flexDirection: 'row', alignItems: 'center', gap: 10 },
  watchLabel: { letterSpacing: 0.6 },
  hint: {
    borderRadius: 999,
    backgroundColor: 'rgba(60,8,110,0.4)',
    borderWidth: 2,
    borderColor: 'rgba(255,255,255,0.6)',
    paddingVertical: 6,
    paddingHorizontal: 16,
  },
  hintText: {
    color: '#ffffff',
    fontFamily: candyFonts.display,
    fontSize: 21,
    letterSpacing: 0.4,
    includeFontPadding: false,
  },
  dots: { flexDirection: 'row', gap: 6 },
  dotRing: {
    width: 16,
    height: 16,
    borderRadius: 8,
    backgroundColor: '#8e1580',
    padding: 1.5,
  },
  dotGlow: {
    shadowColor: '#ff78d2',
    shadowOpacity: 0.9,
    shadowRadius: 8,
    shadowOffset: { width: 0, height: 0 },
  },
  dotRim: {
    flex: 1,
    borderRadius: 7,
    borderWidth: 2.5,
    borderColor: '#ffffff',
    overflow: 'hidden',
  },
  dotEmpty: {
    ...StyleSheet.absoluteFillObject,
    backgroundColor: 'rgba(255,255,255,0.35)',
  },
  timerRing: {
    width: 153,
    height: 11,
    borderRadius: 7,
    backgroundColor: '#8e1580',
    padding: 1.5,
  },
  timerTrack: {
    flex: 1,
    borderRadius: 6,
    borderWidth: 2,
    borderColor: '#ffffff',
    backgroundColor: 'rgba(80,12,140,0.45)',
    overflow: 'hidden',
  },
  flash: { zIndex: 20 },
  doubleRow: { flexDirection: 'row', alignItems: 'center', gap: 10 },
  doubleNote: { fontFamily: candyFonts.display, fontSize: 11, lineHeight: 13, textAlign: 'center', color: '#ffffff' },
  bottom: { paddingHorizontal: 18, gap: 12 },
  toastAt: { position: 'absolute', left: 0, right: 0, height: 0, zIndex: 30 },
  collectionRow: { flexDirection: 'row', justifyContent: 'space-between', alignItems: 'center', marginBottom: 4 },
  odds: { gap: 6, paddingHorizontal: 14, paddingBottom: 4, paddingTop: 2 },
  secretArt: { width: 130, height: 120, alignItems: 'center', justifyContent: 'center' },
  secretMark: { ...StyleSheet.absoluteFillObject, alignItems: 'center', justifyContent: 'center' },
  secretText: { color: candyColors.inkSoft, fontFamily: candyFonts.bodyHeavy, fontSize: 13, textAlign: 'center', marginTop: 6, lineHeight: 18 },
  secretCount: { color: '#d3179a', fontFamily: candyFonts.display, fontSize: 15, marginTop: 8, letterSpacing: 0.5 },
  secretOk: { alignSelf: 'stretch', marginTop: 12 },
  collectionText: {
    color: '#ffffff',
    fontFamily: candyFonts.display,
    fontSize: 13,
    letterSpacing: 1,
    includeFontPadding: false,
  },
  collectionRing: {
    borderRadius: 10,
    backgroundColor: '#a23ad8',
    padding: 2,
    marginTop: -2,
  },
  collectionTrack: {
    height: 14,
    borderRadius: 8,
    borderWidth: 2.5,
    borderColor: '#ffffff',
    backgroundColor: 'rgba(80,12,140,0.45)',
    overflow: 'hidden',
  },
  revealButtons: { flexDirection: 'row', gap: 10 },
  payDivider: { width: 1.5, height: 18, backgroundColor: 'rgba(255,255,255,0.7)' },
  steps: { flexDirection: 'row', alignItems: 'center' },
  stepSlot: { flexDirection: 'row', alignItems: 'center' },
  stepLink: { width: 14, height: 4, borderRadius: 2, backgroundColor: 'rgba(255,255,255,0.8)', marginHorizontal: 3, marginBottom: 3 },
  stepNext: { opacity: 0.55 },
  stepLip: { borderRadius: 999, paddingBottom: 3 },
  stepRing: { borderRadius: 999, padding: 2 },
  stepRim: { borderRadius: 999, backgroundColor: '#ffffff', padding: 2.5 },
  stepFace: { minWidth: 30, height: 30, borderRadius: 999, overflow: 'hidden', alignItems: 'center', justifyContent: 'center' },
  stepPlay: {
    marginLeft: 3,
    width: 0,
    height: 0,
    borderTopWidth: 6,
    borderBottomWidth: 6,
    borderLeftWidth: 10,
    borderTopColor: 'transparent',
    borderBottomColor: 'transparent',
    borderLeftColor: '#ffffff',
  },
  revealFace: { paddingVertical: 12, paddingHorizontal: 6 },
  revealLabel: { fontSize: 14 },
});
