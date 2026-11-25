# Squish Squad → Unity: what's left

Status: 2026-11-24. Everything listed in `UNITY_MIGRATION_PLAN.md` as ✅ is ported, but nothing has run in a real
Unity yet. All of `unity/Assets/Scripts` compiles against Unity's libraries (the `UnityEngine.Modules` NuGet package)
apart from `Haptics.Android.cs`' `Handheld` (missing from that package, not from Unity).

## Done on `claude/zen-franklin-0aolqr` (untested in Unity)

- **Sounds and haptics** in every ported screen: the four games and Squish Time (the creature's squish loop, coin,
  pop, squish haptics), the result cards (stars, coin count, XP fill, level up), the level maps, the game screens'
  sound budgets, the menu and the Game Park, the shop, chests, spin, road, streak, settings, achievements. The game
  code reaches the sound through `Audio/Snd.cs` (no UnityEngine, so the test harnesses still compile). Settings'
  switches now drive `Sfx` (they only saved to PlayerPrefs before), and the music follows the app's stage.
  The chest box's own sounds (synthesized in the app's web pages) are synthesized the same way in Unity
  (`Audio/WebSynth.cs`, `Audio/ChestSounds.cs`, played by `Audio/SynthPlayer.cs`). Not done: the house's sounds
  (task 1).
- **Effects**: Sort and Stack now have the dust, sparks, poofs, angry puffs and confetti (Hop and Squishdoku had them).
- **Live creature animations, native**: the app's rig code (rive-rig.js, rive-generic.js, the defs and move files, the
  result page's states, the browser stand-in) compiled to C# by `tools/unity/rig/jsc.mjs` (`Creatures/Js`, its own
  assembly `SquishSquad.Rig`) and run by `Creatures/NativeRig.cs` on Unity's clock: every creature and every move,
  no JS engine, no recordings (the PuerTS plan and `LiveRig.cs` are gone, and so are the Mittens recordings).
  `Rigs.For` gives it to the menu (idle, fidgets, the Game Park walk, MY HOUSE's turn, the intro's surprised / look /
  dance and its squishes), the result cards (all three characters for every creature: the stars fallback only if
  the rig can't start), Squish Stack's road walker, the house and the yard. `tools/unity/rig-test/run.mjs --all`
  checks it against the JS rig frame by frame (118 creatures x 13 scenarios; see unity/README.md).
- **Purchases**: `Plugins/Android/PlayBilling.androidlib` (the app's Play Billing module, ported) and `Backend/Billing.cs`
  (products, price levels from config/pricing and config/offers, store prices, verifyPurchase, the sync of held
  purchases), wired to the shop.
- **Ads**: `Plugins/Android/RewardedAds.androidlib` (Google Mobile Ads 23.1.0, Google's test ids, as the app) and
  `App/Ads.cs` fill `Ui/AdHook`: the Blitz revives, the Stack and Hop hints, the Squishdoku save, the bonus spin. Off
  Android (the editor) there are no ads, so the games behave as with Remove Ads, as before.
- **config/levels** from Firebase (`App/LevelsConfig.cs`): the XP curve for the menu and every game.
- **Phone art**: on Android the imported textures are ASTC 4x4 (a quarter of RGBA32), the editor and Standalone stay
  exact (`Editor/ProjectSetup.cs` `CompressOnAndroid`).
- **Squish Time cards**: a creature without a shipped card downloads its published one (catalog `card.url`, as the app)
  and keeps it on the phone. Mittens' card stands in until it arrives (or offline).

- **The menu's creature and name plate**: the menu shows the player's chosen creature (profile.lobby.sel) with its own
  plate: every roster creature's plate is exported (`node tools/unity/export-menu.mjs --names`: its rarity's plaque,
  stars and lettering, 118 plates, 5.6 MB). A creature the menu can't animate (the native rig didn't start) or
  without a plate (prickle isn't in the prototype's roster) is shown as Mittens, with Mittens' plate.

## Left

1. **The house**: stages 2-11 of `HOUSE_PORT_PLAN.md` (camera and doors, creatures walking and acting, item taps, edit
   mode, the catalog, the house map, the Dance Club and the Movie Room, the beach, the yard games). The biggest piece.
2. **Tutorial**: new players' guided first steps.
3. **The real AdMob ids** (`App/Ads.cs`, the plugin's manifest, as src/firebase/ads.js) before release.

## Testing and release

- Add the Unity license secrets in GitHub, so CI builds and sends screenshots.
- Test on the PC and on the Galaxy A15: fix what breaks and measure the FPS (the native rig's cost first). On this PC
  (.NET 8, x64; `rig-test` `bench [alloc]`, the whole path from the rig's clock to the compiled scene, the GPU draw
  left out), per frame: Mittens 1.37 ms and 586 KB allocated (was 1.90 ms and 1,974 KB with the markup written and
  parsed), a result card's three (Mittens, Lumi, Biscuit) 4.03 ms and 2,006 KB (was 6.10 ms and 5,932 KB). The
  frame reaches the drawing code as a node tree (`Creatures/RigTree.cs`), no SVG text. What's left of the garbage is
  the rig's own: about half its arrays (`[x, y]` points from its mapping functions, ~1,300 a frame for Mittens), the
  rest the path strings it sets, the string buffers and the scene's shapes. Under ~50 KB would take the compiler
  keeping those point pairs out of the heap (escape analysis in `jsc.mjs`), the next step if the A15 shows GC
  pauses. `NativeRig.LastFrameMs` reports the rig's time in the app; its scripts start on a worker thread at launch.
- The native rig against the JS (`tools/unity/rig-test/run.mjs --all`, 118 creatures x 13 scenarios): 62,516 of
  62,540 snapshots the same markup, the rest at most 0.006 % of their pixels apart, and every frame's direct node tree
  the same as its parsed markup (last-bit differences: V8's
  Math.pow isn't quite fdlibm's, the port matches it 96 % of the time; Math.tanh / cbrt / log2 are the platform's).
- Still on stills, not live rigs: Squish Sort's and Squish Hop's play screens (tools/rig/sort.html / hop.html stages:
  their page scripts could be compiled with `jsc.mjs` the same way), the chest unlock's creature after BAM
  (`ChestSmashView.HeroRig`), and the house's runtime drawings (`House/HouseDraw.Eval`: draw-host.js, the same way).
- Check a purchase with a Play test account and a rewarded ad on the phone.
- In the Firebase console, add the Unity app's Android ID (`com.plushcrush.unity`), or switch Unity to the existing
  app's ID when it replaces the old app. Google Play billing needs the Unity app in the Play Console with the same
  product ids.
