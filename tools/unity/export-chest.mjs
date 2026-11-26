// The chest smash's reveal pictures for Unity (unity/Assets/Resources/Chests/; the code is
// unity/Assets/Scripts/Screens/Chests/ChestSmashView.cs). The reveal (android/app/src/main/assets/chest/host.html,
// 2026-11-17) draws the creature's card as the Characters screen's cards v6 do (the web game's export/cards4: SQ_CARD4
// lays it out, SQ_NAMES has the names drawn in each rarity's lettering), and the creature in its border look:
//   Chests/card/frame-<rarity>.png   the rarity's frame (600 x 894, the cards' 1696 x 2528 canvas scaled)
//   Chests/card/bg-<group>.jpg       the group's background in the card's window (400 x 400; opaque, so JPEG)
//   Chests/card/name/<key>.png       the creature's name in its rarity's lettering (380 wide: half the drawing's,
//                                    still sharper than the card shows it)
//   Chests/cards4.json               SQ_CARD4's layer boxes per rarity (% of the card: bg, art, nm; [x0, y0, x1, y1]),
//                                    its text colours (a name with no picture), and SQ_NAMES: the rarity each name was
//                                    drawn for (the card shows it only for that rarity) and its drawing's size; `looks`: the creatures with
//                                    a Chests/look still
//   Chests/look/<key>.png            the creature's still in a border look (src/squad/looks.js; --look n, the app's
//                                    default 4 without it: android/app/src/main/assets/looks/<n>/<key>.webp, 384 x 384),
//                                    as the reveal's card, the unlock's copies, the copies bar's head and the unlocked
//                                    creature show it (ChestSmash.js rewardOf img); cards4.json's `look` says which.
//                                    Unity draws every creature still with them (Screens/Common/Roster.Picture); one
//                                    look only, to keep the APK small (all four as textures: some 70 MB), so export the
//                                    one Firestore config/roster `look` picks (2026-11-26: 3). The live creatures follow
//                                    config/roster by themselves (Creatures/Js/RigLooks.cs).
// The cards v6 files are the built web game's (webgame/build.mjs, built to webgame/test/out/unity-webgame if it isn't
// there, as tools/unity/rig/bundle.mjs does): the APK ships them beside the chest page.
// node tools/unity/export-chest.mjs [--look n] [--looks-only]   (--looks-only: the stills and cards4.json's looks, not
//                                                               the cards v6 pictures)
import fs from 'node:fs';
import path from 'node:path';
import vm from 'node:vm';
import { execFileSync } from 'node:child_process';
import { fileURLToPath } from 'node:url';

const ROOT = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '..', '..');
const CHESTS = path.join(ROOT, 'unity', 'Assets', 'Resources', 'Chests');
const WEBGAME = path.join(ROOT, 'webgame', 'test', 'out', 'unity-webgame');
if (!fs.existsSync(path.join(WEBGAME, 'export', 'cards4', 'cards4.js'))) { const { build } = await import(path.join(ROOT, 'webgame', 'build.mjs')); await build(WEBGAME); }
const C4 = path.join(WEBGAME, 'export', 'cards4');
const argv = process.argv.slice(2), LOOKS_ONLY = argv.includes('--looks-only');
const LOOK_N = argv.includes('--look') ? Number(argv[argv.indexOf('--look') + 1]) : 4;
if (![1, 2, 3, 4].includes(LOOK_N)) { console.error('--look takes 1 to 4'); process.exit(1); }
for (const d of ['card', 'card/name', 'look']) fs.mkdirSync(path.join(CHESTS, d), { recursive: true });

// PNG (RGBA, optimized) or JPEG (opaque pictures), through Pillow; `w`: scaled to that width
const PY = 'import sys; from PIL import Image; im = Image.open(sys.argv[1]); q = int(sys.argv[3]); w = int(sys.argv[4]);\n'
  + 'im = im.resize((w, round(im.height * w / im.width)), Image.LANCZOS) if w else im\n'
  + 'im.convert("RGB").save(sys.argv[2], quality=q, subsampling=0) if q else im.convert("RGBA").save(sys.argv[2], optimize=True)';
const conv = (src, dst, q = 0, w = 0) => execFileSync('python3', ['-c', PY, src, dst, String(q), String(w)]);

// ---- cards v6 ------------------------------------------------------------------------------------------------------
const w = {}, names = {};
let ink = null;
if (!LOOKS_ONLY) {
vm.runInNewContext(fs.readFileSync(path.join(C4, 'cards4.js'), 'utf8') + '\n' + fs.readFileSync(path.join(C4, 'names.js'), 'utf8'), { window: w });
const INK = /const INK = (\{.*?\});/.exec(fs.readFileSync(path.join(C4, 'cards4.js'), 'utf8'))[1];
ink = vm.runInNewContext('(' + INK + ')');
for (const [key, [rar, src]] of Object.entries(w.SQ_NAMES)) {
  const f = path.join(WEBGAME, src.replace(/\?.*$/, ''));
  conv(f, path.join(CHESTS, 'card', 'name', key + '.png'), 0, 380);
  names[key] = [rar, ...execFileSync('python3', ['-c', 'import sys; from PIL import Image; print(*Image.open(sys.argv[1]).size)', f]).toString().trim().split(' ').map(Number)];
}
for (const rk of w.SQ_CARD4.FR) conv(path.join(C4, `frame-${rk}.webp`), path.join(CHESTS, 'card', `frame-${rk}.png`));
let nBg = 0;
for (const f of fs.readdirSync(C4)) if (/^bg-[a-z]+\.webp$/.test(f)) { conv(path.join(C4, f), path.join(CHESTS, 'card', f.replace('.webp', '.jpg')), 90); nBg++; }
console.log(`cards v6: ${w.SQ_CARD4.FR.length} frames, ${nBg} backgrounds, ${Object.keys(names).length} names`);
}

// ---- the creatures' stills in the look ----------------------------------------------------------------------------
const LOOKS = path.join(ROOT, 'android', 'app', 'src', 'main', 'assets', 'looks', String(LOOK_N));
const looks = [];
for (const f of fs.readdirSync(LOOKS).sort()) if (f.endsWith('.webp')) { conv(path.join(LOOKS, f), path.join(CHESTS, 'look', f.replace('.webp', '.png'))); looks.push(f.replace('.webp', '')); }
console.log(`looks: ${looks.length} stills in look ${LOOK_N}`);
const old = LOOKS_ONLY ? JSON.parse(fs.readFileSync(path.join(CHESTS, 'cards4.json'), 'utf8')) : null;
fs.writeFileSync(path.join(CHESTS, 'cards4.json'), JSON.stringify(old ? { ...old, looks, look: LOOK_N }
  : { fr: w.SQ_CARD4.FR, L: w.SQ_CARD4.L, ink, names, looks, look: LOOK_N }));
