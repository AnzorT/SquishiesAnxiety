# PlushCrush → Unity: port plan

Started 2026-11-22. A **fresh** Unity project (not the earlier local one from `UNITY_MIGRATION_PLAN.md`), rebuilding the
game natively in Unity. The goal is a 1:1 match with the app as it is today: same screens, same look, same rules.

## Decisions so far

| Decision | Choice | Why |
|---|---|---|
| Starting point | Fresh Unity 6 project (6000.3) in `unity/` | User's choice (2026-11-22) |
| Prototype screens (menu, house, park, chest smash) | Rebuilt natively in Unity, not a WebView | User's choice; a WebView would keep the web performance cost |
| Still art | Rendered by Chromium from the game's own files → PNG | Pixel-identical. Unity's SVG importer can't draw the blurs, blend modes and the fabric-texture filter the art uses |
| UI | UI Toolkit, built in C# | Flexbox, like React Native; text-based, reviewable |
| UI units | 1 unit = 1 dp; 832 × 384 (Galaxy A15 landscape), scaled by screen height | Same numbers as the React Native styles |
| App id | `com.plushcrush.app` | `google-services.json` is keyed to it. A Unity build replaces the React Native app on a phone |
| Backend | Unchanged: Firebase (Auth, Firestore, Storage, Functions) | Unity only replaces the client |

## How "1:1" is checked

1. **Reference screenshots** of the real game at the A15's exact size (2340 × 1080 px) live in
   `Assets/_Project/Reference/`. They're frozen (fake clock, seeded randomness, animations held) so they're the same on
   every run: `node tools/unity-port/capture-references.mjs`.
2. In Unity: set the Game view to **2340 × 1080**, press Play, open **PlushCrush > Reference Overlay**, pick the
   screenshot, and slide the opacity. A rebuilt screen is done when nothing moves as the overlay fades in and out.
3. Animations: the same frozen captures at several moments (0 s, 0.5 s, 1 s…) compared with Unity at the same moments.

Known sources of small differences, each checked on the first screen: text drawn by Unity's text engine instead of
the browser's; semi-transparent edges blended in linear color (switch the project to Gamma if they differ visibly).

## What the app is (the port's scope)

**Drawn by React Native** (`src/screens`, `src/components`, mostly `react-native-svg` + gradients, no filters):
Splash, Auth, Verify email, Main (Home tabs), Lobby, Settings, Achievements, Stats, Shop (deals, chests), Daily spin,
Daily challenges, Streak, Level road, Level-up card, Create (custom creatures), Chest opener, Loading, toasts,
interstitial ad. Mini games: **Squishdoku** (600 levels), **Squish Sort**, **Squish Stack**, **Squish Hop**.
**Squish Time**: the 3D squish toy (three.js, Tripo `.glb` models).

**Drawn by the designer's prototype** (`webgame/`, HTML + SVG in a WebView): Main Menu (HUD, level crest, PLAY →
Game Park carousel), Level Pass, Squad House v6 (8 rooms with animated creatures), the 7 yard games, chest smash.

## The hard parts, and the approach

1. **The menu and house scenes are generated, not drawn.** `main-menu-scene.js` builds the scene as SVG from the
   level (1–30) and the season (sunny / rainy / snowy). Colors shift continuously with level, rooms open at set levels.
   - **Plan:** render each (level, season) as a few layered PNGs (back: sky, sea, ground, back trees, house; front:
     path, front trees, bushes), with weather, vignette, lock signs and the creature drawn natively on top. 90
     variants is too much to ship in the app, so only the player's current one is downloaded from Firebase Storage
     and cached. Pixel-identical, and small to ship.
   - Alternative: port the generator to C# and draw vectors at runtime. Continuous, but loses the blurs.
2. **The creatures are alive.** `plush-rig25.js` deforms each creature's SVG every frame (idle, look, hop, dance,
   squish) as one soft body.
   - **Plan:** port the rig's math to C#, deforming a mesh made from the same SVG paths, with the fabric texture as a
     texture in the creature's material. This is the biggest fidelity risk: it gets its own side-by-side check, frame
     by frame.
3. **Animations everywhere** (CSS keyframes, JS timers): rewritten as C# tweens, timed from the original's numbers.
4. **Squish Time**: glTFast loads the same `.glb` models; the squish physics (`src/engine`) is ported line by line.
5. **Fonts**: the app's three (Baloo 2, Nunito, Fredoka) are in. The prototype also uses about a dozen display fonts
   (Cherry Swash, Alfa Slab One, Pacifico…); their TTFs come from Google Fonts' GitHub repo when a screen needs them.
6. **App size**: the exported art is large (creatures alone: 119 MB as PNG). It doesn't go in `Resources`; it ships
   through Addressables, with most of it downloaded on demand.

## Build order

| Phase | What | Status |
|---|---|---|
| 0 | Project, first-open setup, reference screenshots, art export | **Done** (this session) |
| 1 | Main Menu, still: scene at level 1 + HUD, checked 1:1 against `menu.jpg` | Next |
| 2 | Main Menu, alive: weather, the creature rig, PLAY → Game Park | |
| 3 | Characters, Shop, Settings, Achievements, Level road | |
| 4 | Squish Time (3D) | |
| 5 | Squad House (8 rooms) | |
| 6 | Mini games: Squishdoku, Sort, Stack, Hop; yard games | |
| 7 | Firebase, ads, billing wired in (can start any time once the SDKs are imported) | |

Game logic (economy, XP, levels, achievements) is ported into `PlushCrush.Core` as plain C# with tests, alongside
whichever screen first needs it.

## What needs you

- [ ] **Open the project** in Unity 6000.3 (with the Android module) and send a screenshot of the first screen
      (the setup check). See `README.md`.
- [ ] **Firebase and AdMob SDKs** (phase 7): imported in the Editor by hand, once.
- [ ] **A test account** for capturing the signed-in React Native screens as references. Best given as an environment
      secret, not in chat.

## Regenerating

```bash
node webgame/build.mjs --out webgame/test/out/webgame   # the game pages, as the phone has them
node tools/unity-port/capture-references.mjs            # reference screenshots -> Assets/_Project/Reference/game
node tools/unity-port/export-art.mjs                    # creature art -> Assets/_Project/Art/Generated (not in git)
```
