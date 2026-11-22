# Squish Squad → Unity

Status **2026-11-22**: the Main Menu is ported (first pass) in `unity/`. It hasn't run in a real Unity yet: the runtime
scripts compile against Unity's libraries, and the rest (editor scripts, rendering) is checked by the first CI run once
the Unity license secrets are in (`unity/README.md`).

This replaces the plan of 2026-09-20 (PlushCrush, phases 0-6). That work was for the app as it was then. Its Unity
project was never committed here, and the app has been redesigned four times since (v6 → v9, the Nov 13 design). If
that project is still on your PC, its Firebase wrappers and the squish physics port may still be useful for steps 3 and 7.

## Why Unity, and how the look stays the same

The app is slow because of what it's made of, not its code: React Native views, WebViews running the designer's
prototype (the menu, the house, the chests), and creature rigs that rewrite their SVG shapes every frame. Unity draws
ready-made pictures on the GPU, which costs almost nothing.

**Copy, don't redraw.** Nothing is drawn again by hand. Every picture comes out of the current app's own code: a tool
opens the app's screen in headless Chromium at the reference phone's size and pixel density (Galaxy A15: 832 x 384 dp
= 2340 x 1080 px), freezes the clock, and cuts each piece out on the page's own pixel grid. Unity only places and moves
them. The rules (game logic, economy, Firebase calls) are ported to C#.

**Checked by pixels.** Every screen gets a reference screenshot from the app, and CI renders the Unity screen at the
same size and diffs the two (`tools/unity/compare.mjs`), the same method as the Round 10 pixel-diff of the menu.
Feel and speed are checked on the phone.

## Order

1. **Main Menu.** ✅ First pass (below).
2. **Creature animations** (`rive-rig.js`, `rive-generic.js`, the defs, the move and family files: ~2.3 MB of JS,
   3,934 states, 821k keyframes). The single biggest piece, and every screen with a live creature needs it (menu,
   house, Characters, Squad, game buddies). Each frame, the rig rebuilds every part's outline as Bézier paths from
   warp functions, generated ears, limbs and tails, and per-frame props and particles. It's deterministic: with a
   fixed clock and seeded randomness it produces the same frames every time.
   - **Approach: keep the original animation code, replace the browser.** Rewriting 2.3 MB of animation code in C#
     would take months and drift from the original in small ways. Instead, the rig code runs unchanged in a JS engine
     inside Unity, on a small stand-in for the browser (`tools/unity/rig/dom-shim.js`: SVG element tree, the selectors
     it uses, innerHTML, getBBox, a canvas for the fabric grain, fetch), driven by a host clock
     (`tools/unity/rig/virtual-clock.js`). Unity reads the element tree each frame and draws it on the GPU. What made
     the WebView slow is gone: style and layout, re-rasterising SVG with filters, and compositing.
   - ✅ **Proven on all 118 creatures:** `node tools/unity/rig/parity.mjs` runs each creature in Chrome and on the
     stand-in through idle, dance, hop, squish, wave and happy, compares the whole SVG tree every 15 frames, and
     draws any snapshot that differs as text both ways to compare pixels. Over 300 frames each:
     - 110 identical in every snapshot
     - 7 identical to the eye, at most 12 pixels of 475x475 apart: Sea Turtle, Marina, Jinni, Cuppy, Sugarplum, Toco, Shelly
     - 1 visibly different, Puff, and only in its first snapshot, before the first frame (68 px). It's identical from the first frame on.

     The to-the-eye differences are the JS engines' last bits: Node's V8 is not Chrome's V8, and the phone's isn't
     either.
   - Matching Chrome needed its exact geometry rules, because the rigs size parts from `getBBox`:
     - a box is an SVGRect whose numbers are prototype getters, so `Object.assign({}, box)` copies nothing. In the
       app this makes the shadow width NaN for some creatures, e.g. Kiko: kept, so Unity matches the app, and fixable
       later in one place.
     - 32-bit floats throughout
     - quadratic curves kept as quadratics, arcs as Skia's conics
     - transformed children mapped by their corners
     - gfx::RectF's grow-to-contain rule

     `bbox-fuzz.mjs` checks this against Chrome on random paths: ~83 % to the bit. The rest are rotated or tiny arcs,
     where even phones differ.
   - Cost: one creature frame takes 2-5 ms in Node's V8 on this machine (Mittens 2.2, Biscuit 3.0, Lumi 2.2, Ember
     5.2), so maybe 5-12 ms on the A15. The stand-in is ~2 % of that. The rig's own maths is ~70 % (the `glob` warp,
     `clamp`, `r2` rounding, `toD` path building), and the WebView pays it today too, plus all its drawing. One
     creature on the menu fits a frame. A house full of them will need the hottest render functions ported to C#,
     checked against the JS by the same parity test.
   - **Drawing it** (`unity/Assets/Scripts/Vector/`, plain C#, no Unity dependency): each frame's SVG is parsed and
     compiled into shapes and layers:
     - shapes: polygons plus a fill rule, to be filled on the GPU by stencil-then-cover, so there's no triangulation
     - strokes: joins and caps as pieces, unioned in the stencil
     - paint: gradients (objectBoundingBox or user space, focal radials, `hsl()` stops)
     - layers: clip paths, masks, group opacity and filters (the SVG spec's own `feTurbulence` grain and fuzz,
       colour matrix, displacement, blur)
   - ✅ **Checked against Chrome:** `tools/unity/vector-test` draws the compiled frames with a reference rasteriser
     that fills shapes the way the GPU stencil will, and compares them with Chrome's pictures of the same frames
     (`tools/unity/rig/dump-frames.mjs`). Over 30 frames of Mittens, Biscuit, Lumi, Zappi, Ember and Bubbly at 475 px:
     - on average 299 pixels of 225,625 differ visibly (0.13 %), the worst frame 750, all of it anti-aliasing and
       grain sampling
     - mean difference 0.5-2.2 levels of 255
     - compiling a frame takes 4.1 ms on this machine (it was 52 ms when shapes were triangulated)
   - **GPU side written** (`Assets/Scripts/Vector/Gpu/VectorRenderer.cs`, shaders in `Assets/Resources/VectorShaders/`):
     - one RenderTexture per creature (4x MSAA, stencil), stencil fans and cover quads in a CommandBuffer
     - gradients from a ramp texture, layers in temporary targets
     - filters as passes; the noise is computed once into a texture
     It compiles against Unity's libraries; the first CI run with a license is its first real test.
   - **The menu's Mittens is animated** (`Assets/Scripts/Creatures/`): `CreatureView` draws a frame each tick.
     - Until the JS engine is in, the frames are 8 s of Mittens' idle, recorded from the rig code by
       `tools/unity/rig/record.mjs` (240 frames, 785 KB) and looped.
     - Recorded frames through the renderer core vs Chrome: ~200 px visibly different of 225,625, mean 0.5 levels.
   - Next:
     - the JS engine in Unity: PuerTS with V8 on Android (it has a JIT, like the WebView's own engine). Its package
       comes from openupm, which CI can reach but this session can't
     - Hand the tree to C# without re-parsing text, then profile on the phone and port hot spots to C#.
3. **App shell + Firebase**: sign-in, profile, roster and config, so coins, gems, level, name and creature are real.
   The backend doesn't change.
4. **The menu's pages** (`webgame/app/menu.js`): PLAY → Game Park carousel with the game clips, CHARACTERS, the Level Pass.
5. **The house** (Squad House v6, 94 scripts): each furniture piece and room exported as pictures by the same method,
   with the room and placement logic ported.
6. **Shop, chests, chest smash.**
7. **Games**: Squishdoku, Sort, Stack and Hop (their engines are plain JS with tests; port the tests too), and the
   squish stage (the three.js dent shader becomes a Unity shader).
8. **Everything else**: achievements, level road, streak, daily spin, settings, sign-in screens, ads, billing, sounds.

Each step ends with CI screenshots matching the app and you checking it on the phone.

## The Main Menu (step 1)

- `tools/unity/export-menu.mjs` exports:
  - the house picture for all 30 levels x 3 seasons
  - the weather layers
  - the HUD pieces
  - the crest's and PLAY's flourishes, frame by frame
  - `menu.json`, which says where everything goes
- `unity/Assets/Scripts/Menu/MenuView.cs` lays the menu out. On the A15 every picture lands at scale 1 on whole
  pixels. On other screens it follows the web page's rules: the house fills the screen bottom-aligned, the creature
  moves with it, and the HUD keeps its dp size and holds to its screen edge.
  - Rain loops every 0.225 s, snow every 3.5 s, birds fly their paths.
  - Every 5.2 s the crest flaps, and 1.3 s later PLAY glints.
  - PLAY moves down 3 dp while pressed, and the crest shrinks to 0.92.
- Export check: rebuilding the menu from the exported pieces matches the app's screenshot. The HUD, name plate and
  creature are pixel-identical. 1 % of pixels differ, all of it JPEG noise on the house's edges and the rain sitting
  under a pixel off (it moves anyway).

Known gaps:
- The creature is its still picture with a placeholder breath (step 2).
- Coins, gems, name and level are the exported ones (100, 600, Mittens, level 1) until Firebase (step 3). The dev panel
  switches level and season.
- Taps only show a note.
- The flourish frames are whole pictures (~34 MB of texture memory). Split them into moving parts.

## Decisions made (say if you want any changed)

- **Unity 6000.3.0f1**, the version installed in September. Built-in render pipeline.
- **Gamma colour space**, because the browser blends in sRGB. In Linear, every shadow and soft edge would come out different.
- **App id `com.plushcrush.unity`** while both apps exist, so they install side by side. For Firebase, either add an
  Android app with this id in the Firebase console, or switch to `com.plushcrush.app` when Unity replaces the current app.
- **Sprites and a pixel camera, not uGUI**, for screens made of exported pictures. uGUI or UI Toolkit can come in for
  scrolling lists and text input where they're needed.
- **House pictures as JPEG bytes** (q95, full-res colour, ~560 KB each, 51 MB for all 90), decoded when shown. As
  textures, Unity would ship them at ~9 MB each. Follow-up: ship the first levels and download the rest from Firebase
  Storage on demand.
- **Screen scaling**: the HUD keeps its dp size, taking the phone's height as 384 dp, which is exact on the A15.
  Revisit with the phone's real density if other phones look off.
