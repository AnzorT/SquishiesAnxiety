// What the Characters page and the Level Pass share (webgame/app/menu.js §4 / §5 and the page shell main-menu.js
// pageOpen): exported pictures and where they go, the draw list a page model makes each frame, the page's opening
// motion, the sideways drag of its rows (dragRow) and the texts Unity draws with the app's fonts. Plain C# (no
// UnityEngine): tools/unity/pages-test runs the same models outside Unity and compares what they draw with the app.
//
// Units: "pu" = the page's own CSS px (main-menu.js puts the page in .mm-pg at scale(k), k = H / 393, so a pu is
// H / 393 screen px on any screen); "px" = screen pixels (y down). Pictures were cut on the reference screen
// (2340 x 1080, `u` px per pu) and are drawn at Pu / u of their size, which is 1 there: every picture lands on the
// pixels it was cut from.
using System;
using System.Collections.Generic;
using System.Globalization;
using SquishSquad.Ui;
using SquishSquad.Vector;

namespace SquishSquad.Menu
{
    /// <summary>A picture cut from the page: Resources/&lt;page&gt;/&lt;res&gt;.png (or .jpg) as bytes, `at` its top-left minus
    /// its element's box's top-left (reference px), `box` that box at the cut (pu).</summary>
    [Serializable]
    public class PagePic
    {
        public string res;
        public float[] at;
        public int[] size;
        public float[] box;
    }

    [Serializable]
    public class PageRef
    {
        public int[] px;
        public float[] dp;
        public float dpr, k, u, pgW;
    }

    /// <summary>One thing to draw. `M` maps its pixels (y down, top-left 0, 0) to its parent's px; only the part
    /// U0..U1 x V0..V1 (0..1 of the picture, top-left origin) is drawn. A picture (Res), a drawn SVG (Svg, `SvgScale`
    /// px per unit) or a layer (Layer: these draws in its own W x H px, composited as one, as CSS does an element with
    /// opacity). Clip: only inside CX0..CX1 x CY0..CY1 of the parent (a scroll box's overflow).</summary>
    public struct PageDraw
    {
        public string Key, Res, Svg;
        public bool Jpeg;
        public double SvgScale;
        public Affine M;
        public int W, H;
        public double U0, V0, U1, V1;
        public double Opacity;
        public bool Clip;
        public double CX0, CY0, CX1, CY1;
        public List<PageDraw> Layer;
    }

    /// <summary>The page's geometry on a screen, and the helpers that turn pictures into draws.</summary>
    public sealed class PageGeom
    {
        public readonly double W, H, Pu, PgW, S, URef;

        public PageGeom(PageRef r, double screenW, double screenH)
        {
            W = screenW; H = screenH;
            Pu = screenH / 393.0;
            PgW = screenW / Pu;
            // (the json's u is rounded: the reference's own px per pu, 1080 / 393)
            double exact = r.px[1] / 393.0;
            URef = Math.Abs(exact - r.u) < 1e-3 ? exact : r.u;
            S = Pu / URef;
        }

        /// <summary>The screen px of a point in pu.</summary>
        public double X(double pu) => pu * Pu;

        /// <summary>CSS transform `css` (pu, about its own origin, as an element's transform) of an element whose box
        /// starts at (bx, by) pu: element-local px (relative to its box) to page px.</summary>
        public Affine Elem(double bx, double by, Affine css) =>
            Affine.Translate(bx * Pu, by * Pu) * Affine.ScaleBy(Pu, Pu) * css * Affine.ScaleBy(1 / Pu, 1 / Pu);

        public static Affine About(double ox, double oy, Affine t) => Affine.Translate(ox, oy) * t * Affine.Translate(-ox, -oy);

        // pictures at scale 1 go on whole pixels (the cut's own pixels, sharp; Chrome draws a piece moved by a fraction of
        // a pixel anew, a picture moved by one would only blur)
        public static bool SnapAll = false;
        Affine Snap(Affine m)
        {
            if (Math.Abs(m.A - 1) > 1e-9 || Math.Abs(m.D - 1) > 1e-9 || m.B != 0 || m.C != 0) return m;
            double e = Math.Floor(m.E + 0.5), f = Math.Floor(m.F + 0.5);
            if (SnapAll || Math.Abs(m.E - e) < 0.02) m.E = e;
            if (SnapAll || Math.Abs(m.F - f) < 0.02) m.F = f;
            return m;
        }

        /// <summary>The picture of an element whose box is at (bx, by) pu, moved by `css` (pu, about the box's origin).</summary>
        public PageDraw Pic(string key, PagePic p, double bx, double by, double opacity = 1, Affine? css = null)
        {
            var m = Elem(bx, by, css ?? Affine.Identity) * Affine.Translate(p.at[0] * S, p.at[1] * S) * Affine.ScaleBy(S, S);
            return new PageDraw { Key = key, Res = p.res, M = Snap(m), W = p.size[0], H = p.size[1], U0 = 0, V0 = 0, U1 = 1, V1 = 1, Opacity = opacity };
        }

        /// <summary>A picture at its own box (as cut).</summary>
        public PageDraw At(string key, PagePic p, double opacity = 1) => Pic(key, p, p.box[0], p.box[1], opacity);

        /// <summary>A whole-screen picture (a background), stretched to the screen.</summary>
        public PageDraw Screen(string key, PagePic p) =>
            new PageDraw { Key = key, Res = p.res, Jpeg = true, M = Affine.ScaleBy(W / p.size[0], H / p.size[1]), W = p.size[0], H = p.size[1], U0 = 0, V0 = 0, U1 = 1, V1 = 1, Opacity = 1 };

        /// <summary>A box cut at one width (p.box[2] pu) drawn `w` pu wide at (bx, by): narrower, its picture's left part
        /// up to w - capR and its right end; wider, its left end, its middle stretched and its right end (`capL`,
        /// `capR` pu: the round ends with their shadows).</summary>
        public void Slice(List<PageDraw> into, string key, PagePic p, double bx, double by, double w, double capL, double capR, double opacity = 1)
        {
            double wc = p.box[2], u = URef, x0 = -p.at[0];                  // x0: the box's left edge in the picture (px)
            var base_ = Elem(bx, by, Affine.Identity) * Affine.Translate(p.at[0] * S, p.at[1] * S) * Affine.ScaleBy(S, S);
            double size = p.size[0];
            PageDraw Part(string k, double q0, double q1, Affine m) =>
                new PageDraw { Key = key + k, Res = p.res, M = Snap(m), W = p.size[0], H = p.size[1], U0 = Math.Max(0, q0 / size), V0 = 0, U1 = Math.Min(1, q1 / size), V1 = 1, Opacity = opacity };
            double rq = Math.Round(x0 + (wc - capR) * u);                  // where the right end starts in the picture
            if (w <= wc)
            {
                double shift = (w - wc) * Pu;                               // the right end moves left by this (screen px)
                into.Add(Part(":l", 0, rq + (w - wc) * u, base_));
                into.Add(Part(":r", rq, size, Affine.Translate(shift, 0) * base_));
            }
            else
            {
                double lq = Math.Round(x0 + capL * u);
                into.Add(Part(":l", 0, lq, base_));
                // the middle: one column of the picture (at lq) stretched from capL to w - capR
                double from = lq, to = rq + (w - wc) * u;                   // in picture px of a picture `w` wide
                var mid = base_ * Affine.Translate(from, 0) * Affine.ScaleBy((to - from) / 1.0, 1) * Affine.Translate(-lq, 0);
                into.Add(Part(":m", lq, lq + 1, mid));
                into.Add(Part(":r", rq, size, Affine.Translate((w - wc) * Pu, 0) * base_));
            }
        }

        /// <summary>An SVG drawn by Unity (UiSvg, in pu) with its top-left at (x, y) pu: the fraction of a pixel goes
        /// into the drawing, so it lands as Chrome puts it and the texture sits on whole pixels.</summary>
        public PageDraw Svg(string key, double x, double y, double w, double h, Action<UiSvg, float, float> draw, double margin = 4, double opacity = 1)
        {
            double px = (x - margin) * Pu, py = (y - margin) * Pu;
            double ix = Math.Floor(px), iy = Math.Floor(py);
            float fx = (float)((px - ix) / Pu), fy = (float)((py - iy) / Pu);
            float sw = (float)(w + 2 * margin + 1 / Pu), sh = (float)(h + 2 * margin + 1 / Pu);
            var s = new UiSvg(sw, sh);
            draw(s, (float)margin + fx, (float)margin + fy);
            int pw = (int)Math.Ceiling(sw * Pu), ph = (int)Math.Ceiling(sh * Pu);
            return new PageDraw { Key = key, Svg = s.Markup, SvgScale = Pu, M = Affine.Translate(ix, iy), W = pw, H = ph, U0 = 0, V0 = 0, U1 = 1, V1 = 1, Opacity = opacity };
        }

        /// <summary>Clips draws [from..] of `list` to a box (pu).</summary>
        public void ClipTo(List<PageDraw> list, int from, double x, double y, double w, double h)
        {
            for (int i = from; i < list.Count; i++)
            {
                var d = list[i];
                d.Clip = true; d.CX0 = x * Pu; d.CY0 = y * Pu; d.CX1 = (x + w) * Pu; d.CY1 = (y + h) * Pu;
                list[i] = d;
            }
        }

        public static bool In(double[] box, double x, double y) => x >= box[0] && y >= box[1] && x < box[0] + box[2] && y < box[1] + box[3];
    }

    /// <summary>The page shell's motions (main-menu.js .mm-page2: mmPage .42s cubic-bezier(.2,.9,.25,1), opacity 0 -> 1
    /// and scale(1.06) -> none about the screen's middle; closing removes it at once).</summary>
    public static class PageMotion
    {
        static readonly Func<double, double> Curve = CssEase.Bezier(.2, .9, .25, 1);
        public const double OpenMs = 420;

        public static (double opacity, double scale) Open(double ms)
        {
            if (ms >= OpenMs) return (1, 1);
            double t = Curve(Math.Max(0, ms) / OpenMs);
            return (t, 1.06 + (1 - 1.06) * t);
        }

        /// <summary>The whole page as a layer, moved and faded as it opens.</summary>
        public static PageDraw Layer(PageGeom g, List<PageDraw> page, double msSinceOpen)
        {
            var (o, s) = Open(msSinceOpen);
            return new PageDraw
            {
                Key = "page", Layer = page, W = (int)Math.Ceiling(g.W), H = (int)Math.Ceiling(g.H), Opacity = o,
                M = PageGeom.About(g.W / 2, g.H / 2, Affine.ScaleBy(s, s)), U0 = 0, V0 = 0, U1 = 1, V1 = 1,
            };
        }

        /// <summary>CSS keyframes between (offset, value) stops with `ease` per segment (the animation's timing function).</summary>
        public static double Keyframes(double p, (double at, double v)[] kf, Func<double, double> ease)
        {
            if (p <= kf[0].at) return kf[0].v;
            for (int i = 1; i < kf.Length; i++)
                if (p <= kf[i].at) { double t = (p - kf[i - 1].at) / Math.Max(1e-9, kf[i].at - kf[i - 1].at); return kf[i - 1].v + (kf[i].v - kf[i - 1].v) * ease(t); }
            return kf[kf.Length - 1].v;
        }
    }

    /// <summary>A row that scrolls sideways by dragging (webgame/app/menu.js dragRow): it follows the finger once it's
    /// more than 6 px from where it went down, and glides on after a flick (the speed of the last move, times 0.94
    /// every 16 ms, until under 0.02 pu/ms); a drag doesn't count as a tap on what's in it. Units: pu, ms.</summary>
    public sealed class DragScroll
    {
        public double Value, Max;
        bool _down, _moved;
        double _x0, _s0, _lx, _lt, _v, _glideT = -1;
        Func<double, double> _tweenEase;
        double _tFrom, _tTo, _tStart = -1, _tMs;

        public bool Moved => _moved;
        public bool Dragging => _down && _moved;

        public void Clamp() => Value = Math.Max(0, Math.Min(Max, Value));

        public void Down(double x, double now) { StopGlide(); _down = true; _x0 = _lx = x; _s0 = Value; _lt = now; _v = 0; _moved = false; }

        public void Move(double x, double now)
        {
            if (!_down) return;
            double dx = x - _x0;
            if (!_moved && Math.Abs(dx) > 6) _moved = true;
            if (!_moved) return;
            Value = _s0 - dx; Clamp();
            _v = (x - _lx) / Math.Max(1, now - _lt); _lx = x; _lt = now;
        }

        /// <summary>The finger lifted: true if it was a drag (not a tap).</summary>
        public bool Up(double now)
        {
            if (!_down) return false;
            _down = false;
            if (!_moved) return false;
            if (Math.Abs(_v) >= 0.05) _glideT = now;
            return true;
        }

        public void Wheel(double d) { StopGlide(); Value += d; Clamp(); }

        public void StopGlide() { _glideT = -1; _tStart = -1; }

        /// <summary>A tween to `to` (the arrows' jump: 380 ms, ease-in-out quad).</summary>
        public void TweenTo(double to, double now, double ms, Func<double, double> ease) { StopGlide(); _tFrom = Value; _tTo = to; _tStart = now; _tMs = ms; _tweenEase = ease; }

        public void Tick(double now)
        {
            if (_tStart >= 0)
            {
                double t = Math.Min(1, (now - _tStart) / _tMs);
                Value = _tFrom + (_tTo - _tFrom) * _tweenEase(t);
                if (t >= 1) _tStart = -1;
            }
            if (_glideT < 0) return;
            // (the page steps it each frame by the frame's time, at most 40 ms)
            while (_glideT >= 0 && _glideT < now)
            {
                double dt = Math.Min(16.667, now - _glideT);
                Value -= _v * dt; Clamp();
                _v *= Math.Pow(0.94, dt / 16);
                _glideT += dt;
                if (Math.Abs(_v) <= 0.02) _glideT = -1;
            }
        }
    }

    /// <summary>The page's texts drawn by Unity with the app's fonts, styled as the CSS styles them.</summary>
    public static class PageText
    {
        public const string Ink = "#6b4426";
        static Shadow[] TxW => new[] { new Shadow(Ink, 0, 1.6f, 0), new Shadow(Ink, 1.2f, 0, 0), new Shadow(Ink, -1.2f, 0, 0), new Shadow(Ink, 0, -1.2f, 0), new Shadow(Ink, 1, 1, 0), new Shadow(Ink, -1, 1, 0) };

        /// <summary>.tx-w in a .mm-p (Fredoka 700, letter-spacing .6px, cream with the ink outline).</summary>
        public static TextStyle White(float size) => new TextStyle { Font = "Fredoka_700Bold", Size = size, LetterSpacing = 0.6f, Color = "#fff6e2", Shadows = TxW };
        /// <summary>A .mm-p.v-gold's own text (the ink colour, no shadow).</summary>
        public static TextStyle OnGold(float size) => new TextStyle { Font = "Fredoka_700Bold", Size = size, LetterSpacing = 0.6f, Color = Ink };
        /// <summary>.sq-lvx small: Nunito 800 10.5px #f6e8ff.</summary>
        public static TextStyle Small => new TextStyle { Font = "Nunito_800ExtraBold", Size = 10.5f, LetterSpacing = 0.6f, Color = "#f6e8ff" };

        public static double Width(string text, TextStyle t) => string.IsNullOrEmpty(text) ? 0 : UiSvg.BoxWidth(text, t);
        public static double Line(TextStyle t) => UiSvg.LineBox(t);

        /// <summary>Number(n).toLocaleString('en-US').</summary>
        public static string Fmt(double n) => HudValues.Fmt(n);
        public static string Int(int n) => n.ToString(CultureInfo.InvariantCulture);
    }
}
