# Tripo image-to-3D — status & setup

Tracks the "upload a photo → Tripo → 3D squishy" feature (the creator flow).
Code is written and committed; **not yet deployed**. This file is the
checklist for picking it back up.

## What's built

**Client**
- `src/screens/CreateScreen.js` — name, upload a photo (or assemble a 2D
  creature from parts, no Tripo needed), optional squish sound. On submit,
  uploads the resized photo to Storage and writes a `pending` job doc.
- `src/firebase/storage.js` — `uploadSourceImage`, `deleteCustomAssets`.
- `src/firebase/firestore.js` — `addCustomCreature`, `subscribeToCustomCreatures`,
  `retryCustomCreature`, `deleteCustomCreature`.
- `src/components/CustomCards.js` — the MY CREATURES card. Shows the source
  photo under a scan-line + live `GENERATING 3D · N%` while a job runs,
  `RETRY →` on failure/capacity, plays once `ready`.
- `src/components/SquishyToy.js` — `loadGltfFromUrl` downloads + caches a
  custom `.glb` (via `expo-file-system`) and runs it through the **same**
  `buildModelCreature` / `tickPhysics` soft-body physics as the built-in 3D
  creatures (Glorp, Spike, …). Nothing is baked into the file — the physics
  is generic to any triangle-mesh GLB.
- `src/screens/SquishScreen.js` — routes a `ready` custom creature to the 3D
  `<Canvas>` stage; a custom squish sound plays from its base64 data URL.

**Server** — `functions/index.js` (Firebase Cloud Functions, Node 20)
- `generateCustomModel` — Firestore-triggered on
  `users/{uid}/customCreatures/{id}`. On a fresh `status: 'pending'` doc: creates
  a Tripo `image_to_model` task, polls it to completion, downloads the GLB,
  uploads it to Storage (`customModels/{uid}/{id}.glb`), patches the doc to
  `status: 'ready'` with `modelUrl`. Has a per-user daily generation cap (10/24h).
- `checkTripoBalance` — scheduled, hourly. Reads Tripo's real credit balance,
  writes it to `system/tripoStatus`, logs a warning when it's getting low.
  `generateCustomModel` checks that cached balance before spending anything —
  too low, or Tripo's own "insufficient credit" response — and the job
  becomes `status: 'capacity'` ("you have not been charged") instead of a
  bare failure.

**Rules / config**
- `firestore.rules` — `users/{uid}/customCreatures/**` (owner-only).
- `storage.rules` — `customUploads/{uid}/**` (owner read/write, ≤8MB images
  only), `customModels/{uid}/**` (owner read; write is function-only).
- `firebase.json` — wires the `functions` and `storage` sections in.
- New deps: `@react-native-firebase/storage`, `expo-file-system`,
  `expo-image-picker`, `expo-image-manipulator`, `expo-document-picker`.

## What we learned about Tripo along the way

- The API key is **separate from any tripo3d.ai web/consumer subscription** —
  it draws from its own credit balance.
- Billing is **prepaid** ("pay-before-you-go", Tripo's own term) — no
  auto-recharge, no card-on-file for automatic overage. Confirmed against the
  live API: a task call with 0 balance fails immediately
  (`code 2010: "You don't have enough credit to create this task"`) rather
  than succeeding and billing later.
- Two different API hosts, both verified live:
  - Task create/poll: `https://api.tripo3d.ai/v2/openapi/task[/{id}]`
  - Account balance: `https://openapi.tripo3d.ai/v3/account/balance`
- Rough cost: `image_to_model` with texture+pbr runs **~30–60 credits**
  (**~$0.30–0.60**) per generation on Tripo's own pricing table.
  New keys may include a small free trial allotment (worth checking — ours
  showed a 0 balance).

## Outstanding — needs you, not code

1. **Rotate the Tripo API key.** The original one was pasted into a chat
   session, so treat it as burned. Tripo dashboard → API Keys → revoke →
   generate a new one.
2. **Set it as a Firebase secret** (never in a file, never in chat):
   ```bash
   firebase functions:secrets:set TRIPO_API_KEY
   ```
3. **Top up a small Tripo balance** when ready to see a real generated
   model (not required just to deploy/test the plumbing — with $0 balance
   the flow correctly ends at the `capacity` state instead of a real model).
4. **Deploy:**
   ```bash
   cd functions && npm install   # already done once; re-run if deps change
   firebase deploy --only functions,firestore:rules,storage
   ```
5. **Rebuild the dev client** (new native modules): `npx expo run:android`.
6. **Optional:** wire a Cloud Logging alert on `checkTripoBalance`'s "Tripo
   balance low" error log so you get pinged before the wallet hits 0.

## Longer-term (discussed, not built)

- **Charge before generating** (real IAP via Play Billing / App Store,
  ideally through RevenueCat) so a Tripo call only ever happens against
  revenue already collected — the `$4.99` price on the create screen is
  currently cosmetic.
- **Reconciliation job** — a scheduled function that finds any verified
  purchase with no completed/refunded job and fixes it, so a paid user can
  never end up with nothing.
- If Tripo's own concurrency limits become the bottleneck at scale, a thin
  Cloud Tasks buffer in front of `generateCustomModel` to smooth bursts.
