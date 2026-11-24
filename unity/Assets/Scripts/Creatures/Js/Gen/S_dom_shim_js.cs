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
mul_58 = Fn((V _self669, int _argc670, V a_676, V c_677, V _a674, V _a675, V[] _rest671) => {
if (!(Truthy(a_676))) {
return c_677;
}
if (!(Truthy(c_677))) {
return a_676;
}
return Arr(((V)(((ToNum(GetIdx(a_676, 0D)) * ToNum(GetIdx(c_677, 0D))) + (ToNum(GetIdx(a_676, 2D)) * ToNum(GetIdx(c_677, 1D)))))), ((V)(((ToNum(GetIdx(a_676, 1D)) * ToNum(GetIdx(c_677, 0D))) + (ToNum(GetIdx(a_676, 3D)) * ToNum(GetIdx(c_677, 1D)))))), ((V)(((ToNum(GetIdx(a_676, 0D)) * ToNum(GetIdx(c_677, 2D))) + (ToNum(GetIdx(a_676, 2D)) * ToNum(GetIdx(c_677, 3D)))))), ((V)(((ToNum(GetIdx(a_676, 1D)) * ToNum(GetIdx(c_677, 2D))) + (ToNum(GetIdx(a_676, 3D)) * ToNum(GetIdx(c_677, 3D)))))), Add(((V)(((ToNum(GetIdx(a_676, 0D)) * ToNum(GetIdx(c_677, 4D))) + (ToNum(GetIdx(a_676, 2D)) * ToNum(GetIdx(c_677, 5D)))))), GetIdx(a_676, 4D)), Add(((V)(((ToNum(GetIdx(a_676, 1D)) * ToNum(GetIdx(c_677, 4D))) + (ToNum(GetIdx(a_676, 3D)) * ToNum(GetIdx(c_677, 5D)))))), GetIdx(a_676, 5D)));
return default;
}, 2, "mul", false);
parseTransform_59 = Fn((V _self678, int _argc679, V s_685, V _a682, V _a683, V _a684, V[] _rest680) => {
V m_686 = default;
V re_687 = default;
V t_688 = default;
V v_689 = default;
V k_690 = default;
V rr_691 = default;
V cs_692 = default;
V sn_693 = default;
if (!(Truthy(s_685))) {
return V.Null;
}
m_686 = V.Null;
re_687 = NewRegExp(RX9, "(matrix|translate|scale|rotate|skewX|skewY)\\s*\\(([^)]*)\\)", "g");
while (Truthy((t_688 = Invoke(re_687, "exec", s_685)))) {
v_689 = Invoke(Invoke(Invoke(GetIdx(t_688, 2D), "split", NewRegExp(RX7, "[\\s,]+", "")), "filter", G("Boolean")), "map", Fn((V _self694, int _argc695, V x_701, V _a698, V _a699, V _a700, V[] _rest696) => {
return Call(F_34, V.Undef, ((V)(ToNum(x_701))));
return default;
}, 1, "", false));
if (SEqS(GetIdx(t_688, 1D), "matrix")) {
k_690 = v_689;
} else {
if (SEqS(GetIdx(t_688, 1D), "translate")) {
k_690 = Arr(((V)(1D)), ((V)(0D)), ((V)(0D)), ((V)(1D)), (GetIdx(v_689, 0D) is var _t702 && Truthy(_t702) ? _t702 : ((V)(0D))), (GetIdx(v_689, 1D) is var _t703 && Truthy(_t703) ? _t703 : ((V)(0D))));
} else {
if (SEqS(GetIdx(t_688, 1D), "scale")) {
k_690 = Arr(GetIdx(v_689, 0D), ((V)(0D)), ((V)(0D)), (GtN(Get(v_689, "length"), 1D) ? GetIdx(v_689, 1D) : GetIdx(v_689, 0D)), ((V)(0D)), ((V)(0D)));
} else {
if (SEqS(GetIdx(t_688, 1D), "rotate")) {
rr_691 = ((V)(((ToNum(GetIdx(v_689, 0D)) * System.Math.PI) / 180D)));
cs_692 = ((V)(FdLibm.Cos(ToNum(rr_691))));
sn_693 = ((V)(FdLibm.Sin(ToNum(rr_691))));
k_690 = Arr(cs_692, sn_693, ((V)((-ToNum(sn_693)))), cs_692, ((V)(0D)), ((V)(0D)));
if (GtN(Get(v_689, "length"), 2D)) {
k_690 = Call(mul_58, V.Undef, Call(mul_58, V.Undef, Arr(((V)(1D)), ((V)(0D)), ((V)(0D)), ((V)(1D)), GetIdx(v_689, 1D), GetIdx(v_689, 2D)), k_690), Arr(((V)(1D)), ((V)(0D)), ((V)(0D)), ((V)(1D)), ((V)((-ToNum(GetIdx(v_689, 1D))))), ((V)((-ToNum(GetIdx(v_689, 2D)))))));
}
} else {
if (SEqS(GetIdx(t_688, 1D), "skewX")) {
k_690 = Arr(((V)(1D)), ((V)(0D)), ((V)(FdLibm.Tan(((ToNum(GetIdx(v_689, 0D)) * System.Math.PI) / 180D)))), ((V)(1D)), ((V)(0D)), ((V)(0D)));
} else {
k_690 = Arr(((V)(1D)), ((V)(FdLibm.Tan(((ToNum(GetIdx(v_689, 0D)) * System.Math.PI) / 180D)))), ((V)(0D)), ((V)(1D)), ((V)(0D)), ((V)(0D)));
}
}
}
}
}
m_686 = Call(mul_58, V.Undef, m_686, k_690);
}
return m_686;
return default;
}, 1, "parseTransform", false);
Ctx2D_61 = Fn((V _self704, int _argc705, V cv_711, V _a708, V _a709, V _a710, V[] _rest706) => {
Set(_self704, "canvas", cv_711);
Set(_self704, "fillStyle", ((V)("#000")));
Set(_self704, "globalAlpha", ((V)(1D)));
return default;
}, 1, "Ctx2D", false);
install_62 = Fn((V _self712, int _argc713, V G_719, V opts_720, V _a717, V _a718, V[] _rest714) => {
V html_721 = default;
V head_722 = default;
V body_723 = default;
V docListeners_724 = default;
V document_725 = default;
V store_726 = default;
V winListeners_727 = default;
opts_720 = (opts_720 is var _t728 && Truthy(_t728) ? _t728 : NewObj(0).V);
html_721 = New(Element_18, ((V)("html")), ((V)("http://www.w3.org/1999/xhtml")));
head_722 = New(Element_18, ((V)("head")), Get(html_721, "namespaceURI"));
body_723 = New(Element_18, ((V)("body")), Get(html_721, "namespaceURI"));
Set(html_721, "__isRoot", (true ? V.True : V.False));
Invoke(html_721, "appendChild", head_722);
Invoke(html_721, "appendChild", body_723);
docListeners_724 = NewObj(0).V;
document_725 = NewObj(17).Put("nodeType", ((V)(9D))).Put("readyState", ((V)("complete"))).Put("documentElement", html_721).Put("head", head_722).Put("body", body_723).Put("hidden", (false ? V.True : V.False)).Put("visibilityState", ((V)("visible"))).Put("fonts", NewObj(1).Put("ready", Invoke(G("Promise"), "resolve")).V).Put("createElementNS", Fn((V _self729, int _argc730, V ns_736, V tag_737, V _a734, V _a735, V[] _rest731) => {
return New(Element_18, tag_737, ns_736);
return default;
}, 2, "createElementNS", false)).Put("createElement", Fn((V _self738, int _argc739, V tag_745, V _a742, V _a743, V _a744, V[] _rest740) => {
return New(Element_18, Invoke(((V)(ToStrS(tag_745))), "toLowerCase"), ((V)("http://www.w3.org/1999/xhtml")));
return default;
}, 1, "createElement", false)).Put("createTextNode", Fn((V _self746, int _argc747, V t_753, V _a750, V _a751, V _a752, V[] _rest748) => {
return New(Text_11, t_753);
return default;
}, 1, "createTextNode", false)).Put("createDocumentFragment", Fn((V _self754, int _argc755, V _a757, V _a758, V _a759, V _a760, V[] _rest756) => {
return New(Fragment_12);
return default;
}, 0, "createDocumentFragment", false)).Put("getElementById", Fn((V _self761, int _argc762, V id_768, V _a765, V _a766, V _a767, V[] _rest763) => {
return Invoke(html_721, "querySelector", ((V)(JsStrBuf.Begin().S("#").V(id_768).End())));
return default;
}, 1, "getElementById", false)).Put("querySelector", Fn((V _self769, int _argc770, V s_776, V _a773, V _a774, V _a775, V[] _rest771) => {
return Invoke(html_721, "querySelector", s_776);
return default;
}, 1, "querySelector", false)).Put("querySelectorAll", Fn((V _self777, int _argc778, V s_784, V _a781, V _a782, V _a783, V[] _rest779) => {
return Invoke(html_721, "querySelectorAll", s_784);
return default;
}, 1, "querySelectorAll", false)).Put("addEventListener", Fn((V _self785, int _argc786, V t_792, V fn_793, V _a790, V _a791, V[] _rest787) => {
Invoke(SetK(docListeners_724, t_792, (GetK(docListeners_724, t_792) is var _t794 && Truthy(_t794) ? _t794 : Arr())), "push", fn_793);
return default;
}, 2, "addEventListener", false)).Put("removeEventListener", Fn((V _self795, int _argc796, V _a798, V _a799, V _a800, V _a801, V[] _rest797) => {

return default;
}, 0, "removeEventListener", false)).V;
Set(G_719, "window", G_719);
Set(G_719, "self", G_719);
Set(G_719, "globalThis", G_719);
Set(G_719, "Node", Node_10);
Set(G_719, "Element", Set(G_719, "SVGElement", Set(G_719, "HTMLElement", Element_18)));
Set(G_719, "Text", Text_11);
Set(G_719, "DocumentFragment", Fragment_12);
Set(G_719, "document", document_725);
Set(G_719, "navigator", (Get(G_719, "navigator") is var _t809 && Truthy(_t809) ? _t809 : NewObj(5).Put("userAgent", ((V)("SquishRigHost"))).Put("hardwareConcurrency", ((V)(8D))).Put("deviceMemory", ((V)(4D))).Put("maxTouchPoints", ((V)(5D))).Put("vibrate", Fn((V _self802, int _argc803, V _a805, V _a806, V _a807, V _a808, V[] _rest804) => {
return (false ? V.True : V.False);
return default;
}, 0, "vibrate", false)).V));
Set(G_719, "location", (Get(G_719, "location") is var _t810 && Truthy(_t810) ? _t810 : NewObj(5).Put("protocol", ((V)("app:"))).Put("href", ((V)("app://rig/"))).Put("search", ((V)(""))).Put("hash", ((V)(""))).Put("pathname", ((V)("/"))).V));
store_726 = NewObj(0).V;
Set(G_719, "localStorage", (Get(G_719, "localStorage") is var _t843 && Truthy(_t843) ? _t843 : NewObj(4).Put("getItem", Fn((V _self811, int _argc812, V k_818, V _a815, V _a816, V _a817, V[] _rest813) => {
return (Truthy(Invoke(Get(Get(G("Object"), "prototype"), "hasOwnProperty"), "call", store_726, k_818)) ? GetK(store_726, k_818) : V.Null);
return default;
}, 1, "getItem", false)).Put("setItem", Fn((V _self819, int _argc820, V k_826, V v_827, V _a824, V _a825, V[] _rest821) => {
SetK(store_726, k_826, ((V)(ToStrS(v_827))));
return default;
}, 2, "setItem", false)).Put("removeItem", Fn((V _self828, int _argc829, V k_835, V _a832, V _a833, V _a834, V[] _rest830) => {
DeleteK(store_726, k_835);
return default;
}, 1, "removeItem", false)).Put("clear", Fn((V _self836, int _argc837, V _a839, V _a840, V _a841, V _a842, V[] _rest838) => {
store_726 = NewObj(0).V;
return default;
}, 0, "clear", false)).V));
Set(G_719, "sessionStorage", (Get(G_719, "sessionStorage") is var _t844 && Truthy(_t844) ? _t844 : Get(G_719, "localStorage")));
winListeners_727 = NewObj(0).V;
Set(G_719, "addEventListener", Fn((V _self845, int _argc846, V t_852, V fn_853, V _a850, V _a851, V[] _rest847) => {
Invoke(SetK(winListeners_727, t_852, (GetK(winListeners_727, t_852) is var _t854 && Truthy(_t854) ? _t854 : Arr())), "push", fn_853);
return default;
}, 2, "", false));
Set(G_719, "removeEventListener", Fn((V _self855, int _argc856, V _a858, V _a859, V _a860, V _a861, V[] _rest857) => {

return default;
}, 0, "", false));
Set(G_719, "dispatchEvent", Fn((V _self862, int _argc863, V ev_869, V _a866, V _a867, V _a868, V[] _rest864) => {
Invoke(Invoke((GetK(winListeners_727, Get(ev_869, "type")) is var _t878 && Truthy(_t878) ? _t878 : Arr()), "slice"), "forEach", Fn((V _self870, int _argc871, V f_877, V _a874, V _a875, V _a876, V[] _rest872) => {
Call(f_877, V.Undef, ev_869);
return default;
}, 1, "", false));
return (true ? V.True : V.False);
return default;
}, 1, "", false));
Set(G_719, "getComputedStyle", Fn((V _self879, int _argc880, V el_886, V _a883, V _a884, V _a885, V[] _rest881) => {
return Get(el_886, "style");
return default;
}, 1, "", false));
Set(G_719, "matchMedia", Fn((V _self887, int _argc888, V _a890, V _a891, V _a892, V _a893, V[] _rest889) => {
return NewObj(4).Put("matches", (false ? V.True : V.False)).Put("addListener", Fn((V _self894, int _argc895, V _a897, V _a898, V _a899, V _a900, V[] _rest896) => {

return default;
}, 0, "addListener", false)).Put("removeListener", Fn((V _self901, int _argc902, V _a904, V _a905, V _a906, V _a907, V[] _rest903) => {

return default;
}, 0, "removeListener", false)).Put("addEventListener", Fn((V _self908, int _argc909, V _a911, V _a912, V _a913, V _a914, V[] _rest910) => {

return default;
}, 0, "addEventListener", false)).V;
return default;
}, 0, "", false));
Set(G_719, "innerWidth", ((V)(832D)));
Set(G_719, "innerHeight", ((V)(384D)));
Set(G_719, "devicePixelRatio", ((V)(2.8125)));
Set(G_719, "Image", Fn((V _self915, int _argc916, V _a918, V _a919, V _a920, V _a921, V[] _rest917) => {
V e_922 = default;
e_922 = New(Element_18, ((V)("img")), ((V)("http://www.w3.org/1999/xhtml")));
return e_922;
return default;
}, 0, "", false));
Set(G_719, "console", (Get(G_719, "console") is var _t944 && Truthy(_t944) ? _t944 : NewObj(3).Put("log", Fn((V _self923, int _argc924, V _a926, V _a927, V _a928, V _a929, V[] _rest925) => {

return default;
}, 0, "log", false)).Put("warn", Fn((V _self930, int _argc931, V _a933, V _a934, V _a935, V _a936, V[] _rest932) => {

return default;
}, 0, "warn", false)).Put("error", Fn((V _self937, int _argc938, V _a940, V _a941, V _a942, V _a943, V[] _rest939) => {

return default;
}, 0, "error", false)).V));
if (Truthy(Get(opts_720, "readFile"))) {
Set(G_719, "fetch", Fn((V _self945, int _argc946, V url_952, V _a949, V _a950, V _a951, V[] _rest947) => {
V path_953 = default;
path_953 = Invoke(GetIdx(Invoke(GetIdx(Invoke(((V)(ToStrS(url_952))), "split", ((V)("?"))), 0D), "split", ((V)("#"))), 0D), "replace", NewRegExp(RX10, "^\\.\\/", ""), ((V)("")));
return New(G("Promise"), Fn((V _self954, int _argc955, V res_961, V _a958, V _a959, V _a960, V[] _rest956) => {
V text_962 = default;
text_962 = V.Null;
try {
text_962 = Invoke(opts_720, "readFile", path_953);
} catch (System.Exception _ex963) {
V e_964 = default;
e_964 = Caught(_ex963);
text_962 = V.Null;
}
Call(res_961, V.Undef, NewObj(4).Put("ok", (!text_962.IsNullish ? V.True : V.False)).Put("status", ((V)((!text_962.IsNullish ? 200D : 404D)))).Put("text", Fn((V _self965, int _argc966, V _a968, V _a969, V _a970, V _a971, V[] _rest967) => {
return Invoke(G("Promise"), "resolve", (text_962 is var _t972 && Truthy(_t972) ? _t972 : ((V)(""))));
return default;
}, 0, "text", false)).Put("json", Fn((V _self973, int _argc974, V _a976, V _a977, V _a978, V _a979, V[] _rest975) => {
return Invoke(G("Promise"), "resolve", Invoke(G("JSON"), "parse", (text_962 is var _t980 && Truthy(_t980) ? _t980 : ((V)("null")))));
return default;
}, 0, "json", false)).V);
return default;
}, 1, "", false));
return default;
}, 1, "", false));
}
Set(G_719, "__rigShim", NewObj(4).Put("Element", Element_18).Put("serialize", serialize_33).Put("canvases", CANVASES_60).Put("parseTransform", parseTransform_59).V);
return G_719;
return default;
}, 2, "install", false);
SVG_NS_9 = ((V)("http://www.w3.org/2000/svg"));
Object_defineProperty(Get(Node_10, "prototype"), ((V)("firstChild")), NewObj(1).Put("get", Fn((V _self981, int _argc982, V _a984, V _a985, V _a986, V _a987, V[] _rest983) => {
return (GetIdx(Get(_self981, "childNodes"), 0D) is var _t988 && Truthy(_t988) ? _t988 : V.Null);
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Node_10, "prototype"), ((V)("lastChild")), NewObj(1).Put("get", Fn((V _self989, int _argc990, V _a992, V _a993, V _a994, V _a995, V[] _rest991) => {
return (GetIdx(Get(_self989, "childNodes"), (ToNum(Get(Get(_self989, "childNodes"), "length")) - 1D)) is var _t996 && Truthy(_t996) ? _t996 : V.Null);
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Node_10, "prototype"), ((V)("nextSibling")), NewObj(1).Put("get", Fn((V _self997, int _argc998, V _a1000, V _a1001, V _a1002, V _a1003, V[] _rest999) => {
V p_1004 = default;
V i_1005 = default;
p_1004 = Get(_self997, "parentNode");
if (!(Truthy(p_1004))) {
return V.Null;
}
i_1005 = Invoke(Get(p_1004, "childNodes"), "indexOf", _self997);
return (GetK(Get(p_1004, "childNodes"), Add(i_1005, ((V)(1D)))) is var _t1006 && Truthy(_t1006) ? _t1006 : V.Null);
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Node_10, "prototype"), ((V)("previousSibling")), NewObj(1).Put("get", Fn((V _self1007, int _argc1008, V _a1010, V _a1011, V _a1012, V _a1013, V[] _rest1009) => {
V p_1014 = default;
V i_1015 = default;
p_1014 = Get(_self1007, "parentNode");
if (!(Truthy(p_1014))) {
return V.Null;
}
i_1015 = Invoke(Get(p_1014, "childNodes"), "indexOf", _self1007);
return (GtN(i_1015, 0D) ? GetIdx(Get(p_1014, "childNodes"), (ToNum(i_1015) - 1D)) : V.Null);
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Node_10, "prototype"), ((V)("parentElement")), NewObj(1).Put("get", Fn((V _self1016, int _argc1017, V _a1019, V _a1020, V _a1021, V _a1022, V[] _rest1018) => {
return (Truthy((Get(_self1016, "parentNode") is var _t1023 && !Truthy(_t1023) ? _t1023 : (SEqN(Get(Get(_self1016, "parentNode"), "nodeType"), 1D) ? V.True : V.False))) ? Get(_self1016, "parentNode") : V.Null);
return default;
}, 0, "get", false)).V);
Set(Get(Node_10, "prototype"), "appendChild", Fn((V _self1024, int _argc1025, V n_1031, V _a1028, V _a1029, V _a1030, V[] _rest1026) => {
return Invoke(_self1024, "insertBefore", n_1031, V.Null);
return default;
}, 1, "", false));
Set(Get(Node_10, "prototype"), "insertBefore", Fn((V _self1032, int _argc1033, V n_1039, V @ref_1040, V _a1037, V _a1038, V[] _rest1034) => {
V kids_1041 = default;
V k_1042 = default;
V i_1043 = default;
if (SEqN(Get(n_1039, "nodeType"), 11D)) {
kids_1041 = Invoke(Get(n_1039, "childNodes"), "slice");
{
k_1042 = ((V)(0D));
while (true) {
if (!(Lt(k_1042, Get(kids_1041, "length")))) break;
Invoke(_self1032, "insertBefore", GetK(kids_1041, k_1042), @ref_1040);
PostInc(ref k_1042, 1D);
}
}
return n_1039;
}
if (Truthy(Get(n_1039, "parentNode"))) {
Invoke(Get(n_1039, "parentNode"), "removeChild", n_1039);
}
i_1043 = (Truthy(@ref_1040) ? Invoke(Get(_self1032, "childNodes"), "indexOf", @ref_1040) : ((V)((-1D))));
if (LtN(i_1043, 0D)) {
Invoke(Get(_self1032, "childNodes"), "push", n_1039);
} else {
Invoke(Get(_self1032, "childNodes"), "splice", i_1043, ((V)(0D)), n_1039);
}
Set(n_1039, "parentNode", _self1032);
return n_1039;
return default;
}, 2, "", false));
Set(Get(Node_10, "prototype"), "removeChild", Fn((V _self1045, int _argc1046, V n_1052, V _a1049, V _a1050, V _a1051, V[] _rest1047) => {
V i_1053 = default;
i_1053 = Invoke(Get(_self1045, "childNodes"), "indexOf", n_1052);
if (GeN(i_1053, 0D)) {
Invoke(Get(_self1045, "childNodes"), "splice", i_1053, ((V)(1D)));
Set(n_1052, "parentNode", V.Null);
}
return n_1052;
return default;
}, 1, "", false));
Set(Get(Node_10, "prototype"), "replaceChild", Fn((V _self1054, int _argc1055, V n_1061, V old_1062, V _a1059, V _a1060, V[] _rest1056) => {
Invoke(_self1054, "insertBefore", n_1061, old_1062);
return Invoke(_self1054, "removeChild", old_1062);
return default;
}, 2, "", false));
Set(Get(Node_10, "prototype"), "after", Fn((V _self1063, int _argc1064, V _a1066, V _a1067, V _a1068, V _a1069, V[] _rest1065) => {
V p_1071 = default;
V @ref_1072 = default;
V i_1073 = default;
V n_1074 = default;
V _arguments1070 = Arguments(_argc1064, _a1066, _a1067, _a1068, _a1069, _rest1065);
p_1071 = Get(_self1063, "parentNode");
if (!(Truthy(p_1071))) {
return default;
}
@ref_1072 = Get(_self1063, "nextSibling");
{
i_1073 = ((V)(0D));
while (true) {
if (!(Lt(i_1073, Get(_arguments1070, "length")))) break;
n_1074 = GetK(_arguments1070, i_1073);
if (string.Equals(Typeof(n_1074), "string")) {
n_1074 = New(Text_11, n_1074);
}
Invoke(p_1071, "insertBefore", n_1074, @ref_1072);
PostInc(ref i_1073, 1D);
}
}
return default;
}, 0, "", false));
Set(Get(Node_10, "prototype"), "before", Fn((V _self1076, int _argc1077, V _a1079, V _a1080, V _a1081, V _a1082, V[] _rest1078) => {
V p_1084 = default;
V i_1085 = default;
V n_1086 = default;
V _arguments1083 = Arguments(_argc1077, _a1079, _a1080, _a1081, _a1082, _rest1078);
p_1084 = Get(_self1076, "parentNode");
if (!(Truthy(p_1084))) {
return default;
}
{
i_1085 = ((V)(0D));
while (true) {
if (!(Lt(i_1085, Get(_arguments1083, "length")))) break;
n_1086 = GetK(_arguments1083, i_1085);
if (string.Equals(Typeof(n_1086), "string")) {
n_1086 = New(Text_11, n_1086);
}
Invoke(p_1084, "insertBefore", n_1086, _self1076);
PostInc(ref i_1085, 1D);
}
}
return default;
}, 0, "", false));
Set(Get(Node_10, "prototype"), "remove", Fn((V _self1088, int _argc1089, V _a1091, V _a1092, V _a1093, V _a1094, V[] _rest1090) => {
if (Truthy(Get(_self1088, "parentNode"))) {
Invoke(Get(_self1088, "parentNode"), "removeChild", _self1088);
}
return default;
}, 0, "", false));
Set(Get(Node_10, "prototype"), "compareDocumentPosition", Fn((V _self1095, int _argc1096, V other_1102, V _a1099, V _a1100, V _a1101, V[] _rest1097) => {
V a_1103 = default;
V b_1104 = default;
V n_1105 = default;
V i_1106 = default;
V p_1107 = default;
if (SEq(other_1102, _self1095)) {
return ((V)(0D));
}
a_1103 = Arr();
b_1104 = Arr();
n_1105 = _self1095;
while (Truthy(n_1105)) {
Invoke(a_1103, "unshift", n_1105);
n_1105 = Get(n_1105, "parentNode");
}
n_1105 = other_1102;
while (Truthy(n_1105)) {
Invoke(b_1104, "unshift", n_1105);
n_1105 = Get(n_1105, "parentNode");
}
if (!SEq(GetIdx(a_1103, 0D), GetIdx(b_1104, 0D))) {
return ((V)(((double)(ToInt32(1D) | ToInt32(32D)))));
}
i_1106 = ((V)(0D));
while (((Lt(i_1106, Get(a_1103, "length")) && Lt(i_1106, Get(b_1104, "length"))) && SEq(GetK(a_1103, i_1106), GetK(b_1104, i_1106)))) {
PostInc(ref i_1106, 1D);
}
if (SEq(i_1106, Get(a_1103, "length"))) {
return ((V)(((double)(ToInt32(16D) | ToInt32(4D)))));
}
if (SEq(i_1106, Get(b_1104, "length"))) {
return ((V)(((double)(ToInt32(8D) | ToInt32(2D)))));
}
p_1107 = GetIdx(a_1103, (ToNum(i_1106) - 1D));
return ((V)((Gt(Invoke(Get(p_1107, "childNodes"), "indexOf", GetK(b_1104, i_1106)), Invoke(Get(p_1107, "childNodes"), "indexOf", GetK(a_1103, i_1106))) ? 4D : 2D)));
return default;
}, 1, "", false));
Set(Get(Node_10, "prototype"), "contains", Fn((V _self1108, int _argc1109, V n_1115, V _a1112, V _a1113, V _a1114, V[] _rest1110) => {
while (Truthy(n_1115)) {
if (SEq(n_1115, _self1108)) {
return (true ? V.True : V.False);
}
n_1115 = Get(n_1115, "parentNode");
}
return (false ? V.True : V.False);
return default;
}, 1, "", false));
Set(Get(Node_10, "prototype"), "hasChildNodes", Fn((V _self1116, int _argc1117, V _a1119, V _a1120, V _a1121, V _a1122, V[] _rest1118) => {
return (GtN(Get(Get(_self1116, "childNodes"), "length"), 0D) ? V.True : V.False);
return default;
}, 0, "", false));
Set(Text_11, "prototype", Object_create(Get(Node_10, "prototype")));
Object_defineProperty(Get(Text_11, "prototype"), ((V)("textContent")), NewObj(2).Put("get", Fn((V _self1123, int _argc1124, V _a1126, V _a1127, V _a1128, V _a1129, V[] _rest1125) => {
return Get(_self1123, "data");
return default;
}, 0, "get", false)).Put("set", Fn((V _self1130, int _argc1131, V v_1137, V _a1134, V _a1135, V _a1136, V[] _rest1132) => {
Set(_self1130, "data", ((V)(ToStrS(v_1137))));
return default;
}, 1, "set", false)).V);
Object_defineProperty(Get(Text_11, "prototype"), ((V)("nodeValue")), NewObj(2).Put("get", Fn((V _self1138, int _argc1139, V _a1141, V _a1142, V _a1143, V _a1144, V[] _rest1140) => {
return Get(_self1138, "data");
return default;
}, 0, "get", false)).Put("set", Fn((V _self1145, int _argc1146, V v_1152, V _a1149, V _a1150, V _a1151, V[] _rest1147) => {
Set(_self1145, "data", ((V)(ToStrS(v_1152))));
return default;
}, 1, "set", false)).V);
Set(Get(Text_11, "prototype"), "cloneNode", Fn((V _self1153, int _argc1154, V _a1156, V _a1157, V _a1158, V _a1159, V[] _rest1155) => {
return New(Text_11, Get(_self1153, "data"));
return default;
}, 0, "", false));
Set(Fragment_12, "prototype", Object_create(Get(Node_10, "prototype")));
camel_13 = Fn((V _self1160, int _argc1161, V s_1167, V _a1164, V _a1165, V _a1166, V[] _rest1162) => {
return Invoke(Invoke(Invoke(s_1167, "trim"), "replace", NewRegExp(RX12, "^-webkit-", ""), ((V)("webkit-"))), "replace", NewRegExp(RX11, "-([a-z])", "g"), Fn((V _self1168, int _argc1169, V m_1175, V c_1176, V _a1173, V _a1174, V[] _rest1170) => {
return Invoke(c_1176, "toUpperCase");
return default;
}, 2, "", false));
return default;
}, 1, "", false);
kebab_14 = Fn((V _self1177, int _argc1178, V s_1184, V _a1181, V _a1182, V _a1183, V[] _rest1179) => {
return Invoke(Invoke(s_1184, "replace", NewRegExp(RX14, "[A-Z]", "g"), Fn((V _self1185, int _argc1186, V c_1192, V _a1189, V _a1190, V _a1191, V[] _rest1187) => {
return ((V)(JsStrBuf.Begin().S("-").V(Invoke(c_1192, "toLowerCase")).End()));
return default;
}, 1, "", false)), "replace", NewRegExp(RX13, "^webkit-", ""), ((V)("-webkit-")));
return default;
}, 1, "", false);
Object_defineProperty(Get(Style_15, "prototype"), ((V)("cssText")), NewObj(2).Put("get", Fn((V _self1193, int _argc1194, V _a1196, V _a1197, V _a1198, V _a1199, V[] _rest1195) => {
V o_1200 = default;
V k_1201 = default;
o_1200 = Arr();
{
foreach (V _k1202 in ForInKeys(_self1193)) {
k_1201 = _k1202;
if (Truthy(((Invoke(Get(Get(G("Object"), "prototype"), "hasOwnProperty"), "call", _self1193, k_1201) is var _t1203 && !Truthy(_t1203) ? _t1203 : (!SEqS(GetK(_self1193, k_1201), "") ? V.True : V.False)) is var _t1204 && !Truthy(_t1204) ? _t1204 : (!GetK(_self1193, k_1201).IsNullish ? V.True : V.False)))) {
Invoke(o_1200, "push", ((V)(JsStrBuf.Begin().V(Call(kebab_14, V.Undef, k_1201)).S(": ").V(GetK(_self1193, k_1201)).S(";").End())));
}
}
}
return Invoke(o_1200, "join", ((V)(" ")));
return default;
}, 0, "get", false)).Put("set", Fn((V _self1205, int _argc1206, V v_1212, V _a1209, V _a1210, V _a1211, V[] _rest1207) => {
V k_1213 = default;
V parts_1214 = default;
V i_1215 = default;
V j_1216 = default;
{
foreach (V _k1217 in ForInKeys(_self1205)) {
k_1213 = _k1217;
if (Truthy(Invoke(Get(Get(G("Object"), "prototype"), "hasOwnProperty"), "call", _self1205, k_1213))) {
DeleteK(_self1205, k_1213);
}
}
}
parts_1214 = Invoke(((V)(ToStrS(v_1212))), "split", ((V)(";")));
{
i_1215 = ((V)(0D));
while (true) {
if (!(Lt(i_1215, Get(parts_1214, "length")))) break;
j_1216 = Invoke(GetK(parts_1214, i_1215), "indexOf", ((V)(":")));
if (GtN(j_1216, 0D)) {
SetK(_self1205, Call(camel_13, V.Undef, Invoke(GetK(parts_1214, i_1215), "slice", ((V)(0D)), j_1216)), Invoke(Invoke(GetK(parts_1214, i_1215), "slice", Add(j_1216, ((V)(1D)))), "trim"));
}
PostInc(ref i_1215, 1D);
}
}
return default;
}, 1, "set", false)).V);
Set(Get(Style_15, "prototype"), "setProperty", Fn((V _self1219, int _argc1220, V k_1226, V v_1227, V _a1224, V _a1225, V[] _rest1221) => {
SetK(_self1219, Call(camel_13, V.Undef, k_1226), ((V)(ToStrS(v_1227))));
return default;
}, 2, "", false));
Set(Get(Style_15, "prototype"), "getPropertyValue", Fn((V _self1228, int _argc1229, V k_1235, V _a1232, V _a1233, V _a1234, V[] _rest1230) => {
return (GetK(_self1228, Call(camel_13, V.Undef, k_1235)) is var _t1236 && Truthy(_t1236) ? _t1236 : ((V)("")));
return default;
}, 1, "", false));
Set(Get(Style_15, "prototype"), "removeProperty", Fn((V _self1237, int _argc1238, V k_1244, V _a1241, V _a1242, V _a1243, V[] _rest1239) => {
V c_1245 = default;
V v_1246 = default;
c_1245 = Call(camel_13, V.Undef, k_1244);
v_1246 = (GetK(_self1237, c_1245) is var _t1247 && Truthy(_t1247) ? _t1247 : ((V)("")));
DeleteK(_self1237, c_1245);
return v_1246;
return default;
}, 1, "", false));
Set(Get(ClassList_16, "prototype"), "_get", Fn((V _self1248, int _argc1249, V _a1251, V _a1252, V _a1253, V _a1254, V[] _rest1250) => {
return Invoke(Invoke((Invoke(Get(_self1248, "el"), "getAttribute", ((V)("class"))) is var _t1255 && Truthy(_t1255) ? _t1255 : ((V)(""))), "split", NewRegExp(RX2, "\\s+", "")), "filter", G("Boolean"));
return default;
}, 0, "", false));
Set(Get(ClassList_16, "prototype"), "_set", Fn((V _self1256, int _argc1257, V a_1263, V _a1260, V _a1261, V _a1262, V[] _rest1258) => {
Invoke(Get(_self1256, "el"), "setAttribute", ((V)("class")), Invoke(a_1263, "join", ((V)(" "))));
return default;
}, 1, "", false));
Set(Get(ClassList_16, "prototype"), "contains", Fn((V _self1264, int _argc1265, V c_1271, V _a1268, V _a1269, V _a1270, V[] _rest1266) => {
return (GeN(Invoke(Invoke(_self1264, "_get"), "indexOf", c_1271), 0D) ? V.True : V.False);
return default;
}, 1, "", false));
Set(Get(ClassList_16, "prototype"), "add", Fn((V _self1272, int _argc1273, V _a1275, V _a1276, V _a1277, V _a1278, V[] _rest1274) => {
V a_1280 = default;
V i_1281 = default;
V _arguments1279 = Arguments(_argc1273, _a1275, _a1276, _a1277, _a1278, _rest1274);
a_1280 = Invoke(_self1272, "_get");
{
i_1281 = ((V)(0D));
while (true) {
if (!(Lt(i_1281, Get(_arguments1279, "length")))) break;
if (LtN(Invoke(a_1280, "indexOf", GetK(_arguments1279, i_1281)), 0D)) {
Invoke(a_1280, "push", GetK(_arguments1279, i_1281));
}
PostInc(ref i_1281, 1D);
}
}
Invoke(_self1272, "_set", a_1280);
return default;
}, 0, "", false));
Set(Get(ClassList_16, "prototype"), "remove", Fn((V _self1283, int _argc1284, V _a1286, V _a1287, V _a1288, V _a1289, V[] _rest1285) => {
V r_1291 = default;
V _arguments1290 = Arguments(_argc1284, _a1286, _a1287, _a1288, _a1289, _rest1285);
r_1291 = Invoke(Get(Arr(), "slice"), "call", _arguments1290);
Invoke(_self1283, "_set", Invoke(Invoke(_self1283, "_get"), "filter", Fn((V _self1292, int _argc1293, V c_1299, V _a1296, V _a1297, V _a1298, V[] _rest1294) => {
return (LtN(Invoke(r_1291, "indexOf", c_1299), 0D) ? V.True : V.False);
return default;
}, 1, "", false)));
return default;
}, 0, "", false));
Set(Get(ClassList_16, "prototype"), "toggle", Fn((V _self1300, int _argc1301, V c_1307, V on_1308, V _a1305, V _a1306, V[] _rest1302) => {
V has_1309 = default;
has_1309 = Invoke(_self1300, "contains", c_1307);
if (SEq(on_1308, V.Undef)) {
on_1308 = (!(Truthy(has_1309)) ? V.True : V.False);
}
if (Truthy((on_1308 is var _t1310 && !Truthy(_t1310) ? _t1310 : (!(Truthy(has_1309)) ? V.True : V.False)))) {
Invoke(_self1300, "add", c_1307);
}
if (Truthy(((!(Truthy(on_1308)) ? V.True : V.False) is var _t1311 && !Truthy(_t1311) ? _t1311 : has_1309))) {
Invoke(_self1300, "remove", c_1307);
}
return on_1308;
return default;
}, 2, "", false));
NEXT_ID_17 = ((V)(1D));
Set(Element_18, "prototype", Object_create(Get(Node_10, "prototype")));
Set(Get(Element_18, "prototype"), "setAttribute", Fn((V _self1312, int _argc1313, V k_1319, V v_1320, V _a1317, V _a1318, V[] _rest1314) => {
V i_1321 = default;
k_1319 = ((V)(ToStrS(k_1319)));
v_1320 = ((V)(ToStrS(v_1320)));
if (SEqS(k_1319, "style")) {
Set(Get(_self1312, "style"), "cssText", v_1320);
return default;
}
{
i_1321 = ((V)(0D));
while (true) {
if (!(Lt(i_1321, Get(Get(_self1312, "_attrs"), "length")))) break;
if (SEq(GetIdx(GetK(Get(_self1312, "_attrs"), i_1321), 0D), k_1319)) {
SetIdx(GetK(Get(_self1312, "_attrs"), i_1321), 1D, v_1320);
return default;
}
PostInc(ref i_1321, 1D);
}
}
Invoke(Get(_self1312, "_attrs"), "push", Arr(k_1319, v_1320));
return default;
}, 2, "", false));
Set(Get(Element_18, "prototype"), "setAttributeNS", Fn((V _self1323, int _argc1324, V ns_1330, V k_1331, V v_1332, V _a1329, V[] _rest1325) => {
Invoke(_self1323, "setAttribute", k_1331, v_1332);
return default;
}, 3, "", false));
Set(Get(Element_18, "prototype"), "getAttribute", Fn((V _self1333, int _argc1334, V k_1340, V _a1337, V _a1338, V _a1339, V[] _rest1335) => {
V s_1341 = default;
V i_1342 = default;
if (SEqS(k_1340, "style")) {
s_1341 = Get(Get(_self1333, "style"), "cssText");
return (s_1341 is var _t1343 && Truthy(_t1343) ? _t1343 : V.Null);
}
{
i_1342 = ((V)(0D));
while (true) {
if (!(Lt(i_1342, Get(Get(_self1333, "_attrs"), "length")))) break;
if (SEq(GetIdx(GetK(Get(_self1333, "_attrs"), i_1342), 0D), k_1340)) {
return GetIdx(GetK(Get(_self1333, "_attrs"), i_1342), 1D);
}
PostInc(ref i_1342, 1D);
}
}
return V.Null;
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "getAttributeNS", Fn((V _self1345, int _argc1346, V ns_1352, V k_1353, V _a1350, V _a1351, V[] _rest1347) => {
return Invoke(_self1345, "getAttribute", k_1353);
return default;
}, 2, "", false));
Set(Get(Element_18, "prototype"), "hasAttribute", Fn((V _self1354, int _argc1355, V k_1361, V _a1358, V _a1359, V _a1360, V[] _rest1356) => {
return (!SEq(Invoke(_self1354, "getAttribute", k_1361), V.Null) ? V.True : V.False);
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "removeAttribute", Fn((V _self1362, int _argc1363, V k_1369, V _a1366, V _a1367, V _a1368, V[] _rest1364) => {
V i_1370 = default;
if (SEqS(k_1369, "style")) {
Set(Get(_self1362, "style"), "cssText", ((V)("")));
return default;
}
{
i_1370 = ((V)(0D));
while (true) {
if (!(Lt(i_1370, Get(Get(_self1362, "_attrs"), "length")))) break;
if (SEq(GetIdx(GetK(Get(_self1362, "_attrs"), i_1370), 0D), k_1369)) {
Invoke(Get(_self1362, "_attrs"), "splice", i_1370, ((V)(1D)));
return default;
}
PostInc(ref i_1370, 1D);
}
}
return default;
}, 1, "", false));
Object_defineProperty(Get(Element_18, "prototype"), ((V)("attributes")), NewObj(1).Put("get", Fn((V _self1372, int _argc1373, V _a1375, V _a1376, V _a1377, V _a1378, V[] _rest1374) => {
return Invoke(Get(_self1372, "_attrs"), "map", Fn((V _self1379, int _argc1380, V a_1386, V _a1383, V _a1384, V _a1385, V[] _rest1381) => {
return NewObj(4).Put("name", GetIdx(a_1386, 0D)).Put("value", GetIdx(a_1386, 1D)).Put("nodeName", GetIdx(a_1386, 0D)).Put("nodeValue", GetIdx(a_1386, 1D)).V;
return default;
}, 1, "", false));
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("children")), NewObj(1).Put("get", Fn((V _self1387, int _argc1388, V _a1390, V _a1391, V _a1392, V _a1393, V[] _rest1389) => {
return Invoke(Get(_self1387, "childNodes"), "filter", Fn((V _self1394, int _argc1395, V n_1401, V _a1398, V _a1399, V _a1400, V[] _rest1396) => {
return (SEqN(Get(n_1401, "nodeType"), 1D) ? V.True : V.False);
return default;
}, 1, "", false));
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("childElementCount")), NewObj(1).Put("get", Fn((V _self1402, int _argc1403, V _a1405, V _a1406, V _a1407, V _a1408, V[] _rest1404) => {
return Get(Get(_self1402, "children"), "length");
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("firstElementChild")), NewObj(1).Put("get", Fn((V _self1409, int _argc1410, V _a1412, V _a1413, V _a1414, V _a1415, V[] _rest1411) => {
return (GetIdx(Get(_self1409, "children"), 0D) is var _t1416 && Truthy(_t1416) ? _t1416 : V.Null);
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("lastElementChild")), NewObj(1).Put("get", Fn((V _self1417, int _argc1418, V _a1420, V _a1421, V _a1422, V _a1423, V[] _rest1419) => {
V c_1424 = default;
c_1424 = Get(_self1417, "children");
return (GetIdx(c_1424, (ToNum(Get(c_1424, "length")) - 1D)) is var _t1425 && Truthy(_t1425) ? _t1425 : V.Null);
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("classList")), NewObj(1).Put("get", Fn((V _self1426, int _argc1427, V _a1429, V _a1430, V _a1431, V _a1432, V[] _rest1428) => {
return New(ClassList_16, _self1426);
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("id")), NewObj(2).Put("get", Fn((V _self1433, int _argc1434, V _a1436, V _a1437, V _a1438, V _a1439, V[] _rest1435) => {
return (Invoke(_self1433, "getAttribute", ((V)("id"))) is var _t1440 && Truthy(_t1440) ? _t1440 : ((V)("")));
return default;
}, 0, "get", false)).Put("set", Fn((V _self1441, int _argc1442, V v_1448, V _a1445, V _a1446, V _a1447, V[] _rest1443) => {
Invoke(_self1441, "setAttribute", ((V)("id")), v_1448);
return default;
}, 1, "set", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("className")), NewObj(2).Put("get", Fn((V _self1449, int _argc1450, V _a1452, V _a1453, V _a1454, V _a1455, V[] _rest1451) => {
return (Invoke(_self1449, "getAttribute", ((V)("class"))) is var _t1456 && Truthy(_t1456) ? _t1456 : ((V)("")));
return default;
}, 0, "get", false)).Put("set", Fn((V _self1457, int _argc1458, V v_1464, V _a1461, V _a1462, V _a1463, V[] _rest1459) => {
Invoke(_self1457, "setAttribute", ((V)("class")), v_1464);
return default;
}, 1, "set", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("textContent")), NewObj(2).Put("get", Fn((V _self1465, int _argc1466, V _a1468, V _a1469, V _a1470, V _a1471, V[] _rest1467) => {
return Invoke(Invoke(Get(_self1465, "childNodes"), "map", Fn((V _self1472, int _argc1473, V n_1479, V _a1476, V _a1477, V _a1478, V[] _rest1474) => {
return Get(n_1479, "textContent");
return default;
}, 1, "", false)), "join", ((V)("")));
return default;
}, 0, "get", false)).Put("set", Fn((V _self1480, int _argc1481, V v_1487, V _a1484, V _a1485, V _a1486, V[] _rest1482) => {
Invoke(Get(_self1480, "childNodes"), "forEach", Fn((V _self1488, int _argc1489, V n_1495, V _a1492, V _a1493, V _a1494, V[] _rest1490) => {
Set(n_1495, "parentNode", V.Null);
return default;
}, 1, "", false));
Set(_self1480, "childNodes", Arr());
if ((!SEqS(v_1487, "") && !v_1487.IsNullish)) {
Invoke(_self1480, "appendChild", New(Text_11, v_1487));
}
return default;
}, 1, "set", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("innerHTML")), NewObj(2).Put("get", Fn((V _self1496, int _argc1497, V _a1499, V _a1500, V _a1501, V _a1502, V[] _rest1498) => {
return Invoke(Invoke(Get(_self1496, "childNodes"), "map", serialize_33), "join", ((V)("")));
return default;
}, 0, "get", false)).Put("set", Fn((V _self1503, int _argc1504, V v_1510, V _a1507, V _a1508, V _a1509, V[] _rest1505) => {
Invoke(Get(_self1503, "childNodes"), "forEach", Fn((V _self1511, int _argc1512, V n_1518, V _a1515, V _a1516, V _a1517, V[] _rest1513) => {
Set(n_1518, "parentNode", V.Null);
return default;
}, 1, "", false));
Set(_self1503, "childNodes", Arr());
Call(parseInto_30, V.Undef, _self1503, ((V)(ToStrS(v_1510))), Get(_self1503, "namespaceURI"));
return default;
}, 1, "set", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("outerHTML")), NewObj(1).Put("get", Fn((V _self1519, int _argc1520, V _a1522, V _a1523, V _a1524, V _a1525, V[] _rest1521) => {
return Call(serialize_33, V.Undef, _self1519);
return default;
}, 0, "get", false)).V);
Set(Get(Element_18, "prototype"), "cloneNode", Fn((V _self1526, int _argc1527, V deep_1533, V _a1530, V _a1531, V _a1532, V[] _rest1528) => {
V e_1534 = default;
e_1534 = New(Element_18, Get(_self1526, "tagName"), Get(_self1526, "namespaceURI"));
Set(e_1534, "_attrs", Invoke(Get(_self1526, "_attrs"), "map", Fn((V _self1535, int _argc1536, V a_1542, V _a1539, V _a1540, V _a1541, V[] _rest1537) => {
return Arr(GetIdx(a_1542, 0D), GetIdx(a_1542, 1D));
return default;
}, 1, "", false)));
Set(Get(e_1534, "style"), "cssText", Get(Get(_self1526, "style"), "cssText"));
if (Truthy(deep_1533)) {
Invoke(Get(_self1526, "childNodes"), "forEach", Fn((V _self1543, int _argc1544, V c_1550, V _a1547, V _a1548, V _a1549, V[] _rest1545) => {
Invoke(e_1534, "appendChild", Invoke(c_1550, "cloneNode", (true ? V.True : V.False)));
return default;
}, 1, "", false));
}
return e_1534;
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "addEventListener", Fn((V _self1551, int _argc1552, V t_1558, V fn_1559, V _a1556, V _a1557, V[] _rest1553) => {
Invoke(SetK(Get(_self1551, "_listeners"), t_1558, (GetK(Get(_self1551, "_listeners"), t_1558) is var _t1560 && Truthy(_t1560) ? _t1560 : Arr())), "push", fn_1559);
return default;
}, 2, "", false));
Set(Get(Element_18, "prototype"), "removeEventListener", Fn((V _self1561, int _argc1562, V t_1568, V fn_1569, V _a1566, V _a1567, V[] _rest1563) => {
V a_1570 = default;
V i_1571 = default;
a_1570 = GetK(Get(_self1561, "_listeners"), t_1568);
if (Truthy(a_1570)) {
i_1571 = Invoke(a_1570, "indexOf", fn_1569);
if (GeN(i_1571, 0D)) {
Invoke(a_1570, "splice", i_1571, ((V)(1D)));
}
}
return default;
}, 2, "", false));
Set(Get(Element_18, "prototype"), "dispatchEvent", Fn((V _self1572, int _argc1573, V ev_1579, V _a1576, V _a1577, V _a1578, V[] _rest1574) => {
V a_1580 = default;
V i_1581 = default;
Set(ev_1579, "target", (Get(ev_1579, "target") is var _t1582 && Truthy(_t1582) ? _t1582 : _self1572));
a_1580 = Invoke((GetK(Get(_self1572, "_listeners"), Get(ev_1579, "type")) is var _t1583 && Truthy(_t1583) ? _t1583 : Arr()), "slice");
{
i_1581 = ((V)(0D));
while (true) {
if (!(Lt(i_1581, Get(a_1580, "length")))) break;
Invoke(GetK(a_1580, i_1581), "call", _self1572, ev_1579);
PostInc(ref i_1581, 1D);
}
}
return (true ? V.True : V.False);
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "insertAdjacentHTML", Fn((V _self1585, int _argc1586, V where_1592, V html_1593, V _a1590, V _a1591, V[] _rest1587) => {
V f_1594 = default;
f_1594 = New(Fragment_12);
Call(parseInto_30, V.Undef, f_1594, ((V)(ToStrS(html_1593))), Get(_self1585, "namespaceURI"));
if (SEqS(where_1592, "beforeend")) {
Invoke(_self1585, "appendChild", f_1594);
} else {
if (SEqS(where_1592, "afterbegin")) {
Invoke(_self1585, "insertBefore", f_1594, Get(_self1585, "firstChild"));
} else {
if (Truthy(((SEqS(where_1592, "beforebegin") ? V.True : V.False) is var _t1595 && !Truthy(_t1595) ? _t1595 : Get(_self1585, "parentNode")))) {
Invoke(Get(_self1585, "parentNode"), "insertBefore", f_1594, _self1585);
} else {
if (Truthy(((SEqS(where_1592, "afterend") ? V.True : V.False) is var _t1596 && !Truthy(_t1596) ? _t1596 : Get(_self1585, "parentNode")))) {
Invoke(Get(_self1585, "parentNode"), "insertBefore", f_1594, Get(_self1585, "nextSibling"));
}
}
}
}
return default;
}, 2, "", false));
Set(Get(Element_18, "prototype"), "insertAdjacentElement", Fn((V _self1597, int _argc1598, V where_1604, V el_1605, V _a1602, V _a1603, V[] _rest1599) => {
V f_1606 = default;
V h_1607 = default;
f_1606 = New(Fragment_12);
Invoke(f_1606, "appendChild", el_1605);
h_1607 = _self1597;
if (SEqS(where_1604, "beforeend")) {
Invoke(h_1607, "appendChild", el_1605);
} else {
if (SEqS(where_1604, "afterbegin")) {
Invoke(h_1607, "insertBefore", el_1605, Get(h_1607, "firstChild"));
} else {
if (SEqS(where_1604, "beforebegin")) {
Invoke(Get(h_1607, "parentNode"), "insertBefore", el_1605, h_1607);
} else {
Invoke(Get(h_1607, "parentNode"), "insertBefore", el_1605, Get(h_1607, "nextSibling"));
}
}
}
return el_1605;
return default;
}, 2, "", false));
Set(Get(Element_18, "prototype"), "append", Fn((V _self1608, int _argc1609, V _a1611, V _a1612, V _a1613, V _a1614, V[] _rest1610) => {
V i_1616 = default;
V a_1617 = default;
V _arguments1615 = Arguments(_argc1609, _a1611, _a1612, _a1613, _a1614, _rest1610);
{
i_1616 = ((V)(0D));
while (true) {
if (!(Lt(i_1616, Get(_arguments1615, "length")))) break;
a_1617 = GetK(_arguments1615, i_1616);
Invoke(_self1608, "appendChild", (string.Equals(Typeof(a_1617), "string") ? New(Text_11, a_1617) : a_1617));
PostInc(ref i_1616, 1D);
}
}
return default;
}, 0, "", false));
Set(Get(Element_18, "prototype"), "prepend", Fn((V _self1619, int _argc1620, V _a1622, V _a1623, V _a1624, V _a1625, V[] _rest1621) => {
V first_1627 = default;
V i_1628 = default;
V a_1629 = default;
V _arguments1626 = Arguments(_argc1620, _a1622, _a1623, _a1624, _a1625, _rest1621);
first_1627 = Get(_self1619, "firstChild");
{
i_1628 = ((V)(0D));
while (true) {
if (!(Lt(i_1628, Get(_arguments1626, "length")))) break;
a_1629 = GetK(_arguments1626, i_1628);
Invoke(_self1619, "insertBefore", (string.Equals(Typeof(a_1629), "string") ? New(Text_11, a_1629) : a_1629), first_1627);
PostInc(ref i_1628, 1D);
}
}
return default;
}, 0, "", false));
Object_defineProperty(Get(Element_18, "prototype"), ((V)("nextElementSibling")), NewObj(1).Put("get", Fn((V _self1631, int _argc1632, V _a1634, V _a1635, V _a1636, V _a1637, V[] _rest1633) => {
V n_1638 = default;
n_1638 = Get(_self1631, "nextSibling");
while (Truthy((n_1638 is var _t1639 && !Truthy(_t1639) ? _t1639 : (!SEqN(Get(n_1638, "nodeType"), 1D) ? V.True : V.False)))) {
n_1638 = Get(n_1638, "nextSibling");
}
return n_1638;
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("previousElementSibling")), NewObj(1).Put("get", Fn((V _self1640, int _argc1641, V _a1643, V _a1644, V _a1645, V _a1646, V[] _rest1642) => {
V n_1647 = default;
n_1647 = Get(_self1640, "previousSibling");
while (Truthy((n_1647 is var _t1648 && !Truthy(_t1648) ? _t1648 : (!SEqN(Get(n_1647, "nodeType"), 1D) ? V.True : V.False)))) {
n_1647 = Get(n_1647, "previousSibling");
}
return n_1647;
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("ownerSVGElement")), NewObj(1).Put("get", Fn((V _self1649, int _argc1650, V _a1652, V _a1653, V _a1654, V _a1655, V[] _rest1651) => {
V p_1656 = default;
p_1656 = Get(_self1649, "parentNode");
while (Truthy((p_1656 is var _t1657 && !Truthy(_t1657) ? _t1657 : (SEqN(Get(p_1656, "nodeType"), 1D) ? V.True : V.False)))) {
if (SEqS(Get(p_1656, "localName"), "svg")) {
return p_1656;
}
p_1656 = Get(p_1656, "parentNode");
}
return V.Null;
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("isConnected")), NewObj(1).Put("get", Fn((V _self1658, int _argc1659, V _a1661, V _a1662, V _a1663, V _a1664, V[] _rest1660) => {
V p_1665 = default;
p_1665 = _self1658;
while (Truthy(Get(p_1665, "parentNode"))) {
p_1665 = Get(p_1665, "parentNode");
}
return (!(!(Truthy(Get(p_1665, "__isRoot")))) ? V.True : V.False);
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("dataset")), NewObj(1).Put("get", Fn((V _self1666, int _argc1667, V _a1669, V _a1670, V _a1671, V _a1672, V[] _rest1668) => {
V el_1673 = default;
V o_1674 = default;
V a_1675 = default;
V i_1676 = default;
el_1673 = _self1666;
if (string.Equals(GTypeof("Proxy"), "undefined")) {
o_1674 = NewObj(0).V;
a_1675 = (Get(el_1673, "_attrs") is var _t1677 && Truthy(_t1677) ? _t1677 : Arr());
{
i_1676 = ((V)(0D));
while (true) {
if (!(Lt(i_1676, Get(a_1675, "length")))) break;
if (SEqN(Invoke(GetIdx(GetK(a_1675, i_1676), 0D), "indexOf", ((V)("data-"))), 0D)) {
SetK(o_1674, Invoke(Invoke(GetIdx(GetK(a_1675, i_1676), 0D), "slice", ((V)(5D))), "replace", NewRegExp(RX11, "-([a-z])", "g"), Fn((V _self1679, int _argc1680, V m_1686, V c_1687, V _a1684, V _a1685, V[] _rest1681) => {
return Invoke(c_1687, "toUpperCase");
return default;
}, 2, "", false)), GetIdx(GetK(a_1675, i_1676), 1D));
}
PostInc(ref i_1676, 1D);
}
}
return o_1674;
}
return New(G("Proxy"), NewObj(0).V, NewObj(3).Put("get", Fn((V _self1688, int _argc1689, V t_1695, V k_1696, V _a1693, V _a1694, V[] _rest1690) => {
V v_1697 = default;
v_1697 = Invoke(el_1673, "getAttribute", ((V)(JsStrBuf.Begin().S("data-").V(Call(kebab_14, V.Undef, ((V)(ToStrS(k_1696))))).End())));
return (SEq(v_1697, V.Null) ? V.Undef : v_1697);
return default;
}, 2, "get", false)).Put("set", Fn((V _self1698, int _argc1699, V t_1705, V k_1706, V v_1707, V _a1704, V[] _rest1700) => {
Invoke(el_1673, "setAttribute", ((V)(JsStrBuf.Begin().S("data-").V(Call(kebab_14, V.Undef, ((V)(ToStrS(k_1706))))).End())), v_1707);
return (true ? V.True : V.False);
return default;
}, 3, "set", false)).Put("deleteProperty", Fn((V _self1708, int _argc1709, V t_1715, V k_1716, V _a1713, V _a1714, V[] _rest1710) => {
Invoke(el_1673, "removeAttribute", ((V)(JsStrBuf.Begin().S("data-").V(Call(kebab_14, V.Undef, ((V)(ToStrS(k_1716))))).End())));
return (true ? V.True : V.False);
return default;
}, 2, "deleteProperty", false)).V);
return default;
}, 0, "get", false)).V);
Set(Get(Element_18, "prototype"), "setPointerCapture", Fn((V _self1717, int _argc1718, V _a1720, V _a1721, V _a1722, V _a1723, V[] _rest1719) => {

return default;
}, 0, "", false));
Set(Get(Element_18, "prototype"), "releasePointerCapture", Fn((V _self1724, int _argc1725, V _a1727, V _a1728, V _a1729, V _a1730, V[] _rest1726) => {

return default;
}, 0, "", false));
Set(Get(Element_18, "prototype"), "hasPointerCapture", Fn((V _self1731, int _argc1732, V _a1734, V _a1735, V _a1736, V _a1737, V[] _rest1733) => {
return (false ? V.True : V.False);
return default;
}, 0, "", false));
Set(Get(Element_18, "prototype"), "focus", Fn((V _self1738, int _argc1739, V _a1741, V _a1742, V _a1743, V _a1744, V[] _rest1740) => {

return default;
}, 0, "", false));
Set(Get(Element_18, "prototype"), "blur", Fn((V _self1745, int _argc1746, V _a1748, V _a1749, V _a1750, V _a1751, V[] _rest1747) => {

return default;
}, 0, "", false));
Set(Get(Element_18, "prototype"), "getBoundingClientRect", Fn((V _self1752, int _argc1753, V _a1755, V _a1756, V _a1757, V _a1758, V[] _rest1754) => {
V e_1759 = default;
V r_1760 = default;
e_1759 = _self1752;
while (Truthy((e_1759 is var _t1761 && !Truthy(_t1761) ? _t1761 : (!(Truthy(Get(e_1759, "__rect"))) ? V.True : V.False)))) {
e_1759 = Get(e_1759, "parentNode");
}
r_1760 = ((e_1759 is var _t1762 && !Truthy(_t1762) ? _t1762 : Get(e_1759, "__rect")) is var _t1763 && Truthy(_t1763) ? _t1763 : NewObj(4).Put("left", ((V)(0D))).Put("top", ((V)(0D))).Put("width", ((V)(100D))).Put("height", ((V)(100D))).V);
return NewObj(8).Put("left", Get(r_1760, "left")).Put("top", Get(r_1760, "top")).Put("x", Get(r_1760, "left")).Put("y", Get(r_1760, "top")).Put("width", Get(r_1760, "width")).Put("height", Get(r_1760, "height")).Put("right", Add(Get(r_1760, "left"), Get(r_1760, "width"))).Put("bottom", Add(Get(r_1760, "top"), Get(r_1760, "height"))).V;
return default;
}, 0, "", false));
Set(Get(Element_18, "prototype"), "getBBox", Fn((V _self1764, int _argc1765, V _a1767, V _a1768, V _a1769, V _a1770, V[] _rest1766) => {
return Call(bbox_36, V.Undef, _self1764);
return default;
}, 0, "", false));
Set(Get(Element_18, "prototype"), "matches", Fn((V _self1771, int _argc1772, V sel_1778, V _a1775, V _a1776, V _a1777, V[] _rest1773) => {
return Call(matchesList_26, V.Undef, _self1771, Call(parseSelectors_21, V.Undef, sel_1778));
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "closest", Fn((V _self1779, int _argc1780, V sel_1786, V _a1783, V _a1784, V _a1785, V[] _rest1781) => {
V s_1787 = default;
V e_1788 = default;
s_1787 = Call(parseSelectors_21, V.Undef, sel_1786);
e_1788 = _self1779;
while (Truthy((e_1788 is var _t1789 && !Truthy(_t1789) ? _t1789 : (SEqN(Get(e_1788, "nodeType"), 1D) ? V.True : V.False)))) {
if (Truthy(Call(matchesList_26, V.Undef, e_1788, s_1787))) {
return e_1788;
}
e_1788 = Get(e_1788, "parentNode");
}
return V.Null;
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "querySelectorAll", Fn((V _self1790, int _argc1791, V sel_1797, V _a1794, V _a1795, V _a1796, V[] _rest1792) => {
V s_1798 = default;
V @out_1799 = default;
s_1798 = Call(parseSelectors_21, V.Undef, sel_1797);
@out_1799 = Arr();
Call(walk_19, V.Undef, _self1790, Fn((V _self1800, int _argc1801, V e_1807, V _a1804, V _a1805, V _a1806, V[] _rest1802) => {
if (Truthy(Call(matchesList_26, V.Undef, e_1807, s_1798))) {
Invoke(@out_1799, "push", e_1807);
}
return default;
}, 1, "", false));
return @out_1799;
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "querySelector", Fn((V _self1808, int _argc1809, V sel_1815, V _a1812, V _a1813, V _a1814, V[] _rest1810) => {
V s_1816 = default;
V hit_1817 = default;
s_1816 = Call(parseSelectors_21, V.Undef, sel_1815);
hit_1817 = V.Null;
Call(walk_19, V.Undef, _self1808, Fn((V _self1818, int _argc1819, V e_1825, V _a1822, V _a1823, V _a1824, V[] _rest1820) => {
if (Truthy(((!(Truthy(hit_1817)) ? V.True : V.False) is var _t1826 && !Truthy(_t1826) ? _t1826 : Call(matchesList_26, V.Undef, e_1825, s_1816)))) {
hit_1817 = e_1825;
}
return default;
}, 1, "", false));
return hit_1817;
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "getElementsByTagName", Fn((V _self1827, int _argc1828, V t_1834, V _a1831, V _a1832, V _a1833, V[] _rest1829) => {
return Invoke(_self1827, "querySelectorAll", t_1834);
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "getContext", Fn((V _self1835, int _argc1836, V kind_1842, V _a1839, V _a1840, V _a1841, V[] _rest1837) => {
return ((SEqS(kind_1842, "2d") && SEqS(Get(_self1835, "localName"), "canvas")) ? Set(_self1835, "_ctx", (Get(_self1835, "_ctx") is var _t1843 && Truthy(_t1843) ? _t1843 : New(Ctx2D_61, _self1835))) : V.Null);
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "toDataURL", Fn((V _self1844, int _argc1845, V _a1847, V _a1848, V _a1849, V _a1850, V[] _rest1846) => {
V id_1851 = default;
id_1851 = ((V)(JsStrBuf.Begin().S("shim-canvas:").V(Get(_self1844, "__id")).End()));
SetK(CANVASES_60, id_1851, _self1844);
return id_1851;
return default;
}, 0, "", false));
Object_defineProperty(Get(Element_18, "prototype"), ((V)("width")), NewObj(2).Put("get", Fn((V _self1852, int _argc1853, V _a1855, V _a1856, V _a1857, V _a1858, V[] _rest1854) => {
return ((V)(ToNum((Invoke(_self1852, "getAttribute", ((V)("width"))) is var _t1859 && Truthy(_t1859) ? _t1859 : ((V)((SEqS(Get(_self1852, "localName"), "canvas") ? 300D : 0D)))))));
return default;
}, 0, "get", false)).Put("set", Fn((V _self1860, int _argc1861, V v_1867, V _a1864, V _a1865, V _a1866, V[] _rest1862) => {
Invoke(_self1860, "setAttribute", ((V)("width")), v_1867);
return default;
}, 1, "set", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("height")), NewObj(2).Put("get", Fn((V _self1868, int _argc1869, V _a1871, V _a1872, V _a1873, V _a1874, V[] _rest1870) => {
return ((V)(ToNum((Invoke(_self1868, "getAttribute", ((V)("height"))) is var _t1875 && Truthy(_t1875) ? _t1875 : ((V)((SEqS(Get(_self1868, "localName"), "canvas") ? 150D : 0D)))))));
return default;
}, 0, "get", false)).Put("set", Fn((V _self1876, int _argc1877, V v_1883, V _a1880, V _a1881, V _a1882, V[] _rest1878) => {
Invoke(_self1876, "setAttribute", ((V)("height")), v_1883);
return default;
}, 1, "set", false)).V);
SEL_CACHE_20 = NewObj(0).V;
VOID_HTML_27 = NewObj(6).Put("br", ((V)(1D))).Put("img", ((V)(1D))).Put("input", ((V)(1D))).Put("hr", ((V)(1D))).Put("meta", ((V)(1D))).Put("link", ((V)(1D))).V;
ENT_28 = NewObj(6).Put("amp", ((V)("&"))).Put("lt", ((V)("<"))).Put("gt", ((V)(">"))).Put("quot", ((V)("\""))).Put("apos", ((V)("'"))).Put("nbsp", ((V)("\u00a0"))).V;
unescape_29 = Fn((V _self1884, int _argc1885, V s_1891, V _a1888, V _a1889, V _a1890, V[] _rest1886) => {
return Invoke(s_1891, "replace", NewRegExp(RX15, "&(#x[0-9a-f]+|#\\d+|[a-z]+);", "gi"), Fn((V _self1892, int _argc1893, V m_1899, V e_1900, V _a1897, V _a1898, V[] _rest1894) => {
if (SEqS(GetIdx(e_1900, 0D), "#")) {
return ((V)(String_fromCharCode(((V)(((SEqS(GetIdx(e_1900, 1D), "x") || SEqS(GetIdx(e_1900, 1D), "X")) ? ParseInt(Invoke(e_1900, "slice", ((V)(2D))), ((V)(16D))) : ToNum(Invoke(e_1900, "slice", ((V)(1D))))))))));
}
return (!GetK(ENT_28, e_1900).IsNullish ? GetK(ENT_28, e_1900) : m_1899);
return default;
}, 2, "", false));
return default;
}, 1, "", false);
escAttr_31 = Fn((V _self1901, int _argc1902, V s_1908, V _a1905, V _a1906, V _a1907, V[] _rest1903) => {
return Invoke(Invoke(Invoke(Invoke(Invoke(s_1908, "replace", NewRegExp(RX20, "&", "g"), ((V)("&amp;"))), "replace", NewRegExp(RX19, "\"", "g"), ((V)("&quot;"))), "replace", NewRegExp(RX18, "\u00a0", "g"), ((V)("&nbsp;"))), "replace", NewRegExp(RX17, "<", "g"), ((V)("&lt;"))), "replace", NewRegExp(RX16, ">", "g"), ((V)("&gt;")));
return default;
}, 1, "", false);
escText_32 = Fn((V _self1909, int _argc1910, V s_1916, V _a1913, V _a1914, V _a1915, V[] _rest1911) => {
return Invoke(Invoke(Invoke(Invoke(s_1916, "replace", NewRegExp(RX20, "&", "g"), ((V)("&amp;"))), "replace", NewRegExp(RX17, "<", "g"), ((V)("&lt;"))), "replace", NewRegExp(RX16, ">", "g"), ((V)("&gt;"))), "replace", NewRegExp(RX18, "\u00a0", "g"), ((V)("&nbsp;")));
return default;
}, 1, "", false);
F_34 = Get(G("Math"), "fround");
Invoke(Arr(((V)("x")), ((V)("y")), ((V)("width")), ((V)("height"))), "forEach", Fn((V _self1917, int _argc1918, V k_1924, V i_1925, V _a1922, V _a1923, V[] _rest1919) => {
Object_defineProperty(Get(SVGRect_35, "prototype"), k_1924, NewObj(3).Put("get", Fn((V _self1926, int _argc1927, V _a1929, V _a1930, V _a1931, V _a1932, V[] _rest1928) => {
return GetK(Get(_self1926, "_r"), i_1925);
return default;
}, 0, "get", false)).Put("set", Fn((V _self1933, int _argc1934, V v_1940, V _a1937, V _a1938, V _a1939, V[] _rest1935) => {
SetK(Get(_self1933, "_r"), i_1925, ((V)(ToNum(v_1940))));
return default;
}, 1, "set", false)).Put("enumerable", (true ? V.True : V.False)).V);
return default;
}, 2, "", false));
Object_defineProperty(Get(SVGRect_35, "prototype"), ((V)("_r")), NewObj(3).Put("writable", (true ? V.True : V.False)).Put("enumerable", (false ? V.True : V.False)).Put("value", V.Null).V);
F32_38 = New(G("Float32Array"), ((V)(1D)));
U32_39 = New(G("Uint32Array"), Get(F32_38, "buffer"));
SINZ_48 = Fn((V _self1941, int _argc1942, V r_1948, V _a1945, V _a1946, V _a1947, V[] _rest1943) => {
V v_1949 = default;
v_1949 = Call(F_34, V.Undef, ((V)(FdLibm.Sin(ToNum(r_1948)))));
return (Le(((V)(System.Math.Abs(ToNum(v_1949)))), Call(F_34, V.Undef, ((V)((1D / 4096D))))) ? ((V)(0D)) : v_1949);
return default;
}, 1, "", false);
COSZ_49 = Fn((V _self1950, int _argc1951, V r_1957, V _a1954, V _a1955, V _a1956, V[] _rest1952) => {
V v_1958 = default;
v_1958 = Call(F_34, V.Undef, ((V)(FdLibm.Cos(ToNum(r_1957)))));
return (Le(((V)(System.Math.Abs(ToNum(v_1958)))), Call(F_34, V.Undef, ((V)((1D / 4096D))))) ? ((V)(0D)) : v_1958);
return default;
}, 1, "", false);
PIF_50 = Call(F_34, V.Undef, ((V)(System.Math.PI)));
DEG_51 = Call(F_34, V.Undef, ((V)((ToNum(PIF_50) / 180D))));
CANVASES_60 = NewObj(0).V;
Set(Get(Ctx2D_61, "prototype"), "createImageData", Fn((V _self1959, int _argc1960, V w_1966, V h_1967, V _a1964, V _a1965, V[] _rest1961) => {
return NewObj(3).Put("width", w_1966).Put("height", h_1967).Put("data", New(G("Uint8ClampedArray"), ((V)(((ToNum(w_1966) * ToNum(h_1967)) * 4D))))).V;
return default;
}, 2, "", false));
Set(Get(Ctx2D_61, "prototype"), "putImageData", Fn((V _self1968, int _argc1969, V im_1975, V _a1972, V _a1973, V _a1974, V[] _rest1970) => {
Set(Get(_self1968, "canvas"), "_pixels", NewObj(3).Put("width", Get(im_1975, "width")).Put("height", Get(im_1975, "height")).Put("data", Get(im_1975, "data")).V);
return default;
}, 1, "", false));
Set(Get(Ctx2D_61, "prototype"), "getImageData", Fn((V _self1976, int _argc1977, V x_1983, V y_1984, V w_1985, V h_1986, V[] _rest1978) => {
V p_1987 = default;
p_1987 = Get(Get(_self1976, "canvas"), "_pixels");
return (Truthy(p_1987) ? NewObj(3).Put("width", Get(p_1987, "width")).Put("height", Get(p_1987, "height")).Put("data", Get(p_1987, "data")).V : Invoke(_self1976, "createImageData", w_1985, h_1986));
return default;
}, 4, "", false));
Set(Get(Ctx2D_61, "prototype"), "createPattern", Fn((V _self1988, int _argc1989, V src_1995, V rep_1996, V _a1993, V _a1994, V[] _rest1990) => {
return NewObj(2).Put("pattern", src_1995).Put("repeat", rep_1996).V;
return default;
}, 2, "", false));
Set(Get(Ctx2D_61, "prototype"), "fillRect", Fn((V _self1997, int _argc1998, V x_2004, V y_2005, V w_2006, V h_2007, V[] _rest1999) => {
if (Truthy((Get(_self1997, "fillStyle") is var _t2008 && !Truthy(_t2008) ? _t2008 : Get(Get(_self1997, "fillStyle"), "pattern")))) {
Set(Get(_self1997, "canvas"), "_tiled", NewObj(3).Put("src", Get(Get(_self1997, "fillStyle"), "pattern")).Put("w", w_2006).Put("h", h_2007).V);
}
return default;
}, 4, "", false));
Invoke(Arr(((V)("clearRect")), ((V)("save")), ((V)("restore")), ((V)("translate")), ((V)("scale")), ((V)("rotate")), ((V)("beginPath")), ((V)("closePath")), ((V)("moveTo")), ((V)("lineTo")), ((V)("arc")), ((V)("fill")), ((V)("stroke")), ((V)("drawImage")), ((V)("setTransform"))), "forEach", Fn((V _self2009, int _argc2010, V k_2016, V _a2013, V _a2014, V _a2015, V[] _rest2011) => {
SetK(Get(Ctx2D_61, "prototype"), k_2016, Fn((V _self2017, int _argc2018, V _a2020, V _a2021, V _a2022, V _a2023, V[] _rest2019) => {

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
