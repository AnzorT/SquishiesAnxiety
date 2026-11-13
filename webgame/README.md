# webgame: the new design inside the app

The app's Main Menu and house are the designer's prototype itself (`Squish Squad Prototype Nov13.zip`), running in a
WebView (`src/game/GameScreen.js`). The screens are drawn by the prototype's own code, so they match the design
pixel for pixel. Nothing is redrawn in React Native.

- **Main Menu** (`Main Menu.dc.html`, landscape) replaces the app's Home.
- **Squad House v6** replaces the Crib. MY HOUSE in the menu walks into it.
- The old Home and Crib are still in the code:
  - Players in the guided tutorial stay on them until it's done (`src/game/flags.js`).
  - The menu's settings gear opens the old Home, for the features the new design has no screen for yet.

## Build

```
node webgame/build.mjs        # -> android/app/src/main/assets/webgame (also runs before every Android build)
npm run android               # builds the game, then the app
```

The build:

1. Unpacks the zip into `webgame/.cache`.
2. Copies only what the shipped pages use. That's about 41 MB: the pages, their scripts, and the creature art and
   house data.
3. Swaps internet files for local copies, so it runs offline:
   - React comes from `webgame/vendor` (the same file unpkg serves).
   - Google Fonts come from `webgame/vendor/css` (the same .woff2 files Google serves to Chrome). Both were fetched
     once by `node webgame/vendor.mjs`.
4. Adds the app layer (`webgame/app/*`) and the Firebase hooks (`webgame/patches.mjs`).

**A new design zip:**

1. Put it in the repo root and point `PROTOTYPE_ZIP` in `webgame/lib/prototype.mjs` at it.
2. Run `node webgame/tools/dump-config.mjs` to refresh the creature, animation and item list.
3. Run `node webgame/build.mjs`. If the designer changed one of the hooked spots, the build stops and names it.
4. Run the tests below.
5. Run the Firestore seed (next section) so new creatures, animations and items show up there.

## Firebase control

| Firestore (console) | What it controls |
|---|---|
| `gameCreatures/{key}` (118 docs, e.g. `mittens`) | `animations.<id>`: `false` and this creature never plays that animation. Its fallback plays instead: another seat for a seat, another food for a food, otherwise its next move or idle. `enabled`: `false` hides the creature (nobody owns it). `rarity`: 0 common … 4 rainbow. `gait`: the walk style, one of the list in `gaits`. |
| `gameItems/{itemId}` (788 docs, e.g. `LIV-011`, `BCH-004`) | `cost` (coins), `lv` (unlock level), `enabled`: `false` takes it out of the catalog. Already-bought copies stay in the house. `designCost` / `designLv` show the design's values. |
| `config/animations` | `on.<id>`: `false` switches that animation off for every creature. |

- Each animation has one switch. Steps in and out (`bedin`, `bedout`, `bedwake`) follow their main animation (`bed`).
- `idle` can't be switched off: everything falls back to it.

**How changes reach the app.** The scheduled function `rebuildGameConfig` (`functions/gameConfig.js`) boils all of
this down into `config/game`, a small doc of only what differs from the design. The app listens to it, and the running
game applies a change straight away: prices re-price the open catalog, and animations switch on the creature's next
move. A console edit reaches the phones within about a minute.

**Setup, once (needs the service-account key and the Firebase CLI):**

```
cd functions && npm install && cd ..
GOOGLE_APPLICATION_CREDENTIALS=<key.json> node tools/firebase/seed-game-config.mjs   # --dry to preview, --reset for design values
firebase deploy --only functions:gameCreatureWritten,functions:gameItemWritten,functions:gameAnimationsWritten,functions:rebuildGameConfig,firestore:rules
```

**Re-running the seed:**

- It adds new creatures, animations and items.
- It keeps every change you made in the console.

**With no config at all:** the game is exactly the prototype.

## The app <-> game link

The app hands the game its state before the page loads (`window.__SQUISH_INIT__`). After that, both sides talk in
messages (`webgame/app/bridge.js`).

**The player belongs to the app.** The bridge writes it into the prototype's own localStorage save before its
scripts run:

- `level`, `coins`, `owned` (creature keys), `house`
- `house` is the saved layout, `users/{uid}/crib/house6`

**App → game** (`SquishApp.receive`):

| Message | What the game does |
|---|---|
| `state` | Updates `coins`, `level` and `owned` live |
| `config` | Applies the admin's config (`config/game`) |
| `screen: 'house'` | Walks into the house the way MY HOUSE does |

**Game → app** (`ReactNativeWebView.postMessage`):

| Message | What the app does |
|---|---|
| `ready` | Starts sending queued messages |
| `coins {coins, delta}` | Writes the delta to `users/{uid}.coins` (catalog buys) |
| `house {data}` | Saves the layout |
| `open {what: 'shop' or 'settings'}` | Opens the shop or settings |
| `play {mode: 'squish', key}` | Opens Squish Time with that creature |
| `backUnhandled` | Android back on the bare menu: leave the app |
| `error` | Logged |

## Tests (Chromium, the way the phone runs it: file://, offline)

```
npm run webgame:test      # smoke (no errors, no missing files, no internet) + bridge (the link and every Firebase switch)
npm run webgame:pixels    # pixel-perfect check (NODE_USE_ENV_PROXY=1 behind a proxy: the reference loads Google Fonts)
```

`webgame/test/pixel-diff.mjs` compares the design prototype as the designer runs it against the app's build, frozen
at the same moment. Results on Nov 13:

| Screen | Differing pixels |
|---|---|
| Main Menu, phone size (924×412) | 0 |
| Main Menu, design size (852×393) | 3 of 334,836 |
| Main Menu, the prototype's test page | 3 of 1,024,000 |
| House, design size (852×393) | 147 of 334,836 |
| House, the prototype's test page | about 6,000 of 1,024,000 |

Every differing pixel is on a moving creature (a breathing or walking frame apart). The room, walls, furniture, text
and buttons are identical. Two loads of the prototype itself sometimes differ the same way.

## Not done yet

- iOS: the WebView source is Android-only (no `ios/` folder yet).
- The other new screens: Shop v5, Chest Smash v2, Squad Select, Intro, the cards. SHOP opens the app's current store.
- The creature roster: the app sells 30 creatures, the design has 118.
  - The game shows the app's owned creatures that exist in the design. Prickle isn't in it.
  - The house fills its rooms up to 4 creatures from the design's default list when you own fewer, exactly like the
    prototype.
- Yard games give "+N coins (preview)" in the design but don't pay out. That isn't wired to the app's coins.
- The game screen is reloaded each time it's opened (about 2 s for the menu). The house has to load its own engines
  on top of that, which takes longer the first time.
