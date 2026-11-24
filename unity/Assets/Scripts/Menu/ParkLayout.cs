// The Game Park's games carousel as tools/unity/export-park.mjs cut it out of the app (Resources/Park/park.json).
// Plain C# (no UnityEngine): Unity reads it with JsonUtility, tools/unity/park-test with System.Text.Json.
//   "pu": the park page's own CSS px (webgame/app/menu.js puts the page at scale(k), k = H / 393 dp, so a pu is
//         H / 393 screen px on any screen); "px": device pixels on the reference screen (2340 x 1080).
//   A picture's `at` is its top-left minus its element's box's top-left (reference px): Unity puts the box where
//   showGames' formulas say for the screen at hand and the picture at the same offset from it.
using System;

namespace SquishSquad.Menu
{
    [Serializable]
    public class ParkLayout
    {
        public Ref reference;
        public Game[] games;
        public Dim dim;
        public Header header;
        public Pic rays, halo, arrowL, arrowR;
        public Dot dotOn, dotOff;
        public float[] dots;          // each dot's box at rest (x, y, w, h, ...), pu: only to check the formulas
        public Go go;
        public Pic goDim;
        public Card[] cards;

        [Serializable]
        public class Ref
        {
            public int[] px;          // 2340, 1080
            public float[] dp;        // 832, 384
            public float dpr;         // 2.8125
            public float k;           // the page's scale (384 / 393)
            public float u;           // px per pu
            public float pgW;         // the page's width, pu (W / k)
            public float carL;        // the carousel's left edge, pu
            public float CW;          // the card's width, pu
            public string creature;   // whose card Squish Time shows
        }

        [Serializable]
        public class Game
        {
            public string id;
            public string name;
            public bool open;
        }

        [Serializable]
        public class Pic
        {
            public string res;        // Resources/Park/<res>.png
            public float[] at;        // picture top-left relative to its element's box, px
            public int[] size;        // picture size, px
        }

        [Serializable]
        public class Dim
        {
            public string res;
            public float[] box;
            public int[] rect;
        }

        [Serializable]
        public class Header : Pic
        {
            public float[] box;       // the header row (.mm-pgh), pu
            public float[] back;      // the back orb, px relative to the header's box
        }

        [Serializable]
        public class Dot : Pic
        {
            public float[] box;       // pu, at rest
        }

        [Serializable]
        public class Go : Pic
        {
            public float[] box;       // the PLAY button, px relative to its card's box (the slot)
        }

        [Serializable]
        public class Card
        {
            public string id;
            public Pic card;          // relative to the slot's box
            public float[] win;       // the window, px relative to the slot's box
            public float[] go;        // the PLAY button, px relative to the slot's box
            public Pic over;          // the window's inner shadow, relative to the window's box
            public Pic mask;          // the window's shape, relative to the window's box
            public bool hasClip;
            public Clip clip;
            public bool hasSquish;
            public Squish squish;
        }

        [Serializable]
        public class Clip
        {
            public string file;       // StreamingAssets/<file>
            public int[] size;        // the clip's frame size, px
        }

        // Squish Time's card when its creature has no clip of its own: the creature squished by CSS keyframes
        [Serializable]
        public class Squish
        {
            public Part img, l, r;
        }

        [Serializable]
        public class Part : Pic
        {
            public float[] box;       // the element's box, px relative to the window's box
        }

        public const string Root = "Park/";
    }
}
