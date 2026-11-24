// Squish Stack's screen for GameScreen (src/screens/StackScreen.js) and its hub (src/stack/Hub.js, landscape: develop's
// GameHub, Squishdoku's pieces with this game's pictures: REGULAR MODE with the 50 levels' bar, BLITZ MODE with the best
// run, HOW TO PLAY). Its map is the forest road (ForestMap.js) with this game's levels, a banner per size band
// ("4 SQUISHIES · 3 CUSHIONS"). The record is the profile's `stack` (Levels.Record).
using System;
using System.Collections.Generic;
using Facebook.Yoga;
using SquishSquad.Games.Shared;
using SquishSquad.Ui;
using SquishSquad.Ui.Cards;
using SquishSquad.Ui.Screens;
using SquishSquad.Vector;

namespace SquishSquad.Games.Stack
{
    public sealed class StackDef : GameDef
    {
        readonly IDictionary<string, object> _profile;
        public StackDef(IDictionary<string, object> profile) { _profile = profile; }
        StackRecord Rec => Levels.Record(_profile);
        public override string Id => "stack";
        public override string Title => "SQUISH STACK";
        public override string Sub => $"{(int)Levels.DoneOf(Rec)} / {Levels.LEVELS} levels";
        public override string Stars => ((int)Levels.StarsOf(Rec)).ToString();
        public override bool Seen => Rec.Seen;
        public override void MarkSeen()
        {
            Section(_profile, "stack")["seen"] = true;
            StackSave.Record(new Dictionary<string, object> { { "stack.seen", true } });   // StackScreen.js
        }
        public static List<string> Cast => HubsData.Arts(HubsData.Current.stackCast);

        internal static IDictionary<string, object> Section(IDictionary<string, object> profile, string key)
        {
            if (profile.TryGetValue(key, out var v) && v is IDictionary<string, object> d) return d;
            var n = new Dictionary<string, object>();
            profile[key] = n;
            return n;
        }

        public override LevelMap NewMap(float w, float top, float h)
        {
            var list = new List<MapLevel>();
            foreach (var l in Levels.LEVEL_LIST) list.Add(new MapLevel(l.Band, l.Tier));
            // develop: the forest road (src/stack/ForestMap.js, road.js), the whole screen
            var bands = new List<int>();
            foreach (var l in Levels.LEVEL_LIST) bands.Add(l.Band);
            var (nodes, signs, width) = Road.Layout(bands);
            string season = Season == "rainy" || Season == "snowy" ? Season : "sunny";
            var tiles = new string[Road.TILES];
            for (int i = 0; i < tiles.Length; i++) tiles[i] = $"Stack/forest/{season}-{i}.jpg";
            var forest = new MapForest { Tiles = tiles, TileW = Road.TILE_W, TileH = Road.TILE_H, RoadW = Road.ROAD_W, Width = width, Nodes = nodes, Signs = signs, RoadY = Road.Y };
            // the walker: the player's selected character (StackScreen.js walker)
            forest.Walker = Walker; forest.WalkerAr = Walker != null ? TrioItem.ArOf(Walker) : 0;
            var map = new LevelMap(list, w, top, h, Cast, i => $"{Levels.LEVEL_LIST[i].N} SQUISHIES · {Levels.LEVEL_LIST[i].K} CUSHIONS", null, forest);
            Refresh(map);
            return map;
        }

        public override bool FullMap => true;

        public override void Refresh(LevelMap map)
        {
            var rec = Rec;
            map.SetRecord((int)rec.Lv, lv => (int)Js.ToNum(Js.Or(Js.Get(rec.Best, Js.Int(lv)), 0.0)));
        }

        public override Hub NewHub(GameScreen screen) => StackHub.New(_profile, screen);
    }

    /// <summary>src/stack/Hub.js: the new design's GameHub (Games/Shared/ModeHub) with Squish Stack's pictures.</summary>
    public static class StackHub
    {
        public static Hub New(IDictionary<string, object> profile, GameScreen screen)
        {
            var rec = Levels.Record(profile);
            return new ModeHub("SQUISH STACK", "Stack", (int)rec.Lv, (int)Levels.DoneOf(rec), Levels.LEVELS, (int)rec.Blitz.Top,
                () => screen.Go("map"), () => screen.OnBlitz?.Invoke(null), () => screen.ShowRules(true));
        }
    }
}
