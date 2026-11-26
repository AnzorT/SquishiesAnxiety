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
  - the chest unlock's creature after BAM was already live (1aeeaa3); its motion is now `Creatures/HeroPop.cs`
    (Unity-free), and `shop-test unlockframes` draws the whole unlock frame by frame with the rig (item 8)
  - **Unity's own look, on purpose** (the user, 2026-11-25: "we are focusing now only on unity"): the chest reveal has
    a soft breathing glow behind the card instead of the app's turning light beams. The reveal's pixel tests
    (`shop-test smash*`) differ from the app there from now on. The same beams on the Characters screen and the
    "Gathering your squad" loading screen are unchanged (the user: the chest reveal for now)
  - the house's runtime drawings on the compiled realm (`HouseDraw.Eval`: the beach, the house map, pieces the export
    didn't have), Renovate's signs (their text, the Aa editor; handwritten signs in Dancing Script, as Android draws
    `cursive`) and a shell's own wall text (none in the current app) (items 3 and 4)
  - the whole-screen stand-in a game opens under (`Games/Shared/ScreenBones.cs`, MenuScreen OpenUnder), every game
    on its hub's shape, the title's spot centred where the hubs' title is, and the build time logged (item 5)
- **Not checked yet:** none of it has been seen in the Unity Editor or on a device. Checked offline only: the pixel
  tests and a compile of every script in `unity/Assets/Scripts` against Unity 2021.3's reference assemblies
  (NuGet `UnityEngine.Modules`, with `UNITY_5_3_OR_NEWER` defined): it builds.
- **The Editor's first Play (2026-11-25, evening) found two things the offline checks couldn't:**
  - It didn't compile: the rig runtime is its own assembly (`Creatures/Js/SquishSquad.Rig.asmdef`), and
    `RigTree`, `RigStage` and `YardJs` use its `internal` members (`JsArray.Len`, `JsObject.N`). A single-project
    compile doesn't see the line between the two. Fixed: `Creatures/Js/AssemblyInfo.cs` (InternalsVisibleTo
    `SquishSquad.Runtime`).
  - Play froze the Editor (no picture, Stop dead): a stack overflow on the first creature mount. Unity's main thread
    has 1 MB (Unity.exe), and a few compiled functions have huge frames (rive-generic.js's biggest: 600 KB under
    .NET's JIT; see `UNITY_TODO.md`). Fixed: `Creatures/Js/RigThread.cs`, one thread with a 64 MB stack that every
    call into the realm runs on (RigHost, RigStage, YardJs, the tree reads), the caller waiting.
- **Played in the Editor (2026-11-26), and fixed on the way** (uncommitted until the user says so):
  - **Frame rate.** `App/PerfLog.cs` writes a `[Perf]` line to the log every 2 s under 50 fps (Editor and development
    builds): the frame, each timed part, each screen's update, "the rest" (Unity's own work and the Editor's), the GCs.
    - The rig's clock (`NativeRig.Advance`) caught up in 16 ms steps, up to 250 ms; a slow frame asked for more steps
      next time and never recovered (Hop's result card: 15 steps a frame, 4 fps). Now one step a frame, 12–50 ms, the
      rest dropped (12, not 16: at 60 Hz a frame at 15.9 ms got no step and the next a double one, a hitch).
    - The step runs on the rig thread while Unity draws: `RigFrameBegin` (first LateUpdate) has every live creature
      read its frame (`CreatureView.Prefetch`) and posts the step; `RigFrameEnd` (last LateUpdate) waits for it. What's
      drawn is one step behind. Each creature's shapes are made on `Vector/ShapeWorkers.cs` threads (not .NET's pool:
      its jobs waited 10–30 ms for a thread in the Editor). Hop's result card: 4 fps → about 48 in the Editor.
    - MY HOUSE ran at 1 fps: the house's pictures (data: URIs of whole SVGs) go through `encodeURIComponent`, which
      called System.Uri, and Unity's Mono refuses strings over ~65,000 characters there. `Rt.Builtins.cs` encodes and
      decodes as the spec says now (48 / 48 the same as Node, a 300 KB string among them).
  - **Exceptions.** A card layer with no markup yet (the result card's "trio edge") threw every frame in Hop and
    Squishdoku; `UiPiece.SetSvg(null)` now draws nothing. `RosterConfig` read config/roster before any screen had set
    the Resources loader, so the roster wasn't applied; it sets them itself now.
  - **One set of popups for every game (the user: Squish Hop's, reused).** The win card was already shared
    (`GameCards.ResultCard`). The fail card is Hop's STUCK! now everywhere (`GameCards.FailCard`, `Ui/Cards/
    SadBodyItem.cs`: the character whole and sad, its live rig sighing over the cut-out once it draws); each game keeps
    its title, line and buttons. Squishdoku drew its cards' layers itself and dropped their live characters
    (`SdLayer.Mirror`), so its win card's three never came alive: `SdLayer.Creature` and `SquishdokuScreen` draw them as
    `CardPieces` does (`CardPieces.Init` for any host).
  - **Squishdoku (the user).** Only Mittens: the app's roster.js takes only the player's own creatures (one owned =
    every piece that one). Now the player's own first, then the others (`SdCreature.Pick`). Its level map is the games'
    `LevelMap` as Squish Hop's: every level in one row through the chapters' rooms, a banner (the room's card,
    CHAPTER n · ROOM) opening each chapter; `SdMap.cs` is gone (`squishdoku-test flow` / `blitzflow` pass).
  - **Squish Hop's jump (another session).** The hops' height was inside the rig, past its texture (the hopper's head
    cut off in 8–13 % of play frames, friends in ~60 % of pickup frames). `tools/rig/hop.html` now lifts the `.ch` box
    (the rig still gets `ext.lift` for its springs, `ext.sk` sinks its drawing back) and draws its own `.sh` shadow;
    the legs' curves are continuous; a hop arriving mid-air lands the last one first. `HopLevel` LEG_MS / BOING_LEG_MS
    220 / 195; `StageView` gives its views more room on top (`CreatureView.Create(..., marginTop: 0.45)`), no shadow
    dimming. `Gen/S_hop_stage_js.cs` regenerated. Offline over 7 levels to the win: nothing cut off.
  - **Still to look at in the Editor:** Squishdoku (the mixed cast, the new map, its win and fail cards), the fail card
    in Sort and Stack, the Hop jump. In the Editor "the rest" is 10–16 ms a frame (Unity's rendering and the Editor
    itself); at the start the menu builds the house under it in a coroutine, which isn't timed.
- **The creatures' border looks (2026-11-26, the user: "i want all of them to have the number 3"; uncommitted, not
  seen in the Editor yet).** Unity ignored config/roster `look` (it's 3), and only the Pet Shop rigs (Mittens...) had
  the rig's own built-in look 4 shading (the "border" Mittens alone showed on Hop's PERFECT HOPS! card); no rig had a
  line: the rig's outline (rive-rig.js outlineEls) needs browser geometry the stand-in didn't have.
  - `tools/unity/rig/dom-shim.js`: computed style (presentation attributes, inheritance, rgb()), getCTM,
    getBoundingClientRect for SVG shapes, getTotalLength / getPointAtLength / isPointInFill (curves flattened),
    DOMPoint. `native-host.js`: every RiveRig.mount gets its creature's look (`__native.looks(n, over, keys)`; a mount
    with its own look keeps it; no look pictures = none) and a change redraws the creatures on screen;
    `__native.look(id, n)` for one creature (the yard posters: 3, as develop). The rig draws the look itself (MODES:
    3 = a bold line in the house ink round each part), so it matches the look pictures, not the app's outer-edge filter.
  - `Creatures/Js/RigLooks.cs` holds the looks (pushed at boot); `Screens/Common/RosterConfig.cs` reads `look` /
    `looks` (ids or keys) and keeps the last ones in PlayerPrefs (`squish.looks`) for the next start.
  - `Vector/SvgScene.cs`: `paint-order: stroke` on shapes. `Vector/Outline.cs`: a round join is the wedge the turn
    opens, not a whole circle per vertex (same stroke; vector-test against Chrome 5,773 vs 5,778 px without the look).
  - Stills: `export-chest.mjs --look 3 --looks-only` re-exported Resources/Chests/look in look 3 (one look only: all
    four as textures would add some 70 MB); `Roster.Picture` uses them (Achievements, Stats, Squish Time's loading),
    as the app's thumbnails. The games' pieces stay cut-outs, as in the app.
  - Checked offline: rig-test 435/435 frames the same JS vs C#; every one of the 118 creatures draws its line with
    no error; Chrome's rig and the stand-in pick the same parts; Unity's vector core vs Chrome on look-3 frames at
    0.2–0.35 % visible px (the lines' antialiasing). Cost on this PC (rig-test bench): Mittens 1.02 → 1.44 ms a
    frame, three creatures 3.33 → 4.45 ms; not measured on the A15 (MY HOUSE's squad is the heaviest).
    stage-test / yard-test pin look 0 (the app's pages draw their rigs without one).
- **The first APK on the phone (2026-11-26) closed at once, a black screen** (logcat: FATAL EXCEPTION main, "Unable to
  get provider com.google.android.gms.ads.MobileAdsInitProvider: IllegalStateException: Missing application ID",
  play-services-ads-lite 23.1.0). The AdMob app id was in `Plugins/Android/RewardedAds.androidlib/AndroidManifest.xml`,
  but an androidlib with its own build.gradle is read by Gradle's standard layout (`src/main/AndroidManifest.xml`), so
  the root manifest was skipped without a word while the Java (`src/main/java`) and play-services-ads still went in.
  Fixed: both androidlibs' build.gradle set `sourceSets.main.manifest.srcFile 'AndroidManifest.xml'`, and the
  manifests lost their `package` attribute (the build.gradle `namespace` names them). Not built yet: the next APK
  should open; the app id is still Google's test id (item 7).
- **Next, in this order:**
  1. **Press Play in the Editor and go through what changed:** Squish Sort (the map's fridges, a level, the win's
     doors), Squish Hop (a level: the rigs take over once the page has drawn the cast, then hop, bump, stuck, win),
     each of the seven yard games (intro poster, how-to sheet, play, result card), MY HOUSE ("Heading home" while
     the house loads), a chest upgrade and unlock (the glow), Squish Time (the loading beat, the sky), the intro on a
     rainy / snowy day, opening each game from the Game Park (the stand-in; the log's "opened in N ms"), and MY HOUSE:
     the map, the beach, a sign written in Renovate (Aa, typing on the phone's keyboard), and the chest's sounds on
     the phone (each tap's crack and thump, the bounces, the upgrade's rise and poof, the burst; the unlock's bells,
     whoosh, chord, rush, BAM and the creature's landing): how soon a tap's sound comes. Watch for: the rigs' timing, Sort's doors clipping the rigs, the frame rate with many rigs on the
     screen. Fix what's off.
  2. **Item 6:** ask the user to decide (Android back over the Catalog, a new player's starter furniture, the tutorial). **Item 7** is the user's (the A15 test, deploying `functions/`, the release
     setup).
- **Known failures that are older than this work:** Bunbun's park walks differ at 0.000 % (item 4, "Found on the
  way"). `rig-test --all`'s stack overflow about 110 runs in had the same cause as the Editor's freeze; the tests now
  run on the rig thread, and it got past 550 of 1,652 runs with no overflow (that run was then stopped from outside;
  a whole run is still to do).
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
  Offline, compile the scripts as Unity's four assemblies (the `.asmdef` files: `SquishSquad.Rig` =
  `Scripts/Creatures/Js/**` with no engine; `SquishSquad.Runtime` = the rest of `Scripts/**`, referencing Rig;
  `SquishSquad.Editor` = `Assets/Editor/**`; `SquishSquad.Audio.Editor` = `Scripts/Audio/Editor/**`), with
  `UNITY_EDITOR` defined and again without it. One project for everything misses access across them.
- Anything that calls into the compiled realm from Unity goes through `RigThread.Run` (RigHost's calls already do).
  Unity's main thread doesn't have the stack the compiled functions need.
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
- **Renovate:** ✅ signs done 2026-11-25. The house's runtime drawings now run in Unity (item 4's "Also"), so a sign's
  saved text is drawn, and **Aa** opens the sign editor (`House/SignPanel.cs`, `HouseEdit` Sign / SignSet /
  SignToggle / SignDone, `HouseEditView` DrawSign): WRITE YOUR SIGN and the sign's name, the text (the phone's
  keyboard, TouchScreenKeyboard; the computer's in the Editor), the sign's presets (a renovation sign's row `texts`, up
  to 26 letters; a House3D sign's SIGNP, up to 16), Done; the text saved on the piece (`txt`) and the piece redrawn.
  A shell's own HTML text (`sh.texts`) is drawn too (2026-11-25, `RoomCompose.TextBox`: the page's box put on its
  baseline, text-shadow glows as blurred copies); the current app writes none (the doors' plates are off, the neon wall
  art became a renovation piece), so it only shows if the page turns them back on (`house-test roompics` with
  `ROOM_TEXTS=1` draws two test texts). `house-test signframes`
  draws a sign being written. Not seen in the Editor yet.

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
  run clean. The overflow is fixed (2026-11-25): the test called the realm on its 1 MB main thread, where
  rive-generic.js's two biggest closures (600 + 341 KB frames) didn't fit; the tests' Main now runs on
  `RigThread`.
- **Also:** ✅ done 2026-11-25. The house's drawings made at runtime run on the compiled realm: the Squad House page's
  drawing scripts (house4.js on) and `tools/unity/house/draw-host.js` are compiled with the rig (`jsc.mjs`
  houseScripts: +13.8 MB of C#, 20.8 MB in all), `RigHost.HouseEval` takes HouseDraw's calls and NativeRig wires it
  as `HouseDraw.Eval`. Before, Unity had none: the beach wasn't drawn, the house map didn't open ("The map needs the
  drawing engine"), and a piece, shell or surface the export didn't have couldn't be drawn. `rig-test house.mjs`: 148 /
  148 calls answer as the JS (every exported variant and render, shells, textures, the beach in every season by day
  and night, the map). Two compiler fixes on the way (a Set's spread, an arrow's `this`); `rig-test` 1680/1680 still.
  `house-test housepics` draws the map and the beach with it. Watch on the A15: a runtime piece costs ~0.1 s to draw
  (once, then kept), the first call boots the house's part of the realm.

## 5. Small items

- [x] **Chest smash's additive glow** (2026-11-25): canvas `'lighter'` draws are now added, not laid over:
  `Canvas2D` wraps them in `mix-blend-mode: plus-lighter` and the canvas in `isolation: isolate` (so they add onto the
  canvas's own pixels, not the vault behind, as a canvas does); `Vector/SvgScene.cs` reads both (`FillNode` /
  `LayerNode.Additive`, an isolated group is a layer), `VectorRenderer` draws them with additive copies of
  VectorCover / VectorComposite (`Blend One [_DstBlend]`), and the reference rasteriser adds too. `shop-test smash-up`:
  1.0–1.7 % at every moment (it was 1.2–17.4 %). Not seen in the Editor yet.
- [x] **Squish Time's loading moment** (2026-11-25): `Games/Squish/SquishLoading.cs` (LoadingScreen.js: wood, the warm
  halo, the creature's still moving as CreatureThumbnail's 'ready' mood, "Getting ready" with the three hopping dots
  while its card is fetched, "I AM READY!" popping in with the 'ready' sound, the eased fade), over the screen as
  `SquishTime` opens (a `ScreenHost` above the HUD; touches wait for it). `loading-test` (`capture.mjs`: the page on the
  virtual clock): 0.4–2.0 %, 6.4 % at one moment of the fade's steepest part.
- [x] **Squish Time sky** (2026-11-25): `Games/Squish/SquishSky.cs`, SkyBackground.js's pieces for the screen's size
  (gradient, the two glows sized from the screen, the puffs solid to 52 %, the dot grid), not the stretched `hud/sky`.
  `loading-test` sky: 0.00 %.
- [x] **Whole-screen placeholder** (2026-11-25): `Games/Shared/ScreenBones.cs` (ScreenBones.js: the background, the
  back orb's and title's spots, the view's bones with the shine). `Menu/MenuScreen.cs` OpenUnder shows it the frame a
  game is asked for (`hub` on the warm page, Squishdoku on the wood; Hop `hub` too, though App.js still asks for
  `map` from before Hop had a hub), builds the game
  under it the next frame, then fades it out in 160 ms, and logs the build ("[Menu] Squish Stack opened in N ms": read
  it on the A15). The header's spots where the hubs have them (the user): the circle on the back orb, the title's
  bar centred (the app's sits next to the orb). `loading-test bones`: the background and bars as the app's; the app's two hub cards are
  14 dp bars (Bone's default height when `h` is undefined), Unity draws them as full cards like its in-game bones.
  `maps-test bonesframes` draws a game opening frame by frame. Not seen in the Editor yet.
- [x] **`tools/unity/saves-test` builds and passes again** (2026-11-25): `SavesTest.csproj` takes `Games/Hop/Blitz.cs`,
  and both sides play develop's games: the endless Blitz (`afterBlitz(profile, { cleared })` / `AfterBlitz(P, cleared)`
  for Stack, Sort and now Hop, paid on every run's end as payOut), Hop's stars by `takebacks`, Sort's fridge only.
  Against the emulators (`tools/unity/backend/start-emulators.sh`): 142 passed, 0 failed.
- [x] **No Mittens fallback in the menu** (2026-11-25, the user: remove it): `Menu/MenuView.cs` no longer swaps in
  Mittens when the player's creature can't be animated. Its rig runs for every creature now; if one ever can't start
  (or fails), the menu shows that creature's own still (`Characters/still/<key>`, at Mittens' scale with its feet
  where his are) and its own name plate, hidden through the intro's night like the live one. Not seen in the Editor.
- [x] **The chest's sounds** (2026-11-25): the pages synthesize them (chest-sfx.js for the smash, host.html's SND for
  the unlock), so Unity does too: `Audio/WebSynth.cs` is a small offline Web Audio (oscillators, noise, biquads,
  the gain ramps, the WaveShaper bus, the room's convolver, Chrome's own DynamicsCompressor)
  and `Audio/ChestSounds.cs` the two pages' recipes on it (every material, accent and voice; each chest's own `sfx`
  from models.json, now in `ChestMat.Sfx`). `ChestEngine` plays the hit, bounce, charge, poof and burst where
  chest-models.js does; `ChestSmashView` the unlock's card, fly, full, gather (stopped at the BAM or by a tap) and
  bam; `HeroPop.Landed` the landing. `Snd.Synth` renders off the main thread and `Audio/SynthPlayer.cs` plays the
  clip, off with "Sound effects". `tools/unity/sound-test` (its `web.mjs`: the pages' own scripts in Chrome's
  OfflineAudioContext): every sound within ~0.5 dB of Chrome's over its first 300 ms, the peaks alike; a hit renders
  in ~12 ms, a KO in ~40 ms on the desktop (the room's spectra made ahead as the smash opens: watch the delay on the
  A15). The chest page has no haptics. Not heard in Unity yet.
- [x] **The creatures react to touch** (2026-11-26, the user: on the main menu, in the Game Park and on the
  Characters screen): `Creatures/CreatureTouch.cs` hands a finger to the rig's own handlers (native-host.js `pointer`
  on the 0-100 box, `CreatureView.BoxPoint`): a tap plays that creature's poke for the spot (head, ear, nose, eye,
  cheek, belly, side, foot, tail, left / right), a 170 ms hold squeezes and lets go, a drag sideways turns it. The menu
  and the park take it inside the design's `.mm-hit` ellipse when the HUD / carousel didn't (`Menu/MenuView.Touch.cs`,
  `MenuScreen.HandleInput` / `HandlePark`); the Characters page now draws the picked creature's live rig in place of
  its still (`CharactersPage` TickLive: sqPop, hidden under the loader, `.sil` as tint .78 / saturation .3 without its
  glow, happy / love / cheer or look / surprised 350 ms after it mounts, its whole box takes touches). **Found on the
  way:** the design's rive-rig.js (Nov 13 zip) had swallowed its tap branch in a `//` comment (the let-go reaction
  added on the same line), so a tap poked nothing anywhere; `webgame/patches.mjs` makes it a block comment and
  `Gen/S_rive_rig_js.cs` is regenerated (the only Gen file that changed). The phone app's web game gets the same fix
  the next time it's built. Checked offline: a headless tap / hold / drag on 12 creatures of 10 groups (every tap a
  `poke_<spot>` state), `rig-test --scn touch,intro` 325/325 equal. Not seen in the Editor yet.
- [x] **Sounds and haptics** in the other ported screens (see `UNITY_TODO.md`); the stale "Not ported: sounds" notes
  at the top of the game and screen files are corrected. **Left:** the house's own sounds (with the house, item 1).

- [x] **The house's moving pieces** (2026-11-26): what the app moves and Unity didn't. The robot vacuum (LIV-136): a tap
  sends it out of its dock to clean for 5 minutes, wandering to free spots with its turn wiggle, jitter and dust
  sparkles, brushes and lidar turning; a tap again (or the 5 minutes) drives it home; edit mode or leaving the room
  takes it away (`House/HouseVac.cs`, `House/View/HouseVacView.cs`, `__house.vac` in the draw host). A kicked toy now
  spins as it rolls and scales for its depth (its shadow a layer of its own). The SMIL sampler is shared
  (`House/Smil.cs`, the beach's before). `house-test vacframes` draws them frame by frame. The swings, clocks, fish
  and the pieces' own animations aren't moved in the app either (it strips them for the phone's speed), so they stay
  still. Not seen in the Editor yet.

## 6. Decide

- [ ] **Android back over the house's Catalog:** the app leaves the house at once (`webgame/app/bridge.js` clicks
  `.mm-hback`). Unity closes the detail, then the Catalog, then Renovate, one step at a time. Pick one; it's the ❓ row
  in `UNITY_SYNC_DEVELOP.md`.
- [ ] **A new player's living room has no starter furniture** (checked 2026-11-25, app and Unity the same:
  `house-test roompics <dir> fresh-lv1` vs the app's page on a fresh profile): the page's RSTART (a couch, a centre
  table, the TV) never lands, because the save's window migration (WSTART: LIV-012) fills `rooms.living` before
  unlockRooms runs `rnStart`, which only seeds an empty room. Keep it as the app has it, or seed the starters in Unity
  (a small change in `HouseSave.RnStart` / the order in Load).
- [ ] **The new-player tutorial** (`UNITY_TODO.md`): check whether develop's app still has one (Settings has no
  "Replay tutorial" now); if it does, port it.

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
