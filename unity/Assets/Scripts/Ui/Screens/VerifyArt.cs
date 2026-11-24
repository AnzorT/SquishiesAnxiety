// src/screens/VerifyEmailScreen.js (develop, 2026-11-20: the sign-in screen's look, src/screens/auth/kit.js) from the
// Unity code: the house behind, Mittens and the logo along the top where they stood on the sign-in screen (so only the
// panel changes after registering), and a wood panel: the mail icon and "Check your email" in gold lettering, "We sent
// a link to <email>. …", the note's line (always there, so nothing moves: a red pill, or the green "Sent again"), the
// gold I'VE VERIFIED button (its light sweeping across) and two wood buttons, Send it again and Log out. VerifyModel is
// what its buttons do, with the app's notes word for word.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Facebook.Yoga;
using SquishSquad.Vector;

namespace SquishSquad.Ui.Screens
{
    public interface IVerifyBackend
    {
        Task<bool> ReloadVerified();
        Task SendVerification();
    }

    public sealed class FirebaseVerifyBackend : IVerifyBackend
    {
        readonly Backend.FirebaseClient _fb;
        public FirebaseVerifyBackend(Backend.FirebaseClient fb) { _fb = fb; }
        public Task<bool> ReloadVerified() => _fb.Auth.ReloadVerified();
        public Task SendVerification() => _fb.Auth.SendVerification();
    }

    public sealed class VerifyModel
    {
        public string Email = "";
        public bool Busy;
        public string Note = "";
        /// <summary>The note is a problem (a red pill), not "Sent again" (green).</summary>
        public bool NoteBad => !string.IsNullOrEmpty(Note) && !Note.StartsWith("Sent again", StringComparison.Ordinal);

        /// <summary>"I've verified": true once Firebase says the address is confirmed (onVerified).</summary>
        public async Task<bool> Check(IVerifyBackend fb)
        {
            if (Busy) return false;
            Busy = true;
            try
            {
                if (await fb.ReloadVerified()) return true;
                Note = "Not yet — tap the link in the email first. Check your spam folder too.";
            }
            catch (Exception)
            {
                Note = "Could not check right now. Try again in a moment.";
            }
            finally
            {
                Busy = false;
            }
            return false;
        }

        /// <summary>"Send it again" (Firebase limits how often).</summary>
        public async Task Resend(IVerifyBackend fb)
        {
            try
            {
                await fb.SendVerification();
                Note = $"Sent again to {Email}.";
            }
            catch (Exception)
            {
                Note = "Please wait a minute before sending another.";
            }
        }
    }

    public sealed class VerifyUi
    {
        public string Pressed;
        public double DotsMs, GlintMs;
        public double NoteT = 1;        // the note fading up when it changes (useFadeUp)
        public bool CreatureShown;
    }

    public sealed class VerifyArt
    {
        const string MAIL = "M3.5 6.5h17v11h-17Z M4 7l8 6.2L20 7";
        static readonly Shadow[] SoftInk = { new Shadow("rgba(80,40,12,0.75)", 0, 1, 0) };
        static readonly TextStyle TextSt = new TextStyle { Font = AuthArt.Heavy, Size = 14.5f, LineHeight = 20, Color = AuthArt.CREAM, Shadows = SoftInk };
        static readonly TextStyle EmailSt = new TextStyle { Font = AuthArt.Black, Size = 14.5f, LineHeight = 20, Color = AuthArt.GOLD_TXT, Shadows = SoftInk };
        static readonly TextStyle SentSt = new TextStyle { Font = AuthArt.Black, Size = 12.5f, LineHeight = 16, Color = "#d6ffb8", Shadows = new[] { new Shadow("rgba(40,60,10,0.8)", 0, 1, 0) } };
        static readonly TextStyle LinkSt = SquishSquad.Screens.Kit.Ink(15);
        const string Title = "Check your email";
        const string Label = "I\u2019VE\u2002VERIFIED";   // (an en space between the words: the thick outline closed up a plain one)

        public readonly float W, H;
        readonly AuthSizes Z;
        public VerifyArt(float w, float h) { W = w; H = h; Z = AuthSizes.For(w, h); }
        float TitleSize => Z.H < 376 ? 21 : 23;

        TextFlow Body(string email) => new TextFlow(TextSt, 0.5f, new Run("We sent a link to ", TextSt), new Run(email ?? "", EmailSt), new Run(". Tap it to confirm it's really you, then come back here.", TextSt));
        static TextFlow NoteFlow(VerifyModel m) => new TextFlow(m.Note, m.NoteBad ? AuthArt.ErrorText : SentSt, 0.5f);

        public Dictionary<string, Frame> Layout(VerifyModel m)
        {
            var z = Z;
            var root = new FlexNode("root").AlignItems(YGAlign.Center).Padding(YGEdge.Top, z.Top).Padding(YGEdge.Bottom, z.Top);
            var header = root.Add(new FlexNode("header").Row().AlignItems(YGAlign.Center).Justify(YGJustify.Center).Gap(6).Height(z.Head));
            header.Add(new FlexNode("mittens").Size(z.Head, z.Head));
            header.Add(new FlexNode("logo").Size(z.LogoW, z.LogoW / (981f / 133)));
            var area = root.Add(new FlexNode("area").Flex(1).AlignSelf(YGAlign.Stretch).AlignItems(YGAlign.Center).Justify(YGJustify.Center));
            float cardW = Math.Min(z.CardW, z.H < 376 ? 470 : 500);
            var card = area.Add(new FlexNode("card").Width(cardW).PadH(z.PadH).Padding(YGEdge.Top, z.PadT).Padding(YGEdge.Bottom, z.PadB).Gap(z.Gap));
            var title = card.Add(new FlexNode("title").Row().AlignItems(YGAlign.Center).Justify(YGJustify.Center).Gap(8));
            title.Add(new FlexNode("mail").Size(26, 26));
            var (tw, th) = SquishSquad.Screens.Kit.LetteringSize(Title, TitleSize);
            title.Add(new FlexNode("title-t").Size(tw, th));
            card.Add(FlexNode.Leaf("text", Body(m.Email).Measure).PadH(6));
            var note = card.Add(new FlexNode("note-row").AlignItems(YGAlign.Center).Justify(YGJustify.Center).Margin(YGEdge.Top, -3).Margin(YGEdge.Bottom, -3));
            Facebook.Yoga.YGNodeStyleAPI.YGNodeStyleSetMinHeight(note.Node, 20);
            if (!string.IsNullOrEmpty(m.Note))
            {
                var nw = note.Add(new FlexNode("note"));
                if (m.NoteBad) { nw.PadH(12).PadV(2).Border(1.6f).Justify(YGJustify.Center); Facebook.Yoga.YGNodeStyleAPI.YGNodeStyleSetMinHeight(nw.Node, 20); }
                nw.Add(FlexNode.Leaf("note-t", NoteFlow(m).Measure));
            }
            var btn = card.Add(new FlexNode("btn-ring").Height(z.Btn).AlignItems(YGAlign.Center).Justify(YGJustify.Center));
            if (m.Busy) btn.Add(new FlexNode("dots").Row().AlignItems(YGAlign.FlexEnd).Gap(6).Height(20).With(new FlexNode("dot0").Size(10, 10), new FlexNode("dot1").Size(10, 10), new FlexNode("dot2").Size(10, 10)));
            else { var (lw, lh) = SquishSquad.Screens.Kit.LetteringSize(Label, z.BtnFont); btn.Add(new FlexNode("label").Size(lw, lh)); }
            var links = card.Add(new FlexNode("links").Row().Gap(12));
            foreach (var (id, text) in new[] { ("resend", "Send it again"), ("logout", "Log out") })
            {
                var l = links.Add(new FlexNode(id).Flex(1).Height(z.Social).Row().AlignItems(YGAlign.Center).Justify(YGJustify.Center).Gap(8));
                l.Add(new FlexNode(id + "-icon").Size(17, 17));
                l.Add(FlexNode.Leaf(id + "-t", new TextFlow(text, LinkSt).Measure));
            }
            root.Layout(W, H);
            var f = new Dictionary<string, Frame>();
            root.Walk(n => f[n.Name] = n.Frame);
            return f;
        }

        public List<ScreenPiece> Pieces(VerifyModel m, VerifyUi ui, Dictionary<string, Frame> f)
        {
            var z = Z;
            var list = new List<ScreenPiece>();
            AuthArt.Backdrop(list, W, H);
            AuthArt.Header(list, f["mittens"], f["logo"], ui.CreatureShown);
            void Add(string id, UiSvg s, Frame at, float op = 1, Affine? extra = null, float margin = 6) =>
                list.Add(new ScreenPiece { Id = id, Svg = s.Markup, W = s.W, H = s.H, Opacity = op, Margin = margin, Transform = Affine.Translate(Screens.Pieces.Snap(at.X), Screens.Pieces.Snap(at.Y)) * (extra ?? Affine.Identity) });
            var cf = f["card"];
            Add("card", AuthArt.PlaqueSvg(cf.W, cf.H, "vel", 22, 3.5f, 2, 4), new Frame(cf.X - 2, cf.Y - 2, 0, 0), 1, null, 2);
            var mf = f["mail"];
            { var s = new UiSvg(26, 28); SquishSquad.Screens.Kit.Icon(s, MAIL, 0, 0, 26, AuthArt.GOLD_TXT, 2.4f); Add("mail", s, mf); }
            var tf = f["title-t"];
            { var s = new UiSvg(tf.W, tf.H); SquishSquad.Screens.Kit.Lettering(s, Title, "gold", TitleSize, 0, 0); Add("title", s, tf); }
            var xf = f["text"];
            { var s = new UiSvg(xf.W, xf.H); Body(m.Email).Draw(s, 6, 0, xf.W - 12); Add("text", s, xf); }
            if (f.TryGetValue("note", out var nf) && !string.IsNullOrEmpty(m.Note))
            {
                var s = new UiSvg(nf.W, nf.H);
                if (m.NoteBad) AuthArt.ErrorPill(s, nf.W, nf.H);
                var nt = f["note-t"];
                NoteFlow(m).Draw(s, nt.X - nf.X, nt.Y - nf.Y, nt.W);
                double t = ui.NoteT;
                Add("note", s, nf, (float)t, Affine.Translate(0, 6 * (1 - t)));
            }
            // a held button shrinks to 92 % about its middle (cx, cy), as the menu's Level crest does: the extra transform for
            // one of its pieces drawn at `at` (Add puts a piece at its frame's snapped top-left)
            Affine Shrink(bool on, Frame at, float cx, float cy)
            {
                if (!on) return Affine.Identity;
                double lx = cx - Screens.Pieces.Snap(at.X), ly = cy - Screens.Pieces.Snap(at.Y);
                return Affine.Translate(lx, ly) * Affine.ScaleBy(0.92, 0.92) * Affine.Translate(-lx, -ly);
            }
            bool held = ui.Pressed == "check";
            var rf = f["btn-ring"];
            float bcx = rf.X + rf.W / 2, bcy = rf.Y + rf.H / 2 + 1.5f;   // the button's middle (its 3 dp lip in): its glint, label and dots shrink with it
            var bf = new Frame(rf.X - 1.6f, rf.Y - 1.6f, 0, 0);
            Add("btn", AuthArt.PlaqueSvg(rf.W, rf.H, "gold", 15), bf, 1, Shrink(held, bf, bcx, bcy), 2);
            if (!m.Busy) Add("glint", AuthArt.GlintSvg(rf.W, rf.H, ui.GlintMs), rf, 1, Shrink(held, rf, bcx, bcy), 0);
            if (f.TryGetValue("label", out var lb)) { var s = new UiSvg(lb.W, lb.H); SquishSquad.Screens.Kit.Lettering(s, Label, "whiteB", z.BtnFont, 0, 0); Add("label", s, lb, 1, Shrink(held, lb, bcx, bcy)); }
            for (int i = 0; i < 3; i++)
                if (f.TryGetValue("dot" + i, out var df)) { var (svg, tr) = AuthArt.Dot(i, ui.DotsMs, 10); Add("dot" + i, svg, df, 1, Shrink(held, df, bcx, bcy) * tr); }
            foreach (var (id, text, icon) in new[] { ("resend", "Send it again", "M4 12a8 8 0 1 0 2.3-5.7 M4 4v4h4"), ("logout", "Log out", "M14 5h5v14h-5 M10 8l-4 4 4 4 M6 12h10") })
            {
                var lf = f[id];
                var s = AuthArt.PlaqueSvg(lf.W, lf.H, "vel", 14);
                var ic = f[id + "-icon"];
                SquishSquad.Screens.Kit.Icon(s, icon, ic.X - lf.X + 1.6f, ic.Y - lf.Y + 1.6f, 17, "#ffffff", 2.4f);
                var lt = f[id + "-t"];
                s.Text(text, lt.X - lf.X + 1.6f, lt.Y - lf.Y + 1.6f, LinkSt);
                var at = new Frame(lf.X - 1.6f, lf.Y - 1.6f, 0, 0);
                Add(id, s, at, 1, Shrink(ui.Pressed == id, at, lf.X + lf.W / 2, lf.Y + lf.H / 2 + 1.5f), 2);
            }
            return list;
        }

        public string HitTest(Dictionary<string, Frame> f, float x, float y)
        {
            if (f["btn-ring"].Contains(x, y)) return "check";
            if (f["resend"].Inset(4).Contains(x, y)) return "resend";
            if (f["logout"].Inset(4).Contains(x, y)) return "logout";
            return null;
        }
    }
}
