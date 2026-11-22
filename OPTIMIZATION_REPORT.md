# Performance & cleanup round — 20–21 November 2026

Everything done for the "optimize the whole app" goal, measured on the test phone (Samsung Galaxy A16, SM-A165F,
Android 16, release builds). Nothing here is committed yet.

---

## 1. What was asked

- Loading screens were heard before they were seen ("half way done" when they appear).
- Some screens ran at 3–5 fps; flickering in places.
- The house (Crib) showed a white strip at the bottom, as if not full screen.
- Visit every screen, animation and loading screen; reach 60+ fps **without lowering the resolution**; think of older
  phones too. Mobile only.
- Chest list: after opening chests it came back on the first item while its dots showed the end. Remove the 3 dots.
- Remodel/retexture the login screen in the game's new look.
- New players were landing in the old UI and its tutorial: remove the old UI and all unused code. (The tutorial itself is
  for later.)

---

## 2. Results at a glance (measured on the phone)

Frames per second from Android's SurfaceFlinger (what actually reaches the screen). "Still" = nothing on the screen moves,
so nothing is redrawn — correct, not a problem.

| Place | Before | Now |
|---|---|---|
| Menu | 33–50 after the house, stutter | 58–60 |
| Shop (all 5 tabs) | stutter at 90 Hz | 60 |
| Settings, Stats, Achievements | stutter | 59.6–60 |
| Daily Spin, Streak, Daily Challenges, Level Up card | — | 57.7–60 |
| Characters | 1–2 s frozen on first open, flicker | 60; deals at once; one clean fade |
| Level Pass | pause on first open | smooth (longest gap 0.12 s) |
| Game Park | — | 60 |
| Squish Time (loading + stage) | frozen "I AM READY!", ad freezes | 60; smooth entry |
| Squishdoku / Sort / Stack / Hop (hubs, maps, levels) | stutter | 59–60 |
| Win card after a level | 41–45 fps | smooth spring |
| House — Living Room with creatures | 33–35, later 54–58 | 60 (even when the phone is hot) |
| House — map | blank sea, then frozen ~1 s; 4.5 fps | one 0.2 s pause after a restart, then smooth / still |
| House — Catalog | 13–20 fps, constant redraw | still (no redraw) |
| House — switching rooms | 1.16 s (Kitchen) / 1.34 s (Living Room) of drawing | 0.27 s / ~0.7 s, as a cream fade |
| House — white strip at the bottom | present | gone |
| Walking into the house ("Heading home") | stalls up to ~1 s | repeat trips: hitches ≤ 0.23 s; **first trip after a launch: still pauses (0.17–0.87 s)** — accepted "for now" |
| New player's first launch | old UI + tutorial | new intro → Mittens → new menu (58 fps) |

Full numbers and how each was found: [PERFORMANCE.md](PERFORMANCE.md) ("60 fps everywhere…" section) and
[webgame/README.md](webgame/README.md) ("Performance, 2026-11-20").

---

## 3. What was changed

### 3.1 The biggest single win: 60 Hz
The A16's screen runs at 90 Hz (11.1 ms per frame). Most screens needed 12–15 ms, so every frame missed and waited for
the next one: 45–60 fps with constant stutter. The app now asks Android for 60 Hz (same resolution), giving 16.7 ms per
frame. — `android/app/src/main/java/com/plushcrush/app/MainActivity.kt` (`preferSixtyHz`, also turns off the
touch boost on Android 15+).

### 3.2 Loading screens seen from their first frame
- Squish Time's "Getting ready" starts its beats and sound only once it is on screen, and holds still while the stage
  is built under it (`LoadingScreen` `hold`, `SquishScreen` `onShown`).
- Characters' "Gathering your squad" deals from its first frame; the page underneath is built after the deal
  (`G.dealt`). A flicker (fade out, back, fade again) was fixed.
- Level Pass fills unseen, then shows whole.
- "Heading home": dusk starts at once; the night and lit windows are drawn once into pictures and faded in.
- Placeholders (bones) are wood-toned and landscape instead of the old light-blue portrait ones.

### 3.3 The menu and house (the web part of the app)
The menu, house and pages run in one WebView. Every app frame waits on its graphics thread, so the work was about
making it redraw less:
- **Menu kept alive under other screens** (asleep, not rebuilt) — no more ~3 s blank brown on the way back.
- **Creatures take turns** being drawn each frame; drawing all of them every frame is back on only when the phone keeps up.
- **Pictures that animate inside** (SMIL in SVG) are made still where they're shown (Catalog cards, items) — that was
  the Catalog's constant redraw.
- **House freezes** while the Catalog, map or level-up card covers the room.
- **The house map is a picture of itself** (drawn once, kept across launches); its rain/waves hold still while open.
- **Room walls, floors, ceilings and furniture are pictures** (each vector drawing turned into an image once, kept).
- **No filter on the room's creatures**, and **no "fabric grain" noise filter** on creature art (invisible at phone
  size; it was recomputed every frame).
- **Room first, creatures after** on the trip in: the bare room appears, furniture fades in, creatures arrive one by one.
- Map → room: no glow on touch screens, a cream veil while the room is drawn. (The zoom into the room came back on
  21 November, as a cheap zoom of the map's picture; see PERFORMANCE.md.)
- (21 November: the grain removal had also removed every creature's face except Mittens'; fixed, see PERFORMANCE.md.)
- Characters' first open: off-screen card groups aren't drawn, smaller card pictures (`webgame/tools/small-cards.py`),
  the hidden creature under the loader isn't drawn.
- The house fills any screen shape (the white strip).

### 3.4 Squish Time
- The sky behind the creature is native pieces instead of one big vector drawing.
- The ×2/×3/×4 ad buttons keep their loaded ads for the session (no new ad WebViews on every visit).
- **Verified:** a test ad plays, "Reward granted", the ×2 boost runs 60 s, and the button loads its next ad.

### 3.5 Other screens
- Every React Native screen was 48 dp short of the right edge (window size bug) — fixed.
- Looping animations run natively (they keep moving while JavaScript is busy).
- Win card: its creatures' WebView is made after the card settles (no freeze mid-spring).
- The status bar no longer stays on top of the game after the lock screen.

### 3.6 Chest list
No position dots; it stays on the group you were viewing after a chest opening or a tab switch.

### 3.7 Login screen
Remodelled in the wood look (house background, logo, Mittens, wood panel, Log in / Register tabs, Google / Facebook /
TikTok). Checked on the phone: logging in and registering work.

### 3.8 Old UI removed
The classic Home / Lobby / Squad, the old Crib, the old settings sheet, Create-a-squishy and the guided tutorial are
deleted (117 files deleted in total), with the packages and Android permissions only they used
(image/document pickers, image manipulator, Firebase Storage; storage and microphone permissions).

### 3.9 New players
- **Bug found with a fresh account:** new players started owning only Nimbo, whose group (Sky & Stars) is switched off
  in the live roster settings — so they saw **no creature anywhere**.
- **Fix (your choice):** new accounts start with **Mittens** too (the intro's creature; picked automatically).
  Existing players are not changed. — `src/data/creatures.js` (`NEW_PLAYER_CREATURE_IDS`), `src/firebase/firestore.js`,
  and the server sign-in profile in `functions/index.js` (which also stopped writing the old `tut` tutorial flag).
- **Verified on the phone** with a new account: intro → box → Mittens → menu with Mittens, level 1, 350 coins, 600 gems.

### 3.10 Developer mode: no email confirmation
In development builds (and the test/measuring builds), a new email account plays at once — no "verify your email"
screen and no email sent. Normal release builds still require it. — `SKIP_EMAIL_VERIFY` in `src/webDebug.js`.

---

## 4. What is still open

| Item | Status |
|---|---|
| First trip into the house after launching the app: 2–3 pauses (0.17–0.87 s) while the house is drawn for the first time | **Accepted for now.** The real fix is a separate project: rooms drawn as ready-made pictures instead of live vector art. |
| Repeat trips into the house: short hitches (≤ 0.23 s) | Minor. |
| First visit to a room after its look changes (a renovation): slow once, then fast | Pictures are made on first use. |
| Back button doesn't close the Daily Spin (only spinning does) | Found while testing; not changed. |

Tried and taken out (they didn't help): preparing the house in the background, drawing the night in strips, keeping the
live scene under the night.

---

## 5. What you need to do

1. **Deploy the cloud functions** (`firebase deploy --only functions`) so Google / Facebook / TikTok sign-ups also start
   with Mittens. (Earlier rounds' function changes — chest rarity, daily spin, Blitz saves — also wait on a deploy.)
2. **Say when to commit.** Nothing in this round is committed.
3. **Delete the two throwaway test accounts** in Firebase if you like: `devtest1121@example.com` and the earlier
   account with the squad name "Anzor".
4. **Clear or replace `/goal`** — it still asks for "60+ everywhere, no stalls" and keeps re-triggering.

---

## 6. Test setup notes

- Phone: Galaxy A16 over USB (`RF8Y80NPS1B`). It charges more slowly from the PC than heavy testing drains it — check
  the battery before long sessions.
- Release build: `cd android && ./gradlew.bat assembleRelease -x buildWebgame -PreactNativeArchitectures=arm64-v8a`
  (run `node webgame/build.mjs` first when anything under `webgame/` changed).
- Web game tests: `npm run webgame:test` (49 tests, all passing).
- Measuring builds set `WEBVIEW_DEBUG = true` in `src/webDebug.js` (inspectable WebViews, test links like
  `com.plushcrush.app://open/shop`, no email confirmation). **It must be `__DEV__` for a real release** — it is now.
