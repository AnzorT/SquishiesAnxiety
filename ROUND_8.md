# PlushCrush — Round 8 (2026-10-03)

What was changed after your review of the tutorial, the Crib, the shop and the rest of the game. Nothing is committed yet. The technical write-up (files, gotchas) is in `REDESIGN_V3.md` → "Round 8"; `HANDOFF.md` is up to date too.

## Your Firebase question: the empty creature cards

Not a Firebase problem. The app still uses the temporary preview catalog, which loads the creature pictures from a small server on this PC (`node tools/plush-art/serve.mjs`). That server wasn't running, so the pictures failed to load. With it running the cards show again. Publishing the 30-creature catalog ends this for good.

## Tutorial and levels

- The tutorial starts after you log in, never on the splash or login screen.
- Closing and reopening the app continues the tutorial from the same step.
- The early "level 3" came from a leftover test switch that forced Daily Challenges on. It's removed. Daily Challenges now appear only at level 3, once the tutorial has reached them.
- Reopening the app in the middle of the Crib part of the tutorial can no longer skip ahead to the "level 3" card.
- The Crib icon on Home appears from level 2.

## The Crib

**Icons and map**
- The round buttons are copied 1:1 from the HTML (colours, ring, icons, badges).
- In landscape all the buttons are grouped on the left; the level, coins and time of day sit on the right.
- The landscape map is now the design's house cut open to show its rooms, with live counts, faces, "need you" / "busy" and "YOU'RE HERE".

**Portrait**
- The room panel matches the vertical design: wooden planks, the "ROOMS" sign, and tiles showing each room's own wall and floor.
- The white strip at the bottom of the screen is gone.
- The room name is shown big at the top, as in the design.

**Rooms start cheap and grow to luxury**
- Every furniture slot has a new cheapest version made from whatever is lying around: a couch of cardboard boxes, an old TV on a box, a picnic cooler, a washtub, mattresses on the floor, a boombox on a crate, cardboard speakers, a bare bulb, and a taped square to dance on.
- The things that used to be painted into every room (bookshelf, windows, clock, oven, cabinets, curtains, mirrors, neon signs, string lights…) are now items you buy and place.
- Walls, floors and ceilings go from bare plaster and concrete, through the design's styles, up to luxury (Royal Damask walls, Gold Marble floors, Gold Coffers ceilings).
- New rugs for every room, from bare floor to Royal Carpet.
- New ceiling lamps for every room, from a bare bulb to a crystal chandelier. They light the room at night.
- The kitchen has a table slot: Crate Table → Snack Table → Banquet Table.

**Everything is movable**
- In Edit mode every piece of furniture has a dashed handle and can be dragged anywhere in the room (each bed and speaker on its own).
- The seats move with the furniture, so creatures still use it wherever it stands.

**Max 10 creatures in the Crib**
- At most 10 creatures live in the Crib.
- In the Hatchery (the egg room), tap a creature to move it in or out. Moved-out creatures show "AWAY".
- A newly unlocked creature moves in by itself while there's room.

**TV**
- The design's TVs were already drawn from behind, facing the creatures on the sofa. The new cheap box TV is drawn from behind too.

## Daily streak

- The streak has its own flame button on Home, next to Daily Challenges (it's no longer inside Daily Challenges).
- It shows your streak and 10 days of rewards, paid when you open the daily chest:

| Day | Reward |
|---|---|
| 1 | 100 coins |
| 2 | 150 coins |
| 3 | 1 creature token |
| 4 | 250 coins |
| 5 | A free Mystery Box |
| 6 | 400 coins |
| 7 | 2 creature tokens |
| 8 | 600 coins |
| 9 | A free Mystery Box |
| 10 | **Half price on creating a new creature** |

- After day 10 the rewards start again from day 1.
- Each streak day still adds +5% squish coins, up to +50%.

## Key Shop

- Now matches the design: coins in the header, the NEXT UP card, and one stall per rarity ("Common Corner", "Rare Boutique"…) with a striped awning, a wooden sign showing how many you own, and cards standing on wooden shelves.
- Prices and how unlocking works stay the same (creature tokens or the key for $0.99).

## Achievements

23 new ones for what the game has now:
- Levels 3, 5, 10, 25, 50, 75 and **100**.
- Daily chests: the first one and 30.
- Streaks of 3, 7, 10 and 30 days.
- Crib care (1, 50, 250 times), Crib purchases (1, 10, 30), and "Full House" (10 creatures in the Crib).
- Doubled box prizes (1 and 25).

## Spin wheel

- No ad after the wheel any more.
- A coin prize offers "SPIN AGAIN" for a video, up to 3 extra spins a day. With Remove Ads there's no video.

## Mystery Box

- After a box opens you can double the prize by watching a video: the same tokens again, or the same coins again.
- Up to 5 times a day. With Remove Ads there's no video.

## My Creatures

- The "Create your own squishy" card is now the same size as the other cards.

## What you need to do

1. **Deploy to Firebase:** `firebase deploy --only functions:spinWheel,functions:verifyPurchase,firestore:rules`. Spin again and the half-price creation don't work without it. I can run it if you tell me to.
2. **Create the store product** `creature_creation_half` ($2.49, half the creation price) in Play Console and App Store Connect.
3. **Publish the creature catalog.** After that I remove the temporary preview code.
4. **Rebuild the app.** The Android theme changed so the landscape Crib can draw into the camera notch area. The emulator already has this build. A thin dark strip still shows where the gesture bar is.

## Not tested in the app yet

- "SPIN AGAIN" and "DOUBLE IT": they need a real rewarded video, and the wheel only appears once a day.
- The half-price creation purchase: needs the store product first.
- The tutorial from a brand-new account (checked by reading the code and by the tests, not played through).
