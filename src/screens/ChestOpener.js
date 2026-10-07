import React, { useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { Animated, Easing, PanResponder, Pressable, StyleSheet, Text, View } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import CandyBackground from '../components/candy/CandyBackground';
import RoundButton, { BackGlyph } from '../components/candy/RoundButton';
import OutlinedTitle from '../components/candy/OutlinedTitle';
import ShadowText, { outline3 } from '../components/candy/ShadowText';
import { RaysSpin } from '../components/candy/Decor';
import sfx from '../audio/sfx';
import { CHESTS, CHEST_LOOK, RAR_LOOK, chestArtOf, myChests } from '../squad/data';
import * as squad from '../squad/api';
import { BtnText, CandyBtn, Chest, F, PINK_RING } from '../squad/ui';
import RevealShow from './RevealShow';
import TutTarget from '../tutorial/Target';
import { report as tutReport } from '../tutorial/store';

// Opening a chest (the design's "Mystery Box Opener", chest variant): the
// chest has HP, cracked open in five stages by its mechanic — TAP it, HOLD
// it, SWIPE across it, or (Rainbow) tap, then hold, then swipe. Let go and
// it heals back to the start of its stage. At 0 HP it bursts and the Reveal
// Show plays.
//
// The server rolls the chest the moment the smashing starts (squad
// openChest); the burst waits for its answer. The chest's look per crack
// stage is the design's own art (src/squad/chestArt.js); the squash, wobble,
// tremble and burst are done here.

const HP = { basic: 100, silver: 160, gold: 200, crystal: 240, rainbow: 300, season: 160, welcome: 60 };
const DMG = { tap: [11, 15], hold: [5, 7], swipe: [42, 56] };
const MIX_DMG = { tap: [13, 17], hold: [6, 8], swipe: [50, 64] };
const MIX = ['tap', 'tap', 'hold', 'hold', 'swipe'];
const WORDS = ['', 'CLANK!', 'SNAP!', 'CRACK!', 'ALMOST!'];
const BITS = { basic: ['#ffe0c2', '#ffb27a', '#d4c6ff'], silver: ['#d6f0ff', '#8fd3ff', '#ffffff'], gold: ['#ffd1f0', '#ff8fd3', '#ffd84a'], crystal: ['#e4fff9', '#9ff7ea', '#e8dcff'], rainbow: ['#ffb3dd', '#ffd84a', '#9fd8ff'] };
const AURA = { basic: '#ffd59a', silver: '#bcd0ff', gold: '#ffe066', crystal: '#a8f6ff', rainbow: '#ffc2ec' };
const MECH_UI = {
  tap: { title: 'TAP TAP TAP!', sub: 'Stop tapping and it heals', tag: 'TAP', idle: 'Tap the chest to open' },
  hold: { title: 'HOLD TO CHARGE', sub: 'Let go and it heals', tag: 'HOLD', idle: 'Hold the chest to open' },
  swipe: { title: 'SWIPE TO SLASH', sub: 'Swipe across the chest', tag: 'SWIPE', idle: 'Swipe the chest to open' },
  mix: { tag: 'MIX', idle: 'Tap, then hold, then swipe' },
};
// the idle loop per stage: [ms, rotate°, scaleX, scaleY]
const IDLE = [null, [2400, 1, 1, 1], [1400, 2.2, 1.02, 0.98], [900, 0, 1.045, 0.955], [550, 1.8, 1.07, 0.93]];
const rnd = (a, b) => a + Math.random() * (b - a);
const irnd = (a, b) => Math.round(rnd(a, b));
const SIZE = 240 * 1.12;
const ORIGIN_DY = (0.86 - 0.5) * SIZE; // the design squashes about 50% 86%

// One flying chip, number, or slash: a view that animates once and goes.
function Fx({ item, onDone }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    Animated.timing(t, { toValue: 1, duration: item.ms, easing: Easing.out(Easing.cubic), useNativeDriver: true }).start(() => onDone(item.id));
  }, [t, item, onDone]);
  if (item.kind === 'part') {
    return (
      <Animated.View
        style={{
          position: 'absolute', left: item.x - item.w / 2, top: item.y - item.h / 2, width: item.w, height: item.h, borderRadius: item.round ? item.w : 2, backgroundColor: item.c,
          borderWidth: item.round ? 0 : 2, borderColor: '#ffffff',
          opacity: t.interpolate({ inputRange: [0, 1], outputRange: [1, 0] }),
          transform: [{ translateX: t.interpolate({ inputRange: [0, 1], outputRange: [0, item.dx] }) }, { translateY: t.interpolate({ inputRange: [0, 1], outputRange: [0, item.dy] }) }, { rotate: t.interpolate({ inputRange: [0, 1], outputRange: ['0deg', `${item.rot}deg`] }) }, { scale: t.interpolate({ inputRange: [0, 1], outputRange: [1, 0.6] }) }],
        }}
      />
    );
  }
  if (item.kind === 'slash') {
    return (
      <Animated.View
        style={{
          position: 'absolute', left: item.x - item.len / 2, top: item.y - 4.5, width: item.len, height: 9, borderRadius: 999, backgroundColor: '#ffffff', shadowColor: '#bff6ff', shadowRadius: 10, shadowOpacity: 1, elevation: 6,
          opacity: t.interpolate({ inputRange: [0, 0.35, 1], outputRange: [1, 1, 0] }),
          transform: [{ rotate: `${item.ang}deg` }, { scaleX: t.interpolate({ inputRange: [0, 0.35, 1], outputRange: [0.15, 1, 1.08] }) }],
        }}
      />
    );
  }
  // a damage / heal number
  return (
    <Animated.View
      pointerEvents="none"
      style={{
        position: 'absolute', left: item.x - 60, top: item.y - item.size / 2, width: 120, alignItems: 'center',
        opacity: t.interpolate({ inputRange: [0, 0.18, 1], outputRange: [0, 1, 0] }),
        transform: [{ translateY: t.interpolate({ inputRange: [0, 0.18, 1], outputRange: [0, -0.3 * item.size, -2.1 * item.size] }) }, { scale: t.interpolate({ inputRange: [0, 0.18, 1], outputRange: [0.4, 1.25, 0.95] }) }],
      }}
    >
      <ShadowText style={{ fontFamily: F.display, fontSize: item.size, color: item.color }} shadows={[[0, 4, '#45107a'], [2, 0, '#45107a'], [-2, 0, '#45107a'], [0, 2, '#45107a'], [0, -2, '#45107a']]}>
        {item.txt}
      </ShadowText>
    </Animated.View>
  );
}

export default function ChestOpener({ tier, profile, catalog, onClose }) {
  const insets = useSafeAreaInsets();
  const hp = HP[tier] || 100;
  const mechOf = tier === 'rainbow' ? 'mix' : { basic: 'tap', silver: 'tap', gold: 'hold', crystal: 'swipe', season: 'tap', welcome: 'tap' }[tier];
  const art = chestArtOf(tier);

  const [phase, setPhase] = useState('idle'); // idle | smash | burst | reveal
  const [dmg, setDmg] = useState(0);
  const [fx, setFx] = useState([]);
  const [word, setWord] = useState(null);
  const [healing, setHealing] = useState(false);
  const [holding, setHolding] = useState(false);
  const [pull, setPull] = useState(null);
  const [stageBox, setStageBox] = useState({ w: 360, h: 400 });

  const r = useRef({ phase: 'idle', dmg: 0, down: false, anchor: null, lastSlash: 0, tick: 0, holdT: null, healT: null, id: 0, result: null, failed: false, burstReady: false }).current;

  // chest motion
  const sx = useRef(new Animated.Value(1)).current;
  const sy = useRef(new Animated.Value(1)).current;
  const idle = useRef(new Animated.Value(0)).current;
  const bob = useRef(new Animated.Value(0)).current;
  const shake = useRef(new Animated.ValueXY({ x: 0, y: 0 })).current;
  const tremble = useRef(new Animated.ValueXY({ x: 0, y: 0 })).current;
  const fade = useRef(new Animated.Value(1)).current;
  const flash = useRef(new Animated.Value(0)).current;
  const ring = useRef(new Animated.Value(0)).current;

  const stageOf = (d) => Math.min(5, Math.floor(d / (hp / 5) + 1e-9));
  const st = stageOf(dmg);
  const mech = mechOf === 'mix' ? MIX[Math.min(4, st)] : mechOf;
  const range = (m) => (mechOf === 'mix' ? MIX_DMG[m] : DMG[m]);

  // idle bob (before the first touch) and the per-stage wobble
  useEffect(() => {
    if (phase !== 'idle') return undefined;
    const loop = Animated.loop(Animated.sequence([Animated.timing(bob, { toValue: 1, duration: 1200, easing: Easing.inOut(Easing.sin), useNativeDriver: true }), Animated.timing(bob, { toValue: 0, duration: 1200, easing: Easing.inOut(Easing.sin), useNativeDriver: true })]));
    loop.start();
    return () => loop.stop();
  }, [phase, bob]);
  const idleStage = Math.min(4, st);
  useEffect(() => {
    const spec = IDLE[idleStage];
    idle.setValue(0);
    if (!spec || phase === 'burst' || phase === 'reveal') return undefined;
    const loop = Animated.loop(Animated.sequence([Animated.timing(idle, { toValue: 1, duration: spec[0] / 2, easing: Easing.inOut(Easing.sin), useNativeDriver: true }), Animated.timing(idle, { toValue: -1, duration: spec[0] / 2, easing: Easing.inOut(Easing.sin), useNativeDriver: true })]));
    loop.start();
    return () => loop.stop();
  }, [idleStage, phase, idle]);

  // shaking while it's held (lcTremble: more the further along)
  useEffect(() => {
    if (!holding || phase !== 'smash') {
      tremble.setValue({ x: 0, y: 0 });
      return undefined;
    }
    const amp = 1 + Math.min(1, 0.25 + r.dmg / hp) * 3;
    const t = setInterval(() => tremble.setValue({ x: rnd(-amp, amp), y: rnd(-amp, amp) }), 50);
    return () => clearInterval(t);
  }, [holding, phase, tremble, r, hp]);

  const addFx = useCallback((items) => setFx((f) => [...f.slice(-48), ...items]), []);
  const dropFx = useCallback((id) => setFx((f) => f.filter((x) => x.id !== id)), []);
  const center = () => ({ x: stageBox.w / 2, y: stageBox.h * 0.5 });

  const parts = (n, x, y, spread) => {
    const cols = BITS[art] || BITS.basic;
    const out = [];
    for (let i = 0; i < n; i++) {
      const ang = rnd(0, Math.PI * 2);
      const dist = rnd(50, spread);
      const round = i % 3 === 2;
      out.push({ id: ++r.id, kind: 'part', ms: 700, x, y, round, w: round ? irnd(5, 8) : irnd(4, 6), h: round ? irnd(5, 8) : irnd(12, 19), c: round ? '#fff3a0' : cols[i % cols.length], dx: Math.cos(ang) * dist, dy: Math.sin(ang) * dist + 40, rot: irnd(-320, 320) });
    }
    return out;
  };
  const num = (x, y, txt, color, size) => ({ id: ++r.id, kind: 'num', ms: 850, x, y, txt, color, size });

  const shakeIt = (big) => {
    const a = big ? 9 : 3;
    Animated.sequence([
      Animated.timing(shake, { toValue: { x: -a, y: a / 2 }, duration: 50, useNativeDriver: true }),
      Animated.timing(shake, { toValue: { x: a * 0.9, y: -a / 2 }, duration: 60, useNativeDriver: true }),
      Animated.timing(shake, { toValue: { x: -a * 0.6, y: a / 3 }, duration: 60, useNativeDriver: true }),
      Animated.timing(shake, { toValue: { x: 0, y: 0 }, duration: 60, useNativeDriver: true }),
    ]).start();
  };
  // impact squash, then the recoil (lcRecA)
  const squash = (up) => {
    sx.setValue(1.13);
    sy.setValue(0.86);
    Animated.parallel([
      Animated.sequence([Animated.delay(up ? 130 : 60), Animated.timing(sx, { toValue: 0.93, duration: 130, useNativeDriver: true }), Animated.timing(sx, { toValue: 1.03, duration: 95, useNativeDriver: true }), Animated.timing(sx, { toValue: 1, duration: 95, useNativeDriver: true })]),
      Animated.sequence([Animated.delay(up ? 130 : 60), Animated.timing(sy, { toValue: 1.09, duration: 130, useNativeDriver: true }), Animated.timing(sy, { toValue: 0.98, duration: 95, useNativeDriver: true }), Animated.timing(sy, { toValue: 1, duration: 95, useNativeDriver: true })]),
    ]).start();
  };

  const burst = () => {
    r.phase = 'burst';
    stopHold();
    clearTimeout(r.healT);
    setPhase('burst');
    sfx.play('boxOpen');
    shakeIt(true);
    const c = center();
    addFx(parts(18, c.x, c.y, 190));
    flash.setValue(0);
    Animated.sequence([Animated.timing(flash, { toValue: 1, duration: 110, useNativeDriver: true }), Animated.timing(flash, { toValue: 0, duration: 790, useNativeDriver: true })]).start();
    Animated.parallel([
      Animated.sequence([Animated.timing(sx, { toValue: 1.22, duration: 230, useNativeDriver: true }), Animated.timing(sx, { toValue: 0.88, duration: 160, useNativeDriver: true }), Animated.timing(sx, { toValue: 1.6, duration: 260, useNativeDriver: true })]),
      Animated.sequence([Animated.timing(sy, { toValue: 0.82, duration: 230, useNativeDriver: true }), Animated.timing(sy, { toValue: 1.2, duration: 160, useNativeDriver: true }), Animated.timing(sy, { toValue: 1.6, duration: 260, useNativeDriver: true })]),
      Animated.sequence([Animated.delay(390), Animated.timing(fade, { toValue: 0, duration: 260, useNativeDriver: true })]),
    ]).start();
    setTimeout(() => {
      r.burstReady = true;
      maybeReveal();
    }, 700);
  };

  // The reveal needs the burst done and the server's answer.
  const maybeReveal = () => {
    if (!r.burstReady || r.phase === 'reveal') return;
    if (r.failed) {
      onClose();
      return;
    }
    if (!r.result) return;
    r.phase = 'reveal';
    setPull(r.result);
    setPhase('reveal');
  };

  const hit = (amt, o) => {
    if (r.phase !== 'smash') return;
    const prev = stageOf(r.dmg);
    r.dmg = Math.min(hp, r.dmg + amt);
    const now = stageOf(r.dmg);
    const up = now > prev;
    clearTimeout(r.healT);
    setDmg(r.dmg);
    setHealing(false);
    const strong = o.kind !== 'hold' || up;
    if (strong) {
      squash(up);
      shakeIt(up || o.kind === 'swipe');
    }
    if (up && now < 5) {
      setWord({ text: WORDS[now], key: ++r.id });
      ring.setValue(0);
      Animated.timing(ring, { toValue: 1, duration: 550, easing: Easing.out(Easing.quad), useNativeDriver: true }).start();
      sfx.play('bonk');
    }
    const items = [];
    if (o.kind !== 'hold' || o.showNum || up) items.push(num(o.x, o.y - 10, `${o.crit ? 'CRIT -' : '-'}${amt}`, o.crit ? '#ffe045' : '#ffffff', o.crit ? 30 : o.kind === 'hold' ? 18 : 24));
    const c = center();
    items.push(...parts((o.kind === 'swipe' ? 7 : o.kind === 'tap' ? 4 : r.tick % 2) + (up ? 8 : 0), o.kind === 'hold' ? c.x : o.x, o.kind === 'hold' ? c.y : o.y, up ? 150 : 100));
    addFx(items);
    if (r.dmg >= hp) burst();
    else if (!r.holdT && !r.down) armHeal();
  };

  const armHeal = () => {
    clearTimeout(r.healT);
    if (r.phase !== 'smash' || r.dmg <= 0) return;
    r.healT = setTimeout(healStep, 1100);
  };
  const healStep = () => {
    if (r.phase !== 'smash' || r.holdT || r.down || r.dmg <= 0) return;
    const chunk = hp / 5;
    const nd = Math.max(0, (stageOf(r.dmg) - 1) * chunk);
    const healed = Math.round(r.dmg - nd);
    r.dmg = nd;
    setDmg(nd);
    setHealing(true);
    const c = center();
    addFx([num(c.x + rnd(-40, 40), c.y - 70, `+${healed}`, '#9dffcf', 22)]);
    setTimeout(() => setHealing(false), 450);
    if (nd > 0) r.healT = setTimeout(healStep, 650);
  };

  const curMech = () => (mechOf === 'mix' ? MIX[Math.min(4, stageOf(r.dmg))] : mechOf);
  const startHold = () => {
    if (r.holdT) return;
    setHolding(true);
    r.holdT = setInterval(() => {
      if (r.phase !== 'smash' || curMech() !== 'hold') {
        stopHold();
        return;
      }
      r.tick += 1;
      const [a, b] = range('hold');
      const c = center();
      if (r.tick % 3 === 0) sfx.play('holdStep');
      hit(irnd(a, b), { kind: 'hold', x: c.x + rnd(-70, 70), y: c.y + rnd(-60, 20), showNum: r.tick % 3 === 0 });
    }, 80);
  };
  const stopHold = () => {
    if (!r.holdT) return;
    clearInterval(r.holdT);
    r.holdT = null;
    setHolding(false);
  };

  // The server rolls the chest as the smashing starts.
  const start = () => {
    r.phase = 'smash';
    r.dmg = 0;
    r.tick = 0;
    setPhase('smash');
    squad
      .openChest(tier)
      .then((res) => {
        r.result = res;
        maybeReveal();
      })
      .catch(() => {
        r.failed = true;
        maybeReveal();
      });
  };

  const pan = useMemo(
    () =>
      PanResponder.create({
        onStartShouldSetPanResponder: () => true,
        onMoveShouldSetPanResponder: () => true,
        onPanResponderGrant: (e) => {
          if (r.phase === 'burst' || r.phase === 'reveal') return;
          if (r.phase === 'idle') start();
          r.down = true;
          clearTimeout(r.healT);
          const p = { x: e.nativeEvent.locationX, y: e.nativeEvent.locationY };
          const m = curMech();
          if (m === 'tap') {
            const [a, b] = range('tap');
            const crit = Math.random() < 0.12;
            sfx.play('boxThump');
            hit(irnd(a, b) * (crit ? 2 : 1), { kind: 'tap', x: p.x, y: p.y, crit });
          } else if (m === 'hold') startHold();
          else r.anchor = p;
        },
        onPanResponderMove: (e) => {
          if (!r.down || r.phase !== 'smash') return;
          const m = curMech();
          const p = { x: e.nativeEvent.locationX, y: e.nativeEvent.locationY };
          if (m === 'hold' && !r.holdT) return startHold();
          if (m !== 'swipe') return;
          const a = r.anchor;
          if (!a) {
            r.anchor = p;
            return;
          }
          const d = Math.hypot(p.x - a.x, p.y - a.y);
          const t = Date.now();
          if (d > 70 && t - r.lastSlash > 140) {
            r.lastSlash = t;
            const [lo, hi] = range('swipe');
            const crit = Math.random() < 0.2;
            const len = Math.max(170, d * 1.8);
            const sl = { id: ++r.id, kind: 'slash', ms: 380, x: (a.x + p.x) / 2, y: (a.y + p.y) / 2, len, ang: (Math.atan2(p.y - a.y, p.x - a.x) * 180) / Math.PI };
            addFx([sl]);
            sfx.play('swipe');
            hit(Math.round(irnd(lo, hi) * (crit ? 1.5 : 1)), { kind: 'swipe', x: sl.x, y: sl.y, crit });
            r.anchor = p;
          }
        },
        onPanResponderRelease: () => {
          r.down = false;
          r.anchor = null;
          stopHold();
          armHeal();
        },
        onPanResponderTerminate: () => {
          r.down = false;
          r.anchor = null;
          stopHold();
          armHeal();
        },
      }),
    // the handlers read everything live from `r`
    // eslint-disable-next-line react-hooks/exhaustive-deps
    [stageBox],
  );

  useEffect(
    () => () => {
      clearInterval(r.holdT);
      clearTimeout(r.healT);
    },
    [r],
  );
  // the tutorial's view: smashing (or about to), or the reveal
  useEffect(() => tutReport({ boxPhase: phase === 'reveal' ? 'reveal' : 'opening' }), [phase]);
  useEffect(() => () => tutReport({ boxPhase: 'closed' }), []);

  // the next chest of the same kind, if there's one waiting
  const again = () => {
    const left = (myChests(profile)[tier] || 0) > 0;
    if (!left) return onClose();
    Object.assign(r, { phase: 'idle', dmg: 0, result: null, failed: false, burstReady: false });
    sx.setValue(1);
    sy.setValue(1);
    fade.setValue(1);
    setDmg(0);
    setPull(null);
    setWord(null);
    setPhase('idle');
  };

  const stageImg = phase === 'burst' || phase === 'reveal' ? 'burst' : Math.min(4, st);
  const rem = hp - dmg;
  const chunk = hp / 5;
  const spec = IDLE[idleStage];
  const idleRot = idle.interpolate({ inputRange: [-1, 1], outputRange: [`${-(spec?.[1] || 0)}deg`, `${spec?.[1] || 0}deg`] });
  const idleSx = idle.interpolate({ inputRange: [-1, 0, 1], outputRange: [1, 1, spec?.[2] || 1] });
  const idleSy = idle.interpolate({ inputRange: [-1, 0, 1], outputRange: [1, 1, spec?.[3] || 1] });
  const busy = phase === 'smash' || phase === 'burst';
  const mu = MECH_UI[mech] || MECH_UI.tap;
  const odds = (CHESTS[tier]?.odds || []).map((p, i) => ({ p, i })).filter((o) => o.p > 0);
  const glow = pull ? RAR_LOOK[pull.rar]?.dot : '#fff3a0';

  return (
    <View style={StyleSheet.absoluteFill}>
      <CandyBackground style={{ paddingTop: insets.top }}>
        <Animated.View style={{ flex: 1, transform: [{ translateX: shake.x }, { translateY: shake.y }] }}>
          <View style={styles.header}>
            <RoundButton size={36} onPress={busy ? undefined : onClose} dim={busy}>
              <BackGlyph />
            </RoundButton>
            <OutlinedTitle text={`${CHEST_LOOK[tier].name.toUpperCase()} CHEST`} fill="pink" size={23} outline={3} ring={2} drop={5} />
          </View>
          <View style={styles.odds}>
            {odds.map(({ p, i }) => (
              <View key={i} style={[styles.oddsChip, { backgroundColor: RAR_LOOK[i].bg }]}>
                <Text style={styles.oddsLabel}>{RAR_LOOK[i].label}</Text>
                <Text style={styles.oddsPct}>{p}%</Text>
              </View>
            ))}
          </View>

          <View style={{ flex: 1 }} onLayout={(e) => setStageBox({ w: e.nativeEvent.layout.width, h: e.nativeEvent.layout.height })} {...pan.panHandlers}>
            {phase !== 'reveal' && (
              <View style={styles.bar} pointerEvents="none">
                <View style={styles.barHead}>
                  <ShadowText style={styles.barLabel} shadows={outline3('#45107a', 1.5)}>
                    {phase === 'idle' ? 'CHEST HP' : st >= 5 ? 'OPEN!' : `STAGE ${st + 1} / 5`}
                  </ShadowText>
                  <ShadowText style={[styles.barLabel, { color: '#fff3a0', letterSpacing: 0 }]} shadows={outline3('#45107a', 1.5)}>
                    {`${Math.max(0, Math.round(rem))} / ${hp}`}
                  </ShadowText>
                </View>
                <View style={styles.segs}>
                  {[0, 1, 2, 3, 4].map((i) => {
                    const f = Math.max(0, Math.min(1, (rem - i * chunk) / chunk));
                    return (
                      <View key={i} style={styles.seg}>
                        <View style={[styles.segFill, { width: `${f * 100}%`, backgroundColor: healing && f > 0 ? '#7ee8b4' : '#ff8fd0' }]} />
                      </View>
                    );
                  })}
                </View>
              </View>
            )}

            {phase !== 'reveal' && (
              <View style={styles.center} pointerEvents="none">
                <View style={styles.halo} />
                <RaysSpin size={460} durationMs={16000} rayDeg={9} gapDeg={13} opacity={0.5} color={AURA[art]} fadeStart={0.12} fadeEnd={0.62} style={styles.rays} />
                <View style={[styles.floorGlow, { backgroundColor: AURA[art] }]} />
                <TutTarget name="chestStage" style={styles.tutChest} pointerEvents="none" />
                <Animated.View
                  style={{
                    width: SIZE, height: SIZE, marginTop: -32, opacity: fade,
                    transform: [
                      { translateX: tremble.x },
                      { translateY: Animated.add(tremble.y, bob.interpolate({ inputRange: [0, 1], outputRange: [0, -8] })) },
                      // squash about the chest's foot (50% 86%)
                      { translateY: ORIGIN_DY },
                      { scaleX: Animated.multiply(sx, idleSx) },
                      { scaleY: Animated.multiply(sy, idleSy) },
                      { rotate: idleRot },
                      { translateY: -ORIGIN_DY },
                    ],
                  }}
                >
                  <Chest tier={art} stage={stageImg} size={SIZE} />
                </Animated.View>
              </View>
            )}

            <View style={StyleSheet.absoluteFill} pointerEvents="none">
              {fx.map((item) => (
                <Fx key={item.id} item={item} onDone={dropFx} />
              ))}
              {word && phase === 'smash' && (
                <>
                  <Animated.View
                    style={[styles.ring, { left: stageBox.w / 2 - 125, top: stageBox.h / 2 - 125, shadowColor: glow, opacity: ring.interpolate({ inputRange: [0, 1], outputRange: [0.95, 0] }), transform: [{ scale: ring.interpolate({ inputRange: [0, 1], outputRange: [0.3, 1.7] }) }] }]}
                  />
                  <Word key={word.key} text={word.text} />
                </>
              )}
            </View>
          </View>

          <View style={[styles.foot, { paddingBottom: 22 + insets.bottom }]}>
            {phase === 'idle' && (
              <View style={styles.idlePill}>
                <ShadowText style={styles.idleText} shadows={[[0, 3.5, '#45107a'], [2, 0, '#45107a'], [-2, 0, '#45107a'], [0, 2, '#45107a'], [0, -2, '#45107a']]}>
                  {MECH_UI[mechOf].idle}
                </ShadowText>
              </View>
            )}
            {busy && (
              <>
                {mechOf === 'mix' && (
                  <View style={styles.mixRow}>
                    {['tap', 'hold', 'swipe'].map((k) => (
                      <View key={k} style={[styles.mixStep, { backgroundColor: k === mech ? '#ff4fbf' : 'rgba(255,255,255,0.85)' }]}>
                        <Text style={[styles.mixText, { color: k === mech ? '#ffffff' : '#6a1b9a' }]}>{MECH_UI[k].tag}</Text>
                      </View>
                    ))}
                  </View>
                )}
                <CandyBtn kind="pink" padV={10} padH={26} lip={5} key={mech}>
                  <BtnText ring={PINK_RING} size={22}>
                    {mu.title}
                  </BtnText>
                </CandyBtn>
                <ShadowText style={[styles.sub, { color: healing ? '#fff3a0' : '#ffffff' }]} shadows={[[0, 3, '#45107a'], [1.5, 0, '#45107a'], [-1.5, 0, '#45107a'], [0, 1.5, '#45107a'], [0, -1.5, '#45107a']]}>
                  {healing ? "It's healing! Keep going" : mu.sub}
                </ShadowText>
              </>
            )}
          </View>
        </Animated.View>
        <Animated.View pointerEvents="none" style={[StyleSheet.absoluteFill, { backgroundColor: '#ffffff', opacity: flash }]} />
      </CandyBackground>
      {phase === 'reveal' && pull && (
        <RevealShow pull={pull} creature={catalog[pull.id]} chestName={CHEST_LOOK[tier].name} canAgain={(myChests(profile)[tier] || 0) > 0} onAgain={again} onClose={onClose} />
      )}
    </View>
  );
}

// "CRACK!" — pops up big and floats away (mbWord).
function Word({ text }) {
  const t = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    Animated.timing(t, { toValue: 1, duration: 900, easing: Easing.out(Easing.quad), useNativeDriver: true }).start();
  }, [t]);
  return (
    <Animated.View
      style={[
        styles.word,
        {
          opacity: t.interpolate({ inputRange: [0, 0.25, 0.7, 1], outputRange: [0, 1, 1, 0] }),
          transform: [
            { translateY: t.interpolate({ inputRange: [0, 0.25, 0.7, 1], outputRange: [0, -10, -18, -34] }) },
            { scale: t.interpolate({ inputRange: [0, 0.25, 0.7, 1], outputRange: [0.3, 1.2, 1, 0.9] }) },
            { rotate: t.interpolate({ inputRange: [0, 0.25, 0.7, 1], outputRange: ['-10deg', '4deg', '0deg', '0deg'] }) },
          ],
        },
      ]}
    >
      <OutlinedTitle text={text} fill="gold" size={34} outline={3} ring={2} drop={5} />
    </Animated.View>
  );
}

const styles = StyleSheet.create({
  header: { flexDirection: 'row', alignItems: 'center', gap: 10, paddingHorizontal: 16, paddingTop: 8, paddingBottom: 10 },
  odds: { flexDirection: 'row', flexWrap: 'wrap', justifyContent: 'center', gap: 4, paddingHorizontal: 12, paddingBottom: 4 },
  oddsChip: { flexDirection: 'row', alignItems: 'center', gap: 4, borderWidth: 2, borderColor: '#ffffff', borderRadius: 999, paddingHorizontal: 7, paddingVertical: 1 },
  oddsLabel: { fontFamily: F.display, fontSize: 9.5, letterSpacing: 0.5, color: '#4a1a73' },
  oddsPct: { fontFamily: F.display, fontSize: 9.5, color: '#4a1a73' },
  bar: { position: 'absolute', left: '50%', top: 14, width: 236, marginLeft: -118, gap: 4, zIndex: 2 },
  barHead: { flexDirection: 'row', justifyContent: 'space-between', paddingHorizontal: 2 },
  barLabel: { fontFamily: F.display, fontSize: 12, letterSpacing: 1, color: '#ffffff' },
  segs: { flexDirection: 'row', gap: 4 },
  seg: { flex: 1, height: 13, borderRadius: 6, borderWidth: 2, borderColor: '#ffffff', backgroundColor: '#e6d6f5', overflow: 'hidden' },
  segFill: { position: 'absolute', left: 0, top: 0, bottom: 0 },
  center: { ...StyleSheet.absoluteFillObject, alignItems: 'center', justifyContent: 'center' },
  halo: { position: 'absolute', width: 260, height: 260, borderRadius: 130, backgroundColor: 'rgba(255,240,200,0.55)' },
  rays: { position: 'absolute' },
  tutChest: { position: 'absolute', width: 220, height: 200, marginTop: -40 },
  floorGlow: { position: 'absolute', width: 250, height: 56, borderRadius: 125, marginTop: 220, opacity: 0.55 },
  ring: { position: 'absolute', width: 250, height: 250, borderRadius: 125, borderWidth: 6, borderColor: '#ffffff', shadowRadius: 14, shadowOpacity: 1 },
  word: { position: 'absolute', left: 0, right: 0, top: '16%', alignItems: 'center' },
  foot: { paddingHorizontal: 16, alignItems: 'center', gap: 10, minHeight: 120, justifyContent: 'flex-end' },
  idlePill: { backgroundColor: '#c78bff', borderWidth: 3, borderColor: '#ffffff', borderRadius: 999, paddingHorizontal: 16, paddingVertical: 5 },
  idleText: { fontFamily: F.display, fontSize: 17, color: '#ffffff' },
  mixRow: { flexDirection: 'row', gap: 6 },
  mixStep: { borderWidth: 2, borderColor: '#ffffff', borderRadius: 999, paddingHorizontal: 10, paddingVertical: 3 },
  mixText: { fontFamily: F.black, fontSize: 10, letterSpacing: 1 },
  sub: { fontFamily: F.display, fontSize: 15 },
});
