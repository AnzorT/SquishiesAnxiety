// Shows or changes Firestore config/roster: which groups are out ({ groups: { snack: true, spooky: false, ... } },
// one switch per group: only the groups switched on are out, and the Firebase console can flip them too),
// single creatures held back ({ hidden: [creature id] }),
// and the set-reward rule ({ setRewards: true | false }). Until the doc has them they are
// functions/squad.js HIDDEN (the Masked and Elemental Heroes) and SET_REWARDS (off). The app and the
// server both read the doc, so a change shows the next time the Shop or the Squad grid draws and holds
// for the very next chest opened: no app update, no deploy.
// A hidden group has no chest in the Shop, is never HOT (free chest, ad chest, daily deal, streak,
// bundles) and its creatures can't be bought; a player who owns one already keeps it and still sees it.
// Set rewards off: a set's reward creature drops from its group's chests as a Legendary, and finishing
// a set brings nothing extra. On: the design's rule (the reward and 2,000 coins for finishing the set).
// The Rainbow chest ({ rainbow: 'chest' | 'shop' }, functions/squad.js RAINBOW; 'chest' until set):
// 'chest' — not sold; each group's one is earned by unlocking the rest of the group and holds its
// Rainbow creature (set rewards are off then); 'shop' — sold in the Shop as before, and the set-reward
// rule above applies.
//
//   GOOGLE_APPLICATION_CREDENTIALS=<key.json> node tools/admin/roster.mjs                   (shows it)
//   GOOGLE_APPLICATION_CREDENTIALS=<key.json> node tools/admin/roster.mjs --groups          (writes the switches
//                                                                                            as things are now)
//   GOOGLE_APPLICATION_CREDENTIALS=<key.json> node tools/admin/roster.mjs --show elemental  (switches it on)
//   GOOGLE_APPLICATION_CREDENTIALS=<key.json> node tools/admin/roster.mjs --hide heroes     (switches it off)
//   GOOGLE_APPLICATION_CREDENTIALS=<key.json> node tools/admin/roster.mjs --set-rewards on  (or off)
//   GOOGLE_APPLICATION_CREDENTIALS=<key.json> node tools/admin/roster.mjs --rainbow chest   (or shop)
// --show / --hide take group keys (heroes, elemental, spooky…) or creature ids (79), several at once.
import { createRequire } from 'node:module';
import path from 'node:path';
import { fileURLToPath } from 'node:url';

const ROOT = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '../..');
const require = createRequire(path.join(ROOT, 'functions', 'package.json'));
const { initializeApp, applicationDefault } = require('firebase-admin/app');
const { getFirestore } = require('firebase-admin/firestore');
const { GROUPS, BY_ID, hiddenOf, setRewardsOf, rainbowOf } = require(path.join(ROOT, 'functions', 'squad.js'));

if (!process.env.GOOGLE_APPLICATION_CREDENTIALS) {
  console.error('Set GOOGLE_APPLICATION_CREDENTIALS to the service-account key.');
  process.exit(1);
}
const [flag, ...names] = process.argv.slice(2);
if (flag && !['--show', '--hide', '--set-rewards', '--rainbow', '--groups'].includes(flag)) {
  console.error('Use --show or --hide, then group keys or creature ids; or --groups; or --set-rewards on|off; or --rainbow chest|shop.');
  process.exit(1);
}
if (flag === '--rainbow' && !['chest', 'shop'].includes(names[0])) {
  console.error('--rainbow takes chest or shop.');
  process.exit(1);
}
if (flag === '--set-rewards' && !['on', 'off'].includes(names[0])) {
  console.error('--set-rewards takes on or off.');
  process.exit(1);
}
const unknown = flag === '--set-rewards' || flag === '--rainbow' || flag === '--groups' ? [] : names.filter((n) => !GROUPS.some((g) => g.key === n) && !BY_ID[n]);
if (unknown.length) {
  console.error(`Not a group key or creature id: ${unknown.join(', ')} (groups: ${GROUPS.map((g) => g.key).join(', ')})`);
  process.exit(1);
}
const db = getFirestore(initializeApp({ credential: applicationDefault(), projectId: 'squishy-app-61445' }));
const ref = db.collection('config').doc('roster');
const snap = await ref.get();
const cfg = snap.exists ? snap.data() : null;
let hidden = hiddenOf(cfg);
const GROUP_KEYS = GROUPS.map((g) => g.key);
// the switches: the doc's, else what's out now (the older hidden list, or squad.js HIDDEN)
const groupsOf = (c) => (c && c.groups && typeof c.groups === 'object' ? { ...c.groups } : Object.fromEntries(GROUP_KEYS.map((k) => [k, !hiddenOf(c).includes(k)])));
const idsOf = (c) => (c && Array.isArray(c.hidden) ? c.hidden.map(String) : []).filter((x) => !GROUP_KEYS.includes(x));
let setRewards = setRewardsOf(cfg);
let rainbow = rainbowOf(cfg);
if (flag === '--set-rewards') {
  await ref.set({ setRewards: names[0] === 'on' }, { merge: true });
  setRewards = setRewardsOf({ ...cfg, setRewards: names[0] === 'on' });
  console.log('config/roster written');
} else if (flag === '--rainbow') {
  rainbow = names[0];
  await ref.set({ rainbow }, { merge: true });
  setRewards = setRewardsOf({ ...cfg, rainbow });
  console.log('config/roster written');
} else if (flag === '--groups' || (flag && names.length)) {
  const groups = groupsOf(cfg);
  let ids = idsOf(cfg);
  for (const n of names) {
    if (GROUP_KEYS.includes(n)) groups[n] = flag === '--show';
    else ids = flag === '--show' ? ids.filter((x) => x !== n) : [...new Set([...ids, n])];
  }
  for (const k of GROUP_KEYS) if (typeof groups[k] !== 'boolean') groups[k] = false;
  await ref.set({ groups, hidden: ids }, { merge: true });
  hidden = hiddenOf({ ...cfg, groups, hidden: ids });
  console.log('config/roster written');
}
console.log('Groups: ' + GROUP_KEYS.map((k) => `${k} ${!hidden.includes(k) ? 'ON' : 'off'}`).join(', '));
const label = (k) => (BY_ID[k] ? `${BY_ID[k].name} (#${k})` : (GROUPS.find((g) => g.key === k) || {}).name || k);
console.log(hidden.length ? `Not out yet: ${hidden.map(label).join(', ')}` : 'Everything is out.');
console.log(
  rainbow === 'chest'
    ? "Rainbow chests: EARNED (not sold; each group's opens once the rest of the group is unlocked, with its Rainbow creature)"
    : 'Rainbow chests: SOLD in the Shop (the old way)',
);
if (rainbow === 'chest') console.log('Set rewards: OFF while Rainbow chests are earned');
else console.log(setRewards ? 'Set rewards: ON (a set reward comes from finishing its set)' : 'Set rewards: OFF (set rewards drop from chests; finishing a set gives nothing extra)');
if (!snap.exists && !flag) console.log('(config/roster does not exist yet: these are the functions/squad.js defaults)');
