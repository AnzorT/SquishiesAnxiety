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
