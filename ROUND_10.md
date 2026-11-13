# PlushCrush — Round 10 (2026-11-13)

The Nov 13 design (`Squish Squad Prototype Nov13.zip`) inside the app, on top of everything from `develop`. All of it
is committed and pushed on the branch `claude/loving-hopper-e6b8xm`. The technical write-up is in
`webgame/README.md`.

## The new Main Menu and house, pixel for pixel

- The app runs the prototype's own code for the **Main Menu** and **Squad House v6** in a WebView. It doesn't redraw
  them in React Native, which could never match exactly.
- It works offline: React and the exact Google Fonts files are stored in the app.
- I compared the original prototype with the app's version pixel by pixel:

| Screen | Differing pixels |
|---|---|
| Main Menu, Pixel 9 size | 0 to about 300 |
| Main Menu, design size | 3 to about 100 |
| House, design size | about 150 |

  Every differing pixel is on a moving creature or the rain, caught a frame apart. The rooms, furniture, text and
  buttons are identical. Two loads of the original prototype differ from each other the same way.
- The Main Menu replaces the Lobby (Home's squish tab).
- The new house replaces the Crib: MY HOUSE walks into it, and so does every "open the Crib" in the app (the Lobby's
  Crib button, daily challenges).
- The old Crib code stays: Squishdoku and Squish Hop are still played in its rooms.

## Groups: only the groups you switch on

- Firestore `config/roster` has a `groups` field with one switch per group:
  `{ snack: true, fruit: true, …, heroes: false }`.
- Only creatures in groups switched on (`true`) appear anywhere:
  - the Menu (CREATURES and the house)
  - the Shop and its chests (the server rolls by the same switches)
  - the Squad
  - the games (Squishdoku ignored this before; it's fixed)
- A group that isn't listed counts as off.
- You can still hold back a single creature with `hidden: ['79']`.
- You can flip switches in the Firebase console, or from the command line:
  - `node tools/admin/roster.mjs --show spooky`
  - `node tools/admin/roster.mjs --hide spooky`

## All the design's creatures, synced to the design

- **33 new creatures**, for 119 in total.
- Ids are permanent, so the new ones got ids 86–118: Truffle, then the design's 86–117.
- Rarities and group rewards follow the Nov 13 design:
  - Corny is Snack Shack's reward (Chef Bun is now an Epic).
  - Pet Shop and Dreamland have no reward.
  - A Rainbow that isn't a reward (Avo, Duchess) drops from chests as a Legendary.
- 38 is now the **Sea Turtle**. The design gave the name Shelly to a new pet (99).
- **Prickle** left the design: he's retired and never out again. Players who own him keep him.
- The Menu and the house already have every creature's art. To show the new creatures in the app's own screens (Shop,
  Squad, games), their art has to be rendered and published (see "What you need to run").

## PLAY: our games, in the new design

- **PLAY** (and the GAMES tab) opens the design's own Mini Games page with our games:
  - Squish Time
  - **Squishdoku (600 levels)**
  - Squish Sort
  - Squish Stack
  - Squish Hop
- Each card shows the player's progress, for example "Level 37 / 600". PLAY opens that game.
- This is the remodel of the games screen: the same page, cards and buttons as the design.
- The Menu's "Mini Games" card shows our games too ("All 5 games ready!" with their icons).

## Yard games: only from the backyard

- The 7 yard games (Hoop Shot, Penalty Kick, Hopscotch, Bounce Up, Slide & Splash, Cornhole, Ping-Pong) are no longer
  on the PLAY page.
- In the house's **backyard** there's a **YARD GAMES** button in the same gold style as the MY HOUSE tab. It only
  shows in the backyard.
- The button opens the 7 games over the house. Back returns to the yard.

## Controlled from Firebase

- **Animations**, `gameCreatures/{key}` → `animations`: `false` and that creature never plays that animation. A natural
  fallback plays instead: plain sitting for a seat, another food for a food, otherwise idle.
  - `config/animations` switches one animation off for every creature.
- **House items and prices**, `gameItems/{itemId}`: price (`cost`), unlock level (`lv`) and `enabled`. All 788 items:
  the renovation catalog after the designer's own additions and removals, plus the 100 Beach items.
- Changes reach the phones within about a minute, even while the game is open.

## How it fits the rest of the app

- **SHOP** and the coin / gem pills open Home's Shop tab. Its squish tab comes back to the Menu.
- **The settings gear** opens the Lobby (Squad, level road, trophies, settings) with a **MAIN MENU** pill back.
- The game uses the player's real data: coins, gems, XP level, creatures with their finishes and growth stages, and
  the selected creature.
  - A creature picked on the Menu (CREATURES) becomes the selected squishy everywhere.
  - Coins spent in the house catalog, and the house layout, are saved to Firestore.
- Players in the guided tutorial stay on the Lobby and the old Crib until it's done, because the tutorial points at
  them. This is a setting in `src/game/flags.js`.

## What you need to run

1. Switch the groups on as things are now (everything out except Heroes and Elemental):
   ```
   GOOGLE_APPLICATION_CREDENTIALS=<key.json> node tools/admin/roster.mjs --groups
   ```
2. Fill Firestore with the creatures' animations and the house items:
   ```
   cd functions && npm install && cd ..
   GOOGLE_APPLICATION_CREDENTIALS=<key.json> node tools/firebase/seed-game-config.mjs
   ```
3. Deploy the functions (the server needs the new roster to roll chests correctly) and the rules:
   ```
   firebase deploy --only functions,firestore:rules
   ```
4. Art for the 33 new creatures in the app's own screens:
   ```
   DESIGN_DIR=webgame/.cache/Squish-Squad-Prototype-Nov13-96241839/squish-squad node tools/plush-art/render.mjs 86 87 88 …
   ```
   Then run `tools/plush-art/publish.mjs` with the same `DESIGN_DIR`.
5. Rebuild the app. New native parts (WebView screen, screen rotation) mean a JS reload isn't enough:
   ```
   npm run android
   ```

## Checked

- **Server:** the economy tests pass on the new roster, and so do the other functions tests. `verifyPurchase` needs
  `cd functions && npm install` first.
- **App unit tests:** Crib, Hop, XP, Sort, Squishdoku and Stack pass. `progression.test.js` already failed on
  `develop`: it can't find `./format`.
- **In-app game, in Chromium** the way the phone runs it (local files, offline): 27 checks pass. They cover the player
  data, every Firebase switch, groups, PLAY and the games list, picking a creature, the YARD GAMES button, the Android
  back button and saving.
- **Android build:** the JS bundle builds (2,026 modules). It wasn't run on a phone or emulator here: there's no
  Android SDK in this environment.

## Not done yet

- iOS (Android only for now).
- The design's other new screens: Shop v5, Chest Smash v2, Squad Select, the intro, the new cards.
- The yard games show "+N coins" but don't pay them yet.
- The Menu reloads each time it's opened, about 2 seconds. The first walk into the house takes longer.
