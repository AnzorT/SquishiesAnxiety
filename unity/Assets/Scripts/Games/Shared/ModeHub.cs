// A game's hub in the new design (src/squishdoku/Hub.js GameHub: Squish Stack's, Squish Sort's and Squish Hop's front
// page, 2026-11-16, the user: "the same thing" as Squishdoku's): the title at the top (popping in, then rocking),
// REGULAR MODE and BLITZ MODE side by side in the middle as wood plaques tapped as a whole (the mode's name in the menu's
// lettering, the game's picture in a gold-ringed window, then how far through the levels / the most cleared in one Blitz
// run), HOW TO PLAY with a ? under them; each slides in after its delay. The pieces are Squishdoku's hub's (the app
// reuses them: ModePanel, RulesButton; tools/unity/export-squishdoku.mjs, Resources/Squishdoku) with the game's own
// pictures (Resources/<Game>/mode-regular, mode-blitz: tools/unity/export-<game>.mjs); the title, the progress and the
// numbers are drawn here. It sits under the screen's header (48 dp, the back orb).
using System;
using System.Collections.Generic;
using SquishSquad.Audio;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;

namespace SquishSquad.Games.Shared
{
    public sealed class ModeHub : Hub
    {
        // Squishdoku's hub's sizes (SdHub): a mode panel, the gap between them, HOW TO PLAY and its ring
        const float CardW = 372, CardH = 232, CardGap = 22, RulesW = 161.4375f, RulesH = 50, RulesRingH = 45;
        // what's on a mode panel (from its top-left): the info row (12, 196) 348 x 24, its track 14 tall
        const float InfoX = 12, InfoY = 196, InfoW = 348, InfoH = 24;
        const string Display = "Fredoka_700Bold", INK = "#5b3418";

        readonly string _title, _picDir;
        readonly int _lv, _done, _total, _top;
        readonly Action _onRegular, _onBlitz, _onRules;
        float _w, _top0, _h;
        readonly CardArt.Title _t;
        readonly PopIn _pop = new PopIn(60, 0.3, -10);
        readonly Rock _rock = new Rock(2, 3400);
        readonly SlideIn _slideR = new SlideIn(300, 50), _slideB = new SlideIn(420, 50), _slideQ = new SlideIn(600, 30);
        HubButton _regular, _blitz, _rules;
        (string svg, float w, float h) _letR, _letB;

        /// <summary>`picDir`: the Resources folder holding the game's mode-regular / mode-blitz pictures ("Stack").
        /// `lv`, `done`, `total`: REGULAR's line (the bar at done / total, "lv/total"); `top`: BLITZ's BEST.</summary>
        public ModeHub(string title, string picDir, int lv, int done, int total, int top, Action onRegular, Action onBlitz, Action onRules)
        {
            _title = title; _picDir = picDir; _lv = lv; _done = done; _total = total; _top = top;
            _onRegular = onRegular; _onBlitz = onBlitz; _onRules = onRules;
            _t = new CardArt.Title(title, 34, "gold");
        }

        public override IEnumerable<HubButton> Buttons { get { yield return _regular; yield return _blitz; yield return _rules; } }

        // ---- where things are (Hub.js wPage: the title's 30 dp box 40 dp up into the header; the cards and HOW TO PLAY
        // spread with the space left, 12 dp clear of the bottom) --------------------------------------------------------------
        float Gap => (_h - 12 - (-40 + 30 + CardH + RulesH)) / 2;
        float CardsY => _top0 - 10 + Gap;
        float CardsX => Card.Snap((_w - (2 * CardW + CardGap)) / 2);
        float RulesX => Card.Snap((_w - RulesW) / 2);
        float RulesY => CardsY + CardH + Gap;

        public override void Build(float w, float top, float h)
        {
            _w = w; _top0 = top; _h = h;
            _regular = HubButton.Area("hub regular", CardW, CardH, () => { Snd.Play("sd_select"); _onRegular?.Invoke(); });
            _blitz = HubButton.Area("hub blitz", CardW, CardH, () => { Snd.Play("sd_select"); _onBlitz?.Invoke(); });
            _letR = RoyalLettering.Draw("Regular Mode", 22);
            _letB = RoyalLettering.Draw("Blitz Mode", 22);
            _rules = HubButton.FromXml("hub rules", "Squishdoku/rules-lip", "Squishdoku/rules-face", RulesW, RulesRingH, () => { Snd.Play("sd_mode"); _onRules?.Invoke(); });
        }

        public override void Mount()
        {
            _pop.Trigger(); _rock.Mount();
            _slideR.Trigger(); _slideB.Trigger(); _slideQ.Trigger();
        }

        public override void Unmount() { _pop.Stop(); _rock.Unmount(); _slideR.Stop(); _slideB.Stop(); _slideQ.Stop(); }

        static readonly TextStyle Info = new TextStyle { Font = Display, Size = 16, Color = "#ffffff", Shadows = new[] { new Shadow(INK, 0, 1.5f, 1.5f) } };
        static readonly TextStyle InfoCenter = new TextStyle { Font = Display, Size = 18, LetterSpacing = 0.6f, Color = "#ffffff", Shadows = new[] { new Shadow(INK, 0, 1.5f, 1.5f) } };

        // Hub.js LevelsLine: the bar (at least 4 %) and "12/50"
        string LevelsLine()
        {
            var text = $"{Math.Min(_lv, _total)}/{_total}";
            float tw = UiSvg.BoxWidth(text, Info), th = UiSvg.LineBox(Info);
            float trackW = InfoW - 8 - 10 - tw;
            var s = new UiSvg(InfoW, InfoH);
            s.Box(4, (InfoH - 14) / 2, trackW, 14, new BoxStyle { Background = "rgba(60,30,10,0.38)", Radius = 7, BorderWidth = 1, BorderColor = "rgba(255,236,170,0.6)" });
            var clip = s.NewId("tc");
            s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(5, (InfoH - 14) / 2 + 1, trackW - 2, 12, new[] { 6f, 6, 6, 6 })}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{clip})\"");
            float fw = (trackW - 2) * Math.Max(4, _done * 100f / _total) / 100;
            s.Box(5, (InfoH - 14) / 2 + 1, fw, 12, new BoxStyle { Gradient = new[] { "#ffe38a", "#ffb02e" }, GradientAngle = 90, Radius = 7 });
            s.Close();
            s.Text(text, 4 + trackW + 10, (InfoH - th) / 2, Info);
            return s.Markup;
        }

        // Hub.js BestLine: BEST: n, centred
        string BestLine() => new UiSvg(InfoW, InfoH).Text($"BEST: {_top}", 4, (InfoH - UiSvg.LineBox(InfoCenter)) / 2, InfoCenter, InfoW - 8, 0.5f).Markup;

        // Squishdoku's plaque with this game's picture in its window
        string Panel(string kind) => HubsData.LoadXml("Squishdoku/panel-" + kind).Replace("href=\"Squishdoku/mode-" + kind + "\"", "href=\"" + _picDir + "/mode-" + kind + "\"");

        public override void Draw(LayerFrame f, Affine view, float opacity)
        {
            // the title, in the middle of its 30 dp box 40 dp up
            var t = f.L("hub title");
            t.Set(_title, () => { var s = new UiSvg(_t.W, _t.H); _t.Draw(s, 0, 0); return s.Markup; }, _t.W, _t.H, 8);
            var tb = Affine.Translate(Card.Whole((_w - _t.W) / 2), _top0 - 40 + (30 - _t.H) / 2);
            t.Transform = view * tb * _pop.Local(_t.W, _t.H) * _rock.Local(_t.W, _t.H);
            t.Opacity = opacity * _pop.Opacity;
            DrawPanel(f, "regular", _letR, _regular, CardsX, _slideR, LevelsLine, $"{_lv}|{_done}|{_total}", view, opacity);
            DrawPanel(f, "blitz", _letB, _blitz, CardsX + CardW + CardGap, _slideB, BestLine, _top.ToString(), view, opacity);
            _rules.Draw(f, view * Affine.Translate(RulesX, RulesY) * _slideQ.Local, opacity * _slideQ.Opacity);
        }

        // a panel (sinking 2 dp while held), its name (Lettering's box (12, 6) 348 x 34, its <svg> centred in it on whole
        // dp) and its info row
        void DrawPanel(LayerFrame f, string kind, (string svg, float w, float h) name, HubButton btn, float x, SlideIn slide, Func<string> info, string infoKey, Affine view, float opacity)
        {
            float y = CardsY;
            var m = view * Affine.Translate(x, y + (btn.Held ? 2 : 0)) * slide.Local;
            btn.Place(view * Affine.Translate(x, y) * slide.Local);
            float op = opacity * slide.Opacity;
            var p = f.L("hub panel " + kind);
            p.Set(_picDir + kind, () => Panel(kind), CardW, CardH, 6);
            p.Transform = m; p.Opacity = op;
            var (lsvg, lw, lh) = name;
            var l = f.L("hub name " + kind);
            l.Set(lsvg, lw, lh, 6);
            float lx = 12 + (348 - lw) / 2, ly = 6 + (34 - lh) / 2;
            l.Transform = m * Affine.Translate(Card.Whole(x + lx) - x, Card.Whole(y + ly) - y); l.Opacity = op;
            var i = f.L("hub info " + kind);
            i.Set(infoKey, info, InfoW, InfoH, 3);
            i.Transform = m * Affine.Translate(InfoX, InfoY); i.Opacity = op;
        }
    }
}
