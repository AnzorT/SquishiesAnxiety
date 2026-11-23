// node tools/unity/audio-test/run.mjs — what the app's own sound code does, for the C# port's test (Program.cs):
//
//   out/tables.json     sfx.js's EFFECTS and MUSIC as the module has them, the squish stage's files and volumes
//   out/names.json      every sound name the app's code can play (src/**, App.js), where, and what file it resolves to
//   out/formulas.json   each call site's rate / delay / volume formula, read out of its JS file and evaluated
//   out/rules.json      App.js's music, whoosh and coin rules (the effects' bodies, run as written) on stage sequences
//   out/scenarios.json  scripted and random sequences of calls (play, loop, preload, budgets, music, switches, the
//                       app going to the background, squish presses, haptics) ...
//   out/js-traces.json  ... and every player call the app's code made for each, on a virtual clock
//   out/synth.json      the menu's synth sounds (yard-games.js SFX): the tone / noise calls each makes
// Optionally `node tools/unity/audio-test/synth.mjs` (Chromium renders the same synth sounds, to compare samples).
// Then: dotnet run -c Release --project tools/unity/audio-test
import fs from 'node:fs';
import path from 'node:path';
import { register } from 'node:module';
import { fileURLToPath, pathToFileURL } from 'node:url';
import { Clock, settle } from './clock.mjs';

const HERE = path.dirname(fileURLToPath(import.meta.url));
const REPO = path.resolve(HERE, '../../..');
const OUT = path.join(HERE, 'out');
fs.mkdirSync(OUT, { recursive: true });
register('./loader.mjs', import.meta.url);
const T = (globalThis.__AT ??= { log: [], nextId: 1, files: {}, fail: new Set(), appState: 'active', appListeners: [] });
const url = (rel) => pathToFileURL(path.join(REPO, rel)).href;
const src = (rel) => fs.readFileSync(path.join(REPO, rel), 'utf8');
const write = (name, data) => fs.writeFileSync(path.join(OUT, name), JSON.stringify(data, null, 1));
const START = 1.7e12;

// a seeded generator for the random scenarios (mulberry32)
function rng(seed) {
  let a = seed;
  return () => {
    a |= 0;
    a = (a + 0x6d2b79f5) | 0;
    let t = Math.imul(a ^ (a >>> 15), 1 | a);
    t = (t + Math.imul(t ^ (t >>> 7), 61 | t)) ^ t;
    return ((t ^ (t >>> 14)) >>> 0) / 4294967296;
  };
}

// ---- 1. the tables -------------------------------------------------------------------------------------------------
new Clock(START).install();
const sfxMod = await import(url('src/audio/sfx.js') + '?tables');
const EFFECTS = sfxMod.__EFFECTS, MUSIC = sfxMod.__MUSIC;
const creatureFiles = (await import(url('src/audio/creatureSquishFiles.js'))).default;
const { squishSoundFor } = await import(url('src/audio/creatureSquish.js'));
const { CoinSound } = await import(url('src/audio/CoinSound.js'));
const { PopSound } = await import(url('src/audio/PopSound.js'));
const coin = new CoinSound(), pop = new PopSound();
const forIds = {};
for (const id of [...Object.keys(creatureFiles), '20', '999', 'custom']) forIds[id] = squishSoundFor({ id });
forIds['(audio url)'] = squishSoundFor({ id: '3', audio: 'https://example.invalid/x.mp3' });
forIds['(no creature)'] = squishSoundFor(null);
write('tables.json', {
  effects: EFFECTS,
  music: MUSIC,
  creatureSquish: creatureFiles,
  squishSoundFor: forIds,
  coin: { file: coin.source, volume: coin.volume },
  pop: { file: pop.source, volume: pop.volume },
});

// ---- 2. every name the app plays -------------------------------------------------------------------------------------
function jsFiles(dir) {
  const out = [];
  for (const e of fs.readdirSync(path.join(REPO, dir), { withFileTypes: true })) {
    const rel = path.join(dir, e.name);
    if (e.isDirectory()) out.push(...jsFiles(rel));
    else if (/\.js$/.test(e.name) && !/\.test\.js$/.test(e.name)) out.push(rel);
  }
  return out;
}
// the first argument of a call starting at text[i] (just after its '(')
function firstArg(text, i) {
  let depth = 0, q = null;
  const start = i;
  for (; i < text.length; i++) {
    const c = text[i];
    if (q) {
      if (c === '\\') i++;
      else if (c === q) q = null;
      continue;
    }
    if (c === "'" || c === '"' || c === '`') q = c;
    else if ('([{'.includes(c)) depth++;
    else if (')]}'.includes(c)) {
      if (depth === 0) return text.slice(start, i);
      depth--;
    } else if (c === ',' && depth === 0) return text.slice(start, i);
  }
  return text.slice(start);
}
const lineOf = (text, i) => text.slice(0, i).split('\n').length;
function literals(expr) {
  const names = [];
  // a comparison's literal isn't a name (s === 'GO!' ? 'sd_go' : 'sd_count')
  expr = expr.replace(/[!=]==?\s*(?:'[^']*'|"[^"]*")/g, '');
  for (const m of expr.matchAll(/'([^'\\]*)'|"([^"\\]*)"/g)) names.push(m[1] ?? m[2]);
  for (const m of expr.matchAll(/`([^`]*)`/g)) {
    // a template (`sd_star${i + 1}`): every value it takes for i = 0..2 (the stars)
    for (let i = 0; i < 3; i++) names.push(m[1].replace(/\$\{([^}]*)\}/g, (_, e) => String(new Function('i', 'return ' + e)(i))));
  }
  return names;
}
const sites = [];
const dynamic = [];
for (const rel of [...jsFiles('src'), 'App.js']) {
  if (rel.startsWith('src/audio/')) continue;
  const text = src(rel);
  for (const m of text.matchAll(/\bsfx\.(play|loop)\(/g)) {
    const arg = firstArg(text, m.index + m[0].length).trim();
    const names = literals(arg);
    const line = lineOf(text, m.index);
    if (!names.length) dynamic.push({ file: rel, line, arg });
    for (const n of names) sites.push({ name: n, file: rel, line, kind: m[1] });
  }
  for (const m of text.matchAll(/\bsound="(\w+)"/g)) sites.push({ name: m[1], file: rel, line: lineOf(text, m.index), kind: 'sound prop' });
  for (const m of text.matchAll(/\bsound = '(\w+)'/g)) sites.push({ name: m[1], file: rel, line: lineOf(text, m.index), kind: 'sound prop default' });
  for (const m of text.matchAll(/(?:sfx\.preload\(\[|const \w*_SOUNDS = \[)([^\]]*)\]/g))
    for (const n of literals(m[1])) sites.push({ name: n, file: rel, line: lineOf(text, m.index), kind: 'preload' });
}
// the dynamic ones must be covered: ui.js's SdButton plays its `sound` prop (collected above)
const covered = { 'src/squishdoku/ui.js': 'sound' };
const uncovered = dynamic.filter((d) => covered[d.file] !== d.arg);
for (const s of sites) s.file_ = EFFECTS[s.name] ?? null;
// the menu page's sounds (webgame/app/menu.js sfx('...')) are the yard games' synth
const menu = src('webgame/app/menu.js');
const menuSites = [...menu.matchAll(/\bsfx\('(\w+)'\)/g)].map((m) => ({ name: m[1], line: lineOf(menu, m.index) }));
write('names.json', { sites, dynamic, uncovered, menu: menuSites });

// ---- 3. the call sites' formulas ------------------------------------------------------------------------------------
const grab = (rel, re, what) => {
  const m = src(rel).match(re);
  if (!m) throw new Error(`${rel}: ${what} not found (${re})`);
  return m;
};
const ev = (expr, vars, vals, subst = []) => {
  let e = expr;
  for (const [a, b] of subst) e = e.split(a).join(b);
  return new Function(...vars, 'return (' + e + ');')(...vals);
};
const range = (a, b) => Array.from({ length: b - a + 1 }, (_, i) => a + i);
const formulas = [];
function formula(id, rel, expr, vars, inputs, subst) {
  formulas.push({ id, file: rel, expr, inputs, values: inputs.map((v) => ev(expr, vars, v, subst)) });
}
const one = (vals) => vals.map((v) => [v]);
const RND = [0, 0.1234, 0.5, 0.75, 0.999999];
{
  const rel = 'src/stack/Game.js';
  const e = grab(rel, /const rateOf = \(r\) => (.+);/, 'rateOf')[1];
  const ins = [];
  for (const n of range(1, 9)) for (const r of range(0, n - 1)) ins.push([r, n]);
  formula('Stack', rel, e, ['r', 'n'], ins, [['live.current.spec.n', 'n']]);
  for (const name of ['st_lift', 'st_cushion', 'st_land'])
    if (!new RegExp(`sfx\\.play\\('${name}', \\{ rate: rateOf\\(r\\) \\}\\)`).test(src(rel))) throw new Error(`${rel}: ${name} isn't rateOf(r)`);
  formula('StackRestart', rel, grab(rel, /sfx\.play\('st_undo', \{ rate: ([^}]+?) \}\)/, 'st_undo rate')[1], [], [[]]);
  formula('StackTick', rel, grab(rel, /sfx\.play\('sd_tick', \{ rate: (.+?) \}\)/, 'sd_tick')[1], ['s'], one(range(0, 30)));
  formula('BlitzPip', rel, grab(rel, /sfx\.play\('sd_pip', \{ rate: (.+?) \}\)/, 'sd_pip')[1], ['i'], one(range(0, 12)));
}
{
  const rel = 'src/sort/Game.js';
  formula('BlitzPip', rel, grab(rel, /sfx\.play\('sd_pip', \{ rate: (.+?) \}\)/, 'sd_pip')[1], ['i'], one(range(0, 12)));
  formula('SortDeal', rel, grab(rel, /sfx\.play\('fs_pop', \{ rate: (.+?) \}\)/, 'fs_pop')[1], ['n'], one(range(0, 20)));
  formula('SortDealGapMs', rel, grab(rel, /seats\.forEach\(\(slot, n\) =>\s*later\(n \* (\d+),/, 'the deal gap')[1], [], [[]]);
  formula('SortJumpAgain', rel, grab(rel, /sfx\.play\('fs_jump', \{ rate: (.+?) \}\)/, 'fs_jump')[1], [], [[]]);
}
for (const rel of ['src/squishdoku/BlitzGame.js', 'src/squishdoku/RegularGame.js']) {
  formula('SdPlace', rel, grab(rel, /sfx\.play\('sd_place', \{ rate: (.+?) \}\)/, 'sd_place')[1], ['combo'], one(range(0, 15)), [['g.combo', 'combo']]);
  formula('SdTick', rel, grab(rel, /sfx\.play\('sd_tick', \{ rate: (.+?) \}\)/, 'sd_tick')[1], ['sec'], one(range(0, 20)));
  formula('SdSqueak', rel, grab(rel, /sfx\.play\('sd_squeak', \{ rate: (.+?) \}\)/, 'sd_squeak')[1], ['rnd'], one(RND), [['Math.random()', 'rnd']]);
  const hop = grab(rel, /sfx\.play\('sd_hop', \{ delay: (.+?), rate: (.+?) \}\)/, 'sd_hop');
  const blitz = rel.includes('Blitz');
  formula(blitz ? 'SdBlitzHopDelay' : 'SdHopDelay', rel, hop[1], ['r'], one(range(0, 9)));
  formula(blitz ? 'SdBlitzHop' : 'SdHop', rel, hop[2], ['r'], one(range(0, 9)));
}
formula('SdBlitzPip', 'src/squishdoku/BlitzGame.js', grab('src/squishdoku/BlitzGame.js', /sfx\.play\('sd_pip', \{ rate: (.+?) \}\)/, 'sd_pip')[1], ['idx'], one(range(0, 20)));
formula('SdMarkDrag', 'src/squishdoku/RegularGame.js', grab('src/squishdoku/RegularGame.js', /dragged \? \{ rate: (.+?) \} : undefined/, 'sd_x rate')[1], ['rnd'], one(RND), [['Math.random()', 'rnd']]);
for (const rel of ['src/sort/LevelMap.js', 'src/squishdoku/LevelMap.js']) {
  const m = grab(rel, /for \(let k = 0; k < (\d+); k\+\+\) pops\.push\(setTimeout\(\(\) => sfx\.play\('sd_nodePop', \{ rate: (.+?) \}\), (.+?)\)\);/, 'the map pops');
  formula('MapPops', rel, m[1], [], [[]]);
  formula('MapPop', rel, m[2], ['k'], one(range(0, 5)));
  formula('MapPopAt', rel, m[3], ['k'], one(range(0, 5)));
}
{
  const rel = 'src/screens/GamePicker.js';
  const m = grab(rel, /setTimeout\(\(\) => sfx\.play\('sd_nodePop', \{ rate: (.+?) \}\), (.+?)\);/, 'the picker pops');
  formula('PickerPop', rel, m[1], ['index'], one(range(0, 6)));
  formula('PickerPopAt', rel, m[2], ['index'], one(range(0, 6)));
}
for (const rel of ['src/stack/Cards.js', 'src/sort/Cards.js', 'src/hop/Cards.js']) {
  const step = grab(rel, /const STEP = (\d+);/, 'STEP')[1];
  const m = grab(rel, /setTimeout\(\(\) => sfx\.play\((i < res\.stars \? `sd_star\$\{i \+ 1\}` : 'sd_starEmpty')\), (.+?)\)\)/, 'the stars');
  const ins = [];
  for (const i of range(0, 2)) for (const s of range(0, 3)) ins.push([i, s]);
  formula('Star', rel, m[1], ['i', 'stars'], ins, [['res.stars', 'stars']]);
  formula('StarAt', rel, m[2], ['i'], one(range(0, 3)), [['STEP', step]]);
}
{
  const rel = 'src/squishdoku/Overlays.js';
  const step = grab(rel, /const STEP = (\d+);/, 'STEP')[1];
  const m = grab(rel, /at\((.+?), \(\) => sfx\.play\((i < res\.stars \? `sd_star\$\{i \+ 1\}` : 'sd_starEmpty')\)\)/, 'the stars');
  const ins = [];
  for (const i of range(0, 2)) for (const s of range(0, 3)) ins.push([i, s]);
  formula('Star', rel, m[2], ['i', 'stars'], ins, [['res.stars', 'stars']]);
  formula('SdStarAt', rel, m[1], ['i'], one(range(0, 3)), [['STEP', step]]);
}
{
  const rel = 'src/components/CreatureCard.js';
  const P = [0, 0.01, 0.05, 0.1, 0.25, 0.5, 0.73, 0.99, 1];
  formula('HoldStartVolume', rel, grab(rel, /sfx\.loop\('holdLoop', \{ volume: (.+?) \}\)/, 'holdLoop')[1], [], [[]]);
  formula('HoldRate', rel, grab(rel, /const rate = (.+);/, 'the rate')[1], ['p'], one(P));
  formula('HoldVolume', rel, grab(rel, /hum\.setVolume\((.+)\);/, 'the volume')[1], ['p'], one(P));
  formula('HoldStep', rel, 'Math.floor(' + grab(rel, /const step = Math\.floor\((.+)\);/, 'the step')[1] + ')', ['p'], one(P));
  formula('HoldRateEpsilon', rel, grab(rel, /Math\.abs\(rate - lastRate\) > (.+?)\)/, 'the threshold')[1], [], [[]]);
}
write('formulas.json', formulas);

// ---- 4. App.js's rules, the effects' bodies run as written ----------------------------------------------------------
const app = src('App.js');
function effectBody(marker, deps) {
  const i = app.indexOf(marker);
  if (i < 0) throw new Error('App.js: ' + marker + ' not found');
  const a = app.lastIndexOf('useEffect(() => {', i);
  const b = app.indexOf('}, ' + deps + ');', i);
  return app.slice(a + 'useEffect(() => {'.length, b);
}
const musicForExpr = grab('App.js', /const musicFor = \(stage, onGame\) => (.+);/, 'musicFor')[1];
const musicFor = new Function('stage', 'onGame', 'return (' + musicForExpr + ');');
const musicBody = effectBody('sfx.music(fontsLoaded ? musicFor(stage, onGame) : null)', '[stage, fontsLoaded, onGame]');
const musicEffect = new Function('stage', 'onGame', 'fontsLoaded', 'musicFor', 'sfx', musicBody);
const STAGES = ['splash', 'auth', 'verify', 'home', 'toy', 'loading', 'wheel', 'streak', 'shop', 'settings', 'crib', 'squishdoku', 'sort', 'stack', 'hop', 'road', 'achievements', 'stats', 'create', 'box', 'squad'];
const music = [];
for (const stage of STAGES)
  for (const onGame of [false, true]) {
    let got = 'unchanged';
    musicEffect(stage, onGame, true, musicFor, { music: (n) => (got = n) });
    music.push({ stage, onGame, musicFor: musicFor(stage, onGame), effect: got });
  }
const whooshBody = effectBody("sfx.play('whoosh')", '[stage]');
const coinsBody = effectBody("sfx.play(coinsNow > prev ? 'coinShower' : 'spend')", '[coinsNow]');
const R = rng(77);
const whoosh = [], coins = [];
for (let k = 0; k < 40; k++) {
  const seq = Array.from({ length: 12 }, () => STAGES[Math.floor(R() * STAGES.length)]);
  if (k === 0) seq[0] = 'splash';
  const prevStageRef = { current: seq[0] };
  const out = seq.map((stage) => {
    let w = false;
    new Function('stage', 'prevStageRef', 'sfx', whooshBody)(stage, prevStageRef, { play: (n) => (w = n === 'whoosh') });
    return w;
  });
  whoosh.push({ seq, out });
  const cs = Array.from({ length: 12 }, () => (R() < 0.15 ? null : Math.floor(R() * 4) * 10));
  const st = Array.from({ length: 12 }, () => (R() < 0.2 ? (R() < 0.5 ? 'toy' : 'box') : 'home'));
  const prevCoinsRef = { current: cs[0] };
  const cout = cs.map((coinsNow, j) => {
    let s = null;
    new Function('coinsNow', 'stage', 'prevCoinsRef', 'sfx', coinsBody)(coinsNow, st[j], prevCoinsRef, { play: (n) => (s = n) });
    return s;
  });
  coins.push({ coins: cs, stages: st, out: cout });
}
write('rules.json', { musicForExpr, musicBody: musicBody.trim(), music, whoosh, coins });

// ---- 5. behaviour: scenarios and the player calls they make ---------------------------------------------------------
const NAMES = Object.keys(EFFECTS);
const PRELOADS = [
  ['fs_pop', 'fs_peek', 'fs_doorClose', 'fs_doorOpen', 'fs_rattle', 'fs_jump', 'fs_land', 'fs_tumble', 'fs_pick', 'fs_drop', 'fs_snap', 'fs_wrong', 'fs_impostor', 'fs_swap', 'fs_heart', 'fs_mixed', 'sd_tick', 'sd_solve', 'sd_confetti', 'sd_boardIn'],
  ['st_lift', 'st_land', 'st_cushion', 'st_ouch', 'st_bounce', 'st_undo', 'st_hint', 'st_empty', 'st_news', 'sd_tick', 'sd_solve', 'sd_confetti', 'sd_boardIn', 'sd_timeUp'],
  ['sd_place', 'sd_wrong', 'sd_x', 'sd_xOff', 'sd_squeak', 'sd_tick', 'sd_starLost', 'sd_mode', 'sd_modeOff', 'sd_boardIn', 'sd_pause', 'sd_resume', 'sd_hop', 'sd_solve', 'sd_timeUp', 'sd_select', 'fs_heart', 'sd_blitzFail'],
  ['tap', 'nope', 'whoosh', 'boxBell'],
];
function randomSfx(seed) {
  const r = rng(seed);
  const pick = (a) => a[Math.floor(r() * a.length)];
  const hot = Array.from({ length: 3 + Math.floor(r() * 14) }, () => pick(NAMES)).concat(['tap', 'boxBell', 'nope']);
  const files = [null, null, '{"effects":true,"music":true}', '{"effects":false,"music":true}', '{"music":false}', 'garbage{', 'null', '{"effects":false,"music":false}'];
  const sc = { kind: 'sfx', id: 'random-' + seed, start: START + Math.floor(r() * 1e6), file: pick(files), fail: r() < 0.2 ? [EFFECTS[pick(hot)] ?? 'x'] : [], active: r() < 0.9, steps: [] };
  let at = sc.start;
  if (r() < 0.9) sc.steps.push({ at, op: 'init' });
  let loops = 0;
  for (let k = 0; k < 70; k++) {
    at += pick([0, 0, 16, 33, 50, 60, 99, 100, 101, 140, 250, 400, 900, 1300]);
    const x = r();
    let st;
    if (x < 0.5) {
      st = { op: 'play', name: pick(hot) };
      if (r() < 0.3) st.rate = pick([0.8, 0.9, 1.12, 1.3, 0, 2]);
      if (r() < 0.15) st.delay = pick([70, 120, 250, 0]);
    } else if (x < 0.57) st = { op: 'preload', names: pick(PRELOADS) };
    else if (x < 0.62) st = { op: 'budget', n: pick([null, 26, 28, 30, 3, 1]) };
    else if (x < 0.7) st = { op: 'music', name: pick(['theme', 'theme', null, 'bogus']) };
    else if (x < 0.74) st = { op: 'effects', on: r() < 0.6 };
    else if (x < 0.79) st = { op: 'musicOn', on: r() < 0.6 };
    else if (x < 0.83) st = { op: 'active', on: r() < 0.6 };
    else if (x < 0.88) st = { op: 'loop', name: pick(['holdLoop', 'reelLoop', 'whirlLoop', 'nope']), h: loops++, volume: r() < 0.5 ? 0.42 : undefined, rate: r() < 0.3 ? 1.5 : undefined };
    else if (x < 0.96 && loops) st = { op: pick(['loopRate', 'loopVolume', 'loopStop']), h: Math.floor(r() * loops), v: Math.round(r() * 200) / 100 };
    else st = { op: 'play', name: 'tap' };
    st.at = at;
    sc.steps.push(st);
  }
  sc.end = at + 3000;
  return sc;
}
const handmade = [
  // the app starting: no file, the splash, then the theme, buttons
  { kind: 'sfx', id: 'start', start: START, file: null, fail: [], active: true, end: START + 9000,
    steps: [{ at: START, op: 'init' }, { at: START, op: 'music', name: null }, { at: START + 2500, op: 'music', name: 'theme' }, { at: START + 2600, op: 'play', name: 'whoosh' },
      { at: START + 3000, op: 'play', name: 'tap' }, { at: START + 3050, op: 'play', name: 'tap' }, { at: START + 3101, op: 'play', name: 'tap' }, { at: START + 3200, op: 'music', name: 'theme' },
      { at: START + 3300, op: 'musicOn', on: false }, { at: START + 3700, op: 'musicOn', on: true }, { at: START + 4000, op: 'active', on: false }, { at: START + 4100, op: 'play', name: 'tap' },
      { at: START + 5000, op: 'active', on: true }, { at: START + 5600, op: 'music', name: null }] },
  // remembered: music off
  { kind: 'sfx', id: 'music-off', start: START, file: '{"effects":true,"music":false}', fail: [], active: true, end: START + 4000,
    steps: [{ at: START, op: 'init' }, { at: START + 10, op: 'music', name: 'theme' }, { at: START + 500, op: 'musicOn', on: true }, { at: START + 900, op: 'musicOn', on: false }] },
  // a Squishdoku visit: its budget, preloads, a burst of plays, back
  { kind: 'sfx', id: 'squishdoku', start: START, file: null, fail: [], active: true, end: START + 8000,
    steps: [{ at: START, op: 'init' }, { at: START + 100, op: 'budget', n: 30 }, { at: START + 100, op: 'preload', names: PRELOADS[2] },
      ...['sd_place', 'sd_place', 'sd_wrong', 'sd_x', 'sd_xOff', 'sd_star1', 'sd_star2', 'sd_star3', 'sd_perfect', 'sd_coinTick', 'sd_coinTick', 'sd_hop', 'sd_hop'].map((name, i) => ({ at: START + 300 + i * 37, op: 'play', name, rate: i % 3 ? 1 + i * 0.06 : undefined, delay: i % 5 === 4 ? 75 : undefined })),
      { at: START + 2000, op: 'budget', n: null }, { at: START + 2050, op: 'play', name: 'sd_boardOut' }] },
  // two voices round robin, and a file that won't load
  { kind: 'sfx', id: 'voices', start: START, file: null, fail: ['sfx/boxBell.wav'], active: true, end: START + 2000,
    steps: [{ at: START, op: 'init' }, ...[0, 40, 80, 120].map((d) => ({ at: START + 10 + d, op: 'play', name: 'boxBell' })), { at: START + 300, op: 'play', name: 'boxOpen' }] },
  // loops: the hold's hum, effects off and on, the background
  { kind: 'sfx', id: 'loops', start: START, file: null, fail: [], active: true, end: START + 3000,
    steps: [{ at: START, op: 'init' }, { at: START + 10, op: 'loop', name: 'holdLoop', h: 0, volume: 0.42 }, { at: START + 50, op: 'loopRate', h: 0, v: 1.5 }, { at: START + 60, op: 'loopVolume', h: 0, v: 0.8 },
      { at: START + 70, op: 'loop', name: 'reelLoop', h: 1 }, { at: START + 100, op: 'active', on: false }, { at: START + 200, op: 'active', on: true }, { at: START + 300, op: 'effects', on: false },
      { at: START + 310, op: 'loop', name: 'whirlLoop', h: 2 }, { at: START + 400, op: 'active', on: false }, { at: START + 500, op: 'active', on: true }, { at: START + 600, op: 'effects', on: true },
      { at: START + 700, op: 'loopStop', h: 0 }, { at: START + 710, op: 'loopStop', h: 0 }, { at: START + 720, op: 'loopStop', h: 1 }, { at: START + 730, op: 'loopStop', h: 2 }] },
];
const scenarios = [...handmade];
for (let s = 1; s <= 80; s++) scenarios.push(randomSfx(1000 + s));

// the squish stage: SquishSound (press / move / release), CoinSound and PopSound, squishHaptics, makeHaptics
for (let s = 1; s <= 30; s++) {
  const r = rng(5000 + s);
  const pick = (a) => a[Math.floor(r() * a.length)];
  let at = START;
  const steps = [{ at, op: 'load' }];
  for (let k = 0; k < 50; k++) {
    at += pick([0, 5, 16, 20, 33, 60, 100, 179, 180, 181, 250, 350, 400, 600]);
    steps.push({ at, op: pick(['start', 'motion', 'motion', 'motion', 'stop', 'stop', r() < 0.1 ? 'unload' : 'motion']) });
  }
  scenarios.push({ kind: 'squish', id: 'squish-' + s, start: START, file: pick(['creatures/3.ogg', 'slime.wav']), fail: r() < 0.1 ? ['slime.wav', 'creatures/3.ogg'] : [], steps, end: at + 2000 });
  const shots = [{ at: START, op: r() < 0.7 ? 'load' : 'play' }];
  at = START;
  for (let k = 0; k < 20; k++) {
    at += pick([0, 16, 33, 90]);
    shots.push({ at, op: r() < 0.9 ? 'play' : 'unload' });
  }
  scenarios.push({ kind: 'oneshot', id: 'oneshot-' + s, which: pick(['coin', 'pop']), start: START, file: null, fail: r() < 0.1 ? ['coin.mp3', 'pop.mp3'] : [], steps: shots, end: at + 100 });
  const hs = [];
  at = START;
  for (let k = 0; k < 60; k++) {
    at += pick([0, 10, 30, 64, 65, 66, 70, 74, 75, 76, 90, 110, 150, 200]);
    hs.push({ at, op: pick(['press', 'move', 'move', 'move', 'move', 'release']), strength: pick([1, 2, 3, 4, 5, null, 0, 2.5, 3.5, 4.49, 7, -2]) });
  }
  scenarios.push({ kind: 'squishHaptics', id: 'haptics-' + s, start: START, file: null, fail: [], steps: hs, end: at + 200 });
}
for (const on of [true, false])
  scenarios.push({ kind: 'gameHaptics', id: 'game-haptics-' + on, on, start: START, file: null, fail: [], end: START + 100,
    steps: ['tap', 'place', 'wrong', 'win', 'tick'].map((op, i) => ({ at: START + i * 10, op })) });

const FILE_KEY = 'file:///doc/soundSettings.json';
async function run(sc, n) {
  T.log = [];
  T.nextId = 1;
  T.files = sc.file == null ? {} : { [FILE_KEY]: sc.file };
  T.fail = new Set(sc.fail);
  T.appState = sc.active === false ? 'background' : 'active';
  T.appListeners = [];
  const clock = new Clock(sc.start);
  clock.install();
  const q = '?run=' + n;
  if (sc.kind === 'sfx') {
    const sfx = (await import(url('src/audio/sfx.js') + q)).default;
    sfx.subscribe((s) => T.log.push([Date.now(), 'notify', s.effects, s.music]));
    const loops = [];
    for (const st of sc.steps) {
      await clock.advanceTo(st.at);
      switch (st.op) {
        case 'init': await sfx.init(); break;
        case 'play': sfx.play(st.name, st.delay === undefined && st.rate === undefined ? undefined : { delay: st.delay, rate: st.rate }); break;
        case 'preload': sfx.preload(st.names); break;
        case 'budget': sfx.setBudget(st.n); break;
        case 'music': sfx.music(st.name); break;
        case 'effects': sfx.setEffectsOn(st.on); break;
        case 'musicOn': sfx.setMusicOn(st.on); break;
        case 'active': {
          const next = st.on ? 'active' : 'background';
          T.appState = next;
          T.appListeners.forEach((fn) => fn(next));
          break;
        }
        case 'loop': loops[st.h] = sfx.loop(st.name, st.volume === undefined && st.rate === undefined ? undefined : { volume: st.volume, rate: st.rate }); break;
        case 'loopRate': loops[st.h].setRate(st.v); break;
        case 'loopVolume': loops[st.h].setVolume(st.v); break;
        case 'loopStop': loops[st.h].stop(); break;
        default: throw new Error(st.op);
      }
      await settle();
    }
  } else if (sc.kind === 'squish') {
    const { SquishSound } = await import(url('src/audio/SquishSound.js') + q);
    let s = new SquishSound();
    for (const st of sc.steps) {
      await clock.advanceTo(st.at);
      if (st.op === 'load') await s.load(sc.file);
      else if (st.op === 'start') s.start();
      else if (st.op === 'motion') s.noteMotion();
      else if (st.op === 'stop') s.stop();
      else if (st.op === 'unload') await s.unload();
      await settle();
    }
  } else if (sc.kind === 'oneshot') {
    const { OneShotSound } = await import(url('src/audio/OneShotSound.js') + q);
    const s = sc.which === 'coin' ? new OneShotSound(coin.source, coin.volume) : new OneShotSound(pop.source, pop.volume);
    for (const st of sc.steps) {
      await clock.advanceTo(st.at);
      if (st.op === 'load') await s.load();
      else if (st.op === 'play') await s.play();
      else if (st.op === 'unload') await s.unload();
      await settle();
    }
  } else if (sc.kind === 'squishHaptics') {
    const H = await import(url('src/haptics/squishHaptics.js') + q);
    for (const st of sc.steps) {
      await clock.advanceTo(st.at);
      H[st.op + 'Haptic'](st.strength);
      await settle();
    }
  } else if (sc.kind === 'gameHaptics') {
    const { makeHaptics } = await import(url('src/squishdoku/game.js') + q);
    const h = makeHaptics(sc.on);
    for (const st of sc.steps) {
      await clock.advanceTo(st.at);
      h[st.op]();
      await settle();
    }
  }
  await clock.advanceTo(sc.end);
  return T.log.map((e) => e.map((v) => (v === undefined ? null : v)));
}
const traces = {};
let n = 0;
for (const sc of scenarios) traces[sc.id] = await run(sc, ++n);
write('scenarios.json', scenarios);
write('js-traces.json', traces);

// ---- 6. the menu's synth sounds ---------------------------------------------------------------------------------------
let synth = null;
try {
  const { extractPrototype } = await import(url('webgame/lib/prototype.mjs'));
  const proto = await extractPrototype();
  const yg = fs.readFileSync(path.join(proto, 'yard-games.js'), 'utf8');
  const m = yg.match(/const SFX = (\{[\s\S]*?\n\s*win: [^\n]*\});/);
  if (!m) throw new Error('yard-games.js: SFX not found');
  const calls = {};
  let cur = null;
  const fmt = (v) => (v === undefined ? 'u' : String(v));
  const SFX = new Function('tone', 'noise', 'return ' + m[1])(
    (f0, f1, dur, type, vol, delay) => calls[cur].push(['tone', f0, f1, dur, type, vol, delay].map(fmt).join(' ')),
    (dur, vol, lp, delay) => calls[cur].push(['noise', dur, vol, lp, delay].map(fmt).join(' ')),
  );
  for (const k of Object.keys(SFX)) {
    cur = k;
    calls[k] = [];
    SFX[k]();
  }
  const mute = /muted = localStorage\.getItem\(LS \+ '\.mute'\) === '1'/.test(yg) && /const LS = 'yardgames\.v1'/.test(yg);
  synth = { calls, mute, source: path.relative(REPO, path.join(proto, 'yard-games.js')) };
} catch (e) {
  console.log('(menu synth: ' + e.message + ')');
}
write('synth.json', synth);

const total = Object.values(traces).reduce((a, t) => a + t.length, 0);
console.log(`tables: ${NAMES.length} effects, ${Object.keys(MUSIC).length} music, ${Object.keys(creatureFiles).length} creature loops`);
console.log(`names: ${sites.length} uses in src (${new Set(sites.map((s) => s.name)).size} names), ${dynamic.length} dynamic (${uncovered.length} not covered), menu.js: ${menuSites.length}`);
console.log(`formulas: ${formulas.length}, rules: ${music.length} music / ${whoosh.length} whoosh / ${coins.length} coin sequences`);
console.log(`scenarios: ${scenarios.length}, ${total} player calls recorded`);
console.log(`synth: ${synth ? Object.keys(synth.calls).length + ' sounds' : 'skipped'}`);
