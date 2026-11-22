// The weather the game shows: the main menu's world, the house (its map, the Dance Room's glass dome, the beach) and
// Squish Stack's forest (2026-11-21, the user: Firebase says how many weathers we have; more than one, we pick today's).
//
// Firestore config/weather, edited by hand in the Firebase console:
//   { options: ['sunny', 'rainy', 'snowy'] }
// - one option: the game always shows that weather;
// - more than one: today's weather by the month, as before (December-February snowy, May-September sunny, the other
//   months rainy); if that one isn't in the list, the first in the list;
// - no doc, or nothing usable in it: all three (the game as it was).
// App.js passes the doc in (setWeatherConfig) as it changes; the menu's pages get today's weather in the state the app
// sends them (src/game/player.js `weather`, read by webgame/app/bridge.js SquishWeatherNow).
export const WEATHERS = ['sunny', 'rainy', 'snowy'];

let options = WEATHERS;

export function setWeatherConfig(cfg) {
  // (a list; one text, or several split by commas, as typed in the console, counts too)
  const raw = cfg && cfg.options, arr = Array.isArray(raw) ? raw : typeof raw === 'string' ? raw.split(',') : [];
  const list = arr.map((o) => String(o).trim().toLowerCase());
  const ok = list.filter((o, i) => WEATHERS.includes(o) && list.indexOf(o) === i);
  options = ok.length ? ok : WEATHERS;
}

export const weatherOptions = () => options;

// the month's weather (the design's own rule: main-menu-scene.js autoSeason)
export const weatherByMonth = (d = new Date()) => {
  const mo = d.getMonth();
  return mo === 11 || mo <= 1 ? 'snowy' : mo >= 4 && mo <= 8 ? 'sunny' : 'rainy';
};

export function weatherToday(d = new Date()) {
  if (options.length === 1) return options[0];
  const m = weatherByMonth(d);
  return options.includes(m) ? m : options[0];
}
