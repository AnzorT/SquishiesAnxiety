import { Audio } from 'expo-av';

// Base for short one-shot effects that can overlap: each play() spawns its
// own Sound instance instead of restarting a shared one, so rapid triggers
// (e.g. coins earned back-to-back) each ring out in full instead of the
// newest play cutting off the previous one.
export class OneShotSound {
  constructor(source, volume = 1) {
    this.source = source;
    this.volume = volume;
    this.active = new Set();
  }

  // No persistent instance to preload — kept as a no-op so callers can treat
  // this the same as SquishSound's load/unload lifecycle.
  async load() {}

  async play() {
    try {
      const { sound } = await Audio.Sound.createAsync(this.source, { volume: this.volume });
      this.active.add(sound);
      sound.setOnPlaybackStatusUpdate((status) => {
        if (status.didJustFinish) {
          this.active.delete(sound);
          sound.unloadAsync();
        }
      });
      await sound.playAsync();
    } catch (e) {
      // no-op — audio hiccups shouldn't crash gameplay
    }
  }

  async unload() {
    const sounds = Array.from(this.active);
    this.active.clear();
    for (const sound of sounds) {
      try {
        await sound.unloadAsync();
      } catch (e) {
        // no-op
      }
    }
  }
}

export default OneShotSound;
