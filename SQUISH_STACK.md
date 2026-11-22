# Squish Stack: the stacking mini-game

The third mini-game, asked for on 2026-10-24. It's the Tower of Hanoi with squishies: they sit on cushions, a big one can never sit on a smaller one, and you move them one at a time until they match the goal.

## The user's asks (2026-10-24)
- A Tower of Hanoi game in the app. The user saw a playable HTML prototype first (6 levels: the classic tower, scrambled starts, goal pictures, a 4th cushion, par stars) and said: "this actually looks really cool, I would love to implement this".
- Levels: 50 levels with tiers and adaptive difficulty, like Squishdoku and Squish Sort.
- Hint: "combine: hint is by watching an ad and lose a star".
- Clock: "for a certain level it will start a timer".

## Playing
- **Lift:** tap a cushion and its top squishy lifts, hovering and wiggling above the towers. Tap another cushion to put it there, or tap the same one to put it back. Dragging works too.
- **Too big:** a big squishy dropped on a smaller one lands on its head, squashes it flat ("TOO BIG!"), and boings back home. No move is counted.
- **Weight:** squishies lower in a tower are squished a little by the ones on top of them.
- **Goal:** everyone onto the ★ cushion, or, from level 9, the cushions must match the GOAL card. The card is always on screen.
- **Moves and par:** the par is the fewest moves there are (worked out exactly, see Code). The meter shows the stars you can still get if every move from now on is the best one.
- **RESTART** puts everyone back where this puzzle started; the moves go back to 0. (Since 2026-11-16 there's no UNDO, no clock, and no NEW PUZZLE on the pause card, which has RESUME and QUIT: see the end.)

## Stars, hints, clock
- **Stars:**
  - 3 stars: the par.
  - 2 stars: up to par + max(2, half the par).
  - 1 star: any other win.
- **Hint:** shows the next best move. The from-cushion glows white, the to-cushion gold, and the squishy hops.
  - Every hint costs a rewarded ad. With Remove Ads it's free.
  - The first hint in a level asks first ("this level gives one star less"). Later hints in that level go straight to the ad.
  - A hinted level gives one star less, never less than 1. That's one star off for the level, however many hints.
  - My reading of "lose a star". The other reading is a star off per hint.
- **Clock:** from level 15 (`CLOCK_FROM`) on, every level has one. The level that brings it says "BEAT THE CLOCK!".
  - The limit is 20 s + 3.6 s a par move (3 s on HARD and EXPERT), rounded up to 5 s.
  - When it runs out, TIME'S UP, then RETRY.
  - Levels before 15 can't be lost.

## Blitz (asked for on 2026-10-24: "also in the Tower of Hanoi game, i also want to have a blitz version")
**Since 2026-11-16 (the user): BLITZ MODE is endless, and the hub is in the new design.** See "Hub and BLITZ MODE
(2026-11-16)" at the end. What follows was the first Blitz, kept for history.

Like Squishdoku's Blitz. The game now opens on a hub with REGULAR (the map) and BLITZ ⚡:
- **10 puzzles in a row**, all scrambled, from 3 squishies on 3 cushions to 7 on 4. Puzzles 5, 7 and 9 have a goal card.
  - Par ranges run from 4-6 up to 13-16 moves; a skill step moves them by 2.
  - There's a 3, 2, 1, GO! before the first one.
- **One clock for the run**, 4:00. The best answers add up to about 93 moves, some 2.6 s a move. It's stopped between puzzles.
- **The mistake is dropping a big one on a smaller one.** It still squashes and bounces, but the clock stops. Then:
  - **One revive per run:** a rewarded ad, free with Remove Ads.
  - Otherwise it's **BACK TO PUZZLE 1**.
  - The clock running out ends the run too.
- **No hints in Blitz.** UNDO and RESTART still work.
- **The prize:** 800 coins for all 10 puzzles. The best puzzle reached and the best time are saved.
- **Reused from Squishdoku:** the pips, the countdown, the revive, fail and win cards, the pause card and the sd_* Blitz sounds. The music turns to party.
- **Code:**
  - `levels.js`: `BLITZ`, `blitzSpec`, `afterBlitz`.
  - `Game.js`: the `blitz` prop.
  - `Hub.js`: the hub.
  - Saved as `stack.blitz.{reached, bestMs, wins}` and `stack.bSkill`.

## Levels (src/stack/levels.js)
50 levels in bands of one size:

| Levels | Squishies × cushions | Par range (easy → expert) |
|---|---|---|
| 1-3 | 3 × 3 | 3-5 … 7 |
| 4-8 | 4 × 3 | 6-9 … 14-15 |
| 9-14 | 4 × 3, goal card arrives | 7-10 … 13-15 |
| 15-21 | 5 × 3, clock arrives | 10-14 … 21-26 |
| 22-28 | 5 × 4, the 4th cushion (a breather: towers get short) | 6-8 … 10-13 |
| 29-36 | 6 × 4 | 9-11 … 14-17 |
| 37-43 | 7 × 4 | 12-15 … 18-22 |
| 44-50 | 8 × 4 | 15-19 … 24-28 |

- **The classic tower** (everyone on the first cushion, to the last) is played on levels 1, 4, 22 and 29: 7, 15, 13 and 17 moves.
- **Every other level is scrambled.** A fresh random puzzle comes on every play. The start is drawn from every arrangement whose best answer falls in the tier's par range.
- **Tiers:** each level asks for EASY, MEDIUM, HARD or EXPERT. The tier rises inside each band, with breathers in between.
  - The tier sets the par range.
  - It also sets the goal: a picture on HARD and up, and on odd-numbered MEDIUM levels, from level 9.
- **Adaptive difficulty:** a hidden skill score moves the tier one step either way.
  - 3 stars: +0.35. 2 stars: +0.15. A fail: −0.5. A hint: −0.15.
- **What's new:** the first time a level brings something new, a banner says so: the goal card (9), the clock (15), the 4th cushion (22).
- **Coins:** (6 + 2 per squishy + 0.6 per par move, +3 for a picture, +4 for a clock) × stars (1 / 1.5 / 2) × tier (+15% each).
- **XP** (the player level, PLAYER_XP.md, since 2026-10-25): Squish Sort's formula, (10 + ½ × level + 5 × tier) × (0.6 + 0.2 × stars); half on a replay, and a hint's lost star costs XP too. A Blitz win gives 200.
- **Squishies:**
  - Owned ones first, topped up from the roster: level 50 needs 8, and a new player owns 1.
  - Never the Masked or Elemental Heroes, hidden groups, or the pass creature.
  - They're shuffled every play, so the biggest one changes.

## Code
- `src/stack/engine.js`: the rules and the solver.
  - A state is the cushion of each squishy.
  - A breadth-first search from the goal gives the distance of all k^n states. That's 65,536 at 8 on 4, about 10 ms.
  - The search gives the par, the hint and the star meter.
  - `makePuzzle` draws a start in a par range.
- Tests: `node src/stack/engine.test.js`. They check that the classic towers come out at 2^n−1 and at the 4-peg numbers, that the hint path reaches the goal in exactly the par, the levels, and the scoring.
- `src/stack/levels.js`: bands, tiers, the clock, stars, coins, skill, and the `stack` record.
- `src/stack/Game.js`: the play screen (geometry, lift / drop / bounce / undo animations, touch, clock, win and fail).
- `src/stack/Pieces.js`: the cushion, the ★ badge, the goal card, and a squishy drawn by its body.
- `src/stack/Cards.js`: result, time's up, pause, the hint offer, how to play.
- `src/screens/StackScreen.js`: the map and the game. The map is Squish Sort's `LevelMap`, now taking `list` and `bannerOf`.
- `src/stack/roster.js`: who plays.
- **Cut-outs:** `tools/stack/fit.py` writes `assets/stack/<key>.webp` (each squishy cut to its body, with the floor shadow cleared) and `src/stack/art.js`.
  - Why: on a tower, the rig stills' floor shadow floated in the air beside the squishy below.
  - Re-run it when the roster changes.
  - A creature that isn't in `art.js` falls back to its `thumb.url` with a typical body box (and its shadow).
- **Sounds:** `tools/audio/stack_sfx.py` writes `assets/audio/stack/st_*` (lift, land, cushion, ouch, bounce, undo, hint, empty tap, news) and `src/audio/stackFiles.js`. Stars, coins, the win, the tick and time's up reuse Squishdoku's sd_* sounds.
- **Saved on the profile** (written by the client, like Squish Sort's `sort`): `stack.{lv, best, skill, plays, wins, seen}`. Coins go through `saveStack`. firestore.rules doesn't block `stack`, so there's nothing to deploy.
- **Hooked into the app:** the PICK A GAME card (`GamePicker.js`, a tower whose top squishy hops between two cushions), `LobbyScreen` `onOpenStack`, `App.js` stage `stack` (music: cozy).

## Status (2026-10-24)
- Played on the Pixel_8_Pro debug build:
  - the picker card, the map, level 1 (tap lift and drop, too-big bounce, drag, undo, hint through a Google test ad, the win and result card: 8 moves, hinted, 1 star, +16 coins, level 2 unlocked)
  - level 2 (scrambled), level 50 (8 on 4 with the goal card and clock), time's up, pause, the intro banner
  - Squish Sort's map, still the same.
- The test account's `stack` progress was put back after testing with every level unlocked.
- Still to check:
  - the news banners for levels 9, 15 and 22 on screen
  - the hint's glow (it ran, since the meter dropped, but it had finished by the screenshot)
  - the how-to-play card on a fresh account
  - speed on a release build on the A15.
- Nobody has listened to the st_* sounds yet.
- Blitz, played on the Pixel_8_Pro on 2026-10-24:
  - checked: the hub, the countdown, puzzle 1 solved (pip, clock held, PUZZLE 2), big on small opening the revive card, giving up for BACK TO PUZZLE 1 and the best saved, GO AGAIN with a fresh countdown, the Blitz pause card.
  - not yet: the revive in Stack (it's the same code as Sort's, which was checked), a full 10-puzzle win, a timeout.

## Hub and BLITZ MODE (2026-11-16)

The user, after Squishdoku's hub and Blitz redesign: "I want the same thing to be done with squish stack, squish hop".
They chose the hub **and** the endless Blitz (not the hub alone).

**The hub** (`src/stack/Hub.js`, built on Squishdoku's `GameHub` in `src/squishdoku/Hub.js`)
- The title stands alone at the top (no squishies bobbing beside it, no tagline).
- **REGULAR MODE** and **BLITZ MODE** are the new design's wood plaques with a picture each, tapped as a whole (no PLAY
  or GO buttons).
  - The pictures are the Game Park's Squish Stack clip near its end (the tower almost built): as is for Regular, and
    turned electric blue with lightning bolts for Blitz (`tools/games/mode-art.mjs` -> `assets/stack/mode-*.jpg`).
  - REGULAR MODE's line is the progress bar and "23/50". BLITZ MODE's is "BEST: n".
- HOW TO PLAY has a ? on it.
- Squishdoku's other pieces (`ModePanel`, `LevelsLine`, `BestLine`, `RulesButton`, `HubTitle`) are exported for this.

**BLITZ MODE** (`src/stack/Game.js` `blitz`, `levels.js` blitzSpec / blitzLimit / blitzPrize / afterBlitz)
- Puzzle after puzzle, with no end, each on its own clock: 6 s to look plus 2.4 s a move of its par, in whole seconds.
  That is always under Regular's clock for the same par (a test checks it).
- The puzzles climb as the first Blitz's ten did (3 on 3 up to 7 on 4, some with a goal card), then 7 on 4 for five
  more and 8 on 4 for good, every other one with a goal card. Past the climb each clock is 3% shorter than the last,
  down to three quarters.
- A big one dropped on a smaller one (still squashed and bounced home) or a puzzle's clock running out stops the run.
  Saving it works as in Squishdoku:
  - **with a rewarded ad**, once a run (free with Remove Ads);
  - **with gems**: 10, 20, 40 … up to 320 in the same run, through the same `blitzSave` move (`functions/squad.js`).
  - After a mistake the puzzle's clock runs on; after the clock ran out it starts again.
  - **END RUN** is GAME OVER (Squishdoku's card, saying PUZZLES CLEARED).
- Each puzzle cleared pays coins by its squishies (3: 30, 4: 45, 5: 60, 6: 80, 7: 100, 8: 120) and a tenth of
  config/levels `xp.blitz.stack` in XP (20 by default). Quitting or starting over mid-run pays too.
- UNDO and RESTART still work; no hints.
- The HUD: PUZZLE n, CLEARED and BEST (NEW BEST in gold), "1 MISTAKE = GAME OVER", "Big on small ends the run!" and the
  puzzle's clock. The pips and the revive chip are gone.
- The skill (`bSkill`) still moves the par ranges: up after a run of 10 or more, down after one under 5.
- Saved as `stack.blitz.{top, runs}`. `reached`, `bestMs` and `wins` were the ten-puzzle runs' and are no longer written.
- The PICK A GAME card shows "BLITZ BEST n" once there is one.
- **Checked** in the web version's preview with the bundled cut-outs (`?phone=1&preview=1&card=stack-blitz`): the
  countdown, puzzle 1 solved and puzzle 2 with its own clock, TOO BIG opening the save card, the free save carrying
  on, TIME'S UP without the used ad button, END RUN with +30 coins and +20 XP; and Regular level 5 to PERFECT STACK.
  The gem save wasn't tried (it calls the server). Not checked on a phone.

## No clock, no UNDO, the new level screen (2026-11-16)

The user's marked-up screenshots of a level:
- "remove undo button": the level has RESTART and HINT (Blitz: RESTART).
- "no need for timer here, also not in blitz": **no clock at all.** Regular levels from 15 used to have one (and a
  TIME'S UP card); they keep the +4 coins it added (`LATE_FROM`), so the pay is the same. Blitz has no per-puzzle
  clock either: a run ends only on a mistake (big on small), which can be saved as before. `limitFor`, `blitzLimit`
  and the "BEAT THE CLOCK!" news are gone.
- "remove level 49, squish stack text", "remove the 3 stars themselves", the moves and par as "my attempt / attempts for
  3 stars": the counter at the top in the middle reads MOVES 5 / 24 (red once past the par) with the tier beside it.
- "put the goal at the bottom left", "the 2 buttons put them at the bottom on the same row": the goal card bottom left,
  RESTART and HINT side by side bottom right.
- "remove the dashed lines": the dashed outline round the cushions is gone (its soft glow stays).
- "remove the new puzzle button from the menu": the pause card has RESUME and QUIT only.

## Moves (2026-11-17)

The user's list, to make the moves (and "TOO BIG!") much clearer, from the same cut-outs (no new art):
- **Grab:** the squishy stretches up as it's lifted, then dangles from its top while it hovers. Dragged, it swings
  against the way it's moved, by how fast (a native spring toward an angle from the drag speed, every 40 ms). Held
  still or let go, it swings back and forth like a pendulum and settles. The one under it springs up a little,
  relieved of the weight; lifted straight off a cushion, the cushion springs up instead.
- **Correct drop:** it falls and lands with a squash. The one under it squashes flat and bulges sideways, then springs
  back. The squash runs down the tower, 60 ms and about 40 % smaller at each level, to the cushion, and a puff of dust
  comes off the cushion (`puff`, Squish Hop's).
- **Too big:**
  - The small one is flattened like a pancake (a third of its height, held about half a second), with dizzy stars
    circling over it (`Dizzy`), and the board flashes red.
  - The big one is squashed by the landing, then boings off (the boing sound, a stretch) and shakes its head "nope".
    It arcs back home in one curve and lands softly.
  - Let go from a drag, it now comes straight down from where it was dropped, instead of first flying up to hover
    height.
- **Win:** a bounce wave runs up each tower from bottom to top (85 ms a level, the towers 45 ms apart), with a sparkle
  off each squishy. Each one squashes, stretches and squashes again with only a small hop, so it doesn't jump into the
  one on it; the one on top hops high. It's all over before the result card (1.5 s).
- **Lose:** there's no clock any more (2026-11-16), so no TIME'S UP; the one loss is Blitz's mistake (big on small).
  280 ms after it, everyone droops (sunk and wider) and sways sadly (a native loop each, a little apart). The save card
  now comes at 1.5 s (was 1 s), so that shows first. Saving the run straightens everyone up.

**How it's built** (`src/stack/Game.js`)
- **One native timing per move.** Each move is a phase 0 → 1 read through keyframes (`LAND`, `PICK`, `RELIEF`,
  `RIPPLE`, `PANCAKE`, `NOPE`, `WAVE`, `HINT`; `pieceAnims`), as in Squish Hop.
- **A path with turns is one timing per axis:** `pathTiming` works the turns into the timing's easing, and Animated
  computes the frames once. So `fly` (lifts, drops, the deal, the bounce home) no longer chains timings.
- **A delay is worked into the timing** (`after`), e.g. each level of the ripple and the wave.
- **The cushions' bump** is one timing whose easing wobbles back to 0 (`curve`).
- **Loops:** the hover dangle and the sad sway are native loops of one timing.
- Every `Animated.sequence` and `Animated.loop(sequence)` is gone. They were stepped from JS: the land squash, the
  bounce, the hint and win hops, the cushion bump, the held wiggle, the multi-step flights.
- `Piece` draws its weight squish, its body (from its feet: squash, stretch, hops, the nope and the sway), and the
  dangle (from its top). Its transforms are made once (`useMemo`).
- Rules, levels, the engine, stars and coins are untouched. `node src/stack/engine.test.js`: "stack: all good".
- `window.__stack` (web, development only) also has `pick(from)` and `drop(to)`, to lift one and let it go separately.

**Checked** in the web version, frame by frame with Playwright's fake clock (`?phone=1&preview=1&card=stack-level&lv=5`
and `lv=8`, `card=stack-blitz`):
- a pick-up; a real mouse drag with its swing and pendulum settle;
- a drop onto a two-high tower with the ripple;
- too big, from a tap and from a drag;
- level 8 solved, with the win wave;
- a Blitz mistake into the droop and the save card.

Fixed on the way: the win's hops overlapped the ones above them, the bounce arc went up over the counter, and the
sway was hidden by the save card. Not checked on a phone (A15 speed).

## Forest road map (2026-11-17)

The user: "in squish stack let it be the trees forest and i want the background to also scroll with the road itself,
and i want the road to be part of the background and we see our current selected character walking to the next step".

- **The forest** is drawn in the menu world's style (its own `tree()` / `bush()` from `main-menu-scene.js`, the same
  season colours) with a dirt road baked in: `tools/stack/forest.mjs` → `assets/stack/forest-<season>-<0..3>.jpg`
  (2250 × 1035, ~230 KB each). It's one strip of 4 tiles that wraps without a seam, so the map lays them A B C D A B …
  Season by month like the menu (`seasonNow` in `src/royal/WorldBg.js`).
- **The road** is one formula in `src/stack/road.js` (`roadY`, in the pictures' 1000 × 460 units), used by both the
  drawing script and the map, so the levels always stand on it. `layout(list)` places the levels 128 units apart, with
  a 300-unit gap at each band for its wooden sign. Change the road → re-run the script.
- **The map** (`src/stack/ForestMap.js`, sideways only; upright keeps Squish Sort's map) takes the whole screen; the
  top bar lies over the sky (white title). Tiles, signs, level buttons (Squish Sort's `Node`) and the walker all scroll
  together.
- **The walker** is the player's selected character (`lobby.sel`, as the Lobby / Menu pick it) as its live rig:
  `tools/rig/walk.html` (via `RigStage`, `page="walk"`), with the Squad House gaits (`house-walk.js`,
  `house-walk-c.js` + the fruit / pet2 / snack2 profiles, copied by `tools/rig/build.mjs` from the webgame build). It
  stands on the next level to play. Back on the map with that level beaten it turns side-on, walks the road (stepping
  down off each button and up onto the next), turns back and does its happy bounce; the camera frames both ends, or
  follows for a long walk. More than 6 levels on, or backwards: it's just there.
- Its page is mounted fresh each time the map comes back into view (`visit`): a WebView kept hidden under a level can
  come back blank. The walk waits until the character is drawn (3.5 s at most, then it just stands there).
- Web check: `/?full=1&preview=1&card=stack-forest`, tap REGULAR, then `window.__stackWin()`.
- **Not yet on a phone.** `walk.html` and the walk scripts are new Android assets: they need a new APK. Without it the
  map works but shows no walker.

