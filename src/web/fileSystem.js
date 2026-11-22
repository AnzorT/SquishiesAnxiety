// Web only: expo-file-system has no files on web. The app's small saved files (settings, the FPS switch, "keep me
// signed in", the creature cache) live in the browser's localStorage under their path instead. Downloads to the
// cache (3D models, card art) aren't kept: downloadAsync fails, and every caller then loads the URL itself.
const PREFIX = 'sqfs:';
export const documentDirectory = 'file:///web-documents/';
export const cacheDirectory = 'file:///web-cache/';
export const bundleDirectory = null;
export const EncodingType = { UTF8: 'utf8', Base64: 'base64' };
export const FileSystemSessionType = { BACKGROUND: 0, FOREGROUND: 1 };

function store() {
  try {
    return window.localStorage;
  } catch (e) {
    return null;
  }
}
const keyOf = (uri) => PREFIX + String(uri);

export async function getInfoAsync(uri) {
  const s = store();
  const v = s ? s.getItem(keyOf(uri)) : null;
  if (v == null) return { exists: false, isDirectory: false, uri };
  return { exists: true, isDirectory: false, uri, size: v.length, modificationTime: Date.now() / 1000 };
}

export async function readAsStringAsync(uri) {
  const s = store();
  const v = s ? s.getItem(keyOf(uri)) : null;
  if (v == null) throw new Error(`File '${uri}' could not be read (web)`);
  return v;
}

export async function writeAsStringAsync(uri, contents) {
  const s = store();
  if (!s) throw new Error('No storage (web)');
  s.setItem(keyOf(uri), String(contents));
}

export async function deleteAsync(uri, options = {}) {
  const s = store();
  if (!s) return;
  if (s.getItem(keyOf(uri)) == null && !options.idempotent) throw new Error(`File '${uri}' doesn't exist (web)`);
  s.removeItem(keyOf(uri));
}

export async function makeDirectoryAsync() {}

export async function readDirectoryAsync(uri) {
  const s = store();
  if (!s) return [];
  const base = keyOf(uri.endsWith('/') ? uri : `${uri}/`);
  const out = [];
  for (let i = 0; i < s.length; i++) {
    const k = s.key(i);
    if (k && k.startsWith(base)) out.push(k.slice(base.length).split('/')[0]);
  }
  return [...new Set(out)];
}

export async function copyAsync({ from, to }) {
  await writeAsStringAsync(to, await readAsStringAsync(from));
}

export async function moveAsync({ from, to }) {
  await copyAsync({ from, to });
  await deleteAsync(from, { idempotent: true });
}

export async function downloadAsync(url) {
  throw new Error(`No file cache on web (${url})`);
}

export function createDownloadResumable(url) {
  return {
    downloadAsync: () => downloadAsync(url),
    pauseAsync: async () => {},
    resumeAsync: () => downloadAsync(url),
    savable: () => ({}),
  };
}

export async function getFreeDiskStorageAsync() {
  return 1e9;
}

export async function getTotalDiskCapacityAsync() {
  return 1e10;
}
