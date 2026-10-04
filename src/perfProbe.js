// Tiny frame-time probe for the squish stage. Callers add the milliseconds
// they spent in a named section each frame; once every LOG_EVERY_MS the
// averages are logged (visible in logcat as ReactNativeJS) and handed to any
// subscriber (the FPS pill). Cheap enough to leave on: two performance.now()
// calls per section per frame.
const LOG_EVERY_MS = 2000;

const sections = {};
const gauges = {};
let frames = 0;
let intervalSum = 0;
let intervalMax = 0;
let lastFrameAt = 0;
let lastLogAt = 0;
let latest = null;
const listeners = new Set();

export function add(name, ms) {
  sections[name] = (sections[name] || 0) + ms;
}

// A value that's reported as-is (its latest reading), not averaged per frame.
export function set(name, value) {
  gauges[name] = value;
}

// Call once per rendered frame.
export function frame() {
  const now = performance.now();
  if (lastFrameAt) {
    const dt = now - lastFrameAt;
    intervalSum += dt;
    if (dt > intervalMax) intervalMax = dt;
  }
  lastFrameAt = now;
  frames += 1;
  if (!lastLogAt) lastLogAt = now;
  if (now - lastLogAt >= LOG_EVERY_MS) {
    const secs = (now - lastLogAt) / 1000;
    const out = { fps: frames / secs, frameMs: intervalSum / Math.max(1, frames - 1), maxMs: intervalMax };
    Object.keys(sections).forEach((k) => {
      out[k] = sections[k] / frames;
      sections[k] = 0;
    });
    Object.keys(gauges).forEach((k) => {
      out[k] = gauges[k];
    });
    latest = out;
    // eslint-disable-next-line no-console
    console.log(
      `[perf] ${out.fps.toFixed(1)} fps, frame ${out.frameMs.toFixed(1)} ms (max ${out.maxMs.toFixed(0)}) ` +
        Object.keys(out)
          .filter((k) => !['fps', 'frameMs', 'maxMs'].includes(k))
          .map((k) => `${k} ${out[k].toFixed(2)}`)
          .join(', ')
    );
    listeners.forEach((fn) => fn(out));
    frames = 0;
    intervalSum = 0;
    intervalMax = 0;
    lastLogAt = now;
  }
}

export function subscribe(fn) {
  listeners.add(fn);
  if (latest) fn(latest);
  return () => listeners.delete(fn);
}

export default { add, set, frame, subscribe };
