import { Audio } from 'expo-av';

// Base for short one-shot effects that can overlap (the coin ding on every
// earn tick, the release pop). A small pool of players is loaded once and
// replayed round-robin, so rapid triggers each ring out in full instead of
// the newest cutting off the previous one — without creating a player per
// play: every expo-av Sound is a whole ExoPlayer, built on the UI thread,
// and spinning one up mid-squish cost a visible frame hitch each time.
const VOICES = 3;

export class OneShotSound {
  constructor(source, volume = 1) {
    this.source = source;
    this.volume = volume;
    this.voices = [];
    this.next = 0;
    this.loading = null;
  }

  load() {
    if (!this.loading) {
      this.loading = Promise.all(
        Array.from({ length: VOICES }, () =>
          Audio.Sound.createAsync(this.source, { volume: this.volume, shouldPlay: false, progressUpdateIntervalMillis: 60000 })
            .then((r) => r.sound)
            .catch(() => null)
        )
      ).then((sounds) => {
        this.voices = sounds.filter(Boolean);
      });
    }
    return this.loading;
  }

  async play() {
    try {
      if (!this.voices.length) await this.load();
      const sound = this.voices[this.next % (this.voices.length || 1)];
      this.next += 1;
      if (!sound) return;
      // one native call: restart from the top
      await sound.replayAsync();
    } catch (e) {
      // no-op — audio hiccups shouldn't crash gameplay
    }
  }

  async unload() {
    const sounds = this.voices;
    this.voices = [];
    this.loading = null;
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
