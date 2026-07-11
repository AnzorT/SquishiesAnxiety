// Core squish physics state machine.
// We fake true soft-body physics with a CPU-side scalar state (compression
// depth 0..1) driven by touch input, and an ease-out cubic "slow rise" decay
// back to 0 once touch is released. This scalar plus touch position feed the
// GPU shader's vertex-displacement uniforms every frame — cheap enough for
// mobile at 60fps while still feeling like real foam.

export const FILL_PROFILES = {
  memoryFoam: {
    label: 'Memory Foam',
    riseDuration: 2200, // ms to fully recover from full compression
    maxDepth: 0.85,
    burstThreshold: null, // never bursts
    audioProfile: 'foam-soft',
  },
  slime: {
    label: 'Slime',
    riseDuration: 650,
    maxDepth: 0.95,
    burstThreshold: null,
    audioProfile: 'slime-squelch',
  },
  glitterBead: {
    label: 'Glitter Bead',
    riseDuration: 900,
    maxDepth: 0.7,
    burstThreshold: 0.92,
    audioProfile: 'bead-crunch',
  },
};

// Ease-out cubic: fast initial recovery, gentle settle at the end —
// matches how slow-rise foam actually looks.
function easeOutCubic(t) {
  const clamped = Math.min(Math.max(t, 0), 1);
  return 1 - Math.pow(1 - clamped, 3);
}

export class SquishState {
  constructor(fillKey = 'memoryFoam') {
    this.setFill(fillKey);
    this.depth = 0; // 0 = at rest, 1 = fully compressed
    this.touchPoint = { x: 0.5, y: 0.5 };
    this.isTouching = false;
    this.releasedAt = null;
    this.depthAtRelease = 0;
    this.burst = false;
    this.listeners = new Set();
  }

  setFill(fillKey) {
    this.fillKey = fillKey;
    this.profile = FILL_PROFILES[fillKey] ?? FILL_PROFILES.memoryFoam;
  }

  onTouchMove(x, y, pressure = 1) {
    this.isTouching = true;
    this.touchPoint = { x, y };
    const target = Math.min(pressure, 1) * this.profile.maxDepth;
    // Compression itself is snappy (not eased) — it's the release that's slow.
    this.depth = Math.min(this.depth + (target - this.depth) * 0.5, this.profile.maxDepth);

    if (this.profile.burstThreshold && this.depth >= this.profile.burstThreshold) {
      this.burst = true;
      this._notify('burst');
    }
    this._notify('compress');
  }

  onTouchEnd() {
    if (!this.isTouching) return;
    this.isTouching = false;
    this.releasedAt = Date.now();
    this.depthAtRelease = this.depth;
    this._notify('release');
  }

  // Call every frame (e.g. from useFrame). Returns current depth 0..1.
  tick() {
    if (!this.isTouching && this.releasedAt !== null && this.depth > 0) {
      const elapsed = Date.now() - this.releasedAt;
      const t = elapsed / this.profile.riseDuration;
      const remaining = 1 - easeOutCubic(t);
      this.depth = this.depthAtRelease * remaining;
      if (this.depth <= 0.001) {
        this.depth = 0;
        this.releasedAt = null;
      }
    }
    return this.depth;
  }

  reset() {
    this.depth = 0;
    this.releasedAt = null;
    this.burst = false;
  }

  subscribe(fn) {
    this.listeners.add(fn);
    return () => this.listeners.delete(fn);
  }

  _notify(event) {
    this.listeners.forEach((fn) => fn(event, this));
  }
}

export default SquishState;
