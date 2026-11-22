# Squish Sort: the memory mini-game

The second mini-game, asked for on 2026-10-24. Squishies sit on the shelves of a fridge. You see them for about 5 seconds, then the doors shut, the fridge shakes and jumps, and everyone tumbles out. Put each one back on its spot.

## The user's asks (2026-10-24)
- A fridge for the food squishies. The fridge shows for ~5 s, closes, shakes and jumps, then opens, and the creatures go back where they were. Make it challenging, and add it to the PLAY list.
- After trying it: "too simple". Make the fridge bigger, the creatures smaller, add more shelves, and put random foods everywhere to confuse the player.
- Levels and difficulty, like Squishdoku.
- Then: shrink the fridge a little so the doors show. Level 1 should be easy, on about one shelf, and the levels should build up from there.
- 2026-10-28: "i want it to be in real fridge". Several fridge types, "small fridge medium big large extra large XXL … VERY VERY LARGE", each one gaining shelves "until a certain thing", and "your job is to decide when and what". The same for the cupboard.

## Containers
| Container | Squishies | Clutter |
|---|---|---|
| Snack Fridge | Snack Shack, Fruit Patch, Sweet Bakery | 16 foods (milk, eggs, cheese, apple, jam, cupcake, lemon, watermelon…) |

- Each container keeps its own level, stars and skill.
- The squishies come from the whole group, owned or not, without hidden groups or the pass creature (`src/sort/themes.js` `poolOf`).
- Some foods look a lot like food squishies (a cupcake, a lemon, a watermelon slice). They just have no faces.

## Seven sizes (2026-10-28)
The fridge grows through seven real models, one per size (`src/sort/models.js`). (The toy cupboard's column is how it was: the cupboard is gone since 2026-11-17, see the end.)

| Size | Levels | Shelves × spots | Fridge | Cupboard |
|---|---|---|---|---|
| SMALL | 1-5 | 1 × 3, then 2 × 3 from level 3 | Mini Fridge: one door, a freezer box inside at the top, a vent grille, little feet | Bedside Cabinet: one door, a drawer on top, tapered legs |
| MEDIUM | 6-11 | 3 × 3, then 4 × 3 from level 9 | Retro Fridge: mint, a rounded top, a chrome lever handle and badge, splayed chrome legs | Hall Cupboard: one tall panelled door, a cornice, a plinth |
| BIG | 12-18 | 3 × 4, then 4 × 4 from level 15 | Top-Freezer Fridge: almond, its own freezer door on top, salad drawers, magnets and a drawing | Toy Cupboard: the old candy cupboard, two doors with a heart and a star, ball feet |
| LARGE | 19-25 | 5 × 4, then 6 × 4 from level 22 | Bottom-Freezer Fridge: stainless steel, a long bar handle, a freezer drawer | Wardrobe: walnut, two doors, a clothes rail, a drawer, bracket feet |
| EXTRA LARGE | 26-32 | 5 × 5, then 6 × 5 from level 29 | Side-by-Side Fridge: black steel, two tall doors, an ice and water dispenser | Mirror Wardrobe: white, a mirror door, two drawers |
| XXL | 33-41 | 7 × 5, then 8 × 5 from level 37 | French-Door Fridge: steel, two doors over two drawers, a dispenser and a little display | Grand Armoire: cherry, an arched carved crown, arched door panels, bun feet |
| VERY VERY LARGE | 42-50 | 7 × 6, then 8 × 6 from level 46 | Restaurant Fridge: brushed steel, a header with a 3°C thermometer, wire shelves, a lock, casters | Giant Wardrobe: dark oak, little cupboards on top, a row of drawers below |

- **Why these steps:** every model is at least as wide as the one before and gains a shelf partway through, so no level has fewer spots than the one before it. The biggest is 8 × 6. That's one column more than the old 8 × 5, and the spots still come out about 46 dp on the Galaxy A15.
- **On screen:** the bigger models take more of the width (56% of the play area for the small ones, up to 80% for the very very large). A one-door model sits off-centre, away from its hinge, so the open door has room on that side. The doors open as far as the room either side allows: 106°, or down to 98° for the widest ones.
- **Doors:** an open door shows its inside: a fridge's has door bins with bottles, a cupboard's is plain wood. Android's `backfaceVisibility` ignores a parent's turn, so the front and the inside swap by the door's angle. Before this, an open door showed its outside.
- **What the player sees:**
  - A model's first level opens with **BIGGER FRIDGE!** (or **BIGGER CUPBOARD!**) and its size and name.
  - A new shelf adds a **+1 SHELF** chip.
  - Every intro shows the size and name, e.g. "XXL · FRENCH-DOOR FRIDGE".
  - The HUD shows the model's name.
  - The hub card shows the model you're up to, drawn small with its doors opening.
  - The level map has a picture and a banner at each new model, and a "+1 SHELF · 4 SHELVES" banner at each new shelf.
  - How to play has a "BIGGER AND BIGGER" line.

## A level
1. **Deal:** the clutter and the squishies pop onto the shelves.
2. **Peek** (REMEMBER!): about 5 s. A little longer when there are more squishies, shorter on harder tiers.
3. **Close:** the doors shut.
4. **Shake:** a rattle, then two jumps with landings. Behind the shut doors, the clutter gets moved around.
5. **Open:** the doors fly open and the lamp flickers.
6. **Tumble:** the squishies fall out onto the counter (the tray).
7. **Sort:** drag a squishy to its spot, or tap it and then tap the spot. Only the spot under the finger lights up, and there are no dashed outlines. A wrong spot costs a heart, and 3 mistakes end the level. The clock runs: 20 s + 4 s per squishy.

## Twists
- **Impostors:** squishies in the tray that were never inside. Putting one in costs a heart, and it's found out.
- **Sneaky swap:** near the end of the peek, two squishies trade places, or one hops to an empty spot.
- **Mixed up:** after the shake, some squishies are left inside on the wrong spots. Move them home, or drag them out to the tray at no cost. Dropping a squishy on its home where a mixed-up one sits swaps the two.
- **Moving clutter:** the shake moves the clutter to other spots. It never lands on a squishy's home, and at least one empty spot is always left that belongs to nobody, so the gaps don't give the answer away. Dropping on clutter does nothing.

## Levels and difficulty (like Squishdoku)
50 levels per container, in 14 bands of one size across the seven models (above). Squishies on EASY by band: 2, 3 | 3, 4 | 5, 6 | 7, 7 | 8, 8 | 9, 9 | 10, 10 (`src/sort/levels.js` MODEL_SIZES). There's always at least one empty spot.

- **Tiers:** each level asks for EASY, MEDIUM, HARD or EXPERT. The tier rises inside each band, with breathers in between (`src/sort/levels.js` BANDS).
  - Each tier adds a squishy.
  - Medium has one twist, Hard two, Expert all three.
  - No twists on levels 1-5. Then they arrive one at a time: impostors at level 6, mixed up at 10, the swap at 14.
- **Clutter:** about 4 spots in 10, plus one per tier. At least 1 spot stays empty on small shelves, 3 on big ones.
- **Adaptive difficulty:** a hidden skill per container. It goes up after quick clean wins and down after fails and mistakes, and it moves the tier one step at most. The size never changes.
- **Stars:**
  - 3 stars: no mistakes, and under the par time (5 s + 2.6 s per squishy, more for twists).
  - 2 stars: at most one mistake.
  - 1 star: any other win.
- **Coins:** based on the squishies and twists, × stars, × tier.
- **XP** (the player level, PLAYER_XP.md, since 2026-10-25): (10 + ½ × level + 5 × tier) × (0.6 + 0.2 × stars); half on a replay. A Blitz win gives 200.
- **Map:** a winding path of 50 nodes (`src/sort/LevelMap.js`) with tier dots, stars, size banners, each model's picture (`iconOf`, built with its level's node), and a squishy bobbing on the current level.

## Blitz (asked for on 2026-10-24: "in the fridge game i also want to have a blitz option")
**Since 2026-11-17 (the user): BLITZ MODE is endless, like the other games'.** See "Endless BLITZ MODE (2026-11-17)"
at the end. What follows was the first Blitz, kept for history.

Like Squishdoku's Blitz, from the hub's BLITZ ⚡ card:
- **10 rounds in a row**, all in the fridge (the toy cupboard took every other one until 2026-11-17). Each round plays like a Regular level from further up the map: levels 2, 5, 8, 11, 14, 17, 20, 24, 28 and 33, with their size, twists and peek. The Blitz skill (`bSkill`) can move each one a tier.
- **One clock for the whole run**, 5:00 (the rounds' 3-star times add up to about 3:45). It runs only while you sort. It's stopped through the peek, the shake and between rounds.
- **One mistake** (a wrong spot, or an impostor put in) stops the clock. Then:
  - **One revive per run:** a rewarded ad, free with Remove Ads, back to sorting the same round.
  - Otherwise it's **BACK TO ROUND 1**.
  - The clock running out ends the run too, and can't be revived.
- **The prize:** 800 coins for all 10 rounds. The best round reached and the best time are saved.
- **Reused from Squishdoku:** the pips, the revive, fail and win cards, the pause card and the sd_* Blitz sounds.
- **Code:**
  - `levels.js`: `BLITZ_*`, `blitzSpec`, `blitzTheme`, `afterBlitz`.
  - `Game.js`: `SortBlitz` / the `blitz` prop.
  - Saved as `sort.blitz.{reached, bestMs, wins}` and `sort.bSkill`.

## Code
- `src/sort/levels.js`: bands, tiers, specs, skill, stars, coins, and the `sort` record. `src/sort/board.js`: dealing, swaps, the shake, clutter and the drop rules. Tests: `node src/sort/board.test.js`.
- `src/sort/models.js`: the seven fridges (shape, doors, handles, what's on them, their finish and metal).
- `src/sort/Container.js`: draws any model: the body, what's above and below the inside, the inside (glass, wire or wood shelves, salad drawers, a clothes rail, the lamp), the doors and the feet. It also has the geometry (spot size, door angle, the off-centre shift) and `MiniContainer`, the full drawing shrunk for the picker, hub and map. `src/sort/props.js`: the clutter art. `src/sort/Game.js`: the timeline, drag/tap, hearts, clock, win/fail. `src/sort/Cards.js`: result, fail, pause, how to play. `src/sort/Hub.js`, `src/sort/LevelMap.js`, `src/screens/SortScreen.js`.
- Sounds: `tools/audio/sort_sfx.py` writes `assets/audio/sort/fs_*` and `src/audio/sortFiles.js`. Stars, coins, the win and the tick reuse Squishdoku's sd_* sounds.
- Saved on the profile (client-written, like Squishdoku's `sdk`): `sort.fridge.{lv, best, skill}` (an old `sort.cupboard` is just ignored), `sort.plays`, `sort.wins`, `sort.seen`. Coins go through `saveSort`.

## Status
- 2026-10-28, the seven sizes, on the Pixel_8_Pro debug build:
  - checked: all 14 models drawn at game size, open and shut, through a dev gallery that has since been deleted. Also the hub cards, the map's picture and banners, and level 4 played (intro, peek, shake, tumble, a tap-placed squishy landing on its spot).
  - not yet: a BIGGER FRIDGE! intro in play (the test account is on level 4), the bigger models in a real level, and speed on the A15.
  - The layout math was checked for every level at 448 × 849 dp (Pixel 8 Pro) and 384 × 690 dp (A15): nothing runs off screen or into the counter.

### 2026-10-24
- Played on the Pixel_8_Pro debug build: hub, picker card, deal, peek, close, shake, open, tumble, drag and tap placing, a mistake, the win with its result card, time's up, pause. The clutter and the bigger fridge were checked after the user's "too simple".
- Still to check: the level map on screen, the toy cupboard in play, impostors / swap / mixed-up in play, speed on a release build on the A15. Nobody has listened to the fs_* sounds yet.
- Blitz, played on the Pixel_8_Pro on 2026-10-24:
  - checked: the hub card, round 1 in the fridge solved (pip, clock held, round 2 in the cupboard), a mistake opening the revive card, the revive through a test ad (the clock held through it), a second mistake giving BACK TO ROUND 1 and the best round saved, GO AGAIN.
  - not yet: a full 10-round win, a timeout.

## Character animations (2026-11-17)

The user's list, for Regular and Blitz:
- Grab from the tray: lift with a stretch and a wiggle while dragging.
- Correct spot: squash into place, a happy hop, sparkles.
- Wrong spot: shake "no", bounce back to the tray with a sweat drop.
- Impostor found out: a guilty jump and a spin away.
- Win: everyone inside does a bounce wave as the doors close.
- Lose (out of hearts or time): everyone droops sadly.

The squishies in play are the design's live 2.5D rigs, as in Squish Hop. The same day, about Hop's flat cut-out version,
the user had said "when i say animation i mean an entire full body physics + the characters need to be 3d and not 2d".

**What plays**
- **Picked up** (a drag, or chosen with a tap): it pops up stretched tall, thrilled, arms up. While carried it wiggles
  side to side with its feet kicking, and it swings behind the way the finger moves. A chosen one wiggles more gently
  where it stands.
- **The right spot:** into it (a quick hop from the tray on a tap), squashed flat with its eyes shut as it lands. Then a
  happy hop with its arms up, a heart and sparkles, and a big smile for a moment.
- **A wrong spot:** onto it, then a shake of the head (no!) with a frown, its ears back, wet eyes and two sweat drops.
  Then one big bounce back to its place in the tray, sweating again as it lands. (Before, it flew straight back with a
  shake.)
- **An impostor found out:** a guilty jump where it is (eyes wide, mouth open, hands up, blushing, sweating). Then it
  spins away off the nearer side of the screen, smaller and smaller, with the poof. Impostors still in the tray at the
  win, and at a loss, are found out the same way. (Before, they grew and shrank away.)
- **The win:** a bounce wave along the shelves, column by column, each row a little behind. Each squishy squashes,
  bounces with its arms waving and bounces again, happy. The doors swing shut over the wave from 350 ms (650 ms), then
  the thud, the fridge's squash and confetti. The result card comes at 1.7 s (was 1.5 s). The last one put in finishes
  its happy hop first.
- **A loss (Regular):** the ones not home hop there as before and the impostors spin away. Then everyone droops: a
  deflating sigh (head down, ears and arms hanging, frown, teary), a tear, then a slow sad sway. The OH NO! card comes
  once they're down (at least 1.9 s).
- **A loss (Blitz),** whether a mistake with the revive used or turned down, or the clock: everyone droops where they
  are, then BACK TO ROUND 1 after 1.3 s (1.5 s for time's up).
- **Mixed-up ones** look round, puzzled, one at a time every 2.6 s. Not asked; the stills wobble there.
- The tumble out of the fridge has their arms up, flailing, and a squash as they land. Bumped ones and the ones put
  back in the tray land with a squash.

**How it works**
- `tools/rig/sort.html` (copied by `tools/rig/build.mjs` to `android/app/src/main/assets/rig/`) draws every squishy in
  play in one transparent WebView over the play area. It goes through Hop's `src/hop/RigStage.js`, which now takes the
  page's name (`page="sort"`) and its calls. The rig scripts are the design's, unchanged. The page's loader, pause and
  grain fix are copies of `hop.html`'s.
- `src/sort/Game.js` stays in charge: the rules, timing and input are as before, and each move is also sent to the
  page (`rig(...)`). A rig is drawn exactly where its still would be: the stills are the rigs at rest
  (`tools/rig/thumbs.mjs`, the rig's 0-100 box over the middle 88% of the picture).
- A deal's rigs are sent to the page as the deal starts and load through the peek. The deal is played by the rigs if
  the page has drawn them all by the tumble, or by the start of sorting on a slow phone. Otherwise the stills play it.
  The stills also play it if a squishy has no rig, or if a rig's art doesn't load within 9 s.
- **The stills do the same moves more simply** (`Piece`: squash and stretch about the feet, tilt, spin, a sweat drop, a
  wiggle while held, a sway when sad). At the win, the stills on the shelves give way to the inside ones under the
  doors, so the doors shut over the wave there too.
- While the rigs draw, the stills show only the chosen ring (under the page) and the ? and ✓ marks (over it).
- **The doors at the win:** the page clips its squishies to the part of the shelves the doors haven't covered yet. It
  uses the same angle, perspective and curve as `Container.js`'s `Door` and runs 3 px ahead of the door's edge.
- **Speed: only the squishies moving are drawn.** A rig costs a lot to draw: on the weak-phone stand-in (Chromium,
  software rendering, the CPU slowed 4×, `tools/perf/webview-bench.mjs`'s setup) 1 rig ran at 60 fps, 4 at 20 fps and 16
  at 5 fps.
  - The one in the hand and one acting alone (landing, shaking its head, caught out) are drawn every frame.
  - A crowd (the tumble, the win's wave, the droop) takes turns, two drawn a frame. Their bodies' hop, squash and tilt
    are moved every frame around the drawing.
  - One standing still keeps its last drawing (rive-rig's generic rigs skip drawing while `I.ready` is off), and with
    nothing moving the page sleeps.
  - With 16 rigs on the stand-in: idle 60 fps (asleep), the tumble 46, the wave 44, the drag 48, a right spot 56.
- **The floor shadows are the page's own** (the rig's is hidden), so they stay on the floor as a squishy hops. The rig
  lifts itself up to 40 of its units, and the rest of a big jump moves the whole drawing: the rig's own shadow math goes
  below zero past ~70 and filled the console with errors.
- Sounds: as before, plus `fs_doorClose` as the win's doors shut and `fs_drop` as a wrong one lands back in the tray.

**Checked (web, 2026-11-17):** `?phone=1&preview=1&card=sort-level&lv=6` (and `lv=8`, and `sort-blitz`), played
through `window.__sort` with screenshots: the rigs live from the tumble, a drag, a wrong spot (shake, bounce back), a
right spot (squash, hop), a tap choice, an impostor by tap, the win's wave and doors (the clip), a loss by three
mistakes (the droop, then OH NO!), and Blitz (a mistake, the free revive, a second mistake, the droop, BACK TO ROUND 1).
The stills path was also played with the rig page left empty. The only console message left is an older "React does not
recognize the translateY prop" warning from elsewhere.

**Not yet:** the phone (an Android build is needed: `rig/sort.html` is a new asset in the APK), the A15's frame rate,
the toy cupboard with rigs, and a full Blitz win.

## Fridge only, realistic fridges, the other games' screens (2026-11-17)

The user: "about squish sort, lets make it only with food ok ? so delete the top cupboard, next, the fridges dont look
realistic and high detaield enough, need to alter that and make sure the screens of squish sort mathces the other
game's screen like for example the design".

- **Only the fridge.** The toy cupboard is gone: its theme (`themes.js`), its seven models (`models.js`), its toys
  (`props.js`), its hub card, its map and its Blitz rounds. The squishies are the food groups' (Snack Shack, Fruit
  Patch, Sweet Bakery: Sugarplum, the bakery's crowned one, is one of them), the clutter is food, the impostors come
  from the same food pool. Blitz is ten fridge rounds. A player's old `sort.cupboard` progress is left in the profile,
  unread. The game picker's chips and the Stats line say the fridge's level.
- **Realistic fridges** (`Container.js` redrawn, all SVG; `geometry()`, the spots, the door swing and the rig page's
  door clip unchanged):
  - finishes: glossy enamel (white, mint, almond) with a soft reflection band, brushed steel with its grain (steel,
    blue steel, black steel); bevelled edges; a dark gap round the doors; chrome hinge caps;
  - handles: round bars standing off on posts with their shadows, a retro chrome lever on its plate, a moulded pocket,
    a finger groove;
  - the inside has depth: side walls, a ceiling with an LED strip that lights with the lamp, a ribbed back wall with a
    vent, glass shelves with their trims, glints and shadows (wire shelves with rods on the retro and restaurant
    fridges), frosted salad drawers with lettuce, tomatoes and carrots showing through;
  - each door's inside: the rubber gasket, a moulded liner, bins with eggs, a milk jug, cartons, bottles and cans;
  - the details: a sticky note (mini), a SQUISHY badge and chrome trim (retro), a child's drawing, a strawberry
    magnet and a shopping list (top-freezer), an ice and water dispenser and an LCD (side-by-side, French-door), a
    digital thermometer, a maker's plate, louvres, a lock, kick plates and casters (restaurant); a soft shadow on the
    floor under every one.
  - Web preview `?phone=1&preview=1&card=sort-fridges` (`&open=0`, `&m=0…6`) shows them.
- **The screens as the other games':**
  - the hub is `GameHub` (REGULAR MODE / BLITZ MODE wood cards, HOW TO PLAY), its pictures from the game itself
    (`node tools/games/mode-art.mjs sort`, with Metro running: level 12 mid-peek, the REMEMBER! words hidden);
  - the map's header says SQUISH SORT;
  - a level stands in the Crib's kitchen (hop/Room.js) edge to edge, with Squish Hop's top bar (the round back button,
    the fridge's name as the room title, the tier pill; Blitz: "Blitz Mode") and the brown glass: hearts (Blitz: the
    pips and the revive) and one TimerBar, an eye through the peek with its seconds, a clock after;
  - the tray is the same glass, no COUNTER label.
- **Not done:** the Game Park clip (`webgame/app/previews/sort.mp4`, the menu's games carousel) still shows the old
  fridge; nothing seen on a phone yet (needs a fresh bundle; the rig page is unchanged).
- **Checked** in the web version at 832 × 384: every fridge open and shut (`sort-fridges`), levels 6, 12, 20 and 45,
  Blitz, the hub and the map; level 20 played through the shake (doors shut) and the tumble, solved with
  `__sort.solve()` to the result card, no errors. `node src/sort/board.test.js` passes.

## The map in the kitchen (2026-11-17)

The user: "squish sort let be only for kitchen". Sideways the level map stands in the Crib kitchen, the room every level
is played in (`RoomBackdrop`, the whole room), the row along its floor, the title on a cream plaque.
Web-checked only. Since the same day the kitchen scrolls with the list, its picture repeated side by side for the
page's length (`roomOf` → kitchen; SQUISH_HOP.md "Scrolling with the list").

## Endless BLITZ MODE (2026-11-17)

The user, with a screenshot of the Blitz glass (the ten pips, "1 REVIVE", the run's 3:09 clock): "its unlimited and it
should behave like the others, 1 fail means you failed it all and the pop up of the fail does not match the popups in
the other minigames". So Blitz now works as Squishdoku's, Squish Stack's and Squish Hop's do:

- **A run opens with 3, 2, 1, GO!** and goes on round after round with no end. The rounds climb as the first Blitz's
  ten did (Regular levels 2, 5, 8 … 33), on through 36, 39 and 42, then the very very large fridge's eight-shelf levels
  (46-50) in turn, for good. The fridge never gets smaller.
- **Each round has its own clock** (my reading: Squishdoku and Hop have one each, Stack has none since the user took
  it out there): a third more than the level's 3-star time, in whole seconds (14 s for round 1, 46 s for round 10).
  Past the climb each clock is 3% shorter than the last, down to three quarters. It's always under Regular's clock for
  the same level (`board.test.js`). It runs only while you sort, not through the peek and the shake.
- **One mistake** (a wrong spot, or an impostor put in) **or the clock running out stops the run.** The other games'
  save card comes up (OOPS! / TIME'S UP!):
  - **with a rewarded ad**, once a run (free with Remove Ads);
  - **with gems**: 10, 20, 40 … up to 320 in the same run, through the same `blitzSave` move (`functions/squad.js`).
  - After a mistake the round's clock runs on; after it ran out it starts again.
  - **END RUN**: everyone droops, then the other games' GAME OVER card (ROUNDS CLEARED, BEST, coins, XP, PLAY AGAIN /
    QUIT; confetti for a new best).
- **The pay**, per round cleared: twice what the level pays in Regular with 1 star (24 coins for round 1, about 100 for
  round 10), and a tenth of config/levels `xp.blitz.sort` in XP (20 by default). Quitting or starting over mid-run pays
  too. (The first Blitz paid 800 coins and 200 XP for all ten rounds, nothing otherwise.)
- **The glass:** CLEARED n and BEST n (NEW BEST in orange once it's beaten), "1 MISTAKE = GAME OVER", and the round's
  clock. The pips and the revive chip are gone, and so are the old revive, fail and win cards.
- The skill (`bSkill`) still moves the rounds a tier: up after a run of 10 or more, down after one under 5.
- Saved as `sort.blitz.{top, runs}`. `reached`, `bestMs` and `wins` were the ten-round runs' and are no longer written.
  The hub's BLITZ MODE shows "BEST: n" and the PICK A GAME card "BLITZ BEST n" (it was "BLITZ n/10").
- **Code:** `levels.js` `blitzSpec` (with its `limitMs`), `blitzCoins`, `blitzPrize`, `afterBlitz`; `Game.js`
  `payOut`, `blitzStop`, `goOn`, `saveByAd`, `saveByGems`, `endRun`, `again`.
- **Checked** in the web version's preview (`?phone=1&preview=1&card=sort-blitz`): the countdown, round 1 solved
  (CLEARED 1) into round 2, a wrong spot into OOPS!, the free save back to sorting, a second mistake (the free save gone,
  gems and END RUN left), END RUN into GAME OVER (+20 XP), PLAY AGAIN from CLEARED 0; and round 1's clock running out
  into TIME'S UP!, saved with its clock started again. The gem save wasn't tried (it calls the server). Not checked
  on a phone.
