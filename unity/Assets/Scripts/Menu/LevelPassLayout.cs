// The Level Pass as tools/unity/export-pages.mjs cut it out of the app (Resources/LevelPass/levelpass.json). Plain C#:
// Unity reads it with JsonUtility, tools/unity/pages-test with System.Text.Json. Units: see CharactersPageKit.cs.
using System;

namespace SquishSquad.Menu
{
    [Serializable]
    public class LevelPassLayout
    {
        public const string Root = "LevelPass/";

        public PageRef reference;
        public PagePic bg, head, allBox, lvxBox, pillBox, coin, bar, barFill, rail, railFill, you, youPtr, arrow, panel, lock16, flyCoin, flyGem, toast;
        public float[] back, lvCol, togoText, toastText;
        public Disc[] discs;
        public Num[] nums;
        public Badge[] badges;
        public Title[] titles;
        public Sub[] subs;
        public Act[] acts;
        public Card[] cards;
        public Row[] rows;
        public Group[] groups;
        public string[] allGroupKeys;
        public ChestNames[] chestNames;
        public Prize[] road;
        public Measured measured;

        [Serializable] public class Disc : PagePic { public string id; }
        [Serializable] public class Num : PagePic { public int L; public bool on; public float[] button; }
        [Serializable] public class Badge : PagePic { public string id; public float[] button; }
        [Serializable] public class Title : PagePic { public int L; public bool reached; }
        [Serializable] public class Sub : PagePic { public string text; }
        [Serializable] public class Act : PagePic { public string id; }
        [Serializable] public class Card : PagePic { public string key; public int count; }
        [Serializable] public class Row { public int L; public string[] unlocks; }
        [Serializable] public class Group { public string key; public string name; public bool @out; }
        [Serializable] public class ChestNames { public string g; public string[] names; }
        [Serializable] public class Prize { public string k; public float n; public string t; }

        /// <summary>The boxes the app laid out with the test player (pu): the Unity layout is checked against them.</summary>
        [Serializable]
        public class Measured
        {
            public float[] pgh, all, lvx, lvxB, bar, fill, small, pill, pillImg, pillTx, track, rail, railFill, you, youp, ln1, panel, lv, act, items, it;
        }
    }
}
