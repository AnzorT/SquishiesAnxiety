// The Movie Room's home theater (HOUSE_PORT_PLAN.md stage 9): the page's rnTheater (a screen, a player and speakers
// in the room: synced; enough friends seated: ready) and movie-night.js's show (play: the movie for the screen's tier,
// resumed where it was left; the lights dim over 1.2 s, the picture fades in; pause / resume; its cues make the seated
// friends laugh, gasp, cheer, hide, doze and wake (mvCue, mvStep's rig values); it ends, the lights come up and it
// stops). The pictures and soundtracks are the page's own, exported as video (tools/unity/house/export-movies.mjs ->
// StreamingAssets/Movies, Resources/House/movies.json); House/View/HouseMovieView.cs plays them on the screen's quad.
// Not here: the film looks of each screen tier, the full-screen view, the movie picker (the latest unlocked or the last
// picked plays), the 10 s app ad.
using System;
using System.Collections.Generic;

namespace SquishSquad.House
{
    public sealed class Theater
    {
        public bool HasScreen, HasPlayer, HasSpk, Synced, Ready, Edit;
        public double Tier, ScW, ScH; public double[] ScM;   // the screen's box: w x h, mapped into the room by m
        public string Player; public readonly List<string> Spk = new List<string>();
        public int Crew;
    }

    public sealed class MovieShow { public JObj Mv; public double Mt, Age, EndA, MsgT; public bool Pause, Done; public string Msg; }

    public sealed partial class HouseCreatures
    {
        const double DIM = 1.2, UP = 1.2;
        public Theater Th;
        public MovieShow Show;
        bool _prevReady;
        /// <summary>The movies (movies.json's list) and where each was left / which was picked (the page's localStorage).</summary>
        public List<JObj> Movies = new List<JObj>();
        public readonly Dictionary<string, double> MoviePos = new Dictionary<string, double>();
        public string MoviePick;
        public Action MoviesChanged;   // (pos / pick changed: the screen saves them)
        readonly Dictionary<string, JObj> _screens = new Dictionary<string, JObj>();

        // a piece's drawing data (the draw host's variant: the screen's box, the fog's points), when the export's lacks it
        JObj DrawingOf(JObj it, JObj D, string field)
        {
            var I = RnI(it.Str("id")); var dr = I?.dr;
            if (dr?.Obj(field) is JObj s0) return s0;
            bool sp = S.CanSpin(it); double? rot = sp ? it.Num("r") : D.Truthy("mount") ? (it.Truthy("w") ? it.Num("r") : 0) : (double?)null;
            string key = D.Str("reno") + "|" + (rot?.ToString() ?? "") + "|" + field;
            if (!_screens.TryGetValue(key, out var sc)) { sc = HouseDraw.Variant(D.Str("reno"), null, it["txt"] as string, rot, S.Cur)?.Obj(field); _screens[key] = sc; }
            return sc;
        }
        JObj ScreenOf(JObj it, JObj D) => DrawingOf(it, D, "screen");

        /// <summary>fogA: a fog machine's spray points, floor point, confetti point and direction in the room, its scale, its
        /// fog settings (t, style, tint), or null.</summary>
        public (List<(double x, double y)> pts, (double x, double y) fl, (double x, double y)? cf, double[] dir, double s, JObj fog)? FogAnchor(string id)
        {
            var it = FindItem(id); var D = Cat(it); var I = RnI(id); if (it == null || D == null || I == null) return null;
            var F = DrawingOf(it, D, "fog"); if (F == null) return null;
            (double, double) M(JObj q) => A2R(it, I.Value, q.Num("x"), q.Num("y"));
            var pts = new List<(double, double)>(); foreach (var o in F.Arr("pts") ?? new List<object>()) if (o is JObj q) pts.Add(M(q));
            if (pts.Count == 0) return null;
            var d = F.Arr("dir"); double d0 = d != null ? (double)d[0] : 0, d1 = d != null ? (double)d[1] : -1;
            return (pts, F.Obj("fl") is JObj fl ? M(fl) : pts[0], F.Obj("cf") is JObj cf ? M(cf) : ((double, double)?)null, new[] { I.Value.fl ? -d0 : d0, d1 }, Math.Min(2.4, I.Value.k * S.Geo.SAt(it.Num("y")) * 1.2), F);
        }

        /// <summary>rnTheater</summary>
        public Theater TheaterNow()
        {
            var th = new Theater(); var G = S.Geo;
            foreach (var it in RoomItems())
            {
                var D = Cat(it); if (D == null || !D.Has("reno")) continue; var I = RnI(it.Str("id")); if (I == null) continue;
                var r = Row(it); if (r == null) continue; string role = HouseSave.RoleOf(r);
                if (role == "screen")
                {
                    th.HasScreen = true; var sc = ScreenOf(it, D);
                    if (sc != null && (th.ScM == null || r.Num("tier") >= th.Tier))
                    {
                        double sa = G.SAt(it.Num("y")), Kx = I.Value.kx * sa, Ky = I.Value.ky * sa, fs = I.Value.fl ? -1 : 1, Y = it.Num("y") - LiftPx(it); var m = sc.Arr("m");
                        double M(int k) => (double)m[k];
                        th.Tier = r.Num("tier"); th.ScW = sc.Num("w"); th.ScH = sc.Num("h");
                        th.ScM = new[] { M(0) * Kx * fs, M(1) * Ky, M(2) * Kx * fs, M(3) * Ky, it.Num("x") + fs * M(4) * Kx, Y + M(5) * Ky };
                    }
                }
                else if (role == "player") { th.HasPlayer = true; th.Player = it.Str("id"); }
                else if (role == "spk") { th.HasSpk = true; th.Spk.Add(it.Str("id")); }
            }
            th.Synced = th.HasScreen && th.HasPlayer && th.HasSpk && th.ScM != null; th.Edit = Edit;
            th.Crew = Vis.FindAll(c => c.SeatItem != null && !c.Moving).Count; int need = Math.Min(4, Vis.Count);
            th.Ready = th.Synced && ((need > 0 && th.Crew >= need) || Show != null);
            return th;
        }

        List<JObj> Unlocked() { double tr = Th != null && Th.Tier > 0 ? Th.Tier : 1; return Movies.FindAll(m => m.Num("tier") <= tr); }
        JObj PickMv(string id) { var A = Unlocked(); if (A.Count == 0) return null; var w = id ?? MoviePick; return A.Find(m => m.Str("id") == w) ?? A[A.Count - 1]; }
        public bool Showing => Show != null;
        public bool Paused => Show != null && Show.Pause;

        /// <summary>play: the movie for the screen's tier (or the one picked), from where it was left.</summary>
        public void PlayMovie(string id = null)
        {
            if (Th == null || !Th.Synced) return; var mv = PickMv(id); if (mv == null) return;
            if (Show != null) StopShow(true);
            MoviePick = mv.Str("id");
            double pos = MoviePos.TryGetValue(mv.Str("id"), out var p) ? p : 0; if (!(pos > 2 && pos < mv.Num("dur") - 3)) pos = 0;
            Show = new MovieShow { Mv = mv, Mt = pos - DIM, Msg = pos > 0 ? "Resuming at " + Fmt(pos) : "", MsgT = 3 };
            MoviesChanged?.Invoke(); Bump();
        }
        static string Fmt(double s) { int t = (int)Math.Floor(s); return (t / 60) + ":" + (t % 60).ToString("00"); }

        public void TogglePause() { if (Show == null || Show.Done) return; Show.Pause = !Show.Pause; if (Show.Pause) SavePos(Show); Bump(); }

        public void StopShow(bool keep = false)
        {
            if (Show == null) return; var s = Show; SavePos(s); Show = null;
            foreach (var c in Vis) { c.MvR = null; c.MvDz = false; }
            Bump();
        }

        void SavePos(MovieShow s)
        {
            double m = s.Mt; string id = s.Mv.Str("id");
            if (!s.Done && m > 2 && m < s.Mv.Num("dur") - 3) MoviePos[id] = Math.Round(m * 10) / 10; else MoviePos.Remove(id);
            MoviesChanged?.Invoke();
        }

        double _lastPosSave = -1;
        /// <summary>theater() and frame(): ready -> the show starts; no longer ready -> it stops; its clock and cues.</summary>
        public void MovieTick(double now, double dt)
        {
            Th = S.Cur == "movie" || S.Cur == "living" ? TheaterNow() : null;
            if (Th == null || !Th.Synced) { if (Show != null) { Show.Done = true; StopShow(); } _prevReady = false; if (Th == null) return; }
            else
            {
                if (Show != null && !Th.Ready) StopShow();
                if (Th.Ready && !_prevReady && Show == null) PlayMovie();
                _prevReady = Th.Ready;
            }
            var SH = Show; if (SH == null) return;
            dt = Math.Min(0.25, Math.Max(0, dt));
            if (!SH.Pause)
            {
                SH.Age += dt;
                if (!SH.Done)
                {
                    double m0 = SH.Mt; SH.Mt += dt; double dur = SH.Mv.Num("dur"); if (SH.Mt >= dur) { SH.Mt = dur; SH.Done = true; }
                    Cues(m0, SH.Mt);
                    if (Math.Floor(SH.Mt) != _lastPosSave) { _lastPosSave = Math.Floor(SH.Mt); SavePos(SH); }
                }
                else SH.EndA += dt;
                if (SH.MsgT > 0 && SH.Mt > 0) SH.MsgT -= dt;
            }
            if (SH.Done && SH.EndA > UP + 0.6) { StopShow(); MvCue("end", now); }
        }

        void Cues(double m0, double m1)
        {
            var C = Show?.Mv.Arr("cues"); if (C == null || m1 - m0 > 1) return;
            foreach (List<object> q in C) { double t = (double)q[0]; if (t > m0 && t <= m1) { var k = (string)q[1]; if (k != "confetti" && k != "pop") MvCue(k, _mvNow); } }
        }
        double _mvNow;

        /// <summary>The dim (0..1), the picture's opacity, the screen light [r, g, b, lit] now (the view's).</summary>
        public (double dim, double pic, double[] light) ShowLook()
        {
            var SH = Show; if (SH == null) return (0, 0, null);
            double cl(double v) => Math.Max(0, Math.Min(1, v)); double Out(double x) => 1 - Math.Pow(1 - x, 3);
            double dOp = SH.Done ? 1 - cl(SH.EndA / UP) : Out(cl(SH.Age / DIM)), fin = SH.Done ? 1 - cl((SH.EndA - 0.5) / 0.6) : 1, on = cl((SH.Age - DIM + 0.6) / 0.6);
            double[] L = null; var lt = SH.Mv.Arr("light");
            if (lt != null && lt.Count > 0) { int i = Math.Max(0, Math.Min(lt.Count - 1, (int)Math.Floor(Math.Max(0, SH.Mt) * 10))); var a = (List<object>)lt[i]; L = new[] { (double)a[0], (double)a[1], (double)a[2], (double)a[3] }; }
            return (dOp, on * fin, L ?? new double[] { 200, 210, 255, 1 });
        }

        // ---- the seated friends watching (mvCue, mvStep) ----
        static readonly Dictionary<string, double> MVD = new Dictionary<string, double> { ["laugh"] = 1700, ["gasp"] = 1300, ["cheer"] = 2200, ["hide"] = 1900, ["dance"] = 12000 };
        static readonly Dictionary<string, string[]> MVT = new Dictionary<string, string[]> { ["laugh"] = new[] { "Haha!", "Hee hee!", "Hahaha!" }, ["gasp"] = new[] { "Ooh!", "Whoa!", "Gasp!" }, ["cheer"] = new[] { "Yay!", "Woohoo!", "Hooray!" }, ["hide"] = new[] { "Eek!", "Yikes!", "Eep!" }, ["dance"] = new[] { "Encore!", "Bravo!", "Dance party!" } };

        public void MvCue(string k, double now)
        {
            var cr = Vis.FindAll(c => c.SeatItem != null && !c.Moving);
            if (k == "end") { foreach (var c in Vis) { c.MvR = null; c.MvDz = false; } return; }
            if (k == "doze") { var a = cr.FindAll(c => !c.MvDz); if (a.Count > 0) { var c = a[(int)Math.Floor(Rand() * a.Count)]; c.MvDz = true; } return; }
            if (k == "wake") { foreach (var c in cr) if (c.MvDz) { c.MvDz = false; c.MvR = new HouseCreature.MvReact { K = "gasp", T0 = now, D = 1300 }; Say(c, "Huh?!", now); } return; }
            double D = MVD.TryGetValue(k, out var dd) ? dd : 1500; var T = MVT.TryGetValue(k, out var tt) ? tt : new[] { "!" };
            for (int i = 0; i < cr.Count; i++)
            {
                var c = cr[i]; if (c.MvDz) continue; double d = i * 130 + Rand() * 120; c.MvR = new HouseCreature.MvReact { K = k, T0 = now + d, D = D };
                if (i % 2 == 0 || cr.Count < 3) { var line = T[(i + (int)Math.Floor(Rand() * 3)) % T.Length]; var cc = c; Later(d, () => Say(cc, line, _mvNow)); }
            }
        }

        /// <summary>mvStep: a seated friend's reaction as rig values (sq, tilt, hap, smile, open, wide, arms) and a hop.</summary>
        void MvStep(HouseCreature c, double now)
        {
            _mvNow = now;
            bool on = Show != null && !Show.Pause;
            if (c.MvR == null && !c.MvDz && !on) return;
            bool seated = c.SeatItem != null && !c.Moving;
            if (!seated) { c.MvR = null; c.MvDz = false; return; }
            if (on && c.MvR == null && !c.MvDz && now > c.MvMn) { if (c.MvMn != 0) { c.MvR = new HouseCreature.MvReact { K = "munch", T0 = now, D = 1500 }; if (Rand() < 0.4) Say(c, new[] { "Nom!", "Crunch!", "Munch munch" }[(int)Math.Floor(Rand() * 3)], now); } c.MvMn = now + 7000 + Rand() * 8000; }
            var E = c.Ext; void add(string k, double x) => E[k] = (E.TryGetValue(k, out var v) ? v : 0) + x;
            double ks = S.Geo.SAt(c.Y); var R = c.MvR;
            if (R == null) return;
            double u = (now - R.T0) / R.D; if (u >= 1) { c.MvR = null; return; } if (u < 0) return;
            double env = Math.Max(0, Math.Min(1, Math.Min(u / 0.15, (1 - u) / 0.25))), w = Math.Abs(Math.Sin(now * 0.028));
            switch (R.K)
            {
                case "laugh": add("sq", 0.06 * w * env); add("tilt", 5 * Math.Sin(now * 0.014) * env); add("hap", env); add("smile", env); add("open", 0.45 * w * env); c.Oy -= 2.5 * ks * w * env; break;
                case "gasp": { double g = u < 0.2 ? u / 0.2 : 1 - (u - 0.2) / 0.8; add("wide", g); add("open", 0.7 * g); add("sq", -0.1 * g); add("armL", 40 * g); add("armR", 40 * g); c.Oy -= 7 * ks * Math.Sin(Math.PI * Math.Min(1, u / 0.35)); break; }
                case "cheer": { double h = Math.Abs(Math.Sin(u * Math.PI * 4)); c.Oy -= 9 * ks * h * env; add("armL", 130 * env); add("armR", 130 * env); add("hap", env); add("smile", env); add("open", 0.4 * env); add("sq", 0.08 * (1 - h) * env); break; }
                case "hide": add("armL", 100 * env); add("armR", 100 * env); add("sqz", env); add("sq", 0.1 * env); c.Ox += Math.Sin(now * 0.09) * 0.8 * ks * env; break;
                case "dance": { double ts = (now - R.T0) / 1000, e2 = Math.Max(0, Math.Min(1, Math.Min(ts / 0.4, (R.D / 1000 - ts) / 0.6))), b = ts * 2, h = Math.Abs(Math.Sin(b * Math.PI)), s = Math.Sin(b * Math.PI / 2);
                    c.Oy -= 11 * ks * h * e2; add("armL", (70 + 60 * Math.Max(0, s)) * e2); add("armR", (70 + 60 * Math.Max(0, -s)) * e2); add("tilt", 7 * s * e2); add("hap", e2); add("smile", e2); add("open", 0.35 * e2); add("sq", 0.07 * (1 - h) * e2); break; }
                case "munch": { double m = Math.Abs(Math.Sin(now * 0.02)); add("sq", 0.05 * m * env); add("open", 0.3 * m * env); add("armR", 30 * env); break; }
            }
        }
    }
}
