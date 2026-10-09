import React, { memo, useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { Animated, Easing, Pressable, ScrollView, StyleSheet, Text, View, useWindowDimensions } from 'react-native';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { LinearGradient } from 'expo-linear-gradient';
import Svg, { Circle, Path } from 'react-native-svg';
import CandyBackground from '../components/candy/CandyBackground';
import RoundButton, { DailyIcon, GearIcon, HouseIcon, StatsIcon, TrashIcon, TrophyIcon } from '../components/candy/RoundButton';
import OutlinedTitle from '../components/candy/OutlinedTitle';
import ShadowText, { outline3 } from '../components/candy/ShadowText';
import { RaysSpin } from '../components/candy/Decor';
import CreatureThumbnail from '../components/CreatureThumbnail';
import { CustomArt } from '../components/CustomCards';
import HomeMenu, { MENU_BUTTON } from '../components/HomeMenu';
import { Flame } from '../components/StreakIcons';
import TutTarget from '../tutorial/Target';
import { measureTarget, report as tutReport, useTutorialSelect } from '../tutorial/store';
import sfx from '../audio/sfx';
import { BY_ID, FIN, RAR_LOOK, ROSTER, SEASON, SETS, SET_BONUS, SET_OF, STAGE_FX, STAGE_NAMES, creaturePrice, entry, growInfo, owns, setInfo, wallet } from '../squad/data';
import * as squad from '../squad/api';
import MOVES from '../squad/moves';
import { todayKey } from '../dailySpin';
import { BtnText, CandyBtn, F, PINK_RING, Ringed } from '../squad/ui';
import { Purse, Title } from './ShopScreen';
import { Bone, Reveal, useAfterFirstFrame } from '../components/Skeleton';
import { fmtNum } from '../format';
import useInstantTab from '../components/useInstantTab';

// The main screen's Squishies tab (the 2026-10-06 design's "Squishies Tab
// v2", inside the app shell's MainScreen): the SQUAD header (LV, the Crib,
// trophies, settings, and the menu for daily challenges, streak and stats),
// the purses, and the collection, split into the game's Squishies (how many
// collected, the season, and every set with its members, growth pips,
// finish diamond and set reward) and My creations (Create your own squishy,
// then each creature the player made: play, retry, delete).
// Tapping a squishy opens its sheet: growth (Baby → Grown → Best Friend,
// from squish XP alone), finishes (preview, wear; they only drop in
// chests), SQUISH, or how to get it. Every change goes to the server
// (src/squad/api.js). The Star Shop tab went with Stars (2026-10-09).
const SET_LOOK = {
  snack: { name: 'Snack Shack', vibe: 'Street-food buddies', tint: '#fff0e2', lip: '#f2c7a0', ink: '#c4651f', perk: 'Unlocks the Snack Shack kitchen theme' },
  fruit: { name: 'Fruit Patch', vibe: 'Juicy and bright', tint: '#fff6d6', lip: '#ecd078', ink: '#b88a00', perk: 'Unlocks a fruit-stand furniture set' },
  ocean: { name: 'Ocean Pals', vibe: 'Splashy and squishy', tint: '#e4f3ff', lip: '#a9d2f2', ink: '#2f7fd6', perk: 'Unlocks the aquarium wall' },
  pet: { name: 'Pet Shop', vibe: 'Furry best friends', tint: '#ffe9f6', lip: '#f0a8d8', ink: '#c0268f', perk: 'Unlocks the pet bed set' },
  forest: { name: 'Forest Friends', vibe: 'Cozy woodland', tint: '#e2fbef', lip: '#98dcbc', ink: '#16a86a', perk: 'Unlocks the forest room theme' },
  sky: { name: 'Sky & Stars', vibe: 'Dreamy night sky', tint: '#ece6ff', lip: '#c3b0f2', ink: '#5a3ad0', perk: 'Unlocks the starry ceiling' },
  dream: { name: 'Dreamland', vibe: 'Fantasy and magic', tint: '#f6e3ff', lip: '#d9a8f0', ink: '#9a2fc8', perk: 'Unlocks the castle bed' },
  bakery: { name: 'Sweet Bakery', vibe: 'Fresh from the oven', tint: '#fff0e6', lip: '#f2b8a0', ink: '#c2502a', perk: 'Unlocks the bakery kitchen' },
};
// finish swatches and rings (the design's FINSW / FINRING)
const FIN_SW = { n: ['#ffe3f4', '#e6d3ff'], s: ['#ffffff', '#cbeaff', '#a9c8ff'], r: ['#ffb3c7', '#ffe38a', '#b3f5c8', '#b3e0ff', '#dcc2ff'], g: ['#fff3b0', '#ffc233', '#f0a000'] };
const FIN_RING = { n: '#d6b8ee', s: '#9fc4ee', r: '#cdb0f2', g: '#d9a020' };
const FIN_NAME = { n: 'Normal', s: 'Shiny', r: 'Rainbow', g: 'Golden' };
const fmt = fmtNum;

// How a squishy looks in its finish: Rainbow and Golden are the
// thumbnail's own holo / gold washes, Shiny a pale sheen.
const finProps = (f) => (f === 'r' ? { wash: 'holo' } : f === 'g' ? { wash: 'gold' } : f === 's' ? { tint: ['#ffffff', 0.28] } : {});

function Crown({ size }) {
  return (
    <Svg viewBox="0 0 48 36" width={size} height={size * 0.75}>
      <Path d="M7 32 L4 10 L16 19 L24 4 L32 19 L44 10 L41 32 Z" fill="#ffd23a" stroke="#ffffff" strokeWidth={3} strokeLinejoin="round" />
      <Circle cx={24} cy={24} r={3.6} fill="#ff5cc6" />
    </Svg>
  );
}

// A squishy at its growth stage (smaller and rounder as a Baby, crowned as
// a Best Friend) in its finish.
const Squishy = memo(function Squishy({ creature, size, stage = 1, f = 'n', mood = 'idle', animate = false, locked = false }) {
  const fx = STAGE_FX[stage] || STAGE_FX[1];
  return (
    <View style={{ width: size, height: size }}>
      <View style={{ transform: [{ translateY: size * 0.42 * (1 - fx.sy) }, { scaleX: fx.sx }, { scaleY: fx.sy }] }}>
        <CreatureThumbnail creature={creature} size={size} mood={mood} animate={animate} locked={locked} {...(locked ? {} : finProps(f))} />
      </View>
      {fx.crown && !locked && (
        <View style={{ position: 'absolute', left: size * 0.48, top: -size * 0.04, transform: [{ rotate: '13deg' }] }}>
          <Crown size={size * 0.3} />
        </View>
      )}
    </View>
  );
});

function Egg({ size = 40, colors = ['#efe4fb', '#cdb8ec'] }) {
  return (
    <LinearGradient colors={colors} style={{ width: size, height: size * 0.9, borderRadius: size / 2, borderWidth: 2.5, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center' }}>
      <Text style={{ fontFamily: F.display, fontSize: size * 0.4, color: '#ffffff' }}>?</Text>
    </LinearGradient>
  );
}

// The Collection while its cells are still being built (Home's first frame):
// two set cards of placeholder cells.
function CollectionBones() {
  return (
    <View style={{ gap: 12 }}>
      {[0, 1].map((k) => (
        <View key={k} style={[styles.setCard, { backgroundColor: '#ffffff', borderBottomColor: '#e3d4f5' }]}>
          <View style={styles.setHead}>
            <View style={{ flex: 1, gap: 6 }}>
              <Bone w="45%" h={16} r={8} />
              <Bone w="65%" h={9} r={5} />
            </View>
            <Bone w={52} h={24} r={12} />
          </View>
          <Bone h={7} r={4} />
          <View style={styles.grid4}>
            {[0, 1, 2, 3, 4, 5, 6, 7].map((i) => (
              <View key={i} style={styles.cellSlot}>
                <Bone h={88} r={16} />
              </View>
            ))}
          </View>
        </View>
      ))}
    </View>
  );
}

// One squishy in a set's grid.
// A tutorial target (`card:<id>`), in `refs` so the screen can scroll to it
// A cell's look from the profile: owned, growth stage, equipped finish.
function cellLook(profile, id) {
  const mine = owns(profile || {}, id);
  const e = mine ? entry(profile, id) : null;
  return { mine, st: (e && e.st) || 0, eq: (e && e.eq) || 'n' };
}

// It takes only what it shows (owned, stage, finish), not the whole profile:
// with the profile, any profile change (coins from the Crib, a daily tick)
// re-rendered all 72 cells, which took about 1.4 s in a debug build on
// coming back to Home.
const Cell = memo(function Cell({ id, mine, st, eq, creature, onOpen, refs }) {
  const c = BY_ID[id];
  const R = RAR_LOOK[c.rar];
  return (
    <TutTarget name={`card:${id}`} style={styles.cellSlot}>
      <View ref={(r) => (refs.current[id] = r)} collapsable={false}>
        <Pressable style={[styles.cell, { backgroundColor: mine ? R.card : '#f1ebf7', borderBottomColor: mine ? R.lip : '#ddd0ea' }]} onPress={() => onOpen(id)}>
          <View style={[styles.cellDot, { backgroundColor: R.dot }]} />
          {mine && eq !== 'n' && (
            <LinearGradient colors={FIN_SW[eq]} style={[styles.finDiamond, { borderColor: '#ffffff' }]} />
          )}
          <View style={{ width: 54, height: 54, alignItems: 'center', justifyContent: 'center', opacity: mine ? 1 : 0.6 }}>
            {creature ? <Squishy creature={creature} size={54} stage={mine ? st : 1} f={eq} locked={!mine} /> : <Egg />}
          </View>
          {st === 2 ? (
            <LinearGradient colors={['#ffd75e', '#f0a000']} style={styles.bfName}>
              <Text style={[styles.cellName, { color: '#ffffff' }]} numberOfLines={1}>
                {c.name}
              </Text>
            </LinearGradient>
          ) : (
            <Text style={[styles.cellName, { color: mine ? '#4a1a73' : '#8a78a0' }]} numberOfLines={1}>
              {c.name}
            </Text>
          )}
          {mine ? (
            <View style={styles.pips}>
              {[0, 1, 2].map((i) => (
                <View key={i} style={[styles.pip, { backgroundColor: i <= st ? (st === 2 ? '#ffc233' : '#ff5cc6') : '#ffffff', borderColor: i <= st ? (st === 2 ? '#c47a00' : '#c02bd9') : '#d6c4ef' }]} />
              ))}
            </View>
          ) : (
            <Text style={[styles.rarLabel, { color: R.ink }]}>{R.label}</Text>
          )}
        </Pressable>
      </View>
    </TutTarget>
  );
});

// --- Collection tab --------------------------------------------------------------

const CollectionTab = memo(function CollectionTab({ profile, catalog, artIds, onOpen, onSeasonChest, now, refs }) {
  const base = ROSTER.filter((c) => c.base || c.reward);
  const have = base.filter((c) => owns(profile || {}, c.id)).length;
  const col = profile?.col || {};
  const fins = Object.values(col).reduce((n, e) => n + Object.keys(e.f || {}).filter((k) => k !== 'n').length, 0);
  const bfs = Object.values(col).filter((e) => e.st === 2).length;
  const setsDone = SETS.filter((k) => setInfo(profile, k).done).length;
  const seasonOn = artIds.some((id) => BY_ID[id].season);
  const seasonIds = ROSTER.filter((c) => c.season).map((c) => c.id);
  return (
    <View style={{ gap: 14 }}>
      <View style={styles.summary}>
        <View style={styles.rowBase}>
          <Text style={styles.colHave}>{have}</Text>
          <Text style={styles.colTotal}>/ {base.length} collected</Text>
        </View>
        <View style={styles.colBar}>
          <LinearGradient colors={['#ffd6f4', '#ff5cc6', '#c02bd9']} style={{ width: `${(have / base.length) * 100}%`, height: '100%', borderRadius: 999 }} />
        </View>
        <Text style={styles.colNote}>
          {fins} {fins === 1 ? 'finish' : 'finishes'} · {bfs} Best {bfs === 1 ? 'Friend' : 'Friends'} · {setsDone} of {SETS.length} sets complete
        </Text>
      </View>

      {seasonOn && (
        <Ringed ring="#7a2a00" lip={6} radius={24} colors={['#4a1a73', '#8f3cf2', '#ff8a3d']} innerStyle={styles.season}>
          <View style={styles.rowCenter}>
            <View style={styles.seasonChip}>
              <Text style={styles.seasonChipText}>SEASON 1 · LIMITED</Text>
            </View>
            <View style={[styles.seasonChip, { backgroundColor: '#7a2a00', marginLeft: 'auto' }]}>
              <Text style={[styles.seasonChipText, { color: '#ffffff' }]}>Leaves in {Math.max(0, Math.ceil((new Date(2026, 9, 31, 23, 59) - now) / 864e5))} days</Text>
            </View>
          </View>
          <View style={styles.rowBase}>
            <ShadowText style={styles.seasonName} shadows={[[0, 2.5, '#4a1a73'], [2, 0, '#4a1a73'], [-2, 0, '#4a1a73'], [0, -2, '#4a1a73']]}>
              {SEASON.name}
            </ShadowText>
            <Text style={styles.seasonCount}>
              {seasonIds.filter((id) => owns(profile || {}, id)).length} / {seasonIds.length}
            </Text>
          </View>
          <View style={styles.row4}>
            {seasonIds.map((id) => (
              <Pressable key={id} style={styles.seasonCell} onPress={() => onOpen(id)}>
                {catalog[id] ? <Squishy creature={catalog[id]} size={36} locked={!owns(profile || {}, id)} /> : <Egg size={24} colors={['#f6d9c2', '#e0a070']} />}
                <View style={[styles.cellDot, { top: 3, left: 3, width: 7, height: 7, backgroundColor: RAR_LOOK[BY_ID[id].rar].dot }]} />
              </Pressable>
            ))}
          </View>
          <CandyBtn kind="gold" onPress={onSeasonChest} style={{ alignSelf: 'flex-start' }}>
            <BtnText size={14}>SEASON CHEST</BtnText>
          </CandyBtn>
        </Ringed>
      )}

      {SETS.map((key) => {
        const L = SET_LOOK[key];
        const info = setInfo(profile, key);
        const rw = BY_ID[info.reward];
        const rwMine = owns(profile || {}, rw.id);
        const left = info.total - info.have;
        return (
          <View key={key} style={[styles.setCard, { backgroundColor: L.tint, borderBottomColor: L.lip }]}>
            <View style={styles.setHead}>
              <View style={{ flex: 1 }}>
                <Text style={[styles.setName, { color: L.ink }]}>{L.name}</Text>
                <Text style={styles.setVibe}>{L.vibe}</Text>
              </View>
              <View style={[styles.setCount, { backgroundColor: L.ink, borderBottomColor: L.lip }]}>
                <Text style={styles.setCountText}>
                  {info.have} / {info.total}
                </Text>
              </View>
            </View>
            <View style={styles.setBar}>
              <View style={{ width: `${(info.have / info.total) * 100}%`, height: '100%', borderRadius: 999, backgroundColor: L.ink }} />
            </View>
            <View style={styles.grid4}>
              {[...SET_OF[key].ids]
                .sort((a, b) => BY_ID[a].rar - BY_ID[b].rar || a - b)
                .map((id) => (
                  <Cell key={id} id={id} {...cellLook(profile, id)} creature={catalog[id]} onOpen={onOpen} refs={refs} />
                ))}
            </View>
            <Pressable style={[styles.reward, { borderBottomColor: L.lip }]} onPress={() => onOpen(rw.id)}>
              <View style={[styles.rewardArt, { backgroundColor: rwMine ? RAR_LOOK[4].card : '#f1ebf7' }]}>
                {catalog[rw.id] ? <Squishy creature={catalog[rw.id]} size={42} locked={!rwMine} /> : <Egg size={32} colors={['#ffe0f3', '#f0a8d8']} />}
              </View>
              <View style={{ flex: 1, gap: 1 }}>
                <View style={styles.rewardChip}>
                  <Text style={styles.rewardChipText}>SET REWARD</Text>
                </View>
                <Text style={styles.rewardName}>{rw.name}</Text>
                <Text style={styles.rewardNote}>
                  Collect all {info.total} for +{fmt(SET_BONUS)} coins. {L.perk}.
                </Text>
              </View>
              <View style={[styles.rewardPill, rwMine ? { backgroundColor: '#16a86a' } : { backgroundColor: '#ffffff', borderColor: '#f2c98f' }]}>
                <Text style={[styles.rewardPillText, { color: rwMine ? '#ffffff' : '#c46a00' }]}>{rwMine ? 'UNLOCKED' : `${left} TO GO`}</Text>
              </View>
            </Pressable>
          </View>
        );
      })}
      <Text style={styles.foot}>Squish a squishy to earn XP and grow it. Duplicates turn into coins.</Text>
    </View>
  );
});

// --- My creations ------------------------------------------------------------------

// A creature the player made: its picture (or assembled body), name and
// state; PLAY when it's ready, RETRY when the build failed, and delete.
const MineRow = memo(function MineRow({ custom, onPlay, onDelete, onRetry }) {
  const status = custom.status || 'ready';
  const busy = status === 'pending' || status === 'running';
  const failed = status === 'failed' || status === 'capacity' || status === 'blocked';
  const meta = busy ? `Building in 3D · ${Math.round(custom.progress || 0)}%` : failed ? custom.error || 'Couldn’t build it' : `Made ${custom.created}${custom.audio ? ' · own squish sound' : ''}`;
  return (
    <Pressable style={styles.mineRow} onPress={busy || failed ? undefined : () => onPlay(custom)}>
      <View style={styles.mineArt}>
        <CustomArt creature={custom} size={58} busy={busy} dim={busy || failed} />
      </View>
      <View style={{ flex: 1, gap: 2 }}>
        <Text style={styles.mineName} numberOfLines={1}>
          {custom.name}
        </Text>
        <Text style={[styles.mineMeta, failed && { color: '#d0345a' }]} numberOfLines={1}>
          {meta}
        </Text>
      </View>
      <RoundButton size={30} lip={3} onPress={() => onDelete(custom)} hitSlop={8}>
        <TrashIcon />
      </RoundButton>
      {busy ? (
        <CandyBtn kind="grey" padH={10}>
          <BtnText ring="#7a6a8c" size={13}>
            WAIT…
          </BtnText>
        </CandyBtn>
      ) : failed ? (
        <CandyBtn kind="gold" padH={10} onPress={() => onRetry(custom)}>
          <BtnText size={13}>RETRY ↻</BtnText>
        </CandyBtn>
      ) : (
        <CandyBtn kind="cyan" padH={10} onPress={() => onPlay(custom)}>
          <BtnText ring="#0c5a9c" size={13}>
            PLAY ▶
          </BtnText>
        </CandyBtn>
      )}
    </Pressable>
  );
});

const MineTab = memo(function MineTab({ customs, onCreate, createPrice, credits, discountPct, onPlay, onDelete, onRetry }) {
  return (
    <View style={{ gap: 10 }}>
      <TutTarget name="createCard">
        <Pressable onPress={onCreate} style={({ pressed }) => pressed && { transform: [{ translateY: 3 }] }}>
          <Ringed ring="#a23ad8" lip={5} radius={22} colors={['#fff6fd', '#ffdcf4', '#f5cbff']} innerStyle={styles.create}>
            <LinearGradient colors={['#ffb8e4', '#c78bff']} start={{ x: 0, y: 0 }} end={{ x: 1, y: 1 }} style={styles.createPlus}>
              <View style={styles.plusH} />
              <View style={styles.plusV} />
            </LinearGradient>
            <View style={{ flex: 1, gap: 2 }}>
              <Text style={styles.createTitle}>Create your own squishy</Text>
              <Text style={styles.createNote}>Upload or draw a picture, add a squish sound, and we turn it into 3D.</Text>
              <View style={styles.createPrice}>
                <Text style={styles.createPriceText}>{credits > 0 ? `${credits} FREE` : createPrice}</Text>
                <Text style={styles.createPer}>{credits > 0 ? (credits === 1 ? 'CREATION LEFT' : 'CREATIONS LEFT') : 'PER CREATURE'}</Text>
                {credits === 0 && discountPct > 0 && <Text style={styles.createOff}>−{discountPct}%</Text>}
              </View>
            </View>
          </Ringed>
        </Pressable>
      </TutTarget>
      {customs.length ? (
        customs.map((c) => <MineRow key={c.id} custom={c} onPlay={onPlay} onDelete={onDelete} onRetry={onRetry} />)
      ) : (
        <Text style={styles.foot}>Nothing here yet. Turn a photo or a drawing into your very own squishy!</Text>
      )}
    </View>
  );
});

// Collection's split: the game's squishies | the player's own creations
const SUBS = [
  ['game', 'Squishies'],
  ['mine', 'My creations'],
];
function SubSeg({ sub: current, onSub, onPick, mineCount }) {
  // the tapped side lights up at once; onSub follows
  const [sub, press] = useInstantTab(current, onSub);
  return (
    <View style={styles.subTrack}>
      {SUBS.map(([k, label]) => {
        const on = sub === k;
        const text = k === 'mine' && mineCount ? `${label} · ${mineCount}` : label;
        return (
          <Pressable
            key={k}
            style={{ flex: 1 }}
            onPress={() => {
              if (onPick) onPick(k);
              press(k);
            }}
          >
            {on ? (
              <Ringed ring={PINK_RING} lip={3} ringW={2} border={2.5} colors={['#ffd6f4', '#ff5cc6', '#c02bd9']} innerStyle={styles.subOn}>
                <BtnText size={14}>{text}</BtnText>
              </Ringed>
            ) : (
              <View style={styles.subOff}>
                <Text style={styles.subOffText}>{text}</Text>
              </View>
            )}
          </Pressable>
        );
      })}
    </View>
  );
}

// The design's "LV 3" pill: gold, white rim, outlined text.
function LevelPill({ level }) {
  return (
    <View style={styles.lvRing}>
      <LinearGradient colors={['#fffbd6', '#ffe045', '#ff9500']} locations={[0, 0.45, 1]} style={styles.lvFace}>
        <ShadowText style={styles.lvText} shadows={outline3('#a04a00')}>{`LV ${level}`}</ShadowText>
      </LinearGradient>
    </View>
  );
}

const HEADER_BUTTON = 40;

// --- the squishy sheet ---------------------------------------------------------------

function SquishySheet({ id, profile, catalog, artIds, day, onClose, onPlay, onGrow, onFinish, onBuy, onShop }) {
  const up = useRef(new Animated.Value(0)).current;
  const [preview, setPreview] = useState(null);
  useEffect(() => {
    up.setValue(0);
    setPreview(null);
    Animated.spring(up, { toValue: 1, friction: 8, tension: 80, useNativeDriver: true }).start();
  }, [id, up]);
  const c = BY_ID[id];
  const R = RAR_LOOK[c.rar];
  const L = SET_LOOK[c.set] || { name: SEASON.name, tint: '#ffe6cc', lip: '#e0a070', ink: '#7a2a00' };
  const mine = owns(profile || {}, id);
  const e = mine ? entry(profile, id) : null;
  const art = artIds.includes(id);
  const creature = catalog[id];
  const g = mine ? growInfo(profile, id) : null;
  const eq = e?.eq || 'n';
  const show = preview || eq;
  const info = MOVES[Number(id)] || [];
  const coinP = c.base ? creaturePrice(profile || {}, id, artIds, day) : null;

  let lock = '';
  let lockBtn = '';
  if (!mine) {
    if (!art) lock = `${c.name} is still being hatched. It joins the chests and the Shop soon.`;
    else if (c.pass) lock = 'Season Pass exclusive. Coming with the Spooky Squish pass.';
    else if (c.season) {
      lock = `Only in the ${SEASON.name} Season Chest.`;
      lockBtn = 'GET SEASON CHEST';
    } else if (c.reward) {
      const inf = setInfo(profile, c.set);
      lock = `Set reward. Collect all ${inf.total} ${L.name} squishies to unlock it (${inf.have} / ${inf.total}).`;
    } else if (!coinP) {
      lock = 'Legendaries only come from Gold, Crystal and Rainbow chests.';
      lockBtn = 'GET CHESTS';
    }
  }

  return (
    <View style={StyleSheet.absoluteFill}>
      <Pressable style={styles.scrim} onPress={onClose} />
      <Animated.View style={[styles.sheet, { transform: [{ translateY: up.interpolate({ inputRange: [0, 1], outputRange: [700, 0] }) }] }]}>
        <ScrollView style={styles.sheetScroll} contentContainerStyle={styles.sheetBody} showsVerticalScrollIndicator={false}>
          <View style={styles.grip} />
          <View style={styles.pvArt}>
            <View style={[styles.pvGlow, { backgroundColor: R.dot }]} />
            {creature ? <Squishy creature={creature} size={140} stage={mine ? e.st : 1} f={show} mood={mine ? 'dance' : 'idle'} animate locked={!mine} /> : <Egg size={90} />}
          </View>
          <View style={styles.rowWrap}>
            <Text style={[styles.pvName, { color: mine && e.st === 2 ? '#c47a00' : PINK_RING }]}>{c.name}</Text>
            <View style={[styles.pill, { backgroundColor: R.bg }]}>
              <Text style={styles.pillText}>{R.label}</Text>
            </View>
          </View>
          <View style={styles.rowWrap}>
            <View style={[styles.pill, { backgroundColor: L.tint, borderColor: '#ffffff' }]}>
              <Text style={[styles.pillText, { color: L.ink, letterSpacing: 0 }]}>{L.name}</Text>
            </View>
            {mine && (
              <View style={[styles.pill, { backgroundColor: e.st === 2 ? '#f0a000' : e.st === 1 ? '#16a86a' : '#ff5cc6' }]}>
                <Text style={[styles.pillText, { color: '#ffffff' }]}>{STAGE_NAMES[e.st].toUpperCase()}</Text>
              </View>
            )}
          </View>
          {!!info[2] && <Text style={styles.concept}>{info[2]}.</Text>}
          {!!info[3] && (
            <Text style={styles.soundMove}>
              ♪ {info[3]} · {info[0]}
            </Text>
          )}

          {mine && g && (
            <View style={styles.box}>
              <View style={styles.boxHead}>
                <Text style={styles.boxTitle}>GROWTH</Text>
                <Text style={styles.boxNote}>{g.max ? 'Fully grown' : `XP ${Math.min(g.xp, g.needXp)} / ${g.needXp}`}</Text>
              </View>
              <View style={styles.row6}>
                {[0, 1, 2].map((s) => {
                  const now = s === e.st;
                  const done = s <= e.st;
                  const ring = s === 2 ? '#d9a020' : '#c02bd9';
                  return (
                    <View key={s} style={{ flex: 1, alignItems: 'center', gap: 5 }}>
                      <View style={[styles.stageBox, { backgroundColor: done ? (s === 2 ? '#fff3c4' : '#ffe9f6') : '#f6f0fb', borderColor: now ? ring : '#ffffff' }]}>
                        {creature && <Squishy creature={creature} size={60} stage={s} f={eq} locked={!done} />}
                        {now && (
                          <View style={[styles.nowTag, { backgroundColor: ring }]}>
                            <Text style={styles.nowText}>NOW</Text>
                          </View>
                        )}
                      </View>
                      <Text style={[styles.stageLabel, { color: done ? '#4a1a73' : '#a07cc0' }]}>{STAGE_NAMES[s]}</Text>
                    </View>
                  );
                })}
              </View>
              {!g.max && (
                <>
                  <View style={styles.xpBar}>
                    <LinearGradient colors={['#ffb3e0', '#c02bd9']} start={{ x: 0, y: 0 }} end={{ x: 1, y: 0 }} style={{ width: `${Math.min(100, (g.xp / g.needXp) * 100)}%`, height: '100%', borderRadius: 999 }} />
                  </View>
                  <CandyBtn kind={g.xpOk ? 'purple' : 'grey'} padV={8} stretch onPress={() => (g.xpOk ? onGrow(id) : onPlay(id))}>
                    <BtnText ring={g.xpOk ? '#45189a' : '#7a6a8c'} size={15}>
                      {g.xpOk ? `GROW TO ${g.next.toUpperCase()}` : `SQUISH TO EARN ${g.needXp - g.xp} XP`}
                    </BtnText>
                  </CandyBtn>
                </>
              )}
              {g.max && <Text style={styles.maxed}>Best Friend: gold name badge, a crown and a new dance in the reveal show.</Text>}
            </View>
          )}

          <View style={styles.box}>
            <View style={styles.boxHead}>
              <Text style={styles.boxTitle}>FINISHES</Text>
              <Text style={styles.boxNote}>{mine ? (preview && preview !== eq ? `Previewing ${FIN_NAME[preview]}` : 'Tap to preview') : 'Finishes drop in chests'}</Text>
            </View>
            <View style={styles.row6}>
              {['n', 's', 'r', 'g'].map((k) => {
                const F2 = FIN[k];
                const own = !!e?.f?.[k];
                const sel = show === k;
                const state = own ? (eq === k ? 'WEARING' : 'OWNED') : k === 'n' ? 'BASE' : `${F2.odds}%`;
                return (
                  <Pressable
                    key={k}
                    style={[styles.finCard, { backgroundColor: sel ? '#fff0fb' : '#ffffff', borderColor: sel ? '#ff5cc6' : '#efe4f7' }]}
                    onPress={() => {
                      if (!mine) return;
                      if (own && eq !== k) onFinish(id, k);
                      setPreview(k);
                    }}
                  >
                    <LinearGradient colors={FIN_SW[k]} start={{ x: 0, y: 0 }} end={{ x: 1, y: 1 }} style={[styles.finSw, { shadowColor: FIN_RING[k] }]} />
                    <Text style={styles.finName}>{FIN_NAME[k]}</Text>
                    <Text style={[styles.finState, { color: own ? (eq === k ? '#d3179a' : '#16a86a') : '#a07cc0' }]}>{state}</Text>
                  </Pressable>
                );
              })}
            </View>
            {mine && !!preview && !e.f[preview] && <Text style={styles.boxNote}>{FIN_NAME[preview]} only drops in chests.</Text>}
          </View>

          {!!lock && (
            <View style={styles.lock}>
              <Text style={styles.lockText}>{lock}</Text>
              {!!lockBtn && (
                <CandyBtn kind="pink" padV={7} padH={16} onPress={onShop}>
                  <BtnText ring={PINK_RING} size={14}>
                    {lockBtn}
                  </BtnText>
                </CandyBtn>
              )}
            </View>
          )}
        </ScrollView>
        {/* the sheet's actions stay in view under the scrolling part: at the
            end of the scroll, SQUISH sat below the sheet's visible bottom
            (under the ad strip), where the tutorial pointed at it */}
        {(mine || (art && c.base && !!coinP)) && (
          <View style={styles.sheetFoot}>
            {mine && (
              <TutTarget name="sheetPlay" style={{ alignSelf: 'stretch' }}>
                <CandyBtn kind="cyan" padV={12} lip={5} stretch onPress={() => onPlay(id)}>
                  <BtnText ring="#0c5a9c" size={18}>
                    SQUISH ▶
                  </BtnText>
                </CandyBtn>
              </TutTarget>
            )}
            {!mine && art && c.base && !!coinP && (
              <CandyBtn kind="gold" padV={11} lip={5} stretch onPress={() => onBuy(id)}>
                <BtnText size={17}>{`BUY ★ ${fmt(coinP)}`}</BtnText>
              </CandyBtn>
            )}
          </View>
        )}
      </Animated.View>
    </View>
  );
}

// --- growing up ------------------------------------------------------------------------

function GrowFx({ id, to, creature, f, onClose }) {
  const [done, setDone] = useState(false);
  const pop = useRef(new Animated.Value(0)).current;
  const wob = useRef(new Animated.Value(0)).current;
  useEffect(() => {
    const loop = Animated.loop(Animated.sequence([Animated.timing(wob, { toValue: 1, duration: 140, useNativeDriver: true }), Animated.timing(wob, { toValue: -1, duration: 140, useNativeDriver: true })]));
    loop.start();
    const t = setTimeout(() => {
      loop.stop();
      wob.setValue(0);
      setDone(true);
      sfx.play('achievement');
      Animated.spring(pop, { toValue: 1, friction: 5, useNativeDriver: true }).start();
    }, 1400);
    return () => {
      clearTimeout(t);
      loop.stop();
    };
  }, [pop, wob]);
  const name = BY_ID[id].name;
  const bf = to === 2;
  return (
    <View style={[StyleSheet.absoluteFill, styles.grow]}>
      <LinearGradient colors={['#fff3fb', '#e9b8ff', '#8f3cf2', '#45107a']} locations={[0, 0.3, 0.7, 1]} style={StyleSheet.absoluteFill} />
      <RaysSpin size={640} durationMs={16000} rayDeg={9} gapDeg={13} opacity={done ? 0.3 : 0.12} style={{ position: 'absolute', top: '38%', marginTop: -320 }} />
      <Animated.View style={{ transform: [{ rotate: wob.interpolate({ inputRange: [-1, 1], outputRange: ['-4deg', '4deg'] }) }, { scale: pop.interpolate({ inputRange: [0, 1], outputRange: [1, 1.08] }) }] }}>
        <Squishy creature={creature} size={220} stage={done ? to : to - 1} f={f} mood={done ? 'happy' : 'idle'} animate />
      </Animated.View>
      {!done ? (
        <ShadowText style={styles.growWait} shadows={outline3('#45107a', 2)}>
          {`Growing ${name}…`}
        </ShadowText>
      ) : (
        <Animated.View style={{ alignItems: 'center', gap: 10, opacity: pop, transform: [{ scale: pop.interpolate({ inputRange: [0, 1], outputRange: [0.6, 1] }) }] }}>
          <View style={[styles.pill, { backgroundColor: bf ? '#ffd23a' : '#c9f7e1', paddingHorizontal: 12 }]}>
            <Text style={[styles.pillText, { fontSize: 12 }]}>{STAGE_NAMES[to].toUpperCase()}</Text>
          </View>
          <ShadowText style={styles.growTitle} shadows={[[0, 3, '#45107a'], [2, 0, '#45107a'], [-2, 0, '#45107a'], [0, -2, '#45107a']]}>
            {bf ? `${name} is your Best Friend!` : `${name} grew up!`}
          </ShadowText>
          <Text style={styles.growPerk}>{bf ? 'Gold crown and a new dance in the reveal show.' : 'Full size and extra bouncy. Keep squishing to reach Best Friend.'}</Text>
          <CandyBtn kind="pink" padV={10} padH={40} lip={5} onPress={onClose}>
            <BtnText ring={PINK_RING} size={18}>
              YAY!
            </BtnText>
          </CandyBtn>
        </Animated.View>
      )}
    </View>
  );
}

// --- the screen ----------------------------------------------------------------------

function SquishiesScreen({
  active = true,
  profile,
  creatures,
  onPlay,
  onOpenShop,
  onOpenCreator,
  createPrice,
  generationCredits = 0,
  paidCredits = 0,
  discountPct = 0,
  customCreatures = [],
  onSelectCustom,
  onDeleteCustom,
  onRetryCustom,
  // { id, token }: a creature just made — open My creations
  focusMine = null,
  onFocusMineDone = () => {},
  // the header: LV, the Crib (from level 2), trophies, settings, and the
  // menu (daily challenges and streak from level 3, stats)
  level = 1,
  cribUnlocked = false,
  onOpenCrib,
  onOpenAchievements,
  onOpenSettings,
  onOpenStats,
  dailyUnlocked = false,
  dailyBadge = 0,
  onOpenDaily,
  streak = 0,
  streakHot = false,
  onOpenStreak,
}) {
  const insets = useSafeAreaInsets();
  const [sub, setSub] = useState('game');
  const [open, setOpen] = useState(null);
  const [grow, setGrow] = useState(null);
  const [toast, setToast] = useState(null);
  const [busy, setBusy] = useState(false);
  const scroll = useRef(null);
  // the lists are built a couple of frames after the screen (placeholders
  // until then), so its first frame is up at once
  const built = useAfterFirstFrame();
  // read again each time the screen comes back (App keeps it alive under
  // other screens), so a new day shows without a remount
  const now = useMemo(() => new Date(), [active]); // eslint-disable-line react-hooks/exhaustive-deps
  const day = todayKey(now);
  const w = useMemo(() => wallet(profile), [profile]);
  const catalog = useMemo(() => Object.fromEntries((creatures || []).map((c) => [c.id, c])), [creatures]);
  const artIds = useMemo(() => Object.keys(catalog).filter((id) => BY_ID[id]), [catalog]);

  const flash = useCallback((text) => setToast({ text, key: Date.now() }), []);
  useEffect(() => {
    if (!toast) return undefined;
    const t = setTimeout(() => setToast(null), 2200);
    return () => clearTimeout(t);
  }, [toast]);

  const run = useCallback(
    async (fn) => {
      if (busy) return null;
      setBusy(true);
      try {
        return await fn();
      } catch (e) {
        const msg = { not_enough_coins: 'Not enough coins', need_xp: 'Squish it more to earn XP first', owned: 'Already yours' }[e.message];
        flash(msg || 'Something went wrong. Try again!');
        return null;
      } finally {
        setBusy(false);
      }
    },
    [busy, flash],
  );

  const doGrow = useCallback(
    async (id) => {
      const g = growInfo(profile, id);
      if (!g || g.max) return;
      if (!g.xpOk) return flash(`Squish ${BY_ID[id].name} ${g.needXp - g.xp} more times first`);
      const r = await run(() => squad.growCreature(id));
      if (r) {
        setOpen(null);
        setGrow({ id, to: r.st, f: entry(profile, id)?.eq || 'n' });
      }
    },
    [profile, run, flash],
  );
  // wearing a finish the squishy has (finishes only drop in chests)
  const doFinish = useCallback(
    async (id, f) => {
      const e = entry(profile, id);
      if (!e) return;
      if (!e.f[f]) return flash('That finish only drops from chests');
      if (e.eq !== f) await run(() => squad.equipFinish(id, f));
    },
    [profile, run, flash],
  );
  const doBuy = useCallback(
    async (id) => {
      const r = await run(() => squad.buyCreature(id));
      if (r) {
        sfx.play('unlock');
        flash(r.reward ? `Set complete! ${BY_ID[r.reward].name} joined too` : `${BY_ID[id].name} joined your squad!`);
      }
    },
    [run, flash],
  );
  const play = useCallback(
    (id) => {
      setOpen(null);
      if (catalog[id]) onPlay(catalog[id]);
    },
    [catalog, onPlay],
  );

  // the menu button's spot (HomeMenu draws it over everything, in window
  // coordinates; the header keeps room for it)
  const [menuAnchor, setMenuAnchor] = useState(null);
  const onMenuSlot = useCallback(
    (e) => {
      const { y } = e.nativeEvent.layout;
      setMenuAnchor((a) => (a && a.top === insets.top + y ? a : { top: insets.top + y, right: 14 }));
    },
    [insets.top],
  );
  const menuItems = useMemo(() => {
    const list = [];
    if (dailyUnlocked) {
      list.push({ key: 'daily', label: 'DAILY CHALLENGES', variant: 'gold', icon: <DailyIcon />, onPress: onOpenDaily, badge: dailyBadge, tut: 'daily' });
      list.push({ key: 'streak', label: 'DAILY STREAK', variant: 'flame', icon: <Flame size={18} />, onPress: onOpenStreak, badge: streak, badgeGold: true, hot: streakHot });
    }
    list.push({ key: 'stats', label: 'STATS', icon: <StatsIcon size={22} />, onPress: onOpenStats });
    // Settings lives in this menu (2026-10-09 ruling), not in the header
    list.push({ key: 'settings', label: 'SETTINGS', icon: <GearIcon size={21} />, onPress: onOpenSettings });
    return list;
  }, [dailyUnlocked, dailyBadge, streak, streakHot, onOpenDaily, onOpenStreak, onOpenStats, onOpenSettings]);

  // My creations' own scroll (see the Squishies | My creations pages below)
  const mineScroll = useRef(null);
  const openSeasonChest = useCallback(() => onOpenShop('chests'), [onOpenShop]);

  // Squishies and My creations are two pages side by side, and switching
  // slides between them (to My creations: out left / in right). Both stay
  // built, so a switch is only the slide (native, started on the tap's own
  // frame); rebuilding a page took about 1.5 s on the emulator. Each page
  // keeps its own scroll.
  const { width: pageW } = useWindowDimensions();
  const subX = useRef(new Animated.Value(0)).current;
  const subAt = useRef(0);
  const slideSub = useCallback(
    (k) => {
      const to = k === 'mine' ? 1 : 0;
      if (subAt.current === to) return;
      subAt.current = to;
      Animated.timing(subX, { toValue: to, duration: 360, easing: Easing.bezier(0.22, 1, 0.36, 1), useNativeDriver: true }).start();
    },
    [subX],
  );
  useEffect(() => slideSub(sub), [sub, slideSub]);
  // My creations is built in the background a moment after Squishies
  const [mineWarm, setMineWarm] = useState(false);
  useEffect(() => {
    if (!built || mineWarm) return undefined;
    const t = setTimeout(() => setMineWarm(true), 1200);
    return () => clearTimeout(t);
  }, [built, mineWarm]);
  const mineOn = mineWarm || sub === 'mine';
  const subShift = subX.interpolate({ inputRange: [0, 1], outputRange: [0, -pageW] });
  const pickSub = useCallback((k) => setSub(k), []);
  // the tap itself: the sound and the slide at once (pickSub follows)
  const onPickSub = useCallback(
    (k) => {
      if (k === sub) return;
      sfx.play('swipe');
      slideSub(k);
    },
    [sub, slideSub],
  );
  // Back from CREATE with a new creature: My creations, at the top.
  useEffect(() => {
    if (!focusMine) return;
    setSub('mine');
    mineScroll.current?.scrollTo({ y: 0, animated: false });
    onFocusMineDone();
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [focusMine]);

  // The tutorial: which list is up, which squishy's sheet is open, and —
  // when its guide points at a squishy's cell — that cell scrolled into view
  // (then measured again where it landed).
  useEffect(() => tutReport({ listTab: sub === 'mine' ? 'mine' : 'ours' }), [sub]);
  useEffect(() => tutReport({ squadSheet: open == null ? null : String(open) }), [open]);
  useEffect(() => () => tutReport({ squadSheet: null }), []);
  const cellRefs = useRef({});
  const box = useRef(null);
  const offY = useRef(0);
  // only the guide's target on Home (re-rendering on every tutorial change
  // rebuilt this whole screen many times a second)
  const target = useTutorialSelect((s) => (s.screen === 'home' && s.ui && typeof s.ui.target === 'string' ? s.ui.target : null));
  const want = target && target.startsWith('card:') ? target : null;
  // My creations' switch and Create card sit at the top of Collection
  const wantTop = target === 'tabs' || target === 'createCard';
  useEffect(() => {
    if (!wantTop) return undefined;
    setOpen(null);
    if (target === 'createCard') mineScroll.current?.scrollTo({ y: 0, animated: true });
    const t = setTimeout(() => measureTarget(target), 500);
    return () => clearTimeout(t);
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [wantTop, target]);
  useEffect(() => {
    if (!want || !built) return undefined;
    setSub('game');
    const t = setTimeout(() => {
      const cell = cellRefs.current[want.slice(5)];
      if (!cell || !box.current) return;
      cell.measureInWindow((x, y, w, h) =>
        box.current?.measureInWindow((bx, by, bw, bh) => {
          if (y >= by + 8 && y + h <= by + bh - 8) return;
          scroll.current?.scrollTo({ y: Math.max(0, offY.current + y - by - (bh - h) / 2), animated: true });
          setTimeout(() => measureTarget(want), 500);
        }),
      );
    }, 400);
    return () => clearTimeout(t);
  }, [want, built]);

  return (
    <CandyBackground style={{ paddingTop: insets.top }}>
      <View style={styles.header}>
        <OutlinedTitle text="SQUAD" fill="pink" size={25} outline={3} ring={2} drop={5} />
        <LevelPill level={level} />
        <View style={styles.headerIcons} onLayout={onMenuSlot}>
          {cribUnlocked ? (
            <TutTarget name="crib">
              <RoundButton size={HEADER_BUTTON} variant="green" onPress={onOpenCrib}>
                <HouseIcon />
              </RoundButton>
            </TutTarget>
          ) : null}
          <RoundButton size={HEADER_BUTTON} onPress={onOpenAchievements}>
            <TrophyIcon size={22} />
          </RoundButton>
          <View style={styles.menuSlot} />
        </View>
      </View>
      <View style={styles.purses}>
        <Purse cur="coins" amount={w.coins} plus={false} onPress={() => onOpenShop('gems')} />
        <Purse cur="gems" amount={w.gems} plus={false} onPress={() => onOpenShop('gems')} />
      </View>
      <TutTarget name="tabs" style={styles.subBar}>
        <SubSeg sub={sub} onSub={pickSub} onPick={onPickSub} mineCount={customCreatures.length} />
      </TutTarget>
      <View ref={box} collapsable={false} style={styles.pager}>
        <Animated.View style={[styles.pageTrack, { width: pageW * 2, transform: [{ translateX: subShift }] }]}>
          <ScrollView
            ref={scroll}
            style={{ width: pageW }}
            contentContainerStyle={styles.pageBody}
            showsVerticalScrollIndicator={false}
            onScroll={(e) => (offY.current = e.nativeEvent.contentOffset.y)}
            scrollEventThrottle={32}
          >
            <Reveal ready={built} placeholder={<CollectionBones />}>
              <CollectionTab profile={profile} catalog={catalog} artIds={artIds} onOpen={setOpen} onSeasonChest={openSeasonChest} now={now} refs={cellRefs} />
            </Reveal>
          </ScrollView>
          <ScrollView ref={mineScroll} style={{ width: pageW }} contentContainerStyle={styles.pageBody} showsVerticalScrollIndicator={false}>
            <Reveal ready={mineOn} placeholder={<CollectionBones />}>
              <MineTab
                customs={customCreatures}
                onCreate={onOpenCreator}
                createPrice={createPrice}
                credits={generationCredits + paidCredits}
                discountPct={discountPct}
                onPlay={onSelectCustom}
                onDelete={onDeleteCustom}
                onRetry={onRetryCustom}
              />
            </Reveal>
          </ScrollView>
        </Animated.View>
      </View>
      {/* under the sheets */}
      <HomeMenu items={menuItems} anchor={menuAnchor} badge={dailyBadge} hot={streakHot} />
      {open != null && (
        <SquishySheet
          id={open}
          profile={profile}
          catalog={catalog}
          artIds={artIds}
          day={day}
          onClose={() => setOpen(null)}
          onPlay={play}
          onGrow={doGrow}
          onFinish={doFinish}
          onBuy={doBuy}
          onShop={() => {
            setOpen(null);
            onOpenShop('chests');
          }}
        />
      )}
      {grow && <GrowFx id={grow.id} to={grow.to} f={grow.f} creature={catalog[grow.id]} onClose={() => setGrow(null)} />}
      {toast && (
        <View style={[styles.toastWrap, { bottom: 40 }]} pointerEvents="none">
          <Ringed ring={PINK_RING} lip={4} border={0} innerStyle={styles.toast}>
            <Text style={styles.toastText}>{toast.text}</Text>
          </Ringed>
        </View>
      )}
    </CandyBackground>
  );
}

const card = { borderWidth: 3, borderColor: '#ffffff' };
const styles = StyleSheet.create({
  header: { flexDirection: 'row', alignItems: 'center', gap: 8, paddingHorizontal: 14, paddingTop: 10, paddingBottom: 8 },
  headerIcons: { flexDirection: 'row', alignItems: 'center', gap: 6, marginLeft: 'auto' },
  menuSlot: { width: MENU_BUTTON, height: MENU_BUTTON + 4 },
  lvRing: { borderRadius: 999, backgroundColor: '#a04a00', padding: 1.5 },
  lvFace: { borderRadius: 999, borderWidth: 2, borderColor: '#ffffff', paddingHorizontal: 8, paddingVertical: 2 },
  lvText: { fontFamily: F.display, fontSize: 12, color: '#ffffff', includeFontPadding: false },
  subTrack: { flexDirection: 'row', alignItems: 'center', gap: 4, padding: 3, borderRadius: 999, backgroundColor: 'rgba(255,255,255,0.55)', borderWidth: 2, borderColor: '#ffffff' },
  subOn: { paddingVertical: 5, alignItems: 'center', justifyContent: 'center' },
  subOff: { paddingVertical: 8, alignItems: 'center', justifyContent: 'center' },
  subOffText: { fontFamily: F.display, fontSize: 14, color: '#6b3fa0' },
  mineRow: { flexDirection: 'row', alignItems: 'center', gap: 8, borderRadius: 20, backgroundColor: '#ffffff', ...card, borderBottomWidth: 5, borderBottomColor: '#e2a9d6', padding: 8 },
  mineArt: { width: 62, height: 62, borderRadius: 16, backgroundColor: '#ffe9f8', alignItems: 'center', justifyContent: 'center', overflow: 'hidden' },
  mineName: { fontFamily: F.display, fontSize: 16, lineHeight: 19, color: '#4a1a73' },
  mineMeta: { fontFamily: F.bold, fontSize: 11, lineHeight: 14, color: '#9467bd' },
  createOff: { fontFamily: F.black, fontSize: 10, color: '#ffffff', backgroundColor: '#ff3d7f', borderRadius: 999, paddingHorizontal: 6, overflow: 'hidden' },
  cellSlot: { width: '23.4%' },
  // Squishies | My creations, side by side (see slideSub)
  pager: { flex: 1, overflow: 'hidden' },
  pageTrack: { flex: 1, flexDirection: 'row' },
  pageBody: { paddingHorizontal: 14, paddingTop: 2, paddingBottom: 22 },
  // the Squishies | My creations switch, fixed over its two pages
  subBar: { paddingHorizontal: 14, paddingTop: 2, paddingBottom: 10 },
  purses: { flexDirection: 'row', gap: 6, paddingHorizontal: 14, paddingBottom: 10 },
  rowCenter: { flexDirection: 'row', alignItems: 'center', gap: 6 },
  rowBase: { flexDirection: 'row', alignItems: 'baseline', gap: 6 },
  rowWrap: { flexDirection: 'row', alignItems: 'center', gap: 6, flexWrap: 'wrap', justifyContent: 'center' },
  row4: { flexDirection: 'row', gap: 4 },
  row6: { flexDirection: 'row', gap: 6 },
  summary: { gap: 6, borderRadius: 22, backgroundColor: '#ffffff', ...card, borderBottomWidth: 6, borderBottomColor: '#e2a9d6', paddingHorizontal: 14, paddingTop: 10, paddingBottom: 11 },
  colHave: { fontFamily: F.display, fontSize: 28, lineHeight: 30, color: PINK_RING },
  colTotal: { fontFamily: F.black, fontSize: 13, color: '#a07cc0' },
  colBar: { height: 10, borderRadius: 999, backgroundColor: '#f3e4fb', overflow: 'hidden' },
  colNote: { fontFamily: F.heavy, fontSize: 11, color: '#8a5aa8' },
  create: { flexDirection: 'row', alignItems: 'center', gap: 12, paddingHorizontal: 12, paddingVertical: 10 },
  createPlus: { width: 46, height: 46, borderRadius: 23, alignItems: 'center', justifyContent: 'center' },
  plusH: { position: 'absolute', width: 24, height: 4, borderRadius: 2, backgroundColor: '#ffffff' },
  plusV: { position: 'absolute', width: 4, height: 24, borderRadius: 2, backgroundColor: '#ffffff' },
  createTitle: { fontFamily: F.display, fontSize: 16, lineHeight: 19, color: '#4a1a73' },
  createNote: { fontFamily: F.bold, fontSize: 11, lineHeight: 14, color: '#9467bd' },
  createPrice: { alignSelf: 'flex-start', marginTop: 3, flexDirection: 'row', alignItems: 'center', gap: 6, backgroundColor: '#fff5fb', borderWidth: 1.5, borderColor: '#ffcd3c', borderRadius: 999, paddingHorizontal: 10, paddingVertical: 3 },
  createPriceText: { fontFamily: F.display, fontSize: 14, color: '#c25e00' },
  createPer: { fontFamily: F.black, fontSize: 8.5, letterSpacing: 1.2, color: '#6b3fa0' },
  season: { gap: 8, paddingHorizontal: 10, paddingTop: 10, paddingBottom: 12 },
  seasonChip: { backgroundColor: '#ffd23a', borderWidth: 2, borderColor: '#ffffff', borderRadius: 999, paddingHorizontal: 8, paddingVertical: 1 },
  seasonChipText: { fontFamily: F.black, fontSize: 9.5, letterSpacing: 1, color: '#4a1a73' },
  seasonName: { fontFamily: F.display, fontSize: 22, color: '#ffffff' },
  seasonCount: { fontFamily: F.black, fontSize: 11, color: '#ffe9c4' },
  seasonCell: { flex: 1, aspectRatio: 1, borderRadius: 12, backgroundColor: 'rgba(255,255,255,0.85)', borderWidth: 2, borderColor: '#ffffff', alignItems: 'center', justifyContent: 'center' },
  setCard: { gap: 8, borderRadius: 24, ...card, borderBottomWidth: 8, padding: 10 },
  setHead: { flexDirection: 'row', alignItems: 'center', gap: 8, paddingHorizontal: 2 },
  setName: { fontFamily: F.display, fontSize: 18, lineHeight: 20 },
  setVibe: { fontFamily: F.heavy, fontSize: 10.5, color: '#8a6aa6' },
  setCount: { borderWidth: 2.5, borderColor: '#ffffff', borderBottomWidth: 4, borderRadius: 999, paddingHorizontal: 10, paddingVertical: 1 },
  setCountText: { fontFamily: F.display, fontSize: 14, color: '#ffffff' },
  setBar: { height: 7, marginHorizontal: 2, borderRadius: 999, backgroundColor: '#ffffff', overflow: 'hidden' },
  grid4: { flexDirection: 'row', flexWrap: 'wrap', gap: 6 },
  cell: { borderRadius: 16, borderWidth: 2.5, borderColor: '#ffffff', borderBottomWidth: 5, alignItems: 'center', gap: 2, paddingHorizontal: 2, paddingTop: 5, paddingBottom: 6 },
  cellDot: { position: 'absolute', top: 4, left: 4, width: 8, height: 8, borderRadius: 4, borderWidth: 1.5, borderColor: '#ffffff', zIndex: 2 },
  finDiamond: { position: 'absolute', top: 4, right: 4, width: 9, height: 9, borderRadius: 2, borderWidth: 1.5, transform: [{ rotate: '45deg' }], zIndex: 2 },
  cellName: { maxWidth: '100%', fontFamily: F.display, fontSize: 11.5, lineHeight: 13, paddingHorizontal: 5 },
  bfName: { maxWidth: '100%', borderRadius: 999 },
  pips: { flexDirection: 'row', gap: 2 },
  pip: { width: 7, height: 7, borderRadius: 4, borderWidth: 1.5 },
  rarLabel: { fontFamily: F.black, fontSize: 8, letterSpacing: 0.6 },
  reward: { flexDirection: 'row', alignItems: 'center', gap: 10, borderRadius: 16, backgroundColor: '#ffffff', borderBottomWidth: 3, paddingVertical: 6, paddingLeft: 6, paddingRight: 10 },
  rewardArt: { width: 46, height: 46, borderRadius: 13, alignItems: 'center', justifyContent: 'center' },
  rewardChip: { alignSelf: 'flex-start', backgroundColor: '#d3179a', borderRadius: 999, paddingHorizontal: 6 },
  rewardChipText: { fontFamily: F.black, fontSize: 8.5, letterSpacing: 0.8, color: '#ffffff' },
  rewardName: { fontFamily: F.display, fontSize: 14, lineHeight: 16, color: '#4a1a73' },
  rewardNote: { fontFamily: F.heavy, fontSize: 10, lineHeight: 12.5, color: '#8a5aa8' },
  rewardPill: { borderWidth: 2, borderColor: '#ffffff', borderRadius: 999, paddingHorizontal: 8, paddingVertical: 2 },
  rewardPillText: { fontFamily: F.black, fontSize: 10, letterSpacing: 0.5 },
  foot: { fontFamily: F.bold, fontSize: 10.5, lineHeight: 15, color: 'rgba(255,255,255,0.9)', textAlign: 'center', paddingHorizontal: 10 },
  scrim: { ...StyleSheet.absoluteFillObject, backgroundColor: 'rgba(30,0,60,0.55)' },
  sheet: { position: 'absolute', left: 0, right: 0, bottom: 0, maxHeight: '90%', borderTopLeftRadius: 30, borderTopRightRadius: 30, backgroundColor: '#fbefff', borderTopWidth: 3, borderColor: '#ffffff' },
  // shrinks to leave the footer (sheetFoot) in view
  sheetScroll: { flexShrink: 1 },
  sheetBody: { paddingTop: 20, paddingHorizontal: 16, paddingBottom: 14, alignItems: 'center', gap: 9 },
  sheetFoot: { paddingHorizontal: 16, paddingTop: 10, paddingBottom: 14, gap: 8, borderTopWidth: 2, borderTopColor: '#f0dcf7' },
  grip: { width: 44, height: 5, borderRadius: 999, backgroundColor: '#e0c8f2', marginTop: -8 },
  pvArt: { width: 160, height: 160, alignItems: 'center', justifyContent: 'center' },
  pvGlow: { position: 'absolute', width: 150, height: 150, borderRadius: 75, opacity: 0.35 },
  pvName: { fontFamily: F.display, fontSize: 26, lineHeight: 30 },
  pill: { borderWidth: 2, borderColor: '#ffffff', borderRadius: 999, paddingHorizontal: 9, paddingVertical: 1 },
  pillText: { fontFamily: F.black, fontSize: 10, letterSpacing: 1, color: '#4a1a73' },
  concept: { fontFamily: F.heavy, fontSize: 13, lineHeight: 17.5, color: '#6a1b9a', textAlign: 'center' },
  soundMove: { fontFamily: F.heavy, fontSize: 11, color: '#a07cc0', textAlign: 'center' },
  box: { alignSelf: 'stretch', gap: 8, borderRadius: 18, backgroundColor: '#ffffff', ...card, borderBottomWidth: 5, borderBottomColor: '#e0c8f2', paddingHorizontal: 12, paddingVertical: 10 },
  boxHead: { flexDirection: 'row', justifyContent: 'space-between', alignItems: 'baseline' },
  boxTitle: { fontFamily: F.black, fontSize: 10, letterSpacing: 1.2, color: '#a07cc0' },
  boxNote: { fontFamily: F.heavy, fontSize: 10.5, color: '#8a5aa8' },
  stageBox: { width: '100%', maxWidth: 76, aspectRatio: 1, borderRadius: 16, borderWidth: 2.5, alignItems: 'center', justifyContent: 'flex-end', paddingBottom: 3 },
  nowTag: { position: 'absolute', top: -9, borderWidth: 1.5, borderColor: '#ffffff', borderRadius: 999, paddingHorizontal: 6 },
  nowText: { fontFamily: F.black, fontSize: 8.5, letterSpacing: 0.6, color: '#ffffff' },
  stageLabel: { fontFamily: F.black, fontSize: 10 },
  xpBar: { height: 8, borderRadius: 999, backgroundColor: '#f3e4fb', overflow: 'hidden' },
  maxed: { fontFamily: F.heavy, fontSize: 11, lineHeight: 15, color: '#9c4d06', textAlign: 'center' },
  finCard: { flex: 1, alignItems: 'center', gap: 3, borderRadius: 14, paddingVertical: 6, paddingHorizontal: 2, borderWidth: 2 },
  finSw: { width: 26, height: 26, borderRadius: 13, borderWidth: 2.5, borderColor: '#ffffff' },
  finName: { fontFamily: F.black, fontSize: 10, color: '#4a1a73' },
  finState: { fontFamily: F.black, fontSize: 8.5, letterSpacing: 0.4 },
  lock: { alignSelf: 'stretch', alignItems: 'center', gap: 8, borderRadius: 18, backgroundColor: '#ffffff', borderWidth: 3, borderStyle: 'dashed', borderColor: '#e0c8f2', paddingHorizontal: 12, paddingVertical: 10 },
  lockText: { fontFamily: F.heavy, fontSize: 12, lineHeight: 17, color: '#6a1b9a', textAlign: 'center' },
  grow: { alignItems: 'center', justifyContent: 'center', gap: 10, paddingHorizontal: 24, zIndex: 50 },
  growWait: { fontFamily: F.display, fontSize: 22, color: '#ffffff' },
  growTitle: { fontFamily: F.display, fontSize: 28, lineHeight: 32, color: '#ffffff', textAlign: 'center' },
  growPerk: { maxWidth: 280, fontFamily: F.heavy, fontSize: 13, lineHeight: 18, color: '#ffffff', textAlign: 'center' },
  toastWrap: { position: 'absolute', alignSelf: 'center', zIndex: 60 },
  toast: { paddingHorizontal: 16, paddingVertical: 8 },
  toastText: { fontFamily: F.display, fontSize: 14, color: PINK_RING },
});

// memo: App re-renders on things this screen doesn't show (the bottom nav's
// tab, the Shop's state…)
export default memo(SquishiesScreen);
