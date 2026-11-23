// The Characters page's and the Level Pass's link to the player: the live profile, and what the app does for them
// (App.js handleGameSelect / handleGameClaim):
//   CHOOSE      setLobbySelected(uid, id): lobby.sel and lobby.seen (UserData.SetLobbySelected) when signed in, else
//               kept on this device (PlayerPrefs), as the offline menu's own choice
//   CLAIM       squad levelClaim { i } / levelClaimAll (the server pays the prize; the profile refreshes after); a chest's
//               level isn't claimed here: the app opens its level road (the chest smash) there, which Unity hasn't yet
//   who owns what: functions/squad.js owns (col[id] or ownedIds), src/squad/lobby.js selectedId
// The signed-in player comes from App/AppFlow, which sets `Source`.
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using SquishSquad.Backend;
using UnityEngine;

namespace SquishSquad.Menu
{
    public static class CharactersPageLink
    {
        public sealed class Player
        {
            public IDictionary<string, object> Profile;
            public string Uid;
            public FirebaseClient Fb;
        }

        /// <summary>The signed-in player (null: offline / signed out). Set by App/AppFlow.</summary>
        public static Func<Player> Source;

        public static Player Get() => Source?.Invoke();

        // ---- who owns what (functions/squad.js owns, src/squad/lobby.js selectedId) ----------------------------------
        public static bool Owns(IDictionary<string, object> p, string id)
        {
            if (p == null || id == null) return false;
            if (p.TryGetValue("col", out var c) && c is IDictionary<string, object> col && col.TryGetValue(id, out var e) && e != null) return true;
            if (p.TryGetValue("ownedIds", out var o) && o is IList<object> ids) foreach (var x in ids) if (Convert.ToString(x, CultureInfo.InvariantCulture) == id) return true;
            return false;
        }

        public static string SelectedId(IDictionary<string, object> p)
        {
            if (p != null && p.TryGetValue("lobby", out var l) && l is IDictionary<string, object> lobby && lobby.TryGetValue("sel", out var s) && s != null)
            {
                var sel = Convert.ToString(s, CultureInfo.InvariantCulture);
                if (Owns(p, sel)) return sel;
            }
            var own = new List<string>();
            if (p != null && p.TryGetValue("col", out var c) && c is IDictionary<string, object> col) own.AddRange(col.Keys);
            if (p != null && p.TryGetValue("ownedIds", out var o) && o is IList<object> ids) foreach (var x in ids) { var k = Convert.ToString(x, CultureInfo.InvariantCulture); if (!own.Contains(k)) own.Add(k); }
            return own.Contains("1") ? "1" : own.Count > 0 ? own[0] : "0";
        }

        /// <summary>The creatures (keys) the player owns and the one in use, by the page's roster; offline the exported
        /// demo save's, with this device's own choice.</summary>
        public static (List<string> owned, string inUse) Squad(CharactersLayout.Creature[] roster, CharactersLayout.Demo demo, Player pl)
        {
            var owned = new List<string>();
            if (pl == null)
            {
                if (demo?.owned != null) owned.AddRange(demo.owned);
                var local = PlayerPrefs.GetString(LocalSelKey, "");
                return (owned, owned.Contains(local) ? local : demo?.sel);
            }
            foreach (var c in roster) if (c.appId != null && Owns(pl.Profile, c.appId)) owned.Add(c.key);
            var sid = SelectedId(pl.Profile);
            string inUse = null;
            foreach (var c in roster) if (c.appId == sid) inUse = c.key;
            return (owned, inUse ?? (owned.Count > 0 ? owned[0] : null));
        }

        public const string LocalSelKey = "squishsquad.menu.sel";

        /// <summary>CHOOSE: the app's selectSquishy (setLobbySelected) signed in; else this device's choice.</summary>
        public static void Select(CharactersLayout.Creature c)
        {
            var pl = Get();
            if (pl == null || c.appId == null) { PlayerPrefs.SetString(LocalSelKey, c.key); PlayerPrefs.Save(); return; }
            _ = pl.Fb.Data.SetLobbySelected(pl.Uid, c.appId);
        }

        /// <summary>A Level Pass claim (App.js handleGameClaim): → (ok, error, chest). `chest`: a level whose prize is a
        /// chest (the app opens its level road for those).</summary>
        public static async Task<(bool ok, string error, bool chest)> Claim(int[] levels, bool all, Func<int, bool> isChest)
        {
            foreach (var lv in levels) if (isChest(lv)) return (false, null, true);
            var pl = Get();
            if (pl == null) return (true, null, false);   // (offline: the page's own fake, as the web page outside the app)
            try
            {
                var args = new Dictionary<string, object> { ["tzOffsetMinutes"] = TimeZoneInfo.Local.GetUtcOffset(DateTime.Now).TotalMinutes };
                if (levels.Length > 1 || all) args["move"] = "levelClaimAll";
                else { args["move"] = "levelClaim"; args["i"] = (double)levels[0]; }
                var res = await pl.Fb.Data.CallAndRefresh("squad", args);
                if (res is IDictionary<string, object> m && m.TryGetValue("error", out var err) && err != null) return (false, Convert.ToString(err, CultureInfo.InvariantCulture), false);
                return (true, null, false);
            }
            catch (Exception e)
            {
                return (false, e.Message, false);
            }
        }

        /// <summary>The player's day, 'YYYY-MM-DD' (src/dailySpin.js todayKey: the device's own date).</summary>
        public static string Today() => DateTime.Now.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
    }
}
