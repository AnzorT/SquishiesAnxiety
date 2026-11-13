// A live rig creature from the v6 design, drawn by the design's own rig code inside a WebView
// (android/app/src/main/assets/rig, built by tools/rig/build.mjs). Pokes and drag-to-spin are
// handled inside the page; it reports state changes and once-a-second perf numbers back.
import React, { forwardRef, useCallback, useImperativeHandle, useRef, useState } from 'react';
import { Platform, StyleSheet, View } from 'react-native';
import { WebView } from 'react-native-webview';

const HOST = Platform.select({ android: 'file:///android_asset/rig/host.html', default: null });

// renderScale < 1 draws the page at that fraction of the size and lets the (hardware-layer) view
// scale it up: fewer pixels for the GPU to raster, a little softer. `paused` stops the rig's frames
// and its clock (the screen is hidden), so it costs nothing and picks up where it left off.
// `rigShadow` false hides the rig's own floor shadow (a flat purple ellipse as wide as the
// creature, cut off at the page's edge for wide ones like Nimbo: it read as a purple bar, user
// 2026-10-24), for screens that draw a soft floor of their own (the Lobby, the Squad screen).
const HIDE_SHADOW = `(function(){var s=document.createElement('style');s.textContent='ellipse[fill="#6a1b9a"]{display:none!important}';document.head.appendChild(s);})()`;
// `bleed` ({ x, top, bottom } in dp): room for the page past the creature's box. Some
// moves reach well outside it (Nimbo's "happy" spreads 23 % past each side, "surprised" 8 % over
// the top) and the page's edge cut them off, so the creature looked boxed in (user, 2026-10-28).
// The creature is drawn the same size; touches still land only in the box (the view's own bounds).
const RigCreature = forwardRef(function RigCreature({ creatureKey, shuffle = true, renderScale = 1, paused = false, rigShadow = true, bleed = null, onState, onPerf, onMounted, style }, ref) {
  const [box, setBox] = useState(null);
  const web = useRef(null);
  const ready = useRef(false);
  const run = useCallback(js => { if (web.current && ready.current) web.current.injectJavaScript(js + ';true;'); }, []);

  useImperativeHandle(ref, () => ({
    play: name => run(`rigHost.play(${JSON.stringify(name)})`),
    mount: key => run(`rigHost.mount(${JSON.stringify(key)})`),
    setShuffle: on => run(`rigHost.shuffle(${on ? 'true' : 'false'})`),
  }), [run]);

  // A key change after the page is up re-mounts in place (no WebView reload).
  const shownKey = useRef(null);
  if (ready.current && creatureKey !== shownKey.current) { shownKey.current = creatureKey; run(`rigHost.mount(${JSON.stringify(creatureKey)})`); }
  const pausedNow = useRef(false);
  if (ready.current && paused !== pausedNow.current) { pausedNow.current = paused; run(`rigHost.pause(${paused ? 'true' : 'false'})`); }

  // the page's size with the bleed, and where the creature's box sits in it (as %, so the render scale doesn't matter)
  const bx = (bleed && bleed.x) || 0, bt = (bleed && bleed.top) || 0, bb = (bleed && bleed.bottom) || 0;
  const W = box ? box.width + 2 * bx : 0, H = box ? box.height + bt + bb : 0;
  const inset = box ? `${(bt / H) * 100}% ${(bx / W) * 100}% ${(bb / H) * 100}%` : '0';
  const setInset = `document.getElementById('stage').style.inset=${JSON.stringify(inset)}`;
  const insetNow = useRef(null);
  if (ready.current && inset !== insetNow.current) { insetNow.current = inset; run(setInset); }

  const onMessage = useCallback(e => {
    let m; try { m = JSON.parse(e.nativeEvent.data); } catch (x) { return; }
    if (m.type === 'ready') {
      ready.current = true; shownKey.current = creatureKey; pausedNow.current = paused; insetNow.current = inset;
      run(`${rigShadow ? '' : `${HIDE_SHADOW};`}${setInset};rigHost.shuffle(${shuffle ? 'true' : 'false'});rigHost.mount(${JSON.stringify(creatureKey)});rigHost.pause(${paused ? 'true' : 'false'})`);
    } else if (m.type === 'state') onState && onState(m.state);
    else if (m.type === 'perf') onPerf && onPerf(m);
    else if (m.type === 'mounted') onMounted && onMounted(m);
    else if (m.type === 'error') console.warn('[rig]', m.message);
  }, [creatureKey, shuffle, paused, rigShadow, inset, setInset, onState, onPerf, onMounted, run]);

  if (!HOST) return null;
  const k = renderScale, w = W * k, h = H * k;
  // centred on the box's middle, then the box's own place in the bleed
  const left = box ? (box.width - w) / 2 : 0, top = box ? (box.height - h) / 2 + (bb - bt) / 2 : 0;
  return (
    // (a hidden screen, display: none, lays out as 0 × 0: kept out, or the page went 0-sized with
    // NaN insets, and the creature never showed again on a Squad screen built asleep, 2026-10-28)
    <View style={style} onLayout={e => { const l = e.nativeEvent.layout; if (l.width > 0 && l.height > 0) setBox(l); }}>
    {box && <WebView
      ref={web}
      source={{ uri: HOST }}
      originWhitelist={['*']}
      allowFileAccess
      allowFileAccessFromFileURLs
      javaScriptEnabled
      onMessage={onMessage}
      style={styles.web}
      containerStyle={[styles.web, { position: 'absolute', width: w, height: h, left, top, transform: [{ scale: 1 / k }] }]}
      androidLayerType="hardware"
      overScrollMode="never"
      scrollEnabled={false}
      bounces={false}
      setBuiltInZoomControls={false}
      showsHorizontalScrollIndicator={false}
      showsVerticalScrollIndicator={false}
      webviewDebuggingEnabled
    />}
    </View>
  );
});

const styles = StyleSheet.create({ web: { backgroundColor: 'transparent' } });

export default RigCreature;
