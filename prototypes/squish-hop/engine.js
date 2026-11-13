// Squish Hop: the rules and the solver. The same file runs in the page
// (<script src="engine.js">, as window.HopEngine) and in Node (tools/).
//
// A level is a grid of cushions. The squishy hops one cell at a time; the
// cushion it leaves puffs away, so it can't go back there. Hopping onto the
// ★ cushion ends the level, and three stars need every other cushion
// cleared first. The twists:
//   pile      'D'  two cushions on top of each other: two hops to clear
//   friend    'F'  hop on to pick it up; the ★ opens when all are picked up
//   in order  '1'-'9'  numbered friends, picked up in that order
//   arrow     '^' '>' 'v' '<'  you can only hop off it the way it points
//   bubble    'o'  hop onto it and you bounce on, one cushion further the
//                  same way (and on again over more bubbles); you can't hop
//                  onto it if there's nothing to land on past it
//   beat      'a' 'b' 'c'  a beat tile lights up every third hop: you can
//                  only land on it on hop 3k+1 ('b'), 3k+2 ('c') or 3k ('a')
// Other letters: '#' no cushion, '.' cushion, 'S' start, 'G' the ★.
(function (root) {
  // up, right, down, left
  const DIRS = [
    [0, -1],
    [1, 0],
    [0, 1],
    [-1, 0],
  ];
  const DCH = 'URDL';
  const ARROWS = { '^': 0, '>': 1, v: 2, '<': 3 };
  const BEATS = { a: 0, b: 1, c: 2 };

  function parse(rows) {
    const h = rows.length;
    const w = Math.max(...rows.map((r) => r.length));
    const n = w * h;
    const life = new Array(n).fill(0);
    const arrow = new Array(n).fill(-1);
    const bubble = new Array(n).fill(false);
    const beat = new Array(n).fill(-1);
    const order = new Array(n).fill(0);
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
        else if (ch === 'G') goal = i;
        else if (ch === 'F') friends.push(i);
        else if (ch >= '1' && ch <= '9') {
          friends.push(i);
          order[i] = Number(ch);
        } else if (ch in ARROWS) arrow[i] = ARROWS[ch];
        else if (ch === 'o') bubble[i] = true;
        else if (ch in BEATS) beat[i] = BEATS[ch];
      }
    }
    if (start < 0 || goal < 0) throw new Error('a level needs S and G');
    // nb[i][d]: the cushion next to i in direction d, or -1
    const nb = life.map((_, i) => {
      const x = i % w;
      const y = (i / w) | 0;
      return DIRS.map(([dx, dy]) => {
        const nx = x + dx;
        const ny = y + dy;
        return nx >= 0 && ny >= 0 && nx < w && ny < h && life[ny * w + nx] > 0 ? ny * w + nx : -1;
      });
    });
    const nbrs = nb.map((a) => a.filter((j) => j >= 0));
    const fbit = life.map(() => 0);
    friends.forEach((c, k) => (fbit[c] = 1 << k));
    // a numbered friend needs every lower-numbered one picked up first
    const need = life.map((_, i) => {
      if (!order[i]) return 0;
      let m = 0;
      friends.forEach((c) => {
        if (order[c] && order[c] < order[i]) m |= fbit[c];
      });
      return m;
    });
    return { w, h, life, start, goal, friends, nb, nbrs, fbit, need, order, arrow, bubble, beat, all: (1 << friends.length) - 1 };
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

  // Why a cell can't be landed on right now ('' if it can). `hops` is how
  // many cells have been entered so far (the start is entry 0).
  function blockOf(lv, life, got, hops, j) {
    if (j < 0) return 'edge';
    if (life[j] <= 0) return 'gone';
    if (j === lv.goal && got !== lv.all) return 'locked';
    if (lv.need[j] & ~got) return 'order';
    if (lv.beat[j] >= 0 && (hops + 1) % 3 !== lv.beat[j]) return 'beat';
    return '';
  }

  // Hop from where the squishy stands in direction d. Returns { ok, cells
  // (every cell entered, bubbles included), st } or { ok: false, why, cell }.
  function tryMove(lv, st, d) {
    if (st.done) return { ok: false, why: 'done', cell: -1 };
    if (lv.arrow[st.cur] >= 0 && lv.arrow[st.cur] !== d) return { ok: false, why: 'arrow', cell: st.cur };
    const life = st.life.slice();
    let got = st.got;
    let hops = st.hops;
    let at = st.cur;
    const cells = [];
    life[at]--;
    for (;;) {
      const j = lv.nb[at][d];
      const why = blockOf(lv, life, got, hops, j);
      if (why) return { ok: false, why: cells.length ? 'bounce' : why, cell: cells.length ? cells[0] : j, at: j };
      hops++;
      got |= lv.fbit[j];
      cells.push(j);
      at = j;
      if (j !== lv.goal && lv.bubble[j]) {
        life[j]--;
        continue;
      }
      break;
    }
    return { ok: true, cells, st: { cur: at, life, got, hops, done: at === lv.goal } };
  }

  function moves(lv, st) {
    const out = [];
    for (let d = 0; d < 4; d++) {
      const m = tryMove(lv, st, d);
      if (m.ok) out.push({ d, cells: m.cells, st: m.st });
    }
    return out;
  }

  const ABORT = { abort: true };

  // Depth-first search for move lists (directions) that clear every cushion
  // and end on the ★. { limit } caps the nodes visited; { count, cap }
  // collects up to `cap` answers instead of stopping at the first;
  // { rand } (a 0..1 function) shuffles the order moves are tried in.
  // Returns { path, sols, count, nodes, aborted }.
  function search(lv, st, opts = {}) {
    const limit = opts.limit ?? 200000;
    const cap = opts.count ? opts.cap ?? 50 : 1;
    const rand = opts.rand || null;
    const life = st.life.slice();
    const n = life.length;
    const { goal, nb, nbrs, arrow, bubble, beat, fbit, need, all } = lv;
    let remaining = leftOf(lv, life);
    let nodes = 0;
    const sols = [];
    const path = [];
    const seen = new Int32Array(n);
    let stamp = 0;
    const queue = new Int32Array(n);
    const ORDER = [0, 1, 2, 3];
    // the bubbles popped by the moves on the way down, to put back
    const bstack = new Int32Array(n + 4);
    let bsp = 0;

    function live(j) {
      return j >= 0 && life[j] > 0;
    }
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
      for (let c = 0; c < n; c++) {
        if (c === cur || c === goal || life[c] <= 0) continue;
        // an arrow has to have somewhere to send you
        if (arrow[c] >= 0) {
          const t = nb[c][arrow[c]];
          if (!live(t)) return false;
        }
        if (life[c] !== 1) continue;
        if (bubble[c]) {
          // a bubble needs a way in and the way straight on out
          let any = false;
          for (let d = 0; d < 4 && !any; d++) {
            const out = nb[c][d];
            const inn = nb[c][(d + 2) % 4];
            if (live(out) && live(inn) && inn !== goal) any = true;
          }
          if (!any) return false;
          continue;
        }
        // a single cushion with one live neighbour has to be entered from
        // it and left back onto it, so that neighbour needs two hops left
        // (a pile), and the ★ can't be it
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

    function rec(cur, got, hops) {
      if (++nodes > limit) throw ABORT;
      life[cur]--;
      remaining--;
      let dirs = arrow[cur] >= 0 ? [arrow[cur]] : ORDER;
      if (rand && dirs.length > 1) {
        dirs = ORDER.slice();
        for (let i = 3; i > 0; i--) {
          const k = Math.floor(rand() * (i + 1));
          const t = dirs[i];
          dirs[i] = dirs[k];
          dirs[k] = t;
        }
      }
      for (const d of dirs) {
        let at = cur;
        let g = got;
        let h = hops;
        let okMove = true;
        const base = bsp;
        let j = -1;
        for (;;) {
          j = nb[at][d];
          if (j < 0 || life[j] <= 0 || (j === goal && g !== all) || need[j] & ~g || (beat[j] >= 0 && (h + 1) % 3 !== beat[j])) {
            okMove = false;
            break;
          }
          h++;
          g |= fbit[j];
          at = j;
          if (j !== goal && bubble[j]) {
            life[j]--;
            remaining--;
            bstack[bsp++] = j;
            continue;
          }
          break;
        }
        if (okMove) {
          path.push(d);
          if (j === goal) {
            if (remaining === 0 && g === all) {
              sols.push(path.slice());
              if (sols.length >= cap) {
                path.pop();
                restore(base);
                life[cur]++;
                remaining++;
                throw ABORT;
              }
            }
          } else if (ok(j)) rec(j, g, h);
          path.pop();
        }
        restore(base);
      }
      life[cur]++;
      remaining++;
    }
    function restore(base) {
      while (bsp > base) {
        life[bstack[--bsp]]++;
        remaining++;
      }
    }

    let aborted = false;
    if (st.done) {
      const clear = remaining === 0;
      return { path: clear ? [] : null, sols: clear ? [[]] : [], count: clear ? 1 : 0, nodes: 0, aborted: false };
    }
    try {
      if (ok(st.cur)) rec(st.cur, st.got, st.hops);
    } catch (e) {
      if (e !== ABORT) throw e;
      aborted = sols.length < cap;
    }
    return { path: sols[0] || null, sols, count: sols.length, nodes, aborted };
  }

  // the cells a list of moves enters (the first cell of each move, then
  // any bubbles bounced over), and the state after them
  function replay(lv, dirs, st0) {
    let st = st0 || newState(lv);
    const steps = [];
    for (const d of dirs) {
      const m = tryMove(lv, st, d);
      if (!m.ok) return { ok: false, steps, st };
      steps.push(m);
      st = m.st;
    }
    return { ok: true, steps, st };
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

  const api = { DIRS, DCH, ARROWS, BEATS, parse, leftOf, newState, blockOf, tryMove, moves, search, replay, starsFor, parityOk };
  if (typeof module !== 'undefined' && module.exports) module.exports = api;
  else root.HopEngine = api;
})(typeof window !== 'undefined' ? window : globalThis);
