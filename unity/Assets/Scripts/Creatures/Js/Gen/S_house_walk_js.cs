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
pos_13 = Fn((V _self1, int _argc20, V x_26, V _a23, V _a24, V _a25, V[] _rest21) => {
return (GtN(x_26, 0D) ? x_26 : ((V)(0D)));
}, 1, "", true);
pw_14 = Fn((V _self1, int _argc27, V x_33, V k_34, V _a31, V _a32, V[] _rest28) => {
return ((V)(Pow(ToNum(Call(ab_12, V.Undef, x_33)), ToNum(k_34))));
}, 2, "", true);
jmp_15 = Fn((V _self1, int _argc35, V p_41, V a_42, V b_43, V _a40, V[] _rest36) => {
double u_44 = 0;
u_44 = ((((ToNum(p_41) / TAU_8) % 1D) + 1D) % 1D);
if ((Gt(((V)(u_44)), a_42) && Lt(((V)(u_44)), b_43))) {
double au_45 = 0;
au_45 = ((u_44 - ToNum(a_42)) / (ToNum(b_43) - ToNum(a_42)));
return NewObj(3).Put("air", Call(S_10, V.Undef, ((V)((PI_9 * au_45))))).Put("au", ((V)(au_45))).Put("gb", ((V)(0D))).V;
}
return NewObj(3).Put("air", ((V)(0D))).Put("au", ((V)((-1D)))).Put("gb", Call(S_10, V.Undef, ((V)((PI_9 * ((((u_44 - ToNum(b_43)) + 1D) % 1D) / ToNum(Add(((V)((1D - ToNum(b_43)))), a_42)))))))).V;
return default;
}, 3, "", true);
G_16 = NewObj(18).Put("trot", NewObj(3).Put("r", ((V)(1D))).Put("dl", ((V)(2D))).Put("f", Fn((V _self46, int _argc47, V p_53, V A_54, V o_55, V _a52, V[] _rest48) => {
V s_56 = default;
if (_self46.IsNullish) _self46 = GlobalV;
s_56 = Call(S_10, V.Undef, p_53);
Set(o_55, "footL", ((V)(((2.6 * ToNum(A_54)) * ToNum(Call(pos_13, V.Undef, s_56))))));
Set(o_55, "footR", ((V)(((2.6 * ToNum(A_54)) * ToNum(Call(pos_13, V.Undef, ((V)((-ToNum(s_56))))))))));
Set(o_55, "armL", ((V)(((12D * ToNum(A_54)) * ToNum(s_56)))));
Set(o_55, "armR", ((V)((((-12D) * ToNum(A_54)) * ToNum(s_56)))));
Set(o_55, "tilt", ((V)(((2.2 * ToNum(A_54)) * ToNum(s_56)))));
Set(o_55, "lift", ((V)(((2.6 * ToNum(A_54)) * ToNum(Call(ab_12, V.Undef, s_56))))));
Set(o_55, "sq", ((V)((((0.035 * ToNum(A_54)) * ToNum(Call(pw_14, V.Undef, Call(C_11, V.Undef, p_53), ((V)(6D))))) - ((0.02 * ToNum(A_54)) * ToNum(Call(ab_12, V.Undef, s_56)))))));
Set(o_55, "htilt", ((V)((((-2.5) * ToNum(A_54)) * ToNum(s_56)))));
Set(o_55, "pitch", ((V)(0.04)));
Set(o_55, "wag", ((V)((12D * ToNum(Call(S_10, V.Undef, ((V)((2D * ToNum(p_53))))))))));
return default;
}, 3, "f", false)).V).Put("waddle", NewObj(3).Put("r", ((V)(0.72))).Put("dl", ((V)(1D))).Put("f", Fn((V _self57, int _argc58, V p_64, V A_65, V o_66, V _a63, V[] _rest59) => {
V s_67 = default;
if (_self57.IsNullish) _self57 = GlobalV;
s_67 = Call(S_10, V.Undef, p_64);
Set(o_66, "tilt", ((V)(((7D * ToNum(A_65)) * ToNum(s_67)))));
Set(o_66, "x", ((V)(((1.1 * ToNum(A_65)) * ToNum(s_67)))));
Set(o_66, "footL", ((V)(((1.9 * ToNum(A_65)) * ToNum(Call(pos_13, V.Undef, s_67))))));
Set(o_66, "footR", ((V)(((1.9 * ToNum(A_65)) * ToNum(Call(pos_13, V.Undef, ((V)((-ToNum(s_67))))))))));
Set(o_66, "armL", ((V)(((16D * ToNum(A_65)) + ((8D * ToNum(A_65)) * ToNum(s_67))))));
Set(o_66, "armR", ((V)(((16D * ToNum(A_65)) - ((8D * ToNum(A_65)) * ToNum(s_67))))));
Set(o_66, "lift", ((V)(((1.3 * ToNum(A_65)) * ToNum(Call(ab_12, V.Undef, s_67))))));
Set(o_66, "htilt", ((V)((((-4D) * ToNum(A_65)) * ToNum(s_67)))));
Set(o_66, "sq", ((V)(((0.03 * ToNum(A_65)) * ToNum(Call(pw_14, V.Undef, Call(C_11, V.Undef, p_64), ((V)(6D))))))));
return NewObj(1).Put("v", ((V)((0.8 + (0.4 * ToNum(Call(ab_12, V.Undef, s_67))))))).V;
return default;
}, 3, "f", false)).V).Put("hop", NewObj(3).Put("r", ((V)(0.6))).Put("dl", ((V)(2D))).Put("f", Fn((V _self68, int _argc69, V p_75, V A_76, V o_77, V _a74, V[] _rest70) => {
V j_78 = default;
if (_self68.IsNullish) _self68 = GlobalV;
j_78 = Call(jmp_15, V.Undef, p_75, ((V)(0.2)), ((V)(0.8)));
Set(o_77, "lift", ((V)(((14D * ToNum(A_76)) * ToNum(Get(j_78, "air"))))));
Set(o_77, "sq", ((V)((((0.12 * ToNum(A_76)) * ToNum(Get(j_78, "gb"))) - ((0.07 * ToNum(A_76)) * ToNum(Get(j_78, "air")))))));
Set(o_77, "footL", Set(o_77, "footR", ((V)(((2D * ToNum(A_76)) * ToNum(Get(j_78, "air")))))));
Set(o_77, "armL", Set(o_77, "armR", ((V)(((20D * ToNum(A_76)) * ToNum(Get(j_78, "air")))))));
Set(o_77, "pitch", ((V)((GeN(Get(j_78, "au"), 0D) ? ((-0.05) * ToNum(Call(C_11, V.Undef, ((V)((PI_9 * ToNum(Get(j_78, "au")))))))) : (0.03 * ToNum(Get(j_78, "gb")))))));
return NewObj(2).Put("v", ((V)((GeN(Get(j_78, "au"), 0D) ? 1.5 : 0.18)))).Put("land", Get(j_78, "gb")).V;
return default;
}, 3, "f", false)).V).Put("bounce", NewObj(3).Put("r", ((V)(0.7))).Put("dl", ((V)(1.5))).Put("f", Fn((V _self79, int _argc80, V p_86, V A_87, V o_88, V _a85, V[] _rest81) => {
V j_89 = default;
if (_self79.IsNullish) _self79 = GlobalV;
j_89 = Call(jmp_15, V.Undef, p_86, ((V)(0.22)), ((V)(0.78)));
Set(o_88, "lift", ((V)(((12D * ToNum(A_87)) * ToNum(Get(j_89, "air"))))));
Set(o_88, "sq", ((V)((((0.2 * ToNum(A_87)) * ToNum(Get(j_89, "gb"))) - ((0.09 * ToNum(A_87)) * ToNum(Get(j_89, "air")))))));
Set(o_88, "armL", Set(o_88, "armR", ((V)(((18D * ToNum(A_87)) * ToNum(Get(j_89, "air")))))));
Set(o_88, "tilt", ((V)(((3D * ToNum(A_87)) * ToNum(Call(S_10, V.Undef, ((V)((2D * ToNum(p_86))))))))));
Set(o_88, "htilt", ((V)(((2D * ToNum(A_87)) * ToNum(Call(S_10, V.Undef, ((V)(((2D * ToNum(p_86)) + 1D)))))))));
return NewObj(2).Put("v", ((V)((GeN(Get(j_89, "au"), 0D) ? 1.5 : 0.22)))).Put("land", Get(j_89, "gb")).V;
return default;
}, 3, "f", false)).V).Put("float", NewObj(3).Put("r", ((V)(0.42))).Put("dl", ((V)(4D))).Put("f", Fn((V _self90, int _argc91, V p_97, V A_98, V o_99, V _a96, V[] _rest92) => {
V s_100 = default;
if (_self90.IsNullish) _self90 = GlobalV;
s_100 = Call(S_10, V.Undef, p_97);
Set(o_99, "lift", ((V)((3D + ((2.5 * ToNum(A_98)) * ToNum(s_100))))));
Set(o_99, "x", ((V)(((0.8 * ToNum(A_98)) * ToNum(Call(S_10, V.Undef, Add(p_97, ((V)(0.8)))))))));
Set(o_99, "tilt", ((V)(((2.5 * ToNum(A_98)) * ToNum(Call(S_10, V.Undef, Add(p_97, ((V)(0.8)))))))));
Set(o_99, "armL", ((V)((6D + ((7D * ToNum(A_98)) * ToNum(Call(S_10, V.Undef, ((V)((2D * ToNum(p_97)))))))))));
Set(o_99, "armR", ((V)((6D + ((7D * ToNum(A_98)) * ToNum(Call(S_10, V.Undef, ((V)(((2D * ToNum(p_97)) + PI_9))))))))));
Set(o_99, "pitch", ((V)(0.06)));
Set(o_99, "sq", ((V)(((0.025 * ToNum(A_98)) * ToNum(Call(S_10, V.Undef, ((V)((2D * ToNum(p_97))))))))));
return default;
}, 3, "f", false)).V).Put("flutter", NewObj(3).Put("r", ((V)(0.55))).Put("dl", ((V)(5D))).Put("f", Fn((V _self101, int _argc102, V p_108, V A_109, V o_110, V P_111, V[] _rest103) => {
V s_112 = default;
if (_self101.IsNullish) _self101 = GlobalV;
s_112 = Call(S_10, V.Undef, p_108);
Set(o_110, "lift", ((V)((ToNum(A_109) * (9D + (3D * ToNum(Call(S_10, V.Undef, ((V)((2D * ToNum(p_108))))))))))));
Set(o_110, "tilt", ((V)(((2D * ToNum(A_109)) * ToNum(s_112)))));
Set(o_110, "pitch", ((V)(0.07)));
Set(o_110, "footL", Set(o_110, "footR", ((V)(0.8))));
if (SEqS(Get(P_111, "wing"), "own")) {
Set(o_110, "armL", ((V)((8D + (5D * ToNum(Call(S_10, V.Undef, ((V)((2D * ToNum(p_108)))))))))));
Set(o_110, "armR", ((V)((8D + (5D * ToNum(Call(S_10, V.Undef, ((V)(((2D * ToNum(p_108)) + PI_9))))))))));
} else {
Set(o_110, "armL", Set(o_110, "armR", ((V)((34D + (30D * ToNum(Call(S_10, V.Undef, ((V)((6D * ToNum(p_108))))))))))));
}
Set(o_110, "sq", ((V)(((-0.03) * ToNum(Call(S_10, V.Undef, ((V)((6D * ToNum(p_108))))))))));
return default;
}, 4, "f", false)).V).Put("galumph", NewObj(3).Put("r", ((V)(0.55))).Put("dl", ((V)(1.5))).Put("f", Fn((V _self113, int _argc114, V p_120, V A_121, V o_122, V _a119, V[] _rest115) => {
V j_123 = default;
if (_self113.IsNullish) _self113 = GlobalV;
j_123 = Call(jmp_15, V.Undef, p_120, ((V)(0.3)), ((V)(0.75)));
Set(o_122, "lift", ((V)(((6D * ToNum(A_121)) * ToNum(Get(j_123, "air"))))));
Set(o_122, "sq", ((V)((((0.14 * ToNum(A_121)) * ToNum(Get(j_123, "gb"))) - ((0.04 * ToNum(A_121)) * ToNum(Get(j_123, "air")))))));
Set(o_122, "pitch", ((V)(((0.06 * ToNum(Get(j_123, "gb"))) - (0.08 * ToNum(Get(j_123, "air")))))));
Set(o_122, "armL", Set(o_122, "armR", ((V)((8D + ((16D * ToNum(A_121)) * ToNum(Get(j_123, "air"))))))));
Set(o_122, "wag", ((V)(((18D * ToNum(A_121)) * ToNum(Call(S_10, V.Undef, Add(p_120, ((V)(1.2)))))))));
return NewObj(2).Put("v", ((V)((0.4 + (1.3 * ToNum(Get(j_123, "air"))))))).Put("land", Get(j_123, "gb")).V;
return default;
}, 3, "f", false)).V).Put("shuffle", NewObj(3).Put("r", ((V)(1.35))).Put("dl", ((V)(1D))).Put("f", Fn((V _self124, int _argc125, V p_131, V A_132, V o_133, V _a130, V[] _rest126) => {
V s_134 = default;
if (_self124.IsNullish) _self124 = GlobalV;
s_134 = Call(S_10, V.Undef, p_131);
Set(o_133, "tilt", ((V)(((4.5 * ToNum(A_132)) * ToNum(s_134)))));
Set(o_133, "footL", ((V)(((1.4 * ToNum(A_132)) * ToNum(Call(pos_13, V.Undef, s_134))))));
Set(o_133, "footR", ((V)(((1.4 * ToNum(A_132)) * ToNum(Call(pos_13, V.Undef, ((V)((-ToNum(s_134))))))))));
Set(o_133, "lift", ((V)(((1.2 * ToNum(A_132)) * ToNum(Call(ab_12, V.Undef, s_134))))));
Set(o_133, "armL", ((V)(((7D * ToNum(A_132)) * ToNum(s_134)))));
Set(o_133, "armR", ((V)((((-7D) * ToNum(A_132)) * ToNum(s_134)))));
Set(o_133, "htilt", ((V)((((-2D) * ToNum(A_132)) * ToNum(s_134)))));
Set(o_133, "sq", ((V)(((0.02 * ToNum(A_132)) * ToNum(Call(pw_14, V.Undef, Call(C_11, V.Undef, p_131), ((V)(4D))))))));
return default;
}, 3, "f", false)).V).Put("stomp", NewObj(3).Put("r", ((V)(0.62))).Put("dl", ((V)(1D))).Put("f", Fn((V _self135, int _argc136, V p_142, V A_143, V o_144, V _a141, V[] _rest137) => {
V s_145 = default;
V c_146 = default;
if (_self135.IsNullish) _self135 = GlobalV;
s_145 = Call(S_10, V.Undef, p_142);
c_146 = Call(pw_14, V.Undef, Call(C_11, V.Undef, p_142), ((V)(8D)));
Set(o_144, "footL", ((V)(((3.4 * ToNum(A_143)) * ToNum(Call(pos_13, V.Undef, s_145))))));
Set(o_144, "footR", ((V)(((3.4 * ToNum(A_143)) * ToNum(Call(pos_13, V.Undef, ((V)((-ToNum(s_145))))))))));
Set(o_144, "tilt", ((V)(((4D * ToNum(A_143)) * ToNum(s_145)))));
Set(o_144, "lift", ((V)(((2.6 * ToNum(A_143)) * ToNum(Call(ab_12, V.Undef, s_145))))));
Set(o_144, "sq", ((V)(((0.07 * ToNum(A_143)) * ToNum(c_146)))));
Set(o_144, "armL", ((V)(((16D * ToNum(A_143)) * ToNum(s_145)))));
Set(o_144, "armR", ((V)((((-16D) * ToNum(A_143)) * ToNum(s_145)))));
Set(o_144, "htilt", ((V)((((-3D) * ToNum(A_143)) * ToNum(s_145)))));
Set(o_144, "pitch", ((V)(0.03)));
return NewObj(1).Put("land", c_146).V;
return default;
}, 3, "f", false)).V).Put("prance", NewObj(3).Put("r", ((V)(0.9))).Put("dl", ((V)(1.5))).Put("f", Fn((V _self147, int _argc148, V p_154, V A_155, V o_156, V _a153, V[] _rest149) => {
V s_157 = default;
V k_158 = default;
if (_self147.IsNullish) _self147 = GlobalV;
s_157 = Call(S_10, V.Undef, p_154);
k_158 = Call(pw_14, V.Undef, s_157, ((V)(0.7)));
Set(o_156, "footL", ((V)(((3.4 * ToNum(A_155)) * Pow(ToNum(Call(pos_13, V.Undef, s_157)), 0.7)))));
Set(o_156, "footR", ((V)(((3.4 * ToNum(A_155)) * Pow(ToNum(Call(pos_13, V.Undef, ((V)((-ToNum(s_157)))))), 0.7)))));
Set(o_156, "lift", ((V)(((3.6 * ToNum(A_155)) * ToNum(k_158)))));
Set(o_156, "armL", ((V)(((20D * ToNum(A_155)) + ((5D * ToNum(A_155)) * ToNum(s_157))))));
Set(o_156, "armR", ((V)(((20D * ToNum(A_155)) - ((5D * ToNum(A_155)) * ToNum(s_157))))));
Set(o_156, "pitch", ((V)((-0.05))));
Set(o_156, "htilt", ((V)(((3D * ToNum(A_155)) * ToNum(Call(S_10, V.Undef, ((V)((2D * ToNum(p_154))))))))));
Set(o_156, "tilt", ((V)(((1.5 * ToNum(A_155)) * ToNum(s_157)))));
Set(o_156, "sq", ((V)((((0.02 * ToNum(A_155)) * ToNum(Call(pw_14, V.Undef, Call(C_11, V.Undef, p_154), ((V)(6D))))) - ((0.03 * ToNum(A_155)) * ToNum(k_158))))));
return default;
}, 3, "f", false)).V).Put("skip", NewObj(3).Put("r", ((V)(0.8))).Put("dl", ((V)(2D))).Put("f", Fn((V _self159, int _argc160, V p_166, V A_167, V o_168, V _a165, V[] _rest161) => {
V s_169 = default;
V k_170 = default;
if (_self159.IsNullish) _self159 = GlobalV;
s_169 = Call(S_10, V.Undef, p_166);
k_170 = Call(pw_14, V.Undef, s_169, ((V)(0.6)));
Set(o_168, "lift", ((V)(((6D * ToNum(A_167)) * ToNum(k_170)))));
Set(o_168, "footL", ((V)(((3D * ToNum(A_167)) * ToNum(Call(pos_13, V.Undef, s_169))))));
Set(o_168, "footR", ((V)(((3D * ToNum(A_167)) * ToNum(Call(pos_13, V.Undef, ((V)((-ToNum(s_169))))))))));
Set(o_168, "armL", ((V)(((24D * ToNum(A_167)) * ToNum(s_169)))));
Set(o_168, "armR", ((V)((((-24D) * ToNum(A_167)) * ToNum(s_169)))));
Set(o_168, "tilt", ((V)(((3D * ToNum(A_167)) * ToNum(s_169)))));
Set(o_168, "sq", ((V)((((0.06 * ToNum(A_167)) * ToNum(Call(pw_14, V.Undef, Call(C_11, V.Undef, p_166), ((V)(8D))))) - ((0.04 * ToNum(A_167)) * ToNum(k_170))))));
Set(o_168, "htilt", ((V)(((3D * ToNum(A_167)) * ToNum(s_169)))));
return default;
}, 3, "f", false)).V).Put("scurry", NewObj(3).Put("r", ((V)(1.9))).Put("dl", ((V)(2.5))).Put("f", Fn((V _self171, int _argc172, V p_178, V A_179, V o_180, V _a177, V[] _rest173) => {
V s_181 = default;
if (_self171.IsNullish) _self171 = GlobalV;
s_181 = Call(S_10, V.Undef, p_178);
Set(o_180, "footL", ((V)(((1.3 * ToNum(A_179)) * ToNum(Call(pos_13, V.Undef, s_181))))));
Set(o_180, "footR", ((V)(((1.3 * ToNum(A_179)) * ToNum(Call(pos_13, V.Undef, ((V)((-ToNum(s_181))))))))));
Set(o_180, "lift", ((V)(((1.1 * ToNum(A_179)) * ToNum(Call(ab_12, V.Undef, s_181))))));
Set(o_180, "tilt", ((V)(((1.5 * ToNum(A_179)) * ToNum(s_181)))));
Set(o_180, "armL", ((V)((6D + ((4D * ToNum(A_179)) * ToNum(s_181))))));
Set(o_180, "armR", ((V)((6D - ((4D * ToNum(A_179)) * ToNum(s_181))))));
Set(o_180, "pitch", ((V)(0.06)));
Set(o_180, "sq", ((V)(0.03)));
return NewObj(1).Put("v", ((V)(1.1))).V;
return default;
}, 3, "f", false)).V).Put("plod", NewObj(3).Put("r", ((V)(0.45))).Put("dl", ((V)(0.5))).Put("f", Fn((V _self182, int _argc183, V p_189, V A_190, V o_191, V _a188, V[] _rest184) => {
V s_192 = default;
if (_self182.IsNullish) _self182 = GlobalV;
s_192 = Call(S_10, V.Undef, p_189);
Set(o_191, "footL", ((V)(((1.7 * ToNum(A_190)) * ToNum(Call(pos_13, V.Undef, s_192))))));
Set(o_191, "footR", ((V)(((1.7 * ToNum(A_190)) * ToNum(Call(pos_13, V.Undef, ((V)((-ToNum(s_192))))))))));
Set(o_191, "armL", ((V)(((8D * ToNum(A_190)) * (-ToNum(s_192))))));
Set(o_191, "armR", ((V)(((8D * ToNum(A_190)) * ToNum(s_192)))));
Set(o_191, "tilt", ((V)(((2.5 * ToNum(A_190)) * ToNum(s_192)))));
Set(o_191, "lift", ((V)(((0.8 * ToNum(A_190)) * ToNum(Call(ab_12, V.Undef, s_192))))));
Set(o_191, "pitch", ((V)(0.03)));
return NewObj(1).Put("v", ((V)(0.75))).V;
return default;
}, 3, "f", false)).V).Put("crawl", NewObj(3).Put("r", ((V)(0.6))).Put("dl", ((V)(1.5))).Put("f", Fn((V _self193, int _argc194, V p_200, V A_201, V o_202, V _a199, V[] _rest195) => {
V s_203 = default;
if (_self193.IsNullish) _self193 = GlobalV;
s_203 = Call(S_10, V.Undef, p_200);
Set(o_202, "lift", ((V)(((2D * ToNum(A_201)) * ToNum(Call(ab_12, V.Undef, s_203))))));
Set(o_202, "tilt", ((V)(((2.2 * ToNum(A_201)) * ToNum(s_203)))));
Set(o_202, "x", ((V)(((0.6 * ToNum(A_201)) * ToNum(s_203)))));
Set(o_202, "sq", ((V)(((0.04 * ToNum(A_201)) * ToNum(Call(S_10, V.Undef, ((V)((2D * ToNum(p_200))))))))));
Set(o_202, "armL", ((V)((10D + ((12D * ToNum(A_201)) * ToNum(s_203))))));
Set(o_202, "armR", ((V)((10D - ((12D * ToNum(A_201)) * ToNum(s_203))))));
Set(o_202, "footL", ((V)(((1.2 * ToNum(A_201)) * ToNum(Call(pos_13, V.Undef, s_203))))));
Set(o_202, "footR", ((V)(((1.2 * ToNum(A_201)) * ToNum(Call(pos_13, V.Undef, ((V)((-ToNum(s_203))))))))));
return default;
}, 3, "f", false)).V).Put("zombie", NewObj(3).Put("r", ((V)(0.5))).Put("dl", ((V)(0.5))).Put("f", Fn((V _self204, int _argc205, V p_211, V A_212, V o_213, V _a210, V[] _rest206) => {
V s_214 = default;
if (_self204.IsNullish) _self204 = GlobalV;
s_214 = Call(S_10, V.Undef, p_211);
Set(o_213, "armL", ((V)((84D + (4D * ToNum(Call(S_10, V.Undef, ((V)((2D * ToNum(p_211)))))))))));
Set(o_213, "armR", ((V)((84D + (4D * ToNum(Call(S_10, V.Undef, ((V)(((2D * ToNum(p_211)) + 1D))))))))));
Set(o_213, "htilt", ((V)(((7D * ToNum(A_212)) * ToNum(s_214)))));
Set(o_213, "tilt", ((V)(((5D * ToNum(A_212)) * ToNum(s_214)))));
Set(o_213, "footL", ((V)(((1.1 * ToNum(A_212)) * ToNum(Call(pos_13, V.Undef, s_214))))));
Set(o_213, "footR", ((V)(((1.1 * ToNum(A_212)) * ToNum(Call(pos_13, V.Undef, ((V)((-ToNum(s_214))))))))));
Set(o_213, "lift", ((V)(((0.6 * ToNum(A_212)) * ToNum(Call(ab_12, V.Undef, s_214))))));
Set(o_213, "x", ((V)(((0.6 * ToNum(A_212)) * ToNum(s_214)))));
return NewObj(1).Put("v", ((V)(0.7))).V;
return default;
}, 3, "f", false)).V).Put("glide", NewObj(3).Put("r", ((V)(0.4))).Put("dl", ((V)(5D))).Put("f", Fn((V _self215, int _argc216, V p_222, V A_223, V o_224, V _a221, V[] _rest217) => {
V s_225 = default;
if (_self215.IsNullish) _self215 = GlobalV;
s_225 = Call(S_10, V.Undef, p_222);
Set(o_224, "lift", ((V)((3D + ((1.5 * ToNum(A_223)) * ToNum(s_225))))));
Set(o_224, "pitch", ((V)(0.05)));
Set(o_224, "armL", ((V)((10D + (4D * ToNum(Call(S_10, V.Undef, Add(p_222, ((V)(1D))))))))));
Set(o_224, "armR", ((V)((10D + (4D * ToNum(Call(S_10, V.Undef, Add(Add(p_222, ((V)(1D))), ((V)(PI_9))))))))));
Set(o_224, "tilt", ((V)(((1.5 * ToNum(A_223)) * ToNum(Call(S_10, V.Undef, Add(p_222, ((V)(0.6)))))))));
Set(o_224, "sq", ((V)(((0.02 * ToNum(A_223)) * ToNum(Call(S_10, V.Undef, ((V)((2D * ToNum(p_222))))))))));
return default;
}, 3, "f", false)).V).Put("roll", NewObj(3).Put("r", ((V)(0.9))).Put("dl", ((V)(1D))).Put("f", Fn((V _self226, int _argc227, V p_233, V A_234, V o_235, V _a232, V[] _rest228) => {
V s_236 = default;
if (_self226.IsNullish) _self226 = GlobalV;
s_236 = Call(S_10, V.Undef, p_233);
Set(o_235, "tilt", ((V)(((8D * ToNum(A_234)) * ToNum(s_236)))));
Set(o_235, "turn", ((V)(((0.18 * ToNum(A_234)) * ToNum(s_236)))));
Set(o_235, "lift", ((V)(((1.5 * ToNum(A_234)) * ToNum(Call(ab_12, V.Undef, s_236))))));
Set(o_235, "sq", ((V)(((0.03 * ToNum(A_234)) * ToNum(Call(pw_14, V.Undef, Call(C_11, V.Undef, p_233), ((V)(4D))))))));
Set(o_235, "armL", ((V)(((10D * ToNum(A_234)) * ToNum(s_236)))));
Set(o_235, "armR", ((V)((((-10D) * ToNum(A_234)) * ToNum(s_236)))));
Set(o_235, "x", ((V)(((0.8 * ToNum(A_234)) * ToNum(s_236)))));
return default;
}, 3, "f", false)).V).Put("strut", NewObj(3).Put("r", ((V)(0.85))).Put("dl", ((V)(1D))).Put("f", Fn((V _self237, int _argc238, V p_244, V A_245, V o_246, V _a243, V[] _rest239) => {
V s_247 = default;
if (_self237.IsNullish) _self237 = GlobalV;
s_247 = Call(S_10, V.Undef, p_244);
Set(o_246, "footL", ((V)(((2.6 * ToNum(A_245)) * ToNum(Call(pos_13, V.Undef, s_247))))));
Set(o_246, "footR", ((V)(((2.6 * ToNum(A_245)) * ToNum(Call(pos_13, V.Undef, ((V)((-ToNum(s_247))))))))));
Set(o_246, "lift", ((V)(((1.6 * ToNum(A_245)) * ToNum(Call(ab_12, V.Undef, s_247))))));
Set(o_246, "tilt", ((V)(((2D * ToNum(A_245)) * ToNum(s_247)))));
Set(o_246, "pitch", ((V)((0.02 + ((0.1 * ToNum(A_245)) * ToNum(Call(pos_13, V.Undef, Call(S_10, V.Undef, ((V)((2D * ToNum(p_244))))))))))));
Set(o_246, "armL", ((V)((10D + ((6D * ToNum(A_245)) * ToNum(Call(S_10, V.Undef, ((V)((2D * ToNum(p_244)))))))))));
Set(o_246, "armR", ((V)((10D + ((6D * ToNum(A_245)) * ToNum(Call(S_10, V.Undef, ((V)((2D * ToNum(p_244)))))))))));
Set(o_246, "sq", ((V)(((0.03 * ToNum(A_245)) * ToNum(Call(pw_14, V.Undef, Call(C_11, V.Undef, p_244), ((V)(6D))))))));
return default;
}, 3, "f", false)).V).V;
PROF_17 = NewObj(0).V;
DEF_18 = NewObj(1).Put("g", ((V)("trot"))).V;
W_19 = Set(G("window"), "HouseWalk", NewObj(7).Put("G", G_16).Put("PROF", PROF_17).Put("DLS", ((V)(1D))).Put("def", Fn((V _self248, int _argc249, V key_255, V P_256, V _a253, V _a254, V[] _rest250) => {
if (_self248.IsNullish) _self248 = GlobalV;
SetK(PROF_17, key_255, P_256);
return default;
}, 2, "def", false)).Put("prof", Fn((V _self257, int _argc258, V key_264, V _a261, V _a262, V _a263, V[] _rest259) => {
V P0_265 = default;
if (_self257.IsNullish) _self257 = GlobalV;
key_264 = ((Get(G("window"), "SQ_ALIAS") is var _t266 && !Truthy(_t266) ? _t266 : GetK(Get(G("window"), "SQ_ALIAS"), key_264)) is var _t267 && Truthy(_t267) ? _t267 : key_264);
P0_265 = (GetK(PROF_17, key_264) is var _t268 && Truthy(_t268) ? _t268 : DEF_18);
return (Truthy(Get(G("window"), "SquishConfig")) ? Invoke(Get(G("window"), "SquishConfig"), "walkProfile", key_264, P0_265) : P0_265);
return default;
}, 1, "prof", false)).Put("period", Fn((V _self269, int _argc270, V key_276, V _a273, V _a274, V _a275, V[] _rest271) => {
V P_277 = default;
V g_278 = default;
if (_self269.IsNullish) _self269 = GlobalV;
P_277 = Invoke(W_19, "prof", key_276);
g_278 = (GetK(G_16, Get(P_277, "g")) is var _t279 && Truthy(_t279) ? _t279 : Get(G_16, "trot"));
return ((V)(((1000D * TAU_8) / ((11D * ToNum(Get(g_278, "r"))) * ToNum((Get(P_277, "r") is var _t280 && Truthy(_t280) ? _t280 : ((V)(1D))))))));
return default;
}, 1, "period", false)).Put("step", Fn((V _self281, int _argc282, V key_288, V st_289, V E_290, V w_291, V[] _rest283) => {
V rk_295 = default;
V P_296 = default;
V g_297 = default;
double A_298 = 0;
V p_299 = default;
V o_300 = default;
V m_301 = default;
double sr_302 = 0;
double sd_303 = 0;
V fx_304 = default;
V now_305 = default;
V dt_292 = default;
V spd_293 = default;
V spin_294 = default;
if (_self281.IsNullish) _self281 = GlobalV;
dt_292 = (_argc282 > 4 ? _rest283[0] : V.Undef);
spd_293 = (_argc282 > 5 ? _rest283[1] : V.Undef);
spin_294 = (_argc282 > 6 ? _rest283[2] : V.Undef);
key_288 = ((Get(G("window"), "SQ_ALIAS") is var _t306 && !Truthy(_t306) ? _t306 : GetK(Get(G("window"), "SQ_ALIAS"), key_288)) is var _t307 && Truthy(_t307) ? _t307 : key_288);
rk_295 = Set(st_289, "rk", Add((Get(st_289, "rk") is var _t308 && Truthy(_t308) ? _t308 : ((V)(0D))), ((V)((((Truthy(Get(st_289, "run")) ? 1D : 0D) - ToNum((Get(st_289, "rk") is var _t309 && Truthy(_t309) ? _t309 : ((V)(0D))))) * Min(1D, (ToNum(dt_292) * 6D)))))));
P_296 = Invoke(W_19, "prof", key_288);
g_297 = (GetK(G_16, Get(P_296, "g")) is var _t310 && Truthy(_t310) ? _t310 : Get(G_16, "trot"));
A_298 = (ToNum((Get(P_296, "a") is var _t311 && Truthy(_t311) ? _t311 : ((V)(1D)))) * (1D + (0.28 * ToNum(rk_295))));
Set(st_289, "ph", Add((Get(st_289, "ph") is var _t312 && Truthy(_t312) ? _t312 : ((V)(0D))), ((V)((((((ToNum(dt_292) * 11D) * ToNum(Get(g_297, "r"))) * ToNum((Get(P_296, "r") is var _t313 && Truthy(_t313) ? _t313 : ((V)(1D))))) * ToNum((spd_293 is var _t314 && Truthy(_t314) ? _t314 : ((V)(0D))))) * (1D + (0.6 * ToNum(rk_295))))))));
if (LtN(w_291, 0.002)) {
return NewObj(2).Put("v", ((V)(1D))).Put("fx", V.Null).V;
}
p_299 = Get(st_289, "ph");
o_300 = NewObj(0).V;
m_301 = (Invoke(g_297, "f", p_299, ((V)(A_298)), o_300, P_296) is var _t315 && Truthy(_t315) ? _t315 : NewObj(0).V);
sr_302 = ((ToNum((spin_294 is var _t316 && Truthy(_t316) ? _t316 : ((V)(0D)))) * PI_9) / 180D);
sd_303 = (0.45 + (0.55 * ToNum(Call(ab_12, V.Undef, Call(C_11, V.Undef, ((V)(sr_302)))))));
if (Truthy(Get(o_300, "tilt"))) {
OpSet(o_300, "tilt", 2, ((V)(sd_303)));
}
if (Truthy(Get(o_300, "x"))) {
OpSet(o_300, "x", 2, ((V)(sd_303)));
}
Set(o_300, "tilt", Add((Get(o_300, "tilt") is var _t317 && Truthy(_t317) ? _t317 : ((V)(0D))), ((V)(((ToNum(Get(W_19, "DLS")) * ToNum((!Get(P_296, "dl").IsNullish ? Get(P_296, "dl") : Get(g_297, "dl")))) * ToNum(Call(S_10, V.Undef, ((V)(sr_302)))))))));
if (Truthy(Get(P_296, "x"))) {
{
foreach (V _k318 in ForInKeys(Get(P_296, "x"))) {
V k_319 = default;
k_319 = _k318;
V q_320 = default;
V v_321 = default;
q_320 = GetK(Get(P_296, "x"), k_319);
v_321 = Call(S_10, V.Undef, Add(((V)((ToNum((GetIdx(q_320, 1D) is var _t322 && Truthy(_t322) ? _t322 : ((V)(1D)))) * ToNum(p_299)))), (GetIdx(q_320, 2D) is var _t323 && Truthy(_t323) ? _t323 : ((V)(0D)))));
SetK(o_300, k_319, Add((GetK(o_300, k_319) is var _t324 && Truthy(_t324) ? _t324 : ((V)(0D))), ((V)((ToNum(GetIdx(q_320, 0D)) * ToNum((Truthy(GetIdx(q_320, 3D)) ? Call(ab_12, V.Undef, v_321) : v_321)))))));
}
}
}
if (Truthy(Get(P_296, "c"))) {
{
foreach (V _k325 in ForInKeys(Get(P_296, "c"))) {
V k_326 = default;
k_326 = _k325;
SetK(o_300, k_326, Add((GetK(o_300, k_326) is var _t327 && Truthy(_t327) ? _t327 : ((V)(0D))), GetK(Get(P_296, "c"), k_326)));
}
}
}
if (Truthy(Get(P_296, "m"))) {
{
foreach (V _k328 in ForInKeys(Get(P_296, "m"))) {
V k_329 = default;
k_329 = _k328;
if (!GetK(o_300, k_329).IsNullish) {
OpSetK(o_300, k_329, 2, GetK(Get(P_296, "m"), k_329));
}
}
}
}
if (GtN(rk_295, 0.01)) {
V RX_330 = default;
V add_331 = default;
RX_330 = (GetK((Get(G("window"), "HouseWalkRUN") is var _t332 && Truthy(_t332) ? _t332 : NewObj(0).V), key_288) is var _t333 && Truthy(_t333) ? _t333 : NewObj(0).V);
add_331 = Fn((V _self281, int _argc334, V k_340, V v_341, V _a338, V _a339, V[] _rest335) => {
SetK(o_300, k_340, Add((GetK(o_300, k_340) is var _t342 && Truthy(_t342) ? _t342 : ((V)(0D))), ((V)((ToNum(v_341) * ToNum(rk_295))))));
return default;
}, 2, "", true);
Call(add_331, V.Undef, ((V)("tilt")), ((V)(((3.5 * ToNum(Get(W_19, "DLS"))) * ToNum(Call(S_10, V.Undef, ((V)(sr_302))))))));
Call(add_331, V.Undef, ((V)("pitch")), ((V)((-0.06))));
Call(add_331, V.Undef, ((V)("open")), ((V)(0.32)));
Call(add_331, V.Undef, ((V)("mw")), ((V)((-0.25))));
Call(add_331, V.Undef, ((V)("hap")), ((V)(0.7)));
Call(add_331, V.Undef, ((V)("smile")), ((V)(0.3)));
Call(add_331, V.Undef, ((V)("wide")), ((V)(0.25)));
Call(add_331, V.Undef, ((V)("earL")), ((V)(10D)));
Call(add_331, V.Undef, ((V)("earR")), ((V)((-10D))));
{
foreach (V _k343 in ForInKeys(RX_330)) {
V k_344 = default;
k_344 = _k343;
Call(add_331, V.Undef, k_344, GetK(RX_330, k_344));
}
}
}
{
foreach (V _k345 in ForInKeys(o_300)) {
V k_346 = default;
k_346 = _k345;
SetK(E_290, k_346, Add((GetK(E_290, k_346) is var _t347 && Truthy(_t347) ? _t347 : ((V)(0D))), ((V)((ToNum(GetK(o_300, k_346)) * ToNum(w_291))))));
}
}
fx_304 = V.Null;
now_305 = Set(st_289, "t", Add((Get(st_289, "t") is var _t348 && Truthy(_t348) ? _t348 : ((V)(0D))), ((V)((ToNum(dt_292) * 1000D)))));
if (Truthy(((GtN(w_291, 0.6) ? V.True : V.False) is var _t349 && !Truthy(_t349) ? _t349 : spd_293))) {
if (Truthy((Get(P_296, "fx") is var _t351 && !Truthy(_t351) ? _t351 : (Gt(now_305, (Get(st_289, "fxAt") is var _t350 && Truthy(_t350) ? _t350 : ((V)(0D)))) ? V.True : V.False)))) {
Set(st_289, "fxAt", Add(now_305, ((V)((ToNum(GetIdx(Get(P_296, "fx"), 1D)) * (0.7 + (ToNum(Invoke(G("Math"), "random")) * 0.6)))))));
fx_304 = GetIdx(Get(P_296, "fx"), 0D);
}
if (Truthy((Get(P_296, "dust") is var _t352 && !Truthy(_t352) ? _t352 : (!Get(m_301, "land").IsNullish ? V.True : V.False)))) {
V ld_353 = default;
ld_353 = (GtN(Get(m_301, "land"), 0.9) ? V.True : V.False);
if (Truthy((ld_353 is var _t354 && !Truthy(_t354) ? _t354 : (!(Truthy(Get(st_289, "ld"))) ? V.True : V.False)))) {
fx_304 = Get(P_296, "dust");
}
Set(st_289, "ld", ld_353);
}
if (((GtN(rk_295, 0.5) && !(Truthy(fx_304))) && Gt(now_305, (Get(st_289, "ruAt") is var _t355 && Truthy(_t355) ? _t355 : ((V)(0D)))))) {
Set(st_289, "ruAt", Add(now_305, ((V)(260D))));
fx_304 = (Get(P_296, "dust") is var _t356 && Truthy(_t356) ? _t356 : V.Null);
}
}
return NewObj(2).Put("v", (Get(m_301, "v") is var _t357 && Truthy(_t357) ? _t357 : ((V)(1D)))).Put("fx", fx_304).V;
return default;
}, 7, "step", false)).V);
Invoke((Get(G("window"), "HouseWalkC") is var _t365 && Truthy(_t365) ? _t365 : Arr()), "forEach", Fn((V _self1, int _argc358, V f_364, V _a361, V _a362, V _a363, V[] _rest359) => {
return Call(f_364, V.Undef, W_19);
}, 1, "", true));
return default;
}, 0, "", false), V.Undef);
        }
    }
}
