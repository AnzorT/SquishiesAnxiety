# PlushCrush — Round 9 (2026-10-03)

What changed after your review of the Crib's animations and screens. Nothing is committed yet. The technical write-up is in `REDESIGN_V3.md` → "Round 9".

## Animations

- **No more spin when you walk into a room.** The arrival animation was playing every time a room opened. Now it only plays when a creature actually arrives, as the design's quick twirl-in.
- **Every animation from the HTML is in**, in two layers like the design: the creature's own mood, plus the room's motion on top.
- **Eating depends on the food.** Each food is eaten its own way: nibbling (carrot, cookie, salad), chomping (burger, pizza, donut, dumpling), savouring (chocolate, pineapple), gulping (sushi, fish, marshmallow: tossed up and swallowed) and slurping (noodles). You see the food in their hands getting smaller, crumbs, steam, juice, a burp and hearts when they're full.
- **Washing depends on the station.** Washtub and tub, bubble bath, hot tub, spa (face mask and towel), duck pool (ducks swimming around), shower (rain), mud shower (mud spots and drips) and sauna (steam and sweat). Each has its own motion, face and effects, plus the scrub wiggle and rising bubbles.
- **Playing, dancing, sleeping and TV** use the design's moves too. In the yard they hop and cheer. Dancing cycles through the design's three moves: groove, a ballerina twirl and a pop hop. Sleepers breathe slowly with Zs. TV watchers laugh and their eyes take on the screen's colours.
- The "needs something" bubble, the "+15 TUMMY" label and the gold ring when you tap a creature now match the design.

Not possible: the design also swings the creatures' arms and feet. Our creature pictures are single images, so the body, face and effects move but the arms don't.

## Stats

- New creatures start at **70%** on everything.
- Below **40%** they look **sad** (with tears).
- If **only Clean** is below 40%, they look **smelly** instead: grey smudges, stink lines and flies buzzing around them.

## The creature card

Rebuilt to match the HTML 1:1: the dark border, the picture, the red "Enough …" button at the top, the stat bars with arrows, the six action buttons with coloured icons and a red "!" on the one they need, and the sleep and snack pickers. In landscape it's a column on the right; in portrait it fills the space under the room.

## Bedroom

- The blanket now covers the mattress up to the pillows, with a folded white sheet edge. It looks like part of the bed instead of a second mattress.
- Sleeping creatures are tucked in up to their chin, whatever their shape.

## Landscape

- Achievements and notifications slide in from the top.
- Edit mode: when you slide the panel down, its arrow stays at the bottom edge so you can pull it back up.
- Map: every room, including the Bedroom, has the same border.

## Portrait

- Edit mode takes over the whole room panel area instead of sitting on top of it like a popup.

## Hatchery

- It's now an attic: sloped rafters, a round window, wooden walls and floor, a hanging bulb, cobwebs, boxes and an old trunk. The room tile shows the attic too.

## Bug fixed

If the Crib opened before your creatures had loaded, it could move all of them out, and that was saved. That's fixed. Your test account's 10 creatures are back in (they start again at 70%).

## Worth knowing

- Stats drop fast (the design's demo speed). After about 10 minutes away, everyone is hungry again.
- The Crib uses more processing power now (about 25% more on the emulator's debug build). It should be measured on the Galaxy A15 with a release build.

## Kitchen and the gift (added later)

- The daily gift button is gone from the Crib.
- The Back button in the food and sleep choices is now a real button with an arrow, on the left.
- New in the kitchen only: a red basket button opens the Pantry. Buy food ahead: 1 at the normal price, or a pack of 5 for the price of 4. Your squishies eat from the pantry before meals cost coins. There's also a "Buy food for the pantry" button under the food choices.

## Follow-up (same night)

- Creatures still under 40% hungry keep showing it at the table between meals (tears, the hungry lean, the cookie bubble).
- In the kitchen they sit at the table: the table hides their lower body, and their face and food stay above it, whatever their shape.
- The box couch's seat sits lower, so a creature watching TV shows above it like on the other sofas.
- Sad creatures now visibly sob and sway.
- Splash screen: creatures idle or dance.
- Home creature cards: idle, dancing and eating in turn, 4 seconds each.
