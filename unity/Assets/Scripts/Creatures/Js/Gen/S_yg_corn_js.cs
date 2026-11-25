// yg-corn.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_yg_corn_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("[-\\d.]+", "g");
        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V go_8 = default;
if (_self1.IsNullish) _self1 = GlobalV;
go_8 = Fn((V _arrowThis15, int _argc9, V _a11, V _a12, V _a13, V _a14, V[] _rest10) => {
V YG_16 = default;
V S_17 = default;
V D_18 = default;
V cl_19 = default;
V lerp_20 = default;
V r2_21 = default;
V track_22 = default;
V SFX_23 = default;
V ICON_24 = default;
YG_16 = Get(G("window"), "YardGames");
if (((!(Truthy(YG_16)) || !(Truthy(Get(YG_16, "add")))) || !(Truthy(Get(YG_16, "cam"))))) {
return Call(G("setTimeout"), V.Undef, go_8, ((V)(30D)));
}
{ V _t25 = YG_16;
if (_t25.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t25));
{ V _t26 = Get(_t25, "S");
S_17 = _t26; }
{ V _t27 = Get(_t25, "D");
D_18 = _t27; }
{ V _t28 = Get(_t25, "cl");
cl_19 = _t28; }
{ V _t29 = Get(_t25, "lerp");
lerp_20 = _t29; }
{ V _t30 = Get(_t25, "r2");
r2_21 = _t30; }
{ V _t31 = Get(_t25, "track");
track_22 = _t31; }
{ V _t32 = Get(_t25, "SFX");
SFX_23 = _t32; } }
ICON_24 = ((V)(string.Concat("<svg viewBox=\"0 0 120 84\" aria-hidden=\"true\"><rect width=\"120\" height=\"84\" fill=\"#cfeaff\"/><rect y=\"34\" width=\"120\" height=\"50\" fill=\"#9fdc6e\"/>", "<path d=\"M38 72L50 30H70L82 72Z\" fill=\"#3b7fe0\"/><path d=\"M38 72H82V77H38Z\" fill=\"#2a5fb0\"/><path d=\"M44 52H76\" stroke=\"#fff\" stroke-width=\"3\" opacity=\"0.8\"/><ellipse cx=\"60\" cy=\"38\" rx=\"6\" ry=\"2.6\" fill=\"#1b2a44\"/>", "<rect x=\"51\" y=\"58\" width=\"12\" height=\"9\" rx=\"3\" fill=\"#e8483c\" transform=\"rotate(-8 57 62)\"/><rect x=\"88\" y=\"16\" width=\"12\" height=\"9\" rx=\"3\" fill=\"#e8483c\" transform=\"rotate(20 94 20)\"/><path d=\"M92 28Q80 30 72 40\" stroke=\"#fff\" stroke-width=\"1.6\" stroke-dasharray=\"2 3\" fill=\"none\"/></svg>")));
Invoke(YG_16, "add", NewObj(11).Put("id", ((V)("corn"))).Put("land", (true ? V.True : V.False)).Put("name", ((V)("Cornhole"))).Put("item", ((V)("Cornhole Boards"))).Put("color", ((V)("#4f8fff"))).Put("icon", ICON_24).Put("stars", Arr(((V)(8D)), ((V)(13D)), ((V)(18D)))).Put("coinK", ((V)(2D))).Put("hint", ((V)("Pull back and let go to toss \u00b7 mind the wind"))).Put("how", Arr(((V)("Pull back from anywhere and let go to toss your bean bag.")), ((V)("Pull further to throw farther; pull to one side to aim the other way.")), ((V)("8 bags. On the board = 1, in the hole = 3. Watch the wind flag!")))).Put("make", Fn((V _self33, int _argc34, V ctx_40, V _a37, V _a38, V _a39, V[] _rest35) => {
V bg_41 = default;
V fg_42 = default;
V W_43 = default;
V H_44 = default;
V P_45 = default;
double G_46 = 0;
double BW_47 = 0;
double ZF_48 = 0;
double ZB_49 = 0;
double YF_50 = 0;
double YB_51 = 0;
double HZ_52 = 0;
double HR_53 = 0;
double BS_54 = 0;
V yb_55 = default;
V quad_56 = default;
V boardG_57 = default;
V restG_58 = default;
V shG_59 = default;
V flyG_60 = default;
V guideG_61 = default;
V flag_62 = default;
V fp_63 = default;
V fp2_64 = default;
V cloth_65 = default;
V windTx_66 = default;
V me_67 = default;
double mz_68 = 0;
double mx_69 = 0;
V mp_70 = default;
V REL_71 = default;
V bags_72 = default;
double left_73 = 0;
V cur_74 = default;
V drag_75 = default;
V wind_76 = default;
V tNow_77 = default;
V throwT_78 = default;
V settleT_79 = default;
JsStrBuf phase_80 = null;
double inHole_81 = 0;
V mkBag_82 = default;
V newWind_83 = default;
V toss_84 = default;
V tally_85 = default;
V settle_86 = default;
V api_87 = default;
if (_self33.IsNullish) _self33 = GlobalV;
mkBag_82 = Fn((V _self88, int _argc89, V _a91, V _a92, V _a93, V _a94, V[] _rest90) => {
V g_95 = default;
V sh_96 = default;
V b_97 = default;
V st_98 = default;
if (_self88.IsNullish) _self88 = GlobalV;
g_95 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, flyG_60);
sh_96 = Call(S_17, V.Undef, ((V)("ellipse")), NewObj(2).Put("fill", ((V)("#3a2a55"))).Put("opacity", ((V)(0.18))).V, shG_59);
b_97 = Call(S_17, V.Undef, ((V)("path")), NewObj(3).Put("fill", ((V)("#e8483c"))).Put("stroke", ((V)("#b5322a"))).Put("stroke-width", ((V)(1D))).V, g_95);
st_98 = Call(S_17, V.Undef, ((V)("path")), NewObj(4).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffd2cc"))).Put("stroke-width", ((V)(0.9))).Put("stroke-dasharray", ((V)("1.6 1.6"))).V, g_95);
return NewObj(15).Put("g", g_95).Put("sh", sh_96).Put("b", b_97).Put("st", st_98).Put("x", GetIdx(REL_71, 0D)).Put("y", GetIdx(REL_71, 1D)).Put("z", GetIdx(REL_71, 2D)).Put("vx", ((V)(0D))).Put("vy", ((V)(0D))).Put("vz", ((V)(0D))).Put("rot", ((V)(0D))).Put("vr", ((V)(0D))).Put("st8", ((V)("hand"))).Put("sp", ((V)(0D))).Put("dir", Arr(((V)(0D)), ((V)(1D)))).V;
return default;
}, 0, "mkBag", false);
newWind_83 = Fn((V _self99, int _argc100, V _a102, V _a103, V _a104, V _a105, V[] _rest101) => {
if (_self99.IsNullish) _self99 = GlobalV;
wind_76 = ((V)((Round((((ToNum(Invoke(G("Math"), "random")) - 0.5) * 2D) * 6D)) / 10D)));
Set(windTx_66, "textContent", ((V)((SEqN(wind_76, 0D) ? "No wind" : JsStrBuf.Begin().S("Wind ").S((LtN(wind_76, 0D) ? "\u2190 " : "\u2192 ")).V(Invoke(((V)(System.Math.Abs(ToNum(wind_76)))), "toFixed", ((V)(1D)))).End()))));
return default;
}, 0, "newWind", false);
toss_84 = Fn((V _self106, int _argc107, V px_113, V py_114, V _a111, V _a112, V[] _rest108) => {
double len_115 = 0;
V p_116 = default;
double a_117 = 0;
double th_118 = 0;
double v_119 = 0;
double ph_120 = 0;
if (_self106.IsNullish) _self106 = GlobalV;
if ((!(Truthy(cur_74)) || !string.Equals(phase_80.Str, "aim"))) {
return default;
}
len_115 = Hypot(ToNum(px_113), ToNum(py_114));
if ((LtN(py_114, 18D) || (len_115 < 30D))) {
Set(cur_74, "st8", ((V)("hand")));
return default;
}
p_116 = Call(cl_19, V.Undef, ((V)((len_115 / 160D))), ((V)(0.05)), ((V)(1.3)));
a_117 = FdLibm.Atan2((-ToNum(px_113)), ToNum(py_114));
th_118 = ((38D * System.Math.PI) / 180D);
v_119 = (3.6 + (ToNum(p_116) * 4.2));
ph_120 = (FdLibm.Atan2((-ToNum(GetIdx(REL_71, 0D))), (HZ_52 - ToNum(GetIdx(REL_71, 2D)))) + (a_117 * 0.42));
Object_assign(cur_74, NewObj(5).Put("st8", ((V)("fly"))).Put("vx", ((V)(((FdLibm.Sin(ph_120) * v_119) * FdLibm.Cos(th_118))))).Put("vz", ((V)(((FdLibm.Cos(ph_120) * v_119) * FdLibm.Cos(th_118))))).Put("vy", ((V)((v_119 * FdLibm.Sin(th_118))))).Put("vr", ((V)(((ToNum(Invoke(G("Math"), "random")) - 0.5) * 700D)))).V);
Invoke(bags_72, "push", cur_74);
cur_74 = V.Null;
left_73--;
phase_80.Set("fly");
throwT_78 = tNow_77;
Invoke(SFX_23, "whoosh");
Invoke(ctx_40, "timer", ((V)(JsStrBuf.Begin().S("Bags ").N(left_73).End())));
return default;
}, 2, "toss", false);
tally_85 = Fn((V _self121, int _argc122, V _a124, V _a125, V _a126, V _a127, V[] _rest123) => {
double s_128 = 0;
if (_self121.IsNullish) _self121 = GlobalV;
s_128 = 0D;
inHole_81 = 0D;
Invoke(bags_72, "forEach", Fn((V _arrowThis136, int _argc129, V b_135, V _a132, V _a133, V _a134, V[] _rest130) => {
if (SEqS(Get(b_135, "st8"), "hole")) {
s_128 = (s_128 + 3D);
inHole_81++;
} else {
if (((SEqS(Get(b_135, "st8"), "board") || SEqS(Get(b_135, "st8"), "slide")) && !Call(yb_55, V.Undef, Get(b_135, "x"), Get(b_135, "z")).IsNullish)) {
s_128 = (s_128 + 1D);
}
}
return default;
}, 1, "", true));
return ((V)(s_128));
return default;
}, 0, "tally", false);
settle_86 = Fn((V _self137, int _argc138, V _a140, V _a141, V _a142, V _a143, V[] _rest139) => {
V before_144 = default;
V now_145 = default;
if (_self137.IsNullish) _self137 = GlobalV;
before_144 = Get(ctx_40, "score");
now_145 = Call(tally_85, V.Undef);
if (!SEq(now_145, before_144)) {
Invoke(ctx_40, "setScore", now_145);
}
return default;
}, 0, "settle", false);
{ V _t146 = ctx_40;
if (_t146.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t146));
{ V _t147 = Get(_t146, "bg");
bg_41 = _t147; }
{ V _t148 = Get(_t146, "fg");
fg_42 = _t148; }
{ V _t149 = Get(_t146, "W");
W_43 = _t149; }
{ V _t150 = Get(_t146, "H");
H_44 = _t150; } }
P_45 = Invoke(YG_16, "cam", ((V)(2.4)), ((V)(1.45)), ((V)(116D)), ((V)(206D)));
G_46 = 9.8;
BW_47 = 0.86;
ZF_48 = 3D;
ZB_49 = 4.6;
YF_50 = 0.08;
YB_51 = 0.34;
HZ_52 = 4.3;
HR_53 = 0.115;
BS_54 = 0.075;
Invoke(YG_16, "yard", bg_41, NewObj(1).Put("hz", ((V)(116D))).V);
yb_55 = Fn((V _arrowThis159, int _argc151, V x_157, V z_158, V _a155, V _a156, V[] _rest152) => {
return ((((System.Math.Abs(ToNum(x_157)) <= (BW_47 / 2D)) && GeN(z_158, ZF_48)) && LeN(z_158, ZB_49)) ? Call(lerp_20, V.Undef, ((V)(YF_50)), ((V)(YB_51)), ((V)(((ToNum(z_158) - ZF_48) / (ZB_49 - ZF_48))))) : V.Null);
}, 2, "", true);
quad_56 = Fn((V _arrowThis169, int _argc160, V pts_166, V a_167, V p_168, V _a165, V[] _rest161) => {
return Call(S_17, V.Undef, ((V)("path")), Object_assign(NewObj(1).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_166, "map", Fn((V _arrowThis177, int _argc170, V q_176, V _a173, V _a174, V _a175, V[] _rest171) => {
V s_178 = default;
s_178 = Call(P_45, V.Undef, GetIdx(q_176, 0D), GetIdx(q_176, 1D), GetIdx(q_176, 2D));
return ((V)(JsStrBuf.Begin().V(Call(r2_21, V.Undef, GetIdx(s_178, 0D))).S(" ").V(Call(r2_21, V.Undef, GetIdx(s_178, 1D))).End()));
return default;
}, 1, "", true)), "join", ((V)("L")))).S("Z").End()))).V, a_167), (p_168 is var _t179 && Truthy(_t179) ? _t179 : bg_41));
}, 3, "", true);
boardG_57 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, bg_41);
{
V g0_180 = default;
double zm_181 = 0;
JsStrBuf d_182 = null;
g0_180 = Call(P_45, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(((ZF_48 + ZB_49) / 2D))));
Invoke(YG_16, "shadow", boardG_57, GetIdx(g0_180, 0D), Add(GetIdx(g0_180, 1D), ((V)(6D))), ((V)((0.62 * ToNum(GetIdx(g0_180, 2D))))), ((V)(0.2)));
Invoke(Arr(Arr(((V)((((-BW_47) / 2D) + 0.06)))), Arr(((V)(((BW_47 / 2D) - 0.06))))), "forEach", Fn((V _arrowThis192, int _argc183, V _a185, V _a186, V _a187, V _a188, V[] _rest184) => {
V x_191 = default;
{ V _t189 = ListOf(_a185);
{ V _t190 = GetIdx(_t189, 0D);
x_191 = _t190; }
}
return Call(quad_56, V.Undef, Arr(Arr(((V)((ToNum(x_191) - 0.025))), ((V)(0D)), ((V)((ZB_49 - 0.05)))), Arr(Add(x_191, ((V)(0.025))), ((V)(0D)), ((V)((ZB_49 - 0.05)))), Arr(Add(x_191, ((V)(0.025))), ((V)(YB_51)), ((V)((ZB_49 - 0.05)))), Arr(((V)((ToNum(x_191) - 0.025))), ((V)(YB_51)), ((V)((ZB_49 - 0.05))))), NewObj(1).Put("fill", ((V)("#1d4fa0"))).V, boardG_57);
}, 1, "", true));
Call(quad_56, V.Undef, Arr(Arr(((V)(((-BW_47) / 2D))), ((V)((YF_50 - 0.06))), ((V)(ZF_48))), Arr(((V)((BW_47 / 2D))), ((V)((YF_50 - 0.06))), ((V)(ZF_48))), Arr(((V)((BW_47 / 2D))), ((V)(YF_50)), ((V)(ZF_48))), Arr(((V)(((-BW_47) / 2D))), ((V)(YF_50)), ((V)(ZF_48)))), NewObj(1).Put("fill", ((V)("#2a5fb0"))).V, boardG_57);
Call(quad_56, V.Undef, Arr(Arr(((V)(((-BW_47) / 2D))), ((V)(YF_50)), ((V)(ZF_48))), Arr(((V)((BW_47 / 2D))), ((V)(YF_50)), ((V)(ZF_48))), Arr(((V)((BW_47 / 2D))), ((V)(YB_51)), ((V)(ZB_49))), Arr(((V)(((-BW_47) / 2D))), ((V)(YB_51)), ((V)(ZB_49)))), NewObj(1).Put("fill", ((V)("#3b7fe0"))).V, boardG_57);
Call(quad_56, V.Undef, Arr(Arr(((V)((((-BW_47) / 2D) + 0.04))), ((V)((YF_50 + 0.003))), ((V)((ZF_48 + 0.04)))), Arr(((V)(((BW_47 / 2D) - 0.04))), ((V)((YF_50 + 0.003))), ((V)((ZF_48 + 0.04)))), Arr(((V)(((BW_47 / 2D) - 0.04))), ((V)((YB_51 + 0.003))), ((V)((ZB_49 - 0.04)))), Arr(((V)((((-BW_47) / 2D) + 0.04))), ((V)((YB_51 + 0.003))), ((V)((ZB_49 - 0.04))))), NewObj(4).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(1.6))).Put("opacity", ((V)(0.55))).V, boardG_57);
zm_181 = (ZF_48 + 0.55);
Call(quad_56, V.Undef, Arr(Arr(((V)(((-BW_47) / 2D))), Call(lerp_20, V.Undef, ((V)(YF_50)), ((V)(YB_51)), ((V)(((zm_181 - ZF_48) / 1.6)))), ((V)(zm_181))), Arr(((V)((BW_47 / 2D))), Call(lerp_20, V.Undef, ((V)(YF_50)), ((V)(YB_51)), ((V)(((zm_181 - ZF_48) / 1.6)))), ((V)(zm_181))), Arr(((V)((BW_47 / 2D))), Call(lerp_20, V.Undef, ((V)(YF_50)), ((V)(YB_51)), ((V)((((zm_181 + 0.08) - ZF_48) / 1.6)))), ((V)((zm_181 + 0.08)))), Arr(((V)(((-BW_47) / 2D))), Call(lerp_20, V.Undef, ((V)(YF_50)), ((V)(YB_51)), ((V)((((zm_181 + 0.08) - ZF_48) / 1.6)))), ((V)((zm_181 + 0.08))))), NewObj(2).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0.8))).V, boardG_57);
d_182 = new JsStrBuf("");
{
double i_193 = 0;
i_193 = 0D;
while (true) {
if (!((i_193 <= 24D))) break;
double a_195 = 0;
double x_196 = 0;
double z_197 = 0;
V s_198 = default;
a_195 = (((i_193 / 24D) * System.Math.PI) * 2D);
x_196 = (FdLibm.Cos(a_195) * HR_53);
z_197 = (HZ_52 + (FdLibm.Sin(a_195) * HR_53));
s_198 = Call(P_45, V.Undef, ((V)(x_196)), Add(Call(lerp_20, V.Undef, ((V)(YF_50)), ((V)(YB_51)), ((V)(((z_197 - ZF_48) / 1.6)))), ((V)(0.002))), ((V)(z_197)));
d_182.S((NumTruthy(i_193) ? "L" : "M")).V(Call(r2_21, V.Undef, GetIdx(s_198, 0D))).S(" ").V(Call(r2_21, V.Undef, GetIdx(s_198, 1D)));
i_193++;
}
}
Call(S_17, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(string.Concat(d_182.Str, "Z")))).Put("fill", ((V)("#14213a"))).Put("stroke", ((V)("#2a5fb0"))).Put("stroke-width", ((V)(1.5))).V, boardG_57);
}
restG_58 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, bg_41);
shG_59 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, bg_41);
flyG_60 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, fg_42);
guideG_61 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, fg_42);
flag_62 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, bg_41);
fp_63 = Call(P_45, V.Undef, ((V)(((BW_47 / 2D) + 0.45))), ((V)(0D)), ((V)((ZB_49 - 0.1))));
fp2_64 = Call(P_45, V.Undef, ((V)(((BW_47 / 2D) + 0.45))), ((V)(1.25)), ((V)((ZB_49 - 0.1))));
Call(S_17, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_21, V.Undef, GetIdx(fp_63, 0D))).S(" ").V(Call(r2_21, V.Undef, GetIdx(fp_63, 1D))).S("L").V(Call(r2_21, V.Undef, GetIdx(fp2_64, 0D))).S(" ").V(Call(r2_21, V.Undef, GetIdx(fp2_64, 1D))).End()))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(2.4))).V, flag_62);
cloth_65 = Call(S_17, V.Undef, ((V)("path")), NewObj(3).Put("fill", ((V)("#ffcf3a"))).Put("stroke", ((V)("#e09a14"))).Put("stroke-width", ((V)(1D))).V, flag_62);
windTx_66 = Call(D_18, V.Undef, ((V)("div")), NewObj(2).Put("cls", ((V)("yg-pill"))).Put("style", ((V)("position:absolute;right:3%;top:12.5%;font-size:13px;padding:5px 9px;"))).V, Invoke(Get(Get(ctx_40, "crl"), "parentNode"), "querySelector", ((V)(".yg-hud"))));
me_67 = Invoke(ctx_40, "creature", Get(ctx_40, "playerKey"), NewObj(1).Put("yaw", ((V)(198D))).V);
mz_68 = 0.42;
mx_69 = (-0.42);
mp_70 = Call(P_45, V.Undef, ((V)(mx_69)), ((V)(0D)), ((V)(mz_68)));
Invoke(me_67, "set", GetIdx(mp_70, 0D), GetIdx(mp_70, 1D), ((V)((0.78 * ToNum(GetIdx(mp_70, 2D))))));
Invoke(YG_16, "shadow", shG_59, GetIdx(mp_70, 0D), ((V)((ToNum(GetIdx(mp_70, 1D)) - 2D))), ((V)((0.3 * ToNum(GetIdx(mp_70, 2D))))), ((V)(0.2)));
REL_71 = Arr(((V)((mx_69 + 0.2))), ((V)(0.72)), ((V)((mz_68 + 0.18))));
bags_72 = Arr();
left_73 = 8D;
cur_74 = V.Null;
drag_75 = V.Null;
wind_76 = ((V)(0D));
tNow_77 = ((V)(0D));
throwT_78 = ((V)((-9D)));
settleT_79 = ((V)(0D));
phase_80 = new JsStrBuf("aim");
inHole_81 = 0D;
api_87 = NewObj(10).Put("start", Fn((V _self199, int _argc200, V _a202, V _a203, V _a204, V _a205, V[] _rest201) => {
if (_self199.IsNullish) _self199 = GlobalV;
Invoke(bags_72, "forEach", Fn((V _arrowThis213, int _argc206, V b_212, V _a209, V _a210, V _a211, V[] _rest207) => {
Invoke(Get(b_212, "g"), "remove");
Invoke(Get(b_212, "sh"), "remove");
return default;
}, 1, "", true));
bags_72 = Arr();
left_73 = 8D;
cur_74 = Call(mkBag_82, V.Undef);
phase_80.Set("aim");
Invoke(ctx_40, "setScore", ((V)(0D)));
Invoke(ctx_40, "timer", ((V)("Bags 8")));
Call(newWind_83, V.Undef);
return default;
}, 0, "start", false)).Put("down", Fn((V _self214, int _argc215, V p_221, V _a218, V _a219, V _a220, V[] _rest216) => {
if (_self214.IsNullish) _self214 = GlobalV;
if (Truthy(((string.Equals(phase_80.Str, "aim") ? V.True : V.False) is var _t222 && !Truthy(_t222) ? _t222 : cur_74))) {
drag_75 = NewObj(4).Put("x0", Get(p_221, "x")).Put("y0", Get(p_221, "y")).Put("x", Get(p_221, "x")).Put("y", Get(p_221, "y")).V;
}
return default;
}, 1, "down", false)).Put("move", Fn((V _self223, int _argc224, V p_230, V _a227, V _a228, V _a229, V[] _rest225) => {
if (_self223.IsNullish) _self223 = GlobalV;
if (Truthy(drag_75)) {
Set(drag_75, "x", Get(p_230, "x"));
Set(drag_75, "y", Get(p_230, "y"));
}
return default;
}, 1, "move", false)).Put("up", Fn((V _self231, int _argc232, V p_238, V _a235, V _a236, V _a237, V[] _rest233) => {
V d_239 = default;
if (_self231.IsNullish) _self231 = GlobalV;
if (!(Truthy(drag_75))) {
return default;
}
d_239 = drag_75;
drag_75 = V.Null;
Call(toss_84, V.Undef, ((V)((ToNum(Get(p_238, "x")) - ToNum(Get(d_239, "x0"))))), ((V)((ToNum(Get(p_238, "y")) - ToNum(Get(d_239, "y0"))))));
return default;
}, 1, "up", false)).Put("key", Fn((V _self240, int _argc241, V k_247, V dn_248, V _a245, V _a246, V[] _rest242) => {
if (_self240.IsNullish) _self240 = GlobalV;
if (Truthy((dn_248 is var _t249 && !Truthy(_t249) ? _t249 : ((SEqS(k_247, " ") || SEqS(k_247, "ArrowUp")) ? V.True : V.False)))) {
Call(toss_84, V.Undef, ((V)(0D)), ((V)(112D)));
return (true ? V.True : V.False);
}
return default;
}, 2, "key", false)).Put("_toss", Fn((V _arrowThis258, int _argc250, V px_256, V py_257, V _a254, V _a255, V[] _rest251) => {
return Call(toss_84, V.Undef, px_256, py_257);
}, 2, "_toss", true)).Put("_state", Fn((V _arrowThis265, int _argc259, V _a261, V _a262, V _a263, V _a264, V[] _rest260) => {
return NewObj(5).Put("phase", ((V)(phase_80.Str))).Put("left", ((V)(left_73))).Put("score", Call(tally_85, V.Undef)).Put("wind", wind_76).Put("bags", Invoke(bags_72, "map", Fn((V _arrowThis273, int _argc266, V b_272, V _a269, V _a270, V _a271, V[] _rest267) => {
return ((V)(JsStrBuf.Begin().V(Get(b_272, "st8")).S("@").V(Invoke(Get(b_272, "x"), "toFixed", ((V)(2D)))).S(",").V(Invoke(Get(b_272, "z"), "toFixed", ((V)(2D)))).End()));
}, 1, "", true))).V;
}, 0, "_state", true)).Put("_wind", Fn((V _arrowThis281, int _argc274, V w_280, V _a277, V _a278, V _a279, V[] _rest275) => {
wind_76 = w_280;
return default;
}, 1, "_wind", true)).Put("celebrate", Fn((V _self282, int _argc283, V st_289, V _a286, V _a287, V _a288, V[] _rest284) => {
if (_self282.IsNullish) _self282 = GlobalV;
Invoke(me_67, "yaw", ((V)(0D)));
Invoke(me_67, "play", ((V)((GeN(st_289, 2D) ? "happy" : "idle"))));
return default;
}, 1, "celebrate", false)).Put("update", Fn((V _self290, int _argc291, V dt_297, V t_298, V _a295, V _a296, V[] _rest292) => {
V pull_299 = default;
double ts_300 = 0;
V E_301 = default;
if (_self290.IsNullish) _self290 = GlobalV;
tNow_77 = t_298;
{
foreach (V _k302 in new JsIter(bags_72)) {
V b_303 = default;
b_303 = _k302;
double n_304 = 0;
n_304 = 4D;
{
double i_305 = 0;
i_305 = 0D;
while (true) {
if (!((i_305 < n_304))) break;
double h_307 = 0;
h_307 = (ToNum(dt_297) / n_304);
if (SEqS(Get(b_303, "st8"), "fly")) {
V y0_308 = default;
OpSet(b_303, "vy", 1, ((V)((G_46 * h_307))));
OpSet(b_303, "vx", 0, ((V)((ToNum(wind_76) * h_307))));
OpSet(b_303, "x", 0, ((V)((ToNum(Get(b_303, "vx")) * h_307))));
OpSet(b_303, "y", 0, ((V)((ToNum(Get(b_303, "vy")) * h_307))));
OpSet(b_303, "z", 0, ((V)((ToNum(Get(b_303, "vz")) * h_307))));
OpSet(b_303, "rot", 0, ((V)((ToNum(Get(b_303, "vr")) * h_307))));
y0_308 = Call(yb_55, V.Undef, Get(b_303, "x"), Get(b_303, "z"));
if ((!y0_308.IsNullish && Le(Get(b_303, "y"), Add(y0_308, ((V)(0.02)))))) {
if ((Hypot(ToNum(Get(b_303, "x")), (ToNum(Get(b_303, "z")) - HZ_52)) < (HR_53 - 0.02))) {
V s_309 = default;
Set(b_303, "st8", ((V)("hole")));
Set(b_303, "ht", t_298);
Invoke(SFX_23, "swish");
Call(G("setTimeout"), V.Undef, Get(SFX_23, "score"), ((V)(60D)));
s_309 = Call(P_45, V.Undef, ((V)(0D)), ((V)(YB_51)), ((V)(HZ_52)));
Invoke(ctx_40, "toast", ((V)("Airmail! +3")), GetIdx(s_309, 0D), ((V)((ToNum(GetIdx(s_309, 1D)) - 40D))), ((V)("#ffe36e")));
Invoke(ctx_40, "burst", GetIdx(s_309, 0D), GetIdx(s_309, 1D), ((V)("confetti")), ((V)(14D)));
} else {
double hs_310 = 0;
Set(b_303, "st8", ((V)("slide")));
Set(b_303, "y", Add(y0_308, ((V)(0.02))));
hs_310 = (Hypot(ToNum(Get(b_303, "vx")), ToNum(Get(b_303, "vz"))) * 0.5);
Set(b_303, "sp", ((V)(hs_310)));
Set(b_303, "dir", Arr(((V)((ToNum(Get(b_303, "vx")) / ToNum((((V)(Hypot(ToNum(Get(b_303, "vx")), ToNum(Get(b_303, "vz"))))) is var _t311 && Truthy(_t311) ? _t311 : ((V)(1D))))))), ((V)((ToNum(Get(b_303, "vz")) / ToNum((((V)(Hypot(ToNum(Get(b_303, "vx")), ToNum(Get(b_303, "vz"))))) is var _t312 && Truthy(_t312) ? _t312 : ((V)(1D)))))))));
OpSet(b_303, "vr", 2, ((V)(0.2)));
Invoke(SFX_23, "thud");
}
} else {
if (LeN(Get(b_303, "y"), 0.03)) {
Set(b_303, "st8", ((V)("grass")));
Set(b_303, "y", ((V)(0.03)));
Invoke(SFX_23, "thud");
}
}
} else {
if (SEqS(Get(b_303, "st8"), "slide")) {
V y0_313 = default;
Set(b_303, "sp", ((V)(Max(0D, (ToNum(Get(b_303, "sp")) - (3.2 * h_307))))));
OpSet(b_303, "x", 0, ((V)(((ToNum(GetIdx(Get(b_303, "dir"), 0D)) * ToNum(Get(b_303, "sp"))) * h_307))));
OpSet(b_303, "z", 0, ((V)(((ToNum(GetIdx(Get(b_303, "dir"), 1D)) * ToNum(Get(b_303, "sp"))) * h_307))));
OpSet(b_303, "rot", 0, ((V)(((ToNum(Get(b_303, "vr")) * h_307) * 0.2))));
y0_313 = Call(yb_55, V.Undef, Get(b_303, "x"), Get(b_303, "z"));
if (y0_313.IsNullish) {
Set(b_303, "st8", ((V)("fall")));
Set(b_303, "vy", ((V)(0D)));
Set(b_303, "vx", ((V)((ToNum(GetIdx(Get(b_303, "dir"), 0D)) * ToNum(Get(b_303, "sp"))))));
Set(b_303, "vz", ((V)((ToNum(GetIdx(Get(b_303, "dir"), 1D)) * ToNum(Get(b_303, "sp"))))));
} else {
Set(b_303, "y", Add(y0_313, ((V)(0.02))));
if ((Hypot(ToNum(Get(b_303, "x")), (ToNum(Get(b_303, "z")) - HZ_52)) < (HR_53 - 0.035))) {
V s_314 = default;
Set(b_303, "st8", ((V)("hole")));
Set(b_303, "ht", t_298);
Invoke(SFX_23, "swish");
Call(G("setTimeout"), V.Undef, Get(SFX_23, "score"), ((V)(60D)));
s_314 = Call(P_45, V.Undef, ((V)(0D)), ((V)(YB_51)), ((V)(HZ_52)));
Invoke(ctx_40, "toast", ((V)("In the hole! +3")), GetIdx(s_314, 0D), ((V)((ToNum(GetIdx(s_314, 1D)) - 40D))), ((V)("#ffe36e")));
Invoke(ctx_40, "burst", GetIdx(s_314, 0D), GetIdx(s_314, 1D), ((V)("confetti")), ((V)(12D)));
}
{
foreach (V _k315 in new JsIter(bags_72)) {
V o_316 = default;
o_316 = _k315;
if (((!SEq(o_316, b_303) && (SEqS(Get(o_316, "st8"), "board") || SEqS(Get(o_316, "st8"), "slide"))) && (Hypot((ToNum(Get(o_316, "x")) - ToNum(Get(b_303, "x"))), (ToNum(Get(o_316, "z")) - ToNum(Get(b_303, "z")))) < (BS_54 * 2D)))) {
double nx_317 = 0;
double nz_318 = 0;
V nl_319 = default;
nx_317 = (ToNum(Get(o_316, "x")) - ToNum(Get(b_303, "x")));
nz_318 = (ToNum(Get(o_316, "z")) - ToNum(Get(b_303, "z")));
nl_319 = (((V)(Hypot(nx_317, nz_318))) is var _t320 && Truthy(_t320) ? _t320 : ((V)(1D)));
Set(o_316, "st8", ((V)("slide")));
Set(o_316, "dir", Arr(((V)((nx_317 / ToNum(nl_319)))), ((V)((nz_318 / ToNum(nl_319))))));
Set(o_316, "sp", ((V)(Max(ToNum((Get(o_316, "sp") is var _t321 && Truthy(_t321) ? _t321 : ((V)(0D)))), (ToNum(Get(b_303, "sp")) * 0.75)))));
OpSet(b_303, "sp", 2, ((V)(0.3)));
Set(o_316, "x", Add(Get(b_303, "x"), ((V)(((ToNum(GetIdx(Get(o_316, "dir"), 0D)) * BS_54) * 2.02)))));
Set(o_316, "z", Add(Get(b_303, "z"), ((V)(((ToNum(GetIdx(Get(o_316, "dir"), 1D)) * BS_54) * 2.02)))));
Invoke(SFX_23, "tap");
}
}
}
if (LeN(Get(b_303, "sp"), 0D)) {
Set(b_303, "st8", ((V)("board")));
}
}
} else {
if (SEqS(Get(b_303, "st8"), "fall")) {
OpSet(b_303, "vy", 1, ((V)((G_46 * h_307))));
OpSet(b_303, "x", 0, ((V)((ToNum(Get(b_303, "vx")) * h_307))));
OpSet(b_303, "z", 0, ((V)((ToNum(Get(b_303, "vz")) * h_307))));
OpSet(b_303, "y", 0, ((V)((ToNum(Get(b_303, "vy")) * h_307))));
if (LeN(Get(b_303, "y"), 0.03)) {
Set(b_303, "y", ((V)(0.03)));
Set(b_303, "st8", ((V)("grass")));
}
}
}
}
i_305++;
}
}
}
}
if (((string.Equals(phase_80.Str, "fly") && !(Truthy(Invoke(bags_72, "some", Fn((V _arrowThis329, int _argc322, V b_328, V _a325, V _a326, V _a327, V[] _rest323) => {
return (((SEqS(Get(b_328, "st8"), "fly") || SEqS(Get(b_328, "st8"), "slide")) || SEqS(Get(b_328, "st8"), "fall")) ? V.True : V.False);
}, 1, "", true))))) && ((ToNum(t_298) - ToNum(throwT_78)) > 500D))) {
V last_330 = default;
Call(settle_86, V.Undef);
phase_80.Set("wait");
settleT_79 = t_298;
last_330 = GetIdx(bags_72, (ToNum(Get(bags_72, "length")) - 1D));
if (SEqS(Get(last_330, "st8"), "board")) {
Invoke(ctx_40, "toast", ((V)("On the board +1")), ((V)((ToNum(W_43) / 2D))), ((V)((ToNum(H_44) * 0.36))), ((V)("#ffffff")));
} else {
if (SEqS(Get(last_330, "st8"), "grass")) {
Invoke(ctx_40, "toast", ((V)((LtN(Get(last_330, "z"), ZF_48) ? "Short" : "Missed"))), ((V)((ToNum(W_43) / 2D))), ((V)((ToNum(H_44) * 0.36))), ((V)("#ffffff")));
}
}
}
if ((string.Equals(phase_80.Str, "wait") && ((ToNum(t_298) - ToNum(settleT_79)) > 650D))) {
if ((left_73 > 0D)) {
cur_74 = Call(mkBag_82, V.Undef);
phase_80.Set("aim");
Call(newWind_83, V.Undef);
} else {
phase_80.Set("done");
Call(settle_86, V.Undef);
Invoke(ctx_40, "finish", NewObj(1).Put("sub", ((V)(JsStrBuf.Begin().N(inHole_81).S(" in the hole \u00b7 ").V(Get(Invoke(bags_72, "filter", Fn((V _arrowThis338, int _argc331, V b_337, V _a334, V _a335, V _a336, V[] _rest332) => {
return (SEqS(Get(b_337, "st8"), "board") ? V.True : V.False);
}, 1, "", true)), "length")).S(" on the board").End()))).V);
}
}
pull_299 = (Truthy(drag_75) ? Call(cl_19, V.Undef, ((V)((Hypot((ToNum(Get(drag_75, "x")) - ToNum(Get(drag_75, "x0"))), (ToNum(Get(drag_75, "y")) - ToNum(Get(drag_75, "y0")))) / 200D))), ((V)(0D)), ((V)(1D))) : ((V)(0D)));
ts_300 = (ToNum(t_298) - ToNum(throwT_78));
E_301 = ((ts_300 < 600D) ? Call(track_22, V.Undef, Arr(Arr(((V)(0D)), NewObj(3).Put("armR", ((V)((-40D)))).Put("lean", ((V)((-4D)))).Put("sq", ((V)(0.04))).V), Arr(((V)(120D)), NewObj(4).Put("armR", ((V)(165D))).Put("lean", ((V)(6D))).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(2D))).V), Arr(((V)(600D)), NewObj(4).Put("armR", ((V)(20D))).Put("lean", ((V)(0D))).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).V)), ((V)(ts_300))) : NewObj(4).Put("armR", Call(lerp_20, V.Undef, ((V)(30D)), ((V)((-60D))), pull_299)).Put("lean", ((V)(((-6D) * ToNum(pull_299))))).Put("sq", ((V)((0.06 * ToNum(pull_299))))).Put("armL", ((V)((20D + (30D * ToNum(pull_299)))))).V);
Invoke(me_67, "pose", E_301);
Invoke(me_67, "yaw", ((V)((198D + (FdLibm.Sin((ToNum(t_298) / 1100D)) * 4D)))));
{
V k_339 = default;
V @base_340 = default;
double w_341 = 0;
double sg_342 = 0;
double wv_343 = 0;
k_339 = wind_76;
@base_340 = fp2_64;
w_341 = (22D * (SEqN(k_339, 0D) ? 0.25 : Min(1D, ((System.Math.Abs(ToNum(k_339)) / 0.6) + 0.3))));
sg_342 = (SEqN(k_339, 0D) ? 1D : Sign(ToNum(k_339)));
wv_343 = (FdLibm.Sin((ToNum(t_298) / 120D)) * 3D);
Invoke(cloth_65, "setAttribute", ((V)("d")), ((V)(JsStrBuf.Begin().S("M").V(Call(r2_21, V.Undef, GetIdx(@base_340, 0D))).S(" ").V(Call(r2_21, V.Undef, GetIdx(@base_340, 1D))).S("Q").V(Call(r2_21, V.Undef, Add(GetIdx(@base_340, 0D), ((V)(((sg_342 * w_341) * 0.5)))))).S(" ").V(Call(r2_21, V.Undef, Add(Add(GetIdx(@base_340, 1D), ((V)(wv_343))), ((V)((SEqN(k_339, 0D) ? 8D : 0D)))))).S(" ").V(Call(r2_21, V.Undef, Add(GetIdx(@base_340, 0D), ((V)((sg_342 * w_341)))))).S(" ").V(Call(r2_21, V.Undef, Add(Add(Add(GetIdx(@base_340, 1D), ((V)(5D))), ((V)((wv_343 * 0.5)))), ((V)((SEqN(k_339, 0D) ? 10D : 0D)))))).S("L").V(Call(r2_21, V.Undef, GetIdx(@base_340, 0D))).S(" ").V(Call(r2_21, V.Undef, Add(GetIdx(@base_340, 1D), ((V)(13D))))).S("Z").End())));
}
if (Truthy(cur_74)) {
V k_344 = default;
k_344 = (Truthy(drag_75) ? Call(cl_19, V.Undef, ((V)((Hypot((ToNum(Get(drag_75, "x")) - ToNum(Get(drag_75, "x0"))), (ToNum(Get(drag_75, "y")) - ToNum(Get(drag_75, "y0")))) / 200D))), ((V)(0D)), ((V)(1D))) : ((V)(0D)));
Set(cur_74, "x", ((V)((ToNum(GetIdx(REL_71, 0D)) - (0.08 * ToNum(k_344))))));
Set(cur_74, "y", ((V)(((ToNum(GetIdx(REL_71, 1D)) - (0.12 * ToNum(k_344))) + (FdLibm.Sin((ToNum(t_298) / 380D)) * 0.01)))));
Set(cur_74, "z", ((V)((ToNum(GetIdx(REL_71, 2D)) - (0.1 * ToNum(k_344))))));
}
{
foreach (V _k345 in new JsIter(new ArrBuilder().Add(cur_74).Spread(bags_72).V)) {
V b_346 = default;
b_346 = _k345;
V onB_347 = default;
V s_348 = default;
double sc_349 = 0;
double o_350 = 0;
double sq_351 = 0;
V rr_352 = default;
double c_353 = 0;
double sn_354 = 0;
V pts_355 = default;
V m_356 = default;
JsStrBuf d_357 = null;
V g0y_358 = default;
V gy_359 = default;
V gs_360 = default;
V hk_361 = default;
if (!(Truthy(b_346))) {
continue;
}
onB_347 = ((((SEqS(Get(b_346, "st8"), "board") || SEqS(Get(b_346, "st8"), "slide")) || SEqS(Get(b_346, "st8"), "grass")) || SEqS(Get(b_346, "st8"), "hole")) ? V.True : V.False);
if (Truthy((onB_347 is var _t362 && !Truthy(_t362) ? _t362 : (!SEq(Get(Get(b_346, "g"), "parentNode"), restG_58) ? V.True : V.False)))) {
Invoke(restG_58, "appendChild", Get(b_346, "g"));
}
s_348 = Call(P_45, V.Undef, Get(b_346, "x"), Get(b_346, "y"), Get(b_346, "z"));
sc_349 = (ToNum(GetIdx(s_348, 2D)) * BS_54);
o_350 = 1D;
sq_351 = (Truthy(onB_347) ? 0.42 : 0.9);
if (SEqS(Get(b_346, "st8"), "hole")) {
V u_363 = default;
u_363 = Call(cl_19, V.Undef, ((V)(((ToNum(t_298) - ToNum(Get(b_346, "ht"))) / 260D))), ((V)(0D)), ((V)(1D)));
o_350 = (1D - ToNum(u_363));
sq_351 = (0.42 * (1D - (ToNum(u_363) * 0.5)));
}
rr_352 = (Get(b_346, "rot") is var _t364 && Truthy(_t364) ? _t364 : ((V)(0D)));
c_353 = FdLibm.Cos(((ToNum(rr_352) * System.Math.PI) / 180D));
sn_354 = FdLibm.Sin(((ToNum(rr_352) * System.Math.PI) / 180D));
pts_355 = Invoke(Arr(Arr(((V)((-1D))), ((V)((-1D)))), Arr(((V)(1D)), ((V)((-1D)))), Arr(((V)(1D)), ((V)(1D))), Arr(((V)((-1D))), ((V)(1D)))), "map", Fn((V _arrowThis376, int _argc365, V _a367, V _a368, V _a369, V _a370, V[] _rest366) => {
double X_377 = 0;
double Y_378 = 0;
V u_373 = default;
V v_375 = default;
{ V _t371 = ListOf(_a367);
{ V _t372 = GetIdx(_t371, 0D);
u_373 = _t372; }
{ V _t374 = GetIdx(_t371, 1D);
v_375 = _t374; }
}
X_377 = ((ToNum(u_373) * c_353) - (ToNum(v_375) * sn_354));
Y_378 = (((ToNum(u_373) * sn_354) + (ToNum(v_375) * c_353)) * sq_351);
return Arr(Add(GetIdx(s_348, 0D), ((V)((X_377 * sc_349)))), Add(GetIdx(s_348, 1D), ((V)((Y_378 * sc_349)))));
return default;
}, 1, "", true));
m_356 = Fn((V _arrowThis387, int _argc379, V a_385, V bb_386, V _a383, V _a384, V[] _rest380) => {
return Arr(((V)((ToNum(Add(GetIdx(a_385, 0D), GetIdx(bb_386, 0D))) / 2D))), ((V)((ToNum(Add(GetIdx(a_385, 1D), GetIdx(bb_386, 1D))) / 2D))));
}, 2, "", true);
d_357 = new JsStrBuf(JsStrBuf.Begin().S("M").V(Call(r2_21, V.Undef, GetIdx(Call(m_356, V.Undef, GetIdx(pts_355, 3D), GetIdx(pts_355, 0D)), 0D))).S(" ").V(Call(r2_21, V.Undef, GetIdx(Call(m_356, V.Undef, GetIdx(pts_355, 3D), GetIdx(pts_355, 0D)), 1D))).End());
{
double i_388 = 0;
i_388 = 0D;
while (true) {
if (!((i_388 < 4D))) break;
V a_390 = default;
V nb_391 = default;
V mm_392 = default;
a_390 = GetIdx(pts_355, i_388);
nb_391 = GetIdx(pts_355, ((i_388 + 1D) % 4D));
mm_392 = Call(m_356, V.Undef, a_390, nb_391);
d_357.S("Q").V(Call(r2_21, V.Undef, GetIdx(a_390, 0D))).S(" ").V(Call(r2_21, V.Undef, GetIdx(a_390, 1D))).S(" ").V(Call(r2_21, V.Undef, GetIdx(mm_392, 0D))).S(" ").V(Call(r2_21, V.Undef, GetIdx(mm_392, 1D)));
i_388++;
}
}
Invoke(Get(b_346, "b"), "setAttribute", ((V)("d")), ((V)(string.Concat(d_357.Str, "Z"))));
Invoke(Get(b_346, "st"), "setAttribute", ((V)("d")), Invoke(((V)(d_357.Str)), "replace", NewRegExp(RX0, "[-\\d.]+", "g"), Fn((V _arrowThis400, int _argc393, V v_399, V _a396, V _a397, V _a398, V[] _rest394) => {
return v_399;
}, 1, "", true)));
Invoke(Get(b_346, "st"), "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(s_348, 0D)) * 0.18))))).S(" ").V(Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(s_348, 1D)) * 0.18))))).S(") scale(0.82)").End())));
Invoke(Get(b_346, "g"), "setAttribute", ((V)("opacity")), Call(r2_21, V.Undef, ((V)(o_350))));
g0y_358 = Call(yb_55, V.Undef, Get(b_346, "x"), Get(b_346, "z"));
gy_359 = (((!g0y_358.IsNullish && !SEqS(Get(b_346, "st8"), "grass")) && !SEqS(Get(b_346, "st8"), "fall")) ? g0y_358 : ((V)(0D)));
gs_360 = Call(P_45, V.Undef, Get(b_346, "x"), gy_359, Get(b_346, "z"));
hk_361 = Call(cl_19, V.Undef, ((V)((1D - ((ToNum(Get(b_346, "y")) - ToNum(gy_359)) / 1.5)))), ((V)(0.3)), ((V)(1D)));
Invoke(Get(b_346, "sh"), "setAttribute", ((V)("cx")), Call(r2_21, V.Undef, GetIdx(gs_360, 0D)));
Invoke(Get(b_346, "sh"), "setAttribute", ((V)("cy")), Call(r2_21, V.Undef, GetIdx(gs_360, 1D)));
Invoke(Get(b_346, "sh"), "setAttribute", ((V)("rx")), Call(r2_21, V.Undef, ((V)(((sc_349 * 1.1) * ToNum(hk_361))))));
Invoke(Get(b_346, "sh"), "setAttribute", ((V)("ry")), Call(r2_21, V.Undef, ((V)(((sc_349 * 0.35) * ToNum(hk_361))))));
Invoke(Get(b_346, "sh"), "setAttribute", ((V)("opacity")), (SEqS(Get(b_346, "st8"), "hole") ? ((V)(0D)) : Call(r2_21, V.Undef, ((V)((0.22 * ToNum(hk_361)))))));
}
}
Set(guideG_61, "innerHTML", ((V)("")));
if (Truthy((drag_75 is var _t401 && !Truthy(_t401) ? _t401 : cur_74))) {
double px_402 = 0;
double py_403 = 0;
double len_404 = 0;
px_402 = (ToNum(Get(drag_75, "x")) - ToNum(Get(drag_75, "x0")));
py_403 = (ToNum(Get(drag_75, "y")) - ToNum(Get(drag_75, "y0")));
len_404 = Hypot(px_402, py_403);
if ((py_403 > 18D)) {
V p_405 = default;
double a_406 = 0;
double th_407 = 0;
double v_408 = 0;
double ph_409 = 0;
V x_410 = default;
V y_411 = default;
V z_412 = default;
double vx_413 = 0;
double vz_414 = 0;
double vy_415 = 0;
p_405 = Call(cl_19, V.Undef, ((V)((len_404 / 160D))), ((V)(0.05)), ((V)(1.3)));
a_406 = FdLibm.Atan2((-px_402), py_403);
th_407 = ((38D * System.Math.PI) / 180D);
v_408 = (3.6 + (ToNum(p_405) * 4.2));
ph_409 = (FdLibm.Atan2((-ToNum(GetIdx(REL_71, 0D))), (HZ_52 - ToNum(GetIdx(REL_71, 2D)))) + (a_406 * 0.42));
x_410 = Get(cur_74, "x");
y_411 = Get(cur_74, "y");
z_412 = Get(cur_74, "z");
vx_413 = ((FdLibm.Sin(ph_409) * v_408) * FdLibm.Cos(th_407));
vz_414 = ((FdLibm.Cos(ph_409) * v_408) * FdLibm.Cos(th_407));
vy_415 = (v_408 * FdLibm.Sin(th_407));
{
double i_416 = 0;
i_416 = 0D;
while (true) {
if (!((i_416 < 9D))) break;
double h_418 = 0;
V s_419 = default;
h_418 = 0.045;
vy_415 = (vy_415 - (G_46 * h_418));
x_410 = Add(x_410, ((V)((vx_413 * h_418))));
y_411 = Add(y_411, ((V)((vy_415 * h_418))));
z_412 = Add(z_412, ((V)((vz_414 * h_418))));
s_419 = Call(P_45, V.Undef, x_410, y_411, z_412);
Call(S_17, V.Undef, ((V)("circle")), NewObj(5).Put("cx", Call(r2_21, V.Undef, GetIdx(s_419, 0D))).Put("cy", Call(r2_21, V.Undef, GetIdx(s_419, 1D))).Put("r", Call(r2_21, V.Undef, ((V)(Max(1.5, (3.4 - (i_416 * 0.2))))))).Put("fill", ((V)("#ffffff"))).Put("opacity", Call(r2_21, V.Undef, ((V)((0.9 - (i_416 * 0.08)))))).V, guideG_61);
i_416++;
}
}
}
}
return default;
}, 2, "update", false)).V;
Call(newWind_83, V.Undef);
cur_74 = Call(mkBag_82, V.Undef);
return api_87;
return default;
}, 1, "make", false)).V);
return default;
}, 0, "", true);
Call(go_8, V.Undef);
return default;
}, 0, "", false), V.Undef);
        }
    }
}
