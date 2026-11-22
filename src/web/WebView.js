// Web only: react-native-webview → an <iframe> on the same address. The pages the app opens on Android from its APK
// (file:///android_asset/...) are served by Metro at /android_asset/ (metro.config.js), which puts one line first in
// each page's <head>: it calls window.__rnwFrame(pageWindow, frame) here before the page's own scripts run. That hands
// the page what the Android WebView gives it:
//   window.ReactNativeWebView.postMessage(s) → the onMessage prop ({ nativeEvent: { data: s } }), a moment later
//   injectedJavaScriptBeforeContentLoaded    → run in the page first
//   ref.injectJavaScript(js)                 → run in the page
// Same address, so the app can reach into the page directly; the pages' localStorage is shared between them as on
// the phone (where it's shared between file:// pages).
import React, { forwardRef, useCallback, useImperativeHandle, useRef } from 'react';
import { StyleSheet, View } from 'react-native';

const frames = new Map(); // <iframe> → its WebView
if (typeof window !== 'undefined') {
  window.__rnwFrame = (win, el) => {
    const w = frames.get(el);
    if (w) w.boot(win);
  };
}

const urlOf = (source) => {
  const uri = (source && source.uri) || 'about:blank';
  return uri.replace(/^file:\/\/\/android_asset\//, '/android_asset/');
};

// The phone on the computer's screen (PhoneFrame.js) is the app's frame scaled up with a CSS transform to fit the
// window (~220% on a 1080p monitor). Chrome redraws text, pictures and SVGs at that size, but a <canvas> keeps the
// pixels its page gave it (its size x devicePixelRatio, the monitor's 1), so the chest smash, the rigs and the other
// canvas pages came out stretched 2x and soft (2026-11-17, the user: the chest about to open is "low resolution").
// Each page is told the pixels it really gets on the screen: the monitor's ratio x the frame's scale, at most 3 (as
// the chest page's own cap; the A15 itself is 2.81). Worked out once as the page loads.
function screenRatio() {
  let s = window.devicePixelRatio || 1;
  try {
    const f = window.frameElement; // the phone frame's <iframe>, when the app runs in it
    if (f && f.offsetWidth) s *= f.getBoundingClientRect().width / f.offsetWidth;
  } catch (e) {}
  return Math.max(1, Math.min(3, s));
}

function run(win, js, what) {
  if (!win || !js) return;
  try {
    win.eval(js);
  } catch (e) {
    console.warn(`[WebView web] ${what}:`, e);
  }
}

export const WebView = forwardRef(function WebView(props, ref) {
  const { source, style, containerStyle } = props;
  const propsRef = useRef(props);
  propsRef.current = props;
  const el = useRef(null);
  const win = useRef(null);
  const self = useRef(null);
  if (!self.current) {
    self.current = {
      boot(w) {
        win.current = w;
        const ratio = screenRatio();
        try {
          Object.defineProperty(w, 'devicePixelRatio', { configurable: true, get: () => ratio });
        } catch (e) {}
        w.ReactNativeWebView = {
          postMessage(data) {
            const s = String(data);
            setTimeout(() => {
              const cb = propsRef.current.onMessage;
              if (cb) cb({ nativeEvent: { data: s, url: w.location.href } });
            }, 0);
          },
        };
        // Esc in the page is the phone's back button too (src/web/setup.js)
        w.addEventListener('keydown', (e) => {
          if (e.key === 'Escape' && window.__webBack) window.__webBack();
        });
        run(w, propsRef.current.injectedJavaScriptBeforeContentLoaded, 'injectedJavaScriptBeforeContentLoaded');
      },
    };
  }

  useImperativeHandle(
    ref,
    () => ({
      injectJavaScript: (js) => run(win.current, js, 'injectJavaScript'),
      reload: () => {
        try {
          if (el.current) el.current.contentWindow.location.reload();
        } catch (e) {}
      },
      postMessage: (data) => {
        const w = win.current;
        if (w) w.dispatchEvent(new w.MessageEvent('message', { data }));
      },
      goBack: () => {},
      goForward: () => {},
      stopLoading: () => {},
      requestFocus: () => el.current && el.current.focus(),
    }),
    [],
  );

  const setEl = useCallback((node) => {
    if (el.current) frames.delete(el.current);
    el.current = node;
    if (node) frames.set(node, self.current);
    else win.current = null;
  }, []);

  const onLoad = useCallback(() => {
    const p = propsRef.current;
    let w = win.current;
    // a page Metro didn't serve (no boot line): still reachable, same address
    if (!w && el.current) {
      try {
        w = el.current.contentWindow;
        self.current.boot(w);
      } catch (e) {}
    }
    run(w, p.injectedJavaScript, 'injectedJavaScript');
    const ev = { nativeEvent: { url: urlOf(p.source), loading: false, title: '' } };
    if (p.onLoad) p.onLoad(ev);
    if (p.onLoadEnd) p.onLoadEnd(ev);
  }, []);

  const bg = (StyleSheet.flatten(style) || {}).backgroundColor || 'transparent';
  return (
    <View style={[styles.fill, containerStyle, style]}>
      {React.createElement('iframe', {
        ref: setEl,
        src: urlOf(source),
        onLoad,
        title: 'game',
        allow: 'autoplay; fullscreen',
        style: { border: 0, width: '100%', height: '100%', display: 'block', background: bg },
      })}
    </View>
  );
});

export default WebView;

const styles = StyleSheet.create({
  fill: { flex: 1, overflow: 'hidden' },
});
