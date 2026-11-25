// A whole screen's placeholder while a game opened over the menu is built (develop's src/components/ScreenBones.js, in
// App.js's WhenScreenReady): the screen's background (the games' warm page, or the planks: Squishdoku), the back orb's
// and the title's spots in the header (64 dp: a 40 dp circle where the back orb is, a 220 x 30 bar where the hubs'
// centred title is; the app's sits next to the orb), and the view's
// bones of `kind` under it ('hub', 'map', 'game', 'list': Bones.Layout), all in the wood look with the shine sweeping
// across them. Menu/MenuScreen.cs shows it the frame the game is asked for, builds the game under it the next frame,
// then fades it out over the game in 160 ms (Reveal: ease-out quad). No UnityEngine here, and nothing of the screens'
// kit: the caller hands it the background's picture (Kit.PageBg / WoodBg) and shows the pieces.
using System;
using System.Collections.Generic;
using SquishSquad.Vector;

namespace SquishSquad.Games.Shared
{
    public sealed class ScreenBones
    {
        /// <summary>One piece: its SVG (W x H dp), where it goes (dp), its opacity.</summary>
        public struct Piece { public string Id, Svg; public float W, H, Opacity; public Affine Transform; }

        public const double FADE_MS = 160;
        const float HEADER = 64;
        readonly string _kind, _bgSvg;
        readonly float _w, _h;
        double _fadeFrom = -1;

        /// <summary>`kind`: the view's bones; `background`: the screen's background, wDp x hDp (the warm page or the wood).</summary>
        public ScreenBones(string kind, string background, float wDp, float hDp) { _kind = kind; _bgSvg = background; _w = wDp; _h = hDp; }

        /// <summary>The game is built: fade out from `nowMs`.</summary>
        public void Reveal(double nowMs) { if (_fadeFrom < 0) _fadeFrom = nowMs; }
        public bool Revealing => _fadeFrom >= 0;
        public bool Done(double nowMs) => _fadeFrom >= 0 && nowMs - _fadeFrom >= FADE_MS;

        public float Opacity(double nowMs)
        {
            if (_fadeFrom < 0) return 1;
            double t = Math.Min(1, Math.Max(0, (nowMs - _fadeFrom) / FADE_MS));
            return (float)((1 - t) * (1 - t));   // (the content fades in out(quad): the bones over it the other way)
        }

        public List<Piece> Pieces(double nowMs)
        {
            float op = Opacity(nowMs);
            var list = new List<Piece>();
            if (_bgSvg != null) list.Add(new Piece { Id = "bones-bg", Svg = _bgSvg, W = _w, H = _h, Opacity = op, Transform = Affine.Identity });
            // where the hubs have them (Unity's own, 2026-11-25, the user: the app puts the title's spot next to the back orb,
            // but the hubs' title is in the middle): the back orb's 40 dp circle at (14, 6), the title's 220 x 30 bar
            // centred across the top, its middle 27 dp down
            var head = new List<Bones.Box> { new Bones.Box(14, 6, 40, 40, 20), new Bones.Box(_w / 2 - 110, 27 - 15, 220, 30, 15) };
            list.Add(new Piece { Id = "bones-head", Svg = Bones.Markup(head, _w, HEADER, _w), W = _w, H = HEADER, Opacity = op, Transform = Affine.Identity });
            float vh = _h - HEADER;
            list.Add(new Piece { Id = "bones-view", Svg = Bones.Markup(_kind, _w, vh, _w), W = _w, H = vh, Opacity = op, Transform = Affine.Translate(0, HEADER) });
            return list;
        }
    }
}
