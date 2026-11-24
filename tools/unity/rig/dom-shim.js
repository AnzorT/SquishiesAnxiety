// The part of a browser the creature rigs use, without a browser: an SVG element tree with attributes, the few
// selectors the rig code asks for, innerHTML in and out, inline style, a 2D canvas for the fabric-grain tile, and
// fetch() of the creature art. The rigs (rive-rig.js, rive-generic.js and the move files) run on it unchanged, and
// whoever hosts it reads the element tree every frame and draws it: tools/unity/rig/parity.mjs checks in Node that
// the tree is the same as Chrome's, frame by frame; the Unity app draws it with its own renderer.
//
// Plain ES2017, no Node or browser APIs: install(G, { readFile }) adds window / document / navigator / localStorage /
// fetch / Image / getComputedStyle to the global object G. Timers and requestAnimationFrame come from virtual-clock.js.
(function (root) {
  'use strict';
  var SVG_NS = 'http://www.w3.org/2000/svg';

  // ---------- nodes ----------
  function Node() { this.parentNode = null; this.childNodes = []; }
  Object.defineProperty(Node.prototype, 'firstChild', { get: function () { return this.childNodes[0] || null; } });
  Object.defineProperty(Node.prototype, 'lastChild', { get: function () { return this.childNodes[this.childNodes.length - 1] || null; } });
  Object.defineProperty(Node.prototype, 'nextSibling', { get: function () { var p = this.parentNode; if (!p) return null; var i = p.childNodes.indexOf(this); return p.childNodes[i + 1] || null; } });
  Object.defineProperty(Node.prototype, 'previousSibling', { get: function () { var p = this.parentNode; if (!p) return null; var i = p.childNodes.indexOf(this); return i > 0 ? p.childNodes[i - 1] : null; } });
  Object.defineProperty(Node.prototype, 'parentElement', { get: function () { return this.parentNode && this.parentNode.nodeType === 1 ? this.parentNode : null; } });
  Node.prototype.appendChild = function (n) { return this.insertBefore(n, null); };
  Node.prototype.insertBefore = function (n, ref) {
    if (n.nodeType === 11) { var kids = n.childNodes.slice(); for (var k = 0; k < kids.length; k++) this.insertBefore(kids[k], ref); return n; }
    if (n.parentNode) n.parentNode.removeChild(n);
    var i = ref ? this.childNodes.indexOf(ref) : -1;
    if (i < 0) this.childNodes.push(n); else this.childNodes.splice(i, 0, n);
    n.parentNode = this;
    return n;
  };
  Node.prototype.removeChild = function (n) { var i = this.childNodes.indexOf(n); if (i >= 0) { this.childNodes.splice(i, 1); n.parentNode = null; } return n; };
  Node.prototype.replaceChild = function (n, old) { this.insertBefore(n, old); return this.removeChild(old); };
  // (ChildNode.after / before: develop's rive-rig.js setLight puts a light group after its part's group)
  Node.prototype.after = function () { var p = this.parentNode; if (!p) return; var ref = this.nextSibling; for (var i = 0; i < arguments.length; i++) { var n = arguments[i]; if (typeof n === 'string') n = new Text(n); p.insertBefore(n, ref); } };
  Node.prototype.before = function () { var p = this.parentNode; if (!p) return; for (var i = 0; i < arguments.length; i++) { var n = arguments[i]; if (typeof n === 'string') n = new Text(n); p.insertBefore(n, this); } };
  Node.prototype.remove = function () { if (this.parentNode) this.parentNode.removeChild(this); };
  // (develop's rive-rig.js litTick: whether a part is drawn after the body) DOCUMENT_POSITION_* bits
  Node.prototype.compareDocumentPosition = function (other) {
    if (other === this) return 0;
    var a = [], b = [], n = this; while (n) { a.unshift(n); n = n.parentNode; } n = other; while (n) { b.unshift(n); n = n.parentNode; }
    if (a[0] !== b[0]) return 1 | 32;
    var i = 0; while (i < a.length && i < b.length && a[i] === b[i]) i++;
    if (i === a.length) return 16 | 4;   // other is inside this: contained by, following
    if (i === b.length) return 8 | 2;    // other holds this: contains, preceding
    var p = a[i - 1]; return p.childNodes.indexOf(b[i]) > p.childNodes.indexOf(a[i]) ? 4 : 2;
  };
  Node.prototype.contains = function (n) { while (n) { if (n === this) return true; n = n.parentNode; } return false; };
  Node.prototype.hasChildNodes = function () { return this.childNodes.length > 0; };

  function Text(t) { Node.call(this); this.nodeType = 3; this.data = String(t); }
  Text.prototype = Object.create(Node.prototype);
  Object.defineProperty(Text.prototype, 'textContent', { get: function () { return this.data; }, set: function (v) { this.data = String(v); } });
  Object.defineProperty(Text.prototype, 'nodeValue', { get: function () { return this.data; }, set: function (v) { this.data = String(v); } });
  Text.prototype.cloneNode = function () { return new Text(this.data); };

  function Fragment() { Node.call(this); this.nodeType = 11; }
  Fragment.prototype = Object.create(Node.prototype);

  // inline style: a plain object of camelCase properties, cssText in and out
  var camel = function (s) { return s.trim().replace(/^-webkit-/, 'webkit-').replace(/-([a-z])/g, function (m, c) { return c.toUpperCase(); }); };
  var kebab = function (s) { return s.replace(/[A-Z]/g, function (c) { return '-' + c.toLowerCase(); }).replace(/^webkit-/, '-webkit-'); };
  function Style() {}
  Object.defineProperty(Style.prototype, 'cssText', {
    get: function () { var o = []; for (var k in this) if (Object.prototype.hasOwnProperty.call(this, k) && this[k] !== '' && this[k] != null) o.push(kebab(k) + ': ' + this[k] + ';'); return o.join(' '); },
    set: function (v) { for (var k in this) if (Object.prototype.hasOwnProperty.call(this, k)) delete this[k]; var parts = String(v).split(';'); for (var i = 0; i < parts.length; i++) { var j = parts[i].indexOf(':'); if (j > 0) this[camel(parts[i].slice(0, j))] = parts[i].slice(j + 1).trim(); } }
  });
  Style.prototype.setProperty = function (k, v) { this[camel(k)] = String(v); };
  Style.prototype.getPropertyValue = function (k) { return this[camel(k)] || ''; };
  Style.prototype.removeProperty = function (k) { var c = camel(k), v = this[c] || ''; delete this[c]; return v; };

  function ClassList(el) { this.el = el; }
  ClassList.prototype._get = function () { return (this.el.getAttribute('class') || '').split(/\s+/).filter(Boolean); };
  ClassList.prototype._set = function (a) { this.el.setAttribute('class', a.join(' ')); };
  ClassList.prototype.contains = function (c) { return this._get().indexOf(c) >= 0; };
  ClassList.prototype.add = function () { var a = this._get(); for (var i = 0; i < arguments.length; i++) if (a.indexOf(arguments[i]) < 0) a.push(arguments[i]); this._set(a); };
  ClassList.prototype.remove = function () { var r = [].slice.call(arguments); this._set(this._get().filter(function (c) { return r.indexOf(c) < 0; })); };
  ClassList.prototype.toggle = function (c, on) { var has = this.contains(c); if (on === undefined) on = !has; if (on && !has) this.add(c); if (!on && has) this.remove(c); return on; };

  var NEXT_ID = 1;
  function Element(tag, ns) {
    Node.call(this);
    this.nodeType = 1;
    this.namespaceURI = ns || SVG_NS;
    // like a browser: HTML element names in capitals (DIV), SVG ones as written (clipPath)
    this.localName = this.namespaceURI === SVG_NS ? tag : String(tag).toLowerCase();
    this.tagName = this.nodeName = this.namespaceURI === SVG_NS ? tag : this.localName.toUpperCase();
    this._attrs = [];           // [name, value] in the order they were first set (what Chrome serializes)
    this.style = new Style();
    this._listeners = {};
    this.__id = NEXT_ID++;
  }
  Element.prototype = Object.create(Node.prototype);
  Element.prototype.setAttribute = function (k, v) {
    k = String(k); v = String(v);
    if (k === 'style') { this.style.cssText = v; return; }
    for (var i = 0; i < this._attrs.length; i++) if (this._attrs[i][0] === k) { this._attrs[i][1] = v; return; }
    this._attrs.push([k, v]);
  };
  Element.prototype.setAttributeNS = function (ns, k, v) { this.setAttribute(k, v); };
  Element.prototype.getAttribute = function (k) {
    if (k === 'style') { var s = this.style.cssText; return s || null; }
    for (var i = 0; i < this._attrs.length; i++) if (this._attrs[i][0] === k) return this._attrs[i][1];
    return null;
  };
  Element.prototype.getAttributeNS = function (ns, k) { return this.getAttribute(k); };
  Element.prototype.hasAttribute = function (k) { return this.getAttribute(k) !== null; };
  Element.prototype.removeAttribute = function (k) {
    if (k === 'style') { this.style.cssText = ''; return; }
    for (var i = 0; i < this._attrs.length; i++) if (this._attrs[i][0] === k) { this._attrs.splice(i, 1); return; }
  };
  Object.defineProperty(Element.prototype, 'attributes', { get: function () { return this._attrs.map(function (a) { return { name: a[0], value: a[1], nodeName: a[0], nodeValue: a[1] }; }); } });
  Object.defineProperty(Element.prototype, 'children', { get: function () { return this.childNodes.filter(function (n) { return n.nodeType === 1; }); } });
  Object.defineProperty(Element.prototype, 'childElementCount', { get: function () { return this.children.length; } });
  Object.defineProperty(Element.prototype, 'firstElementChild', { get: function () { return this.children[0] || null; } });
  Object.defineProperty(Element.prototype, 'lastElementChild', { get: function () { var c = this.children; return c[c.length - 1] || null; } });
  Object.defineProperty(Element.prototype, 'classList', { get: function () { return new ClassList(this); } });
  Object.defineProperty(Element.prototype, 'id', { get: function () { return this.getAttribute('id') || ''; }, set: function (v) { this.setAttribute('id', v); } });
  Object.defineProperty(Element.prototype, 'className', { get: function () { return this.getAttribute('class') || ''; }, set: function (v) { this.setAttribute('class', v); } });
  Object.defineProperty(Element.prototype, 'textContent', {
    get: function () { return this.childNodes.map(function (n) { return n.textContent; }).join(''); },
    set: function (v) { this.childNodes.forEach(function (n) { n.parentNode = null; }); this.childNodes = []; if (v !== '' && v != null) this.appendChild(new Text(v)); }
  });
  Object.defineProperty(Element.prototype, 'innerHTML', {
    get: function () { return this.childNodes.map(serialize).join(''); },
    set: function (v) { this.childNodes.forEach(function (n) { n.parentNode = null; }); this.childNodes = []; parseInto(this, String(v), this.namespaceURI); }
  });
  Object.defineProperty(Element.prototype, 'outerHTML', { get: function () { return serialize(this); } });
  Element.prototype.cloneNode = function (deep) {
    var e = new Element(this.tagName, this.namespaceURI);
    e._attrs = this._attrs.map(function (a) { return [a[0], a[1]]; });
    e.style.cssText = this.style.cssText;
    if (deep) this.childNodes.forEach(function (c) { e.appendChild(c.cloneNode(true)); });
    return e;
  };
  Element.prototype.addEventListener = function (t, fn) { (this._listeners[t] = this._listeners[t] || []).push(fn); };
  Element.prototype.removeEventListener = function (t, fn) { var a = this._listeners[t]; if (a) { var i = a.indexOf(fn); if (i >= 0) a.splice(i, 1); } };
  Element.prototype.dispatchEvent = function (ev) { ev.target = ev.target || this; var a = (this._listeners[ev.type] || []).slice(); for (var i = 0; i < a.length; i++) a[i].call(this, ev); return true; };
  Element.prototype.insertAdjacentHTML = function (where, html) {
    var f = new Fragment(); parseInto(f, String(html), this.namespaceURI);
    if (where === 'beforeend') this.appendChild(f);
    else if (where === 'afterbegin') this.insertBefore(f, this.firstChild);
    else if (where === 'beforebegin' && this.parentNode) this.parentNode.insertBefore(f, this);
    else if (where === 'afterend' && this.parentNode) this.parentNode.insertBefore(f, this.nextSibling);
  };
  Element.prototype.insertAdjacentElement = function (where, el) { var f = new Fragment(); f.appendChild(el); var h = this; if (where === 'beforeend') h.appendChild(el); else if (where === 'afterbegin') h.insertBefore(el, h.firstChild); else if (where === 'beforebegin') h.parentNode.insertBefore(el, h); else h.parentNode.insertBefore(el, h.nextSibling); return el; };
  Element.prototype.append = function () { for (var i = 0; i < arguments.length; i++) { var a = arguments[i]; this.appendChild(typeof a === 'string' ? new Text(a) : a); } };
  Element.prototype.prepend = function () { var first = this.firstChild; for (var i = 0; i < arguments.length; i++) { var a = arguments[i]; this.insertBefore(typeof a === 'string' ? new Text(a) : a, first); } };
  Object.defineProperty(Element.prototype, 'nextElementSibling', { get: function () { var n = this.nextSibling; while (n && n.nodeType !== 1) n = n.nextSibling; return n; } });
  Object.defineProperty(Element.prototype, 'previousElementSibling', { get: function () { var n = this.previousSibling; while (n && n.nodeType !== 1) n = n.previousSibling; return n; } });
  Object.defineProperty(Element.prototype, 'ownerSVGElement', { get: function () { var p = this.parentNode; while (p && p.nodeType === 1) { if (p.localName === 'svg') return p; p = p.parentNode; } return null; } });
  Object.defineProperty(Element.prototype, 'isConnected', { get: function () { var p = this; while (p.parentNode) p = p.parentNode; return !!p.__isRoot; } });
  Object.defineProperty(Element.prototype, 'dataset', { get: function () {
    var el = this;
    // (the compiled realm has no Proxy: there, a copy of the data-* attributes to read, which is all its scripts do —
    // the yard games' posters, yg-intros.js)
    if (typeof Proxy === 'undefined') {
      var o = {}, a = el._attrs || [];
      for (var i = 0; i < a.length; i++) if (a[i][0].indexOf('data-') === 0) o[a[i][0].slice(5).replace(/-([a-z])/g, function (m, c) { return c.toUpperCase(); })] = a[i][1];
      return o;
    }
    return new Proxy({}, { get: function (t, k) { var v = el.getAttribute('data-' + kebab(String(k))); return v === null ? undefined : v; },
      set: function (t, k, v) { el.setAttribute('data-' + kebab(String(k)), v); return true; }, deleteProperty: function (t, k) { el.removeAttribute('data-' + kebab(String(k))); return true; } }); } });
  Element.prototype.setPointerCapture = function () {};
  Element.prototype.releasePointerCapture = function () {};
  Element.prototype.hasPointerCapture = function () { return false; };
  Element.prototype.focus = function () {};
  Element.prototype.blur = function () {};
  // the host's box, in CSS px (only read by pointer handlers); the host sets el.__rect
  Element.prototype.getBoundingClientRect = function () {
    var e = this; while (e && !e.__rect) e = e.parentNode;
    var r = (e && e.__rect) || { left: 0, top: 0, width: 100, height: 100 };
    return { left: r.left, top: r.top, x: r.left, y: r.top, width: r.width, height: r.height, right: r.left + r.width, bottom: r.top + r.height };
  };
  Element.prototype.getBBox = function () { return bbox(this); };
  Element.prototype.matches = function (sel) { return matchesList(this, parseSelectors(sel)); };
  Element.prototype.closest = function (sel) { var s = parseSelectors(sel), e = this; while (e && e.nodeType === 1) { if (matchesList(e, s)) return e; e = e.parentNode; } return null; };
  Element.prototype.querySelectorAll = function (sel) { var s = parseSelectors(sel), out = []; walk(this, function (e) { if (matchesList(e, s)) out.push(e); }); return out; };
  Element.prototype.querySelector = function (sel) { var s = parseSelectors(sel), hit = null; walk(this, function (e) { if (!hit && matchesList(e, s)) hit = e; }); return hit; };
  Element.prototype.getElementsByTagName = function (t) { return this.querySelectorAll(t); };
  Element.prototype.getContext = function (kind) { return kind === '2d' && this.localName === 'canvas' ? (this._ctx = this._ctx || new Ctx2D(this)) : null; };
  Element.prototype.toDataURL = function () { var id = 'shim-canvas:' + this.__id; CANVASES[id] = this; return id; };
  Object.defineProperty(Element.prototype, 'width', { get: function () { return +(this.getAttribute('width') || (this.localName === 'canvas' ? 300 : 0)); }, set: function (v) { this.setAttribute('width', v); } });
  Object.defineProperty(Element.prototype, 'height', { get: function () { return +(this.getAttribute('height') || (this.localName === 'canvas' ? 150 : 0)); }, set: function (v) { this.setAttribute('height', v); } });

  function walk(el, fn) { for (var i = 0; i < el.childNodes.length; i++) { var c = el.childNodes[i]; if (c.nodeType === 1) { fn(c); walk(c, fn); } } }

  // ---------- selectors: tag, #id, .class, [a], [a=v], [a^=v], [a$=v], [a*=v], descendant and child combinators, lists ----------
  var SEL_CACHE = {};
  function parseSelectors(sel) {
    if (SEL_CACHE[sel]) return SEL_CACHE[sel];
    var list = splitTop(sel, ',').map(function (one) {
      var steps = [], comb = ' ', re = /\s*(>)\s*|\s+|([^\s>]+)/g, m;
      one = one.trim();
      while ((m = re.exec(one))) {
        if (m[1]) { comb = '>'; continue; }
        if (!m[2]) { if (steps.length) comb = comb === '>' ? '>' : ' '; continue; }
        steps.push({ comb: steps.length ? comb : null, parts: compound(m[2]) }); comb = ' ';
      }
      return steps;
    });
    return (SEL_CACHE[sel] = list);
  }
  function splitTop(s, ch) { var out = [], d = 0, q = null, cur = ''; for (var i = 0; i < s.length; i++) { var c = s[i]; if (q) { if (c === q) q = null; } else if (c === '"' || c === "'") q = c; else if (c === '[') d++; else if (c === ']') d--; else if (c === ch && !d) { out.push(cur); cur = ''; continue; } cur += c; } out.push(cur); return out; }
  function compound(s) {
    var p = { tag: null, id: null, cls: [], attrs: [] }, re = /([a-zA-Z][\w-]*)|#([\w-]+)|\.([\w-]+)|\[\s*([\w:-]+)\s*(?:([\^$*~|]?=)\s*(?:"([^"]*)"|'([^']*)'|([^\]\s]*)))?\s*\]|(\*)/g, m;
    while ((m = re.exec(s))) {
      if (m[1]) p.tag = m[1].toLowerCase(); else if (m[2]) p.id = m[2]; else if (m[3]) p.cls.push(m[3]);
      else if (m[4]) p.attrs.push({ name: m[4], op: m[5] || null, val: m[6] != null ? m[6] : m[7] != null ? m[7] : m[8] });
    }
    return p;
  }
  function matchCompound(e, p) {
    if (p.tag && e.localName.toLowerCase() !== p.tag) return false;
    if (p.id && e.getAttribute('id') !== p.id) return false;
    if (p.cls.length) { var c = (e.getAttribute('class') || '').split(/\s+/); for (var i = 0; i < p.cls.length; i++) if (c.indexOf(p.cls[i]) < 0) return false; }
    for (var j = 0; j < p.attrs.length; j++) {
      var a = p.attrs[j], v = e.getAttribute(a.name);
      if (v === null) return false;
      if (!a.op) continue;
      if (a.op === '=' && v !== a.val) return false;
      if (a.op === '^=' && v.indexOf(a.val) !== 0) return false;
      if (a.op === '$=' && v.slice(-a.val.length) !== a.val) return false;
      if (a.op === '*=' && v.indexOf(a.val) < 0) return false;
      if (a.op === '~=' && v.split(/\s+/).indexOf(a.val) < 0) return false;
    }
    return true;
  }
  function matchSteps(e, steps, k) {
    if (!matchCompound(e, steps[k].parts)) return false;
    if (k === 0) return true;
    var comb = steps[k].comb, p = e.parentNode;
    if (comb === '>') return !!p && p.nodeType === 1 && matchSteps(p, steps, k - 1);
    while (p && p.nodeType === 1) { if (matchSteps(p, steps, k - 1)) return true; p = p.parentNode; }
    return false;
  }
  function matchesList(e, list) { for (var i = 0; i < list.length; i++) if (matchSteps(e, list[i], list[i].length - 1)) return true; return false; }

  // ---------- markup in and out ----------
  var VOID_HTML = { br: 1, img: 1, input: 1, hr: 1, meta: 1, link: 1 };
  var ENT = { amp: '&', lt: '<', gt: '>', quot: '"', apos: "'", nbsp: ' ' };
  var unescape = function (s) { return s.replace(/&(#x[0-9a-f]+|#\d+|[a-z]+);/gi, function (m, e) { if (e[0] === '#') return String.fromCharCode(e[1] === 'x' || e[1] === 'X' ? parseInt(e.slice(2), 16) : +e.slice(1)); return ENT[e] != null ? ENT[e] : m; }); };
  function parseInto(parent, html, ns) {
    var stack = [parent], i = 0, n = html.length;
    while (i < n) {
      var lt = html.indexOf('<', i);
      if (lt < 0) lt = n;
      if (lt > i) { var t = html.slice(i, lt); if (t.trim() || stack.length > 1) stack[stack.length - 1].appendChild(new Text(unescape(t))); }
      if (lt >= n) break;
      if (html.startsWith('<!--', lt)) { var e = html.indexOf('-->', lt + 4); i = e < 0 ? n : e + 3; continue; }
      if (html[lt + 1] === '!' || html[lt + 1] === '?') { var e2 = html.indexOf('>', lt); i = e2 < 0 ? n : e2 + 1; continue; }
      if (html[lt + 1] === '/') { var e3 = html.indexOf('>', lt); var name = html.slice(lt + 2, e3).trim(); for (var s = stack.length - 1; s > 0; s--) if (stack[s].localName === name || stack[s].tagName === name) { stack.length = s; break; } i = e3 + 1; continue; }
      var m = /^<([a-zA-Z][\w:.-]*)/.exec(html.slice(lt, lt + 64));
      if (!m) { stack[stack.length - 1].appendChild(new Text('<')); i = lt + 1; continue; }
      var tag = m[1], j = lt + m[0].length, el = new Element(tag, tag === 'svg' ? SVG_NS : stack[stack.length - 1].namespaceURI || ns);
      // attributes
      var are = /\s*([^\s"'>\/=]+)(?:\s*=\s*(?:"([^"]*)"|'([^']*)'|([^\s"'=<>`]+)))?|\s*(\/?)>/g; are.lastIndex = j;
      var selfClose = false, am;
      while ((am = are.exec(html))) {
        if (am.index !== are.lastIndex - am[0].length) break;
        if (am[5] !== undefined && am[0].trim().slice(-1) === '>') { selfClose = am[5] === '/'; j = are.lastIndex; break; }
        el.setAttribute(am[1], unescape(am[2] != null ? am[2] : am[3] != null ? am[3] : am[4] != null ? am[4] : ''));
        j = are.lastIndex;
      }
      stack[stack.length - 1].appendChild(el);
      i = j;
      if (!selfClose && !(el.namespaceURI !== SVG_NS && VOID_HTML[tag.toLowerCase()])) stack.push(el);
    }
  }
  var escAttr = function (s) { return s.replace(/&/g, '&amp;').replace(/"/g, '&quot;').replace(/ /g, '&nbsp;').replace(/</g, '&lt;').replace(/>/g, '&gt;'); };
  var escText = function (s) { return s.replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;').replace(/ /g, '&nbsp;'); };
  function serialize(n) {
    if (n.nodeType === 3) return escText(n.data);
    if (n.nodeType === 11) return n.childNodes.map(serialize).join('');
    var a = '', attrs = n._attrs.slice();
    var st = n.style.cssText; if (st) attrs.push(['style', st]);
    for (var i = 0; i < attrs.length; i++) a += ' ' + attrs[i][0] + '="' + escAttr(attrs[i][1]) + '"';
    return '<' + n.localName + a + '>' + n.childNodes.map(serialize).join('') + '</' + n.localName + '>';
  }

  // ---------- geometry: getBBox, the way Blink computes it ----------
  // Each shape's box in 32-bit floats (rect: x, y, w, h; circle / ellipse: centre minus radius, twice the radius; path:
  // Skia's tight bounds), a group's box the union of its children's boxes mapped through their transforms (the four
  // corners, not the tight outline). The rigs feed these numbers into the shapes they draw, so they have to match to
  // the last bit (rive-generic.js sizes the shadow from one).
  var F = Math.fround;
  // what getBBox returns: like the browser's SVGRect, its numbers are getters on the prototype, not own properties.
  // That matters: rive-generic.js copies a box with Object.assign({}, box), which in a browser copies nothing (and
  // makes some creatures' shadow width NaN, e.g. Kiko's). Same here, so the creatures draw exactly as in the app.
  function SVGRect(x, y, w, h) { this._r = [x, y, w, h]; }
  ['x', 'y', 'width', 'height'].forEach(function (k, i) {
    Object.defineProperty(SVGRect.prototype, k, { get: function () { return this._r[i]; }, set: function (v) { this._r[i] = +v; }, enumerable: true });
  });
  Object.defineProperty(SVGRect.prototype, '_r', { writable: true, enumerable: false, value: null });
  function bbox(el) {
    var r = boxOf(el), o = Object.create(SVGRect.prototype);
    Object.defineProperty(o, '_r', { value: r ? [r.x, r.y, r.w, r.h] : [0, 0, 0, 0], writable: true, enumerable: false });
    return o;
  }
  function rect(x, y, w, h) { return { x: F(x), y: F(y), w: F(w), h: F(h) }; }
  // gfx::RectF from its edges: if float rounding left x + width short of the right edge, the width becomes the next
  // float up (RectF::SetByBounds / UnionEvenIfEmpty: "may not fully contain ... expand the rect"); same for height
  var F32 = new Float32Array(1), U32 = new Uint32Array(F32.buffer);
  function nextUp(v) { if (v !== v || v === Infinity) return v; if (v === 0) return F(1.401298464324817e-45); F32[0] = v; U32[0] += v > 0 ? 1 : -1; return F32[0]; }
  function fromBounds(l, t, r, b) {
    var w = F(r - l), h = F(b - t);
    if (F(l + w) < r) w = nextUp(w);
    if (F(t + h) < b) h = nextUp(h);
    return { x: l, y: t, w: w, h: h };
  }
  function unite(a, b) {
    if (!a) return b; if (!b) return a;
    var x0 = Math.min(a.x, b.x), y0 = Math.min(a.y, b.y), x1 = Math.max(F(a.x + a.w), F(b.x + b.w)), y1 = Math.max(F(a.y + a.h), F(b.y + b.h));
    return fromBounds(x0, y0, x1, y1);
  }
  function mapRect(m, r) {
    if (!m) return r;
    var xs = [], ys = [], pts = [[r.x, r.y], [F(r.x + r.w), r.y], [F(r.x + r.w), F(r.y + r.h)], [r.x, F(r.y + r.h)]];
    for (var i = 0; i < 4; i++) { xs.push(F(m[0] * pts[i][0] + m[2] * pts[i][1] + m[4])); ys.push(F(m[1] * pts[i][0] + m[3] * pts[i][1] + m[5])); }
    var x0 = Math.min.apply(null, xs), y0 = Math.min.apply(null, ys), x1 = Math.max.apply(null, xs), y1 = Math.max.apply(null, ys);
    return fromBounds(x0, y0, x1, y1);
  }

  // A path's box as Blink gets it: the path data parsed to floats and normalised (absolute points, H/V as lines, S as
  // C, T as Q, arcs as Skia's conics from SkPath::arcTo), then
  // Skia's SkPath::computeTightBounds: each curve's extrema (SkFindCubicExtrema / SkFindUnitQuadRoots) evaluated with
  // SkCubicCoeff, every operation rounded to a 32-bit float.
  function validUnitDivide(n, d) { if (n < 0) { n = -n; d = -d; } if (d === 0 || n === 0 || n >= d) return null; var r = F(n / d); return (r !== r || r === 0) ? null : r; }
  function unitQuadRoots(A, B, C) {
    if (A === 0) { var r0 = validUnitDivide(-C, B); return r0 === null ? [] : [r0]; }
    var dr = B * B - 4 * A * C;
    if (dr < 0) return [];
    var R = F(Math.sqrt(dr));
    if (!isFinite(R)) return [];
    var Q = B < 0 ? F(-F(F(B - R) / 2)) : F(-F(F(B + R) / 2)), out = [], a = validUnitDivide(Q, A), b = validUnitDivide(C, Q);
    if (a !== null) out.push(a); if (b !== null) out.push(b);
    if (out.length === 2) { if (out[0] > out[1]) out.reverse(); else if (out[0] === out[1]) out.pop(); }
    return out;
  }
  function cubicExtremaT(a, b, c, d) { return unitQuadRoots(F(F(d - a) + F(3 * F(b - c))), F(2 * F(F(F(a - b) - b) + c)), F(b - a)); }
  function evalCubic(p, t, k) {   // k: 0 = x, 1 = y
    var P0 = p[0][k], P1 = p[1][k], P2 = p[2][k], P3 = p[3][k];
    var A = F(F(P3 + F(3 * F(P1 - P2))) - P0), B = F(3 * F(F(P2 - F(2 * P1)) + P0)), C = F(3 * F(P1 - P0));
    return F(F(F(F(F(F(A * t) + B) * t) + C) * t) + P0);
  }
  // SkPath::arcTo (the SVG form Blink uses): the arc as conics, float maths as Skia does it
  var SINZ = function (r) { var v = F(Math.sin(r)); return Math.abs(v) <= F(1 / 4096) ? 0 : v; };
  var COSZ = function (r) { var v = F(Math.cos(r)); return Math.abs(v) <= F(1 / 4096) ? 0 : v; };
  var PIF = F(Math.PI), DEG = F(PIF / 180);
  function rotM(deg) { var rad = F(F(deg) * DEG); return [COSZ(rad), SINZ(rad)]; }   // SkMatrix::setRotate: [cos, sin]
  function arcToConics(cur, rx, ry, angle, large, sweep, to) {
    if (!rx || !ry) return null;
    if (cur[0] === to[0] && cur[1] === to[1]) return null;
    rx = F(Math.abs(rx)); ry = F(Math.abs(ry));
    var mdx = F(F(cur[0] - to[0]) * 0.5), mdy = F(F(cur[1] - to[1]) * 0.5);
    var r1 = rotM(-angle), tmx = F(F(mdx * r1[0]) + F(mdy * -r1[1])), tmy = F(F(mdy * r1[0]) + F(mdx * r1[1]));
    if (r1[1] === 0 && r1[0] === 1) { tmx = mdx; tmy = mdy; }
    var srx = F(rx * rx), sry = F(ry * ry), sx = F(tmx * tmx), sy = F(tmy * tmy);
    var rs = F(F(sx / srx) + F(sy / sry));
    if (rs > 1) { rs = F(Math.sqrt(rs)); rx = F(rx * rs); ry = F(ry * rs); }
    // pointTransform = scale(1/rx, 1/ry) * rotate(-angle)
    // setScale(1/rx, 1/ry).preRotate(-angle): the product's entries rounded once (Skia's muladdmul), then
    // x' = x sx + y kx, y' = y sy + x ky
    var irx = F(1 / rx), iry = F(1 / ry), USX = F(irx * r1[0]), UKX = F(irx * -r1[1]), UKY = F(iry * r1[1]), USY = F(iry * r1[0]);
    var mapU = function (p) {
      if (r1[1] === 0 && r1[0] === 1) return [F(p[0] * irx), F(p[1] * iry)];
      return [F(F(p[0] * USX) + F(p[1] * UKX)), F(F(p[1] * USY) + F(p[0] * UKY))];
    };
    var u0 = mapU(cur), u1 = mapU(to), dx = F(u1[0] - u0[0]), dy = F(u1[1] - u0[1]);
    var dd = F(F(dx * dx) + F(dy * dy)), sfs = Math.max(F(F(1 / dd) - 0.25), 0), sf = F(Math.sqrt(sfs));
    var ccw = !sweep;
    if (ccw !== !!large) sf = -sf;
    dx = F(dx * sf); dy = F(dy * sf);
    var cx = F(F(F(u0[0] + u1[0]) * 0.5) - dy), cy = F(F(F(u0[1] + u1[1]) * 0.5) + dx);
    var a0x = F(u0[0] - cx), a0y = F(u0[1] - cy), a1x = F(u1[0] - cx), a1y = F(u1[1] - cy);
    var th1 = F(Math.atan2(a0y, a0x)), th2 = F(Math.atan2(a1y, a1x)), arc = F(th2 - th1), PI2 = F(PIF * 2);
    if (arc < 0 && sweep) arc = F(arc + PI2); else if (arc > 0 && !sweep) arc = F(arc - PI2);
    if (Math.abs(arc) < F(PIF / (1000 * 1000))) return null;
    // setRotate(angle).preScale(rx, ry): each column scaled in place
    var r2m = rotM(angle), BSX = F(r2m[0] * rx), BKY = F(r2m[1] * rx), BKX = F(-r2m[1] * ry), BSY = F(r2m[0] * ry);
    var mapB = function (p) {
      if (r2m[1] === 0 && r2m[0] === 1) return [F(p[0] * rx), F(p[1] * ry)];
      return [F(F(p[0] * BSX) + F(p[1] * BKX)), F(F(p[1] * BSY) + F(p[0] * BKY))];
    };
    var segs = Math.ceil(Math.abs(F(arc / F(F(2 * PIF) / 3)))), tw = F(arc / segs), t = F(Math.tan(F(0.5 * tw)));
    if (!isFinite(t)) return [];
    var w = F(Math.sqrt(F(0.5 + F(F(Math.cos(tw)) * 0.5))));
    var isInt = function (v) { return v === Math.floor(v); };
    var expectInts = Math.abs(F(F(PIF / 2) - Math.abs(tw))) <= F(1 / 4096) && isInt(rx) && isInt(ry) && isInt(to[0]) && isInt(to[1]);
    var out = [], st = th1;
    for (var i = 0; i < segs; i++) {
      var et = F(st + tw), se = SINZ(et), ce = COSZ(et);
      var p1 = [F(ce + cx), F(se + cy)], p0 = [F(p1[0] + F(t * se)), F(p1[1] - F(t * ce))];
      var m0 = mapB(p0), m1 = mapB(p1);
      if (expectInts) { m0 = [Math.round(m0[0]), Math.round(m0[1])]; m1 = [Math.round(m1[0]), Math.round(m1[1])]; }
      out.push([m0, m1, w]);
      st = et;
    }
    if (out.length) out[out.length - 1][1] = [to[0], to[1]];   // setLastPt(x, y)
    return out;
  }
  function conicExtremaT(a, b, c, w) {   // conic_find_extrema: one root of the derivative, or none
    var P20 = F(c - a), P10 = F(b - a), wP10 = F(w * P10);
    var r = unitQuadRoots(F(F(w * P20) - P20), F(P20 - F(2 * wP10)), wP10);
    return r.length === 1 ? r : [];
  }
  function evalConic(p, w, t, k) {
    var p0 = p[0][k], p1w = F(p[1][k] * w), p2 = p[2][k];
    var nA = F(F(p2 - F(2 * p1w)) + p0), nB = F(2 * F(p1w - p0));
    var dB = F(2 * F(w - 1)), dA = F(0 - dB);
    var num = F(F(F(F(nA * t) + nB) * t) + p0), den = F(F(F(F(dA * t) + dB) * t) + 1);
    return F(num / den);
  }
  function pathTight(d) {
    var tk = d.match(/[a-zA-Z]|[-+]?(?:\d*\.\d+|\d+\.?)(?:[eE][-+]?\d+)?/g) || [], i = 0, cmd = '';
    var cur = [0, 0], start = [0, 0], lastC = null, lastQ = null, segs = [];
    var n = function () { return F(+tk[i++]); };
    var abs = function (rel, x, y) { return rel ? [F(cur[0] + x), F(cur[1] + y)] : [x, y]; };
    while (i < tk.length) {
      if (/[a-zA-Z]/.test(tk[i])) cmd = tk[i++];
      var C = cmd.toUpperCase(), rel = cmd !== C, p;
      if (C === 'Z') { segs.push({ v: 'Z' }); cur = start; lastC = lastQ = null; if (i < tk.length && !/[a-zA-Z]/.test(tk[i])) i++; continue; }
      if (i >= tk.length) break;
      if (C === 'M') { p = abs(rel, n(), n()); segs.push({ v: 'M', p: [p] }); cur = start = p; cmd = rel ? 'l' : 'L'; lastC = lastQ = null; continue; }
      if (C === 'L') { p = abs(rel, n(), n()); segs.push({ v: 'L', p: [cur, p] }); cur = p; lastC = lastQ = null; continue; }
      if (C === 'H') { var hx = n(); p = [rel ? F(cur[0] + hx) : hx, cur[1]]; segs.push({ v: 'L', p: [cur, p] }); cur = p; lastC = lastQ = null; continue; }
      if (C === 'V') { var vy = n(); p = [cur[0], rel ? F(cur[1] + vy) : vy]; segs.push({ v: 'L', p: [cur, p] }); cur = p; lastC = lastQ = null; continue; }
      if (C === 'C' || C === 'S') {
        var c1;
        if (C === 'C') c1 = abs(rel, n(), n()); else c1 = lastC ? [F(F(2 * cur[0]) - lastC[0]), F(F(2 * cur[1]) - lastC[1])] : cur;
        var c2 = abs(rel, n(), n()), e = abs(rel, n(), n());
        segs.push({ v: 'C', p: [cur, c1, c2, e] }); lastC = c2; lastQ = null; cur = e; continue;
      }
      if (C === 'Q' || C === 'T') {
        var qc = C === 'Q' ? abs(rel, n(), n()) : (lastQ ? [F(F(2 * cur[0]) - lastQ[0]), F(F(2 * cur[1]) - lastQ[1])] : cur);
        var qe = abs(rel, n(), n());
        segs.push({ v: 'Q', p: [cur, qc, qe] }); lastQ = qc; lastC = null; cur = qe; continue;
      }
      if (C === 'A') {
        var rx = n(), ry = n(), ang = n(), lg = n(), sw = n(), to = abs(rel, n(), n()), conics = arcToConics(cur, rx, ry, ang, lg, sw, to);
        if (!conics) segs.push({ v: 'L', p: [cur, to] });
        else { var from = cur; for (var k = 0; k < conics.length; k++) { segs.push({ v: 'K', p: [from, conics[k][0], conics[k][1]], w: conics[k][2] }); from = conics[k][1]; } }
        cur = to; lastC = lastQ = null; continue;
      }
      i++;
    }
    if (!segs.length) return null;
    var first = segs[0].p ? segs[0].p[0] : [0, 0], x0 = first[0], y0 = first[1], x1 = x0, y1 = y0;
    var add = function (x, y) { if (x < x0) x0 = x; if (x > x1) x1 = x; if (y < y0) y0 = y; if (y > y1) y1 = y; };
    for (var s2 = 0; s2 < segs.length; s2++) {
      var g = segs[s2];
      if (g.v === 'M') add(g.p[0][0], g.p[0][1]);
      else if (g.v === 'L') add(g.p[1][0], g.p[1][1]);
      else if (g.v === 'K') {
        var kts = conicExtremaT(g.p[0][0], g.p[1][0], g.p[2][0], g.w).concat(conicExtremaT(g.p[0][1], g.p[1][1], g.p[2][1], g.w));
        for (var jk = 0; jk < kts.length; jk++) add(evalConic(g.p, g.w, kts[jk], 0), evalConic(g.p, g.w, kts[jk], 1));
        add(g.p[2][0], g.p[2][1]);
      }
      else if (g.v === 'Q') {
        // SkFindQuadExtrema + SkQuadCoeff (fA = P2 - 2 P1 + P0, fB = 2 (P1 - P0), (fA t + fB) t + P0)
        var qts = [], qa = validUnitDivide(F(g.p[0][0] - g.p[1][0]), F(F(F(g.p[0][0] - g.p[1][0]) - g.p[1][0]) + g.p[2][0])), qb = validUnitDivide(F(g.p[0][1] - g.p[1][1]), F(F(F(g.p[0][1] - g.p[1][1]) - g.p[1][1]) + g.p[2][1]));
        if (qa !== null) qts.push(qa); if (qb !== null) qts.push(qb);
        for (var jq = 0; jq < qts.length; jq++) {
          var tq = qts[jq], ev = function (k) { var P0 = g.p[0][k], P1 = g.p[1][k], P2 = g.p[2][k], A = F(F(P2 - F(2 * P1)) + P0), B = F(2 * F(P1 - P0)); return F(F(F(F(A * tq) + B) * tq) + P0); };
          add(ev(0), ev(1));
        }
        add(g.p[2][0], g.p[2][1]);
      }
      else if (g.v === 'C') {
        var ts = cubicExtremaT(g.p[0][0], g.p[1][0], g.p[2][0], g.p[3][0]).concat(cubicExtremaT(g.p[0][1], g.p[1][1], g.p[2][1], g.p[3][1]));
        for (var j = 0; j < ts.length; j++) add(evalCubic(g.p, ts[j], 0), evalCubic(g.p, ts[j], 1));
        add(g.p[3][0], g.p[3][1]);
      }
    }
    return fromBounds(x0, y0, x1, y1);
  }
  function boxOf(el) {
    var tag = el.localName, num = function (k) { return F(parseFloat(el.getAttribute(k) || '0') || 0); };
    if (tag === 'path') return pathTight(el.getAttribute('d') || '');
    if (tag === 'rect') return rect(num('x'), num('y'), num('width'), num('height'));
    if (tag === 'circle') { var r = num('r'); return rect(F(num('cx') - r), F(num('cy') - r), F(r * 2), F(r * 2)); }
    if (tag === 'ellipse') { var rx = num('rx'), ry = num('ry'); return rect(F(num('cx') - rx), F(num('cy') - ry), F(rx * 2), F(ry * 2)); }
    if (tag === 'line') { var x1 = num('x1'), y1 = num('y1'), x2 = num('x2'), y2 = num('y2'); return rect(Math.min(x1, x2), Math.min(y1, y2), Math.abs(x2 - x1), Math.abs(y2 - y1)); }
    if (tag === 'polygon' || tag === 'polyline') { var p = (el.getAttribute('points') || '').split(/[\s,]+/).filter(Boolean).map(Number), b2 = null; for (var i = 0; i + 1 < p.length; i += 2) b2 = unite(b2, rect(p[i], p[i + 1], 0, 0)); return b2; }
    if (tag === 'g' || tag === 'svg' || tag === 'a' || tag === 'switch') {
      var u = null;
      for (var c = 0; c < el.childNodes.length; c++) {
        var ch = el.childNodes[c];
        if (ch.nodeType !== 1 || /^(defs|clipPath|mask|linearGradient|radialGradient|pattern|filter|style|title|desc|metadata|script|symbol|marker)$/.test(ch.localName)) continue;
        var cb = boxOf(ch);
        if (cb) u = unite(u, mapRect(parseTransform(ch.getAttribute('transform')), cb));
      }
      return u;
    }
    return null;
  }
  function mul(a, c) { if (!a) return c; if (!c) return a; return [a[0] * c[0] + a[2] * c[1], a[1] * c[0] + a[3] * c[1], a[0] * c[2] + a[2] * c[3], a[1] * c[2] + a[3] * c[3], a[0] * c[4] + a[2] * c[5] + a[4], a[1] * c[4] + a[3] * c[5] + a[5]]; }
  function parseTransform(s) {
    if (!s) return null;
    var m = null, re = /(matrix|translate|scale|rotate|skewX|skewY)\s*\(([^)]*)\)/g, t;
    while ((t = re.exec(s))) {
      var v = t[2].split(/[\s,]+/).filter(Boolean).map(function (x) { return F(+x); }), k;
      if (t[1] === 'matrix') k = v;
      else if (t[1] === 'translate') k = [1, 0, 0, 1, v[0] || 0, v[1] || 0];
      else if (t[1] === 'scale') k = [v[0], 0, 0, v.length > 1 ? v[1] : v[0], 0, 0];
      else if (t[1] === 'rotate') { var rr = v[0] * Math.PI / 180, cs = Math.cos(rr), sn = Math.sin(rr); k = [cs, sn, -sn, cs, 0, 0]; if (v.length > 2) k = mul(mul([1, 0, 0, 1, v[1], v[2]], k), [1, 0, 0, 1, -v[1], -v[2]]); }
      else if (t[1] === 'skewX') k = [1, 0, Math.tan(v[0] * Math.PI / 180), 1, 0, 0];
      else k = [1, Math.tan(v[0] * Math.PI / 180), 0, 1, 0, 0];
      m = mul(m, k);
    }
    return m;
  }
  // ---------- canvas 2D: just enough for the fabric-grain tile (pixels kept for the host) ----------
  var CANVASES = {};
  function Ctx2D(cv) { this.canvas = cv; this.fillStyle = '#000'; this.globalAlpha = 1; }
  Ctx2D.prototype.createImageData = function (w, h) { return { width: w, height: h, data: new Uint8ClampedArray(w * h * 4) }; };
  Ctx2D.prototype.putImageData = function (im) { this.canvas._pixels = { width: im.width, height: im.height, data: im.data }; };
  Ctx2D.prototype.getImageData = function (x, y, w, h) { var p = this.canvas._pixels; return p ? { width: p.width, height: p.height, data: p.data } : this.createImageData(w, h); };
  Ctx2D.prototype.createPattern = function (src, rep) { return { pattern: src, repeat: rep }; };
  Ctx2D.prototype.fillRect = function (x, y, w, h) { if (this.fillStyle && this.fillStyle.pattern) this.canvas._tiled = { src: this.fillStyle.pattern, w: w, h: h }; };
  ['clearRect', 'save', 'restore', 'translate', 'scale', 'rotate', 'beginPath', 'closePath', 'moveTo', 'lineTo', 'arc', 'fill', 'stroke', 'drawImage', 'setTransform'].forEach(function (k) { Ctx2D.prototype[k] = function () {}; });

  // ---------- install ----------
  function install(G, opts) {
    opts = opts || {};
    var html = new Element('html', 'http://www.w3.org/1999/xhtml'), head = new Element('head', html.namespaceURI), body = new Element('body', html.namespaceURI);
    html.__isRoot = true;
    html.appendChild(head); html.appendChild(body);
    var docListeners = {};
    var document = {
      nodeType: 9, readyState: 'complete', documentElement: html, head: head, body: body, hidden: false, visibilityState: 'visible',
      fonts: { ready: Promise.resolve() },
      createElementNS: function (ns, tag) { return new Element(tag, ns); },
      createElement: function (tag) { return new Element(String(tag).toLowerCase(), 'http://www.w3.org/1999/xhtml'); },
      createTextNode: function (t) { return new Text(t); },
      createDocumentFragment: function () { return new Fragment(); },
      getElementById: function (id) { return html.querySelector('#' + id); },
      querySelector: function (s) { return html.querySelector(s); },
      querySelectorAll: function (s) { return html.querySelectorAll(s); },
      addEventListener: function (t, fn) { (docListeners[t] = docListeners[t] || []).push(fn); },
      removeEventListener: function () {},
    };
    G.window = G; G.self = G; G.globalThis = G;
    G.Node = Node; G.Element = G.SVGElement = G.HTMLElement = Element; G.Text = Text; G.DocumentFragment = Fragment;
    G.document = document;
    G.navigator = G.navigator || { userAgent: 'SquishRigHost', hardwareConcurrency: 8, deviceMemory: 4, maxTouchPoints: 5, vibrate: function () { return false; } };
    G.location = G.location || { protocol: 'app:', href: 'app://rig/', search: '', hash: '', pathname: '/' };
    var store = {};
    G.localStorage = G.localStorage || { getItem: function (k) { return Object.prototype.hasOwnProperty.call(store, k) ? store[k] : null; }, setItem: function (k, v) { store[k] = String(v); }, removeItem: function (k) { delete store[k]; }, clear: function () { store = {}; } };
    G.sessionStorage = G.sessionStorage || G.localStorage;
    var winListeners = {};
    G.addEventListener = function (t, fn) { (winListeners[t] = winListeners[t] || []).push(fn); };
    G.removeEventListener = function () {};
    G.dispatchEvent = function (ev) { (winListeners[ev.type] || []).slice().forEach(function (f) { f(ev); }); return true; };
    G.getComputedStyle = function (el) { return el.style; };
    G.matchMedia = function () { return { matches: false, addListener: function () {}, removeListener: function () {}, addEventListener: function () {} }; };
    G.innerWidth = 832; G.innerHeight = 384; G.devicePixelRatio = 2.8125;
    G.Image = function () { var e = new Element('img', 'http://www.w3.org/1999/xhtml'); return e; };
    G.console = G.console || { log: function () {}, warn: function () {}, error: function () {} };
    if (opts.readFile) {
      G.fetch = function (url) {
        var path = String(url).split('?')[0].split('#')[0].replace(/^\.\//, '');
        return new Promise(function (res) {
          var text = null; try { text = opts.readFile(path); } catch (e) { text = null; }
          res({ ok: text != null, status: text != null ? 200 : 404, text: function () { return Promise.resolve(text || ''); }, json: function () { return Promise.resolve(JSON.parse(text || 'null')); } });
        });
      };
    }
    G.__rigShim = { Element: Element, serialize: serialize, canvases: CANVASES, parseTransform: parseTransform };
    return G;
  }

  root.RigDomShim = { install: install };
})(typeof globalThis !== 'undefined' ? globalThis : this);
