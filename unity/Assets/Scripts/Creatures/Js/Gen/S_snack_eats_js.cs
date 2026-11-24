// snack-eats.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_snack_eats_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("y$", "");
        public static void Run()
        {
Call(Named(boot_27 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V R_8 = default;
V hand_9 = default;
V both_10 = default;
V o_11 = default;
V NOHANDS_12 = default;
V jump_13 = default;
V swing_14 = default;
V jelly_15 = default;
V EAR_16 = default;
V sniffF_17 = default;
V lipLick_18 = default;
V hearts_19 = default;
V para_20 = default;
V pat_21 = default;
V buildAll_22 = default;
V REACT_23 = default;
V hop_24 = default;
V kiss_25 = default;
V CARDS_26 = default;
if (_self1.IsNullish) _self1 = GlobalV;
R_8 = Get(G("window"), "RiveRig");
if ((((!(Truthy(R_8)) || !(Truthy(Get(R_8, "EATKIT")))) || !(Truthy(Get(R_8, "SNACKLIB")))) || !(Truthy(Get(R_8, "EATLIB"))))) {
Call(G("setTimeout"), V.Undef, boot_27.v, ((V)(25D)));
return default;
}
if (Truthy(Get(R_8, "snackEatV"))) {
return default;
}
Set(R_8, "snackEatV", ((V)(1D)));
{ V _t28 = Get(R_8, "PETLIB");
if (_t28.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t28));
{ V _t29 = Get(_t28, "hand");
hand_9 = _t29; }
{ V _t30 = Get(_t28, "both");
both_10 = _t30; }
{ V _t31 = Get(_t28, "o");
o_11 = _t31; }
{ V _t32 = Get(_t28, "NOHANDS");
NOHANDS_12 = _t32; }
{ V _t33 = Get(_t28, "jump");
jump_13 = _t33; }
{ V _t34 = Get(_t28, "swing");
swing_14 = _t34; }
{ V _t35 = Get(_t28, "jelly");
jelly_15 = _t35; } }
{ V _t36 = Get(R_8, "EATKIT");
if (_t36.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t36));
{ V _t37 = Get(_t36, "EAR");
EAR_16 = _t37; }
{ V _t38 = Get(_t36, "sniffF");
sniffF_17 = _t38; }
{ V _t39 = Get(_t36, "lipLick");
lipLick_18 = _t39; }
{ V _t40 = Get(_t36, "hearts");
hearts_19 = _t40; }
{ V _t41 = Get(_t36, "para");
para_20 = _t41; }
{ V _t42 = Get(_t36, "pat");
pat_21 = _t42; }
{ V _t43 = Get(_t36, "buildAll");
buildAll_22 = _t43; } }
{ V _t44 = Get(R_8, "EATLIB");
if (_t44.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t44));
{ V _t45 = Get(_t44, "REACT");
REACT_23 = _t45; } }
Object_assign(EAR_16, NewObj(9).Put("mallow", ((V)(0.6))).Put("bao", ((V)(0.6))).Put("dunkie", ((V)(0.6))).Put("frybo", ((V)(1D))).Put("bunbun", ((V)(0.6))).Put("choco", ((V)(0.6))).Put("scoop", ((V)(0.6))).Put("boba", ((V)(1D))).Put("chefbun", ((V)(1D))).V);
hop_24 = Fn((V _self1, int _argc46, V t_52, V h_53, V ev_54, V _a51, V[] _rest47) => {
return Call(jump_13, V.Undef, t_52, NewObj(6).Put("h", (h_53 is var _t55 && Truthy(_t55) ? _t55 : ((V)(6D)))).Put("ant", ((V)(140D))).Put("up", ((V)(190D))).Put("c", ((V)(0.14))).Put("arm", ((V)(40D))).Put("ev", ev_54).V);
}, 3, "", true);
kiss_25 = Fn((V _self1, int _argc56, V t_62, V _a59, V _a60, V _a61, V[] _rest57) => {
return Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_62, "to", ((V)(260D)), Call(o_11, V.Undef, Call(hand_9, V.Undef, ((V)(1D)), ((V)(13D)), ((V)((-15D)))), NewObj(2).Put("armR", ((V)(20D))).Put("close", ((V)(0.9))).V), ((V)("io"))), "to", ((V)(130D)), NewObj(3).Put("open", ((V)(0.3))).Put("mw", ((V)(0.5))).Put("puff", ((V)((-0.2)))).V, ((V)("o"))), "to", ((V)(220D)), Call(o_11, V.Undef, Call(hand_9, V.Undef, ((V)(1D)), ((V)((-4D))), ((V)((-10D)))), NewObj(4).Put("armR", ((V)(80D))).Put("open", ((V)(0.25))).Put("mw", ((V)(1D))).Put("puff", ((V)(0D))).V), ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("pawR")), ((V)(3D))), "wait", ((V)(250D))), "to", ((V)(300D)), Call(o_11, V.Undef, Call(hand_9, V.Undef, ((V)(1D)), ((V)(0D)), ((V)(0D))), NewObj(3).Put("armR", ((V)(0D))).Put("close", ((V)(0D))).Put("open", ((V)(0D))).V), ((V)("io")));
}, 1, "", true);
CARDS_26 = NewObj(9).Put("mallow", NewObj(11).Put("savor", ((V)(0.7))).Put("chewMs", ((V)(145D))).Put("chewN", ((V)(1D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.6))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Slow soft bites, savours it with eyes shut, then sinks into a happy wobble."))).Put("pre", Fn((V _self1, int _argc63, V t_69, V _a66, V _a67, V _a68, V[] _rest64) => {
return Call(sniffF_17, V.Undef, t_69, ((V)(1D)));
}, 1, "pre", true)).Put("post", Fn((V _self1, int _argc70, V t_76, V _a73, V _a74, V _a75, V[] _rest71) => {
return Invoke(Invoke(Invoke(t_76, "to", ((V)(300D)), NewObj(2).Put("close", ((V)(0.6))).Put("smile", ((V)(0.8))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(250D)), NewObj(1).Put("close", ((V)(0D))).V, ((V)("io")));
}, 1, "post", true)).Put("yum", Fn((V _self1, int _argc77, V t_83, V _a80, V _a81, V _a82, V[] _rest78) => {
Invoke(Invoke(t_83, "to", ((V)(500D)), NewObj(3).Put("sq", ((V)(0.16))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(900D)), NewObj(1).Put("sq", ((V)((-0.03)))).V, ((V)("o")));
Call(jelly_15, V.Undef, t_83, ((V)(0.06)), ((V)(2D)), ((V)(300D)));
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1, int _argc84, V t_90, V _a87, V _a88, V _a89, V[] _rest85) => {
Call(hearts_19, V.Undef, t_90, ((V)(2D)));
Invoke(t_90, "to", ((V)(300D)), NewObj(1).Put("blush", ((V)(1D))).V, ((V)("io")));
Invoke(Get(CARDS_26, "mallow"), "yum", t_90);
return default;
}, 1, "love", true)).V).Put("bao", NewObj(8).Put("chewMs", ((V)(135D))).Put("crumbs", ((V)(1D))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Blows on it to cool it first (a puff of steam), neat bites, steam puffs out of his knot when he is happy."))).Put("pre", Fn((V _self1, int _argc91, V t_97, V _a94, V _a95, V _a96, V[] _rest92) => {
Invoke(Invoke(Invoke(Invoke(t_97, "to", ((V)(250D)), NewObj(3).Put("puff", ((V)(0.6))).Put("pitch", ((V)((-0.08)))).Put("ly", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(3).Put("puff", ((V)((-0.3)))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.5))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("steam")), ((V)("mouth")), ((V)(2D))), "to", ((V)(260D)), NewObj(4).Put("puff", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "pre", true)).Put("post", Fn((V _self1, int _argc98, V t_104, V _a101, V _a102, V _a103, V[] _rest99) => {
return Call(lipLick_18, V.Undef, t_104);
}, 1, "post", true)).Put("yum", Fn((V _self1, int _argc105, V t_111, V _a108, V _a109, V _a110, V[] _rest106) => {
Invoke(t_111, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(hop_24, V.Undef, t_111, ((V)(6D)), Arr(Arr(((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(4D)))));
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1, int _argc112, V t_118, V _a115, V _a116, V _a117, V[] _rest113) => {
Call(hearts_19, V.Undef, t_118, ((V)(2D)));
Invoke(t_118, "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(3D)));
Invoke(Get(CARDS_26, "bao"), "yum", t_118);
return default;
}, 1, "love", true)).V).Put("dunkie", NewObj(8).Put("crumbs", ((V)(2D))).Put("open", ((V)(0.8))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Dunks it first, like a donut in coffee, then happy chomps; rocks like a rolling wheel when he likes it."))).Put("pre", Fn((V _self1, int _argc119, V t_125, V H_126, V _a123, V _a124, V[] _rest120) => {
V L_127 = default;
L_127 = Call(o_11, V.Undef, Get(H_126, "chest"));
{
foreach (V _k128 in ForInKeys(L_127)) {
V q_129 = default;
q_129 = _k128;
if (Truthy(Invoke(NewRegExp(RX0, "y$", ""), "test", q_129))) {
OpSetK(L_127, q_129, 0, ((V)(7D)));
}
}
}
Invoke(Invoke(Invoke(Invoke(Invoke(t_125, "to", ((V)(320D)), Call(o_11, V.Undef, L_127, NewObj(3).Put("pitch", ((V)((-0.22)))).Put("ly", ((V)(0.9))).Put("sq", ((V)(0.04))).V), ((V)("io"))), "to", ((V)(120D)), NewObj(1).Put("sq", ((V)(0.08))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("drop")), Arr(((V)(50D)), ((V)(82D))), ((V)(2D))), "to", ((V)(160D)), NewObj(1).Put("sq", ((V)(0.03))).V, ((V)("io"))), "to", ((V)(320D)), Call(o_11, V.Undef, Get(H_126, "chest"), NewObj(3).Put("pitch", ((V)((-0.05)))).Put("ly", ((V)(0.4))).Put("sq", ((V)(0D))).V), ((V)("io")));
return default;
}, 2, "pre", true)).Put("post", Fn((V _self1, int _argc130, V t_136, V _a133, V _a134, V _a135, V[] _rest131) => {
return Call(lipLick_18, V.Undef, t_136, (true ? V.True : V.False));
}, 1, "post", true)).Put("yum", Fn((V _self1, int _argc137, V t_143, V _a140, V _a141, V _a142, V[] _rest138) => {
Invoke(Invoke(t_143, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("sprinkle")), ((V)("head")), ((V)(4D)));
Call(swing_14, V.Undef, t_143, ((V)(1100D)), ((V)(3D)), NewObj(2).Put("tilt", ((V)(10D))).Put("x", ((V)(2.5))).V);
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1, int _argc144, V t_150, V _a147, V _a148, V _a149, V[] _rest145) => {
Call(hearts_19, V.Undef, t_150, ((V)(2D)));
Invoke(Get(CARDS_26, "dunkie"), "yum", t_150);
return default;
}, 1, "love", true)).V).Put("frybo", NewObj(9).Put("chewMs", ((V)(110D))).Put("chewN", ((V)(0.9))).Put("crumbs", ((V)(2D))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Salts it first, quick crunchy bites, his fries wave when he is happy."))).Put("pre", Fn((V _self1, int _argc151, V t_157, V _a154, V _a155, V _a156, V[] _rest152) => {
Invoke(Invoke(Invoke(Invoke(t_157, "to", ((V)(200D)), NewObj(2).Put("pitch", ((V)((-0.1)))).Put("ly", ((V)(0.7))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(2).Put("earL", ((V)((-8D)))).Put("earR", ((V)((-8D)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("salt")), ((V)("head")), ((V)(4D))), "to", ((V)(220D)), NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
Call(sniffF_17, V.Undef, t_157, ((V)(1D)));
return default;
}, 1, "pre", true)).Put("post", Fn((V _self1, int _argc158, V t_164, V _a161, V _a162, V _a163, V[] _rest159) => {
return Call(lipLick_18, V.Undef, t_164);
}, 1, "post", true)).Put("yum", Fn((V _self1, int _argc165, V t_171, V _a168, V _a169, V _a170, V[] _rest166) => {
Invoke(Invoke(Invoke(t_171, "to", ((V)(160D)), NewObj(4).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("earL", ((V)((-10D)))).Put("earR", ((V)((-10D)))).V, ((V)("io"))), "to", ((V)(700D)), NewObj(1).Put("fw", ((V)(1.3))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(3).Put("fw", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1, int _argc172, V t_178, V _a175, V _a176, V _a177, V[] _rest173) => {
Call(hearts_19, V.Undef, t_178, ((V)(2D)));
Invoke(Get(CARDS_26, "frybo"), "yum", t_178);
return default;
}, 1, "love", true)).V).Put("bunbun", NewObj(9).Put("open", ((V)(0.95))).Put("crumbs", ((V)(3D))).Put("puff", ((V)(1.15))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Opens wide (his layers lift apart), big chomps, crumbs everywhere, a cheesy squeak when he likes it."))).Put("pre", Fn((V _self1, int _argc179, V t_185, V _a182, V _a183, V _a184, V[] _rest180) => {
return Invoke(Invoke(Invoke(t_185, "to", ((V)(220D)), NewObj(3).Put("split", ((V)(0.45))).Put("open", ((V)(0.5))).Put("wide", ((V)(0.3))).V, ((V)("o"))), "wait", ((V)(160D))), "to", ((V)(220D)), NewObj(3).Put("split", ((V)(0D))).Put("open", ((V)(0D))).Put("wide", ((V)(0D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _self1, int _argc186, V t_192, V _a189, V _a190, V _a191, V[] _rest187) => {
return Call(pat_21, V.Undef, t_192, ((V)(2D)));
}, 1, "post", true)).Put("yum", Fn((V _self1, int _argc193, V t_199, V _a196, V _a197, V _a198, V[] _rest194) => {
Invoke(Invoke(Invoke(Invoke(t_199, "to", ((V)(140D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("note")), ((V)("head")), ((V)(1D))), "to", ((V)(160D)), NewObj(1).Put("split", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).Put("split", ((V)(0D))).V, ((V)("io")));
Call(swing_14, V.Undef, t_199, ((V)(900D)), ((V)(3D)), NewObj(2).Put("fan", ((V)(0.5))).Put("tilt", ((V)(3D))).V);
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1, int _argc200, V t_206, V _a203, V _a204, V _a205, V[] _rest201) => {
Call(hearts_19, V.Undef, t_206, ((V)(2D)));
Invoke(Get(CARDS_26, "bunbun"), "yum", t_206);
return default;
}, 1, "love", true)).V).Put("choco", NewObj(9).Put("open", ((V)(0.5))).Put("savor", ((V)(0.6))).Put("chewMs", ((V)(140D))).Put("crumbs", ((V)(1D))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Neat little snapping bites, savours it, melts a little with happiness, then firms up."))).Put("post", Fn((V _self1, int _argc207, V t_213, V _a210, V _a211, V _a212, V[] _rest208) => {
return Invoke(Invoke(t_213, "to", ((V)(80D)), NewObj(1).Put("tw", ((V)(1D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("tw", ((V)(0D))).V, ((V)("io")));
}, 1, "post", true)).Put("yum", Fn((V _self1, int _argc214, V t_220, V _a217, V _a218, V _a219, V[] _rest215) => {
Invoke(Invoke(Invoke(Invoke(t_220, "to", ((V)(700D)), NewObj(5).Put("melt", ((V)(0.5))).Put("sq", ((V)(0.06))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("close", ((V)(0.5))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(140D)), NewObj(4).Put("melt", ((V)(0D))).Put("sq", ((V)((-0.04)))).Put("tw", ((V)(1D))).Put("close", ((V)(0D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(2).Put("sq", ((V)(0D))).Put("tw", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1, int _argc221, V t_227, V _a224, V _a225, V _a226, V[] _rest222) => {
Call(hearts_19, V.Undef, t_227, ((V)(2D)));
Invoke(t_227, "to", ((V)(250D)), NewObj(1).Put("blush", ((V)(1D))).V, ((V)("io")));
Invoke(Get(CARDS_26, "choco"), "yum", t_227);
return default;
}, 1, "love", true)).V).Put("scoop", NewObj(8).Put("open", ((V)(0.55))).Put("chewMs", ((V)(130D))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("A little lick first, small bites, his cherry bobs and pops when he likes it."))).Put("pre", Fn((V _self1, int _argc228, V t_234, V _a231, V _a232, V _a233, V[] _rest229) => {
return Invoke(Invoke(Invoke(t_234, "to", ((V)(200D)), NewObj(2).Put("pitch", ((V)((-0.08)))).Put("ly", ((V)(0.7))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(2).Put("tongue", ((V)(0.9))).Put("open", ((V)(0.2))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(3).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _self1, int _argc235, V t_241, V _a238, V _a239, V _a240, V[] _rest236) => {
return Call(lipLick_18, V.Undef, t_241);
}, 1, "post", true)).Put("yum", Fn((V _self1, int _argc242, V t_248, V _a245, V _a246, V _a247, V[] _rest243) => {
Invoke(Invoke(Invoke(Invoke(t_248, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "osc", ((V)(900D)), ((V)(3D)), NewObj(2).Put("chb", ((V)(1D))).Put("htilt", ((V)(3D))).V, NewObj(2).Put("chb", ((V)(0D))).Put("htilt", ((V)((-3D)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(2).Put("chy", ((V)(0.8))).Put("htilt", ((V)(0D))).V, ((V)("o"))), "to", ((V)(280D)), NewObj(1).Put("chy", ((V)(0D))).V, ((V)("i")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1, int _argc249, V t_255, V _a252, V _a253, V _a254, V[] _rest250) => {
Call(hearts_19, V.Undef, t_255, ((V)(2D)));
Invoke(Get(CARDS_26, "scoop"), "yum", t_255);
return default;
}, 1, "love", true)).V).Put("boba", NewObj(8).Put("chewMs", ((V)(125D))).Put("crumbs", ((V)(1D))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Gulps it down with his pearls swirling as he chews, then happy bubbles."))).Put("pre", Fn((V _self1, int _argc256, V t_262, V _a259, V _a260, V _a261, V[] _rest257) => {
return Invoke(Invoke(t_262, "to", ((V)(250D)), NewObj(3).Put("pitch", ((V)((-0.08)))).Put("ly", ((V)(0.7))).Put("swirl", ((V)(1D))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(2).Put("swirl", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _self1, int _argc263, V t_269, V _a266, V _a267, V _a268, V[] _rest264) => {
return Invoke(Invoke(Invoke(t_269, "to", ((V)(300D)), NewObj(2).Put("swirl", ((V)(1.5))).Put("pop", ((V)(0.8))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("bubble")), ((V)("mouth")), ((V)(2D))), "to", ((V)(400D)), NewObj(2).Put("swirl", ((V)(0D))).Put("pop", ((V)(0D))).V, ((V)("io")));
}, 1, "post", true)).Put("yum", Fn((V _self1, int _argc270, V t_276, V _a273, V _a274, V _a275, V[] _rest271) => {
Invoke(t_276, "to", ((V)(150D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(hop_24, V.Undef, t_276, ((V)(6D)));
Invoke(Invoke(t_276, "to", ((V)(160D)), NewObj(2).Put("stw", ((V)(1.5))).Put("pop", ((V)(1.5))).V, ((V)("o"))), "to", ((V)(500D)), NewObj(2).Put("stw", ((V)(0D))).Put("pop", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1, int _argc277, V t_283, V _a280, V _a281, V _a282, V[] _rest278) => {
Call(hearts_19, V.Undef, t_283, ((V)(2D)));
Invoke(Get(CARDS_26, "boba"), "yum", t_283);
return default;
}, 1, "love", true)).V).Put("chefbun", NewObj(9).Put("open", ((V)(0.6))).Put("chewMs", ((V)(145D))).Put("savor", ((V)(0.5))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Sniffs it like a food critic, a careful taste, thinks about it, then eats; a chef's kiss after."))).Put("pre", Fn((V _self1, int _argc284, V t_290, V _a287, V _a288, V _a289, V[] _rest285) => {
Call(sniffF_17, V.Undef, t_290, ((V)(2D)));
Invoke(Invoke(Invoke(t_290, "to", ((V)(350D)), NewObj(3).Put("close", ((V)(0.85))).Put("htilt", ((V)(6D))).Put("pitch", ((V)(0.08))).V, ((V)("io"))), "wait", ((V)(350D))), "to", ((V)(250D)), NewObj(3).Put("close", ((V)(0D))).Put("htilt", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "pre", true)).Put("post", Fn((V _self1, int _argc291, V t_297, V _a294, V _a295, V _a296, V[] _rest292) => {
return Call(kiss_25, V.Undef, t_297);
}, 1, "post", true)).Put("yum", Fn((V _self1, int _argc298, V t_304, V _a301, V _a302, V _a303, V[] _rest299) => {
Invoke(t_304, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(hop_24, V.Undef, t_304, ((V)(5D)));
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1, int _argc305, V t_311, V _a308, V _a309, V _a310, V[] _rest306) => {
Call(hearts_19, V.Undef, t_311, ((V)(2D)));
Call(kiss_25, V.Undef, t_311);
Call(hop_24, V.Undef, t_311, ((V)(5D)));
return default;
}, 1, "love", true)).V).V;
Call(buildAll_22, V.Undef, CARDS_26);
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
