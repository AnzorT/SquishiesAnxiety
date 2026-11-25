# Unity port: what's left (as of 2026-11-25)

The goal: the Unity app (`unity/`) matches the React Native app on `develop` exactly. Most of it is done. This file
lists what isn't, so it can be picked up item by item with Claude Code.

## Where it stopped (2026-11-25, second session): continue from here

- **Done and pushed** (branch `ccr-5d87b564-vqdyo7`, on top of `develop` at af7a904; merge it into `develop`):
  - items 1–4 below (first session: 6a1d8b3, 7705f86, c265b47, a73b319, 5301a53)
  - `saves-test` builds and passes again: 142 / 142 against the emulators (item 5)
  - the chest smash's upgrade glow is additive, as the page's canvas 'lighter': `smash-up` 1.0–1.7 % (was up to
    17.4 %); the other smash shots unchanged or better (item 5)
  - Squish Time's loading beat (`SquishLoading.cs`) and sky (`SquishSky.cs`): `loading-test` mean 1.4 %, sky 0.00 %
    (item 5)
  - the game intro's rain and snow (`Menu/IntroRain.cs`): `auth-test rain` 0.10 % rainy and snowy (item 8)
- **Not checked yet:** none of it has been seen in the Unity Editor or on a device. Checked offline only: the pixel
  tests and a compile of every script in `unity/Assets/Scripts` against Unity 2021.3's reference assemblies
  (NuGet `UnityEngine.Modules`, with `UNITY_5_3_OR_NEWER` defined): it builds.
- **Next, in this order:**
  1. **Press Play in the Editor and go through what changed:** Squish Sort (the map's fridges, a level, the win's
     doors), Squish Hop (a level: the rigs take over once the page has drawn the cast, then hop, bump, stuck, win),
     each of the seven yard games (intro poster, how-to sheet, play, result card), MY HOUSE ("Heading home" while
     the house loads), a chest upgrade (the glow), Squish Time (the loading beat, the sky) and the intro on a rainy /
     snowy day. Watch for: the rigs' timing, Sort's doors clipping the rigs, the frame rate with many rigs on the
     screen. Fix what's off.
  2. **Item 5, what's left:** the whole-screen placeholder, the Mittens fallback, sounds (the chest's hit and unlock).
  3. **Item 4's "Also":** compile `draw-host.js` for `HouseDraw.Eval` the way the stage pages are compiled. After
     that, Renovate's signs (item 3).
  4. **Item 6:** ask the user to decide. **Item 7** is the user's (the A15 test, deploying `functions/`, the release
     setup).
- **Known failures that are older than this work:** `rig-test --all` stops about 110 runs in with a C# stack
  overflow, and Bunbun's park walks differ at 0.000 % (item 4, "Found on the way").
- **.NET:** the tests target .NET 8 (`apt-get install dotnet-sdk-8.0` on Ubuntu). Where only .NET 10 is installed,
  run them with `DOTNET_ROLL_FORWARD=Major`, or build them with `-p:TargetFramework=net10.0`.
- **What the tests need running:** the Expo web app (`npx expo start --web --port 8081`), the built web game
  (`node webgame/build.mjs --out webgame/test/out/unity-webgame`), and for `saves-test` / `shop-test emu` the
  emulators (`WORK=<scratch> tools/unity/backend/start-emulators.sh`).

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

- [x] **Chest smash's additive glow** (2026-11-25): canvas `'lighter'` draws are now added, not laid over:
  `Canvas2D` wraps them in `mix-blend-mode: plus-lighter` and the canvas in `isolation: isolate` (so they add onto the
  canvas's own pixels, not the vault behind, as a canvas does); `Vector/SvgScene.cs` reads both (`FillNode` /
  `LayerNode.Additive`, an isolated group is a layer), `VectorRenderer` draws them with additive copies of
  VectorCover / VectorComposite (`Blend One [_DstBlend]`), and the reference rasteriser adds too. `shop-test smash-up`:
  1.0–1.7 % at every moment (it was 1.2–17.4 %). Not seen in the Editor yet. **Left:** the page's hit and unlock
  sounds (`Screens/Chests/ChestSmashView.cs`).
- [x] **Squish Time's loading moment** (2026-11-25): `Games/Squish/SquishLoading.cs` (LoadingScreen.js: wood, the warm
  halo, the creature's still moving as CreatureThumbnail's 'ready' mood, "Getting ready" with the three hopping dots
  while its card is fetched, "I AM READY!" popping in with the 'ready' sound, the eased fade), over the screen as
  `SquishTime` opens (a `ScreenHost` above the HUD; touches wait for it). `loading-test` (`capture.mjs`: the page on the
  virtual clock): 0.4–2.0 %, 6.4 % at one moment of the fade's steepest part.
- [x] **Squish Time sky** (2026-11-25): `Games/Squish/SquishSky.cs`, SkyBackground.js's pieces for the screen's size
  (gradient, the two glows sized from the screen, the puffs solid to 52 %, the dot grid), not the stretched `hud/sky`.
  `loading-test` sky: 0.00 %.
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
- [ ] **Release setup** (`UNITY_TODO.md`): the real AdMob ids (`App/Ads.cs` has Google's test ids), the Unity license
  secrets in GitHub for CI, the Unity app's Android id in Firebase (`com.plushcrush.unity`) or the old app's id, the
  app and its products in the Play Console, a test purchase and a rewarded ad on the phone.
- [ ] **New-player tutorial** (`UNITY_TODO.md`): check whether develop's app still has one (Settings has no "Replay
  tutorial" now); if it does, port it.

## 8. From the screen table (`UNITY_SYNC_DEVELOP.md`)

- [x] **The game intro's rain / snow** (2026-11-25): `Menu/IntroRain.cs` (intro.js rainBuild), on the frame over the
  house, under the captions, from the night into the morning; `auth-test rain` 0.10 % (capture-intro.mjs
  `WEATHER=rainy|snowy`). Left there: a run in the Editor for timing and placement.
- [x] **The chest unlock's creature after BAM** comes out live on its native rig: done on 2026-11-24 (1aeeaa3,
  `Creatures/HeroCreature.cs`); the screen table still said otherwise. 2026-11-25: its motion (popAt: the grow out of
  the burst, the spin, the hop, the landing's dust and sparkles, 'happy') moved into `Creatures/HeroPop.cs` (no
  UnityEngine), which `shop-test unlockframes` uses to draw the whole unlock frame by frame with the rig.
- [x] **Blitz cards' unit** (board / round / puzzle): the code already said the right word per game (`StackBlitz`
  puzzle, `SortBlitz` round, `HopBlitz` board); its row in `UNITY_SYNC_DEVELOP.md` is ✅ now.
