// Renovate's sign editor panel (Squad House v6.dc.html's sgx, Aa on a sign's toolbar): 300 wide, under the top in the
// middle, tilted -1°; padding 10 12 12, gap 8: WRITE YOUR SIGN and the sign's name, the text box (36 tall), the sign's
// presets (wrapping, 24 tall, 5 apart), Done (gold, right). Its look and layout, without UnityEngine: House/View/
// HouseEditView.cs shows it and handles the typing, the tests draw it (tools/unity/house-test `signframes`).
using System;
using System.Collections.Generic;
using System.Globalization;
using SquishSquad.Ui;

namespace SquishSquad.House
{
    public static class SignPanel
    {
        public const double W = 300, Y = 54;
        /// <summary>The panel's left in the frame (left: 50 % of the 852 px frame).</summary>
        public static double X => 426 - W / 2;
        static readonly TextStyle Head = new TextStyle { Font = "Fredoka_700Bold", Size = 9, Color = "#c4651f", LetterSpacing = 9 * 0.09f };
        static readonly TextStyle Name = new TextStyle { Font = "Fredoka_700Bold", Size = 12, Color = "#8a6a4a" };
        static readonly TextStyle Text = new TextStyle { Font = "Fredoka_500Medium", Size = 18, Color = "#5b3418" };
        static readonly TextStyle Hint = new TextStyle { Font = "Fredoka_500Medium", Size = 18, Color = "#b8a48c" };
        static readonly TextStyle Pre = new TextStyle { Font = "Fredoka_700Bold", Size = 11.5f, Color = "#5b3418" };
        static readonly TextStyle Done = new TextStyle { Font = "Fredoka_700Bold", Size = 13, Color = "#5b3418" };

        /// <summary>The panel's parts (panel px from its top-left): "sg-input", "sg-pre:i", "sg-done"; and its height.</summary>
        public static (List<(string id, double x, double y, double w, double h)> els, double h) Layout(HouseCreatures.SignEd ed)
        {
            var els = new List<(string, double, double, double, double)>();
            double x0 = 12, w = W - 24, y = 10;
            y += Math.Max(UiSvg.LineBox(Head), UiSvg.LineBox(Name)) + 8;
            els.Add(("sg-input", x0, y, w, 36)); y += 36 + 8;
            double px = 0;
            for (int i = 0; i < ed.Presets.Count; i++)
            {
                double bw = UiSvg.BoxWidth(ed.Presets[i], Pre) + 18 + 4;
                if (px > 0 && px + bw > w) { px = 0; y += 24 + 5; }
                els.Add(("sg-pre:" + i, x0 + px, y, bw, 24)); px += bw + 5;
            }
            if (ed.Presets.Count > 0) y += 24 + 8;
            double dw = UiSvg.BoxWidth("Done", Done) + 32 + 4;
            els.Add(("sg-done", x0 + w - dw, y, dw, 28)); y += 28;
            return (els, y + 12);
        }

        static string N(double v) => Math.Round(v, 3).ToString("0.###", CultureInfo.InvariantCulture);

        /// <summary>The panel (W x its height): `typing` the text box focused, `caret` its caret shown now, `held` the
        /// part held down (it sinks 2 px).</summary>
        public static UiSvg Draw(HouseCreatures.SignEd ed, bool typing, bool caret, string held)
        {
            var (els, H0) = Layout(ed);
            var s = new UiSvg((float)W, (float)H0);
            // #fff6e2, radius 10, a 2.5 #6b4426 ring, a 4 px lip and a soft shadow under it
            s.Box(0, 0, (float)W, (float)H0, new BoxStyle { Background = "#fff6e2", Radius = 10, Shadows = new[] { new Shadow("#6b4426", 0, 0, 0, 2.5f), new Shadow("rgba(107,68,38,0.35)", 0, 4, 0, 2.5f), new Shadow("rgba(60,30,10,0.35)", 0, 12, 22) } });
            float hy = 10, hh = Math.Max(UiSvg.LineBox(Head), UiSvg.LineBox(Name));
            s.Text("WRITE YOUR SIGN", 12, hy + (hh - UiSvg.LineBox(Head)) / 2, Head);
            float nw = UiSvg.BoxWidth(ed.Style, Name); s.Text(ed.Style, (float)(W - 12 - nw), hy + (hh - UiSvg.LineBox(Name)) / 2, Name);
            foreach (var (id, x, y, w, h) in els)
            {
                float Wd = (float)w, Ht = (float)h;
                bool down = held == id;
                s.Open($"transform=\"translate({N(x)} {N(y + (down ? 2 : 0))})\"");
                if (id == "sg-input")
                {
                    s.Box(0, 0, Wd, Ht, new BoxStyle { Background = "#ffffff", Radius = 7, BorderWidth = 2, BorderColor = typing ? "#c4651f" : "#6b4426" });
                    bool empty = string.IsNullOrEmpty(ed.Val);
                    var st = empty ? Hint : Text;
                    s.Text(empty ? "Type a message" : ed.Val, 10, (Ht - UiSvg.LineBox(st)) / 2, st);
                    if (caret) { float cx = 10 + (empty ? 0 : UiSvg.BoxWidth(ed.Val, Text)) + 1; s.Box(cx, 8, 2, Ht - 16, new BoxStyle { Background = "#5b3418" }); }
                }
                else if (id == "sg-done")
                {
                    s.Box(0, 0, Wd, Ht, new BoxStyle { Gradient = new[] { "#ffe9a0", "#e2b14a", "#b8862a" }, GradientStops = new[] { 0f, 0.6f, 1f }, Radius = 6, BorderWidth = 2, BorderColor = "#6b4426", Shadows = new[] { new Shadow("#6b4426", 0, down ? 0.5f : 2.5f, 0) } });
                    float tw = UiSvg.BoxWidth("Done", Done); s.Text("Done", (Wd - tw) / 2, (Ht - UiSvg.LineBox(Done)) / 2, Done);
                }
                else
                {
                    string t = ed.Presets[int.Parse(id.Substring(7))];
                    s.Box(0, 0, Wd, Ht, new BoxStyle { Background = t == ed.Val ? "#ffe39a" : "#efdcb6", Radius = 6, BorderWidth = 2, BorderColor = "#6b4426" });
                    float tw = UiSvg.BoxWidth(t, Pre); s.Text(t, (Wd - tw) / 2, (Ht - UiSvg.LineBox(Pre)) / 2, Pre);
                }
                s.Close();
            }
            return s;
        }
    }
}
