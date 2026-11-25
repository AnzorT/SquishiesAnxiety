// house-walk.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_house_walk_js
    {

        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
double TAU_8 = 0;
double PI_9 = 0;
V S_10 = default;
V C_11 = default;
V ab_12 = default;
V pos_13 = default;
V pw_14 = default;
V jmp_15 = default;
V G_16 = default;
V PROF_17 = default;
V DEF_18 = default;
V W_19 = default;
if (_self1.IsNullish) _self1 = GlobalV;
TAU_8 = (System.Math.PI * 2D);
PI_9 = System.Math.PI;
S_10 = Get(G("Math"), "sin");
C_11 = Get(G("Math"), "cos");
ab_12 = Get(G("Math"), "abs");
pos_13 = Fn((V _arrowThis27, int _argc20, V x_26, V _a23, V _a24, V _a25, V[] _rest21) => {
return (GtN(x_26, 0D) ? x_26 : ((V)(0D)));
}, 1, "", true);
pw_14 = Fn((V _arrowThis36, int _argc28, V x_34, V k_35, V _a32, V _a33, V[] _rest29) => {
return ((V)(Pow(ToNum(Call(ab_12, V.Undef, x_34)), ToNum(k_35))));
}, 2, "", true);
jmp_15 = Fn((V _arrowThis46, int _argc37, V p_43, V a_44, V b_45, V _a42, V[] _rest38) => {
double u_47 = 0;
u_47 = ((((ToNum(p_43) / TAU_8) % 1D) + 1D) % 1D);
if ((Gt(((V)(u_47)), a_44) && Lt(((V)(u_47)), b_45))) {
double au_48 = 0;
au_48 = ((u_47 - ToNum(a_44)) / (ToNum(b_45) - ToNum(a_44)));
return NewObj(3).Put("air", Call(S_10, V.Undef, ((V)((PI_9 * au_48))))).Put("au", ((V)(au_48))).Put("gb", ((V)(0D))).V;
}
return NewObj(3).Put("air", ((V)(0D))).Put("au", ((V)((-1D)))).Put("gb", Call(S_10, V.Undef, ((V)((PI_9 * ((((u_47 - ToNum(b_45)) + 1D) % 1D) / ToNum(Add(((V)((1D - ToNum(b_45)))), a_44)))))))).V;
return default;
}, 3, "", true);
G_16 = NewObj(18).Put("trot", NewObj(3).Put("r", ((V)(1D))).Put("dl", ((V)(2D))).Put("f", Fn((V _self49, int _argc50, V p_56, V A_57, V o_58, V _a55, V[] _rest51) => {
V s_59 = default;
if (_self49.IsNullish) _self49 = GlobalV;
s_59 = Call(S_10, V.Undef, p_56);
Set(o_58, "footL", ((V)(((2.6 * ToNum(A_57)) * ToNum(Call(pos_13, V.Undef, s_59))))));
Set(o_58, "footR", ((V)(((2.6 * ToNum(A_57)) * ToNum(Call(pos_13, V.Undef, ((V)((-ToNum(s_59))))))))));
Set(o_58, "armL", ((V)(((12D * ToNum(A_57)) * ToNum(s_59)))));
Set(o_58, "armR", ((V)((((-12D) * ToNum(A_57)) * ToNum(s_59)))));
Set(o_58, "tilt", ((V)(((2.2 * ToNum(A_57)) * ToNum(s_59)))));
Set(o_58, "lift", ((V)(((2.6 * ToNum(A_57)) * ToNum(Call(ab_12, V.Undef, s_59))))));
Set(o_58, "sq", ((V)((((0.035 * ToNum(A_57)) * ToNum(Call(pw_14, V.Undef, Call(C_11, V.Undef, p_56), ((V)(6D))))) - ((0.02 * ToNum(A_57)) * ToNum(Call(ab_12, V.Undef, s_59)))))));
Set(o_58, "htilt", ((V)((((-2.5) * ToNum(A_57)) * ToNum(s_59)))));
Set(o_58, "pitch", ((V)(0.04)));
Set(o_58, "wag", ((V)((12D * ToNum(Call(S_10, V.Undef, ((V)((2D * ToNum(p_56))))))))));
return default;
}, 3, "f", false)).V).Put("waddle", NewObj(3).Put("r", ((V)(0.72))).Put("dl", ((V)(1D))).Put("f", Fn((V _self60, int _argc61, V p_67, V A_68, V o_69, V _a66, V[] _rest62) => {
V s_70 = default;
if (_self60.IsNullish) _self60 = GlobalV;
s_70 = Call(S_10, V.Undef, p_67);
Set(o_69, "tilt", ((V)(((7D * ToNum(A_68)) * ToNum(s_70)))));
Set(o_69, "x", ((V)(((1.1 * ToNum(A_68)) * ToNum(s_70)))));
Set(o_69, "footL", ((V)(((1.9 * ToNum(A_68)) * ToNum(Call(pos_13, V.Undef, s_70))))));
Set(o_69, "footR", ((V)(((1.9 * ToNum(A_68)) * ToNum(Call(pos_13, V.Undef, ((V)((-ToNum(s_70))))))))));
Set(o_69, "armL", ((V)(((16D * ToNum(A_68)) + ((8D * ToNum(A_68)) * ToNum(s_70))))));
Set(o_69, "armR", ((V)(((16D * ToNum(A_68)) - ((8D * ToNum(A_68)) * ToNum(s_70))))));
Set(o_69, "lift", ((V)(((1.3 * ToNum(A_68)) * ToNum(Call(ab_12, V.Undef, s_70))))));
Set(o_69, "htilt", ((V)((((-4D) * ToNum(A_68)) * ToNum(s_70)))));
Set(o_69, "sq", ((V)(((0.03 * ToNum(A_68)) * ToNum(Call(pw_14, V.Undef, Call(C_11, V.Undef, p_67), ((V)(6D))))))));
return NewObj(1).Put("v", ((V)((0.8 + (0.4 * ToNum(Call(ab_12, V.Undef, s_70))))))).V;
return default;
}, 3, "f", false)).V).Put("hop", NewObj(3).Put("r", ((V)(0.6))).Put("dl", ((V)(2D))).Put("f", Fn((V _self71, int _argc72, V p_78, V A_79, V o_80, V _a77, V[] _rest73) => {
V j_81 = default;
if (_self71.IsNullish) _self71 = GlobalV;
j_81 = Call(jmp_15, V.Undef, p_78, ((V)(0.2)), ((V)(0.8)));
Set(o_80, "lift", ((V)(((14D * ToNum(A_79)) * ToNum(Get(j_81, "air"))))));
Set(o_80, "sq", ((V)((((0.12 * ToNum(A_79)) * ToNum(Get(j_81, "gb"))) - ((0.07 * ToNum(A_79)) * ToNum(Get(j_81, "air")))))));
Set(o_80, "footL", Set(o_80, "footR", ((V)(((2D * ToNum(A_79)) * ToNum(Get(j_81, "air")))))));
Set(o_80, "armL", Set(o_80, "armR", ((V)(((20D * ToNum(A_79)) * ToNum(Get(j_81, "air")))))));
Set(o_80, "pitch", ((V)((GeN(Get(j_81, "au"), 0D) ? ((-0.05) * ToNum(Call(C_11, V.Undef, ((V)((PI_9 * ToNum(Get(j_81, "au")))))))) : (0.03 * ToNum(Get(j_81, "gb")))))));
return NewObj(2).Put("v", ((V)((GeN(Get(j_81, "au"), 0D) ? 1.5 : 0.18)))).Put("land", Get(j_81, "gb")).V;
return default;
}, 3, "f", false)).V).Put("bounce", NewObj(3).Put("r", ((V)(0.7))).Put("dl", ((V)(1.5))).Put("f", Fn((V _self82, int _argc83, V p_89, V A_90, V o_91, V _a88, V[] _rest84) => {
V j_92 = default;
if (_self82.IsNullish) _self82 = GlobalV;
j_92 = Call(jmp_15, V.Undef, p_89, ((V)(0.22)), ((V)(0.78)));
Set(o_91, "lift", ((V)(((12D * ToNum(A_90)) * ToNum(Get(j_92, "air"))))));
Set(o_91, "sq", ((V)((((0.2 * ToNum(A_90)) * ToNum(Get(j_92, "gb"))) - ((0.09 * ToNum(A_90)) * ToNum(Get(j_92, "air")))))));
Set(o_91, "armL", Set(o_91, "armR", ((V)(((18D * ToNum(A_90)) * ToNum(Get(j_92, "air")))))));
Set(o_91, "tilt", ((V)(((3D * ToNum(A_90)) * ToNum(Call(S_10, V.Undef, ((V)((2D * ToNum(p_89))))))))));
Set(o_91, "htilt", ((V)(((2D * ToNum(A_90)) * ToNum(Call(S_10, V.Undef, ((V)(((2D * ToNum(p_89)) + 1D)))))))));
return NewObj(2).Put("v", ((V)((GeN(Get(j_92, "au"), 0D) ? 1.5 : 0.22)))).Put("land", Get(j_92, "gb")).V;
return default;
}, 3, "f", false)).V).Put("float", NewObj(3).Put("r", ((V)(0.42))).Put("dl", ((V)(4D))).Put("f", Fn((V _self93, int _argc94, V p_100, V A_101, V o_102, V _a99, V[] _rest95) => {
V s_103 = default;
if (_self93.IsNullish) _self93 = GlobalV;
s_103 = Call(S_10, V.Undef, p_100);
Set(o_102, "lift", ((V)((3D + ((2.5 * ToNum(A_101)) * ToNum(s_103))))));
Set(o_102, "x", ((V)(((0.8 * ToNum(A_101)) * ToNum(Call(S_10, V.Undef, Add(p_100, ((V)(0.8)))))))));
Set(o_102, "tilt", ((V)(((2.5 * ToNum(A_101)) * ToNum(Call(S_10, V.Undef, Add(p_100, ((V)(0.8)))))))));
Set(o_102, "armL", ((V)((6D + ((7D * ToNum(A_101)) * ToNum(Call(S_10, V.Undef, ((V)((2D * ToNum(p_100)))))))))));
Set(o_102, "armR", ((V)((6D + ((7D * ToNum(A_101)) * ToNum(Call(S_10, V.Undef, ((V)(((2D * ToNum(p_100)) + PI_9))))))))));
Set(o_102, "pitch", ((V)(0.06)));
Set(o_102, "sq", ((V)(((0.025 * ToNum(A_101)) * ToNum(Call(S_10, V.Undef, ((V)((2D * ToNum(p_100))))))))));
return default;
}, 3, "f", false)).V).Put("flutter", NewObj(3).Put("r", ((V)(0.55))).Put("dl", ((V)(5D))).Put("f", Fn((V _self104, int _argc105, V p_111, V A_112, V o_113, V P_114, V[] _rest106) => {
V s_115 = default;
if (_self104.IsNullish) _self104 = GlobalV;
s_115 = Call(S_10, V.Undef, p_111);
Set(o_113, "lift", ((V)((ToNum(A_112) * (9D + (3D * ToNum(Call(S_10, V.Undef, ((V)((2D * ToNum(p_111))))))))))));
Set(o_113, "tilt", ((V)(((2D * ToNum(A_112)) * ToNum(s_115)))));
Set(o_113, "pitch", ((V)(0.07)));
Set(o_113, "footL", Set(o_113, "footR", ((V)(0.8))));
if (SEqS(Get(P_114, "wing"), "own")) {
Set(o_113, "armL", ((V)((8D + (5D * ToNum(Call(S_10, V.Undef, ((V)((2D * ToNum(p_111)))))))))));
Set(o_113, "armR", ((V)((8D + (5D * ToNum(Call(S_10, V.Undef, ((V)(((2D * ToNum(p_111)) + PI_9))))))))));
} else {
Set(o_113, "armL", Set(o_113, "armR", ((V)((34D + (30D * ToNum(Call(S_10, V.Undef, ((V)((6D * ToNum(p_111))))))))))));
}
Set(o_113, "sq", ((V)(((-0.03) * ToNum(Call(S_10, V.Undef, ((V)((6D * ToNum(p_111))))))))));
return default;
}, 4, "f", false)).V).Put("galumph", NewObj(3).Put("r", ((V)(0.55))).Put("dl", ((V)(1.5))).Put("f", Fn((V _self116, int _argc117, V p_123, V A_124, V o_125, V _a122, V[] _rest118) => {
V j_126 = default;
if (_self116.IsNullish) _self116 = GlobalV;
j_126 = Call(jmp_15, V.Undef, p_123, ((V)(0.3)), ((V)(0.75)));
Set(o_125, "lift", ((V)(((6D * ToNum(A_124)) * ToNum(Get(j_126, "air"))))));
Set(o_125, "sq", ((V)((((0.14 * ToNum(A_124)) * ToNum(Get(j_126, "gb"))) - ((0.04 * ToNum(A_124)) * ToNum(Get(j_126, "air")))))));
Set(o_125, "pitch", ((V)(((0.06 * ToNum(Get(j_126, "gb"))) - (0.08 * ToNum(Get(j_126, "air")))))));
Set(o_125, "armL", Set(o_125, "armR", ((V)((8D + ((16D * ToNum(A_124)) * ToNum(Get(j_126, "air"))))))));
Set(o_125, "wag", ((V)(((18D * ToNum(A_124)) * ToNum(Call(S_10, V.Undef, Add(p_123, ((V)(1.2)))))))));
return NewObj(2).Put("v", ((V)((0.4 + (1.3 * ToNum(Get(j_126, "air"))))))).Put("land", Get(j_126, "gb")).V;
return default;
}, 3, "f", false)).V).Put("shuffle", NewObj(3).Put("r", ((V)(1.35))).Put("dl", ((V)(1D))).Put("f", Fn((V _self127, int _argc128, V p_134, V A_135, V o_136, V _a133, V[] _rest129) => {
V s_137 = default;
if (_self127.IsNullish) _self127 = GlobalV;
s_137 = Call(S_10, V.Undef, p_134);
Set(o_136, "tilt", ((V)(((4.5 * ToNum(A_135)) * ToNum(s_137)))));
Set(o_136, "footL", ((V)(((1.4 * ToNum(A_135)) * ToNum(Call(pos_13, V.Undef, s_137))))));
Set(o_136, "footR", ((V)(((1.4 * ToNum(A_135)) * ToNum(Call(pos_13, V.Undef, ((V)((-ToNum(s_137))))))))));
Set(o_136, "lift", ((V)(((1.2 * ToNum(A_135)) * ToNum(Call(ab_12, V.Undef, s_137))))));
Set(o_136, "armL", ((V)(((7D * ToNum(A_135)) * ToNum(s_137)))));
Set(o_136, "armR", ((V)((((-7D) * ToNum(A_135)) * ToNum(s_137)))));
Set(o_136, "htilt", ((V)((((-2D) * ToNum(A_135)) * ToNum(s_137)))));
Set(o_136, "sq", ((V)(((0.02 * ToNum(A_135)) * ToNum(Call(pw_14, V.Undef, Call(C_11, V.Undef, p_134), ((V)(4D))))))));
return default;
}, 3, "f", false)).V).Put("stomp", NewObj(3).Put("r", ((V)(0.62))).Put("dl", ((V)(1D))).Put("f", Fn((V _self138, int _argc139, V p_145, V A_146, V o_147, V _a144, V[] _rest140) => {
V s_148 = default;
V c_149 = default;
if (_self138.IsNullish) _self138 = GlobalV;
s_148 = Call(S_10, V.Undef, p_145);
c_149 = Call(pw_14, V.Undef, Call(C_11, V.Undef, p_145), ((V)(8D)));
Set(o_147, "footL", ((V)(((3.4 * ToNum(A_146)) * ToNum(Call(pos_13, V.Undef, s_148))))));
Set(o_147, "footR", ((V)(((3.4 * ToNum(A_146)) * ToNum(Call(pos_13, V.Undef, ((V)((-ToNum(s_148))))))))));
Set(o_147, "tilt", ((V)(((4D * ToNum(A_146)) * ToNum(s_148)))));
Set(o_147, "lift", ((V)(((2.6 * ToNum(A_146)) * ToNum(Call(ab_12, V.Undef, s_148))))));
Set(o_147, "sq", ((V)(((0.07 * ToNum(A_146)) * ToNum(c_149)))));
Set(o_147, "armL", ((V)(((16D * ToNum(A_146)) * ToNum(s_148)))));
Set(o_147, "armR", ((V)((((-16D) * ToNum(A_146)) * ToNum(s_148)))));
Set(o_147, "htilt", ((V)((((-3D) * ToNum(A_146)) * ToNum(s_148)))));
Set(o_147, "pitch", ((V)(0.03)));
return NewObj(1).Put("land", c_149).V;
return default;
}, 3, "f", false)).V).Put("prance", NewObj(3).Put("r", ((V)(0.9))).Put("dl", ((V)(1.5))).Put("f", Fn((V _self150, int _argc151, V p_157, V A_158, V o_159, V _a156, V[] _rest152) => {
V s_160 = default;
V k_161 = default;
if (_self150.IsNullish) _self150 = GlobalV;
s_160 = Call(S_10, V.Undef, p_157);
k_161 = Call(pw_14, V.Undef, s_160, ((V)(0.7)));
Set(o_159, "footL", ((V)(((3.4 * ToNum(A_158)) * Pow(ToNum(Call(pos_13, V.Undef, s_160)), 0.7)))));
Set(o_159, "footR", ((V)(((3.4 * ToNum(A_158)) * Pow(ToNum(Call(pos_13, V.Undef, ((V)((-ToNum(s_160)))))), 0.7)))));
Set(o_159, "lift", ((V)(((3.6 * ToNum(A_158)) * ToNum(k_161)))));
Set(o_159, "armL", ((V)(((20D * ToNum(A_158)) + ((5D * ToNum(A_158)) * ToNum(s_160))))));
Set(o_159, "armR", ((V)(((20D * ToNum(A_158)) - ((5D * ToNum(A_158)) * ToNum(s_160))))));
Set(o_159, "pitch", ((V)((-0.05))));
Set(o_159, "htilt", ((V)(((3D * ToNum(A_158)) * ToNum(Call(S_10, V.Undef, ((V)((2D * ToNum(p_157))))))))));
Set(o_159, "tilt", ((V)(((1.5 * ToNum(A_158)) * ToNum(s_160)))));
Set(o_159, "sq", ((V)((((0.02 * ToNum(A_158)) * ToNum(Call(pw_14, V.Undef, Call(C_11, V.Undef, p_157), ((V)(6D))))) - ((0.03 * ToNum(A_158)) * ToNum(k_161))))));
return default;
}, 3, "f", false)).V).Put("skip", NewObj(3).Put("r", ((V)(0.8))).Put("dl", ((V)(2D))).Put("f", Fn((V _self162, int _argc163, V p_169, V A_170, V o_171, V _a168, V[] _rest164) => {
V s_172 = default;
V k_173 = default;
if (_self162.IsNullish) _self162 = GlobalV;
s_172 = Call(S_10, V.Undef, p_169);
k_173 = Call(pw_14, V.Undef, s_172, ((V)(0.6)));
Set(o_171, "lift", ((V)(((6D * ToNum(A_170)) * ToNum(k_173)))));
Set(o_171, "footL", ((V)(((3D * ToNum(A_170)) * ToNum(Call(pos_13, V.Undef, s_172))))));
Set(o_171, "footR", ((V)(((3D * ToNum(A_170)) * ToNum(Call(pos_13, V.Undef, ((V)((-ToNum(s_172))))))))));
Set(o_171, "armL", ((V)(((24D * ToNum(A_170)) * ToNum(s_172)))));
Set(o_171, "armR", ((V)((((-24D) * ToNum(A_170)) * ToNum(s_172)))));
Set(o_171, "tilt", ((V)(((3D * ToNum(A_170)) * ToNum(s_172)))));
Set(o_171, "sq", ((V)((((0.06 * ToNum(A_170)) * ToNum(Call(pw_14, V.Undef, Call(C_11, V.Undef, p_169), ((V)(8D))))) - ((0.04 * ToNum(A_170)) * ToNum(k_173))))));
Set(o_171, "htilt", ((V)(((3D * ToNum(A_170)) * ToNum(s_172)))));
return default;
}, 3, "f", false)).V).Put("scurry", NewObj(3).Put("r", ((V)(1.9))).Put("dl", ((V)(2.5))).Put("f", Fn((V _self174, int _argc175, V p_181, V A_182, V o_183, V _a180, V[] _rest176) => {
V s_184 = default;
if (_self174.IsNullish) _self174 = GlobalV;
s_184 = Call(S_10, V.Undef, p_181);
Set(o_183, "footL", ((V)(((1.3 * ToNum(A_182)) * ToNum(Call(pos_13, V.Undef, s_184))))));
Set(o_183, "footR", ((V)(((1.3 * ToNum(A_182)) * ToNum(Call(pos_13, V.Undef, ((V)((-ToNum(s_184))))))))));
Set(o_183, "lift", ((V)(((1.1 * ToNum(A_182)) * ToNum(Call(ab_12, V.Undef, s_184))))));
Set(o_183, "tilt", ((V)(((1.5 * ToNum(A_182)) * ToNum(s_184)))));
Set(o_183, "armL", ((V)((6D + ((4D * ToNum(A_182)) * ToNum(s_184))))));
Set(o_183, "armR", ((V)((6D - ((4D * ToNum(A_182)) * ToNum(s_184))))));
Set(o_183, "pitch", ((V)(0.06)));
Set(o_183, "sq", ((V)(0.03)));
return NewObj(1).Put("v", ((V)(1.1))).V;
return default;
}, 3, "f", false)).V).Put("plod", NewObj(3).Put("r", ((V)(0.45))).Put("dl", ((V)(0.5))).Put("f", Fn((V _self185, int _argc186, V p_192, V A_193, V o_194, V _a191, V[] _rest187) => {
V s_195 = default;
if (_self185.IsNullish) _self185 = GlobalV;
s_195 = Call(S_10, V.Undef, p_192);
Set(o_194, "footL", ((V)(((1.7 * ToNum(A_193)) * ToNum(Call(pos_13, V.Undef, s_195))))));
Set(o_194, "footR", ((V)(((1.7 * ToNum(A_193)) * ToNum(Call(pos_13, V.Undef, ((V)((-ToNum(s_195))))))))));
Set(o_194, "armL", ((V)(((8D * ToNum(A_193)) * (-ToNum(s_195))))));
Set(o_194, "armR", ((V)(((8D * ToNum(A_193)) * ToNum(s_195)))));
Set(o_194, "tilt", ((V)(((2.5 * ToNum(A_193)) * ToNum(s_195)))));
Set(o_194, "lift", ((V)(((0.8 * ToNum(A_193)) * ToNum(Call(ab_12, V.Undef, s_195))))));
Set(o_194, "pitch", ((V)(0.03)));
return NewObj(1).Put("v", ((V)(0.75))).V;
return default;
}, 3, "f", false)).V).Put("crawl", NewObj(3).Put("r", ((V)(0.6))).Put("dl", ((V)(1.5))).Put("f", Fn((V _self196, int _argc197, V p_203, V A_204, V o_205, V _a202, V[] _rest198) => {
V s_206 = default;
if (_self196.IsNullish) _self196 = GlobalV;
s_206 = Call(S_10, V.Undef, p_203);
Set(o_205, "lift", ((V)(((2D * ToNum(A_204)) * ToNum(Call(ab_12, V.Undef, s_206))))));
Set(o_205, "tilt", ((V)(((2.2 * ToNum(A_204)) * ToNum(s_206)))));
Set(o_205, "x", ((V)(((0.6 * ToNum(A_204)) * ToNum(s_206)))));
Set(o_205, "sq", ((V)(((0.04 * ToNum(A_204)) * ToNum(Call(S_10, V.Undef, ((V)((2D * ToNum(p_203))))))))));
Set(o_205, "armL", ((V)((10D + ((12D * ToNum(A_204)) * ToNum(s_206))))));
Set(o_205, "armR", ((V)((10D - ((12D * ToNum(A_204)) * ToNum(s_206))))));
Set(o_205, "footL", ((V)(((1.2 * ToNum(A_204)) * ToNum(Call(pos_13, V.Undef, s_206))))));
Set(o_205, "footR", ((V)(((1.2 * ToNum(A_204)) * ToNum(Call(pos_13, V.Undef, ((V)((-ToNum(s_206))))))))));
return default;
}, 3, "f", false)).V).Put("zombie", NewObj(3).Put("r", ((V)(0.5))).Put("dl", ((V)(0.5))).Put("f", Fn((V _self207, int _argc208, V p_214, V A_215, V o_216, V _a213, V[] _rest209) => {
V s_217 = default;
if (_self207.IsNullish) _self207 = GlobalV;
s_217 = Call(S_10, V.Undef, p_214);
Set(o_216, "armL", ((V)((84D + (4D * ToNum(Call(S_10, V.Undef, ((V)((2D * ToNum(p_214)))))))))));
Set(o_216, "armR", ((V)((84D + (4D * ToNum(Call(S_10, V.Undef, ((V)(((2D * ToNum(p_214)) + 1D))))))))));
Set(o_216, "htilt", ((V)(((7D * ToNum(A_215)) * ToNum(s_217)))));
Set(o_216, "tilt", ((V)(((5D * ToNum(A_215)) * ToNum(s_217)))));
Set(o_216, "footL", ((V)(((1.1 * ToNum(A_215)) * ToNum(Call(pos_13, V.Undef, s_217))))));
Set(o_216, "footR", ((V)(((1.1 * ToNum(A_215)) * ToNum(Call(pos_13, V.Undef, ((V)((-ToNum(s_217))))))))));
Set(o_216, "lift", ((V)(((0.6 * ToNum(A_215)) * ToNum(Call(ab_12, V.Undef, s_217))))));
Set(o_216, "x", ((V)(((0.6 * ToNum(A_215)) * ToNum(s_217)))));
return NewObj(1).Put("v", ((V)(0.7))).V;
return default;
}, 3, "f", false)).V).Put("glide", NewObj(3).Put("r", ((V)(0.4))).Put("dl", ((V)(5D))).Put("f", Fn((V _self218, int _argc219, V p_225, V A_226, V o_227, V _a224, V[] _rest220) => {
V s_228 = default;
if (_self218.IsNullish) _self218 = GlobalV;
s_228 = Call(S_10, V.Undef, p_225);
Set(o_227, "lift", ((V)((3D + ((1.5 * ToNum(A_226)) * ToNum(s_228))))));
Set(o_227, "pitch", ((V)(0.05)));
Set(o_227, "armL", ((V)((10D + (4D * ToNum(Call(S_10, V.Undef, Add(p_225, ((V)(1D))))))))));
Set(o_227, "armR", ((V)((10D + (4D * ToNum(Call(S_10, V.Undef, Add(Add(p_225, ((V)(1D))), ((V)(PI_9))))))))));
Set(o_227, "tilt", ((V)(((1.5 * ToNum(A_226)) * ToNum(Call(S_10, V.Undef, Add(p_225, ((V)(0.6)))))))));
Set(o_227, "sq", ((V)(((0.02 * ToNum(A_226)) * ToNum(Call(S_10, V.Undef, ((V)((2D * ToNum(p_225))))))))));
return default;
}, 3, "f", false)).V).Put("roll", NewObj(3).Put("r", ((V)(0.9))).Put("dl", ((V)(1D))).Put("f", Fn((V _self229, int _argc230, V p_236, V A_237, V o_238, V _a235, V[] _rest231) => {
V s_239 = default;
if (_self229.IsNullish) _self229 = GlobalV;
s_239 = Call(S_10, V.Undef, p_236);
Set(o_238, "tilt", ((V)(((8D * ToNum(A_237)) * ToNum(s_239)))));
Set(o_238, "turn", ((V)(((0.18 * ToNum(A_237)) * ToNum(s_239)))));
Set(o_238, "lift", ((V)(((1.5 * ToNum(A_237)) * ToNum(Call(ab_12, V.Undef, s_239))))));
Set(o_238, "sq", ((V)(((0.03 * ToNum(A_237)) * ToNum(Call(pw_14, V.Undef, Call(C_11, V.Undef, p_236), ((V)(4D))))))));
Set(o_238, "armL", ((V)(((10D * ToNum(A_237)) * ToNum(s_239)))));
Set(o_238, "armR", ((V)((((-10D) * ToNum(A_237)) * ToNum(s_239)))));
Set(o_238, "x", ((V)(((0.8 * ToNum(A_237)) * ToNum(s_239)))));
return default;
}, 3, "f", false)).V).Put("strut", NewObj(3).Put("r", ((V)(0.85))).Put("dl", ((V)(1D))).Put("f", Fn((V _self240, int _argc241, V p_247, V A_248, V o_249, V _a246, V[] _rest242) => {
V s_250 = default;
if (_self240.IsNullish) _self240 = GlobalV;
s_250 = Call(S_10, V.Undef, p_247);
Set(o_249, "footL", ((V)(((2.6 * ToNum(A_248)) * ToNum(Call(pos_13, V.Undef, s_250))))));
Set(o_249, "footR", ((V)(((2.6 * ToNum(A_248)) * ToNum(Call(pos_13, V.Undef, ((V)((-ToNum(s_250))))))))));
Set(o_249, "lift", ((V)(((1.6 * ToNum(A_248)) * ToNum(Call(ab_12, V.Undef, s_250))))));
Set(o_249, "tilt", ((V)(((2D * ToNum(A_248)) * ToNum(s_250)))));
Set(o_249, "pitch", ((V)((0.02 + ((0.1 * ToNum(A_248)) * ToNum(Call(pos_13, V.Undef, Call(S_10, V.Undef, ((V)((2D * ToNum(p_247))))))))))));
Set(o_249, "armL", ((V)((10D + ((6D * ToNum(A_248)) * ToNum(Call(S_10, V.Undef, ((V)((2D * ToNum(p_247)))))))))));
Set(o_249, "armR", ((V)((10D + ((6D * ToNum(A_248)) * ToNum(Call(S_10, V.Undef, ((V)((2D * ToNum(p_247)))))))))));
Set(o_249, "sq", ((V)(((0.03 * ToNum(A_248)) * ToNum(Call(pw_14, V.Undef, Call(C_11, V.Undef, p_247), ((V)(6D))))))));
return default;
}, 3, "f", false)).V).V;
PROF_17 = NewObj(0).V;
DEF_18 = NewObj(1).Put("g", ((V)("trot"))).V;
W_19 = Set(G("window"), "HouseWalk", NewObj(7).Put("G", G_16).Put("PROF", PROF_17).Put("DLS", ((V)(1D))).Put("def", Fn((V _self251, int _argc252, V key_258, V P_259, V _a256, V _a257, V[] _rest253) => {
if (_self251.IsNullish) _self251 = GlobalV;
SetK(PROF_17, key_258, P_259);
return default;
}, 2, "def", false)).Put("prof", Fn((V _self260, int _argc261, V key_267, V _a264, V _a265, V _a266, V[] _rest262) => {
V P0_268 = default;
if (_self260.IsNullish) _self260 = GlobalV;
key_267 = ((Get(G("window"), "SQ_ALIAS") is var _t269 && !Truthy(_t269) ? _t269 : GetK(Get(G("window"), "SQ_ALIAS"), key_267)) is var _t270 && Truthy(_t270) ? _t270 : key_267);
P0_268 = (GetK(PROF_17, key_267) is var _t271 && Truthy(_t271) ? _t271 : DEF_18);
return (Truthy(Get(G("window"), "SquishConfig")) ? Invoke(Get(G("window"), "SquishConfig"), "walkProfile", key_267, P0_268) : P0_268);
return default;
}, 1, "prof", false)).Put("period", Fn((V _self272, int _argc273, V key_279, V _a276, V _a277, V _a278, V[] _rest274) => {
V P_280 = default;
V g_281 = default;
if (_self272.IsNullish) _self272 = GlobalV;
P_280 = Invoke(W_19, "prof", key_279);
g_281 = (GetK(G_16, Get(P_280, "g")) is var _t282 && Truthy(_t282) ? _t282 : Get(G_16, "trot"));
return ((V)(((1000D * TAU_8) / ((11D * ToNum(Get(g_281, "r"))) * ToNum((Get(P_280, "r") is var _t283 && Truthy(_t283) ? _t283 : ((V)(1D))))))));
return default;
}, 1, "period", false)).Put("step", Fn((V _self284, int _argc285, V key_291, V st_292, V E_293, V w_294, V[] _rest286) => {
V rk_298 = default;
V P_299 = default;
V g_300 = default;
double A_301 = 0;
V p_302 = default;
V o_303 = default;
V m_304 = default;
double sr_305 = 0;
double sd_306 = 0;
V fx_307 = default;
V now_308 = default;
V dt_295 = default;
V spd_296 = default;
V spin_297 = default;
if (_self284.IsNullish) _self284 = GlobalV;
dt_295 = (_argc285 > 4 ? _rest286[0] : V.Undef);
spd_296 = (_argc285 > 5 ? _rest286[1] : V.Undef);
spin_297 = (_argc285 > 6 ? _rest286[2] : V.Undef);
key_291 = ((Get(G("window"), "SQ_ALIAS") is var _t309 && !Truthy(_t309) ? _t309 : GetK(Get(G("window"), "SQ_ALIAS"), key_291)) is var _t310 && Truthy(_t310) ? _t310 : key_291);
rk_298 = Set(st_292, "rk", Add((Get(st_292, "rk") is var _t311 && Truthy(_t311) ? _t311 : ((V)(0D))), ((V)((((Truthy(Get(st_292, "run")) ? 1D : 0D) - ToNum((Get(st_292, "rk") is var _t312 && Truthy(_t312) ? _t312 : ((V)(0D))))) * Min(1D, (ToNum(dt_295) * 6D)))))));
P_299 = Invoke(W_19, "prof", key_291);
g_300 = (GetK(G_16, Get(P_299, "g")) is var _t313 && Truthy(_t313) ? _t313 : Get(G_16, "trot"));
A_301 = (ToNum((Get(P_299, "a") is var _t314 && Truthy(_t314) ? _t314 : ((V)(1D)))) * (1D + (0.28 * ToNum(rk_298))));
Set(st_292, "ph", Add((Get(st_292, "ph") is var _t315 && Truthy(_t315) ? _t315 : ((V)(0D))), ((V)((((((ToNum(dt_295) * 11D) * ToNum(Get(g_300, "r"))) * ToNum((Get(P_299, "r") is var _t316 && Truthy(_t316) ? _t316 : ((V)(1D))))) * ToNum((spd_296 is var _t317 && Truthy(_t317) ? _t317 : ((V)(0D))))) * (1D + (0.6 * ToNum(rk_298))))))));
if (LtN(w_294, 0.002)) {
return NewObj(2).Put("v", ((V)(1D))).Put("fx", V.Null).V;
}
p_302 = Get(st_292, "ph");
o_303 = NewObj(0).V;
m_304 = (Invoke(g_300, "f", p_302, ((V)(A_301)), o_303, P_299) is var _t318 && Truthy(_t318) ? _t318 : NewObj(0).V);
sr_305 = ((ToNum((spin_297 is var _t319 && Truthy(_t319) ? _t319 : ((V)(0D)))) * PI_9) / 180D);
sd_306 = (0.45 + (0.55 * ToNum(Call(ab_12, V.Undef, Call(C_11, V.Undef, ((V)(sr_305)))))));
if (Truthy(Get(o_303, "tilt"))) {
OpSet(o_303, "tilt", 2, ((V)(sd_306)));
}
if (Truthy(Get(o_303, "x"))) {
OpSet(o_303, "x", 2, ((V)(sd_306)));
}
Set(o_303, "tilt", Add((Get(o_303, "tilt") is var _t320 && Truthy(_t320) ? _t320 : ((V)(0D))), ((V)(((ToNum(Get(W_19, "DLS")) * ToNum((!Get(P_299, "dl").IsNullish ? Get(P_299, "dl") : Get(g_300, "dl")))) * ToNum(Call(S_10, V.Undef, ((V)(sr_305)))))))));
if (Truthy(Get(P_299, "x"))) {
{
foreach (V _k321 in ForInKeys(Get(P_299, "x"))) {
V k_322 = default;
k_322 = _k321;
V q_323 = default;
V v_324 = default;
q_323 = GetK(Get(P_299, "x"), k_322);
v_324 = Call(S_10, V.Undef, Add(((V)((ToNum((GetIdx(q_323, 1D) is var _t325 && Truthy(_t325) ? _t325 : ((V)(1D)))) * ToNum(p_302)))), (GetIdx(q_323, 2D) is var _t326 && Truthy(_t326) ? _t326 : ((V)(0D)))));
SetK(o_303, k_322, Add((GetK(o_303, k_322) is var _t327 && Truthy(_t327) ? _t327 : ((V)(0D))), ((V)((ToNum(GetIdx(q_323, 0D)) * ToNum((Truthy(GetIdx(q_323, 3D)) ? Call(ab_12, V.Undef, v_324) : v_324)))))));
}
}
}
if (Truthy(Get(P_299, "c"))) {
{
foreach (V _k328 in ForInKeys(Get(P_299, "c"))) {
V k_329 = default;
k_329 = _k328;
SetK(o_303, k_329, Add((GetK(o_303, k_329) is var _t330 && Truthy(_t330) ? _t330 : ((V)(0D))), GetK(Get(P_299, "c"), k_329)));
}
}
}
if (Truthy(Get(P_299, "m"))) {
{
foreach (V _k331 in ForInKeys(Get(P_299, "m"))) {
V k_332 = default;
k_332 = _k331;
if (!GetK(o_303, k_332).IsNullish) {
OpSetK(o_303, k_332, 2, GetK(Get(P_299, "m"), k_332));
}
}
}
}
if (GtN(rk_298, 0.01)) {
V RX_333 = default;
V add_334 = default;
RX_333 = (GetK((Get(G("window"), "HouseWalkRUN") is var _t335 && Truthy(_t335) ? _t335 : NewObj(0).V), key_291) is var _t336 && Truthy(_t336) ? _t336 : NewObj(0).V);
add_334 = Fn((V _arrowThis345, int _argc337, V k_343, V v_344, V _a341, V _a342, V[] _rest338) => {
SetK(o_303, k_343, Add((GetK(o_303, k_343) is var _t346 && Truthy(_t346) ? _t346 : ((V)(0D))), ((V)((ToNum(v_344) * ToNum(rk_298))))));
return default;
}, 2, "", true);
Call(add_334, V.Undef, ((V)("tilt")), ((V)(((3.5 * ToNum(Get(W_19, "DLS"))) * ToNum(Call(S_10, V.Undef, ((V)(sr_305))))))));
Call(add_334, V.Undef, ((V)("pitch")), ((V)((-0.06))));
Call(add_334, V.Undef, ((V)("open")), ((V)(0.32)));
Call(add_334, V.Undef, ((V)("mw")), ((V)((-0.25))));
Call(add_334, V.Undef, ((V)("hap")), ((V)(0.7)));
Call(add_334, V.Undef, ((V)("smile")), ((V)(0.3)));
Call(add_334, V.Undef, ((V)("wide")), ((V)(0.25)));
Call(add_334, V.Undef, ((V)("earL")), ((V)(10D)));
Call(add_334, V.Undef, ((V)("earR")), ((V)((-10D))));
{
foreach (V _k347 in ForInKeys(RX_333)) {
V k_348 = default;
k_348 = _k347;
Call(add_334, V.Undef, k_348, GetK(RX_333, k_348));
}
}
}
{
foreach (V _k349 in ForInKeys(o_303)) {
V k_350 = default;
k_350 = _k349;
SetK(E_293, k_350, Add((GetK(E_293, k_350) is var _t351 && Truthy(_t351) ? _t351 : ((V)(0D))), ((V)((ToNum(GetK(o_303, k_350)) * ToNum(w_294))))));
}
}
fx_307 = V.Null;
now_308 = Set(st_292, "t", Add((Get(st_292, "t") is var _t352 && Truthy(_t352) ? _t352 : ((V)(0D))), ((V)((ToNum(dt_295) * 1000D)))));
if (Truthy(((GtN(w_294, 0.6) ? V.True : V.False) is var _t353 && !Truthy(_t353) ? _t353 : spd_296))) {
if (Truthy((Get(P_299, "fx") is var _t355 && !Truthy(_t355) ? _t355 : (Gt(now_308, (Get(st_292, "fxAt") is var _t354 && Truthy(_t354) ? _t354 : ((V)(0D)))) ? V.True : V.False)))) {
Set(st_292, "fxAt", Add(now_308, ((V)((ToNum(GetIdx(Get(P_299, "fx"), 1D)) * (0.7 + (ToNum(Invoke(G("Math"), "random")) * 0.6)))))));
fx_307 = GetIdx(Get(P_299, "fx"), 0D);
}
if (Truthy((Get(P_299, "dust") is var _t356 && !Truthy(_t356) ? _t356 : (!Get(m_304, "land").IsNullish ? V.True : V.False)))) {
V ld_357 = default;
ld_357 = (GtN(Get(m_304, "land"), 0.9) ? V.True : V.False);
if (Truthy((ld_357 is var _t358 && !Truthy(_t358) ? _t358 : (!(Truthy(Get(st_292, "ld"))) ? V.True : V.False)))) {
fx_307 = Get(P_299, "dust");
}
Set(st_292, "ld", ld_357);
}
if (((GtN(rk_298, 0.5) && !(Truthy(fx_307))) && Gt(now_308, (Get(st_292, "ruAt") is var _t359 && Truthy(_t359) ? _t359 : ((V)(0D)))))) {
Set(st_292, "ruAt", Add(now_308, ((V)(260D))));
fx_307 = (Get(P_299, "dust") is var _t360 && Truthy(_t360) ? _t360 : V.Null);
}
}
return NewObj(2).Put("v", (Get(m_304, "v") is var _t361 && Truthy(_t361) ? _t361 : ((V)(1D)))).Put("fx", fx_307).V;
return default;
}, 7, "step", false)).V);
Invoke((Get(G("window"), "HouseWalkC") is var _t370 && Truthy(_t370) ? _t370 : Arr()), "forEach", Fn((V _arrowThis369, int _argc362, V f_368, V _a365, V _a366, V _a367, V[] _rest363) => {
return Call(f_368, V.Undef, W_19);
}, 1, "", true));
return default;
}, 0, "", false), V.Undef);
        }
    }
}
