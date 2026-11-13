// Copies the design's rig scripts, each creature's front SVG and tools/rig/host.html into the Android
// assets, where src/components/RigCreature.js loads them (file:///android_asset/rig/host.html).
// usage: node tools/rig/build.mjs   (re-run after a new design drop is unpacked in tools/design-v6)
import { copyFileSync, mkdirSync, readdirSync, rmSync, existsSync, statSync } from 'node:fs';
import { join, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';

const ROOT = join(dirname(fileURLToPath(import.meta.url)), '..', '..');
const DESIGN = join(ROOT, 'tools', 'design-v6');
const OUT = join(ROOT, 'android', 'app', 'src', 'main', 'assets', 'rig');
const SCRIPTS = ['rive-rig.js', 'rive-generic.js', 'pet-defs.js', 'mittens-moves.js', 'rig-shuffle.js'];

if (!existsSync(join(DESIGN, 'rive-rig.js'))) throw new Error('unpack the design zip into tools/design-v6 first');
rmSync(OUT, { recursive: true, force: true });
mkdirSync(OUT, { recursive: true });
copyFileSync(join(ROOT, 'tools', 'rig', 'host.html'), join(OUT, 'host.html'));
for (const f of SCRIPTS) copyFileSync(join(DESIGN, f), join(OUT, f));

const tripo = join(DESIGN, 'export', 'tripo');
let n = 0, bytes = 0;
for (const key of readdirSync(tripo)) {
  const src = join(tripo, key, key + '-front.svg');
  if (!existsSync(src)) continue;
  mkdirSync(join(OUT, 'export', 'tripo', key), { recursive: true });
  copyFileSync(src, join(OUT, 'export', 'tripo', key, key + '-front.svg'));
  n++; bytes += statSync(src).size;
}
console.log(`rig assets: ${SCRIPTS.length} scripts, ${n} creatures (${(bytes / 1048576).toFixed(1)} MB of SVG) -> ${OUT}`);
