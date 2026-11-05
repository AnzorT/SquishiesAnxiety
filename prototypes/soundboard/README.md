# Squish Soundboard (prototype)

A music toy on the Crib's DJ booth, asked for on 2026-11-05. The user wanted a game like Cartoon Network's *Cartoon Soundboard*: characters on a stage, and a mixer with Voice, FX and Music tracks. It unlocks once the player has bought and put on a DJ booth in the Crib.

## Open it
`index.html` loads the real art and sounds from `/assets`, so it has to stay in this repo. Its sounds are decoded with Web Audio, which browsers don't allow from a `file://` page, so do one of these:
- serve the repo root (`npx serve .`) and open `/prototypes/soundboard/`
- make the one-file copy: `node tools/bundle.mjs <out.html>`

## The unlock (the Crib's Dance Room)
- **What unlocks it:** the soundboard opens when the equipped DJ Booth tier is the **DJ Deck** or better (`UNLOCK_TIER = 2`). That's the first tier that's a real booth (level 3, 300 coins).
- **The tiers below:** the free Boombox Crate and the Laptop Desk show a tag over the booth: **LOCKED · DJ DECK**. Tapping it opens a card that names the booth, its level and its price.
- **Unlocking:** putting the DJ Deck on gives the Crib's toast, "Soundboard unlocked!", with PLAY. The booth then wears a pulsing **♪ SOUNDBOARD** sticker. Tapping the sticker or the booth opens the soundboard through the Crib's room-switch flash.
- **Better booths bring more songs:** the soundboard's Music list is the DJ's own songs, `songs(home)` in `src/crib/home.js`. That's 2 with the DJ Deck, 3 with the Pro Mixer, 4 with the LED Booth and 6 with the Mega Stage. Songs not yet unlocked show a lock and the booth that brings them.
- **Prototype only:** the panel at the bottom stands in for the Home Shop. Tap a booth to put it on. In the app, buying a tier puts it on (`buy()` in home.js), and Edit mode swaps tiers.

## The soundboard
- **Stage:** the Dance Room with the equipped booth's own picture, the Crib's light-up dance floor (`src/crib/Dance.js` colours, stepping on every beat), and five squishies. Tap a squishy and it sings its voice.
- **The mixer** has three tracks over **16 beats** (4 bars), drawn as two rows of 8:
  - **VOICE:** each squishy's voice is a 0.42 s slice of its own squish recording (`assets/audio/creatures/<id>.ogg`, the loop the squish stage plays). `tools/voices.py` finds each recording's cleanest strong squish. The levels are evened out.
  - **FX:** pop, bubble, squeak, boing, coin, sparkle, bonk and whoosh, all from `assets/audio`. Each has its own stage effect: candy dots, rising bubbles, a wiggle, everyone jumping, gold sparks, sparkles, a shake, a light sweep.
  - **MUSIC:** one cell per bar, MUSIC or BREAK, for drops.
- **Editing:** pick a squishy (VOICES), a sound (FX) or Erase, then tap beats. Drag across beats to fill them. Tapping the same thing again clears it.
- **Songs:** the songs are the Crib's club tracks, each exactly 8 bars. The tempo comes from the track's length (32 beats), from 100 to 140 BPM. A 16-beat pattern plays twice per loop.
- **PLAY / STOP:** everything is scheduled ahead on the audio clock, so voices and effects land on the beat. Squishies bop on each music beat and squash when they sing.
- **REC:** while playing, tapping a squishy writes its voice on the nearest beat.
- **MIX IT!:** makes a fresh groove.
- **CLEAR** empties the mix.
- **SAVE** keeps the mix and the chosen booth (localStorage, `squishSoundboard.v1`). It opens with a demo mix.

The look is the Crib's:
- **Top bar:** the Crib's top bar.
- **Mixer:** the Dance Room's song-pill plum.
- **Buttons:** the Crib's sticker buttons and plain buttons.
- **Toast:** the Crib's toast.
- **Locked card:** the card all the mini-games share.

Nothing is new art. The booths' pictures, prices and songs come from the catalogue through `tools/djart.mjs`.

## Moving it into the app
1. **The unlock:** `tierOf(home, 'dj') >= 2` (`src/crib/home.js`). It's live: putting a lower tier back on in Edit mode locks it again.
2. **The way in:** in `CribScreen`'s dance room, a sticker over the booth. Tapping the booth itself opens it too. When locked, the card's button can open the Home Shop on the DJ Booth.
3. **A new screen:** `src/screens/SoundboardScreen.js`, with the scheduler, mixer and stage split under `src/soundboard/`.
   - The stage lineup: the player's own creatures that have their own squish recording (squad ids 0–19). The others would use the generic slime loop.
   - The voice slice starts: `voices.js`.
4. **Sound timing:** expo-av has no audio-clock scheduling. Its sounds would be fired from a short JS timer (a little looser than this page), or a Web Audio-style native library would be used.
5. **Saving:** mixes saved with the Crib state (`users/{uid}/crib/state`), next to the song the booth is on.

## Files
| File | What it is |
|---|---|
| `index.html` | The page: the Crib's Dance Room with the DJ booth, and the soundboard. |
| `djart.js` | The DJ Booth's tiers (name, level, price, songs, picture and where it stands) and the songs, from `src/crib`. Written by `tools/djart.mjs`. Don't edit by hand. |
| `voices.js` | Where each creature's voice starts in its squish recording, and how loud it peaks. Written by `tools/voices.py` (numpy and ffmpeg). Don't edit by hand. |
| `tools/djart.mjs` | `node prototypes/soundboard/tools/djart.mjs` |
| `tools/voices.py` | `python3 prototypes/soundboard/tools/voices.py` |
| `tools/bundle.mjs` | The one-file copy (about 3 MB): `node prototypes/soundboard/tools/bundle.mjs <out.html>`. `--artifact` drops the html/head/body wrapper for a claude.ai Artifact. |
