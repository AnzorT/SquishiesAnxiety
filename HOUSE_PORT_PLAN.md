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
   ✅ (2026-11-23, untested in Unity) `House/HouseWalk.cs` (house-walk.js and the egg rolls; `house-test walk`: 3,690
   frames of 41 creatures equal to the page), `House/HouseCreatures.cs` (init, enterRoom's placing and carrying,
   wander / goTo / freeSpot / blocked / clampF, the walk tick, needs decay and lines, say, particles;
   `tools/unity/house/creature-trace.mjs` + `house-test creatures`: the page's runs replayed with its own random draws
   and rig fidgets, every creature every frame equal: lv12 living 900 frames, kitchen 1,800), `House/RoomLayers.cs` (the
   room cut into a base and one layer per piece / front / toy by z-index so creatures sort between them; `house-test
   layers` + `layers-check.mjs`: stacked, equal to stage 1's picture in every lv12 room), `House/View/HouseSquadView.cs`
   (the creatures drawn: live rig with the walk's ext channels and fidgets, else the recording, else the cut-out; shadows,
   selection ring, name tag, speech bubble, particles; taps). Not checked by a trace yet: taps (select, floor, a door with
   a friend), the dance room's round floor (no creature was in it).
4. Live rigs and actions: act, finishUse, needs, quick actions, seats / snuggles, speech. Needs the creature engine.
   ✅ (2026-11-23, untested in Unity) `House/HouseActions.cs` (ACT, act's seat / use / snuggle / dance / watch / dine
   branches, Seated / Used (the arrive callbacks), finishUse, bowlDone, leave with the rig's out / wake moves and the kept
   pose, onRig, the lights / party toggles, qaGo / firstAct, needs recovery, mode particles); the rig: its state events
   (`__live.events`), the house moves' metadata (walk.json `hs`), ext channels and fidgets; `House/View/HouseWheel.cs`
   (the quick-action wheel, pieces from export-hud.mjs). `creature-trace.mjs <fx> <room> <frames> "<script>"` +
   `house-test acts`: kitchen (snack, cook, dance, 1,500 frames) and bedroom (nap, floor tap: wake and climb out, nap
   again) replayed exactly: every creature's state every frame and every ctrl.play. Not yet: setVar's pictures (5),
   the swing / ride seat motion (5: item angles), the movie cues (9), the beach acts (10), the old action bar's
   meters (dead in the current design).
5. Item interactions and room effects: rnTap kinds, TV, toys, lights / night, party / disco, vacuum, fog, animated
   pieces (SMIL as flipbooks).
   Found (2026-11-23): a piece's picture depends on its runtime state (on / open, TV channel, toaster, dishwasher,
   growth stage, paint mode, a game being played) and, from stage 6, on any rotation, size, colour and sign text the
   player picks. Stage 1 exported only the variants the fixtures' rooms show (house-pieces.json), so neither stage
   can rely on exported pictures alone. Plan: draw pieces at runtime with the page's own drawing code (RenoDraw
   reno-*.js, House3D house4*.js: pure functions returning SVG) in the JS engine that already runs the creatures
   (PuerTS, LiveRig's bundle), the exported variants as the fallback when the engine is off. The rnTap logic itself
   (~33 KB with its helpers) is then a C# port like stage 4.
   ✅ (2026-11-23, untested in Unity) The drawings: `tools/unity/house/draw-host.js` (the page's scripts from house4.js
   on and its own rnReg / rnDraw / rnOpt / rnLayer / tightBB, copied in by `tools/unity/rig/bundle.mjs`; Resources/Rig
   now 2.3 MB gzip), `House/HouseDraw.cs` (the model's fallback when the export lacks a drawing; pictures named as the
   export names them). `tools/unity/house/draw-check.mjs`: all 53 exported variants and 54 renders made again equal;
   through C# and PuerTS (QuickJS) in `tools/unity/rig/live-test`. The pieces: `House/HousePieces.cs` (itemDown, rnTap's
   kinds, piece states and rStOf, rnUse / rnPlayer / rnStop, toaster, dishwasher, grow, paint, TV channels and
   speakers, the house4 TV, jams and fog as states, rnTick, the yard ball's kicks and rallies); the room's pictures
   follow the states (RoomModel.StateOf / VarOf); taps on pieces and toys (their boxes, topmost by z); the rolling toy's
   layer moves. `creature-trace.mjs decorated living ... "tap:i27 ... tap:i23 ..."` + `house-test acts`: TV channels
   with speakers, tap-to-sit and the sit / lounge cycle replayed exactly (states, plays, toasts). Not yet: the swing /
   ride seat sway and other animated house4 parts (clock, fish, pulse), SMIL pieces as flipbooks, the robot vacuum's run
   (VacBot), the disco lights, a piece's own redraw instead of the whole room's, the toy's spin.
6. Edit mode: drag, wall snap, rotate, resize, store, signs, ceiling lights. Verify: H JSON after each step.
   **Done (logic, UI) except signs.** `House/HouseEdit.cs`: itemDown in Renovate, dragMove / dragFloor / wallPose /
   dragWall / dragSmall (onto hosts' tops) / dragEnd, szFit / minE / szWall, rotSet (the 0..360 slider), editRot,
   editSize (one size, width x height), editStore, freeCount, placeNew, edHold / edBack (friends held off a piece being
   edited and put back), the ceiling light (lightDown / move / up, lightSize, lightStore, lightBack, back to the middle),
   the toolbox's tray and tabs (trayVals, rnSlot, useRSurf). Runtime drawing grew the room's shell (House3D.shell: a moved
   or resized light, new surfaces) and the renovated surfaces' textures (`__house.shell`, `__house.tex`; draw-check:
   all 17 shells and 10 textures equal). `tools/unity/house/export-edit.mjs` -> `Resources/House/edit.json` + `edit/`:
   RMAP, short names, surface names, SPEC lights, every row's tab, and the edit UI's fixed pieces cut from the page
   (snap.js now draws inset box shadows). `House/View/HouseEditView.cs`: Done, House shop (until stage 7: a toast), the
   toolbox (sliding, its tab, label card, tray cards drawn from the page's styles, tabs), the toolbar (its box, labels,
   slider, the page's buttons), the light's dashed handle; HouseScreen's input presses, holds and releases (drags);
   the room's dashed footprints and wall boxes (RoomModel EditOn / ESel, wallSel). Verified with
   `creature-trace.mjs decorated living 340 "...edit, down, move, up, size, rot, turn, store, place, ldown, lmove,
   lsize, lstore, lback, rsurf, done"` and `decorated movie` (side and back wall, width x height) + `house-test acts`
   (the .NET check now draws through `tools/unity/house/draw-server.mjs`, the same host PuerTS runs): the room's items,
   selection, lx / lz / surf / rtex / lOff / uid, every creature and play equal on every frame. Not yet: writing on
   signs (Aa: the sign editor), the tray's mouse-wheel scroll, the inset light on the toolbar's box (a flat highlight).
7. Catalog and economy: pages, detail, buy / place, level locks, config.
   **Done (logic, UI).** `House/HouseShop.cs`: openCat, rcList, rcVals (12 cards a spread, categories with the yard's
   names, paging on into the next category, the level line), rdVals, buyR (the wallet: Coins / Spend, freeShop),
   placeR (to its room, then placeNew in Renovate or useRSurf). `tools/unity/house/export-catalog.mjs` ->
   `Resources/House/shop.json` + `shop/`: every row's tag line, what it does, secret, short note, surface or piece, and
   the Catalog's fixed pieces cut from the page (snap.js: radial-gradient stops with no position fixed).
   `House/View/HouseShopView.cs`: the book, room tab and header, House level and coins, the cards (pictures through
   the draw host, balanced two-line names, BUY / OWNED / IN USE / LV n), categories, paging, the detail card; opened
   from the drawer's CATALOG and Renovate's House shop. `HouseScreen.Coins` / `Spend` take the app's wallet (stage 8
   wires them). Verified: `creature-trace.mjs lv12 living 60 "shop, cat, next, prev, card, close, det, buy, placer,
   closeshop ..."` + `house-test acts`: the Catalog's state, coins, owned / rOwn, every card, the categories, the
   paging and the detail equal on every frame the page had drawn its cards. Not yet: the dev level popup (House level).
8. House map, and the walk home from the Unity menu.
   **Done except the walk.** MY HOUSE (the menu's `home` tap, `Menu/MenuScreen.cs` OpenHouse): the player's save
   (`users/{uid}/crib/house6` as the app's WebView house; offline on the device), level, creatures (keys -> the house
   roster), coins (the Catalog's spends written as the bridge sends them: gameCoins with the difference); saved when it
   changes; Android's back closes the detail, the Catalog, Renovate, the map, then the house. The map
   (`House/HouseMap.cs`, `House/View/HouseMapView.cs`): the page's own `mapVals` / `natMap` / `lockVals` run by the
   draw host (`__house.map`; `tools/unity/rig/bundle.mjs` now copies whole top-level functions by matching brackets),
   the page's map `<svg>` template (`tools/unity/house/export-map.mjs` -> `map-template.html`) filled in C#, the trees
   and bushes into the groups the page fills by ref; openMap / mapPick (the 2.6x zoom into the room, the cream fade) /
   pickRoom (the selected friend comes along) / closeMap; the room labels drawn from the page's styles; the room's
   House map button, Back and the weather chips cut from the page. `export-map.mjs` checks the host's values against
   the page's (all five fixtures equal) and saves the page's drawn map for `house-test map` (the C# markup against
   it). Not yet: the walk to the door and the "Heading home" loading scene (the house opens at once), the creatures'
   faces in the map's labels (cream circles), the map's SMIL (clouds, waves, rain and snow stand still).
9. Dance Club, Movie Room (movies as exported video + audio), TV sound.
   **Done (logic, video, sound) except the screen looks.** `tools/unity/house/export-movies.mjs`: the five Squad
   Movies drawn frame by frame by the page's own movie code and screenshotted, their scores (SquadMovies.record) played
   through movie-night.js's own tone / noise / bus code into an OfflineAudioContext, muxed by ffmpeg ->
   `StreamingAssets/Movies/<id>.mp4` (480 x 270, H.264 + AAC, 21 MB for all 15 minutes) and `movies.json` (cues,
   the screen's light 10 a second); the speakers' groove and the TV's three channels rendered offline from the page's
   own code (tv-sound.js's scheduler stepped by hand) -> `Resources/House/audio/*.ogg`, one seamless period each; the
   Dance Club's track (`club.mp3`). `House/HouseMovie.cs`: rnTheater, the show (play the screen tier's movie or the
   last picked, resume where it was left, dim, pause / resume on the screen or player, the end), cues -> mvCue, mvStep's
   rig values. `House/View/HouseMovieView.cs`: the movie on the screen's quad (VideoPlayer, cover fit, fade), the dim
   and the screen's light, the groove and TV loops. `House/View/HouseClubView.cs`: ClubFog ported (puffs by tier and
   style, bubbles, confetti, the bank and the dim, the linger), the party's disco spots, the club track (musicSync).
   Verified: `creature-trace.mjs decorated movie 260 "buy, placer (player, speakers), done, tap screen / player"` +
   `house-test acts`: the theater (synced, tier) and the show (movie, time, pause) equal on every frame. Not yet: the
   screens' film looks by tier (grain, fuzz, widescreen), the projector's beam, the speakers' bounce and notes, the
   movie picker and full-screen view, the 10 s app ad, the holo pop-outs and confetti cues.
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
