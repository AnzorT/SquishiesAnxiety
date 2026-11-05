# Squish Hop (prototype)

A path puzzle sketch: the squishy hops across a quilt of cushions, and each cushion puffs away when it hops off, so it can never go back. It has to reach the ★ cushion, and clearing every other cushion first gives 3 stars. Asked for on 2026-11-05, after the user turned down the four mashup sketches in `../mashups`.

Open `index.html` from a checkout of this repo. It loads the real files from `/assets`, so it has to stay where it is. Nothing to install. For a copy that opens anywhere, run `tools/bundle.mjs` (below).

## Made from the app's own parts
Nothing on the page is new art. All of it is taken from the repo:

- **Squishy:** Bubbly's head with its idle, happy and sad faces (`assets/squishdoku/heads`, from `tools/rig/heads.mjs`).
- **Friends:** Boba, Mochi, Berri, Dunkie and Pip, from the same heads.
- **Cushions:** the Squishdoku cushions (`assets/squishdoku/cushions`): violet for a plain cushion, magenta for a double, gold for the ★. The ★ badge is Squish Stack's.
- **Board frame:** the Squishdoku board frame (plum ring, white rim, lilac seams).
- **Screen:** laid out like Squish Stack:
  - the top bar (‹, game name, LEVEL with its tier chip, a HOPS pill)
  - the goal card, the star meter and its pill, the tip line
  - the board
  - UNDO / RESTART / HINT
- **Cards:** the Squishdoku and Stack cards (result, stuck, pause, hint, how to play, levels), with the outlined titles, the stars that pop in with rays, and the news banner from Squish Sort.
- **Look:** the sky background with clouds, dots and sparkles, the candy buttons, the Fredoka and Nunito fonts, and the particle bursts (`squishdoku/fx.js`).
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

## Rules
- **Hop** one cushion at a time: swipe (a long drag can turn corners), use the arrow keys or WASD, or tap a cushion next to the squishy.
- **Puff:** the cushion the squishy hops off puffs away and leaves a dent. A hop into a dent or a hole just bumps.
- **The ★ cushion** ends the level.
- **Friends** (from level 4) sit on cushions. Hopping onto one picks it up, and it flies to the goal card. The ★ stays shut, grey with a count of friends still to get, until every friend is picked up.
- **Doubles** (from level 6) are magenta. They take two hops to clear: after the first hop they turn into a plain cushion.
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
| 6 | 5×5 | 2 doubles | MEDIUM | 3 |
| 7 | 6×6 | 3 doubles, 1 friend | HARD | 11 |
| 8 | 7×6 | 3 doubles, 2 friends | EXPERT | 28 |

The search keeps boards with few full-clear paths that random play almost never clears. On levels 5, 7 and 8, random hopping cleared none of 600 tries. Doubles add many more ways through, so levels 7 and 8 have more paths, but they are still hard to find.

## Files
| File | What it is |
|---|---|
| `index.html` | The page. Styles, screen and game code. |
| `engine.js` | The rules and the solver (depth-first search, cut short by a "still in one piece" check and a dead-end check). Runs in the page and in Node. |
| `levels.js` | The levels, written by `tools/gen.mjs`. Don't edit by hand. |
| `tools/picks.json` | The chosen boards that `levels.js` is built from. |
| `tools/gen.mjs` | The level search: `node tools/gen.mjs [seconds per level] [--only=7,8]`. `--write` only rebuilds `levels.js` from `picks.json`. |
| `tools/check.mjs` | Tests: the solver against brute force on 3000 small random boards, and a full clear on every level. `node tools/check.mjs` |
| `tools/bundle.mjs` | One self-contained file (scripts and assets inlined, about 1.4 MB): `node tools/bundle.mjs <out.html>`. `--artifact` drops the html/head/body wrapper for a claude.ai Artifact. |

Progress (best stars, the how-to-play card seen, sound on/off) is saved in the browser's localStorage under `squishHop.v1`.
