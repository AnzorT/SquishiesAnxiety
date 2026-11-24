// Squish Hop's screen for GameScreen (src/screens/HopScreen.js on develop): the hub (src/hop/Hub.js: the games' GameHub,
// Games/Shared/ModeHub, with Squish Hop's pictures; HOW TO PLAY there), then the level map (a band per Crib room, the
// room's picture over its banner: "KITCHEN · ARROWS", the room's name and the twist it brings in) through the rooms its
// levels are played in (royal/WorldBg.js RoomBackdrop: LevelMap DrawRooms), the title on a plaque, the star pill. The
// record is the profile's `hop` (Levels.Record).
using System.Collections.Generic;
using SquishSquad.Games.Shared;

namespace SquishSquad.Games.Hop
{
    public sealed class HopDef : GameDef
    {
        readonly IDictionary<string, object> _profile;
        public HopDef(IDictionary<string, object> profile) { _profile = profile; }
        HopRecord Rec => Levels.Record(_profile);
        public override string Id => "hop";
        public override string Title => "SQUISH HOP";
        // (the title on a plaque over the room behind the map)
        public override bool Plaque => true;
        public override string Sub => $"{Levels.DoneOf(Rec)} / {Levels.LEVELS} levels";
        public override string Stars => ((int)Levels.StarsOf(Rec)).ToString();
        public override bool Seen => Rec.Seen;
        public override void MarkSeen()
        {
            if (!(_profile.TryGetValue("hop", out var v) && v is IDictionary<string, object> d)) _profile["hop"] = d = new Dictionary<string, object>();
            d["seen"] = true;
            HopSave.Record(new Dictionary<string, object> { { "hop.seen", true } });   // HopScreen.js
        }

        // a room's banner: its name and the twist it brings in
        static string BannerOf(int i)
        {
            var L = Levels.LEVEL_LIST[i];
            LevelListEntry twist = null;
            foreach (var x in Levels.LEVEL_LIST) if (x.Band == L.Band && !string.IsNullOrEmpty(x.News)) { twist = x; break; }
            return Levels.ROOMS[L.Room].Name.ToUpperInvariant() + (twist != null ? " · " + Levels.TWISTS[twist.News].Name : "");
        }

        static readonly Dictionary<string, MapIcon> Rooms = new Dictionary<string, MapIcon>();
        // hop/Room.js RoomCard (164 x 96 and its white border), exported: Resources/Maps/room-<room>
        static MapIcon RoomOf(int i)
        {
            string room = Levels.LEVEL_LIST[i].Room;
            if (!Rooms.TryGetValue(room, out var ic))
            {
                var (w, h) = HubsData.Current.Size("room-" + room);
                Rooms[room] = ic = new MapIcon(room, HubsData.LoadXml("Maps/room-" + room), w, h);
            }
            return ic;
        }

        public override LevelMap NewMap(float w, float top, float h)
        {
            var list = new List<MapLevel>();
            foreach (var l in Levels.LEVEL_LIST) list.Add(new MapLevel(l.Band, l.Tier));
            // the rooms behind the map (HopScreen.js roomOf), the row on their floor (ROW_ON_FLOOR)
            var map = new LevelMap(list, w, top, h, HubsData.Arts(HubsData.Current.hopCast), BannerOf, RoomOf, roomOf: i => Levels.LEVEL_LIST[i].Room, rowAt: 0.75f);
            Refresh(map);
            return map;
        }

        public override Hub NewHub(GameScreen screen)
        {
            var rec = Levels.Record(_profile);
            return new ModeHub("SQUISH HOP", "Hop", rec.Lv, Levels.DoneOf(rec), Levels.LEVELS, (int)Js.ToNumber(rec.BlitzTop),
                () => screen.Go("map"), () => screen.OnBlitz?.Invoke(null), () => screen.ShowRules(true));
        }

        public override void Refresh(LevelMap map)
        {
            var rec = Levels.Record(_profile);
            map.SetRecord(rec.Lv, lv => rec.Best.TryGetValue(Js.KeyOf(lv), out var v) && Js.Truthy(v) ? (int)Js.ToNumber(v) : 0);
        }
    }
}
