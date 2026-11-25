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
hop_24 = Fn((V _arrowThis55, int _argc46, V t_52, V h_53, V ev_54, V _a51, V[] _rest47) => {
return Call(jump_13, V.Undef, t_52, NewObj(6).Put("h", (h_53 is var _t56 && Truthy(_t56) ? _t56 : ((V)(6D)))).Put("ant", ((V)(140D))).Put("up", ((V)(190D))).Put("c", ((V)(0.14))).Put("arm", ((V)(40D))).Put("ev", ev_54).V);
}, 3, "", true);
kiss_25 = Fn((V _arrowThis64, int _argc57, V t_63, V _a60, V _a61, V _a62, V[] _rest58) => {
return Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_63, "to", ((V)(260D)), Call(o_11, V.Undef, Call(hand_9, V.Undef, ((V)(1D)), ((V)(13D)), ((V)((-15D)))), NewObj(2).Put("armR", ((V)(20D))).Put("close", ((V)(0.9))).V), ((V)("io"))), "to", ((V)(130D)), NewObj(3).Put("open", ((V)(0.3))).Put("mw", ((V)(0.5))).Put("puff", ((V)((-0.2)))).V, ((V)("o"))), "to", ((V)(220D)), Call(o_11, V.Undef, Call(hand_9, V.Undef, ((V)(1D)), ((V)((-4D))), ((V)((-10D)))), NewObj(4).Put("armR", ((V)(80D))).Put("open", ((V)(0.25))).Put("mw", ((V)(1D))).Put("puff", ((V)(0D))).V), ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("pawR")), ((V)(3D))), "wait", ((V)(250D))), "to", ((V)(300D)), Call(o_11, V.Undef, Call(hand_9, V.Undef, ((V)(1D)), ((V)(0D)), ((V)(0D))), NewObj(3).Put("armR", ((V)(0D))).Put("close", ((V)(0D))).Put("open", ((V)(0D))).V), ((V)("io")));
}, 1, "", true);
CARDS_26 = NewObj(9).Put("mallow", NewObj(11).Put("savor", ((V)(0.7))).Put("chewMs", ((V)(145D))).Put("chewN", ((V)(1D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.6))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Slow soft bites, savours it with eyes shut, then sinks into a happy wobble."))).Put("pre", Fn((V _arrowThis72, int _argc65, V t_71, V _a68, V _a69, V _a70, V[] _rest66) => {
return Call(sniffF_17, V.Undef, t_71, ((V)(1D)));
}, 1, "pre", true)).Put("post", Fn((V _arrowThis80, int _argc73, V t_79, V _a76, V _a77, V _a78, V[] _rest74) => {
return Invoke(Invoke(Invoke(t_79, "to", ((V)(300D)), NewObj(2).Put("close", ((V)(0.6))).Put("smile", ((V)(0.8))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(250D)), NewObj(1).Put("close", ((V)(0D))).V, ((V)("io")));
}, 1, "post", true)).Put("yum", Fn((V _arrowThis88, int _argc81, V t_87, V _a84, V _a85, V _a86, V[] _rest82) => {
Invoke(Invoke(t_87, "to", ((V)(500D)), NewObj(3).Put("sq", ((V)(0.16))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(900D)), NewObj(1).Put("sq", ((V)((-0.03)))).V, ((V)("o")));
Call(jelly_15, V.Undef, t_87, ((V)(0.06)), ((V)(2D)), ((V)(300D)));
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis96, int _argc89, V t_95, V _a92, V _a93, V _a94, V[] _rest90) => {
Call(hearts_19, V.Undef, t_95, ((V)(2D)));
Invoke(t_95, "to", ((V)(300D)), NewObj(1).Put("blush", ((V)(1D))).V, ((V)("io")));
Invoke(Get(CARDS_26, "mallow"), "yum", t_95);
return default;
}, 1, "love", true)).V).Put("bao", NewObj(8).Put("chewMs", ((V)(135D))).Put("crumbs", ((V)(1D))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Blows on it to cool it first (a puff of steam), neat bites, steam puffs out of his knot when he is happy."))).Put("pre", Fn((V _arrowThis104, int _argc97, V t_103, V _a100, V _a101, V _a102, V[] _rest98) => {
Invoke(Invoke(Invoke(Invoke(t_103, "to", ((V)(250D)), NewObj(3).Put("puff", ((V)(0.6))).Put("pitch", ((V)((-0.08)))).Put("ly", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(3).Put("puff", ((V)((-0.3)))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.5))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("steam")), ((V)("mouth")), ((V)(2D))), "to", ((V)(260D)), NewObj(4).Put("puff", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "pre", true)).Put("post", Fn((V _arrowThis112, int _argc105, V t_111, V _a108, V _a109, V _a110, V[] _rest106) => {
return Call(lipLick_18, V.Undef, t_111);
}, 1, "post", true)).Put("yum", Fn((V _arrowThis120, int _argc113, V t_119, V _a116, V _a117, V _a118, V[] _rest114) => {
Invoke(t_119, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(hop_24, V.Undef, t_119, ((V)(6D)), Arr(Arr(((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(4D)))));
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis128, int _argc121, V t_127, V _a124, V _a125, V _a126, V[] _rest122) => {
Call(hearts_19, V.Undef, t_127, ((V)(2D)));
Invoke(t_127, "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(3D)));
Invoke(Get(CARDS_26, "bao"), "yum", t_127);
return default;
}, 1, "love", true)).V).Put("dunkie", NewObj(8).Put("crumbs", ((V)(2D))).Put("open", ((V)(0.8))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Dunks it first, like a donut in coffee, then happy chomps; rocks like a rolling wheel when he likes it."))).Put("pre", Fn((V _arrowThis137, int _argc129, V t_135, V H_136, V _a133, V _a134, V[] _rest130) => {
V L_138 = default;
L_138 = Call(o_11, V.Undef, Get(H_136, "chest"));
{
foreach (V _k139 in ForInKeys(L_138)) {
V q_140 = default;
q_140 = _k139;
if (Truthy(Invoke(NewRegExp(RX0, "y$", ""), "test", q_140))) {
OpSetK(L_138, q_140, 0, ((V)(7D)));
}
}
}
Invoke(Invoke(Invoke(Invoke(Invoke(t_135, "to", ((V)(320D)), Call(o_11, V.Undef, L_138, NewObj(3).Put("pitch", ((V)((-0.22)))).Put("ly", ((V)(0.9))).Put("sq", ((V)(0.04))).V), ((V)("io"))), "to", ((V)(120D)), NewObj(1).Put("sq", ((V)(0.08))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("drop")), Arr(((V)(50D)), ((V)(82D))), ((V)(2D))), "to", ((V)(160D)), NewObj(1).Put("sq", ((V)(0.03))).V, ((V)("io"))), "to", ((V)(320D)), Call(o_11, V.Undef, Get(H_136, "chest"), NewObj(3).Put("pitch", ((V)((-0.05)))).Put("ly", ((V)(0.4))).Put("sq", ((V)(0D))).V), ((V)("io")));
return default;
}, 2, "pre", true)).Put("post", Fn((V _arrowThis148, int _argc141, V t_147, V _a144, V _a145, V _a146, V[] _rest142) => {
return Call(lipLick_18, V.Undef, t_147, (true ? V.True : V.False));
}, 1, "post", true)).Put("yum", Fn((V _arrowThis156, int _argc149, V t_155, V _a152, V _a153, V _a154, V[] _rest150) => {
Invoke(Invoke(t_155, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("sprinkle")), ((V)("head")), ((V)(4D)));
Call(swing_14, V.Undef, t_155, ((V)(1100D)), ((V)(3D)), NewObj(2).Put("tilt", ((V)(10D))).Put("x", ((V)(2.5))).V);
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis164, int _argc157, V t_163, V _a160, V _a161, V _a162, V[] _rest158) => {
Call(hearts_19, V.Undef, t_163, ((V)(2D)));
Invoke(Get(CARDS_26, "dunkie"), "yum", t_163);
return default;
}, 1, "love", true)).V).Put("frybo", NewObj(9).Put("chewMs", ((V)(110D))).Put("chewN", ((V)(0.9))).Put("crumbs", ((V)(2D))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Salts it first, quick crunchy bites, his fries wave when he is happy."))).Put("pre", Fn((V _arrowThis172, int _argc165, V t_171, V _a168, V _a169, V _a170, V[] _rest166) => {
Invoke(Invoke(Invoke(Invoke(t_171, "to", ((V)(200D)), NewObj(2).Put("pitch", ((V)((-0.1)))).Put("ly", ((V)(0.7))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(2).Put("earL", ((V)((-8D)))).Put("earR", ((V)((-8D)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("salt")), ((V)("head")), ((V)(4D))), "to", ((V)(220D)), NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
Call(sniffF_17, V.Undef, t_171, ((V)(1D)));
return default;
}, 1, "pre", true)).Put("post", Fn((V _arrowThis180, int _argc173, V t_179, V _a176, V _a177, V _a178, V[] _rest174) => {
return Call(lipLick_18, V.Undef, t_179);
}, 1, "post", true)).Put("yum", Fn((V _arrowThis188, int _argc181, V t_187, V _a184, V _a185, V _a186, V[] _rest182) => {
Invoke(Invoke(Invoke(t_187, "to", ((V)(160D)), NewObj(4).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("earL", ((V)((-10D)))).Put("earR", ((V)((-10D)))).V, ((V)("io"))), "to", ((V)(700D)), NewObj(1).Put("fw", ((V)(1.3))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(3).Put("fw", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis196, int _argc189, V t_195, V _a192, V _a193, V _a194, V[] _rest190) => {
Call(hearts_19, V.Undef, t_195, ((V)(2D)));
Invoke(Get(CARDS_26, "frybo"), "yum", t_195);
return default;
}, 1, "love", true)).V).Put("bunbun", NewObj(9).Put("open", ((V)(0.95))).Put("crumbs", ((V)(3D))).Put("puff", ((V)(1.15))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Opens wide (his layers lift apart), big chomps, crumbs everywhere, a cheesy squeak when he likes it."))).Put("pre", Fn((V _arrowThis204, int _argc197, V t_203, V _a200, V _a201, V _a202, V[] _rest198) => {
return Invoke(Invoke(Invoke(t_203, "to", ((V)(220D)), NewObj(3).Put("split", ((V)(0.45))).Put("open", ((V)(0.5))).Put("wide", ((V)(0.3))).V, ((V)("o"))), "wait", ((V)(160D))), "to", ((V)(220D)), NewObj(3).Put("split", ((V)(0D))).Put("open", ((V)(0D))).Put("wide", ((V)(0D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _arrowThis212, int _argc205, V t_211, V _a208, V _a209, V _a210, V[] _rest206) => {
return Call(pat_21, V.Undef, t_211, ((V)(2D)));
}, 1, "post", true)).Put("yum", Fn((V _arrowThis220, int _argc213, V t_219, V _a216, V _a217, V _a218, V[] _rest214) => {
Invoke(Invoke(Invoke(Invoke(t_219, "to", ((V)(140D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("note")), ((V)("head")), ((V)(1D))), "to", ((V)(160D)), NewObj(1).Put("split", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).Put("split", ((V)(0D))).V, ((V)("io")));
Call(swing_14, V.Undef, t_219, ((V)(900D)), ((V)(3D)), NewObj(2).Put("fan", ((V)(0.5))).Put("tilt", ((V)(3D))).V);
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis228, int _argc221, V t_227, V _a224, V _a225, V _a226, V[] _rest222) => {
Call(hearts_19, V.Undef, t_227, ((V)(2D)));
Invoke(Get(CARDS_26, "bunbun"), "yum", t_227);
return default;
}, 1, "love", true)).V).Put("choco", NewObj(9).Put("open", ((V)(0.5))).Put("savor", ((V)(0.6))).Put("chewMs", ((V)(140D))).Put("crumbs", ((V)(1D))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Neat little snapping bites, savours it, melts a little with happiness, then firms up."))).Put("post", Fn((V _arrowThis236, int _argc229, V t_235, V _a232, V _a233, V _a234, V[] _rest230) => {
return Invoke(Invoke(t_235, "to", ((V)(80D)), NewObj(1).Put("tw", ((V)(1D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("tw", ((V)(0D))).V, ((V)("io")));
}, 1, "post", true)).Put("yum", Fn((V _arrowThis244, int _argc237, V t_243, V _a240, V _a241, V _a242, V[] _rest238) => {
Invoke(Invoke(Invoke(Invoke(t_243, "to", ((V)(700D)), NewObj(5).Put("melt", ((V)(0.5))).Put("sq", ((V)(0.06))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("close", ((V)(0.5))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(140D)), NewObj(4).Put("melt", ((V)(0D))).Put("sq", ((V)((-0.04)))).Put("tw", ((V)(1D))).Put("close", ((V)(0D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(2).Put("sq", ((V)(0D))).Put("tw", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis252, int _argc245, V t_251, V _a248, V _a249, V _a250, V[] _rest246) => {
Call(hearts_19, V.Undef, t_251, ((V)(2D)));
Invoke(t_251, "to", ((V)(250D)), NewObj(1).Put("blush", ((V)(1D))).V, ((V)("io")));
Invoke(Get(CARDS_26, "choco"), "yum", t_251);
return default;
}, 1, "love", true)).V).Put("scoop", NewObj(8).Put("open", ((V)(0.55))).Put("chewMs", ((V)(130D))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("A little lick first, small bites, his cherry bobs and pops when he likes it."))).Put("pre", Fn((V _arrowThis260, int _argc253, V t_259, V _a256, V _a257, V _a258, V[] _rest254) => {
return Invoke(Invoke(Invoke(t_259, "to", ((V)(200D)), NewObj(2).Put("pitch", ((V)((-0.08)))).Put("ly", ((V)(0.7))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(2).Put("tongue", ((V)(0.9))).Put("open", ((V)(0.2))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(3).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _arrowThis268, int _argc261, V t_267, V _a264, V _a265, V _a266, V[] _rest262) => {
return Call(lipLick_18, V.Undef, t_267);
}, 1, "post", true)).Put("yum", Fn((V _arrowThis276, int _argc269, V t_275, V _a272, V _a273, V _a274, V[] _rest270) => {
Invoke(Invoke(Invoke(Invoke(t_275, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "osc", ((V)(900D)), ((V)(3D)), NewObj(2).Put("chb", ((V)(1D))).Put("htilt", ((V)(3D))).V, NewObj(2).Put("chb", ((V)(0D))).Put("htilt", ((V)((-3D)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(2).Put("chy", ((V)(0.8))).Put("htilt", ((V)(0D))).V, ((V)("o"))), "to", ((V)(280D)), NewObj(1).Put("chy", ((V)(0D))).V, ((V)("i")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis284, int _argc277, V t_283, V _a280, V _a281, V _a282, V[] _rest278) => {
Call(hearts_19, V.Undef, t_283, ((V)(2D)));
Invoke(Get(CARDS_26, "scoop"), "yum", t_283);
return default;
}, 1, "love", true)).V).Put("boba", NewObj(8).Put("chewMs", ((V)(125D))).Put("crumbs", ((V)(1D))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Gulps it down with his pearls swirling as he chews, then happy bubbles."))).Put("pre", Fn((V _arrowThis292, int _argc285, V t_291, V _a288, V _a289, V _a290, V[] _rest286) => {
return Invoke(Invoke(t_291, "to", ((V)(250D)), NewObj(3).Put("pitch", ((V)((-0.08)))).Put("ly", ((V)(0.7))).Put("swirl", ((V)(1D))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(2).Put("swirl", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _arrowThis300, int _argc293, V t_299, V _a296, V _a297, V _a298, V[] _rest294) => {
return Invoke(Invoke(Invoke(t_299, "to", ((V)(300D)), NewObj(2).Put("swirl", ((V)(1.5))).Put("pop", ((V)(0.8))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("bubble")), ((V)("mouth")), ((V)(2D))), "to", ((V)(400D)), NewObj(2).Put("swirl", ((V)(0D))).Put("pop", ((V)(0D))).V, ((V)("io")));
}, 1, "post", true)).Put("yum", Fn((V _arrowThis308, int _argc301, V t_307, V _a304, V _a305, V _a306, V[] _rest302) => {
Invoke(t_307, "to", ((V)(150D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(hop_24, V.Undef, t_307, ((V)(6D)));
Invoke(Invoke(t_307, "to", ((V)(160D)), NewObj(2).Put("stw", ((V)(1.5))).Put("pop", ((V)(1.5))).V, ((V)("o"))), "to", ((V)(500D)), NewObj(2).Put("stw", ((V)(0D))).Put("pop", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis316, int _argc309, V t_315, V _a312, V _a313, V _a314, V[] _rest310) => {
Call(hearts_19, V.Undef, t_315, ((V)(2D)));
Invoke(Get(CARDS_26, "boba"), "yum", t_315);
return default;
}, 1, "love", true)).V).Put("chefbun", NewObj(9).Put("open", ((V)(0.6))).Put("chewMs", ((V)(145D))).Put("savor", ((V)(0.5))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Sniffs it like a food critic, a careful taste, thinks about it, then eats; a chef's kiss after."))).Put("pre", Fn((V _arrowThis324, int _argc317, V t_323, V _a320, V _a321, V _a322, V[] _rest318) => {
Call(sniffF_17, V.Undef, t_323, ((V)(2D)));
Invoke(Invoke(Invoke(t_323, "to", ((V)(350D)), NewObj(3).Put("close", ((V)(0.85))).Put("htilt", ((V)(6D))).Put("pitch", ((V)(0.08))).V, ((V)("io"))), "wait", ((V)(350D))), "to", ((V)(250D)), NewObj(3).Put("close", ((V)(0D))).Put("htilt", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "pre", true)).Put("post", Fn((V _arrowThis332, int _argc325, V t_331, V _a328, V _a329, V _a330, V[] _rest326) => {
return Call(kiss_25, V.Undef, t_331);
}, 1, "post", true)).Put("yum", Fn((V _arrowThis340, int _argc333, V t_339, V _a336, V _a337, V _a338, V[] _rest334) => {
Invoke(t_339, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(hop_24, V.Undef, t_339, ((V)(5D)));
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis348, int _argc341, V t_347, V _a344, V _a345, V _a346, V[] _rest342) => {
Call(hearts_19, V.Undef, t_347, ((V)(2D)));
Call(kiss_25, V.Undef, t_347);
Call(hop_24, V.Undef, t_347, ((V)(5D)));
return default;
}, 1, "love", true)).V).V;
Call(buildAll_22, V.Undef, CARDS_26);
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
