// The app's side of the saves test: the steps of a plan played the way the app's screens play them, with the app's own
// code: the games' levels.js work the outcome out from the profile (profileRef.current: the document as the
// app's listener has it), and src/firebase/firestore.js saveStack / saveSort / saveHop / saveSquishdoku write it, as
// src/stack/Game.js, src/sort/Game.js, src/hop/Game.js, src/squishdoku/RegularGame.js / BlitzGame.js and the screens'
// `seen` / HEAD START writes call them; Squishdoku's gem save is src/squad/api.js blitzSave (the `squad` callable).
//
//   node --import ./register.mjs app.mjs <plan.json> <log.json>
//   plan: { email, password, steps: [{ do: 'stack.win', lv, par, moves, hinted }, …] }   (Program.cs writes it)
//   log:  per step { do, update, coins, xp, levelUps, error }
import fs from 'node:fs';
import { signInWithEmailAndPassword } from 'firebase/auth';
import { doc, getDoc } from 'firebase/firestore';
import { auth, db, idle } from './shims/emulator.mjs';
import { saveHop, saveSort, saveSquishdoku, saveStack } from '../../../src/firebase/firestore.js';
import * as stack from '../../../src/stack/levels.js';
import * as sort from '../../../src/sort/levels.js';
import * as hop from '../../../src/hop/levels.js';
import * as sdk from '../../../src/squishdoku/levels.js';
import * as squad from '../../../src/squad/api.js';

const [planPath, logPath] = process.argv.slice(2);
const plan = JSON.parse(fs.readFileSync(planPath, 'utf8'));
await signInWithEmailAndPassword(auth, plan.email, plan.password);
const uid = auth.currentUser.uid;

const read = async () => (await getDoc(doc(db, 'users', uid))).data();
const said = (out) => ({ update: out.update, coins: out.coins || 0, xp: out.xp || 0, levelUps: out.levelUps || [] });

// each step: (profile, args) → what it saved
const STEPS = {
  // StackScreen.js: the first visit
  'stack.seen': (p) => {
    if (stack.record(p).seen) return { update: {} };
    saveStack(uid, { 'stack.seen': true }, 0);
    return { update: { 'stack.seen': true } };
  },
  // Game.js win() / lose()
  'stack.win': (p, a) => {
    const spec = stack.levelSpec(a.lv, stack.record(p).skill);
    const out = stack.afterLevel(p, spec, a.par, { won: true, moves: a.moves, hinted: a.hinted });
    saveStack(uid, out.update, out.coins, out.xp, p);
    return said(out);
  },
  'stack.lose': (p, a) => {
    const spec = stack.levelSpec(a.lv, stack.record(p).skill);
    const out = stack.afterLevel(p, spec, a.par, { won: false });
    saveStack(uid, out.update, 0);
    return { update: out.update };
  },
  // Blitz: payOut() (the run over, or left in the middle): what the cleared puzzles paid
  'stack.blitz': (p, a) => {
    const out = stack.afterBlitz(p, { cleared: a.cleared });
    saveStack(uid, out.update, out.coins, out.xp, p);
    return said(out);
  },

  'sort.seen': (p) => {
    if (sort.record(p).seen) return { update: {} };
    saveSort(uid, { 'sort.seen': true }, 0);
    return { update: { 'sort.seen': true } };
  },
  'sort.win': (p, a) => {
    const spec = sort.levelSpec(a.lv, sort.record(p)[a.theme].skill);
    const out = sort.afterLevel(p, a.theme, spec, { won: true, mistakes: a.mistakes, ms: a.ms });
    saveSort(uid, out.update, out.coins, out.xp, p);
    return said(out);
  },
  'sort.lose': (p, a) => {
    const spec = sort.levelSpec(a.lv, sort.record(p)[a.theme].skill);
    const out = sort.afterLevel(p, a.theme, spec, { won: false, mistakes: a.mistakes });
    saveSort(uid, out.update, 0);
    return { update: out.update };
  },
  'sort.blitz': (p, a) => {
    const out = sort.afterBlitz(p, { cleared: a.cleared });
    saveSort(uid, out.update, out.coins, out.xp, p);
    return said(out);
  },

  // HopScreen.js: the first visit; Game.js win(), retry() after getting stuck, payOut() (Blitz)
  'hop.seen': (p) => {
    if (hop.record(p).seen) return { update: {} };
    saveHop(uid, { 'hop.seen': true }, 0);
    return { update: { 'hop.seen': true } };
  },
  'hop.win': (p, a) => {
    const out = hop.afterLevel(p, hop.levelSpec(a.lv), { takebacks: a.takebacks, hinted: a.hinted });
    saveHop(uid, out.update, out.coins, out.xp, p);
    return said(out);
  },
  'hop.stuck': (p) => {
    const update = hop.afterStuck(p);
    saveHop(uid, update, 0);
    return { update };
  },

  'hop.blitz': (p, a) => {
    const out = hop.afterBlitz(p, { cleared: a.cleared });
    saveHop(uid, out.update, out.coins, out.xp, p);
    return said(out);
  },

  // SquishdokuScreen.js toggleHead; RegularGame.js solved() / timeUp() (and outOfHearts); BlitzGame.js settle(),
  // saveByGems()
  'sdk.head': (p, a) => {
    saveSquishdoku(uid, { 'sdk.head': a.on }, 0);
    return { update: { 'sdk.head': a.on } };
  },
  'sdk.win': (p, a) => {
    const spec = sdk.levelSpec(a.lv, a.head);
    const out = sdk.afterLevel(p, spec, { solved: true, ms: a.ms, mistakes: a.mistakes, stars: a.stars, perfect: a.perfect });
    saveSquishdoku(uid, out.update, out.coins, out.xp, p);
    return said(out);
  },
  'sdk.lose': (p, a) => {
    const r = sdk.afterLevel(p, sdk.levelSpec(a.lv, a.head), { solved: false });
    saveSquishdoku(uid, r.update, 0);
    return { update: r.update };
  },
  'sdk.blitz': (p, a) => {
    const out = sdk.afterBlitz(p, { cleared: a.cleared });
    saveSquishdoku(uid, out.update, out.coins, out.xp, p);
    return said(out);
  },
  'sdk.gemSave': async (p, a) => {
    try {
      const res = await squad.blitzSave(a.i);
      return { update: {}, paid: res && res.gems };
    } catch (e) {
      return { update: {}, error: String((e && e.message) || e) };
    }
  },
};

const log = [];
for (const step of plan.steps) {
  const fn = STEPS[step.do];
  if (!fn) throw new Error(`no such step: ${step.do}`);
  const r = await fn(await read(), step);
  await idle();
  log.push({ do: step.do, ...r });
}
fs.writeFileSync(logPath, JSON.stringify(log, null, 2));
process.exit(0);
