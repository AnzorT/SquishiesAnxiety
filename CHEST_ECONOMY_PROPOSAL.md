# Chest economy proposal (2026-10-10)

A proposal, not built yet. It changes how creatures are unlocked and how coins and gems are priced. The open questions at the end need answers before anything changes in `functions/squad.js`.

## The goal

- Creatures are unlocked **only from chests**.
- Coins and gems are the two currencies that buy things (chests first).
- Gems buy the same things for a much smaller number than coins, cheap enough that paying feels worth it.

## The economy today

**How creatures are unlocked today:**
- From chests (bought with coins or gems).
- Bought outright with coins: 1,500 / 4,000 / 9,000 by rarity (Legendaries only from chests).
- Bought with Stars in the Star Shop.

**What each chest gives today:** one creature, with these odds.

| Chest | Price | Common | Rare | Epic | Legendary | Extra |
|---|---|---|---|---|---|---|
| Basic | 250 coins | 72% | 22% | 5% | 1% | 3 free a day for a video |
| Silver | 600 coins | 55% | 33% | 9.5% | 2.5% | |
| Gold | 1,200 coins | 30% | 45% | 20% | 5% | counts toward the Legendary guarantee |
| Crystal | 150 gems | – | 50% | 38% | 12% | counts toward the guarantee |
| Rainbow | 300 gems | – | – | 70% | 30% | finishes 3× as likely |
| Season | 120 gems | 50% | 30% | 15% | 5% | season creatures only |

**Rules every chest shares:**
- A creature not owned yet is 3× as likely to drop.
- Every 10th chest without an Epic gives one.
- Every 30th Gold, Crystal or Rainbow chest gives a Legendary.
- Finishes: Shiny 2%, Rainbow 0.5%, Golden 0.1%.
- Duplicates pay **coins**: 400 / 1,000 / 2,500 / 5,000 by rarity. `SQUAD_ECONOMY.md` says Stars, but `functions/squad.js` pays coins.

**The roster in chests:** 64 creatures (32 Common, 16 Rare, 8 Epic, 8 Legendary). Separately there are 8 set rewards (given for completing a set, not from chests) and 7 season creatures.

**How fast coins come in:**
- Squishing pays 5 coins per 1.5 s of play, about **200 coins a minute**.
- An ad multiplies that by 2–4 for a minute.
- The daily spin and the daily chest add a few hundred coins a day.

**What gems cost in real money:**
- The gem packs: $0.99 80, $4.99 450, $9.99 950, $19.99 2,000, $49.99 5,500, $99.99 12,000. The first buy of each pack is doubled.
- That's about 1.2¢ a gem in the smallest pack and 0.8¢ in the biggest.
- The gems → coins swap pays 20–24 coins per gem. That rate is too poor for anyone to use.
- New players start with 600 gems and 180 Stars.

## Part 1: the coin ↔ gem rate

Both currencies are tied to the same yardstick, **minutes of play**:
- coins cost playing time: 200 coins ≈ 1 minute of squishing;
- gems cost money: 1 gem ≈ 1¢.

The rate is therefore the price of skipping a minute of play.

**Proposed: 1 gem = 100 coins, everywhere.**
- An item's gem price is its coin price ÷ 100: 5,000 coins (about 25 minutes of squishing) is 50 gems (about $0.60).
- The gems → coins swap pays the same 100 coins per gem.
- One rate across the app avoids a gem price that's a good deal in one place and a bad deal in another.

**Why it invites paying:**
- The $0.99 pack (80 gems, 160 on the first buy) buys 40–80 minutes of play.
- Price buttons can show both prices, e.g. "4,000 coins (~20 min)" next to "40 gems", so the gem price reads as a bargain.

**What it changes:** the 600 starting gems would be worth 60,000 coins (about 5 hours of play). Lower them to around **100**.

## Part 2: rarity chests

**Each chest gives one creature of a known rarity**, with a 10% chance to land one rarity higher instead.

| Chest | Always gives | 10% chance of instead | Coins | Gems |
|---|---|---|---|---|
| Common chest | a Common | a Rare | 500 | 5 |
| Rare chest | a Rare | an Epic | 2,000 | 15 |
| Epic chest | an Epic | a Legendary | 6,000 | 25 |
| Legendary chest | a Legendary | – | 25,000 | 35 |

**Gem prices (decided 2026-10-10):** 5 for a Common chest, then +10 per rarity. This drops the flat 1 gem = 100 coins rate from Part 1: the higher the rarity, the better the gem deal (100 / 133 / 240 / 714 coins per gem). A Legendary chest costs about $0.40 in gems against about 2 hours of squishing.

The surprise comes from:
- the 10% upgrade (a moment for the opening animation);
- the finishes (Shiny / Rainbow / Golden);
- not knowing *which* creature of that rarity you'll get.

### How long a full collection takes

Simulated on the real roster, 2,000 runs per row, with the 3× chance for creatures not owned yet:

| Rarity | In the roster | Chests to own them all | Duplicates on the way | With coins | With gems |
|---|---|---|---|---|---|
| Common | 32 | ~72 | ~33 | 36,000 coins ≈ 3 h | 360 gems ≈ $4 |
| Rare | 16 | ~32 | ~13 | 64,000 coins ≈ 5.5 h | 480 gems ≈ $5 |
| Epic | 8 | ~14 | ~5 | 84,000 coins ≈ 7 h | 350 gems ≈ $4 |
| Legendary | 8 | ~13 | ~5 | 325,000 coins ≈ 27 h | 455 gems ≈ $5 |

The hours count squishing only (200 coins a minute), not the daily spin, daily chest or ads. The dollar figures use about 1¢ a gem. The whole roster costs about 1,650 gems (about $16) with gems.

**Without the 3× rule,** every row roughly doubles: about 144 chests for the Commons, 60 for the Rares, 25 for the Epics and 22 for the Legendaries.

### Compared with today's chests

The same simulation of today's chests: average number of chests to own everything each chest can hold, priced at the new rate.

| Chest | Chests needed | Cost |
|---|---|---|
| Basic | ~1,270 | ~635,000 coins ≈ 53 h at 500 coins a chest |
| Silver | ~510 | ~765,000 coins at 1,500 a chest |
| Gold | ~245 | ~980,000 coins at 4,000 a chest |
| Crystal (Rare and up) | ~100 | ~12,000 gems ≈ $100 at 120 a chest |
| Rainbow (Epic and up) | ~42 | ~12,600 gems ≈ $100 at 300 a chest |

**Rarity chests need about 130 chests and 55 duplicates for the whole roster.** Today's mixed chests need hundreds of chests and over a thousand duplicates. Today's duplicate coins (400 for a Common) would almost refund a 500-coin chest.

### Pros and cons

**Pros:**
- Players choose what they go for.
- The prices are easy to read.
- The Legendary chest is the obvious thing to pay for: about 2 hours of squishing or 35 gems (about $0.40).
- Far fewer duplicates.

**Cons:**
- Less surprise than a mixed chest.
- The small rarities (8 Epics, 8 Legendaries) run out of new creatures quickly, so duplicates need a reward.

## Also proposed

- **Duplicates pay Stars, not coins:** about 5 / 15 / 40 / 120 by rarity, doubled for a finish (as `SQUAD_ECONOMY.md` describes). Stars pay for growth and finishes, so a duplicate is still useful and no chest refunds itself.
- **Creatures can't be bought outright any more:** no coin prices, no Today's Picks, no creatures in the Star Shop.

## Open questions

1. **The rate:** settled by the gem prices (5 / 15 / 25 / 35). Still open: what rate the gems → coins swap pays.
2. **The four rarity chests and the 10% upgrade:** as in the table, or a different upgrade chance (5–20%)?
3. **The Legendary chest:** keep a coin price (25,000) so free players can complete the collection, or gems only?
4. **Free chests:** the 3 free chests a day for a video become Common chests?
5. **Duplicates:** pay Stars?
6. **Stars:** used for growth and finishes once creatures can't be bought with them?
7. **The other chests:** replace Crystal, Rainbow and Season with the four rarity chests, or keep Rainbow (better finishes) and Season (the season's creatures)?
8. **What coins and gems buy:** only chests, or also Crib furniture and food, finishes and growth?
9. **Starting gems:** lower from 600 to about 100?

## Next steps once decided

1. Re-run the simulation with the final numbers.
2. Change the rules and their tests: `functions/squad.js`, `functions/squad.test.js`.
3. Update the client: `src/squad/data.js` imports the server's tables, so it follows. Then the Shop's chest page, the Star Shop and the creature sheet's buy buttons.
4. Update `SQUAD_ECONOMY.md`.
5. **You deploy** the `squad` function, and reset test players if the economy changes for them.

## How the numbers were made

A Node script in the session's scratchpad (not in the repo) that copies the chest rules:
- rarity weights;
- the 3× weight for creatures not owned yet;
- the Epic guarantee every 10 chests and the Legendary guarantee every 30;
- for the rarity chests, the 10% upgrade.

It runs each case 300–2,000 times and averages. To check final numbers, the same model can be run against `functions/squad.js` itself once the new rules are in.
