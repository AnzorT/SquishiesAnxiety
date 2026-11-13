# webgame: the new design inside the app

The app's Main Menu and house are the designer's prototype itself (`Squish Squad Prototype Nov13.zip`), running in a
WebView (`src/game/GameScreen.js`). The screens are drawn by the prototype's own code, so they match the design
pixel for pixel. Nothing is redrawn in React Native.

- **Main Menu** (`Main Menu.dc.html`, landscape) replaces Home's squish tab (the Lobby).
- **Squad House v6** replaces the Crib. MY HOUSE in the menu walks into it, and so does every "open the Crib" in the
  app (the Lobby's Crib button, daily challenges).
- **PLAY / GAMES** opens the design's own Mini Games page with the app's games:
  - Squish Time (the design's card)
  - Squishdoku (600 levels), Squish Sort, Squish Stack, Squish Hop, each card showing the player's level
  - PLAY on a card opens that game (the app's own screens; Squishdoku and Hop still play in the old Crib's rooms,
    which is why `src/crib` stays).
  The list and the progress lines come from `src/game/player.js` (`menuGames`); the card pictures are drawn in
  `webgame/app/games.js` in the style of the design's own game icons.
- **The 7 yard games** (Hoop Shot … Ping-Pong) are only in the house: a YARD GAMES button (the menu's gold tab style)
  in the backyard opens the same page with them, over the house. They're no longer on the Mini Games page.
- **SHOP** (and the coin / gem pills) opens Home's Shop tab, as before; its squish tab comes back to the Menu.
- **The settings gear** opens the Lobby (Squad, level road, trophies, settings…) with a MAIN MENU pill back.
- Players in the guided tutorial stay on the Lobby and the old Crib until it's done: the tutorial points at them
  (`src/game/flags.js`).

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
| `config/roster` → `groups` | **Which groups are out**: `{ snack: true, fruit: true, …, heroes: false }`. Only the groups switched on (`true`) appear anywhere: the Menu (CREATURES, the house), the Shop's chests, the Squad, the games. A group not listed is off. `hidden: ['79']` still holds back single creatures (ids). The server rolls chests by the same switches (`functions/squad.js` `hiddenOf`). `node tools/admin/roster.mjs --groups` writes the switches as things are now; `--show spooky` / `--hide spooky` flip one. |

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

## The roster (functions/squad.js)

The app's 119 creatures: the Oct 19 design's 86 (ids 0-85) and the Nov 13 design's 33 new ones (ids 86-118: Truffle,
then the design's 86-117). Ids are permanent (the collection is keyed by them), so the app's ids differ from the
design's; the game and the app talk by key (`webgame/app/roster.js`, `src/game/player.js`).

- Rarities and group rewards follow the Nov 13 design (`REWARD_KEYS`: Tutti, Pearl, Sprout, Aurora, Sugarplum, Corny;
  Pet Shop and Dreamland have none). A Rainbow that isn't a reward (Avo, Duchess) drops from chests as a Legendary.
- 38 is the Sea Turtle (it was Shelly; the design gave the name Shelly to a new pet, 99).
- Prickle (15) left the design: retired (`RETIRED`), never out again; a player who owns him keeps him.
- A new creature appears in the app's own screens once its art is published (`creatures/{id}`):
  `DESIGN_DIR=webgame/.cache/Squish-Squad-Prototype-Nov13-96241839/squish-squad node tools/plush-art/render.mjs 86 87 …`
  then `tools/plush-art/publish.mjs` (with the same `DESIGN_DIR`). The Menu and the house have every creature's art
  already.

## The app <-> game link

The app hands the game its state before the page loads (`window.__SQUISH_INIT__`). After that, both sides talk in
messages (`webgame/app/bridge.js`).

**The player belongs to the app.** The bridge writes it into the prototype's own localStorage save before its
scripts run:

- `level` (the XP level), `coins`, `gems`, `owned` (creature keys), `col` (their finishes and growth stages), `sel`
  (the selected creature), `hiddenKeys` (creatures in groups switched off), `games` (the Mini Games list), `house`
- `house` is the saved layout, `users/{uid}/crib/house6`

**App → game** (`SquishApp.receive`):

| Message | What the game does |
|---|---|
| `state` | Updates `coins`, `gems`, `level`, `owned` and `hiddenKeys` live |
| `config` | Applies the admin's config (`config/game`) |
| `screen: 'house'` | Walks into the house the way MY HOUSE does |

**Game → app** (`ReactNativeWebView.postMessage`):

| Message | What the app does |
|---|---|
| `ready` | Starts sending queued messages |
| `coins {coins, delta}` | Writes the delta to `users/{uid}.coins` (catalog buys) |
| `house {data}` | Saves the layout |
| `open {what: 'shop' or 'settings'}` | Opens the shop or settings |
| `play {mode, key}` | `mode` 'squish': Squish Time with that creature; 'squishdoku', 'sort', 'stack', 'hop': that game |
| `select {key}` | The creature picked on the Menu (CREATURES) becomes the selected squishy (`lobby.sel`) |
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
- The other new screens: Shop v5, Chest Smash v2, Squad Select, Intro, the cards. SHOP opens the app's current Shop.
- The 33 new creatures' art for the app's own screens (render + publish, above).
- The house fills its rooms up to 4 creatures from the design's default list when you own fewer, exactly like the
  prototype.
- Yard games give "+N coins (preview)" in the design but don't pay out. That isn't wired to the app's coins.
- The game screen is reloaded each time it's opened (about 2 s for the menu). The house has to load its own engines
  on top of that, which takes longer the first time.
