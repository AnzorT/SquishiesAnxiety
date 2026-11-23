// Runs in the app's page (react-native-web): window.__snap(element) turns a piece of the UI into one SVG drawn in the
// element's own CSS pixels (dp), for the Unity vector renderer. It reads what Chrome laid out and painted:
//   views       rounded rects with their background colour or linear-gradient, borders (each side's width and
//               colour; dashed and dotted ones as dashed strokes), box shadows (blurred), opacity, transforms,
//               overflow clipping (rounded)
//   svg         react-native-svg's own <svg> elements, copied as they are
//   images      <image> elements; their pixels come back in `images` (data URLs) by id
//   text        each character at the spot Chrome put it, drawn from the app's font outlines
//               (tools/unity/ui/fonts.py): <use> of a glyph defined once per font; text-shadow as a copy under it.
//               Characters the font doesn't have (emoji, symbols from a fallback font) come back in `rasters` with
//               their box, to be cut out of a screenshot.
// Paint order follows CSS for react-native-web's tree: every view is positioned, so siblings paint in tree order
// sorted by z-index.
(function () {
  const FONTS = new Set(window.__snapFonts || []);   // font names with outlines (fonts.py)
  const GLYPHS = window.__snapGlyphs || {};          // font name -> Set of characters it has
  const n2 = (v) => +(+v).toFixed(3);
  const esc = (s) => String(s).replace(/&/g, '&amp;').replace(/"/g, '&quot;').replace(/</g, '&lt;');

  function parseColor(c) {
    if (!c || c === 'transparent') return null;
    const m = c.match(/rgba?\(([^)]+)\)/);
    if (!m) return null;
    const p = m[1].split(/[ ,/]+/).filter(Boolean).map(Number);
    const a = p.length > 3 ? p[3] : 1;
    if (a <= 0) return null;
    return { rgb: `rgb(${p[0]},${p[1]},${p[2]})`, a };
  }
  const fillAttr = (col, name = 'fill') => `${name}="${col.rgb}"${col.a < 1 ? ` ${name}-opacity="${n2(col.a)}"` : ''}`;

  // the element's untransformed box and transform, relative to its parent element's box
  function measure(root) {
    const all = [root, ...root.querySelectorAll('*')];
    const saved = all.map((e) => e.style.transform);
    const tr = all.map((e) => {
      const cs = getComputedStyle(e);
      return { t: cs.transform, o: cs.transformOrigin };
    });
    all.forEach((e) => e.style.setProperty('transform', 'none', 'important'));
    const boxes = new Map();
    all.forEach((e, i) => boxes.set(e, { r: e.getBoundingClientRect(), t: tr[i].t, o: tr[i].o }));
    // transforms stay off while the tree is read (text positions too), and come back after
    boxes.restore = () =>
      all.forEach((e, i) => {
        e.style.removeProperty('transform');
        if (saved[i]) e.style.transform = saved[i];
      });
    return boxes;
  }

  function matrixOf(t) {
    if (!t || t === 'none') return null;
    const m = new DOMMatrix(t);
    return m.isIdentity ? null : m;
  }

  // a rounded rect path (CSS radii, scaled down together when they don't fit, as CSS does)
  function rrect(x, y, w, h, r) {
    let [tl, tr, br, bl] = r.map((v) => Math.max(0, v));
    const f = Math.min(1, w / (tl + tr || 1), w / (bl + br || 1), h / (tl + bl || 1), h / (tr + br || 1));
    if (f < 1) [tl, tr, br, bl] = [tl * f, tr * f, br * f, bl * f];
    if (w <= 0 || h <= 0) return '';
    const k = 0.5522847498;
    const p = [];
    p.push(`M${n2(x + tl)} ${n2(y)}`, `H${n2(x + w - tr)}`);
    if (tr) p.push(`C${n2(x + w - tr + tr * k)} ${n2(y)} ${n2(x + w)} ${n2(y + tr - tr * k)} ${n2(x + w)} ${n2(y + tr)}`);
    p.push(`V${n2(y + h - br)}`);
    if (br) p.push(`C${n2(x + w)} ${n2(y + h - br + br * k)} ${n2(x + w - br + br * k)} ${n2(y + h)} ${n2(x + w - br)} ${n2(y + h)}`);
    p.push(`H${n2(x + bl)}`);
    if (bl) p.push(`C${n2(x + bl - bl * k)} ${n2(y + h)} ${n2(x)} ${n2(y + h - bl + bl * k)} ${n2(x)} ${n2(y + h - bl)}`);
    p.push(`V${n2(y + tl)}`);
    if (tl) p.push(`C${n2(x)} ${n2(y + tl - tl * k)} ${n2(x + tl - tl * k)} ${n2(y)} ${n2(x + tl)} ${n2(y)}`);
    p.push('Z');
    return p.join(' ');
  }

  // CSS linear-gradient(...) -> an SVG gradient in the box's user space
  function gradient(bg, x, y, w, h, defs, ids) {
    const m = bg.match(/^linear-gradient\((.*)\)$/);
    if (!m) return null;
    const parts = m[1].split(/,(?![^(]*\))/).map((s) => s.trim());
    let ang = 180;
    if (/^-?[\d.]+deg$/.test(parts[0])) ang = parseFloat(parts.shift());
    else if (/^to /.test(parts[0])) {
      const d = parts.shift().slice(3);
      const map = { top: 0, right: 90, bottom: 180, left: 270, 'top right': 45, 'right top': 45, 'bottom right': 135, 'right bottom': 135, 'bottom left': 225, 'left bottom': 225, 'top left': 315, 'left top': 315 };
      ang = map[d] ?? 180;
    }
    const a = (ang * Math.PI) / 180;
    const len = Math.abs(w * Math.sin(a)) + Math.abs(h * Math.cos(a));
    const cx = x + w / 2, cy = y + h / 2;
    const dx = (Math.sin(a) * len) / 2, dy = (-Math.cos(a) * len) / 2;
    const stops = parts.map((s, i) => {
      const cm = s.match(/(rgba?\([^)]*\)|#[0-9a-f]+|\w+)\s*([\d.]+%)?/i);
      const col = parseColor(cm[1]) || { rgb: cm[1], a: 1 };
      const off = cm[2] ? parseFloat(cm[2]) / 100 : parts.length === 1 ? 0 : i / (parts.length - 1);
      return `<stop offset="${n2(off)}" stop-color="${col.rgb}"${col.a < 1 ? ` stop-opacity="${n2(col.a)}"` : ''}/>`;
    });
    const id = `lg${ids.n++}`;
    defs.push(`<linearGradient id="${id}" gradientUnits="userSpaceOnUse" x1="${n2(cx - dx)}" y1="${n2(cy - dy)}" x2="${n2(cx + dx)}" y2="${n2(cy + dy)}">${stops.join('')}</linearGradient>`);
    return `url(#${id})`;
  }

  function radii(cs) {
    return [cs.borderTopLeftRadius, cs.borderTopRightRadius, cs.borderBottomRightRadius, cs.borderBottomLeftRadius].map((v) => parseFloat(v) || 0);
  }

  function textOf(e, cs, x0, y0, out, ctx) {
    // the element's own text nodes (react-native-web puts a Text's string straight into its div / span)
    const fam = cs.fontFamily.split(',')[0].replace(/["']/g, '').trim();
    const size = parseFloat(cs.fontSize);
    const col = parseColor(cs.color);
    if (!col) return;
    const shadow = cs.textShadow && cs.textShadow !== 'none' ? cs.textShadow.match(/(rgba?\([^)]*\))\s+(-?[\d.]+)px\s+(-?[\d.]+)px\s+([\d.]+)px/) : null;
    const known = FONTS.has(fam);
    // the baseline: a zero-size inline-block probe sits on it
    for (const node of e.childNodes) {
      if (node.nodeType !== 3 || !node.data.length) continue;
      const probe = document.createElement('span');
      probe.style.cssText = 'display:inline-block;width:0;height:0;vertical-align:baseline';
      node.after(probe);
      const pb = probe.getBoundingClientRect().bottom;
      const range = document.createRange();
      // the last character's line holds the probe: the offset from a character's top to the baseline
      const last = node.data.length - 1;
      range.setStart(node, last); range.setEnd(node, last + 1);
      const lastTop = range.getBoundingClientRect().top;
      probe.remove();
      const base = pb - lastTop;
      const glyphs = [];
      for (let i = 0; i < node.data.length; i++) {
        const ch = node.data[i];
        // (a surrogate pair is one character)
        let len = 1;
        if (/[\ud800-\udbff]/.test(ch)) len = 2;
        range.setStart(node, i); range.setEnd(node, i + len);
        const rects = range.getClientRects();
        const r = rects[0];
        const s = node.data.substr(i, len);
        if (len === 2) i++;
        if (!r || /\s/.test(s)) continue;
        if (known && GLYPHS[fam] && GLYPHS[fam].has(s)) glyphs.push({ ch: s, x: r.left - x0, y: r.top - y0 + base });
        else {
          // drawn by Chrome on its own later (snap-page.mjs), placed here as a picture
          const id = `raster${ctx.rasters.length}`;
          ctx.rasters.push({ id, ch: s, font: cs.fontFamily, size, weight: cs.fontWeight, color: cs.color, w: r.width, h: r.height });
          out.push(`<image href="${id}" x="${n2(r.left - x0)}" y="${n2(r.top - y0)}" width="${n2(r.width)}" height="${n2(r.height)}" preserveAspectRatio="none"/>`);
        }
      }
      if (!glyphs.length) continue;
      // for checking text layout (tools/unity/ui): the run as Chrome placed it
      ctx.texts.push({ s: node.data, font: fam, size, ls: parseFloat(cs.letterSpacing) || 0, xs: glyphs.map((g) => g.x), chars: glyphs.map((g) => g.ch).join(''), y: glyphs[0].y, align: cs.textAlign, w: e.getBoundingClientRect().width, top: e.getBoundingClientRect().top + parseFloat(cs.paddingTop) + parseFloat(cs.borderTopWidth) - y0, lh: cs.lineHeight, h: e.getBoundingClientRect().height });
      const draw = (dx, dy, color, extra = '') => {
        const uses = glyphs.map((g) => {
          const gid = ctx.glyph(fam, g.ch);
          return `<use href="#${gid}" transform="translate(${n2(g.x + dx)} ${n2(g.y + dy)}) scale(${n2(size / ctx.upm(fam))} ${n2(-size / ctx.upm(fam))})"/>`;
        });
        return `<g ${fillAttr(color)}${extra}>${uses.join('')}</g>`;
      };
      if (shadow) {
        const sc = parseColor(shadow[1]);
        const blur = parseFloat(shadow[4]);
        let extra = '';
        if (sc && blur > 0) {
          const id = `ts${ctx.ids.n++}`;
          ctx.defs.push(`<filter id="${id}" x="-20%" y="-20%" width="140%" height="140%"><feGaussianBlur stdDeviation="${n2(blur / 2)}"/></filter>`);
          extra = ` filter="url(#${id})"`;
        }
        if (sc) out.push(draw(parseFloat(shadow[2]), parseFloat(shadow[3]), sc, extra));
      }
      out.push(draw(0, 0, col));
    }
  }

  // one element and everything in it, into `out`, in the coordinates of `root`'s box
  function element(e, boxes, rootBox, out, ctx) {
    const cs = getComputedStyle(e);
    if (cs.display === 'none' || cs.visibility === 'hidden') return;
    const op = parseFloat(cs.opacity);
    if (op <= 0) return;
    const b = boxes.get(e);
    if (!b) return;
    const x = b.r.left - rootBox.left, y = b.r.top - rootBox.top, w = b.r.width, h = b.r.height;
    const inner = [];
    const tag = e.tagName.toLowerCase();

    if (tag === 'svg') {
      const clone = e.cloneNode(true);
      clone.removeAttribute('style');
      clone.removeAttribute('class');
      clone.setAttribute('x', n2(x)); clone.setAttribute('y', n2(y));
      clone.setAttribute('width', n2(w)); clone.setAttribute('height', n2(h));
      if (!clone.getAttribute('viewBox')) clone.setAttribute('viewBox', `0 0 ${n2(w)} ${n2(h)}`);
      clone.setAttribute('overflow', 'visible');
      inner.push(new XMLSerializer().serializeToString(clone).replace(/ xmlns="[^"]*"/, ''));
    } else {
      const r = radii(cs);
      const bw = [cs.borderTopWidth, cs.borderRightWidth, cs.borderBottomWidth, cs.borderLeftWidth].map((v) => parseFloat(v) || 0);
      const bs = [cs.borderTopStyle, cs.borderRightStyle, cs.borderBottomStyle, cs.borderLeftStyle];
      const bc = [cs.borderTopColor, cs.borderRightColor, cs.borderBottomColor, cs.borderLeftColor].map(parseColor);
      const outer = rrect(x, y, w, h, r);
      // box shadows (outer only), under the box
      if (cs.boxShadow && cs.boxShadow !== 'none') {
        for (const s of cs.boxShadow.split(/,(?![^(]*\))/).reverse()) {
          const m = s.trim().match(/(rgba?\([^)]*\))\s+(-?[\d.]+)px\s+(-?[\d.]+)px\s+([\d.]+)px(?:\s+(-?[\d.]+)px)?/);
          if (!m || /inset/.test(s)) continue;
          const col = parseColor(m[1]);
          if (!col) continue;
          const [ox, oy, blur, spread] = [m[2], m[3], m[4], m[5] || 0].map(parseFloat);
          const sp = rrect(x + ox - spread, y + oy - spread, w + 2 * spread, h + 2 * spread, r.map((v) => (v ? v + spread : 0)));
          let f = '';
          if (blur > 0) {
            const id = `bs${ctx.ids.n++}`;
            ctx.defs.push(`<filter id="${id}" x="-50%" y="-50%" width="200%" height="200%"><feGaussianBlur stdDeviation="${n2(blur / 2)}"/></filter>`);
            f = ` filter="url(#${id})"`;
          }
          inner.push(`<path d="${sp}" ${fillAttr(col)}${f}/>`);
        }
      }
      // background colour, then images (gradients)
      const bgc = parseColor(cs.backgroundColor);
      if (bgc && outer) inner.push(`<path d="${outer}" ${fillAttr(bgc)}/>`);
      if (cs.backgroundImage && cs.backgroundImage !== 'none' && outer) {
        for (const layer of cs.backgroundImage.split(/,(?=\s*(?:linear|radial|url)\()/).reverse()) {
          const L = layer.trim();
          if (L.startsWith('linear-gradient')) {
            const g = gradient(L, x, y, w, h, ctx.defs, ctx.ids);
            if (g) inner.push(`<path d="${outer}" fill="${g}"/>`);
          } else if (L.startsWith('url(')) {
            const src = L.slice(4, -1).replace(/^["']|["']$/g, '');
            const id = ctx.image(src);
            const size = cs.backgroundSize;
            const par = size === 'contain' ? 'xMidYMid meet' : size === 'cover' ? 'xMidYMid slice' : 'none';
            const clip = `ic${ctx.ids.n++}`;
            ctx.defs.push(`<clipPath id="${clip}"><path d="${outer}"/></clipPath>`);
            inner.push(`<image href="${id}" x="${n2(x)}" y="${n2(y)}" width="${n2(w)}" height="${n2(h)}" preserveAspectRatio="${par}" clip-path="url(#${clip})"/>`);
          }
        }
      }
      // borders: the ring between the outer box and the padding box; one colour, or each side's own
      if (bw.some((v) => v > 0)) {
        const inR = [Math.max(0, r[0] - Math.max(bw[3], bw[0])), Math.max(0, r[1] - Math.max(bw[0], bw[1])), Math.max(0, r[2] - Math.max(bw[1], bw[2])), Math.max(0, r[3] - Math.max(bw[2], bw[3]))];
        const solid = bs.every((s, i) => !bw[i] || s === 'solid');
        const same = bc.every((c, i) => !bw[i] || (c && bc.find(Boolean) && c.rgb === bc.find(Boolean).rgb && c.a === bc.find(Boolean).a));
        if (solid && same && bc.find(Boolean)) {
          const ring = outer + ' ' + rrect(x + bw[3], y + bw[0], w - bw[1] - bw[3], h - bw[0] - bw[2], inR);
          inner.push(`<path d="${ring}" fill-rule="evenodd" ${fillAttr(bc.find((c, i) => c && bw[i]))}/>`);
        } else if (!solid) {
          // dashed / dotted: a dashed stroke down the middle of the border (Chrome's dash layout differs a little)
          const t = Math.max(...bw), c = bc.find((c, i) => c && bw[i]);
          if (c) {
            const dash = bs.find((s, i) => bw[i] && s !== 'solid') === 'dotted' ? `${n2(t)} ${n2(t)}` : `${n2(t * 3)} ${n2(t * 3)}`;
            const mid = rrect(x + t / 2, y + t / 2, w - t, h - t, r.map((v) => Math.max(0, v - t / 2)));
            inner.push(`<path d="${mid}" fill="none" ${fillAttr(c, 'stroke')} stroke-width="${n2(t)}" stroke-dasharray="${dash}"/>`);
          }
        } else {
          // each side its own colour: the ring cut into four trapezoids at the corners' diagonals
          const ring = outer + ' ' + rrect(x + bw[3], y + bw[0], w - bw[1] - bw[3], h - bw[0] - bw[2], inR);
          const ix = x + bw[3], iy = y + bw[0], iw = w - bw[1] - bw[3], ih = h - bw[0] - bw[2];
          const sides = [
            `M${x} ${y} L${x + w} ${y} L${ix + iw} ${iy} L${ix} ${iy} Z`,
            `M${x + w} ${y} L${x + w} ${y + h} L${ix + iw} ${iy + ih} L${ix + iw} ${iy} Z`,
            `M${x + w} ${y + h} L${x} ${y + h} L${ix} ${iy + ih} L${ix + iw} ${iy + ih} Z`,
            `M${x} ${y + h} L${x} ${y} L${ix} ${iy} L${ix} ${iy + ih} Z`,
          ];
          sides.forEach((sd, i) => {
            if (!bw[i] || !bc[i]) return;
            const id = `bc${ctx.ids.n++}`;
            ctx.defs.push(`<clipPath id="${id}"><path d="${sd}"/></clipPath>`);
            inner.push(`<path d="${ring}" fill-rule="evenodd" ${fillAttr(bc[i])} clip-path="url(#${id})"/>`);
          });
        }
      }
      if (tag === 'img') {
        // react-native-web's Image draws with its background; the <img> itself is invisible (opacity 0)
      }
      textOf(e, cs, rootBox.left, rootBox.top, inner, ctx);
      // children, in paint order, clipped when overflow is hidden
      const kids = [...e.children].map((c, i) => ({ c, i, z: parseInt(getComputedStyle(c).zIndex) || 0 }));
      kids.sort((a, b) => a.z - b.z || a.i - b.i);
      const kidOut = [];
      for (const k of kids) element(k.c, boxes, rootBox, kidOut, ctx);
      if (kidOut.length) {
        if (cs.overflow === 'hidden' || cs.overflowX === 'hidden') {
          const id = `oc${ctx.ids.n++}`;
          const pad = rrect(x + bw[3], y + bw[0], w - bw[1] - bw[3], h - bw[0] - bw[2], r.map((v, i) => Math.max(0, v - Math.max(bw[(i + 3) % 4], bw[i]))));
          ctx.defs.push(`<clipPath id="${id}"><path d="${pad || outer}"/></clipPath>`);
          inner.push(`<g clip-path="url(#${id})">${kidOut.join('')}</g>`);
        } else inner.push(...kidOut);
      }
    }

    if (!inner.length) return;
    const m = e === ctx.root ? null : matrixOf(b.t);
    let attrs = '';
    if (m) {
      const [ox, oy] = b.o.split(' ').map(parseFloat);
      const T = new DOMMatrix().translate(x + ox, y + oy).multiply(m).translate(-(x + ox), -(y + oy));
      attrs += ` transform="matrix(${[T.a, T.b, T.c, T.d, T.e, T.f].map(n2).join(' ')})"`;
    }
    if (op < 1) attrs += ` opacity="${n2(op)}"`;
    out.push(attrs ? `<g${attrs}>${inner.join('')}</g>` : inner.join(''));
  }

  // -> { svg, w, h, images: { id: src }, rasters: [{ ch, font, box (page px), local }] }
  window.__snap = function snap(root, opts = {}) {
    const boxes = measure(root);
    const rootBox = boxes.get(root).r;
    const ctx = {
      root,
      defs: [],
      ids: { n: 0 },
      rasters: [],
      texts: [],
      images: {},
      glyphDefs: new Map(),
      upm: (fam) => (window.__snapUpm || {})[fam] || 1000,
      glyph(fam, ch) {
        const key = fam + '\u0000' + ch;
        if (!this.glyphDefs.has(key)) this.glyphDefs.set(key, { id: `g${this.glyphDefs.size}`, fam, ch });
        return this.glyphDefs.get(key).id;
      },
      image(src) {
        for (const [id, s] of Object.entries(this.images)) if (s === src) return id;
        const id = `img${Object.keys(this.images).length}`;
        this.images[id] = src;
        return id;
      },
    };
    const out = [];
    try {
      element(root, boxes, rootBox, out, ctx);
    } finally {
      boxes.restore();
    }
    const glyphs = [...ctx.glyphDefs.values()].map((g) => `<path id="${g.id}" data-font="${esc(g.fam)}" data-char="${esc(g.ch)}" d="${esc((window.__snapPaths || {})[g.fam]?.[g.ch] || '')}"/>`);
    const w = n2(rootBox.width), h = n2(rootBox.height);
    const svg = `<svg xmlns="http://www.w3.org/2000/svg" width="${w}" height="${h}" viewBox="0 0 ${w} ${h}" overflow="visible"><defs>${glyphs.join('')}${ctx.defs.join('')}</defs>${out.join('')}</svg>`;
    return { svg, w: rootBox.width, h: rootBox.height, x: rootBox.left, y: rootBox.top, images: ctx.images, rasters: ctx.rasters, texts: ctx.texts };
  };
})();

// React's component tree from the page (react-dom's fibers): window.__components(name) lists the components called
// `name` (function name, memo / forwardRef included) as { el: their first DOM element, props } in tree order.
(function () {
  function fiberOf(el) {
    for (const k in el) if (k.startsWith('__reactFiber$') || k.startsWith('__reactContainer$')) return el[k];
    return null;
  }
  const nameOf = (t) => (t ? t.displayName || t.name || (t.type && nameOf(t.type)) || (t.render && nameOf(t.render)) || null : null);
  function hostOf(f) {
    for (let c = f; c; c = c.child) if (c.stateNode instanceof Element) return c.stateNode;
    return null;
  }
  window.__components = function (name, root = document.getElementById('root')) {
    let f = fiberOf(root);
    if (f && f.stateNode && f.stateNode.current) f = f.stateNode.current;   // a container: its root fiber
    const out = [];
    const walk = (x) => {
      for (; x; x = x.sibling) {
        if (typeof x.type !== 'string' && nameOf(x.elementType || x.type) === name) out.push({ el: hostOf(x), props: x.memoizedProps });
        if (x.child) walk(x.child);
      }
    };
    walk(f);
    return out;
  };
})();
