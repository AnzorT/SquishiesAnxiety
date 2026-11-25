// pet-eats.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_pet_eats_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("y$", "");
        public static void Run()
        {
Call(Named(boot_45 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V R_8 = default;
V TL_9 = default;
V S_10 = default;
V hand_11 = default;
V both_12 = default;
V o_13 = default;
V NOHANDS_14 = default;
V jump_15 = default;
V shake_16 = default;
V swing_17 = default;
V jelly_18 = default;
V popcorn_19 = default;
V croak_20 = default;
V CARD_21 = default;
V DESC_22 = default;
V FOODS_23 = default;
V foodProp_24 = default;
V HOLD_25 = default;
V REACT_26 = default;
V EAR_27 = default;
V prims_28 = default;
V STY_29 = default;
V recv_30 = default;
V sniffF_31 = default;
V lipLick_32 = default;
V sour_33 = default;
V freeze_34 = default;
V hearts_35 = default;
V wagF_36 = default;
V para_37 = default;
V pat_38 = default;
V oink_39 = default;
V wheek_40 = default;
V boof_41 = default;
V CARDS_42 = default;
V meal_43 = default;
V buildAll_44 = default;
if (_self1.IsNullish) _self1 = GlobalV;
R_8 = Get(G("window"), "RiveRig");
if ((((!(Truthy(R_8)) || !(Truthy(Get(R_8, "PETLIB")))) || !(Truthy(Get(R_8, "EATLIB")))) || !(Truthy(Get(R_8, "pokeV"))))) {
Call(G("setTimeout"), V.Undef, boot_45.v, ((V)(25D)));
return default;
}
if (Truthy(Get(R_8, "eatV"))) {
return default;
}
Set(R_8, "eatV", ((V)(1D)));
{ V _t46 = Get(R_8, "PETLIB");
if (_t46.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t46));
{ V _t47 = Get(_t46, "TL");
TL_9 = _t47; }
{ V _t48 = Get(_t46, "S");
S_10 = _t48; }
{ V _t49 = Get(_t46, "hand");
hand_11 = _t49; }
{ V _t50 = Get(_t46, "both");
both_12 = _t50; }
{ V _t51 = Get(_t46, "o");
o_13 = _t51; }
{ V _t52 = Get(_t46, "NOHANDS");
NOHANDS_14 = _t52; }
{ V _t53 = Get(_t46, "jump");
jump_15 = _t53; }
{ V _t54 = Get(_t46, "shake");
shake_16 = _t54; }
{ V _t55 = Get(_t46, "swing");
swing_17 = _t55; }
{ V _t56 = Get(_t46, "jelly");
jelly_18 = _t56; }
{ V _t57 = Get(_t46, "popcorn");
popcorn_19 = _t57; }
{ V _t58 = Get(_t46, "croak");
croak_20 = _t58; }
{ V _t59 = Get(_t46, "CARD");
CARD_21 = _t59; }
{ V _t60 = Get(_t46, "DESC");
DESC_22 = _t60; } }
{ V _t61 = Get(R_8, "EATLIB");
if (_t61.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t61));
{ V _t62 = Get(_t61, "FOODS");
FOODS_23 = _t62; }
{ V _t63 = Get(_t61, "foodProp");
foodProp_24 = _t63; }
{ V _t64 = Get(_t61, "HOLD");
HOLD_25 = _t64; }
{ V _t65 = Get(_t61, "REACT");
REACT_26 = _t65; } }
EAR_27 = NewObj(6).Put("biscuit", ((V)(0.45))).Put("mamapaws", ((V)(0.45))).Put("ribbit", ((V)(0D))).Put("quill", ((V)(0.6))).Put("nibbles", ((V)(0.8))).Put("poppy", ((V)(0.8))).V;
prims_28 = Fn((V _arrowThis73, int _argc66, V P_72, V _a69, V _a70, V _a71, V[] _rest67) => {
V E_74 = default;
V cr_75 = default;
double stash_76 = 0;
V C_77 = default;
E_74 = (GetK(EAR_27, Get(P_72, "key")).IsNullish ? ((V)(1D)) : GetK(EAR_27, Get(P_72, "key")));
cr_75 = (Get(P_72, "crumbs") is var _t78 && Truthy(_t78) ? _t78 : ((V)(1D)));
stash_76 = 0D;
C_77 = NewObj(8).Put("toMouth", Fn((V _arrowThis89, int _argc79, V t_85, V H_86, V x_87, V ms_88, V[] _rest80) => {
return Invoke(t_85, "to", ((ms_88 is var _t90 && Truthy(_t90) ? _t90 : Get(P_72, "reach")) is var _t91 && Truthy(_t91) ? _t91 : ((V)(280D))), Call(o_13, V.Undef, Get(H_86, "mouth"), NewObj(5).Put("open", (Get(P_72, "open") is var _t92 && Truthy(_t92) ? _t92 : ((V)(0.7)))).Put("pitch", ((V)((-0.12)))).Put("ly", ((V)(0.5))).Put("wide", ((V)(0.1))).Put("close", ((V)(0D))).V, (x_87 is var _t93 && Truthy(_t93) ? _t93 : NewObj(0).V)), ((V)("io")));
}, 4, "toMouth", true)).Put("snap", Fn((V _arrowThis102, int _argc94, V t_100, V n_101, V _a98, V _a99, V[] _rest95) => {
return Invoke(Invoke(Invoke(t_100, "to", ((V)(85D)), NewObj(5).Put("open", ((V)(0D))).Put("sq", ((V)(0.07))).Put("pitch", ((V)((-0.07)))).Put("earL", ((V)((4D * ToNum(E_74))))).Put("earR", ((V)((4D * ToNum(E_74))))).V, ((V)("o"))), "e", ((V)("bite"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("mouth")), (n_101 is var _t103 && Truthy(_t103) ? _t103 : cr_75));
}, 2, "snap", true)).Put("back", Fn((V _arrowThis113, int _argc104, V t_110, V H_111, V x_112, V _a109, V[] _rest105) => {
return Invoke(t_110, "to", ((V)(260D)), Call(o_13, V.Undef, Get(H_111, "chest"), NewObj(6).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("pitch", ((V)(0.05))).Put("ly", ((V)(0.2))).Put("wide", ((V)(0D))).V, (x_112 is var _t114 && Truthy(_t114) ? _t114 : NewObj(0).V)), ((V)("io")));
}, 3, "back", true)).Put("bite", Fn((V _self115, int _argc116, V t_122, V H_123, V last_124, V i_125, V[] _rest117) => {
V q_126 = default;
if (_self115.IsNullish) _self115 = GlobalV;
q_126 = (_argc116 > 4 ? _rest117[0] : V.Undef);
Invoke(C_77, "toMouth", t_122, H_123, (Truthy(q_126) ? NewObj(1).Put("open", ((V)(0.85))).V : V.Null), (Truthy(q_126) ? ((V)(170D)) : V.Null));
Invoke(C_77, "snap", t_122);
if (Truthy(last_124)) {
Invoke(t_122, "e", ((V)("done")));
}
return Invoke(C_77, "back", t_122, H_123);
return default;
}, 5, "bite", false)).Put("chew", Fn((V _self127, int _argc128, V t_134, V n_135, V big_136, V _a133, V[] _rest129) => {
V h_137 = default;
V pf_138 = default;
if (_self127.IsNullish) _self127 = GlobalV;
n_135 = ((V)(Max(1D, Round((ToNum(n_135) * ToNum((Get(P_72, "chewN") is var _t139 && Truthy(_t139) ? _t139 : ((V)(1D)))))))));
h_137 = (Get(P_72, "chewMs") is var _t140 && Truthy(_t140) ? _t140 : ((V)(135D)));
pf_138 = (Get(P_72, "puff") is var _t141 && Truthy(_t141) ? _t141 : ((V)(1D)));
if (Truthy(Get(P_72, "savor"))) {
Invoke(t_134, "to", ((V)(140D)), NewObj(1).Put("close", Get(P_72, "savor")).V, ((V)("io")));
}
{
double i_142 = 0;
i_142 = 0D;
while (true) {
if (!(Lt(((V)(i_142)), n_135))) break;
Invoke(Invoke(t_134, "to", h_137, NewObj(6).Put("open", ((V)(0.22))).Put("puff", ((V)(Max(stash_76, ((Truthy(big_136) ? 1D : 0.65) * ToNum(pf_138)))))).Put("sq", ((V)(0.025))).Put("mw", ((V)(0.85))).Put("pitch", ((V)((-0.03)))).Put("htilt", ((V)((NumTruthy((i_142 % 2D)) ? 1.5 : (-1.5))))).V, ((V)("io"))), "to", h_137, NewObj(5).Put("open", ((V)(0.02))).Put("puff", ((V)(Max(stash_76, ((Truthy(big_136) ? 0.85 : 0.5) * ToNum(pf_138)))))).Put("sq", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0.02))).V, ((V)("io")));
i_142++;
}
}
return t_134;
return default;
}, 3, "chew", false)).Put("gulp", Fn((V _self144, int _argc145, V t_151, V _a148, V _a149, V _a150, V[] _rest146) => {
if (_self144.IsNullish) _self144 = GlobalV;
if (Truthy(Get(P_72, "stash"))) {
stash_76 = Min(1.15, ToNum(Add(((V)(stash_76)), Get(P_72, "stash"))));
}
return Invoke(Invoke(Invoke(t_151, "to", ((V)(150D)), NewObj(6).Put("puff", ((V)(stash_76))).Put("sq", ((V)(0.06))).Put("pitch", ((V)(0.16))).Put("open", ((V)(0D))).Put("htilt", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("o"))), "e", ((V)("gulp"))), "to", ((V)(220D)), NewObj(2).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "gulp", false)).Put("whole", Fn((V _self152, int _argc153, V t_159, V H_160, V _a157, V _a158, V[] _rest154) => {
if (_self152.IsNullish) _self152 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_159, "to", ((V)(320D)), Call(o_13, V.Undef, Get(H_160, "mouth"), NewObj(4).Put("open", ((V)(1D))).Put("mw", ((V)(1.1))).Put("pitch", ((V)(0.08))).Put("wide", ((V)(0.3))).V), ((V)("io"))), "to", ((V)(110D)), NewObj(4).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("puff", ((V)((1.1 * ToNum((Get(P_72, "puff") is var _t161 && Truthy(_t161) ? _t161 : ((V)(1D)))))))).Put("sq", ((V)(0.08))).V, ((V)("o"))), "e", ((V)("bite"))), "e", ((V)("done"))), "to", ((V)(300D)), Call(o_13, V.Undef, Get(H_160, "chest"), NewObj(3).Put("sq", ((V)(0D))).Put("wide", ((V)(0D))).Put("hap", ((V)(1D))).V), ((V)("io")));
Invoke(C_77, "chew", t_159, ((V)(5D)), (true ? V.True : V.False));
return Invoke(C_77, "gulp", t_159);
return default;
}, 2, "whole", false)).Put("big", Fn((V _self162, int _argc163, V t_169, V H_170, V _a167, V _a168, V[] _rest164) => {
if (_self162.IsNullish) _self162 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_169, "to", ((V)(380D)), Call(o_13, V.Undef, Get(H_170, "mouth"), NewObj(6).Put("open", ((V)(1D))).Put("mw", ((V)(1.45))).Put("pitch", ((V)(0.12))).Put("htilt", ((V)((-6D)))).Put("wide", ((V)(0.5))).Put("sq", ((V)((-0.05)))).V), ((V)("io"))), "wait", ((V)(150D))), "to", ((V)(110D)), NewObj(6).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("sq", ((V)(0.1))).Put("puff", ((V)(1.2))).Put("htilt", ((V)(0D))).Put("wide", ((V)(0D))).V, ((V)("o"))), "e", ((V)("bite"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("mouth")), ((V)(5D))), "to", ((V)(300D)), Call(o_13, V.Undef, Get(H_170, "chest"), NewObj(2).Put("sq", ((V)(0D))).Put("pitch", ((V)(0.04))).V), ((V)("io")));
Invoke(C_77, "chew", t_169, ((V)(6D)), (true ? V.True : V.False));
Invoke(C_77, "gulp", t_169);
Invoke(C_77, "bite", t_169, H_170, (true ? V.True : V.False));
Invoke(C_77, "chew", t_169, ((V)(3D)));
return Invoke(C_77, "gulp", t_169);
return default;
}, 2, "big", false)).V;
Invoke(Arr(((V)("bite")), ((V)("chew")), ((V)("gulp")), ((V)("whole")), ((V)("big")), ((V)("share"))), "forEach", Fn((V _arrowThis178, int _argc171, V k_177, V _a174, V _a175, V _a176, V[] _rest172) => {
if (Truthy(GetK(P_72, k_177))) {
SetK(C_77, k_177, InvokeK(P_72, k_177, C_77, P_72));
}
return default;
}, 1, "", true));
Set(C_77, "end", Fn((V _arrowThis185, int _argc179, V _a181, V _a182, V _a183, V _a184, V[] _rest180) => {
double v_186 = 0;
v_186 = stash_76;
stash_76 = 0D;
return ((V)(v_186));
return default;
}, 0, "", true));
return C_77;
return default;
}, 1, "", true);
STY_29 = NewObj(9).Put("chomp", Fn((V _self187, int _argc188, V t_194, V H_195, V f_196, V C_197, V[] _rest189) => {
if (_self187.IsNullish) _self187 = GlobalV;
{
double i_198 = 0;
i_198 = 0D;
while (true) {
if (!(Lt(((V)(i_198)), Get(f_196, "n")))) break;
V last_200 = default;
last_200 = ((i_198 == (ToNum(Get(f_196, "n")) - 1D)) ? V.True : V.False);
if (Truthy(((Get(C_197, "share") is var _t201 && !Truthy(_t201) ? _t201 : ((i_198 == 1D) ? V.True : V.False)) is var _t202 && !Truthy(_t202) ? _t202 : (!(Truthy(last_200)) ? V.True : V.False)))) {
Invoke(C_197, "share", t_194, H_195);
goto _cont199;
}
Invoke(C_197, "bite", t_194, H_195, last_200, ((V)(i_198)));
Invoke(C_197, "chew", t_194, (Get(f_196, "chew") is var _t203 && Truthy(_t203) ? _t203 : ((V)(3D))));
Invoke(C_197, "gulp", t_194);
_cont199: ;
i_198++;
}
}
return default;
}, 4, "chomp", false)).Put("gobble", Fn((V _self204, int _argc205, V t_211, V H_212, V f_213, V C_214, V[] _rest206) => {
if (_self204.IsNullish) _self204 = GlobalV;
{
double i_215 = 0;
i_215 = 0D;
while (true) {
if (!(Lt(((V)(i_215)), Get(f_213, "n")))) break;
V last_217 = default;
last_217 = ((i_215 == (ToNum(Get(f_213, "n")) - 1D)) ? V.True : V.False);
if (Truthy(((Get(C_214, "share") is var _t218 && !Truthy(_t218) ? _t218 : ((i_215 == 2D) ? V.True : V.False)) is var _t219 && !Truthy(_t219) ? _t219 : (!(Truthy(last_217)) ? V.True : V.False)))) {
Invoke(C_214, "share", t_211, H_212);
goto _cont216;
}
Invoke(C_214, "bite", t_211, H_212, last_217, ((V)(i_215)), (true ? V.True : V.False));
Invoke(C_214, "chew", t_211, ((V)(1D)));
_cont216: ;
i_215++;
}
}
Invoke(C_214, "gulp", t_211);
return default;
}, 4, "gobble", false)).Put("nibble", Fn((V _self220, int _argc221, V t_227, V H_228, V f_229, V C_230, V[] _rest222) => {
if (_self220.IsNullish) _self220 = GlobalV;
Invoke(t_227, "to", ((V)(320D)), Call(o_13, V.Undef, Get(H_228, "mouth"), NewObj(2).Put("pitch", ((V)((-0.08)))).Put("ly", ((V)(0.5))).V), ((V)("io")));
{
double i_231 = 0;
i_231 = 0D;
while (true) {
if (!(Lt(((V)(i_231)), Get(f_229, "n")))) break;
Invoke(Invoke(Invoke(Invoke(t_227, "to", ((V)(85D)), NewObj(3).Put("open", ((V)(0.3))).Put("mw", ((V)(0.6))).Put("sq", ((V)(0.02))).V, ((V)("o"))), "to", ((V)(85D)), NewObj(3).Put("open", ((V)(0D))).Put("sq", ((V)(0D))).Put("puff", ((V)(0.45))).V, ((V)("io"))), "e", ((V)("bite"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("mouth")), ((V)(1D)));
i_231++;
}
}
Invoke(t_227, "e", ((V)("done")));
Invoke(C_230, "back", t_227, H_228, NewObj(2).Put("puff", ((V)(0.55))).Put("mw", ((V)(1D))).V);
Invoke(C_230, "chew", t_227, ((V)(3D)));
Invoke(C_230, "gulp", t_227);
return default;
}, 4, "nibble", false)).Put("typewriter", Fn((V _self233, int _argc234, V t_240, V H_241, V f_242, V C_243, V[] _rest235) => {
V m_244 = default;
if (_self233.IsNullish) _self233 = GlobalV;
m_244 = Get(H_241, "mouth");
{
double row_245 = 0;
row_245 = 0D;
while (true) {
if (!((row_245 < 2D))) break;
Invoke(t_240, "to", ((V)(300D)), Call(o_13, V.Undef, m_244, NewObj(5).Put("hLx", Add(Get(m_244, "hLx"), ((V)(6D)))).Put("hRx", Add(Get(m_244, "hRx"), ((V)(6D)))).Put("pitch", ((V)((-0.08)))).Put("ly", ((V)(0.4))).Put("hyaw", ((V)(0.15))).V), ((V)("io")));
{
double i_247 = 0;
i_247 = 0D;
while (true) {
if (!(Lt(((V)(i_247)), Get(f_242, "n")))) break;
double p_249 = 0;
p_249 = (6D - (((i_247 + 1D) * 12D) / ToNum(Get(f_242, "n"))));
Invoke(Invoke(Invoke(Invoke(t_240, "to", ((V)(110D)), NewObj(4).Put("open", ((V)(0.35))).Put("hLx", Add(Get(m_244, "hLx"), ((V)(p_249)))).Put("hRx", Add(Get(m_244, "hRx"), ((V)(p_249)))).Put("hyaw", ((V)(((-p_249) / 32D)))).V, ((V)("io"))), "to", ((V)(90D)), NewObj(2).Put("open", ((V)(0D))).Put("sq", ((V)(0.03))).V, ((V)("o"))), "e", ((V)("bite"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("mouth")), ((V)(1D)));
i_247++;
}
}
Invoke(Invoke(Invoke(t_240, "to", ((V)(170D)), NewObj(5).Put("hLx", Add(Get(m_244, "hLx"), ((V)(6D)))).Put("hRx", Add(Get(m_244, "hRx"), ((V)(6D)))).Put("hyaw", ((V)(0.2))).Put("sq", ((V)(0D))).Put("wide", ((V)(0.4))).V, ((V)("o"))), "e", ((V)("ding"))), "to", ((V)(120D)), NewObj(1).Put("wide", ((V)(0D))).V);
row_245++;
}
}
Invoke(t_240, "e", ((V)("done")));
Invoke(C_243, "back", t_240, H_241, NewObj(2).Put("hyaw", ((V)(0D))).Put("puff", ((V)(0.7))).V);
Invoke(C_243, "chew", t_240, ((V)(3D)));
if (Truthy(Get(f_242, "seed"))) {
Invoke(Invoke(Invoke(t_240, "to", ((V)(160D)), NewObj(4).Put("puff", ((V)(0.3))).Put("mw", ((V)(0.45))).Put("open", ((V)(0.2))).Put("hyaw", ((V)(0.4))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("seed")), ((V)("mouth"))), "to", ((V)(220D)), NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hyaw", ((V)(0D))).V);
}
Invoke(C_243, "gulp", t_240);
return default;
}, 4, "typewriter", false)).Put("lick", Fn((V _self250, int _argc251, V t_257, V H_258, V f_259, V C_260, V[] _rest252) => {
V L_261 = default;
if (_self250.IsNullish) _self250 = GlobalV;
L_261 = Call(o_13, V.Undef, Get(H_258, "mouth"));
{
foreach (V _k262 in ForInKeys(L_261)) {
V q_263 = default;
q_263 = _k262;
if (Truthy(Invoke(NewRegExp(RX0, "y$", ""), "test", q_263))) {
OpSetK(L_261, q_263, 0, ((V)(3D)));
}
}
}
Invoke(t_257, "to", ((V)(320D)), Call(o_13, V.Undef, L_261, NewObj(2).Put("ly", ((V)(0.5))).Put("pitch", ((V)((-0.05)))).V), ((V)("io")));
{
double i_264 = 0;
i_264 = 0D;
while (true) {
if (!(Lt(((V)(i_264)), Get(f_259, "n")))) break;
Invoke(Invoke(Invoke(t_257, "to", ((V)(170D)), NewObj(6).Put("tongue", ((V)(1D))).Put("pitch", ((V)(0.18))).Put("sq", ((V)((-0.04)))).Put("open", ((V)(0.12))).Put("close", ((V)(0.5))).Put("hyaw", ((V)((Truthy(Get(f_259, "swirl")) ? (NumTruthy((i_264 % 2D)) ? 0.22 : (-0.22)) : 0D)))).V, ((V)("io"))), "e", ((V)("lick"))), "to", ((V)(230D)), NewObj(4).Put("tongue", ((V)(0.15))).Put("pitch", ((V)((-0.05)))).Put("sq", ((V)(0.01))).Put("open", ((V)(0D))).V, ((V)("io")));
i_264++;
}
}
Invoke(t_257, "to", ((V)(200D)), NewObj(5).Put("tongue", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("close", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(0.8))).V, ((V)("io")));
if (Truthy(Get(f_259, "then"))) {
Invoke(C_260, "bite", t_257, H_258, (true ? V.True : V.False));
Invoke(C_260, "chew", t_257, ((V)(3D)));
Invoke(C_260, "gulp", t_257);
} else {
Invoke(Invoke(t_257, "e", ((V)("done"))), "to", ((V)(300D)), Call(o_13, V.Undef, Get(H_258, "chest")), ((V)("io")));
}
return default;
}, 4, "lick", false)).Put("whole", Fn((V _self266, int _argc267, V t_273, V H_274, V f_275, V C_276, V[] _rest268) => {
if (_self266.IsNullish) _self266 = GlobalV;
Invoke(C_276, "whole", t_273, H_274);
return default;
}, 4, "whole", false)).Put("big", Fn((V _self277, int _argc278, V t_284, V H_285, V f_286, V C_287, V[] _rest279) => {
if (_self277.IsNullish) _self277 = GlobalV;
Invoke(C_287, "big", t_284, H_285);
return default;
}, 4, "big", false)).Put("slurp", Fn((V _self288, int _argc289, V t_295, V H_296, V f_297, V C_298, V[] _rest290) => {
if (_self288.IsNullish) _self288 = GlobalV;
{
double i_299 = 0;
i_299 = 0D;
while (true) {
if (!((i_299 < 3D))) break;
V a_301 = default;
Invoke(t_295, "to", ((V)(220D)), NewObj(4).Put("pitch", ((V)((-0.25)))).Put("ly", ((V)(0.6))).Put("mw", ((V)(0.5))).Put("open", ((V)(0.25))).V, ((V)("io")));
a_301 = Get(t_295, "t");
Invoke(t_295, "osc", ((V)(700D)), ((V)(5D)), NewObj(3).Put("sq", ((V)(0.04))).Put("open", ((V)(0.2))).Put("mw", ((V)(0.42))).V, NewObj(3).Put("sq", ((V)((-0.01)))).Put("open", ((V)(0.28))).Put("mw", ((V)(0.5))).V, ((V)("s")));
Invoke(Get(f_297, "wins"), "push", Arr(a_301, Get(t_295, "t")));
Invoke(t_295, "to", ((V)(120D)), NewObj(4).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("puff", ((V)(0.6))).Put("pitch", ((V)(0.05))).V, ((V)("o")));
Invoke(C_298, "chew", t_295, ((V)(2D)));
Invoke(C_298, "gulp", t_295);
i_299++;
}
}
Invoke(t_295, "e", ((V)("done")));
return default;
}, 4, "slurp", false)).Put("sip", Fn((V _self302, int _argc303, V t_309, V H_310, V f_311, V C_312, V[] _rest304) => {
if (_self302.IsNullish) _self302 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_309, "to", ((V)(320D)), Call(o_13, V.Undef, (Get(f_311, "mp") is var _t313 && Truthy(_t313) ? _t313 : Get(H_310, "mouth")), NewObj(1).Put("pitch", ((V)((-0.05)))).V), ((V)("io"))), "to", ((V)(160D)), NewObj(3).Put("mw", ((V)(0.42))).Put("open", ((V)(0.1))).Put("puff", ((V)((-0.4)))).V, ((V)("o"))), "em", ((V)(1800D)), ((V)(450D)), ((V)("bubble")), ((V)("mouth")), ((V)(1D))), "osc", ((V)(1800D)), ((V)(6D)), NewObj(2).Put("puff", ((V)((-0.5)))).Put("sq", ((V)(0.03))).V, NewObj(2).Put("puff", ((V)((-0.3)))).Put("sq", ((V)(0D))).V, ((V)("s"))), "to", ((V)(140D)), NewObj(3).Put("puff", ((V)((-0.6)))).Put("sq", ((V)(0.06))).Put("wide", ((V)(0.4))).V, ((V)("o"))), "e", ((V)("crumple"))), "to", ((V)(260D)), Call(o_13, V.Undef, Get(H_310, "chest"), NewObj(5).Put("mw", ((V)(1D))).Put("open", ((V)(0D))).Put("puff", ((V)(0D))).Put("sq", ((V)(0D))).Put("wide", ((V)(0D))).V), ((V)("io"))), "wait", ((V)(300D))), "e", ((V)("done")));
return default;
}, 4, "sip", false)).V;
recv_30 = Fn((V _arrowThis323, int _argc314, V t_320, V H_321, V P_322, V _a319, V[] _rest315) => {
V E_324 = default;
E_324 = (GetK(EAR_27, Get(P_322, "key")).IsNullish ? ((V)(1D)) : GetK(EAR_27, Get(P_322, "key")));
return Invoke(Invoke(Invoke(Invoke(Invoke(t_320, "e", ((V)("food"))), "to", ((V)(110D)), NewObj(2).Put("ly", ((V)(0.7))).Put("wide", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(300D)), Call(o_13, V.Undef, Get(H_321, "chest"), NewObj(4).Put("pitch", ((V)((-0.18)))).Put("sq", ((V)(0.05))).Put("earL", ((V)(((-6D) * ToNum(E_324))))).Put("earR", ((V)(((-6D) * ToNum(E_324))))).V), ((V)("o"))), "to", ((V)(300D)), NewObj(6).Put("wide", ((V)(0D))).Put("smile", ((V)(0.8))).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("pitch", ((V)((-0.08)))).V, ((V)("io"))), "wait", ((V)(150D)));
return default;
}, 3, "", true);
sniffF_31 = Fn((V _arrowThis333, int _argc325, V t_331, V n_332, V _a329, V _a330, V[] _rest326) => {
return Invoke(Invoke(Invoke(Invoke(t_331, "to", ((V)(200D)), NewObj(2).Put("pitch", ((V)((-0.18)))).Put("ly", ((V)(0.7))).V, ((V)("io"))), "osc", ((V)((ToNum((n_332 is var _t334 && Truthy(_t334) ? _t334 : ((V)(2D)))) * 230D))), (n_332 is var _t335 && Truthy(_t335) ? _t335 : ((V)(2D))), NewObj(3).Put("sq", ((V)(0.03))).Put("pitch", ((V)((-0.13)))).Put("mw", ((V)(0.85))).V, NewObj(3).Put("sq", ((V)(0D))).Put("pitch", ((V)((-0.18)))).Put("mw", ((V)(1D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(3).Put("pitch", ((V)((-0.05)))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("hap", ((V)(0D))).V, ((V)("io")));
}, 2, "", true);
lipLick_32 = Fn((V _arrowThis344, int _argc336, V t_342, V big_343, V _a340, V _a341, V[] _rest337) => {
return Invoke(Invoke(Invoke(t_342, "to", ((V)(140D)), NewObj(4).Put("tongue", ((V)((Truthy(big_343) ? 1D : 0.8)))).Put("open", ((V)((Truthy(big_343) ? 0.3 : 0.15)))).Put("hyaw", ((V)(0.12))).Put("pitch", ((V)((Truthy(big_343) ? 0.08 : 0D)))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(1).Put("hyaw", ((V)((-0.12)))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(4).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 2, "", true);
sour_33 = Fn((V _arrowThis353, int _argc345, V t_351, V P_352, V _a349, V _a350, V[] _rest346) => {
Invoke(Invoke(t_351, "to", ((V)(130D)), NewObj(8).Put("sqz", ((V)(1D))).Put("mw", ((V)(0.4))).Put("open", ((V)(0.15))).Put("sq", ((V)(0.12))).Put("earL", ((V)(14D))).Put("earR", ((V)(14D))).Put("pitch", ((V)((-0.15)))).Put("puff", ((V)((-0.3)))).V, ((V)("o"))), "wait", ((V)(350D)));
Call(shake_16, V.Undef, t_351, NewObj(7).Put("P", ((V)(85D))).Put("env", Arr(((V)(0.5)), ((V)(1D)), ((V)(0.9)), ((V)(0.6)), ((V)(0.3)))).Put("head", ((V)(0.3))).Put("roll", ((V)(4D))).Put("ear", ((V)(10D))).Put("chest", ((V)(0.12))).Put("body", ((V)(0.6))).V);
return Invoke(Invoke(t_351, "to", ((V)(350D)), NewObj(10).Put("sqz", ((V)(0D))).Put("mw", ((V)(1D))).Put("open", ((V)(0D))).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("pitch", ((V)(0D))).Put("puff", ((V)(0D))).Put("smile", ((V)(0.6))).Put("hap", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(250D)));
return default;
}, 2, "", true);
freeze_34 = Fn((V _arrowThis362, int _argc354, V t_360, V P_361, V _a358, V _a359, V[] _rest355) => {
V hy_363 = default;
hy_363 = (Get(P_361, "headY") is var _t364 && Truthy(_t364) ? _t364 : ((V)((-22D))));
Invoke(Invoke(Invoke(t_360, "to", ((V)(150D)), NewObj(3).Put("sqz", ((V)(1D))).Put("sq", ((V)(0.08))).Put("frown", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(300D)), (Truthy(Get(P_361, "armsUp")) ? NewObj(4).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("earL", ((V)(16D))).Put("earR", ((V)(16D))).V : Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)((-1D))), hy_363), NewObj(4).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("earL", ((V)(16D))).Put("earR", ((V)(16D))).V)), ((V)("io"))), "wait", ((V)(300D)));
Call(shake_16, V.Undef, t_360, NewObj(6).Put("P", ((V)(75D))).Put("env", Arr(((V)(0.4)), ((V)(0.8)), ((V)(1D)), ((V)(0.8)), ((V)(0.5)), ((V)(0.25)))).Put("head", ((V)(0.16))).Put("roll", ((V)(3D))).Put("ear", ((V)(8D))).Put("body", ((V)(0.5))).V);
return Invoke(Invoke(t_360, "to", ((V)(400D)), Call(o_13, V.Undef, NOHANDS_14, NewObj(9).Put("sqz", ((V)(0D))).Put("frown", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("sq", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io"))), "wait", ((V)(300D)));
return default;
}, 2, "", true);
hearts_35 = Fn((V _arrowThis373, int _argc365, V t_371, V n_372, V _a369, V _a370, V[] _rest366) => {
return Invoke(t_371, "e", ((V)("emit")), ((V)("heart")), ((V)("head")), (n_372 is var _t374 && Truthy(_t374) ? _t374 : ((V)(2D))));
}, 2, "", true);
wagF_36 = Fn((V _arrowThis384, int _argc375, V t_381, V dur_382, V a_383, V _a380, V[] _rest376) => {
return Call(swing_17, V.Undef, t_381, dur_382, ((V)(Max(3D, Round((ToNum(dur_382) / 160D))))), NewObj(1).Put("wag", (a_383 is var _t385 && Truthy(_t385) ? _t385 : ((V)(30D)))).V);
}, 3, "", true);
para_37 = Fn((V _arrowThis395, int _argc386, V t_392, V from_393, V fn_394, V _a391, V[] _rest387) => {
V e_396 = default;
e_396 = Get(t_392, "t");
Invoke(t_392, "at", from_393);
Call(fn_394, V.Undef, t_392);
return Invoke(t_392, "at", ((V)(Max(ToNum(e_396), ToNum(Get(t_392, "t"))))));
return default;
}, 3, "", true);
pat_38 = Fn((V _arrowThis405, int _argc397, V t_403, V n_404, V _a401, V _a402, V[] _rest398) => {
Invoke(t_403, "to", ((V)(260D)), Call(both_12, V.Undef, ((V)(9D)), ((V)(0D))), ((V)("io")));
{
double i_406 = 0;
i_406 = 0D;
while (true) {
if (!(Lt(((V)(i_406)), (n_404 is var _t408 && Truthy(_t408) ? _t408 : ((V)(3D)))))) break;
Invoke(Invoke(t_403, "to", ((V)(140D)), NewObj(3).Put("hLy", ((V)(2D))).Put("hRy", ((V)((-1D)))).Put("sq", ((V)(0.03))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(3).Put("hLy", ((V)((-1D)))).Put("hRy", ((V)(2D))).Put("sq", ((V)(0D))).V, ((V)("io")));
i_406++;
}
}
return Invoke(t_403, "to", ((V)(260D)), NOHANDS_14, ((V)("io")));
return default;
}, 2, "", true);
oink_39 = Fn((V _arrowThis416, int _argc409, V t_415, V _a412, V _a413, V _a414, V[] _rest410) => {
return Invoke(Invoke(Invoke(t_415, "to", ((V)(120D)), NewObj(3).Put("open", ((V)(0.55))).Put("mw", ((V)(0.8))).Put("pitch", ((V)(0.12))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(200D)), NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 1, "", true);
wheek_40 = Fn((V _arrowThis424, int _argc417, V t_423, V _a420, V _a421, V _a422, V[] _rest418) => {
return Invoke(Invoke(Invoke(Invoke(t_423, "to", ((V)(130D)), NewObj(4).Put("pitch", ((V)(0.2))).Put("open", ((V)(0.65))).Put("mw", ((V)(0.75))).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(220D)), NewObj(2).Put("pitch", ((V)(0.16))).Put("open", ((V)(0.45))).V, ((V)("io"))), "to", ((V)(180D)), NewObj(4).Put("pitch", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("sq", ((V)(0D))).V, ((V)("io")));
}, 1, "", true);
boof_41 = Fn((V _arrowThis432, int _argc425, V t_431, V _a428, V _a429, V _a430, V[] _rest426) => {
return Invoke(Invoke(Invoke(Invoke(t_431, "to", ((V)(110D)), NewObj(4).Put("open", ((V)(0.85))).Put("mw", ((V)(0.85))).Put("sq", ((V)((-0.07)))).Put("pitch", ((V)(0.12))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(200D)), NewObj(4).Put("open", ((V)(0.15))).Put("mw", ((V)(1D))).Put("sq", ((V)(0.03))).Put("pitch", ((V)(0D))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(2).Put("sq", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
}, 1, "", true);
CARDS_42 = NewObj(10).Put("mittens", NewObj(6).Put("savor", ((V)(0.5))).Put("txt", ((V)("Sniffs it first, neat bites, savours it, licks his lips."))).Put("pre", Fn((V _arrowThis440, int _argc433, V t_439, V _a436, V _a437, V _a438, V[] _rest434) => {
return Call(sniffF_31, V.Undef, t_439, ((V)(2D)));
}, 1, "pre", true)).Put("post", Fn((V _arrowThis448, int _argc441, V t_447, V _a444, V _a445, V _a446, V[] _rest442) => {
return Call(lipLick_32, V.Undef, t_447);
}, 1, "post", true)).Put("yum", Fn((V _arrowThis456, int _argc449, V t_455, V _a452, V _a453, V _a454, V[] _rest450) => {
return Invoke(REACT_26, "yum", t_455);
}, 1, "yum", true)).Put("love", Fn((V _arrowThis464, int _argc457, V t_463, V _a460, V _a461, V _a462, V[] _rest458) => {
return Invoke(REACT_26, "love", t_463);
}, 1, "love", true)).V).Put("biscuit", NewObj(9).Put("open", ((V)(0.85))).Put("crumbs", ((V)(3D))).Put("chewN", ((V)(0.6))).Put("chewMs", ((V)(115D))).Put("txt", ((V)("Tail going the whole time, big quick bites, crumbs fly, licks his chops and looks for more."))).Put("recv", Fn((V _arrowThis474, int _argc465, V t_471, V H_472, V P_473, V _a470, V[] _rest466) => {
V a_475 = default;
a_475 = Get(t_471, "t");
Call(recv_30, V.Undef, t_471, H_472, P_473);
Call(para_37, V.Undef, t_471, a_475, Fn((V _arrowThis483, int _argc476, V u_482, V _a479, V _a480, V _a481, V[] _rest477) => {
return Call(wagF_36, V.Undef, u_482, ((V)((ToNum(Get(t_471, "t")) - ToNum(a_475)))), ((V)(30D)));
}, 1, "", true));
return default;
}, 3, "recv", true)).Put("post", Fn((V _arrowThis491, int _argc484, V t_490, V _a487, V _a488, V _a489, V[] _rest485) => {
Call(lipLick_32, V.Undef, t_490, (true ? V.True : V.False));
Invoke(Invoke(Invoke(Invoke(Invoke(t_490, "to", ((V)(110D)), NewObj(1).Put("lx", ((V)((-0.8)))).V, ((V)("o"))), "wait", ((V)(220D))), "to", ((V)(110D)), NewObj(1).Put("lx", ((V)(0.8))).V, ((V)("o"))), "wait", ((V)(220D))), "to", ((V)(110D)), NewObj(1).Put("lx", ((V)(0D))).V, ((V)("o")));
return default;
}, 1, "post", true)).Put("yum", Fn((V _arrowThis499, int _argc492, V t_498, V _a495, V _a496, V _a497, V[] _rest493) => {
V a_500 = default;
Invoke(t_498, "to", ((V)(200D)), NewObj(4).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("tongue", ((V)(0.7))).Put("open", ((V)(0.3))).V, ((V)("io")));
a_500 = Get(t_498, "t");
Call(jump_15, V.Undef, t_498, NewObj(5).Put("h", ((V)(7D))).Put("ant", ((V)(140D))).Put("up", ((V)(200D))).Put("c", ((V)(0.14))).Put("arm", ((V)(30D))).V);
Call(para_37, V.Undef, t_498, a_500, Fn((V _arrowThis508, int _argc501, V u_507, V _a504, V _a505, V _a506, V[] _rest502) => {
return Call(wagF_36, V.Undef, u_507, ((V)((ToNum(Get(t_498, "t")) - ToNum(a_500)))), ((V)(32D)));
}, 1, "", true));
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis517, int _argc509, V t_515, V P_516, V _a513, V _a514, V[] _rest510) => {
Invoke(Get(CARDS_42, "biscuit"), "yum", t_515, P_516);
Call(hearts_35, V.Undef, t_515, ((V)(2D)));
Invoke(t_515, "to", ((V)(300D)), NewObj(1).Put("blush", ((V)(1D))).V, ((V)("io")));
return default;
}, 2, "love", true)).V).Put("truffle", NewObj(8).Put("crumbs", ((V)(4D))).Put("puff", ((V)(1.15))).Put("open", ((V)(0.8))).Put("txt", ((V)("Snorts at it, big messy chomps with crumbs everywhere, oinks, pats his belly."))).Put("pre", Fn((V _arrowThis525, int _argc518, V t_524, V _a521, V _a522, V _a523, V[] _rest519) => {
Invoke(Invoke(t_524, "to", ((V)(80D)), NewObj(3).Put("sq", ((V)(0.06))).Put("pitch", ((V)(0.1))).Put("mw", ((V)(0.75))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(3).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("io")));
Call(sniffF_31, V.Undef, t_524, ((V)(2D)));
return default;
}, 1, "pre", true)).Put("post", Fn((V _arrowThis533, int _argc526, V t_532, V _a529, V _a530, V _a531, V[] _rest527) => {
Call(pat_38, V.Undef, t_532, ((V)(2D)));
return default;
}, 1, "post", true)).Put("yum", Fn((V _arrowThis541, int _argc534, V t_540, V _a537, V _a538, V _a539, V[] _rest535) => {
Call(oink_39, V.Undef, t_540);
Invoke(t_540, "to", ((V)(160D)), NewObj(3).Put("sq", ((V)(0.12))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(jelly_18, V.Undef, t_540, ((V)(0.1)), ((V)(4D)), ((V)(230D)));
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis549, int _argc542, V t_548, V _a545, V _a546, V _a547, V[] _rest543) => {
Call(oink_39, V.Undef, t_548);
Call(hearts_35, V.Undef, t_548, ((V)(2D)));
Invoke(t_548, "to", ((V)(160D)), NewObj(4).Put("sq", ((V)(0.12))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("blush", ((V)(1D))).V, ((V)("io")));
Call(jelly_18, V.Undef, t_548, ((V)(0.1)), ((V)(4D)), ((V)(230D)));
return default;
}, 1, "love", true)).V).Put("nibbles", NewObj(11).Put("chewMs", ((V)(95D))).Put("chewN", ((V)(1.4))).Put("stash", ((V)(0.35))).Put("puff", ((V)(1.1))).Put("open", ((V)(0.45))).Put("headY", ((V)((-16D)))).Put("txt", ((V)("Quick nibbly bites, stuffs his cheeks (they stay puffed), pats them, then swallows."))).Put("pre", Fn((V _arrowThis557, int _argc550, V t_556, V _a553, V _a554, V _a555, V[] _rest551) => {
Invoke(t_556, "osc", ((V)(500D)), ((V)(4D)), NewObj(3).Put("sq", ((V)(0.025))).Put("pitch", ((V)((-0.06)))).Put("mw", ((V)(0.8))).V, NewObj(3).Put("sq", ((V)(0D))).Put("pitch", ((V)((-0.1)))).Put("mw", ((V)(1D))).V, ((V)("o")));
return default;
}, 1, "pre", true)).Put("post", Fn((V _arrowThis567, int _argc558, V t_564, V P_565, V C_566, V _a563, V[] _rest559) => {
V v_568 = default;
v_568 = Invoke(C_566, "end");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_564, "to", ((V)(260D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(1D)), ((V)((-15D)))), NewObj(3).Put("puff", ((V)(Max(0.9, ToNum(v_568))))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io"))), "osc", ((V)(600D)), ((V)(2D)), NewObj(2).Put("hLy", ((V)((-16D)))).Put("hRy", ((V)((-14D)))).V, NewObj(2).Put("hLy", ((V)((-14D)))).Put("hRy", ((V)((-16D)))).V, ((V)("io"))), "to", ((V)(220D)), Call(o_13, V.Undef, NOHANDS_14), ((V)("io"))), "to", ((V)(800D)), NewObj(2).Put("puff", ((V)(0D))).Put("sq", ((V)(0.03))).V, ((V)("io"))), "e", ((V)("gulp"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
return default;
}, 3, "post", true)).Put("yum", Fn((V _arrowThis576, int _argc569, V t_575, V _a572, V _a573, V _a574, V[] _rest570) => {
Invoke(t_575, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
{
double i_577 = 0;
i_577 = 0D;
while (true) {
if (!((i_577 < 3D))) break;
Invoke(Invoke(t_575, "to", ((V)(110D)), NewObj(2).Put("sq", ((V)(0.05))).Put("lift", ((V)(1D))).V, ((V)("o"))), "to", ((V)(130D)), NewObj(2).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io")));
i_577++;
}
}
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis586, int _argc579, V t_585, V _a582, V _a583, V _a584, V[] _rest580) => {
Call(hearts_35, V.Undef, t_585, ((V)(2D)));
Invoke(Get(CARDS_42, "nibbles"), "yum", t_585);
Invoke(t_585, "to", ((V)(200D)), NewObj(1).Put("blush", ((V)(1D))).V, ((V)("io")));
return default;
}, 1, "love", true)).V).Put("quill", NewObj(8).Put("open", ((V)(0.45))).Put("chewMs", ((V)(140D))).Put("chewN", ((V)(0.9))).Put("txt", ((V)("Glances around shyly first, small careful bites, blushes."))).Put("pre", Fn((V _arrowThis594, int _argc587, V t_593, V _a590, V _a591, V _a592, V[] _rest588) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_593, "to", ((V)(300D)), NewObj(3).Put("hyaw", ((V)((-0.25)))).Put("lx", ((V)((-0.6)))).Put("blush", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(400D)), NewObj(2).Put("hyaw", ((V)(0.25))).Put("lx", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(300D)), NewObj(3).Put("hyaw", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0.5))).V, ((V)("io")));
return default;
}, 1, "pre", true)).Put("post", Fn((V _arrowThis602, int _argc595, V t_601, V _a598, V _a599, V _a600, V[] _rest596) => {
return Invoke(Invoke(Invoke(t_601, "to", ((V)(300D)), NewObj(4).Put("blush", ((V)(1D))).Put("smile", ((V)(0.6))).Put("ly", ((V)(0.4))).Put("pitch", ((V)((-0.08)))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(250D)), NewObj(2).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 1, "post", true)).Put("yum", Fn((V _arrowThis610, int _argc603, V t_609, V _a606, V _a607, V _a608, V[] _rest604) => {
Invoke(t_609, "to", ((V)(200D)), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(0.9))).Put("blush", ((V)(0.8))).V, ((V)("io")));
Call(swing_17, V.Undef, t_609, ((V)(1200D)), ((V)(3D)), NewObj(3).Put("x", ((V)(1.6))).Put("bend", ((V)(2.5))).Put("htilt", ((V)((-2D)))).V);
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis618, int _argc611, V t_617, V _a614, V _a615, V _a616, V[] _rest612) => {
Call(hearts_35, V.Undef, t_617, ((V)(1D)));
Invoke(t_617, "to", ((V)(300D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(2D)), ((V)((-18D)))), NewObj(3).Put("hap", ((V)(1D))).Put("blush", ((V)(1D))).Put("smile", ((V)(0.7))).V), ((V)("io")));
Call(swing_17, V.Undef, t_617, ((V)(1200D)), ((V)(3D)), NewObj(2).Put("x", ((V)(1.4))).Put("bend", ((V)(2D))).V);
Invoke(t_617, "to", ((V)(250D)), NOHANDS_14, ((V)("io")));
return default;
}, 1, "love", true)).V).Put("waffles", NewObj(8).Put("open", ((V)(0.9))).Put("crumbs", ((V)(2D))).Put("chewN", ((V)(0.6))).Put("txt", ((V)("Hops with excitement, wolfs it down, licks his nose, butt wiggle."))).Put("pre", Fn((V _arrowThis626, int _argc619, V t_625, V _a622, V _a623, V _a624, V[] _rest620) => {
return Call(jump_15, V.Undef, t_625, NewObj(5).Put("h", ((V)(6D))).Put("ant", ((V)(120D))).Put("up", ((V)(170D))).Put("c", ((V)(0.12))).Put("arm", ((V)(25D))).V);
}, 1, "pre", true)).Put("post", Fn((V _arrowThis634, int _argc627, V t_633, V _a630, V _a631, V _a632, V[] _rest628) => {
return Invoke(Invoke(Invoke(t_633, "to", ((V)(150D)), NewObj(3).Put("tongue", ((V)(1D))).Put("open", ((V)(0.35))).Put("pitch", ((V)(0.12))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("tongue", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(3).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 1, "post", true)).Put("yum", Fn((V _arrowThis642, int _argc635, V t_641, V _a638, V _a639, V _a640, V[] _rest636) => {
Invoke(t_641, "to", ((V)(150D)), NewObj(4).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("tongue", ((V)(0.6))).Put("open", ((V)(0.3))).V, ((V)("io")));
Call(swing_17, V.Undef, t_641, ((V)(1000D)), ((V)(9D)), NewObj(3).Put("tilt", ((V)(5D))).Put("x", ((V)(0.8))).Put("wag", ((V)(38D))).V);
Call(boof_41, V.Undef, t_641);
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis650, int _argc643, V t_649, V _a646, V _a647, V _a648, V[] _rest644) => {
Call(hearts_35, V.Undef, t_649, ((V)(2D)));
Invoke(Get(CARDS_42, "waffles"), "yum", t_649);
return default;
}, 1, "love", true)).V).Put("poppy", NewObj(9).Put("chewMs", ((V)(100D))).Put("chewN", ((V)(1.6))).Put("open", ((V)(0.5))).Put("headY", ((V)((-16D)))).Put("txt", ((V)("Busy munching with a twitching nose, wheeks for joy."))).Put("pre", Fn((V _arrowThis658, int _argc651, V t_657, V _a654, V _a655, V _a656, V[] _rest652) => {
Invoke(t_657, "osc", ((V)(560D)), ((V)(4D)), NewObj(2).Put("sq", ((V)(0.025))).Put("mw", ((V)(0.8))).V, NewObj(2).Put("sq", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("o")));
return default;
}, 1, "pre", true)).Put("post", Fn((V _arrowThis666, int _argc659, V t_665, V _a662, V _a663, V _a664, V[] _rest660) => {
return Call(wheek_40, V.Undef, t_665);
}, 1, "post", true)).Put("yum", Fn((V _arrowThis674, int _argc667, V t_673, V _a670, V _a671, V _a672, V[] _rest668) => {
Call(popcorn_19, V.Undef, t_673, ((V)(10D)), ((V)(1D)), ((V)(500D)));
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis682, int _argc675, V t_681, V _a678, V _a679, V _a680, V[] _rest676) => {
Call(hearts_35, V.Undef, t_681, ((V)(2D)));
Call(popcorn_19, V.Undef, t_681, ((V)(10D)), ((V)(1D)), ((V)(500D)));
Call(popcorn_19, V.Undef, t_681, ((V)(8D)), ((V)((-1D))), ((V)(440D)));
return default;
}, 1, "love", true)).V).Put("duchess", NewObj(10).Put("open", ((V)(0.4))).Put("crumbs", ((V)(0D))).Put("savor", ((V)(0.85))).Put("chewMs", ((V)(145D))).Put("chewN", ((V)(0.85))).Put("txt", ((V)("Inspects it first, tiny dainty bites, savours with her eyes shut, dabs her mouth, chin up."))).Put("pre", Fn((V _arrowThis690, int _argc683, V t_689, V _a686, V _a687, V _a688, V[] _rest684) => {
Invoke(t_689, "to", ((V)(320D)), NewObj(4).Put("htilt", ((V)(8D))).Put("close", ((V)(0.4))).Put("ly", ((V)(0.6))).Put("pitch", ((V)((-0.1)))).V, ((V)("io")));
Call(sniffF_31, V.Undef, t_689, ((V)(1D)));
Invoke(Invoke(t_689, "to", ((V)(240D)), NewObj(3).Put("htilt", ((V)(0D))).Put("close", ((V)(0D))).Put("pitch", ((V)((-0.12)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("pitch", ((V)((-0.04)))).V, ((V)("io")));
return default;
}, 1, "pre", true)).Put("post", Fn((V _arrowThis698, int _argc691, V t_697, V _a694, V _a695, V _a696, V[] _rest692) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_697, "to", ((V)(300D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(13D)), ((V)((-15D)))), NewObj(1).Put("armR", ((V)(18D))).V), ((V)("io"))), "osc", ((V)(500D)), ((V)(2D)), NewObj(1).Put("hRy", ((V)((-13D)))).V, NewObj(1).Put("hRy", ((V)((-16D)))).V, ((V)("io"))), "to", ((V)(300D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(0D)), ((V)(0D))), NewObj(3).Put("armR", ((V)(0D))).Put("pitch", ((V)(0.15))).Put("close", ((V)(0.4))).V), ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(250D)), NewObj(2).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "post", true)).Put("yum", Fn((V _arrowThis706, int _argc699, V t_705, V _a702, V _a703, V _a704, V[] _rest700) => {
Invoke(Invoke(Invoke(Invoke(t_705, "to", ((V)(400D)), NewObj(3).Put("pitch", ((V)(0.15))).Put("close", ((V)(1D))).Put("smile", ((V)(0.9))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(1).Put("close", ((V)(0.35))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis714, int _argc707, V t_713, V _a710, V _a711, V _a712, V[] _rest708) => {
Call(hearts_35, V.Undef, t_713, ((V)(1D)));
Invoke(Get(CARDS_42, "duchess"), "yum", t_713);
return default;
}, 1, "love", true)).V).Put("mamapaws", NewObj(7).Put("chewMs", ((V)(150D))).Put("propZ", ((V)(12.5))).Put("txt", ((V)("Shares with her pup: the pup gets one of the bites, then hearts."))).Put("share", Fn((V _arrowThis723, int _argc715, V C_721, V P_722, V _a719, V _a720, V[] _rest716) => {
return Fn((V _arrowThis732, int _argc724, V t_730, V H_731, V _a728, V _a729, V[] _rest725) => {
V L_733 = default;
L_733 = (SEq(H_731, Get(HOLD_25, "two")) ? Call(both_12, V.Undef, ((V)(7D)), ((V)(10D))) : Call(hand_11, V.Undef, ((V)(1D)), ((V)(8D)), ((V)(10D))));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_730, "to", ((V)(380D)), Call(o_13, V.Undef, L_733, NewObj(3).Put("pitch", ((V)((-0.28)))).Put("ly", ((V)(0.9))).Put("smile", ((V)(1D))).V), ((V)("io"))), "wait", ((V)(120D))), "to", ((V)(110D)), NewObj(1).Put("sq", ((V)(0.03))).V, ((V)("o"))), "e", ((V)("bite"))), "e", ((V)("emit")), ((V)("crumb")), Arr(((V)(50D)), ((V)(70D))), ((V)(2D))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("hap", ((V)(1D))).V, ((V)("io")));
Call(hearts_35, V.Undef, t_730, ((V)(1D)));
Invoke(Invoke(t_730, "wait", ((V)(250D))), "to", ((V)(320D)), Call(o_13, V.Undef, Get(H_731, "chest"), NewObj(3).Put("pitch", ((V)(0D))).Put("ly", ((V)(0.2))).Put("hap", ((V)(0D))).V), ((V)("io")));
return default;
}, 2, "", true);
}, 2, "share", true)).Put("post", Fn((V _arrowThis741, int _argc734, V t_740, V _a737, V _a738, V _a739, V[] _rest735) => {
return Invoke(Invoke(Invoke(t_740, "to", ((V)(350D)), NewObj(3).Put("pitch", ((V)((-0.25)))).Put("ly", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io")));
}, 1, "post", true)).Put("yum", Fn((V _arrowThis749, int _argc742, V t_748, V _a745, V _a746, V _a747, V[] _rest743) => {
Call(hearts_35, V.Undef, t_748, ((V)(1D)));
{
double i_750 = 0;
i_750 = 0D;
while (true) {
if (!((i_750 < 2D))) break;
Invoke(Invoke(Invoke(Invoke(t_748, "to", ((V)(200D)), NewObj(3).Put("sq", ((V)(0.1))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(2).Put("sq", ((V)((-0.05)))).Put("lift", ((V)(2D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0.03))).Put("lift", ((V)(0D))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
i_750++;
}
}
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis759, int _argc752, V t_758, V _a755, V _a756, V _a757, V[] _rest753) => {
Call(hearts_35, V.Undef, t_758, ((V)(2D)));
Invoke(Get(CARDS_42, "mamapaws"), "yum", t_758);
return default;
}, 1, "love", true)).V).Put("ribbit", NewObj(10).Put("txt", ((V)("Eats with his tongue - zap! - and swallows by squeezing his eyes shut, throat puffing."))).Put("pre", Fn((V _arrowThis767, int _argc760, V t_766, V _a763, V _a764, V _a765, V[] _rest761) => {
Invoke(t_766, "to", ((V)(250D)), NewObj(2).Put("ly", ((V)(0.7))).Put("pitch", ((V)((-0.08)))).V, ((V)("io")));
Call(croak_20, V.Undef, t_766, ((V)(1D)), ((V)(380D)));
return default;
}, 1, "pre", true)).Put("bite", Fn((V _arrowThis776, int _argc768, V C_774, V P_775, V _a772, V _a773, V[] _rest769) => {
return Fn((V _arrowThis786, int _argc777, V t_783, V H_784, V last_785, V _a782, V[] _rest778) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_783, "to", ((V)(160D)), Call(o_13, V.Undef, Get(H_784, "chest"), NewObj(3).Put("ly", ((V)(0.7))).Put("pitch", ((V)((-0.08)))).Put("sq", ((V)(0.06))).V), ((V)("io"))), "to", ((V)(70D)), NewObj(3).Put("tongue", ((V)(1D))).Put("open", ((V)(0.6))).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "e", ((V)("bite"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("mouth")), ((V)(1D))), "to", ((V)(110D)), NewObj(3).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("sq", ((V)(0.07))).V, ((V)("io")));
if (Truthy(last_785)) {
Invoke(t_783, "e", ((V)("done")));
}
return t_783;
return default;
}, 3, "", true);
}, 2, "bite", true)).Put("chew", Fn((V _arrowThis795, int _argc787, V C_793, V P_794, V _a791, V _a792, V[] _rest788) => {
return Fn((V _arrowThis804, int _argc796, V t_802, V n_803, V _a800, V _a801, V[] _rest797) => {
return Invoke(Invoke(Invoke(t_802, "to", ((V)(120D)), NewObj(5).Put("close", ((V)(1D))).Put("sqz", ((V)(0.6))).Put("puff", ((V)(0.6))).Put("sq", ((V)(0.06))).Put("pitch", ((V)((-0.05)))).V, ((V)("io"))), "wait", ((V)(Min(450D, (110D * ToNum(n_803)))))), "to", ((V)(160D)), NewObj(5).Put("close", ((V)(0D))).Put("sqz", ((V)(0D))).Put("puff", ((V)(0D))).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 2, "", true);
}, 2, "chew", true)).Put("gulp", Fn((V _arrowThis813, int _argc805, V C_811, V P_812, V _a809, V _a810, V[] _rest806) => {
return Fn((V _arrowThis821, int _argc814, V t_820, V _a817, V _a818, V _a819, V[] _rest815) => {
return Invoke(Invoke(Invoke(t_820, "to", ((V)(100D)), NewObj(1).Put("sq", ((V)(0.04))).V, ((V)("o"))), "e", ((V)("gulp"))), "to", ((V)(140D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
}, 1, "", true);
}, 2, "gulp", true)).Put("whole", Fn((V _arrowThis830, int _argc822, V C_828, V P_829, V _a826, V _a827, V[] _rest823) => {
return Fn((V _arrowThis839, int _argc831, V t_837, V H_838, V _a835, V _a836, V[] _rest832) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_837, "to", ((V)(200D)), Call(o_13, V.Undef, Get(H_838, "chest"), NewObj(2).Put("ly", ((V)(0.7))).Put("sq", ((V)(0.06))).V), ((V)("io"))), "to", ((V)(80D)), NewObj(3).Put("tongue", ((V)(1D))).Put("open", ((V)(0.8))).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "e", ((V)("bite"))), "e", ((V)("done"))), "to", ((V)(130D)), NewObj(4).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("puff", ((V)(1.1))).Put("sq", ((V)(0.08))).V, ((V)("io")));
return Invoke(C_828, "chew", t_837, ((V)(4D)));
return default;
}, 2, "", true);
}, 2, "whole", true)).Put("big", Fn((V _arrowThis848, int _argc840, V C_846, V P_847, V _a844, V _a845, V[] _rest841) => {
return Fn((V _arrowThis857, int _argc849, V t_855, V H_856, V _a853, V _a854, V[] _rest850) => {
Invoke(C_846, "bite", t_855, H_856, (false ? V.True : V.False));
Invoke(C_846, "chew", t_855, ((V)(3D)));
Invoke(C_846, "bite", t_855, H_856, (true ? V.True : V.False));
return Invoke(C_846, "chew", t_855, ((V)(3D)));
return default;
}, 2, "", true);
}, 2, "big", true)).Put("post", Fn((V _arrowThis865, int _argc858, V t_864, V _a861, V _a862, V _a863, V[] _rest859) => {
return Call(croak_20, V.Undef, t_864, ((V)(1D)), ((V)(400D)));
}, 1, "post", true)).Put("yum", Fn((V _arrowThis873, int _argc866, V t_872, V _a869, V _a870, V _a871, V[] _rest867) => {
Invoke(t_872, "to", ((V)(150D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(jump_15, V.Undef, t_872, NewObj(5).Put("h", ((V)(10D))).Put("ant", ((V)(130D))).Put("up", ((V)(210D))).Put("c", ((V)(0.22))).Put("arm", ((V)(45D))).V);
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis881, int _argc874, V t_880, V _a877, V _a878, V _a879, V[] _rest875) => {
Call(hearts_35, V.Undef, t_880, ((V)(2D)));
Invoke(Get(CARDS_42, "ribbit"), "yum", t_880);
return default;
}, 1, "love", true)).V).V;
meal_43 = Fn((V _arrowThis892, int _argc882, V key_888, V food_889, V f0_890, V P_891, V[] _rest883) => {
V f_893 = default;
V H_894 = default;
V t_895 = default;
V C_896 = default;
V r_897 = default;
f_893 = Object_assign(NewObj(0).V, f0_890, NewObj(1).Put("wins", Arr()).V);
H_894 = GetK(HOLD_25, Get(f_893, "hold"));
t_895 = Call(TL_9, V.Undef, NewObj(0).V, ((GetK(CARD_21, key_888) is var _t898 && !Truthy(_t898) ? _t898 : Get(GetK(CARD_21, key_888), "T")) is var _t899 && Truthy(_t899) ? _t899 : ((V)(1D))));
C_896 = Call(prims_28, V.Undef, P_891);
Call((Get(P_891, "recv") is var _t900 && Truthy(_t900) ? _t900 : recv_30), V.Undef, t_895, H_894, P_891);
if (Truthy(Get(P_891, "pre"))) {
Invoke(P_891, "pre", t_895, H_894, P_891, C_896);
}
if (Truthy(Get(f_893, "pre"))) {
Invoke(f_893, "pre", t_895, H_894);
}
InvokeK(STY_29, Get(f_893, "style"), t_895, H_894, f_893, C_896);
if (Truthy(Get(P_891, "post"))) {
Invoke(P_891, "post", t_895, P_891, C_896);
}
r_897 = Get(f_893, "react");
if ((SEqS(r_897, "yum") || SEqS(r_897, "love"))) {
InvokeK(P_891, r_897, t_895, P_891);
} else {
if (SEqS(r_897, "sour")) {
Call(sour_33, V.Undef, t_895, P_891);
} else {
if (SEqS(r_897, "freeze")) {
Call(freeze_34, V.Undef, t_895, P_891);
} else {
InvokeK(REACT_26, r_897, t_895);
}
}
}
Invoke(t_895, "rest", ((V)(450D)));
return Invoke(t_895, "done", Object_assign(NewObj(1).Put("prop", Call(foodProp_24, V.Undef, f_893, food_889)).V, (!Get(P_891, "propZ").IsNullish ? NewObj(1).Put("propZ", Get(P_891, "propZ")).V : NewObj(0).V)));
return default;
}, 4, "", true);
buildAll_44 = Fn((V _arrowThis908, int _argc901, V CARDS_907, V _a904, V _a905, V _a906, V[] _rest902) => {
V ST_909 = default;
ST_909 = NewObj(0).V;
{
foreach (V _k910 in ForInKeys(CARDS_907)) {
V key_911 = default;
key_911 = _k910;
V P_912 = default;
V D_913 = default;
P_912 = Object_assign(NewObj(1).Put("key", key_911).V, GetK(CARDS_907, key_911));
D_913 = SetK(DESC_22, key_911, (GetK(DESC_22, key_911) is var _t914 && Truthy(_t914) ? _t914 : NewObj(0).V));
Invoke(Object_keys(FOODS_23), "forEach", Fn((V _arrowThis922, int _argc915, V food_921, V _a918, V _a919, V _a920, V[] _rest916) => {
V f_923 = default;
f_923 = GetK(FOODS_23, food_921);
SetK(ST_909, ((V)(JsStrBuf.Begin().S("eat_").V(food_921).S("@").V(key_911).End())), Call(meal_43, V.Undef, key_911, food_921, f_923, P_912));
SetK(D_913, ((V)(JsStrBuf.Begin().S("eat_").V(food_921).End())), Arr(Get(f_923, "label"), ((V)(JsStrBuf.Begin().V(Get(P_912, "txt")).S(" ").V(Get(f_923, "d")).End()))));
return default;
}, 1, "", true));
}
}
Invoke(R_8, "add", ST_909);
return default;
}, 1, "", true);
Set(R_8, "EATKIT", NewObj(14).Put("EAR", EAR_27).Put("prims", prims_28).Put("STY", STY_29).Put("recv", recv_30).Put("sniffF", sniffF_31).Put("lipLick", lipLick_32).Put("sour", sour_33).Put("freeze", freeze_34).Put("hearts", hearts_35).Put("wagF", wagF_36).Put("para", para_37).Put("pat", pat_38).Put("meal", meal_43).Put("buildAll", buildAll_44).V);
Call(buildAll_44, V.Undef, CARDS_42);
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
