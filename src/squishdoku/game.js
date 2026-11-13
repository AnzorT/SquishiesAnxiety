import { useCallback, useEffect, useRef } from 'react';
import { Animated, Easing, Image } from 'react-native';
import * as Haptics from 'expo-haptics';
import { makePuzzleAsync } from './engine';

// What both modes share: the clock, the puzzle maker that keeps boards
// ready ahead of time, picking creatures, and haptics.

// A clock that can pause: `frac` (Animated, 1 → 0, on the native driver)
// drives the timer bar; `elapsed()` is the truth the game reads.
export function useClock() {
  const frac = useRef(new Animated.Value(1)).current;
  const st = useRef({ limit: 1, used: 0, since: 0, running: false });
  const anim = useRef(null);
  const run = useCallback(() => {
    const s = st.current;
    anim.current?.stop();
    frac.setValue(Math.max(0, 1 - s.used / s.limit));
    anim.current = Animated.timing(frac, { toValue: 0, duration: Math.max(1, s.limit - s.used), easing: Easing.linear, useNativeDriver: true });
    anim.current.start();
  }, [frac]);
  const elapsed = useCallback(() => {
    const s = st.current;
    return s.used + (s.running ? Date.now() - s.since : 0);
  }, []);
  const start = useCallback(
    (limit, used = 0) => {
      st.current = { limit, used, since: Date.now(), running: true };
      run();
    },
    [run],
  );
  const pause = useCallback(() => {
    const s = st.current;
    if (!s.running) return;
    s.used += Date.now() - s.since;
    s.running = false;
    anim.current?.stop();
    frac.setValue(Math.max(0, 1 - s.used / s.limit));
  }, [frac]);
  const resume = useCallback(() => {
    const s = st.current;
    if (s.running) return;
    s.since = Date.now();
    s.running = true;
    run();
  }, [run]);
  const reset = useCallback(() => {
    anim.current?.stop();
    st.current = { limit: 1, used: 0, since: 0, running: false };
    frac.setValue(1);
  }, [frac]);
  useEffect(() => () => anim.current?.stop(), []);
  return { frac, elapsed, start, pause, resume, reset, running: () => st.current.running, limit: () => st.current.limit };
}

// Boards made ahead: `get(n, tier)` resolves with a fresh board (one already
// made if there is one), `prefetch(n, tier)` starts making the next. Boards
// are made a few milliseconds at a time (engine.makePuzzleAsync), so a
// 9×9 expert board doesn't freeze the screen while it's found.
const store = new Map(); // `${n}:${tier}` -> { ready: [], pending: Promise | null }
const keyOf = (n, tier) => `${n}:${tier}`;
function slot(n, tier) {
  const k = keyOf(n, tier);
  if (!store.has(k)) store.set(k, { ready: [], pending: null });
  return store.get(k);
}
function make(n, tier) {
  const s = slot(n, tier);
  if (!s.pending) {
    s.pending = makePuzzleAsync({ n, tier })
      .then((p) => {
        s.ready.push(p);
        return p;
      })
      .finally(() => {
        s.pending = null;
      });
  }
  return s.pending;
}
export function prefetchPuzzle(n, tier) {
  const s = slot(n, tier);
  if (!s.ready.length) make(n, tier).catch(() => {});
}
export async function getPuzzle(n, tier) {
  const s = slot(n, tier);
  // several callers can wait on one board being made: whoever finds the
  // shelf empty again waits for the next
  while (!s.ready.length) await make(n, tier);
  const p = s.ready.shift();
  // keep one spare for the replay
  prefetchPuzzle(n, tier);
  return p;
}

// `k` different creatures, at random.
export function pickCreatures(roster, k) {
  const pool = roster.slice();
  const out = [];
  while (out.length < k && pool.length) out.push(pool.splice(Math.floor(Math.random() * pool.length), 1)[0]);
  while (out.length < k) out.push(roster[out.length % Math.max(1, roster.length)] || null);
  return out;
}

// Warms the image cache for these creatures (gives up after `ms`).
export function prefetchImages(uris, ms = 1500) {
  const all = Promise.all(uris.filter(Boolean).map((u) => Image.prefetch(u).catch(() => false)));
  return Promise.race([all, new Promise((r) => setTimeout(r, ms))]);
}

const quiet = (p) => p && p.catch(() => {});
export function makeHaptics(on) {
  return {
    tap: () => on && quiet(Haptics.selectionAsync()),
    place: () => on && quiet(Haptics.impactAsync(Haptics.ImpactFeedbackStyle.Medium)),
    wrong: () => on && quiet(Haptics.notificationAsync(Haptics.NotificationFeedbackType.Error)),
    win: () => on && quiet(Haptics.notificationAsync(Haptics.NotificationFeedbackType.Success)),
    tick: () => on && quiet(Haptics.impactAsync(Haptics.ImpactFeedbackStyle.Light)),
  };
}

// The sounds a game plays mid-puzzle, loaded up front.
export const PLAY_SOUNDS = ['sd_place', 'sd_wrong', 'sd_x', 'sd_xOff', 'sd_squeak', 'sd_tick', 'sd_starLost', 'sd_mode', 'sd_modeOff', 'sd_boardIn', 'sd_pause', 'sd_resume', 'sd_hop', 'sd_solve'];
export const RESULT_SOUNDS = ['sd_star1', 'sd_star2', 'sd_star3', 'sd_starEmpty', 'sd_perfect', 'sd_coinTick', 'sd_xpFill', 'sd_confetti'];
