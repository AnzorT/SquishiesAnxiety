// The fail card's character, every game's (Squish Hop's STUCK!, src/hop/Cards.js SadSquishy; since 2026-11-26, the
// user: Hop's popups for all the mini games): a 150 x 128 box, the character's whole body 84 dp wide standing 6 dp above
// its bottom, centred. Its cut-out first; once its rig has drawn (the host: Ui/Cards/CardPieces, Squishdoku's screen,
// Creatures/ResultRig), the live character in its place, as the app's rig crying over the cut-out: the result page's
// sigh and then its sad hold (result.html resMiss → resSad). The cut-out stays when the rig can't run.
using System;
using SquishSquad.Vector;

namespace SquishSquad.Ui.Cards
{
    public sealed class SadBodyItem : CardItem
    {
        /// <summary>A cut-out (a Resources path, Stack/art/...) → its creature's key, height / width and where the body sits
        /// in it (left, top, right, bottom fractions): Resources/Hop/hop.json's cast, set by the host (CardPieces.Init).</summary>
        public static Func<string, (string key, float ar, float[] box)?> OfPicture;

        const float BodyW = 84, Feet = 6;
        readonly string _picture;
        readonly CardLayer _cut;
        string _key;
        float _ar = 1;
        float[] _box = { 0, 0, 1, 1 };
        CardLayer _rig;
        CardCreature _c;

        /// <summary>`picture`: the character's cut-out (a Resources path), or null: an empty box.</summary>
        public SadBodyItem(string picture)
        {
            _picture = picture;
            _cut = Layer("sad squishy");
            var of = picture != null ? OfPicture?.Invoke(picture) : null;
            if (of != null) { _key = of.Value.key; _ar = of.Value.ar; if (of.Value.box != null && of.Value.box.Length == 4) _box = of.Value.box; }
        }

        public override bool IsStatic => false;

        public override void Measure(float colW)
        {
            W = 150; H = 128;
            var s = new UiSvg(W, H);
            if (_picture != null)
            {
                float sw = BodyW / (_box[2] - _box[0]), sh = sw * _ar, bh = sw * _ar * (_box[3] - _box[1]);
                float bx = (W - BodyW) / 2, by = H - Feet - bh;
                s.Image(_picture, bx - _box[0] * sw, by - _box[1] * sh, sw, sh, "none");
            }
            _cut.Set(s.Markup, W, H, 2);
        }

        public override void Mount()
        {
            base.Mount();
            if (_rig != null || string.IsNullOrEmpty(_key) || TrioItem.LiveFor == null || !TrioItem.LiveFor(new[] { _key })) return;
            _c = new CardCreature { Key = _key, State = "resMiss", Clip = "miss", GreyAbove = -1 };
            _rig = new CardLayer("sad creature") { Creature = _c, Opacity = 0 };
            _rig.Set("<svg xmlns=\"http://www.w3.org/2000/svg\" width=\"100\" height=\"100\"/>", 100, 100, 0);
            Layers.Add(_rig);
        }

        public override void Unmount()
        {
            base.Unmount();
            if (_rig == null) return;
            Layers.Remove(_rig);
            _rig = null; _c = null;
        }

        public override void Place(Affine card, float opacity)
        {
            var (m, o) = Box(card, opacity);
            var b = _c != null && !_c.Failed ? _c.Body : null;
            _cut.Transform = m;
            _cut.Opacity = b != null ? 0 : o;
            if (_rig == null) return;
            if (b == null || b.Bw <= 0 || b.Bh <= 0) { _rig.Opacity = 0; return; }
            // as big as the cut-out's body (84 dp wide), no taller than the box; its feet where the cut-out's stand
            double k = Math.Min(BodyW / b.Bw, (H - Feet - 4) / b.Bh);
            _c.Unit = (float)k;
            _rig.Transform = m * Affine.Translate(W / 2 - b.Cx * k, H - Feet - b.Gy * k) * Affine.ScaleBy(k, k);
            _rig.Opacity = o;
        }
    }
}
