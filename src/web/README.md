# The web version

The whole app runs in a browser, shown inside a phone at the Galaxy A15's size (built 2026-11-14).

## Running it

```
npx expo start
```

Then open **http://localhost:8081** in Chrome, or press **w** in that terminal. `npm run web` does both. The same
Metro serves the Android app and the web version at once.

- On a computer you get a phone frame (Galaxy A15 landscape, 832 x 384 dp) scaled to fit the window. The app runs
  inside it at exactly that size, so it lays out as on the phone.
- Under the frame: **◁ Back** is the phone's back button (so is **Esc**), **Reload** reloads the app, and
  **Full window** opens the app without the frame.
- `?device=412x915` shows another phone size (portrait width x height, in dp).
- On a phone's own browser there is no frame: the app fills the screen.
- A desktop browser is far faster than a phone, so the web version tells you nothing about the A15's frame rate.

Log in with email and password. The Google, Facebook and TikTok buttons don't work on web yet (see below).

## How it works

Nothing in the app's screens changed. The Android-only pieces are swapped for web stand-ins, on web only.
`metro.config.js` swaps them, and the Android bundle doesn't contain them.

| On Android | On web | File |
|---|---|---|
| `@react-native-firebase/*` | Firebase's web SDK, compat API (same calls). Same project and key, read from `google-services.json`. | `firebase/*.js` |
| `react-native-webview` | An `<iframe>` with the same message link (`ReactNativeWebView.postMessage`, `injectJavaScript`, `injectedJavaScriptBeforeContentLoaded`) | `WebView.js` |
| Pages from the APK (`file:///android_asset/...`) | Served by Metro at `/android_asset/` from `android/app/src/main/assets`, with one start line added to each page | `metro.config.js` |
| Google Play Billing | Nothing to buy: buying says the store is unavailable | `src/billing/index.web.js` |
| AdMob (test ads) | Pretend ads: a rewarded ad grants its reward after a moment, as Google's test ads do | `ads.js` |
| `expo-file-system` | The app's small saved files in `localStorage`; downloads aren't cached | `fileSystem.js` |
| Turning the phone | Turns the frame | `orientation.js` |
| `SvgXml` (missing from react-native-svg's web build) | The browser draws the SVG itself | `svg.js` |
| Back button, `Alert` | Esc / the frame's Back button; the browser's alert and confirm dialogs | `setup.js` |
| Firebase Storage files in WebGL and fetch | Fetched through Metro at `/__fbstorage/`, because the bucket sends no CORS headers | `metro.config.js`, `setup.js` |

`App.web.js` is the web entry. Expo imports `./App`, and Metro picks `App.web.js` first on web. It shows the frame
(`PhoneFrame.js`), or inside the frame loads `setup.js` and then the real `App.js`.

The game pages come from `android/app/src/main/assets`. Run `node webgame/build.mjs` (and
`node tools/chest/build.mjs`) after changing them, as for Android.

## Testing helpers (development only)

- **`window.__app`**: in a development build, App.js puts a few of its switches on the page, so a test can open a
  screen or a card without playing up to it. Nothing here spends the account's coins or gems. From the browser
  console (inside the frame, or at `/?phone=1`):
  - `__app.setScreen('road')` opens a screen (`'stats'`, `'road'`, `'settings'`, `'shop'`, `'achievements'`,
    `'squishdoku'`, `'sort'`, `'stack'`, `'hop'`; `'home'` goes back).
  - `__app.setStreakIntro(true)` opens the streak screen.
  - `__app.setSpinState('show')` opens the daily spin. Don't tap SPIN: it spends the day's real spin.
  - `__app.setLevelUp({ level: 12 })` opens the level-up card.
  - `__app.setDailyOpen(true)` opens Daily Challenges.
  - `__app.play()` opens Squish Time with the selected creature.
  - `__app.flashApp('text')` shows a toast.
- **`/?phone=1&preview=1`** (`Preview.js`) shows the games' popups on their own, with made-up numbers, plus the
  email check screen a signed-in test account can't reach. `window.__preview('sd-result')` switches between them;
  `window.__previewNames` lists them. `&card=…` opens one at load.
  - The result cards (`sd-result`, `sd-perfect`, `sort-result`, `stack-result`, `hop-result`) draw their three live
    characters (`src/squishdoku/Trio.js`): `&keys=a,b,c` picks them (`&keys=none`: the stills), `&stars=n` how many
    are earned. In the result page's frame, `resultStage._state()` says who's drawn and what each is doing.
  - Squish Stack and Squish Hop are there whole, played by the bundled cut-outs with no account (nothing is saved and
    ads are free; don't tap a gem save, it calls the server): `stack-forest` (Squish Stack's forest map with a walker:
    tap REGULAR, then `window.__stackWin()` beats the next level), `stack-hub`, `hop-hub`, `stack-blitz`, `hop-blitz`
    (`&top=0`: no best run yet, so the first one is a NEW BEST), `stack-level&lv=5`, `hop-level&lv=8`.
  - **`window.__stack`** (in a Squish Stack level or Blitz): `best()` is the next best move `[r, from, to]`,
    `move(from, to)` lifts the top squishy off cushion `from` and puts it on `to`, `pick(from)` and `drop(to)` do
    the two halves on their own, `state()` gives the phase and where everyone is.
  - Squishdoku whole, the same way: `sd-level&lv=12` (`&head=1`: HEAD START) and `sd-blitz` (`&top=…`), its creatures
    the ones with faces (squishdoku/bodies.js). **`window.__sdk`** plays them: `answer()` is the answer's cells row by
    row, `miss()` a wrong cell, `tap(cell)` taps one, `timeUp()` runs the clock out, `save()` (Blitz) takes the save
    card's free save.
  - `spin`: the Daily Spin with a made-up server (`&i=…`: the slice it lands on; 3, the Mystery Box, by default).
  - `shop`: the sideways Shop with a made-up wallet, to see its tabs slide (`&tab=…`: the tab it opens on). Only switch
    tabs: its buttons call the server.
  - `vault`: *To the treasure vault* on its own (`&ms=…`: when the page counts as painted). `smash`: the real chest
    smash under it, as a Shop chest runs it (the smash up on the tapped chest, a made-up answer after `&ans=…` ms, a
    sibling frozen with Freeze); nothing reaches the server. `window.__smashLog` says when each step happened.
    `&id=33`: the creature it holds (Mittens by default); `&copies=7&need=12`: a copy toward unlocking it (+1 COPY and
    the copies bar on the reveal; the unlocking copy when they're equal).
  - Squish Sort whole: `sort-level&lv=6` and `sort-blitz` (the fridge only since 2026-11-17), played by the bundled
    cast. **`window.__sort`** (in a level or Blitz): `state()` gives the phase, whether the rigs play the deal
    (`rigLive`) and each squishy's home and spot; `drop(k, i)` lets squishy `k` go on spot `i` (`-1`: the tray);
    `grab(k)` / `drag(k, x, y)` pick it up and carry it (the play area's dp); `tap(k)` chooses it or lets go;
    `solve(leave)` puts every squishy home but `leave`.
  - **`window.__hop`** (in a Squish Hop level or Blitz): `sol` is the board's full clear (directions 0 up, 1 right,
    2 down, 3 left), `hop(d)` hops that way, `state()` gives the phase, hops, take-backs and whether a full clear is
    still possible.

## Freeze on the web

The web renders with `createRoot` (concurrent React), the phone in legacy mode. Concurrent React holds a commit back
when a Suspense boundary that's already showing would suspend in an ordinary update, and each new update restarts the
wait; on the web every frame of an `Animated` animation is a React update. So a `Freeze` going to sleep while anything
animated was running elsewhere stopped every commit for good (2026-11-16: *To the treasure vault* stuck part way, over
the Shop frozen under the chest smash). `src/components/freezeSync.web.js` makes the switch to asleep a `flushSync`
update, which React always commits. Anything else built on Suspense needs the same care here.

## The demo build (a link with no account)

`node tools/web/demo.mjs [folder]` builds Squish Stack and Squish Hop on their own (`src/web/Demo.js`), to try from a
static page with no login: e.g. a private claude.ai artifact (`page.html` is the page, everything else its files).

- A start page with the two games, then each game's hub, map, levels and Blitz, as in the app.
- The profile lives in the page (`src/web/demo/store.js` stands in for `src/firebase/firestore.js`, and
  `src/web/demo/api.js` for `src/squad/api.js`: Blitz's gem save spends the page's own gems). It starts with every
  level open and 200 gems; a reload starts over. Nothing reaches Firebase.
- The squishies are two dozen bundled cut-outs (`src/web/demo/cast.js`); ads are the web version's pretend ones.
- `metro.config.js` makes these swaps only when the build runs with `EXPO_PUBLIC_DEMO=1`, which the script sets.
- The script makes every address relative (the page can live in any folder), keeps only the demo's creatures' pictures
  (under the artifact's 511-file limit) and moves the script out of `_expo/` (artifacts reserve names starting with _).
- Serve the folder to try it locally: `python3 -m http.server -d dist-demo`, then open `/index.html`.

## Not done yet

- **Google, Facebook and TikTok sign-in.** The `oauth` function sends the player back to
  `com.plushcrush.app://auth`, which a browser can't open. It needs a web return address: an allowed list of
  origins in `functions/oauth.js`, plus a deploy.
- **Putting it online** (Firebase Hosting, set up 2026-11-16; not deployed yet):
  1. `node tools/web/host.mjs` builds the whole app into `dist/`: the menu's pages, the web version, and the pages the
     app opens from its APK at `dist/android_asset/` with their start line (`src/web/frameHook.js`).
  2. `firebase deploy --only hosting` puts it at https://squishy-app-61445.web.app (`firebase.json` `hosting`).
     Firebase's own `web.app` and `firebaseapp.com` addresses are already allowed to sign in.
  3. Once: let those sites read Storage, for the 3D squishies and the creature art drawn in WebGL (`cors.json`; the
     hosted app goes to Storage directly, only the dev server has the `/__fbstorage/` relay). With the `gcloud` CLI,
     or in the Google Cloud console's Cloud Shell:
     ```
     gcloud storage buckets update gs://squishy-app-61445.firebasestorage.app --cors-file=cors.json
     ```
- **Purchases** can't work in a browser through Google Play.
- `sort-fridges`: Squish Sort's seven fridges side by side at their biggest shelves (`&open=0`: shut; `&m=0…6`: one of
  them; `&w=…`: the area each is laid out in), to look at the drawing (src/sort/Container.js).
