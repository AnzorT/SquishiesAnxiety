# Unity port: what's left (as of 2026-11-24, `develop` at 1223d6e)

The goal: the Unity app (`unity/`) matches the React Native app on `develop` exactly. Most of it is done. This file
lists what isn't, so it can be picked up item by item with Claude Code.

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

## 4. Sort and Hop: animated creatures on the play screens

- **Unity now:** the creatures there are still pictures (cut-outs).
- **To do:** compile the app's stage pages (`tools/rig/sort.html` / `tools/rig/hop.html`) with `tools/unity/rig/jsc.mjs` the
  way the menu rig is, wire the game events (place, correct, wrong, win, lose, hop, bump...) to the rig, and check it
  visually in Unity. Squish Stack's road walker (`NativeRig.WalkStep`) is the example to follow.
- **Also:** the house's drawings made at runtime (`HouseDraw.Eval`) have nothing behind them yet. `draw-host.js`
  could be compiled the same way.

## 5. Small items

- [ ] **Chest smash:** the upgrade's glow beams need additive blending (now normal; up to 17 % off in `shop-test
  smash-up`). Also add the page's hit and unlock sounds. Code: `Screens/Chests/ChestSmashView.cs`.
- [ ] **Squish Time's loading moment:** wood, the creature, "Getting ready" with three hopping gold dots, then
  "I AM READY!" and a fade (`src/screens/LoadingScreen.js`). Unity goes straight into Squish Time.
- [ ] **Squish Time sky:** draw it as native pieces (puffs without the solid core) instead of the old `hud/sky`.
- [ ] **Whole-screen placeholder:** the warm page / wood with the back orb's and title's spots for screens opened
  over the menu (`src/components/Skeleton.js` ScreenBones). Unity builds its screens at once, so it never shows one.
- [ ] **`tools/unity/saves-test` doesn't build:** `HopSave.cs` uses `AfterBlitzResult` from `Games/Hop/Blitz.cs`,
  which the test project doesn't include. Add it (and anything else it needs) to `SavesTest.csproj` and fix the
  calls to the new Blitz API.
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
