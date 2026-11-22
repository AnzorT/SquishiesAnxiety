# Redesign v9 (2026-11-16)

The user's list from 2026-11-16, with the Desktop zip `Squish-Squad-assets.zip` (exported 16 Nov). The zip holds:

- Three loading screens, each as an MP4 recording and three stills: *Heading home*, *To the treasure vault* and
  *Gathering your squad*.
- 117 creatures in four border looks, as 512 px PNGs:
  - look-1: shading only
  - look-2: thin ink line
  - look-3: bold ink line
  - look-4: bold colour line, the game's default

## The user's answers (AskUserQuestion)

- **Use the zip as it is.** I rebuild the three loading screens from the recordings as live animations. The four
  looks become still pictures, chosen in Firebase, and used wherever the app shows a creature that doesn't move. The
  animated creatures stay as they are.
- **The backgrounds** of the Level Pass, Achievements, Characters and Shop become the wood planks of the Game Park's
  game card: the menu's `--vel` and `--dia` planks.
- ***Gathering your squad*** plays when Characters opens. *Heading home* plays when entering the house. *To the treasure
  vault* plays after buying a chest, before it opens.

## Steps

1. **Crib back button:** the house page's back button becomes the app's wood back orb.
2. **Achievements bottom bar:** the title in the middle, how to unlock it below. No LOCKED or UNLOCKED.
3. **Characters:** the creature stands in the ring, not above it.
4. **Wood plank backgrounds:**
   - In the menu page: Characters and the Level Pass.
   - In the app: Achievements and the Shop.
5. **Level Pass redesign** (menu.js):
   - One row of levels, each one tappable. The tapped level's rewards show in one panel at the bottom.
   - There's no reward tile under every level and no big card for the next reward. This fixes the overlap while
     scrolling.
   - Rewards are drawn as what you get:
     - A chest shows that group's own chest, for example the Pet Shop Common chest.
     - A room shows a picture of the room.
6. **Rewards set in Firebase:** a chest prize in `config/levels` road can name its group:
   `{ k: 'chest', t: 'common', g: 'pet' }`. Without `g` it stays today's first HOT group. This needs a functions
   deploy.
7. **Loading screens:**
   - *Heading home*: menu → house.
   - *To the treasure vault*: buy a chest → the chest smash.
   - *Gathering your squad*: opening Characters.
   Each plays its entry, waits for the real load, then plays its exit.
8. **Creature looks:** `config/roster` gets `look` (1–4; 4 when unset) and an optional `looks: { <creature id>: n }`.
   The still pictures come from the zip's PNGs.

## Status (2026-11-16): all 8 steps built

Checked in the web version only: not on a phone, nothing committed.

1. **House back button:** `.mm-hback` is now the wood orb (CSS in `webgame/app/menu.js`).
2. **Achievements:** the bottom bar has the title in the middle, how to unlock it below, and the progress bar when the
   achievement counts something. No LOCKED or UNLOCKED. (`src/screens/AchievementsScreen.js` WideDetails)
3. **Characters:** the creature stands on the plate (`.sq-c2 .rig` moved down 28 px and made 150 px).
4. **Wood:**
   - In the menu, `WOOD_BG` is the page background (Level Pass, Characters).
   - In the app, `WoodBg` (`src/royal/parts.js`) shows a picture of the same CSS (`webgame/tools/wood-bg.mjs` ->
     `assets/royal/wood-bg.jpg`). Used on Achievements, the Shop and the RN Level Road.
5. **Level Pass** (`M.levels` in menu.js):
   - One row of 46 px level discs. Each is gold once reached, with a ! when it can be claimed, a check when done and a
     lock when not reached. The selected level has a cream ring and a pointer.
   - The selected level's rewards show in one wood panel along the bottom: LEVEL n, its state, CLAIM / CLAIMED /
     "n XP to go", and a card for each reward.
   - A chest card shows its group's own chest (`app/gchests/<g>-<t>-grow.webp`, copied in by `webgame/build.mjs`) and
     name.
   - Rooms and Yard Games show pictures from the house map; the house's next look shows the house
     (`webgame/tools/room-art.mjs` -> `webgame/app/art/rooms/*.jpg`).
6. **Rewards set in Firebase:** a road chest's `g` in `config/levels` (`functions/squad.js` prizeGroup; documented in
   `tools/admin/levels.mjs`; covered by tests).
   - The app sends each chest prize's group and names (`src/game/player.js` roadPrizes).
   - **Deployed 2026-11-16.** The first try failed because Google retired the Node.js 20 runtime on 2026-10-30.
     `functions/package.json` now asks for Node 22 and every function was redeployed on it. That also created the
     not-yet-deployed `gameCreatureWritten`, `gameItemWritten`, `gameAnimationsWritten` and `rebuildGameConfig`.
7. **Loading screens:**
   - **No progress bars** (the user, 2026-11-16: "from the loading screens, please just remove the progress bars").
     None of the three has the bar, its knob or the % any more; the tip stays. Each still keeps its unseen progress,
     which times the house's lights, the vault coin's walk along the trail, and when the squad's cards leave.
     (`assets/royal/vault-fill.png` and `vault-key.png`, still drawn by `vault-art.mjs`, are no longer used.)
   - **Stuck part way on the web (fixed 2026-11-16):** the user saw *To the treasure vault* stop part way along its
     trail. The Shop behind it goes to sleep (Freeze) once the smash has painted, and on the web (concurrent React)
     that held every later commit back while the loader's loops kept asking for frames, so nothing moved again. Fixed
     in Freeze for every screen: `src/components/freezeSync.web.js` (see src/web/README.md, "Freeze on the web"). The
     phone renders in legacy mode and never had it. Preview: `/?full=1&preview=1&card=smash`.
   - *Heading home* (menu.js `headingHome`; three patches in `webgame/patches.mjs`):
     - After the walk to the door, night falls on the real house. Stars and the moon come out, and the open rooms
       light up one by one as the house loads, the door last. Then the camera flies in.
     - 2026-11-17, the user: the lights weren't lighting the windows, just a big glow over each room. They now work the
       intro's way (`app/intro.js`): the night has holes where a lit room's windows are, and each window gets a warm
       pane and its own halo. The small round windows (attic, dormer, the dome's drum) and the porch lamps light too.
       The locked rooms' boarded windows stay dark. Web-checked at levels 3 and 26.
     - The house now counts as loaded when it says so (`state.ready`). Before, it waited for more than 12 pictures,
       and a house with 11 always waited the full 12 s.
   - *Gathering your squad* (menu.js `gatherSquad`, when Characters opens), as in the recording:
     - The deck deals five of your creatures' cards left to right, each turning over as it lands. The deck shrinks
       and is gone once the last card has left it (the user's correction).
     - While still loading, the cards turn back, gather into the deck and the next five are dealt (up to 15).
     - Once the row's pictures in view have loaded, the cards fade away up the table.
   - *To the treasure vault* (`src/components/VaultLoader.js`, art by `webgame/tools/vault-art.mjs`): plays over every
     chest smash until it has painted (ChestSmash `onShown`).
     - It covers the Shop's buys, free, ad, deal and bundle chests, the Deals claims, and the Level Road (and so the
       Level Pass and LEVEL UP chest claims).
     - Deals claims no longer use the falling ChestDrop.
     - Preview: `/?phone=1&preview=1&card=vault`.
8. **Looks:**
   - `tools/looks/encode.py <zip>` writes `android/app/src/main/assets/looks/<n>/<key>.webp` (384 px, about 6 MB for
     all) and `src/squad/lookKeys.js`.
   - `src/squad/looks.js` withLooks: App.js's `creatures` carry the chosen look in `thumb.url` (`asset:/looks/...`;
     on web `/android_asset/looks/...`).
   - The menu's still pictures (character cards, the Level Pass avatar, the loaders) use it through `state.looks`.
   - Set it with `tools/admin/roster.mjs --look n [creatures]`, or `look` / `looks` in `config/roster`. It is 4 when
     unset; 0 means the old pictures.
   - Prickle and Wisecrack aren't in the zip and keep their pictures.
   - **The live creatures too** (2026-11-16, the user: "the character himself does not have the look 3, for example
     look at the character at main menu"). `webgame/app/rig-look.js` draws the look's outline round every animated rig
     as an SVG filter on the group holding the whole creature (not its floor shadow): look 2 a thin ink line, 3 a bold
     ink line, 4 a bold line in a dark shade of the creature's colour; 0 and 1 no line.
     - Outer edge only: unlike the pictures, there's no line where an arm crosses the body. A line on each part was
       tried; the rigs build their parts too differently (spirals on Aurora and Finn, nothing on Mittens).
     - Colours are measured in the pictures by `tools/looks/lines.py` (-> `webgame/app/look-lines.js`); widths (rig
       units: 0.6 / 1 / 1) were matched to the pictures by eye.
     - The game's pages (menu, Characters, the house, the loaders): `rig-look.js` wraps `RiveRig.mount` and follows
       `state.looks` live. The app's own rig page (`tools/rig/host.html`, Squishdoku's buddy, sign-in): `RigCreature`
       sends `rigHost.look(n)` from `useRigLook` (`src/squad/looks.js`, fed by App.js's `config/roster`).
     - Checked on the web: menu, Characters and Blitz buddy all in look 3. Not yet checked: the house, or the frame
       rate on the A15 (one filter per creature on screen, so the house's squad costs the most). Squish Time's 3D
       creature has no outline.

## Round 2 (2026-11-16)

- **The vault room** (the user: "where is the vault room?"; their pick: the place every chest is opened). The chest
  smash page (`tools/chest/host.html`) stands in an underground treasure vault, where *To the treasure vault* flies in:
  - A stone wall with a glowing arch full of gold behind the chest, two wall torches that flicker, a stone floor, and
    gold, gems, goblets and old chests in the corners. It's a picture drawn once by `tools/chest/vault-room.mjs`
    (`tools/chest/vault-room.jpg`), which `tools/chest/build.mjs` copies next to host.html.
  - Two banners on the wall in the chest's group colour.
  - The page's purple (HP bar, hint text, reveal backdrop) is now brown and gold.
- ***Gathering your squad*** now follows the recording: the deck is gone once the last card has been dealt (the user's
  correction). See step 7.
- **Functions deployed** on Node 22 (see step 6).

## Round 3 (2026-11-16): the Squishdoku hub and BLITZ MODE

- **The hub layout**, from the user's marked-up screenshot:
  - The title is at the top in the middle.
  - The two modes are side by side in the middle.
  - HEAD START and HOW TO PLAY are along the bottom.
  - The page is on the wood.
- **The cards in the new design**: wood plaques like the Game Park's game card, with no PLAY or GO buttons. The card is
  tapped.
  - REGULAR MODE has the progress bar and "25/600" on one row.
  - BLITZ MODE shows only "BEST: n".
- **HEAD START** has no creature picture, says what it does plainly, and is for Regular mode only.
- **HOW TO PLAY** has a ? where the X was.
- **BLITZ MODE is endless:**
  - Each board has a short clock of its own.
  - A mistake or the clock running out is GAME OVER, unless the run is saved with an ad (once) or gems (10, 20, 40 …).
  - Each board cleared pays.
  - This needs a functions deploy for the gem save (`blitzSave`).
- Details in SQUISHDOKU.md, "Hub and Blitz redesign (2026-11-16)".

## Round 4 (2026-11-16): the same for Squish Stack and Squish Hop

- The user: "I want the same thing to be done with squish stack, squish hop". Both got the hub in the new design and
  an endless BLITZ MODE with saves, as Squishdoku's Round 3.
  - The hubs share Squishdoku's pieces (`GameHub` in `src/squishdoku/Hub.js`). Each card's picture is its game's Game
    Park clip (`tools/games/mode-art.mjs`).
  - Squish Hop had no hub or Blitz before; its Blitz deals fresh small boards (`src/hop/blitz.js`).
  - The save and GAME OVER cards take a `unit` (puzzle / board) and a line on what went wrong.
- Squish Hop's ★ now opens only once every other cushion is cleared, and its stars count UNDOs and RESTARTs.
- Details in SQUISH_STACK.md and SQUISH_HOP.md, "Hub and BLITZ MODE (2026-11-16)" / "Hub, BLITZ MODE and the ★ rule".
- The gem save needs `blitzSave` deployed (Round 3's functions deploy). The `xp.blitz.hop` default is read by the app
  itself, so it needs no deploy.
- The STUCK card and every mini-game's result card (the stars, or Squishdoku's score creatures, and Blitz's champion
  card) are one column in landscape too, as upright: the title and picture on top, the text, coins, XP and buttons
  under them (the user's marked-up screenshot and pick, 2026-11-16). `Overlay`'s `column`
  (`src/squishdoku/Overlays.js`): set tighter, with the stars and score creatures at 72% and the XP bar and LEVEL n!
  side by side (`useCompact`), so a result with a level-up fits the 384 dp height. The other popups keep two columns.
- Every mini-game's pause card is one column in landscape too: PAUSED above its buttons (the user's screenshot).
- **Squish Stack's level and Blitz** (the user's two marked-up screenshots, 2026-11-16):
  - No UNDO (RESTART and HINT only), no clock in Regular or Blitz, no stars meter, no level number, no game name, no
    tip lines, no dashed outline round the cushions.
  - The counter at the top in the middle: MOVES n / par (n turns red once past the par: 3 stars is at or under it) and
    the tier. Blitz: CLEARED, BEST, the tier and 1 MISTAKE = GAME OVER.
  - Sideways: the back button top left, the goal card bottom left, RESTART and HINT side by side bottom right; the
    cushions in the middle between two side columns of the same width. Upright: the back button and the counter along
    the top, the goal under them, the two buttons at the bottom.
- The fail cards are one column in landscape too, their two buttons the same size and RETRY in the app's gold:
  Squishdoku's TIME'S UP / OUT OF HEARTS, Squish Sort's TIME'S UP / OH NO, Squish Hop's STUCK. Squish Stack's TIME'S UP
  is gone with its clock.
- Every pause card's buttons: RESUME in the app's gold, RESTART / NEW PUZZLE and QUIT / LEVELS white, as the fail
  cards (the user: "buttons need color changed"). Squish Stack's no longer mentions a clock.
- 2026-11-17: one pause card for every mini-game, Regular and Blitz (Squishdoku's `PauseCard` in
  `src/squishdoku/Overlays.js`; the copies in hop/stack/sort `Cards.js` are gone): gold PAUSED, RESUME (gold) and QUIT
  (white), no text line. No RESTART / RESTART LEVEL / START OVER on it (the user: "the restart button should have
  already been removed"). Squish Hop and Squish Stack keep RESTART on the level; Squishdoku and Squish Sort have none
  mid-level now (QUIT and pick the level again).

## Round 5 (2026-11-16): the vault room, warm and cosy

The user: the chests "look blurred in the vault room", "are too small", "the hp meter doesn't look related to the
vault", and "the vault is not looking great, it should be in the same warm and cozy Squish Squad app".

- **The room** (`tools/chest/vault-room.mjs` -> `vault-room.jpg`) is redrawn in the app's colours:
  - Honey wood planks over a panelled wainscot, with a beam and warm string lights along the top.
  - A round brass vault door stands open behind the chest, its opening glowing with gold.
  - The chest stands on a berry-red rug with a gold border, on warm floorboards.
  - Two brass wall lanterns, with old chests, a coin sack, a gem jar and coin piles in the corners.
  - The banners (the group's colour) hang from the beam. The lantern glows flicker.
  - Both sit in `#vault`, the picture's own cover box, so they line up on any phone shape.
- **The treasure is the app's own** (the user, 2026-11-16: "change the chests in the vault into our chests, from the
  selected squad only; replace the coins and gems with the ones in the app; more coins, chests and gems"):
  - The coins and gems are the app's currency pictures (`assets/squad/currency`): heaps behind and in front of the
    corners, a bank of coins inside the open vault door, coin stacks, coins and gems scattered on the floor, and a jar
    of gems. Gems get a soft glow, as they're pale on the gold.
  - The chests are the opened chest's group's own five (`assets/squad/gchests/<group>-<tier>-grow.webp`): Legendary
    and Epic on the left with Common in front, Rainbow and Rare on the right. The coin sack, goblet and drawn old chests
    are gone.
  - So there's one picture per group: `tools/chest/vault-room.mjs [group]` -> `tools/chest/vault/<group>.webp` (11,
    about 265 KB each; WebP via the page's canvas), copied by `tools/chest/build.mjs` to the chest assets' `vault/`.
    `vault-room.jpg` is gone.
  - host.html `roomFor(group)` decodes the group's picture before it goes up, and `start()` says 'shown' after it
    (0.8 s at most), so the loader never leaves onto a room still loading.
  - Preview: `/?full=1&preview=1&card=smash&group=fruit`.
  - Round 2 (the user: "add much more", the chests "look out of context, they do not merge with the coins and gems",
    "why is the chest texture blurred"):
    - Sharp: the chests are drawn by the chest engine itself (tools/design-v6, as `tools/shop-art/groupchests.mjs`
      draws the Shop's) at twice their size on the screen. The Shop's 480 px pictures drawn at ~410 px had come out
      soft; the coins were sharp because they're shrunk to half.
    - Merged: no Shop glow; a soft contact shadow; the room's warm light on them (a colour filter); each one sunk in its
      heap with the next heap piled over its foot; some tumbled at a tilt.
    - More: heaps rising up both corner walls, ten chests (the left corner Legendary, Rare, Epic, Common; the right
      Rainbow, Epic, Legendary, Rare), heaps beside the vault door, gem clusters, coin stacks, a bigger bank of coins
      in the door. About 360 KB a group (about 3.9 MB for the 11).
    - A taller coin mountain inside the vault door was tried and reverted (the user: "not looking good"); it's the
      low bank of coins.
  - **The shine** (the user: "add the shiny flicker that pops on gold and gems, and on the legendary and rainbow
    chests"): the menu crest's twinkle (a cream four-point star that pops, turns 90° and fades in ~0.9 s), with a glow:
    gold on coins, cool on gems, pink on the Rainbow chest.
    - Sixteen at a time (eight in lite), each popping on another spot when it's done: coins about half the time, gems
      a quarter, the group's two Legendary chests and its Rainbow chest the rest.
    - The spots are saved by `vault-room.mjs` as it draws: coins near each heap's surface, every gem, and each group's
      Legendary and Rainbow boxes -> `tools/chest/vault/spots.js` (`window.VAULT_SPOTS`, copied with the pictures).
    - host.html `twinkles()` starts once the first room is up. They're CSS animations of transform and opacity
      only, so the chest's canvas pays nothing for them.
- **The HP meter is the vault's lock plate:**
  - Wood in a brown rim (the app's plaques), with gold bars for the hits left.
  - A brass padlock that shakes with each hit and opens when the chest bursts.
  - The tier chip is cream with a brown rim, the name is in the app's gold lettering, and the hint is a cream pill.
- **Bigger chests:** in landscape the chest is sized from under the HUD to just over the hint, for the tallest model
  (host.html `fitStage`).
  - The engine's portrait sizing had left every chest at its smallest scale, 0.6.
  - The scale is now ~1.04 on the A15 (about 1.7x bigger), and a chest still grows when it upgrades.
- **Sharp chests:** the canvas is the screen's own resolution, up to 3x. It was 1.5x, or 1x in lite, on the A15's
  2.81x screen.
  - Lite now halves the particles only.
  - Only the chest page's own slowness (its watcher, or its remembered `sq.chestLite`) lowers the resolution, to 2x.
  - A weak phone (2 GB or 2 cores) starts at 1.5x.
  - The menu's slow step no longer blurs the chest.
- Checked in headless Chrome at the A15's size and density. Not yet on the phone: its frame rate at full resolution
  needs a look (the tester FPS pill), and the APK needs a rebuild because the page is an asset.
- **Sign-in, sideways** (the user's screenshot, 2026-11-16): the card is narrower (580 dp, was 700), as the Log in button
  looked wrong stretched across it; no "Log in or make an account to save your squad." line under the title (upright
  too; an error still shows there sideways). To fit Register's four fields in one row: the fields' text 14 px, and
  the password hint "6+ characters" (Log in keeps "At least 6 characters").

## Round 6 (2026-11-16): the new game intro replaces the splash screen

The user: "squad-intro file in desktop holds the new game intro, delete the old one and put the new one".

- **The intro:** the designer's `Desktop/squad-intro.js`, "Squish wakes the house", copied unchanged as
  `webgame/app/intro.js` and loaded by the menu page.
  - It starts at night in the rain, outside the house. A box drops in, and a tap opens it: Mittens pops out.
  - Squishing Mittens three times lights the rooms. At dawn the squad peeks out of the windows and the SQUISH SQUAD
    logo drops in. Then TAP TO START.
  - Skip, or Android back, ends it at any time.
- **The old splash screen** (Mittens + title + loading bar, `src/screens/SplashScreen.js`) is deleted. At launch the
  app now shows its launch colour until it's ready: sign-in known and, signed in, the profile and the catalog loaded
  (10 s at most). The purple fonts-loading screen is that colour too.
- **When it plays:** once a launch, the first time the menu shows.
  - The daily spin, the streak screen and the level-up card wait until it's over.
  - A new account sees it when the menu first shows after the tutorial, since the tutorial uses the classic Home.
- **Hooking it up:** it was written for the Nov 14 menu's `startIntro`. Our menu is the Nov 13 one, so
  `webgame/app/menu.js` builds the same api:
  - Mittens stands in for the player's own character during the story.
  - The HUD is hidden while it plays.
  - The six rooms it lights are opened in its house picture (the Nov 13 house boards them up at level 1).
  - The Nov 13 rig has no lighting, so the night is a filter on the creature.
  - At the end, the player's real house and character come back.
- Web-checked: the whole story with taps, TAP TO START, and Skip. Not yet on the phone.
- **Frame rate** (the user: "the intro has very low FPS"). On the weak-phone bench (`tools/perf/intro-bench.mjs`) it was
  12-19 fps; it's now 39-57, with the plain menu at 54. The look is unchanged (checked side by side). The changes:
  - Its two houses are drawn still, as the menu draws its own (`stripAnim`). They had brought back the scene's own
    animations, which repaint the whole picture every frame.
  - The menu's weather layer is hidden while it plays.
  - In `app/intro.js` (marked PERF):
    - The rain is two prepainted layers the compositor slides, instead of 80 CSS-animated SVG lines.
    - Each moving layer is its own GPU layer: the box, the effects and ring, the waving squad (moved out of the masked
      night layer), the morning house's fade-in and Mittens. Moving them used to repaint the house beneath.
    - Each logo letter is its own small layer that's moved, not one SVG redrawn every frame.
  - The night layer stays on the house's layer, because its window glows blend with the house.

## Round 7 (2026-11-17): the Daily Spin

The user, with two screenshots (the "You won!" card and the wheel sideways): "change the buttons color, the coin with
the amount we received should be in the same row", "remodel the spinning wheel so it fits the current game design",
the prizes "always spinning … they change their degree in order to stay up" (read as: they should turn with the wheel,
not stay upright), "change the coins and gem's design in the wheel to match the ones in the game", and "remove 1 prize
and put there … 1 mystery box". All in `src/screens/DailySpinScreen.js`.

- **The wheel**, in the menu's look: an ink outline and lip, the menu's gold rim (`RIM`) with brass studs whose lights
  blink, cream and wood slices split by ink lines with gold pegs at the rim, the Mystery Box slice gold, the 50-gem
  jackpot amethyst. The pointer is a gold drop, and the SPIN hub is a round gold plaque with the menu's lettering.
- **The prizes turn with the wheel.** Each one is fixed in its slice, standing out from the middle; the old
  counter-rotation that kept them upright is gone. The winning slice's prize is upright under the pointer when it lands.
- **The coins and gems** are the HUD's (`squad/currencyArt` COIN[0] / GEM[0], through `LevelBits` `PrizeArt`), on
  the wheel and on the card.
- **The Mystery Box** (my picks: which slice, and its odds): the 150 coins slice is now one Common chest, with the
  same 14% weight. It's today's first HOT group's chest, as the level road's chests, and the wheel shows that chest.
  The server opens it in `spinWheel` (`functions/dailySpin.js` `spinOutcome` → `squad.js` `openGroup`). The card's
  button reads **Open**, and the chest smash plays under "To the treasure vault". Its COLLECT goes back to the wheel.
- **The card:** the prize picture and the amount (with COINS / GEMS / MYSTERY BOX under it) on one row; Collect in
  the app's gold.
- **The buttons:** "Watch ad, spin again" in the app's gold, "Continue to my squad" white, as the games' cards.
- Web preview: `/?full=1&phone=1&preview=1&card=spin` (`&i=2` lands on 250 coins; the box by default). A made-up
  server; nothing reaches the account.
- **Deploy `spinWheel`** (functions). Until then the live server still pays 150 coins on that slice: the wheel lands on
  the box and the card says +150 coins.
- Web-checked (wheel, chest spin, smash and back, a coins spin, portrait). Not yet on the phone.
- **2026-11-18, a real wheel** (the user, on a screenshot: the outer ring "is not spinning and it should", and the
  pointer "needs to be affected by the wheel that is spinning like in real spinning wheels"):
  - The rim's 16 lights turn with the wheel (`Lights`). The gold ring under them looks the same at any turn, and its
    light stays fixed.
  - The gold drop is now a **flapper**: a gold tongue hung from a round cap with a screw, above the rim. Its tip
    reaches in between the gold pegs on the slice lines. Each peg knocks it aside as it passes, it slips out under the
    tip, and the flapper springs back, wobbling (`stepFlap` / `useFlapper`: a ~11 Hz damped spring, a ±48° hinge,
    small sub-steps so a fast whirl still hits every peg). During the whirl it buzzes, bent against the pegs. As the
    wheel slows, each peg flicks it. At rest it hangs straight in a slice's middle.
  - The physics runs in JS from a listener on the wheel's angle (the wheel itself still turns on the native driver),
    only while something moves.
  - The wheel starts with a slice's middle under the pointer (`REST`), not a peg. The layout keeps room above the wheel
    for the cap (`CAP`), so the wheel is a little smaller sideways.
  - Web-checked with the preview: pointer angle sampled per frame, frames looked at. Not yet on the phone (needs no
    APK: Metro). The sounds are unchanged; the ticks are still the recorded ones, not one per peg.

## Round 8 (2026-11-17): the Shop's tabs slide

The user: "in the shop, when i am in daily, if i go to chests or deals or anything on his right side, i expect the
current items to exit on the left side and the new items from the right side", and the other way going left.

- `ShopScreen.js` (the sideways Shop, `royal`): `goTab` notes the switch (`tabSwap`: from, to, which way). The page
  being left stays up on its own layer while the new one slides in beside it, a whole page width, 0.4 s. A tab to the
  right: the current items leave to the left and the new ones come in from the right. A tab to the left: the other way.
  Tabs further along slide the same way.
- One native timing moves both pages. It starts two frames after the switch, once the new page has been drawn at its
  start (a timing started in the render that builds the page waits for that build on Android).
- The leaving page takes no taps. A tap on another tab mid-slide starts a new slide from the page coming in. Opening
  the Shop on a tab (a purse, GET SEASON CHEST …) just shows it, with no slide.
- Web preview: `/?full=1&phone=1&preview=1&card=shop` (`&tab=chests`: the tab it opens on). It uses a made-up wallet.
  Only switch tabs there: the buttons call the server.
- Web-checked: frame-by-frame positions of both pages for Daily → Chests, Chests → Daily and Daily → Special offers.
  Not yet on the phone.
- 2026-11-17: one result card for every mini-game's level win, as with the pause card (`ResultCard` in
  `src/squishdoku/Overlays.js`; the copies in hop/stack/sort `Cards.js` are gone, each keeps its titles as
  `RESULT_TITLES`; Squish Sort's result `Star` moved there too). The user showed Squish Hop's with "modify, you know
  how?", read as the day's rulings: less text, one card for all, the main button gold. So: no line of numbers under
  the title (LEVEL n · tier · hops / moves / time / mistakes), no "… for 3 stars!" / "A hint costs one star" tip, no
  NEXT: LEVEL n · room / LEVEL n UNLOCKED line, no "NO ✕ · NO MISTAKES" under Squishdoku's PERFECT stamp (which now
  has room above the coins sideways). MENU (Squishdoku: MAP) and REPLAY white, NEXT gold (was wood and green). The
  title, stars (Squishdoku: its score creatures), coins, XP and the level-up box stay. The three buttons are one size
  (`trioFace`, 100 dp faces, 16 pt labels; the user: "the 3 buttons are not the same size").
- 2026-11-17, the result card's stars are live characters (the user, on Squishdoku's: "i dont want there to be the
  circle and a static image of the creatures, i want a genuine character there that is grayed and once they are
  filled their color changes and they jump from joy, not a fast jump, a slow one and they show happy animations").
  All four games, since it is one card: three of the design's 2.5D rigs (`keys`) on one page,
  `tools/rig/result.html` → `android/app/src/main/assets/rig/result.html` (`tools/rig/build.mjs` copies it), laid
  over the card's row by `src/squishdoku/Trio.js` through Hop's `RigStage`. Which three: Squishdoku's score
  creatures (`roster.js keyOfUri`), Hop's hopper in the middle with two friends, three of Stack's stack, three of the
  fridge's own squishies in Sort (`trioOf` tops up from the cast).
  - They pop in grey. At 420 + i × 760 ms an earned one fills with colour from its feet up (an SVG filter greys it
    above a rising edge with a gold shine; not a backdrop-filter, which greyed the card behind the page too), its
    face lights up, it crouches and jumps slowly (0.64 s up turning round, 0.32 s hanging, 0.46 s down, a squashy
    landing with sparkles and hearts), then plays happy moves in turns (two bounces, a wave, a wiggle, a hop with a
    twirl) with a sway, hearts now and then, and the gold rays behind it. A missed one sighs, sheds a tear and stays
    grey and a bit sad. My choices: the slow turn in the air, the moves, the sounds (the star sounds at each fill,
    `sd_hop` at each take-off), the grey shade.
  - The stars' sounds, the PERFECT stamp (lower now, across their feet) and the coins wait for the page to draw the
    three; the buttons come at 1.5 s regardless. While it loads, each one's cut-out stands in as a soft grey shape.
    If the page can't draw them in 4 s (or won't load: an APK from before it), the card shows its old stills.
  - Cost: grey and missed ones are drawn once, then kept; happy ones every other frame between moves, every frame
    through the fill and jump; after 15 s the sway stops and they stand still between moves (the page sleeps).
  - Web-checked at 832 × 384 and 384 × 832 (previews and a real win in each game). Not yet on a phone: the page is an
    APK asset, so it needs a new build; until then a phone shows the stills. Preview: `&keys=a,b,c` (`none`: the
    stills) and `&stars=n` on `sd-result`, `sd-perfect`, `sort-result`, `stack-result`, `hop-result`.
- 2026-11-17, the chest reveal (the user, with a screenshot of Melo's: "when we open a character from the chests we need
  to display them with the new card designs + the +1 copy, the progress bar and the collect need their designs
  updated"). In `tools/chest/host.html` (copied to the APK's assets):
  - **The card** is the Characters screen's card (cards v6, as the design's own Chest Smash v2 reveal draws it): the
    rarity's frame, the group's background in its window with the shine sweeping over it, the creature bobbing, its
    name in its rarity's lettering (as text when there's none drawn for its rarity). The page loads the game pages'
    `cards4.js` and `names.js` from `../webgame/export/cards4/`. The picture is the creature's still in its Firebase
    look (`ChestSmash.js` `rewardOf`: `../looks/<n>/<key>.webp` from `rigLookOf`; the old front SVG when it has
    none). The rarity chip and the creature's line sit under the card. The pictures are fetched while the chest is
    smashed. No creature (loot only): a cream card.
  - **+1 COPY** (and NEW SQUISHY! / UNLOCKED!): gold lettering, as the chest's name, on a wood plaque, popping in.
  - **The copies bar**: the vault lock plate's wood, the creature's head in a cream disc on its left end, a gold fill in
    a dark groove, the count on it, "Find **5 more** to unlock Melo!" under it; a shine runs along it once full.
  - **COLLECT**: the app's gold button (the games' RESUME / RETRY), with a shine passing over it.
  - Sideways: the card on the left (as tall as the screen allows), the rest on the right; upright: the label, the card,
    the rest under it.
  - Web-checked at 832 × 384, 640 × 360 and 384 × 832 (the page on its own, every rarity, a copy, the unlocking copy,
    a duplicate with coins) and through the app's preview (`card=smash&id=33&copies=7&need=12`). Not yet on a phone:
    the page is an APK asset, so it needs a new build.
- 2026-11-17, **the unlock** (the user: "after we reach the number of cards we need to receive the character i [want]
  there to be an animation where all the cards come together and them bam comes out the character"). In
  `tools/chest/host.html` (THE UNLOCK, styles and script), when the chest brings the copy that unlocks its creature
  (`isNew` with `need` > 1):
  - The reveal opens on the creature's copies (small cards v6 cards). The ones found before fan out of the middle of
    the creature's place into a ring round a count on a wood plaque (1 / 12 … 11 / 12, a bell a step higher each).
    The new one flies up from where the chest stood, big and spinning, with a gold glow (12 / 12, a chord).
  - The ring swells, then spins in faster and faster as the cards go white-hot, into one stack that shakes harder
    and swells, then squeezes. BAM: a white flash, two shockwaves, gold, white and rarity-colour sparks and
    confetti, the screen shakes, a deep thump with a fan of bells.
  - The creature grows out of the light as its **live 2.5D rig** (my reading of "comes out the character": the user's
    standing rule is that character animation means the full-body rigs). Stretched tall with its arms up, it turns round once, hops (as high as the
    room over its head allows), lands with dust and sparkles, and plays the rig's `happy`. After that it does the
    lobby's shuffle of happy moves, and it can be poked.
  - Then its name (gold lettering, under its feet), its rarity chip, UNLOCKED!, the full bar, "<name> joins your
    squad!" and COLLECT come in as on any reveal. The creature takes the card's place.
  - Sideways, all of it happens in the **middle of the screen** (the user, after seeing it on the left: "the animation
    should be played in the middle as well as the character that we just unlocked"): on an unlock the reveal is three
    columns, UNLOCKED! and the bar on the creature's left (`#rvStart`), the creature, COLLECT on its right (`#rvEnd`).
    The ring, the BAM and the rig follow `#hero`, so they moved with it. Then every reveal got the same three columns
    (the user: "in the cards, please put the card in the middle and the progress bar in the left side like you did in
    the animation"): +1 COPY / NEW SQUISHY! / UNLOCKED!, the bar, coins and the lucky meter on the left, the card in
    the middle, COLLECT alone on the right. Portrait is unchanged (one column). Web-checked at 832 × 384 and 640 × 360.
  - About 3 s to the BAM for 5 copies, 3.5 s for 14. A tap during it skips to the BAM.
  - The rig scripts (`../rig/`: rive-rig, rive-generic, pet-defs, mittens-moves, rig-shuffle, look-lines, rig-look,
    about 0.9 MB) load into the chest page only for an unlocking copy, from the moment the chest bursts. Its art is
    fetched from `../rig/export/` through a fetch shim. A generic rig is built then and kept undrawn until the BAM; a
    design rig (Mittens) is made at the BAM. It wears the creature's border look (`rewardOf` now passes `look`).
  - If the rig isn't ready by the BAM, the still pops out and the rig takes over when ready. If the rig never loads,
    the still stays.
  - A creature a chest gives whole reports copies = need too, so it plays the same unlock.
  - Web-checked through the app's preview at 832 × 384 and 640 × 360: Melo (12), Frybo (5), Mittens (design rig),
    Mallow with the rig art blocked (the still), and Marina with a tap at 0.8 s (the skip). +1 COPY (7 / 12) is
    unchanged and loads no rig. Preview: `card=smash&id=33&copies=12&need=12`.
  - Not yet on a phone: it needs a new APK (the page is an asset). The A15's frame rate during the merge and its rig
    load time are unmeasured.
- 2026-11-17, *To the treasure vault* (the user: "only the map zooms in, i need everything there to be zoomed in so it
  won't look weird"): the way out now zooms the whole screen into the X as one layer (the table with its candle,
  compass and coins, the candle's light, the map with its trail and coin, the title and the tip), the X staying where
  it is (`src/components/VaultLoader.js` `sceneMove`; it was only the map's box). Web-checked frame by frame on a fake
  clock at 832 × 384 (`?full=1&preview=1&card=vault`); it's JS, so the phone gets it with the bundle, no APK needed.

## Round 9 (2026-11-18): each chest holds only its own rarity

The user: "common chests gives you only common characters, rare gives you only rare, epic epic, legendery gives only legendery and of course rainbow only the rainbow characters".

- **The rule** is `chestPool` in `functions/squad.js`: a chest gives a creature of its group whose rarity is the chest's. The drop odds per size are gone. The Shop's cards say "Only Common pals", and a chest's sheet lists only the pals it can give.
- **The Lucky meter is gone from group chests.** It turned every 10th chest into an Epic, which would break the rule.
- **The first-smash upgrade stays.** A Common or Rare chest that upgrades holds the rarity it became. This is my reading, the user can still rule it out.
- **Avo and Duchess are Legendaries now** (my call). They were labelled Rainbow, but no Rainbow chest holds them, and Avo is needed to earn Fruit Patch's Rainbow chest.
- **A group with none of a rarity** (Elemental has no Common or Rare, Masked Heroes only a Legendary) doesn't show or sell that chest. A chest that's given for it (free chest, prize, bundle) comes from the first group that has that rarity.
- **Needs a functions deploy.** Until then the live server still rolls the old odds.
