# Performance: what was slow, what changed, how to measure

Written 2026-09-29 after profiling the app on the Galaxy A15 (Helio G99, Mali-G57 MC2, 90 Hz screen, 4 GB RAM) and on the Pixel_9 emulator. The goal was a squish stage and menus that hold the screen's refresh rate the way a native (Unity-style) build would.

## Two findings that matter more than any code change

**1. Test smoothness on a release build.** Both installs (emulator and phone) were *debug* builds: `pkgFlags=[ DEBUGGABLE … ]` in `adb shell dumpsys package com.plushcrush.app`. A debug build runs React with development checks, loads the bundle over Metro, and validates every bridge message. On the A15 the same squish measured 23-29 fps in debug and 44 fps in release before any optimisation. Build one with:

```
cd android && ./gradlew assembleRelease -PreactNativeArchitectures=arm64-v8a
adb install -r app/build/outputs/apk/release/app-release.apk
```

It is signed with the debug keystore (see `android/app/build.gradle`), so it installs over the debug build and back again. `-PreactNativeArchitectures=arm64-v8a` skips the other three ABIs and cuts the native build from ~25 minutes to ~7 (a rebuild after a JS-only change takes ~2). Reinstall the debug build with `npx expo run:android` as before.

**2. The squish was CPU-bound on the JS thread.** Every premade creature is a 6k-vertex / 10k-triangle Tripo mesh (the custom photo creatures go up to 55k vertices). The old soft body ran one spring per vertex plus a diffusion pass, rewrote every position, recomputed every normal, and re-uploaded both buffers each frame, all on Hermes (no JIT): 11-19 ms a frame on the A15, plus a 6-10 ms raycast over all triangles on every finger move. At a 90 Hz frame budget of 11 ms, that alone forced 2-3 vsyncs per frame.

## What changed

| Area | Before | After |
|---|---|---|
| Dent physics (`src/components/SquishyToy.js`) | Per-vertex springs + diffusion on the JS thread, positions and normals re-uploaded every frame | The vertex shader evaluates the same exponential funnel per vertex from a short list of press points (`uSquishPress`, up to 24), and tilts the authored normal by the exact Jacobian of the displacement. JS advances one scalar spring per press point. Measured offline against the old simulation on the real meshes: mid-hold positions within 0.01 units (body is 1.9 across), analytic normals within ~1.5° of a full recompute. JS cost per frame: ~18 ms → ~0.3 ms, independent of mesh size. |
| Touch picking | Möller–Trumbore over all 10k triangles per move | A uniform grid over the rest mesh's triangles (built once per model, cached) walked along the ray: 7 ms → under 1 ms. The screen-space fallback for misses samples every other vertex on dense meshes. |
| Whole-body puff (`lift`) | Baked into every vertex position | On the group transform, like the squash and wobble already were |
| Anti-aliasing (`src/components/Supersample.js`) | Fixed 2x supersampling | Still 2x, but adaptive: every 60 frames a blocking `gl.getError()` measures how far behind the GL thread is (expo-gl never blocks otherwise). Two slow probes step the factor down 2 → 1.5 → 1; eight clean ones step it back up. Logged as `[Supersample] …` |
| Sound (`src/audio/OneShotSound.js`) | A new expo-av player (a whole ExoPlayer, created on the UI thread) for every coin ding and release pop | Three players loaded once per effect, replayed round-robin |
| Touch effects (`src/screens/SquishScreen.js`) | A ripple and a "+N" coin mounted per touch / per earn tick | Pooled (3 each), moved and restarted through native-driver `setValue`s. The one-time gesture hint now unmounts after it fades instead of animating invisibly for the whole session. |
| UI compositing | The full-screen candy background (six gradient/pattern fills), sparkle glyphs with blurred shadows, and the spinning card rays were re-rasterised whenever anything moved over them | `renderToHardwareTextureAndroid` on those views: each is one cached texture that the native-driver animations only transform |

The 2D creature path (`SquishyToy2D`) is untouched.

## Numbers (Galaxy A15, release build)

| Scenario | Before | After |
|---|---|---|
| Squish stage, holding and dragging | 44 fps (JS frame 22.7 ms: physics 11.1, pick 0.6) | 80-88 fps (JS frame 11.4-12.6 ms: physics 0.1, pick < 1, three.js render 2.4) |
| Squish stage, idle | 85 fps | 85-88 fps |
| UI-thread janky frames (`dumpsys gfxinfo`): splash / Home idle / Home paging / toy | 0.5% / 1.1% / 2.3% / 0.8% | 0.04% / 0.3% / 0.4% / 0.3% |
| App threads during a hold (`top -H`) | RenderThread 57%, main 33%, JS 28%, GL thread 25% | JS 24%, Mali driver 17%, everything else under 5% |

Same phone, debug build, before: 19-26 fps while squishing.

## How to measure

- **JS frame time on the squish stage:** `src/perfProbe.js` logs a line every 2 s while the stage is mounted, in debug and release alike: `[perf] 85.5 fps, frame 11.8 ms (max 23) pick 0.00, physics 0.07, render 2.43, glWait 0.31, ssFactor 2`. `pick` is the touch raycast, `physics` the press-point springs, `render` three.js's own JS work, `glWait` the last GPU back-pressure probe (ms; under 2 is healthy, over 6 means the GPU is behind), `ssFactor` the current supersampling. Read it with `adb logcat | grep perf`. The FPS pill on the stage (Settings → Show FPS) shows the same frame rate.
- **UI thread:** `adb shell dumpsys gfxinfo com.plushcrush.app reset`, use the app, then `adb shell dumpsys gfxinfo com.plushcrush.app` and read "Janky frames" and the percentiles. Take the dump *after* the window you care about: the dump itself blocks the app's main thread for several seconds on Samsung phones and shows up as a 5 s stall in the perf log.
- **Threads:** `adb shell top -H -p $(adb shell pidof com.plushcrush.app) -n 1 -d 4 -b` while doing something; `mqt_js` is the JS thread, `RenderThread` the UI compositor, `mali-cmar-backe` the GPU driver.
- **Driving the phone without touching it:** `adb shell input tap X Y`, `adb shell input motionevent DOWN|MOVE|UP X Y` (a held finger), `adb exec-out screencap -p > shot.png`. Each command takes a second or two over wireless ADB.
- **Offline physics harness:** the app's physics functions can be sliced out of `SquishyToy.js` (from `const clamp = ` to `// Memoized so a parent`) and run in Node with a hand-parsed GLB; `node --jitless` approximates Hermes within about 20%. The cached models are in the app's `cache/creatureModels/*.glb` (readable with `run-as` on a debug build).

## Knobs and follow-ups

- `PRESS_MOVE_EPS` in `SquishyToy.js` (0.008 model units): how far the finger slides before the dent starts a new press point (with the old one springing back — the "jelly" lag). Smaller = more lag and more press points; the shader takes up to `SQUISH_MAX_PRESSES` (24).
- `FACTOR_STEPS`, `SLOW_MS`, `CLEAN_MS` in `Supersample.js` tune the adaptive quality. Pass `adaptive={false}` to `<Supersample>` to pin the factor.
- The earn tick (every 1.5 s while held) still costs a frame or two: the coin counter's re-render and the sound. Pooling removed the view mounts; what's left is small.
- The Mystery Box tap burst was not re-measured on the phone after these changes.

## Moving between screens (2026-10-08)

Taps that open a screen felt slow. The data wasn't the cause: the catalog, profile and creations stream in through Firestore listeners at startup and stay in App's state, so no screen fetches anything when it opens. The cause was that App showed exactly one screen at a time. Opening the Crib, Achievements, Stats, Create, Streak or a squish threw Home away (both tabs, every cell's image, face and animation), and going back built it all again in one JS frame before anything appeared.

- **Home stays alive** (`App.js`, `src/components/Freeze.js`, `src/components/ScreenLayer.js`). Once built, Home stays mounted under whatever opens from it. The other screen comes in a `ScreenLayer`, sliding in from the right (`SLIDE_IN` in App: Crib, Create, Achievements, Stats, Streak and the loading screen; the wheel, the streak's intro and the squish screen don't slide). When the slide ends, Home is frozen: `Freeze` suspends it, so it's hidden with `display: none`, doesn't re-render (the squish's coin ticks no longer reach it) and keeps its state, scroll position included. Back unfreezes it with one render. Signing out drops it.
  - While covered, `MainScreen`'s `active` is off: the ad strip keeps its look but drops the real banner, and `SquishiesScreen` reads the date again when it comes back (it used to get a fresh one from the remount).
  - `Freeze` is react-freeze's trick (react-navigation uses it). It was checked under a legacy React root, which this app uses (`newArchEnabled=false`): hidden, no renders on new props, state kept, new props on unfreeze.
- **The loading screen is quick when there's nothing to load** (`LoadingScreen.js`). If the creature's model is already loaded this run (`isCreatureModelReady` in `SquishyToy.js`) or it has none, it skips "Getting Ready": "I AM READY!" for 0.5 s, then a 0.2 s fade. The first time a model loads still gets the full 1.5 + 1 + 0.5 s sequence (longer if the download is slow).
- **Placeholders first** (`src/components/Skeleton.js`). A screen's first frame is its background, header and placeholder blocks with a shared white shine sweeping across them (`Bone`, `BoneCard`). The real content is built after that frame: in a ScreenLayer two frames in, while the slide is already running (`useScreenReady`, or `WhenScreenReady` for the Crib, whose placeholder is `src/crib/CribBones.js`; it waited for the end of the slide until 2026-10-10), and on Home and the Shop a couple of frames after mounting (`useAfterFirstFrame`). That covers Achievements, Stats, Streak (its tiles' entrance now starts when they appear), the Crib, the Squishies lists and the Shop's tabs. Create is a light form and builds at once. The slide runs on the native driver, so the JS build doesn't hold it up; creating the new views on the UI thread can cost it a frame or two, which is the price of the content arriving 0.3-0.6 s sooner.
- **The splash's loading bar** (`SplashScreen.js`) fills on the native driver: a pink pill sliding inside the track over 1.1 s on an ease-out curve. It used to be a JS-set width jumping 7-16% every 110 ms, which stuttered while the JS thread was busy starting the app. The percentage text follows the same curve and re-renders on its own.
- **The real cause of the delay on every tap (found by profiling, 2026-10-08):** the JS thread sat at ~100% even with the app idle on Home. 73% of it was the Shop's once-a-second clock (`setNow(new Date())`), which re-rendered the whole Shop every second, even while hidden behind the Squishies tab (the Shop stays mounted after the first visit). Another 18% was `toLocaleString`, which is very slow on Hermes, formatting every price on each of those renders. Every tap waited in line behind that. Now the three countdowns are `TickingText` (`src/squad/ui.js`), which re-renders one Text a second; the Shop's `day` moves on with a timeout at midnight; and every number on screen goes through `fmtNum` (`src/format.js`, same output as `toLocaleString('en-US')`). Rule: never put a fast timer's state at the top of a big screen.
- **Full run through a new account's tutorial (2026-10-09), profiled tap by tap.** Two more app-wide causes:
  - *The tutorial store re-rendered the whole app.* App's `useTutorial` subscribed to every store change, even after the tutorial was over, and every `TutTarget`'s onLayout measured itself and bumped that store. Mounting Squishies (72 card targets) re-rendered App up to 72 times; one tap measured a 2 s block. Now (`src/tutorial/store.js`): target rects have their own listeners (only the Guide), a target measures itself only while the guide points at it, App subscribes only while the tutorial runs and only to "coarse" changes, and screens read one value with `useTutorialSelect`.
  - *The hold step re-rendered App every 150 ms* (its progress tick): 4 of 6.7 s of JS during the hold. The progress (`holdMs`, `rotateAcc`) is now "volatile": only the Guide's `LiveProgress` draws it, and App reacts only when a goal is reached. Hold measured afterwards: 0.3-1.3 s of JS over 6.8 s, longest block under 0.2 s (debug build).
  - Also: `SquishiesScreen`, `ShopScreen` and `SquishScreen` are memoized (App's re-renders no longer rebuild them), App's `priceOf` is stable, and each tab (Shop's Chests / Squishies / Gems, Squishies' Collection / Star Shop / My creations) stays mounted once opened (`src/components/TabPane.js`), so switching back is instant.
  - Bug found on the way: the creature sheet's SQUISH button was the last thing in its scroll, below the sheet's visible bottom, and the tutorial pointed at it under the banner ad. The sheet's actions are now a fixed footer.
  - In debug builds, React's dev timers (`unstable_now`) account for roughly half of every render's cost on the emulator. Judge smoothness on a release build: `assembleRelease -PreactNativeArchitectures=x86_64` builds one for the emulators (5.5 min).
- **Collection ↔ Star Shop, measured 2026-10-09 (debug, emulator-5556):** about 0.5-0.7 s of JS per switch, of which ~0.4 s is React's debug-only timers (`unstable_now`), plus ~0.15 s on the UI thread for the switch's frame. Every other frame waits 20-40 ms on the emulator's software GPU ("MESA: Failed to open rendernode"), and Home redraws all the time even when idle (175 frames in ~4 s; source not found yet: suspects are the menu button's `SoftPulse` while the streak is hot, and the Shop page's `Bob` chests off-screen once the Shop was visited). The switch also *felt* dead because the pill only moved after the whole screen had re-rendered. Now `src/components/useInstantTab.js`: the segmented switches (`Seg`, `SubSeg`) and the bottom nav (with MainScreen's page slide) light up and start moving on the tap's own frame, and the real switch follows two frames later. Then Collection and Star Shop became two pages side by side (`SquishiesScreen`, `slideTo`): both stay built (Star Shop is built in the background 1.2 s after the Collection), and a switch is only a native slide (to Star Shop: out left / in right; back: out right / in left), started on the tap through `Seg`'s `onPick`. Captured on the emulator: the slide is under way in the first frame after the tap and done within about 0.3 s (it took ~1.5 s before).
- **Every tab is now a page (2026-10-09).** Squishies | My creations (inside Collection, its switch fixed above the pages), and the Shop's Chests | Squishies | Gems use the same side-by-side pages and native slide as Collection | Star Shop. The Shop is built in the background 2.5 s after Home settles (MainScreen), and its pages one at a time a second apart. Links into the Shop no longer remount it (`openKey`). Measured on a settled app (debug, emulator): every switch is done within 0.6 s, with the content already built.
  - The Shop's three tabs took inline callbacks (`onOdds`, `onPick`, `onPack`, `onNoAds`), and the Squishies screen's `wallet()` was rebuilt every render, so every switch re-rendered every tab's content despite `memo`. Now stable (`useCallback` / `useMemo`). Measured afterwards (debug, emulator, settled app): every bottom-nav and Shop-tab switch had JS busy 0.23-0.63 s in total, no block longer than 0.16 s, and its first update 0.2-0.5 s after the tap (adb's own tap delay included).
  - Still slow: the first ~10-20 s after a cold start in a debug build. The profile showed 18.6 s of JS in the first 30 s: Home's first build (72 cells), the background builds and the splash. A tap in that window waits. If it matters on a release build, build the Collection set by set rather than all 72 cells at once.
- **Crib in and out (2026-10-09).** Going in, the Crib read its doc from Firestore on every visit (a network round trip, showing an empty portrait Crib meanwhile), then rebuilt itself rotated once the saved orientation arrived. Now `src/firebase/firestore.js` keeps the Crib's state in memory (`peekCrib`, updated by `saveCrib`) and App preloads it after sign-in, so the Crib builds once, in the right orientation, with no wait. Its build is still one ~1.8 s block in a debug build (the room scene), behind `CribBones`. Inside, the simulation tick (250 ms) re-renders the Crib at least once a second: about 35% of JS in debug, by design.
  - Coming back took a 1.4 s freeze and then a white screen: Home re-rendered all 72 collection cells (each took the whole profile, and the Crib's coins change it), and the off-screen Shop re-rendered its three tabs (2.7 s). Now cells take only what they show (`cellLook`), MainScreen puts the page you're not on to sleep (`Freeze`, once the slide away from it is over; the Shop only after its background build), and the way back is `ScreenLayer`'s `exit()`: the screen slides out at once (380 ms, eased) with Home uncovered under it a frame later, then unmounts out of sight (`goHome` in App, for the Crib, Create, Achievements and Stats). The app's root is sky-blue, so a gap is never white. Timeline on the emulator: the Crib is gone within ~0.3 s, and Home is complete at ~1-1.2 s.
- **How to profile the JS thread** (debug build, Metro running): `curl localhost:<metro port>/json/list` lists the Hermes targets; connect to "Hermes React Native"'s `webSocketDebuggerUrl` and send `Profiler.enable`, `Profiler.start`, wait, then `Profiler.stop`, and sum the samples' self and inclusive time per function. In debug, `unstable_now` (React's dev profiler timers) inflates everything, but the shares point at the right culprit.
- Not done yet: `FlatList` for the Squishies and Shop grids, so off-screen cells aren't built up front.
- Not yet measured on a phone. Measure on a release build (see the top of this file).

## Buttons and back buttons (2026-10-10)

The user: every button that opens something (Settings, Achievements, every back button) reacts late. Measured on emulator-5556 with temporary marks in the app: the root View's `onTouchEnd` timestamp (the native MotionEvent time, the same clock as `performance.now()`), then the time of each step (screen switched, first frame, content built, fade done), plus React `<Profiler>`s around Home, the layer and the sheets. The marks are removed again; the method is below.

What was wrong, and what changed:

- **Achievements re-rendered itself about every 270 ms while open.** Every mounted badge's creature ran its own 3 s mood timer (`mood="cycle"`). A tap landing in that stream waited: the back button's touch reached JS 693 ms late. Now only the centre badge cycles (`live` in `AchievementsScreen`'s `Badge`); the touch reaches JS in 20-60 ms.
- **Every trip re-rendered all of Home.** Going anywhere and back flips Home's `active`, and `SquishiesScreen` made a new `now` for it, which re-rendered all 72 collection cells (150-300 ms each way in debug). `now` only changes on a new day now. Home's header, purses and Squishies | My creations switch are memoized (`Header`, `Purses`, `SubSegMemo`).
- **A hidden Home measured itself as 0 × 0.** Home asleep under another screen is `display: none`, so its `onLayout` handlers stored a 0 size: on waking, the sky background (`CandyBackground`, `SkyBackground`), the outlined titles (`OutlinedTitle`'s text width) and the menu button's spot rendered at 0, then again at the real size (two flickering re-renders). Every such handler now ignores 0 sizes (also `IntroBackground`, `ShineSweep`, `BottomNav`, the Shop's `Seg`).
- **The slide-ins waited for their slide before building** (`ScreenLayer`'s `useScreenReady` flipped at the end of the 260 ms slide), then faded in over 320 ms. Now the content is built two frames in, while the native slide runs, and the fade is 160 ms.
- **Back started slow on purpose** (an ease-in over 380 ms, so Home had time to draw under it). Now Home is uncovered in the same render as the tap (it's cheap now: 10-20 ms in debug) and the layer slides out fast at first (280 ms, ease-out), like the way in. The streak screen's close now uses the same slide (it swapped straight to Home).
- **Settings was a `<Modal>`**: a new Android dialog window on every open, the whole sheet built from scratch (~280 ms) and rendered twice more (~310 ms) before it moved, then thrown away on close. `SettingsSheet` is now drawn in the app's own tree, built once (in the background 4 s after start) and kept; opening only slides it up on the native driver. Its contents (`Body`) are memoized, the Android back key closes it (`BackHandler`), and the feedback popup inside is still a Modal. The three sheets (`SettingsSheet`, `RemoveAdsSheet`, `DailyChallengesSheet`) are memoized: they all re-rendered with App on every screen change.
- **The menu built its rows on every open** (~270 ms in debug) and dropped them on close. They're built once (in the background 3 s after Home is up) and kept; `HomeMenu` and its `Row`s are memoized.
- Also: `AchievementsScreen`, `StatsScreen` and `StreakScreen` are memoized (App re-renders while they're open); Achievements mounts 3 badges either side of the centre instead of 5, and only the centre badge and its neighbours carry the large SVG glow.

Numbers, release build on emulator-5556 (x86_64), ms after the finger lifts: when the screen answers / when its content is drawn / when it's done.

| Button | answers | content | done |
|---|---|---|---|
| Achievements (trophy) | 140-160 | ~520 | ~680 |
| Stats (menu) | 210 | 550 | 710 |
| Streak (menu) | 210 | 850 | 950 |
| Crib | 130 | 550 | 1130 |
| Create | 240 | 360 | 360 |
| Settings (menu) | 105-120 | — | slide 280 |
| Settings close | 80-110 | — | — |
| Shop / Squishies tab | slide on the tap | 250-280 | — |
| SQUISH (loading → squish screen) | 140 | 1430 (squish screen) | — |
| Every back button | slide starts on the tap | Home under it at once | — |
| Squish screen back | 360 | — | — |

Before, in the debug build on the same emulator: Achievements done at 2.9 s and back at 2.0-2.2 s, Settings' first frame at 0.9-1.3 s, the menu 0.3-0.5 s, Stats and Streak 2.4-2.8 s.

- **Judge on a release build.** In debug, React's dev timers are about half of every render; the same taps took 2-4× longer there.
- **The emulator was overloaded during this:** 4 GB with 80 MB of swap free and 89% system CPU, the app at 956 MB after two hours of debug use, median frame 48 ms. Restart the app (or `adb reboot`) before measuring.
- **Still slow:** the Crib's scene (~1 s in release), Streak's day tiles (~0.6 s), the first Shop visit after launch (a 2.6 s build in debug), the squish screen's "I AM READY!" step (by design), and the native side of creating many SVG views (badges, glows): the same in debug and release.
- **How to measure again:** a root `View` with `onTouchEnd={(e) => (up = e.nativeEvent.timestamp)}`, `console.log` of `performance.now() - up` at each step and in the next `requestAnimationFrame`, read with `adb logcat -s ReactNativeJS`; `<React.Profiler onRender>` (debug only) for which subtree re-rendered and how long. Drive with `adb shell input swipe X Y X Y 80` (a finger-length press). The emulator's `screenrecord` is no use for this: it captures about 10 fps.

## Chests: buying and opening (2026-10-10)

The user reported a long wait after buying or getting a chest, and in the opener the first tap answered but the 2nd and 3rd came late and the motion stuttered. Found with Hermes CPU profiles over Metro (debug, emulator-5556) and checked on a release build with touch-timestamp probes.

- **Every tap rebuilt every animation node on screen.** `ChestOpener` re-rendered on each hit (HP, chips, numbers), and each flying chip (`Fx`), the chest's transform and the ring made their `interpolate`/`Animated.multiply` nodes in render. With the native driver each new node is created, connected and dropped over the bridge, one call each. With about 48 chips alive, three taps 400 ms apart kept the JS thread busy for the whole 4 s window (`createAnimatedNode`, `dropAnimatedNode` and `__startNativeAnimation` at the top of the profile). Now the animated parts are memoized pieces (`ChestStage`, `HpBar`, `Foot`, `Header`, `Ring`, `Flash`, `Word`) whose nodes are made once. A hit's chips and number are one group (`Burst`) driven by ONE native timing. Finished groups are dropped when the next group is added, not by a re-render per chip. Same 3 taps: 1.4 s busy, 2.6 s idle (debug), and node creation went from 44 samples to 1.
- **Multi-step motion went through JS.** `Animated.sequence` hands back to JS between steps, and `Animated.loop(Animated.sequence(…))` is run from JS (only a loop of a single timing runs natively). So the squash, shake, flash, burst, idle wobble, bob and tremble stalled whenever JS was busy, which is the stutter. Each is now a single timing (or a native loop of one) read through a keyframed interpolation (`keys`, `curve` in `ChestOpener.js`). The tremble used to be a 50 ms `setInterval` of `setValue`s; it's now a looping jitter path scaled by `tremAmp`. Rule: **in anything that animates while the user taps, never use `sequence`/`loop(sequence)` with the native driver.** The Reveal Show's twinkles had the same loop; its particles (`Twinkle`, `Confetti`, `ConfettiBit`, `Firework`) are memoized too, because its beat re-renders the show every 0.5-1 s.
- **Crack stages swapped the image source** and waited on decoding. All six stages are laid out up front (only the current one is opaque).
- **The server's answers re-rendered the Shop mid-smash.** `openChest` (and the purchase before it) change the profile about a second after the first tap, which re-rendered all three Shop tabs under the opener: the 2nd/3rd tap delay. The Shop's content now sleeps under the opener (`Freeze`) and catches up 1.3 s into the Reveal Show (`onRevealing`), not on the YAY tap (where it cost ~2.5 s in debug). OPEN ANOTHER puts it back to sleep in the same render. The opener draws on the Shop's own sky instead of a second full-screen `CandyBackground` (one GPU layer and one layout pass less).
- **Buying waited on the server, twice.** The "got" sheet only went up after the `squad` Cloud Function answered (a round trip, more when it's cold). Also the Shop's `busy` flag was state that `run` depended on, so every move re-rendered every card in the Chests and Gems tabs twice (a single 2 s block in debug). Now the sheet goes up on the tap and the move finishes behind it. What the player can't afford is caught locally first, and a failure takes the sheet down (broke sheet or toast as before). OPEN NOW waits for the purchase (`waitFor`) before rolling. `busy` is a ref. `GemsTab` takes `firstBought`/`adsFree` instead of the whole profile.

Release build, emulator-5556, ms from the finger lifting (or touching, for chest taps) to the handler or first frame:

| Step | Release |
|---|---|
| Buy → "got" sheet | 106 |
| OPEN NOW / My Chests → opener drawn | 286-308 |
| Chest taps (10 a chest, 0.3 s apart) | 5-43, 96-100 on the bursting tap |
| YAY → Shop back, already caught up | < 500 |

Not measured on the A15. The Cloud Function's cold start still sets how soon the reveal can start after the burst (the burst waits for the roll), but the roll starts on the first tap, so it is normally back before the chest breaks.

### The v6 chest smash: no empty screen before the chest (2026-10-28)

The user saw "a screen" between tapping Open and the chest. The smash (`ChestSmash`, a WebView on `android_asset/chest/host.html`) came up at once with `chest: null`, but the page only drew the chest on `chestHost.start`, which waited for both the page load (a fresh WebView each open, ~430 KB of chest scripts) and the `squad` Cloud Function's answer. Until then it showed the page's bare dark purple with empty pills (the tier label, HP bar and hint, no text).

- The app knows which chest it is at the tap (the bought group and size; free = welcome group or `lineup(day, hidden)[0]` Common; ad = `lineup[1]` Rare; deal = `lineup[0]` `GDEAL.size`, the server's own picks). The Shop passes it as `first`, and the page starts that scene at once in phase `wait`. `chestHost.fill({ final, reward })` brings in the answer. A first tap while waiting is held and played when it lands, so the upgrade roll is never guessed. If the server's group or size differ (a day change at midnight), a normal `start` replaces the scene.
- The smash stays at opacity 0 until the page posts `shown` (two frames after `start`), so the WebView's own load shows the Shop rather than an empty page. The Shop freezes only after that. A 2.5 s fallback shows the smash anyway in case `shown` never arrives.
- `host.html` is an Android asset: a Metro reload doesn't pick it up, the APK has to be rebuilt.

## Taps that wait, slow backs, long loading screens (2026-10-28)

The user: long loading screens, buttons that answer seconds late, and going back "freezes for a few seconds, then takes me back". Measured on the Galaxy A15 (USB) with a temporary probe: the root View's `onTouchEndCapture` timestamp, a `requestAnimationFrame` loop logging every frame over 50 ms, marks in `ScreenLayer` and `React.Profiler`s around Home, the Shop and the layer (`adb logcat -s ReactNativeJS`). The CPU profiler over Metro stopped answering after an app relaunch (targets listed, commands timed out); the probe was enough. The user had been judging a **debug** build again.

Why, in one rule: **on Android (legacy arch) a native-driver animation started in a handler only starts once that handler's render has been committed** (NativeAnimatedModule runs its queue at the end of the UIManager batch). Every screen that was built in the same render as its slide held the slide, and every frame, until the build was done. A big subtree created at once (or shown again after `display: none`) also stalls the UI thread, so a slide that does start still stutters.

What changed:

- **ScreenLayer** (every screen over Home): the content is built when the slide-in is over (`useScreenReady`); during the slide only placeholders, which are light. Building during the slide (since 2026-10-10) made the UI thread create the views mid-slide: a 260 ms slide took 0.6-0.85 s. **Back** starts the slide-out first and uncovers Home in the next task (`setTimeout(onUncover, 0)`); uncovering first put Home's render (and the game screen's own re-render) in front of the slide.
- **Squishdoku, Squish Sort, Squish Stack and the level road** sit in `WhenScreenReady` with `ScreenBones` (candy sky, header, `ViewBones` of a kind: `hub`, `map`, `game`, `list`) and are memoized, so App's renders (Home waking on the way back) don't re-render them.
- **Inside the games** (hub → map → level, Blitz): `useViewSwitch` + `ViewSlot` (src/components/ViewSwitch.js) start the switch's spring and draw the new view's placeholders on the tap, build the content two frames later and fade it in. The **level map stays built, asleep, under a level** (`KeptView`), so QUIT / leaving a level is instant (it was a full rebuild: 0.75 s render + 0.8 s of view creation in debug).
- **Long lists are built a few items a frame** (`useProgressive` in Skeleton.js): the level maps (nearest the current level first) and the Squad grid.
- **Lobby** (`useSettled`): the games sheet (2.5 s after the lobby settles), the Squad screen (4.5 s) and the selected creature's squish model (6.5 s) are prepared in the background. The sheet and the Squad are kept and asleep while closed (the Squad sleeps only once all its tiles are built: `onBuilt`), and the lobby is hidden (`display: none`) while the Squad covers it: idle on the Squad went from ~15 fps (64 stalls in 4 s, RenderThread at 83 %) to no stalls. PLAY's game cards open their game on release (they waited 160 ms for the squash, then the lobby 200 ms more).
- **MainScreen's off-screen tab** sleeps with `Hold` (Freeze.js), not `Freeze`: it stays laid out beside the page shown, deaf to new props from above. Waking the Shop from `display: none` was a 0.3-0.7 s UI-thread re-layout in the middle of its slide; now 0.06-0.26 s of small stalls, and idle frames are unchanged.
- **Banner ads** come 700 ms after an `AdStrip` goes live (a banner is a WebView of its own): it was a 0.3 s stall as Home came back.
- **Squishdoku's level buddy** (a rig WebView) is made 0.7 s into the level, not with the board; its still shows until then as before.
- **Loading screens**: the squish game's beats are as short as reads well (dots for as long as the model takes, 0.6 s at least, then 0.9 s; quick path 0.6 s), and the lobby's preload makes the quick path the usual one. **The splash finishes as soon as the app is ready** (signed in or not, profile and catalog here), 1.5 s at the least, 10 s at most (user ruling 2026-10-28; it was a fixed 10 s).

Galaxy A15, release build, ms after the finger lifts (frames over 100 ms in brackets, total):

| Tap | Before (debug) | After (release) |
|---|---|---|
| Splash | 10 s + | hands over at 2.8 s from the first frame |
| SQUAD | 3.6 s before anything moved | slide at once; one 0.3 s hitch mid-slide |
| PLAY (games sheet) | 0.5 s, then 1.3 s choppy | smooth (0.15 s of small stalls) |
| A game from the sheet | screen at 1.1 s | screen at 0.12 s, slide done 0.44 s, content after |
| Regular → level map | 0.86 s, then 0.6 s | placeholders at once, nodes fill in ~0.75 s |
| QUIT a level → map | ~1.5 s rebuild | instant (one 0.13 s frame) |
| Every back button | slide waited 0.06-0.3 s on Home's render | slide starts ~0.03 s, done ~0.3 s |
| Achievements / level road | first frame 0.27-0.58 s, slide 0.6-0.85 s | screen at 0.13-0.17 s, slide clean |
| PLAY → Squish | squish screen at 5.3 s | at 0.86 s |
| Shop ↔ Squish tab | 0.3-0.7 s stall in the slide | 0.06-0.26 s |

Follow-ups the same day:

- **The Squad screen ran at ~25 fps while open, before and after the above.** `dumpsys gfxinfo … framestats` put it in RenderThread's *sync* stage: ~66 ms a frame against ~5 ms of GPU. With the grid's tiles taken out it was 1.8 ms. Every frame of the live hero, HWUI re-prepared the pictures of all ~80 tiles, scrolled out of sight or not. Fix: `removeClippedSubviews` on the grid's ScrollView (sync 1.9 ms). Check a screen that has something live with `framestats` and a median of SyncStart → IssueDrawCommandsStart; anything over a few ms is the tree, not the GPU.
- **The Squad's tiles** draw their floor shadow from one shared PNG (assets/squad/tile-floor.png, the same gradient) and their small lock in plain views: ~150 little SVGs, each drawn on the UI thread, made the Squad's every showing a 0.3 s hitch.
- **Chromium's "tile memory limits exceeded, some content may not draw"**: a rig WebView made off screen and then put to sleep (the Squad's hero in the background build) never drew; the hero spot stayed empty. The hero's rig is now made the first time the screen is up, after its slide, with the creature's still until it has drawn. `RigCreature` ignores 0 × 0 layouts (a hidden screen's).
- **Tried and dropped:** keeping the closed Squad laid out off screen (`Hold`) and the lobby under the open Squad at `opacity: 0` instead of `display: none`. Both made the phone work through the hidden screen every frame: the lobby went from 1 to ~40 stalled frames in 4 s. `display: none` (Freeze) is right for something hidden under or below; `Hold` only for a page beside the one shown (MainScreen's tabs), where it measured fine.
- **Sound players** (`sfx.preload`) are made one every 40 ms instead of in one burst (a Squishdoku level made 16 ExoPlayers on the main thread as its board came in). Squishdoku's sound budget is 30 (was 18, less than a level plays, so every level made some again) and its level sounds load while the menus are up.
- **Creature art prefetch at startup** runs 6 at a time (App.js `PREFETCH_AT_ONCE`); all at once was hundreds of bridge calls as the app started.

- **Forever loops run on the native side** (src/components/idleLoop.js: `usePingPong`, `useKeyLoop`, `phaseLoop`): a linear phase looping natively, read through keyframes of the curve. `Animated.loop(Animated.sequence(…))` is restarted from JS at every step: each `Twinkle` (14 on every sparkly background), `Bob`, the level maps' current node, a placed Squishdoku creature's breathe and sway, the HUD's glow, pulse and pip, Sort's wobble and pulse, Stack's seat glow and Squishdoku's `Pulse`/`Rock` all woke the JS thread every half-period. About 30 other `loop(sequence)` uses remain in screens not on these paths (Crib, Achievements, Daily Spin, Shop Deals, CandyButton…); convert them the same way when touched.
- **The games sheet** hides the lobby parts it covers (the creature, SQUAD and PLAY) once it's all the way up (`onUp`), and shows them again as it starts down: the phone drew them under it every frame (open sheet ~60 → ~43 ms a frame).
- **The level road** renders 5 rows first (was 12), then 4 a batch over a smaller window, and its rows' lock is plain views (was an SVG each).

- **Home under a covering screen** (App.js) is no longer hidden with `display: none` (Freeze): hiding and showing the Lobby + Shop's thousands of views cost one 0.4-0.65 s frame (debug) as each screen came in and again on the way back. It's now held (`Hold`: not re-rendered), moved out of sight in a clipped container, and `LoopsOn` (idleLoop.js) turns off for it: its native loops stop and **the Lobby takes its live creature out** (`display: none` on the rig's one view). That WebView, even paused and out of sight, cost ~3.5 ms of RenderThread work in *every* frame of whatever was on screen; MainScreen turns `LoopsOn` off for the tab you slid away from too, so the Shop and the games sheet no longer pay for it. Exception, the Crib: with Home held under it, each Crib frame cost ~150 ms (below), so the Shop page is truly hidden there.

**How this was measured, and a correction.** `dumpsys gfxinfo … framestats` keeps only the last 120 frames (about 1.3 s at 90 Hz), and its newer "Janky frames" count missed these frames too: the earlier "no janky frames" checks in this section missed the frame where a screen's content appears. The reliable way is a system trace of every main-thread frame after a tap: `adb shell atrace -t 6 -b 32768 gfx view input > trace.txt`, then the `Choreographer#doFrame` slices of the app's main thread (`B|<pid>|…` / `E|<pid>` lines; strip the `\r`). A frame's `animation` phase is where React Native creates and updates views.

Galaxy A15, release build, system trace of every main-thread frame in the 3-4 s after the tap (2026-10-28):

| Tap | Slowest frames after it |
|---|---|
| SQUAD / its back | 130 ms (the tap's own frame: the slide starts on it) / 80 ms |
| PLAY (games sheet) | 67 ms |
| Squishdoku from the sheet / Regular → level map / a level | 96 / 89 / 75 ms |
| pause / QUIT | 50 / 59 ms |
| Every back (map, hub, Achievements, road, Crib, squish) | 31-59 ms |
| Achievements / level road | 73 / 66 ms |
| Shop tab / Squish tab | 28 / 22 ms |
| Crib | 122-124 ms, after its slide (was 0.2-0.23 s) |
| A room in the Crib | 77-86 ms, under the room flash (was 120-170 ms) |
| The first Shop tap after a Crib visit (the Shop built again) | 109-134 ms worst (was 258), the rest spread out |
| PLAY → Squish | 143 ms (the squish stage starting, 1.2 s in, under the loading screen) |

Idle, traced, frames a second over 3 s (2026-10-28, final release build): Lobby 82, Squad 81, games sheet 68, Squishdoku 90, level map 82, a level 60, Achievements 78, Shop 76, Crib 89, squish 76; no idle screen had a frame over 34 ms. (`gfxinfo`'s IntendedVsync → FrameCompleted is a frame's latency, not its interval: the "~40-45 fps" reported for the games sheet and the Shop earlier was read off it and was wrong; they ran ~55-70 fps. The games sheet's cards now cache their still faces as a texture with their moving picture over them, `renderToHardwareTextureAndroid`: with the pictures inside, Android re-drew all the cards every frame.)

**Why the Crib is the exception.** With Home held under it, the Crib's frames took ~150 ms: a system trace showed RenderThread uploading ~175 textures *every frame* (prepareTree pins the images of every view in the tree, off-screen ones too, and the Crib's pictures plus the Shop's, 99 chest pictures of ~87 MB decoded, don't fit Android's texture cache together, so they evict each other). Without the Shop the Crib idles at ~23 ms a frame. So the Shop is let go (unmounted) once the Crib has slid in (App `SHOP_AWAY_UNDER` → MainScreen `ShopAway`) and built again only when its tab is next tapped, behind its placeholders. Hiding it with display: none instead cost ~0.35 s frames as the Crib came in and again after the way back; hiding all of Home, 0.4-0.9 s (debug). The Shop builds in pieces now: the chest carousel builds only the card in view and its neighbours (`near`; the rest are empty cards until a swipe brings them near), the Deals and Gems pages a part a frame (below). The Crib builds its scene a couple of frames after its frame and room dock, and its creatures a few a frame.

Last round (same day):

- **The Shop built again after the Crib.** Its 0.25 s frame wasn't the tap: it came 1.5 s later, when the Shop built its Deals page unseen (the streak and two offers in one frame), and the Gems page 1 s after that. Every page is built a part a frame now: the Chests tab (the tiles and the deal, then the carousel, then the rest), the Deals (the offers on top, the streak, then one offer a frame) and the Gems (one pack a frame, then the swaps). Only the page shown has placeholders. When the Shop isn't built yet as its tab is tapped, its page slides in as placeholders (`ShopPageBones`) and the Shop is built once it's in, fading in over them (MainScreen).
- **The Crib** comes in a part every other frame (`useEveryOtherFrame`, Skeleton.js: one frame apart, React Native can still run both parts' view batches in one frame): its HUD, then the room dock, then the room, itself in three parts (the backdrop and the night's tint, then the furniture, then the front and the creatures, three a frame). The room scene is keyed by the room, so a room switch builds the new room the same way, under the flash. And **the room-switch flash** is two pictures (assets/crib/flash-*.png, tools/crib-art/flash.py) instead of a full-screen SVG. react-native-svg draws every SVG in software on the UI thread the first time it's drawn, and this one (mounted, unseen, from the Crib's first frame) was ~40 ms of it.
- **The Lobby's creature after the squish game**: its WebView, kept hidden through the squish stage, came back blank (Chromium's "tile memory limits exceeded"). The Lobby lets the WebView go while a screen covers Home (App `RigAway`) and makes a fresh one once Home is back, showing the creature's still until it has drawn.

Still the slowest, each one frame of ~0.1-0.15 s once the screen is already up: the SQUAD tap (its grid shown again: react-native-svg throws away and redraws its pictures when a view's size changes), the Crib (~0.12 s), the Shop built again after the Crib (~0.11-0.13 s) and the squish stage starting (~0.14 s, under the loading screen). A debug build is 2-4x slower than all of the above.
