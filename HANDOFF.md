# PlushCrush handoff (2026-10-03, evening)

Everything needed to pick up in a new chat. Paste or point the new chat at this file first.

## 1. Where things stand

- Branch `develop`, last commit `a6cbd36` (Round 6 docs). **All of the 2026-10-03 work is uncommitted** (about 75 changed/new files): the new roster (Phase A), tutorial and progression (Phase B), the Squad Crib with its extras (Phase C), and polish (Phase D).
- All of it was walked through on the Pixel_9 emulator. Tests pass:
  - `node --input-type=module -e "import('./src/crib/model.test.js')"`
  - `node --input-type=module -e "import('./src/progression.test.js')"`
- Round 9 (the Crib's animations 1:1 with the design: plush moods per food and bath station + the care-state layer, the design's creature card, tucking blankets, the attic Hatchery, 70% start / 40% sad-smelly rule, landscape banners from the top, Edit fixes): `REDESIGN_V3.md` → "Round 9", user summary `ROUND_9.md`.
- The full write-up is `REDESIGN_V3.md` → "Round 7" (Phases A, B, C, D, with gotchas) and "Round 8" (the user's review: tutorial gates, the Crib's HUD/map/dock, cheap → luxe rooms, movable furniture, the 10-creature cap, the 10-day streak, the Key Shop stalls, achievements, SPIN AGAIN, DOUBLE IT).

## 2. What's left

**For the user (needs their keys or tools):**
1. Publish the 30-creature catalog and reset the test players (needs the Firebase service-account key; the assistant may not search the disk for credentials):
   ```
   node tools/plush-art/render.mjs
   GOOGLE_APPLICATION_CREDENTIALS=<path-to-key.json> node tools/plush-art/publish.mjs --catalog --reset-players
   ```
   `--reset-players` also deletes every `users/{uid}/crib/state`. `--dry` previews.
2. `firebase deploy --only functions:spinWheel,functions:verifyPurchase,firestore:rules` (roster filter past 20, SPIN AGAIN's video spins, the half-price creation, `adSpins` blocked for clients). The Firebase CLI on this PC is logged in; the assistant may run it if the user says so.
5. Create the store product `creature_creation_half` ($2.49, half of the creation price; or `creature_creation_half_<cents>` for a price level) in Play Console / App Store Connect.
3. Tripo 3D models for the new creatures (view sheets in `tools/plush-art/design/export/tripo/<key>/`). Until a creature's doc has a `modelUrl`, it plays on the 2D squish stage.
4. Done: `firebase deploy --only firestore:rules`.

**For the assistant, once the catalog is published:**
- Remove `TEMP-DEV-CATALOG` (3 places in `App.js`: lines ~80, ~306, ~318). Restore line 318 to `setCreatures(list); saveCreaturesToCache(list);`.
- Check the app against the real catalog (Home, Key Shop, box, Crib).
- Then commit, if the user asks (attribution line from the system reminder).

**Worth a look later:**
- The living room's 12 animated plush creatures use about 160% of the emulator's CPU in the debug build (the dance room about 90%). Measure on the Galaxy A15 in a release build.
- Sad creatures cost coins while the Crib is open (the design's rule). The test account's creatures were all at 0 stats, costing about 5 coins/s.

## 3. The user's rulings (2026-10-03)

- **Roster reset:** the old 20 creatures and every player's progress are thrown away (still testing, not released). 30 new plush creatures.
- **Economy unchanged:** no shared tokens. Per-creature tokens, box rules and Round 5/6 prices stay. Deferred: the design's $2.99 Remove Ads, $0.99 first creations, $6.99/mo Daily Creator, Starter Pack, streak creation discount, and **$ prices on furniture** (the Home Shop sells for coins only).
- **Crib:** both orientations with the blue rotate toggle; state survives rotation.
- **Order is the assistant's call; don't break what works** (3D squish stage, box, shop, billing).
- The tap-spam "WHOA THERE!" easter egg stays.

## 3b. Later rulings (Round 8, 2026-10-03 evening)

- The 10-day streak (day 10 = half price on a creation) is wanted now, on its **own** Home button, not inside Daily Challenges.
- Max **10** creatures live in the Crib; the Hatchery picks who.
- Rooms start **cheap** (boxes instead of furniture) and go up to luxurious, walls/floors/ceilings/rugs/lamps included; **everything is movable** and stays usable.
- The Key Shop and the Crib HUD/map must be the design's, 1:1.
- No ad after the wheel: SPIN AGAIN for a video instead. Box prizes can be doubled for a video, max 5 a day.

## 4. What was built (by phase)

**Phase A: roster.** `tools/plush-art/roster.mjs`, `render.mjs`, `publish.mjs`, `serve.mjs` (preview on :9500, writes git-ignored `src/data/devCatalog.js`). Plush faces and motion: `src/plush/faces.js`, `src/plush/motion.js`, `src/components/CreatureThumbnail.js`. Tiers spread 0-11 Common, 12-18 Rare, 19-23 Epic, 24-27 Legendary, 28 Rainbow, 29 Golden (`tierOf` in `src/theme/candyTheme.js`). SECRET = Prism Nimbo.

**Phase B: progression.** `src/progression.js`, `src/tutorial/` (store, Target, steps, Guide), `src/screens/DailyChallengesSheet.js`. Profile fields `tut`, `level`, `levelDay`, `daily`, `streak`, `lastFull`. Daily challenges open at level 3; the level then rises once a day when the daily chest is opened.

**Phase C: the Squad Crib** (`src/screens/CribScreen.js`, `src/crib/`):
- `model.js`: the simulation, as pure functions over one state saved at `users/{uid}/crib/state`. It pauses while the app is in the background and catches up (max 10 min, no coins) on return.
- `home.js`: furniture (the design's `crib-home.js`) over `state.home`: buy, equip, play spots, decor, lamps, themes, perks, layout (spots), visuals (pieces).
- `data.js` (rules and layouts), `catalog.js` (generated by `tools/crib-art/export.mjs`: per-slot-tier art).
- `Scene.js` draws, in order: room layers and themes → dance lights and floor or yard games → back furniture → decor → creatures (zIndex 100+y) → front layer (zIndex 1000: front furniture, kitchen table, night).
- `art.js` (room layers and themes), `roomArt.js` (generated require map), `Yard.js` and `Dance.js` (Reanimated, one memoized frame callback using `f.timestamp`), `Night.js` (SVG mask with lamp holes and glow), `Decor.js` (drag; `toLocal` maps landscape's rotated axes), `Shop.js`, `EditPanel.js`, `CribCard.js`, `RoomTiles.js`, `ui.js`.
- Music: 11 tracks `assets/audio/music/crib_*.ogg` / `club_*.ogg`, registered in `src/audio/sfx.js`. `App.js` doesn't set music for the crib stage; CribScreen does (`ROOM_MUSIC`, the dance room plays the DJ song).

**Phase D: polish.** Key Shop NEXT UP banner (`src/components/shop/NextUp.js`; it holds the tutorial's `key` target). BoxReveal plays mood `reveal`. Achievements creature badges play mood `cycle`.

## 5. Regenerating art and sound

Extract the design first: `python -m zipfile -e "ASMR Creature Squash Game.zip" tools/plush-art/design`

| What | Command |
|---|---|
| Crib rooms (layers), themes, `src/crib/roomArt.js` | `node tools/crib-art/render.mjs` (or one room: `... render.mjs living`) |
| Check the layers composite back correctly | `python tools/crib-art/check.py` |
| Crib catalogue (`src/crib/catalog.js`) | `node tools/crib-art/export.mjs` |
| Crib music | `node tools/audio/render.mjs --crib`, then `python tools/audio/encode.py`, then `git checkout --` the older `.ogg` files it re-encoded (same audio, new bytes) |
| Creature art | `node tools/plush-art/render.mjs` |

## 6. Dev environment

- **Metro:** `npx expo start --port 8081`. The emulator's debug build loads from `localhost:8082` (pref `debug_http_host`), forwarded to 8081.
- **Preview catalog server:** `node tools/plush-art/serve.mjs` (port 9500). Needed while `TEMP-DEV-CATALOG` is in.
- **adb reverse** (re-add after every emulator reboot):
  ```
  adb reverse tcp:8082 tcp:8081
  adb reverse tcp:8081 tcp:8081
  adb reverse tcp:9500 tcp:9500
  ```
- **Emulator:** AVD Pixel_9 (`emulator-5554`), 1080×2424, 2 GB RAM. The test account is already signed in. Home taps (px): start (540,2140); Crib house icon (452,262); Key Shop (882,261); trophy (774,259). In the Crib, portrait: shop (300,216), edit (414,216), rotate (1002,216); room tiles living (140,1680), yard (936,2016), dance (141,1995).
- **Emulator thrash:** after a long session the 2 GB fills up and taps arrive seconds late, landing on whatever screen is up by then. One late tap opened a $0.99 Play purchase sheet; it was backed out and nothing was bought. Fix: `adb reboot`, then re-add the reverses. Confirm the screen with a screenshot before every tap, close sheets with `adb shell input keyevent 4`, and never batch taps.
- **Screenshots:** `adb exec-out screencap -p > file.png` (in Git Bash set `MSYS_NO_PATHCONV=1` and use `C:/...` paths).
- **Galaxy A15** over wireless adb when connected: `adb-RF8Y80NPS1B-cnmMDV._adb-tls-connect._tcp`.

## 7. Gotchas learned

- Android `zIndex` reorders siblings. A layer meant to be on top needs its own higher zIndex.
- Reanimated `useFrameCallback` re-registers whenever the callback changes, which restarts `timeSinceFirstFrame`. Memoize the callback and use `f.timestamp`.
- `react-native-svg` can't draw `<image href="data:image/svg+xml…">`. `export.mjs` inlines those as nested `<svg>`.
- The home object is mutated in place. Components get a `homeRev` counter so `memo` and `useMemo` notice changes.
- Fast Refresh while files are half-edited throws transient errors (and can bounce the app to the splash). Judge after a full relaunch.
- `Animated.delay` loops stall `InteractionManager`; use native zero-motion timings instead.
- Android `measureInWindow` y excludes the status bar.
- The pending-callbacks dev warning counts running native animations; it isn't a leak.
