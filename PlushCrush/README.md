# PlushCrush 🍑

A 3D squishy-toy ASMR game in React Native + Expo. Squeeze slow-rise foam toys,
feel the rebound, collect the roster, swap the fills.

## What's inside

- `src/engine/SquishState.js` — the physics: compression + ease-out cubic
  "slow rise" decay on release, per-fill profiles (Memory Foam, Slime,
  Glitter Bead) with different rise speed, max depth, and burst behavior.
- `src/engine/SquishShaderMaterial.js` — GPU vertex-displacement shader that
  deforms the toy mesh at the touch point and adds foam-whitening/rim shading.
- `src/components/PlushToy.js` — procedural icosphere toy mesh, no external
  3D assets needed.
- `src/components/ParticleBurst.js` — point-sprite particle puff/burst
  feedback.
- `src/audio/AudioEngine.js` — layered ASMR audio: a continuous compression
  "bed" whose pitch/volume tracks depth, plus one-shot squelch/crunch hits on
  fast compression. Degrades silently if audio files aren't present.
- `src/hooks/useSquishToy.js` — wires physics + audio + haptics together for
  a screen to consume.
- `src/screens/ShelfScreen.js` — collectible grid, rarity-colored, locked
  toys dimmed with price.
- `src/screens/SquishScreen.js` — the single-focus play screen: full-bleed
  GL canvas, gesture-driven squish, fill dock.
- `src/screens/FillSwapSheet.js` — bottom sheet to change a toy's fill.
- `src/data/toyCatalog.js` — five toys across common/rare/epic rarity.
- `src/theme/tokens.js` — "collector's night shelf" design tokens (deep plum
  background, candy pastels, soft-glass UI).

## Run it

```bash
cd PlushCrush
npm install
npx expo start
```

Then press `i` (iOS sim), `a` (Android emulator), or scan the QR with the
**Expo Go** app on your phone. Real-device testing is recommended — touch +
haptics + audio are the whole point.

> First install may prompt to align Expo SDK versions: run
> `npx expo install --fix` if so.

## Notes

- Audio files aren't bundled (no placeholder MP3s shipped). Drop files named
  per `SAMPLE_MAP` in `src/audio/AudioEngine.js` into `assets/audio/` — the
  engine degrades silently if they're missing, so the app runs fine without
  them during development.
- The squish is a shader trick (vertex displacement), not true soft-body
  physics — this keeps it smooth on mobile GPUs.
