// The Shop's and the Level Road's writes: the `squad` Cloud Function's moves (src/squad/api.js move: { move, ...args,
// tzOffsetMinutes }), through the Backend client. A move answers its result, or { error: code } for a rule
// ('not_enough_gems', 'deal_used' …): thrown here as a SquadError with that code, as the app's api.js throws it.
//   groupChest { group, size }   rainbowChest { group }   freeChest   adChest   dealChest
//       → { group, size, final, upgraded, id, rar, isNew, copies, need, coins, dupeCoins, reward, setBonus, luck, rainbow }
//   streakClaim → { kind, n | chest, day }    passClaim { i } → { kind, n | chest, i }    swap { i } → { coins }
//   levelClaim { i: level } → { kind, n | chest, lv }    levelClaimAll → { results: [...] }
// Writes go to the live project in the app; tools/unity/shop-test runs them against the Firebase emulators only.
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SquishSquad.Backend;

namespace SquishSquad.Screens
{
    public static class ShopWrites
    {
        public static async Task<IDictionary<string, object>> Squad(FirebaseFunctions functions, string move, IDictionary<string, object> args, DateTime now)
        {
            var data = new Dictionary<string, object>(args ?? new Dictionary<string, object>()) { ["move"] = move, ["tzOffsetMinutes"] = ScreenWrites.TzOffsetMinutes(now) };
            object res;
            try { res = await functions.Call("squad", data); }
            catch (FunctionsException e) { throw new SquadError(e.Message); }
            var m = Prof.Map(res);
            var err = Prof.Get(m, "error");
            if (err != null) throw new SquadError(err as string ?? Prof.Str(Prof.Get(Prof.Map(err), "message")) ?? "error");
            return m ?? new Dictionary<string, object>();
        }
    }
}
