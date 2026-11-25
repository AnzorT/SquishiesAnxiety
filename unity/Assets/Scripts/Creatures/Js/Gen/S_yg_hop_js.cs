// yg-hop.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_yg_hop_js
    {

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
V SFX_22 = default;
V ICON_23 = default;
V ROWS_24 = default;
V COL_25 = default;
V ACT_26 = default;
YG_16 = Get(G("window"), "YardGames");
if (((!(Truthy(YG_16)) || !(Truthy(Get(YG_16, "add")))) || !(Truthy(Get(YG_16, "cam"))))) {
return Call(G("setTimeout"), V.Undef, go_8, ((V)(30D)));
}
{ V _t27 = YG_16;
if (_t27.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t27));
{ V _t28 = Get(_t27, "S");
S_17 = _t28; }
{ V _t29 = Get(_t27, "D");
D_18 = _t29; }
{ V _t30 = Get(_t27, "cl");
cl_19 = _t30; }
{ V _t31 = Get(_t27, "lerp");
lerp_20 = _t31; }
{ V _t32 = Get(_t27, "r2");
r2_21 = _t32; }
{ V _t33 = Get(_t27, "SFX");
SFX_22 = _t33; } }
ICON_23 = ((V)(string.Concat("<svg viewBox=\"0 0 120 84\" aria-hidden=\"true\"><rect width=\"120\" height=\"84\" fill=\"#9fdc6e\"/><path d=\"M30 84L44 6H76L90 84Z\" fill=\"#d9d4cc\"/>", "<g stroke=\"#fff\" stroke-width=\"1.6\"><path d=\"M50 74H70V84H50Z\" fill=\"#ffd1e8\"/><path d=\"M51 62H69V74H51Z\" fill=\"#fff3a8\"/><path d=\"M52 51H68V62H52Z\" fill=\"#c8f0b6\"/><path d=\"M45 41H60V51H45ZM60 41H75V51H60Z\" fill=\"#cfe6ff\"/><path d=\"M53 32H67V41H53Z\" fill=\"#ffd9b8\"/><path d=\"M47 23H60V32H47ZM60 23H73V32H60Z\" fill=\"#e4d4ff\"/><path d=\"M54 15H66V23H54Z\" fill=\"#ffd1e8\"/><path d=\"M53 15Q60 4 67 15Z\" fill=\"#fff3a8\"/></g>", "<ellipse cx=\"60\" cy=\"57\" rx=\"4\" ry=\"2\" fill=\"#8a8f99\"/></svg>")));
ROWS_24 = Arr(Arr(((V)(1D))), Arr(((V)(2D))), Arr(((V)(3D))), Arr(((V)(4D)), ((V)(5D))), Arr(((V)(6D))), Arr(((V)(7D)), ((V)(8D))), Arr(((V)(9D))), Arr(((V)("HOME"))));
COL_25 = Arr(((V)("#ffd1e8")), ((V)("#fff3a8")), ((V)("#c8f0b6")), ((V)("#cfe6ff")), ((V)("#ffd9b8")), ((V)("#e4d4ff")), ((V)("#ffd1e8")), ((V)("#fff3a8")));
ACT_26 = NewObj(3).Put("hop", NewObj(3).Put("c", ((V)("#ff5cae"))).Put("t", ((V)("Hop"))).Put("k", Arr(((V)("ArrowLeft")), ((V)("a")), ((V)("A")))).V).Put("split", NewObj(3).Put("c", ((V)("#3d9bff"))).Put("t", ((V)("Split"))).Put("k", Arr(((V)("ArrowDown")), ((V)("s")), ((V)("S")))).V).Put("leap", NewObj(3).Put("c", ((V)("#ffb020"))).Put("t", ((V)("Leap"))).Put("k", Arr(((V)("ArrowUp")), ((V)("w")), ((V)("W")), ((V)(" ")))).V).V;
Invoke(YG_16, "add", NewObj(11).Put("id", ((V)("hop"))).Put("land", (true ? V.True : V.False)).Put("name", ((V)("Hopscotch"))).Put("item", ((V)("Hopscotch Court"))).Put("color", ((V)("#ff7fc0"))).Put("icon", ICON_23).Put("stars", Arr(((V)(180D)), ((V)(420D)), ((V)(700D)))).Put("coinK", ((V)(0.08))).Put("hint", ((V)("Pink = Hop \u00b7 Blue = Split \u00b7 Yellow = Leap over the stone"))).Put("how", Arr(((V)("Press the move as the ring closes on the next square.")), ((V)("Pink Hop for one square, blue Split for the double squares, yellow Leap over the stone.")), ((V)("Keys: \u2190 hop \u00b7 \u2193 split \u00b7 \u2191 leap. 3 hearts, the beat speeds up each lap.")))).Put("make", Fn((V _self34, int _argc35, V ctx_41, V _a38, V _a39, V _a40, V[] _rest36) => {
V bg_42 = default;
V fg_43 = default;
V W_44 = default;
V H_45 = default;
V P_46 = default;
double Z0_47 = 0;
double RL_48 = 0;
double SW_49 = 0;
V rowZ_50 = default;
V quad_51 = default;
V court_52 = default;
V chalk_53 = default;
V cells_54 = default;
V stoneG_55 = default;
V ringG_56 = default;
V shG_57 = default;
V me_58 = default;
V meSh_59 = default;
V bar_60 = default;
V btn_61 = default;
double lap_62 = 0;
double beat_63 = 0;
double hearts_64 = 0;
V moves_65 = default;
double mi_66 = 0;
V t0_67 = default;
V tNow_68 = default;
V cur_69 = default;
V hopA_70 = default;
JsStrBuf phase_71 = null;
V ph0_72 = default;
V stone_73 = default;
double combo_74 = 0;
double stumbles_75 = 0;
double perfect_76 = 0;
V STONES_77 = default;
V plan_78 = default;
V drawStone_79 = default;
V judge_80 = default;
V press_81 = default;
V api_82 = default;
if (_self34.IsNullish) _self34 = GlobalV;
plan_78 = Fn((V _self83, int _argc84, V _a86, V _a87, V _a88, V _a89, V[] _rest85) => {
double r_90 = 0;
if (_self83.IsNullish) _self83 = GlobalV;
stone_73 = GetIdx(STONES_77, (lap_62 % ToNum(Get(STONES_77, "length"))));
moves_65 = Arr();
r_90 = (-1D);
while ((r_90 < 7D)) {
double nx_91 = 0;
V a_92 = default;
nx_91 = (r_90 + 1D);
a_92 = V.Undef;
if (SEqN(stone_73, nx_91)) {
nx_91++;
a_92 = ((V)("leap"));
} else {
a_92 = ((V)((SEqN(Get(GetIdx(ROWS_24, nx_91), "length"), 2D) ? "split" : "hop")));
}
Invoke(moves_65, "push", NewObj(4).Put("row", ((V)(nx_91))).Put("act", a_92).Put("due", ((V)(0D))).Put("done", ((V)(0D))).V);
r_90 = nx_91;
}
beat_63 = Max(430D, (760D * Pow(0.92, lap_62)));
t0_67 = Add(tNow_68, ((V)((beat_63 * 2D))));
Invoke(moves_65, "forEach", Fn((V _arrowThis101, int _argc93, V m_99, V i_100, V _a97, V _a98, V[] _rest94) => {
return Set(m_99, "due", Add(t0_67, ((V)((beat_63 * ToNum(i_100))))));
}, 2, "", true));
mi_66 = 0D;
Call(drawStone_79, V.Undef);
Invoke(ctx_41, "timer", Add(Invoke(((V)("\u2665")), "repeat", ((V)(hearts_64))), Invoke(((V)("\u2661")), "repeat", ((V)((3D - hearts_64))))));
return default;
}, 0, "plan", false);
drawStone_79 = Fn((V _self102, int _argc103, V _a105, V _a106, V _a107, V _a108, V[] _rest104) => {
V c_109 = default;
V s_110 = default;
double k_111 = 0;
if (_self102.IsNullish) _self102 = GlobalV;
Set(stoneG_55, "innerHTML", ((V)("")));
c_109 = GetIdx(GetK(cells_54, stone_73), 0D);
s_110 = Call(P_46, V.Undef, Get(c_109, "x"), ((V)(0D)), Get(c_109, "z"));
k_111 = (ToNum(GetIdx(s_110, 2D)) / 245.7);
Call(S_17, V.Undef, ((V)("ellipse")), NewObj(5).Put("cx", Call(r2_21, V.Undef, GetIdx(s_110, 0D))).Put("cy", Call(r2_21, V.Undef, Add(GetIdx(s_110, 1D), ((V)((2D * k_111)))))).Put("rx", Call(r2_21, V.Undef, ((V)((11D * k_111))))).Put("ry", Call(r2_21, V.Undef, ((V)((4.2 * k_111))))).Put("fill", ((V)("#6f7480"))).V, stoneG_55);
Call(S_17, V.Undef, ((V)("ellipse")), NewObj(5).Put("cx", Call(r2_21, V.Undef, GetIdx(s_110, 0D))).Put("cy", Call(r2_21, V.Undef, GetIdx(s_110, 1D))).Put("rx", Call(r2_21, V.Undef, ((V)((10D * k_111))))).Put("ry", Call(r2_21, V.Undef, ((V)((4.6 * k_111))))).Put("fill", ((V)("#9aa0ab"))).V, stoneG_55);
Call(S_17, V.Undef, ((V)("ellipse")), NewObj(5).Put("cx", Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(s_110, 0D)) - (3D * k_111)))))).Put("cy", Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(s_110, 1D)) - (1.4 * k_111)))))).Put("rx", Call(r2_21, V.Undef, ((V)((4D * k_111))))).Put("ry", Call(r2_21, V.Undef, ((V)((1.6 * k_111))))).Put("fill", ((V)("#c9ced6"))).V, stoneG_55);
return default;
}, 0, "drawStone", false);
judge_80 = Fn((V _self112, int _argc113, V m_119, V act_120, V dt_121, V _a118, V[] _rest114) => {
V ok_122 = default;
double a_123 = 0;
V txt_124 = default;
V col_125 = default;
double pts_126 = 0;
V c_127 = default;
V s_128 = default;
if (_self112.IsNullish) _self112 = GlobalV;
Set(m_119, "done", ((V)(1D)));
mi_66++;
ok_122 = (SEq(act_120, Get(m_119, "act")) ? V.True : V.False);
a_123 = System.Math.Abs(ToNum(dt_121));
txt_124 = V.Undef;
col_125 = V.Undef;
pts_126 = 0D;
if (!(Truthy(ok_122))) {
txt_124 = ((V)((Truthy(act_120) ? "Oops!" : "Miss!")));
col_125 = ((V)("#ff7a8a"));
hearts_64--;
combo_74 = 0D;
stumbles_75 = 1D;
Invoke(SFX_22, "miss");
} else {
if ((a_123 < 85D)) {
txt_124 = ((V)("Perfect!"));
col_125 = ((V)("#ffe36e"));
pts_126 = 30D;
perfect_76++;
} else {
if ((a_123 < 165D)) {
txt_124 = ((V)("Good"));
col_125 = ((V)("#8fe0ff"));
pts_126 = 15D;
} else {
txt_124 = ((V)("OK"));
col_125 = ((V)("#ffffff"));
pts_126 = 5D;
}
}
}
if (Truthy(ok_122)) {
combo_74++;
pts_126 = (pts_126 + Min(20D, (System.Math.Floor((combo_74 / 4D)) * 5D)));
Invoke(SFX_22, "pop");
}
c_127 = GetIdx(GetK(cells_54, Get(m_119, "row")), 0D);
s_128 = Call(P_46, V.Undef, Get(c_127, "x"), ((V)(0D)), Get(c_127, "z"));
if (NumTruthy(pts_126)) {
Invoke(ctx_41, "add", ((V)(pts_126)), GetIdx(s_128, 0D), ((V)((ToNum(GetIdx(s_128, 1D)) - 50D))), ((V)(JsStrBuf.Begin().V(txt_124).S(((combo_74 >= 8D) ? JsStrBuf.Begin().S(" x").N(combo_74).End() : "")).End())), col_125);
} else {
Invoke(ctx_41, "toast", txt_124, GetIdx(s_128, 0D), ((V)((ToNum(GetIdx(s_128, 1D)) - 50D))), col_125);
}
Invoke(ctx_41, "timer", Add(Invoke(((V)("\u2665")), "repeat", ((V)(Max(0D, hearts_64)))), Invoke(((V)("\u2661")), "repeat", ((V)((3D - Max(0D, hearts_64)))))));
hopA_70 = NewObj(7).Put("from", Get(cur_69, "z")).Put("to", Get(GetIdx(GetK(cells_54, Get(m_119, "row")), 0D), "z")).Put("row", Get(m_119, "row")).Put("act", Get(m_119, "act")).Put("t0", tNow_68).Put("dur", ((V)((Min(400D, (beat_63 * 0.72)) * (SEqS(Get(m_119, "act"), "leap") ? 1.25 : 1D))))).Put("bad", (!(Truthy(ok_122)) ? V.True : V.False)).V;
Set(cur_69, "row", Get(m_119, "row"));
if ((hearts_64 <= 0D)) {
phase_71.Set("over");
ph0_72 = tNow_68;
}
return default;
}, 3, "judge", false);
press_81 = Fn((V _self129, int _argc130, V k_136, V _a133, V _a134, V _a135, V[] _rest131) => {
V m_137 = default;
double dt_138 = 0;
if (_self129.IsNullish) _self129 = GlobalV;
if ((!(Truthy(Get(ctx_41, "playing"))) || !string.Equals(phase_71.Str, "run"))) {
return default;
}
m_137 = GetIdx(moves_65, mi_66);
if (!(Truthy(m_137))) {
return default;
}
dt_138 = (ToNum(tNow_68) - ToNum(Get(m_137, "due")));
if ((dt_138 < (-230D))) {
Invoke(SFX_22, "tap");
return default;
}
Call(judge_80, V.Undef, m_137, k_136, ((V)(dt_138)));
return default;
}, 1, "press", false);
{ V _t139 = ctx_41;
if (_t139.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t139));
{ V _t140 = Get(_t139, "bg");
bg_42 = _t140; }
{ V _t141 = Get(_t139, "fg");
fg_43 = _t141; }
{ V _t142 = Get(_t139, "W");
W_44 = _t142; }
{ V _t143 = Get(_t139, "H");
H_45 = _t143; } }
P_46 = Invoke(YG_16, "cam", ((V)(2D)), ((V)(2.2)), ((V)(24D)), ((V)(160D)));
Z0_47 = 0.35;
RL_48 = 0.5;
SW_49 = 0.5;
Invoke(YG_16, "yard", bg_42, NewObj(2).Put("hz", ((V)(24D))).Put("trees", (false ? V.True : V.False)).V);
rowZ_50 = Fn((V _arrowThis151, int _argc144, V i_150, V _a147, V _a148, V _a149, V[] _rest145) => {
return ((V)((Z0_47 + (RL_48 * ToNum(Add(i_150, ((V)(0.5))))))));
}, 1, "", true);
quad_51 = Fn((V _arrowThis161, int _argc152, V pts_158, V a_159, V p_160, V _a157, V[] _rest153) => {
return Call(S_17, V.Undef, ((V)("path")), Object_assign(NewObj(1).Put("d", ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_158, "map", Fn((V _arrowThis169, int _argc162, V q_168, V _a165, V _a166, V _a167, V[] _rest163) => {
V s_170 = default;
s_170 = Call(P_46, V.Undef, GetIdx(q_168, 0D), ((V)(0D)), GetIdx(q_168, 1D));
return ((V)(JsStrBuf.Begin().V(Call(r2_21, V.Undef, GetIdx(s_170, 0D))).S(" ").V(Call(r2_21, V.Undef, GetIdx(s_170, 1D))).End()));
return default;
}, 1, "", true)), "join", ((V)("L")))).S("Z").End()))).V, a_159), (p_160 is var _t171 && Truthy(_t171) ? _t171 : bg_42));
}, 3, "", true);
Call(quad_51, V.Undef, Arr(Arr(((V)((-0.95))), ((V)((-0.4)))), Arr(((V)(0.95)), ((V)((-0.4)))), Arr(((V)(0.95)), ((V)(5.2))), Arr(((V)((-0.95))), ((V)(5.2)))), NewObj(1).Put("fill", ((V)("#dcd6cc"))).V);
{
double z_172 = 0;
z_172 = (-0.4);
while (true) {
if (!((z_172 < 5.2))) break;
Call(quad_51, V.Undef, Arr(Arr(((V)((-0.95))), ((V)(z_172))), Arr(((V)(0.95)), ((V)(z_172))), Arr(((V)(0.95)), ((V)((z_172 + 0.012)))), Arr(((V)((-0.95))), ((V)((z_172 + 0.012))))), NewObj(1).Put("fill", ((V)("#c7c0b4"))).V);
z_172 = (z_172 + 0.6);
}
}
Call(quad_51, V.Undef, Arr(Arr(((V)((-0.95))), ((V)((-0.4)))), Arr(((V)((-0.9))), ((V)((-0.4)))), Arr(((V)((-0.9))), ((V)(5.2))), Arr(((V)((-0.95))), ((V)(5.2)))), NewObj(1).Put("fill", ((V)("#c2bbae"))).V);
Call(quad_51, V.Undef, Arr(Arr(((V)(0.9)), ((V)((-0.4)))), Arr(((V)(0.95)), ((V)((-0.4)))), Arr(((V)(0.95)), ((V)(5.2))), Arr(((V)(0.9)), ((V)(5.2)))), NewObj(1).Put("fill", ((V)("#c2bbae"))).V);
court_52 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, bg_42);
chalk_53 = NewObj(5).Put("fill", ((V)("none"))).Put("stroke", ((V)("#ffffff"))).Put("stroke-width", ((V)(2.2))).Put("stroke-linejoin", ((V)("round"))).Put("opacity", ((V)(0.92))).V;
cells_54 = Arr();
Invoke(ROWS_24, "forEach", Fn((V _arrowThis182, int _argc174, V r_180, V i_181, V _a178, V _a179, V[] _rest175) => {
double z0_183 = 0;
double z1_184 = 0;
z0_183 = (Z0_47 + (RL_48 * ToNum(i_181)));
z1_184 = (z0_183 + RL_48);
if (SEqS(GetIdx(r_180, 0D), "HOME")) {
JsStrBuf d_185 = null;
double n_186 = 0;
d_185 = new JsStrBuf("");
n_186 = 20D;
{
double k_187 = 0;
k_187 = 0D;
while (true) {
if (!((k_187 <= n_186))) break;
double a_189 = 0;
V s_190 = default;
a_189 = ((System.Math.PI * k_187) / n_186);
s_190 = Call(P_46, V.Undef, ((V)((((-FdLibm.Cos(a_189)) * SW_49) * 0.9))), ((V)(0D)), ((V)((z0_183 + ((FdLibm.Sin(a_189) * RL_48) * 1.3)))));
d_185.S((NumTruthy(k_187) ? "L" : "M")).V(Call(r2_21, V.Undef, GetIdx(s_190, 0D))).S(" ").V(Call(r2_21, V.Undef, GetIdx(s_190, 1D)));
k_187++;
}
}
Call(S_17, V.Undef, ((V)("path")), NewObj(3).Put("d", ((V)(string.Concat(d_185.Str, "Z")))).Put("fill", GetK(COL_25, i_181)).Put("opacity", ((V)(0.75))).V, court_52);
Call(S_17, V.Undef, ((V)("path")), Object_assign(NewObj(1).Put("d", ((V)(string.Concat(d_185.Str, "Z")))).V, chalk_53), court_52);
Invoke(cells_54, "push", Arr(NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)((z0_183 + (RL_48 * 0.55))))).V));
} else {
V xs_191 = default;
xs_191 = (SEqN(Get(r_180, "length"), 2D) ? Arr(Arr(((V)((-SW_49))), ((V)(0D))), Arr(((V)(0D)), ((V)(SW_49)))) : Arr(Arr(((V)(((-SW_49) / 2D))), ((V)((SW_49 / 2D))))));
Invoke(cells_54, "push", Invoke(xs_191, "map", Fn((V _arrowThis203, int _argc192, V _a194, V _a195, V _a196, V _a197, V[] _rest193) => {
V a_200 = default;
V b_202 = default;
{ V _t198 = ListOf(_a194);
{ V _t199 = GetIdx(_t198, 0D);
a_200 = _t199; }
{ V _t201 = GetIdx(_t198, 1D);
b_202 = _t201; }
}
Call(quad_51, V.Undef, Arr(Arr(a_200, ((V)(z0_183))), Arr(b_202, ((V)(z0_183))), Arr(b_202, ((V)(z1_184))), Arr(a_200, ((V)(z1_184)))), NewObj(2).Put("fill", GetK(COL_25, i_181)).Put("opacity", ((V)(0.75))).V, court_52);
Call(quad_51, V.Undef, Arr(Arr(a_200, ((V)(z0_183))), Arr(b_202, ((V)(z0_183))), Arr(b_202, ((V)(z1_184))), Arr(a_200, ((V)(z1_184)))), chalk_53, court_52);
return NewObj(2).Put("x", ((V)((ToNum(Add(a_200, b_202)) / 2D)))).Put("z", ((V)(((z0_183 + z1_184) / 2D)))).V;
return default;
}, 1, "", true)));
}
Invoke(r_180, "forEach", Fn((V _arrowThis212, int _argc204, V lb_210, V j_211, V _a208, V _a209, V[] _rest205) => {
V c_213 = default;
V s_214 = default;
double k_215 = 0;
c_213 = (GetK(GetK(cells_54, i_181), j_211) is var _t216 && Truthy(_t216) ? _t216 : GetIdx(GetK(cells_54, i_181), 0D));
s_214 = Call(P_46, V.Undef, Get(c_213, "x"), ((V)(0D)), Get(c_213, "z"));
k_215 = (ToNum(GetIdx(s_214, 2D)) / 245.7);
Set(Call(S_17, V.Undef, ((V)("text")), NewObj(9).Put("x", ((V)(0D))).Put("y", ((V)(0D))).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").V(Call(r2_21, V.Undef, GetIdx(s_214, 0D))).S(" ").V(Call(r2_21, V.Undef, Add(GetIdx(s_214, 1D), ((V)((6D * k_215)))))).S(") scale(").V(Call(r2_21, V.Undef, ((V)((k_215 * 1.1))))).S(" ").V(Call(r2_21, V.Undef, ((V)((k_215 * 0.62))))).S(")").End()))).Put("text-anchor", ((V)("middle"))).Put("font-family", ((V)("Fredoka, sans-serif"))).Put("font-weight", ((V)(700D))).Put("font-size", ((V)((SEqS(lb_210, "HOME") ? 20D : 30D)))).Put("fill", ((V)("#ffffff"))).Put("opacity", ((V)(0.9))).V, court_52), "textContent", lb_210);
return default;
}, 2, "", true));
return default;
}, 2, "", true));
{
double i_217 = 0;
i_217 = 0D;
while (true) {
if (!((i_217 < 8D))) break;
V s_219 = default;
s_219 = Call(P_46, V.Undef, ((V)(((NumTruthy((i_217 % 2D)) ? 1D : (-1D)) * (0.62 + ((i_217 * 0.07) % 0.2))))), ((V)(0D)), ((V)((0.5 + (i_217 * 0.55)))));
Call(S_17, V.Undef, ((V)("ellipse")), NewObj(6).Put("cx", Call(r2_21, V.Undef, GetIdx(s_219, 0D))).Put("cy", Call(r2_21, V.Undef, GetIdx(s_219, 1D))).Put("rx", Call(r2_21, V.Undef, ((V)(((9D * ToNum(GetIdx(s_219, 2D))) / 245.7))))).Put("ry", Call(r2_21, V.Undef, ((V)(((3D * ToNum(GetIdx(s_219, 2D))) / 245.7))))).Put("fill", GetIdx(COL_25, i_217)).Put("opacity", ((V)(0.4))).V, court_52);
i_217++;
}
}
{
V s_220 = default;
s_220 = Call(P_46, V.Undef, ((V)(0.7)), ((V)(0D)), ((V)(0.15)));
Call(S_17, V.Undef, ((V)("rect")), NewObj(7).Put("x", Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(s_220, 0D)) - 9D))))).Put("y", Call(r2_21, V.Undef, ((V)((ToNum(GetIdx(s_220, 1D)) - 3D))))).Put("width", ((V)(18D))).Put("height", ((V)(6D))).Put("rx", ((V)(3D))).Put("fill", ((V)("#ff8fc8"))).Put("transform", ((V)(JsStrBuf.Begin().S("rotate(-20 ").V(Call(r2_21, V.Undef, GetIdx(s_220, 0D))).S(" ").V(Call(r2_21, V.Undef, GetIdx(s_220, 1D))).S(")").End()))).V, court_52);
}
stoneG_55 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, bg_42);
ringG_56 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, bg_42);
shG_57 = Call(S_17, V.Undef, ((V)("g")), NewObj(0).V, bg_42);
me_58 = Invoke(ctx_41, "creature", Get(ctx_41, "playerKey"), NewObj(1).Put("yaw", ((V)(180D))).V);
meSh_59 = Invoke(YG_16, "shadow", shG_57, ((V)(0D)), ((V)(0D)), ((V)(30D)), ((V)(0.2)));
bar_60 = Call(D_18, V.Undef, ((V)("div")), NewObj(1).Put("style", ((V)("position:absolute;left:auto;right:2.5%;width:40%;bottom:4%;display:flex;gap:3%;justify-content:center;pointer-events:none;z-index:6;"))).V, Invoke(Get(Get(ctx_41, "crl"), "parentNode"), "querySelector", ((V)(".yg-hud"))));
btn_61 = NewObj(0).V;
Invoke(ctx_41, "hint", ((V)("")));
Invoke(Object_keys(ACT_26), "forEach", Fn((V _arrowThis228, int _argc221, V k_227, V _a224, V _a225, V _a226, V[] _rest222) => {
V b_229 = default;
V ic_230 = default;
b_229 = Call(D_18, V.Undef, ((V)("button")), NewObj(2).Put("aria-label", Get(GetK(ACT_26, k_227), "t")).Put("style", ((V)(JsStrBuf.Begin().S("pointer-events:auto;flex:1;max-width:30%;aspect-ratio:1.65;border:0;border-radius:22%;background:#ffffff;color:").V(Get(GetK(ACT_26, k_227), "c")).S(";font:700 clamp(12px,4.6cqw,20px)/1 Fredoka,sans-serif;box-shadow:0 1.2cqw 0 ").V(Get(GetK(ACT_26, k_227), "c")).S(";cursor:pointer;display:flex;flex-direction:column;align-items:center;justify-content:center;gap:4%;touch-action:none;").End()))).V, bar_60);
ic_230 = Call(D_18, V.Undef, ((V)("div")), NewObj(1).Put("style", ((V)("width:46%;height:46%;"))).V, b_229);
Set(ic_230, "innerHTML", ((V)((SEqS(k_227, "hop") ? "<svg viewBox=\"0 0 24 24\"><ellipse cx=\"12\" cy=\"13\" rx=\"4.5\" ry=\"6.5\" fill=\"currentColor\"/><circle cx=\"9\" cy=\"4.5\" r=\"1.6\" fill=\"currentColor\"/><circle cx=\"12.5\" cy=\"3.6\" r=\"1.6\" fill=\"currentColor\"/><circle cx=\"15.6\" cy=\"4.8\" r=\"1.5\" fill=\"currentColor\"/></svg>" : (SEqS(k_227, "split") ? "<svg viewBox=\"0 0 24 24\"><ellipse cx=\"6.5\" cy=\"14\" rx=\"3.6\" ry=\"5.6\" fill=\"currentColor\"/><ellipse cx=\"17.5\" cy=\"14\" rx=\"3.6\" ry=\"5.6\" fill=\"currentColor\"/><circle cx=\"5\" cy=\"6.2\" r=\"1.3\" fill=\"currentColor\"/><circle cx=\"8\" cy=\"5.6\" r=\"1.3\" fill=\"currentColor\"/><circle cx=\"16\" cy=\"5.6\" r=\"1.3\" fill=\"currentColor\"/><circle cx=\"19\" cy=\"6.2\" r=\"1.3\" fill=\"currentColor\"/></svg>" : "<svg viewBox=\"0 0 24 24\"><path d=\"M3 19Q12 -2 21 19\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2.6\" stroke-linecap=\"round\"/><path d=\"M17.5 16.5L21 19.5L22 15\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2.6\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/><ellipse cx=\"12\" cy=\"20\" rx=\"4\" ry=\"2\" fill=\"#8a8f99\"/></svg>")))));
Call(D_18, V.Undef, ((V)("div")), NewObj(0).V, b_229, Get(GetK(ACT_26, k_227), "t"));
Invoke(b_229, "addEventListener", ((V)("pointerdown")), Fn((V _arrowThis238, int _argc231, V e_237, V _a234, V _a235, V _a236, V[] _rest232) => {
Invoke(e_237, "preventDefault");
Invoke(e_237, "stopPropagation");
Call(press_81, V.Undef, k_227);
Set(Get(b_229, "style"), "transform", ((V)("translateY(3px)")));
Call(G("setTimeout"), V.Undef, Fn((V _arrowThis252, int _argc246, V _a248, V _a249, V _a250, V _a251, V[] _rest247) => {
return Set(Get(b_229, "style"), "transform", ((V)("")));
}, 0, "", true), ((V)(90D)));
return default;
}, 1, "", true));
SetK(btn_61, k_227, b_229);
return default;
}, 1, "", true));
lap_62 = 0D;
beat_63 = 760D;
hearts_64 = 3D;
moves_65 = Arr();
mi_66 = 0D;
t0_67 = ((V)(0D));
tNow_68 = ((V)(0D));
cur_69 = NewObj(2).Put("z", ((V)(0.2))).Put("row", ((V)((-1D)))).V;
hopA_70 = V.Null;
phase_71 = new JsStrBuf("idle");
ph0_72 = ((V)(0D));
stone_73 = ((V)(0D));
combo_74 = 0D;
stumbles_75 = 0D;
perfect_76 = 0D;
STONES_77 = Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(4D)), ((V)(6D)));
api_82 = NewObj(7).Put("start", Fn((V _self253, int _argc254, V _a256, V _a257, V _a258, V _a259, V[] _rest255) => {
if (_self253.IsNullish) _self253 = GlobalV;
lap_62 = 0D;
hearts_64 = 3D;
combo_74 = 0D;
perfect_76 = 0D;
cur_69 = NewObj(2).Put("z", ((V)(0.2))).Put("row", ((V)((-1D)))).V;
hopA_70 = V.Null;
phase_71.Set("run");
Call(plan_78, V.Undef);
Invoke(me_58, "yaw", ((V)(180D)));
return default;
}, 0, "start", false)).Put("key", Fn((V _self260, int _argc261, V k_267, V dn_268, V _a265, V _a266, V[] _rest262) => {
if (_self260.IsNullish) _self260 = GlobalV;
if (!(Truthy(dn_268))) {
return default;
}
{
foreach (V _k269 in ForInKeys(ACT_26)) {
V a_270 = default;
a_270 = _k269;
if (Truthy(Invoke(Get(GetK(ACT_26, a_270), "k"), "includes", k_267))) {
Call(press_81, V.Undef, a_270);
return (true ? V.True : V.False);
}
}
}
return default;
}, 2, "key", false)).Put("down", Fn((V _self271, int _argc272, V _a274, V _a275, V _a276, V _a277, V[] _rest273) => {
if (_self271.IsNullish) _self271 = GlobalV;

return default;
}, 0, "down", false)).Put("_press", press_81).Put("_state", Fn((V _arrowThis284, int _argc278, V _a280, V _a281, V _a282, V _a283, V[] _rest279) => {
return NewObj(6).Put("lap", ((V)(lap_62))).Put("hearts", ((V)(hearts_64))).Put("mi", ((V)(mi_66))).Put("phase", ((V)(phase_71.Str))).Put("due", (GetIdx(moves_65, mi_66) is var _t285 && !Truthy(_t285) ? _t285 : ((V)(Round((ToNum(Get(GetIdx(moves_65, mi_66), "due")) - ToNum(tNow_68))))))).Put("act", (GetIdx(moves_65, mi_66) is var _t286 && !Truthy(_t286) ? _t286 : Get(GetIdx(moves_65, mi_66), "act"))).V;
}, 0, "_state", true)).Put("celebrate", Fn((V _self287, int _argc288, V st_294, V _a291, V _a292, V _a293, V[] _rest289) => {
if (_self287.IsNullish) _self287 = GlobalV;
Invoke(me_58, "yaw", ((V)(0D)));
Invoke(me_58, "play", ((V)((GeN(st_294, 2D) ? "happy" : "idle"))));
return default;
}, 1, "celebrate", false)).Put("update", Fn((V _self295, int _argc296, V dt_302, V t_303, V _a300, V _a301, V[] _rest297) => {
V z_304 = default;
double lift_305 = 0;
V E_306 = default;
V s_307 = default;
V g_308 = default;
V m_309 = default;
if (_self295.IsNullish) _self295 = GlobalV;
tNow_68 = t_303;
if (string.Equals(phase_71.Str, "run")) {
V m_310 = default;
double bi_311 = 0;
m_310 = GetIdx(moves_65, mi_66);
if (Truthy((m_310 is var _t312 && !Truthy(_t312) ? _t312 : (Gt(t_303, Add(Get(m_310, "due"), ((V)(230D)))) ? V.True : V.False)))) {
Call(judge_80, V.Undef, m_310, V.Null, ((V)(999D)));
}
bi_311 = System.Math.Floor(((ToNum(t_303) - ToNum(t0_67)) / beat_63));
if ((!SEqN(Get(api_82, "_bi"), bi_311) && (bi_311 >= (-2D)))) {
Set(api_82, "_bi", ((V)(bi_311)));
if ((bi_311 < 0D)) {
Invoke(SFX_22, "tick");
}
}
if ((Ge(((V)(mi_66)), Get(moves_65, "length")) && !(Truthy(hopA_70)))) {
phase_71.Set("lap");
ph0_72 = t_303;
lap_62++;
Invoke(ctx_41, "add", ((V)((50D + (lap_62 * 10D)))), ((V)((ToNum(W_44) / 2D))), ((V)((ToNum(H_45) * 0.4))), ((V)(JsStrBuf.Begin().S("Lap ").N(lap_62).S("! +").N((50D + (lap_62 * 10D))).End())), ((V)("#ffe36e")));
Invoke(SFX_22, "score");
Invoke(me_58, "yaw", ((V)(0D)));
Invoke(me_58, "play", ((V)("happy")));
}
}
if (string.Equals(phase_71.Str, "lap")) {
double u_313 = 0;
u_313 = ((ToNum(t_303) - ToNum(ph0_72)) / 1000D);
if (((u_313 > 1.1) && (u_313 < 2.1))) {
Set(cur_69, "z", Call(lerp_20, V.Undef, Get(GetIdx(GetIdx(cells_54, 7D), 0D), "z"), ((V)(0.2)), Invoke(YG_16, "SM", ((V)(((u_313 - 1.1) / 1D))))));
Invoke(me_58, "yaw", ((V)(0D)));
Invoke(me_58, "walk", dt_302, ((V)(1D)), ((V)(0D)));
}
if ((u_313 >= 2.1)) {
Invoke(me_58, "yaw", ((V)(180D)));
Invoke(me_58, "play", ((V)("idle")));
Set(cur_69, "z", ((V)(0.2)));
Set(cur_69, "row", ((V)((-1D))));
if ((lap_62 >= 6D)) {
phase_71.Set("over");
Invoke(ctx_41, "finish", NewObj(2).Put("sub", ((V)(JsStrBuf.Begin().S("6 laps! ").N(perfect_76).S(" perfect").End()))).Put("title", ((V)("Champion!"))).V);
} else {
phase_71.Set("run");
Call(plan_78, V.Undef);
Invoke(ctx_41, "toast", ((V)("Faster!")), ((V)((ToNum(W_44) / 2D))), ((V)((ToNum(H_45) * 0.45))), ((V)("#ffffff")));
}
}
}
if (((string.Equals(phase_71.Str, "over") && ((ToNum(t_303) - ToNum(ph0_72)) > 300D)) && !(Truthy(Get(api_82, "_fin"))))) {
Set(api_82, "_fin", ((V)(1D)));
if ((hearts_64 <= 0D)) {
Invoke(me_58, "yaw", ((V)(0D)));
Invoke(me_58, "play", ((V)("surprised")));
Invoke(ctx_41, "finish", NewObj(1).Put("sub", ((V)(JsStrBuf.Begin().N(lap_62).S(" lap").S(((lap_62 == 1D) ? "" : "s")).S(" \u00b7 ").N(perfect_76).S(" perfect").End()))).V);
}
}
z_304 = Get(cur_69, "z");
lift_305 = 0D;
E_306 = NewObj(0).V;
if (Truthy(hopA_70)) {
V u_314 = default;
double hh_315 = 0;
u_314 = Call(cl_19, V.Undef, ((V)(((ToNum(t_303) - ToNum(Get(hopA_70, "t0"))) / ToNum(Get(hopA_70, "dur"))))), ((V)(0D)), ((V)(1D)));
z_304 = Call(lerp_20, V.Undef, Get(hopA_70, "from"), Get(hopA_70, "to"), Invoke(YG_16, "SM", u_314));
hh_315 = (SEqS(Get(hopA_70, "act"), "leap") ? 0.42 : 0.22);
lift_305 = (FdLibm.Sin((ToNum(u_314) * System.Math.PI)) * hh_315);
E_306 = (SEqS(Get(hopA_70, "act"), "split") ? NewObj(5).Put("armL", ((V)(((100D * FdLibm.Sin((ToNum(u_314) * System.Math.PI))) + 30D)))).Put("armR", ((V)(((100D * FdLibm.Sin((ToNum(u_314) * System.Math.PI))) + 30D)))).Put("footL", ((V)((2D * FdLibm.Sin((ToNum(u_314) * System.Math.PI)))))).Put("footR", ((V)((2D * FdLibm.Sin((ToNum(u_314) * System.Math.PI)))))).Put("sq", ((V)((GtN(u_314, 0.85) ? 0.12 : (-0.05))))).V : (SEqS(Get(hopA_70, "act"), "leap") ? NewObj(4).Put("armL", ((V)((150D * FdLibm.Sin((ToNum(u_314) * System.Math.PI)))))).Put("armR", ((V)((150D * FdLibm.Sin((ToNum(u_314) * System.Math.PI)))))).Put("spin", ((V)((360D * ToNum(Invoke(YG_16, "SM", u_314)))))).Put("sq", ((V)((GtN(u_314, 0.85) ? 0.1 : (-0.06))))).V : NewObj(4).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("footR", ((V)((3D * FdLibm.Sin((ToNum(u_314) * System.Math.PI)))))).Put("sq", ((V)((GtN(u_314, 0.85) ? 0.08 : (-0.04))))).V));
if (Truthy(Get(hopA_70, "bad"))) {
Set(E_306, "tilt", ((V)(((FdLibm.Sin((ToNum(u_314) * 20D)) * 6D) * (1D - (ToNum(u_314) * 0.5))))));
}
if (GeN(u_314, 1D)) {
Set(cur_69, "z", Get(hopA_70, "to"));
hopA_70 = V.Null;
}
} else {
if (string.Equals(phase_71.Str, "run")) {
V m_316 = default;
V pre_317 = default;
m_316 = GetIdx(moves_65, mi_66);
pre_317 = (Truthy(m_316) ? Call(cl_19, V.Undef, ((V)((1D - ((ToNum(Get(m_316, "due")) - ToNum(t_303)) / beat_63)))), ((V)(0D)), ((V)(1D))) : ((V)(0D)));
E_306 = NewObj(3).Put("sq", ((V)((0.06 * ToNum(pre_317))))).Put("armL", ((V)((20D + (25D * ToNum(pre_317)))))).Put("armR", ((V)((20D + (25D * ToNum(pre_317)))))).V;
}
}
if ((string.Equals(phase_71.Str, "run") || string.Equals(phase_71.Str, "lap"))) {
Invoke(me_58, "pose", E_306);
}
s_307 = Call(P_46, V.Undef, ((V)(0D)), ((V)(lift_305)), z_304);
g_308 = Call(P_46, V.Undef, ((V)(0D)), ((V)(0D)), z_304);
Invoke(me_58, "set", GetIdx(s_307, 0D), GetIdx(s_307, 1D), ((V)((1D * ToNum(GetIdx(s_307, 2D))))));
Invoke(meSh_59, "setAttribute", ((V)("cx")), Call(r2_21, V.Undef, GetIdx(g_308, 0D)));
Invoke(meSh_59, "setAttribute", ((V)("cy")), Call(r2_21, V.Undef, GetIdx(g_308, 1D)));
Invoke(meSh_59, "setAttribute", ((V)("rx")), Call(r2_21, V.Undef, ((V)(((0.3 * ToNum(GetIdx(g_308, 2D))) * (1D - lift_305))))));
Invoke(meSh_59, "setAttribute", ((V)("ry")), Call(r2_21, V.Undef, ((V)(((0.08 * ToNum(GetIdx(g_308, 2D))) * (1D - lift_305))))));
Set(ringG_56, "innerHTML", ((V)("")));
m_309 = ((string.Equals(phase_71.Str, "run") ? V.True : V.False) is var _t318 && !Truthy(_t318) ? _t318 : GetIdx(moves_65, mi_66));
if (Truthy(m_309)) {
V u_319 = default;
V A_320 = default;
V rad_321 = default;
V cs_322 = default;
V c_323 = default;
V q_324 = default;
V tag_325 = default;
u_319 = Call(cl_19, V.Undef, ((V)((1D - ((ToNum(Get(m_309, "due")) - ToNum(t_303)) / beat_63)))), ((V)(0D)), ((V)(1.2)));
A_320 = GetK(ACT_26, Get(m_309, "act"));
rad_321 = Call(lerp_20, V.Undef, ((V)(0.62)), ((V)(0.27)), ((V)(Min(1D, ToNum(u_319)))));
cs_322 = GetK(cells_54, Get(m_309, "row"));
Invoke(cs_322, "forEach", Fn((V _arrowThis333, int _argc326, V c_332, V _a329, V _a330, V _a331, V[] _rest327) => {
JsStrBuf d_334 = null;
d_334 = new JsStrBuf("");
{
double i_335 = 0;
i_335 = 0D;
while (true) {
if (!((i_335 <= 28D))) break;
double a_337 = 0;
V q_338 = default;
a_337 = (((i_335 / 28D) * System.Math.PI) * 2D);
q_338 = Call(P_46, V.Undef, Add(Get(c_332, "x"), ((V)(((FdLibm.Cos(a_337) * ToNum(rad_321)) * (SEqN(Get(cs_322, "length"), 2D) ? 0.55 : 1D))))), ((V)(0D)), Add(Get(c_332, "z"), ((V)(((FdLibm.Sin(a_337) * ToNum(rad_321)) * 0.8)))));
d_334.S((NumTruthy(i_335) ? "L" : "M")).V(Call(r2_21, V.Undef, GetIdx(q_338, 0D))).S(" ").V(Call(r2_21, V.Undef, GetIdx(q_338, 1D)));
i_335++;
}
}
Call(S_17, V.Undef, ((V)("path")), NewObj(6).Put("d", ((V)(string.Concat(d_334.Str, "Z")))).Put("fill", Get(A_320, "c")).Put("fill-opacity", ((V)((0.12 + (0.2 * ToNum(u_319)))))).Put("stroke", Get(A_320, "c")).Put("stroke-width", ((V)(3.2))).Put("opacity", Call(cl_19, V.Undef, ((V)((ToNum(u_319) * 2D))), ((V)(0D)), ((V)(1D)))).V, ringG_56);
return default;
}, 1, "", true));
c_323 = (SEqN(Get(cs_322, "length"), 2D) ? NewObj(2).Put("x", ((V)(0D))).Put("z", Get(GetIdx(cs_322, 0D), "z")).V : GetIdx(cs_322, 0D));
q_324 = Call(P_46, V.Undef, Get(c_323, "x"), ((V)(0D)), Get(c_323, "z"));
tag_325 = Call(S_17, V.Undef, ((V)("g")), NewObj(2).Put("transform", ((V)(JsStrBuf.Begin().S("translate(").V(Call(r2_21, V.Undef, GetIdx(q_324, 0D))).S(" ").V(Call(r2_21, V.Undef, ((V)(((ToNum(GetIdx(q_324, 1D)) - ((22D * ToNum(GetIdx(q_324, 2D))) / 245.7)) - 8D))))).S(")").End()))).Put("opacity", Call(cl_19, V.Undef, ((V)((ToNum(u_319) * 2D))), ((V)(0D)), ((V)(1D)))).V, ringG_56);
Call(S_17, V.Undef, ((V)("rect")), NewObj(6).Put("x", ((V)((-22D)))).Put("y", ((V)((-11D)))).Put("width", ((V)(44D))).Put("height", ((V)(20D))).Put("rx", ((V)(10D))).Put("fill", Get(A_320, "c")).V, tag_325);
Set(Call(S_17, V.Undef, ((V)("text")), NewObj(6).Put("y", ((V)(4D))).Put("text-anchor", ((V)("middle"))).Put("font-family", ((V)("Fredoka, sans-serif"))).Put("font-weight", ((V)(700D))).Put("font-size", ((V)(12D))).Put("fill", ((V)("#ffffff"))).V, tag_325), "textContent", Get(A_320, "t"));
Invoke(Object_keys(btn_61), "forEach", Fn((V _arrowThis346, int _argc339, V k_345, V _a342, V _a343, V _a344, V[] _rest340) => {
Set(Get(GetK(btn_61, k_345), "style"), "background", ((V)(((SEq(k_345, Get(m_309, "act")) && GtN(u_319, 0.5)) ? JsStrBuf.Begin().V(Get(A_320, "c")).S("22").End() : "#ffffff"))));
return default;
}, 1, "", true));
}
return default;
}, 2, "update", false)).V;
Call(plan_78, V.Undef);
return api_82;
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
