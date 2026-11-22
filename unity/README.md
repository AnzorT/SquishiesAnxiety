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
3. Press Play in any scene: `Assets/Scripts/App/Boot.cs` builds the menu. Set the Game view to 2340 x 1080 to see it at
   the reference size.
4. On the phone: **Squish Squad → Build Android APK** (or File → Build Settings). It has its own app id, so it installs
   next to the current app for side-by-side testing.

The number at the top middle is the frame rate. Tap it for the dev panel: level 1-30 and season (auto follows the
month, like the app).

## The art: `node tools/unity/export-menu.mjs`

Builds the in-app web game, opens the menu in Chromium at the A15's size with the clock frozen, and cuts out every piece
into `Assets/Resources/Menu/` (needs `python3 -m pip install pillow` for the JPEGs). Run it again whenever the menu's
design changes. `--levels 1,5 --seasons rainy` exports fewer states; `--no-build` reuses the last web build.

- `scene/<season>-<level>.jpg.bytes`: the house picture for each of the 90 states (JPEG, decoded by `MenuView`)
- `weather/`: one band of rain or snow and a bird, animated in Unity like `webgame/app/menu.js` does
- `hud/`: each button, pill, the crest, the name plate, the creature's still, and the flourishes frame by frame
- `menu.json`: where everything goes (device pixels on the reference screen) and how it moves
- `../Reference/menu-a15.png`: the app's menu at the same moment, what Unity's screenshot is compared with

`node tools/unity/compare.mjs --compose` rebuilds the menu from those pieces with the same placement rules as
`MenuView.cs` and compares it with the reference (it matches except JPEG noise on edges and sub-pixel rain).

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
