# Squish Hop (prototype)

A path puzzle sketch: the squishy hops across cushions laid on the floor, and each cushion puffs away when it hops off, so it can never go back. It has to reach the ★ cushion, and clearing every other cushion first gives 3 stars. Asked for on 2026-11-05, after the user turned down the four mashup sketches in `../mashups`.

Open `index.html` from a checkout of this repo. It loads the real files from `/assets`, so it has to stay where it is. Nothing to install. For a copy that opens anywhere, run `tools/bundle.mjs` (below).

## The look: a hop through the Crib (2026-11-05, second round)
The first version used the Squishdoku board: velvet cushions in a framed quilt, with heads for pieces. The user said it looked too much like Squishdoku. Three new looks were mocked up: the Crib's dance room, the Crib's living room, and the app's sky. The user picked "a mix of all the rooms".

So every level is set in one of the Crib's rooms, and the 100 levels walk through the house. Each room brings in a twist, and the time of day moves on (morning, day, evening, night) through each room's levels:

| Levels | Room | New twist | Floor pieces |
|---|---|---|---|
| 1–14 | Living Room | friends (8) | mint cushions on the living-room rug |
| 15–30 | Kitchen | arrows (15) | lilac cushions |
| 31–46 | Bathroom | bubbles (31) | pink cushions |
| 47–62 | Bedroom | piles (47), friends in order (55) | lilac cushions |
| 63–80 | Yard | everything mixed, bigger boards | pink cushions |
| 81–100 | Dance Room | beat tiles (81), then everything, up to 7×8 | the Crib's light-up floor tiles |

Nothing on the page is new art. All of it is taken from the repo:

- **Rooms:** the Crib's room layers (`assets/crib/rooms`, placed as in `src/crib/roomArt.js` and `src/crib/art.js`):
  - the yard's sky underneath, then the room, then its furniture for the time of day
  - cut at the room's floor line (`FLOOR_TOP`), with the floor repeated down to the bottom of the screen
  - evening and night get the Crib's tints (`src/crib/data.js` `PHASES`)
  - the living-room rug is the Crib's rug fixture
  - moving to a new room shows the Crib's room-switch flash (`flash-glow` and `flash-dots`)
- **Board:** laid on the floor in perspective (CSS 3D, leaned back 38°).
  - Cushions are Squish Stack's stitched cushions (`src/stack/Pieces.js`: ring, white piping, stitching, tuft) in its four colours. Peach is always the ★ cushion.
  - A pile is two cushions stacked on each other.
  - An arrow is the Crib's back chevron (`src/crib/Hud.js`) printed on the cushion, turned the way it points.
  - A bubble floats over its cushion.
  - The Dance Room uses the Crib's dance-floor colours (`src/crib/Dance.js`: the four tile colours in its 2 × 2 pattern, the dark lines, the pink glow). They step round the colour wheel like the room's floor does. On beat levels the plain tiles are its mint and the three beats its pink, blue and yellow.
- **Squishies:** Squish Stack's full-body cut-outs (`assets/stack`), standing upright on the tilted board.
  - Bubbly is the player. Boba, Mochi, Berri, Dunkie and Pip are the friends.
  - Their heads with faces (`assets/squishdoku/heads`) are used in the goal card and the STUCK card.
  - Numbered friends wear a pink number chip.
  - The ★ floats over its cushion.
- **Top bar:** the Crib's HUD (`src/crib/Hud.js`): the round pink button with the brown ring and lip, the cream-to-peach room title, and the brown glass time-of-day pill.
- **Bottom strip:** the goal (friends › ★), the star meter, LEFT and HOPS, and the tip line, on the Crib's brown glass.
- **Buttons:** UNDO, RESTART and HINT are pill buttons with the Crib's button faces (blue, purple, gold) on its brown ring.
- **Cards:** the cards all the mini-games share (`squishdoku/Overlays.js`, Squish Stack's): result, stuck, pause, hint, how to play and levels. They have the outlined titles, the stars that pop in with rays, and Squish Sort's news banner.
- **Sounds:** from `assets/audio`:
  - hop: `st_lift`
  - cushion puff: `pop`
  - bubble bounce: `bubble_tap`
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
- **Stuck:** with nowhere left to hop, the STUCK card opens, with UNDO and RETRY.

The twists (the letters are the map letters in `engine.js`):

| Twist | Letter | Rule | First seen |
|---|---|---|---|
| Friends | `F` | Hop onto a friend to pick it up; it flies to the goal card. The ★ stays shut, grey with a count, until every friend is picked up. | 8 |
| Arrows | `^ > v <` | You can only hop off an arrow cushion the way it points. | 15 |
| Bubbles | `o` | Hop onto a bubble and it bounces you on, one cushion further the same way (and on again over more bubbles). It pops as you pass. You can't hop onto it if there's nothing to land on past it. | 31 |
| Piles | `D` | Two cushions on top of each other: two hops to clear. | 47 |
| Friends in order | `1`–`9` | Numbered friends are picked up 1, 2, 3… | 55 |
| Beat tiles | `a b c` | Dance Room only. A coloured tile is lit every third hop and can only be landed on lit. The BEAT pill shows the colour of the next hop first. (Every cell a hop lands on counts, bubbles too.) | 81 |

A blocked hop bumps, and the tip line says why (the arrow, the bubble, the order, the beat or the shut ★).

## Stars, hint
- **Stars:**
  - 3 stars: every cushion cleared.
  - 2 stars: up to 3 cushions left.
  - 1 star: more than 3 left.
- **The meter** shows 3 while a full clear is still possible. As soon as it isn't, it drops to 2 and the tip says so ("UNDO to go for 3 stars!"). From level 5 on there is exactly one full clear, so this is exact: you're still on it or you're not. On levels 1–4 the solver checks after every hop.
- **HINT** makes the next right cushion glow and lift. If you've already left the full clear, it first goes back to the last spot that was still on it.
  - A hinted level gives one star less, as in Squish Stack.
  - The first hint in a level asks first. In the app that would be the rewarded ad.
- **UNDO** takes back one hop. **RESTART** starts the level over.

## Levels
100 levels, made by `tools/gen.mjs`. For each level it:
1. Takes a random walk over the grid that covers the board. The cells it skips become holes; with piles, some cells are walked twice. The walk's start is S, its end the ★.
2. Places the level's twists so that the walk still works:
   - an arrow points the way the walk leaves
   - a bubble sits where the walk goes straight through
   - a beat tile gets the beat the walk lands on it with
   - friends in order are numbered in walk order
3. If another full clear exists, adds one more twist that the other clear breaks and the walk keeps, until the walk is the **only** full clear. Levels 1–4 may have up to three.
4. Scores the board's **effort**: how many moves the solver tries before it finds the clear, averaged over shuffled move orders.

Each slot tried between about 190 candidates (the biggest boards) and 460,000 (level 1) in 10–20 seconds on one core. It then picked one on a log scale of effort:
- the level that brings in a twist is easy
- every fifth level is a breather
- the rest climb through the room
- each room's last level is near the hardest found
- later rooms reach higher

Effort runs from 8 (level 1) through tens and hundreds in the first rooms to thousands later on. Each room's last level gets harder: 281, 2,882, 4,784, 16,297 and 11,615. The finale, levels 96–100, runs from 13,000 to 114,000. The tier chip (EASY to EXPERT) is the level's effort rank among all 100.

## Files
| File | What it is |
|---|---|
| `index.html` | The page. Styles, rooms, board and game code. |
| `engine.js` | The rules (`tryMove`) and the solver. The solver is a depth-first search, cut short by four checks: the board is still in one piece, no dead ends, every arrow has somewhere to send you, and every bubble has a way through. Runs in the page and in Node. |
| `levels.js` | The levels, written by `tools/gen.mjs`. Don't edit by hand. |
| `tools/picks.json` | The chosen boards that `levels.js` is built from. |
| `tools/gen.mjs` | The level search. Steps below. |
| `tools/check.mjs` | Tests, run with `node tools/check.mjs`. It checks the solver against brute force on about 40,000 small random boards with every twist (about 2,800 of them clearable), and that each level has the stated number of full clears and its stored answer replays. |
| `tools/bundle.mjs` | One self-contained file (scripts and assets inlined, about 3 MB): `node tools/bundle.mjs <out.html>`. `--artifact` drops the html/head/body wrapper for a claude.ai Artifact. |

Progress (best stars, the how-to-play card seen, sound on/off) is saved in the browser's localStorage under `squishHop.v2`, with the last level played.

To remake the levels:
1. Search the slots, several ranges at once, one per core, each writing its slots to the same folder:

   ```
   node tools/gen.mjs --slots=1-40 --secs=10 --out=DIR
   node tools/gen.mjs --slots=41-60 --secs=19 --out=DIR
   ```

2. Pick from the folder into `picks.json` and `levels.js`:

   ```
   node tools/gen.mjs --merge=DIR
   ```

3. Run `node tools/check.mjs`.

`node tools/gen.mjs --plan` prints the 100 slots (size, twists, pick spot).
