// The home theater's picture and the house's music (HOUSE_PORT_PLAN.md stage 9), as movie-night.js draws them:
//   the film   the show's movie (StreamingAssets/Movies/<id>.mp4, tools/unity/house/export-movies.mjs) played by a
//              VideoPlayer into a texture on the screen's quad (the theater's matrix; the 320 x 180 film covering the
//              screen's box), fading in, kept at the show's time, paused with it
//   the look   the screen tier's film look (movies.js look): 1 an old projector on a bedsheet (folds, grain, flicker,
//              scratches, gate weave, vignette), 2 an old plasma (scanlines, a rolling band, dark rounded edges, a
//              jitter now and then), 3 clean, 4 cinema bars, 5 holo (a rainbow edge glow, a sheen sweeping across)
//   the room   dimmed round the screen with its light spilling out (the light's colour and level from the movie), the
//              projector's beam from the player to the screen, the speakers hopping on the beat (bounce)
//   the bar    play / pause, the title (or "Resuming at"), the time and its progress, the movie picker (the five,
//              which the screen plays, where each was left), full screen (the film zooms off the screen to a 16:9
//              frame over a darkened view, its controls fading after 2.6 s), the end
//   the loops  the speakers' groove while they play and no show is on, the TV's channel while a TV is on with speakers
// Sounds follow the app's sound-effects setting. Not drawn: the film's CSS filters (blur, saturation), the hair on the
// old film, the speakers' rings and notes, the holo pop-outs and confetti, the 10 s app ad (a screen always has a movie).
using System;
using System.Collections.Generic;
using System.IO;
using SquishSquad.Ui;
using SquishSquad.Vector;
using UnityEngine;
using UnityEngine.Video;
using Object = UnityEngine.Object;

namespace SquishSquad.House.View
{
    public sealed class HouseMovieView
    {
        readonly HouseCreatures _sim;
        readonly HouseRoomView _room;
        readonly float _k;
        readonly JObj _icons;
        GameObject _go; VideoPlayer _vp; RenderTexture _rt; Mesh _mesh; Material _mat; MeshRenderer _mr;
        UiPiece _dark, _spill, _look, _bar, _menu, _back, _xb; string _dimKey, _lookKey, _barKey, _menuKey;
        Mesh _fx, _grain, _beam; MeshRenderer _fxR, _grainR, _beamR; Texture2D _soft, _noise; Color32[] _noisePx;
        AudioSource _groove, _tv; int _tvCh;
        string _loaded;
        readonly System.Random _r = new System.Random();
        const int Order = 2000 + 880 * 4, FocusOrder = 31500;

        public HouseMovieView(HouseRoomView room, HouseCreatures sim, float screenK, JObj icons) { _room = room; _sim = sim; _k = screenK; _icons = icons ?? new JObj(); }

        Affine Frame => Affine.ScaleBy(_k / UiPiece.PxPerDp, _k / UiPiece.PxPerDp);
        double R(double a, double b) => a + _r.NextDouble() * (b - a);

        AudioSource Src(string name, string clip)
        {
            var go = new GameObject(name); go.transform.SetParent(_room.transform, false);
            var a = go.AddComponent<AudioSource>(); a.clip = Resources.Load<AudioClip>("House/audio/" + clip); a.loop = true; a.playOnAwake = false; return a;
        }

        public void Update(double now)
        {
            bool sound = SquishSquad.Audio.Sfx.EffectsOn;
            bool jam = _sim.Jams.Count > 0 && _sim.Show == null && sound && _sim.S.Cur != "dance";   // (musicSync: the Dance Club plays its own track)
            _groove ??= Src("groove", "groove");
            if (jam && !_groove.isPlaying) _groove.Play(); else if (!jam && _groove.isPlaying) _groove.Stop();
            int ch = 0; if (sound && _sim.SpkIn()) foreach (var kv in _sim.Rst) if (kv.Value.Ch > 0 && RoleOf(kv.Key) == "tv") { ch = (int)kv.Value.Ch; break; }
            if (ch != _tvCh) { _tvCh = ch; _tv ??= Src("tv", "tv1"); _tv.Stop(); if (ch > 0) { _tv.clip = Resources.Load<AudioClip>("House/audio/tv" + ch); _tv.Play(); } }
            _sim.FzStep(now);
            Bounce(now);
            Show(now, sound);
        }

        JObj Item(string id) { foreach (var it in _sim.S.H.Obj("rooms")?[_sim.S.Cur] as List<object> ?? new List<object>()) if (it is JObj j && j.Str("id") == id) return j; return null; }
        string RoleOf(string id) { var j = Item(id); var r = j == null ? null : _sim.S.RowOf(_sim.S.D.CatOf(j.Str("t"))); return r == null ? "" : HouseSave.RoleOf(r); }

        // the speakers on the beat (bounce): a hop, a squash on the beat, a sway, a little shake; the big ones every 4th
        void Bounce(double now)
        {
            var b = _sim.Beat(now);
            foreach (var p in _room.Pieces)
            {
                bool spk = p.Id != null && p.Kind != "toy" && b != null && (_sim.Show != null || _sim.Jams.Contains("it:" + p.Id)) && RoleOf(p.Id) == "spk";
                if (!spk) { p.Bx = p.By = p.Rot = 0; p.Sx = p.Sy = 1; continue; }
                var (n, ph, amp) = b.Value; double hop = Math.Sin(Math.PI * ph), sq = Math.Exp(-ph * 9), big = n % 4 == 0 ? 1.6 : 1, H = (p.Box ?? p.Region)[3];
                p.Bx = Math.Sin(now * 0.11) * 1.5 * amp * (0.35 + sq); p.By = -hop * H * 0.1 * big * amp + Math.Cos(now * 0.137) * 0.9 * amp * (0.35 + sq);
                p.Sx = 1 + 0.14 * sq * amp - 0.04 * hop; p.Sy = 1 - 0.14 * sq * amp + 0.06 * hop * amp; p.Rot = (n % 2 != 0 ? 1 : -1) * 3 * hop * amp * big;
            }
        }

        // ---- textures ----
        static Texture2D SoftTex()
        {
            int n = 64; var t = new Texture2D(n, n, TextureFormat.RGBA32, false) { wrapMode = TextureWrapMode.Clamp }; var px = new Color32[n * n];
            for (int y = 0; y < n; y++) for (int x = 0; x < n; x++) { double d = Math.Sqrt(Math.Pow((x + 0.5) / n * 2 - 1, 2) + Math.Pow((y + 0.5) / n * 2 - 1, 2)); px[y * n + x] = new Color32(255, 255, 255, (byte)(255 * Math.Max(0, 1 - d))); }
            t.SetPixels32(px); t.Apply(); return t;
        }
        Mesh MeshOf(string name, Texture tex, out MeshRenderer mr)
        {
            var go = new GameObject(name); go.transform.SetParent(_room.transform, false); var m = new Mesh { name = name }; m.MarkDynamic();
            go.AddComponent<MeshFilter>().sharedMesh = m; mr = go.AddComponent<MeshRenderer>(); mr.sharedMaterial = new Material(Shader.Find("Sprites/Default")) { mainTexture = tex }; return m;
        }

        // ---- geometry: the film's box in the frame (the screen's quad, or zoomed to the full view) ----
        Vec2 _c0, _c1, _c3; double _u0, _u1, _v0, _v1;
        Vec2 FrameOf(double bx, double by) { double k = _room.CamK; return new Vec2(426 + k * (bx - 426), 393 + k * (by + HouseFrame.BoxTop - 393)); }
        Vec2 Box(double u, double v) => _c0 + (_c1 - _c0) * u + (_c3 - _c0) * v;   // (unit box -> frame)
        Vec2 Stage(double sx, double sy) => Box((sx / 320 - _u0) / (_u1 - _u0), (sy / 180 - _v0) / (_v1 - _v0));
        Affine StageAffine() { var o = Stage(0, 0); var ex = Stage(1, 0) - o; var ey = Stage(0, 1) - o; return new Affine(ex.X, ex.Y, ey.X, ey.Y, o.X, o.Y); }
        static double Bk(double x) => 1 + 2 * Math.Pow(x - 1, 3) + Math.Pow(x - 1, 2);

        void Show(double now, bool sound)
        {
            var SH = _sim.Show; var th = _sim.Th;
            if (SH == null || th == null || th.ScM == null)
            {
                if (_vp != null && _vp.isPlaying) _vp.Stop(); _loaded = null;
                foreach (var r in new Renderer[] { _mr, _fxR, _grainR, _beamR }) if (r != null) r.enabled = false;
                foreach (var u in new[] { _dark, _spill, _look, _bar, _menu, _back, _xb }) if (u != null) u.Visible = false;
                return;
            }
            var look = _sim.ShowLook(); int tier = (int)th.Tier;
            if (_go == null)
            {
                _go = new GameObject("movie"); _go.transform.SetParent(_room.transform, false);
                _rt = new RenderTexture(480, 270, 0); _vp = _go.AddComponent<VideoPlayer>(); _vp.playOnAwake = false; _vp.isLooping = false;
                _vp.renderMode = VideoRenderMode.RenderTexture; _vp.targetTexture = _rt; _vp.audioOutputMode = VideoAudioOutputMode.Direct;
                _mesh = new Mesh { name = "movie quad" }; _go.AddComponent<MeshFilter>().sharedMesh = _mesh; _mr = _go.AddComponent<MeshRenderer>();
                _mat = new Material(Shader.Find("Sprites/Default")) { mainTexture = _rt }; _mr.sharedMaterial = _mat;
                _soft = SoftTex(); _noise = new Texture2D(96, 54, TextureFormat.RGBA32, false) { filterMode = FilterMode.Point }; _noisePx = new Color32[96 * 54];
                _fx = MeshOf("movie look", _soft, out _fxR); _grain = MeshOf("movie grain", _noise, out _grainR); _beam = MeshOf("projector beam", _soft, out _beamR);
                _dark = UiPiece.Create(_room.transform, "movie dim", Order); _spill = UiPiece.Create(_room.transform, "movie light", Order + 1);
            }
            string id = SH.Mv.Str("id");
            if (_loaded != id) { _loaded = id; _vp.url = Path.Combine(Application.streamingAssetsPath, "Movies", id + ".mp4"); _vp.Prepare(); }
            if (_vp.isPrepared)
            {
                _vp.SetDirectAudioMute(0, !sound);
                bool run = !SH.Pause && !SH.Done && SH.Mt >= 0;
                if (run) { if (!_vp.isPlaying) { _vp.time = SH.Mt; _vp.Play(); } else if (Math.Abs(_vp.time - SH.Mt) > 0.3) _vp.time = SH.Mt; }
                else { if (_vp.isPlaying) _vp.Pause(); if (SH.Mt >= 0 && Math.Abs(_vp.time - SH.Mt) > 0.1) _vp.time = Math.Max(0, SH.Mt); }
            }
            // the film's box: the screen's quad in the frame, eased to a 16:9 frame filling the view in full screen
            double[] m = th.ScM; double w = th.ScW, h = th.ScH;
            Vec2 Q(double x, double y) => FrameOf(m[0] * x + m[2] * y + m[4], m[1] * x + m[3] * y + m[5]);
            Vec2 q0 = Q(0, 0), q1 = Q(w, 0), q3 = Q(0, h);
            if (m[0] * m[3] - m[1] * m[2] < 0) { var q2 = Q(w, h); q1 = q0; q0 = Q(w, 0); q3 = q2; }   // (a mirrored screen: the film not mirrored)
            double p = _sim.FzP, e = Bk(p * p * (3 - 2 * p)), Wt = Math.Min(852, 393 * 16.0 / 9), Ht = Wt * 9 / 16;
            Vec2 t0 = new Vec2((852 - Wt) / 2, (393 - Ht) / 2), t1 = t0 + new Vec2(Wt, 0), t3 = t0 + new Vec2(0, Ht);
            _c0 = q0 + (t0 - q0) * e; _c1 = q1 + (t1 - q1) * e; _c3 = q3 + (t3 - q3) * e;
            double bw = (_c1 - _c0).Length, bh = (_c3 - _c0).Length, s = Math.Max(bw / 320, bh / 180), uw = bw / (320 * s), vh = bh / (180 * s);
            _u0 = (1 - uw) / 2; _u1 = (1 + uw) / 2; _v0 = (1 - vh) / 2; _v1 = (1 + vh) / 2;
            bool focus = p > 0; int ord = focus ? FocusOrder : Order;
            // tier 1's gate weave: the picture shifts a little each 83 ms
            if (tier <= 1 && now - _weaveAt >= 83) { _weaveAt = now; _wx = (_r.NextDouble() - 0.5) * 1.4 / 320; _wy = (_r.NextDouble() - 0.5) * 1.8 / 180; }
            double wx = tier <= 1 ? _wx : tier == 2 ? _jit : 0, wy = tier <= 1 ? _wy : 0;
            if (tier == 2) _jit = _r.NextDouble() < 0.01 ? (_r.NextDouble() - 0.5) * 3 / 320 : 0;
            var W = new[] { Box(0, 0), Box(1, 0), Box(1, 1), Box(0, 1) };
            _mesh.SetVertices(Array.ConvertAll(W, v => _room.WorldFrame(v.X, v.Y)));
            float u0 = (float)(_u0 - wx), u1 = (float)(_u1 - wx), v0 = (float)(_v0 + wy), v1 = (float)(_v1 + wy);
            _mesh.SetUVs(0, new[] { new Vector2(u0, 1 - v0), new Vector2(u1, 1 - v0), new Vector2(u1, 1 - v1), new Vector2(u0, 1 - v1) });
            var col = new Color(1, 1, 1, (float)look.pic); _mesh.SetColors(new[] { col, col, col, col });
            _mesh.SetTriangles(new[] { 0, 1, 2, 0, 2, 3 }, 0); _mesh.RecalculateBounds(); _mr.enabled = look.pic > 0.001; _mr.sortingOrder = ord + 2;
            Look(tier, now, look.pic, ord);
            Dim(look, m, w, h, focus);
            Beam(th, look, focus);
            Bar(now, ord);
        }
        double _weaveAt, _wx, _wy, _jit, _grainAt, _flick;
        readonly double[] _scratch = { -1, -1 };

        // ---- the screen tier's look ----
        void Look(int tier, double now, double op, int ord)
        {
            // the static layers (an SVG in stage px, clipped to what the screen shows of the film)
            double x0 = _u0 * 320, y0 = _v0 * 180, ww = (_u1 - _u0) * 320, hh = (_v1 - _v0) * 180;
            string key = tier + "|" + Math.Round(x0) + "," + Math.Round(y0) + "," + Math.Round(ww) + "," + Math.Round(hh);
            _look ??= UiPiece.Create(_room.transform, "movie look", ord + 3);
            if (_lookKey != key)
            {
                _lookKey = key; string N(double v) => HouseGeo.N(Math.Round(v * 100) / 100);
                string body = "";
                if (tier <= 1)
                    body = "<defs><linearGradient id=\"f1\" gradientTransform=\"rotate(13 0.5 0.5)\"><stop offset=\"0.14\" stop-opacity=\"0\"/><stop offset=\"0.18\" stop-color=\"#000\" stop-opacity=\"0.13\"/><stop offset=\"0.22\" stop-color=\"#fff\" stop-opacity=\"0.07\"/><stop offset=\"0.27\" stop-opacity=\"0\"/><stop offset=\"0.52\" stop-opacity=\"0\"/><stop offset=\"0.57\" stop-color=\"#000\" stop-opacity=\"0.11\"/><stop offset=\"0.61\" stop-color=\"#fff\" stop-opacity=\"0.06\"/><stop offset=\"0.66\" stop-opacity=\"0\"/><stop offset=\"0.8\" stop-opacity=\"0\"/><stop offset=\"0.86\" stop-color=\"#000\" stop-opacity=\"0.09\"/><stop offset=\"0.92\" stop-opacity=\"0\"/></linearGradient>"
                        + "<radialGradient id=\"vg\" cx=\"0.5\" cy=\"0.5\" r=\"0.71\"><stop offset=\"0.52\" stop-color=\"#000\" stop-opacity=\"0\"/><stop offset=\"1\" stop-color=\"#000\" stop-opacity=\"0.5\"/></radialGradient></defs>"
                        + "<rect x=\"-20\" y=\"-20\" width=\"360\" height=\"220\" fill=\"url(#f1)\"/><rect width=\"320\" height=\"180\" fill=\"url(#vg)\"/>";
                else if (tier == 2)
                {
                    body = "<defs><pattern id=\"sl\" width=\"3\" height=\"3\" patternUnits=\"userSpaceOnUse\"><rect width=\"3\" height=\"1\" fill=\"#000\" fill-opacity=\"0.2\"/></pattern><radialGradient id=\"ed\" cx=\"0.5\" cy=\"0.5\" r=\"0.62\"><stop offset=\"0.78\" stop-color=\"#000\" stop-opacity=\"0\"/><stop offset=\"1\" stop-color=\"#000\" stop-opacity=\"0.6\"/></radialGradient></defs>"
                        + "<rect width=\"320\" height=\"180\" fill=\"url(#sl)\"/><rect width=\"320\" height=\"180\" rx=\"10\" fill=\"url(#ed)\"/>";
                }
                else if (tier == 4) body = "<rect width=\"320\" height=\"10\" fill=\"#000\"/><rect y=\"170\" width=\"320\" height=\"10\" fill=\"#000\"/>";
                if (body == "") body = "<rect width=\"1\" height=\"1\" fill=\"none\"/>";
                _look.SetSvg($"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"320\" height=\"180\" viewBox=\"0 0 320 180\"><defs><clipPath id=\"cw\"><rect x=\"{N(x0)}\" y=\"{N(y0)}\" width=\"{N(ww)}\" height=\"{N(hh)}\"/></clipPath></defs><g clip-path=\"url(#cw)\">{body}</g></svg>", 320, 180, 0);
            }
            _look.Visible = op > 0.001; _look.Opacity = (float)op; _look.Order = ord + 3; _look.Transform = Frame * StageAffine();
            // the moving parts: quads in stage px (clipped to the window), soft-edged or solid
            var V = new List<Vector3>(); var UV = new List<Vector2>(); var C = new List<Color>(); var T = new List<int>();
            void Q(double x, double y, double qw, double qh, Color c, bool solid, double rot = 0, bool vsoft = false)
            {
                double cx = x + qw / 2, cy = y + qh / 2, ca = Math.Cos(rot), sa = Math.Sin(rot);
                Vec2 P(double dx, double dy) { double px = cx + dx * ca - dy * sa, py = cy + dx * sa + dy * ca; return Stage(Math.Max(x0, Math.Min(x0 + ww, px)), Math.Max(y0, Math.Min(y0 + hh, py))); }
                int n = V.Count; foreach (var pt in new[] { P(-qw / 2, -qh / 2), P(qw / 2, -qh / 2), P(qw / 2, qh / 2), P(-qw / 2, qh / 2) }) V.Add(_room.WorldFrame(pt.X, pt.Y));
                if (solid) for (int i = 0; i < 4; i++) UV.Add(new Vector2(0.5f, 0.5f));
                else if (vsoft) { UV.Add(new Vector2(0.5f, 1)); UV.Add(new Vector2(0.5f, 1)); UV.Add(new Vector2(0.5f, 0)); UV.Add(new Vector2(0.5f, 0)); }   // (soft top and bottom)
                else { UV.Add(new Vector2(0, 0.5f)); UV.Add(new Vector2(1, 0.5f)); UV.Add(new Vector2(1, 0.5f)); UV.Add(new Vector2(0, 0.5f)); }   // (soft left and right)
                for (int i = 0; i < 4; i++) C.Add(c); T.AddRange(new[] { n, n + 1, n + 2, n, n + 2, n + 3 });
            }
            float o = (float)op;
            if (tier <= 1)
            {
                if (now - _grainAt >= 83)
                {
                    _grainAt = now; for (int i = 0; i < _noisePx.Length; i++) { byte g = (byte)_r.Next(256); _noisePx[i] = new Color32(g, g, g, 255); }
                    _noise.SetPixels32(_noisePx); _noise.Apply(); _flick = 0.03 + _r.NextDouble() * 0.1;
                    for (int i = 0; i < 2; i++) _scratch[i] = _r.NextDouble() < 0.28 ? _r.NextDouble() * 320 : -1;
                }
                Q(0, 0, 320, 180, new Color(0, 0, 0, (float)_flick * o), true);
                foreach (var sx in _scratch) if (sx >= 0) Q(sx, 0, 1, 180, new Color(250 / 255f, 240 / 255f, 220 / 255f, 0.55f * o), true);
                // the grain (overlay at 0.3: here a grey veil of the noise)
                var gv = new[] { Stage(x0, y0), Stage(x0 + ww, y0), Stage(x0 + ww, y0 + hh), Stage(x0, y0 + hh) };
                _grain.Clear(); _grain.SetVertices(Array.ConvertAll(gv, v => _room.WorldFrame(v.X, v.Y)));
                _grain.SetUVs(0, new[] { new Vector2((float)_u0, (float)(1 - _v0)), new Vector2((float)_u1, (float)(1 - _v0)), new Vector2((float)_u1, (float)(1 - _v1)), new Vector2((float)_u0, (float)(1 - _v1)) });
                var gc = new Color(1, 1, 1, 0.12f * o); _grain.SetColors(new[] { gc, gc, gc, gc }); _grain.SetTriangles(new[] { 0, 1, 2, 0, 2, 3 }, 0); _grain.RecalculateBounds();
                _grainR.enabled = o > 0.001; _grainR.sortingOrder = ord + 4;
            }
            else _grainR.enabled = false;
            if (tier == 2) { double top = ((now / 6000) % 1) * 230 - 30; Q(0, top, 320, 26, new Color(1, 1, 1, 0.08f * o), false, 0, true); }
            if (tier >= 5)
            {
                double hue = (now / 20) % 360; var c1 = Color.HSVToRGB((float)(hue / 360), 0.9f, 1f); c1.a = 0.55f * o; var c2 = Color.HSVToRGB((float)(((hue + 120) % 360) / 360), 0.9f, 1f); c2.a = 0.6f * o;
                Q(0, -6, 320, 12, c1, false, 0, true); Q(0, 174, 320, 12, c1, false, 0, true); Q(-6, 0, 12, 180, c2, false); Q(314, 0, 12, 180, c2, false);
                double sl = ((now / 5000) % 1) * 520 - 100; Q(sl, -20, 60, 220, new Color(1, 1, 1, 0.14f * o), false, 18 * Math.PI / 180);
            }
            _fx.Clear(); _fx.SetVertices(V); _fx.SetUVs(0, UV); _fx.SetColors(C); _fx.SetTriangles(T, 0); _fx.RecalculateBounds(); _fxR.enabled = V.Count > 0; _fxR.sortingOrder = ord + 4;
        }

        // ---- the room dimmed, the screen's light ----
        void Dim((double dim, double pic, double[] light) look, double[] m, double w, double h, bool focus)
        {
            Vec2 P0(double x, double y) => new Vec2(m[0] * x + m[2] * y + m[4], m[1] * x + m[3] * y + m[5]);
            double cx = (P0(0, 0).X + P0(w, h).X) / 2, cy = (P0(0, 0).Y + P0(w, h).Y) / 2, qw = Math.Abs(P0(w, 0).X - P0(0, 0).X), Rr = Math.Max(qw, 80) * 1.4;
            string key = Math.Round(cx) + "," + Math.Round(cy) + "," + Math.Round(Rr);
            if (_dimKey != key)
            {
                _dimKey = key; double W = 852 + 120, H = 393 + 120, ox = cx + 60, oy = cy + 60;
                _dark.SetSvg($"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{W}\" height=\"{H}\" viewBox=\"0 0 {W} {H}\"><defs><radialGradient id=\"d\" gradientUnits=\"userSpaceOnUse\" cx=\"{ox:F0}\" cy=\"{oy:F0}\" r=\"{Math.Max(W, H):F0}\" gradientTransform=\"translate({ox:F0} {oy:F0}) scale(1 {H / W:F3}) translate({-ox:F0} {-oy:F0})\"><stop offset=\"0\" stop-color=\"#080512\" stop-opacity=\"0.5\"/><stop offset=\"0.7\" stop-color=\"#080512\" stop-opacity=\"0.88\"/></radialGradient></defs><rect width=\"{W}\" height=\"{H}\" fill=\"url(#d)\"/></svg>", (float)W, (float)H, 0);
                _spill.SetSvg($"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{W}\" height=\"{H}\" viewBox=\"0 0 {W} {H}\"><defs><radialGradient id=\"s\" gradientUnits=\"userSpaceOnUse\" cx=\"{ox:F0}\" cy=\"{oy:F0}\" r=\"{Rr:F0}\"><stop offset=\"0\" stop-color=\"#ffffff\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></radialGradient></defs><rect width=\"{W}\" height=\"{H}\" fill=\"url(#s)\"/></svg>", (float)W, (float)H, 0);
            }
            var k = _room.CamK; var f0 = FrameOf(-60, -60);
            var A = Frame * Affine.Translate(f0.X, f0.Y) * Affine.ScaleBy(k, k);
            _dark.Visible = _spill.Visible = look.dim > 0.001; _dark.Transform = A; _spill.Transform = A;
            _dark.Opacity = (float)look.dim; _spill.Opacity = (float)(look.dim * 0.3 * look.light[3] * look.pic);
            // full screen: the view behind the film darkens (rgba(0,0,0, 1.4 p))
            _back ??= UiPiece.Create(_room.transform, "movie backdrop", FocusOrder);
            if (focus) { if (_back.Width < 1) _back.SetSvg("<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"852\" height=\"393\" viewBox=\"0 0 852 393\"><rect x=\"-10\" y=\"-10\" width=\"872\" height=\"413\" fill=\"#000\"/></svg>", 852, 393, 0); _back.Visible = true; _back.Transform = Frame; _back.Opacity = (float)Math.Min(1, _sim.FzP * 1.4); }
            else _back.Visible = false;
        }

        // ---- the projector's beam: the player's centre (35 % down its box) to the screen's corners ----
        void Beam(Theater th, (double dim, double pic, double[] light) look, bool focus)
        {
            HouseRoomView.Piece pl = null; foreach (var p in _room.Pieces) if (p.Id == th.Player && p.Kind != "toy") { pl = p; break; }
            if (pl == null || focus || _sim.Show == null) { _beamR.enabled = false; return; }
            var b = pl.Box ?? pl.Region; double bx = b[0] + b[2] / 2, by = b[1] + b[3] * 0.35 - HouseFrame.BoxTop;
            var m = th.ScM; double w = th.ScW, h = th.ScH;
            var pts = new List<Vec2> { new Vec2(bx, by) }; foreach (var (x, y) in new[] { (0.0, 0.0), (w, 0.0), (w, h), (0.0, h) }) pts.Add(new Vec2(m[0] * x + m[2] * y + m[4], m[1] * x + m[3] * y + m[5]));
            var hull = Hull(pts); var cen = (pts[1] + pts[3]) * 0.5; var pv = new Vec2(bx, by); var d = cen - pv; double L2 = d.X * d.X + d.Y * d.Y;
            var SH = _sim.Show; double on = Math.Max(0, Math.Min(1, (SH.Age - 1.2 + 0.6) / 0.6)), opa = 0.32 * on * Math.Min(1, look.light[3] + 0.2) * (SH.Done ? 1 - Math.Max(0, Math.Min(1, SH.EndA / 0.6)) : 1);
            var V = new List<Vector3>(); var C = new List<Color>(); var UV = new List<Vector2>(); var T = new List<int>();
            foreach (var q in hull)
            {
                double t = L2 > 0 ? Math.Max(0, Math.Min(1, ((q.X - pv.X) * d.X + (q.Y - pv.Y) * d.Y) / L2)) : 0;
                V.Add(_room.World(q.X, q.Y)); UV.Add(new Vector2(0.5f, 0.5f));
                C.Add(Color.Lerp(new Color(1, 1, 1, 0.8f * (float)opa), new Color(0xd6 / 255f, 0xec / 255f, 1, 0.14f * (float)opa), (float)t));
            }
            for (int i = 1; i + 1 < hull.Count; i++) T.AddRange(new[] { 0, i, i + 1 });
            _beam.Clear(); _beam.SetVertices(V); _beam.SetUVs(0, UV); _beam.SetColors(C); _beam.SetTriangles(T, 0); _beam.RecalculateBounds();
            _beamR.enabled = opa > 0.001; _beamR.sortingOrder = Order + 1;
        }
        static List<Vec2> Hull(List<Vec2> P)
        {
            var p = new List<Vec2>(P); p.Sort((a, b) => a.X != b.X ? a.X.CompareTo(b.X) : a.Y.CompareTo(b.Y));
            double Cr(Vec2 o, Vec2 a, Vec2 b) => (a.X - o.X) * (b.Y - o.Y) - (a.Y - o.Y) * (b.X - o.X);
            var lo = new List<Vec2>(); foreach (var q in p) { while (lo.Count >= 2 && Cr(lo[lo.Count - 2], lo[lo.Count - 1], q) <= 0) lo.RemoveAt(lo.Count - 1); lo.Add(q); }
            var up = new List<Vec2>(); for (int i = p.Count - 1; i >= 0; i--) { var q = p[i]; while (up.Count >= 2 && Cr(up[up.Count - 2], up[up.Count - 1], q) <= 0) up.RemoveAt(up.Count - 1); up.Add(q); }
            lo.RemoveAt(lo.Count - 1); up.RemoveAt(up.Count - 1); lo.AddRange(up); return lo;
        }

        // ---- the player bar, the picker, full screen's close button ----
        static readonly TextStyle TtlSt = new TextStyle { Font = "Fredoka_600SemiBold", Size = 12, Color = "#5a3a1e" }, TmSt = new TextStyle { Font = "Fredoka_600SemiBold", Size = 10.5f, Color = "#8a5a2e" };
        const double BarW = 4 + 6 + 34 + 8 + 180 + 8 + 34 + 8 + 34 + 8 + 34 + 6, BarH = 4 + 10 + 34;
        double _barX, _barY, _barS; float _barOp;
        string Ic(string name) => (_icons.Str(name) ?? "").Replace("currentColor", "#3a1a5c");
        static string Inner(string svg, double x, double y, double size)
        {
            var m = System.Text.RegularExpressions.Regex.Match(svg ?? "", "viewBox=\"([^\"]+)\""); if (!m.Success) return "";
            var body = System.Text.RegularExpressions.Regex.Replace(svg, "^<svg[^>]*>|</svg>$", "");
            var attrs = System.Text.RegularExpressions.Regex.Match(svg, "^<svg([^>]*)>").Groups[1].Value; attrs = System.Text.RegularExpressions.Regex.Replace(attrs, "\\s(width|height|viewBox|xmlns)=\"[^\"]*\"", "");
            return $"<svg x=\"{x}\" y=\"{y}\" width=\"{size}\" height=\"{size}\" viewBox=\"{m.Groups[1].Value}\"{attrs}>{body}</svg>";
        }

        void Bar(double now, int ord)
        {
            var SH = _sim.Show; bool focus = _sim.FzP > 0;
            bool show = !focus || (_sim.FzP > 0.85 && (now - _sim.FzCtl < 2600 || SH.Pause || _sim.MenuOn));
            _barOp = !focus ? 1 : show ? 1 : 0;
            double mt = Math.Max(0, Math.Min(SH.Mv.Num("dur"), SH.Mt)), dur = SH.Mv.Num("dur");
            string ttl = SH.MsgT > 0 && SH.Msg != "" ? SH.Msg : SH.Mv.Str("title"), tm = T(mt) + " / " + T(dur), ic = SH.Pause ? "play" : "pause", fi = _sim.FzOn ? "shrink" : "full";
            int fill = (int)Math.Round(180 * mt / dur);
            string hb = HeldId, hbar = hb == "play" || hb == "list" || hb == "full" || hb == "stop" ? hb : "";   // (the held bar button: shrunk)
            string key = ttl + "|" + tm + "|" + fill + "|" + ic + "|" + fi + "|" + hbar;
            _bar ??= UiPiece.Create(_room.transform, "movie bar", ord + 10);
            if (_barKey != key)
            {
                _barKey = key; float W = (float)BarW, H = (float)BarH; var s = new UiSvg(W, H);
                s.Box(0, 0, W, H, new BoxStyle { Background = "#f6ead2", Radius = H / 2, BorderWidth = 2, BorderColor = "#c9ad86", Shadows = new[] { new Shadow("rgba(90,58,30,0.28)", 0, 3, 0) } });
                double x = 2 + 6; void Btn(string name, string id, bool main, double size) { bool pr = hbar == id; if (pr) s.Open(PressG(x + 17, 7 + 17)); s.Box((float)x, 7, 34, 34, new BoxStyle { Background = main ? "#e2b14a" : "#fbf3e3", Radius = 17, BorderWidth = 2, BorderColor = main ? "#8a6420" : "#c9ad86" }); s.Raw(Inner(Ic(name), x + 17 - size / 2, 7 + 17 - size / 2, size)); if (pr) s.Close(); x += 34 + 8; }
                Btn(ic, "play", true, 14);
                string t2 = ttl; float tmw = UiSvg.BoxWidth(tm, TmSt); while (t2.Length > 1 && UiSvg.BoxWidth(t2, TtlSt) > 180 - tmw - 6) t2 = t2.Substring(0, t2.Length - 2) + "\u2026";
                s.Text(t2, (float)x, 9, TtlSt); s.Text(tm, (float)(x + 180 - tmw), 10.5f, TmSt);
                s.Box((float)x, 30, 180, 7, new BoxStyle { Background = "#e2cfa8", Radius = 3.5f }); if (fill > 0) s.Box((float)x, 30, Math.Max(7, fill), 7, new BoxStyle { Background = "#8a6420", Radius = 3.5f });
                x += 180 + 8; Btn("list", "list", false, 14); Btn(fi, "full", false, 15); Btn("skip", "stop", false, 14);
                _bar.SetSvg(s.Markup, W, H, 8);
            }
            // in the room: centred at the bottom of the room (104 px up), with the camera; full screen: at the view's bottom
            if (!focus) { var c = FrameOf(426, 343 - 104 + BarH / 2); _barS = _room.CamK; _barX = c.X - BarW / 2 * _barS; _barY = c.Y - BarH / 2 * _barS; }
            else { _barS = 1; _barX = 426 - BarW / 2; _barY = 393 - 70; }
            _bar.Visible = _barOp > 0; _bar.Order = ord + 10; _bar.Opacity = _barOp; _bar.Transform = Frame * Affine.Translate(_barX, _barY) * Affine.ScaleBy(_barS, _barS);
            // the picker above the bar, right-aligned
            _menu ??= UiPiece.Create(_room.transform, "movie picker", ord + 11);
            if (_sim.MenuOn && _barOp > 0)
            {
                var rows = _sim.MovieMenu(); string hrow = hb != null && hb.StartsWith("row") ? hb : "";   // (the held row: shrunk)
                string mk = string.Join("|", rows.ConvertAll(r => r.mv.Str("id") + r.ok + r.cur + r.sub)) + "|" + hrow;
                double MH = 8 + 2 + 18 + rows.Count * (42 + 3) + 8;
                if (_menuKey != mk)
                {
                    _menuKey = mk; float W = 270, H = (float)MH; var s = new UiSvg(W, H);
                    s.Box(0, 0, W, H, new BoxStyle { Background = "#fbf3e3", Radius = 18, BorderWidth = 2, BorderColor = "#c9ad86", Shadows = new[] { new Shadow("rgba(90,58,30,0.25)", 0, 4, 0) } });
                    s.Text("Movies", 2 + 8 + 6, 2 + 8 + 2, new TextStyle { Font = "Fredoka_600SemiBold", Size = 12, Color = "#8a5a2e" });
                    double y = 2 + 8 + 18 + 3; int ri = 0;
                    foreach (var (mv, ok, cur, sub) in rows)
                    {
                        bool pr = hrow == "row" + ri++; if (pr) s.Open(PressG(10 + 125, y + 21));
                        s.Box(10, (float)y, 250, 42, new BoxStyle { Background = cur ? "#f3dca6" : ok ? "#ffffff" : "rgba(0,0,0,0)", Radius = 12, BorderWidth = 2, BorderColor = cur ? "#8a6420" : "rgba(0,0,0,0)" });
                        s.Box(10 + 11, (float)(y + 10), 22, 22, new BoxStyle { Background = ok ? "#e2b14a" : "#eadcc2", Radius = 11 });
                        var ns = new TextStyle { Font = "Fredoka_700Bold", Size = 11, Color = "#3a1a5c" }; string tn = HouseJson.JsString(mv["tier"]);
                        s.Text(tn, (float)(10 + 11 + 11 - UiSvg.BoxWidth(tn, ns) / 2), (float)(y + 21 - UiSvg.LineBox(ns) / 2), ns);
                        var a = new TextStyle { Font = "Fredoka_600SemiBold", Size = 12.5f, Color = ok ? "#3a1a5c" : "#9a8262" }; var b = new TextStyle { Font = "Fredoka_500Medium", Size = 10.5f, Color = ok ? "#8a5a2e" : "#a8916f" };
                        s.Text(mv.Str("title"), 10 + 11 + 22 + 8, (float)(y + 7), a); s.Text(sub, 10 + 11 + 22 + 8, (float)(y + 22), b);
                        if (pr) s.Close();
                        y += 42 + 3;
                    }
                    _menu.SetSvg(s.Markup, W, H, 8);
                }
                _menu.Visible = true; _menu.Order = ord + 11;
                _menu.Transform = Frame * Affine.Translate(_barX, _barY) * Affine.ScaleBy(_barS, _barS) * Affine.Translate(BarW - 270, BarH - 48 - MH);
            }
            else _menu.Visible = false;
            // full screen's close button (top right)
            _xb ??= UiPiece.Create(_room.transform, "movie close", FocusOrder + 12);
            if (focus && show)
            {
                if (_xb.Width < 1) { var s = new UiSvg(34, 34); s.Box(0, 0, 34, 34, new BoxStyle { Background = "#fbf3e3", Radius = 17, BorderWidth = 2, BorderColor = "#c9ad86" }); s.Raw(Inner(Ic("shrink"), 9.5, 9.5, 15)); _xb.SetSvg(s.Markup, 34, 34, 6); }
                _xb.Visible = true; _xb.Transform = Frame * Affine.Translate(852 - 14 - 34, 12) * (hb == "x" ? Affine.Translate(17, 17) * Affine.ScaleBy(0.92, 0.92) * Affine.Translate(-17, -17) : Affine.Identity);
            }
            else _xb.Visible = false;
        }
        static string T(double s) { int t = (int)Math.Floor(s); return (t / 60) + ":" + (t % 60).ToString("00"); }
        // a held control drawn in a picture: a <g>'s attributes shrinking what it holds to 92 % about (cx, cy)
        static string PressG(double cx, double cy) => $"transform=\"translate({HouseGeo.N(cx)} {HouseGeo.N(cy)}) scale(0.92) translate({HouseGeo.N(-cx)} {HouseGeo.N(-cy)})\"";

        /// <summary>Whether a frame point is on the player bar or the open picker.</summary>
        public bool Hits(double fx, double fy)
        {
            if (_sim.Show == null || _barOp <= 0) return false;
            double lx = (fx - _barX) / _barS, ly = (fy - _barY) / _barS;
            if (lx >= 0 && lx <= BarW && ly >= 0 && ly <= BarH) return true;
            if (_sim.MenuOn) { double MH = 8 + 2 + 18 + _sim.MovieMenu().Count * 45 + 8, my = ly - (BarH - 48 - MH), mx = lx - (BarW - 270); return mx >= 0 && mx <= 270 && my >= 0 && my <= MH; }
            return false;
        }

        /// <summary>A tap on the theater's controls (frame px): true when it was theirs (in full screen every tap is).</summary>
        public bool Tap(double fx, double fy, double now)
        {
            var SH = _sim.Show; if (SH == null) return false;
            bool focus = _sim.FzP > 0;
            if (focus && fx >= 852 - 48 && fy <= 46 && _xb != null && _xb.Visible) { _sim.Focus(false, now); return true; }
            if (_barOp > 0)
            {
                double lx = (fx - _barX) / _barS, ly = (fy - _barY) / _barS;
                if (_sim.MenuOn && _menu.Visible)
                {
                    double my = ly - (BarH - 48 - (8 + 2 + 18 + _sim.MovieMenu().Count * 45 + 8)), mx = lx - (BarW - 270);
                    if (mx >= 0 && mx <= 270 && my >= 0)
                    {
                        int i = (int)Math.Floor((my - (2 + 8 + 18 + 3)) / 45); var rows = _sim.MovieMenu();
                        if (i >= 0 && i < rows.Count && rows[i].ok && !rows[i].cur) _sim.PickMovie(rows[i].mv.Str("id"));
                        _sim.FzCtl = now; return true;
                    }
                }
                if (lx >= 0 && lx <= BarW && ly >= 0 && ly <= BarH)
                {
                    _sim.FzCtl = now; double x = lx - 8;
                    if (x >= 0 && x < 34) _sim.TogglePause();
                    else if (x >= 34 + 8 + 180 + 8 && x < 34 + 8 + 180 + 8 + 34) { _sim.MenuOn = !_sim.MenuOn; _sim.Bumped(); }
                    else if (x >= 34 + 8 + 180 + 8 + 42 && x < 34 + 8 + 180 + 8 + 42 + 34) _sim.Focus(!_sim.FzOn, now);
                    else if (x >= 34 + 8 + 180 + 8 + 84 && x < 34 + 8 + 180 + 8 + 84 + 34) _sim.StopShow();
                    return true;
                }
            }
            if (focus) { _sim.FzCtl = now; _sim.MenuOn = false; return true; }   // (a tap on the film shows the controls)
            if (_sim.MenuOn) { _sim.MenuOn = false; return true; }
            return false;
        }

        // ---- the press (the menu's Level crest): the control a press began on shrinks to 92 % about its centre while the
        // finger is on it: "play", "list", "full", "stop" (the bar's, redrawn), "row<i>" (the picker's, redrawn), "x" (full
        // screen's close, scaled). The hit areas never change, so Tap is unchanged.
        string _held; bool _heldOn;
        string HeldId => _heldOn ? _held : null;
        // the control a tap at (fx, fy) would act on (Tap's tests, without acting), or null
        string Under(double fx, double fy)
        {
            if (_sim.Show == null) return null;
            bool focus = _sim.FzP > 0;
            if (focus && fx >= 852 - 48 && fy <= 46 && _xb != null && _xb.Visible) return "x";
            if (_barOp <= 0) return null;
            double lx = (fx - _barX) / _barS, ly = (fy - _barY) / _barS;
            if (_sim.MenuOn && _menu != null && _menu.Visible)
            {
                double my = ly - (BarH - 48 - (8 + 2 + 18 + _sim.MovieMenu().Count * 45 + 8)), mx = lx - (BarW - 270);
                if (mx >= 0 && mx <= 270 && my >= 0)
                {
                    int i = (int)Math.Floor((my - (2 + 8 + 18 + 3)) / 45); var rows = _sim.MovieMenu();
                    return i >= 0 && i < rows.Count && rows[i].ok && !rows[i].cur ? "row" + i : null;
                }
            }
            if (lx >= 0 && lx <= BarW && ly >= 0 && ly <= BarH)
            {
                double x = lx - 8, b = 34 + 8 + 180 + 8;
                if (x >= 0 && x < 34) return "play";
                if (x >= b && x < b + 34) return "list";
                if (x >= b + 42 && x < b + 42 + 34) return "full";
                if (x >= b + 84 && x < b + 84 + 34) return "stop";
            }
            return null;
        }
        /// <summary>A press began at (fx, fy) (frame px: the same coordinates Tap gets): the control under it (the one Tap would act on) is held.</summary>
        public void PressDown(double fx, double fy, double now) { _held = Under(fx, fy); _heldOn = _held != null; }
        /// <summary>The finger moved: the control is drawn held only while the finger is still on it.</summary>
        public void PressMove(double fx, double fy) { if (_held != null) _heldOn = Under(fx, fy) == _held; }
        /// <summary>Released or cancelled (a drag): nothing is held.</summary>
        public void PressUp() { _held = null; _heldOn = false; }

        public void Destroy()
        {
            if (_go != null) Object.Destroy(_go); if (_rt != null) _rt.Release(); if (_mat != null) Object.Destroy(_mat);
            foreach (var u in new[] { _dark, _spill, _look, _bar, _menu, _back, _xb }) if (u != null) Object.Destroy(u.gameObject);
            foreach (var r in new Renderer[] { _fxR, _grainR, _beamR }) if (r != null) Object.Destroy(r.gameObject);
            if (_groove != null) Object.Destroy(_groove.gameObject); if (_tv != null) Object.Destroy(_tv.gameObject);
        }
    }
}
