// A virtual clock for the app's JS: Date.now, setTimeout / setInterval / clear*, with the same rules as the C# port's
// JsTimers (unity/Assets/Scripts/Audio/JsTimers.cs): a timer fires once the clock reaches its due time, with the clock
// at that time; timers due together fire in the order they were armed; an interval is re-armed (due + interval)
// before its callback runs. After every callback the promise jobs are run (the mocks resolve at once), so each
// callback's whole effect lands at its own time, as in C# where everything is synchronous.
const settle = () => new Promise((r) => setImmediate(r));

export class Clock {
  constructor(start) {
    this.now = start;
    this.live = [];
    this.nextId = 1;
    this.seq = 0;
  }

  install() {
    const c = this;
    Date.now = () => c.now;
    globalThis.setTimeout = (fn, ms = 0, ...a) => c.arm(() => fn(...a), ms, 0);
    globalThis.setInterval = (fn, ms = 0, ...a) => c.arm(() => fn(...a), ms, Math.max(1, ms));
    globalThis.clearTimeout = globalThis.clearInterval = (id) => c.clear(id);
  }

  arm(fn, ms, every) {
    const t = { id: this.nextId++, due: this.now + Math.max(0, +ms || 0), every, seq: ++this.seq, fn };
    this.live.push(t);
    return t.id;
  }

  clear(id) {
    if (!id) return;
    const i = this.live.findIndex((t) => t.id === id);
    if (i >= 0) this.live.splice(i, 1);
  }

  async advanceTo(to) {
    for (;;) {
      let next = null;
      for (const t of this.live) if (t.due <= to && (!next || t.due < next.due || (t.due === next.due && t.seq < next.seq))) next = t;
      if (!next) break;
      if (next.due > this.now) this.now = next.due;
      if (next.every > 0) {
        next.due += next.every;
        next.seq = ++this.seq;
      } else this.live.splice(this.live.indexOf(next), 1);
      next.fn();
      await settle();
    }
    if (to > this.now) this.now = to;
  }
}

export { settle };
