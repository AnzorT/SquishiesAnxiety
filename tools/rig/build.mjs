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
// Squish Hop's characters (src/hop/RigStage.js): every rig on the board in one page
copyFileSync(join(ROOT, 'tools', 'rig', 'hop.html'), join(OUT, 'hop.html'));
// Squish Sort's squishies (src/sort/Game.js, through the same RigStage): every one in play in one page
copyFileSync(join(ROOT, 'tools', 'rig', 'sort.html'), join(OUT, 'sort.html'));
// every mini-game's result card: its three characters (src/squishdoku/Trio.js, through the same RigStage)
copyFileSync(join(ROOT, 'tools', 'rig', 'result.html'), join(OUT, 'result.html'));
// Squish Stack's selected character on its forest road (src/stack/ForestMap.js): its page, and the Squad House walks it
// walks with (from the webgame build: node webgame/build.mjs first)
copyFileSync(join(ROOT, 'tools', 'rig', 'walk.html'), join(OUT, 'walk.html'));
for (const f of ['house-walk.js', 'house-walk-c.js', 'fruit-house.js', 'pet2-house.js', 'snack2-house.js']) copyFileSync(join(ROOT, 'android', 'app', 'src', 'main', 'assets', 'webgame', f), join(OUT, f));
for (const f of SCRIPTS) copyFileSync(join(DESIGN, f), join(OUT, f));
// the border look's outline (shared with the game's pages)
for (const f of ['look-lines.js', 'rig-look.js']) copyFileSync(join(ROOT, 'webgame', 'app', f), join(OUT, f));

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
