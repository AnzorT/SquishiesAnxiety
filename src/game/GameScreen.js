// The new design's Main Menu and house (webgame/, built from the designer's prototype), full screen in landscape.
// The pages are the prototype's own code, so they look exactly like the design. This screen hands them the player
// (coins, level, owned creatures, the saved house) and the admin's remote config, and turns what they send back into
// app actions (shop, settings, Squish Time) and Firestore writes (coins, house layout). Messages: webgame/README.md.
import React, { useCallback, useEffect, useMemo, useRef, useState } from 'react';
import { BackHandler, Platform, StyleSheet, Text, View } from 'react-native';
import { WebView } from 'react-native-webview';
import * as ScreenOrientation from 'expo-screen-orientation';
import { StatusBar } from 'expo-status-bar';
import { gameCoins, loadHouse, saveHouse, subscribeToGameConfig } from './gameData';

// node webgame/build.mjs puts the game in android/app/src/main/assets/webgame
const GAME_URL = Platform.OS === 'android' ? 'file:///android_asset/webgame/App.dc.html' : null;
const BG = '#24123f'; // the design's page colour, so nothing flashes while it loads

// JSON for a JS string: also escape the two line separators JSON leaves raw (U+2028, U+2029)
const LS = String.fromCharCode(0x2028), PS = String.fromCharCode(0x2029);
const toJs = (v) => JSON.stringify(v).split(LS).join('\\u2028').split(PS).join('\\u2029');

export default function GameScreen({ uid, level, coins, ownedKeys, wantHouse, onHouseShown, onShop, onSettings, onPlay }) {
  const web = useRef(null);
  const ready = useRef(false);
  const queue = useRef([]);
  const [house, setHouse] = useState(undefined); // undefined while loading, then the saved layout or null
  const [config, setConfig] = useState(null);
  const [crashes, setCrashes] = useState(0);

  useEffect(() => {
    let live = true;
    // don't hold the game for a slow network: start without the saved house after 2.5 s (the game keeps its own copy)
    const t = setTimeout(() => live && setHouse((h) => (h === undefined ? null : h)), 2500);
    loadHouse(uid).then((h) => live && setHouse((cur) => (cur === undefined ? h : cur)));
    return () => {
      live = false;
      clearTimeout(t);
    };
  }, [uid]);
  useEffect(() => {
    // no config yet (first run offline): start with the design's own values, the config is applied when it comes
    const t = setTimeout(() => setConfig((c) => c || {}), 2500);
    const off = subscribeToGameConfig(setConfig);
    return () => {
      clearTimeout(t);
      off();
    };
  }, []);

  // landscape while the game is on screen; the rest of the app is portrait
  useEffect(() => {
    ScreenOrientation.lockAsync(ScreenOrientation.OrientationLock.LANDSCAPE).catch(() => {});
    return () => {
      ScreenOrientation.lockAsync(ScreenOrientation.OrientationLock.PORTRAIT_UP).catch(() => {});
    };
  }, []);

  const send = useCallback((msg) => {
    if (!ready.current || !web.current) {
      queue.current.push(msg);
      return;
    }
    web.current.injectJavaScript(`window.SquishApp && window.SquishApp.receive(${toJs(msg)}); true;`);
  }, []);

  // what the page starts with (later changes are sent as messages)
  const state = useMemo(() => ({ level, coins, owned: ownedKeys }), [level, coins, ownedKeys]);
  const startRef = useRef(null);
  if (!startRef.current && house !== undefined && config) {
    startRef.current = { screen: 'menu', state: { ...state, house: house || undefined }, config };
  }
  const start = startRef.current;

  useEffect(() => {
    if (start) send({ type: 'state', state });
  }, [state, start, send]);
  useEffect(() => {
    if (start && config) send({ type: 'config', config });
  }, [config, start, send]);
  useEffect(() => {
    if (!wantHouse || !start) return;
    send({ type: 'screen', screen: 'house' });
    onHouseShown && onHouseShown();
  }, [wantHouse, start, send, onHouseShown]);

  // Android back: the game closes what's on top (house, a game, the games page); nothing open -> leave the app
  useEffect(() => {
    const sub = BackHandler.addEventListener('hardwareBackPress', () => {
      if (web.current && ready.current) web.current.injectJavaScript('window.SquishApp && window.SquishApp.back(); true;');
      return true;
    });
    return () => sub.remove();
  }, []);

  const onMessage = useCallback(
    (e) => {
      let msg;
      try {
        msg = JSON.parse(e.nativeEvent.data);
      } catch (err) {
        return;
      }
      const p = msg.payload || {};
      switch (msg.type) {
        case 'ready':
          ready.current = true;
          queue.current.splice(0).forEach(send);
          break;
        case 'coins':
          gameCoins(uid, p.delta);
          break;
        case 'house':
          saveHouse(uid, p.data);
          break;
        case 'open':
          if (p.what === 'shop') onShop && onShop();
          else if (p.what === 'settings') onSettings && onSettings();
          break;
        case 'play':
          onPlay && onPlay(p.key, p.mode);
          break;
        case 'backUnhandled':
          BackHandler.exitApp();
          break;
        case 'error':
          console.warn('[webgame]', p.message, p.file ? `${p.file}:${p.line}` : '');
          break;
        default:
          break;
      }
    },
    [uid, send, onShop, onSettings, onPlay]
  );

  // the page's process died (low memory): start it again
  const restart = useCallback(() => {
    ready.current = false;
    queue.current = [];
    setCrashes((n) => n + 1);
  }, []);

  if (!GAME_URL) {
    return (
      <View style={[styles.fill, styles.center]}>
        <Text style={styles.note}>The new design runs on Android for now.</Text>
      </View>
    );
  }
  return (
    <View style={styles.fill}>
      <StatusBar hidden />
      {start ? (
        <WebView
          key={crashes}
          ref={web}
          source={{ uri: GAME_URL }}
          style={styles.web}
          containerStyle={styles.fill}
          originWhitelist={['*']}
          injectedJavaScriptBeforeContentLoaded={`window.__SQUISH_INIT__ = ${toJs(start)}; true;`}
          onMessage={onMessage}
          javaScriptEnabled
          domStorageEnabled
          // the game's pages, art and catalog are files next to the page; the design runtime reads them with fetch/XHR
          allowFileAccess
          allowFileAccessFromFileURLs
          allowUniversalAccessFromFileURLs
          // pixel-perfect: the phone's font-size setting must not resize the design's text
          textZoom={100}
          setBuiltInZoomControls={false}
          setDisplayZoomControls={false}
          scrollEnabled={false}
          bounces={false}
          overScrollMode="never"
          showsHorizontalScrollIndicator={false}
          showsVerticalScrollIndicator={false}
          mediaPlaybackRequiresUserAction={false}
          allowsInlineMediaPlayback
          androidLayerType="hardware"
          setSupportMultipleWindows={false}
          webviewDebuggingEnabled={__DEV__}
          onRenderProcessGone={restart}
          onContentProcessDidTerminate={restart}
        />
      ) : null}
    </View>
  );
}

const styles = StyleSheet.create({
  fill: { flex: 1, backgroundColor: BG },
  web: { flex: 1, backgroundColor: BG },
  center: { alignItems: 'center', justifyContent: 'center' },
  note: { color: '#e8dcff', fontSize: 16 },
});
