import React, { forwardRef, memo, useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { Animated, BackHandler, FlatList, Image, StyleSheet, Text, View, useWindowDimensions } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Circle, Path } from 'react-native-svg';
import ChestSmash from '../components/ChestSmash';
import VaultLoader, { buddyUriOf } from '../components/VaultLoader';
import Toast from '../components/squad/Toast';
import { PrizeArt, prizeLabel } from '../components/LevelBits';
import { ChestDrop, FlyLayer, centerOf, flyReward, usePurse } from '../components/RewardFx';
import { BtnText, CandyBtn, F, GOLD, GOLD_RING, Ringed } from '../squad/ui';
import { HIDDEN, lineup, wallet } from '../squad/data';
import { COIN, GEM } from '../squad/currencyArt';
import * as squad from '../squad/api';
import { todayKey } from '../dailySpin';
import sfx from '../audio/sfx';
import { fmtNum } from '../format';
import { roadView, xpView } from '../playerXp';
import { Lettering, Orb, WoodBg } from '../royal';

// The level road (PLAYER_XP.md): the player's level and XP bar across the
// top, and under them a prize at every level on the road (config/levels
// `road`), left to right (REDESIGN_V8: drag it sideways), each claimed once
// from the server (squad levelClaim). A claim's coins and gems burst out of
// the prize's icon and fly up to the counters in the header; a chest drops
// in from above and opens in the Shop's smash (src/components/RewardFx.js).
// Chests are of today's first HOT group. `autoClaim`: levels to claim as it
// opens (the LEVEL UP card's COLLECT).

const ERRORS = {
  claimed: 'Already claimed',
  need_level: 'Reach that level first',
  nothing_to_claim: 'Nothing to claim yet',
  unknown_reward: "That prize isn't there any more",
};

const Check = () => (
  <Svg width={30} height={30} viewBox="0 0 24 24">
    <Circle cx={12} cy={12} r={11} fill="#ffffff" />
    <Circle cx={12} cy={12} r={8.5} fill="#26a94e" />
    <Path d="M8 12.3 L10.8 15 L16.2 9.4" stroke="#ffffff" strokeWidth={2.6} fill="none" strokeLinecap="round" strokeLinejoin="round" />
  </Svg>
);
// the same lock as the SVG it was (viewBox 13 × 14 at 12 px), in plain
// views: most rows the road opens on are locked, and an SVG view each made
// building them slow (2026-10-28)
const Lock = () => (
  <View style={styles.lock}>
    <View style={styles.lockShackle} />
    <View style={styles.lockBody} />
  </View>
);

// The coin / gem counter (the lobby's), counting up as a reward flies in
// (RewardFx usePurse). ref: { icon, hold(n), add(n), release() }
const Purse = forwardRef(function Purse({ gem, amount }, ref) {
  const { icon, scale, shown } = usePurse(ref, amount);
  return (
    <Animated.View style={{ transform: [{ scale }] }}>
      <Ringed ring="#6b4426" lip={3} ringW={2} border={2.5} innerStyle={styles.purse}>
        <View ref={icon} collapsable={false}>
          <Image source={gem ? GEM[0] : COIN[0]} style={gem ? styles.gemImg : styles.coinImg} fadeDuration={0} />
        </View>
        <Text style={[styles.purseText, { color: gem ? '#1d6fb8' : '#b86200' }]}>{fmtNum(shown)}</Text>
      </Ringed>
    </Animated.View>
  );
});

// One level of the road as a column (REDESIGN_V8, every list sideways): its disc on a rail running left to right and
// its prize card under it
const COL = 128;
const Col = memo(function Col({ n, last, current, group, busy, toGo, onClaim, onIcon }) {
  const { lv, r, got, claimable, reached } = n;
  return (
    <View style={styles.col}>
      <View style={[styles.hRail, reached && styles.railOn, lv === 1 && { left: COL / 2 }, last && { right: COL / 2 }]} />
      {reached ? (
        <LinearGradient colors={GOLD} locations={[0, 0.5, 1]} style={[styles.disc, current && styles.discNow]}>
          <Text style={styles.discText}>{lv}</Text>
        </LinearGradient>
      ) : (
        <View style={[styles.disc, styles.discOff]}>
          <Text style={[styles.discText, { color: '#a88d70' }]}>{lv}</Text>
        </View>
      )}
      <Ringed ring={claimable ? GOLD_RING : reached ? '#c8955e' : '#e2cfb4'} lip={3} ringW={2} border={2.5} radius={18} bg={got ? '#f6ece0' : '#ffffff'} style={styles.colCardRing} innerStyle={styles.colCard}>
        <View ref={(v) => onIcon(lv, v)} collapsable={false} style={styles.colArt}>
          <PrizeArt r={r} group={group} i={lv} size={50} dim={got} />
        </View>
        <Text style={[styles.colPrize, got && styles.prizeGot, !reached && styles.prizeOff]} numberOfLines={2}>
          {prizeLabel(r)}
        </Text>
        {got ? (
          <Check />
        ) : claimable ? (
          <CandyBtn kind={busy ? 'grey' : 'gold'} padV={5} padH={12} onPress={() => onClaim([lv])} disabled={busy}>
            <BtnText ring={busy ? '#8a7a6a' : GOLD_RING} size={14}>
              CLAIM
            </BtnText>
          </CandyBtn>
        ) : (
          <View style={styles.lockTag}>
            <Lock />
            <Text style={styles.lockText}>{toGo ? `${fmtNum(toGo)} XP` : `LV ${lv}`}</Text>
          </View>
        )}
      </Ringed>
    </View>
  );
});

// `levels`: config/levels (already in src/playerXp.js; here so the road redraws when it changes)
function LevelRoadScreen({ profile, levels, creatures, hidden = HIDDEN, autoClaim = null, onBack }) {
  const insets = useSafeAreaInsets();
  const { height: winH } = useWindowDimensions();
  const view = xpView(profile);
  const profileRef = useRef(profile);
  profileRef.current = profile;
  const w = wallet(profile);
  const nodes = useMemo(() => roadView(profile), [profile, levels]); // eslint-disable-line react-hooks/exhaustive-deps
  const claimable = nodes.filter((n) => n.claimable).map((n) => n.lv);
  const group = useMemo(() => lineup(todayKey(new Date()), hidden)[0], [hidden]);
  const catalog = useMemo(() => Object.fromEntries((creatures || []).map((c) => [c.id, c])), [creatures]);

  const [toast, setToast] = useState(null);
  const flash = useCallback((text) => setToast({ text, key: Date.now() }), []);
  useEffect(() => {
    if (!toast) return undefined;
    const t = setTimeout(() => setToast(null), 2600);
    return () => clearTimeout(t);
  }, [toast]);

  // the chest smash: the one showing and the ones after it. The first opens behind "To the treasure vault"
  // (REDESIGN_V9: the user's loading screen for going to open a chest) until its page has painted (`up`); the ones
  // after it (CLAIM ALL's), on the same page, drop in from above (`drop`)
  const [smash, setSmash] = useState(null); // { chest: { key, result }, queue, up }
  const [drop, setDrop] = useState(null); // { key, group, size, reveal }
  const smashKey = useRef(0);
  const smashRef = useRef(smash);
  smashRef.current = smash;
  const showChest = useCallback((result, queue) => {
    smashKey.current += 1;
    const next = !!smashRef.current;
    setSmash((s) => ({ chest: { key: smashKey.current, result }, queue, up: !!(s && s.up) }));
    if (next) setDrop({ key: smashKey.current, group: result.group, size: result.size });
  }, []);
  const smashShown = useCallback(() => setSmash((s) => s && { ...s, up: true }), []);
  const [vaultGone, setVaultGone] = useState(false);
  const smashOn = !!smash;
  useEffect(() => {
    if (!smashOn) setVaultGone(false);
  }, [smashOn]);
  const vaultDone = useCallback(() => setVaultGone(true), []);
  const buddy = useMemo(() => buddyUriOf(creatures, profile), [creatures, profile]);
  const collectSmash = useCallback(() => {
    const s = smashRef.current;
    if (!s || !s.queue.length) return setSmash(null);
    showChest(s.queue[0], s.queue.slice(1));
  }, [showChest]);

  // The counters hold what the wallet had while a claim runs and its rewards
  // fly in, then let go once the profile has the claims (`waitFor`: their
  // levels; the server writes the coins in the same go), or after a while.
  const coinPurse = useRef(null);
  const gemPurse = useRef(null);
  const holdPurses = useCallback((wl) => {
    coinPurse.current?.hold(wl.coins);
    gemPurse.current?.hold(wl.gems);
  }, []);
  const releasePurses = useCallback(() => {
    coinPurse.current?.release();
    gemPurse.current?.release();
  }, []);
  const [waitFor, setWaitFor] = useState(null);
  const claimedNow = profile?.levelGot || {};
  const caughtUp = !!waitFor && waitFor.every((lv) => claimedNow[lv]);
  useEffect(() => {
    if (!waitFor) return undefined;
    if (caughtUp) {
      releasePurses();
      setWaitFor(null);
      return undefined;
    }
    const t = setTimeout(() => {
      releasePurses();
      setWaitFor(null);
    }, 20000);
    return () => clearTimeout(t);
  }, [waitFor, caughtUp, releasePurses]);
  const fly = useRef(null);
  const disc = useRef(null);
  const icons = useRef(new Map()); // level → its prize icon's view
  const onIcon = useCallback((lv, v) => {
    if (v) icons.current.set(lv, v);
    else icons.current.delete(lv);
  }, []);

  // One prize's coins or gems: out of its icon (the level disc when its row
  // is off screen) and up into their counter, which counts up as they land.
  const flyPrize = useCallback(
    async (lv, r, done) => {
      const gem = r.kind === 'gems';
      let from = await centerOf({ current: icons.current.get(lv) });
      if (!from || from.y < 90 || from.y > winH - 40) from = await centerOf(disc);
      flyReward({ layer: fly.current, from, purse: gem ? gemPurse.current : coinPurse.current, n: r.n, gem, img: gem ? GEM[lv % 6] : COIN[lv % 6], onDone: done });
    },
    [winH],
  );

  // Claims `levels` (more than one: everything waiting, in one server call).
  // The counters hold still meanwhile; then the coins and gems fly in (each
  // prize from its own icon, a little apart), and the chests drop in after.
  const [busy, setBusy] = useState(false);
  const busyRef = useRef(false);
  const claim = useCallback(
    async (levels) => {
      if (busyRef.current || !levels.length) return;
      busyRef.current = true;
      setBusy(true);
      holdPurses(wallet(profileRef.current));
      let got = [];
      try {
        const rs = levels.length > 1 ? (await squad.levelClaimAll()).results : [await squad.levelClaim(levels[0])];
        got = rs.map((r) => ({ lv: r.lv, r }));
      } catch (e) {
        flash(ERRORS[e.message] || 'Something went wrong. Try again!');
      }
      const money = got.filter((g) => g.r.kind === 'coins' || g.r.kind === 'gems');
      const chests = got.filter((g) => g.r.kind === 'chest').map((g) => g.r.chest);
      const finish = () => {
        busyRef.current = false;
        setBusy(false);
        if (chests.length) showChest(chests[0], chests.slice(1));
      };
      if (!money.length) {
        releasePurses();
        return finish();
      }
      sfx.play('coinShower');
      let left = money.length;
      money.forEach((g, k) =>
        setTimeout(
          () =>
            flyPrize(g.lv, g.r, () => {
              left -= 1;
              if (left) return;
              setWaitFor(got.map((x) => x.lv));
              setTimeout(finish, chests.length ? 300 : 0);
            }),
          k * 220,
        ),
      );
    },
    [flash, flyPrize, showChest, holdPurses, releasePurses],
  );
  // the LEVEL UP card's COLLECT: its levels, once the screen has slid in
  useEffect(() => {
    if (!autoClaim || !autoClaim.length) return undefined;
    const t = setTimeout(() => claim(autoClaim.filter((lv) => nodes[lv - 1]?.claimable)), 450);
    return () => clearTimeout(t);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);

  useEffect(() => {
    const sub = BackHandler.addEventListener('hardwareBackPress', () => {
      if (!smash && !drop) onBack();
      return true;
    });
    return () => sub.remove();
  }, [smash, drop, onBack]);

  // opens on the first prize waiting, else the next one to reach
  const startAt = useMemo(() => {
    const i = claimable.length ? claimable[0] - 1 : Math.min(nodes.length - 1, view.level);
    return Math.max(0, i - 1);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, []);
  const pct = Math.max(3, Math.min(100, Math.round((view.into / view.need) * 100)));
  const toNext = view.need - view.into;
  const renderCol = useCallback(
    ({ item }) => <Col n={item} last={item.lv === nodes.length} current={item.lv === view.level} group={group} busy={busy} toGo={item.lv === view.level + 1 ? toNext : 0} onClaim={claim} onIcon={onIcon} />,
    [nodes.length, view.level, group, busy, toNext, claim, onIcon],
  );
  const overlays = (
    <>
      {toast ? (
        <View pointerEvents="none" style={[styles.toastAt, { bottom: insets.bottom + 8 }]}>
          <Toast message={toast.text} messageKey={toast.key} />
        </View>
      ) : null}
      <FlyLayer ref={fly} />
      {/* the smash loads unseen under the treasure vault loading screen (the next ones under a chest dropping in) */}
      {smash && (
        <View style={[StyleSheet.absoluteFill, drop && !drop.reveal && styles.unseen]} pointerEvents={drop ? 'none' : 'auto'}>
          <ChestSmash chest={smash.chest} catalog={catalog} onCollect={collectSmash} onShown={smashShown} />
        </View>
      )}
      {smash && !vaultGone && <VaultLoader ready={!!smash.up} uri={buddy} onDone={vaultDone} />}
      {drop && <ChestDrop key={drop.key} group={drop.group} size={drop.size} onReveal={() => setDrop((d) => d && { ...d, reveal: true })} onDone={() => setDrop(null)} />}
    </>
  );
  // the title, your level and the counters across the top; the road runs left to right under them (drag it sideways),
  // CLAIM ALL below it
  return (
    <View style={styles.wRoot}>
      <WoodBg />
      <View style={styles.wTop}>
        <Orb icon="back" onPress={onBack} />
        <Lettering text="Level Road" variant="gold" size={26} />
        <Ringed ring="#6b4426" lip={4} colors={WOOD} radius={18} style={styles.wLevelRing} innerStyle={styles.wLevel}>
          <View ref={disc} collapsable={false}>
            <LinearGradient colors={GOLD} locations={[0, 0.5, 1]} style={styles.midDisc}>
              <Text style={styles.midNum} numberOfLines={1} adjustsFontSizeToFit>
                {view.level}
              </Text>
            </LinearGradient>
          </View>
          <View style={styles.topCol}>
            <View style={styles.bar}>
              <LinearGradient colors={BAR} start={{ x: 0, y: 0 }} end={{ x: 1, y: 0 }} style={[styles.barFill, { width: `${pct}%` }]} />
              <Text style={styles.barText}>{`${fmtNum(view.into)} / ${fmtNum(view.need)} XP`}</Text>
            </View>
            <Text style={styles.hint} numberOfLines={1}>Mini-games, challenges and squishing give XP</Text>
          </View>
        </Ringed>
        <View style={styles.purses}>
          <Purse ref={coinPurse} amount={w.coins} />
          <Purse ref={gemPurse} gem amount={w.gems} />
        </View>
      </View>
      <View style={styles.wMid}>
        <FlatList
          horizontal
          style={styles.wRoad}
          data={nodes}
          keyExtractor={(n) => String(n.lv)}
          renderItem={renderCol}
          extraData={busy}
          getItemLayout={(_, i) => ({ length: COL, offset: COL * i, index: i })}
          initialScrollIndex={startAt}
          initialNumToRender={8}
          maxToRenderPerBatch={4}
          windowSize={7}
          contentContainerStyle={styles.wRoadIn}
          showsHorizontalScrollIndicator={false}
          ListFooterComponent={<Text style={styles.foot}>{`The road ends at level ${nodes.length}. Every level after it still counts toward your trophies.`}</Text>}
        />
        {claimable.length > 1 ? (
          <CandyBtn kind={busy ? 'grey' : 'gold'} padV={8} padH={26} lip={5} onPress={() => claim(claimable)} disabled={busy} style={styles.wAll}>
            <BtnText ring={busy ? '#8a7a6a' : GOLD_RING} size={17}>
              {`CLAIM ALL (${claimable.length})`}
            </BtnText>
          </CandyBtn>
        ) : null}
      </View>
      {overlays}
    </View>
  );
}

// the wood look (src/royal/theme.js WOOD) and the XP bar's warm fill
const WOOD = ['#e6b47c', '#cf955a', '#b47a42'];
const BAR = ['#ffe08a', '#ffb347', '#f07a1c'];

const styles = StyleSheet.create({
  wRoot: { flex: 1, backgroundColor: '#24123f' },
  wTop: { flexDirection: 'row', alignItems: 'center', gap: 12, paddingHorizontal: 16, paddingTop: 10, paddingBottom: 4 },
  wLevelRing: { flex: 1, maxWidth: 300 },
  wLevel: { flexDirection: 'row', alignItems: 'center', gap: 10, paddingVertical: 6, paddingHorizontal: 10 },
  midDisc: { width: 44, height: 44, borderRadius: 22, alignItems: 'center', justifyContent: 'center', borderWidth: 2.5, borderColor: '#ffffff' },
  midNum: { fontFamily: F.display, fontSize: 21, color: '#7a3d00', includeFontPadding: false, paddingHorizontal: 3 },
  wMid: { flex: 1, justifyContent: 'center', gap: 12, paddingBottom: 8 },
  wRoad: { flexGrow: 0 },
  wAll: { alignSelf: 'center' },
  wRoadIn: { paddingHorizontal: 16, alignItems: 'flex-start' },
  col: { width: COL, alignItems: 'center', paddingTop: 4, gap: 8 },
  hRail: { position: 'absolute', top: 4 + 19 - 3, left: 0, right: 0, height: 6, backgroundColor: '#e2cfb4' },
  colCardRing: { width: COL - 12 },
  colCard: { alignItems: 'center', gap: 6, paddingTop: 10, paddingBottom: 10, paddingHorizontal: 6, height: 168 },
  colArt: { height: 56, alignItems: 'center', justifyContent: 'center' },
  colPrize: { fontFamily: F.display, fontSize: 15, lineHeight: 18, color: '#5b3418', textAlign: 'center', minHeight: 36, textAlignVertical: 'center' },
  lock: { width: 12, height: 13, alignItems: 'center' },
  lockShackle: { width: 6.6, height: 5.2, marginTop: 0.6, borderWidth: 1.7, borderBottomWidth: 0, borderColor: '#a88d70', borderTopLeftRadius: 3.3, borderTopRightRadius: 3.3 },
  lockBody: { width: 9.2, height: 6.5, borderRadius: 1.8, backgroundColor: '#a88d70' },
  purses: { marginLeft: 'auto', flexDirection: 'row', alignItems: 'center', gap: 6 },
  purse: { flexDirection: 'row', alignItems: 'center', gap: 5, paddingLeft: 7, paddingRight: 9, paddingVertical: 4 },
  coinImg: { width: 22, height: 22, marginVertical: -5, marginLeft: -4 },
  gemImg: { width: 24, height: 24, marginVertical: -6, marginLeft: -5 },
  purseText: { fontFamily: F.black, fontSize: 13.5, includeFontPadding: false },
  topCol: { flex: 1, gap: 5 },
  bar: { height: 22, borderRadius: 11, backgroundColor: 'rgba(63,36,18,0.45)', borderWidth: 2, borderColor: '#ffffff', overflow: 'hidden', justifyContent: 'center' },
  barFill: { position: 'absolute', left: 0, top: 0, bottom: 0, borderRadius: 9 },
  barText: { fontFamily: F.display, fontSize: 12, color: '#ffffff', textAlign: 'center', textShadowColor: '#3f2412', textShadowRadius: 3, textShadowOffset: { width: 0, height: 1 } },
  hint: { fontFamily: F.heavy, fontSize: 11, color: '#fff6e2' },
  railOn: { backgroundColor: '#ffc23a' },
  disc: { width: 38, height: 38, borderRadius: 19, alignItems: 'center', justifyContent: 'center', borderWidth: 2.5, borderColor: '#ffffff' },
  discNow: { width: 42, height: 42, borderRadius: 21, marginHorizontal: -2, borderColor: '#ff8a3d', borderWidth: 3 },
  discOff: { backgroundColor: '#f3e6d4' },
  discText: { fontFamily: F.display, fontSize: 15, color: '#7a3d00', includeFontPadding: false },
  prizeGot: { color: '#a88d70' },
  prizeOff: { color: '#8a7560' },
  lockTag: { flexDirection: 'row', alignItems: 'center', gap: 4, backgroundColor: '#f6ead8', borderRadius: 999, paddingHorizontal: 9, paddingVertical: 5 },
  lockText: { fontFamily: F.black, fontSize: 11, color: '#8a7560', includeFontPadding: false },
  foot: { width: 220, alignSelf: 'center', fontFamily: F.heavy, fontSize: 12, color: '#5b3418', textAlign: 'left', paddingHorizontal: 16 },
  unseen: { opacity: 0 },
  toastAt: { position: 'absolute', left: 0, right: 0, height: 80 },
});

// App re-renders while it's open (Home waking on the way back, the profile)
export default memo(LevelRoadScreen);
