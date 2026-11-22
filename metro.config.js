const { getDefaultConfig } = require('expo/metro-config');

const config = getDefaultConfig(__dirname);
config.transformer.unstable_allowRequireContext = true;
// Developer mode (src/webDebug.js): EXPO_PUBLIC_DEV_MODE is inlined into the code at build time, but Metro's
// transform cache doesn't know about it, so a build with the switch could reuse files cached by one without it (or
// the reverse). Custom transformer keys go into the cache key, so flipping the switch re-transforms.
config.transformer.squishDevMode = process.env.EXPO_PUBLIC_DEV_MODE || '';
// Not in Metro's default asset list — needed so require('./glorp_3d.glb')
// bundles as a binary asset (resolved via expo-asset) instead of Metro
// trying to parse it as source. See SquishyToy.js's Glorp build path.
config.resolver.assetExts.push('glb', 'gltf');
// The v3 sounds and music (assets/audio/sfx, assets/audio/music) are Ogg.
config.resolver.assetExts.push('ogg');
// Build output and generated copies the JS never imports (2026-11-14): Metro watched them, and after a gradle build
// (android/app/build: ~1.4 GB, thousands of files written and deleted) or a webgame / chest rebuild it spent minutes at
// ~2 CPU cores working through the file events, slowing the emulator next to it. The game pages are read by the
// WebViews from the APK's assets (file:///android_asset), not through Metro.
const sep = '[\\\\/]';
// (the drive letter either way: Windows hands out the same folder as c:\ and C:\; no 'i' flag, Metro can't combine
//  patterns whose flags differ from Expo's own)
const root = __dirname
  .replace(/[\\/]/g, sep)
  .replace(/[.()+^$|{}]/g, '\\$&')
  .replace(/^([a-zA-Z]):/, (m, d) => '[' + d.toLowerCase() + d.toUpperCase() + ']:');
config.resolver.blockList = [].concat(
  config.resolver.blockList || [],
  ['android/app/build', 'android/build', 'android/.gradle', 'android/app/.cxx', 'android/app/src/main/assets', 'webgame/test/out', 'webgame/.cache']
    .map((d) => new RegExp('^' + root + sep + d.replace(/\./g, '\\.').replace(/\//g, sep) + sep + '.*')),
);

// ---- The web version (npm run web; src/web/README.md) ----
// The Android-only modules are swapped for web stand-ins, on web only (Android and iOS never see src/web/).
const path = require('path');
const fs = require('fs');
const WEB_SWAPS = {
  '@react-native-firebase/app': 'src/web/firebase/app.js',
  '@react-native-firebase/auth': 'src/web/firebase/auth.js',
  '@react-native-firebase/firestore': 'src/web/firebase/firestore.js',
  'react-native-google-mobile-ads': 'src/web/ads.js',
  'react-native-webview': 'src/web/WebView.js',
  'expo-file-system': 'src/web/fileSystem.js',
  'expo-screen-orientation': 'src/web/orientation.js',
  'react-native-svg': 'src/web/svg.js', // (adds SvgXml, which its web build lacks)
};
// The web demo (src/web/Demo.js, tools/web/demo.mjs): a build with EXPO_PUBLIC_DEMO=1 opens Squish Stack and Squish
// Hop on their own with no account. The app's root, its saves and its server moves are swapped for the demo's, which
// keep the profile in the page. Other builds never see these files.
const DEMO = process.env.EXPO_PUBLIC_DEMO === '1';
const DEMO_SWAPS = { 'App.js': 'src/web/Demo.js', 'src/firebase/firestore.js': 'src/web/demo/store.js', 'src/squad/api.js': 'src/web/demo/api.js' };
config.resolver.resolveRequest = (context, name, platform) => {
  if (platform === 'web' && WEB_SWAPS[name]) return { type: 'sourceFile', filePath: path.join(__dirname, WEB_SWAPS[name]) };
  const found = context.resolveRequest(context, name, platform);
  if (DEMO && platform === 'web' && found && found.type === 'sourceFile') {
    const rel = path.relative(__dirname, found.filePath).split(path.sep).join('/');
    if (DEMO_SWAPS[rel]) return { type: 'sourceFile', filePath: path.join(__dirname, DEMO_SWAPS[rel]) };
  }
  return found;
};
// The game pages the Android app opens from its APK (file:///android_asset/...) are served from the same folder at
// /android_asset/ (the web WebView, src/web/WebView.js, opens them in a frame). Every page gets one line first in its
// <head> that hands the frame to the app before the page's own scripts run (window.ReactNativeWebView, and the
// WebView's injectedJavaScriptBeforeContentLoaded).
const ASSETS = path.join(__dirname, 'android', 'app', 'src', 'main', 'assets');
const MIME = {
  '.html': 'text/html; charset=utf-8', '.js': 'text/javascript; charset=utf-8', '.mjs': 'text/javascript; charset=utf-8',
  '.css': 'text/css; charset=utf-8', '.json': 'application/json', '.svg': 'image/svg+xml', '.png': 'image/png',
  '.jpg': 'image/jpeg', '.jpeg': 'image/jpeg', '.webp': 'image/webp', '.gif': 'image/gif', '.mp3': 'audio/mpeg',
  '.ogg': 'audio/ogg', '.wav': 'audio/wav', '.m4a': 'audio/mp4', '.mp4': 'video/mp4', '.webm': 'video/webm',
  '.woff': 'font/woff', '.woff2': 'font/woff2', '.ttf': 'font/ttf', '.otf': 'font/otf', '.glb': 'model/gltf-binary',
  '.riv': 'application/octet-stream', '.wasm': 'application/wasm', '.txt': 'text/plain; charset=utf-8',
};
const FRAME_HOOK = require('./src/web/frameHook.js');
function serveAsset(req, res, next) {
  if (!req.url.startsWith('/android_asset/')) return next();
  let rel;
  try {
    rel = decodeURIComponent(req.url.split(/[?#]/)[0].slice('/android_asset/'.length));
  } catch (e) {
    res.statusCode = 400;
    return res.end();
  }
  const file = path.normalize(path.join(ASSETS, rel));
  if (!file.startsWith(ASSETS + path.sep)) {
    res.statusCode = 403;
    return res.end();
  }
  fs.stat(file, (err, st) => {
    if (err || !st.isFile()) {
      res.statusCode = 404;
      return res.end('Not found: ' + rel);
    }
    const ext = path.extname(file).toLowerCase();
    res.setHeader('Content-Type', MIME[ext] || 'application/octet-stream');
    res.setHeader('Cache-Control', 'no-cache');
    if (ext !== '.html') {
      res.setHeader('Content-Length', st.size);
      return fs.createReadStream(file).pipe(res);
    }
    fs.readFile(file, 'utf8', (e2, html) => {
      if (e2) {
        res.statusCode = 500;
        return res.end();
      }
      const m = /<head[^>]*>/i.exec(html);
      res.end(m ? html.slice(0, m.index + m[0].length) + FRAME_HOOK + html.slice(m.index + m[0].length) : FRAME_HOOK + html);
    });
  });
}
// Firebase Storage files (creature art, 3D models) through this server, for the web version's WebGL and fetch: the
// bucket sends no CORS headers, and a browser won't hand a WebGL texture or a fetch another site's file without
// them. src/web/setup.js sends those requests to /__fbstorage/... (a plain <img> still goes straight to Storage).
// Hosting the web version elsewhere needs the bucket's CORS set instead (src/web/README.md).
const https = require('https');
function proxyStorage(req, res, next) {
  if (!req.url.startsWith('/__fbstorage/')) return next();
  if (req.method === 'OPTIONS') {
    res.writeHead(204, { 'Access-Control-Allow-Origin': '*', 'Access-Control-Allow-Methods': 'GET', 'Access-Control-Allow-Headers': '*' });
    return res.end();
  }
  if (req.method !== 'GET') {
    res.statusCode = 405;
    return res.end();
  }
  const up = https.get('https://firebasestorage.googleapis.com/' + req.url.slice('/__fbstorage/'.length), (r) => {
    const h = { 'Access-Control-Allow-Origin': '*', 'Cache-Control': r.headers['cache-control'] || 'public, max-age=3600' };
    ['content-type', 'content-length', 'etag', 'last-modified'].forEach((k) => r.headers[k] && (h[k] = r.headers[k]));
    res.writeHead(r.statusCode || 502, h);
    r.pipe(res);
  });
  up.on('error', (e) => {
    res.statusCode = 502;
    res.end(String(e.message));
  });
}
config.server = config.server || {};
const enhance = config.server.enhanceMiddleware;
config.server.enhanceMiddleware = (middleware, server) => {
  const inner = enhance ? enhance(middleware, server) : middleware;
  return (req, res, next) => serveAsset(req, res, () => proxyStorage(req, res, () => inner(req, res, next)));
};

module.exports = config;
