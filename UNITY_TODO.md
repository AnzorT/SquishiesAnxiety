# Squish Squad → Unity: what's left

Status: 2026-11-23. Everything listed in `UNITY_MIGRATION_PLAN.md` as ✅ is ported and pushed to
`ccr-262e9e49-lz99nc`, but nothing has run in a real Unity yet.

## Main work left

1. **The house**: stages 2-11 of `HOUSE_PORT_PLAN.md`:
   - camera and doors
   - creatures walking and acting
   - item taps
   - edit mode
   - the catalog
   - the house map
   - the Dance Club and the Movie Room
   - the beach
   - the yard games

   This is the biggest piece.
2. **Live creature animations**: creatures move from recorded clips today; only Mittens' idle and walk are recorded,
   and many screens show still pictures. This needs a JavaScript engine package (PuerTS); ask the owner before
   adding it.
3. **Sounds**: connect them to every screen. The sound system is done (`unity/Assets/Scripts/Audio/`); each screen
   still has to call it.
4. **Effects**: the dust, sparks and confetti in the games.
5. **Ads and real-money purchases**: the hooks are ready, but the code to talk to Google's billing and to an ads
   provider still needs writing.
6. **Tutorial**: new players' guided first steps.
7. **Smaller items**:
   - shrink the art size before the phone build
   - the creature shown on the menu's name plate
   - load the levels config from Firebase
   - export the rest of the creatures' Squish Time cards

## Testing and release

- Add the Unity license secrets in GitHub, so CI builds and sends screenshots.
- Test on the PC and on the Galaxy A15: fix what breaks and measure the FPS.
- In the Firebase console, add the Unity app's Android ID (`com.plushcrush.unity`), or switch Unity to the existing
  app's ID when it replaces the old app.
