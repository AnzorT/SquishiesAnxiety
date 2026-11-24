// The house map (HOUSE_PORT_PLAN.md stage 8): the page's openMap / mapPick / pickRoom / closeMap, and the map's
// picture: the page's own <svg> template (Resources/House/map-template.html, tools/unity/house/export-map.mjs) filled
// with the page's own mapVals, run by the draw host (__house.map: the house's look by level, the season's colours and
// weather, the rooms' tiles, locks and labels, the trees and bushes natMap draws into the two groups the page fills by
// ref). export-map.mjs checks the host's values against the page's; house-test `map` the picture's markup.
using System;
using System.Collections.Generic;
using System.Text;

namespace SquishSquad.House
{
    public sealed partial class HouseCreatures
    {
        // the page's map state: map, mapGo (the room being zoomed into), mapHov, mapIn (shown: scale 0.92 -> 1)
        public bool Map, MapIn;
        public string MapGo, MapHov;
        public HouseCreature Carry;   // the friend coming along (the selected one when the map opened)
        double _mapInAt = -1, _mapGoAt = -1;
        /// <summary>Goes to a room with a friend (the screen's enterRoom).</summary>
        public Action<string, HouseCreature> GoRoomWith;
        /// <summary>The month (0-11) the season is read from (the page's new Date().getMonth()).</summary>
        public Func<int> Month = () => DateTime.Now.Month - 1;

        public void OpenMap(double now)
        {
            Carry = SelC; Map = true; MapGo = null; MapHov = null; MapIn = false; Edit = false; ESel = null; Shop = false;
            _mapInAt = now + 40; _mapGoAt = -1; Bump();
        }
        public void CloseMap() { Carry = null; Map = false; Bump(); }

        public void MapPick(string rk, double now)
        {
            if (MapGo != null) return;
            if (!S.IsOpen(rk) || rk == S.Cur) { PickRoom(rk); return; }
            MapGo = rk; MapHov = rk; _mapGoAt = now + 650; Bump();
        }

        void PickRoom(string r)
        {
            if (!S.IsOpen(r)) { Toast("The " + (HouseFrame.RLAB.TryGetValue(r, out var n) ? n : r) + " opens at level " + HouseJson.JsString(S.D.Room(r)?["unlock"])); return; }
            var c = Carry; Carry = null;
            if (r == S.Cur) { Map = false; Bump(); }
            else { Map = false; MapGo = null; GoRoomWith?.Invoke(r, c); }
        }

        /// <summary>The map's timers: shown 40 ms after it opens; the room entered 650 ms after a pick.</summary>
        public void MapTick(double now)
        {
            if (!Map) return;
            if (_mapInAt >= 0 && now >= _mapInAt) { _mapInAt = -1; MapIn = true; Bump(); }
            if (_mapGoAt >= 0 && now >= _mapGoAt) { _mapGoAt = -1; var r = MapGo; PickRoom(r); }
        }

        /// <summary>Today's weather as the app picks it (Firestore config/weather: Menu/Weather.cs via MenuState.Season),
        /// or null: the page's SquishWeatherNow (webgame/app/bridge.js).</summary>
        public Func<string> WeatherNow;

        /// <summary>seasonNow: (2026-11-21, webgame/patches.mjs) the app's weather first; else Dec-Feb snowy, May-Sep
        /// sunny, else rainy.</summary>
        public string SeasonNow()
        {
            var w = WeatherNow?.Invoke(); if (w == "sunny" || w == "rainy" || w == "snowy") return w;
            int mo = Month(); return mo == 11 || mo <= 1 ? "snowy" : mo >= 4 && mo <= 8 ? "sunny" : "rainy";
        }

        public string MapHint => Carry != null ? Carry.Name + " is coming with you" : "Tap a place to go there";

        string _mapKey; JObj _mapVals;
        /// <summary>mapVals, from the draw host (null: no engine).</summary>
        public JObj MapVals()
        {
            var st = new JObj { ["lvl"] = (double)S.Level, ["cur"] = S.Cur, ["season"] = SeasonNow(), ["mapHov"] = MapHov, ["mapGo"] = MapGo, ["mapIn"] = MapIn };
            var open = new List<object>(); var b0 = new JObj(); var rm = new RoomModel(S);
            foreach (var rk in S.D.RKeys) if (S.IsOpen(rk)) { open.Add(rk); var sh = rm.ShellOf(rk); b0[rk] = sh?.Obj("P")?["b0"]; }
            st["open"] = open; st["b0"] = b0;
            var cs = new List<object>();
            foreach (var c in Cs) { var N = new JObj(); foreach (var k in new[] { "h", "c", "e", "f" }) N[k] = c.N.TryGetValue(k, out var v) ? v : 0; cs.Add(new JObj { ["key"] = c.Key, ["name"] = c.Name, ["room"] = c.Room, ["N"] = N, ["id"] = (double)c.Id }); }
            st["cs"] = cs;
            var key = HouseJson.Stringify(st); if (key == _mapKey) return _mapVals;
            _mapKey = key;
            try { var s = HouseDraw.Eval?.Invoke("__house.map(" + HouseJson.Stringify(key) + ")"); _mapVals = s == null ? null : HouseJson.Parse(s) as JObj; }
            catch (Exception) { _mapVals = null; }
            return _mapVals;
        }

        // ---- the picture: the template filled in, as SVG text ----
        static HouseTemplate _mapTpl;
        /// <summary>The map's &lt;svg&gt; for these values (the trees and bushes in their groups; events and hints dropped).</summary>
        public static string MapSvg(string template, JObj vals)
        {
            if (_mapTpl == null)
            {
                var t = template.Replace("ref=\"{{ natBRef }}\"", "data-nat=\"B\"").Replace("ref=\"{{ natFRef }}\"", "data-nat=\"F\"");
                int i = t.IndexOf("<svg", StringComparison.Ordinal); _mapTpl = new HouseTemplate(i > 0 ? t.Substring(i) : t);
            }
            var nat = vals.Obj("mx")?.Obj("nat");
            var sb = new StringBuilder();
            foreach (var d in _mapTpl.Render(vals)) Write(sb, d, nat);
            return sb.ToString();
        }

        static readonly HashSet<string> Void = new HashSet<string> { "stop", "path", "rect", "circle", "ellipse", "line", "polyline", "polygon", "use", "image", "animate", "animateTransform", "animateMotion", "set", "feGaussianBlur", "feOffset", "feBlend", "feColorMatrix", "feFlood", "feComposite", "feMerge", "feMergeNode" };
        static void Write(StringBuilder sb, Dom d, JObj nat)
        {
            if (d.Tag == "#text") { sb.Append(Esc(d.Text)); return; }
            if (d.Tag.StartsWith("#") || d.Tag == "!--") return;
            sb.Append('<').Append(d.Tag);
            foreach (var a in d.Attrs)
            {
                if (a.Key.StartsWith("on") || a.Key.StartsWith("hint-") || a.Key == "data-nat" || a.Key == "ref") continue;
                sb.Append(' ').Append(a.Key).Append("=\"").Append(Esc(a.Value ?? "")).Append('"');
            }
            var nk = d["data-nat"];
            if (d.Children.Count == 0 && nk == null && Void.Contains(d.Tag)) { sb.Append("/>"); return; }
            sb.Append('>');
            if (nk != null && nat != null) sb.Append(nat.Str(nk) ?? "");
            foreach (var c in d.Children) Write(sb, c, nat);
            sb.Append("</").Append(d.Tag).Append('>');
        }
        static string Esc(string s) => s.Replace("&", "&amp;").Replace("<", "&lt;").Replace("\"", "&quot;");
    }
}
