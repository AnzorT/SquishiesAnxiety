// The game's remote config: what the admin switches in the Firebase console, boiled down to one small document the
// app reads (config/game). Used by the Cloud Functions below (index.js) and by tools/firebase/seed-game-config.mjs.
//
// Where the admin edits (Firestore console):
//   gameCreatures/{key}   one doc per creature (118): enabled, rarity, gait, and animations: { dance: true, sit: true, ... }
//                         set an animation to false and that creature never plays it (it falls back to idle / plain sitting)
//   gameItems/{itemId}    one doc per house item (788, e.g. LIV-011, BCH-004): cost, lv (unlock level), enabled
//   config/animations     on: { dance: true, ... }  an animation set to false here is off for every creature
//
// What the app reads (config/game), only what differs from the design:
//   { v: 1, animsOff: [...], creatures: { key: { on?, rar?, off?: [...], gait? } }, items: { id: { cost?, lv?, on? } }, updatedAt }
// Applied in the game by webgame/app/config.js.

function compileGameConfig({ creatures = [], items = [], animations = null }) {
  const animsOff = Object.entries((animations && animations.on) || {}).filter(([, v]) => v === false).map(([k]) => k).sort();
  const cs = {};
  for (const c of creatures) {
    if (!c || !c.key) continue;
    const e = {};
    if (c.enabled === false) e.on = false;
    if (typeof c.rarity === 'number' && c.rarity !== c.designRarity) e.rar = c.rarity;
    const off = Object.entries(c.animations || {}).filter(([, v]) => v === false).map(([k]) => k).sort();
    if (off.length) e.off = off;
    if (typeof c.gait === 'string' && c.gait && c.gait !== c.designGait) e.gait = c.gait;
    if (Object.keys(e).length) cs[c.key] = e;
  }
  const its = {};
  for (const i of items) {
    if (!i || !i.id) continue;
    const e = {};
    if (i.enabled === false) e.on = false;
    if (typeof i.cost === 'number' && i.cost !== i.designCost) e.cost = Math.max(0, Math.round(i.cost));
    if (typeof i.lv === 'number' && i.lv !== i.designLv) e.lv = Math.max(1, Math.round(i.lv));
    if (Object.keys(e).length) its[i.id] = e;
  }
  return { v: 1, animsOff, creatures: cs, items: its };
}

// Reads every source doc and writes config/game. ~900 reads: called once per batch of edits, not per edit.
async function rebuildGameConfig(db, FieldValue) {
  const [cs, is, an] = await Promise.all([db.collection('gameCreatures').get(), db.collection('gameItems').get(), db.doc('config/animations').get()]);
  const live = compileGameConfig({ creatures: cs.docs.map(d => d.data()), items: is.docs.map(d => d.data()), animations: an.exists ? an.data() : null });
  await db.doc('config/game').set({ ...live, updatedAt: FieldValue.serverTimestamp() });
  return live;
}

module.exports = { compileGameConfig, rebuildGameConfig };
