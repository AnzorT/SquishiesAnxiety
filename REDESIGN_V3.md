# Redesign v3 — status

Status as of **2026-09-28**. This tracks porting the new design into the React Native app: what the design is, what was decided, what is done, and what is left.

## The design

The new design came in as `ASMR Creature Squash Game.zip` in the repo root. Inside it:

| File | What it is |
|---|---|
| `ASMR Creature Squash v3.dc.html` | **The new design.** Source of truth for everything below. |
| `ASMR Creature Squash v2.dc.html` | An in-between version. v3 includes all of it. |
| `Creature Plush.dc.html` | The new "plush" creature art. |
| `sfx.js` | All music and sound effects, generated in code (Web Audio). |
| `App Icon v2.dc.html` | The new app icon. |
| `ASMR Creature Squash Game.html` | **Not the new design.** Identical to the old bundled page. |
| `Squish Squad Prototype.html` | An older prototype. Not the new design. |

What the redesign changes, in short:

- **Look:** a dark navy theme becomes a bright pink→violet stage with polka dots, bokeh and sparkles; glossy "candy" buttons; sticker-style titles; the Fredoka font; plush-style creatures.
- **New features:** Mystery Box with rarity tiers, 50 achievements in a carousel, a Daily Spin wheel, ×2/×3/×4 ad boosts, music and sound effects.

## Decisions made

- **Platform:** the redesign goes into the **React Native app**. The Unity port is dropped.
- **Coins:** earned while holding a squish, **1 coin every 1.5 s** (not the design's 2). Nothing is earned on release.
- **The tap-spam easter egg stays.** The "🚨 WHOA THERE! You're tapping way too much. You will be punished." popup is not in the v3 design, but it must be kept. It trips at 5 quick taps in 1 s or 7 in 2 s, and ACCEPT PUNISHMENT plays a full-screen ad.
- **Creature catalog is untouched.** Creature art lives in Firestore and only an admin can change it, so the plush look is drawn inside the app on top of the existing art.

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
- `src/components/CreatureThumbnail.js` — the plush layers on every creature.
- Deleted (no longer used): `src/theme/squadTheme.js`, `src/theme/tokens.js`, `src/components/squad/GradientButton.js`, `src/components/squad/IconButton.js`.
- New dependency: `@expo-google-fonts/fredoka`.

## What is left

### Phase 2 — new features (not started)

- **Mystery Box.** New screen, plus a banner on Home ("3/20 · FIND THE SECRET"). The first box is free, the second needs a video ad, then each costs 500 coins. The player taps it 10 times fast to open it. Rarity odds: Common 55%, Rare 25%, Epic 12%, Legendary 6%, Rainbow 1.5%, Golden 0.5%. A duplicate gives +150 coins.
- **50 achievements.** The list grows from 10 to 50 (squish counts, hold times, coins, box opens, rare pulls, spins, ads, creations…). The carousel already supports progress bars. New stats need saving on the player profile.
- **Daily Spin wheel** after login, with coin prizes plus a rare FREE creature and a rare free CREATE.
- **PAINT mode** in Create (draw your own creature). It needs a drawing canvas that can export an image.

Two questions need answers before Phase 2:

1. **Wheel "CREATE" prize.** It grants a free creation, but the Firestore rules stop the app from changing the free-creation count. Either add a Cloud Function that grants it, or drop that prize.
2. **Secret "Prism Glorp".** It's the prize once all 20 creatures are owned. It could be just a badge, or a real playable creature (which needs art and a 3D model).

### Phase 3 — audio and app icon (not started)

**Audio today:** the app plays only three sounds, all on the squish screen: the squish loop (`slime.wav`), the coin (`coin.mp3`) and the release pop (`pop.mp3`). There is **no music and no button/screen sounds**. The `music-*.wav` files in `assets/audio` exist but nothing plays them.

**Audio in the design (`sfx.js`):** background music per screen (dreamy on splash/login, party on the wheel, cozy on home/shop/achievements, calm on squish/loading, mystery on the box), plus about 35 sound effects (taps, swooshes, coins, box taps that rise in pitch, box open, reveal, unlock, achievement, ad start/finish, boost…). It is all generated in code with the browser's Web Audio API, which React Native doesn't have. The plan is to record every sound and each music loop to audio files (by running `sfx.js` in headless Chrome), then play them in the app.

**App icon:** the new icon (`App Icon v2.dc.html`, Glorp on a gold pedestal with pink rays and a gold coin) replaces `assets/icons/app_icon.png`. It needs rendering at 1024×1024, then a new app build.

## Notes for whoever picks this up

- react-native-svg ignores gradient `<Stop>`s wrapped in a React fragment; the shape renders black. Keep stops as direct children.
- Give full-screen SVGs their measured pixel size. With `"100%"` the background kept its first size and left a bare strip at the bottom.
- After many hot reloads, buttons can look stuck or popups linger. Relaunch the app before calling it a bug.
- Test account "Ted" on the emulator owns every creature. To see locked cards, force the state in code for a moment.
