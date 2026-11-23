// The app's squish stage, run frame by frame on a scripted sequence of touches, with its state recorded every frame
// and its picture at chosen frames: what Program.cs checks the Unity port against (`dotnet run -- toy <dir>`).
//   node tools/unity/squish-test/ref.mjs <out dir> [key] [stage]
// Needs the Expo web app (http://localhost:8081) and an exported card (node tools/unity/export-squish.mjs).
import fs from 'node:fs';
import path from 'node:path';
import { fileURLToPath } from 'node:url';
import { openApp } from '../ui/snap-page.mjs';

const HERE = path.dirname(fileURLToPath(import.meta.url));
const REPO = path.resolve(HERE, '../../..');
const [out, key = 'mittens', stageArg = '0'] = process.argv.slice(2);
const stage = Number(stageArg);
fs.mkdirSync(out, { recursive: true });
const data = JSON.parse(fs.readFileSync(path.join(REPO, 'unity/Assets/Resources/Squish/squish.json'), 'utf8'));
const id = data.roster.find((c) => c.key === key).id;
const png = fs.readFileSync(path.join(REPO, `unity/Assets/Resources/Squish/cards/${key}.png.bytes`));
const BG = '#c8dcf0';
const DT = 16;

// the scenario: [frame, event] (events go in after that frame is drawn)
export const SCENARIO = {
  seed: 1234.5, idlePhase: 2, frames: 260,
  events: [
    [5, { t: 'down', x: 0.1, y: 0.15 }],
    [9, { t: 'move', x: 0.102, y: 0.151 }],
    [14, { t: 'move', x: 0.16, y: 0.1 }],
    [18, { t: 'move', x: 0.24, y: 0.02 }],
    [22, { t: 'move', x: 0.3, y: -0.08 }],
    [40, { t: 'up', r: [0.83, 0.21] }],
    [70, { t: 'down', x: -0.35, y: -0.25 }],
    [95, { t: 'up', r: [0.12, 0.64] }],
    [100, { t: 'down', x: 0.92, y: 0.88 }],
    [104, { t: 'move', x: 0.6, y: 0.5 }],
    [112, { t: 'up', r: [0.5, 0.97] }],
    [150, { t: 'orbit', dx: 24, dy: 6 }],
    [151, { t: 'orbit', dx: 30, dy: 4 }],
    [152, { t: 'orbit', dx: 18, dy: -3 }],
    [153, { t: 'endOrbit' }],
    [200, { t: 'down', x: 0, y: 0.35 }],
    [206, { t: 'cancel' }],
  ],
  shots: [4, 12, 20, 30, 39, 44, 52, 80, 94, 120, 160, 210, 259],
};

const { browser, page, errors } = await openApp('http://localhost:8081/?phone=1&preview=1&card=scr-stats');
await page.waitForTimeout(6000);
await page.addScriptTag({ path: path.join(HERE, 'toy-page.js') });
const url = 'data:image/png;base64,' + png.toString('base64');
await page.evaluate(async ([url, id, stage, BG]) => window.__squishMount({ url, id, stage, bg: BG }), [url, id, stage, BG]);
await page.evaluate(([seed, ph]) => { window.__toy.seed = seed; window.__toy.idlePhase = ph; }, [SCENARIO.seed, SCENARIO.idlePhase]);
const t0 = await page.evaluate(() => window.__squishNow());
const frames = [];
const evAt = new Map();
for (const [f, e] of SCENARIO.events) (evAt.get(f) || evAt.set(f, []).get(f)).push(e);
for (let f = 0; f < SCENARIO.frames; f++) {
  await page.evaluate((DT) => window.__squishStep(DT), DT);
  const st = await page.evaluate(() => window.__squishState());
  frames.push(st);
  if (SCENARIO.shots.includes(f)) await page.screenshot({ path: path.join(out, `frame-${f}.png`), clip: { x: 0, y: 0, width: 384, height: 384 } });
  for (const e of evAt.get(f) || []) {
    await page.evaluate((e) => {
      const h = window.__squishHandle.current;
      if (e.t === 'down') h.pointerDown(e.x, e.y);
      else if (e.t === 'move') h.pointerMove(e.x, e.y);
      else if (e.t === 'up') { const r = e.r.slice(); const mr = Math.random; Math.random = () => r.shift(); try { h.pointerUp(); } finally { Math.random = mr; } }
      else if (e.t === 'orbit') h.orbit(e.dx, e.dy);
      else if (e.t === 'endOrbit') h.endOrbit();
      else if (e.t === 'cancel') h.cancelPoke();
    }, e);
  }
}
// the compiled programs (the card's: three's MeshStandardMaterial with the squish and the card decode; the quad's)
const shaders = await page.evaluate(() => {
  const gl = window.__squishGl;
  const ctx = gl.getContext();
  return gl.info.programs.map((p) => ({ name: p.name, vs: ctx.getShaderSource(p.vertexShader), fs: ctx.getShaderSource(p.fragmentShader) }));
});
fs.writeFileSync(path.join(out, 'shaders.json'), JSON.stringify(shaders, null, 1));
fs.writeFileSync(path.join(out, 'frames.json'), JSON.stringify({ key, id, stage, bg: BG, dt: DT, t0, scenario: SCENARIO, frames }));
console.log(`${frames.length} frames, ${SCENARIO.shots.length} shots -> ${out}`, errors.slice(0, 3));
await browser.close();
