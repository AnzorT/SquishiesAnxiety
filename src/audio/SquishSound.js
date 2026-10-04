import { Audio } from 'expo-av';

// A single looping sample that plays while the creature is being squished —
// and only while the finger is actually moving. A press starts it; once the
// finger rests (no movement for IDLE_PAUSE_MS) it fades out and pauses; the
// next movement fades it back in from where it stopped; letting go fades it
// out. Which sample depends on the creature (src/audio/creatureSquish.js),
// so the source is passed into load() rather than hardcoded here.
//
// Every level change is a fade (in FADE_STEP_MS steps) that starts from
// wherever the volume is right now, so a finger that stops and restarts
// mid-fade never hears a jump or a click. The player is paused, not
// stopped, so resuming continues the loop instead of restarting it.
const FADE_STEP_MS = 20;
// letting go
const RELEASE_FADE_MS = 400;
// finger holding still: how long before the sound starts to fade, and how
// long the fade takes
const IDLE_PAUSE_MS = 180;
const IDLE_FADE_MS = 350;
// finger moving again
const RESUME_FADE_MS = 120;

export class SquishSound {
  constructor() {
    this.sound = null;
    this.fadeTimer = null;
    this.fadeTarget = null; // where the running fade is heading
    this.idleTimer = null;
    this.held = false; // finger down (a poke in progress)
    this.audible = false; // player running (possibly mid-fade)
    this.volume = 0; // last volume sent to the player
  }

  _clearFade() {
    if (this.fadeTimer) {
      clearInterval(this.fadeTimer);
      this.fadeTimer = null;
    }
    this.fadeTarget = null;
  }

  _clearIdle() {
    if (this.idleTimer) {
      clearTimeout(this.idleTimer);
      this.idleTimer = null;
    }
  }

  _setVolume(v) {
    this.volume = v;
    if (!this.sound) return;
    this.sound.setVolumeAsync(v).catch(() => {
      // sound may have been unloaded mid-fade — nothing to do
    });
  }

  // Ramps from the current volume to `target` over `ms`, then calls onDone.
  _fadeTo(target, ms, onDone) {
    this._clearFade();
    this.fadeTarget = target;
    const from = this.volume;
    const steps = Math.max(1, Math.round(ms / FADE_STEP_MS));
    let step = 0;
    this.fadeTimer = setInterval(() => {
      step += 1;
      this._setVolume(from + ((target - from) * step) / steps);
      if (step >= steps) {
        this._clearFade();
        onDone && onDone();
      }
    }, FADE_STEP_MS);
  }

  _pause() {
    this.audible = false;
    if (!this.sound) return;
    // pauseAsync (not stopAsync) — stopAsync resets the playhead to 0,
    // which would restart the loop from the top on every resume. Pausing
    // keeps position so the next play resumes right where this left off.
    this.sound.pauseAsync().catch(() => {});
  }

  async _play() {
    this.audible = true;
    if (!this.sound) return;
    try {
      await this.sound.playAsync();
    } catch (e) {
      // no-op — audio hiccups shouldn't crash gameplay
    }
  }

  // Arms the "finger is resting" fade; every movement re-arms it.
  _armIdle() {
    this._clearIdle();
    this.idleTimer = setTimeout(() => {
      this.idleTimer = null;
      this._fadeTo(0, IDLE_FADE_MS, () => this._pause());
    }, IDLE_PAUSE_MS);
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
        volume: 0,
        progressUpdateIntervalMillis: 60000,
      });
      this.sound = sound;
    } catch (e) {
      this.sound = null;
    }
  }

  // A poke started: play at once (the press itself is a squish), then fade
  // out unless the finger keeps moving.
  start() {
    if (!this.sound) return;
    this.held = true;
    this._clearFade();
    this._setVolume(1);
    this._play();
    this._armIdle();
  }

  // The finger moved: keep the sound going, or bring it back if it had
  // faded while the finger rested.
  noteMotion() {
    if (!this.sound || !this.held) return;
    this._armIdle();
    if (!this.audible) this._play();
    // bring the level back up, unless a fade-in is already under way (a
    // drag calls this many times a second)
    if (this.volume < 1 && this.fadeTarget !== 1) this._fadeTo(1, RESUME_FADE_MS);
  }

  // Letting go: fade out and pause. Fire-and-forget by design (callers
  // don't await this); a new press that lands mid-fade just calls start().
  stop() {
    this.held = false;
    this._clearIdle();
    if (!this.sound) return;
    if (!this.audible && !this.fadeTimer) return; // already quiet
    this._fadeTo(0, RELEASE_FADE_MS, () => this._pause());
  }

  async unload() {
    this._clearFade();
    this._clearIdle();
    this.held = false;
    this.audible = false;
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
