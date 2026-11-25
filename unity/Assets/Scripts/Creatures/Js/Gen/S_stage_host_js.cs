// stage-host.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_stage_host_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("(translate|scale|rotate)\\(([^)]*)\\)", "g");
        static readonly System.Text.RegularExpressions.Regex RX1 = JsRegExp.Compile("inset\\(([^)]*)\\)", "");
        static readonly System.Text.RegularExpressions.Regex RX2 = JsRegExp.Compile("\\s+", "");
        static readonly System.Text.RegularExpressions.Regex RX3 = JsRegExp.Compile("%$", "");
        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V G_8, V _a5, V _a6, V _a7, V[] _rest3) => {
V S_9 = default;
V api_10 = default;
V RE_11 = default;
V matrix_12 = default;
V num_13 = default;
api_10 = Fn((V _self14, int _argc15, V page_21, V _a18, V _a19, V _a20, V[] _rest16) => {
V s_22 = default;
s_22 = GetK(S_9, page_21);
return ((s_22 is var _t23 && !Truthy(_t23) ? _t23 : GetK(Get(s_22, "win"), ((V)(JsStrBuf.Begin().V(page_21).S("Stage").End())))) is var _t24 && Truthy(_t24) ? _t24 : V.Null);
return default;
}, 1, "api", false);
matrix_12 = Fn((V _self25, int _argc26, V tf_32, V _a29, V _a30, V _a31, V[] _rest27) => {
V m_33 = default;
V r_34 = default;
V a_35 = default;
V t_36 = default;
V i_37 = default;
V q_38 = default;
V c_39 = default;
V s_40 = default;
m_33 = Arr(((V)(1D)), ((V)(0D)), ((V)(0D)), ((V)(1D)), ((V)(0D)), ((V)(0D)));
Set(RE_11, "lastIndex", ((V)(0D)));
while (Truthy((r_34 = Invoke(RE_11, "exec", (tf_32 is var _t41 && Truthy(_t41) ? _t41 : ((V)(""))))))) {
a_35 = Invoke(GetIdx(r_34, 2D), "split", ((V)(",")));
{
i_37 = ((V)(0D));
while (true) {
if (!(Lt(i_37, Get(a_35, "length")))) break;
SetK(a_35, i_37, ((V)(ParseFloat(GetK(a_35, i_37)))));
PostInc(ref i_37, 1D);
}
}
if (SEqS(GetIdx(r_34, 1D), "translate")) {
t_36 = Arr(((V)(1D)), ((V)(0D)), ((V)(0D)), ((V)(1D)), GetIdx(a_35, 0D), (GtN(Get(a_35, "length"), 1D) ? GetIdx(a_35, 1D) : ((V)(0D))));
} else {
if (SEqS(GetIdx(r_34, 1D), "scale")) {
t_36 = Arr(GetIdx(a_35, 0D), ((V)(0D)), ((V)(0D)), (GtN(Get(a_35, "length"), 1D) ? GetIdx(a_35, 1D) : GetIdx(a_35, 0D)), ((V)(0D)), ((V)(0D)));
} else {
q_38 = ((V)(((ToNum(GetIdx(a_35, 0D)) * System.Math.PI) / 180D)));
c_39 = ((V)(FdLibm.Cos(ToNum(q_38))));
s_40 = ((V)(FdLibm.Sin(ToNum(q_38))));
t_36 = Arr(c_39, s_40, ((V)((-ToNum(s_40)))), c_39, ((V)(0D)), ((V)(0D)));
}
}
m_33 = Arr(((V)(((ToNum(GetIdx(m_33, 0D)) * ToNum(GetIdx(t_36, 0D))) + (ToNum(GetIdx(m_33, 2D)) * ToNum(GetIdx(t_36, 1D)))))), ((V)(((ToNum(GetIdx(m_33, 1D)) * ToNum(GetIdx(t_36, 0D))) + (ToNum(GetIdx(m_33, 3D)) * ToNum(GetIdx(t_36, 1D)))))), ((V)(((ToNum(GetIdx(m_33, 0D)) * ToNum(GetIdx(t_36, 2D))) + (ToNum(GetIdx(m_33, 2D)) * ToNum(GetIdx(t_36, 3D)))))), ((V)(((ToNum(GetIdx(m_33, 1D)) * ToNum(GetIdx(t_36, 2D))) + (ToNum(GetIdx(m_33, 3D)) * ToNum(GetIdx(t_36, 3D)))))), Add(((V)(((ToNum(GetIdx(m_33, 0D)) * ToNum(GetIdx(t_36, 4D))) + (ToNum(GetIdx(m_33, 2D)) * ToNum(GetIdx(t_36, 5D)))))), GetIdx(m_33, 4D)), Add(((V)(((ToNum(GetIdx(m_33, 1D)) * ToNum(GetIdx(t_36, 4D))) + (ToNum(GetIdx(m_33, 3D)) * ToNum(GetIdx(t_36, 5D)))))), GetIdx(m_33, 5D)));
}
return m_33;
return default;
}, 1, "matrix", false);
num_13 = Fn((V _self43, int _argc44, V v_50, V d_51, V _a48, V _a49, V[] _rest45) => {
V n_52 = default;
n_52 = ((V)(ParseFloat(v_50)));
return (double.IsNaN(ToNum(n_52)) ? d_51 : n_52);
return default;
}, 2, "num", false);
S_9 = (Get(G_8, "__stages") is var _t53 && Truthy(_t53) ? _t53 : Set(G_8, "__stages", NewObj(0).V));
RE_11 = NewRegExp(RX0, "(translate|scale|rotate)\\(([^)]*)\\)", "g");
Set(G_8, "__stage", NewObj(7).Put("size", Fn((V _self54, int _argc55, V page_61, V w_62, V h_63, V _a60, V[] _rest56) => {
V s_64 = default;
s_64 = GetK(S_9, page_61);
if (Truthy(s_64)) {
Set(Get(s_64, "win"), "innerWidth", w_62);
Set(Get(s_64, "win"), "innerHeight", h_63);
}
return default;
}, 3, "size", false)).Put("ready", Fn((V _self65, int _argc66, V page_72, V _a69, V _a70, V _a71, V[] _rest67) => {
return (!(!(Truthy(Call(api_10, V.Undef, page_72)))) ? V.True : V.False);
return default;
}, 1, "ready", false)).Put("call", Fn((V _self73, int _argc74, V page_80, V fn_81, V json_82, V _a79, V[] _rest75) => {
V a_83 = default;
a_83 = Call(api_10, V.Undef, page_80);
if ((!(Truthy(a_83)) || !string.Equals(Typeof(GetK(a_83, fn_81)), "function"))) {
return (false ? V.True : V.False);
}
Invoke(GetK(a_83, fn_81), "apply", a_83, (Truthy(json_82) ? Invoke(G("JSON"), "parse", json_82) : Arr()));
return (true ? V.True : V.False);
return default;
}, 3, "call", false)).Put("out", Fn((V _self84, int _argc85, V page_91, V _a88, V _a89, V _a90, V[] _rest86) => {
V s_92 = default;
V k_93 = default;
V o_94 = default;
s_92 = GetK(S_9, page_91);
if (!(Truthy(s_92))) {
return ((V)("[]"));
}
k_93 = ((V)(JsStrBuf.Begin().S("__").V(page_91).S("Out").End()));
o_94 = GetK(Get(s_92, "win"), k_93);
if ((!(Truthy(o_94)) || !(Truthy(Get(o_94, "length"))))) {
return ((V)("[]"));
}
SetK(Get(s_92, "win"), k_93, Arr());
return Invoke(G("JSON"), "stringify", o_94);
return default;
}, 1, "out", false)).Put("read", Fn((V _self95, int _argc96, V page_102, V _a99, V _a100, V _a101, V[] _rest97) => {
V a_103 = default;
V @out_104 = default;
a_103 = Call(api_10, V.Undef, page_102);
@out_104 = Arr();
if ((!(Truthy(a_103)) || !(Truthy(Get(a_103, "_C"))))) {
return @out_104;
}
Invoke(Get(a_103, "_C"), "forEach", Fn((V _self105, int _argc106, V c_112, V _a109, V _a110, V _a111, V[] _rest107) => {
V st_113 = default;
V m_114 = default;
V I_115 = default;
V row_116 = default;
V ss_117 = default;
V sm_118 = default;
if (!(Truthy(Get(c_112, "el")))) {
return default;
}
st_113 = Get(Get(c_112, "el"), "style");
m_114 = Call(matrix_12, V.Undef, Get(st_113, "transform"));
I_115 = Get(c_112, "I");
row_116 = Arr(Get(c_112, "id"), Get(c_112, "key"), Get(c_112, "inner"), GetIdx(m_114, 0D), GetIdx(m_114, 1D), GetIdx(m_114, 2D), GetIdx(m_114, 3D), GetIdx(m_114, 4D), GetIdx(m_114, 5D), Call(num_13, V.Undef, Get(st_113, "opacity"), ((V)(1D))), Call(num_13, V.Undef, Get(st_113, "zIndex"), ((V)(0D))), ((V)((Truthy((((!(Truthy(I_115)) || !(Truthy(Get(I_115, "generic")))) ? V.True : V.False) is var _t119 && Truthy(_t119) ? _t119 : Get(I_115, "ready"))) ? 1D : 0D))));
if (Truthy(Get(c_112, "sh"))) {
ss_117 = Get(Get(c_112, "sh"), "style");
sm_118 = Call(matrix_12, V.Undef, Get(ss_117, "transform"));
Invoke(row_116, "push", GetIdx(sm_118, 0D), GetIdx(sm_118, 1D), GetIdx(sm_118, 2D), GetIdx(sm_118, 3D), GetIdx(sm_118, 4D), GetIdx(sm_118, 5D), Call(num_13, V.Undef, Get(ss_117, "opacity"), ((V)(1D))), Call(num_13, V.Undef, Get(ss_117, "zIndex"), ((V)(0D))));
}
Invoke(@out_104, "push", row_116);
return default;
}, 1, "", false));
return @out_104;
return default;
}, 1, "read", false)).Put("host", Fn((V _self120, int _argc121, V page_127, V id_128, V _a125, V _a126, V[] _rest122) => {
V a_129 = default;
V c_130 = default;
a_129 = Call(api_10, V.Undef, page_127);
c_130 = ((a_129 is var _t131 && !Truthy(_t131) ? _t131 : Get(a_129, "_C")) is var _t132 && !Truthy(_t132) ? _t132 : Invoke(Get(a_129, "_C"), "get", id_128));
return (Truthy(c_130) ? Get(c_130, "inner") : V.Null);
return default;
}, 2, "host", false)).Put("clip", Fn((V _self133, int _argc134, V page_140, V _a137, V _a138, V _a139, V[] _rest135) => {
V s_141 = default;
V cp_142 = default;
V r_143 = default;
V v_144 = default;
V W_145 = default;
V px_146 = default;
V right_147 = default;
V left_148 = default;
s_141 = GetK(S_9, page_140);
if (!(Truthy(s_141))) {
return V.Null;
}
cp_142 = Get(Get(Get(s_141, "board"), "style"), "clipPath");
if (!(Truthy(cp_142))) {
return V.Null;
}
r_143 = Invoke(NewRegExp(RX1, "inset\\(([^)]*)\\)", ""), "exec", cp_142);
if (!(Truthy(r_143))) {
return V.Null;
}
v_144 = Invoke(Invoke(GetIdx(r_143, 1D), "trim"), "split", NewRegExp(RX2, "\\s+", ""));
W_145 = Get(Get(s_141, "win"), "innerWidth");
px_146 = Fn((V _self149, int _argc150, V x_156, V _a153, V _a154, V _a155, V[] _rest151) => {
return ((V)((Truthy(Invoke(NewRegExp(RX3, "%$", ""), "test", x_156)) ? ((ParseFloat(x_156) / 100D) * ToNum(W_145)) : ParseFloat(x_156))));
return default;
}, 1, "", false);
right_147 = Call(px_146, V.Undef, (GetIdx(v_144, 1D) is var _t157 && Truthy(_t157) ? _t157 : GetIdx(v_144, 0D)));
left_148 = Call(px_146, V.Undef, ((GetIdx(v_144, 3D) is var _t158 && Truthy(_t158) ? _t158 : GetIdx(v_144, 1D)) is var _t159 && Truthy(_t159) ? _t159 : GetIdx(v_144, 0D)));
return Arr(left_148, ((V)((ToNum(W_145) - ToNum(right_147)))));
return default;
}, 1, "clip", false)).V);
return default;
}, 1, "", false), V.Undef, (!string.Equals(GTypeof("globalThis"), "undefined") ? G("globalThis") : GlobalV));
        }
    }
}
