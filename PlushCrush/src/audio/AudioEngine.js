import { Audio } from 'expo-av';

// Layered ASMR audio engine. Two layers per fill profile:
//  - a continuous "compression bed" whose volume/pitch is driven by depth
//  - one-shot texture hits (squelch/crunch) fired on fast compression deltas
// Fill-specific sample keys map to files under assets/audio. If a file is
// missing the engine degrades silently (no crash, just no sound) so the app
// still runs without bundled audio assets during development.

const SAMPLE_MAP = {
  'foam-soft': { bed: 'foam_bed.mp3', hit: 'foam_hit.mp3' },
  'slime-squelch': { bed: 'slime_bed.mp3', hit: 'slime_squelch.mp3' },
  'bead-crunch': { bed: 'bead_bed.mp3', hit: 'bead_crunch.mp3' },
  tear: { hit: 'tear_rupture.mp3' },
};

export class AudioEngine {
  constructor() {
    this.sounds = {};
    this.ready = false;
    this.lastDepth = 0;
  }

  async init() {
    try {
      await Audio.setAudioModeAsync({ playsInSilentModeIOS: true });
      this.ready = true;
    } catch (e) {
      console.warn('AudioEngine: failed to init audio mode', e);
    }
  }

  async _loadOnce(key, filename) {
    if (this.sounds[key] || !filename) return;
    try {
      const { sound } = await Audio.Sound.createAsync(
        // eslint-disable-next-line global-require, import/no-dynamic-require
        require(`../../assets/audio/${filename}`),
        { shouldPlay: false, isLooping: key.endsWith(':bed') }
      );
      this.sounds[key] = sound;
    } catch (e) {
      // Missing asset — degrade silently.
      this.sounds[key] = null;
    }
  }

  async loadProfile(profileKey) {
    const sample = SAMPLE_MAP[profileKey];
    if (!sample) return;
    if (sample.bed) await this._loadOnce(`${profileKey}:bed`, sample.bed);
    if (sample.hit) await this._loadOnce(`${profileKey}:hit`, sample.hit);
  }

  async playBed(profileKey, depth) {
    const sound = this.sounds[`${profileKey}:bed`];
    if (!sound) return;
    try {
      const status = await sound.getStatusAsync();
      if (!status.isPlaying && depth > 0.05) await sound.playAsync();
      if (depth <= 0.02) await sound.stopAsync();
      await sound.setVolumeAsync(Math.min(depth * 1.3, 1));
      await sound.setRateAsync(0.85 + depth * 0.3, true);
    } catch (e) {
      // no-op — audio hiccups shouldn't crash gameplay
    }
  }

  async playHit(profileKey) {
    const sound = this.sounds[`${profileKey}:hit`];
    if (!sound) return;
    try {
      await sound.replayAsync();
    } catch (e) {
      // no-op
    }
  }

  // Call on every SquishState tick to drive continuous bed audio + fire
  // one-shot hits on fast compression deltas.
  onDepthChange(profileKey, depth) {
    const delta = depth - this.lastDepth;
    this.playBed(profileKey, depth);
    if (delta > 0.18) {
      this.playHit(profileKey);
    }
    this.lastDepth = depth;
  }

  async playBurst() {
    const sound = this.sounds['tear:hit'];
    if (!sound) return;
    try {
      await sound.replayAsync();
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

export default AudioEngine;
