// The robot vacuum (LIV-136 "Robo-Vac & Charging Dock"): the page's vac-bot.js (VacBot) and vacTap. A tap on the dock
// sends the robot out (from the dock's floor point to 26 px in front of it, 1.1 s), then it wanders: to a free spot
// (freeSpot) at 46 px/s (at least 350 ms; cubic-bezier(.45, 0, .55, 1)), a wait of 250-950 ms, again; a turn wiggle
// when it changes direction (rotate 0, ±7 deg up 1 px, ∓3 deg, 0 over 420 ms, ease-out), its body jittering ±1.2 deg
// (240 ms alternate, ease-in-out), a sparkle of dust every 420 ms while it moves (1.3 s). After 5 minutes, or a tap
// while it's out, it drives back in front of the dock and into it (1.1 s), and the dock shows it parked again. Edit
// mode and leaving the room take it away at once. No UnityEngine: House/View/HouseVacView.cs draws it.
using System;
using System.Collections.Generic;
using SquishSquad.Anim;

namespace SquishSquad.House
{
    public sealed class HouseVac
    {
        public readonly string Key, Id;
        /// <summary>"out" (cleaning) or "back" (driving home).</summary>
        public string Mode = "out";
        public bool Dead;
        public double X, Y, T0;
        public double Speed = 46, OutX = 0, OutY = 26, Ms = 300000;
        /// <summary>The dock's floor point (re-read live), a free floor spot, the sprite's scale at y.</summary>
        public Func<(double x, double y)?> Home, Spot;
        public Func<double, double> SAt = y => 1;
        public Action OnDone;
        /// <summary>The dust sparkles: where (room px: left, top, size), their z-index, when.</summary>
        public sealed class Dust { public double L, T, Size, Z, T0; }
        public readonly List<Dust> Dusts = new List<Dust>();

        readonly Random _r = new Random();
        double _x0, _y0, _x1, _y1, _gt0, _gd; Action<double> _gcb; bool _going;
        double _waitAt; Action<double> _wait;
        double _endAt = double.MaxValue, _killAt = -1, _dustAt;
        int _f = 1; double _faceT0 = -1e9, _faceF;

        static readonly Func<double, double> Drive = Easing.Bezier(0.45, 0, 0.55, 1), EaseOut = Easing.Bezier(0, 0, 0.58, 1), EaseInOut = Easing.Bezier(0.42, 0, 0.58, 1);
        public const double DustMs = 1300;

        public HouseVac(string key, string id) { Key = key; Id = id; }

        public static double Z(double y) => Math.Round(y) + 1;

        /// <summary>VacBot.start: true when it set off (it has a dock to start from).</summary>
        public bool Start(double now)
        {
            var h = Home?.Invoke(); if (h == null) return false;
            X = h.Value.x; Y = h.Value.y; T0 = now; _endAt = now + Ms; _dustAt = now + 420;
            Go(now, (h.Value.x + OutX, h.Value.y + OutY), Wander, 1100);
            return true;
        }

        /// <summary>VacBot.stop: drive home (atOnce: gone now).</summary>
        public void Stop(double now, bool atOnce)
        {
            if (Dead) return;
            if (atOnce) { Dead = true; return; }
            if (Mode == "back") return;
            Mode = "back"; _endAt = double.MaxValue; _wait = null;
            if (_going) { var p = At(now); X = p.x; Y = p.y; _going = false; _gcb = null; }
            var h = Home?.Invoke();
            if (h == null) { Dead = true; OnDone?.Invoke(); return; }
            var h0 = h.Value;
            Go(now, (h0.x + OutX, h0.y + OutY), n => { var h2 = Home?.Invoke() ?? h0; Go(n, h2, n2 => { OnDone?.Invoke(); _killAt = n2 + 140; }, 1100); });
        }

        /// <summary>Its clock: the drives' ends, the waits, the 5 minutes, the dust.</summary>
        public void Step(double now)
        {
            if (Dead) return;
            for (; _dustAt <= now; _dustAt += 420) if (MovingAt(_dustAt)) AddDust(_dustAt);
            Dusts.RemoveAll(d => now - d.T0 >= DustMs);
            if (_killAt >= 0 && now >= _killAt) { Dead = true; return; }
            if (Mode == "out" && now >= _endAt) Stop(now, false);
            if (_going && now >= _gt0 + _gd) { _going = false; X = _x1; Y = _y1; var cb = _gcb; _gcb = null; cb?.Invoke(_gt0 + _gd); }
            if (_wait != null && now >= _waitAt) { var w = _wait; _wait = null; w(_waitAt); }
        }

        bool MovingAt(double t) => _going && t >= _gt0 && t < _gt0 + _gd;

        (double x, double y) At(double t)
        {
            if (!_going) return (X, Y);
            double e = Drive(Math.Max(0, Math.Min(1, (t - _gt0) / _gd)));
            return (_x0 + (_x1 - _x0) * e, _y0 + (_y1 - _y0) * e);
        }

        /// <summary>Where it is at `now` and how it's drawn: its floor point (room px), its scale and z-index (eased
        /// with the drive, as the page's animation of left / top / scale / z-index), the turn wiggle's angle (deg, about
        /// the floor point) and lift (px), the body's jitter (deg, about the picture's centre).</summary>
        public (double x, double y, double s, double z, double wig, double lift, double jit) Pose(double now)
        {
            double x, y, s, z;
            if (_going)
            {
                double e = Drive(Math.Max(0, Math.Min(1, (now - _gt0) / _gd)));
                x = _x0 + (_x1 - _x0) * e; y = _y0 + (_y1 - _y0) * e;
                double s0 = SAt(_y0), s1 = SAt(_y1); s = s0 + (s1 - s0) * e;
                z = Math.Round(Z(_y0) + (Z(_y1) - Z(_y0)) * e);
            }
            else { x = X; y = Y; s = SAt(Y); z = Z(Y); }
            double wig = 0, lift = 0, p = (now - _faceT0) / 420;
            if (p >= 0 && p < 1)
            {
                // keyframes 0, ±7 deg (up 1 px), ∓3 deg, 0 at offsets 0, 1/3, 2/3, 1; the ease-out over the whole
                double q = EaseOut(p) * 3; int i = Math.Min(2, (int)q); double f = q - i;
                double[] R = { 0, 7 * _faceF, -3 * _faceF, 0 }, L = { 0, 1, 0, 0 };
                wig = R[i] + (R[i + 1] - R[i]) * f; lift = L[i] + (L[i + 1] - L[i]) * f;
            }
            double k = Math.Max(0, now - T0) / 240; int n = (int)Math.Floor(k); double fr = EaseInOut(k - n);
            double jit = n % 2 == 0 ? -1.2 + 2.4 * fr : 1.2 - 2.4 * fr;
            return (x, y, s, z, wig, lift, jit);
        }

        /// <summary>A sparkle's look at `now`: opacity, scale, its rise (px, in its scaled space).</summary>
        public static (double op, double sc, double ty) DustAt(Dust d, double now)
        {
            double p = Math.Max(0, Math.Min(1, (now - d.T0) / DustMs)), q = EaseOut(p);
            if (q < 0.25) { double f = q / 0.25; return (f, 0.4 + 0.7 * f, 0); }
            double g = (q - 0.25) / 0.75; return (1 - g, 1.1 - 0.5 * g, -6 * g);
        }

        void Go(double now, (double x, double y) p, Action<double> cb, double ms = 0)
        {
            if (Dead) return;
            double dx = p.x - X, dy = p.y - Y, dist = Math.Sqrt(dx * dx + dy * dy);
            Face(now, dx);
            _x0 = X; _y0 = Y; _x1 = p.x; _y1 = p.y; _gt0 = now; _gd = ms > 0 ? ms : Math.Max(350, dist / (Speed > 0 ? Speed : 42) * 1000);
            _gcb = cb; _going = true;
        }

        // the robot is round and symmetric, so it never mirrors; a direction change is a quick turn wiggle
        void Face(double now, double dx)
        {
            if (Math.Abs(dx) < 3) return;
            int f = dx < 0 ? -1 : 1; if (f == _f) return;
            _f = f; _faceT0 = now; _faceF = f;
        }

        void Wander(double now)
        {
            if (Dead || Mode != "out") return;
            var p = Spot?.Invoke();
            if (p == null) { Wait(now, 800, Wander); return; }
            Go(now, p.Value, n => Wait(n, 250 + _r.NextDouble() * 700, Wander));
        }

        void Wait(double now, double ms, Action<double> fn) { _waitAt = now + ms; _wait = fn; }

        void AddDust(double t)
        {
            var (x, y) = At(t); double s = SAt(y), sz = 9 * s;
            Dusts.Add(new Dust { L = x - sz / 2 + (_r.NextDouble() - 0.5) * 16 * s, T = y - sz / 2 - 3 * s, Size = sz, Z = Z(y - 1), T0 = t });
        }
    }

    public sealed partial class HouseCreatures
    {
        /// <summary>The robot vacuums out of their docks, by key 'vac:id'.</summary>
        public readonly Dictionary<string, HouseVac> Vacs = new Dictionary<string, HouseVac>();

        public bool VacBusy(string key) => Vacs.TryGetValue(key, out var b) && !b.Dead;
        public void VacStop(string key) { if (Vacs.TryGetValue(key, out var b)) b.Stop(Last, false); }

        /// <summary>vacTap's start: the robot sprite out of the dock `it` (its drawing's vac: home, bb), cleaning.</summary>
        public bool VacStart(string key, JObj it)
        {
            if (VacBusy(key)) return false;
            string id = it.Str("id");
            var hq = RnI(id)?.dr?.Obj("vac")?.Arr("home");
            if (hq == null || hq.Count < 2) return false;
            double hx = Convert.ToDouble(hq[0]), hy = Convert.ToDouble(hq[1]);
            var R = RS(it);
            var b = new HouseVac(key, id)
            {
                Speed = 46, OutX = 0, OutY = 26,
                Home = () => { var it2 = FindItem(id); var I2 = RnI(id); if (it2 == null || I2 == null) return null; return A2R(it2, I2.Value, hx, hy); },
                Spot = () => { var p = FreeSpot(S.Cur); return (p.x, p.y); },
                SAt = y => S.Geo.SAt(y) * (RnI(id)?.k ?? 1),
                OnDone = () => { R.Play = false; Bump(); },
            };
            if (!b.Start(Last)) return false;
            Vacs[key] = b;
            return true;
        }

        /// <summary>VacBot.stopAll(true): every robot gone at once (leaving the room).</summary>
        public void VacKillAll() { foreach (var b in Vacs.Values) b.Stop(Last, true); Vacs.Clear(); }

        void VacTick(double now)
        {
            if (Vacs.Count == 0) return;
            // (edit mode: the robots gone at once, their docks showing them parked)
            if (Edit)
            {
                foreach (var b in Vacs.Values) { b.Stop(now, true); if (Rst.TryGetValue(b.Id, out var R)) R.Play = false; }
                Vacs.Clear(); Bump(); return;
            }
            var dead = new List<string>();
            foreach (var kv in Vacs) { kv.Value.Step(now); if (kv.Value.Dead) dead.Add(kv.Key); }
            foreach (var k in dead) Vacs.Remove(k);
        }
    }
}
