# Unity port: what's left (as of 2026-11-25)

The goal: the Unity app (`unity/`) matches the React Native app on `develop` exactly. Most of it is done. This file
lists what isn't, so it can be picked up item by item with Claude Code.

## Where it stopped (2026-11-25): continue from here

- **Done:** items 1–4 below (commits 6a1d8b3, 7705f86, c265b47, a73b319, 5301a53, all pushed). Also pushed: the
  texture `.meta` files the Editor rewrote when it re-imported the art with `Editor/ProjectSetup.cs`'s import rules
  (no GUID changes).
- **Not checked yet:** none of items 1–4 has been seen in the Unity Editor or on a device. They were checked offline
  only: the pixel tests (numbers in each item) and an offline compile of the scripts with `dotnet`.
- **Next, in this order:**
  1. **Press Play in the Editor and go through what changed:** Squish Sort (the map's fridges, a level, the win's
     doors), Squish Hop (a level: the rigs take over once the page has drawn the cast, then hop, bump, stuck, win),
     each of the seven yard games (intro poster, how-to sheet, play, result card), and MY HOUSE ("Heading home" while
     the house loads). Watch for: the rigs' timing, Sort's doors clipping the rigs, the frame rate with many rigs on
     the screen. Fix what's off.
  2. **Item 5, the small items.** (`saves-test` is done.) Then the chest smash's additive glow,
     Squish Time's loading moment and sky, the whole-screen placeholder, the Mittens fallback, and sounds.
  3. **Item 4's "Also":** compile `draw-host.js` for `HouseDraw.Eval` the way the stage pages are compiled. After
     that, Renovate's signs (item 3).
  4. **Item 6:** ask the user to decide. **Item 7** is the user's (the A15 test, deploying `functions/`).
- **Known failures that are older than this work:** `rig-test --all` stops about 110 runs in with a C# stack
  overflow, and Bunbun's park walks differ at 0.000 % (item 4, "Found on the way").
- **This machine has only .NET 10:** run the tests with `DOTNET_ROLL_FORWARD=Major`, or build them with
  `-p:TargetFramework=net10.0`.

## Read first

- `UNITY_SYNC_DEVELOP.md`: every screen with its status (✅ done, 🔧 partly done (the row says what's left), ⬜ to do,
  ❓ to decide) and where the Unity code for it lives. Update its row when you finish something.
- `unity/README.md`: the tools, one per screen:
  - An exporter (`tools/unity/export-*.mjs`) cuts the fixed art out of the running app. Start the app with
    `npx expo start --web --port 8081`, or for some exporters use the built web game in
    `webgame/test/out/unity-webgame`.
  - A pixel test (`dotnet run -c Release --project tools/unity/<test> -- ...`) draws the Unity code's screen next to
    the app's and counts the pixels that differ. About 1–3 % is a match; more than that means something is off.
- `UNITY_TODO.md`: longer-term notes (performance next steps, sounds, etc.).

## How to work

- Work and commit on `develop`. Commit only the files you changed (`git commit -- <paths>`), and don't force-push.
- Every new file under `unity/Assets` needs a `.meta` file with a fresh GUID.
- Check that it compiles: open the project in the Unity editor (or use the CI workflow `.github/workflows/unity.yml`).
- Rules tests for the games: `tools/unity/games/<game>` compares Unity's rules with the app's JS. Keep them all
  passing.
- The creatures are animated by `Creatures/NativeRig.cs` (the app's rig compiled to C# by `tools/unity/rig/jsc.mjs`).
  If the creature designs change, re-run `jsc.mjs`, then `node tools/unity/rig-test/run.mjs --all` (the parity test
  against the app).

---

## 1. Squish Sort: the realistic fridges (biggest) ✅ done 2026-11-24

- **App:** `src/sort/Container.js` and `src/sort/models.js` (about 1,470 changed lines; all SVG). The fridge is drawn
  on the map (the fridge pictures) and on the play screen.
- **Unity now:** develop's seven fridges (`Games/Sort/SortModels.cs`, `SortArt.Fridge.cs`), on the map and in play.
  `sort-test` levels 1, 6, 12, 19, 26, 33, 42 (every fridge): 1.5–2.3 %; `sort-test blitz` about 2 %.
- **Also done:** the win as develop: the doors swing shut over the bounce wave, the impostors spin away, and the
  stills' other moves (happy hop, head shake with a sweat drop, droop and sway on a loss, the GAME OVER droop).

## 2. Yard games (big) ✅ done 2026-11-24

- **App:** the seven yard games are landscape (yard-games.js v4–v6 in `yard-mini-games.zip`, laid over the prototype
  by `webgame/build.mjs`; hoop, soccer, slide and pong were rewritten). Each opens with a poster intro and a how-to
  sheet (`yg-intros.js`) and ends with the app-look result cards. `webgame/app/games.js` wires the Yard Games page.
- **Unity now:** the app's own game code runs: `yard-games.js`, `yg-intros.js` and the seven `yg-*.js` are compiled
  with the rig by `tools/unity/rig/jsc.mjs` (bridge: `tools/unity/rig/yard-host.js`) and run on the rig's clock
  (`Games/Yard/YardJs.cs`); `Games/Yard/View/YardScreen.cs` draws the stage's layers and creatures, and
  `YardGameArt.cs` the top bar, pills, toasts, intro sheet and result card from the page's CSS. The old portrait
  `Yard*.cs` games are gone; the saved bests live in PlayerPrefs (`YardSave.cs`).
- **Test:** `tools/unity/yard-test` (`capture.mjs` shoots the app's intro / play / result per game, `YardTest shots`
  draws Unity's): mostly 2–5 %; what's left is the intro poster's creature (look 3's ink line, the fabric grain on
  the still), the games' random parts (opponents, obstacles), and the ★'s fallback font on the result card.

## 3. House: "Heading home" and Renovate

- **"Heading home":** ✅ done 2026-11-24. The loading screen while the house opens (`webgame/app/menu.js`
  M.headingHome, REDESIGN_V9): night falls on the house, its rooms light up as it loads, the moon and stars, the
  lettering and a tip (no bar since the user's ruling). Unity: `Menu/MenuView.Heading.cs` with the night made by
  `Menu/HeadingNight.cs` (Unity-free); `MenuScreen` loads the house under it. Test: `tools/unity/heading-test`
  (`capture.mjs` holds the app's night with every room lit; lv12: 1.04 %).
- **Renovate:** checked 2026-11-24. Re-exporting its pieces from develop's build (`export-edit.mjs`) changes nothing but
  the text pictures' anti-aliasing, and develop's house-page changes since the port (tray stills, yard toys out of the
  tray, the veil) are in. What still differs is **signs**: the toolbar's "Aa" (writing on a sign: the page's sign
  editor with its presets) only toasts in Unity, and a sign's own text isn't drawn (`RoomCompose`: HTML text,
  `sh.texts`). Both need the house's runtime drawing (`HouseDraw.Eval`, see item 4's "Also").

## 4. Sort and Hop: animated creatures on the play screens ✅ done 2026-11-24 (but the "Also")

- **Unity now:** the app's own stage pages run in the rig's realm: `jsc.mjs` takes each page's script out of
  `tools/rig/sort.html` / `hop.html` (STAGE_PAGES, in a `window` of its own with its own `#board`) and
  `tools/unity/rig/stage-host.js` is the bridge; `Creatures/RigStage.cs` makes the calls and reads each squishy back,
  `Creatures/StageView.cs` draws them (CreatureView got `Place`: any 2D box, cut to a band). The games make the app's
  calls: `Games/Sort/SortLevel.Rigs.cs`, `Games/Hop/HopLevel.Rigs.cs` (and their call sites, as Game.js), and
  `SortGame` / `HopGame` step the page's clock and draw it. The stand-in learned what the pages need (`dom-shim.js`:
  `svg.getElementById`, getBBox leaving out `display: none` children, the sort page's CSS rule through `__cssHidden`).
- **Tests:** `tools/unity/stage-test`: `capture.mjs` + scenes (the page in Chromium vs compiled: sort-rest 3.6 % of
  the squishies' pixels, hop-rest's boxes equal but Mittens' design), `sortlevel` / `hoplevel` (real levels on the
  compiled pages: the rigs take over and stand exactly where the stills / cut-outs stand).
- **Left:** see them in the Editor and on a device (timing, the doors' clip, how many rigs a frame the A15 can draw).
  Mittens on the Hop page is the web build's design (as Unity's menu), not the app page's design-v6 copy.
- **Found on the way (older than this work):** `node tools/unity/rig-test/run.mjs --all` (run with
  `DOTNET_ROLL_FORWARD=Major` where only .NET 10 is installed) stops about 110 runs in with a stack overflow in the C#
  side (deep in rive-generic.js, from a promise), right after Bunbun's park walks, whose outline point lists differ
  from the JS's at 0.000 % of pixels; both happen the same with the stand-in before this work. Bunbun and Jelli alone
  run clean.
- **Also (open):** the house's drawings made at runtime (`HouseDraw.Eval`) have nothing behind them yet.
  `draw-host.js` could be compiled the same way; Renovate's signs wait for it (item 3).

## 5. Small items

- [ ] **Chest smash:** the upgrade's glow beams need additive blending (now normal; up to 17 % off in `shop-test
  smash-up`). Also add the page's hit and unlock sounds. Code: `Screens/Chests/ChestSmashView.cs`.
- [ ] **Squish Time's loading moment:** wood, the creature, "Getting ready" with three hopping gold dots, then
  "I AM READY!" and a fade (`src/screens/LoadingScreen.js`). Unity goes straight into Squish Time.
- [ ] **Squish Time sky:** draw it as native pieces (puffs without the solid core) instead of the old `hud/sky`.
- [ ] **Whole-screen placeholder:** the warm page / wood with the back orb's and title's spots for screens opened
  over the menu (`src/components/Skeleton.js` ScreenBones). Unity builds its screens at once, so it never shows one.
- [x] **`tools/unity/saves-test` builds and passes again** (2026-11-25): `SavesTest.csproj` takes `Games/Hop/Blitz.cs`,
  and both sides play develop's games: the endless Blitz (`afterBlitz(profile, { cleared })` / `AfterBlitz(P, cleared)`
  for Stack, Sort and now Hop, paid on every run's end as payOut), Hop's stars by `takebacks`, Sort's fridge only.
  Against the emulators (`tools/unity/backend/start-emulators.sh`): 142 passed, 0 failed.
- [ ] **Menu fallback to Mittens** (`Menu/MenuView.cs`, commit 93a81bb): every creature animates now, so this almost
  never kicks in. Keep it as a safety net or remove it.
- [ ] **Sounds and haptics** in the ported screens (see `UNITY_TODO.md`).

## 6. Decide

- [ ] **Android back over the house's Catalog:** the app leaves the house at once (`webgame/app/bridge.js` clicks
  `.mm-hback`). Unity closes the detail, then the Catalog, then Renovate, one step at a time. Pick one; it's the ❓ row
  in `UNITY_SYNC_DEVELOP.md`.

## 7. Outside the code

- [ ] **Test in the Unity editor and on the Galaxy A15:** frame rate (the creature rig: `NativeRig.LastFrameMs`; the
  result card has three at once), start-up time on Android, build size of the generated rig code under IL2CPP. If it
  stutters, the next performance steps are in `UNITY_TODO.md` (the rig still allocates about 586 KB per creature per
  frame; the biggest part is small `[x, y]` point arrays).
- [ ] **Deploy the server functions for `develop`** (`functions/`). Until then the daily spin pays 150 coins and
  chests roll the old way.
