# Redesign v8: the wood look, a cleaner menu, the shop and games remade for landscape

Started 2026-11-14 from your list of fixes (with the house's Renovate / Catalog buttons as the new look).

## Your rulings

- **The look:** the house's wood buttons (Renovate / Catalog) replace the purple velvet and the pink everywhere:
  - a striped wood panel, #e6b47c → #cf955a → #b47a42
  - a dark brown outline and lip, #6b4426
  - gold rivets
  - cream labels, #fff6e2, with brown lettering, #5b3418
- **No diamond tips** (the small squares on the ends of the buttons), anywhere.
- **Characters:** bright, warm and shiny instead of purple.
- **Gems:** every pack side by side as a tall card, all on screen without scrolling. The 2X bonus is a ribbon above them.
- **Daily streak** stays in Deals, the same size as "No more ads".
- **Shop chests:** only Common, Rare, Epic and Legendary are sold. A group's Rainbow chest is never sold. It's given when the
  player has collected that group's characters from Common to Legendary, and it unlocks the group's Rainbow character.
- **The settings gear** is cut off at the screen's edge: move it in.

## My readings (tell me if wrong)

- **"The music in the beginning needs to continue playing":** the sign-in music stops when the menu opens (the menu
  plays no music). It now keeps playing on the menu and the Game Park.
- **The "beep":** it's the screen-change whoosh. Its sound file has a steady 1050 Hz tone in it. It plays when the
  splash makes way for the first screen, and also on every later screen change. It's removed at the start, as asked. Say
  if it should go everywhere.
- **Sign-in and registration "on a horizontal":** they're already sideways, but the form is a tall column (about 570 dp
  on a 384 dp screen), so it scrolls. Now the fields sit side by side and everything fits the screen. A new account's
  email check stays sideways too.

## Steps

| # | What | Where |
|---|---|---|
| 0 | The wood look everywhere: the menu's colours (ink, velvet, rims) and the app's royal kit; no diamond tips | `webgame/app/menu.js` (CSS), `src/royal/theme.js`, `src/royal/Plaque.js` |
| 1 | Main menu: no SQUAD; MY HOUSE / CHARACTERS / SHOP move left; coins, gems and the gear spaced, with the gear moved in from the edge; bigger coin and gem icons over the left of their pills; a trophy button next to the gear (Achievements, taken out of Settings); the level crest recoloured; tapping the house no longer walks in; music continues; no beep at the start | `webgame/patches.mjs`, `webgame/app/menu.js`, `App.js`, `SettingsRoyal.js` |
| 2 | Sign-in and registration fit the landscape screen, in the wood look | `src/screens/AuthScreen.js` |
| 3 | Characters remodel: warm and bright; your character in the middle on a spinning ring of lights (10 dp below the feet), its name and two tags; no filters, no "12 of 111", no location button, no "Baby"; every character in one row below, Common → Rainbow | `webgame/app/menu.js` (`M.characters`) |
| 4 | Shop remodel: Chests / Deals / Gems as tabs across the top under "Shop". Chests: one group at a time with its 4 chests side by side, the group's name above, arrows at the screen's sides. Deals: the two cards the same size. Gems: every pack side by side | `src/screens/royal/ShopChestsRoyal.js`, `ShopDeals.js` |
| 5 | Game Park: no coins pill, no "5 games · Frybo plays every one" | `webgame/app/menu.js` |
| 6 | Squishdoku in landscape: hub, level map and board laid out sideways, in the wood look | `src/squishdoku/*` |
| 7 | Squish Sort in landscape | `src/sort/*` |
| 8 | Squish Stack in landscape | `src/stack/*` |
| 9 | Squish Hop in landscape | `src/hop/*` |

Every step is checked in the web version (http://localhost:8081, the A15-size frame) before the next.

## Status (2026-11-14)

Steps 0 to 5 are built and checked in the web version. Nothing is committed.

- **0, the look:**
  - App side: `src/royal/theme.js` makes 'vel' wood, INK brown, the orb a wooden knob, the page amber, pearl cream and the lettering's white cream. `Plaque.js` never draws tips and adds the wood grain. `parts.js`: `PageBg` is warm, and the pills have the big pictures.
  - Menu pages: `menu.js` sets `--ink`, `--vel`, `--rimG`, `--dia` and `--spk` on `.mm-root`, with no `.tip` diamonds. `patches.mjs` changes the gold and white lettering outlines.
  - Every `#3d1268` in `menu.js` is now `#6b4426`.
- **1, the menu:**
  - No SQUAD (patch). The tabs start at the left.
  - The pills have the big pictures, with room between them.
  - The gear sits 30 from the right edge.
  - A trophy orb (`SquishMenu.trophy()`) sends `open achievements`, which reaches `GameScreen` `onAchievements` and then App `openAchievements`. Achievements is gone from `SettingsRoyal`'s links.
  - The crest has a ruby medallion, cream wings and a green XP ring.
  - `.mm-hot` ignores taps.
  - Music: App plays 'bounce' on the Menu (stage home), and nothing inside the house.
  - No whoosh when leaving the splash.
- **2, sign-in:**
  - The fields sit side by side, the button sits beside "Keep me signed in", and the social buttons are one short row. It fits 832 x 384 without scrolling.
  - The card is cream, the switch pill and button are gold, and the sky is warm (`IntroBackground`).
  - `auth`, `verify` and `splash` are always landscape, even for a new account.
- **3, Characters:** `M.characters` rewritten, with `.sq-c2` CSS.
- **4, Shop:**
  - The tabs are a centred row under the title.
  - Chests (`ShopChestsRoyal.js`) is pages: "Today" (Free, Rare for an ad, the daily deal, Lucky), then each group's 4 sold chests and a Rainbow progress line (OPEN when ready). Arrows at the sides, dots, swipe.
  - Deals: the cards are columns of the same height (the `DealsWide` context). "No more ads" is blue and the jar is teal.
  - Gems: the 6 packs are in one row under a 2X ribbon, with the swaps as chips below. No pink or purple.
- **5, Game Park:**
  - No coins pill and no subtitle.
  - The game cards are wood.
  - The tent is red and cream.
- **Tests (2026-11-14):** while clicking through the old Shop layout in the web version, a test tap hit the daily deal's buy button. The test account spent 320 gems on that day's deal chest; it's test currency only.

### Round 2 (2026-11-14, your follow-ups)

- **Characters:**
  - The row goes group by group, each with a cream label and a divider. Within a group it runs Common to Rainbow.
  - The ring is now a golden platform seen at a slant. It turns slowly (12 s a turn) with its lights riding on its rim. Each light is counter-turned and counter-squashed, so it stays round.
  - The stage is a little smaller (rig 140), so the name row and the cards fit under it.
- **Shop:** a **Daily** tab, left of Chests, holds the free chest, the ad chest, the daily deal and the Lucky meter (`ShopDailyRoyal`). The free / ad count badge moved to it. Chests is now only the groups.
- **Settings:** no Level Pass link. SAVE (the nickname) is centred at the bottom of the screen; the nickname box fills its panel.
- **Achievements, landscape remodel:**
  - The carousel spans the full width in the middle, with the badges spread out (`xOfWide`).
  - The details are one wood bar along the bottom: the number and title, the description, then the progress and status.
  - The progress bars are gold, the locked badges warm, the locks wood, and the halo has no pink.
- **The web version, fixed:** a browser paints positioned boxes over plain ones whatever their order, so react-native-svg icons and text inputs vanished under the plaques' fill layers. `src/web/setup.js` now makes them positioned. This was web-only; the phone was fine.

### Round 3 (2026-11-14): scrolling, groups, and steps 6 to 9 (the games sideways)

- **Characters:**
  - The row is dragged with a finger or the mouse and glides on after a flick; a mouse wheel scrolls it too (`dragRow` in `menu.js`). A drag never counts as a tap on a card.
  - Arrows at the row's ends jump to the previous / next group.
  - The current group's name stays pinned at the left while you scroll through it.
- **Every sideways list scrolls:**
  - On a phone a finger already did.
  - The web version drags any sideways-scrolling box with the mouse (`src/web/setup.js`); paged lists snap back to a page.
  - The Level Pass track uses `dragRow`.
  - The Shop's chest pager updates its dots and arrows as it scrolls.
- **Deals:** the pink "Mega bundle" style is now warm ruby. The pink and purple buttons are orange and wood.
- **The games (steps 6 to 9):** `GameFrame` takes `full`, and App's `GAME_FRAME` has `full: true` for all four. A game then has the whole screen and lays itself out sideways; `useWide()` / `useGameDims()` tell it.
  - **Squishdoku:**
    - Hub: the title, level, HEAD START and HOW TO PLAY on the left, REGULAR and BLITZ on the right.
    - Map: the chapter's room, name and wood arrows in a column, then the 20 levels winding left to right.
    - Level and Blitz: the top bar, the score / clock glass and the time of day on the left, the board in the middle, the buddy and PLACE / MARK (stacked) on the right.
  - **Squish Sort:**
    - Hub: the title, BLITZ and HOW TO PLAY on the left, the fridge and cupboard cards (shorter) on the right.
    - Map: sideways, each band's banner and picture over its first level.
    - Level: the top bar, rounds and clock on the left. The fridge or cupboard gets the full height, with the tray as a column at its right (`trayGeoWide`).
  - **Squish Stack:**
    - Hub: two columns.
    - Map: Sort's.
    - Level: the top bar, goal, stars and par on the left, the cushions in the middle, UNDO / RESTART / HINT down the right.
  - **Squish Hop:**
    - Map: Sort's.
    - Level: the top bar and the goal strip on the left, the board in the middle, the controls down the right.
  - **The rooms behind the boards (Squishdoku, Hop):** in landscape the picture spans the width and is raised so its floor line sits 30% down, with the floor repeated below (`roomGeometry`). The board gets most of the height.
  - **Colours:**
    - The shared candy palettes are now warm: `squishdoku/ui.js` BTN pink → orange, purple → wood, white with a brown rim.
    - The theme's INK and RING are brown, and the pink title fill (`TITLE_FILLS.pink`) is orange app-wide.
    - The map nodes, banners, level pills and XP bars across the four games no longer use pink or purple.
    - The games' backgrounds are the warm page (`GameBackground`) with wood back orbs (`GameBack`).
    - The puzzles' own colours (Squishdoku's nine patches, Stack's cushions) are untouched: the games need them.
- **Tests:**
  - webgame smoke 3/3, bridge 37/37 (its Characters test now finds the new page).
  - The web and Android bundles compile.
  - Every game's hub, map and a level were opened in the web version. The Blitz screens weren't opened; they share the same layouts.

### Round 4 (2026-11-16): every screen and popup checked sideways

You asked me to go through each screen and popup and fix whatever still wasn't made for the landscape screen. I opened
each one in the web version (832 x 384, the A15 sideways). Fixed:

- **The games' popups** (win, time's up, out of hearts, stuck, pause, hint, revive, Blitz lost / won, how to play) in
  all four games: in landscape the card is two columns, the title and stars or picture on the left, the numbers and
  buttons on the right (`<Split />` in `squishdoku/Overlays.js`). They were tall cards that ran off the screen.
  - Squishdoku's how-to-play has the little board and GOT IT! on the left and the rules on the right.
  - The cards are cream, not pink and lavender.
  - The cream buttons' lettering is brown (`BtnLabel kind="white"`).
- **Level up:** a wide wood card, the level on the left, the prize and COLLECT on the right. It was a purple card
  taller than the screen.
- **Daily Challenges:** wider, the two lists side by side, the daily chest under them. It no longer scrolls.
- **Daily Streak:** everything on one screen. The flame with its line and bonus, today's card and LET'S GO are on the
  left, and all ten days are on the right, five to a row (day 10 is a tile). The prize grid was cut off before, and the
  bonus line hid behind the button. The cold flame (no streak yet) is blue, not purple.
- **Level Road:** the road runs left to right (drag it sideways), with the level, XP bar and counters across the top.
  It was a purple card and a list running down.
- **Squish Time:**
  - Its settings popup is two columns (sound and display, then the squish) and fits under the gear. It ran off the
    bottom.
  - Its side panel and coin pill are wood, and the bottom of the sky is peach instead of pink.
- **Shop:** a chest's info sheet shows the chest and its button on the left and the odds and squishies on the right.
  It was a tall picture with everything else below the fold.
- **Blitz (all three games):** the 1-10 progress dots are smaller in landscape. They overflowed Squishdoku's left
  panel. Sort's "ROUND 1/10" stays on one line.
- **Email check (new accounts):** Mittens and the title on the left, the card on the right, in the sign-in screen's
  cream and gold. It was a column taller than the screen.
- **Colours:**
  - The shared candy palette is warm now: brown ink and outlines, cream paper, amber stage, and orange instead of pink
    for buttons. The candy theme's ink, outline, sheet and background; `squad/ui` PINK; the round buttons; the
    toggles.
  - Leftover purple and pink are gone from the stats, the spin wheel and its prize card, the achievement toast and the
    tester-only Test wallet.
  - The title outlines across the games are brown.
  - The house's "Loading your house…" page is dark brown, not dark purple (`patches.mjs`).
  - The phone's launch screen colour is `#2A1608`. It needs a new phone build (`app.json` and `colors.xml`).
- **Settings:** the Test wallet now covers the SAVE button instead of sitting under it.
- **Web version only:**
  - Two fixes in `src/web/setup.js`. Squish Time's sky took up room in the layout and pushed the creature behind the
    boost panel. The feedback box was invisible.
  - Testing helpers (`window.__app`, `?preview=1`), described in `src/web/README.md`.

**Still not landscape: the guided tutorial.** A new player, or anyone who taps "Replay tutorial" in Settings, still
gets the old portrait Lobby, Shop and Crib until the tutorial ends (`NEW_DESIGN_DURING_TUTORIAL = false`). It's a
rewrite, not a layout fix:

- Its steps point at the old screens.
- Its last part teaches the old Crib (feed a squishy, its moods), which the new house doesn't have.
- The menu's buttons live inside the menu page, so it needs coach marks of its own there.

**Tests:** webgame smoke 3/3, bridge 37/37. The web and Android bundles compile. Nothing is committed, and nothing
was checked on a phone.

## Music: only Velvet Map Study (2026-11-16)

The user: "remove all the background music files that are not Velvet Map Study".

- **Deleted:**
  - `assets/audio/music/`, all but `velvet_map_study.mp3`: the five moods (calm, cozy, dream, mystery, party),
    Butterscotch Bounce, the old Crib's six room tracks and five club songs.
  - The unused `assets/audio/music-*.wav` and `assets/audio/preview/music/`.
  - The rendered WAVs in `tools/audio/out/music-*.wav`.
  - The house's Dance Room song (`music/rubber-band-hustle.mp3`).
- **What plays now:** Velvet Map Study, from the end of the splash on, on every screen (`musicFor` in App.js).
  - It continues, without restarting, into Squish Time, the four games and their Blitz, the box, the Shop, Settings
    and the email check. Before, the Shop, Settings and the email check had no music at all.
  - The old Crib plays it under its own music switch. Its DJ song pill is gone. Its DJ Booth upgrades still say
    "2 songs … 6 songs" (old Crib only, reached by the old tutorial).
- **The house:**
  - The house page still plays only its own sounds.
  - Its Dance Room speakers use the room's built-in beat (a `webgame/patches.mjs` patch).
  - The build no longer ships `music/`. The design's own copy in `webgame/.cache` and its zip are untouched.
- **The audio tools:** `tools/audio/encode.py` skips `music-*.wav`, so a re-render of the effects can't bring the
  tracks back.
- **Checked:**
  - In the web version, the only music file played on the menu, the four games, the Shop and Settings is
    `velvet_map_study.mp3`.
  - Smoke 3/3, bridge 37/37, and both bundles compile.
- **Recovering a deleted track:** the tracks are still in git history (`git checkout HEAD -- assets/audio/music/<file>`
  until this is committed).

## The games' level screens: the row in the middle, the menu's world behind (2026-11-16)

The user: "in the levels screen, the list needs to be in the middle; change the background of the levels screen to
something that matches the map screen UI design". My reading:

- "Levels screen": each mini-game's level map (Squishdoku's is titled LEVELS).
- "Map screen": the main menu's world behind the house and the Game Park.

**The row in the middle:**
- The shared map that Sort, Stack and Hop use (`src/sort/LevelMap.js`) had its row at 74% of the height, under the
  band signs. Now:
  - The row runs along the middle line with a gentle wave.
  - Each band's sign (its picture over its banner) stands in the row before its first level. No dots run through a
    sign.
  - The current level's squishy sits on its right when a sign is on its left.
- Squishdoku (`src/squishdoku/LevelMap.js`): its wave was ±66 px, from near the top bar to near the bottom. It's ±24
  now, level with the chapter card.

**The background:**
- It's the menu world's own art, drawn by its scene code (`main-menu-scene.js`) without the house: sky, sea and
  lighthouse, grass with flowers, trees framing the edges.
- `webgame/tools/levels-bg.mjs` renders it to `assets/royal/levels-{sunny,rainy,snowy}.jpg` (2340 x 1080, about
  100 KB each).
- `src/royal/WorldBg.js` picks the picture by the month, as the menu's world does. It always shows the lush world
  (level 30), not the player's level.
- `MapBackdrop` shows it behind each game's level map only (landscape), fading in with the map's slide. The hub and
  the levels themselves keep the warm page.
- **Replaced 2026-11-17** (the user): Squish Stack's map is a forest that scrolls with its road and has the selected
  character walking it (SQUISH_STACK.md "Forest road map"); Squishdoku's and Squish Hop's stand in the room their levels
  are played in, Squish Sort's in the kitchen (`RoomBackdrop` in `src/royal/WorldBg.js`; the rooms scroll with the
  list, SQUISH_HOP.md "Scrolling with the list"). The world pictures,
  `levels-bg.mjs` and `MapBackdrop` were deleted (they're in git history, 2ab1004).

**Checked** in the web version (all four maps) and both bundles compile. Not checked on a phone.
