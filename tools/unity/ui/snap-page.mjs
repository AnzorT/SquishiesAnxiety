// Shared by the UI exporters: open a page of the app (Expo web, http://localhost:8081) at the reference phone's size,
// with tools/unity/ui/snap.js and the fonts (fonts.py output) loaded, so `snap(page, selectorOrHandle)` returns a
// piece of the UI as SVG.
import fs from 'node:fs';
import path from 'node:path';
import { createRequire } from 'node:module';
import { fileURLToPath } from 'node:url';

const require = createRequire(import.meta.url);
export const { chromium } = require('playwright');
export const HERE = path.dirname(fileURLToPath(import.meta.url));
export const ROOT = path.resolve(HERE, '..', '..', '..');
export const FONT_DIR = path.join(ROOT, 'unity', 'Assets', 'Resources', 'Fonts');
// Galaxy A15 sideways
export const DP = { width: 832, height: 384 }, DPR = 2.8125;

export function fontData() {
  const fonts = {}, glyphs = {}, upm = {}, paths = {};
  for (const f of fs.readdirSync(FONT_DIR).filter((f) => f.endsWith('.json'))) {
    const d = JSON.parse(fs.readFileSync(path.join(FONT_DIR, f), 'utf8'));
    const chars = [...d.chars];
    fonts[d.name] = true;
    glyphs[d.name] = chars;
    upm[d.name] = d.unitsPerEm;
    paths[d.name] = Object.fromEntries(chars.map((c, i) => [c, d.glyphs[i].d]));
  }
  return { names: Object.keys(fonts), glyphs, upm, paths };
}

export async function openApp(url, { browser } = {}) {
  const b = browser || (await chromium.launch());
  const page = await b.newPage({ viewport: DP, deviceScaleFactor: DPR });
  const errors = [];
  page.on('pageerror', (e) => errors.push(e.message));
  const fd = fontData();
  await page.addInitScript((fd) => {
    window.__snapFonts = fd.names;
    window.__snapGlyphs = Object.fromEntries(Object.entries(fd.glyphs).map(([k, v]) => [k, new Set(v)]));
    window.__snapUpm = fd.upm;
    window.__snapPaths = fd.paths;
  }, fd);
  await page.addInitScript({ path: path.join(HERE, 'snap.js') });
  await page.goto(url, { timeout: 240000 });
  return { browser: b, page, errors };
}

// the element's SVG; images inlined as data URLs when `inline`
export async function snap(page, target, { inline = true } = {}) {
  const handle = typeof target === 'string' ? await page.$(target) : target;
  const s = await page.evaluate(
    async ([el, inline]) => {
      const s = window.__snap(el);
      if (inline) {
        for (const [id, src] of Object.entries(s.images)) {
          const blob = await (await fetch(src)).blob();
          const data = await new Promise((r) => {
            const fr = new FileReader();
            fr.onload = () => r(fr.result);
            fr.readAsDataURL(blob);
          });
          s.svg = s.svg.split(`href="${id}"`).join(`href="${data}"`);
          s.images[id] = data;
        }
      }
      return s;
    },
    [handle, inline],
  );
  // characters from a fallback font (★, emoji): each drawn by Chrome alone on a transparent page, as a PNG
  for (const r of s.rasters) {
    const png = await page.evaluate(async (r) => {
      const c = document.createElement('canvas');
      const k = window.devicePixelRatio;
      c.width = Math.ceil(r.w * k); c.height = Math.ceil(r.h * k);
      const g = c.getContext('2d');
      g.scale(k, k);
      g.font = `${r.weight} ${r.size}px ${r.font}`;
      g.fillStyle = r.color;
      g.textBaseline = 'alphabetic';
      // the character box's top is the font's ascent above the baseline
      const m = g.measureText(r.ch);
      g.fillText(r.ch, 0, m.fontBoundingBoxAscent + (r.h - m.fontBoundingBoxAscent - m.fontBoundingBoxDescent) / 2);
      return c.toDataURL('image/png');
    }, r);
    s.images[r.id] = png;
    s.svg = s.svg.split(`href="${r.id}"`).join(`href="${inline ? png : r.id}"`);
  }
  return s;
}
