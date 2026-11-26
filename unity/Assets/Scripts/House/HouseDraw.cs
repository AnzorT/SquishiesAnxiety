// The house's piece drawings made at runtime (HOUSE_PORT_PLAN.md stage 5 on): any piece in any state, angle and sign
// text, by the page's own drawing code (tools/unity/house/draw-host.js). Nothing fills Eval yet: the JS engine plan is
// gone (the creature rig is compiled to C# instead, tools/unity/rig/jsc.mjs; the house's drawing code could be
// compiled the same way). The stage-1 export (house-pieces.json) answers first; this is
// what the room asks when the export doesn't have a drawing. Pictures come back as SVG text, named the way the export
// names them (SMIL stripped, ids renumbered, sha1: the same drawing gets the same name) and kept in Pics.
// tools/unity/house/draw-check.mjs checks the host against the export (every variant and render equal).
// Not drawn at runtime: what the export ships as PNG because the vector renderer can't draw it (text, blend modes).
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace SquishSquad.House
{
    public static class HouseDraw
    {
        /// <summary>Evaluates a JS expression in the engine and returns its string (null: no engine).</summary>
        public static Func<string, string> Eval;
        /// <summary>Runtime pictures by name (SVG text), next to Resources/House/pics.</summary>
        public static readonly Dictionary<string, string> Pics = new Dictionary<string, string>();
        static bool _init, _ok;
        static string _room;

        public static bool On => Ready();

        static bool Ready()
        {
            if (Eval == null) return false;
            if (_init) return _ok;
            _init = true;
            try { _ok = double.TryParse(Eval("String(__house.init())"), out var n) && n > 0; } catch (Exception) { _ok = false; }
            return _ok;
        }

        static string Q(string s) => s == null ? "null" : HouseJson.Stringify(s);

        static void Geo(string room)
        {
            if (room == _room) return;
            _room = room;
            Eval("String(__house.geo(" + Q(room) + "))");
        }

        static readonly Regex Smil1 = new Regex("<(animate|animateTransform|animateMotion|set|animateColor)\\b[^>]*/>");
        static readonly Regex Smil2 = new Regex("<(animate|animateTransform|animateMotion|set|animateColor)\\b[^>]*>[\\s\\S]*?</\\1>");
        static readonly Regex Ids = new Regex("\\bid=\"([^\"]+)\"");
        static readonly Regex Refs = new Regex("(\\bid=\")([^\"]+)(\")|(url\\(#)([^)]+)(\\))|(href=\"#)([^\"]+)(\")");

        /// <summary>The export's picture name for an SVG: SMIL stripped, ids renumbered in order, sha1 (16 hex).</summary>
        public static string Canon(string svg, out string canon)
        {
            var s = Smil2.Replace(Smil1.Replace(svg, ""), "");
            var map = new Dictionary<string, string>();
            foreach (Match m in Ids.Matches(s)) if (!map.ContainsKey(m.Groups[1].Value)) map[m.Groups[1].Value] = "k" + map.Count;
            s = Refs.Replace(s, m =>
            {
                string Re(string id) => map.TryGetValue(id, out var k) ? k : id;
                if (m.Groups[1].Success) return m.Groups[1].Value + Re(m.Groups[2].Value) + m.Groups[3].Value;
                if (m.Groups[4].Success) return m.Groups[4].Value + Re(m.Groups[5].Value) + m.Groups[6].Value;
                return m.Groups[7].Value + Re(m.Groups[8].Value) + m.Groups[9].Value;
            });
            canon = s;
            using var sha = SHA1.Create();
            var h = sha.ComputeHash(Encoding.UTF8.GetBytes(s));
            var sb = new StringBuilder(); for (int i = 0; i < 8; i++) sb.Append(h[i].ToString("x2"));
            return sb.ToString();
        }

        static string Pic(string svg)
        {
            if (string.IsNullOrEmpty(svg)) return "";
            if (!svg.StartsWith("<")) return "";   // (a raster picture: not made at runtime)
            var name = Canon(svg, out var canon);
            Pics[name] = canon;
            return name;
        }

        /// <summary>A renovation piece's drawing in the export's variant form ({ src, srcF, whole, bb, tb, top }, pictures
        /// by name in Pics), drawn in `room` (its scale), or null.</summary>
        public static JObj Variant(string id, string st, string txt, double? rot, string room)
        {
            if (!Ready()) return null;
            try
            {
                Geo(room);
                var o = HouseJson.Parse(Eval("__house.variant(" + Q(id) + ", " + Q(st) + ", " + Q(txt ?? "") + ", " + (rot == null ? "null" : HouseJson.JsString(rot.Value)) + ")")) as JObj;
                if (o == null) return null;
                o["src"] = Pic(o.Str("src")); o["srcF"] = Pic(o.Str("srcF")); o["whole"] = Pic(o.Str("whole"));
                return o;
            }
            catch (Exception) { return null; }
        }

        /// <summary>The robot vacuum's sprite for the dock `id` at `rot` in `room` (its scale): { src (SVG text with its
        /// SMIL), bb ([x, y, w, h] about its floor point), home }, or null.</summary>
        public static JObj Vac(string id, double? rot, string room)
        {
            if (!Ready()) return null;
            try { Geo(room); return HouseJson.Parse(Eval("__house.vac(" + Q(id) + ", " + (rot == null ? "null" : HouseJson.JsString(rot.Value)) + ")")) as JObj; }
            catch (Exception) { return null; }
        }

        /// <summary>The room's shell (House3D.shell: walls, floor, ceiling light) for its surfaces `sf` ({ slot: id, lx,
        /// lz }) and its doors' lock levels, or null (stage 6: a moved or resized light, a new surface).</summary>
        public static JObj Shell(string room, JObj sf, JObj locks)
        {
            if (!Ready()) return null;
            try { Geo(room); return HouseJson.Parse(Eval("__house.shell(" + Q(room) + ", " + Q(HouseJson.Stringify(sf)) + ", " + Q(HouseJson.Stringify(locks)) + ")")) as JObj; }
            catch (Exception) { return null; }
        }

        static readonly string[] TexPics = { "wall", "wallS", "board", "floor", "ceil", "fence", "fenceR", "wallOne", "wallOneR", "wallRnd", "ylRoom", "src" };

        /// <summary>A renovated surface's textures in the export's tex.json form (pictures by name in Pics), or null.</summary>
        public static JObj Tex(string id, string room)
        {
            if (!Ready()) return null;
            try
            {
                Geo(room);
                var o = HouseJson.Parse(Eval("__house.tex(" + Q(id) + ")")) as JObj; if (o == null) return null;
                string P(string v) => v != null && v.StartsWith("<") ? Pic(v) : v ?? "";   // (colours stay as they are)
                foreach (var k in TexPics) o[k] = P(o.Str(k));
                if (o.Obj("floorRoom")?.Arr("layers") is List<object> L) foreach (var l in L) if (l is JObj lj) lj["url"] = P(lj.Str("url"));
                return o;
            }
            catch (Exception) { return null; }
        }

        /// <summary>House3D.render's box, paths and gradients for a piece (its gradients go into `grads`), or null.</summary>
        public static JObj Render(string t, double r, double c, string v, string room, JObj grads)
        {
            if (!Ready()) return null;
            try
            {
                Geo(room);
                var o = HouseJson.Parse(Eval("__house.render(" + Q(t) + ", " + HouseJson.JsString(r) + ", " + HouseJson.JsString(c) + ", " + Q(v ?? "") + ")")) as JObj;
                if (o == null) return null;
                if (o.Obj("grads") is JObj g && grads != null) foreach (var k in g.Keys) if (!grads.Has(k)) grads[k] = g[k];
                o.Remove("grads");
                return o;
            }
            catch (Exception) { return null; }
        }
    }
}
