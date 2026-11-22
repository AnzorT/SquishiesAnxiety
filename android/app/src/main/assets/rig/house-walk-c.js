// Per-creature walks for the Squad House (gaits live in house-walk.js). g = gait, a = size, r = tempo, x = extra channels synced to the step
// ([amp, harmonic, phase, abs]), sm = max facing angle while walking (flat ones never go edge-on), c = constant channels while walking, m = scale a gait channel, fx = [particle, ms] while walking, dust = particle on each footfall.
(function () {
  const add = W => {
    const d = (k, P) => W.def(k, P);
    // ---------- Pet Shop ----------
    d('mittens', { g: 'trot', x: { wag: [10, 2] } });
    d('biscuit', { g: 'trot', a: 1.15, r: 1.1, x: { wag: [24, 2] }, c: { hap: 0.5, smile: 1, open: 0.3, tongue: 0.4 } });
    d('prickle', { g: 'scurry', a: 1 });
    d('truffle', { g: 'trot', a: 0.9, x: { wag: [16, 2] } });
    d('ribbit', { g: 'hop', a: 1.2 });
    d('nibbles', { g: 'scurry', a: 1.1, r: 1.1 });
    d('quill', { g: 'waddle', a: 0.8, r: 0.9 });
    d('waffles', { g: 'trot' });
    d('poppy', { g: 'hop', a: 1 });
    d('duchess', { g: 'prance', a: 1, x: { wag: [12, 1] }, c: { close: 0.3 } });
    d('mamapaws', { g: 'waddle', a: 0.7, r: 0.85, c: { smile: 0.6 } });
    // ---------- Sky & Stars ----------
    d('nimbo', { g: 'float', fx: ['drop', 240] });
    d('lumi', { g: 'float', a: 0.9, x: { x: [1.2, 1] } });
    d('bubbly', { g: 'float', fx: ['bubble', 700] });
    d('twinkle', { g: 'float', a: 1.1, sm: 45, x: { glow: [0.3, 2, 0, 1] }, fx: ['spark', 520] });
    d('zappi', { g: 'scurry', r: 0.85, x: { zap: [0.3, 4, 0, 1] }, fx: ['spark', 420] });
    d('plip', { g: 'bounce', a: 0.8, fx: ['drop', 600] });
    d('breeze', { g: 'float', a: 1.2, x: { puff: [0.15, 1, 0, 1] } });
    d('dusty', { g: 'flutter', a: 0.8, wing: 'own' });
    d('aurora', { g: 'float', r: 0.85, x: { wag: [20, 1] } });
    // ---------- Snack Shack ----------
    d('mallow', { g: 'bounce' });
    d('bao', { g: 'bounce', a: 0.85, fx: ['steam', 900] });
    d('dunkie', { g: 'roll', sm: 50 });
    d('frybo', { g: 'shuffle', x: { fw: [0.4, 2, 0, 1] } });
    d('bunbun', { g: 'bounce', a: 0.9, x: { split: [0.25, 1, 0, 1] } });
    d('choco', { g: 'shuffle', a: 1.1, sm: 50 });
    d('scoop', { g: 'waddle', a: 0.7, x: { chb: [0.6, 2, 0, 1] } });
    d('boba', { g: 'bounce', a: 0.8 });
    d('chefbun', { g: 'prance', a: 0.8 });
    // ---------- Ocean Pals ----------
    d('pip', { g: 'waddle', a: 1.2 });
    d('jelli', { g: 'float', r: 1.2, x: { sq: [0.06, 1] } });
    d('finn', { g: 'galumph' });
    d('sealy', { g: 'galumph', a: 1.1 });
    d('puff', { g: 'float', a: 0.9, x: { armL: [10, 4], armR: [10, 4, Math.PI] } });
    d('shelly', { g: 'plod', c: { nk: 0.3 }, x: { nk: [0.15, 2] } });
    d('seaturtle', { g: 'plod', c: { nk: 0.25 }, x: { nk: [0.12, 2] } });   // Nov 12: the real sea turtle rows along on its flippers (rive-generic turns the walk speed into flipper strokes)
    d('octo', { g: 'crawl', c: { ow: 0.8 } });
    d('marina', { g: 'galumph', a: 0.8, x: { tsw: [0.5, 1] }, c: { tun: 0.5 } });
    d('pearl', { g: 'galumph', x: { hsw: [0.4, 1], fflap: [0.6, 2, 0, 1] } });
    // ---------- Fruit Patch ----------
    d('pina', { g: 'waddle', a: 0.8, r: 0.9, x: { crw: [0.3, 2, 0, 1] } });
    d('avo', { g: 'waddle', a: 0.9, x: { prw: [0.4, 1, 0, 1] } });
    d('berri', { g: 'skip', x: { stw: [0.6, 2, 0, 1] } });
    d('lemmy', { g: 'roll', a: 0.8 });
    d('kiwi', { g: 'strut', x: { fzz: [0.2, 2, 0, 1] } });
    d('melo', { g: 'shuffle', sm: 45, x: { sdj: [0.6, 2, 0, 1] } });
    d('peachy', { g: 'skip', a: 0.85, x: { lfl: [0.5, 2, 0, 1] } });
    d('pitaya', { g: 'stomp', a: 0.8, x: { wfl: [0.5, 1, 0, 1] }, c: { brf: 0.2 } });
    d('tutti', { g: 'flutter', a: 0.8, wing: 'own', c: { wfl: 1 }, fx: ['spark', 600] });
    // ---------- Forest Friends ----------
    d('kiko', { g: 'trot', x: { wag: [12, 2] } });
    d('teddy', { g: 'stomp', a: 0.8 });
    d('hoot', { g: 'waddle', sm: 65, x: { wfl: [0.4, 1, 0, 1] } });
    d('leo', { g: 'trot', a: 1.1, x: { tsw: [0.5, 1], msh: [0.2, 2, 0, 1] }, c: { pitch: -0.02 } });
    d('panko', { g: 'waddle', a: 1.1, r: 0.9 });
    d('acorn', { g: 'hop', a: 0.8, r: 1.25, x: { tsw: [0.5, 1], tfl: [0.4, 1, 0, 1] } });
    d('fawn', { g: 'prance', a: 1.1 });
    d('moss', { g: 'bounce', a: 0.8, x: { cb: [0.7, 1, 0, 1] } });
    d('sprout', { g: 'skip', a: 0.9, x: { lfl: [0.5, 2, 0, 1], stw: [0.5, 2, 0, 1] } });
    // ---------- Dreamland ----------
    d('hana', { g: 'hop', a: 1.1, x: { tw: [1, 2] } });
    d('boo', { g: 'float', x: { flr: [0.4, 1, 0, 1] }, c: { flr: 0.3 } });
    d('pixie', { g: 'flutter', wing: 'own', c: { wfl: 1 }, fx: ['spark', 500] });
    d('floof', { g: 'stomp', a: 1.1, x: { fzz: [0.3, 2, 0, 1] }, dust: 'sand' });
    d('unibun', { g: 'prance', fx: ['spark', 900] });
    d('gumdrop', { g: 'bounce', a: 0.5, x: { jig: [0.25, 1, 0, 1] } });
    d('ember', { g: 'strut', x: { wfl: [0.5, 2, 0, 1], cfl: [0.3, 2, 0, 1] } });
    d('drako', { g: 'stomp', a: 0.9, x: { tsw: [0.6, 1], wfl: [0.3, 2, 0, 1] }, dust: 'sand' });
    d('jinni', { g: 'float', x: { gwh: [0.4, 1] } });
    // ---------- Sweet Bakery ----------
    d('cuppy', { g: 'bounce', a: 0.8 });
    d('chip', { g: 'roll', a: 0.9, sm: 45 });
    d('twisty', { g: 'shuffle', a: 0.9, sm: 45 });
    d('crois', { g: 'waddle', a: 0.8, sm: 55 });
    d('maca', { g: 'hop', a: 0.7 });
    d('puddi', { g: 'bounce', a: 0.7, r: 0.8 });
    d('mochi', { g: 'bounce' });
    d('cakey', { g: 'shuffle', a: 0.8 });
    d('sugarplum', { g: 'prance' });
    // ---------- Spooky Squish ----------
    d('gourdy', { g: 'roll' });
    d('batty', { g: 'flutter', sm: 60 });
    d('kernel', { g: 'hop', a: 1.1, r: 1.25 });
    d('hexie', { g: 'trot', a: 0.9, x: { wag: [12, 2] } });
    d('mumbles', { g: 'zombie' });
    d('hocus', { g: 'glide', fx: ['spark', 800] });
    d('countsquishula', { g: 'glide', c: { pitch: -0.03 } });
  };
  if (window.HouseWalk) add(window.HouseWalk); else (window.HouseWalkC = window.HouseWalkC || []).push(add);
})();
