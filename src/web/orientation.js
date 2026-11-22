// Web only: expo-screen-orientation. Inside the phone frame (PhoneFrame.js) a lock turns the frame, the way the app
// turns the phone (landscape for the new look, portrait for the screens not redone yet), so the app gets the other
// screen size as on the phone. Outside it (a real phone's browser) it asks the browser, which mostly declines: fine.
export const OrientationLock = {
  DEFAULT: 0, ALL: 1, PORTRAIT: 2, PORTRAIT_UP: 3, PORTRAIT_DOWN: 4, LANDSCAPE: 5, LANDSCAPE_LEFT: 6, LANDSCAPE_RIGHT: 7,
  OTHER: 8, UNKNOWN: 9,
};
export const Orientation = { UNKNOWN: 0, PORTRAIT_UP: 1, PORTRAIT_DOWN: 2, LANDSCAPE_LEFT: 3, LANDSCAPE_RIGHT: 4 };

const subs = new Set();
const frame = () => {
  try {
    return window.parent !== window && window.parent.__phoneFrame ? window.parent.__phoneFrame : null;
  } catch (e) {
    return null;
  }
};
let current = OrientationLock.DEFAULT;

const wide = () => (typeof window !== 'undefined' ? window.innerWidth > window.innerHeight : true);
const orientationNow = () => (wide() ? Orientation.LANDSCAPE_LEFT : Orientation.PORTRAIT_UP);

export async function lockAsync(lock) {
  current = lock;
  const f = frame();
  const landscape = lock === OrientationLock.LANDSCAPE || lock === OrientationLock.LANDSCAPE_LEFT || lock === OrientationLock.LANDSCAPE_RIGHT;
  const portrait = lock === OrientationLock.PORTRAIT || lock === OrientationLock.PORTRAIT_UP || lock === OrientationLock.PORTRAIT_DOWN;
  if (f) {
    if (landscape || portrait) f.orient(landscape ? 'landscape' : 'portrait');
  } else if (typeof screen !== 'undefined' && screen.orientation && screen.orientation.lock && (landscape || portrait)) {
    await screen.orientation.lock(landscape ? 'landscape' : 'portrait').catch(() => {});
  }
  const o = orientationNow();
  subs.forEach((fn) => fn({ orientationInfo: { orientation: o }, orientationLock: lock }));
}

export async function unlockAsync() {
  current = OrientationLock.DEFAULT;
}
export async function getOrientationAsync() {
  return orientationNow();
}
export async function getOrientationLockAsync() {
  return current;
}
export async function supportsOrientationLockAsync() {
  return true;
}
export function addOrientationChangeListener(fn) {
  subs.add(fn);
  return { remove: () => subs.delete(fn) };
}
export function removeOrientationChangeListener(sub) {
  if (sub && sub.remove) sub.remove();
}
export function removeOrientationChangeListeners() {
  subs.clear();
}
