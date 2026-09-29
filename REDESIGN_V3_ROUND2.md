# Redesign v3 — round 2: review fixes

Date: **2026-09-28**. After Phase 1 (the candy restyle, see `REDESIGN_V3.md`), the screens were reviewed against the design file `ASMR Creature Squash v3.dc.html` and a list of fixes came back. This document covers what was changed for each item, where the code is, how it was checked, and what is still open.

Everything below was checked on the Pixel_9 emulator, side by side with the design rendered in headless Chrome. Nothing is committed yet.

## At a glance

| # | Request | What was done |
|---|---|---|
| **Login** | | |
| 1 | Going to REGISTER should just add a field with a nice animation, like the design, not shrink and move the widgets | REGISTER grows one row above Email and folds it away on LOGIN (the design's `authFieldIn` / `authFieldOut`). Email, Password and the button are not re-animated or resized. |
| **Creatures list** | | |
| 1 | The new creature designs must be in Firebase, not in the app | The creatures are rendered to images and published to Firebase Storage. Each `creatures/{id}` doc gets a `plush` field and the app draws from it. **The upload still has to be run once** (see "Open items"). |
| 2 | Creatures must be exactly like the design | The images are rendered from the design's own HTML/CSS in Chrome, so they are pixel-exact. The app adds the design's own mood animations and sparkles. |
| 3 | The ad bar looks like a button; make it full width, stuck to the bottom | Full-width strip flush with the bottom edge. It is outside the list animation. |
| 4 | Coin style differs from the design, and should be a bit bigger | Coin rebuilt from the design's CSS (ring, two-tone lip, white rim, gold face, highlight, small star), at 17px instead of 14px. |
| 5 | Rarity pill looks different | Sizes, ring and rim match the design. Its white rim is now a separate layer. |
| 6 | "★ OWNED" is missing its background | The design outlines this text with three shadows; React Native only drew one. Now drawn with all three. |
| 7 | List switch: going left, the old list exits right and the new one enters from the left, and vice versa; the ad bar stays | Done exactly that way. The header, tabs and ad bar don't move. |
| 8 | Switching lists takes 1–2 s | Switching is instant. Both lists stay built, and a placeholder card with a sweeping flash shows if one isn't ready yet. |
| 9 | Up/down arrows take about 1 s | The next card is always pre-built, so a press responds in 8–30 ms. |
| 10 | Swiping by hand "resets" the card and the creature animation | A swipe now hands over to the same card that was peeking in, so nothing restarts. |
| 11 | No shine sweep on creatures in the design; remove it | Removed. |
| **Key Shop** | | |
| 1 | The creature should be inside the round hole of the key; keep the new key's color | New key: the gold key's round bow holds the creature. |
| 2 | BUY / OWNED padding like the design | 8×14 padding, min-width 86, 13px caption, 3px white rim, 2.5px ring, 4px lip. |
| **Achievements** | | |
| 1 | Behavior and style don't match the design | Carousel rebuilt on the design's numbers (positions, sizes, fades, glow, dimming, overshoot). |
| 2 | The text block should be lower | Pinned to the bottom of the screen, as in the design. |
| 3 | The design has 50 achievements | All 50, in the design's order and wording. |
| **General** | | |
| — | The button gloss has a gap under the top, like a hole | Two causes were fixed: the gloss came out too thin on padded buttons, and there was a strip of button color above it. It is now full height and flush under the white rim. |

## Creature art: from the design to Firebase

### Why images

The design builds each creature out of CSS: rounded shapes, gradients, soft inner shadows, and a white "sticker" outline made with drop-shadow filters. The app's drawing library (react-native-svg 15.2) has no blur or filter support. A redrawn version could only approximate those shadows, so the creatures would never be exactly like the design.

Instead, Chrome renders the design's own markup once, and the result is published as images. The app shows the image and adds only what moves.

### How it works

1. **Render.** `tools/plush-art/render.mjs` takes the creature markup from `Creature Plush.dc.html` and renders all 20 creatures in headless Chrome as WebP images with transparent backgrounds. It trims the empty space and records where each image sits.
2. **Sizes.** The design's shadows are fixed pixel sizes, so a small creature looks different from a big one. There are five variants per creature, each rendered at the size the design uses it:

   | Variant | Rendered at | Used for |
   |---|---|---|
   | `lg`, `lgLocked` | 160px | Home card, Loading screen |
   | `md`, `mdLocked` | 84px | Achievements badges, Splash |
   | `sm` | 30px | Key Shop |

   All 100 images come to about 5 MB.
3. **Publish.** `tools/plush-art/publish.mjs` uploads the images to Firebase Storage under `creatureArt/plush-v1/{id}/` and writes this onto each `creatures/{id}` doc:

   ```
   plush: { v: 1, lg: { url, frame }, lgLocked, md, mdLocked, sm }
   ```

   `frame` says where the image sits relative to the creature's box, because shadows and accessories spill outside it.
4. **Display.** `src/components/CreatureThumbnail.js` picks the variant by size and lock state and plays the design's mood animations (creFloat, creJump, creWobble, creSleep, creReady, creCelebrate) with the same timings. It also adds the two twinkling sparkles. All images are pre-loaded when the catalog arrives, so paging never waits on the network.

If a creature has no `plush` yet, the app falls back to its older art in Firestore. That's why the creatures look like before until the upload runs. No creature art is bundled in the app.

### Faithful to the design, on purpose

- **Nubbin's horns, Spike's spikes and Ember's flame were missing** in the design too: its CSS sizes them with `%` border widths, which browsers ignore. Round 3 brought back Nubbin's and Spike's (see `REDESIGN_V3.md`); Ember's flame is still missing.
- **Glimmer's and Pearla's animated shine band was left out**, as requested.

## Home screen

- **New card pager** (`src/components/CardPager.js`):
  - Every card on screen or next to it stays built, keyed by page, and one animation value moves them all.
  - The motion follows the design: the incoming card slides 108% while growing from 0.94 and fading in from 0.5, and the outgoing card leaves the other way.
  - A finger drag moves the same cards and hands over to the same card on release.
- **List switching:**
  - Both lists sit side by side and slide as whole units (the design's `ghostList` + `listInLeft` / `listInRight`).
  - MY CREATURES is built quietly right after Home opens. If you switch before it's ready, a placeholder card (`SkeletonCard.js`) shows with a sweeping flash.
- **Layout.** The card is 84% wide and 88% tall with a 400px cap, like the design. The creature is `min(170, height − 34, 80% of width)`, on a pedestal 130% as wide.
- **Outlined text.** The design outlines text with several hard shadows (buttons, "★ OWNED", tab labels). React Native only supports one, so the new `src/components/candy/ShadowText.js` draws the extra copies.
- **Speed.** App.js no longer re-renders the whole app on every page change, and the cards only re-render when their own data changes.

## Key Shop

`src/components/candy/CreatureKey.js` is the design's gold key (brown outline, white inner line, gold gradient, 2px drop) with its round bow grown into a ring. The creature sits in the ring's window. It is clipped to the window so its soft glow doesn't wash out the gold.

## Achievements

- **The list** (`src/achievements.js`) has the design's 50 entries. All of them are worked out from the player's profile:
  - creatures owned, coins earned, squish presses, longest hold, and creatures played;
  - custom creatures made;
  - ads watched and the biggest boost (both new).
- **New profile fields:** `adsWatched` and `maxMult`, written by `recordAdWatched` when a reward ad finishes on the squish screen. They feed "Movie Night" (5 ads) and "Max Boost" (×4).
- **Mystery Box and Daily Spin achievements** stay locked at 0 for now. They will unlock once those features (Phase 2) save `boxOpens`, `tierPulls`, `secretFound`, `spins` and `wheelJackpot`.
- **The screen** (`src/screens/AchievementsScreen.js`) follows the design:
  - badge ring outside the badge;
  - a gold glow on the centre badge and slight dimming on the side ones;
  - movement with a small overshoot (0.5 s) and a separate fade (0.35 s);
  - opens on the first unfinished achievement;
  - text block at the bottom that rises in on each change.

## Login / Register

- REGISTER adds one row: **Nickname + Age**. The design only has Nickname, but the under-13 age gate had to stay.
- The age is checked on the phone before anything is sent to Firebase. Under 13 shows the "ask a parent or guardian" card.
- The button caption fades up when it changes (the design's `authTextIn`).
- The title stays "Welcome Back!" in both modes, as in the design.
- Like the design, the form is centred, so the column shifts by half the new row's height while it grows.

## Button gloss

Two problems caused the "hole":

1. **Too thin.** On buttons with padding, the gloss's 44% height was measured against the caption instead of the whole button face.
2. **The gap.** A strip of button color sat between the white rim and the gloss.

`Shine` in `src/components/candy/CandyButton.js` now draws in its own full-size layer, so its size is right on every button. It also starts flush under the rim. This fixes every candy button, pill, tab, round button, ad button and the bonus bar at once.

## Differences from the design (on purpose)

- **Ad bar:** full width at the bottom, not the design's inset box (requested).
- **Coin:** 17px, not 14px (requested).
- **Key Shop:** the creature is inside the key's bow, not in a separate ring next to a small key (requested).
- **Register:** has an Age box next to Nickname, to keep the age gate.
- **List switching:** keeps each list's position. The design jumps back to the first card.
- **Button gloss:** starts flush under the rim (requested). The design has a 3px gap.

## Files

**New**
- `src/components/CardPager.js` — Home's card lists
- `src/components/SkeletonCard.js` — placeholder card with a flash
- `src/components/candy/ShadowText.js` — text with several outline shadows
- `src/components/candy/CreatureKey.js` — the Key Shop key
- `tools/plush-art/render.mjs` — renders the creature images
- `tools/plush-art/publish.mjs` — uploads them and updates the catalog

**Rewritten**
- `src/components/CreatureThumbnail.js`
- `src/screens/HomeScreen.js`
- `src/screens/AchievementsScreen.js`
- `src/screens/AuthScreen.js`
- `src/achievements.js`
- `src/components/candy/Coin.js`

**Changed**
- `App.js`
- `src/components/CreatureCard.js`
- `src/components/CustomCards.js`
- `src/components/candy/CandyButton.js`
- `src/components/candy/CandyTabs.js`
- `src/components/candy/Decor.js`
- `src/components/candy/OutlinedTitle.js`
- `src/screens/StoreScreen.js`
- `src/screens/SquishScreen.js`
- `src/firebase/firestore.js`
- `.gitignore` (ignores the tool's design copy and render output)

**Removed**
- `src/components/PagedCard.js`

## How it was checked

- Each screen was screenshotted on the emulator next to the same screen of the design rendered in headless Chrome, and compared zoomed in.
- Animations (list switch, arrows, swipe hand-off, achievements, register row) were recorded with `adb screenrecord` and checked frame by frame.
- Press-to-response time was logged in the app: arrows respond in 8–30 ms. A tab switch spends about 80–100 ms of JS work in this dev build, but the slide itself runs on the native thread and starts immediately.
- The new creature art was previewed on the emulator from a temporary local server. That preview was removed so the app only reads art from Firebase.

## Open items

All closed as of 2026-09-29:

1. **Publish the creature art:** done by the user. To re-render and publish again:

   ```
   python -m zipfile -e "ASMR Creature Squash Game.zip" tools/plush-art/design
   node tools/plush-art/render.mjs
   ```

   then, in PowerShell:

   ```powershell
   $env:GOOGLE_APPLICATION_CREDENTIALS = "C:\path\to\your-service-account-key.json"
   node tools/plush-art/publish.mjs
   ```

   Add `--dry` to preview. Re-running is safe. Keep the service-account key outside the project folder: it gives full admin access (the repo's `.gitignore` now ignores `*-firebase-adminsdk-*.json`).
2. **Phase 2** (Mystery Box, Daily Spin, PAINT): done, see `REDESIGN_V3.md`.
3. **Phase 3** (music and sound effects, the new app icon): done, see `REDESIGN_V3.md`.
