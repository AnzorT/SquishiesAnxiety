// Settings in Unity (SettingsView on screen): the menu's gear opens it. Nickname → UserData.UpdateNickname, Send
// feedback → UserData.SubmitFeedback, Replay tutorial → the tutorial step 'start', Stats → StatsScreen over it (its
// back returns here, as App.js openFromSettings), a tester's Test wallet → testWallet. LOG OUT calls OnLogout (the
// app's sign-out: the host's). Music / Sound effects are Sfx's switches (soundSettings.json, as the app); the
// FPS counter calls OnToggleFps. Typing goes through App/TextEntry (the phone's keyboard).
using System;
using System.Collections.Generic;
using SquishSquad.App;
using SquishSquad.Backend;
using UnityEngine;

namespace SquishSquad.Screens
{
    public sealed class SettingsScreen : ScreenViewHost
    {
        public Action OnLogout, OnToggleFps;
        public bool FpsOn;
        IDictionary<string, object> _profile;
        FirebaseClient _fb;
        string _uid;
        bool _tester;
        readonly TextEntry _entry = new TextEntry();
        StatsScreen _stats;

        /// <summary>`tester`: the account's tester claim (the Test wallet and the FPS switch).</summary>
        public static SettingsScreen Create(Transform parent, IDictionary<string, object> profile, FirebaseClient fb, string uid, bool tester = false, float screenW = 0, float screenH = 0)
        {
            var s = Make<SettingsScreen>(parent, "Settings", screenW, screenH);
            s._profile = profile; s._fb = fb; s._uid = uid; s._tester = tester;
            s.Follow(fb?.Data.Feed);
            return s;
        }

        SettingsView V => (SettingsView)View;

        protected override IScreenView Build(float w, float h)
        {
            string nick = Prof.Str(Prof.Get(_profile, "nickname")) ?? "Squisher";
            var v = new SettingsView(nick, _tester, w, h, Clock, SquishSquad.Audio.Sfx.MusicOn, SquishSquad.Audio.Sfx.EffectsOn, FpsOn)
            {
                OnBack = Exit,
                OnLogout = () => OnLogout?.Invoke(),
                OnToggleFps = () => { FpsOn = !FpsOn; OnToggleFps?.Invoke(); },
                // (Sfx keeps them in soundSettings.json and mirrors them to PlayerPrefs squishsquad.sound.*)
                OnSound = (m, e) => { SquishSquad.Audio.Sfx.SetMusicOn(m); SquishSquad.Audio.Sfx.SetEffectsOn(e); },
                OnSaveNickname = n => { if (_fb != null && _uid != null) _ = _fb.Data.UpdateNickname(_uid, n); },
                OnSubmitFeedback = t => _fb != null && _uid != null ? _fb.Data.SubmitFeedback(_uid, t) : System.Threading.Tasks.Task.CompletedTask,
                OnReplayTutorial = () => { if (_fb != null && _uid != null) _ = _fb.Data.SetTutorialStep(_uid, "start"); },
                OnOpenStats = OpenStats,
            };
            if (_tester)
            {
                var lv = Progression.Level(_profile);
                v.Wallet = new TestWalletView(Clock, Prof.Num(Prof.Get(_profile, "coins")), Prof.Num(Prof.Get(_profile, "gems"), 30), lv)
                {
                    FpsOn = () => FpsOn,
                    OnToggleFps = () => { FpsOn = !FpsOn; OnToggleFps?.Invoke(); },
                    OnSet = w => _fb != null ? ScreenWrites.TestWallet(_fb.Functions, w, DateTime.Now) : System.Threading.Tasks.Task.CompletedTask,
                };
            }
            return v;
        }

        void OpenStats()
        {
            if (_stats != null) return;
            _stats = StatsScreen.Create(transform.parent, _profile, _fb?.Data.Feed, null, ScreenW, ScreenH);
            _stats.OnExit = () => { Destroy(_stats.gameObject); _stats = null; gameObject.SetActive(true); };
            gameObject.SetActive(false);
        }

        protected override void Frame()
        {
            var v = V;
            if (v.Focused != null)
            {
                bool number = v.Focused.StartsWith("w");
                if (_entry.Field != v.Focused) _entry.Focus(v.Focused, v.TextOf(v.Focused), number ? TextEntry.Kind.Number : TextEntry.Kind.Text, v.Focused == "nick" ? 10 : 0, v.Focused == "nick" ? "Your name" : "");
                var was = v.TextOf(v.Focused);
                var t = _entry.Poll(was);
                if (t != was) v.SetText(v.Focused, t);
                if (_entry.Field == null) { if (v.Focused == "nick") v.Save(); v.Blur(); }
                v.CaretOn = _entry.CaretOn;
            }
            else if (_entry.Field != null) _entry.Blur();
        }

        protected override void Back() => V.Back();

        protected override void ProfileChanged(IDictionary<string, object> profile)
        {
            _profile = profile;
            V.Nickname = Prof.Str(Prof.Get(profile, "nickname")) ?? V.Nickname;
            V.Wallet?.SetWallet(Prof.Num(Prof.Get(profile, "coins")), Prof.Num(Prof.Get(profile, "gems"), 30), Progression.Level(profile));
        }
    }
}
