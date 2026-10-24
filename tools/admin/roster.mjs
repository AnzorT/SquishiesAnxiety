// Shows or changes Firestore config/roster: what isn't out yet ({ hidden: [group key or creature id] })
// and the set-reward rule ({ setRewards: true | false }). Until the doc has them they are
// functions/squad.js HIDDEN (the Masked and Elemental Heroes) and SET_REWARDS (off). The app and the
// server both read the doc, so a change shows the next time the Shop or the Squad grid draws and holds
// for the very next chest opened: no app update, no deploy.
// A hidden group has no chest in the Shop, is never HOT (free chest, ad chest, daily deal, streak,
// bundles) and its creatures can't be bought; a player who owns one already keeps it and still sees it.
// Set rewards off: a set's reward creature drops from its group's chests as a Legendary, and finishing
// a set brings nothing extra. On: the design's rule (the reward and 2,000 coins for finishing the set).
//
//   GOOGLE_APPLICATION_CREDENTIALS=<key.json> node tools/admin/roster.mjs                   (shows it)
//   GOOGLE_APPLICATION_CREDENTIALS=<key.json> node tools/admin/roster.mjs --show elemental  (brings it out)
//   GOOGLE_APPLICATION_CREDENTIALS=<key.json> node tools/admin/roster.mjs --hide heroes     (hides it again)
//   GOOGLE_APPLICATION_CREDENTIALS=<key.json> node tools/admin/roster.mjs --set-rewards on  (or off)
// --show / --hide take group keys (heroes, elemental, spooky…) or creature ids (79), several at once.
import { createRequire } from 'node:module';
import path from 'node:path';
import { fileURLToPath } from 'node:url';

const ROOT = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '../..');
const require = createRequire(path.join(ROOT, 'functions', 'package.json'));
const { initializeApp, applicationDefault } = require('firebase-admin/app');
const { getFirestore } = require('firebase-admin/firestore');
const { GROUPS, BY_ID, hiddenOf, setRewardsOf } = require(path.join(ROOT, 'functions', 'squad.js'));

if (!process.env.GOOGLE_APPLICATION_CREDENTIALS) {
  console.error('Set GOOGLE_APPLICATION_CREDENTIALS to the service-account key.');
  process.exit(1);
}
const [flag, ...names] = process.argv.slice(2);
if (flag && !['--show', '--hide', '--set-rewards'].includes(flag)) {
  console.error('Use --show or --hide, then group keys or creature ids; or --set-rewards on|off.');
  process.exit(1);
}
if (flag === '--set-rewards' && !['on', 'off'].includes(names[0])) {
  console.error('--set-rewards takes on or off.');
  process.exit(1);
}
const unknown = flag === '--set-rewards' ? [] : names.filter((n) => !GROUPS.some((g) => g.key === n) && !BY_ID[n]);
if (unknown.length) {
  console.error(`Not a group key or creature id: ${unknown.join(', ')} (groups: ${GROUPS.map((g) => g.key).join(', ')})`);
  process.exit(1);
}
const db = getFirestore(initializeApp({ credential: applicationDefault(), projectId: 'squishy-app-61445' }));
const ref = db.collection('config').doc('roster');
const snap = await ref.get();
const cfg = snap.exists ? snap.data() : null;
let hidden = hiddenOf(cfg);
let setRewards = setRewardsOf(cfg);
if (flag === '--set-rewards') {
  setRewards = names[0] === 'on';
  await ref.set({ setRewards }, { merge: true });
  console.log('config/roster written');
} else if (flag && names.length) {
  hidden = flag === '--show' ? hidden.filter((k) => !names.includes(k)) : [...new Set([...hidden, ...names])];
  await ref.set({ hidden }, { merge: true });
  console.log('config/roster written');
}
const label = (k) => (BY_ID[k] ? `${BY_ID[k].name} (#${k})` : (GROUPS.find((g) => g.key === k) || {}).name || k);
console.log(hidden.length ? `Not out yet: ${hidden.map(label).join(', ')}` : 'Everything is out.');
console.log(setRewards ? 'Set rewards: ON (a set reward comes from finishing its set)' : 'Set rewards: OFF (set rewards drop from chests; finishing a set gives nothing extra)');
if (!snap.exists && !flag) console.log('(config/roster does not exist yet: these are the functions/squad.js defaults)');
