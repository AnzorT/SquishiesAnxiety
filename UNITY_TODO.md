# Squish Squad → Unity: what's left

Status: 2026-11-23. Everything listed in `UNITY_MIGRATION_PLAN.md` as ✅ is ported, but nothing has run in a real
Unity yet. All of `unity/Assets/Scripts` compiles against Unity's libraries (the `UnityEngine.Modules` NuGet package)
apart from `Haptics.Android.cs`' `Handheld` (missing from that package, not from Unity).

## Done on `claude/zen-franklin-0aolqr` (untested in Unity)

- **Sounds and haptics** in every ported screen: the four games and Squish Time (the creature's squish loop, coin,
  pop, squish haptics), the result cards (stars, coin count, XP fill, level up), the level maps, the game screens'
  sound budgets, the menu and the Game Park, the shop, chests, spin, road, streak, settings, achievements. The game
  code reaches the sound through `Audio/Snd.cs` (no UnityEngine, so the test harnesses still compile). Settings'
  switches now drive `Sfx` (they only saved to PlayerPrefs before), and the music follows the app's stage.
  Not done: the chest box's own hit sounds (synthesized in the app's web page), the house's sounds (task 1).
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
- Test on the PC and on the Galaxy A15: fix what breaks and measure the FPS (the native rig's cost first: on this PC
  ~2 ms a frame for one creature with its markup, ~3.5-5 ms for a result card's three, ~1.5 MB allocated per creature
  frame; `NativeRig.LastFrameMs` reports it in the app; the scripts' start-up runs on a worker thread at launch). If
  the A15 is short, the next steps are typed numeric locals and direct calls in `jsc.mjs`, and stepping a card's
  three at 30 fps.
- Still on stills, not live rigs: Squish Sort's and Squish Hop's play screens (tools/rig/sort.html / hop.html stages:
  their page scripts could be compiled with `jsc.mjs` the same way), the chest unlock's creature after BAM
  (`ChestSmashView.HeroRig`), and the house's runtime drawings (`House/HouseDraw.Eval`: draw-host.js, the same way).
- Check a purchase with a Play test account and a rewarded ad on the phone.
- In the Firebase console, add the Unity app's Android ID (`com.plushcrush.unity`), or switch Unity to the existing
  app's ID when it replaces the old app. Google Play billing needs the Unity app in the Play Console with the same
  product ids.
