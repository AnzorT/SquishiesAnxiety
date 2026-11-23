// What capture.mjs shoots and Program.cs rebuilds: a Preview.js screen ("shop-<tab>[-poor]", "road", "vault") for one
// of its made-up players (window.__shopPlayer), taps at set moments (ms on the virtual clock, x / y in dp on the
// 832 x 384 screen) and the moments shot. `wheel`: [ms, x, y, dy], `wheelX`: [ms, x, y, dx] (sideways); `drag`: [ms, x, y, dx]. `mask`: boxes (dp) left
// out of the comparison: the Chests tab's card backdrops (CARD_ART), where the web app differs from the phone (react-native-
// web's ImageBackground gives its picture its natural width, so only its left edge shows; the phone, and Unity, cover
// the card with it). `page`: the chest smash's own page (smash.mjs), not Preview.js.
// the reveal card's picture: the app shows the creature's front art (export/tripo), Unity its still (the Stack cut-out)
const REVEAL_ART = [[150, 60, 190, 190]];
const CARD_ART = [0, 1, 2, 3].map((i) => [93.56 + i * 168.06, 151.5, 140.7, 109.4]);
export const SHOTS = [
  // the four tabs, settled
  { name: 'daily', preview: 'shop-daily', player: 'shop', at: [1500] },
  { name: 'chests', preview: 'shop-chests', player: 'shop', at: [1500], mask: CARD_ART },
  { name: 'deals', preview: 'shop-deals', player: 'shop', at: [2500] },
  { name: 'gems', preview: 'shop-gems', player: 'shop', at: [2000] },
  // a poorer player who has used today's chests (the countdown, TOMORROW, Bought!, the streak done, no 2X left)
  { name: 'daily-poor', preview: 'shop-daily-poor', player: 'poor', at: [1500] },
  { name: 'deals-poor', preview: 'shop-deals-poor', player: 'poor', at: [2500] },
  { name: 'gems-poor', preview: 'shop-gems-poor', player: 'poor', at: [2000] },
  // the Chests tab's next page (the right arrow), settled; the Deals row scrolled (`scrollTo`: its
  // scrollLeft set, in the Stage's units; Unity: the wheel by as much)
  { name: 'chests-next', preview: 'shop-chests', player: 'shop', taps: [[1200, 797, 229]], at: [2600], mask: CARD_ART },
  { name: 'deals-scrolled', preview: 'shop-deals', player: 'shop', scrollTo: [[2600, 1100]], at: [3600] },
  // the sheets: a chest's (its art tapped), mid-spring and settled; the odds (Drop odds); not enough gems (Epic OPEN)
  { name: 'sheet-chest', preview: 'shop-chests', player: 'shop', taps: [[1200, 165, 215]], at: [1300, 2400] },
  { name: 'sheet-odds', preview: 'shop-daily', player: 'shop', taps: [[1200, 683, 302]], at: [2400] },
  { name: 'sheet-broke', preview: 'shop-chests-poor', player: 'poor', taps: [[1200, 500, 316]], at: [2400] },
  // the Level Road (level 5: three prizes waiting, CLAIM ALL), and dragged along; a new player's (level 2)
  { name: 'road', preview: 'road', player: 'shop', at: [1500] },
  { name: 'road-new', preview: 'road-new', player: 'road-new', at: [1500] },
  // "To the treasure vault" (Preview.js "vault": ready after 4.5 s): the bar creeping, the trail, the tip changing;
  // ready: the bar fills, the map zooms into the X (its fading in and out aren't shot: the page fades over Preview.js's
  // own background, Unity over the chest)
  { name: 'vault', preview: 'vault', at: [1000, 3000, 4400, 4700, 5000, 5150] },
  // the chest smash (its own page, smash.mjs): the server's roll for a Common Pet Shop chest (Mittens, a copy: 3 / 5),
  // the chest popping in; six taps (each a dent, cracks, flash, dust and debris; the last knocks it out: the shards, the
  // loot bursting out); the reveal card coming in and settled (the copies bar filling)
  { name: 'smash', page: 'smash', result: { group: 'pet', size: 'common', final: 'common', id: '1', rar: 0, isNew: false, copies: 3, need: 5, coins: 0, dupeCoins: 0 }, taps: [[600, 416, 240], [900, 416, 240], [1200, 400, 230], [1500, 430, 250], [1800, 416, 240], [2100, 416, 240]], at: [300, 610, 700, 1000, 1610, 2000, 2150, 2300, 2700, 3500, 4300, 6200], mask: REVEAL_ART },
  // the first tap's upgrade (the server rolled a Common Snack Shack chest up to Rare): the charge (its beams, motes and
  // rings, the room darkening), the poof into the Rare chest and its RARE! banner, then a hit
  { name: 'smash-up', page: 'smash', result: { group: 'snack', size: 'common', final: 'rare', id: '30', rar: 1, isNew: true, copies: 0, need: 10, coins: 0, dupeCoins: 0 }, taps: [[500, 416, 240], [2600, 416, 240]], at: [900, 1400, 1700, 1800, 2300, 2700] },
];
