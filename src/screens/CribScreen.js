import React, { useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { Animated, AppState, BackHandler, ScrollView, StatusBar as RNStatusBar, StyleSheet, View, useWindowDimensions } from 'react-native';
import { StatusBar } from 'expo-status-bar';
import { SafeAreaInsetsContext, useSafeAreaInsets } from 'react-native-safe-area-context';
import CreatureThumbnail from '../components/CreatureThumbnail';
import DailyChallengesSheet from './DailyChallengesSheet';
import TutorialGuide from '../tutorial/Guide';
import { report as tutReport } from '../tutorial/store';
import { cribCoins, loadCrib, noteCribBuy, saveCrib, setCribSize } from '../firebase/firestore';
import sfx from '../audio/sfx';
import { level as levelOf } from '../progression';
import Scene from '../crib/Scene';
import { careKey } from '../crib/careState';
import { setCribLandscape } from '../crib/orientation';
import CribCard from '../crib/CribCard';
import RoomDock, { TILE_H } from '../crib/RoomTiles';
import CribMap from '../crib/CribMap';
import { Shop } from '../crib/Shop';
import { EditPanel } from '../crib/EditPanel';
import { ACTS, PH, ROOMS, ROOM_ORDER, SCENE_H, SCENE_W, SIZE, SLEEP, foodOf, phaseOf, spotsFor, viewOf } from '../crib/data';
import { CRIB_MAX, advanceOffline, applyLayout, buyFood, coinRate, freshState, lookOf, mealFill, needOf, normalize, occupancy, sendTo, setMember, startMeal, syncPets, teleporting, tick } from '../crib/model';
import { buy as buyItem, canBuy, equip, fridgeFoods, itemOf, nextSong, placeGame, setDecorPos, setPad, setTheme, setUnitPos, sleepCount, sleeperY, dinerY, song, songs, toggleLight, toggleStore } from '../crib/home';
import { CribToast, INK, PAPER, PanButton, SongPill } from '../crib/ui';
import { Pantry } from '../crib/Pantry';
import { CoinsPill, CribButton, LevelPill, PhasePill, RoomTitle } from '../crib/Hud';
import { LinearGradient } from 'expo-linear-gradient';

// The Squad Crib (the 2026-10-03 design's "Squad Crib v5" and "Squad Crib
// Vertical"): the creatures' home. Seven rooms drawn by Scene.js from the
// simulation in src/crib/model.js, which this screen owns: it loads the
// player's home from Firestore (users/{uid}/crib/state) once, ticks it four
// times a second while open, saves it on every change (debounced) and on
// the way out, and credits the coins the squad makes to the profile.
//
// Portrait is the design's vertical page: the scene ×1.3 in a sideways
// scroller, the room dock below. Landscape is the v5 page: the scene fit to
// the screen, the map behind a button. The blue button switches between
// them; the switch is a rotated view, not a device orientation change, so
// Android never recreates anything — and the state is saved either way.
// The Crib's tutorial steps (crib → c_tap → c_feed → c_lvl3 → c_daily →
// c_offers) are steps.js's; this screen reports what they watch and hosts
// the guide inside its own container.
//
// The furniture (src/crib/home.js, saved in the same document): the Home
// Shop sells upgrades, bath stations, yard games and decor for coins (above
// the player's level they're locked); Edit mode swaps tiers and games,
// stores and drags decor, moves the yard's games and picks wall / floor /
// ceiling themes. Each room plays its own music; the dance room the song its
// DJ booth is on. While the app is in the background the squad isn't
// ticked (no coins either way); coming back catches them up like a reopen.

const PORTRAIT_SCALE = 1.3028; // the vertical page's scene scale at 393 wide
const TICK_MS = 250;
const SAVE_MS = 20000;
const COINS_MS = 5000;
const TOAST_MS = 3600;
const FRAME = '#2b1d16';

const DAILY_EV = { bath: 'bath', eat: 'feed', sleep: 'sleep', dance: 'dance', yard: 'play', tv: 'tv' };
const EDITABLE = ['living', 'kitchen', 'bath', 'bed', 'dance', 'yard'];
const SHOP_MSG_MS = 2400;
// each room's music (the design's crib_* tracks); the dance room plays its song
const ROOM_MUSIC = { living: 'crib_living', kitchen: 'crib_kitchen', bath: 'crib_bath', bed: 'crib_bed', dance: 'crib_dance', hatch: 'crib_living', yard: 'crib_yard' };
const ZERO_INSETS = { top: 0, bottom: 0, left: 0, right: 0 };

const MEAL_SHOWN_MS = 3200; // a meal's full-tummy moment after the last bite (model.js)
const PLUSH_MOOD = { bath: 'bath', sleep: 'sleep', dance: 'dance', tv: 'tv', yard: 'happy' };

// The plush mood a creature plays (the design's plushMood), from what it's
// doing and how it looks (model.js lookOf: sad, or smelly when only Clean is
// low): tapped and fine → happy; at the table with a meal going → eat; the
// rooms' activities; then smelly → dirty, sad → sad; fresh from the bath →
// clean.
function moodOf(pet, now, selected, look) {
  const eatOn = !!pet.meal && now < pet.meal.t0 + pet.meal.ms + MEAL_SHOWN_MS;
  if (selected && !eatOn && !look) return 'happy';
  if (pet.act === 'eat' && eatOn) return 'eat';
  if (PLUSH_MOOD[pet.act]) return PLUSH_MOOD[pet.act];
  if (look === 'smelly') return 'dirty';
  if (look === 'sad') return 'sad';
  if (pet.cleanUntil > now) return 'clean';
  return 'idle';
}

export default function CribScreen({ authUser, profile, creatures, onBack, noteDaily, daily, tutorialStep, onTutorialAction }) {
  const uid = authUser ? authUser.uid : null;
  const win = useWindowDimensions();
  const insets = useSafeAreaInsets();
  // the screen's own box once laid out (the window's height leaves out
  // part of an Android screen, which showed as bars in landscape)
  const [box, setBox] = useState(null);
  const onRootLayout = useCallback((e) => {
    const { width, height } = e.nativeEvent.layout;
    setBox((b) => (b && b.width === width && b.height === height ? b : { width, height }));
  }, []);

  const byId = useMemo(() => Object.fromEntries((creatures || []).map((c) => [c.id, c])), [creatures]);
  // the roster creatures the player owns (custom ones have no plush art yet)
  const ownedIds = useMemo(() => (profile?.ownedIds || []).filter((id) => /^\d+$/.test(id) && byId[id] && byId[id].plush), [profile?.ownedIds, byId]);
  const ownedKey = ownedIds.join(',');
  // Nothing loads or syncs before the catalog and the profile are in: with
  // no owned creatures known yet, the sync would move everyone out (and
  // save it). Every player owns at least the starter.
  const ready = ownedIds.length > 0;

  const model = useRef(null);
  const [loaded, setLoaded] = useState(false);
  const [frame, setFrame] = useState(0);
  const bump = useCallback(() => setFrame((f) => f + 1), []);
  const [room, setRoom] = useState('living');
  const [landscape, setLandscape] = useState(false);
  const W = box ? box.width : win.width;
  const H = box ? box.height : win.height;
  const [sel, setSel] = useState(null);
  const [mode, setMode] = useState('main');
  const [sleepH, setSleepH] = useState(2);
  const [mapOpen, setMapOpen] = useState(false);
  const [dailyOpen, setDailyOpen] = useState(false);
  const [pantryOpen, setPantryOpen] = useState(false); // the kitchen's pantry shop
  const [pantryMsg, setPantryMsg] = useState(null);
  const pantryTimer = useRef(null);
  const [musicOn, setMusicOn] = useState(true);
  const [toast, setToast] = useState(null);
  const [shop, setShop] = useState(null); // the shop's room tab, when open
  const [shopMsg, setShopMsg] = useState(null);
  const shopTimer = useRef(null);
  const [edit, setEdit] = useState(false);
  const [editTab, setEditTab] = useState('furn');
  const [edHide, setEdHide] = useState(false);
  const [homeRev, setHomeRev] = useState(0);
  const toastTimer = useRef(null);
  const plus = useRef({}); // id → { text, at }
  const pending = useRef(0); // coins not yet written to the profile
  const dirty = useRef(false);
  const tutStep = useRef(tutorialStep);
  tutStep.current = tutorialStep;
  const tutFed = useRef(false);
  const flash = useRef(new Animated.Value(0)).current;

  const now = Date.now();
  const tutorialOn = tutorialStep && tutorialStep !== 'done';
  const coinsNow = (profile?.coins ?? 0) + pending.current;
  const level = levelOf(profile);
  const home = model.current ? model.current.home : null;

  // --- load, tick, save ----------------------------------------------------------

  useEffect(() => {
    if (!ready || loaded) return undefined;
    let alive = true;
    (async () => {
      const doc = uid ? await loadCrib(uid) : null;
      if (!alive) return;
      const t = Date.now();
      const st = doc ? normalize(doc, ownedIds, t) : freshState(ownedIds, t, { tutorial: !!tutorialOn });
      if (doc) advanceOffline(st, t);
      // the tutorial's lesson is a hungry starter at home
      const p0 = st.pets['0'];
      if (p0 && ['crib', 'c_tap', 'c_feed', 'c_lvl3'].includes(tutStep.current)) {
        p0.stats.tummy = Math.min(p0.stats.tummy, 14);
        if (p0.act !== 'home') sendTo(st, '0', 'home', { now: t });
      }
      model.current = st;
      setRoom(ROOMS[st.room] ? st.room : 'living');
      setLandscape(!!st.landscape);
      dirty.current = true;
      setLoaded(true);
    })();
    return () => {
      alive = false;
    };
    // once per sign-in, when ready; later unlocks are picked up below
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [uid, ready]);

  useEffect(() => {
    if (!loaded || !model.current || !ready) return;
    if (syncPets(model.current, ownedIds, Date.now())) {
      dirty.current = true;
      bump();
    }
    // how many live here, for the achievements
    const n = model.current.members.length;
    if (uid && n !== (profile?.cribSize ?? 0) && n > (profile?.cribSize ?? 0)) setCribSize(uid, n);
  }, [ownedKey, loaded, bump, ownedIds]); // eslint-disable-line react-hooks/exhaustive-deps

  const showToast = useCallback((t, ms = TOAST_MS) => {
    clearTimeout(toastTimer.current);
    setToast(t);
    if (ms) toastTimer.current = setTimeout(() => setToast((cur) => (cur === t ? null : cur)), ms);
  }, []);
  const nameOf = useCallback((id) => (byId[id] ? byId[id].name : 'Someone'), [byId]);

  const flushCoins = useCallback(() => {
    const n = pending.current;
    if (!n || !uid) return;
    pending.current = 0;
    // never below zero
    const floor = -(profile?.coins ?? 0);
    cribCoins(uid, Math.max(n, floor));
  }, [uid, profile?.coins]);
  const save = useCallback(() => {
    if (!uid || !model.current || !dirty.current) return;
    dirty.current = false;
    const st = model.current;
    st.room = room;
    st.landscape = landscape;
    saveCrib(uid, JSON.parse(JSON.stringify(st)));
  }, [uid, room, landscape]);
  const saveRef = useRef(save);
  saveRef.current = save;
  const flushRef = useRef(flushCoins);
  flushRef.current = flushCoins;

  useEffect(() => {
    if (!loaded) return undefined;
    let n = 0;
    let away = AppState.currentState !== 'active';
    const iv = setInterval(() => {
      const st = model.current;
      if (!st || away) return;
      const t = Date.now();
      const events = tick(st, t, { open: true });
      let changed = false;
      events.forEach((e) => {
        if (e.type === 'coins') pending.current += e.n;
        else if (e.type === 'plus') {
          plus.current[e.id] = { text: e.text, at: t };
          changed = true;
        } else if (e.type === 'home') {
          changed = true;
          if (e.why === 'hungry') showToast({ title: `${nameOf(e.id)} got hungry`, body: 'Came home for a snack.', creature: e.id, action: { label: 'FEED', kind: 'feed', id: e.id } }, 5000);
          else showToast({ title: `${nameOf(e.id)} woke up`, body: 'Back in the living room, full of energy.', creature: e.id });
        } else if (e.type === 'wander') changed = true;
      });
      // the tutorial's free cookie, once the starter is at the table
      const p0 = st.pets['0'];
      if (tutStep.current === 'c_lvl3' && p0 && p0.act === 'eat' && !p0.meal && !teleporting(p0, t) && !tutFed.current) {
        tutFed.current = true;
        startMeal(st, '0', 'cookie', { free: true, now: t });
        changed = true;
      }
      dirty.current = true;
      n += 1;
      if (changed || n % 4 === 0) bump();
    }, TICK_MS);
    const saveIv = setInterval(() => saveRef.current(), SAVE_MS);
    const coinIv = setInterval(() => flushRef.current(), COINS_MS);
    const sub = AppState.addEventListener('change', (s) => {
      if (s !== 'active') {
        if (away) return;
        away = true;
        flushRef.current();
        dirty.current = true;
        saveRef.current();
      } else if (away) {
        // back: the time away passes like a reopen (capped, no coins)
        away = false;
        if (model.current) advanceOffline(model.current, Date.now());
        dirty.current = true;
        bump();
      }
    });
    return () => {
      clearInterval(iv);
      clearInterval(saveIv);
      clearInterval(coinIv);
      sub.remove();
      flushRef.current();
      saveRef.current();
    };
  }, [loaded, bump, showToast, nameOf]);

  // --- the rooms ---------------------------------------------------------------

  const goRoom = useCallback(
    (r) => {
      setMapOpen(false);
      if (r === room) return;
      sfx.play('whoosh');
      Animated.sequence([Animated.timing(flash, { toValue: 1, duration: 210, useNativeDriver: true }), Animated.timing(flash, { toValue: 0, duration: 210, useNativeDriver: true })]).start();
      setTimeout(() => {
        setRoom(r);
        if (model.current) model.current.room = r;
        dirty.current = true;
      }, 200);
    },
    [room, flash]
  );

  const petsHere = useMemo(() => {
    const st = model.current;
    if (!st) return [];
    return Object.keys(st.pets)
      .filter((id) => viewOf(st.pets[id].room) === room && byId[id])
      .map((id) => {
        const p = st.pets[id];
        const spot = spotsFor(p.room, st.home)[p.spot] || { x: 426, y: 300 };
        const moving = teleporting(p, now);
        const look = lookOf(p);
        const need = moving ? null : needOf(p);
        const meal = p.meal && now < p.meal.t0 + p.meal.ms + MEAL_SHOWN_MS ? p.meal : null;
        const playing = p.room === 'yard' && p.act === 'yard' && !moving && spot.g ? spot : null;
        // in bed, tucked in to the chin; at the table, sitting at it
        const inBed = p.act === 'sleep' && p.room === 'bed' && !moving;
        const atTable = p.act === 'eat' && p.room === 'kitchen';
        const rig = byId[id].rig;
        const mouthY = rig && rig.mouth ? rig.mouth.y : 64;
        return {
          id,
          creature: byId[id],
          x: spot.x,
          y: inBed ? sleeperY(st.home, spot.y, mouthY, SIZE) : atTable ? dinerY(st.home, spot.y, mouthY, SIZE) : spot.y,
          mood: moodOf(p, now, sel === id, look),
          careKey: careKey(p, { look, need: needOf(p), yardGame: spot.g }),
          // what the plush moods need: the meal (its food and timing), the
          // bath station
          care: meal ? { food: meal.k, eatStart: meal.t0, eatMs: meal.ms } : p.act === 'bath' && p.room === 'bath' ? { bathStyle: spot.style || 'tub' } : null,
          need,
          since: p.since,
          from: p.from,
          plus: plus.current[id] && now - plus.current[id].at < 1800 ? plus.current[id] : null,
          selected: sel === id,
          // playing on one of the yard's games (it moves with it)
          game: playing,
        };
      });
    // `frame` stands for the model's contents
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [frame, room, sel, byId, homeRev]);

  // who's on the yard's games, and whether anyone's dancing (the lights speed up)
  const yardSpots = useMemo(() => (room === 'yard' && model.current ? spotsFor('yard', model.current.home) : null), [room, frame, homeRev]); // eslint-disable-line react-hooks/exhaustive-deps
  const yardOccKey = room === 'yard' && model.current ? occupancy(model.current, 'yard').join(',') : '';
  const yardOcc = useMemo(() => (yardOccKey ? yardOccKey.split(',').map((v) => v || null) : null), [yardOccKey]);
  const dancing = room === 'dance' && !!model.current && Object.values(model.current.pets).some((p) => p.room === 'dance' && p.act === 'dance' && !teleporting(p, now));

  const summary = useMemo(() => {
    const st = model.current;
    const out = {};
    ROOM_ORDER.forEach((r) => (out[r] = { pets: [], count: 0, busy: 0, needs: 0, eggs: 0 }));
    if (st) {
      Object.keys(st.pets).forEach((id) => {
        const p = st.pets[id];
        const r = viewOf(p.room);
        if (!out[r] || !byId[id]) return;
        out[r].pets.push(byId[id]);
        out[r].count += 1;
        if (p.act !== 'home' && r !== 'living') out[r].busy += 1;
        if (needOf(p)) out[r].needs += 1;
      });
    }
    out.hatch.eggs = Math.max(0, (creatures || []).filter((c) => /^\d+$/.test(c.id)).length - ownedIds.length);
    return out;
    // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [frame, byId, creatures, ownedIds]);

  const pods = useMemo(() => {
    if (room !== 'hatch') return null;
    const st = model.current;
    return (creatures || [])
      .filter((c) => /^\d+$/.test(c.id) && c.plush)
      .sort((a, b) => Number(a.id) - Number(b.id))
      .map((c) => {
        const p = st && st.pets[c.id];
        return { creature: c, owned: ownedIds.includes(c.id), member: !!p, where: p ? ROOMS[viewOf(p.room)].name.toUpperCase() : 'AWAY' };
      });
  }, [room, creatures, frame, ownedIds]); // eslint-disable-line react-hooks/exhaustive-deps
  const members = model.current ? model.current.members.length : 0;

  // the hatchery's switch: a hatched friend moves into the Crib (while
  // there's room for CRIB_MAX) or out of it
  const onPodPress = useCallback(
    (pod) => {
      const st = model.current;
      if (!st) return;
      const c = pod.creature;
      if (!pod.owned) {
        showToast({ title: `${c.name} is still dreaming`, body: 'Open a Mystery Box to hatch them.' });
        return;
      }
      if (pod.member && c.id === '0' && tutorialOn) {
        showToast({ title: `${c.name} stays for now`, body: 'Finish the tutorial first.' }, 2600);
        return;
      }
      const r = setMember(st, c.id, !pod.member, ownedIds, Date.now());
      if (!r.ok) {
        showToast({ title: `The Crib is full (${CRIB_MAX}/${CRIB_MAX})`, body: 'Move someone out first — tap them here.' }, 3000);
        return;
      }
      sfx.play('tap');
      dirty.current = true;
      bump();
      if (uid) setCribSize(uid, st.members.length);
      showToast({ title: pod.member ? `${c.name} moved out` : `${c.name} moved in!`, body: `${st.members.length}/${CRIB_MAX} friends live in the Crib.`, creature: c.id }, 2600);
    },
    [ownedIds, tutorialOn, showToast, bump, uid]
  );

  const needCount = useMemo(() => ROOM_ORDER.reduce((n, r) => n + summary[r].needs, 0), [summary]);
  const rate = model.current ? coinRate(model.current, now) : 0;
  const phase = phaseOf(new Date().getHours());

  // --- the card ---------------------------------------------------------------------

  const openCard = useCallback(
    (id) => {
      const p = model.current && model.current.pets[id];
      if (!p) return;
      sfx.play('tap');
      setSel(id);
      setMode(p.act === 'eat' && !p.meal && !teleporting(p, Date.now()) ? 'feed' : 'main');
    },
    []
  );
  const closeCard = useCallback(() => {
    setSel(null);
    setMode('main');
  }, []);

  const send = useCallback(
    (id, act, opts = {}) => {
      const st = model.current;
      if (!st) return false;
      const r = sendTo(st, id, act, { ...opts, now: Date.now() });
      if (!r.ok) {
        if (r.reason === 'full') showToast({ title: 'That room is full', body: 'Bring someone home first.' }, 2600);
        return false;
      }
      dirty.current = true;
      bump();
      if (act !== 'home') {
        const ev = DAILY_EV[act];
        if (ev && noteDaily) noteDaily(ev);
        const rm = viewOf(ACTS[act].room);
        if (!opts.quiet) showToast({ title: `${nameOf(id)} went to the ${ROOMS[rm].name}`, body: ACTS[act].verb + (act === 'dance' || act === 'yard' ? ' until hungry' : ''), creature: id, action: rm !== room ? { label: 'GO', kind: 'go', room: rm } : null });
      }
      return true;
    },
    [bump, noteDaily, nameOf, room, showToast]
  );

  const onAct = useCallback(
    (k) => {
      const st = model.current;
      const p = st && sel && st.pets[sel];
      if (!p) return;
      if (k === 'tuck') {
        const max = sleepCount(st.home);
        if (send(sel, 'sleep', { h: Math.min(sleepH, SLEEP[Math.max(0, max - 1)]) })) closeCard();
        return;
      }
      if (k === p.act) {
        if (k === 'eat' && !p.meal) setMode('feed');
        return;
      }
      if (k === 'sleep') {
        setMode('sleep');
        return;
      }
      if (send(sel, k)) closeCard();
    },
    [sel, sleepH, send, closeCard]
  );
  const onStop = useCallback(() => {
    if (sel && send(sel, 'home')) closeCard();
  }, [sel, send, closeCard]);
  const onFeed = useCallback(
    (k) => {
      const st = model.current;
      if (!st || !sel) return;
      const r = startMeal(st, sel, k, { coins: coinsNow, now: Date.now() });
      if (!r.ok) {
        if (r.reason === 'coins') showToast({ title: 'Not enough coins', body: `${foodOf(k).name} costs ${foodOf(k).price} coins.` }, 2600);
        return;
      }
      if (r.cost) pending.current -= r.cost;
      sfx.play('tap');
      dirty.current = true;
      bump();
      closeCard();
    },
    [sel, coinsNow, bump, closeCard, showToast]
  );
  const roomFull = useCallback(
    (k) => {
      const st = model.current;
      if (!st) return false;
      return occupancy(st, ACTS[k].room).every((v) => v != null);
    },
    [frame] // eslint-disable-line react-hooks/exhaustive-deps
  );

  const onToastAction = useCallback(
    (a) => {
      setToast(null);
      if (a.kind === 'go') goRoom(a.room);
      else if (a.kind === 'feed') send(a.id, 'eat', { quiet: true });
      else if (a.kind === 'daily') setDailyOpen(true);
    },
    [goRoom, send]
  );

  // --- the furniture: the shop, Edit mode ----------------------------------------------

  const flashShop = useCallback((msg) => {
    clearTimeout(shopTimer.current);
    setShopMsg(msg);
    shopTimer.current = setTimeout(() => setShopMsg(null), SHOP_MSG_MS);
  }, []);
  // the home changed: creatures whose spot went away go home, the scene
  // redraws, and it's saved (`now` for a purchase, else with the next save)
  const homeChanged = useCallback(
    (saveNow) => {
      const st = model.current;
      if (!st) return;
      applyLayout(st, Date.now());
      dirty.current = true;
      setHomeRev((r) => r + 1);
      bump();
      if (saveNow) saveRef.current();
    },
    [bump]
  );
  const onBuy = useCallback(
    (id) => {
      const st = model.current;
      const it = itemOf(id);
      if (!st || !it) return;
      const r = canBuy(st.home, id, { level, coins: coinsNow });
      if (!r.ok) {
        if (r.reason === 'coins') flashShop(`Not enough coins for ${it.name}`);
        return;
      }
      pending.current -= r.cost;
      const { placed } = buyItem(st.home, id);
      if (uid) noteCribBuy(uid);
      sfx.play('spend');
      flashShop(it.name + (it.kind === 'decor' ? ' placed in your room!' : it.kind === 'game' ? (placed ? ' added to the yard!' : ' bought! Swap it into a play spot in Edit mode.') : ' installed!'));
      // paid and saved together, right away
      flushRef.current();
      homeChanged(true);
    },
    [uid, level, coinsNow, flashShop, homeChanged]
  );
  const openShop = useCallback(() => {
    sfx.play('tap');
    closeCard();
    setShop(EDITABLE.includes(room) ? room : 'living');
  }, [room, closeCard]);
  const openEdit = useCallback(() => {
    if (!EDITABLE.includes(room)) return;
    sfx.play('tap');
    closeCard();
    setToast(null);
    setMapOpen(false);
    setEditTab('furn');
    setEdHide(false);
    setEdit(true);
  }, [room, closeCard]);
  const closeEdit = useCallback(() => {
    setEdit(false);
    saveRef.current();
  }, []);
  // no Edit mode in the hatchery
  useEffect(() => {
    if (edit && !EDITABLE.includes(room)) setEdit(false);
  }, [edit, room]);
  const onEquip = useCallback((slot, id) => model.current && equip(model.current.home, slot, id) && homeChanged(false), [homeChanged]);
  const onPlace = useCallback((pad, game) => model.current && placeGame(model.current.home, pad, game) && homeChanged(false), [homeChanged]);
  const onStore = useCallback(
    (id) => {
      if (!model.current) return;
      toggleStore(model.current.home, id);
      homeChanged(false);
    },
    [homeChanged]
  );
  const onTheme = useCallback(
    (kind, i) => {
      if (!model.current) return;
      setTheme(model.current.home, room, kind, i);
      homeChanged(false);
    },
    [room, homeChanged]
  );
  const onToggleLight = useCallback(
    (id) => {
      if (!model.current) return;
      toggleLight(model.current.home, id);
      sfx.play('tap');
      homeChanged(false);
    },
    [homeChanged]
  );
  const onMoveDecor = useCallback(
    (id, x, y) => {
      if (!model.current) return;
      setDecorPos(model.current.home, id, x, y);
      homeChanged(false);
    },
    [homeChanged]
  );
  const onMovePad = useCallback(
    (k, dx, dy, done) => {
      if (!model.current) return;
      setPad(model.current.home, k, dx, dy);
      if (done) homeChanged(false);
      else setHomeRev((r) => r + 1);
    },
    [homeChanged]
  );
  // a piece of furniture dragged in Edit mode (its seats move with it)
  const onMoveUnit = useCallback(
    (key, dx, dy, done) => {
      if (!model.current) return;
      setUnitPos(model.current.home, key, dx, dy);
      if (done) homeChanged(false);
      else setHomeRev((r) => r + 1);
    },
    [homeChanged]
  );
  const onNextSong = useCallback(() => {
    if (!model.current) return;
    nextSong(model.current.home);
    dirty.current = true;
    setHomeRev((r) => r + 1);
  }, []);

  // --- the kitchen's pantry shop (src/crib/Pantry.js) ----------------------------------
  // only in the kitchen: its HUD button, and "Buy food" in the snack picker

  const flashPantry = useCallback((msg) => {
    clearTimeout(pantryTimer.current);
    setPantryMsg(msg);
    pantryTimer.current = setTimeout(() => setPantryMsg(null), SHOP_MSG_MS);
  }, []);
  const openPantry = useCallback(() => {
    sfx.play('tap');
    setToast(null);
    setPantryOpen(true);
  }, []);
  const closePantry = useCallback(() => setPantryOpen(false), []);
  const onBuyFood = useCallback(
    (k, n) => {
      const st = model.current;
      const F = foodOf(k);
      if (!st || !F) return;
      const r = buyFood(st, k, n, { coins: coinsNow });
      if (!r.ok) {
        if (r.reason === 'coins') flashPantry(`Not enough coins for ${n} × ${F.name}`);
        return;
      }
      pending.current -= r.cost;
      sfx.play('spend');
      flashPantry(`${n} × ${F.name} put in the pantry`);
      // paid and saved together, right away
      flushRef.current();
      dirty.current = true;
      bump();
      saveRef.current();
    },
    [coinsNow, flashPantry, bump]
  );
  // the pantry is the kitchen's: leaving the room closes it
  useEffect(() => {
    if (room !== 'kitchen') setPantryOpen(false);
  }, [room]);

  // --- the toggles, back ------------------------------------------------------------

  const toggleLandscape = useCallback(() => {
    setLandscape((v) => {
      if (model.current) model.current.landscape = !v;
      dirty.current = true;
      return !v;
    });
    setMapOpen(false);
    // saved right away, like anything else that would be a shame to lose
    setTimeout(() => saveRef.current(), 50);
  }, []);
  // the Crib's own music switch (not the Settings one); each room has its
  // track, the dance room plays the DJ's song. App.js takes over again when
  // the stage changes.
  const songNow = model.current ? song(model.current.home) : null;
  const track = !musicOn ? null : room === 'dance' && songNow ? songNow.track : ROOM_MUSIC[room];
  useEffect(() => {
    sfx.music(track);
  }, [track]);
  const toggleMusic = useCallback(() => setMusicOn((v) => !v), []);
  // App.js's banners turn with a landscape Crib (crib/orientation.js)
  useEffect(() => setCribLandscape(landscape), [landscape]);
  useEffect(() => () => setCribLandscape(false), []);
  const leave = useCallback(() => {
    flushCoins();
    save();
    onBack();
  }, [flushCoins, save, onBack]);

  useEffect(() => {
    const sub = BackHandler.addEventListener('hardwareBackPress', () => {
      if (shop) setShop(null);
      else if (edit) closeEdit();
      else if (dailyOpen) setDailyOpen(false);
      else if (pantryOpen) setPantryOpen(false);
      else if (mapOpen) setMapOpen(false);
      else if (sel) closeCard();
      else leave();
      return true;
    });
    return () => sub.remove();
  }, [shop, edit, closeEdit, dailyOpen, pantryOpen, mapOpen, sel, closeCard, leave]);

  // --- the tutorial --------------------------------------------------------------------

  const p0 = model.current && model.current.pets['0'];
  const pet0Key = p0 ? `${p0.act}|${!teleporting(p0, now)}` : '';
  const pet0 = useMemo(() => (pet0Key ? { act: pet0Key.split('|')[0], live: pet0Key.endsWith('true') } : null), [pet0Key]);
  useEffect(() => {
    tutReport({ host: 'crib', cribRoom: room, cribSel: sel, cribPet0: pet0, dailyOpen });
  }, [room, sel, pet0, dailyOpen]);
  useEffect(() => () => tutReport({ host: null, cribSel: null, cribPet0: null, dailyOpen: false }), []);
  const prevStep = useRef(tutorialStep);
  useEffect(() => {
    if (!loaded) return;
    const was = prevStep.current;
    prevStep.current = tutorialStep;
    if (tutorialStep === 'crib' || tutorialStep === 'c_tap') {
      if (room !== 'living') goRoom('living');
      if (tutorialStep === 'crib') closeCard();
    } else if (tutorialStep === 'c_daily') setDailyOpen(true);
    else if (tutorialStep === 'c_offers') setDailyOpen(false);
    else if (tutorialStep === 'done' && was === 'c_offers') showToast({ title: 'Tutorial complete!', body: 'Have fun with your squad.' }, 4000);
  }, [tutorialStep, loaded]); // eslint-disable-line react-hooks/exhaustive-deps

  // a hosted guide's targets, in this container's coordinates: in portrait
  // the container starts under the status bar; in landscape it's this
  // screen's view rotated a quarter turn about the window's centre
  const host = useMemo(() => {
    if (landscape) {
      return {
        unmap: ({ x, y, w, h }) => {
          const dx = x - W / 2;
          const dy = y - H / 2;
          return { x: H / 2 + dy, y: W / 2 - dx, w, h };
        },
      };
    }
    const fix = RNStatusBar.currentHeight || 0;
    return { unmap: ({ x, y, w, h }) => ({ x, y: y + fix, w, h }) };
  }, [landscape, W, H]);

  // --- layout ----------------------------------------------------------------------------

  // a drag's screen movement in the scene's directions (landscape is a
  // view turned a quarter clockwise)
  const toLocal = useCallback((dx, dy) => (landscape ? { x: dy, y: -dx } : { x: dx, y: dy }), [landscape]);

  const cw = landscape ? H : W; // the container's size
  const ch = landscape ? W : H;
  // landscape covers the screen (a sliver of the room's top and bottom may
  // go), portrait is the vertical page's zoom in a sideways scroller
  const scale = landscape ? Math.max(cw / SCENE_W, ch / SCENE_H) : PORTRAIT_SCALE * (cw / 393);
  const sceneW = SCENE_W * scale;
  const sceneH = SCENE_H * scale;
  // (the status bar's own height too: coming back from landscape, where it's
  // hidden, the insets can lag a frame behind)
  const topPad = landscape ? 10 : Math.max(insets.top, RNStatusBar.currentHeight || 0) + 10;
  // the portrait scroller starts centred (the design's panToX), or on the
  // starter while the tutorial points at it
  const scroller = useRef(null);
  const scrollX = useRef(0);
  const pan = useCallback(
    (d) => {
      const x = Math.max(0, Math.min(sceneW - cw, scrollX.current + d * cw * 0.6));
      if (scroller.current) scroller.current.scrollTo({ x, animated: true });
    },
    [sceneW, cw]
  );
  useEffect(() => {
    if (landscape || !scroller.current || !loaded) return;
    const st = model.current;
    const p0 = st && st.pets['0'];
    const onStarter = (tutorialStep === 'c_tap' || tutorialStep === 'c_feed') && p0 && viewOf(p0.room) === room;
    const focusX = onStarter ? (spotsFor(p0.room, st.home)[p0.spot] || { x: sceneW / scale / 2 }).x * scale : sceneW / 2;
    scroller.current.scrollTo({ x: Math.max(0, Math.min(sceneW - cw, focusX - cw / 2)), animated: !!onStarter });
  }, [landscape, room, sceneW, cw, scale, tutorialStep, loaded]);

  const selPet = sel && model.current ? model.current.pets[sel] : null;
  const roomName = ROOMS[room].name.toUpperCase();
  const roomSub = room === 'hatch' ? `${members}/${CRIB_MAX} live in the Crib · tap one to move` : `${summary[room].count} friends here · ${ROOMS[room].sub}`;

  const canEdit = EDITABLE.includes(room);
  // The HUD, as the design lays it out (src/crib/Hud.js). Landscape: every
  // button in a row on the left — back, music, rotate, map, shop, edit,
  // daily, and in the kitchen the pantry — then the level, the coins and the
  // time of day on the right. Portrait: back, music, shop, edit, rotate on
  // the left and the pantry (kitchen), daily on the right, the room's big
  // title and the coins under them.
  const dailyBtn = daily && daily.unlocked ? <CribButton face="yellow" icon="daily" onPress={() => setDailyOpen(true)} badge={daily.badge || 0} badgeKind="red" /> : null;
  const pantryBtn = room === 'kitchen' && !edit ? <CribButton face="red" icon="pantry" iconSize={26} onPress={openPantry} /> : null;
  const hud = landscape ? (
    <View pointerEvents="box-none" style={[styles.hud, styles.hudLand]}>
      <LinearGradient pointerEvents="none" colors={['rgba(70,40,20,0.3)', 'rgba(70,40,20,0)']} style={StyleSheet.absoluteFill} />
      <View style={styles.hudRowLand} pointerEvents="box-none">
        <CribButton face="pink" icon="back" onPress={leave} />
        <CribButton face="gold" icon="music" off={!musicOn} onPress={toggleMusic} />
        <CribButton face="blue" icon="rotate" iconSize={22} onPress={toggleLandscape} />
        <CribButton face="green" icon="map" iconSize={26} onPress={() => setMapOpen(true)} badge={needCount} />
        <CribButton face="purple" icon="shop" iconSize={26} onPress={openShop} />
        <CribButton face="orange" icon="edit" iconSize={22} onPress={openEdit} dim={!canEdit || edit} />
        {dailyBtn}
        {pantryBtn}
        <View style={{ flex: 1 }} />
        <View style={styles.hudPills}>
          <LevelPill level={level} />
          <CoinsPill coins={coinsNow} rate={rate} />
          <PhasePill sun={PH[phase].sun} label={PH[phase].label} />
        </View>
      </View>
    </View>
  ) : (
    <View pointerEvents="box-none" style={[styles.hud, { paddingTop: topPad, paddingHorizontal: 14, paddingBottom: 24 }]}>
      <LinearGradient pointerEvents="none" colors={['rgba(70,40,20,0.38)', 'rgba(70,40,20,0)']} style={StyleSheet.absoluteFill} />
      <View style={styles.hudRowPort} pointerEvents="box-none">
        <CribButton face="pink" icon="back" onPress={leave} />
        <CribButton face="gold" icon="music" off={!musicOn} onPress={toggleMusic} />
        <CribButton face="purple" icon="shop" size={42} iconSize={26} onPress={openShop} />
        <CribButton face="orange" icon="edit" size={42} iconSize={22} onPress={openEdit} dim={!canEdit || edit} />
        <CribButton face="blue" icon="rotate" size={42} iconSize={22} turn onPress={toggleLandscape} />
        <View style={{ flex: 1 }} />
        {pantryBtn}
        {dailyBtn}
      </View>
      <View style={styles.hudRowPort2} pointerEvents="box-none">
        <View pointerEvents="none" style={{ flexShrink: 1 }}>
          <RoomTitle title={roomName} sub={roomSub} />
        </View>
        <View style={{ flex: 1 }} />
        <CoinsPill coins={coinsNow} rate={rate} />
      </View>
    </View>
  );

  const scene = loaded ? (
    <Scene
      room={room}
      phase={phase}
      scale={scale}
      pets={petsHere}
      onPetPress={openCard}
      host={host}
      pods={pods}
      onPodPress={onPodPress}
      members={members}
      podHead={landscape}
      home={home}
      homeRev={homeRev}
      edit={edit}
      yardSpots={yardSpots}
      yardOcc={yardOcc}
      dancing={dancing}
      onToggleLight={onToggleLight}
      onMoveDecor={onMoveDecor}
      onMovePad={onMovePad}
      onMoveUnit={onMoveUnit}
      toLocal={toLocal}
    />
  ) : null;
  const songs_ = model.current ? songs(model.current.home) : [];
  const songPill =
    room === 'dance' && !edit && !shop && songNow ? (
      <View pointerEvents="box-none" style={landscape ? { position: 'absolute', right: 20, bottom: 16, zIndex: 12 } : { position: 'absolute', right: 12, top: sceneH - 46, zIndex: 12 }}>
        <SongPill name={songNow.name} count={`${songs_.indexOf(songNow) + 1}/${songs_.length}`} onPress={onNextSong} />
      </View>
    ) : null;

  const overlays = (
    <>
      <Animated.View pointerEvents="none" style={[StyleSheet.absoluteFill, { backgroundColor: '#ffffff', opacity: flash }]} />
      {songPill}
      {toast && !edit ? (
        <View pointerEvents="box-none" style={[styles.toastAt, { top: topPad + 52, left: landscape ? cw * 0.2 : 12, right: landscape ? cw * 0.2 : 12 }]}>
          <CribToast toast={toast} onAction={onToastAction}>
            {toast.creature && byId[toast.creature] ? <CreatureThumbnail creature={byId[toast.creature]} size={40} animate={false} /> : null}
          </CribToast>
        </View>
      ) : null}
      {selPet ? (
        <View pointerEvents="box-none" style={landscape ? styles.cardLand : [styles.cardPort, { top: sceneH - 16, bottom: insets.bottom + 14 }]}>
          <CribCard
            pet={selPet}
            creature={byId[sel]}
            now={now}
            coins={coinsNow}
            pantry={model.current.pantry}
            mode={mode}
            sleepH={sleepH}
            sleepMax={sleepCount(model.current.home)}
            fridge={fridgeFoods(model.current.home)}
            fill={(f) => mealFill(model.current, f)}
            onSleepH={setSleepH}
            onMode={setMode}
            onAct={onAct}
            onStop={onStop}
            onClose={closeCard}
            onFeed={onFeed}
            onPantry={openPantry}
            roomFull={roomFull}
            host={host}
            cols={landscape ? 4 : 5}
            style={{ flex: 1 }}
          />
        </View>
      ) : null}
      {mapOpen ? <CribMap width={cw} height={ch} scale={Math.min(cw / SCENE_W, ch / SCENE_H)} summary={summary} current={room} onGo={goRoom} onClose={() => setMapOpen(false)} /> : null}
      {pantryOpen && model.current ? (
        <Pantry
          pantry={model.current.pantry}
          fridge={fridgeFoods(model.current.home)}
          fill={(f) => mealFill(model.current, f)}
          coins={coinsNow}
          msg={pantryMsg}
          width={cw}
          height={ch}
          onBuy={onBuyFood}
          onClose={closePantry}
        />
      ) : null}
      {edit && landscape && home ? (
        <EditPanel
          home={home}
          homeRev={homeRev}
          room={room}
          level={level}
          tab={editTab}
          onTab={setEditTab}
          onEquip={onEquip}
          onPlace={onPlace}
          onStore={onStore}
          onTheme={onTheme}
          onShop={() => setShop(room)}
          onDone={closeEdit}
          hidden={edHide}
          onToggleHidden={() => setEdHide((v) => !v)}
        />
      ) : null}
      {shop && home ? (
        <Shop
          home={home}
          homeRev={homeRev}
          room={shop}
          level={level}
          coins={coinsNow}
          msg={shopMsg}
          width={cw}
          onRoom={setShop}
          onBuy={onBuy}
          onClose={() => setShop(null)}
          topPad={landscape ? 12 : insets.top + 8}
          bottomPad={landscape ? 8 : insets.bottom}
        />
      ) : null}
      {daily ? <DailyChallengesSheet visible={dailyOpen} profile={profile} onClose={() => setDailyOpen(false)} onClaim={daily.onClaim} onClaimChest={daily.onClaimChest} /> : null}
      <TutorialGuide host="crib" onAction={onTutorialAction} />
    </>
  );

  // (flex, not the window's height: on Android that leaves out the system
  // bar at the bottom, which then showed white under the dock)
  const portrait = (
    <View style={{ flex: 1, backgroundColor: FRAME }} onLayout={onRootLayout}>
      <ScrollView
        ref={scroller}
        horizontal
        bounces={false}
        scrollEnabled={!edit}
        onScroll={(e) => (scrollX.current = e.nativeEvent.contentOffset.x)}
        scrollEventThrottle={64}
        showsHorizontalScrollIndicator={false}
        style={{ height: sceneH, flexGrow: 0 }}
        contentContainerStyle={{ width: sceneW }}
      >
        {scene}
      </ScrollView>
      <PanButton dir={-1} onPress={() => pan(-1)} style={[styles.panBtn, { left: 8, top: sceneH * 0.55 }]} />
      <PanButton dir={1} onPress={() => pan(1)} style={[styles.panBtn, { right: 8, top: sceneH * 0.55 }]} />
      {edit && home ? (
        <View style={[styles.dock, { paddingHorizontal: 0, paddingTop: 0, paddingBottom: 0, backgroundColor: PAPER }]}>
          <EditPanel
            vertical
            home={home}
            homeRev={homeRev}
            room={room}
            level={level}
            tab={editTab}
            onTab={setEditTab}
            onEquip={onEquip}
            onPlace={onPlace}
            onStore={onStore}
            onTheme={onTheme}
            onShop={() => setShop(room)}
            onDone={closeEdit}
            bottomPad={insets.bottom}
          />
        </View>
      ) : (
        <RoomDock summary={summary} current={room} onGo={goRoom} phase={PH[phase]} level={level} tileH={Math.max(92, Math.min(TILE_H, Math.floor((ch - sceneH - insets.bottom - 92) / 2)))} bottomPad={insets.bottom} />
      )}
      {hud}
      {overlays}
    </View>
  );

  const land = (
    <View style={{ width: cw, height: ch, backgroundColor: FRAME, alignItems: 'center', justifyContent: 'center', overflow: 'hidden' }}>
      {scene}
      {hud}
      {overlays}
    </View>
  );

  if (!landscape) return portrait;
  return (
    <View style={{ flex: 1, backgroundColor: FRAME }} onLayout={onRootLayout}>
      <StatusBar hidden />
      <SafeAreaInsetsContext.Provider value={ZERO_INSETS}>
        <View style={{ position: 'absolute', left: (W - H) / 2, top: (H - W) / 2, width: H, height: W, transform: [{ rotate: '90deg' }] }}>{land}</View>
      </SafeAreaInsetsContext.Provider>
    </View>
  );
}

const styles = StyleSheet.create({
  hud: { position: 'absolute', left: 0, right: 0, top: 0, zIndex: 20 },
  hudLand: { paddingTop: 14, paddingHorizontal: 18, paddingBottom: 18 },
  hudRowLand: { flexDirection: 'row', alignItems: 'center', gap: 10 },
  hudPills: { flexDirection: 'row', alignItems: 'center', gap: 6 },
  hudRowPort: { flexDirection: 'row', alignItems: 'center', gap: 8 },
  hudRowPort2: { flexDirection: 'row', alignItems: 'center', gap: 10, marginTop: 4 },
  panBtn: { position: 'absolute', zIndex: 12 },
  toastAt: { position: 'absolute', zIndex: 30 },
  // the design's card: a column on the right under the HUD (landscape), or
  // everything under the scene (portrait)
  cardLand: { position: 'absolute', right: 14, top: 68, bottom: 12, width: 292, zIndex: 25 },
  cardPort: { position: 'absolute', left: 10, right: 10, zIndex: 25 },
  dock: { flex: 1, paddingHorizontal: 12, paddingTop: 10, borderTopWidth: 4, borderTopColor: INK, backgroundColor: '#f3dcb8', marginTop: -4 },
});
