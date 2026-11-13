# Redesign v5: the rest of "Squish Squad App.html"

All five steps below are **built** (2026-10-08). What's left is on the user's side (the player reset and the deploy), checking on a phone, and the later rive-rig project.

Working rules, since the user is short on tokens:
- read only the design sections you're porting;
- check visuals with screenshots (`tools/shop-art/shot.mjs`) rather than reading whole CSS files;
- match the **whole** screen against a full-page design shot: background, splash and mascot, not just the widgets. The user caught the old background still behind every screen.

## Where things stand (2026-10-08)

- Commit only when the user asks.
- **Roster published** to Firestore: the 30 plush creatures replace the old 20 (see "Roster" below). The app reads the catalog from Firestore again; the `TEMP-DEV-CATALOG` hook is gone.
- **The user still has to run:**
  1. The player reset, so everyone starts fresh in the new economy. In PowerShell:
     ```
     $env:GOOGLE_APPLICATION_CREDENTIALS = "<path to your service-account key>.json"
     node tools/plush-art/publish.mjs --reset-players
     ```
     Add `--dry` first to preview. It clears gems, chests, the collection and the other economy fields, so the starting 600 gems and the welcome chest are handed out again. It keeps nickname, email, purchases (`adsFree`, `generationCredits`, `paidCredits`, `gemFirst`) and custom creatures.
  2. The deploy of `verifyPurchase`: `firebase deploy --only functions:verifyPurchase`. `spinWheel`, `squad` and `firestore.rules` went live on 2026-10-09 (see ECONOMY_V2.md).
- **Stars were dropped on 2026-10-09** (see ECONOMY_V2.md).
- **Not seen on a phone:** steps 2, 3 and 5, the sky backgrounds and the new splash. The user asked to stop emulator testing on 2026-10-08. Metro builds the app, every changed file passes the Babel scope check, and `functions/*.test.js` pass.
- The economy itself is described in `SQUAD_ECONOMY.md` (screens: `ShopScreen.js`, `ChestOpener.js`, `RevealShow.js`, `SquishiesScreen.js`; shared UI in `src/squad/ui.js`).

## The APK (2026-10-08)

A release APK for phones, with the JS bundled in, so it runs without the PC:
`cd android && ./gradlew.bat assembleRelease -PreactNativeArchitectures=arm64-v8a`
→ `android/app/build/outputs/apk/release/app-release.apk` (about 95 MB; a copy is on the user's Desktop as `SquishSquad.apk`).
- **arm64 only:** the full build fails on `react-native-reanimated:buildCMakeRelWithDebInfo[armeabi-v7a]` with "ninja: manifest 'build.ninja' still dirty after 100 tries", while arm64-v8a builds fine. Deleting `node_modules/react-native-reanimated/android/.cxx` didn't help, and no file has a future timestamp. So it's most likely Windows' 260-character path limit (the project's path is long and has spaces). Moving the project to a short path (e.g. `C:\pc`) or enabling Windows long paths should allow a full build. 32-bit-only phones and x86 emulators can't run the arm64 APK.
- It's signed with the debug key (`android/app/build.gradle`): fine for installing straight onto phones, not for the Play Store. Google Play Billing (gem packs, Remove Ads) doesn't work in a sideloaded app.
- `versionCode` is still 1.

## Unused files, delete when convenient

`CreatureReelScreen.js`, `CandyTabs`, `SkeletonCard`, `MysteryBoxBanner`, `RemoveAdsButton`, `CreateOwnCard` / `CustomCreatureCard` (but `CustomArt` in the same file is used), `CardPager` once those are gone, and `src/data/devCatalog.js` (git-ignored). `RemoveAdsSheet` is still rendered in App, but nothing opens it any more.

## The design files

`node tools/shop-art/extract.mjs` decodes `Squish Squad App.html` into `tools/shop-art/design/` (git-ignored).
- Screenshot any page: `node tools/shop-art/shot.mjs "<page>.dc.html" out.png [--js "…"]`. Pages scroll inside a `overflow-y:auto` div; see `SQUAD_ECONOMY.md` for the scroll trick.
- The app shell (bottom nav, login, daily spin, ad banner) is in the bundle's `__bundler/template`. To get it, decode it the way `extract.mjs` does and save it as `design/App Shell.html`. Add that to `extract.mjs` first.
- Each `.dc.html` is markup with `{{ bindings }}` plus a `<script type="text/x-dc">` class. Its `renderVals()` holds the data.

| Step | Design page | Size | Replaces |
|---|---|---|---|
| 1 ✅ | App shell + `Squishies Tab v2` (already ported as `SquishiesScreen`) | 61 KB shell | `HomeScreen` as the main screen, plus a Squishies / Shop bottom nav. **Done 2026-10-07**, see below |
| 2 ✅ | `ASMR Creature Squash v5.dc.html` | 323 KB | `SquishScreen` UI. Keep the 3D squish stage and its engine; restyle only the HUD and overlays. **Built 2026-10-07, not yet seen on device**, see below |
| 3 ✅ | `Squad Crib Vertical v2.dc.html` | 203 KB | `CribScreen` portrait layout. The Crib's model and art stay (`src/crib/`). **Built 2026-10-08, not yet seen on device**, see below |
| 4 ✅ | Shell login / register | in the shell | `AuthScreen`, email only. **Built and seen on the emulator 2026-10-08**, see below |
| 5 ✅ | Shell daily spin + ad banner | in the shell | `DailySpinScreen` + `AdStrip`. **Built 2026-10-08, needs a deploy**, see below |
| later | `Full Roster v1`, the zip's `handoff/` rive-rig | | the creature animation rig: a separate project |

## How to port a screen (what worked for the Shop)

1. Screenshot the design page at 390×800 and read only the section you're on.
2. Rebuild it in React Native with `src/squad/ui.js` and the candy components (`OutlinedTitle`, `ShadowText`, `RaysSpin`, `CandyBackground`, `RoundButton`).
3. Anything drawn with CSS filters (drop-shadow outlines, blur glows) that react-native-svg 15.2 can't do: render it to images in headless Chrome, as `tools/shop-art/render.mjs` does for the chests.
4. Check on the Pixel_9 emulator (see the memory's test-device notes).
   - After adding hooks, do a full relaunch (`am force-stop` + `monkey`): Fast Refresh throws stale errors.
   - Check undefined names with Babel scope analysis. There's no ESLint in the repo.
5. Keep the tutorial working. Its targets are `TutTarget name="…"`, its steps are in `src/tutorial/steps.js`, and Home's `box`, `store`, `card:1`, `tabs` and `createCard` targets must keep existing somewhere if Home is replaced.

## Step 1 as built (2026-10-07)

User rulings: the old Home carousel is gone; Collection is split into the game's **Squishies** and **My creations**; the Crib keeps its green house button (from level 2) in the header.
- `src/screens/MainScreen.js`: the shell. Squishies and Shop pages slide side by side, then the ad strip (`AdStrip inset={false}`), then `src/squad/BottomNav.js`. The Shop mounts on its first visit. While the chest opener is up, `ShopScreen` calls `onImmersive(true)` and the ad and nav hide.
- App: stage `'home'` is the shell. `mainTab` is `'squish' | 'shop'`. `openShopAt(tab)` bumps `shopKey`, which remounts the Shop on that tab. The `'store'` and `'squad'` stages are gone, and so is `HomeScreen.js`. SettingsSheet is now rendered in App.
- Header: SQUAD, LV pill, then Crib, trophy and the HomeMenu (daily, streak, stats, settings; Settings moved into the menu 2026-10-09).
- Tutorial: App reports `screen: 'store'` while the Shop tab is open. Targets: `store` is the Shop nav item and `storeBack` is the Squishies nav item (`box` is no longer used). `card:<id>` is a Collection cell; the screen scrolls it into view when the guide points at it. `sheetPlay` is the sheet's SQUISH; steps use the `squadSheet` report. `tabs` is the Squishies / My creations switch and `createCard` is in My creations; both scroll the list to the top.
- Not checked on device: the full tutorial run (replay it from Settings), and the ad strip (the test account is ad-free).
- The files this step orphaned are listed under "Unused files" at the top. A backup of the deleted `HomeScreen.js` was only kept in that session's scratchpad.

## Step 2 as built (2026-10-07)

Most of the squish HUD already followed an earlier pass of the same design (back + gear buttons, bonus bar, the ×2/×3/×4 gold ad buttons, coin pops, ×N COINS! flash), so only the v5 differences were changed:
- Background: new `src/squad/SkyBackground.js`, v5's sky (blue → lavender → pink, a pink glow from the bottom, a white glow behind the toy, three cloud puffs, white dots every 26px). Static memoized SVG, as CandyBackground.
- Coin pill: shows `+N EARNED` for this session (from 0), not the wallet total.
- Gear: a white dropdown card under the gear with no scrim (v5), but it keeps all our settings (3 sounds, FPS, vibration, poke strength and direction) and a small ✕, which is the tutorial's `gearClose` target.
- Gesture hints: v5's white hands with a thin purple outline, a plain pink touch ring and a glowing purple caption (no pill). The rotate caption still says "2 FINGERS TO ROTATE" (v5 says HOLD TO ROTATE, which isn't our gesture). The GAMEPLAY SETTINGS pointer is kept and uses the same caption style.
- Not checked on device: on 2026-10-07 the emulator running then (`Pixel_10_Pro_XL`, emulator-5554) sat on "Loading from 10.0.2.2:8081…" even though Metro served the bundle fine to the PC. That's probably the 10.0.2.2 issue from the device notes.
- Screenshot the design's squish screen: in `shot.mjs --js`, get the dc instance from a button's `__reactFiber…` → `.return` chain → `stateNode.logic`, stub `SquishGuide.show` and `logic.tutGo`, then `setState({ screen: 'squish', … })`. The bonus clock is `window.__squishClock`.

## Step 3 as built (2026-10-08)

v2 is only about 10 small changes from `Squad Crib Vertical.dc.html` (the older zip's page, which the Crib was already ported from). To see them: `diff tools/plush-art/design/"Squad Crib Vertical.dc.html" tools/shop-art/design/"Squad Crib Vertical v2.dc.html"`. Ported:
- Portrait top row is now back, music, shop, edit, daily, rotate; the pantry (kitchen only) stays on the right. v2 dropped the gift button (we never had one).
- Coins use the shared `coin.svg` (`CoinIcon` from `src/squad/ui.js`): the HUD pill (18px, padding 5×12), and through `CoinGlyph` in `src/crib/ui.js`, the Home Shop pill (17px), its buy buttons (15px) and the pantry. `HudCoin` is gone.
- The room-switch flash is `RoomFlash` in `src/crib/Hud.js`: radial white → #e6dcff → #8fd0ff with white dots every 22px (was plain white).
- The room subtitle starts with "<nickname>’s home · " (v2's `ownerName`).

Kept on purpose, where v2 differs:
- Rotate button: v2 shows it only when the page runs standalone (in the app it's portrait only). Kept, because of the 2026-10-03 ruling for both orientations. Remove it if the user now wants portrait only.
- Daily button: v2 always shows it; ours still waits for `dailyIsUnlocked` (Round 8 ruling).
- The attic's counter stays `members/CRIB_MAX` (v2: owned / roster size). v2's `syncSquad` (residents from the collection, 10 living + 3 yard) and the room-switch timeout fallback were already covered by our model.
- Not checked on device: `emulator-5554` couldn't reach `10.0.2.2:8081`; see `EMULATOR_TROUBLESHOOTING.md`. Metro builds the bundle fine.

## Step 4 as built (2026-10-08)

- `src/screens/AuthScreen.js` matches the shell's Log in / Register: the `src/squad/IntroBackground.js` sky (blue → pink, dots every 26px; step 5's daily spin can reuse it), the white outlined "Squish Squad" title with a subtitle that fades up when the mode changes, then one white card with a lilac lip holding the Log in / Register switch (springy pink pill), labelled fields (pink border while focused), the password's Show / Hide, the pink error box, the pink submit button ("Log in" / "Create my squad") and Keep me signed in.
- Left out: the OR + Google / Facebook / TikTok row (email only, the user's ruling) and the rive-rig Mittens mascot above the title (the later rig project).
- Kept from before: the age gate (an AGE field next to SQUAD NAME; under 13 shows the parent/guardian message), the tutorial's `enter` target on the submit button, and the register row's grow/fold animation. The squad name stays capped at 10 characters like Settings (design: 16), and needs at least 2.
- Keep me signed in: `setKeepSignedIn()` in `src/firebase/auth.js` writes `keepSignedIn.txt` (expo-file-system) on submit. When it says `0`, the first auth state of the next app run signs out. A missing file means keep.
- Seen on the Pixel emulator through a temporary overlay (removed), so the real account stayed signed in. Not run through a real sign-in or sign-up.
- `CandyTabs` is now unused (AuthScreen was its last user).

## Step 5 as built (2026-10-08)

User rulings: the wheel's prizes are the design's (coins / gems / Stars), and one "Watch ad, spin again" a day (was 3).
- Server: `functions/dailySpin.js` has the design's 8 slices with their weights (100c 22, 5g 18, 250c 14, 20★ 14, 50c 20, 15g 7, 500c 4, 50g 1 = JACKPOT) and `MAX_AD_SPINS = 1`. `spinWheel` applies `squad.withStart` first, so a gems prize can't cancel the 600 starting gems. Tests: `cd functions && node dailySpin.test.js`. **Deploy `functions:spinWheel`**; until then the old server rules run against the new app wheel.
- App: `src/dailySpin.js` matches (slices, `MAX_AD_SPINS = 1`, `prizeCard` → title / amount / what). `DailySpinScreen` is the shell's: intro sky + warm glow + two puffs, "HI <NICKNAME>!", DAILY SPIN, the 366px gold wheel (scaled to fit) with 16 blinking bulbs and coin / gem / Star icons, the gold SPIN hub as the button, Mittens (our plush, mood idle → happy) under it when the screen is tall enough, the "You won!" / "JACKPOT!" popup with Collect, then the green "Watch ad, spin again" (the real rewarded ad unlocks the hub: "Spin unlocked! Tap SPIN.") and "Continue to my squad".
- The FREE creature reel is gone from App (`CreatureReelScreen.js` is unused now), and so is the CREATE prize; `creationDiscountPct` is no longer set by anything. The Jackpot achievement now means the 50 gems slice.
- `AdStrip`: the shell's dark purple 60px bar with a pastel rounded card and an "AD" tag behind the real banner. The shell's made-up cross-promo ads are left out.
- `OutlinedTitle` puts a hair space between A and I: react-native-svg on Android dropped the I ("DALY SPIN", "DALY STREAK"). Not yet seen on a device.
- Not seen on device after the last changes (the user stopped emulator testing). The wheel's idle look was checked once on the emulator and matched the design.

## Roster (2026-10-08)

The `TEMP-DEV-CATALOG` hook is removed from App.js: the app reads `creatures/*` from Firestore again. **Published 2026-10-08**: all 30 docs replaced, run with the user's service-account key (on their Desktop). The command, for next time: `GOOGLE_APPLICATION_CREDENTIALS=<key.json> node tools/plush-art/publish.mjs --catalog` (add `--dry` first to preview). The art is rendered in `tools/plush-art/out/`.
- **Players not reset yet.** Their `ownedIds` still use the old ids, which now point at different creatures. The user runs `--reset-players` (see "Where things stand").

## Backgrounds and splash (2026-10-08)

The user found the old pink/purple stage still behind every screen. The design puts one sky behind all its pages (Squishies Tab v2, Shop Screen v2, Full Roster): `linear-gradient(#8fd0ff, #b9e2ff 38%, #e6dcff 68%, #ffd6f4)`, five white cloud wisps and white dots every 26px.
- `CandyBackground` now draws that sky, so every screen built on it changed: Squishies, Shop, chest opener, Achievements, Stats, Streak, Create, Loading. The status bar icons are dark, except in the Crib.
- `SplashScreen` is the shell's: intro sky, Mittens hopping (our plush, mood `happy`, in place of the rive-rig kitten), the white "Squish Squad" title, a pink loading bar ("WAKING UP THE SQUAD… N%" → READY!), on by itself after about a second, and a tap skips it. No more TAP TO START or scattered creatures.
- Not seen on a device (the user stopped emulator testing).

## Open questions to ask the user (briefly)

- ~~Step 4: Google / Facebook?~~ Ruled 2026-10-08: **email only for now**. Leave the social buttons out.
- Crib rotate button: the design hides it inside the app (portrait only). We kept it because of the 2026-10-03 ruling for both orientations. Ask if they now want portrait only.
- The design's mascot is the rive-rig Mittens; we show our Mittens plush instead (splash, daily spin). On a brand-new install the splash has no Mittens until the catalog has been downloaded once.
- A full APK that also runs on 32-bit phones needs the project moved to a shorter path (see "The APK").
