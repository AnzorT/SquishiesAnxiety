// Web only (App.web.js loads it before the app): what React Native gives the app on a phone that a browser doesn't.
import { Alert, BackHandler } from 'react-native';

// The screen doesn't scroll: on a phone whatever lies past its edge (screens waiting off to the side, sheets below)
// is simply cut off, but a browser page grows to hold it (the app's page was twice the screen's height) and scrolled
// it into view when something there took focus, shifting the whole app up. `clip` cuts it off without making the
// root a box that can scroll. No text selection on drags, as in the app.
const css = document.createElement('style');
css.textContent =
  'html,body{height:100%;margin:0;overflow:hidden;overscroll-behavior:none}' +
  '#root{overflow:clip}' +
  'body{user-select:none;-webkit-user-select:none;-webkit-tap-highlight-color:transparent}' +
  'input,textarea{user-select:text;-webkit-user-select:text}' +
  // A browser paints positioned boxes over plain ones whatever their order, and react-native-web's views are all
  // positioned, but its text inputs and react-native-svg's <svg> are not. So a plaque's fill layers (absolute, drawn
  // before its content, as on the phone) covered the content's icons and inputs. Positioned, they paint in order, as on
  // the phone. :where() gives the rule no weight, so a position the app gave (an absolute-fill SVG, which
  // react-native-web writes as a class) still wins: with an id's weight the rule beat those classes, and a full-screen
  // SVG background took up room in the layout (Squish Time's sky pushed its stage off to the side).
  // (not only inside #root: a Modal's content is drawn in a layer of its own beside it)
  ':where(svg,input,textarea){position:relative}';
document.head.appendChild(css);
window.addEventListener('scroll', () => {
  if (window.scrollX || window.scrollY) window.scrollTo(0, 0);
});

// Sideways lists scroll by dragging with the mouse too (the user: every horizontal list scrolls left to right). On a
// phone a finger swipes them; in a browser a mouse can't, so a press-and-drag on any sideways-scrolling box scrolls it,
// gliding on after a flick, and a mouse wheel scrolls it sideways. A drag doesn't count as a click on what's under it.
// Paged lists (the Shop's chests) snap to their page when let go.
(function dragScroll() {
  const scroller = (t) => {
    for (let e = t; e && e !== document.body; e = e.parentElement) {
      if (e.scrollWidth > e.clientWidth + 1) {
        const ox = getComputedStyle(e).overflowX;
        if (ox === 'auto' || ox === 'scroll') return e;
      }
    }
    return null;
  };
  let el = null, x0 = 0, s0 = 0, moved = false, lx = 0, lt = 0, v = 0, raf = 0, snap = '';
  const stop = () => {
    cancelAnimationFrame(raf);
    raf = 0;
  };
  const release = () => {
    if (!el) return;
    const e = el;
    el = null;
    if (snap) {
      // paged: back to snapping, which settles it on the nearest page
      e.style.scrollSnapType = snap;
      return;
    }
    if (!moved || Math.abs(v) < 0.05) return;
    let last = performance.now();
    const step = (now) => {
      const dt = Math.min(40, now - last);
      last = now;
      e.scrollLeft -= v * dt;
      v *= Math.pow(0.94, dt / 16);
      raf = Math.abs(v) > 0.02 ? requestAnimationFrame(step) : 0;
    };
    raf = requestAnimationFrame(step);
  };
  window.addEventListener('pointerdown', (e) => {
    if (e.pointerType !== 'mouse' || e.button !== 0) return;
    const s = scroller(e.target);
    if (!s) return;
    stop();
    el = s;
    x0 = lx = e.clientX;
    s0 = s.scrollLeft;
    lt = performance.now();
    v = 0;
    moved = false;
    snap = getComputedStyle(s).scrollSnapType;
    snap = snap && snap !== 'none' ? snap : '';
  }, true);
  window.addEventListener('pointermove', (e) => {
    if (!el) return;
    const dx = e.clientX - x0;
    if (!moved && Math.abs(dx) > 6) {
      moved = true;
      if (snap) el.style.scrollSnapType = 'none';
    }
    if (!moved) return;
    const t = performance.now();
    el.scrollLeft = s0 - dx;
    v = (e.clientX - lx) / Math.max(1, t - lt);
    lx = e.clientX;
    lt = t;
  }, true);
  window.addEventListener('pointerup', release, true);
  window.addEventListener('pointercancel', release, true);
  window.addEventListener('click', (e) => {
    if (moved) {
      e.stopPropagation();
      e.preventDefault();
      moved = false;
    }
  }, true);
  window.addEventListener('wheel', (e) => {
    if (Math.abs(e.deltaY) <= Math.abs(e.deltaX)) return;
    const s = scroller(e.target);
    if (!s || getComputedStyle(s).overflowY === 'auto' || getComputedStyle(s).overflowY === 'scroll') return;
    stop();
    s.scrollLeft += e.deltaY;
    e.preventDefault();
  }, { passive: false, capture: true });
})();

// Firebase Storage sends no CORS headers unless the bucket is set up for the site (cors.json), so in development the
// creature art a WebGL texture needs (an image asked for with crossOrigin) and the 3D models the app fetches come
// through the dev server (/__fbstorage/, metro.config.js). A plain image on a screen needs no CORS and still loads
// from Storage directly. The hosted build (tools/web/host.mjs) has no dev server: it goes to Storage, whose CORS
// lets its sites in.
const STORAGE = 'https://firebasestorage.googleapis.com/';
const viaServer = (u) => (__DEV__ && typeof u === 'string' && u.startsWith(STORAGE) ? `/__fbstorage/${u.slice(STORAGE.length)}` : u);
const realFetch = window.fetch.bind(window);
window.fetch = (input, init) => realFetch(typeof input === 'string' ? viaServer(input) : input, init);
const srcProp = Object.getOwnPropertyDescriptor(HTMLImageElement.prototype, 'src');
Object.defineProperty(HTMLImageElement.prototype, 'src', {
  ...srcProp,
  set(v) {
    srcProp.set.call(this, this.crossOrigin != null ? viaServer(v) : v);
  },
});

// The phone's back button: Esc, or the frame's Back button (PhoneFrame.js calls window.__webBack). As on Android, the
// handler added last goes first, and one that returns true has dealt with it. (react-native-web's BackHandler only
// logs an error.)
const backHandlers = [];
BackHandler.addEventListener = (type, fn) => {
  if (type === 'hardwareBackPress') backHandlers.push(fn);
  return { remove: () => BackHandler.removeEventListener(type, fn) };
};
BackHandler.removeEventListener = (type, fn) => {
  const i = backHandlers.lastIndexOf(fn);
  if (i >= 0) backHandlers.splice(i, 1);
};
BackHandler.exitApp = () => {};
window.__webBack = () => {
  for (let i = backHandlers.length - 1; i >= 0; i--) {
    try {
      if (backHandlers[i]()) return true;
    } catch (e) {
      console.error('[back]', e);
    }
  }
  return false;
};
// (the game pages' frames pass their Esc here too: src/web/WebView.js)
window.addEventListener('keydown', (e) => {
  if (e.key === 'Escape') window.__webBack();
});

// Alert.alert does nothing in react-native-web: the browser's own dialogs instead. One button: a notice. Two or
// more: OK runs the last button that isn't "cancel", Cancel runs the cancel one (the app's dialogs are yes/no).
Alert.alert = (title, message, buttons) => {
  const text = [title, message].filter(Boolean).join('\n\n');
  const list = buttons && buttons.length ? buttons : [{ text: 'OK' }];
  setTimeout(() => {
    if (list.length === 1) {
      window.alert(text);
      if (list[0].onPress) list[0].onPress();
      return;
    }
    const cancel = list.find((b) => b.style === 'cancel') || null;
    const others = list.filter((b) => b !== cancel);
    const yes = others[others.length - 1];
    const extra = others.length > 1 ? `\n\n(OK = ${yes.text})` : '';
    if (window.confirm(text + extra)) {
      if (yes && yes.onPress) yes.onPress();
    } else if (cancel && cancel.onPress) cancel.onPress();
  }, 0);
};
