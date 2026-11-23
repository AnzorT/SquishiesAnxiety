// The home theater's picture and the house's music (HOUSE_PORT_PLAN.md stage 9): the show's movie
// (StreamingAssets/Movies/<id>.mp4, tools/unity/house/export-movies.mjs) played by a VideoPlayer into a texture on the
// screen's quad (the theater's matrix, the 320 x 180 film covering the screen's box, fading in as the page's film
// does), kept at the show's time (HouseMovie.cs), paused with it; the room dimmed round it (movie-night.js's dim: a
// dark ellipse and the screen's light spilling out, the light's colour and level from the movie); and the loops: the
// speakers' groove while they play and no show is on, the TV's channel while a TV is on with speakers in the room.
// Sounds follow the app's sound-effects setting. Not yet: the projector's beam, the speakers' bounce and notes.
using System;
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
        GameObject _go; VideoPlayer _vp; RenderTexture _rt; Mesh _mesh; Material _mat; MeshRenderer _mr;
        UiPiece _dark, _spill; string _dimKey;
        AudioSource _groove, _tv; int _tvCh;
        string _loaded;
        const int Order = 2000 + 880 * 4;   // (movie-night's layer over the room's pieces)

        public HouseMovieView(HouseRoomView room, HouseCreatures sim, float screenK) { _room = room; _sim = sim; _k = screenK; }

        AudioSource Src(string name, string clip)
        {
            var go = new GameObject(name); go.transform.SetParent(_room.transform, false);
            var a = go.AddComponent<AudioSource>(); a.clip = Resources.Load<AudioClip>("House/audio/" + clip); a.loop = true; a.playOnAwake = false; return a;
        }

        public void Update(double now)
        {
            bool sound = SquishSquad.Audio.Sfx.EffectsOn;
            // the loops: the groove (speakers playing, no show), the TV's channel (on, with speakers)
            bool jam = _sim.Jams.Count > 0 && _sim.Show == null && sound && _sim.S.Cur != "dance";   // (musicSync: the Dance Club plays its own track)
            _groove ??= Src("groove", "groove");
            if (jam && !_groove.isPlaying) _groove.Play(); else if (!jam && _groove.isPlaying) _groove.Stop();
            int ch = 0; if (sound && _sim.SpkIn()) foreach (var kv in _sim.Rst) if (kv.Value.Ch > 0 && IsTv(kv.Key)) { ch = (int)kv.Value.Ch; break; }
            if (ch != _tvCh) { _tvCh = ch; _tv ??= Src("tv", "tv1"); _tv.Stop(); if (ch > 0) { _tv.clip = Resources.Load<AudioClip>("House/audio/tv" + ch); _tv.volume = 1; _tv.Play(); } }
            Show(now, sound);
        }

        bool IsTv(string id) { foreach (var it in _sim.S.H.Obj("rooms")?[_sim.S.Cur] as System.Collections.Generic.List<object> ?? new System.Collections.Generic.List<object>()) if (it is JObj j && j.Str("id") == id) { var r = _sim.S.RowOf(_sim.S.D.CatOf(j.Str("t"))); return r != null && HouseSave.RoleOf(r) == "tv"; } return false; }

        void Show(double now, bool sound)
        {
            var SH = _sim.Show; var th = _sim.Th;
            if (SH == null || th == null || th.ScM == null)
            {
                if (_vp != null && _vp.isPlaying) _vp.Stop();
                if (_mr != null) _mr.enabled = false; if (_dark != null) { _dark.Visible = false; _spill.Visible = false; }
                _loaded = null; return;
            }
            var look = _sim.ShowLook();
            // the video
            if (_go == null)
            {
                _go = new GameObject("movie"); _go.transform.SetParent(_room.transform, false);
                _rt = new RenderTexture(480, 270, 0); _vp = _go.AddComponent<VideoPlayer>(); _vp.playOnAwake = false; _vp.isLooping = false;
                _vp.renderMode = VideoRenderMode.RenderTexture; _vp.targetTexture = _rt; _vp.audioOutputMode = VideoAudioOutputMode.Direct;
                _mesh = new Mesh { name = "movie quad" }; _go.AddComponent<MeshFilter>().sharedMesh = _mesh; _mr = _go.AddComponent<MeshRenderer>();
                _mat = new Material(Shader.Find("Sprites/Default")) { mainTexture = _rt }; _mr.sharedMaterial = _mat; _mr.sortingOrder = Order + 2;
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
            // the quad: the screen's box (w x h, matrix m) in the room, the film covering it (centred, clipped)
            double[] m = th.ScM; double w = th.ScW, h = th.ScH, s = Math.Max(w / 320, h / 180), uw = w / (320 * s), vh = h / (180 * s);
            Vector3 P(double x, double y) => _room.World(m[0] * x + m[2] * y + m[4], m[1] * x + m[3] * y + m[5]);
            _mesh.SetVertices(new[] { P(0, 0), P(w, 0), P(w, h), P(0, h) });
            float u0 = (float)((1 - uw) / 2), u1 = (float)((1 + uw) / 2), v0 = (float)((1 - vh) / 2), v1 = (float)((1 + vh) / 2);
            _mesh.SetUVs(0, new[] { new Vector2(u0, v1), new Vector2(u1, v1), new Vector2(u1, v0), new Vector2(u0, v0) });
            var col = new Color(1, 1, 1, (float)look.pic); _mesh.SetColors(new[] { col, col, col, col });
            _mesh.SetTriangles(new[] { 0, 1, 2, 0, 2, 3 }, 0); _mesh.RecalculateBounds(); _mr.enabled = look.pic > 0.001;
            // the dim: a dark ellipse round the screen's centre, its light spilling out (radius 1.4x its width, at least 80)
            double cx = (P0(m, 0, 0).x + P0(m, w, h).x) / 2, cy = (P0(m, 0, 0).y + P0(m, w, h).y) / 2, qw = Math.Abs(P0(m, w, 0).x - P0(m, 0, 0).x), R = Math.Max(qw, 80) * 1.4;
            string key = Math.Round(cx) + "," + Math.Round(cy) + "," + Math.Round(R);
            if (_dark == null) { _dark = UiPiece.Create(_room.transform, "movie dim", Order); _spill = UiPiece.Create(_room.transform, "movie light", Order + 1); }
            if (_dimKey != key)
            {
                _dimKey = key; double W = 852 + 120, H = 393 + 120, ox = cx + 60, oy = cy + 60;
                _dark.SetSvg($"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{W}\" height=\"{H}\" viewBox=\"0 0 {W} {H}\"><defs><radialGradient id=\"d\" gradientUnits=\"userSpaceOnUse\" cx=\"{ox:F0}\" cy=\"{oy:F0}\" r=\"{Math.Max(W, H):F0}\" gradientTransform=\"translate({ox:F0} {oy:F0}) scale(1 {H / W:F3}) translate({-ox:F0} {-oy:F0})\"><stop offset=\"0\" stop-color=\"#080512\" stop-opacity=\"0.5\"/><stop offset=\"0.7\" stop-color=\"#080512\" stop-opacity=\"0.88\"/></radialGradient></defs><rect width=\"{W}\" height=\"{H}\" fill=\"url(#d)\"/></svg>", (float)W, (float)H, 0);
                _spill.SetSvg($"<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"{W}\" height=\"{H}\" viewBox=\"0 0 {W} {H}\"><defs><radialGradient id=\"s\" gradientUnits=\"userSpaceOnUse\" cx=\"{ox:F0}\" cy=\"{oy:F0}\" r=\"{R:F0}\"><stop offset=\"0\" stop-color=\"#ffffff\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></radialGradient></defs><rect width=\"{W}\" height=\"{H}\" fill=\"url(#s)\"/></svg>", (float)W, (float)H, 0);
            }
            // (the room's box px -> the frame at the camera's zoom, as the pieces: -60 px bleed round the room)
            var k = _room.CamK; var f0 = HouseCamera.ToFrame(-60, -60, k);
            var A = Affine.ScaleBy(_k / UiPiece.PxPerDp, _k / UiPiece.PxPerDp) * Affine.Translate(f0.x, f0.y) * Affine.ScaleBy(k, k);
            _dark.Visible = _spill.Visible = look.dim > 0.001; _dark.Transform = A; _spill.Transform = A;
            _dark.Opacity = (float)look.dim; _spill.Opacity = (float)(look.dim * 0.3 * look.light[3] * look.pic);
        }
        static (double x, double y) P0(double[] m, double x, double y) => (m[0] * x + m[2] * y + m[4], m[1] * x + m[3] * y + m[5]);

        public void Destroy()
        {
            if (_go != null) Object.Destroy(_go); if (_rt != null) _rt.Release(); if (_mat != null) Object.Destroy(_mat);
            if (_dark != null) Object.Destroy(_dark.gameObject); if (_spill != null) Object.Destroy(_spill.gameObject);
            if (_groove != null) Object.Destroy(_groove.gameObject); if (_tv != null) Object.Destroy(_tv.gameObject);
        }
    }
}
