// The design prototype is the source of truth for how the game looks. It lives in the repo as the zip the designer
// hands over (Squish Squad Prototype Nov13.zip). extractPrototype() unpacks it once into webgame/.cache and returns
// the folder with the pages (…/squish-squad). A new zip (new name or new size) gets its own folder.
import fs from 'node:fs';
import path from 'node:path';
import { fileURLToPath } from 'node:url';
import StreamZip from 'node-stream-zip';

const HERE = path.dirname(fileURLToPath(import.meta.url));
export const WEBGAME = path.resolve(HERE, '..');
export const REPO = path.resolve(WEBGAME, '..');
// the zip to build from; change this line when the designer sends a new one
export const PROTOTYPE_ZIP = path.join(REPO, 'Squish Squad Prototype Nov13.zip');

export async function extractPrototype(zipPath = PROTOTYPE_ZIP) {
  const st = fs.statSync(zipPath);
  const tag = path.basename(zipPath, '.zip').replace(/[^A-Za-z0-9]+/g, '-') + '-' + st.size;
  const dir = path.join(WEBGAME, '.cache', tag);
  const done = path.join(dir, '.extracted');
  if (!fs.existsSync(done)) {
    fs.rmSync(dir, { recursive: true, force: true });
    fs.mkdirSync(dir, { recursive: true });
    const zip = new StreamZip.async({ file: zipPath });
    await zip.extract(null, dir);
    await zip.close();
    fs.writeFileSync(done, new Date().toISOString());
  }
  const root = fs.readdirSync(dir).find(n => fs.existsSync(path.join(dir, n, 'support.js')));
  if (!root) throw new Error('no prototype folder with support.js inside ' + zipPath);
  return path.join(dir, root);
}
