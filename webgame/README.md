# webgame: the new design inside the app

The app's Main Menu and house are the designer's prototype itself (`Squish Squad Prototype Nov13.zip`), running in a
WebView (`src/game/GameScreen.js`). The screens are drawn by the prototype's own code, so they match the design
pixel for pixel. Nothing is redrawn in React Native.

- **Main Menu** (`Main Menu.dc.html`, landscape) replaces Home's squish tab (the Lobby).
- **Squad House v6** replaces the Crib. MY HOUSE in the menu walks into it, and so does every "open the Crib" in the
  app (the Lobby's Crib button, daily challenges).
- **PLAY / GAMES** opens the design's own Mini Games page with the app's games:
  - Squish Time (the design's card)
  - Squishdoku (600 levels), Squish Sort, Squish Stack, Squish Hop, each card showing the player's level
  - PLAY on a card opens that game (the app's own screens; Squishdoku and Hop still play in the old Crib's rooms,
    which is why `src/crib` stays).
  The list and the progress lines come from `src/game/player.js` (`menuGames`); the card pictures are drawn in
  `webgame/app/games.js` in the style of the design's own game icons.
- **The 7 yard games** (Hoop Shot … Ping-Pong) are only in the house: a YARD GAMES button (the menu's gold tab style)
  in the backyard opens the same page with them, over the house. They're no longer on the Mini Games page.
  Since 2026-11-18 they're the designer's Nov 17 versions (see "The yard games' zip" below).

## The yard games' zip (2026-11-18)

`yard-mini-games.zip` (repo root, the designer's handoff of Nov 17; its own README.md and NOTES.md say how the games
work) is laid over the prototype: `YARD_ZIP` in `webgame/lib/prototype.mjs`. Any file in the zip's `app/` folder
replaces the prototype's file of the same name. What that changes:

- **The 7 games** are the landscape versions (780 x 360 stage, `land: true`): Hoop Shot with its aim path, Penalty Kick
  with the run-up and the keeper's dive, Slide & Splash with the long slide and the kiddie pool, Ping-Pong with paddles in
  the paws, and so on. Each opens on an intro poster (`yg-intros.js`, added to the menu page by a patch) with your
  creature drawn in look 3.
- A landscape game fills the whole Mini Games page (`.mm-gp.land`, main-menu v14's two CSS lines, patched in); its own
  top bar and intro carry back (‹ goes to the Yard Games) and how to play.
- **The creature system they were tested with:** `rive-rig.js` v1117b (held props, per-rig look), and the creature fixes
  of Nov 14-16 (Quill the hedgehog, Duchess / Bean / Zippy arms, Razzy's berries, new art for Mittens, Biscuit, Bean,
  Duchess, Ribbit, Truffle, Waffles, Zippy). The menu and the house use them too.
- **Looks:** this rig has the design's border looks built in, on by default (look 4). The app's look comes from Firebase
  (`app/rig-look.js`), so rig-look.js sets the built-in one to 0, and a patch skips measuring the shapes for a line no
  one draws. Only the intro posters keep their own look 3 (the user's pick in the design).
- **Older WebViews:** a patch makes the rig's `isPointInFill` use an SVGPoint (Chromium before ~128 throws on a
  DOMPoint; it killed the menu in the test Chromium).
- Coins on the results card are still a preview (`+N coins (preview)`): nothing is paid.

**The user's changes (2026-11-18):**

- **Yard Games page** (`app/games.js` `yardCard` / `yardPage`, hooked into main-menu.js `openGames` by patches):
  - Wide cards, each with its game's intro poster and your character in it. The character is drawn live for about a
    second, then kept as a still, one card at a time.
  - The list drags sideways with a finger or the mouse and glides on. A drag never counts as a tap.
- **A yard game opens only when its toy is bought** in the Backyard's shop (`yardLocked`; bought = the house's
  `owned['R:<id>'] > 0`):
  - Hoop Shot: YRD-102. Penalty Kick: YRD-104. Hopscotch: YRD-101.
  - Bounce Up: YRD-120/121. Slide & Splash: YRD-123/124/125.
  - Cornhole: YRD-037. Ping-Pong: YRD-057.
  - Catalog rows whose name matches also count.
  - A locked card shows a padlock on its greyed poster and "Buy the … in the Backyard (price)". Tapping it says the
    same.
  - The Backyard's level rule still comes first.
- **Hoop Shot** (patches on `yg-hoop.js`, plus `ctx.addTime` in `yard-games.js`):
  - You stand at the three-point arc (`FZ`, 0.95 m nearer the hoop), higher on the screen.
  - A full pull is 95, not 150, so the pulls that score end well inside the screen.
  - It stands right in front of the hoop (`PX` 0; it used to be 0.5 m to the left), facing it. The held ball sits
    between its two paws (`pawsAt`), so from behind the body hides most of it (the user: fine). The throw lifts it into
    view over the head.
  - Every basket adds 10 seconds ("+10s" under the clock).
- **The games' toys are bought, never placed** (the user; `app/games.js` `yardGameOf` / `yardStrip` / `yardNew`, patches
  on `Squad House v6.dc.html`):
  - The catalog's Games tab in the Yard sells them. Buying one unlocks its game behind the backyard's YARD GAMES
    button, which shows a NEW badge (`2 NEW` for two) until the Yard Games are opened.
  - No "Place it" on their cards, and they aren't in Renovate's tray.
  - A toy placed before this rule leaves the yard when the house loads. It stays bought, so its game stays unlocked.
  - One toy per game is enough: after any slide or trampoline, the game's other toys show UNLOCKED and aren't for sale.
- **No coins pill** on the Yard Games page.
- **The yard games' popups are in the app's look** (`app/games.js` `YPOP` CSS + `yardPopup`, called by two patches in
  `yard-games.js` once the intro sheet or the results card is built). Only the games inside the app's page get it.
  - The intro's how-to sheet and the results card are the app's card: cream paper, a white rim, a brown outline and
    lip.
  - Titles use the app's outlined lettering: "HOW TO PLAY" in gold; on the results card, gold for 3 stars, orange
    otherwise.
  - The rules sit in numbered orange discs, as in Squish Hop's how-to.
  - Buttons are the app's: gold PLAY / PLAY AGAIN and cream YARD GAMES. Option chips are cream, the chosen one gold.
  - The stars have a gold-and-brown edge, and the coin row has the menu's coin.
  - The back buttons (the intro's and the game's top bar) are the app's orange orb.

A newer yard zip: replace the file (same name) and run the build and tests. A file the zip has that the prototype
doesn't is only shipped if a page loads it (add its `<script>` with a patch, like `yg-intros.js`).
- **SHOP** (and the coin / gem pills) opens Home's Shop tab, as before; its squish tab comes back to the Menu.
- **The settings gear** opens the Lobby (Squad, level road, trophies, settings…) with a MAIN MENU pill back.
- Players in the guided tutorial stay on the Lobby and the old Crib until it's done: the tutorial points at them
  (`src/game/flags.js`).

## Round 11 (2026-11-14): the menu as a game lobby

`webgame/app/menu.js` does all of it; `webgame/patches.mjs` (the "round 11" block) hands it the menu's insides
(`opts._x`) and swaps the pieces of the HUD. Nothing of the design's own code is redrawn.

- **HUD:** no "Cozy home" / "Next: room" pills, no GAMES tab, no "Let's play / Mini Games" board. PLAY stands on its own
  (bigger, with a glint). CREATURES is **CHARACTERS**. The coin and gem pills have room between the icon and the number.
- **The level crest is alive:** its wings flap now and then, the star flips, a shine sweeps the medal, sparkles
  twinkle (LEVEL sits on a gold banner under the medal), a pink ring shows the XP to the next level, and a pink badge counts the prizes waiting. Tapping it opens the
  **Level Pass**: a track of every level (the road's prize, plus what the level opens: rooms, the yard games, the
  house's next look), a preview of the picked level, your character riding the track at your XP, CLAIM / CLAIM ALL.
  Coins and gems are claimed right there (the app calls `levelClaim` / `levelClaimAll`); a level with a chest opens the
  app's level road on it (its chest smash).
- **PLAY:** the character turns, walks left, and the camera follows it to the **Game Park**, a new part of the map left of
  the house. It's drawn with the scene's own sky, grass, trees and weather (`MainMenuScene.svg({ ...st, park: true })`),
  so it changes with the level and season like the house does. A tree and bushes stand on the seam. The games line up in a
  carousel under rays and a halo: one big card at a time, as wide as the gap between the two arrows: the game's name, its
  clip across the whole card, then a line about it, your progress and PLAY; swipe, the arrows or the dots change it.
  One straight road joins the two places: from the house's path to its left edge (`SquishMenu.houseRoad`, patched into
  the scene's `path()`), carried on across the park, with one line of stepping stones like the house path's own,
  evenly spaced from the house's path to the park. No stone pad under the character (house or park), and no
  "Lv n" signs on the house's locked parts (their boards still show they're locked). The middle one plays a 5-second clip of the real game: `webgame/app/previews/<id>.mp4` + its
  first frame `<id>.jpg`, recorded on the emulator. Squish Time's clip is Frybo; for any other character the card
  squishes that character's picture instead. The park remembers the last game picked. Back (or Android back) walks home.
  A game started in the park comes back to the park.
- **CHARACTERS:** a full screen. Your character's live rig on a lit pad (left) with its nameplate, rarity, group, stage
  and finish, and CHOOSE (it then stands in front of the house). On the right is every character that's out, yours first,
  the others as silhouettes with a lock, with filters for All / Mine / each group. A locked one can be tapped to meet it,
  and "Find it in chests" opens the shop.

**Re-recording a clip:** `adb shell screenrecord --time-limit 12 /sdcard/x.mp4` while playing (the emulator records at
720x1280). Cut 5 s into a 1000x400 (2.5:1) clip, H.264 baseline, no audio: the whole board or scene (a 520-660 px tall band; pan it slowly
top to bottom and back for a tall board: ffmpeg `crop` with a `cos(2*PI*t/5)` y) shown whole in the middle, and the
sides filled with the game's own edge colours stretched out (a smooth gradient on sky backgrounds, the floor on the
wood ones), so it isn't zoomed in and there's no blur. Grab a frame as the .jpg. Keep each under ~400 KB.

## Build

```
node webgame/build.mjs        # -> android/app/src/main/assets/webgame (also runs before every Android build)
npm run android               # builds the game, then the app
```

The build:

1. Unpacks the zip into `webgame/.cache`.
2. Copies only what the shipped pages use. That's about 41 MB: the pages, their scripts, and the creature art and
   house data.
3. Swaps internet files for local copies, so it runs offline:
   - React comes from `webgame/vendor` (the same file unpkg serves).
   - Google Fonts come from `webgame/vendor/css` (the same .woff2 files Google serves to Chrome). Both were fetched
     once by `node webgame/vendor.mjs`.
4. Adds the app layer (`webgame/app/*`) and the Firebase hooks (`webgame/patches.mjs`).

**A new design zip:**

1. Put it in the repo root and point `PROTOTYPE_ZIP` in `webgame/lib/prototype.mjs` at it.
2. Run `node webgame/tools/dump-config.mjs` to refresh the creature, animation and item list.
3. Run `node webgame/build.mjs`. If the designer changed one of the hooked spots, the build stops and names it.
4. Run the tests below.
5. Run the Firestore seed (next section) so new creatures, animations and items show up there.

## Firebase control

| Firestore (console) | What it controls |
|---|---|
| `gameCreatures/{key}` (118 docs, e.g. `mittens`) | `animations.<id>`: `false` and this creature never plays that animation. Its fallback plays instead: another seat for a seat, another food for a food, otherwise its next move or idle. `enabled`: `false` hides the creature (nobody owns it). `rarity`: 0 common … 4 rainbow. `gait`: the walk style, one of the list in `gaits`. |
| `gameItems/{itemId}` (788 docs, e.g. `LIV-011`, `BCH-004`) | `cost` (coins), `lv` (unlock level), `enabled`: `false` takes it out of the catalog. Already-bought copies stay in the house. `designCost` / `designLv` show the design's values. |
| `config/animations` | `on.<id>`: `false` switches that animation off for every creature. |
| `config/roster` → `groups` | **Which groups are out**: `{ snack: true, fruit: true, …, heroes: false }`. Only the groups switched on (`true`) appear anywhere: the Menu (CREATURES, the house), the Shop's chests, the Squad, the games. A group not listed is off. `hidden: ['79']` still holds back single creatures (ids). The server rolls chests by the same switches (`functions/squad.js` `hiddenOf`). `node tools/admin/roster.mjs --groups` writes the switches as things are now; `--show spooky` / `--hide spooky` flip one. |

- Each animation has one switch. Steps in and out (`bedin`, `bedout`, `bedwake`) follow their main animation (`bed`).
- `idle` can't be switched off: everything falls back to it.

**How changes reach the app.** The scheduled function `rebuildGameConfig` (`functions/gameConfig.js`) boils all of
this down into `config/game`, a small doc of only what differs from the design. The app listens to it, and the running
game applies a change straight away: prices re-price the open catalog, and animations switch on the creature's next
move. A console edit reaches the phones within about a minute.

**Setup, once (needs the service-account key and the Firebase CLI):**

```
cd functions && npm install && cd ..
GOOGLE_APPLICATION_CREDENTIALS=<key.json> node tools/firebase/seed-game-config.mjs   # --dry to preview, --reset for design values
firebase deploy --only functions:gameCreatureWritten,functions:gameItemWritten,functions:gameAnimationsWritten,functions:rebuildGameConfig,firestore:rules
```

**Re-running the seed:**

- It adds new creatures, animations and items.
- It keeps every change you made in the console.

**With no config at all:** the game is exactly the prototype.

## The roster (functions/squad.js)

The app's 119 creatures: the Oct 19 design's 86 (ids 0-85) and the Nov 13 design's 33 new ones (ids 86-118: Truffle,
then the design's 86-117). Ids are permanent (the collection is keyed by them), so the app's ids differ from the
design's; the game and the app talk by key (`webgame/app/roster.js`, `src/game/player.js`).

- Rarities and group rewards follow the Nov 13 design (`REWARD_KEYS`: Tutti, Pearl, Sprout, Aurora, Sugarplum, Corny;
  Pet Shop and Dreamland have none). Avo and Duchess, Rainbow in the design, are Legendaries in the game (`RAR_NOW` in `app/config.js`), since each chest holds only its own rarity and no Rainbow chest holds them.
- 38 is the Sea Turtle (it was Shelly; the design gave the name Shelly to a new pet, 99).
- Prickle (15) left the design: retired (`RETIRED`), never out again; a player who owns him keeps him.
- A new creature appears in the app's own screens once its art is published (`creatures/{id}`):
  `DESIGN_DIR=webgame/.cache/Squish-Squad-Prototype-Nov13-96241839/squish-squad node tools/plush-art/render.mjs 86 87 …`
  then `tools/plush-art/publish.mjs` (with the same `DESIGN_DIR`). The Menu and the house have every creature's art
  already.

## The app <-> game link

The app hands the game its state before the page loads (`window.__SQUISH_INIT__`). After that, both sides talk in
messages (`webgame/app/bridge.js`).

**The player belongs to the app.** The bridge writes it into the prototype's own localStorage save before its
scripts run:

- `level` (the XP level), `coins`, `gems`, `owned` (creature keys), `col` (their finishes and growth stages), `sel`
  (the selected creature), `hiddenKeys` (creatures in groups switched off), `games` (the Mini Games list), `house`,
  `xp` (`{ level, into, need, per }`: the crest's ring) and `road` (the level road: `{ lv, k, n, t, got, claimable }`)
- Android's WebView can run the app's `injectedJavaScriptBeforeContentLoaded` after the page's first scripts, so
  `window.__SQUISH_INIT__` may arrive late. `app/bridge.js` catches it whenever it lands.
- `house` is the saved layout, `users/{uid}/crib/house6`
- `intro: true` (the start data, beside `screen`): play the game intro when the menu is up. The app asks once a launch,
  the first time the menu shows. The intro is the designer's `squad-intro.js` (`app/intro.js`, the same look; only its PERF-marked changes for the frame rate). It replaced
  the app's old splash screen on 2026-11-16, and `app/menu.js` hands it the menu's parts it runs on. Android back skips it.

**App → game** (`SquishApp.receive`):

| Message | What the game does |
|---|---|
| `state` | Updates `coins`, `gems`, `level`, `owned` and `hiddenKeys` live |
| `config` | Applies the admin's config (`config/game`) |
| `screen: 'house'` | Walks into the house the way MY HOUSE does (asleep: on wake) |
| `page {name, opts}` | Opens a menu page (asleep: on wake) |
| `sleep {on: true}` | The page sleeps: nothing it draws or computes runs (frames, timers, its clock, CSS / Web / SVG animations, clips, sounds). Send it once another screen of the app has fully covered the menu. See "Performance, 2026-11-20" |
| `sleep {on: false}` | The page wakes and carries on exactly where it was. Send it just before the menu is uncovered |

**Game → app** (`ReactNativeWebView.postMessage`):

| Message | What the app does |
|---|---|
| `ready` | Starts sending queued messages |
| `coins {coins, delta}` | Writes the delta to `users/{uid}.coins` (catalog buys) |
| `house {data}` | Saves the layout |
| `open {what: 'shop' or 'settings'}` | Opens the shop or settings |
| `play {mode, key, from}` | `mode` 'squish': Squish Time with that creature; 'squishdoku', 'sort', 'stack', 'hop': that game. `from: 'park'`: the app opens the menu in the Game Park again afterwards (start `screen: 'park'`) |
| `claim {lv, all}` | The Level Pass: claim one level's prize (or all waiting). The app answers `claimed {ok, error}` or `claimed {road: true}` (a chest: it opened the level road) |
| `select {key}` | The creature picked on the Menu (CREATURES) becomes the selected squishy (`lobby.sel`) |
| `intro {phase}` | `'start'`: the game intro is playing. `'done'`: it's over (finished, skipped, or it couldn't play). The daily spin, the streak and the level-up card wait until then |
| `backUnhandled` | Android back on the bare menu: leave the app |
| `error` | Logged |

## Tests (Chromium, the way the phone runs it: file://, offline)

```
npm run webgame:test      # smoke (no errors, no missing files, no internet) + bridge (the link and every Firebase switch)
npm run webgame:pixels    # pixel-perfect check (NODE_USE_ENV_PROXY=1 behind a proxy: the reference loads Google Fonts)
```

`webgame/test/pixel-diff.mjs` compares the design prototype as the designer runs it against the app's build, frozen
at the same moment. Results on Nov 13:

| Screen | Differing pixels |
|---|---|
| Main Menu, phone size (924×412) | 0 |
| Main Menu, design size (852×393) | 3 of 334,836 |
| Main Menu, the prototype's test page | 3 of 1,024,000 |
| House, design size (852×393) | 147 of 334,836 |
| House, the prototype's test page | about 6,000 of 1,024,000 |

Every differing pixel is on a moving creature (a breathing or walking frame apart). The room, walls, furniture, text
and buttons are identical. Two loads of the prototype itself sometimes differ the same way.

## Performance, 2026-11-20

The user: "performance is very poor, the loading screens — I only hear the audio and when I see them they are half way
done; screens with 3-5 fps; lots of flickering; in the crib (the house) at the lower part there's something white".
Everything changed is marked `PERF 2026-11-20` in the code.

**Loaders and page openings** (`app/menu.js`, `app/games.js`):

- A loader or page is put up on its own in the tap's frame (a few dozen elements), and nothing heavy happens before
  its first frame is on screen (`SquishPerf.painted`). The page is then built under the loader in slices of a few ms a
  frame (`SquishPerf.slices`), so frames keep coming.
- Everything a loader moves is a Web Animation of transform / opacity, which the GPU plays from the loader's first
  frame on screen, even while the page is being built under it. Its sounds are set on the sound clock from that first
  frame (`sfxDelay`: the yard games' synth, with its start time moved), so they land with what's on screen. Before,
  the loaders ran on timers from the tap while the whole page was built in that same frame: they were half played
  when first seen, and their sounds came in a burst.
  - **Gathering your squad** (Characters): the deal, the flips, the deck, the leave and the fade are Web Animations
    with the design's timings and curves. The page (stage, row group by group, creature, scroll) is built under it.
  - **Heading home**: the house starts loading only once it is on screen (`HH.shown()`, awaited by goHome). The night,
    stars, moon and title fade in as Web Animations; each lit window is three small GPU layers (the window by day: a
    picture of the house with its door open, cut to the window; the warm pane in soft-light; the halo in screen),
    faded in along the same curves as before when the loading reaches it. The camera's flight in through the door
    and back out is a Web Animation too (`SquishMenu.zoom`, the same curve and veil), so the house starting up or
    being torn down can't freeze it.
  - **Level Pass**: the header and frame come first, the track and the rewards right after that first frame (as its
    fade-in starts); the reward pictures decode off the frame.
  - **Yard Games**: the cards come first, the seven posters one per slice after the first frame.
  - **Game Park** (PLAY): the park's big picture is drawn right after the tap's frame, while the creature turns (the
    camera reaches the park only after the turn), not in the tap itself.
- The menu's creature stops at once when a page opens over it (`SquishMenu.hold`).

**The menu under pages and the house** (`app/menu.js` `cover`): once a page has faded in, or the house is up (the
door's veil white), the menu isn't drawn at all (`content-visibility: hidden` on its scene, HUD, weather and veil:
cheap to hide and show again, no restyle). Chrome used to re-sort the menu's thousands of shapes into GPU layers
("layerize") every frame under the house: on the bench that was 44% of the house's frame time (1745 ms of 4000 ->
372 ms). It is drawn again in the same frame the page closes or the trip back starts.

**The scene as a picture** (`app/menu.js` `picture`): the live scene SVG is drawn as an `<img>` of itself (one
shape instead of thousands) where that buys frames: on a slow phone (the frame-rate guard at step 2 or 3; there also
while a page fades in over the menu), and under Heading home. It is not bit-for-bit the live SVG (edges smoothed a hair
differently: 1.75/255 on average, nothing moves), and each picture is a whole SVG document in memory, so a phone that
keeps up and the pixel test keep the live SVG, and the pictures are only made once they're needed. The live SVG stays
underneath (in `.sq-live`, hidden by `content-visibility`) for the door's opening and the game intro.
`SquishMenu.picture = 'on' | 'off' | 'auto'` forces it.

**The house fills the screen** (`patches.mjs`, `SquishMenu.houseBox`): the house's box is the screen at the scale
that fits 852 x 393 in it (852 wide and taller on a taller screen, 393 tall and wider on a wider one), not 852 x 393
scaled to the width (that left the cream strip). The room, the catalog and the map stay 852 x 393 in its middle (the
room's picture already reaches further: more floor and ceiling show), the HUD keeps to the edges, a tap in the room is
mapped through the offset (`toLocal`), the map's sea gradient carries on round the map. Checked at 796x384, 852x393
(unchanged), 640x360 and 900x400: room, map, catalog, Renovate.

**Leaving the house**: the unmounted house is let go (`window.__sh` held it for the session). The frame-rate guard
keeps a step per place (`SquishPerf.scope('house' | 'menu')`): the house used to step the creatures down for the rest
of the session, so the menu after a visit drew its creature every 2nd or 3rd frame (the user's 33-50 fps after the
house). It isn't judged while a page or the house loads (`SquishPerf.quiet`) or for 2.5 s after a wake.

**Smaller things**: the turning rays (Gathering your squad, Characters, the Game Park) are cut to the circle their mask
shows (same pixels, 23-37% less GPU memory for a layer redrawn as it turns); the crest's flourish restarts over two
frames instead of forcing a layout (a hitch every 5 s); `build.mjs` empties an output folder another program holds
open instead of failing.

**Sleep / wake** (`app/perf.js` `SquishSleep`, `app/bridge.js`): `SquishApp.receive({ type: 'sleep', on: true })` and
`{ type: 'sleep', on: false }`. perf.js loads before every other script and stands in for the browser's clocks, so the
design's own engines sleep without knowing:

- the page's clock (`performance.now()` and every `requestAnimationFrame` time) stands still while asleep: on wake
  every tween, rig and loop carries on from where it was (no jump to the end, no big first step)
- `requestAnimationFrame` callbacks wait and run in the first frame back
- `setTimeout`: a timer keeps the time it had left and fires that long after wake; `setInterval`s stop and restart
- CSS animations: paused by one rule (`html.sq-sleep`); Web Animations and CSS transitions: `pause()` / `play()`; SVG
  animations: `pauseAnimations()`; `<video>` / `<audio>`: `pause()` / `play()`; WebAudio: `suspend()` / `resume()`.
  Anything started while asleep starts paused and plays on wake.
- `state` and `config` are applied at once; `screen` and `page` wait for wake, so their walk or page opening plays
  where it can be seen.
- What must run while asleep uses `SquishSleep.native` (the real timers): the house's save to the app and the app's
  answers (`bridge.js`).
- Never asleep unless the app says so: with no `sleep` messages nothing changes.

On the bench asleep costs 0-1 ms of main thread a second and draws no frames (menu, park and house), the clock stands
still, a 2 s timer with 1 s left fires 1 s after wake, the first frame back is the next frame
(`tools/perf/sleep-bench.mjs`; `webgame/test/bridge.mjs` checks it too).

**Benches** (`tools/perf/`, all Chromium + SwiftShader, CPU x4, 796 x 384 at DPR 2.8125; `GAME=<build dir>`,
`VIEW=<w>x<h>`):

- `open-bench.mjs chars level park house back`: each page from the tap: the first composited frame that changed, the
  loader's state when first seen, frame rates and long frames, a contact sheet of the frames; `back`: the menu before
  and after a visit to the house (`TALLY=1`: who keeps scheduling frames and timers)
- `trace-open.mjs <scene> [secs]`: where the main thread goes (`TIMELINE=<ms>`, `TREE=1`)
- `profile.mjs <scene>`: JavaScript time by function
- `layers.mjs <scene ...>`: GPU layers and their tile memory
- `sleep-bench.mjs <menu|park|house>`: the sleep / wake checks above

## Not done yet

- iOS: the WebView source is Android-only (no `ios/` folder yet).
- The other new screens: Shop v5, Chest Smash v2, Squad Select, Intro, the cards. SHOP opens the app's current Shop.
- The 33 new creatures' art for the app's own screens (render + publish, above).
- The house fills its rooms up to 4 creatures from the design's default list when you own fewer, exactly like the
  prototype.
- Yard games give "+N coins (preview)" in the design but don't pay out. That isn't wired to the app's coins.
- The game screen is reloaded each time it's opened (about 2 s for the menu). The house has to load its own engines
  on top of that, which takes longer the first time.

### On the phone, later the same day (Galaxy A16, release builds)

- **Creatures take turns** (`patches.mjs` rive-rig loop, `app/perf.js` `rigStride` / `rigCost`): at the guard's step N
  each creature is drawn every Nth frame, 1/N of them a frame (it was all of them every Nth frame, so those frames
  took ~25 ms and missed the vsync). The house starts at step 2 and goes back to step 1 if drawing all its creatures
  stays under 7 ms a frame for 3 s. House: 33-35 fps → 59.5.
- **The turning rays** of Characters and its loader are drawn once into a `<canvas>` the GPU turns (`raysCanvas`):
  the CSS conic gradient under a radial mask took the WebView's GPU thread 1-2 s of tiles on a first open.
- **Loaders start once frames flow** (`SquishPerf.steady(fn)`): Gathering your squad deals, and the Level Pass shows its
  filled track, only once three frames in a row have reached the screen in time; the first open of a page makes the
  GPU thread build its tiles for up to ~0.5 s, and the deal used to play on unseen. Characters and the Level Pass
  don't fade in (a fade frozen part-way was a see-through ghost of the page over the menu).
- **Frozen house** (`SquishPerf.freeze`, set by `app/menu.js` from `window.__sh.state`): while the Catalog book, the
  map or the level-up card covers the room, the house's tick and the creature loop stop. Neither asks for frames
  while frozen (a cheap timer checks back): on Android every frame a WebView asks for makes the phone composite the
  whole page again, ~75 ms under the open Catalog. The rig engine's own watchdog interval calls the loop directly,
  so the loop checks the freeze before anything else.
- **The weather stops when the menu is covered** (`weatherOn` in `cover`): its moving layers are Web Animations, which
  CSS can't pause, and running unseen under the house they kept the WebView drawing every frame.
- **Still pictures** (`window.SquishStill(src)` in `app/perf.js`): SMIL `<animate>` / `<animateTransform>` / `<set>` …
  inside an SVG picture (a CSS data-URI background or an `<image href>`) makes Chrome re-raster it on every frame. That was
  the open Catalog drawing at 13-20 fps with nothing moving. `SquishStill` strips the SMIL from those pictures (the
  `img()` builder, the catalog cards and the item sheet, the room items' `src` / `srcF`; cached). The house map's own SVG
  pauses its animations (`pauseAnimations`) while the map is open, so its rain and waves hold still there (they were
  redrawn at 4.5 fps). Catalog, map, Kitchen and the empty rooms now draw nothing while nothing moves.
- **The house's back orb steps aside over the open Catalog** (`.mm-hback` hidden while `[data-screen-label="Catalog"]`
  is in the house, as on the map): it covered the Catalog's first tab ("Walls"); the Catalog has its own close.
- **The step-up is on trial** (`trialUntil`): for its first 6 s at step 1, a single second under 58 fps steps the house back
  to taking turns. The creatures' script time (`rigCost`) doesn't show what the GPU pays to redraw them all every frame,
  and the usual "under 55 fps for 2 s" let the Living Room sit at 50-58.
- **No filter on the rooms' creatures** (patches.mjs): their faint drop shadow + saturate + contrast filter made the GPU
  draw and filter every creature offscreen on every frame. Living Room: ~15 → ~10 ms of WebView drawing a frame, 60 fps
  even hot. In the house, step 1 is on probation for the whole visit (one second under 58 fps: back to step 2).
- **Map → room** (patches.mjs + `window.SquishVeil` in app/menu.js): no 2.6x zoom (a full re-raster of the map at 2.6x
  before its first step), no hover glow / label growth on touch screens (`hv` false under `(hover: none)`: each re-rastered
  map tiles, and every map tile replays the whole map with its blurs), the map's cream veil a layer from the start
  (`will-change:opacity`), and the new room drawn under a 99% cream veil that fades out once frames flow (an opaque
  layer would hide the room from the rasteriser). Was: map frozen ~0.9 s, then a blank page, then the room popping in.
- Measuring the WebView's GPU side: a Chrome trace of the page (browser target, categories cc/gpu/viz/toplevel) gives
  the in-process GPU thread's `Scheduler::RunTask` (busy share) and `RasterDecoderImpl::DoEndRasterCHROMIUM` (raster);
  the app's RenderThread waits on it inside `DrawFn_DrawGL`. Experiments: inject CSS / set state over CDP and compare.
- **Characters' first open** (menu.js, M.characters): a group's cards are drawn only while on screen (`.gc` gets
  `content-visibility:auto` with its measured size as it goes in; `.gc` has 18 px padding and -18 px margin so the
  selected card's glow and the IN USE tag fit inside what content-visibility clips); the spotlight creature is hidden
  while the loader covers it (`.sq-chars:has(.sq-gs:not(.out)) .sq-c2 .rig`, the loader adds `out` as it leaves); the
  menu is `sq-covered` from the page's first frame (also the Level Pass); the row's and the deal's cards use small copies
  of their pictures (`smallPic`: app/sm/cards4/…, ../looks-sm/…, made by webgame/tools/small-cards.py, with an
  `onerror` back to the original). Was: the whole 10,800 px row, the unseen spotlight creature every frame and ~90 full-size
  pictures rastered/decoded the first time (the loader still for ~1-1.5 s). Not yet measured on the phone.
- Still open: the cream hold between rooms is the room's raster time (~1-2 s).
