// Squishdoku's front page in landscape (src/squishdoku/Hub.js, REDESIGN_V9): SQUISHDOKU at the top (popping in, then
// rocking), the two modes side by side (wood plaques: the mode's name, its picture in a gold-ringed window, and under it
// how far through the 600 levels / the most boards cleared in one Blitz run), HEAD START's plaque with its switch and HOW
// TO PLAY along the bottom; each slides in after its delay. The plaques, the switch's looks and HOW TO PLAY are cut from
// the app (tools/unity/export-squishdoku.mjs: Resources/Squishdoku); the title, the progress and the numbers are drawn
// here. It sits under the screen's top bar (48 dp); SdScreen hosts it. No UnityEngine here.
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;

namespace SquishSquad.Games.Squishdoku
{
    public sealed class SdHub
    {
        public const float Top = 48;          // the screen's top bar
        public const float CardW = 372, CardH = 232, CardGap = 22, HeadW = 400, HeadH = 66, RulesW = 161.4375f, RulesH = 50, RulesRingH = 45;
        // what's on a mode panel (from its top-left): the info row (12, 196) 348 x 24, its track 14 tall
        const float InfoX = 12, InfoY = 196, InfoW = 348, InfoH = 24;
        const float ToggleX = 330, ToggleY = 16.5f, ToggleW = 58, ToggleH = 33, KnobX = 6, KnobY = 6, Knob = 17, Travel = 28;

        public Action OnRegular, OnBlitz, OnRules, OnToggleHead;

        readonly float W, H;
        readonly Func<string, string> _xml;
        readonly SdLayer _letR, _letB;
        readonly SdLayer _title, _panelR, _panelB, _infoR, _infoB, _head, _togOff, _togOn, _knob, _rulesLip, _rulesFace;
        readonly PopIn _pop = new PopIn(60, 0.3, -10);
        readonly Rock _rock = new Rock(2, 3400);
        readonly SlideIn _slideR = new SlideIn(300, 50), _slideB = new SlideIn(420, 50), _slideH = new SlideIn(520, 40), _slideQ = new SlideIn(600, 30);
        readonly AnimatedValue _pos, _squash = new AnimatedValue(0);
        readonly Press _press = new Press();
        readonly CardArt.Title _t = new CardArt.Title("SQUISHDOKU", 34, "gold");
        bool _head0;
        string _infoKey;

        public SdHub(float screenW, float screenH, Func<string, string> xml, bool head)
        {
            W = screenW; H = screenH; _xml = xml;
            _head0 = head;
            _pos = new AnimatedValue(head ? 1 : 0);
            _title = new SdLayer("title").Set(_t.Markup(), _t.W, _t.H, 8);
            _panelR = new SdLayer("panel regular").Set(xml("panel-regular"), CardW, CardH, 6);
            _panelB = new SdLayer("panel blitz").Set(xml("panel-blitz"), CardW, CardH, 6);
            _infoR = new SdLayer("progress"); _infoB = new SdLayer("best");
            var (lr, lrw, lrh) = SdArt.Lettering("Regular Mode", 22);
            _letR = new SdLayer("regular mode").Set(lr, lrw, lrh, 6);
            var (lb, lbw, lbh) = SdArt.Lettering("Blitz Mode", 22);
            _letB = new SdLayer("blitz mode").Set(lb, lbw, lbh, 6);
            _head = new SdLayer("head start").Set(xml("headstart"), HeadW, HeadH, 6);
            _togOff = new SdLayer("switch off").Set(xml("toggle-off"), ToggleW, ToggleH, 3);
            _togOn = new SdLayer("switch on").Set(xml("toggle-on"), ToggleW, ToggleH, 3);
            _knob = new SdLayer("switch knob").Set(xml("toggle-knob"), Knob, Knob, 3);
            _rulesLip = new SdLayer("how to play lip").Set(xml("rules-lip"), RulesW, RulesRingH, 3);
            _rulesFace = new SdLayer("how to play").Set(xml("rules-face"), RulesW, RulesRingH, 3);
        }

        /// <summary>The hub's content mounts (built behind its placeholders): its pop-ins and slide-ins start.</summary>
        public void Mount()
        {
            _pop.Trigger(); _rock.Mount();
            _slideR.Trigger(); _slideB.Trigger(); _slideH.Trigger(); _slideQ.Trigger();
        }
        public void Unmount() { _pop.Stop(); _rock.Unmount(); _slideR.Stop(); _slideB.Stop(); _slideH.Stop(); _slideQ.Stop(); }

        /// <summary>HEAD START flipped: the switch springs across.</summary>
        public void SetHead(bool on)
        {
            if (on == _head0) return;
            _head0 = on;
            Animated.Spring(_pos, Fx.Spring(on ? 1 : 0, 6, 140)).Start();
        }

        // ---- where things are (Hub.js wPage: the title's 30 dp box 40 dp up into the top bar; the cards and the bottom row
        // spread with the space left, 12 dp clear of the bottom) --------------------------------------------------------------
        float Gap => (H - Top - 12 - (-40 + 30 + CardH + HeadH)) / 2;
        float CardsY => Top - 10 + Gap;
        float CardsX => Card.Snap((W - (2 * CardW + CardGap)) / 2);
        float BottomY => CardsY + CardH + Gap;
        float HeadX => Card.Snap((W - (HeadW + 18 + RulesW)) / 2);
        float RulesX => HeadX + HeadW + 18;
        float RulesY => BottomY + (HeadH - RulesH) / 2;
        public (float x, float y, float w, float h) Regular => (CardsX, CardsY, CardW, CardH);
        public (float x, float y, float w, float h) Blitz => (CardsX + CardW + CardGap, CardsY, CardW, CardH);
        public (float x, float y, float w, float h) Toggle => (HeadX + ToggleX, BottomY + ToggleY, ToggleW, ToggleH);
        public (float x, float y, float w, float h) Rules => (RulesX, RulesY, RulesW, RulesH);

        static readonly TextStyle Info = new TextStyle { Font = SdArt.Display, Size = 16, Color = "#ffffff", Shadows = new[] { new Shadow(SdArt.INK, 0, 1.5f, 1.5f) } };
        static readonly TextStyle InfoCenter = new TextStyle { Font = SdArt.Display, Size = 18, LetterSpacing = 0.6f, Color = "#ffffff", Shadows = new[] { new Shadow(SdArt.INK, 0, 1.5f, 1.5f) } };

        /// <summary>REGULAR's info row: the bar (at least 4%) and "12/600"; BLITZ's: BEST: n.</summary>
        void Infos(SdkRecord rec)
        {
            int lv = (int)rec.Lv, top = (int)Js.OrNumber(rec.Blitz["top"], 0);
            bool last = Js.Truthy(rec.Best.TryGetValue(Js.IntKey(Levels.LevelCount), out var b) ? b : null);
            int done = lv - 1 + (last ? 1 : 0);
            var key = $"{lv}|{done}|{top}";
            if (key == _infoKey) return;
            _infoKey = key;
            var text = $"{Math.Min(lv, Levels.LevelCount)}/{Levels.LevelCount}";
            float tw = UiSvg.BoxWidth(text, Info), th = UiSvg.LineBox(Info);
            float trackW = InfoW - 8 - 10 - tw;
            var s = new UiSvg(InfoW, InfoH);
            s.Box(4, (InfoH - 14) / 2, trackW, 14, new BoxStyle { Background = "rgba(60,30,10,0.38)", Radius = 7, BorderWidth = 1, BorderColor = "rgba(255,236,170,0.6)" });
            var clip = s.NewId("tc");
            s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(5, (InfoH - 14) / 2 + 1, trackW - 2, 12, new[] { 6f, 6, 6, 6 })}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{clip})\"");
            float fw = (trackW - 2) * Math.Max(4, done * 100f / Levels.LevelCount) / 100;
            s.Box(5, (InfoH - 14) / 2 + 1, fw, 12, new BoxStyle { Gradient = new[] { "#ffe38a", "#ffb02e" }, GradientAngle = 90, Radius = 7 });
            s.Close();
            s.Text(text, 4 + trackW + 10, (InfoH - th) / 2, Info);
            _infoR.Set(s.Markup, InfoW, InfoH, 3);
            var best = $"BEST: {top}";
            var sb = new UiSvg(InfoW, InfoH).Text(best, 4, (InfoH - UiSvg.LineBox(InfoCenter)) / 2, InfoCenter, InfoW - 8, 0.5f);
            _infoB.Set(sb.Markup, InfoW, InfoH, 3);
        }

        static readonly Interpolator OnOp = Fx.Lerp(new[] { 0, 0.5, 1 }, new[] { 0.0, 0.5, 1 }, true), OffOp = Fx.Lerp(new[] { 0, 0.5, 1 }, new[] { 1.0, 0.5, 0 }, true);

        /// <summary>Its layers under `view` (the view switch's slide), `opacity` (its reveal).</summary>
        public void Layers(SdkRecord rec, Affine view, float opacity, List<SdLayer> o)
        {
            Infos(rec);
            // the title, in the middle of its 30 dp box 8 dp down
            var tb = Affine.Translate(Card.Whole((W - _t.W) / 2), Top - 40 + (30 - _t.H) / 2);
            _title.Transform = view * tb * _pop.Local(_t.W, _t.H) * _rock.Local(_t.W, _t.H);
            _title.Opacity = opacity * _pop.Opacity;
            o.Add(_title);
            Panel(_panelR, _infoR, _letR, Regular, _slideR, _downOn == 1, view, opacity, o);
            Panel(_panelB, _infoB, _letB, Blitz, _slideB, _downOn == 2, view, opacity, o);
            // HEAD START
            var hm = view * Affine.Translate(HeadX, BottomY) * _slideH.Local;
            float ho = opacity * _slideH.Opacity;
            _head.Transform = hm; _head.Opacity = ho; o.Add(_head);
            double p = _pos.GetValue(), q = _squash.GetValue();
            var tm = hm * Affine.Translate(ToggleX, ToggleY);
            _togOff.Transform = tm; _togOff.Opacity = ho * (float)OffOp.Evaluate(p); o.Add(_togOff);
            _togOn.Transform = tm; _togOn.Opacity = ho * (float)OnOp.Evaluate(p); o.Add(_togOn);
            _knob.Transform = tm * Affine.Translate(KnobX + Travel * p, KnobY) * Fx.About(Knob, Knob, Affine.ScaleBy(1 + 0.18 * q, 1 - 0.14 * q));
            _knob.Opacity = ho; o.Add(_knob);
            // HOW TO PLAY (SdButton: the whole button shrinks to 0.93, the ring sinks 4 dp)
            double t = _press.T, s = 1 + (0.93 - 1) * t;
            var whole = view * Affine.Translate(RulesX, RulesY) * _slideQ.Local * Fx.About(RulesW, RulesH, Affine.ScaleBy(s, s));
            float qo = opacity * _slideQ.Opacity;
            _rulesLip.Transform = whole * Affine.Translate(0, 5); _rulesLip.Opacity = qo; o.Add(_rulesLip);
            _rulesFace.Transform = whole * Affine.Translate(0, 4 * t); _rulesFace.Opacity = qo; o.Add(_rulesFace);
        }

        // the panel's name: Lettering's box (12, 6) 348 x 34, its <svg> centred in it on whole dp
        static void Panel(SdLayer panel, SdLayer info, SdLayer name, (float x, float y, float w, float h) r, SlideIn slide, bool down, Affine view, float opacity, List<SdLayer> o)
        {
            var m = view * Affine.Translate(r.x, r.y + (down ? 2 : 0)) * slide.Local;
            panel.Transform = m; panel.Opacity = opacity * slide.Opacity; o.Add(panel);
            float lx = 12 + (348 - name.W) / 2, ly = 6 + (34 - name.H) / 2;
            name.Transform = m * Affine.Translate(Card.Whole(r.x + lx) - r.x, Card.Whole(r.y + ly) - r.y); name.Opacity = panel.Opacity; o.Add(name);
            info.Transform = m * Affine.Translate(InfoX, InfoY); info.Opacity = panel.Opacity; o.Add(info);
        }

        // ---- touches (screen dp) ------------------------------------------------------------------------------------------
        int _downOn;   // 1 regular, 2 blitz, 3 the switch, 4 HOW TO PLAY

        static bool In((float x, float y, float w, float h) r, float x, float y, float slop) => x >= r.x - slop && x <= r.x + r.w + slop && y >= r.y - slop && y <= r.y + r.h + slop;

        int Hit(float x, float y) => In(Regular, x, y, 0) ? 1 : In(Blitz, x, y, 0) ? 2 : In(Toggle, x, y, 8) ? 3 : In(Rules, x, y, 6) ? 4 : 0;

        public bool Down(float x, float y)
        {
            _downOn = Hit(x, y);
            if (_downOn == 3) Animated.Timing(_squash, Fx.Timing(1, 90, Easing.Out(Easing.Quad))).Start();
            if (_downOn == 4) _press.Down();
            return _downOn != 0;
        }

        public void Up(float x, float y)
        {
            int was = _downOn;
            _downOn = 0;
            if (was == 3) Animated.Timing(_squash, Fx.Timing(0, 90, Easing.Out(Easing.Quad))).Start();
            if (was == 4) _press.Up();
            if (was == 0 || Hit(x, y) != was) return;
            if (was == 1) OnRegular?.Invoke();
            else if (was == 2) OnBlitz?.Invoke();
            else if (was == 3) OnToggleHead?.Invoke();
            else OnRules?.Invoke();
        }
    }
}
