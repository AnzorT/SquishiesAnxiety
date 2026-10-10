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
