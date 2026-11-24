// The Main Menu's layout, as tools/unity/export-menu.mjs cut it out of the app's own menu (Resources/Menu/menu.json).
// Pixel rects are device pixels on the reference screen (Galaxy A15 landscape, 2340 x 1080), as (left, top, width,
// height) with y going down, exactly as the web page lays them out.
using System;
using UnityEngine;

namespace SquishSquad.Menu
{
    [Serializable]
    public class MenuLayout
    {
        public Reference reference;
        public Scene scene;
        public Weather[] weather;
        public Piece[] hud;
        public HudText hudText;     // where the player's numbers are drawn (MenuView.Hud.cs); null in an older export
        public NamePlate[] names;   // every roster creature's name plate, in place of the 'name' piece's (export --names)

        [Serializable]
        public class NamePlate
        {
            public string key;
            public string res;
            public int[] rect;          // reference px, as the 'name' piece's
        }

        [Serializable]
        public class HudText
        {
            public float k;             // the HUD's scale (384 / 393)
            public float hudWidth;      // its width in its own px on the reference screen
            public HudPill[] pills;
            public HudCrest crest;
        }

        [Serializable]
        public class HudPill
        {
            public string id;
            public float[] pill;        // the reference's pill box (reference px)
            public string text;
            public float[] iconOffset;  // its coin / gem picture's box from the pill's (reference px)
        }

        [Serializable]
        public class HudCrest
        {
            public float[] svg;         // the crest's <svg> (viewBox 0 0 120 104), reference px
            public float[] cin;         // .sq-cin: it floats and presses about 50 % 62 % of this
            public int level;
            public bool ring;
        }

        [Serializable]
        public class Reference
        {
            public float[] dp;      // 832, 384
            public float dpr;       // 2.8125 device px per dp
            public int[] px;        // 2340, 1080
            public string shot;
            public int level;
            public string season;
        }

        [Serializable]
        public class Scene
        {
            public float[] viewBox;      // 0, 0, 1000, 460 (drawn with "xMidYMax slice": fills the screen, bottom aligned)
            public int[] size;           // every house picture's size in pixels
            public float[] originUnits;  // the viewBox point at the picture's top-left pixel corner
            public float unitsPerPx;     // viewBox units per picture pixel
            public SceneState[] states;
            public SceneState[] parks;   // the Game Park's SVG (gzip) per state: drawn once by the vector renderer
        }

        [Serializable]
        public class SceneState
        {
            public string season;
            public int level;
            public string res;
        }

        [Serializable]
        public class Weather
        {
            public string season;
            public bool hasBand;
            public Band band;
            public bool hasBirds;
            public Birds birds;
        }

        // one band of rain / snow, repeated every `period` units; all copies slide from `from` to `to` every `ms`
        [Serializable]
        public class Band
        {
            public string res;
            public float[] rectUnits;   // where the picture sits, in viewBox units (x, y, w, h)
            public float period;
            public int[] copies;
            public float[] from;
            public float[] to;
            public float ms;
        }

        [Serializable]
        public class Birds
        {
            public string res;
            public float[] sizeUnits;
            public float[] anchorUnits; // the picture's top-left, relative to the point that follows the path
            public BirdPath[] paths;
        }

        [Serializable]
        public class BirdPath
        {
            public float ms;
            public float[] points;      // x0, y0, x1, y1 ... in viewBox units, evenly spaced in time
        }

        [Serializable]
        public class Piece
        {
            public string id;
            public string res;
            public int[] rect;          // the picture, reference px
            public float[] hit;         // the element's own box (where a tap counts), reference px
            public bool world;          // stands in the scene (moves with the house picture on other screen shapes)
            public string tap;
            public Press press;
            public bool hasFlourish;
            public Flourish flourish;
        }

        [Serializable]
        public class Press
        {
            public float dy;            // dp down while held
            public float scale = 1;     // scale while held
            public float[] pivot;       // of the hit box, 0..1
        }

        // a short burst (the crest's flap, PLAY's glint) every `every` ms, `delay` ms into the cycle, `ms` long
        [Serializable]
        public class Flourish
        {
            public float ms;
            public float every;
            public float delay;
            public int[] rect;
            public string[] frames;
        }

        public const string Root = "Menu/";

        public static MenuLayout Load()
        {
            var text = Resources.Load<TextAsset>(Root + "menu");
            if (text == null) throw new InvalidOperationException("Resources/Menu/menu.json is missing: run node tools/unity/export-menu.mjs");
            return JsonUtility.FromJson<MenuLayout>(text.text);
        }

        public Weather WeatherFor(string season)
        {
            foreach (var w in weather) if (w.season == season) return w;
            return null;
        }

        public SceneState ParkFor(string season, int level) => Nearest(scene.parks, season, level);

        // the house picture for a level and season; the nearest exported level when that one wasn't exported
        public SceneState SceneFor(string season, int level) => Nearest(scene.states, season, level);

        static SceneState Nearest(SceneState[] all, string season, int level)
        {
            if (all == null || all.Length == 0) return null;
            SceneState best = null;
            foreach (var s in all)
            {
                if (s.season != season) continue;
                if (best == null || Math.Abs(s.level - level) < Math.Abs(best.level - level)) best = s;
            }
            return best ?? all[0];
        }
    }
}
