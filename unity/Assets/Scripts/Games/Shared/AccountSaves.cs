// Points the four puzzle games' save hooks (StackSave, SortSave, HopSave, SdSave) at the player's account
// (Backend/GameSaves.cs), or clears them offline. The menu calls Use when it opens a game, with the signed-in player
// whose profile it copied into the game (MenuScreen.SeedGameProfiles), so a game only ever saves an outcome worked out
// from that account's own record.
using SquishSquad.Backend;
using SquishSquad.Games.Hop;
using SquishSquad.Games.Sort;
using SquishSquad.Games.Squishdoku;
using SquishSquad.Games.Stack;

namespace SquishSquad.Games.Shared
{
    public static class AccountSaves
    {
        /// <summary>Signed in (`uid` and `data`): the games save to users/{uid}; null: offline, nothing is sent.</summary>
        public static void Use(string uid, UserData data)
        {
            GameSaves.Use(uid, data);
            bool on = GameSaves.SignedIn;
            StackSave.To = on ? (u, c, x, p, l) => GameSaves.Save("stack", u, c, x, p, l) : null;
            SortSave.To = on ? (u, c, x, p, l) => GameSaves.Save("sort", u, c, x, p, l) : null;
            HopSave.To = on ? (u, c, x, p, l) => GameSaves.Save("hop", u, c, x, p, l) : null;
            SdSave.To = on ? (u, c, x, p, l) => GameSaves.Save("squishdoku", u, c, x, p, l) : null;
            SdSave.BlitzSave = on ? GameSaves.BlitzSave : (System.Func<int, System.Threading.Tasks.Task<string>>)null;
        }
    }
}
