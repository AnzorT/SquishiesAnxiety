// Squish Hop's characters as the design's live 2.5D rigs (SQUISH_HOP.md, "Rig characters"): one transparent WebView
// over the board (android/app/src/main/assets/rig/hop.html, from tools/rig/hop.html) draws the hopper and every friend,
// with the rig's own bones, springs and soft-body jiggle. Game.js decides what happens and when; this hands each move
// to the page. Until the page says the board's cast is drawn (`onCast`), the game shows its cut-outs (Pieces.js).
// Squish Sort uses it too, with its own page (`page="sort"`: rig/sort.html, `sortStage`, the calls src/sort/Game.js
// lists), and the result card's three characters (`page="result"`: rig/result.html, src/squishdoku/Trio.js). The
// page's other messages go to `onEvent`. A page that won't load (an APK from before it) shows nothing, not the
// WebView's error page, and says so (`onFail`).
import React, { forwardRef, useCallback, useImperativeHandle, useRef } from 'react';
import { Platform, StyleSheet, View } from 'react-native';
import { WebView } from 'react-native-webview';
import { WEBVIEW_DEBUG } from '../webDebug';

// (web: the same page, served at /android_asset/ by metro.config.js; src/web/WebView.js)
const hostOf = (page) => Platform.select({ android: `file:///android_asset/rig/${page}.html`, web: `/android_asset/rig/${page}.html`, default: null });

// The page's calls (hop.html `hopStage`): positions are the board area's (the page adds `origin`), a character's `s`
// is its scale there (standOn's s / T) and `W` its body's width at scale 1.
//   cast(list, tag)   the board's characters [{ id, key, W, x, y, s, z, o }]; answers { type: 'cast', tag, ok }
//   enter(id, p, delay, pop)   hop(id, legs, dir)   bump(id, dx, dy, shake)   pickup(id, x, y, ms)   restore(id, p)
//   place(id, p)   win(id, ms)   stuck(id)   unstuck(id)   giggle(id)
const CALLS = ['origin', 'cast', 'place', 'show', 'enter', 'hop', 'bump', 'pickup', 'restore', 'win', 'stuck', 'unstuck', 'giggle'];

const noPage = () => <View />;

const RigStage = forwardRef(function RigStage({ style, page = 'hop', calls = CALLS, paused = false, onReady, onCast, onEvent, onFail }, ref) {
  const HOST = hostOf(page);
  const api = `${page}Stage`;
  const web = useRef(null);
  const ready = useRef(false);
  const run = useCallback((js) => {
    if (web.current && ready.current) web.current.injectJavaScript(`${js};true;`);
  }, []);
  useImperativeHandle(
    ref,
    () => Object.fromEntries(calls.map((fn) => [fn, (...args) => run(`window.${api}&&${api}.${fn}(${args.map((a) => JSON.stringify(a === undefined ? null : a)).join(',')})`)])),
    [run, api, calls],
  );
  const pausedNow = useRef(false);
  if (ready.current && paused !== pausedNow.current) {
    pausedNow.current = paused;
    run(`${api}.pause(${paused ? 'true' : 'false'})`);
  }
  const onMessage = useCallback(
    (e) => {
      let m;
      try {
        m = JSON.parse(e.nativeEvent.data);
      } catch (x) {
        return;
      }
      if (m.type === 'ready') {
        ready.current = true;
        pausedNow.current = false;
        onReady && onReady();
      } else if (m.type === 'cast') onCast && onCast(m);
      else if (m.type === 'error') console.warn(`[${page} rig]`, m.message);
      else if (onEvent) onEvent(m);
    },
    [onReady, onCast, onEvent, page],
  );
  if (!HOST) return null;
  return (
    <View pointerEvents="none" style={style}>
      <WebView
        ref={web}
        source={{ uri: HOST }}
        originWhitelist={['*']}
        allowFileAccess
        allowFileAccessFromFileURLs
        javaScriptEnabled
        onMessage={onMessage}
        onError={onFail}
        renderError={noPage}
        style={styles.web}
        containerStyle={styles.web}
        androidLayerType="hardware"
        overScrollMode="never"
        scrollEnabled={false}
        bounces={false}
        setBuiltInZoomControls={false}
        showsHorizontalScrollIndicator={false}
        showsVerticalScrollIndicator={false}
        webviewDebuggingEnabled={WEBVIEW_DEBUG}
      />
    </View>
  );
});

const styles = StyleSheet.create({ web: { flex: 1, backgroundColor: 'transparent' } });

export default RigStage;
