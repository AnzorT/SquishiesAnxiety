// Opening a group chest (REDESIGN_V6 step 6): the design's "Chest Smash v2", run in a WebView
// (android/app/src/main/assets/chest, built by tools/chest/build.mjs) — its own canvas engine for
// the dents, cracks, holes, torn parts, burst and loot, its own sounds, and its overlay: HP pips,
// POWER / SUPER, banners, the reveal card and COLLECT.
//
// The server has already rolled the chest (squad groupChest, freeChest, adChest, dealChest); this
// plays that result: the first tap of a Common or Rare plays its upgrade when the server rolled
// one, and the reveal shows the creature the server granted. `chest` changes → the next chest
// (bundles open several in a row) without reloading the page.
import React, { useCallback, useEffect, useRef, useState } from 'react';
import { Platform, StyleSheet, View } from 'react-native';
import { WebView } from 'react-native-webview';
import { useSafeAreaInsets } from 'react-native-safe-area-context';
import { BY_ID, RAR_LOOK } from '../squad/data';
import { rigLookOf } from '../squad/looks';
import sfx from '../audio/sfx';
import { pageFps, useFpsActive } from './fpsMeter';
import { WEBVIEW_DEBUG } from '../webDebug';

// (web: the same page, served at /android_asset/ by metro.config.js; src/web/WebView.js)
const HOST = Platform.select({ android: 'file:///android_asset/chest/host.html', web: '/android_asset/chest/host.html', default: null });
const SIZE_NAMES = { common: 'common', rare: 'rare', epic: 'epic', legendary: 'legendary', set: 'set' };

// What the page's reveal card shows for the server's result. The card is the Characters screen's (cards v6: `key` finds
// the name lettering, `set` the group background); the picture is the creature's still in its Firebase look (the
// page's ../looks/, as the menu's cards), or its old front art when it has no look pictures.
function rewardOf(r, catalog) {
  const c = r.id != null ? BY_ID[String(r.id)] : null;
  const R = c ? RAR_LOOK[c.rar] : null;
  const doc = c ? catalog[c.id] : null;
  const look = c ? rigLookOf(c.key) : 0;
  return {
    name: c ? c.name : '',
    key: c ? c.key : '',
    set: c ? c.set : '',
    rar: c ? c.rar : 0,
    rarLabel: R ? R.label : '',
    rarBg: R ? R.bg : '#ffffff',
    rarInk: R ? R.ink : '#45107a',
    concept: (doc && doc.description) || '',
    img: !c ? '' : look ? `../looks/${look}/${c.key}.webp` : `../rig/export/tripo/${c.key}/${c.key}-front.svg`,
    // (the border look again, for the live creature the page brings out when this copy unlocks it: rig-look.js)
    look,
    isNew: !!r.isNew,
    // copies found of it so far and how many unlock it (none: it came whole)
    copies: r.copies || 0,
    need: r.need || 0,
    coins: r.coins || 0,
    dupeCoins: r.dupeCoins || 0,
    setBonus: r.setBonus || 0,
    luck: !!r.luck,
  };
}

// `chest`: { key, result } (result: the server's answer); `onCollect()` after COLLECT.
// `first`: { group, size } of the chest whose answer is on its way (known at the tap): its
// scene comes up at once and the answer fills it in when it lands (a first tap meanwhile is
// held). The smash stays unseen until the page has painted its scene, then `onShown()`.
export default function ChestSmash({ chest, first = null, catalog, onCollect, onShown }) {
  const insets = useSafeAreaInsets();
  const web = useRef(null);
  const ready = useRef(false);
  const shown = useRef(null); // the chest's key on the page, or 'first'
  const [painted, setPainted] = useState(false);
  const [effects, setEffects] = useState(true);
  useEffect(() => sfx.subscribe((s) => setEffects(s.effects)), []);

  const run = useCallback((js) => {
    if (web.current && ready.current) web.current.injectJavaScript(`${js};true;`);
  }, []);
  const start = useCallback(() => {
    if (!ready.current) return;
    const scene = { sound: effects, insetTop: insets.top, insetBottom: insets.bottom };
    if (!chest) {
      if (!first || shown.current) return;
      shown.current = 'first';
      run(`chestHost.start(${JSON.stringify({ ...scene, group: first.group, size: first.size, wait: true })})`);
      return;
    }
    if (shown.current === chest.key) return;
    const r = chest.result;
    const o = { group: r.group, size: SIZE_NAMES[r.size] || 'common', final: SIZE_NAMES[r.final] || r.size, reward: rewardOf(r, catalog || {}) };
    // the answer for the chest already up, or a scene of its own
    if (shown.current === 'first' && first && o.group === first.group && o.size === first.size) run(`chestHost.fill(${JSON.stringify(o)})`);
    else run(`chestHost.start(${JSON.stringify({ ...scene, ...o })})`);
    shown.current = chest.key;
  }, [chest, first, catalog, effects, insets.top, insets.bottom, run]);
  useEffect(() => start(), [start]);
  useEffect(() => run(`chestHost.sound(${effects ? 'true' : 'false'})`), [effects, run]);
  // the tester's FPS counter: the page counts its own frames while it's on (fpsMeter.js)
  const fpsOn = useFpsActive();
  const fpsOnRef = useRef(fpsOn);
  fpsOnRef.current = fpsOn;
  useEffect(() => {
    run(`chestHost.meter(${fpsOn ? 'true' : 'false'})`);
    if (!fpsOn) pageFps('chest', null);
  }, [fpsOn, run]);
  useEffect(() => () => pageFps('chest', null), []);
  // never left unseen over the screen if the page doesn't say 'shown'
  useEffect(() => {
    if (painted) return undefined;
    const t = setTimeout(() => {
      setPainted(true);
      onShown?.();
    }, 2500);
    return () => clearTimeout(t);
  }, [painted, onShown]);

  const onMessage = useCallback(
    (e) => {
      let m;
      try {
        m = JSON.parse(e.nativeEvent.data);
      } catch (x) {
        return;
      }
      if (m.type === 'fps') {
        pageFps('chest', m);
      } else if (m.type === 'ready') {
        ready.current = true;
        if (fpsOnRef.current) run('chestHost.meter(true)');
        start();
      } else if (m.type === 'shown') {
        if (!painted) {
          setPainted(true);
          onShown?.();
        }
      } else if (m.type === 'reveal') {
        sfx.play('sparkle');
      } else if (m.type === 'collect') {
        sfx.play('coinShower');
        onCollect();
      }
    },
    [start, onCollect, onShown, painted, run],
  );

  if (!HOST) return null;
  return (
    <View style={[StyleSheet.absoluteFill, !painted && styles.unseen]}>
      <WebView
        ref={web}
        source={{ uri: HOST }}
        originWhitelist={['*']}
        allowFileAccess
        allowFileAccessFromFileURLs
        javaScriptEnabled
        // (localStorage: the page remembers that this phone needs its lighter mode, for the next chests)
        domStorageEnabled
        mediaPlaybackRequiresUserAction={false}
        onMessage={onMessage}
        style={styles.web}
        // (no androidLayerType: the chest redraws every frame, and a hardware layer added an off-screen copy of the
        //  whole screen each frame. Performance, 2026-11-14)
        overScrollMode="never"
        scrollEnabled={false}
        bounces={false}
        setBuiltInZoomControls={false}
        webviewDebuggingEnabled={WEBVIEW_DEBUG}
      />
    </View>
  );
}

const styles = StyleSheet.create({
  web: { flex: 1, backgroundColor: '#22160e' }, // (the vault room's dark, REDESIGN_V9)
  unseen: { opacity: 0 },
});
