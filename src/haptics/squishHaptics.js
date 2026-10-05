import { Platform } from 'react-native';
import * as Haptics from 'expo-haptics';

// Vibration for the squish stage, following the squish sound's behaviour:
// one impact when the finger lands, a train of ticks while it moves (none
// while it rests), one impact when it lets go. Nothing for two-finger
// rotation or the coin ticks.
//
// The strength follows the Squish level setting (1-5). expo-haptics only
// has three real strengths on Android (light 30/255, medium 50/255, heavy
// 70/255 amplitude, 43-60 ms each), so the five levels also differ in how
// often the ticks come while dragging and whether the landing is a double
// tap. Phones whose motor can't vary amplitude still feel the rate change.
//
// iOS's Taptic Engine has five genuinely different styles (soft, light,
// medium, rigid, heavy), so there each level gets its own.
const { Soft, Light, Medium, Rigid, Heavy } = Haptics.ImpactFeedbackStyle;
const LEVELS = Platform.OS === 'ios'
  ? {
      1: { press: Soft, pressDouble: false, tick: Soft, tickMs: 150, release: Soft },
      2: { press: Light, pressDouble: false, tick: Light, tickMs: 110, release: Soft },
      3: { press: Medium, pressDouble: false, tick: Medium, tickMs: 90, release: Light },
      4: { press: Rigid, pressDouble: false, tick: Rigid, tickMs: 75, release: Light },
      5: { press: Heavy, pressDouble: true, tick: Heavy, tickMs: 65, release: Medium },
    }
  : {
      1: { press: Light, pressDouble: false, tick: Light, tickMs: 150, release: Light },
      2: { press: Medium, pressDouble: false, tick: Light, tickMs: 110, release: Light },
      3: { press: Medium, pressDouble: false, tick: Medium, tickMs: 90, release: Light },
      4: { press: Heavy, pressDouble: false, tick: Medium, tickMs: 75, release: Medium },
      5: { press: Heavy, pressDouble: true, tick: Heavy, tickMs: 65, release: Medium },
    };

const levelFor = (strength) => LEVELS[Math.max(1, Math.min(5, Math.round(strength || 3)))];
const fire = (style) => {
  Haptics.impactAsync(style).catch(() => {
    // no vibrator (emulator) or haptics disabled by the system — nothing to do
  });
};

let lastTickAt = 0;

// The finger landed on the creature.
export function pressHaptic(strength) {
  const cfg = levelFor(strength);
  fire(cfg.press);
  if (cfg.pressDouble) setTimeout(() => fire(Light), 70);
  lastTickAt = Date.now();
}

// The finger moved (called on every real movement; rate-limited here).
export function moveHaptic(strength) {
  const cfg = levelFor(strength);
  const now = Date.now();
  if (now - lastTickAt < cfg.tickMs) return;
  lastTickAt = now;
  fire(cfg.tick);
}

// The finger let go of a squish.
export function releaseHaptic(strength) {
  fire(levelFor(strength).release);
}

export default { pressHaptic, moveHaptic, releaseHaptic };
