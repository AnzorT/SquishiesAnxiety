// emu: the house's save in Firestore (users/{uid}/crib/house6 = { data, t }) through UserData.LoadHouse / SaveHouse,
// against the Firebase Local Emulator Suite (tools/unity/backend/start-emulators.sh). Every request goes through
// LocalOnly, which refuses anything but 127.0.0.1 / localhost: this can never reach the live project.
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using SquishSquad.Backend;
using SquishSquad.House;

static class Emu
{
    sealed class LocalOnly : IHttp
    {
        readonly IHttp inner = new HttpClientHttp(TimeSpan.FromSeconds(30));
        public Task<HttpResult> Send(HttpRequest r, CancellationToken cancel = default)
        {
            var u = new Uri(r.Url);
            if (!(u.Host == "127.0.0.1" || u.Host == "localhost") || u.Scheme != "http") throw new InvalidOperationException("refusing a non-emulator request: " + r.Url);
            return inner.Send(r, cancel);
        }
    }
    static int pass, fail;
    static void Check(bool ok, string what) { if (ok) pass++; else fail++; Console.WriteLine($"  {(ok ? "ok  " : "FAIL")} {what}"); }

    public static async Task<int> Run()
    {
        SynchronizationContext.SetSynchronizationContext(null);
        var host = Environment.GetEnvironmentVariable("EMULATOR_HOST") ?? "127.0.0.1";
        var fb = new FirebaseClient(FirebaseConfig.Emulator("demo-squish", host), new MemoryAuthStore(), new LocalOnly());
        await fb.Auth.Start();
        var email = "unity-house-" + DateTime.UtcNow.Ticks.ToString("x") + "@example.com";
        var user = await fb.Auth.RegisterWithEmail(email, "secret12");
        var uid = user.Uid; var data = fb.Data;
        Check(await data.LoadHouse(uid) == null, "a new player has no house (loadHouse: null)");
        await data.SaveHouse(uid, "");
        Check(await data.LoadHouse(uid) == null, "an empty save isn't written");
        // a fixture's house as the C# loads it, saved, read back, loaded again: the same house
        var d = Program.Data(); var hs = Program.LoadFixture(d, "decorated"); var json = hs.ToJsonKeepingUnknown();
        await data.SaveHouse(uid, json);
        var back = await data.LoadHouse(uid);
        Check(back == json, $"saved and read back byte for byte ({json.Length} chars)");
        var doc = (await fb.Firestore.Get("users/" + uid + "/crib/house6"))?.Data;
        Check(doc != null && doc.ContainsKey("t") && doc["t"] != null && !(doc["t"] is string), "t is the server's timestamp: " + (doc != null && doc.ContainsKey("t") ? doc["t"]?.GetType().Name : "none"));
        var hs2 = new HouseSave(d); var meta = (JObj)HouseJson.Parse(File.ReadAllText(Path.Combine(Program.Cap, "decorated", "meta.json")));
        var owned = new System.Collections.Generic.List<int>(); foreach (var o in meta.Arr("owned")) owned.Add((int)(double)o);
        hs2.Load(back, (int)meta.Num("level"), owned, "living");
        Check(hs2.ToJson() == hs.ToJson(), "loaded again from Firestore: the same house");
        // a newer design's key survives the round trip (ToJsonKeepingUnknown)
        var pre = (JObj)HouseJson.Parse(File.ReadAllText(Path.Combine(Program.Cap, "premigration", "meta.json")));
        var hs3 = new HouseSave(d); hs3.Load(pre.Str("input"), 11, owned, "living");
        var kept = hs3.ToJsonKeepingUnknown();
        Check(kept.Contains("\"futureKey\":{\"keep\":[1,2,3]}") && !hs3.ToJson().Contains("futureKey"), "an unknown key (futureKey) is kept by ToJsonKeepingUnknown, dropped by the page-exact ToJson");
        Console.WriteLine($"emu: {pass} ok, {fail} failed");
        return fail;
    }
}
