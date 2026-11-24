// The creature rig, compiled to C#: the app's own rig code (rive-rig.js, rive-generic.js, the defs and move files, as
// parity.mjs loads them) and the browser stand-in it runs on (dom-shim.js, virtual-clock.js, live-host.js), turned into
// plain C# ahead of time, so Unity animates every creature natively (Creatures/NativeRig.cs): no JS engine, no
// recordings, the same frames as the app.
//
// Why compiled and not rewritten by hand: the rig is ~2 MB of dense JS (rive-generic.js alone draws a hundred
// creatures, each its own special cases) and it changes with every design drop. A hand port would take months and
// drift; this is the same code, so it draws the same thing, and re-running this after a drop keeps Unity in step.
//
// Each script becomes one static class with Run() (unity/Assets/Scripts/Creatures/Js/Gen/<name>.cs). The JS values
// live in Creatures/Js (JsValue.cs: V, a struct; JsObject.cs; Rt.cs: the operators and the built-ins, as the
// language defines them: number formatting, property order, stable sort, regexes...). What the compiler does:
//   - every binding a C# local (closures are C# lambdas, which capture the same way), `let` in a loop a fresh one per
//     turn when a closure keeps it; var / function declarations hoisted; the top level the global object's
//   - functions take (this, argc, a0..a3, rest): no array for a call of up to four arguments
//   - numbers stay doubles and strings C# strings where the expression's type is plain (arithmetic, literals,
//     concatenation), V otherwise; a let / const that only ever holds numbers is a C# double; Math.* (fdlibm, as V8)
//     and a few built-ins called directly; the stand-in's markup writer done natively (Creatures/Js/Dom.cs)
//
//   node tools/unity/rig/jsc.mjs            (after node webgame/build.mjs; writes Creatures/Js/Gen)
//   node tools/unity/rig/jsc.mjs --test     (also the test scenarios, tools/unity/rig-test/scenarios.js, for rig-test)
import fs from 'node:fs';
import path from 'node:path';
import { createRequire } from 'node:module';
import { fileURLToPath } from 'node:url';

const require = createRequire(import.meta.url);
const { parse } = require('@babel/parser');
const traverse = require('@babel/traverse').default;

const HERE = path.dirname(fileURLToPath(import.meta.url));
const REPO = path.resolve(HERE, '../../..');
const WORK = path.join(REPO, 'webgame/test/out/unity-webgame');
const OUT = path.join(REPO, 'unity/Assets/Scripts/Creatures/Js/Gen');
const RIG = eval(fs.readFileSync(path.join(HERE, 'parity.mjs'), 'utf8').match(/export const RIG_SCRIPTS = (\[[\s\S]*?\]);/)[1]);

export const YARD_SCRIPTS = ['yard-games.js', 'yg-intros.js', 'yg-hoop.js', 'yg-soccer.js', 'yg-hop.js', 'yg-tramp.js', 'yg-slide.js', 'yg-corn.js', 'yg-pong.js'];

// ---------------------------------------------------------------------------------------------------------------
// the scripts, in the order the host runs them
export function scriptList(test) {
  const list = [
    ['dom-shim.js', path.join(HERE, 'dom-shim.js')],
    ['live-host.js', path.join(HERE, 'live-host.js')],
    ['virtual-clock.js', path.join(HERE, 'virtual-clock.js')],
    ...RIG.map((s) => [s, path.join(WORK, s)]),
    // the creatures' border looks (the menu loads them before the rig: Main Menu.dc.html)
    ['app/look-lines.js', path.join(WORK, 'app/look-lines.js')],
    ['app/rig-look.js', path.join(WORK, 'app/rig-look.js')],
    ['result-states.js', null],   // tools/rig/result.html addStates (below)
    ['native-host.js', path.join(HERE, 'native-host.js')],
    // the yard games (Games/Yard/YardJs.cs): the bridge first (it hands the saved bests over before yard-games.js
    // reads them), then the page's scripts in the menu page's order (Main Menu.dc.html: yard-games.js, yg-intros.js,
    // the games)
    ['yard-host.js', path.join(HERE, 'yard-host.js')],
    ...YARD_SCRIPTS.map((s) => [s, path.join(WORK, s)]),
  ];
  if (test) list.push(['scenarios.js', path.join(REPO, 'tools/unity/rig-test/scenarios.js')]);
  return list;
}

// tools/rig/result.html's addStates, as record.mjs --clip result takes it from the page: the result card's states
export function resultStates() {
  const page = fs.readFileSync(path.join(REPO, 'tools/rig/result.html'), 'utf8');
  const helpers = page.match(/const AR = K => \(\{ armL: K, armR: K \}\), ER = K => \(\{ earL: K, earR: K \}\);/)[0];
  const body = page.match(/function addStates\(\) \{\n([\s\S]*?)\n  \}\n/)[1];
  return `// tools/rig/result.html addStates (taken from the page by tools/unity/rig/jsc.mjs): the result card's states\n`
    + `(function () { if (window.__resStates) return; window.__resStates = true;\n${helpers}\n${body}\n})();\n`;
}

// ---------------------------------------------------------------------------------------------------------------
const CS_KEYWORDS = new Set('abstract as base bool break byte case catch char checked class const continue decimal default delegate do double else enum event explicit extern false finally fixed float for foreach goto if implicit in int interface internal is lock long namespace new null object operator out override params private protected public readonly ref return sbyte sealed short sizeof stackalloc static string struct switch this throw true try typeof uint ulong unchecked unsafe ushort using virtual void volatile while var dynamic value yield async await'.split(' '));

const csStr = (s) => '"' + Array.from(String(s)).map((ch) => {
  const c = ch.codePointAt(0);
  if (ch === '"') return '\\"';
  if (ch === '\\') return '\\\\';
  if (c >= 0x20 && c < 0x7f) return ch;
  if (c === 10) return '\\n';
  if (c === 13) return '\\r';
  if (c === 9) return '\\t';
  if (c > 0xffff) { const s2 = ch; return '\\u' + s2.charCodeAt(0).toString(16).padStart(4, '0') + '\\u' + s2.charCodeAt(1).toString(16).padStart(4, '0'); }
  return '\\u' + c.toString(16).padStart(4, '0');
}).join('') + '"';

function csNum(v) {
  if (Number.isNaN(v)) return 'double.NaN';
  if (v === Infinity) return 'double.PositiveInfinity';
  let s = String(v);
  if (/^-?\d+$/.test(s)) return s + 'D';
  if (/e/.test(s) && !/\./.test(s)) return s.replace('e', '.0e').replace('e+', 'e');
  return s.replace('e+', 'e');
}

class Compiler {
  constructor(name, src) {
    this.name = name; this.src = src;
    this.names = new Map();   // babel Binding -> C# name
    this.uid = 0;
    this.fnStack = [];        // { self, argc, arrow, strict }
    this.loops = [];          // { kind, cont: label or null, used }
    this.regexes = [];
    this.strict = false;
  }
  tmp(p = 't') { return '_' + p + (++this.uid); }
  nameOf(binding) {
    let n = this.names.get(binding);
    if (!n) {
      const base = binding.identifier.name.replace(/\$/g, '_S');
      n = (CS_KEYWORDS.has(base) ? '@' + base : base) + '_' + (++this.uid);
      this.names.set(binding, n);
    }
    return n;
  }
  err(path, msg) { const l = path.node.loc ? path.node.loc.start : { line: '?', column: '?' }; return new Error(`${this.name}:${l.line}:${l.column}: ${msg}`); }

  compile() {
    const ast = parse(this.src, { sourceType: 'script', allowReturnOutsideFunction: false });
    let prog;
    traverse(ast, { Program(p) { prog = p; p.stop(); } });
    this.prog = prog;
    this.sbufs = this.inferStrBufs(prog);
    this.typed = process.env.JSC_UNTYPED && (process.env.JSC_UNTYPED === '*' || process.env.JSC_UNTYPED.split(',').includes(this.name)) ? new Set() : this.inferNumbers(prog);
    this.strict = (prog.node.directives || []).some((d) => d.value.value === 'use strict');
    const body = [];
    // the top level: var / function declarations are the global object's (they are in a browser too)
    for (const [n, b] of Object.entries(prog.scope.bindings)) {
      if (b.kind === 'var' || b.kind === 'hoisted') body.push(`GDecl(${csStr(n)});`);
    }
    this.fnStack.push({ self: 'V.Undef', top: true, strict: this.strict });
    for (const s of prog.get('body')) if (s.isFunctionDeclaration()) body.push(this.funcDecl(s));
    for (const s of prog.get('body')) if (!s.isFunctionDeclaration()) body.push(this.stmt(s));
    this.fnStack.pop();
    const cls = 'S_' + this.name.replace(/[^A-Za-z0-9]/g, '_');
    const re = this.regexes.map((r, i) => `        static readonly System.Text.RegularExpressions.Regex RX${i} = JsRegExp.Compile(${csStr(r.src)}, ${csStr(r.flags)});`).join('\n');
    return { cls, code: `// ${this.name}, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class ${cls}
    {
${re}
        public static void Run()
        {
${body.join('\n')}
        }
    }
}
` };
  }

  // ------------------------------------------------------------------ bindings
  // the C# declarations of the bindings a scope owns (at its top: closures may use them before their line)
  declsOf(scope, skip) {
    const out = [];
    for (const [n, b] of Object.entries(scope.bindings)) {
      if (b.kind === 'param' || (skip && skip.has(b))) continue;
      if (scope.path.isProgram()) continue;
      if (b.kind === 'local' && b.path.isFunctionExpression()) continue;   // a named function expression: its own
      out.push(this.typed.has(b) ? `double ${this.nameOf(b)} = 0;` : this.sbufs.has(b) ? `JsStrBuf ${this.nameOf(b)} = null;` : `V ${this.nameOf(b)} = default;`);
    }
    return out;
  }
  hoistedFns(stmts) { return stmts.filter((s) => s.isFunctionDeclaration()).map((s) => this.funcDecl(s)); }
  funcDecl(s) {
    const b = s.scope.parent.getBinding(s.node.id.name) || s.parentPath.scope.getBinding(s.node.id.name);
    const nat = (NATIVE[this.name] || {})[s.node.id.name];
    const fn = nat ? `Fn(${nat}, ${s.node.params.length}, ${csStr(s.node.id.name)}, false)` : this.func(s, s.node.id.name);
    if (!b || b.scope.path.isProgram()) return `GSet(${csStr(s.node.id.name)}, ${fn});`;
    return `${this.nameOf(b)} = ${fn};`;
  }
  ref(path, name) {
    const b = path.scope.getBinding(name);
    if (!b || b.scope.path.isProgram()) return null;
    if (b.kind === 'local' && b.path.isFunctionExpression()) return { named: b, code: this.namedRef(b) };
    return { code: this.nameOf(b), b, num: this.typed.has(b), sb: this.sbufs.has(b) };
  }

  // ------------------------------------------------------------------ strings built up in place
  // a `let` that starts as a string and is only ever added to (`s += ...`) or set to a string: a JsStrBuf (the parts
  // written into one buffer, the string made when it's read), not a new string at every +=
  inferStrBufs(prog) {
    const out = new Set();
    const isStr = (p) => {
      const n = p.node;
      if (n.type === 'StringLiteral' || n.type === 'TemplateLiteral') return true;
      if (n.type === 'BinaryExpression' && n.operator === '+') return isStr(p.get('left')) || isStr(p.get('right'));
      if (n.type === 'ConditionalExpression') return isStr(p.get('consequent')) && isStr(p.get('alternate'));
      return false;
    };
    prog.traverse({
      VariableDeclarator: (d) => {
        const decl = d.parentPath;
        if (decl.node.kind !== 'let' || !d.get('id').isIdentifier() || !d.node.init || !isStr(d.get('init'))) return;
        if (!decl.parentPath.isBlockStatement() && !decl.parentPath.isProgram()) return;   // (not a for head)
        const b = d.scope.getBinding(d.node.id.name);
        if (!b || b.scope.path.isProgram() || b.path !== d) return;
        if (!b.constantViolations.length) return;
        if (!b.constantViolations.every((v) => v.isAssignmentExpression() && v.get('left').isIdentifier() && (v.node.operator === '+=' || (v.node.operator === '=' && isStr(v.get('right')))))) return;
        out.add(b);
      },
    });
    return out;
  }

  // ------------------------------------------------------------------ numbers in doubles
  // `let` / `const` bindings that only ever hold numbers (every value they get is an arithmetic result, a numeric
  // literal, a Math call or another such binding) are C# doubles: no conversions, no V in between. Found by a
  // fixpoint: assume all candidates, drop the ones a value can't be shown numeric for, until nothing changes.
  inferNumbers(prog) {
    const cand = new Set();
    prog.traverse({
      VariableDeclarator: (d) => {
        const decl = d.parentPath;
        if (decl.node.kind === 'var' || !d.get('id').isIdentifier() || !d.node.init) return;
        if (decl.parentPath.isForInStatement() || decl.parentPath.isForOfStatement()) return;
        const b = d.scope.getBinding(d.node.id.name);
        if (!b || b.scope.path.isProgram() || b.path !== d) return;
        if (b.constantViolations.some((v) => !(v.isUpdateExpression() || (v.isAssignmentExpression() && v.get('left').isIdentifier())))) return;
        // a for-loop `let` a closure keeps (a fresh copy each turn: forStmt) stays a V
        if (decl.parentPath.isForStatement() && decl.parentPath.node.init === decl.node) {
          const fnp = decl.parentPath.getFunctionParent();
          if (b.referencePaths.concat(b.constantViolations).some((r) => r.getFunctionParent() !== fnp)) return;
        }
        cand.add(b);
      },
    });
    const isNum = (p) => {
      const n = p.node;
      switch (n.type) {
        case 'NumericLiteral': return true;
        case 'ParenthesizedExpression': return isNum(p.get('expression'));
        case 'UnaryExpression': return n.operator === '-' || n.operator === '+' || n.operator === '~';
        case 'UpdateExpression': return true;
        case 'BinaryExpression':
          if (n.operator === '+') return isNum(p.get('left')) && isNum(p.get('right'));
          return ['-', '*', '/', '%', '**', '|', '&', '^', '<<', '>>', '>>>'].includes(n.operator);
        case 'ConditionalExpression': return isNum(p.get('consequent')) && isNum(p.get('alternate'));
        case 'SequenceExpression': { const e = p.get('expressions'); return isNum(e[e.length - 1]); }
        case 'AssignmentExpression':
          if (n.operator === '=') return isNum(p.get('right'));
          if (n.operator === '+=') return isNum(p.get('left')) && isNum(p.get('right'));
          return !['&&=', '||=', '??='].includes(n.operator);
        case 'Identifier': {
          if (n.name === 'NaN' || n.name === 'Infinity') return !p.scope.getBinding(n.name);
          const b = p.scope.getBinding(n.name);
          return !!b && cand.has(b);
        }
        case 'CallExpression': {
          const c = p.get('callee');
          if (c.isMemberExpression() && !c.node.computed && this.isGlobal(c.get('object'), 'Math') && MATH[c.node.property.name] && !p.node.arguments.some((a) => a.type === 'SpreadElement')) return true;
          if (c.isIdentifier() && !c.scope.getBinding(c.node.name) && ['parseFloat', 'parseInt', 'Number'].includes(c.node.name)) return true;
          return false;
        }
        case 'MemberExpression': return this.isGlobal(p.get('object'), 'Math') && !n.computed && ['PI', 'E', 'SQRT2', 'LN2', 'LN10', 'LOG2E', 'LOG10E', 'SQRT1_2'].includes(n.property.name);
        default: return false;
      }
    };
    for (let changed = true; changed;) {
      changed = false;
      for (const b of [...cand]) {
        const ok = isNum(b.path.get('init')) && b.constantViolations.every((v) => v.isUpdateExpression() || (v.node.operator === '+=' ? isNum(v.get('right')) : v.node.operator === '=' ? isNum(v.get('right')) : true));
        if (!ok) { cand.delete(b); changed = true; }
      }
    }
    return cand;
  }
  namedRef(b) { return this.nameOf(b) + '.v'; }

  // ------------------------------------------------------------------ statements
  block(stmts, scopeOwner) {
    const out = [];
    if (scopeOwner) out.push(...this.declsOf(scopeOwner.scope));
    out.push(...this.hoistedFns(stmts));
    for (const s of stmts) if (!s.isFunctionDeclaration()) out.push(this.stmt(s));
    return out.join('\n');
  }
  stmt(p) {
    const n = p.node;
    switch (n.type) {
      case 'ExpressionStatement': return this.exprStmt(p.get('expression'));
      case 'VariableDeclaration': return this.varDecl(p);
      case 'FunctionDeclaration': return '';
      case 'ReturnStatement': {
        if (this.fnStack[this.fnStack.length - 1].top) throw this.err(p, 'return at the top level');
        return n.argument ? `return ${this.v(p.get('argument'))};` : 'return default;';
      }
      case 'IfStatement': {
        let s = `if (${this.b(p.get('test'))}) {\n${this.stmtIn(p.get('consequent'))}\n}`;
        if (n.alternate) s += ` else {\n${this.stmtIn(p.get('alternate'))}\n}`;
        return s;
      }
      case 'BlockStatement': return `{\n${this.block(p.get('body'), p.scope.path === p ? p : null)}\n}`;
      case 'EmptyStatement': return ';';
      case 'ForStatement': return this.forStmt(p);
      case 'WhileStatement': {
        this.loops.push({ kind: 'while' });
        const s = `while (${this.b(p.get('test'))}) {\n${this.stmtIn(p.get('body'))}\n}`;
        this.loops.pop();
        return s;
      }
      case 'DoWhileStatement': {
        this.loops.push({ kind: 'do' });
        const s = `do {\n${this.stmtIn(p.get('body'))}\n} while (${this.b(p.get('test'))});`;
        this.loops.pop();
        return s;
      }
      case 'ForInStatement': case 'ForOfStatement': return this.forInOf(p);
      case 'BreakStatement': if (n.label) throw this.err(p, 'labels'); return 'break;';
      case 'ContinueStatement': {
        if (n.label) throw this.err(p, 'labels');
        const l = this.loops[this.loops.length - 1];
        if (l && l.cont) { l.used = true; return `goto ${l.cont};`; }
        return 'continue;';
      }
      case 'ThrowStatement': return `throw Throw(${this.v(p.get('argument'))});`;
      case 'TryStatement': {
        let s = `try {\n${this.stmtIn(p.get('block'))}\n}`;
        if (n.handler) {
          const h = p.get('handler'), ex = this.tmp('ex');
          let pre = '';
          if (n.handler.param) {
            const decls = this.declsOf(h.scope);
            pre = decls.join('\n') + '\n' + this.assignPattern(h.get('param'), `Caught(${ex})`, h) + '\n';
          }
          s += ` catch (System.Exception ${ex}) {\n${pre}${this.stmtIn(h.get('body'))}\n}`;
        }
        if (n.finalizer) s += ` finally {\n${this.stmtIn(p.get('finalizer'))}\n}`;
        return s;
      }
      case 'SwitchStatement': return this.switchStmt(p);
      case 'ClassDeclaration': {
        const b = p.scope.getBinding(n.id.name);
        const cls = this.classExpr(p);
        if (!b || b.scope.path.isProgram()) return `GSet(${csStr(n.id.name)}, ${cls});`;
        return `${this.nameOf(b)} = ${cls};`;
      }
      default: throw this.err(p, 'statement ' + n.type);
    }
  }
  // a statement as a loop's or an if's body (a block: its own braces are ours)
  stmtIn(p) {
    if (p.isBlockStatement()) return this.block(p.get('body'), p.scope.path === p ? p : null);
    return this.stmt(p);
  }
  exprStmt(p) {
    const n = p.node;
    if (n.type === 'SequenceExpression') return p.get('expressions').map((e) => this.exprStmt(e)).join('\n');
    if (n.type === 'LogicalExpression' && (n.operator === '&&' || n.operator === '||')) {
      const t = this.b(p.get('left'));
      return `if (${n.operator === '&&' ? t : '!(' + t + ')'}) {\n${this.exprStmt(p.get('right'))}\n}`;
    }
    if (n.type === 'ConditionalExpression') return `if (${this.b(p.get('test'))}) {\n${this.exprStmt(p.get('consequent'))}\n} else {\n${this.exprStmt(p.get('alternate'))}\n}`;
    if (n.type === 'UnaryExpression' && n.operator === 'void') return this.exprStmt(p.get('argument'));
    if (n.type === 'AssignmentExpression' && n.operator === '=' && n.left.type !== 'Identifier' && n.left.type !== 'MemberExpression') {
      // a destructuring assignment
      const t = this.tmp();
      return `{ V ${t} = ${this.v(p.get('right'))};\n${this.assignPattern(p.get('left'), t, p)} }`;
    }
    const e = this.expr(p);
    if (e.stmtCode) return e.stmtCode + ';';
    if (e.stmt) return e.code + ';';
    return `_ = ${e.code};`;
  }
  varDecl(p) {
    const out = [];
    for (const d of p.get('declarations')) {
      const id = d.get('id');
      if (!d.node.init) {
        // `var x;` keeps its value; `let x;` is undefined (each pass through a loop body too)
        if (p.node.kind !== 'var' && id.isIdentifier()) { const r = this.ref(d, id.node.name); out.push(r ? `${r.code} = V.Undef;` : `GSet(${csStr(id.node.name)}, V.Undef);`); }
        continue;
      }
      if (id.isIdentifier()) {
        const r = this.ref(d, id.node.name);
        const val = r && r.num ? this.n(d.get('init')) : r && r.sb ? `new JsStrBuf(${this.s(d.get('init'))})` : this.v(d.get('init'));
        out.push(r ? `${r.code} = ${val};` : `GSet(${csStr(id.node.name)}, ${val});`);
      } else {
        const t = this.tmp();
        out.push(`{ V ${t} = ${this.v(d.get('init'))};\n${this.assignPattern(id, t, d)} }`);
      }
    }
    return out.join('\n');
  }
  // assigns `src` (a C# V expression, evaluated once: a variable) to a target: an identifier, a member, a pattern
  assignPattern(p, src, ctx) {
    const n = p.node;
    if (n.type === 'Identifier') {
      const r = this.ref(p, n.name);
      return r ? `${r.code} = ${r.num ? `ToNum(${src})` : src};` : `GSet(${csStr(n.name)}, ${src});`;
    }
    if (n.type === 'MemberExpression') return this.setMember(p, src) + ';';
    if (n.type === 'AssignmentPattern') {
      const t = this.tmp();
      return `{ V ${t} = ${src}; if (${t}.IsUndef) ${t} = ${this.v(p.get('right'))};\n${this.assignPattern(p.get('left'), t, ctx)} }`;
    }
    if (n.type === 'ArrayPattern') {
      const t = this.tmp(), out = [`{ V ${t} = ListOf(${src});`];
      p.get('elements').forEach((e, i) => {
        if (!e.node) return;
        if (e.isRestElement()) out.push(this.assignPattern(e.get('argument'), `RestFrom(${t}, ${i})`, ctx));
        else { const ti = this.tmp(); out.push(`{ V ${ti} = GetIdx(${t}, ${i}D);\n${this.assignPattern(e, ti, ctx)} }`); }
      });
      out.push('}');
      return out.join('\n');
    }
    if (n.type === 'ObjectPattern') {
      const out = [`if (${src}.IsNullish) throw TypeErr("Cannot destructure " + ToStr(${src}));`], keys = [];
      for (const pr of p.get('properties')) {
        if (pr.isRestElement()) { out.push(this.assignPattern(pr.get('argument'), `ObjRest(${src}, new string[] { ${keys.map(csStr).join(', ')} })`, ctx)); continue; }
        let key;
        if (pr.node.computed) key = `GetK(${src}, ${this.v(pr.get('key'))})`;
        else { const k = pr.node.key.type === 'Identifier' ? pr.node.key.name : String(pr.node.key.value); keys.push(k); key = `Get(${src}, ${csStr(k)})`; }
        const ti = this.tmp();
        out.push(`{ V ${ti} = ${key};\n${this.assignPattern(pr.get('value'), ti, ctx)} }`);
      }
      return out.join('\n');
    }
    throw this.err(p, 'pattern ' + n.type);
  }

  forStmt(p) {
    const n = p.node, out = ['{'];
    if (p.scope.path === p) out.push(...this.declsOf(p.scope));
    if (n.init) out.push(n.init.type === 'VariableDeclaration' ? this.varDecl(p.get('init')) : this.exprStmt(p.get('init')));
    // `let` bindings a closure in the loop keeps: a fresh one per turn (the JS semantics), carried over to the next
    const perIter = [];
    if (n.init && n.init.type === 'VariableDeclaration' && n.init.kind !== 'var') {
      for (const [name, b] of Object.entries(p.scope.bindings)) {
        const fnp = p.getFunctionParent();
        if (b.referencePaths.concat(b.constantViolations).some((r) => r.getFunctionParent() !== fnp)) perIter.push(b);
      }
    }
    const loop = { kind: 'for', cont: this.tmp('cont'), used: false };
    this.loops.push(loop);
    let saved = [];
    if (perIter.length) {
      // inside the loop the binding is the turn's own copy
      saved = perIter.map((b) => [b, this.names.get(b)]);
    }
    const inner = [];
    const copies = perIter.map((b) => { const outer = this.nameOf(b), own = outer + '_it'; return { b, outer, own }; });
    for (const c of copies) { inner.push(`V ${c.own} = ${c.outer};`); this.names.set(c.b, c.own); }
    if (n.test) inner.push(`if (!(${this.b(p.get('test'))})) break;`);
    inner.push(this.stmtIn(p.get('body')));
    this.loops.pop();
    if (loop.used) inner.push(`${loop.cont}: ;`);
    for (const c of copies) { this.names.set(c.b, c.outer); inner.push(`${c.outer} = ${c.own};`); }
    if (n.update) inner.push(this.exprStmt(p.get('update')));
    out.push(`while (true) {\n${inner.join('\n')}\n}`);
    out.push('}');
    return out.join('\n');
  }
  forInOf(p) {
    const n = p.node, it = this.tmp('k'), out = ['{'];
    const left = p.get('left');
    const decl = left.isVariableDeclaration() ? left : null;
    const target = decl ? decl.get('declarations')[0].get('id') : left;
    // bindings of a `let` / `const` head: declared in the body (a fresh one each turn)
    const own = decl && decl.node.kind !== 'var' && p.scope.path === p ? Object.values(p.scope.bindings) : [];
    const src = n.type === 'ForInStatement' ? `ForInKeys(${this.v(p.get('right'))})` : `new JsIter(${this.v(p.get('right'))})`;
    this.loops.push({ kind: 'foreach' });
    const body = [...own.map((b) => `V ${this.nameOf(b)} = default;`), this.assignPattern(target, it, p), this.stmtIn(p.get('body'))];
    this.loops.pop();
    out.push(`foreach (V ${it} in ${src}) {\n${body.join('\n')}\n}`);
    out.push('}');
    return out.join('\n');
  }
  switchStmt(p) {
    const n = p.node, d = this.tmp('sw'), c = this.tmp('c'), out = ['{'];
    if (p.scope.path === p) out.push(...this.declsOf(p.scope));
    out.push(`V ${d} = ${this.v(p.get('discriminant'))}; int ${c} = -1;`);
    const cases = p.get('cases');
    let def = -1;
    const tests = [];
    cases.forEach((cs, i) => { if (!cs.node.test) def = i; else tests.push(`${tests.length ? 'else ' : ''}if (SEq(${d}, ${this.v(cs.get('test'))})) ${c} = ${i};`); });
    out.push(...tests);
    if (def >= 0) out.push(`if (${c} < 0) ${c} = ${def};`);
    const secs = cases.map((cs, i) => `case ${i}: {\n${this.hoistedFns(cs.get('consequent')).join('\n')}\n${cs.get('consequent').filter((s) => !s.isFunctionDeclaration()).map((s) => this.stmt(s)).join('\n')}\n}\n${i + 1 < cases.length ? `goto case ${i + 1};` : 'break;'}`);
    out.push(`switch (${c}) {\n${secs.join('\n')}\n}`);
    out.push('}');
    return out.join('\n');
  }

  // ------------------------------------------------------------------ functions
  func(p, name) {
    const n = p.node, arrow = n.type === 'ArrowFunctionExpression';
    const parent = this.fnStack[this.fnStack.length - 1];
    const strict = this.strict || parent.strict || (n.body.directives || []).some((d) => d.value.value === 'use strict');
    const self = arrow ? (parent.top ? 'GlobalV' : parent.self) : this.tmp('self');
    const argc = this.tmp('argc'), rest = this.tmp('rest');
    const fr = { self, argc, rest, arrow, strict, top: false, argsName: null, slots: [] };
    const slots = [0, 1, 2, 3].map(() => this.tmp('a'));
    fr.slots = slots;
    this.fnStack.push(fr);
    const savedLoops = this.loops; this.loops = [];
    const pro = [];
    if (!arrow && !strict) pro.push(`if (${self}.IsNullish) ${self} = GlobalV;`);
    // parameters: the four slots, then the rest array
    const params = p.get('params');
    const simpleNames = [];
    params.forEach((pp, i) => { if (pp.isIdentifier() && i < 4) simpleNames[i] = this.nameOf(p.scope.getBinding(pp.node.name)); });
    const slotNames = slots.map((s, i) => simpleNames[i] || s);
    params.forEach((pp, i) => {
      const src = i < 4 ? slots[i] : `(${argc} > ${i} ? ${rest}[${i - 4}] : V.Undef)`;
      if (pp.isIdentifier() && i < 4) return;
      if (pp.isRestElement()) { pro.push(this.assignPattern(pp.get('argument'), `RestArgs(${i}, ${argc}, ${slotNames.join(', ')}, ${rest})`, p)); return; }
      pro.push(this.assignPattern(pp, src, p));
    });
    // `arguments`
    let usesArgs = false;
    if (!arrow) p.traverse({ Function(q) { if (!q.isArrowFunctionExpression()) q.skip(); }, Identifier(q) { if (q.node.name === 'arguments' && !q.scope.getBinding('arguments') && q.isReferencedIdentifier()) usesArgs = true; } });
    if (usesArgs) { fr.argsName = this.tmp('arguments'); pro.push(`V ${fr.argsName} = Arguments(${argc}, ${slotNames.join(', ')}, ${rest});`); }
    // parameter bindings that aren't a slot of their own (patterns, defaults, past the fourth): locals
    const lam = new Set(simpleNames.filter(Boolean));
    const pdecl = Object.values(p.scope.bindings).filter((b) => b.kind === 'param' && !lam.has(this.nameOf(b))).map((b) => `V ${this.nameOf(b)} = default;`);
    pro.unshift(...pdecl);
    const sig = [self, argc, ...slots.map((s, i) => simpleNames[i] || s), rest];
    let body;
    if (n.body.type === 'BlockStatement') {
      const bp = p.get('body');
      const strs = bp.get('body');
      body = [...this.declsOf(p.scope), ...pro, this.block(strs, null), 'return default;'].join('\n');
    } else {
      body = [...this.declsOf(p.scope), ...pro, `return ${this.v(p.get('body'))};`].join('\n');
    }
    this.loops = savedLoops;
    this.fnStack.pop();
    const lamc = `(V ${sig[0]}, int ${sig[1]}, V ${sig[2]}, V ${sig[3]}, V ${sig[4]}, V ${sig[5]}, V[] ${sig[6]}) => {\n${body}\n}`;
    const nm = name || (n.id && n.id.name) || '';
    const mk = `Fn(${lamc}, ${n.params.length}, ${csStr(nm)}, ${arrow ? 'true' : 'false'})`;
    // a named function expression that names itself inside: a holder the body reads
    if (n.type === 'FunctionExpression' && n.id) {
      const b = p.scope.getBinding(n.id.name);
      if (b && b.kind === 'local' && b.path === p && b.referencePaths.length) {
        return `Named(${this.nameOf(b)} => ${mk})`;
      }
    }
    return mk;
  }
  paramDecls(pp, fnp) { return ''; }   // (parameter bindings are declared with the function's scope)
  classExpr(p) {
    const n = p.node;
    let ctor = null;
    const methods = [];
    for (const m of p.get('body').get('body')) {
      if (!m.isClassMethod()) throw this.err(m, 'class member ' + m.node.type);
      if (m.node.kind === 'constructor') ctor = m;
      else methods.push(m);
    }
    if (n.superClass) throw this.err(p, 'extends');
    const c = ctor ? this.func(ctor, n.id ? n.id.name : '') : `Fn((V s, int c, V a, V b, V d, V e, V[] r) => default, 0, ${csStr(n.id ? n.id.name : '')}, false)`;
    const ms = methods.map((m) => {
      const key = m.node.computed ? this.v(m.get('key')) : csStr(m.node.key.name);
      if (m.node.static) return `.Static(${key}, ${this.func(m, m.node.key.name)})`;
      return m.node.kind === 'get' ? `.ProtoGetter(${key}, ${this.func(m)})` : m.node.kind === 'set' ? `.ProtoSetter(${key}, ${this.func(m)})` : `.Method(${key}, ${this.func(m, m.node.key.name)})`;
    });
    return `ClassOf(${c})${ms.join('')}.V`;
  }

  // ------------------------------------------------------------------ expressions
  // e: { code, t: 'v' | 'n' | 's' | 'b', stmt?: true when the C# can stand as a statement }
  v(p) { return this.toV(this.expr(p)); }
  n(p) { return this.toN(this.expr(p)); }
  s(p) { return this.toS(this.expr(p)); }
  b(p) { return this.toB(this.expr(p)); }
  toV(e) { return e.t === 'v' ? e.code : e.t === 'n' ? `((V)(${e.code}))` : e.t === 's' ? `((V)(${e.code}))` : `(${e.code} ? V.True : V.False)`; }
  toN(e) { return e.t === 'n' ? e.code : e.t === 'v' ? `ToNum(${e.code})` : e.t === 's' ? `ToNum((V)(${e.code}))` : `(${e.code} ? 1D : 0D)`; }
  toS(e) { return e.t === 's' ? e.code : e.t === 'n' ? `NumStr(${e.code})` : e.t === 'v' ? `ToStr(${e.code})` : `(${e.code} ? "true" : "false")`; }
  toB(e) { return e.t === 'b' ? e.code : e.t === 'v' ? `Truthy(${e.code})` : e.t === 'n' ? `NumTruthy(${e.code})` : `((${e.code}).Length != 0)`; }

  expr(p) {
    const n = p.node;
    switch (n.type) {
      case 'NumericLiteral': return { code: csNum(n.value), t: 'n' };
      case 'StringLiteral': return { code: csStr(n.value), t: 's' };
      case 'BooleanLiteral': return { code: n.value ? 'true' : 'false', t: 'b' };
      case 'NullLiteral': return { code: 'V.Null', t: 'v' };
      case 'RegExpLiteral': {
        let i = this.regexes.findIndex((r) => r.src === n.pattern && r.flags === n.flags);
        if (i < 0) { i = this.regexes.length; this.regexes.push({ src: n.pattern, flags: n.flags }); }
        return { code: `NewRegExp(RX${i}, ${csStr(n.pattern)}, ${csStr(n.flags)})`, t: 'v' };
      }
      case 'TemplateLiteral': {
        const parts = [];
        n.quasis.forEach((q, i) => { if (q.value.cooked) parts.push(csStr(q.value.cooked)); if (i < n.expressions.length) parts.push(this.s(p.get('expressions')[i])); });
        return { code: parts.length ? `string.Concat(${parts.length === 1 ? parts[0] + ', ""' : parts.join(', ')})` : '""', t: 's' };
      }
      case 'Identifier': return this.ident(p);
      case 'ThisExpression': { const f = this.fnStack[this.fnStack.length - 1]; return { code: f.top ? 'GlobalV' : f.self, t: 'v' }; }
      case 'ArrayExpression': return this.arrayLit(p);
      case 'ObjectExpression': return this.objectLit(p);
      case 'FunctionExpression': case 'ArrowFunctionExpression': return { code: this.func(p), t: 'v' };
      case 'ClassExpression': return { code: this.classExpr(p), t: 'v' };
      case 'MemberExpression': return this.member(p);
      case 'CallExpression': return this.call(p);
      case 'NewExpression': {
        const args = this.args(p.get('arguments'));
        return { code: args.spread ? `NewSpread(${this.v(p.get('callee'))}, ${args.spread})` : `New(${[this.v(p.get('callee')), ...args.list].join(', ')})`, t: 'v', stmt: true };
      }
      case 'SequenceExpression': {
        const es = p.get('expressions').map((e) => this.v(e));
        return { code: es.reduce((a, b) => `Seq(${a}, ${b})`), t: 'v' };
      }
      case 'ConditionalExpression': {
        const a = this.expr(p.get('consequent')), b = this.expr(p.get('alternate'));
        const t = this.b(p.get('test'));
        if (a.t === b.t) return { code: `(${t} ? ${a.code} : ${b.code})`, t: a.t };
        return { code: `(${t} ? ${this.toV(a)} : ${this.toV(b)})`, t: 'v' };
      }
      case 'LogicalExpression': {
        const a = this.expr(p.get('left')), b = this.expr(p.get('right'));
        if (n.operator === '??') { const tt = this.tmp(); return { code: `(${this.toV(a)} is var ${tt} && !${tt}.IsNullish ? ${tt} : ${this.toV(b)})`, t: 'v' }; }
        if (a.t === 'b' && b.t === 'b') return { code: `(${a.code} ${n.operator} ${b.code})`, t: 'b' };
        const tt = this.tmp();
        if (n.operator === '||') return { code: `(${this.toV(a)} is var ${tt} && Truthy(${tt}) ? ${tt} : ${this.toV(b)})`, t: 'v' };
        return { code: `(${this.toV(a)} is var ${tt} && !Truthy(${tt}) ? ${tt} : ${this.toV(b)})`, t: 'v' };
      }
      case 'UnaryExpression': return this.unary(p);
      case 'BinaryExpression': return this.binary(p);
      case 'AssignmentExpression': return this.assign(p);
      case 'UpdateExpression': return this.update(p);
      case 'ParenthesizedExpression': return this.expr(p.get('expression'));
      default: throw this.err(p, 'expression ' + n.type);
    }
  }
  ident(p) {
    const name = p.node.name;
    const r = this.ref(p, name);
    if (r && r.sb) return { code: `${r.code}.Str`, t: 's' };
    if (r) return { code: r.code, t: r.num ? 'n' : 'v' };
    if (name === 'arguments') {
      const f = [...this.fnStack].reverse().find((f) => !f.arrow);
      if (f && f.argsName) return { code: f.argsName, t: 'v' };
    }
    if (name === 'undefined') return { code: 'V.Undef', t: 'v' };
    if (name === 'NaN') return { code: 'double.NaN', t: 'n' };
    if (name === 'Infinity') return { code: 'double.PositiveInfinity', t: 'n' };
    return { code: `G(${csStr(name)})`, t: 'v' };
  }
  isGlobal(p, name) { return p.isIdentifier({ name }) && !p.scope.getBinding(name); }
  arrayLit(p) {
    const els = p.get('elements');
    if (els.some((e) => e.node && e.isSpreadElement())) return { code: this.spreadArr(els), t: 'v' };
    if (els.some((e) => !e.node)) return { code: `ArrHoles(${els.map((e) => e.node ? this.v(e) : 'Hole').join(', ')})`, t: 'v' };
    return { code: els.length ? `Arr(${els.map((e) => this.v(e)).join(', ')})` : 'Arr()', t: 'v' };
  }
  spreadArr(els) {
    return `new ArrBuilder()${els.map((e) => !e.node ? '.Add(V.Undef)' : e.isSpreadElement() ? `.Spread(${this.v(e.get('argument'))})` : `.Add(${this.v(e)})`).join('')}.V`;
  }
  objectLit(p) {
    const parts = [];
    for (const pr of p.get('properties')) {
      const n = pr.node;
      if (pr.isSpreadElement()) { parts.push(`.Spread(${this.v(pr.get('argument'))})`); continue; }
      const key = n.computed ? null : n.key.type === 'Identifier' ? n.key.name : String(n.key.value);
      const kc = key != null ? csStr(key) : null;
      if (pr.isObjectMethod()) {
        const fn = this.func(pr, key || '');
        if (n.kind === 'get') parts.push(kc ? `.Getter(${kc}, ${fn})` : `.GetterK(${this.v(pr.get('key'))}, ${fn})`);
        else if (n.kind === 'set') parts.push(kc ? `.Setter(${kc}, ${fn})` : `.SetterK(${this.v(pr.get('key'))}, ${fn})`);
        else parts.push(kc ? `.Put(${kc}, ${fn})` : `.PutK(${this.v(pr.get('key'))}, ${fn})`);
        continue;
      }
      let val;
      const vp = pr.get('value');
      if ((vp.isFunctionExpression() || vp.isArrowFunctionExpression()) && !vp.node.id && key) val = this.func(vp, key);
      else val = this.v(vp);
      parts.push(kc ? `.Put(${kc}, ${val})` : `.PutK(${this.v(pr.get('key'))}, ${val})`);
    }
    return { code: `NewObj(${p.node.properties.length})${parts.join('')}.V`, t: 'v' };
  }
  propName(p) {
    // a member's key: a C# string literal when it's fixed, else null
    const n = p.node;
    if (!n.computed) return csStr(n.property.name);
    if (n.property.type === 'StringLiteral') return csStr(n.property.value);
    return null;
  }
  member(p) {
    const n = p.node, obj = p.get('object');
    // Math.PI and friends
    if (this.isGlobal(obj, 'Math') && !n.computed) {
      const c = { PI: 'System.Math.PI', E: 'System.Math.E', SQRT2: '1.4142135623730951D', LN2: '0.6931471805599453D', LN10: '2.302585092994046D', LOG2E: '1.4426950408889634D', LOG10E: '0.4342944819032518D', SQRT1_2: '0.7071067811865476D' }[n.property.name];
      if (c) return { code: c, t: 'n' };
    }
    const o = this.expr(obj);
    const k = this.propName(p);
    if (k === '"length"' && o.t === 's') return { code: `((double)(${o.code}).Length)`, t: 'n' };
    if (k) return { code: `Get(${this.toV(o)}, ${k})`, t: 'v' };
    const kp = p.get('property'), ke = this.expr(kp);
    if (ke.t === 'n') return { code: `GetIdx(${this.toV(o)}, ${ke.code})`, t: 'v' };
    return { code: `GetK(${this.toV(o)}, ${this.toV(ke)})`, t: 'v' };
  }
  args(list) {
    if (list.some((a) => a.isSpreadElement())) return { spread: this.spreadArr(list) };
    return { list: list.map((a) => this.v(a)) };
  }
  call(p) {
    const n = p.node, callee = p.get('callee');
    const argsP = p.get('arguments');
    // built-ins called directly (when not shadowed)
    if (callee.isMemberExpression() && !callee.node.computed && !argsP.some((a) => a.isSpreadElement())) {
      const ob = callee.get('object'), m = callee.node.property.name;
      if (this.isGlobal(ob, 'Math') && MATH[m]) {
        const r = MATH[m](argsP.map((a) => this.n(a)));
        if (r) return { code: r, t: 'n', stmt: true };
      }
      if (this.isGlobal(ob, 'Object') && ['keys', 'assign', 'entries', 'values', 'create', 'defineProperty', 'getPrototypeOf', 'freeze', 'getOwnPropertyNames', 'setPrototypeOf', 'fromEntries'].includes(m))
        return { code: `Object_${m}(${argsP.map((a) => this.v(a)).join(', ')})`, t: 'v', stmt: true };
      if (this.isGlobal(ob, 'Array') && (m === 'isArray' || m === 'from' || m === 'of')) {
        if (m === 'isArray') return { code: `(${this.v(argsP[0])}.O is JsArray)`, t: 'b', stmt: true };
        return { code: `Array_${m}(${argsP.map((a) => this.v(a)).join(', ')})`, t: 'v', stmt: true };
      }
      if (this.isGlobal(ob, 'String') && m === 'fromCharCode') return { code: `String_fromCharCode(${argsP.map((a) => this.v(a)).join(', ')})`, t: 's', stmt: true };
    }
    if (callee.isIdentifier() && !callee.scope.getBinding(callee.node.name) && !argsP.some((a) => a.isSpreadElement())) {
      const g = callee.node.name, A = argsP.map((a) => this.v(a));
      if (g === 'String' && A.length === 1) return { code: `ToStrS(${A[0]})`, t: 's', stmt: true };
      if (g === 'String' && A.length === 0) return { code: '""', t: 's' };
      if (g === 'Number' && A.length === 1) return { code: `ToNum(${A[0]})`, t: 'n', stmt: true };
      if (g === 'Boolean' && A.length === 1) return { code: `Truthy(${A[0]})`, t: 'b', stmt: true };
      if (g === 'parseFloat' && A.length === 1) return { code: `ParseFloat(${A[0]})`, t: 'n', stmt: true };
      if (g === 'parseInt') return { code: `ParseInt(${A[0]}, ${A[1] || 'V.Undef'})`, t: 'n', stmt: true };
      if (g === 'isFinite' && A.length === 1) return { code: `IsFiniteV(${A[0]})`, t: 'b', stmt: true };
      if (g === 'isNaN' && A.length === 1) return { code: `double.IsNaN(ToNum(${A[0]}))`, t: 'b', stmt: true };
    }
    const args = this.args(argsP);
    if (callee.isMemberExpression()) {
      const o = this.v(callee.get('object'));
      const k = this.propName(callee);
      if (args.spread) return { code: k ? `InvokeSpread(${o}, ${k}, ${args.spread})` : `InvokeSpreadK(${o}, ${this.v(callee.get('property'))}, ${args.spread})`, t: 'v', stmt: true };
      return { code: k ? `Invoke(${[o, k, ...args.list].join(', ')})` : `InvokeK(${[o, this.v(callee.get('property')), ...args.list].join(', ')})`, t: 'v', stmt: true };
    }
    const f = this.v(callee);
    if (args.spread) return { code: `CallSpread(${f}, V.Undef, ${args.spread})`, t: 'v', stmt: true };
    return { code: `Call(${[f, 'V.Undef', ...args.list].join(', ')})`, t: 'v', stmt: true };
  }
  unary(p) {
    const n = p.node, op = n.operator;
    if (op === 'typeof') {
      const a = p.get('argument');
      if (a.isIdentifier() && !this.ref(a, a.node.name) && !['undefined', 'NaN', 'Infinity', 'arguments'].includes(a.node.name)) return { code: `GTypeof(${csStr(a.node.name)})`, t: 's' };
      return { code: `Typeof(${this.v(a)})`, t: 's' };
    }
    if (op === 'delete') {
      const a = p.get('argument');
      if (!a.isMemberExpression()) return { code: 'true', t: 'b' };
      const k = this.propName(a);
      return { code: k ? `Delete(${this.v(a.get('object'))}, ${k})` : `DeleteK(${this.v(a.get('object'))}, ${this.v(a.get('property'))})`, t: 'b', stmt: true };
    }
    if (op === 'void') return { code: `Seq(${this.v(p.get('argument'))}, V.Undef)`, t: 'v' };
    if (op === '!') return { code: `!(${this.b(p.get('argument'))})`, t: 'b' };
    if (op === '-') { const a = p.get('argument'); if (a.isNumericLiteral()) return { code: '(-' + csNum(a.node.value) + ')', t: 'n' }; return { code: `(-${this.n(a)})`, t: 'n' }; }
    if (op === '+') return { code: this.n(p.get('argument')), t: 'n' };
    if (op === '~') return { code: `((double)(~ToInt32(${this.n(p.get('argument'))})))`, t: 'n' };
    throw this.err(p, 'unary ' + op);
  }
  binaryOp(op, a, b) {
    // a, b: { code, t }
    switch (op) {
      case '+': {
        if (a.t === 'n' && b.t === 'n') return { code: `(${a.code} + ${b.code})`, t: 'n' };
        if (a.t === 's' || b.t === 's') {
          // the chain's parts as they are (numbers too): strings only, four or fewer: string.Concat; else written into
          // a lent buffer (JsStrBuf.Begin ... End: one string made, none for the numbers)
          const parts = [];
          const flat = (e) => { if (e.cparts) parts.push(...e.cparts); else parts.push(e); };
          flat(a); flat(b);
          const code = parts.length <= 4 && parts.every((q) => q.t === 's') ? `string.Concat(${parts.map((q) => q.code).join(', ')})` : `JsStrBuf.Begin()${this.appendParts({ cparts: parts })}.End()`;
          return { code, t: 's', cparts: parts };
        }
        return { code: `Add(${this.toV(a)}, ${this.toV(b)})`, t: 'v' };
      }
      case '-': case '*': case '/': return { code: `(${this.toN(a)} ${op} ${this.toN(b)})`, t: 'n' };
      case '%': return { code: `(${this.toN(a)} % ${this.toN(b)})`, t: 'n' };
      case '**': return { code: `Pow(${this.toN(a)}, ${this.toN(b)})`, t: 'n' };
      case '|': case '&': case '^': return { code: `((double)(ToInt32(${this.toN(a)}) ${op} ToInt32(${this.toN(b)})))`, t: 'n' };
      case '<<': return { code: `((double)(ToInt32(${this.toN(a)}) << (int)(ToUint32(${this.toN(b)}) & 31)))`, t: 'n' };
      case '>>': return { code: `((double)(ToInt32(${this.toN(a)}) >> (int)(ToUint32(${this.toN(b)}) & 31)))`, t: 'n' };
      case '>>>': return { code: `((double)(ToUint32(${this.toN(a)}) >> (int)(ToUint32(${this.toN(b)}) & 31)))`, t: 'n' };
      case '===': case '!==': {
        const neg = op === '!==' ? '!' : '';
        if (a.t === 'n' && b.t === 'n') return { code: `(${a.code} ${op === '===' ? '==' : '!='} ${b.code})`, t: 'b' };
        if (a.t === 's' && b.t === 's') return { code: `${neg}string.Equals(${a.code}, ${b.code})`, t: 'b' };
        if (b.t === 's') return { code: `${neg}SEqS(${this.toV(a)}, ${b.code})`, t: 'b' };
        if (a.t === 's') return { code: `${neg}SEqS(${this.toV(b)}, ${a.code})`, t: 'b' };
        if (b.t === 'n') return { code: `${neg}SEqN(${this.toV(a)}, ${b.code})`, t: 'b' };
        if (a.t === 'n') return { code: `${neg}SEqN(${this.toV(b)}, ${a.code})`, t: 'b' };
        return { code: `${neg}SEq(${this.toV(a)}, ${this.toV(b)})`, t: 'b' };
      }
      case '==': case '!=': {
        const neg = op === '!=' ? '!' : '';
        if (a.t === 'n' && b.t === 'n') return { code: `(${a.code} ${op} ${b.code})`, t: 'b' };
        if (b.code === 'V.Null' || b.code === 'V.Undef') return { code: `${neg}${this.toV(a)}.IsNullish`, t: 'b' };
        if (a.code === 'V.Null' || a.code === 'V.Undef') return { code: `${neg}${this.toV(b)}.IsNullish`, t: 'b' };
        return { code: `${neg}LEq(${this.toV(a)}, ${this.toV(b)})`, t: 'b' };
      }
      case '<': case '>': case '<=': case '>=': {
        if (a.t === 'n' && b.t === 'n') return { code: `(${a.code} ${op} ${b.code})`, t: 'b' };
        const f = { '<': 'Lt', '>': 'Gt', '<=': 'Le', '>=': 'Ge' }[op];
        if (b.t === 'n') return { code: `${f}N(${this.toV(a)}, ${b.code})`, t: 'b' };
        return { code: `${f}(${this.toV(a)}, ${this.toV(b)})`, t: 'b' };
      }
      case 'instanceof': return { code: `InstanceOf(${this.toV(a)}, ${this.toV(b)})`, t: 'b' };
      case 'in': return { code: `HasProperty(${this.toV(b)}, ${this.toV(a)})`, t: 'b' };
    }
    throw new Error('binary ' + op);
  }
  // a JsStrBuf's appends for an expression (its concatenation's parts, or itself)
  appendParts(e) {
    const parts = e.cparts || [e];
    return parts.map((q) => q.t === 's' ? `.S(${q.code})` : q.t === 'n' ? `.N(${q.code})` : q.t === 'b' ? `.B(${q.code})` : `.V(${q.code})`).join('');
  }
  binary(p) {
    const n = p.node;
    return this.binaryOp(n.operator, this.expr(p.get('left')), this.expr(p.get('right')));
  }
  setMember(p, val) {
    const n = p.node, o = this.v(p.get('object')), k = this.propName(p);
    if (k) return `Set(${o}, ${k}, ${val})`;
    const ke = this.expr(p.get('property'));
    if (ke.t === 'n') return `SetIdx(${o}, ${ke.code}, ${val})`;
    return `SetK(${o}, ${this.toV(ke)}, ${val})`;
  }
  assign(p) {
    const n = p.node, left = p.get('left');
    if (n.operator === '=') {
      if (left.isIdentifier()) {
        const r = this.ref(left, left.node.name);
        // (as a value, in parentheses: C#'s = binds looser than JS's parenthesised assignment, `(s = x) / k`; as a
        // statement, bare: C# takes no parenthesised assignment there)
        if (r && r.num) { const c = `${r.code} = ${this.n(p.get('right'))}`; return { code: `(${c})`, stmtCode: c, t: 'n', stmt: true }; }
        if (r && r.sb) { const c = `${r.code}.Set(${this.s(p.get('right'))})`; return { code: `${c}.Str`, t: 's', stmtCode: c }; }
        const val = this.v(p.get('right'));
        if (r) { const c = `${r.code} = ${val}`; return { code: `(${c})`, stmtCode: c, t: 'v', stmt: true }; }
        return { code: `GSet(${csStr(left.node.name)}, ${val})`, t: 'v', stmt: true };
      }
      if (left.isMemberExpression()) return { code: this.setMember(left, this.v(p.get('right'))), t: 'v', stmt: true };
      const t = this.tmp();
      return { code: `DestructureExpr(${this.v(p.get('right'))}, (V ${t}) => { ${this.assignPattern(left, t, p)} })`, t: 'v', stmt: true };
    }
    const op = n.operator.slice(0, -1);
    if (op === '&&' || op === '||' || op === '??') throw this.err(p, 'logical assignment');
    if (left.isIdentifier()) {
      const r = this.ref(left, left.node.name);
      if (r && r.sb && op === '+') { const c = r.code + this.appendParts(this.expr(p.get('right'))); return { code: `${c}.Str`, t: 's', stmtCode: c }; }
      const cur = r ? { code: r.code, t: r.num ? 'n' : 'v' } : { code: `G(${csStr(left.node.name)})`, t: 'v' };
      const res = this.binaryOp(op, cur, this.expr(p.get('right')));
      if (r && r.num) { const c = `${r.code} = ${this.toN(res)}`; return { code: `(${c})`, stmtCode: c, t: 'n', stmt: true }; }
      if (r) { const c = `${r.code} = ${this.toV(res)}`; return { code: `(${c})`, stmtCode: c, t: 'v', stmt: true }; }
      return { code: `GSet(${csStr(left.node.name)}, ${this.toV(res)})`, t: 'v', stmt: true };
    }
    // a member: the object and key evaluated once
    const OPS = { '+': 0, '-': 1, '*': 2, '/': 3, '%': 4, '|': 5, '&': 6, '^': 7, '<<': 8, '>>': 9, '>>>': 10, '**': 11 };
    const o = this.v(left.get('object')), k = this.propName(left);
    const rhs = this.v(p.get('right'));
    return { code: k ? `OpSet(${o}, ${k}, ${OPS[op]}, ${rhs})` : `OpSetK(${o}, ${this.v(left.get('property'))}, ${OPS[op]}, ${rhs})`, t: 'v', stmt: true };
  }
  update(p) {
    const n = p.node, a = p.get('argument'), d = n.operator === '++' ? '1D' : '-1D';
    if (a.isIdentifier()) {
      const r = this.ref(a, a.node.name);
      if (r && r.num) return { code: n.prefix ? `${n.operator}${r.code}` : `${r.code}${n.operator}`, t: 'n', stmt: true };
      if (r) return { code: `${n.prefix ? 'PreInc' : 'PostInc'}(ref ${r.code}, ${d})`, t: 'n', stmt: true };
      return { code: `GInc(${csStr(a.node.name)}, ${d}, ${n.prefix ? 'true' : 'false'})`, t: 'n', stmt: true };
    }
    if (a.isMemberExpression()) {
      const o = this.v(a.get('object')), k = this.propName(a);
      return { code: k ? `IncM(${o}, ${k}, ${d}, ${n.prefix ? 'true' : 'false'})` : `IncK(${o}, ${this.v(a.get('property'))}, ${d}, ${n.prefix ? 'true' : 'false'})`, t: 'n', stmt: true };
    }
    throw this.err(p, 'update of ' + a.node.type);
  }
}

// functions done natively in C# instead (the same result, run.mjs checks it): the stand-in's markup writer
const NATIVE = { 'dom-shim.js': { serialize: 'Dom.SerializeFn' } };

// Math.* called directly: (args as C# doubles) -> C# double expression, or null to call it the slow way
const MATH = {
  abs: (a) => a.length === 1 && `System.Math.Abs(${a[0]})`,
  floor: (a) => a.length === 1 && `System.Math.Floor(${a[0]})`,
  ceil: (a) => a.length === 1 && `System.Math.Ceiling(${a[0]})`,
  round: (a) => a.length === 1 && `Round(${a[0]})`,
  trunc: (a) => a.length === 1 && `System.Math.Truncate(${a[0]})`,
  sign: (a) => a.length === 1 && `Sign(${a[0]})`,
  sqrt: (a) => a.length === 1 && `System.Math.Sqrt(${a[0]})`,
  cbrt: (a) => a.length === 1 && `FdLibm.Cbrt(${a[0]})`,
  sin: (a) => a.length === 1 && `FdLibm.Sin(${a[0]})`,
  cos: (a) => a.length === 1 && `FdLibm.Cos(${a[0]})`,
  tan: (a) => a.length === 1 && `FdLibm.Tan(${a[0]})`,
  asin: (a) => a.length === 1 && `FdLibm.Asin(${a[0]})`,
  acos: (a) => a.length === 1 && `FdLibm.Acos(${a[0]})`,
  atan: (a) => a.length === 1 && `FdLibm.Atan(${a[0]})`,
  atan2: (a) => a.length === 2 && `FdLibm.Atan2(${a[0]}, ${a[1]})`,
  exp: (a) => a.length === 1 && `FdLibm.Exp(${a[0]})`,
  log: (a) => a.length === 1 && `FdLibm.Log(${a[0]})`,
  log2: (a) => a.length === 1 && `FdLibm.Log2(${a[0]})`,
  log10: (a) => a.length === 1 && `FdLibm.Log10(${a[0]})`,
  pow: (a) => a.length === 2 && `Pow(${a[0]}, ${a[1]})`,
  hypot: (a) => a.length >= 1 && `Hypot(${a.join(', ')})`,
  min: (a) => `Min(${a.join(', ')})`,
  max: (a) => `Max(${a.join(', ')})`,
  fround: (a) => a.length === 1 && `((double)(float)(${a[0]}))`,
  sinh: (a) => a.length === 1 && `FdLibm.Sinh(${a[0]})`,
  cosh: (a) => a.length === 1 && `FdLibm.Cosh(${a[0]})`,
  tanh: (a) => a.length === 1 && `FdLibm.Tanh(${a[0]})`,
};

export function compileScript(name, src) {
  return new Compiler(name, src).compile();
}

// ---------------------------------------------------------------------------------------------------------------
if (process.argv[1] && path.resolve(process.argv[1]) === fileURLToPath(import.meta.url)) {
  const test = process.argv.includes('--test');
  const outDir = process.argv.includes('--out') ? process.argv[process.argv.indexOf('--out') + 1] : OUT;
  if (!fs.existsSync(path.join(WORK, 'rive-rig.js'))) { const { build } = await import('../../../webgame/build.mjs'); await build(WORK); }
  fs.mkdirSync(outDir, { recursive: true });
  // Unity wants a .meta (a fresh guid) for each new file and folder; the existing ones keep theirs
  const inUnity = path.resolve(outDir).startsWith(path.join(REPO, 'unity/Assets') + path.sep);
  const guid = () => [...Array(32)].map(() => Math.floor(Math.random() * 16).toString(16)).join('');
  const meta = (f, folder) => {
    if (!inUnity || fs.existsSync(f + '.meta')) return;
    fs.writeFileSync(f + '.meta', folder ? `fileFormatVersion: 2\nguid: ${guid()}\nfolderAsset: yes\nDefaultImporter:\n  externalObjects: {}\n  userData: \n  assetBundleName: \n  assetBundleVariant: \n` : `fileFormatVersion: 2\nguid: ${guid()}\n`);
  };
  meta(path.resolve(outDir), true);
  const written = new Set(['Scripts.cs']);
  const classes = [];
  let total = 0;
  for (const [name, file] of scriptList(test)) {
    const src = file ? fs.readFileSync(file, 'utf8') : resultStates();
    const t0 = Date.now();
    const { cls, code } = compileScript(name, src);
    const out = path.join(outDir, cls + '.cs');
    fs.writeFileSync(out, code);
    meta(out);
    written.add(cls + '.cs');
    total += code.length;
    classes.push([name, cls]);
    console.log(`${name.padEnd(22)} ${(src.length / 1024).toFixed(0).padStart(5)} KB js -> ${(code.length / 1024).toFixed(0).padStart(5)} KB c# (${Date.now() - t0} ms)`);
  }
  // the scripts in order, for the host (Creatures/NativeRig.cs runs them once, as the page loads them)
  const list = `// The compiled scripts in the order the host runs them (tools/unity/rig/jsc.mjs). Generated: don't edit.
namespace SquishSquad.Creatures.Js.Gen
{
    public static class Scripts
    {
        public static readonly (string name, System.Action run)[] All =
        {
${classes.map(([n, c]) => `            (${csStr(n)}, ${c}.Run),`).join('\n')}
        };
    }
}
`;
  fs.writeFileSync(path.join(outDir, 'Scripts.cs'), list);
  meta(path.join(outDir, 'Scripts.cs'));
  // (scripts no longer in the list: gone, with their .meta)
  for (const f of fs.readdirSync(outDir)) if (f.endsWith('.cs') && !written.has(f)) { fs.rmSync(path.join(outDir, f)); fs.rmSync(path.join(outDir, f + '.meta'), { force: true }); }
  console.log(`${classes.length} scripts, ${(total / 1048576).toFixed(1)} MB of C# -> ${path.relative(REPO, outDir)}`);
}
