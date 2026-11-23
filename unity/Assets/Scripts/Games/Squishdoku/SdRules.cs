// HOW TO PLAY (src/squishdoku/Rules.js) in landscape: the title, a solved 5×5 drawn small (engine.js makePuzzle, seed
// 20261022: its patches' cushions, the player's creatures' heads on the solution) and GOT IT! on the left; the six rules
// on the right, each sliding in 70 ms after the last. Built on the shared card (Ui/Cards Card). No UnityEngine here.
using System;
using System.Collections.Generic;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using SquishSquad.Vector;

namespace SquishSquad.Games.Squishdoku
{
    public static class SdRules
    {
        static readonly string[] CUSHIONS = { "magenta", "sky", "gold", "violet", "emerald", "tangerine", "sapphire", "teal", "ruby" };
        static readonly (string key, string text)[] RULES =
        {
            ("1", "One creature in every ROW and every COLUMN."),
            ("2", "One creature in every coloured PATCH."),
            ("3", "Creatures can't TOUCH, not even corner to corner."),
            ("✕", "Tap to place. Rule cells out with ✕ (MARK, or long-press). A wrong tap is a mistake. From level 46 you have 3 hearts: the third mistake and you try the board again."),
            ("★", "No ✕ and no mistakes = PERFECT: all 3 creatures and triple coins. Otherwise beat the clock to keep them."),
            ("⚡", "BLITZ: board after board, each on a short clock, with 1 creature placed for you and no ✕. A mistake or the clock running out ends the run."),
        };

        /// <summary>The card. `roster`: the player's creatures; `headOf`: a creature's board head (Resources path), or null
        /// for its still.</summary>
        public static Card Card(float screenW, float screenH, SdCreature[] roster, Func<SdCreature, string> headOf, Action onClose)
        {
            var c = new Card(screenW, screenH) { RetriggerOnHide = true };
            c.Left.Add(new TitleItem(new CardArt.Title("HOW TO PLAY", 26, "pink")) { Pop = new PopIn(40) });
            c.Left.Add(new MiniBoardItem(roster, headOf, 150) { Pop = new PopIn(140) });
            c.Left.Add(new ButtonsItem(false, new CardButton(new CardArt.ButtonLook("green", "GOT IT!", 18, 30, 9), onClose)) { MarginTop = 4 });
            c.Right.Add(new RulesItem());
            return c;
        }

        /// <summary>Rules.js MiniBoard: the solved board in a 2.5 dp brown rim, cells size / 5.</summary>
        public sealed class MiniBoardItem : CardItem
        {
            readonly CardLayer _layer;
            readonly float _size;
            readonly SdCreature[] _roster;
            readonly Func<SdCreature, string> _headOf;
            public MiniBoardItem(SdCreature[] roster, Func<SdCreature, string> headOf, float size) { _roster = roster ?? new SdCreature[0]; _headOf = headOf; _size = size; _layer = Layer("mini board"); }
            public override bool IsStatic => false;
            public override void Measure(float colW)
            {
                W = H = _size + 8;
                var p = Engine.MakePuzzle(5, 0, 20261022);
                float cs = _size / p.N;
                var s = new UiSvg(W, H);
                s.Box(0, 0, W, H, new BoxStyle { Background = "#f3e6d4", Radius = 12 });
                var clip = s.NewId("mb");
                s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(2.5f, 2.5f, W - 5, H - 5, new[] { 9.5f, 9.5f, 9.5f, 9.5f })}\"/></clipPath>");
                s.Open($"clip-path=\"url(#{clip})\"");
                for (int cell = 0; cell < p.N * p.N; cell++)
                {
                    int r = cell / p.N, col = cell % p.N, reg = p.Regions[cell];
                    // (absolutely placed in the rim's padding box: 2.5 in)
                    float x = 2.5f + 4 + col * cs, y = 2.5f + 4 + r * cs;
                    s.Image("Squishdoku/cushions/" + CUSHIONS[reg % CUSHIONS.Length], x, y, cs, cs);
                    if (p.Solution[r] == col && _roster.Length > 0)
                    {
                        var c = _roster[(reg * 5 + 3) % _roster.Length];
                        var head = _headOf?.Invoke(c);
                        s.Image(head ?? c.Picture, x + cs * 0.07f, y + cs * 0.04f, cs * 0.86f, cs * 0.86f, "xMidYMid meet");
                    }
                }
                s.Close();
                s.Box(0, 0, W, H, new BoxStyle { Radius = 12, BorderWidth = 2.5f, BorderColor = "#6b4426" });
                _layer.Set(s.Markup, W, H, 2);
            }
        }

        /// <summary>The rules in a ScrollView up to 340 dp tall: a badge (24 dp, orange, the key or a ✕) and the rule's text
        /// (Nunito 12 on 16), each row sliding in 14 dp, 200 ms + 70 a row.</summary>
        public sealed class RulesItem : CardItem
        {
            static readonly TextStyle Text = new TextStyle { Font = CardArt.Heavy, Size = 12, LineHeight = 16, Color = CardArt.INK };
            static readonly TextStyle Key = CardArt.Style(CardArt.Display, 12, "#ffffff");
            readonly SlideIn[] _slides = new SlideIn[RULES.Length];
            readonly CardLayer[] _rows = new CardLayer[RULES.Length];
            readonly float[] _rowY = new float[RULES.Length];

            public RulesItem()
            {
                for (int i = 0; i < RULES.Length; i++) { _slides[i] = new SlideIn(200 + i * 70, 14); _rows[i] = Layer("rule " + i); }
            }

            public override bool IsStatic => false;

            public override void Measure(float colW)
            {
                W = colW;
                float y = 0, tw = colW - 8 - 24 - 9;
                for (int i = 0; i < RULES.Length; i++)
                {
                    var lines = CardArt.Wrap(RULES[i].text, Text, tw);
                    float h = Math.Max(25, lines.Count * 16);
                    var s = new UiSvg(colW, h);
                    s.Box(4, 1, 24, 24, new BoxStyle { Background = "#ff8a3d", Radius = 12, BorderWidth = 2, BorderColor = "#ffffff" });
                    if (RULES[i].key == "✕")
                    {
                        // XGlyph 11: two white bars across, turned ±45°
                        foreach (var a in new[] { 45, -45 })
                        {
                            s.Open($"transform=\"rotate({a} 16 13)\"");
                            s.Box(16 - 5.5f, 13 - 1.21f, 11, 2.42f, new BoxStyle { Background = "#ffffff", Radius = 11 });
                            s.Close();
                        }
                    }
                    else s.Text(RULES[i].key, 6, 3 + (20 - UiSvg.LineBox(Key)) / 2, Key, 20, 0.5f);
                    for (int k = 0; k < lines.Count; k++) s.Text(lines[k], 4 + 24 + 9, k * 16, Text);
                    _rows[i].Set(s.Markup, colW, h, 3);
                    _rowY[i] = y;
                    y += h + 6;
                }
                H = Math.Min(340, y - 6);
            }

            public override void Trigger() { foreach (var s in _slides) s.Trigger(); }
            public override void Unmount() { foreach (var s in _slides) s.Stop(); }

            public override void Place(Affine card, float opacity)
            {
                var m = card * Affine.Translate(X, Y);
                for (int i = 0; i < RULES.Length; i++)
                {
                    _rows[i].Transform = m * Affine.Translate(0, _rowY[i]) * _slides[i].Local;
                    _rows[i].Opacity = opacity * _slides[i].Opacity;
                }
            }
        }
    }
}
