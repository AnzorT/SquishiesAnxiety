# Unity ← React Native (develop): what's out of sync

Started 2026-11-24. The Unity port (`unity/`) was forked from the React Native app at `2ab1004` (Nov 16, `main`) and
never got the app's changes made on `develop` after it (8f26ec5 Nov 19, 0f8a9d7 / e036d3e Nov 20, 1000d5a Nov 21,
c3b66dd Nov 21, b78a979 Nov 22). The art is cut out of the running app by `tools/unity/export-*.mjs`, so most of the
pictures were also the Nov 16 app's. Goal: Unity matches the app on `develop` exactly.

Status: ✅ done and checked against the app's pixels · 🔧 partly done (what's left is said) · ⬜ to do.

Done so far, on `ccr-b6a1e1d9-oxmmsl` (from develop): the Game Park posters; the cards (one result card in one column
with the app's buttons, one pause card, the fail cards; the live characters are left: stars stand in, as in the app
when its rigs can't draw); Squish Stack's forest road (the walking creature is left); Characters' loader without its
progress bar, the spotlight centred, the pages whole from their first frame; the house's vignette fading on the way
to the park; the launch colour; the coins and the Catalog's BUY. Known small leftovers: the Characters row scrolled
far sits 36 pu off; the Level Pass's track and panel don't fade in over its first 140 ms.

## Start-up

| | What the app does on develop | Unity before |
|---|---|---|
| ✅ | No splash art: a flat `#2a1608` launch colour until sign-in is known (and, signed in, the profile and the creature catalog; 10 s at most) | the old blue splash with a loading bar and "WAKING UP THE SQUAD… N%" (`App/SplashView.cs`, `Ui/Screens/SplashArt.cs`) |
| 🔧 | **The game intro** (`webgame/app/intro.js`), after log in / the email check, on the menu's own house, once every launch: night, a box drops ("Tap the box!"), Mittens pops out, three squishes light three rooms, dawn, the squad peeks out, the SQUISH SQUAD logo, "TAP TO START". SKIP top right, Android back skips. Weather follows today's. The daily spin, streak and level-up wait for its end | missing: spin and streak show at once (`Menu/MenuScreen.cs` CheckDaily) — done (`Menu/MenuView.Intro.cs`, `Menu/IntroArt.cs`, `tools/unity/export-intro.mjs`): the lit / dawn states, captions, Skip, TAP TO START, logo letters and peeking squad are the app's pictures; the box, ring, sparks, bursts, puffs, camera and Mittens' moves (recorded: surprised, look, dance; night tint) are drawn in Unity. The box checked against the app (`auth-test intro`: 0.08 % of the frame). Left: a run in the Unity editor to check timing and placement on device; the rain / snow over the intro |
| ✅ | Music silent until the intro's third squish (and on log in / verify before it) | the theme plays at once (`App/AppFlow.cs` → `Music.Follow`) — `Music.Hold` / `Release` |
| ✅ | Log in / register in the wood look: the menu's house softened behind, live Mittens + logo on top, one wood panel (Log in · Register gold pill switch, the fields side by side, gold button, Keep me signed in, OR, Google / Facebook / TikTok plaques); three size tiers by phone height (`src/screens/auth/kit.js`, `Socials.js`) | the old blue layout (`App/AuthView.cs`, `Ui/Screens/AuthArt.cs`) |
| ✅ | Verify email in the same wood kit; development builds skip it (`SKIP_EMAIL_VERIFY`) | old blue look, no skip (`App/VerifyView.cs`) |
| ✅ | New accounts own Nimbo and Mittens | only `"0"` (`Backend/UserData.cs`) |
| ✅ | Weather from Firestore `config/weather` (one option = always it; several = the month's rule; none = all three): the menu, the intro, the house, Squish Stack's forest | the month only (`Menu/MenuState.cs`) — `Menu/Weather.cs` (src/weather.js), read once when the menu opens signed in (`App/AppFlow.cs`), `MenuState.Season` uses it |

## Menu, Game Park, Characters

| | develop | Unity before |
|---|---|---|
| ✅ | Game Park: the four mini-games are still posters (`app/art/park/<id>.jpg`, the name in the picture, no title row, no video); rays 492 px | clips (`StreamingAssets/Park/*.mp4`), rays 560 px |
| ✅ | Menu → Game Park: the house's vignette fades out (0.45 s, a second vignette-free picture cross-faded in) so the house meets the park's art with no seam | the vignette is baked into the house JPEG and never fades: the darker house meets the brighter park (**the "cut" between two pictures**) |
| ✅ | Characters' loading screen "Gathering your squad": **no progress bar** (the band, 46 px, holds only the tip), rays 714 px | bar, knob and 0-100 % |
| ✅ | Characters: the spotlight (rays, platform, creature, CHOOSE) at the page's middle on every screen | fixed at the A15's x |
| ⬜ | Squish Time's loading beat: wood, the creature, "Getting ready" with hopping dots, then "I AM READY!" | missing (straight into Squish Time) |
| ⬜ | Squish Time sky as native pieces (puffs without the solid core) | the old `hud/sky` |
| ✅ | Settings: no "Replay tutorial" | still there |
| ⬜ | Screen placeholders in the wood look, sideways | translucent white, portrait shapes |

## The mini-games' cards (all four games, Regular and Blitz)

| | develop (`src/squishdoku/Overlays.js`, `Trio.js`) | Unity before |
|---|---|---|
| 🔧 | **One result card for every game**, one column (max 440, title and picture on top): the title, **three live characters instead of stars** (grey, each earned one fills with colour from the feet up, jumps for joy with rays, then loops happy moves; a missed one sighs and stays grey; fallback: gold stars, Squishdoku its faces), coins counting, XP bar with LEVEL n! beside it, then MENU (Squishdoku: MAP) and REPLAY white, NEXT ▶ gold, 100×48 each | each game's own two-column card: stars, a line of numbers, "Under x for 3 stars", LEVEL n UNLOCKED, white / purple / **green** buttons — done, the live characters too (`Ui/Cards/TrioItem.cs`: result.html's moves, the grey shapes while they load, the coins waiting for them; `Creatures/ResultRig.cs` plays them live with the JS engine, or from recordings: `record.mjs <key> --clip result`, Mittens only so far, ~2.4 MB a creature; a card whose three can't all be drawn shows the stars, the app's fallback). Checked: the four games' `cards` tests at 300 / 640 ms (the stills in place: 0.4-0.8 %), the stars with `?keys=none`. Squishdoku's PERFECT stamp across the live characters' feet too (TrioItem: Overlays.js Stamp, trioStamp; not pixel-checked: it comes after the characters, which the reference rasteriser can't draw) |
| ✅ | One pause card: PAUSED (gold), RESUME gold, QUIT white, nothing else | three buttons (green / purple / white) and a body text, per game |
| ✅ | Time's up / fail: one column, MENU (MAP) white + RETRY gold, 150 wide | small white + big pink |
| 🔧 | Blitz cards say the game's unit (board / round / puzzle) | "board" everywhere — Squish Stack's say puzzle, Sort's round (SdBlitzCards Unit) |
| ✅ | HOW TO PLAY: GOT IT! in gold; Sort's and Hop's shorter texts | green — done: all four re-exported (`export-maps.mjs rules`, which now runs by parts and keeps what develop's pages no longer have) |

## The games

| | develop | Unity before |
|---|---|---|
| ✅ | **Squish Stack's map is a forest road** (`src/stack/ForestMap.js`, `road.js`, `forest-<season>-0..3.jpg`): the levels stand on the road like stepping stones, wooden signs per band, your creature walks to the next level | the shared map: nodes on a wave with three dots between them (**"the rocks are not connected"**) over the season's world picture — done, the walker too (`LevelMap` DrawWalker: the selected creature stands on the next level and walks the road there after a win, turned side-on with its own gait when live (`Creatures/ResultRig.cs` ForWalk, walk.html's moves), else its idle recording slides along, else its cut-out stands; `maps-test stack-map` 1.5-2.4 % settled, the scenarios tap develop's new hub (`tapUnity` while Unity's hub is the old one)) |
| ✅ | Stack hub: GameHub with picture wood cards (REGULAR / BLITZ), HOW TO PLAY "?" | old heads, tagline, mode cards, progress bar — done: `Games/Shared/ModeHub` (Hub.js GameHub, Squishdoku's plaques and HOW TO PLAY with the game's pictures, `Resources/Stack/mode-*.png`; royal Lettering moved to `Ui/Cards/RoyalLettering`), the rules card re-exported (`export-maps.mjs stack rules`: GOT IT! gold, develop's texts). `maps-test` stack-hub 1.1-2.0 %, stack-first / stack-rules 1.9-2.8 % (the card's text edges a fraction of a pixel off), stack-stars 2.0 % (was 58 % with the old hub); the idle loops (KeyLoop) loop on the web now too, as develop's idleLoop.js |
| 🔧 | Stack: no clock, no UNDO; MOVES n / par in the middle; goal bottom left; RESTART and HINT bottom right | clock, UNDO, old HUD — done: two 200 dp side columns (the back orb, the goal at the bottom; RESTART and HINT at the bottom right), the counter over the cushions (`StackArt.CounterSvg`, n pink past par), no dashed rug; re-exported (`export-stack.mjs`: develop's forest map, the level's own orb). `stack-test` 0.90 % outside the board. Left: develop's squishy moves of 11-17 (SQUISH_STACK.md "Moves": squash on landing, stretch when lifted, the dangle, pancake, nope, the win's wave, the dizzy stars, TOO BIG!'s red flash) — Unity still moves them the fork's way |
| ✅ | Stack Blitz endless (ramp then 7-on-4 / 8-on-4), coins per puzzle, save by ad or gems | 10 puzzles on a 4:00 clock — done: `StackBlitz.cs` as Game.js `blitz` (3, 2, 1, GO!, puzzle after puzzle, CLEARED / BEST / 1 MISTAKE = GAME OVER in the counter, the mistake: everyone droops and sways, the save card at 1.5 s: SAVE IT by ad / SAVE FOR gems (squad.blitzSave, twice the last) / END RUN, GAME OVER with what it paid; leaving or PLAY AGAIN pays out first), Squishdoku's save and GAME OVER cards with unit "puzzle"; rules `games/stack` 47541 cases match. `stack-test blitz` (blitz.mjs: develop's run, a save, END RUN, PLAY AGAIN, a pause) 0.7-2.5 %, mean 1.35 %, its flow checks pass |
| 🔧 | Squish Sort: fridge only (no Toy Cupboard), the fridges redrawn realistic, kitchen room behind the map and the play, GameHub, live rigs in play | fridge + cupboard, old fridge art, stills — done: the hub (`SortHub` → `Games/Shared/ModeHub`, `Resources/Sort/mode-*.png`; maps-test sort-hub 1.9 %), fridge only (rules: THEME_KEYS, modelOf; the map is the fridge's), the kitchen behind the map (`LevelMap` DrawRooms: royal/WorldBg.js RoomBackdrop with Room.js `full`, shared with Hop and Squishdoku; the row on the floor, ROW_ON_FLOOR; the title on its plaque) — sort-map 2.3-3.3 % settled. Left: the realistic fridges (develop's models.js / Container.js: the map's fridge pictures and the play's fridge), the kitchen behind the play, develop's play HUD (the Crib's top bar, RoomTitle, the glass), live rigs; Sort's level / blitz pixel tests (`sort-test capture.mjs` / `blitz.mjs`) still follow the old page |
| 🔧 | Sort Blitz endless: per-round clock (par × 1.33, −3 % a round to 75 %), pay per round | 10 rounds on 5:00 — rules done (`Levels.cs` BlitzSpec / BlitzCoins / BlitzPrize / AfterBlitz(cleared), record top / runs; `games/sort` all 33068 cases match the JS, its fixtures follow develop); the run (`SortBlitz.cs`): round after round on its own clock, a mistake or the clock: the save card (SAVE IT / SAVE FOR gems / END RUN, Squishdoku's cards with unit "round"), saved after the clock it starts again, GAME OVER 1.1 s after END RUN, pays out on leaving / PLAY AGAIN. Left: its 3, 2, 1, GO!, develop's HUD (CLEARED / BEST on the glass), the droop at GAME OVER |
| ✅ | Squishdoku: creatures react on the board (faces, pop up, happy wave along row/column/patch, sad shake and poof, everyone droops when lost, cheer up after a save); the chapter's room behind the map | the old drop and hop, no faces; the season's world — the chapter's room behind the map is done (`SdScreen`: Room.js `full` tiles along the page, scrolled with the map; `SdMap` the row on the floor, ROW_ON_FLOOR): `squishdoku-test screen` map 2.7-3.2 % settled. The PERFECT stamp over the live characters' feet is done (TrioItem). The reactions too: `SdBoard` is RoomBoard.js for Regular and Blitz alike (SdLevel's copy of the board gone): the three faces (bodies.js → `Resources/Squishdoku/bodies/<key>-idle/happy/sad.png`, `-red` the tint's shape, `bodies.json`; `export-squishdoku.mjs --bodies-only`), hop/Pieces.js's juicy moves it uses (the crouching hop, the landing wobble, the head's "no", the droop; rotateX / rotateY drawn flat), pop, the row / column / patch wave (fx.js Wave), the wrong one's red flash and fall, HopAll from the last one (its beats for the hop sounds), SadAll (time up, out of hearts, a Blitz mistake or clock: the card once they've drooped), CheerUp after a save; board.js GUTTER 20 (it was 5: the level's board was too big); the map's room held under a level that's starting (WorldBg useRoomUnder). `squishdoku-test play` (capture.mjs now runs the clock out and RETRYs: develop's pause card has no RESTART) 1.5-3.1 % (the time-up shot 14 %: the board's shake caught ~40 ms apart), solve 2.7-3.0 % until the result card (its live characters aren't drawn by the reference rasteriser), hearts 1.2-3.7 %; `blitz` mean 1.78 %, worst 4.35 %; `screen` level 6.3 % (the board's cascade a frame or two apart), 12.3 % as it slides in (the placeholders: develop's wood bones, the ⬜ row above); flow and blitzflow all ok |
| 🔧 | Squish Hop: a hub, BLITZ MODE (random boards growing, short clock), stars by take-backs, the ★ waits for every cushion, Crib rooms behind the map, live rigs, board 20 dp gutter (A15 fit) | no hub, no Blitz, stars by cushions left, cut-outs, `aw - 10` — the 20 dp gutter is done — the rules are develop's: the ★ shut until every other cushion is cleared (Engine BlockOf / search), stars by take-backs (RESTART, RETRY; HopLevel counts them), record blitz top / runs, `Blitz.cs` (blitz.js: the boards from a seed, their clocks and coins; blitzPrize, afterBlitz); `games/hop` all 289,666 cases pass (152 Blitz boards the same as the JS's); the hub (`HopDef.NewHub` → `Games/Shared/ModeHub`, `Resources/Hop/mode-*.png`; maps-test hop-hub 0.9-1.8 %, hop-rules 3.3 %), the Crib rooms behind the map (LevelMap DrawRooms, the row on the floor, the title on its plaque, no "?" orb; hop-map 3.5-3.8 % settled). Left: the BLITZ MODE screen (the hub's BLITZ shows "isn't in the Unity version yet"; its rules are ported), live rigs |

## Shop, chests, spin

| | develop | Unity before |
|---|---|---|
| ✅ | Each chest holds only its own rarity; no Lucky meter; a group only sells the chests it can fill; Avo and Duchess Legendary; new Rainbow line | Lucky meter, odds, every size, old texts (the server already pays the new way) — done (`Screens/Shop`, `export-shop.mjs`); the Shop remembers its page; no page dots |
| 🔧 | Vault: the group's own backdrop, bigger chest, HP by rarity in five bars, the v6 reveal (three columns), **a copy that unlocks a creature: copies gather in a ring, BAM, the live creature** | old vault room with torches and banners, old reveal, no unlock — done (`Screens/Chests`, `export-chest.mjs`; `shop-test smash*` mostly 1–4 %) but: the creature after BAM is its still (the live rig: `ChestSmashView.HeroRig`); the upgrade's glow beams are drawn with normal blending, not additive (up to 17 % in `smash-up`); the page's hit and unlock sounds |
| ✅ | Vault loader without a progress bar (the coin runs to the X, the screen zooms) | `vault-fill` bar — `shop-test vault` 1.8–2.3 % |
| ✅ | Daily Spin remodel: the 150-coin slice is a Common MYSTERY BOX chest that opens into a smash; wood, gold and jewel wheel; prizes and lights turn with it; a flapper pointer | old wheel, upright prizes, coins 150 — `Screens/Spin`, `screens-test spin` 1.1–2.0 %, `spin-chest` 1.3 % |

## The house

The house is the design's Squad House page as `webgame/build.mjs` builds it with `webgame/patches.mjs` and the menu's
`webgame/app/{menu,games,perf,bridge}.js`; its exporters (`tools/unity/house/`) now cut develop's build (the room
template came from the unpatched prototype). Checked with `house-test save` (5 / 5 equal), `chrome` (all ok), `markup`
(54 / 58 rooms equal: the beach's live scene and the dance floor's CSS are drawn another way) and `pixels` (the room
drawn by the reference rasteriser against develop's page; visibly different pixels, day / night):
lv12 living 0.35 / 0.03 %, lv12 backyard 0.86 / 0.04 % (unchanged), lv12 dance 1.17 → 0.37 / 0.06 %, decorated
living 1.99 / 0.46 → 2.01 / 0.48 % (the blur traded for strokes), decorated dance (renovated brick wall and light-up floor) 24.3 → 3.5 / 0.4 %. What's
left there is anti-aliasing along the floor tiles and furniture edges, and the brick wall's neon strip glow.

| | develop | Unity before |
|---|---|---|
| ✅ | Rooms drawn as develop's page: the soft edge shading as six see-through strokes (no blur), the Dance Room's trims as soft strokes, no drop-shadow / saturate filter on the creatures; pieces, the Catalog's cards and the glass-dome sky as stills (SMIL out) | the Nov 13 template (blurred edge, filtered trims) — `export-house.mjs` reads the built page (`room-template.html`) |
| ✅ | The Dance Room's renovated floor: a CSS 3D plane (rotateX 60°, perspective 450) tiled with the floor's tile, its dark shading, clipped to the round room | **not drawn at all** (Notes: "CSS-3D floor not drawn") — `House/HouseFlat.cs` draws the plane into a picture (each pixel traced back onto the plane, mip-mapped tile), `RoomCompose` places it, clips `clip-path: path()` boxes, draws vertical linear-gradients; the renovated round brick wall (16 `<use>` slices of one picture) drew flat bricks, fixed |
| ⬜ | Light-up dance floors (6 of them) animate as 4 baked moments of their tile switched step-end (`menu.js` SquishDisco; off in lite mode, paused under the Catalog / map) | still (the moment-0 tile): needs the tile's 4 moments exported and the floor layer split from the room's picture to switch them |
| ✅ | Weather from `config/weather` for the map, the glass dome and the beach (patches.mjs seasonNow asks SquishWeatherNow) | the month (and the dome's season never set: always rainy) — `Menu/Weather.cs` via `HouseMap.WeatherNow`; all six glass skies exported |
| ✅ | Yard games' toys are bought once, never placed: any toy of a game unlocks it (the others aren't sold after), not in Renovate's tray, one standing in the yard is taken out on load; the Catalog's card says UNLOCKED (no price, no x1), its detail what buying does / "Unlocked! Play … in YARD GAMES", no Place it; buying toasts "… unlocked!" and puts a NEW badge on YARD GAMES until the Yard Games are opened | placed like furniture — `House/HouseYard.cs` (games.js yardGameOf / yardLocked / yardStrip; the toy ids and names match the page's for every catalog row), `HouseShop`, `HouseEdit` tray, `HouseSave` initH |
| ✅ | YARD GAMES: the menu's gold tab (gamepad icon) top right of the backyard, its pulsing NEW / "n NEW" badge | a pink "Yard Games" pill top centre — cut from the menu page by `export-hud.mjs` (`hud/yard*.xml`) |
| ✅ | The menu's wood back orb over the house (bottom left; hidden on the map and over the Catalog) | none (Android back only) — `hud/back.xml` |
| ✅ | The frame fills any screen (menu.js houseBox: scale min(w/852, h/393)); the room, Catalog and map in its middle, the HUD (map button, drawer, toast, YARD GAMES, map's Back / weather / hint / level chip) on its edges; the room picture, night, Catalog dim and map sea fill it; the map's sea its sea0 → sea1 gradient | scaled to the width (cut off or a strip on other shapes), flat sea — `HouseFrame.MX / MY`, `HouseScreen`, `HouseRoomView`, `HouseMapView`, `HouseShopView`. Left: Renovate's toolbar and toolbox stay on the 852 box (the page stretches the toolbar to the frame) |
| ✅ | The trip in: the bare room first, the furniture layer fades in 0.5 s later (0.35 s), the creatures' rigs arrive one by one (0.42 s, then every 0.22 s) | all at once — `HouseScreen.Fill`, `HouseRoomView.ItemsOpacity`, `HouseSquadView.Fade / Mounted`. The walk to the door, "Heading home" and the camera flight in (the menu's) aren't in Unity: the house opens at once |
| ✅ | A room picked on the map comes up under the cream veil (0.99, then 0.28 s ease-out); the map zooms 2.6x into the room as a picture; rooms don't light up under a finger | no veil; glow on pick — `HouseScreen.Veil`, `HouseMap.HoverNone` |
| ✅ | The house stands still (creatures, rigs, timers) while the Catalog or the map covers it | kept running — `HouseCreatures.Freeze` |
| ⬜ | **The Yard Games page**: the menu's Mini Games page in yard mode, a horizontal list (dragged sideways) of wide poster cards (the game's intro poster with your character, name, ★ best / New! / Locked, its toy, PLAY or "Buy <toy> in the Backyard catalog (n coins)" with a padlock), no coins pill; a game plays landscape across the page with its own top bar and the app-look intro / results cards | the design's portrait phone-frame hub with seven two-column cards, all games open (`Games/Yard/View/YardScreen.cs`): needs its own pass (export the menu's yard page and posters, the games' landscape layout) |

## Bugs found while looking (not differences)

| | |
|---|---|
| ✅ | **Catalog BUY does nothing**: the house gets the profile's coins once when it opens; offline ("Dev: menu offline") that's 0, so every buy is refused with "Not enough coins" (`Menu/MenuScreen.cs` OpenHouse) |
| ✅ | **Coins won don't add up**: offline the games save nothing on purpose; signed in, check the menu's pill follows the profile after a game |
| ❓ | **The app: Android back over the house's Catalog leaves the house** (`webgame/app/bridge.js` clicks `.mm-hback`, which is only hidden there since 2026-11-20, not gone). Unity closes the detail, then the Catalog, then Renovate first; to decide which is meant |

## How each screen is brought over

Re-run its exporter against develop (`node tools/unity/export-<screen>.mjs`; fix the exporter where develop's page
changed), update the Unity code that places the pieces, then run its test (`dotnet run -c Release --project
tools/unity/<screen>-test`), which draws Unity's picture and diffs it with the app's. This machine needs .NET 8
(`apt-get install dotnet-sdk-8.0`) and `npm ci`.
