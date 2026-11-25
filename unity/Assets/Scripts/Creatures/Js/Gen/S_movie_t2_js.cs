// movie-t2.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_movie_t2_js
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
double FY_32 = 0;
double W_33 = 0;
V HAT_34 = default;
V LENS_35 = default;
V LANT_36 = default;
V LAMP_37 = default;
V PIE_38 = default;
V bakery_39 = default;
V boo_40 = default;
V hoot_41 = default;
V mk_42 = default;
V score_43 = default;
if (_self1.IsNullish) _self1 = GlobalV;
bakery_39 = Fn((V _self44, int _argc45, V L_51, V seed_52, V _a49, V _a50, V[] _rest46) => {
V cam_53 = default;
V w_54 = default;
V moon_55 = default;
V rn_56 = default;
V wf_57 = default;
V ctr_58 = default;
V plate_59 = default;
V lamp_60 = default;
V act_61 = default;
V dark_62 = default;
V fl_63 = default;
if (_self44.IsNullish) _self44 = GlobalV;
cam_53 = Call(D_10, V.Undef, L_51, ((V)("left:0;top:0;width:320px;height:180px;transform-origin:160px 110px;")));
Call(D_10, V.Undef, cam_53, ((V)("left:-40px;top:0;width:800px;height:142px;background:linear-gradient(#141a42,#26306a 70%,#2e3a78);")));
Call(D_10, V.Undef, cam_53, ((V)("left:-40px;top:96px;width:800px;height:46px;background:repeating-linear-gradient(90deg,#3a2f5e 0 18px,#342a56 18px 20px);border-top:3px solid #4b3f78;")));
w_54 = Call(D_10, V.Undef, cam_53, ((V)("left:228px;top:18px;width:66px;height:54px;overflow:hidden;border:4px solid #4b3f78;background:linear-gradient(#0b1030,#1c2a62);")));
moon_55 = Call(D_10, V.Undef, w_54, ((V)("left:38px;top:6px;width:16px;height:16px;border-radius:50%;background:#fff6c8;box-shadow:0 0 12px 4px rgba(255,246,200,0.5);")));
Call(D_10, V.Undef, w_54, ((V)("left:31px;top:0;width:3px;height:100%;background:#4b3f78;")));
Call(D_10, V.Undef, w_54, ((V)("left:0;top:24px;width:100%;height:3px;background:#4b3f78;")));
rn_56 = Call(rain_24, V.Undef, w_54, ((V)(26D)), seed_52);
wf_57 = Call(D_10, V.Undef, w_54, ((V)("inset:0;background:#dfe8ff;opacity:0;")));
Invoke(Arr(Arr(((V)(20D)), ((V)(26D))), Arr(((V)(20D)), ((V)(58D)))), "forEach", Fn((V _arrowThis75, int _argc64, V _a66, V _a67, V _a68, V _a69, V[] _rest65) => {
V x_72 = default;
V y_74 = default;
{ V _t70 = ListOf(_a66);
{ V _t71 = GetIdx(_t70, 0D);
x_72 = _t71; }
{ V _t73 = GetIdx(_t70, 1D);
y_74 = _t73; }
}
Call(D_10, V.Undef, cam_53, ((V)(JsStrBuf.Begin().S("left:").V(x_72).S("px;top:").V(y_74).S("px;width:70px;height:4px;background:#5a4a86;").End())));
Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "forEach", Fn((V _arrowThis83, int _argc76, V k_82, V _a79, V _a80, V _a81, V[] _rest77) => {
return Call(D_10, V.Undef, cam_53, ((V)(JsStrBuf.Begin().S("left:").V(Add(Add(x_72, ((V)(6D))), ((V)((ToNum(k_82) * 22D))))).S("px;top:").N(((ToNum(y_74) - 14D) + ((ToNum(k_82) % 2D) * 3D))).S("px;width:13px;height:").N((14D - ((ToNum(k_82) % 2D) * 3D))).S("px;border-radius:3px 3px 2px 2px;background:").V(GetK(Arr(((V)("#6a5aa6")), ((V)("#8a6ab6")), ((V)("#5a7ab6"))), k_82)).S(";border:1px solid #2a2050;").End())));
}, 1, "", true));
return default;
}, 1, "", true));
Call(D_10, V.Undef, cam_53, ((V)("left:-40px;top:142px;width:800px;height:40px;background:repeating-conic-gradient(#1e1a40 0% 25%,#2c2856 0% 50%) 0 0/28px 14px;")));
ctr_58 = Call(D_10, V.Undef, cam_53, ((V)("left:96px;top:106px;width:128px;height:44px;")));
Call(D_10, V.Undef, ctr_58, ((V)("left:0;top:6px;width:128px;height:38px;border-radius:2px;background:linear-gradient(#5a4a8a,#3e3270);")));
Call(D_10, V.Undef, ctr_58, ((V)("left:-4px;top:0;width:136px;height:7px;border-radius:3px;background:#8a7ac0;")));
Call(D_10, V.Undef, ctr_58, ((V)("left:10px;top:16px;width:50px;height:20px;border:2px solid #6a5aa0;border-radius:2px;box-sizing:border-box;")));
Call(D_10, V.Undef, ctr_58, ((V)("left:68px;top:16px;width:50px;height:20px;border:2px solid #6a5aa0;border-radius:2px;box-sizing:border-box;")));
plate_59 = Call(D_10, V.Undef, cam_53, ((V)("left:140px;top:96px;width:40px;height:12px;")), ((V)("<svg viewBox=\"0 0 40 12\" width=\"40\" height=\"12\"><ellipse cx=\"20\" cy=\"8\" rx=\"19\" ry=\"3.6\" fill=\"#dfe6ff\" stroke=\"#8a90c0\" stroke-width=\"0.8\"></ellipse><path d=\"M17 11 L23 11 L22 6 L18 6Z\" fill=\"#c2c8ee\"></path><circle cx=\"14\" cy=\"7\" r=\"0.9\" fill=\"#a8743a\"></circle><circle cx=\"25\" cy=\"7.6\" r=\"0.8\" fill=\"#a8743a\"></circle><circle cx=\"20\" cy=\"6.6\" r=\"0.7\" fill=\"#a8743a\"></circle></svg>")));
Call(D_10, V.Undef, cam_53, ((V)("left:186px;top:91px;width:26px;height:16px;border-radius:2px;background:#fff6dc;border:1px solid #8a7050;font-size:5.2px;line-height:7px;color:#5a3420;text-align:center;padding-top:1px;box-sizing:border-box;")), ((V)("MOON<br>PIE")));
lamp_60 = Call(D_10, V.Undef, cam_53, ((V)("left:150px;top:0;width:20px;height:26px;")), ((V)("<svg viewBox=\"0 0 20 26\" width=\"20\" height=\"26\"><path d=\"M10 0 L10 12\" stroke=\"#4b3f78\" stroke-width=\"1.5\"></path><path d=\"M3 20 L6 12 L14 12 L17 20Z\" fill=\"#6a5aa6\"></path></svg>")));
act_61 = Call(D_10, V.Undef, cam_53, ((V)("left:0;top:0;width:320px;height:180px;")));
dark_62 = Call(D_10, V.Undef, L_51, ((V)("inset:0;pointer-events:none;")));
fl_63 = Call(D_10, V.Undef, L_51, ((V)("inset:0;background:#e6eeff;opacity:0;pointer-events:none;")));
return NewObj(6).Put("cam", cam_53).Put("act", act_61).Put("ctr", ctr_58).Put("plate", plate_59).Put("lamp", lamp_60).Put("upd", Fn((V _self84, int _argc85, V t_91, V _a88, V _a89, V _a90, V[] _rest86) => {
V l_94 = default;
V d_95 = default;
V sp_96 = default;
V o_93 = default;
if (_self84.IsNullish) _self84 = GlobalV;
{ V _t92 = _a88; if (_t92.IsUndef) _t92 = NewObj(0).V;
o_93 = _t92; }
Call(rn_56, V.Undef, t_91);
l_94 = (Get(o_93, "flash") is var _t97 && Truthy(_t97) ? _t97 : ((V)(0D)));
Set(Get(wf_57, "style"), "opacity", Invoke(((V)((ToNum(l_94) * 0.8))), "toFixed", ((V)(3D))));
Set(Get(fl_63, "style"), "opacity", Invoke(((V)((ToNum(l_94) * 0.55))), "toFixed", ((V)(3D))));
d_95 = (Get(o_93, "dark") is var _t98 && !_t98.IsNullish ? _t98 : ((V)(0.55)));
sp_96 = Get(o_93, "spot");
Set(Get(dark_62, "style"), "background", ((V)((Truthy(sp_96) ? JsStrBuf.Begin().S("radial-gradient(circle at ").V(GetIdx(sp_96, 0D)).S("px ").V(GetIdx(sp_96, 1D)).S("px, rgba(6,8,28,0) ").V(GetIdx(sp_96, 2D)).S("px, rgba(6,8,28,").V(d_95).S(") ").N((ToNum(GetIdx(sp_96, 2D)) * 1.8)).S("px)").End() : JsStrBuf.Begin().S("rgba(6,8,28,").V(d_95).S(")").End()))));
if (Truthy(Get(o_93, "cam"))) {
Set(Get(cam_53, "style"), "transform", ((V)(JsStrBuf.Begin().S("translate(").V(Invoke((GetIdx(Get(o_93, "cam"), 0D) is var _t99 && Truthy(_t99) ? _t99 : ((V)(0D))), "toFixed", ((V)(1D)))).S("px,").V(Invoke((GetIdx(Get(o_93, "cam"), 1D) is var _t100 && Truthy(_t100) ? _t100 : ((V)(0D))), "toFixed", ((V)(1D)))).S("px) scale(").V(Invoke((GetIdx(Get(o_93, "cam"), 2D) is var _t101 && Truthy(_t101) ? _t101 : ((V)(1D))), "toFixed", ((V)(3D)))).S(")").End())));
}
return default;
}, 2, "upd", false)).V;
return default;
}, 2, "bakery", false);
mk_42 = Fn((V _self102, int _argc103, V _a105, V _a106, V _a107, V _a108, V[] _rest104) => {
V S_109 = default;
if (_self102.IsNullish) _self102 = GlobalV;
S_109 = Arr();
Invoke(S_109, "push", NewObj(5).Put("a", ((V)(0D))).Put("b", ((V)(14D))).Put("rgb", ((V)("120,140,255"))).Put("lit", Fn((V _arrowThis117, int _argc110, V t_116, V _a113, V _a114, V _a115, V[] _rest111) => {
return ((V)((0.4 + (ToNum(Call(lightning_25, V.Undef, t_116, Arr(((V)(8.5)), ((V)(11.2))))) * 0.8))));
}, 1, "lit", true)).Put("mk", Fn((V _self118, int _argc119, V L_125, V _a122, V _a123, V _a124, V[] _rest120) => {
V B_126 = default;
V ti_127 = default;
if (_self118.IsNullish) _self118 = GlobalV;
B_126 = Call(bakery_39, V.Undef, L_125, ((V)(3D)));
ti_127 = Call(D_10, V.Undef, L_125, ((V)("left:0;top:34px;width:320px;text-align:center;font-family:'Creepster',cursive;font-size:30px;line-height:1.05;color:#c8f08a;text-shadow:0 0 10px rgba(150,255,120,0.6),0 3px 0 #1a1040;letter-spacing:1px;z-index:40;")), ((V)("WHO ATE THE<br>MOON PIE?")));
return Fn((V _arrowThis135, int _argc128, V t_134, V _a131, V _a132, V _a133, V[] _rest129) => {
V l_136 = default;
V z_137 = default;
double cx_138 = 0;
l_136 = Call(lightning_25, V.Undef, t_134, Arr(((V)(8.5)), ((V)(11.2))));
Set(Get(ti_127, "style"), "opacity", Invoke(((V)((ToNum(Call(P_11, V.Undef, t_134, ((V)(0.6)), ((V)(2D)))) * (1D - ToNum(Call(P_11, V.Undef, t_134, ((V)(6D)), ((V)(7D)))))))), "toFixed", ((V)(3D))));
Set(Get(ti_127, "style"), "transform", ((V)(JsStrBuf.Begin().S("translateY(").V(Invoke(((V)((FdLibm.Sin((ToNum(t_134) * 2D)) * 2D))), "toFixed", ((V)(1D)))).S("px)").End())));
z_137 = Call(kf_13, V.Undef, t_134, Arr(Arr(((V)(6.5)), ((V)(1D))), Arr(((V)(12D)), ((V)(1.9)))));
cx_138 = ((1D - ToNum(z_137)) * 0D);
Invoke(B_126, "upd", t_134, NewObj(4).Put("flash", l_136).Put("dark", ((V)((0.5 + (0.2 * ToNum(Call(P_11, V.Undef, t_134, ((V)(6D)), ((V)(8D))))))))).Put("spot", Arr(((V)(160D)), ((V)(100D)), ((V)((30D + (25D * ToNum(l_136))))))).Put("cam", Arr(((V)(cx_138)), ((V)(((ToNum(z_137) - 1D) * 10D))), z_137)).V);
Set(Get(Get(B_126, "cam"), "style"), "transformOrigin", ((V)("160px 102px")));
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
Invoke(S_109, "push", NewObj(4).Put("a", ((V)(14D))).Put("b", ((V)(26D))).Put("rgb", ((V)("120,140,255"))).Put("mk", Fn((V _self139, int _argc140, V L_146, V _a143, V _a144, V _a145, V[] _rest141) => {
V B_147 = default;
V b_148 = default;
V h_149 = default;
V sp_150 = default;
if (_self139.IsNullish) _self139 = GlobalV;
B_147 = Call(bakery_39, V.Undef, L_146, ((V)(5D)));
b_148 = Call(boo_40, V.Undef, Get(B_147, "act"));
h_149 = Call(hoot_41, V.Undef, Get(B_147, "act"));
sp_150 = Call(bub_21, V.Undef, L_146);
return Fn((V _arrowThis158, int _argc151, V t_157, V _a154, V _a155, V _a156, V[] _rest152) => {
V bs_159 = default;
V hs_160 = default;
bs_159 = Call(go_19, V.Undef, t_157, Arr(Arr(((V)(0D)), ((V)((-30D))), ((V)(150D)), NewObj(1).Put("m", ((V)("float"))).V), Arr(((V)(3D)), ((V)(118D)), ((V)(150D)))), NewObj(3).Put("m", ((V)("float"))).Put("gy", ((V)(FY_32))).Put("f", ((V)("front"))).V);
hs_160 = Call(go_19, V.Undef, t_157, Arr(Arr(((V)(0.8)), ((V)(350D))), Arr(((V)(1.3)), ((V)(320D)), V.Null, NewObj(1).Put("m", ((V)("hop"))).V), Arr(((V)(1.8)), ((V)(290D)), V.Null, NewObj(1).Put("m", ((V)("hop"))).V), Arr(((V)(2.3)), ((V)(260D)), V.Null, NewObj(1).Put("m", ((V)("hop"))).V), Arr(((V)(2.8)), ((V)(232D)), V.Null, NewObj(1).Put("m", ((V)("hop"))).V), Arr(((V)(3.3)), ((V)(206D)))), NewObj(3).Put("y", ((V)(FY_32))).Put("m", ((V)("hop"))).Put("f", ((V)("front"))).V);
Invoke(b_148, "put", bs_159, NewObj(1).Put("lens", (Truthy((bs_159 is var _t161 && !Truthy(_t161) ? _t161 : (GtN(t_157, 3D) ? V.True : V.False))) ? Arr(Add(Get(bs_159, "x"), ((V)(22D))), ((V)(((ToNum(Get(bs_159, "y")) - 30D) + (FdLibm.Sin((ToNum(t_157) * 3D)) * 2D)))), ((V)((-10D)))) : V.Null)).V);
Invoke(h_149, "put", hs_160);
Invoke(B_147, "upd", t_157, NewObj(2).Put("dark", ((V)(0.42))).Put("spot", (Truthy(hs_160) ? Arr(Add(Get(hs_160, "x"), ((V)(19D))), ((V)((ToNum(Get(hs_160, "y")) - 24D))), ((V)(50D))) : V.Null)).V);
Call(lines_22, V.Undef, sp_150, t_157, Arr(Arr(((V)(2.6)), ((V)(5.4)), ((V)("A crime... at the bakery!")), ((V)("b"))), Arr(((V)(5.8)), ((V)(8.6)), ((V)("Hoo... who did this?")), ((V)("h"))), Arr(((V)(9D)), ((V)(11.8)), ((V)("Line up the suspects!")), ((V)("b")))), NewObj(2).Put("b", (bs_159 is var _t162 && !Truthy(_t162) ? _t162 : Arr(Get(bs_159, "x"), ((V)((ToNum(Get(bs_159, "y")) - 60D)))))).Put("h", (hs_160 is var _t163 && !Truthy(_t163) ? _t163 : Arr(Get(hs_160, "x"), ((V)((ToNum(Get(hs_160, "y")) - 54D)))))).V);
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
Invoke(S_109, "push", NewObj(4).Put("a", ((V)(26D))).Put("b", ((V)(46D))).Put("rgb", ((V)("150,160,255"))).Put("mk", Fn((V _self164, int _argc165, V L_171, V _a168, V _a169, V _a170, V[] _rest166) => {
V B_172 = default;
V b_173 = default;
V h_174 = default;
V m_175 = default;
V sp_176 = default;
V cone_177 = default;
V fl_178 = default;
if (_self164.IsNullish) _self164 = GlobalV;
B_172 = Call(bakery_39, V.Undef, L_171, ((V)(7D)));
b_173 = Call(boo_40, V.Undef, Get(B_172, "act"));
h_174 = Call(hoot_41, V.Undef, Get(B_172, "act"));
m_175 = Call(actor_17, V.Undef, Get(B_172, "act"), ((V)("mochi")), ((V)(W_33)));
sp_176 = Call(bub_21, V.Undef, L_171);
cone_177 = Call(D_10, V.Undef, Get(B_172, "act"), ((V)("left:118px;top:20px;width:84px;height:140px;background:linear-gradient(rgba(255,240,180,0.35),rgba(255,240,180,0.04));clip-path:polygon(40% 0,60% 0,100% 100%,0 100%);")));
fl_178 = Call(parts_23, V.Undef, Get(B_172, "act"), ((V)(22D)), ((V)("width:10px;height:10px;border-radius:50%;background:#ffffff;z-index:8;")), V.Null, Fn((V _arrowThis187, int _argc179, V i_185, V t_186, V _a183, V _a184, V[] _rest180) => {
double d_188 = 0;
V r_189 = default;
double a_190 = 0;
double s_191 = 0;
double e_192 = 0;
d_188 = (ToNum(t_186) - 10.2);
if (((d_188 < 0D) || (d_188 > 2.6))) {
return V.Null;
}
r_189 = Call(rnd_29, V.Undef, ((V)(((ToNum(i_185) * 7D) + 1D))));
a_190 = (System.Math.PI * (0.65 + (ToNum(Call(r_189, V.Undef)) * 0.7)));
s_191 = (40D + (ToNum(Call(r_189, V.Undef)) * 70D));
e_192 = (1D - FdLibm.Exp(((-d_188) * 3D)));
return NewObj(4).Put("x", ((V)((160D + ((FdLibm.Cos(a_190) * s_191) * e_192))))).Put("y", ((V)(((128D + (((FdLibm.Sin(a_190) * s_191) * 0.5) * e_192)) - (d_188 * 6D))))).Put("k", ((V)((0.8 + (d_188 * 1.2))))).Put("o", ((V)((0.9 * (1D - (d_188 / 2.6)))))).V;
return default;
}, 2, "", true));
return Fn((V _arrowThis200, int _argc193, V t_199, V _a196, V _a197, V _a198, V[] _rest194) => {
double blow_201 = 0;
V bs_202 = default;
V sn_203 = default;
double lx_204 = 0;
V lens_205 = default;
blow_201 = (ToNum(Call(P_11, V.Undef, t_199, ((V)(10.2)), ((V)(10.5)))) * (1D - ToNum(Call(P_11, V.Undef, t_199, ((V)(12D)), ((V)(13.5))))));
bs_202 = Call(go_19, V.Undef, t_199, Arr(Arr(((V)(0D)), ((V)(100D)), ((V)(150D)), NewObj(1).Put("m", ((V)("float"))).V)), NewObj(2).Put("m", ((V)("float"))).Put("gy", ((V)(FY_32))).V);
sn_203 = ((GtN(t_199, 8.5) && LtN(t_199, 10.2)) ? Call(P_11, V.Undef, t_199, ((V)(8.5)), ((V)(10.1)), Get(E_12, "in")) : ((V)(((GeN(t_199, 10.2) && LtN(t_199, 10.6)) ? (1D - ToNum(Call(P_11, V.Undef, t_199, ((V)(10.2)), ((V)(10.45))))) : 0D))));
if (Truthy(bs_202)) {
OpSet(bs_202, "x", 1, ((V)((blow_201 * 34D))));
OpSet(bs_202, "r", 0, ((V)((blow_201 * (-30D)))));
}
lx_204 = (LtN(t_199, 9D) ? (140D + (FdLibm.Sin((ToNum(t_199) * 1.6)) * 14D)) : (120D - (blow_201 * 30D)));
lens_205 = Arr(((V)(lx_204)), ((V)((118D + (FdLibm.Cos((ToNum(t_199) * 1.3)) * 6D)))), ((V)((-20D))));
Invoke(b_173, "put", bs_202, NewObj(1).Put("lens", lens_205).V);
Invoke(h_174, "put", NewObj(4).Put("x", ((V)(250D))).Put("y", ((V)(FY_32))).Put("v", ((V)("front"))).Put("r", ((V)((FdLibm.Sin((ToNum(t_199) * 2D)) * 2D)))).V);
Call(pose_18, V.Undef, m_175, NewObj(6).Put("x", ((V)(160D))).Put("y", ((V)(FY_32))).Put("v", ((V)("front"))).Put("sx", ((V)(((1D - (0.1 * ToNum(sn_203))) + (0.14 * ((GeN(t_199, 10.2) && LtN(t_199, 10.5)) ? 1D : 0D)))))).Put("sy", ((V)(((1D + (0.14 * ToNum(sn_203))) - (0.2 * ((GeN(t_199, 10.2) && LtN(t_199, 10.5)) ? 1D : 0D)))))).Put("r", ((V)(((GtN(t_199, 10.5) && LtN(t_199, 12D)) ? (FdLibm.Sin((ToNum(t_199) * 20D)) * 4D) : 0D)))).V);
Call(fl_178, V.Undef, t_199);
Invoke(B_172, "upd", t_199, NewObj(2).Put("dark", ((V)(0.6))).Put("spot", Arr(((V)(160D)), ((V)(120D)), ((V)(38D)))).V);
Set(Get(cone_177, "style"), "opacity", ((V)("1")));
Call(lines_22, V.Undef, sp_176, t_199, Arr(Arr(((V)(2D)), ((V)(5D)), ((V)("Powder on your face, Mochi?")), ((V)("b"))), Arr(((V)(5.5)), ((V)(8D)), ((V)("I... I...")), ((V)("m"))), Arr(((V)(8.4)), ((V)(10.1)), ((V)("A... a... a...")), ((V)("m"))), Arr(((V)(10.2)), ((V)(11.4)), ((V)("ACHOO!")), ((V)("m"))), Arr(((V)(11.8)), ((V)(14.6)), ((V)("Just flour! Sorry!")), ((V)("m"))), Arr(((V)(15D)), ((V)(18.6)), ((V)("Not our pie thief.")), ((V)("h")))), NewObj(3).Put("b", (bs_202 is var _t206 && !Truthy(_t206) ? _t206 : Arr(Get(bs_202, "x"), ((V)((ToNum(Get(bs_202, "y")) - 60D)))))).Put("m", Arr(((V)(160D)), ((V)(104D)))).Put("h", Arr(((V)(250D)), ((V)(104D)))).V);
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
Invoke(S_109, "push", NewObj(4).Put("a", ((V)(46D))).Put("b", ((V)(62D))).Put("rgb", ((V)("150,160,255"))).Put("mk", Fn((V _self207, int _argc208, V L_214, V _a211, V _a212, V _a213, V[] _rest209) => {
V B_215 = default;
V b_216 = default;
V h_217 = default;
V pu_218 = default;
V sp_219 = default;
V tray_220 = default;
V zz_221 = default;
V gl_222 = default;
if (_self207.IsNullish) _self207 = GlobalV;
B_215 = Call(bakery_39, V.Undef, L_214, ((V)(9D)));
b_216 = Call(boo_40, V.Undef, Get(B_215, "act"));
h_217 = Call(hoot_41, V.Undef, Get(B_215, "act"));
pu_218 = Call(actor_17, V.Undef, Get(B_215, "act"), ((V)("puddi")), ((V)((W_33 - 6D))));
sp_219 = Call(bub_21, V.Undef, L_214);
tray_220 = Call(D_10, V.Undef, Get(B_215, "act"), ((V)("left:198px;top:101px;width:60px;height:7px;border-radius:3px;background:linear-gradient(#cfd4ee,#8a90c0);")));
zz_221 = Call(parts_23, V.Undef, Get(B_215, "act"), ((V)(3D)), ((V)("font-family:'Fredoka',sans-serif;font-weight:700;font-size:11px;color:#c9d4ff;z-index:8;")), ((V)("z")), Fn((V _arrowThis231, int _argc223, V i_229, V t_230, V _a227, V _a228, V[] _rest224) => {
double a_232 = 0;
if (GtN(t_230, 7D)) {
return V.Null;
}
a_232 = (((ToNum(t_230) * 0.45) + (ToNum(i_229) / 3D)) % 1D);
return NewObj(4).Put("x", ((V)(((236D + (a_232 * 16D)) + (FdLibm.Sin((a_232 * 6D)) * 3D))))).Put("y", ((V)((70D - (a_232 * 30D))))).Put("k", ((V)((0.7 + (a_232 * 0.8))))).Put("o", ((V)(FdLibm.Sin((System.Math.PI * a_232))))).V;
return default;
}, 2, "", true));
gl_222 = Call(parts_23, V.Undef, Get(B_215, "act"), ((V)(2D)), ((V)("width:6px;height:6px;border-radius:50%;background:#ffd88a;box-shadow:0 0 6px 2px #ffb84a;z-index:8;")), V.Null, Fn((V _arrowThis241, int _argc233, V i_239, V t_240, V _a237, V _a238, V[] _rest234) => {
return (LtN(t_240, 5.5) ? NewObj(4).Put("x", ((V)((222D + (ToNum(i_239) * 9D))))).Put("y", ((V)((86D + (ToNum(i_239) * 2D))))).Put("k", ((V)((0.6 + (0.4 * System.Math.Abs(FdLibm.Sin(ToNum(Add(((V)((ToNum(t_240) * 4D))), i_239))))))))).Put("o", ((V)(0.8))).V : V.Null);
}, 2, "", true));
return Fn((V _arrowThis249, int _argc242, V t_248, V _a245, V _a246, V _a247, V[] _rest243) => {
V up_250 = default;
V hs_251 = default;
up_250 = Call(P_11, V.Undef, t_248, ((V)(7D)), ((V)(7.35)), Get(E_12, "back"));
Invoke(b_216, "put", Call(go_19, V.Undef, t_248, Arr(Arr(((V)(0D)), ((V)(118D)), ((V)(150D)), NewObj(1).Put("m", ((V)("float"))).V)), NewObj(2).Put("m", ((V)("float"))).Put("gy", ((V)(FY_32))).V), NewObj(1).Put("lens", ((GtN(t_248, 2D) && LtN(t_248, 6D)) ? Arr(((V)(226D)), ((V)(92D)), ((V)((-10D)))) : V.Null)).V);
hs_251 = Call(go_19, V.Undef, t_248, Arr(Arr(((V)(0D)), ((V)(290D))), Arr(((V)(1.5)), ((V)(290D)), V.Null, NewObj(1).Put("m", ((V)("hop"))).V), Arr(((V)(2.2)), ((V)(262D)), V.Null, NewObj(1).Put("m", ((V)("hop"))).V), Arr(((V)(2.9)), ((V)(252D)))), NewObj(3).Put("y", ((V)(FY_32))).Put("m", ((V)("hop"))).Put("f", ((V)("left"))).V);
if (Truthy(((hs_251 is var _t252 && !Truthy(_t252) ? _t252 : (GtN(t_248, 5.6) ? V.True : V.False)) is var _t253 && !Truthy(_t253) ? _t253 : (LtN(t_248, 7D) ? V.True : V.False)))) {
Set(hs_251, "v", ((V)("left")));
Set(hs_251, "r", ((V)((FdLibm.Sin(((ToNum(t_248) - 5.6) * 14D)) * 12D))));
}
Invoke(h_217, "put", hs_251);
Call(pose_18, V.Undef, pu_218, NewObj(7).Put("x", ((V)(228D))).Put("y", ((V)(((103D - (ToNum(up_250) * 6D)) - ((GtN(t_248, 7D) && LtN(t_248, 7.6)) ? (FdLibm.Sin((((ToNum(t_248) - 7D) * System.Math.PI) / 0.6)) * 14D) : 0D))))).Put("v", ((V)("front"))).Put("r", ((V)((LtN(t_248, 7D) ? ((-8D) + (FdLibm.Sin((ToNum(t_248) * 1.5)) * 2D)) : 0D)))).Put("sx", ((V)((1D + ((0.03 * FdLibm.Sin((ToNum(t_248) * 2.5))) * (1D - ToNum(up_250))))))).Put("sy", ((V)((1D - ((0.05 * FdLibm.Sin((ToNum(t_248) * 2.5))) * (1D - ToNum(up_250))))))).Put("sh", (false ? V.True : V.False)).V);
Call(zz_221, V.Undef, t_248);
Call(gl_222, V.Undef, t_248);
Invoke(B_215, "upd", t_248, NewObj(2).Put("dark", ((V)(0.5))).Put("spot", Arr(((V)(228D)), ((V)(100D)), ((V)(40D)))).V);
Call(show_16, V.Undef, tray_220, (true ? V.True : V.False));
Call(lines_22, V.Undef, sp_219, t_248, Arr(Arr(((V)(1D)), ((V)(3.8)), ((V)("Caramel on the counter...")), ((V)("b"))), Arr(((V)(7.4)), ((V)(11D)), ((V)("Huh?! I was only napping!")), ((V)("p"))), Arr(((V)(11.4)), ((V)(15.4)), ((V)("Hmm... not him either.")), ((V)("b")))), NewObj(2).Put("b", Arr(((V)(118D)), ((V)(92D)))).Put("p", Arr(((V)(228D)), ((V)(52D)))).V);
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
Invoke(S_109, "push", NewObj(5).Put("a", ((V)(62D))).Put("b", ((V)(72D))).Put("rgb", ((V)("60,70,160"))).Put("lit", Fn((V _arrowThis261, int _argc254, V t_260, V _a257, V _a258, V _a259, V[] _rest255) => {
return ((V)(0.08));
}, 1, "lit", true)).Put("mk", Fn((V _self262, int _argc263, V L_269, V _a266, V _a267, V _a268, V[] _rest264) => {
V B_270 = default;
V b_271 = default;
V h_272 = default;
V sp_273 = default;
V eyes_274 = default;
if (_self262.IsNullish) _self262 = GlobalV;
B_270 = Call(bakery_39, V.Undef, L_269, ((V)(11D)));
b_271 = Call(boo_40, V.Undef, Get(B_270, "act"));
h_272 = Call(hoot_41, V.Undef, Get(B_270, "act"));
sp_273 = Call(bub_21, V.Undef, L_269);
eyes_274 = Call(D_10, V.Undef, L_269, ((V)("left:0;top:0;width:30px;height:10px;display:none;z-index:50;")), ((V)("<svg viewBox=\"0 0 30 10\" width=\"30\" height=\"10\"><ellipse cx=\"6\" cy=\"5\" rx=\"4.5\" ry=\"3.4\" fill=\"#f6ff8a\"></ellipse><ellipse cx=\"24\" cy=\"5\" rx=\"4.5\" ry=\"3.4\" fill=\"#f6ff8a\"></ellipse><circle cx=\"7\" cy=\"5\" r=\"1.6\" fill=\"#1a1040\"></circle><circle cx=\"25\" cy=\"5\" r=\"1.6\" fill=\"#1a1040\"></circle></svg>")));
return Fn((V _arrowThis282, int _argc275, V t_281, V _a278, V _a279, V _a280, V[] _rest276) => {
double sh_283 = 0;
V bs_284 = default;
V hs_285 = default;
V dk_286 = default;
double bl_287 = 0;
sh_283 = (GtN(t_281, 4D) ? (FdLibm.Sin((ToNum(t_281) * 50D)) * 1.5) : 0D);
bs_284 = Call(go_19, V.Undef, t_281, Arr(Arr(((V)(0D)), ((V)(120D)), ((V)(150D)), NewObj(1).Put("m", ((V)("float"))).V)), NewObj(2).Put("m", ((V)("float"))).Put("gy", ((V)(FY_32))).V);
if (Truthy(bs_284)) {
OpSet(bs_284, "x", 0, ((V)(sh_283)));
}
Invoke(b_271, "put", bs_284);
hs_285 = NewObj(3).Put("x", ((V)((214D + sh_283)))).Put("y", ((V)(FY_32))).Put("v", ((V)("front"))).V;
Invoke(h_272, "put", hs_285, ((V)((LtN(t_281, 1.4) ? (LtN(Invoke(G("Math"), "random"), 0.5) ? 1D : 0.2) : 0D))));
dk_286 = Call(P_11, V.Undef, t_281, ((V)(0.2)), ((V)(0.6)));
Invoke(B_270, "upd", t_281, NewObj(2).Put("dark", ((V)((0.55 + (0.4 * ToNum(dk_286)))))).Put("spot", (LtN(t_281, 1.4) ? Arr(((V)(233D)), ((V)(136D)), ((V)(40D))) : V.Null)).V);
bl_287 = (((ToNum(t_281) % 2.4) > 2.25) ? 0.15 : 1D);
if (GtN(t_281, 2.8)) {
Call(put_15, V.Undef, eyes_274, ((V)((168D + (FdLibm.Sin((ToNum(t_281) * 0.9)) * 26D)))), ((V)((128D + (FdLibm.Sin((ToNum(t_281) * 1.4)) * 4D)))), ((V)(1D)), ((V)(0D)), Call(P_11, V.Undef, t_281, ((V)(2.8)), ((V)(3.4))));
OpSet(Get(eyes_274, "style"), "transform", 0, ((V)(JsStrBuf.Begin().S(" scaleY(").N(bl_287).S(")").End())));
} else {
Call(show_16, V.Undef, eyes_274, (false ? V.True : V.False));
}
Call(lines_22, V.Undef, sp_273, t_281, Arr(Arr(((V)(1D)), ((V)(2.8)), ((V)("Uh-oh...")), ((V)("h"))), Arr(((V)(4.6)), ((V)(8.6)), ((V)("W-w-who\u2019s there?!")), ((V)("b")))), NewObj(2).Put("b", (bs_284 is var _t288 && !Truthy(_t288) ? _t288 : Arr(Get(bs_284, "x"), ((V)((ToNum(Get(bs_284, "y")) - 60D)))))).Put("h", Arr(((V)(214D)), ((V)(104D)))).V);
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
Invoke(S_109, "push", NewObj(5).Put("a", ((V)(72D))).Put("b", ((V)(86D))).Put("rgb", ((V)("150,160,255"))).Put("inF", (false ? V.True : V.False)).Put("mk", Fn((V _self289, int _argc290, V L_296, V _a293, V _a294, V _a295, V[] _rest291) => {
V B_297 = default;
V b_298 = default;
V h_299 = default;
V ch_300 = default;
V sp_301 = default;
V sp2_302 = default;
if (_self289.IsNullish) _self289 = GlobalV;
B_297 = Call(bakery_39, V.Undef, L_296, ((V)(13D)));
b_298 = Call(boo_40, V.Undef, Get(B_297, "act"));
h_299 = Call(hoot_41, V.Undef, Get(B_297, "act"));
ch_300 = Call(actor_17, V.Undef, Get(B_297, "act"), ((V)("chip")), ((V)(W_33)));
sp_301 = Call(bub_21, V.Undef, L_296);
sp2_302 = Call(parts_23, V.Undef, Get(B_297, "act"), ((V)(6D)), ((V)("width:7px;height:7px;z-index:8;")), ((V)("<svg viewBox=\"0 0 10 10\" width=\"7\" height=\"7\"><path d=\"M5 0 L6 4 L10 5 L6 6 L5 10 L4 6 L0 5 L4 4Z\" fill=\"#fff3b0\"></path></svg>")), Fn((V _arrowThis311, int _argc303, V i_309, V t_310, V _a307, V _a308, V[] _rest304) => {
double a_312 = 0;
a_312 = (((ToNum(t_310) * 0.8) + (ToNum(i_309) / 6D)) % 1D);
return (LtN(t_310, 9D) ? NewObj(5).Put("x", ((V)((160D + (FdLibm.Cos((ToNum(i_309) * 1.7)) * 18D))))).Put("y", ((V)((128D + (FdLibm.Sin((ToNum(i_309) * 2.3)) * 14D))))).Put("k", ((V)((FdLibm.Sin((System.Math.PI * a_312)) * 1.3)))).Put("r", ((V)((a_312 * 90D)))).Put("o", ((V)(1D))).V : V.Null);
return default;
}, 2, "", true));
return Fn((V _arrowThis320, int _argc313, V t_319, V _a316, V _a317, V _a318, V[] _rest314) => {
V cs_321 = default;
V bs_322 = default;
cs_321 = Call(go_19, V.Undef, t_319, Arr(Arr(((V)(0D)), ((V)(160D)), ((V)(172D)), NewObj(1).Put("m", ((V)("still"))).V), Arr(((V)(1D)), ((V)(160D)), ((V)(172D))), Arr(((V)(1.5)), ((V)(160D)), ((V)(FY_32)), NewObj(2).Put("m", ((V)("hop"))).Put("h", ((V)(10D))).V), Arr(((V)(2D)), ((V)(160D)), ((V)(FY_32)))), NewObj(2).Put("y", ((V)(FY_32))).Put("f", ((V)("front"))).V);
Call(pose_18, V.Undef, ch_300, cs_321);
Call(sp2_302, V.Undef, t_319);
bs_322 = Call(go_19, V.Undef, t_319, Arr(Arr(((V)(0D)), ((V)(112D)), ((V)(150D)), NewObj(1).Put("m", ((V)("float"))).V), Arr(((V)(10D)), ((V)(112D)), ((V)(150D))), Arr(((V)(12D)), ((V)(92D)), ((V)(150D)))), NewObj(2).Put("m", ((V)("float"))).Put("gy", ((V)(FY_32))).V);
Invoke(b_298, "put", bs_322, NewObj(1).Put("lens", (GtN(t_319, 10.4) ? Arr(((V)(80D)), ((V)(150D)), ((V)(40D))) : V.Null)).V);
Invoke(h_299, "put", NewObj(3).Put("x", ((V)(222D))).Put("y", ((V)((FY_32 - ((GtN(t_319, 6D) && LtN(t_319, 6.4)) ? (FdLibm.Sin((((ToNum(t_319) - 6D) * System.Math.PI) / 0.4)) * 8D) : 0D))))).Put("v", ((V)("front"))).V, ((V)(1D)));
Invoke(B_297, "upd", t_319, NewObj(2).Put("flash", ((V)((1D - ToNum(Call(P_11, V.Undef, t_319, ((V)(0D)), ((V)(0.5)))))))).Put("dark", ((V)(0.38))).V);
Call(lines_22, V.Undef, sp_301, t_319, Arr(Arr(((V)(2.2)), ((V)(5.6)), ((V)("Hi! It\u2019s just my chips!")), ((V)("c"))), Arr(((V)(6D)), ((V)(9.4)), ((V)("Phew!")), ((V)("h"))), Arr(((V)(10D)), ((V)(13.6)), ((V)("Wait... crumbs!")), ((V)("b")))), NewObj(3).Put("c", Arr(((V)(160D)), ((V)(104D)))).Put("h", Arr(((V)(222D)), ((V)(104D)))).Put("b", (bs_322 is var _t323 && !Truthy(_t323) ? _t323 : Arr(Get(bs_322, "x"), ((V)((ToNum(Get(bs_322, "y")) - 60D)))))).V);
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
Invoke(S_109, "push", NewObj(4).Put("a", ((V)(86D))).Put("b", ((V)(100D))).Put("rgb", ((V)("150,160,255"))).Put("mk", Fn((V _self324, int _argc325, V L_331, V _a328, V _a329, V _a330, V[] _rest326) => {
V B_332 = default;
V b_333 = default;
V h_334 = default;
V sp_335 = default;
V lamp_336 = default;
V cr_337 = default;
if (_self324.IsNullish) _self324 = GlobalV;
B_332 = Call(bakery_39, V.Undef, L_331, ((V)(15D)));
b_333 = Call(boo_40, V.Undef, Get(B_332, "act"));
h_334 = Call(hoot_41, V.Undef, Get(B_332, "act"));
sp_335 = Call(bub_21, V.Undef, L_331);
lamp_336 = Call(D_10, V.Undef, Get(B_332, "act"), ((V)("left:0;top:0;display:none;z-index:5;")), LAMP_37);
cr_337 = Array_from(NewObj(1).Put("length", ((V)(14D))).V, Fn((V _arrowThis346, int _argc338, V __344, V i_345, V _a342, V _a343, V[] _rest339) => {
return Call(D_10, V.Undef, Get(B_332, "act"), ((V)(JsStrBuf.Begin().S("left:").N(((60D + (ToNum(i_345) * 26D)) + ((ToNum(i_345) % 2D) * 5D))).S("px;top:").N((163D + ((ToNum(i_345) % 3D) * 2D))).S("px;width:3.5px;height:3px;border-radius:50%;background:#c98a4a;").End())));
}, 2, "", true));
return Fn((V _arrowThis354, int _argc347, V t_353, V _a350, V _a351, V _a352, V[] _rest348) => {
V px_355 = default;
V bs_356 = default;
V hs_357 = default;
double sh_358 = 0;
px_355 = Call(kf_13, V.Undef, t_353, Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(10D)), ((V)((-190D))))), Get(E_12, "io"));
bs_356 = Call(go_19, V.Undef, t_353, Arr(Arr(((V)(0D)), ((V)(70D)), ((V)(150D)), NewObj(1).Put("m", ((V)("float"))).V), Arr(((V)(10D)), ((V)(270D)), ((V)(150D)))), NewObj(2).Put("m", ((V)("float"))).Put("gy", ((V)(FY_32))).V);
if (Truthy(bs_356)) {
Set(bs_356, "v", ((V)("right")));
}
Invoke(b_333, "put", bs_356, NewObj(1).Put("lens", (Truthy(bs_356) ? Arr(Add(Get(bs_356, "x"), ((V)(26D))), ((V)(156D)), ((V)(30D))) : V.Null)).V);
hs_357 = Call(go_19, V.Undef, t_353, Arr(Arr(((V)(0D)), ((V)(30D))), Arr(((V)(10D)), ((V)(236D)))), NewObj(3).Put("y", ((V)(FY_32))).Put("m", ((V)("walk"))).Put("f", ((V)("right"))).V);
Invoke(h_334, "put", hs_357);
sh_358 = (GtN(t_353, 8D) ? ((FdLibm.Sin((ToNum(t_353) * 46D)) * 2.5) * (0.5 + (0.5 * FdLibm.Sin((ToNum(t_353) * 3D))))) : 0D);
Call(put_15, V.Undef, lamp_336, ((V)((420D + sh_358))), ((V)(152D)), ((V)(1.2)), ((V)((sh_358 * 2D))), ((V)(1D)));
Invoke(B_332, "upd", t_353, NewObj(3).Put("dark", ((V)(0.6))).Put("spot", (Truthy(hs_357) ? Arr(Add(Add(Get(hs_357, "x"), ((V)(19D))), px_355), ((V)((ToNum(Get(hs_357, "y")) - 24D))), ((V)(60D))) : V.Null)).Put("cam", Arr(px_355, ((V)(0D)), ((V)(1D)))).V);
Set(Get(Get(B_332, "cam"), "style"), "transformOrigin", ((V)("0 0")));
Call(lines_22, V.Undef, sp_335, t_353, Arr(Arr(((V)(3D)), ((V)(6.6)), ((V)("Follow the crumbs...")), ((V)("b"))), Arr(((V)(8.2)), ((V)(12D)), ((V)("It ends at... a lamp?")), ((V)("h")))), NewObj(2).Put("b", (bs_356 is var _t359 && !Truthy(_t359) ? _t359 : Arr(Add(Get(bs_356, "x"), px_355), ((V)((ToNum(Get(bs_356, "y")) - 60D)))))).Put("h", (hs_357 is var _t360 && !Truthy(_t360) ? _t360 : Arr(Add(Get(hs_357, "x"), px_355), ((V)((ToNum(Get(hs_357, "y")) - 54D)))))).V);
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
Invoke(S_109, "push", NewObj(5).Put("a", ((V)(100D))).Put("b", ((V)(110D))).Put("rgb", ((V)("190,140,255"))).Put("inF", (false ? V.True : V.False)).Put("mk", Fn((V _self361, int _argc362, V L_368, V _a365, V _a366, V _a367, V[] _rest363) => {
V B_369 = default;
V b_370 = default;
V h_371 = default;
V j_372 = default;
V sp_373 = default;
V lamp_374 = default;
V sm_375 = default;
V cb_376 = default;
if (_self361.IsNullish) _self361 = GlobalV;
B_369 = Call(bakery_39, V.Undef, L_368, ((V)(17D)));
b_370 = Call(boo_40, V.Undef, Get(B_369, "act"));
h_371 = Call(hoot_41, V.Undef, Get(B_369, "act"));
j_372 = Call(actor_17, V.Undef, Get(B_369, "act"), ((V)("jinni")), ((V)((W_33 + 6D))));
sp_373 = Call(bub_21, V.Undef, L_368);
lamp_374 = Call(D_10, V.Undef, Get(B_369, "act"), ((V)("left:0;top:0;z-index:5;")), LAMP_37);
sm_375 = Call(parts_23, V.Undef, Get(B_369, "act"), ((V)(16D)), ((V)("width:22px;height:22px;border-radius:50%;background:#b98aff;z-index:7;")), V.Null, Fn((V _arrowThis385, int _argc377, V i_383, V t_384, V _a381, V _a382, V[] _rest378) => {
V r_386 = default;
double a_387 = 0;
double d_388 = 0;
if (GtN(t_384, 2.4)) {
return V.Null;
}
r_386 = Call(rnd_29, V.Undef, Add(i_383, ((V)(40D))));
a_387 = ((ToNum(Call(r_386, V.Undef)) * System.Math.PI) * 2D);
d_388 = (ToNum(Call(P_11, V.Undef, t_384, ((V)(0D)), ((V)(1.4)))) * (14D + (ToNum(Call(r_386, V.Undef)) * 26D)));
return NewObj(4).Put("x", ((V)((208D + (FdLibm.Cos(a_387) * d_388))))).Put("y", ((V)(((120D + ((FdLibm.Sin(a_387) * d_388) * 0.7)) - (ToNum(t_384) * 8D))))).Put("k", ((V)((0.6 + (ToNum(t_384) * 0.7))))).Put("o", ((V)((0.85 * (1D - ToNum(Call(P_11, V.Undef, t_384, ((V)(1D)), ((V)(2.4)), Get(E_12, "lin")))))))).V;
return default;
}, 2, "", true));
cb_376 = Call(parts_23, V.Undef, Get(B_369, "act"), ((V)(3D)), ((V)("width:3px;height:3px;border-radius:50%;background:#c98a4a;z-index:9;")), V.Null, Fn((V _arrowThis398, int _argc389, V i_395, V t_396, V s_397, V _a394, V[] _rest390) => {
return V.Null;
}, 3, "", true));
return Fn((V _arrowThis406, int _argc399, V t_405, V _a402, V _a403, V _a404, V[] _rest400) => {
V js_407 = default;
Call(put_15, V.Undef, lamp_374, ((V)(230D)), ((V)(152D)), ((V)(1.2)), ((V)(0D)), ((V)(1D)));
js_407 = (GtN(t_405, 0.4) ? Call(go_19, V.Undef, t_405, Arr(Arr(((V)(0.4)), ((V)(210D)), ((V)(150D)), NewObj(1).Put("m", ((V)("float"))).V), Arr(((V)(1.2)), ((V)(210D)), ((V)(118D)))), NewObj(3).Put("m", ((V)("float"))).Put("gy", ((V)(150D))).Put("f", ((V)("front"))).V) : V.Null);
if (Truthy(js_407)) {
Set(js_407, "k", Call(P_11, V.Undef, t_405, ((V)(0.4)), ((V)(1D)), Get(E_12, "back")));
}
Call(pose_18, V.Undef, j_372, js_407);
Call(sm_375, V.Undef, t_405);
Invoke(b_370, "put", NewObj(5).Put("x", ((V)(80D))).Put("y", ((V)(((150D - (FdLibm.Sin((ToNum(t_405) * 2.4)) * 3D)) - (LtN(t_405, 1.2) ? (ToNum(Call(P_11, V.Undef, t_405, ((V)(0.2)), ((V)(0.5)))) * 10D) : 0D))))).Put("v", ((V)("front"))).Put("gy", ((V)(FY_32))).Put("r", ((V)(((GtN(t_405, 3D) && LtN(t_405, 5D)) ? (FdLibm.Sin((ToNum(t_405) * 14D)) * 5D) : 0D)))).V);
Invoke(h_371, "put", NewObj(3).Put("x", ((V)(46D))).Put("y", ((V)((FY_32 - ((GtN(t_405, 0.3) && LtN(t_405, 0.7)) ? 8D : 0D))))).Put("v", ((V)("front"))).V);
Invoke(B_369, "upd", t_405, NewObj(2).Put("flash", ((V)(((1D - ToNum(Call(P_11, V.Undef, t_405, ((V)(0D)), ((V)(0.4))))) * 0.6)))).Put("dark", ((V)(0.32))).V);
Call(lines_22, V.Undef, sp_373, t_405, Arr(Arr(((V)(2D)), ((V)(6D)), ((V)("Oops! I wished for a snack!")), ((V)("j"))), Arr(((V)(6.4)), ((V)(9.6)), ((V)("You?!")), ((V)("b")))), NewObj(2).Put("j", (js_407 is var _t408 && !Truthy(_t408) ? _t408 : Arr(Get(js_407, "x"), ((V)((ToNum(Get(js_407, "y")) - 66D)))))).Put("b", Arr(((V)(80D)), ((V)(92D)))).V);
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
Invoke(S_109, "push", NewObj(5).Put("a", ((V)(110D))).Put("b", ((V)(120D))).Put("rgb", ((V)("255,210,150"))).Put("outF", (false ? V.True : V.False)).Put("mk", Fn((V _self409, int _argc410, V L_416, V _a413, V _a414, V _a415, V[] _rest411) => {
V B_417 = default;
V sp_418 = default;
V pie_419 = default;
V b_420 = default;
V h_421 = default;
V cast_422 = default;
V j_423 = default;
V swirl_424 = default;
V end_425 = default;
if (_self409.IsNullish) _self409 = GlobalV;
B_417 = Call(bakery_39, V.Undef, L_416, ((V)(19D)));
sp_418 = Call(bub_21, V.Undef, L_416);
pie_419 = Call(D_10, V.Undef, Get(B_417, "act"), ((V)("left:0;top:0;display:none;z-index:4;")), PIE_38);
b_420 = Call(boo_40, V.Undef, Get(B_417, "act"));
h_421 = Call(hoot_41, V.Undef, Get(B_417, "act"));
cast_422 = Invoke(Arr(((V)("mochi")), ((V)("puddi")), ((V)("chip"))), "map", Fn((V _arrowThis433, int _argc426, V k_432, V _a429, V _a430, V _a431, V[] _rest427) => {
return Call(actor_17, V.Undef, Get(B_417, "act"), k_432, ((V)((W_33 - 8D))));
}, 1, "", true));
j_423 = Call(actor_17, V.Undef, Get(B_417, "act"), ((V)("jinni")), ((V)(W_33)));
swirl_424 = Call(parts_23, V.Undef, Get(B_417, "act"), ((V)(12D)), ((V)("width:8px;height:8px;z-index:9;")), ((V)("<svg viewBox=\"0 0 10 10\" width=\"8\" height=\"8\"><path d=\"M5 0 L6 4 L10 5 L6 6 L5 10 L4 6 L0 5 L4 4Z\" fill=\"#fff3b0\"></path></svg>")), Fn((V _arrowThis442, int _argc434, V i_440, V t_441, V _a438, V _a439, V[] _rest435) => {
double a_443 = 0;
double r_444 = 0;
if (GtN(t_441, 3.5)) {
return V.Null;
}
a_443 = ((ToNum(t_441) * 5D) + (ToNum(i_440) * 0.52));
r_444 = (40D * (1D - ToNum(Call(P_11, V.Undef, t_441, ((V)(0D)), ((V)(3D))))));
return NewObj(5).Put("x", ((V)((160D + (FdLibm.Cos(a_443) * r_444))))).Put("y", ((V)((104D + ((FdLibm.Sin(a_443) * r_444) * 0.5))))).Put("k", ((V)(1D))).Put("r", ((V)((a_443 * 50D)))).Put("o", ((V)((1D - ToNum(Call(P_11, V.Undef, t_441, ((V)(2.6)), ((V)(3.5)))))))).V;
return default;
}, 2, "", true));
end_425 = Call(D_10, V.Undef, L_416, ((V)("left:0;top:16px;width:320px;text-align:center;font-family:'Creepster',cursive;font-size:22px;color:#c8f08a;text-shadow:0 2px 0 #1a1040;z-index:60;")), ((V)("THE END")));
return Fn((V _arrowThis452, int _argc445, V t_451, V _a448, V _a449, V _a450, V[] _rest446) => {
V pk_453 = default;
double tip_454 = 0;
pk_453 = Call(P_11, V.Undef, t_451, ((V)(1.4)), ((V)(2.2)), Get(E_12, "back"));
Call(put_15, V.Undef, pie_419, ((V)(160D)), ((V)(108D)), ((V)((1.05 * ToNum(pk_453)))), ((V)(0D)), ((V)((GtN(pk_453, 0.01) ? 1D : 0D))));
Call(swirl_424, V.Undef, t_451);
tip_454 = ((GtN(t_451, 6D) && LtN(t_451, 9D)) ? (8D * FdLibm.Sin((System.Math.PI * ToNum(Call(P_11, V.Undef, t_451, ((V)(6D)), ((V)(9D)), Get(E_12, "lin")))))) : 0D);
Invoke(b_420, "put", NewObj(2).Spread(Call(dance_20, V.Undef, t_451, ((V)(60D)), ((V)(150D)), ((V)("bounce")), ((V)(0.5)), ((V)(0.2)))).Put("gy", ((V)(FY_32))).V, NewObj(1).Put("tip", ((V)(tip_454))).V);
Invoke(h_421, "put", NewObj(1).Spread(Call(dance_20, V.Undef, t_451, ((V)(280D)), ((V)(FY_32)), ((V)("bounce")), ((V)(0.5)), ((V)(0.5)))).V);
Invoke(cast_422, "forEach", Fn((V _arrowThis463, int _argc455, V n_461, V i_462, V _a459, V _a460, V[] _rest456) => {
return Call(pose_18, V.Undef, n_461, Call(dance_20, V.Undef, t_451, GetK(Arr(((V)(96D)), ((V)(128D)), ((V)(200D))), i_462), ((V)((FY_32 + 4D))), ((V)((SEqN(i_462, 1D) ? "sway" : "bounce"))), ((V)(0.5)), ((V)((ToNum(i_462) * 0.3)))));
}, 2, "", true));
Call(pose_18, V.Undef, j_423, NewObj(4).Put("x", ((V)(240D))).Put("y", ((V)((140D + (FdLibm.Sin((ToNum(t_451) * 2.4)) * 3D))))).Put("v", ((V)("front"))).Put("gy", ((V)((FY_32 + 4D)))).V);
Invoke(B_417, "upd", t_451, NewObj(1).Put("dark", ((V)(0.2))).V);
Set(Get(end_425, "style"), "opacity", Invoke(Call(P_11, V.Undef, t_451, ((V)(8D)), ((V)(8.8))), "toFixed", ((V)(3D))));
Call(lines_22, V.Undef, sp_418, t_451, Arr(Arr(((V)(2.4)), ((V)(5.6)), ((V)("A new Moon Pie for everyone!")), ((V)("j"))), Arr(((V)(6D)), ((V)(9.2)), ((V)("Case closed!")), ((V)("b")))), NewObj(2).Put("j", Arr(((V)(240D)), ((V)(76D)))).Put("b", Arr(((V)(60D)), ((V)(90D)))).V);
return default;
}, 1, "", true);
return default;
}, 1, "mk", false)).V);
return Call(film_27, V.Undef, S_109, NewObj(1).Put("rgb", ((V)("120,140,255"))).V);
return default;
}, 0, "mk", false);
score_43 = Fn((V _self464, int _argc465, V Q_471, V _a468, V _a469, V _a470, V[] _rest466) => {
V I_472 = default;
double B_473 = 0;
V WALK_474 = default;
V walk_475 = default;
if (_self464.IsNullish) _self464 = GlobalV;
I_472 = Call(snd_28, V.Undef, Q_471);
B_473 = 0.5;
Invoke(I_472, "thunder", ((V)(0.1)), ((V)(0.25)));
Invoke(I_472, "pad", ((V)(0D)), Arr(((V)(38D)), ((V)(45D)), ((V)(50D))), ((V)(7D)), ((V)(0.025)), ((V)("sawtooth")), ((V)(500D)));
Invoke(I_472, "theremin", ((V)(1D)), ((V)(440D)), ((V)(660D)), ((V)(2.4)));
Invoke(I_472, "theremin", ((V)(3.6)), ((V)(620D)), ((V)(415D)), ((V)(2.6)));
Invoke(I_472, "thunder", ((V)(8.5)));
Invoke(I_472, "thunder", ((V)(11.2)), ((V)(0.3)));
Invoke(I_472, "pad", ((V)(7D)), Arr(((V)(37D)), ((V)(44D)), ((V)(49D))), ((V)(7D)), ((V)(0.025)), ((V)("sawtooth")), ((V)(500D)));
Invoke(I_472, "theremin", ((V)(9.2)), ((V)(330D)), ((V)(523D)), ((V)(3.2)), ((V)(0.07)));
WALK_474 = Arr(((V)(50D)), ((V)(53D)), ((V)(57D)), ((V)(56D)), ((V)(55D)), ((V)(53D)), ((V)(52D)), ((V)(49D)), ((V)(50D)), ((V)(57D)), ((V)(53D)), ((V)(50D)), ((V)(45D)), ((V)(48D)), ((V)(49D)), ((V)(52D)));
walk_475 = Fn((V _arrowThis488, int _argc476, V t0_482, V t1_483, V _a480, V _a481, V[] _rest477) => {
V up_485 = default;
V v_487 = default;
{ V _t484 = _a480; if (_t484.IsUndef) _t484 = ((V)(0D));
up_485 = _t484; }
{ V _t486 = _a481; if (_t486.IsUndef) _t486 = ((V)(0.09));
v_487 = _t486; }
return Invoke(I_472, "beat", t0_482, t1_483, ((V)(B_473)), Fn((V _arrowThis497, int _argc489, V t_495, V i_496, V _a493, V _a494, V[] _rest490) => {
Invoke(I_472, "pluck", t_495, Add(((V)((ToNum(GetIdx(WALK_474, (ToNum(i_496) % 16D))) - 12D))), up_485), ((V)(0.22)), v_487);
if (NumTruthy((ToNum(i_496) % 2D))) {
Invoke(I_472, "hat", Add(t_495, ((V)((B_473 / 2D)))), ((V)(0.025)));
}
if (((ToNum(i_496) % 8D) == 0D)) {
Invoke(I_472, "pad", t_495, Arr(Add(((V)(62D)), up_485), Add(((V)(65D)), up_485), Add(((V)(69D)), up_485)), ((V)((B_473 * 8D))), ((V)(0.012)), ((V)("triangle")), ((V)(1200D)));
}
return default;
}, 2, "", true));
}, 4, "", true);
Call(walk_475, V.Undef, ((V)(14D)), ((V)(36D)));
Invoke(I_472, "bell", ((V)(16.5)), ((V)(86D)), ((V)(1D)), ((V)(0.04)));
Invoke(I_472, "bell", ((V)(16.8)), ((V)(81D)), ((V)(1D)), ((V)(0.04)));
Invoke(I_472, "hoot", ((V)(20.2)));
Invoke(I_472, "sneeze", ((V)(34.4)));
Invoke(I_472, "poof", ((V)(36.2)), ((V)(0.25)));
Invoke(I_472, "boing", ((V)(36.7)));
Call(walk_475, V.Undef, ((V)(37D)), ((V)(62D)));
Invoke(I_472, "chirp", ((V)(53.1)), ((V)(0.06)));
Invoke(I_472, "boing", ((V)(53D)), ((V)(0.08)));
Invoke(I_472, "tone", ((V)(62.2)), ((V)(240D)), ((V)(0.4)), NewObj(4).Put("to", ((V)(60D))).Put("slide", ((V)(0.35))).Put("vol", ((V)(0.12))).Put("type", ((V)("triangle"))).V);
Invoke(I_472, "pad", ((V)(62.4)), Arr(((V)(34D)), ((V)(41D))), ((V)(9.5)), ((V)(0.03)), ((V)("sawtooth")), ((V)(300D)));
Invoke(I_472, "beat", ((V)(63D)), ((V)(72D)), ((V)(0.75)), Fn((V _arrowThis506, int _argc498, V t_504, V i_505, V _a502, V _a503, V[] _rest499) => {
Invoke(I_472, "kick", t_504, ((V)(0.25)));
Invoke(I_472, "kick", Add(t_504, ((V)(0.18))), ((V)(0.18)));
return default;
}, 2, "", true));
Invoke(I_472, "theremin", ((V)(65D)), ((V)(300D)), ((V)(390D)), ((V)(2.5)), ((V)(0.06)));
Invoke(I_472, "theremin", ((V)(67.6)), ((V)(390D)), ((V)(280D)), ((V)(3.4)), ((V)(0.06)));
Invoke(I_472, "tone", ((V)(72D)), ((V)(400D)), ((V)(0.2)), NewObj(3).Put("to", ((V)(1200D))).Put("slide", ((V)(0.15))).Put("vol", ((V)(0.06))).V);
Invoke(I_472, "sparkle", ((V)(72.1)), ((V)(79D)));
Invoke(I_472, "pluck", ((V)(74.2)), ((V)(72D)), ((V)(0.2)));
Invoke(I_472, "pluck", ((V)(74.4)), ((V)(76D)), ((V)(0.2)));
Invoke(I_472, "pluck", ((V)(74.6)), ((V)(79D)), ((V)(0.3)));
Call(walk_475, V.Undef, ((V)(76D)), ((V)(86D)), ((V)(5D)), ((V)(0.08)));
Invoke(I_472, "beat", ((V)(86D)), ((V)(100D)), ((V)(B_473)), Fn((V _arrowThis515, int _argc507, V t_513, V i_514, V _a511, V _a512, V[] _rest508) => {
Invoke(I_472, "pluck", t_513, ((V)((ToNum(GetIdx(WALK_474, (ToNum(i_514) % 16D))) - 7D))), ((V)(0.2)), ((V)(0.08)));
if (NumTruthy((ToNum(i_514) % 2D))) {
Invoke(I_472, "hat", Add(t_513, ((V)((B_473 / 2D)))), ((V)(0.02)));
}
return default;
}, 2, "", true));
Invoke(I_472, "theremin", ((V)(88D)), ((V)(392D)), ((V)(466D)), ((V)(3D)), ((V)(0.05)));
Invoke(I_472, "beat", ((V)(94D)), ((V)(100D)), ((V)(0.07)), Fn((V _arrowThis524, int _argc516, V t_522, V i_523, V _a520, V _a521, V[] _rest517) => {
return Invoke(I_472, "noise", t_522, ((V)(0.03)), NewObj(4).Put("ft", ((V)("bandpass"))).Put("f", ((V)(2600D))).Put("q", ((V)(2D))).Put("vol", ((V)((0.02 + (0.02 * ((ToNum(t_522) - 94D) / 6D)))))).V);
}, 2, "", true));
Invoke(I_472, "poof", ((V)(100.3)), ((V)(0.3)));
Invoke(I_472, "crash", ((V)(100.3)), ((V)(0.08)));
Invoke(Arr(((V)(72D)), ((V)(76D)), ((V)(79D)), ((V)(83D)), ((V)(86D)), ((V)(91D))), "forEach", Fn((V _arrowThis533, int _argc525, V m_531, V k_532, V _a529, V _a530, V[] _rest526) => {
return Invoke(I_472, "bell", ((V)((100.5 + (ToNum(k_532) * 0.07)))), m_531, ((V)(0.7)), ((V)(0.05)));
}, 2, "", true));
Invoke(I_472, "pluck", ((V)(102D)), ((V)(64D)), ((V)(0.2)));
Invoke(I_472, "pluck", ((V)(102.25)), ((V)(67D)), ((V)(0.2)));
Invoke(I_472, "pluck", ((V)(102.5)), ((V)(71D)), ((V)(0.4)));
Invoke(I_472, "timp", ((V)(106.4)), ((V)(0.3)));
Invoke(I_472, "brass", ((V)(106.4)), ((V)(57D)), ((V)(1.2)), ((V)(0.04)));
Invoke(I_472, "sparkle", ((V)(110.4)), ((V)(79D)));
Invoke(I_472, "sparkle", ((V)(111.2)), ((V)(84D)));
Invoke(I_472, "crash", ((V)(111.4)), ((V)(0.1)));
Invoke(I_472, "beat", ((V)(111.4)), ((V)(119.4)), ((V)(B_473)), Fn((V _arrowThis542, int _argc534, V t_540, V i_541, V _a538, V _a539, V[] _rest535) => {
if (((ToNum(i_541) % 2D) == 0D)) {
Invoke(I_472, "kick", t_540, ((V)(0.4)));
} else {
Invoke(I_472, "snare", t_540, ((V)(0.12)));
}
Invoke(I_472, "hat", Add(t_540, ((V)((B_473 / 2D)))), ((V)(0.03)));
Invoke(I_472, "bass", t_540, ((V)((ToNum(GetIdx(Arr(((V)(50D)), ((V)(50D)), ((V)(55D)), ((V)(55D)), ((V)(57D)), ((V)(57D)), ((V)(50D)), ((V)(50D))), (ToNum(i_541) % 8D))) - 12D))));
if (((ToNum(i_541) % 4D) == 0D)) {
V c_543 = default;
c_543 = GetIdx(Arr(Arr(((V)(62D)), ((V)(66D)), ((V)(69D))), Arr(((V)(67D)), ((V)(71D)), ((V)(74D))), Arr(((V)(69D)), ((V)(73D)), ((V)(76D))), Arr(((V)(62D)), ((V)(66D)), ((V)(69D)))), ((ToNum(i_541) / 4D) % 4D));
Invoke(c_543, "forEach", Fn((V _arrowThis551, int _argc544, V m_550, V _a547, V _a548, V _a549, V[] _rest545) => {
return Invoke(I_472, "brass", t_540, m_550, ((V)((B_473 * 3.6))), ((V)(0.025)));
}, 1, "", true));
}
return default;
}, 2, "", true));
Invoke(Arr(((V)(74D)), ((V)(78D)), ((V)(81D)), ((V)(86D))), "forEach", Fn((V _arrowThis560, int _argc552, V m_558, V k_559, V _a556, V _a557, V[] _rest553) => {
return Invoke(I_472, "lead", ((V)((111.4 + (ToNum(k_559) * 2D)))), m_558, ((V)(1.6)), ((V)(0.04)));
}, 2, "", true));
Invoke(I_472, "crash", ((V)(119.4)), ((V)(0.12)));
Invoke(I_472, "brass", ((V)(119.4)), ((V)(62D)), ((V)(0.6)), ((V)(0.05)));
return default;
}, 1, "score", false);
SM_8 = Get(G("window"), "SquadMovies");
K_9 = Get(G("window"), "MK");
if (((!(Truthy(SM_8)) || !(Truthy(K_9))) || !(Truthy(Get(SM_8, "def"))))) {
return default;
}
{ V _t561 = K_9;
if (_t561.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t561));
{ V _t562 = Get(_t561, "D");
D_10 = _t562; }
{ V _t563 = Get(_t561, "P");
P_11 = _t563; }
{ V _t564 = Get(_t561, "E");
E_12 = _t564; }
{ V _t565 = Get(_t561, "kf");
kf_13 = _t565; }
{ V _t566 = Get(_t561, "win");
win_14 = _t566; }
{ V _t567 = Get(_t561, "put");
put_15 = _t567; }
{ V _t568 = Get(_t561, "show");
show_16 = _t568; }
{ V _t569 = Get(_t561, "actor");
actor_17 = _t569; }
{ V _t570 = Get(_t561, "pose");
pose_18 = _t570; }
{ V _t571 = Get(_t561, "go");
go_19 = _t571; }
{ V _t572 = Get(_t561, "dance");
dance_20 = _t572; }
{ V _t573 = Get(_t561, "bub");
bub_21 = _t573; }
{ V _t574 = Get(_t561, "lines");
lines_22 = _t574; }
{ V _t575 = Get(_t561, "parts");
parts_23 = _t575; }
{ V _t576 = Get(_t561, "rain");
rain_24 = _t576; }
{ V _t577 = Get(_t561, "lightning");
lightning_25 = _t577; }
{ V _t578 = Get(_t561, "glow");
glow_26 = _t578; }
{ V _t579 = Get(_t561, "film");
film_27 = _t579; }
{ V _t580 = Get(_t561, "snd");
snd_28 = _t580; }
{ V _t581 = Get(_t561, "rnd");
rnd_29 = _t581; }
{ V _t582 = Get(_t561, "cl");
cl_30 = _t582; }
{ V _t583 = Get(_t561, "lerp");
lerp_31 = _t583; } }
FY_32 = 160D;
W_33 = 58D;
HAT_34 = ((V)("<svg viewBox=\"0 0 30 14\" width=\"30\" height=\"14\"><path d=\"M3 11 Q15 15 27 11 L27 12.6 Q15 16.6 3 12.6Z\" fill=\"#3a2a22\"></path><path d=\"M8 11 L9.5 3 Q15 0 20.5 3 L22 11Z\" fill=\"#5a4030\"></path><path d=\"M8.6 8.4 L21.4 8.4 L21.8 10.6 L8.2 10.6Z\" fill=\"#2a1a12\"></path><path d=\"M12 3.5 Q15 5 18 3.5\" stroke=\"#3a2a22\" stroke-width=\"1\" fill=\"none\"></path></svg>"));
LENS_35 = ((V)("<svg viewBox=\"0 0 30 30\" width=\"30\" height=\"30\"><path d=\"M19 19 L28 28\" stroke=\"#6a4a2a\" stroke-width=\"4\" stroke-linecap=\"round\"></path><circle cx=\"12\" cy=\"12\" r=\"9\" fill=\"rgba(200,230,255,0.35)\" stroke=\"#c9a24a\" stroke-width=\"3\"></circle><path d=\"M7 9 Q9 6 12 6\" stroke=\"#ffffff\" stroke-width=\"1.5\" fill=\"none\" opacity=\"0.8\"></path></svg>"));
LANT_36 = ((V)("<svg viewBox=\"0 0 16 22\" width=\"16\" height=\"22\"><path d=\"M5 3 Q8 0 11 3\" stroke=\"#3a2a22\" stroke-width=\"1.4\" fill=\"none\"></path><rect x=\"3\" y=\"4\" width=\"10\" height=\"3\" rx=\"1\" fill=\"#5a4030\"></rect><rect x=\"4\" y=\"7\" width=\"8\" height=\"10\" rx=\"2\" fill=\"#ffe28a\" stroke=\"#5a4030\" stroke-width=\"1.2\"></rect><rect x=\"3\" y=\"17\" width=\"10\" height=\"3\" rx=\"1\" fill=\"#5a4030\"></rect></svg>"));
LAMP_37 = ((V)("<svg viewBox=\"0 0 60 30\" width=\"60\" height=\"30\"><path d=\"M8 18 Q4 10 12 10 L40 10 Q50 10 58 4 Q54 14 46 18 Q46 26 30 27 Q14 26 14 20Z\" fill=\"#e2b14a\" stroke=\"#7a5414\" stroke-width=\"1.4\"></path><ellipse cx=\"27\" cy=\"10\" rx=\"10\" ry=\"3\" fill=\"#f6d36a\" stroke=\"#7a5414\" stroke-width=\"1.2\"></ellipse><circle cx=\"27\" cy=\"6\" r=\"2.6\" fill=\"#f6d36a\" stroke=\"#7a5414\" stroke-width=\"1\"></circle><path d=\"M8 18 Q2 18 3 13 Q4 10 9 12\" fill=\"none\" stroke=\"#7a5414\" stroke-width=\"2\"></path><path d=\"M18 18 Q28 22 40 17\" stroke=\"#fff3c0\" stroke-width=\"1.6\" fill=\"none\" opacity=\"0.8\"></path></svg>"));
PIE_38 = ((V)("<svg viewBox=\"0 0 80 40\" width=\"80\" height=\"40\"><ellipse cx=\"40\" cy=\"30\" rx=\"38\" ry=\"9\" fill=\"#c98a4a\"></ellipse><path d=\"M2 30 L2 22 Q40 4 78 22 L78 30 Q40 40 2 30Z\" fill=\"#b8763a\"></path><ellipse cx=\"40\" cy=\"21\" rx=\"36\" ry=\"12\" fill=\"#5a3420\"></ellipse><path d=\"M34 12 A10 10 0 1 0 50 26 A8 8 0 1 1 34 12Z\" fill=\"#fff2b8\"></path><circle cx=\"22\" cy=\"20\" r=\"1.6\" fill=\"#ffffff\" opacity=\"0.8\"></circle><circle cx=\"58\" cy=\"17\" r=\"1.3\" fill=\"#ffffff\" opacity=\"0.8\"></circle><circle cx=\"27\" cy=\"26\" r=\"1\" fill=\"#ffffff\" opacity=\"0.8\"></circle></svg>"));
boo_40 = Fn((V _arrowThis591, int _argc584, V p_590, V _a587, V _a588, V _a589, V[] _rest585) => {
V a_592 = default;
V h_593 = default;
V g_594 = default;
a_592 = Call(actor_17, V.Undef, p_590, ((V)("boo")), ((V)(W_33)));
h_593 = Call(D_10, V.Undef, p_590, ((V)("left:0;top:0;display:none;z-index:6;")), HAT_34);
g_594 = Call(D_10, V.Undef, p_590, ((V)("left:0;top:0;display:none;z-index:6;")), LENS_35);
return NewObj(2).Put("a", a_592).Put("put", Fn((V _self595, int _argc596, V s_602, V _a599, V _a600, V _a601, V[] _rest597) => {
V o_604 = default;
if (_self595.IsNullish) _self595 = GlobalV;
{ V _t603 = _a599; if (_t603.IsUndef) _t603 = NewObj(0).V;
o_604 = _t603; }
Call(pose_18, V.Undef, a_592, s_602);
if (!(Truthy(s_602))) {
Call(show_16, V.Undef, h_593, (false ? V.True : V.False));
Call(show_16, V.Undef, g_594, (false ? V.True : V.False));
return default;
}
Call(put_15, V.Undef, h_593, Add(Add(Get(s_602, "x"), ((V)(1D))), ((V)((ToNum((Get(s_602, "r") is var _t605 && Truthy(_t605) ? _t605 : ((V)(0D)))) * 0.5)))), ((V)(((ToNum(Get(s_602, "y")) - (W_33 * 0.86)) - ToNum((Get(o_604, "tip") is var _t606 && Truthy(_t606) ? _t606 : ((V)(0D))))))), ((V)(1D)), Add((Get(s_602, "r") is var _t607 && Truthy(_t607) ? _t607 : ((V)(0D))), ((V)((Truthy(Get(o_604, "tip")) ? (-14D) : (-6D))))), ((V)(1D)));
if (Truthy(Get(o_604, "lens"))) {
Call(put_15, V.Undef, g_594, GetIdx(Get(o_604, "lens"), 0D), GetIdx(Get(o_604, "lens"), 1D), ((V)(1D)), (GetIdx(Get(o_604, "lens"), 2D) is var _t608 && Truthy(_t608) ? _t608 : ((V)(0D))), ((V)(1D)));
} else {
Call(show_16, V.Undef, g_594, (false ? V.True : V.False));
}
return default;
}, 2, "put", false)).V;
return default;
}, 1, "", true);
hoot_41 = Fn((V _arrowThis616, int _argc609, V p_615, V _a612, V _a613, V _a614, V[] _rest610) => {
V a_617 = default;
V l_618 = default;
V gl_619 = default;
a_617 = Call(actor_17, V.Undef, p_615, ((V)("hoot")), ((V)((W_33 - 4D))));
l_618 = Call(D_10, V.Undef, p_615, ((V)("left:0;top:0;display:none;z-index:6;")), LANT_36);
gl_619 = Call(glow_26, V.Undef, p_615, ((V)("rgba(255,226,140,0.55)")), ((V)(40D)), ((V)("z-index:2;")));
return NewObj(2).Put("a", a_617).Put("put", Fn((V _self620, int _argc621, V s_627, V _a624, V _a625, V _a626, V[] _rest622) => {
V x_630 = default;
double y_631 = 0;
V on_629 = default;
if (_self620.IsNullish) _self620 = GlobalV;
{ V _t628 = _a624; if (_t628.IsUndef) _t628 = ((V)(1D));
on_629 = _t628; }
Call(pose_18, V.Undef, a_617, s_627);
if (!(Truthy(s_627))) {
Call(show_16, V.Undef, l_618, (false ? V.True : V.False));
Call(show_16, V.Undef, gl_619, (false ? V.True : V.False));
return default;
}
x_630 = Add(Get(s_627, "x"), ((V)(19D)));
y_631 = ((ToNum(Get(s_627, "y")) - 24D) + (FdLibm.Sin(ToNum((Get(s_627, "r") is var _t632 && Truthy(_t632) ? _t632 : ((V)(0D))))) * 2D));
Call(put_15, V.Undef, l_618, x_630, ((V)(y_631)), ((V)(1D)), ((V)((FdLibm.Sin((ToNum(Invoke(G("Date"), "now")) / 300D)) * 4D))), ((V)(1D)));
Call(put_15, V.Undef, gl_619, x_630, ((V)(y_631)), ((V)(1D)), ((V)(0D)), on_629);
return default;
}, 2, "put", false)).V;
return default;
}, 1, "", true);
Invoke(SM_8, "def", ((V)("moonpie")), NewObj(4).Put("mk", mk_42).Put("score", score_43).Put("beat", Fn((V _arrowThis640, int _argc633, V t_639, V _a636, V _a637, V _a638, V[] _rest634) => {
V on_641 = default;
double x_642 = 0;
on_641 = ((((GeN(t_639, 14D) && LtN(t_639, 62D)) || (GeN(t_639, 76D) && LtN(t_639, 100D))) || (GeN(t_639, 111.4) && LtN(t_639, 119.4))) ? V.True : V.False);
if (!(Truthy(on_641))) {
return V.Null;
}
x_642 = (ToNum(t_639) / 0.5);
return NewObj(3).Put("n", ((V)(System.Math.Floor(x_642)))).Put("ph", ((V)((x_642 - System.Math.Floor(x_642))))).Put("amp", ((V)(0.6))).V;
return default;
}, 1, "beat", true)).Put("cues", Arr(Arr(((V)(9D)), ((V)("gasp"))), Arr(((V)(36.6)), ((V)("laugh"))), Arr(((V)(54D)), ((V)("laugh"))), Arr(((V)(66D)), ((V)("hide"))), Arr(((V)(74.5)), ((V)("laugh"))), Arr(((V)(95D)), ((V)("hide"))), Arr(((V)(100.6)), ((V)("gasp"))), Arr(((V)(103D)), ((V)("laugh"))), Arr(((V)(112.5)), ((V)("cheer"))), Arr(((V)(117D)), ((V)("cheer"))))).V);
return default;
}, 0, "", false), V.Undef);
        }
    }
}
