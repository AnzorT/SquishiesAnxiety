// Copies the chest smash page (tools/chest/host.html), the design's chest engine and sounds, and the
// two fonts it uses into the Android assets, where src/components/ChestSmash.js loads them
// (file:///android_asset/chest/host.html).
// usage: node tools/chest/build.mjs   (re-run after a new design drop is unpacked in tools/design-v6)
import { copyFileSync, mkdirSync, rmSync, existsSync } from 'node:fs';
import { join, dirname } from 'node:path';
import { fileURLToPath } from 'node:url';

const ROOT = join(dirname(fileURLToPath(import.meta.url)), '..', '..');
const DESIGN = join(ROOT, 'tools', 'design-v6');
const OUT = join(ROOT, 'android', 'app', 'src', 'main', 'assets', 'chest');
const SCRIPTS = ['chest-sfx.js', 'chest-models.js', 'chest-fruit.js', 'chest-ocean.js', 'chest-pet.js', 'chest-kit.js', 'chest-forest.js', 'chest-sky.js', 'chest-dream.js', 'chest-bakery.js', 'chest-heroes.js', 'chest-elemental.js', 'chest-spooky.js'];
const FONTS = [
  ['@expo-google-fonts/fredoka/700Bold', 'Fredoka_700Bold.ttf'],
  ['@expo-google-fonts/nunito/700Bold', 'Nunito_700Bold.ttf'],
  ['@expo-google-fonts/nunito/800ExtraBold', 'Nunito_800ExtraBold.ttf'],
  ['@expo-google-fonts/nunito/900Black', 'Nunito_900Black.ttf'],
];

if (!existsSync(join(DESIGN, 'chest-models.js'))) throw new Error('unpack the design zip into tools/design-v6 first');
rmSync(OUT, { recursive: true, force: true });
mkdirSync(join(OUT, 'fonts'), { recursive: true });
copyFileSync(join(ROOT, 'tools', 'chest', 'host.html'), join(OUT, 'host.html'));
for (const f of SCRIPTS) copyFileSync(join(DESIGN, f), join(OUT, f));
for (const [dir, f] of FONTS) copyFileSync(join(ROOT, 'node_modules', dir, f), join(OUT, 'fonts', f));
console.log(`chest assets: host.html, ${SCRIPTS.length} scripts, ${FONTS.length} fonts -> ${OUT}`);
