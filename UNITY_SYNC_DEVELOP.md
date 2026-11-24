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
| ⬜ | **The game intro** (`webgame/app/intro.js`), after log in / the email check, on the menu's own house, once every launch: night, a box drops ("Tap the box!"), Mittens pops out, three squishes light three rooms, dawn, the squad peeks out, the SQUISH SQUAD logo, "TAP TO START". SKIP top right, Android back skips. Weather follows today's. The daily spin, streak and level-up wait for its end | missing: spin and streak show at once (`Menu/MenuScreen.cs` CheckDaily) |
| ⬜ | Music silent until the intro's third squish (and on log in / verify before it) | the theme plays at once (`App/AppFlow.cs` → `Music.Follow`) |
| ⬜ | Log in / register in the wood look: the menu's house softened behind, live Mittens + logo on top, one wood panel (Log in · Register gold pill switch, the fields side by side, gold button, Keep me signed in, OR, Google / Facebook / TikTok plaques); three size tiers by phone height (`src/screens/auth/kit.js`, `Socials.js`) | the old blue layout (`App/AuthView.cs`, `Ui/Screens/AuthArt.cs`) |
| ⬜ | Verify email in the same wood kit; development builds skip it (`SKIP_EMAIL_VERIFY`) | old blue look, no skip (`App/VerifyView.cs`) |
| ✅ | New accounts own Nimbo and Mittens | only `"0"` (`Backend/UserData.cs`) |
| ⬜ | Weather from Firestore `config/weather` (one option = always it; several = the month's rule; none = all three): the menu, the intro, the house, Squish Stack's forest | the month only (`Menu/MenuState.cs`) |

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
| 🔧 | **One result card for every game**, one column (max 440, title and picture on top): the title, **three live characters instead of stars** (grey, each earned one fills with colour from the feet up, jumps for joy with rays, then loops happy moves; a missed one sighs and stays grey; fallback: gold stars, Squishdoku its faces), coins counting, XP bar with LEVEL n! beside it, then MENU (Squishdoku: MAP) and REPLAY white, NEXT ▶ gold, 100×48 each | each game's own two-column card: stars, a line of numbers, "Under x for 3 stars", LEVEL n UNLOCKED, white / purple / **green** buttons — done but the live characters: the stars stand in, as in the app when its rigs fail |
| ✅ | One pause card: PAUSED (gold), RESUME gold, QUIT white, nothing else | three buttons (green / purple / white) and a body text, per game |
| ✅ | Time's up / fail: one column, MENU (MAP) white + RETRY gold, 150 wide | small white + big pink |
| ⬜ | Blitz cards say the game's unit (board / round / puzzle) | "board" everywhere |
| 🔧 | HOW TO PLAY: GOT IT! in gold; Sort's and Hop's shorter texts | green — Squishdoku's done; the other three come with their hubs' re-export (export-maps.mjs) |

## The games

| | develop | Unity before |
|---|---|---|
| 🔧 | **Squish Stack's map is a forest road** (`src/stack/ForestMap.js`, `road.js`, `forest-<season>-0..3.jpg`): the levels stand on the road like stepping stones, wooden signs per band, your creature walks to the next level | the shared map: nodes on a wave with three dots between them (**"the rocks are not connected"**) over the season's world picture — done but the walker (the selected creature walking the road: live rig) |
| ⬜ | Stack hub: GameHub with picture wood cards (REGULAR / BLITZ), HOW TO PLAY "?" | old heads, tagline, mode cards, progress bar |
| ⬜ | Stack: no clock, no UNDO; MOVES n / par in the middle; goal bottom left; RESTART and HINT bottom right | clock, UNDO, old HUD |
| ⬜ | Stack Blitz endless (ramp then 7-on-4 / 8-on-4), coins per puzzle, save by ad or gems | 10 puzzles on a 4:00 clock |
| ⬜ | Squish Sort: fridge only (no Toy Cupboard), the fridges redrawn realistic, kitchen room behind the map and the play, GameHub, live rigs in play | fridge + cupboard, old fridge art, stills |
| ⬜ | Sort Blitz endless: per-round clock (par × 1.33, −3 % a round to 75 %), pay per round | 10 rounds on 5:00 |
| ⬜ | Squishdoku: creatures react on the board (faces, pop up, happy wave along row/column/patch, sad shake and poof, everyone droops when lost, cheer up after a save); the chapter's room behind the map | the old drop and hop, no faces; the season's world |
| 🔧 | Squish Hop: a hub, BLITZ MODE (random boards growing, short clock), stars by take-backs, the ★ waits for every cushion, Crib rooms behind the map, live rigs, board 20 dp gutter (A15 fit) | no hub, no Blitz, stars by cushions left, cut-outs, `aw - 10` — the 20 dp gutter is done |

## Shop, chests, spin

| | develop | Unity before |
|---|---|---|
| ⬜ | Each chest holds only its own rarity; no Lucky meter; a group only sells the chests it can fill; Avo and Duchess Legendary; new Rainbow line | Lucky meter, odds, every size, old texts (the server already pays the new way) |
| ⬜ | Vault: the group's own backdrop, bigger chest, HP by rarity in five bars, the v6 reveal (three columns), **a copy that unlocks a creature: copies gather in a ring, BAM, the live creature** | old vault room with torches and banners, old reveal, no unlock |
| ⬜ | Vault loader without a progress bar (the coin runs to the X, the screen zooms) | `vault-fill` bar |
| ⬜ | Daily Spin remodel: the 150-coin slice is a Common MYSTERY BOX chest that opens into a smash; wood, gold and jewel wheel; prizes and lights turn with it; a flapper pointer | old wheel, upright prizes, coins 150 |

## The house

Exported from the Nov 16 page, not develop's. To bring over: yard toys bought, never placed (UNLOCKED, NEW badge on
YARD GAMES), the Yard Games page as a horizontal list of poster cards, room drawing as stills (no SMIL, stroke shading,
no creature shadow filter, disco floors as frames), the map's cream veil and picture zoom, the trip in (room first,
creatures one by one), the frame filling taller screens, weather.

## Bugs found while looking (not differences)

| | |
|---|---|
| ✅ | **Catalog BUY does nothing**: the house gets the profile's coins once when it opens; offline ("Dev: menu offline") that's 0, so every buy is refused with "Not enough coins" (`Menu/MenuScreen.cs` OpenHouse) |
| ✅ | **Coins won don't add up**: offline the games save nothing on purpose; signed in, check the menu's pill follows the profile after a game |

## How each screen is brought over

Re-run its exporter against develop (`node tools/unity/export-<screen>.mjs`; fix the exporter where develop's page
changed), update the Unity code that places the pieces, then run its test (`dotnet run -c Release --project
tools/unity/<screen>-test`), which draws Unity's picture and diffs it with the app's. This machine needs .NET 8
(`apt-get install dotnet-sdk-8.0`) and `npm ci`.
