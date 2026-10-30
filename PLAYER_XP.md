# Player XP (2026-10-24, built 2026-10-25)

The whole game has one XP bar. The mini-games, the daily challenges and squishing fill it, and the player level comes from it. Opening the daily chest no longer raises the level.

**Status:** built, uncommitted. **You need to deploy** the functions (`squad`, `testWallet`) and the Firestore rules. Until then a CLAIM on the level road shows "Something went wrong. Try again!", because the server doesn't have the `levelClaim` move yet.

## Changing levels, prizes and XP (no app update)

Everything below lives in Firestore **`config/levels`**, which the app and the server both read. Edit it in the Firebase console (Firestore → `config` → `levels`) and it applies straight away for every player. A field you leave out, or get wrong, falls back to the default in `functions/squad.js` `DEFAULT_LEVELS`.

| Field | What it does | Now |
|---|---|---|
| `xpPerLevel` | Reaching level L takes `xpPerLevel × L` XP, counted from 0 at each level | 100 |
| `road` | One prize per level, from level 1. **Add a row to add a level.** A prize is `{ k: "coins", n: 500 }`, `{ k: "gems", n: 50 }` or `{ k: "chest", t: "common" }` (`t` is `common`, `rare`, `epic`, `legendary` or `set`, the Rainbow chest) | 50 levels |
| `xp.challenge` | XP per daily challenge claimed | 25 |
| `xp.chest` | XP for the daily chest | 100 |
| `xp.squishEvery` / `xp.squishDay` | 1 XP every this many squishes, up to this much a day | 5 / 200 |
| `xp.replay` | The share of a level's XP a replay pays (0–1) | 0.5 |
| `xp.games` | Multiplies every mini-game level's XP (2 = double) | 1 |
| `xp.blitz.squishdoku` / `.sort` / `.stack` | XP for a won Blitz run | 400 / 200 / 200 |

Things to know:
- Changing `xpPerLevel` changes everyone's level at once, because a level is worked out from the player's XP total. Prizes already claimed stay claimed.
- The script `tools/admin/levels.mjs` shows the document, seeds it (`--seed`) or replaces it with a JSON file (`--file`). It was seeded on 2026-10-25 with the defaults. On the emulator, adding a 51st level showed up on the road without an app update.
- The server reads `config/levels` only after the functions deploy that includes it. Until then it uses the defaults built into the deployed code.

## Your answers (2026-10-25)

1. Daily challenges keep their coins and also give XP.
2. Squishdoku's Puzzle Level is folded into the player level.
3. Replays pay XP, "50% less": a replay pays half.
4. Level-up rewards: a hand-made prize at every level from 1 to 50 (the **level road**), like the season pass.
5. The Crib's item level tags spread from 1–9 to 1–20.
6. (not answered) Mini-games stay open to everyone. That was my proposal.
7. Squishing gives XP directly.

## My readings (tell me if any is wrong)

- **Replays:** half the level's XP. If the replay beats your best stars and the difference is more than half, it pays the difference instead.
- **Squishing:** 1 XP every 5 squishes, up to 200 XP a day (1,000 squishes). The cap stops an auto-clicker from farming levels.
- **The road:** level 1's prize can be claimed straight away (a welcome gift). The road ends at 50; later levels pay nothing but still count for the LV 75 and LV 100 trophies.
- **The road's chests** are of today's first HOT group, like the free chest.
- **LEVEL UP card:** it shows on the Lobby once per level (never in the middle of a game). It skips levels 2 and 3, because the tutorial already has its own cards for those. COLLECT opens the road and claims every prize waiting; LATER leaves them there.
- **Moving existing players over:** their old level's XP plus their Squishdoku Puzzle XP becomes their new total. Nobody loses a level. The levels gained this way don't show a LEVEL UP card, but their prizes wait on the road.

## Where XP comes from

| Source | XP |
|---|---|
| A daily challenge claimed | 25 (plus its coins, as before) |
| The daily chest | 100 (plus its coins and the streak reward, as before) |
| Squishing | 1 every 5 squishes, up to 200 a day |
| Squishdoku level | 8–90, the old Puzzle XP formula (×0.6 with HEAD START) |
| Squishdoku Blitz won | 400 (240 with HEAD START) |
| Squish Sort / Squish Stack level | (10 + ½ × level number + 5 × tier) × (0.6 + 0.2 × stars): 12 at level 1, 60 at level 50 on EXPERT with 3 stars |
| Sort / Stack Blitz won | 200 |
| Any replay of a level already beaten | half (see above) |
| The tutorial | brings you up to level 2 (200 XP in total), then level 3 (500) |

## The curve

**Reaching level L takes 100 × L XP, counted from 0 again at every level** (the user, 2026-10-25: "once you reach level 9 you need to gain from the start 1000xp to get level 10, and that's how it should be for every level"). Levels 2 and 3 come at once with the tutorial. There's no top level.

| Level | XP for this level | Total XP |
|---|---|---|
| 2 | 200 (tutorial) | 200 |
| 3 | 300 (tutorial) | 500 |
| 4 | 400 | 900 |
| 5 | 500 | 1,400 |
| 10 | 1,000 | 5,400 |
| 20 | 2,000 | 20,900 |
| 50 | 5,000 | 127,400 |
| 100 | 10,000 | 504,900 |

At about 500 XP a day (the daily challenges plus some games), that's level 10 in about 10 days, level 20 in about 6 weeks and level 50 in about 8 months.

Earlier curves, both dropped: 100 + 20 × (L − 1) per level up to 1,000 (level 50 at 28,300 XP), then 100 × L in total (level 50 at 5,000 XP).

## The level road

A prize at every level from 1 to 50. Coins grow, gems come every few levels, and every 5th level has a bigger chest. The table is `DEFAULT_OFFERS.road` in `functions/squad.js`. Putting a `road` array in Firestore `config/offers` replaces it without an app update.

| Levels | Prizes |
|---|---|
| 1–5 | 200 coins · 300 coins · Common chest · 400 coins · 30 gems |
| 6–10 | 500 coins · Common chest · 600 coins · 40 gems · **Rare chest** |
| 11–15 | 800 coins · Common chest · 50 gems · 1,000 coins · **Rare chest** |
| 16–20 | 1,200 coins · 60 gems · Common chest · 1,500 coins · **Epic chest** |
| 21–25 | 1,600 coins · Rare chest · 80 gems · 1,800 coins · **Legendary chest** |
| 26–30 | 2,000 coins · Rare chest · 100 gems · 2,200 coins · **Epic chest** |
| 31–35 | 2,400 coins · Rare chest · 120 gems · 2,600 coins · **Epic chest** |
| 36–40 | 2,800 coins · Rare chest · 150 gems · 3,000 coins · **Legendary chest** |
| 41–45 | 3,200 coins · Epic chest · 180 gems · 3,500 coins · **Legendary chest** |
| 46–50 | 4,000 coins · Epic chest · 250 gems · 5,000 coins · **Rainbow chest** |

In total: 40,600 coins, 1,060 gems and 19 chests (4 Common, 6 Rare, 5 Epic, 3 Legendary, 1 Rainbow).

## What the level affects

- **The Crib** opens at LV 2, and **Daily Challenges** at LV 3 (both reached in the tutorial, as before).
- **The Crib's furniture, walls and floors:** the design's tags 1, 2 … 9 now mean levels 1, 3, 6, 8, 11, 13, 15, 18 and 20 (`spreadLevel` in `src/crib/home.js`).
- **The level trophies** (LV 3 → LV 100). "Reach level 100 with the Daily Challenges" is now "Reach level 100".
- **The level road** (above).

## Where it shows

- **The Lobby:** a LEVEL chip beside the coins, with the level, an XP bar and a red count of prizes waiting. Tapping it opens the level road.
- **The level road screen:**
  - The header has your coin and gem counters.
  - The XP card shows your level and its bar ("42 / 500 XP").
  - CLAIM ALL claims everything waiting in one server call (`levelClaimAll`).
  - Below are the 50 prizes.
- **Claiming on the road:**
  - Coins and gems burst out of the prize's icon and fly into their counter, which bumps and counts up as each one lands. A prize whose row is off screen flies from the level disc instead.
  - A chest drops in from above (squash, bounce, rays) onto the spot where the chest smash draws its chest, then the smash fades in under it.
  - With several prizes, the coins and gems come first, then the chests one by one; each chest drops in after the previous one is collected.
  - The code is in `src/components/RewardFx.js`.
- **Every result card** (Squishdoku, Sort, Stack, and every Blitz win): "+N XP", the XP bar filling, and "LEVEL n!" when it rises.
- **Squishdoku:** its hub shows YOUR LEVEL instead of PUZZLE LEVEL; the map's LV pill and the result bar are the player's. PICK A GAME dropped the PUZZLE LV chip.
- **Daily Challenges sheet:** "+25 XP" under every reward, and "+100 XP" on the chest line. The claim toasts say "+60 coins · +25 XP!".
- **The Shop's season pass** says "PASS XP" now, so it can't be confused with this XP.

## Saving

- **App-side fields.** `pxp` is the XP total, and `level` is written beside it. The app writes both itself, like coins: every grant is an increment, in the same write as the coins it came with. `lvSeen` is the last level whose LEVEL UP card was shown.
- **Server-only field.** `levelGot` (`{ [level]: true }`) is written only by the server's `levelClaim` and `levelClaimAll`; the rules block the app from writing it. The server works out the level from `pxp` with the same curve (`functions/squad.js` `playerLevel`, which the app imports too).
- **Squishdoku's `sdk.xp`** is no longer written; it's read once when a player is moved over.
- **The test wallet's level box** now sets `pxp` to that level's total.

## Files

- `functions/squad.js`: the curve, the road, `levelClaim`. `functions/index.js`: `levelClaim` wiring, the test wallet, the new-profile `pxp`. `firestore.rules`: `levelGot`.
- `src/playerXp.js`: XP, level, the road's view, the replay rule, moving players over.
- `src/progression.js`: the challenge, chest and squish XP. `src/firebase/firestore.js`: the writes.
- The three games' `levels.js` (XP per win), `src/squishdoku/Overlays.js` (`XpBar`, `XpGain`, `XpPlus`, shared with the Sort and Stack cards).
- `src/components/LevelBits.js` (the LV chip, the LEVEL UP card, the prize art), `src/screens/LevelRoadScreen.js`.
- Tests: `src/playerXp.test.js`, `src/progression.test.js`, `functions/squad.test.js`, `src/sort/board.test.js`, `src/stack/engine.test.js`, `src/crib/model.test.js`.

## Checked on the emulator (2026-10-25)

- **The Lobby's LEVEL chip:** level 7 with a red 7. The test account was moved over at level 7, so no LEVEL UP card.
- **The level road** (on the earlier curve): "5 / 220 XP", CLAIM ALL (7), level 8 showing "215 XP" to go. CLAIM shows the error toast until the deploy.
- **Squishdoku level 8, first clear:** PERFECT with HEAD START paid +22 XP, and the bar filled from 5 to 27.
- **Squishdoku level 8, replay:** paid +14 XP, half of 27. The bar started from 27, so the first win's XP was saved.
- **The LEVEL UP card:** shown on the Lobby after setting the test account's `lvSeen` back to 5. COLLECT opened the road and tried to claim the 7 prizes waiting; the app then wrote `lvSeen` back to 7.
- **Squishing:** the 5th squish of the day added 1 XP (`pxp` 941 → 942).
- **Not seen on the emulator yet:**
  - a real claim (it needs the deploy);
  - the Sort and Stack result cards (they use the same XP pieces as Squishdoku's);
  - the Daily Challenges sheet's XP labels.
