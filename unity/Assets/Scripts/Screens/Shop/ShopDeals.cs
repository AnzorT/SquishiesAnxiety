// The Shop's Deals, Special offers and Gems tabs, landscape (src/screens/ShopDeals.js DealsTab / GemsTab; the buttons
// are the wood look's gold plaques), from config/offers (the design's defaults when it's missing: ShopData):
//   Deals    a row that scrolls sideways (a drag or the wheel), each card in a 330 x 262 column: Remove Ads (the TV
//            wobbling, its rays turning, the shine sweeping, the twinkles, BEST DEAL ribbon), the 7-day streak (the
//            flame flickering with the count on it, the seven days, CLAIM DAY n or the time to the next gift), the gem
//            jar, the season pass (until it ends); a thank-you line once ads are off
//   Special  offers (DealsTab part 'special', 2026-11-16, the user: the bundles get a tab of their own): the same row,
//            the bundles only (their pods: mountains of gems and coins, the chest; the burst badge, the one-time
//            timer); "No special offers right now." once every one is bought or gone
//   Gems     the 2X first-buy ribbon, every pack side by side (its gem pile, 2X on its first buy, its price), the gem →
//            coin swaps in a row under them
// Buying with real money: OnBuyProduct is the hook (the menu sets it to Backend/Billing, Google Play; without it, a note).
// The streak's and the pass's claims are squad moves (streakClaim / passClaim); a chest prize opens in the smash.
using System;
using System.Collections.Generic;
using System.Linq;
using Facebook.Yoga;
using SquishSquad.Anim;
using SquishSquad.Ui;
using SquishSquad.Ui.Screens;
using SquishSquad.Vector;
using static SquishSquad.Screens.Kit;
using static SquishSquad.Screens.ShopArt;

namespace SquishSquad.Screens
{
    public sealed partial class ShopView
    {
        const float COL_W = 330, COL_H = 262;
        float _scrollX, _scrollMax;
        // the loops of the Deals cards (rays, shines, twinkles, the TV, the flame, today's day, the bursts)
        readonly Dictionary<string, Loop> _loops = new Dictionary<string, Loop>();
        readonly Dictionary<string, AnimatedValue> _spins = new Dictionary<string, AnimatedValue>();
        int _shown;   // useProgressive: the parts built so far

        void BuildDealsLoops()
        {
            _loops.Clear();
            _spins.Clear();
            _shown = 1;
            if (Tab != "deals" && Tab != "special" && Tab != "gems") return;
            // one part more a frame (useProgressive(…, 1, 1)); each part's loops start as it's built
            void Next() { _shown++; _t.RequestAnimationFrame(() => { if (_shown < 12) Next(); }); }
            _t.RequestAnimationFrame(Next);
        }

        Loop L(string id, double ms, double delay = 0) { if (!_loops.TryGetValue(id, out var l)) _loops[id] = l = new Loop(_t, ms, delay); return l; }
        /// <summary>A sequence loop 0 → 1 → 0 (two eased halves of `a` and `b` ms), as Burst / NoAdsArt / StreakFlame run it.</summary>
        double Swing(string id, double a, double b)
        {
            if (!_spins.TryGetValue(id, out var v))
            {
                _spins[id] = v = new AnimatedValue(0);
                Animated.Loop(Animated.Sequence(Motion.Timing(v, 1, a, Easing.InOut(Easing.Sin)), Motion.Timing(v, 0, b, Easing.InOut(Easing.Sin)))).Start();
            }
            return v.GetValue();
        }
        /// <summary>A linear 0 → 1 loop (RaysSpin, ShineSweep's bezier when `ease`), started after `delay`.</summary>
        double Spin(string id, double ms, double delay = 0, Func<double, double> ease = null)
        {
            if (!_spins.TryGetValue(id, out var v))
            {
                _spins[id] = v = new AnimatedValue(0);
                var a = Animated.Loop(Motion.Timing(v, 1, ms, ease ?? Motion.Linear));
                if (delay > 0) _t.SetTimeout(() => a.Start(), delay); else a.Start();
            }
            return v.GetValue();
        }

        void ScrollDeals(float x) { _scrollX = Math.Max(0, Math.Min(_scrollMax, x)); }

        static float Pseudo(float w, float h, float sx, float sy, float ex, float ey) => (float)(90 + Math.Atan2((ey - sy) * h, (ex - sx) * w) * 180 / Math.PI);

        // ---- shared pieces ------------------------------------------------------------------------------------------------
        /// <summary>The card: its ring (lip 8 under it), the white border, the diagonal gradient; returns the padding box.</summary>
        static Frame Card(UiSvg s, float x, float y, float w, float h, string ring, string[] colors, float[] stops, float sx, float sy, float ex, float ey)
        {
            s.Box(x, y, w, h, new BoxStyle { Radius = 28, Background = ring });
            float fx = x + 2.5f, fy = y + 2.5f, fw = w - 5, fh = h - 2.5f - 8;
            s.Box(fx, fy, fw, fh, new BoxStyle { Radius = 25.5f, Gradient = colors, GradientStops = stops, GradientAngle = Pseudo(fw, fh, sx, sy, ex, ey), BorderWidth = 3, BorderColor = "#ffffff" });
            return new Frame(fx + 3, fy + 3, fw - 6, fh - 6);
        }

        static string ClipTo(UiSvg s, Frame pad, float r = 22.5f)
        {
            var id = s.NewId("cc");
            s.Def($"<clipPath id=\"{id}\"><path d=\"{UiSvg.RRect(pad.X, pad.Y, pad.W, pad.H, new[] { r, r, r, r })}\"/></clipPath>");
            return id;
        }

        /// <summary>candy/Decor.js RaysArt (the wedges, faded by a radial gradient), turned `deg`, its box at (x, y).</summary>
        static void Rays(UiSvg s, float x, float y, float size, string color, float opacity, double deg, float rayDeg = 8, float gapDeg = 14, float fadeStart = 0.15f, float fadeEnd = 0.65f)
        {
            float c = size / 2;
            int n = (int)Math.Round(360 / (rayDeg + gapDeg));
            var id = s.NewId("rf");
            s.Def($"<radialGradient id=\"{id}\" cx=\"{F(c)}\" cy=\"{F(c)}\" r=\"{F(c)}\" gradientUnits=\"userSpaceOnUse\"><stop offset=\"{F(fadeStart)}\" stop-color=\"{color}\" stop-opacity=\"{F(opacity)}\"/><stop offset=\"{F(fadeEnd)}\" stop-color=\"{color}\" stop-opacity=\"0\"/></radialGradient>");
            var d = new System.Text.StringBuilder();
            for (int i = 0; i < n; i++)
            {
                double a0 = i * (360.0 / n), a1 = a0 + rayDeg;
                double r0 = (a0 - 90) * Math.PI / 180, r1 = (a1 - 90) * Math.PI / 180;
                d.Append($"M{F(c)} {F(c)} L{(c + c * Math.Cos(r0)).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)} {(c + c * Math.Sin(r0)).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)} A{F(c)} {F(c)} 0 0 1 {(c + c * Math.Cos(r1)).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)} {(c + c * Math.Sin(r1)).ToString("0.00", System.Globalization.CultureInfo.InvariantCulture)} Z ");
            }
            s.Raw($"<g transform=\"translate({F(x + c)} {F(y + c)}) rotate({F(deg)}) translate({F(-c)} {F(-c)})\"><path d=\"{d}\" fill=\"url(#{id})\"/></g>");
        }

        /// <summary>candy/ShineSweep.js at phase `t` (its bezier already applied) over the box.</summary>
        static void Sweep(UiSvg s, Frame pad, double t, float strength)
        {
            double tx = Motion.Lerp(t, new[] { 0, 0.55, 1 }, new[] { -0.7 * pad.W, 1.4 * pad.W, 1.4 * pad.W });
            float sw = pad.W * 0.4f;
            s.Box(pad.X + (float)tx, pad.Y, sw, pad.H, new BoxStyle { Gradient = new[] { "rgba(255,255,255,0)", $"rgba(255,255,255,{F(strength)})", "rgba(255,255,255,0)" }, GradientAngle = Pseudo(sw, pad.H, 0, 0.4f, 1, 0.6f) });
        }

        /// <summary>The ribbon across the card's top-right corner.</summary>
        static void Ribbon(UiSvg s, Frame pad, string text, string[] colors, string rim)
        {
            var id = s.NewId("rb");
            s.Def($"<clipPath id=\"{id}\"><path d=\"{UiSvg.RRect(pad.Right - 96, pad.Y, 96, 96, new[] { 0f, 22.5f, 0, 0 })}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{id})\"");
            var tt = T(Black, 11, "#ffffff", 1);
            float bw = Bw(2), fh = LH(tt) + 8 + 2 * bw, rh = fh + 3;
            float rx = pad.Right + 44 - 150, ry = pad.Y + 16;
            s.Open($"transform=\"translate({F(rx + 75)} {F(ry + rh / 2)}) rotate(45) translate({F(-75)} {F(-rh / 2)})\"");
            s.Box(0, 0, 150, rh, new BoxStyle { Background = rim });
            s.Box(0, 0, 150, fh, new BoxStyle { Gradient = colors, Borders = new[] { bw, 0, bw, 0 }, BorderColor = "#ffffff" });
            s.Text(text, 75 - W(text, tt) / 2, bw + 4, tt);
            s.Close();
            s.Close();
        }

        /// <summary>The royal Btn (a plaque, gold or wood) of ShopDeals' RoyalShop: `content` draws its face.</summary>
        void DealBtn(List<ScreenPiece> list, string id, Frame at, float radius, bool wood, Action<UiSvg, float, float> content)
        {
            var s = new UiSvg(at.W, at.H);
            Plaque(s, 0, 0, at.W, at.H, wood ? "vel" : "gold", radius);
            content(s, at.W, at.H);
            list.Add(Piece("btn-" + id, s, at.X, at.Y + (_pressed == id ? 2 : 0), 1, null, 8));
            _hits.Add(id, at.X, at.Y, at.W, at.H);
        }

        static TextStyle BtnLabel(string rim, float size) => T(Kit.Display, size, "#ffffff", 0, 0, Outline3(rim, 2));
        static readonly string GREEN_RIM = "#17652f", GOLD_RIM = "#9c4d06", PINK_RIM = "#8a3a0e", WOOD_RIM = "#6b4426";

        /// <summary>Twinkle (candy/Sparkles.js): ✦ with its pink glow, as Chrome draws it (Resources/Shop/twinkle-*.png).</summary>
        void Twinkle(List<ScreenPiece> list, string id, float x, float y, float size, string color, double durS, double delayS, float ox, float oy)
        {
            var tw = TwinkleArt.Of(size, color);
            if (tw == null) return;
            var lp = L(id, durS * 1000, delayS * 1000);
            double t = Motion.UpDown(lp.Phase);
            float op = (float)(0.2 + 0.8 * t), sc = (float)(0.6 + 0.5 * t), rot = (float)(20 * t);
            var s = new UiSvg(tw.Value.w, tw.Value.h);
            s.Image(tw.Value.href, tw.Value.px, tw.Value.py, tw.Value.pw, tw.Value.ph);
            var m = Affine.Translate(x + ox, y + oy) * About(tw.Value.w, tw.Value.h, Affine.Rotate(rot) * Affine.ScaleBy(sc, sc));
            list.Add(new ScreenPiece { Id = id, Svg = s.Markup, W = tw.Value.w, H = tw.Value.h, Opacity = op, Margin = 0, Transform = m });
        }

        // ---- Deals / Special offers ------------------------------------------------------------------------------------------
        /// <summary>DealsTab: `part` 'deals' (everything but the bundles) or 'special' (the bundles only, no streak).</summary>
        void Deals(List<ScreenPiece> list, string part)
        {
            var offers = ShopData.OfferList(_offers);
            double now = NowMs;
            var bought = Prof.Map(Prof.Get(_profile, "offersBought"));
            var seen = Prof.Map(Prof.Get(_profile, "offerSeen"));
            bool adsFree = Prof.Truthy(Prof.Get(_profile, "adsFree"));
            var pass = ShopData.Pass(_offers);
            double passEnds = PassEnds(pass);
            var shown = offers.Where(o => !(Prof.Get(o, "enabled") is bool b && !b))
                .Where(o => !(Prof.Truthy(Prof.Get(o, "once")) && Prof.Truthy(Prof.Get(bought, Prof.Str(o["id"])))))
                .Where(o => !(Prof.Truthy(Prof.Get(o, "once")) && Prof.Truthy(Prof.Get(o, "windowHours")) && Prof.Truthy(Prof.Get(seen, Prof.Str(o["id"]))) && now > Prof.Num(Prof.Get(seen, Prof.Str(o["id"]))) + Prof.Num(Prof.Get(o, "windowHours")) * 3600e3))
                .Where(o => !(Prof.Str(o["kind"]) == "pass" && passEnds > 0 && now > passEnds))
                .Where(o => (part == "special") == (Prof.Str(o["kind"]) == "bundle"))
                .OrderBy(o => Prof.Num(Prof.Get(o, "order"))).ToList();
            foreach (var o in shown.Where(o => Prof.Truthy(Prof.Get(o, "once")) && Prof.Truthy(Prof.Get(o, "windowHours")) && !Prof.Truthy(Prof.Get(seen, Prof.Str(o["id"])))))
                if (_seenSent.Add(Prof.Str(o["id"]))) OnSeenOffer?.Invoke(Prof.Str(o["id"]), now);
            var first = shown.Where(o => Prof.Num(Prof.Get(o, "order")) < 0).ToList();
            var rest = shown.Where(o => Prof.Num(Prof.Get(o, "order")) >= 0).ToList();
            int streakN = part == "special" ? 0 : 1;
            if (part == "special" && shown.Count == 0) { SpecialNone(list); _scrollMax = 0; _scrollX = 0; return; }
            // the row's parts, built one a frame: (kind, offer, index)
            var parts = new List<(string kind, IDictionary<string, object> o, int i)>();
            for (int i = 0; i < first.Count; i++) parts.Add(("offer", first[i], i));
            if (streakN > 0) parts.Add(("streak", null, 0));
            for (int i = 0; i < rest.Count; i++) parts.Add(("offer", rest[i], i));
            if (part != "special" && adsFree && shown.Any(o => Prof.Str(o["kind"]) == "noads")) parts.Add(("owned", null, 0));
            int total = first.Count + streakN + rest.Count;
            int builtN = Math.Min(_shown, total);
            // widths: a column 330; gap 18; padding 24 each side
            var widths = new List<float>();
            int count = 0;
            var built = new List<(string kind, IDictionary<string, object> o, int i)>();
            foreach (var p in parts)
            {
                if (p.kind != "owned") { if (count >= builtN) break; count++; }
                if (p.kind == "offer" && Prof.Str(p.o["kind"]) == "noads" && adsFree) continue;
                built.Add(p);
                widths.Add(COL_W);
            }
            float content = 48 + widths.Sum() + 18 * Math.Max(0, widths.Count - 1);
            float viewW = SW;
            _scrollMax = Math.Max(0, content - viewW);
            _scrollX = Math.Min(_scrollX, _scrollMax);
            float x0 = Math.Max(0, (viewW - content) / 2) + 24 - _scrollX;
            // the row: centred in the 285 under the tabs (paddingTop 10, paddingBottom 8)
            float y = 108 + (285 - (COL_H + 18)) / 2 + 10;
            float x = x0;
            for (int k = 0; k < built.Count; k++)
            {
                var p = built[k];
                float w = widths[k];
                if (x + w > -20 && x < SW + 20)
                {
                    if (p.kind == "streak") Streak(list, x, y);
                    else if (p.kind == "owned") NoAdsOwned(list, x, y);
                    else
                    {
                        var kind = Prof.Str(p.o["kind"]);
                        if (kind == "noads") NoAds(list, p.o, x, y);
                        else if (kind == "jar") Jar(list, p.o, x, y);
                        else if (kind == "bundle") Bundle(list, p.o, p.i, x, y, Prof.Num(Prof.Get(seen, Prof.Str(p.o["id"])), TabAtMs));
                        else if (kind == "pass") PassCard(list, pass, x, y, now, passEnds);
                    }
                }
                x += w + 18;
            }
        }

        readonly HashSet<string> _seenSent = new HashSet<string>();
        /// <summary>When the tab was built (its clock time): `seen[id] || now` until the profile has the offer's first
        /// sight (DealsTab's `now`, its render's), and when its Countdowns started ticking.</summary>
        double TabAtMs => NowMs - (_t.Now - _tabAt);
        /// <summary>Countdown's `now`: its clock, moved on a second at a time from when it was built (setInterval 1000).</summary>
        double CountdownNow => TabAtMs + Math.Floor((NowMs - TabAtMs) / 1000) * 1000;

        static double PassEnds(IDictionary<string, object> pass)
        {
            var e = Prof.Str(Prof.Get(pass, "ends"));
            if (e == null) return 0;
            return (DateTime.Parse(e, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AdjustToUniversal | System.Globalization.DateTimeStyles.AssumeUniversal) - new DateTime(1970, 1, 1)).TotalMilliseconds;
        }

        /// <summary>specialNone: the Special offers tab with every bundle bought or gone, two lines in the middle of the
        /// page under the tabs (gap 4).</summary>
        void SpecialNone(List<ScreenPiece> list)
        {
            var t = T(Kit.Display, 18, CREAM, 0, 0, new[] { new Shadow("rgba(107,68,38,0.8)", 0, 1.5f, 1) });
            string a = "No special offers right now.", b = "Check back soon!";
            float h = LH(t) * 2 + 4, w = Math.Max(W(a, t), W(b, t));
            var s = new UiSvg(w, h);
            TxtC(s, a, w / 2, 0, t);
            TxtC(s, b, w / 2, LH(t) + 4, t);
            list.Add(Piece("special-none", s, (SW - w) / 2, 108 + (SH - 108 - h) / 2, 1, null, 4));
        }

        static readonly TextStyle PerkT = T(Black, 12, "#ffffff", 0, 0, new[] { new Shadow("rgba(110,0,40,0.55)", 0, 1, 1) });
        static readonly TextStyle StreakPerkT = T(Black, 12, "#ffffff", 0, 0, new[] { new Shadow("rgba(122,30,0,0.6)", 0, 1, 1) });
        static readonly TextStyle OneTime = T(Black, 9.5f, "#8a4a00", 1.2f);

        void NoAds(List<ScreenPiece> list, IDictionary<string, object> o, float x, float y)
        {
            var title = BtnLabel("#1d4f9a", 21); title.LetterSpacing = 0; title.LineHeight = 25;
            title.Shadows = Outline3("#1d4f9a", 2.5f);
            string[] perks = { "No banner or pop-up ads", "Ad chests open with no video", "Boosts and revives, video-free" };
            // the layout: the row (the TV, the text column), the button
            var root = new FlexNode("card").Width(COL_W - 5 - 6).Height(COL_H - 10.5f - 6).Padding(10).Gap(6).Justify(YGJustify.SpaceBetween);
            var row = root.Add(new FlexNode("row").Row().AlignItems(YGAlign.Center).Gap(12).Padding(YGEdge.Top, 4));
            row.Add(FlexX.Box("tv", 96, 96));
            var col = row.Add(new FlexNode("text").Flex(1).Gap(5).Padding(YGEdge.Right, 24));
            col.Add(new FlexNode("titleBox").Padding(YGEdge.Right, 34)).Add(FlexX.Para("title", new TextFlow("NO MORE ADS", title)));
            for (int i = 0; i < 3; i++)
            {
                var pr = col.Add(new FlexNode("perk" + i).Row().AlignItems(YGAlign.Center).Gap(6));
                pr.Add(FlexX.Box("check" + i, 16, 16));
                pr.Add(FlexX.Para("perkText" + i, new TextFlow(perks[i], PerkT)).Flex(1));
            }
            root.Add(new FlexNode("btn").Height(50));
            root.Layout(COL_W - 11, COL_H - 16.5f);
            var f = new Dictionary<string, Frame>();
            root.Walk(n => f[n.Name] = n.Frame);
            var s = new UiSvg(COL_W, COL_H);
            var pad = Card(s, 0, 0, COL_W, COL_H, "#1d4f9a", new[] { "#d6ecff", "#5aa8ff", "#2f6fd6" }, new[] { 0f, 0.5f, 1 }, 0.2f, 0, 0.8f, 1);
            float ox = pad.X, oy = pad.Y;
            new TextFlow("NO MORE ADS", title).Draw(s, ox + f["title"].X, oy + f["title"].Y, f["title"].W);
            for (int i = 0; i < 3; i++)
            {
                Check(s, ox + f["check" + i].X, oy + f["check" + i].Y, 16, "#2f6fd6");
                new TextFlow(perks[i], PerkT).Draw(s, ox + f["perkText" + i].X, oy + f["perkText" + i].Y, f["perkText" + i].W);
            }
            if (Prof.Str(Prof.Get(o, "tag")) is string tag) Ribbon(s, pad, tag, new[] { "#ff6f91", "#e0123f" }, "#8e0a2a");
            list.Add(Piece("noads", s, x, y, 1, null, 8));
            // what moves: the rays and the shine (clipped to the card), the twinkles, the TV
            Fx(list, "noads", x, y, pad, 22000, 0.28f, "#ffffff", 3200, 0, 0.45f);
            Twinkle(list, "noads-tw1", x + pad.X + 104, y + pad.Y + 14, 14, "#fff3a0", 1.8, 0, 0, 0);
            Twinkle(list, "noads-tw2", x + pad.X + 14, y + pad.Y + pad.H - 86, 10, "#ffffff", 2.4, 0.7, 0, -1);
            double tv = Swing("noads-tv", 700, 700);
            var art = new UiSvg(96, 96);
            NoAdsArt(art);
            var tvf = f["tv"];
            float rot = (float)(-6 + 12 * tv), ty = (float)Motion.Lerp(tv, new[] { 0.0, 0.5, 1 }, new[] { 0.0, -4, 0 });
            list.Add(new ScreenPiece { Id = "noads-tv", Svg = art.Markup, W = 96, H = 96, Margin = 8, Transform = Affine.Translate(x + ox + tvf.X, y + oy + tvf.Y) * About(96, 96, Affine.Rotate(rot) * Affine.Translate(0, ty)) });
            var bf = f["btn"];
            string price = PriceLabel("removeAds");
            DealBtn(list, "noads", new Frame(x + ox + bf.X, y + oy + bf.Y, bf.W, bf.H), 20, false, (b, w, h) =>
            {
                var lt = BtnLabel(GOLD_RIM, 23);
                float th = LH(lt) + LH(OneTime) - 1, ty0 = (h - th) / 2;
                TxtC(b, price, w / 2, ty0, lt);
                TxtC(b, "ONE-TIME PURCHASE", w / 2, ty0 + LH(lt) - 1, OneTime);
            });
        }

        static void NoAdsArt(UiSvg s)
        {
            var adT = "<text x=\"50\" y=\"58\" font-size=\"26\" font-weight=\"900\" fill=\"#ffd84a\" text-anchor=\"middle\">AD</text>";
            var inner = "<path d=\"M38 20 L28 6 M62 20 L72 6\" stroke=\"#ffffff\" stroke-width=\"5\" stroke-linecap=\"round\"/>"
                + "<circle cx=\"28\" cy=\"6\" r=\"4.5\" fill=\"#ffd84a\" stroke=\"#ffffff\" stroke-width=\"2\"/><circle cx=\"72\" cy=\"6\" r=\"4.5\" fill=\"#ffd84a\" stroke=\"#ffffff\" stroke-width=\"2\"/>"
                + "<rect x=\"10\" y=\"22\" width=\"80\" height=\"60\" rx=\"16\" fill=\"#8e1040\"/><rect x=\"10\" y=\"18\" width=\"80\" height=\"60\" rx=\"16\" fill=\"#ffffff\"/><rect x=\"17\" y=\"25\" width=\"66\" height=\"46\" rx=\"10\" fill=\"#3a1a6a\"/>";
            s.Drawing(inner, 0, 0, 96, 96, "0 0 100 100");
            // react-native-svg's <Text fontWeight 900>: the page's default family at 900 (Nunito Black), as UiSvg glyphs
            float k = 96 / 100f;
            var at = T(Black, 26 * k, "#ffd84a");
            s.Glyphs("AD", 50 * k - W("AD", at) / 2, 58 * k, Black, 26 * k, 0, "#ffd84a");
            _ = adT;
            s.Drawing("<circle cx=\"50\" cy=\"48\" r=\"31\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"12\"/><path d=\"M28 70 L72 26\" stroke=\"#ffffff\" stroke-width=\"12\" stroke-linecap=\"round\"/>"
                + "<circle cx=\"50\" cy=\"48\" r=\"31\" fill=\"none\" stroke=\"#e0123f\" stroke-width=\"7\"/><path d=\"M28 70 L72 26\" stroke=\"#e0123f\" stroke-width=\"7\" stroke-linecap=\"round\"/>", 0, 0, 96, 96, "0 0 100 100");
        }

        /// <summary>A card's rays turning and shine sweeping, clipped to it (a piece of its own: it changes every frame).</summary>
        void Fx(List<ScreenPiece> list, string id, float x, float y, Frame pad, double raysMs, float raysOp, string raysColor, double shineMs, double shineDelay, float strength, bool rays = true)
        {
            var s = new UiSvg(COL_W, COL_H);
            var clip = ClipTo(s, pad);
            s.Open($"clip-path=\"url(#{clip})\"");
            if (rays) Rays(s, pad.X - 150, pad.Y - 150, 340, raysColor, raysOp, 360 * Spin(id + "-rays", raysMs));
            Sweep(s, pad, Spin(id + "-shine", shineMs, shineDelay, Easing.Bezier(0.42, 0, 0.58, 1)), strength);
            s.Close();
            list.Add(Piece(id + "-fx", s, x, y, 1, null, 0));
        }

        // ---- the daily streak ----------------------------------------------------------------------------------------------
        static readonly Dictionary<string, (string[] bg, string ring, string ink)> DAY_LOOK = new Dictionary<string, (string[], string, string)>
        {
            ["next"] = (new[] { "#ffffff", "#fff0dc" }, "#c2531c", "#a33a06"),
            ["today"] = (new[] { "#fffbe0", "#ffd84a" }, "#9c4d06", "#7a3d00"),
            ["done"] = (new[] { "#fff6ea", "#ffe0c2" }, "#d98a52", "#b8662a"),
            ["big"] = (new[] { "#fbf5ff", "#dcc6ff" }, "#6a22d6", "#5a22c8"),
        };

        static string RewardText(IDictionary<string, object> r) => Prof.Str(r["k"]) == "coins" ? Prof.Fmt(Prof.Num(r["n"])) : Prof.Str(r["k"]) == "gems" ? Prof.JsStr(Prof.Num(r["n"])) : ShopData.SIZE_NAME[ShopData.SizeI(ShopData.ShownSize(Prof.Str(r["t"])))];
        static string RewardLong(IDictionary<string, object> r) => Prof.Str(r["k"]) == "coins" ? $"{Prof.Fmt(Prof.Num(r["n"]))} coins" : Prof.Str(r["k"]) == "gems" ? $"{Prof.JsStr(Prof.Num(r["n"]))} gems" : $"{ShopData.SIZE_NAME[ShopData.SizeI(ShopData.ShownSize(Prof.Str(r["t"])))]} chest";

        (int cnt, int idx, bool doneToday) StreakState(List<IDictionary<string, object>> streak)
        {
            var st = Prof.Map(Prof.Get(_profile, "shopStreak"));
            string last = Prof.Str(Prof.Get(st, "last"));
            bool doneToday = last == _day;
            bool alive = doneToday || last == Prof.DayBefore(_day);
            int cnt = alive ? (int)Prof.Num(Prof.Get(st, "count")) : 0;
            int idx = doneToday ? ((cnt - 1) % streak.Count + streak.Count) % streak.Count : cnt % streak.Count;
            return (cnt, idx, doneToday);
        }

        void Streak(List<ScreenPiece> list, float x, float y)
        {
            var streak = ShopData.Streak(_offers);
            var (cnt, idx, doneToday) = StreakState(streak);
            var hot = ShopData.Lineup(_day, _hidden);
            string[] perks = { "A free gift every day", $"Day {streak.Count}: {RewardLong(streak[streak.Count - 1])}" };
            var title = T(Kit.Display, 21, "#ffffff", 0, 25, Outline3("#9a2a06", 2.5f));
            var root = new FlexNode("card").Padding(10).Gap(6).Justify(YGJustify.SpaceBetween);
            var top = root.Add(new FlexNode("top").Row().AlignItems(YGAlign.Center).Gap(12).Padding(YGEdge.Top, 4).Padding(YGEdge.Left, 4));
            top.Add(FlexX.Box("flame", 62, 62 * 1.15f));
            var col = top.Add(new FlexNode("text").Flex(1).Gap(5).Padding(YGEdge.Right, 24));
            col.Add(new FlexNode("titleBox").Padding(YGEdge.Right, 34)).Add(FlexX.Para("title", new TextFlow("DAILY STREAK", title)));
            for (int i = 0; i < 2; i++)
            {
                var pr = col.Add(new FlexNode("perk" + i).Row().AlignItems(YGAlign.Center).Gap(6));
                pr.Add(FlexX.Box("check" + i, 16, 16));
                pr.Add(FlexX.Para("perkText" + i, new TextFlow(perks[i], StreakPerkT)).Flex(1));
            }
            var grid = root.Add(new FlexNode("grid").Row().Gap(4).MinH(84));
            var labelT = T(Black, 8.5f, "#000", 0.3f);
            var amtT = T(Kit.Display, 11.5f, "#000");
            for (int i = 0; i < streak.Count; i++)
            {
                bool last = i == streak.Count - 1;
                var slot = grid.Add(new FlexNode("slot" + i).Flex(last ? 1.35f : 1).MinW(0));
                slot.Add(new FlexNode("ring" + i).Flex(1).Padding(2).Padding(YGEdge.Bottom, 4))
                    .Add(new FlexNode("face" + i).Flex(1).MinH(60).AlignItems(YGAlign.Center).Justify(YGJustify.Center).Gap(2).PadV(3).PadH(2).Border(2))
                    .With(FlexX.Txt("label" + i, "DAY 7", labelT), FlexX.Box("art" + i, 1, 1), FlexX.Txt("amt" + i, "x", amtT));
            }
            if (doneToday) root.Add(new FlexNode("wait").Height(52));
            else root.Add(new FlexNode("btn").Height(44));
            float iw = COL_W - 11, ih = COL_H - 16.5f;
            root.Width(iw).Height(ih);
            // the days' art sizes into the measure
            for (int i = 0; i < streak.Count; i++)
            {
                bool last = i == streak.Count - 1, chest = Prof.Str(streak[i]["k"]) == "chest";
                var a = root.Find("art" + i);
                if (chest) a.Size(last ? 48 : 34, last ? 40 : 28); else a.Size(last ? 32 : 26, last ? 32 : 26);
            }
            root.Layout(iw, ih);
            var f = new Dictionary<string, Frame>();
            root.Walk(n => f[n.Name] = n.Frame);
            var s = new UiSvg(COL_W, COL_H);
            var pad = Card(s, 0, 0, COL_W, COL_H, "#9a2a06", new[] { "#ffe27a", "#ff9a3d", "#ec4a22" }, new[] { 0f, 0.5f, 1 }, 0.2f, 0, 0.8f, 1);
            float ox = pad.X, oy = pad.Y;
            // (the rays and the shine go under the content: a piece between)
            list.Add(Piece("streak", s, x, y, 1, null, 8));
            Fx(list, "streak", x, y, pad, 22000, 0.28f, "#ffffff", 3400, 900, 0.4f);
            var c = new UiSvg(COL_W, COL_H);
            new TextFlow("DAILY STREAK", title).Draw(c, ox + f["title"].X, oy + f["title"].Y, f["title"].W);
            for (int i = 0; i < 2; i++)
            {
                Check(c, ox + f["check" + i].X, oy + f["check" + i].Y, 16, "#ff6a1a");
                new TextFlow(perks[i], StreakPerkT).Draw(c, ox + f["perkText" + i].X, oy + f["perkText" + i].Y, f["perkText" + i].W);
            }
            for (int i = 0; i < streak.Count; i++)
            {
                var r = streak[i];
                bool last = i == streak.Count - 1;
                bool done = doneToday ? i <= idx : i < idx, today = !doneToday && i == idx;
                var look = DAY_LOOK[today ? "today" : done ? "done" : last ? "big" : "next"];
                var rf = f["ring" + i]; var ff = f["face" + i];
                c.Box(ox + rf.X, oy + rf.Y, rf.W, rf.H, new BoxStyle { Radius = 14, Background = look.ring });
                c.Box(ox + ff.X, oy + ff.Y, ff.W, ff.H, new BoxStyle { Radius = 12, Gradient = look.bg, BorderWidth = 2, BorderColor = "#ffffff" });
                var fclip = c.NewId("df");
                c.Def($"<clipPath id=\"{fclip}\"><path d=\"{UiSvg.RRect(ox + ff.X + 2, oy + ff.Y + 2, ff.W - 4, ff.H - 4, new[] { 10f, 10, 10, 10 })}\"/></clipPath>");
                c.Open($"clip-path=\"url(#{fclip})\"");
                if (last && !done) Rays(c, ox + ff.X + ff.W / 2 - 65, oy + ff.Y + 2 - 30, 130, "#ffffff", 0.7f, 360 * Spin("day7-rays", 16000));
                string label = today ? "TODAY" : $"DAY {i + 1}";
                var lt = T(Black, 8.5f, look.ink, 0.3f);
                FitText(c, label, lt, ox + f["label" + i].X, oy + f["label" + i].Y, ff.W - 8, 0.7f, ox + ff.X + ff.W / 2);
                var af = f["art" + i];
                float bob = today ? (float)Swing("today-day", 650, 650) : 0;
                var artM = $"translate({F(ox + af.X + af.W / 2)} {F(oy + af.Y + af.H / 2 - 3 * bob)}) scale({F(1 + 0.08 * bob)}) translate({F(-af.W / 2)} {F(-af.H / 2)})";
                c.Open($"transform=\"{artM}\"");
                if (Prof.Str(r["k"]) == "chest") Contain(c, Chest(hot[2], ShopData.ShownSize(Prof.Str(r["t"])) + "-grow"), 0, 0, af.W, af.H);
                else c.Image(Prof.Str(r["k"]) == "gems" ? Gem(i) : Coin(i), 0, 0, af.W, af.H);
                c.Close();
                var at = T(Kit.Display, 11.5f, look.ink);
                FitText(c, RewardText(r), at, ox + f["amt" + i].X, oy + f["amt" + i].Y, ff.W - 8, 0.6f, ox + ff.X + ff.W / 2);
                if (done)
                {
                    c.Box(ox + ff.X + 2, oy + ff.Y + 2, ff.W - 4, ff.H - 4, new BoxStyle { Background = "rgba(255,255,255,0.7)" });
                    Check(c, ox + ff.X + ff.W / 2 - 11, oy + ff.Y + ff.H / 2 - 11, 22);
                }
                c.Close();
                _hits.Add("day:" + i, x + ox + rf.X, y + oy + rf.Y, rf.W, rf.H);
            }
            if (doneToday)
            {
                var wf = f["wait"];
                c.Box(ox + wf.X, oy + wf.Y, wf.W, wf.H, new BoxStyle { Radius = 22, Background = "rgba(122,30,0,0.28)", BorderWidth = Bw(2.5f), BorderColor = "rgba(255,255,255,0.85)" });
                var t1 = T(Kit.Display, 20, "#ffffff", 0, 0, Outline3("#9a2a06", 2));
                var t2 = T(Black, 12, "#fff3d6", 0.4f);
                string l1 = $"{cnt} DAY{(cnt == 1 ? "" : "S")} IN A ROW!", l2 = "Next gift in " + ShopData.Hms(ShopData.UntilMidnight(_now()));
                float th = LH(t1) + 1 + LH(t2), ty = oy + wf.Y + (wf.H - th) / 2;
                TxtC(c, l1, ox + wf.X + wf.W / 2, ty, t1);
                TxtC(c, l2, ox + wf.X + wf.W / 2, ty + LH(t1) + 1, t2);
            }
            Ribbon(c, pad, "FREE", new[] { "#7be884", "#26a94e" }, "#17652f");
            list.Add(Piece("streak-c", c, x, y, 1, null, 8));
            Twinkle(list, "streak-tw1", x + pad.X + 92, y + pad.Y + 12, 14, "#ffffff", 1.8, 0, 0, 0);
            Twinkle(list, "streak-tw2", x + pad.X + 10, y + pad.Y + 96, 10, "#fff3a0", 2.4, 0.7, 0, 0);
            Flame(list, x + ox + f["flame"].X, y + oy + f["flame"].Y, cnt);
            if (!doneToday)
            {
                var bf = f["btn"];
                DealBtn(list, "streak-claim", new Frame(x + ox + bf.X, y + oy + bf.Y, bf.W, bf.H), 18, false, (b, w, h) =>
                {
                    var lt = BtnLabel(GREEN_RIM, 21);
                    var st = T(Black, 9.5f, "#17652f", 1.2f);
                    float th = LH(lt) + LH(st) - 1, ty = (h - th) / 2;
                    TxtC(b, $"CLAIM DAY {idx + 1}", w / 2, ty, lt);
                    TxtC(b, $"FREE · {RewardLong(streak[idx]).ToUpperInvariant()}", w / 2, ty + LH(lt) - 1, st);
                });
            }
        }

        /// <summary>A one-line Text with adjustsFontSizeToFit (web: shrinks the font to fit, down to minScale), centred on cx.</summary>
        static void FitText(UiSvg s, string text, TextStyle t, float x, float y, float maxW, float minScale, float cx)
        {
            float w = W(text, t);
            var st = t;
            if (w > maxW)
            {
                float k = Math.Max(minScale, maxW / w);
                st = T(t.Font, t.Size * k, t.Color, t.LetterSpacing * k);
                w = W(text, st);
                if (w > maxW) text = Ellipsize(text, st, maxW);
                w = W(text, st);
                y += (LH(t) - LH(st)) / 2;
            }
            s.Text(text, cx - w / 2, y, st);
        }

        void Flame(List<ScreenPiece> list, float x, float y, int count)
        {
            const float FW = 62, FH = 62 * 1.15f;
            var g = new UiSvg(130, 130);
            var gid = g.NewId("fg");
            g.Def($"<radialGradient id=\"{gid}\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#fff6c4\" stop-opacity=\"0.95\"/><stop offset=\"0.55\" stop-color=\"#fff6c4\" stop-opacity=\"0.38\"/><stop offset=\"1\" stop-color=\"#fff6c4\" stop-opacity=\"0\"/></radialGradient>");
            g.Raw($"<circle cx=\"65\" cy=\"65\" r=\"65\" fill=\"url(#{gid})\"/>");
            list.Add(Piece("flame-glow", g, x + (FW - 130) / 2, y + (FH - 130) / 2, 1, null, 0));
            double t = Swing("flame", 520, 640);
            var fl = new UiSvg(FW, FH);
            BigFlame(fl, 0, 0, FW, count == 0);
            var m = Affine.Translate(x, y) * About(FW, FH, Affine.Translate(0, FH / 2) * Affine.Rotate(-2 + 4 * t) * Affine.ScaleBy(1 - 0.04 * t, 1 + 0.07 * t) * Affine.Translate(0, -FH / 2));
            list.Add(new ScreenPiece { Id = "flame", Svg = fl.Markup, W = FW, H = FH, Margin = 6, Transform = m });
            var nt = T(Kit.Display, count >= 100 ? 22 : 30, "#ffffff", 0, 0, Outline3(count > 0 ? "#8a1d0c" : "#45189a", 2.5f));
            string n = count.ToString();
            var s = new UiSvg(FW, LH(nt));
            s.Text(n, (FW - W(n, nt)) / 2, 0, nt);
            list.Add(Piece("flame-num", s, x, y + FH - FH * 0.09f - LH(nt), 1, null, 6));
        }

        // ---- the gem jar -------------------------------------------------------------------------------------------------------
        void Jar(List<ScreenPiece> list, IDictionary<string, object> o, float x, float y)
        {
            double gems = ShopData.JarGems(_profile, o), max = Prof.Num(Prof.Get(o, "max")); if (max == 0) max = 1500;
            int pct = (int)Math.Min(100, Math.Round(gems / max * 100));
            bool full = gems >= max;
            var titleT = T(Kit.Display, 20, "#ffffff", 0, 0, Outline3("#45189a", 2));
            var noteT = T(Heavy, 11.5f, "#45107a", 0, 15);
            string name = Prof.Str(Prof.Get(o, "name")) ?? "Gem jar";
            string note = "Fills with gems as you earn coins. Break it to keep them all!";
            var root = new FlexNode("card").Padding(10).Gap(6).Justify(YGJustify.SpaceBetween).Row().AlignItems(YGAlign.Center);
            root.Add(FlexX.Box("jar", 84 + 5, 104 + 2.5f + 7));
            var col = root.Add(new FlexNode("text").Flex(1).MinW(0).Gap(7));
            var head = col.Add(new FlexNode("head").Row().AlignItems(YGAlign.Center).Gap(6));
            head.Add(FlexX.Txt("title", name, titleT));
            var fullT = T(Black, 10, "#ffffff");
            if (full) head.Add(new FlexNode("full").PadH(7).PadV(1).Border(2)).Add(FlexX.Txt("fullText", "FULL!", fullT));
            col.Add(FlexX.Para("note", new TextFlow(note, noteT)));
            col.Add(new FlexNode("meter").Height(20));
            col.Add(new FlexNode("btn").Height(38));
            float iw = COL_W - 11, ih = COL_H - 16.5f;
            root.Width(iw).Height(ih);
            root.Layout(iw, ih);
            var f = new Dictionary<string, Frame>();
            root.Walk(n => f[n.Name] = n.Frame);
            var s = new UiSvg(COL_W, COL_H);
            var pad = Card(s, 0, 0, COL_W, COL_H, "#14917e", new[] { "#effffb", "#bff2e8", "#6fd6c4" }, new[] { 0f, 0.6f, 1 }, 0, 0, 1, 1);
            float ox = pad.X, oy = pad.Y;
            // the jar: its ring, the glass, the fill, two gems, the lid, the shine
            var jf = f["jar"];
            float jx = ox + jf.X, jy = oy + jf.Y;
            s.Box(jx, jy, 89, 113.5f, new BoxStyle { Radii = new[] { 34f, 34, 28, 28 }, Background = "#45189a" });
            float gx = jx + 2.5f, gy = jy + 2.5f;
            s.Box(gx, gy, 84, 104, new BoxStyle { Radii = new[] { 32f, 32, 26, 26 }, Background = "rgba(255,255,255,0.85)" });
            var jc = s.NewId("jc");
            s.Def($"<clipPath id=\"{jc}\"><path d=\"{UiSvg.RRect(gx + 3, gy + 3, 78, 98, new[] { 29f, 29, 23, 23 })}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{jc})\"");
            float fh = 98 * pct / 100f;
            if (fh > 0) s.Box(gx + 3, gy + 3 + 98 - fh, 78, fh, new BoxStyle { Gradient = new[] { "#b9e6ff", "#8a5cff", "#6a22d6" } });
            s.Open($"transform=\"translate({F(gx + 3 + 8 + 21)} {F(gy + 3 + 98 - 8 - 21)}) rotate(-12) translate(-21 -21)\"");
            s.Image(Gem(1), 0, 0, 42, 42);
            s.Close();
            s.Open($"transform=\"translate({F(gx + 3 + 78 - 6 - 17)} {F(gy + 3 + 98 - 22 - 17)}) rotate(14) translate(-17 -17)\"");
            s.Image(Gem(5), 0, 0, 34, 34);
            s.Close();
            s.Box(gx + 3 + 78 / 2f - 17, gy + 3 + 7, 34, 6, new BoxStyle { Radius = 3, Background = "#c9a8ef" });
            s.Box(gx + 3 + 9, gy + 3 + 18, 9, 42, new BoxStyle { Radius = 5, Background = "rgba(255,255,255,0.8)" });
            s.Close();
            s.Box(gx, gy, 84, 104, new BoxStyle { Radii = new[] { 32f, 32, 26, 26 }, BorderWidth = 3, BorderColor = "#ffffff" });
            s.Text(name, ox + f["title"].X, oy + f["title"].Y, titleT);
            if (full)
            {
                var ff = f["full"];
                s.Box(ox + ff.X, oy + ff.Y, ff.W, ff.H, new BoxStyle { Radius = 999, Background = "#e01e4a", BorderWidth = 2, BorderColor = "#ffffff" });
                s.Text("FULL!", ox + f["fullText"].X, oy + f["fullText"].Y, fullT);
            }
            new TextFlow(note, noteT).Draw(s, ox + f["note"].X, oy + f["note"].Y, f["note"].W);
            var mf = f["meter"];
            float mx = ox + mf.X, my = oy + mf.Y;
            s.Box(mx, my, mf.W, 20, new BoxStyle { Radius = 10, Background = "rgba(69,24,154,0.22)" });
            var mc = s.NewId("mt");
            s.Def($"<clipPath id=\"{mc}\"><path d=\"{UiSvg.RRect(mx + 2, my + 2, mf.W - 4, 16, new[] { 8f, 8, 8, 8 })}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{mc})\"");
            float fw = (mf.W - 4) * Math.Max(4, pct) / 100f;
            s.Box(mx + 2, my + 2, fw, 16, new BoxStyle { Radius = 10, Gradient = new[] { "#b9e6ff", "#8a5cff" }, GradientAngle = 90 });
            s.Close();
            s.Box(mx, my, mf.W, 20, new BoxStyle { Radius = 10, BorderWidth = 2, BorderColor = "#ffffff" });
            var mt = T(Kit.Display, 11.5f, "#ffffff", 0, 0, new[] { new Shadow("#45189a", 0, 1.2f, 1) });
            string mtext = $"{Prof.Fmt(gems)} / {Prof.Fmt(max)}";
            TxtC(s, mtext, mx + mf.W / 2, my + (20 - LH(mt)) / 2, mt);
            list.Add(Piece("jar", s, x, y, 1, null, 8));
            Twinkle(list, "jar-tw", x + jx + 89 + 4 - 0, y + jy + 12, 12, "#ffffff", 1.6, 0, -TwinkleW(12, "#ffffff"), 0);
            var bf = f["btn"];
            string price = PriceLabel("offer:" + Prof.Str(o["id"]));
            DealBtn(list, "jar:" + Prof.Str(o["id"]), new Frame(x + ox + bf.X, y + oy + bf.Y, bf.W, bf.H), 13, false, (b, w, h) =>
            {
                var lt = BtnLabel(PINK_RIM, 16);
                TxtC(b, $"BREAK IT · {price}", w / 2, (h - LH(lt)) / 2, lt);
            });
        }

        static float TwinkleW(float size, string color) => TwinkleArt.Of(size, color)?.w ?? size;

        // ---- bundles --------------------------------------------------------------------------------------------------------
        static readonly Dictionary<string, (string[] bg, string rim, string glow)> STYLES = new Dictionary<string, (string[], string, string)>
        {
            ["green"] = (new[] { "#b9f7c9", "#4fd47a", "#1f9a48" }, "#17652f", "#eaffd8"),
            ["blue"] = (new[] { "#bfe4ff", "#5aa2ff", "#2f5fd0" }, "#1f3f9a", "#e3f2ff"),
            ["pink"] = (new[] { "#ffd0b8", "#ff6a3d", "#c8361a" }, "#7a1e0c", "#fff0e6"),
            ["gold"] = (new[] { "#fff3b0", "#ffc933", "#f08c00" }, "#a04a00", "#fffbe0"),
        };

        void Bundle(List<ScreenPiece> list, IDictionary<string, object> o, int index, float x, float y, double seenAt)
        {
            var look = STYLES.TryGetValue(Prof.Str(Prof.Get(o, "style")) ?? "", out var lk) ? lk : STYLES["pink"];
            var chests = (Prof.List(Prof.Get(o, "chests")) ?? new List<object>()).Select(c => (string)c).ToList();
            double gems = Prof.Num(Prof.Get(o, "gems")), coins = Prof.Num(Prof.Get(o, "coins"));
            string tag = Prof.Str(Prof.Get(o, "tag"));
            double timer = Prof.Truthy(Prof.Get(o, "once")) && Prof.Truthy(Prof.Get(o, "windowHours")) ? seenAt + Prof.Num(Prof.Get(o, "windowHours")) * 3600e3 : 0;
            var off = (Prof.Str(Prof.Get(o, "off")) ?? "").Split(' ');
            var hot = ShopData.Lineup(_day, _hidden);
            var nameT = T(Kit.Display, 23, "#ffffff", 0, 27, Outline3(look.rim, 2.5f));
            var timerT = T(Black, 10.5f, look.rim);
            var podT = T(Kit.Display, 15, "#000");
            var plusT = T(Kit.Display, 20, "#ffffff", 0, 0, new[] { new Shadow("rgba(40,0,70,0.45)", 0, 1.5f, 1) });
            string name = Prof.Str(Prof.Get(o, "name")) ?? "";
            string timerText = timer > 0 ? "One time only · " + ShopData.Hms(timer - CountdownNow) : null;
            // the card's natural height (not stretched to the column)
            var root = new FlexNode("card").Width(COL_W - 11).Padding(14).Gap(12);
            if (tag != null) root.Padding(YGEdge.Top, 20);
            var headN = root.Add(new FlexNode("head").Row().AlignItems(YGAlign.FlexStart).Padding(YGEdge.Right, 64).MinH(30));
            var hc = headN.Add(new FlexNode("headCol").Flex(1).MinW(0));
            hc.Add(FlexX.Txt("name", name, nameT));
            if (timerText != null) hc.Add(new FlexNode("timer").Row().AlignItems(YGAlign.Center).Gap(4).Margin(YGEdge.Top, 4).PadH(8).PadV(2).AlignSelf(YGAlign.FlexStart)).With(FlexX.Box("clock", 12, 12), FlexX.Txt("timerText", timerText, timerT));
            var pods = root.Add(new FlexNode("pods").Row().AlignItems(YGAlign.Center).Gap(2));
            // the gems and the coins as mountains (`rows`; 2026-11-16, the user: "add mountains of golds and gems" to the special
            // offers), the chest as its picture
            var podList = new List<(string id, string img, float iw, float ih, string amt, string ink, bool wide, int rows, int start, string twinkle)>();
            if (gems > 0) podList.Add(("gems", null, 0, 0, Prof.Fmt(gems), "#5a22c8", false, gems >= 2000 ? 4 : 3, index + 1, "#d9c4ff"));
            if (coins > 0) podList.Add(("coins", null, 0, 0, Prof.Fmt(coins), "#b86200", false, coins >= 20000 ? 4 : 3, index + 2, "#fff3a0"));
            if (chests.Count > 0)
            {
                string sz = ShopData.ShownSize(chests[0]);
                podList.Add(("chest", Chest(hot[0], sz + "-grow"), 76, 62, $"{(chests.Count > 1 ? $"{chests.Count}× " : "")}{ShopData.SIZE_NAME[ShopData.SizeI(sz)]} chest{(chests.Count > 1 ? "s" : "")}", "#45107a", true, 0, 0, null));
            }
            for (int i = 0; i < podList.Count; i++)
            {
                if (i > 0) pods.Add(FlexX.Txt("plus" + i, "+", plusT));
                var p = podList[i];
                var pn = pods.Add(new FlexNode("pod-" + p.id).Flex(p.wide ? 1.35f : 1).MinW(0).AlignItems(YGAlign.Center).Gap(2).Padding(YGEdge.Top, 6).Padding(YGEdge.Bottom, 7).PadH(3).Border(2));
                // (podArtTall: a mountain's as tall as the chest pod's picture and two-line name, so the row doesn't grow)
                pn.Add(new FlexNode("podArt-" + p.id).Height(p.rows > 0 ? 70 : 56).AlignSelf(YGAlign.Stretch));
                pn.Add(FlexX.Para("podAmt-" + p.id, new TextFlow(p.amt, T(Kit.Display, 15, p.ink), 0.5f)));
            }
            root.Add(new FlexNode("btn").Height(50));
            root.Layout(COL_W - 11, float.NaN);
            var f = new Dictionary<string, Frame>();
            root.Walk(n => f[n.Name] = n.Frame);
            float cardH = f["card"].H + 6 + 10.5f;
            var s = new UiSvg(COL_W, cardH);
            var pad = Card(s, 0, 0, COL_W, cardH, look.rim, look.bg, new[] { 0f, 0.5f, 1 }, 0.1f, 0, 0.9f, 1);
            float ox = pad.X, oy = pad.Y;
            var mountains = new List<(string id, bool gems, int rows, int start, string twinkle, float cx, float bottom)>();
            var clip = ClipTo(s, pad);
            s.Open($"clip-path=\"url(#{clip})\"");
            s.Box(pad.Right + 60 - 220, pad.Y - 80, 220, 220, new BoxStyle { Radius = 110, Background = "rgba(255,255,255,0.14)" });
            s.Box(pad.X - 40, pad.Bottom + 70 - 160, 160, 160, new BoxStyle { Radius = 80, Background = "rgba(255,255,255,0.1)" });
            s.Close();
            s.Text(name, ox + f["name"].X, oy + f["name"].Y, nameT);
            if (timerText != null)
            {
                var tf = f["timer"];
                s.Box(ox + tf.X, oy + tf.Y, tf.W, tf.H, new BoxStyle { Radius = 999, Background = "#ffffff" });
                var cf = f["clock"];
                s.Drawing($"<circle cx=\"12\" cy=\"13\" r=\"9\" fill=\"none\" stroke=\"{look.rim}\" stroke-width=\"3\"/><path d=\"M12 8 V13 L15 15\" stroke=\"{look.rim}\" stroke-width=\"3\" fill=\"none\" stroke-linecap=\"round\"/>", ox + cf.X, oy + cf.Y, 12, 12, "0 0 24 24");
                s.Text(timerText, ox + f["timerText"].X, oy + f["timerText"].Y, timerT);
            }
            for (int i = 0; i < podList.Count; i++)
            {
                var p = podList[i];
                if (i > 0) s.Text("+", ox + f["plus" + i].X, oy + f["plus" + i].Y, plusT);
                var pf = f["pod-" + p.id];
                s.Box(ox + pf.X, oy + pf.Y, pf.W, pf.H, new BoxStyle { Radius = 18, Background = "rgba(255,255,255,0.92)", BorderWidth = 2, BorderColor = "#ffffff" });
                var af = f["podArt-" + p.id];
                // the glow (a mountain's 90, its top 10 over the art's: centred on the 70 tall art all the same)
                float gs = p.rows > 0 ? 90 : p.wide ? 96 : 70, acx = ox + af.X + af.W / 2, acy = oy + af.Y + af.H / 2;
                var gid = s.NewId("pg");
                s.Def($"<radialGradient id=\"{gid}\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#fff6c4\" stop-opacity=\"0.9\"/><stop offset=\"0.55\" stop-color=\"#fff6c4\" stop-opacity=\"0.36\"/><stop offset=\"1\" stop-color=\"#fff6c4\" stop-opacity=\"0\"/></radialGradient>");
                s.Raw($"<circle cx=\"{F(acx)}\" cy=\"{F(acy)}\" r=\"{F(gs / 2)}\" fill=\"url(#{gid})\"/>");
                if (p.rows > 0) mountains.Add((p.id, p.id == "gems", p.rows, p.start, p.twinkle, acx, oy + af.Y + af.H));
                else Contain(s, p.img, acx - p.iw / 2, acy - p.ih / 2, p.iw, p.ih);
                var at = f["podAmt-" + p.id];
                new TextFlow(p.amt, T(Kit.Display, 15, p.ink), 0.5f).Draw(s, ox + at.X, oy + at.Y, at.W);
            }
            // the mountains, at the foot of their art, centred
            foreach (var m in mountains)
            {
                var (mw, mh) = MountainSize(m.rows);
                Mountain(s, m.gems, m.rows, m.start, m.cx - mw / 2, m.bottom - mh);
            }
            float ty = 0;   // (the tag sits over the card's top edge)
            list.Add(Piece("bundle-" + index, s, x, y + ty, 1, null, 8));
            foreach (var m in mountains)
            {
                var (mw, mh) = MountainSize(m.rows);
                float mx = x + m.cx - mw / 2, my = y + ty + m.bottom - mh;
                float size = m.rows >= 4 ? 24 : 26, h = (float)Math.Round(size * 0.64), v = (float)Math.Round(size * 0.52);
                Twinkle(list, $"bundle-{index}-{m.id}-tw1", mx + mw / 2 + h * 0.7f, my - 4, 11, m.twinkle, 1.8, 0, 0, 0);
                Twinkle(list, $"bundle-{index}-{m.id}-tw2", mx + 1, my + v * (m.rows - 2), 8, "#ffffff", 2.4, 0.7, 0, 0);
            }
            Fx(list, "bundle-" + index, x, y + ty, pad, 0, 0, "#ffffff", 3600, index * 500, 0.35f, false);
            var bf = f["btn"];
            string was = Prof.Str(Prof.Get(o, "was"));
            string price = PriceLabel("offer:" + Prof.Str(o["id"]));
            DealBtn(list, "bundle:" + Prof.Str(o["id"]), new Frame(x + ox + bf.X, y + ty + oy + bf.Y, bf.W, bf.H), 18, false, (b, w, h) =>
            {
                var lt = BtnLabel(GREEN_RIM, 22);
                var wt = T(Black, 13, "#1d6a3a");
                float rw = (was != null ? W(was, wt) + 8 : 0) + W(price, lt), bx = (w - rw) / 2;
                if (was != null) { Strike(b, was, bx, (h - LH(wt)) / 2, wt); bx += W(was, wt) + 8; }
                b.Text(price, bx, (h - LH(lt)) / 2, lt);
            });
            if (tag != null)
            {
                var tt = T(Black, 11, "#7a3d00", 0.8f);
                string text = $"★ {tag} ★";
                float tw = W(text, tt) + 24 + 2 * Bw(2.5f), th = LH(tt) + 6 + 2 * Bw(2.5f);
                var tg = new UiSvg(tw, th);
                tg.Box(0, 0, tw, th, new BoxStyle { Radius = 999, Gradient = new[] { "#ffe14d", "#ffb000" }, BorderWidth = Bw(2.5f), BorderColor = "#ffffff" });
                tg.Text(text, 12 + Bw(2.5f), 3 + Bw(2.5f), tt);
                list.Add(Piece("tag-" + index, tg, x + (COL_W - tw) / 2, y + ty - 12, 1, null, 4));
            }
            if (off.Length > 0 && off[0] != "") Burst(list, "burst-" + index, x + COL_W + 8 - 74, y + ty - 14, 74, off[0], off.Length > 1 ? off[1] : null, new[] { "#fff36b", "#ffb000" }, "#a3001f");
        }

        // Mountain: a mountain of coins or gems, rows of pieces heaped into a peak, one more piece in each row down, every
        // piece a little turned (TILT), the rows above the base drooping at their ends so the heap is a rounded mound; the
        // front row drawn last (nearest). `start`: where the six coins or gems start mixing through the heap.
        static readonly float[] TILT = { -14, 9, -5, 12, -9, 4, 15, -11, 6, -3 };
        static (float w, float h) MountainSize(int rows)
        {
            float size = rows >= 4 ? 24 : 26, h = (float)Math.Round(size * 0.64), v = (float)Math.Round(size * 0.52);
            return ((rows - 1) * h + size, (rows - 1) * v + size + 4);
        }
        static void Mountain(UiSvg s, bool gems, int rows, int start, float x, float y)
        {
            float size = rows >= 4 ? 24 : 26, h = (float)Math.Round(size * 0.64), v = (float)Math.Round(size * 0.52);
            float w = MountainSize(rows).w;
            int n = 0;
            for (int r = 0; r < rows; r++)
                for (int c = 0; c <= r; c++)
                {
                    float ps = (float)Math.Round(size * (0.86 + 0.14 * r / Math.Max(1, rows - 1)));
                    float off = (c - r / 2f) / Math.Max(1, (rows - 1) / 2f);
                    float droop = r < rows - 1 ? off * off * v * 0.6f : 0;
                    float px = x + w / 2 + (c - r / 2f) * h - ps / 2, py = y + r * v + (size - ps) + droop;
                    s.Open($"transform=\"translate({F(px + ps / 2)} {F(py + ps / 2)}) rotate({F(TILT[n % TILT.Length])}) translate({F(-ps / 2)} {F(-ps / 2)})\"");
                    s.Image(gems ? Gem(start + n) : Coin(start + n), 0, 0, ps, ps);
                    s.Close();
                    n++;
                }
        }

        void Burst(List<ScreenPiece> list, string id, float x, float y, float size, string top, string bottom, string[] colors, string ink)
        {
            var pts = new List<string>();
            for (int i = 0; i < 28; i++)
            {
                double r = i % 2 == 1 ? 0.8 : 1, a = Math.PI * i / 14;
                pts.Add($"{(50 + 48 * r * Math.Sin(a)).ToString("0.0", System.Globalization.CultureInfo.InvariantCulture)},{(50 - 48 * r * Math.Cos(a)).ToString("0.0", System.Globalization.CultureInfo.InvariantCulture)}");
            }
            string d = "M" + string.Join(" L", pts) + " Z";
            var s = new UiSvg(size, size);
            var gid = s.NewId("bf");
            s.Def($"<radialGradient id=\"{gid}\" cx=\"40%\" cy=\"35%\" r=\"70%\"><stop offset=\"0\" stop-color=\"{colors[0]}\"/><stop offset=\"1\" stop-color=\"{colors[1]}\"/></radialGradient>");
            s.Drawing($"<path d=\"{d}\" fill=\"{ink}\" transform=\"translate(0 4)\"/><path d=\"{d}\" fill=\"#ffffff\"/><path d=\"{d}\" fill=\"url(#{gid})\" transform=\"translate(50 50) scale(0.88) translate(-50 -50)\"/>", 0, 0, size, size, "0 0 100 100");
            float k = size / 100;
            float fs = top != null && top.Length > 3 ? 23 : 28;
            s.Glyphs(top, 50 * k - W(top, T(Black, fs * k, ink)) / 2, (bottom != null ? 50 : 60) * k, Black, fs * k, 0, ink);
            if (bottom != null) s.Glyphs(bottom, 50 * k - W(bottom, T(Black, 16 * k, ink)) / 2, 70 * k, Black, 16 * k, 0, ink);
            double t = Swing(id, 1100, 1100);
            var m = Affine.Translate(x, y) * About(size, size, Affine.Rotate(-10 + 18 * t) * Affine.ScaleBy(1 + 0.06 * t, 1 + 0.06 * t));
            list.Add(new ScreenPiece { Id = id, Svg = s.Markup, W = size, H = size, Margin = 6, Transform = m });
        }

        void NoAdsOwned(List<ScreenPiece> list, float x, float y)
        {
            var t1 = T(Kit.Display, 16, "#17803a"); var t2 = T(Body, 11.5f, "#6a4a9a");
            // (owned: padding 12 and a 2 border round the row; at the top of its column, as every card)
            float h = Math.Max(26, LH(t1) + LH(t2)) + 28;
            var s = new UiSvg(COL_W, h);
            s.Box(0, 0, COL_W, h, new BoxStyle { Radius = 20, Background = "rgba(255,255,255,0.88)", BorderWidth = 2, BorderColor = "#ffffff" });
            Check(s, 14, (h - 26) / 2, 26);
            float ty = (h - LH(t1) - LH(t2)) / 2;
            s.Text("Ads are off", 14 + 26 + 10, ty, t1);
            s.Text("Thanks for supporting the squad!", 14 + 26 + 10, ty + LH(t1), t2);
            list.Add(Piece("noads-owned", s, x, y, 1, null, 4));
        }

        void PassCard(List<ScreenPiece> list, IDictionary<string, object> pass, float x, float y, double now, double ends)
        {
            // (the default pass ended on 2026-10-31: it shows only for a config/offers pass still running; drawn plainly)
            var nodes = Prof.List(pass["nodes"]).Select(Prof.Map).ToList();
            string season = Prof.Str(Prof.Get(pass, "season"));
            double xp = Prof.Num(Prof.Get(_profile, "passXp"));
            bool prem = Prof.Truthy(Prof.Get(Prof.Map(Prof.Get(_profile, "passPrem")), season));
            var got = Prof.Map(Prof.Get(Prof.Map(Prof.Get(_profile, "passGot")), season));
            double max = Prof.Num(nodes[nodes.Count - 1]["xp"]); if (max == 0) max = 1;
            var s = new UiSvg(COL_W, COL_H);
            var pad = Card(s, 0, 0, COL_W, COL_H, "#2a0a4a", new[] { "#4a1a7a", "#6a22b0", "#c2410c" }, new[] { 0f, 0.55f, 1 }, 0, 0, 1, 1);
            var st = T(Black, 9.5f, "#ffc27a", 1);
            s.Image("Shop/img/crown", pad.X + 14, pad.Y + 14, 40, 34, "xMidYMid meet");
            s.Text(((Prof.Str(Prof.Get(pass, "name")) ?? "Season pass").ToUpperInvariant()), pad.X + 60, pad.Y + 12, st);
            s.Text("Season pass", pad.X + 60, pad.Y + 12 + LH(st), T(Kit.Display, 23, "#ffffff", 0, 27, Outline3("#2a0a4a", 2.5f)));
            if (ends > 0)
            {
                int days = (int)Math.Max(0, Math.Ceiling((ends - now) / 864e5));
                var lt = T(Black, 9.5f, "#ffffff", 0.5f); string l = $"{days} DAY{(days == 1 ? "" : "S")} LEFT";
                float lw = W(l, lt) + 20;
                s.Box(pad.Right - 14 - lw, pad.Y + 18, lw, LH(lt) + 10, new BoxStyle { Radius = 999, Background = "#ff8a3d", BorderWidth = 2, BorderColor = "#ffffff" });
                s.Text(l, pad.Right - 14 - lw + 10, pad.Y + 23, lt);
            }
            float by = pad.Y + 62, bw = pad.W - 28;
            Bar(s, pad.X + 14, by, bw, 22, (float)Math.Max(3, Math.Min(100, Math.Round(xp / max * 100))), "rgba(0,0,0,0.3)", 2.5f, "#ffffff", 11, new[] { "#ffd84a", "#ff8a3d", "#ff5cc6" });
            TxtC(s, $"{Prof.Fmt(xp)} / {Prof.Fmt(max)} PASS XP", pad.X + pad.W / 2, by + 3, T(Kit.Display, 12, "#ffffff", 0, 0, new[] { new Shadow("#2a0a4a", 0, 1.2f, 1) }));
            float nx = pad.X + 14, ny = by + 34;
            for (int i = 0; i < nodes.Count && nx < pad.Right; i++)
            {
                var r = nodes[i];
                bool claimed = Prof.Truthy(Prof.Get(got, i.ToString())), reach = xp >= Prof.Num(r["xp"]), lockd = Prof.Truthy(Prof.Get(r, "prem")) && !prem, can = reach && !claimed && !lockd;
                s.Box(nx, ny, 78, 87, new BoxStyle { Radius = 20, Background = can ? "#b86200" : Prof.Truthy(Prof.Get(r, "prem")) ? "#c47a00" : "#6a3aa8" });
                s.Box(nx + 2, ny + 2, 74, 80, new BoxStyle { Radius = 18, Gradient = can ? new[] { "#fff6c4", "#ffd84a" } : Prof.Truthy(Prof.Get(r, "prem")) ? new[] { "#fff3d0", "#ffd98a" } : new[] { "#f6efff", "#dcc6ff" }, BorderWidth = Bw(2.5f), BorderColor = "#ffffff", Opacity = claimed ? 0.55f : 1 });
                TxtC(s, RewardText(r), nx + 39, ny + 60, T(Kit.Display, 12.5f, Prof.Truthy(Prof.Get(r, "prem")) ? "#7a3d00" : "#45107a"));
                _hits.Add("pass:" + i, x + nx, y + ny, 78, 87);
                nx += 88;
            }
            list.Add(Piece("pass", s, x, y, 1, null, 8));
        }

        // ---- Gems ----------------------------------------------------------------------------------------------------------
        static readonly (string[] bg, string rim, string glow)[] PACK_LOOK =
        {
            (new[] { "#f0f9ff", "#c7e9ff" }, "#2f7fd6", "#ffffff"), (new[] { "#ecfffb", "#b6f0e6" }, "#14917e", "#ffffff"), (new[] { "#fff3ea", "#ffd0b0" }, "#d0561c", "#ffffff"),
            (new[] { "#ecfff5", "#b3f0d2" }, "#16a86a", "#ffffff"), (new[] { "#fffbe6", "#ffdc8a" }, "#c46a00", "#fff6c4"), (new[] { "#fff6e2", "#ffe0a8", "#ffc98a" }, "#a04a00", "#fff6c4"),
        };
        static readonly float[][] PILE = { new[] { 0f }, new[] { -0.6f, 0.6f }, new[] { -1f, 0, 1 }, new[] { -1.4f, -0.45f, 0.45f, 1.4f }, new[] { -1.6f, -0.8f, 0, 0.8f, 1.6f }, new[] { -2f, -1, 0, 1, 2 } };
        static readonly string[] SWAP_TAGS = { "", "+12%", "+25%" };

        void Gems(List<ScreenPiece> list)
        {
            var packs = ShopData.Packs(_offers);
            var first = Prof.Map(Prof.Get(_profile, "gemFirst"));
            bool anyDouble = packs.Any(p => !Prof.Truthy(Prof.Get(first, Prof.Str(p["product"]))));
            int packsShown = Math.Min(_shown, packs.Count + 1);
            float y = 108 + 2;
            if (anyDouble)
            {
                var a = T(Kit.Display, 15, "#e0123f"); var b = T(Black, 11.5f, "#7a3a00");
                string t2 = "FIRST BUY BONUS · every pack gives double gems the first time you buy it";
                float rw = 14 + W("2X", a) + 8 + W(t2, b) + 14 + 4;
                var s = new UiSvg(rw, 26);
                s.Box(0, 0, rw, 26, new BoxStyle { Radius = 999, Gradient = new[] { "#fffbe0", "#ffe27a", "#ffb000" }, GradientAngle = 90, BorderWidth = 2, BorderColor = "#a04a00" });
                s.Text("2X", 16, (26 - LH(a)) / 2, a);
                s.Text(t2, 16 + W("2X", a) + 8, (26 - LH(b)) / 2, b);
                list.Add(Piece("gem-ribbon", s, (SW - rw) / 2, y, 1, null, 4));
                y += 26 + 10;
            }
            // the packs: a row (paddingTop 10), bottoms aligned (alignItems flex-end)
            var packH = new List<float>();
            var packSvgs = new List<UiSvg>();
            for (int pi = 0; pi < Math.Min(packsShown, packs.Count); pi++) { var (s, h) = Pack(packs[pi], pi, !Prof.Truthy(Prof.Get(first, Prof.Str(packs[pi]["product"])))); packSvgs.Add(s); packH.Add(h); }
            int n = packs.Count;
            float rowW = n * 120 + (n - 1) * 10, x0 = (SW - rowW) / 2, rowH = packH.Count > 0 ? packH.Max() : 0;
            float py = y + 10;
            for (int pi = 0; pi < packSvgs.Count; pi++)
            {
                float px = x0 + pi * 130, ty = py + rowH - packH[pi];
                list.Add(Piece("pack-" + pi, packSvgs[pi], px, ty + (_pressed == "pack:" + pi ? 0 : 0), 1, null, 16));
                var p = packs[pi];
                _hits.Add("pack:" + pi, px, ty, 120, packH[pi]);
            }
            if (packsShown <= packs.Count) return;
            // the swaps
            float sy = py + rowH + 10;
            var lab = T(Kit.Display, 14, CREAM, 0, 0, new[] { new Shadow("rgba(107,68,38,0.8)", 0, 1.5f, 1) });
            var cT = T(Kit.Display, 14, "#5b3418"); var gT = T(Kit.Display, 13, "#5b3418"); var tagT = T(Black, 8.5f, "#ffffff");
            // a chip: border 2, paddingLeft 8, the coin, gap 5, the coins, gap 5, the price pill (its 1.5 border as Chrome
            // draws it, Bw: 1), paddingRight 4, border 2
            float pb = Bw(1.5f);
            var chips = ShopData.Swaps.Select((w, i) => (w, i, cw: 8 + 22 + 5 + W(Prof.Fmt(w.coins), cT) + 5 + (8 + 18 + 2 + W(Prof.Fmt(w.gems), gT) + 8 + 2 * pb) + 4 + 4)).ToList();
            float total = W("Swap gems for coins", lab) + chips.Sum(c => c.cw + 10);
            float sx = (SW - total) / 2;
            var ls = new UiSvg(W("Swap gems for coins", lab), LH(lab));
            ls.Text("Swap gems for coins", 0, 0, lab);
            list.Add(Piece("swaps-label", ls, sx, sy + (36 - LH(lab)) / 2, 1, null, 4));
            sx += W("Swap gems for coins", lab) + 10;
            foreach (var (w, i, cw) in chips)
            {
                var s = new UiSvg(cw, 36);
                s.Box(0, 0, cw, 36, new BoxStyle { Radius = 999, Background = "#fff6e2", Borders = new[] { 2f, 2, 4, 2 }, BorderColor = "#6b4426" });
                float cx = 2 + 8;
                s.Image(Coin(i + 1), cx, 2 + (30 - 22) / 2, 22, 22); cx += 22 + 5;
                s.Text(Prof.Fmt(w.coins), cx, 2 + (30 - LH(cT)) / 2, cT); cx += W(Prof.Fmt(w.coins), cT) + 5;
                float pw = 8 + 18 + 2 + W(Prof.Fmt(w.gems), gT) + 8 + 2 * pb;
                s.Box(cx, 2 + (30 - 26) / 2, pw, 26, new BoxStyle { Radius = 999, Background = "#ffd24a", BorderWidth = Bw(1.5f), BorderColor = "#9c4d06" });
                s.Image(Gem(0), cx + 1 + 8, 2 + (30 - 18) / 2, 18, 18);
                s.Text(Prof.Fmt(w.gems), cx + 1 + 8 + 18 + 2, 2 + (30 - LH(gT)) / 2, gT);
                if (SWAP_TAGS[i] != "")
                {
                    float tw = W(SWAP_TAGS[i], tagT) + 8;
                    // (right -6, top -9: from the padding box, inside the chip's 2 border)
                    s.Box(cw + 4 - tw, -7, tw, LH(tagT), new BoxStyle { Radius = 999, Background = "#26a94e" });
                    s.Text(SWAP_TAGS[i], cw + 4 - tw + 4, -7, tagT);
                }
                list.Add(Piece("swap-" + i, s, sx, sy + (_pressed == "swap:" + i ? 2 : 0), 1, null, 12));
                _hits.Add("swap:" + i, sx, sy, cw, 36);
                sx += cw + 10;
            }
        }

        (UiSvg, float) Pack(IDictionary<string, object> p, int pi, bool dbl)
        {
            var look = PACK_LOOK[Math.Min(pi, PACK_LOOK.Length - 1)];
            var pl = PILE[Math.Min(PILE.Length - 1, Math.Max(0, (int)(Prof.Num(Prof.Get(p, "icons"), pi + 1)) - 1))];
            bool big = pi >= 3;
            double gems = Prof.Num(p["gems"]);
            var amtT = T(Kit.Display, 21, "#ffffff", 0, 25, Outline3(look.rim, 2));
            var wasT = T(Black, 11, "#a898c8"); var nameT = T(Black, 10, look.rim, 1);
            string name = (Prof.Str(Prof.Get(p, "name")) ?? "").ToUpperInvariant();
            // pack: paddingTop 12, padH 7, paddingBottom 8; gap 2: pile 64, the amount, the name row, the button (marginTop 4, 32)
            float rowH = Math.Max(dbl ? LH(wasT) : 0, LH(nameT));
            float innerH = 12 + 64 + 2 + LH(amtT) + 2 + rowH + 2 + 4 + 32 + 8;
            float faceH = innerH + 6, h = faceH + 2.5f + 7;
            var s = new UiSvg(120, h);
            s.Box(0, 0, 120, h, new BoxStyle { Radius = 26, Background = look.rim });
            s.Box(2.5f, 2.5f, 115, faceH, new BoxStyle { Radius = 23.5f, Gradient = look.bg, BorderWidth = 3, BorderColor = "#ffffff" });
            var clip = s.NewId("pk");
            s.Def($"<clipPath id=\"{clip}\"><path d=\"{UiSvg.RRect(5.5f, 5.5f, 109, faceH - 6, new[] { 20.5f, 20.5f, 20.5f, 20.5f })}\"/></clipPath>");
            s.Open($"clip-path=\"url(#{clip})\"");
            float cy = 5.5f + 12;
            // RaysSpin 200 behind the pile (top -60), turning
            if (Prof.Truthy(Prof.Get(p, "tag"))) Rays(s, 60 - 100, 5.5f - 60, 200, "#ffffff", 0.55f, 360 * Spin("pack-rays-" + pi, 18000));
            // the glow and the pile
            var gid = s.NewId("pg");
            s.Def($"<radialGradient id=\"{gid}\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"{look.glow}\" stop-opacity=\"0.95\"/><stop offset=\"0.55\" stop-color=\"{look.glow}\" stop-opacity=\"0.38\"/><stop offset=\"1\" stop-color=\"{look.glow}\" stop-opacity=\"0\"/></radialGradient>");
            s.Raw($"<circle cx=\"60\" cy=\"{F(cy - 22 + 60)}\" r=\"60\" fill=\"url(#{gid})\"/>");
            var sizes = pl.Select(o => (float)Math.Round((big ? 50 : 46) - Math.Abs(o) * 7 + Math.Min(pi, 3) * 1.5)).ToArray();
            float pw = sizes.Sum() - 12 * sizes.Length, px = 60 - pw / 2;
            for (int i = 0; i < pl.Length; i++)
            {
                float sz = sizes[i], mb = (float)Math.Round(Math.Max(0, 8 - Math.Abs(pl[i]) * 6));
                float gx = px - 6, gy = cy + 64 - mb - sz;
                s.Open($"transform=\"translate({F(gx + sz / 2)} {F(gy + sz / 2)}) rotate({F(Math.Round(pl[i] * 10))}) translate({F(-sz / 2)} {F(-sz / 2)})\"");
                s.Image(Gem(pi + i), 0, 0, sz, sz);
                s.Close();
                px += sz - 12;
            }
            cy += 64 + 2;
            string amt = Prof.Fmt(dbl ? gems * 2 : gems);
            TxtC(s, amt, 60, cy, amtT);
            cy += LH(amtT) + 2;
            float rw = (dbl ? W(Prof.Fmt(gems), wasT) + 4 : 0) + W(name, nameT), rx = 60 - rw / 2;
            if (dbl) { Strike(s, Prof.Fmt(gems), rx, cy + (rowH - LH(wasT)) / 2, wasT); rx += W(Prof.Fmt(gems), wasT) + 4; }
            s.Text(name, rx, cy + (rowH - LH(nameT)) / 2, nameT);
            cy += rowH + 2 + 4;
            // the price (a royal gold plaque), radius 13
            Plaque(s, 5.5f + 7, cy, 109 - 14, 32, "gold", 13);
            string key = ShopData.ProductKey(Prof.Str(p["product"]));
            string price = key != null ? PriceLabel(key) : "";
            var lt = BtnLabel(GREEN_RIM, 15);
            TxtC(s, price, 60, cy + (32 - LH(lt)) / 2, lt);
            if (dbl)
            {
                var xt = T(Kit.Display, 13, "#ffffff");
                float xw = W("2X", xt) + 12 + 4, xh = LH(xt) + 4;
                s.Open($"transform=\"translate({F(5.5f + 8 + xw / 2)} {F(5.5f + 8 + xh / 2)}) rotate(-8) translate({F(-xw / 2)} {F(-xh / 2)})\"");
                s.Box(0, 0, xw, xh, new BoxStyle { Radius = 8, Background = "#e01e4a", BorderWidth = 2, BorderColor = "#ffffff" });
                s.Text("2X", 8, 2, xt);
                s.Close();
            }
            s.Close();
            string tag = Prof.Str(Prof.Get(p, "tag"));
            if (tag != null)
            {
                var tt = T(Black, 9.5f, "#ffffff", 0.6f);
                float tw = W(tag, tt) + 24, th = LH(tt) + 8;
                s.Box(60 - tw / 2, -11, tw, th, new BoxStyle { Radius = 999, Gradient = tag == "BEST VALUE" ? new[] { "#7be884", "#26a94e" } : new[] { "#ffb347", "#ff7a1e" }, BorderWidth = 2, BorderColor = "#ffffff" });
                s.Text(tag, 60 - tw / 2 + 12, -11 + 4, tt);
            }
            return (s, h);
        }

        bool TapDeals(string h)
        {
            if (h == "noads") { BuyProduct("removeAds"); return true; }
            if (h.StartsWith("jar:"))
            {
                var o = ShopData.OfferList(_offers).FirstOrDefault(x => Prof.Str(x["id"]) == h.Substring(4));
                if (o != null && ShopData.JarGems(_profile, o) < 100) Flash("The jar is nearly empty. Play to fill it!");
                else BuyProduct("offer:" + h.Substring(4));
                return true;
            }
            if (h.StartsWith("bundle:")) { BuyProduct("offer:" + h.Substring(7)); return true; }
            if (h.StartsWith("pack:"))
            {
                var p = ShopData.Packs(_offers)[int.Parse(h.Substring(5))];
                var key = ShopData.ProductKey(Prof.Str(p["product"]));
                if (key != null) BuyProduct(key);
                return true;
            }
            if (h.StartsWith("swap:")) { Swap(int.Parse(h.Substring(5))); return true; }
            if (h == "streak-claim") { ClaimReward("streakClaim", null); return true; }
            if (h.StartsWith("day:"))
            {
                var streak = ShopData.Streak(_offers);
                var (cnt, idx, doneToday) = StreakState(streak);
                int i = int.Parse(h.Substring(4));
                bool done = doneToday ? i <= idx : i < idx, today = !doneToday && i == idx;
                if (today) ClaimReward("streakClaim", null);
                else Flash(done ? "Already claimed" : $"Come back on day {i + 1}");
                return true;
            }
            if (h.StartsWith("pass:"))
            {
                int i = int.Parse(h.Substring(5));
                var pass = ShopData.Pass(_offers);
                var r = Prof.Map(Prof.List(pass["nodes"])[i]);
                string season = Prof.Str(Prof.Get(pass, "season"));
                bool claimed = Prof.Truthy(Prof.Get(Prof.Map(Prof.Get(Prof.Map(Prof.Get(_profile, "passGot")), season)), i.ToString()));
                if (claimed) return true;
                if (Prof.Num(Prof.Get(_profile, "passXp")) < Prof.Num(r["xp"])) { Flash($"Open more chests to reach {Prof.JsStr(Prof.Num(r["xp"]))} pass XP"); return true; }
                if (Prof.Truthy(Prof.Get(r, "prem")) && !Prof.Truthy(Prof.Get(Prof.Map(Prof.Get(_profile, "passPrem")), season))) { Flash("This reward needs the season pass"); return true; }
                ClaimReward("passClaim", new Dictionary<string, object> { ["i"] = (double)i });
                return true;
            }
            return false;
        }

        async void BuyProduct(string key)
        {
            if (key == "removeAds" && Prof.Truthy(Prof.Get(_profile, "adsFree"))) { Flash("Ads are already off"); return; }
            if (OnBuyProduct == null) { Flash("Purchases aren't in the Unity version yet"); return; }
            IDictionary<string, object> r;
            try { r = await OnBuyProduct(key); }
            catch (Exception e)
            {
                // (Backend.BillingException: its words for the player; a cancel says nothing)
                if (e.GetType().Name != "BillingException" || (string)e.GetType().GetField("Code")?.GetValue(e) != "cancelled") Flash(e.Message);
                return;
            }
            if (r == null) return;
            if (Prof.Truthy(Prof.Get(r, "pending"))) { Flash("Payment pending: it'll be added once Google Play clears it"); return; }
            if (Prof.Str(Prof.Get(r, "granted")) == "restored") { Flash("Restored your earlier purchase"); return; }
            string g = Prof.Str(Prof.Get(r, "granted"));
            if (g == "bundle")
            {
                var chests = (Prof.List(Prof.Get(r, "chests")) ?? new List<object>()).Select(Prof.Map).Where(c => c != null).ToList();
                if (chests.Count > 0) OnOpenChest?.Invoke(new ChestRequest { Group = Prof.Str(chests[0]["group"]), Size = Prof.Str(chests[0]["size"]), Rolled = chests });
            }
            else if (g == "pass") Flash("Season pass unlocked!");
            else if (g == "gems" && Prof.Truthy(Prof.Get(r, "offer"))) Flash($"Gem jar broken: +{Prof.Fmt(Prof.Num(Prof.Get(r, "gems")))} gems!");
        }

        async void Swap(int i)
        {
            var w = Wallet;
            var r = await Run("swap", new Dictionary<string, object> { ["i"] = (double)i }, _ => ShopData.Swaps[i].gems - w.gems);
            if (r != null) Flash($"+{Prof.Fmt(Prof.Num(Prof.Get(r, "coins")))} coins");
        }

        /// <summary>The streak's or a pass's claim: coins or gems (the pills count up as the profile brings them), or a chest
        /// (the smash).</summary>
        async void ClaimReward(string move, Dictionary<string, object> args)
        {
            var r = await Run(move, args);
            if (r == null) return;
            if (Prof.Str(Prof.Get(r, "kind")) != "chest") Audio.Snd.Play("coinShower");
            if (Prof.Str(Prof.Get(r, "kind")) == "chest")
            {
                var c = Prof.Map(Prof.Get(r, "chest"));
                if (c != null) OnOpenChest?.Invoke(new ChestRequest { Group = Prof.Str(c["group"]), Size = Prof.Str(c["size"]), Rolled = new List<IDictionary<string, object>> { c } });
            }
        }
    }

    /// <summary>Twinkle's ✦ as Chrome draws it (Resources/Shop/twinkle.json, tools/unity/export-shop.mjs): per size and
    /// colour, the picture (with its glow) and the glyph's box.</summary>
    public static class TwinkleArt
    {
        static Dictionary<string, (string href, float w, float h, float px, float py, float pw, float ph)> _all;
        public static (string href, float w, float h, float px, float py, float pw, float ph)? Of(float size, string color)
        {
            if (_all == null)
            {
                _all = new Dictionary<string, (string, float, float, float, float, float, float)>();
                var t = Roster.ReadText?.Invoke("Shop/twinkle");
                if (t != null)
                    foreach (var kv in Prof.Map(Backend.Json.Parse(t)))
                    {
                        var m = Prof.Map(kv.Value);
                        _all[kv.Key] = ("Shop/img/" + (string)m["file"], (float)Prof.Num(m["w"]), (float)Prof.Num(m["h"]), (float)Prof.Num(m["px"]), (float)Prof.Num(m["py"]), (float)Prof.Num(m["pw"]), (float)Prof.Num(m["ph"]));
                    }
            }
            return _all.TryGetValue(Prof.JsStr(size) + color, out var v) ? v : ((string, float, float, float, float, float, float)?)null;
        }
    }
}
