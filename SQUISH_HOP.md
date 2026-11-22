# Squish Hop: the cushion-hopping mini-game

The fourth mini-game. It began as a web prototype made in a cloud session (`prototypes/squish-hop/`, branch `claude/thin-ice-game-repo-i9424j`, merged into develop on 2026-11-07). The user then asked: "take the idea and implement it on our app". The prototype's README has the design history: the rooms, the twists, and how the levels were made.

## Playing
- **Hop:** the squishy hops one cushion at a time. Swipe (a long drag can turn corners: one hop per half a tile of drag), or tap a cushion next to it, or press an arrow key (bottom left, since 2026-11-17). A quick flick that ends before a hop's worth of drag still hops once.
- **Puff:** the cushion it hops off puffs away, leaving a dashed dent. It can never go back there.
- **The ★ cushion** ends the level. **Since 2026-11-16 (the user) it opens only once every other cushion is cleared**,
  so every win is a full clear. Until then it's grey with how many are left (the goal card's cushion badge says the same; it was a LEFT pill); hopping at
  it bumps with "Clear every other cushion first. Then the ★ opens!". A pile counts until both its layers are gone.
- **Stuck:** with nowhere left to hop, the STUCK card comes up with RETRY (UNDO was taken out on 2026-11-17).
- **The hopper** is the Lobby's squishy (if it has a cut-out). The friends are other squishies, the player's own first. A level always has the same friends, like its board (`roster.js`).

## The twists, room by room (100 levels)
| Levels | Room | New twist |
|---|---|---|
| 1-14 | Living Room | friends (8): pick them all up (they sit on cushions, so clearing every cushion picks them up) |
| 15-30 | Kitchen | arrows (15): you can only hop off an arrow cushion the way it points |
| 31-46 | Bathroom | bubbles (31): land on one and it bounces you one further |
| 47-62 | Bedroom | piles (47): two cushions, two hops; friends in order (55): 1, 2, 3… |
| 63-80 | Yard | everything mixed, bigger boards |
| 81-100 | Dance Room | beat tiles (81): lit every third hop, landed on only when lit |

The first time a level brings a twist in, a banner says so (until that level has a result, like Squish Stack's).

## Stars, hint, rewards
- **Stars** (since 2026-11-16, the user's pick once every win became a full clear): **3 with no UNDO or RESTART, 2 with
  up to 3, 1 with more.** UNDO, RESTART (once a hop is made) and RETRY after getting
  stuck each count as one take-back; NEXT and REPLAY start the count again. The result card said "n TAKE-BACKS" (no line of numbers on it since 2026-11-17).
  (Before: 3 for a full clear, 2 for up to 3 cushions left, 1 otherwise.)
- **The meter** shows the stars still possible: off the full clear it's one fewer, since an UNDO is needed. Levels 5-100 have exactly one full clear, so this is exact: you're on it or you're not. Levels 1-4 ask the solver after every hop. Off it, the tip says "You can't clear every cushion from here. UNDO and try another way!".
- **Hint:** Squish Stack's rules. Every hint costs a rewarded ad (free with Remove Ads). The first one in a level asks first, and a hinted level gives one star less.
  - It shows the next cushion of the full clear, glowing gold.
  - If you've already left the full clear, it first takes you back to the last spot that was still on it ("Went back 2 hops").
- **RESTART** plays the same board from the start (a taken hint stays taken). There's no UNDO since 2026-11-17 (see the end).
- **Coins:** (8 + 0.6 per cushion + 4 per twist + 2 per friend) × stars (1 / 1.5 / 2) × tier (+15% each). That's 13 / 20 / 27 on level 1, 134 for 3 stars on level 90, and 198 on level 100.
- **XP:** Squish Sort's and Stack's formula, (10 + ½ × level + 5 × tier) × (0.6 + 0.2 × stars). Half on a replay, through playerXp.

## Every level is fixed
Unlike the other three mini-games, a level is the same board every time: played, replayed or retried. There's no random deal and no hidden skill score moving the tier. `src/hop/levelData.js` holds the 100 boards, made and checked offline by the prototype's `tools/gen.mjs` (unique full clear, effort score). A level's tier (EASY…EXPERT) is how hard its board measured against the others.

## Code (src/hop/)
- `engine.js`: the rules and the solver, an ES-module copy of `prototypes/squish-hop/engine.js` (keep the two the same, but for one rule: here the ★ stays shut until every other cushion is cleared, the prototype's opens once the friends are picked up; the solver finds the same full clears either way).
- `levelData.js`: the boards (written from the prototype's `levels.js`; don't edit by hand).
- `levels.js`: rooms, the time of day through each room, tiers, the map's list, stars, coins, XP, and the profile's `hop` record.
- `board.js`: the board's perspective, worked out in JS: leaned back 38°, seen from 13 tiles away, as the prototype's CSS.
  - It gives where a squishy stands, which cell a tap is on, and the cushions' outlines on screen.
  - Doing it in JS rather than with an RN 3D transform means drawing, standing and touching all use the same numbers. Only the rug uses RN's own `perspective` + `rotateX` (it's decoration).
- `Pieces.js`: the drawing.
  - Cushions and dance tiles as tilted SVG shapes, one view per layer so each can puff away and back.
  - Arrows, bubbles, the ★, the hint glow, and the flat cushion used in the goal card and the picker.
  - The squishies: Stack's cut-outs. Every hop is one native timing (`freshPose`), so nothing steps from JS. Their
    moves are under "Character animations (2026-11-17)" below.
- `Room.js`: the Crib's room layers scaled so the floor line sits about a third of the way down, the floor repeated below, the time-of-day tint; and `RoomCard`, the map's room picture.
- `Game.js`: a level (input, hops, puffs, friends flying to the goal card, undo, hint, stuck, win), and the next ones after it, with the Crib's room-switch flash between rooms.
- `Cards.js`: the result, STUCK, pause, hint and how-to-play cards.
- `roster.js`: the hopper and each level's friends.
- `src/screens/HopScreen.js`: the map (Squish Sort's `LevelMap`, with a band per room and its picture) and the game.
- **Hooked into the app:** the PICK A GAME card (`GamePicker.js` `HopArt`: a squishy hopping along three cushions that puff away), `LobbyScreen` `onOpenHop`, `App.js` stage `hop` (music: cozy).
- **Saved on the profile** (written by the client): `hop.{lv, best, plays, wins, seen}` through `saveHop`. firestore.rules doesn't block `hop`, so there's nothing to deploy.
- **Sounds:** all existing ones. Hop: `st_lift`. Puff: `fs_pop`. Bubble: `tap` (the bubble). Bump: `bonk`. Friend: `sd_squeak`. ★ opens: `sd_unlock`. Stuck: `sd_wrong`. Win: `st_land`, `sd_solve`, `sd_confetti`. Room change: `swoosh`.
- **Tests:** `node src/hop/engine.test.js`.
  - Every level's stored clear replays to a full clear, and the first eight have the number of clears the data says.
  - A tap anywhere in any cell finds that cell, on every board, at three area sizes, and the board fits.
  - The rooms, times of day, stars, coins and XP are right.
  - The solver itself is checked against brute force by `prototypes/squish-hop/tools/check.mjs`.

## Status (2026-11-07)
- Played on the Pixel_8_Pro debug build:
  - the picker card and its animation, the map (room pictures and banners), the how-to-play card on a first visit
  - level 1 (taps and swipes, puffs, the win, ALL CLEAR with +27 coins and +12 XP, level 2 unlocked and saved), NEXT to level 2
  - level 90 (Dance Room: beats, bubbles, piles, arrows), its whole 45-hop clear
  - level 58 (Bedroom: four friends in order, picked up and landing in the goal card in order), its whole clear
  - getting stuck (STUCK card, UNDO from it), the hint through a Google test ad (back 2 hops, the glow, one star less)
  - level 70 (Yard).
- **Fixed from the prototype:**
  - The goal card lists friends in pick-up order, and it grows to fit them.
  - Friends are smaller, and numbered chips are drawn over everything, so a friend behind another can still be read.
  - HOPS counts hops, not cells entered.
- **Not yet checked:**
  - the room-switch flash on NEXT into a new room
  - the friends' flight to the goal card, frame by frame
  - speed on a release build on the A15
- The levels are still the prototype's 100. The 600-levels-per-game plan (fixed, measured difficulty for every mini-game) is next, waiting on the user's decisions.

## Hub, BLITZ MODE and the ★ rule (2026-11-16)

The user, after Squishdoku's hub and Blitz redesign: "I want the same thing to be done with squish stack, squish hop.
also, in squish hop, change the rule so that the block that moves us to the next round is unlocked only after we
visited all the other blocks". They chose a hub **and** a new endless Blitz for Hop, and stars by take-backs.

**The ★ rule** (`engine.js` blockOf and the solver): above, under Playing. The ★ opening has its pop, sparkle and
`sd_unlock` on the hop that clears the last other cushion (it used to be the last friend landing in the goal card).
Tests: the ★ is `locked` with a cushion (or a pile's second layer) left, and random play on all 100 levels never ends
with cushions left.

**The hub** (`src/hop/Hub.js`, Squishdoku's `GameHub`; `HopScreen` now opens on it)
- The title alone, **REGULAR MODE** (the 100-level map, "37/100") and **BLITZ MODE** ("BEST: n") as wood plaques with a
  picture each, tapped as a whole, and HOW TO PLAY with a ?.
- The pictures are the Game Park's Squish Hop clip at its start, as is and in Blitz blue with bolts
  (`tools/games/mode-art.mjs` -> `assets/hop/mode-*.jpg`).
- The map's header keeps SQUISH HOP, the levels done and the ★ pill; its back goes to the hub. The ? moved to the hub.

**BLITZ MODE** (`src/hop/blitz.js`, `Game.js` `blitz`, `levels.js` blitzPrize / afterBlitz)
- The 100 levels are fixed and big (up to 54 hops, most with only one full clear): too much for a short clock, and
  easy to learn by heart. So Blitz deals **fresh small boards**, made on the phone in a couple of milliseconds the
  way `tools/gen.mjs` starts a level: a random walk covering most of a grid (skipped cells are holes), its start the
  squishy's cushion and its end the ★, friends on the walk and arrows pointing the way it leaves.
  - The climb: 3×3, 4×3 ×2, 4×4 ×2, 5×4 ×3, 5×5 ×3, then 6×5 for good. Friends from the 3rd board, arrows from the 6th.
  - Each board's clock: 5 s to look plus 1 s a hop, in whole seconds; past the climb 3% shorter each board, down to
    three quarters.
  - Every board is played in the Dance Room (the party room, like Squishdoku's Blitz).
- **The mistake** is a hop after which no full clear is left: the solver checks after every hop (at most ~30 ms on a
  computer for a 6×5 board). Getting stuck counts too, in case the solver ever gives up. A board's clock running out
  stops the run as well.
- Saving works as in Squishdoku (an ad once a run, free with Remove Ads; or gems 10, 20, 40 … through `blitzSave`).
  After a mistake the hops back to the last spot a full clear was possible from are taken back and the clock runs on;
  after the clock ran out, the board's clock starts again. END RUN is GAME OVER (BOARDS CLEARED).
- Each board cleared pays coins by its grid (3×3: 25, 4×3: 35, 4×4: 45, 5×4: 60, 5×5: 75, 6×5: 95) and a tenth of
  config/levels `xp.blitz.hop` in XP (a new key, 200 by default in `functions/squad.js`: 20 a board). Quitting or
  starting over mid-run pays too.
- No UNDO, RESTART or hints in Blitz. In their place, the glass with "1 MISTAKE = GAME OVER" and the board's clock.
  The strip shows CLEARED, BEST (NEW BEST in gold) and LEFT.
- Saved as `hop.blitz.{top, runs}`. The PICK A GAME card shows "BLITZ BEST n" once there is one.
- **Checked** in the web version's preview with the bundled cut-outs (`?phone=1&preview=1&card=hop-blitz`): the
  countdown with the board hidden until GO, board 1 cleared (the ★ opening at LEFT 0), board 2 with its own clock, a
  wrong hop opening the save card ("That hop left tiles you can't clear."), the free save taking the hop back,
  TIME'S UP without the used ad button, END RUN with +25 coins and +20 XP. Regular level 8: the ★ counting down
  from 19, the meter and tip off the clear, UNDO as a take-back, the result card with 2 stars and "1 TAKE-BACK". The
  gem save wasn't tried (it calls the server). Not checked on a phone.

## Character animations (2026-11-17)

The user: the hop arc and landing squash were "too subtle". They asked for bigger, juicier moves from the same
cut-outs (no new art), built on `freshPose`.

**What plays** (all in `src/hop/Pieces.js` `freshPose({ juicy: true })`, run from `src/hop/Game.js`):
- **Hop:** a crouch first (squashed down; the squishy doesn't travel yet), stretched tall as it takes off and while it
  falls, then a landing squash that wobbles back up (`LAND_MS`, 360 ms). A wider puff of dust fans out round its feet
  (the new `puff` kind in `src/squishdoku/fx.js`).
- **Direction:** it leans into the hop: sideways going left or right; away from the camera going up the board, toward
  it going down (`LEAN_X`, 22°). It faces the way it hops: as drawn going right, mirrored going left, with a quick paper
  turn in the crouch. Up and down keep the last facing. UNDO hops back without a lean.
- **Bubble:** landing on a bubble squashes the squishy flat, and the hop off it springs up tall with a jelly wobble in the
  air (`bp`, the boing). The take-off sound is `st_lift`, pitched up.
- **Bump:** it squishes against the way it can't go (narrow and tall sideways, flat up or down), then shakes its head
  (`no`, 560 ms, a turn about the middle). The hint's nudge doesn't squish.
- **Friend picked up:** the friend pops up behind the hopper in a happy little hop with a wiggle, then spins on its way
  to the goal card (`hap`, 760 ms; was a 640 ms flight). A ring of candy dots pops where it stood.
- **Win:** three happy jumps on the ★, tilting right, then left; the last one higher, with a spin round. Sparkles land
  with each jump, and gold stars burst at the spin (`joy`, 1150 ms; 900 ms in Blitz, before the next board drops in).
  The friends in the goal card cheer: three jumps with a wiggle, the last a spin, one after another. It all ends before
  the result card, which still comes at 1.3 s.
- **Stuck:** the squishy droops (sinks, widens and hangs forward), looks left, then right, and a sweat drop runs down
  beside its head, again and again. Then it sways slowly from side to side. The STUCK card now comes at 1.4 s (was
  1 s), so the sway shows before the card covers the board. A Blitz mistake or TIME'S UP does the same before its save
  card (still at 1 s and 0.9 s). UNDO, the hint, a save or a new go snap it back (`cheerUp`).
- **Tap on the squishy itself:** the wiggle, now one timing (`wig`).

**How it's built:**
- One system: Hop's squishies use `freshPose({ juicy: true })`. Each move is one phase 0 → 1, run as one linear native
  timing and read through keyframes (`HOP`, `BOING`, `LAND`, `JOY`, `HAP`, `NO`, `LOOK` …). Every keyframe list starts and
  ends at rest. Phases running at once multiply or add up, so a landing still wobbling while the next hop crouches gives
  way softly: the squash has a soft limit. The two `Animated.sequence`s are gone: the old two win hops and the stuck
  wobble, both stepped from JS. The sad sway and the sweat drop are native loops (`useKeyLoop`), on only while stuck.
- The travel waits out the crouch through its easing (`holdEase`): the frames are worked out once and played natively.
  A hop is still 190 ms (170 onto a bubble), a bump still holds input for 200 ms, and hops still queue as before. The
  landing, the head shake and the friend's flight play on while the next hop goes.
- `Piece` makes its interpolations once (`useMemo`). The hopper re-renders on every hop (its z), and that used to build
  new animated nodes each time.
- Squishdoku's room board (`RoomBoard.js`) still uses the plain `freshPose()`. Its pieces look and move as before.
- Rules, levels, the engine, stars and coins are untouched. `node src/hop/engine.test.js`: 11 passed.

**Checked** in the web version, frame by frame in headless Chrome with Playwright's fake clock
(`?phone=1&preview=1&card=hop-level&lv=8`, `lv=31`, `card=hop-blitz`):
- the bump, hops in all four directions, three hops queued at once, the friend pickup, the win with the goal card
  cheering, stuck and UNDO from its card (level 8);
- a boing off a bubble, mirrored going left (level 31);
- a Blitz win into board 2, and a wrong hop into the save card.

Fixed on the way: the first landing puff covered the squishy's belly (now it fans out low); the head shake was too small
to read; the friend's hop didn't clear a tall hopper's head; the sad sway was hidden behind the STUCK card.
**Not checked on a phone:** speed on the A15 release build, and Android's own drawing of the leans and turns (rotateX
from the feet, rotateY with a perspective; the web adds its own perspective, see `WEB_DEPTH`). The preview's friends
include some without a head picture (aeroswift), so their goal-card slot cheers as a blank circle there.

## Rig characters (2026-11-17)

The user, after the cut-out animations above: "when i say animation i mean an entire full body physics + the
characters need to be 3d and not 2d". There are no 3D models of the roster, so they chose the 2.5D rigs from Claude
Design (the lobby's live creatures: bones, mesh warp, a 2.5D head that turns, springs and a soft-body jiggle). Only
the characters change; the board, cushions, bubbles and the ★ stay as they are.

**How it works**
- **One page for every character:** `tools/rig/hop.html`, copied by `tools/rig/build.mjs` to
  `android/app/src/main/assets/rig/hop.html`. It loads the design's rig scripts, unchanged, as the lobby's `host.html`
  does, and draws the hopper and every friend on the board in a single transparent WebView. One WebView each would be
  too heavy for the A15.
- **`src/hop/RigStage.js`** lays that WebView over the board as big as the screen, so a friend can fly to the goal card.
  Touches pass through it. It sits under the order chips, the banner and the effects.
- **`Game.js` stays in charge:** the rules, the timing and input are unchanged. Each move is also sent to the page:
  `cast`, `enter`, `hop` (its legs), `bump`, `pickup`, `restore`, `win`, `stuck`, `unstuck` and `giggle`, with screen
  positions from `board.js`.
- **The page plays each move with the rig's own pose values** (squash, lift, tilt, lean, turn, pitch, arms, ears, spin,
  the face), through `ctrl.ext()`. The rig's springs add the follow-through on top (head jiggle, trailing ears and
  tail, the body's soft wobble). New moves are added in the design's own format (`RiveRig.add`): `hopSad`,
  `hopSadLook`, `hopPerk`, `hopGiggle`, `hopOops`, `hopJoy`. Bigger copies of the rig's particles are added too
  (`hopSweat`, `hopDust`, `hopHeart`, `hopSpark`, `hopPop`): the design sized its particles for the big lobby creature,
  and a sweat drop on the board came out a pixel tall.
- **The cut-outs stand in** (Pieces.js, the moves above) until the page says the board's cast is drawn (`onCast`).
  They also stay if a rig's art doesn't load within 9 s. A new level with new friends shows the cut-outs for a moment,
  then switches over.
- **While rigs are on,** the game's own landing puff and bubble poof are left out (that layer is drawn over the rigs,
  so they covered the squishy's face). The rig puffs its own dust round its feet and pops its own bubbles instead.

**What each move does on the rig**
- **Hop:** crouch, a stretched take-off with the arms up, an arc. It leans into the hop (sideways, or back going up the
  board, forward going down), the head turns toward where it's going and stays turned, then a squash landing with
  dust.
- **Bubble:** flat on the bubble, then it springs up tall with a jelly wobble as the bubble pops.
- **Bump:** squished against the edge, eyes wide and a frown, then a 2.5D shake of the head.
- **Pickup:** the friend does a happy hop behind the hopper (happy face, hearts), then spins off to the goal card,
  shrinking.
- **Win:** happy face and hearts, three jumps (tilting right, then left), the last one higher with a full 2.5D spin,
  sparkles, a landing squash.
- **Stuck:** turns back to the camera, droops (head down, ears and arms hanging, frown, teary eyes), looks left and
  right, sweat drops run down, then a slow sad sway. UNDO, the hint, a save or a new go play `hopPerk` and it's back
  to normal.

**Checked** in the web version, frame by frame (Playwright's fake clock reaches into the page's frame too):
- level 8: the bump, hops in all four directions, the pickup, the win, stuck and UNDO from its card;
- level 31: a boing off a bubble;
- Blitz: a win into board 2, and a wrong hop into the save card.

**Fixed on the way:**
- Moves started as another ended were dropped. That lost the boing's second leg and every landing squash.
- The crouch and the win landings were pancake-flat.
- A friend's pickup hop covered the hopper's face.
- The look round turned the head almost all the way round after a sideways hop.

**Not checked:**
- On a phone, and the A15's frame rate with several rigs in one page. The lobby measured one rig at about 90 fps.
  A board has the hopper plus up to a handful of friends, each smaller.
- Acorn's rig shadow is `rx="NaN"` in the design's own code (in the lobby page too), so it has no shadow, and the
  WebView logs an SVG error every frame for it.

## No UNDO (2026-11-17)

The user: "get rid of the undo button both in the pop up of once you fail and in the screen itself".
- **The level screen:** RESTART and HINT only, down the right (at the bottom right since 2026-11-17: see the end).
- **The STUCK card:** RETRY only.
- **The stars count the same take-backs, less UNDO:** RESTART (once a hop is made; the pause card has none since 2026-11-17) and
  RETRY after getting stuck. HOW TO PLAY says "No RESTART or RETRY for 3 stars!" (the result card did too, until 2026-11-17).
- **Off a full clear,** the tip says "RESTART and try another way!" (RESTART throbs instead since 2026-11-17).
- The hint still goes back to the last spot on a full clear by itself ("Went back 2 hops"). That's part of the hint,
  not an UNDO.
- Earlier sections that mention UNDO describe how it was before.

## The crying hopper on the STUCK card (2026-11-17)

The user: "in the pop up where user fails, show the character himself (not a bubble with him in it) with sad
animation, we start with a gentle sad animation and then the one where they cry really badly".
- The STUCK card shows the hopper whole, as its live 2.5D rig (`RigCreature`, the lobby's page), in place of the round
  sad head (`SadSquishy` in `src/hop/Cards.js`).
- **It plays the design's own moves** (`mittens-moves.js`, which work on every creature):
  - first `cry`, quiet crying: ears droop, teary eyes, a wobbling lip, a few tears, a wipe of the eye;
  - after `CRY_MS` (2.2 s), `sob`, heavy crying: it wails with tears gushing, its body shakes and it rubs both eyes;
  - then `sob` again, each time it ends, until RETRY.
- **While the rig loads** (about a second, in its own WebView), the hopper's full-body cut-out stands in. The cut-out
  also stays if the rig won't load.
- **Checked** in the web version: the card on its own (`?phone=1&preview=1&card=hop-stuck`, which now gets a hopper
  from the preview's cast) and level 8, played until stuck. The quiet crying, then the sobbing, the card still fits the
  sideways screen, and RETRY.

## Less text, arrow keys (2026-11-17)

The user, on a screenshot of the Kitchen level: "the squish hop level thing is too much, need to remove that text, +
there is too much text in instructions, make it simple with UI not text, and lastly the buttons, put them at the
bottom, and on the bottom left put 4 buttons that represent arrow keys which let us move the player with it".
- **No "SQUISH HOP · LEVEL n" line** under the room's name (nor Blitz's "SQUISH HOP · BOARD n"). The tier pill stays.
  The level's number still shows in its banner as it starts.
- **The goal card is pictures only:** a cushion (a mint tile in the Dance Room) with how many are still to clear on a
  purple badge (a green tick once they're all gone), the friends to pick up, `›`, the ★ cushion. Under it the stars
  still possible (Blitz: CLEARED and BEST), and the BEAT pill on beat levels. No LEFT or HOPS pills.
- **No tip line.** What it said is now shown:
  - a bump on the shut ★ or a friend out of order shakes the goal card, on an unlit beat tile the BEAT pill;
  - off a full clear, RESTART throbs (the meter already shows the star it costs);
  - the hint's "Went back n hops" is gone (the board shows it going back), and its way lights up on the arrow keys;
  - a new twist still gets its banner the first time (FRIENDS!, ARROWS!…), and HOW TO PLAY has the rules.
- **Arrow keys** (`DPad` in `src/hop/Game.js`): four cream keys in a cross at the bottom left, in Regular and Blitz.
  Each press hops that way as the finger lands (`SdButton`'s new `onDown`), the same as a swipe, and queues like
  one while a hop plays. The hint's key turns gold while its cushion glows. Swipes and taps still work.
- **RESTART and HINT** at the bottom right, one over the other. Blitz's rule and clock stay in the middle on the right.
  Upright, the keys sit bottom left with the buttons beside them.
- **Checked** in the web version at the A15's sideways size (832 × 384): levels 30, 61 (four friends in order: the goal
  card's row still fits), 82 (Dance Room beats), Blitz, and upright; three key presses along level 30's solution made
  three hops; the hint lit the up key on level 61. Not yet seen on a phone.

## The map in its rooms (2026-11-17)

The user: "the rooms change so there each background will be tailored to the room that the levels are played in (same
for squish hop)". Sideways the level map stands in the room of the levels in the middle of the screen: Squish Sort's
map reports it as it scrolls (`onFocus`), and `RoomBackdrop` (`src/royal/WorldBg.js`) fades to each new room. The
whole room shows (`Room` `full`), the row runs along its floor (`rowAt`), the bands' room signs stay, and the title is
on a cream plaque. My reading: the background follows the scroll and changes at the screen's middle, rather than
each room's stretch scrolling past as one picture. Web-checked only.

**Scrolling with the list (2026-11-17).** The user: the background in the level menu is "not being scrolled" when the
list is. So the reading above was wrong: each room's stretch now scrolls past with its levels. The map
(`src/sort/LevelMap.js`) reports where each room runs along the page (`roomOf`, `onSpans`: a room from just before its
first band's sign to the next room's), and drives an `Animated.Value` with the page's scroll on the UI thread
(`scrollX`, `Animated.event` with the native driver, `scrollEventThrottle` 16). `RoomBackdrop` repeats each room's
picture side by side (the Crib pictures run on into each other; mirrored copies would flip the signs' writing), puts a
wooden post where one room meets the next, and moves the lot by the scroll. It draws only the pictures within two
screens of the view. `onFocus` is gone. Web-checked only (no phone was attached).
