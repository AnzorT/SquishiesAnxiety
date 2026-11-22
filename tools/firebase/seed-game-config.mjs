// Puts the design prototype's creatures, animations and house items into Firestore, where the admin controls them
// (see functions/gameConfig.js for what each field does), and writes config/game, the doc the app reads.
//
//   node webgame/tools/dump-config.mjs     (only after a new prototype zip: refreshes webgame/data/game-config.json)
//   GOOGLE_APPLICATION_CREDENTIALS=<service-account-key.json> node tools/firebase/seed-game-config.mjs [--dry] [--reset]
//
// Safe to run again: it adds new creatures, animations and items, refreshes the design values (designCost, designLv,
// designRarity, designGait, names) and keeps everything the admin changed (cost, lv, enabled, rarity, gait, switches).
// --reset puts every creature and item back to the design's values (all animations on, design prices).
// --dry prints what it would write.
import { createRequire } from 'node:module';
import fs from 'node:fs';
import path from 'node:path';
import { fileURLToPath } from 'node:url';

const HERE = path.dirname(fileURLToPath(import.meta.url));
const ROOT = path.resolve(HERE, '../..');
const args = process.argv.slice(2);
const DRY = args.includes('--dry');
const RESET = args.includes('--reset');
const PROJECT_ID = 'squishy-app-61445';

// firebase-admin is already installed for the Cloud Functions (cd functions && npm install)
const require = createRequire(path.join(ROOT, 'functions', 'package.json'));
const { rebuildGameConfig, compileGameConfig } = require(path.join(ROOT, 'functions', 'gameConfig.js'));

const data = JSON.parse(fs.readFileSync(path.join(ROOT, 'webgame/data/game-config.json'), 'utf8'));
const RARITY = ['common', 'rare', 'epic', 'legendary', 'rainbow'];

function creatureDoc(c, old) {
  const animations = {};
  for (const a of c.animations) animations[a] = RESET || !old || !old.animations || old.animations[a] === undefined ? true : old.animations[a] !== false;
  const keep = (field, design) => (RESET || !old || old[field] === undefined ? design : old[field]);
  return {
    id: c.id, key: c.key, name: c.name, set: c.set, order: c.id,
    danceName: c.move || null,
    enabled: keep('enabled', true),
    rarity: keep('rarity', c.rar), designRarity: c.rar, rarityNames: RARITY.join(' / '),
    gait: keep('gait', c.gait), designGait: c.gait, gaits: data.gaits.join(' / '),
    animations,
    animationTitles: c.titles || {},
    seededFrom: data.prototype,
  };
}

function itemDoc(i, old) {
  const keep = (field, design) => (RESET || !old || old[field] === undefined ? design : old[field]);
  return {
    id: i.id, room: i.room, name: i.name, slot: i.slot, category: i.cat, tier: i.tier, tierName: i.tierName, rarity: i.rarity,
    cost: keep('cost', i.cost), designCost: i.cost,
    lv: keep('lv', i.lv), designLv: i.lv,
    enabled: keep('enabled', true),
    seededFrom: data.prototype,
  };
}

async function main() {
  if (DRY) {
    const live = compileGameConfig({ creatures: data.creatures.map(c => creatureDoc(c, null)), items: data.items.map(i => itemDoc(i, null)) });
    console.log(`dry run: ${data.creatures.length} gameCreatures, ${data.items.length} gameItems, config/animations, config/game`);
    console.log('example creature:', JSON.stringify(creatureDoc(data.creatures[1], null)).slice(0, 400), '...');
    console.log('example item:', JSON.stringify(itemDoc(data.items[0], null)));
    console.log('config/game with nothing changed:', JSON.stringify(live));
    return;
  }
  const { initializeApp, applicationDefault } = require('firebase-admin/app');
  const { getFirestore, FieldValue } = require('firebase-admin/firestore');
  initializeApp({ credential: applicationDefault(), projectId: PROJECT_ID });
  const db = getFirestore();
  const [cs, is, an] = await Promise.all([db.collection('gameCreatures').get(), db.collection('gameItems').get(), db.doc('config/animations').get()]);
  const oldC = new Map(cs.docs.map(d => [d.id, d.data()]));
  const oldI = new Map(is.docs.map(d => [d.id, d.data()]));

  const writes = [];
  for (const c of data.creatures) writes.push([db.collection('gameCreatures').doc(c.key), creatureDoc(c, oldC.get(c.key))]);
  for (const i of data.items) writes.push([db.collection('gameItems').doc(i.id), itemDoc(i, oldI.get(i.id))]);
  const allAnims = [...new Set(data.creatures.flatMap(c => c.animations))].sort();
  const oldOn = (!RESET && an.exists && an.data().on) || {};
  writes.push([db.doc('config/animations'), {
    on: Object.fromEntries(allAnims.map(a => [a, oldOn[a] === undefined ? true : oldOn[a] !== false])),
    note: 'false = this animation is off for every creature. Per creature: gameCreatures/<key>.animations',
    variantOf: data.variantOf,
  }]);
  for (let i = 0; i < writes.length; i += 400) {
    const b = db.batch();
    for (const [ref, doc] of writes.slice(i, i + 400)) b.set(ref, doc);
    await b.commit();
    process.stdout.write(`\rwrote ${Math.min(i + 400, writes.length)} / ${writes.length}`);
  }
  console.log();
  const gone = [...oldC.keys()].filter(k => !data.creatures.some(c => c.key === k));
  if (gone.length) console.log('in Firestore but no longer in the prototype (left as they are):', gone.join(', '));
  const live = await rebuildGameConfig(db, FieldValue);
  await db.doc('config/gameDirty').delete();
  console.log(`config/game: ${Object.keys(live.creatures).length} creatures and ${Object.keys(live.items).length} items differ from the design, ${live.animsOff.length} animations off for everyone`);
}

main().catch(e => { console.error(e); process.exit(1); });
