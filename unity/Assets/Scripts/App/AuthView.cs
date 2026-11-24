// src/screens/AuthScreen.js in Unity: Ui/Screens/AuthArt draws it, AuthModel does what it does, this runs it: taps
// (the Log in / Register switch, the fields, Show / Hide, the gold button, "Keep me signed in", the social buttons),
// typing (TextEntry), and the app's motions on the app's clock (Anim): the switch's pill (350 ms, bezier .3 1.3 .5 1),
// the button's label fading up when it changes (300 ms, out quad), the hopping dots while the server answers, the
// register row opening or closing (Android's LayoutAnimation: 300 ms ease-in-out, the new row fading in), the field's
// orange border and blinking caret while focused, the button moving down 3 dp while held (the social ones 2), and the
// card column scrolling when it's taller than the screen (register with an error).
// Signing in moves the app on (AppFlow watches FirebaseAuth.AuthStateChanged), as App.js's listener does.
using System;
using System.Collections.Generic;
using System.Text;
using SquishSquad.Anim;
using SquishSquad.Ui;
using SquishSquad.Ui.Screens;
using UnityEngine;

namespace SquishSquad.App
{
    public sealed class AuthView : MonoBehaviour
    {
        public readonly AuthModel Model = new AuthModel();
        readonly AuthUi _ui = new AuthUi();
        IAuthBackend _backend;
        Action<string> _toast;
        AuthArt _art;
        ScreenHost _host;
        Ticker _ticker;
        readonly AnimatedValue _pill = new AnimatedValue(0), _label = new AnimatedValue(1);
        readonly TextEntry _entry = new TextEntry();
        Dictionary<string, Frame> _layout;
        float _scrollMax;
        string _layoutKey, _shownKey;
        int _labelSeen;
        double _submitAt;

        // the register row opening / closing (LayoutAnimation SWAP)
        Dictionary<string, Frame> _animFrom;
        HashSet<string> _created;
        double _animStart = -1;
        const double SwapMs = 300;

        // the pointer
        string _down;
        Vector2 _downAt;
        float _scrollAtDown;
        bool _dragging;

        public static AuthView Create(Transform parent, IAuthBackend backend, Action<string> toast)
        {
            var go = new GameObject("Log in");
            go.transform.SetParent(parent, false);
            var v = go.AddComponent<AuthView>();
            v._backend = backend;
            v._toast = toast;
            return v;
        }

        double Now => Time.unscaledTimeAsDouble * 1000;

        double _openedAt;

        void Start()
        {
            _openedAt = Now;
            UiPiece.PxPerDp = Screen.height / 384f;
            _ticker = new Ticker(Now);
            _host = new ScreenHost(transform, "pieces");
            _labelSeen = Model.LabelChanges;
        }

        void OnDestroy() { _entry.Blur(); _host?.Dispose(); }

        void Run(Action a) { var was = Ticker.Default; Ticker.Default = _ticker; try { a(); } finally { Ticker.Default = was; } }

        void Update()
        {
            double now = Now;
            float w = Screen.width / UiPiece.PxPerDp, h = Screen.height / UiPiece.PxPerDp;
            if (_art == null || _art.W != w || _art.H != h) { UiPiece.PxPerDp = Screen.height / 384f; _art = new AuthArt(Screen.width / UiPiece.PxPerDp, 384); _layoutKey = null; }
            _ticker.Tick(now);
            Typing();
            Pointer();
            Relayout(now);

            // what moves
            _ui.PillX = _pill.GetValue();
            _ui.LabelT = _label.GetValue();
            _ui.Focus = _entry.Field;
            _ui.CaretOn = _entry.CaretOn;
            _ui.DotsMs = Model.Submitting ? now - _submitAt : 0;
            _ui.GlintMs = now - _openedAt;
            _ui.CreatureShown = _host.Creature != null && _host.Creature.gameObject.activeSelf;
            if (_animStart >= 0)
            {
                double t = Math.Min(1, (now - _animStart) / SwapMs);
                float e = (float)(Math.Cos((t + 1) * Math.PI) / 2 + 0.5);   // Android's AccelerateDecelerateInterpolator
                var f = new Dictionary<string, Frame>(_layout);
                foreach (var kv in _layout) if (_animFrom.TryGetValue(kv.Key, out var a)) f[kv.Key] = Frame.Lerp(a, kv.Value, e);
                _ui.FramesOverride = f;
                _ui.Fade = new Dictionary<string, float>();
                foreach (var id in _created) _ui.Fade[id] = (float)t;
                if (t >= 1) { _animStart = -1; _ui.FramesOverride = null; _ui.Fade = null; }
            }
            Show();
        }

        // ---- layout: Yoga again when what's in the card changes; the register row animates in or out ----------------
        void Relayout(double now)
        {
            if (Model.LabelChanges != _labelSeen)
            {
                _labelSeen = Model.LabelChanges;
                // useFadeUp: the new label fades up 6 dp
                Run(() => { _label.SetValue(0); Animated.Timing(_label, new TimingConfig { ToValue = 1, Duration = 300, Easing = Easing.Out(Easing.Quad) }).Start(); });
            }
            string key = $"{Model.Register}|{Model.Blocked}|{Model.Error}|{Model.Submitting}|{Model.ButtonLabel}|{Model.ShowPass}";
            if (key == _layoutKey) return;
            var old = _layout;
            bool modeChanged = _layoutKey != null && _layoutKey.Split('|')[0] != key.Split('|')[0];
            _layoutKey = key;
            _layout = _art.Layout(Model, out _scrollMax);
            _ui.ScrollY = Mathf.Clamp(_ui.ScrollY, 0, _scrollMax);
            if (modeChanged && old != null)
            {
                _animFrom = old;
                _created = new HashSet<string>();
                foreach (var k in _layout.Keys) if (!old.ContainsKey(k)) _created.Add(k);
                _animStart = now;
            }
        }

        void Show()
        {
            // only when something on screen changed
            var sb = new StringBuilder(_layoutKey);
            sb.Append('|').Append(Model.Age).Append('|').Append(Model.Nickname).Append('|').Append(Model.Email).Append('|').Append(Model.Password).Append('|').Append(Model.Keep)
              .Append('|').Append(_ui.Focus).Append(_ui.CaretOn).Append('|').Append(_ui.Pressed).Append('|').Append(_ui.ScrollY.ToString("0.00"))
              .Append('|').Append(_ui.PillX.ToString("0.0000")).Append('|').Append(_ui.LabelT.ToString("0.0000")).Append('|').Append(_ui.DotsMs.ToString("0"))
              .Append('|').Append(_animStart).Append('|').Append(Math.Floor(_ui.GlintMs / 16)).Append(_ui.CreatureShown);
            var key = sb.ToString();
            if (key == _shownKey && _animStart < 0) return;
            _shownKey = key;
            _host.Show(_art.Pieces(Model, _ui, _layout));
        }

        // ---- typing ---------------------------------------------------------------------------------------------------
        static readonly string[] Order = { "nick", "age", "email", "pass" };

        void Focus(string id)
        {
            var kind = id == "email" ? TextEntry.Kind.Email : id == "age" ? TextEntry.Kind.Number : id == "pass" && !Model.ShowPass ? TextEntry.Kind.Password : TextEntry.Kind.Text;
            int max = id == "nick" ? AuthModel.NicknameMax : id == "age" ? AuthModel.AgeMax : 0;
            string ph = AuthArt.Placeholder(id, Model.Register);
            _entry.Focus(id, AuthArt.Value(Model, id), kind, max, ph);
        }

        void Typing()
        {
            var id = _entry.Field;
            if (id == null) return;
            if (!_layout.ContainsKey("f-" + id + "-input")) { _entry.Blur(); return; }
            var t = _entry.Poll(AuthArt.Value(Model, id));
            if (id == "nick") Model.Nickname = t; else if (id == "age") Model.Age = t; else if (id == "email") Model.Email = t; else Model.Password = t;
            if (_entry.TabPressed)
            {
                int i = Array.IndexOf(Order, id);
                for (int j = 1; j <= Order.Length; j++)
                {
                    var next = Order[(i + j) % Order.Length];
                    if (_layout.ContainsKey("f-" + next + "-input")) { Focus(next); break; }
                }
            }
        }

        // ---- taps -----------------------------------------------------------------------------------------------------
        static bool Holds(string hit) => hit == "submit" || hit == "google" || hit == "facebook" || hit == "tiktok"
            || hit == "tab-login" || hit == "tab-register" || hit == "eye" || hit == "keep";

        void Pointer()
        {
            var p = ScreenHost.Read();
            if (p.Down && !AppFlow.InDevPanel(p.Dp))
            {
                _down = _art.HitTest(_layout, _ui, p.Dp.x, p.Dp.y) ?? "";
                if (_down == "submit" && Model.Submitting) _down = "";
                _downAt = p.Dp;
                _scrollAtDown = _ui.ScrollY;
                _dragging = false;
                _ui.Pressed = Holds(_down) ? _down : null;
            }
            if (_down == null) return;
            if (p.Held)
            {
                // a drag over the card column scrolls it (when there's more than fits)
                if (_scrollMax > 0 && Mathf.Abs(p.Dp.y - _downAt.y) > 8) _dragging = true;
                if (_dragging) { _ui.ScrollY = Mathf.Clamp(_scrollAtDown - (p.Dp.y - _downAt.y), 0, _scrollMax); _ui.Pressed = null; }
                else _ui.Pressed = Holds(_down) && _art.HitTest(_layout, _ui, p.Dp.x, p.Dp.y) == _down ? _down : null;
            }
            if (!p.Up) return;
            var down = _down;
            _down = null;
            _ui.Pressed = null;
            if (_dragging) return;
            var hit = _art.HitTest(_layout, _ui, p.Dp.x, p.Dp.y);
            if (hit != down || string.IsNullOrEmpty(hit)) { if (string.IsNullOrEmpty(down)) _entry.Blur(); return; }
            Tap(hit);
        }

        void Tap(string hit)
        {
            switch (hit)
            {
                case "tab-login":
                case "tab-register":
                    bool reg = hit == "tab-register";
                    if (Model.SwitchMode(reg))
                    {
                        if (_entry.Field == "nick" || _entry.Field == "age") _entry.Blur();
                        Run(() => Animated.Timing(_pill, new TimingConfig { ToValue = reg ? 1 : 0, Duration = 350, Easing = Easing.Bezier(0.3, 1.3, 0.5, 1) }).Start());
                    }
                    break;
                case "eye": Model.ShowPass = !Model.ShowPass; if (_entry.Field == "pass") { _entry.Blur(); Focus("pass"); } break;
                case "keep": Model.Keep = !Model.Keep; break;
                case "submit": Submit(); break;
                case "google": case "facebook": case "tiktok":
                    // social.js's web sign-in isn't ported
                    _toast?.Invoke(char.ToUpperInvariant(hit[0]) + hit.Substring(1).Replace("Tiktok", "TikTok") + " sign-in isn't in the Unity version yet");
                    break;
                default:
                    if (Array.IndexOf(AuthArt.FieldIds, hit) >= 0) Focus(hit);
                    break;
            }
        }

        async void Submit()
        {
            if (Model.Submitting) return;
            _submitAt = Now;
            try { await Model.Submit(_backend); }
            catch (Exception e) { Debug.LogException(e); }
        }
    }
}
