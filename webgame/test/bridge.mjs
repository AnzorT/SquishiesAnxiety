// The app <-> game link and the Firebase switches, on the built game, the way the phone runs it (file://, offline,
// a fake window.ReactNativeWebView collecting what the game sends):
//   - the app's player (coins, level, owned creatures) is what the game shows
//   - an animation switched off for a creature (or for everyone) never plays; idle can't be switched off
//   - a house item's price and unlock level come from the config; a hidden item leaves the catalog
//   - a config pushed while the game runs is applied (live)
//   - buying in the catalog reports the coins to the app; the house layout is reported for saving
//   node webgame/build.mjs --out webgame/test/out/webgame && node webgame/test/bridge.mjs
import path from 'node:path';
import { createRequire } from 'node:module';
import { fileURLToPath, pathToFileURL } from 'node:url';

const require = createRequire(import.meta.url);
const { chromium } = require('playwright');
const HERE = path.dirname(fileURLToPath(import.meta.url));
const DIR = path.resolve(process.argv[2] || path.join(HERE, 'out/webgame'));

const INIT = {
  screen: 'menu',
  state: {
    level: 8, coins: 7777, gems: 321,
    owned: ['mittens', 'nimbo', 'mallow', 'bao', 'biscuit', 'wisecrack'],
    col: { mittens: { f: { n: 1, g: 1 }, eq: 'g', st: 2 } },
    sel: 'nimbo',
    hiddenKeys: ['wisecrack'], // the Masked Heroes group is switched off (config/roster groups)
    games: [
      { id: 'squishdoku', name: 'Squishdoku', item: '600 puzzle levels', best: 'Level 37 / 600', color: '#3fc4ec' },
      { id: 'sort', name: 'Squish Sort', item: 'Fridge & cupboard', best: 'Fridge 4 · Cupboard 2', color: '#ff9a3c' },
      { id: 'stack', name: 'Squish Stack', item: 'Tower puzzles', best: 'Level 9 / 50', color: '#9b6bff' },
      { id: 'hop', name: 'Squish Hop', item: 'Cushion hopping', best: 'Level 3 / 100', color: '#2fc6a8' },
    ],
  },
  config: {
    v: 1,
    animsOff: ['spin'],
    creatures: { mittens: { off: ['dance', 'lounge', 'bed'] }, bao: { on: false } },
    items: { 'LIV-011': { cost: 4321, lv: 2 }, 'LIV-012': { on: false } },
  },
};

let fails = 0;
const check = (ok, what, got) => { console.log(`${ok ? 'ok  ' : 'FAIL'} ${what}${ok ? '' : '  (got ' + JSON.stringify(got) + ')'}`); if (!ok) fails++; };

const browser = await chromium.launch({ args: ['--allow-file-access-from-files'] });
const page = await browser.newPage({ viewport: { width: 852, height: 393 } });
const errors = [];
page.on('pageerror', e => errors.push(e.message));
await page.route(/^https?:/, r => { errors.push('internet: ' + r.request().url()); r.abort(); });
await page.addInitScript(init => {
  window.__SQUISH_INIT__ = init;
  window.__sent = [];
  window.ReactNativeWebView = { postMessage: m => window.__sent.push(JSON.parse(m)) };
}, INIT);
await page.goto(pathToFileURL(path.join(DIR, 'App.dc.html')).href);
await page.waitForFunction(() => document.querySelector('.mm-tab[data-tab="house"]'), null, { timeout: 30000 });
await page.waitForTimeout(1500);

// ---- the player ----
const hud = await page.evaluate(() => document.querySelector('.mm-hud').innerText);
check(/7,?777/.test(hud), 'the menu shows the app\'s coins (7777)', hud.slice(0, 120));
check(await page.evaluate(() => window.SquishProfile.get().level) === 8, 'the game\'s level is the app\'s (8)');
const owned = await page.evaluate(() => window.SquishSquad.ownedIds().map(id => window.SquishSquad.ROSTER[id].key).sort());
check(JSON.stringify(owned) === JSON.stringify(['biscuit', 'mallow', 'mittens', 'nimbo']), 'owned creatures = the app\'s, minus Bao (switched off) and Wisecrack (his group is off)', owned);
const coll = await page.evaluate(() => ({ sel: window.SquadLobby.selected(), mit: window.SquishSquad.entry(1), gems: window.SquishSquad.wallet().gems }));
check(coll.sel === 0 && coll.mit && coll.mit.eq === 'g' && coll.mit.st === 2 && coll.gems === 321, 'the app\'s selected creature (Nimbo), Mittens\' gold finish and stage, and gems reach the game', coll);
check((await page.evaluate(() => window.__sent.map(m => m.type))).includes('ready'), 'the game says ready');

// ---- the weather (Firestore config/weather -> the app picks today's, src/weather.js -> state.weather) ----
const wx = await page.evaluate(() => {
  const mo = new Date().getMonth(), month = mo === 11 || mo <= 1 ? 'snowy' : mo >= 4 && mo <= 8 ? 'sunny' : 'rainy';
  const seasonOf = () => window.MainMenuScene.state({ level: 8 }).season;
  const before = { now: window.SquishWeatherNow(), season: seasonOf(), month };
  const other = month === 'sunny' ? 'snowy' : 'sunny';
  window.SquishApp.receive({ type: 'state', state: { weather: other } });
  const after = { now: window.SquishWeatherNow(), season: seasonOf(), want: other };
  window.SquishApp.receive({ type: 'state', state: { weather: 'foggy' } });
  const bad = seasonOf();
  window.SquishApp.receive({ type: 'state', state: { weather: null } });
  return { before, after, bad, month };
});
check(wx.before.now === null && wx.before.season === wx.before.month, 'no weather from the app: the menu\'s world keeps the month\'s', wx.before);
check(wx.after.now === wx.after.want && wx.after.season === wx.after.want, 'the app\'s weather (config/weather) is the menu\'s world\'s, even against the month', wx.after);
check(wx.bad === wx.month, 'a weather the game doesn\'t have is ignored (the month\'s)', wx.bad);

// ---- animations ----
const anim = await page.evaluate(() => {
  const h = document.body.appendChild(document.createElement('div'));
  const play = (key, n) => { const c = window.RiveRig.mount(h, key, { fidgets: false }); c.play(n); const got = c._I.cur.name; c.destroy(); return got; };
  return {
    mittensDance: play('mittens', 'dance'), nimboDance: play('nimbo', 'dance'), nimboSpin: play('nimbo', 'spin'),
    mittensHappy: play('mittens', 'happy'), mittensIdle: play('mittens', 'idle'),
    bedin: window.SquishConfig.allowed('mittens', 'bedin'), lounge: window.SquishConfig.gateState('mittens', 'lounge', window.RiveRig.STATES),
  };
});
check(anim.mittensDance !== 'dance', 'Mittens\' dance is switched off: he does something else', anim.mittensDance);
check(anim.nimboDance === 'dance', 'Nimbo still dances');
check(anim.nimboSpin !== 'spin', '"spin" is off for everyone', anim.nimboSpin);
check(anim.mittensHappy === 'happy' && anim.mittensIdle === 'idle', 'Mittens\' other moves still play');
check(anim.bedin === false, 'getting into bed follows "bed"\'s switch');
check(anim.lounge === 'sit', 'Mittens\' lounge is off: he sits instead (not idle, which would make the house re-seat him)', anim.lounge);

// ---- the house and its items ----
await page.click('.mm-tab[data-tab="house"]');
await page.waitForFunction(() => window.__sh && window.__sh.byId && window.__sh.byId.size > 500, null, { timeout: 90000 });
await page.waitForTimeout(1500);
const items = await page.evaluate(() => ({
  cost: window.__sh.byId.get('LIV-011').cost, lv: window.__sh.byId.get('LIV-011').lv,
  hiddenInCatalog: window.__sh.rows.some(r => r.id === 'LIV-012'), hiddenStillDraws: window.__sh.byId.has('LIV-012'),
  other: window.__sh.byId.get('LIV-013') && window.__sh.byId.get('LIV-013').cost,
}));
check(items.cost === 4321 && items.lv === 2, 'LIV-011 costs 4321 and opens at level 2 (from the config)', items);
check(!items.hiddenInCatalog && items.hiddenStillDraws, 'LIV-012 is hidden from the catalog but still drawable if owned', items);

// a new config while the house is open
await page.evaluate(cfg => window.SquishApp.receive({ type: 'config', config: cfg }), { ...INIT.config, items: { 'LIV-011': { cost: 99 } } });
const live = await page.evaluate(() => ({ cost: window.__sh.byId.get('LIV-011').cost, lv: window.__sh.byId.get('LIV-011').lv, back: window.__sh.rows.some(r => r.id === 'LIV-012') }));
check(live.cost === 99 && live.back, 'a config pushed live re-prices the catalog and brings LIV-012 back', live);

// buying: coins go back to the app
const bought = await page.evaluate(() => { window.__sent.length = 0; const ok = window.SquishSquad.spend('coins', 99); return ok; });
await page.waitForTimeout(300);
const coinsMsg = await page.evaluate(() => window.__sent.filter(m => m.type === 'coins').pop());
check(bought && coinsMsg && coinsMsg.payload.delta === -99 && coinsMsg.payload.coins === 7678, 'spending 99 coins tells the app (delta -99, 7678 left)', coinsMsg);

// coins changed by the app (e.g. a purchase) reach the running game without being echoed back
await page.evaluate(() => { window.__sent.length = 0; window.SquishApp.receive({ type: 'state', state: { coins: 50000 } }); });
await page.waitForTimeout(300);
const echo = await page.evaluate(() => ({ coins: window.SquishSquad.coins(), sent: window.__sent.filter(m => m.type === 'coins').length }));
check(echo.coins === 50000 && echo.sent === 0, 'the app\'s new coin count reaches the game and isn\'t sent back', echo);

// the house layout is reported for saving
await page.evaluate(() => { window.__sent.length = 0; window.__sh.save && window.__sh.save(); });
await page.waitForTimeout(2200);
const houseMsg = await page.evaluate(() => window.__sent.find(m => m.type === 'house'));
check(houseMsg && typeof houseMsg.payload.data === 'string' && houseMsg.payload.data.length > 100, 'the house layout is sent to the app to save', houseMsg && houseMsg.payload.data && houseMsg.payload.data.length);

// the house map: no back orb (the map has its own Back and its hint sits there); Android back closes the map, not the house
await page.evaluate(() => window.__sh.openMap());
await page.waitForTimeout(900);
const onMap = await page.evaluate(() => { const hb = document.querySelector('.mm-hback'); return { map: !!document.querySelector('[data-screen-label="House map"]'), orb: !!hb && getComputedStyle(hb).display !== 'none' }; });
check(onMap.map && !onMap.orb, 'the house map hides the back orb', onMap);
const mapBack = await page.evaluate(() => window.SquishApp.back());
await page.waitForTimeout(900);
const offMap = await page.evaluate(() => { const hb = document.querySelector('.mm-hback'); return { map: !!document.querySelector('[data-screen-label="House map"]'), orb: !!hb && getComputedStyle(hb).display !== 'none' }; });
check(mapBack === true && !offMap.map && offMap.orb, 'Android back on the map goes back to the room, the orb returns', offMap);

// back button: leaves the house
const back = await page.evaluate(() => window.SquishApp.back());
await page.waitForTimeout(1500);
// (2026-11-21: the house is then parked, ready for the next trip: still in the page, invisible and untouchable)
const parked = await page.evaluate(() => { const h = document.querySelector('.mm-house'); return !h || (getComputedStyle(h).pointerEvents === 'none' && +getComputedStyle(h).opacity < 0.05); });
check(back === true && parked, 'Android back leaves the house (parked out of sight)', { back, parked });

// round 11: no GAMES tab, no "Let's play" board, CHARACTERS, a living level crest
const hudBits = await page.evaluate(() => ({ tabs: [...document.querySelectorAll('.mm-tab')].map(t => t.textContent.trim()), board: !!document.querySelector('.mm-card .k'), pills: !!document.querySelector('.mm-lv .tag'), crest: !!document.querySelector('.sq-crest .sq-cin') }));
check(hudBits.tabs.join() === 'CRIBFLUF,CHARACTERS,SHOP' && !hudBits.board && !hudBits.pills && hudBits.crest, 'the HUD: CRIBFLUF / CHARACTERS / SHOP, no board, no tier pills, a live crest', hudBits);

// PLAY: the creature walks left to the Game Park, where the app's games line up (no yard games there)
await page.click('.mm-play');
await page.waitForFunction(() => document.querySelector('.sq-pk.in'), null, { timeout: 15000 });
await page.waitForTimeout(800);
const arrows = await page.evaluate(() => { const L = document.querySelector('.sq-arr.l').getBoundingClientRect(), R = document.querySelector('.sq-arr.r').getBoundingClientRect(), C = document.querySelector('.sq-slot.c .sq-gc').getBoundingClientRect(); return { gapL: Math.round(C.left - L.right), gapR: Math.round(R.left - C.right) }; });
check(arrows.gapL >= 0 && arrows.gapL < 16 && arrows.gapR >= 0 && arrows.gapR < 16, 'the game card spans from the left arrow to the right arrow', arrows);
const lay = await page.evaluate(() => { const c = document.querySelector('.sq-slot.c .sq-gc'), r = e => c.querySelector(e).getBoundingClientRect(), C = c.getBoundingClientRect(), t = r('.ttl'), w = r('.win'), go = r('.go'), ds = r('.info'); return { titleAbove: t.bottom <= w.top + 1, fullWidth: w.width >= C.width - 30, clipAbove: w.bottom <= Math.min(go.top, ds.top) + 1, live: !!document.querySelector('.sq-gc .live') }; });
check(lay.titleAbove && lay.fullWidth && lay.clipAbove && !lay.live, 'a game card: its name, then its clip across the card, then the text, level and PLAY (no LIVE tag)', lay);
// (the four mini-games' cards have their name in their poster, not a title row: 2026-11-21)
const cards = await page.evaluate(() => [...document.querySelectorAll('.sq-slot')].map(e => (e.querySelector('.ttl svg') ? e.querySelector('.ttl svg').getAttribute('aria-label') : e.querySelector('.win img').alt) + ':' + e.querySelector('.best').textContent));
check(JSON.stringify(cards.map(c => c.split(':')[0])) === JSON.stringify(['Squish Time', 'Squishdoku', 'Squish Sort', 'Squish Stack', 'Squish Hop']) && cards[1].includes('Level 37 / 600'), 'PLAY walks to the Game Park: Squish Time, Squishdoku (Level 37 / 600), Sort, Stack, Hop', cards);
// Squish Time (in the middle first) asks the app for the squish screen, with the menu's creature, from the park
await page.evaluate(() => { window.__sent.length = 0; });
await page.click('.sq-slot.c .go', { force: true });
await page.waitForTimeout(700);
const playMsg = await page.evaluate(() => window.__sent.find(m => m.type === 'play'));
check(playMsg && playMsg.payload.mode === 'squish' && playMsg.payload.from === 'park' && ['mittens', 'nimbo', 'mallow', 'biscuit'].includes(playMsg.payload.key), 'Squish Time asks the app to squish the menu\'s creature (from the park)', playMsg);
// the next game: Squishdoku
await page.click('.sq-arr.r', { force: true });
await page.waitForTimeout(700);
await page.evaluate(() => { window.__sent.length = 0; });
await page.click('.sq-slot.c .go', { force: true });
await page.waitForTimeout(700);
const sdk = await page.evaluate(() => window.__sent.find(m => m.type === 'play'));
check(sdk && sdk.payload.mode === 'squishdoku', 'PLAY on Squishdoku asks the app for Squishdoku', sdk);
// (since 2026-11-21 the four mini-games show a still poster, with no clip: the park decodes no video for them)
const clip = await page.evaluate(() => { const s = document.querySelector('.sq-slot.c'), im = s.querySelector('.win img'); return { video: !!document.querySelector('.sq-slot video'), poster: im && im.getAttribute('src'), title: !!s.querySelector('.ttl') }; });
check(!clip.video && clip.poster === 'app/art/park/squishdoku.jpg' && !clip.title, 'Squishdoku shows its poster (its name drawn in, no title row) and no video plays', clip);
// back walks home
await page.click('.sq-pk [data-x]', { force: true });
await page.waitForFunction(() => !document.querySelector('.sq-pk') && !document.querySelector('.sq-parkL') && !document.querySelector('.mm-hud.mm-gone'), null, { timeout: 15000 });
check(true, 'back from the park walks home and the HUD comes back');
// the road from the house's pad runs to its left edge, where the park's road carries on
const road = await page.evaluate(() => { const svg = document.querySelector('.mm-scene svg'); return !!svg && /M-60 401 H452/.test(svg.innerHTML); });
check(road, 'the house picture has the road to the Game Park');

// the Level Pass: the crest opens it; CLAIM asks the app
await page.click('.sq-crest', { force: true });
await page.waitForTimeout(900);
const pass = await page.evaluate(() => ({ open: !!document.querySelector('.sq-lvtrack'), n: document.querySelectorAll('.sq-ln').length }));
check(pass.open && pass.n >= 30, 'the crest opens the Level Pass (30+ levels)', pass);
await page.click('.mm-page2 [data-x]', { force: true });
await page.waitForTimeout(600);

// the character chosen on CHARACTERS goes to the app
await page.click('.mm-tab[data-tab="creatures"]');
// (REDESIGN_V9: the Gathering your squad loading screen plays first, then leaves)
await page.waitForSelector('.sq-gs', { state: 'detached', timeout: 10000 });
await page.waitForTimeout(300);
await page.evaluate(() => { window.__sent.length = 0; });
await page.click('.sq-cc[data-id="1"]', { force: true });
await page.waitForTimeout(500);
await page.click('.sq-c2 [data-sel]', { force: true }); // (REDESIGN_V8: the remodelled Characters page)
await page.waitForTimeout(400);
const sel = await page.evaluate(() => window.__sent.find(m => m.type === 'select'));
check(sel && sel.payload.key === 'mittens', 'choosing Mittens on CHARACTERS tells the app', sel);
await page.click('.mm-page2 [data-x]', { force: true });
await page.waitForTimeout(600);

// REDESIGN_V7 step 0: the menu's page framework, and a page asking the app for something
const pageFw = await page.evaluate(async () => {
  window.SquishMenu.pages.__test = (x, o, P) => { const pg = P.page(x, { title: 'Test Page', note: 'a note', right: P.pill(P.coinImg(), 5) }); pg.pg.insertAdjacentHTML('beforeend', '<div id="tp">' + o.word + '</div>'); };
  const opened = window.SquishMenu.open('__test', { word: 'hi' });
  const shown = (document.querySelector('#tp') || {}).textContent === 'hi' && !!document.querySelector('.mm-page2 .mm-pgh .mm-orb');
  window.SquishApp.back();
  await new Promise(r => setTimeout(r, 400));
  return { opened, shown, closed: !document.querySelector('#tp') };
});
check(pageFw.opened && pageFw.shown && pageFw.closed, 'a menu page opens over the menu with its header, and Android back closes it', pageFw);
const ask = await page.evaluate(async () => {
  window.__sent.length = 0;
  const p1 = window.SquishApp.ask('squad', { move: 'freeChest' });
  const m1 = window.__sent.find(s => s.type === 'ask');
  window.SquishApp.receive({ type: 'answer', id: m1.payload.id, ok: true, result: { coins: 5 } });
  const r1 = await p1;
  const p2 = window.SquishApp.ask('buy', { key: 'gems_s' });
  const m2 = window.__sent.filter(s => s.type === 'ask')[1];
  window.SquishApp.receive({ type: 'answer', id: m2.payload.id, ok: false, error: 'not_enough_gems' });
  let e2 = null; try { await p2; } catch (e) { e2 = e.message; }
  return { what: m1.payload.what, move: m1.payload.payload.move, r1, e2 };
});
check(ask.what === 'squad' && ask.move === 'freeChest' && ask.r1 && ask.r1.coins === 5 && ask.e2 === 'not_enough_gems', 'App.ask: a page asks the app and gets its answer, or its error code', ask);

// the yard games: only from the backyard's YARD GAMES button
await page.click('.mm-tab[data-tab="house"]');
await page.waitForFunction(() => window.__sh && window.__sh.byId && document.querySelector('.mm-hback'), null, { timeout: 90000 });
await page.waitForTimeout(2500);
const btnLiving = await page.evaluate(() => { const x = document.querySelector('.sq-yard-wrap'); return !!x && x.style.display !== 'none'; });
await page.evaluate(() => window.__sh.enterRoom('backyard'));
await page.waitForTimeout(9000);
const btnYard = await page.evaluate(() => { const x = document.querySelector('.sq-yard-wrap'); return !!x && x.style.display !== 'none'; });
check(!btnLiving && btnYard, 'the YARD GAMES button is in the backyard only', { btnLiving, btnYard });
await page.click('.sq-yard');
await page.waitForTimeout(1500);
const yard = await page.evaluate(() => ({ cards: [...document.querySelectorAll('.mm-gc')].map(e => e.dataset.g), over: document.querySelector('.mm-host').style.zIndex }));
check(yard.cards.join() === 'hoop,soccer,hop,tramp,slide,corn,pong' && yard.over === '30', 'it opens the 7 yard games, over the house', yard);
// (2026-11-18, the user: a yard game opens only once its toy is bought in the Backyard; the cards are wide, with the game's poster)
const locks = await page.evaluate(() => [...document.querySelectorAll('.sq-ygc')].map(e => ({ g: e.dataset.g, lock: e.classList.contains('lock'), need: (e.querySelector('.need') || {}).textContent || '', poster: !!e.querySelector('.win svg .ygp-cr') })));
check(locks.length === 7 && locks.every(l => l.lock && l.poster) && /^Buy .*Hoop.* in the Backyard catalog \(440 coins\)/.test(locks[0].need), 'with no toys bought every yard game is locked, says what to buy, and shows its poster', locks.slice(0, 2));
// buy the hoop (as the house's catalog does: owned['R:<id>']), and the page opens Hoop Shot
await page.evaluate(() => { window.__sh.H.owned['R:YRD-102'] = 1; document.querySelector('.mm-pg [data-x]').click(); });
await page.waitForTimeout(800);
await page.click('.sq-yard');
await page.waitForTimeout(1500);
const open1 = await page.evaluate(() => [...document.querySelectorAll('.sq-ygc:not(.lock)')].map(e => e.dataset.g));
check(open1.join() === 'hoop', 'buying the Driveway Basketball Hoop opens Hoop Shot (only)', open1);
// (2026-11-18, the user: the toys are bought once and never placed)
const toy = await page.evaluate(() => { const s = window.__sh, c0 = window.SquishSquad.coins(), a = s.buyR('YRD-101'), c1 = window.SquishSquad.coins(), b = s.buyR('YRD-101'), c2 = window.SquishSquad.coins(), r0 = s.rTab; s.rTab = () => 'furn'; const tray = s.trayVals({}).map(x => x.id); s.rTab = r0; return { a, b, first: c0 - c1, second: c1 - c2, n: s.H.owned['R:YRD-101'], tray, placed: (s.H.rooms.backyard || []).some(i => i.t === 'R:YRD-101') }; });
check(toy.a && !toy.b && toy.first === 110 && toy.second === 0 && toy.n === 1 && !toy.placed && !toy.tray.includes('R:YRD-101'), 'the toy of a yard game is bought once and is never offered for placing', toy);
await page.click('.mm-gc[data-g="hoop"] .go');
await page.waitForTimeout(2000);
// (2026-11-18, the yard zip: a landscape game fills the page, so the page's side column and its back orb are hidden;
// the back button is the game intro's own ‹)
const land = await page.evaluate(() => ({ land: !!document.querySelector('.mm-gp.land'), poster: !!document.querySelector('.mm-gp .yg-iback'), frame: (() => { const f = document.querySelector('.mm-gp .yg-frame'); if (!f) return null; const r = f.getBoundingClientRect(); return Math.round(r.width / r.height * 100) / 100; })() }));
check(land.land && land.poster && land.frame > 2 && land.frame < 2.3, 'a yard game plays sideways across the page (780 x 360) and opens on its intro poster', land);
await page.click('.mm-gp .yg-iback');
await page.waitForTimeout(1000);
await page.click('.mm-pg [data-x]');
await page.waitForTimeout(800);
const backIn = await page.evaluate(() => ({ page: !!document.querySelector('.mm-page2'), z: document.querySelector('.mm-host').style.zIndex, room: window.__sh.state.cur }));
check(!backIn.page && backIn.z === '' && backIn.room === 'backyard', 'a yard game\'s back goes to the Yard Games, and back again to the backyard', backIn);

// the app asks for the house right at start (a daily challenge's "go to the house"): the menu walks in once it's ready
const page2 = await browser.newPage({ viewport: { width: 852, height: 393 } });
page2.on('pageerror', e => errors.push(e.message));
await page2.route(/^https?:/, r => { errors.push('internet: ' + r.request().url()); r.abort(); });
await page2.addInitScript(init => {
  window.__SQUISH_INIT__ = init;
  window.__sent = [];
  window.ReactNativeWebView = { postMessage: m => { const x = JSON.parse(m); window.__sent.push(x); if (x.type === 'ready') window.SquishApp.receive({ type: 'screen', screen: 'house' }); } };
}, INIT);
await page2.goto(pathToFileURL(path.join(DIR, 'App.dc.html')).href);
const inHouse = await page2.waitForFunction(() => window.__sh && window.__sh.byId && window.__sh.byId.size > 500 && document.querySelector('.mm-hback'), null, { timeout: 90000 }).then(() => true, () => false);
check(inHouse, 'a house request sent before the menu has loaded still walks into the house');

// the app's start data arriving after the page's first scripts (it happens on Android): nothing the menu saved before
// is sent to the app as the player's pick, and the menu shows the app's character once the data lands
const page3 = await browser.newPage({ viewport: { width: 852, height: 393 } });
page3.on('pageerror', e => errors.push(e.message));
await page3.route(/^https?:/, r => { errors.push('internet: ' + r.request().url()); r.abort(); });
await page3.addInitScript(init => { window.__sent = []; window.__late = init; window.ReactNativeWebView = { postMessage: m => window.__sent.push(JSON.parse(m)) }; }, INIT);
await page3.goto(pathToFileURL(path.join(DIR, 'App.dc.html')).href);
await page3.waitForFunction(() => document.querySelector('.mm-tab'), null, { timeout: 30000 });
await page3.evaluate(() => { const k = 'squishsquad.lobby.v1'; const v = JSON.parse(localStorage.getItem(k) || '{}'); v.sel = 1; localStorage.setItem(k, JSON.stringify(v)); });
await page3.evaluate(() => { window.__SQUISH_INIT__ = window.__late; });
await page3.waitForTimeout(800);
const late = await page3.evaluate(() => ({ picks: window.__sent.filter(m => m.type === 'select').length, shown: window.SquishSquad.ROSTER[window.SquadLobby.selected()].key }));
check(late.picks === 0 && late.shown === 'nimbo', 'start data arriving late: no stray pick goes to the app, and the menu shows the app character', late);

// PERF 2026-11-20: sleep / wake. Asleep, nothing runs (frames, timers, the page's clock, CSS animations); 'state' is
// applied at once, 'screen' waits for wake; on wake everything carries on where it was
const sleep = await page3.evaluate(() => new Promise(res => {
  const A = window.SquishApp, out = {};
  let frames = 0; const count = () => { frames++; requestAnimationFrame(count); }; requestAnimationFrame(count);
  let fired = 0; setTimeout(() => { fired = performance.now(); }, 300);
  setTimeout(() => {
    out.t0 = performance.now(); out.f0 = frames;
    A.receive({ type: 'sleep', on: true });
    out.asleep = !!window.SquishSleep.asleep;
    A.receive({ type: 'state', state: { coins: 4242 } });
    A.receive({ type: 'screen', screen: 'house' });
    const nat = window.SquishSleep.native;
    nat.setTimeout(() => {
      out.framesAsleep = frames - out.f0; out.clockAsleep = performance.now() - out.t0; out.firedAsleep = !!fired;
      out.coins = window.SquishSquad.wallet().coins; out.walkedAsleep = !!document.querySelector('.mm-hud.mm-gone');
      out.cssPaused = getComputedStyle(document.documentElement).getPropertyValue('--x') === '' && document.documentElement.classList.contains('sq-sleep');
      A.receive({ type: 'sleep', on: false });
      out.awake = !window.SquishSleep.asleep;
      nat.setTimeout(() => { out.framesAwake = frames - out.f0 - out.framesAsleep; out.fired = fired ? Math.round(fired - out.t0) : 0; out.walked = !!document.querySelector('.mm-hud.mm-gone'); res(out); }, 800);
    }, 700);
  }, 100);
}));
check(sleep.asleep && sleep.framesAsleep <= 1 && sleep.clockAsleep < 5 && !sleep.firedAsleep && sleep.cssPaused, 'asleep: no frames, no timers, the page\'s clock stands still, CSS animations paused', sleep);
check(sleep.coins === 4242 && !sleep.walkedAsleep, 'asleep: the app\'s state is applied at once, a screen change waits for wake', sleep);
check(sleep.awake && sleep.framesAwake > 5 && sleep.fired > 150 && sleep.fired < 400 && sleep.walked, 'awake: frames and timers carry on (a timer fires after the time it had left), the parked screen change plays', sleep);

check(!errors.length, 'no page errors, no internet', errors.slice(0, 5));
await browser.close();
process.exit(fails ? 1 : 0);
