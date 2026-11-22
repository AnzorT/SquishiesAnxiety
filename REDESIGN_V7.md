# Redesign v7: the whole app in the new look, landscape

**Status (2026-11-14):** all steps built in one go ("do all the steps, I will approve at the end"), waiting for your review. Checked on the Pixel_8_Pro emulator. **Not done: the tutorial rewrite** (below). Nothing committed.

## Steps 1-10 results (2026-11-14)

**One switch for the orientation:** App.js `LANDSCAPE_SCREENS` + `landscape`. Every screen a player reaches in the new
design is landscape, from the first frame (app.json and the manifest are landscape now). The status bar is hidden in
landscape.

| Step | What it is now | Files |
|---|---|---|
| 1 Shop | Its own landscape screen from the Menu's SHOP and pills (not the old bottom tab). Tabs down the left (Chests / Deals / Gems with their badges), the shelf on the right: Free chest, Rare chest (ad), the daily deal, every group's chest with its 5 sizes, the Lucky meter; the Deals and Gems cards side by side with gold buttons. Chest details and "not enough" in a centred pearl panel. Same server moves and purchases as before. | `src/screens/royal/ShopChestsRoyal.js`, `ShopScreen.js` (`royal`), `ShopDeals.js` (`RoyalShop`, `wide`) |
| 2 Chest opening | The designer's Chest Smash v2 already plays sideways; its reveal is now two columns (the card left; copies, coins and COLLECT right). The chest drop is sized by the height. | `tools/chest/host.html` (`@media (orientation: landscape)`), `RewardFx.js` |
| 3 Settings | The gear opens a Settings screen in the new look: Sound, Nickname, "Your squad" (Achievements, Stats, Level Pass), More (feedback, replay tutorial, a tester's Test wallet, log out). The old Lobby no longer opens from the Menu. Screens opened from Settings go back to Settings. | `src/screens/royal/SettingsRoyal.js`, App.js `openFromSettings` |
| 3 Achievements, Stats, Level Road | Landscape layouts on the new page: badge carousel left / details right; favourite + most squished left / 8 tiles right; level card left / the road right. | `AchievementsScreen.js`, `StatsScreen.js`, `LevelRoadScreen.js` |
| 4 Dailies | Daily Spin: the wheel left, greeting and buttons right. Streak: hero + today + button left, the prizes right. Daily Challenges: a centred panel. LEVEL UP fits as it was. | `DailySpinScreen.js`, `StreakScreen.js`, `DailyChallengesSheet.js` |
| 5 Squish Time | The 3D stage sized by the height, the creature in the middle, the x2 / x3 / x4 boosts in a panel at the right, no banner ad. | `SquishScreen.js` |
| 6-9 Mini-games | Each game plays in a centre panel (its own screens, unchanged), framed by the new page: its name on the left, "How to play" on the right. **My reading, tell me if wrong:** the games' boards are not re-laid out sideways (the plan's "board on one side, goal on the other"); that would be a rewrite of each game's screens. | `src/royal/GameFrame.js` (`useGameDims`), App.js `GAME_FRAME` |
| 10 Sign-in, splash | Sign-in in two columns (Mittens + title left, the card right). The splash mascot sized by the height. | `AuthScreen.js`, `SplashScreen.js` |

**Not done:**
- **The tutorial rewrite.** A new player in the guided tutorial still gets the old portrait Lobby and Crib until it's finished (the tutorial points at them; `NEW_DESIGN_DURING_TUTORIAL = false`). Then the landscape Menu takes over.
- The old portrait screens (Lobby, Squishies, Squad, the Shop tab) are still in the code, only reachable from that tutorial path. Not removed.
- The Game Park's clips still show the games as before (they look the same inside the frame's centre panel).
- The emulator check covered: Shop (all tabs, a free chest opened to COLLECT), Settings and the three screens from it, Squish Time, Squish Sort (hub, map, a level), the Game Park, cold start, log out and log in. Not opened on the emulator this round: Daily Spin and Streak (they only come up once a day), Stack, Hop and Squishdoku inside the frame, the Galaxy A15.

## Step 0 result (2026-11-14): foundation

- **The menu's look in React Native:** [src/royal/](src/royal/) (`import { Plaque, Btn, Orb, Pill, Lettering, PageBg, PageHeader, Stage } from '../royal'`).
  - `Plaque` covers the 7 finishes (vel, gold, bronze, wood, amy, pearl, rainbow) with the gold rim, ink outline, 3D lip, top shine, bottom shade, diamond tips, sparkles and diamond pattern. Same numbers as `main-menu.js`'s CSS.
  - `Lettering`: the menu's `ft()` in SVG, in the same 8 styles. It draws at once with an estimated width, then adjusts.
  - `Btn` (gold or velvet, with optional glow and glint), `Orb` (back, close, gear, pause, restart and hint icons), `Pill` (coins and gems with their pictures), `PageBg` and `PageHeader` (a full-screen page like the Level Pass).
  - `Stage` scales the design's 393-tall units to the phone, as the menu does (k = screen height / 393).
- **Gallery** (debug builds only): `adb shell am start -a android.intent.action.VIEW -d "com.plushcrush.app://royal" com.plushcrush.app`. It puts the menu's top bar and PLAY exactly where the menu draws them. On the Pixel_8_Pro they match the WebView menu: same rims, lip, tips, lettering and pills.
- **Menu pages:** `webgame/app/pages/*.js` load after `menu.js` (`build.mjs`).
  - A page registers as `SquishMenu.pages.<name> = (x, opts, P) => …`. `P.page(x, { title, note, right, body })` gives the header and the back orb; Android back closes it.
  - `SquishMenu.open(name)` opens a page, and the app can too (GameScreen `page` prop → `{ type: 'page' }`).
- **The request link:** `SquishApp.ask(what, payload)` → a Promise. GameScreen sends it to `onAsk`, and App.js `handleGameAsk` answers:
  - `'squad'` `{ move, args }`: any squad server move (`move` is now exported from `src/squad/api.js`)
  - `'buy'` `{ key }`: a Play purchase
  - `'price'` `{ keys }`: store prices
  - anything else: error `unknown_ask`
  Checked end to end on the emulator.
- **Black cutout strip:** the window background is black (styles.xml), so the strip by the camera in landscape is no longer white.
- **Fixed: a stray character change.** When the app's start data reached the page late (it happens on Android), the menu's demo pick (Mittens) was sent to the app as the player's choice, and the test account's character changed from Frybo to Mittens. The bridge now reports nothing until the app's player is in, and refreshes the engines' caches when the data lands. Frybo was put back through Characters.
- **Tests:** webgame smoke 3/3, bridge 37/37 (new: the page framework, App.ask, the late-start case).

## Your rulings (2026-11-14)

- Every screen from the old version gets the new design: the Nov 13 Main Menu's look (purple velvet panels, gold rims, gold buttons, the menu's own lettering) and **landscape**.
- **The mini-games and Squish Time too:** landscape and the new look.
- All screens are in scope ("all together"). Plan first, then **one step per session**, each shown on the emulator before the next.

## Already done (round 11)

- Main Menu, house, Game Park (PLAY), Level Pass, Characters: landscape, new look.

## How it's built

Everything ends up as **one look in two places**:

1. **Menu-type screens are pages in the game's WebView** (`webgame/app/`), next to the Main Menu. They use the menu's own style code (`main-menu.js`), so they match it exactly. They also open without the phone turning or the WebView reloading. The app (React Native) keeps the parts that need the phone or the server: purchases (Google Play), ads, sign-in and every server move. The page asks, the app does it and answers (the same link as the Level Pass's CLAIM).
2. **The games stay in React Native** (their engines are there), redrawn sideways with a **React Native copy of the menu's style**: the same panels, buttons, lettering and colours, built once in step 0 and used by every game.

At the end the whole app is landscape: no screen turns the phone anymore.

## The screens

| Today | Becomes | Step |
|---|---|---|
| Shop: Chests (Free chest, group chests, keys), Deals, Gems, Remove Ads, "Not enough coins" | One landscape Shop page, from the designer's Shop v5 (portrait) laid out sideways: tabs on the left, the shelf of chests / deals / gem packs on the right | 1 |
| Chest opening (ChestOpener, ChestSmash) + what came out (RevealShow) | The designer's Chest Smash v2, landscape; used by the Shop, the Level Pass and the daily gift | 2 |
| Settings gear → the old Lobby (Squad, level road, trophies, gear) + Settings sheet (music, sounds, nickname, feedback, stats, replay tutorial, log out) | A Settings page on the menu; the old Lobby retires | 3 |
| Achievements (badge carousel), Stats | Landscape pages in the same carousel style as the Game Park | 3 |
| Daily Spin + its creature reel, Daily Challenges, Daily Streak, LEVEL UP card | Landscape pages / pop-ups over the menu | 4 |
| Squish Time (the 3D squish, combo, rewards, x2 ads) | Landscape: the creature in the middle, combo and coins on the sides | 5 |
| Squishdoku (hub, level map, regular, Blitz) | Landscape: the board on one side, goal / clock / hints on the other | 6 |
| Squish Sort (hub, fridge / cupboard, counter) | Landscape: fridge on one side, the counter beside it | 7 |
| Squish Stack (hub, three cushions) | Landscape: the cushions spread wide, buttons at the side | 8 |
| Squish Hop (hub, rug of cushions) | Landscape: the rug on one side, goal and buttons on the other | 9 |
| Log in / Register, Verify email, Splash, Loading | Landscape, the new look | 10 |
| The guided tutorial (it points at the old Lobby and Crib) | Rewritten for the new screens (menu, PLAY, Shop, house) | 10 |
| Old screens no longer used (Lobby, GamePicker, Squishies, Squad, Level road, portrait tab bar) | Removed; the whole app locked to landscape | 10 |

After steps 5-9 I re-record the Game Park's game clips, since they show the games sideways now.

## The steps

0. **Foundation.** The React Native copy of the menu's style (panel, gold and velvet buttons, round orbs, the lettering, the page header with back + title + coin/gem pills, the page background), checked side by side with the WebView menu. A page framework in `webgame/app/` for the new menu pages, with the app link for buying, server moves and ads.
1. **Shop.** All tabs, buying through the app (Play Billing, the `squad` server), "not enough" pop-up, Remove Ads, the offer timers.
2. **Chest opening.** Chest Smash v2 landscape, the reveal, duplicates and set rewards, used everywhere a chest opens.
3. **Settings, Achievements, Stats.** The gear opens Settings on the menu; trophies and stats move there.
4. **Daily screens.** Spin, reel, challenges, streak, LEVEL UP.
5. **Squish Time.**
6. **Squishdoku.**
7. **Squish Sort.**
8. **Squish Stack.**
9. **Squish Hop.**
10. **Sign-in, splash, loading, tutorial, clean-up**, the whole app locked landscape, the new game clips.

Each step ends with the emulator check and the tests. The all-device APK is rebuilt each time so it can go on the Galaxy A15. Nothing is committed unless you ask.

## Questions for you (answered with my picks: GO without other answers, 2026-11-14)

- Banner ad: bottom strip on menu pages only, none during games.
- Squishdoku and Hop keep their own rooms as backdrops.
- Create-a-squishy stays out.

The questions as asked:

1. **Banner ad in landscape.** Today it's a strip along the bottom. Sideways, that strip takes about 12% of the screen's height. Keep it at the bottom on menu pages only (none in games)? Or somewhere else?
2. **Squishdoku and Hop backdrops.** They're played in the old Crib's rooms. Sideways, keep their own rooms as backdrops (my pick), or play them in the new house's rooms?
3. **Create-a-squishy** (photo → your own squishy) can't be reached anymore since the Squishies tab left. Leave it out (my pick), or bring it back somewhere?

## My readings (tell me if any is wrong)

- "The new designs" means the Main Menu's style. The designer's newer portrait pages (Shop v5, Chest Smash v2, Squad Select v2) give the **content**; the layout is mine, sideways.
- The economy, prices and server rules don't change. Only how the screens look and sit.
- The old Crib stays only as the games' backdrops (question 2).
