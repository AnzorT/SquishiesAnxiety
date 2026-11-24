// house-walk-c.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_house_walk_c_js
    {

        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V add_8 = default;
if (_self1.IsNullish) _self1 = GlobalV;
add_8 = Fn((V _self1, int _argc9, V W_15, V _a12, V _a13, V _a14, V[] _rest10) => {
V d_16 = default;
d_16 = Fn((V _self1, int _argc17, V k_23, V P_24, V _a21, V _a22, V[] _rest18) => {
return Invoke(W_15, "def", k_23, P_24);
}, 2, "", true);
Call(d_16, V.Undef, ((V)("mittens")), NewObj(2).Put("g", ((V)("trot"))).Put("x", NewObj(1).Put("wag", Arr(((V)(10D)), ((V)(2D)))).V).V);
Call(d_16, V.Undef, ((V)("biscuit")), NewObj(5).Put("g", ((V)("trot"))).Put("a", ((V)(1.15))).Put("r", ((V)(1.1))).Put("x", NewObj(1).Put("wag", Arr(((V)(24D)), ((V)(2D)))).V).Put("c", NewObj(4).Put("hap", ((V)(0.5))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("tongue", ((V)(0.4))).V).V);
Call(d_16, V.Undef, ((V)("prickle")), NewObj(2).Put("g", ((V)("scurry"))).Put("a", ((V)(1D))).V);
Call(d_16, V.Undef, ((V)("truffle")), NewObj(3).Put("g", ((V)("trot"))).Put("a", ((V)(0.9))).Put("x", NewObj(1).Put("wag", Arr(((V)(16D)), ((V)(2D)))).V).V);
Call(d_16, V.Undef, ((V)("ribbit")), NewObj(2).Put("g", ((V)("hop"))).Put("a", ((V)(1.2))).V);
Call(d_16, V.Undef, ((V)("nibbles")), NewObj(3).Put("g", ((V)("scurry"))).Put("a", ((V)(1.1))).Put("r", ((V)(1.1))).V);
Call(d_16, V.Undef, ((V)("quill")), NewObj(3).Put("g", ((V)("waddle"))).Put("a", ((V)(0.8))).Put("r", ((V)(0.9))).V);
Call(d_16, V.Undef, ((V)("waffles")), NewObj(1).Put("g", ((V)("trot"))).V);
Call(d_16, V.Undef, ((V)("poppy")), NewObj(2).Put("g", ((V)("hop"))).Put("a", ((V)(1D))).V);
Call(d_16, V.Undef, ((V)("duchess")), NewObj(4).Put("g", ((V)("prance"))).Put("a", ((V)(1D))).Put("x", NewObj(1).Put("wag", Arr(((V)(12D)), ((V)(1D)))).V).Put("c", NewObj(1).Put("close", ((V)(0.3))).V).V);
Call(d_16, V.Undef, ((V)("mamapaws")), NewObj(4).Put("g", ((V)("waddle"))).Put("a", ((V)(0.7))).Put("r", ((V)(0.85))).Put("c", NewObj(1).Put("smile", ((V)(0.6))).V).V);
Call(d_16, V.Undef, ((V)("nimbo")), NewObj(2).Put("g", ((V)("float"))).Put("fx", Arr(((V)("drop")), ((V)(240D)))).V);
Call(d_16, V.Undef, ((V)("lumi")), NewObj(3).Put("g", ((V)("float"))).Put("a", ((V)(0.9))).Put("x", NewObj(1).Put("x", Arr(((V)(1.2)), ((V)(1D)))).V).V);
Call(d_16, V.Undef, ((V)("bubbly")), NewObj(2).Put("g", ((V)("float"))).Put("fx", Arr(((V)("bubble")), ((V)(700D)))).V);
Call(d_16, V.Undef, ((V)("twinkle")), NewObj(5).Put("g", ((V)("float"))).Put("a", ((V)(1.1))).Put("sm", ((V)(45D))).Put("x", NewObj(1).Put("glow", Arr(((V)(0.3)), ((V)(2D)), ((V)(0D)), ((V)(1D)))).V).Put("fx", Arr(((V)("spark")), ((V)(520D)))).V);
Call(d_16, V.Undef, ((V)("zappi")), NewObj(4).Put("g", ((V)("scurry"))).Put("r", ((V)(0.85))).Put("x", NewObj(1).Put("zap", Arr(((V)(0.3)), ((V)(4D)), ((V)(0D)), ((V)(1D)))).V).Put("fx", Arr(((V)("spark")), ((V)(420D)))).V);
Call(d_16, V.Undef, ((V)("plip")), NewObj(3).Put("g", ((V)("bounce"))).Put("a", ((V)(0.8))).Put("fx", Arr(((V)("drop")), ((V)(600D)))).V);
Call(d_16, V.Undef, ((V)("breeze")), NewObj(3).Put("g", ((V)("float"))).Put("a", ((V)(1.2))).Put("x", NewObj(1).Put("puff", Arr(((V)(0.15)), ((V)(1D)), ((V)(0D)), ((V)(1D)))).V).V);
Call(d_16, V.Undef, ((V)("dusty")), NewObj(3).Put("g", ((V)("flutter"))).Put("a", ((V)(0.8))).Put("wing", ((V)("own"))).V);
Call(d_16, V.Undef, ((V)("aurora")), NewObj(3).Put("g", ((V)("float"))).Put("r", ((V)(0.85))).Put("x", NewObj(1).Put("wag", Arr(((V)(20D)), ((V)(1D)))).V).V);
Call(d_16, V.Undef, ((V)("mallow")), NewObj(1).Put("g", ((V)("bounce"))).V);
Call(d_16, V.Undef, ((V)("bao")), NewObj(3).Put("g", ((V)("bounce"))).Put("a", ((V)(0.85))).Put("fx", Arr(((V)("steam")), ((V)(900D)))).V);
Call(d_16, V.Undef, ((V)("dunkie")), NewObj(2).Put("g", ((V)("roll"))).Put("sm", ((V)(50D))).V);
Call(d_16, V.Undef, ((V)("frybo")), NewObj(2).Put("g", ((V)("shuffle"))).Put("x", NewObj(1).Put("fw", Arr(((V)(0.4)), ((V)(2D)), ((V)(0D)), ((V)(1D)))).V).V);
Call(d_16, V.Undef, ((V)("bunbun")), NewObj(3).Put("g", ((V)("bounce"))).Put("a", ((V)(0.9))).Put("x", NewObj(1).Put("split", Arr(((V)(0.25)), ((V)(1D)), ((V)(0D)), ((V)(1D)))).V).V);
Call(d_16, V.Undef, ((V)("choco")), NewObj(3).Put("g", ((V)("shuffle"))).Put("a", ((V)(1.1))).Put("sm", ((V)(50D))).V);
Call(d_16, V.Undef, ((V)("scoop")), NewObj(3).Put("g", ((V)("waddle"))).Put("a", ((V)(0.7))).Put("x", NewObj(1).Put("chb", Arr(((V)(0.6)), ((V)(2D)), ((V)(0D)), ((V)(1D)))).V).V);
Call(d_16, V.Undef, ((V)("boba")), NewObj(2).Put("g", ((V)("bounce"))).Put("a", ((V)(0.8))).V);
Call(d_16, V.Undef, ((V)("chefbun")), NewObj(2).Put("g", ((V)("prance"))).Put("a", ((V)(0.8))).V);
Call(d_16, V.Undef, ((V)("pip")), NewObj(2).Put("g", ((V)("waddle"))).Put("a", ((V)(1.2))).V);
Call(d_16, V.Undef, ((V)("jelli")), NewObj(3).Put("g", ((V)("float"))).Put("r", ((V)(1.2))).Put("x", NewObj(1).Put("sq", Arr(((V)(0.06)), ((V)(1D)))).V).V);
Call(d_16, V.Undef, ((V)("finn")), NewObj(1).Put("g", ((V)("galumph"))).V);
Call(d_16, V.Undef, ((V)("sealy")), NewObj(2).Put("g", ((V)("galumph"))).Put("a", ((V)(1.1))).V);
Call(d_16, V.Undef, ((V)("puff")), NewObj(3).Put("g", ((V)("float"))).Put("a", ((V)(0.9))).Put("x", NewObj(2).Put("armL", Arr(((V)(10D)), ((V)(4D)))).Put("armR", Arr(((V)(10D)), ((V)(4D)), ((V)(System.Math.PI)))).V).V);
Call(d_16, V.Undef, ((V)("shelly")), NewObj(3).Put("g", ((V)("plod"))).Put("c", NewObj(1).Put("nk", ((V)(0.3))).V).Put("x", NewObj(1).Put("nk", Arr(((V)(0.15)), ((V)(2D)))).V).V);
Call(d_16, V.Undef, ((V)("seaturtle")), NewObj(3).Put("g", ((V)("plod"))).Put("c", NewObj(1).Put("nk", ((V)(0.25))).V).Put("x", NewObj(1).Put("nk", Arr(((V)(0.12)), ((V)(2D)))).V).V);
Call(d_16, V.Undef, ((V)("octo")), NewObj(2).Put("g", ((V)("crawl"))).Put("c", NewObj(1).Put("ow", ((V)(0.8))).V).V);
Call(d_16, V.Undef, ((V)("marina")), NewObj(4).Put("g", ((V)("galumph"))).Put("a", ((V)(0.8))).Put("x", NewObj(1).Put("tsw", Arr(((V)(0.5)), ((V)(1D)))).V).Put("c", NewObj(1).Put("tun", ((V)(0.5))).V).V);
Call(d_16, V.Undef, ((V)("pearl")), NewObj(2).Put("g", ((V)("galumph"))).Put("x", NewObj(2).Put("hsw", Arr(((V)(0.4)), ((V)(1D)))).Put("fflap", Arr(((V)(0.6)), ((V)(2D)), ((V)(0D)), ((V)(1D)))).V).V);
Call(d_16, V.Undef, ((V)("pina")), NewObj(4).Put("g", ((V)("waddle"))).Put("a", ((V)(0.8))).Put("r", ((V)(0.9))).Put("x", NewObj(1).Put("crw", Arr(((V)(0.3)), ((V)(2D)), ((V)(0D)), ((V)(1D)))).V).V);
Call(d_16, V.Undef, ((V)("avo")), NewObj(3).Put("g", ((V)("waddle"))).Put("a", ((V)(0.9))).Put("x", NewObj(1).Put("prw", Arr(((V)(0.4)), ((V)(1D)), ((V)(0D)), ((V)(1D)))).V).V);
Call(d_16, V.Undef, ((V)("berri")), NewObj(2).Put("g", ((V)("skip"))).Put("x", NewObj(1).Put("stw", Arr(((V)(0.6)), ((V)(2D)), ((V)(0D)), ((V)(1D)))).V).V);
Call(d_16, V.Undef, ((V)("lemmy")), NewObj(2).Put("g", ((V)("roll"))).Put("a", ((V)(0.8))).V);
Call(d_16, V.Undef, ((V)("kiwi")), NewObj(2).Put("g", ((V)("strut"))).Put("x", NewObj(1).Put("fzz", Arr(((V)(0.2)), ((V)(2D)), ((V)(0D)), ((V)(1D)))).V).V);
Call(d_16, V.Undef, ((V)("melo")), NewObj(3).Put("g", ((V)("shuffle"))).Put("sm", ((V)(45D))).Put("x", NewObj(1).Put("sdj", Arr(((V)(0.6)), ((V)(2D)), ((V)(0D)), ((V)(1D)))).V).V);
Call(d_16, V.Undef, ((V)("peachy")), NewObj(3).Put("g", ((V)("skip"))).Put("a", ((V)(0.85))).Put("x", NewObj(1).Put("lfl", Arr(((V)(0.5)), ((V)(2D)), ((V)(0D)), ((V)(1D)))).V).V);
Call(d_16, V.Undef, ((V)("pitaya")), NewObj(4).Put("g", ((V)("stomp"))).Put("a", ((V)(0.8))).Put("x", NewObj(1).Put("wfl", Arr(((V)(0.5)), ((V)(1D)), ((V)(0D)), ((V)(1D)))).V).Put("c", NewObj(1).Put("brf", ((V)(0.2))).V).V);
Call(d_16, V.Undef, ((V)("tutti")), NewObj(5).Put("g", ((V)("flutter"))).Put("a", ((V)(0.8))).Put("wing", ((V)("own"))).Put("c", NewObj(1).Put("wfl", ((V)(1D))).V).Put("fx", Arr(((V)("spark")), ((V)(600D)))).V);
Call(d_16, V.Undef, ((V)("kiko")), NewObj(2).Put("g", ((V)("trot"))).Put("x", NewObj(1).Put("wag", Arr(((V)(12D)), ((V)(2D)))).V).V);
Call(d_16, V.Undef, ((V)("teddy")), NewObj(2).Put("g", ((V)("stomp"))).Put("a", ((V)(0.8))).V);
Call(d_16, V.Undef, ((V)("hoot")), NewObj(3).Put("g", ((V)("waddle"))).Put("sm", ((V)(65D))).Put("x", NewObj(1).Put("wfl", Arr(((V)(0.4)), ((V)(1D)), ((V)(0D)), ((V)(1D)))).V).V);
Call(d_16, V.Undef, ((V)("leo")), NewObj(4).Put("g", ((V)("trot"))).Put("a", ((V)(1.1))).Put("x", NewObj(2).Put("tsw", Arr(((V)(0.5)), ((V)(1D)))).Put("msh", Arr(((V)(0.2)), ((V)(2D)), ((V)(0D)), ((V)(1D)))).V).Put("c", NewObj(1).Put("pitch", ((V)((-0.02)))).V).V);
Call(d_16, V.Undef, ((V)("panko")), NewObj(3).Put("g", ((V)("waddle"))).Put("a", ((V)(1.1))).Put("r", ((V)(0.9))).V);
Call(d_16, V.Undef, ((V)("acorn")), NewObj(4).Put("g", ((V)("hop"))).Put("a", ((V)(0.8))).Put("r", ((V)(1.25))).Put("x", NewObj(2).Put("tsw", Arr(((V)(0.5)), ((V)(1D)))).Put("tfl", Arr(((V)(0.4)), ((V)(1D)), ((V)(0D)), ((V)(1D)))).V).V);
Call(d_16, V.Undef, ((V)("fawn")), NewObj(2).Put("g", ((V)("prance"))).Put("a", ((V)(1.1))).V);
Call(d_16, V.Undef, ((V)("moss")), NewObj(3).Put("g", ((V)("bounce"))).Put("a", ((V)(0.8))).Put("x", NewObj(1).Put("cb", Arr(((V)(0.7)), ((V)(1D)), ((V)(0D)), ((V)(1D)))).V).V);
Call(d_16, V.Undef, ((V)("sprout")), NewObj(3).Put("g", ((V)("skip"))).Put("a", ((V)(0.9))).Put("x", NewObj(2).Put("lfl", Arr(((V)(0.5)), ((V)(2D)), ((V)(0D)), ((V)(1D)))).Put("stw", Arr(((V)(0.5)), ((V)(2D)), ((V)(0D)), ((V)(1D)))).V).V);
Call(d_16, V.Undef, ((V)("hana")), NewObj(3).Put("g", ((V)("hop"))).Put("a", ((V)(1.1))).Put("x", NewObj(1).Put("tw", Arr(((V)(1D)), ((V)(2D)))).V).V);
Call(d_16, V.Undef, ((V)("boo")), NewObj(3).Put("g", ((V)("float"))).Put("x", NewObj(1).Put("flr", Arr(((V)(0.4)), ((V)(1D)), ((V)(0D)), ((V)(1D)))).V).Put("c", NewObj(1).Put("flr", ((V)(0.3))).V).V);
Call(d_16, V.Undef, ((V)("pixie")), NewObj(4).Put("g", ((V)("flutter"))).Put("wing", ((V)("own"))).Put("c", NewObj(1).Put("wfl", ((V)(1D))).V).Put("fx", Arr(((V)("spark")), ((V)(500D)))).V);
Call(d_16, V.Undef, ((V)("floof")), NewObj(4).Put("g", ((V)("stomp"))).Put("a", ((V)(1.1))).Put("x", NewObj(1).Put("fzz", Arr(((V)(0.3)), ((V)(2D)), ((V)(0D)), ((V)(1D)))).V).Put("dust", ((V)("sand"))).V);
Call(d_16, V.Undef, ((V)("unibun")), NewObj(2).Put("g", ((V)("prance"))).Put("fx", Arr(((V)("spark")), ((V)(900D)))).V);
Call(d_16, V.Undef, ((V)("gumdrop")), NewObj(3).Put("g", ((V)("bounce"))).Put("a", ((V)(0.5))).Put("x", NewObj(1).Put("jig", Arr(((V)(0.25)), ((V)(1D)), ((V)(0D)), ((V)(1D)))).V).V);
Call(d_16, V.Undef, ((V)("ember")), NewObj(2).Put("g", ((V)("strut"))).Put("x", NewObj(2).Put("wfl", Arr(((V)(0.5)), ((V)(2D)), ((V)(0D)), ((V)(1D)))).Put("cfl", Arr(((V)(0.3)), ((V)(2D)), ((V)(0D)), ((V)(1D)))).V).V);
Call(d_16, V.Undef, ((V)("drako")), NewObj(4).Put("g", ((V)("stomp"))).Put("a", ((V)(0.9))).Put("x", NewObj(2).Put("tsw", Arr(((V)(0.6)), ((V)(1D)))).Put("wfl", Arr(((V)(0.3)), ((V)(2D)), ((V)(0D)), ((V)(1D)))).V).Put("dust", ((V)("sand"))).V);
Call(d_16, V.Undef, ((V)("jinni")), NewObj(2).Put("g", ((V)("float"))).Put("x", NewObj(1).Put("gwh", Arr(((V)(0.4)), ((V)(1D)))).V).V);
Call(d_16, V.Undef, ((V)("cuppy")), NewObj(2).Put("g", ((V)("bounce"))).Put("a", ((V)(0.8))).V);
Call(d_16, V.Undef, ((V)("chip")), NewObj(3).Put("g", ((V)("roll"))).Put("a", ((V)(0.9))).Put("sm", ((V)(45D))).V);
Call(d_16, V.Undef, ((V)("twisty")), NewObj(3).Put("g", ((V)("shuffle"))).Put("a", ((V)(0.9))).Put("sm", ((V)(45D))).V);
Call(d_16, V.Undef, ((V)("crois")), NewObj(3).Put("g", ((V)("waddle"))).Put("a", ((V)(0.8))).Put("sm", ((V)(55D))).V);
Call(d_16, V.Undef, ((V)("maca")), NewObj(2).Put("g", ((V)("hop"))).Put("a", ((V)(0.7))).V);
Call(d_16, V.Undef, ((V)("puddi")), NewObj(3).Put("g", ((V)("bounce"))).Put("a", ((V)(0.7))).Put("r", ((V)(0.8))).V);
Call(d_16, V.Undef, ((V)("mochi")), NewObj(1).Put("g", ((V)("bounce"))).V);
Call(d_16, V.Undef, ((V)("cakey")), NewObj(2).Put("g", ((V)("shuffle"))).Put("a", ((V)(0.8))).V);
Call(d_16, V.Undef, ((V)("sugarplum")), NewObj(1).Put("g", ((V)("prance"))).V);
Call(d_16, V.Undef, ((V)("gourdy")), NewObj(1).Put("g", ((V)("roll"))).V);
Call(d_16, V.Undef, ((V)("batty")), NewObj(2).Put("g", ((V)("flutter"))).Put("sm", ((V)(60D))).V);
Call(d_16, V.Undef, ((V)("kernel")), NewObj(3).Put("g", ((V)("hop"))).Put("a", ((V)(1.1))).Put("r", ((V)(1.25))).V);
Call(d_16, V.Undef, ((V)("hexie")), NewObj(3).Put("g", ((V)("trot"))).Put("a", ((V)(0.9))).Put("x", NewObj(1).Put("wag", Arr(((V)(12D)), ((V)(2D)))).V).V);
Call(d_16, V.Undef, ((V)("mumbles")), NewObj(1).Put("g", ((V)("zombie"))).V);
Call(d_16, V.Undef, ((V)("hocus")), NewObj(2).Put("g", ((V)("glide"))).Put("fx", Arr(((V)("spark")), ((V)(800D)))).V);
Call(d_16, V.Undef, ((V)("countsquishula")), NewObj(2).Put("g", ((V)("glide"))).Put("c", NewObj(1).Put("pitch", ((V)((-0.03)))).V).V);
return default;
}, 1, "", true);
if (Truthy(Get(G("window"), "HouseWalk"))) {
Call(add_8, V.Undef, Get(G("window"), "HouseWalk"));
} else {
Invoke(Set(G("window"), "HouseWalkC", (Get(G("window"), "HouseWalkC") is var _t25 && Truthy(_t25) ? _t25 : Arr())), "push", add_8);
}
return default;
}, 0, "", false), V.Undef);
        }
    }
}
