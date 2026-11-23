// src/screens/SplashScreen.js in Unity (Ui/Screens/SplashArt + SplashModel): the title, the loading bar and its line
// on the app's clock. AppFlow says when the app is ready (signed in or not, and the profile here); Finished fires 250 ms
// after the bar is full, as the app's onFinish. A tap doesn't skip it.
using System;
using SquishSquad.Anim;
using SquishSquad.Ui;
using SquishSquad.Ui.Screens;
using UnityEngine;

namespace SquishSquad.App
{
    public sealed class SplashView : MonoBehaviour
    {
        Ticker _ticker;
        SplashModel _model;
        SplashArt _art;
        ScreenHost _host;
        string _shown;
        bool _ready;
        public event Action Finished;

        public static SplashView Create(Transform parent)
        {
            var go = new GameObject("Splash");
            go.transform.SetParent(parent, false);
            return go.AddComponent<SplashView>();
        }

        /// <summary>The app is ready: the bar fills the rest (1.5 s after the start at the earliest).</summary>
        public void SetReady() { _ready = true; _model?.SetReady(); }

        void Start()
        {
            UiPiece.PxPerDp = Screen.height / 384f;
            _ticker = new Ticker(Time.unscaledTimeAsDouble * 1000);
            _model = new SplashModel(_ticker);
            _model.Finished += () => Finished?.Invoke();
            if (_ready) _model.SetReady();
            _host = new ScreenHost(transform, "pieces");
        }

        void OnDestroy() => _host?.Dispose();

        void Update()
        {
            _ticker.Tick(Time.unscaledTimeAsDouble * 1000);
            float w = Screen.width / UiPiece.PxPerDp;
            if (_art == null || _art.W != w) { UiPiece.PxPerDp = Screen.height / 384f; _art = new SplashArt(Screen.width / UiPiece.PxPerDp, 384); _shown = null; }
            // the fill moves in quarter-pixel steps at most (no redraw for less)
            string key = _model.Label + "|" + Math.Round(_model.Fill.GetValue() * SplashModel.TRACK_W * UiPiece.PxPerDp * 4);
            if (key == _shown) return;
            _shown = key;
            _host.Show(_art.Pieces(_model));
        }
    }
}
