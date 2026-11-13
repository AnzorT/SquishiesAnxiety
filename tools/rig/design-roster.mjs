// The design's roster (tools/design-v6/squad-store.js R), parsed:
// [{ id, key, name, set, rar, concept, sound, move, dance, flag }] in the
// design's own numbering (ours is functions/squad.js; match by `key`).
import fs from 'node:fs';
import path from 'node:path';
import { fileURLToPath } from 'node:url';

const ROOT = path.resolve(path.dirname(fileURLToPath(import.meta.url)), '../..');
// DESIGN_DIR: another unpacked design (e.g. the Nov 13 prototype: webgame/.cache/<zip>/squish-squad)
const DESIGN_DIR = process.env.DESIGN_DIR ? path.resolve(process.env.DESIGN_DIR) : path.join(ROOT, 'tools/design-v6');
const src = fs.readFileSync(path.join(DESIGN_DIR, 'squad-store.js'), 'utf8');
const arrayAfter = (marker) => {
  const start = src.indexOf(marker) + marker.length;
  let depth = 0;
  for (let i = start; i < src.length; i++) {
    if (src[i] === '[') depth++;
    else if (src[i] === ']' && --depth === 0) return src.slice(start, i + 1);
  }
  throw new Error(`no ${marker}`);
};
// [id, name, set, rarity, concept, sound, move name, dance, flag]
const R = new Function(`return ${arrayAfter('const R = ')}`)();
const KEYOF = new Function(`return ${src.match(/const KEYOF = ({[^}]*})/)[1]}`)();
export const design = R.map(([id, name, set, rar, concept, sound, move, dance, flag]) => ({
  id, name, set, rar, concept, sound, move, dance, flag,
  key: KEYOF[id] || name.toLowerCase().replace(/[^a-z]/g, ''),
}));
