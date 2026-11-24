// result-states.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_result_states_js
    {

        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V AR_8 = default;
V ER_9 = default;
if (_self1.IsNullish) _self1 = GlobalV;
if (Truthy(Get(G("window"), "__resStates"))) {
return default;
}
Set(G("window"), "__resStates", (true ? V.True : V.False));
AR_8 = Fn((V _self1, int _argc10, V K_16, V _a13, V _a14, V _a15, V[] _rest11) => {
return NewObj(2).Put("armL", K_16).Put("armR", K_16).V;
}, 1, "", true);
ER_9 = Fn((V _self1, int _argc17, V K_23, V _a20, V _a21, V _a22, V[] _rest18) => {
return NewObj(2).Put("earL", K_23).Put("earR", K_23).V;
}, 1, "", true);
Object_assign(Get(Get(G("window"), "RiveRig"), "PRE"), NewObj(4).Put("resSpark", NewObj(8).Put("n", ((V)(8D))).Put("sp", ((V)(36D))).Put("vy", ((V)((-14D)))).Put("g", ((V)(0D))).Put("life", ((V)(780D))).Put("r", Arr(((V)(3.4)), ((V)(5.6)))).Put("col", Arr(((V)("#fff3a0")), ((V)("#ffffff")), ((V)("#ffd23a")), ((V)("#ffd1f5")))).Put("kind", ((V)("star"))).V).Put("resDust", NewObj(8).Put("n", ((V)(7D))).Put("sp", ((V)(26D))).Put("vy", ((V)((-5D)))).Put("g", ((V)(10D))).Put("life", ((V)(620D))).Put("r", Arr(((V)(2D)), ((V)(3.6)))).Put("col", Arr(((V)("#ffffff")), ((V)("#fff6e6")), ((V)("#f6e2c4")))).Put("kind", ((V)("dot"))).V).Put("resHeart", NewObj(7).Put("n", ((V)(1D))).Put("sp", ((V)(9D))).Put("vy", ((V)((-16D)))).Put("g", ((V)((-3D)))).Put("life", ((V)(1300D))).Put("r", Arr(((V)(1.8)), ((V)(2.2)))).Put("kind", ((V)("heart"))).V).Put("resTear", NewObj(8).Put("n", ((V)(1D))).Put("sp", ((V)(0.6))).Put("vy", ((V)(3D))).Put("g", ((V)(18D))).Put("life", ((V)(1100D))).Put("r", Arr(((V)(2.2)), ((V)(2.5)))).Put("col", Arr(((V)("#b9c4cc")))).Put("kind", ((V)("drop"))).V).V);
Invoke(Get(G("window"), "RiveRig"), "add", NewObj(5).Put("resWait", NewObj(3).Put("loop", ((V)(2000D))).Put("blend", ((V)(160D))).Put("k", NewObj(4).Put("smile", Arr(Arr(((V)(0D)), ((V)(0.2))))).Put("pitch", Arr(Arr(((V)(0D)), ((V)(0.12))))).Put("ly", Arr(Arr(((V)(0D)), ((V)((-0.35)))))).Spread(Call(ER_9, V.Undef, Arr(Arr(((V)(0D)), ((V)((-4D))))))).V).V).Put("resWow", NewObj(4).Put("dur", ((V)(700D))).Put("blend", ((V)(70D))).Put("next", ((V)("resHappy"))).Put("k", NewObj(6).Put("wide", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)(1D)), ((V)("o"))), Arr(((V)(520D)), ((V)(1D))), Arr(((V)(700D)), ((V)(0.2)), ((V)("io"))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)(0.8)), ((V)("o"))), Arr(((V)(520D)), ((V)(0.7))), Arr(((V)(700D)), ((V)(0.5)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0.3))), Arr(((V)(160D)), ((V)(1D)), ((V)("o"))))).Put("hap", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(450D)), ((V)(0D))), Arr(((V)(700D)), ((V)(1D)), ((V)("io"))))).Put("blush", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)(0.7)), ((V)("io"))))).Spread(Call(ER_9, V.Undef, Arr(Arr(((V)(0D)), ((V)((-4D)))), Arr(((V)(120D)), ((V)(16D)), ((V)("o"))), Arr(((V)(700D)), ((V)(10D)), ((V)("io")))))).V).V).Put("resHappy", NewObj(3).Put("loop", ((V)(1800D))).Put("blend", ((V)(160D))).Put("k", NewObj(6).Put("hap", Arr(Arr(((V)(0D)), ((V)(1D))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(1D))))).Put("blush", Arr(Arr(((V)(0D)), ((V)(0.6))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0.35))), Arr(((V)(450D)), ((V)(0.6)), ((V)("io"))), Arr(((V)(900D)), ((V)(0.35)), ((V)("io"))), Arr(((V)(1350D)), ((V)(0.6)), ((V)("io"))), Arr(((V)(1800D)), ((V)(0.35)), ((V)("io"))))).Put("wag", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)(16D)), ((V)("io"))), Arr(((V)(600D)), ((V)((-16D))), ((V)("io"))), Arr(((V)(900D)), ((V)(16D)), ((V)("io"))), Arr(((V)(1200D)), ((V)((-16D))), ((V)("io"))), Arr(((V)(1500D)), ((V)(12D)), ((V)("io"))), Arr(((V)(1800D)), ((V)(0D)), ((V)("io"))))).Spread(Call(ER_9, V.Undef, Arr(Arr(((V)(0D)), ((V)(10D))), Arr(((V)(900D)), ((V)(14D)), ((V)("io"))), Arr(((V)(1800D)), ((V)(10D)), ((V)("io")))))).V).V).Put("resMiss", NewObj(4).Put("dur", ((V)(760D))).Put("blend", ((V)(120D))).Put("next", ((V)("resSad"))).Put("k", NewObj(9).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(260D)), ((V)((-0.1))), ((V)("o"))), Arr(((V)(520D)), ((V)(0.18)), ((V)("io"))), Arr(((V)(760D)), ((V)(0.1)), ((V)("io"))))).Put("pitch", Arr(Arr(((V)(0D)), ((V)(0.1))), Arr(((V)(600D)), ((V)((-0.45))), ((V)("io"))))).Put("ly", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(500D)), ((V)(0.45)), ((V)("io"))))).Put("frown", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(300D)), ((V)(0.8)), ((V)("io"))))).Put("teary", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(600D)), ((V)(0.5)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))))).Put("close", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(260D)), ((V)(0.4)), ((V)("io"))), Arr(((V)(520D)), ((V)(0.2)), ((V)("io"))))).Spread(Call(ER_9, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(600D)), ((V)((-14D))), ((V)("io")))))).Spread(Call(AR_8, V.Undef, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(600D)), ((V)((-12D))), ((V)("io")))))).V).V).Put("resSad", NewObj(4).Put("loop", ((V)(2600D))).Put("blend", ((V)(220D))).Put("noBlink", (true ? V.True : V.False)).Put("k", NewObj(8).Put("sq", Arr(Arr(((V)(0D)), ((V)(0.1))))).Put("pitch", Arr(Arr(((V)(0D)), ((V)((-0.45)))))).Put("ly", Arr(Arr(((V)(0D)), ((V)(0.45))))).Put("frown", Arr(Arr(((V)(0D)), ((V)(0.8))))).Put("teary", Arr(Arr(((V)(0D)), ((V)(0.5))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))))).Spread(Call(ER_9, V.Undef, Arr(Arr(((V)(0D)), ((V)((-14D))))))).Spread(Call(AR_8, V.Undef, Arr(Arr(((V)(0D)), ((V)((-12D))))))).V).V).V);
return default;
}, 0, "", false), V.Undef);
        }
    }
}
