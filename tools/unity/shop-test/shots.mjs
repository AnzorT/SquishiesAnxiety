// What capture.mjs shoots and Program.cs rebuilds: a Preview.js screen ("shop-<tab>[-poor]", "road", "vault") for one
// of its made-up players (window.__shopPlayer), taps at set moments (ms on the virtual clock, x / y in dp on the
// 832 x 384 screen) and the moments shot. `wheel`: [ms, x, y, dy], `wheelX`: [ms, x, y, dx] (sideways); `drag`: [ms, x, y, dx]. `mask`: boxes (dp) left
// out of the comparison: the Chests tab's card backdrops (CARD_ART), where the web app differs from the phone (react-native-
// web's ImageBackground gives its picture its natural width, so only its left edge shows; the phone, and Unity, cover
// the card with it). `page`: the chest smash's own page (smash.mjs), not Preview.js.
// the chest smash's taps: n of them `every` ms apart from `from`, round the chest's middle (the page's pointerdown)
const hits = (from, n, every = 150) => Array.from({ length: n }, (_, i) => [from + i * every, 416 + [0, -16, 14, -8, 10][i % 5], 262 + [0, -10, 8, 4, -6][i % 5]]);
const CARD_ART = [0, 1, 2, 3].map((i) => [93.56 + i * 168.06, 151.5, 140.7, 109.4]);
export const SHOTS = [
  // the five tabs, settled
  { name: 'daily', preview: 'shop-daily', player: 'shop', at: [1500] },
  { name: 'chests', preview: 'shop-chests', player: 'shop', at: [1500], mask: CARD_ART },
  { name: 'deals', preview: 'shop-deals', player: 'shop', at: [2500] },
  { name: 'special', preview: 'shop-special', player: 'shop', at: [2500] },
  { name: 'gems', preview: 'shop-gems', player: 'shop', at: [2000] },
  // a poorer player who has used today's chests (the countdown, TOMORROW, Bought!, the streak done, no 2X left)
  { name: 'daily-poor', preview: 'shop-daily-poor', player: 'poor', at: [1500] },
  { name: 'deals-poor', preview: 'shop-deals-poor', player: 'poor', at: [2500] },
  { name: 'special-poor', preview: 'shop-special-poor', player: 'poor', at: [2500] },
  { name: 'gems-poor', preview: 'shop-gems-poor', player: 'poor', at: [2000] },
  // the Chests tab's next page (the right arrow), settled; the Deals and Special offers rows scrolled (`scrollTo`: its
  // scrollLeft set, in the Stage's units; Unity: the wheel by as much)
  { name: 'chests-next', preview: 'shop-chests', player: 'shop', taps: [[1200, 797, 229]], at: [2600], mask: CARD_ART },
  { name: 'deals-scrolled', preview: 'shop-deals', player: 'shop', scrollTo: [[2600, 1100]], at: [3600] },
  { name: 'special-scrolled', preview: 'shop-special', player: 'shop', scrollTo: [[2600, 1100]], at: [3600] },
  // the sheets: a chest's (its art tapped), mid-spring and settled; not enough gems (Epic OPEN)
  // (the odds sheet's shot went with its "Drop odds" link, gone from the app's Daily tab)
  { name: 'sheet-chest', preview: 'shop-chests', player: 'shop', taps: [[1200, 165, 215]], at: [1300, 2400] },
  { name: 'sheet-broke', preview: 'shop-chests-poor', player: 'poor', taps: [[1200, 500, 316]], at: [2400] },
  // the Level Road (level 5: three prizes waiting, CLAIM ALL), and dragged along; a new player's (level 2)
  { name: 'road', preview: 'road', player: 'shop', at: [1500] },
  { name: 'road-new', preview: 'road-new', player: 'road-new', at: [1500] },
  // "To the treasure vault" (Preview.js "vault": ready after 4.5 s): the bar creeping, the trail, the tip changing;
  // ready: the bar fills, the map zooms into the X (its fading in and out aren't shot: the page fades over Preview.js's
  // own background, Unity over the chest)
  { name: 'vault', preview: 'vault', at: [1000, 3000, 4400, 4700, 5000, 5150] },
  // the chest smash (its own page, smash.mjs), in each chest's group's vault room (its twinkles popping on the treasure):
  // the server's roll for a Common Pet Shop chest (Mittens, a copy: 3 / 5), the chest popping in; fifteen taps (its 15
  // HP: each a dent, cracks, flash, dust and debris, a gold bar draining, the padlock shaking; the last knocks it out:
  // the shards, the loot bursting out, the padlock opening); the reveal coming in (the cards v6 card, +1 COPY, the
  // copies bar filling) and settled
  { name: 'smash', page: 'smash', result: { group: 'pet', size: 'common', final: 'common', id: '1', rar: 0, isNew: false, copies: 3, need: 5, coins: 0, dupeCoins: 0 }, taps: hits(600, 15), at: [300, 610, 700, 1000, 1610, 2100, 2710, 2800, 3100, 3500, 4300, 5020, 5400, 6000, 7500] },
  // the first tap's upgrade (the server rolled a Common Snack Shack chest up to Rare): the charge (its beams, motes and
  // rings, the room darkening), the poof into the Rare chest and its RARE! banner, then a hit
  { name: 'smash-up', page: 'smash', result: { group: 'snack', size: 'common', final: 'rare', id: '30', rar: 1, isNew: true, copies: 0, need: 10, coins: 0, dupeCoins: 0 }, taps: [[500, 416, 240], [2600, 416, 240]], at: [900, 1400, 1700, 1800, 2300, 2700] },
  // THE UNLOCK: the copy that unlocks Pip (Ocean Pals, 5 / 5): the copies fanning out into a ring round the count, the
  // new one flying up from the chest, the ring spinning in white-hot, the stack shaking, BAM (the flash, the shockwave,
  // the sparks), Pip popping out (its still, where the app's live rig would be), UNLOCKED! and the full bar, settled
  { name: 'smash-unlock', page: 'smash', result: { group: 'ocean', size: 'common', final: 'common', id: '6', rar: 0, isNew: true, copies: 5, need: 5, coins: 0, dupeCoins: 0 }, taps: hits(600, 15), at: [5020, 5320, 5620, 6020, 6520, 7120, 7520, 7740, 7860, 8120, 8920, 10720] },
  // a creature that comes whole: NEW SQUISHY! (a Rainbow Sky & Stars chest, Aurora: the biggest chest, 50 HP)
  { name: 'smash-new', page: 'smash', result: { group: 'sky', size: 'rainbow', final: 'rainbow', id: '53', rar: 4, isNew: true, copies: 0, need: 0, coins: 0, dupeCoins: 0 }, taps: hits(600, 50, 100), at: [300, 3000, 5900, 7900, 9700] },
  // a duplicate (a Rare Forest Friends chest, Hoot, owned already): its coins, no bar
  { name: 'smash-dupe', page: 'smash', result: { group: 'forest', size: 'rare', final: 'rare', id: '23', rar: 1, isNew: false, copies: 0, need: 0, coins: 0, dupeCoins: 84 }, taps: hits(600, 20, 120), at: [300, 2000, 3260, 5300, 6800] },
];
