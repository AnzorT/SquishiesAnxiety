// dotnet run -c Release --project tools/unity/house-test -- <command>
//   save     every fixture's save loaded by the C# port (HouseSave) vs the page's save after load (exact JSON)
//   markup   every fixture x open room x day / night: the C# room's markup (items in order, boxes, scales, z, pictures,
//            the shell's svg) vs the page's DOM
//   emu      house6 load / save (UserData.LoadHouse / SaveHouse) against the Firebase emulators
//            (tools/unity/backend/start-emulators.sh; demo-squish; requests to 127.0.0.1 only)
//   pixels   the same rooms drawn from the C# room (RoomSvg, pictures from Resources/House/pics) by the reference
//            rasteriser vs Chrome's screenshot (creatures and HUD hidden); writes out/<fixture>-<room>-<day|night>-*.png
//   chrome   the stage-2 pieces (camera, doors, drawer, toast) against the page's numbers
//   signframes <dir>  a sign written in Renovate, frame by frame, for a video (Signs.cs)
// The page's answers: node tools/unity/house/fixtures.mjs && node tools/unity/house/export-house.mjs
using System;
using System.IO;
using System.Linq;
using SquishSquad.House;

static partial class Program
{
    public static string PixRoom;
    public static int DiscoK = -1;   // pixels --disco k: the light-up floor at moment k
    public static readonly string Repo = FindRepo();
    public static readonly string Res = Path.Combine(Repo, "unity/Assets/Resources/House");
    public static readonly string Cap = Path.Combine(Repo, "tools/unity/house/captures");

    static string FindRepo() { var d = AppContext.BaseDirectory; while (d != null && !File.Exists(Path.Combine(d, "HOUSE_PORT_PLAN.md"))) d = Path.GetDirectoryName(d); return d ?? Directory.GetCurrentDirectory(); }

    public static HouseData Data() => HouseData.Load(n => { var f = Path.Combine(Res, n + ".json"); return File.Exists(f) ? File.ReadAllText(f) : null; });

    static int Main(string[] args)
    {
        var cmd = args.Length > 0 ? args[0] : "save";
        var only = args.Length > 1 ? args[1] : null;
        switch (cmd)
        {
            case "save": return Save(only);
            case "markup": return Markup(only);
            case "emu": return Emu.Run().GetAwaiter().GetResult();
            case "chrome": return Chrome.Run();
            case "camera": return CameraLayers.Run(args[1], args[2]);
            case "walk": return WalkCheck.Run();
            case "creatures": return CreatureCheck.Run();
            case "acts": return ActCheck.Run();
            case "map": return MapCheck.Run();
            case "layers": return LayerCheck.Run(args[1], args[2]);
            case "compose": return ComposeOnly(args[1], args[2]);
            case "rt": return DebugRt(args[1], args[2]);
            case "roompics": return RoomPics(args[1], args.Length > 2 ? args[2] : "fresh-lv1", args.Skip(3).ToArray());
            case "housepics": return HousePics(args.Length > 1 ? args[1] : Path.Combine(Repo, "tools/unity/house-test/out/pics"));
            case "signframes": return SignFrames(args.Length > 1 ? args[1] : Path.Combine(Repo, "tools/unity/house-test/out/signs"));
            case "pixels": PixRoom = args.Length > 2 && !args[2].StartsWith("--") ? args[2] : null; { int di = Array.IndexOf(args, "--disco"); if (di > 0 && di + 1 < args.Length) DiscoK = int.Parse(args[di + 1]); } return Pixels(only, args.Contains("--keep"));
            default: Console.WriteLine("commands: save | markup | pixels [fixture]"); return 2;
        }
    }

    public static string[] Fixtures(string only) => Directory.GetDirectories(Cap).Select(Path.GetFileName).Where(n => only == null || n == only).OrderBy(n => n).ToArray();

    public static HouseSave LoadFixture(HouseData d, string fx)
    {
        var meta = (JObj)HouseJson.Parse(File.ReadAllText(Path.Combine(Cap, fx, "meta.json")));
        var owned = meta.Arr("owned").Select(o => (int)(double)o).ToList();
        var hs = new HouseSave(d);
        hs.Load(meta["input"] as string, (int)meta.Num("level"), owned, meta.Str("startRoom"));
        return hs;
    }

    static int Save(string only)
    {
        var d = Data(); int bad = 0;
        foreach (var fx in Fixtures(only))
        {
            var want = File.ReadAllText(Path.Combine(Cap, fx, "saved.json"));
            var hs = LoadFixture(d, fx);
            var got = hs.ToJson();
            if (got == want) { Console.WriteLine($"{fx}: identical ({want.Length} chars)"); continue; }
            bad++;
            int i = 0; while (i < got.Length && i < want.Length && got[i] == want[i]) i++;
            Console.WriteLine($"{fx}: DIFFERENT at {i}\n  page: ...{Cut(want, i)}\n  C#:   ...{Cut(got, i)}");
        }
        return bad;
    }
    static string Cut(string s, int i) => s.Substring(Math.Max(0, i - 80), Math.Min(200, s.Length - Math.Max(0, i - 80)));
}
