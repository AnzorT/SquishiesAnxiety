# Mashup mini-game sketches

`index.html` is a single self-contained page with four playable sketches of
possible Squish Squad mini-games. Open it in a browser; nothing to install.

| Game | Mix |
|---|---|
| Squish Squeeze | box-pushing puzzle + soft bodies (6 levels, stars, solver hint) |
| Claw Run | claw machine + roguelite (3 machines, upgrades) |
| Wash Day | match-3 + rotating gravity |
| Squish Choir | rhythm + memory (off-beats, tempo ramp, seat swap / duet / curtain twists) |

The plushies are drawn stand-ins and the sounds are synthesized in the browser.

## Squish Squeeze rules

- A plush is 2x2. Walk into a 1-wide gap and it squeezes into a 1x4 strip.
- A strip puffs back to 2x2 at its leading end as soon as there is room
  (preferring the side it squeezed from) and shoves anything there one cell.
- Blocks and plushies are pushed one cell, no chains. A pushed plush squeezes
  into gaps too. A round plush can't push a block into a 1-wide gap.
- Win: every plush round in its own bed, every toy box holding a block.

## Tools (`tools/`, Node 18+)

| File | What it does |
|---|---|
| `engine.js` | Squeeze rules + breadth-first solver (same code runs in the page) |
| `gen.js` | random level search: `node gen.js <seed> <seconds> <block1\|block2\|sleepy> <out.json>` |
| `show.js` | ASCII view + dead-end % of the top results: `node show.js b1.json 8` |
| `pick.js` | turns chosen results into `levels.js` (cleans and trims maps, sets par) |
| `sqzview.js`, `choir.js` | the Squeeze screen and the Choir game |
| `assemble.js` | writes the above back into `../index.html` |

`b1.json`, `b2.json` and `sl.json` are the saved search results the shipped
levels were picked from. To change levels: run `gen.js`, look with `show.js`,
edit the picks in `pick.js`, then run `pick.js` and `assemble.js`.
