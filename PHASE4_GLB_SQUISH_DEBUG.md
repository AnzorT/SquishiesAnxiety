# Phase 4 GLB squish bug — investigation notes (2026-09-21, unresolved)

## Symptom

The procedural-sphere squish rig (`SquishRigView`, drag-and-drop demo) works correctly and is user-confirmed: dragging visibly dents the body inward with jelly-wave spread, releasing bounces/wobbles back, right-drag orbits, eyes blink.

The **real premade creature loaded from Storage via glTFast** (Glorp, id `0`, `.glb`, 662 verts, 203 weld groups) does not show any visible localized dent while pressing/holding, even with the dent floor exaggerated to an 85% pull (`ModelTuning.DentFloor` temporarily set to `0.15`, normally `0.72`). The only visible change happens *after* releasing or moving the mouse away from the model (the release wobble/bounce, or the dent relaxing back — motion is visible even though the held pose wasn't).

## What's confirmed, with evidence (not just ruled out by reasoning)

1. **The physics simulation is computing correctly.** A live diagnostic (`SquishRigView.DebugInfo` / former `ModelSquishRigView.DebugInfo`) read directly from the Editor log during a 18-second hold showed `maxDentAmt` and `maxDentTarget` climbing correctly into the 7+ range (matching the exaggerated `DentStrength`/`DentFloor`), `mode=Poke` held the whole time.
2. **The deformed vertex position reaches the actual Mesh object.** Added a diagnostic that reads `mesh.vertices` back *after* `SetVertices` and compares it to what the physics computed (`rig.PosOut`) for the single worst-dented vertex. Result: `base-vs-rigPosOut diff=0.8792` (a real, large computed displacement) but `rigPosOut-vs-meshActual diff=0.0000` — the mesh's CPU-side data is byte-for-byte what the physics produced. This rules out any bug in the physics math or in the `SetVertices` call itself.
3. **Only one mesh exists in this .glb.** Explicitly logged `GetComponentsInChildren<MeshFilter>()` and `GetComponentsInChildren<SkinnedMeshRenderer>()` counts: 1 MeshFilter (662v), 0 SkinnedMeshRenderers. Ruled out "editing the wrong mesh while a different one renders."
4. **Not a stale-play-mode/domain-reload artifact.** One test run did show a real `NullReferenceException` spamming every frame from `SquishPhysics.Tick`, traced to `_rig` being null despite the `_ready` guard — consistent with recompiling while Play mode was left running. A clean stop-Play → recompile → Play-fresh cycle eliminated that exception, but the core "no visible dent while pressing" symptom persisted unchanged in the following clean run.
5. **Not a difference in the update/render code path.** Refactored so the real creature is driven by the *exact same* `SquishRigView` component (same `Update`/`ApplyFrame`/`HandleInput`/`TryPickLocal`) that's confirmed working on the procedural sphere — added `SquishRigView.ReplaceWithMesh(...)` so a loader (`ModelSquishRigView`, now just a thin glTFast-loading shim) can swap in real mesh data instead of the procedural sphere, then everything downstream is byte-for-byte identical code. Symptom persisted unchanged.
6. **Not the "reuse glTFast's own renderer" theory.** Tried building a completely fresh `MeshFilter`+`MeshRenderer` from scratch (mirroring the working sphere) instead of reusing/replacing glTFast's instantiated renderer. Symptom persisted unchanged (this is now moot since point 5 superseded it, but recorded for completeness).

## What's not yet conclusively tested

- **Material/shader as the cause.** A diagnostic swap to a plain `Standard`-shader red material (instead of the real glTF-imported material/texture) was queued but not confirmed either way before the session moved on. **Left in the code as of this writing**: `ModelSquishRigView.cs` currently uses a temporary `diagMaterial` (plain red `Standard` material) instead of the real `sourceMaterial` — this needs to be resolved (confirm/deny, then revert to `sourceMaterial`) as the next concrete step.
- Whether this is specific to *this* creature's mesh (topology, UV layout, degenerate triangles from the low-poly Tripo export) vs. GLB-loaded meshes in general — never tested against a second creature.
- Whether the adjacency-based diffusion path (`SquishRig.Neighbors != null` branch in `SquishPhysics.Tick`) has a subtle bug that happens not to show up in the specific vertex read back in point 2 above (that diagnostic only checked the single worst-dented vertex, not the whole mesh's visual silhouette/normals).
- Camera framing / whether the touch point is actually landing where the user expects on this specific mesh's silhouette (never got a direct screenshot of the model mid-press to visually confirm).

## Known temporary/diagnostic state left in the code — clean up before trusting this again

- `Assets/_Project/Scripts/Core/Physics/PhysTuning.cs`: `ModelTuning.DentFloor` is `0.15f` (diagnostic exaggeration). **Real value is `0.72f`.**
- `Assets/_Project/Scripts/Physics/ModelSquishRigView.cs`: passes a temporary plain red `diagMaterial` instead of the real `sourceMaterial` into `SquishRigView.ReplaceWithMesh(...)`.
- The Unity scene (`test1.unity`) likely still has a stray, disabled/broken `ModelSquishRigView` GameObject with an empty `ModelUrl` (logs `ModelSquishRigView: ModelUrl not set.` harmlessly every Play session — it never builds any visible geometry since `Start()` returns before reaching that code, but it's clutter worth deleting).

## Suggested next steps, when resumed

1. Confirm/deny the material theory first (cheapest remaining test, already wired up — just needs someone to actually look at the result).
2. If material isn't it: temporarily disable the diffusion step in `SquishPhysics.Tick` (comment out the `if (rig.Neighbors != null) {...} else {...}` block) and retest — isolates diffusion from the base per-vertex spring.
3. If still nothing: get an actual screenshot of the Game view *during* a hold (not after) to visually confirm what's rendering, rather than continuing to reason from verbal descriptions.
4. Consider testing against a second premade creature's `.glb` to see if this is creature-specific (mesh topology/UVs) or systemic.
