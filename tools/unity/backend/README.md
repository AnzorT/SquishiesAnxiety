# Unity backend client: emulator test

`unity/Assets/Scripts/Backend/` is the Unity port's connection to the app's Firebase backend: a small REST client
for Auth, Firestore and callable Cloud Functions. It's plain C# 9 on netstandard2.1, with no packages. This folder
tests it end to end against the **Firebase Local Emulator Suite**, never against the live project:

- the test uses `FirebaseConfig.Emulator("demo-squish")`. A `demo-` project id stops the emulators from reaching
  any real project.
- every request goes through `LocalOnlyHttp` (Program.cs), which throws for any host other than 127.0.0.1 or
  localhost.

## Run

Needs Node 22, Java 11+ and the .NET 8 SDK.

```sh
# 1. emulators (auth 9099, firestore 8080, functions 5001), from a scratch copy of firebase.json,
#    firestore.rules and functions/ (npm ci runs in the copy, not in the repo)
WORK=/tmp/squish-emulators tools/unity/backend/start-emulators.sh      # leave it running

# 2. the test, in another shell
cd tools/unity/backend && dotnet run
TRACE_HTTP=1 dotnet run        # also prints every request
EMULATOR_HOST=10.0.2.2 dotnet run   # emulators on another host
```

The first start downloads firebase-tools (npm) and the Firestore emulator jar into `$WORK`. Later starts reuse
them. The test ends with a pass/fail table and returns exit code 1 if anything failed. It makes fresh accounts on
every run, so it can be re-run without restarting the emulators.

`local-no-proxy.cjs`: behind an HTTPS proxy, firebase-tools ignores `NO_PROXY` and sends its own calls to the local
emulators to the proxy. The functions emulator then fails to register its Firestore triggers ("Unable to parse JSON:
request blocked"). start-emulators.sh preloads this shim, which makes the CLI honour `NO_PROXY`. Without a proxy
it does nothing.

## What it covers

- **codec**: Firestore REST JSON ⇄ `IDictionary<string, object>` / `List<object>` / double / bool / string /
  DateTime (plus bytes, references, geo points). Field-path quoting (``stack.best.`3` ``) and the JSON
  reader/writer.
- **auth**:
  - sign up and sign in
  - error codes mapped to `src/firebase/authErrors.js`'s messages
  - ID token caching, forced refresh, and refresh before expiry
  - the persisted session, and "Keep me signed in" off
  - email verification (through the emulator's oobCodes) and password reset
  - custom-token sign-in (the emulator's unsigned token)
  - sign out
- **firestore**:
  - `createUserProfile`'s fields, read back as the app's map and through `Games/Stack/Levels.Record`
  - the polling profile feed: local apply, refresh after a write, and an outside change at the next poll
  - increment, arrayUnion and arrayRemove, dotted and numeric paths, and the `recordPress` transaction
  - `saveStack` with a real `Levels.AfterLevel` outcome
  - subcollections: add with serverTimestamp, list ordered, merge set with delete, then delete; crib/state;
    feedback
- **functions**: `spinWheel` (prize, then `{ already: true }`, and the profile it changed). Error mapping
  (`squad` with an unknown move gives `invalid-argument`; signed out gives "Not signed in").
- **rules** (`firestore.rules` as deployed): another user's profile and crib are refused. So are server-only
  fields (`gems`, `generationCredits`), a spoofed or read-back `feedback`, and an update to a missing profile.

## Compile check against Unity

The test builds `Backend/**` without `Backend/Unity/` (that folder needs UnityEngine). To check everything against
Unity's own DLLs, build a netstandard2.1 project that references the UnityEngine module DLLs and compiles
`unity/Assets/Scripts/**/*.cs`.
