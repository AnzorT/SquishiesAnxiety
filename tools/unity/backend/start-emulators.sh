#!/usr/bin/env bash
# Starts the Firebase Local Emulator Suite (auth, firestore, functions) for the Unity backend client's tests, from a
# throwaway copy of the repo's firebase.json, firestore.rules and functions/ (so `npm ci` never touches the repo).
#
# The project id is demo-squish: a `demo-` id makes the emulators refuse to talk to any real Firebase project.
#
#   WORK=/some/scratch/dir tools/unity/backend/start-emulators.sh
#
# WORK holds firebase-tools (node_modules), the emulator jars (FIREBASE_EMULATORS_PATH) and the project copy.
set -euo pipefail
REPO="$(cd "$(dirname "$0")/../../.." && pwd)"
WORK="${WORK:-${TMPDIR:-/tmp}/squish-emulators}"
PROJ="$WORK/proj"
mkdir -p "$WORK" "$PROJ/functions"

if [ ! -x "$WORK/node_modules/.bin/firebase" ]; then
  (cd "$WORK" && { [ -f package.json ] || npm init -y >/dev/null; } && npm i firebase-tools)
fi

cp "$REPO/firestore.rules" "$REPO/storage.rules" "$PROJ/"
cp "$REPO"/functions/*.js "$REPO/functions/package.json" "$REPO/functions/package-lock.json" "$PROJ/functions/"
cp -r "$REPO/functions/apple" "$PROJ/functions/"
if [ ! -d "$PROJ/functions/node_modules" ] || [ "$REPO/functions/package-lock.json" -nt "$PROJ/functions/node_modules" ]; then
  (cd "$PROJ/functions" && npm ci)
fi

# The repo's firebase.json plus an emulators block (default ports, no UI).
node -e '
  const fs = require("fs");
  const cfg = JSON.parse(fs.readFileSync(process.argv[1], "utf8"));
  cfg.emulators = {
    auth: { host: "127.0.0.1", port: 9099 },
    firestore: { host: "127.0.0.1", port: 8080 },
    functions: { host: "127.0.0.1", port: 5001 },
    ui: { enabled: false },
    singleProjectMode: true,
  };
  fs.writeFileSync(process.argv[2], JSON.stringify(cfg, null, 2));
' "$REPO/firebase.json" "$PROJ/firebase.json"

export FIREBASE_EMULATORS_PATH="$WORK/emulators"
# behind an HTTPS proxy, keep the CLI's calls to the local emulators off the proxy (see local-no-proxy.cjs)
export FIREBASE_TOOLS_DIR="$WORK"
export NODE_OPTIONS="${NODE_OPTIONS:-} --require $REPO/tools/unity/backend/local-no-proxy.cjs"
cd "$PROJ"
exec "$WORK/node_modules/.bin/firebase" emulators:start --only auth,firestore,functions --project demo-squish
