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
const DIR = path.join(HERE, 'out/webgame');

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

// back button: leaves the house
const back = await page.evaluate(() => window.SquishApp.back());
await page.waitForTimeout(1500);
check(back === true && !(await page.$('.mm-hback')), 'Android back leaves the house');

// PLAY: the design's Mini Games page with the app's games (no yard games there)
await page.click('.mm-play');
await page.waitForTimeout(1200);
const cards = await page.evaluate(() => [...document.querySelectorAll('.mm-gc')].map(e => e.dataset.g + ':' + (e.querySelector('.best') || {}).textContent));
check(JSON.stringify(cards.map(c => c.split(':')[0])) === JSON.stringify(['squish', 'squishdoku', 'sort', 'stack', 'hop']) && cards[1].includes('Level 37 / 600'), 'PLAY lists Squish Time, Squishdoku (Level 37 / 600), Sort, Stack, Hop', cards);
await page.evaluate(() => { window.__sent.length = 0; });
await page.click('.mm-gc[data-g="squishdoku"] .go');
await page.waitForTimeout(300);
const sdk = await page.evaluate(() => window.__sent.find(m => m.type === 'play'));
check(sdk && sdk.payload.mode === 'squishdoku', 'PLAY on Squishdoku asks the app for Squishdoku', sdk);
// Squish Time asks the app for the squish screen, with the menu's creature
await page.evaluate(() => { window.__sent.length = 0; });
await page.click('.mm-pg .go >> nth=0');
await page.waitForTimeout(500);
const playMsg = await page.evaluate(() => window.__sent.find(m => m.type === 'play'));
check(playMsg && playMsg.payload.mode === 'squish' && ['mittens', 'nimbo', 'mallow', 'biscuit'].includes(playMsg.payload.key), 'Squish Time asks the app to squish the menu\'s creature', playMsg);

// the creature picked on the menu (CREATURES) goes to the app
await page.click('.mm-pg [data-x]');
await page.waitForTimeout(600);
await page.click('.mm-tab[data-tab="creatures"]');
await page.waitForTimeout(900);
await page.evaluate(() => { window.__sent.length = 0; });
await page.click('.mm-pick .it[data-id="1"]');
await page.waitForTimeout(400);
const sel = await page.evaluate(() => window.__sent.find(m => m.type === 'select'));
check(sel && sel.payload.key === 'mittens', 'picking Mittens on the menu tells the app', sel);

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
await page.click('.mm-gc[data-g="hoop"] .go');
await page.waitForTimeout(2000);
await page.click('.mm-gp [data-x]');
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

check(!errors.length, 'no page errors, no internet', errors.slice(0, 5));
await browser.close();
process.exit(fails ? 1 : 0);
