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
- **UNDO** takes back the last move, but the move still counts. **RESTART** puts everyone back where this puzzle started; the moves go back to 0 and the clock keeps going. The pause card's **NEW PUZZLE** deals a fresh one.

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
