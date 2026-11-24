// The HUD's numbers, drawn live (Menu/HudArt.cs) over the exported pieces: the coin and gem pills with the player's
// coins and gems (the row reflows from the right edge as a number grows, and the coin / gem pictures move with their
// pills), and the crest's level number and XP ring (the ring sweeps in the first time, as the app's SMIL does). They
// follow the HUD's fade, and the crest's number follows its press and its flourish (sqFloat) as the crest's own
// <svg> does in the app. Values: SetHud (MenuScreen gives the signed-in player's; until then the exported ones).
using SquishSquad.Ui;
using SquishSquad.Vector;
using UnityEngine;

namespace SquishSquad.Menu
{
    public sealed partial class MenuView
    {
        HudValues _hud = HudValues.Baked;
        UiPiece _coinsPill, _gemsPill, _crestText;
        PieceView _coinsIcon, _gemsIcon, _crest;
        float _hudAlpha = 1;
        string _coinsShown, _gemsShown, _crestShown;
        float _ringFrom = -1;   // ms the ring's sweep started (-1: none)
        static bool _ringShown; // M.crest's ringShown: the sweep plays once per run

        public HudValues Hud => _hud;

        void BuildHud()
        {
            var ht = _layout.hudText;
            if (ht == null || ht.pills == null) return;   // an export from before the drawn HUD: the pictures as they are
            UiPiece.PxPerDp = _h / _layout.reference.dp[1];
            _coinsIcon = _pieces.Find(p => p.Data.id == "pill-coins");
            _gemsIcon = _pieces.Find(p => p.Data.id == "pill-gems");
            _crest = _pieces.Find(p => p.Data.id == "crest");
            int below = HudOrder - 1;   // the pills under their coin / gem pictures, over the weather
            _coinsPill = UiPiece.Create(_root, "coins pill", below);
            _gemsPill = UiPiece.Create(_root, "gems pill", below);
            if (_crest != null && ht.crest != null && ht.crest.svg != null && ht.crest.svg.Length == 4)
                _crestText = UiPiece.Create(_crest.Pivot, "crest number", _crest.Order + 1);
            ApplyHud(0);
        }

        /// <summary>Shows these numbers (from now, `nowMs` on the view's clock: the ring's first sweep starts there).</summary>
        public void SetHud(HudValues v, float nowMs)
        {
            if (v == null || v.SameAs(_hud)) return;
            bool firstXp = v.HasXp && !_ringShown;
            _hud = v;
            if (firstXp) { _ringShown = true; _ringFrom = nowMs; }
            ApplyHud(nowMs);
        }

        // reference px of a HUD piece -> this screen's px (the piece's screen edge, as MenuView.Map)
        Vector2 HudMap(string id, Vector2 refPx)
        {
            var p = System.Array.Find(_layout.hud, x => x.id == id);
            return p != null ? Map(p, refPx) : refPx * _f;
        }

        void ApplyHud(float nowMs)
        {
            var ht = _layout.hudText;
            if (_coinsPill == null || ht == null) return;
            float K = ht.k > 0 ? ht.k : HudArt.K, dpr = _layout.reference.dpr, ppd = UiPiece.PxPerDp;
            string coins = HudValues.Fmt(_hud.Coins), gems = HudValues.Fmt(_hud.Gems);
            var (cx, cw, gx, gw, y) = HudArt.PillRow(ht.hudWidth, coins, gems);
            foreach (var (piece, icon, id, text, x, w) in new[] { (_coinsPill, _coinsIcon, "pill-coins", coins, cx, cw), (_gemsPill, _gemsIcon, "pill-gems", gems, gx, gw) })
            {
                // the pill on the reference screen (its own HUD px x K = dp, x dpr = reference px), then on this one
                var refPos = new Vector2(x * K * dpr, y * K * dpr);
                var at = HudMap(id, refPos);
                if (id == "pill-coins" ? _coinsShown != text : _gemsShown != text)
                {
                    var svg = HudArt.Pill(text, K);
                    piece.SetSvg(svg.Markup, svg.W, svg.H, 20);   // (its soft shadow reaches 18 px below)
                    if (id == "pill-coins") _coinsShown = text; else _gemsShown = text;
                }
                piece.Transform = Affine.Translate(at.x / ppd, at.y / ppd);
                piece.Apply();
                var refPill = System.Array.Find(ht.pills, p => p.id == id);
                if (icon != null && refPill != null)
                {
                    // the picture keeps its place from the pill's left edge; the tap box is the pill
                    var was = HudMap(id, new Vector2(refPill.pill[0], refPill.pill[1]));
                    icon.Offset(new Vector2(at.x - was.x, 0));
                    icon.Hit = new Rect(at.x, at.y, w * K * dpr * _f, HudArt.PillH * K * dpr * _f);
                }
            }
            TickHud(nowMs);
        }

        // the crest's number and ring: the ring's sweep, the crest's flourish (its float) and press, the HUD's fade
        void TickHud(float ms)
        {
            if (_coinsPill == null) return;
            _coinsPill.Opacity = _gemsPill.Opacity = _hudAlpha;
            _coinsPill.Apply(); _gemsPill.Apply();
            if (_crestText == null) return;
            var c = _layout.hudText.crest;
            float ppd = UiPiece.PxPerDp, dpr = _layout.reference.dpr;
            float s = Mathf.Min(c.svg[2] / 120f, c.svg[3] / 104f);   // reference px per viewBox unit (meet)
            var origin = HudMap("crest", new Vector2(c.svg[0] + (c.svg[2] - 120 * s) / 2, c.svg[1] + (c.svg[3] - 104 * s) / 2));
            double f = _hud.Need > 0 ? System.Math.Min(1, _hud.Into / _hud.Need) : 0;
            double shown = HudArt.RingAt(f, _ringFrom < 0 ? 0 : ms - _ringFrom, _ringFrom >= 0);
            if (_ringFrom >= 0 && ms - _ringFrom > 1700) _ringFrom = -1;
            string key = _hud.Level + "|" + _hud.HasXp + "|" + shown.ToString("0.000");
            if (key != _crestShown)
            {
                var svg = HudArt.CrestText(_hud.Level, _hud.HasXp, shown, s * _f / ppd);
                _crestText.SetSvg(svg.Markup, svg.W, svg.H, 4);
                _crestShown = key;
            }
            // sqFloat while the crest flourishes (not while it's held), about 50 % 62 % of .sq-cin
            var fl = _crest.Data.flourish;
            float dy = 0, sc = 1;
            if (fl != null && _crest.Data.hasFlourish && !_crest.Pressed)
            {
                float phase = ms - fl.every - fl.delay;
                if (phase >= 0) { var (d, k) = HudArt.Float(Mathf.Repeat(phase, fl.every)); dy = d * HudArt.K * dpr * _f / ppd; sc = k; }
            }
            var o = HudMap("crest", new Vector2(c.cin[0] + c.cin[2] * 0.5f, c.cin[1] + c.cin[3] * 0.62f)) / ppd;
            var pivot = _crest.PivotPx / ppd;   // the piece sits in the crest's press pivot (it scales with the press)
            var m = Affine.Translate(-pivot.x, -pivot.y) * Affine.Translate(o.x, o.y + dy) * Affine.ScaleBy(sc, sc) * Affine.Translate(-o.x, -o.y)
                    * Affine.Translate(origin.x / ppd, origin.y / ppd);
            _crestText.Transform = m;
            _crestText.Opacity = _hudAlpha;
            _crestText.Apply();
        }

        void DisposeHud()
        {
            foreach (var p in new[] { _coinsPill, _gemsPill, _crestText }) if (p != null) Kill(p.gameObject);
            _coinsPill = _gemsPill = _crestText = null;
        }
    }
}
