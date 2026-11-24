// Injected into the Expo web app's preview page (http://localhost:8081/?preview=1): mounts the app's OWN squish stage,
// exactly as SquishScreen's SquishStage does (src/screens/SquishScreen.js: the same camera, gl settings, lights,
// <Supersample factor={2} /> and <SquishyToy ... cardUrl stage />), with the module instances of the app's bundle
// (Metro's __r), into a 384 x 384 dp box at the phone's density (dpr 2.8125, as expo-gl renders: R3F native's
// dpr = PixelRatio.get()). The clocks (Date.now, performance.now, requestAnimationFrame) are virtual, so a test steps
// the app frame by frame and reads its state (window.__toy: SquishyToy's own per-toy state object `s`).
//   window.__squishMount({ url, id, stage, bg }) -> Promise   then __squishStep(ms), __squishState(), __squishHandle
(function () {
  const mods = () => __r.getModules();
  function mod(re) {
    for (const [id, m] of mods()) if (m && m.verboseName && re.test(m.verboseName)) return __r(id);
    throw new Error('module not in the bundle: ' + re);
  }
  // --- virtual clocks ---
  let vt = 1700000000000;
  let rafQ = [];
  const realRaf = window.requestAnimationFrame.bind(window);
  function installClock() {
    Date.now = () => vt;
    performance.now = () => vt - 1700000000000 + 1000;
    window.requestAnimationFrame = (cb) => { rafQ.push(cb); return rafQ.length; };
    window.cancelAnimationFrame = () => {};
  }
  window.__squishStep = (ms) => {
    vt += ms;
    const q = rafQ; rafQ = [];
    for (const cb of q) cb(performance.now());
  };
  window.__squishNow = () => vt;

  // SquishyToy's per-toy state `s`: buildModelCreature's Object.assign(s, cardState(...)) hands it over
  const oa = Object.assign;
  Object.assign = function (t, ...src) {
    if (src.length === 1 && src[0] && src[0].card === true && 'sqSt' in src[0]) window.__toy = t;
    return oa.call(Object, t, ...src);
  };

  window.__squishMount = async ({ url, id, stage, bg = '#c8dcf0', size = 384, dpr = 2.8125 }) => {
    const React = mod(/^node_modules\/react\/index\.js$/);
    const THREE = mod(/^node_modules\/three\/build\/three\.module\.js$/);
    const R3F = mod(/^node_modules\/@react-three\/fiber\/dist\/react-three-fiber\.esm\.js$/);
    const SquishyToy = mod(/^src\/components\/SquishyToy\.js$/).default;
    const Supersample = mod(/^src\/components\/Supersample\.js$/).default;
    installClock();
    // (what <Canvas> does before its root: the three namespace as JSX elements)
    R3F.extend(THREE);
    const box = document.createElement('div');
    box.style.cssText = `position:fixed;left:0;top:0;width:${size}px;height:${size}px;background:${bg};z-index:99999`;
    const canvas = document.createElement('canvas');
    canvas.style.cssText = `width:${size}px;height:${size}px;display:block`;
    box.appendChild(canvas);
    document.body.appendChild(box);
    const root = R3F.createRoot(canvas);
    root.configure({
      size: { width: size, height: size, top: 0, left: 0 },
      dpr,
      frameloop: 'always',
      camera: { fov: 30, position: [0, 0.1, 4.6], near: 0.1, far: 100 },
      gl: { toneMapping: THREE.NeutralToneMapping, toneMappingExposure: 1, preserveDrawingBuffer: true },
      events: undefined,
    });
    const ref = React.createRef();
    const h = React.createElement;
    root.render(
      h(React.Fragment, null,
        h('ambientLight', { intensity: 0.6 }),
        h('hemisphereLight', { args: [0xffffff, 0x9aa8bc, 3.5] }),
        h('directionalLight', { color: 0xffffff, intensity: 1.2, position: [2, 3, 3] }),
        h('directionalLight', { color: 0xd8ccff, intensity: 0.3, position: [-2.5, -1, 2] }),
        h('directionalLight', { color: 0xffffff, intensity: 0.35, position: [-1.5, 2, -3] }),
        h(Supersample, { factor: 2, adaptive: false }),
        h(SquishyToy, { ref, creatureId: String(id), cardUrl: url, stage, onSquish: () => {}, onRelease: () => {}, dentScale: 1, dentOutward: false }),
      ),
    );
    window.__squishHandle = ref;
    window.__squishRoot = root;
    window.__squishGl = R3F._roots.get(canvas).store.getState().gl;
    window.__squishThree = THREE;
    // wait (real time) for the atlas and the build
    for (let i = 0; i < 400 && !(window.__toy && ref.current); i++) await new Promise((r) => setTimeout(r, 25));
    if (!window.__toy) throw new Error('the toy never built');
    return true;
  };

  // the state a test compares: SquishyToy's s, the group's transform, the shader's uniforms as uploaded
  window.__squishState = () => {
    const s = window.__toy;
    const g = s.group;
    g.updateMatrixWorld(true);
    let u = null;
    try {
      const gl = window.__squishGl;
      const props = gl && gl.properties.get(s.bodyMat);
      const un = props && props.uniforms;
      if (un && un.uSquishPress) u = { press: Array.from(un.uSquishPress.value), count: un.uSquishCount.value, dir: un.uSquishDir.value.toArray(), dent: un.uSquishDent.value.toArray() };
    } catch (e) { u = { error: String(e) }; }
    return {
      now: vt,
      presses: s.presses.map((p) => ({ ...p })),
      lift: s.lift, atRest: s.atRest, mode: s.mode, dentTargetActive: s.dentTargetActive,
      pressHoldTime: s.pressHoldTime, pressLocalSmoothed: s.pressLocalSmoothed ? s.pressLocalSmoothed.toArray() : null,
      pressDir: s.pressDir.toArray(),
      globalSquash: s.globalSquash, globalSquashV: s.globalSquashV, globalSquashTarget: s.globalSquashTarget,
      wobbleRotX: s.wobbleRotX, wobbleRotXV: s.wobbleRotXV, wobbleRotZ: s.wobbleRotZ, wobbleRotZV: s.wobbleRotZV,
      userRotX: s.userRotX, userRotY: s.userRotY, orbitTargetX: s.orbitTargetX, orbitTargetY: s.orbitTargetY, orbitVelX: s.orbitVelX, orbitVelY: s.orbitVelY,
      idlePhase: s.idlePhase, mv: { ...s.mv }, reactT: s.reactT,
      pos: g.position.toArray(), rot: [g.rotation.x, g.rotation.y, g.rotation.z], scale: g.scale.toArray(),
      matrix: g.matrixWorld.elements.slice(),
      uniforms: u,
    };
  };
})();
