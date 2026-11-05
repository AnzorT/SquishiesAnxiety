// Squish Hop: the rules and the solver. The same file runs in the page
// (<script src="engine.js">, as window.HopEngine) and in Node (tools/).
//
// A level is a grid of cushions. The squishy hops one cell at a time; the
// cushion it leaves puffs away, so it can't go back there. A double cushion
// takes two hops to clear. Friends sit on cushions and are picked up by
// hopping onto them. The ★ cushion ends the level, and it only lets the
// squishy on once every friend is picked up. Three stars: every cushion
// cleared before the ★.
//
// Map letters: '#' no cushion, '.' cushion, 'D' double cushion, 'S' start,
// 'G' the ★ cushion, 'F' a friend on a cushion.
(function (root) {
  const DIRS = [
    [0, -1],
    [1, 0],
    [0, 1],
    [-1, 0],
  ];

  function parse(rows) {
    const h = rows.length;
    const w = Math.max(...rows.map((r) => r.length));
    const life = new Array(w * h).fill(0);
    const friends = [];
    let start = -1;
    let goal = -1;
    for (let y = 0; y < h; y++) {
      for (let x = 0; x < w; x++) {
        const ch = rows[y][x] || '#';
        const i = y * w + x;
        if (ch === '#') continue;
        life[i] = ch === 'D' ? 2 : 1;
        if (ch === 'S') start = i;
        if (ch === 'G') goal = i;
        if (ch === 'F') friends.push(i);
      }
    }
    if (start < 0 || goal < 0) throw new Error('a level needs S and G');
    const nbrs = life.map((_, i) => {
      const x = i % w;
      const y = (i / w) | 0;
      const out = [];
      for (const [dx, dy] of DIRS) {
        const nx = x + dx;
        const ny = y + dy;
        if (nx >= 0 && ny >= 0 && nx < w && ny < h && life[ny * w + nx] > 0) out.push(ny * w + nx);
      }
      return out;
    });
    const fbit = life.map(() => 0);
    friends.forEach((c, k) => (fbit[c] = 1 << k));
    return { w, h, life, start, goal, friends, nbrs, fbit, all: (1 << friends.length) - 1 };
  }

  // the cells still to clear (the ★ cushion isn't one), counting the one
  // the squishy stands on
  function leftOf(lv, life) {
    let n = 0;
    for (let i = 0; i < life.length; i++) if (i !== lv.goal) n += life[i];
    return n;
  }

  function newState(lv) {
    return { cur: lv.start, life: lv.life.slice(), got: 0, hops: 0, done: false };
  }

  // can the squishy hop from where it is onto cell j?
  function canEnter(lv, st, j) {
    if (st.life[j] <= 0) return false;
    if (j === lv.goal && st.got !== lv.all) return false;
    return lv.nbrs[st.cur].includes(j);
  }

  function moves(lv, st) {
    if (st.done) return [];
    return lv.nbrs[st.cur].filter((j) => st.life[j] > 0 && (j !== lv.goal || st.got === lv.all));
  }

  // the state after hopping onto j (no checks: use canEnter first)
  function step(lv, st, j) {
    const life = st.life.slice();
    life[st.cur]--;
    return { cur: j, life, got: st.got | lv.fbit[j], hops: st.hops + 1, done: j === lv.goal };
  }

  const ABORT = { abort: true };

  // Depth-first search for paths that clear every cushion and end on the ★.
  // { limit } caps the nodes visited; { count, cap } counts answers instead
  // of stopping at the first. Returns { path, count, nodes, aborted }, path
  // being the cells to hop onto, in order (null if none was found).
  function search(lv, st, opts = {}) {
    const limit = opts.limit ?? 200000;
    const cap = opts.count ? opts.cap ?? 50 : 1;
    const life = st.life.slice();
    const n = life.length;
    const goal = lv.goal;
    const nbrs = lv.nbrs;
    let remaining = leftOf(lv, life);
    let nodes = 0;
    let count = 0;
    let first = null;
    const path = [];
    const seen = new Int32Array(n);
    let stamp = 0;
    const queue = new Int32Array(n);

    // can everything still be cleared, judging from the board's shape?
    function ok(cur) {
      // every live cell (and the ★) in one piece with the squishy
      stamp++;
      let head = 0;
      let tail = 0;
      queue[tail++] = cur;
      seen[cur] = stamp;
      while (head < tail) {
        const c = queue[head++];
        if (c === goal) continue; // the ★ ends the level: no way through it
        for (const m of nbrs[c]) {
          if (life[m] > 0 && seen[m] !== stamp) {
            seen[m] = stamp;
            queue[tail++] = m;
          }
        }
      }
      let alive = 0;
      for (let i = 0; i < n; i++) if (life[i] > 0) alive++;
      if (tail !== alive) return false;
      // dead ends: a single cushion with one live neighbour has to be
      // entered from it and left back onto it, so that neighbour needs two
      // hops left (a double), and the ★ can't be it
      for (let c = 0; c < n; c++) {
        if (c === cur || c === goal || life[c] !== 1) continue;
        let deg = 0;
        let only = -1;
        for (const m of nbrs[c]) {
          if (life[m] > 0) {
            deg++;
            only = m;
          }
        }
        if (deg === 0) return false;
        if (deg === 1 && (only === goal || life[only] < 2)) return false;
      }
      return true;
    }

    function rec(cur, got) {
      if (++nodes > limit) throw ABORT;
      life[cur]--;
      remaining--;
      for (const m of nbrs[cur]) {
        if (life[m] <= 0) continue;
        if (m === goal) {
          if (got === lv.all && remaining === 0) {
            count++;
            if (!first) first = path.concat([goal]);
            if (count >= cap) {
              life[cur]++;
              remaining++;
              throw ABORT;
            }
          }
          continue;
        }
        path.push(m);
        if (ok(m)) rec(m, got | lv.fbit[m]);
        path.pop();
      }
      life[cur]++;
      remaining++;
    }

    let aborted = false;
    if (st.done) {
      return { path: remaining === 0 ? [] : null, count: remaining === 0 ? 1 : 0, nodes: 0, aborted: false };
    }
    try {
      if (ok(st.cur)) rec(st.cur, st.got);
    } catch (e) {
      if (e !== ABORT) throw e;
      aborted = count < cap;
    }
    return { path: first, count, nodes, aborted };
  }

  // Stars for a finished level: 3 for every cushion cleared, 2 for up to
  // 3 left, else 1; a hint takes one off (never below 1).
  function starsFor(left, hinted) {
    const s = left === 0 ? 3 : left <= 3 ? 2 : 1;
    return Math.max(1, s - (hinted ? 1 : 0));
  }

  // A quick check before the search: on a chessboard colouring the hops
  // alternate colours, so the visits to each colour must match up.
  function parityOk(lv) {
    let a = 0;
    let b = 0;
    for (let i = 0; i < lv.life.length; i++) {
      const v = i === lv.goal ? 1 : lv.life[i];
      if (!v) continue;
      const x = i % lv.w;
      const y = (i / lv.w) | 0;
      if ((x + y) % 2) a += v;
      else b += v;
    }
    const col = (i) => ((i % lv.w) + ((i / lv.w) | 0)) % 2;
    const len = a + b;
    if (len % 2 === 0) return a === b && col(lv.start) !== col(lv.goal);
    const major = a > b ? 1 : 0;
    return Math.abs(a - b) === 1 && col(lv.start) === major && col(lv.goal) === major;
  }

  const api = { DIRS, parse, leftOf, newState, canEnter, moves, step, search, starsFor, parityOk };
  if (typeof module !== 'undefined' && module.exports) module.exports = api;
  else root.HopEngine = api;
})(typeof window !== 'undefined' ? window : globalThis);
