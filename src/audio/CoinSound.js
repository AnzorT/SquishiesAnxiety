import { Audio } from 'expo-av';

// A short one-shot "ding" played each time a coin is earned. Uses
// replayAsync so rapid squishing/dragging can retrigger it before the
// previous play finishes, instead of queueing or getting dropped.

export class CoinSound {
  constructor() {
    this.sound = null;
  }

  async load() {
    try {
      const { sound } = await Audio.Sound.createAsync(require('../../assets/audio/coin.mp3'), {
        volume: 0.8,
      });
      this.sound = sound;
    } catch (e) {
      this.sound = null;
    }
  }

  async play() {
    if (!this.sound) return;
    try {
      await this.sound.replayAsync();
    } catch (e) {
      // no-op — audio hiccups shouldn't crash gameplay
    }
  }

  async unload() {
    if (!this.sound) return;
    try {
      await this.sound.unloadAsync();
    } catch (e) {
      // no-op
    }
    this.sound = null;
  }
}

export default CoinSound;
