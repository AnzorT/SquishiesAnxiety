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

## The landscape menu, the Game Park and the chest smash (2026-11-14)

The user: the whole app feels unoptimised; the chest room drops frames almost every time, worst while smashing; the new Main Menu runs at "like 5 fps". Goal: smooth on the weakest phone the app supports (minSdk 23).

**How it was measured.** The Galaxy A15 wasn't connected, and the Pixel_8_Pro emulator swaps hard (it thrashes even after a reboot), so its fps only says "better or worse". The menu, the park and the chest are WebView pages, so they were measured in Chromium as a weak phone: SwiftShader (software GPU), the CPU slowed 4x, the A15's landscape size (832 x 384 at DPR 2.8125). `tools/perf/webview-bench.mjs` does it (how to run it is at the top of the file); `EARLY=1` slows the CPU from page load, so the pages' own frame-rate guards see a slow phone, as they would on one. Use it to compare before / after on one machine, then check a release build on a phone.

Weak-phone stand-in, fps (before → after):

| Scene | Before | After |
|---|---|---|
| Main Menu, rainy / snowy | 29 / 36 | 59 / 58 (sunny: 60) |
| Game Park (after PLAY) | 16 | 56-57 |
| The house | ~35 | 47-54 |
| Chest, idle | 31 | 60 (full quality) |
| Chest, smashing (9 taps) | 17 | 40 (switches to lite mid-smash), 50 (lite from the start) |

On the thrashing emulator the old menu measured 5.8 fps (the user's "5 fps") and the new one 13-20.

### Main Menu and Game Park (webgame)

- **The scene is drawn still.** The designer's scene is one full-screen SVG with blur filters, and its trees, smoke, lights, clouds and rain were SMIL animations inside it, so every frame repainted the whole SVG. `app/menu.js` (section 0) strips the `<animate…>` tags from the scene and the park (`SquishMenu.still`, patched into main-menu.js `draw()`; `weather()` in main-menu-scene.js returns nothing in the app).
- **Only the weather moves**, re-made as a handful of shapes on one layer moved by transform with the Web Animations API (the compositor runs it, no repaint): rain 140 streaks, snow, or 3 birds when sunny. Hidden while the house or a page covers the menu (`.sq-away`), and on the lowest quality step (`.sq-lite`).
- **The HUD stopped animating non-stop.** Every continuous CSS animation (PLAY's glint and pulse, the crest's wings, star, sparkles and sweep, glows) kept a GPU layer of its own, and a weak GPU pays for every layer every frame: taking them out doubled the emulator's fps (16.8 → 31.3). They now play as a short flourish every 5.2 s (`.fl` on the crest, then the PLAY card 1.3 s later); glows and drop shadows are still; the few left animate transform or opacity only.
- **The creatures** (rive-rig.js rebuilds and redraws its SVG every frame, the costliest thing left) are each on their own layer (`will-change: opacity`, patches.mjs), not drawn at all while hidden (`sqHold`: under the house or a page), and **`app/perf.js` (`SquishPerf`)** lowers their rate while the page can't hold ~55 fps: every other frame, then every third, kept for the session. It starts judging 4 s after the page has loaded: at first it counted the page's boot (8-14 fps even on a fast machine), which put every phone at every other frame for the session; and the menu numbers above were taken that way (re-measured with `EARLY=1 SETTLE=8` after the fix: rainy 59 at every other frame, snowy 58 at every frame; a fast machine stays at every frame). Phones with 2 GB of memory or 2 cores or fewer start at every other frame.
- **Smaller things:** the app root is `position: absolute` (a fixed element is a full-screen layer of its own); the door's white veil is `visibility: hidden` while at opacity 0 (it was a full-screen layer even when see-through).

### The chest smash (tools/chest/host.html → android/app/src/main/assets/chest)

- **The canvas is capped at 1.5x the CSS size** (the engine asked for 2x; the A15's screen is 2.81x): about a third of the pixels. **Lite** is 1x with half the particles. A watcher now runs **for the whole time the chest is up** (a second under ~48 fps twice in a row, or one under ~35 → lite); it used to look at the first ~1.5 s only, which the idle chest often passed, so the smash then ran at full quality. Phones with 2 GB or less / 2 cores or fewer start in lite.
- **The chest's picture is cached.** `Stage.renderLayer` drew every part, dent, crack and hole as vectors into an off-screen canvas every frame, though most frames only move the chest (wobble, hop and shake are transforms). It's drawn again only when something on it changed (a hit, the damage, dents, cracks, holes, torn parts, a hinge's swing, the hit flash, the burst, a charge-up, a spinning gradient, the scale); `resize()` resets it. In lite, the soft changes (swing, flash, burst, charge, spin) update it every other frame, and the hard ones still update at once. Idle chest script time: ~600 → ~40 ms a second.
- **No `androidLayerType="hardware"`** on the chest's and the game's WebViews (ChestSmash.js, GameScreen.js): their content changes every frame, so a hardware layer only added an off-screen copy of the whole WebView each frame.

### The new look's React Native kit (src/royal)

- **Plaques** (every button, pill, card and panel) drew their fill as an SVG; react-native-svg draws in software on the UI thread, so each screen with dozens of them took a long first frame. The fill is now native `expo-linear-gradient` views (`Fill` in Plaque.js); the page background (`PageBg`) is a native gradient and one picture (assets/royal/rays.png) instead of a full-screen SVG.
- **The fine diamond pattern on the velvet and the wood grain were dropped**: Android's `resizeMode="repeat"` drew the tile once instead of tiling it, and an SVG pattern would bring the software drawing back. Visible on close look; put back with a pre-tiled picture per size if wanted.
- **The gold glow and PLAY-style glint** are native loops (`usePingPong` / `useKeyLoop`, idleLoop.js) that also stop under a covering screen; they were `loop(sequence)`s restarted from JS at every step. The glow is a texture of its own (`renderToHardwareTextureAndroid`), so the pulse only fades it.

### FPS counter for testers (2026-11-14)

The tester-only FPS pill (`src/components/FpsCounter.js`, Settings → Options → FPS counter, also in the Test wallet; kept across launches) used to count only the app's JS frames, which stay at 60 while a WebView page struggles. Now the menu page (`SquishPerf.meter`) and the chest page (`chestHost.meter`) count their own frames while it's on and send them every half second (`src/components/fpsMeter.js`); the pill shows the page on top (**CHEST**, then **MENU**; **LITE** when that page has lowered its quality) with the app's own rate beside it, or **APP** on the other screens. It sits at the bottom, right of centre, and lets taps through. Off: no page cost at all.

### Memory: the house moves built on demand (2026-11-14, later)

The user saw low fps on the Pixel_8_Pro emulator even with the release build. The emulator was out of memory: swap full, 342% of its 400% CPU in the kernel, the game's WebView renderer at ~600 MB. Measured in Chromium, the **menu page held 292 MB of live JS after a GC, while loading only 3 MB of files**: the design's `house-moves.js` builds every creature's own furniture moves (sit, lounge, bed, water, play, games, cooking…) as keyframe tables at page load, for all ~86 creatures (~2.7 MB each, 229 MB), though a player has a handful in the house.

`SquishLazy` (webgame/app/perf.js, two patches in patches.mjs) holds each creature's builder calls and runs them, in their order, the first time that creature is drawn (`need(key)` before its frame in rive-rig's loop, and in `poseAt`). The shared defaults are built at once. Each builder ends by noting the creature in its table (PROF, BED, WAT, PLY, BB, CX), and the later creature files loop over `Object.keys(PROF)`, so a held call notes the creature there at once; without that, the bed / bath / play / game builders skipped every waiting creature (caught by the check below).

- **Same result:** with Math.random seeded, the old and the new page end with the same 14,626 states, and all 113 creatures' tables are identical (JSON) once asked for.
- **Menu page JS heap: 292 → 49-52 MB**; in the house with five creatures 78 MB.
- **Menu ready (4x CPU slowdown): 6.9 → 2.4 s.** A creature's first appearance costs one build of ~55-65 ms at 4x (a few frames, once).
- Still built for everyone at load: `pet-anims.js` flavoured copies (~32 MB), the next candidate.

### The chest remembers a slow phone (2026-11-14, later)

Each chest opening loads its page afresh, so on a slow phone every smash began at full quality and stuttered until the watcher stepped down. Now (tools/chest/host.html, localStorage shared with the menu page; `domStorageEnabled` on ChestSmash's WebView): a switch to lite after the first measured second (the first can be slow from loading art), or the menu's guard having stepped its creatures down (`sq.perfStep`), starts the next chests in lite. Forgotten after 14 days, so a phone is tried at full quality again. The menu's guard also ignores single stalls over a second (a page loading), so it doesn't step down for those.

### The development setup (2026-11-14, later)

What made the emulator's numbers low, measured: the Android 17 image's NFC service restarting in a loop (no NFC HAL; `adb shell svc nfc disable` stopped it), the sensors HAL at ~1/3 of a core, swap full, and on the PC Metro at ~2 cores in its file watcher, working through the events of `android/app/build` after each gradle build (thousands of files it never needs). `metro.config.js` now blocks the build outputs and generated copies (android/app/build, android/build, android/.gradle, android/app/.cxx, android/app/src/main/assets, webgame/test/out, webgame/.cache): restart Metro to pick it up. (Blocklist patterns must have the same regex flags as Expo's default, or Metro can't combine them and the release bundle fails.) Release builds install over debug ones keeping the login (both use the debug keystore): `./gradlew assembleRelease -PreactNativeArchitectures=x86_64,arm64-v8a`.

Still open: a real-phone measurement (release build, Galaxy A15 and a 2 GB Android 6-8 phone if one is around); the rig creatures remain the main cost on the menu; the smash is still script-bound in its busiest second (debris and particles).

## 60 fps everywhere, loaders on time, the old UI gone (2026-11-20)

The user's list: screens at 3-5 fps, loading screens heard before they were seen ("half way done"), flicker, a white
strip under the house, the chest list coming back on page 1 with its dots at the end, a new player getting the old UI
and tutorial. Measured on the Galaxy A16 (SM-A165F, Helio G99, 90 Hz panel, release builds).

**How it was measured.** `dumpsys SurfaceFlinger --latency <app layer>` once a second (present times of every frame the
app's window showed: nothing in the app is touched, unlike gfxinfo, which stalls it ~5 s). An idle screen draws nothing,
so a long gap between two taps is not a slow frame: read p95, not max. `atrace gfx view input sched` for where a frame's
time goes (UI thread `Choreographer#doFrame`, RenderThread `DrawFrame`). `debug.hwui.show_dirty_regions` to see what
redraws. Screen recordings cut into timed contact sheets for loaders and transitions.

**What was found and changed:**

- **90 Hz.** The phone's panel runs at 90 Hz, so a frame has 11.1 ms. Most screens needed 12-15 ms on the RenderThread:
  every frame missed one vsync and waited for the next (22 ms), and screens alternated 11 / 22 ms: "45-60 fps" with
  constant stutter (Settings, the games' hubs and maps, the house). MainActivity asks for 60 Hz
  (`preferredRefreshRate = 60`; Samsung shows apps only the panel's top mode, so a mode id alone did nothing) and turns
  off the touch boost on Android 15+. Same resolution, 16.7 ms per frame: Settings, Stats, Achievements, the Shop, all four
  games' hubs, maps and levels, Squish Time, the intro and the menu now run at a flat 59.7-60 fps.
- **The menu was rebuilt on every return.** The Main Menu's WebView was unmounted under every other screen and loaded
  again on the way back (~3 s of blank brown, then "Loading your house"). It now stays alive under every screen, asleep
  (App.js `menuAsleep` → GameScreen `asleep` → the page's `sleep` message: nothing drawn or computed) and at opacity 0;
  it wakes as the screen above starts to leave, exactly where it was (Game Park, Characters …).
- **Loaders that ran before they were seen.** Squish Time's "Getting ready" now starts its beats and its sound once its
  first frame is painted, and the squish stage is built under it in the same layer (there was a bare frame between the
  two). The menu pages' loaders (Characters, Heading home, Level Pass): webgame/README.md "Performance, 2026-11-20".
- **Placeholders flashed the old design.** Every game screen opened through the old light-blue sky with portrait
  placeholder blocks before its wooden hub appeared: ScreenBones / ViewBones are now wood-toned, landscape, on the screen's
  own background. From a level map into a level, the room behind the map is kept up under the level until the level has
  drawn its own (WorldBg `useRoomUnder`), instead of flashing the bare page between them.
- **Every React Native screen was 48 dp short of the right edge.** React Native's window size left out the navigation
  bar's strip although the app hides the bar and draws over it (748 dp vs the root's 796). App.js sets the window size from
  the root view's real size, so the Shop, Settings, Stats, Achievements … are centred and fill the screen.
- **Idle loops that went back to JS at every step** (`Animated.loop(Animated.sequence(...))`: the wheel's bulbs, the
  streak's flame, the vault loader and others) are single native loops (idleLoop.js), so they keep moving while JS is busy.
- **The chest list** (Shop → Chests): coming back from a chest smash, the list remounted on the first group while the
  arrows still thought they were on the page you left (a 0 width while hidden under the smash). Zero sizes are ignored,
  the list starts on the page it's on, and the page dots are gone (the user's request).
- **The old UI** (classic Home / Lobby / Shop tab / Squad, the old Crib, the old settings sheet, Create-a-squishy, the
  guided tutorial that kept new players there) and ~60 files only it used are deleted; the packages and permissions only
  they needed are gone too (image picker, document picker, image manipulator, Firebase Storage; storage and microphone
  permissions). A new player now starts on the menu. Smaller APK, smaller JS bundle, less to parse at launch.
- **The house's creatures took turns.** At the frame-rate guard's step 2 (webgame/app/perf.js) every creature was
  drawn on one frame and none on the next: the house's 4-5 creatures together took ~25 ms on the A16, so those frames
  missed the 16.7 ms vsync and the house ran at ~35 fps unevenly. Now 1/step of them is drawn each frame (each still
  every step-th frame, with its own time step), the house starts at step 2, and a phone with room to spare (all of them
  under 7 ms a frame for 3 s) goes back to every frame. House: 33-35 → 59.5 fps from the first visit.
- **First opens of Characters and the Level Pass.** Their slowly turning rays were CSS conic gradients under a radial
  mask, ~1960 px layers the WebView's GPU thread took up to 1-2 s to make the first time, drawing no frame meanwhile; they
  are now drawn once into a canvas that the GPU turns. The loaders start their motion and sounds only once frames are
  actually reaching the screen (`SquishPerf.steady`), and these pages don't fade in (a fade frozen part-way was a
  see-through ghost over the menu). What's left of a first open is ~0.5 s of the GPU making the page's tiles, once per
  launch; later opens are instant.

- **Squish Time's way in** (PLAY → "I AM READY!" → the stage). Building the stage under the loading beat held the UI
  thread for 0.2-0.3 s (~230 native views, and every react-native-svg on it painted in software: the full-screen sky,
  the pooled "+N" coins' outlined titles, the hint hands), right while "I AM READY!" was popping: it froze mid-pop.
  The sky is now native pieces in one hardware layer (a native gradient, small radial bitmaps scaled and tinted, the
  dot grid as bitmap blocks: src/squad/SkyBackground.js, assets/squad/sky/make-sky.mjs; `resizeMode="repeat"` drew a
  single tile on Android, so no tiling). And the beat waits: LoadingScreen `hold` keeps its first frame still until
  SquishScreen reports it is built and drawn (`onShown`), then pops, plays its sound and fades. ~0.3 s longer on a
  warm open, but nothing on screen freezes while it moves.
- **The three WATCH AD buttons loaded three new rewarded ads on every visit** and threw the loaded ones away on the way
  out. Each ad that arrives makes Google's SDK build a WebView on the main thread: 55-175 ms freezes of the stage half a
  second after it appeared. The ads now live for the session, one per multiplier (WatchAdButton `adPool`; a used,
  failed or 50-minute-old ad is replaced): a second visit builds none, and its buttons are ready at once. The first
  visit after a launch still pays for them.
- **The house's Catalog, map and rooms redrew continuously** (13-20 fps of redraws under the open Catalog, 4.5 fps
  on the map): SMIL `<animate>` inside SVG pictures (CSS data-URI backgrounds, `<image>`) makes Chrome re-raster
  them on every frame. `SquishStill` (webgame/app/perf.js) strips the SMIL from those pictures (catalog cards, the item
  sheet, room items); the map's own SVG pauses its animations while the map is open; the house tick and the creature
  loop stop asking for frames while the Catalog, the map or the level-up card covers the room (`SquishPerf.freeze`).
- **Daily Challenges** was still the old design's white candy card: it's in the wood look now (no scrolling, 59 fps).
  The streak's DAY 10 tile no longer lets its shine sweep escape the tile. What was left of the old Crib's data
  (catalog, home, fixtures, dock pictures, the map picture) is gone; only the foods and the time-of-day tints stay.

**A measuring trap.** `dumpsys SurfaceFlinger --list` can show the app's window twice: the window's container layer
(no buffers, never draws) and the `…MainActivity$_<pid>` layer that does. Reading only the first one makes a busy screen
look "idle: nothing drawn". Take the layer with the most frames.

**Measured after the round (A16, release, 60 Hz; fps from SurfaceFlinger, p95 frame time in brackets):** intro 58.7,
menu 60 (16.8 ms), Characters 60, Shop 84-89 before the 60 Hz switch and 60 after, Settings 59.7, Stats 60,
Achievements 60, sign-in 60, Squish Time 60, house 59.5 (16.7 ms), menu after the house 58.7 (was 33-50), Squishdoku /
Sort / Stack / Hop hubs 59.7, maps 59.3-60, levels 58.7-60.

**Final pass (same day, the release with everything in it):** Shop (all tabs), Settings, Stats, Achievements, Level Road,
the four games' hubs, maps and levels, the Game Park, Daily Challenges, Streak: 59-60 fps (screens with nothing moving
draw nothing). Squish Time: from PLAY, the loading beat shows at once, holds still while the stage is built, then pops,
fades, and the stage runs at 60 with no pause over 40 ms (warm open, screen recording). Catalog, house map, Kitchen:
nothing drawn while nothing moves.

**The house, last round (same day).** Every Android WebView frame waits for the WebView's one in-process GPU thread,
which also rasterises the page's tiles: whatever makes that thread re-raster a lot freezes the whole app's frames.
- **The rooms' creatures had a CSS filter** (a 22% drop shadow, 1.5 px blur, +6% saturation, +3% contrast: barely
  visible). Over content that changes every frame, the GPU drew each creature offscreen and filtered it on every frame:
  ~15 ms of WebView drawing a frame in the Living Room, 50-58 fps. Without it (webgame/patches.mjs): ~10 ms, the GPU
  thread 60% busy instead of 90%, and the Living Room holds 60 even with the phone hot (thermal status 2). In the house,
  drawing every creature every frame (step 1) stays on probation for the whole visit (one second under 58 fps: back to
  taking turns).
- **Going to a room from the house map** froze the map ~0.9 s after the tap, cut to a blank cream page for 0.5-1.2 s,
  then popped the room in. The map zoomed 2.6x into the picked room (the WebView rasters the whole map again at 2.6x
  before the first step), lit the room up (a blurred glow faded in inside the map's SVG: every step re-rasters those map
  tiles, and each map tile replays the whole map with its 26 blurs), and promoted its cream veil to a layer as the fade
  began (the map's tiles rastered again). Now: no zoom, no glow on a touch screen, the veil a layer from the start; the
  map fades to cream, the new room is drawn under a cream veil (`SquishVeil`, 99% so the room still rasters under it),
  and the veil fades out once frames flow again. Total ~1.5-2 s from the tap, all of it a smooth fade.
- **The house's back orb** no longer covers the Catalog's first tab.

**The evening round (the user: "no improvements, the map got worse").** The earlier map changes only removed effects; the
cost was the WebView's GPU thread rastering big vector art (every app frame waits for it). Measured on the A16:
- **The house map is a picture of itself** (app/menu.js `SquishMapShown`): drawn once into a JPEG on the CPU, kept in
  memory and IndexedDB by a hash of its markup, laid over the SVG, which is then not drawn at all but still takes the taps
  (`pointer-events:painted`); the map has its own layer. Second and later opens: one 50 ms hitch (was 0.5-1 s of blank
  sea, then a frozen map after each tap). The first open of a new map state still draws the SVG once.
- **Room textures and furniture are pictures** (`SquishTex`, patches.mjs wraps the house's `rnTex` and the room items'
  `src`): each wall/floor/ceiling/fence texture (an SVG of 64-232 shapes tiled by a slanted pattern) and each piece of
  furniture (40-100 KB SVGs) is drawn once into a WebP and kept (IndexedDB, loaded at start). Room tiles cost up to
  300-400 ms each before. Room switch raster: Kitchen 1.16 → 0.27 s, Living Room 1.34 → 0.63-0.73 s.
- **No grain on the creatures** (webgame/build.mjs `noGrain`, and the games' rig pages' copy): every creature's art had
  an feTurbulence noise filter (22% multiply), computed again every frame a creature moves. Living Room: GPU thread 89% →
  53% busy, 54-58 → 60 fps. Not visible at a creature's size on a phone (compared side by side).
  **2026-11-21 fix:** the first version made the group a bare `<g>`, and every creature but Mittens lost its face: the
  rigs find the body by that group's filter attribute (`g[filter]`, `closest('g[filter]')` in rive-generic.js,
  plush-motion.js, plush-rig25.js), so nothing was body, no head was found and the eyes and mouth had nowhere to go
  (Mittens has her own rig). Now the group is `<g filter="none">`: still found, nothing drawn; rig-look.js skips "none"
  when it adds the outline. A16, release + dev mode: Living Room 58.0 fps (p95 16.9 ms) without faces → 59.8 / 57.8
  (p95 16.8) with them; menu 58.7.
- **The Dance Room at 1-3 fps (2026-11-21, the user: "1 fps all the time")**: two animated SVGs shown as pictures. A
  browser draws an animated SVG image again every frame, and the layer it is in with it; neither shows in
  `getAnimations()` or a page-level SMIL count, and the room_probe-style desktop runs missed the second because the
  default floor isn't the renovated one. Found on the A16 over CDP (a measuring build) by hiding one part at a time
  and reading SurfaceFlinger: the room 3.8 fps, floor hidden 54.5, anything else hidden no change.
  1. Its **floor** (`rnFlat`: a CSS 3D surface, 3000 x 1200 rotated 60deg, tiled with the renovated floor's 15 KB SVG
     with 25 SMIL animations and 3 filters): each tile layer is now `SquishStill` then `SquishTex('item')` (a WebP drawn
     once). 3.5 → 57.8 fps (p95 16.9 ms).
  2. Its **glass-dome sky** (`glassSky`, 4 clouds drifting by SMIL over 80-110 s): `SquishStill`. 2.5 → 3.5 fps alone.
  3. The round room's three blurred trims became see-through strokes (`softStroke`): no measurable change, kept.
  4. **The light-up floors' colours came back (the user asked, "without sacrificing the fps too much")**: the 6 floors
     drawn as the 3D floor (CLB-045, -065, -085, -114, then -005 and -025 at the user's pick; app/menu.js `SquishDisco`) show their animation as 4 moments of its loop
     (its longest animation up to 6 s): each tile paused at that moment (`svgAt`: the SVG's SMIL values written into a
     still copy) and drawn once into a WebP (kept in IndexedDB like the room textures), the floor showing moment 0 and
     3 copies of its 3D surface over it showing the others, switched on in turn by CSS opacity animations
     (`sqDisco4_*`, step-end: no fade, the user didn't want one): the GPU shows finished layers, nothing is drawn again.
     **Black flicker** (the user saw it): at opacity 0 the WebView neither draws a copy nor keeps its tiles, so the copy
     was drawn at the moment it came on and showed its dark background colour meanwhile (recorded: the floor's brightness
     122 → 44 at each switch). Now the copies have no colour of their own and each is already there at 1% during the slot
     before its own (drawn, invisible): recorded on the A16, no dark frame and each switch one clean frame, every 1.4 s.
     At most the floor, the copy on show and the next one are drawn. (Versions: faded with all three held, 45-54 fps;
     faded with each gone once covered, 58.3 / 58.5 fps p95 16.8 ms with CLB-114, the still floor 57.8; the final one
     measured with the phone hot after hours of tests, thermal status 1: 51.7 fps, the still floor 39-58 in that state.)
     Off in lite mode (`sq-lite-all`, the house isn't inside `.mm-frame`), paused while the house stands still under the
     Catalog / map / level-up (`sq-hfz`).
  The Backyard and the Yard Games list measured idle / 60 fps the same day (sunny weather, no creatures there).
- **The map's zoom into a room is back (2026-11-21, the user asked for it)**: only while the map shows its picture. At the
  tap, app/menu.js `SquishMapZoom` makes the zooming box its own layer (`will-change: transform`), the house's
  `mapPick` (patches.mjs) starts the 2.6x zoom two frames later, and the zoom only scales that layer on the GPU (a little
  soft towards the end, under the cream). Recorded on the A16: the zoom and the cream fade run at 17 ms a frame with no
  hitch (the fade alone had a 233 ms one); the room is then drawn under the cream as before (~0.7 s for the Kitchen).
  Without the picture (the first opening of a new map state) it still fades with no zoom.
- **Heading home**: its day picture is a JPEG (was an SVG image of the whole scene drawn at several scales); with the
  room work above its worst frames went from 0.6-1.1 s to 0.18-0.3 s.
- **The win card** (Trio.js): its characters' WebView is made once the card has settled (650 ms), not mid-spring; the
  spring plays smoothly, a 0.25 s pause remains on the still card just before the characters appear.
- The status bar is hidden again whenever the app comes back to the front (MainActivity), so the game isn't pushed down
  after the lock screen.
- **Characters' first open, measured** (cold start, release): the page is now built under the loader once its first
  deal has played (`G.dealt`), so the loader deals from its first frame (it showed a still deck for ~0.9 s while the page
  under it was drawn for the first time); the page's first drawing (one 0.35 s pause) falls while the dealt cards rest,
  and the page is up ~0.4 s sooner than before (3.9 s from the tap). It fades once into the page. A flicker found on the way (the loader faded
  out, came back fully and faded again: the class added as it leaves was `out`, the loader's own faded state) is fixed
  (`sq-leaving`). **Level Pass first open: no gap over 116 ms.**
- **Chest list**: no position dots; paging to the last group, switching to another Shop tab and back keeps the group.
- **The map picture is the same for every room** (the map's markup is identical whichever room you're in: the "you're
  here" pin and the faces are HTML), so it is made once per house look (a renovation, the weather, the time of day) and
  kept across launches; its last picture is read and decoded at start (`sq.mapKey`). First map open after a restart:
  one 0.2 s gap (was 0.23 + 0.5 s).

- **Heading home rebuilt** (the user agreed): the night and each lit window are canvases drawn once (headingHome
  `nightPics`: the day picture multiplied by the night's colours, each light's windows, halos and panes composited in
  lighting order) and faded in; no multiply / screen / soft-light layers or masked copies of the house any more. Same
  look (compared in Chrome at the A16's size). It did **not** remove the stalls (recorded twice on the phone: 0.25-0.33 s
  at the start and as the night falls, 0.4-0.57 s as the house appears after the flight in): they come from making the
  day picture (the menu scene's ~2,000 shapes drawn into a CPU canvas on the page's main thread, ~0.28 s), the first
  upload of the night's canvases, and the house's own first drawing. Tried and reverted: not swapping the scene for its
  picture under the night (worse: stalls up to 0.55-0.85 s). Also tried: the day picture drawn in 6 strips and the
  lights composed one per task (`svgCanvas` bands): no change (0.2-0.4 s at the start, 0.35-0.63 s as the house appears),
  so these stalls are not the page's main thread: they are the WebView's GPU thread drawing the house for the first time
  (every app frame waits on it). Removing them would mean drawing less of the house the first time it appears (or having
  it drawn before the trip), a change to the house itself.
- **Tried and taken out (2026-11-21, the user chose to try it): the house prepared in the background.** The house was
  mounted invisibly once the menu had been still for 4 s, held, and only revealed by the trip in; going back parked it.
  Measured on the phone over two trips: 0.27-0.88 s stalls, no better than before (an earlier "no stalls" reading had
  recorded the Daily Spin, not the trip). It kept the whole house in memory and needed the back key to step around a
  hidden house, so it was removed. The trip in still stalls 0.2-0.6 s, 3-4 times.
- **Room first, creatures after (2026-11-21, the user chose it).** On the trip in the house is revealed as its bare room;
  the furniture layer (`.sq-items`) fades in half a second later and the creatures are mounted one at a time after that
  (app/menu.js `SquishFill` / `fillEnd`; the house's `mountVis` waits while filling, `mountVis(1)` mounts the next one).
  Switching rooms on the map is unchanged. Dusk falls at once again (the plain night layer), with the drawn night fading
  over it when made (the rebuild had made the title sit over the daytime house for ~1.5 s). Measured on the phone: the
  reveal is smooth (room, then furniture, then creatures over ~1 s); a repeat trip has hitches of at most 0.23 s; the
  **first trip after a launch** still stalls ~0.3-0.6 s twice while dusk falls (the house being built under it, the
  night's pictures made).

**Full sweep on the final build (2026-11-21, a@gmail.com, level 28, phone cool):** menu 58.2, Shop 60, Settings 59.6,
Stats 60, Achievements 60, Streak 60, Daily Challenges 57.7, Daily Spin 60, Level Up 58.2, Characters 60, Game Park 60,
Squish Time 60, Squishdoku / Sort / Stack / Hop hubs 59.1-60, Squishdoku map and level 60, Living Room 60. Drawing
nothing while nothing moves (correct): Level Road, Level Pass, the house map, the Kitchen, the Catalog. First trip into
the house after this launch: pauses of 0.17-0.87 s (accepted by the user "for now"; repeat trips earlier: at most 0.23 s).

**Still open:**
- **First opens after a launch** (Characters, the Level Pass, the first Squish Time): the loader showed still for
  ~1-1.5 s before moving (later opens smooth). Traced on Characters (GPU raster per layer, 4 s after the tap): 2.6 s of
  GPU raster, of which the card row 0.89 s (the whole 10,800 px row, all 86 cards) and the spotlight creature 0.95 s
  (animating unseen under the loader, rastered again every frame), plus ~90 card pictures decoded and uploaded (~1 s),
  and the menu's scene behind the page until the next 400 ms cover() round. Changed (webgame/app/menu.js, last thing
  this day): each group's cards are drawn only while on screen (`content-visibility:auto` at the size measured as it goes
  in), the spotlight creature is hidden while the loader covers it, the menu is covered from the page's first frame
  (Characters and the Level Pass), and the cards use small copies of their pictures (webgame/tools/small-cards.py:
  webgame/app/sm/cards4, assets/looks-sm; 3-10x fewer pixels, the original if one is missing). With the first two only
  (by CSS over CDP), GPU raster fell 2.6 → 1.7 s and the row 149 → 28 tiles. **Not yet measured on the phone with all of
  it:** the phone's battery ran down to 1% (it charges slower over the PC's USB than it drained under the tests).
  Checked in Chrome at the A16's size and density: the loader, the page, a scrolled row (groups appear as they come in,
  the dividers, the IN USE tag and the selected card's glow intact), no page errors, no missing files.
- **The cream hold between rooms** is the room's raster time (~1-2 s on the A16). Next: cheaper room pictures (their
  patterns and blurs).
- Watching a rewarded ad with the new ad pool has not been tried on a device (the test account must not watch ads):
  watch one and check the ×N boost starts and the button loads its next ad.
- The sign-in screen was checked on the phone (log out, log in by email: 60 fps, the keyboard's Go submits). In
  landscape, Samsung's keyboard opens its full-screen typing box over the form (standard Android; `disableFullscreenUI`
  would show the form instead, under the keyboard).
