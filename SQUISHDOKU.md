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

## Regular mode: 50 levels
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
- A switch on the Squishdoku hub, for both modes, saved in `sdk.head`.
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

## Saved data
The profile's `sdk` field is client-written, like coins:
- `lv`: the highest unlocked level
- `best`: `{ level: creatures }`
- `perfect`: `{ level: true }`
- `xp`: the old Puzzle XP. It's no longer written; it was added to the player's `pxp` once (PLAYER_XP.md)
- `skill` and `bSkill`
- `blitz`: `{ reached, bestMs, wins }`
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
