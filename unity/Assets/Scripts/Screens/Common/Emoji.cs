// The characters no font of the app has (🔥, ⏱), as Chrome draws them: Resources/Screens/emoji/<name>.png with their
// box and advance (Resources/Screens/emoji.json, tools/unity/export-screens.mjs).
using System.Collections.Generic;
using SquishSquad.Backend;

namespace SquishSquad.Screens
{
    public sealed class Emoji
    {
        public string Name;
        public float W, H, Adv, Base;

        static Dictionary<string, Emoji> _all;
        public static Emoji Of(string name)
        {
            if (_all == null)
            {
                _all = new Dictionary<string, Emoji>();
                var j = Prof.Map(Json.Parse(Roster.ReadText?.Invoke("Screens/emoji") ?? "{}"));
                foreach (var kv in j)
                {
                    var m = Prof.Map(kv.Value);
                    _all[kv.Key] = new Emoji { Name = kv.Key, W = (float)Prof.Num(m["w"]), H = (float)Prof.Num(m["h"]), Adv = (float)Prof.Num(m["adv"]), Base = (float)Prof.Num(m["base"]) };
                }
            }
            return _all.TryGetValue(name, out var e) ? e : new Emoji { Name = name, W = 10, H = 10, Adv = 10 };
        }
    }
}
