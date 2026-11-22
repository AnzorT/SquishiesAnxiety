// The tester's FPS counter (FpsCounter.js): whether it's on, and the frame rates the web pages report.
// The Main Menu (GameScreen) and the chest smash (ChestSmash) are web pages: their frames are drawn by the WebView, not
// by the app's JS, so the app's own count says nothing about them. While the counter is on, each page measures its own
// frames and sends { fps, low, lite } every half second (webgame/app/perf.js SquishPerf.meter, tools/chest/host.html
// chestHost.meter); the counter shows the page on top (the chest over the menu), else the app's own frames.
// The switch is kept across launches (a file, like the sound settings). It only shows for a tester account (App.js).
import { useSyncExternalStore } from 'react';
import * as FileSystem from 'expo-file-system';

const PATH = `${FileSystem.documentDirectory}fpsCounter.json`;
const ORDER = ['chest', 'menu']; // the one on top first
const STALE_MS = 1500; // no word from a page for this long: it's gone or hidden

let wanted = false; // the player's switch
let active = false; // the switch, for a tester account (App.js): what the pages are asked to report
const pages = {}; // name -> { fps, low, lite, at }
const subs = new Set();
const notify = () => subs.forEach((f) => f());
const subscribe = (f) => {
  subs.add(f);
  return () => subs.delete(f);
};

FileSystem.readAsStringAsync(PATH)
  .then((s) => {
    const v = !!JSON.parse(s).on;
    if (v !== wanted) {
      wanted = v;
      notify();
    }
  })
  .catch(() => {}); // never switched yet

export function setFpsWanted(v) {
  wanted = !!v;
  notify();
  FileSystem.writeAsStringAsync(PATH, JSON.stringify({ on: wanted })).catch(() => {});
}
export const useFpsWanted = () => useSyncExternalStore(subscribe, () => wanted);

export function setFpsActive(v) {
  if (active === !!v) return;
  active = !!v;
  if (!active) Object.keys(pages).forEach((k) => delete pages[k]);
  notify();
}
export const useFpsActive = () => useSyncExternalStore(subscribe, () => active);

// a page's reading (name: 'menu' | 'chest'), or null when it's gone
export function pageFps(name, m) {
  if (m) pages[name] = { fps: m.fps, low: m.low, lite: !!m.lite, at: Date.now() };
  else delete pages[name];
}

// the page on top with a fresh reading: { name, fps, low, lite }, or null
export function topPage() {
  const now = Date.now();
  for (const name of ORDER) {
    const p = pages[name];
    if (p && now - p.at < STALE_MS) return { name, ...p };
  }
  return null;
}
