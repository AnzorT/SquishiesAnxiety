// src/screens/VerifyEmailScreen.js from the Unity code, sideways: Mittens and "Check your email" on the left, the card
// on the right ("We sent a link to <email>. …", the note, the gold "I've verified" button, "Send it again" and "Log
// out"). VerifyModel is what its buttons do, with the app's notes word for word.
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
        public double DotsMs;
    }

    public sealed class VerifyArt
    {
        const string INK = "#5b3418", RIM = "#6b4426";
        static float B25 => FlexNode.Bw(2.5f);
        static readonly TextStyle TitleStyle = new TextStyle
        {
            Font = AuthArt.Display, Size = 34, LineHeight = 40, Color = "#ffffff",
            Shadows = new[] { new Shadow(RIM, 0, 4, 0), new Shadow(RIM, 2.5f, 0, 0), new Shadow(RIM, -2.5f, 0, 0), new Shadow(RIM, 0, -2.5f, 0) },
        };
        static readonly TextStyle TextSt = new TextStyle { Font = AuthArt.Heavy, Size = 14, LineHeight = 20, Color = INK };
        static readonly TextStyle EmailSt = new TextStyle { Font = AuthArt.Black, Size = 14, LineHeight = 20, Color = "#c25e00" };
        static readonly TextStyle NoteSt = new TextStyle { Font = AuthArt.Heavy, Size = 12.5f, LineHeight = 17, Color = "#d0345a" };
        static readonly TextStyle LinkSt = new TextStyle { Font = AuthArt.Black, Size = 13, Color = "#8a3a0e" };
        static readonly TextStyle BtnSt = AuthArt.BtnStyle(20, AuthArt.GOLD_RING);
        const string Title = "Check your email";

        public readonly float W, H;
        public VerifyArt(float w, float h) { W = w; H = h; }

        TextFlow Body(string email) => new TextFlow(TextSt, 0.5f, new Run("We sent a link to ", TextSt), new Run(email ?? "", EmailSt), new Run(". Tap it to confirm it's really you, then come back here.", TextSt));

        public Dictionary<string, Frame> Layout(VerifyModel m)
        {
            var root = new FlexNode("root");
            var col = root.Add(new FlexNode("col").Flex(1).Justify(YGJustify.Center).PadH(22).Gap(30).Row().AlignItems(YGAlign.Center));
            var side = col.Add(new FlexNode("side").AlignItems(YGAlign.Center).Gap(6));
            side.Add(new FlexNode("mittens").Size(180, 180).AlignSelf(YGAlign.Center));
            side.Add(FlexNode.Leaf("title", new TextFlow(Title, TitleStyle).Measure).AlignSelf(YGAlign.Center));
            var lip = col.Add(new FlexNode("lip").Padding(YGEdge.Bottom, 5).Width(400));
            var card = lip.Add(new FlexNode("card").Gap(14).Padding(18).Border(2.5f));
            card.Add(FlexNode.Leaf("text", Body(m.Email).Measure));
            if (!string.IsNullOrEmpty(m.Note)) card.Add(FlexNode.Leaf("note", new TextFlow(m.Note, NoteSt, 0.5f).Measure));
            var ring = card.Add(new FlexNode("btn-ring").AlignSelf(YGAlign.Stretch).Padding(2.5f).Padding(YGEdge.Bottom, 7.5f));
            var face = ring.Add(new FlexNode("btn-face").Border(3).PadV(10).PadH(14).Row().AlignItems(YGAlign.Center).Justify(YGJustify.Center).Gap(5));
            if (m.Busy) face.Add(new FlexNode("dots").Row().Gap(5).Padding(YGEdge.Top, 7).Height(26).With(new FlexNode("dot0").Size(14, 16), new FlexNode("dot1").Size(14, 16), new FlexNode("dot2").Size(14, 16)));
            else face.Add(FlexNode.Leaf("label", new TextFlow("I've verified", BtnSt).Measure));
            var row = card.Add(new FlexNode("links").Row().Justify(YGJustify.SpaceBetween).PadH(6));
            row.Add(FlexNode.Leaf("resend", new TextFlow("Send it again", LinkSt).Measure));
            row.Add(FlexNode.Leaf("logout", new TextFlow("Log out", LinkSt).Measure));
            root.Layout(W, H);
            var f = new Dictionary<string, Frame>();
            root.Walk(n => f[n.Name] = n.Frame);
            return f;
        }

        public List<ScreenPiece> Pieces(VerifyModel m, VerifyUi ui, Dictionary<string, Frame> f)
        {
            var list = new List<ScreenPiece> { new ScreenPiece { Id = "bg", Svg = IntroArt.Svg(W, H), W = W, H = H, Margin = 0 } };
            var mf = f["mittens"];
            list.Add(new ScreenPiece { Id = "mittens", Slot = true, W = mf.W, H = mf.H, Transform = Affine.Translate(mf.X, mf.Y) });
            void Add(string id, UiSvg s, Frame at, float op = 1, Affine? extra = null) =>
                list.Add(new ScreenPiece { Id = id, Svg = s.Markup, W = s.W, H = s.H, Opacity = op, Transform = Affine.Translate(Screens.Pieces.Snap(at.X), Screens.Pieces.Snap(at.Y)) * (extra ?? Affine.Identity) });
            var tf = f["title"];
            Add("title", new UiSvg(tf.W, tf.H).Text(Title, 0, 0, TitleStyle), tf);
            var lf = f["lip"]; var cf = f["card"];
            Add("card", new UiSvg(lf.W, lf.H).Box(0, 0, lf.W, lf.H, new BoxStyle { Radius = 28, Background = RIM })
                .Box(cf.X - lf.X, cf.Y - lf.Y, cf.W, cf.H, new BoxStyle { Radius = 28, Background = "#fff6e2", BorderWidth = B25, BorderColor = RIM }), lf);
            var xf = f["text"];
            { var s = new UiSvg(xf.W, xf.H); Body(m.Email).Draw(s, 0, 0, xf.W); Add("text", s, xf); }
            if (f.TryGetValue("note", out var nf) && !string.IsNullOrEmpty(m.Note)) { var s = new UiSvg(nf.W, nf.H); new TextFlow(m.Note, NoteSt, 0.5f).Draw(s, 0, 0, nf.W); Add("note", s, nf); }
            var press = ui.Pressed == "check" ? Affine.Translate(0, 3) : Affine.Identity;
            var rf = f["btn-ring"]; var ff = f["btn-face"];
            Add("btn", AuthArt.CandyBody(rf.W, rf.H, ff.X - rf.X, ff.Y - rf.Y, ff.W, ff.H, AuthArt.GOLD, new[] { 0f, 0.5f, 1f }, AuthArt.GOLD_RING), rf, 1, press);
            if (f.TryGetValue("label", out var lb)) Add("label", new UiSvg(lb.W, lb.H).Text("I've verified", 0, 0, BtnSt), lb, 1, press);
            for (int i = 0; i < 3; i++)
                if (f.TryGetValue("dot" + i, out var df)) { var (svg, tr, op) = AuthArt.HopDot(i, ui.DotsMs, 14); Add("dot" + i, svg, df, op, press * tr); }
            var a = f["resend"]; Add("resend", new UiSvg(a.W, a.H).Text("Send it again", 0, 0, LinkSt), a);
            var b = f["logout"]; Add("logout", new UiSvg(b.W, b.H).Text("Log out", 0, 0, LinkSt), b);
            return list;
        }

        public string HitTest(Dictionary<string, Frame> f, float x, float y)
        {
            if (f["btn-ring"].Contains(x, y)) return "check";
            if (f["resend"].Inset(8).Contains(x, y)) return "resend";
            if (f["logout"].Inset(8).Contains(x, y)) return "logout";
            return null;
        }
    }
}
