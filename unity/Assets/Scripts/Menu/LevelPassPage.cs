// The Level Pass on screen (the level crest's tap, as webgame/app/menu.js M.levels): LevelPassModel says what to draw,
// CharactersPageView draws it, this hands it the player and the touches and asks the server for claims
// (CharactersPageLink). MenuScreen opens it and passes it the input while it's open.
using System;
using SquishSquad.Ui;
using UnityEngine;

namespace SquishSquad.Menu
{
    /// <summary>A page open over the menu (the Characters page, the Level Pass).</summary>
    public interface IMenuPage : IDisposable
    {
        bool Closed { get; }
        /// <summary>The page covers the whole screen (the menu under it needn't draw).</summary>
        bool Covers { get; }
        void Tick(float nowMs);
        /// <summary>The touch (page px, y down), Android's back / Escape, the mouse wheel.</summary>
        void Input(bool down, bool held, bool up, Vector2 px, float nowMs, bool back, float wheel);
    }

    public sealed class LevelPassPage : IMenuPage
    {
        static LevelPassLayout _layout;
        static CharactersLayout _roster;
        readonly LevelPassModel _m;
        readonly CharactersPageView _view;
        object _profileSeen;
        public bool Closed { get; private set; }
        public bool Covers => _m != null && Time.unscaledTime * 1000 - _openedReal > PageMotion.OpenMs + 50;
        readonly float _openedReal;

        public static LevelPassLayout Layout => _layout ??= LoadJson<LevelPassLayout>(LevelPassLayout.Root + "levelpass");
        internal static CharactersLayout Roster => _roster ??= LoadJson<CharactersLayout>(CharactersLayout.Root + "characters");

        internal static T LoadJson<T>(string res) where T : class
        {
            var t = Resources.Load<TextAsset>(res);
            if (t == null) return null;
            var o = JsonUtility.FromJson<T>(t.text);
            Resources.UnloadAsset(t);
            return o;
        }

        /// <summary>Opens the page (null: not exported: tools/unity/export-pages.mjs).</summary>
        public static LevelPassPage Open(Transform parent, float w, float h, float nowMs, int order)
        {
            UiFont.ReadJson ??= n => Resources.Load<TextAsset>("Fonts/" + n)?.text;
            UiFont.ParseJson ??= j => JsonUtility.FromJson<UiFontData>(j);
            return Layout == null ? null : new LevelPassPage(parent, w, h, nowMs, order);
        }

        LevelPassPage(Transform parent, float w, float h, float nowMs, int order)
        {
            _openedReal = Time.unscaledTime * 1000;
            var pl = CharactersPageLink.Get();
            _profileSeen = pl?.Profile;
            _m = new LevelPassModel(Layout, w, h, DataOf(pl), nowMs);
            _m.YouArt = YouArt;
            if (pl != null) _m.OnClaim = Claim;
            _view = new CharactersPageView(LevelPassLayout.Root, parent, order);
        }

        static PagePic YouArt(string key)
        {
            var r = Roster;
            var s = r?.stills != null ? Array.Find(r.stills, x => x.key == key) : null;
            return s?.you;
        }

        static LevelPassData DataOf(CharactersPageLink.Player pl)
        {
            var r = Roster;
            string you = null;
            if (r != null) you = CharactersPageLink.Squad(r.roster, r.demo, pl).inUse;
            if (pl == null)
            {
                // offline: the exported menu's numbers (the prototype's demo save: no XP), the dev panel's level
                var b = HudValues.Baked;
                return new LevelPassData { Level = MenuState.Level, Into = 0, Need = 0, Coins = b.Coins, Day = CharactersPageLink.Today(), YouKey = you ?? "mittens" };
            }
            return LevelPassData.FromProfile(pl.Profile, CharactersPageLink.Today(), you);
        }

        async void Claim(int[] levels, bool all)
        {
            var (ok, error, chest) = await CharactersPageLink.Claim(levels, all, lv => lv >= 1 && lv <= Layout.road.Length && Layout.road[lv - 1].k == "chest");
            if (Closed) return;
            float now = Now;
            if (chest)
            {
                // the app opens the level road on that level (its chest smash): not ported
                _m.Answer(false, null, now);
                MenuScreen.Instance?.ShowToast("Chest opening isn't in the Unity version yet", 2.2f);
                return;
            }
            _m.Answer(ok, error, now);
        }

        float _now;
        float Now => _now;

        public void Tick(float nowMs)
        {
            _now = nowMs;
            if (Closed) return;
            var pl = CharactersPageLink.Get();
            if (pl?.Profile != null && !ReferenceEquals(pl.Profile, _profileSeen))
            {
                _profileSeen = pl.Profile;
                _m.SetData(DataOf(pl), nowMs);
            }
            _view.Show(_m.Draw(nowMs));
        }

        Vector2 _downAt;
        LevelPassModel.HitKind _downHit;
        int _downLevel;
        bool _pressing, _inTrack;

        public void Input(bool down, bool held, bool up, Vector2 px, float nowMs, bool back, float wheel)
        {
            _now = nowMs;
            if (Closed) return;
            if (back) { Close(); return; }
            double pu = _m.G.Pu;
            if (wheel != 0 && px.y / pu >= 60 && px.y / pu < 178) _m.Track.Wheel(-wheel * 100);
            if (down)
            {
                _pressing = true; _downAt = px;
                _downHit = _m.HitTest(px.x, px.y, out _downLevel);
                _inTrack = px.y / pu >= 60 && px.y / pu < 178;
                if (_inTrack) _m.Track.Down(px.x / pu, nowMs);
            }
            else if (held && _pressing && _inTrack) _m.Track.Move(px.x / pu, nowMs);
            if (!up || !_pressing) return;
            _pressing = false;
            if (_inTrack && _m.Track.Up(nowMs)) return;   // (a drag isn't a tap)
            var hit = _m.HitTest(px.x, px.y, out int level);
            if (hit != _downHit || level != _downLevel) return;
            switch (hit)
            {
                case LevelPassModel.HitKind.Back: Close(); break;
                case LevelPassModel.HitKind.ClaimAll: _m.ClaimAll(nowMs); break;
                case LevelPassModel.HitKind.Level: _m.TapLevel(level, nowMs); break;
                case LevelPassModel.HitKind.Claim: _m.Claim(level, nowMs); break;
            }
        }

        void Close() { Closed = true; }

        public void Dispose() => _view.Dispose();
    }
}
