// The level map's and the game hubs' pieces for Unity, cut out of the app (Expo web on http://localhost:8081,
// src/web/Preview.js's "game-stack" / "game-sort" / "game-hop" and the rules cards; start it with
// `npx expo start --web --port 8081`). Almost everything on the hubs and the map is drawn by the Unity code
// (Games/Shared, Games/Stack/StackHub, Games/Sort/SortHub), since numbers and states change; this cuts out what
// can't be drawn from the app's fonts, or never changes:
//   Maps/world-<season>.jpg.bytes   the menu's world behind the level map (assets/royal/levels-*.jpg, WorldBg.js)
//   Maps/room-<room>.xml            Squish Hop's room cards over its map's banners (hop/Room.js RoomCard), drawing the
//                                   rooms' pictures from Resources/Hop/rooms
//   Hubs/back.xml, help.xml         the wooden back orb and Squish Hop's "?" orb (royal Orb)
//   Hubs/blitz-title.xml            "BLITZ ⚡" on the BLITZ card (the ⚡ is Chrome's colour emoji)
//   Hubs/go-lip.xml, go-face.xml    the BLITZ card's GO ⚡ button: its lip, and its ring and face (moves when pressed)
//   Hubs/rules-<game>-left.xml / -right.xml   each game's HOW TO PLAY card's two columns (GOT IT! and the title left
//                                   out: Unity draws them, the button presses, the title is react-native-svg text)
//   Hubs/img/<hash>.png             those emoji, as Chrome draws them
//   Hubs/hubs.json                  the pieces' sizes, the rules cards' buttons, and the squishies each screen shows
//                                   (the cast's / the containers' pictures, in the app's order: Resources/Stack/art)
// node tools/unity/export-maps.mjs
import fs from 'node:fs';
import path from 'node:path';
import crypto from 'node:crypto';
import { openApp, snap, ROOT } from './ui/snap-page.mjs';

const MAPS = path.join(ROOT, 'unity', 'Assets', 'Resources', 'Maps');
const HUBS = path.join(ROOT, 'unity', 'Assets', 'Resources', 'Hubs');
fs.mkdirSync(MAPS, { recursive: true });
fs.mkdirSync(HUBS, { recursive: true });

for (const s of ['sunny', 'rainy', 'snowy']) fs.copyFileSync(path.join(ROOT, 'assets', 'royal', `levels-${s}.jpg`), path.join(MAPS, `world-${s}.jpg.bytes`));

// a picture the app loads, as a Resources path: the squishies' cut-outs (assets/stack/<key>.webp -> Stack/art/<key>)
// and the Crib's rooms (assets/crib/rooms/<name>.webp -> Hop/rooms/<name>)
function resOf(src) {
  const u = decodeURIComponent(src || '');
  let m = u.match(/assets\/stack\/(\w+)\.webp/);
  if (m && fs.existsSync(path.join(ROOT, 'unity', 'Assets', 'Resources', 'Stack', 'art', m[1] + '.png'))) return 'Stack/art/' + m[1];
  m = u.match(/assets\/crib\/rooms\/([\w-]+)\.webp/);
  if (m && fs.existsSync(path.join(ROOT, 'unity', 'Assets', 'Resources', 'Hop', 'rooms', m[1] + '.png'))) return 'Hop/rooms/' + m[1];
  return null;
}
const fileOf = (uri) => { const r = resOf(uri); return r && r.startsWith('Stack/art/') ? r.slice(10) : ''; };

const pieces = {};
// a piece's SVG: its pictures by Resources path; colour-emoji characters (rasters) inlined as PNG data
async function save(dir, name, handle) {
  const s = await snap(page, handle, { inline: false });
  let svg = s.svg;
  for (const [id, src] of Object.entries(s.images)) {
    let res;
    if (src.startsWith('data:')) {
      // a character Chrome drew from its colour-emoji font: a PNG in Hubs/img, named by its content
      const bytes = Buffer.from(src.split(',')[1], 'base64');
      const hash = crypto.createHash('sha1').update(bytes).digest('hex').slice(0, 12);
      fs.mkdirSync(path.join(HUBS, 'img'), { recursive: true });
      fs.writeFileSync(path.join(HUBS, 'img', hash + '.png'), bytes);
      res = 'Hubs/img/' + hash;
    } else res = resOf(src);
    if (!res) throw new Error(`${name}: a picture with no Resources copy: ${src}`);
    svg = svg.split(`href="${id}"`).join(`href="${res}"`);
  }
  fs.writeFileSync(path.join(dir, name + '.xml'), svg);
  pieces[name] = [+s.w.toFixed(3), +s.h.toFixed(3)];
  return s;
}
const box = (h) => h.evaluate((e) => { const r = e.getBoundingClientRect(); return [r.x, r.y, r.width, r.height].map((v) => +v.toFixed(3)); });

const { browser, page, errors } = await openApp('http://localhost:8081/?phone=1&preview=1&card=game-stack');
await page.waitForTimeout(7000);
const out = { pieces, rules: {} };

// ---- Squish Stack's hub: the orb, BLITZ ⚡, GO ⚡ ------------------------------------------------------------------
await save(HUBS, 'back', await page.evaluateHandle(() => window.__components('Orb')[0].el));
await save(HUBS, 'blitz-title', await page.evaluateHandle(() => [...document.querySelectorAll('div')].find((d) => d.childNodes.length === 1 && d.textContent === 'BLITZ ⚡')));
const go = await page.evaluateHandle(() => {
  const b = window.__components('SdButton').find((c) => /GO/.test(c.el.textContent)).el;
  const inner = b.firstElementChild;
  return { b, lip: inner.children[0], ring: inner.children[1] };
});
await save(HUBS, 'go-lip', await go.evaluateHandle((g) => g.lip));
await save(HUBS, 'go-face', await go.evaluateHandle((g) => g.ring));
out.go = { button: await box(await go.evaluateHandle((g) => g.b)), ring: await box(await go.evaluateHandle((g) => g.ring)) };
out.stackCast = await page.evaluate(() => window.__components('Hub')[0].props.uris).then((l) => l.map(fileOf));

// ---- Squish Sort: the containers' squishies -----------------------------------------------------------------------
await page.evaluate(() => window.__preview('game-sort'));
await page.waitForTimeout(5000);
const pools = await page.evaluate(() => { const p = window.__components('Hub')[0].props.pools; return { fridge: p.fridge.map((c) => c.uri), cupboard: p.cupboard.map((c) => c.uri) }; });
out.sortPools = { fridge: pools.fridge.map(fileOf), cupboard: pools.cupboard.map(fileOf) };

// ---- Squish Hop: the "?" orb, the cast, every room's card (the map builds them all, a few a frame) -------------------
await page.evaluate(() => window.__preview('game-hop'));
await page.waitForTimeout(6000);
await save(HUBS, 'help', await page.evaluateHandle(() => window.__components('Orb')[1].el));
out.hopCast = await page.evaluate(() => window.__components('LevelMap')[0].props.uris).then((l) => l.map(fileOf));
const rooms = await page.evaluate(() => [...new Set(window.__components('RoomCard').map((c) => c.props.room))]);
for (const room of rooms) {
  await save(MAPS, 'room-' + room, await page.evaluateHandle((room) => window.__components('RoomCard').find((c) => c.props.room === room).el, room));
}
out.rooms = rooms;

// ---- the rules cards: each column without its button ----------------------------------------------------------------
for (const game of ['stack', 'sort', 'hop']) {
  await page.evaluate((c) => window.__preview(c), `${game}-rules`);
  await page.waitForTimeout(2500);
  const parts = await page.evaluateHandle(() => {
    const tc = window.__components('OutlinedTitle')[0];
    const title = tc.el;
    const left = title.parentElement;
    const right = left.nextElementSibling;
    const btn = window.__components('SdButton').at(-1);
    const inner = btn.el.firstElementChild;
    const face = inner.children[1].firstElementChild;
    const label = face.textContent.trim().replace(/^(.+?)\1+$/, '$1');
    const cs = getComputedStyle(face);
    const text = [...face.querySelectorAll('div')].filter((d) => d.childNodes.length === 1 && d.firstChild.nodeType === 3).pop();
    const lb = left.getBoundingClientRect(), tb = title.getBoundingClientRect();
    return { left, right, btn: btn.el, title, info: { title: tc.props.text, titleSize: tc.props.size, titleFill: tc.props.fill, titleAt: [tb.x - lb.x, tb.y - lb.y, tb.width, tb.height].map((v) => +v.toFixed(3)), label, kind: btn.props.kind, padH: parseFloat(cs.paddingLeft), padV: parseFloat(cs.paddingTop), fontSize: parseFloat(getComputedStyle(text).fontSize), marginTop: parseFloat(getComputedStyle(btn.el).marginTop) } };
  });
  // (the title is react-native-svg text: Unity draws it, CardArt.Title)
  await parts.evaluate((p) => { p.btn.style.visibility = 'hidden'; p.title.style.visibility = 'hidden'; });
  await save(HUBS, `rules-${game}-left`, await parts.evaluateHandle((p) => p.left));
  await save(HUBS, `rules-${game}-right`, await parts.evaluateHandle((p) => p.right));
  await parts.evaluate((p) => { p.btn.style.visibility = ''; p.title.style.visibility = ''; });
  const r = await box(await parts.evaluateHandle((p) => p.right));
  const b = await box(await parts.evaluateHandle((p) => p.btn));
  out.rules[game] = { ...(await parts.evaluate((p) => p.info)), at: [+(b[0] - r[0]).toFixed(3), +(b[1] - r[1]).toFixed(3)], size: [b[2], b[3]] };
}

// (the same as lists, for Unity's JsonUtility)
out.pieceList = Object.entries(pieces).map(([name, [w, h]]) => ({ name, w, h }));
out.rulesList = Object.entries(out.rules).map(([game, r]) => ({ game, ...r }));
fs.writeFileSync(path.join(HUBS, 'hubs.json'), JSON.stringify(out, null, 1));
console.log('pieces:', Object.keys(pieces).join(' '));
console.log('rooms:', rooms.join(' '), '| casts:', out.stackCast.length, out.hopCast.length, out.sortPools.fridge.length, out.sortPools.cupboard.length);
if (errors.length) console.log('page errors:', errors.slice(0, 3).join(' | '));
await browser.close();
