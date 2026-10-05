# Redesign v3 — status

Status as of **2026-09-29**. This tracks porting the new design into the React Native app: what the design is, what was decided, what is done, and what is left.

## The design

The new design came in as `ASMR Creature Squash Game.zip` in the repo root. Inside it:

| File | What it is |
|---|---|
| `ASMR Creature Squash v3.dc.html` | **The new design.** Source of truth for everything below. |
| `ASMR Creature Squash v2.dc.html` | An in-between version. v3 includes all of it. |
| `Creature Plush.dc.html` | The new "plush" creature art. |
| `sfx.js` | All music and sound effects, generated in code (Web Audio). |
| `App Icon v2.dc.html` | The design's app icon. The app uses the user's own `app-icon-1024.png` instead (Phase 3). |
| `ASMR Creature Squash Game.html` | **Not the new design.** Identical to the old bundled page. |
| `Squish Squad Prototype.html` | An older prototype. Not the new design. |

What the redesign changes, in short:

- **Look:** a dark navy theme becomes a bright pink→violet stage with polka dots, bokeh and sparkles; glossy "candy" buttons; sticker-style titles; the Fredoka font; plush-style creatures.
- **New features:** Mystery Box with rarity tiers, 50 achievements in a carousel, a Daily Spin wheel, ×2/×3/×4 ad boosts, music and sound effects.

## Decisions made

- **Platform:** the redesign goes into the **React Native app**. The Unity port is dropped.
- **Coins:** **5 coins for every 1.5 s the finger spends moving** on the squish (since Round 6; before that it was every 1.5 s of holding, and 1 coin, not 5; the design had 2). Holding still earns nothing, like the squish sound. Nothing is earned on release.
- **The tap-spam easter egg stays.** The "🚨 WHOA THERE! You're tapping way too much. You will be punished." popup is not in the v3 design, but it must be kept. It trips at 5 quick taps in 1 s or 7 in 2 s, and ACCEPT PUNISHMENT plays a full-screen ad.
- **Creature art comes from Firebase, not the app.** The v3 plush creatures are rendered from the design's own HTML/CSS to images, hosted in Firebase Storage and listed on each `creatures/{id}` doc as `plush`. The app bundles no creature art (see "Creature art" below).
- **Unlocking (Round 5):** only Glorp is free. Coins buy Mystery Boxes, not creatures. Every creature has its own tokens (30 for Puffle, +5 per creature along the roster). A box gives 1–3 tokens (80/17/3%) of one locked creature, picked by rarity (50/28/13/6/2/1%); a full set puts its key on its card. The other way to a key is $0.99 in the Key Shop. All the box numbers are tunable in Firestore (`config/mysteryBox`).
- **Register keeps the age gate.** REGISTER adds one row (Nickname + Age) like the design's single Nickname field. The age is checked on the device before anything is sent to Firebase; under 13 shows the "ask a parent" card.

## Phase 1 — restyle every existing screen: DONE

Every screen was checked on the Pixel_9 emulator.

| Screen | What changed |
|---|---|
| Splash | Candy stage with sparkles, wobbling gold/pink "SQUISH SQUAD" sticker title, pulsing pink TAP TO START. |
| Auth | Pink "Welcome Back!" title, glass tab bar with a sliding pink pill, pale inputs, blue candy button. The under-13 age gate is kept. |
| Home | Round trophy/bag/gear buttons, glass coin pill, sliding tab bar, round arrow buttons, ad slot in a glass frame. |
| Creature card | Pink card, creature on a gold pedestal under spinning light rays, rarity chip (COMMON…GOLDEN), ★ OWNED + PLAY ▶, purple padlock when locked, pink padlock + sliding gold key + gold UNLOCKED! burst for hold-to-unlock. |
| My Creatures cards | Dashed "Create your own squishy" card, custom creature cards with candy PLAY / RETRY buttons. |
| Key Shop | Pink rows, creature in a gold-ringed key bow, BUY / KEY READY / ★ OWNED candy buttons. |
| Achievements | Grid replaced by the swipeable one-badge-at-a-time carousel with rays, halo, check/lock corners, and a progress bar per achievement. |
| Settings | Pale pink sheet of white cards, candy SAVE and LOG OUT. |
| Loading | Creature on the candy stage, "Getting Ready", then a wobbling "✦ I AM READY! ✦". |
| Squish | Candy stage, round back/gear buttons, gold ×2/×3/×4 ad buttons (now in that order), gold bonus bar, "×N COINS!" flash, spinning coin "+1" pops, pink touch ripples. |
| WHOA THERE! popup | Restyled to candy: pops in, shaking 🚨, red sticker title, pink ACCEPT PUNISHMENT button. Behaviour unchanged. |
| Create | Candy stage, white inputs, pink segment toggle, candy CREATE button. |
| Toasts | White toast, gold→pink achievement banner (now below the status bar). |

### Where the code is

- `src/theme/candyTheme.js` — colours, fonts, button colours, rarity tiers.
- `src/components/candy/` — the shared pieces: `CandyBackground`, `CandyButton` (+ `CandyPill`), `RoundButton` (+ trophy/bag/gear/key icons), `Coin` (coin icon, glass pill, coin pill), `OutlinedTitle` (sticker titles), `CandyTabs`, `Decor` (rays, pedestal, card, progress bar, rarity chip), `Sparkles`.
- `src/components/CreatureThumbnail.js` — draws a creature from its Firestore `plush` images (or the older `svg`), with the mood animation.
- `src/components/CardPager.js`, `SkeletonCard.js` — Home's card lists.
- `src/components/candy/ShadowText.js` (multi-shadow outlined text), `CreatureKey.js` (key shop key).
- `tools/plush-art/` — render and publish the creature art.
- Deleted (no longer used): `src/theme/squadTheme.js`, `src/theme/tokens.js`, `src/components/squad/GradientButton.js`, `src/components/squad/IconButton.js`.
- New dependency: `@expo-google-fonts/fredoka`.

## Round 2 — review fixes: DONE (2026-09-28)

Full write-up, item by item: [REDESIGN_V3_ROUND2.md](REDESIGN_V3_ROUND2.md).

| Area | What changed |
|---|---|
| Creature art | Rendered 1:1 from `Creature Plush.dc.html` by `tools/plush-art/render.mjs`. `CreatureThumbnail` shows the image plus the design's own mood keyframes (creFloat, creJump…) and creTwinkle sparkles. The shine sweep is gone. |
| Home paging | New `CardPager`: cards are page-keyed and stay mounted, one native `pos` value moves them. Arrows react on the next frame (was ~1 s); a finger swipe hands over to the same card instance, so the creature no longer restarts. |
| Home tabs | Both lists stay mounted side by side. Switching slides the old list out and the new one in from the opposite side (design's ghostList + listInLeft/Right). MY CREATURES is built right after Home settles; if it isn't ready, a skeleton card with a sweeping flash shows instead of a delay. |
| Home layout | Card 84% × 88% (max 400) like the design. Ad bar is full width and flush with the bottom, outside the list animation. Coin rebuilt from the design's CSS (bigger, 17px). Rarity chip, name sticker and `★ OWNED` / button captions use the design's multi-shadow outlines (`ShadowText`). |
| Key Shop | `CreatureKey`: the gold key's round bow holds the creature. Buttons use the design's padding (8×14, min-width 86). |
| Achievements | All 50 from the design, in order (`src/achievements.js`). Carousel numbers, glow, dimming and the text block at the bottom follow the design; opens on the first unfinished one. Box/Spin ones stay locked until Phase 2 writes `boxOpens`, `tierPulls`, `secretFound`, `spins`, `wheelJackpot`. New profile fields: `adsWatched`, `maxMult` (written by `recordAdWatched`). |
| Auth | REGISTER grows one row (authFieldIn) and folds it away (authFieldOut); nothing else moves except the centred column's shift, as in the design. |
| Buttons | Gloss fixed: it was sized against the caption instead of the face (a thin floating strip) and now also starts flush under the white rim. |

## Round 3 — review fixes: DONE (2026-09-28)

| Area | What changed |
|---|---|
| Creature art | Four creatures changed from the design, in `tools/plush-art/fixes.mjs` (render.mjs applies it): **Cosmo** sits inside its ring (the far half passes behind the body, the near half in front, below the face; the gloss moved onto the body, where the shared one floated above it). **Puffington** has Mochi's eyes and its cheeks on the middle puff. **Spike** has its three spikes back and **Nubbin** its two horn-ears, drawn as soft plush cones shaded like the body. Nubbin also smiles and has the design's real eyes. Re-published by the user; the app shows the new art. |
| Squish ad | Same strip as Home: full width, 60px slot, flush with the bottom. Both screens now use `src/components/AdStrip.js`. |
| Achievements | The badge gloss starts flush under the white rim (it had the same 5% gap as the buttons did). |
| Loading | "Getting Ready" is a gold sticker title (the same style as "I AM READY!") and the dots are three hopping candy balls (pink, gold, blue) built like the candy buttons. |

## Round 4 — review fixes: DONE (2026-09-29)

| Area | What changed |
|---|---|
| Button gloss | The highlight now runs the full width of the face on every candy button, pill and tab (Mystery Box buttons, the LOGIN/REGISTER and list tab slider, PLAY, the ×2/×3/×4 ad buttons…); the design insets it 9% a side, which read as too narrow. Round buttons, coins and badges keep an inset. `Shine` in `src/components/candy/CandyButton.js`. |
| Box reveal name | The name was cut off at both ends when a longer name followed a shorter one (OPEN ANOTHER). `OutlinedTitle` measured its text inside its own current width; it now measures in an unconstrained box and adds a little slack. `src/components/candy/OutlinedTitle.js`. |

### Creature art

1. `python -m zipfile -e "ASMR Creature Squash Game.zip" tools/plush-art/design`
2. `node tools/plush-art/render.mjs` → `tools/plush-art/out/{id}/{lg,lgLocked,md,mdLocked,sm}.webp` + `manifest.json` (about 5 MB for all 20).
3. `GOOGLE_APPLICATION_CREDENTIALS=<service-account key> node tools/plush-art/publish.mjs` uploads them to Storage (`creatureArt/plush-v1/…`) and writes `plush` on each `creatures/{id}` (`--dry` to preview).

Until step 3 has run, the app falls back to each creature's older `svg`. Changes to individual creatures go in `tools/plush-art/fixes.mjs`, not in the extracted design, so re-extracting the zip keeps them.

Size classes exist because the design's shadows are fixed pixel sizes: `lg` (card, loading, 160px), `md` (achievements, splash, 84px), `sm` (key shop, 30px).

## Phase 2 — new features: DONE (2026-09-29)

Checked on the Pixel_9 emulator against the design (recordings, frame by frame).

| Feature | What it does | Where |
|---|---|---|
| **Mystery Box** | Home banner ("MYSTERY BOX · 20/20 · SECRET FOUND", price pill FREE / VIDEO / 500 / READY). Box screen as designed: odds chips, the gift with its halo and orbiting sparkles, 10 fast taps (each within 0.5 s, or the dots drain and "Too slow!"), per-tap shake, word, shock ring, chips and cracks, the burst and flash, then the reveal (rays, confetti, sparks, tier badge, name, NEW / DUPLICATE · +150 / SECRET note), SQUISH IT and OPEN ANOTHER. First box free, second a rewarded video, then 500 coins. Rainbow and Secret pulls shimmer, Golden glints. **Changed in Round 5:** boxes give creature tokens, the tap window is 0.4 s, and each day's first two boxes cost a video each (free with Remove Ads), then 500 coins. | `src/mysteryBox.js` (rules, odds), `src/screens/MysteryBoxScreen.js`, `src/components/box/`, `openBox` / `payBoxWithAd` in `src/firebase/firestore.js` |
| **Daily Spin** | Once a day, before Home (also on coming back to the app on a new day, from Home only). The server rolls the prize and hands it out: coins (60–300), **15% off the next custom creature** (0.1%) or a **free creature** (0.1%, then the "PICK A CREATURE" reel lands on it). "Thanks for spinning" ad break after. If the server can't be reached: "THE WHEEL IS RESTING". | `functions/dailySpin.js` + `spinWheel` in `functions/index.js`, `src/dailySpin.js`, `src/screens/DailySpinScreen.js`, `src/screens/CreatureReelScreen.js`, `src/firebase/callFunction.js` |
| **PAINT** | CREATE ONE now has PAINT and ASSEMBLE. PAINT is the design's pad: 8 colours, brush 4–48, ERASER, UNDO (12 steps), CLEAR. The painting is saved as a 1024 px JPEG and goes through the same photo → 3D path as an upload. | `src/components/PaintCanvas.js`, `src/screens/CreateScreen.js` |
| Achievements | The box and wheel ones now count: `boxOpens`, `tierPulls`, `secretFound` (box), `spins`, `wheelJackpot` (server). | `src/achievements.js` |
| Rules | The app can't write `spins`, `lastSpinDay`, `wheelJackpot` or `creationDiscountPct` (only `spinWheel` can). Checked in the emulator: 403 for the client, spins work through the function, one per day. | `firestore.rules` |

**Deployed by the user on 2026-09-29.** For reference, the deploy (until it has run, the wheel shows "THE WHEEL IS RESTING"):

```
firebase deploy --only functions:spinWheel,firestore:rules
```

`firestore:rules` replaces the live rules with this repo's `firestore.rules`. If the live rules were edited in the console, compare them first.

**Decisions made in Phase 2:**
- Wheel CREATE prize = 15% off the next custom creature (user's call), granted only by the server. It's stored as `creationDiscountPct`; the price label shows it, but there's no purchase flow yet, so whatever sells creations later must apply it and clear it.
- Daily Spin once per calendar day (user's call), not per login.
- Prism Glorp: for now the design's version (a rainbow Glorp reveal, the Secret Keeper badge, "SECRET FOUND"). How creatures unlock is being rethought (see "What is left").
- A box is paid for and opened in one write when it bursts, so nothing is charged if you leave mid-tap. The video box is saved the moment the video ends.

## Phase 3 — sound, music and app icon: DONE (2026-09-29)

**App icon.** The user's `app-icon-1024.png` (repo root, any square size) is the icon; `python tools/icon/makeIcons.py` rebuilds everything from it. `assets/icons/app_icon.png` is the art as a full square (its own rounded corners, and the faint shadow outside them, filled from the nearby background); `assets/icons/app_icon_foreground.png` and the `mipmap-*/ic_launcher_foreground.png` files are the Android adaptive-icon layer (that square sized to the 72 dp area launchers show, with a little bleed); `ic_launcher.png` keeps the art's own rounded shape for pre-adaptive launchers and `ic_launcher_round.png` is a circle crop. The script prints the background colour, which goes in `iconBackground` (`colors.xml`) and `app.json`'s `adaptiveIcon.backgroundColor` (now `#A68FEB`). The `android/` folder was already generated, so its files are written directly; `app.json` points at the same files for the next prebuild.

**Sound and music.** Everything comes from the design's own `sfx.js`:

| | What | Where |
|---|---|---|
| Render | `node tools/audio/render.mjs` runs `sfx.js` in headless Chrome with an OfflineAudioContext (sample-exact). Music is one full 24-bar cycle per mood with the tail folded onto the start, so it loops without a seam. | `tools/audio/render.mjs` |
| Encode | `python tools/audio/encode.py` (needs `pip install --user soundfile numpy`): effects levelled as one group (loudest at 0.92, about the app's old coin/pop level), short ones as WAV, long ones Ogg; music Ogg. Writes the effect list the app requires. 1.2 MB of effects, 4.8 MB of music. | `assets/audio/sfx`, `assets/audio/music`, `src/audio/effectFiles.js` |
| Play | `sfx.play(name)`, `sfx.loop(name)`, `sfx.music(mood)`; Music and Sound effects switches in Home → Settings, remembered on the device. Nothing plays in the background. | `src/audio/sfx.js`, `src/components/candy/ToggleSwitch.js` |

Where each sound plays (the design's `_sfxDiff`): music per screen (dream on splash/login, party on the wheel and reel, cozy on Home/shop/achievements/create, calm on loading/squish, mystery on the box, crossfading); whoosh between screens; tap on every candy/round button, tab and switch; swipe on the Home tabs; swoosh on card and achievement paging; popOpen/popClose on the settings sheet and squish settings; coinShower / spend when coins go up / down (outside the squish screen and the box, which play their own); the box's rising tap (a thump and a bell pitched per tap), boxOpen, the reveal (jackpot), fail when the taps drain; the wheel's whirl, slowing ticks and win / jackpot; the reel's ticking, landing and jackpot; the unlock hold's rising hum with a note every 10% and the unlock chime; achievement; ready on Loading; boost on ×N COINS; adDone when a box video pays out; sparkle when a photo creature finishes turning 3D. The squish screen keeps its own squish / coin / release sounds. **Since 2026-09-29 (evening) every premade creature has its own squish loop:** the design's recordings in `ASMR Creature Squash Game (1).zip` (`export/creature-sounds/NN-name.wav`, NN−1 = creature id) go through `tools/audio/encodeCreatureSounds.py` (silence trimmed, tail crossfaded onto the head so it loops without a click, one shared gain to peak 0.7, mono Ogg) into `assets/audio/creatures/<id>.ogg` (~63 KB each); `src/audio/creatureSquish.js` picks it by id, or a custom creature's own `audio` URL, or the old `slime.wav`. To change the level, edit `PEAK` in the script and re-run it. The loop only plays while the finger *moves*: a press starts it, a finger that rests for 180 ms fades it out (350 ms) and pauses it, the next movement (3 dp or more, so jitter doesn't count) fades it back in (120 ms) from where it paused, and letting go fades it out (400 ms) — `SquishSound.js`. **Vibration (2026-09-29, `src/haptics/squishHaptics.js`)** follows the same shape: one impact on landing, a tick every 65-150 ms while the finger moves, one on release; nothing while resting, rotating or on the coin tick. Its strength is the Poke strength setting (1 = light ticks every 150 ms … 5 = heavy ticks every 65 ms and a double-tap landing; expo-haptics has only light/medium/heavy on Android, so rate does the rest). A Vibration switch sits in the squish settings under SQUISH, default on; like the sound switches it isn't persisted. Not felt on the emulator (no vibrator).

Performance notes (measured on the Pixel_9 emulator):
- Each expo-av sound is a whole ExoPlayer (decoder + 3–4 threads). Keeping ~40 loaded ran the 2 GB emulator out of memory, so only 8 effects stay loaded (least recently used released) and the box's ten tap sounds are two samples pitched by the playback rate.
- Replaying an Ogg restarts its decoder; short effects are WAV for that reason. The box preloads its sounds when the screen opens.
- With sound on, the box's fast taps still register, but late in a 10-tap burst they lag more than with sound off (about 0.6 s behind at the 10th tap on the emulator vs about 0.3 s). A real phone should do better; if it doesn't, the next step is a native low-latency player (SoundPool) for effects.

**Metro:** `metro.config.js` now lists `ogg` as an asset type — restart Metro after pulling this (an older Metro fails with "Unable to resolve module …dream.ogg"; see [EMULATOR_TROUBLESHOOTING.md](EMULATOR_TROUBLESHOOTING.md)).

## Round 5 — review fixes, the unlock economy, paid Remove Ads: DONE (2026-09-29)

Checked on the Pixel_9 emulator. Real purchases can't be made until the Play Console setup below is done.

### Review fixes

| Area | What changed |
|---|---|
| Free creations | The "✓ 1 FREE GENERATION" pill on the Create card was a flat teal outline. It's now a blue candy pill (gloss, light streak, gentle breath) with a gold ball holding the count and "FREE CREATION". `src/components/CustomCards.js` |
| Music / sound switches | The design's flat switch was replaced by a candy one: glossy track in a white rim and dark ring with a lip, mint + "ON" or lilac + "OFF", and a white candy-ball knob that squashes when pressed and springs across. Used in Settings and the squish settings. `src/components/candy/ToggleSwitch.js` |
| Box: "Open for 500 coins" | Coins are only ever spent by an explicit OPEN · ⊙500 button, so once a box is paid for the hint only says "Tap the box to open!". "OPEN ANOTHER" shows no price. |
| Box: tap window | 0.4 s between taps (was 0.5 s). |
| Padlock keyhole | The locked card's gold keyhole was two views: a white-rimmed circle and a slot with no rim that also covered the bottom of the circle's rim, leaving a bare gold line. It's now one SVG shape (round top + slot) with the white rim and a thin brown edge all the way round. `GoldKeyhole` in `src/components/CreatureCard.js` |
| Box: cracks over the "?" | The design's 3rd crack climbed into the "?" coin and its 8th ran across it. They now zigzag across the box just above the coin; the 6th and 9th were nudged off its edge. Every crack now stays at least 36 px from the coin's centre; the coin's radius is about 34 px. `src/components/box/GiftBox.js` |

### Mystery Box: two daily boxes, then coins

| | Without Remove Ads | With Remove Ads |
|---|---|---|
| 1st box of the day | watch a video | free |
| 2nd box of the day | watch a video | free |
| every box after that | 500 coins (no video) | 500 coins |

The two daily boxes come back on the next calendar day (the phone's date, like the Daily Spin). The box screen shows them as two chips (a blue ✓ once used) with "Box 1/2 today · watch a video" + WATCH TO OPEN, "Free box 1/2 today · tap it!" with Remove Ads, and once both are used, "New video boxes in 13h 40m" + OPEN · ⊙500 (or "N MORE COINS" when short). The Home banner shows the next box's cost: ▶ VIDEO, FREE, ⊙500 or READY. A box that was paid for waits (`boxPending`) until it's opened, even across days. Profile fields: `boxDay` + `boxDayOpens` (today's count); `boxOpens` still counts every box ever opened (the achievements read it). The very first box ever fills Puffle's set of tokens.

`src/mysteryBox.js` (rules), `src/screens/MysteryBoxScreen.js`, `payBoxWithAd` / `payBoxWithCoins` / `openBox` in `src/firebase/firestore.js`.

### Unlocking creatures: each creature's own tokens, or $0.99

**Glorp is the only free creature** for new players. Accounts from before keep every creature they own, including Puffle and Nubbin, which used to be free.

**Coins don't buy creatures. They buy Mystery Boxes.** Every creature has its **own tokens** (Puffle tokens, Nubbin tokens…). Its key comes one of two ways, then the usual hold-to-unlock on the Home card:

| Way | Price |
|---|---|
| **Its own tokens**, from Mystery Boxes | **30** for #1 Puffle, **+5 for each creature after** (Nubbin 35, Dotty 40 … Cosmo 120). When the set fills, the key appears on its card by itself. |
| **$0.99** in the Key Shop | the same for every creature (Google Play / App Store) |

**What a box gives**, in two steps:

1. **Which creature.** First a rarity, then a random locked creature of that rarity. A rarity with nothing left to unlock is skipped.

   | Rarity | Chance |
   |---|---|
   | Common | 50% |
   | Rare | 28% |
   | Epic | 13% |
   | Legendary | 6% |
   | Rainbow | 2% |
   | Golden | 1% |

2. **How many tokens:** 1 token 80%, 2 tokens 17%, 3 tokens 3%.

The very first box ever fills Puffle's set (30 tokens), so a new player unlocks one creature straight away. If the only creatures left already have their keys waiting, a box pays 150 coins instead.

**Tunable in the database.** All of these numbers are in a Firestore document, `config/mysteryBox`. The app reads it (it can't write it) and uses the values above until it exists or for any field that's missing or wrong. To change the numbers without an app update, create it in the Firebase console → Firestore → `config` → document `mysteryBox`:

| Field | Type | Value |
|---|---|---|
| `rarityOdds` | map | `Common` 50, `Rare` 28, `Epic` 13, `Legendary` 6, `Rainbow` 2, `Golden` 1 (numbers) |
| `tokenOdds` | map | `1` 80, `2` 17, `3` 3 (numbers; the key is how many tokens) |
| `firstPrice` | number | 30 |
| `priceStep` | number | 5 |
| `boxPrice` | number | 500 (coins per box once the day's video boxes are used; since Round 6) |
| `dailyBoxes` | number | 2 (video boxes a day, free with Remove Ads; 0–10; since Round 6) |
| `spareBoxCoins` | number | 150 (coins a box gives when nothing is left to unlock; since Round 6) |

**How long it takes at these numbers** (simulation, an engaged player putting 1,500 coins a day into boxes and opening both daily boxes): Puffle from the first box, then the **second creature around day 64**, 5 by day ~87, all 19 in ~7½ months. A casual player (~600 coins a day) gets the second around day 100 and all of them in about a year. A box averages ~1.2 tokens, so lowering `firstPrice` / `priceStep` is the main dial.

**The Secret.** Once you own all 20 creatures, your next box gives the secret rainbow creature, Prism Glorp, and the Secret Keeper achievement. To make that clear, the box screen's top row ends with a pulsing **SECRET ???** chip. Tapping it opens a candy popup: Glorp's locked silhouette under a big gold "?", "A secret rainbow creature is hiding in the Mystery Box. Unlock all 20 creatures, and your next box reveals it!", and "YOU HAVE 5/20". Once found, it shows Prism Glorp. The Home banner says "5/20 · A SECRET AWAITS".

**Where it shows:**
- **Box screen:** the row at the top gives each rarity's chance ("COMMON 50%", from the database) and ends with the SECRET chip.
- **Box reveal:** the creature pops out with its rarity badge and name, "+2 NUBBIN TOKENS", and a bar of its tokens so far. When the set just filled, it adds "KEY READY! HOLD ITS CARD TO UNLOCK" and the left button is a gold UNLOCK IT (Home, on that card). Otherwise it's SHOP (the Key Shop on that creature's row). A coin box shows a big coin and "+150 COINS".
- **Locked card:** the creature's token and "12/30", and a pink UNLOCK pill. Tapping it opens the short popup: "Unlock it in the Shop:", "12/30 tokens · from Mystery Boxes", "Unlock now $0.99", and SHOP.
- **Key Shop:** every row shows the creature's token, "12/30 TOKENS" with a progress bar, and a $0.99 button. Owned rows show ★ OWNED; rows with a key waiting show KEY READY.
- **The token itself:** a round candy coin with a plum ring, a white rim, and the creature on a face in its rarity's colours.

**Code:** `src/economy.js` (defaults, reading `config/mysteryBox`, prices, picks), `src/mysteryBox.js`, `src/components/candy/Tokens.js`, `src/components/UnlockSheet.js`, `src/screens/StoreScreen.js`, `src/screens/MysteryBoxScreen.js` (odds row, SECRET chip and popup), `src/components/box/BoxReveal.js`, `openBox` and `subscribeToBoxConfig` in `src/firebase/firestore.js`, `STARTER_CREATURE_IDS` (now just Glorp) in `src/data/creatures.js`. Profile field: `tokens` (creature id → count). Fields from versions that only existed during testing (`stickerPile`, a `stickers` map) are ignored. The catalog's `price` field is not read.

**Key Shop speed.** Building every row at once took ~2.3 s on the emulator, long enough that a tap on SHOP looked ignored. The rows are now a FlatList of fixed-height, memoised rows that builds the ones in view first (starting at the focused creature): ~0.9 s in the dev build.

### Remove Ads ($1.99)

- **Floating button** on Home's lists, beside the down arrow: a gold candy pill with a "no ads" badge, NO ADS and a $1.99 tag, bobbing. It opens a popup listing what it does, with REMOVE ADS · $1.99. (Settings had the same entry until Round 6.)
- **Once bought** (`adsFree`): no ad strip on Home or the squish screen; no ad breaks (Daily Spin, free creation, and the WHOA THERE! punishment, which still pops up but just closes); the two daily boxes are free with no video; ×2 / ×3 / ×4 start without a video, labelled NO AD. After each boost the buttons recharge for 30 s ("READY IN 27s"), about the time the video would have taken. Without that, ×4 could run nonstop and the economy above would be four times faster for anyone who paid $1.99. To change it, set `AD_FREE_BOOST_RECHARGE_MS` in `src/economy.js` (0 = no recharge).
- Ad-free boosts still count toward "Max Boost" but not "Movie Night" / "Ad Enthusiast" (no video was watched).

### How purchases work (Google Play and App Store)

Four products, **with the same ids in both stores** (`PRODUCTS` in `src/economy.js`, `functions/purchases.js`):

| Product id | Type | Price | What it gives |
|---|---|---|---|
| `remove_ads` | one-time (non-consumable) | $1.99 | `adsFree` (see Remove Ads above) |
| `creature_key` | consumable | $0.99 | the key of the creature picked in the app |
| `creature_creation` | consumable | $4.99 | one custom-creature generation (`generationCredits` + 1) |
| `creature_creation_15off` | consumable | $4.24 | the same, bought instead while the Daily Spin's 15%-off prize waits; it uses the prize up |

Stores can't discount a price on the fly, which is why the 15% off is its own product. The app shows each store's own localized price; the dollar amounts above are only fallbacks, so set whatever prices you want in the stores.

**Buying a creation.** The Create screen's button shows FREE while the player has a generation credit (everyone starts with one), and the store price when they don't. Pressing it buys one and carries straight on with the creation. A paid creation gets no ad break. The Home "Create your own squishy" card shows the same price.

**The app never grants anything itself.** Every purchase goes to the `verifyPurchase` Cloud Function:
1. It checks the purchase with the store.
2. It checks the purchase was made by this player.
3. It grants the purchase exactly once (a `purchases/{id}` ledger), then acknowledges or consumes it (Google Play). On iOS the app finishes the transaction once the server answers.

Anything that didn't get through (the app closed mid-way, a pending payment clearing later, Remove Ads on a new phone) is sent again at sign-in, and on iOS StoreKit re-delivers unfinished transactions at launch.

| | Android | iOS |
|---|---|---|
| App side | The app's own Google Play Billing 8.3 module (`android/app/src/main/java/com/plushcrush/app/billing/`), `src/billing/index.android.js` | StoreKit 2 through `react-native-iap` 12.16.4, `src/billing/index.ios.js`. `react-native.config.js` keeps it out of the Android build: its Android side is Billing 7, which Play no longer accepts |
| How the server checks it | Google Play Developer API (`purchases.products.get`) with the functions' service account | Apple's signed transaction (StoreKit 2 JWS), checked against Apple's root certificate (`functions/apple/AppleRootCA-G3.cer`) with Apple's `@apple/app-store-server-library`, online revocation checks on |
| Whose purchase | sha256 of the uid in the obfuscated account id | the same hash in the `appAccountToken` UUID |
| Which creature (key) | the obfuscated profile id | the last 6 hex digits of the `appAccountToken` |

Shared code: `src/billing/common.js` (prices, errors, the server call, the account token with its own SHA-256, since Hermes has none). Server: `functions/verifyPurchase.js` (the handler, both stores), `functions/purchases.js` (the rules), wired in `functions/index.js`.

**Tested here:**
- **Server, end to end** against the Firestore emulator, with the command below:
  - Google Play (faked store responses): every product; nothing granted twice; acknowledge/consume; pending payments; wrong account; unknown tokens.
  - App Store: real Apple-library verification with a test certificate chain shaped like Apple's. Valid transactions are accepted. An untrusted chain, another app, an Xcode test transaction, a refund, another player, a mismatched product, and a live transaction without `APPLE_APP_ID` are all refused.

  ```
  cd functions
  firebase emulators:exec --only firestore --project demo-plushcrush "node verifyPurchase.test.js"
  ```
- **Tokens match:** the app's and the server's account tokens match (and the app's SHA-256 matches Node's).
- **Builds:** the Android app builds with Billing 8 and without `react-native-iap`. Both JS bundles build: Android includes only `index.android.js`, iOS includes `index.ios.js` and `react-native-iap`.

**Not tested:**
- **A real purchase on either store:** that needs the store setup below.
- **Anything on iOS:** there is no iOS app yet (see "iOS" under What is left).

### Setup still needed (yours to do)

**Google Play**
1. **Play Console → your app → Monetize → Products → In-app products:** create the four products above with those exact ids. `remove_ads` is a normal one-time product; the other three are consumable in use (the server consumes them).
2. **Google Cloud console** (the Firebase project): enable the **Google Play Android Developer API**.
3. **Play Console → Users and permissions:** invite the functions' service account (`PROJECT_NUMBER-compute@developer.gserviceaccount.com`) with **View financial data** and **Manage orders and subscriptions**. It can take up to a day to take effect.
4. **Test:** upload a build to an internal testing track, add your Google account as a license tester, install from Play, and buy each product. The emulator can't buy: its Play Store has no signed-in account.

**App Store** (once there's an iOS app)
1. **Apple Developer Program** membership, and the **Paid Apps agreement** signed in App Store Connect (IAP doesn't work without it).
2. **App Store Connect → the app → In-App Purchases:** create the same four products with the same ids (`remove_ads` as Non-Consumable, the others Consumable).
3. **`functions/.env`:** add `APPLE_APP_ID=<the app's numeric Apple ID>` (App Store Connect → App Information). Sandbox and TestFlight purchases work without it; live ones are refused until it's set.
4. **Build for iOS** with EAS Build (`eas build -p ios`, works from Windows) or Xcode on a Mac. This machine can't. `npx expo prebuild --platform ios` generates the `ios/` project; `react-native-iap` links automatically.
5. **Test** with a sandbox Apple ID (App Store Connect → Users and Access → Sandbox) on a real iPhone or through TestFlight.

**Both**
```
firebase deploy --only functions:verifyPurchase,firestore:rules
```
`firestore:rules` replaces the live rules with this repo's file, so compare first if the live rules were edited in the console. Keep the service-account key (`squishy-app-61445-firebase-adminsdk-*.json`, currently in the project folder) outside the project: `.gitignore` skips it, but it gives full admin access.

### Checked on the emulator

- **Home:** with and without ads, and a locked card with its tokens.
- **Locked-creature popup:** SHOP → Key Shop on that creature's row, including one further down (Glimmer).
- **Key Shop:** $0.99 failing politely.
- **Settings:** the new switches and the Remove Ads entry; the Remove Ads popup.
- **Daily boxes:** box 1 by video → open, box 2 by video → open, then the coins state with its countdown and OPEN ⊙500.
- **With Remove Ads:** a free daily box ("Free box 1/2 today · tap it!"), no ad strip, and NO AD boosts that start at once and then recharge for 30 s.
- **Cracks:** photographed at nine taps.
- **Unit checks:** token prices, which creature a box picks (the next two ~40% each), bundle sizes and caps, Puffle's first box, the coin box, the daily-box rules, plus the purchase grant rules.

**Tokens, checked on the emulator** (on a real account, looking only; opening a box was switched to save nothing for the test):
- **Puffle, with 20 real tokens:** 20/30 on the card, in the popup and in the Key Shop.
- **Popup → SHOP:** opens on Puffle's row.
- **Box screen:** the rarity chips, then SECRET ??? and its popup ("YOU HAVE 1/20").
- **A box reveal:** a Rare Glimmer, "+1 GLIMMER TOKEN", 1/65. Its progress bar had collapsed to a dot and is fixed (it now spans the column).
- **SHOP from the reveal:** the Key Shop on Glimmer's row.

Not checked on the emulator: buying a creation (needs Play products).

## Round 6 — last review fixes: DONE (2026-09-29)

Checked on the Pixel_9 emulator unless noted.

### Screens
- **Splash:** no creature sits behind the wordmark, the tagline or TAP TO START any more. The creatures are placed in zones measured on screen (above the wordmark, between the tagline and the button, beside each), so this holds on any screen shape. A zone that's too short shrinks its creatures; a side zone too narrow for one stays empty.
- **Ad strip on more screens:** the Mystery Box, the Key Shop, Achievements and Stats now have the ad strip along the bottom, as on Home and the squish screen (none with Remove Ads). The box's toasts sit above it.
- **Settings:** Remove Ads and the stats are gone (Remove Ads stays on Home's NO ADS button). The sheet scrolls when it's taller than the screen allows: checked by padding it past the screen. The backdrop used to wrap the scroll view in two touchables; it's now a sibling behind the sheet. The empty gap under "Sound effects" is fixed.
- **Stats (new screen):** a chart button left of the trophy on Home opens YOUR STATS: the favourite creature, eight tiles (squishes, longest hold, time squishing, coins earned, creatures, achievements, boxes opened, biggest boost) and the five most-squished creatures, custom ones included. `src/screens/StatsScreen.js`; the icon is `StatsIcon` in `RoundButton.js`.
- **Squish screen:**
  - **Hint hands:** redrawn in the candy style: white hands with the header icons' dark outline and drop, pink-and-white touch rings, and the Mystery Box's glass pill for the caption.
  - **Rotate caption:** now says **2 FINGERS TO ROTATE**, since one finger pokes.
  - **Settings pointer (new):** a third hand under the gear, a pink halo pulsing round the gear, and a **GAMEPLAY SETTINGS** pill ("Sound · vibration · poke"). It fades when the gear is opened, or 4 s after the first squish; the stage hints still go on the first touch.
  - **FPS:** off by default.
  - **Coins only while moving:** coins follow the squish sound's rule. Only time spent moving the finger counts, and every 1.5 s of it pays a tick; a finger that holds still earns nothing. Checked on the emulator: holding still for 4 s gave nothing, and dragging for 3.5 s gave +10 (two ticks).
- **Creating a creature:**
  - **The "uploading" overlay:** redesigned on the candy stage. A gold CREATING… title, the picture in a round candy frame under spinning rays, a white-and-pink shine sweeping down it (the teal scan line is gone), a pink progress bar and a glass note.
  - **After CREATE:** Home now opens on MY CREATURES, on the new creature's card. It used to land on OUR CREATURES: Home mounts fresh at that moment and ignored the first value of the old focus counter. App now passes the new creature's id (`focusMine`). If its doc arrives a moment later, the list waits on the last page and then snaps to the card.
  - **The custom creature card:** rebuilt on the premade card's layout. The dotted pink backdrop, rays, gold pedestal, sticker-style name with a MY CREATION chip, a round trash button, and candy PLAY / PLEASE WAIT… / RETRY. A photo creature sits in the same round candy frame. While it builds, the frame shows the shine sweep and a glass BUILDING IN 3D · N% pill with a progress bar; a failed one shows COULDN'T BUILD IT.
  - **How these were checked:** fake creatures injected for a moment (assembled, building at 42%, failed, and one arriving 2.5 s late), and the overlay forced on. Ted's free creation was not spent.

### Buying a creation: fixes
The purchase path was already in place (Round 5). Reading it end to end turned up two bugs:
1. **A paid credit could show as FREE, followed by an ad.** If the purchase went through but the creation didn't (the upload failed, or the store confirmed late), the next press showed FREE. It then played the forced ad break meant for the free creation. Now:
   - **Server:** `verifyPurchase` also counts bought credits in `paidCredits`, and `generateCustomModel` spends a bought credit first (a refund puts it back the same way). The rule is `spendCredit` in `functions/purchases.js`.
   - **App:** a leftover bought credit shows as **PAID** on the Create button ("Uses the creation you bought") and as CREATION READY on Home's card, and gets no ad break.
   - **Rules:** `firestore.rules` keeps `paidCredits` server-only.
2. **"Already owned" on Google Play.** If an earlier creation or key purchase was never consumed, Play refuses a new one. The app then showed "Ads removed — thank you!" and nothing happened. Now it sends the stuck purchase to the server (which grants and consumes it) and opens the Play sheet again once.

**Tested:** the server suite passes on the Firestore emulator (`functions/verifyPurchase.test.js`, now with paid-credit checks and `spendCredit` rules). Both JS bundles (Android, iOS) build. `react-native-iap` 12.16.4 does return `verificationResultIOS` in StoreKit 2 mode, which the iOS path relies on. `verifyPurchase` is live (an unauthenticated call gets 401).

**Not tested:** a real purchase. That still needs the Play Console products and license testing (Round 5's setup list, steps 1–4), and an iOS build for the App Store.

### Prices from Firebase
Every coin price is now in `config/mysteryBox`: the box's price in coins (`boxPrice`), how many video boxes a day (`dailyBoxes`) and the coins a box gives when nothing is left to unlock (`spareBoxCoins`). They join the odds and token prices already there (the table under "Unlocking creatures"). The app picks a change up live, no update needed; a missing or bad value falls back to the default. Checked with a Node test of the parsing (defaults, set values, bad values, the document deleted).

**Real-money prices, as price levels (`config/pricing`).** Google Play and the App Store only charge the price stored on their own product, so Firebase picks *which* product is sold. Each of the three can be sold at other prices, as its own store product named `<id>_<cents>`:

| Field in `config/pricing` | Example | The app then sells | Default (no field) |
|---|---|---|---|
| `creatureKey` | 1.49 | `creature_key_149` | `creature_key` |
| `removeAds` | 2.99 | `remove_ads_299` | `remove_ads` |
| `creation` | 5.99 | `creature_creation_599`, and `creature_creation_15off_509` for the Daily Spin's 15% off (85%, cents rounded down) | `creature_creation`, `creature_creation_15off` |
| `creationDiscount` (optional) | 4.99 | `creature_creation_15off_499`, instead of the automatic 85% | — |

To change a price:
1. **Create the product first**, in both stores, with that id and that price. Key and creation products are consumable; Remove Ads is non-consumable.
2. **Set the number** in Firestore → `config` → document `pricing` (a number, in US dollars).

The app picks the change up live, no update needed. It shows the store's localized price once loaded, and the Firebase number before that. A price whose product doesn't exist yet can't be bought ("Purchases aren't available right now"), and the app logs which ids are missing. Removing the field goes back to the base product.

The server grants any price level like its base product, so purchases made at an older price still sync. **Deactivate a price level you no longer sell** (Play Console: set the product inactive; App Store Connect: remove it from sale). Otherwise a modified app could still buy an older, cheaper one.

Checked: Node tests of the app's price logic (ids, labels, the discount, bad values) and the server suite with price-level purchases (a $1.49 key, a $5.99 creation, $2.99 Remove Ads; lookalike ids refused). Not checked: a real purchase at a price level (needs the store products).

**Deploy (yours to run).** Also needed for price levels: the live `verifyPurchase` only knows the four base ids. Both functions must go out together: the new `verifyPurchase` without the new `generateCustomModel` would leave bought credits marked PAID forever.
```
firebase deploy --only functions:verifyPurchase,functions:generateCustomModel,firestore:rules
```
Until then the app behaves as before (no `paidCredits` means FREE, as today). As before, `firestore:rules` replaces the live rules with this file, so compare first if they were edited in the console.

## Key Shop stalls (2026-09-29)

The Key Shop's list of rows is now a street of market stalls, one per rarity (Common, Rare, Epic, Legendary, Rainbow, Golden), each in that rarity's colours. A stall has:
- a striped, scalloped awning hanging from a candy rod, with the rarity's name on a candy sign. Rainbow's stripes run through the rainbow; Rainbow and Golden twinkle.
- candy-cane posts and a dotted back wall.
- shelves with two creatures each, every creature in a white display box: its art on a soft glow, its name, its tokens with a bar, and the $0.99 button (or ★ OWNED / KEY READY). A rarity with one creature (Rainbow, Golden) shows it as a single wide showcase.
- a counter along the front with "3/7 OWNED".

Opened from a locked creature's popup (SHOP), it still lands on that creature's shelf, and the creature still breathes. Nothing about buying changed.

Code: `src/components/shop/Stall.js` (the stall art, colours per rarity and sizes) and `src/screens/StoreScreen.js` (the list and the display boxes). The list is still a FlatList of fixed-height pieces (a stall's top, each shelf, its counter), so it builds a shelf at a time as before.

Checked on the Pixel_9 emulator at 411 dp and 360 dp wide, with some creatures temporarily forced to locked, key-ready and part-way through their tokens (the override is removed): every stall, the showcase, the counters, and opening on Zappy's shelf.

## What is left

### Creature unlocking: decided and built (Round 5)

The earlier research (same day) led to Round 5's creature tokens / $0.99 and paid Remove Ads. From the same list, still open: new creatures in seasons (the catalog and art are server-side, so no app update is needed; `tierOf` places ids 19 and up in Golden, so new creatures need a tier rule first), Prism Glorp as a playable reward for finishing the set, a starter pack, and a monthly pass. Never sell boxes for real money (odds disclosure rules, and Brazil's ban for under-18s).

**Before real money flows:** the Play Console products, the service-account permission and the `verifyPurchase` deploy in Round 5's setup list.

### Smaller follow-ups
- **Box tap lag with sound:** check fast Mystery Box tapping on a real phone (see Phase 3's performance notes). If it lags there too, move effects to a native low-latency player (SoundPool).
- **iOS: a Restore Purchases button.** App Review expects one for a non-consumable like Remove Ads. The app restores it on its own at sign-in (`syncPurchases`), but a visible RESTORE link (for example in the Remove Ads popup) avoids a rejection.
- **Economy is still client-trusted:** coins, tokens and `ownedIds` are written by the app, guarded only by the rules. Paid things (`adsFree`, purchased keys) go through the server. Moving box pulls and key purchases into Cloud Functions would close the rest.
- **iOS:** there is no iOS app yet. Purchases are written for it (StoreKit 2, `src/billing/index.ios.js`) but have never run. Other iOS gaps: Ogg audio doesn't play on iOS (`tools/audio/encode.py` needs AAC), and the AdMob iOS app id in `app.json` is Google's test id.

## Performance (2026-09-29)

Profiled on the Galaxy A15 and rebuilt the squish stage's hot paths: the dent now runs in the vertex shader, touch picking uses a grid, sounds are pooled, and the heavy UI layers are cached as GPU textures. Squishing went from 44 fps (release) / 25 fps (debug) to 80-88 fps on that phone. Details, numbers and how to measure: [PERFORMANCE.md](PERFORMANCE.md). Judge smoothness on a **release** build — the debug build the emulator runs is several times slower.

## Notes for whoever picks this up

- react-native-svg ignores gradient `<Stop>`s wrapped in a React fragment; the shape renders black. Keep stops as direct children.
- Give full-screen SVGs their measured pixel size. With `"100%"` the background kept its first size and left a bare strip at the bottom.
- After many hot reloads, buttons can look stuck or popups linger. Relaunch the app before calling it a bug.
- Test account "Ted" on the emulator owns every creature. To see locked cards, force the state in code for a moment.
- Emulator problems (the app won't load, white screens, adb hanging): see [EMULATOR_TROUBLESHOOTING.md](EMULATOR_TROUBLESHOOTING.md).

## Round 7 — the 2026-10-03 drop: new roster, tutorial, progression, the Crib (IN PROGRESS)

A new `ASMR Creature Squash Game.zip` replaced the old one on 2026-10-03 (281 new files, 26 changed). The screens are still in `ASMR Creature Squash v3.dc.html`; the new pieces are `Squad Crib v5.dc.html` (landscape) + `Squad Crib Vertical.dc.html` (portrait) with `crib-home.js`, `foods.js`, `furniture.js`, `daily-challenges.js` (levels, challenges, streak, tutorial state), `squish-guide.js` (the coach-mark overlay), `squish-rig.js` + `creatures-v2.js` + `plush-anim.js` (the plush animation engine) and a bigger `sfx.js`. `Squad Crib v1-v4`, `Creature Home*`, `Care Motion System`, `Creature Roster/Styles`, `Tripo Views`, `Creatures for 3D` are exploration pages, not screens.

**Rulings (the user, 2026-10-03):** the old 20 creatures and every player's progress are thrown away (still testing); the economy stays as it is (per-creature tokens, Round 5/6 prices — the design's shared tokens, $2.99 Remove Ads, $0.99 first creations, $6.99/mo Daily Creator, Starter Pack, streak discount and $ furniture are deferred); the Crib gets both orientations with the design's rotate toggle, and its state must survive rotation; the order is my call, nothing that works gets broken.

### Phase A — the 30-creature plush roster: DONE (2026-10-03)

| | What |
|---|---|
| Roster | 30 creatures, Nimbo … Avo (`tools/plush-art/roster.mjs`: names and descriptions from the design). Ids are roster positions and Firestore doc ids. The design's rarity formula stops at 20 (it would make ids 19-29 all Golden), so the tiers are spread over 30: 0-11 Common, 12-18 Rare, 19-23 Epic, 24-27 Legendary, 28 Rainbow (Boba), 29 Golden (Avo) — `tierOf` in `src/theme/candyTheme.js`. |
| Art | `tools/plush-art/render.mjs` renders each creature's `design/export/tripo/{key}/{key}-front.svg` (the drawing the design's plush component loads) with the design's sticker filter, to `xl` (320px, the 2D squish stage), `lg`/`lgLocked` (160), `md`/`mdLocked` (84), `sm` (30), plus `lgFace`/`lgLockedFace`/`mdFace`/`mdLockedFace` — the same without the drawing's own eyes and mouth, for the mood faces. It also collects each creature's `rig` (face geometry/colours from `creatures-v2.js`) and `moves`. ~1 min, 10 images × 30. |
| Faces and motion | `src/plush/faces.js` is the design's eye/mouth glyphs (squish-rig.js) as SVG strings; `src/plush/motion.js` samples the design's procedural moods (plush-anim.js: idle breath/sway/hop, happy, dance, clean, spin, sleep, sad, reveal, unlock/celebrate, and the lists' "cycle") into native-driver keyframe tracks. `CreatureThumbnail.js` draws body image + mood face overlay + blink + sparkles; the old 20-creature SVG fallback is gone. Not ported yet: arm/foot/ear part animation, the Crib moods (eat, bath, tv…) — they rest as idle for now. |
| Squish stage | New creatures have no 3D models yet, so they play through `SquishyToy2D` (plush box = 80% of the stage, `xl` art). A Tripo GLB put on the doc as `modelUrl` switches a creature to the 3D rig as before; the view sheets for Tripo are `design/export/tripo/<key>/` (front/back/left/right for the first 21; front/back only for Scoop … Avo). |
| Economy texts | `SECRET` is "Prism Nimbo"; achievements renamed to the design's (Bun Appétit … Stacked!), the Legendary/Rainbow/Golden ones go by tier; `spinWheel`'s roster filter no longer stops at 20 (**needs `firebase deploy --only functions:spinWheel`**). |
| Sounds | The zip's 20 recordings are new, still named after the old creatures; `tools/audio/encodeCreatureSounds.py` now reads the new zip and maps NN−1 → id, so 0-19 have their own loop and 20-29 use the shared one. |
| Key Shop | Rows play the design's `cycle` mood. |

**Publishing the roster (yours to run, needs the service-account key):**

```
python -m zipfile -e "ASMR Creature Squash Game.zip" tools/plush-art/design
node tools/plush-art/render.mjs
GOOGLE_APPLICATION_CREDENTIALS=<key.json> node tools/plush-art/publish.mjs --catalog --reset-players
```

`--catalog` REPLACES `creatures/0 … 29` (old fields, including the old `modelUrl`s, go away; 20-29 are created). `--reset-players` resets every profile to a fresh one (250 coins, Nimbo, no keys/tokens/boxes/stats/spins, `tut: 'start'`, `level: 1`), keeping identity, purchases (`adsFree`, `generationCredits`, `paidCredits`) and custom creatures. `--dry` prints without writing. To preview the art before publishing: `node tools/plush-art/serve.mjs` + `adb reverse tcp:9500 tcp:9500` and point App.js at `src/data/devCatalog.js` (git-ignored).

### Phase B — tutorial, levels, daily challenges, streak: DONE (2026-10-03)

| | What | Where |
|---|---|---|
| Profile fields | `tut` (tutorial step, `'done'` when over), `level`, `levelDay`, `daily` { date, prog, claimed, chest }, `streak`, `lastFull`. Client-written like coins; fresh profiles start at `tut: 'start'`, `level: 1`. | `src/progression.js`, `createUserProfile` |
| Guided tutorial | The design's coach marks (dim with a hole, pulsing ring, animated hand — tap / hold / two-finger twist —, caption with progress bar and a button; centred level cards) on this app's economy: tap to start → register → the first Mystery Box (free, it fills Mittens' tokens) → LEVEL 2 card → UNLOCK IT → hold Mittens' card → play → gear, close it → hold 5 s → twist two fingers → goal: 500 coins at ×10 → back → box 2 for 500 coins → a card about creature tokens → the shop, "keys unlock creatures" → back → MY CREATURES → the create card → the Crib. A step whose target isn't on screen shows a non-blocking banner and the steps point back when the player wanders (back to the card, back to the box, the shop button). "Replay tutorial" in Settings. The Daily Spin waits until the tutorial is done. | `src/tutorial/` (store, Target, steps, Guide, useTutorial), `TutTarget`s in the screens |
| Box rules bent by it | The very first box ever is free (no video) — my call, the design does the same; the tutorial's second box is paid with coins whatever the day's boxes say. | `boxPayMode` in `src/mysteryBox.js` |
| Levels | 2 at the first key (tutorial), 3 when the Crib tutorial is done (Phase C), then +1 per day the daily chest is opened. "LV n" pill beside the nickname. | |
| Daily challenges | From level 3: a gold clipboard button on Home (badge = rewards waiting) opens the design's panel — 3 game challenges (squish N times, earn N coins squishing, watch a bonus video) + 3 of the 6 Crib ones (bath, feed, sleep, dance, TV, play), picked by the date so every device sees the same list; CLAIM pays coins; all six claimed → the chest: +250 coins + 1 token of the cheapest locked creature (the design's shared token became one creature's token — my call), the streak, and the level. "Challenge complete: …" toast. | `src/screens/DailyChallengesSheet.js`, `bumpDaily`/`claimDailyChallenge`/`claimDailyChest` in `src/firebase/firestore.js` |
| Streak | Chest days in a row; +5% squish coins per day; a missed day resets it. The design's streak discount on creations is deferred with the other price changes. | `streakMultiplier`, SquishScreen `coinMultiplier` |
| Home header | Six buttons now (Crib, Daily, stats, trophy, shop, gear) at 36 px; the LV pill sits beside the name because five-digit coin counts didn't fit the design's one-row wallet. | `HomeScreen.js`, `RoundButton` variants `green`/`gold`, `HouseIcon`/`DailyIcon` |
| Rules check | `node --input-type=module -e "import('./src/progression.test.js')"` | `src/progression.test.js` |

Checked on the Pixel_9 emulator: the whole game-side tutorial (every spotlight, the hold progress, the box payment and taps, the cards), the header, the panel and its progress. Not checkable with adb: the two-finger twist (the step was passed with a temporary threshold and verified visually).

**Gotchas found:**
- `Animated.delay` in a loop holds an `InteractionManager` handle; thirty blinking creatures stalled the Key Shop's FlatList (it builds rows between interactions). Pauses are native zero-motion timings now.
- On Android `measureInWindow()` reports y from below the status bar (RN subtracts the visible frame) while the overlay starts at the screen top — `StatusBar.currentHeight` goes back on. A FlatList row clipped by `removeClippedSubviews` measures as (0, 0): treated as "not on screen".
- `useSyncExternalStore` returning the same mutable object never changes an effect's dependency — the tutorial hook depends on the store's version counter.

### Phase C — the Squad Crib: DONE (2026-10-03)

The creatures' home, from `Squad Crib v5.dc.html` (landscape) and `Squad Crib Vertical.dc.html` (portrait): seven rooms, every owned roster creature living in them with clean / energy / tummy stats, the player sending them to rooms to fix their needs, coins made by how happy they are, and furniture to buy and arrange.

| | What | Where |
|---|---|---|
| Rooms | Living room, kitchen, bathroom, bedroom, dance room, hatchery, yard. Each is the design's CSS room rendered in headless Chrome, **in layers**: `under` (the yard's sky), `base` (the room's own wall and floor), `over` (everything on top, with see-through holes where wall and floor show), `front` (the kitchen's snack table, drawn over the creatures). Rooms with a window or sky have a version per time of day (morning, day, evening, night). A check composites the layers back and compares them with the whole room (mean difference about 1 colour level). 26 images, 1.3 MB. | `tools/crib-art/render.mjs`, `tools/crib-art/check.py`, `assets/crib/rooms/`, `src/crib/roomArt.js` (generated) |
| Themes | The design's wall / floor / ceiling themes (6 per kind, the dance room's club set, the yard's ground) as 49 images at the size of what they cover, slid between the room's base and its `over` layer. Locked by level like the design. 0.7 MB. | `assets/crib/themes/`, `RoomBackdrop` in `src/crib/art.js` |
| The simulation | The design's `tick` / `sendTo` / `startMeal` as pure functions over one state object, saved as it is in `users/{uid}/crib/state` (debounced, on leaving, when the app goes to the background, and right away on a rotate or a purchase). An hour of the creatures' day is 15 s. Up to 10 min of time away is caught up when the Crib reopens, with no coins either way; **the same while the app is in the background** (the tick pauses). Coins the squad makes (or costs: sad creatures cost coins, as in the design) go to the profile's `coins`. | `src/crib/model.js` (+ `model.test.js`), `loadCrib` / `saveCrib` / `cribCoins` in `src/firebase/firestore.js` |
| Screen | Portrait: the scene ×1.3 in a sideways scroller with look-left / look-right buttons, the room tiles below. Landscape: the scene fitted, the room map behind a button. The blue button switches between them inside the app (a rotated view, not a device rotation, so Android never recreates the screen). Creature card (stats with trends, the six actions, sleep and snack pickers), need bubbles, "+12 TUMMY" labels, teleport pop-in/out, toasts, the daily gift (+150), daily-challenge events. | `src/screens/CribScreen.js`, `src/crib/Scene.js`, `CribCard.js`, `RoomTiles.js`, `ui.js` |
| Crib tutorial | crib → c_tap → c_feed → c_lvl3 → c_daily → c_offers, hosted inside the Crib's own container (so it rotates with it). | `src/tutorial/steps.js` |
| Furniture | The design's `crib-home.js` as pure functions over the state's `home`: 10 slots with 5 tiers each (sofa, TV, fridge, bathtub, beds, dance floor, DJ booth, speakers, ceiling light, club lights), 3 bath stations (shower, mud shower, sauna), 12 yard games on 4 play spots, 22 decor pieces. Tiers change the rooms: sofa seats for TV, bath spots and their cleaning speed, how long the beds let them sleep, what the fridge holds, dance-floor size, songs. Decor gives its room's perk (more coins, fuller meals, faster cleaning, faster energy, slower draining). A creature whose spot disappears (a smaller tier, a game put away) goes back to the living room. | `src/crib/home.js`, `tools/crib-art/export.mjs` → `src/crib/catalog.js` (every piece of art, per slot tier) |
| Home Shop | Purple button. A tab per room; upgrades, bath stations, games and decor as cards; locked above the player's level; coins only. **The design's $ prices are left out** (economy ruling: furniture money prices are deferred). A bought tier goes straight into use, a game onto a free play spot. | `src/crib/Shop.js` |
| Edit mode | Orange button. Creatures step out; a panel with Furniture (swap owned tiers; in the yard, what's on each play spot), Decor (store / place) and Walls & floor (themes). Decor and the yard's games are dragged in the room itself (dashed outlines, the design's limits). Landscape: a strip along the bottom that tucks away; portrait: in the room dock's place. | `src/crib/EditPanel.js`, `src/crib/Decor.js` |
| Motion | The yard's starter games are drawn in the app and move: the swing (ropes and seat, and whoever's on it), the seesaw, the trampoline (bounce and squash), the ball field (the ball flies between two players, or bounces over one). The other games move their creatures (slide, sandbox, ball pit, pool, merry-go-round, kite, bubble wand, hopscotch). The dance room's floor steps through its colours; the Ceiling Light and Club Lights tiers add the disco ball, wheeling spots, swinging beams, lasers and the light show, faster while someone dances. All on the UI thread (Reanimated, one clock, the design's own formulas). | `src/crib/Yard.js`, `src/crib/Dance.js` |
| Evening and night | The dark over the room (and the creatures) with a soft hole and a coloured glow around every lamp that's on; tap a lamp to switch it; the time of day's tint over everything. | `src/crib/Night.js` |
| Music | Each room has its own track, the dance room plays the DJ booth's current song (the song pill switches it; better booths have more). 11 tracks rendered from the drop's new music engine (`node tools/audio/render.mjs --crib`, then `encode.py`), 3.2 MB. The design's TV glow is switched off in the design itself, so there's none here either. | `assets/audio/music/crib_*.ogg`, `club_*.ogg`, `ROOM_MUSIC` in `CribScreen.js` |

**Rebuilding the Crib's art** (after a new design zip): `node tools/crib-art/render.mjs` (rooms + themes + `roomArt.js`, ~2 min), `python tools/crib-art/check.py`, `node tools/crib-art/export.mjs` (catalogue), `node tools/audio/render.mjs --crib` + `python tools/audio/encode.py` (music; then restore the re-encoded but unchanged older `.ogg` files from git — Vorbis gives each encode new bytes).

Checked on the Pixel_9 emulator: rooms, themes (wall, floor, ceiling), the shop (buying tiers and decor, coins taken), Edit mode in both orientations (tiers, themes, dragging decor and games, the yard's play spots), the swing, ball field, seesaw and trampoline moving, the dance floor stepping and the disco ball, the night with a lamp on and off, saving across leaving, a force-stop and the layout switch.

**Gotchas found:**
- Android's `zIndex` reorders siblings: the creatures (zIndex 100 + their feet) drew over a front layer without one — the night didn't darken them and front furniture sat behind them. The front layer has zIndex 1000.
- Reanimated's `useFrameCallback` registers its callback again whenever the function changes; with an inline callback every render restarted `timeSinceFirstFrame` and the motion jumped back. The callback is memoized and the clock is the frame's own `timestamp`.
- The emulator's 2 GB fills up (the app is ~330 MB native heap at Home already, plus a WebView); when it swaps, taps arrive seconds late and land on whatever is on screen by then (one closed the shop and hit the rotate button underneath, another a $0.99 key button). `adb reboot` clears it; wait for each screen before the next tap.
- Twelve animated plush creatures cost the living room ~160% of the emulator's CPU in the debug build (the dance room's lights ~90%). Worth measuring on the A15 in a release build.

### Phase D — polish: DONE (2026-10-03)

| | What | Where |
|---|---|---|
| Key Shop | The design's **NEXT UP** banner on top: the first creature you neither own nor hold a key for, jumping in front of slow rays under a gold ribbon, with its rarity, tokens so far and the $0.99 key. The tutorial's "keys unlock creatures" points at it. | `src/components/shop/NextUp.js`, `StoreScreen.js` |
| Box reveal | The creature now plays the design's `reveal` mood (shoots up out of the box, drops, settles, hops) instead of `celebrate`. | `src/components/box/BoxReveal.js` |
| Achievements | Creature badges play the design's `cycle` mood instead of standing idle. | `src/screens/AchievementsScreen.js` |

## Round 8 — the user's review of Round 7 (2026-10-03, evening)

| Ask | What changed | Where |
|---|---|---|
| Tutorial starts after login | No hints on the splash or sign-in screens any more; it starts on Home once signed in and picks up from the profile's step after a restart. | `src/tutorial/useTutorial.js`, `steps.js` (`QUIET` screens) |
| Reopening jumped to level 3 / daily challenges too early | `TEMP-DEV-DAILY` (forced the daily button on) is gone. Daily Challenges need level 3 **and** the tutorial over (or at its `c_daily` step), so a replay hides them again. After a restart in the Crib steps the starter is sent home hungry again and `c_lvl3` falls back to feeding instead of showing "level 3" over a stale state. | `src/progression.js` (`dailyUnlocked`), `steps.js`, `CribScreen.js` |
| Crib icon from level 2 | Home's house button shows from level 2 (`cribUnlocked`). | `HomeScreen.js`, `progression.js` |
| Empty creature cards | Not Firebase: the app still runs on the preview catalog (`TEMP-DEV-CATALOG`), whose pictures come from `tools/plush-art/serve.mjs` on port 9500. It wasn't running and had no `adb reverse tcp:9500`. Publishing the catalog ends this. | — |
| Crib HUD = the design's | `src/crib/Hud.js`: the design's 46 px buttons (rim, three-stop face, brown ring + lip), its icons with their drop shadows, gold/red badges, LV / coins / time-of-day pills. Landscape: every button grouped on the left (back, music, rotate, map, shop, edit, daily, gift). Portrait: the vertical page's two rows and big room title. The scene covers the screen in landscape (`Math.max` scale). | `Hud.js`, `CribScreen.js` |
| Crib map = the design's | The CRIB MAP house: scenery shot from the design by `tools/crib-art/map.mjs` (`assets/crib/map.webp`); names, counts, need/busy pills, faces, YOU'RE HERE and the close button drawn over it. | `src/crib/CribMap.js` |
| Vertical room dock | Wooden planks, the tilted ROOMS sign, phase + LV pills, tiles with each room's wall/floor (the design's DOCK_BG, rendered by `map.mjs` to `assets/crib/dock/*@3x.webp`), faces, name/count pills, need badge, HERE frame. The portrait page fills the screen (no white strip at the bottom). | `src/crib/RoomTiles.js` |
| Rooms start cheap | Every furniture slot has a new cheapest tier (Box Couch, Box TV, Picnic Cooler, Washtub, Floor Mattress, Taped Square, Boombox Crate, Box Speakers, Bare Bulb); the design's tiers moved up one (`sofa1` is now the old `sofa0`, which costs 150). The rooms' baked-in fixtures (bookshelf, windows, clock, oven, curtains, neon signs, string lights…) are cut out one by one by `tools/crib-art/fixtures.mjs` and sold as decor; the design's "over" picture isn't drawn in those rooms any more, and the wall trim only shows with the design's wallpapers. | `src/crib/extra.js`, `home.js`, `art.js`, `fixtureGeo.js` / `fixtureArt.js` (generated) |
| Decor styles cheap → expensive | Walls / floors / ceilings: a bare first one (plaster, concrete; a dark basement in the dance room), the design's at a price, a luxe last one (Royal Damask, Gold Marble, Gold Coffers) — owned per room (`th:<room>:<kind>:<i>`), bought in the shop. New slots: the kitchen's table (Crate → Snack → Banquet; it carries the kitchen's seats), a rug per room (Bare Floor → Old Doormat → … → Royal Carpet) and a ceiling lamp per room (Bare Bulb → … → Crystal Chandelier; lights the room at night). Rugs, lamps and the table add to the room's perk. | `extra.js`, `home.js`, `Shop.js`, `EditPanel.js` |
| Everything movable | In Edit mode every piece of furniture has a dashed handle (each bed and speaker on its own, bath stations too) and can go anywhere in the room; its seats move with it (`home.spos`, `layout()`), so creatures use it wherever it stands. | `home.js` (`unitsOf`, `movables`, `setUnitPos`), `Decor.js` (`UnitHandle`), `Dance.js` (floor + disco ball offsets) |
| Max 10 in the Crib, chosen in the Hatchery | `CRIB_MAX = 10`: `state.members` live there; a newly unlocked creature moves in by itself while there's room; tapping a hatched friend in the Hatchery moves it in or out (AWAY), "full" at 10/10; the starter can't leave during the tutorial. `cribSize` on the profile for the new achievement. | `src/crib/model.js` (`syncPets`, `setMember`), `Scene.js` (pods), `CribScreen.js` |
| TV faces the creatures | The design's TVs were already drawn from behind; the new Box TV is too. | `extra.js` |
| 10-day streak, day 10 = half price | `STREAK_REWARDS`: 100 / 150 coins, +1 token, 250, a free box, 400, +2 tokens, 600, a free box, **half price on the next creation** (`streakDiscount`), paid with the daily chest; the track repeats after day 10; the squish bonus (+5%/day) stops at +50%. Shown on its **own flame button** on Home (the user asked to take it out of Daily Challenges): `StreakSheet`. The creator sells `creature_creation_half` (50% of the creation price level) while the reward waits; the server clears it on purchase. | `progression.js`, `StreakTrack.js`, `StreakSheet.js`, `firestore.js` (`claimDailyChest`), `economy.js`, `functions/purchases.js`, `verifyPurchase.js` |
| Key Shop = the design's | Coin pill in the header, NEXT UP with the outlined name and "Unlock key", and the design's stalls: rounded frame in the rarity's trim colour, striped awning + scallops, wooden sign "Common Corner 3/12", striped wall, 2-column cards (glow + rays, gold key, OWNED/READY chip, rarity strip, name, button, tokens) each on a wooden shelf. Our economy stays: the button is `KEY · $0.99`, the line shows the creature's own tokens. | `StoreScreen.js`, `src/components/shop/Stall.js`, `NextUp.js` |
| Achievements for what's there now | +23: levels 3/5/10/25/50/75/**100**, first chest / 30 chests, 3/7/10/30-day streaks, Crib care 1/50/250, Crib purchases 1/10/30, Full House (10 in the Crib), box doubles 1/25. New profile counters: `chests`, `bestStreak`, `cribCare`, `cribBuys`, `cribSize`, `boxDoublesTotal`. | `src/achievements.js`, `firestore.js` |
| Wheel: no ad after it | The interstitial after the wheel (and the reel) is gone; a coins prize offers **SPIN AGAIN** for a rewarded video (none with Remove Ads), up to 3 a day — checked by the server (`adSpins: { day, n }`, blocked for clients in the rules). | `DailySpinScreen.js`, `functions/dailySpin.js` (`spinAllowed`), `index.js`, `firestore.rules` |
| Box prize ×2 | DOUBLE IT on the reveal: a video (none with Remove Ads) gives the same tokens again (up to the full set, which then readies the key) or the coins again; 5 a day (`boxDoubles`). | `mysteryBox.js` (`doublePull`), `firestore.js` (`doubleBox`), `MysteryBoxScreen.js` |
| Create card size (asked mid-round) | The tutorial's target wrapper had no size, so CARD_SIZE's percentages shrank against it; the wrapper now has the card's size. | `HomeScreen.js`, `CustomCards.js` |

**Needs the user / a deploy:** `firebase deploy --only functions:spinWheel,functions:verifyPurchase,firestore:rules` (bonus spins, the half-price product, `adSpins` blocked for clients); create the store product `creature_creation_half` ($2.49 — or a price level `creature_creation_half_<cents>` at half of `config/pricing.creation`); publish the catalog (then remove `TEMP-DEV-CATALOG`). Saved Crib homes from before still load (`normalizeHome`), but their tier ids now mean one tier cheaper — the planned `--reset-players` clears them anyway.

**Native:** `android/app/src/main/res/values/styles.xml` got `windowLayoutInDisplayCutoutMode = shortEdges` (the landscape Crib hides the status bar and the camera cutout's strip stayed black). Needs a native rebuild — done for the emulator's debug build. A thin strip remains where the gesture bar is.

**Tools:** `node tools/crib-art/fixtures.mjs` (fixtures + trim + kitchen table, ~1 min), `node tools/crib-art/map.mjs` (map + dock tiles). Tests: `src/crib/model.test.js` (moving furniture, themes, fixtures / rugs / lamps, the 10-cap) and `src/progression.test.js` (streak track, gates) pass.

**Not checked on a device yet:** SPIN AGAIN and DOUBLE IT (they need today's wheel / a box opened with a real rewarded video), the half-price purchase (needs the store product), the tutorial from a brand-new account.

**Gotchas:** a furniture piece that loses its mirroring hands React Native a null transform, which throws (`validateTransforms`) — `Piece` always passes a list. Image `require`s can't sit in modules the Node tests import: fixture geometry is `fixtureGeo.js`, the pictures `fixtureArt.js`, and items refer to pictures by name (`art: 'kitchen.table'`). Chrome rewrites inline colours as `rgb(…)`, so the render tools' DOM lookups match on that.

## Round 9 — the Crib's animations, card, beds and attic (2026-10-03, night)

The user's review of the Crib. Rulings: new creatures start at **70%** on every stat; under **40%** a creature looks sad — smelly instead when Clean is its only low stat; landscape banners come from the top; Edit in portrait takes over the dock; the Hatchery is an attic.

**Animations, 1:1 with the design.** The design moves each Crib creature with two layers, now both ported:
- *Plush mood* (`plush-anim.js` → `src/plush/care.js` `planMood`, body tracks in `motion.js`): eating per food style (nibble / chomp / savor / gulp / slurp: the food held, shrinking per bite, tossed for a gulp, a noodle strand for a slurp; crumbs, steam, juice, burp, hearts; eating ↔ content faces with a chomping mouth), timed to the meal (`care: { food, eatStart, eatMs }`, one one-shot track started part-way in); bath per station (`care.bathStyle` from the bath spot: tub / bubble / hottub / spa / duck / shower / mud / sauna, washtub = tub — foam crowns, bubbles, steam, the spa mask and towel, orbiting ducks and splashes, rain, mud spots, sweat); dirty (smudges, stink lines); sad (tears, drops); sleep (Zs); clean (sparkles); happy (hearts); dance (notes); tv (own face → happy → party → content over 9 s, the screen's colours on the eyes). A plan = body tracks + face layers with opacity tracks + static SVG + sprites (small SVGs moved by sampled tracks); tracks with the same period share one native Animated.Value (`CreatureThumbnail.js` `usePlanValues`, `Sprite`, `Statics`). Props are skipped under a 40 px box. Arms/feet can't move (the art is baked images).
- *Care state* (`squish-rig.js` STATES as picked by v5 `animFor` → `src/crib/careState.js`): idle / sad / hungry / tired / smelly / bathing / sleeping / play / party / walk, and the dance cycle (groove → twirl → pop hop, 1.9 s each — the twirl is the design's ballerina turn about the upright axis), with tints (`CreatureThumbnail` `tint`) and particles (bubbles 3/s, Zs, mint haze, three orbiting flies, notes, sparkles) as looping sprites. Scene.js `Pet` applies it around the plush creature (origin 50% 92%, the twirl about 50% 55%); a yard walk hops.
- Moods per creature (CribScreen `moodOf` = the design's plushMood, `careKey`), looks from `model.js` `lookOf` (sad, or smelly when only Clean < 40).
- **The room-entry spin is gone:** `Pet` played its arrival pop (a flat 540° turn) whenever it mounted with `from` set — every time you walked into a room. It now plays only for an arrival happening now (since < 1.04 s), as the design's tp-in (bouncy grow + rotateY, after the 520 ms tp-out); the ghost is the design's tp-out.
- Need bubble = the design's speech bubble (40×46, ring, tail, glyphs, pop/pulse/float); "+N" label gold with a brown outline; selection ring gold.

**Card** (`CribCard.js`, rewritten from the design's markup): ink border with a lip, static avatar on a peach disc, plain ✕, the red "Enough …" pill under the header, stats with separate trend arrows, 50 px action tiles with coloured icons and a red "!" badge, sleep picker (bolt, striped gain bar, Tuck in) and snack picker (grid with corner price tags; 4 columns landscape, 5 portrait). Placed like the design: landscape right column 292 wide from 68 to the bottom; portrait everything under the scene.

**Beds** (`extra.js` `blanketSvg` / `blanketAt` / `SLEEPER_Y`, `home.js` `sleeperY`): the design's blanket was a strip *under* the mattress (it read as a second mattress). Every tier now has a blanket over the mattress up to the pillows with a white sheet hem; each sleeper is placed by its rig's mouth so the hem is at its chin (`blanketTop - 9 - mouth·0.72 + 72`).

**Other:** landscape banners — `src/crib/orientation.js` (`setCribLandscape`, `TurnWithCrib`; App.js wraps the app Toast + AchievementToast); the Crib toast drops from 70 px up. Edit: landscape tuck keeps the arrow tab on the bottom edge; portrait fills the dock edge to edge. Map: every room's 3 px frame drawn in code. Hatchery = `src/crib/attic.js` (also the dock tile). Stats: `data.js` `NEED_AT` 40, `START_STAT` 70.

**Bug fixed:** with no owned creatures known yet (catalog late, or briefly empty), `syncPets` moved everyone out and they never came back (they were "known") — then it saved. CribScreen now neither loads nor syncs until `ownedIds` is non-empty. The test account's 10 were moved back in by hand (they re-entered at 70%).

**Perf (debug, emulator, living room, 7 creatures):** app ~200% CPU (JS ~60-70%, RenderThread ~50-60%) vs ~160% measured in Round 7. Measure a release build on the A15 before trimming (candidates: memo `Pet`, fewer dance sparkles).

**Gift out, pantry in, clearer Back (2026-10-03, late; plushcrush-58).** The user's follow-up: the Crib's daily gift button (+150 coins a day) was irrelevant: removed, along with its popup, `GiftIcon` (ui.js) and the HUD's `gift` icon. (`state.gift` is still in saved docs, unused.) The snack and sleep pickers' underlined "Back" text didn't read as a button: `PickHead` is now a lipped pill with an arrow, in front of the title. **Pantry shop, kitchen only** (`src/crib/Pantry.js`): a red basket HUD button that shows only in the kitchen (in the button row in landscape, top right in portrait), plus "Buy food for the pantry" under the snack picker. It sells what the fridge holds, +1 at the food's price or +5 for the price of 4 (`model.js` `FOOD_PACK`, `foodCost`, `buyFood`; tested in model.test.js). Paid and saved right away, like a Home Shop purchase. Leaving the kitchen closes it. Foods a better fridge would add are listed as locked. Meals still take from the pantry first, then cost coins.

**Round 9b (same night, the user's follow-up):**
- Still hungry shows: `model.js` `fixing()` — a stat counts as being fixed only in the bath / in bed / at the table *with a meal going*; `lookOf`/`needOf` take `now`. `careState.careKey`: at the table between meals the creature shows how it feels (hungry lean, sad plush, tummy bubble).
- Kitchen: seats per table tier 14 below its top (`extra.js` `TABLE_TOPS` [286, 282, 290], `KITCHEN_SPOTS(top)`); each diner placed by its rig's mouth (`home.js` `dinerY`, mouth clamped 50-75% — bunbun's rig says 43, which doesn't fit its art) so the table hides the lower body and the food shows. `model.test.js` updated (kitchen seat 300 + 30).
- Box couch: its front's seat starts at y 46 like the design's sofas (48), so sitters show down to the cushion.
- Sad plush motion made readable (`motion.js`: sob sy 0.94+0.06·hic, ty 5-5·hic, head sway ±3°).
- `CreatureThumbnail` mood `list`: idle → dance → eat, 4 s each (eat = a Crib food by hash, 3 s meal + the full moment); Home's `CreatureCard` uses it. Splash `MOODS` = idle / dance. `care.js` caches plans (400 entries) so cycling doesn't re-sample.
