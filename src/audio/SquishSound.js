import { Audio } from 'expo-av';

// A single looping sample that plays for exactly as long as the buddy is
// being squished — started when a poke begins, stopped when it's released.

export class SquishSound {
  constructor() {
    this.sound = null;
  }

  async load() {
    try {
      await Audio.setAudioModeAsync({ playsInSilentModeIOS: true });
    } catch (e) {
      // no-op — audio mode is a nice-to-have, not required to function
    }
    try {
      const { sound } = await Audio.Sound.createAsync(require('../../assets/audio/slime.wav'), {
        isLooping: true,
        volume: 1,
      });
      this.sound = sound;
    } catch (e) {
      this.sound = null;
    }
  }

  async start() {
    if (!this.sound) return;
    try {
      await this.sound.playAsync();
    } catch (e) {
      // no-op — audio hiccups shouldn't crash gameplay
    }
  }

  async stop() {
    if (!this.sound) return;
    try {
      await this.sound.stopAsync();
    } catch (e) {
      // no-op
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

export default SquishSound;
