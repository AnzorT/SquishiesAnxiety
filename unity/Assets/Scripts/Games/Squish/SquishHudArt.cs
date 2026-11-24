// Squish Time's screen around the stage (src/screens/SquishScreen.js, landscape as the app shows it): where every
// piece goes on a screen of any size (the app's flex layout worked out: the stage area and the boosts' panel side by
// side, the stage centred in its area, the HUD held to its edges), and the pieces Unity makes itself because they
// change (the coin pill's number, the rings), drawn as the UI exporter writes what Chrome paints (UiSvg / UiFont).
// The exported pieces (tools/unity/export-squish.mjs -> Resources/Squish/hud/*.xml, hud.json) are the app's own.
// Plain C#: tools/unity/squish-test composes the screen from it and compares with the app's screenshot.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;

namespace SquishSquad.Games.Squish
{
    public struct HudBox
    {
        public float X, Y, W, H;
        public HudBox(float x, float y, float w, float h) { X = x; Y = y; W = w; H = h; }
        public bool Contains(float px, float py) => px >= X && px < X + W && py >= Y && py < Y + H;
        public HudBox Move(float dx, float dy) => new HudBox(X + dx, Y + dy, W, H);
    }

    /// <summary>The screen's layout in dp for a screen w x h (landscape), from the A15's measured boxes (hud.json).</summary>
    public sealed class SquishLayout
    {
        public const float SidePanelW = 210, GearSize = 42, GearRight = 14, Edge = 14;
        public readonly float W, H, StageSize, StageAreaW;
        public readonly HudBox Stage, Back, Pill, Gear, GearGlyph, GearHalo, SettingsHand, SettingsHint, Boosts, Settings, Punish, CloseX;
        public readonly HudBox[] HintHands = new HudBox[2], HintLabels = new HudBox[2], HintRings = new HudBox[2];
        public readonly Dictionary<string, HudBox> A15 = new Dictionary<string, HudBox>();

        public SquishLayout(float w, float h, IDictionary<string, object> hudJson)
        {
            W = w; H = h;
            foreach (var kv in (IDictionary<string, object>)hudJson["pieces"])
            {
                var a = (IList<object>)kv.Value;
                A15[kv.Key] = new HudBox(F(a[0]), F(a[1]), F(a[2]), F(a[3]));
            }
            // STAGE_SIZE: the screen's shorter side, capped for tablets; centred in the stage area (flex: 1 beside
            // the 210 dp panel)
            StageSize = Math.Min((float)Math.Round(Math.Min(w, h)), 420);
            StageAreaW = w - SidePanelW;
            Stage = new HudBox((StageAreaW - StageSize) / 2, (h - StageSize) / 2, StageSize, StageSize);
            var s15 = A15["stage"];
            // top left: the back orb and the pill (left 14, top 14)
            Back = A15["back"];
            Pill = A15["coinPill"];
            // the gear: right 14 of the stage area; the halo round it, the settings hint under it
            float dxArea = StageAreaW - (832 - SidePanelW);
            Gear = A15["gear"].Move(dxArea, 0);
            GearGlyph = A15["gearGlyphBox"].Move(dxArea, 0);
            GearHalo = A15["gearHalo"].Move(dxArea, 0);
            SettingsHand = A15["hand-0"].Move(dxArea, 0);
            SettingsHint = A15["hint-0"].Move(dxArea, 0);
            // the stage's gesture hints: 4 % in from its sides, at half its height
            float k = StageSize / s15.W;
            for (int i = 0; i < 2; i++)
            {
                bool left = i == 0;
                HudBox Place(HudBox b)
                {
                    float ox = b.X - s15.X, oy = b.Y - s15.Y;
                    float x = left ? 0.04f * StageSize + (ox - 0.04f * s15.W) : StageSize - 0.04f * StageSize - (s15.W - 0.04f * s15.W - ox);
                    return new HudBox(Stage.X + x, Stage.Y + StageSize / 2 + (oy - s15.H / 2), b.W, b.H);
                }
                HintHands[i] = Place(A15["hand-" + (i + 1)]);
                HintLabels[i] = Place(A15["hint-" + (i + 1)]);
                HintRings[i] = Place(A15["ring-" + i]);
            }
            // the boosts' panel: right edge, centred (under the invisible bonus banner)
            var b15 = A15["boosts"];
            Boosts = new HudBox(w - (832 - b15.X), h / 2 + (b15.Y - 192), b15.W, b15.H);
            // the settings card: right 14 of the screen, under the gear
            var c15 = A15["settings"];
            Settings = new HudBox(w - (832 - c15.X), c15.Y, c15.W, c15.H);
            CloseX = A15["closeX"].Move(Settings.X - c15.X, 0);
            // the punishment: centred
            var p15 = A15["punish"];
            Punish = new HudBox((w - p15.W) / 2, (h - p15.H) / 2, p15.W, p15.H);
        }

        /// <summary>A piece of the settings card (a toggle, a choice row) on this screen.</summary>
        public HudBox InSettings(string name) => A15[name].Move(Settings.X - A15["settings"].X, Settings.Y - A15["settings"].Y);
        /// <summary>ACCEPT PUNISHMENT's button in the card (read off the app's screenshot).</summary>
        public HudBox PunishButton => new HudBox(Punish.X + 30.5f, Punish.Y + 206.5f, 279, 51);

        static float F(object o) => (float)(double)o;
    }

    public static class SquishHudArt
    {
        /// <summary>Loads an exported piece's SVG (Resources/Squish/hud/<name>.xml).</summary>
        public static Func<string, string> Xml;

        // src/format.js fmtNum
        public static string FmtNum(double n)
        {
            double v = Math.Floor(n + 0.5);
            string s = Math.Abs(v).ToString("0", CultureInfo.InvariantCulture);
            s = Regex.Replace(s, @"\B(?=(\d{3})+(?!\d))", ",");
            return v < 0 ? "-" + s : s;
        }

        static readonly TextStyle PillText = new TextStyle { Font = "Nunito_800ExtraBold", Size = 13, Color = "#ffffff", Shadows = new[] { new Shadow("#6b4426", 0, 1, 1) } };
        static readonly TextStyle PillEarned = new TextStyle { Font = "Nunito_800ExtraBold", Size = 9, Color = "#ffe9a8", LetterSpacing = 0.8f, Shadows = new[] { new Shadow("#6b4426", 0, 1, 1) } };

        /// <summary>CoinCounter: "+N EARNED" in its pill (row: coin 17, gap 6, padding 12 / 5, border 2), w x h dp.</summary>
        public static string Pill(double value, out float w, out float h)
        {
            string t = "+" + FmtNum(value);
            float tw = UiSvg.BoxWidth(t, PillText), ew = UiSvg.BoxWidth("EARNED", PillEarned);
            float line = Math.Max(17, Math.Max(UiSvg.LineBox(PillText), UiSvg.LineBox(PillEarned)));
            w = 2 + 12 + 17 + 6 + tw + 6 + ew + 12 + 2;
            h = 2 + 5 + line + 5 + 2;
            var s = new UiSvg(w, h);
            s.Box(0, 0, w, h, new BoxStyle { Radius = h / 2, Background = "rgba(90,50,20,0.42)", BorderWidth = 2, BorderColor = "rgba(255,255,255,0.9)" });
            float x = 14, top = 7;
            s.Raw(Nest(Xml("coin"), x, top + (line - 17) / 2));
            x += 17 + 6;
            s.Text(t, x, top + (line - UiSvg.LineBox(PillText)) / 2, PillText);
            x += tw + 6;
            s.Text("EARNED", x, top + (line - UiSvg.LineBox(PillEarned)) / 2, PillEarned);
            return s.Markup;
        }

        /// <summary>A circle's border (TouchRing 26 / 2.5 #ff6fbd, the gear's halo 52 / 3 #ff8a3d, the touch ripple
        /// 180 / 3 rgba(255,111,189,0.7)).</summary>
        public static string Ring(float size, float border, string color)
        {
            var s = new UiSvg(size, size);
            s.Box(0, 0, size, size, new BoxStyle { Radius = size / 2, BorderWidth = border, BorderColor = color });
            return s.Markup;
        }

        /// <summary>FloatingCoin's sticker: OutlinedTitle `+N`, gold, 26, outline 2.5, letterSpacing 0.</summary>
        public static CardArt.Title Sticker(int n) => new CardArt.Title("+" + n, 26, "gold") { Outline = 2.5f, LetterSpacing = 0 };

        /// <summary>The punishment's title: OutlinedTitle "WHOA THERE!" in PUNISH_FILL (red), 30.</summary>
        public static CardArt.Title PunishTitle()
        {
            CardArt.TITLE_FILLS["squish-punish"] = (new[] { "#ffe0e6", "#ff5c7a", "#d3173d" }, new[] { 0f, 0.5f, 1 });
            return new CardArt.Title("WHOA THERE!", 30, "squish-punish");
        }

        /// <summary>FloatingCoin's row (coin 30, gap 2, the sticker; centred on each other): the coin's and the sticker's
        /// top-left in the row, and the row's size.</summary>
        public static void FloatRow(CardArt.Title sticker, out float coinY, out float stickerX, out float stickerY, out float w, out float h)
        {
            h = Math.Max(30, sticker.H);
            w = 30 + 2 + sticker.W;
            coinY = (h - 30) / 2;
            stickerX = 32;
            stickerY = (h - sticker.H) / 2;
        }

        public static string Dim(float w, float h, string color)
        {
            var s = new UiSvg(w, h);
            s.Box(0, 0, w, h, new BoxStyle { Background = color });
            return s.Markup;
        }

        static int _nests;
        /// <summary>An SVG piece inside another at (x, y) (its ids prefixed so they don't clash).</summary>
        public static string Nest(string svg, double x, double y, string extra = "")
        {
            var p = "n" + (_nests++) + "-";
            int a = svg.IndexOf('>') + 1;
            var inner = svg.Substring(a, svg.LastIndexOf("</svg>", StringComparison.Ordinal) - a);
            inner = inner.Replace("id=\"", "id=\"" + p).Replace("href=\"#", "href=\"#" + p).Replace("url(#", "url(#" + p);
            return $"<g transform=\"translate({UiSvg.F(x)} {UiSvg.F(y)}){extra}\">{inner}</g>";
        }
    }
}
