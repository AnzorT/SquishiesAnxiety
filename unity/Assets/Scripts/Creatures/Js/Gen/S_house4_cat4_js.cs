// house4-cat4.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_house4_cat4_js
    {

        public static void Run()
        {
Call(Named(boot_60 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V X_8 = default;
V K_9 = default;
V solid_10 = default;
V box_11 = default;
V cyl_12 = default;
V ball_13 = default;
V slab_14 = default;
V slabX_15 = default;
V arcW_16 = default;
V disc_17 = default;
V prism_18 = default;
V prismZ_19 = default;
V legs4_20 = default;
V shade_21 = default;
V mix_22 = default;
V NE_23 = default;
double PI_24 = 0;
V GOLD_25 = default;
V CH_26 = default;
V CR_27 = default;
V WH_28 = default;
V DK_29 = default;
V INK_30 = default;
V LEAF_31 = default;
V BARK_32 = default;
V em_33 = default;
V neon_34 = default;
V ring_35 = default;
V flame_36 = default;
V A4_37 = default;
V SIGNS_38 = default;
V L_39 = default;
V Dn_40 = default;
V Y_41 = default;
V NEW_42 = default;
V WT_43 = default;
V BK_44 = default;
V rescale_45 = default;
V ramp_46 = default;
V TBF_47 = default;
V topBase_48 = default;
V ELEC_49 = default;
V FLOORA_50 = default;
V GAMES_51 = default;
V GARDEN_52 = default;
V YGLOW_53 = default;
V IN_54 = default;
V OUT_55 = default;
if (_self1.IsNullish) _self1 = GlobalV;
X_8 = Get(G("window"), "House3D");
if (!(Truthy(((((X_8 is var _t56 && !Truthy(_t56) ? _t56 : Get(X_8, "EXT")) is var _t57 && !Truthy(_t57) ? _t57 : Get(X_8, "shell")) is var _t58 && !Truthy(_t58) ? _t58 : Get(X_8, "SPEC")) is var _t59 && !Truthy(_t59) ? _t59 : Get(X_8, "ITEMS"))))) {
Call(G("setTimeout"), V.Undef, boot_60.v, ((V)(20D)));
return default;
}
if (Truthy(Get(X_8, "EXT2"))) {
return default;
}
K_9 = Get(X_8, "K");
{ V _t61 = K_9;
if (_t61.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t61));
{ V _t62 = Get(_t61, "solid");
solid_10 = _t62; }
{ V _t63 = Get(_t61, "box");
box_11 = _t63; }
{ V _t64 = Get(_t61, "cyl");
cyl_12 = _t64; }
{ V _t65 = Get(_t61, "ball");
ball_13 = _t65; }
{ V _t66 = Get(_t61, "slab");
slab_14 = _t66; }
{ V _t67 = Get(_t61, "slabX");
slabX_15 = _t67; }
{ V _t68 = Get(_t61, "arcW");
arcW_16 = _t68; }
{ V _t69 = Get(_t61, "disc");
disc_17 = _t69; }
{ V _t70 = Get(_t61, "prism");
prism_18 = _t70; }
{ V _t71 = Get(_t61, "prismZ");
prismZ_19 = _t71; }
{ V _t72 = Get(_t61, "legs4");
legs4_20 = _t72; }
{ V _t73 = Get(_t61, "shade");
shade_21 = _t73; }
{ V _t74 = Get(_t61, "mix");
mix_22 = _t74; } }
NE_23 = Get(K_9, "NEON");
PI_24 = System.Math.PI;
GOLD_25 = ((V)("#e2b14a"));
CH_26 = ((V)("#d5dde2"));
CR_27 = ((V)("#fffaf1"));
WH_28 = ((V)("#ffffff"));
DK_29 = ((V)("#36373c"));
INK_30 = ((V)("#3a2a20"));
LEAF_31 = ((V)("#5fa84a"));
BARK_32 = ((V)("#8a5a34"));
em_33 = Fn((V _arrowThis82, int _argc75, V o_81, V _a78, V _a79, V _a80, V[] _rest76) => {
return Object_assign(NewObj(2).Put("emit", ((V)(1D))).Put("noOut", ((V)(1D))).V, (o_81 is var _t83 && Truthy(_t83) ? _t83 : NewObj(0).V));
}, 1, "", true);
neon_34 = NewObj(3).Put("y", ((V)(60D))).Put("r", ((V)(90D))).Put("c", ((V)("url(#gNeon)"))).V;
ring_35 = Fn((V _arrowThis98, int _argc84, V x_90, V y_91, V z_92, V r_93, V[] _rest85) => {
V t_94 = default;
V h_95 = default;
V col_96 = default;
V o_97 = default;
t_94 = (_argc84 > 4 ? _rest85[0] : V.Undef);
h_95 = (_argc84 > 5 ? _rest85[1] : V.Undef);
col_96 = (_argc84 > 6 ? _rest85[2] : V.Undef);
o_97 = (_argc84 > 7 ? _rest85[3] : V.Undef);
return Call(arcW_16, V.Undef, x_90, y_91, z_92, r_93, r_93, t_94, h_95, ((V)(0D)), ((V)((PI_24 * 2D))), col_96, Object_assign(NewObj(1).Put("n", ((V)(14D))).V, (o_97 is var _t99 && Truthy(_t99) ? _t99 : NewObj(0).V)));
}, 8, "", true);
flame_36 = Fn((V _arrowThis110, int _argc100, V x_106, V y_107, V z_108, V s_109, V[] _rest101) => {
return Arr(Call(ball_13, V.Undef, x_106, y_107, z_108, ((V)((5D * ToNum(s_109)))), ((V)("#ff9d2a")), Call(em_33, V.Undef, NewObj(3).Put("sy", ((V)(1.7))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V)), Call(ball_13, V.Undef, x_106, Add(y_107, ((V)((2D * ToNum(s_109))))), Add(z_108, ((V)(1D))), ((V)((2.8 * ToNum(s_109)))), ((V)("#ffe9a0")), Call(em_33, V.Undef, NewObj(3).Put("sy", ((V)(1.6))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)));
}, 4, "", true);
A4_37 = NewObj(25).Put("hopscotch", Fn((V _arrowThis118, int _argc111, V S_117, V _a114, V _a115, V _a116, V[] _rest112) => {
return NewObj(7).Put("w", ((V)(74D))).Put("d", ((V)(196D))).Put("flat", ((V)(1D))).Put("noBlock", ((V)(1D))).Put("act", ((V)("play"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(0D))).V).Put("build", Fn((V _arrowThis126, int _argc119, V P_125, V _a122, V _a123, V _a124, V[] _rest120) => {
V cs_127 = default;
V o_128 = default;
cs_127 = (SEqS(Get(S_117, "k"), "candy") ? NE_23 : Arr(((V)("#fffaf1")), ((V)("#ffd66b")), ((V)("#9fd8ff")), ((V)("#ffb3a0")), ((V)("#b8f0a0")), ((V)("#fffaf1"))));
o_128 = Arr();
Invoke(Arr(Arr(((V)(0D))), Arr(((V)(0D))), Arr(((V)((-1D))), ((V)(1D))), Arr(((V)(0D))), Arr(((V)((-1D))), ((V)(1D))), Arr(((V)(0D))), Arr(((V)((-1D))), ((V)(1D)))), "forEach", Fn((V _arrowThis137, int _argc129, V r_135, V i_136, V _a133, V _a134, V[] _rest130) => {
return Invoke(r_135, "forEach", Fn((V _arrowThis145, int _argc138, V c_144, V _a141, V _a142, V _a143, V[] _rest139) => {
return Invoke(o_128, "push", Call(box_11, V.Undef, ((V)((ToNum(c_144) * 17D))), ((V)(0D)), ((V)((84D - (ToNum(i_136) * 28D)))), ((V)(32D)), ((V)(0.8)), ((V)(26D)), GetIdx(cs_127, (ToNum(Add(Add(((V)((ToNum(i_136) * 2D))), c_144), ((V)(7D)))) % 6D)), NewObj(2).Put("r", ((V)(3D))).Put("mat", ((V)("paint"))).V));
}, 1, "", true));
}, 2, "", true));
Invoke(o_128, "push", Call(ball_13, V.Undef, ((V)(10D)), ((V)(0.8)), ((V)(66D)), ((V)(4.5)), (SEqS(Get(S_117, "k"), "royal") ? GOLD_25 : ((V)("#e2554a"))), NewObj(3).Put("sy", ((V)(0.4))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
return o_128;
return default;
}, 1, "build", true)).V;
}, 1, "hopscotch", true)).Put("hoop", Fn((V _arrowThis153, int _argc146, V S_152, V _a149, V _a150, V _a151, V[] _rest147) => {
return NewObj(5).Put("w", ((V)(72D))).Put("d", ((V)(60D))).Put("act", ((V)("play"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(92D))).V).Put("build", Fn((V _arrowThis161, int _argc154, V P_160, V _a157, V _a158, V _a159, V[] _rest155) => {
V k_162 = default;
V pole_163 = default;
V bd_164 = default;
V rim_165 = default;
V o_166 = default;
k_162 = Get(S_152, "k");
pole_163 = (SEqS(k_162, "royal") ? GOLD_25 : (SEqS(k_162, "candy") ? WH_28 : (SEqS(k_162, "junk") ? ((V)("#8a8f94")) : DK_29)));
bd_164 = (SEqS(k_162, "junk") ? ((V)("#c9a46a")) : (SEqS(k_162, "royal") ? ((V)("#7a1e2c")) : WH_28));
rim_165 = (SEqS(k_162, "royal") ? GOLD_25 : ((V)("#ff7a2a")));
o_166 = Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-16D))), ((V)(46D)), ((V)(8D)), ((V)(34D)), (SEqS(k_162, "junk") ? ((V)("#6b6f74")) : Call(shade_21, V.Undef, pole_163, ((V)(0.85)))), NewObj(1).Put("r", ((V)(4D))).V), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(8D)), ((V)((-16D))), ((V)(3.2)), ((V)(150D)), pole_163, NewObj(1).Put("n", ((V)(8D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(150D)), ((V)((-12D))), ((V)(4D)), ((V)(4D)), ((V)(12D)), pole_163), Call(slab_14, V.Undef, ((V)(0D)), ((V)(128D)), ((V)((-5D))), ((V)(66D)), ((V)(46D)), ((V)(3D)), bd_164, NewObj(1).Put("r", ((V)(3D))).V), Call(slab_14, V.Undef, ((V)(0D)), ((V)(136D)), ((V)((-3.2))), ((V)(28D)), ((V)(22D)), ((V)(0.6)), (SEqS(k_162, "royal") ? GOLD_25 : ((V)("#e2554a"))), NewObj(1).Put("r", ((V)(1D))).V), Call(slab_14, V.Undef, ((V)(0D)), ((V)(138D)), ((V)((-2.8))), ((V)(23D)), ((V)(17D)), ((V)(0.6)), bd_164, NewObj(1).Put("r", ((V)(1D))).V), Call(ring_35, V.Undef, ((V)(0D)), ((V)(132D)), ((V)(9D)), ((V)(11D)), ((V)(1.6)), ((V)(1.8)), rim_165), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(116D)), ((V)(9D)), ((V)(9.5)), ((V)(16D)), ((V)("#f4f1ea")), NewObj(3).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.65))), Arr(((V)(16D)), ((V)(0D)), ((V)(1D))))).Put("mat", ((V)("fab"))).V));
if (SEqS(k_162, "candy")) {
Invoke(Arr(((V)(30D)), ((V)(60D)), ((V)(90D)), ((V)(120D))), "forEach", Fn((V _arrowThis175, int _argc167, V y_173, V i_174, V _a171, V _a172, V[] _rest168) => {
return Invoke(o_166, "push", Call(cyl_12, V.Undef, ((V)(0D)), Add(((V)(8D)), y_173), ((V)((-16D))), ((V)(3.5)), ((V)(7D)), GetK(NE_23, i_174), NewObj(1).Put("n", ((V)(8D))).V));
}, 2, "", true));
}
Invoke(o_166, "push", Call(ball_13, V.Undef, ((V)(30D)), ((V)(0D)), ((V)(36D)), ((V)(10D)), ((V)("#ff8a3a")), NewObj(2).Put("k", ((V)(5D))).Put("n", ((V)(12D))).V));
return o_166;
return default;
}, 1, "build", true)).V;
}, 1, "hoop", true)).Put("goal", Fn((V _arrowThis183, int _argc176, V S_182, V _a179, V _a180, V _a181, V[] _rest177) => {
return NewObj(5).Put("w", ((V)(156D))).Put("d", ((V)(62D))).Put("act", ((V)("play"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(74D))).V).Put("build", Fn((V _arrowThis191, int _argc184, V P_190, V _a187, V _a188, V _a189, V[] _rest185) => {
V k_192 = default;
V f_193 = default;
V net_194 = default;
k_192 = Get(S_182, "k");
f_193 = (SEqS(k_192, "royal") ? GOLD_25 : WH_28);
net_194 = ((V)((SEqS(k_192, "candy") ? "#fff0fa" : "#e6ecef")));
return Arr(Call(cyl_12, V.Undef, ((V)((-72D))), ((V)(0D)), ((V)(24D)), ((V)(2.8)), ((V)(70D)), f_193, NewObj(1).Put("n", ((V)(8D))).V), Call(cyl_12, V.Undef, ((V)(72D)), ((V)(0D)), ((V)(24D)), ((V)(2.8)), ((V)(70D)), f_193, NewObj(1).Put("n", ((V)(8D))).V), Call(slabX_15, V.Undef, ((V)(0D)), ((V)(67D)), ((V)(24D)), ((V)(150D)), ((V)(5.4)), ((V)(5.4)), f_193, NewObj(1).Put("r", ((V)(2D))).V), Call(slab_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-24D))), ((V)(144D)), ((V)(44D)), ((V)(1.2)), net_194, NewObj(2).Put("r", ((V)(2D))).Put("mat", ((V)("fab"))).V), Call(prism_18, V.Undef, ((V)((-73D))), ((V)((-71D))), Arr(Arr(((V)(24D)), ((V)(0D))), Arr(((V)(24D)), ((V)(68D))), Arr(((V)((-24D))), ((V)(44D))), Arr(((V)((-24D))), ((V)(0D)))), net_194, NewObj(1).Put("mat", ((V)("fab"))).V), Call(prism_18, V.Undef, ((V)(71D)), ((V)(73D)), Arr(Arr(((V)(24D)), ((V)(0D))), Arr(((V)(24D)), ((V)(68D))), Arr(((V)((-24D))), ((V)(44D))), Arr(((V)((-24D))), ((V)(0D)))), net_194, NewObj(1).Put("mat", ((V)("fab"))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-24D))), ((V)(150D)), ((V)(3D)), ((V)(4D)), f_193, NewObj(1).Put("r", ((V)(1D))).V), Call(ball_13, V.Undef, ((V)(38D)), ((V)(0D)), ((V)(48D)), ((V)(9D)), WH_28, NewObj(2).Put("k", ((V)(5D))).Put("n", ((V)(12D))).V), Call(ball_13, V.Undef, ((V)(36D)), ((V)(12D)), ((V)(54D)), ((V)(2.6)), DK_29, NewObj(3).Put("sy", ((V)(0.5))).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V));
return default;
}, 1, "build", true)).V;
}, 1, "goal", true)).Put("toss", Fn((V _arrowThis202, int _argc195, V S_201, V _a198, V _a199, V _a200, V[] _rest196) => {
return NewObj(5).Put("w", ((V)(74D))).Put("d", ((V)(116D))).Put("act", ((V)("play"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(84D))).V).Put("build", Fn((V _arrowThis210, int _argc203, V P_209, V _a206, V _a207, V _a208, V[] _rest204) => {
V k_211 = default;
V wd_212 = default;
V st_213 = default;
k_211 = Get(S_201, "k");
wd_212 = (SEqS(k_211, "candy") ? Get(P_209, "a") : (SEqS(k_211, "royal") ? ((V)("#7a1e2c")) : Get(P_209, "w")));
st_213 = (SEqS(k_211, "royal") ? GOLD_25 : Get(P_209, "b"));
return Arr(Call(prism_18, V.Undef, ((V)((-32D))), ((V)(32D)), Arr(Arr(((V)(52D)), ((V)(0D))), Arr(((V)(52D)), ((V)(5D))), Arr(((V)((-52D))), ((V)(26D))), Arr(((V)((-52D))), ((V)(0D)))), wd_212), Call(prism_18, V.Undef, ((V)((-7D))), ((V)(7D)), Arr(Arr(((V)(52.4)), ((V)(5.2))), Arr(((V)((-52.4))), ((V)(26.2))), Arr(((V)((-52.4))), ((V)(27D))), Arr(((V)(52.4)), ((V)(6D)))), st_213), Call(ball_13, V.Undef, ((V)(0D)), ((V)(21.6)), ((V)((-30D))), ((V)(7.5)), ((V)("#2a1c14")), NewObj(3).Put("sy", ((V)(0.18))).Put("k", ((V)(3D))).Put("n", ((V)(12D))).V), Call(box_11, V.Undef, ((V)((-14D))), ((V)(0D)), ((V)(66D)), ((V)(13D)), ((V)(4D)), ((V)(13D)), Get(P_209, "b"), NewObj(2).Put("r", ((V)(4D))).Put("soft", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(14D)), ((V)(0D)), ((V)(72D)), ((V)(13D)), ((V)(4D)), ((V)(13D)), ((V)("#e2554a")), NewObj(2).Put("r", ((V)(4D))).Put("soft", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(6D)), ((V)(13D)), ((V)(12D)), ((V)(13D)), ((V)(4D)), ((V)(13D)), Get(P_209, "b"), NewObj(2).Put("r", ((V)(4D))).Put("soft", ((V)(1D))).V));
return default;
}, 1, "build", true)).V;
}, 1, "toss", true)).Put("ringToss", Fn((V _arrowThis221, int _argc214, V S_220, V _a217, V _a218, V _a219, V[] _rest215) => {
return NewObj(6).Put("w", ((V)(64D))).Put("d", ((V)(64D))).Put("round", ((V)(1D))).Put("act", ((V)("play"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(74D))).V).Put("build", Fn((V _arrowThis229, int _argc222, V P_228, V _a225, V _a226, V _a227, V[] _rest223) => {
return new ArrBuilder().Add(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(26D)), ((V)(5D)), (SEqS(Get(S_220, "k"), "royal") ? GOLD_25 : Get(P_228, "w")), NewObj(1).Put("n", ((V)(16D))).V)).Add(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(5D)), ((V)(0D)), ((V)(3D)), ((V)(46D)), Get(P_228, "a"), NewObj(1).Put("n", ((V)(8D))).V)).Add(Call(ball_13, V.Undef, ((V)(0D)), ((V)(50D)), ((V)(0D)), ((V)(4.4)), Get(P_228, "b"))).Spread(Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _arrowThis237, int _argc230, V i_236, V _a233, V _a234, V _a235, V[] _rest231) => {
return Call(ring_35, V.Undef, ((V)(0D)), ((V)((5.4 + (ToNum(i_236) * 3D)))), ((V)(0D)), ((V)((12D - (ToNum(i_236) * 1.3)))), ((V)(3D)), ((V)(2.6)), GetIdx(NE_23, (ToNum(i_236) * 2D)));
}, 1, "", true))).Add(Call(ring_35, V.Undef, ((V)(30D)), ((V)(0D)), ((V)(30D)), ((V)(11D)), ((V)(3D)), ((V)(2.6)), GetIdx(NE_23, 3D))).V;
}, 1, "build", true)).V;
}, 1, "ringToss", true)).Put("tether", Fn((V _arrowThis245, int _argc238, V S_244, V _a241, V _a242, V _a243, V[] _rest239) => {
return NewObj(6).Put("w", ((V)(90D))).Put("d", ((V)(90D))).Put("round", ((V)(1D))).Put("act", ((V)("play"))).Put("use", NewObj(2).Put("x", ((V)(46D))).Put("z", ((V)(46D))).V).Put("build", Fn((V _arrowThis253, int _argc246, V P_252, V _a249, V _a250, V _a251, V[] _rest247) => {
V k_254 = default;
V pole_255 = default;
k_254 = Get(S_244, "k");
pole_255 = (SEqS(k_254, "royal") ? GOLD_25 : ((V)("#c9d3d8")));
return Arr(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(20D)), ((V)(6D)), ((V)((SEqS(k_254, "royal") ? "#f4f1ea" : "#8a8f94"))), NewObj(1).Put("n", ((V)(14D))).V), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(0D)), ((V)(2.4)), ((V)(146D)), pole_255, NewObj(1).Put("n", ((V)(8D))).V), Call(ball_13, V.Undef, ((V)(0D)), ((V)(150D)), ((V)(0D)), ((V)(3D)), pole_255), Call(prismZ_19, V.Undef, ((V)((-0.5))), ((V)(0.5)), Arr(Arr(((V)((-0.5))), ((V)(148D))), Arr(((V)(0.5)), ((V)(148D))), Arr(((V)(27D)), ((V)(100D))), Arr(((V)(25.8)), ((V)(100D)))), CR_27), Call(ball_13, V.Undef, ((V)(26D)), ((V)(82D)), ((V)(0D)), ((V)(12D)), (SEqS(k_254, "royal") ? ((V)("#7a1e2c")) : Get(P_252, "b"))));
return default;
}, 1, "build", true)).V;
}, 1, "tether", true)).Put("sprinkler", Fn((V _arrowThis263, int _argc256, V S_262, V _a259, V _a260, V _a261, V[] _rest257) => {
return NewObj(5).Put("w", ((V)(64D))).Put("d", ((V)(40D))).Put("act", ((V)("play"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(54D))).V).Put("build", Fn((V _arrowThis271, int _argc264, V P_270, V _a267, V _a268, V _a269, V[] _rest265) => {
V o_272 = default;
o_272 = Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(30D)), ((V)(5D)), ((V)(18D)), (SEqS(Get(S_262, "k"), "mod") ? DK_29 : ((V)("#5cb85c"))), NewObj(1).Put("r", ((V)(4D))).V), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(5D)), ((V)(0D)), ((V)(2D)), ((V)(8D)), CH_26, NewObj(1).Put("n", ((V)(6D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(13D)), ((V)(0D)), ((V)(46D)), ((V)(3D)), ((V)(4D)), CH_26, NewObj(1).Put("r", ((V)(1.5))).V));
{
double i_273 = 0;
i_273 = 0D;
while (true) {
if (!((i_273 <= 12D))) break;
double a_275 = 0;
a_275 = ((PI_24 * i_273) / 12D);
Invoke(o_272, "push", Call(ball_13, V.Undef, ((V)(((-48D) * FdLibm.Cos(a_275)))), ((V)((14D + (44D * FdLibm.Sin(a_275))))), ((V)(0D)), ((V)(2.3)), ((V)((NumTruthy((i_273 % 3D)) ? "#bfe9ff" : "#ffffff"))), Call(em_33, V.Undef, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("op", ((V)(0.75))).V)));
i_273++;
}
}
return o_272;
return default;
}, 1, "build", true)).V;
}, 1, "sprinkler", true)).Put("dome", Fn((V _arrowThis283, int _argc276, V S_282, V _a279, V _a280, V _a281, V[] _rest277) => {
return NewObj(6).Put("w", ((V)(144D))).Put("d", ((V)(144D))).Put("round", ((V)(1D))).Put("act", ((V)("play"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(96D))).V).Put("build", Fn((V _arrowThis291, int _argc284, V P_290, V _a287, V _a288, V _a289, V[] _rest285) => {
V k_292 = default;
V cs_293 = default;
V o_294 = default;
k_292 = Get(S_282, "k");
cs_293 = (SEqS(k_292, "candy") ? NE_23 : (SEqS(k_292, "royal") ? Arr(GOLD_25, ((V)("#f4f1ea")), GOLD_25) : Arr(Get(P_290, "a"), Get(P_290, "b"), ((V)("#e2554a")))));
o_294 = Arr();
Invoke(o_294, "push", Call(solid_10, V.Undef, NewObj(11).Put("ax", ((V)("z"))).Put("sh", ((V)("arc"))).Put("c", Arr(((V)(0D)), ((V)(0D)))).Put("a", ((V)(66D))).Put("b", ((V)(66D))).Put("th", ((V)(3.2))).Put("a0", ((V)(0D))).Put("a1", ((V)(PI_24))).Put("n", ((V)(14D))).Put("rings", Arr(Arr(((V)((-1.6))), ((V)(0D))), Arr(((V)(1.6)), ((V)(0D))))).Put("col", GetIdx(cs_293, 0D)).V), Call(solid_10, V.Undef, NewObj(11).Put("ax", ((V)("x"))).Put("sh", ((V)("arc"))).Put("c", Arr(((V)(0D)), ((V)(0D)))).Put("a", ((V)(66D))).Put("b", ((V)(66D))).Put("th", ((V)(3.2))).Put("a0", ((V)(0D))).Put("a1", ((V)(PI_24))).Put("n", ((V)(14D))).Put("rings", Arr(Arr(((V)((-1.6))), ((V)(0D))), Arr(((V)(1.6)), ((V)(0D))))).Put("col", GetIdx(cs_293, 1D)).V));
Invoke(Arr(Arr(((V)(0D)), ((V)(66D))), Arr(((V)(22D)), ((V)(62D))), Arr(((V)(42D)), ((V)(50D))), Arr(((V)(56D)), ((V)(34D)))), "forEach", Fn((V _arrowThis307, int _argc295, V _a297, V i_301, V _a299, V _a300, V[] _rest296) => {
V y_304 = default;
V r_306 = default;
{ V _t302 = ListOf(_a297);
{ V _t303 = GetIdx(_t302, 0D);
y_304 = _t303; }
{ V _t305 = GetIdx(_t302, 1D);
r_306 = _t305; }
}
return Invoke(o_294, "push", Call(ring_35, V.Undef, ((V)(0D)), y_304, ((V)(0D)), r_306, ((V)(3D)), ((V)(3D)), GetIdx(cs_293, (ToNum(Add(i_301, ((V)(2D)))) % ToNum(Get(cs_293, "length"))))));
}, 2, "", true));
Invoke(o_294, "push", Call(ball_13, V.Undef, ((V)(0D)), ((V)(64D)), ((V)(0D)), ((V)(4D)), GetIdx(cs_293, 0D)));
return o_294;
return default;
}, 1, "build", true)).V;
}, 1, "dome", true)).Put("golf", Fn((V _arrowThis315, int _argc308, V S_314, V _a311, V _a312, V _a313, V[] _rest309) => {
return NewObj(7).Put("w", ((V)(164D))).Put("d", ((V)(94D))).Put("flat", ((V)(1D))).Put("noBlock", ((V)(1D))).Put("act", ((V)("play"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(0D))).V).Put("build", Fn((V _arrowThis323, int _argc316, V P_322, V _a319, V _a320, V _a321, V[] _rest317) => {
V k_324 = default;
V g_325 = default;
V o_326 = default;
k_324 = Get(S_314, "k");
g_325 = ((V)((SEqS(k_324, "candy") ? "#9fe0c4" : "#5cb85c")));
o_326 = Arr(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(80D)), ((V)(1.6)), Call(shade_21, V.Undef, g_325, ((V)(0.85))), NewObj(2).Put("rz", ((V)(46D))).Put("n", ((V)(24D))).V), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(1.6)), ((V)(0D)), ((V)(75D)), ((V)(0.4)), g_325, NewObj(3).Put("rz", ((V)(42D))).Put("n", ((V)(22D))).Put("mat", ((V)("fab"))).V), Call(ball_13, V.Undef, ((V)(42D)), ((V)(1.4)), ((V)((-10D))), ((V)(4.4)), ((V)("#20160e")), NewObj(3).Put("sy", ((V)(0.15))).Put("k", ((V)(3D))).Put("n", ((V)(10D))).V), Call(cyl_12, V.Undef, ((V)(42D)), ((V)(1.6)), ((V)((-10D))), ((V)(0.8)), ((V)(42D)), WH_28, NewObj(1).Put("n", ((V)(4D))).V), Call(prismZ_19, V.Undef, ((V)((-0.4))), ((V)(0.4)), Arr(Arr(((V)(42.8)), ((V)(44D))), Arr(((V)(60D)), ((V)(37D))), Arr(((V)(42.8)), ((V)(30D)))), (SEqS(k_324, "royal") ? GOLD_25 : ((V)("#e2554a")))), Call(ball_13, V.Undef, ((V)((-34D))), ((V)(2D)), ((V)(16D)), ((V)(3D)), WH_28, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
if (SEqS(k_324, "candy")) {
Invoke(Arr(Arr(((V)((-6D))), ((V)((-16D)))), Arr(((V)(16D)), ((V)(18D)))), "forEach", Fn((V _arrowThis339, int _argc327, V _a329, V i_333, V _a331, V _a332, V[] _rest328) => {
V x_336 = default;
V z_338 = default;
{ V _t334 = ListOf(_a329);
{ V _t335 = GetIdx(_t334, 0D);
x_336 = _t335; }
{ V _t337 = GetIdx(_t334, 1D);
z_338 = _t337; }
}
return Invoke(o_326, "push", Call(cyl_12, V.Undef, x_336, ((V)(2D)), z_338, ((V)(1D)), ((V)(14D)), WH_28, NewObj(1).Put("n", ((V)(4D))).V), Call(disc_17, V.Undef, x_336, ((V)(18D)), z_338, ((V)(8D)), ((V)(2D)), GetIdx(NE_23, (ToNum(i_333) * 2D))));
}, 2, "", true));
}
return o_326;
return default;
}, 1, "build", true)).V;
}, 1, "golf", true)).Put("pong", Fn((V _arrowThis347, int _argc340, V S_346, V _a343, V _a344, V _a345, V[] _rest341) => {
return NewObj(5).Put("w", ((V)(152D))).Put("d", ((V)(86D))).Put("act", ((V)("play"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(74D))).V).Put("build", Fn((V _arrowThis355, int _argc348, V P_354, V _a351, V _a352, V _a353, V[] _rest349) => {
V k_356 = default;
V top_357 = default;
k_356 = Get(S_346, "k");
top_357 = (SEqS(k_356, "candy") ? Get(P_354, "a") : ((V)((SEqS(k_356, "royal") ? "#2f6a4a" : "#2f6f8a"))));
return new ArrBuilder().Spread(Call(legs4_20, V.Undef, ((V)(64D)), ((V)(34D)), ((V)(36D)), (SEqS(k_356, "royal") ? GOLD_25 : DK_29), ((V)(2.6)))).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(36D)), ((V)(0D)), ((V)(152D)), ((V)(4D)), ((V)(86D)), top_357, NewObj(2).Put("r", ((V)(2D))).Put("mat", ((V)("paint"))).V)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(40D)), ((V)(41.6)), ((V)(152D)), ((V)(0.4)), ((V)(1.4)), WH_28)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(40D)), ((V)((-41.6))), ((V)(152D)), ((V)(0.4)), ((V)(1.4)), WH_28)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(40D)), ((V)(0D)), ((V)(152D)), ((V)(0.4)), ((V)(1D)), WH_28)).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(40D)), ((V)(0D)), ((V)(2D)), ((V)(10D)), ((V)(90D)), ((V)("#f4f1ea")), NewObj(1).Put("mat", ((V)("fab"))).V)).Add(Call(cyl_12, V.Undef, ((V)((-52D))), ((V)(40D)), ((V)(20D)), ((V)(8D)), ((V)(1.2)), ((V)("#e2554a")), NewObj(1).Put("n", ((V)(12D))).V)).Add(Call(box_11, V.Undef, ((V)((-52D))), ((V)(40.4)), ((V)(30D)), ((V)(3D)), ((V)(1D)), ((V)(9D)), ((V)("#a86b36")))).Add(Call(ball_13, V.Undef, ((V)(22D)), ((V)(40D)), ((V)((-12D))), ((V)(2.6)), ((V)("#ff9d4a")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)).V;
return default;
}, 1, "build", true)).V;
}, 1, "pong", true)).Put("gnome", Fn((V _arrowThis365, int _argc358, V S_364, V _a361, V _a362, V _a363, V[] _rest359) => {
return NewObj(4).Put("w", ((V)(34D))).Put("d", ((V)(34D))).Put("round", ((V)(1D))).Put("build", Fn((V _arrowThis373, int _argc366, V P_372, V _a369, V _a370, V _a371, V[] _rest367) => {
V k_374 = default;
V hat_375 = default;
V coat_376 = default;
k_374 = Get(S_364, "k");
hat_375 = (SEqS(k_374, "royal") ? GOLD_25 : ((V)("#e2554a")));
coat_376 = (SEqS(k_374, "candy") ? GetIdx(NE_23, 4D) : ((V)("#3f7fc4")));
return Arr(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(12D)), ((V)(4D)), ((V)("#8a8f94")), NewObj(1).Put("n", ((V)(12D))).V), Call(cyl_12, V.Undef, ((V)((-5D))), ((V)(4D)), ((V)(2D)), ((V)(4D)), ((V)(6D)), ((V)("#5a3a24")), NewObj(1).Put("n", ((V)(8D))).V), Call(cyl_12, V.Undef, ((V)(5D)), ((V)(4D)), ((V)(2D)), ((V)(4D)), ((V)(6D)), ((V)("#5a3a24")), NewObj(1).Put("n", ((V)(8D))).V), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(9D)), ((V)(0D)), ((V)(11D)), ((V)(18D)), coat_376, NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(18D)), ((V)(0D)), ((V)(0.7))))).V), Call(ball_13, V.Undef, ((V)(0D)), ((V)(22D)), ((V)(4D)), ((V)(7.5)), ((V)("#f4f1ea")), NewObj(2).Put("sy", ((V)(1.3))).Put("sz", ((V)(0.7))).V), Call(ball_13, V.Undef, ((V)(0D)), ((V)(28D)), ((V)(1D)), ((V)(6.5)), ((V)("#f2c7a0"))), Call(ball_13, V.Undef, ((V)(0D)), ((V)(30D)), ((V)(7D)), ((V)(2.6)), ((V)("#e88a7a")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(34D)), ((V)(0D)), ((V)(7.4)), ((V)(20D)), hat_375, NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(20D)), ((V)(0D)), ((V)(0.05))))).V));
return default;
}, 1, "build", true)).V;
}, 1, "gnome", true)).Put("birdbath", Fn((V _arrowThis384, int _argc377, V S_383, V _a380, V _a381, V _a382, V[] _rest378) => {
return NewObj(4).Put("w", ((V)(60D))).Put("d", ((V)(60D))).Put("round", ((V)(1D))).Put("build", Fn((V _arrowThis392, int _argc385, V P_391, V _a388, V _a389, V _a390, V[] _rest386) => {
V st_393 = default;
st_393 = ((V)((SEqS(Get(S_383, "k"), "royal") ? "#f4f1ea" : "#c9c3b8")));
return new ArrBuilder().Add(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(16D)), ((V)(6D)), st_393, NewObj(2).Put("n", ((V)(14D))).Put("mat", ((V)("paint"))).V)).Add(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(0D)), ((V)(6D)), ((V)(40D)), st_393, NewObj(3).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.3))), Arr(((V)(20D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(40D)), ((V)(0D)), ((V)(1.2))))).Put("mat", ((V)("paint"))).V)).Add(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(46D)), ((V)(0D)), ((V)(26D)), ((V)(8D)), st_393, NewObj(3).Put("n", ((V)(18D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.6))), Arr(((V)(8D)), ((V)(0D)), ((V)(1D))))).Put("mat", ((V)("paint"))).V)).Add(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(53D)), ((V)(0D)), ((V)(22D)), ((V)(0.6)), ((V)("#9fd8f2")), Call(em_33, V.Undef, NewObj(2).Put("n", ((V)(18D))).Put("op", ((V)(0.85))).V))).Add(Call(ball_13, V.Undef, ((V)(12D)), ((V)(54D)), ((V)((-6D))), ((V)(5D)), ((V)("#7fa8d8")), NewObj(1).Put("sx", ((V)(1.3))).V)).Add(Call(ball_13, V.Undef, ((V)(17D)), ((V)(59D)), ((V)((-6D))), ((V)(3.4)), ((V)("#7fa8d8")))).Add(Call(box_11, V.Undef, ((V)(21D)), ((V)(60D)), ((V)((-6D))), ((V)(3D)), ((V)(1.4)), ((V)(2D)), ((V)("#ff9d4a")), NewObj(1).Put("r", ((V)(0.5))).V)).Spread((SEqS(Get(S_383, "k"), "royal") ? Arr(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(54D)), ((V)(0D)), ((V)(26.4)), ((V)(2D)), GOLD_25, NewObj(1).Put("n", ((V)(18D))).V)) : Arr())).V;
return default;
}, 1, "build", true)).V;
}, 1, "birdbath", true)).Put("flowerBed", Fn((V _arrowThis401, int _argc394, V S_400, V _a397, V _a398, V _a399, V[] _rest395) => {
return NewObj(3).Put("w", ((V)(130D))).Put("d", ((V)(44D))).Put("build", Fn((V _arrowThis409, int _argc402, V P_408, V _a405, V _a406, V _a407, V[] _rest403) => {
V k_410 = default;
V ed_411 = default;
V o_412 = default;
k_410 = Get(S_400, "k");
ed_411 = (SEqS(k_410, "royal") ? ((V)("#f4f1ea")) : (SEqS(k_410, "candy") ? Get(P_408, "a") : ((V)("#a86b36"))));
o_412 = Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(130D)), ((V)(12D)), ((V)(44D)), ed_411, NewObj(1).Put("r", ((V)(3D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(0D)), ((V)(122D)), ((V)(1.6)), ((V)(36D)), ((V)("#5a3a24")), NewObj(2).Put("r", ((V)(2D))).Put("mat", ((V)("paint"))).V));
{
double i_413 = 0;
i_413 = 0D;
while (true) {
if (!((i_413 < 14D))) break;
double x_415 = 0;
double z_416 = 0;
double h_417 = 0;
V c_418 = default;
x_415 = (((-54D) + ((i_413 % 7D) * 18D)) + ((i_413 > 6D) ? 9D : 0D));
z_416 = ((i_413 > 6D) ? 8D : (-8D));
h_417 = (10D + ((i_413 * 7D) % 9D));
c_418 = (SEqS(k_410, "candy") ? GetIdx(NE_23, (i_413 % 6D)) : GetIdx(Arr(((V)("#e2554a")), ((V)("#ffd23f")), ((V)("#f4f1ea")), ((V)("#c4a0e0")), ((V)("#ff9d4a"))), (i_413 % 5D)));
Invoke(o_412, "push", Call(cyl_12, V.Undef, ((V)(x_415)), ((V)(13D)), ((V)(z_416)), ((V)(0.9)), ((V)(h_417)), LEAF_31, NewObj(1).Put("n", ((V)(4D))).V), Call(ball_13, V.Undef, ((V)((x_415 - 3D))), ((V)((13D + (h_417 * 0.4)))), ((V)(z_416)), ((V)(3.4)), LEAF_31, NewObj(3).Put("sy", ((V)(0.5))).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V), Call(ball_13, V.Undef, ((V)(x_415)), ((V)((13D + h_417))), ((V)(z_416)), ((V)(4.6)), c_418, NewObj(2).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V), Call(ball_13, V.Undef, ((V)(x_415)), ((V)((15D + h_417))), ((V)((z_416 + 3D))), ((V)(1.6)), ((V)("#ffd23f")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V));
i_413++;
}
}
return o_412;
return default;
}, 1, "build", true)).V;
}, 1, "flowerBed", true)).Put("stones", Fn((V _arrowThis426, int _argc419, V S_425, V _a422, V _a423, V _a424, V[] _rest420) => {
return NewObj(5).Put("w", ((V)(150D))).Put("d", ((V)(120D))).Put("flat", ((V)(1D))).Put("noBlock", ((V)(1D))).Put("build", Fn((V _arrowThis434, int _argc427, V P_433, V _a430, V _a431, V _a432, V[] _rest428) => {
return Invoke(Arr(Arr(((V)((-56D))), ((V)(40D)), ((V)(15D))), Arr(((V)((-22D))), ((V)(18D)), ((V)(13D))), Arr(((V)(12D)), ((V)((-4D))), ((V)(16D))), Arr(((V)(46D)), ((V)((-28D))), ((V)(13D))), Arr(((V)(66D)), ((V)((-50D))), ((V)(11D)))), "map", Fn((V _arrowThis449, int _argc435, V _a437, V i_441, V _a439, V _a440, V[] _rest436) => {
V x_444 = default;
V z_446 = default;
V r_448 = default;
{ V _t442 = ListOf(_a437);
{ V _t443 = GetIdx(_t442, 0D);
x_444 = _t443; }
{ V _t445 = GetIdx(_t442, 1D);
z_446 = _t445; }
{ V _t447 = GetIdx(_t442, 2D);
r_448 = _t447; }
}
return Call(cyl_12, V.Undef, x_444, ((V)(0D)), z_446, r_448, ((V)(2.4)), (SEqS(Get(S_425, "k"), "royal") ? ((V)((NumTruthy((ToNum(i_441) % 2D)) ? "#f4f1ea" : "#e6dcc8"))) : GetIdx(Arr(((V)("#b9b2a6")), ((V)("#a8a196")), ((V)("#c4beb2"))), (ToNum(i_441) % 3D))), NewObj(3).Put("rz", ((V)((ToNum(r_448) * 0.72)))).Put("n", ((V)(14D))).Put("mat", ((V)("paint"))).V);
}, 2, "", true));
}, 1, "build", true)).V;
}, 1, "stones", true)).Put("spinner", Fn((V _arrowThis457, int _argc450, V S_456, V _a453, V _a454, V _a455, V[] _rest451) => {
return NewObj(4).Put("w", ((V)(40D))).Put("d", ((V)(40D))).Put("round", ((V)(1D))).Put("build", Fn((V _arrowThis465, int _argc458, V P_464, V _a461, V _a462, V _a463, V[] _rest459) => {
V o_466 = default;
V cs_467 = default;
o_466 = Arr(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(2D)), ((V)(90D)), (SEqS(Get(S_456, "k"), "royal") ? GOLD_25 : CH_26), NewObj(1).Put("n", ((V)(6D))).V));
cs_467 = NE_23;
{
double i_468 = 0;
i_468 = 0D;
while (true) {
if (!((i_468 < 6D))) break;
double a_470 = 0;
double b_471 = 0;
a_470 = (((i_468 / 6D) * PI_24) * 2D);
b_471 = (a_470 + 0.9);
Invoke(o_466, "push", Call(prismZ_19, V.Undef, ((V)(5D)), ((V)(6D)), Arr(Arr(((V)(0D)), ((V)(92D))), Arr(((V)((FdLibm.Cos(a_470) * 22D))), ((V)((92D + (FdLibm.Sin(a_470) * 22D))))), Arr(((V)((FdLibm.Cos(b_471) * 14D))), ((V)((92D + (FdLibm.Sin(b_471) * 14D)))))), GetIdx(cs_467, i_468)));
i_468++;
}
}
Invoke(o_466, "push", Call(disc_17, V.Undef, ((V)(0D)), ((V)(92D)), ((V)(6D)), ((V)(3D)), ((V)(2D)), WH_28));
return o_466;
return default;
}, 1, "build", true)).V;
}, 1, "spinner", true)).Put("urn", Fn((V _arrowThis479, int _argc472, V S_478, V _a475, V _a476, V _a477, V[] _rest473) => {
return NewObj(4).Put("w", ((V)(54D))).Put("d", ((V)(54D))).Put("round", ((V)(1D))).Put("build", Fn((V _arrowThis487, int _argc480, V P_486, V _a483, V _a484, V _a485, V[] _rest481) => {
return Arr(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(14D)), ((V)(6D)), GOLD_25, NewObj(1).Put("n", ((V)(14D))).V), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(0D)), ((V)(22D)), ((V)(34D)), ((V)("#f4f1ea")), NewObj(3).Put("n", ((V)(16D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.5))), Arr(((V)(16D)), ((V)(0D)), ((V)(1D))), Arr(((V)(30D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(34D)), ((V)(0D)), ((V)(1.1))))).Put("mat", ((V)("paint"))).V), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(30D)), ((V)(0D)), ((V)(22.6)), ((V)(3D)), GOLD_25, NewObj(1).Put("n", ((V)(16D))).V), Call(ball_13, V.Undef, ((V)(0D)), ((V)(38D)), ((V)(0D)), ((V)(24D)), ((V)("#4f9a44")), NewObj(1).Put("mat", ((V)("fab"))).V), Call(ball_13, V.Undef, ((V)((-8D))), ((V)(56D)), ((V)(6D)), ((V)(10D)), ((V)("#6fae50")), NewObj(1).Put("mat", ((V)("fab"))).V));
}, 1, "build", true)).V;
}, 1, "urn", true)).Put("tiki", Fn((V _arrowThis495, int _argc488, V S_494, V _a491, V _a492, V _a493, V[] _rest489) => {
return NewObj(5).Put("w", ((V)(30D))).Put("d", ((V)(30D))).Put("round", ((V)(1D))).Put("glow", Fn((V _arrowThis502, int _argc496, V _a498, V _a499, V _a500, V _a501, V[] _rest497) => {
return NewObj(2).Put("y", ((V)(112D))).Put("r", ((V)(70D))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis510, int _argc503, V P_509, V _a506, V _a507, V _a508, V[] _rest504) => {
V k_511 = default;
V c_512 = default;
k_511 = Get(S_494, "k");
c_512 = (SEqS(k_511, "royal") ? GOLD_25 : ((V)("#c9a46a")));
return new ArrBuilder().Add(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(8D)), ((V)(4D)), ((V)("#5a4020")), NewObj(1).Put("n", ((V)(10D))).V)).Add(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(2.6)), ((V)(96D)), c_512, NewObj(1).Put("n", ((V)(8D))).V)).Spread(Invoke(Arr(((V)(24D)), ((V)(48D)), ((V)(72D))), "map", Fn((V _arrowThis520, int _argc513, V y_519, V _a516, V _a517, V _a518, V[] _rest514) => {
return Call(cyl_12, V.Undef, ((V)(0D)), y_519, ((V)(0D)), ((V)(3D)), ((V)(2D)), Call(shade_21, V.Undef, c_512, ((V)(0.7))), NewObj(1).Put("n", ((V)(8D))).V);
}, 1, "", true))).Add(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(98D)), ((V)(0D)), ((V)(7D)), ((V)(10D)), (SEqS(k_511, "royal") ? GOLD_25 : ((V)("#8a6a3e"))), NewObj(2).Put("n", ((V)(10D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.6))), Arr(((V)(10D)), ((V)(0D)), ((V)(1D))))).V)).Spread(Call(flame_36, V.Undef, ((V)(0D)), ((V)(108D)), ((V)(0D)), ((V)(1.4)))).V;
return default;
}, 1, "build", true)).V;
}, 1, "tiki", true)).Put("solar", Fn((V _arrowThis528, int _argc521, V S_527, V _a524, V _a525, V _a526, V[] _rest522) => {
return NewObj(4).Put("w", ((V)(140D))).Put("d", ((V)(30D))).Put("glow", Fn((V _arrowThis535, int _argc529, V _a531, V _a532, V _a533, V _a534, V[] _rest530) => {
return NewObj(2).Put("y", ((V)(30D))).Put("r", ((V)(90D))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis543, int _argc536, V P_542, V _a539, V _a540, V _a541, V[] _rest537) => {
V o_544 = default;
V c_545 = default;
o_544 = Arr();
c_545 = (SEqS(Get(S_527, "k"), "royal") ? GOLD_25 : ((V)("#3a3d44")));
Invoke(Arr(((V)((-54D))), ((V)((-18D))), ((V)(18D)), ((V)(54D))), "forEach", Fn((V _arrowThis553, int _argc546, V x_552, V _a549, V _a550, V _a551, V[] _rest547) => {
return Invoke(o_544, "push", Call(cyl_12, V.Undef, x_552, ((V)(0D)), ((V)(0D)), ((V)(1.6)), ((V)(26D)), c_545, NewObj(1).Put("n", ((V)(6D))).V), Call(cyl_12, V.Undef, x_552, ((V)(26D)), ((V)(0D)), ((V)(6D)), ((V)(8D)), ((V)("#fff1b8")), Call(em_33, V.Undef, NewObj(1).Put("n", ((V)(10D))).V)), Call(cyl_12, V.Undef, x_552, ((V)(34D)), ((V)(0D)), ((V)(7.4)), ((V)(2D)), c_545, NewObj(1).Put("n", ((V)(10D))).V), Call(box_11, V.Undef, x_552, ((V)(36D)), ((V)(0D)), ((V)(10D)), ((V)(1D)), ((V)(10D)), ((V)("#2c3a5a")), NewObj(2).Put("r", ((V)(1D))).Put("mat", ((V)("metal"))).V));
}, 1, "", true));
return o_544;
return default;
}, 1, "build", true)).V;
}, 1, "solar", true)).Put("ledWall", Fn((V _arrowThis561, int _argc554, V S_560, V _a557, V _a558, V _a559, V[] _rest555) => {
return NewObj(8).Put("w", ((V)(132D))).Put("d", ((V)(8D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(36D))).Put("act", ((V)("party"))).Put("party", ((V)(1D))).Put("glow", Fn((V _arrowThis568, int _argc562, V _a564, V _a565, V _a566, V _a567, V[] _rest563) => {
return NewObj(3).Put("y", ((V)(40D))).Put("r", ((V)(100D))).Put("c", ((V)("url(#gNeon)"))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis577, int _argc569, V P_575, V v_576, V _a573, V _a574, V[] _rest570) => {
V on_578 = default;
V o_579 = default;
on_578 = (SEqS(v_576, "on") ? V.True : V.False);
o_579 = Arr(Call(slab_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-1D))), ((V)(126D)), ((V)(82D)), ((V)(4D)), ((V)("#1b1d2a")), NewObj(2).Put("r", ((V)(4D))).Put("mat", ((V)("metal"))).V));
{
double i_580 = 0;
i_580 = 0D;
while (true) {
if (!((i_580 < 10D))) break;
{
double j_582 = 0;
j_582 = 0D;
while (true) {
if (!((j_582 < 6D))) break;
V c_584 = default;
V lit_585 = default;
c_584 = (SEqS(Get(S_560, "k"), "candy") ? GetIdx(NE_23, ((i_580 + j_582) % 6D)) : GetIdx(NE_23, (((i_580 * 2D) + (j_582 * 3D)) % 6D)));
lit_585 = (on_578 is var _t586 && Truthy(_t586) ? _t586 : (((((i_580 * 7D) + (j_582 * 3D)) % 4D) != 0D) ? V.True : V.False));
Invoke(o_579, "push", Call(box_11, V.Undef, ((V)(((-54D) + (i_580 * 12D)))), ((V)((4D + (j_582 * 12.6)))), ((V)(1.4)), ((V)(9.4)), ((V)(9.4)), ((V)(1D)), (Truthy(lit_585) ? c_584 : Call(shade_21, V.Undef, c_584, ((V)(0.4)))), (Truthy(lit_585) ? Call(em_33, V.Undef, NewObj(1).Put("r", ((V)(2D))).V) : NewObj(2).Put("r", ((V)(2D))).Put("noOut", ((V)(1D))).V)));
j_582++;
}
}
i_580++;
}
}
return o_579;
return default;
}, 2, "build", true)).V;
}, 1, "ledWall", true)).Put("laser", Fn((V _arrowThis594, int _argc587, V S_593, V _a590, V _a591, V _a592, V[] _rest588) => {
return NewObj(7).Put("w", ((V)(42D))).Put("d", ((V)(42D))).Put("round", ((V)(1D))).Put("act", ((V)("party"))).Put("party", ((V)(1D))).Put("glow", Fn((V _arrowThis601, int _argc595, V _a597, V _a598, V _a599, V _a600, V[] _rest596) => {
return NewObj(3).Put("y", ((V)(150D))).Put("r", ((V)(90D))).Put("c", ((V)("url(#gNeon)"))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis610, int _argc602, V P_608, V v_609, V _a606, V _a607, V[] _rest603) => {
V on_611 = default;
V body_612 = default;
V cs_613 = default;
V o_614 = default;
double n_615 = 0;
on_611 = (SEqS(v_609, "on") ? V.True : V.False);
body_612 = (SEqS(Get(S_593, "k"), "royal") ? GOLD_25 : ((V)("#23252e")));
cs_613 = Arr(((V)("#ff3b6b")), ((V)("#4fe0d0")), ((V)("#a6f06a")), ((V)("#8f7bff")), ((V)("#ffd66b")));
o_614 = new ArrBuilder().Add(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(17D)), ((V)(6D)), body_612, NewObj(2).Put("n", ((V)(14D))).Put("mat", ((V)("metal"))).V)).Add(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(0D)), ((V)(9D)), ((V)(100D)), body_612, NewObj(2).Put("n", ((V)(12D))).Put("mat", ((V)("metal"))).V)).Spread(Invoke(Arr(((V)(26D)), ((V)(50D)), ((V)(74D))), "map", Fn((V _arrowThis624, int _argc616, V y_622, V i_623, V _a620, V _a621, V[] _rest617) => {
return Call(cyl_12, V.Undef, ((V)(0D)), y_622, ((V)(0D)), ((V)(9.6)), ((V)(3D)), GetIdx(NE_23, (ToNum(i_623) * 2D)), Call(em_33, V.Undef, NewObj(1).Put("n", ((V)(12D))).V));
}, 2, "", true))).Add(Call(box_11, V.Undef, ((V)(0D)), ((V)(106D)), ((V)(0D)), ((V)(24D)), ((V)(15D)), ((V)(24D)), body_612, NewObj(2).Put("r", ((V)(5D))).Put("mat", ((V)("metal"))).V)).Add(Call(ball_13, V.Undef, ((V)(0D)), ((V)(109D)), ((V)(12D)), ((V)(4.6)), ((V)("#ff4fd8")), Call(em_33, V.Undef, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V))).V;
n_615 = (Truthy(on_611) ? 5D : 3D);
{
double i_625 = 0;
i_625 = 0D;
while (true) {
if (!((i_625 < n_615))) break;
double a_627 = 0;
double ex_628 = 0;
double ey_629 = 0;
a_627 = ((-0.85) + ((i_625 * 1.7) / (n_615 - 1D)));
ex_628 = (FdLibm.Sin(a_627) * 120D);
ey_629 = (114D + (FdLibm.Cos(a_627) * 100D));
Invoke(o_614, "push", Call(prismZ_19, V.Undef, ((V)(12D)), ((V)(13D)), Arr(Arr(((V)((-1D))), ((V)(114D))), Arr(((V)(1D)), ((V)(114D))), Arr(((V)((ex_628 + 2D))), ((V)(ey_629))), Arr(((V)((ex_628 - 2D))), ((V)(ey_629)))), GetIdx(cs_613, i_625), Call(em_33, V.Undef, NewObj(1).Put("op", ((V)(0.7))).V)));
i_625++;
}
}
return o_614;
return default;
}, 2, "build", true)).V;
}, 1, "laser", true)).Put("infinity", Fn((V _arrowThis637, int _argc630, V S_636, V _a633, V _a634, V _a635, V[] _rest631) => {
return NewObj(8).Put("w", ((V)(92D))).Put("d", ((V)(8D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(42D))).Put("act", ((V)("party"))).Put("party", ((V)(1D))).Put("glow", Fn((V _arrowThis644, int _argc638, V _a640, V _a641, V _a642, V _a643, V[] _rest639) => {
return NewObj(3).Put("y", ((V)(40D))).Put("r", ((V)(80D))).Put("c", ((V)("url(#gNeon)"))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis653, int _argc645, V P_651, V v_652, V _a649, V _a650, V[] _rest646) => {
double sh_654 = 0;
V o_655 = default;
sh_654 = (SEqS(v_652, "on") ? 1D : 0D);
o_655 = Arr(Call(slab_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-1D))), ((V)(86D)), ((V)(82D)), ((V)(4D)), (SEqS(Get(S_636, "k"), "royal") ? GOLD_25 : ((V)("#2a2c38"))), NewObj(2).Put("r", ((V)(12D))).Put("mat", ((V)("metal"))).V), Call(slab_14, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(1.2)), ((V)(78D)), ((V)(74D)), ((V)(1D)), ((V)("#0b0d18")), NewObj(2).Put("r", ((V)(9D))).Put("noOut", ((V)(1D))).V));
{
double i_656 = 0;
i_656 = 0D;
while (true) {
if (!((i_656 < 6D))) break;
double s_658 = 0;
double zz_659 = 0;
s_658 = (1D - (i_656 * 0.15));
zz_659 = (2D + (i_656 * 0.7));
Invoke(o_655, "push", Call(slab_14, V.Undef, ((V)(0D)), ((V)((41D - (35D * s_658)))), ((V)(zz_659)), ((V)((72D * s_658))), ((V)((70D * s_658))), ((V)(0.3)), GetIdx(NE_23, ((i_656 + sh_654) % 6D)), Call(em_33, V.Undef, NewObj(1).Put("r", ((V)((9D * s_658)))).V)), Call(slab_14, V.Undef, ((V)(0D)), ((V)(((41D - (35D * s_658)) + 2.6))), ((V)((zz_659 + 0.35))), ((V)(((72D * s_658) - 5.2))), ((V)(((70D * s_658) - 5.2))), ((V)(0.3)), ((V)("#0b0d18")), NewObj(2).Put("r", ((V)((8D * s_658)))).Put("noOut", ((V)(1D))).V));
i_656++;
}
}
return o_655;
return default;
}, 2, "build", true)).V;
}, 1, "infinity", true)).Put("ledArch", Fn((V _arrowThis667, int _argc660, V S_666, V _a663, V _a664, V _a665, V[] _rest661) => {
return NewObj(6).Put("w", ((V)(156D))).Put("d", ((V)(76D))).Put("act", ((V)("party"))).Put("party", ((V)(1D))).Put("glow", Fn((V _arrowThis674, int _argc668, V _a670, V _a671, V _a672, V _a673, V[] _rest669) => {
return NewObj(3).Put("y", ((V)(70D))).Put("r", ((V)(110D))).Put("c", ((V)("url(#gNeon)"))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis683, int _argc675, V P_681, V v_682, V _a679, V _a680, V[] _rest676) => {
V @base_684 = default;
V cs_685 = default;
V o_686 = default;
@base_684 = (SEqS(Get(S_666, "k"), "royal") ? GOLD_25 : ((V)("#2a2c38")));
cs_685 = (SEqS(Get(S_666, "k"), "candy") ? Arr(GetIdx(NE_23, 0D), GetIdx(NE_23, 2D), GetIdx(NE_23, 4D)) : (SEqS(Get(S_666, "k"), "royal") ? Arr(((V)("#fff1b8")), ((V)("#cdb8f5")), ((V)("#bff0ff"))) : Arr(((V)("#4fe0d0")), ((V)("#8f7bff")), ((V)("#ff4fd8")))));
o_686 = Arr();
Invoke(Arr(((V)((-30D))), ((V)(0D)), ((V)(30D))), "forEach", Fn((V _arrowThis695, int _argc687, V z_693, V i_694, V _a691, V _a692, V[] _rest688) => {
return Invoke(o_686, "push", Call(solid_10, V.Undef, NewObj(11).Put("ax", ((V)("z"))).Put("sh", ((V)("arc"))).Put("c", Arr(((V)(0D)), ((V)(0D)))).Put("a", ((V)(72D))).Put("b", ((V)(94D))).Put("th", ((V)(7D))).Put("a0", ((V)(0D))).Put("a1", ((V)(PI_24))).Put("n", ((V)(14D))).Put("rings", Arr(Arr(((V)((ToNum(z_693) - 2.6))), ((V)(0D))), Arr(Add(z_693, ((V)(2.6))), ((V)(0D))))).Put("col", @base_684).V), Call(solid_10, V.Undef, NewObj(13).Put("ax", ((V)("z"))).Put("sh", ((V)("arc"))).Put("c", Arr(((V)(0D)), ((V)(0D)))).Put("a", ((V)(68.4))).Put("b", ((V)(90.4))).Put("th", ((V)(2.4))).Put("a0", ((V)(0.05))).Put("a1", ((V)((PI_24 - 0.05)))).Put("n", ((V)(14D))).Put("rings", Arr(Arr(Add(z_693, ((V)(2.7))), ((V)(0D))), Arr(Add(z_693, ((V)(3.3))), ((V)(0D))))).Put("col", GetIdx(cs_685, (ToNum(Add(i_694, ((V)((SEqS(v_682, "on") ? 1D : 0D))))) % 3D))).Put("emit", ((V)(1D))).Put("noOut", ((V)(1D))).V), Call(box_11, V.Undef, ((V)((-72D))), ((V)(0D)), z_693, ((V)(12D)), ((V)(4D)), ((V)(9D)), @base_684), Call(box_11, V.Undef, ((V)(72D)), ((V)(0D)), z_693, ((V)(12D)), ((V)(4D)), ((V)(9D)), @base_684));
}, 2, "", true));
return o_686;
return default;
}, 2, "build", true)).V;
}, 1, "ledArch", true)).Put("spot", Fn((V _arrowThis703, int _argc696, V S_702, V _a699, V _a700, V _a701, V[] _rest697) => {
return NewObj(7).Put("w", ((V)(62D))).Put("d", ((V)(62D))).Put("round", ((V)(1D))).Put("act", ((V)("party"))).Put("party", ((V)(1D))).Put("glow", Fn((V _arrowThis710, int _argc704, V _a706, V _a707, V _a708, V _a709, V[] _rest705) => {
return NewObj(3).Put("y", ((V)(96D))).Put("r", ((V)(80D))).Put("c", ((V)("url(#gNeon)"))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis719, int _argc711, V P_717, V v_718, V _a715, V _a716, V[] _rest712) => {
V c_720 = default;
V lit_721 = default;
c_720 = (SEqS(Get(S_702, "k"), "royal") ? GOLD_25 : ((V)("#2a2c38")));
lit_721 = (SEqS(v_718, "on") ? WH_28 : ((V)("#ffe9a0")));
return Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(4D)), ((V)(4D)), ((V)(54D)), c_720, NewObj(1).Put("yaw", ((V)(0D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(4D)), ((V)(4D)), ((V)(54D)), c_720, NewObj(1).Put("yaw", ((V)((PI_24 / 3D)))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(4D)), ((V)(4D)), ((V)(54D)), c_720, NewObj(1).Put("yaw", ((V)(((-PI_24) / 3D)))).V), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(2.4)), ((V)(72D)), CH_26, NewObj(1).Put("n", ((V)(6D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(72D)), ((V)(0D)), ((V)(28D)), ((V)(6D)), ((V)(16D)), c_720, NewObj(2).Put("r", ((V)(2D))).Put("mat", ((V)("metal"))).V), Call(box_11, V.Undef, ((V)((-13D))), ((V)(78D)), ((V)(0D)), ((V)(3D)), ((V)(18D)), ((V)(10D)), c_720), Call(box_11, V.Undef, ((V)(13D)), ((V)(78D)), ((V)(0D)), ((V)(3D)), ((V)(18D)), ((V)(10D)), c_720), Call(ball_13, V.Undef, ((V)(0D)), ((V)(78D)), ((V)(0D)), ((V)(12D)), ((V)("#22242e")), NewObj(2).Put("sx", ((V)(0.95))).Put("mat", ((V)("metal"))).V), Call(disc_17, V.Undef, ((V)(0D)), ((V)(90D)), ((V)(10D)), ((V)(7.4)), ((V)(1.6)), lit_721, Call(em_33, V.Undef)), Call(prismZ_19, V.Undef, ((V)(12D)), ((V)(13D)), Arr(Arr(((V)((-6D))), ((V)(92D))), Arr(((V)(6D)), ((V)(92D))), Arr(((V)(36D)), ((V)(176D))), Arr(((V)((-14D))), ((V)(176D)))), ((V)("#fff6c8")), Call(em_33, V.Undef, NewObj(1).Put("op", ((V)(0.35))).V)));
return default;
}, 2, "build", true)).V;
}, 1, "spot", true)).Put("crystal", Fn((V _arrowThis729, int _argc722, V S_728, V _a725, V _a726, V _a727, V[] _rest723) => {
return NewObj(7).Put("w", ((V)(62D))).Put("d", ((V)(62D))).Put("round", ((V)(1D))).Put("act", ((V)("party"))).Put("party", ((V)(1D))).Put("glow", Fn((V _arrowThis736, int _argc730, V _a732, V _a733, V _a734, V _a735, V[] _rest731) => {
return NewObj(3).Put("y", ((V)(70D))).Put("r", ((V)(90D))).Put("c", ((V)("url(#gNeon)"))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis745, int _argc737, V P_743, V v_744, V _a741, V _a742, V[] _rest738) => {
V cs_746 = default;
V o_747 = default;
cs_746 = Arr(((V)("#dff2fb")), ((V)("#cdb8f5")), ((V)("#bff0dc")), ((V)("#fff1b8")), ((V)("#ffd6f2")));
o_747 = Arr(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(25D)), ((V)(10D)), GOLD_25, NewObj(1).Put("n", ((V)(16D))).V), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(0D)), ((V)(19D)), ((V)(4D)), ((V)("#7a1e2c")), NewObj(2).Put("n", ((V)(16D))).Put("soft", ((V)(1D))).V));
Invoke(Arr(Arr(((V)((-12D))), ((V)(46D)), ((V)((-4D)))), Arr(((V)(0D)), ((V)(74D)), ((V)(0D))), Arr(((V)(12D)), ((V)(54D)), ((V)(4D))), Arr(((V)((-4D))), ((V)(36D)), ((V)(10D))), Arr(((V)(8D)), ((V)(30D)), ((V)((-10D))))), "forEach", Fn((V _arrowThis762, int _argc748, V _a750, V i_754, V _a752, V _a753, V[] _rest749) => {
V x_757 = default;
V h_759 = default;
V z_761 = default;
{ V _t755 = ListOf(_a750);
{ V _t756 = GetIdx(_t755, 0D);
x_757 = _t756; }
{ V _t758 = GetIdx(_t755, 1D);
h_759 = _t758; }
{ V _t760 = GetIdx(_t755, 2D);
z_761 = _t760; }
}
return Invoke(o_747, "push", Call(prismZ_19, V.Undef, ((V)((ToNum(z_761) - 4D))), Add(z_761, ((V)(4D))), Arr(Arr(((V)((ToNum(x_757) - 6D))), ((V)(14D))), Arr(Add(x_757, ((V)(6D))), ((V)(14D))), Arr(Add(x_757, ((V)(4D))), Add(((V)(14D)), h_759)), Arr(x_757, Add(Add(((V)(14D)), h_759), ((V)(10D)))), Arr(((V)((ToNum(x_757) - 4D))), Add(((V)(14D)), h_759))), GetIdx(cs_746, (ToNum(Add(i_754, ((V)((SEqS(v_744, "on") ? 2D : 0D))))) % 5D)), Call(em_33, V.Undef, NewObj(1).Put("op", ((V)(0.88))).V)));
}, 2, "", true));
return o_747;
return default;
}, 2, "build", true)).V;
}, 1, "crystal", true)).Put("gcube", Fn((V _arrowThis770, int _argc763, V S_769, V _a766, V _a767, V _a768, V[] _rest764) => {
return NewObj(7).Put("w", ((V)(46D))).Put("d", ((V)(46D))).Put("act", ((V)("sit"))).Put("party", ((V)(1D))).Put("seats", Arr(NewObj(3).Put("x", ((V)(0D))).Put("z", ((V)(0D))).Put("h", ((V)(42D))).V)).Put("glow", Fn((V _arrowThis777, int _argc771, V _a773, V _a774, V _a775, V _a776, V[] _rest772) => {
return NewObj(3).Put("y", ((V)(20D))).Put("r", ((V)(50D))).Put("c", ((V)("url(#gNeon)"))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis786, int _argc778, V P_784, V v_785, V _a782, V _a783, V[] _rest779) => {
V c_787 = default;
c_787 = ((V)((SEqS(Get(S_769, "k"), "candy") ? (SEqS(v_785, "on") ? "#ffd66b" : "#ff9de6") : (SEqS(v_785, "on") ? "#8f7bff" : "#4fe0d0"))));
return Arr(Call(box_11, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(44D)), ((V)(40D)), ((V)(44D)), c_787, NewObj(2).Put("r", ((V)(6D))).Put("emit", ((V)(1D))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)(40D)), ((V)(0D)), ((V)(40D)), ((V)(1.5)), ((V)(40D)), WH_28, Call(em_33, V.Undef, NewObj(2).Put("r", ((V)(6D))).Put("op", ((V)(0.55))).V)));
return default;
}, 2, "build", true)).V;
}, 1, "gcube", true)).V;
SIGNS_38 = NewObj(6).Put("card", NewObj(4).Put("W", ((V)(160D))).Put("H", ((V)(94D))).Put("z", ((V)(0.4))).Put("elev", ((V)(40D))).V).Put("chalk", NewObj(4).Put("W", ((V)(172D))).Put("H", ((V)(106D))).Put("z", ((V)(2.6))).Put("elev", ((V)(44D))).V).Put("marq", NewObj(4).Put("W", ((V)(196D))).Put("H", ((V)(100D))).Put("z", ((V)(4D))).Put("elev", ((V)(44D))).V).Put("neon", NewObj(4).Put("W", ((V)(212D))).Put("H", ((V)(92D))).Put("z", ((V)(2.2))).Put("elev", ((V)(46D))).V).Put("led", NewObj(4).Put("W", ((V)(222D))).Put("H", ((V)(80D))).Put("z", ((V)(2.8))).Put("elev", ((V)(50D))).V).Put("royal", NewObj(4).Put("W", ((V)(212D))).Put("H", ((V)(112D))).Put("z", ((V)(3D))).Put("elev", ((V)(42D))).V).V;
Set(X_8, "SIGNST", NewObj(6).Put("card", NewObj(5).Put("ff", ((V)("'Permanent Marker', 'Comic Sans MS', cursive"))).Put("col", ((V)("#2a1a10"))).Put("sh", ((V)("0 0 1px rgba(42,26,16,0.4)"))).Put("rot", ((V)((-3D)))).Put("cw", ((V)(0.62))).V).Put("chalk", NewObj(5).Put("ff", ((V)("'Gochi Hand', 'Comic Sans MS', cursive"))).Put("col", ((V)("#f4f1ea"))).Put("sh", ((V)("0 0 1.5px rgba(255,255,255,0.7)"))).Put("rot", ((V)(0D))).Put("cw", ((V)(0.55))).V).Put("marq", NewObj(5).Put("ff", ((V)("'Limelight', Georgia, serif"))).Put("col", ((V)("#c4312f"))).Put("sh", ((V)("0 1px 0 rgba(255,255,255,0.6)"))).Put("rot", ((V)(0D))).Put("cw", ((V)(0.66))).V).Put("neon", NewObj(5).Put("ff", ((V)("'Pacifico', 'Brush Script MT', cursive"))).Put("col", ((V)("#ffffff"))).Put("sh", ((V)("0 0 2px #ffffff, 0 0 6px #ff4fd8, 0 0 14px #ff4fd8, 0 0 26px #ff4fd8"))).Put("rot", ((V)((-4D)))).Put("cw", ((V)(0.6))).V).Put("led", NewObj(6).Put("ff", ((V)("'VT323', 'Courier New', monospace"))).Put("col", ((V)("#ffcf6a"))).Put("sh", ((V)("0 0 3px #ff9d4a, 0 0 9px #ff6a00"))).Put("rot", ((V)(0D))).Put("cw", ((V)(0.5))).Put("ls", ((V)("0.08em"))).V).Put("royal", NewObj(5).Put("ff", ((V)("'Cinzel Decorative', Georgia, serif"))).Put("col", ((V)("#ffe9a0"))).Put("sh", ((V)("0 1px 0 #4a2c14, 0 0 6px rgba(255,214,107,0.7)"))).Put("rot", ((V)(0D))).Put("cw", ((V)(0.72))).V).V);
Set(A4_37, "sign", Fn((V _arrowThis795, int _argc788, V S_794, V _a791, V _a792, V _a793, V[] _rest789) => {
V st_796 = default;
V G_797 = default;
V W_798 = default;
V H_799 = default;
V lit_800 = default;
st_796 = Get(S_794, "st");
G_797 = GetK(SIGNS_38, st_796);
W_798 = Get(G_797, "W");
H_799 = Get(G_797, "H");
lit_800 = (((SEqS(st_796, "marq") || SEqS(st_796, "neon")) || SEqS(st_796, "led")) ? V.True : V.False);
return NewObj(9).Put("w", Add(W_798, ((V)(8D)))).Put("d", ((V)(8D))).Put("mount", ((V)("wall"))).Put("elev", Get(G_797, "elev")).Put("sign", st_796).Put("face", NewObj(4).Put("y", ((V)((ToNum(H_799) / 2D)))).Put("z", Get(G_797, "z")).Put("w", ((V)((ToNum(W_798) - (SEqS(st_796, "card") ? 14D : 22D))))).Put("h", ((V)((ToNum(H_799) - (SEqS(st_796, "card") ? 18D : 24D))))).V).Put("txt", ((V)("DANCE!"))).Put("glow", (Truthy(lit_800) ? Fn((V _arrowThis807, int _argc801, V _a803, V _a804, V _a805, V _a806, V[] _rest802) => {
return NewObj(3).Put("y", ((V)((ToNum(H_799) / 2D)))).Put("r", ((V)((ToNum(W_798) * 0.65)))).Put("c", ((V)("url(#gNeon)"))).V;
}, 0, "", true) : V.Null)).Put("build", Fn((V _arrowThis815, int _argc808, V P_814, V _a811, V _a812, V _a813, V[] _rest809) => {
V o_816 = default;
o_816 = Arr();
if (SEqS(st_796, "card")) {
Invoke(o_816, "push", Call(slab_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-1D))), W_798, H_799, ((V)(2.4)), ((V)("#c99a62")), NewObj(2).Put("r", ((V)(2D))).Put("mat", ((V)("wood"))).V), Call(slab_14, V.Undef, ((V)(0D)), ((V)((ToNum(H_799) - 6D))), ((V)(0.4)), ((V)((ToNum(W_798) - 4D))), ((V)(2D)), ((V)(0.4)), ((V)("#b88850")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V), Call(slab_14, V.Undef, ((V)((((-ToNum(W_798)) / 2D) + 10D))), ((V)((ToNum(H_799) - 10D))), ((V)(0.8)), ((V)(22D)), ((V)(9D)), ((V)(0.4)), ((V)("#f6efc8")), NewObj(3).Put("r", ((V)(0D))).Put("op", ((V)(0.8))).Put("noOut", ((V)(1D))).V), Call(slab_14, V.Undef, ((V)(((ToNum(W_798) / 2D) - 12D))), ((V)((-2D))), ((V)(0.8)), ((V)(22D)), ((V)(9D)), ((V)(0.4)), ((V)("#f6efc8")), NewObj(3).Put("r", ((V)(0D))).Put("op", ((V)(0.8))).Put("noOut", ((V)(1D))).V), Call(slab_14, V.Undef, ((V)(((ToNum(W_798) / 2D) - 8D))), ((V)((ToNum(H_799) - 12D))), ((V)(0.6)), ((V)(10D)), ((V)(10D)), ((V)(0.4)), ((V)("#a87a44")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V));
} else {
if (SEqS(st_796, "chalk")) {
Invoke(o_816, "push", Call(slab_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-1D))), W_798, H_799, ((V)(3.6)), ((V)("#a86b36")), NewObj(2).Put("r", ((V)(3D))).Put("mat", ((V)("wood"))).V), Call(slab_14, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(1D)), ((V)((ToNum(W_798) - 12D))), ((V)((ToNum(H_799) - 12D))), ((V)(1D)), ((V)("#2f4a3a")), NewObj(2).Put("r", ((V)(2D))).Put("mat", ((V)("paint"))).V), Call(box_11, V.Undef, ((V)(0D)), ((V)((-4D))), ((V)(3D)), ((V)((ToNum(W_798) - 20D))), ((V)(3D)), ((V)(6D)), ((V)("#a86b36")), NewObj(1).Put("r", ((V)(1D))).V), Call(box_11, V.Undef, ((V)((-24D))), ((V)((-1D))), ((V)(4D)), ((V)(12D)), ((V)(2.4)), ((V)(2.4)), WH_28, NewObj(1).Put("r", ((V)(1D))).V), Call(box_11, V.Undef, ((V)((-8D))), ((V)((-1D))), ((V)(4.6)), ((V)(9D)), ((V)(2.4)), ((V)(2.4)), ((V)("#ffb3c8")), NewObj(1).Put("r", ((V)(1D))).V));
} else {
if (SEqS(st_796, "marq")) {
double n_817 = 0;
double m_818 = 0;
Invoke(o_816, "push", Call(slab_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-1D))), W_798, H_799, ((V)(6D)), ((V)("#b8282a")), NewObj(2).Put("r", ((V)(6D))).Put("mat", ((V)("metal"))).V), Call(slab_14, V.Undef, ((V)(0D)), ((V)(8D)), ((V)(2.2)), ((V)((ToNum(W_798) - 16D))), ((V)((ToNum(H_799) - 16D))), ((V)(1D)), ((V)("#fff6e2")), NewObj(2).Put("r", ((V)(4D))).Put("mat", ((V)("paint"))).V));
n_817 = 9D;
m_818 = 4D;
{
double i_819 = 0;
i_819 = 0D;
while (true) {
if (!((i_819 < n_817))) break;
double x_821 = 0;
x_821 = ((((-ToNum(W_798)) / 2D) + 8D) + ((i_819 * (ToNum(W_798) - 16D)) / (n_817 - 1D)));
Invoke(o_816, "push", Call(ball_13, V.Undef, ((V)(x_821)), ((V)((ToNum(H_799) - 7D))), ((V)(2.4)), ((V)(2.6)), ((V)("#fff1a8")), Call(em_33, V.Undef, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)), Call(ball_13, V.Undef, ((V)(x_821)), ((V)(1.8)), ((V)(2.4)), ((V)(2.6)), ((V)("#fff1a8")), Call(em_33, V.Undef, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)));
i_819++;
}
}
{
double j_822 = 0;
j_822 = 1D;
while (true) {
if (!((j_822 < m_818))) break;
double y_824 = 0;
y_824 = (2D + ((j_822 * (ToNum(H_799) - 10D)) / m_818));
Invoke(o_816, "push", Call(ball_13, V.Undef, ((V)((((-ToNum(W_798)) / 2D) + 4D))), ((V)(y_824)), ((V)(2.4)), ((V)(2.6)), ((V)("#fff1a8")), Call(em_33, V.Undef, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)), Call(ball_13, V.Undef, ((V)(((ToNum(W_798) / 2D) - 4D))), ((V)(y_824)), ((V)(2.4)), ((V)(2.6)), ((V)("#fff1a8")), Call(em_33, V.Undef, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)));
j_822++;
}
}
} else {
if (SEqS(st_796, "neon")) {
InvokeSpread(o_816, "push", new ArrBuilder().Add(Call(slab_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-0.5))), W_798, H_799, ((V)(2D)), ((V)("#cfe6f7")), NewObj(3).Put("r", ((V)(8D))).Put("op", ((V)(0.55))).Put("mat", ((V)("cer"))).V)).Add(Call(slab_14, V.Undef, ((V)(0D)), ((V)(3D)), ((V)((-1.8))), ((V)((ToNum(W_798) - 6D))), ((V)((ToNum(H_799) - 6D))), ((V)(0.6)), ((V)("#1b1030")), NewObj(3).Put("r", ((V)(7D))).Put("op", ((V)(0.5))).Put("noOut", ((V)(1D))).V)).Spread(Invoke(Arr(Arr(((V)((((-ToNum(W_798)) / 2D) + 8D))), ((V)((ToNum(H_799) - 8D)))), Arr(((V)(((ToNum(W_798) / 2D) - 8D))), ((V)((ToNum(H_799) - 8D)))), Arr(((V)((((-ToNum(W_798)) / 2D) + 8D))), ((V)(8D))), Arr(((V)(((ToNum(W_798) / 2D) - 8D))), ((V)(8D)))), "map", Fn((V _arrowThis836, int _argc825, V _a827, V _a828, V _a829, V _a830, V[] _rest826) => {
V x_833 = default;
V y_835 = default;
{ V _t831 = ListOf(_a827);
{ V _t832 = GetIdx(_t831, 0D);
x_833 = _t832; }
{ V _t834 = GetIdx(_t831, 1D);
y_835 = _t834; }
}
return Call(disc_17, V.Undef, x_833, y_835, ((V)(0.5)), ((V)(2.6)), ((V)(2.4)), CH_26);
}, 1, "", true))).V);
} else {
if (SEqS(st_796, "led")) {
Invoke(o_816, "push", Call(slab_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-1D))), W_798, H_799, ((V)(5D)), ((V)("#14151c")), NewObj(2).Put("r", ((V)(4D))).Put("mat", ((V)("metal"))).V), Call(slab_14, V.Undef, ((V)(0D)), ((V)(5D)), ((V)(1.6)), ((V)((ToNum(W_798) - 10D))), ((V)((ToNum(H_799) - 10D))), ((V)(0.6)), ((V)("#262017")), NewObj(2).Put("r", ((V)(2D))).Put("noOut", ((V)(1D))).V), Call(box_11, V.Undef, ((V)((((-ToNum(W_798)) / 2D) + 14D))), ((V)((ToNum(H_799) - 4D))), ((V)(1D)), ((V)(4D)), ((V)(6D)), ((V)(4D)), ((V)("#3a3d44"))), Call(box_11, V.Undef, ((V)(((ToNum(W_798) / 2D) - 14D))), ((V)((ToNum(H_799) - 4D))), ((V)(1D)), ((V)(4D)), ((V)(6D)), ((V)(4D)), ((V)("#3a3d44"))));
} else {
if (SEqS(st_796, "royal")) {
Invoke(o_816, "push", Call(slab_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-1D))), W_798, H_799, ((V)(5D)), GOLD_25, NewObj(1).Put("r", ((V)(8D))).V), Call(slab_14, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(1.6)), ((V)((ToNum(W_798) - 12D))), ((V)((ToNum(H_799) - 12D))), ((V)(1D)), ((V)("#7a1e2c")), NewObj(2).Put("r", ((V)(5D))).Put("soft", ((V)(1D))).V), Call(prismZ_19, V.Undef, ((V)(0D)), ((V)(4D)), Arr(Arr(((V)((-30D))), H_799), Arr(((V)((-18D))), Add(H_799, ((V)(14D)))), Arr(((V)((-8D))), Add(H_799, ((V)(6D)))), Arr(((V)(0D)), Add(H_799, ((V)(20D)))), Arr(((V)(8D)), Add(H_799, ((V)(6D)))), Arr(((V)(18D)), Add(H_799, ((V)(14D)))), Arr(((V)(30D)), H_799)), GOLD_25), Call(ball_13, V.Undef, ((V)(0D)), Add(H_799, ((V)(20D))), ((V)(2D)), ((V)(4D)), ((V)("#e2554a")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
}
}
}
}
}
}
return o_816;
return default;
}, 1, "build", true)).V;
return default;
}, 1, "", true));
L_39 = ((V)("living"));
Dn_40 = ((V)("dance"));
Y_41 = ((V)("backyard"));
NEW_42 = Arr(Arr(((V)(8D)), ((V)("g_chalkHop")), ((V)("Chalk Hopscotch")), Y_41, ((V)("hopscotch"))), Arr(((V)(8D)), ((V)("g_oldSprk")), ((V)("Garden Sprinkler")), Y_41, ((V)("sprinkler"))), Arr(((V)(9D)), ((V)("g_drvHoop")), ((V)("Driveway Hoop")), Y_41, ((V)("hoop"))), Arr(((V)(9D)), ((V)("y_gnome")), ((V)("Garden Gnome")), Y_41, ((V)("gnome"))), Arr(((V)(10D)), ((V)("g_yGoal")), ((V)("Backyard Goal")), Y_41, ((V)("goal"))), Arr(((V)(10D)), ((V)("y_stones")), ((V)("Stepping Stones")), Y_41, ((V)("stones"))), Arr(((V)(11D)), ((V)("g_ringT")), ((V)("Ring Toss")), Y_41, ((V)("ringToss"))), Arr(((V)(12D)), ((V)("g_toss")), ((V)("Beanbag Toss")), Y_41, ((V)("toss"))), Arr(((V)(12D)), ((V)("y_bath")), ((V)("Stone Bird Bath")), Y_41, ((V)("birdbath"))), Arr(((V)(13D)), ((V)("y_bed")), ((V)("Flower Bed")), Y_41, ((V)("flowerBed"))), Arr(((V)(14D)), ((V)("g_tether")), ((V)("Tetherball")), Y_41, ((V)("tether"))), Arr(((V)(15D)), ((V)("g_pong")), ((V)("Ping-Pong Table")), Y_41, ((V)("pong"))), Arr(((V)(15D)), ((V)("y_tiki")), ((V)("Tiki Torch")), Y_41, ((V)("tiki"))), Arr(((V)(16D)), ((V)("g_dome")), ((V)("Climbing Dome")), Y_41, ((V)("dome"))), Arr(((V)(17D)), ((V)("g_proHoop")), ((V)("Pro Hoop")), Y_41, ((V)("hoop"))), Arr(((V)(17D)), ((V)("y_solar")), ((V)("Solar Path Lights")), Y_41, ((V)("solar"))), Arr(((V)(18D)), ((V)("g_putt")), ((V)("Putting Green")), Y_41, ((V)("golf"))), Arr(((V)(19D)), ((V)("g_proGoal")), ((V)("Pro Soccer Goal")), Y_41, ((V)("goal"))), Arr(((V)(20D)), ((V)("y_spin")), ((V)("Wind Spinner")), Y_41, ((V)("spinner"))), Arr(((V)(21D)), ((V)("g_cPong")), ((V)("Candy Ping-Pong")), Y_41, ((V)("pong"))), Arr(((V)(22D)), ((V)("g_jToss")), ((V)("Jellybean Toss")), Y_41, ((V)("toss"))), Arr(((V)(23D)), ((V)("g_cHop")), ((V)("Rainbow Hopscotch")), Y_41, ((V)("hopscotch"))), Arr(((V)(24D)), ((V)("g_cGolf")), ((V)("Candy Mini Golf")), Y_41, ((V)("golf"))), Arr(((V)(25D)), ((V)("g_gHoop")), ((V)("Gumball Hoop")), Y_41, ((V)("hoop"))), Arr(((V)(26D)), ((V)("g_sky")), ((V)("Sky Climber")), Y_41, ((V)("dome"))), Arr(((V)(27D)), ((V)("y_urn")), ((V)("Royal Garden Urn")), Y_41, ((V)("urn"))), Arr(((V)(28D)), ((V)("g_rTether")), ((V)("Royal Tetherball")), Y_41, ((V)("tether"))), Arr(((V)(28D)), ((V)("y_rTiki")), ((V)("Golden Torch")), Y_41, ((V)("tiki"))), Arr(((V)(29D)), ((V)("g_gHoop2")), ((V)("Golden Hoop")), Y_41, ((V)("hoop"))), Arr(((V)(29D)), ((V)("y_rGnome")), ((V)("Royal Gnome")), Y_41, ((V)("gnome"))), Arr(((V)(11D)), ((V)("x_sgCard")), ((V)("Cardboard Sign")), Dn_40, ((V)("sign")), NewObj(1).Put("st", ((V)("card"))).V, ((V)(20D))), Arr(((V)(13D)), ((V)("x_sgChalk")), ((V)("Chalkboard Sign")), Dn_40, ((V)("sign")), NewObj(1).Put("st", ((V)("chalk"))).V), Arr(((V)(16D)), ((V)("x_sgMarq")), ((V)("Marquee Bulb Sign")), Dn_40, ((V)("sign")), NewObj(1).Put("st", ((V)("marq"))).V), Arr(((V)(20D)), ((V)("x_sgNeon")), ((V)("Neon Script Sign")), Dn_40, ((V)("sign")), NewObj(1).Put("st", ((V)("neon"))).V), Arr(((V)(24D)), ((V)("x_sgLed")), ((V)("LED Ticker Sign")), Dn_40, ((V)("sign")), NewObj(1).Put("st", ((V)("led"))).V), Arr(((V)(29D)), ((V)("x_sgRoyal")), ((V)("Royal Gold Marquee")), Dn_40, ((V)("sign")), NewObj(1).Put("st", ((V)("royal"))).V), Arr(((V)(16D)), ((V)("x_ledWall")), ((V)("LED Light Wall")), Dn_40, ((V)("ledWall"))), Arr(((V)(18D)), ((V)("x_laser")), ((V)("Laser Tower")), Dn_40, ((V)("laser"))), Arr(((V)(19D)), ((V)("x_gcube")), ((V)("Glow Cube Seat")), Dn_40, ((V)("gcube"))), Arr(((V)(20D)), ((V)("x_spot")), ((V)("Moving-Head Spotlight")), Dn_40, ((V)("spot"))), Arr(((V)(21D)), ((V)("x_infin")), ((V)("Infinity Mirror")), Dn_40, ((V)("infinity"))), Arr(((V)(23D)), ((V)("x_cLed")), ((V)("Rainbow LED Wall")), Dn_40, ((V)("ledWall"))), Arr(((V)(24D)), ((V)("x_ledArch")), ((V)("LED Tunnel Arch")), Dn_40, ((V)("ledArch"))), Arr(((V)(25D)), ((V)("x_cCube")), ((V)("Candy Glow Cube")), Dn_40, ((V)("gcube"))), Arr(((V)(27D)), ((V)("x_auArch")), ((V)("Aurora Light Arch")), Dn_40, ((V)("ledArch"))), Arr(((V)(28D)), ((V)("x_crysS")), ((V)("Crystal Light Sculpture")), Dn_40, ((V)("crystal"))), Arr(((V)(29D)), ((V)("x_rLaser")), ((V)("Royal Laser Tower")), Dn_40, ((V)("laser"))), Arr(((V)(30D)), ((V)("x_rInf")), ((V)("Royal Infinity Mirror")), Dn_40, ((V)("infinity"))));
WT_43 = NewObj(26).Put("hopscotch", ((V)(0.6))).Put("sprinkler", ((V)(0.6))).Put("hoop", ((V)(1.2))).Put("gnome", ((V)(0.4))).Put("goal", ((V)(1.3))).Put("stones", ((V)(0.5))).Put("ringToss", ((V)(0.7))).Put("toss", ((V)(0.9))).Put("birdbath", ((V)(0.7))).Put("flowerBed", ((V)(0.8))).Put("tether", ((V)(1D))).Put("pong", ((V)(1.6))).Put("tiki", ((V)(0.5))).Put("dome", ((V)(1.8))).Put("solar", ((V)(0.6))).Put("golf", ((V)(1.4))).Put("spinner", ((V)(0.5))).Put("urn", ((V)(0.9))).Put("sign", ((V)(0.8))).Put("ledWall", ((V)(1.8))).Put("laser", ((V)(1.6))).Put("gcube", ((V)(0.9))).Put("spot", ((V)(1.4))).Put("infinity", ((V)(1.6))).Put("ledArch", ((V)(2.4))).Put("crystal", ((V)(2D))).V;
BK_44 = NewObj(0).V;
Invoke(Get(X_8, "BANDS"), "forEach", Fn((V _arrowThis844, int _argc837, V b_843, V _a840, V _a841, V _a842, V[] _rest838) => {
return SetK(BK_44, Get(b_843, "k"), b_843);
}, 1, "", true));
Invoke(NEW_42, "forEach", Fn((V _arrowThis866, int _argc845, V _a847, V _a848, V _a849, V _a850, V[] _rest846) => {
V band_867 = default;
V S_868 = default;
V D_869 = default;
V price_870 = default;
V lv_853 = default;
V id_855 = default;
V n_857 = default;
V room_859 = default;
V arch_861 = default;
V ex_863 = default;
V @fixed_865 = default;
{ V _t851 = ListOf(_a847);
{ V _t852 = GetIdx(_t851, 0D);
lv_853 = _t852; }
{ V _t854 = GetIdx(_t851, 1D);
id_855 = _t854; }
{ V _t856 = GetIdx(_t851, 2D);
n_857 = _t856; }
{ V _t858 = GetIdx(_t851, 3D);
room_859 = _t858; }
{ V _t860 = GetIdx(_t851, 4D);
arch_861 = _t860; }
{ V _t862 = GetIdx(_t851, 5D);
ex_863 = _t862; }
{ V _t864 = GetIdx(_t851, 6D);
@fixed_865 = _t864; }
}
band_867 = Get(Invoke(X_8, "bandOf", lv_853), "k");
S_868 = Object_assign(NewObj(1).Put("k", band_867).V, (ex_863 is var _t871 && Truthy(_t871) ? _t871 : NewObj(0).V));
D_869 = InvokeK(A4_37, arch_861, S_868);
price_870 = (@fixed_865 is var _t873 && Truthy(_t873) ? _t873 : ((V)((Round((((50D + (ToNum(lv_853) * 28D)) * ToNum((GetK(WT_43, arch_861) is var _t872 && Truthy(_t872) ? _t872 : ((V)(1D))))) / 10D)) * 10D))));
Object_assign(D_869, NewObj(10).Put("n", n_857).Put("cat", room_859).Put("price", price_870).Put("cols", Get(GetK(BK_44, band_867), "cols")).Put("lv", lv_853).Put("band", band_867).Put("arch", arch_861).Put("room", room_859).Put("start", (false ? V.True : V.False)).Put("id", id_855).V);
if (Truthy((Get(D_869, "mount") is var _t874 && Truthy(_t874) ? _t874 : Get(D_869, "small")))) {
Set(D_869, "noBlock", ((V)(1D)));
}
SetK(Get(X_8, "CAT"), id_855, D_869);
Invoke(Get(X_8, "ITEMS"), "push", NewObj(10).Put("id", id_855).Put("n", n_857).Put("room", room_859).Put("lv", lv_853).Put("band", band_867).Put("arch", arch_861).Put("price", price_870).Put("start", (false ? V.True : V.False)).Put("hidden", (false ? V.True : V.False)).Put("surf", (false ? V.True : V.False)).V);
return default;
}, 1, "", true));
Object_assign(Get(X_8, "ARCH"), A4_37);
Object_assign(Get(X_8, "SPEC"), NewObj(8).Put("l_halo", NewObj(1).Put("k", ((V)("halo"))).V).Put("l_laser", NewObj(1).Put("k", ((V)("laser"))).V).Put("l_truss", NewObj(1).Put("k", ((V)("truss"))).V).Put("l_crys", NewObj(1).Put("k", ((V)("crys"))).V).Put("yl_fairy", NewObj(1).Put("k", ((V)("fairy"))).V).Put("yl_festoon", NewObj(1).Put("k", ((V)("festoon"))).V).Put("yl_lantern", NewObj(1).Put("k", ((V)("lantern"))).V).Put("yl_torch", NewObj(1).Put("k", ((V)("torch"))).V).V);
Invoke(Arr(Arr(((V)(16D)), ((V)("l_halo")), ((V)("LED Halo Rings")), ((V)("style")), ((V)("light")), ((V)("dance"))), Arr(((V)(19D)), ((V)("l_laser")), ((V)("Laser Light Rig")), ((V)("style")), ((V)("light")), ((V)("dance"))), Arr(((V)(23D)), ((V)("l_truss")), ((V)("Spotlight Truss")), ((V)("style")), ((V)("light")), ((V)("dance"))), Arr(((V)(28D)), ((V)("l_crys")), ((V)("Crystal LED Chandelier")), ((V)("style")), ((V)("light")), ((V)("dance"))), Arr(((V)(10D)), ((V)("yl_fairy")), ((V)("Fairy Lights")), Y_41, ((V)("ylight"))), Arr(((V)(18D)), ((V)("yl_festoon")), ((V)("Festoon Bulbs")), Y_41, ((V)("ylight"))), Arr(((V)(22D)), ((V)("yl_lantern")), ((V)("Paper Lanterns")), Y_41, ((V)("ylight"))), Arr(((V)(27D)), ((V)("yl_torch")), ((V)("Garden Torches")), Y_41, ((V)("ylight")))), "forEach", Fn((V _arrowThis894, int _argc875, V _a877, V _a878, V _a879, V _a880, V[] _rest876) => {
double price_895 = 0;
V m_896 = default;
V lv_883 = default;
V id_885 = default;
V n_887 = default;
V room_889 = default;
V arch_891 = default;
V only_893 = default;
{ V _t881 = ListOf(_a877);
{ V _t882 = GetIdx(_t881, 0D);
lv_883 = _t882; }
{ V _t884 = GetIdx(_t881, 1D);
id_885 = _t884; }
{ V _t886 = GetIdx(_t881, 2D);
n_887 = _t886; }
{ V _t888 = GetIdx(_t881, 3D);
room_889 = _t888; }
{ V _t890 = GetIdx(_t881, 4D);
arch_891 = _t890; }
{ V _t892 = GetIdx(_t881, 5D);
only_893 = _t892; }
}
price_895 = (Round((((50D + (ToNum(lv_883) * 28D)) * (SEqS(arch_891, "light") ? 1.1 : 0.9)) / 10D)) * 10D);
m_896 = NewObj(10).Put("id", id_885).Put("n", n_887).Put("room", room_889).Put("lv", lv_883).Put("band", Get(Invoke(X_8, "bandOf", lv_883), "k")).Put("arch", arch_891).Put("price", ((V)(price_895))).Put("start", (false ? V.True : V.False)).Put("hidden", (false ? V.True : V.False)).Put("surf", (true ? V.True : V.False)).V;
if (Truthy(only_893)) {
Set(m_896, "only", only_893);
}
SetK(Get(X_8, "SURF"), id_885, m_896);
Invoke(Get(X_8, "ITEMS"), "push", m_896);
return default;
}, 1, "", true));
Invoke(Get(X_8, "ITEMS"), "sort", Fn((V _arrowThis905, int _argc897, V a_903, V b_904, V _a901, V _a902, V[] _rest898) => {
return ((V)((ToNum(Get(a_903, "lv")) - ToNum(Get(b_904, "lv")))));
}, 2, "", true));
rescale_45 = Fn((V _arrowThis914, int _argc906, V D_912, V f_913, V _a910, V _a911, V[] _rest907) => {
if ((!(Truthy(f_913)) || (System.Math.Abs((ToNum(f_913) - 1D)) < 0.001))) {
return default;
}
Set(D_912, "zs", ((V)((ToNum((Get(D_912, "zs") is var _t915 && Truthy(_t915) ? _t915 : ((V)(1D)))) * ToNum(f_913)))));
OpSet(D_912, "w", 2, f_913);
OpSet(D_912, "d", 2, f_913);
if (Truthy(Get(D_912, "use"))) {
Set(D_912, "use", Object_assign(NewObj(0).V, Get(D_912, "use"), NewObj(2).Put("x", ((V)((ToNum(Get(Get(D_912, "use"), "x")) * ToNum(f_913))))).Put("z", ((V)((ToNum(Get(Get(D_912, "use"), "z")) * ToNum(f_913))))).V));
}
if (Truthy(Get(D_912, "seats"))) {
Set(D_912, "seats", Invoke(Get(D_912, "seats"), "map", Fn((V _arrowThis923, int _argc916, V s_922, V _a919, V _a920, V _a921, V[] _rest917) => {
return Object_assign(NewObj(0).V, s_922, NewObj(3).Put("x", ((V)((ToNum(Get(s_922, "x")) * ToNum(f_913))))).Put("z", ((V)((ToNum(Get(s_922, "z")) * ToNum(f_913))))).Put("h", ((V)((ToNum(Get(s_922, "h")) * ToNum(f_913))))).V);
}, 1, "", true)));
}
return default;
}, 2, "", true);
ramp_46 = Fn((V _arrowThis932, int _argc924, V D_930, V k_931, V _a928, V _a929, V[] _rest925) => {
return ((V)((1D + (Max(0D, Min(1D, ((ToNum((Get(D_930, "lv") is var _t933 && Truthy(_t933) ? _t933 : ((V)(1D)))) - 6D) / 24D))) * ToNum(k_931)))));
}, 2, "", true);
Invoke(Object_values(Get(X_8, "CAT")), "forEach", Fn((V _arrowThis941, int _argc934, V D_940, V _a937, V _a938, V _a939, V[] _rest935) => {
double f_942 = 0;
double cap_943 = 0;
if (Truthy(((((!(Truthy(Invoke(Arr(((V)("tv")), ((V)("tvstand")), ((V)("wallTV")), ((V)("projector"))), "includes", Get(D_940, "arch")))) ? V.True : V.False) is var _t944 && Truthy(_t944) ? _t944 : Get(D_940, "small")) is var _t945 && Truthy(_t945) ? _t945 : (SEqS(Get(D_940, "id"), "radio") ? V.True : V.False)) is var _t946 && Truthy(_t946) ? _t946 : (!(Truthy(Get(D_940, "zs"))) ? V.True : V.False)))) {
return default;
}
f_942 = (ToNum(Call(ramp_46, V.Undef, D_940, ((V)(0.45)))) / ToNum(Call(ramp_46, V.Undef, D_940, ((V)(0.9)))));
Call(rescale_45, V.Undef, D_940, ((V)(f_942)));
if (Truthy((Get(D_940, "mount") is var _t947 && !Truthy(_t947) ? _t947 : Get(D_940, "elev")))) {
Set(D_940, "elev", ((V)(Round((ToNum(Get(D_940, "elev")) / System.Math.Sqrt(f_942))))));
}
cap_943 = (SEqS(Get(D_940, "arch"), "projector") ? 560D : (SEqS(Get(D_940, "arch"), "wallTV") ? 430D : 0D));
if (Truthy((((V)(cap_943)) is var _t948 && !Truthy(_t948) ? _t948 : (((ToNum(Get(D_940, "w")) * ToNum(Get(X_8, "FS"))) > cap_943) ? V.True : V.False)))) {
Call(rescale_45, V.Undef, D_940, ((V)((cap_943 / (ToNum(Get(D_940, "w")) * ToNum(Get(X_8, "FS")))))));
}
return default;
}, 1, "", true));
TBF_47 = NewObj(21).Put("tbToaster", ((V)(0.66))).Put("tbTeapot", ((V)(0.7))).Put("tbJar", ((V)(0.66))).Put("tbCake", ((V)(0.62))).Put("tbFruit", ((V)(0.66))).Put("tbMixer", ((V)(0.64))).Put("tbCup", ((V)(0.7))).Put("tbPerfume", ((V)(0.72))).Put("tbSoap", ((V)(0.72))).Put("tbDuck", ((V)(0.75))).Put("tbBooks", ((V)(0.75))).Put("tbClock", ((V)(0.7))).Put("tbRadio", ((V)(0.68))).Put("tbGlobe", ((V)(0.68))).Put("tbSnow", ((V)(0.72))).Put("tbTrophy", ((V)(0.72))).Put("tbCandles", ((V)(0.68))).Put("tbBox", ((V)(0.72))).Put("tbVase", ((V)(0.62))).Put("miniTV", ((V)(0.72))).Put("handheld", ((V)(0.6))).V;
Invoke(Object_values(Get(X_8, "CAT")), "forEach", Fn((V _arrowThis956, int _argc949, V D_955, V _a952, V _a953, V _a954, V[] _rest950) => {
V f_957 = default;
f_957 = GetK(TBF_47, Get(D_955, "arch"));
if (Truthy((f_957 is var _t958 && !Truthy(_t958) ? _t958 : Get(D_955, "small")))) {
Call(rescale_45, V.Undef, D_955, f_957);
}
return default;
}, 1, "", true));
Invoke(Get(X_8, "CACHE"), "clear");
Set(X_8, "rescale", rescale_45);
topBase_48 = Get(X_8, "topOf");
Set(X_8, "topOf", Fn((V _arrowThis966, int _argc959, V t_965, V _a962, V _a963, V _a964, V[] _rest960) => {
V D_967 = default;
V v_968 = default;
D_967 = GetK(Get(X_8, "CAT"), t_965);
if (Truthy((D_967 is var _t969 && !Truthy(_t969) ? _t969 : (Get(D_967, "_tz").IsNullish ? V.True : V.False)))) {
Set(D_967, "_tz", (Get(D_967, "zs") is var _t970 && Truthy(_t970) ? _t970 : ((V)(1D))));
}
v_968 = Call(topBase_48, V.Undef, t_965);
return (Truthy(D_967) ? ((V)(((ToNum(v_968) / ToNum(Get(D_967, "_tz"))) * ToNum((Get(D_967, "zs") is var _t971 && Truthy(_t971) ? _t971 : ((V)(1D))))))) : v_968);
return default;
}, 1, "", true));
Set(X_8, "CRDEF", ((V)(1.09)));
Set(X_8, "SZDEF", NewObj(11).Put("bookcase", ((V)(2.15))).Put("wallTV", ((V)(1.45))).Put("aquaCol", ((V)(0.5))).Put("handheld", ((V)(1.05))).Put("dj", ((V)(1.7))).Put("projector", ((V)(1.25))).Put("arcade", ((V)(1.05))).Put("stage", ((V)(2.5))).Put("tv", ((V)(1.2))).Put("pit", ((V)(1.35))).Put("poster", ((V)(1.05))).V);
Object_assign(Get(X_8, "SZDEF"), NewObj(89).Put("sofa", ((V)(1.09))).Put("armchair", ((V)(1.09))).Put("lsofa", ((V)(1.15))).Put("usofa", ((V)(1.15))).Put("longSofa", ((V)(1.15))).Put("modEnd", ((V)(1.15))).Put("modMid", ((V)(1.15))).Put("modCorner", ((V)(1.15))).Put("plant", ((V)(1.18))).Put("lamp", ((V)(1.26))).Put("pouf", ((V)(0.8))).Put("beanpile", ((V)(1.22))).Put("tvstand", ((V)(0.83))).Put("monstera", ((V)(1.24))).Put("pottedPalm", ((V)(1.45))).Put("cactus", ((V)(1.18))).Put("flowerPot", ((V)(0.92))).Put("aquaBig", ((V)(1.09))).Put("mushLamp", ((V)(1.21))).Put("lowShelf", ((V)(1.15))).Put("fridge", ((V)(1.5))).Put("hutch", ((V)(1.55))).Put("table", ((V)(0.86))).Put("chair", ((V)(1.16))).Put("stool", ((V)(1.22))).Put("bowl", ((V)(1.25))).Put("tub", ((V)(1.11))).Put("bsink", ((V)(1.45))).Put("basket", ((V)(1.19))).Put("rack", ((V)(1.54))).Put("shower", ((V)(1.49))).Put("bed", ((V)(1.2))).Put("nightstand", ((V)(0.91))).Put("wardrobe", ((V)(1.46))).Put("chest", ((V)(0.85))).Put("dresser", ((V)(1.23))).Put("swing", ((V)(1.23))).Put("pool", ((V)(1.14))).Put("slide", ((V)(1.32))).Put("stand", ((V)(1.29))).Put("grill", ((V)(1.32))).Put("tramp", ((V)(1.25))).Put("house", ((V)(1.58))).Put("merry", ((V)(0.86))).Put("tree", ((V)(1.81))).Put("fountain", ((V)(1.27))).Put("bush", ((V)(1.09))).Put("sunflower", ((V)(1.27))).Put("lantern", ((V)(1.1))).Put("hoop", ((V)(1.48))).Put("goal", ((V)(1.47))).Put("ringToss", ((V)(1.09))).Put("toss", ((V)(1.2))).Put("birdbath", ((V)(1.48))).Put("tether", ((V)(1.37))).Put("pong", ((V)(1.28))).Put("tiki", ((V)(1.3))).Put("dome", ((V)(1.49))).Put("spinner", ((V)(1.25))).Put("urn", ((V)(1.13))).Put("sprinkler", ((V)(0.86))).Put("juke", ((V)(1.16))).Put("pillar", ((V)(1.21))).Put("claw", ((V)(1.21))).Put("spkWall", ((V)(1.24))).Put("spkTower", ((V)(1.31))).Put("gcube", ((V)(1.15))).Put("ledArch", ((V)(2.05))).Put("crystal", ((V)(1.43))).Put("ledWall", ((V)(1.58))).Put("infinity", ((V)(1.32))).Put("gallery", ((V)(1.35))).Put("wallClock", ((V)(0.83))).Put("sconce", ((V)(1.22))).Put("miniTV", ((V)(0.89))).Put("tankSmall", ((V)(0.8))).Put("tbCup", ((V)(0.71))).Put("tbClock", ((V)(0.76))).Put("tbCake", ((V)(0.91))).Put("tbFruit", ((V)(0.87))).Put("tbDuck", ((V)(0.79))).Put("tbPerfume", ((V)(0.77))).Put("tbRadio", ((V)(0.86))).Put("tbVase", ((V)(0.85))).Put("bonsai", ((V)(0.79))).Put("tbSoap", ((V)(0.87))).Put("tbSnow", ((V)(0.86))).Put("tbCandles", ((V)(0.83))).Put("tbBox", ((V)(0.85))).V);
Set(X_8, "setSize", Fn((V _arrowThis980, int _argc972, V arch_978, V k_979, V _a976, V _a977, V[] _rest973) => {
Invoke(Object_values(Get(X_8, "CAT")), "forEach", Fn((V _arrowThis988, int _argc981, V D_987, V _a984, V _a985, V _a986, V[] _rest982) => {
double f_989 = 0;
if (!SEq(Get(D_987, "arch"), arch_978)) {
return default;
}
f_989 = (ToNum(k_979) / ToNum((Get(D_987, "_uk") is var _t990 && Truthy(_t990) ? _t990 : ((V)(1D)))));
if ((System.Math.Abs((f_989 - 1D)) < 0.0001)) {
return default;
}
Call(rescale_45, V.Undef, D_987, ((V)(f_989)));
Set(D_987, "_uk", k_979);
return default;
}, 1, "", true));
Invoke(Get(X_8, "CACHE"), "clear");
return default;
}, 2, "", true));
ELEC_49 = New(G("Set"), Arr(((V)("tv")), ((V)("tvstand")), ((V)("miniTV")), ((V)("wallTV")), ((V)("projector")), ((V)("speaker")), ((V)("spkWall")), ((V)("sub")), ((V)("smokeSpk")), ((V)("partyBox")), ((V)("spkTower")), ((V)("juke")), ((V)("dj")), ((V)("arcade")), ((V)("pinball")), ((V)("claw")), ((V)("racer")), ((V)("consoleSet")), ((V)("handheld")), ((V)("tbRadio")), ((V)("tbToaster")), ((V)("tbMixer")), ((V)("lamp")), ((V)("tableLamp")), ((V)("mushLamp")), ((V)("sconce")), ((V)("neonSign")), ((V)("pillar")), ((V)("fridge")), ((V)("stove")), ((V)("lantern")), ((V)("aquaBig")), ((V)("aquaCol")), ((V)("tankSmall")), ((V)("ledWall")), ((V)("laser")), ((V)("infinity")), ((V)("ledArch")), ((V)("spot")), ((V)("crystal")), ((V)("gcube"))));
FLOORA_50 = New(G("Set"), Arr(((V)("rug")), ((V)("rug2")), ((V)("mat"))));
GAMES_51 = New(G("Set"), Arr(((V)("swing")), ((V)("slide")), ((V)("seesaw")), ((V)("sandbox")), ((V)("pool")), ((V)("tramp")), ((V)("merry")), ((V)("house")), ((V)("hopscotch")), ((V)("hoop")), ((V)("goal")), ((V)("toss")), ((V)("ringToss")), ((V)("tether")), ((V)("sprinkler")), ((V)("dome")), ((V)("golf")), ((V)("pong"))));
GARDEN_52 = New(G("Set"), Arr(((V)("sunflower")), ((V)("tree")), ((V)("bush")), ((V)("fountain")), ((V)("flowerPot")), ((V)("plant")), ((V)("pottedPalm")), ((V)("monstera")), ((V)("cactus")), ((V)("gnome")), ((V)("birdbath")), ((V)("flowerBed")), ((V)("stones")), ((V)("spinner")), ((V)("urn"))));
YGLOW_53 = New(G("Set"), Arr(((V)("lantern")), ((V)("tiki")), ((V)("solar"))));
IN_54 = Arr(NewObj(2).Put("k", ((V)("furn"))).Put("n", ((V)("Furniture"))).V, NewObj(2).Put("k", ((V)("walls"))).Put("n", ((V)("Walls"))).V, NewObj(2).Put("k", ((V)("floors"))).Put("n", ((V)("Floors"))).V, NewObj(2).Put("k", ((V)("ceil"))).Put("n", ((V)("Ceiling"))).V, NewObj(2).Put("k", ((V)("elec"))).Put("n", ((V)("Electronics"))).V);
OUT_55 = Arr(NewObj(2).Put("k", ((V)("patio"))).Put("n", ((V)("Patio"))).V, NewObj(2).Put("k", ((V)("games"))).Put("n", ((V)("Games"))).V, NewObj(2).Put("k", ((V)("garden"))).Put("n", ((V)("Garden"))).V, NewObj(2).Put("k", ((V)("glow"))).Put("n", ((V)("Lights"))).V, NewObj(2).Put("k", ((V)("lawn"))).Put("n", ((V)("Lawn & Fence"))).V);
Set(X_8, "CATS", Fn((V _arrowThis998, int _argc991, V rk_997, V _a994, V _a995, V _a996, V[] _rest992) => {
return (Truthy((GetK(Get(X_8, "ROOMS"), rk_997) is var _t999 && !Truthy(_t999) ? _t999 : Get(GetK(Get(X_8, "ROOMS"), rk_997), "out"))) ? OUT_55 : IN_54);
}, 1, "", true));
Set(X_8, "catOf", Fn((V _arrowThis1007, int _argc1000, V id_1006, V _a1003, V _a1004, V _a1005, V[] _rest1001) => {
V M_1008 = default;
V D_1009 = default;
V a_1010 = default;
M_1008 = GetK(Get(X_8, "SURF"), id_1006);
if (Truthy(M_1008)) {
V a_1011 = default;
a_1011 = Get(M_1008, "arch");
return ((V)((SEqS(a_1011, "floor") ? "floors" : (SEqS(a_1011, "light") ? "ceil" : ((SEqS(a_1011, "fence") || SEqS(a_1011, "ground")) ? "lawn" : (SEqS(a_1011, "ylight") ? "glow" : "walls"))))));
}
D_1009 = GetK(Get(X_8, "CAT"), id_1006);
if (!(Truthy(D_1009))) {
return ((V)("furn"));
}
a_1010 = Get(D_1009, "arch");
if (SEqS(Get(D_1009, "room"), "backyard")) {
return ((V)((Truthy(Invoke(GAMES_51, "has", a_1010)) ? "games" : (Truthy(Invoke(GARDEN_52, "has", a_1010)) ? "garden" : (Truthy(Invoke(YGLOW_53, "has", a_1010)) ? "glow" : "patio")))));
}
if (Truthy(Invoke(ELEC_49, "has", a_1010))) {
return ((V)("elec"));
}
if (Truthy((Get(D_1009, "flat") is var _t1012 && Truthy(_t1012) ? _t1012 : Invoke(FLOORA_50, "has", a_1010)))) {
return ((V)("floors"));
}
if (Truthy(Get(D_1009, "mount"))) {
return ((V)("walls"));
}
return ((V)("furn"));
return default;
}, 1, "", true));
Set(X_8, "surfOk", Fn((V _arrowThis1021, int _argc1013, V id_1019, V rk_1020, V _a1017, V _a1018, V[] _rest1014) => {
V M_1022 = default;
M_1022 = GetK(Get(X_8, "SURF"), id_1019);
return ((((!(!(Truthy(M_1022))) && !(Truthy(Get(M_1022, "hidden")))) ? V.True : V.False) is var _t1023 && !Truthy(_t1023) ? _t1023 : Invoke(Invoke(X_8, "slotsOf", rk_1020), "includes", Get(M_1022, "arch"))) is var _t1024 && !Truthy(_t1024) ? _t1024 : ((!(Truthy(Get(M_1022, "only"))) || SEq(Get(M_1022, "only"), rk_1020)) ? V.True : V.False));
return default;
}, 2, "", true));
Set(X_8, "EXT2", ((V)(1D)));
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
