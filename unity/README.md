# Squish Squad in Unity

The Unity version of the app, built screen by screen next to the current React Native app, which keeps working until
Unity has caught up. Same Firebase backend, same look: the pictures come out of the current app's own code, so on the
reference phone (Galaxy A15, 2340 x 1080) Unity draws the same pixels.

**Ported so far** (see `../UNITY_MIGRATION_PLAN.md` for the details and the checks):
- start-up: splash, log in / register, the email check; the menu with the player's coins, gems and level
- the Main Menu (house picture for every level and season, weather, the HUD, flourishes, presses), PLAY's walk to the
  Game Park and its games carousel
- all five games from their cards: Squish Time; Squishdoku, Sort, Stack and Hop with hubs, level maps, levels, cards
  and Blitz
- CHARACTERS, the Level Pass (crest), Achievements (trophy), Settings with Stats (gear), the daily spin, the streak
  and the daily challenges (once a day, as the app)
- in progress: the Shop with chest opening and the Level Road, saving the games' progress to the account, the house
  (`../HOUSE_PORT_PLAN.md`). The SHOP tab and the house's tab still say "not in the Unity version yet".

## The tools, one per screen

Each screen has an exporter (cuts what's fixed out of the running app: `npx expo start --web --port 8081` for the
React Native screens; the webgame build for the menu's) and a test (drives the app on a virtual clock, plays the same
input on the Unity code, draws it with the reference rasteriser and diffs the pixels):

| Screen | Export | Test (`dotnet run -c Release --project tools/unity/<test> -- ...`) |
|---|---|---|
| Menu, park, pages | `export-menu.mjs`, `export-park.mjs`, `export-pages.mjs` | `park-test`, `pages-test` |
| Start-up screens | (drawn) | `auth-test` (+ `-- emu` against the Firebase emulators) |
| Games | `export-<game>.mjs` | `stack-test`, `sort-test`, `hop-test`, `squishdoku-test`, `maps-test`, `squish-test` |
| Achievements, settings, spin, streak, daily | `export-screens.mjs` | `screens-test` (+ `-- emu`) |
| Game rules | | `games/<game>` (vs the JS on the same inputs) |
| Fonts, text | `ui/fonts.py` | `ui/TextTest` |
| Animations (RN's Animated) | | `anim` |
| Layout (Yoga) | | `yoga/tests` |
| Firebase client | | `backend` (start `backend/start-emulators.sh` first; never the live project) |

## Open it

1. Unity Hub → **Add project from disk** → pick this `unity` folder. Editor version: **6000.3.0f1** (in
   `ProjectSettings/ProjectVersion.txt`). Install Android Build Support with it to build for the phone.
2. The first open writes the project settings (`Assets/Editor/ProjectSetup.cs`: Gamma colour, landscape, IL2CPP ARM64,
   app id `com.plushcrush.unity`, the Input Manager) and an empty `Assets/Scenes/Main.unity`. **Restart the editor once**
   so the input setting takes effect, then commit the new `ProjectSettings/` and `.meta` files.
3. Press Play in any scene: `Assets/Scripts/App/Boot.cs` starts the app's flow (`App/AppFlow.cs`): the splash, then log
   in / register (the live Firebase project, as the app), the email check for a new account, then the menu with your
   coins, gems and level. "Dev: menu offline" (top middle, editor and development builds) skips to the menu with the
   exported numbers. Set the Game view to 2340 x 1080 to see it at the reference size.
4. On the phone: **Squish Squad → Build Android APK** (or File → Build Settings). It has its own app id, so it installs
   next to the current app for side-by-side testing.

The number at the top middle is the frame rate. Tap it for the dev panel: level 1-30 (offline) and season (auto follows
the month, like the app), and Sign out.

## The start-up screens: `tools/unity/auth-test`

Splash, log in / register and verify are drawn by the Unity code (`Assets/Scripts/Ui/Screens`), so there's nothing to
export: `node tools/unity/auth-test/capture.mjs <dir>` screenshots the app's states (Expo web, `src/web/Preview.js`
"splash", "auth", "verify"), `dotnet run -c Release --project tools/unity/auth-test -- shots <dir>` draws the same
states from the Unity code and reports the pixels that differ. `node tools/unity/auth-test/menu.mjs <dir>` and
`-- menu <dir>` do the same for the menu's pills and crest with several players, and `-- emu` runs the screens' logic
against the Firebase emulators (`tools/unity/backend/start-emulators.sh`).

## The art: `node tools/unity/export-menu.mjs`

Builds the in-app web game, opens the menu in Chromium at the A15's size with the clock frozen, and cuts out every piece
into `Assets/Resources/Menu/` (needs `python3 -m pip install pillow` for the JPEGs). Run it again whenever the menu's
design changes. `--levels 1,5 --seasons rainy` exports fewer states; `--no-build` reuses the last web build;
`--hud-only` redoes just the HUD pieces. The numbers the player's profile changes aren't in the pictures: the coin and
gem pills are cut as their pictures only, the crest without its level number, and `Menu/HudArt.cs` draws the rest.

- `scene/<season>-<level>.jpg.bytes`: the house picture for each of the 90 states (JPEG, decoded by `MenuView`)
- `weather/`: one band of rain or snow and a bird, animated in Unity like `webgame/app/menu.js` does
- `hud/`: each button, pill, the crest, the name plate, the creature's still, and the flourishes frame by frame
- `menu.json`: where everything goes (device pixels on the reference screen) and how it moves
- `../Reference/menu-a15.png`: the app's menu at the same moment, what Unity's screenshot is compared with

`node tools/unity/compare.mjs --compose` rebuilds the menu from those pieces with the same placement rules as
`MenuView.cs` and compares it with the reference (it matches except JPEG noise on edges and sub-pixel rain).

## The Game Park's games carousel: `node tools/unity/export-park.mjs`

Opens the menu straight into the Game Park (as the app does when you come back from a game) with the app's games list,
and cuts out the carousel's pieces into `Assets/Resources/Park/` (each card, its window's inner shadow and shape,
PLAY, the dim, the header, the rays, the halo, the arrows, the dots, Squish Time's creature) with `park.json`; copies
the game clips to `Assets/StreamingAssets/Park/`; writes the app's screenshots to `webgame/test/out/unity-park/`
(`../Reference/park-a15.png` for CI). Run `export-menu.mjs` first (or pass `--no-build` to reuse its web build).
`dotnet run -c Release --project tools/unity/park-test` then draws the Unity code's carousel over the app's park and
reports the pixels that differ from the app (`-- 2048 1536` draws it on another screen shape).

## The creatures' animations: `tools/unity/rig/`, `tools/unity/rig-test/`

The creatures move exactly as in the app because Unity runs the app's own animation code (`rive-rig.js`,
`rive-generic.js`, the defs and move files, the result page's states) on the small stand-in for the browser it was
checked on (`dom-shim.js`, `virtual-clock.js`), **compiled to C#**: `node tools/unity/rig/jsc.mjs` turns every script
into a class in `Assets/Scripts/Creatures/Js/Gen` (its own assembly, `SquishSquad.Rig`, no Unity in it), on a small
runtime with the language's rules (`Creatures/Js`: values, objects, the built-ins, V8's number formatting, fdlibm's
maths). `Creatures/NativeRig.cs` runs it on Unity's clock (its scripts start on a worker thread as the app starts) and
hands each frame's SVG to `CreatureView`. Every creature, every move; no JS engine and no recordings. Re-run `jsc.mjs`
(after `node webgame/build.mjs`) when the design's rig changes, and `bundle.mjs` for the creature art it reads
(`Resources/Rig/files.bytes`).

- `node tools/unity/rig-test/run.mjs [keys...] [--all] [--scn idle,moves]` builds the C# rig with plain dotnet and runs
  it beside the JS rig in Node, the same scenarios on the same clock and seed (`rig-test/scenarios.js`: the menu's
  idle and fidgets, moves, a poke and a squeeze, the intro, MY HOUSE's turn, the park walk, the result card's four
  clips, the Stack road walk, the house's fidgets), and compares every snapshot's markup; ones that differ are drawn
  by Chrome both ways and compared by pixels (all 118 creatures x 13 scenarios: 62,516 of 62,540 snapshots the same
  markup, the rest at most 0.006 % of their pixels apart). `dotnet tools/unity/rig-test/bin/Release/net8.0/RigTest.dll
  bench [alloc] [keys]` times frames (here ~1.1 ms for Mittens with its markup, about half of V8's for the same rig).
- `node tools/unity/rig/parity.mjs mittens lumi ...` runs creatures in Chrome and on the stand-in, through idle, dance,
  hop, squish, wave and happy, and compares the whole SVG tree every few frames. Text differences are drawn both ways
  and compared by pixels. `--log-bbox` lists every measurement the rig takes on both sides.
- `node tools/unity/rig/bbox-fuzz.mjs` checks the stand-in's `getBBox` against Chrome's, to the bit, on random paths.
- `node tools/unity/rig/dump-frames.mjs <dir> mittens lumi ...` writes creature frames (SVG) with Chrome's picture of
  each; `dotnet run -c Release --project tools/unity/vector-test -- <dir>` compiles them with the Unity app's vector
  core (`Assets/Scripts/Vector`), draws them with a reference rasteriser and reports the pixels that differ from Chrome.
- `node tools/unity/rig/record.mjs <key> [--clip ...]` still records frames (the fallback `RecordedRig` plays them if
  the native rig can't start; none ship now).

## CI: screenshots and an APK on every push (`.github/workflows/unity.yml`)

Needs a Unity license as repository secrets (GitHub → Settings → Secrets and variables → Actions → New repository
secret). With a **Personal** license:

| Secret | Value |
|---|---|
| `UNITY_LICENSE` | the whole contents of `Unity_lic.ulf`. On Windows it's `C:\ProgramData\Unity\Unity_lic.ulf` (open it in Notepad, copy everything). It exists once Unity Hub has activated your license. |
| `UNITY_EMAIL` | your Unity account email |
| `UNITY_PASSWORD` | your Unity account password |

(A Plus/Pro seat: `UNITY_SERIAL` instead of `UNITY_LICENSE`.) Without them the workflow stops at its first step with a note.

What each run does:

- **screenshots**: opens the project headless, renders the menu at 2340 x 1080 (and 2400 x 1080, 1920 x 1080,
  2048 x 1536), compares the first with `Reference/menu-a15.png`, and pushes the pictures to the branch
  `unity-shots/<your branch>` (also an artifact). Fails if more than 2 % of the pixels differ.
- **android**: builds `SquishSquad.apk` (artifact `squish-squad-unity-apk`, on the run's page).

## Next

See `UNITY_MIGRATION_PLAN.md` at the repo root.
