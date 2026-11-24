// The Characters page on screen (CHARACTERS on the menu, as webgame/app/menu.js M.characters): CharactersModel says
// what to draw, CharactersPageView draws it, this hands it the player and the touches and saves CHOOSE
// (CharactersPageLink). MenuScreen opens it and passes it the input while it's open.
using System;
using System.Collections.Generic;
using SquishSquad.Ui;
using UnityEngine;

namespace SquishSquad.Menu
{
    public sealed class CharactersPage : IMenuPage
    {
        readonly CharactersModel _m;
        readonly CharactersPageView _view;
        object _profileSeen;
        readonly float _openedReal;
        public bool Closed { get; private set; }
        public bool Covers => true;   // (develop: whole from its first frame, the menu under it not drawn: PageMotion.Layer)

        /// <summary>Opens the page (null: not exported: tools/unity/export-pages.mjs).</summary>
        public static CharactersPage Open(Transform parent, float w, float h, float nowMs, int order)
        {
            UiFont.ReadJson ??= n => Resources.Load<TextAsset>("Fonts/" + n)?.text;
            UiFont.ParseJson ??= j => JsonUtility.FromJson<UiFontData>(j);
            var l = LevelPassPage.Roster;
            return l == null ? null : new CharactersPage(l, parent, w, h, nowMs, order);
        }

        CharactersPage(CharactersLayout l, Transform parent, float w, float h, float nowMs, int order)
        {
            _openedReal = Time.unscaledTime * 1000;
            var pl = CharactersPageLink.Get();
            _profileSeen = pl?.Profile;
            var (owned, inUse) = CharactersPageLink.Squad(l.roster, l.demo, pl);
            int tips = l.gs?.tips?.Length ?? 1;
            _m = new CharactersModel(l, w, h, owned, inUse, nowMs, UnityEngine.Random.Range(0, Math.Max(1, tips)));
            _m.OnChoose = key => { var c = Array.Find(l.roster, x => x.key == key); if (c != null) CharactersPageLink.Select(c); };
            _m.OnShop = () =>
            {
                // the app closes the page and opens the Shop (not in the Unity version yet)
                Closed = true;
                MenuScreen.Instance?.ShowToast("The Shop isn't in the Unity version yet", 2f);
            };
            _view = new CharactersPageView(CharactersLayout.Root, parent, order);
            // the row's first cards decoded while the loading screen plays (the app holds it until they've loaded)
            _warm = new Queue<string>();
            foreach (var g in l.groups) foreach (var id in g.ids) { var c = Array.Find(l.roster, x => x.id == id); if (c != null) _warm.Enqueue(c.key); }
        }

        readonly Queue<string> _warm;

        public void Tick(float nowMs)
        {
            if (Closed) return;
            var pl = CharactersPageLink.Get();
            if (pl?.Profile != null && !ReferenceEquals(pl.Profile, _profileSeen))
            {
                _profileSeen = pl.Profile;
                var (owned, inUse) = CharactersPageLink.Squad(_m.L.roster, _m.L.demo, pl);
                _m.SetOwned(owned, inUse);
            }
            // a few pictures a frame, before they're scrolled to
            for (int i = 0; i < 3 && _warm.Count > 0; i++)
            {
                var k = _warm.Dequeue();
                var set = Array.Find(_m.L.cards, x => x.key == k);
                if (set != null) { _view.Picture(_m.Owns(k) ? set.card.res : set.locked.res); }
            }
            _view.Show(_m.Draw(nowMs));
        }

        bool _pressing, _inRow;
        CharactersModel.HitKind _downHit;
        string _downKey;

        public void Input(bool down, bool held, bool up, Vector2 px, float nowMs, bool back, float wheel)
        {
            if (Closed) return;
            if (back) { Closed = true; return; }
            double pu = _m.G.Pu;
            bool rowY = px.y / pu >= 284;
            if (wheel != 0 && rowY) _m.Row.Wheel(-wheel * 100);
            if (down)
            {
                _pressing = true;
                _downHit = _m.HitTest(px.x, px.y, out _downKey);
                _inRow = rowY && !_m.Loading(nowMs);
                if (_inRow) _m.Row.Down(px.x / pu, nowMs);
                if (_downHit == CharactersModel.HitKind.Card) _m.Press(_downKey, nowMs);
            }
            else if (held && _pressing && _inRow)
            {
                _m.Row.Move(px.x / pu, nowMs);
                if (_m.Row.Moved) _m.Release(nowMs);
            }
            if (!up || !_pressing) return;
            _pressing = false;
            _m.Release(nowMs);
            if (_inRow && _m.Row.Up(nowMs)) return;   // (a drag isn't a tap)
            var hit = _m.HitTest(px.x, px.y, out string key);
            if (hit != _downHit || key != _downKey) return;
            switch (hit)
            {
                case CharactersModel.HitKind.Back: Closed = true; break;
                case CharactersModel.HitKind.Prev: _m.Jump(-1, nowMs); break;
                case CharactersModel.HitKind.Next: _m.Jump(1, nowMs); break;
                case CharactersModel.HitKind.Act: _m.Act(nowMs); break;
                case CharactersModel.HitKind.Card: _m.Choose(key, nowMs); break;
            }
        }

        public void Dispose() => _view.Dispose();
    }
}
