import { Audio } from 'expo-av';

// Sonic identity ported from the "Squish Buddies" design: a continuous quiet
// ambient hum (two detuned 84Hz tones through a slow-swept lowpass filter)
// plus one-shot squish / release / stick / boop hits. The original used live
// Web Audio oscillators — expo-av has no oscillator API, so each sound is a
// pre-rendered sample matching the same envelope/filter shapes (see
// assets/audio + the generator script that produced them).

const FILES = {
  squish: 'squish.wav',
  release: 'release.wav',
  stick: 'stick.wav',
  boop: 'boop.wav',
  ambient: 'ambient.wav',
};

// eslint-disable-next-line global-require, import/no-dynamic-require
const audioContext = require.context('../../assets/audio', false, /\.(mp3|wav)$/);

export class SquishyAudioEngine {
  constructor() {
    this.sounds = {};
    this.muted = false;
  }

  async init(muted = false) {
    this.muted = muted;
    try {
      await Audio.setAudioModeAsync({ playsInSilentModeIOS: true });
    } catch (e) {
      // no-op — audio mode is a nice-to-have, not required to function
    }
    await Promise.all(Object.entries(FILES).map(([key, filename]) => this._load(key, filename)));
    if (!this.muted) this._startAmbient();
  }

  async _load(key, filename) {
    const contextKey = `./${filename}`;
    if (!audioContext.keys().includes(contextKey)) {
      this.sounds[key] = null;
      return;
    }
    try {
      const isAmbient = key === 'ambient';
      const { sound } = await Audio.Sound.createAsync(audioContext(contextKey), {
        shouldPlay: false,
        isLooping: isAmbient,
        volume: isAmbient ? 0.5 : 1,
      });
      this.sounds[key] = sound;
    } catch (e) {
      // Missing/undecodable asset — degrade silently.
      this.sounds[key] = null;
    }
  }

  async _startAmbient() {
    const ambient = this.sounds.ambient;
    if (!ambient) return;
    try {
      await ambient.playAsync();
    } catch (e) {
      // no-op
    }
  }

  async _playOneShot(key) {
    if (this.muted) return;
    const sound = this.sounds[key];
    if (!sound) return;
    try {
      await sound.replayAsync();
    } catch (e) {
      // no-op — audio hiccups shouldn't crash gameplay
    }
  }

  playSquish() {
    this._playOneShot('squish');
  }

  playRelease() {
    this._playOneShot('release');
  }

  playStick() {
    this._playOneShot('stick');
  }

  playBoop() {
    this._playOneShot('boop');
  }

  async setMuted(muted) {
    this.muted = muted;
    const ambient = this.sounds.ambient;
    if (!ambient) return;
    try {
      if (muted) {
        await ambient.pauseAsync();
      } else {
        await ambient.playAsync();
      }
    } catch (e) {
      // no-op
    }
  }

  async unloadAll() {
    await Promise.all(
      Object.values(this.sounds)
        .filter(Boolean)
        .map((s) => s.unloadAsync().catch(() => {}))
    );
    this.sounds = {};
  }
}

export default SquishyAudioEngine;
