# Squish Squad in Unity

The Unity version of the app, built screen by screen next to the current React Native app, which keeps working until
Unity has caught up. Same Firebase backend, same look: the pictures come out of the current app's own code, so on the
reference phone (Galaxy A15, 2340 x 1080) Unity draws the same pixels.

**Ported so far: the Main Menu** (house picture for every level and season, rain / snow / birds, every HUD button, the
crest's and PLAY's flourishes, pressed looks). Taps show a "not in the Unity version yet" note; nothing else is ported.

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

## The creatures' animations: `tools/unity/rig/`

The creatures move exactly as in the app because Unity will run the app's own animation code (`rive-rig.js` and
friends, unchanged) on a small stand-in for the browser, `dom-shim.js`, driven by `virtual-clock.js`, and draw the
shapes it produces each frame. (Drawing them in Unity and running a JS engine inside Unity are the next steps.)

- `node tools/unity/rig/parity.mjs mittens lumi ...` runs creatures in Chrome and on the stand-in, through idle, dance,
  hop, squish, wave and happy, and compares the whole SVG tree every few frames. Text differences are drawn both ways
  and compared by pixels. `--log-bbox` lists every measurement the rig takes on both sides.
- `node tools/unity/rig/bbox-fuzz.mjs` checks the stand-in's `getBBox` against Chrome's, to the bit, on random paths.
- `node tools/unity/rig/dump-frames.mjs <dir> mittens lumi ...` writes creature frames (SVG) with Chrome's picture of
  each; `dotnet run -c Release --project tools/unity/vector-test -- <dir>` compiles them with the Unity app's vector
  core (`Assets/Scripts/Vector`), draws them with a reference rasteriser and reports the pixels that differ from Chrome.

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
