# Squish Soundboard (prototype)

A music toy on the Dance Room's DJ Console, asked for on 2026-11-05. The user wanted a game like Cartoon Network's *Cartoon Soundboard*: characters on a stage, and a mixer with Voice, FX and Music tracks. It unlocks once the player has bought a DJ Console and put it in the Dance Room.

The look is the **Squad House v6** design (the "ASMR Creature Squash Game" design project). It uses:
- the design's Dance Club room
- its most expensive club items
- its DJ crew and club fog
- its UI: the wood drawer, tabs, catalog book, cards, buttons and toast

Nothing on the page is new art. The one exception is the drawer's turntable icon, drawn in the house's icon style.

## Open it
`index.html` loads its sounds from the repo's `/assets`, so it has to stay in this repo. The sounds are decoded with Web Audio, which browsers don't allow from a `file://` page, so do one of these:
- serve the repo root (`npx serve .`) and open `/prototypes/soundboard/`
- make the one-file copy: `node prototypes/soundboard/tools/bundle.mjs <out.html>`

The page is the house's 852 × 393 landscape frame, scaled to fit. Phones in portrait get a "Turn your phone sideways" note.

## The Dance Room (the unlock)
- **The room:** the house's Dance Club. It has the most expensive walls, floor and ceiling (CLB-081, CLB-085, CLB-089), and the most expensive club pieces are already in it:
  - CLB-082 bass reactors
  - CLB-086 hologram dancer
  - CLB-090 bubble-mist tower
  - CLB-098 holo synth
- **Locked:** with no DJ Console, the spot in the middle of the floor shows a **DJ CONSOLE · Goes here** note with a **LOCKED** stamp. The drawer's Soundboard button has a lock.
- **The catalog:** the house's catalog book, open at Dance Room · DJ Console. Its five tiers:

  | Tier | Item | Level | Coins | Songs |
  |---|---|---|---|---|
  | 1 | CLB-015 folding table | Lv 5 | 125 | 2 |
  | 2 | CLB-035 plywood booth | Lv 11 | 505 | 3 |
  | 3 | CLB-055 aluminum truss booth | Lv 17 | 2,070 | 4 |
  | 4 | CLB-075 obsidian altar | Lv 23 | 7,820 | 5 |
  | 5 | CLB-095 Levitating Cyber-Stage | Lv 29 | 40,250 | 6 |

- **Unlocking:** **Buy** places the console in the room. Mittens, the player's character, steps behind it as the DJ. The first console shows a **Soundboard unlocked!** card with **Play**. Any DJ Console unlocks it. A better one brings more songs.
- **Opening it:** tap the gold **♪ Soundboard** tag, the console, or the drawer's Soundboard button.
- **Prototype only:**
  - The player is level 30 with 60,000 test coins: enough for every console.
  - **PLACE** puts back a console you already own.
  - Owned consoles, coins and the placed console are saved in this browser.

## The soundboard
- **The stage:** the Dance Club, zoomed in on the floor.
  - **The DJ:** Mittens, as the design's **DJ crew** (`art/dj-crew.js`), behind the placed console. It has headset and shades, one paw pumping and one on the ear cup. Its groove follows the song's tempo and stays in step every bar. It stops when the music stops.
  - **On the dance floor:** Bubbly, Frybo, Jelli and Twinkle, two each side of the booth, each under its own coloured spotlight.
  - **The crowd:** the other 14 creatures, at the back of the floor. They sway, jump on the beat, and squish when tapped.
  - **The club pieces:** the bass reactors flank the booth, and the hologram dancer and the mist tower stand at the sides.
  - **The light:** four moving ceiling beams in the DJ crew's ring-light colours, colour pools on the floor, and the DANCE sign pulsing on the beat.
  - **The fog:** while the music plays, the mist tower puts out the design's club fog (`art/club-fx.js`, mist style).
- **The voices:** each voice is a 0.42 s slice of that creature's own squish recording (`assets/audio/creatures/<id>.ogg`). There are five: the DJ and the four on the floor. Tap any of them on stage to hear them.
- **The mixer:** the house's wood drawer. It has three lanes over **16 beats** (4 bars):
  - **VOICE:** the five voices.
  - **FX:** pop, bubble, squeak, boing, coin, sparkle, bonk and whoosh, from `assets/audio`. Each has its own stage effect:

    | FX | On stage |
    |---|---|
    | pop | candy dots |
    | bubble | bubbles drifting from the mist tower |
    | squeak | a wiggle |
    | boing | everyone jumps |
    | coin | gold sparks over the booth |
    | sparkle | sparkles |
    | bonk | a shake |
    | whoosh | a light sweep and a fog puff from the bass reactors |

  - **MUSIC:** one cell per bar, ♪ Music or Break.
- **Editing:**
  - The lane tabs (Voice, FX, Music) switch the row of choices above the lanes.
  - Pick a voice, a sound or Erase, then tap beats. Drag across beats to fill them, and tap a beat again to clear it.
  - The chosen voice gets a gold ring on stage.
- **Songs:** the Crib's club tracks (`src/crib/home.js` SONGS), each exactly 8 bars. The tempo comes from each track's length (32 beats). The 16-beat pattern plays twice per loop. Songs the console doesn't bring show the level of the console that does.
- **Controls:**
  - **Play / Stop:** everything is scheduled ahead on the audio clock, so voices and effects land on the beat. Space works too.
  - **Record:** while playing, a tap on a voice on stage is written onto the nearest beat.
  - **Mix it!** makes a fresh groove. **Clear** empties the mix.
  - **Save** keeps the mix in this browser (`squishSoundboard.v2`). It opens with a demo mix.

## Moving it into the app
1. **The unlock:** a DJ Console placed in the Dance Room opens the soundboard. In today's app Crib that's `tierOf(home, 'dj')` (`src/crib/home.js`). Once the Crib moves to the Squad House v6 rooms, it's the CLB DJ Console slot. Taking the console out locks it again.
2. **The way in:** the gold tag over the console in the Dance Room. Tapping the console opens it too. When it's locked, the button takes the player to the catalog's DJ Console page.
3. **A new screen:** `src/screens/SoundboardScreen.js`, with the scheduler, mixer and stage split under `src/soundboard/`.
   - **The DJ:** the player's own creature, drawn the DJ crew way. The design has DJ fits for Mittens, Mochi, Boba, Pip, Kiwi, Floof, Gumdrop and Mallow, and a generic fit for the rest.
   - **The rest of the stage:** the four dancers and the crowd come from the squad.
4. **Sound timing:** expo-av has no audio-clock scheduling. Its sounds would be fired from a short JS timer (a little looser than this page), or a Web Audio-style native library would be used.
5. **Saving:** mixes saved with the Crib state (`users/{uid}/crib/state`).

## Files
| File | What it is |
|---|---|
| `index.html` | The page: the Dance Room with the DJ Console unlock, and the soundboard. |
| `art/dance-club.webp` | The design's Dance Club room with the CLB-081/085/089 walls, floor and ceiling and no items. It was rendered from the Squad House v6 page in a headless browser. |
| `art/items/CLB-*.svg`, `art/items.js` | The DJ Consoles and club pieces as the design's `RenoDraw.draw` draws them, cropped to their art. Each item's floor point is (0, 0) in its viewBox. `items.js` has their catalogue facts: name, tier, level, coins, viewBox, float, holo. |
| `art/export/tripo/<key>/<key>-front.svg` | The design's creature front pictures, unchanged. These are the 20 squad creatures with squish recordings. |
| `art/dj-crew.js`, `art/club-fx.js` | The design's DJ crew and club fog code, unchanged. |
| `voices.js` | Where each creature's voice starts in its squish recording, and how loud it peaks. Written by `tools/voices.py` (numpy and ffmpeg). Don't edit by hand. |
| `tools/voices.py` | `python3 prototypes/soundboard/tools/voices.py` |
| `tools/bundle.mjs` | The one-file copy (about 4.5 MB): `node prototypes/soundboard/tools/bundle.mjs <out.html>`. `--artifact` drops the html/head/body wrapper for a claude.ai Artifact. |

The `art/` files came from the design project's own files. The room and the items were exported by running the Squad House v6 page and its `RenoDraw` in a headless browser. To refresh them after the design changes, export them the same way.
