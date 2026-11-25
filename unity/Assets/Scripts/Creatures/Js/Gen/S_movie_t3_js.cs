// movie-t3.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_movie_t3_js
    {

        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V SM_8 = default;
V K_9 = default;
V D_10 = default;
V P_11 = default;
V E_12 = default;
V kf_13 = default;
V win_14 = default;
V put_15 = default;
V show_16 = default;
V actor_17 = default;
V pose_18 = default;
V go_19 = default;
V dance_20 = default;
V bub_21 = default;
V lines_22 = default;
V parts_23 = default;
V rain_24 = default;
V lightning_25 = default;
V glow_26 = default;
V film_27 = default;
V snd_28 = default;
V rnd_29 = default;
V cl_30 = default;
V lerp_31 = default;
V stars_32 = default;
double FY_33 = 0;
double W_34 = 0;
V forest_35 = default;
V aura_36 = default;
V walkers_37 = default;
V mk_38 = default;
V score_39 = default;
if (_self1.IsNullish) _self1 = GlobalV;
forest_35 = Fn((V _self40, int _argc41, V L_47, V seed_48, V _a45, V _a46, V[] _rest42) => {
V r_51 = default;
V sky_52 = default;
V st_53 = default;
V moon_54 = default;
V lay_55 = default;
V hills_56 = default;
V L1_57 = default;
V L2_58 = default;
V gr_59 = default;
V act_60 = default;
V nite_61 = default;
V fl_62 = default;
V o_50 = default;
if (_self40.IsNullish) _self40 = GlobalV;
{ V _t49 = _a45; if (_t49.IsUndef) _t49 = NewObj(0).V;
o_50 = _t49; }
r_51 = Call(rnd_29, V.Undef, seed_48);
sky_52 = Call(D_10, V.Undef, L_47, ((V)("inset:0;")));
st_53 = Call(stars_32, V.Undef, L_47, ((V)(70D)), ((V)(320D)), ((V)(110D)), Add(seed_48, ((V)(1D))), ((V)("#fffbe0")), ((V)(1.2)));
moon_54 = Call(D_10, V.Undef, L_47, ((V)("left:250px;top:18px;width:18px;height:18px;border-radius:50%;background:#fff8d8;box-shadow:0 0 14px 5px rgba(255,248,216,0.4);display:none;")));
lay_55 = Fn((V _arrowThis75, int _argc63, V n_69, V f_70, V y_71, V hh_72, V[] _rest64) => {
V g_76 = default;
V col_73 = default;
V sz_74 = default;
col_73 = (_argc63 > 4 ? _rest64[0] : V.Undef);
sz_74 = (_argc63 > 5 ? _rest64[1] : V.Undef);
g_76 = Call(D_10, V.Undef, L_47, ((V)("left:0;top:0;width:1280px;height:180px;")));
{
double i_77 = 0;
i_77 = 0D;
while (true) {
if (!(Lt(((V)(i_77)), n_69))) break;
double x_79 = 0;
double s_80 = 0;
x_79 = ((i_77 * (1280D / ToNum(n_69))) + (ToNum(Call(r_51, V.Undef)) * 40D));
s_80 = (ToNum(sz_74) * (0.8 + (ToNum(Call(r_51, V.Undef)) * 0.5)));
Call(D_10, V.Undef, g_76, ((V)(JsStrBuf.Begin().S("left:").N((x_79 + (s_80 * 0.42))).S("px;top:").N((ToNum(y_71) - 4D)).S("px;width:").N((s_80 * 0.16)).S("px;height:").V(Add(hh_72, ((V)(6D)))).S("px;background:").V(GetIdx(col_73, 1D)).S(";").End())));
Invoke(Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)((-0.28))), ((V)(0.22)), ((V)(0.75))), Arr(((V)(0.3)), ((V)(0.2)), ((V)(0.72)))), "forEach", Fn((V _arrowThis94, int _argc81, V _a83, V _a84, V _a85, V _a86, V[] _rest82) => {
V dx_89 = default;
V dy_91 = default;
V k_93 = default;
{ V _t87 = ListOf(_a83);
{ V _t88 = GetIdx(_t87, 0D);
dx_89 = _t88; }
{ V _t90 = GetIdx(_t87, 1D);
dy_91 = _t90; }
{ V _t92 = GetIdx(_t87, 2D);
k_93 = _t92; }
}
return Call(D_10, V.Undef, g_76, ((V)(JsStrBuf.Begin().S("left:").N(((x_79 + (s_80 * ToNum(Add(((V)(0.5)), dx_89)))) - ((s_80 * ToNum(k_93)) / 2D))).S("px;top:").N(((ToNum(y_71) - (s_80 * 0.9)) + (s_80 * ToNum(dy_91)))).S("px;width:").N((s_80 * ToNum(k_93))).S("px;height:").N(((s_80 * ToNum(k_93)) * 0.95)).S("px;border-radius:50%;background:").V(GetIdx(col_73, 0D)).S(";").End())));
}, 1, "", true));
i_77++;
}
}
Set(g_76, "_f", f_70);
return g_76;
return default;
}, 6, "", true);
hills_56 = Call(D_10, V.Undef, L_47, ((V)("left:0;top:84px;width:1280px;height:60px;background:radial-gradient(ellipse 120px 40px at 80px 60px,#6b9a7a 98%,transparent 100%) 0 0/260px 60px repeat-x;")));
Set(hills_56, "_f", ((V)(0.15)));
L1_57 = Call(lay_55, V.Undef, ((V)(10D)), ((V)(0.35)), ((V)(118D)), ((V)(22D)), Arr(((V)("#4f8a5a")), ((V)("#5a4030"))), ((V)(46D)));
L2_58 = Call(lay_55, V.Undef, ((V)(7D)), ((V)(0.8)), ((V)(140D)), ((V)(18D)), Arr(((V)("#3d7a48")), ((V)("#4a3424"))), ((V)(62D)));
gr_59 = Call(D_10, V.Undef, L_47, ((V)(JsStrBuf.Begin().S("left:0;top:").N((FY_33 - 4D)).S("px;width:320px;height:").N((184D - FY_33)).S("px;background:linear-gradient(#5aa05a,#3f7a42);").End())));
Call(D_10, V.Undef, gr_59, ((V)("left:0;top:0;width:320px;height:3px;background:#7ec46e;")));
act_60 = Call(D_10, V.Undef, L_47, ((V)("inset:0;")));
nite_61 = Call(D_10, V.Undef, L_47, ((V)("inset:0;pointer-events:none;background:#0a1440;opacity:0;")));
fl_62 = Call(D_10, V.Undef, L_47, ((V)("inset:0;pointer-events:none;background:#eef4ff;opacity:0;")));
return NewObj(3).Put("act", act_60).Put("gr", gr_59).Put("upd", Fn((V _self95, int _argc96, V t_102, V _a99, V _a100, V _a101, V[] _rest97) => {
V n_105 = default;
V px_106 = default;
V w_107 = default;
V q_104 = default;
if (_self95.IsNullish) _self95 = GlobalV;
{ V _t103 = _a99; if (_t103.IsUndef) _t103 = NewObj(0).V;
q_104 = _t103; }
n_105 = (Get(q_104, "n") is var _t108 && !_t108.IsNullish ? _t108 : ((V)(0D)));
px_106 = (Get(q_104, "px") is var _t109 && Truthy(_t109) ? _t109 : ((V)(0D)));
w_107 = (Get(q_104, "warm") is var _t110 && Truthy(_t110) ? _t110 : ((V)(0D)));
Set(Get(sky_52, "style"), "background", ((V)(JsStrBuf.Begin().S("linear-gradient(").V(Invoke(Arr(((V)(JsStrBuf.Begin().S("hsl(").V(Call(lerp_31, V.Undef, ((V)(205D)), ((V)(232D)), n_105)).S(",").V(Call(lerp_31, V.Undef, ((V)(70D)), ((V)(55D)), n_105)).S("%,").V(Call(lerp_31, V.Undef, ((V)(68D)), ((V)(14D)), n_105)).S("%)").End())), ((V)(JsStrBuf.Begin().S("hsl(").V(Call(lerp_31, V.Undef, ((V)(195D)), ((V)(260D)), n_105)).S(",").V(Call(lerp_31, V.Undef, ((V)(70D)), ((V)(40D)), n_105)).S("%,").V(Call(lerp_31, V.Undef, ((V)(84D)), ((V)(24D)), n_105)).S("%)").End()))), "join", ((V)(",")))).S(")").End())));
if (Truthy(w_107)) {
Set(Get(sky_52, "style"), "background", ((V)(JsStrBuf.Begin().S("linear-gradient(hsl(").V(Call(lerp_31, V.Undef, ((V)(232D)), ((V)(280D)), w_107)).S(",60%,").V(Call(lerp_31, V.Undef, ((V)(14D)), ((V)(30D)), w_107)).S("%),hsl(").V(Call(lerp_31, V.Undef, ((V)(260D)), ((V)(40D)), w_107)).S(",80%,").V(Call(lerp_31, V.Undef, ((V)(24D)), ((V)(62D)), w_107)).S("%))").End())));
}
Set(Get(st_53, "style"), "opacity", Invoke(Call(cl_30, V.Undef, ((V)(((ToNum(n_105) - 0.4) * 2D)))), "toFixed", ((V)(2D))));
Call(show_16, V.Undef, moon_54, (GtN(n_105, 0.5) ? V.True : V.False));
Invoke(Arr(hills_56, L1_57, L2_58), "forEach", Fn((V _arrowThis118, int _argc111, V g_117, V _a114, V _a115, V _a116, V[] _rest112) => {
Set(Get(g_117, "style"), "transform", ((V)(JsStrBuf.Begin().S("translateX(").V(Invoke(((V)((-((ToNum(px_106) * ToNum(Get(g_117, "_f"))) % 640D)))), "toFixed", ((V)(1D)))).S("px)").End())));
return default;
}, 1, "", true));
Set(Get(nite_61, "style"), "opacity", Invoke(((V)(((ToNum(n_105) * 0.5) * (1D - (ToNum(w_107) * 0.8))))), "toFixed", ((V)(3D))));
Set(Get(fl_62, "style"), "opacity", Invoke(((V)((ToNum((Get(q_104, "flash") is var _t119 && Truthy(_t119) ? _t119 : ((V)(0D)))) * 0.6))), "toFixed", ((V)(3D))));
return default;
}, 2, "upd", false)).V;
return default;
}, 3, "forest", false);
mk_38 = Fn((V _self120, int _argc121, V _a123, V _a124, V _a125, V _a126, V[] _rest122) => {
V S_127 = default;
if (_self120.IsNullish) _self120 = GlobalV;
S_127 = Arr();
Invoke(S_127, "push", NewObj(5).Put("a", ((V)(0D))).Put("b", ((V)(20D))).Put("rgb", ((V)("255,220,150"))).Put("lit", Fn((V _arrowThis135, int _argc128, V t_134, V _a131, V _a132, V _a133, V[] _rest129) => {
return ((V)((0.9 - (ToNum(Call(P_11, V.Undef, t_134, ((V)(6D)), ((V)(13D)))) * 0.6))));
}, 1, "lit", true)).Put("mk", Fn((V _self136, int _argc137, V L_143, V _a140, V _a141, V _a142, V[] _rest138) => {
V F_144 = default;
V lu_145 = default;
V au_146 = default;
V sp_147 = default;
V ti_148 = default;
V ff_149 = default;
if (_self136.IsNullish) _self136 = GlobalV;
F_144 = Call(forest_35, V.Undef, L_143, ((V)(3D)));
lu_145 = Call(actor_17, V.Undef, Get(F_144, "act"), ((V)("lumi")), ((V)(W_34)));
au_146 = Call(aura_36, V.Undef, Get(F_144, "act"));
sp_147 = Call(bub_21, V.Undef, L_143);
ti_148 = Call(D_10, V.Undef, L_143, ((V)("left:0;top:30px;width:320px;text-align:center;font-family:Georgia,serif;font-style:italic;font-weight:700;font-size:24px;line-height:1.1;color:#fffbe8;text-shadow:0 0 12px rgba(255,220,120,0.8),0 2px 0 #3a2a10;z-index:40;")), ((V)("The Lantern of<br>Lost Woods")));
ff_149 = Call(parts_23, V.Undef, Get(F_144, "act"), ((V)(8D)), ((V)("width:3px;height:3px;border-radius:50%;background:#fff6a0;box-shadow:0 0 5px 2px #ffe060;")), V.Null, Fn((V _arrowThis158, int _argc150, V i_156, V t_157, V _a154, V _a155, V[] _rest151) => {
return ((GtN(t_157, 7D) && LtN(t_157, 13D)) ? NewObj(3).Put("x", ((V)(((40D + (ToNum(i_156) * 34D)) + (FdLibm.Sin(ToNum(Add(((V)((ToNum(t_157) * 0.8))), i_156))) * 14D))))).Put("y", ((V)(((60D + ((ToNum(i_156) % 3D) * 22D)) + (FdLibm.Cos(ToNum(Add(((V)((ToNum(t_157) * 1.1))), i_156))) * 10D))))).Put("o", ((V)((0.4 + (0.6 * System.Math.Abs(FdLibm.Sin(ToNum(Add(((V)((ToNum(t_157) * 2D))), i_156))))))))).V : V.Null);
}, 2, "", true));
return Fn((V _arrowThis166, int _argc159, V t_165, V _a162, V _a163, V _a164, V[] _rest160) => {
V n_167 = default;
double @out_168 = 0;
V s_169 = default;
n_167 = Call(P_11, V.Undef, t_165, ((V)(5D)), ((V)(12D)), Get(E_12, "io"));
@out_168 = (LtN(t_165, 11D) ? 1D : (LtN(t_165, 13D) ? (((FdLibm.Sin((ToNum(t_165) * 40D)) > 0.2) ? 0.8 : 0.15) * (1D - ToNum(Call(P_11, V.Undef, t_165, ((V)(12.4)), ((V)(13D)))))) : 0D));
Invoke(F_144, "upd", t_165, NewObj(1).Put("n", n_167).V);
Set(Get(ti_148, "style"), "opacity", Invoke(((V)((ToNum(Call(P_11, V.Undef, t_165, ((V)(0.8)), ((V)(2.2)))) * (1D - ToNum(Call(P_11, V.Undef, t_165, ((V)(5.5)), ((V)(6.6)))))))), "toFixed", ((V)(3D))));
s_169 = NewObj(5).Put("x", ((V)(160D))).Put("y", ((V)(FY_33))).Put("v", ((V)(((GtN(t_165, 13.4) && LtN(t_165, 15D)) ? "left" : "front")))).Put("r", ((V)((GtN(t_165, 13D) ? (-4D) : 0D)))).Put("sy", ((V)((1D + (0.01 * FdLibm.Sin((ToNum(t_165) * 3D))))))).V;
Call(pose_18, V.Undef, lu_145, s_169);
Call(put_15, V.Undef, au_146, ((V)(160D)), ((V)((FY_33 - 26D))), ((V)((1D + (0.06 * FdLibm.Sin((ToNum(t_165) * 5D)))))), ((V)(0D)), ((V)(@out_168)));
Call(ff_149, V.Undef, t_165);
Call(lines_22, V.Undef, sp_147, t_165, Arr(Arr(((V)(15D)), ((V)(19.4)), ((V)("My lantern... it went out!")), ((V)("l")))), NewObj(1).Put("l", Arr(((V)(160D)), ((V)((FY_33 - 58D))))).V);
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
Invoke(S_127, "push", NewObj(5).Put("a", ((V)(20D))).Put("b", ((V)(40D))).Put("rgb", ((V)("150,170,255"))).Put("lit", Fn((V _arrowThis177, int _argc170, V t_176, V _a173, V _a174, V _a175, V[] _rest171) => {
return ((V)(0.35));
}, 1, "lit", true)).Put("mk", Fn((V _self178, int _argc179, V L_185, V _a182, V _a183, V _a184, V[] _rest180) => {
V F_186 = default;
V lu_187 = default;
V ac_188 = default;
V fa_189 = default;
V sp_190 = default;
V map_191 = default;
if (_self178.IsNullish) _self178 = GlobalV;
F_186 = Call(forest_35, V.Undef, L_185, ((V)(5D)));
lu_187 = Call(actor_17, V.Undef, Get(F_186, "act"), ((V)("lumi")), ((V)(W_34)));
ac_188 = Call(actor_17, V.Undef, Get(F_186, "act"), ((V)("acorn")), ((V)((W_34 - 6D))));
fa_189 = Call(actor_17, V.Undef, Get(F_186, "act"), ((V)("fawn")), ((V)(W_34)));
sp_190 = Call(bub_21, V.Undef, L_185);
map_191 = Call(D_10, V.Undef, L_185, ((V)("left:60px;top:22px;width:200px;height:118px;transform-origin:50% 50%;display:none;z-index:30;border-radius:4px;background:linear-gradient(135deg,#f4e2b4,#e6c98a);box-shadow:0 4px 10px rgba(0,0,0,0.4);")), ((V)("<svg viewBox=\"0 0 200 118\" width=\"200\" height=\"118\"><path d=\"M10 10 L190 10 L190 108 L10 108Z\" fill=\"none\" stroke=\"#a07a3a\" stroke-width=\"2\" stroke-dasharray=\"1 0\"></path><path d=\"M120 86 L150 26 L180 86Z\" fill=\"#8a9a6a\" stroke=\"#5a4a2a\" stroke-width=\"1.4\"></path><path d=\"M142 42 L150 26 L158 42 Q150 46 142 42Z\" fill=\"#ffffff\"></path><circle cx=\"150\" cy=\"34\" r=\"5\" fill=\"#8fe8ff\" stroke=\"#3a7aa0\" stroke-width=\"1\"></circle><path d=\"M22 92 Q50 60 70 84 T112 70 T146 40\" stroke=\"#a0402a\" stroke-width=\"2\" stroke-dasharray=\"4 4\" fill=\"none\"></path><path d=\"M54 70 Q66 74 78 66\" stroke=\"#4a8ac8\" stroke-width=\"5\" fill=\"none\" opacity=\"0.7\"></path><circle cx=\"92\" cy=\"80\" r=\"6\" fill=\"#d9a03a\"></circle><circle cx=\"108\" cy=\"58\" r=\"5\" fill=\"#c84a4a\"></circle><circle cx=\"108\" cy=\"58\" r=\"1.4\" fill=\"#ffffff\"></circle><text x=\"150\" y=\"100\" font-size=\"9\" text-anchor=\"middle\" fill=\"#5a3a1a\" font-family=\"Georgia\" font-style=\"italic\">Glow Spring</text><circle cx=\"22\" cy=\"92\" r=\"3\" fill=\"#5a3a1a\"></circle></svg>")));
return Fn((V _arrowThis199, int _argc192, V t_198, V _a195, V _a196, V _a197, V[] _rest193) => {
double ms_200 = 0;
Invoke(F_186, "upd", t_198, NewObj(2).Put("n", ((V)(0.72))).Put("px", ((V)((ToNum(Call(P_11, V.Undef, t_198, ((V)(17D)), ((V)(20D)), Get(E_12, "in"))) * 120D)))).V);
ms_200 = (ToNum(Call(P_11, V.Undef, t_198, ((V)(5D)), ((V)(6.2)), Get(E_12, "out"))) * (1D - ToNum(Call(P_11, V.Undef, t_198, ((V)(11.4)), ((V)(12.2))))));
if ((ms_200 > 0.01)) {
Call(show_16, V.Undef, map_191, (true ? V.True : V.False));
Set(Get(map_191, "style"), "transform", ((V)(JsStrBuf.Begin().S("scaleX(").V(Invoke(((V)(ms_200)), "toFixed", ((V)(3D)))).S(") rotate(").V(Invoke(((V)(((-2D) + (FdLibm.Sin(ToNum(t_198)) * 0.8)))), "toFixed", ((V)(2D)))).S("deg)").End())));
} else {
Call(show_16, V.Undef, map_191, (false ? V.True : V.False));
}
Call(pose_18, V.Undef, lu_187, Call(go_19, V.Undef, t_198, Arr(Arr(((V)(0D)), ((V)(160D))), Arr(((V)(17D)), ((V)(160D))), Arr(((V)(20D)), ((V)(360D)))), NewObj(2).Put("y", ((V)(FY_33))).Put("f", ((V)("front"))).V));
Call(pose_18, V.Undef, ac_188, Call(go_19, V.Undef, t_198, Arr(Arr(((V)(0D)), ((V)((-30D)))), Arr(((V)(3D)), ((V)(110D))), Arr(((V)(17D)), ((V)(110D))), Arr(((V)(20D)), ((V)(300D)))), NewObj(2).Put("y", ((V)(FY_33))).Put("f", ((V)("front"))).V));
Call(pose_18, V.Undef, fa_189, Call(go_19, V.Undef, t_198, Arr(Arr(((V)(0D)), ((V)(360D))), Arr(((V)(3.4)), ((V)(214D))), Arr(((V)(17D)), ((V)(214D))), Arr(((V)(20D)), ((V)(420D)))), NewObj(2).Put("y", ((V)(FY_33))).Put("f", ((V)("front"))).V));
Call(lines_22, V.Undef, sp_190, t_198, Arr(Arr(((V)(3.6)), ((V)(5.2)), ((V)("Look, an old map!")), ((V)("f"))), Arr(((V)(12.4)), ((V)(14.6)), ((V)("We\u2019ll help you, Lumi!")), ((V)("a"))), Arr(((V)(14.8)), ((V)(17D)), ((V)("To Mossy Mountain!")), ((V)("f")))), NewObj(2).Put("a", Arr(((V)(110D)), ((V)((FY_33 - 54D))))).Put("f", Arr(((V)(214D)), ((V)((FY_33 - 58D))))).V);
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
Invoke(S_127, "push", NewObj(5).Put("a", ((V)(40D))).Put("b", ((V)(65D))).Put("rgb", ((V)("150,190,255"))).Put("lit", Fn((V _arrowThis208, int _argc201, V t_207, V _a204, V _a205, V _a206, V[] _rest202) => {
return ((V)(0.4));
}, 1, "lit", true)).Put("mk", Fn((V _self209, int _argc210, V L_216, V _a213, V _a214, V _a215, V[] _rest211) => {
V F_217 = default;
V ns_218 = default;
V sp_219 = default;
V rv_220 = default;
V rw_221 = default;
V SX_222 = default;
V spl_223 = default;
if (_self209.IsNullish) _self209 = GlobalV;
F_217 = Call(forest_35, V.Undef, L_216, ((V)(7D)));
ns_218 = Invoke(Arr(((V)("lumi")), ((V)("acorn")), ((V)("fawn"))), "map", Fn((V _arrowThis232, int _argc224, V k_230, V i_231, V _a228, V _a229, V[] _rest225) => {
return Call(actor_17, V.Undef, Get(F_217, "act"), k_230, ((V)((SEqN(i_231, 1D) ? (W_34 - 6D) : W_34))));
}, 2, "", true));
sp_219 = Call(bub_21, V.Undef, L_216);
rv_220 = Call(D_10, V.Undef, Get(F_217, "act"), ((V)(JsStrBuf.Begin().S("left:96px;top:").N((FY_33 - 6D)).S("px;width:150px;height:40px;background:repeating-linear-gradient(90deg,#4a9ad8 0 14px,#5aaae6 14px 22px);").End())), ((V)("")));
rw_221 = Call(D_10, V.Undef, rv_220, ((V)("inset:0;background:repeating-linear-gradient(90deg,rgba(255,255,255,0.35) 0 4px,rgba(255,255,255,0) 4px 26px);")));
SX_222 = Arr(((V)(118D)), ((V)(148D)), ((V)(178D)), ((V)(208D)), ((V)(238D)));
Invoke(SX_222, "forEach", Fn((V _arrowThis240, int _argc233, V x_239, V _a236, V _a237, V _a238, V[] _rest234) => {
return Call(D_10, V.Undef, Get(F_217, "act"), ((V)(JsStrBuf.Begin().S("left:").N((ToNum(x_239) - 11D)).S("px;top:").N((FY_33 - 4D)).S("px;width:22px;height:9px;border-radius:50%;background:#8a8a90;box-shadow:inset 0 2px 0 #b0b0b6;").End())));
}, 1, "", true));
spl_223 = Call(parts_23, V.Undef, Get(F_217, "act"), ((V)(10D)), ((V)("width:4px;height:4px;border-radius:50%;background:#cfeaff;z-index:7;")), V.Null, Fn((V _arrowThis249, int _argc241, V i_247, V t_248, V _a245, V _a246, V[] _rest242) => {
double d_250 = 0;
double a_251 = 0;
d_250 = (ToNum(t_248) - 10.4);
if (((d_250 < 0D) || (d_250 > 0.9))) {
return V.Null;
}
a_251 = ((-System.Math.PI) * (0.2 + (0.6 * (ToNum(i_247) / 9D))));
return NewObj(3).Put("x", ((V)((178D + ((FdLibm.Cos(a_251) * 40D) * d_250))))).Put("y", ((V)((((FY_33 + 4D) + ((FdLibm.Sin(a_251) * 60D) * d_250)) + ((60D * d_250) * d_250))))).Put("o", ((V)((1D - (d_250 / 0.9))))).V;
return default;
}, 2, "", true));
return Fn((V _arrowThis259, int _argc252, V t_258, V _a255, V _a256, V _a257, V[] _rest253) => {
Invoke(F_217, "upd", t_258, NewObj(2).Put("n", ((V)(0.72))).Put("px", ((V)((300D + (Min(ToNum(t_258), 4D) * 30D))))).V);
Set(Get(rw_221, "style"), "backgroundPosition", ((V)(JsStrBuf.Begin().V(Invoke(((V)((ToNum(t_258) * 30D))), "toFixed", ((V)(1D)))).S("px 0").End())));
Invoke(ns_218, "forEach", Fn((V _arrowThis268, int _argc260, V n_266, V i_267, V _a264, V _a265, V[] _rest261) => {
double a_269 = 0;
V hk_270 = default;
V s_271 = default;
a_269 = (4D + (ToNum(i_267) * 1.6));
hk_270 = Arr(Arr(((V)(0D)), ((V)(((-30D) - (ToNum(i_267) * 34D))))), Arr(((V)(a_269)), ((V)(92D))));
Invoke(SX_222, "forEach", Fn((V _arrowThis280, int _argc272, V x_278, V k_279, V _a276, V _a277, V[] _rest273) => {
return Invoke(hk_270, "push", Arr(((V)(((a_269 + 0.6) + (ToNum(k_279) * 0.6)))), x_278, V.Null, NewObj(1).Put("m", ((V)("hop"))).V));
}, 2, "", true));
Invoke(hk_270, "push", Arr(((V)(((a_269 + 0.6) + (5D * 0.6)))), ((V)((270D + (ToNum(i_267) * 10D)))), V.Null, NewObj(1).Put("m", ((V)("hop"))).V));
Invoke(hk_270, "push", Arr(((V)(25D)), ((V)((270D + (ToNum(i_267) * 10D))))));
s_271 = Call(go_19, V.Undef, t_258, hk_270, NewObj(4).Put("y", ((V)(FY_33))).Put("m", ((V)("walk"))).Put("ph", i_267).Put("f", ((V)("front"))).V);
if (((SEqN(i_267, 1D) && GtN(t_258, 9.6)) && LtN(t_258, 13.6))) {
double sl_281 = 0;
sl_281 = (ToNum(Call(P_11, V.Undef, t_258, ((V)(9.6)), ((V)(10.3)), Get(E_12, "in"))) * (1D - ToNum(Call(P_11, V.Undef, t_258, ((V)(12D)), ((V)(12.8)), Get(E_12, "back")))));
s_271 = NewObj(4).Put("x", ((V)((178D + (6D * sl_281))))).Put("y", ((V)((FY_33 + (10D * sl_281))))).Put("v", ((V)((LtN(t_258, 12D) ? "right" : "front")))).Put("r", ((V)(((40D * sl_281) * (1D + (0.1 * FdLibm.Sin((ToNum(t_258) * 20D)))))))).V;
}
if (((SEqN(i_267, 2D) && GtN(t_258, 10D)) && LtN(t_258, 12.8))) {
s_271 = NewObj(4).Put("x", ((V)(160D))).Put("y", ((V)(FY_33))).Put("v", ((V)("right"))).Put("r", ((V)(((18D * ToNum(Call(P_11, V.Undef, t_258, ((V)(10D)), ((V)(10.5))))) * (1D - ToNum(Call(P_11, V.Undef, t_258, ((V)(12D)), ((V)(12.8))))))))).V;
}
Call(pose_18, V.Undef, n_266, s_271);
return default;
}, 2, "", true));
Call(spl_223, V.Undef, t_258);
Call(lines_22, V.Undef, sp_219, t_258, Arr(Arr(((V)(9.6)), ((V)(11.2)), ((V)("Whoa-whoa-whoa!")), ((V)("a"))), Arr(((V)(12D)), ((V)(14.6)), ((V)("Got you!")), ((V)("f"))), Arr(((V)(17.5)), ((V)(21D)), ((V)("Thank you, Fawn!")), ((V)("a")))), NewObj(2).Put("a", (LtN(t_258, 15D) ? Arr(((V)(178D)), ((V)((FY_33 - 52D)))) : Arr(((V)(280D)), ((V)((FY_33 - 52D)))))).Put("f", Arr(((V)(160D)), ((V)((FY_33 - 58D))))).V);
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
Invoke(S_127, "push", NewObj(5).Put("a", ((V)(65D))).Put("b", ((V)(90D))).Put("rgb", ((V)("255,210,120"))).Put("lit", Fn((V _arrowThis289, int _argc282, V t_288, V _a285, V _a286, V _a287, V[] _rest283) => {
return ((V)(0.45));
}, 1, "lit", true)).Put("mk", Fn((V _self290, int _argc291, V L_297, V _a294, V _a295, V _a296, V[] _rest292) => {
V F_298 = default;
V tr_299 = default;
V hole_300 = default;
V te_301 = default;
V tc_302 = default;
V drip_303 = default;
V ns_304 = default;
V sp_305 = default;
V bees_306 = default;
if (_self290.IsNullish) _self290 = GlobalV;
F_298 = Call(forest_35, V.Undef, L_297, ((V)(9D)));
tr_299 = Call(D_10, V.Undef, Get(F_298, "act"), ((V)(JsStrBuf.Begin().S("left:176px;top:20px;width:70px;height:").N((FY_33 - 16D)).S("px;border-radius:30px 30px 4px 4px;background:linear-gradient(90deg,#6a4a2a,#8a6038 50%,#5a3a20);").End())));
Call(D_10, V.Undef, Get(F_298, "act"), ((V)("left:150px;top:-10px;width:120px;height:60px;border-radius:50%;background:#3d7a48;")));
hole_300 = Call(D_10, V.Undef, Get(F_298, "act"), ((V)("left:193px;top:72px;width:36px;height:42px;border-radius:50%;background:#2a1a0c;")));
te_301 = Call(actor_17, V.Undef, Get(F_298, "act"), ((V)("teddy")), ((V)((W_34 + 4D))));
tc_302 = Call(D_10, V.Undef, Get(F_298, "act"), ((V)("left:186px;top:96px;width:50px;height:60px;border-radius:40% 40% 0 0/14px 14px 0 0;background:linear-gradient(90deg,#6a4a2a,#8a6038 50%,#5a3a20) -10px 0/70px 100%;z-index:4;")));
drip_303 = Call(D_10, V.Undef, Get(F_298, "act"), ((V)("left:196px;top:110px;width:6px;height:18px;border-radius:0 0 4px 4px;background:#f2b630;z-index:5;")));
ns_304 = Invoke(Arr(((V)("lumi")), ((V)("acorn")), ((V)("fawn"))), "map", Fn((V _arrowThis315, int _argc307, V k_313, V i_314, V _a311, V _a312, V[] _rest308) => {
return Call(actor_17, V.Undef, Get(F_298, "act"), k_313, ((V)((SEqN(i_314, 1D) ? (W_34 - 6D) : W_34))));
}, 2, "", true));
sp_305 = Call(bub_21, V.Undef, L_297);
bees_306 = Call(parts_23, V.Undef, Get(F_298, "act"), ((V)(4D)), ((V)("width:8px;height:6px;border-radius:50%;background:repeating-linear-gradient(90deg,#f2c030 0 2px,#2a1a0c 2px 4px);z-index:8;")), V.Null, Fn((V _arrowThis324, int _argc316, V i_322, V t_323, V _a320, V _a321, V[] _rest317) => {
return NewObj(3).Put("x", ((V)((211D + (FdLibm.Cos(((ToNum(t_323) * 3D) + (ToNum(i_322) * 1.6))) * (26D + (ToNum(i_322) * 4D))))))).Put("y", ((V)((70D + (FdLibm.Sin(ToNum(Add(((V)((ToNum(t_323) * 4.2))), i_322))) * 14D))))).Put("r", ((V)((FdLibm.Sin(ToNum(Add(((V)((ToNum(t_323) * 9D))), i_322))) * 20D)))).V;
}, 2, "", true));
return Fn((V _arrowThis332, int _argc325, V t_331, V _a328, V _a329, V _a330, V[] _rest326) => {
V pop_333 = default;
double heave_334 = 0;
Invoke(F_298, "upd", t_331, NewObj(2).Put("n", ((V)(0.72))).Put("px", ((V)(420D))).V);
Call(bees_306, V.Undef, t_331);
pop_333 = Call(P_11, V.Undef, t_331, ((V)(15D)), ((V)(17.4)), Get(E_12, "lin"));
heave_334 = ((GtN(t_331, 7D) && LtN(t_331, 15D)) ? Max(0D, FdLibm.Sin((((ToNum(t_331) - 7D) * System.Math.PI) / 2.6))) : 0D);
if (LtN(t_331, 15D)) {
Call(pose_18, V.Undef, te_301, NewObj(5).Put("x", ((V)((211D + ((FdLibm.Sin((ToNum(t_331) * 7D)) * 2D) * (1D - heave_334)))))).Put("y", ((V)((114D - (heave_334 * 6D))))).Put("v", ((V)("front"))).Put("r", ((V)(((FdLibm.Sin((ToNum(t_331) * 5D)) * 6D) + (heave_334 * (-8D)))))).Put("sh", (false ? V.True : V.False)).V);
Call(show_16, V.Undef, tc_302, (true ? V.True : V.False));
} else {
double h_335 = 0;
Call(show_16, V.Undef, tc_302, (false ? V.True : V.False));
h_335 = (FdLibm.Sin((System.Math.PI * Min(1D, ToNum(pop_333)))) * 50D);
Call(pose_18, V.Undef, te_301, NewObj(5).Put("x", Call(lerp_31, V.Undef, ((V)(211D)), ((V)(150D)), pop_333)).Put("y", ((V)((ToNum(Call(lerp_31, V.Undef, ((V)(114D)), ((V)(FY_33)), pop_333)) - h_335)))).Put("v", ((V)("front"))).Put("r", ((V)((LtN(pop_333, 1D) ? (ToNum(pop_333) * 360D) : 0D)))).Put("gy", ((V)(FY_33))).V);
}
Set(Get(drip_303, "style"), "height", ((V)(JsStrBuf.Begin().V(Invoke(((V)((12D + (6D * FdLibm.Sin((ToNum(t_331) * 2D)))))), "toFixed", ((V)(1D)))).S("px").End())));
Invoke(ns_304, "forEach", Fn((V _arrowThis344, int _argc336, V n_342, V i_343, V _a340, V _a341, V[] _rest337) => {
V s_345 = default;
s_345 = Call(go_19, V.Undef, t_331, Arr(Arr(((V)(0D)), ((V)((40D + (ToNum(i_343) * 30D))))), Arr(((V)(6.5)), ((V)((140D - (ToNum(i_343) * 26D))))), Arr(((V)(17.4)), ((V)((140D - (ToNum(i_343) * 26D))))), Arr(((V)(19D)), ((V)((110D - (ToNum(i_343) * 26D)))))), NewObj(3).Put("y", ((V)(FY_33))).Put("f", ((V)("right"))).Put("ph", i_343).V);
if (Truthy(((s_345 is var _t346 && !Truthy(_t346) ? _t346 : (GtN(t_331, 7D) ? V.True : V.False)) is var _t347 && !Truthy(_t347) ? _t347 : (LtN(t_331, 15D) ? V.True : V.False)))) {
Set(s_345, "v", ((V)("right")));
Set(s_345, "r", ((V)(((-14D) * heave_334))));
OpSet(s_345, "x", 1, ((V)((heave_334 * 6D))));
}
if (Truthy(((s_345 is var _t348 && !Truthy(_t348) ? _t348 : (GtN(t_331, 15D) ? V.True : V.False)) is var _t349 && !Truthy(_t349) ? _t349 : (LtN(t_331, 17.8) ? V.True : V.False)))) {
Set(s_345, "v", ((V)("front")));
}
Call(pose_18, V.Undef, n_342, s_345);
return default;
}, 2, "", true));
Call(lines_22, V.Undef, sp_305, t_331, Arr(Arr(((V)(1D)), ((V)(4.6)), ((V)("Help! I\u2019m stuck in the honey tree!")), ((V)("t"))), Arr(((V)(7D)), ((V)(9D)), ((V)("Heave...")), ((V)("f"))), Arr(((V)(9.6)), ((V)(11.6)), ((V)("Ho...")), ((V)("a"))), Arr(((V)(12.2)), ((V)(14.6)), ((V)("HEAVE!")), ((V)("l"))), Arr(((V)(18D)), ((V)(22D)), ((V)("Thanks! I\u2019ll come too!")), ((V)("T")))), NewObj(5).Put("t", Arr(((V)(211D)), ((V)(74D)))).Put("f", Arr(((V)(88D)), ((V)((FY_33 - 58D))))).Put("a", Arr(((V)(114D)), ((V)((FY_33 - 52D))))).Put("l", Arr(((V)(140D)), ((V)((FY_33 - 58D))))).Put("T", Arr(((V)(150D)), ((V)((FY_33 - 60D))))).V);
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
Invoke(S_127, "push", NewObj(5).Put("a", ((V)(90D))).Put("b", ((V)(115D))).Put("rgb", ((V)("255,140,160"))).Put("lit", Fn((V _arrowThis357, int _argc350, V t_356, V _a353, V _a354, V _a355, V[] _rest351) => {
return ((V)(0.5));
}, 1, "lit", true)).Put("mk", Fn((V _self358, int _argc359, V L_365, V _a362, V _a363, V _a364, V[] _rest360) => {
V F_366 = default;
V sp_367 = default;
V shroom_368 = default;
V mo_369 = default;
V ns_370 = default;
if (_self358.IsNullish) _self358 = GlobalV;
F_366 = Call(forest_35, V.Undef, L_365, ((V)(11D)));
sp_367 = Call(bub_21, V.Undef, L_365);
shroom_368 = Fn((V _arrowThis381, int _argc371, V x_377, V w_378, V h_379, V c_380, V[] _rest372) => {
Call(D_10, V.Undef, Get(F_366, "act"), ((V)(JsStrBuf.Begin().S("left:").N((ToNum(x_377) - (ToNum(w_378) * 0.14))).S("px;top:").N((FY_33 - ToNum(h_379))).S("px;width:").N((ToNum(w_378) * 0.28)).S("px;height:").V(h_379).S("px;border-radius:8px 8px 2px 2px;background:#f4ead2;").End())));
Call(D_10, V.Undef, Get(F_366, "act"), ((V)(JsStrBuf.Begin().S("left:").N((ToNum(x_377) - (ToNum(w_378) / 2D))).S("px;top:").N(((FY_33 - ToNum(h_379)) - (ToNum(w_378) * 0.38))).S("px;width:").V(w_378).S("px;height:").N((ToNum(w_378) * 0.5)).S("px;border-radius:").V(w_378).S("px ").V(w_378).S("px 6px 6px;background:radial-gradient(circle at 30% 40%,#fff 0 5%,transparent 6%),radial-gradient(circle at 66% 30%,#fff 0 6%,transparent 7%),radial-gradient(circle at 50% 70%,#fff 0 4%,transparent 5%),").V(c_380).S(";").End())));
return default;
}, 4, "", true);
Call(shroom_368, V.Undef, ((V)(196D)), ((V)(70D)), ((V)(54D)), ((V)("#d8443a")));
Call(shroom_368, V.Undef, ((V)(250D)), ((V)(54D)), ((V)(34D)), ((V)("#e0603a")));
Call(shroom_368, V.Undef, ((V)(36D)), ((V)(50D)), ((V)(30D)), ((V)("#c8443a")));
mo_369 = Call(actor_17, V.Undef, Get(F_366, "act"), ((V)("moss")), ((V)((W_34 - 4D))));
ns_370 = Invoke(Arr(((V)("lumi")), ((V)("acorn")), ((V)("fawn")), ((V)("teddy"))), "map", Fn((V _arrowThis390, int _argc382, V k_388, V i_389, V _a386, V _a387, V[] _rest383) => {
return Call(actor_17, V.Undef, Get(F_366, "act"), k_388, ((V)((SEqN(i_389, 1D) ? (W_34 - 6D) : W_34))));
}, 2, "", true));
return Fn((V _arrowThis398, int _argc391, V t_397, V _a394, V _a395, V _a396, V[] _rest392) => {
double mb_399 = 0;
V bo_400 = default;
Invoke(F_366, "upd", t_397, NewObj(2).Put("n", ((V)(0.72))).Put("px", ((V)(600D))).V);
mb_399 = (System.Math.Abs(FdLibm.Sin((ToNum(t_397) * 5D))) * (LtN(t_397, 6D) ? 10D : 0D));
Call(pose_18, V.Undef, mo_369, Call(go_19, V.Undef, t_397, Arr(Arr(((V)(0D)), ((V)(150D)), ((V)((FY_33 - mb_399))), NewObj(1).Put("m", ((V)("still"))).V)), NewObj(1).Put("y", ((V)(FY_33))).V));
Invoke(ns_370, "forEach", Fn((V _arrowThis409, int _argc401, V n_407, V i_408, V _a405, V _a406, V[] _rest402) => {
double a_410 = 0;
V k_411 = default;
V s_412 = default;
a_410 = (7D + (ToNum(i_408) * 2.6));
k_411 = Arr(Arr(((V)(0D)), ((V)((40D - (ToNum(i_408) * 26D))))), Arr(((V)((a_410 - 1D))), ((V)(110D))), Arr(((V)((a_410 - 0.2))), ((V)(150D)), ((V)((FY_33 - 22D))), NewObj(2).Put("m", ((V)("hop"))).Put("h", ((V)(8D))).V), Arr(((V)((a_410 + 0.9))), ((V)((280D - (ToNum(i_408) * 18D)))), ((V)(FY_33)), NewObj(2).Put("m", ((V)("hop"))).Put("h", ((V)(92D))).V), Arr(((V)(25D)), ((V)((280D - (ToNum(i_408) * 18D))))));
s_412 = Call(go_19, V.Undef, t_397, k_411, NewObj(3).Put("y", ((V)(FY_33))).Put("f", ((V)("front"))).Put("ph", i_408).V);
if (Truthy(((s_412 is var _t413 && !Truthy(_t413) ? _t413 : (GtN(t_397, a_410) ? V.True : V.False)) is var _t414 && !Truthy(_t414) ? _t414 : (LtN(t_397, (a_410 + 0.9)) ? V.True : V.False)))) {
Set(s_412, "r", ((V)(((ToNum(Call(P_11, V.Undef, t_397, ((V)(a_410)), ((V)((a_410 + 0.9))))) * 360D) % 360D))));
}
Call(pose_18, V.Undef, n_407, s_412);
return default;
}, 2, "", true));
bo_400 = Invoke(ns_370, "some", Fn((V _arrowThis423, int _argc415, V n_421, V i_422, V _a419, V _a420, V[] _rest416) => {
double a_424 = 0;
a_424 = (7D + (ToNum(i_422) * 2.6));
return ((GtN(t_397, (a_424 - 0.3)) && LtN(t_397, (a_424 + 0.1))) ? V.True : V.False);
return default;
}, 2, "", true));
if (Truthy(bo_400)) {
V m_425 = default;
m_425 = mo_369;
}
Call(pose_18, V.Undef, mo_369, NewObj(5).Put("x", ((V)(150D))).Put("y", ((V)((FY_33 - mb_399)))).Put("v", ((V)("front"))).Put("sx", ((V)((Truthy(bo_400) ? 1.15 : 1D)))).Put("sy", ((V)((Truthy(bo_400) ? 0.82 : 1D)))).V);
if (GtN(t_397, 18.4)) {
Call(pose_18, V.Undef, mo_369, Call(go_19, V.Undef, t_397, Arr(Arr(((V)(18.4)), ((V)(150D))), Arr(((V)(19D)), ((V)(220D)), V.Null, NewObj(2).Put("m", ((V)("hop"))).Put("h", ((V)(30D))).V), Arr(((V)(19.6)), ((V)(270D)), V.Null, NewObj(2).Put("m", ((V)("hop"))).Put("h", ((V)(30D))).V), Arr(((V)(25D)), ((V)(270D)))), NewObj(3).Put("y", ((V)(FY_33))).Put("m", ((V)("hop"))).Put("f", ((V)("front"))).V));
}
Call(lines_22, V.Undef, sp_367, t_397, Arr(Arr(((V)(1.2)), ((V)(3.8)), ((V)("The mushroom maze!")), ((V)("a"))), Arr(((V)(4D)), ((V)(6.6)), ((V)("Need a lift? Boing!")), ((V)("m"))), Arr(((V)(20D)), ((V)(23.4)), ((V)("Moss, come with us!")), ((V)("l")))), NewObj(3).Put("a", Arr(((V)(40D)), ((V)((FY_33 - 52D))))).Put("m", Arr(((V)(150D)), ((V)((FY_33 - 56D))))).Put("l", Arr(((V)(280D)), ((V)((FY_33 - 58D))))).V);
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
Invoke(S_127, "push", NewObj(5).Put("a", ((V)(115D))).Put("b", ((V)(140D))).Put("rgb", ((V)("120,130,220"))).Put("lit", Fn((V _arrowThis433, int _argc426, V t_432, V _a429, V _a430, V _a431, V[] _rest427) => {
return ((V)((0.25 + (ToNum(Call(lightning_25, V.Undef, t_432, Arr(((V)(3D)), ((V)(9.2)), ((V)(18D))))) * 0.8))));
}, 1, "lit", true)).Put("mk", Fn((V _self434, int _argc435, V L_441, V _a438, V _a439, V _a440, V[] _rest436) => {
V F_442 = default;
V rn_443 = default;
V sp_444 = default;
V sh_445 = default;
V ns_446 = default;
if (_self434.IsNullish) _self434 = GlobalV;
F_442 = Call(forest_35, V.Undef, L_441, ((V)(13D)));
rn_443 = Call(rain_24, V.Undef, L_441, ((V)(60D)), ((V)(4D)));
sp_444 = Call(bub_21, V.Undef, L_441);
Set(Get(Get(F_442, "gr"), "style"), "background", ((V)("linear-gradient(#6a6a7a,#4a4a5a)")));
Call(D_10, V.Undef, Get(F_442, "act"), ((V)(JsStrBuf.Begin().S("left:0;top:").N((FY_33 + 8D)).S("px;width:320px;height:30px;background:linear-gradient(#3a3a4a,#20202c);").End())));
sh_445 = Call(actor_17, V.Undef, Get(F_442, "act"), ((V)("leo")), ((V)(150D)));
Set(Get(sh_445, "style"), "zIndex", ((V)("1")));
ns_446 = Invoke(Arr(((V)("lumi")), ((V)("acorn")), ((V)("fawn")), ((V)("teddy")), ((V)("moss"))), "map", Fn((V _arrowThis455, int _argc447, V k_453, V i_454, V _a451, V _a452, V[] _rest448) => {
return Call(actor_17, V.Undef, Get(F_442, "act"), k_453, ((V)((SEqN(i_454, 1D) ? (W_34 - 6D) : (W_34 - 2D)))));
}, 2, "", true));
return Fn((V _arrowThis463, int _argc456, V t_462, V _a459, V _a460, V _a461, V[] _rest457) => {
V l_464 = default;
V sc_465 = default;
double cw_466 = 0;
l_464 = Call(lightning_25, V.Undef, t_462, Arr(((V)(3D)), ((V)(9.2)), ((V)(18D))));
Invoke(F_442, "upd", t_462, NewObj(3).Put("n", ((V)(1D))).Put("px", ((V)((800D + (Min(ToNum(t_462), 7D) * 25D))))).Put("flash", l_464).V);
Call(rn_443, V.Undef, t_462);
Call(pose_18, V.Undef, sh_445, (GtN(t_462, 8.6) ? NewObj(7).Put("x", ((V)((220D + (FdLibm.Sin((ToNum(t_462) * 0.7)) * 6D))))).Put("y", ((V)((FY_33 - 8D)))).Put("v", ((V)("front"))).Put("f", ((V)("brightness(0) blur(1px)"))).Put("o", ((V)((0.82 * ToNum(Call(P_11, V.Undef, t_462, ((V)(8.6)), ((V)(10D)))))))).Put("k", ((V)((1D + (0.06 * FdLibm.Sin((ToNum(t_462) * 1.3))))))).Put("sh", (false ? V.True : V.False)).V : V.Null));
sc_465 = (GtN(t_462, 9.6) ? V.True : V.False);
cw_466 = (Truthy(sc_465) ? (FdLibm.Sin((ToNum(t_462) * 40D)) * 1.4) : 0D);
Invoke(ns_446, "forEach", Fn((V _arrowThis475, int _argc467, V n_473, V i_474, V _a471, V _a472, V[] _rest468) => {
V s_476 = default;
s_476 = Call(go_19, V.Undef, t_462, Arr(Arr(((V)(0D)), ((V)(((-20D) - (ToNum(i_474) * 30D))))), Arr(((V)(7D)), ((V)((170D - (ToNum(i_474) * 30D)))))), NewObj(3).Put("y", ((V)(FY_33))).Put("f", ((V)("right"))).Put("ph", i_474).V);
if (Truthy(s_476)) {
OpSet(s_476, "r", 0, ((V)((LtN(t_462, 7D) ? (-6D) : 0D))));
if (Truthy(sc_465)) {
Set(s_476, "x", ((V)((((150D - (ToNum(i_474) * 28D)) - (ToNum(Call(P_11, V.Undef, t_462, ((V)(9.6)), ((V)(10.4)))) * 14D)) + cw_466))));
Set(s_476, "v", ((V)("front")));
Set(s_476, "sy", ((V)(0.92)));
Set(s_476, "sx", ((V)(1.06)));
}
}
Call(pose_18, V.Undef, n_473, s_476);
return default;
}, 2, "", true));
Call(lines_22, V.Undef, sp_444, t_462, Arr(Arr(((V)(1D)), ((V)(4D)), ((V)("Hold on tight!")), ((V)("t"))), Arr(((V)(12.4)), ((V)(15.6)), ((V)("W-what IS that?!")), ((V)("a"))), Arr(((V)(19D)), ((V)(23D)), ((V)("ROAAAR!")), ((V)("x")))), NewObj(3).Put("t", Arr(((V)(80D)), ((V)((FY_33 - 58D))))).Put("a", Arr(((V)(122D)), ((V)((FY_33 - 52D))))).Put("x", Arr(((V)(220D)), ((V)(40D)))).V);
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
Invoke(S_127, "push", NewObj(5).Put("a", ((V)(140D))).Put("b", ((V)(150D))).Put("rgb", ((V)("255,220,150"))).Put("lit", Fn((V _arrowThis484, int _argc477, V t_483, V _a480, V _a481, V _a482, V[] _rest478) => {
return ((V)(0.45));
}, 1, "lit", true)).Put("mk", Fn((V _self485, int _argc486, V L_492, V _a489, V _a490, V _a491, V[] _rest487) => {
V F_493 = default;
V le_494 = default;
V lu_495 = default;
V sp_496 = default;
V bug_497 = default;
V bg2_498 = default;
if (_self485.IsNullish) _self485 = GlobalV;
F_493 = Call(forest_35, V.Undef, L_492, ((V)(15D)));
le_494 = Call(actor_17, V.Undef, Get(F_493, "act"), ((V)("leo")), ((V)((W_34 + 4D))));
lu_495 = Call(actor_17, V.Undef, Get(F_493, "act"), ((V)("lumi")), ((V)(W_34)));
sp_496 = Call(bub_21, V.Undef, L_492);
bug_497 = Call(glow_26, V.Undef, Get(F_493, "act"), ((V)("rgba(255,240,120,0.95)")), ((V)(7D)), ((V)("z-index:9;")));
bg2_498 = Call(glow_26, V.Undef, Get(F_493, "act"), ((V)("rgba(255,240,120,0.4)")), ((V)(20D)), ((V)("z-index:8;")));
return Fn((V _arrowThis506, int _argc499, V t_505, V _a502, V _a503, V _a504, V[] _rest500) => {
V sm_507 = default;
V u_508 = default;
V bx_509 = default;
double by_510 = 0;
Invoke(F_493, "upd", t_505, NewObj(2).Put("n", ((V)(1D))).Put("px", ((V)(980D))).V);
sm_507 = Call(P_11, V.Undef, t_505, ((V)(8.4)), ((V)(9D)));
Call(pose_18, V.Undef, le_494, NewObj(4).Put("x", ((V)((214D + (LtN(t_505, 7D) ? (FdLibm.Sin((ToNum(t_505) * 40D)) * 1.2) : 0D))))).Put("y", ((V)((FY_33 - ((GtN(t_505, 8.4) && LtN(t_505, 9D)) ? (FdLibm.Sin((((ToNum(t_505) - 8.4) * System.Math.PI) / 0.6)) * 10D) : 0D))))).Put("v", ((V)("front"))).Put("sy", ((V)((LtN(t_505, 7D) ? 0.94 : 1D)))).V);
Call(pose_18, V.Undef, lu_495, NewObj(3).Put("x", ((V)(116D))).Put("y", ((V)(FY_33))).Put("v", ((V)("right"))).V);
u_508 = Call(P_11, V.Undef, t_505, ((V)(6D)), ((V)(8.2)), Get(E_12, "io"));
bx_509 = Call(lerp_31, V.Undef, ((V)(134D)), ((V)(204D)), u_508);
by_510 = ((ToNum(Call(lerp_31, V.Undef, ((V)((FY_33 - 30D))), ((V)((FY_33 - 34D))), u_508)) - (FdLibm.Sin((System.Math.PI * ToNum(u_508))) * 24D)) + (FdLibm.Sin((ToNum(t_505) * 6D)) * 2D));
Call(put_15, V.Undef, bug_497, bx_509, ((V)(by_510)), ((V)(1D)), ((V)(0D)), ((V)((GtN(t_505, 5.6) ? 1D : 0D))));
Call(put_15, V.Undef, bg2_498, bx_509, ((V)(by_510)), ((V)((1D + (0.2 * FdLibm.Sin((ToNum(t_505) * 7D)))))), ((V)(0D)), ((V)((GtN(t_505, 5.6) ? 1D : 0D))));
Call(lines_22, V.Undef, sp_496, t_505, Arr(Arr(((V)(0.4)), ((V)(5D)), ((V)("I only roar because... I\u2019m scared of the dark too.")), ((V)("L"))), Arr(((V)(5.4)), ((V)(8.2)), ((V)("Here, share my glow-bug!")), ((V)("l")))), NewObj(2).Put("L", Arr(((V)(214D)), ((V)((FY_33 - 60D))))).Put("l", Arr(((V)(116D)), ((V)((FY_33 - 58D))))).V);
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
Invoke(S_127, "push", NewObj(5).Put("a", ((V)(150D))).Put("b", ((V)(170D))).Put("rgb", ((V)("255,230,150"))).Put("lit", Fn((V _arrowThis518, int _argc511, V t_517, V _a514, V _a515, V _a516, V[] _rest512) => {
return ((V)((GtN(t_517, 8.5) ? 1.2 : 0.5)));
}, 1, "lit", true)).Put("mk", Fn((V _self519, int _argc520, V L_526, V _a523, V _a524, V _a525, V[] _rest521) => {
V F_527 = default;
V sp_528 = default;
V pool_529 = default;
V big_530 = default;
V ns_531 = default;
V lu_532 = default;
V au_533 = default;
V rings_534 = default;
V sp2_535 = default;
if (_self519.IsNullish) _self519 = GlobalV;
F_527 = Call(forest_35, V.Undef, L_526, ((V)(17D)));
sp_528 = Call(bub_21, V.Undef, L_526);
pool_529 = Call(D_10, V.Undef, Get(F_527, "act"), ((V)(JsStrBuf.Begin().S("left:110px;top:").N((FY_33 - 8D)).S("px;width:100px;height:22px;border-radius:50%;background:radial-gradient(ellipse at 50% 40%,#e8fbff,#8fe8ff 50%,#3a8ac0);box-shadow:0 0 20px 8px rgba(143,232,255,0.6);").End())));
big_530 = Call(glow_26, V.Undef, L_526, ((V)("rgba(255,240,170,0.9)")), ((V)(160D)), ((V)("z-index:20;mix-blend-mode:screen;")));
ns_531 = Invoke(Arr(((V)("acorn")), ((V)("fawn")), ((V)("teddy")), ((V)("moss")), ((V)("leo"))), "map", Fn((V _arrowThis544, int _argc536, V k_542, V i_543, V _a540, V _a541, V[] _rest537) => {
return Call(actor_17, V.Undef, Get(F_527, "act"), k_542, ((V)((SEqN(i_543, 0D) ? (W_34 - 6D) : (W_34 - 2D)))));
}, 2, "", true));
lu_532 = Call(actor_17, V.Undef, Get(F_527, "act"), ((V)("lumi")), ((V)(W_34)));
au_533 = Call(aura_36, V.Undef, Get(F_527, "act"), ((V)("rgba(255,236,150,0.85)")), ((V)(50D)));
rings_534 = Call(parts_23, V.Undef, L_526, ((V)(3D)), ((V)("width:40px;height:40px;border-radius:50%;border:3px solid #fff6c8;box-sizing:border-box;z-index:21;")), V.Null, Fn((V _arrowThis553, int _argc545, V i_551, V t_552, V _a549, V _a550, V[] _rest546) => {
double d_554 = 0;
d_554 = ((ToNum(t_552) - 8.5) - (ToNum(i_551) * 0.25));
return (((d_554 > 0D) && (d_554 < 1.6)) ? NewObj(4).Put("x", ((V)(160D))).Put("y", ((V)((FY_33 - 20D)))).Put("k", ((V)((1D + (d_554 * 6D))))).Put("o", ((V)((1D - (d_554 / 1.6))))).V : V.Null);
return default;
}, 2, "", true));
sp2_535 = Call(parts_23, V.Undef, L_526, ((V)(16D)), ((V)("width:4px;height:4px;border-radius:50%;background:#fff6a0;box-shadow:0 0 6px 2px #ffd860;z-index:22;")), V.Null, Fn((V _arrowThis563, int _argc555, V i_561, V t_562, V _a559, V _a560, V[] _rest556) => {
return (GtN(t_562, 8.6) ? NewObj(3).Put("x", ((V)((((ToNum(i_561) * 41D) + ((ToNum(t_562) * 8D) * ((ToNum(i_561) % 3D) + 1D))) % 330D)))).Put("y", ((V)((150D - (((((ToNum(t_562) - 8.6) * 18D) * (1D + (ToNum(i_561) % 4D))) + (ToNum(i_561) * 13D)) % 150D))))).Put("o", ((V)(0.8))).V : V.Null);
}, 2, "", true));
return Fn((V _arrowThis571, int _argc564, V t_570, V _a567, V _a568, V _a569, V[] _rest565) => {
V w_572 = default;
V ls_573 = default;
w_572 = Call(P_11, V.Undef, t_570, ((V)(8.5)), ((V)(12D)), Get(E_12, "io"));
Invoke(F_527, "upd", t_570, NewObj(3).Put("n", ((V)(1D))).Put("px", ((V)(1200D))).Put("warm", w_572).V);
Set(Get(pool_529, "style"), "filter", ((V)(JsStrBuf.Begin().S("brightness(").V(Invoke(((V)((1D + (ToNum(w_572) * 0.6)))), "toFixed", ((V)(2D)))).S(")").End())));
Invoke(ns_531, "forEach", Fn((V _arrowThis582, int _argc574, V n_580, V i_581, V _a578, V _a579, V[] _rest575) => {
return Call(pose_18, V.Undef, n_580, (GtN(t_570, 10D) ? Call(dance_20, V.Undef, t_570, GetK(Arr(((V)(44D)), ((V)(74D)), ((V)(246D)), ((V)(276D)), ((V)(216D))), i_581), ((V)(FY_33)), ((V)((NumTruthy((ToNum(i_581) % 2D)) ? "jump" : "bounce"))), ((V)(0.45)), ((V)((ToNum(i_581) * 0.2)))) : Call(go_19, V.Undef, t_570, Arr(Arr(((V)(0D)), ((V)(((-20D) - (ToNum(i_581) * 30D))))), Arr(((V)(4.5)), ((V)((ToNum(GetK(Arr(((V)(44D)), ((V)(74D)), ((V)(246D)), ((V)(276D)), ((V)(216D))), i_581)) - (GtN(i_581, 1D) ? 0D : 0D)))))), NewObj(3).Put("y", ((V)(FY_33))).Put("ph", i_581).Put("f", ((V)("front"))).V)));
}, 2, "", true));
ls_573 = Call(go_19, V.Undef, t_570, Arr(Arr(((V)(0D)), ((V)((-60D)))), Arr(((V)(4.5)), ((V)(100D))), Arr(((V)(6D)), ((V)(100D))), Arr(((V)(7.4)), ((V)(128D))), Arr(((V)(10D)), ((V)(128D)))), NewObj(2).Put("y", ((V)(FY_33))).Put("f", ((V)("right"))).V);
if (Truthy(((ls_573 is var _t583 && !Truthy(_t583) ? _t583 : (GtN(t_570, 7.4) ? V.True : V.False)) is var _t584 && !Truthy(_t584) ? _t584 : (LtN(t_570, 8.6) ? V.True : V.False)))) {
Set(ls_573, "r", ((V)((16D * FdLibm.Sin((System.Math.PI * ToNum(Call(P_11, V.Undef, t_570, ((V)(7.4)), ((V)(8.6)), Get(E_12, "lin")))))))));
}
Call(pose_18, V.Undef, lu_532, ls_573);
if (Truthy(ls_573)) {
Call(put_15, V.Undef, au_533, Get(ls_573, "x"), ((V)((ToNum(Get(ls_573, "y")) - 26D))), ((V)(((1D + (ToNum(w_572) * 0.8)) + (0.06 * FdLibm.Sin((ToNum(t_570) * 5D)))))), ((V)(0D)), w_572);
}
Call(put_15, V.Undef, big_530, ((V)(160D)), ((V)((FY_33 - 20D))), ((V)((0.2 + (ToNum(w_572) * 1.6)))), ((V)(0D)), ((V)((Max(0D, (1D - (System.Math.Abs((ToNum(t_570) - 9.2)) / 3D))) * 0.9))));
Call(rings_534, V.Undef, t_570);
Call(sp2_535, V.Undef, t_570);
Call(lines_22, V.Undef, sp_528, t_570, Arr(Arr(((V)(1.5)), ((V)(4.5)), ((V)("The Glow Spring!")), ((V)("a"))), Arr(((V)(12D)), ((V)(16D)), ((V)("The whole forest is glowing!")), ((V)("l"))), Arr(((V)(16.4)), ((V)(19.6)), ((V)("Hooray!")), ((V)("T")))), NewObj(3).Put("a", Arr(((V)(44D)), ((V)((FY_33 - 52D))))).Put("l", Arr(((V)(128D)), ((V)((FY_33 - 58D))))).Put("T", Arr(((V)(246D)), ((V)((FY_33 - 58D))))).V);
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
Invoke(S_127, "push", NewObj(6).Put("a", ((V)(170D))).Put("b", ((V)(180D))).Put("rgb", ((V)("255,220,150"))).Put("lit", Fn((V _arrowThis592, int _argc585, V t_591, V _a588, V _a589, V _a590, V[] _rest586) => {
return ((V)(0.6));
}, 1, "lit", true)).Put("outF", (false ? V.True : V.False)).Put("mk", Fn((V _self593, int _argc594, V L_600, V _a597, V _a598, V _a599, V[] _rest595) => {
V F_601 = default;
V ns_602 = default;
V gl_603 = default;
V cr_604 = default;
V ff_605 = default;
if (_self593.IsNullish) _self593 = GlobalV;
F_601 = Call(forest_35, V.Undef, L_600, ((V)(19D)));
ns_602 = Invoke(Arr(((V)("leo")), ((V)("moss")), ((V)("teddy")), ((V)("fawn")), ((V)("acorn")), ((V)("lumi"))), "map", Fn((V _arrowThis613, int _argc606, V k_612, V _a609, V _a610, V _a611, V[] _rest607) => {
return Call(actor_17, V.Undef, Get(F_601, "act"), k_612, ((V)((W_34 - 10D))));
}, 1, "", true));
gl_603 = Invoke(ns_602, "map", Fn((V _arrowThis620, int _argc614, V _a616, V _a617, V _a618, V _a619, V[] _rest615) => {
return Call(aura_36, V.Undef, Get(F_601, "act"), ((V)("rgba(255,236,150,0.55)")), ((V)(22D)));
}, 0, "", true));
cr_604 = Call(D_10, V.Undef, L_600, ((V)("left:0;top:22px;width:320px;text-align:center;font-family:Georgia,serif;font-style:italic;color:#fffbe8;text-shadow:0 0 8px rgba(255,220,120,0.8);z-index:40;")), ((V)("<div style=\"font-size:22px;font-weight:700;\">The End</div><div style=\"font-size:8px;margin-top:5px;letter-spacing:1px;font-style:normal;\">STARRING LUMI \u00b7 ACORN \u00b7 FAWN \u00b7 TEDDY \u00b7 MOSS \u00b7 LEO</div>")));
ff_605 = Call(parts_23, V.Undef, Get(F_601, "act"), ((V)(10D)), ((V)("width:3px;height:3px;border-radius:50%;background:#fff6a0;box-shadow:0 0 5px 2px #ffe060;")), V.Null, Fn((V _arrowThis629, int _argc621, V i_627, V t_628, V _a625, V _a626, V[] _rest622) => {
return NewObj(3).Put("x", ((V)((((ToNum(i_627) * 37D) + (FdLibm.Sin(ToNum(Add(t_628, i_627))) * 12D)) % 320D)))).Put("y", ((V)(((40D + ((ToNum(i_627) % 4D) * 22D)) + (FdLibm.Cos(ToNum(Add(((V)((ToNum(t_628) * 1.2))), i_627))) * 8D))))).Put("o", ((V)((0.4 + (0.6 * System.Math.Abs(FdLibm.Sin(ToNum(Add(((V)((ToNum(t_628) * 2D))), i_627))))))))).V;
}, 2, "", true));
return Fn((V _arrowThis637, int _argc630, V t_636, V _a633, V _a634, V _a635, V[] _rest631) => {
Invoke(F_601, "upd", t_636, NewObj(3).Put("n", ((V)(1D))).Put("px", ((V)((1400D + (ToNum(t_636) * 30D))))).Put("warm", ((V)(0.25))).V);
Call(ff_605, V.Undef, t_636);
Set(Get(cr_604, "style"), "opacity", Invoke(Call(P_11, V.Undef, t_636, ((V)(2D)), ((V)(3.5))), "toFixed", ((V)(3D))));
Invoke(ns_602, "forEach", Fn((V _arrowThis646, int _argc638, V n_644, V i_645, V _a642, V _a643, V[] _rest639) => {
V s_647 = default;
s_647 = Call(go_19, V.Undef, t_636, Arr(Arr(((V)(0D)), ((V)(((-20D) - (ToNum(i_645) * 34D))))), Arr(((V)(10D)), ((V)((300D - (ToNum(i_645) * 34D)))))), NewObj(2).Put("y", ((V)(FY_33))).Put("ph", i_645).V);
Set(s_647, "f", ((V)("brightness(0.4) saturate(0.7)")));
Call(pose_18, V.Undef, n_644, s_647);
Call(put_15, V.Undef, GetK(gl_603, i_645), Get(s_647, "x"), ((V)((ToNum(Get(s_647, "y")) - 20D))), ((V)(1D)), ((V)(0D)), ((V)(1D)));
return default;
}, 2, "", true));
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
return Call(film_27, V.Undef, S_127, NewObj(1).Put("rgb", ((V)("200,210,255"))).V);
return default;
}, 0, "mk", false);
score_39 = Fn((V _self648, int _argc649, V Q_655, V _a652, V _a653, V _a654, V[] _rest650) => {
V I_656 = default;
V TH_657 = default;
V TH2_658 = default;
V theme_659 = default;
V chords_660 = default;
V DM_661 = default;
V march_662 = default;
if (_self648.IsNullish) _self648 = GlobalV;
I_656 = Call(snd_28, V.Undef, Q_655);
TH_657 = Arr(Arr(((V)(0D)), ((V)(74D)), ((V)(1D))), Arr(((V)(1D)), ((V)(76D)), ((V)(0.5))), Arr(((V)(1.5)), ((V)(78D)), ((V)(0.5))), Arr(((V)(2D)), ((V)(81D)), ((V)(1.5))), Arr(((V)(3.5)), ((V)(79D)), ((V)(0.5))), Arr(((V)(4D)), ((V)(78D)), ((V)(1D))), Arr(((V)(5D)), ((V)(76D)), ((V)(1D))), Arr(((V)(6D)), ((V)(74D)), ((V)(2D))));
TH2_658 = Arr(Arr(((V)(0D)), ((V)(71D)), ((V)(1D))), Arr(((V)(1D)), ((V)(74D)), ((V)(0.5))), Arr(((V)(1.5)), ((V)(76D)), ((V)(0.5))), Arr(((V)(2D)), ((V)(78D)), ((V)(1.5))), Arr(((V)(3.5)), ((V)(76D)), ((V)(0.5))), Arr(((V)(4D)), ((V)(74D)), ((V)(1D))), Arr(((V)(5D)), ((V)(73D)), ((V)(1D))), Arr(((V)(6D)), ((V)(74D)), ((V)(2D))));
theme_659 = Fn((V _arrowThis677, int _argc663, V t0_669, V B_670, V _a667, V _a668, V[] _rest664) => {
V f_672 = default;
V v_674 = default;
V tr_676 = default;
{ V _t671 = _a667; if (_t671.IsUndef) _t671 = Get(I_656, "str");
f_672 = _t671; }
{ V _t673 = _a668; if (_t673.IsUndef) _t673 = ((V)(0.05));
v_674 = _t673; }
{ V _t675 = (_argc663 > 4 ? _rest664[0] : V.Undef); if (_t675.IsUndef) _t675 = ((V)(0D));
tr_676 = _t675; }
Invoke(TH_657, "forEach", Fn((V _arrowThis691, int _argc678, V _a680, V _a681, V _a682, V _a683, V[] _rest679) => {
V o_686 = default;
V m_688 = default;
V d_690 = default;
{ V _t684 = ListOf(_a680);
{ V _t685 = GetIdx(_t684, 0D);
o_686 = _t685; }
{ V _t687 = GetIdx(_t684, 1D);
m_688 = _t687; }
{ V _t689 = GetIdx(_t684, 2D);
d_690 = _t689; }
}
return Call(f_672, V.Undef, Add(t0_669, ((V)((ToNum(o_686) * ToNum(B_670))))), Add(m_688, tr_676), ((V)(((ToNum(d_690) * ToNum(B_670)) * 1.05))), v_674);
}, 1, "", true));
Invoke(TH2_658, "forEach", Fn((V _arrowThis705, int _argc692, V _a694, V _a695, V _a696, V _a697, V[] _rest693) => {
V o_700 = default;
V m_702 = default;
V d_704 = default;
{ V _t698 = ListOf(_a694);
{ V _t699 = GetIdx(_t698, 0D);
o_700 = _t699; }
{ V _t701 = GetIdx(_t698, 1D);
m_702 = _t701; }
{ V _t703 = GetIdx(_t698, 2D);
d_704 = _t703; }
}
return Call(f_672, V.Undef, Add(t0_669, ((V)((ToNum(Add(((V)(8D)), o_700)) * ToNum(B_670))))), Add(m_702, tr_676), ((V)(((ToNum(d_704) * ToNum(B_670)) * 1.05))), v_674);
}, 1, "", true));
return default;
}, 5, "", true);
chords_660 = Fn((V _arrowThis718, int _argc706, V t0_712, V B_713, V n_714, V P0_715, V[] _rest707) => {
V v_717 = default;
{ V _t716 = (_argc706 > 4 ? _rest707[0] : V.Undef); if (_t716.IsUndef) _t716 = ((V)(0.02));
v_717 = _t716; }
{
double k_719 = 0;
k_719 = 0D;
while (true) {
if (!(Lt(((V)(k_719)), n_714))) break;
Invoke(I_656, "pad", Add(t0_712, ((V)(((k_719 * 4D) * ToNum(B_713))))), GetIdx(P0_715, (k_719 % ToNum(Get(P0_715, "length")))), ((V)(((4D * ToNum(B_713)) * 1.02))), v_717, ((V)("sawtooth")), ((V)(1100D)));
k_719++;
}
}
return default;
}, 5, "", true);
DM_661 = Arr(Arr(((V)(50D)), ((V)(54D)), ((V)(57D)), ((V)(62D))), Arr(((V)(47D)), ((V)(54D)), ((V)(59D)), ((V)(62D))), Arr(((V)(43D)), ((V)(50D)), ((V)(55D)), ((V)(59D))), Arr(((V)(45D)), ((V)(52D)), ((V)(57D)), ((V)(61D))));
Call(chords_660, V.Undef, ((V)(0D)), ((V)(0.75)), ((V)(4D)), DM_661, ((V)(0.018)));
Invoke(Arr(((V)(86D)), ((V)(81D)), ((V)(78D)), ((V)(74D)), ((V)(78D)), ((V)(81D))), "forEach", Fn((V _arrowThis729, int _argc721, V m_727, V k_728, V _a725, V _a726, V[] _rest722) => {
return Invoke(I_656, "bell", ((V)((1D + (ToNum(k_728) * 0.6)))), m_727, ((V)(1.2)), ((V)(0.035)));
}, 2, "", true));
Call(theme_659, V.Undef, ((V)(4.5)), ((V)(0.4)), Get(I_656, "str"), ((V)(0.035)));
Invoke(I_656, "pad", ((V)(11D)), Arr(((V)(50D)), ((V)(53D)), ((V)(57D))), ((V)(3D)), ((V)(0.02)), ((V)("triangle")), ((V)(900D)));
Invoke(I_656, "tone", ((V)(12.4)), ((V)(880D)), ((V)(0.6)), NewObj(4).Put("to", ((V)(220D))).Put("slide", ((V)(0.6))).Put("vol", ((V)(0.04))).Put("type", ((V)("triangle"))).V);
Invoke(I_656, "pad", ((V)(13.2)), Arr(((V)(46D)), ((V)(50D)), ((V)(53D))), ((V)(6.5)), ((V)(0.022)), ((V)("sawtooth")), ((V)(700D)));
Invoke(Arr(((V)(69D)), ((V)(67D)), ((V)(65D)), ((V)(62D))), "forEach", Fn((V _arrowThis738, int _argc730, V m_736, V k_737, V _a734, V _a735, V[] _rest731) => {
return Invoke(I_656, "voice", ((V)((15D + (ToNum(k_737) * 1.1)))), m_736, ((V)(1.1)), ((V)(0.05)));
}, 2, "", true));
Invoke(I_656, "pad", ((V)(20D)), Arr(((V)(50D)), ((V)(55D)), ((V)(59D))), ((V)(5D)), ((V)(0.018)));
Invoke(I_656, "tone", ((V)(25D)), ((V)(300D)), ((V)(1D)), NewObj(4).Put("to", ((V)(900D))).Put("slide", ((V)(0.9))).Put("type", ((V)("triangle"))).Put("vol", ((V)(0.02))).V);
Invoke(I_656, "noise", ((V)(25D)), ((V)(1D)), NewObj(3).Put("ft", ((V)("bandpass"))).Put("f", ((V)(1500D))).Put("vol", ((V)(0.03))).V);
march_662 = Fn((V _arrowThis750, int _argc739, V t0_745, V t1_746, V B_747, V _a744, V[] _rest740) => {
V tr_749 = default;
{ V _t748 = _a744; if (_t748.IsUndef) _t748 = ((V)(0D));
tr_749 = _t748; }
return Invoke(I_656, "beat", t0_745, t1_746, B_747, Fn((V _arrowThis759, int _argc751, V t_757, V i_758, V _a755, V _a756, V[] _rest752) => {
Invoke(I_656, "pluck", t_757, Add(((V)((ToNum(GetIdx(Arr(((V)(50D)), ((V)(57D)), ((V)(54D)), ((V)(57D))), (ToNum(i_758) % 4D))) - 12D))), tr_749), ((V)(0.2)), ((V)(0.08)));
if (((ToNum(i_758) % 4D) == 0D)) {
Invoke(I_656, "timp", t_757, ((V)(0.12)));
}
if (NumTruthy((ToNum(i_758) % 2D))) {
Invoke(I_656, "hat", t_757, ((V)(0.02)));
}
if (((ToNum(i_758) % 16D) == 0D)) {
Invoke(I_656, "pad", t_757, Invoke(GetIdx(DM_661, ((ToNum(i_758) / 16D) % 4D)), "map", Fn((V _arrowThis767, int _argc760, V m_766, V _a763, V _a764, V _a765, V[] _rest761) => {
return Add(m_766, tr_749);
}, 1, "", true)), ((V)((16D * ToNum(B_747)))), ((V)(0.014)));
}
return default;
}, 2, "", true));
}, 4, "", true);
Call(march_662, V.Undef, ((V)(28D)), ((V)(40D)), ((V)(0.375)));
Call(theme_659, V.Undef, ((V)(32D)), ((V)(0.375)), Get(I_656, "brass"), ((V)(0.035)));
Invoke(I_656, "beat", ((V)(40D)), ((V)(49.6)), ((V)(0.1875)), Fn((V _arrowThis776, int _argc768, V t_774, V i_775, V _a772, V _a773, V[] _rest769) => {
return Invoke(I_656, "pluck", t_774, GetIdx(Arr(((V)(62D)), ((V)(66D)), ((V)(69D)), ((V)(74D)), ((V)(69D)), ((V)(66D))), (ToNum(i_775) % 6D)), ((V)(0.15)), ((V)(0.04)));
}, 2, "", true));
Invoke(I_656, "noise", ((V)(40D)), ((V)(25D)), NewObj(6).Put("ft", ((V)("bandpass"))).Put("f", ((V)(900D))).Put("q", ((V)(0.5))).Put("vol", ((V)(0.02))).Put("at", ((V)(2D))).Put("sus", ((V)(1D))).V);
Invoke(Arr(((V)(44.6)), ((V)(45.2)), ((V)(45.8)), ((V)(46.4)), ((V)(47D)), ((V)(47.6)), ((V)(48.2))), "forEach", Fn((V _arrowThis784, int _argc777, V t_783, V _a780, V _a781, V _a782, V[] _rest778) => {
return Invoke(I_656, "boing", t_783, ((V)(0.04)));
}, 1, "", true));
Invoke(I_656, "beat", ((V)(49.6)), ((V)(52.6)), ((V)(0.07)), Fn((V _arrowThis793, int _argc785, V t_791, V i_792, V _a789, V _a790, V[] _rest786) => {
return Invoke(I_656, "str", t_791, ((V)((74D + (ToNum(i_792) % 2D)))), ((V)(0.08)), ((V)(0.025)));
}, 2, "", true));
Invoke(I_656, "splash", ((V)(50.4)));
Invoke(I_656, "brass", ((V)(52.6)), ((V)(62D)), ((V)(0.4)), ((V)(0.05)));
Invoke(I_656, "brass", ((V)(52.6)), ((V)(66D)), ((V)(0.4)), ((V)(0.05)));
Invoke(I_656, "brass", ((V)(53D)), ((V)(69D)), ((V)(1.6)), ((V)(0.05)));
Invoke(I_656, "crash", ((V)(53D)), ((V)(0.08)));
Call(theme_659, V.Undef, ((V)(54D)), ((V)(0.42)), Get(I_656, "str"), ((V)(0.04)));
Invoke(I_656, "beat", ((V)(65D)), ((V)(72D)), ((V)(0.5)), Fn((V _arrowThis802, int _argc794, V t_800, V i_801, V _a798, V _a799, V[] _rest795) => {
return Invoke(I_656, "tone", t_800, GetIdx(Arr(((V)(110D)), ((V)(130.8)), ((V)(146.8)), ((V)(130.8))), (ToNum(i_801) % 4D)), ((V)(0.3)), NewObj(3).Put("type", ((V)("square"))).Put("lp", ((V)(700D))).Put("vol", ((V)(0.05))).V);
}, 2, "", true));
Invoke(I_656, "bee", ((V)(65D)), ((V)(25D)), ((V)(0.018)));
Invoke(Arr(((V)(72D)), ((V)(74.6)), ((V)(77.2))), "forEach", Fn((V _arrowThis810, int _argc803, V t_809, V _a806, V _a807, V _a808, V[] _rest804) => {
Invoke(I_656, "timp", t_809, ((V)(0.35)));
Invoke(I_656, "str", t_809, ((V)(50D)), ((V)(1.2)), ((V)(0.05)));
Invoke(I_656, "str", Add(t_809, ((V)(0.6))), ((V)(57D)), ((V)(0.8)), ((V)(0.04)));
return default;
}, 1, "", true));
Invoke(I_656, "boing", ((V)(80D)), ((V)(0.12)));
Invoke(I_656, "pop", ((V)(80.2)), ((V)(0.15)));
Invoke(I_656, "crash", ((V)(80.3)), ((V)(0.08)));
Call(march_662, V.Undef, ((V)(82D)), ((V)(90D)), ((V)(0.375)), ((V)(2D)));
Invoke(I_656, "beat", ((V)(90D)), ((V)(115D)), ((V)(0.375)), Fn((V _arrowThis819, int _argc811, V t_817, V i_818, V _a815, V _a816, V[] _rest812) => {
Invoke(I_656, "pluck", t_817, GetIdx(Arr(((V)(55D)), ((V)(59D)), ((V)(62D)), ((V)(67D))), (ToNum(i_818) % 4D)), ((V)(0.15)), ((V)(0.06)));
if (((ToNum(i_818) % 2D) == 0D)) {
Invoke(I_656, "hat", t_817, ((V)(0.02)));
}
return default;
}, 2, "", true));
Invoke(Arr(((V)(96D)), ((V)(98.6)), ((V)(101.2)), ((V)(103.8))), "forEach", Fn((V _arrowThis827, int _argc820, V t_826, V _a823, V _a824, V _a825, V[] _rest821) => {
Invoke(I_656, "boing", t_826, ((V)(0.12)));
Invoke(I_656, "whoosh", t_826, ((V)(0.5)), ((V)(0.05)));
return default;
}, 1, "", true));
Invoke(I_656, "crash", ((V)(108.5)), ((V)(0.08)));
Call(theme_659, V.Undef, ((V)(108.5)), ((V)(0.4)), Get(I_656, "brass"), ((V)(0.035)), ((V)(5D)));
Invoke(I_656, "rumble", ((V)(115D)), ((V)(25D)), ((V)(0.06)));
Invoke(I_656, "thunder", ((V)(118D)));
Invoke(I_656, "thunder", ((V)(124.2)), ((V)(0.4)));
Invoke(I_656, "thunder", ((V)(133D)), ((V)(0.4)));
Invoke(I_656, "beat", ((V)(115D)), ((V)(140D)), ((V)(0.75)), Fn((V _arrowThis836, int _argc828, V t_834, V i_835, V _a832, V _a833, V[] _rest829) => {
Invoke(I_656, "str", t_834, GetIdx(Arr(((V)(38D)), ((V)(38D)), ((V)(39D)), ((V)(38D))), (ToNum(i_835) % 4D)), ((V)(0.7)), ((V)(0.035)));
if (((ToNum(i_835) % 4D) == 3D)) {
Invoke(I_656, "timp", t_834, ((V)(0.18)));
}
return default;
}, 2, "", true));
Invoke(I_656, "tone", ((V)(123.6)), ((V)(90D)), ((V)(2.4)), NewObj(6).Put("to", ((V)(60D))).Put("slide", ((V)(2D))).Put("type", ((V)("sawtooth"))).Put("lp", ((V)(500D))).Put("vol", ((V)(0.16))).Put("at", ((V)(0.1))).V);
Invoke(I_656, "noise", ((V)(123.6)), ((V)(2.2)), NewObj(5).Put("ft", ((V)("lowpass"))).Put("f", ((V)(700D))).Put("fTo", ((V)(200D))).Put("vol", ((V)(0.18))).Put("at", ((V)(0.1))).V);
Invoke(I_656, "tone", ((V)(134D)), ((V)(110D)), ((V)(1.8)), NewObj(6).Put("to", ((V)(70D))).Put("slide", ((V)(1.6))).Put("type", ((V)("sawtooth"))).Put("lp", ((V)(600D))).Put("vol", ((V)(0.12))).Put("at", ((V)(0.1))).V);
Invoke(I_656, "pad", ((V)(140D)), Arr(((V)(50D)), ((V)(54D)), ((V)(57D)), ((V)(62D))), ((V)(10D)), ((V)(0.02)), ((V)("triangle")), ((V)(1400D)));
Call(theme_659, V.Undef, ((V)(141D)), ((V)(0.5)), Get(I_656, "piano"), ((V)(0.05)));
Invoke(I_656, "sparkle", ((V)(146D)), ((V)(86D)));
Invoke(I_656, "beat", ((V)(150D)), ((V)(158.5)), ((V)(0.25)), Fn((V _arrowThis845, int _argc837, V t_843, V i_844, V _a841, V _a842, V[] _rest838) => {
return Invoke(I_656, "str", t_843, ((V)((50D + System.Math.Floor((ToNum(i_844) / 4D))))), ((V)(0.24)), ((V)((0.02 + (ToNum(i_844) * 0.0008)))));
}, 2, "", true));
Invoke(I_656, "timp", ((V)(157.8)), ((V)(0.4)));
Invoke(I_656, "timp", ((V)(158.1)), ((V)(0.45)));
Invoke(I_656, "crash", ((V)(158.5)), ((V)(0.15)));
Invoke(I_656, "boom", ((V)(158.5)), ((V)(0.25)));
Call(chords_660, V.Undef, ((V)(158.5)), ((V)(0.5)), ((V)(5D)), DM_661, ((V)(0.03)));
Call(theme_659, V.Undef, ((V)(158.5)), ((V)(0.5)), Get(I_656, "brass"), ((V)(0.05)));
Call(theme_659, V.Undef, ((V)(158.5)), ((V)(0.5)), Get(I_656, "str"), ((V)(0.04)), ((V)(12D)));
Invoke(Arr(((V)(74D)), ((V)(78D)), ((V)(81D)), ((V)(86D)), ((V)(90D))), "forEach", Fn((V _arrowThis854, int _argc846, V m_852, V k_853, V _a850, V _a851, V[] _rest847) => {
return Invoke(I_656, "bell", ((V)((158.6 + (ToNum(k_853) * 0.08)))), m_852, ((V)(1.4)), ((V)(0.05)));
}, 2, "", true));
Invoke(Arr(((V)(62D)), ((V)(66D)), ((V)(69D))), "forEach", Fn((V _arrowThis862, int _argc855, V m_861, V _a858, V _a859, V _a860, V[] _rest856) => {
return Invoke(I_656, "voice", ((V)(158.5)), m_861, ((V)(8D)), ((V)(0.025)));
}, 1, "", true));
Call(theme_659, V.Undef, ((V)(170D)), ((V)(0.55)), Get(I_656, "piano"), ((V)(0.05)));
Call(chords_660, V.Undef, ((V)(170D)), ((V)(0.55)), ((V)(4D)), DM_661, ((V)(0.014)));
Invoke(I_656, "bell", ((V)(179D)), ((V)(86D)), ((V)(1.2)), ((V)(0.04)));
return default;
}, 1, "score", false);
SM_8 = Get(G("window"), "SquadMovies");
K_9 = Get(G("window"), "MK");
if (((!(Truthy(SM_8)) || !(Truthy(K_9))) || !(Truthy(Get(SM_8, "def"))))) {
return default;
}
{ V _t863 = K_9;
if (_t863.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t863));
{ V _t864 = Get(_t863, "D");
D_10 = _t864; }
{ V _t865 = Get(_t863, "P");
P_11 = _t865; }
{ V _t866 = Get(_t863, "E");
E_12 = _t866; }
{ V _t867 = Get(_t863, "kf");
kf_13 = _t867; }
{ V _t868 = Get(_t863, "win");
win_14 = _t868; }
{ V _t869 = Get(_t863, "put");
put_15 = _t869; }
{ V _t870 = Get(_t863, "show");
show_16 = _t870; }
{ V _t871 = Get(_t863, "actor");
actor_17 = _t871; }
{ V _t872 = Get(_t863, "pose");
pose_18 = _t872; }
{ V _t873 = Get(_t863, "go");
go_19 = _t873; }
{ V _t874 = Get(_t863, "dance");
dance_20 = _t874; }
{ V _t875 = Get(_t863, "bub");
bub_21 = _t875; }
{ V _t876 = Get(_t863, "lines");
lines_22 = _t876; }
{ V _t877 = Get(_t863, "parts");
parts_23 = _t877; }
{ V _t878 = Get(_t863, "rain");
rain_24 = _t878; }
{ V _t879 = Get(_t863, "lightning");
lightning_25 = _t879; }
{ V _t880 = Get(_t863, "glow");
glow_26 = _t880; }
{ V _t881 = Get(_t863, "film");
film_27 = _t881; }
{ V _t882 = Get(_t863, "snd");
snd_28 = _t882; }
{ V _t883 = Get(_t863, "rnd");
rnd_29 = _t883; }
{ V _t884 = Get(_t863, "cl");
cl_30 = _t884; }
{ V _t885 = Get(_t863, "lerp");
lerp_31 = _t885; }
{ V _t886 = Get(_t863, "stars");
stars_32 = _t886; } }
FY_33 = 152D;
W_34 = 54D;
aura_36 = Fn((V _arrowThis898, int _argc887, V p_893, V _a890, V _a891, V _a892, V[] _rest888) => {
V c_895 = default;
V r_897 = default;
{ V _t894 = _a890; if (_t894.IsUndef) _t894 = ((V)("rgba(255,236,150,0.75)"));
c_895 = _t894; }
{ V _t896 = _a891; if (_t896.IsUndef) _t896 = ((V)(46D));
r_897 = _t896; }
return Call(glow_26, V.Undef, p_893, c_895, r_897, ((V)("z-index:3;mix-blend-mode:screen;")));
}, 3, "", true);
walkers_37 = Fn((V _arrowThis912, int _argc899, V t_905, V keys_906, V ns_907, V _a904, V[] _rest900) => {
V gap_909 = default;
V o_911 = default;
{ V _t908 = _a904; if (_t908.IsUndef) _t908 = ((V)(34D));
gap_909 = _t908; }
{ V _t910 = (_argc899 > 4 ? _rest900[0] : V.Undef); if (_t910.IsUndef) _t910 = NewObj(0).V;
o_911 = _t910; }
return Invoke(ns_907, "map", Fn((V _arrowThis921, int _argc913, V n_919, V i_920, V _a917, V _a918, V[] _rest914) => {
return Call(pose_18, V.Undef, n_919, Call(go_19, V.Undef, ((V)((ToNum(t_905) - (ToNum(i_920) * 0.12)))), Invoke(keys_906, "map", Fn((V _arrowThis929, int _argc922, V k_928, V _a925, V _a926, V _a927, V[] _rest923) => {
return Arr(GetIdx(k_928, 0D), ((V)((ToNum(GetIdx(k_928, 1D)) - (ToNum(i_920) * ToNum(gap_909))))), GetIdx(k_928, 2D), GetIdx(k_928, 3D));
}, 1, "", true)), Object_assign(NewObj(2).Put("y", ((V)(FY_33))).Put("ph", ((V)((ToNum(i_920) * 1.3)))).V, o_911)));
}, 2, "", true));
}, 5, "", true);
Invoke(SM_8, "def", ((V)("lantern")), NewObj(4).Put("mk", mk_38).Put("score", score_39).Put("beat", Fn((V _arrowThis937, int _argc930, V t_936, V _a933, V _a934, V _a935, V[] _rest931) => {
V on_938 = default;
double x_939 = 0;
on_938 = ((((GeN(t_936, 28D) && LtN(t_936, 40D)) || (GeN(t_936, 82D) && LtN(t_936, 115D))) || (GeN(t_936, 160D) && LtN(t_936, 170D))) ? V.True : V.False);
if (!(Truthy(on_938))) {
return V.Null;
}
x_939 = (ToNum(t_936) / 0.375);
return NewObj(3).Put("n", ((V)(System.Math.Floor(x_939)))).Put("ph", ((V)((x_939 - System.Math.Floor(x_939))))).Put("amp", ((V)(0.6))).V;
return default;
}, 1, "beat", true)).Put("cues", Arr(Arr(((V)(13.3)), ((V)("gasp"))), Arr(((V)(33D)), ((V)("cheer"))), Arr(((V)(50.2)), ((V)("gasp"))), Arr(((V)(53D)), ((V)("cheer"))), Arr(((V)(80.3)), ((V)("laugh"))), Arr(((V)(96.2)), ((V)("laugh"))), Arr(((V)(108.5)), ((V)("cheer"))), Arr(((V)(119D)), ((V)("doze"))), Arr(((V)(125D)), ((V)("hide"))), Arr(((V)(133.2)), ((V)("hide"))), Arr(((V)(146.5)), ((V)("cheer"))), Arr(((V)(158.3)), ((V)("wake"))), Arr(((V)(159D)), ((V)("cheer"))), Arr(((V)(164D)), ((V)("cheer"))))).V);
return default;
}, 0, "", false), V.Undef);
        }
    }
}
