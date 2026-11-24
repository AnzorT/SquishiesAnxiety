// node tools/unity/export-audio.mjs — copies the sounds the app plays into the Unity project and writes their table.
//
// What the app plays (and nothing else: assets/audio/preview and the old squish-*.mp3 aren't used anywhere):
//   - src/audio/sfx.js's EFFECTS: effectFiles.js, squishdokuFiles.js, sortFiles.js, stackFiles.js, then its own
//     overrides ('tap' is bubble_tap.wav), and MUSIC ('theme': Velvet Map Study)
//   - the squish screen's own: each creature's squish loop (creatureSquishFiles.js), the default loop (slime.wav,
//     creatureSquish.js), the coin ding (CoinSound.js) and the release pop (PopSound.js)
// They go to unity/Assets/Resources/Audio/<the same path under assets/audio>, byte for byte: Unity imports WAV, MP3
// and Ogg Vorbis as they are (24-bit / 48 kHz WAV included), so nothing is converted. The import settings (PCM for
// the WAV effects, Vorbis for the rest, streaming for the music) are applied by
// unity/Assets/Scripts/Audio/Editor/AudioImport.cs. A file Unity couldn't import would be converted to WAV with
// ffmpeg (none is today).
//
// Writes unity/Assets/Scripts/Audio/SoundFiles.g.cs (name -> file) and prints the sizes. --check: only compares
// (exit 1 when the Unity copy or the table is stale).
import { createHash } from 'node:crypto';
import { execFileSync } from 'node:child_process';
import fs from 'node:fs';
import path from 'node:path';
import { fileURLToPath } from 'node:url';

const here = path.dirname(fileURLToPath(import.meta.url));
const ROOT = path.resolve(here, '../..');
const SRC = path.join(ROOT, 'src/audio');
const ASSETS = path.join(ROOT, 'assets/audio');
const OUT = path.join(ROOT, 'unity/Assets/Resources/Audio');
const TABLE = path.join(ROOT, 'unity/Assets/Scripts/Audio/SoundFiles.g.cs');
const CHECK = process.argv.includes('--check');
const UNITY_FORMATS = new Set(['.wav', '.mp3', '.ogg', '.aif', '.aiff']);

const read = (f) => fs.readFileSync(path.join(SRC, f), 'utf8');
// `key: require('../../assets/audio/<file>')` (key a name or a quoted string)
const REQ = /(?:^|[\s{,])(?:'([^']+)'|"([^"]+)"|([A-Za-z_$][\w$]*))\s*:\s*require\(\s*'\.\.\/\.\.\/assets\/audio\/([^']+)'\s*\)/g;
function table(text) {
  const out = {};
  for (const m of text.matchAll(REQ)) out[m[1] ?? m[2] ?? m[3]] = m[4];
  return out;
}
const one = (file, re) => {
  const m = read(file).match(re);
  if (!m) throw new Error(`${file}: the sound's require() wasn't found`);
  return m[1];
};

// sfx.js: `const EFFECTS = { ...A, ...B, key: require(...) }` with A, B imported from './xFiles'
const sfx = read('sfx.js');
const imports = Object.fromEntries([...sfx.matchAll(/^import\s+(\w+)\s+from\s+'\.\/(\w+)';/gm)].map((m) => [m[1], m[2] + '.js']));
const eff = sfx.match(/const EFFECTS = \{([^;]*)\};/);
if (!eff) throw new Error('sfx.js: EFFECTS not found');
const effects = {};
for (const part of eff[1].split(/,(?![^(]*\))/)) {
  const p = part.trim();
  if (!p) continue;
  const spread = p.match(/^\.\.\.(\w+)$/);
  if (spread) Object.assign(effects, table(read(imports[spread[1]])));
  else Object.assign(effects, table(' ' + p));
}
const musicBlock = sfx.match(/const MUSIC = \{([\s\S]*?)\n\};/);
if (!musicBlock) throw new Error('sfx.js: MUSIC not found');
const music = table(musicBlock[1]);
const creatures = table(read('creatureSquishFiles.js'));
const squish = {
  coin: one('CoinSound.js', /require\('\.\.\/\.\.\/assets\/audio\/([^']+)'\)/),
  pop: one('PopSound.js', /require\('\.\.\/\.\.\/assets\/audio\/([^']+)'\)/),
  slime: one('creatureSquish.js', /DEFAULT_SQUISH_SOUND = require\('\.\.\/\.\.\/assets\/audio\/([^']+)'\)/),
};
const coinVol = Number(one('CoinSound.js', /super\([^,]+,\s*([0-9.]+)\)/));
const popVol = Number(one('PopSound.js', /super\([^,]+,\s*([0-9.]+)\)/));

// ---- copy -----------------------------------------------------------------------------------------------------------
const files = [...new Set([...Object.values(effects), ...Object.values(music), ...Object.values(creatures), ...Object.values(squish)])].sort();
const sha = (f) => createHash('sha1').update(fs.readFileSync(f)).digest('hex');
let stale = 0, bytes = 0;
const rows = [];
for (const rel of files) {
  const from = path.join(ASSETS, rel);
  if (!fs.existsSync(from)) throw new Error('missing ' + from);
  const ext = path.extname(rel).toLowerCase();
  let to = path.join(OUT, rel), convert = false;
  if (!UNITY_FORMATS.has(ext)) {
    to = to.slice(0, -ext.length) + '.wav';
    convert = true;
  }
  const same = fs.existsSync(to) && (convert || sha(from) === sha(to));
  if (!same) {
    stale++;
    if (!CHECK) {
      fs.mkdirSync(path.dirname(to), { recursive: true });
      if (convert) execFileSync('ffmpeg', ['-v', 'error', '-y', '-i', from, '-c:a', 'pcm_s16le', to]);
      else fs.copyFileSync(from, to);
    }
  }
  const n = fs.existsSync(to) ? fs.statSync(to).size : fs.statSync(from).size;
  bytes += n;
  rows.push([rel, n, convert ? 'converted to WAV' : '']);
}
// files in the Unity folder the app no longer plays (their .meta go with them)
const want = new Set(files.map((r) => path.join(OUT, r)));
const extra = [];
const walk = (d) => fs.existsSync(d) && fs.readdirSync(d, { withFileTypes: true }).forEach((e) => {
  const f = path.join(d, e.name);
  if (e.isDirectory()) walk(f);
  else if (!f.endsWith('.meta') && !want.has(f)) extra.push(f);
});
walk(OUT);
for (const f of extra) {
  stale++;
  if (!CHECK) {
    fs.rmSync(f);
    fs.rmSync(f + '.meta', { force: true });
  }
}

// ---- the table --------------------------------------------------------------------------------------------------------
const cs = (o) => Object.keys(o).sort().map((k) => `            { ${JSON.stringify(k)}, ${JSON.stringify(o[k])} },`).join('\n');
const text = `// Generated by tools/unity/export-audio.mjs from src/audio (sfx.js's EFFECTS and MUSIC, creatureSquishFiles.js,
// creatureSquish.js, CoinSound.js, PopSound.js). Don't edit by hand: run the exporter again when the app's sounds change.
// Each file is the app's path under assets/audio; Unity has it at Resources/Audio/<path without its extension>.
using System.Collections.Generic;

namespace SquishSquad.Audio
{
    public static class SoundFiles
    {
        /// <summary>sfx.js's EFFECTS: name -> file (${Object.keys(effects).length}).</summary>
        public static readonly IReadOnlyDictionary<string, string> Effects = new Dictionary<string, string>
        {
${cs(effects)}
        };

        /// <summary>sfx.js's MUSIC.</summary>
        public static readonly IReadOnlyDictionary<string, string> Music = new Dictionary<string, string>
        {
${cs(music)}
        };

        /// <summary>creatureSquishFiles.js: each premade creature's own squish loop (creature id -> file).</summary>
        public static readonly IReadOnlyDictionary<string, string> CreatureSquish = new Dictionary<string, string>
        {
${cs(creatures)}
        };

        /// <summary>creatureSquish.js's DEFAULT_SQUISH_SOUND: the loop for any other creature.</summary>
        public const string DefaultSquish = ${JSON.stringify(squish.slime)};
        /// <summary>CoinSound.js: the ding on every coin earned on the squish stage, at this volume.</summary>
        public const string Coin = ${JSON.stringify(squish.coin)};
        public const double CoinVolume = ${coinVol};
        /// <summary>PopSound.js: the pop when a one-finger squish lets go, at this volume.</summary>
        public const string Pop = ${JSON.stringify(squish.pop)};
        public const double PopVolume = ${popVol};

        /// <summary>The Resources path of an app file ("sfx/tap.wav" -> "Audio/sfx/tap").</summary>
        public static string ResourcePath(string file)
        {
            int dot = file.LastIndexOf('.');
            return "Audio/" + (dot > 0 ? file.Substring(0, dot) : file);
        }
    }
}
`;
const old = fs.existsSync(TABLE) ? fs.readFileSync(TABLE, 'utf8') : '';
if (old !== text) {
  stale++;
  if (!CHECK) fs.writeFileSync(TABLE, text);
}

// ---- report -----------------------------------------------------------------------------------------------------------
const kb = (n) => (n / 1024).toFixed(1).padStart(8) + ' KB';
const groups = {};
for (const [rel, n] of rows) {
  const g = rel.includes('/') ? rel.split('/')[0] : '(root)';
  groups[g] = groups[g] || [0, 0];
  groups[g][0]++;
  groups[g][1] += n;
}
console.log(`${Object.keys(effects).length} effects, ${Object.keys(music).length} music, ${Object.keys(creatures).length} creature loops, coin/pop/slime`);
for (const [g, [c, n]] of Object.entries(groups)) console.log(`  ${g.padEnd(12)} ${String(c).padStart(3)} files ${kb(n)}`);
console.log(`  total        ${String(rows.length).padStart(3)} files ${kb(bytes)}`);
for (const [rel, , note] of rows) if (note) console.log('  ' + rel + ': ' + note);
if (CHECK) {
  console.log(stale ? `stale: ${stale} (run without --check)` : 'up to date');
  process.exit(stale ? 1 : 0);
} else console.log(stale ? `wrote ${stale} change(s)` : 'up to date');
