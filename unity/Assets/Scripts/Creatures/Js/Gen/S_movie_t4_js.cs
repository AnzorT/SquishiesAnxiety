// movie-t4.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_movie_t4_js
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
V glow_24 = default;
V film_25 = default;
V snd_26 = default;
V rnd_27 = default;
V cl_28 = default;
V lerp_29 = default;
V stars_30 = default;
double W_31 = 0;
V SPR_32 = default;
V SHIP_33 = default;
V FLAME_34 = default;
V shipN_35 = default;
V ship_36 = default;
V space_37 = default;
V planet_38 = default;
V bridge_39 = default;
V burst_40 = default;
V paint_41 = default;
V mk_42 = default;
V score_43 = default;
if (_self1.IsNullish) _self1 = GlobalV;
space_37 = Fn((V _self44, int _argc45, V L_51, V seed_52, V _a49, V _a50, V[] _rest46) => {
V ly_55 = default;
V streak_56 = default;
V o_54 = default;
if (_self44.IsNullish) _self44 = GlobalV;
{ V _t53 = _a49; if (_t53.IsUndef) _t53 = NewObj(0).V;
o_54 = _t53; }
Call(D_10, V.Undef, L_51, ((V)(JsStrBuf.Begin().S("inset:0;background:").V((Get(o_54, "bg") is var _t57 && Truthy(_t57) ? _t57 : ((V)("radial-gradient(ellipse at 70% 40%,#1a1446,#070618 70%)")))).S(";").End())));
ly_55 = Invoke(Arr(Arr(((V)(90D)), ((V)(0.15)), ((V)(1D))), Arr(((V)(60D)), ((V)(0.4)), ((V)(1.4))), Arr(((V)(30D)), ((V)(1D)), ((V)(1.8)))), "map", Fn((V _arrowThis72, int _argc58, V _a60, V i_64, V _a62, V _a63, V[] _rest59) => {
V a_73 = default;
V b_74 = default;
V g_75 = default;
V n_67 = default;
V f_69 = default;
V s_71 = default;
{ V _t65 = ListOf(_a60);
{ V _t66 = GetIdx(_t65, 0D);
n_67 = _t66; }
{ V _t68 = GetIdx(_t65, 1D);
f_69 = _t68; }
{ V _t70 = GetIdx(_t65, 2D);
s_71 = _t70; }
}
a_73 = Call(stars_30, V.Undef, L_51, n_67, ((V)(640D)), ((V)(180D)), Add(seed_52, i_64), ((V)((Truthy(i_64) ? "#ffffff" : "#c9d4ff"))), s_71);
Set(a_73, "_f", f_69);
b_74 = Call(stars_30, V.Undef, L_51, n_67, ((V)(640D)), ((V)(180D)), Add(seed_52, i_64), ((V)((Truthy(i_64) ? "#ffffff" : "#c9d4ff"))), s_71);
Set(b_74, "_f", f_69);
Set(Get(b_74, "style"), "left", ((V)("640px")));
g_75 = Call(D_10, V.Undef, L_51, ((V)("left:0;top:0;width:1280px;height:180px;")));
Invoke(g_75, "appendChild", a_73);
Invoke(g_75, "appendChild", b_74);
Set(g_75, "_f", f_69);
return g_75;
return default;
}, 2, "", true));
streak_56 = Call(D_10, V.Undef, L_51, ((V)("inset:0;opacity:0;background:repeating-linear-gradient(0deg,rgba(255,255,255,0) 0 7px,rgba(220,230,255,0.6) 7px 8px,rgba(255,255,255,0) 8px 17px);")));
return NewObj(1).Put("upd", Fn((V _self76, int _argc77, V t_83, V _a80, V _a81, V _a82, V[] _rest78) => {
V sp_85 = default;
V wp_87 = default;
if (_self76.IsNullish) _self76 = GlobalV;
{ V _t84 = _a80; if (_t84.IsUndef) _t84 = ((V)(60D));
sp_85 = _t84; }
{ V _t86 = _a81; if (_t86.IsUndef) _t86 = ((V)(0D));
wp_87 = _t86; }
Invoke(ly_55, "forEach", Fn((V _arrowThis95, int _argc88, V g_94, V _a91, V _a92, V _a93, V[] _rest89) => {
Set(Get(g_94, "style"), "transform", ((V)(JsStrBuf.Begin().S("translateX(").V(Invoke(((V)((-(((ToNum(t_83) * ToNum(sp_85)) * ToNum(Get(g_94, "_f"))) % 640D)))), "toFixed", ((V)(1D)))).S("px)").End())));
return default;
}, 1, "", true));
Set(Get(streak_56, "style"), "opacity", Invoke(((V)((ToNum(wp_87) * 0.8))), "toFixed", ((V)(3D))));
Set(Get(streak_56, "style"), "transform", ((V)(JsStrBuf.Begin().S("scaleX(").N((1D + (ToNum(wp_87) * 3D))).S(")").End())));
return default;
}, 3, "upd", false)).V;
return default;
}, 3, "space", false);
bridge_39 = Fn((V _self96, int _argc97, V L_103, V _a100, V _a101, V _a102, V[] _rest98) => {
V wn_106 = default;
V sp_107 = default;
V lt_108 = default;
V act_109 = default;
V alarm_110 = default;
V o_105 = default;
if (_self96.IsNullish) _self96 = GlobalV;
{ V _t104 = _a100; if (_t104.IsUndef) _t104 = NewObj(0).V;
o_105 = _t104; }
Call(D_10, V.Undef, L_103, ((V)("inset:0;background:linear-gradient(#3a4070,#252a50);")));
wn_106 = Call(D_10, V.Undef, L_103, ((V)("left:40px;top:14px;width:240px;height:88px;border-radius:44px 44px 10px 10px;overflow:hidden;border:5px solid #8a94c8;box-sizing:border-box;")));
sp_107 = Call(space_37, V.Undef, wn_106, (Get(o_105, "seed") is var _t111 && Truthy(_t111) ? _t111 : ((V)(3D))));
Call(D_10, V.Undef, L_103, ((V)("left:0;top:100px;width:320px;height:80px;background:linear-gradient(#4a5290,#2e3466);")));
Call(D_10, V.Undef, L_103, ((V)("left:0;top:100px;width:320px;height:4px;background:#9aa4d8;")));
lt_108 = Array_from(NewObj(1).Put("length", ((V)(12D))).V, Fn((V _arrowThis120, int _argc112, V __118, V i_119, V _a116, V _a117, V[] _rest113) => {
return Call(D_10, V.Undef, L_103, ((V)(JsStrBuf.Begin().S("left:").N((14D + (ToNum(i_119) * 26D))).S("px;top:112px;width:6px;height:6px;border-radius:50%;background:").V(GetIdx(SPR_32, (ToNum(i_119) % 5D))).S(";").End())));
}, 2, "", true));
act_109 = Call(D_10, V.Undef, L_103, ((V)("inset:0;")));
alarm_110 = Call(D_10, V.Undef, L_103, ((V)("inset:0;background:#ff2a4a;opacity:0;pointer-events:none;")));
return NewObj(3).Put("wn", wn_106).Put("act", act_109).Put("upd", Fn((V _self121, int _argc122, V t_128, V _a125, V _a126, V _a127, V[] _rest123) => {
V q_130 = default;
if (_self121.IsNullish) _self121 = GlobalV;
{ V _t129 = _a125; if (_t129.IsUndef) _t129 = NewObj(0).V;
q_130 = _t129; }
Invoke(sp_107, "upd", t_128, (Get(q_130, "sp") is var _t131 && !_t131.IsNullish ? _t131 : ((V)(40D))), (Get(q_130, "wp") is var _t132 && Truthy(_t132) ? _t132 : ((V)(0D))));
Invoke(lt_108, "forEach", Fn((V _arrowThis141, int _argc133, V l_139, V i_140, V _a137, V _a138, V[] _rest134) => {
Set(Get(l_139, "style"), "opacity", Invoke(((V)(((FdLibm.Sin(((ToNum(t_128) * 3D) + (ToNum(i_140) * 1.7))) > 0D) ? 1D : 0.3))), "toFixed", ((V)(2D))));
return default;
}, 2, "", true));
Set(Get(alarm_110, "style"), "opacity", Invoke(((V)((ToNum((Get(q_130, "alarm") is var _t142 && Truthy(_t142) ? _t142 : ((V)(0D)))) * (0.18 + (0.14 * FdLibm.Sin((ToNum(t_128) * 8D))))))), "toFixed", ((V)(3D))));
return default;
}, 2, "upd", false)).V;
return default;
}, 2, "bridge", false);
mk_42 = Fn((V _self143, int _argc144, V _a146, V _a147, V _a148, V _a149, V[] _rest145) => {
V S_150 = default;
if (_self143.IsNullish) _self143 = GlobalV;
S_150 = Arr();
Invoke(S_150, "push", NewObj(5).Put("a", ((V)(0D))).Put("b", ((V)(25D))).Put("rgb", ((V)("255,190,140"))).Put("lit", Fn((V _arrowThis158, int _argc151, V t_157, V _a154, V _a155, V _a156, V[] _rest152) => {
return ((V)((0.7 + ((GtN(t_157, 9D) && LtN(t_157, 14D)) ? 0.4 : 0D))));
}, 1, "lit", true)).Put("mk", Fn((V _self159, int _argc160, V L_166, V _a163, V _a164, V _a165, V[] _rest161) => {
V sky_167 = default;
V st_168 = default;
V cam_169 = default;
V gnd_170 = default;
V sh_171 = default;
V cnt_172 = default;
V crew_173 = default;
V sp_174 = default;
V smoke_175 = default;
if (_self159.IsNullish) _self159 = GlobalV;
sky_167 = Call(D_10, V.Undef, L_166, ((V)("inset:0;")));
st_168 = Call(stars_30, V.Undef, L_166, ((V)(80D)), ((V)(320D)), ((V)(180D)), ((V)(5D)), ((V)("#fff")), ((V)(1.2)));
cam_169 = Call(D_10, V.Undef, L_166, ((V)("inset:0;")));
gnd_170 = Call(D_10, V.Undef, cam_169, ((V)("left:-20px;top:150px;width:360px;height:60px;background:linear-gradient(#6a5a8a,#3a2e5a);")));
Call(D_10, V.Undef, cam_169, ((V)("left:200px;top:40px;width:14px;height:112px;background:repeating-linear-gradient(45deg,#c8443a 0 6px,#e8e0d8 6px 12px);")));
Call(D_10, V.Undef, cam_169, ((V)("left:186px;top:60px;width:30px;height:4px;background:#8a8a9a;")));
sh_171 = Call(shipN_35, V.Undef, cam_169);
cnt_172 = Call(D_10, V.Undef, L_166, ((V)("left:0;top:18px;width:320px;text-align:center;font-size:44px;font-weight:700;color:#fff;text-shadow:0 3px 0 #3a1a5c;z-index:40;")), ((V)("")));
crew_173 = Invoke(Arr(((V)("zappi")), ((V)("twinkle")), ((V)("nimbo"))), "map", Fn((V _arrowThis183, int _argc176, V k_182, V _a179, V _a180, V _a181, V[] _rest177) => {
return Call(actor_17, V.Undef, cam_169, k_182, ((V)((W_31 - 8D))));
}, 1, "", true));
sp_174 = Call(bub_21, V.Undef, L_166);
smoke_175 = Call(parts_23, V.Undef, cam_169, ((V)(14D)), ((V)("width:30px;height:30px;border-radius:50%;background:#e8e4f0;z-index:9;")), V.Null, Fn((V _arrowThis192, int _argc184, V i_190, V t_191, V _a188, V _a189, V[] _rest185) => {
double d_193 = 0;
double s_194 = 0;
d_193 = ((ToNum(t_191) - 9D) - ((ToNum(i_190) % 7D) * 0.1));
if ((d_193 < 0D)) {
return V.Null;
}
s_194 = (NumTruthy((ToNum(i_190) % 2D)) ? 1D : (-1D));
return NewObj(4).Put("x", ((V)((160D + (s_194 * (10D + ((d_193 * 40D) * (1D + ((ToNum(i_190) % 3D) * 0.4))))))))).Put("y", ((V)((148D - (d_193 * 4D))))).Put("k", ((V)((0.6 + (d_193 * 0.6))))).Put("o", ((V)((0.9 * (1D - ToNum(Call(P_11, V.Undef, ((V)(d_193)), ((V)(1D)), ((V)(5D))))))))).V;
return default;
}, 2, "", true));
return Fn((V _arrowThis202, int _argc195, V t_201, V _a198, V _a199, V _a200, V[] _rest196) => {
V up_203 = default;
V sk_204 = default;
double shk_205 = 0;
V c_206 = default;
double f_207 = 0;
up_203 = Call(kf_13, V.Undef, t_201, Arr(Arr(((V)(10D)), ((V)(0D))), Arr(((V)(16D)), ((V)(260D))), Arr(((V)(25D)), ((V)(600D)))), Get(E_12, "in"));
sk_204 = Call(P_11, V.Undef, t_201, ((V)(12D)), ((V)(22D)));
Set(Get(sky_167, "style"), "background", ((V)(JsStrBuf.Begin().S("linear-gradient(hsl(").V(Call(lerp_29, V.Undef, ((V)(220D)), ((V)(240D)), sk_204)).S(",60%,").V(Call(lerp_29, V.Undef, ((V)(62D)), ((V)(6D)), sk_204)).S("%),hsl(").V(Call(lerp_29, V.Undef, ((V)(25D)), ((V)(250D)), sk_204)).S(",").V(Call(lerp_29, V.Undef, ((V)(80D)), ((V)(40D)), sk_204)).S("%,").V(Call(lerp_29, V.Undef, ((V)(78D)), ((V)(10D)), sk_204)).S("%))").End())));
Set(Get(st_168, "style"), "opacity", Invoke(sk_204, "toFixed", ((V)(2D))));
Set(Get(cam_169, "style"), "transform", ((V)(JsStrBuf.Begin().S("translateY(").V(Invoke(((V)(Min(ToNum(up_203), 220D))), "toFixed", ((V)(1D)))).S("px)").End())));
shk_205 = ((GtN(t_201, 9D) && LtN(t_201, 18D)) ? (FdLibm.Sin((ToNum(t_201) * 60D)) * 1.2) : 0D);
Call(ship_36, V.Undef, sh_171, ((V)((160D + shk_205))), ((V)(((110D - Min(ToNum(up_203), 220D)) - (Max(0D, (ToNum(up_203) - 220D)) * 0.2)))), ((V)(1D)), ((V)((-90D))), ((V)((GtN(t_201, 8.6) ? 1D : 0D))), t_201);
Call(smoke_175, V.Undef, t_201);
Invoke(crew_173, "forEach", Fn((V _arrowThis216, int _argc208, V n_214, V i_215, V _a212, V _a213, V[] _rest209) => {
double a_217 = 0;
a_217 = (0.6 + (ToNum(i_215) * 1.2));
Call(pose_18, V.Undef, n_214, (LtN(t_201, (a_217 + 2.2)) ? Call(go_19, V.Undef, t_201, Arr(Arr(((V)(0D)), ((V)(((-20D) - (ToNum(i_215) * 30D))))), Arr(((V)((a_217 + 1.6))), ((V)((150D + (ToNum(i_215) * 4D))))), Arr(((V)((a_217 + 2.2))), ((V)(158D)), ((V)(140D)))), NewObj(2).Put("y", ((V)(150D))).Put("o", ((V)((GtN(t_201, (a_217 + 1.6)) ? (1D - ToNum(Call(P_11, V.Undef, t_201, ((V)((a_217 + 1.6))), ((V)((a_217 + 2.2)))))) : 1D)))).V) : V.Null));
return default;
}, 2, "", true));
c_206 = ((V)(((GeN(t_201, 5.6) && LtN(t_201, 8.6)) ? ToStrS(((V)((3D - System.Math.Floor((ToNum(t_201) - 5.6)))))) : ((GeN(t_201, 8.6) && LtN(t_201, 10D)) ? "BLAST OFF!" : ""))));
if (!SEq(Get(cnt_172, "textContent"), c_206)) {
Set(cnt_172, "textContent", c_206);
}
Set(Get(cnt_172, "style"), "fontSize", ((V)((GtN(Get(c_206, "length"), 2D) ? "30px" : "44px"))));
f_207 = ((ToNum(t_201) - 5.6) % 1D);
Set(Get(cnt_172, "style"), "transform", ((V)(JsStrBuf.Begin().S("scale(").V(Invoke(((V)((1D + (0.3 * FdLibm.Exp(((-f_207) * 6D)))))), "toFixed", ((V)(3D)))).S(")").End())));
Call(lines_22, V.Undef, sp_174, t_201, Arr(Arr(((V)(0.4)), ((V)(3.2)), ((V)("All aboard, crew!")), ((V)("z")))), NewObj(1).Put("z", Arr(((V)(60D)), ((V)(100D)))).V);
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
Invoke(S_150, "push", NewObj(4).Put("a", ((V)(25D))).Put("b", ((V)(50D))).Put("rgb", ((V)("150,170,255"))).Put("mk", Fn((V _self218, int _argc219, V L_225, V _a222, V _a223, V _a224, V[] _rest220) => {
V @out_226 = default;
V sp0_227 = default;
V pl_228 = default;
V pl2_229 = default;
V sh_230 = default;
V inn_231 = default;
V B_232 = default;
V z_233 = default;
V tw_234 = default;
V nb_235 = default;
V pp_236 = default;
V sp_237 = default;
V box_238 = default;
V lid_239 = default;
if (_self218.IsNullish) _self218 = GlobalV;
@out_226 = Call(D_10, V.Undef, L_225, ((V)("inset:0;")));
sp0_227 = Call(space_37, V.Undef, @out_226, ((V)(7D)));
pl_228 = Call(planet_38, V.Undef, @out_226, ((V)(60D)), ((V)("radial-gradient(circle at 35% 35%,#ffd0a0,#e0703a 70%)")), ((V)("#ffe0b0")));
pl2_229 = Call(planet_38, V.Undef, @out_226, ((V)(26D)), ((V)("radial-gradient(circle at 35% 35%,#c0f0ff,#3a8ac0 70%)")));
sh_230 = Call(shipN_35, V.Undef, @out_226);
inn_231 = Call(D_10, V.Undef, L_225, ((V)("inset:0;display:none;")));
B_232 = Call(bridge_39, V.Undef, inn_231, NewObj(1).Put("seed", ((V)(9D))).V);
z_233 = Call(actor_17, V.Undef, Get(B_232, "act"), ((V)("zappi")), ((V)((W_31 + 4D))));
tw_234 = Call(actor_17, V.Undef, Get(B_232, "act"), ((V)("twinkle")), ((V)(W_31)));
nb_235 = Call(actor_17, V.Undef, Get(B_232, "act"), ((V)("nimbo")), ((V)(W_31)));
pp_236 = Call(actor_17, V.Undef, Get(B_232, "act"), ((V)("pip")), ((V)((W_31 - 4D))));
sp_237 = Call(bub_21, V.Undef, L_225);
box_238 = Call(D_10, V.Undef, Get(B_232, "act"), ((V)("left:236px;top:120px;width:44px;height:36px;z-index:6;background:repeating-linear-gradient(90deg,#c8a06a 0 10px,#b8905a 10px 12px);border:2px solid #6a4a2a;box-sizing:border-box;")));
lid_239 = Call(D_10, V.Undef, Get(B_232, "act"), ((V)("left:0;top:0;width:48px;height:8px;background:#a8804a;border:2px solid #6a4a2a;box-sizing:border-box;z-index:7;display:none;")));
return Fn((V _arrowThis247, int _argc240, V t_246, V _a243, V _a244, V _a245, V[] _rest241) => {
V io_248 = default;
double u_249 = 0;
double rat_250 = 0;
V op_251 = default;
io_248 = (GeN(t_246, 7D) ? V.True : V.False);
Call(show_16, V.Undef, @out_226, (!(Truthy(io_248)) ? V.True : V.False));
Call(show_16, V.Undef, inn_231, io_248);
if (!(Truthy(io_248))) {
Invoke(sp0_227, "upd", t_246, ((V)(90D)));
Call(put_15, V.Undef, pl_228, ((V)((300D - (ToNum(t_246) * 22D)))), ((V)(50D)), ((V)(1D)), ((V)(0D)), ((V)(1D)));
Call(put_15, V.Undef, pl2_229, ((V)((360D - (ToNum(t_246) * 40D)))), ((V)(130D)), ((V)(1D)), ((V)(0D)), ((V)(1D)));
Call(ship_36, V.Undef, sh_230, ((V)((90D + (ToNum(t_246) * 8D)))), ((V)((92D + (FdLibm.Sin((ToNum(t_246) * 1.5)) * 6D)))), ((V)(0.9)), ((V)((FdLibm.Sin((ToNum(t_246) * 1.5)) * 3D))), ((V)(1D)), t_246);
return default;
}
u_249 = (ToNum(t_246) - 7D);
Invoke(B_232, "upd", t_246);
Call(pose_18, V.Undef, z_233, NewObj(3).Put("x", ((V)(160D))).Put("y", ((V)(158D))).Put("v", ((V)("front"))).V);
Call(pose_18, V.Undef, tw_234, NewObj(3).Put("x", ((V)(82D))).Put("y", ((V)(158D))).Put("v", ((V)((((u_249 > 8.4) && (u_249 < 11D)) ? "right" : "front")))).V);
Call(pose_18, V.Undef, nb_235, NewObj(4).Put("x", ((V)(112D))).Put("y", ((V)((140D + (FdLibm.Sin((ToNum(t_246) * 2D)) * 3D))))).Put("v", ((V)((((u_249 > 8.4) && (u_249 < 11D)) ? "right" : "front")))).Put("gy", ((V)(158D))).V);
rat_250 = (((u_249 > 3D) && (u_249 < 8.6)) ? ((FdLibm.Sin((ToNum(t_246) * 50D)) * 2D) * (0.4 + (0.6 * System.Math.Abs(FdLibm.Sin((ToNum(t_246) * 2D)))))) : 0D);
Set(Get(box_238, "style"), "transform", ((V)(JsStrBuf.Begin().S("translateX(").V(Invoke(((V)(rat_250)), "toFixed", ((V)(1D)))).S("px)").End())));
op_251 = Call(P_11, V.Undef, ((V)(u_249)), ((V)(8.6)), ((V)(9D)));
if (GtN(op_251, 0D)) {
double d_252 = 0;
d_252 = (u_249 - 8.6);
Call(put_15, V.Undef, lid_239, ((V)((258D + (d_252 * 30D)))), ((V)(((120D - (d_252 * 60D)) + ((d_252 * d_252) * 60D)))), ((V)(1D)), ((V)((d_252 * 300D))), ((V)((1D - ToNum(Call(P_11, V.Undef, ((V)(d_252)), ((V)(1.2)), ((V)(1.6))))))));
} else {
Call(show_16, V.Undef, lid_239, (false ? V.True : V.False));
}
Call(pose_18, V.Undef, pp_236, ((u_249 > 8.6) ? NewObj(5).Put("x", ((V)(258D))).Put("y", ((V)((132D - (FdLibm.Sin((System.Math.PI * ToNum(Call(P_11, V.Undef, ((V)(u_249)), ((V)(8.6)), ((V)(9.4)))))) * 14D))))).Put("v", ((V)("front"))).Put("sx", ((V)((1D + (0.08 * FdLibm.Sin((u_249 * 9D))))))).Put("sh", (false ? V.True : V.False)).V : V.Null));
Call(lines_22, V.Undef, sp_237, ((V)(u_249)), Arr(Arr(((V)(0.6)), ((V)(3.6)), ((V)("Course set for Planet Sprinkle.")), ((V)("z"))), Arr(((V)(8.9)), ((V)(11D)), ((V)("Surprise!")), ((V)("p"))), Arr(((V)(11.4)), ((V)(14D)), ((V)("A stowaway?!")), ((V)("z"))), Arr(((V)(14.4)), ((V)(17.6)), ((V)("Can I come? Pleeease?")), ((V)("p")))), NewObj(2).Put("z", Arr(((V)(160D)), ((V)(104D)))).Put("p", Arr(((V)(258D)), ((V)(86D)))).V);
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
Invoke(S_150, "push", NewObj(4).Put("a", ((V)(50D))).Put("b", ((V)(70D))).Put("rgb", ((V)("255,160,210"))).Put("mk", Fn((V _self253, int _argc254, V L_260, V _a257, V _a258, V _a259, V[] _rest255) => {
V inn_261 = default;
V B_262 = default;
V z_263 = default;
V tw_264 = default;
V pp_265 = default;
V sp_266 = default;
V holo_267 = default;
V sl_268 = default;
V @out_269 = default;
V sp0_270 = default;
V sh_271 = default;
if (_self253.IsNullish) _self253 = GlobalV;
inn_261 = Call(D_10, V.Undef, L_260, ((V)("inset:0;")));
B_262 = Call(bridge_39, V.Undef, inn_261, NewObj(1).Put("seed", ((V)(11D))).V);
z_263 = Call(actor_17, V.Undef, Get(B_262, "act"), ((V)("zappi")), ((V)((W_31 + 4D))));
tw_264 = Call(actor_17, V.Undef, Get(B_262, "act"), ((V)("twinkle")), ((V)(W_31)));
pp_265 = Call(actor_17, V.Undef, Get(B_262, "act"), ((V)("pip")), ((V)((W_31 - 8D))));
sp_266 = Call(bub_21, V.Undef, L_260);
holo_267 = Call(D_10, V.Undef, Get(B_262, "wn"), ((V)("left:84px;top:8px;width:62px;height:62px;border-radius:50%;")));
sl_268 = Array_from(NewObj(1).Put("length", ((V)(14D))).V, Fn((V _arrowThis280, int _argc272, V __278, V i_279, V _a276, V _a277, V[] _rest273) => {
return Call(D_10, V.Undef, holo_267, ((V)(JsStrBuf.Begin().S("left:").N((10D + ((ToNum(i_279) * 37D) % 42D))).S("px;top:").N((8D + ((ToNum(i_279) * 23D) % 44D))).S("px;width:5px;height:2px;border-radius:1px;background:").V(GetIdx(SPR_32, (ToNum(i_279) % 5D))).S(";transform:rotate(").N((ToNum(i_279) * 47D)).S("deg);").End())));
}, 2, "", true));
@out_269 = Call(D_10, V.Undef, L_260, ((V)("inset:0;display:none;")));
sp0_270 = Call(space_37, V.Undef, @out_269, ((V)(13D)));
sh_271 = Call(shipN_35, V.Undef, @out_269);
return Fn((V _arrowThis288, int _argc281, V t_287, V _a284, V _a285, V _a286, V[] _rest282) => {
V w_289 = default;
double u_290 = 0;
V wp_291 = default;
w_289 = (GeN(t_287, 11D) ? V.True : V.False);
Call(show_16, V.Undef, inn_261, (!(Truthy(w_289)) ? V.True : V.False));
Call(show_16, V.Undef, @out_269, w_289);
if (!(Truthy(w_289))) {
double fd_292 = 0;
Invoke(B_262, "upd", t_287);
fd_292 = (0.35 + (0.25 * FdLibm.Sin((ToNum(t_287) * 3D))));
Set(Get(holo_267, "style"), "background", ((V)(JsStrBuf.Begin().S("radial-gradient(circle at 35% 35%,hsl(330,").N((30D * fd_292)).S("%,").N((60D + (10D * fd_292))).S("%),hsl(330,").N((20D * fd_292)).S("%,30%) 75%)").End())));
Set(Get(holo_267, "style"), "boxShadow", ((V)(JsStrBuf.Begin().S("0 0 14px 3px rgba(255,150,210,").V(Invoke(((V)((0.3 * fd_292))), "toFixed", ((V)(2D)))).S(")").End())));
Invoke(sl_268, "forEach", Fn((V _arrowThis301, int _argc293, V s_299, V i_300, V _a297, V _a298, V[] _rest294) => {
Set(Get(s_299, "style"), "opacity", Invoke(((V)(((FdLibm.Sin(ToNum(Add(((V)((ToNum(t_287) * 5D))), i_300))) > 0.3) ? 0.9 : 0.15))), "toFixed", ((V)(2D))));
return default;
}, 2, "", true));
Call(pose_18, V.Undef, z_263, NewObj(3).Put("x", ((V)(160D))).Put("y", ((V)(158D))).Put("v", ((V)(((GtN(t_287, 6.5) && LtN(t_287, 7.5)) ? "front" : "back")))).V);
Call(pose_18, V.Undef, tw_264, NewObj(3).Put("x", ((V)(92D))).Put("y", ((V)(158D))).Put("v", ((V)("front"))).V);
Call(pose_18, V.Undef, pp_265, NewObj(3).Put("x", ((V)(236D))).Put("y", ((V)(158D))).Put("v", ((V)("front"))).V);
Call(lines_22, V.Undef, sp_266, t_287, Arr(Arr(((V)(1D)), ((V)(5.2)), ((V)("Planet Sprinkle\u2019s candy core is fading!")), ((V)("t"))), Arr(((V)(5.6)), ((V)(7.4)), ((V)("Oh no!")), ((V)("p"))), Arr(((V)(7.6)), ((V)(10.6)), ((V)("Full speed ahead!")), ((V)("z")))), NewObj(3).Put("t", Arr(((V)(92D)), ((V)(104D)))).Put("p", Arr(((V)(236D)), ((V)(108D)))).Put("z", Arr(((V)(160D)), ((V)(104D)))).V);
return default;
}
u_290 = (ToNum(t_287) - 11D);
wp_291 = Call(P_11, V.Undef, ((V)(u_290)), ((V)(0.5)), ((V)(3D)));
Invoke(sp0_270, "upd", t_287, ((V)((90D + (ToNum(wp_291) * 900D)))), wp_291);
Call(ship_36, V.Undef, sh_271, ((V)((160D + ((FdLibm.Sin((u_290 * 30D)) * ToNum(wp_291)) * 1.5)))), ((V)(90D)), ((V)((1D + (ToNum(wp_291) * 0.1)))), ((V)(0D)), ((V)(1D)), t_287);
Call(sp_266, V.Undef, V.Null);
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
Invoke(S_150, "push", NewObj(5).Put("a", ((V)(70D))).Put("b", ((V)(105D))).Put("rgb", ((V)("170,180,255"))).Put("lit", Fn((V _arrowThis309, int _argc302, V t_308, V _a305, V _a306, V _a307, V[] _rest303) => {
return ((V)(0.6));
}, 1, "lit", true)).Put("mk", Fn((V _self310, int _argc311, V L_317, V _a314, V _a315, V _a316, V[] _rest312) => {
V sp0_318 = default;
V sh_319 = default;
V sp_320 = default;
V r_321 = default;
V AS_322 = default;
V zz_323 = default;
if (_self310.IsNullish) _self310 = GlobalV;
sp0_318 = Call(space_37, V.Undef, L_317, ((V)(17D)));
sh_319 = Call(shipN_35, V.Undef, L_317);
sp_320 = Call(bub_21, V.Undef, L_317);
r_321 = Call(rnd_27, V.Undef, ((V)(99D)));
AS_322 = Array_from(NewObj(1).Put("length", ((V)(12D))).V, Fn((V _arrowThis332, int _argc324, V __330, V i_331, V _a328, V _a329, V[] _rest325) => {
return NewObj(5).Put("t0", ((V)((2D + (ToNum(i_331) * 2.6))))).Put("y", ((V)((30D + (ToNum(Call(r_321, V.Undef)) * 120D))))).Put("s", ((V)((18D + (ToNum(Call(r_321, V.Undef)) * 22D))))).Put("v", ((V)((90D + (ToNum(Call(r_321, V.Undef)) * 60D))))).Put("hit", ((V)((GeN(i_331, 4D) ? ((2D + (ToNum(i_331) * 2.6)) + (((330D - 160D) / (90D + (ToNum(Call(r_321, V.Undef)) * 0D))) * 0D)) : (-1D))))).V;
}, 2, "", true));
Invoke(AS_322, "forEach", Fn((V _arrowThis341, int _argc333, V a_339, V i_340, V _a337, V _a338, V[] _rest334) => {
Set(a_339, "n", Call(D_10, V.Undef, L_317, ((V)(JsStrBuf.Begin().S("left:0;top:0;width:").V(Get(a_339, "s")).S("px;height:").V(Get(a_339, "s")).S("px;border-radius:46% 54% 50% 50%/52% 46% 54% 48%;background:radial-gradient(circle at 35% 30%,#b0a8b8,#6a6070 60%,#4a4252);box-shadow:inset -3px -3px 0 rgba(0,0,0,0.25);display:none;z-index:8;").End()))));
Set(a_339, "hx", ((V)((210D + ((ToNum(i_340) % 3D) * 30D)))));
Set(a_339, "th", Add(Get(a_339, "t0"), ((V)(((340D - ToNum(Get(a_339, "hx"))) / ToNum(Get(a_339, "v")))))));
Set(a_339, "b", (GeN(i_340, 4D) ? Call(burst_40, V.Undef, L_317, ((V)(16D)), Get(a_339, "hx"), Get(a_339, "y"), Get(a_339, "th"), ((V)((ToNum(Get(a_339, "s")) / 30D)))) : V.Null));
return default;
}, 2, "", true));
Call(paint_41, V.Undef, L_317);
zz_323 = Call(parts_23, V.Undef, L_317, ((V)(6D)), ((V)("width:26px;height:2px;border-radius:1px;background:#a6f06a;box-shadow:0 0 4px #a6f06a;z-index:9;")), V.Null, Fn((V _arrowThis350, int _argc342, V i_348, V t_349, V _a346, V _a347, V[] _rest343) => {
V a_351 = default;
double d_352 = 0;
double u_353 = 0;
double sy_354 = 0;
a_351 = GetIdx(AS_322, (4D + (ToNum(i_348) * 1D)));
if (!(Truthy(a_351))) {
return V.Null;
}
d_352 = (ToNum(Get(a_351, "th")) - ToNum(t_349));
if (((d_352 < 0D) || (d_352 > 0.35))) {
return V.Null;
}
u_353 = (1D - (d_352 / 0.35));
sy_354 = (90D + (FdLibm.Sin((ToNum(Get(a_351, "th")) * 1.3)) * 26D));
return NewObj(4).Put("x", Call(lerp_29, V.Undef, ((V)(200D)), Get(a_351, "hx"), ((V)(u_353)))).Put("y", Call(lerp_29, V.Undef, ((V)(sy_354)), Get(a_351, "y"), ((V)(u_353)))).Put("r", ((V)((FdLibm.Atan2((ToNum(Get(a_351, "y")) - sy_354), (ToNum(Get(a_351, "hx")) - 200D)) * 57D)))).Put("o", ((V)(1D))).V;
return default;
}, 2, "", true));
return Fn((V _arrowThis362, int _argc355, V t_361, V _a358, V _a359, V _a360, V[] _rest356) => {
double sy_363 = 0;
Invoke(sp0_318, "upd", t_361, ((V)(120D)));
sy_363 = ((90D + (FdLibm.Sin((ToNum(t_361) * 1.3)) * 26D)) + ((GtN(t_361, 4.6) && LtN(t_361, 5.6)) ? ((-FdLibm.Sin(((ToNum(t_361) - 4.6) * System.Math.PI))) * 24D) : 0D));
Call(ship_36, V.Undef, sh_319, ((V)(150D)), ((V)(sy_363)), ((V)(0.9)), ((V)((FdLibm.Cos((ToNum(t_361) * 1.3)) * 8D))), ((V)(1D)), t_361);
Invoke(AS_322, "forEach", Fn((V _arrowThis371, int _argc364, V a_370, V _a367, V _a368, V _a369, V[] _rest365) => {
double d_372 = 0;
double x_373 = 0;
d_372 = (ToNum(t_361) - ToNum(Get(a_370, "t0")));
x_373 = (340D - (d_372 * ToNum(Get(a_370, "v"))));
if (Truthy(((((d_372 < 0D) ? V.True : V.False) is var _t375 && Truthy(_t375) ? _t375 : (Get(a_370, "b") is var _t374 && !Truthy(_t374) ? _t374 : (Ge(t_361, Get(a_370, "th")) ? V.True : V.False))) is var _t376 && Truthy(_t376) ? _t376 : ((x_373 < (-40D)) ? V.True : V.False)))) {
Call(show_16, V.Undef, Get(a_370, "n"), (false ? V.True : V.False));
} else {
Call(put_15, V.Undef, Get(a_370, "n"), ((V)(x_373)), Get(a_370, "y"), ((V)(1D)), ((V)((d_372 * 60D))), ((V)(1D)));
}
if (Truthy(Get(a_370, "b"))) {
Invoke(a_370, "b", t_361);
}
return default;
}, 1, "", true));
Call(zz_323, V.Undef, t_361);
Call(lines_22, V.Undef, sp_320, t_361, Arr(Arr(((V)(10D)), ((V)(13.6)), ((V)("Zap \u2019em into sprinkles!")), ((V)("z"))), Arr(((V)(30D)), ((V)(33.6)), ((V)("Yeah! We made it!")), ((V)("p")))), NewObj(2).Put("z", Arr(((V)(150D)), ((V)((sy_363 - 34D))))).Put("p", Arr(((V)(150D)), ((V)((sy_363 - 34D))))).V);
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
Invoke(S_150, "push", NewObj(4).Put("a", ((V)(105D))).Put("b", ((V)(130D))).Put("rgb", ((V)("255,120,120"))).Put("mk", Fn((V _self377, int _argc378, V L_384, V _a381, V _a382, V _a383, V[] _rest379) => {
V B_385 = default;
V eng_386 = default;
V gau_387 = default;
V smoke_388 = default;
V stm_389 = default;
V nb_390 = default;
V z_391 = default;
V pp_392 = default;
V sp_393 = default;
V drz_394 = default;
if (_self377.IsNullish) _self377 = GlobalV;
B_385 = Call(bridge_39, V.Undef, L_384, NewObj(1).Put("seed", ((V)(21D))).V);
Set(Get(Get(B_385, "wn"), "style"), "display", ((V)("none")));
Call(D_10, V.Undef, L_384, ((V)("left:0;top:0;width:320px;height:100px;background:repeating-linear-gradient(90deg,#3a4070 0 30px,#343a66 30px 32px);")));
eng_386 = Call(D_10, V.Undef, L_384, ((V)("left:186px;top:50px;width:90px;height:106px;border-radius:20px 20px 6px 6px;background:linear-gradient(90deg,#8a94c8,#c8d0f0 40%,#6a74a8);border:3px solid #3a4070;box-sizing:border-box;")));
gau_387 = Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _arrowThis402, int _argc395, V i_401, V _a398, V _a399, V _a400, V[] _rest396) => {
return Call(D_10, V.Undef, eng_386, ((V)(JsStrBuf.Begin().S("left:").N((12D + (ToNum(i_401) * 24D))).S("px;top:18px;width:16px;height:16px;border-radius:50%;border:2px solid #3a4070;box-sizing:border-box;").End())));
}, 1, "", true));
smoke_388 = Call(parts_23, V.Undef, L_384, ((V)(10D)), ((V)("width:18px;height:18px;border-radius:50%;background:#5a5a6a;z-index:6;")), V.Null, Fn((V _arrowThis411, int _argc403, V i_409, V t_410, V _a407, V _a408, V[] _rest404) => {
double a_412 = 0;
if (GtN(t_410, 15D)) {
return V.Null;
}
a_412 = (((ToNum(t_410) * 0.6) + (ToNum(i_409) / 10D)) % 1D);
return NewObj(4).Put("x", ((V)((231D + (FdLibm.Sin(ToNum(Add(((V)((a_412 * 6D))), i_409))) * 10D))))).Put("y", ((V)((48D - (a_412 * 50D))))).Put("k", ((V)((0.6 + a_412)))).Put("o", ((V)((0.7 * FdLibm.Sin((System.Math.PI * a_412)))))).V;
return default;
}, 2, "", true));
stm_389 = Call(parts_23, V.Undef, L_384, ((V)(12D)), ((V)("width:16px;height:16px;border-radius:50%;background:#ffffff;z-index:7;")), V.Null, Fn((V _arrowThis421, int _argc413, V i_419, V t_420, V _a417, V _a418, V[] _rest414) => {
double d_422 = 0;
double a_423 = 0;
d_422 = ((ToNum(t_420) - 10D) - ((ToNum(i_419) % 6D) * 0.15));
if (((d_422 < 0D) || (d_422 > 6D))) {
return V.Null;
}
a_423 = ((d_422 * 0.5) % 1D);
return NewObj(4).Put("x", ((V)((231D + (FdLibm.Sin(ToNum(Add(((V)((a_423 * 5D))), i_419))) * 18D))))).Put("y", ((V)((60D - (a_423 * 60D))))).Put("k", ((V)((0.5 + (a_423 * 1.4))))).Put("o", ((V)((0.75 * (1D - a_423))))).V;
return default;
}, 2, "", true));
nb_390 = Call(actor_17, V.Undef, Get(B_385, "act"), ((V)("nimbo")), ((V)((W_31 + 4D))));
z_391 = Call(actor_17, V.Undef, Get(B_385, "act"), ((V)("zappi")), ((V)(W_31)));
pp_392 = Call(actor_17, V.Undef, Get(B_385, "act"), ((V)("pip")), ((V)((W_31 - 6D))));
sp_393 = Call(bub_21, V.Undef, L_384);
drz_394 = Call(parts_23, V.Undef, Get(B_385, "act"), ((V)(14D)), ((V)("width:1.5px;height:7px;border-radius:1px;background:#8fd4ff;z-index:9;")), V.Null, Fn((V _arrowThis432, int _argc424, V i_430, V t_431, V _a428, V _a429, V[] _rest425) => {
return ((GtN(t_431, 9.6) && LtN(t_431, 15.4)) ? NewObj(3).Put("x", ((V)((214D + ((ToNum(i_430) * 9D) % 38D))))).Put("y", ((V)((66D + (((ToNum(t_431) * 120D) + (ToNum(i_430) * 11D)) % 34D))))).Put("o", ((V)(0.9))).V : V.Null);
}, 2, "", true));
return Fn((V _arrowThis440, int _argc433, V t_439, V _a436, V _a437, V _a438, V[] _rest434) => {
V fix_441 = default;
fix_441 = Call(P_11, V.Undef, t_439, ((V)(14.4)), ((V)(15.2)));
Invoke(B_385, "upd", t_439, NewObj(1).Put("alarm", ((V)((1D - ToNum(fix_441))))).V);
Call(smoke_388, V.Undef, t_439);
Call(stm_389, V.Undef, t_439);
Call(drz_394, V.Undef, t_439);
Invoke(gau_387, "forEach", Fn((V _arrowThis450, int _argc442, V g_448, V i_449, V _a446, V _a447, V[] _rest443) => {
Set(Get(g_448, "style"), "background", ((V)((GtN(fix_441, 0.5) ? "#6fe39a" : ((FdLibm.Sin(ToNum(Add(((V)((ToNum(t_439) * 9D))), i_449))) > 0D) ? "#ff4a5a" : "#8a2a3a")))));
return default;
}, 2, "", true));
Set(Get(eng_386, "style"), "transform", ((V)((LtN(fix_441, 1D) ? JsStrBuf.Begin().S("translateX(").V(Invoke(((V)((FdLibm.Sin((ToNum(t_439) * 40D)) * 1.2))), "toFixed", ((V)(1D)))).S("px)").End() : ""))));
Call(pose_18, V.Undef, nb_390, Call(go_19, V.Undef, t_439, Arr(Arr(((V)(0D)), ((V)(60D)), ((V)(130D)), NewObj(1).Put("m", ((V)("float"))).V), Arr(((V)(7D)), ((V)(60D)), ((V)(130D))), Arr(((V)(9.4)), ((V)(231D)), ((V)(74D))), Arr(((V)(15.6)), ((V)(231D)), ((V)(74D))), Arr(((V)(17.6)), ((V)(130D)), ((V)(110D)))), NewObj(2).Put("m", ((V)("float"))).Put("gy", ((V)(158D))).V));
Call(pose_18, V.Undef, z_391, NewObj(4).Put("x", ((V)(92D))).Put("y", ((V)(158D))).Put("v", ((V)("front"))).Put("r", ((V)((LtN(fix_441, 1D) ? (FdLibm.Sin((ToNum(t_439) * 7D)) * 3D) : 0D)))).V);
Call(pose_18, V.Undef, pp_392, NewObj(3).Put("x", ((V)(128D))).Put("y", ((V)((158D - ((GtN(t_439, 15.6) && LtN(t_439, 16.2)) ? (FdLibm.Sin((((ToNum(t_439) - 15.6) * System.Math.PI) / 0.6)) * 12D) : 0D))))).Put("v", ((V)("front"))).V);
Call(lines_22, V.Undef, sp_393, t_439, Arr(Arr(((V)(1.4)), ((V)(4.8)), ((V)("The engine\u2019s overheating!")), ((V)("z"))), Arr(((V)(5.4)), ((V)(8.4)), ((V)("Leave it to me!")), ((V)("n"))), Arr(((V)(15.8)), ((V)(19D)), ((V)("Ha! Steamy!")), ((V)("p"))), Arr(((V)(19.6)), ((V)(23D)), ((V)("Engine back online!")), ((V)("z")))), NewObj(3).Put("z", Arr(((V)(92D)), ((V)(104D)))).Put("n", Arr(((V)(60D)), ((V)(76D)))).Put("p", Arr(((V)(128D)), ((V)(106D)))).V);
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
Invoke(S_150, "push", NewObj(4).Put("a", ((V)(130D))).Put("b", ((V)(160D))).Put("rgb", ((V)("200,170,255"))).Put("mk", Fn((V _self451, int _argc452, V L_458, V _a455, V _a456, V _a457, V[] _rest453) => {
V B_459 = default;
V sp_460 = default;
V ks_461 = default;
V ns_462 = default;
V r_463 = default;
V blobs_464 = default;
V zz_465 = default;
if (_self451.IsNullish) _self451 = GlobalV;
B_459 = Call(bridge_39, V.Undef, L_458, NewObj(1).Put("seed", ((V)(25D))).V);
sp_460 = Call(bub_21, V.Undef, L_458);
ks_461 = Arr(((V)("zappi")), ((V)("twinkle")), ((V)("nimbo")), ((V)("pip")));
ns_462 = Invoke(ks_461, "map", Fn((V _arrowThis473, int _argc466, V k_472, V _a469, V _a470, V _a471, V[] _rest467) => {
return Call(actor_17, V.Undef, Get(B_459, "act"), k_472, ((V)((W_31 - 4D))));
}, 1, "", true));
r_463 = Call(rnd_27, V.Undef, ((V)(5D)));
blobs_464 = Array_from(NewObj(1).Put("length", ((V)(6D))).V, Fn((V _arrowThis482, int _argc474, V __480, V i_481, V _a478, V _a479, V[] _rest475) => {
return Call(D_10, V.Undef, Get(B_459, "act"), ((V)(JsStrBuf.Begin().S("left:0;top:0;width:").N((12D + ((ToNum(i_481) % 3D) * 4D))).S("px;height:").N((10D + ((ToNum(i_481) % 3D) * 3D))).S("px;border-radius:50%;background:").V(GetIdx(Arr(((V)("#ffc6d8")), ((V)("#ffe08a")), ((V)("#c9f0b0"))), (ToNum(i_481) % 3D))).S(";border:1.5px solid rgba(90,40,80,0.4);box-sizing:border-box;z-index:8;display:none;").End())));
}, 2, "", true));
zz_465 = Call(parts_23, V.Undef, Get(B_459, "act"), ((V)(3D)), ((V)("font-weight:700;font-size:10px;color:#c9d4ff;z-index:9;")), ((V)("z")), Fn((V _arrowThis491, int _argc483, V i_489, V t_490, V _a487, V _a488, V[] _rest484) => {
double a_492 = 0;
if (LtN(t_490, 15D)) {
return V.Null;
}
a_492 = (((ToNum(t_490) * 0.45) + (ToNum(i_489) / 3D)) % 1D);
return NewObj(4).Put("x", ((V)((92D + (a_492 * 14D))))).Put("y", ((V)((42D - (a_492 * 26D))))).Put("k", ((V)((0.7 + (a_492 * 0.8))))).Put("o", ((V)(FdLibm.Sin((System.Math.PI * a_492))))).V;
return default;
}, 2, "", true));
return Fn((V _arrowThis500, int _argc493, V t_499, V _a496, V _a497, V _a498, V[] _rest494) => {
Invoke(B_459, "upd", t_499, NewObj(1).Put("sp", ((V)(25D))).V);
Invoke(ns_462, "forEach", Fn((V _arrowThis509, int _argc501, V n_507, V i_508, V _a505, V _a506, V[] _rest502) => {
V s_510 = default;
s_510 = NewObj(5).Put("x", Add(GetK(Arr(((V)(90D)), ((V)(120D)), ((V)(220D)), ((V)(250D))), i_508), ((V)((FdLibm.Sin(((ToNum(t_499) * 0.5) + (ToNum(i_508) * 2D))) * 16D))))).Put("y", ((V)((96D + (FdLibm.Sin(ToNum(Add(((V)((ToNum(t_499) * 0.7))), i_508))) * 18D))))).Put("v", ((V)((SEqN(i_508, 3D) ? (LtN(t_499, 10D) ? "right" : "front") : "front")))).Put("r", ((V)(((((ToNum(t_499) * 14D) * (NumTruthy((ToNum(i_508) % 2D)) ? 1D : (-1D))) + (ToNum(i_508) * 40D)) % 360D)))).Put("sh", (false ? V.True : V.False)).V;
if (SEqN(i_508, 3D)) {
Set(s_510, "x", Call(kf_13, V.Undef, t_499, Arr(Arr(((V)(0D)), ((V)(250D))), Arr(((V)(4D)), ((V)(180D))), Arr(((V)(10D)), ((V)(150D))), Arr(((V)(11D)), ((V)(150D))), Arr(((V)(20D)), ((V)(230D))))));
Set(s_510, "y", Call(kf_13, V.Undef, t_499, Arr(Arr(((V)(0D)), ((V)(96D))), Arr(((V)(4D)), ((V)(80D))), Arr(((V)(10D)), ((V)(74D))), Arr(((V)(20D)), ((V)(100D))))));
Set(s_510, "r", ((V)(((GtN(t_499, 10D) && LtN(t_499, 12D)) ? 0D : ((ToNum(t_499) * 30D) % 360D)))));
}
if ((SEqN(i_508, 1D) && GtN(t_499, 15D))) {
Set(s_510, "r", ((V)((20D + (FdLibm.Sin(ToNum(t_499)) * 6D)))));
Set(s_510, "x", ((V)(92D)));
Set(s_510, "y", ((V)(82D)));
}
Call(pose_18, V.Undef, n_507, s_510);
return default;
}, 2, "", true));
Invoke(blobs_464, "forEach", Fn((V _arrowThis519, int _argc511, V b_517, V i_518, V _a515, V _a516, V[] _rest512) => {
V x_520 = default;
V y_521 = default;
if ((SEqN(i_518, 0D) && GtN(t_499, 10D))) {
if (LtN(t_499, 11.2)) {
Call(put_15, V.Undef, b_517, ((V)(150D)), ((V)(60D)), ((V)((1D - ToNum(Call(P_11, V.Undef, t_499, ((V)(10.4)), ((V)(11D))))))), ((V)(0D)), ((V)(1D)));
} else {
Call(show_16, V.Undef, b_517, (false ? V.True : V.False));
}
return default;
}
x_520 = (SEqN(i_518, 0D) ? Call(kf_13, V.Undef, t_499, Arr(Arr(((V)(0D)), ((V)(210D))), Arr(((V)(4D)), ((V)(170D))), Arr(((V)(10D)), ((V)(150D))))) : ((V)((40D + ((((ToNum(i_518) * 53D) + ((ToNum(t_499) * 9D) * (NumTruthy((ToNum(i_518) % 2D)) ? 1D : (-1D)))) + 600D) % 240D)))));
y_521 = (SEqN(i_518, 0D) ? Call(kf_13, V.Undef, t_499, Arr(Arr(((V)(0D)), ((V)(62D))), Arr(((V)(10D)), ((V)(60D))))) : ((V)((40D + (((ToNum(i_518) * 29D) + (FdLibm.Sin(ToNum(Add(((V)((ToNum(t_499) * 0.6))), i_518))) * 20D)) % 80D)))));
Call(put_15, V.Undef, b_517, x_520, y_521, ((V)((1D + (0.12 * FdLibm.Sin(ToNum(Add(((V)((ToNum(t_499) * 6D))), i_518))))))), ((V)((FdLibm.Sin(ToNum(Add(((V)((ToNum(t_499) * 2D))), i_518))) * 30D))), ((V)(1D)));
return default;
}, 2, "", true));
Call(zz_465, V.Undef, t_499);
Call(lines_22, V.Undef, sp_460, t_499, Arr(Arr(((V)(1D)), ((V)(4D)), ((V)("Zero-g snack time!")), ((V)("t"))), Arr(((V)(5D)), ((V)(8.4)), ((V)("Come back, pudding!")), ((V)("p"))), Arr(((V)(10.4)), ((V)(12.4)), ((V)("Nom!")), ((V)("p"))), Arr(((V)(20D)), ((V)(24D)), ((V)("Twinkle fell asleep upside down!")), ((V)("z")))), NewObj(3).Put("t", Arr(((V)(120D)), ((V)(62D)))).Put("p", Arr(((V)(150D)), ((V)(44D)))).Put("z", Arr(((V)(90D)), ((V)(58D)))).V);
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
Invoke(S_150, "push", NewObj(5).Put("a", ((V)(160D))).Put("b", ((V)(180D))).Put("rgb", ((V)("120,255,150"))).Put("lit", Fn((V _arrowThis529, int _argc522, V t_528, V _a525, V _a526, V _a527, V[] _rest523) => {
return ((V)((LtN(t_528, 8D) ? 0.6 : 0.12)));
}, 1, "lit", true)).Put("mk", Fn((V _self530, int _argc531, V L_537, V _a534, V _a535, V _a536, V[] _rest532) => {
V sp0_538 = default;
V sh_539 = default;
V sp_540 = default;
V dark_541 = default;
V ufo_542 = default;
V lights_543 = default;
V beam_544 = default;
V oc_545 = default;
if (_self530.IsNullish) _self530 = GlobalV;
sp0_538 = Call(space_37, V.Undef, L_537, ((V)(29D)));
sh_539 = Call(shipN_35, V.Undef, L_537);
sp_540 = Call(bub_21, V.Undef, L_537);
dark_541 = Call(D_10, V.Undef, L_537, ((V)("inset:0;background:#05040e;display:none;z-index:30;")));
ufo_542 = Call(D_10, V.Undef, L_537, ((V)("left:0;top:0;width:220px;height:70px;z-index:12;")), ((V)("<svg viewBox=\"0 0 220 70\" width=\"220\" height=\"70\"><ellipse cx=\"110\" cy=\"24\" rx=\"44\" ry=\"22\" fill=\"rgba(160,255,200,0.5)\" stroke=\"#3a7a5a\" stroke-width=\"2\"></ellipse><ellipse cx=\"110\" cy=\"40\" rx=\"108\" ry=\"24\" fill=\"#6a5aa6\" stroke=\"#2a1a50\" stroke-width=\"2.5\"></ellipse><ellipse cx=\"110\" cy=\"36\" rx=\"96\" ry=\"10\" fill=\"#8a7ac8\"></ellipse></svg>")));
lights_543 = Array_from(NewObj(1).Put("length", ((V)(7D))).V, Fn((V _arrowThis554, int _argc546, V __552, V i_553, V _a550, V _a551, V[] _rest547) => {
return Call(D_10, V.Undef, ufo_542, ((V)(JsStrBuf.Begin().S("left:").N((26D + (ToNum(i_553) * 28D))).S("px;top:44px;width:8px;height:8px;border-radius:50%;").End())));
}, 2, "", true));
beam_544 = Call(D_10, V.Undef, L_537, ((V)("left:110px;top:56px;width:100px;height:130px;z-index:9;background:linear-gradient(rgba(140,255,160,0.55),rgba(140,255,160,0.15));clip-path:polygon(38% 0,62% 0,100% 100%,0 100%);display:none;")));
oc_545 = Call(actor_17, V.Undef, dark_541, ((V)("octo")), ((V)(170D)));
return Fn((V _arrowThis562, int _argc555, V t_561, V _a558, V _a559, V _a560, V[] _rest556) => {
V u_563 = default;
V pull_564 = default;
Invoke(sp0_538, "upd", t_561, ((V)(40D)));
u_563 = Call(P_11, V.Undef, t_561, ((V)(2D)), ((V)(4D)));
Call(put_15, V.Undef, ufo_542, ((V)(160D)), ((V)(((-40D) + (ToNum(u_563) * 76D)))), ((V)(1D)), ((V)(0D)), ((V)(1D)));
Invoke(lights_543, "forEach", Fn((V _arrowThis573, int _argc565, V l_571, V i_572, V _a569, V _a570, V[] _rest566) => {
Set(Get(l_571, "style"), "background", ((V)(((FdLibm.Sin(ToNum(Add(((V)((ToNum(t_561) * 6D))), i_572))) > 0D) ? "#ffd66b" : "#a6f06a"))));
return default;
}, 2, "", true));
Call(show_16, V.Undef, beam_544, (GtN(t_561, 4D) ? V.True : V.False));
Set(Get(beam_544, "style"), "opacity", Invoke(((V)((0.7 + (0.3 * FdLibm.Sin((ToNum(t_561) * 9D)))))), "toFixed", ((V)(2D))));
pull_564 = Call(P_11, V.Undef, t_561, ((V)(5D)), ((V)(8D)), Get(E_12, "in"));
Call(ship_36, V.Undef, sh_539, Call(lerp_29, V.Undef, ((V)(110D)), ((V)(160D)), Call(P_11, V.Undef, t_561, ((V)(0D)), ((V)(4D)))), Call(lerp_29, V.Undef, ((V)(120D)), ((V)(50D)), pull_564), ((V)((0.8 - (ToNum(pull_564) * 0.5)))), ((V)((GtN(t_561, 5D) ? (ToNum(t_561) * 160D) : 0D))), ((V)((LtN(t_561, 5D) ? 1D : 0.3))), t_561);
Call(show_16, V.Undef, dark_541, (GtN(t_561, 8D) ? V.True : V.False));
if (GtN(t_561, 8D)) {
Call(pose_18, V.Undef, oc_545, NewObj(7).Put("x", ((V)(160D))).Put("y", ((V)(196D))).Put("v", ((V)("front"))).Put("f", ((V)("brightness(0.12) saturate(0)"))).Put("o", Call(P_11, V.Undef, t_561, ((V)(8.2)), ((V)(9.4)))).Put("k", ((V)((1D + (0.04 * FdLibm.Sin((ToNum(t_561) * 1.4))))))).Put("sh", (false ? V.True : V.False)).V);
}
Call(lines_22, V.Undef, sp_540, t_561, Arr(Arr(((V)(1.6)), ((V)(5D)), ((V)("We\u2019re caught in a tractor beam!")), ((V)("z"))), Arr(((V)(12D)), ((V)(15.6)), ((V)("W-who\u2019s there?")), ((V)("p")))), NewObj(2).Put("z", Arr(((V)(150D)), ((V)(96D)))).Put("p", Arr(((V)(160D)), ((V)(150D)))).V);
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
Invoke(S_150, "push", NewObj(5).Put("a", ((V)(180D))).Put("b", ((V)(200D))).Put("rgb", ((V)("200,140,255"))).Put("inF", (false ? V.True : V.False)).Put("mk", Fn((V _self574, int _argc575, V L_581, V _a578, V _a579, V _a580, V[] _rest576) => {
V oc_582 = default;
V ks_583 = default;
V sp_584 = default;
V map_585 = default;
if (_self574.IsNullish) _self574 = GlobalV;
Call(D_10, V.Undef, L_581, ((V)("inset:0;background:radial-gradient(ellipse at 50% 30%,#8a6ad8,#3a2a70 70%);")));
Call(D_10, V.Undef, L_581, ((V)("left:0;top:140px;width:320px;height:40px;background:#2a1e56;")));
oc_582 = Call(actor_17, V.Undef, L_581, ((V)("octo")), ((V)(74D)));
ks_583 = Invoke(Arr(((V)("zappi")), ((V)("twinkle")), ((V)("nimbo")), ((V)("pip"))), "map", Fn((V _arrowThis593, int _argc586, V k_592, V _a589, V _a590, V _a591, V[] _rest587) => {
return Call(actor_17, V.Undef, L_581, k_592, ((V)((W_31 - 6D))));
}, 1, "", true));
sp_584 = Call(bub_21, V.Undef, L_581);
map_585 = Call(D_10, V.Undef, L_581, ((V)("left:118px;top:14px;width:84px;height:58px;border-radius:10px;z-index:9;display:none;background:radial-gradient(circle at 30% 50%,#ff8fd0,rgba(0,0,0,0) 40%),radial-gradient(circle at 70% 40%,#8fe8ff,rgba(0,0,0,0) 44%),rgba(40,20,80,0.6);border:2px solid #c9a6ff;")), ((V)("<svg viewBox=\"0 0 84 58\" width=\"84\" height=\"58\"><path d=\"M8 46 Q30 10 50 30 T78 12\" stroke=\"#ffd66b\" stroke-width=\"2\" stroke-dasharray=\"3 3\" fill=\"none\"></path><circle cx=\"78\" cy=\"12\" r=\"5\" fill=\"#ff6fa8\"></circle></svg>")));
return Fn((V _arrowThis601, int _argc594, V t_600, V _a597, V _a598, V _a599, V[] _rest595) => {
double m_602 = 0;
Call(pose_18, V.Undef, oc_582, Call(dance_20, V.Undef, t_600, ((V)(190D)), ((V)(146D)), ((V)("wave")), ((V)(0.8))));
_ = Get(Arr(((V)("x"))), "length");
Invoke(ks_583, "forEach", Fn((V _arrowThis611, int _argc603, V n_609, V i_610, V _a607, V _a608, V[] _rest604) => {
return Call(pose_18, V.Undef, n_609, NewObj(4).Put("x", ((V)((50D + (ToNum(i_610) * 30D))))).Put("y", ((V)(146D))).Put("v", ((V)("right"))).Put("sy", ((V)((1D + (0.01 * FdLibm.Sin(ToNum(Add(((V)((ToNum(t_600) * 3D))), i_610)))))))).V);
}, 2, "", true));
m_602 = (ToNum(Call(P_11, V.Undef, t_600, ((V)(11D)), ((V)(11.8)), Get(E_12, "back"))) * (1D - ToNum(Call(P_11, V.Undef, t_600, ((V)(17.4)), ((V)(18D))))));
if ((m_602 > 0.01)) {
Call(put_15, V.Undef, map_585, ((V)(160D)), ((V)(43D)), ((V)(m_602)), ((V)(0D)), ((V)(1D)));
} else {
Call(show_16, V.Undef, map_585, (false ? V.True : V.False));
}
Call(lines_22, V.Undef, sp_584, t_600, Arr(Arr(((V)(1D)), ((V)(5D)), ((V)("Hi! I\u2019m Octo... I was so lonely out here.")), ((V)("o"))), Arr(((V)(5.6)), ((V)(9D)), ((V)("Want to come with us?")), ((V)("z"))), Arr(((V)(9.4)), ((V)(13D)), ((V)("Yes! I know a shortcut!")), ((V)("o"))), Arr(((V)(13.4)), ((V)(17.6)), ((V)("Through the nebula!")), ((V)("o")))), NewObj(2).Put("o", Arr(((V)(190D)), ((V)(82D)))).Put("z", Arr(((V)(50D)), ((V)(100D)))).V);
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
Invoke(S_150, "push", NewObj(4).Put("a", ((V)(200D))).Put("b", ((V)(220D))).Put("rgb", ((V)("255,140,220"))).Put("mk", Fn((V _self612, int _argc613, V L_619, V _a616, V _a617, V _a618, V[] _rest614) => {
V sp0_620 = default;
V au_621 = default;
V sh_622 = default;
V sp_623 = default;
if (_self612.IsNullish) _self612 = GlobalV;
sp0_620 = Call(space_37, V.Undef, L_619, ((V)(33D)), NewObj(1).Put("bg", ((V)("radial-gradient(ellipse at 30% 40%,#ff6fb0 0,rgba(0,0,0,0) 40%),radial-gradient(ellipse at 70% 60%,#6a8aff 0,rgba(0,0,0,0) 45%),radial-gradient(ellipse at 50% 20%,#a06aff 0,rgba(0,0,0,0) 40%),#140a30"))).V);
au_621 = Call(actor_17, V.Undef, L_619, ((V)("aurora")), ((V)(150D)));
sh_622 = Call(shipN_35, V.Undef, L_619, ((V)(12D)));
sp_623 = Call(bub_21, V.Undef, L_619);
return Fn((V _arrowThis631, int _argc624, V t_630, V _a627, V _a628, V _a629, V[] _rest625) => {
V x_632 = default;
double y_633 = 0;
Invoke(sp0_620, "upd", t_630, ((V)(30D)));
x_632 = Call(kf_13, V.Undef, t_630, Arr(Arr(((V)(0D)), ((V)((-100D)))), Arr(((V)(10D)), ((V)(150D))), Arr(((V)(20D)), ((V)(420D)))), Get(E_12, "lin"));
y_633 = (166D + (FdLibm.Sin((ToNum(t_630) * 0.9)) * 8D));
Call(pose_18, V.Undef, au_621, NewObj(6).Put("x", x_632).Put("y", ((V)(y_633))).Put("v", ((V)("right"))).Put("r", ((V)((FdLibm.Sin((ToNum(t_630) * 0.9)) * 4D)))).Put("sh", (false ? V.True : V.False)).Put("f", ((V)(JsStrBuf.Begin().S("hue-rotate(").V(Invoke(((V)((FdLibm.Sin((ToNum(t_630) * 0.5)) * 30D))), "toFixed", ((V)(0D)))).S("deg)").End()))).V);
Call(ship_36, V.Undef, sh_622, ((V)((ToNum(x_632) - 6D))), ((V)((y_633 - 112D))), ((V)(0.6)), ((V)((FdLibm.Sin((ToNum(t_630) * 0.9)) * 4D))), ((V)(0.2)), t_630);
Call(lines_22, V.Undef, sp_623, t_630, Arr(Arr(((V)(3D)), ((V)(6.6)), ((V)("A space whale!")), ((V)("p"))), Arr(((V)(7D)), ((V)(11D)), ((V)("Hold on, she\u2019ll give us a ride!")), ((V)("o")))), NewObj(2).Put("p", Arr(((V)((ToNum(x_632) - 6D))), ((V)((y_633 - 128D))))).Put("o", Arr(((V)((ToNum(x_632) - 6D))), ((V)((y_633 - 128D))))).V);
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
Invoke(S_150, "push", NewObj(5).Put("a", ((V)(220D))).Put("b", ((V)(235D))).Put("rgb", ((V)("255,170,220"))).Put("lit", Fn((V _arrowThis641, int _argc634, V t_640, V _a637, V _a638, V _a639, V[] _rest635) => {
return ((V)((0.6 + (ToNum(Call(P_11, V.Undef, t_640, ((V)(4D)), ((V)(6D)))) * 0.6))));
}, 1, "lit", true)).Put("mk", Fn((V _self642, int _argc643, V L_649, V _a646, V _a647, V _a648, V[] _rest644) => {
V sp0_650 = default;
V pl_651 = default;
V rr_652 = default;
V dots_653 = default;
V sh_654 = default;
V ray_655 = default;
V sp_656 = default;
V fw_657 = default;
if (_self642.IsNullish) _self642 = GlobalV;
sp0_650 = Call(space_37, V.Undef, L_649, ((V)(37D)));
pl_651 = Call(D_10, V.Undef, L_649, ((V)("left:110px;top:40px;width:120px;height:120px;border-radius:50%;")));
rr_652 = Call(rnd_27, V.Undef, ((V)(77D)));
dots_653 = Array_from(NewObj(1).Put("length", ((V)(26D))).V, Fn((V _arrowThis666, int _argc658, V __664, V i_665, V _a662, V _a663, V[] _rest659) => {
return Call(D_10, V.Undef, pl_651, ((V)(JsStrBuf.Begin().S("left:").V(Invoke(((V)((18D + (ToNum(Call(rr_652, V.Undef)) * 80D)))), "toFixed", ((V)(0D)))).S("px;top:").V(Invoke(((V)((16D + (ToNum(Call(rr_652, V.Undef)) * 84D)))), "toFixed", ((V)(0D)))).S("px;width:9px;height:3px;border-radius:2px;background:").V(GetIdx(SPR_32, (ToNum(i_665) % 5D))).S(";transform:rotate(").N((ToNum(i_665) * 61D)).S("deg);").End())));
}, 2, "", true));
sh_654 = Call(shipN_35, V.Undef, L_649, ((V)(12D)));
ray_655 = Call(D_10, V.Undef, L_649, ((V)("left:0;top:0;width:100px;height:6px;border-radius:3px;background:linear-gradient(90deg,#fff6c8,#ffd66b);box-shadow:0 0 10px 4px rgba(255,214,107,0.7);display:none;z-index:11;transform-origin:0 50%;")));
sp_656 = Call(bub_21, V.Undef, L_649);
fw_657 = Invoke(Arr(((V)(6D)), ((V)(7.2)), ((V)(8.4)), ((V)(9.6)), ((V)(10.8)), ((V)(12D))), "map", Fn((V _arrowThis675, int _argc667, V t0_673, V i_674, V _a671, V _a672, V[] _rest668) => {
return Call(burst_40, V.Undef, L_649, ((V)(18D)), ((V)((60D + ((ToNum(i_674) * 83D) % 200D)))), ((V)((30D + ((ToNum(i_674) * 37D) % 60D)))), t0_673, ((V)(1.2)));
}, 2, "", true));
Call(paint_41, V.Undef, L_649);
return Fn((V _arrowThis683, int _argc676, V t_682, V _a679, V _a680, V _a681, V[] _rest677) => {
V g_684 = default;
Invoke(sp0_650, "upd", t_682, ((V)(20D)));
g_684 = Call(P_11, V.Undef, t_682, ((V)(4D)), ((V)(6D)));
Set(Get(pl_651, "style"), "background", ((V)(JsStrBuf.Begin().S("radial-gradient(circle at 35% 35%,hsl(330,").V(Call(lerp_29, V.Undef, ((V)(15D)), ((V)(90D)), g_684)).S("%,").V(Call(lerp_29, V.Undef, ((V)(55D)), ((V)(80D)), g_684)).S("%),hsl(320,").V(Call(lerp_29, V.Undef, ((V)(10D)), ((V)(70D)), g_684)).S("%,").V(Call(lerp_29, V.Undef, ((V)(28D)), ((V)(50D)), g_684)).S("%) 75%)").End())));
Set(Get(pl_651, "style"), "boxShadow", ((V)(JsStrBuf.Begin().S("0 0 ").N((10D + (30D * ToNum(g_684)))).S("px ").N((4D + (10D * ToNum(g_684)))).S("px rgba(255,150,210,").V(Invoke(((V)((0.2 + (0.5 * ToNum(g_684))))), "toFixed", ((V)(2D)))).S(")").End())));
Invoke(dots_653, "forEach", Fn((V _arrowThis693, int _argc685, V d_691, V i_692, V _a689, V _a690, V[] _rest686) => {
Set(Get(d_691, "style"), "opacity", Invoke(((V)((0.2 + (0.8 * ToNum(g_684))))), "toFixed", ((V)(2D))));
return default;
}, 2, "", true));
Call(ship_36, V.Undef, sh_654, ((V)(50D)), ((V)(130D)), ((V)(0.6)), ((V)((-20D))), ((V)(1D)), t_682);
if ((GtN(t_682, 3D) && LtN(t_682, 6D))) {
Call(put_15, V.Undef, ray_655, ((V)(64D)), ((V)(122D)), ((V)(1D)), ((V)((-26D))), ((V)(1D)));
Set(Get(ray_655, "style"), "transform", ((V)(JsStrBuf.Begin().S("translate(64px,122px) rotate(-26deg) scaleX(").V(Invoke(((V)((ToNum(Call(P_11, V.Undef, t_682, ((V)(3D)), ((V)(3.6)))) * 1.2))), "toFixed", ((V)(2D)))).S(")").End())));
} else {
Call(show_16, V.Undef, ray_655, (false ? V.True : V.False));
}
Invoke(fw_657, "forEach", Fn((V _arrowThis701, int _argc694, V f_700, V _a697, V _a698, V _a699, V[] _rest695) => {
return Call(f_700, V.Undef, t_682);
}, 1, "", true));
Call(lines_22, V.Undef, sp_656, t_682, Arr(Arr(((V)(0.4)), ((V)(3D)), ((V)("Charge the core!")), ((V)("z"))), Arr(((V)(8D)), ((V)(12D)), ((V)("Planet Sprinkle is saved!")), ((V)("t")))), NewObj(2).Put("z", Arr(((V)(50D)), ((V)(104D)))).Put("t", Arr(((V)(50D)), ((V)(104D)))).V);
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
Invoke(S_150, "push", NewObj(5).Put("a", ((V)(235D))).Put("b", ((V)(240D))).Put("rgb", ((V)("180,170,255"))).Put("outF", (false ? V.True : V.False)).Put("mk", Fn((V _self702, int _argc703, V L_709, V _a706, V _a707, V _a708, V[] _rest704) => {
V sp0_710 = default;
V sh_711 = default;
V oc_712 = default;
V tx_713 = default;
if (_self702.IsNullish) _self702 = GlobalV;
sp0_710 = Call(space_37, V.Undef, L_709, ((V)(41D)));
sh_711 = Call(shipN_35, V.Undef, L_709, ((V)(12D)));
oc_712 = Call(actor_17, V.Undef, L_709, ((V)("octo")), ((V)(50D)));
tx_713 = Call(D_10, V.Undef, L_709, ((V)("left:0;top:22px;width:320px;text-align:center;font-size:20px;font-weight:700;color:#ffd66b;text-shadow:0 2px 0 #3a1a5c;z-index:40;")), ((V)("To be continued...?")));
return Fn((V _arrowThis721, int _argc714, V t_720, V _a717, V _a718, V _a719, V[] _rest715) => {
Invoke(sp0_710, "upd", t_720, ((V)(30D)));
Call(ship_36, V.Undef, sh_711, ((V)((160D - (ToNum(t_720) * 40D)))), ((V)((110D - (ToNum(t_720) * 6D)))), ((V)((0.7 - (ToNum(t_720) * 0.08)))), ((V)(180D)), ((V)(1D)), t_720);
OpSet(Get(sh_711, "style"), "transform", 0, ((V)(" scaleY(-1)")));
Call(pose_18, V.Undef, oc_712, NewObj(5).Put("x", ((V)(250D))).Put("y", ((V)((150D + (FdLibm.Sin((ToNum(t_720) * 2D)) * 3D))))).Put("v", ((V)("front"))).Put("r", ((V)((FdLibm.Sin((ToNum(t_720) * 6D)) * 10D)))).Put("sh", (false ? V.True : V.False)).V);
Set(Get(tx_713, "style"), "opacity", Invoke(Call(P_11, V.Undef, t_720, ((V)(1D)), ((V)(2D))), "toFixed", ((V)(3D))));
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
return Call(film_25, V.Undef, S_150, NewObj(1).Put("rgb", ((V)("150,170,255"))).V);
return default;
}, 0, "mk", false);
score_43 = Fn((V _self722, int _argc723, V Q_729, V _a726, V _a727, V _a728, V[] _rest724) => {
V I_730 = default;
double B_731 = 0;
V PR_732 = default;
V MEL_733 = default;
V synth_734 = default;
V theme_735 = default;
if (_self722.IsNullish) _self722 = GlobalV;
I_730 = Call(snd_26, V.Undef, Q_729);
B_731 = 0.5;
PR_732 = Arr(Arr(((V)(45D)), Arr(((V)(57D)), ((V)(60D)), ((V)(64D)))), Arr(((V)(41D)), Arr(((V)(57D)), ((V)(60D)), ((V)(65D)))), Arr(((V)(43D)), Arr(((V)(55D)), ((V)(59D)), ((V)(62D)))), Arr(((V)(40D)), Arr(((V)(55D)), ((V)(59D)), ((V)(64D)))));
MEL_733 = Arr(((V)(76D)), ((V)(79D)), ((V)(81D)), ((V)(79D)), ((V)(76D)), ((V)(74D)), ((V)(72D)), ((V)(74D)));
synth_734 = Fn((V _arrowThis748, int _argc736, V t0_742, V t1_743, V _a740, V _a741, V[] _rest737) => {
V lv_745 = default;
V tr_747 = default;
{ V _t744 = _a740; if (_t744.IsUndef) _t744 = ((V)(1D));
lv_745 = _t744; }
{ V _t746 = _a741; if (_t746.IsUndef) _t746 = ((V)(0D));
tr_747 = _t746; }
return Invoke(I_730, "beat", t0_742, t1_743, ((V)((B_731 / 2D))), Fn((V _arrowThis757, int _argc749, V t_755, V i_756, V _a753, V _a754, V[] _rest750) => {
double bar_758 = 0;
V p_759 = default;
bar_758 = (System.Math.Floor((ToNum(i_756) / 8D)) % 4D);
p_759 = GetIdx(PR_732, bar_758);
Invoke(I_730, "bass", t_755, Add(Add(((V)((ToNum(GetIdx(p_759, 0D)) - 12D))), tr_747), ((V)((NumTruthy((ToNum(i_756) % 2D)) ? 12D : 0D)))), ((V)(0.2)), ((V)(0.12)));
if ((GtN(lv_745, 0D) && ((ToNum(i_756) % 4D) == 0D))) {
Invoke(I_730, "kick", t_755, ((V)(0.5)));
}
if ((GtN(lv_745, 0D) && ((ToNum(i_756) % 8D) == 4D))) {
Invoke(I_730, "snare", t_755, ((V)(0.16)));
}
if (Truthy(((GtN(lv_745, 1D) ? V.True : V.False) is var _t760 && !Truthy(_t760) ? _t760 : ((V)((ToNum(i_756) % 2D)))))) {
Invoke(I_730, "hat", t_755, ((V)(0.03)));
}
if (((ToNum(i_756) % 8D) == 0D)) {
Invoke(I_730, "pad", t_755, Invoke(GetIdx(p_759, 1D), "map", Fn((V _arrowThis768, int _argc761, V m_767, V _a764, V _a765, V _a766, V[] _rest762) => {
return Add(m_767, tr_747);
}, 1, "", true)), ((V)((B_731 * 4D))), ((V)(0.018)), ((V)("sawtooth")), ((V)(1400D)));
}
if ((GtN(lv_745, 1D) && ((ToNum(i_756) % 2D) == 0D))) {
Invoke(I_730, "pluck", t_755, Add(Add(GetIdx(GetIdx(p_759, 1D), ((ToNum(i_756) / 2D) % 3D)), ((V)(12D))), tr_747), ((V)(0.15)), ((V)(0.035)));
}
return default;
}, 2, "", true));
}, 4, "", true);
theme_735 = Fn((V _arrowThis780, int _argc769, V t0_775, V _a772, V _a773, V _a774, V[] _rest770) => {
V tr_777 = default;
V v_779 = default;
{ V _t776 = _a772; if (_t776.IsUndef) _t776 = ((V)(0D));
tr_777 = _t776; }
{ V _t778 = _a773; if (_t778.IsUndef) _t778 = ((V)(0.05));
v_779 = _t778; }
return Invoke(MEL_733, "forEach", Fn((V _arrowThis789, int _argc781, V m_787, V k_788, V _a785, V _a786, V[] _rest782) => {
return Invoke(I_730, "lead", Add(t0_775, ((V)((ToNum(k_788) * B_731)))), Add(m_787, tr_777), ((V)((B_731 * (((ToNum(k_788) % 4D) == 3D) ? 1.8 : 0.9)))), v_779);
}, 2, "", true));
}, 3, "", true);
Invoke(I_730, "pad", ((V)(0D)), Arr(((V)(57D)), ((V)(60D)), ((V)(64D))), ((V)(5.6)), ((V)(0.02)), ((V)("sawtooth")), ((V)(900D)));
Invoke(Arr(((V)(5.6)), ((V)(6.6)), ((V)(7.6))), "forEach", Fn((V _arrowThis797, int _argc790, V t_796, V _a793, V _a794, V _a795, V[] _rest791) => {
Invoke(I_730, "bell", t_796, ((V)(81D)), ((V)(0.5)), ((V)(0.06)));
Invoke(I_730, "tone", t_796, ((V)(880D)), ((V)(0.15)), NewObj(1).Put("vol", ((V)(0.05))).V);
return default;
}, 1, "", true));
Invoke(I_730, "boom", ((V)(8.6)), ((V)(0.5)));
Invoke(I_730, "rumble", ((V)(8.6)), ((V)(10D)), ((V)(0.14)));
Invoke(I_730, "crash", ((V)(9D)), ((V)(0.12)));
Call(synth_734, V.Undef, ((V)(10D)), ((V)(25D)), ((V)(2D)));
Call(theme_735, V.Undef, ((V)(14D)));
Call(theme_735, V.Undef, ((V)(18D)), ((V)(0D)), ((V)(0.045)));
Call(synth_734, V.Undef, ((V)(25D)), ((V)(32D)), ((V)(1D)));
Invoke(I_730, "pad", ((V)(32D)), Arr(((V)(57D)), ((V)(60D)), ((V)(64D)), ((V)(67D))), ((V)(10D)), ((V)(0.02)), ((V)("triangle")), ((V)(1500D)));
Invoke(I_730, "beat", ((V)(35D)), ((V)(40.5)), ((V)(0.12)), Fn((V _arrowThis806, int _argc798, V t_804, V i_805, V _a802, V _a803, V[] _rest799) => {
return Invoke(I_730, "noise", t_804, ((V)(0.05)), NewObj(4).Put("ft", ((V)("bandpass"))).Put("f", ((V)(600D))).Put("q", ((V)(1D))).Put("vol", ((V)(0.05))).V);
}, 2, "", true));
Invoke(I_730, "pop", ((V)(40.5)), ((V)(0.2)));
Invoke(I_730, "boing", ((V)(40.6)), ((V)(0.12)));
Invoke(I_730, "sparkle", ((V)(40.8)), ((V)(84D)));
Invoke(I_730, "pad", ((V)(50D)), Arr(((V)(56D)), ((V)(60D)), ((V)(63D))), ((V)(10D)), ((V)(0.022)), ((V)("sawtooth")), ((V)(800D)));
Invoke(I_730, "alarm", ((V)(52D)), ((V)(3D)), ((V)(0.03)));
Invoke(I_730, "brass", ((V)(57.6)), ((V)(57D)), ((V)(1.5)), ((V)(0.05)));
Invoke(I_730, "brass", ((V)(57.6)), ((V)(64D)), ((V)(1.5)), ((V)(0.04)));
Invoke(I_730, "tone", ((V)(61.5)), ((V)(200D)), ((V)(3D)), NewObj(6).Put("to", ((V)(2400D))).Put("slide", ((V)(3D))).Put("type", ((V)("sawtooth"))).Put("lp", ((V)(3000D))).Put("vol", ((V)(0.05))).Put("at", ((V)(0.5))).V);
Invoke(I_730, "whoosh", ((V)(62D)), ((V)(3D)), ((V)(0.12)));
Invoke(I_730, "boom", ((V)(64.5)), ((V)(0.3)));
Call(synth_734, V.Undef, ((V)(64.5)), ((V)(70D)), ((V)(2D)), ((V)(2D)));
Call(synth_734, V.Undef, ((V)(70D)), ((V)(105D)), ((V)(2D)));
Call(theme_735, V.Undef, ((V)(76D)));
Call(theme_735, V.Undef, ((V)(90D)), ((V)(5D)));
{
double k_807 = 0;
k_807 = 4D;
while (true) {
if (!((k_807 < 12D))) break;
double th_809 = 0;
th_809 = ((72D + (k_807 * 2.6)) + ((340D - (210D + ((k_807 % 3D) * 30D))) / 90D));
Invoke(I_730, "zap", ((V)((th_809 - 0.35))));
Invoke(I_730, "pop", ((V)(th_809)), ((V)(0.1)));
Invoke(I_730, "sparkle", ((V)((th_809 + 0.05))), ((V)(88D)), ((V)(0.02)));
k_807++;
}
}
Invoke(I_730, "whoosh", ((V)(74.6)), ((V)(0.6)), ((V)(0.12)));
Invoke(I_730, "crash", ((V)(100D)), ((V)(0.1)));
Invoke(I_730, "alarm", ((V)(105D)), ((V)(18D)), ((V)(0.04)));
Invoke(I_730, "rumble", ((V)(105D)), ((V)(10D)), ((V)(0.08)));
Invoke(I_730, "beat", ((V)(105D)), ((V)(119D)), ((V)(B_731)), Fn((V _arrowThis818, int _argc810, V t_816, V i_817, V _a814, V _a815, V[] _rest811) => {
Invoke(I_730, "bass", t_816, ((V)(40D)), ((V)(0.3)), ((V)(0.1)));
if (((ToNum(i_817) % 2D) == 0D)) {
Invoke(I_730, "timp", t_816, ((V)(0.1)));
}
return default;
}, 2, "", true));
Invoke(I_730, "noise", ((V)(114.6)), ((V)(5D)), NewObj(5).Put("ft", ((V)("bandpass"))).Put("f", ((V)(3000D))).Put("q", ((V)(0.5))).Put("vol", ((V)(0.03))).Put("at", ((V)(0.5))).V);
Invoke(I_730, "steam", ((V)(115D)), ((V)(5D)), ((V)(0.06)));
Invoke(I_730, "tone", ((V)(119.4)), ((V)(300D)), ((V)(0.6)), NewObj(4).Put("to", ((V)(900D))).Put("slide", ((V)(0.5))).Put("vol", ((V)(0.06))).Put("type", ((V)("triangle"))).V);
Invoke(I_730, "sparkle", ((V)(120D)), ((V)(79D)));
Call(synth_734, V.Undef, ((V)(121D)), ((V)(130D)), ((V)(1D)));
Invoke(I_730, "beat", ((V)(130D)), ((V)(160D)), ((V)(1D)), Fn((V _arrowThis827, int _argc819, V t_825, V i_826, V _a823, V _a824, V[] _rest820) => {
Invoke(I_730, "pad", t_825, Invoke(GetIdx(GetIdx(PR_732, (ToNum(i_826) % 4D)), 1D), "map", Fn((V _arrowThis835, int _argc828, V m_834, V _a831, V _a832, V _a833, V[] _rest829) => {
return Add(m_834, ((V)(12D)));
}, 1, "", true)), ((V)(1.05)), ((V)(0.012)), ((V)("triangle")), ((V)(2000D)));
Invoke(I_730, "bell", Add(t_825, ((V)(0.5))), GetIdx(Arr(((V)(88D)), ((V)(86D)), ((V)(84D)), ((V)(83D))), (ToNum(i_826) % 4D)), ((V)(0.8)), ((V)(0.025)));
Invoke(I_730, "sub", t_825, ((V)((ToNum(GetIdx(GetIdx(PR_732, (ToNum(i_826) % 4D)), 0D)) - 12D))), ((V)(0.9)), ((V)(0.08)));
return default;
}, 2, "", true));
Invoke(Arr(((V)(134D)), ((V)(136.4)), ((V)(138D))), "forEach", Fn((V _arrowThis843, int _argc836, V t_842, V _a839, V _a840, V _a841, V[] _rest837) => {
return Invoke(I_730, "boing", t_842, ((V)(0.05)));
}, 1, "", true));
Invoke(I_730, "tone", ((V)(140.4)), ((V)(500D)), ((V)(0.15)), NewObj(4).Put("to", ((V)(200D))).Put("slide", ((V)(0.1))).Put("vol", ((V)(0.12))).Put("type", ((V)("triangle"))).V);
Invoke(I_730, "tone", ((V)(162D)), ((V)(120D)), ((V)(8D)), NewObj(7).Put("to", ((V)(240D))).Put("slide", ((V)(6D))).Put("type", ((V)("sawtooth"))).Put("lp", ((V)(800D))).Put("vol", ((V)(0.06))).Put("at", ((V)(1D))).Put("vib", Arr(((V)(8D)), ((V)(10D)))).V);
Invoke(I_730, "beat", ((V)(164D)), ((V)(168D)), ((V)(0.25)), Fn((V _arrowThis851, int _argc844, V t_850, V _a847, V _a848, V _a849, V[] _rest845) => {
return Invoke(I_730, "tone", t_850, ((V)(640D)), ((V)(0.1)), NewObj(3).Put("to", ((V)(900D))).Put("slide", ((V)(0.08))).Put("vol", ((V)(0.03))).V);
}, 1, "", true));
Invoke(I_730, "pad", ((V)(168D)), Arr(((V)(38D)), ((V)(39D)), ((V)(45D))), ((V)(12D)), ((V)(0.035)), ((V)("sawtooth")), ((V)(400D)));
Invoke(I_730, "boom", ((V)(168.2)), ((V)(0.4)));
Invoke(I_730, "beat", ((V)(169D)), ((V)(180D)), ((V)(0.8)), Fn((V _arrowThis859, int _argc852, V t_858, V _a855, V _a856, V _a857, V[] _rest853) => {
Invoke(I_730, "kick", t_858, ((V)(0.25)));
Invoke(I_730, "kick", Add(t_858, ((V)(0.2))), ((V)(0.2)));
return default;
}, 1, "", true));
Invoke(I_730, "sparkle", ((V)(180D)), ((V)(84D)));
Call(synth_734, V.Undef, ((V)(181D)), ((V)(200D)), ((V)(1D)), ((V)(3D)));
Invoke(I_730, "pad", ((V)(181D)), Arr(((V)(60D)), ((V)(64D)), ((V)(67D))), ((V)(19D)), ((V)(0.015)), ((V)("triangle")), ((V)(1600D)));
Invoke(Arr(((V)(72D)), ((V)(74D)), ((V)(76D)), ((V)(79D))), "forEach", Fn((V _arrowThis868, int _argc860, V m_866, V k_867, V _a864, V _a865, V[] _rest861) => {
return Invoke(I_730, "voice", ((V)((189D + (ToNum(k_867) * 0.6)))), m_866, ((V)(0.6)), ((V)(0.05)));
}, 2, "", true));
Invoke(I_730, "pad", ((V)(200D)), Arr(((V)(50D)), ((V)(57D)), ((V)(62D)), ((V)(66D))), ((V)(10D)), ((V)(0.025)), ((V)("sawtooth")), ((V)(1100D)));
Invoke(I_730, "pad", ((V)(210D)), Arr(((V)(52D)), ((V)(59D)), ((V)(64D)), ((V)(67D))), ((V)(10D)), ((V)(0.025)), ((V)("sawtooth")), ((V)(1100D)));
Invoke(I_730, "tone", ((V)(201D)), ((V)(160D)), ((V)(3.5)), NewObj(5).Put("to", ((V)(120D))).Put("slide", ((V)(3D))).Put("vol", ((V)(0.12))).Put("at", ((V)(0.6))).Put("vib", Arr(((V)(3D)), ((V)(8D)))).V);
Invoke(I_730, "tone", ((V)(208D)), ((V)(220D)), ((V)(3D)), NewObj(5).Put("to", ((V)(150D))).Put("slide", ((V)(3D))).Put("vol", ((V)(0.1))).Put("at", ((V)(0.6))).Put("vib", Arr(((V)(3D)), ((V)(8D)))).V);
Call(theme_735, V.Undef, ((V)(203D)), ((V)((-2D))), ((V)(0.04)));
Call(theme_735, V.Undef, ((V)(212D)), ((V)(0D)), ((V)(0.04)));
Invoke(I_730, "tone", ((V)(223D)), ((V)(300D)), ((V)(3D)), NewObj(6).Put("to", ((V)(1500D))).Put("slide", ((V)(3D))).Put("type", ((V)("sawtooth"))).Put("lp", ((V)(2500D))).Put("vol", ((V)(0.05))).Put("at", ((V)(0.4))).V);
Invoke(I_730, "crash", ((V)(226D)), ((V)(0.15)));
Invoke(I_730, "boom", ((V)(226D)), ((V)(0.3)));
Call(synth_734, V.Undef, ((V)(226D)), ((V)(235D)), ((V)(2D)), ((V)(5D)));
Call(theme_735, V.Undef, ((V)(226D)), ((V)(5D)));
Invoke(Arr(((V)(6D)), ((V)(7.2)), ((V)(8.4)), ((V)(9.6)), ((V)(10.8)), ((V)(12D))), "forEach", Fn((V _arrowThis876, int _argc869, V d_875, V _a872, V _a873, V _a874, V[] _rest870) => {
Invoke(I_730, "pop", Add(((V)(220D)), d_875), ((V)(0.12)));
Invoke(I_730, "sparkle", Add(Add(((V)(220D)), d_875), ((V)(0.05))), ((V)((84D + ((ToNum(d_875) * 3D) % 7D)))), ((V)(0.03)));
return default;
}, 1, "", true));
Invoke(I_730, "pad", ((V)(235D)), Arr(((V)(57D)), ((V)(60D)), ((V)(64D)), ((V)(71D))), ((V)(5D)), ((V)(0.02)), ((V)("triangle")), ((V)(1500D)));
Invoke(Arr(((V)(81D)), ((V)(79D)), ((V)(76D)), ((V)(74D)), ((V)(76D))), "forEach", Fn((V _arrowThis885, int _argc877, V m_883, V k_884, V _a881, V _a882, V[] _rest878) => {
return Invoke(I_730, "bell", ((V)((235.4 + (ToNum(k_884) * 0.5)))), m_883, ((V)(1D)), ((V)(0.04)));
}, 2, "", true));
return default;
}, 1, "score", false);
SM_8 = Get(G("window"), "SquadMovies");
K_9 = Get(G("window"), "MK");
if (((!(Truthy(SM_8)) || !(Truthy(K_9))) || !(Truthy(Get(SM_8, "def"))))) {
return default;
}
{ V _t886 = K_9;
if (_t886.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t886));
{ V _t887 = Get(_t886, "D");
D_10 = _t887; }
{ V _t888 = Get(_t886, "P");
P_11 = _t888; }
{ V _t889 = Get(_t886, "E");
E_12 = _t889; }
{ V _t890 = Get(_t886, "kf");
kf_13 = _t890; }
{ V _t891 = Get(_t886, "win");
win_14 = _t891; }
{ V _t892 = Get(_t886, "put");
put_15 = _t892; }
{ V _t893 = Get(_t886, "show");
show_16 = _t893; }
{ V _t894 = Get(_t886, "actor");
actor_17 = _t894; }
{ V _t895 = Get(_t886, "pose");
pose_18 = _t895; }
{ V _t896 = Get(_t886, "go");
go_19 = _t896; }
{ V _t897 = Get(_t886, "dance");
dance_20 = _t897; }
{ V _t898 = Get(_t886, "bub");
bub_21 = _t898; }
{ V _t899 = Get(_t886, "lines");
lines_22 = _t899; }
{ V _t900 = Get(_t886, "parts");
parts_23 = _t900; }
{ V _t901 = Get(_t886, "glow");
glow_24 = _t901; }
{ V _t902 = Get(_t886, "film");
film_25 = _t902; }
{ V _t903 = Get(_t886, "snd");
snd_26 = _t903; }
{ V _t904 = Get(_t886, "rnd");
rnd_27 = _t904; }
{ V _t905 = Get(_t886, "cl");
cl_28 = _t905; }
{ V _t906 = Get(_t886, "lerp");
lerp_29 = _t906; }
{ V _t907 = Get(_t886, "stars");
stars_30 = _t907; } }
W_31 = 52D;
SPR_32 = Arr(((V)("#ff6fa8")), ((V)("#ffd66b")), ((V)("#8fe8ff")), ((V)("#a6f06a")), ((V)("#c9a6ff")), ((V)("#ffffff")));
SHIP_33 = ((V)("<svg viewBox=\"0 0 100 60\" width=\"100\" height=\"60\"><path d=\"M14 30 Q2 18 8 10 Q14 14 22 22Z\" fill=\"#ff8fb8\" stroke=\"#5a2a5a\" stroke-width=\"1.6\"></path><path d=\"M14 34 Q2 46 8 54 Q14 50 22 42Z\" fill=\"#ff8fb8\" stroke=\"#5a2a5a\" stroke-width=\"1.6\"></path><path d=\"M70 26 Q84 24 96 12 L98 16 Q88 30 72 36Z\" fill=\"#dfe8ff\" stroke=\"#5a2a5a\" stroke-width=\"1.6\"></path><ellipse cx=\"44\" cy=\"33\" rx=\"32\" ry=\"20\" fill=\"#eef4ff\" stroke=\"#5a2a5a\" stroke-width=\"1.8\"></ellipse><path d=\"M14 36 Q44 46 76 36\" stroke=\"#8fd4ff\" stroke-width=\"5\" fill=\"none\"></path><path d=\"M28 15 Q44 4 60 15Z\" fill=\"#c9d8ff\" stroke=\"#5a2a5a\" stroke-width=\"1.6\"></path><circle cx=\"44\" cy=\"7\" r=\"3.4\" fill=\"#ffd66b\" stroke=\"#5a2a5a\" stroke-width=\"1.2\"></circle><circle cx=\"50\" cy=\"29\" r=\"8\" fill=\"#8fe8ff\" stroke=\"#5a2a5a\" stroke-width=\"2\"></circle><path d=\"M46 25 Q49 23 52 24\" stroke=\"#fff\" stroke-width=\"1.6\" fill=\"none\"></path><ellipse cx=\"30\" cy=\"24\" rx=\"6\" ry=\"3\" fill=\"#ffffff\" opacity=\"0.7\"></ellipse></svg>"));
FLAME_34 = ((V)("<svg viewBox=\"0 0 40 20\" width=\"40\" height=\"20\"><path d=\"M40 10 Q20 -2 0 10 Q20 22 40 10Z\" fill=\"#ffb84a\"></path><path d=\"M40 10 Q26 3 12 10 Q26 17 40 10Z\" fill=\"#fff3b0\"></path></svg>"));
shipN_35 = Fn((V _arrowThis917, int _argc908, V p_914, V _a911, V _a912, V _a913, V[] _rest909) => {
V g_918 = default;
V f_919 = default;
V z_916 = default;
{ V _t915 = _a911; if (_t915.IsUndef) _t915 = ((V)(10D));
z_916 = _t915; }
g_918 = Call(D_10, V.Undef, p_914, ((V)(JsStrBuf.Begin().S("left:0;top:0;width:100px;height:60px;display:none;z-index:").V(z_916).S(";transform-origin:50% 50%;").End())));
f_919 = Call(D_10, V.Undef, g_918, ((V)("left:-30px;top:23px;width:40px;height:20px;transform-origin:100% 50%;")), FLAME_34);
Call(D_10, V.Undef, g_918, ((V)("left:0;top:0;")), SHIP_33);
Set(g_918, "_f", f_919);
return g_918;
return default;
}, 2, "", true);
ship_36 = Fn((V _arrowThis937, int _argc920, V g_926, V x_927, V y_928, V _a925, V[] _rest921) => {
V k_930 = default;
V r_932 = default;
V fl_934 = default;
V t_936 = default;
{ V _t929 = _a925; if (_t929.IsUndef) _t929 = ((V)(1D));
k_930 = _t929; }
{ V _t931 = (_argc920 > 4 ? _rest921[0] : V.Undef); if (_t931.IsUndef) _t931 = ((V)(0D));
r_932 = _t931; }
{ V _t933 = (_argc920 > 5 ? _rest921[1] : V.Undef); if (_t933.IsUndef) _t933 = ((V)(1D));
fl_934 = _t933; }
{ V _t935 = (_argc920 > 6 ? _rest921[2] : V.Undef); if (_t935.IsUndef) _t935 = ((V)(0D));
t_936 = _t935; }
Call(put_15, V.Undef, g_926, x_927, y_928, k_930, r_932, ((V)(1D)));
Set(Get(Get(g_926, "_f"), "style"), "opacity", Invoke(fl_934, "toFixed", ((V)(2D))));
Set(Get(Get(g_926, "_f"), "style"), "transform", ((V)(JsStrBuf.Begin().S("scaleX(").V(Invoke(((V)(((0.7 + (0.4 * ToNum(fl_934))) + (0.15 * FdLibm.Sin((ToNum(t_936) * 40D)))))), "toFixed", ((V)(3D)))).S(") scaleY(").V(Invoke(((V)((0.9 + (0.1 * FdLibm.Sin((ToNum(t_936) * 31D)))))), "toFixed", ((V)(3D)))).S(")").End())));
return default;
}, 7, "", true);
planet_38 = Fn((V _arrowThis948, int _argc938, V p_944, V d_945, V bg_946, V ring_947, V[] _rest939) => {
V n_949 = default;
n_949 = Call(D_10, V.Undef, p_944, ((V)(JsStrBuf.Begin().S("left:0;top:0;width:").V(d_945).S("px;height:").V(d_945).S("px;border-radius:50%;background:").V(bg_946).S(";display:none;").End())));
if (Truthy(ring_947)) {
Call(D_10, V.Undef, n_949, ((V)(JsStrBuf.Begin().S("left:").N(((-ToNum(d_945)) * 0.3)).S("px;top:").N((ToNum(d_945) * 0.42)).S("px;width:").N((ToNum(d_945) * 1.6)).S("px;height:").N((ToNum(d_945) * 0.16)).S("px;border-radius:50%;border:2px solid ").V(ring_947).S(";box-sizing:border-box;transform:rotate(-12deg);").End())));
}
return n_949;
return default;
}, 4, "", true);
burst_40 = Fn((V _arrowThis963, int _argc950, V p_956, V n_957, V x0_958, V y0_959, V[] _rest951) => {
V t0_960 = default;
V sz_962 = default;
t0_960 = (_argc950 > 4 ? _rest951[0] : V.Undef);
{ V _t961 = (_argc950 > 5 ? _rest951[1] : V.Undef); if (_t961.IsUndef) _t961 = ((V)(1D));
sz_962 = _t961; }
return Call(parts_23, V.Undef, p_956, n_957, ((V)("width:4px;height:2px;border-radius:1px;z-index:12;")), V.Null, Fn((V _arrowThis972, int _argc964, V i_970, V t_971, V _a968, V _a969, V[] _rest965) => {
double d_973 = 0;
V r_974 = default;
double a_975 = 0;
double s_976 = 0;
d_973 = (ToNum(t_971) - ToNum(t0_960));
if (((d_973 < 0D) || (d_973 > 1.6))) {
return V.Null;
}
r_974 = Call(rnd_27, V.Undef, ((V)(((ToNum(i_970) * 13D) + Round(ToNum(x0_958))))));
a_975 = ((ToNum(Call(r_974, V.Undef)) * System.Math.PI) * 2D);
s_976 = ((30D + (ToNum(Call(r_974, V.Undef)) * 50D)) * ToNum(sz_962));
return NewObj(4).Put("x", Add(x0_958, ((V)(((FdLibm.Cos(a_975) * s_976) * (1D - FdLibm.Exp(((-d_973) * 4D)))))))).Put("y", Add(Add(y0_959, ((V)(((FdLibm.Sin(a_975) * s_976) * (1D - FdLibm.Exp(((-d_973) * 4D))))))), ((V)(((d_973 * d_973) * 10D))))).Put("r", ((V)(((a_975 * 57D) + (d_973 * 400D))))).Put("o", ((V)((1D - (d_973 / 1.6))))).V;
return default;
}, 2, "", true));
}, 6, "", true);
paint_41 = Fn((V _arrowThis984, int _argc977, V L_983, V _a980, V _a981, V _a982, V[] _rest978) => {
Invoke(new ArrBuilder().Spread(Invoke(L_983, "querySelectorAll", ((V)("div")))).V, "forEach", Fn((V _arrowThis993, int _argc985, V n_991, V i_992, V _a989, V _a990, V[] _rest986) => {
if ((SEqS(Get(Get(n_991, "style"), "width"), "4px") && SEqS(Get(Get(n_991, "style"), "height"), "2px"))) {
Set(Get(n_991, "style"), "background", GetIdx(SPR_32, (ToNum(i_992) % 6D)));
}
return default;
}, 2, "", true));
return default;
}, 1, "", true);
Invoke(SM_8, "def", ((V)("trek")), NewObj(4).Put("mk", mk_42).Put("score", score_43).Put("beat", Fn((V _arrowThis1001, int _argc994, V t_1000, V _a997, V _a998, V _a999, V[] _rest995) => {
V on_1002 = default;
double x_1003 = 0;
on_1002 = ((((((GeN(t_1000, 10D) && LtN(t_1000, 32D)) || (GeN(t_1000, 64.5) && LtN(t_1000, 105D))) || (GeN(t_1000, 121D) && LtN(t_1000, 130D))) || (GeN(t_1000, 181D) && LtN(t_1000, 200D))) || (GeN(t_1000, 226D) && LtN(t_1000, 235D))) ? V.True : V.False);
if (!(Truthy(on_1002))) {
return V.Null;
}
x_1003 = (ToNum(t_1000) / 0.5);
return NewObj(3).Put("n", ((V)(System.Math.Floor(x_1003)))).Put("ph", ((V)((x_1003 - System.Math.Floor(x_1003))))).Put("amp", ((V)(0.8))).V;
return default;
}, 1, "beat", true)).Put("cues", Arr(Arr(((V)(10.5)), ((V)("cheer"))), Arr(((V)(41D)), ((V)("laugh"))), Arr(((V)(74.8)), ((V)("gasp"))), Arr(((V)(85D)), ((V)("cheer"))), Arr(((V)(100.5)), ((V)("cheer"))), Arr(((V)(120D)), ((V)("laugh"))), Arr(((V)(140.5)), ((V)("laugh"))), Arr(((V)(145D)), ((V)("doze"))), Arr(((V)(168.4)), ((V)("hide"))), Arr(((V)(183D)), ((V)("laugh"))), Arr(((V)(201D)), ((V)("wake"))), Arr(((V)(202D)), ((V)("gasp"))), Arr(((V)(224D)), ((V)("cheer"))), Arr(((V)(230D)), ((V)("cheer"))))).V);
return default;
}, 0, "", false), V.Undef);
        }
    }
}
