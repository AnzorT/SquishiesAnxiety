// The launch, as the app has it on develop (App.js, 2026-11-16: the designer's game intro replaced the splash screen,
// src/screens/SplashScreen.js deleted): no title, no loading bar, only the launch colour (LAUNCH_BG #2a1608) until the
// app is ready (sign-in known and, signed in, the profile here: AppFlow's SetReady), 10 s at most; then Finished. The
// game intro plays on the menu after it (and after log in / the email check). The old splash's art (Ui/Screens/
// SplashArt, SplashModel) is no longer shown.
using System;
using System.Collections.Generic;
using SquishSquad.Ui;
using SquishSquad.Ui.Screens;
using UnityEngine;

namespace SquishSquad.App
{
    public sealed class SplashView : MonoBehaviour
    {
        public const string LaunchBg = "#2a1608";
        const float MaxSeconds = 10;

        ScreenHost _host;
        float _start, _w;
        bool _ready, _done;
        public event Action Finished;

        public static SplashView Create(Transform parent)
        {
            var go = new GameObject("Splash");
            go.transform.SetParent(parent, false);
            return go.AddComponent<SplashView>();
        }

        /// <summary>The app is ready (App.js launchReady): the launch is over.</summary>
        public void SetReady() => _ready = true;

        void Start()
        {
            _start = Time.unscaledTime;
            _host = new ScreenHost(transform, "pieces");
        }

        void OnDestroy() => _host?.Dispose();

        void Update()
        {
            UiPiece.PxPerDp = Screen.height / 384f;
            float w = Screen.width / UiPiece.PxPerDp;
            if (w != _w)
            {
                _w = w;
                var bg = new UiSvg(w, 384).Box(0, 0, w, 384, new BoxStyle { Background = LaunchBg });
                _host.Show(new List<ScreenPiece> { new ScreenPiece { Id = "launch", Svg = bg.Markup, W = w, H = 384, Margin = 0 } });
            }
            if (_done || !(_ready || Time.unscaledTime - _start > MaxSeconds)) return;
            _done = true;
            Finished?.Invoke();
        }
    }
}
