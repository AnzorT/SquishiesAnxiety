// Stand-ins for React Native, expo-av, expo-file-system and expo-haptics that record every call the app's sound
// code makes (globalThis.__AT.log), on the virtual clock (clock.mjs). Shared state lives on globalThis because the
// loader hands this file out under several module URLs.
const T = (globalThis.__AT ??= { log: [], nextId: 1, files: {}, fail: new Set(), appState: 'active', appListeners: [] });
const now = () => Date.now();
const rec = (...e) => T.log.push([now(), ...e]);

// ---- react-native / react ----------------------------------------------------------------------------------------------
export const AppState = {
  get currentState() {
    return T.appState;
  },
  addEventListener(type, fn) {
    T.appListeners.push(fn);
    return { remove() {} };
  },
};
export const Platform = { OS: 'android', select: (o) => o.android ?? o.default };
export const Animated = { Value: class {}, timing: () => ({ start() {} }) };
export const Easing = {};
export const Image = { prefetch: async () => true };
export const useCallback = (f) => f;
export const useEffect = () => {};
export const useRef = (v) => ({ current: v });
export const useState = (v) => [v, () => {}];

// ---- expo-av ----------------------------------------------------------------------------------------------------------
const status = (s = {}) => ({
  shouldPlay: !!s.shouldPlay,
  loop: !!s.isLooping,
  volume: s.volume ?? 1,
  rate: s.rate ?? 1,
});
class Sound {
  constructor(id) {
    this.id = id;
  }
  async replayAsync(s = {}) {
    rec('replay', this.id, s.rate ?? null);
  }
  async setVolumeAsync(v) {
    rec('vol', this.id, v);
  }
  async setRateAsync(r) {
    rec('rate', this.id, r);
  }
  async playAsync() {
    rec('play', this.id);
  }
  async pauseAsync() {
    rec('pause', this.id);
  }
  async unloadAsync() {
    rec('unload', this.id);
  }
}
export const Audio = {
  Sound: {
    createAsync(source, s) {
      const file = typeof source === 'string' ? source : source && source.uri;
      if (T.fail.has(file)) {
        rec('create', 0, file, status(s));
        return Promise.reject(new Error('no ' + file));
      }
      const id = T.nextId++;
      rec('create', id, file, status(s));
      return Promise.resolve({ sound: new Sound(id), status: {} });
    },
  },
  async setAudioModeAsync(mode) {
    // sfx.js's (SquishSound's own iOS-only call isn't part of the player's behaviour)
    if (mode && 'shouldDuckAndroid' in mode) rec('mode');
  },
};

// ---- expo-file-system --------------------------------------------------------------------------------------------------
export const documentDirectory = 'file:///doc/';
export async function getInfoAsync(p) {
  return { exists: p in T.files };
}
export async function readAsStringAsync(p) {
  return T.files[p];
}
export async function writeAsStringAsync(p, text) {
  T.files[p] = text;
  rec('write', text);
}

// ---- expo-haptics ------------------------------------------------------------------------------------------------------
export const ImpactFeedbackStyle = { Soft: 'soft', Light: 'light', Medium: 'medium', Rigid: 'rigid', Heavy: 'heavy' };
export const NotificationFeedbackType = { Success: 'success', Warning: 'warning', Error: 'error' };
export async function impactAsync(style) {
  rec('vib', 'impact ' + style);
}
export async function notificationAsync(type) {
  rec('vib', 'notification ' + type);
}
export async function selectionAsync() {
  rec('vib', 'selection');
}

export default {};
