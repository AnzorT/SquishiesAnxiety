# Economy v2 (2026-10-09)

Follows SQUAD_ECONOMY.md (the 2026-10-06 chests/gems/Stars economy). The user found it too complicated: three currencies, five rarity labels, six chests, four finishes, three growth stages and seven ways to unlock a creature, sold in two different places. The goal is a simpler, Subway Surfers-like model.

## Rulings (user)

- **Keep gems** (2026-10-09). They stay the premium currency, sold in the six gem packs.
- **Drop Stars from the database, the UI and all logic** (2026-10-09). Done the same day.

## Stars removal (done 2026-10-09)

- **Server (`functions/squad.js`, tests in `squad.test.js`):**
  - Duplicates pay coins: `DUPE` = 400 / 1,000 / 2,500 / 5,000 (2,500 for a Set reward), doubled for a finish.
  - A finished set pays `SET_BONUS` = 2,000 coins.
  - Growth needs XP only.
  - `buyFinish` is gone, so finishes come from chests only.
  - `buyCreature` takes coins only.
  - `dailyGift` pays a streak day's gems (up to 20) or a Silver chest.
  - The start is 600 gems.
- **Wheel:** the 20 Stars slice is now 150 coins (`functions/dailySpin.js` and `src/dailySpin.js`).
- **Streak:** days 3 and 7 pay +10 / +20 gems instead of Stars.
- **Rules:** `stars` is out of the server-only field lists in `firestore.rules`.
- **App:**
  - The Star Shop tab, the Stars purse and the Stars buttons are gone (Squishies screen and Shop).
  - The reveal shows "Duplicate! +N coins".
  - The tutorial card is now "Collect them all!" (step `collect`; the old `stars` step still maps to it).
  - The star icon is removed (`tools/shop-art/extract.mjs` no longer writes it).
- **Database:** `tools/plush-art/drop-stars.mjs` deleted `stars` from the 2 players who had it (Ted, temp).
- **Deployed:** `squad`, `spinWheel` and `firestore.rules` went live on 2026-10-09. The deploy ran by accident: a shell command's backticks ran it. It shipped this change and the earlier uncommitted squad/rules work. Afterwards no player had Stars.
- **Not deployed:** the app itself. It needs a new build to drop the Star Shop on devices.

## Proposed, waiting on the user

- **Coins have one clear job:** they buy creatures, the Crib (rooms and food) and boost upgrades.
- **One unlock path per creature, shown on its card:**
  - Common 2,500 coins, Rare 7,500, Epic 20,000.
  - Legendary 500 gems.
  - A set's reward creature comes free with the full set.
  - Season creatures come from the season.
  - Prices live in Firebase `config`.
- **Duplicate payout:** coins, as built above. Could become 25% of the creature's new price.
- **Chests:**
  - Two kinds: a coin Mystery Box (3 free a day, one video each) and a gem Crystal Chest.
  - Chests are the only source of finishes and exclusive decor, plus a chance at a creature.
  - No pity or Epic counters.
- **Finishes:** chests only for now; whether gems can also buy them is open.
- **Coin upgrades:** boost length and earn rate. Open.
- **Squishies screen:**
  - One grid with set filter chips.
  - Locked creatures are faded, with their price on the card.
  - A progress bar for each set.
  - A simple sheet: PLAY, growth and finishes when owned; one BUY button when locked.
  - My creations becomes its own tab.
- **Shop:**
  - Four tabs: Squishies (the only place creatures are sold, with one daily deal), Upgrades, Gems (gem packs, coin packs, Starter Pack, Remove Ads) and Chests.

## Steps (one per session)

1. Prices and unlocks: `functions/squad.js` + tests, `src/squad/data.js`.
2. Squishies screen.
3. Shop.
4. Clean-up: achievements, Purse headers, anything still pointing at the old flow.
