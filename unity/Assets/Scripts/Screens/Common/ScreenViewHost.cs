// A screen of this folder in Unity: its view (pure C#, IScreenView) on its own clock (Anim's Ticker: the app's
// Animated), its pieces on screen through App/ScreenHost (one UiPiece each, redrawn only when its SVG changes), the
// player's touches handed to it in dp, Escape (Android's back) to Back(). Every screen here derives from this:
//   var s = AchievementsScreen.Create(parent, profile, ...); s.OnExit = ...;   then Init(nowMs) (Unity's Start does
//   it) and, outside play mode (CI screenshots), Advance(nowMs).
// `parent` is the screen's top-left (dp → px by UiPiece.PxPerDp, y down), as the games' screens are placed.
using System;
using System.Collections.Generic;
using SquishSquad.Anim;
using SquishSquad.App;
using SquishSquad.Backend;
using SquishSquad.Ui;
using UnityEngine;

namespace SquishSquad.Screens
{
    [DefaultExecutionOrder(-40)]
    public abstract class ScreenViewHost : MonoBehaviour
    {
        /// <summary>Back out of the screen (its back orb, Android's back, its last button): the host removes it.</summary>
        public Action OnExit;

        protected IScreenView View;
        protected Ticker Clock;
        protected float ScreenW, ScreenH;   // px (0: Screen)
        protected float Wdp, Hdp;
        ScreenHost _host;
        bool _started, _wasDown;
        IDictionary<string, object> _pendingProfile;
        IProfileFeed _feed;

        protected static T Make<T>(Transform parent, string name, float screenW, float screenH) where T : ScreenViewHost
        {
            var go = new GameObject(name);
            go.transform.SetParent(parent, false);
            var s = go.AddComponent<T>();
            s.ScreenW = screenW; s.ScreenH = screenH;
            return s;
        }

        protected abstract IScreenView Build(float wDp, float hDp);
        /// <summary>The profile changed (the feed): the screen shows it (default: nothing).</summary>
        protected virtual void ProfileChanged(IDictionary<string, object> profile) { }
        /// <summary>Android's back (default: out).</summary>
        protected virtual void Back() => Exit();
        /// <summary>Each frame before the pieces are taken (text entry, the caret...).</summary>
        protected virtual void Frame() { }

        protected void Exit() => OnExit?.Invoke();
        protected static DateTime Now => DateTime.Now;

        /// <summary>The profile feed to follow (UserData.Feed), if any: changes reach ProfileChanged on the main thread.</summary>
        protected void Follow(IProfileFeed feed)
        {
            if (feed == null) return;
            _feed = feed;
            _feed.Changed += OnFeed;
        }
        void OnFeed(IDictionary<string, object> p) { lock (this) _pendingProfile = p; }

        public static void EnsureLoaders()
        {
            UiFont.ReadJson ??= name => Resources.Load<TextAsset>("Fonts/" + name)?.text;
            UiFont.ParseJson ??= json => JsonUtility.FromJson<UiFontData>(json);
            Roster.ReadText ??= path => Resources.Load<TextAsset>(path)?.text;
        }

        void Start() => Init(Time.unscaledTimeAsDouble * 1000);

        /// <summary>Builds the screen with the clock at `nowMs` (Unity calls it; CI screenshots call it outside play mode).</summary>
        public void Init(double nowMs)
        {
            if (_started) return;
            _started = true;
            EnsureLoaders();
            Clock = new Ticker(nowMs);
            Ticker.Default = Clock;
            Wdp = (ScreenW > 0 ? ScreenW : Screen.width) / UiPiece.PxPerDp;
            Hdp = (ScreenH > 0 ? ScreenH : Screen.height) / UiPiece.PxPerDp;
            _host = new ScreenHost(transform, name + " pieces");
            View = Build(Wdp, Hdp);
            Show();
        }

        /// <summary>Moves the clock to `nowMs` and shows that frame (CI screenshots).</summary>
        public void Advance(double nowMs)
        {
            if (!_started) Init(nowMs);
            Ticker.Default = Clock;
            Clock.Tick(nowMs);
            Show();
        }

        void Update()
        {
            if (!_started) return;
            Ticker.Default = Clock;
            Clock.Tick(Time.unscaledTimeAsDouble * 1000);
            IDictionary<string, object> p;
            lock (this) { p = _pendingProfile; _pendingProfile = null; }
            if (p != null) ProfileChanged(p);
            var ptr = ScreenHost.Read();
            if (ptr.Down) View.Down(ptr.Dp.x, ptr.Dp.y);
            else if (ptr.Held && _wasDown) View.Move(ptr.Dp.x, ptr.Dp.y);
            if (ptr.Up && _wasDown) View.Up(ptr.Dp.x, ptr.Dp.y);
            _wasDown = ptr.Down || (ptr.Held && _wasDown);
            if (ptr.Up) _wasDown = false;
            if (Input.GetKeyDown(KeyCode.Escape)) Back();
            if (this == null || !isActiveAndEnabled) return;
            Show();
        }

        void Show()
        {
            Frame();
            _host.Show(View.Pieces());
        }

        void OnDestroy()
        {
            if (_feed != null) _feed.Changed -= OnFeed;
            _host?.Dispose();
        }
    }
}
