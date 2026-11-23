// The house fixtures (HOUSE_PORT_PLAN.md stage 0): saves + players the page and the C# port are both checked on.
//
//   node tools/unity/house/fixtures.mjs        writes tools/unity/house/fixtures/<name>.json
//
// A fixture is { name, profile: { level, coins }, collection?, house: '<ssHouse5b JSON>' | null, rooms: [...] }:
//   fresh-lv1    a new player: no save (the house makes one), level 1
//   lv12         level 12, no save: every starter room (living .. movie) opens with its starter pieces
//   decorated    level 24: pieces in every room bought and placed with the house's own rules: wall snaps on the side
//                walls, ceiling lights, rotations, sizes (one size and width x height), signs with text, small pieces
//                on a table, renovated walls / floors / ceilings / fence / ground / yard lights, a moved and
//                resized shell light, night in two rooms
//   premigration a save written before the one-shot migrations (ceiling lights / windows as surfaces, the dented
//                bowl, the living-room ball, the old projector on the floor): initH must move it all
//   lv30-beach   level 30 with the beach open, standing on the beach
//
// The decorated save is made in the page by the house's own functions (wallPose, backY, ceilE, the owned counts), so it
// is a save the app could have written.
import fs from 'node:fs';
import path from 'node:path';
import { fileURLToPath } from 'node:url';
import { openHouse, launch } from './harness.mjs';

const HERE = path.dirname(fileURLToPath(import.meta.url));
export const FIX_DIR = path.join(HERE, 'fixtures');
const ALL = ['living', 'kitchen', 'bathroom', 'bedroom', 'backyard', 'dance', 'movie', 'beach'];
export const roomsFor = lv => ALL.filter(r => lv >= { living: 1, kitchen: 2, bathroom: 4, bedroom: 6, backyard: 8, dance: 11, movie: 12, beach: 30 }[r]);

// the pre-migration save, written by hand the way a Nov 6 house saved: ceiling lights and windows were surfaces
// (H.surf[room].light / .win = 'rv_<id>', the bought ones in rOwn), a dented bowl in the living room, the yard ball,
// the bedroom projector BED-080 standing on the floor
const PREMIG = {
  owned: { 'R:LIV-011': 1, dentedBowl: 3, 'R:BED-080': 1, 'R:KIT-015': 1, 'R:KIT-010': 1 },
  rooms: {
    living: [{ id: 'i1', t: 'dentedBowl', x: 300, y: 250, r: 0, c: 0 }, { id: 'i2', t: 'R:LIV-006', x: 430, y: 190, r: 330, c: 0 }],
    kitchen: [{ id: 'i3', t: 'R:KIT-015', x: 176, y: 150, r: 330, c: 0 }, { id: 'i4', t: 'R:KIT-010', x: 292, y: 150, r: 330, c: 0 }, { id: 'i9', t: 'dentedBowl', x: 500, y: 260, r: 0, c: 0 }],
    bedroom: [{ id: 'i5', t: 'R:BED-080', x: 400, y: 230, r: 330, c: 0, e: 20 }, { id: 'i6', t: 'R:BED-015', x: 330, y: 198, r: 330, c: 0 }],
  },
  toys: { living: [{ id: 'livingt0', k: 'ball', x: 380, y: 300 }], backyard: [{ id: 'backyardt0', k: 'ball', x: 380, y: 300 }] },
  surf: { living: { light: 'rv_LIV-038', win: 'rv_LIV-032' }, kitchen: { light: 'rv_KIT-037', win: 'rv_KIT-032' }, bedroom: { light: 'rv_BED-030' }, dance: { light: 'rv_CLB-026' } },
  rOwn: { 'LIV-038': 1, 'LIV-032': 1, 'KIT-037': 1, 'KIT-032': 1, 'BED-030': 1, 'BED-050': 1, 'CLB-026': 1, 'LIV-021': 1, 'GONE-999': 1 },
  rtex: { living: { wall: 'LIV-021' } },
  open: { living: 1, kitchen: 1, bedroom: 1, bathroom: 1, backyard: 1, dance: 1 },
  night: { bedroom: 1 }, uid: 12, seenLv: 11, cur: 'bedroom', cr: { mittens: 'kitchen' }, needs: { mittens: { h: 40, c: 50, e: 60, f: 70 } },
  sOwn: { w_peel: 1 }, lx: { kitchen: 300 }, futureKey: { keep: [1, 2, 3] },
};

// the decorated house: built in the page on a fresh level-24 house
async function decorated(b) {
  const H = await openHouse(b, { profile: { level: 24, coins: 999999 } });
  await H.ready();
  await H.frames(5);
  const err = await H.page.evaluate(() => {
    const sh = window.__sh, X = sh.X, Hs = sh.H, WALLR = 69;
    const add = (rk, id, o) => {
      const t = 'R:' + id, D = sh.rnReg(id); if (!D) throw new Error('no piece ' + id);
      Hs.owned[t] = (Hs.owned[t] || 0) + 1;
      const it = Object.assign({ id: 'i' + (Hs.uid++), t, x: 426, y: 240, r: D.mount ? 0 : 330, c: 0 }, o || {});
      if (D.mount) { it.y = sh.backY(D); it.e = D.rL === 'ceil' ? sh.ceilE(it, D) : D.elev; if (o && o.e != null) it.e = o.e; }
      if (o && o.wall) { const side = o.wall; delete it.wall; const p = sh.wallPose(it, side, o.wy || 170); delete it.wy; if (!p) throw new Error('no wall pose ' + id); Object.assign(it, { r: p.r, x: p.x, y: p.y, w: side }); }
      delete it.wy;
      (Hs.rooms[rk] = Hs.rooms[rk] || []).push(it); return it;
    };
    const rt = (rk, slot, id) => { Hs.rOwn[id] = 1; Hs.rtex[rk] = Object.assign({}, Hs.rtex[rk], { [slot]: id }); };
    // living: a turned couch, a rug, a coffee table with two small pieces on it, a wall TV, a mirror snapped to the
    // left wall, a neon sign with text, a ceiling light, a resized speaker, renovated wall / floor / ceiling, night
    add('living', 'LIV-046', { x: 430, y: 196, r: 300 });
    add('living', 'LIV-037', { x: 420, y: 282, r: 0 });
    const tb = add('living', 'LIV-016', { x: 520, y: 250, r: 330 });
    add('living', 'LIV-008', { x: 510, y: 250, r: 330, on: tb.id });
    add('living', 'LIV-031', { x: 600 });
    add('living', 'LIV-024', { wall: 'L', wy: 180 });
    add('living', 'LIV-064', { x: 250, txt: 'HELLO' });
    add('living', 'LIV-038', {});
    add('living', 'LIV-133', { x: 700, y: 230, r: 30, sz: 1.3 });
    rt('living', 'wall', 'LIV-021'); rt('living', 'floor', 'LIV-025'); rt('living', 'ceil', 'LIV-029');
    Hs.night.living = 1;
    // kitchen: a table turned 45 degrees and bigger, a chair, a pendant light, renovated wall and floor
    add('kitchen', 'KIT-053', { x: 430, y: 230, r: 45, sz: 1.2 });
    add('kitchen', 'KIT-036', { x: 520, y: 260, r: 120 });
    add('kitchen', 'KIT-037', {});
    rt('kitchen', 'wall', 'KIT-021'); rt('kitchen', 'floor', 'KIT-025');
    // bathroom: a tub, a mirror on the right wall
    add('bathroom', 'BTH-055', { x: 400, y: 240, r: 0 });
    add('bathroom', 'BTH-050', { wall: 'R', wy: 190 });
    // bedroom: a bed facing front, a chandelier; the shell light moved and resized; night
    add('bedroom', 'BED-063', { x: 420, y: 200, r: 0 });
    add('bedroom', 'BED-070', {});
    Hs.lx.bedroom = 300; Hs.lz = { bedroom: 1.5, kitchen: 0.75 }; Hs.night.bedroom = 1;
    // backyard: a pool sized width x height, the limestone fence, paver ground, bistro lights
    add('backyard', 'YRD-075', { x: 430, y: 270, r: 330, sw: 1.4, sh: 0.8 });
    add('backyard', 'YRD-046', { x: 250, y: 230, r: 30 });
    rt('backyard', 'fence', 'YRD-061'); rt('backyard', 'ground', 'YRD-065');
    Hs.rOwn['YRD-043'] = 1; Hs.surf.backyard = Object.assign({}, Hs.surf.backyard, { ylight: 'rv_YRD-043' });
    // dance: a sign with its own text, a light rig on the floor, renovated wall and floor
    add('dance', 'CLB-106', { x: 600, txt: 'PARTY' });
    add('dance', 'CLB-066', { x: 560, y: 250, r: 330 });
    rt('dance', 'wall', 'CLB-041'); rt('dance', 'floor', 'CLB-045');
    // movie: a couch and a projector screen sized width x height
    add('movie', 'MOV-033', { x: 426, y: 250, r: 330 });
    add('movie', 'MOV-062', { x: 426, sw: 1.2, sh: 0.9 });
    sh.save();
    return null;
  });
  if (err) throw new Error(err);
  const house = await H.page.evaluate(() => localStorage.getItem('ssHouse5b'));
  const errs = H.errs.slice();
  await H.close();
  if (errs.length) console.warn('decorated: page errors', errs.slice(0, 5));
  return house;
}

export function loadFixtures() {
  return fs.readdirSync(FIX_DIR).filter(f => f.endsWith('.json')).sort().map(f => JSON.parse(fs.readFileSync(path.join(FIX_DIR, f), 'utf8')));
}

if (process.argv[1] && process.argv[1].endsWith('fixtures.mjs')) {
  fs.mkdirSync(FIX_DIR, { recursive: true });
  const b = await launch();
  const out = [
    { name: 'fresh-lv1', profile: { level: 1, coins: 100 }, house: null },
    { name: 'lv12', profile: { level: 12, coins: 2500 }, house: null },
    { name: 'decorated', profile: { level: 24, coins: 5000 }, house: await decorated(b) },
    { name: 'premigration', profile: { level: 11, coins: 800 }, house: JSON.stringify(PREMIG) },
    { name: 'lv30-beach', profile: { level: 30, coins: 20000 }, house: JSON.stringify({ cur: 'beach', open: { living: 1 }, uid: 1 }), room: 'beach' },
  ];
  for (const f of out) {
    f.rooms = roomsFor(f.profile.level);
    fs.writeFileSync(path.join(FIX_DIR, f.name + '.json'), JSON.stringify(f, null, 1) + '\n');
    console.log(f.name, f.house ? f.house.length + ' chars' : 'no save', f.rooms.join(','));
  }
  await b.close();
}
