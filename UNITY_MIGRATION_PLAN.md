# PlushCrush → Unity/C# Migration Plan

Status: **Phase 0 scaffolding in progress (2026-09-20).** This document is the single source of truth for the port. It was built from a full, line-verified inventory of the current React Native/Expo app (three parallel research passes, 2026-09-19) — not from memory or assumption. Update it as decisions are made; don't let it drift from what's actually built.

## Guiding principles (per your 4 requirements)

1. **1:1 match, no scope creep.** Phase 1 (this plan) reproduces the app exactly as it exists today — same screens, same economy rules, same physics feel, same ad placements. No redesign, no "while we're at it" improvements. Anything tempting-but-not-current-behavior goes in §9 (Explicitly Deferred).
2. **Unity/C# best practices throughout** — see §3.
3. **Every point requiring your action is called out inline** with a 🔴 marker, and consolidated in §8.
4. **Build order starts from parity**, not from the eventual GPU-physics/IAP upgrades discussed earlier — those are explicitly out of scope for this plan (§9).

---

## 1. The one strategic fact that shrinks this project

**The entire backend is reusable, unchanged.** Firebase Auth, Firestore, Storage, security rules, and both Cloud Functions (`generateCustomModel`, `checkTripoBalance`) are plain Node.js/Firestore — nothing about them is React-Native-specific. The Tripo integration, the credit economy, the security rules, `google-services.json`/`GoogleService-Info.plist` — all of it stays exactly as-is in this repo. **Unity only needs to replace the client.** Do not touch `functions/`, `firestore.rules`, `storage.rules`, or the Firebase project itself as part of this port.

---

## 2. What "1:1" means, precisely

A complete, verified inventory (screens, Firestore schema, Cloud Functions, economy rules, ads, and the full squish-physics algorithm) was built for this plan. Rather than duplicate it here, treat these as the spec of record:

- **Screens/UI/navigation**: every screen in `src/screens/`, every prop, every animation trigger, the full `App.js` stage state machine, every component in `src/components/` and `src/components/squad/`.
- **Backend/economy**: the full Firestore schema (`users/{uid}`, `users/{uid}/customCreatures/{id}`, `creatures/{id}`, `config/pricing`, `feedback/{id}`), every security rule, both Cloud Functions step-by-step, the achievement list (`src/achievements.js`), the coin/key/generation-credit economy, and every ad placement (`AdBanner`, 3x `WatchAdButton`, `PunishmentModal`, `ForcedInterstitialAd`).
- **Physics/rendering**: the complete `tickPhysics` algorithm (dent spring, jelly-wave diffusion, weld-normal averaging, global squash, release wobble, orbit), the 3D load pipeline (`prepareModelData`/`buildModelCreature`), the 2D transform-based equivalent (`SquishyToy2D`), and `CreatureThumbnail`'s mood-animation/glow/shine system.

When implementing any piece, **re-read the actual current source file first** — this plan describes architecture and order, not a frozen snapshot of every constant. Two known drift risks already found during research:
- ~~🔴 The 3D-vs-2D creature list is Firestore-live, not static.~~ **Resolved 2026-09-21**: queried the live `creatures` collection directly (Node script + the `firebase` JS SDK, signed in with the existing test account from `reference_headless_testing.md`). Result: **all 20 creatures (ids 0–19) currently have a `modelUrl` set** — there is no 2D-only creature in the live roster right now. Every creature also has both `svg` and `svgLocked`. This can drift again in the future (it's still Firestore-live, not static) — the Unity `Creature` POCO already treats `ModelUrl` as nullable for exactly that reason, and `FirestoreService.SubscribeToCreatures` (Phase 1) reads it live rather than from a snapshot.
- The project's own memory notes (`project_squish_stage_rendering.md`) describe an older, now-removed static `MODEL_3D` per-id tuning map — the current code uses one shared `MODEL_TUNING` constant for every 3D creature. Trust the live code, not that memory file, if the two ever disagree.

---

## 3. Unity/C# best practices for this project

**Project structure**
```
Assets/
  _Project/
    Scripts/
      Core/          # state machine, app-root, data models (POCOs, not MonoBehaviours)
      Firebase/       # thin wrappers over Firebase Unity SDK calls, mirroring src/firebase/*.js 1:1
      Physics/        # SquishRig3D, SquishRig2D, tickPhysics port
      UI/             # one folder per screen, UI Toolkit controllers
      Economy/        # achievements, coins, keys, generation-credit client logic
      Ads/            # AdMob wrappers, mirroring the 4 ad-lifecycle call sites
    Prefabs/
    Scenes/            # likely just one persistent scene — see below
    Art/
    UI/                 # .uxml/.uss
  Plugins/              # Firebase SDK, AdMob SDK, glTFast (see §6)
```
- **Assembly definitions** (`.asmdef`) per top-level folder above, with explicit references only where needed (e.g. `UI` depends on `Core`+`Economy`, not on `Physics` internals) — keeps compile times sane and makes illegal dependencies a compile error, not a code-review problem.
- **Single persistent scene**, not one scene per screen. `App.js`'s entire model is one root component conditionally mounting one "stage" at a time plus two always-on overlays, with a lot of state (sound toggles, `homeIndex`, the `loadingToy`→`activeToy` handoff) that must survive screen transitions. A Unity scene-per-screen approach would fight that; a single scene with a `GameStateMachine` MonoBehaviour enabling/disabling screen roots (or swapping UI Toolkit panels) is the direct equivalent of `App.js`'s `stage` variable.
- **Data models as plain C# classes/structs**, not MonoBehaviours — mirror the Firestore schema exactly (`UserProfile`, `CustomCreature`, `Creature`, `PricingConfig`) with `[FirestoreData]`/`[FirestoreProperty]` attributes (Firebase Unity SDK supports POCO mapping directly — use it instead of hand-rolled JSON parsing).
- **ScriptableObjects** for static tuning data that has no per-user state: `PHYS` (strength/stiff/damp/wobbleKick), `MODEL_TUNING`, the `MOOD_ANIM` keyframe table, ad-unit-id config per environment (test vs prod) — makes them designer-editable in the Inspector and diff-friendly.
- **UI Toolkit (UXML/USS), not uGUI.** It's text-based, so it can actually be authored/reviewed as code (unlike uGUI's prefab+Inspector wiring), it's the modern Unity-recommended path, and `squadTheme.js`'s token system (colors/gradients/fonts/radii) maps naturally onto USS custom properties.
- **async/await over coroutines** for all Firebase/network calls — Firebase Unity SDK's `Task`-based API supports this natively; keeps `generateCustomModel`-adjacent polling logic (progress updates while a custom creature generates) readable instead of callback soup.
- **Object pooling** for `Ripple` and `FloatingCoin` equivalents — they're spawned frequently during play, exactly the case pooling exists for.
- **Unity Test Framework (NUnit)** for the deterministic, non-MonoBehaviour-dependent logic: the achievement conditions (`computeAchievements` port), the dent-spring/diffusion math (can be tested as pure functions over a mock vertex buffer), the abuse-detection sliding-window rules.
- **Version control**: `.gitignore` for `Library/`, `Temp/`, `Obj/`, `Build/`, `*.csproj`, `*.sln`, `UserSettings/`; Editor → Project Settings → Editor: **Visible Meta Files** + **Force Text** serialization so `.unity`/`.prefab` diffs are readable; consider Git LFS for binary art once real assets exist. **Vendored SDKs are also gitignored, not committed** (`Assets/Firebase/`, `Assets/ExternalDependencyManager/`, `Assets/Plugins/{iOS,tvOS}/`) — the Firebase Unity SDK alone is ~280MB with one file over GitHub's 100MB hard limit, and it's fully regenerable via the §4/§7 import steps, so it's treated like `node_modules` rather than checked in.
- **Naming**: PascalCase for types/methods/public members, camelCase for locals/private fields (`_camelCase` for private backing fields is fine, pick one convention and enforce via `.editorconfig`), namespaces mirroring the folder structure (`PlushCrush.Physics`, `PlushCrush.Firebase`, etc).

---

## 4. Firebase Unity SDK integration

Direct mapping from the inventoried `src/firebase/*.js` files:

| RN file | Unity equivalent | Notes |
|---|---|---|
| `auth.js` | `Firebase.Auth.FirebaseAuth` wrapper class | Same 4 methods: subscribe-to-auth-state, register, login, logout. Same age-gate UX logic ports to a C# `AuthController` — it's pure client-side validation, no Firebase-specific change. |
| `firestore.js` | `Firebase.Firestore.FirebaseFirestore` wrapper class | Every exported function (`addCoins`, `buyKey`, `unlockWithKey`, `recordPress`, etc.) has a direct transaction/set/update equivalent in the C# SDK. Port function-for-function — the inventory has the exact read/write shape of each. |
| `storage.js` | `Firebase.Storage.FirebaseStorage` wrapper class | Same two paths (`customUploads/{uid}/{file}`, `customModels/{uid}/{file}`), same rules (unchanged, server-side). Port the retry-on-`storage/unauthorized` logic (fresh-token + 3 retries) — it's a real, previously-hit bug, not defensive-programming excess. |
| `firestore.rules`, `storage.rules` | *(unchanged)* | Deploy exactly as they are today. No Unity-side action. |
| `functions/index.js` | *(unchanged)* | Unity never calls Tripo directly, same as the RN client never did — it only writes `customCreatures` docs and reads `status`/`progress` back via a live listener, exactly like `subscribeToCustomCreatures`. |

🔴 **Your action**: download the Firebase Unity SDK from firebase.google.com/download/unity and import the `.unitypackage`s for Auth, Firestore, and Storage into the Unity project (Assets → Import Package). This is a one-time interactive import step — I can write everything downstream of it, but the initial package import into a fresh Editor project is most reliably done by hand once. `google-services.json`/`GoogleService-Info.plist` already exist in this repo and can be dropped into the Unity project's `Assets/` root as-is (same Firebase project, no new project needed).

**Package identity (decided 2026-09-20)**: Firebase has no separate "Unity project" concept — it has one project (`squishy-app-61445`, already used by the RN app) containing platform apps keyed by package/bundle id. The RN app's Android `applicationId`/iOS `bundleIdentifier` are both `com.plushcrush.app`, which is what the copied `google-services.json`/`GoogleService-Info.plist` are keyed to. Decision: Unity uses the **same** `com.plushcrush.app` identity (full replacement, not a side-by-side test app) — set directly in `ProjectSettings/ProjectSettings.asset`'s `applicationIdentifier` block (Android/iPhone/Standalone all `com.plushcrush.app`, `overrideDefaultApplicationIdentifier: 1`). No Firebase Console changes needed as a result. Trade-off accepted: installing a Unity build on a device that already has the RN app installed will replace it, not run alongside it.

---

## 5. Squish physics port (the core technical risk)

This is the single most complex subsystem and the one most likely to feel subtly wrong if under-specified — the full algorithm (dent-fall precompute, per-frame spring-damper, jelly-wave diffusion, weld-normal averaging, global squash, release wobble, orbit momentum) was extracted from `SquishyToy.js` as exact, replicable pseudocode during research. Port it step-for-step, not "in spirit."

**Key facts that change the Unity implementation vs. the RN one:**
- Unity's `Transform` mutations **do** repaint every frame (unlike the R3F/Hermes quirk on the RN target device that silently no-ops transform writes and forced the *global* squash/wobble/breathe onto `group.scale`/`group.rotation` anyway — that part already uses a transform in the current app and should stay a transform in Unity, it's just no longer working around a bug, it's the natural approach).
- The **localized dent** still needs to be a per-vertex mesh deformation — not because of a repaint bug in Unity, but because a single object transform fundamentally cannot express a localized, non-uniform "poke" shape the way per-vertex displacement can. Port this as direct `Mesh.vertices`/`Mesh.normals` array mutation (`mesh.MarkDynamic()` for the frequently-updated mesh, then `RecalculateNormals()` where the RN code calls `computeVertexNormals()`) — same algorithm, same every-other-frame normal-recompute cadence, same weld-group re-averaging after every `RecalculateNormals()` call.
- Framerate independence: replicate the `k = dt * 60` pattern exactly (every stiffness/damping constant is a 60fps-rate exponentiated by `k`) using `Time.deltaTime` — don't substitute Unity's own spring/physics primitives, the feel is tuned to this exact formula.
- `.glb` loading: Unity has no native glTF importer. Use **[glTFast](https://github.com/atteneder/glTFast)** (Unity-recommended, MIT-licensed, runtime-capable) to replace `GLTFLoader`. Mirror the two-tier cache (`loadGltfFromUrl`'s disk cache + `loadModelDataFromUrl`'s parsed-and-prepped cache) with a download-to-`Application.persistentDataPath` + in-memory `Dictionary<string, Task<ModelData>>` cache, keyed by URL exactly as the RN version is.
- Weld-group computation (grouping vertices at identical positions, since low-poly Tripo exports duplicate vertices at UV seams) and adjacency-building (triangle-derived neighbor sets, replacing the procedural sphere's implicit row/col grid) both port as straightforward C# — same algorithms, just typed collections instead of `Map`/`Set`.
- 🔴 **Decision needed before Phase 4**: replicate the CPU-per-vertex-loop approach exactly (safest for 1:1 feel, matches this plan's phase-1 mandate), or invest early in a compute-shader version of the dent+diffusion step. Recommendation: **port CPU-side first, exactly as specified** — it's the only way to verify the port actually matches the original feel; a GPU rewrite is a legitimate Phase 2 optimization (§9) once you have a working, comparable baseline to test against.

The 2D equivalent (`SquishyToy2D` — used only for custom creatures without a 3D model) ports to a DOTween- or Unity-native-tween-driven transform on a `SpriteRenderer`/UI element, matching the exact same squash/lean/shift/twist/wobble formulas already extracted. Both rigs must expose the same six-method interaction contract (`PointerDown`/`PointerMove`/`PointerUp`/`Orbit`/`EndOrbit`/`CancelPoke`) behind a shared `ISquishRig` interface, exactly mirroring how `SquishScreen`'s single gesture handler drives either RN component interchangeably today.

---

## 6. Art & UI asset strategy

- **Creature art**: every creature's visual is server-baked SVG (`creature.svg`/`svgLocked` fields in Firestore), rendered generically by `CreatureThumbnail.js` with shared mood-animation/glow/shine logic layered on top. Unity has no first-class SVG renderer for this use case.
  - 🔴 **Decision needed**: either (a) pre-rasterize each creature's SVG to a sprite texture (normal + locked/grayscale variant) at a fixed resolution and drive the *generic* mood/glow/shine system in C# against those textures — closest to current behavior, recommended — or (b) use a Unity SVG import package (e.g. Vector Graphics package) to render at runtime. Rasterizing is simpler and matches how the art will actually be viewed (small, animated, never zoomed); recommend (a).
- **UI**: build every screen in UI Toolkit (UXML/USS) directly from the screen-by-screen inventory (every visual element, every animation trigger already documented). `squadTheme.js`'s color/gradient/font/radius tokens become USS custom properties in one shared stylesheet.
- **Fonts**: Baloo 2 (headings) and Nunito (body) are both on Google Fonts — same font files can be imported directly into Unity's TextMeshPro.

---

## 7. Ads (Google Mobile Ads Unity SDK)

Four distinct ad placements, each with an identical create→load→show→cleanup lifecycle already documented exactly (including the 8s failsafe timeout pattern used by the two forced-interstitial placements):

| Placement | Type | Port target |
|---|---|---|
| `AdBanner` | Banner, always-on | Bottom of Home's card stage + SquishScreen's bottom panel |
| `WatchAdButton` ×3 | Rewarded, player-initiated | The ×2/×3/×4 coin-bonus buttons on SquishScreen |
| `PunishmentModal` | Interstitial, forced | Tap-abuse guard |
| `ForcedInterstitialAd` | Interstitial, forced | Fires once after a free (non-paid) custom-creature generation |

🔴 **Your action**: the current ad unit IDs are Google's public **test** IDs everywhere (`ads.js`) — real AdMob app/unit IDs need to be created in your AdMob account and swapped in before any real build, same requirement that already existed for the RN app and was never blocking this port specifically.

---

## 8. Consolidated list of everything that needs you

1. **Firebase Unity SDK + AdMob Unity SDK package import** — one-time interactive `.unitypackage` import into the Unity Editor (§4, §7).
2. ~~**Live Firestore `creatures` catalog snapshot**~~ — ✅ done (§2): all 20 are currently 3D, none blocking.
3. **Real AdMob production ad unit IDs** — needed before any real (non-test) build (§7). Not new to this port — the RN app has the same open item.
4. **Google Play Console / App Store Connect accounts** — confirmed not yet set up (from the earlier IAP discussion). Needed for *any* real device distribution of the Unity build, not just IAP — flagging again here since it now blocks basic shipping, not only payments.
5. **On-device/Editor testing loop, same as this whole session** — I have no way to see a running Unity build. Every phase below ends with you running it and telling me what's actually wrong.
6. **Unity licensing decision** — already installed/activated (Unity 6.3, confirmed this session) under what's presumably a Personal license; revisit Unity's revenue-threshold terms if/when this ships commercially.
7. Everything already flagged 🔴 inline above.

---

## 9. Explicitly deferred (not part of this plan)

- **Real IAP** (Google Play Billing / Apple StoreKit) — already scoped and blocked on store account setup in an earlier discussion this session; revisit once §8.4 is done.
- **GPU/compute-shader physics** for higher poly counts than the app currently uses — a real, legitimate future optimization (discussed earlier re: Subway Surfers comparison), but Phase 1's mandate is parity with the current CPU-side algorithm, not an upgrade.
- **Fixing the `adsFree` dead flag** (set by `claimAdsFree` but never actually consulted to suppress any ad — a pre-existing gap found during research, not something this port should silently "fix" without you deciding it's in scope).
- **`purchaseCreature`** (an unused/possibly-dead Firestore function found during research, direct-unlock analog of `buyKey`) — carry over for parity or confirm dead code before dropping; not a blocking decision for Phase 1.

---

## 10. Build order

1. **Phase 0 — Environment.** ✅ Unity project created (6000.3.0f1), `Assets/_Project` folder structure + 6 `.asmdef`s (Core/Firebase/Physics/Economy/Ads/UI, dependency-ordered per §3) scaffolded, `.gitignore` in place and verified (`Library/`/`Temp/`/`UserSettings/` correctly excluded), git repo initialized (not yet committed — review `git status` and commit when ready), `google-services.json`/`GoogleService-Info.plist` copied into `Assets/`. Force Text serialization + Visible Meta Files were already Unity 6 defaults, no action needed. ⏳ Remaining: Firebase + AdMob + glTFast package install (🔴 your action, §4/§7 — open the project in the Editor and import the `.unitypackage`s).
2. **Phase 1 — Data layer. ✅ DONE and verified (2026-09-21).** C# POCOs written (`UserProfile`, `CustomCreature`, `Creature`, `PricingConfig` + nested types, `[FirestoreData]`/`[FirestoreProperty]`-decorated, field names pinned to the existing camelCase Firestore keys) and `AuthService`/`FirestoreService`/`StorageService` wrapper classes ported function-for-function from `src/firebase/*.js` (§4). Firebase Unity SDK (Auth/Firestore/Storage v13.17.0) imported and compiling clean. **Verified live against the real, unchanged backend**: a throwaway smoke test (`Assets/_Project/Scripts/_SmokeTest/FirebaseSmokeTest.cs`) registered a real Auth user and wrote+read back a `users/{uid}` profile doc — result matched `createUserProfile`'s shape exactly (`coins: 250`, `totalEarned: 250`, `generationCredits: 1`, starter `ownedIds`). Two real bugs found and fixed during this pass: `StorageException.ErrorUnauthorized` doesn't exist (real name is `ErrorNotAuthorized`), and a missing `using Firebase.Auth;` in `StorageService.cs`. Delete the `_SmokeTest` folder once Phase 2's real screens exist.
3. **Phase 2 — App shell. ✅ DONE and verified (2026-09-21).** You confirmed the full loop live: Splash → Auth (sign in/register/sign out all worked) → Home → "Open a toy (demo)" → Loading (stage label + Finish Loading button both showed correctly) → Toy → Back to Home. `AppStage`/`AppScreen`/`ToyHandle`/`AppStateMachine` (Core, pure logic, no MonoBehaviour/Firebase dependency — mirrors `App.js`'s `splashDone`/`authChecked`/`authUser`/`activeToy`/`loadingToy`/`screen` ternary chain exactly) + `AppRoot` (UI, MonoBehaviour — wires real `AuthService` auth events into the state machine, renders one OnGUI placeholder panel per stage with the same navigation buttons `App.js`'s handlers expose: continue-past-splash, sign in/register, open achievements/store/create, open-a-toy demo → loading → toy, back-to-home, sign out). `AppRoot` lives in `UI` rather than `Core` for the same reason Phase 1's Firestore attributes ended up needing a `Core.asmdef` reference — `Core` can't depend on `Firebase` without a circular reference, since `Firebase` already depends on `Core`. Placeholder screens only (no UI Toolkit yet — that's Phase 5); the goal here was proving navigation works end-to-end, not what it looks like.
4. **Phase 3 — Creature art. ✅ DONE and verified (2026-09-21).** You confirmed live: mood bounce/wobble animates correctly, cycling mood visibly changes the motion (jump/celebrate/etc.), the glow renders and toggles on/off correctly, and all 20 real creatures from the live catalog render correctly with no visual breakage.
   - ~~🔴 pull the live catalog first~~ — done via a Node script signed in with the `reference_headless_testing.md` test account (no Firebase Console access needed). Also surfaced fields `Creature.cs` was missing from Phase 1 (`outline`, `outlineCx/Cy`, `shadowColor`, `trueGlow`, `hasShine`, `starter`, `description`, `visual`) — added them.
   - Rasterization pipeline: a Node/`sharp` script (not an Editor tool — avoids needing you to run anything in-Editor) rendered all 20 creatures × {normal, locked, outline-silhouette} = 60 sprites at 512×512 into `Assets/_Project/Art/Resources/Creatures/`, using each creature's bled viewBox (-16,-16,132,132) so out-of-bounds art (Glorp's antenna, Cosmo's ring, etc.) isn't clipped. Verified visually (Glorp, Noodle, Cosmo all correct). One shared `ShineGradient.png` for the shine-sweep effect.
   - `MoodAnimCatalog`/`MoodAnimator`/`ShineAnimator` (Core, pure logic, no MonoBehaviour/UnityEngine dependency) port `MOOD_ANIM`'s keyframe table and the shine-sweep timing exactly, including the `easeInOutSine`/`easeInQuad` easing curves.
   - `CreatureThumbnailView` (UI, MonoBehaviour) is the `CreatureThumbnail.js` equivalent: loads the rasterized sprites via `Resources.Load`, layers the glow (multiple scaled/tinted copies of the outline sprite) and shine (gradient sprite + `SpriteMask` clipped to the outline) under/over the body sprite, driven every frame by the two Core animators. Known simplification: glow layers scale around this object's own pivot rather than each creature's individual `outlineCx/outlineCy` — identical for ~15 creatures where those equal 50, a few-percent approximation for the rest (ids 6, 10, 14, 17) — revisit only if visually off.
   - Built with plain `SpriteRenderer`s, not UI Toolkit — proving the system works, not the final look (Phase 5 rebuilds this against real screens).
   - Demo harness: `CreatureCatalogDemo.cs` (`_SmokeTest`) cycles through the live catalog with on-screen Prev/Next/mood/locked/glow controls.
5. **Phase 4 — Squish physics. ✅ Core algorithm + procedural rig written and verified live (2026-09-21).** You confirmed the procedural sphere (Glorp's shape) dents on drag, bounces back on release, orbits on right-drag, and blinks — feel confirmed OK.
   - `PhysTuning`/`ModelTuning` (Core) — exact `PHYS`/`MODEL_TUNING` constants from `src/data/creatures.js` and `SquishyToy.js`.
   - `SquishRig` (Core, plain data) + `SquishPhysics` (Core, pure functions) — line-for-line port of `tickPhysics`/`computeDentFall`/`applyDentScale`/`resetDentTargets`/`weldNormals` and the `pointerDown`/`pointerMove`/`orbit`/`endOrbit`/`cancelPoke`/`pointerUp` imperative-handle methods. No MonoBehaviour/Mesh dependency — a view component resolves screen taps to a local Vector3 via its own raycast and applies the per-frame `PosOut`/`FeaturePosOut`/`FeatureScaleOut`/`GroupScale`/`GroupRotation*` outputs to its actual Mesh/Transforms.
   - `UvSphereBuilder` + `SquishRigView` (`Physics/`) — the procedural-sphere half only (matches the RN app's own fallback creature: round eyes + antenna = `DEFAULT_VISUAL`/Glorp's shape, a real code path, not a throwaway test shape). Desktop input stand-in: left-drag = poke, right-drag = orbit (real touch gesture wiring is Phase 5's job).
   - ~~🔴 The GLB-import half is blocked on glTFast~~ — resolved (`com.unity.cloud.gltfast` 6.20.0 added directly to `Packages/manifest.json`, same reliable file-edit approach as the package-identity fix, not the interactive `.unitypackage` flow Firebase needed). `MeshTopology` (Core) ports `buildAdjacency`/`buildWeldGroups` exactly; `ModelSquishRigView` (`Physics/`) loads a real `.glb` via `GltfImport`, does the same recentre/rescale/weld/adjacency prep as `prepareModelData`, and drives it through the *same unchanged* `SquishRig`/`SquishPhysics` as the procedural sphere — only mesh construction differs, exactly as designed. Demo: `ModelSquishDemo.cs`. Known gap: no automatic procedural-sphere fallback on load failure yet (the RN version has one); a failed load just logs and shows nothing.
   - Known simplifications, deliberately deferred rather than solved blind: picking uses a static `SphereCollider` instead of raycasting the live deforming mesh (fine while the dent stays small relative to the sphere); group rotation uses a direct radians→degrees XYZ Euler mapping, which may compose slightly differently than three.js's own rotation order under simultaneous X+Z wobble; feature-position Z sign was flipped from the RN source because this project's test-scene camera faces the opposite direction from `SquishScreen.js`'s (`position: [0, 0.1, 4.6]` vs this scene's `(0, 1, -10)`) — verify these visually, revisit only if something reads as wrong.
   - 🔴 **Open bug, unresolved**: the real GLB creature (unlike the procedural sphere) shows no visible per-vertex dent while pressing — only after releasing/moving away. Deeply investigated (physics values confirmed correct, mesh CPU data confirmed correctly deformed via direct read-back, only one mesh in the .glb, rendering code now unified with the working procedural rig via `SquishRigView.ReplaceWithMesh`) without finding the cause — see **`PHASE4_GLB_SQUISH_DEBUG.md`** (repo root) for the full investigation log and suggested next steps (material isolation test was queued but not confirmed either way). Per your instruction, left for you to test/debug directly rather than continuing to guess blind.
6. **Phase 5 — Screens. ✅ Written 2026-09-21, not yet run.** All 9 screens (Splash, Auth, Home, Loading, SquishScreen chrome, Create, Achievements, Store, Settings-as-overlay) built with real UI Toolkit — **in C#, not hand-authored UXML/USS** (the whole visual tree is constructed via `VisualElement`/`style` calls; same reasoning as avoiding hand-written scene YAML — a markup format I can't visually verify before handing off is a real risk, plain C# object construction isn't, and it's an equally valid, fully-supported way to use UI Toolkit). Real fonts (Baloo 2 + Nunito, exact weights `squadFonts` needs) fetched from Google Fonts' GitHub repo and imported. `SquadColors`/`SquadRadii` (Core) port `squadTheme.js`'s tokens exactly; `UiFactory` (UI) holds shared styled-element builders.
   - **Known, deliberate simplifications** (breadth over unverifiable pixel-perfect depth, given no way to visually iterate): no gradient backgrounds (flat colors instead — squadGradients has no direct USS equivalent without pre-baked gradient textures); Home's swipe-to-page-with-ghost-card-flyoff replaced with prev/next buttons (the paging *logic* — index clamping, tab switching — is ported exactly, just triggered by taps); no shimmer-ring pulse on completed achievements; Create screen's photo-upload path shows a "coming soon" notice (needs a native image-picker plugin not yet integrated) — the assemble-from-parts path is fully wired; `authErrors.js`'s friendly error-message mapping not ported (raw exception messages instead).
   - **Real architectural fix mid-build**: originally planned to rebuild the whole screen tree on every data change; caught before shipping that this would destroy/recreate text fields (losing cursor position/focus) on every keystroke if input callbacks also triggered a rebuild. Fixed by giving each stateful screen a persisted UI-state object (`AuthUiState`/`HomeUiState`/`CreateUiState`, held on `AppRoot`, surviving rebuilds) that input callbacks mutate directly without triggering `Render()` — only real navigation events (tab switches, submits) do.
   - `SquishScreenView` is UI chrome only (back button, coin pill) — a transparent-background overlay on top of the actual 3D toy, which `AppRoot.SpawnActiveToy`/`DestroyActiveToy` manages as a separate GameObject lifecycle alongside the Toy stage (looks up whether the selected creature has a real `ModelUrl` to decide `ModelSquishRigView` vs the procedural `SquishRigView` fallback).
7. **Phase 6 — Economy wiring. ✅ Written alongside Phase 5.** `Achievements.cs` (Economy) ports `computeAchievements` exactly. `AppRoot` exposes `BuyKey`/`UnlockWithKey`/`SaveNickname`/`ClaimAdsFree`/`SubmitFeedback`/`AddCoins`/`RecordPress`/`MarkAchievement`/`DeleteCustomCreature`/`RetryCustomCreature`/`CreateAssembledCreature`, each a direct call into the already-verified Phase 1 `FirestoreService`, called from the screens that need them. Coin-earning on squish (`SquishRigView.OnSquish`/`OnReleased` events, added this phase) matches `SquishScreen.js`'s exact formula — 1 coin every 1.5s while held (`EARN_PER_TICK`/`EARN_TICK_MS`), applied once on release — wired via a coroutine in `AppRoot.WireToyEconomy`. No bonus multipliers yet (tied to the AdMob-gated watch-ad flow, Phase 7).
8. **Phase 7 — Ads.** Not started — blocked on the AdMob Unity SDK import (same one-time package step as Firebase/glTFast), and the ×2/×3/×4 coin-bonus buttons + forced-interstitial placements depend on it directly.
9. **Phase 8 — Platform builds.** 🔴 needs your store accounts (§8.4) to go beyond local/Editor testing.

**Testing note for Phases 5-6**: none of this has been run in the Editor yet — self-reviewed for compile correctness (one real bug already caught and fixed: `SquadRadii.md` should've been `SquadRadii.Md`) but not visually verified. To try it: disable the other test GameObjects in the Hierarchy, drag `AppRoot.cs` onto a fresh GameObject, Play. Expect rough edges — this was a large amount of code written without the ability to see it render.

Each phase ends with you running the build and reporting back what's actually wrong — same iterative loop this whole session used to fix the RN app. Don't expect (or aim for) a phase to be "done" without that check.
