# Running the app on the emulator: troubleshooting

Updated 2026-09-29. Fixes for the problems hit while running PlushCrush on the `Pixel_9` Android emulator, starting with the one that stops the app now.

## "Unable to resolve module … dream.ogg" (the app won't start)

**What you see:** a white screen, or a red error screen that says:

```
Unable to resolve module ../../assets/audio/music/dream.ogg
from ...\src\audio\sfx.js
```

**Why:** the new music and sound files are `.ogg`. Metro, the dev server that sends the app's code to the emulator, only handles `.ogg` files since a change to `metro.config.js` in Phase 3. Metro reads that file once, when it starts. A Metro that was already running before the change still refuses `.ogg` files.

Right now two Metro servers are running:

| Port | Started by | Knows `.ogg`? |
|---|---|---|
| 8081 | `npx expo start` (started days ago) | **No**, it started before the change |
| 8082 | `npx expo run:android` (started today) | Yes |

The app is currently set to load from **8081**, which is why it fails.

**Fix: pick one of these.**

**A. Restart the Metro on 8081** (simplest)

1. In the terminal where `npx expo start` is running, press `Ctrl+C`.
2. Start it again with a clean cache:
   ```
   npx expo start -c
   ```
3. On the emulator, reopen the app (or press `r` in the Metro terminal to reload).

**B. Use the Metro on 8082 instead** (already has the change)

1. Open the dev menu on the emulator: press `Ctrl+M`, or run `adb shell input keyevent 82`.
2. Choose **Change bundle location** and enter `localhost:8082`.
3. Reload the app.

Afterwards, stop the Metro you're not using. Two Metro servers from the same folder only cause confusion about which one the app is talking to.

## Blank white screen with "Compiling JS failed" in the logs

**What you see:** a white screen. `adb logcat` shows a line like:

```
Compiling JS failed: 241249:13:'}' expected ... Buffer size 12676716
```

The line number changes on every launch.

**Why:** the emulator's own route to the PC (`10.0.2.2`) was dropping single bytes from the 12.7 MB of app code, so the code arrived broken. The code itself is fine: the same download on the PC compiles cleanly.

**Fix:** load the code through the adb connection instead, which arrives complete.

1. Forward the Metro port into the emulator (use your Metro's port):
   ```
   adb reverse tcp:8081 tcp:8081
   ```
2. In the dev menu, **Change bundle location** to `localhost:8081`, not `10.0.2.2:8081`.

This setting survives app restarts. It's lost if the app is uninstalled or the emulator is wiped; set it again if that happens.

## "Unable to load script. Make sure you're either running Metro…"

**What you see:** a red screen with that message.

**Why:** either nothing is running on the port the app points at, or the adb port forward is gone. It disappears whenever adb restarts or the emulator reboots.

**Fix:**

1. Check Metro is running: open `http://localhost:8081/status` in a browser. It should say `packager-status:running`.
2. Re-add the forward and check it:
   ```
   adb reverse tcp:8081 tcp:8081
   adb reverse --list
   ```
3. Reload the app.

## The emulator is very slow, or adb commands hang

**Why:** the emulator has only 2 GB of memory. After many hours of use it runs out and starts swapping, and everything crawls: taps lag, and `adb` commands time out.

**Fix:**

1. If `adb devices` hangs, restart adb:
   ```
   adb kill-server
   adb start-server
   ```
   Then re-add the port forward (see above).
2. If the emulator itself is slow, cold-boot it (fresh start, no saved state):
   ```
   emulator -avd Pixel_9 -no-snapshot-load
   ```
   Or in Android Studio's Device Manager, choose **Cold Boot Now**.

## Quick checklist

When the app won't start on the emulator, go through these in order:

1. **Is one Metro running?** `http://localhost:8081/status` (or `:8082`) says `running`.
2. **Did it start after the last `metro.config.js` change?** If not, restart it with `npx expo start -c`.
3. **Is the port forwarded?** `adb reverse --list` shows your Metro's port.
4. **Is the app pointed at it?** Dev menu → **Change bundle location** → `localhost:<port>`.
5. **Still stuck?** Read the actual error:
   ```
   adb logcat -d | findstr ReactNative
   ```
