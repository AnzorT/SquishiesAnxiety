import React, { memo } from 'react';
import { Pressable, ScrollView, StyleSheet, Text, View } from 'react-native';
import Svg, { Circle, Defs, Ellipse, Path, Pattern, Rect } from 'react-native-svg';
import { SvgXml } from 'react-native-svg';
import { LinearGradient } from 'expo-linear-gradient';
import CreatureThumbnail from '../components/CreatureThumbnail';
import TutTarget from '../tutorial/Target';
import { candyFonts } from '../theme/candyTheme';
import { ACTS, ACT_ORDER, FOODS, RATE, SEC_PER_HR, SLEEP, STATS, fmtMin, foodOf } from './data';
import { needOf, sleepGain, teleporting } from './model';
import { INK, PAPER, SOFT } from './ui';

// A creature's card, 1:1 the design's ("Squad Crib v5" / "Vertical": the
// card markup and cardVals): its picture, name and what it's doing, the red
// "Enough …" pill while it's busy, the three stats with their trend arrows,
// and six tiles to send it somewhere — or the sleep picker ("How long should
// they sleep?") and the snack picker ("What should they eat?"). The home
// decides how long the beds let them sleep (`sleepMax`), what the fridge
// holds (`fridge`) and how much a meal fills (`fill(food)`). `cols`: the
// snack grid's columns (the design: 4 in landscape, 5 in portrait).

const LIP = 3;

// a design button: a face with a 3 px ink lip under it that it presses into
function Lipped({ onPress, disabled, style, face, children, radius = 12, lip = LIP }) {
  return (
    <Pressable onPress={onPress} disabled={disabled} style={[{ paddingBottom: lip }, style]}>
      {({ pressed }) => (
        <>
          <View style={[StyleSheet.absoluteFill, { top: lip, borderRadius: radius, backgroundColor: INK }]} />
          <View style={[face, { borderRadius: radius, transform: [{ translateY: pressed ? lip - 1 : 0 }] }]}>{children}</View>
        </>
      )}
    </Pressable>
  );
}

// the tiles' icons (the design's isBath … isTv)
function ActIcon({ icon }) {
  return (
    <Svg width={18} height={18} viewBox="0 0 24 24">
      {icon === 'bath' ? (
        <>
          <Path d="M3 12h18v1.5a5.5 5.5 0 0 1-5.5 5.5h-7A5.5 5.5 0 0 1 3 13.5z" fill={INK} />
          <Path d="M6 12V6.5a2 2 0 0 1 4 0" stroke={INK} strokeWidth={2.2} fill="none" strokeLinecap="round" />
          <Circle cx={15} cy={7} r={2.2} fill="#5fb6dc" />
        </>
      ) : icon === 'food' ? (
        <>
          <Circle cx={12} cy={12} r={9} fill="#e7a95c" stroke={INK} strokeWidth={2} />
          <Circle cx={8.8} cy={9.8} r={1.6} fill={INK} />
          <Circle cx={14.6} cy={8.6} r={1.3} fill={INK} />
          <Circle cx={11} cy={15} r={1.5} fill={INK} />
        </>
      ) : icon === 'sleep' ? (
        <Path d="M15.5 3a8.8 8.8 0 1 0 6 14A7.2 7.2 0 0 1 15.5 3z" fill="#c9b6f0" stroke={INK} strokeWidth={2} strokeLinejoin="round" />
      ) : icon === 'music' ? (
        <>
          <Path d="M9 5.5l10-2.5v12.5" stroke={INK} strokeWidth={2.4} fill="none" strokeLinejoin="round" />
          <Path d="M9 5.5V18" stroke={INK} strokeWidth={2.4} />
          <Ellipse cx={6.5} cy={18.3} rx={3.4} ry={2.7} fill="#ff5c8a" stroke={INK} strokeWidth={1.5} />
          <Ellipse cx={16.5} cy={15.8} rx={3.4} ry={2.7} fill="#ff5c8a" stroke={INK} strokeWidth={1.5} />
        </>
      ) : icon === 'ball' ? (
        <>
          <Circle cx={12} cy={12} r={9} fill="#ffd66b" stroke={INK} strokeWidth={2} />
          <Path d="M3 12h18M12 3v18" stroke="#f2665a" strokeWidth={2.4} />
        </>
      ) : (
        <>
          <Rect x={2.5} y={6} width={19} height={13} rx={3} fill="#9fd8f0" stroke={INK} strokeWidth={2} />
          <Path d="M8 2.5l4 3.5 4-3.5" stroke={INK} strokeWidth={2} fill="none" strokeLinecap="round" />
        </>
      )}
    </Svg>
  );
}

function StatRow({ stat, value, rate }) {
  const v = Math.round(value);
  const up = rate > 0.05;
  const down = rate < -0.3;
  return (
    <View style={styles.stat}>
      <Text style={styles.statLabel}>{stat.label}</Text>
      <View style={[styles.bar, { backgroundColor: stat.light }]}>
        <View style={[styles.barFill, { width: `${v}%`, backgroundColor: stat.color }]} />
      </View>
      <Text style={styles.statPct}>{`${v}%`}</Text>
      <Text style={[styles.trend, { color: up ? '#4f9a3a' : '#e0503f' }]}>{up ? '▲' : down ? '▼' : ''}</Text>
    </View>
  );
}

function statusOf(pet, now) {
  const A = ACTS[pet.act];
  if (teleporting(pet, now)) return 'Teleporting…';
  if (pet.act === 'sleep' && pet.sleepEnd) return `Sleeping · ${fmtMin(Math.max(0, Math.ceil(((pet.sleepEnd - now) / 1000) * (60 / SEC_PER_HR))))} left`;
  if (pet.act === 'dance' || pet.act === 'yard') return `${A.verb} · until hungry`;
  if (pet.act === 'eat') {
    const M = pet.meal;
    if (!M) return 'At the table · pick a snack';
    return now < M.t0 + M.ms ? `Eating ${foodOf(M.k).name.toLowerCase()} · ${Math.ceil((M.t0 + M.ms - now) / 1000)}s left` : 'Finished eating · yum!';
  }
  if (pet.act === 'bath' && pet.stats.clean >= 100) return `${A.verb} · all done, tap Enough`;
  return A.verb;
}

function Actions({ pet, now, roomFull, onAct, host }) {
  const need = needOf(pet);
  const moving = teleporting(pet, now);
  return (
    <View style={styles.actions}>
      {ACT_ORDER.map((k) => {
        const a = ACTS[k];
        const here = pet.act === k;
        const full = !here && roomFull(k);
        const rec = !here && !!need && STATS.find((s) => s.k === need).fix === k;
        const hint = here ? (k === 'eat' ? (pet.meal ? 'eating' : 'pick food') : 'here now') : full ? 'room full' : a.hint;
        const tile = (
          <Lipped onPress={() => onAct(k)} disabled={full || moving} style={{ opacity: full ? 0.45 : 1 }} face={[styles.act, { backgroundColor: here || rec ? a.light : '#ffffff', borderColor: here ? a.color : INK }]}>
            <ActIcon icon={a.icon} />
            <Text style={styles.actLabel}>{a.label}</Text>
            <Text style={styles.actHint}>{hint}</Text>
          </Lipped>
        );
        return (
          <View key={k} style={styles.actWrap}>
            {k === 'eat' ? (
              <TutTarget name="act-eat" host={host}>
                {tile}
              </TutTarget>
            ) : (
              tile
            )}
            {rec ? (
              <View pointerEvents="none" style={styles.rec}>
                <Text style={styles.recText}>!</Text>
              </View>
            ) : null}
          </View>
        );
      })}
    </View>
  );
}

// a picker's title, with a back button in front of it: a pill with an arrow
// (the design's underlined "Back" text didn't read as a button)
function PickHead({ title, onBack }) {
  return (
    <View style={styles.pickHead}>
      <Lipped onPress={onBack} radius={999} face={styles.back}>
        <Svg width={12} height={12} viewBox="0 0 24 24">
          <Path d="M15 4 L7 12 L15 20" stroke={INK} strokeWidth={4} fill="none" strokeLinecap="round" strokeLinejoin="round" />
        </Svg>
        <Text style={styles.backText}>Back</Text>
      </Lipped>
      <Text style={styles.pickTitle}>{title}</Text>
    </View>
  );
}

// the gain on the energy bar: yellow stripes
function GainStripes({ w, h }) {
  return (
    <Svg width={w} height={h}>
      <Defs>
        <Pattern id="g" width={10} height={10} patternUnits="userSpaceOnUse" patternTransform="rotate(45)">
          <Rect width={5} height={10} fill="#ffd66b" />
          <Rect x={5} width={5} height={10} fill="#fff3c4" />
        </Pattern>
      </Defs>
      <Rect width={w} height={h} fill="url(#g)" />
    </Svg>
  );
}

function SleepPicker({ pet, sleepH, sleepMax: max, onSleepH, onTuck, onBack }) {
  const SH = Math.min(sleepH, SLEEP[Math.max(0, max - 1)]);
  const e = Math.round(pet.stats.energy);
  const gain = sleepGain(pet.stats.energy, SH);
  return (
    <View style={styles.pick}>
      <PickHead title="How long should they sleep?" onBack={onBack} />
      <View style={styles.chips}>
        {SLEEP.map((h, k) => {
          const ok = k < max;
          return (
            <Pressable key={h} onPress={() => ok && onSleepH(h)} style={[styles.chip, { backgroundColor: ok && SH === h ? '#c9b6f0' : '#ffffff', opacity: ok ? 1 : 0.35 }]}>
              <Text style={styles.chipText}>{h < 1 ? '30m' : `${h}h`}</Text>
            </Pressable>
          );
        })}
      </View>
      <View style={styles.gainRow}>
        <Svg width={18} height={20} viewBox="0 0 20 24">
          <Path d="M12 1 L3 14 H9 L7 23 L17 9 H11 Z" fill="#ffd66b" stroke={INK} strokeWidth={2} strokeLinejoin="round" />
        </Svg>
        <Text style={styles.gainBig}>{`+${gain}`}</Text>
        <Text style={styles.gainLabel}>{`energy · ${e}% → ${Math.min(100, e + gain)}%`}</Text>
      </View>
      <View style={[styles.bar, styles.gainBar]}>
        <View style={{ width: `${e}%`, backgroundColor: '#f2b84a' }} />
        <View style={{ width: `${gain}%`, overflow: 'hidden' }}>
          <GainStripes w={400} h={12} />
        </View>
      </View>
      <Text style={styles.note}>{`Wakes up on their own after ${fmtMin(SH * 60)} (${SH * SEC_PER_HR}s of squishy time)${max < SLEEP.length ? ' · better beds unlock longer sleep' : ''}`}</Text>
      <Lipped onPress={onTuck} radius={999} face={[styles.tuck]}>
        <Text style={styles.tuckText}>Tuck in</Text>
      </Lipped>
    </View>
  );
}

function FeedPicker({ pet, coins, pantry, fridge, fill, cols, onFeed, onBack, onPantry }) {
  const foods = FOODS.filter((f) => fridge.includes(f.k));
  const more = FOODS.length - foods.length;
  return (
    <View style={styles.pick}>
      <PickHead title="What should they eat?" onBack={onBack} />
      <Text style={styles.note}>{`Tummy ${Math.round(pet.stats.tummy)}% · green = in your pantry, yellow = coin price`}</Text>
      <View style={styles.foods}>
        {foods.map((f) => {
          const n = pantry[f.k] || 0;
          const can = n > 0 || coins >= f.price;
          return (
            <View key={f.k} style={{ width: `${100 / cols}%`, paddingHorizontal: 3, paddingTop: 8 }}>
              <Lipped onPress={() => onFeed(f.k)} disabled={!can} style={{ opacity: can ? 1 : 0.45 }} face={styles.food}>
                <SvgXml xml={f.svg} width={24} height={24} />
                <Text style={styles.foodName} numberOfLines={1}>
                  {f.name.split(' ')[0]}
                </Text>
                <Text style={styles.foodFill}>{`+${fill(f)}`}</Text>
              </Lipped>
              <View pointerEvents="none" style={[styles.tag, { backgroundColor: n > 0 ? '#c9e8a8' : '#ffd66b' }]}>
                <Text style={styles.tagText}>{n > 0 ? `×${n}` : `${f.price}`}</Text>
              </View>
            </View>
          );
        })}
      </View>
      {more > 0 ? <Text style={[styles.note, { textAlign: 'center' }]}>{`Upgrade your fridge to unlock ${more} more foods`}</Text> : null}
      {onPantry ? (
        <Lipped onPress={onPantry} radius={999} face={styles.buyFood}>
          <ActIcon icon="food" />
          <Text style={styles.buyFoodText}>Buy food for the pantry</Text>
        </Lipped>
      ) : null}
    </View>
  );
}

function CribCard({ pet, creature, now, coins, pantry, mode, sleepH, sleepMax, fridge, fill, cols = 4, onSleepH, onMode, onAct, onStop, onClose, onFeed, onPantry, roomFull, host, style }) {
  if (!pet || !creature) return null;
  const A = ACTS[pet.act];
  const R = RATE[pet.act];
  const canStop = pet.act !== 'home' && !teleporting(pet, now);
  return (
    <View style={[styles.wrap, style]}>
      <View style={styles.lip} />
      <View style={styles.card}>
        <ScrollView showsVerticalScrollIndicator={false} contentContainerStyle={styles.inner} bounces={false}>
          <View style={styles.head}>
            <LinearGradient colors={['#f6d7a8', '#ffe6b8']} start={{ x: 0.5, y: 0 }} end={{ x: 0.5, y: 0.7 }} style={styles.avatar}>
              <CreatureThumbnail creature={creature} size={44} animate={false} />
            </LinearGradient>
            <View style={{ flex: 1, minWidth: 0 }}>
              <Text style={styles.name} numberOfLines={1}>
                {creature.name}
              </Text>
              <Text style={styles.status} numberOfLines={2}>
                {statusOf(pet, now)}
              </Text>
            </View>
            <Pressable onPress={onClose} hitSlop={8} style={({ pressed }) => [styles.close, pressed && { opacity: 0.7 }]}>
              <Text style={styles.closeText}>✕</Text>
            </Pressable>
          </View>
          {canStop && mode === 'main' ? (
            <Lipped onPress={onStop} radius={999} face={styles.stop}>
              <Text style={styles.stopText}>{A.stop}</Text>
            </Lipped>
          ) : null}
          {mode === 'sleep' ? (
            <SleepPicker pet={pet} sleepH={sleepH} sleepMax={sleepMax} onSleepH={onSleepH} onTuck={() => onAct('tuck')} onBack={() => onMode('main')} />
          ) : mode === 'feed' ? (
            <FeedPicker pet={pet} coins={coins} pantry={pantry} fridge={fridge} fill={fill} cols={cols} onFeed={onFeed} onBack={() => onMode('main')} onPantry={onPantry} />
          ) : (
            <>
              <View style={{ gap: 5 }}>
                {STATS.map((s) => (
                  <StatRow key={s.k} stat={s} value={pet.stats[s.k]} rate={s.k === 'energy' && pet.act === 'sleep' ? pet.sleepRate : R[s.k]} />
                ))}
              </View>
              <Actions pet={pet} now={now} roomFull={roomFull} onAct={onAct} host={host} />
            </>
          )}
        </ScrollView>
      </View>
    </View>
  );
}

export default memo(CribCard);

const styles = StyleSheet.create({
  wrap: { paddingBottom: 5 },
  lip: { ...StyleSheet.absoluteFillObject, top: 5, borderRadius: 22, backgroundColor: INK },
  card: { flex: 1, backgroundColor: PAPER, borderRadius: 22, borderWidth: 3, borderColor: INK, overflow: 'hidden', shadowColor: '#3c1e0a', shadowOpacity: 0.35, shadowRadius: 15, shadowOffset: { width: 0, height: 14 }, elevation: 10 },
  inner: { paddingTop: 10, paddingHorizontal: 12, paddingBottom: 12, gap: 8 },
  head: { flexDirection: 'row', alignItems: 'center', gap: 10 },
  avatar: { width: 50, height: 50, borderRadius: 25, borderWidth: 2.5, borderColor: INK, alignItems: 'center', justifyContent: 'center', overflow: 'hidden' },
  name: { fontFamily: candyFonts.display, fontSize: 19, lineHeight: 22, color: INK },
  status: { fontFamily: candyFonts.bodyHeavy, fontSize: 11, color: SOFT },
  close: { width: 30, height: 30, borderRadius: 15, borderWidth: 2.5, borderColor: INK, backgroundColor: '#fff6e6', alignItems: 'center', justifyContent: 'center' },
  closeText: { fontFamily: candyFonts.bodyBlack, fontSize: 13, color: INK, includeFontPadding: false },
  stop: { height: 30, borderWidth: 2.5, borderColor: INK, backgroundColor: '#f2665a', alignItems: 'center', justifyContent: 'center' },
  stopText: { fontFamily: candyFonts.display, fontSize: 13, color: '#ffffff' },
  stat: { flexDirection: 'row', alignItems: 'center', gap: 7 },
  statLabel: { width: 50, fontFamily: candyFonts.bodyBlack, fontSize: 11, color: INK },
  bar: { flex: 1, height: 12, borderRadius: 7, borderWidth: 2, borderColor: INK, overflow: 'hidden' },
  barFill: { position: 'absolute', left: 0, top: 0, bottom: 0 },
  statPct: { width: 32, textAlign: 'right', fontFamily: candyFonts.bodyBlack, fontSize: 11, color: INK },
  trend: { width: 12, fontFamily: candyFonts.bodyBlack, fontSize: 10 },
  actions: { flexDirection: 'row', flexWrap: 'wrap', marginHorizontal: -3, rowGap: 7, marginTop: 2 },
  actWrap: { width: '33.333%', paddingHorizontal: 3 },
  act: { height: 50, padding: 2, borderWidth: 2.5, alignItems: 'center', justifyContent: 'center' },
  actLabel: { fontFamily: candyFonts.display, fontSize: 12, lineHeight: 14, color: INK },
  actHint: { fontFamily: candyFonts.bodyHeavy, fontSize: 9, lineHeight: 10, color: SOFT },
  rec: { position: 'absolute', right: -3, top: -7, width: 16, height: 16, borderRadius: 8, backgroundColor: '#f2665a', borderWidth: 2, borderColor: INK, alignItems: 'center', justifyContent: 'center' },
  recText: { fontFamily: candyFonts.bodyBlack, fontSize: 10, lineHeight: 12, color: '#ffffff', includeFontPadding: false },
  pick: { gap: 7 },
  pickHead: { flexDirection: 'row', alignItems: 'center', gap: 10 },
  pickTitle: { fontFamily: candyFonts.display, fontSize: 14, color: INK, flexShrink: 1 },
  back: { height: 30, flexDirection: 'row', alignItems: 'center', gap: 3, paddingLeft: 9, paddingRight: 12, borderWidth: 2.5, borderColor: INK, backgroundColor: '#fff6e6' },
  backText: { fontFamily: candyFonts.display, fontSize: 13, color: INK, includeFontPadding: false },
  buyFood: { height: 30, flexDirection: 'row', alignItems: 'center', justifyContent: 'center', gap: 6, borderWidth: 2.5, borderColor: INK, backgroundColor: '#ffd66b' },
  buyFoodText: { fontFamily: candyFonts.display, fontSize: 13, color: INK },
  chips: { flexDirection: 'row', gap: 5 },
  chip: { flex: 1, height: 28, borderRadius: 9, borderWidth: 2.5, borderColor: INK, alignItems: 'center', justifyContent: 'center' },
  chipText: { fontFamily: candyFonts.display, fontSize: 12, color: INK },
  gainRow: { flexDirection: 'row', alignItems: 'center', gap: 6 },
  gainBig: { fontFamily: candyFonts.display, fontSize: 20, color: '#c98a00' },
  gainLabel: { fontFamily: candyFonts.bodyHeavy, fontSize: 11, color: SOFT },
  gainBar: { flex: 0, flexDirection: 'row', backgroundColor: '#ffefc2' },
  note: { fontFamily: candyFonts.bodyHeavy, fontSize: 10, color: SOFT },
  tuck: { height: 34, borderWidth: 2.5, borderColor: INK, backgroundColor: '#c9b6f0', alignItems: 'center', justifyContent: 'center' },
  tuckText: { fontFamily: candyFonts.display, fontSize: 14, color: INK },
  foods: { flexDirection: 'row', flexWrap: 'wrap', marginHorizontal: -3 },
  food: { height: 58, paddingTop: 3, paddingHorizontal: 2, paddingBottom: 2, borderWidth: 2.5, borderColor: INK, backgroundColor: '#ffffff', alignItems: 'center', justifyContent: 'center', gap: 1 },
  foodName: { fontFamily: candyFonts.display, fontSize: 10, lineHeight: 11, color: INK, maxWidth: '100%' },
  foodFill: { fontFamily: candyFonts.bodyBlack, fontSize: 9, lineHeight: 10, color: '#d9483e' },
  tag: { position: 'absolute', right: -3, top: 1, minWidth: 18, height: 16, paddingHorizontal: 4, borderRadius: 8, borderWidth: 2, borderColor: INK, alignItems: 'center', justifyContent: 'center' },
  tagText: { fontFamily: candyFonts.bodyBlack, fontSize: 9, lineHeight: 11, color: INK, includeFontPadding: false },
});
