// Random showcase animations for creature viewers (lobby / squad select): idle a few seconds, then a random move, repeat.
// const sh = RigShuffle(); sh.attach(ctrl); pass sh.onState from the rig's onState; sh.stop() on unmount.
(function () {
  if (window.RigShuffle) return;
  const LIST = ['dance', 'happy', 'hop', 'spin', 'look', 'love', 'cheer', 'surprised', 'dance', 'turn'];
  window.RigShuffle = function () {
    let ctrl = null, t = 0, last = null;
    const next = () => {
      if (!ctrl) return; let k; do { k = LIST[Math.floor(Math.random() * LIST.length)]; } while (k === last);
      last = k; ctrl.play(k); clearTimeout(t);
      t = setTimeout(() => { if (ctrl) ctrl.play('idle'); }, k === 'dance' ? 11000 : 7000);
    };
    const wait = () => { clearTimeout(t); t = setTimeout(next, 2600 + Math.random() * 2800); };
    return {
      attach(c) { ctrl = c; last = null; wait(); },
      onState(a) { if (!ctrl) return; if (a === 'idle') wait(); else if (a !== last) clearTimeout(t); },
      stop() { ctrl = null; clearTimeout(t); },
    };
  };
})();
