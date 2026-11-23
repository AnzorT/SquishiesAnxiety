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

        void Start()
        {
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
            if (_down != null && p.Held) _ui.Pressed = _down == "check" && !Model.Busy && _art.HitTest(f, p.Dp.x, p.Dp.y) == "check" ? "check" : null;
            if (_down != null && p.Up)
            {
                var hit = _art.HitTest(f, p.Dp.x, p.Dp.y);
                if (hit == _down) Tap(hit);
                _down = null;
                _ui.Pressed = null;
            }
            _ui.DotsMs = Model.Busy ? now - _busyAt : 0;
            var key = $"{w}|{Model.Busy}|{Model.Note}|{_ui.Pressed}|{_ui.DotsMs:0}";
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
