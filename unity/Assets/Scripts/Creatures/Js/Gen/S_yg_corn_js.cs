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
go_8 = Fn((V _self1, int _argc9, V _a11, V _a12, V _a13, V _a14, V[] _rest10) => {
V YG_15 = default;
V S_16 = default;
V D_17 = default;
V cl_18 = default;
V lerp_19 = default;
V r2_20 = default;
V track_21 = default;
V SFX_22 = default;
V ICON_23 = default;
YG_15 = Get(G("window"), "YardGames");
if (((!(Truthy(YG_15)) || !(Truthy(Get(YG_15, "add")))) || !(Truthy(Get(YG_15, "cam"))))) {
return Call(G("setTimeout"), V.Undef, go_8, ((V)(30D)));
}
{ V _t24 = YG_15;
if (_t24.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t24));
{ V _t25 = Get(_t24, "S");
S_16 = _t25; }
{ V _t26 = Get(_t24, "D");
D_17 = _t26; }
{ V _t27 = Get(_t24, "cl");
cl_18 = _t27; }
{ V _t28 = Get(_t24, "lerp");
lerp_19 = _t28; }
{ V _t29 = Get(_t24, "r2");
r2_20 = _t29; }
{ V _t30 = Get(_t24, "track");
track_21 = _t30; }
{ V _t31 = Get(_t24, "SFX");
SFX_22 = _t31; } }
ICON_23 = ((V)(string.Concat("<svg viewBox=\"0 0 120 84\" aria-hidden=\"true\"><rect width=\"120\" height=\"84\" fill=\"#cfeaff\"/><rect y=\"34\" width=\"120\" height=\"50\" fill=\"#9fdc6e\"/>", "<path d=\"M38 72L50 30H70L82 72Z\" fill=\"#3b7fe0\"/><path d=\"M38 72H82V77H38Z\" fill=\"#2a5fb0\"/><path d=\"M44 52H76\" stroke=\"#fff\" stroke-width=\"3\" opacity=\"0.8\"/><ellipse cx=\"60\" cy=\"38\" rx=\"6\" ry=\"2.6\" fill=\"#1b2a44\"/>", "<rect x=\"51\" y=\"58\" width=\"12\" height=\"9\" rx=\"3\" fill=\"#e8483c\" transform=\"rotate(-8 57 62)\"/><rect x=\"88\" y=\"16\" width=\"12\" height=\"9\" rx=\"3\" fill=\"#e8483c\" transform=\"rotate(20 94 20)\"/><path d=\"M92 28Q80 30 72 40\" stroke=\"#fff\" stroke-width=\"1.6\" stroke-dasharray=\"2 3\" fill=\"none\"/></svg>")));
Invoke(YG_15, "add", NewObj(11).Put("id", ((V)("corn"))).Put("land", (true ? V.True : V.False)).Put("name", ((V)("Cornhole"))).Put("item", ((V)("Cornhole Boards"))).Put("color", ((V)("#4f8fff"))).Put("icon", ICON_23).Put("stars", Arr(((V)(8D)), ((V)(13D)), ((V)(18D)))).Put("coinK", ((V)(2D))).Put("hint", ((V)("Pull back and let go to toss \u00b7 mind the wind"))).Put("how", Arr(((V)("Pull back from anywhere and let go to toss your bean bag.")), ((V)("Pull further to throw farther; pull to one side to aim the other way.")), ((V)("8 bags. On the board = 1, in the hole = 3. Watch the wind flag!")))).Put("make", Fn((V _self32, int _argc33, V ctx_39, V _a36, V _a37, V _a38, V[] _rest34) => {
V bg_40 = default;
V fg_41 = default;
V W_42 = default;
V H_43 = default;
V P_44 = default;
double G_45 = 0;
double BW_46 = 0;
double ZF_47 = 0;
double ZB_48 = 0;
double YF_49 = 0;
double YB_50 = 0;
double HZ_51 = 0;
double HR_52 = 0;
double BS_53 = 0;
V yb_54 = default;
V quad_55 = default;
V boardG_56 = default;
V restG_57 = default;
V shG_58 = default;
V flyG_59 = default;
V guideG_60 = default;
V flag_61 = default;
V fp_62 = default;
V fp2_63 = default;
V cloth_64 = default;
V windTx_65 = default;
V me_66 = default;
double mz_67 = 0;
double mx_68 = 0;
V mp_69 = default;
V REL_70 = default;
V bags_71 = default;
double left_72 = 0;
V cur_73 = default;
V drag_74 = default;
V wind_75 = default;
V tNow_76 = default;
V throwT_77 = default;
V settleT_78 = default;
JsStrBuf phase_79 = null;
double inHole_80 = 0;
V mkBag_81 = default;
V newWind_82 = default;
V toss_83 = default;
V tally_84 = default;
V settle_85 = default;
V api_86 = default;
if (_self32.IsNullish) _self32 = GlobalV;
mkBag_81 = Fn((V _self87, int _argc88, V _a90, V _a91, V _a92, V _a93, V[] _rest89) => {
V g_94 = default;
V sh_95 = default;
V b_96 = default;
V st_97 = default;
if (_self87.IsNullish) _self87 = GlobalV;
g_94 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, flyG_59);
sh_95 = Call(S_16, V.Undef, ((V)("ellipse")), NewObj(2).Put("fill", ((V)("#3a2a55"))).Put("opacity", ((V)(0.18))).V, shG_58);
b_96 = Call(S_16, V.Undef, ((V)("path")), NewObj(3).Put("fill", ((V)("#e8483c"))).Put("stroke", ((V)("#b5322a"))).Put("stroke-width", ((V)(1D))).V, g_94);
st_97 = Call(S_16, V.Undef, ((V)("path")), NewObj(4).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffd2cc"))).Put("stroke-width", ((V)(0.9))).Put("stroke-dasharray", ((V)("1.6 1.6"))).V, g_94);
return NewObj(15).Put("g", g_94).Put("sh", sh_95).Put("b", b_96).Put("st", st_97).Put("x", GetIdx(REL_70, 0D)).Put("y", GetIdx(REL_70, 1D)).Put("z", GetIdx(REL_70, 2D)).Put("vx", ((V)(0D))).Put("vy", ((V)(0D))).Put("vz", ((V)(0D))).Put("rot", ((V)(0D))).Put("vr", ((V)(0D))).Put("st8", ((V)("hand"))).Put("sp", ((V)(0D))).Put("dir", Arr(((V)(0D)), ((V)(1D)))).V;
return default;
}, 0, "mkBag", false);
newWind_82 = Fn((V _self98, int _argc99, V _a101, V _a102, V _a103, V _a104, V[] _rest100) => {
if (_self98.IsNullish) _self98 = GlobalV;
wind_75 = ((V)((Round((((ToNum(Invoke(G("Math"), "random")) - 0.5) * 2D) * 6D)) / 10D)));
Set(windTx_65, "textContent", ((V)((SEqN(wind_75, 0D) ? "No wind" : JsStrBuf.Begin().S("Wind ").S((LtN(wind_75, 0D) ? "\u2190 " : "\u2192 ")).V(Invoke(((V)(System.Math.Abs(ToNum(wind_75)))), "toFixed", ((V)(1D)))).End()))));
return default;
}, 0, "newWind", false);
toss_83 = Fn((V _self105, int _argc106, V px_112, V py_113, V _a110, V _a111, V[] _rest107) => {
double len_114 = 0;
V p_115 = default;
double a_116 = 0;
double th_117 = 0;
double v_118 = 0;
double ph_119 = 0;
if (_self105.IsNullish) _self105 = GlobalV;
if ((!(Truthy(cur_73)) || !string.Equals(phase_79.Str, "aim"))) {
return default;
}
len_114 = Hypot(ToNum(px_112), ToNum(py_113));
if ((LtN(py_113, 18D) || (len_114 < 30D))) {
Set(cur_73, "st8", ((V)("hand")));
return default;
}
p_115 = Call(cl_18, V.Undef, ((V)((len_114 / 160D))), ((V)(0.05)), ((V)(1.3)));
a_116 = FdLibm.Atan2((-ToNum(px_112)), ToNum(py_113));
th_117 = ((38D * System.Math.PI) / 180D);
v_118 = (3.6 + (ToNum(p_115) * 4.2));
ph_119 = (FdLibm.Atan2((-ToNum(GetIdx(REL_70, 0D))), (HZ_51 - ToNum(GetIdx(REL_70, 2D)))) + (a_116 * 0.42));
Object_assign(cur_73, NewObj(5).Put("st8", ((V)("fly"))).Put("vx", ((V)(((FdLibm.Sin(ph_119) * v_118) * FdLibm.Cos(th_117))))).Put("vz", ((V)(((FdLibm.Cos(ph_119) * v_118) * FdLibm.Cos(th_117))))).Put("vy", ((V)((v_118 * FdLibm.Sin(th_117))))).Put("vr", ((V)(((ToNum(Invoke(G("Math"), "random")) - 0.5) * 700D)))).V);
Invoke(bags_71, "push", cur_73);
cur_73 = V.Null;
left_72--;
phase_79.Set("fly");
throwT_77 = tNow_76;
Invoke(SFX_22, "whoosh");
Invoke(ctx_39, "timer", ((V)(JsStrBuf.Begin().S("Bags ").N(left_72).End())));
return default;
}, 2, "toss", false);
tally_84 = Fn((V _self120, int _argc121, V _a123, V _a124, V _a125, V _a126, V[] _rest122) => {
double s_127 = 0;
if (_self120.IsNullish) _self120 = GlobalV;
s_127 = 0D;
inHole_80 = 0D;
Invoke(bags_71, "forEach", Fn((V _self120, int _argc128, V b_134, V _a131, V _a132, V _a133, V[] _rest129) => {
if (SEqS(Get(b_134, "st8"), "hole")) {
s_127 = (s_127 + 3D);
inHole_80++;
} else {
if (((SEqS(Get(b_134, "st8"), "board") || SEqS(Get(b_134, "st8"), "slide")) && !Call(yb_54, V.Undef, Get(b_134, "x"), Get(b_134, "z")).IsNullish)) {
s_127 = (s_127 + 1D);
}
}
return default;
}, 1, "", true));
return ((V)(s_127));
return default;
}, 0, "tally", false);
settle_85 = Fn((V _self135, int _argc136, V _a138, V _a139, V _a140, V _a141, V[] _rest137) => {
V before_142 = default;
V now_143 = default;
if (_self135.IsNullish) _self135 = GlobalV;
before_142 = Get(ctx_39, "score");
now_143 = Call(tally_84, V.Undef);
if (!SEq(now_143, before_142)) {
Invoke(ctx_39, "setScore", now_143);
}
return default;
}, 0, "settle", false);
{ V _t144 = ctx_39;
if (_t144.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t144));
{ V _t145 = Get(_t144, "bg");
bg_40 = _t145; }
{ V _t146 = Get(_t144, "fg");
fg_41 = _t146; }
{ V _t147 = Get(_t144, "W");
W_42 = _t147; }
{ V _t148 = Get(_t144, "H");
H_43 = _t148; } }
P_44 = Invoke(YG_15, "cam", ((V)(2.4)), ((V)(1.45)), ((V)(116D)), ((V)(206D)));
G_45 = 9.8;
BW_46 = 0.86;
ZF_47 = 3D;
ZB_48 = 4.6;
YF_49 = 0.08;
YB_50 = 0.34;
HZ_51 = 4.3;
HR_52 = 0.115;
BS_53 = 0.075;
Invoke(YG_15, "yard", bg_40, NewObj(1).Put("hz", ((V)(116D))).V);
yb_54 = Fn((V _self32, int _argc149, V x_155, V z_156, V _a153, V _a154, V[] _rest150) => {
return ((((System.Math.Abs(ToNum(x_155)) <= (BW_46 / 2D)) && GeN(z_156, ZF_47)) && LeN(z_156, ZB_48)) ? Call(lerp_19, V.Undef, ((V)(YF_49)), ((V)(YB_50)), ((V)(((ToNum(z_156) - ZF_47) / (ZB_48 - ZF_47))))) : V.Null);
}, 2, "", true);
quad_55 = Fn((V _self32, int _argc157, V pts_163, V a_164, V p_165, V _a162, V[] _rest158) => {
return Call(S_16, V.Undef, ((V)("path")), Object_assign(NewObj(1).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_163, "map", Fn((V _self32, int _argc166, V q_172, V _a169, V _a170, V _a171, V[] _rest167) => {
V s_173 = default;
s_173 = Call(P_44, V.Undef, GetIdx(q_172, 0D), GetIdx(q_172, 1D), GetIdx(q_172, 2D));
return ((V)(JsStrBuf.Begin().V(Call(r2_20, V.Undef, GetIdx(s_173, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(s_173, 1D))).End()));
return default;
}, 1, "", true)), "join", ((V)("L")))).S("Z").End()))).V, a_164), (p_165 is var _t174 && Truthy(_t174) ? _t174 : bg_40));
}, 3, "", true);
boardG_56 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, bg_40);
{
V g0_175 = default;
double zm_176 = 0;
JsStrBuf d_177 = null;
g0_175 = Call(P_44, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(((ZF_47 + ZB_48) / 2D))));
Invoke(YG_15, "shadow", boardG_56, GetIdx(g0_175, 0D), Add(GetIdx(g0_175, 1D), ((V)(6D))), ((V)((0.62 * ToNum(GetIdx(g0_175, 2D))))), ((V)(0.2)));
Invoke(Arr(Arr(((V)((((-BW_46) / 2D) + 0.06)))), Arr(((V)(((BW_46 / 2D) - 0.06))))), "forEach", Fn((V _self32, int _argc178, V _a180, V _a181, V _a182, V _a183, V[] _rest179) => {
V x_186 = default;
{ V _t184 = ListOf(_a180);
{ V _t185 = GetIdx(_t184, 0D);
x_186 = _t185; }
}
return Call(quad_55, V.Undef, Arr(Arr(((V)((ToNum(x_186) - 0.025))), ((V)(0D)), ((V)((ZB_48 - 0.05)))), Arr(Add(x_186, ((V)(0.025))), ((V)(0D)), ((V)((ZB_48 - 0.05)))), Arr(Add(x_186, ((V)(0.025))), ((V)(YB_50)), ((V)((ZB_48 - 0.05)))), Arr(((V)((ToNum(x_186) - 0.025))), ((V)(YB_50)), ((V)((ZB_48 - 0.05))))), NewObj(1).Put("fill", ((V)("#1d4fa0"))).V, boardG_56);
}, 1, "", true));
Call(quad_55, V.Undef, Arr(Arr(((V)(((-BW_46) / 2D))), ((V)((YF_49 - 0.06))), ((V)(ZF_47))), Arr(((V)((BW_46 / 2D))), ((V)((YF_49 - 0.06))), ((V)(ZF_47))), Arr(((V)((BW_46 / 2D))), ((V)(YF_49)), ((V)(ZF_47))), Arr(((V)(((-BW_46) / 2D))), ((V)(YF_49)), ((V)(ZF_47)))), NewObj(1).Put("fill", ((V)("#2a5fb0"))).V, boardG_56);
Call(quad_55, V.Undef, Arr(Arr(((V)(((-BW_46) / 2D))), ((V)(YF_49)), ((V)(ZF_47))), Arr(((V)((BW_46 / 2D))), ((V)(YF_49)), ((V)(ZF_47))), Arr(((V)((BW_46 / 2D))), ((V)(YB_50)), ((V)(ZB_48))), Arr(((V)(((-BW_46) / 2D))), ((V)(YB_50)), ((V)(ZB_48)))), NewObj(1).Put("fill", ((V)("#3b7fe0"))).V, boardG_56);
Call(quad_55, V.Undef, Arr(Arr(((V)((((-BW_46) / 2D) + 0.04))), ((V)((YF_49 + 0.003))), ((V)((ZF_47 + 0.04)))), Arr(((V)(((BW_46 / 2D) - 0.04))), ((V)((YF_49 + 0.003))), ((V)((ZF_47 + 0.04)))), Arr(((V)(((BW_46 / 2D) - 0.04))), ((V)((YB_50 + 0.003))), ((V)((ZB_48 - 0.04)))), Arr(((V)((((-BW_46) / 2D) + 0.04))), ((V)((YB_50 + 0.003))), ((V)((ZB_48 - 0.04))))), NewObj(4).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(1.6))).Put("opacity", ((V)(0.55))).V, boardG_56);
zm_176 = (ZF_47 + 0.55);
Call(quad_55, V.Undef, Arr(Arr(((V)(((-BW_46) / 2D))), Call(lerp_19, V.Undef, ((V)(YF_49)), ((V)(YB_50)), ((V)(((zm_176 - ZF_47) / 1.6)))), ((V)(zm_176))), Arr(((V)((BW_46 / 2D))), Call(lerp_19, V.Undef, ((V)(YF_49)), ((V)(YB_50)), ((V)(((zm_176 - ZF_47) / 1.6)))), ((V)(zm_176))), Arr(((V)((BW_46 / 2D))), Call(lerp_19, V.Undef, ((V)(YF_49)), ((V)(YB_50)), ((V)((((zm_176 + 0.08) - ZF_47) / 1.6)))), ((V)((zm_176 + 0.08)))), Arr(((V)(((-BW_46) / 2D))), Call(lerp_19, V.Undef, ((V)(YF_49)), ((V)(YB_50)), ((V)((((zm_176 + 0.08) - ZF_47) / 1.6)))), ((V)((zm_176 + 0.08))))), NewObj(2).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0.8))).V, boardG_56);
d_177 = new JsStrBuf("");
{
double i_187 = 0;
i_187 = 0D;
while (true) {
if (!((i_187 <= 24D))) break;
double a_189 = 0;
double x_190 = 0;
double z_191 = 0;
V s_192 = default;
a_189 = (((i_187 / 24D) * System.Math.PI) * 2D);
x_190 = (FdLibm.Cos(a_189) * HR_52);
z_191 = (HZ_51 + (FdLibm.Sin(a_189) * HR_52));
s_192 = Call(P_44, V.Undef, ((V)(x_190)), Add(Call(lerp_19, V.Undef, ((V)(YF_49)), ((V)(YB_50)), ((V)(((z_191 - ZF_47) / 1.6)))), ((V)(0.002))), ((V)(z_191)));
d_177.S((NumTruthy(i_187) ? "L" : "M")).V(Call(r2_20, V.Undef, GetIdx(s_192, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(s_192, 1D)));
i_187++;
}
}
Call(S_16, V.Undef, ((V)("path")), NewObj(4).Put("d", ((V)(string.Concat(d_177.Str, "Z")))).Put("fill", ((V)("#14213a"))).Put("stroke", ((V)("#2a5fb0"))).Put("stroke-width", ((V)(1.5))).V, boardG_56);
}
restG_57 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, bg_40);
shG_58 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, bg_40);
flyG_59 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, fg_41);
guideG_60 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, fg_41);
flag_61 = Call(S_16, V.Undef, ((V)("g")), NewObj(0).V, bg_40);
fp_62 = Call(P_44, V.Undef, ((V)(((BW_46 / 2D) + 0.45))), ((V)(0D)), ((V)((ZB_48 - 0.1))));
fp2_63 = Call(P_44, V.Undef, ((V)(((BW_46 / 2D) + 0.45))), ((V)(1.25)), ((V)((ZB_48 - 0.1))));
Call(S_16, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, GetIdx(fp_62, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(fp_62, 1D))).S("L").V(Call(r2_20, V.Undef, GetIdx(fp2_63, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(fp2_63, 1D))).End()))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(2.4))).V, flag_61);
cloth_64 = Call(S_16, V.Undef, ((V)("path")), NewObj(3).Put("fill", ((V)("#ffcf3a"))).Put("stroke", ((V)("#e09a14"))).Put("stroke-width", ((V)(1D))).V, flag_61);
windTx_65 = Call(D_17, V.Undef, ((V)("div")), NewObj(2).Put("cls", ((V)("yg-pill"))).Put("style", ((V)("position:absolute;right:3%;top:12.5%;font-size:13px;padding:5px 9px;"))).V, Invoke(Get(Get(ctx_39, "crl"), "parentNode"), "querySelector", ((V)(".yg-hud"))));
me_66 = Invoke(ctx_39, "creature", Get(ctx_39, "playerKey"), NewObj(1).Put("yaw", ((V)(198D))).V);
mz_67 = 0.42;
mx_68 = (-0.42);
mp_69 = Call(P_44, V.Undef, ((V)(mx_68)), ((V)(0D)), ((V)(mz_67)));
Invoke(me_66, "set", GetIdx(mp_69, 0D), GetIdx(mp_69, 1D), ((V)((0.78 * ToNum(GetIdx(mp_69, 2D))))));
Invoke(YG_15, "shadow", shG_58, GetIdx(mp_69, 0D), ((V)((ToNum(GetIdx(mp_69, 1D)) - 2D))), ((V)((0.3 * ToNum(GetIdx(mp_69, 2D))))), ((V)(0.2)));
REL_70 = Arr(((V)((mx_68 + 0.2))), ((V)(0.72)), ((V)((mz_67 + 0.18))));
bags_71 = Arr();
left_72 = 8D;
cur_73 = V.Null;
drag_74 = V.Null;
wind_75 = ((V)(0D));
tNow_76 = ((V)(0D));
throwT_77 = ((V)((-9D)));
settleT_78 = ((V)(0D));
phase_79 = new JsStrBuf("aim");
inHole_80 = 0D;
api_86 = NewObj(10).Put("start", Fn((V _self193, int _argc194, V _a196, V _a197, V _a198, V _a199, V[] _rest195) => {
if (_self193.IsNullish) _self193 = GlobalV;
Invoke(bags_71, "forEach", Fn((V _self193, int _argc200, V b_206, V _a203, V _a204, V _a205, V[] _rest201) => {
Invoke(Get(b_206, "g"), "remove");
Invoke(Get(b_206, "sh"), "remove");
return default;
}, 1, "", true));
bags_71 = Arr();
left_72 = 8D;
cur_73 = Call(mkBag_81, V.Undef);
phase_79.Set("aim");
Invoke(ctx_39, "setScore", ((V)(0D)));
Invoke(ctx_39, "timer", ((V)("Bags 8")));
Call(newWind_82, V.Undef);
return default;
}, 0, "start", false)).Put("down", Fn((V _self207, int _argc208, V p_214, V _a211, V _a212, V _a213, V[] _rest209) => {
if (_self207.IsNullish) _self207 = GlobalV;
if (Truthy(((string.Equals(phase_79.Str, "aim") ? V.True : V.False) is var _t215 && !Truthy(_t215) ? _t215 : cur_73))) {
drag_74 = NewObj(4).Put("x0", Get(p_214, "x")).Put("y0", Get(p_214, "y")).Put("x", Get(p_214, "x")).Put("y", Get(p_214, "y")).V;
}
return default;
}, 1, "down", false)).Put("move", Fn((V _self216, int _argc217, V p_223, V _a220, V _a221, V _a222, V[] _rest218) => {
if (_self216.IsNullish) _self216 = GlobalV;
if (Truthy(drag_74)) {
Set(drag_74, "x", Get(p_223, "x"));
Set(drag_74, "y", Get(p_223, "y"));
}
return default;
}, 1, "move", false)).Put("up", Fn((V _self224, int _argc225, V p_231, V _a228, V _a229, V _a230, V[] _rest226) => {
V d_232 = default;
if (_self224.IsNullish) _self224 = GlobalV;
if (!(Truthy(drag_74))) {
return default;
}
d_232 = drag_74;
drag_74 = V.Null;
Call(toss_83, V.Undef, ((V)((ToNum(Get(p_231, "x")) - ToNum(Get(d_232, "x0"))))), ((V)((ToNum(Get(p_231, "y")) - ToNum(Get(d_232, "y0"))))));
return default;
}, 1, "up", false)).Put("key", Fn((V _self233, int _argc234, V k_240, V dn_241, V _a238, V _a239, V[] _rest235) => {
if (_self233.IsNullish) _self233 = GlobalV;
if (Truthy((dn_241 is var _t242 && !Truthy(_t242) ? _t242 : ((SEqS(k_240, " ") || SEqS(k_240, "ArrowUp")) ? V.True : V.False)))) {
Call(toss_83, V.Undef, ((V)(0D)), ((V)(112D)));
return (true ? V.True : V.False);
}
return default;
}, 2, "key", false)).Put("_toss", Fn((V _self32, int _argc243, V px_249, V py_250, V _a247, V _a248, V[] _rest244) => {
return Call(toss_83, V.Undef, px_249, py_250);
}, 2, "_toss", true)).Put("_state", Fn((V _self32, int _argc251, V _a253, V _a254, V _a255, V _a256, V[] _rest252) => {
return NewObj(5).Put("phase", ((V)(phase_79.Str))).Put("left", ((V)(left_72))).Put("score", Call(tally_84, V.Undef)).Put("wind", wind_75).Put("bags", Invoke(bags_71, "map", Fn((V _self32, int _argc257, V b_263, V _a260, V _a261, V _a262, V[] _rest258) => {
return ((V)(JsStrBuf.Begin().V(Get(b_263, "st8")).S("@").V(Invoke(Get(b_263, "x"), "toFixed", ((V)(2D)))).S(",").V(Invoke(Get(b_263, "z"), "toFixed", ((V)(2D)))).End()));
}, 1, "", true))).V;
}, 0, "_state", true)).Put("_wind", Fn((V _self32, int _argc264, V w_270, V _a267, V _a268, V _a269, V[] _rest265) => {
wind_75 = w_270;
return default;
}, 1, "_wind", true)).Put("celebrate", Fn((V _self271, int _argc272, V st_278, V _a275, V _a276, V _a277, V[] _rest273) => {
if (_self271.IsNullish) _self271 = GlobalV;
Invoke(me_66, "yaw", ((V)(0D)));
Invoke(me_66, "play", ((V)((GeN(st_278, 2D) ? "happy" : "idle"))));
return default;
}, 1, "celebrate", false)).Put("update", Fn((V _self279, int _argc280, V dt_286, V t_287, V _a284, V _a285, V[] _rest281) => {
V pull_288 = default;
double ts_289 = 0;
V E_290 = default;
if (_self279.IsNullish) _self279 = GlobalV;
tNow_76 = t_287;
{
foreach (V _k291 in new JsIter(bags_71)) {
V b_292 = default;
b_292 = _k291;
double n_293 = 0;
n_293 = 4D;
{
double i_294 = 0;
i_294 = 0D;
while (true) {
if (!((i_294 < n_293))) break;
double h_296 = 0;
h_296 = (ToNum(dt_286) / n_293);
if (SEqS(Get(b_292, "st8"), "fly")) {
V y0_297 = default;
OpSet(b_292, "vy", 1, ((V)((G_45 * h_296))));
OpSet(b_292, "vx", 0, ((V)((ToNum(wind_75) * h_296))));
OpSet(b_292, "x", 0, ((V)((ToNum(Get(b_292, "vx")) * h_296))));
OpSet(b_292, "y", 0, ((V)((ToNum(Get(b_292, "vy")) * h_296))));
OpSet(b_292, "z", 0, ((V)((ToNum(Get(b_292, "vz")) * h_296))));
OpSet(b_292, "rot", 0, ((V)((ToNum(Get(b_292, "vr")) * h_296))));
y0_297 = Call(yb_54, V.Undef, Get(b_292, "x"), Get(b_292, "z"));
if ((!y0_297.IsNullish && Le(Get(b_292, "y"), Add(y0_297, ((V)(0.02)))))) {
if ((Hypot(ToNum(Get(b_292, "x")), (ToNum(Get(b_292, "z")) - HZ_51)) < (HR_52 - 0.02))) {
V s_298 = default;
Set(b_292, "st8", ((V)("hole")));
Set(b_292, "ht", t_287);
Invoke(SFX_22, "swish");
Call(G("setTimeout"), V.Undef, Get(SFX_22, "score"), ((V)(60D)));
s_298 = Call(P_44, V.Undef, ((V)(0D)), ((V)(YB_50)), ((V)(HZ_51)));
Invoke(ctx_39, "toast", ((V)("Airmail! +3")), GetIdx(s_298, 0D), ((V)((ToNum(GetIdx(s_298, 1D)) - 40D))), ((V)("#ffe36e")));
Invoke(ctx_39, "burst", GetIdx(s_298, 0D), GetIdx(s_298, 1D), ((V)("confetti")), ((V)(14D)));
} else {
double hs_299 = 0;
Set(b_292, "st8", ((V)("slide")));
Set(b_292, "y", Add(y0_297, ((V)(0.02))));
hs_299 = (Hypot(ToNum(Get(b_292, "vx")), ToNum(Get(b_292, "vz"))) * 0.5);
Set(b_292, "sp", ((V)(hs_299)));
Set(b_292, "dir", Arr(((V)((ToNum(Get(b_292, "vx")) / ToNum((((V)(Hypot(ToNum(Get(b_292, "vx")), ToNum(Get(b_292, "vz"))))) is var _t300 && Truthy(_t300) ? _t300 : ((V)(1D))))))), ((V)((ToNum(Get(b_292, "vz")) / ToNum((((V)(Hypot(ToNum(Get(b_292, "vx")), ToNum(Get(b_292, "vz"))))) is var _t301 && Truthy(_t301) ? _t301 : ((V)(1D)))))))));
OpSet(b_292, "vr", 2, ((V)(0.2)));
Invoke(SFX_22, "thud");
}
} else {
if (LeN(Get(b_292, "y"), 0.03)) {
Set(b_292, "st8", ((V)("grass")));
Set(b_292, "y", ((V)(0.03)));
Invoke(SFX_22, "thud");
}
}
} else {
if (SEqS(Get(b_292, "st8"), "slide")) {
V y0_302 = default;
Set(b_292, "sp", ((V)(Max(0D, (ToNum(Get(b_292, "sp")) - (3.2 * h_296))))));
OpSet(b_292, "x", 0, ((V)(((ToNum(GetIdx(Get(b_292, "dir"), 0D)) * ToNum(Get(b_292, "sp"))) * h_296))));
OpSet(b_292, "z", 0, ((V)(((ToNum(GetIdx(Get(b_292, "dir"), 1D)) * ToNum(Get(b_292, "sp"))) * h_296))));
OpSet(b_292, "rot", 0, ((V)(((ToNum(Get(b_292, "vr")) * h_296) * 0.2))));
y0_302 = Call(yb_54, V.Undef, Get(b_292, "x"), Get(b_292, "z"));
if (y0_302.IsNullish) {
Set(b_292, "st8", ((V)("fall")));
Set(b_292, "vy", ((V)(0D)));
Set(b_292, "vx", ((V)((ToNum(GetIdx(Get(b_292, "dir"), 0D)) * ToNum(Get(b_292, "sp"))))));
Set(b_292, "vz", ((V)((ToNum(GetIdx(Get(b_292, "dir"), 1D)) * ToNum(Get(b_292, "sp"))))));
} else {
Set(b_292, "y", Add(y0_302, ((V)(0.02))));
if ((Hypot(ToNum(Get(b_292, "x")), (ToNum(Get(b_292, "z")) - HZ_51)) < (HR_52 - 0.035))) {
V s_303 = default;
Set(b_292, "st8", ((V)("hole")));
Set(b_292, "ht", t_287);
Invoke(SFX_22, "swish");
Call(G("setTimeout"), V.Undef, Get(SFX_22, "score"), ((V)(60D)));
s_303 = Call(P_44, V.Undef, ((V)(0D)), ((V)(YB_50)), ((V)(HZ_51)));
Invoke(ctx_39, "toast", ((V)("In the hole! +3")), GetIdx(s_303, 0D), ((V)((ToNum(GetIdx(s_303, 1D)) - 40D))), ((V)("#ffe36e")));
Invoke(ctx_39, "burst", GetIdx(s_303, 0D), GetIdx(s_303, 1D), ((V)("confetti")), ((V)(12D)));
}
{
foreach (V _k304 in new JsIter(bags_71)) {
V o_305 = default;
o_305 = _k304;
if (((!SEq(o_305, b_292) && (SEqS(Get(o_305, "st8"), "board") || SEqS(Get(o_305, "st8"), "slide"))) && (Hypot((ToNum(Get(o_305, "x")) - ToNum(Get(b_292, "x"))), (ToNum(Get(o_305, "z")) - ToNum(Get(b_292, "z")))) < (BS_53 * 2D)))) {
double nx_306 = 0;
double nz_307 = 0;
V nl_308 = default;
nx_306 = (ToNum(Get(o_305, "x")) - ToNum(Get(b_292, "x")));
nz_307 = (ToNum(Get(o_305, "z")) - ToNum(Get(b_292, "z")));
nl_308 = (((V)(Hypot(nx_306, nz_307))) is var _t309 && Truthy(_t309) ? _t309 : ((V)(1D)));
Set(o_305, "st8", ((V)("slide")));
Set(o_305, "dir", Arr(((V)((nx_306 / ToNum(nl_308)))), ((V)((nz_307 / ToNum(nl_308))))));
Set(o_305, "sp", ((V)(Max(ToNum((Get(o_305, "sp") is var _t310 && Truthy(_t310) ? _t310 : ((V)(0D)))), (ToNum(Get(b_292, "sp")) * 0.75)))));
OpSet(b_292, "sp", 2, ((V)(0.3)));
Set(o_305, "x", Add(Get(b_292, "x"), ((V)(((ToNum(GetIdx(Get(o_305, "dir"), 0D)) * BS_53) * 2.02)))));
Set(o_305, "z", Add(Get(b_292, "z"), ((V)(((ToNum(GetIdx(Get(o_305, "dir"), 1D)) * BS_53) * 2.02)))));
Invoke(SFX_22, "tap");
}
}
}
if (LeN(Get(b_292, "sp"), 0D)) {
Set(b_292, "st8", ((V)("board")));
}
}
} else {
if (SEqS(Get(b_292, "st8"), "fall")) {
OpSet(b_292, "vy", 1, ((V)((G_45 * h_296))));
OpSet(b_292, "x", 0, ((V)((ToNum(Get(b_292, "vx")) * h_296))));
OpSet(b_292, "z", 0, ((V)((ToNum(Get(b_292, "vz")) * h_296))));
OpSet(b_292, "y", 0, ((V)((ToNum(Get(b_292, "vy")) * h_296))));
if (LeN(Get(b_292, "y"), 0.03)) {
Set(b_292, "y", ((V)(0.03)));
Set(b_292, "st8", ((V)("grass")));
}
}
}
}
i_294++;
}
}
}
}
if (((string.Equals(phase_79.Str, "fly") && !(Truthy(Invoke(bags_71, "some", Fn((V _self279, int _argc311, V b_317, V _a314, V _a315, V _a316, V[] _rest312) => {
return (((SEqS(Get(b_317, "st8"), "fly") || SEqS(Get(b_317, "st8"), "slide")) || SEqS(Get(b_317, "st8"), "fall")) ? V.True : V.False);
}, 1, "", true))))) && ((ToNum(t_287) - ToNum(throwT_77)) > 500D))) {
V last_318 = default;
Call(settle_85, V.Undef);
phase_79.Set("wait");
settleT_78 = t_287;
last_318 = GetIdx(bags_71, (ToNum(Get(bags_71, "length")) - 1D));
if (SEqS(Get(last_318, "st8"), "board")) {
Invoke(ctx_39, "toast", ((V)("On the board +1")), ((V)((ToNum(W_42) / 2D))), ((V)((ToNum(H_43) * 0.36))), ((V)("#ffffff")));
} else {
if (SEqS(Get(last_318, "st8"), "grass")) {
Invoke(ctx_39, "toast", ((V)((LtN(Get(last_318, "z"), ZF_47) ? "Short" : "Missed"))), ((V)((ToNum(W_42) / 2D))), ((V)((ToNum(H_43) * 0.36))), ((V)("#ffffff")));
}
}
}
if ((string.Equals(phase_79.Str, "wait") && ((ToNum(t_287) - ToNum(settleT_78)) > 650D))) {
if ((left_72 > 0D)) {
cur_73 = Call(mkBag_81, V.Undef);
phase_79.Set("aim");
Call(newWind_82, V.Undef);
} else {
phase_79.Set("done");
Call(settle_85, V.Undef);
Invoke(ctx_39, "finish", NewObj(1).Put("sub", ((V)(JsStrBuf.Begin().N(inHole_80).S(" in the hole \u00b7 ").V(Get(Invoke(bags_71, "filter", Fn((V _self279, int _argc319, V b_325, V _a322, V _a323, V _a324, V[] _rest320) => {
return (SEqS(Get(b_325, "st8"), "board") ? V.True : V.False);
}, 1, "", true)), "length")).S(" on the board").End()))).V);
}
}
pull_288 = (Truthy(drag_74) ? Call(cl_18, V.Undef, ((V)((Hypot((ToNum(Get(drag_74, "x")) - ToNum(Get(drag_74, "x0"))), (ToNum(Get(drag_74, "y")) - ToNum(Get(drag_74, "y0")))) / 200D))), ((V)(0D)), ((V)(1D))) : ((V)(0D)));
ts_289 = (ToNum(t_287) - ToNum(throwT_77));
E_290 = ((ts_289 < 600D) ? Call(track_21, V.Undef, Arr(Arr(((V)(0D)), NewObj(3).Put("armR", ((V)((-40D)))).Put("lean", ((V)((-4D)))).Put("sq", ((V)(0.04))).V), Arr(((V)(120D)), NewObj(4).Put("armR", ((V)(165D))).Put("lean", ((V)(6D))).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(2D))).V), Arr(((V)(600D)), NewObj(4).Put("armR", ((V)(20D))).Put("lean", ((V)(0D))).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).V)), ((V)(ts_289))) : NewObj(4).Put("armR", Call(lerp_19, V.Undef, ((V)(30D)), ((V)((-60D))), pull_288)).Put("lean", ((V)(((-6D) * ToNum(pull_288))))).Put("sq", ((V)((0.06 * ToNum(pull_288))))).Put("armL", ((V)((20D + (30D * ToNum(pull_288)))))).V);
Invoke(me_66, "pose", E_290);
Invoke(me_66, "yaw", ((V)((198D + (FdLibm.Sin((ToNum(t_287) / 1100D)) * 4D)))));
{
V k_326 = default;
V @base_327 = default;
double w_328 = 0;
double sg_329 = 0;
double wv_330 = 0;
k_326 = wind_75;
@base_327 = fp2_63;
w_328 = (22D * (SEqN(k_326, 0D) ? 0.25 : Min(1D, ((System.Math.Abs(ToNum(k_326)) / 0.6) + 0.3))));
sg_329 = (SEqN(k_326, 0D) ? 1D : Sign(ToNum(k_326)));
wv_330 = (FdLibm.Sin((ToNum(t_287) / 120D)) * 3D);
Invoke(cloth_64, "setAttribute", ((V)("d")), ((V)(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, GetIdx(@base_327, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(@base_327, 1D))).S("Q").V(Call(r2_20, V.Undef, Add(GetIdx(@base_327, 0D), ((V)(((sg_329 * w_328) * 0.5)))))).S(" ").V(Call(r2_20, V.Undef, Add(Add(GetIdx(@base_327, 1D), ((V)(wv_330))), ((V)((SEqN(k_326, 0D) ? 8D : 0D)))))).S(" ").V(Call(r2_20, V.Undef, Add(GetIdx(@base_327, 0D), ((V)((sg_329 * w_328)))))).S(" ").V(Call(r2_20, V.Undef, Add(Add(Add(GetIdx(@base_327, 1D), ((V)(5D))), ((V)((wv_330 * 0.5)))), ((V)((SEqN(k_326, 0D) ? 10D : 0D)))))).S("L").V(Call(r2_20, V.Undef, GetIdx(@base_327, 0D))).S(" ").V(Call(r2_20, V.Undef, Add(GetIdx(@base_327, 1D), ((V)(13D))))).S("Z").End())));
}
if (Truthy(cur_73)) {
V k_331 = default;
k_331 = (Truthy(drag_74) ? Call(cl_18, V.Undef, ((V)((Hypot((ToNum(Get(drag_74, "x")) - ToNum(Get(drag_74, "x0"))), (ToNum(Get(drag_74, "y")) - ToNum(Get(drag_74, "y0")))) / 200D))), ((V)(0D)), ((V)(1D))) : ((V)(0D)));
Set(cur_73, "x", ((V)((ToNum(GetIdx(REL_70, 0D)) - (0.08 * ToNum(k_331))))));
Set(cur_73, "y", ((V)(((ToNum(GetIdx(REL_70, 1D)) - (0.12 * ToNum(k_331))) + (FdLibm.Sin((ToNum(t_287) / 380D)) * 0.01)))));
Set(cur_73, "z", ((V)((ToNum(GetIdx(REL_70, 2D)) - (0.1 * ToNum(k_331))))));
}
{
foreach (V _k332 in new JsIter(new ArrBuilder().Add(cur_73).Spread(bags_71).V)) {
V b_333 = default;
b_333 = _k332;
V onB_334 = default;
V s_335 = default;
double sc_336 = 0;
double o_337 = 0;
double sq_338 = 0;
V rr_339 = default;
double c_340 = 0;
double sn_341 = 0;
V pts_342 = default;
V m_343 = default;
JsStrBuf d_344 = null;
V g0y_345 = default;
V gy_346 = default;
V gs_347 = default;
V hk_348 = default;
if (!(Truthy(b_333))) {
continue;
}
onB_334 = ((((SEqS(Get(b_333, "st8"), "board") || SEqS(Get(b_333, "st8"), "slide")) || SEqS(Get(b_333, "st8"), "grass")) || SEqS(Get(b_333, "st8"), "hole")) ? V.True : V.False);
if (Truthy((onB_334 is var _t349 && !Truthy(_t349) ? _t349 : (!SEq(Get(Get(b_333, "g"), "parentNode"), restG_57) ? V.True : V.False)))) {
Invoke(restG_57, "appendChild", Get(b_333, "g"));
}
s_335 = Call(P_44, V.Undef, Get(b_333, "x"), Get(b_333, "y"), Get(b_333, "z"));
sc_336 = (ToNum(GetIdx(s_335, 2D)) * BS_53);
o_337 = 1D;
sq_338 = (Truthy(onB_334) ? 0.42 : 0.9);
if (SEqS(Get(b_333, "st8"), "hole")) {
V u_350 = default;
u_350 = Call(cl_18, V.Undef, ((V)(((ToNum(t_287) - ToNum(Get(b_333, "ht"))) / 260D))), ((V)(0D)), ((V)(1D)));
o_337 = (1D - ToNum(u_350));
sq_338 = (0.42 * (1D - (ToNum(u_350) * 0.5)));
}
rr_339 = (Get(b_333, "rot") is var _t351 && Truthy(_t351) ? _t351 : ((V)(0D)));
c_340 = FdLibm.Cos(((ToNum(rr_339) * System.Math.PI) / 180D));
sn_341 = FdLibm.Sin(((ToNum(rr_339) * System.Math.PI) / 180D));
pts_342 = Invoke(Arr(Arr(((V)((-1D))), ((V)((-1D)))), Arr(((V)(1D)), ((V)((-1D)))), Arr(((V)(1D)), ((V)(1D))), Arr(((V)((-1D))), ((V)(1D)))), "map", Fn((V _self279, int _argc352, V _a354, V _a355, V _a356, V _a357, V[] _rest353) => {
double X_363 = 0;
double Y_364 = 0;
V u_360 = default;
V v_362 = default;
{ V _t358 = ListOf(_a354);
{ V _t359 = GetIdx(_t358, 0D);
u_360 = _t359; }
{ V _t361 = GetIdx(_t358, 1D);
v_362 = _t361; }
}
X_363 = ((ToNum(u_360) * c_340) - (ToNum(v_362) * sn_341));
Y_364 = (((ToNum(u_360) * sn_341) + (ToNum(v_362) * c_340)) * sq_338);
return Arr(Add(GetIdx(s_335, 0D), ((V)((X_363 * sc_336)))), Add(GetIdx(s_335, 1D), ((V)((Y_364 * sc_336)))));
return default;
}, 1, "", true));
m_343 = Fn((V _self279, int _argc365, V a_371, V bb_372, V _a369, V _a370, V[] _rest366) => {
return Arr(((V)((ToNum(Add(GetIdx(a_371, 0D), GetIdx(bb_372, 0D))) / 2D))), ((V)((ToNum(Add(GetIdx(a_371, 1D), GetIdx(bb_372, 1D))) / 2D))));
}, 2, "", true);
d_344 = new JsStrBuf(JsStrBuf.Begin().S("M").V(Call(r2_20, V.Undef, GetIdx(Call(m_343, V.Undef, GetIdx(pts_342, 3D), GetIdx(pts_342, 0D)), 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(Call(m_343, V.Undef, GetIdx(pts_342, 3D), GetIdx(pts_342, 0D)), 1D))).End());
{
double i_373 = 0;
i_373 = 0D;
while (true) {
if (!((i_373 < 4D))) break;
V a_375 = default;
V nb_376 = default;
V mm_377 = default;
a_375 = GetIdx(pts_342, i_373);
nb_376 = GetIdx(pts_342, ((i_373 + 1D) % 4D));
mm_377 = Call(m_343, V.Undef, a_375, nb_376);
d_344.S("Q").V(Call(r2_20, V.Undef, GetIdx(a_375, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(a_375, 1D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(mm_377, 0D))).S(" ").V(Call(r2_20, V.Undef, GetIdx(mm_377, 1D)));
i_373++;
}
}
Invoke(Get(b_333, "b"), "setAttribute", ((V)("d")), ((V)(string.Concat(d_344.Str, "Z"))));
Invoke(Get(b_333, "st"), "setAttribute", ((V)("d")), Invoke(((V)(d_344.Str)), "replace", NewRegExp(RX0, "[-\\d.]+", "g"), Fn((V _self279, int _argc378, V v_384, V _a381, V _a382, V _a383, V[] _rest379) => {
return v_384;
}, 1, "", true)));
Invoke(Get(b_333, "st"), "setAttribute", ((V)("transform")), ((V)(JsStrBuf.Begin().S("translate(").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(s_335, 0D)) * 0.18))))).S(" ").V(Call(r2_20, V.Undef, ((V)((ToNum(GetIdx(s_335, 1D)) * 0.18))))).S(") scale(0.82)").End())));
Invoke(Get(b_333, "g"), "setAttribute", ((V)("opacity")), Call(r2_20, V.Undef, ((V)(o_337))));
g0y_345 = Call(yb_54, V.Undef, Get(b_333, "x"), Get(b_333, "z"));
gy_346 = (((!g0y_345.IsNullish && !SEqS(Get(b_333, "st8"), "grass")) && !SEqS(Get(b_333, "st8"), "fall")) ? g0y_345 : ((V)(0D)));
gs_347 = Call(P_44, V.Undef, Get(b_333, "x"), gy_346, Get(b_333, "z"));
hk_348 = Call(cl_18, V.Undef, ((V)((1D - ((ToNum(Get(b_333, "y")) - ToNum(gy_346)) / 1.5)))), ((V)(0.3)), ((V)(1D)));
Invoke(Get(b_333, "sh"), "setAttribute", ((V)("cx")), Call(r2_20, V.Undef, GetIdx(gs_347, 0D)));
Invoke(Get(b_333, "sh"), "setAttribute", ((V)("cy")), Call(r2_20, V.Undef, GetIdx(gs_347, 1D)));
Invoke(Get(b_333, "sh"), "setAttribute", ((V)("rx")), Call(r2_20, V.Undef, ((V)(((sc_336 * 1.1) * ToNum(hk_348))))));
Invoke(Get(b_333, "sh"), "setAttribute", ((V)("ry")), Call(r2_20, V.Undef, ((V)(((sc_336 * 0.35) * ToNum(hk_348))))));
Invoke(Get(b_333, "sh"), "setAttribute", ((V)("opacity")), (SEqS(Get(b_333, "st8"), "hole") ? ((V)(0D)) : Call(r2_20, V.Undef, ((V)((0.22 * ToNum(hk_348)))))));
}
}
Set(guideG_60, "innerHTML", ((V)("")));
if (Truthy((drag_74 is var _t385 && !Truthy(_t385) ? _t385 : cur_73))) {
double px_386 = 0;
double py_387 = 0;
double len_388 = 0;
px_386 = (ToNum(Get(drag_74, "x")) - ToNum(Get(drag_74, "x0")));
py_387 = (ToNum(Get(drag_74, "y")) - ToNum(Get(drag_74, "y0")));
len_388 = Hypot(px_386, py_387);
if ((py_387 > 18D)) {
V p_389 = default;
double a_390 = 0;
double th_391 = 0;
double v_392 = 0;
double ph_393 = 0;
V x_394 = default;
V y_395 = default;
V z_396 = default;
double vx_397 = 0;
double vz_398 = 0;
double vy_399 = 0;
p_389 = Call(cl_18, V.Undef, ((V)((len_388 / 160D))), ((V)(0.05)), ((V)(1.3)));
a_390 = FdLibm.Atan2((-px_386), py_387);
th_391 = ((38D * System.Math.PI) / 180D);
v_392 = (3.6 + (ToNum(p_389) * 4.2));
ph_393 = (FdLibm.Atan2((-ToNum(GetIdx(REL_70, 0D))), (HZ_51 - ToNum(GetIdx(REL_70, 2D)))) + (a_390 * 0.42));
x_394 = Get(cur_73, "x");
y_395 = Get(cur_73, "y");
z_396 = Get(cur_73, "z");
vx_397 = ((FdLibm.Sin(ph_393) * v_392) * FdLibm.Cos(th_391));
vz_398 = ((FdLibm.Cos(ph_393) * v_392) * FdLibm.Cos(th_391));
vy_399 = (v_392 * FdLibm.Sin(th_391));
{
double i_400 = 0;
i_400 = 0D;
while (true) {
if (!((i_400 < 9D))) break;
double h_402 = 0;
V s_403 = default;
h_402 = 0.045;
vy_399 = (vy_399 - (G_45 * h_402));
x_394 = Add(x_394, ((V)((vx_397 * h_402))));
y_395 = Add(y_395, ((V)((vy_399 * h_402))));
z_396 = Add(z_396, ((V)((vz_398 * h_402))));
s_403 = Call(P_44, V.Undef, x_394, y_395, z_396);
Call(S_16, V.Undef, ((V)("circle")), NewObj(5).Put("cx", Call(r2_20, V.Undef, GetIdx(s_403, 0D))).Put("cy", Call(r2_20, V.Undef, GetIdx(s_403, 1D))).Put("r", Call(r2_20, V.Undef, ((V)(Max(1.5, (3.4 - (i_400 * 0.2))))))).Put("fill", ((V)("#ffffff"))).Put("opacity", Call(r2_20, V.Undef, ((V)((0.9 - (i_400 * 0.08)))))).V, guideG_60);
i_400++;
}
}
}
}
return default;
}, 2, "update", false)).V;
Call(newWind_82, V.Undef);
cur_73 = Call(mkBag_81, V.Undef);
return api_86;
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
