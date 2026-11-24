// What capture.mjs shoots and Program.cs rebuilds: a Preview.js screen ("scr-…") for one of its made-up players,
// taps at set moments (ms on the virtual clock, x / y in dp on the 832 x 384 screen) and the moments shot.
// `wheel`: [ms, x, y, dy] a mouse wheel scroll; `drag`: [ms, x, y, dx] a sideways drag. `mask`: boxes (dp) left out of the comparison: creature pictures the app moves (CreatureThumbnail's mood motion,
// not ported).
export const SHOTS = [
  // Achievements: opens on the first one not done ("Squish Tycoon", 7 of 72), settled; the right arrow (a move: mid-way
  // and settled); the left arrow twice (a done one, gold); a new player (the first creature badge, locked)
  { name: 'ach', preview: 'scr-achievements', player: 'mid', at: [2000] },
  { name: 'ach-next', preview: 'scr-achievements', player: 'mid', taps: [[1000, 797, 172]], at: [1150, 1300, 1700] },
  // a swipe to the left (the next badge), mid-way and settled
  { name: 'ach-swipe', preview: 'scr-achievements', player: 'mid', drag: [[1000, 600, 180, -120]], at: [1250, 1800] },
  { name: 'ach-done', preview: 'scr-achievements', player: 'mid', taps: [[600, 35, 172], [1400, 35, 172]], at: [2400] },
  { name: 'ach-new', preview: 'scr-achievements-new', player: 'new', at: [1500], mask: [[350, 110, 132, 140]] },
  // the streak: alive (3 days, today's chest shut), the tiles coming in and settled; the intro (no back orb, Later);
  // today's chest opened (CONTINUE); no streak (the cold flame); a long one (day 9)
  { name: 'streak', preview: 'scr-streak', player: 'mid', at: [300, 700, 2000] },
  { name: 'streak-intro', preview: 'scr-streak-intro', player: 'mid', at: [2000] },
  { name: 'streak-done', preview: 'scr-streak-done', player: 'done', at: [2000] },
  { name: 'streak-zero', preview: 'scr-streak-zero', player: 'zero', at: [2000] },
  { name: 'streak-long', preview: 'scr-streak-long', player: 'long', at: [2000] },
  // the daily challenges sheet: 2 claimed, 1 to claim (CLAIM +40), the rest part-way; all claimed (OPEN); opened
  { name: 'daily', preview: 'scr-daily', player: 'mid', at: [1000] },
  { name: 'daily-ready', preview: 'scr-daily-ready', player: 'ready', at: [1000] },
  { name: 'daily-done', preview: 'scr-daily-done', player: 'done', at: [1000] },
  // scrolled to its end with the mouse wheel (the panel's content is 16 dp taller than the panel)
  { name: 'daily-scrolled', preview: 'scr-daily', player: 'mid', wheel: [[800, 416, 200, 100]], at: [1500] },
  // Settings: as it opens; Music switched off (the knob springing across, then settled); a tester's (FPS counter,
  // Test wallet)
  { name: 'settings', preview: 'scr-settings', at: [1000] },
  { name: 'settings-music', preview: 'scr-settings', taps: [[500, 234, 132]], at: [560, 700, 1500] },
  { name: 'settings-tester', preview: 'scr-settings-tester', at: [1000] },
  // Send feedback: the box fading in; a tester's Test wallet, and scrolled
  { name: 'settings-feedback', preview: 'scr-settings', taps: [[500, 666, 137]], at: [1300] },
  { name: 'settings-wallet', preview: 'scr-settings-tester', taps: [[500, 666, 239]], wheel: [[1500, 416, 200, 120]], at: [1300, 2200] },
  // Stats
  { name: 'stats', preview: 'scr-stats', player: 'mid', at: [1000], mask: [[44, 80, 80, 96], [56, 180, 46, 170]] },
  { name: 'stats-new', preview: 'scr-stats-new', player: 'new', at: [1000] },
  // the Daily Spin: waiting; SPIN at 1000 (the whirl ramps up, the "server" answers at 1800: 500 coins, slice 6, then
  // the 4.5 s landing), the prize card popping in, settled
  { name: 'spin', preview: 'scr-spin', at: [1000, 1300, 1700, 2400, 3500, 5000, 6200, 6500, 7200], taps: [[1000, 216, 189]] },
  // the Mystery Box slice (2026-11-17): today's chest on the wheel, the card's MYSTERY BOX and Open
  { name: 'spin-chest', preview: 'scr-spin', spin: { index: 3, kind: 'chest', amount: 1, size: 'common', jackpot: false, chest: { group: 'pet', size: 'common', final: 'common', id: '43', rar: 0, isNew: false, copies: 2, need: 5, coins: 0, dupeCoins: 0 } }, at: [4000, 7200], taps: [[1000, 216, 189]] },
];
