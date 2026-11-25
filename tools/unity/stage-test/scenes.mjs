// The stage test's scenes: a page, its size (dp) and scale, and the calls to make on it as src/hop/RigStage.js makes
// them (step.call with step.args), with waits between (a number of ms, or 'cast': until the page says it has drawn
// the cast). The last wait holds the scene still: everyone has settled, so the page has stopped drawing them.
// Written out as scenes.json for Program.cs (node tools/unity/stage-test/scenes.mjs).
import fs from 'node:fs';
import path from 'node:path';
import { fileURLToPath } from 'node:url';

export const BG = '#9fd8c8';
const P = 56;
const sortCast = [
  { id: '2', key: 'mallow', P },
  { id: '3', key: 'bao', P },
  { id: '9', key: 'pina', P },
  { id: '14', key: 'choco', P },
];
export const SCENES = [
  {
    // four squishies at rest: three on a shelf (one in front), one in the tray (smaller)
    name: 'sort-rest', page: 'sort', W: 640, H: 360, dpr: 2,
    steps: [
      { call: 'cast', args: [sortCast, 't1'] },
      { wait: 'cast' },
      { call: 'place', args: ['2', { x: 80, y: 150, s: 1, o: 1 }] },
      { call: 'place', args: ['3', { x: 170, y: 150, s: 1, o: 1 }] },
      { call: 'place', args: ['9', { x: 260, y: 160, s: 1, o: 1, z: 12 }] },
      { call: 'place', args: ['14', { x: 470, y: 90, s: 0.8, o: 1 }] },
      { wait: 2500 },
    ],
  },
  {
    // the hopper and two friends at rest on the board
    name: 'hop-rest', page: 'hop', W: 640, H: 360, dpr: 2,
    steps: [
      { call: 'origin', args: [0, 0] },
      { call: 'cast', args: [[{ id: 'p', key: 'mittens', W: 60, x: 200, y: 240, s: 1, z: 20, o: 1 }, { id: 'f0', key: 'mallow', W: 44, x: 360, y: 200, s: 1, z: 10, o: 1 }, { id: 'f1', key: 'bao', W: 44, x: 470, y: 280, s: 0.9, z: 30, o: 1 }], 'h1'] },
      { wait: 'cast' },
      { wait: 2500 },
    ],
  },
];

if (process.argv[1] && path.resolve(process.argv[1]) === fileURLToPath(import.meta.url))
  fs.writeFileSync(path.join(path.dirname(fileURLToPath(import.meta.url)), 'scenes.json'), JSON.stringify({ bg: BG, scenes: SCENES }, null, 1));
