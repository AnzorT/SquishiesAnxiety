// Preloaded into the firebase CLI by start-emulators.sh (NODE_OPTIONS=--require).
//
// firebase-tools' HTTP client (lib/apiv2.js) sends every request through HTTPS_PROXY when it's set and ignores
// NO_PROXY, so behind a proxy even its calls to the local emulators (e.g. the functions emulator registering
// Firestore triggers at 127.0.0.1:8080) go to the proxy and fail. This swaps its undici ProxyAgent for undici's
// EnvHttpProxyAgent, which reads the same HTTPS_PROXY but honours NO_PROXY (localhost / 127.0.0.1 go direct).
// Nothing else changes: outside traffic still goes through the proxy.
'use strict';
const path = require('path');
if (process.env.HTTPS_PROXY || process.env.https_proxy) {
  try {
    const cli = require.resolve('firebase-tools/package.json', { paths: [process.env.FIREBASE_TOOLS_DIR || process.cwd()] });
    const undici = require(require.resolve('undici', { paths: [path.dirname(cli)] }));
    if (undici.EnvHttpProxyAgent) {
      undici.ProxyAgent = class extends undici.EnvHttpProxyAgent {
        constructor() {
          super();
        }
      };
    }
  } catch (e) {
    // not the CLI (e.g. a functions worker that can't see firebase-tools): nothing to patch
  }
}
