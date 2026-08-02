import { Audio } from 'expo-av';

// A single looping sample that plays for exactly as long as the buddy is
// being squished — started when a poke begins, stopped when it's released.
// Which sample depends on the creature (see SQUISH_SOUND_BY_SPECIES in
// SquishScreen.js), so the source is passed into load() rather than
// hardcoded here.

// Release fades the volume out over this many ms (in even steps) instead of
// cutting the loop dead, so letting go doesn't sound like a hard stutter.
const FADE_OUT_MS = 400;
const FADE_STEP_MS = 20;

export class SquishSound {
  constructor() {
    this.sound = null;
    this.fadeTimer = null;
  }

  _clearFade() {
    if (this.fadeTimer) {
      clearInterval(this.fadeTimer);
      this.fadeTimer = null;
    }
  }

  async load(source) {
    try {
      await Audio.setAudioModeAsync({ playsInSilentModeIOS: true });
    } catch (e) {
      // no-op — audio mode is a nice-to-have, not required to function
    }
    try {
      const { sound } = await Audio.Sound.createAsync(source, {
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
    this._clearFade();
    try {
      await this.sound.setVolumeAsync(1);
      await this.sound.playAsync();
    } catch (e) {
      // no-op — audio hiccups shouldn't crash gameplay
    }
  }

  // Fades volume down over FADE_OUT_MS rather than cutting the loop dead.
  // Fire-and-forget by design (callers don't await this), so a re-squish
  // that lands mid-fade just calls start(), which cancels the fade timer
  // and snaps volume back to 1.
  async stop() {
    if (!this.sound) return;
    this._clearFade();
    const sound = this.sound;
    const steps = Math.round(FADE_OUT_MS / FADE_STEP_MS);
    let step = 0;
    this.fadeTimer = setInterval(async () => {
      step += 1;
      const volume = Math.max(0, 1 - step / steps);
      try {
        await sound.setVolumeAsync(volume);
      } catch (e) {
        // sound may have been unloaded mid-fade — nothing to do
      }
      if (step >= steps) {
        this._clearFade();
        try {
          await sound.stopAsync();
          await sound.setVolumeAsync(1);
        } catch (e) {
          // no-op
        }
      }
    }, FADE_STEP_MS);
  }

  async unload() {
    this._clearFade();
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
