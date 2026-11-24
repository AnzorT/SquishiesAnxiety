// The Yard Games page (develop: the menu's games page in yard mode, main-menu.js openGames('yard') as webgame/patches.mjs
// patches it, with webgame/app/games.js yardCard / yardPage; 2026-11-18, the user: "in the menu of the yard games I want
// it to be in horizontal and put the images of the games on them (on all of them) and make the list of the games
// scrollable, I want the game to be unlocked only when the game got purchased"): the menu's wood page over the house,
// the back orb and "Yard Games" lettering, "n of 7 ready · your creature plays every game", and the seven games as wide
// cards in a row dragged sideways (a drag glides on and never counts as a tap): each card the game's intro poster
// (yg-intros.js) with your creature posed in it, its name and ★ best / New! / Locked, its toy, and PLAY, or, while
// none of its toys is bought in the Backyard's catalog, the poster greyed (saturate .3, brightness .78), a padlock
// and "Buy <toy> in the Backyard catalog (n coins)"; no coins pill. A tap on a locked card says what to buy (the
// menu's toast). Pictures and places: tools/unity/house/export-yardpage.mjs (Resources/Yard/page); the page's
// geometry, draws and texts are the menu pages' (Menu/CharactersPageKit.cs). Plain C# (tools/unity/pages-test `yd`
// runs it outside Unity against the app's screenshots).
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using SquishSquad.Menu;
using SquishSquad.Ui;
using SquishSquad.Vector;

namespace SquishSquad.Games.Yard.View
{
    [Serializable]
    public class YardPageLayout
    {
        public const string Root = "Yard/page/";
        public PageRef reference;
        public PagePic bg, head, padlock;
        public float[] orb, padlockAt;
        public Sub sub;
        public ListBox list;
        public Chip chip;
        public Game[] games;
        public float scrollMax;

        [Serializable] public class Sub { public float[] box; public string font, color, text; }
        [Serializable] public class ListBox { public float top, padL, padR, padT, gap; }
        [Serializable] public class Chip { public string bg, ring, font, color, ls; public float padX, padY, h; }
        [Serializable] public class Cards { public PagePic open, @lock; }
        [Serializable] public class Overs { public PagePic[] open, @lock; }
        [Serializable] public class Slot { public float w, yaw; public string who; public float[] m; public string[] poseK; public float[] poseV; }
        [Serializable] public class Game { public string id; public int segs; public float[] box, win, chip, chipLock, play; public Cards card; public Overs over; public Slot[] slots; }
    }

    public sealed class YardPageModel
    {
        public readonly YardPageLayout L;
        public readonly PageGeom G;
        /// <summary>The row's scroll (pu, scrollLeft).</summary>
        public double Scroll;
        public double ScrollMax => Math.Max(0, ContentW - G.PgW);
        double ContentW { get { var g = L.games[L.games.Length - 1]; return g.box[0] + g.box[2] + L.list.padR; } }

        /// <summary>Is the game open (a toy of it bought: HouseYard.Locked), its best (0: none).</summary>
        public Func<string, bool> Open = _ => true;
        public Func<string, int> Best = _ => 0;
        /// <summary>A creature in a poster: the rig's picture for (game, slot) as SVG in a w x w box (the rig's own
        /// svg, x / y / width / height set), or null (none drawn). `grey`: the locked poster's filter applied.</summary>
        public Func<string, int, bool, string> Creature;
        /// <summary>The menu's toast (a locked card's tap).</summary>
        public string ToastText; public double ToastAt = -1e9;
        /// <summary>What's held down: the back orb, or a card (`HeldGame`); it shrinks to 0.92 about its centre while the
        /// finger stays on it, as the menu's Level crest does (YardScreen.PageInput sets it).</summary>
        public Hit Held; public string HeldGame;

        public YardPageModel(YardPageLayout l, double screenW, double screenH)
        {
            L = l; G = new PageGeom(l.reference, screenW, screenH);
        }

        // ---- what's shown ----
        public PageDraw Draw(double now)
        {
            Tick(now);
            var d = new List<PageDraw>();
            d.Add(G.Screen("bg", L.bg));
            G.Header(d, G.At("head", L.head), L.head, L.orb, Held == Hit.Back);
            // the subtitle: "<open> of <n> ready · your creature plays every game" (main-menu.js openGames; the yard page
            // keeps the design's note)
            int nOpen = 0; foreach (var g in L.games) if (Open(g.id)) nOpen++;
            string sub = nOpen + " of " + L.games.Length + " ready · your creature plays every game";
            var st = new TextStyle { Font = "Nunito_700Bold", Size = 11.5f, Color = Css(L.sub.color) };
            var sb = L.sub.box;
            d.Add(G.Svg("sub:" + sub, sb[0], sb[1], PageText.Width(sub, st) + 2, sb[3], (s, x, y) => s.Text(sub, x, y + (sb[3] - (float)PageText.Line(st)) / 2, st)));
            // the cards
            double top = L.list.top, sc = Scroll;
            foreach (var g in L.games)
            {
                double cx = g.box[0] - sc, cy = top + g.box[1];
                if (cx > G.PgW + 40 || cx + g.box[2] < -40) continue;
                bool op = Open(g.id); string k = g.id + (op ? ":o" : ":l");
                int c0 = d.Count;
                d.Add(G.Pic("card:" + k, op ? g.card.open : g.card.@lock, cx, cy));
                // the poster's creatures, each under the part of the poster drawn after it
                var overs = op ? g.over.open : g.over.@lock;
                for (int i = 0; i < g.slots.Length; i++)
                {
                    var cr = CreatureDraw(g, i, cx, cy, !op);
                    if (cr.HasValue) d.Add(cr.Value);
                    if (overs != null && i < overs.Length && overs[i] != null) d.Add(G.Pic("over:" + k + i, overs[i], cx + g.win[0], cy + g.win[1]));
                }
                // ★ Best n / New! / Locked
                int best = Best(g.id);
                string chip = best > 0 ? "★ Best " + best.ToString(CultureInfo.InvariantCulture) : op ? "New!" : "Locked";
                var cb = !op && g.chipLock != null && g.chipLock.Length == 4 ? g.chipLock : g.chip;
                d.Add(Chip("chip:" + g.id + chip, chip, cx + cb[0] + cb[2], cy + cb[1]));
                if (!op) d.Add(G.Pic("lock:" + g.id, L.padlock, cx + L.padlockAt[0], cy + L.padlockAt[1]));
                // held: the whole card (its poster, creatures, chip and padlock) shrinks about its middle
                if (Held == Hit.Card && HeldGame == g.id) G.Shrink(d, c0, cx + g.box[2] / 2, cy + g.box[3] / 2);
            }
            if (now - ToastAt < 2400 && ToastText != null) d.Add(Toast(now));
            return PageMotion.Layer(G, d, now);
        }

        // .mm-gc .best: padding 2px 9px, radius 999, its background and a 1 px inset ring, Nunito 800 10px, letter-spacing
        // .6px; right-aligned in the card's row (its right edge `right` pu)
        PageDraw Chip(string key, string text, double right, double y)
        {
            var c = L.chip;
            var ts = new TextStyle { Font = "Nunito_800ExtraBold", Size = 10, Color = Css(c.color), LetterSpacing = 0.6f };
            float w = (float)(PageText.Width(text, ts) + 2 * c.padX), h = c.h + 2 * c.padY;
            var ring = Regex.Match(c.ring ?? "", @"rgba?\([^)]*\)");
            return G.Svg(key, right - w, y, w, h, (s, x, y0) =>
            {
                s.Box(x, y0, w, h, new BoxStyle { Background = c.bg, Radius = 999 });
                if (ring.Success) s.Box(x, y0, w, h, new BoxStyle { Radius = 999, BorderWidth = 1, BorderColor = ring.Value });
                s.Text(text, x, y0 + c.padY + (c.h - (float)PageText.Line(ts)) / 2, ts, w, 0.5f);
            });
        }

        // the menu's toast (main-menu.js toast(): .mm-toast mm-p tip v-gold, top 60, centred, max 70 % wide, Fredoka 700
        // 13px, padding 5px 18px; mmToast 2.4 s: in from 8 px up over 10 %, out over the last 15 %), its gold plaque
        // drawn here
        PageDraw Toast(double now)
        {
            double t = (now - ToastAt) / 2400, op = t < 0.1 ? t / 0.1 : t > 0.85 ? (1 - t) / 0.15 : 1, dy = t < 0.1 ? -8 * (1 - t / 0.1) : 0;
            var ts = PageText.OnGold(13);
            float w = (float)Math.Min(G.PgW * 0.7, PageText.Width(ToastText, ts) + 36), h = (float)PageText.Line(ts) + 10;
            return G.Svg("toast:" + ToastText, G.PgW / 2 - w / 2, 60 + dy, w, h, (s, x, y) =>
            {
                s.Box(x, y, w, h, new BoxStyle { Gradient = new[] { "#fff3b8", "#ffd45a", "#f0a828" }, Radius = 999, BorderWidth = 2, BorderColor = PageText.Ink, Shadows = new[] { new Shadow(PageText.Ink, 0, 3, 0) } });
                s.Text(ToastText, x, y + 5, ts, w, 0.5f);
            }, 6, Math.Max(0, Math.Min(1, op)));
        }

        PageDraw? CreatureDraw(YardPageLayout.Game g, int i, double cx, double cy, bool grey)
        {
            var svg = Creature?.Invoke(g.id, i, grey);
            if (svg == null) return null;
            var sl = g.slots[i]; var m = sl.m;
            // the slot's box: (-w/2, -0.93 w) w x w in its own units (yg-intros.js posterRig), with room round it (a
            // creature draws outside its box)
            double w = sl.w, mg = w * 0.25, size = w + 2 * mg;
            double k = Math.Sqrt(m[0] * m[0] + m[1] * m[1]) * G.Pu;      // screen px per slot unit
            int tex = (int)Math.Ceiling(size * k);
            string markup = "<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"" + F(size) + "\" height=\"" + F(size) + "\" viewBox=\"" + F(-w / 2 - mg) + " " + F(-w * 0.93 - mg) + " " + F(size) + " " + F(size) + "\">" + svg + "</svg>";
            var slot = new Affine(m[0], m[1], m[2], m[3], m[4], m[5]);
            var M = Affine.Translate(cx * G.Pu, cy * G.Pu) * Affine.ScaleBy(G.Pu, G.Pu) * slot * Affine.Translate(-w / 2 - mg, -w * 0.93 - mg) * Affine.ScaleBy(size / tex, size / tex);
            return new PageDraw { Key = "cr:" + g.id + i + (grey ? "g" : ""), Svg = markup, SvgScale = tex / size, M = M, W = tex, H = tex, U0 = 0, V0 = 0, U1 = 1, V1 = 1, Opacity = 1 };
        }

        // ---- taps and the drag (games.js yardPage: it follows the finger once more than 8 px from where it went down,
        // then glides: the last move's speed x 16 a frame, x 0.93 each frame, until under 0.4 px; a drag isn't a tap) ----
        public enum Hit { None, Back, Card }
        public Hit HitTest(double px, double py, out string game)
        {
            game = null; double x = px / G.Pu, y = py / G.Pu;
            if (PageGeom.In(Array.ConvertAll(L.orb, v => (double)v), x, y)) return Hit.Back;
            foreach (var g in L.games)
            {
                double cx = g.box[0] - Scroll, cy = L.list.top + g.box[1];
                if (y >= L.list.top && x >= cx && x < cx + g.box[2] && y >= cy && y < cy + g.box[3]) { game = g.id; return Hit.Card; }
            }
            return Hit.None;
        }

        bool _down, _dragged; double _x0, _s0, _lx, _lt, _vel, _glide, _glideT = -1;
        public bool Dragged => _dragged;
        public void Down(double px, double now) { _glideT = -1; _down = true; _dragged = false; _x0 = _lx = px; _s0 = Scroll; _lt = now; _vel = 0; }
        public void Move(double px, double now)
        {
            if (!_down) return;
            double dx = px - _x0;
            if (!_dragged && Math.Abs(dx) > 8) _dragged = true;
            if (!_dragged) return;
            Scroll = Clamp(_s0 - dx / G.Pu);
            _vel = (px - _lx) / Math.Max(1, now - _lt) / G.Pu; _lx = px; _lt = now;
        }
        /// <summary>The finger lifted: true if it was a drag (not a tap).</summary>
        public bool Up(double now)
        {
            if (!_down) return false;
            _down = false;
            if (!_dragged) return false;
            _glide = -_vel * 16; _glideT = now;
            return true;
        }
        public void Wheel(double d) { _glideT = -1; Scroll = Clamp(Scroll + d); }
        void Tick(double now)
        {
            while (_glideT >= 0 && _glideT + 16.667 <= now)
            {
                if (Math.Abs(_glide) < 0.4) { _glideT = -1; break; }
                Scroll = Clamp(Scroll + _glide); _glide *= 0.93; _glideT += 16.667;
            }
        }
        double Clamp(double v) => Math.Max(0, Math.Min(ScrollMax, v));

        public void Toast(string text, double now) { ToastText = text; ToastAt = now; }

        // ---- helpers ----
        static string F(double v) => v.ToString("0.####", CultureInfo.InvariantCulture);
        static string Css(string c)
        {
            var m = Regex.Match(c ?? "", @"rgba?\(\s*(\d+)[ ,]+(\d+)[ ,]+(\d+)");
            return m.Success ? "#" + int.Parse(m.Groups[1].Value).ToString("x2") + int.Parse(m.Groups[2].Value).ToString("x2") + int.Parse(m.Groups[3].Value).ToString("x2") : c;
        }

        /// <summary>The locked poster's filter (games.js .sq-ygc.lock .win > svg: saturate(.3) brightness(.78)) applied
        /// to every colour of a drawing (the creature in it), as Chrome applies it in sRGB.</summary>
        public static string Greyed(string svg)
        {
            return Regex.Replace(svg, @"(?<!url\()#([0-9a-fA-F]{6}|[0-9a-fA-F]{3})\b(?![\w-])|rgba?\(\s*(\d+)[ ,]+(\d+)[ ,]+(\d+)", m =>
            {
                double r, g, b;
                if (m.Groups[1].Success)
                {
                    var h = m.Groups[1].Value; if (h.Length == 3) h = "" + h[0] + h[0] + h[1] + h[1] + h[2] + h[2];
                    r = Convert.ToInt32(h.Substring(0, 2), 16); g = Convert.ToInt32(h.Substring(2, 2), 16); b = Convert.ToInt32(h.Substring(4, 2), 16);
                }
                else { r = double.Parse(m.Groups[2].Value); g = double.Parse(m.Groups[3].Value); b = double.Parse(m.Groups[4].Value); }
                const double s = 0.3, br = 0.78;
                double R = ((0.213 + 0.787 * s) * r + (0.715 - 0.715 * s) * g + (0.072 - 0.072 * s) * b) * br;
                double G2 = ((0.213 - 0.213 * s) * r + (0.715 + 0.285 * s) * g + (0.072 - 0.072 * s) * b) * br;
                double B = ((0.213 - 0.213 * s) * r + (0.715 - 0.715 * s) * g + (0.072 + 0.928 * s) * b) * br;
                int C(double v) => Math.Max(0, Math.Min(255, (int)Math.Round(v)));
                if (m.Groups[1].Success) return "#" + C(R).ToString("x2") + C(G2).ToString("x2") + C(B).ToString("x2");
                return m.Value.StartsWith("rgba") ? "rgba(" + C(R) + "," + C(G2) + "," + C(B) : "rgb(" + C(R) + "," + C(G2) + "," + C(B);
            });
        }
    }
}
