// Rebuilds ../index.html in place: swaps in the Squeeze engine + levels.js +
// sqzview.js and choir.js, plus their card markup. usage: node assemble.js
const fs = require("fs");
const path = require("path");
const dir = __dirname, pagePath = path.join(dir, "..", "index.html");
const lines = fs.readFileSync(pagePath, "utf8").split("\n");
const find = (re, from = 0) => { for (let i = from; i < lines.length; i++) if (re.test(lines[i])) return i; throw new Error("not found " + re); };
const sqzCardStart = find(/<section class="card pick" id="squeeze"/);
const sqzCardEnd = find(/<\/section>/, sqzCardStart);
const choirCardStart = find(/<section class="card" id="choir"/);
const choirCardEnd = find(/<\/section>/, choirCardStart);
const sqzCodeStart = find(/^\/\* 1\. SQUISH SQUEEZE/) - 1;
const clawCodeStart = find(/^\/\* 2\. CLAW RUN/) - 1;
const choirCodeStart = find(/^\/\* 4\. SQUISH CHOIR/) - 1;
const loopStart = find(/^\/\* Loop: draw only/) - 1;

const engine = fs.readFileSync(path.join(dir, "engine.js"), "utf8").split("/*ENGINE-START*/")[1].split("/*ENGINE-END*/")[0];
const levels = fs.readFileSync(path.join(dir, "levels.js"), "utf8");
const view = fs.readFileSync(path.join(dir, "sqzview.js"), "utf8");
const choir = fs.readFileSync(path.join(dir, "choir.js"), "utf8");

const sqzCard = `    <section class="card pick" id="squeeze" aria-labelledby="sqz-h">
      <div class="card-head"><span class="mix">Box-pushing puzzle + soft bodies</span><span class="badge">My pick</span></div>
      <h2 id="sqz-h">Squish Squeeze</h2>
      <p class="rules">Tuck everyone into bed. Walk into a gap that is too tight and you squeeze thin. The moment there is room, you puff back up and shove whatever is beside you. Toy blocks go into the dashed toy boxes. Blocks can't be pulled, and a round plush can't push a block into a narrow gap because its other half hits the wall. So the puzzle is planning where you squeeze, and where you pop out.</p>
      <div class="lvls" id="sqz-levels" role="group" aria-label="Levels"></div>
      <div class="stage"><canvas id="sqz-cv" class="touch-none" tabindex="0" aria-label="Squish Squeeze level. Use the arrow keys to move."></canvas></div>
      <div class="hud"><span class="stat">Moves <span id="sqz-moves">0</span></span><span class="stat">Best possible <span id="sqz-par">0</span></span><span class="stat stars" id="sqz-stars"></span><span class="msg" id="sqz-msg" aria-live="polite"></span></div>
      <div class="controls">
        <div class="dpad" role="group" aria-label="Move">
          <button class="btn sq blue up" data-dir="up" aria-label="Up">↑</button>
          <button class="btn sq blue left" data-dir="left" aria-label="Left">←</button>
          <button class="btn sq blue down" data-dir="down" aria-label="Down">↓</button>
          <button class="btn sq blue right" data-dir="right" aria-label="Right">→</button>
        </div>
        <div class="stack">
          <button class="btn grey" id="sqz-undo">Undo</button>
          <button class="btn" id="sqz-restart">Restart</button>
        </div>
        <button class="btn gold" id="sqz-hint">Hint</button>
      </div>
      <p class="hint">Arrow keys, swipe, or tap where you want to go. Three stars for the best possible move count, two for up to half as many again (or if you used a hint). Hint works out your next move from where you are, and tells you if you are stuck.</p>
    </section>`;
const choirCard = `    <section class="card" id="choir" aria-labelledby="choir-h">
      <div class="card-head"><span class="mix">Rhythm game + memory game</span></div>
      <h2 id="choir-h">Squish Choir</h2>
      <p class="rules">The choir sings a short phrase. Play it back with the same singers and the same rhythm, off-beats included. Every round is longer and faster, and twists arrive: two singers swap seats, two sing at once, or they hide behind a curtain so you can only hear them. One wrong singer or one off-beat tap fails the round.</p>
      <div class="stage"><canvas id="choir-cv" class="touch-tap" tabindex="0" aria-label="Choir stage. Press keys 1 to 5 to squish the singer in each seat."></canvas></div>
      <div class="hud">
        <span class="stat">Round <span id="choir-round">1</span></span>
        <span class="stat">Tries <span id="choir-lives">3</span></span>
        <span class="stat">Score <span id="choir-score">0</span></span>
        <span class="stat"><span id="choir-bpm">92</span> BPM</span>
        <span class="msg" id="choir-msg" aria-live="polite">Turn your sound on. Tap the singers to learn their voices, then press Start.</span>
      </div>
      <div class="controls"><button class="btn gold big" id="choir-start">Start</button></div>
      <p class="hint">Tap a singer, or press 1 to 5 for the seats. After a swap the keys still mean seats, not singers. Each singer has their own sound, which you need for the curtain rounds. Bubbles joins in round 3: one more voice to tell apart.</p>
    </section>`;
const css = `.lvls{display:flex;flex-wrap:wrap;gap:8px}
.lvl{appearance:none;display:grid;justify-items:center;gap:2px;min-width:54px;padding:6px 8px 5px;border-radius:14px;border:2px solid #ecd2f7;background:var(--sheet);color:var(--ink);font-family:var(--display);cursor:pointer;touch-action:manipulation}
.lvl .n{font-weight:700;font-size:17px;line-height:1}
.lvl .st{font-size:11px;letter-spacing:1px;color:#e09a00;line-height:1}
.lvl[aria-current="true"]{background:linear-gradient(#fff7b0,#ffd23a);border-color:#c27a0a}
.lvl:focus-visible{outline:3px solid var(--pink);outline-offset:2px}
.stat.stars{color:#e09a00;letter-spacing:1px}
.stat:empty{display:none}
`;
const out = [
  ...lines.slice(0, sqzCardStart),
  sqzCard,
  ...lines.slice(sqzCardEnd + 1, choirCardStart),
  choirCard,
  ...lines.slice(choirCardEnd + 1, sqzCodeStart),
  "/* ------------------------------------------------------------------ */",
  "/* 1. SQUISH SQUEEZE: rules engine, levels (found by solver), view     */",
  "/* ------------------------------------------------------------------ */",
  engine.trim(),
  levels.trim(),
  view.trim(),
  "",
  ...lines.slice(clawCodeStart, choirCodeStart),
  choir.trim(),
  "",
  ...lines.slice(loopStart),
].join("\n").replace("footer{", lines.some(l => l.startsWith(".lvls{")) ? "footer{" : css + "footer{");
fs.writeFileSync(pagePath, out);
console.log("written", out.length, "chars");
