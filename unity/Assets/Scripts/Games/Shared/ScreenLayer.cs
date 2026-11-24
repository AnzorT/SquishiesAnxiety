// What the game screens (the hubs, the level map, the header, the placeholders) are drawn as: layers, each an SVG (or a
// picture) in its own box, placed every frame with a 2D transform (screen dp) and an opacity, the way React Native
// moves a view. Pure C# (no UnityEngine): the tests (tools/unity/maps-test) draw the same layers with the reference
// rasteriser, GameScreenHost shows them in Unity as UiPieces.
using System;
using System.Collections.Generic;
using System.Globalization;
using SquishSquad.Games.Sort;
using SquishSquad.Vector;

namespace SquishSquad.Games.Shared
{
    public sealed class ScreenLayer
    {
        public readonly string Name;
        public string Markup { get; private set; }
        /// <summary>A picture filling the box (a Resources path; ".jpg": JPEG bytes, Resources/&lt;path&gt;.bytes).</summary>
        public string Picture { get; private set; }
        public float W { get; private set; }
        public float H { get; private set; }
        public float Margin { get; private set; } = 6;
        /// <summary>Goes up whenever the markup or box changes (the texture is drawn again).</summary>
        public int Version { get; private set; }
        public Affine Transform = Affine.Identity;
        public float Opacity = 1;
        public bool Visible = true;
        /// <summary>A Sort container's door: projected with its perspective (Sort's DoorView) instead of Transform.</summary>
        public DoorView Door;
        /// <summary>The markup's key: Set with the same key keeps the markup without building it again.</summary>
        public string Key { get; private set; }

        public ScreenLayer(string name) { Name = name; }

        public void Set(string markup, float w, float h, float margin = 6)
        {
            if (markup == Markup && w == W && h == H && margin == Margin && Picture == null) return;
            Markup = markup; Picture = null; W = w; H = h; Margin = margin; Version++;
        }

        /// <summary>Builds the markup only when `key` changed.</summary>
        public void Set(string key, Func<string> build, float w, float h, float margin = 6)
        {
            if (key == Key && Markup != null && w == W && h == H && margin == Margin) return;
            Key = key;
            Set(build(), w, h, margin);
        }

        public void SetPicture(string href, float w, float h)
        {
            if (href == Picture && w == W && h == H && Markup == null) return;
            Picture = href; Markup = null; Key = null; W = w; H = h; Margin = 0; Version++;
        }
    }

    /// <summary>A frame's layers in paint order: L(name) brings the layer of that name (made once) to the end of this
    /// frame's list, reset (identity, opaque, visible).</summary>
    public sealed class LayerFrame
    {
        readonly Dictionary<string, ScreenLayer> _all = new Dictionary<string, ScreenLayer>();
        public readonly List<ScreenLayer> List = new List<ScreenLayer>();

        public void Begin() => List.Clear();

        public ScreenLayer L(string name)
        {
            if (!_all.TryGetValue(name, out var l)) _all[name] = l = new ScreenLayer(name);
            l.Transform = Affine.Identity; l.Opacity = 1; l.Visible = true; l.Door = null;
            List.Add(l);
            return l;
        }

        /// <summary>Forgets the layers whose names start with `prefix` (a view that went).</summary>
        public void Drop(string prefix)
        {
            var gone = new List<string>();
            foreach (var k in _all.Keys) if (k.StartsWith(prefix, StringComparison.Ordinal)) gone.Add(k);
            foreach (var k in gone) _all.Remove(k);
        }
    }

    /// <summary>Resources/Hubs/hubs.json (tools/unity/export-maps.mjs): the exported pieces' sizes, the rules cards'
    /// buttons, and the squishies each screen shows (Resources/Stack/art file names, in the app's order).</summary>
    [Serializable]
    public sealed class HubsData
    {
        [Serializable] public sealed class Piece { public string name; public float w, h; }
        [Serializable] public sealed class Rules { public string game, label, kind, title, titleFill; public float padH, padV, fontSize, marginTop, titleSize; public float[] at, size, titleAt; }
        [Serializable] public sealed class Pools { public string[] fridge, cupboard; }
        public Piece[] pieceList;
        public Rules[] rulesList;
        public string[] stackCast, hopCast, rooms;
        public Pools sortPools;

        /// <summary>The text of an exported piece (Resources/&lt;path&gt;.xml); set by the host.</summary>
        public static Func<string, string> LoadXml;
        /// <summary>The data; set by the host.</summary>
        public static HubsData Current;

        public (float w, float h) Size(string name)
        {
            foreach (var p in pieceList) if (p.name == name) return (p.w, p.h);
            throw new InvalidOperationException("Hubs/hubs.json has no piece " + name + ": run node tools/unity/export-maps.mjs");
        }

        public Rules RulesOf(string game)
        {
            foreach (var r in rulesList) if (r.game == game) return r;
            throw new InvalidOperationException("Hubs/hubs.json has no rules for " + game);
        }

        public static string Art(string file) => string.IsNullOrEmpty(file) ? null : "Stack/art/" + file;
        public static List<string> Arts(string[] files) { var l = new List<string>(); if (files != null) foreach (var f in files) l.Add(Art(f)); return l; }
    }

    static class Num
    {
        public static string S(double v) => v.ToString("0.###", CultureInfo.InvariantCulture);
        /// <summary>A JS number as text (integers without a point).</summary>
        public static string Js(double v) => v == Math.Floor(v) && Math.Abs(v) < 1e15 ? ((long)v).ToString(CultureInfo.InvariantCulture) : v.ToString("R", CultureInfo.InvariantCulture);
    }
}
