// Node module hooks that load the app's src/audio (and squishHaptics, squishdoku/game.js) as they are, with React
// Native's modules swapped for the recording stand-ins in mocks.mjs:
//   - 'react-native', 'react', 'expo-av', 'expo-file-system', 'expo-haptics' -> mocks.mjs
//   - './effectFiles' (no extension) -> './effectFiles.js'
//   - require('../../assets/audio/<file>') -> '<file>' (Metro's asset id becomes the file's name)
//   - sfx.js also exports its EFFECTS and MUSIC tables (as __EFFECTS, __MUSIC), so the test can read the app's own
// Registered by run.mjs (module.register).
import fs from 'node:fs';
import { fileURLToPath, pathToFileURL } from 'node:url';

const MOCK = new URL('./mocks.mjs', import.meta.url).href;
const MOCKED = new Set(['react-native', 'react', 'expo-av', 'expo-file-system', 'expo-haptics']);

export async function resolve(specifier, context, next) {
  if (MOCKED.has(specifier)) return { url: MOCK + '#' + specifier, shortCircuit: true };
  if ((specifier.startsWith('./') || specifier.startsWith('../')) && context.parentURL && context.parentURL.includes('/src/')) {
    const bare = specifier.split('?')[0];
    if (!/\.[cm]?js$/.test(bare)) {
      const u = new URL(bare + '.js', context.parentURL);
      if (fs.existsSync(fileURLToPath(u))) return { url: u.href, shortCircuit: true };
    }
  }
  return next(specifier, context);
}

export async function load(url, context, next) {
  if (url.startsWith(MOCK)) return { format: 'module', source: fs.readFileSync(fileURLToPath(MOCK.split('#')[0]), 'utf8'), shortCircuit: true };
  if (url.startsWith('file:') && url.includes('/src/') && /\.js(\?|$)/.test(url)) {
    let source = fs.readFileSync(fileURLToPath(url.split('?')[0]), 'utf8');
    source = source.replace(/require\(\s*'\.\.\/(?:\.\.\/)+assets\/audio\/([^']+)'\s*\)/g, (_, f) => JSON.stringify(f));
    if (/\/src\/audio\/sfx\.js(\?|$)/.test(url)) source += '\nexport { EFFECTS as __EFFECTS, MUSIC as __MUSIC };\n';
    return { format: 'module', source, shortCircuit: true };
  }
  return next(url, context);
}

export const self = pathToFileURL(fileURLToPath(import.meta.url)).href;
