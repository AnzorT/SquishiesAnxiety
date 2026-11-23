# Squad House → Unity (C#): the plan

The owner chose (2026-11-23) to rewrite the house in C#, identical to the app: same look, same behaviour, the same
save (Firestore `users/{uid}/crib/house6`) so a player's house is the same in both apps. Each stage is checked against
the app by pixel diffs and traces, like the games.

Source: the prototype in `webgame/.cache/Squish-Squad-Prototype-Nov13-*/squish-squad/` (`Squad House v6.dc.html` +
94 scripts), our patches `webgame/patches.mjs`, the bridge `webgame/app/bridge.js`, the app side
`src/game/gameData.js` (loadHouse / saveHouse), `src/game/GameScreen.js`.

## What the 51.6k lines are

| Part | Lines | Port |
|---|---|---|
| The house itself (logic + template in the .dc.html) | ~1,770 + ~820 | **C# rewrite** |
| Small engines: beach logic, walk gaits, vacuum, fog, movie night, TV sound | ~1,100 | **C# rewrite** |
| Furniture / renovation drawing (RenoDraw `reno-*.js`, House3D `house4*.js`) | ~33k | pure functions returning SVG: **export their output**; the geometry maths (~40 lines) in C# |
| Creature rigs, moves, house moves (`rive-*.js`, `*-anims.js`, `house-*.js`) | 14.1k | the creature animation engine (shared with the rest of the app); export house-state metadata to JSON for the C# logic |
| dc / React runtime (support.js) | 1.9k | replaced by Unity |

## The save (`ssHouse5b` → Firestore `users/{uid}/crib/house6` = `{ data: '<JSON>', t }`)

`H = { owned, rOwn, sOwn, rooms: { room: [Item] }, toys, surf, rtex, lx, lz, lOff, night, open, seenLv, uid, cur, cr,
home, needs: { key: { h, c, e, f } }, bsh, shells, <one-shot migration flags> }`,
`Item = { id, t ('R:<renoId>' | legacy), x, y, r, c, e, w, r0, on, sz | sw, sh, st, txt, cl }`.
No version number: port `initH` with its migrations exactly. Round-trip rule: keep the parsed JSON and change only
known fields, so keys from a newer design survive. Coins for purchases: `UserData.CribCoins`.

## Reachable today (current design)

8 rooms (living Lv1, kitchen 2, bathroom 4, bedroom 6, backyard 8, dance 11, movie 12, beach 30), doors and the house
map; creatures: select, walk, quick actions, furniture actions (sit, nap, bath, cook, eat, watch, play...), needs
(decay / recover, "Hungry..."); room toggles (lights, party); item taps (TV channels, fridge, vacuum robot, fog...);
toys; Renovate (edit mode: drag, wall snap, rotate, resize, store, signs, ceiling lights); the catalog (buy with
coins, level locks, config prices); the Movie Room theater; the Dance Club; the beach; YARD GAMES (owned by the menu).
Dead / demo-only (don't port): legacy catalogs, model preview, colour choice, old action bar and meters, level-up
popup, test bar, size panel, house3d.js v3, SquishDaily.

## Stages (each ships and is tested)

0. Harness: the house page deterministic (virtual clock, split Math.random streams, seeded saves and profile, CSS /
   Web Animations paused, SMIL stripped for stills), scripted input shared by the page and C#, a trace hook, fixtures.
1. Save, catalog data, a static room from a save (no creatures): `HouseSave` (initH + migrations), the catalog and
   piece table exported to JSON, geometry, the room template; exported piece pictures. Verify: H JSON after load,
   room markup, pixels per fixture × room × day / night.
2. Framing, camera (0.85 indoors, 0.45 s ease), doors, HUD chrome, toasts.
   ✅ (2026-11-23, untested in Unity) `House/HouseChrome.cs` (camera, doors, drawer, toast logic: `house-test chrome`,
   19 checks), `House/View/HouseScreen.cs` (the screen: room, camera easing in the quad's texture coordinates, the night
   overlay drawn unzoomed as the page does, the drawer from `tools/unity/house/export-hud.mjs`, toasts, taps), the
   room drawn at camK 1 over the zoom's region (`house-test camera` + `tools/unity/house/camera-check.mjs`: the zoomed
   layers equal stage 1's picture to 0.00 % of pixels in living, kitchen, dance and backyard, day and night).
   Left for later stages: RENOVATE / CATALOG (6, 7), the house map (8), the selected friend walking to a door (3).
   The drawer's inset highlights aren't drawn (snap.js skips inset shadows).
3. Creatures placed and walking (logic exact; recorded clips as visuals): pick, homeFor, freeSpot, wander, goTo, the
   movement / turn tick, HouseWalk, z-order, particles. Verify: traces over scripted sessions.
4. Live rigs and actions: act, finishUse, needs, quick actions, seats / snuggles, speech. Needs the creature engine.
5. Item interactions and room effects: rnTap kinds, TV, toys, lights / night, party / disco, vacuum, fog, animated
   pieces (SMIL as flipbooks).
6. Edit mode: drag, wall snap, rotate, resize, store, signs, ceiling lights. Verify: H JSON after each step.
7. Catalog and economy: pages, detail, buy / place, level locks, config.
8. House map, and the walk home from the Unity menu.
9. Dance Club, Movie Room (movies as exported video + audio), TV sound.
10. Beach.
11. Yard games (with the menu).

About 75-100 helper-days. Live creatures: run the rig code (the creature engine) at 30 Hz round-robin within a
frame budget, hot functions ported to C#; a loop cache only if the A15 can't keep up.

## Phone performance

The web house was slow from per-frame SVG rig rebuilds, React re-rendering everything every second, data-URI SVG
furniture re-rasterized with SMIL / blurs / blend modes, CSS filters on every creature, DOM particles, 78 scripts
loading, a Firestore write every ~5 s. Unity: the room shell rendered once per room, each piece a cached quad, SMIL
pieces as cached flipbooks, pooled particle sprites, UI redrawn only on change, the rig scheduler, and debounced saves
(same format, fewer writes).
