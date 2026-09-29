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
- **Coins:** earned while holding a squish, **1 coin every 1.5 s** (not the design's 2). Nothing is earned on release.
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

Checked on the Pixel_9 emulator against the design (recordings, frame by frame). Nothing is committed yet.

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

**App icon.** The user's `app-icon-1024.png` (repo root) is the new icon. `assets/icons/app_icon.png` is that image; `assets/icons/app_icon_foreground.png` is the Android adaptive-icon layer (the art without its light frame, sized to the 72 dp area launchers show, on `#B24FE6`). The `android/` folder was already generated, so its `mipmap-*` icons and `iconBackground` colour were rewritten too; `app.json` points at the same files for the next prebuild. On round launchers the gold coin in the top-right corner is partly cut, as with any full-bleed square icon. Checked on the emulator's launcher after a rebuild.

**Sound and music.** Everything comes from the design's own `sfx.js`:

| | What | Where |
|---|---|---|
| Render | `node tools/audio/render.mjs` runs `sfx.js` in headless Chrome with an OfflineAudioContext (sample-exact). Music is one full 24-bar cycle per mood with the tail folded onto the start, so it loops without a seam. | `tools/audio/render.mjs` |
| Encode | `python tools/audio/encode.py` (needs `pip install --user soundfile numpy`): effects levelled as one group (loudest at 0.92, about the app's old coin/pop level), short ones as WAV, long ones Ogg; music Ogg. Writes the effect list the app requires. 1.2 MB of effects, 4.8 MB of music. | `assets/audio/sfx`, `assets/audio/music`, `src/audio/effectFiles.js` |
| Play | `sfx.play(name)`, `sfx.loop(name)`, `sfx.music(mood)`; Music and Sound effects switches in Home → Settings, remembered on the device. Nothing plays in the background. | `src/audio/sfx.js`, `src/components/candy/ToggleSwitch.js` |

Where each sound plays (the design's `_sfxDiff`): music per screen (dream on splash/login, party on the wheel and reel, cozy on Home/shop/achievements/create, calm on loading/squish, mystery on the box, crossfading); whoosh between screens; tap on every candy/round button, tab and switch; swipe on the Home tabs; swoosh on card and achievement paging; popOpen/popClose on the settings sheet and squish settings; coinShower / spend when coins go up / down (outside the squish screen and the box, which play their own); the box's rising tap (a thump and a bell pitched per tap), boxOpen, the reveal (jackpot), fail when the taps drain; the wheel's whirl, slowing ticks and win / jackpot; the reel's ticking, landing and jackpot; the unlock hold's rising hum with a note every 10% and the unlock chime; achievement; ready on Loading; boost on ×N COINS; adDone when a box video pays out; sparkle when a photo creature finishes turning 3D. The squish screen keeps its own squish / coin / release sounds.

Performance notes (measured on the Pixel_9 emulator):
- Each expo-av sound is a whole ExoPlayer (decoder + 3–4 threads). Keeping ~40 loaded ran the 2 GB emulator out of memory, so only 8 effects stay loaded (least recently used released) and the box's ten tap sounds are two samples pitched by the playback rate.
- Replaying an Ogg restarts its decoder; short effects are WAV for that reason. The box preloads its sounds when the screen opens.
- With sound on, the box's fast taps still register, but late in a 10-tap burst they lag more than with sound off (about 0.6 s behind at the 10th tap on the emulator vs about 0.3 s). A real phone should do better; if it doesn't, the next step is a native low-latency player (SoundPool) for effects.

**Metro:** `metro.config.js` now lists `ogg` as an asset type — restart Metro after pulling this (an older Metro fails with "Unable to resolve module …dream.ogg"; see [EMULATOR_TROUBLESHOOTING.md](EMULATOR_TROUBLESHOOTING.md)).

## Round 5 — review fixes, the unlock economy, paid Remove Ads: DONE (2026-09-29)

Checked on the Pixel_9 emulator. Nothing is committed yet. Real purchases can't be made until the Play Console setup below is done.

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

- **Floating button** on Home's lists, beside the down arrow: a gold candy pill with a "no ads" badge, NO ADS and a $1.99 tag, bobbing. It opens a popup listing what it does, with REMOVE ADS · $1.99. Settings has the same entry (it used to be a free "CLAIM FREE").
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

## What is left

### Creature unlocking: decided and built (Round 5)

The earlier research (same day) led to Round 5's creature tokens / $0.99 and paid Remove Ads. From the same list, still open: new creatures in seasons (the catalog and art are server-side, so no app update is needed; `tierOf` places ids 19 and up in Golden, so new creatures need a tier rule first), Prism Glorp as a playable reward for finishing the set, a starter pack, and a monthly pass. Never sell boxes for real money (odds disclosure rules, and Brazil's ban for under-18s).

**Before real money flows:** the Play Console products, the service-account permission and the `verifyPurchase` deploy in Round 5's setup list.

### Smaller follow-ups
- **Box tap lag with sound:** check fast Mystery Box tapping on a real phone (see Phase 3's performance notes). If it lags there too, move effects to a native low-latency player (SoundPool).
- **Commit:** nothing from Round 2 onwards is committed yet.
- **Economy is still client-trusted:** coins, tokens and `ownedIds` are written by the app, guarded only by the rules. Paid things (`adsFree`, purchased keys) go through the server. Moving box pulls and key purchases into Cloud Functions would close the rest.
- **iOS:** there is no iOS app yet. Purchases are written for it (StoreKit 2, `src/billing/index.ios.js`) but have never run. Other iOS gaps: Ogg audio doesn't play on iOS (`tools/audio/encode.py` needs AAC), and the AdMob iOS app id in `app.json` is Google's test id.

## Notes for whoever picks this up

- react-native-svg ignores gradient `<Stop>`s wrapped in a React fragment; the shape renders black. Keep stops as direct children.
- Give full-screen SVGs their measured pixel size. With `"100%"` the background kept its first size and left a bare strip at the bottom.
- After many hot reloads, buttons can look stuck or popups linger. Relaunch the app before calling it a bug.
- Test account "Ted" on the emulator owns every creature. To see locked cards, force the state in code for a moment.
- Emulator problems (the app won't load, white screens, adb hanging): see [EMULATOR_TROUBLESHOOTING.md](EMULATOR_TROUBLESHOOTING.md).
