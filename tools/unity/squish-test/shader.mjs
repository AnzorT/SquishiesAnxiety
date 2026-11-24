// The dent shader's maths on the GPU, from the app's own GLSL: SquishyToy.js's SQUISH_VERTEX_GLSL, SQUISH_NORMAL_GLSL
// and SQUISH_POSITION_GLSL (read from the source), spliced after three's beginnormal_vertex / begin_vertex as
// installSquishShader does, run over the card's vertices (the app's cardGeometryData, from the Expo web bundle) with
// WebGL2 transform feedback for many random press sets. Program.cs `shader` computes the same with the port
// (SquishShaderMath, which SquishCard.shader transcribes) and compares.
//   node tools/unity/squish-test/shader.mjs <out dir> [cases]
import fs from 'node:fs';
import path from 'node:path';
import { fileURLToPath } from 'node:url';
import { openApp } from '../ui/snap-page.mjs';

const HERE = path.dirname(fileURLToPath(import.meta.url));
const REPO = path.resolve(HERE, '../../..');
const [out, casesArg = '400'] = process.argv.slice(2);
fs.mkdirSync(out, { recursive: true });
const src = fs.readFileSync(path.join(REPO, 'src/components/SquishyToy.js'), 'utf8');
const max = +src.match(/const SQUISH_MAX_PRESSES = (\d+);/)[1];
const glsl = (name) => src.match(new RegExp('const ' + name + ' = `([\\s\\S]*?)`;'))[1].replace('${SQUISH_MAX_PRESSES}', String(max));
const VERTEX = glsl('SQUISH_VERTEX_GLSL');
const NORMAL = glsl('SQUISH_NORMAL_GLSL').replace('#include <beginnormal_vertex>', 'vec3 objectNormal = vec3( normal );');
const POSITION = glsl('SQUISH_POSITION_GLSL').replace('#include <begin_vertex>', 'vec3 transformed = vec3( position );');
const VS = `#version 300 es
precision highp float;
precision highp int;
in vec3 position;
in vec3 normal;
out vec3 oPos;
out vec3 oNrm;
${VERTEX}
void main() {
${NORMAL}
${POSITION}
  oPos = transformed;
  oNrm = objectNormal;
  gl_Position = vec4(0.0, 0.0, 0.0, 1.0);
}`;
const FS = `#version 300 es
precision highp float;
out vec4 c;
void main() { c = vec4(1.0); }`;

// seeded random press sets: 1-24 points on / near the card (front or back), springs' amplitudes, a direction with the
// lift folded in, a dent shape around CARD_TUNING's, the push-in / pop-out sign
let seed = 20261123;
const rnd = () => ((seed = (seed * 1103515245 + 12345) % 2147483648) / 2147483648);
const cases = [];
for (let k = 0; k < +casesArg; k++) {
  const count = 1 + Math.floor(rnd() * max);
  const press = [];
  for (let j = 0; j < max; j++) {
    const back = rnd() < 0.3 ? -1 : 1;
    press.push(...(j < count ? [(rnd() * 2 - 1) * 1.3, (rnd() * 2 - 1) * 1.3, back * rnd() * 0.08, (rnd() * 2 - 0.4) * 0.6] : [0, 0, 0, 0]));
  }
  const p = [press[0], press[1], press[2]];
  const len = Math.hypot(...p) || 1;
  const sign = rnd() < 0.8 ? 1 : -1;
  const lift = 1 + (rnd() * 0.3 - 0.1);
  const dir = p.map((v) => (-v / len) * sign / lift);
  const dent = [0.2 + rnd() * 0.25, 0.02 + rnd() * 0.06, 0.36 * (0.5 + rnd()) * 1.5, 0];
  cases.push({ count, press: Array.from(new Float32Array(press)), dir: Array.from(new Float32Array(dir)), dent: Array.from(new Float32Array(dent)) });
}

const { browser, page } = await openApp('http://localhost:8081/?phone=1&preview=1&card=scr-stats');
await page.waitForTimeout(5000);
const res = await page.evaluate(([VS, FS, cases]) => {
  let card = null;
  for (const [id, m] of __r.getModules()) if (m && m.verboseName === 'src/components/squishCard.js') card = __r(id);
  const g = card.cardGeometryData();
  const canvas = document.createElement('canvas');
  const gl = canvas.getContext('webgl2');
  const sh = (type, s) => { const x = gl.createShader(type); gl.shaderSource(x, s); gl.compileShader(x); if (!gl.getShaderParameter(x, gl.COMPILE_STATUS)) throw new Error(gl.getShaderInfoLog(x)); return x; };
  const prog = gl.createProgram();
  gl.attachShader(prog, sh(gl.VERTEX_SHADER, VS));
  gl.attachShader(prog, sh(gl.FRAGMENT_SHADER, FS));
  gl.transformFeedbackVaryings(prog, ['oPos', 'oNrm'], gl.INTERLEAVED_ATTRIBS);
  gl.bindAttribLocation(prog, 0, 'position');
  gl.bindAttribLocation(prog, 1, 'normal');
  gl.linkProgram(prog);
  if (!gl.getProgramParameter(prog, gl.LINK_STATUS)) throw new Error(gl.getProgramInfoLog(prog));
  gl.useProgram(prog);
  const n = g.vertCount;
  const buf = (data, loc) => { const b = gl.createBuffer(); gl.bindBuffer(gl.ARRAY_BUFFER, b); gl.bufferData(gl.ARRAY_BUFFER, data, gl.STATIC_DRAW); gl.enableVertexAttribArray(loc); gl.vertexAttribPointer(loc, 3, gl.FLOAT, false, 0, 0); };
  buf(g.basePos, 0);
  buf(g.baseNormals, 1);
  const tf = gl.createBuffer();
  gl.bindBuffer(gl.TRANSFORM_FEEDBACK_BUFFER, tf);
  gl.bufferData(gl.TRANSFORM_FEEDBACK_BUFFER, n * 6 * 4, gl.STREAM_READ);
  gl.enable(gl.RASTERIZER_DISCARD);
  const U = (name) => gl.getUniformLocation(prog, name);
  const outs = [];
  for (const c of cases) {
    gl.uniform4fv(U('uSquishPress'), new Float32Array(c.press));
    gl.uniform1i(U('uSquishCount'), c.count);
    gl.uniform3fv(U('uSquishDir'), new Float32Array(c.dir));
    gl.uniform4fv(U('uSquishDent'), new Float32Array(c.dent));
    gl.bindBufferBase(gl.TRANSFORM_FEEDBACK_BUFFER, 0, tf);
    gl.beginTransformFeedback(gl.POINTS);
    gl.drawArrays(gl.POINTS, 0, n);
    gl.endTransformFeedback();
    gl.bindBufferBase(gl.TRANSFORM_FEEDBACK_BUFFER, 0, null);
    const o = new Float32Array(n * 6);
    gl.bindBuffer(gl.TRANSFORM_FEEDBACK_BUFFER, tf);
    gl.getBufferSubData(gl.TRANSFORM_FEEDBACK_BUFFER, 0, o);
    outs.push(Array.from(o));
  }
  return { basePos: Array.from(g.basePos), baseNormals: Array.from(g.baseNormals), uv: Array.from(g.uvArray), index: Array.from(g.indexArray), outs, renderer: gl.getParameter(gl.RENDERER) };
}, [VS, FS, cases]);
fs.writeFileSync(path.join(out, 'shader.json'), JSON.stringify({ vs: VS, cases, ...res }));
console.log(`${cases.length} press sets x ${res.basePos.length / 3} vertices on ${res.renderer} -> ${out}/shader.json`);
await browser.close();
