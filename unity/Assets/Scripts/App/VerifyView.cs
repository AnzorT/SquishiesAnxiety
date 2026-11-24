// src/screens/VerifyEmailScreen.js in Unity (Ui/Screens/VerifyArt + VerifyModel): "I've verified" asks Firebase again
// (the hopping dots while it does), "Send it again" resends the link, "Log out" is the way back. The gold button moves
// down 3 dp while held.
using System;
using SquishSquad.Ui;
using SquishSquad.Ui.Screens;
using UnityEngine;

namespace SquishSquad.App
{
    public sealed class VerifyView : MonoBehaviour
    {
        public readonly VerifyModel Model = new VerifyModel();
        readonly VerifyUi _ui = new VerifyUi();
        IVerifyBackend _backend;
        Action _onVerified, _onLogout;
        VerifyArt _art;
        ScreenHost _host;
        string _down, _shownKey;
        double _busyAt;

        public static VerifyView Create(Transform parent, string email, IVerifyBackend backend, Action onVerified, Action onLogout)
        {
            var go = new GameObject("Verify email");
            go.transform.SetParent(parent, false);
            var v = go.AddComponent<VerifyView>();
            v.Model.Email = email ?? "";
            v._backend = backend;
            v._onVerified = onVerified;
            v._onLogout = onLogout;
            return v;
        }

        double _openedAt, _noteAt = -1e9;
        string _noteSeen = "";

        void Start()
        {
            _openedAt = Time.unscaledTimeAsDouble * 1000;
            UiPiece.PxPerDp = Screen.height / 384f;
            _host = new ScreenHost(transform, "pieces");
        }

        void OnDestroy() => _host?.Dispose();

        void Update()
        {
            double now = Time.unscaledTimeAsDouble * 1000;
            float w = Screen.width / UiPiece.PxPerDp;
            if (_art == null || _art.W != w) { UiPiece.PxPerDp = Screen.height / 384f; _art = new VerifyArt(Screen.width / UiPiece.PxPerDp, 384); }
            var f = _art.Layout(Model);
            var p = ScreenHost.Read();
            if (p.Down && !AppFlow.InDevPanel(p.Dp)) _down = _art.HitTest(f, p.Dp.x, p.Dp.y) ?? "";
            if (_down != null && p.Held) _ui.Pressed = _down != "" && !(_down == "check" && Model.Busy) && _art.HitTest(f, p.Dp.x, p.Dp.y) == _down ? _down : null;
            if (_down != null && p.Up)
            {
                var hit = _art.HitTest(f, p.Dp.x, p.Dp.y);
                if (hit == _down) Tap(hit);
                _down = null;
                _ui.Pressed = null;
            }
            _ui.DotsMs = Model.Busy ? now - _busyAt : 0;
            _ui.GlintMs = now - _openedAt;
            _ui.CreatureShown = _host.Creature != null && _host.Creature.gameObject.activeSelf;
            // useFadeUp: a new note fades up 6 dp (260 ms, out quad)
            if (Model.Note != _noteSeen) { _noteSeen = Model.Note; _noteAt = now; }
            double nt = Math.Min(1, (now - _noteAt) / 260);
            _ui.NoteT = 1 - (1 - nt) * (1 - nt);
            var key = $"{w}|{Model.Busy}|{Model.Note}|{_ui.Pressed}|{_ui.DotsMs:0}|{Math.Floor(_ui.GlintMs / 16)}|{_ui.CreatureShown}|{_ui.NoteT:0.000}";
            if (key == _shownKey) return;
            _shownKey = key;
            _host.Show(_art.Pieces(Model, _ui, f));
        }

        async void Tap(string hit)
        {
            try
            {
                if (hit == "check")
                {
                    if (Model.Busy) return;
                    _busyAt = Time.unscaledTimeAsDouble * 1000;
                    if (await Model.Check(_backend)) _onVerified?.Invoke();
                }
                else if (hit == "resend") await Model.Resend(_backend);
                else if (hit == "logout") _onLogout?.Invoke();
            }
            catch (Exception e) { Debug.LogException(e); }
        }
    }
}
