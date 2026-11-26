// The Characters page on screen (CHARACTERS on the menu, as webgame/app/menu.js M.characters): CharactersModel says
// what to draw, CharactersPageView draws it, this hands it the player and the touches and saves CHOOSE
// (CharactersPageLink). MenuScreen opens it and passes it the input while it's open.
using System;
using System.Collections.Generic;
using SquishSquad.Creatures;
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
            // only the creatures that are out (config/roster, Screens/RosterConfig), as the app's page shows them
            var l = LevelPassPage.Roster?.Only(c => SquishSquad.Screens.RosterConfig.IdOut(c.id.ToString(System.Globalization.CultureInfo.InvariantCulture)));
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
            _parent = parent;
            _order = order;
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
            TickLive(nowMs);
            _view.Show(_m.Draw(nowMs));
        }

        // ---- the creature on the platform, live (menu.js showRig: the app mounts its rig there, a new one for each
        // creature picked, popping in; greyed when not owned) and reacting to touches (CreatureTouch) ----
        readonly Transform _parent;
        readonly int _order;
        CreatureView _live;
        NativeRig _liveRig;
        string _liveKey;
        bool _mounted, _greeted;
        double _liveAt;
        Vector3 _liveHome;
        readonly CreatureTouch _touch = new CreatureTouch();
        static readonly string[] OwnHello = { "happy", "love", "cheer" }, LockedHello = { "look", "surprised" };

        void TickLive(double now)
        {
            if (!_mounted || _m.Pick != _liveKey) Mount(_m.Pick, now);
            if (_live == null) return;
            var (sc, ty, op) = _m.PopAt(now);
            // sqPop: scaled about the box's middle after a move ty pu down (world y up)
            double pu = _m.G.Pu; var b = _m.RigBox;
            var c = new Vector3((float)((b[0] + b[2] / 2) * pu), -(float)((b[1] + b[3] / 2) * pu), 0);
            float s = (float)sc;
            _live.transform.localPosition = c + s * (_liveHome - c + new Vector3(0, -(float)(ty * pu), 0));
            _live.transform.localScale = new Vector3(s, s, 1);
            _live.SetOpacity((float)(op * (1 - _m.LoaderOpacity(now))));
            // .sil: filter saturate(.3) brightness(.78) (its glow left out)
            bool own = _m.Owns(_liveKey);
            _live.SetTint(own ? Color.white : new Color(.78f, .78f, .78f, 1), own ? 1 : .3f);
            // 350 ms after it's mounted: happy / love / cheer, or for one not owned, look / surprised
            if (!_greeted && now - _liveAt >= 350)
            {
                _greeted = true;
                var l = own ? OwnHello : LockedHello;
                _live.Play(l[UnityEngine.Random.Range(0, l.Length)]);
            }
        }

        void Mount(string key, double now)
        {
            _mounted = true;
            _touch.Drop();
            if (_live != null) { Kill(_live.gameObject); _live = null; }   // (its rig leaves with it: CreatureView.OnDestroy)
            _liveRig = null;
            _liveKey = key;
            _m.LiveKey = null;
            if (key == null) return;
            var rig = NativeRig.Create(key);
            if (rig == null) return;   // (the rig can't run: the still, as before)
            double pu = _m.G.Pu; var b = _m.RigBox;
            _live = CreatureView.Create(_parent, rig, new Rect((float)(b[0] * pu), (float)(b[1] * pu), (float)(b[2] * pu), (float)(b[3] * pu)), _order + 1);
            _liveHome = _live.transform.localPosition;
            _live.Failed = _ => { _m.LiveKey = null; };   // (its still instead)
            _liveRig = rig;
            _m.LiveKey = key;
            _liveAt = now;
            _greeted = false;
        }

        // a page px (y down) on the creature's 0-100 box
        Vector2 LiveBox(Vector2 px) => _live.BoxPoint(_parent.TransformPoint(new Vector3(px.x, -px.y, 0)));

        static void Kill(UnityEngine.Object o) { if (o == null) return; if (Application.isPlaying) UnityEngine.Object.Destroy(o); else UnityEngine.Object.DestroyImmediate(o); }

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
            // a finger on the creature is its rig's until it lifts (a poke, a squeeze, a turn)
            if (_touch.Active)
            {
                if (_live == null) _touch.Drop();
                else if (up) _touch.Up();
                else if (held) _touch.Move(LiveBox(px));
                return;
            }
            if (down && _live != null && _m.LiveKey == _liveKey && !_m.Loading(nowMs) && _m.HitTest(px.x, px.y, out _) == CharactersModel.HitKind.None)
            {
                var b = LiveBox(px);
                if (CreatureTouch.InBox(b)) { _touch.Down(_liveRig, b); return; }
            }
            if (down)
            {
                _pressing = true;
                _downHit = _m.HitTest(px.x, px.y, out _downKey);
                _inRow = rowY && !_m.Loading(nowMs);
                if (_inRow) _m.Row.Down(px.x / pu, nowMs);
                if (_downHit == CharactersModel.HitKind.Card) _m.Press(_downKey, nowMs);
            }
            // a button (not a card: those have their own press) shrinks while the finger stays on it
            if (_pressing && (down || held) && _downHit != CharactersModel.HitKind.Card && _downHit != CharactersModel.HitKind.None)
                _m.Held = _m.HitTest(px.x, px.y, out _) == _downHit && !(_inRow && _m.Row.Moved) ? _downHit : CharactersModel.HitKind.None;
            else if (held && _pressing && _inRow)
            {
                _m.Row.Move(px.x / pu, nowMs);
                if (_m.Row.Moved) _m.Release(nowMs);
            }
            if (!up || !_pressing) return;
            _pressing = false;
            _m.Held = CharactersModel.HitKind.None;
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

        public void Dispose()
        {
            _touch.Drop();
            if (_live != null) { Kill(_live.gameObject); _live = null; }
            _view.Dispose();
        }
    }
}
