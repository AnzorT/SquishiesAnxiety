import { useSyncExternalStore } from 'react';

// The tutorial's view of the app, outside React's tree so any screen can
// feed it without prop drilling: what's on screen (`report`) and where the
// things it points at are (`registerTarget`, see Target.js). The step
// machine (steps.js) reads this, the Guide overlay (Guide.js) draws from it.

const state = {
  // reported by App.js and the screens
  screen: 'splash', // App's stage: splash | auth | home | box | toy | store | …
  listTab: 'ours', // Home's tab
  boxPhase: 'closed', // MysteryBoxScreen: closed | opening | reveal
  boxPaid: false, // the box on screen is paid for (or free): tapping opens it
  holdActive: false, // SquishScreen: one finger pressing the toy
  rotateAcc: 0, // SquishScreen: how far two fingers have twisted, px
  settingsOpen: false, // SquishScreen's settings popup
  busy: false, // an ad or another overlay is up — the guide hides
  // the Crib (CribScreen): the room on screen, the creature whose card is
  // open, the starter creature's doings, its daily panel
  cribRoom: 'living',
  cribSel: null,
  cribPet0: null, // { act, live } | null
  dailyOpen: false,
  // 'crib' while the Crib draws the guide inside its own (maybe rotated)
  // container — the root Guide stands down; see TutorialGuide's `host`
  host: null,
  // the tutorial's own
  holdMs: 0, // hold time banked in the 'hold' step
  ui: null, // what the Guide shows: { mode: 'spot' | 'card' | 'banner', … }
};
const targets = new Map(); // name → { ref, host, rect }
const listeners = new Set();
let version = 0;

function emit() {
  version++;
  listeners.forEach((fn) => fn());
}

export function report(patch) {
  let changed = false;
  Object.keys(patch).forEach((k) => {
    if (state[k] !== patch[k]) {
      state[k] = patch[k];
      changed = true;
    }
  });
  if (changed) emit();
}

export const getState = () => state;

// `host`: for a target inside a hosted guide's container, { unmap(rect) }
// turns its window rectangle into the container's own coordinates (the Crib
// in landscape is a rotated view).
export function registerTarget(name, ref, host = null) {
  targets.set(name, { ref, host, rect: targets.get(name)?.rect || null });
}
export function unregisterTarget(name, ref) {
  const t = targets.get(name);
  if (t && t.ref === ref) targets.delete(name);
}
export const targetRect = (name) => targets.get(name)?.rect || null;
export const hasTarget = (name) => targets.has(name);

// Measures a target in window coordinates (the Guide polls the one it points
// at, so a target that moves — a card paging in — is followed).
export function measureTarget(name) {
  const t = targets.get(name);
  const node = t && t.ref && t.ref.current;
  if (!node || !node.measureInWindow) return;
  node.measureInWindow((x, y, w, h) => {
    // (0, 0) is what a view detached from the window reports (a list row
    // clipped by removeClippedSubviews): not a position
    let rect = w > 0 && h > 0 && !(x === 0 && y === 0) ? { x, y, w, h } : null;
    if (rect && t.host && t.host.unmap) rect = t.host.unmap(rect);
    const r = t.rect;
    if (!rect && !r) return;
    if (rect && r && Math.abs(r.x - rect.x) < 0.5 && Math.abs(r.y - rect.y) < 0.5 && Math.abs(r.w - rect.w) < 0.5 && Math.abs(r.h - rect.h) < 0.5) return;
    t.rect = rect;
    emit();
  });
}

const subscribe = (fn) => {
  listeners.add(fn);
  return () => listeners.delete(fn);
};
const snapshot = () => version;

// Re-renders the caller whenever anything in the store changes. The state
// object itself never changes identity — effects that should follow the
// store depend on the version from useTutorialVersion().
export function useTutorialStore() {
  useSyncExternalStore(subscribe, snapshot, snapshot);
  return state;
}
export function useTutorialVersion() {
  return useSyncExternalStore(subscribe, snapshot, snapshot);
}
