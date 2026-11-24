// The house screen around the room (HOUSE_PORT_PLAN.md stage 2), as Squad House v6.dc.html does it, in plain C# so
// tools/unity/house-test checks it:
//   HouseCamera  the room box at top 50 px in the 852 x 393 frame, scaled by camK (0.85 indoors, 1 in the dance room,
//                outdoors and on the beach) about (426, 343) of the box, eased over 0.45 s (CSS `transition: transform
//                0.45s ease`) when it changes; the page's toLocal (a frame point -> the box's room units)
//   HouseDoors   a room's doors (its shell's `doors`: hit path, to, lock, spawn, walk) and the page's tapDoor
//   HouseHud     the bottom drawer (its tab, RENOVATE, CATALOG; renderVals' dw: closed at translateY 72, open at -16,
//                0.75 s cubic-bezier(.25,1.15,.4,1); the tab's arrow turns 0 -> 180 deg in 0.25 s ease) and the toast
//                (toast(t): 2.4 s, popping in with hsToast: 0.25 s ease-out from 8 px up and transparent)
// Times are ms on the caller's clock.
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Vector;

namespace SquishSquad.House
{
    public static class HouseFrame
    {
        public const double W = 852, H = 393, BoxTop = 50, OX = 426, OY = 343;
        /// <summary>The house's frame past the 852 x 393 room on each side (design px; 0 on the design's own shape). PERF
        /// 2026-11-20 (webgame/patches.mjs, app/menu.js houseBox; the user: "something white that makes it look like we're
        /// not in full screen"): the frame is the screen at the scale that fits 852 x 393 in it (852 wide and taller on a
        /// taller screen, 393 tall and wider on a wider one); the room, the Catalog and the map stay 852 x 393 in its
        /// middle (rmX = MX, rmY = MY), the HUD keeps to its edges, the sea, the dim and the night fill it.</summary>
        public static double MX, MY;
        /// <summary>RLAB: the rooms' names in messages.</summary>
        public static readonly Dictionary<string, string> RLAB = new Dictionary<string, string>
        {
            { "living", "Living Room" }, { "kitchen", "Kitchen" }, { "bathroom", "Bathroom" }, { "bedroom", "Bedroom" }, { "backyard", "Backyard" },
            { "dance", "Dance Room" }, { "movie", "Movie Room" }, { "beach", "Beach" }, { "style", "Walls & Floors" },
        };
    }

    public sealed class HouseCamera
    {
        static readonly Func<double, double> Ease = Easing.Bezier(0.25, 0.1, 0.25, 1);   // CSS `ease`
        public const double Ms = 450;
        double _from = 1, _to = 1, _t0 = -1e9;

        /// <summary>renderVals' camK for a room: 0.85 indoors, 1 in the dance room, outdoors and on the beach.</summary>
        public static double KFor(string room, bool outdoors, bool beach) => room != "dance" && !outdoors && !beach ? 0.85 : 1;

        /// <summary>The camera's next scale; `animate` false jumps there (the first room).</summary>
        public void Set(double k, double now, bool animate = true)
        {
            if (k == _to && animate) return;
            _from = animate ? K(now) : k;
            _to = k;
            _t0 = animate ? now : -1e9;
        }

        public double K(double now)
        {
            double t = (now - _t0) / Ms;
            if (t >= 1) return _to;
            if (t <= 0) return _from;
            return _from + (_to - _from) * Ease(t);
        }

        public bool Moving(double now) => now - _t0 < Ms;

        /// <summary>A frame point (852 x 393 px) -> the room box's units at scale k (the page's toLocal).</summary>
        public static (double x, double y) ToBox(double fx, double fy, double k) =>
            (HouseFrame.OX + (fx - HouseFrame.OX) / k, HouseFrame.OY + (fy - HouseFrame.BoxTop - HouseFrame.OY) / k);

        /// <summary>A room box point -> the frame at scale k.</summary>
        public static (double x, double y) ToFrame(double bx, double by, double k) =>
            (HouseFrame.OX + (bx - HouseFrame.OX) * k, HouseFrame.BoxTop + HouseFrame.OY + (by - HouseFrame.OY) * k);
    }

    public static class HouseDoors
    {
        static readonly Dictionary<string, Polyline> Shapes = new Dictionary<string, Polyline>();

        static Polyline Shape(string d)
        {
            if (Shapes.TryGetValue(d, out var p)) return p;
            var root = SvgMarkup.Parse("<svg xmlns=\"http://www.w3.org/2000/svg\"><path d=\"" + d + "\"/></svg>");
            SvgNode Find(SvgNode n) { if (n.Tag == "path") return n; foreach (var c in n.Children) { var r = Find(c); if (r != null) return r; } return null; }
            var path = Find(root);
            p = path != null ? Geometry.Flatten(path, Affine.Identity, 0.25, out _) : new Polyline();
            Shapes[d] = p;
            return p;
        }

        // nonzero winding, as SVG's default fill-rule (where the page's transparent hit path takes the pointer)
        public static bool Inside(string d, double x, double y)
        {
            int wn = 0;
            foreach (var c in Shape(d).Contours)
                for (int i = 0; i < c.Count; i++)
                {
                    var a = c[i]; var b = c[(i + 1) % c.Count];
                    if (a.Y <= y) { if (b.Y > y && (b.X - a.X) * (y - a.Y) - (x - a.X) * (b.Y - a.Y) > 0) wn++; }
                    else if (b.Y <= y && (b.X - a.X) * (y - a.Y) - (x - a.X) * (b.Y - a.Y) < 0) wn--;
                }
            return wn != 0;
        }

        /// <summary>The door under a room box point, or null (the shell's doors, last on top as in the markup).</summary>
        public static JObj At(JObj shell, double bx, double by)
        {
            var doors = shell?.Arr("doors");
            if (doors == null) return null;
            for (int i = doors.Count - 1; i >= 0; i--)
                if (doors[i] is JObj d && d.Str("hit") is string hit && Inside(hit, bx, by)) return d;
            return null;
        }

        /// <summary>tapDoor without creatures (stage 3 walks the selected one to the door first): a locked door's toast,
        /// else the next room. Returns the toast, or null when the room changed.</summary>
        public static string LockedText(JObj door)
        {
            string to = door.Str("to");
            return "Boarded up! The " + (HouseFrame.RLAB.TryGetValue(to ?? "", out var n) ? n : to) + " opens at level " + HouseJson.JsString(door["lock"]);
        }

        public static string Tap(HouseSave s, JObj door)
        {
            double lk = door.Num("lock");
            string to = door.Str("to");
            if (lk != 0) return "Boarded up! The " + (HouseFrame.RLAB.TryGetValue(to ?? "", out var n) ? n : to) + " opens at level " + HouseJson.JsString(door["lock"]);
            s.EnterRoom(to);
            return null;
        }
    }

    public sealed class HouseHud
    {
        public sealed class Rect { public double X, Y, W, H; public bool Has(double x, double y, double dy = 0) => x >= X && x <= X + W && y >= Y + dy && y <= Y + H + dy; }

        public readonly Dictionary<string, Rect> Pieces = new Dictionary<string, Rect>(), Buttons = new Dictionary<string, Rect>();
        readonly double _closedTy, _openTy, _drawerMs, _arrowMs, _openDeg, _closedDeg;
        readonly Func<double, double> _drawerEase, _arrowEase;
        public const double ToastMs = 2400, ToastInMs = 250;
        static readonly Func<double, double> ToastEase = Easing.Bezier(0, 0, 0.58, 1);   // CSS ease-out

        public bool Open { get; private set; }
        double _tyFrom, _tyTo, _tyT0 = -1e9, _degFrom, _degTo, _degT0 = -1e9;
        public string Toast { get; private set; }
        public int ToastKey { get; private set; }
        double _toastT0 = -1e9;

        static Rect R(object v) { var a = v as List<object>; return a == null || a.Count < 4 ? null : new Rect { X = (double)a[0], Y = (double)a[1], W = (double)a[2], H = (double)a[3] }; }
        static Func<double, double> Bz(List<object> e) => e != null && e.Count == 4 ? Easing.Bezier((double)e[0], (double)e[1], (double)e[2], (double)e[3]) : Easing.Bezier(0.25, 0.1, 0.25, 1);

        /// <summary>From Resources/House/hud.json (tools/unity/house/export-hud.mjs).</summary>
        /// <summary>The backyard's YARD GAMES button (games.js: right / top of the house's box, its size; where its picture
        /// and its NEW badge's sit against it, frame px) and the menu's back orb (left / bottom of the screen in menu dp).</summary>
        public sealed class YardBtn { public double Right, Top, W, H, PulseMs = 1400, PulseScale = 1.14; public double[] Snap, Badge, BadgeSnap; }
        public sealed class BackOrb { public double Left, Bottom, W, H; public double[] Snap; }
        public YardBtn Yard; public BackOrb Back;
        static double[] A4(JObj o, string k) { var a = o.Arr(k); return a == null ? null : new[] { (double)a[0], (double)a[1], (double)a[2], (double)a[3] }; }

        public HouseHud(string hudJson)
        {
            var j = (JObj)HouseJson.Parse(hudJson);
            if (j.Obj("yard") is JObj y) Yard = new YardBtn { Right = y.Num("right"), Top = y.Num("top"), W = y.Num("w"), H = y.Num("h"), Snap = A4(y, "snap"), Badge = A4(y, "badge"), BadgeSnap = A4(y, "badgeSnap"), PulseMs = y.Obj("pulse")?.Num("ms") ?? 1400, PulseScale = y.Obj("pulse")?.Num("scale") ?? 1.14 };
            if (j.Obj("back") is JObj bk) Back = new BackOrb { Left = bk.Num("left"), Bottom = bk.Num("bottom"), W = bk.Num("w"), H = bk.Num("h"), Snap = A4(bk, "snap") };
            foreach (var k in j.Obj("pieces").Keys) Pieces[k] = R(j.Obj("pieces")[k]);
            foreach (var k in j.Obj("buttons").Keys) Buttons[k] = R(j.Obj("buttons")[k]);
            var d = j.Obj("drawer"); var a = j.Obj("arrow");
            _closedTy = d.Num("closedTy"); _openTy = d.Num("openTy"); _drawerMs = d.Num("ms"); _drawerEase = Bz(d.Arr("ease"));
            _closedDeg = a.Num("closedDeg"); _openDeg = a.Num("openDeg"); _arrowMs = a.Num("ms"); _arrowEase = Bz(a.Arr("ease"));
            _tyFrom = _tyTo = _closedTy; _degFrom = _degTo = _closedDeg;
        }

        static double Tween(double from, double to, double t0, double ms, Func<double, double> ease, double now)
        {
            double t = (now - t0) / ms;
            return t >= 1 ? to : t <= 0 ? from : from + (to - from) * ease(t);
        }

        /// <summary>The drawer's translateY now (frame px; its pieces' rects are at 0).</summary>
        public double DrawerTy(double now) => Tween(_tyFrom, _tyTo, _tyT0, _drawerMs, _drawerEase, now);
        /// <summary>The tab's arrow's rotation now (degrees, about its centre).</summary>
        public double ArrowDeg(double now) => Tween(_degFrom, _degTo, _degT0, _arrowMs, _arrowEase, now);

        public void SetOpen(bool open, double now)
        {
            if (open == Open) return;
            _tyFrom = DrawerTy(now); _tyTo = open ? _openTy : _closedTy; _tyT0 = now;
            _degFrom = ArrowDeg(now); _degTo = open ? _openDeg : _closedDeg; _degT0 = now;
            Open = open;
        }

        /// <summary>The page's toast(t): shown 2.4 s; a new one replaces it and pops in again.</summary>
        public void ShowToast(string text, double now) { Toast = text; ToastKey++; _toastT0 = now; }

        /// <summary>The toast now: its text, opacity and y offset (hsToast), or null when it's gone.</summary>
        public (string text, double op, double dy)? ToastAt(double now)
        {
            if (Toast == null) return null;
            if (now - _toastT0 >= ToastMs) { Toast = null; return null; }
            double t = ToastEase(Math.Min(1, Math.Max(0, (now - _toastT0) / ToastInMs)));
            return (Toast, t, -8 * (1 - t));
        }

        /// <summary>A tap at a frame point: "tab", "renovate", "catalog", or null (not on the drawer).</summary>
        public string Tap(double x, double y, double now)
        {
            double ty = DrawerTy(now);
            if (Pieces.TryGetValue("tab", out var tab) && tab.Has(x, y, ty)) return "tab";
            foreach (var kv in Buttons) if (kv.Value.Has(x, y, ty)) return kv.Key;
            return null;
        }

        /// <summary>Whether a frame point is on the drawer at all (its taps don't reach the room).</summary>
        public bool Covers(double x, double y, double now)
        {
            double ty = DrawerTy(now);
            foreach (var kv in Pieces) if (kv.Value.Has(x, y, ty)) return true;
            return false;
        }
    }
}
