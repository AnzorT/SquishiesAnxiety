// The Dance Club's atmosphere (HOUSE_PORT_PLAN.md stage 9): club-fx.js's ClubFog ported (a fog machine switched on:
// puffs by its tier's rate, size, life and opacity, in its style: jet, haze, up, ring, mist; tier 5's bubbles and the
// up-style's confetti bursts; the low fog bank swaying at the floor point and the room dimming round it; switched off,
// the puffs run out and the bank and dim fade over the tier's linger), the party's disco spots (DISCO: 22 neon spots
// sliding across, discoStep), and the club's music (musicSync: rubber-band-hustle.mp3 while speakers play in the Dance
// Club, instead of the groove). Puffs are quads of one soft-circle texture tinted per puff, in one mesh (the page's
// radial-gradient divs, animated by WAAPI keyframes: the eased progress through 3 keyframes).
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SquishSquad.House.View
{
    public sealed class HouseClubView
    {
        sealed class Tier { public double Rate, S0, S1, Life, Op, Spd, Bank, Linger, Dim, Bub; }
        static readonly Dictionary<int, Tier> TIER = new Dictionary<int, Tier>
        {
            [1] = new Tier { Rate = 0, S0 = 0, S1 = 0, Life = 4.6, Op = 0, Spd = 0, Bank = 0, Linger = 0.4, Dim = 0, Bub = 6 },
            [2] = new Tier { Rate = 4, S0 = 24, S1 = 42, Life = 3.6, Op = 0.5, Spd = 70, Bank = 0, Linger = 1.2, Dim = 0.1, Bub = 0 },
            [3] = new Tier { Rate = 7, S0 = 34, S1 = 62, Life = 6, Op = 0.56, Spd = 52, Bank = 0.32, Linger = 6, Dim = 0.18, Bub = 0 },
            [4] = new Tier { Rate = 10, S0 = 42, S1 = 80, Life = 7.6, Op = 0.62, Spd = 48, Bank = 0.44, Linger = 9, Dim = 0.24, Bub = 0 },
            [5] = new Tier { Rate = 14, S0 = 56, S1 = 104, Life = 10.5, Op = 0.7, Spd = 38, Bank = 0.56, Linger = 14, Dim = 0.3, Bub = 3 },
        };
        static readonly string[] CONF = { "#ff4f6a", "#ffd84f", "#3ff0ff", "#7dff6a", "#b04bff", "#ffffff", "#ff9d3c" };
        static readonly Func<double, double> Ease = Easing.Bezier(0.22, 0.6, 0.35, 1), EaseUp = Easing.Bezier(0.1, 0.8, 0.3, 1), EaseConf = Easing.Bezier(0.15, 0.75, 0.4, 1), Lin = x => x;
        const int CAP = 170;

        sealed class Key { public double X, Y, S, Op, At; }
        sealed class P { public Key[] K; public double T0, Life, Size, W = 1, H = 1; public Color C; public Func<double, double> E; public bool Ring; }
        sealed class Job { public string Key, Style; public Tier T; public int Tn; public string[] Tint; public double Acc, BAcc, T0, Last; public bool CfDone; public double Off = -1; public (double x, double y) Fl; public double S; }

        readonly HouseCreatures _sim;
        readonly HouseRoomView _room;
        readonly List<P> _ps = new List<P>();
        readonly Dictionary<string, Job> _jobs = new Dictionary<string, Job>();
        readonly System.Random _r = new System.Random();
        Mesh _mesh, _discoMesh; Material _mat; MeshRenderer _mr, _dmr; GameObject _go, _dgo;
        const int Order = 2000 + 880 * 4 - 1, DiscoOrder = 2000 + 830 * 4;

        public HouseClubView(HouseRoomView room, HouseCreatures sim) { _room = room; _sim = sim; }

        double R(double a, double b) => a + _r.NextDouble() * (b - a);
        T Pick<T>(IList<T> a) => a[_r.Next(a.Count)];
        static Color Hex(string h, double a) { ColorUtility.TryParseHtmlString(h, out var c); c.a = (float)a; return c; }

        static Texture2D SoftTex()
        {
            // the puffs' radial-gradient(closest-side, a 0%, a*0.6 42%, a*0.18 72%, 0 100%) as alpha
            int n = 64; var t = new Texture2D(n, n, TextureFormat.RGBA32, false) { wrapMode = TextureWrapMode.Clamp };
            var px = new Color32[n * n];
            for (int y = 0; y < n; y++) for (int x = 0; x < n; x++)
                {
                    double d = Math.Sqrt(Math.Pow((x + 0.5) / n * 2 - 1, 2) + Math.Pow((y + 0.5) / n * 2 - 1, 2));
                    double a = d < 0.42 ? 1 - 0.4 * d / 0.42 : d < 0.72 ? 0.6 - 0.42 * (d - 0.42) / 0.3 : d < 1 ? 0.18 * (1 - (d - 0.72) / 0.28) : 0;
                    px[y * n + x] = new Color32(255, 255, 255, (byte)(255 * a));
                }
            t.SetPixels32(px); t.Apply(); return t;
        }

        void Ensure()
        {
            if (_go != null) return;
            var tex = SoftTex();
            _go = new GameObject("club fx"); _go.transform.SetParent(_room.transform, false);
            _mesh = new Mesh { name = "club fx" }; _mesh.MarkDynamic(); _go.AddComponent<MeshFilter>().sharedMesh = _mesh;
            _mr = _go.AddComponent<MeshRenderer>(); _mat = new Material(Shader.Find("Sprites/Default")) { mainTexture = tex }; _mr.sharedMaterial = _mat; _mr.sortingOrder = Order;
            _dgo = new GameObject("disco"); _dgo.transform.SetParent(_room.transform, false);
            _discoMesh = new Mesh { name = "disco" }; _discoMesh.MarkDynamic(); _dgo.AddComponent<MeshFilter>().sharedMesh = _discoMesh;
            _dmr = _dgo.AddComponent<MeshRenderer>(); _dmr.sharedMaterial = _mat; _dmr.sortingOrder = DiscoOrder;
        }

        public void Update(double now)
        {
            Ensure();
            // (no club track of its own: patches.mjs turns the page's rubber-band-hustle.mp3 off, `const want = false`,
            // so the Dance Club plays the speakers' groove like every room: HouseMovieView)
            // the jobs: one per fog machine switched on (the room's)
            foreach (var key in _sim.Fogs) if (!_jobs.ContainsKey(key)) Start(key, now);
            foreach (var kv in new List<KeyValuePair<string, Job>>(_jobs)) if (kv.Value.Off < 0 && !_sim.Fogs.Contains(kv.Key)) kv.Value.Off = now;
            foreach (var j in new List<Job>(_jobs.Values))
            {
                if (j.Off >= 0) { if (now - j.Off > j.T.Linger * 1000 + 100) _jobs.Remove(j.Key); continue; }
                var A = _sim.FogAnchor(j.Key.Substring(3)); if (A == null) { _jobs.Remove(j.Key); continue; }
                var a = A.Value; j.Fl = a.fl; j.S = a.s;
                double el = (now - j.T0) / 1000, rate = j.T.Rate;
                if (j.Style == "up") { double ph = el % 2.4; rate = ph < 0.7 ? j.T.Rate * 3.2 : j.T.Rate * 0.12; if (a.cf != null && ph < 0.1 && !j.CfDone) { j.CfDone = true; Confetti(a.cf.Value, a.s, now); } if (ph > 0.2) j.CfDone = false; }
                if (_ps.Count > CAP) continue;
                double dt = Math.Min(0.5, (now - (j.Last == 0 ? now - 100 : j.Last)) / 1000); j.Last = now;
                j.Acc += rate * dt; while (j.Acc >= 1) { j.Acc -= 1; Puff(j, a, now); }
                j.BAcc += j.T.Bub * dt; while (j.BAcc >= 1) { j.BAcc -= 1; Bubble(a, j.Tn > 1, now); }
            }
            Draw(now);
            Disco(now);
        }

        void Start(string key, double now)
        {
            var A = _sim.FogAnchor(key.Substring(3)); if (A == null) return; var f = A.Value.fog;
            int t = Math.Max(1, Math.Min(5, (int)f.Num("t"))); var tint = f.Arr("tint");
            _jobs[key] = new Job { Key = key, T = TIER[t], Tn = t, Style = f.Str("style") ?? "jet", Tint = tint != null && tint.Count > 0 ? tint.ConvertAll(x => (string)x).ToArray() : new[] { "#f4f6fa" }, T0 = now, Fl = A.Value.fl, S = A.Value.s };
        }

        static Key K(double x, double y, double s, double op, double at) => new Key { X = x, Y = y, S = s, Op = op, At = at };

        void Puff(Job job, (List<(double x, double y)> pts, (double x, double y) fl, (double x, double y)? cf, double[] dir, double s, JObj fog) A, double now)
        {
            var t = job.T; double s = A.s; var q = Pick(A.pts); double sz = R(t.S0, t.S1) * s, life = t.Life * R(0.8, 1.15) * 1000, op = t.Op * R(0.7, 1), h = sz / 2;
            var col = Hex(Pick(job.Tint), 1); double x0 = q.x - h, y0 = q.y - h, dx = A.dir[0], dy = A.dir[1], px = -dy, py = dx, sp = t.Spd * s * t.Life;
            Key[] k; Func<double, double> e = Ease;
            switch (job.Style)
            {
                case "jet": { double a = R(-0.4, 0.4), L = sp * R(0.45, 0.75); k = new[] { K(x0, y0, 0.22, 0, 0), K(x0 + dx * L * 0.5 + px * a * L * 0.25, y0 + dy * L * 0.5 + py * a * L * 0.25, 0.9, 1, 0.16), K(x0 + dx * L + px * a * L * 0.8, y0 + dy * L + py * a * L * 0.8 - L * 0.16, 2.1, 0, 1) }; break; }
                case "haze": { double L = sp * R(0.35, 0.7), ex = R(-1, 1) * L, ey = -R(0.05, 0.35) * L; k = new[] { K(x0, y0, 0.3, 0, 0), K(x0 + dx * L * 0.4 + ex * 0.3, y0 + dy * L * 0.3 + ey * 0.3, 1, 1, 0.2), K(x0 + dx * L * 0.6 + ex, y0 + dy * L * 0.2 + ey, 2.4, 0, 1) }; break; }
                case "up": { double H = 150 * s * R(0.8, 1.2), jx = R(-8, 8) * s; k = new[] { K(x0, y0, 0.18, 0, 0), K(x0 + jx, y0 - H * 0.55, 0.85, 1, 0.14), K(x0 + jx * 4, y0 - H, 2.3, 0, 1) }; e = EaseUp; break; }
                case "ring": case "mist": { double a = R(0, Math.PI * 2), L = sp * R(0.3, 0.6), up = job.Style == "mist" ? R(0.15, 0.45) : 0.05, sw = R(-0.6, 0.6);
                    k = new[] { K(x0 + Math.Cos(a) * 6 * s, y0 + Math.Sin(a) * 2 * s, 0.3, 0, 0), K(x0 + Math.Cos(a + sw) * L * 0.45, y0 + Math.Sin(a + sw) * L * 0.16 - L * up * 0.5, 1, 1, 0.2), K(x0 + Math.Cos(a) * L, y0 + Math.Sin(a) * L * 0.34 - L * up, 2.3, 0, 1) }; break; }
                default: return;
            }
            col.a = (float)op;
            _ps.Add(new P { K = k, T0 = now, Life = life, Size = sz, C = col, E = e });
        }

        void Bubble((List<(double x, double y)> pts, (double x, double y) fl, (double x, double y)? cf, double[] dir, double s, JObj fog) A, bool small, double now)
        {
            double s = A.s; var q = Pick(A.pts); double sz = R(small ? 6 : 9, small ? 12 : 20) * s, h = sz / 2, dx = A.dir[0], dy = A.dir[1], px = -dy, py = dx, L = R(70, 150) * s, life = R(3.2, 5.2) * 1000, w = R(4, 10) * s * (_r.NextDouble() < 0.5 ? -1 : 1);
            (double, double) Pt(double f) { double ux = dx * L * f + px * Math.Sin(f * 6.3) * w, uy = dy * L * f + py * Math.Sin(f * 6.3) * w - L * 0.55 * Math.Pow(f, 1.25); return (q.x - h + ux, q.y - h + uy); }
            var ks = new List<Key>(); double[] fs = { 0, 0.25, 0.5, 0.75, 0.93 };
            for (int i = 0; i < fs.Length; i++) { var (x, y) = Pt(fs[i]); ks.Add(K(x, y, i > 0 ? 1 : 0.4, i > 0 ? 0.95 : 0, fs[i])); }
            var (ex, ey) = Pt(0.93); ks.Add(K(ex, ey, 1.35, 0, 1));
            _ps.Add(new P { K = ks.ToArray(), T0 = now, Life = life, Size = sz, C = new Color(0.75f, 0.92f, 1f, 0.55f), E = Lin, Ring = true });
        }

        void Confetti((double x, double y) c, double s, double now)
        {
            for (int i = 0; i < 22; i++)
            {
                double w = R(3, 6) * s, hh = w * R(0.45, 0.7), vx = R(-70, 70) * s, H = R(110, 190) * s, life = R(2.2, 3.4) * 1000;
                _ps.Add(new P { K = new[] { K(c.x, c.y, 0.6, 1, 0), K(c.x + vx * 0.6, c.y - H, 1, 1, 0.32), K(c.x + vx, c.y - H * 0.35 + R(0, 50) * s, 1, 0, 1) }, T0 = now, Life = life, Size = 1, W = w, H = hh, C = Hex(Pick(CONF), 1), E = EaseConf });
            }
        }

        readonly List<Vector3> _v = new List<Vector3>(); readonly List<Vector2> _uv = new List<Vector2>(); readonly List<Color> _c = new List<Color>(); readonly List<int> _tri = new List<int>();
        void Quad(double x, double y, double w, double h, Color c, bool solid = false)
        {
            int n = _v.Count; _v.Add(_room.World(x, y)); _v.Add(_room.World(x + w, y)); _v.Add(_room.World(x + w, y + h)); _v.Add(_room.World(x, y + h));
            if (solid) { var m = new Vector2(0.5f, 0.5f); _uv.Add(m); _uv.Add(m); _uv.Add(m); _uv.Add(m); }
            else { _uv.Add(new Vector2(0, 1)); _uv.Add(new Vector2(1, 1)); _uv.Add(new Vector2(1, 0)); _uv.Add(new Vector2(0, 0)); }
            for (int i = 0; i < 4; i++) _c.Add(c);
            _tri.Add(n); _tri.Add(n + 1); _tri.Add(n + 2); _tri.Add(n); _tri.Add(n + 2); _tri.Add(n + 3);
        }

        void Draw(double now)
        {
            _v.Clear(); _uv.Clear(); _c.Clear(); _tri.Clear();
            // the dim and the bank of each machine (faded in over 1.6 s / 3 s, out over its linger)
            foreach (var j in _jobs.Values)
            {
                double inD = Math.Min(1, (now - j.T0) / 1600), inB = Math.Min(1, (now - j.T0) / 3000), lin = j.T.Linger * 1000;
                double outF = j.Off < 0 ? 1 : Math.Max(0, 1 - (now - j.Off) / lin), outD = j.Off < 0 ? 1 : Math.Max(0, 1 - (now - j.Off) / Math.Max(600, lin * 0.7));
                if (j.T.Dim > 0) Quad(-60, -60, 852 + 120, 393 + 120, new Color(12 / 255f, 10 / 255f, 26 / 255f, (float)(j.T.Dim * 0.8 * inD * outD)), true);
                if (j.T.Bank > 0)
                {
                    double w = (150 + j.Tn * 40) * j.S, h = w * 0.3, sway = Math.Sin((now - j.T0) / 5200 * Math.PI) , sx = 1 + 0.07 * (sway + 1), sy = 1 + 0.04 * (sway + 1), off = 0.04 * w * sway;
                    var c = Hex(j.Tint[0], j.T.Bank * inB * outF);
                    Quad(j.Fl.x - w * sx / 2 + off, j.Fl.y - h * 0.6 - h * (sy - 1) / 2, w * sx, h * sy, c);
                }
            }
            for (int i = _ps.Count - 1; i >= 0; i--)
            {
                var p = _ps[i]; double u = (now - p.T0) / p.Life; if (u >= 1) { _ps.RemoveAt(i); continue; } if (u < 0) continue;
                double e = p.E(u); int a = 0; while (a < p.K.Length - 2 && e > p.K[a + 1].At) a++;
                var k0 = p.K[a]; var k1 = p.K[a + 1]; double f = k1.At > k0.At ? Math.Max(0, Math.Min(1, (e - k0.At) / (k1.At - k0.At))) : 1;
                double x = k0.X + (k1.X - k0.X) * f, y = k0.Y + (k1.Y - k0.Y) * f, s = k0.S + (k1.S - k0.S) * f, op = k0.Op + (k1.Op - k0.Op) * f;
                double w = (p.Size > 1 ? p.Size : p.W) * s, h = (p.Size > 1 ? p.Size : p.H) * s, cx = x + (p.Size > 1 ? p.Size : p.W) / 2, cy = y + (p.Size > 1 ? p.Size : p.H) / 2;   // (scaled about its centre, as CSS's transform-origin)
                var c = p.C; c.a *= (float)op;
                Quad(cx - w / 2, cy - h / 2, w, h, c, p.Size <= 1);
            }
            _mesh.Clear(); _mesh.SetVertices(_v); _mesh.SetUVs(0, _uv); _mesh.SetColors(_c); _mesh.SetTriangles(_tri, 0); _mesh.RecalculateBounds();
            _mr.enabled = _v.Count > 0;
        }

        // the party's disco spots (DISCO: 22 neon spots, sliding left to right; the layer starts 50 px above the box)
        static readonly string[] NEONC = HouseCreatures.NEONC;
        void Disco(double now)
        {
            bool on = _sim.Party && _sim.S.Cur == "dance";
            _dmr.enabled = on; if (!on) return;
            _v.Clear(); _uv.Clear(); _c.Clear(); _tri.Clear();
            for (int n = 0; n < 22; n++)
            {
                double x0 = (n * 97) % 900, y = 16 + ((n * 53) % 360) - 50, r = 6 + (n * 7) % 9, v = 0.5 + ((n * 37) % 10) / 10.0;
                double l = ((x0 + now * 0.06 * v) % 920 + 920) % 920 - 34, z = r * 2;
                Quad(l - 1.5, y - 1.5, z + 3, z + 3, Hex(NEONC[n % 6], 0.5));   // (blur(1.5px): the soft edge)
            }
            _discoMesh.Clear(); _discoMesh.SetVertices(_v); _discoMesh.SetUVs(0, _uv); _discoMesh.SetColors(_c); _discoMesh.SetTriangles(_tri, 0); _discoMesh.RecalculateBounds();
        }

        public void Destroy() { if (_go != null) Object.Destroy(_go); if (_dgo != null) Object.Destroy(_dgo); if (_mat != null) Object.Destroy(_mat); }
    }
}
