// The app's own yard games, run natively: yard-games.js v6, yg-intros.js and the seven yg-*.js as webgame/build.mjs
// builds them (with webgame/patches.mjs), compiled to C# with the rig by tools/unity/rig/jsc.mjs and run in the rig's
// realm on the browser stand-in, on the rig's one clock (Creatures/NativeRig.cs). tools/unity/rig/yard-host.js is the
// page's side of this (__yard): a game opened as the app's menu page opens one, its stage read back. Unity-free
// (tools/unity/yard-test runs it with plain dotnet): the caller boots the realm (NativeRig.Ready / RigHost.Boot) and
// steps the clock.
using System;
using System.Collections.Generic;
using SquishSquad.Creatures.Js;

namespace SquishSquad.Games.Yard
{
    /// <summary>What the game's page shows that Unity draws itself (yard-host.js ui()): the top bar's words, the hint, the
    /// games' own pills and buttons, the toasts, the intro's sheet or the results card.</summary>
    public sealed class YardUi
    {
        public double W = 780, H = 360;
        public string Phase = "play";            // "intro" | "play" | "result" | "card" (an old portrait card)
        public string Title = "", Score = "", Time = "", Hint = "";
        public bool Hurry;
        public sealed class Pill { public string Css, Text; public List<(string text, string color)> Spans = new List<(string, string)>(); }
        public sealed class Button { public string Label, Color, Css, Icon; }
        public sealed class Buttons { public string Css; public List<Button> List = new List<Button>(); }
        public readonly List<Pill> Pills = new List<Pill>();
        public Buttons Bar;
        public sealed class Toast { public int Id; public string Text, Color; public double X, Y; public bool Big; }
        public readonly List<Toast> Toasts = new List<Toast>();
        public sealed class Intro { public List<string> How = new List<string>(); public List<(string label, bool on)> Opts = new List<(string, bool)>(); public string Best = "", Color = ""; }
        public Intro IntroSheet;
        public sealed class Result { public string Title = "", Score = "", Sub = "", Coins = ""; public int Stars; public List<string> Buttons = new List<string>(); }
        public Result Res;
    }

    public static class YardJs
    {
        static V Y => Rt.G("__yard");
        // (on the rig thread: Creatures/Js/RigThread)
        static V Call(string k) => RigThread.Run(() => { var v = Rt.Invoke(Y, k); Rt.RunMicrotasks(); return v; });
        static V Call(string k, V a) => RigThread.Run(() => { var v = Rt.Invoke(Y, k, a); Rt.RunMicrotasks(); return v; });
        static V Call(string k, V a, V b) => RigThread.Run(() => { var v = Rt.Invoke(Y, k, a, b); Rt.RunMicrotasks(); return v; });
        static V Call(string k, V a, V b, V c) => RigThread.Run(() => { var v = Rt.Invoke(Y, k, a, b, c); Rt.RunMicrotasks(); return v; });

        /// <summary>Whether the realm has the yard games (yard-host.js and the games compiled in).</summary>
        public static bool Available => !Rt.G("__yard").IsNullish && !Rt.G("YardGames").IsNullish;

        /// <summary>Opens the game `id` (yard-games.js's id: hoop, soccer, hop, tramp, slide, corn, pong) with the creature
        /// `key` playing (as the app's menu picks it on the strip: one of the yard's sets, else the yard's own choice).</summary>
        public static bool Open(string id, string key) => Rt.Truthy(Call("open", id, key ?? ""));
        /// <summary>Back to the hub (the game stops, its creatures leave).</summary>
        public static void Close() => Call("close");
        /// <summary>Whether the game went back to the hub itself (its back orb, YARD GAMES on the results).</summary>
        public static bool Closed => Rt.Truthy(Call("closed"));

        /// <summary>The stage's children, bottom to top (svg layers, creature layers .yg-crl, the HUD, the cards).</summary>
        public static List<V> Stage()
        {
            var o = new List<V>();
            if (Call("stage").O is JsArray a) for (int i = 0; i < a.Len; i++) if (a.At(i).O is JsObject) o.Add(a.At(i));
            return o;
        }
        public static string Tag(V el) => Rt.ToStr(Rt.Get(el, "localName"));
        public static string Class(V el) { var c = Rt.Invoke(el, "getAttribute", "class"); return c.IsNullish ? "" : Rt.ToStr(c); }
        public static bool Has(V el, string cls) => (" " + Class(el) + " ").Contains(" " + cls + " ");
        public static List<V> Children(V el)
        {
            var o = new List<V>();
            if (Rt.Get(el, "childNodes").O is JsArray a) for (int i = 0; i < a.Len; i++) if (a.At(i).O is JsObject && Rt.ToNum(Rt.Get(a.At(i), "nodeType")) == 1) o.Add(a.At(i));
            return o;
        }
        /// <summary>A creature's host div: [left, top, width, height] % of the stage, its turn (deg) about (ox, oy) % of its
        /// box, its z-index, hidden (visibility), gone (display none).</summary>
        public static double[] Box(V host)
        {
            var a = Call("box", host).O as JsArray; var o = new double[10];
            if (a != null) for (int i = 0; i < Math.Min(10, a.Len); i++) o[i] = Rt.ToNum(a.At(i));
            return o;
        }
        public static V FirstSvg(V el) => Dom.FirstSvg(el);
        public static string Markup(V el) => Dom.Serialize(el);

        /// <summary>The intro poster's element (.yg-iart: the poster's &lt;svg&gt;, the creatures in it as stills).</summary>
        public static V Art() => Call("el", "art");

        /// <summary>A finger on the stage, in stage units ("pointerdown" | "pointermove" | "pointerup").</summary>
        public static void Pointer(string type, double x, double y) => Call("pointer", type, x, y);
        /// <summary>A card's button: "play", "iback", "back", ("opt", i), ("res", i).</summary>
        public static void Click(string what, int i = 0) { var el = Call("el", what, i); if (!el.IsNullish) Call("click", el); }
        /// <summary>One of a game's own buttons (Hopscotch's), pressed.</summary>
        public static void Press(int i) { var el = Call("el", "btn", i); if (!el.IsNullish) Call("press", el); }
        /// <summary>The synth sounds asked for since the last call (YardGames.SFX's names).</summary>
        public static string[] Sfx()
        {
            if (!(Call("sfx").O is JsArray a) || a.Len == 0) return Array.Empty<string>();
            var o = new string[a.Len]; for (int i = 0; i < a.Len; i++) o[i] = Rt.ToStr(a.At(i)); return o;
        }
        /// <summary>The bests and plays as the page keeps them (localStorage yardgames.v1), JSON, or null.</summary>
        public static string Saved() { var s = Call("saved"); return s.IsNullish ? null : Rt.ToStr(s); }

        static string S(V o, string k) { var v = Rt.Get(o, k); return v.IsNullish ? "" : Rt.ToStr(v); }
        static double N(V o, string k) => Rt.ToNum(Rt.Get(o, k));
        static IEnumerable<V> Each(V o, string k) { if (Rt.Get(o, k).O is JsArray a) for (int i = 0; i < a.Len; i++) yield return a.At(i); }

        /// <summary>What Unity draws itself, now.</summary>
        public static YardUi Ui()
        {
            var json = Call("ui");
            var o = Rt.Invoke(Rt.G("JSON"), "parse", json);
            var u = new YardUi { W = N(o, "W"), H = N(o, "H"), Phase = S(o, "phase"), Title = S(o, "ttl"), Score = S(o, "score"), Time = S(o, "time"), Hint = S(o, "hint"), Hurry = Rt.Truthy(Rt.Get(o, "hurry")) };
            foreach (var e in Each(o, "extra"))
            {
                if (S(e, "kind") == "pill")
                {
                    var p = new YardUi.Pill { Css = S(e, "css"), Text = S(e, "text") };
                    foreach (var s in Each(e, "spans")) p.Spans.Add((Rt.ToStr(Rt.GetIdx(s, 0)), Rt.ToStr(Rt.GetIdx(s, 1))));
                    u.Pills.Add(p);
                }
                else
                {
                    var b = new YardUi.Buttons { Css = S(e, "css") };
                    foreach (var x in Each(e, "buttons")) b.List.Add(new YardUi.Button { Label = S(x, "label"), Color = S(x, "color"), Css = S(x, "css"), Icon = S(x, "icon") });
                    u.Bar = b;
                }
            }
            foreach (var t in Each(o, "toasts"))
                u.Toasts.Add(new YardUi.Toast { Id = (int)N(t, "id"), Text = S(t, "text"), Color = S(t, "col"), X = N(t, "x"), Y = N(t, "y"), Big = Rt.Truthy(Rt.Get(t, "big")) });
            var i = Rt.Get(o, "intro");
            if (i.O is JsObject)
            {
                var s = new YardUi.Intro { Best = S(i, "best"), Color = S(i, "color") };
                foreach (var h in Each(i, "how")) s.How.Add(Rt.ToStr(h));
                foreach (var p in Each(i, "opts")) s.Opts.Add((S(p, "label"), Rt.Truthy(Rt.Get(p, "on"))));
                u.IntroSheet = s;
            }
            var r = Rt.Get(o, "result");
            if (r.O is JsObject)
            {
                var res = new YardUi.Result { Title = S(r, "title"), Score = S(r, "score"), Sub = S(r, "sub"), Coins = S(r, "coins"), Stars = (int)N(r, "stars") };
                foreach (var b in Each(r, "buttons")) res.Buttons.Add(Rt.ToStr(b));
                u.Res = res;
            }
            return u;
        }

        /// <summary>The ui as yard-host.js writes it (tests and logs).</summary>
        public static string UiJson() => Rt.ToStr(Call("ui"));
    }
}
