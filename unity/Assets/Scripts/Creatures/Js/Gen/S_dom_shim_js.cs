// dom-shim.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_dom_shim_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("\\s*(>)\\s*|\\s+|([^\\s>]+)", "g");
        static readonly System.Text.RegularExpressions.Regex RX1 = JsRegExp.Compile("([a-zA-Z][\\w-]*)|#([\\w-]+)|\\.([\\w-]+)|\\[\\s*([\\w:-]+)\\s*(?:([\\^$*~|]?=)\\s*(?:\"([^\"]*)\"|'([^']*)'|([^\\]\\s]*)))?\\s*\\]|(\\*)", "g");
        static readonly System.Text.RegularExpressions.Regex RX2 = JsRegExp.Compile("\\s+", "");
        static readonly System.Text.RegularExpressions.Regex RX3 = JsRegExp.Compile("^<([a-zA-Z][\\w:.-]*)", "");
        static readonly System.Text.RegularExpressions.Regex RX4 = JsRegExp.Compile("\\s*([^\\s\"'>\\/=]+)(?:\\s*=\\s*(?:\"([^\"]*)\"|'([^']*)'|([^\\s\"'=<>`]+)))?|\\s*(\\/?)>", "g");
        static readonly System.Text.RegularExpressions.Regex RX5 = JsRegExp.Compile("[a-zA-Z]|[-+]?(?:\\d*\\.\\d+|\\d+\\.?)(?:[eE][-+]?\\d+)?", "g");
        static readonly System.Text.RegularExpressions.Regex RX6 = JsRegExp.Compile("[a-zA-Z]", "");
        static readonly System.Text.RegularExpressions.Regex RX7 = JsRegExp.Compile("[\\s,]+", "");
        static readonly System.Text.RegularExpressions.Regex RX8 = JsRegExp.Compile("^(defs|clipPath|mask|linearGradient|radialGradient|pattern|filter|style|title|desc|metadata|script|symbol|marker)$", "");
        static readonly System.Text.RegularExpressions.Regex RX9 = JsRegExp.Compile("(matrix|translate|scale|rotate|skewX|skewY)\\s*\\(([^)]*)\\)", "g");
        static readonly System.Text.RegularExpressions.Regex RX10 = JsRegExp.Compile("^\\.\\/", "");
        static readonly System.Text.RegularExpressions.Regex RX11 = JsRegExp.Compile("-([a-z])", "g");
        static readonly System.Text.RegularExpressions.Regex RX12 = JsRegExp.Compile("^-webkit-", "");
        static readonly System.Text.RegularExpressions.Regex RX13 = JsRegExp.Compile("^webkit-", "");
        static readonly System.Text.RegularExpressions.Regex RX14 = JsRegExp.Compile("[A-Z]", "g");
        static readonly System.Text.RegularExpressions.Regex RX15 = JsRegExp.Compile("&(#x[0-9a-f]+|#\\d+|[a-z]+);", "gi");
        static readonly System.Text.RegularExpressions.Regex RX16 = JsRegExp.Compile(">", "g");
        static readonly System.Text.RegularExpressions.Regex RX17 = JsRegExp.Compile("<", "g");
        static readonly System.Text.RegularExpressions.Regex RX18 = JsRegExp.Compile("\u00a0", "g");
        static readonly System.Text.RegularExpressions.Regex RX19 = JsRegExp.Compile("\"", "g");
        static readonly System.Text.RegularExpressions.Regex RX20 = JsRegExp.Compile("&", "g");
        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V root_8, V _a5, V _a6, V _a7, V[] _rest3) => {
V SVG_NS_9 = default;
V Node_10 = default;
V Text_11 = default;
V Fragment_12 = default;
V camel_13 = default;
V kebab_14 = default;
V Style_15 = default;
V ClassList_16 = default;
V NEXT_ID_17 = default;
V Element_18 = default;
V walk_19 = default;
V SEL_CACHE_20 = default;
V parseSelectors_21 = default;
V splitTop_22 = default;
V compound_23 = default;
V matchCompound_24 = default;
V matchSteps_25 = default;
V matchesList_26 = default;
V VOID_HTML_27 = default;
V ENT_28 = default;
V unescape_29 = default;
V parseInto_30 = default;
V escAttr_31 = default;
V escText_32 = default;
V serialize_33 = default;
V F_34 = default;
V SVGRect_35 = default;
V bbox_36 = default;
V rect_37 = default;
V F32_38 = default;
V U32_39 = default;
V nextUp_40 = default;
V fromBounds_41 = default;
V unite_42 = default;
V mapRect_43 = default;
V validUnitDivide_44 = default;
V unitQuadRoots_45 = default;
V cubicExtremaT_46 = default;
V evalCubic_47 = default;
V SINZ_48 = default;
V COSZ_49 = default;
V PIF_50 = default;
V DEG_51 = default;
V rotM_52 = default;
V arcToConics_53 = default;
V conicExtremaT_54 = default;
V evalConic_55 = default;
V pathTight_56 = default;
V boxOf_57 = default;
V mul_58 = default;
V parseTransform_59 = default;
V CANVASES_60 = default;
V Ctx2D_61 = default;
V install_62 = default;
Node_10 = Fn((V _self63, int _argc64, V _a66, V _a67, V _a68, V _a69, V[] _rest65) => {
Set(_self63, "parentNode", V.Null);
Set(_self63, "childNodes", Arr());
return default;
}, 0, "Node", false);
Text_11 = Fn((V _self70, int _argc71, V t_77, V _a74, V _a75, V _a76, V[] _rest72) => {
Invoke(Node_10, "call", _self70);
Set(_self70, "nodeType", ((V)(3D)));
Set(_self70, "data", ((V)(ToStrS(t_77))));
return default;
}, 1, "Text", false);
Fragment_12 = Fn((V _self78, int _argc79, V _a81, V _a82, V _a83, V _a84, V[] _rest80) => {
Invoke(Node_10, "call", _self78);
Set(_self78, "nodeType", ((V)(11D)));
return default;
}, 0, "Fragment", false);
Style_15 = Fn((V _self85, int _argc86, V _a88, V _a89, V _a90, V _a91, V[] _rest87) => {

return default;
}, 0, "Style", false);
ClassList_16 = Fn((V _self92, int _argc93, V el_99, V _a96, V _a97, V _a98, V[] _rest94) => {
Set(_self92, "el", el_99);
return default;
}, 1, "ClassList", false);
Element_18 = Fn((V _self100, int _argc101, V tag_107, V ns_108, V _a105, V _a106, V[] _rest102) => {
Invoke(Node_10, "call", _self100);
Set(_self100, "nodeType", ((V)(1D)));
Set(_self100, "namespaceURI", (ns_108 is var _t109 && Truthy(_t109) ? _t109 : SVG_NS_9));
Set(_self100, "localName", (SEq(Get(_self100, "namespaceURI"), SVG_NS_9) ? tag_107 : Invoke(((V)(ToStrS(tag_107))), "toLowerCase")));
Set(_self100, "tagName", Set(_self100, "nodeName", (SEq(Get(_self100, "namespaceURI"), SVG_NS_9) ? tag_107 : Invoke(Get(_self100, "localName"), "toUpperCase"))));
Set(_self100, "_attrs", Arr());
Set(_self100, "style", New(Style_15));
Set(_self100, "_listeners", NewObj(0).V);
Set(_self100, "__id", ((V)(PostInc(ref NEXT_ID_17, 1D))));
return default;
}, 2, "Element", false);
walk_19 = Fn((V _self110, int _argc111, V el_117, V fn_118, V _a115, V _a116, V[] _rest112) => {
V i_119 = default;
V c_120 = default;
{
i_119 = ((V)(0D));
while (true) {
if (!(Lt(i_119, Get(Get(el_117, "childNodes"), "length")))) break;
c_120 = GetK(Get(el_117, "childNodes"), i_119);
if (SEqN(Get(c_120, "nodeType"), 1D)) {
Call(fn_118, V.Undef, c_120);
Call(walk_19, V.Undef, c_120, fn_118);
}
PostInc(ref i_119, 1D);
}
}
return default;
}, 2, "walk", false);
parseSelectors_21 = Fn((V _self122, int _argc123, V sel_129, V _a126, V _a127, V _a128, V[] _rest124) => {
V list_130 = default;
if (Truthy(GetK(SEL_CACHE_20, sel_129))) {
return GetK(SEL_CACHE_20, sel_129);
}
list_130 = Invoke(Call(splitTop_22, V.Undef, sel_129, ((V)(","))), "map", Fn((V _self131, int _argc132, V one_138, V _a135, V _a136, V _a137, V[] _rest133) => {
V steps_139 = default;
V comb_140 = default;
V re_141 = default;
V m_142 = default;
steps_139 = Arr();
comb_140 = ((V)(" "));
re_141 = NewRegExp(RX0, "\\s*(>)\\s*|\\s+|([^\\s>]+)", "g");
one_138 = Invoke(one_138, "trim");
while (Truthy((m_142 = Invoke(re_141, "exec", one_138)))) {
if (Truthy(GetIdx(m_142, 1D))) {
comb_140 = ((V)(">"));
continue;
}
if (!(Truthy(GetIdx(m_142, 2D)))) {
if (Truthy(Get(steps_139, "length"))) {
comb_140 = ((V)((SEqS(comb_140, ">") ? ">" : " ")));
}
continue;
}
Invoke(steps_139, "push", NewObj(2).Put("comb", (Truthy(Get(steps_139, "length")) ? comb_140 : V.Null)).Put("parts", Call(compound_23, V.Undef, GetIdx(m_142, 2D))).V);
comb_140 = ((V)(" "));
}
return steps_139;
return default;
}, 1, "", false));
return SetK(SEL_CACHE_20, sel_129, list_130);
return default;
}, 1, "parseSelectors", false);
splitTop_22 = Fn((V _self143, int _argc144, V s_150, V ch_151, V _a148, V _a149, V[] _rest145) => {
V @out_152 = default;
V d_153 = default;
V q_154 = default;
V cur_155 = default;
V i_156 = default;
V c_157 = default;
@out_152 = Arr();
d_153 = ((V)(0D));
q_154 = V.Null;
cur_155 = ((V)(""));
{
i_156 = ((V)(0D));
while (true) {
if (!(Lt(i_156, Get(s_150, "length")))) break;
c_157 = GetK(s_150, i_156);
if (Truthy(q_154)) {
if (SEq(c_157, q_154)) {
q_154 = V.Null;
}
} else {
if ((SEqS(c_157, "\"") || SEqS(c_157, "'"))) {
q_154 = c_157;
} else {
if (SEqS(c_157, "[")) {
PostInc(ref d_153, 1D);
} else {
if (SEqS(c_157, "]")) {
PostInc(ref d_153, -1D);
} else {
if ((SEq(c_157, ch_151) && !(Truthy(d_153)))) {
Invoke(@out_152, "push", cur_155);
cur_155 = ((V)(""));
goto _cont158;
}
}
}
}
}
cur_155 = Add(cur_155, c_157);
_cont158: ;
PostInc(ref i_156, 1D);
}
}
Invoke(@out_152, "push", cur_155);
return @out_152;
return default;
}, 2, "splitTop", false);
compound_23 = Fn((V _self159, int _argc160, V s_166, V _a163, V _a164, V _a165, V[] _rest161) => {
V p_167 = default;
V re_168 = default;
V m_169 = default;
p_167 = NewObj(4).Put("tag", V.Null).Put("id", V.Null).Put("cls", Arr()).Put("attrs", Arr()).V;
re_168 = NewRegExp(RX1, "([a-zA-Z][\\w-]*)|#([\\w-]+)|\\.([\\w-]+)|\\[\\s*([\\w:-]+)\\s*(?:([\\^$*~|]?=)\\s*(?:\"([^\"]*)\"|'([^']*)'|([^\\]\\s]*)))?\\s*\\]|(\\*)", "g");
while (Truthy((m_169 = Invoke(re_168, "exec", s_166)))) {
if (Truthy(GetIdx(m_169, 1D))) {
Set(p_167, "tag", Invoke(GetIdx(m_169, 1D), "toLowerCase"));
} else {
if (Truthy(GetIdx(m_169, 2D))) {
Set(p_167, "id", GetIdx(m_169, 2D));
} else {
if (Truthy(GetIdx(m_169, 3D))) {
Invoke(Get(p_167, "cls"), "push", GetIdx(m_169, 3D));
} else {
if (Truthy(GetIdx(m_169, 4D))) {
Invoke(Get(p_167, "attrs"), "push", NewObj(3).Put("name", GetIdx(m_169, 4D)).Put("op", (GetIdx(m_169, 5D) is var _t170 && Truthy(_t170) ? _t170 : V.Null)).Put("val", (!GetIdx(m_169, 6D).IsNullish ? GetIdx(m_169, 6D) : (!GetIdx(m_169, 7D).IsNullish ? GetIdx(m_169, 7D) : GetIdx(m_169, 8D)))).V);
}
}
}
}
}
return p_167;
return default;
}, 1, "compound", false);
matchCompound_24 = Fn((V _self171, int _argc172, V e_178, V p_179, V _a176, V _a177, V[] _rest173) => {
V c_180 = default;
V i_181 = default;
V j_182 = default;
V a_183 = default;
V v_184 = default;
if (Truthy((Get(p_179, "tag") is var _t185 && !Truthy(_t185) ? _t185 : (!SEq(Invoke(Get(e_178, "localName"), "toLowerCase"), Get(p_179, "tag")) ? V.True : V.False)))) {
return (false ? V.True : V.False);
}
if (Truthy((Get(p_179, "id") is var _t186 && !Truthy(_t186) ? _t186 : (!SEq(Invoke(e_178, "getAttribute", ((V)("id"))), Get(p_179, "id")) ? V.True : V.False)))) {
return (false ? V.True : V.False);
}
if (Truthy(Get(Get(p_179, "cls"), "length"))) {
c_180 = Invoke((Invoke(e_178, "getAttribute", ((V)("class"))) is var _t187 && Truthy(_t187) ? _t187 : ((V)(""))), "split", NewRegExp(RX2, "\\s+", ""));
{
i_181 = ((V)(0D));
while (true) {
if (!(Lt(i_181, Get(Get(p_179, "cls"), "length")))) break;
if (LtN(Invoke(c_180, "indexOf", GetK(Get(p_179, "cls"), i_181)), 0D)) {
return (false ? V.True : V.False);
}
PostInc(ref i_181, 1D);
}
}
}
{
j_182 = ((V)(0D));
while (true) {
if (!(Lt(j_182, Get(Get(p_179, "attrs"), "length")))) break;
a_183 = GetK(Get(p_179, "attrs"), j_182);
v_184 = Invoke(e_178, "getAttribute", Get(a_183, "name"));
if (SEq(v_184, V.Null)) {
return (false ? V.True : V.False);
}
if (!(Truthy(Get(a_183, "op")))) {
goto _cont189;
}
if ((SEqS(Get(a_183, "op"), "=") && !SEq(v_184, Get(a_183, "val")))) {
return (false ? V.True : V.False);
}
if ((SEqS(Get(a_183, "op"), "^=") && !SEqN(Invoke(v_184, "indexOf", Get(a_183, "val")), 0D))) {
return (false ? V.True : V.False);
}
if ((SEqS(Get(a_183, "op"), "$=") && !SEq(Invoke(v_184, "slice", ((V)((-ToNum(Get(Get(a_183, "val"), "length")))))), Get(a_183, "val")))) {
return (false ? V.True : V.False);
}
if ((SEqS(Get(a_183, "op"), "*=") && LtN(Invoke(v_184, "indexOf", Get(a_183, "val")), 0D))) {
return (false ? V.True : V.False);
}
if ((SEqS(Get(a_183, "op"), "~=") && LtN(Invoke(Invoke(v_184, "split", NewRegExp(RX2, "\\s+", "")), "indexOf", Get(a_183, "val")), 0D))) {
return (false ? V.True : V.False);
}
_cont189: ;
PostInc(ref j_182, 1D);
}
}
return (true ? V.True : V.False);
return default;
}, 2, "matchCompound", false);
matchSteps_25 = Fn((V _self190, int _argc191, V e_197, V steps_198, V k_199, V _a196, V[] _rest192) => {
V comb_200 = default;
V p_201 = default;
if (!(Truthy(Call(matchCompound_24, V.Undef, e_197, Get(GetK(steps_198, k_199), "parts"))))) {
return (false ? V.True : V.False);
}
if (SEqN(k_199, 0D)) {
return (true ? V.True : V.False);
}
comb_200 = Get(GetK(steps_198, k_199), "comb");
p_201 = Get(e_197, "parentNode");
if (SEqS(comb_200, ">")) {
return (((!(!(Truthy(p_201))) && SEqN(Get(p_201, "nodeType"), 1D)) ? V.True : V.False) is var _t202 && !Truthy(_t202) ? _t202 : Call(matchSteps_25, V.Undef, p_201, steps_198, ((V)((ToNum(k_199) - 1D)))));
}
while (Truthy((p_201 is var _t203 && !Truthy(_t203) ? _t203 : (SEqN(Get(p_201, "nodeType"), 1D) ? V.True : V.False)))) {
if (Truthy(Call(matchSteps_25, V.Undef, p_201, steps_198, ((V)((ToNum(k_199) - 1D)))))) {
return (true ? V.True : V.False);
}
p_201 = Get(p_201, "parentNode");
}
return (false ? V.True : V.False);
return default;
}, 3, "matchSteps", false);
matchesList_26 = Fn((V _self204, int _argc205, V e_211, V list_212, V _a209, V _a210, V[] _rest206) => {
V i_213 = default;
{
i_213 = ((V)(0D));
while (true) {
if (!(Lt(i_213, Get(list_212, "length")))) break;
if (Truthy(Call(matchSteps_25, V.Undef, e_211, GetK(list_212, i_213), ((V)((ToNum(Get(GetK(list_212, i_213), "length")) - 1D)))))) {
return (true ? V.True : V.False);
}
PostInc(ref i_213, 1D);
}
}
return (false ? V.True : V.False);
return default;
}, 2, "matchesList", false);
parseInto_30 = Fn((V _self215, int _argc216, V parent_222, V html_223, V ns_224, V _a221, V[] _rest217) => {
V stack_225 = default;
V i_226 = default;
V n_227 = default;
V lt_228 = default;
V t_229 = default;
V e_230 = default;
V e2_231 = default;
V e3_232 = default;
V name_233 = default;
V s_234 = default;
V m_235 = default;
V tag_236 = default;
V j_237 = default;
V el_238 = default;
V are_239 = default;
V selfClose_240 = default;
V am_241 = default;
stack_225 = Arr(parent_222);
i_226 = ((V)(0D));
n_227 = Get(html_223, "length");
while (Lt(i_226, n_227)) {
lt_228 = Invoke(html_223, "indexOf", ((V)("<")), i_226);
if (LtN(lt_228, 0D)) {
lt_228 = n_227;
}
if (Gt(lt_228, i_226)) {
t_229 = Invoke(html_223, "slice", i_226, lt_228);
if (Truthy((Invoke(t_229, "trim") is var _t242 && Truthy(_t242) ? _t242 : (GtN(Get(stack_225, "length"), 1D) ? V.True : V.False)))) {
Invoke(GetIdx(stack_225, (ToNum(Get(stack_225, "length")) - 1D)), "appendChild", New(Text_11, Call(unescape_29, V.Undef, t_229)));
}
}
if (Ge(lt_228, n_227)) {
break;
}
if (Truthy(Invoke(html_223, "startsWith", ((V)("<!--")), lt_228))) {
e_230 = Invoke(html_223, "indexOf", ((V)("-->")), Add(lt_228, ((V)(4D))));
i_226 = (LtN(e_230, 0D) ? n_227 : Add(e_230, ((V)(3D))));
continue;
}
if ((SEqS(GetK(html_223, Add(lt_228, ((V)(1D)))), "!") || SEqS(GetK(html_223, Add(lt_228, ((V)(1D)))), "?"))) {
e2_231 = Invoke(html_223, "indexOf", ((V)(">")), lt_228);
i_226 = (LtN(e2_231, 0D) ? n_227 : Add(e2_231, ((V)(1D))));
continue;
}
if (SEqS(GetK(html_223, Add(lt_228, ((V)(1D)))), "/")) {
e3_232 = Invoke(html_223, "indexOf", ((V)(">")), lt_228);
name_233 = Invoke(Invoke(html_223, "slice", Add(lt_228, ((V)(2D))), e3_232), "trim");
{
s_234 = ((V)((ToNum(Get(stack_225, "length")) - 1D)));
while (true) {
if (!(GtN(s_234, 0D))) break;
if ((SEq(Get(GetK(stack_225, s_234), "localName"), name_233) || SEq(Get(GetK(stack_225, s_234), "tagName"), name_233))) {
Set(stack_225, "length", s_234);
break;
}
PostInc(ref s_234, -1D);
}
}
i_226 = Add(e3_232, ((V)(1D)));
continue;
}
m_235 = Invoke(NewRegExp(RX3, "^<([a-zA-Z][\\w:.-]*)", ""), "exec", Invoke(html_223, "slice", lt_228, Add(lt_228, ((V)(64D)))));
if (!(Truthy(m_235))) {
Invoke(GetIdx(stack_225, (ToNum(Get(stack_225, "length")) - 1D)), "appendChild", New(Text_11, ((V)("<"))));
i_226 = Add(lt_228, ((V)(1D)));
continue;
}
tag_236 = GetIdx(m_235, 1D);
j_237 = Add(lt_228, Get(GetIdx(m_235, 0D), "length"));
el_238 = New(Element_18, tag_236, (SEqS(tag_236, "svg") ? SVG_NS_9 : (Get(GetIdx(stack_225, (ToNum(Get(stack_225, "length")) - 1D)), "namespaceURI") is var _t244 && Truthy(_t244) ? _t244 : ns_224)));
are_239 = NewRegExp(RX4, "\\s*([^\\s\"'>\\/=]+)(?:\\s*=\\s*(?:\"([^\"]*)\"|'([^']*)'|([^\\s\"'=<>`]+)))?|\\s*(\\/?)>", "g");
Set(are_239, "lastIndex", j_237);
selfClose_240 = (false ? V.True : V.False);
while (Truthy((am_241 = Invoke(are_239, "exec", html_223)))) {
if (!SEqN(Get(am_241, "index"), (ToNum(Get(are_239, "lastIndex")) - ToNum(Get(GetIdx(am_241, 0D), "length"))))) {
break;
}
if ((!SEq(GetIdx(am_241, 5D), V.Undef) && SEqS(Invoke(Invoke(GetIdx(am_241, 0D), "trim"), "slice", ((V)((-1D)))), ">"))) {
selfClose_240 = (SEqS(GetIdx(am_241, 5D), "/") ? V.True : V.False);
j_237 = Get(are_239, "lastIndex");
break;
}
Invoke(el_238, "setAttribute", GetIdx(am_241, 1D), Call(unescape_29, V.Undef, (!GetIdx(am_241, 2D).IsNullish ? GetIdx(am_241, 2D) : (!GetIdx(am_241, 3D).IsNullish ? GetIdx(am_241, 3D) : (!GetIdx(am_241, 4D).IsNullish ? GetIdx(am_241, 4D) : ((V)("")))))));
j_237 = Get(are_239, "lastIndex");
}
Invoke(GetIdx(stack_225, (ToNum(Get(stack_225, "length")) - 1D)), "appendChild", el_238);
i_226 = j_237;
if ((!(Truthy(selfClose_240)) && !(Truthy(((!SEq(Get(el_238, "namespaceURI"), SVG_NS_9) ? V.True : V.False) is var _t245 && !Truthy(_t245) ? _t245 : GetK(VOID_HTML_27, Invoke(tag_236, "toLowerCase"))))))) {
Invoke(stack_225, "push", el_238);
}
}
return default;
}, 3, "parseInto", false);
serialize_33 = Fn(Dom.SerializeFn, 1, "serialize", false);
SVGRect_35 = Fn((V _self246, int _argc247, V x_253, V y_254, V w_255, V h_256, V[] _rest248) => {
Set(_self246, "_r", Arr(x_253, y_254, w_255, h_256));
return default;
}, 4, "SVGRect", false);
bbox_36 = Fn((V _self257, int _argc258, V el_264, V _a261, V _a262, V _a263, V[] _rest259) => {
V r_265 = default;
V o_266 = default;
r_265 = Call(boxOf_57, V.Undef, el_264);
o_266 = Object_create(Get(SVGRect_35, "prototype"));
Object_defineProperty(o_266, ((V)("_r")), NewObj(3).Put("value", (Truthy(r_265) ? Arr(Get(r_265, "x"), Get(r_265, "y"), Get(r_265, "w"), Get(r_265, "h")) : Arr(((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(0D))))).Put("writable", (true ? V.True : V.False)).Put("enumerable", (false ? V.True : V.False)).V);
return o_266;
return default;
}, 1, "bbox", false);
rect_37 = Fn((V _self267, int _argc268, V x_274, V y_275, V w_276, V h_277, V[] _rest269) => {
return NewObj(4).Put("x", Call(F_34, V.Undef, x_274)).Put("y", Call(F_34, V.Undef, y_275)).Put("w", Call(F_34, V.Undef, w_276)).Put("h", Call(F_34, V.Undef, h_277)).V;
return default;
}, 4, "rect", false);
nextUp_40 = Fn((V _self278, int _argc279, V v_285, V _a282, V _a283, V _a284, V[] _rest280) => {
if ((!SEq(v_285, v_285) || SEqN(v_285, double.PositiveInfinity))) {
return v_285;
}
if (SEqN(v_285, 0D)) {
return Call(F_34, V.Undef, ((V)(1.401298464324817e-45)));
}
SetIdx(F32_38, 0D, v_285);
OpSetK(U32_39, ((V)(0D)), 0, ((V)((GtN(v_285, 0D) ? 1D : (-1D)))));
return GetIdx(F32_38, 0D);
return default;
}, 1, "nextUp", false);
fromBounds_41 = Fn((V _self286, int _argc287, V l_293, V t_294, V r_295, V b_296, V[] _rest288) => {
V w_297 = default;
V h_298 = default;
w_297 = Call(F_34, V.Undef, ((V)((ToNum(r_295) - ToNum(l_293)))));
h_298 = Call(F_34, V.Undef, ((V)((ToNum(b_296) - ToNum(t_294)))));
if (Lt(Call(F_34, V.Undef, Add(l_293, w_297)), r_295)) {
w_297 = Call(nextUp_40, V.Undef, w_297);
}
if (Lt(Call(F_34, V.Undef, Add(t_294, h_298)), b_296)) {
h_298 = Call(nextUp_40, V.Undef, h_298);
}
return NewObj(4).Put("x", l_293).Put("y", t_294).Put("w", w_297).Put("h", h_298).V;
return default;
}, 4, "fromBounds", false);
unite_42 = Fn((V _self299, int _argc300, V a_306, V b_307, V _a304, V _a305, V[] _rest301) => {
V x0_308 = default;
V y0_309 = default;
V x1_310 = default;
V y1_311 = default;
if (!(Truthy(a_306))) {
return b_307;
}
if (!(Truthy(b_307))) {
return a_306;
}
x0_308 = ((V)(Min(ToNum(Get(a_306, "x")), ToNum(Get(b_307, "x")))));
y0_309 = ((V)(Min(ToNum(Get(a_306, "y")), ToNum(Get(b_307, "y")))));
x1_310 = ((V)(Max(ToNum(Call(F_34, V.Undef, Add(Get(a_306, "x"), Get(a_306, "w")))), ToNum(Call(F_34, V.Undef, Add(Get(b_307, "x"), Get(b_307, "w")))))));
y1_311 = ((V)(Max(ToNum(Call(F_34, V.Undef, Add(Get(a_306, "y"), Get(a_306, "h")))), ToNum(Call(F_34, V.Undef, Add(Get(b_307, "y"), Get(b_307, "h")))))));
return Call(fromBounds_41, V.Undef, x0_308, y0_309, x1_310, y1_311);
return default;
}, 2, "unite", false);
mapRect_43 = Fn((V _self312, int _argc313, V m_319, V r_320, V _a317, V _a318, V[] _rest314) => {
V xs_321 = default;
V ys_322 = default;
V pts_323 = default;
V i_324 = default;
V x0_325 = default;
V y0_326 = default;
V x1_327 = default;
V y1_328 = default;
if (!(Truthy(m_319))) {
return r_320;
}
xs_321 = Arr();
ys_322 = Arr();
pts_323 = Arr(Arr(Get(r_320, "x"), Get(r_320, "y")), Arr(Call(F_34, V.Undef, Add(Get(r_320, "x"), Get(r_320, "w"))), Get(r_320, "y")), Arr(Call(F_34, V.Undef, Add(Get(r_320, "x"), Get(r_320, "w"))), Call(F_34, V.Undef, Add(Get(r_320, "y"), Get(r_320, "h")))), Arr(Get(r_320, "x"), Call(F_34, V.Undef, Add(Get(r_320, "y"), Get(r_320, "h")))));
{
i_324 = ((V)(0D));
while (true) {
if (!(LtN(i_324, 4D))) break;
Invoke(xs_321, "push", Call(F_34, V.Undef, Add(((V)(((ToNum(GetIdx(m_319, 0D)) * ToNum(GetIdx(GetK(pts_323, i_324), 0D))) + (ToNum(GetIdx(m_319, 2D)) * ToNum(GetIdx(GetK(pts_323, i_324), 1D)))))), GetIdx(m_319, 4D))));
Invoke(ys_322, "push", Call(F_34, V.Undef, Add(((V)(((ToNum(GetIdx(m_319, 1D)) * ToNum(GetIdx(GetK(pts_323, i_324), 0D))) + (ToNum(GetIdx(m_319, 3D)) * ToNum(GetIdx(GetK(pts_323, i_324), 1D)))))), GetIdx(m_319, 5D))));
PostInc(ref i_324, 1D);
}
}
x0_325 = Invoke(Get(G("Math"), "min"), "apply", V.Null, xs_321);
y0_326 = Invoke(Get(G("Math"), "min"), "apply", V.Null, ys_322);
x1_327 = Invoke(Get(G("Math"), "max"), "apply", V.Null, xs_321);
y1_328 = Invoke(Get(G("Math"), "max"), "apply", V.Null, ys_322);
return Call(fromBounds_41, V.Undef, x0_325, y0_326, x1_327, y1_328);
return default;
}, 2, "mapRect", false);
validUnitDivide_44 = Fn((V _self330, int _argc331, V n_337, V d_338, V _a335, V _a336, V[] _rest332) => {
V r_339 = default;
if (LtN(n_337, 0D)) {
n_337 = ((V)((-ToNum(n_337))));
d_338 = ((V)((-ToNum(d_338))));
}
if (((SEqN(d_338, 0D) || SEqN(n_337, 0D)) || Ge(n_337, d_338))) {
return V.Null;
}
r_339 = Call(F_34, V.Undef, ((V)((ToNum(n_337) / ToNum(d_338)))));
return ((!SEq(r_339, r_339) || SEqN(r_339, 0D)) ? V.Null : r_339);
return default;
}, 2, "validUnitDivide", false);
unitQuadRoots_45 = Fn((V _self340, int _argc341, V A_347, V B_348, V C_349, V _a346, V[] _rest342) => {
V r0_350 = default;
V dr_351 = default;
V R_352 = default;
V Q_353 = default;
V @out_354 = default;
V a_355 = default;
V b_356 = default;
if (SEqN(A_347, 0D)) {
r0_350 = Call(validUnitDivide_44, V.Undef, ((V)((-ToNum(C_349)))), B_348);
return (SEq(r0_350, V.Null) ? Arr() : Arr(r0_350));
}
dr_351 = ((V)(((ToNum(B_348) * ToNum(B_348)) - ((4D * ToNum(A_347)) * ToNum(C_349)))));
if (LtN(dr_351, 0D)) {
return Arr();
}
R_352 = Call(F_34, V.Undef, ((V)(System.Math.Sqrt(ToNum(dr_351)))));
if (!(IsFiniteV(R_352))) {
return Arr();
}
Q_353 = (LtN(B_348, 0D) ? Call(F_34, V.Undef, ((V)((-ToNum(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, ((V)((ToNum(B_348) - ToNum(R_352)))))) / 2D))))))))) : Call(F_34, V.Undef, ((V)((-ToNum(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, Add(B_348, R_352))) / 2D))))))))));
@out_354 = Arr();
a_355 = Call(validUnitDivide_44, V.Undef, Q_353, A_347);
b_356 = Call(validUnitDivide_44, V.Undef, C_349, Q_353);
if (!SEq(a_355, V.Null)) {
Invoke(@out_354, "push", a_355);
}
if (!SEq(b_356, V.Null)) {
Invoke(@out_354, "push", b_356);
}
if (SEqN(Get(@out_354, "length"), 2D)) {
if (Gt(GetIdx(@out_354, 0D), GetIdx(@out_354, 1D))) {
Invoke(@out_354, "reverse");
} else {
if (SEq(GetIdx(@out_354, 0D), GetIdx(@out_354, 1D))) {
Invoke(@out_354, "pop");
}
}
}
return @out_354;
return default;
}, 3, "unitQuadRoots", false);
cubicExtremaT_46 = Fn((V _self357, int _argc358, V a_364, V b_365, V c_366, V d_367, V[] _rest359) => {
return Call(unitQuadRoots_45, V.Undef, Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(d_367) - ToNum(a_364))))), Call(F_34, V.Undef, ((V)((3D * ToNum(Call(F_34, V.Undef, ((V)((ToNum(b_365) - ToNum(c_366)))))))))))), Call(F_34, V.Undef, ((V)((2D * ToNum(Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, ((V)((ToNum(a_364) - ToNum(b_365)))))) - ToNum(b_365))))), c_366))))))), Call(F_34, V.Undef, ((V)((ToNum(b_365) - ToNum(a_364))))));
return default;
}, 4, "cubicExtremaT", false);
evalCubic_47 = Fn((V _self368, int _argc369, V p_375, V t_376, V k_377, V _a374, V[] _rest370) => {
V P0_378 = default;
V P1_379 = default;
V P2_380 = default;
V P3_381 = default;
V A_382 = default;
V B_383 = default;
V C_384 = default;
P0_378 = GetK(GetIdx(p_375, 0D), k_377);
P1_379 = GetK(GetIdx(p_375, 1D), k_377);
P2_380 = GetK(GetIdx(p_375, 2D), k_377);
P3_381 = GetK(GetIdx(p_375, 3D), k_377);
A_382 = Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, Add(P3_381, Call(F_34, V.Undef, ((V)((3D * ToNum(Call(F_34, V.Undef, ((V)((ToNum(P1_379) - ToNum(P2_380))))))))))))) - ToNum(P0_378)))));
B_383 = Call(F_34, V.Undef, ((V)((3D * ToNum(Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(P2_380) - ToNum(Call(F_34, V.Undef, ((V)((2D * ToNum(P1_379)))))))))), P0_378)))))));
C_384 = Call(F_34, V.Undef, ((V)((3D * ToNum(Call(F_34, V.Undef, ((V)((ToNum(P1_379) - ToNum(P0_378))))))))));
return Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(A_382) * ToNum(t_376))))), B_383))) * ToNum(t_376))))), C_384))) * ToNum(t_376))))), P0_378));
return default;
}, 3, "evalCubic", false);
rotM_52 = Fn((V _self385, int _argc386, V deg_392, V _a389, V _a390, V _a391, V[] _rest387) => {
V rad_393 = default;
rad_393 = Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, deg_392)) * ToNum(DEG_51)))));
return Arr(Call(COSZ_49, V.Undef, rad_393), Call(SINZ_48, V.Undef, rad_393));
return default;
}, 1, "rotM", false);
arcToConics_53 = Fn((V _self394, int _argc395, V cur_401, V rx_402, V ry_403, V angle_404, V[] _rest396) => {
V mdx_408 = default;
V mdy_409 = default;
V r1_410 = default;
V tmx_411 = default;
V tmy_412 = default;
V srx_413 = default;
V sry_414 = default;
V sx_415 = default;
V sy_416 = default;
V rs_417 = default;
V irx_418 = default;
V iry_419 = default;
V USX_420 = default;
V UKX_421 = default;
V UKY_422 = default;
V USY_423 = default;
V mapU_424 = default;
V u0_425 = default;
V u1_426 = default;
V dx_427 = default;
V dy_428 = default;
V dd_429 = default;
V sfs_430 = default;
V sf_431 = default;
V ccw_432 = default;
V cx_433 = default;
V cy_434 = default;
V a0x_435 = default;
V a0y_436 = default;
V a1x_437 = default;
V a1y_438 = default;
V th1_439 = default;
V th2_440 = default;
V arc_441 = default;
V PI2_442 = default;
V r2m_443 = default;
V BSX_444 = default;
V BKY_445 = default;
V BKX_446 = default;
V BSY_447 = default;
V mapB_448 = default;
V segs_449 = default;
V tw_450 = default;
V t_451 = default;
V w_452 = default;
V isInt_453 = default;
V expectInts_454 = default;
V @out_455 = default;
V st_456 = default;
V i_457 = default;
V et_458 = default;
V se_459 = default;
V ce_460 = default;
V p1_461 = default;
V p0_462 = default;
V m0_463 = default;
V m1_464 = default;
V large_405 = default;
V sweep_406 = default;
V to_407 = default;
large_405 = (_argc395 > 4 ? _rest396[0] : V.Undef);
sweep_406 = (_argc395 > 5 ? _rest396[1] : V.Undef);
to_407 = (_argc395 > 6 ? _rest396[2] : V.Undef);
if ((!(Truthy(rx_402)) || !(Truthy(ry_403)))) {
return V.Null;
}
if ((SEq(GetIdx(cur_401, 0D), GetIdx(to_407, 0D)) && SEq(GetIdx(cur_401, 1D), GetIdx(to_407, 1D)))) {
return V.Null;
}
rx_402 = Call(F_34, V.Undef, ((V)(System.Math.Abs(ToNum(rx_402)))));
ry_403 = Call(F_34, V.Undef, ((V)(System.Math.Abs(ToNum(ry_403)))));
mdx_408 = Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, ((V)((ToNum(GetIdx(cur_401, 0D)) - ToNum(GetIdx(to_407, 0D))))))) * 0.5))));
mdy_409 = Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, ((V)((ToNum(GetIdx(cur_401, 1D)) - ToNum(GetIdx(to_407, 1D))))))) * 0.5))));
r1_410 = Call(rotM_52, V.Undef, ((V)((-ToNum(angle_404)))));
tmx_411 = Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(mdx_408) * ToNum(GetIdx(r1_410, 0D)))))), Call(F_34, V.Undef, ((V)((ToNum(mdy_409) * (-ToNum(GetIdx(r1_410, 1D)))))))));
tmy_412 = Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(mdy_409) * ToNum(GetIdx(r1_410, 0D)))))), Call(F_34, V.Undef, ((V)((ToNum(mdx_408) * ToNum(GetIdx(r1_410, 1D))))))));
if ((SEqN(GetIdx(r1_410, 1D), 0D) && SEqN(GetIdx(r1_410, 0D), 1D))) {
tmx_411 = mdx_408;
tmy_412 = mdy_409;
}
srx_413 = Call(F_34, V.Undef, ((V)((ToNum(rx_402) * ToNum(rx_402)))));
sry_414 = Call(F_34, V.Undef, ((V)((ToNum(ry_403) * ToNum(ry_403)))));
sx_415 = Call(F_34, V.Undef, ((V)((ToNum(tmx_411) * ToNum(tmx_411)))));
sy_416 = Call(F_34, V.Undef, ((V)((ToNum(tmy_412) * ToNum(tmy_412)))));
rs_417 = Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(sx_415) / ToNum(srx_413))))), Call(F_34, V.Undef, ((V)((ToNum(sy_416) / ToNum(sry_414)))))));
if (GtN(rs_417, 1D)) {
rs_417 = Call(F_34, V.Undef, ((V)(System.Math.Sqrt(ToNum(rs_417)))));
rx_402 = Call(F_34, V.Undef, ((V)((ToNum(rx_402) * ToNum(rs_417)))));
ry_403 = Call(F_34, V.Undef, ((V)((ToNum(ry_403) * ToNum(rs_417)))));
}
irx_418 = Call(F_34, V.Undef, ((V)((1D / ToNum(rx_402)))));
iry_419 = Call(F_34, V.Undef, ((V)((1D / ToNum(ry_403)))));
USX_420 = Call(F_34, V.Undef, ((V)((ToNum(irx_418) * ToNum(GetIdx(r1_410, 0D))))));
UKX_421 = Call(F_34, V.Undef, ((V)((ToNum(irx_418) * (-ToNum(GetIdx(r1_410, 1D)))))));
UKY_422 = Call(F_34, V.Undef, ((V)((ToNum(iry_419) * ToNum(GetIdx(r1_410, 1D))))));
USY_423 = Call(F_34, V.Undef, ((V)((ToNum(iry_419) * ToNum(GetIdx(r1_410, 0D))))));
mapU_424 = Fn((V _self465, int _argc466, V p_472, V _a469, V _a470, V _a471, V[] _rest467) => {
if ((SEqN(GetIdx(r1_410, 1D), 0D) && SEqN(GetIdx(r1_410, 0D), 1D))) {
return Arr(Call(F_34, V.Undef, ((V)((ToNum(GetIdx(p_472, 0D)) * ToNum(irx_418))))), Call(F_34, V.Undef, ((V)((ToNum(GetIdx(p_472, 1D)) * ToNum(iry_419))))));
}
return Arr(Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(GetIdx(p_472, 0D)) * ToNum(USX_420))))), Call(F_34, V.Undef, ((V)((ToNum(GetIdx(p_472, 1D)) * ToNum(UKX_421))))))), Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(GetIdx(p_472, 1D)) * ToNum(USY_423))))), Call(F_34, V.Undef, ((V)((ToNum(GetIdx(p_472, 0D)) * ToNum(UKY_422))))))));
return default;
}, 1, "", false);
u0_425 = Call(mapU_424, V.Undef, cur_401);
u1_426 = Call(mapU_424, V.Undef, to_407);
dx_427 = Call(F_34, V.Undef, ((V)((ToNum(GetIdx(u1_426, 0D)) - ToNum(GetIdx(u0_425, 0D))))));
dy_428 = Call(F_34, V.Undef, ((V)((ToNum(GetIdx(u1_426, 1D)) - ToNum(GetIdx(u0_425, 1D))))));
dd_429 = Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(dx_427) * ToNum(dx_427))))), Call(F_34, V.Undef, ((V)((ToNum(dy_428) * ToNum(dy_428)))))));
sfs_430 = ((V)(Max(ToNum(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, ((V)((1D / ToNum(dd_429)))))) - 0.25))))), 0D)));
sf_431 = Call(F_34, V.Undef, ((V)(System.Math.Sqrt(ToNum(sfs_430)))));
ccw_432 = (!(Truthy(sweep_406)) ? V.True : V.False);
if (!SEq(ccw_432, (!(!(Truthy(large_405))) ? V.True : V.False))) {
sf_431 = ((V)((-ToNum(sf_431))));
}
dx_427 = Call(F_34, V.Undef, ((V)((ToNum(dx_427) * ToNum(sf_431)))));
dy_428 = Call(F_34, V.Undef, ((V)((ToNum(dy_428) * ToNum(sf_431)))));
cx_433 = Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, Add(GetIdx(u0_425, 0D), GetIdx(u1_426, 0D)))) * 0.5))))) - ToNum(dy_428)))));
cy_434 = Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, Add(GetIdx(u0_425, 1D), GetIdx(u1_426, 1D)))) * 0.5)))), dx_427));
a0x_435 = Call(F_34, V.Undef, ((V)((ToNum(GetIdx(u0_425, 0D)) - ToNum(cx_433)))));
a0y_436 = Call(F_34, V.Undef, ((V)((ToNum(GetIdx(u0_425, 1D)) - ToNum(cy_434)))));
a1x_437 = Call(F_34, V.Undef, ((V)((ToNum(GetIdx(u1_426, 0D)) - ToNum(cx_433)))));
a1y_438 = Call(F_34, V.Undef, ((V)((ToNum(GetIdx(u1_426, 1D)) - ToNum(cy_434)))));
th1_439 = Call(F_34, V.Undef, ((V)(FdLibm.Atan2(ToNum(a0y_436), ToNum(a0x_435)))));
th2_440 = Call(F_34, V.Undef, ((V)(FdLibm.Atan2(ToNum(a1y_438), ToNum(a1x_437)))));
arc_441 = Call(F_34, V.Undef, ((V)((ToNum(th2_440) - ToNum(th1_439)))));
PI2_442 = Call(F_34, V.Undef, ((V)((ToNum(PIF_50) * 2D))));
if (Truthy(((LtN(arc_441, 0D) ? V.True : V.False) is var _t473 && !Truthy(_t473) ? _t473 : sweep_406))) {
arc_441 = Call(F_34, V.Undef, Add(arc_441, PI2_442));
} else {
if ((GtN(arc_441, 0D) && !(Truthy(sweep_406)))) {
arc_441 = Call(F_34, V.Undef, ((V)((ToNum(arc_441) - ToNum(PI2_442)))));
}
}
if (Lt(((V)(System.Math.Abs(ToNum(arc_441)))), Call(F_34, V.Undef, ((V)((ToNum(PIF_50) / (1000D * 1000D))))))) {
return V.Null;
}
r2m_443 = Call(rotM_52, V.Undef, angle_404);
BSX_444 = Call(F_34, V.Undef, ((V)((ToNum(GetIdx(r2m_443, 0D)) * ToNum(rx_402)))));
BKY_445 = Call(F_34, V.Undef, ((V)((ToNum(GetIdx(r2m_443, 1D)) * ToNum(rx_402)))));
BKX_446 = Call(F_34, V.Undef, ((V)(((-ToNum(GetIdx(r2m_443, 1D))) * ToNum(ry_403)))));
BSY_447 = Call(F_34, V.Undef, ((V)((ToNum(GetIdx(r2m_443, 0D)) * ToNum(ry_403)))));
mapB_448 = Fn((V _self474, int _argc475, V p_481, V _a478, V _a479, V _a480, V[] _rest476) => {
if ((SEqN(GetIdx(r2m_443, 1D), 0D) && SEqN(GetIdx(r2m_443, 0D), 1D))) {
return Arr(Call(F_34, V.Undef, ((V)((ToNum(GetIdx(p_481, 0D)) * ToNum(rx_402))))), Call(F_34, V.Undef, ((V)((ToNum(GetIdx(p_481, 1D)) * ToNum(ry_403))))));
}
return Arr(Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(GetIdx(p_481, 0D)) * ToNum(BSX_444))))), Call(F_34, V.Undef, ((V)((ToNum(GetIdx(p_481, 1D)) * ToNum(BKX_446))))))), Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(GetIdx(p_481, 1D)) * ToNum(BSY_447))))), Call(F_34, V.Undef, ((V)((ToNum(GetIdx(p_481, 0D)) * ToNum(BKY_445))))))));
return default;
}, 1, "", false);
segs_449 = ((V)(System.Math.Ceiling(System.Math.Abs(ToNum(Call(F_34, V.Undef, ((V)((ToNum(arc_441) / ToNum(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, ((V)((2D * ToNum(PIF_50)))))) / 3D))))))))))))));
tw_450 = Call(F_34, V.Undef, ((V)((ToNum(arc_441) / ToNum(segs_449)))));
t_451 = Call(F_34, V.Undef, ((V)(FdLibm.Tan(ToNum(Call(F_34, V.Undef, ((V)((0.5 * ToNum(tw_450))))))))));
if (!(IsFiniteV(t_451))) {
return Arr();
}
w_452 = Call(F_34, V.Undef, ((V)(System.Math.Sqrt(ToNum(Call(F_34, V.Undef, Add(((V)(0.5)), Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, ((V)(FdLibm.Cos(ToNum(tw_450)))))) * 0.5)))))))))));
isInt_453 = Fn((V _self482, int _argc483, V v_489, V _a486, V _a487, V _a488, V[] _rest484) => {
return (SEqN(v_489, System.Math.Floor(ToNum(v_489))) ? V.True : V.False);
return default;
}, 1, "", false);
expectInts_454 = (((((Le(((V)(System.Math.Abs(ToNum(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, ((V)((ToNum(PIF_50) / 2D))))) - System.Math.Abs(ToNum(tw_450)))))))))), Call(F_34, V.Undef, ((V)((1D / 4096D))))) ? V.True : V.False) is var _t490 && !Truthy(_t490) ? _t490 : Call(isInt_453, V.Undef, rx_402)) is var _t491 && !Truthy(_t491) ? _t491 : Call(isInt_453, V.Undef, ry_403)) is var _t492 && !Truthy(_t492) ? _t492 : Call(isInt_453, V.Undef, GetIdx(to_407, 0D))) is var _t493 && !Truthy(_t493) ? _t493 : Call(isInt_453, V.Undef, GetIdx(to_407, 1D)));
@out_455 = Arr();
st_456 = th1_439;
{
i_457 = ((V)(0D));
while (true) {
if (!(Lt(i_457, segs_449))) break;
et_458 = Call(F_34, V.Undef, Add(st_456, tw_450));
se_459 = Call(SINZ_48, V.Undef, et_458);
ce_460 = Call(COSZ_49, V.Undef, et_458);
p1_461 = Arr(Call(F_34, V.Undef, Add(ce_460, cx_433)), Call(F_34, V.Undef, Add(se_459, cy_434)));
p0_462 = Arr(Call(F_34, V.Undef, Add(GetIdx(p1_461, 0D), Call(F_34, V.Undef, ((V)((ToNum(t_451) * ToNum(se_459))))))), Call(F_34, V.Undef, ((V)((ToNum(GetIdx(p1_461, 1D)) - ToNum(Call(F_34, V.Undef, ((V)((ToNum(t_451) * ToNum(ce_460)))))))))));
m0_463 = Call(mapB_448, V.Undef, p0_462);
m1_464 = Call(mapB_448, V.Undef, p1_461);
if (Truthy(expectInts_454)) {
m0_463 = Arr(((V)(Round(ToNum(GetIdx(m0_463, 0D))))), ((V)(Round(ToNum(GetIdx(m0_463, 1D))))));
m1_464 = Arr(((V)(Round(ToNum(GetIdx(m1_464, 0D))))), ((V)(Round(ToNum(GetIdx(m1_464, 1D))))));
}
Invoke(@out_455, "push", Arr(m0_463, m1_464, w_452));
st_456 = et_458;
PostInc(ref i_457, 1D);
}
}
if (Truthy(Get(@out_455, "length"))) {
SetIdx(GetIdx(@out_455, (ToNum(Get(@out_455, "length")) - 1D)), 1D, Arr(GetIdx(to_407, 0D), GetIdx(to_407, 1D)));
}
return @out_455;
return default;
}, 7, "arcToConics", false);
conicExtremaT_54 = Fn((V _self495, int _argc496, V a_502, V b_503, V c_504, V w_505, V[] _rest497) => {
V P20_506 = default;
V P10_507 = default;
V wP10_508 = default;
V r_509 = default;
P20_506 = Call(F_34, V.Undef, ((V)((ToNum(c_504) - ToNum(a_502)))));
P10_507 = Call(F_34, V.Undef, ((V)((ToNum(b_503) - ToNum(a_502)))));
wP10_508 = Call(F_34, V.Undef, ((V)((ToNum(w_505) * ToNum(P10_507)))));
r_509 = Call(unitQuadRoots_45, V.Undef, Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, ((V)((ToNum(w_505) * ToNum(P20_506)))))) - ToNum(P20_506))))), Call(F_34, V.Undef, ((V)((ToNum(P20_506) - ToNum(Call(F_34, V.Undef, ((V)((2D * ToNum(wP10_508)))))))))), wP10_508);
return (SEqN(Get(r_509, "length"), 1D) ? r_509 : Arr());
return default;
}, 4, "conicExtremaT", false);
evalConic_55 = Fn((V _self510, int _argc511, V p_517, V w_518, V t_519, V k_520, V[] _rest512) => {
V p0_521 = default;
V p1w_522 = default;
V p2_523 = default;
V nA_524 = default;
V nB_525 = default;
V dB_526 = default;
V dA_527 = default;
V num_528 = default;
V den_529 = default;
p0_521 = GetK(GetIdx(p_517, 0D), k_520);
p1w_522 = Call(F_34, V.Undef, ((V)((ToNum(GetK(GetIdx(p_517, 1D), k_520)) * ToNum(w_518)))));
p2_523 = GetK(GetIdx(p_517, 2D), k_520);
nA_524 = Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(p2_523) - ToNum(Call(F_34, V.Undef, ((V)((2D * ToNum(p1w_522)))))))))), p0_521));
nB_525 = Call(F_34, V.Undef, ((V)((2D * ToNum(Call(F_34, V.Undef, ((V)((ToNum(p1w_522) - ToNum(p0_521))))))))));
dB_526 = Call(F_34, V.Undef, ((V)((2D * ToNum(Call(F_34, V.Undef, ((V)((ToNum(w_518) - 1D)))))))));
dA_527 = Call(F_34, V.Undef, ((V)((0D - ToNum(dB_526)))));
num_528 = Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(nA_524) * ToNum(t_519))))), nB_525))) * ToNum(t_519))))), p0_521));
den_529 = Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(dA_527) * ToNum(t_519))))), dB_526))) * ToNum(t_519))))), ((V)(1D))));
return Call(F_34, V.Undef, ((V)((ToNum(num_528) / ToNum(den_529)))));
return default;
}, 4, "evalConic", false);
pathTight_56 = Fn((V _self530, int _argc531, V d_537, V _a534, V _a535, V _a536, V[] _rest532) => {
V tk_538 = default;
V i_539 = default;
V cmd_540 = default;
V cur_541 = default;
V start_542 = default;
V lastC_543 = default;
V lastQ_544 = default;
V segs_545 = default;
V n_546 = default;
V abs_547 = default;
V C_548 = default;
V rel_549 = default;
V p_550 = default;
V hx_551 = default;
V vy_552 = default;
V c1_553 = default;
V c2_554 = default;
V e_555 = default;
V qc_556 = default;
V qe_557 = default;
V rx_558 = default;
V ry_559 = default;
V ang_560 = default;
V lg_561 = default;
V sw_562 = default;
V to_563 = default;
V conics_564 = default;
V from_565 = default;
V k_566 = default;
V first_567 = default;
V x0_568 = default;
V y0_569 = default;
V x1_570 = default;
V y1_571 = default;
V add_572 = default;
V s2_573 = default;
V g_574 = default;
V kts_575 = default;
V jk_576 = default;
V qts_577 = default;
V qa_578 = default;
V qb_579 = default;
V jq_580 = default;
V tq_581 = default;
V ev_582 = default;
V ts_583 = default;
V j_584 = default;
tk_538 = (Invoke(d_537, "match", NewRegExp(RX5, "[a-zA-Z]|[-+]?(?:\\d*\\.\\d+|\\d+\\.?)(?:[eE][-+]?\\d+)?", "g")) is var _t585 && Truthy(_t585) ? _t585 : Arr());
i_539 = ((V)(0D));
cmd_540 = ((V)(""));
cur_541 = Arr(((V)(0D)), ((V)(0D)));
start_542 = Arr(((V)(0D)), ((V)(0D)));
lastC_543 = V.Null;
lastQ_544 = V.Null;
segs_545 = Arr();
n_546 = Fn((V _self586, int _argc587, V _a589, V _a590, V _a591, V _a592, V[] _rest588) => {
return Call(F_34, V.Undef, ((V)(ToNum(GetIdx(tk_538, PostInc(ref i_539, 1D))))));
return default;
}, 0, "", false);
abs_547 = Fn((V _self593, int _argc594, V rel_600, V x_601, V y_602, V _a599, V[] _rest595) => {
return (Truthy(rel_600) ? Arr(Call(F_34, V.Undef, Add(GetIdx(cur_541, 0D), x_601)), Call(F_34, V.Undef, Add(GetIdx(cur_541, 1D), y_602))) : Arr(x_601, y_602));
return default;
}, 3, "", false);
while (Lt(i_539, Get(tk_538, "length"))) {
if (Truthy(Invoke(NewRegExp(RX6, "[a-zA-Z]", ""), "test", GetK(tk_538, i_539)))) {
cmd_540 = GetIdx(tk_538, PostInc(ref i_539, 1D));
}
C_548 = Invoke(cmd_540, "toUpperCase");
rel_549 = (!SEq(cmd_540, C_548) ? V.True : V.False);
if (SEqS(C_548, "Z")) {
Invoke(segs_545, "push", NewObj(1).Put("v", ((V)("Z"))).V);
cur_541 = start_542;
lastC_543 = (lastQ_544 = V.Null);
if ((Lt(i_539, Get(tk_538, "length")) && !(Truthy(Invoke(NewRegExp(RX6, "[a-zA-Z]", ""), "test", GetK(tk_538, i_539)))))) {
PostInc(ref i_539, 1D);
}
continue;
}
if (Ge(i_539, Get(tk_538, "length"))) {
break;
}
if (SEqS(C_548, "M")) {
p_550 = Call(abs_547, V.Undef, rel_549, Call(n_546, V.Undef), Call(n_546, V.Undef));
Invoke(segs_545, "push", NewObj(2).Put("v", ((V)("M"))).Put("p", Arr(p_550)).V);
cur_541 = (start_542 = p_550);
cmd_540 = ((V)((Truthy(rel_549) ? "l" : "L")));
lastC_543 = (lastQ_544 = V.Null);
continue;
}
if (SEqS(C_548, "L")) {
p_550 = Call(abs_547, V.Undef, rel_549, Call(n_546, V.Undef), Call(n_546, V.Undef));
Invoke(segs_545, "push", NewObj(2).Put("v", ((V)("L"))).Put("p", Arr(cur_541, p_550)).V);
cur_541 = p_550;
lastC_543 = (lastQ_544 = V.Null);
continue;
}
if (SEqS(C_548, "H")) {
hx_551 = Call(n_546, V.Undef);
p_550 = Arr((Truthy(rel_549) ? Call(F_34, V.Undef, Add(GetIdx(cur_541, 0D), hx_551)) : hx_551), GetIdx(cur_541, 1D));
Invoke(segs_545, "push", NewObj(2).Put("v", ((V)("L"))).Put("p", Arr(cur_541, p_550)).V);
cur_541 = p_550;
lastC_543 = (lastQ_544 = V.Null);
continue;
}
if (SEqS(C_548, "V")) {
vy_552 = Call(n_546, V.Undef);
p_550 = Arr(GetIdx(cur_541, 0D), (Truthy(rel_549) ? Call(F_34, V.Undef, Add(GetIdx(cur_541, 1D), vy_552)) : vy_552));
Invoke(segs_545, "push", NewObj(2).Put("v", ((V)("L"))).Put("p", Arr(cur_541, p_550)).V);
cur_541 = p_550;
lastC_543 = (lastQ_544 = V.Null);
continue;
}
if ((SEqS(C_548, "C") || SEqS(C_548, "S"))) {

if (SEqS(C_548, "C")) {
c1_553 = Call(abs_547, V.Undef, rel_549, Call(n_546, V.Undef), Call(n_546, V.Undef));
} else {
c1_553 = (Truthy(lastC_543) ? Arr(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, ((V)((2D * ToNum(GetIdx(cur_541, 0D))))))) - ToNum(GetIdx(lastC_543, 0D)))))), Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, ((V)((2D * ToNum(GetIdx(cur_541, 1D))))))) - ToNum(GetIdx(lastC_543, 1D))))))) : cur_541);
}
c2_554 = Call(abs_547, V.Undef, rel_549, Call(n_546, V.Undef), Call(n_546, V.Undef));
e_555 = Call(abs_547, V.Undef, rel_549, Call(n_546, V.Undef), Call(n_546, V.Undef));
Invoke(segs_545, "push", NewObj(2).Put("v", ((V)("C"))).Put("p", Arr(cur_541, c1_553, c2_554, e_555)).V);
lastC_543 = c2_554;
lastQ_544 = V.Null;
cur_541 = e_555;
continue;
}
if ((SEqS(C_548, "Q") || SEqS(C_548, "T"))) {
qc_556 = (SEqS(C_548, "Q") ? Call(abs_547, V.Undef, rel_549, Call(n_546, V.Undef), Call(n_546, V.Undef)) : (Truthy(lastQ_544) ? Arr(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, ((V)((2D * ToNum(GetIdx(cur_541, 0D))))))) - ToNum(GetIdx(lastQ_544, 0D)))))), Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, ((V)((2D * ToNum(GetIdx(cur_541, 1D))))))) - ToNum(GetIdx(lastQ_544, 1D))))))) : cur_541));
qe_557 = Call(abs_547, V.Undef, rel_549, Call(n_546, V.Undef), Call(n_546, V.Undef));
Invoke(segs_545, "push", NewObj(2).Put("v", ((V)("Q"))).Put("p", Arr(cur_541, qc_556, qe_557)).V);
lastQ_544 = qc_556;
lastC_543 = V.Null;
cur_541 = qe_557;
continue;
}
if (SEqS(C_548, "A")) {
rx_558 = Call(n_546, V.Undef);
ry_559 = Call(n_546, V.Undef);
ang_560 = Call(n_546, V.Undef);
lg_561 = Call(n_546, V.Undef);
sw_562 = Call(n_546, V.Undef);
to_563 = Call(abs_547, V.Undef, rel_549, Call(n_546, V.Undef), Call(n_546, V.Undef));
conics_564 = Call(arcToConics_53, V.Undef, cur_541, rx_558, ry_559, ang_560, lg_561, sw_562, to_563);
if (!(Truthy(conics_564))) {
Invoke(segs_545, "push", NewObj(2).Put("v", ((V)("L"))).Put("p", Arr(cur_541, to_563)).V);
} else {
from_565 = cur_541;
{
k_566 = ((V)(0D));
while (true) {
if (!(Lt(k_566, Get(conics_564, "length")))) break;
Invoke(segs_545, "push", NewObj(3).Put("v", ((V)("K"))).Put("p", Arr(from_565, GetIdx(GetK(conics_564, k_566), 0D), GetIdx(GetK(conics_564, k_566), 1D))).Put("w", GetIdx(GetK(conics_564, k_566), 2D)).V);
from_565 = GetIdx(GetK(conics_564, k_566), 1D);
PostInc(ref k_566, 1D);
}
}
}
cur_541 = to_563;
lastC_543 = (lastQ_544 = V.Null);
continue;
}
PostInc(ref i_539, 1D);
}
if (!(Truthy(Get(segs_545, "length")))) {
return V.Null;
}
first_567 = (Truthy(Get(GetIdx(segs_545, 0D), "p")) ? GetIdx(Get(GetIdx(segs_545, 0D), "p"), 0D) : Arr(((V)(0D)), ((V)(0D))));
x0_568 = GetIdx(first_567, 0D);
y0_569 = GetIdx(first_567, 1D);
x1_570 = x0_568;
y1_571 = y0_569;
add_572 = Fn((V _self604, int _argc605, V x_611, V y_612, V _a609, V _a610, V[] _rest606) => {
if (Lt(x_611, x0_568)) {
x0_568 = x_611;
}
if (Gt(x_611, x1_570)) {
x1_570 = x_611;
}
if (Lt(y_612, y0_569)) {
y0_569 = y_612;
}
if (Gt(y_612, y1_571)) {
y1_571 = y_612;
}
return default;
}, 2, "", false);
{
s2_573 = ((V)(0D));
while (true) {
if (!(Lt(s2_573, Get(segs_545, "length")))) break;
g_574 = GetK(segs_545, s2_573);
if (SEqS(Get(g_574, "v"), "M")) {
Call(add_572, V.Undef, GetIdx(GetIdx(Get(g_574, "p"), 0D), 0D), GetIdx(GetIdx(Get(g_574, "p"), 0D), 1D));
} else {
if (SEqS(Get(g_574, "v"), "L")) {
Call(add_572, V.Undef, GetIdx(GetIdx(Get(g_574, "p"), 1D), 0D), GetIdx(GetIdx(Get(g_574, "p"), 1D), 1D));
} else {
if (SEqS(Get(g_574, "v"), "K")) {
kts_575 = Invoke(Call(conicExtremaT_54, V.Undef, GetIdx(GetIdx(Get(g_574, "p"), 0D), 0D), GetIdx(GetIdx(Get(g_574, "p"), 1D), 0D), GetIdx(GetIdx(Get(g_574, "p"), 2D), 0D), Get(g_574, "w")), "concat", Call(conicExtremaT_54, V.Undef, GetIdx(GetIdx(Get(g_574, "p"), 0D), 1D), GetIdx(GetIdx(Get(g_574, "p"), 1D), 1D), GetIdx(GetIdx(Get(g_574, "p"), 2D), 1D), Get(g_574, "w")));
{
jk_576 = ((V)(0D));
while (true) {
if (!(Lt(jk_576, Get(kts_575, "length")))) break;
Call(add_572, V.Undef, Call(evalConic_55, V.Undef, Get(g_574, "p"), Get(g_574, "w"), GetK(kts_575, jk_576), ((V)(0D))), Call(evalConic_55, V.Undef, Get(g_574, "p"), Get(g_574, "w"), GetK(kts_575, jk_576), ((V)(1D))));
PostInc(ref jk_576, 1D);
}
}
Call(add_572, V.Undef, GetIdx(GetIdx(Get(g_574, "p"), 2D), 0D), GetIdx(GetIdx(Get(g_574, "p"), 2D), 1D));
} else {
if (SEqS(Get(g_574, "v"), "Q")) {
qts_577 = Arr();
qa_578 = Call(validUnitDivide_44, V.Undef, Call(F_34, V.Undef, ((V)((ToNum(GetIdx(GetIdx(Get(g_574, "p"), 0D), 0D)) - ToNum(GetIdx(GetIdx(Get(g_574, "p"), 1D), 0D)))))), Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, ((V)((ToNum(GetIdx(GetIdx(Get(g_574, "p"), 0D), 0D)) - ToNum(GetIdx(GetIdx(Get(g_574, "p"), 1D), 0D))))))) - ToNum(GetIdx(GetIdx(Get(g_574, "p"), 1D), 0D)))))), GetIdx(GetIdx(Get(g_574, "p"), 2D), 0D))));
qb_579 = Call(validUnitDivide_44, V.Undef, Call(F_34, V.Undef, ((V)((ToNum(GetIdx(GetIdx(Get(g_574, "p"), 0D), 1D)) - ToNum(GetIdx(GetIdx(Get(g_574, "p"), 1D), 1D)))))), Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, ((V)((ToNum(GetIdx(GetIdx(Get(g_574, "p"), 0D), 1D)) - ToNum(GetIdx(GetIdx(Get(g_574, "p"), 1D), 1D))))))) - ToNum(GetIdx(GetIdx(Get(g_574, "p"), 1D), 1D)))))), GetIdx(GetIdx(Get(g_574, "p"), 2D), 1D))));
if (!SEq(qa_578, V.Null)) {
Invoke(qts_577, "push", qa_578);
}
if (!SEq(qb_579, V.Null)) {
Invoke(qts_577, "push", qb_579);
}
{
jq_580 = ((V)(0D));
while (true) {
if (!(Lt(jq_580, Get(qts_577, "length")))) break;
tq_581 = GetK(qts_577, jq_580);
ev_582 = Fn((V _self616, int _argc617, V k_623, V _a620, V _a621, V _a622, V[] _rest618) => {
V P0_624 = default;
V P1_625 = default;
V P2_626 = default;
V A_627 = default;
V B_628 = default;
P0_624 = GetK(GetIdx(Get(g_574, "p"), 0D), k_623);
P1_625 = GetK(GetIdx(Get(g_574, "p"), 1D), k_623);
P2_626 = GetK(GetIdx(Get(g_574, "p"), 2D), k_623);
A_627 = Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(P2_626) - ToNum(Call(F_34, V.Undef, ((V)((2D * ToNum(P1_625)))))))))), P0_624));
B_628 = Call(F_34, V.Undef, ((V)((2D * ToNum(Call(F_34, V.Undef, ((V)((ToNum(P1_625) - ToNum(P0_624))))))))));
return Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(A_627) * ToNum(tq_581))))), B_628))) * ToNum(tq_581))))), P0_624));
return default;
}, 1, "", false);
Call(add_572, V.Undef, Call(ev_582, V.Undef, ((V)(0D))), Call(ev_582, V.Undef, ((V)(1D))));
PostInc(ref jq_580, 1D);
}
}
Call(add_572, V.Undef, GetIdx(GetIdx(Get(g_574, "p"), 2D), 0D), GetIdx(GetIdx(Get(g_574, "p"), 2D), 1D));
} else {
if (SEqS(Get(g_574, "v"), "C")) {
ts_583 = Invoke(Call(cubicExtremaT_46, V.Undef, GetIdx(GetIdx(Get(g_574, "p"), 0D), 0D), GetIdx(GetIdx(Get(g_574, "p"), 1D), 0D), GetIdx(GetIdx(Get(g_574, "p"), 2D), 0D), GetIdx(GetIdx(Get(g_574, "p"), 3D), 0D)), "concat", Call(cubicExtremaT_46, V.Undef, GetIdx(GetIdx(Get(g_574, "p"), 0D), 1D), GetIdx(GetIdx(Get(g_574, "p"), 1D), 1D), GetIdx(GetIdx(Get(g_574, "p"), 2D), 1D), GetIdx(GetIdx(Get(g_574, "p"), 3D), 1D)));
{
j_584 = ((V)(0D));
while (true) {
if (!(Lt(j_584, Get(ts_583, "length")))) break;
Call(add_572, V.Undef, Call(evalCubic_47, V.Undef, Get(g_574, "p"), GetK(ts_583, j_584), ((V)(0D))), Call(evalCubic_47, V.Undef, Get(g_574, "p"), GetK(ts_583, j_584), ((V)(1D))));
PostInc(ref j_584, 1D);
}
}
Call(add_572, V.Undef, GetIdx(GetIdx(Get(g_574, "p"), 3D), 0D), GetIdx(GetIdx(Get(g_574, "p"), 3D), 1D));
}
}
}
}
}
PostInc(ref s2_573, 1D);
}
}
return Call(fromBounds_41, V.Undef, x0_568, y0_569, x1_570, y1_571);
return default;
}, 1, "pathTight", false);
boxOf_57 = Fn((V _self630, int _argc631, V el_637, V _a634, V _a635, V _a636, V[] _rest632) => {
V tag_638 = default;
V num_639 = default;
V r_640 = default;
V rx_641 = default;
V ry_642 = default;
V x1_643 = default;
V y1_644 = default;
V x2_645 = default;
V y2_646 = default;
V p_647 = default;
V b2_648 = default;
V i_649 = default;
V u_650 = default;
V c_651 = default;
V ch_652 = default;
V cb_653 = default;
tag_638 = Get(el_637, "localName");
num_639 = Fn((V _self654, int _argc655, V k_661, V _a658, V _a659, V _a660, V[] _rest656) => {
return Call(F_34, V.Undef, (((V)(ParseFloat((Invoke(el_637, "getAttribute", k_661) is var _t662 && Truthy(_t662) ? _t662 : ((V)("0")))))) is var _t663 && Truthy(_t663) ? _t663 : ((V)(0D))));
return default;
}, 1, "", false);
if (SEqS(tag_638, "path")) {
return Call(pathTight_56, V.Undef, (Invoke(el_637, "getAttribute", ((V)("d"))) is var _t664 && Truthy(_t664) ? _t664 : ((V)(""))));
}
if (SEqS(tag_638, "rect")) {
return Call(rect_37, V.Undef, Call(num_639, V.Undef, ((V)("x"))), Call(num_639, V.Undef, ((V)("y"))), Call(num_639, V.Undef, ((V)("width"))), Call(num_639, V.Undef, ((V)("height"))));
}
if (SEqS(tag_638, "circle")) {
r_640 = Call(num_639, V.Undef, ((V)("r")));
return Call(rect_37, V.Undef, Call(F_34, V.Undef, ((V)((ToNum(Call(num_639, V.Undef, ((V)("cx")))) - ToNum(r_640))))), Call(F_34, V.Undef, ((V)((ToNum(Call(num_639, V.Undef, ((V)("cy")))) - ToNum(r_640))))), Call(F_34, V.Undef, ((V)((ToNum(r_640) * 2D)))), Call(F_34, V.Undef, ((V)((ToNum(r_640) * 2D)))));
}
if (SEqS(tag_638, "ellipse")) {
rx_641 = Call(num_639, V.Undef, ((V)("rx")));
ry_642 = Call(num_639, V.Undef, ((V)("ry")));
return Call(rect_37, V.Undef, Call(F_34, V.Undef, ((V)((ToNum(Call(num_639, V.Undef, ((V)("cx")))) - ToNum(rx_641))))), Call(F_34, V.Undef, ((V)((ToNum(Call(num_639, V.Undef, ((V)("cy")))) - ToNum(ry_642))))), Call(F_34, V.Undef, ((V)((ToNum(rx_641) * 2D)))), Call(F_34, V.Undef, ((V)((ToNum(ry_642) * 2D)))));
}
if (SEqS(tag_638, "line")) {
x1_643 = Call(num_639, V.Undef, ((V)("x1")));
y1_644 = Call(num_639, V.Undef, ((V)("y1")));
x2_645 = Call(num_639, V.Undef, ((V)("x2")));
y2_646 = Call(num_639, V.Undef, ((V)("y2")));
return Call(rect_37, V.Undef, ((V)(Min(ToNum(x1_643), ToNum(x2_645)))), ((V)(Min(ToNum(y1_644), ToNum(y2_646)))), ((V)(System.Math.Abs((ToNum(x2_645) - ToNum(x1_643))))), ((V)(System.Math.Abs((ToNum(y2_646) - ToNum(y1_644))))));
}
if ((SEqS(tag_638, "polygon") || SEqS(tag_638, "polyline"))) {
p_647 = Invoke(Invoke(Invoke((Invoke(el_637, "getAttribute", ((V)("points"))) is var _t665 && Truthy(_t665) ? _t665 : ((V)(""))), "split", NewRegExp(RX7, "[\\s,]+", "")), "filter", G("Boolean")), "map", G("Number"));
b2_648 = V.Null;
{
i_649 = ((V)(0D));
while (true) {
if (!(Lt(Add(i_649, ((V)(1D))), Get(p_647, "length")))) break;
b2_648 = Call(unite_42, V.Undef, b2_648, Call(rect_37, V.Undef, GetK(p_647, i_649), GetK(p_647, Add(i_649, ((V)(1D)))), ((V)(0D)), ((V)(0D))));
i_649 = Add(i_649, ((V)(2D)));
}
}
return b2_648;
}
if ((((SEqS(tag_638, "g") || SEqS(tag_638, "svg")) || SEqS(tag_638, "a")) || SEqS(tag_638, "switch"))) {
u_650 = V.Null;
{
c_651 = ((V)(0D));
while (true) {
if (!(Lt(c_651, Get(Get(el_637, "childNodes"), "length")))) break;
ch_652 = GetK(Get(el_637, "childNodes"), c_651);
if (Truthy(((!SEqN(Get(ch_652, "nodeType"), 1D) ? V.True : V.False) is var _t668 && Truthy(_t668) ? _t668 : Invoke(NewRegExp(RX8, "^(defs|clipPath|mask|linearGradient|radialGradient|pattern|filter|style|title|desc|metadata|script|symbol|marker)$", ""), "test", Get(ch_652, "localName"))))) {
goto _cont667;
}
if (Truthy((((SEqS(Get(Get(ch_652, "style"), "display"), "none") || SEqS(Invoke(ch_652, "getAttribute", ((V)("display"))), "none")) ? V.True : V.False) is var _t670 && Truthy(_t670) ? _t670 : (Get(root_8, "__cssHidden") is var _t669 && !Truthy(_t669) ? _t669 : Invoke(root_8, "__cssHidden", ch_652))))) {
goto _cont667;
}
cb_653 = Call(boxOf_57, V.Undef, ch_652);
if (Truthy(cb_653)) {
u_650 = Call(unite_42, V.Undef, u_650, Call(mapRect_43, V.Undef, Call(parseTransform_59, V.Undef, Invoke(ch_652, "getAttribute", ((V)("transform")))), cb_653));
}
_cont667: ;
PostInc(ref c_651, 1D);
}
}
return u_650;
}
return V.Null;
return default;
}, 1, "boxOf", false);
mul_58 = Fn((V _self671, int _argc672, V a_678, V c_679, V _a676, V _a677, V[] _rest673) => {
if (!(Truthy(a_678))) {
return c_679;
}
if (!(Truthy(c_679))) {
return a_678;
}
return Arr(((V)(((ToNum(GetIdx(a_678, 0D)) * ToNum(GetIdx(c_679, 0D))) + (ToNum(GetIdx(a_678, 2D)) * ToNum(GetIdx(c_679, 1D)))))), ((V)(((ToNum(GetIdx(a_678, 1D)) * ToNum(GetIdx(c_679, 0D))) + (ToNum(GetIdx(a_678, 3D)) * ToNum(GetIdx(c_679, 1D)))))), ((V)(((ToNum(GetIdx(a_678, 0D)) * ToNum(GetIdx(c_679, 2D))) + (ToNum(GetIdx(a_678, 2D)) * ToNum(GetIdx(c_679, 3D)))))), ((V)(((ToNum(GetIdx(a_678, 1D)) * ToNum(GetIdx(c_679, 2D))) + (ToNum(GetIdx(a_678, 3D)) * ToNum(GetIdx(c_679, 3D)))))), Add(((V)(((ToNum(GetIdx(a_678, 0D)) * ToNum(GetIdx(c_679, 4D))) + (ToNum(GetIdx(a_678, 2D)) * ToNum(GetIdx(c_679, 5D)))))), GetIdx(a_678, 4D)), Add(((V)(((ToNum(GetIdx(a_678, 1D)) * ToNum(GetIdx(c_679, 4D))) + (ToNum(GetIdx(a_678, 3D)) * ToNum(GetIdx(c_679, 5D)))))), GetIdx(a_678, 5D)));
return default;
}, 2, "mul", false);
parseTransform_59 = Fn((V _self680, int _argc681, V s_687, V _a684, V _a685, V _a686, V[] _rest682) => {
V m_688 = default;
V re_689 = default;
V t_690 = default;
V v_691 = default;
V k_692 = default;
V rr_693 = default;
V cs_694 = default;
V sn_695 = default;
if (!(Truthy(s_687))) {
return V.Null;
}
m_688 = V.Null;
re_689 = NewRegExp(RX9, "(matrix|translate|scale|rotate|skewX|skewY)\\s*\\(([^)]*)\\)", "g");
while (Truthy((t_690 = Invoke(re_689, "exec", s_687)))) {
v_691 = Invoke(Invoke(Invoke(GetIdx(t_690, 2D), "split", NewRegExp(RX7, "[\\s,]+", "")), "filter", G("Boolean")), "map", Fn((V _self696, int _argc697, V x_703, V _a700, V _a701, V _a702, V[] _rest698) => {
return Call(F_34, V.Undef, ((V)(ToNum(x_703))));
return default;
}, 1, "", false));
if (SEqS(GetIdx(t_690, 1D), "matrix")) {
k_692 = v_691;
} else {
if (SEqS(GetIdx(t_690, 1D), "translate")) {
k_692 = Arr(((V)(1D)), ((V)(0D)), ((V)(0D)), ((V)(1D)), (GetIdx(v_691, 0D) is var _t704 && Truthy(_t704) ? _t704 : ((V)(0D))), (GetIdx(v_691, 1D) is var _t705 && Truthy(_t705) ? _t705 : ((V)(0D))));
} else {
if (SEqS(GetIdx(t_690, 1D), "scale")) {
k_692 = Arr(GetIdx(v_691, 0D), ((V)(0D)), ((V)(0D)), (GtN(Get(v_691, "length"), 1D) ? GetIdx(v_691, 1D) : GetIdx(v_691, 0D)), ((V)(0D)), ((V)(0D)));
} else {
if (SEqS(GetIdx(t_690, 1D), "rotate")) {
rr_693 = ((V)(((ToNum(GetIdx(v_691, 0D)) * System.Math.PI) / 180D)));
cs_694 = ((V)(FdLibm.Cos(ToNum(rr_693))));
sn_695 = ((V)(FdLibm.Sin(ToNum(rr_693))));
k_692 = Arr(cs_694, sn_695, ((V)((-ToNum(sn_695)))), cs_694, ((V)(0D)), ((V)(0D)));
if (GtN(Get(v_691, "length"), 2D)) {
k_692 = Call(mul_58, V.Undef, Call(mul_58, V.Undef, Arr(((V)(1D)), ((V)(0D)), ((V)(0D)), ((V)(1D)), GetIdx(v_691, 1D), GetIdx(v_691, 2D)), k_692), Arr(((V)(1D)), ((V)(0D)), ((V)(0D)), ((V)(1D)), ((V)((-ToNum(GetIdx(v_691, 1D))))), ((V)((-ToNum(GetIdx(v_691, 2D)))))));
}
} else {
if (SEqS(GetIdx(t_690, 1D), "skewX")) {
k_692 = Arr(((V)(1D)), ((V)(0D)), ((V)(FdLibm.Tan(((ToNum(GetIdx(v_691, 0D)) * System.Math.PI) / 180D)))), ((V)(1D)), ((V)(0D)), ((V)(0D)));
} else {
k_692 = Arr(((V)(1D)), ((V)(FdLibm.Tan(((ToNum(GetIdx(v_691, 0D)) * System.Math.PI) / 180D)))), ((V)(0D)), ((V)(1D)), ((V)(0D)), ((V)(0D)));
}
}
}
}
}
m_688 = Call(mul_58, V.Undef, m_688, k_692);
}
return m_688;
return default;
}, 1, "parseTransform", false);
Ctx2D_61 = Fn((V _self706, int _argc707, V cv_713, V _a710, V _a711, V _a712, V[] _rest708) => {
Set(_self706, "canvas", cv_713);
Set(_self706, "fillStyle", ((V)("#000")));
Set(_self706, "globalAlpha", ((V)(1D)));
return default;
}, 1, "Ctx2D", false);
install_62 = Fn((V _self714, int _argc715, V G_721, V opts_722, V _a719, V _a720, V[] _rest716) => {
V html_723 = default;
V head_724 = default;
V body_725 = default;
V docListeners_726 = default;
V document_727 = default;
V store_728 = default;
V winListeners_729 = default;
opts_722 = (opts_722 is var _t730 && Truthy(_t730) ? _t730 : NewObj(0).V);
html_723 = New(Element_18, ((V)("html")), ((V)("http://www.w3.org/1999/xhtml")));
head_724 = New(Element_18, ((V)("head")), Get(html_723, "namespaceURI"));
body_725 = New(Element_18, ((V)("body")), Get(html_723, "namespaceURI"));
Set(html_723, "__isRoot", (true ? V.True : V.False));
Invoke(html_723, "appendChild", head_724);
Invoke(html_723, "appendChild", body_725);
docListeners_726 = NewObj(0).V;
document_727 = NewObj(17).Put("nodeType", ((V)(9D))).Put("readyState", ((V)("complete"))).Put("documentElement", html_723).Put("head", head_724).Put("body", body_725).Put("hidden", (false ? V.True : V.False)).Put("visibilityState", ((V)("visible"))).Put("fonts", NewObj(1).Put("ready", Invoke(G("Promise"), "resolve")).V).Put("createElementNS", Fn((V _self731, int _argc732, V ns_738, V tag_739, V _a736, V _a737, V[] _rest733) => {
return New(Element_18, tag_739, ns_738);
return default;
}, 2, "createElementNS", false)).Put("createElement", Fn((V _self740, int _argc741, V tag_747, V _a744, V _a745, V _a746, V[] _rest742) => {
return New(Element_18, Invoke(((V)(ToStrS(tag_747))), "toLowerCase"), ((V)("http://www.w3.org/1999/xhtml")));
return default;
}, 1, "createElement", false)).Put("createTextNode", Fn((V _self748, int _argc749, V t_755, V _a752, V _a753, V _a754, V[] _rest750) => {
return New(Text_11, t_755);
return default;
}, 1, "createTextNode", false)).Put("createDocumentFragment", Fn((V _self756, int _argc757, V _a759, V _a760, V _a761, V _a762, V[] _rest758) => {
return New(Fragment_12);
return default;
}, 0, "createDocumentFragment", false)).Put("getElementById", Fn((V _self763, int _argc764, V id_770, V _a767, V _a768, V _a769, V[] _rest765) => {
return Invoke(html_723, "querySelector", ((V)(JsStrBuf.Begin().S("#").V(id_770).End())));
return default;
}, 1, "getElementById", false)).Put("querySelector", Fn((V _self771, int _argc772, V s_778, V _a775, V _a776, V _a777, V[] _rest773) => {
return Invoke(html_723, "querySelector", s_778);
return default;
}, 1, "querySelector", false)).Put("querySelectorAll", Fn((V _self779, int _argc780, V s_786, V _a783, V _a784, V _a785, V[] _rest781) => {
return Invoke(html_723, "querySelectorAll", s_786);
return default;
}, 1, "querySelectorAll", false)).Put("addEventListener", Fn((V _self787, int _argc788, V t_794, V fn_795, V _a792, V _a793, V[] _rest789) => {
Invoke(SetK(docListeners_726, t_794, (GetK(docListeners_726, t_794) is var _t796 && Truthy(_t796) ? _t796 : Arr())), "push", fn_795);
return default;
}, 2, "addEventListener", false)).Put("removeEventListener", Fn((V _self797, int _argc798, V _a800, V _a801, V _a802, V _a803, V[] _rest799) => {

return default;
}, 0, "removeEventListener", false)).V;
Set(G_721, "window", G_721);
Set(G_721, "self", G_721);
Set(G_721, "globalThis", G_721);
Set(G_721, "Node", Node_10);
Set(G_721, "Element", Set(G_721, "SVGElement", Set(G_721, "HTMLElement", Element_18)));
Set(G_721, "Text", Text_11);
Set(G_721, "DocumentFragment", Fragment_12);
Set(G_721, "document", document_727);
Set(G_721, "navigator", (Get(G_721, "navigator") is var _t811 && Truthy(_t811) ? _t811 : NewObj(5).Put("userAgent", ((V)("SquishRigHost"))).Put("hardwareConcurrency", ((V)(8D))).Put("deviceMemory", ((V)(4D))).Put("maxTouchPoints", ((V)(5D))).Put("vibrate", Fn((V _self804, int _argc805, V _a807, V _a808, V _a809, V _a810, V[] _rest806) => {
return (false ? V.True : V.False);
return default;
}, 0, "vibrate", false)).V));
Set(G_721, "location", (Get(G_721, "location") is var _t812 && Truthy(_t812) ? _t812 : NewObj(5).Put("protocol", ((V)("app:"))).Put("href", ((V)("app://rig/"))).Put("search", ((V)(""))).Put("hash", ((V)(""))).Put("pathname", ((V)("/"))).V));
store_728 = NewObj(0).V;
Set(G_721, "localStorage", (Get(G_721, "localStorage") is var _t845 && Truthy(_t845) ? _t845 : NewObj(4).Put("getItem", Fn((V _self813, int _argc814, V k_820, V _a817, V _a818, V _a819, V[] _rest815) => {
return (Truthy(Invoke(Get(Get(G("Object"), "prototype"), "hasOwnProperty"), "call", store_728, k_820)) ? GetK(store_728, k_820) : V.Null);
return default;
}, 1, "getItem", false)).Put("setItem", Fn((V _self821, int _argc822, V k_828, V v_829, V _a826, V _a827, V[] _rest823) => {
SetK(store_728, k_828, ((V)(ToStrS(v_829))));
return default;
}, 2, "setItem", false)).Put("removeItem", Fn((V _self830, int _argc831, V k_837, V _a834, V _a835, V _a836, V[] _rest832) => {
DeleteK(store_728, k_837);
return default;
}, 1, "removeItem", false)).Put("clear", Fn((V _self838, int _argc839, V _a841, V _a842, V _a843, V _a844, V[] _rest840) => {
store_728 = NewObj(0).V;
return default;
}, 0, "clear", false)).V));
Set(G_721, "sessionStorage", (Get(G_721, "sessionStorage") is var _t846 && Truthy(_t846) ? _t846 : Get(G_721, "localStorage")));
winListeners_729 = NewObj(0).V;
Set(G_721, "addEventListener", Fn((V _self847, int _argc848, V t_854, V fn_855, V _a852, V _a853, V[] _rest849) => {
Invoke(SetK(winListeners_729, t_854, (GetK(winListeners_729, t_854) is var _t856 && Truthy(_t856) ? _t856 : Arr())), "push", fn_855);
return default;
}, 2, "", false));
Set(G_721, "removeEventListener", Fn((V _self857, int _argc858, V _a860, V _a861, V _a862, V _a863, V[] _rest859) => {

return default;
}, 0, "", false));
Set(G_721, "dispatchEvent", Fn((V _self864, int _argc865, V ev_871, V _a868, V _a869, V _a870, V[] _rest866) => {
Invoke(Invoke((GetK(winListeners_729, Get(ev_871, "type")) is var _t880 && Truthy(_t880) ? _t880 : Arr()), "slice"), "forEach", Fn((V _self872, int _argc873, V f_879, V _a876, V _a877, V _a878, V[] _rest874) => {
Call(f_879, V.Undef, ev_871);
return default;
}, 1, "", false));
return (true ? V.True : V.False);
return default;
}, 1, "", false));
Set(G_721, "getComputedStyle", Fn((V _self881, int _argc882, V el_888, V _a885, V _a886, V _a887, V[] _rest883) => {
return Get(el_888, "style");
return default;
}, 1, "", false));
Set(G_721, "matchMedia", Fn((V _self889, int _argc890, V _a892, V _a893, V _a894, V _a895, V[] _rest891) => {
return NewObj(4).Put("matches", (false ? V.True : V.False)).Put("addListener", Fn((V _self896, int _argc897, V _a899, V _a900, V _a901, V _a902, V[] _rest898) => {

return default;
}, 0, "addListener", false)).Put("removeListener", Fn((V _self903, int _argc904, V _a906, V _a907, V _a908, V _a909, V[] _rest905) => {

return default;
}, 0, "removeListener", false)).Put("addEventListener", Fn((V _self910, int _argc911, V _a913, V _a914, V _a915, V _a916, V[] _rest912) => {

return default;
}, 0, "addEventListener", false)).V;
return default;
}, 0, "", false));
Set(G_721, "innerWidth", ((V)(832D)));
Set(G_721, "innerHeight", ((V)(384D)));
Set(G_721, "devicePixelRatio", ((V)(2.8125)));
Set(G_721, "Image", Fn((V _self917, int _argc918, V _a920, V _a921, V _a922, V _a923, V[] _rest919) => {
V e_924 = default;
e_924 = New(Element_18, ((V)("img")), ((V)("http://www.w3.org/1999/xhtml")));
return e_924;
return default;
}, 0, "", false));
Set(G_721, "console", (Get(G_721, "console") is var _t946 && Truthy(_t946) ? _t946 : NewObj(3).Put("log", Fn((V _self925, int _argc926, V _a928, V _a929, V _a930, V _a931, V[] _rest927) => {

return default;
}, 0, "log", false)).Put("warn", Fn((V _self932, int _argc933, V _a935, V _a936, V _a937, V _a938, V[] _rest934) => {

return default;
}, 0, "warn", false)).Put("error", Fn((V _self939, int _argc940, V _a942, V _a943, V _a944, V _a945, V[] _rest941) => {

return default;
}, 0, "error", false)).V));
if (Truthy(Get(opts_722, "readFile"))) {
Set(G_721, "fetch", Fn((V _self947, int _argc948, V url_954, V _a951, V _a952, V _a953, V[] _rest949) => {
V path_955 = default;
path_955 = Invoke(GetIdx(Invoke(GetIdx(Invoke(((V)(ToStrS(url_954))), "split", ((V)("?"))), 0D), "split", ((V)("#"))), 0D), "replace", NewRegExp(RX10, "^\\.\\/", ""), ((V)("")));
return New(G("Promise"), Fn((V _self956, int _argc957, V res_963, V _a960, V _a961, V _a962, V[] _rest958) => {
V text_964 = default;
text_964 = V.Null;
try {
text_964 = Invoke(opts_722, "readFile", path_955);
} catch (System.Exception _ex965) {
V e_966 = default;
e_966 = Caught(_ex965);
text_964 = V.Null;
}
Call(res_963, V.Undef, NewObj(4).Put("ok", (!text_964.IsNullish ? V.True : V.False)).Put("status", ((V)((!text_964.IsNullish ? 200D : 404D)))).Put("text", Fn((V _self967, int _argc968, V _a970, V _a971, V _a972, V _a973, V[] _rest969) => {
return Invoke(G("Promise"), "resolve", (text_964 is var _t974 && Truthy(_t974) ? _t974 : ((V)(""))));
return default;
}, 0, "text", false)).Put("json", Fn((V _self975, int _argc976, V _a978, V _a979, V _a980, V _a981, V[] _rest977) => {
return Invoke(G("Promise"), "resolve", Invoke(G("JSON"), "parse", (text_964 is var _t982 && Truthy(_t982) ? _t982 : ((V)("null")))));
return default;
}, 0, "json", false)).V);
return default;
}, 1, "", false));
return default;
}, 1, "", false));
}
Set(G_721, "__rigShim", NewObj(4).Put("Element", Element_18).Put("serialize", serialize_33).Put("canvases", CANVASES_60).Put("parseTransform", parseTransform_59).V);
return G_721;
return default;
}, 2, "install", false);
SVG_NS_9 = ((V)("http://www.w3.org/2000/svg"));
Object_defineProperty(Get(Node_10, "prototype"), ((V)("firstChild")), NewObj(1).Put("get", Fn((V _self983, int _argc984, V _a986, V _a987, V _a988, V _a989, V[] _rest985) => {
return (GetIdx(Get(_self983, "childNodes"), 0D) is var _t990 && Truthy(_t990) ? _t990 : V.Null);
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Node_10, "prototype"), ((V)("lastChild")), NewObj(1).Put("get", Fn((V _self991, int _argc992, V _a994, V _a995, V _a996, V _a997, V[] _rest993) => {
return (GetIdx(Get(_self991, "childNodes"), (ToNum(Get(Get(_self991, "childNodes"), "length")) - 1D)) is var _t998 && Truthy(_t998) ? _t998 : V.Null);
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Node_10, "prototype"), ((V)("nextSibling")), NewObj(1).Put("get", Fn((V _self999, int _argc1000, V _a1002, V _a1003, V _a1004, V _a1005, V[] _rest1001) => {
V p_1006 = default;
V i_1007 = default;
p_1006 = Get(_self999, "parentNode");
if (!(Truthy(p_1006))) {
return V.Null;
}
i_1007 = Invoke(Get(p_1006, "childNodes"), "indexOf", _self999);
return (GetK(Get(p_1006, "childNodes"), Add(i_1007, ((V)(1D)))) is var _t1008 && Truthy(_t1008) ? _t1008 : V.Null);
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Node_10, "prototype"), ((V)("previousSibling")), NewObj(1).Put("get", Fn((V _self1009, int _argc1010, V _a1012, V _a1013, V _a1014, V _a1015, V[] _rest1011) => {
V p_1016 = default;
V i_1017 = default;
p_1016 = Get(_self1009, "parentNode");
if (!(Truthy(p_1016))) {
return V.Null;
}
i_1017 = Invoke(Get(p_1016, "childNodes"), "indexOf", _self1009);
return (GtN(i_1017, 0D) ? GetIdx(Get(p_1016, "childNodes"), (ToNum(i_1017) - 1D)) : V.Null);
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Node_10, "prototype"), ((V)("parentElement")), NewObj(1).Put("get", Fn((V _self1018, int _argc1019, V _a1021, V _a1022, V _a1023, V _a1024, V[] _rest1020) => {
return (Truthy((Get(_self1018, "parentNode") is var _t1025 && !Truthy(_t1025) ? _t1025 : (SEqN(Get(Get(_self1018, "parentNode"), "nodeType"), 1D) ? V.True : V.False))) ? Get(_self1018, "parentNode") : V.Null);
return default;
}, 0, "get", false)).V);
Set(Get(Node_10, "prototype"), "appendChild", Fn((V _self1026, int _argc1027, V n_1033, V _a1030, V _a1031, V _a1032, V[] _rest1028) => {
return Invoke(_self1026, "insertBefore", n_1033, V.Null);
return default;
}, 1, "", false));
Set(Get(Node_10, "prototype"), "insertBefore", Fn((V _self1034, int _argc1035, V n_1041, V @ref_1042, V _a1039, V _a1040, V[] _rest1036) => {
V kids_1043 = default;
V k_1044 = default;
V i_1045 = default;
if (SEqN(Get(n_1041, "nodeType"), 11D)) {
kids_1043 = Invoke(Get(n_1041, "childNodes"), "slice");
{
k_1044 = ((V)(0D));
while (true) {
if (!(Lt(k_1044, Get(kids_1043, "length")))) break;
Invoke(_self1034, "insertBefore", GetK(kids_1043, k_1044), @ref_1042);
PostInc(ref k_1044, 1D);
}
}
return n_1041;
}
if (Truthy(Get(n_1041, "parentNode"))) {
Invoke(Get(n_1041, "parentNode"), "removeChild", n_1041);
}
i_1045 = (Truthy(@ref_1042) ? Invoke(Get(_self1034, "childNodes"), "indexOf", @ref_1042) : ((V)((-1D))));
if (LtN(i_1045, 0D)) {
Invoke(Get(_self1034, "childNodes"), "push", n_1041);
} else {
Invoke(Get(_self1034, "childNodes"), "splice", i_1045, ((V)(0D)), n_1041);
}
Set(n_1041, "parentNode", _self1034);
return n_1041;
return default;
}, 2, "", false));
Set(Get(Node_10, "prototype"), "removeChild", Fn((V _self1047, int _argc1048, V n_1054, V _a1051, V _a1052, V _a1053, V[] _rest1049) => {
V i_1055 = default;
i_1055 = Invoke(Get(_self1047, "childNodes"), "indexOf", n_1054);
if (GeN(i_1055, 0D)) {
Invoke(Get(_self1047, "childNodes"), "splice", i_1055, ((V)(1D)));
Set(n_1054, "parentNode", V.Null);
}
return n_1054;
return default;
}, 1, "", false));
Set(Get(Node_10, "prototype"), "replaceChild", Fn((V _self1056, int _argc1057, V n_1063, V old_1064, V _a1061, V _a1062, V[] _rest1058) => {
Invoke(_self1056, "insertBefore", n_1063, old_1064);
return Invoke(_self1056, "removeChild", old_1064);
return default;
}, 2, "", false));
Set(Get(Node_10, "prototype"), "after", Fn((V _self1065, int _argc1066, V _a1068, V _a1069, V _a1070, V _a1071, V[] _rest1067) => {
V p_1073 = default;
V @ref_1074 = default;
V i_1075 = default;
V n_1076 = default;
V _arguments1072 = Arguments(_argc1066, _a1068, _a1069, _a1070, _a1071, _rest1067);
p_1073 = Get(_self1065, "parentNode");
if (!(Truthy(p_1073))) {
return default;
}
@ref_1074 = Get(_self1065, "nextSibling");
{
i_1075 = ((V)(0D));
while (true) {
if (!(Lt(i_1075, Get(_arguments1072, "length")))) break;
n_1076 = GetK(_arguments1072, i_1075);
if (string.Equals(Typeof(n_1076), "string")) {
n_1076 = New(Text_11, n_1076);
}
Invoke(p_1073, "insertBefore", n_1076, @ref_1074);
PostInc(ref i_1075, 1D);
}
}
return default;
}, 0, "", false));
Set(Get(Node_10, "prototype"), "before", Fn((V _self1078, int _argc1079, V _a1081, V _a1082, V _a1083, V _a1084, V[] _rest1080) => {
V p_1086 = default;
V i_1087 = default;
V n_1088 = default;
V _arguments1085 = Arguments(_argc1079, _a1081, _a1082, _a1083, _a1084, _rest1080);
p_1086 = Get(_self1078, "parentNode");
if (!(Truthy(p_1086))) {
return default;
}
{
i_1087 = ((V)(0D));
while (true) {
if (!(Lt(i_1087, Get(_arguments1085, "length")))) break;
n_1088 = GetK(_arguments1085, i_1087);
if (string.Equals(Typeof(n_1088), "string")) {
n_1088 = New(Text_11, n_1088);
}
Invoke(p_1086, "insertBefore", n_1088, _self1078);
PostInc(ref i_1087, 1D);
}
}
return default;
}, 0, "", false));
Set(Get(Node_10, "prototype"), "remove", Fn((V _self1090, int _argc1091, V _a1093, V _a1094, V _a1095, V _a1096, V[] _rest1092) => {
if (Truthy(Get(_self1090, "parentNode"))) {
Invoke(Get(_self1090, "parentNode"), "removeChild", _self1090);
}
return default;
}, 0, "", false));
Set(Get(Node_10, "prototype"), "compareDocumentPosition", Fn((V _self1097, int _argc1098, V other_1104, V _a1101, V _a1102, V _a1103, V[] _rest1099) => {
V a_1105 = default;
V b_1106 = default;
V n_1107 = default;
V i_1108 = default;
V p_1109 = default;
if (SEq(other_1104, _self1097)) {
return ((V)(0D));
}
a_1105 = Arr();
b_1106 = Arr();
n_1107 = _self1097;
while (Truthy(n_1107)) {
Invoke(a_1105, "unshift", n_1107);
n_1107 = Get(n_1107, "parentNode");
}
n_1107 = other_1104;
while (Truthy(n_1107)) {
Invoke(b_1106, "unshift", n_1107);
n_1107 = Get(n_1107, "parentNode");
}
if (!SEq(GetIdx(a_1105, 0D), GetIdx(b_1106, 0D))) {
return ((V)(((double)(ToInt32(1D) | ToInt32(32D)))));
}
i_1108 = ((V)(0D));
while (((Lt(i_1108, Get(a_1105, "length")) && Lt(i_1108, Get(b_1106, "length"))) && SEq(GetK(a_1105, i_1108), GetK(b_1106, i_1108)))) {
PostInc(ref i_1108, 1D);
}
if (SEq(i_1108, Get(a_1105, "length"))) {
return ((V)(((double)(ToInt32(16D) | ToInt32(4D)))));
}
if (SEq(i_1108, Get(b_1106, "length"))) {
return ((V)(((double)(ToInt32(8D) | ToInt32(2D)))));
}
p_1109 = GetIdx(a_1105, (ToNum(i_1108) - 1D));
return ((V)((Gt(Invoke(Get(p_1109, "childNodes"), "indexOf", GetK(b_1106, i_1108)), Invoke(Get(p_1109, "childNodes"), "indexOf", GetK(a_1105, i_1108))) ? 4D : 2D)));
return default;
}, 1, "", false));
Set(Get(Node_10, "prototype"), "contains", Fn((V _self1110, int _argc1111, V n_1117, V _a1114, V _a1115, V _a1116, V[] _rest1112) => {
while (Truthy(n_1117)) {
if (SEq(n_1117, _self1110)) {
return (true ? V.True : V.False);
}
n_1117 = Get(n_1117, "parentNode");
}
return (false ? V.True : V.False);
return default;
}, 1, "", false));
Set(Get(Node_10, "prototype"), "hasChildNodes", Fn((V _self1118, int _argc1119, V _a1121, V _a1122, V _a1123, V _a1124, V[] _rest1120) => {
return (GtN(Get(Get(_self1118, "childNodes"), "length"), 0D) ? V.True : V.False);
return default;
}, 0, "", false));
Set(Text_11, "prototype", Object_create(Get(Node_10, "prototype")));
Object_defineProperty(Get(Text_11, "prototype"), ((V)("textContent")), NewObj(2).Put("get", Fn((V _self1125, int _argc1126, V _a1128, V _a1129, V _a1130, V _a1131, V[] _rest1127) => {
return Get(_self1125, "data");
return default;
}, 0, "get", false)).Put("set", Fn((V _self1132, int _argc1133, V v_1139, V _a1136, V _a1137, V _a1138, V[] _rest1134) => {
Set(_self1132, "data", ((V)(ToStrS(v_1139))));
return default;
}, 1, "set", false)).V);
Object_defineProperty(Get(Text_11, "prototype"), ((V)("nodeValue")), NewObj(2).Put("get", Fn((V _self1140, int _argc1141, V _a1143, V _a1144, V _a1145, V _a1146, V[] _rest1142) => {
return Get(_self1140, "data");
return default;
}, 0, "get", false)).Put("set", Fn((V _self1147, int _argc1148, V v_1154, V _a1151, V _a1152, V _a1153, V[] _rest1149) => {
Set(_self1147, "data", ((V)(ToStrS(v_1154))));
return default;
}, 1, "set", false)).V);
Set(Get(Text_11, "prototype"), "cloneNode", Fn((V _self1155, int _argc1156, V _a1158, V _a1159, V _a1160, V _a1161, V[] _rest1157) => {
return New(Text_11, Get(_self1155, "data"));
return default;
}, 0, "", false));
Set(Fragment_12, "prototype", Object_create(Get(Node_10, "prototype")));
camel_13 = Fn((V _self1162, int _argc1163, V s_1169, V _a1166, V _a1167, V _a1168, V[] _rest1164) => {
return Invoke(Invoke(Invoke(s_1169, "trim"), "replace", NewRegExp(RX12, "^-webkit-", ""), ((V)("webkit-"))), "replace", NewRegExp(RX11, "-([a-z])", "g"), Fn((V _self1170, int _argc1171, V m_1177, V c_1178, V _a1175, V _a1176, V[] _rest1172) => {
return Invoke(c_1178, "toUpperCase");
return default;
}, 2, "", false));
return default;
}, 1, "", false);
kebab_14 = Fn((V _self1179, int _argc1180, V s_1186, V _a1183, V _a1184, V _a1185, V[] _rest1181) => {
return Invoke(Invoke(s_1186, "replace", NewRegExp(RX14, "[A-Z]", "g"), Fn((V _self1187, int _argc1188, V c_1194, V _a1191, V _a1192, V _a1193, V[] _rest1189) => {
return ((V)(JsStrBuf.Begin().S("-").V(Invoke(c_1194, "toLowerCase")).End()));
return default;
}, 1, "", false)), "replace", NewRegExp(RX13, "^webkit-", ""), ((V)("-webkit-")));
return default;
}, 1, "", false);
Object_defineProperty(Get(Style_15, "prototype"), ((V)("cssText")), NewObj(2).Put("get", Fn((V _self1195, int _argc1196, V _a1198, V _a1199, V _a1200, V _a1201, V[] _rest1197) => {
V o_1202 = default;
V k_1203 = default;
o_1202 = Arr();
{
foreach (V _k1204 in ForInKeys(_self1195)) {
k_1203 = _k1204;
if (Truthy(((Invoke(Get(Get(G("Object"), "prototype"), "hasOwnProperty"), "call", _self1195, k_1203) is var _t1205 && !Truthy(_t1205) ? _t1205 : (!SEqS(GetK(_self1195, k_1203), "") ? V.True : V.False)) is var _t1206 && !Truthy(_t1206) ? _t1206 : (!GetK(_self1195, k_1203).IsNullish ? V.True : V.False)))) {
Invoke(o_1202, "push", ((V)(JsStrBuf.Begin().V(Call(kebab_14, V.Undef, k_1203)).S(": ").V(GetK(_self1195, k_1203)).S(";").End())));
}
}
}
return Invoke(o_1202, "join", ((V)(" ")));
return default;
}, 0, "get", false)).Put("set", Fn((V _self1207, int _argc1208, V v_1214, V _a1211, V _a1212, V _a1213, V[] _rest1209) => {
V k_1215 = default;
V parts_1216 = default;
V i_1217 = default;
V j_1218 = default;
{
foreach (V _k1219 in ForInKeys(_self1207)) {
k_1215 = _k1219;
if (Truthy(Invoke(Get(Get(G("Object"), "prototype"), "hasOwnProperty"), "call", _self1207, k_1215))) {
DeleteK(_self1207, k_1215);
}
}
}
parts_1216 = Invoke(((V)(ToStrS(v_1214))), "split", ((V)(";")));
{
i_1217 = ((V)(0D));
while (true) {
if (!(Lt(i_1217, Get(parts_1216, "length")))) break;
j_1218 = Invoke(GetK(parts_1216, i_1217), "indexOf", ((V)(":")));
if (GtN(j_1218, 0D)) {
SetK(_self1207, Call(camel_13, V.Undef, Invoke(GetK(parts_1216, i_1217), "slice", ((V)(0D)), j_1218)), Invoke(Invoke(GetK(parts_1216, i_1217), "slice", Add(j_1218, ((V)(1D)))), "trim"));
}
PostInc(ref i_1217, 1D);
}
}
return default;
}, 1, "set", false)).V);
Set(Get(Style_15, "prototype"), "setProperty", Fn((V _self1221, int _argc1222, V k_1228, V v_1229, V _a1226, V _a1227, V[] _rest1223) => {
SetK(_self1221, Call(camel_13, V.Undef, k_1228), ((V)(ToStrS(v_1229))));
return default;
}, 2, "", false));
Set(Get(Style_15, "prototype"), "getPropertyValue", Fn((V _self1230, int _argc1231, V k_1237, V _a1234, V _a1235, V _a1236, V[] _rest1232) => {
return (GetK(_self1230, Call(camel_13, V.Undef, k_1237)) is var _t1238 && Truthy(_t1238) ? _t1238 : ((V)("")));
return default;
}, 1, "", false));
Set(Get(Style_15, "prototype"), "removeProperty", Fn((V _self1239, int _argc1240, V k_1246, V _a1243, V _a1244, V _a1245, V[] _rest1241) => {
V c_1247 = default;
V v_1248 = default;
c_1247 = Call(camel_13, V.Undef, k_1246);
v_1248 = (GetK(_self1239, c_1247) is var _t1249 && Truthy(_t1249) ? _t1249 : ((V)("")));
DeleteK(_self1239, c_1247);
return v_1248;
return default;
}, 1, "", false));
Set(Get(ClassList_16, "prototype"), "_get", Fn((V _self1250, int _argc1251, V _a1253, V _a1254, V _a1255, V _a1256, V[] _rest1252) => {
return Invoke(Invoke((Invoke(Get(_self1250, "el"), "getAttribute", ((V)("class"))) is var _t1257 && Truthy(_t1257) ? _t1257 : ((V)(""))), "split", NewRegExp(RX2, "\\s+", "")), "filter", G("Boolean"));
return default;
}, 0, "", false));
Set(Get(ClassList_16, "prototype"), "_set", Fn((V _self1258, int _argc1259, V a_1265, V _a1262, V _a1263, V _a1264, V[] _rest1260) => {
Invoke(Get(_self1258, "el"), "setAttribute", ((V)("class")), Invoke(a_1265, "join", ((V)(" "))));
return default;
}, 1, "", false));
Set(Get(ClassList_16, "prototype"), "contains", Fn((V _self1266, int _argc1267, V c_1273, V _a1270, V _a1271, V _a1272, V[] _rest1268) => {
return (GeN(Invoke(Invoke(_self1266, "_get"), "indexOf", c_1273), 0D) ? V.True : V.False);
return default;
}, 1, "", false));
Set(Get(ClassList_16, "prototype"), "add", Fn((V _self1274, int _argc1275, V _a1277, V _a1278, V _a1279, V _a1280, V[] _rest1276) => {
V a_1282 = default;
V i_1283 = default;
V _arguments1281 = Arguments(_argc1275, _a1277, _a1278, _a1279, _a1280, _rest1276);
a_1282 = Invoke(_self1274, "_get");
{
i_1283 = ((V)(0D));
while (true) {
if (!(Lt(i_1283, Get(_arguments1281, "length")))) break;
if (LtN(Invoke(a_1282, "indexOf", GetK(_arguments1281, i_1283)), 0D)) {
Invoke(a_1282, "push", GetK(_arguments1281, i_1283));
}
PostInc(ref i_1283, 1D);
}
}
Invoke(_self1274, "_set", a_1282);
return default;
}, 0, "", false));
Set(Get(ClassList_16, "prototype"), "remove", Fn((V _self1285, int _argc1286, V _a1288, V _a1289, V _a1290, V _a1291, V[] _rest1287) => {
V r_1293 = default;
V _arguments1292 = Arguments(_argc1286, _a1288, _a1289, _a1290, _a1291, _rest1287);
r_1293 = Invoke(Get(Arr(), "slice"), "call", _arguments1292);
Invoke(_self1285, "_set", Invoke(Invoke(_self1285, "_get"), "filter", Fn((V _self1294, int _argc1295, V c_1301, V _a1298, V _a1299, V _a1300, V[] _rest1296) => {
return (LtN(Invoke(r_1293, "indexOf", c_1301), 0D) ? V.True : V.False);
return default;
}, 1, "", false)));
return default;
}, 0, "", false));
Set(Get(ClassList_16, "prototype"), "toggle", Fn((V _self1302, int _argc1303, V c_1309, V on_1310, V _a1307, V _a1308, V[] _rest1304) => {
V has_1311 = default;
has_1311 = Invoke(_self1302, "contains", c_1309);
if (SEq(on_1310, V.Undef)) {
on_1310 = (!(Truthy(has_1311)) ? V.True : V.False);
}
if (Truthy((on_1310 is var _t1312 && !Truthy(_t1312) ? _t1312 : (!(Truthy(has_1311)) ? V.True : V.False)))) {
Invoke(_self1302, "add", c_1309);
}
if (Truthy(((!(Truthy(on_1310)) ? V.True : V.False) is var _t1313 && !Truthy(_t1313) ? _t1313 : has_1311))) {
Invoke(_self1302, "remove", c_1309);
}
return on_1310;
return default;
}, 2, "", false));
NEXT_ID_17 = ((V)(1D));
Set(Element_18, "prototype", Object_create(Get(Node_10, "prototype")));
Set(Get(Element_18, "prototype"), "setAttribute", Fn((V _self1314, int _argc1315, V k_1321, V v_1322, V _a1319, V _a1320, V[] _rest1316) => {
V i_1323 = default;
k_1321 = ((V)(ToStrS(k_1321)));
v_1322 = ((V)(ToStrS(v_1322)));
if (SEqS(k_1321, "style")) {
Set(Get(_self1314, "style"), "cssText", v_1322);
return default;
}
{
i_1323 = ((V)(0D));
while (true) {
if (!(Lt(i_1323, Get(Get(_self1314, "_attrs"), "length")))) break;
if (SEq(GetIdx(GetK(Get(_self1314, "_attrs"), i_1323), 0D), k_1321)) {
SetIdx(GetK(Get(_self1314, "_attrs"), i_1323), 1D, v_1322);
return default;
}
PostInc(ref i_1323, 1D);
}
}
Invoke(Get(_self1314, "_attrs"), "push", Arr(k_1321, v_1322));
return default;
}, 2, "", false));
Set(Get(Element_18, "prototype"), "setAttributeNS", Fn((V _self1325, int _argc1326, V ns_1332, V k_1333, V v_1334, V _a1331, V[] _rest1327) => {
Invoke(_self1325, "setAttribute", k_1333, v_1334);
return default;
}, 3, "", false));
Set(Get(Element_18, "prototype"), "getAttribute", Fn((V _self1335, int _argc1336, V k_1342, V _a1339, V _a1340, V _a1341, V[] _rest1337) => {
V s_1343 = default;
V i_1344 = default;
if (SEqS(k_1342, "style")) {
s_1343 = Get(Get(_self1335, "style"), "cssText");
return (s_1343 is var _t1345 && Truthy(_t1345) ? _t1345 : V.Null);
}
{
i_1344 = ((V)(0D));
while (true) {
if (!(Lt(i_1344, Get(Get(_self1335, "_attrs"), "length")))) break;
if (SEq(GetIdx(GetK(Get(_self1335, "_attrs"), i_1344), 0D), k_1342)) {
return GetIdx(GetK(Get(_self1335, "_attrs"), i_1344), 1D);
}
PostInc(ref i_1344, 1D);
}
}
return V.Null;
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "getAttributeNS", Fn((V _self1347, int _argc1348, V ns_1354, V k_1355, V _a1352, V _a1353, V[] _rest1349) => {
return Invoke(_self1347, "getAttribute", k_1355);
return default;
}, 2, "", false));
Set(Get(Element_18, "prototype"), "hasAttribute", Fn((V _self1356, int _argc1357, V k_1363, V _a1360, V _a1361, V _a1362, V[] _rest1358) => {
return (!SEq(Invoke(_self1356, "getAttribute", k_1363), V.Null) ? V.True : V.False);
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "removeAttribute", Fn((V _self1364, int _argc1365, V k_1371, V _a1368, V _a1369, V _a1370, V[] _rest1366) => {
V i_1372 = default;
if (SEqS(k_1371, "style")) {
Set(Get(_self1364, "style"), "cssText", ((V)("")));
return default;
}
{
i_1372 = ((V)(0D));
while (true) {
if (!(Lt(i_1372, Get(Get(_self1364, "_attrs"), "length")))) break;
if (SEq(GetIdx(GetK(Get(_self1364, "_attrs"), i_1372), 0D), k_1371)) {
Invoke(Get(_self1364, "_attrs"), "splice", i_1372, ((V)(1D)));
return default;
}
PostInc(ref i_1372, 1D);
}
}
return default;
}, 1, "", false));
Object_defineProperty(Get(Element_18, "prototype"), ((V)("attributes")), NewObj(1).Put("get", Fn((V _self1374, int _argc1375, V _a1377, V _a1378, V _a1379, V _a1380, V[] _rest1376) => {
return Invoke(Get(_self1374, "_attrs"), "map", Fn((V _self1381, int _argc1382, V a_1388, V _a1385, V _a1386, V _a1387, V[] _rest1383) => {
return NewObj(4).Put("name", GetIdx(a_1388, 0D)).Put("value", GetIdx(a_1388, 1D)).Put("nodeName", GetIdx(a_1388, 0D)).Put("nodeValue", GetIdx(a_1388, 1D)).V;
return default;
}, 1, "", false));
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("children")), NewObj(1).Put("get", Fn((V _self1389, int _argc1390, V _a1392, V _a1393, V _a1394, V _a1395, V[] _rest1391) => {
return Invoke(Get(_self1389, "childNodes"), "filter", Fn((V _self1396, int _argc1397, V n_1403, V _a1400, V _a1401, V _a1402, V[] _rest1398) => {
return (SEqN(Get(n_1403, "nodeType"), 1D) ? V.True : V.False);
return default;
}, 1, "", false));
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("childElementCount")), NewObj(1).Put("get", Fn((V _self1404, int _argc1405, V _a1407, V _a1408, V _a1409, V _a1410, V[] _rest1406) => {
return Get(Get(_self1404, "children"), "length");
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("firstElementChild")), NewObj(1).Put("get", Fn((V _self1411, int _argc1412, V _a1414, V _a1415, V _a1416, V _a1417, V[] _rest1413) => {
return (GetIdx(Get(_self1411, "children"), 0D) is var _t1418 && Truthy(_t1418) ? _t1418 : V.Null);
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("lastElementChild")), NewObj(1).Put("get", Fn((V _self1419, int _argc1420, V _a1422, V _a1423, V _a1424, V _a1425, V[] _rest1421) => {
V c_1426 = default;
c_1426 = Get(_self1419, "children");
return (GetIdx(c_1426, (ToNum(Get(c_1426, "length")) - 1D)) is var _t1427 && Truthy(_t1427) ? _t1427 : V.Null);
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("classList")), NewObj(1).Put("get", Fn((V _self1428, int _argc1429, V _a1431, V _a1432, V _a1433, V _a1434, V[] _rest1430) => {
return New(ClassList_16, _self1428);
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("id")), NewObj(2).Put("get", Fn((V _self1435, int _argc1436, V _a1438, V _a1439, V _a1440, V _a1441, V[] _rest1437) => {
return (Invoke(_self1435, "getAttribute", ((V)("id"))) is var _t1442 && Truthy(_t1442) ? _t1442 : ((V)("")));
return default;
}, 0, "get", false)).Put("set", Fn((V _self1443, int _argc1444, V v_1450, V _a1447, V _a1448, V _a1449, V[] _rest1445) => {
Invoke(_self1443, "setAttribute", ((V)("id")), v_1450);
return default;
}, 1, "set", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("className")), NewObj(2).Put("get", Fn((V _self1451, int _argc1452, V _a1454, V _a1455, V _a1456, V _a1457, V[] _rest1453) => {
return (Invoke(_self1451, "getAttribute", ((V)("class"))) is var _t1458 && Truthy(_t1458) ? _t1458 : ((V)("")));
return default;
}, 0, "get", false)).Put("set", Fn((V _self1459, int _argc1460, V v_1466, V _a1463, V _a1464, V _a1465, V[] _rest1461) => {
Invoke(_self1459, "setAttribute", ((V)("class")), v_1466);
return default;
}, 1, "set", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("textContent")), NewObj(2).Put("get", Fn((V _self1467, int _argc1468, V _a1470, V _a1471, V _a1472, V _a1473, V[] _rest1469) => {
return Invoke(Invoke(Get(_self1467, "childNodes"), "map", Fn((V _self1474, int _argc1475, V n_1481, V _a1478, V _a1479, V _a1480, V[] _rest1476) => {
return Get(n_1481, "textContent");
return default;
}, 1, "", false)), "join", ((V)("")));
return default;
}, 0, "get", false)).Put("set", Fn((V _self1482, int _argc1483, V v_1489, V _a1486, V _a1487, V _a1488, V[] _rest1484) => {
Invoke(Get(_self1482, "childNodes"), "forEach", Fn((V _self1490, int _argc1491, V n_1497, V _a1494, V _a1495, V _a1496, V[] _rest1492) => {
Set(n_1497, "parentNode", V.Null);
return default;
}, 1, "", false));
Set(_self1482, "childNodes", Arr());
if ((!SEqS(v_1489, "") && !v_1489.IsNullish)) {
Invoke(_self1482, "appendChild", New(Text_11, v_1489));
}
return default;
}, 1, "set", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("innerHTML")), NewObj(2).Put("get", Fn((V _self1498, int _argc1499, V _a1501, V _a1502, V _a1503, V _a1504, V[] _rest1500) => {
return Invoke(Invoke(Get(_self1498, "childNodes"), "map", serialize_33), "join", ((V)("")));
return default;
}, 0, "get", false)).Put("set", Fn((V _self1505, int _argc1506, V v_1512, V _a1509, V _a1510, V _a1511, V[] _rest1507) => {
Invoke(Get(_self1505, "childNodes"), "forEach", Fn((V _self1513, int _argc1514, V n_1520, V _a1517, V _a1518, V _a1519, V[] _rest1515) => {
Set(n_1520, "parentNode", V.Null);
return default;
}, 1, "", false));
Set(_self1505, "childNodes", Arr());
Call(parseInto_30, V.Undef, _self1505, ((V)(ToStrS(v_1512))), Get(_self1505, "namespaceURI"));
return default;
}, 1, "set", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("outerHTML")), NewObj(1).Put("get", Fn((V _self1521, int _argc1522, V _a1524, V _a1525, V _a1526, V _a1527, V[] _rest1523) => {
return Call(serialize_33, V.Undef, _self1521);
return default;
}, 0, "get", false)).V);
Set(Get(Element_18, "prototype"), "cloneNode", Fn((V _self1528, int _argc1529, V deep_1535, V _a1532, V _a1533, V _a1534, V[] _rest1530) => {
V e_1536 = default;
e_1536 = New(Element_18, Get(_self1528, "tagName"), Get(_self1528, "namespaceURI"));
Set(e_1536, "_attrs", Invoke(Get(_self1528, "_attrs"), "map", Fn((V _self1537, int _argc1538, V a_1544, V _a1541, V _a1542, V _a1543, V[] _rest1539) => {
return Arr(GetIdx(a_1544, 0D), GetIdx(a_1544, 1D));
return default;
}, 1, "", false)));
Set(Get(e_1536, "style"), "cssText", Get(Get(_self1528, "style"), "cssText"));
if (Truthy(deep_1535)) {
Invoke(Get(_self1528, "childNodes"), "forEach", Fn((V _self1545, int _argc1546, V c_1552, V _a1549, V _a1550, V _a1551, V[] _rest1547) => {
Invoke(e_1536, "appendChild", Invoke(c_1552, "cloneNode", (true ? V.True : V.False)));
return default;
}, 1, "", false));
}
return e_1536;
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "addEventListener", Fn((V _self1553, int _argc1554, V t_1560, V fn_1561, V _a1558, V _a1559, V[] _rest1555) => {
Invoke(SetK(Get(_self1553, "_listeners"), t_1560, (GetK(Get(_self1553, "_listeners"), t_1560) is var _t1562 && Truthy(_t1562) ? _t1562 : Arr())), "push", fn_1561);
return default;
}, 2, "", false));
Set(Get(Element_18, "prototype"), "removeEventListener", Fn((V _self1563, int _argc1564, V t_1570, V fn_1571, V _a1568, V _a1569, V[] _rest1565) => {
V a_1572 = default;
V i_1573 = default;
a_1572 = GetK(Get(_self1563, "_listeners"), t_1570);
if (Truthy(a_1572)) {
i_1573 = Invoke(a_1572, "indexOf", fn_1571);
if (GeN(i_1573, 0D)) {
Invoke(a_1572, "splice", i_1573, ((V)(1D)));
}
}
return default;
}, 2, "", false));
Set(Get(Element_18, "prototype"), "dispatchEvent", Fn((V _self1574, int _argc1575, V ev_1581, V _a1578, V _a1579, V _a1580, V[] _rest1576) => {
V a_1582 = default;
V i_1583 = default;
Set(ev_1581, "target", (Get(ev_1581, "target") is var _t1584 && Truthy(_t1584) ? _t1584 : _self1574));
a_1582 = Invoke((GetK(Get(_self1574, "_listeners"), Get(ev_1581, "type")) is var _t1585 && Truthy(_t1585) ? _t1585 : Arr()), "slice");
{
i_1583 = ((V)(0D));
while (true) {
if (!(Lt(i_1583, Get(a_1582, "length")))) break;
Invoke(GetK(a_1582, i_1583), "call", _self1574, ev_1581);
PostInc(ref i_1583, 1D);
}
}
return (true ? V.True : V.False);
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "insertAdjacentHTML", Fn((V _self1587, int _argc1588, V where_1594, V html_1595, V _a1592, V _a1593, V[] _rest1589) => {
V f_1596 = default;
f_1596 = New(Fragment_12);
Call(parseInto_30, V.Undef, f_1596, ((V)(ToStrS(html_1595))), Get(_self1587, "namespaceURI"));
if (SEqS(where_1594, "beforeend")) {
Invoke(_self1587, "appendChild", f_1596);
} else {
if (SEqS(where_1594, "afterbegin")) {
Invoke(_self1587, "insertBefore", f_1596, Get(_self1587, "firstChild"));
} else {
if (Truthy(((SEqS(where_1594, "beforebegin") ? V.True : V.False) is var _t1597 && !Truthy(_t1597) ? _t1597 : Get(_self1587, "parentNode")))) {
Invoke(Get(_self1587, "parentNode"), "insertBefore", f_1596, _self1587);
} else {
if (Truthy(((SEqS(where_1594, "afterend") ? V.True : V.False) is var _t1598 && !Truthy(_t1598) ? _t1598 : Get(_self1587, "parentNode")))) {
Invoke(Get(_self1587, "parentNode"), "insertBefore", f_1596, Get(_self1587, "nextSibling"));
}
}
}
}
return default;
}, 2, "", false));
Set(Get(Element_18, "prototype"), "insertAdjacentElement", Fn((V _self1599, int _argc1600, V where_1606, V el_1607, V _a1604, V _a1605, V[] _rest1601) => {
V f_1608 = default;
V h_1609 = default;
f_1608 = New(Fragment_12);
Invoke(f_1608, "appendChild", el_1607);
h_1609 = _self1599;
if (SEqS(where_1606, "beforeend")) {
Invoke(h_1609, "appendChild", el_1607);
} else {
if (SEqS(where_1606, "afterbegin")) {
Invoke(h_1609, "insertBefore", el_1607, Get(h_1609, "firstChild"));
} else {
if (SEqS(where_1606, "beforebegin")) {
Invoke(Get(h_1609, "parentNode"), "insertBefore", el_1607, h_1609);
} else {
Invoke(Get(h_1609, "parentNode"), "insertBefore", el_1607, Get(h_1609, "nextSibling"));
}
}
}
return el_1607;
return default;
}, 2, "", false));
Set(Get(Element_18, "prototype"), "append", Fn((V _self1610, int _argc1611, V _a1613, V _a1614, V _a1615, V _a1616, V[] _rest1612) => {
V i_1618 = default;
V a_1619 = default;
V _arguments1617 = Arguments(_argc1611, _a1613, _a1614, _a1615, _a1616, _rest1612);
{
i_1618 = ((V)(0D));
while (true) {
if (!(Lt(i_1618, Get(_arguments1617, "length")))) break;
a_1619 = GetK(_arguments1617, i_1618);
Invoke(_self1610, "appendChild", (string.Equals(Typeof(a_1619), "string") ? New(Text_11, a_1619) : a_1619));
PostInc(ref i_1618, 1D);
}
}
return default;
}, 0, "", false));
Set(Get(Element_18, "prototype"), "prepend", Fn((V _self1621, int _argc1622, V _a1624, V _a1625, V _a1626, V _a1627, V[] _rest1623) => {
V first_1629 = default;
V i_1630 = default;
V a_1631 = default;
V _arguments1628 = Arguments(_argc1622, _a1624, _a1625, _a1626, _a1627, _rest1623);
first_1629 = Get(_self1621, "firstChild");
{
i_1630 = ((V)(0D));
while (true) {
if (!(Lt(i_1630, Get(_arguments1628, "length")))) break;
a_1631 = GetK(_arguments1628, i_1630);
Invoke(_self1621, "insertBefore", (string.Equals(Typeof(a_1631), "string") ? New(Text_11, a_1631) : a_1631), first_1629);
PostInc(ref i_1630, 1D);
}
}
return default;
}, 0, "", false));
Object_defineProperty(Get(Element_18, "prototype"), ((V)("nextElementSibling")), NewObj(1).Put("get", Fn((V _self1633, int _argc1634, V _a1636, V _a1637, V _a1638, V _a1639, V[] _rest1635) => {
V n_1640 = default;
n_1640 = Get(_self1633, "nextSibling");
while (Truthy((n_1640 is var _t1641 && !Truthy(_t1641) ? _t1641 : (!SEqN(Get(n_1640, "nodeType"), 1D) ? V.True : V.False)))) {
n_1640 = Get(n_1640, "nextSibling");
}
return n_1640;
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("previousElementSibling")), NewObj(1).Put("get", Fn((V _self1642, int _argc1643, V _a1645, V _a1646, V _a1647, V _a1648, V[] _rest1644) => {
V n_1649 = default;
n_1649 = Get(_self1642, "previousSibling");
while (Truthy((n_1649 is var _t1650 && !Truthy(_t1650) ? _t1650 : (!SEqN(Get(n_1649, "nodeType"), 1D) ? V.True : V.False)))) {
n_1649 = Get(n_1649, "previousSibling");
}
return n_1649;
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("ownerSVGElement")), NewObj(1).Put("get", Fn((V _self1651, int _argc1652, V _a1654, V _a1655, V _a1656, V _a1657, V[] _rest1653) => {
V p_1658 = default;
p_1658 = Get(_self1651, "parentNode");
while (Truthy((p_1658 is var _t1659 && !Truthy(_t1659) ? _t1659 : (SEqN(Get(p_1658, "nodeType"), 1D) ? V.True : V.False)))) {
if (SEqS(Get(p_1658, "localName"), "svg")) {
return p_1658;
}
p_1658 = Get(p_1658, "parentNode");
}
return V.Null;
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("isConnected")), NewObj(1).Put("get", Fn((V _self1660, int _argc1661, V _a1663, V _a1664, V _a1665, V _a1666, V[] _rest1662) => {
V p_1667 = default;
p_1667 = _self1660;
while (Truthy(Get(p_1667, "parentNode"))) {
p_1667 = Get(p_1667, "parentNode");
}
return (!(!(Truthy(Get(p_1667, "__isRoot")))) ? V.True : V.False);
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("dataset")), NewObj(1).Put("get", Fn((V _self1668, int _argc1669, V _a1671, V _a1672, V _a1673, V _a1674, V[] _rest1670) => {
V el_1675 = default;
V o_1676 = default;
V a_1677 = default;
V i_1678 = default;
el_1675 = _self1668;
if (string.Equals(GTypeof("Proxy"), "undefined")) {
o_1676 = NewObj(0).V;
a_1677 = (Get(el_1675, "_attrs") is var _t1679 && Truthy(_t1679) ? _t1679 : Arr());
{
i_1678 = ((V)(0D));
while (true) {
if (!(Lt(i_1678, Get(a_1677, "length")))) break;
if (SEqN(Invoke(GetIdx(GetK(a_1677, i_1678), 0D), "indexOf", ((V)("data-"))), 0D)) {
SetK(o_1676, Invoke(Invoke(GetIdx(GetK(a_1677, i_1678), 0D), "slice", ((V)(5D))), "replace", NewRegExp(RX11, "-([a-z])", "g"), Fn((V _self1681, int _argc1682, V m_1688, V c_1689, V _a1686, V _a1687, V[] _rest1683) => {
return Invoke(c_1689, "toUpperCase");
return default;
}, 2, "", false)), GetIdx(GetK(a_1677, i_1678), 1D));
}
PostInc(ref i_1678, 1D);
}
}
return o_1676;
}
return New(G("Proxy"), NewObj(0).V, NewObj(3).Put("get", Fn((V _self1690, int _argc1691, V t_1697, V k_1698, V _a1695, V _a1696, V[] _rest1692) => {
V v_1699 = default;
v_1699 = Invoke(el_1675, "getAttribute", ((V)(JsStrBuf.Begin().S("data-").V(Call(kebab_14, V.Undef, ((V)(ToStrS(k_1698))))).End())));
return (SEq(v_1699, V.Null) ? V.Undef : v_1699);
return default;
}, 2, "get", false)).Put("set", Fn((V _self1700, int _argc1701, V t_1707, V k_1708, V v_1709, V _a1706, V[] _rest1702) => {
Invoke(el_1675, "setAttribute", ((V)(JsStrBuf.Begin().S("data-").V(Call(kebab_14, V.Undef, ((V)(ToStrS(k_1708))))).End())), v_1709);
return (true ? V.True : V.False);
return default;
}, 3, "set", false)).Put("deleteProperty", Fn((V _self1710, int _argc1711, V t_1717, V k_1718, V _a1715, V _a1716, V[] _rest1712) => {
Invoke(el_1675, "removeAttribute", ((V)(JsStrBuf.Begin().S("data-").V(Call(kebab_14, V.Undef, ((V)(ToStrS(k_1718))))).End())));
return (true ? V.True : V.False);
return default;
}, 2, "deleteProperty", false)).V);
return default;
}, 0, "get", false)).V);
Set(Get(Element_18, "prototype"), "setPointerCapture", Fn((V _self1719, int _argc1720, V _a1722, V _a1723, V _a1724, V _a1725, V[] _rest1721) => {

return default;
}, 0, "", false));
Set(Get(Element_18, "prototype"), "releasePointerCapture", Fn((V _self1726, int _argc1727, V _a1729, V _a1730, V _a1731, V _a1732, V[] _rest1728) => {

return default;
}, 0, "", false));
Set(Get(Element_18, "prototype"), "hasPointerCapture", Fn((V _self1733, int _argc1734, V _a1736, V _a1737, V _a1738, V _a1739, V[] _rest1735) => {
return (false ? V.True : V.False);
return default;
}, 0, "", false));
Set(Get(Element_18, "prototype"), "focus", Fn((V _self1740, int _argc1741, V _a1743, V _a1744, V _a1745, V _a1746, V[] _rest1742) => {

return default;
}, 0, "", false));
Set(Get(Element_18, "prototype"), "blur", Fn((V _self1747, int _argc1748, V _a1750, V _a1751, V _a1752, V _a1753, V[] _rest1749) => {

return default;
}, 0, "", false));
Set(Get(Element_18, "prototype"), "getBoundingClientRect", Fn((V _self1754, int _argc1755, V _a1757, V _a1758, V _a1759, V _a1760, V[] _rest1756) => {
V e_1761 = default;
V r_1762 = default;
e_1761 = _self1754;
while (Truthy((e_1761 is var _t1763 && !Truthy(_t1763) ? _t1763 : (!(Truthy(Get(e_1761, "__rect"))) ? V.True : V.False)))) {
e_1761 = Get(e_1761, "parentNode");
}
r_1762 = ((e_1761 is var _t1764 && !Truthy(_t1764) ? _t1764 : Get(e_1761, "__rect")) is var _t1765 && Truthy(_t1765) ? _t1765 : NewObj(4).Put("left", ((V)(0D))).Put("top", ((V)(0D))).Put("width", ((V)(100D))).Put("height", ((V)(100D))).V);
return NewObj(8).Put("left", Get(r_1762, "left")).Put("top", Get(r_1762, "top")).Put("x", Get(r_1762, "left")).Put("y", Get(r_1762, "top")).Put("width", Get(r_1762, "width")).Put("height", Get(r_1762, "height")).Put("right", Add(Get(r_1762, "left"), Get(r_1762, "width"))).Put("bottom", Add(Get(r_1762, "top"), Get(r_1762, "height"))).V;
return default;
}, 0, "", false));
Set(Get(Element_18, "prototype"), "getBBox", Fn((V _self1766, int _argc1767, V _a1769, V _a1770, V _a1771, V _a1772, V[] _rest1768) => {
return Call(bbox_36, V.Undef, _self1766);
return default;
}, 0, "", false));
Set(Get(Element_18, "prototype"), "matches", Fn((V _self1773, int _argc1774, V sel_1780, V _a1777, V _a1778, V _a1779, V[] _rest1775) => {
return Call(matchesList_26, V.Undef, _self1773, Call(parseSelectors_21, V.Undef, sel_1780));
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "closest", Fn((V _self1781, int _argc1782, V sel_1788, V _a1785, V _a1786, V _a1787, V[] _rest1783) => {
V s_1789 = default;
V e_1790 = default;
s_1789 = Call(parseSelectors_21, V.Undef, sel_1788);
e_1790 = _self1781;
while (Truthy((e_1790 is var _t1791 && !Truthy(_t1791) ? _t1791 : (SEqN(Get(e_1790, "nodeType"), 1D) ? V.True : V.False)))) {
if (Truthy(Call(matchesList_26, V.Undef, e_1790, s_1789))) {
return e_1790;
}
e_1790 = Get(e_1790, "parentNode");
}
return V.Null;
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "querySelectorAll", Fn((V _self1792, int _argc1793, V sel_1799, V _a1796, V _a1797, V _a1798, V[] _rest1794) => {
V s_1800 = default;
V @out_1801 = default;
s_1800 = Call(parseSelectors_21, V.Undef, sel_1799);
@out_1801 = Arr();
Call(walk_19, V.Undef, _self1792, Fn((V _self1802, int _argc1803, V e_1809, V _a1806, V _a1807, V _a1808, V[] _rest1804) => {
if (Truthy(Call(matchesList_26, V.Undef, e_1809, s_1800))) {
Invoke(@out_1801, "push", e_1809);
}
return default;
}, 1, "", false));
return @out_1801;
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "querySelector", Fn((V _self1810, int _argc1811, V sel_1817, V _a1814, V _a1815, V _a1816, V[] _rest1812) => {
V s_1818 = default;
V hit_1819 = default;
s_1818 = Call(parseSelectors_21, V.Undef, sel_1817);
hit_1819 = V.Null;
Call(walk_19, V.Undef, _self1810, Fn((V _self1820, int _argc1821, V e_1827, V _a1824, V _a1825, V _a1826, V[] _rest1822) => {
if (Truthy(((!(Truthy(hit_1819)) ? V.True : V.False) is var _t1828 && !Truthy(_t1828) ? _t1828 : Call(matchesList_26, V.Undef, e_1827, s_1818)))) {
hit_1819 = e_1827;
}
return default;
}, 1, "", false));
return hit_1819;
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "getElementsByTagName", Fn((V _self1829, int _argc1830, V t_1836, V _a1833, V _a1834, V _a1835, V[] _rest1831) => {
return Invoke(_self1829, "querySelectorAll", t_1836);
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "getElementById", Fn((V _self1837, int _argc1838, V id_1844, V _a1841, V _a1842, V _a1843, V[] _rest1839) => {
V hit_1845 = default;
hit_1845 = V.Null;
Call(walk_19, V.Undef, _self1837, Fn((V _self1846, int _argc1847, V e_1853, V _a1850, V _a1851, V _a1852, V[] _rest1848) => {
if ((!(Truthy(hit_1845)) && SEq(Invoke(e_1853, "getAttribute", ((V)("id"))), id_1844))) {
hit_1845 = e_1853;
}
return default;
}, 1, "", false));
return hit_1845;
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "getContext", Fn((V _self1854, int _argc1855, V kind_1861, V _a1858, V _a1859, V _a1860, V[] _rest1856) => {
return ((SEqS(kind_1861, "2d") && SEqS(Get(_self1854, "localName"), "canvas")) ? Set(_self1854, "_ctx", (Get(_self1854, "_ctx") is var _t1862 && Truthy(_t1862) ? _t1862 : New(Ctx2D_61, _self1854))) : V.Null);
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "toDataURL", Fn((V _self1863, int _argc1864, V _a1866, V _a1867, V _a1868, V _a1869, V[] _rest1865) => {
V id_1870 = default;
id_1870 = ((V)(JsStrBuf.Begin().S("shim-canvas:").V(Get(_self1863, "__id")).End()));
SetK(CANVASES_60, id_1870, _self1863);
return id_1870;
return default;
}, 0, "", false));
Object_defineProperty(Get(Element_18, "prototype"), ((V)("width")), NewObj(2).Put("get", Fn((V _self1871, int _argc1872, V _a1874, V _a1875, V _a1876, V _a1877, V[] _rest1873) => {
return ((V)(ToNum((Invoke(_self1871, "getAttribute", ((V)("width"))) is var _t1878 && Truthy(_t1878) ? _t1878 : ((V)((SEqS(Get(_self1871, "localName"), "canvas") ? 300D : 0D)))))));
return default;
}, 0, "get", false)).Put("set", Fn((V _self1879, int _argc1880, V v_1886, V _a1883, V _a1884, V _a1885, V[] _rest1881) => {
Invoke(_self1879, "setAttribute", ((V)("width")), v_1886);
return default;
}, 1, "set", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("height")), NewObj(2).Put("get", Fn((V _self1887, int _argc1888, V _a1890, V _a1891, V _a1892, V _a1893, V[] _rest1889) => {
return ((V)(ToNum((Invoke(_self1887, "getAttribute", ((V)("height"))) is var _t1894 && Truthy(_t1894) ? _t1894 : ((V)((SEqS(Get(_self1887, "localName"), "canvas") ? 150D : 0D)))))));
return default;
}, 0, "get", false)).Put("set", Fn((V _self1895, int _argc1896, V v_1902, V _a1899, V _a1900, V _a1901, V[] _rest1897) => {
Invoke(_self1895, "setAttribute", ((V)("height")), v_1902);
return default;
}, 1, "set", false)).V);
SEL_CACHE_20 = NewObj(0).V;
VOID_HTML_27 = NewObj(6).Put("br", ((V)(1D))).Put("img", ((V)(1D))).Put("input", ((V)(1D))).Put("hr", ((V)(1D))).Put("meta", ((V)(1D))).Put("link", ((V)(1D))).V;
ENT_28 = NewObj(6).Put("amp", ((V)("&"))).Put("lt", ((V)("<"))).Put("gt", ((V)(">"))).Put("quot", ((V)("\""))).Put("apos", ((V)("'"))).Put("nbsp", ((V)("\u00a0"))).V;
unescape_29 = Fn((V _self1903, int _argc1904, V s_1910, V _a1907, V _a1908, V _a1909, V[] _rest1905) => {
return Invoke(s_1910, "replace", NewRegExp(RX15, "&(#x[0-9a-f]+|#\\d+|[a-z]+);", "gi"), Fn((V _self1911, int _argc1912, V m_1918, V e_1919, V _a1916, V _a1917, V[] _rest1913) => {
if (SEqS(GetIdx(e_1919, 0D), "#")) {
return ((V)(String_fromCharCode(((V)(((SEqS(GetIdx(e_1919, 1D), "x") || SEqS(GetIdx(e_1919, 1D), "X")) ? ParseInt(Invoke(e_1919, "slice", ((V)(2D))), ((V)(16D))) : ToNum(Invoke(e_1919, "slice", ((V)(1D))))))))));
}
return (!GetK(ENT_28, e_1919).IsNullish ? GetK(ENT_28, e_1919) : m_1918);
return default;
}, 2, "", false));
return default;
}, 1, "", false);
escAttr_31 = Fn((V _self1920, int _argc1921, V s_1927, V _a1924, V _a1925, V _a1926, V[] _rest1922) => {
return Invoke(Invoke(Invoke(Invoke(Invoke(s_1927, "replace", NewRegExp(RX20, "&", "g"), ((V)("&amp;"))), "replace", NewRegExp(RX19, "\"", "g"), ((V)("&quot;"))), "replace", NewRegExp(RX18, "\u00a0", "g"), ((V)("&nbsp;"))), "replace", NewRegExp(RX17, "<", "g"), ((V)("&lt;"))), "replace", NewRegExp(RX16, ">", "g"), ((V)("&gt;")));
return default;
}, 1, "", false);
escText_32 = Fn((V _self1928, int _argc1929, V s_1935, V _a1932, V _a1933, V _a1934, V[] _rest1930) => {
return Invoke(Invoke(Invoke(Invoke(s_1935, "replace", NewRegExp(RX20, "&", "g"), ((V)("&amp;"))), "replace", NewRegExp(RX17, "<", "g"), ((V)("&lt;"))), "replace", NewRegExp(RX16, ">", "g"), ((V)("&gt;"))), "replace", NewRegExp(RX18, "\u00a0", "g"), ((V)("&nbsp;")));
return default;
}, 1, "", false);
F_34 = Get(G("Math"), "fround");
Invoke(Arr(((V)("x")), ((V)("y")), ((V)("width")), ((V)("height"))), "forEach", Fn((V _self1936, int _argc1937, V k_1943, V i_1944, V _a1941, V _a1942, V[] _rest1938) => {
Object_defineProperty(Get(SVGRect_35, "prototype"), k_1943, NewObj(3).Put("get", Fn((V _self1945, int _argc1946, V _a1948, V _a1949, V _a1950, V _a1951, V[] _rest1947) => {
return GetK(Get(_self1945, "_r"), i_1944);
return default;
}, 0, "get", false)).Put("set", Fn((V _self1952, int _argc1953, V v_1959, V _a1956, V _a1957, V _a1958, V[] _rest1954) => {
SetK(Get(_self1952, "_r"), i_1944, ((V)(ToNum(v_1959))));
return default;
}, 1, "set", false)).Put("enumerable", (true ? V.True : V.False)).V);
return default;
}, 2, "", false));
Object_defineProperty(Get(SVGRect_35, "prototype"), ((V)("_r")), NewObj(3).Put("writable", (true ? V.True : V.False)).Put("enumerable", (false ? V.True : V.False)).Put("value", V.Null).V);
F32_38 = New(G("Float32Array"), ((V)(1D)));
U32_39 = New(G("Uint32Array"), Get(F32_38, "buffer"));
SINZ_48 = Fn((V _self1960, int _argc1961, V r_1967, V _a1964, V _a1965, V _a1966, V[] _rest1962) => {
V v_1968 = default;
v_1968 = Call(F_34, V.Undef, ((V)(FdLibm.Sin(ToNum(r_1967)))));
return (Le(((V)(System.Math.Abs(ToNum(v_1968)))), Call(F_34, V.Undef, ((V)((1D / 4096D))))) ? ((V)(0D)) : v_1968);
return default;
}, 1, "", false);
COSZ_49 = Fn((V _self1969, int _argc1970, V r_1976, V _a1973, V _a1974, V _a1975, V[] _rest1971) => {
V v_1977 = default;
v_1977 = Call(F_34, V.Undef, ((V)(FdLibm.Cos(ToNum(r_1976)))));
return (Le(((V)(System.Math.Abs(ToNum(v_1977)))), Call(F_34, V.Undef, ((V)((1D / 4096D))))) ? ((V)(0D)) : v_1977);
return default;
}, 1, "", false);
PIF_50 = Call(F_34, V.Undef, ((V)(System.Math.PI)));
DEG_51 = Call(F_34, V.Undef, ((V)((ToNum(PIF_50) / 180D))));
CANVASES_60 = NewObj(0).V;
Set(Get(Ctx2D_61, "prototype"), "createImageData", Fn((V _self1978, int _argc1979, V w_1985, V h_1986, V _a1983, V _a1984, V[] _rest1980) => {
return NewObj(3).Put("width", w_1985).Put("height", h_1986).Put("data", New(G("Uint8ClampedArray"), ((V)(((ToNum(w_1985) * ToNum(h_1986)) * 4D))))).V;
return default;
}, 2, "", false));
Set(Get(Ctx2D_61, "prototype"), "putImageData", Fn((V _self1987, int _argc1988, V im_1994, V _a1991, V _a1992, V _a1993, V[] _rest1989) => {
Set(Get(_self1987, "canvas"), "_pixels", NewObj(3).Put("width", Get(im_1994, "width")).Put("height", Get(im_1994, "height")).Put("data", Get(im_1994, "data")).V);
return default;
}, 1, "", false));
Set(Get(Ctx2D_61, "prototype"), "getImageData", Fn((V _self1995, int _argc1996, V x_2002, V y_2003, V w_2004, V h_2005, V[] _rest1997) => {
V p_2006 = default;
p_2006 = Get(Get(_self1995, "canvas"), "_pixels");
return (Truthy(p_2006) ? NewObj(3).Put("width", Get(p_2006, "width")).Put("height", Get(p_2006, "height")).Put("data", Get(p_2006, "data")).V : Invoke(_self1995, "createImageData", w_2004, h_2005));
return default;
}, 4, "", false));
Set(Get(Ctx2D_61, "prototype"), "createPattern", Fn((V _self2007, int _argc2008, V src_2014, V rep_2015, V _a2012, V _a2013, V[] _rest2009) => {
return NewObj(2).Put("pattern", src_2014).Put("repeat", rep_2015).V;
return default;
}, 2, "", false));
Set(Get(Ctx2D_61, "prototype"), "fillRect", Fn((V _self2016, int _argc2017, V x_2023, V y_2024, V w_2025, V h_2026, V[] _rest2018) => {
if (Truthy((Get(_self2016, "fillStyle") is var _t2027 && !Truthy(_t2027) ? _t2027 : Get(Get(_self2016, "fillStyle"), "pattern")))) {
Set(Get(_self2016, "canvas"), "_tiled", NewObj(3).Put("src", Get(Get(_self2016, "fillStyle"), "pattern")).Put("w", w_2025).Put("h", h_2026).V);
}
return default;
}, 4, "", false));
Invoke(Arr(((V)("clearRect")), ((V)("save")), ((V)("restore")), ((V)("translate")), ((V)("scale")), ((V)("rotate")), ((V)("beginPath")), ((V)("closePath")), ((V)("moveTo")), ((V)("lineTo")), ((V)("arc")), ((V)("fill")), ((V)("stroke")), ((V)("drawImage")), ((V)("setTransform"))), "forEach", Fn((V _self2028, int _argc2029, V k_2035, V _a2032, V _a2033, V _a2034, V[] _rest2030) => {
SetK(Get(Ctx2D_61, "prototype"), k_2035, Fn((V _self2036, int _argc2037, V _a2039, V _a2040, V _a2041, V _a2042, V[] _rest2038) => {

return default;
}, 0, "", false));
return default;
}, 1, "", false));
Set(root_8, "RigDomShim", NewObj(1).Put("install", install_62).V);
return default;
}, 1, "", false), V.Undef, (!string.Equals(GTypeof("globalThis"), "undefined") ? G("globalThis") : GlobalV));
        }
    }
}
