# Squish Hop (prototype)

A path puzzle sketch: the squishy hops across cushions laid on the floor, and each cushion puffs away when it hops off, so it can never go back. It has to reach the ★ cushion, and clearing every other cushion first gives 3 stars. Asked for on 2026-11-05, after the user turned down the four mashup sketches in `../mashups`.

Open `index.html` from a checkout of this repo. It loads the real files from `/assets`, so it has to stay where it is. Nothing to install. For a copy that opens anywhere, run `tools/bundle.mjs` (below).

## The look: a hop through the Crib (2026-11-05, second round)
The first version used the Squishdoku board: velvet cushions in a framed quilt, with heads for pieces. The user said it looked too much like Squishdoku. Three new looks were mocked up: the Crib's dance room, the Crib's living room, and the app's sky. The user picked "a mix of all the rooms".

So every level is set in one of the Crib's rooms, at a time of day, and the levels walk through the house:

| Level | Room | Time | Floor pieces |
|---|---|---|---|
| 1 | Living Room | day | mint cushions on the living-room rug |
| 2 | Kitchen | morning | lilac cushions |
| 3 | Bathroom | day | pink cushions |
| 4 | Bedroom | evening | lilac cushions |
| 5 | Yard | evening | pink cushions |
| 6 | Living Room | evening | mint cushions on the rug |
| 7 | Bedroom | night | lilac cushions |
| 8 | Dance Room | | the Crib's light-up floor tiles, which go dark when left |

Nothing on the page is new art. All of it is taken from the repo:

- **Rooms:** the Crib's room layers (`assets/crib/rooms`, placed as in `src/crib/roomArt.js` and `src/crib/art.js`):
  - the yard's sky underneath, then the room, then its furniture for the time of day
  - cut at the room's floor line (`FLOOR_TOP`), with the floor repeated down to the bottom of the screen
  - evening and night get the Crib's tints (`src/crib/data.js` `PHASES`)
  - the living-room rug is the Crib's rug fixture
  - moving to a new room shows the Crib's room-switch flash (`flash-glow` and `flash-dots`)
- **Board:** laid on the floor in perspective (CSS 3D, leaned back 38°).
  - Cushions are Squish Stack's stitched cushions (`src/stack/Pieces.js`: ring, white piping, stitching, tuft) in its four colours. Peach is always the ★ cushion.
  - A double is a pile: two cushions stacked on each other.
  - The Dance Room uses the Crib's dance-floor colours (`src/crib/Dance.js`: the four tile colours in its 2 × 2 pattern, the dark lines, the pink glow). They step round the colour wheel like the room's floor does.
- **Squishies:** Squish Stack's full-body cut-outs (`assets/stack`), standing upright on the tilted board.
  - Bubbly is the player. Boba, Mochi, Berri, Dunkie and Pip are the friends.
  - Their heads with faces (`assets/squishdoku/heads`) are used in the goal card and the STUCK card.
  - The ★ floats over its cushion.
- **Top bar:** the Crib's HUD (`src/crib/Hud.js`): the round pink button with the brown ring and lip, the cream-to-peach room title, and the brown glass time-of-day pill.
- **Bottom strip:** the goal (friends › ★), the star meter, LEFT and HOPS, and the tip line, on the Crib's brown glass.
- **Buttons:** UNDO, RESTART and HINT are pill buttons with the Crib's button faces (blue, purple, gold) on its brown ring.
- **Cards:** the cards all the mini-games share (`squishdoku/Overlays.js`, Squish Stack's): result, stuck, pause, hint, how to play and levels. They have the outlined titles, the stars that pop in with rays, and Squish Sort's news banner.
- **Sounds:** from `assets/audio`:
  - hop: `st_lift`
  - cushion puff: `pop`
  - bump: `bonk`
  - undo: `st_undo`
  - hint: `st_hint`
  - friend: `sd_squeak`
  - ★ opens: `sd_unlock`
  - stuck: `sd_wrong`
  - finish: `st_land` and `sd_solve`
  - stars: `sd_star1-3`, `sd_starEmpty` and `sd_perfect`
  - board in: `sd_boardIn`
  - news: `st_news`
  - room change: `swoosh`

## Rules
- **Hop** one cushion at a time: swipe (a long drag can turn corners), use the arrow keys or WASD, or tap a cushion next to the squishy. Up is toward the back of the room.
- **Puff:** the cushion the squishy hops off puffs away and leaves a dent. A hop into a dent or a hole just bumps.
- **The ★ cushion** ends the level.
- **Friends** (from level 4) sit on cushions. Hopping onto one picks it up, and it flies to the goal card. The ★ stays shut, grey with a count of friends still to get, until every friend is picked up.
- **Piles** (doubles, from level 6) are two cushions on top of each other. They take two hops to clear: the first hop takes the top cushion off.
- **Stuck:** no cushion left to hop onto opens the STUCK card, with UNDO and RETRY.

## Stars, hint
- **Stars:**
  - 3 stars: every cushion cleared.
  - 2 stars: up to 3 cushions left.
  - 1 star: more than 3 left.
- **The meter** shows 3 while a full clear is still possible. As soon as it isn't, it drops to 2 and the tip says so ("UNDO to go for 3 stars!"). The solver checks this after every hop.
- **HINT** makes the next right cushion glow gold.
  - If a full clear is no longer possible, it first goes back to the last spot where one was.
  - A hinted level gives one star less, as in Squish Stack.
  - The first hint in a level asks first. In the app that would be the rewarded ad.
- **UNDO** takes back one hop. **RESTART** starts the level over.

## Levels
8 levels, found by a random search and checked by the solver:

| Level | Board | Twist | Tier | Full-clear paths |
|---|---|---|---|---|
| 1 | 4×3 | | EASY | 4 |
| 2 | 4×4 | | EASY | 1 |
| 3 | 5×4 | | MEDIUM | 1 |
| 4 | 5×5 | 1 friend | MEDIUM | 1 |
| 5 | 6×5 | 2 friends | HARD | 1 |
| 6 | 5×5 | 2 piles | MEDIUM | 3 |
| 7 | 6×6 | 3 piles, 1 friend | HARD | 11 |
| 8 | 7×6 | 3 piles, 2 friends | EXPERT | 28 |

The search keeps boards with few full-clear paths that random play almost never clears. On levels 5, 7 and 8, random hopping cleared none of 600 tries. Piles add many more ways through, so levels 7 and 8 have more paths, but they are still hard to find.

## Files
| File | What it is |
|---|---|
| `index.html` | The page. Styles, rooms, board and game code. |
| `engine.js` | The rules and the solver (depth-first search, cut short by a "still in one piece" check and a dead-end check). Runs in the page and in Node. |
| `levels.js` | The levels, written by `tools/gen.mjs`. Don't edit by hand. |
| `tools/picks.json` | The chosen boards that `levels.js` is built from. |
| `tools/gen.mjs` | The level search: `node tools/gen.mjs [seconds per level] [--only=7,8]`. `--write` only rebuilds `levels.js` from `picks.json`. |
| `tools/check.mjs` | Tests: the solver against brute force on 3000 small random boards, and a full clear on every level. `node tools/check.mjs` |
| `tools/bundle.mjs` | One self-contained file (scripts and assets inlined, about 2.3 MB): `node tools/bundle.mjs <out.html>`. `--artifact` drops the html/head/body wrapper for a claude.ai Artifact. |

Progress (best stars, the how-to-play card seen, sound on/off) is saved in the browser's localStorage under `squishHop.v1`.
