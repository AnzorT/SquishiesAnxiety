# Squishdoku: the first mini-game

A Queens-style logic puzzle, like Pengudoku (Google Play), built with our creatures. Agreed with the user on 2026-10-22.

## Rules
- The grid is n×n and cut into n coloured patches.
- Put one creature in every row, every column and every patch.
- No two creatures may touch, not even corner to corner.
- Every board has exactly one answer, and it can be solved by logic alone.

## Controls
- **Tap** a cell to place a creature. Only a correct cell keeps it. A wrong cell is a **mistake**: the creature's head zooms up, turns sad, cries and shrinks away.
- **✕ mark** (Regular only): with the ✕ tool on, tap or drag over cells to mark them; tap a ✕ again to clear it. A long press also marks a ✕ while the tool is off.
- Tapping a placed creature makes it squeak and wiggle. That's just for fun and has no effect on the game.

## Regular mode: 50 levels (until 2026-11-07; see "600 fixed levels" below)
| Levels | Grid |
|---|---|
| 1-3 | 4×4 |
| 4-10 | 5×5 |
| 11-20 | 6×6 |
| 21-30 | 7×7 |
| 31-40 | 8×8 |
| 41-50 | 9×9 |

- Each level asks for a difficulty tier (easy, medium, hard or expert) that rises inside each size band, with a few easier "breather" levels in between. The table is in `src/squishdoku/levels.js`.
- **Random every time**: a level is a size plus a tier. The board is generated fresh on the phone on every play (`src/squishdoku/engine.js`), and the next board is built in the background while you play.
- **Adaptive difficulty**: a hidden skill score goes up after fast, clean solves and down after timeouts and mistakes. It shifts the tier by one step at most, and the grid size never changes.
- **Timer**: each level has a time limit. If it runs out, the level fails and you retry on a new board.
- **Score**: the "stars" are 3 creatures, chosen at random from the whole roster each time.

| Result | Creatures |
|---|---|
| No ✕ used and no mistakes ("PERFECT") | 3, and the bigger prize |
| No mistakes, solved before time A | 3 |
| No mistakes, solved before time B | 2 |
| Solved later, or with any mistake | 1 |
| Time runs out | failed |

  The creatures sit on the timer bar at times A and B, and each one falls off as its time passes.
- **Rewards**: coins depend on grid size and creatures earned (×1, ×1.5, ×2, or ×3 for PERFECT). Players also earn **XP** for their player level (PLAYER_XP.md; until 2026-10-25 it was the game's own Puzzle Level, whose levels paid coins). A replay of a level already beaten pays half. Gems are only granted by the server, so the game gives none.
- The next level unlocks after any solve.

## Blitz mode
**Since 2026-11-16 (the user): BLITZ MODE is endless.** See "Hub and Blitz redesign (2026-11-16)" at the end. What
follows was the first Blitz, kept for history.

- 10 boards in a row: 4×4, 5×5 ×2, 6×6 ×4, 7×7 ×3.
- One shared timer for the whole run, set to 10:00 to start.
- No ✕ marks.
- **One mistake, or the timer running out, sends you back to level 1** with new boards and a full timer.
- **One revive per run**: after a mistake, watch a rewarded ad (free for Remove Ads owners) to stay on the same board. A timeout can't be revived.
- Finishing all 10 boards pays a big prize. The best level reached and the best time are saved.

## Creatures
- The board pieces and the 3 score creatures come from the creatures **the player owns** (rig stills, `thumb.url`; on the board, their heads: see below). If they own only one, every piece is that one. **Masked Heroes and Elemental Heroes never appear.** If the player owns none of the rest, any of the rest are used. See `src/squishdoku/roster.js`.
- **Heads on the board (2026-10-28, the user's ask)**: the board shows each creature's **head alone**, without body, arms or feet, filling its cell. `tools/rig/heads.mjs` renders them from the rig in headless Chrome, in three faces made from the rig's own face channels (no body motion, so the three line up): **idle**, **happy** (squinting smile, mouth open, blush) and **sad** (frown, teary eyes, lids and ears down). It writes `assets/squishdoku/heads/<key>-<face>.webp` (224 px, about 2.3 MB for all 79) and `src/squishdoku/heads.js` (key → faces + where the eyes are). Limbs are hidden by their rig role. Creatures with a separate body under the head (teddy, leo, panko, hoot and others: `CUT` in the tool) are also cut to the head's circle below its middle, and `BAND` trims a tail beside the head (acorn, drako). Re-run the tool after a new roster creature. One published since falls back to its rig still (`roster.js` headOf).
- **Reactions**: on a tap the head **zooms up from small to fill its cell** (180 ms, a little overshoot). A **right** one lands with a squash, lights up with its happy face, hops twice and waggles its head, sends a ripple across its patch and a ring of candy dots, then settles back to its idle face. A **wrong** one turns sad as it lands, with the tile glowing red; two tears roll down, it hangs its head and shakes it, then shrinks away in a poof. On a solve all the creatures hop in a wave, smiling.
- **XP goes to the player**, not to creatures. Since 2026-10-25 that's the player level the whole game shares (PLAYER_XP.md).

## Animation and sound
Everything moves, and everything has its own sound, generated in Python (`tools/audio/squishdoku_sfx.py` writes `assets/audio/squishdoku/` and `src/audio/squishdokuFiles.js`). Sounds:

- **Cells**: tap, ✕ on, ✕ off.
- **Placing**: a rising sweep as the head zooms up (it was a falling whistle until 2026-10-28) and a squishy landing, plus a chime that climbs with every correct creature in a row.
- **Mistakes**: buzz, grumble and poof.
- **Timer**: a tick for the last 10 s, a sound when a timer-creature falls off, and a time's-up alarm.
- **Board**: cascading in and whooshing out.
- **Solve**: fanfare, hop wave, confetti.
- **Result**: creature 1, 2 and 3 each with their own sound, getting more powerful; an empty-slot thud; the PERFECT stamp; coin ticks; the XP fill; level up.
- **Map**: node pop, unlock, locked bonk, start level.
- **Controls**: ✕-tool toggle on and off, pause, resume, squeak.
- **Blitz**: 3-2-1 countdown, GO, level-to-level whoosh, progress pip, the back-to-level-1 crash, pips draining, revive, the big win.

## HEAD START (added 2026-10-23)
- A switch on the Squishdoku hub, saved in `sdk.head`. Since 2026-11-16 it is for Regular mode only. Blitz ignores it:
  every Blitz board gives 1 creature anyway (see the Blitz redesign below).
- When it's on, the first row's creature drops into place after the board's intro, before the clock starts.
- Because that makes the puzzle easier, the clock is **20% shorter** (times A and B too, and Blitz becomes 8:00) and **coins and XP are ×0.6**, PERFECT included.
- These numbers are `HEAD_START` in `levels.js`.
- The level header shows a HEAD START chip, and the result card shows "HEAD START".

## How players get in (2026-10-23)
- The Lobby's **PLAY** slides up **PICK A GAME** (`src/screens/GamePicker.js`).
  - **SQUISH:** the creature squashes over and over on spinning rays.
  - **SQUISHDOKU:** a mini board where creatures drop in one by one, with chips for progress.
  - **MORE SOON:** a placeholder card.
- The cards fly in from alternate sides and squash when tapped.
- During the tutorial, PLAY still goes straight to Squish, which is the step the tutorial points at.
- The separate Puzzle tile is gone.

## Look and life (2026-10-23)
- The board is **plush cushions** (since 2026-10-28, the user's pick): a quilt of puffy fabric squares with the rigs' own fabric grain and a soft shadow (a white stitched seam round each was taken off the same day, the user's ask), so they're the same material as the plush creatures. Until then they were glossy candy-button tiles (style A, chosen 2026-10-23), which the user felt didn't fit the creatures' texture. Each colour is one picture (`tools/squishdoku/cushions.mjs` writes `assets/squishdoku/cushions/` and `src/squishdoku/cushions.js`, about 95 KB). `Tile.js` draws it and clips the flashes and the mistake glow to the cushion's shape. There are no border lines between patches; the colours alone tell them apart (`theme.js` PATCHES). The colours went through three rounds that day: the user asked for much more colour that fits the app. A bright candy set looked out of context, and the soft **Dreamy** pastels weren't "cool" enough. From mock boards (6×6, and 9×9 for all nine colours) the user picked **Jewel**, made velvet for the cushions: magenta, sky, gold, violet, emerald, tangerine, sapphire, teal and ruby, which the pastel creatures stand out on. The ✕ is white with a plum outline, because a plum ✕ was lost on the deep colours.
- **Buddy** (`Buddy.js`): the creature picked in the Lobby, as the live rig, stands under the board and reacts:
  - right: happy or hop, "Yay!"
  - wrong: surprised and a shake, "Oops!"
  - solve: spin, then happy
  - the last seconds: look, "Hurry!"
  - time's up: surprised
- **Placed creatures breathe and sway.**
  - Every 1.3 s one of them does a trick: hop, wiggle, spin or peek. Tricks keep the eyes open: a happy face (eyes shut) flashing on its own read as the creature closing and opening its eyes, so since 2026-10-28 it only shows when a creature lands right, cheers a new one, is tapped, or on the solve.
  - They hop to cheer each new creature (with their happy face) and flinch at a mistake (with a worried look).

## In the Crib's rooms (2026-11-07)
The user asked for a Squishdoku remodel done "the same method" as Squish Hop (SQUISH_HOP.md), "that it happens in the rooms instead of the regular board", "and the characters look like" Squish Hop's.

- **The room:** a level is played in one of the Crib's rooms (src/hop/Room.js), with the time of day.
  - For now each grid size has its room: 4×4 Living Room, 5×5 Kitchen, 6×6 Bathroom, 7×7 Bedroom, 8×8 Yard, 9×9 Dance Room (`levels.js` `stageOf`).
  - A Blitz run is in the Dance Room.
- **The board** lies on the room's floor in Squish Hop's perspective (src/hop/board.js), leaned back 30° rather than Hop's 38°, so a 9×9 keeps big cells (`RoomBoard.js` `SDK_TILT`).
  - The patches are plush cushions drawn as tilted SVG, in the Jewel colours: the body colour in the middle going to the deep edge, on a darker ring.
  - ✕ marks are printed on the cushions, white with a plum edge.
- **The creatures stand on their cushions,** body and all: Squish Stack's cut-outs (`stack/roster.js` `castOf`, the player's own; all of them if they own none).
  - A right one drops on and lands with a squash, sparks fly, its patch ripples (the cushions bob), its row and column bob, and everyone hops to cheer.
  - A wrong one drops on with the cell glowing red, shakes its head, and shrinks away in a poof. The board shakes, and the cell gets its ✕.
  - A placed creature breathes, peeks about, and now and then does a hop or a wiggle.
  - Since the heads are gone, the board shows no happy or sad faces. The score creatures, the clock, the result cards and the Buddy are unchanged.
    (Since 2026-11-17 the standing creatures have happy and sad faces again: see "Reactions on the room board" at the end.)
- **The screen:**
  - The Crib's top bar: pause (or back), the room's title, LEVEL n · size, the tier and HEAD START chips, and the time-of-day pill.
  - The score creatures and the clock on the Crib's brown glass.
  - The Buddy and the PLACE / MARK tools on a glass strip at the bottom.
- **Code:**
  - `src/squishdoku/RoomBoard.js`: the board, the same contract and ref API as `Board.js`, which is kept but no longer used by the games.
  - `RegularGame.js` and `BlitzGame.js`: the room layout.
  - `SquishdokuScreen.js`: hands the games `cast`, and gives a level or a run the whole screen.
- **Checked on the Pixel_8_Pro (debug):**
  - Regular level 17 (6×6, Bathroom): HEAD START's creature, a solve tap by tap, PERFECT SQUISH, level 18 unlocked.
  - Level 18: a wrong tap (red glow, poof, auto ✕).
  - The pause card; Blitz board 1 in the Dance Room.
- **Not checked yet:** a 9×9 in a room on a phone, the ✕ drag and long press on the tilted board, and speed on the A15.
- **Next:** done, see "600 fixed levels".

## 600 fixed levels (2026-11-07)
The user's rulings:
- Instead of a board that "remodels itself" every time a level is played, 600 levels, each with a decided difficulty.
- No hidden skill score.
- Players keep their level number.
- Squishdoku goes first of the mini-games.

This replaces "Regular mode: 50 levels" above (its random boards, the tier per level, and the skill score). Blitz is unchanged: it still deals fresh boards each run, with its own `bSkill`.

**Every level is one board, the same for everyone, every time.**
- REPLAY and RETRY (time's up) play it again. (The pause card's RESTART, was NEW BOARD, is gone since 2026-11-17: the user.)
- `src/squishdoku/levelData.js` holds all 600 (75 KB).
- `tools/squishdoku/levels600.mjs` makes them on the PC with the game's own engine, in 8 seeded jobs with fixed counts, so a run gives the same levels on any machine: about 95 s on 8 cores. Its steps:
  1. Make boards of every size.
  2. Drop repeats: the same patches turned or mirrored count once.
  3. Give each level the unused board nearest its target effort, the hardest first.
  4. Check every board again: exactly one answer, solved by logic.
  5. Print a table per chapter.

**Difficulty is the grader's effort** (engine.js `grade`: how much thinking a board takes; 8 ≈ needs a chain, 16 two, 24 three).
- The plan, `plan()` in the tool, is what to change to re-tune.
- **30 chapters of 20 levels.** Inside a chapter the target rises. The 5th, 10th and 15th levels are breathers, and the 20th is the chapter's hardest.
- **Sizes:**

| Levels | Size | Notes |
|---|---|---|
| 1-4 | 4×4 | always effort 0-1 |
| 5-22 | 5×5 | |
| 23-45 | 6×6 | |
| 46-80 | 7×7 | |
| 81-130 | 8×8 | |
| 131-600 | 9×9 | breathers are 8×8, or 7×7 on the 15th |

  9×9 stays the top size. A 10×10 would need a 10th patch colour and gets small on the tilted board.
- **The 9×9 years:** the base effort climbs from 4 (level 131) to 32 (level 600), a chapter adds up to 4, and a boss is 8 over its base (up to 40). (Before "Harder" below: 4 → 24, +3, boss +5, and level 600 at 29.)
- **Tiers by effort:** EASY ≤1, MEDIUM ≤3, HARD ≤7, EXPERT ≤15, then the new **MASTER** (16-23) and **LEGEND** (24+), so the long 9×9 climb shows. Their colours are purple `#8f3cf2` and amber `#f5a300` (theme.js).
- **What the engine can reach** (measured 2026-11-07):
  - 4×4 is always easy, and 5×5 rarely passes 3.
  - At 9×9, the top 10% is effort ≥6, the top 1% ≥13, and the top 0.1% ≥25. The best seen was 27. Past that the tool climbs (see "Harder" below).
  - The effort score piles up at 8, 16 and 24.
  - `makePuzzle` hangs for n < 4.
- **The clock:** the size's times (TIMES) × (1 + 0.05 per point of effort, up to 30), rounded to 5 s. A 9×9 at effort 24 has 2.2 × as long, and from 30 on 2.5 ×. HEAD START is still × 0.8.
- **Coins and XP** grow with the tier as before (+15% coins and +5 XP per tier), now up to LEGEND.

**Rooms by chapter:** chapter c is in room (c - 1) mod 6 of Living Room, Kitchen, Bathroom, Bedroom, Yard, Dance Room. The time of day moves through the chapter, 5 levels each for the rooms with four times of day (`levels.js` `stageOf`, replacing the room-per-size of the section above).

**The patch colours:** a level gets the first n colours of theme.js PATCHES, whose order puts the most different hues first, shuffled by level. A random n of the 9 had put sky next to sapphire.

**The map:** one chapter a page. The chapter's room picture is on top with CHAPTER n · ROOM, its levels and sizes, ◀ ▶ to the chapters either side, and CHAPTER n+1 ▶ at the bottom. It opens on the current level's chapter. 600 levels on one page would have been about 60,000 points tall.

**Saved data:**
- `sdk.lv`, `sdk.best` and `sdk.perfect` keep their meaning, and the level number carries over (a player on 18 of 50 is on 18 of 600).
- `sdk.skill` is no longer written or read.

**Tests:** `node src/squishdoku/levels.test.js`.
- Every board has one answer (its stored one), the grader solves it by logic with its stored effort, and it has n different colours.
- No board appears twice.
- Sizes rise; from chapter 8 each chapter is mostly 9×9 and its median effort never falls; the last chapter's median is 28 or more, and level 600 is a LEGEND of 36 or more.
- Every 9×9 fits the shape guard, and at least 60 are past effort 25.
- Hearts from level 46; the clock stops growing at effort 30.
- Rooms, clocks, HEAD START, and level numbers carried over.

**Checked on the Pixel_8_Pro:**
- The hub shows Level 18 of 600.
- Chapter 1's page (Living Room, ◀ dimmed) and chapter 2 (Kitchen, locked).
- Level 18 from the data: Living Room at night, 5×5, MEDIUM, HEAD START. It was solved by tapping the stored answer, and its colours are distinct after the colour fix.

## Harder (2026-11-07)
The user asked what else could make Squishdoku harder, and chose two things: hearts, and harder boards from the tool. (Not chosen for now: furniture on some cushions as a later twist, and two creatures per row, column and patch on 10×10.)

**1. Hearts.** Before, a wrong tap was rejected at once and given its ✕, and cost nothing but the stars. A hard board could be beaten by tapping around until the creatures landed, so its thinking score didn't count.
- From level 46 (the first 7×7) a level has 3 hearts (`levels.js` `HEARTS`, `HEARTS_FROM`; `levelSpec` gives `hearts`, 0 before 46).
- A mistake costs one: the heart pops and greys (`components/Hearts.js`, Squish Sort's heart, now shared) with Sort's `fs_heart` sound.
- The third locks the board at once and stops the clock. The wrong creature's shake plays out, then **OUT OF HEARTS!** with RETRY (the same board) and MAP (`TimeUpCard` with `hearts`). It counts as a play, like time's up.
- Levels 1-45 keep free mistakes, for learning. Stars are unchanged: a mistake still leaves 1.
- The hearts sit at the right of the score creatures, on the glass. Level 46's banner says "NEW: 3 HEARTS! A MISTAKE COSTS ONE" and stays up longer. The rules card says it too.
- Blitz is unchanged: one mistake already ends a run there.

**2. Harder boards: the climb.** The plain maker's 9×9s top out about 25-27. The tool now also climbs:
- A board's patches are reshaped a cell at a time. A change is kept if the patch it left is still in one piece, there's still exactly one answer, the grader still solves it by logic, and the effort didn't drop. A climb stops after 150·n tries without a gain.
- **The shape guard** (`tools/squishdoku/shape.mjs`): unguarded, the climb wins by growing snakes and one-cell-wide passages (17 of those "corridor" cells on a board, against 7 on a plain one). So a change is kept only if the board's corridors, tips, total edges and perimeter ratios are each within the 95th percentile of 1,500 plain 9×9s. Since the second run every 9×9, plain ones too, must fit: the plain maker's rare hard boards were often snaky as well.
- Guarded, one minute of 8 workers climbed 175 boards: 34 at effort 30 or more, the best 48.
- Each of the 8 jobs climbs 100 boards after its plain ones (`CLIMBS`), seeded, so a run is still the same on any machine. It takes about 7.5 minutes.
- What the run gave:

```
chapter  levels    sizes                 effort min / median / max   (targets)
   1     1-20    4×4 16×5                0 /   1 /   3      (0-3)
   2    21-40    2×5 18×6                1 /   3 /   5      (1-5)
   3    41-60    5×6 15×7                1 /   3 /   8      (1-8)
   4    61-80    20×7                    2 /   6 /   8      (2-8)
   5    81-100   20×8                    3 /   4 /  10      (3-10)
   6   101-120   20×8                    3 /   7 /  10      (3-10)
   7   121-140   1×7 10×8 9×9            3 /   9 /  13      (3-13)
   8   141-160   1×7 2×8 17×9            4 /   7 /  14      (4-14)
   9   161-180   1×7 2×8 17×9            5 /   8 /  15      (5-15)
  10   181-200   1×7 2×8 17×9            5 /   9 /  16      (5-16)
  11   201-220   1×7 2×8 17×9            6 /  10 /  17      (6-17)
  12   221-240   1×7 2×8 17×9            6 /  12 /  19      (6-19)
  13   241-260   1×7 2×8 17×9            7 /  13 /  20      (7-20)
  14   261-280   1×7 2×8 17×9            7 /  14 /  21      (7-21)
  15   281-300   1×7 2×8 17×9            8 /  15 /  22      (8-22)
  16   301-320   1×7 2×8 17×9            8 /  16 /  23      (8-23)
  17   321-340   1×7 2×8 17×9            8 /  18 /  25      (8-24)
  18   341-360   1×7 2×8 17×9            8 /  19 /  26      (8-26)
  19   361-380   1×7 2×8 17×9            8 /  20 /  27      (8-27)
  20   381-400   1×7 2×8 17×9            8 /  21 /  28      (8-28)
  21   401-420   1×7 2×8 17×9            8 /  22 /  29      (8-29)
  22   421-440   1×7 2×8 17×9            8 /  24 /  30      (8-30)
  23   441-460   1×7 2×8 17×9            8 /  25 /  32      (8-32)
  24   461-480   1×7 2×8 17×9            8 /  26 /  33      (8-33)
  25   481-500   1×7 2×8 17×9            8 /  27 /  34      (8-34)
  26   501-520   1×7 2×8 17×9            8 /  28 /  35      (8-35)
  27   521-540   1×7 2×8 17×9            8 /  29 /  36      (8-36)
  28   541-560   1×7 2×8 17×9            8 /  30 /  37      (8-38)
  29   561-580   1×7 2×8 17×9            8 /  32 /  38      (8-39)
  30   581-600   1×7 2×8 17×9            8 /  33 /  40      (8-40)

levels more than 2 off their target: 0
climbed boards used: 215, plain: 385
  plain 9×9    185 boards: corridors 7.63, tips 16.57, edges 140.85, perimeter ratio 1.26
  climbed 9×9  215 boards: corridors 10.20, tips 18.36, edges 148.05, perimeter ratio 1.30
```

## Saved data
The profile's `sdk` field is client-written, like coins:
- `lv`: the highest unlocked level
- `best`: `{ level: creatures }`
- `perfect`: `{ level: true }`
- `xp`: the old Puzzle XP. It's no longer written; it was added to the player's `pxp` once (PLAYER_XP.md)
- `skill` and `bSkill`
- `blitz`: `{ top, runs }` (the endless Blitz: the most boards cleared in one run, and how many runs); `reached`, `bestMs` and `wins` were the ten-board runs' and are no longer written
- `head`: HEAD START on or off
- `plays` and `solves`

## Code
- `src/squishdoku/engine.js`: generator, player-style grader, uniqueness repair. Tests: `node src/squishdoku/engine.test.js`.
- `src/squishdoku/levels.js`: level table, timers, stars, rewards, XP, skill.
- `src/squishdoku/*.js`: board, HUD, result, map, hub, blitz, effects.
- `src/screens/SquishdokuScreen.js`: the screen. It opens from the PLAY game picker.

## Status (2026-10-22)
Built and played on the Pixel_8_Pro emulator, using a debug build and a script that read the board off screenshots and solved it. Each of these worked on screen:
- **Regular:** the hub, the rules card, the map, level play, placing and mistakes, the ✕ tool, drag-✕ and long-press ✕, creatures falling off the timer, time's up, pause, the result screen with PERFECT, and a Puzzle Level up.
- **Blitz:** the countdown, a full 10-board run to the win screen, a mistake opening the revive card, and BACK TO LEVEL 1.
- **Saving:** progress, XP and the Blitz best showed up correctly in the hub afterwards.

Still to do:
- **Speed:** check it on a **release build on the A15**. The emulator was swap-thrashing in debug, so its slow taps don't show how the game really performs.
- **Sounds:** they were generated and checked for levels and clipping, but nobody has listened to them yet. Play through and say which ones to change.
- **Timers** in `levels.js` (`TIMES`, `BLITZ_MS`) are first guesses. Tune them after real play. 4×4 at 15 s for 3 creatures may be too tight.
- **Haptics** are untested; the emulator has none.

## Later (not in v1)
- **Rescue the lost creatures**: chapters of 10 levels, each uncovering a mystery creature.
- **Daily Creature Puzzle**, counted toward the streak.
- Daily-challenge events.
- ~~Puzzle XP feeding the season pass~~: replaced by the player XP (PLAYER_XP.md).

## Hub and Blitz redesign (2026-11-16)

The user's list, from a screenshot of the hub.

**The hub** (`src/squishdoku/Hub.js`)
- The two modes are **REGULAR MODE** and **BLITZ MODE** cards in the app's new design: a wood plaque like the Game
  Park's game card, the name in the menu's lettering, a picture in a gold-ringed window, and one line under it.
  - The pictures are the Game Park clip's last frame, as is for Regular and turned electric blue with lightning bolts
    for Blitz (`tools/squishdoku/mode-art.mjs` -> `assets/squishdoku/mode-*.jpg`).
- No PLAY or GO buttons: the whole card is tapped.
- REGULAR MODE's line is the progress bar and "25/600" on one row. "Level 25 of 600" and "Beat the clock…" are gone.
- BLITZ MODE's only line is the best run: "BEST: 12".
- The title stands alone: the two creature heads beside it were removed (the user, 2026-11-16).
- HEAD START has no creature picture and says plainly what it does: REGULAR MODE, "Every level starts with 1 creature
  already placed", "20% less time · 40% fewer coins & XP".
- HOW TO PLAY has a ? where the X was.
- Squish Sort's and Squish Stack's hubs still use the old cards (`ModeCard`).

**BLITZ MODE** (`src/squishdoku/BlitzGame.js`, `levels.js` blitzSpec / blitzPrize / afterBlitz)
- One board after another, with no end. Each board has its own clock, and the clocks are short: 12 s for a 4×4, 20 for
  5×5, 30 for 6×6, 42 for 7×7 and 56 for 8×8. Every one is under Regular's 3-creature time for that size (a test checks
  it).
- The sizes climb: 4×4 twice, 5×5 three times, 6×6 four, 7×7 five, then 8×8 for good. From there the boards are harder
  (tier 1, tier 2 from board 21), and each clock is 3% shorter than the last, down to three quarters (42 s).
- One mistake, or a board's clock running out, ends the run, unless the player saves it:
  - **with a rewarded ad**, once a run (free with Remove Ads);
  - **with gems**: 10, then 20, 40, 80 … up to 320 in the same run. The `squad` function's `blitzSave` move charges
    them (`functions/squad.js`).
  - A save after a mistake goes on with the board's clock where it was; after the clock ran out, the board's clock
    starts again.
  - **END RUN** is GAME OVER.
  - The save card (the user's second look): the words in the middle, then the buttons in one row, 8% shorter than
    before. The ad's button shows only until it has been used once in the run.
- GAME OVER shows the boards cleared, the best (or NEW BEST!), and what the run paid.
  - It's one column, with the title on top. There are no score creatures, because Blitz has no stars.
  - QUIT and PLAY AGAIN are the same size, and PLAY AGAIN is gold like the app's other buttons.
  - Each board cleared pays coins by its size (30, 50, 70, 100, 130).
  - It also pays a tenth of config/levels `xp.blitz.squishdoku` in XP (40 by default).
  - Quitting or restarting in the middle of a run pays it too.
- HEAD START: since 2026-11-16 (the user: Blitz was a little too hard) every board starts with 1 creature placed,
  whether the hub's HEAD START switch is on or off. It is the first row's creature, dropped in once the board has
  landed, and the board's clock starts 0.35 s later. It costs nothing: the clocks and the pay are unchanged.
- The HUD: BOARD n, CLEARED and BEST, "1 MISTAKE = GAME OVER", and the board's clock.
- The skill (`bSkill`) still nudges the boards' tiers: up after a run of 10 or more, down after one under 5.
- Checked in the web version:
  - A board cleared, then on to board 2 with a fresh 12 s clock.
  - A mistake opened the save card. The ad save carried on with the same board, and its button was gone at the next
    mistake.
  - The clock running out showed TIME'S UP.
  - END RUN showed GAME OVER with NEW BEST and +30 coins / +40 XP.
  - The gem save wasn't tried: it spends real gems on the test account, and the move needs a functions deploy.

## Reactions on the room board (2026-11-17)
The user's list: a right creature pops in with a squash, turns happy, hops and sparkles, and a happy wave ripples along
the row, column or box it completes; a wrong one shakes "no", turns sad, flashes red and drops away; a win turns every
creature happy with a bounce rippling out from the last one placed; a loss turns every creature sad, drooping and
sinking one after another. In both Regular and Blitz.

- **Faces on the whole bodies.** The list said the tiles are heads (heads.js), but since the room remodel (2026-11-07)
  the board's creatures stand on their cushions, body and all, with no faces. I kept the bodies and gave them faces
  (my reading: the user's own remodel stands, and the faces were the point).
  - `tools/squishdoku/faces.mjs` renders each board creature (every one with a Squish Stack cut-out, minus the Masked
    and Elemental Heroes) from its rig in three faces: idle, happy and sad. The face poses are heads.mjs's (face
    channels only, no body motion), so the three line up.
  - The board draws these renders, not the Stack cut-outs. The cut-outs were made from older rigs and eye glances, a
    few pixels off, so a face faded in over them would jump.
  - Output: `assets/squishdoku/bodies/<key>-<face>.webp` (256 px longest side; 79 creatures, 2.5 MB) and
    `src/squishdoku/bodies.js` (key -> idle, happy, sad, ar). Re-run it after a new roster creature. A creature with
    no render falls back to its cut-out, without faces.
  - `Piece` (src/hop/Pieces.js) draws a creature with `c.faces` as the idle picture with the happy and sad ones faded
    over it (the idle one goes once a face is fully in, so a sad ear doesn't show twice), plus a red-tinted copy for
    the red flash.
- **Moves:** the creatures now use Squish Hop's juicy poses (`freshPose({ juicy: true })`), which already have the
  head shake "no" (a turn), the droop and the springy landing.
- **Right** (`RoomBoard.place`): it pops up out of its cushion from small, feet planted, with an overshoot (0.2 s),
  then lands with a squash. It turns happy for about a second, does a hop for joy, and sparkles twice.
  - Every right creature completes its row, its column and its patch, since each holds exactly one. So every right
    creature sends the happy wave out along all three, 55 ms a cell: each cushion bobs, a soft glow comes up on it,
    and a little star pops up off it (`fx.js` `wave`, one native timing for the whole wave).
  - The creatures already placed cheer with a hop and a short happy face.
- **Wrong** (`RoomBoard.wrong`): it pops up the same, turns sad as it lands, flashes red twice (the creature itself;
  the cell's red glow as before), shakes its head "no", then drops away (falls, shrinks, tips and fades) in a poof,
  about 1.3 s in all. The others flinch with a worried face.
- **Win** (`hopAll(from)`): every creature turns happy and stays so. A bounce ripples out from the last one placed:
  the cushions bob, each creature jumps when it's reached (twice in Regular, once in Blitz, where the next board is
  waiting), and stars rise off half the cells (not every cell: a 9×9's would mount ~150 views at once). It starts as
  the last creature lands. The games play their hop sound at each jump.
- **Lose** (`sadAll(from)`): one creature after another, the nearest the mistake first (otherwise back to front),
  turns sad, droops (squashed down, tipped toward you, leaning a little) and sinks a little. They stay so.
  - Regular: the clock running out, and the last heart. The card now waits for the droop (Regular's time-up card
    used to show at once; there is a locked 'out' phase first now).
  - Blitz: a mistake or the board's clock. Its droop is quicker (100 ms apart), and the save card comes up as the
    last one sinks. A save (`cheerUp`) brings everyone back with a hop.
  - Blitz now waits as long as the win's ripple needs before the next board (0.65 s or more).
- **Checked in the web version** (headless Chrome with a slowed clock, `sd-level` / `sd-blitz` in the preview, played
  by `window.__sdk`): a right creature and its wave, a wrong one, the win on a 5×5 and a 9×9, the time-up droop and
  its card, and in Blitz a cleared board, a mistake with the droop and the save card, and the save.
- **Not checked yet:** a phone. Each creature is now four pictures and the juicy poses' 3D turns, and the waves add
  views, so the A15 (release build) is the thing to watch.

## The map in its room (2026-11-17)

The user: "in the squishdoku, the rooms change so there each background will be tailored to the room that the levels
are played in". Sideways the level map stands in the chapter's room (`RoomBackdrop` in `src/royal/WorldBg.js`, the
whole room as `src/hop/Room.js` draws it with `full`, in daylight); turning the chapter fades to the next room
(`LevelMap` `onChapter`). The row runs along the floor (`rowAt` = `ROW_ON_FLOOR`, 0.75 of the map's height), the
chapter's name and arrows level with it (its room picture left out: the room is behind it), LEVELS on a wooden plaque.
Web-checked only.

**Scrolling with the list (2026-11-17).** The user: the background "not being scrolled" when the list is. The room is
now the chapter's page long, its picture repeated side by side, and moves with the levels: `LevelMap` reports it
(`onSpans`, which replaced `onChapter`) and drives the screen's `scrollX` with the page's scroll on the UI thread
(SQUISH_HOP.md "Scrolling with the list" has the details). Turning the chapter still fades to the next room. Web-checked
only.
