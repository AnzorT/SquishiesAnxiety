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
prims_28 = Fn((V _self1, int _argc66, V P_72, V _a69, V _a70, V _a71, V[] _rest67) => {
V E_73 = default;
V cr_74 = default;
double stash_75 = 0;
V C_76 = default;
E_73 = (GetK(EAR_27, Get(P_72, "key")).IsNullish ? ((V)(1D)) : GetK(EAR_27, Get(P_72, "key")));
cr_74 = (Get(P_72, "crumbs") is var _t77 && Truthy(_t77) ? _t77 : ((V)(1D)));
stash_75 = 0D;
C_76 = NewObj(8).Put("toMouth", Fn((V _self1, int _argc78, V t_84, V H_85, V x_86, V ms_87, V[] _rest79) => {
return Invoke(t_84, "to", ((ms_87 is var _t88 && Truthy(_t88) ? _t88 : Get(P_72, "reach")) is var _t89 && Truthy(_t89) ? _t89 : ((V)(280D))), Call(o_13, V.Undef, Get(H_85, "mouth"), NewObj(5).Put("open", (Get(P_72, "open") is var _t90 && Truthy(_t90) ? _t90 : ((V)(0.7)))).Put("pitch", ((V)((-0.12)))).Put("ly", ((V)(0.5))).Put("wide", ((V)(0.1))).Put("close", ((V)(0D))).V, (x_86 is var _t91 && Truthy(_t91) ? _t91 : NewObj(0).V)), ((V)("io")));
}, 4, "toMouth", true)).Put("snap", Fn((V _self1, int _argc92, V t_98, V n_99, V _a96, V _a97, V[] _rest93) => {
return Invoke(Invoke(Invoke(t_98, "to", ((V)(85D)), NewObj(5).Put("open", ((V)(0D))).Put("sq", ((V)(0.07))).Put("pitch", ((V)((-0.07)))).Put("earL", ((V)((4D * ToNum(E_73))))).Put("earR", ((V)((4D * ToNum(E_73))))).V, ((V)("o"))), "e", ((V)("bite"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("mouth")), (n_99 is var _t100 && Truthy(_t100) ? _t100 : cr_74));
}, 2, "snap", true)).Put("back", Fn((V _self1, int _argc101, V t_107, V H_108, V x_109, V _a106, V[] _rest102) => {
return Invoke(t_107, "to", ((V)(260D)), Call(o_13, V.Undef, Get(H_108, "chest"), NewObj(6).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("pitch", ((V)(0.05))).Put("ly", ((V)(0.2))).Put("wide", ((V)(0D))).V, (x_109 is var _t110 && Truthy(_t110) ? _t110 : NewObj(0).V)), ((V)("io")));
}, 3, "back", true)).Put("bite", Fn((V _self111, int _argc112, V t_118, V H_119, V last_120, V i_121, V[] _rest113) => {
V q_122 = default;
if (_self111.IsNullish) _self111 = GlobalV;
q_122 = (_argc112 > 4 ? _rest113[0] : V.Undef);
Invoke(C_76, "toMouth", t_118, H_119, (Truthy(q_122) ? NewObj(1).Put("open", ((V)(0.85))).V : V.Null), (Truthy(q_122) ? ((V)(170D)) : V.Null));
Invoke(C_76, "snap", t_118);
if (Truthy(last_120)) {
Invoke(t_118, "e", ((V)("done")));
}
return Invoke(C_76, "back", t_118, H_119);
return default;
}, 5, "bite", false)).Put("chew", Fn((V _self123, int _argc124, V t_130, V n_131, V big_132, V _a129, V[] _rest125) => {
V h_133 = default;
V pf_134 = default;
if (_self123.IsNullish) _self123 = GlobalV;
n_131 = ((V)(Max(1D, Round((ToNum(n_131) * ToNum((Get(P_72, "chewN") is var _t135 && Truthy(_t135) ? _t135 : ((V)(1D)))))))));
h_133 = (Get(P_72, "chewMs") is var _t136 && Truthy(_t136) ? _t136 : ((V)(135D)));
pf_134 = (Get(P_72, "puff") is var _t137 && Truthy(_t137) ? _t137 : ((V)(1D)));
if (Truthy(Get(P_72, "savor"))) {
Invoke(t_130, "to", ((V)(140D)), NewObj(1).Put("close", Get(P_72, "savor")).V, ((V)("io")));
}
{
double i_138 = 0;
i_138 = 0D;
while (true) {
if (!(Lt(((V)(i_138)), n_131))) break;
Invoke(Invoke(t_130, "to", h_133, NewObj(6).Put("open", ((V)(0.22))).Put("puff", ((V)(Max(stash_75, ((Truthy(big_132) ? 1D : 0.65) * ToNum(pf_134)))))).Put("sq", ((V)(0.025))).Put("mw", ((V)(0.85))).Put("pitch", ((V)((-0.03)))).Put("htilt", ((V)((NumTruthy((i_138 % 2D)) ? 1.5 : (-1.5))))).V, ((V)("io"))), "to", h_133, NewObj(5).Put("open", ((V)(0.02))).Put("puff", ((V)(Max(stash_75, ((Truthy(big_132) ? 0.85 : 0.5) * ToNum(pf_134)))))).Put("sq", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0.02))).V, ((V)("io")));
i_138++;
}
}
return t_130;
return default;
}, 3, "chew", false)).Put("gulp", Fn((V _self140, int _argc141, V t_147, V _a144, V _a145, V _a146, V[] _rest142) => {
if (_self140.IsNullish) _self140 = GlobalV;
if (Truthy(Get(P_72, "stash"))) {
stash_75 = Min(1.15, ToNum(Add(((V)(stash_75)), Get(P_72, "stash"))));
}
return Invoke(Invoke(Invoke(t_147, "to", ((V)(150D)), NewObj(6).Put("puff", ((V)(stash_75))).Put("sq", ((V)(0.06))).Put("pitch", ((V)(0.16))).Put("open", ((V)(0D))).Put("htilt", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("o"))), "e", ((V)("gulp"))), "to", ((V)(220D)), NewObj(2).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "gulp", false)).Put("whole", Fn((V _self148, int _argc149, V t_155, V H_156, V _a153, V _a154, V[] _rest150) => {
if (_self148.IsNullish) _self148 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_155, "to", ((V)(320D)), Call(o_13, V.Undef, Get(H_156, "mouth"), NewObj(4).Put("open", ((V)(1D))).Put("mw", ((V)(1.1))).Put("pitch", ((V)(0.08))).Put("wide", ((V)(0.3))).V), ((V)("io"))), "to", ((V)(110D)), NewObj(4).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("puff", ((V)((1.1 * ToNum((Get(P_72, "puff") is var _t157 && Truthy(_t157) ? _t157 : ((V)(1D)))))))).Put("sq", ((V)(0.08))).V, ((V)("o"))), "e", ((V)("bite"))), "e", ((V)("done"))), "to", ((V)(300D)), Call(o_13, V.Undef, Get(H_156, "chest"), NewObj(3).Put("sq", ((V)(0D))).Put("wide", ((V)(0D))).Put("hap", ((V)(1D))).V), ((V)("io")));
Invoke(C_76, "chew", t_155, ((V)(5D)), (true ? V.True : V.False));
return Invoke(C_76, "gulp", t_155);
return default;
}, 2, "whole", false)).Put("big", Fn((V _self158, int _argc159, V t_165, V H_166, V _a163, V _a164, V[] _rest160) => {
if (_self158.IsNullish) _self158 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_165, "to", ((V)(380D)), Call(o_13, V.Undef, Get(H_166, "mouth"), NewObj(6).Put("open", ((V)(1D))).Put("mw", ((V)(1.45))).Put("pitch", ((V)(0.12))).Put("htilt", ((V)((-6D)))).Put("wide", ((V)(0.5))).Put("sq", ((V)((-0.05)))).V), ((V)("io"))), "wait", ((V)(150D))), "to", ((V)(110D)), NewObj(6).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("sq", ((V)(0.1))).Put("puff", ((V)(1.2))).Put("htilt", ((V)(0D))).Put("wide", ((V)(0D))).V, ((V)("o"))), "e", ((V)("bite"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("mouth")), ((V)(5D))), "to", ((V)(300D)), Call(o_13, V.Undef, Get(H_166, "chest"), NewObj(2).Put("sq", ((V)(0D))).Put("pitch", ((V)(0.04))).V), ((V)("io")));
Invoke(C_76, "chew", t_165, ((V)(6D)), (true ? V.True : V.False));
Invoke(C_76, "gulp", t_165);
Invoke(C_76, "bite", t_165, H_166, (true ? V.True : V.False));
Invoke(C_76, "chew", t_165, ((V)(3D)));
return Invoke(C_76, "gulp", t_165);
return default;
}, 2, "big", false)).V;
Invoke(Arr(((V)("bite")), ((V)("chew")), ((V)("gulp")), ((V)("whole")), ((V)("big")), ((V)("share"))), "forEach", Fn((V _self1, int _argc167, V k_173, V _a170, V _a171, V _a172, V[] _rest168) => {
if (Truthy(GetK(P_72, k_173))) {
SetK(C_76, k_173, InvokeK(P_72, k_173, C_76, P_72));
}
return default;
}, 1, "", true));
Set(C_76, "end", Fn((V _self1, int _argc174, V _a176, V _a177, V _a178, V _a179, V[] _rest175) => {
double v_180 = 0;
v_180 = stash_75;
stash_75 = 0D;
return ((V)(v_180));
return default;
}, 0, "", true));
return C_76;
return default;
}, 1, "", true);
STY_29 = NewObj(9).Put("chomp", Fn((V _self181, int _argc182, V t_188, V H_189, V f_190, V C_191, V[] _rest183) => {
if (_self181.IsNullish) _self181 = GlobalV;
{
double i_192 = 0;
i_192 = 0D;
while (true) {
if (!(Lt(((V)(i_192)), Get(f_190, "n")))) break;
V last_194 = default;
last_194 = ((i_192 == (ToNum(Get(f_190, "n")) - 1D)) ? V.True : V.False);
if (Truthy(((Get(C_191, "share") is var _t195 && !Truthy(_t195) ? _t195 : ((i_192 == 1D) ? V.True : V.False)) is var _t196 && !Truthy(_t196) ? _t196 : (!(Truthy(last_194)) ? V.True : V.False)))) {
Invoke(C_191, "share", t_188, H_189);
goto _cont193;
}
Invoke(C_191, "bite", t_188, H_189, last_194, ((V)(i_192)));
Invoke(C_191, "chew", t_188, (Get(f_190, "chew") is var _t197 && Truthy(_t197) ? _t197 : ((V)(3D))));
Invoke(C_191, "gulp", t_188);
_cont193: ;
i_192++;
}
}
return default;
}, 4, "chomp", false)).Put("gobble", Fn((V _self198, int _argc199, V t_205, V H_206, V f_207, V C_208, V[] _rest200) => {
if (_self198.IsNullish) _self198 = GlobalV;
{
double i_209 = 0;
i_209 = 0D;
while (true) {
if (!(Lt(((V)(i_209)), Get(f_207, "n")))) break;
V last_211 = default;
last_211 = ((i_209 == (ToNum(Get(f_207, "n")) - 1D)) ? V.True : V.False);
if (Truthy(((Get(C_208, "share") is var _t212 && !Truthy(_t212) ? _t212 : ((i_209 == 2D) ? V.True : V.False)) is var _t213 && !Truthy(_t213) ? _t213 : (!(Truthy(last_211)) ? V.True : V.False)))) {
Invoke(C_208, "share", t_205, H_206);
goto _cont210;
}
Invoke(C_208, "bite", t_205, H_206, last_211, ((V)(i_209)), (true ? V.True : V.False));
Invoke(C_208, "chew", t_205, ((V)(1D)));
_cont210: ;
i_209++;
}
}
Invoke(C_208, "gulp", t_205);
return default;
}, 4, "gobble", false)).Put("nibble", Fn((V _self214, int _argc215, V t_221, V H_222, V f_223, V C_224, V[] _rest216) => {
if (_self214.IsNullish) _self214 = GlobalV;
Invoke(t_221, "to", ((V)(320D)), Call(o_13, V.Undef, Get(H_222, "mouth"), NewObj(2).Put("pitch", ((V)((-0.08)))).Put("ly", ((V)(0.5))).V), ((V)("io")));
{
double i_225 = 0;
i_225 = 0D;
while (true) {
if (!(Lt(((V)(i_225)), Get(f_223, "n")))) break;
Invoke(Invoke(Invoke(Invoke(t_221, "to", ((V)(85D)), NewObj(3).Put("open", ((V)(0.3))).Put("mw", ((V)(0.6))).Put("sq", ((V)(0.02))).V, ((V)("o"))), "to", ((V)(85D)), NewObj(3).Put("open", ((V)(0D))).Put("sq", ((V)(0D))).Put("puff", ((V)(0.45))).V, ((V)("io"))), "e", ((V)("bite"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("mouth")), ((V)(1D)));
i_225++;
}
}
Invoke(t_221, "e", ((V)("done")));
Invoke(C_224, "back", t_221, H_222, NewObj(2).Put("puff", ((V)(0.55))).Put("mw", ((V)(1D))).V);
Invoke(C_224, "chew", t_221, ((V)(3D)));
Invoke(C_224, "gulp", t_221);
return default;
}, 4, "nibble", false)).Put("typewriter", Fn((V _self227, int _argc228, V t_234, V H_235, V f_236, V C_237, V[] _rest229) => {
V m_238 = default;
if (_self227.IsNullish) _self227 = GlobalV;
m_238 = Get(H_235, "mouth");
{
double row_239 = 0;
row_239 = 0D;
while (true) {
if (!((row_239 < 2D))) break;
Invoke(t_234, "to", ((V)(300D)), Call(o_13, V.Undef, m_238, NewObj(5).Put("hLx", Add(Get(m_238, "hLx"), ((V)(6D)))).Put("hRx", Add(Get(m_238, "hRx"), ((V)(6D)))).Put("pitch", ((V)((-0.08)))).Put("ly", ((V)(0.4))).Put("hyaw", ((V)(0.15))).V), ((V)("io")));
{
double i_241 = 0;
i_241 = 0D;
while (true) {
if (!(Lt(((V)(i_241)), Get(f_236, "n")))) break;
double p_243 = 0;
p_243 = (6D - (((i_241 + 1D) * 12D) / ToNum(Get(f_236, "n"))));
Invoke(Invoke(Invoke(Invoke(t_234, "to", ((V)(110D)), NewObj(4).Put("open", ((V)(0.35))).Put("hLx", Add(Get(m_238, "hLx"), ((V)(p_243)))).Put("hRx", Add(Get(m_238, "hRx"), ((V)(p_243)))).Put("hyaw", ((V)(((-p_243) / 32D)))).V, ((V)("io"))), "to", ((V)(90D)), NewObj(2).Put("open", ((V)(0D))).Put("sq", ((V)(0.03))).V, ((V)("o"))), "e", ((V)("bite"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("mouth")), ((V)(1D)));
i_241++;
}
}
Invoke(Invoke(Invoke(t_234, "to", ((V)(170D)), NewObj(5).Put("hLx", Add(Get(m_238, "hLx"), ((V)(6D)))).Put("hRx", Add(Get(m_238, "hRx"), ((V)(6D)))).Put("hyaw", ((V)(0.2))).Put("sq", ((V)(0D))).Put("wide", ((V)(0.4))).V, ((V)("o"))), "e", ((V)("ding"))), "to", ((V)(120D)), NewObj(1).Put("wide", ((V)(0D))).V);
row_239++;
}
}
Invoke(t_234, "e", ((V)("done")));
Invoke(C_237, "back", t_234, H_235, NewObj(2).Put("hyaw", ((V)(0D))).Put("puff", ((V)(0.7))).V);
Invoke(C_237, "chew", t_234, ((V)(3D)));
if (Truthy(Get(f_236, "seed"))) {
Invoke(Invoke(Invoke(t_234, "to", ((V)(160D)), NewObj(4).Put("puff", ((V)(0.3))).Put("mw", ((V)(0.45))).Put("open", ((V)(0.2))).Put("hyaw", ((V)(0.4))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("seed")), ((V)("mouth"))), "to", ((V)(220D)), NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hyaw", ((V)(0D))).V);
}
Invoke(C_237, "gulp", t_234);
return default;
}, 4, "typewriter", false)).Put("lick", Fn((V _self244, int _argc245, V t_251, V H_252, V f_253, V C_254, V[] _rest246) => {
V L_255 = default;
if (_self244.IsNullish) _self244 = GlobalV;
L_255 = Call(o_13, V.Undef, Get(H_252, "mouth"));
{
foreach (V _k256 in ForInKeys(L_255)) {
V q_257 = default;
q_257 = _k256;
if (Truthy(Invoke(NewRegExp(RX0, "y$", ""), "test", q_257))) {
OpSetK(L_255, q_257, 0, ((V)(3D)));
}
}
}
Invoke(t_251, "to", ((V)(320D)), Call(o_13, V.Undef, L_255, NewObj(2).Put("ly", ((V)(0.5))).Put("pitch", ((V)((-0.05)))).V), ((V)("io")));
{
double i_258 = 0;
i_258 = 0D;
while (true) {
if (!(Lt(((V)(i_258)), Get(f_253, "n")))) break;
Invoke(Invoke(Invoke(t_251, "to", ((V)(170D)), NewObj(6).Put("tongue", ((V)(1D))).Put("pitch", ((V)(0.18))).Put("sq", ((V)((-0.04)))).Put("open", ((V)(0.12))).Put("close", ((V)(0.5))).Put("hyaw", ((V)((Truthy(Get(f_253, "swirl")) ? (NumTruthy((i_258 % 2D)) ? 0.22 : (-0.22)) : 0D)))).V, ((V)("io"))), "e", ((V)("lick"))), "to", ((V)(230D)), NewObj(4).Put("tongue", ((V)(0.15))).Put("pitch", ((V)((-0.05)))).Put("sq", ((V)(0.01))).Put("open", ((V)(0D))).V, ((V)("io")));
i_258++;
}
}
Invoke(t_251, "to", ((V)(200D)), NewObj(5).Put("tongue", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("close", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(0.8))).V, ((V)("io")));
if (Truthy(Get(f_253, "then"))) {
Invoke(C_254, "bite", t_251, H_252, (true ? V.True : V.False));
Invoke(C_254, "chew", t_251, ((V)(3D)));
Invoke(C_254, "gulp", t_251);
} else {
Invoke(Invoke(t_251, "e", ((V)("done"))), "to", ((V)(300D)), Call(o_13, V.Undef, Get(H_252, "chest")), ((V)("io")));
}
return default;
}, 4, "lick", false)).Put("whole", Fn((V _self260, int _argc261, V t_267, V H_268, V f_269, V C_270, V[] _rest262) => {
if (_self260.IsNullish) _self260 = GlobalV;
Invoke(C_270, "whole", t_267, H_268);
return default;
}, 4, "whole", false)).Put("big", Fn((V _self271, int _argc272, V t_278, V H_279, V f_280, V C_281, V[] _rest273) => {
if (_self271.IsNullish) _self271 = GlobalV;
Invoke(C_281, "big", t_278, H_279);
return default;
}, 4, "big", false)).Put("slurp", Fn((V _self282, int _argc283, V t_289, V H_290, V f_291, V C_292, V[] _rest284) => {
if (_self282.IsNullish) _self282 = GlobalV;
{
double i_293 = 0;
i_293 = 0D;
while (true) {
if (!((i_293 < 3D))) break;
V a_295 = default;
Invoke(t_289, "to", ((V)(220D)), NewObj(4).Put("pitch", ((V)((-0.25)))).Put("ly", ((V)(0.6))).Put("mw", ((V)(0.5))).Put("open", ((V)(0.25))).V, ((V)("io")));
a_295 = Get(t_289, "t");
Invoke(t_289, "osc", ((V)(700D)), ((V)(5D)), NewObj(3).Put("sq", ((V)(0.04))).Put("open", ((V)(0.2))).Put("mw", ((V)(0.42))).V, NewObj(3).Put("sq", ((V)((-0.01)))).Put("open", ((V)(0.28))).Put("mw", ((V)(0.5))).V, ((V)("s")));
Invoke(Get(f_291, "wins"), "push", Arr(a_295, Get(t_289, "t")));
Invoke(t_289, "to", ((V)(120D)), NewObj(4).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("puff", ((V)(0.6))).Put("pitch", ((V)(0.05))).V, ((V)("o")));
Invoke(C_292, "chew", t_289, ((V)(2D)));
Invoke(C_292, "gulp", t_289);
i_293++;
}
}
Invoke(t_289, "e", ((V)("done")));
return default;
}, 4, "slurp", false)).Put("sip", Fn((V _self296, int _argc297, V t_303, V H_304, V f_305, V C_306, V[] _rest298) => {
if (_self296.IsNullish) _self296 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_303, "to", ((V)(320D)), Call(o_13, V.Undef, (Get(f_305, "mp") is var _t307 && Truthy(_t307) ? _t307 : Get(H_304, "mouth")), NewObj(1).Put("pitch", ((V)((-0.05)))).V), ((V)("io"))), "to", ((V)(160D)), NewObj(3).Put("mw", ((V)(0.42))).Put("open", ((V)(0.1))).Put("puff", ((V)((-0.4)))).V, ((V)("o"))), "em", ((V)(1800D)), ((V)(450D)), ((V)("bubble")), ((V)("mouth")), ((V)(1D))), "osc", ((V)(1800D)), ((V)(6D)), NewObj(2).Put("puff", ((V)((-0.5)))).Put("sq", ((V)(0.03))).V, NewObj(2).Put("puff", ((V)((-0.3)))).Put("sq", ((V)(0D))).V, ((V)("s"))), "to", ((V)(140D)), NewObj(3).Put("puff", ((V)((-0.6)))).Put("sq", ((V)(0.06))).Put("wide", ((V)(0.4))).V, ((V)("o"))), "e", ((V)("crumple"))), "to", ((V)(260D)), Call(o_13, V.Undef, Get(H_304, "chest"), NewObj(5).Put("mw", ((V)(1D))).Put("open", ((V)(0D))).Put("puff", ((V)(0D))).Put("sq", ((V)(0D))).Put("wide", ((V)(0D))).V), ((V)("io"))), "wait", ((V)(300D))), "e", ((V)("done")));
return default;
}, 4, "sip", false)).V;
recv_30 = Fn((V _self1, int _argc308, V t_314, V H_315, V P_316, V _a313, V[] _rest309) => {
V E_317 = default;
E_317 = (GetK(EAR_27, Get(P_316, "key")).IsNullish ? ((V)(1D)) : GetK(EAR_27, Get(P_316, "key")));
return Invoke(Invoke(Invoke(Invoke(Invoke(t_314, "e", ((V)("food"))), "to", ((V)(110D)), NewObj(2).Put("ly", ((V)(0.7))).Put("wide", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(300D)), Call(o_13, V.Undef, Get(H_315, "chest"), NewObj(4).Put("pitch", ((V)((-0.18)))).Put("sq", ((V)(0.05))).Put("earL", ((V)(((-6D) * ToNum(E_317))))).Put("earR", ((V)(((-6D) * ToNum(E_317))))).V), ((V)("o"))), "to", ((V)(300D)), NewObj(6).Put("wide", ((V)(0D))).Put("smile", ((V)(0.8))).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("pitch", ((V)((-0.08)))).V, ((V)("io"))), "wait", ((V)(150D)));
return default;
}, 3, "", true);
sniffF_31 = Fn((V _self1, int _argc318, V t_324, V n_325, V _a322, V _a323, V[] _rest319) => {
return Invoke(Invoke(Invoke(Invoke(t_324, "to", ((V)(200D)), NewObj(2).Put("pitch", ((V)((-0.18)))).Put("ly", ((V)(0.7))).V, ((V)("io"))), "osc", ((V)((ToNum((n_325 is var _t326 && Truthy(_t326) ? _t326 : ((V)(2D)))) * 230D))), (n_325 is var _t327 && Truthy(_t327) ? _t327 : ((V)(2D))), NewObj(3).Put("sq", ((V)(0.03))).Put("pitch", ((V)((-0.13)))).Put("mw", ((V)(0.85))).V, NewObj(3).Put("sq", ((V)(0D))).Put("pitch", ((V)((-0.18)))).Put("mw", ((V)(1D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(3).Put("pitch", ((V)((-0.05)))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("hap", ((V)(0D))).V, ((V)("io")));
}, 2, "", true);
lipLick_32 = Fn((V _self1, int _argc328, V t_334, V big_335, V _a332, V _a333, V[] _rest329) => {
return Invoke(Invoke(Invoke(t_334, "to", ((V)(140D)), NewObj(4).Put("tongue", ((V)((Truthy(big_335) ? 1D : 0.8)))).Put("open", ((V)((Truthy(big_335) ? 0.3 : 0.15)))).Put("hyaw", ((V)(0.12))).Put("pitch", ((V)((Truthy(big_335) ? 0.08 : 0D)))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(1).Put("hyaw", ((V)((-0.12)))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(4).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 2, "", true);
sour_33 = Fn((V _self1, int _argc336, V t_342, V P_343, V _a340, V _a341, V[] _rest337) => {
Invoke(Invoke(t_342, "to", ((V)(130D)), NewObj(8).Put("sqz", ((V)(1D))).Put("mw", ((V)(0.4))).Put("open", ((V)(0.15))).Put("sq", ((V)(0.12))).Put("earL", ((V)(14D))).Put("earR", ((V)(14D))).Put("pitch", ((V)((-0.15)))).Put("puff", ((V)((-0.3)))).V, ((V)("o"))), "wait", ((V)(350D)));
Call(shake_16, V.Undef, t_342, NewObj(7).Put("P", ((V)(85D))).Put("env", Arr(((V)(0.5)), ((V)(1D)), ((V)(0.9)), ((V)(0.6)), ((V)(0.3)))).Put("head", ((V)(0.3))).Put("roll", ((V)(4D))).Put("ear", ((V)(10D))).Put("chest", ((V)(0.12))).Put("body", ((V)(0.6))).V);
return Invoke(Invoke(t_342, "to", ((V)(350D)), NewObj(10).Put("sqz", ((V)(0D))).Put("mw", ((V)(1D))).Put("open", ((V)(0D))).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("pitch", ((V)(0D))).Put("puff", ((V)(0D))).Put("smile", ((V)(0.6))).Put("hap", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(250D)));
return default;
}, 2, "", true);
freeze_34 = Fn((V _self1, int _argc344, V t_350, V P_351, V _a348, V _a349, V[] _rest345) => {
V hy_352 = default;
hy_352 = (Get(P_351, "headY") is var _t353 && Truthy(_t353) ? _t353 : ((V)((-22D))));
Invoke(Invoke(Invoke(t_350, "to", ((V)(150D)), NewObj(3).Put("sqz", ((V)(1D))).Put("sq", ((V)(0.08))).Put("frown", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(300D)), (Truthy(Get(P_351, "armsUp")) ? NewObj(4).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("earL", ((V)(16D))).Put("earR", ((V)(16D))).V : Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)((-1D))), hy_352), NewObj(4).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("earL", ((V)(16D))).Put("earR", ((V)(16D))).V)), ((V)("io"))), "wait", ((V)(300D)));
Call(shake_16, V.Undef, t_350, NewObj(6).Put("P", ((V)(75D))).Put("env", Arr(((V)(0.4)), ((V)(0.8)), ((V)(1D)), ((V)(0.8)), ((V)(0.5)), ((V)(0.25)))).Put("head", ((V)(0.16))).Put("roll", ((V)(3D))).Put("ear", ((V)(8D))).Put("body", ((V)(0.5))).V);
return Invoke(Invoke(t_350, "to", ((V)(400D)), Call(o_13, V.Undef, NOHANDS_14, NewObj(9).Put("sqz", ((V)(0D))).Put("frown", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("sq", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io"))), "wait", ((V)(300D)));
return default;
}, 2, "", true);
hearts_35 = Fn((V _self1, int _argc354, V t_360, V n_361, V _a358, V _a359, V[] _rest355) => {
return Invoke(t_360, "e", ((V)("emit")), ((V)("heart")), ((V)("head")), (n_361 is var _t362 && Truthy(_t362) ? _t362 : ((V)(2D))));
}, 2, "", true);
wagF_36 = Fn((V _self1, int _argc363, V t_369, V dur_370, V a_371, V _a368, V[] _rest364) => {
return Call(swing_17, V.Undef, t_369, dur_370, ((V)(Max(3D, Round((ToNum(dur_370) / 160D))))), NewObj(1).Put("wag", (a_371 is var _t372 && Truthy(_t372) ? _t372 : ((V)(30D)))).V);
}, 3, "", true);
para_37 = Fn((V _self1, int _argc373, V t_379, V from_380, V fn_381, V _a378, V[] _rest374) => {
V e_382 = default;
e_382 = Get(t_379, "t");
Invoke(t_379, "at", from_380);
Call(fn_381, V.Undef, t_379);
return Invoke(t_379, "at", ((V)(Max(ToNum(e_382), ToNum(Get(t_379, "t"))))));
return default;
}, 3, "", true);
pat_38 = Fn((V _self1, int _argc383, V t_389, V n_390, V _a387, V _a388, V[] _rest384) => {
Invoke(t_389, "to", ((V)(260D)), Call(both_12, V.Undef, ((V)(9D)), ((V)(0D))), ((V)("io")));
{
double i_391 = 0;
i_391 = 0D;
while (true) {
if (!(Lt(((V)(i_391)), (n_390 is var _t393 && Truthy(_t393) ? _t393 : ((V)(3D)))))) break;
Invoke(Invoke(t_389, "to", ((V)(140D)), NewObj(3).Put("hLy", ((V)(2D))).Put("hRy", ((V)((-1D)))).Put("sq", ((V)(0.03))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(3).Put("hLy", ((V)((-1D)))).Put("hRy", ((V)(2D))).Put("sq", ((V)(0D))).V, ((V)("io")));
i_391++;
}
}
return Invoke(t_389, "to", ((V)(260D)), NOHANDS_14, ((V)("io")));
return default;
}, 2, "", true);
oink_39 = Fn((V _self1, int _argc394, V t_400, V _a397, V _a398, V _a399, V[] _rest395) => {
return Invoke(Invoke(Invoke(t_400, "to", ((V)(120D)), NewObj(3).Put("open", ((V)(0.55))).Put("mw", ((V)(0.8))).Put("pitch", ((V)(0.12))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(200D)), NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 1, "", true);
wheek_40 = Fn((V _self1, int _argc401, V t_407, V _a404, V _a405, V _a406, V[] _rest402) => {
return Invoke(Invoke(Invoke(Invoke(t_407, "to", ((V)(130D)), NewObj(4).Put("pitch", ((V)(0.2))).Put("open", ((V)(0.65))).Put("mw", ((V)(0.75))).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(220D)), NewObj(2).Put("pitch", ((V)(0.16))).Put("open", ((V)(0.45))).V, ((V)("io"))), "to", ((V)(180D)), NewObj(4).Put("pitch", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("sq", ((V)(0D))).V, ((V)("io")));
}, 1, "", true);
boof_41 = Fn((V _self1, int _argc408, V t_414, V _a411, V _a412, V _a413, V[] _rest409) => {
return Invoke(Invoke(Invoke(Invoke(t_414, "to", ((V)(110D)), NewObj(4).Put("open", ((V)(0.85))).Put("mw", ((V)(0.85))).Put("sq", ((V)((-0.07)))).Put("pitch", ((V)(0.12))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(200D)), NewObj(4).Put("open", ((V)(0.15))).Put("mw", ((V)(1D))).Put("sq", ((V)(0.03))).Put("pitch", ((V)(0D))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(2).Put("sq", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
}, 1, "", true);
CARDS_42 = NewObj(10).Put("mittens", NewObj(6).Put("savor", ((V)(0.5))).Put("txt", ((V)("Sniffs it first, neat bites, savours it, licks his lips."))).Put("pre", Fn((V _self1, int _argc415, V t_421, V _a418, V _a419, V _a420, V[] _rest416) => {
return Call(sniffF_31, V.Undef, t_421, ((V)(2D)));
}, 1, "pre", true)).Put("post", Fn((V _self1, int _argc422, V t_428, V _a425, V _a426, V _a427, V[] _rest423) => {
return Call(lipLick_32, V.Undef, t_428);
}, 1, "post", true)).Put("yum", Fn((V _self1, int _argc429, V t_435, V _a432, V _a433, V _a434, V[] _rest430) => {
return Invoke(REACT_26, "yum", t_435);
}, 1, "yum", true)).Put("love", Fn((V _self1, int _argc436, V t_442, V _a439, V _a440, V _a441, V[] _rest437) => {
return Invoke(REACT_26, "love", t_442);
}, 1, "love", true)).V).Put("biscuit", NewObj(9).Put("open", ((V)(0.85))).Put("crumbs", ((V)(3D))).Put("chewN", ((V)(0.6))).Put("chewMs", ((V)(115D))).Put("txt", ((V)("Tail going the whole time, big quick bites, crumbs fly, licks his chops and looks for more."))).Put("recv", Fn((V _self1, int _argc443, V t_449, V H_450, V P_451, V _a448, V[] _rest444) => {
V a_452 = default;
a_452 = Get(t_449, "t");
Call(recv_30, V.Undef, t_449, H_450, P_451);
Call(para_37, V.Undef, t_449, a_452, Fn((V _self1, int _argc453, V u_459, V _a456, V _a457, V _a458, V[] _rest454) => {
return Call(wagF_36, V.Undef, u_459, ((V)((ToNum(Get(t_449, "t")) - ToNum(a_452)))), ((V)(30D)));
}, 1, "", true));
return default;
}, 3, "recv", true)).Put("post", Fn((V _self1, int _argc460, V t_466, V _a463, V _a464, V _a465, V[] _rest461) => {
Call(lipLick_32, V.Undef, t_466, (true ? V.True : V.False));
Invoke(Invoke(Invoke(Invoke(Invoke(t_466, "to", ((V)(110D)), NewObj(1).Put("lx", ((V)((-0.8)))).V, ((V)("o"))), "wait", ((V)(220D))), "to", ((V)(110D)), NewObj(1).Put("lx", ((V)(0.8))).V, ((V)("o"))), "wait", ((V)(220D))), "to", ((V)(110D)), NewObj(1).Put("lx", ((V)(0D))).V, ((V)("o")));
return default;
}, 1, "post", true)).Put("yum", Fn((V _self1, int _argc467, V t_473, V _a470, V _a471, V _a472, V[] _rest468) => {
V a_474 = default;
Invoke(t_473, "to", ((V)(200D)), NewObj(4).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("tongue", ((V)(0.7))).Put("open", ((V)(0.3))).V, ((V)("io")));
a_474 = Get(t_473, "t");
Call(jump_15, V.Undef, t_473, NewObj(5).Put("h", ((V)(7D))).Put("ant", ((V)(140D))).Put("up", ((V)(200D))).Put("c", ((V)(0.14))).Put("arm", ((V)(30D))).V);
Call(para_37, V.Undef, t_473, a_474, Fn((V _self1, int _argc475, V u_481, V _a478, V _a479, V _a480, V[] _rest476) => {
return Call(wagF_36, V.Undef, u_481, ((V)((ToNum(Get(t_473, "t")) - ToNum(a_474)))), ((V)(32D)));
}, 1, "", true));
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1, int _argc482, V t_488, V P_489, V _a486, V _a487, V[] _rest483) => {
Invoke(Get(CARDS_42, "biscuit"), "yum", t_488, P_489);
Call(hearts_35, V.Undef, t_488, ((V)(2D)));
Invoke(t_488, "to", ((V)(300D)), NewObj(1).Put("blush", ((V)(1D))).V, ((V)("io")));
return default;
}, 2, "love", true)).V).Put("truffle", NewObj(8).Put("crumbs", ((V)(4D))).Put("puff", ((V)(1.15))).Put("open", ((V)(0.8))).Put("txt", ((V)("Snorts at it, big messy chomps with crumbs everywhere, oinks, pats his belly."))).Put("pre", Fn((V _self1, int _argc490, V t_496, V _a493, V _a494, V _a495, V[] _rest491) => {
Invoke(Invoke(t_496, "to", ((V)(80D)), NewObj(3).Put("sq", ((V)(0.06))).Put("pitch", ((V)(0.1))).Put("mw", ((V)(0.75))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(3).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("io")));
Call(sniffF_31, V.Undef, t_496, ((V)(2D)));
return default;
}, 1, "pre", true)).Put("post", Fn((V _self1, int _argc497, V t_503, V _a500, V _a501, V _a502, V[] _rest498) => {
Call(pat_38, V.Undef, t_503, ((V)(2D)));
return default;
}, 1, "post", true)).Put("yum", Fn((V _self1, int _argc504, V t_510, V _a507, V _a508, V _a509, V[] _rest505) => {
Call(oink_39, V.Undef, t_510);
Invoke(t_510, "to", ((V)(160D)), NewObj(3).Put("sq", ((V)(0.12))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(jelly_18, V.Undef, t_510, ((V)(0.1)), ((V)(4D)), ((V)(230D)));
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1, int _argc511, V t_517, V _a514, V _a515, V _a516, V[] _rest512) => {
Call(oink_39, V.Undef, t_517);
Call(hearts_35, V.Undef, t_517, ((V)(2D)));
Invoke(t_517, "to", ((V)(160D)), NewObj(4).Put("sq", ((V)(0.12))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("blush", ((V)(1D))).V, ((V)("io")));
Call(jelly_18, V.Undef, t_517, ((V)(0.1)), ((V)(4D)), ((V)(230D)));
return default;
}, 1, "love", true)).V).Put("nibbles", NewObj(11).Put("chewMs", ((V)(95D))).Put("chewN", ((V)(1.4))).Put("stash", ((V)(0.35))).Put("puff", ((V)(1.1))).Put("open", ((V)(0.45))).Put("headY", ((V)((-16D)))).Put("txt", ((V)("Quick nibbly bites, stuffs his cheeks (they stay puffed), pats them, then swallows."))).Put("pre", Fn((V _self1, int _argc518, V t_524, V _a521, V _a522, V _a523, V[] _rest519) => {
Invoke(t_524, "osc", ((V)(500D)), ((V)(4D)), NewObj(3).Put("sq", ((V)(0.025))).Put("pitch", ((V)((-0.06)))).Put("mw", ((V)(0.8))).V, NewObj(3).Put("sq", ((V)(0D))).Put("pitch", ((V)((-0.1)))).Put("mw", ((V)(1D))).V, ((V)("o")));
return default;
}, 1, "pre", true)).Put("post", Fn((V _self1, int _argc525, V t_531, V P_532, V C_533, V _a530, V[] _rest526) => {
V v_534 = default;
v_534 = Invoke(C_533, "end");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_531, "to", ((V)(260D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(1D)), ((V)((-15D)))), NewObj(3).Put("puff", ((V)(Max(0.9, ToNum(v_534))))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io"))), "osc", ((V)(600D)), ((V)(2D)), NewObj(2).Put("hLy", ((V)((-16D)))).Put("hRy", ((V)((-14D)))).V, NewObj(2).Put("hLy", ((V)((-14D)))).Put("hRy", ((V)((-16D)))).V, ((V)("io"))), "to", ((V)(220D)), Call(o_13, V.Undef, NOHANDS_14), ((V)("io"))), "to", ((V)(800D)), NewObj(2).Put("puff", ((V)(0D))).Put("sq", ((V)(0.03))).V, ((V)("io"))), "e", ((V)("gulp"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
return default;
}, 3, "post", true)).Put("yum", Fn((V _self1, int _argc535, V t_541, V _a538, V _a539, V _a540, V[] _rest536) => {
Invoke(t_541, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
{
double i_542 = 0;
i_542 = 0D;
while (true) {
if (!((i_542 < 3D))) break;
Invoke(Invoke(t_541, "to", ((V)(110D)), NewObj(2).Put("sq", ((V)(0.05))).Put("lift", ((V)(1D))).V, ((V)("o"))), "to", ((V)(130D)), NewObj(2).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io")));
i_542++;
}
}
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1, int _argc544, V t_550, V _a547, V _a548, V _a549, V[] _rest545) => {
Call(hearts_35, V.Undef, t_550, ((V)(2D)));
Invoke(Get(CARDS_42, "nibbles"), "yum", t_550);
Invoke(t_550, "to", ((V)(200D)), NewObj(1).Put("blush", ((V)(1D))).V, ((V)("io")));
return default;
}, 1, "love", true)).V).Put("quill", NewObj(8).Put("open", ((V)(0.45))).Put("chewMs", ((V)(140D))).Put("chewN", ((V)(0.9))).Put("txt", ((V)("Glances around shyly first, small careful bites, blushes."))).Put("pre", Fn((V _self1, int _argc551, V t_557, V _a554, V _a555, V _a556, V[] _rest552) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_557, "to", ((V)(300D)), NewObj(3).Put("hyaw", ((V)((-0.25)))).Put("lx", ((V)((-0.6)))).Put("blush", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(400D)), NewObj(2).Put("hyaw", ((V)(0.25))).Put("lx", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(300D)), NewObj(3).Put("hyaw", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0.5))).V, ((V)("io")));
return default;
}, 1, "pre", true)).Put("post", Fn((V _self1, int _argc558, V t_564, V _a561, V _a562, V _a563, V[] _rest559) => {
return Invoke(Invoke(Invoke(t_564, "to", ((V)(300D)), NewObj(4).Put("blush", ((V)(1D))).Put("smile", ((V)(0.6))).Put("ly", ((V)(0.4))).Put("pitch", ((V)((-0.08)))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(250D)), NewObj(2).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 1, "post", true)).Put("yum", Fn((V _self1, int _argc565, V t_571, V _a568, V _a569, V _a570, V[] _rest566) => {
Invoke(t_571, "to", ((V)(200D)), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(0.9))).Put("blush", ((V)(0.8))).V, ((V)("io")));
Call(swing_17, V.Undef, t_571, ((V)(1200D)), ((V)(3D)), NewObj(3).Put("x", ((V)(1.6))).Put("bend", ((V)(2.5))).Put("htilt", ((V)((-2D)))).V);
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1, int _argc572, V t_578, V _a575, V _a576, V _a577, V[] _rest573) => {
Call(hearts_35, V.Undef, t_578, ((V)(1D)));
Invoke(t_578, "to", ((V)(300D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(2D)), ((V)((-18D)))), NewObj(3).Put("hap", ((V)(1D))).Put("blush", ((V)(1D))).Put("smile", ((V)(0.7))).V), ((V)("io")));
Call(swing_17, V.Undef, t_578, ((V)(1200D)), ((V)(3D)), NewObj(2).Put("x", ((V)(1.4))).Put("bend", ((V)(2D))).V);
Invoke(t_578, "to", ((V)(250D)), NOHANDS_14, ((V)("io")));
return default;
}, 1, "love", true)).V).Put("waffles", NewObj(8).Put("open", ((V)(0.9))).Put("crumbs", ((V)(2D))).Put("chewN", ((V)(0.6))).Put("txt", ((V)("Hops with excitement, wolfs it down, licks his nose, butt wiggle."))).Put("pre", Fn((V _self1, int _argc579, V t_585, V _a582, V _a583, V _a584, V[] _rest580) => {
return Call(jump_15, V.Undef, t_585, NewObj(5).Put("h", ((V)(6D))).Put("ant", ((V)(120D))).Put("up", ((V)(170D))).Put("c", ((V)(0.12))).Put("arm", ((V)(25D))).V);
}, 1, "pre", true)).Put("post", Fn((V _self1, int _argc586, V t_592, V _a589, V _a590, V _a591, V[] _rest587) => {
return Invoke(Invoke(Invoke(t_592, "to", ((V)(150D)), NewObj(3).Put("tongue", ((V)(1D))).Put("open", ((V)(0.35))).Put("pitch", ((V)(0.12))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("tongue", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(3).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 1, "post", true)).Put("yum", Fn((V _self1, int _argc593, V t_599, V _a596, V _a597, V _a598, V[] _rest594) => {
Invoke(t_599, "to", ((V)(150D)), NewObj(4).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("tongue", ((V)(0.6))).Put("open", ((V)(0.3))).V, ((V)("io")));
Call(swing_17, V.Undef, t_599, ((V)(1000D)), ((V)(9D)), NewObj(3).Put("tilt", ((V)(5D))).Put("x", ((V)(0.8))).Put("wag", ((V)(38D))).V);
Call(boof_41, V.Undef, t_599);
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1, int _argc600, V t_606, V _a603, V _a604, V _a605, V[] _rest601) => {
Call(hearts_35, V.Undef, t_606, ((V)(2D)));
Invoke(Get(CARDS_42, "waffles"), "yum", t_606);
return default;
}, 1, "love", true)).V).Put("poppy", NewObj(9).Put("chewMs", ((V)(100D))).Put("chewN", ((V)(1.6))).Put("open", ((V)(0.5))).Put("headY", ((V)((-16D)))).Put("txt", ((V)("Busy munching with a twitching nose, wheeks for joy."))).Put("pre", Fn((V _self1, int _argc607, V t_613, V _a610, V _a611, V _a612, V[] _rest608) => {
Invoke(t_613, "osc", ((V)(560D)), ((V)(4D)), NewObj(2).Put("sq", ((V)(0.025))).Put("mw", ((V)(0.8))).V, NewObj(2).Put("sq", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("o")));
return default;
}, 1, "pre", true)).Put("post", Fn((V _self1, int _argc614, V t_620, V _a617, V _a618, V _a619, V[] _rest615) => {
return Call(wheek_40, V.Undef, t_620);
}, 1, "post", true)).Put("yum", Fn((V _self1, int _argc621, V t_627, V _a624, V _a625, V _a626, V[] _rest622) => {
Call(popcorn_19, V.Undef, t_627, ((V)(10D)), ((V)(1D)), ((V)(500D)));
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1, int _argc628, V t_634, V _a631, V _a632, V _a633, V[] _rest629) => {
Call(hearts_35, V.Undef, t_634, ((V)(2D)));
Call(popcorn_19, V.Undef, t_634, ((V)(10D)), ((V)(1D)), ((V)(500D)));
Call(popcorn_19, V.Undef, t_634, ((V)(8D)), ((V)((-1D))), ((V)(440D)));
return default;
}, 1, "love", true)).V).Put("duchess", NewObj(10).Put("open", ((V)(0.4))).Put("crumbs", ((V)(0D))).Put("savor", ((V)(0.85))).Put("chewMs", ((V)(145D))).Put("chewN", ((V)(0.85))).Put("txt", ((V)("Inspects it first, tiny dainty bites, savours with her eyes shut, dabs her mouth, chin up."))).Put("pre", Fn((V _self1, int _argc635, V t_641, V _a638, V _a639, V _a640, V[] _rest636) => {
Invoke(t_641, "to", ((V)(320D)), NewObj(4).Put("htilt", ((V)(8D))).Put("close", ((V)(0.4))).Put("ly", ((V)(0.6))).Put("pitch", ((V)((-0.1)))).V, ((V)("io")));
Call(sniffF_31, V.Undef, t_641, ((V)(1D)));
Invoke(Invoke(t_641, "to", ((V)(240D)), NewObj(3).Put("htilt", ((V)(0D))).Put("close", ((V)(0D))).Put("pitch", ((V)((-0.12)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("pitch", ((V)((-0.04)))).V, ((V)("io")));
return default;
}, 1, "pre", true)).Put("post", Fn((V _self1, int _argc642, V t_648, V _a645, V _a646, V _a647, V[] _rest643) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_648, "to", ((V)(300D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(13D)), ((V)((-15D)))), NewObj(1).Put("armR", ((V)(18D))).V), ((V)("io"))), "osc", ((V)(500D)), ((V)(2D)), NewObj(1).Put("hRy", ((V)((-13D)))).V, NewObj(1).Put("hRy", ((V)((-16D)))).V, ((V)("io"))), "to", ((V)(300D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(0D)), ((V)(0D))), NewObj(3).Put("armR", ((V)(0D))).Put("pitch", ((V)(0.15))).Put("close", ((V)(0.4))).V), ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(250D)), NewObj(2).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "post", true)).Put("yum", Fn((V _self1, int _argc649, V t_655, V _a652, V _a653, V _a654, V[] _rest650) => {
Invoke(Invoke(Invoke(Invoke(t_655, "to", ((V)(400D)), NewObj(3).Put("pitch", ((V)(0.15))).Put("close", ((V)(1D))).Put("smile", ((V)(0.9))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(1).Put("close", ((V)(0.35))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1, int _argc656, V t_662, V _a659, V _a660, V _a661, V[] _rest657) => {
Call(hearts_35, V.Undef, t_662, ((V)(1D)));
Invoke(Get(CARDS_42, "duchess"), "yum", t_662);
return default;
}, 1, "love", true)).V).Put("mamapaws", NewObj(7).Put("chewMs", ((V)(150D))).Put("propZ", ((V)(12.5))).Put("txt", ((V)("Shares with her pup: the pup gets one of the bites, then hearts."))).Put("share", Fn((V _self1, int _argc663, V C_669, V P_670, V _a667, V _a668, V[] _rest664) => {
return Fn((V _self1, int _argc671, V t_677, V H_678, V _a675, V _a676, V[] _rest672) => {
V L_679 = default;
L_679 = (SEq(H_678, Get(HOLD_25, "two")) ? Call(both_12, V.Undef, ((V)(7D)), ((V)(10D))) : Call(hand_11, V.Undef, ((V)(1D)), ((V)(8D)), ((V)(10D))));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_677, "to", ((V)(380D)), Call(o_13, V.Undef, L_679, NewObj(3).Put("pitch", ((V)((-0.28)))).Put("ly", ((V)(0.9))).Put("smile", ((V)(1D))).V), ((V)("io"))), "wait", ((V)(120D))), "to", ((V)(110D)), NewObj(1).Put("sq", ((V)(0.03))).V, ((V)("o"))), "e", ((V)("bite"))), "e", ((V)("emit")), ((V)("crumb")), Arr(((V)(50D)), ((V)(70D))), ((V)(2D))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("hap", ((V)(1D))).V, ((V)("io")));
Call(hearts_35, V.Undef, t_677, ((V)(1D)));
Invoke(Invoke(t_677, "wait", ((V)(250D))), "to", ((V)(320D)), Call(o_13, V.Undef, Get(H_678, "chest"), NewObj(3).Put("pitch", ((V)(0D))).Put("ly", ((V)(0.2))).Put("hap", ((V)(0D))).V), ((V)("io")));
return default;
}, 2, "", true);
}, 2, "share", true)).Put("post", Fn((V _self1, int _argc680, V t_686, V _a683, V _a684, V _a685, V[] _rest681) => {
return Invoke(Invoke(Invoke(t_686, "to", ((V)(350D)), NewObj(3).Put("pitch", ((V)((-0.25)))).Put("ly", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io")));
}, 1, "post", true)).Put("yum", Fn((V _self1, int _argc687, V t_693, V _a690, V _a691, V _a692, V[] _rest688) => {
Call(hearts_35, V.Undef, t_693, ((V)(1D)));
{
double i_694 = 0;
i_694 = 0D;
while (true) {
if (!((i_694 < 2D))) break;
Invoke(Invoke(Invoke(Invoke(t_693, "to", ((V)(200D)), NewObj(3).Put("sq", ((V)(0.1))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(2).Put("sq", ((V)((-0.05)))).Put("lift", ((V)(2D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0.03))).Put("lift", ((V)(0D))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
i_694++;
}
}
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1, int _argc696, V t_702, V _a699, V _a700, V _a701, V[] _rest697) => {
Call(hearts_35, V.Undef, t_702, ((V)(2D)));
Invoke(Get(CARDS_42, "mamapaws"), "yum", t_702);
return default;
}, 1, "love", true)).V).Put("ribbit", NewObj(10).Put("txt", ((V)("Eats with his tongue - zap! - and swallows by squeezing his eyes shut, throat puffing."))).Put("pre", Fn((V _self1, int _argc703, V t_709, V _a706, V _a707, V _a708, V[] _rest704) => {
Invoke(t_709, "to", ((V)(250D)), NewObj(2).Put("ly", ((V)(0.7))).Put("pitch", ((V)((-0.08)))).V, ((V)("io")));
Call(croak_20, V.Undef, t_709, ((V)(1D)), ((V)(380D)));
return default;
}, 1, "pre", true)).Put("bite", Fn((V _self1, int _argc710, V C_716, V P_717, V _a714, V _a715, V[] _rest711) => {
return Fn((V _self1, int _argc718, V t_724, V H_725, V last_726, V _a723, V[] _rest719) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_724, "to", ((V)(160D)), Call(o_13, V.Undef, Get(H_725, "chest"), NewObj(3).Put("ly", ((V)(0.7))).Put("pitch", ((V)((-0.08)))).Put("sq", ((V)(0.06))).V), ((V)("io"))), "to", ((V)(70D)), NewObj(3).Put("tongue", ((V)(1D))).Put("open", ((V)(0.6))).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "e", ((V)("bite"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("mouth")), ((V)(1D))), "to", ((V)(110D)), NewObj(3).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("sq", ((V)(0.07))).V, ((V)("io")));
if (Truthy(last_726)) {
Invoke(t_724, "e", ((V)("done")));
}
return t_724;
return default;
}, 3, "", true);
}, 2, "bite", true)).Put("chew", Fn((V _self1, int _argc727, V C_733, V P_734, V _a731, V _a732, V[] _rest728) => {
return Fn((V _self1, int _argc735, V t_741, V n_742, V _a739, V _a740, V[] _rest736) => {
return Invoke(Invoke(Invoke(t_741, "to", ((V)(120D)), NewObj(5).Put("close", ((V)(1D))).Put("sqz", ((V)(0.6))).Put("puff", ((V)(0.6))).Put("sq", ((V)(0.06))).Put("pitch", ((V)((-0.05)))).V, ((V)("io"))), "wait", ((V)(Min(450D, (110D * ToNum(n_742)))))), "to", ((V)(160D)), NewObj(5).Put("close", ((V)(0D))).Put("sqz", ((V)(0D))).Put("puff", ((V)(0D))).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 2, "", true);
}, 2, "chew", true)).Put("gulp", Fn((V _self1, int _argc743, V C_749, V P_750, V _a747, V _a748, V[] _rest744) => {
return Fn((V _self1, int _argc751, V t_757, V _a754, V _a755, V _a756, V[] _rest752) => {
return Invoke(Invoke(Invoke(t_757, "to", ((V)(100D)), NewObj(1).Put("sq", ((V)(0.04))).V, ((V)("o"))), "e", ((V)("gulp"))), "to", ((V)(140D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
}, 1, "", true);
}, 2, "gulp", true)).Put("whole", Fn((V _self1, int _argc758, V C_764, V P_765, V _a762, V _a763, V[] _rest759) => {
return Fn((V _self1, int _argc766, V t_772, V H_773, V _a770, V _a771, V[] _rest767) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_772, "to", ((V)(200D)), Call(o_13, V.Undef, Get(H_773, "chest"), NewObj(2).Put("ly", ((V)(0.7))).Put("sq", ((V)(0.06))).V), ((V)("io"))), "to", ((V)(80D)), NewObj(3).Put("tongue", ((V)(1D))).Put("open", ((V)(0.8))).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "e", ((V)("bite"))), "e", ((V)("done"))), "to", ((V)(130D)), NewObj(4).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("puff", ((V)(1.1))).Put("sq", ((V)(0.08))).V, ((V)("io")));
return Invoke(C_764, "chew", t_772, ((V)(4D)));
return default;
}, 2, "", true);
}, 2, "whole", true)).Put("big", Fn((V _self1, int _argc774, V C_780, V P_781, V _a778, V _a779, V[] _rest775) => {
return Fn((V _self1, int _argc782, V t_788, V H_789, V _a786, V _a787, V[] _rest783) => {
Invoke(C_780, "bite", t_788, H_789, (false ? V.True : V.False));
Invoke(C_780, "chew", t_788, ((V)(3D)));
Invoke(C_780, "bite", t_788, H_789, (true ? V.True : V.False));
return Invoke(C_780, "chew", t_788, ((V)(3D)));
return default;
}, 2, "", true);
}, 2, "big", true)).Put("post", Fn((V _self1, int _argc790, V t_796, V _a793, V _a794, V _a795, V[] _rest791) => {
return Call(croak_20, V.Undef, t_796, ((V)(1D)), ((V)(400D)));
}, 1, "post", true)).Put("yum", Fn((V _self1, int _argc797, V t_803, V _a800, V _a801, V _a802, V[] _rest798) => {
Invoke(t_803, "to", ((V)(150D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(jump_15, V.Undef, t_803, NewObj(5).Put("h", ((V)(10D))).Put("ant", ((V)(130D))).Put("up", ((V)(210D))).Put("c", ((V)(0.22))).Put("arm", ((V)(45D))).V);
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1, int _argc804, V t_810, V _a807, V _a808, V _a809, V[] _rest805) => {
Call(hearts_35, V.Undef, t_810, ((V)(2D)));
Invoke(Get(CARDS_42, "ribbit"), "yum", t_810);
return default;
}, 1, "love", true)).V).V;
meal_43 = Fn((V _self1, int _argc811, V key_817, V food_818, V f0_819, V P_820, V[] _rest812) => {
V f_821 = default;
V H_822 = default;
V t_823 = default;
V C_824 = default;
V r_825 = default;
f_821 = Object_assign(NewObj(0).V, f0_819, NewObj(1).Put("wins", Arr()).V);
H_822 = GetK(HOLD_25, Get(f_821, "hold"));
t_823 = Call(TL_9, V.Undef, NewObj(0).V, ((GetK(CARD_21, key_817) is var _t826 && !Truthy(_t826) ? _t826 : Get(GetK(CARD_21, key_817), "T")) is var _t827 && Truthy(_t827) ? _t827 : ((V)(1D))));
C_824 = Call(prims_28, V.Undef, P_820);
Call((Get(P_820, "recv") is var _t828 && Truthy(_t828) ? _t828 : recv_30), V.Undef, t_823, H_822, P_820);
if (Truthy(Get(P_820, "pre"))) {
Invoke(P_820, "pre", t_823, H_822, P_820, C_824);
}
if (Truthy(Get(f_821, "pre"))) {
Invoke(f_821, "pre", t_823, H_822);
}
InvokeK(STY_29, Get(f_821, "style"), t_823, H_822, f_821, C_824);
if (Truthy(Get(P_820, "post"))) {
Invoke(P_820, "post", t_823, P_820, C_824);
}
r_825 = Get(f_821, "react");
if ((SEqS(r_825, "yum") || SEqS(r_825, "love"))) {
InvokeK(P_820, r_825, t_823, P_820);
} else {
if (SEqS(r_825, "sour")) {
Call(sour_33, V.Undef, t_823, P_820);
} else {
if (SEqS(r_825, "freeze")) {
Call(freeze_34, V.Undef, t_823, P_820);
} else {
InvokeK(REACT_26, r_825, t_823);
}
}
}
Invoke(t_823, "rest", ((V)(450D)));
return Invoke(t_823, "done", Object_assign(NewObj(1).Put("prop", Call(foodProp_24, V.Undef, f_821, food_818)).V, (!Get(P_820, "propZ").IsNullish ? NewObj(1).Put("propZ", Get(P_820, "propZ")).V : NewObj(0).V)));
return default;
}, 4, "", true);
buildAll_44 = Fn((V _self1, int _argc829, V CARDS_835, V _a832, V _a833, V _a834, V[] _rest830) => {
V ST_836 = default;
ST_836 = NewObj(0).V;
{
foreach (V _k837 in ForInKeys(CARDS_835)) {
V key_838 = default;
key_838 = _k837;
V P_839 = default;
V D_840 = default;
P_839 = Object_assign(NewObj(1).Put("key", key_838).V, GetK(CARDS_835, key_838));
D_840 = SetK(DESC_22, key_838, (GetK(DESC_22, key_838) is var _t841 && Truthy(_t841) ? _t841 : NewObj(0).V));
Invoke(Object_keys(FOODS_23), "forEach", Fn((V _self1, int _argc842, V food_848, V _a845, V _a846, V _a847, V[] _rest843) => {
V f_849 = default;
f_849 = GetK(FOODS_23, food_848);
SetK(ST_836, ((V)(string.Concat("eat_", ToStr(food_848), "@", ToStr(key_838)))), Call(meal_43, V.Undef, key_838, food_848, f_849, P_839));
SetK(D_840, ((V)(string.Concat("eat_", ToStr(food_848)))), Arr(Get(f_849, "label"), ((V)(string.Concat(ToStr(Get(P_839, "txt")), " ", ToStr(Get(f_849, "d")))))));
return default;
}, 1, "", true));
}
}
Invoke(R_8, "add", ST_836);
return default;
}, 1, "", true);
Set(R_8, "EATKIT", NewObj(14).Put("EAR", EAR_27).Put("prims", prims_28).Put("STY", STY_29).Put("recv", recv_30).Put("sniffF", sniffF_31).Put("lipLick", lipLick_32).Put("sour", sour_33).Put("freeze", freeze_34).Put("hearts", hearts_35).Put("wagF", wagF_36).Put("para", para_37).Put("pat", pat_38).Put("meal", meal_43).Put("buildAll", buildAll_44).V);
Call(buildAll_44, V.Undef, CARDS_42);
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
