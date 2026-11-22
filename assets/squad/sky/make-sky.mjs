// The Squish Time sky's bitmaps (src/squad/SkyBackground.js), written as plain PNGs: node assets/squad/sky/make-sky.mjs
// - glow.png: white, alpha 1 at the centre falling linearly to 0 at the edge (an SVG radial gradient's falloff), drawn
//   scaled and tinted for the glow behind the toy and the warm glow rising from the bottom
// - puff.png: the cloud puffs, solid to 52% of the radius, then the same linear falloff
// - dotgrid@3x.png: a 10 x 5 block of the white dot grid's 26 dp cells (a 1.4 dp dot at each centre, 80% white), laid
//   out edge to edge at 260 x 130 dp (resizeMode repeat drew a single tile on Android: no tiling)
// (2026-11-20: the sky was one full-screen react-native-svg, painted in software on the UI thread, 65 ms on the
// Galaxy A16 each time the stage came up under the loading beat)
import fs from 'fs';
import path from 'path';
import zlib from 'zlib';
import { fileURLToPath } from 'url';

const here = path.dirname(fileURLToPath(import.meta.url));

const CRC = new Uint32Array(256).map((_, n) => {
  let c = n;
  for (let k = 0; k < 8; k++) c = c & 1 ? 0xedb88320 ^ (c >>> 1) : c >>> 1;
  return c >>> 0;
});
const crc32 = (buf) => {
  let c = 0xffffffff;
  for (const b of buf) c = CRC[(c ^ b) & 0xff] ^ (c >>> 8);
  return (c ^ 0xffffffff) >>> 0;
};
const chunk = (type, data) => {
  const len = Buffer.alloc(4);
  len.writeUInt32BE(data.length);
  const td = Buffer.concat([Buffer.from(type, 'ascii'), data]);
  const crc = Buffer.alloc(4);
  crc.writeUInt32BE(crc32(td));
  return Buffer.concat([len, td, crc]);
};
// alpha(x, y) in 0..1 for every pixel centre; white everywhere
function png(file, size, alpha) {
  const [W, H] = Array.isArray(size) ? size : [size, size];
  const rows = [];
  for (let y = 0; y < H; y++) {
    const row = Buffer.alloc(1 + W * 4);
    for (let x = 0; x < W; x++) {
      const a = Math.max(0, Math.min(1, alpha(x + 0.5, y + 0.5)));
      row.writeUInt32BE(((0xffffff << 8) | Math.round(a * 255)) >>> 0, 1 + x * 4);
    }
    rows.push(row);
  }
  const ihdr = Buffer.alloc(13);
  ihdr.writeUInt32BE(W, 0);
  ihdr.writeUInt32BE(H, 4);
  ihdr[8] = 8; // bit depth
  ihdr[9] = 6; // RGBA
  const out = Buffer.concat([
    Buffer.from([0x89, 0x50, 0x4e, 0x47, 0x0d, 0x0a, 0x1a, 0x0a]),
    chunk('IHDR', ihdr),
    chunk('IDAT', zlib.deflateSync(Buffer.concat(rows), { level: 9 })),
    chunk('IEND', Buffer.alloc(0)),
  ]);
  fs.writeFileSync(path.join(here, file), out);
  console.log(file, W + 'x' + H, out.length, 'bytes');
}

const radial = (size, solid) => (x, y) => {
  const d = Math.hypot(x - size / 2, y - size / 2) / (size / 2);
  return d <= solid ? 1 : 1 - (d - solid) / (1 - solid);
};
png('glow.png', 512, radial(512, 0));
png('puff.png', 128, radial(128, 0.52));
// 26 dp cells at 3x: 78 px each, the dot r = 1.4 dp = 4.2 px, 80% white, a one-pixel soft edge
png('dotgrid@3x.png', [780, 390], (x, y) => 0.8 * Math.max(0, Math.min(1, 4.2 + 0.5 - Math.hypot((x % 78) - 39, (y % 78) - 39))));
