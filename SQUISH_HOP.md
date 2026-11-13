# Squish Hop: the cushion-hopping mini-game

The fourth mini-game. It began as a web prototype made in a cloud session (`prototypes/squish-hop/`, branch `claude/thin-ice-game-repo-i9424j`, merged into develop on 2026-11-07). The user then asked: "take the idea and implement it on our app". The prototype's README has the design history: the rooms, the twists, and how the levels were made.

## Playing
- **Hop:** the squishy hops one cushion at a time. Swipe (a long drag can turn corners: one hop per half a tile of drag), or tap a cushion next to it. A quick flick that ends before a hop's worth of drag still hops once.
- **Puff:** the cushion it hops off puffs away, leaving a dashed dent. It can never go back there.
- **The ★ cushion** ends the level. Clearing every other cushion first is a full clear.
- **Stuck:** with nowhere left to hop, the STUCK card comes up with UNDO and RETRY.
- **The hopper** is the Lobby's squishy (if it has a cut-out). The friends are other squishies, the player's own first. A level always has the same friends, like its board (`roster.js`).

## The twists, room by room (100 levels)
| Levels | Room | New twist |
|---|---|---|
| 1-14 | Living Room | friends (8): pick them all up; the ★ is shut, grey with a count, until then |
| 15-30 | Kitchen | arrows (15): you can only hop off an arrow cushion the way it points |
| 31-46 | Bathroom | bubbles (31): land on one and it bounces you one further |
| 47-62 | Bedroom | piles (47): two cushions, two hops; friends in order (55): 1, 2, 3… |
| 63-80 | Yard | everything mixed, bigger boards |
| 81-100 | Dance Room | beat tiles (81): lit every third hop, landed on only when lit |

The first time a level brings a twist in, a banner says so (until that level has a result, like Squish Stack's).

## Stars, hint, rewards
- **Stars:** 3 for a full clear, 2 for up to 3 cushions left, 1 otherwise.
- **The meter** shows 3 while a full clear is still possible. Levels 5-100 have exactly one full clear, so this is exact: you're on it or you're not. Levels 1-4 ask the solver after every hop. Off it, the tip says "UNDO to go for 3 stars!".
- **Hint:** Squish Stack's rules. Every hint costs a rewarded ad (free with Remove Ads). The first one in a level asks first, and a hinted level gives one star less.
  - It shows the next cushion of the full clear, glowing gold.
  - If you've already left the full clear, it first takes you back to the last spot that was still on it ("Went back 2 hops").
- **UNDO** takes back one hop. **RESTART** plays the same board from the start (a taken hint stays taken).
- **Coins:** (8 + 0.6 per cushion + 4 per twist + 2 per friend) × stars (1 / 1.5 / 2) × tier (+15% each). That's 13 / 20 / 27 on level 1, 134 for 3 stars on level 90, and 198 on level 100.
- **XP:** Squish Sort's and Stack's formula, (10 + ½ × level + 5 × tier) × (0.6 + 0.2 × stars). Half on a replay, through playerXp.

## Every level is fixed
Unlike the other three mini-games, a level is the same board every time: played, replayed or retried. There's no random deal and no hidden skill score moving the tier. `src/hop/levelData.js` holds the 100 boards, made and checked offline by the prototype's `tools/gen.mjs` (unique full clear, effort score). A level's tier (EASY…EXPERT) is how hard its board measured against the others.

## Code (src/hop/)
- `engine.js`: the rules and the solver, an ES-module copy of `prototypes/squish-hop/engine.js` (keep the two the same).
- `levelData.js`: the boards (written from the prototype's `levels.js`; don't edit by hand).
- `levels.js`: rooms, the time of day through each room, tiers, the map's list, stars, coins, XP, and the profile's `hop` record.
- `board.js`: the board's perspective, worked out in JS: leaned back 38°, seen from 13 tiles away, as the prototype's CSS.
  - It gives where a squishy stands, which cell a tap is on, and the cushions' outlines on screen.
  - Doing it in JS rather than with an RN 3D transform means drawing, standing and touching all use the same numbers. Only the rug uses RN's own `perspective` + `rotateX` (it's decoration).
- `Pieces.js`: the drawing.
  - Cushions and dance tiles as tilted SVG shapes, one view per layer so each can puff away and back.
  - Arrows, bubbles, the ★, the hint glow, and the flat cushion used in the goal card and the picker.
  - The squishies: Stack's cut-outs. Every hop is one native timing (`freshPose`), so nothing steps from JS.
- `Room.js`: the Crib's room layers scaled so the floor line sits about a third of the way down, the floor repeated below, the time-of-day tint; and `RoomCard`, the map's room picture.
- `Game.js`: a level (input, hops, puffs, friends flying to the goal card, undo, hint, stuck, win), and the next ones after it, with the Crib's room-switch flash between rooms.
- `Cards.js`: the result, STUCK, pause, hint and how-to-play cards.
- `roster.js`: the hopper and each level's friends.
- `src/screens/HopScreen.js`: the map (Squish Sort's `LevelMap`, with a band per room and its picture) and the game.
- **Hooked into the app:** the PICK A GAME card (`GamePicker.js` `HopArt`: a squishy hopping along three cushions that puff away), `LobbyScreen` `onOpenHop`, `App.js` stage `hop` (music: cozy).
- **Saved on the profile** (written by the client): `hop.{lv, best, plays, wins, seen}` through `saveHop`. firestore.rules doesn't block `hop`, so there's nothing to deploy.
- **Sounds:** all existing ones. Hop: `st_lift`. Puff: `fs_pop`. Bubble: `tap` (the bubble). Bump: `bonk`. Friend: `sd_squeak`. ★ opens: `sd_unlock`. Stuck: `sd_wrong`. Win: `st_land`, `sd_solve`, `sd_confetti`. Room change: `swoosh`.
- **Tests:** `node src/hop/engine.test.js`.
  - Every level's stored clear replays to a full clear, and the first eight have the number of clears the data says.
  - A tap anywhere in any cell finds that cell, on every board, at three area sizes, and the board fits.
  - The rooms, times of day, stars, coins and XP are right.
  - The solver itself is checked against brute force by `prototypes/squish-hop/tools/check.mjs`.

## Status (2026-11-07)
- Played on the Pixel_8_Pro debug build:
  - the picker card and its animation, the map (room pictures and banners), the how-to-play card on a first visit
  - level 1 (taps and swipes, puffs, the win, ALL CLEAR with +27 coins and +12 XP, level 2 unlocked and saved), NEXT to level 2
  - level 90 (Dance Room: beats, bubbles, piles, arrows), its whole 45-hop clear
  - level 58 (Bedroom: four friends in order, picked up and landing in the goal card in order), its whole clear
  - getting stuck (STUCK card, UNDO from it), the hint through a Google test ad (back 2 hops, the glow, one star less)
  - level 70 (Yard).
- **Fixed from the prototype:**
  - The goal card lists friends in pick-up order, and it grows to fit them.
  - Friends are smaller, and numbered chips are drawn over everything, so a friend behind another can still be read.
  - HOPS counts hops, not cells entered.
- **Not yet checked:**
  - the room-switch flash on NEXT into a new room
  - the friends' flight to the goal card, frame by frame
  - speed on a release build on the A15
- The levels are still the prototype's 100. The 600-levels-per-game plan (fixed, measured difficulty for every mini-game) is next, waiting on the user's decisions.
