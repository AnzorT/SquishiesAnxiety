# Squad economy (2026-10-06 design drop)

> **2026-10-09:** Stars were dropped everywhere (server, database, UI). Duplicates and finished sets now pay coins, growth is XP only, and finishes come from chests only. See ECONOMY_V2.md. The Stars rules below are history.

The switch from per-creature tokens, keys and the Key Shop to the design's chests, gems, Stars and finishes. The spec is `Squish Squad App.html` (a bundled page; its screens and `squad-store.js` are decoded from the `__bundler/manifest` script: gzip + base64 per resource) and `handoff/squad-store.js` in the zip.

## Rulings (user, 2026-10-06)

- Switch the economy now, **before** the rive-rig animation migration.
- Start with 600 gems and 180 Stars. Remove Ads stays $1.99.
- Real money: the six gem packs (`gems_80` … `gems_12000`) and the existing Remove Ads. Season Pass, Starter Pack, Mega Bundle and VIP come later.
- Chest rolls, gems, Stars and the collection are **server-side** (the `squad` Cloud Function).
- Tokens, keys and the Key Shop are **replaced**. Test players are reset again.

## The rules (`functions/squad.js`, tested by `functions/squad.test.js`)

- **Roster:** 79 creatures in 8 sets plus the Spooky Squish season. Ids 0-29 are the current plush 30. Rarity: Common, Rare, Epic, Legendary, plus one Set reward per set. Only creatures with a catalog doc (that is, with art) drop or are sold.
- **Chests:** Basic 250, Silver 600 and Gold 1,200 coins. Crystal 150, Rainbow 300 and Season 120 gems. Odds are in `CHESTS`.
  - Gold, Crystal and Rainbow count toward pity: the 30th is a Legendary.
  - Every 10th chest without an Epic gives one.
  - Unowned creatures are 3× as likely.
- **Free chests:**
  - 3 free Basic chests a day for a video each.
  - The Daily Deal is a Crystal chest for 105 gems, once a day.
  - Bought chests wait in My Chests (`chests`) until opened.
- **Finishes:**
  - Shiny 2%, Rainbow 0.5%, Golden 0.1%, tripled in a Rainbow chest.
  - Shiny and Rainbow can also be bought for Stars (3× and 8× the creature's Star price). Golden can't.
- **Stars:**
  - Duplicates pay 5 / 15 / 40 / 120 Stars (40 for a Set reward), doubled for a finish.
  - Finishing a set gives its reward creature plus 50 Stars.
- **Buying a creature:**
  - Coins: 1,500 / 4,000 / 9,000. Legendaries come from chests only.
  - Stars: 40 / 100 / 250 / 700.
  - Today's Picks (3 a day) are 20% off.
- **Growth:** Baby → Grown (100 XP + 10 Stars) → Best Friend (300 XP + 40 Stars). The app writes the XP (`xp.<id>`) from squishing.
- **Gems → coins:** 100 → 2,000, 250 → 5,500, 500 → 12,000.
- **Gem packs:** $0.99 80, $4.99 450, $9.99 950, $19.99 2,000, $49.99 5,500, $99.99 12,000. The first purchase of each pack gives double.
- **Start:** every player gets 600 gems and 180 Stars, on their first `squad` move (the app sends `start` on sign-in). A profile without `gems` hasn't had them yet.
- **Remove Ads** stays at $1.99 (the existing product), not the design's $3.99.

## Phases

1. **Done:** the rules (`functions/squad.js` + `squad.test.js`), the `squad` callable, gem packs in `purchases.js` / `verifyPurchase.js`, and the server-only fields in `firestore.rules`.
2. **Done:** client data. `src/squad/data.js` imports `functions/squad.js` itself, so the tables can't drift. `src/squad/api.js` holds the moves. `tierOf` returns the new rarities, and the gem packs are in `src/economy.js`.
3. **Done:** the screens.
   - `ShopScreen` (Chests / Squishies / Gems) replaces the Key Shop.
   - `ChestOpener` (TAP / HOLD / SWIPE / MIX, healing, crack stages, burst) and `RevealShow` (the design's timeline at lower fidelity than its CSS).
   - `SquishiesScreen` (Collection / Star Shop, the squishy sheet with growth and finishes, the grow celebration). It opens from Home's menu as **MY SQUAD**.
   - The chest art is rendered from the design by `tools/shop-art/` (see below).
4. **Done:** the old economy is removed.
   - Gone: the Key Shop, the Mystery Box screen, tokens, keys, the unlock sheet, DOUBLE IT, `src/mysteryBox.js`, the box config, and the client's `creatureKey` product. The server still grants old `creature_key` purchases.
   - Home's banner is now **CHESTS** and opens the Shop. A locked card says IN CHESTS · GET IT and opens the Shop's squishies.
   - **Tutorial:** every new player gets a **Welcome chest** that always holds Mittens. The tutorial opens it, then buys a Basic chest with the goal coins, then shows a Stars & finishes card.
   - **Daily chest:** coins (app) + 5 Stars (server `dailyGift`, once a day). The streak's token days are now +10 / +20 Stars and its box days a free Silver chest.
   - **Achievements:** chests opened and pulls (`chestOpens`, `tierPulls`), Rainbow / Golden finishes, a complete set, Grown and Best Friend.
   - **Growth XP:** 1 per squish (`xp.<id>`, written by `recordPress`).
5. **For the user:**
   - `firebase deploy --only functions:squad,functions:verifyPurchase,firestore:rules`. The auto-mode classifier blocks the assistant from deploying to production.
   - Create the six `gems_*` consumable products in Play Console and App Store Connect.

The profile field is `chestBag`, not `chests`: `chests` already counts the daily chests opened.

## Tools (tools/shop-art)

- `extract.mjs`: decodes `Squish Squad App.html` into `tools/shop-art/design/` (git-ignored), copies `support.js` / `squad-store.js` / `creatures-v2.js` from the zip, and writes `src/squad/icons.js` (coin, gem, star) and `src/squad/moves.js` (move, dance, concept, sound per squishy).
- `render.mjs`: the chests (5 tiers × stages 0-4 + burst) to `assets/squad/chests/*.webp` and `src/squad/chestArt.js`.
- `shot.mjs`: a screenshot of any design page, for comparing.
- `cdp.mjs`: the shared headless-Chrome helper.

## Later

- The hero offers (Season Pass, Starter Pack, Mega Bundle, VIP) and their products.
- The Spooky season: its card and chest show once its creatures have art.
- Per-rarity chest glow images: the opener's crack stages use the design's default purple glow.
- A closer port of the Reveal Show's disco stage.
