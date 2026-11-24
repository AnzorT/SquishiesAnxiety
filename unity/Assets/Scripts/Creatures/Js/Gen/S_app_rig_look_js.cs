// app/rig-look.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_app_rig_look_js
    {

        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V NS_8 = default;
V WIDTH_9 = default;
V uid_10 = default;
V lineOf_11 = default;
V body_12 = default;
V mk_13 = default;
V filterFor_14 = default;
V paint_15 = default;
V apply_16 = default;
V App_17 = default;
V lookFor_18 = default;
V live_19 = default;
V alive_20 = default;
V track_21 = default;
V last_22 = default;
V rig_23 = default;
V wrap_24 = default;
if (_self1.IsNullish) _self1 = GlobalV;
lineOf_11 = Fn((V _self25, int _argc26, V key_32, V n_33, V _a30, V _a31, V[] _rest27) => {
V c_34 = default;
if (_self25.IsNullish) _self25 = GlobalV;
c_34 = GetK((Get(G("window"), "SQ_LOOK_LINES") is var _t35 && Truthy(_t35) ? _t35 : NewObj(0).V), key_32);
if ((!(Truthy(c_34)) || !(Truthy(GetK(WIDTH_9, n_33))))) {
return V.Null;
}
return NewObj(2).Put("w", GetK(WIDTH_9, n_33)).Put("col", (SEqN(n_33, 4D) ? GetIdx(c_34, 1D) : GetIdx(c_34, 0D))).V;
return default;
}, 2, "lineOf", false);
body_12 = Fn((V _self36, int _argc37, V I_43, V _a40, V _a41, V _a42, V[] _rest38) => {
V sh_44 = default;
V g_45 = default;
if (_self36.IsNullish) _self36 = GlobalV;
sh_44 = (I_43 is var _t46 && !Truthy(_t46) ? _t46 : Get(I_43, "shadow"));
g_45 = (Truthy((sh_44 is var _t47 && !Truthy(_t47) ? _t47 : Get(sh_44, "parentNode"))) ? Get(sh_44, "nextElementSibling") : V.Null);
return (Truthy((g_45 is var _t48 && !Truthy(_t48) ? _t48 : (SEqS(Get(g_45, "tagName"), "g") ? V.True : V.False))) ? g_45 : V.Null);
return default;
}, 1, "body", false);
mk_13 = Fn((V _self49, int _argc50, V tag_56, V attrs_57, V parent_58, V _a55, V[] _rest51) => {
V e_59 = default;
V a_60 = default;
if (_self49.IsNullish) _self49 = GlobalV;
e_59 = Invoke(G("document"), "createElementNS", NS_8, tag_56);
{
foreach (V _k61 in ForInKeys(attrs_57)) {
a_60 = _k61;
Invoke(e_59, "setAttribute", a_60, GetK(attrs_57, a_60));
}
}
if (Truthy(parent_58)) {
Invoke(parent_58, "appendChild", e_59);
}
return e_59;
return default;
}, 3, "mk", false);
filterFor_14 = Fn((V _self62, int _argc63, V g_69, V _a66, V _a67, V _a68, V[] _rest64) => {
V f_70 = default;
V svg_71 = default;
V defs_72 = default;
V a_73 = default;
V m_74 = default;
if (_self62.IsNullish) _self62 = GlobalV;
f_70 = Get(g_69, "__sqLook");
if (Truthy((f_70 is var _t75 && !Truthy(_t75) ? _t75 : Get(f_70, "isConnected")))) {
return f_70;
}
svg_71 = Get(g_69, "ownerSVGElement");
defs_72 = (Invoke(svg_71, "querySelector", ((V)("defs"))) is var _t76 && Truthy(_t76) ? _t76 : Invoke(svg_71, "insertBefore", Invoke(G("document"), "createElementNS", NS_8, ((V)("defs"))), Get(svg_71, "firstChild")));
f_70 = Call(mk_13, V.Undef, ((V)("filter")), NewObj(6).Put("id", ((V)(JsStrBuf.Begin().S("sqlook").N(PreInc(ref uid_10, 1D)).End()))).Put("x", ((V)("-15%"))).Put("y", ((V)("-15%"))).Put("width", ((V)("130%"))).Put("height", ((V)("130%"))).Put("color-interpolation-filters", ((V)("sRGB"))).V, defs_72);
a_73 = Call(mk_13, V.Undef, ((V)("feComponentTransfer")), NewObj(2).Put("in", ((V)("SourceAlpha"))).Put("result", ((V)("a"))).V, f_70);
Call(mk_13, V.Undef, ((V)("feFuncA")), NewObj(3).Put("type", ((V)("linear"))).Put("slope", ((V)("2.5"))).Put("intercept", ((V)("-0.5"))).V, a_73);
Set(f_70, "__m", Call(mk_13, V.Undef, ((V)("feMorphology")), NewObj(4).Put("in", ((V)("a"))).Put("operator", ((V)("dilate"))).Put("radius", ((V)("0.8"))).Put("result", ((V)("d"))).V, f_70));
Set(f_70, "__c", Call(mk_13, V.Undef, ((V)("feFlood")), NewObj(1).Put("flood-color", ((V)("#3f2f26"))).V, f_70));
Call(mk_13, V.Undef, ((V)("feComposite")), NewObj(3).Put("in2", ((V)("d"))).Put("operator", ((V)("in"))).Put("result", ((V)("o"))).V, f_70);
m_74 = Call(mk_13, V.Undef, ((V)("feMerge")), NewObj(0).V, f_70);
Call(mk_13, V.Undef, ((V)("feMergeNode")), NewObj(1).Put("in", ((V)("o"))).V, m_74);
Call(mk_13, V.Undef, ((V)("feMergeNode")), NewObj(1).Put("in", ((V)("SourceGraphic"))).V, m_74);
Set(g_69, "__sqLook", f_70);
return f_70;
return default;
}, 1, "filterFor", false);
paint_15 = Fn((V _self77, int _argc78, V ctrl_84, V key_85, V n_86, V _a83, V[] _rest79) => {
V I_87 = default;
V g_88 = default;
V L_89 = default;
V f_90 = default;
V own_91 = default;
if (_self77.IsNullish) _self77 = GlobalV;
I_87 = (ctrl_84 is var _t92 && !Truthy(_t92) ? _t92 : Get(ctrl_84, "_I"));
g_88 = Call(body_12, V.Undef, I_87);
if (!(Truthy(g_88))) {
return (false ? V.True : V.False);
}
L_89 = Call(lineOf_11, V.Undef, key_85, n_86);
if (!(Truthy(L_89))) {
Set(Get(g_88, "style"), "filter", ((V)("")));
return (true ? V.True : V.False);
}
f_90 = Call(filterFor_14, V.Undef, g_88);
Invoke(Get(f_90, "__m"), "setAttribute", ((V)("radius")), Get(L_89, "w"));
Invoke(Get(f_90, "__c"), "setAttribute", ((V)("flood-color")), Get(L_89, "col"));
own_91 = Invoke(g_88, "getAttribute", ((V)("filter")));
if (SEqS(own_91, "none")) {
own_91 = ((V)(""));
}
Set(Get(g_88, "style"), "filter", ((V)(JsStrBuf.Begin().S((Truthy(own_91) ? JsStrBuf.Begin().V(own_91).S(" ").End() : "")).S("url(#").V(Get(f_90, "id")).S(")").End())));
return (true ? V.True : V.False);
return default;
}, 3, "paint", false);
apply_16 = Fn((V _self93, int _argc94, V ctrl_100, V key_101, V n_102, V _a99, V[] _rest95) => {
V tries_103 = default;
if (_self93.IsNullish) _self93 = GlobalV;
if (!(Truthy(ctrl_100))) {
return default;
}
Set(ctrl_100, "__sqLookN", n_102);
tries_103 = ((V)(0D));
Call(Named(go_111 => Fn((V _self104, int _argc105, V _a107, V _a108, V _a109, V _a110, V[] _rest106) => {
if (_self104.IsNullish) _self104 = GlobalV;
if (!SEq(Get(ctrl_100, "__sqLookN"), n_102)) {
return default;
}
if ((!(Truthy(Call(paint_15, V.Undef, ctrl_100, key_101, n_102))) && (PreInc(ref tries_103, 1D) < 270D))) {
Call(G("setTimeout"), V.Undef, go_111.v, ((V)(30D)));
}
return default;
}, 0, "go", false)), V.Undef);
return default;
}, 3, "apply", false);
lookFor_18 = Fn((V _self112, int _argc113, V key_119, V _a116, V _a117, V _a118, V[] _rest114) => {
V L_120 = default;
if (_self112.IsNullish) _self112 = GlobalV;
L_120 = (Get(App_17, "state") is var _t121 && !Truthy(_t121) ? _t121 : Get(Get(App_17, "state"), "looks"));
if (((!(Truthy(L_120)) || !(Truthy(Get(L_120, "keys")))) || LtN(Invoke(Get(L_120, "keys"), "indexOf", key_119), 0D))) {
return ((V)(0D));
}
return (Truthy((Get(L_120, "over") is var _t122 && !Truthy(_t122) ? _t122 : (!GetK(Get(L_120, "over"), key_119).IsNullish ? V.True : V.False))) ? GetK(Get(L_120, "over"), key_119) : Get(L_120, "n"));
return default;
}, 1, "lookFor", false);
alive_20 = Fn((V _self123, int _argc124, V r_130, V _a127, V _a128, V _a129, V[] _rest125) => {
V I_131 = default;
if (_self123.IsNullish) _self123 = GlobalV;
I_131 = Get(Get(r_130, "c"), "_I");
return ((!(!(Truthy(I_131))) ? V.True : V.False) is var _t133 && !Truthy(_t133) ? _t133 : ((!(Truthy(Get(I_131, "shadow"))) ? V.True : V.False) is var _t132 && Truthy(_t132) ? _t132 : Get(Get(I_131, "shadow"), "isConnected")));
return default;
}, 1, "alive", false);
track_21 = Fn((V _self134, int _argc135, V ctrl_141, V key_142, V _a139, V _a140, V[] _rest136) => {
if (_self134.IsNullish) _self134 = GlobalV;
if ((!(Truthy(ctrl_141)) || !(Truthy(key_142)))) {
return default;
}
live_19 = Invoke(live_19, "filter", Fn((V _self143, int _argc144, V r_150, V _a147, V _a148, V _a149, V[] _rest145) => {
if (_self143.IsNullish) _self143 = GlobalV;
return ((!SEq(Get(r_150, "c"), ctrl_141) ? V.True : V.False) is var _t151 && !Truthy(_t151) ? _t151 : Call(alive_20, V.Undef, r_150));
return default;
}, 1, "", false));
Invoke(live_19, "push", NewObj(2).Put("c", ctrl_141).Put("k", key_142).V);
Call(apply_16, V.Undef, ctrl_141, key_142, Call(lookFor_18, V.Undef, key_142));
return default;
}, 2, "track", false);
wrap_24 = Fn((V _self152, int _argc153, V R_159, V _a156, V _a157, V _a158, V[] _rest154) => {
V mount_160 = default;
if (_self152.IsNullish) _self152 = GlobalV;
if (Truthy((((!(Truthy(R_159)) ? V.True : V.False) is var _t161 && Truthy(_t161) ? _t161 : Get(R_159, "__sqLook")) is var _t162 && Truthy(_t162) ? _t162 : (!string.Equals(Typeof(Get(R_159, "mount")), "function") ? V.True : V.False)))) {
return R_159;
}
if (string.Equals(Typeof(Get(R_159, "setLook")), "function")) {
try {
Invoke(R_159, "setLook", ((V)(0D)));
} catch (System.Exception _ex163) {
V e_164 = default;
e_164 = Caught(_ex163);
Invoke(G("console"), "error", ((V)("[RigLook]")), e_164);
}
}
mount_160 = Get(R_159, "mount");
Set(R_159, "mount", Fn((V _self165, int _argc166, V host_172, V key_173, V o_174, V _a171, V[] _rest167) => {
V c_176 = default;
if (_self165.IsNullish) _self165 = GlobalV;
V _arguments175 = Arguments(_argc166, host_172, key_173, o_174, _a171, _rest167);
c_176 = Invoke(mount_160, "apply", _self165, _arguments175);
try {
if (!(Truthy((o_174 is var _t177 && !Truthy(_t177) ? _t177 : (!Get(o_174, "look").IsNullish ? V.True : V.False))))) {
Call(track_21, V.Undef, c_176, key_173);
}
} catch (System.Exception _ex178) {
V e_179 = default;
e_179 = Caught(_ex178);
Invoke(G("console"), "error", ((V)("[RigLook]")), e_179);
}
return c_176;
return default;
}, 3, "", false));
Set(R_159, "__sqLook", (true ? V.True : V.False));
return R_159;
return default;
}, 1, "wrap", false);
if (Truthy(Get(G("window"), "RigLook"))) {
return default;
}
NS_8 = ((V)("http://www.w3.org/2000/svg"));
WIDTH_9 = NewObj(3).Put("2", ((V)(0.6))).Put("3", ((V)(1D))).Put("4", ((V)(1D))).V;
uid_10 = ((V)(0D));
Set(G("window"), "RigLook", NewObj(3).Put("apply", apply_16).Put("lineOf", lineOf_11).Put("WIDTH", WIDTH_9).V);
App_17 = Get(G("window"), "SquishApp");
if (!(Truthy(App_17))) {
return default;
}
live_19 = Arr();
last_22 = ((V)(""));
Invoke(App_17, "on", ((V)("state")), Fn((V _self180, int _argc181, V _a183, V _a184, V _a185, V _a186, V[] _rest182) => {
V now_187 = default;
if (_self180.IsNullish) _self180 = GlobalV;
now_187 = Invoke(G("JSON"), "stringify", ((Get(App_17, "state") is var _t188 && !Truthy(_t188) ? _t188 : Get(Get(App_17, "state"), "looks")) is var _t189 && Truthy(_t189) ? _t189 : V.Null));
if (SEq(now_187, last_22)) {
return default;
}
last_22 = now_187;
live_19 = Invoke(live_19, "filter", alive_20);
Invoke(live_19, "forEach", Fn((V _self190, int _argc191, V r_197, V _a194, V _a195, V _a196, V[] _rest192) => {
if (_self190.IsNullish) _self190 = GlobalV;
Call(apply_16, V.Undef, Get(r_197, "c"), Get(r_197, "k"), Call(lookFor_18, V.Undef, Get(r_197, "k")));
return default;
}, 1, "", false));
return default;
}, 0, "", false));
rig_23 = Get(G("window"), "RiveRig");
try {
Object_defineProperty(G("window"), ((V)("RiveRig")), NewObj(4).Put("configurable", (true ? V.True : V.False)).Put("enumerable", (true ? V.True : V.False)).Put("get", Fn((V _self198, int _argc199, V _a201, V _a202, V _a203, V _a204, V[] _rest200) => {
if (_self198.IsNullish) _self198 = GlobalV;
return rig_23;
return default;
}, 0, "get", false)).Put("set", Fn((V _self205, int _argc206, V R_212, V _a209, V _a210, V _a211, V[] _rest207) => {
if (_self205.IsNullish) _self205 = GlobalV;
rig_23 = Call(wrap_24, V.Undef, R_212);
return default;
}, 1, "set", false)).V);
if (Truthy(rig_23)) {
Call(wrap_24, V.Undef, rig_23);
}
} catch (System.Exception _ex213) {
V e_214 = default;
e_214 = Caught(_ex213);
Invoke(G("console"), "error", ((V)("[RigLook]")), e_214);
}
return default;
}, 0, "", false), V.Undef);
        }
    }
}
