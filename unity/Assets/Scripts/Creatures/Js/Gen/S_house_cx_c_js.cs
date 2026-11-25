// house-cx-c.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_house_cx_c_js
    {

        public static void Run()
        {
Set(G("window"), "HouseCreatures", (Get(G("window"), "HouseCreatures") is var _t1 && Truthy(_t1) ? _t1 : Arr()));
Invoke(Get(G("window"), "HouseCreatures"), "push", Fn((V _self2, int _argc3, V H_9, V _a6, V _a7, V _a8, V[] _rest4) => {
V cBuild_10 = default;
V PROF_11 = default;
V GRP_12 = default;
V OF_13 = default;
V KS_14 = default;
V ks_15 = default;
V C_16 = default;
V RUN_17 = default;
if (_self2.IsNullish) _self2 = GlobalV;
if (!(Truthy(Get(H_9, "cBuild")))) {
return default;
}
{ V _t18 = H_9;
if (_t18.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t18));
{ V _t19 = Get(_t18, "cBuild");
cBuild_10 = _t19; }
{ V _t20 = Get(_t18, "PROF");
PROF_11 = _t20; } }
GRP_12 = NewObj(9).Put("pet", Arr(((V)("#e8483c")), ((V)("#45189a")))).Put("sky", Arr(((V)("#5ab4f0")), ((V)("#2e86c8")))).Put("snack", Arr(((V)("#ffb84a")), ((V)("#d95a2a")))).Put("ocean", Arr(((V)("#2ea3dc")), ((V)("#1e6aa8")))).Put("fruit", Arr(((V)("#7cc35a")), ((V)("#4f8f3a")))).Put("forest", Arr(((V)("#b07a42")), ((V)("#5a7a2a")))).Put("dream", Arr(((V)("#b98ae8")), ((V)("#7a3df0")))).Put("bakery", Arr(((V)("#ff8a4a")), ((V)("#c96a2a")))).Put("spooky", Arr(((V)("#ff8a2a")), ((V)("#5a2a8a")))).V;
OF_13 = NewObj(0).V;
Invoke(Arr(Arr(((V)("pet")), ((V)("mittens biscuit prickle nibbles quill poppy duchess mamapaws truffle ribbit shelly"))), Arr(((V)("sky")), ((V)("nimbo lumi bubbly twinkle zappi plip breeze dusty aurora"))), Arr(((V)("snack")), ((V)("mallow bao dunkie frybo bunbun choco scoop boba chefbun"))), Arr(((V)("ocean")), ((V)("pip jelli finn sealy puff seaturtle octo marina pearl"))), Arr(((V)("fruit")), ((V)("pina avo berri lemmy kiwi melo peachy pitaya tutti"))), Arr(((V)("forest")), ((V)("kiko teddy hoot leo panko acorn fawn moss sprout"))), Arr(((V)("dream")), ((V)("hana boo pixie floof unibun gumdrop ember drako jinni"))), Arr(((V)("bakery")), ((V)("cuppy chip twisty crois maca puddi mochi cakey sugarplum"))), Arr(((V)("spooky")), ((V)("gourdy batty kernel hexie mumbles hocus countsquishula")))), "forEach", Fn((V _arrowThis32, int _argc21, V _a23, V _a24, V _a25, V _a26, V[] _rest22) => {
V g_29 = default;
V s_31 = default;
{ V _t27 = ListOf(_a23);
{ V _t28 = GetIdx(_t27, 0D);
g_29 = _t28; }
{ V _t30 = GetIdx(_t27, 1D);
s_31 = _t30; }
}
return Invoke(Invoke(s_31, "split", ((V)(" "))), "forEach", Fn((V _arrowThis40, int _argc33, V k_39, V _a36, V _a37, V _a38, V[] _rest34) => {
return SetK(OF_13, k_39, g_29);
}, 1, "", true));
}, 1, "", true));
KS_14 = NewObj(4).Put("head", ((V)("nimbo lumi bubbly twinkle plip breeze zappi dusty jelli boo pixie jinni batty hocus"))).Put("tail", ((V)("finn sealy pearl marina aurora"))).Put("flip", ((V)("pip octo puff seaturtle"))).Put("body", ((V)("dunkie chip twisty mochi puddi maca cakey kernel gourdy melo choco"))).V;
ks_15 = NewObj(0).V;
Invoke(Object_keys(KS_14), "forEach", Fn((V _arrowThis48, int _argc41, V s_47, V _a44, V _a45, V _a46, V[] _rest42) => {
return Invoke(Invoke(GetK(KS_14, s_47), "split", ((V)(" "))), "forEach", Fn((V _arrowThis56, int _argc49, V k_55, V _a52, V _a53, V _a54, V[] _rest50) => {
return SetK(ks_15, k_55, s_47);
}, 1, "", true));
}, 1, "", true));
C_16 = NewObj(12).Put("mittens", NewObj(1).Put("fc2", ((V)("#ffcc3a"))).V).Put("biscuit", NewObj(1).Put("fc2", ((V)("#e8483c"))).V).Put("mamapaws", NewObj(1).Put("fc2", ((V)("#5ab4f0"))).V).Put("poppy", NewObj(1).Put("fc2", ((V)("#ff8a4a"))).V).Put("zappi", NewObj(1).Put("fc2", ((V)("#ffd24a"))).V).Put("lumi", NewObj(1).Put("fc2", ((V)("#ffd24a"))).V).Put("frybo", NewObj(1).Put("pc", ((V)("#e8483c"))).V).Put("scoop", NewObj(1).Put("mc", ((V)("#ff8fa8"))).V).Put("chefbun", NewObj(1).Put("mc", ((V)("#ffffff"))).V).Put("sugarplum", NewObj(1).Put("mc", ((V)("#ffd24a"))).V).Put("jinni", NewObj(2).Put("mc", ((V)("#ffd24a"))).Put("hc", ((V)("#ffd24a"))).V).Put("countsquishula", NewObj(2).Put("mc", ((V)("#7a1e2a"))).Put("hc", ((V)("#c0392b"))).V).V;
RUN_17 = NewObj(31).Put("biscuit", NewObj(2).Put("wag", ((V)(22D))).Put("tongue", ((V)(0.5))).V).Put("mamapaws", NewObj(2).Put("wag", ((V)(18D))).Put("tongue", ((V)(0.4))).V).Put("mittens", NewObj(1).Put("curl", ((V)(0.3))).V).Put("poppy", NewObj(2).Put("earL", ((V)((-8D)))).Put("earR", ((V)(8D))).V).Put("leo", NewObj(2).Put("tsw", ((V)(0.6))).Put("mfl", ((V)(0.4))).V).Put("acorn", NewObj(1).Put("tfl", ((V)(0.5))).V).Put("kiko", NewObj(1).Put("tfl", ((V)(0.4))).V).Put("drako", NewObj(2).Put("wfl", ((V)(0.6))).Put("tsw", ((V)(0.4))).V).Put("pixie", NewObj(1).Put("wfl", ((V)(1D))).V).Put("ember", NewObj(2).Put("cfl", ((V)(0.5))).Put("wfl", ((V)(0.6))).V).Put("hoot", NewObj(2).Put("wfl", ((V)(0.6))).Put("tfl", ((V)(0.4))).V).Put("pitaya", NewObj(1).Put("wfl", ((V)(0.6))).V).Put("tutti", NewObj(1).Put("wfl", ((V)(0.8))).V).Put("unibun", NewObj(2).Put("earL", ((V)(6D))).Put("earR", ((V)((-6D)))).V).Put("floof", NewObj(1).Put("fzz", ((V)(0.6))).V).Put("kiwi", NewObj(1).Put("fzz", ((V)(0.6))).V).Put("berri", NewObj(1).Put("stw", ((V)(0.6))).V).Put("frybo", NewObj(1).Put("fw", ((V)(0.5))).V).Put("jelli", NewObj(1).Put("sq", ((V)((-0.05)))).V).Put("pearl", NewObj(1).Put("hsw", ((V)(0.5))).V).Put("jinni", NewObj(1).Put("gwh", ((V)(0.5))).V).Put("boo", NewObj(1).Put("flr", ((V)(0.6))).V).Put("hana", NewObj(2).Put("flL", ((V)(0.3))).Put("flR", ((V)(0.3))).V).Put("nimbo", NewObj(1).Put("puff", ((V)(0.3))).V).Put("zappi", NewObj(1).Put("zap", ((V)(0.6))).V).Put("dusty", NewObj(1).Put("wfl", ((V)(0.8))).V).Put("batty", NewObj(2).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V).Put("marina", NewObj(1).Put("tsw", ((V)(0.5))).V).Put("finn", NewObj(1).Put("wag", ((V)(16D))).V).Put("sealy", NewObj(1).Put("wag", ((V)(14D))).V).Put("aurora", NewObj(1).Put("glow", ((V)(0.4))).V).V;
Set(G("window"), "HouseWalkRUN", Object_assign((Get(G("window"), "HouseWalkRUN") is var _t57 && Truthy(_t57) ? _t57 : NewObj(0).V), RUN_17));
Invoke(Object_keys(PROF_11), "forEach", Fn((V _arrowThis65, int _argc58, V k_64, V _a61, V _a62, V _a63, V[] _rest59) => {
V g_66 = default;
g_66 = (GetK(GRP_12, GetK(OF_13, k_64)) is var _t67 && Truthy(_t67) ? _t67 : Get(GRP_12, "pet"));
Call(cBuild_10, V.Undef, k_64, Object_assign(NewObj(4).Put("ks", (GetK(ks_15, k_64) is var _t68 && Truthy(_t68) ? _t68 : ((V)("foot")))).Put("pc", GetIdx(g_66, 0D)).Put("hc", GetIdx(g_66, 0D)).Put("mc", ((V)("#3b3b4a"))).V, (GetK(C_16, k_64) is var _t69 && Truthy(_t69) ? _t69 : NewObj(0).V)));
return default;
}, 1, "", true));
return default;
}, 1, "", false));
        }
    }
}
