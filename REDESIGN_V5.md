# Redesign v5: the rest of "Squish Squad App.html"

Start here in a new session. The user is short on tokens, so:
- read only the design sections you're porting;
- check visuals with screenshots (`tools/shop-art/shot.mjs`) rather than reading whole CSS files;
- keep each session to one step below.

## Where things stand (2026-10-07)

- The **economy** is already switched to the design: chests, gems, Stars, finishes and growth. See `SQUAD_ECONOMY.md`.
  - Screens: `src/screens/ShopScreen.js`, `ChestOpener.js`, `RevealShow.js`, `SquishiesScreen.js`.
  - Shared UI: `src/squad/ui.js` (Ringed, CandyBtn, BtnText, PriceBtn, Chip, Bob, Chest, Coin / Gem / Star icons).
- **Not deployed yet:** the user runs `firebase deploy --only functions:squad,functions:verifyPurchase,firestore:rules` (the auto-mode classifier blocks the assistant). Until then, chest and Stars moves fail.
- **Nothing committed** since `b588cc8`. Commit only when the user asks.
- The user ruled (2026-10-07): restyle the **whole app** to the design, in the order below.

## The design files

`node tools/shop-art/extract.mjs` decodes `Squish Squad App.html` into `tools/shop-art/design/` (git-ignored).
- Screenshot any page: `node tools/shop-art/shot.mjs "<page>.dc.html" out.png [--js "…"]`. Pages scroll inside a `overflow-y:auto` div; see `SQUAD_ECONOMY.md` for the scroll trick.
- The app shell (bottom nav, login, daily spin, ad banner) is in the bundle's `__bundler/template`. To get it, decode it the way `extract.mjs` does and save it as `design/App Shell.html`. Add that to `extract.mjs` first.
- Each `.dc.html` is markup with `{{ bindings }}` plus a `<script type="text/x-dc">` class. Its `renderVals()` holds the data.

| Step | Design page | Size | Replaces |
|---|---|---|---|
| 1 ✅ | App shell + `Squishies Tab v2` (already ported as `SquishiesScreen`) | 61 KB shell | `HomeScreen` as the main screen, plus a Squishies / Shop bottom nav. **Done 2026-10-07**, see below |
| 2 ✅ | `ASMR Creature Squash v5.dc.html` | 323 KB | `SquishScreen` UI. Keep the 3D squish stage and its engine; restyle only the HUD and overlays. **Built 2026-10-07, not yet seen on device**, see below |
| 3 | `Squad Crib Vertical v2.dc.html` | 203 KB | `CribScreen` portrait layout. The Crib's model and art stay (`src/crib/`). |
| 4 | Shell login / register | in the shell | `AuthScreen` (email, plus Google / Facebook if the user wants the SDKs) |
| 5 | Shell daily spin + ad banner | in the shell | `DailySpinScreen` restyle. Skip the made-up cross-promo ads unless the user wants them. |
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
- Header: SQUAD, LV pill, then Crib, trophy, settings and the HomeMenu (daily, streak, stats).
- Tutorial: App reports `screen: 'store'` while the Shop tab is open. Targets: `store` is the Shop nav item and `storeBack` is the Squishies nav item (`box` is no longer used). `card:<id>` is a Collection cell; the screen scrolls it into view when the guide points at it. `sheetPlay` is the sheet's SQUISH; steps use the `squadSheet` report. `tabs` is the Squishies / My creations switch and `createCard` is in My creations; both scroll the list to the top.
- Not checked on device: the full tutorial run (replay it from Settings), and the ad strip (the test account is ad-free).
- Orphaned now, delete when convenient: `SkeletonCard`, `MysteryBoxBanner`, `RemoveAdsButton`, `CreateOwnCard` / `CustomCreatureCard` (but `CustomArt` in the same file is used), and `CardPager` once those are gone. `RemoveAdsSheet` is still rendered in App but nothing opens it any more (Remove Ads is in Shop › Gems). `CandyTabs` is still used by AuthScreen. A backup of the deleted `HomeScreen.js` was only kept in that session's scratchpad.

## Step 2 as built (2026-10-07)

Most of the squish HUD already followed an earlier pass of the same design (back + gear buttons, bonus bar, the ×2/×3/×4 gold ad buttons, coin pops, ×N COINS! flash), so only the v5 differences were changed:
- Background: new `src/squad/SkyBackground.js`, v5's sky (blue → lavender → pink, a pink glow from the bottom, a white glow behind the toy, three cloud puffs, white dots every 26px). Static memoized SVG, as CandyBackground.
- Coin pill: shows `+N EARNED` for this session (from 0), not the wallet total.
- Gear: a white dropdown card under the gear with no scrim (v5), but it keeps all our settings (3 sounds, FPS, vibration, poke strength and direction) and a small ✕, which is the tutorial's `gearClose` target.
- Gesture hints: v5's white hands with a thin purple outline, a plain pink touch ring and a glowing purple caption (no pill). The rotate caption still says "2 FINGERS TO ROTATE" (v5 says HOLD TO ROTATE, which isn't our gesture). The GAMEPLAY SETTINGS pointer is kept and uses the same caption style.
- Not checked on device: on 2026-10-07 the emulator running then (`Pixel_10_Pro_XL`, emulator-5554) sat on "Loading from 10.0.2.2:8081…" even though Metro served the bundle fine to the PC. That's probably the 10.0.2.2 issue from the device notes.
- Screenshot the design's squish screen: in `shot.mjs --js`, get the dc instance from a button's `__reactFiber…` → `.return` chain → `stateNode.logic`, stub `SquishGuide.show` and `logic.tutGo`, then `setState({ screen: 'squish', … })`. The bonus clock is `window.__squishClock`.

## Open questions to ask the user (briefly)

- Step 4: real Google and Facebook sign-in (needs their console setup), or email only for now?
