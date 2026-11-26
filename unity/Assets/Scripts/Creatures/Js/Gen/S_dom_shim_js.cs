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
        static readonly System.Text.RegularExpressions.Regex RX10 = JsRegExp.Compile("^#([0-9a-f]{3,8})$", "");
        static readonly System.Text.RegularExpressions.Regex RX11 = JsRegExp.Compile(".", "g");
        static readonly System.Text.RegularExpressions.Regex RX12 = JsRegExp.Compile("^rgba?\\(([^)]*)\\)$", "");
        static readonly System.Text.RegularExpressions.Regex RX13 = JsRegExp.Compile("[\\s,\\/]+", "");
        static readonly System.Text.RegularExpressions.Regex RX14 = JsRegExp.Compile("^hsla?\\(([^)]*)\\)$", "");
        static readonly System.Text.RegularExpressions.Regex RX15 = JsRegExp.Compile("^url\\(\\s*[\"']?([^\"')]+)[\"']?\\s*\\)", "");
        static readonly System.Text.RegularExpressions.Regex RX16 = JsRegExp.Compile("^\\.\\/", "");
        static readonly System.Text.RegularExpressions.Regex RX17 = JsRegExp.Compile("-([a-z])", "g");
        static readonly System.Text.RegularExpressions.Regex RX18 = JsRegExp.Compile("^-webkit-", "");
        static readonly System.Text.RegularExpressions.Regex RX19 = JsRegExp.Compile("^webkit-", "");
        static readonly System.Text.RegularExpressions.Regex RX20 = JsRegExp.Compile("[A-Z]", "g");
        static readonly System.Text.RegularExpressions.Regex RX21 = JsRegExp.Compile("&(#x[0-9a-f]+|#\\d+|[a-z]+);", "gi");
        static readonly System.Text.RegularExpressions.Regex RX22 = JsRegExp.Compile(">", "g");
        static readonly System.Text.RegularExpressions.Regex RX23 = JsRegExp.Compile("<", "g");
        static readonly System.Text.RegularExpressions.Regex RX24 = JsRegExp.Compile("\u00a0", "g");
        static readonly System.Text.RegularExpressions.Regex RX25 = JsRegExp.Compile("\"", "g");
        static readonly System.Text.RegularExpressions.Regex RX26 = JsRegExp.Compile("&", "g");
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
V CS_INH_60 = default;
V CS_DEF_61 = default;
V CS_PAINT_62 = default;
V CS_NUM_63 = default;
V NAMED_64 = default;
V specified_65 = default;
V cssColor_66 = default;
V computed_67 = default;
V CStyle_68 = default;
V Mat_69 = default;
V Pt_70 = default;
V hostRect_71 = default;
V GEO_ATTRS_72 = default;
V geoOf_73 = default;
V shapeSubs_74 = default;
V pathSubs_75 = default;
V arcFlat_76 = default;
V CANVASES_77 = default;
V Ctx2D_78 = default;
V install_79 = default;
Node_10 = Fn((V _self80, int _argc81, V _a83, V _a84, V _a85, V _a86, V[] _rest82) => {
Set(_self80, "parentNode", V.Null);
Set(_self80, "childNodes", Arr());
return default;
}, 0, "Node", false);
Text_11 = Fn((V _self87, int _argc88, V t_94, V _a91, V _a92, V _a93, V[] _rest89) => {
Invoke(Node_10, "call", _self87);
Set(_self87, "nodeType", ((V)(3D)));
Set(_self87, "data", ((V)(ToStrS(t_94))));
return default;
}, 1, "Text", false);
Fragment_12 = Fn((V _self95, int _argc96, V _a98, V _a99, V _a100, V _a101, V[] _rest97) => {
Invoke(Node_10, "call", _self95);
Set(_self95, "nodeType", ((V)(11D)));
return default;
}, 0, "Fragment", false);
Style_15 = Fn((V _self102, int _argc103, V _a105, V _a106, V _a107, V _a108, V[] _rest104) => {

return default;
}, 0, "Style", false);
ClassList_16 = Fn((V _self109, int _argc110, V el_116, V _a113, V _a114, V _a115, V[] _rest111) => {
Set(_self109, "el", el_116);
return default;
}, 1, "ClassList", false);
Element_18 = Fn((V _self117, int _argc118, V tag_124, V ns_125, V _a122, V _a123, V[] _rest119) => {
Invoke(Node_10, "call", _self117);
Set(_self117, "nodeType", ((V)(1D)));
Set(_self117, "namespaceURI", (ns_125 is var _t126 && Truthy(_t126) ? _t126 : SVG_NS_9));
Set(_self117, "localName", (SEq(Get(_self117, "namespaceURI"), SVG_NS_9) ? tag_124 : Invoke(((V)(ToStrS(tag_124))), "toLowerCase")));
Set(_self117, "tagName", Set(_self117, "nodeName", (SEq(Get(_self117, "namespaceURI"), SVG_NS_9) ? tag_124 : Invoke(Get(_self117, "localName"), "toUpperCase"))));
Set(_self117, "_attrs", Arr());
Set(_self117, "style", New(Style_15));
Set(_self117, "_listeners", NewObj(0).V);
Set(_self117, "__id", ((V)(PostInc(ref NEXT_ID_17, 1D))));
return default;
}, 2, "Element", false);
walk_19 = Fn((V _self127, int _argc128, V el_134, V fn_135, V _a132, V _a133, V[] _rest129) => {
V i_136 = default;
V c_137 = default;
{
i_136 = ((V)(0D));
while (true) {
if (!(Lt(i_136, Get(Get(el_134, "childNodes"), "length")))) break;
c_137 = GetK(Get(el_134, "childNodes"), i_136);
if (SEqN(Get(c_137, "nodeType"), 1D)) {
Call(fn_135, V.Undef, c_137);
Call(walk_19, V.Undef, c_137, fn_135);
}
PostInc(ref i_136, 1D);
}
}
return default;
}, 2, "walk", false);
parseSelectors_21 = Fn((V _self139, int _argc140, V sel_146, V _a143, V _a144, V _a145, V[] _rest141) => {
V list_147 = default;
if (Truthy(GetK(SEL_CACHE_20, sel_146))) {
return GetK(SEL_CACHE_20, sel_146);
}
list_147 = Invoke(Call(splitTop_22, V.Undef, sel_146, ((V)(","))), "map", Fn((V _self148, int _argc149, V one_155, V _a152, V _a153, V _a154, V[] _rest150) => {
V steps_156 = default;
V comb_157 = default;
V re_158 = default;
V m_159 = default;
steps_156 = Arr();
comb_157 = ((V)(" "));
re_158 = NewRegExp(RX0, "\\s*(>)\\s*|\\s+|([^\\s>]+)", "g");
one_155 = Invoke(one_155, "trim");
while (Truthy((m_159 = Invoke(re_158, "exec", one_155)))) {
if (Truthy(GetIdx(m_159, 1D))) {
comb_157 = ((V)(">"));
continue;
}
if (!(Truthy(GetIdx(m_159, 2D)))) {
if (Truthy(Get(steps_156, "length"))) {
comb_157 = ((V)((SEqS(comb_157, ">") ? ">" : " ")));
}
continue;
}
Invoke(steps_156, "push", NewObj(2).Put("comb", (Truthy(Get(steps_156, "length")) ? comb_157 : V.Null)).Put("parts", Call(compound_23, V.Undef, GetIdx(m_159, 2D))).V);
comb_157 = ((V)(" "));
}
return steps_156;
return default;
}, 1, "", false));
return SetK(SEL_CACHE_20, sel_146, list_147);
return default;
}, 1, "parseSelectors", false);
splitTop_22 = Fn((V _self160, int _argc161, V s_167, V ch_168, V _a165, V _a166, V[] _rest162) => {
V @out_169 = default;
V d_170 = default;
V q_171 = default;
V cur_172 = default;
V i_173 = default;
V c_174 = default;
@out_169 = Arr();
d_170 = ((V)(0D));
q_171 = V.Null;
cur_172 = ((V)(""));
{
i_173 = ((V)(0D));
while (true) {
if (!(Lt(i_173, Get(s_167, "length")))) break;
c_174 = GetK(s_167, i_173);
if (Truthy(q_171)) {
if (SEq(c_174, q_171)) {
q_171 = V.Null;
}
} else {
if ((SEqS(c_174, "\"") || SEqS(c_174, "'"))) {
q_171 = c_174;
} else {
if (SEqS(c_174, "[")) {
PostInc(ref d_170, 1D);
} else {
if (SEqS(c_174, "]")) {
PostInc(ref d_170, -1D);
} else {
if ((SEq(c_174, ch_168) && !(Truthy(d_170)))) {
Invoke(@out_169, "push", cur_172);
cur_172 = ((V)(""));
goto _cont175;
}
}
}
}
}
cur_172 = Add(cur_172, c_174);
_cont175: ;
PostInc(ref i_173, 1D);
}
}
Invoke(@out_169, "push", cur_172);
return @out_169;
return default;
}, 2, "splitTop", false);
compound_23 = Fn((V _self176, int _argc177, V s_183, V _a180, V _a181, V _a182, V[] _rest178) => {
V p_184 = default;
V re_185 = default;
V m_186 = default;
p_184 = NewObj(4).Put("tag", V.Null).Put("id", V.Null).Put("cls", Arr()).Put("attrs", Arr()).V;
re_185 = NewRegExp(RX1, "([a-zA-Z][\\w-]*)|#([\\w-]+)|\\.([\\w-]+)|\\[\\s*([\\w:-]+)\\s*(?:([\\^$*~|]?=)\\s*(?:\"([^\"]*)\"|'([^']*)'|([^\\]\\s]*)))?\\s*\\]|(\\*)", "g");
while (Truthy((m_186 = Invoke(re_185, "exec", s_183)))) {
if (Truthy(GetIdx(m_186, 1D))) {
Set(p_184, "tag", Invoke(GetIdx(m_186, 1D), "toLowerCase"));
} else {
if (Truthy(GetIdx(m_186, 2D))) {
Set(p_184, "id", GetIdx(m_186, 2D));
} else {
if (Truthy(GetIdx(m_186, 3D))) {
Invoke(Get(p_184, "cls"), "push", GetIdx(m_186, 3D));
} else {
if (Truthy(GetIdx(m_186, 4D))) {
Invoke(Get(p_184, "attrs"), "push", NewObj(3).Put("name", GetIdx(m_186, 4D)).Put("op", (GetIdx(m_186, 5D) is var _t187 && Truthy(_t187) ? _t187 : V.Null)).Put("val", (!GetIdx(m_186, 6D).IsNullish ? GetIdx(m_186, 6D) : (!GetIdx(m_186, 7D).IsNullish ? GetIdx(m_186, 7D) : GetIdx(m_186, 8D)))).V);
}
}
}
}
}
return p_184;
return default;
}, 1, "compound", false);
matchCompound_24 = Fn((V _self188, int _argc189, V e_195, V p_196, V _a193, V _a194, V[] _rest190) => {
V c_197 = default;
V i_198 = default;
V j_199 = default;
V a_200 = default;
V v_201 = default;
if (Truthy((Get(p_196, "tag") is var _t202 && !Truthy(_t202) ? _t202 : (!SEq(Invoke(Get(e_195, "localName"), "toLowerCase"), Get(p_196, "tag")) ? V.True : V.False)))) {
return (false ? V.True : V.False);
}
if (Truthy((Get(p_196, "id") is var _t203 && !Truthy(_t203) ? _t203 : (!SEq(Invoke(e_195, "getAttribute", ((V)("id"))), Get(p_196, "id")) ? V.True : V.False)))) {
return (false ? V.True : V.False);
}
if (Truthy(Get(Get(p_196, "cls"), "length"))) {
c_197 = Invoke((Invoke(e_195, "getAttribute", ((V)("class"))) is var _t204 && Truthy(_t204) ? _t204 : ((V)(""))), "split", NewRegExp(RX2, "\\s+", ""));
{
i_198 = ((V)(0D));
while (true) {
if (!(Lt(i_198, Get(Get(p_196, "cls"), "length")))) break;
if (LtN(Invoke(c_197, "indexOf", GetK(Get(p_196, "cls"), i_198)), 0D)) {
return (false ? V.True : V.False);
}
PostInc(ref i_198, 1D);
}
}
}
{
j_199 = ((V)(0D));
while (true) {
if (!(Lt(j_199, Get(Get(p_196, "attrs"), "length")))) break;
a_200 = GetK(Get(p_196, "attrs"), j_199);
v_201 = Invoke(e_195, "getAttribute", Get(a_200, "name"));
if (SEq(v_201, V.Null)) {
return (false ? V.True : V.False);
}
if (!(Truthy(Get(a_200, "op")))) {
goto _cont206;
}
if ((SEqS(Get(a_200, "op"), "=") && !SEq(v_201, Get(a_200, "val")))) {
return (false ? V.True : V.False);
}
if ((SEqS(Get(a_200, "op"), "^=") && !SEqN(Invoke(v_201, "indexOf", Get(a_200, "val")), 0D))) {
return (false ? V.True : V.False);
}
if ((SEqS(Get(a_200, "op"), "$=") && !SEq(Invoke(v_201, "slice", ((V)((-ToNum(Get(Get(a_200, "val"), "length")))))), Get(a_200, "val")))) {
return (false ? V.True : V.False);
}
if ((SEqS(Get(a_200, "op"), "*=") && LtN(Invoke(v_201, "indexOf", Get(a_200, "val")), 0D))) {
return (false ? V.True : V.False);
}
if ((SEqS(Get(a_200, "op"), "~=") && LtN(Invoke(Invoke(v_201, "split", NewRegExp(RX2, "\\s+", "")), "indexOf", Get(a_200, "val")), 0D))) {
return (false ? V.True : V.False);
}
_cont206: ;
PostInc(ref j_199, 1D);
}
}
return (true ? V.True : V.False);
return default;
}, 2, "matchCompound", false);
matchSteps_25 = Fn((V _self207, int _argc208, V e_214, V steps_215, V k_216, V _a213, V[] _rest209) => {
V comb_217 = default;
V p_218 = default;
if (!(Truthy(Call(matchCompound_24, V.Undef, e_214, Get(GetK(steps_215, k_216), "parts"))))) {
return (false ? V.True : V.False);
}
if (SEqN(k_216, 0D)) {
return (true ? V.True : V.False);
}
comb_217 = Get(GetK(steps_215, k_216), "comb");
p_218 = Get(e_214, "parentNode");
if (SEqS(comb_217, ">")) {
return (((!(!(Truthy(p_218))) && SEqN(Get(p_218, "nodeType"), 1D)) ? V.True : V.False) is var _t219 && !Truthy(_t219) ? _t219 : Call(matchSteps_25, V.Undef, p_218, steps_215, ((V)((ToNum(k_216) - 1D)))));
}
while (Truthy((p_218 is var _t220 && !Truthy(_t220) ? _t220 : (SEqN(Get(p_218, "nodeType"), 1D) ? V.True : V.False)))) {
if (Truthy(Call(matchSteps_25, V.Undef, p_218, steps_215, ((V)((ToNum(k_216) - 1D)))))) {
return (true ? V.True : V.False);
}
p_218 = Get(p_218, "parentNode");
}
return (false ? V.True : V.False);
return default;
}, 3, "matchSteps", false);
matchesList_26 = Fn((V _self221, int _argc222, V e_228, V list_229, V _a226, V _a227, V[] _rest223) => {
V i_230 = default;
{
i_230 = ((V)(0D));
while (true) {
if (!(Lt(i_230, Get(list_229, "length")))) break;
if (Truthy(Call(matchSteps_25, V.Undef, e_228, GetK(list_229, i_230), ((V)((ToNum(Get(GetK(list_229, i_230), "length")) - 1D)))))) {
return (true ? V.True : V.False);
}
PostInc(ref i_230, 1D);
}
}
return (false ? V.True : V.False);
return default;
}, 2, "matchesList", false);
parseInto_30 = Fn((V _self232, int _argc233, V parent_239, V html_240, V ns_241, V _a238, V[] _rest234) => {
V stack_242 = default;
V i_243 = default;
V n_244 = default;
V lt_245 = default;
V t_246 = default;
V e_247 = default;
V e2_248 = default;
V e3_249 = default;
V name_250 = default;
V s_251 = default;
V m_252 = default;
V tag_253 = default;
V j_254 = default;
V el_255 = default;
V are_256 = default;
V selfClose_257 = default;
V am_258 = default;
stack_242 = Arr(parent_239);
i_243 = ((V)(0D));
n_244 = Get(html_240, "length");
while (Lt(i_243, n_244)) {
lt_245 = Invoke(html_240, "indexOf", ((V)("<")), i_243);
if (LtN(lt_245, 0D)) {
lt_245 = n_244;
}
if (Gt(lt_245, i_243)) {
t_246 = Invoke(html_240, "slice", i_243, lt_245);
if (Truthy((Invoke(t_246, "trim") is var _t259 && Truthy(_t259) ? _t259 : (GtN(Get(stack_242, "length"), 1D) ? V.True : V.False)))) {
Invoke(GetIdx(stack_242, (ToNum(Get(stack_242, "length")) - 1D)), "appendChild", New(Text_11, Call(unescape_29, V.Undef, t_246)));
}
}
if (Ge(lt_245, n_244)) {
break;
}
if (Truthy(Invoke(html_240, "startsWith", ((V)("<!--")), lt_245))) {
e_247 = Invoke(html_240, "indexOf", ((V)("-->")), Add(lt_245, ((V)(4D))));
i_243 = (LtN(e_247, 0D) ? n_244 : Add(e_247, ((V)(3D))));
continue;
}
if ((SEqS(GetK(html_240, Add(lt_245, ((V)(1D)))), "!") || SEqS(GetK(html_240, Add(lt_245, ((V)(1D)))), "?"))) {
e2_248 = Invoke(html_240, "indexOf", ((V)(">")), lt_245);
i_243 = (LtN(e2_248, 0D) ? n_244 : Add(e2_248, ((V)(1D))));
continue;
}
if (SEqS(GetK(html_240, Add(lt_245, ((V)(1D)))), "/")) {
e3_249 = Invoke(html_240, "indexOf", ((V)(">")), lt_245);
name_250 = Invoke(Invoke(html_240, "slice", Add(lt_245, ((V)(2D))), e3_249), "trim");
{
s_251 = ((V)((ToNum(Get(stack_242, "length")) - 1D)));
while (true) {
if (!(GtN(s_251, 0D))) break;
if ((SEq(Get(GetK(stack_242, s_251), "localName"), name_250) || SEq(Get(GetK(stack_242, s_251), "tagName"), name_250))) {
Set(stack_242, "length", s_251);
break;
}
PostInc(ref s_251, -1D);
}
}
i_243 = Add(e3_249, ((V)(1D)));
continue;
}
m_252 = Invoke(NewRegExp(RX3, "^<([a-zA-Z][\\w:.-]*)", ""), "exec", Invoke(html_240, "slice", lt_245, Add(lt_245, ((V)(64D)))));
if (!(Truthy(m_252))) {
Invoke(GetIdx(stack_242, (ToNum(Get(stack_242, "length")) - 1D)), "appendChild", New(Text_11, ((V)("<"))));
i_243 = Add(lt_245, ((V)(1D)));
continue;
}
tag_253 = GetIdx(m_252, 1D);
j_254 = Add(lt_245, Get(GetIdx(m_252, 0D), "length"));
el_255 = New(Element_18, tag_253, (SEqS(tag_253, "svg") ? SVG_NS_9 : (Get(GetIdx(stack_242, (ToNum(Get(stack_242, "length")) - 1D)), "namespaceURI") is var _t261 && Truthy(_t261) ? _t261 : ns_241)));
are_256 = NewRegExp(RX4, "\\s*([^\\s\"'>\\/=]+)(?:\\s*=\\s*(?:\"([^\"]*)\"|'([^']*)'|([^\\s\"'=<>`]+)))?|\\s*(\\/?)>", "g");
Set(are_256, "lastIndex", j_254);
selfClose_257 = (false ? V.True : V.False);
while (Truthy((am_258 = Invoke(are_256, "exec", html_240)))) {
if (!SEqN(Get(am_258, "index"), (ToNum(Get(are_256, "lastIndex")) - ToNum(Get(GetIdx(am_258, 0D), "length"))))) {
break;
}
if ((!SEq(GetIdx(am_258, 5D), V.Undef) && SEqS(Invoke(Invoke(GetIdx(am_258, 0D), "trim"), "slice", ((V)((-1D)))), ">"))) {
selfClose_257 = (SEqS(GetIdx(am_258, 5D), "/") ? V.True : V.False);
j_254 = Get(are_256, "lastIndex");
break;
}
Invoke(el_255, "setAttribute", GetIdx(am_258, 1D), Call(unescape_29, V.Undef, (!GetIdx(am_258, 2D).IsNullish ? GetIdx(am_258, 2D) : (!GetIdx(am_258, 3D).IsNullish ? GetIdx(am_258, 3D) : (!GetIdx(am_258, 4D).IsNullish ? GetIdx(am_258, 4D) : ((V)("")))))));
j_254 = Get(are_256, "lastIndex");
}
Invoke(GetIdx(stack_242, (ToNum(Get(stack_242, "length")) - 1D)), "appendChild", el_255);
i_243 = j_254;
if ((!(Truthy(selfClose_257)) && !(Truthy(((!SEq(Get(el_255, "namespaceURI"), SVG_NS_9) ? V.True : V.False) is var _t262 && !Truthy(_t262) ? _t262 : GetK(VOID_HTML_27, Invoke(tag_253, "toLowerCase"))))))) {
Invoke(stack_242, "push", el_255);
}
}
return default;
}, 3, "parseInto", false);
serialize_33 = Fn(Dom.SerializeFn, 1, "serialize", false);
SVGRect_35 = Fn((V _self263, int _argc264, V x_270, V y_271, V w_272, V h_273, V[] _rest265) => {
Set(_self263, "_r", Arr(x_270, y_271, w_272, h_273));
return default;
}, 4, "SVGRect", false);
bbox_36 = Fn((V _self274, int _argc275, V el_281, V _a278, V _a279, V _a280, V[] _rest276) => {
V r_282 = default;
V o_283 = default;
r_282 = Call(boxOf_57, V.Undef, el_281);
o_283 = Object_create(Get(SVGRect_35, "prototype"));
Object_defineProperty(o_283, ((V)("_r")), NewObj(3).Put("value", (Truthy(r_282) ? Arr(Get(r_282, "x"), Get(r_282, "y"), Get(r_282, "w"), Get(r_282, "h")) : Arr(((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(0D))))).Put("writable", (true ? V.True : V.False)).Put("enumerable", (false ? V.True : V.False)).V);
return o_283;
return default;
}, 1, "bbox", false);
rect_37 = Fn((V _self284, int _argc285, V x_291, V y_292, V w_293, V h_294, V[] _rest286) => {
return NewObj(4).Put("x", Call(F_34, V.Undef, x_291)).Put("y", Call(F_34, V.Undef, y_292)).Put("w", Call(F_34, V.Undef, w_293)).Put("h", Call(F_34, V.Undef, h_294)).V;
return default;
}, 4, "rect", false);
nextUp_40 = Fn((V _self295, int _argc296, V v_302, V _a299, V _a300, V _a301, V[] _rest297) => {
if ((!SEq(v_302, v_302) || SEqN(v_302, double.PositiveInfinity))) {
return v_302;
}
if (SEqN(v_302, 0D)) {
return Call(F_34, V.Undef, ((V)(1.401298464324817e-45)));
}
SetIdx(F32_38, 0D, v_302);
OpSetK(U32_39, ((V)(0D)), 0, ((V)((GtN(v_302, 0D) ? 1D : (-1D)))));
return GetIdx(F32_38, 0D);
return default;
}, 1, "nextUp", false);
fromBounds_41 = Fn((V _self303, int _argc304, V l_310, V t_311, V r_312, V b_313, V[] _rest305) => {
V w_314 = default;
V h_315 = default;
w_314 = Call(F_34, V.Undef, ((V)((ToNum(r_312) - ToNum(l_310)))));
h_315 = Call(F_34, V.Undef, ((V)((ToNum(b_313) - ToNum(t_311)))));
if (Lt(Call(F_34, V.Undef, Add(l_310, w_314)), r_312)) {
w_314 = Call(nextUp_40, V.Undef, w_314);
}
if (Lt(Call(F_34, V.Undef, Add(t_311, h_315)), b_313)) {
h_315 = Call(nextUp_40, V.Undef, h_315);
}
return NewObj(4).Put("x", l_310).Put("y", t_311).Put("w", w_314).Put("h", h_315).V;
return default;
}, 4, "fromBounds", false);
unite_42 = Fn((V _self316, int _argc317, V a_323, V b_324, V _a321, V _a322, V[] _rest318) => {
V x0_325 = default;
V y0_326 = default;
V x1_327 = default;
V y1_328 = default;
if (!(Truthy(a_323))) {
return b_324;
}
if (!(Truthy(b_324))) {
return a_323;
}
x0_325 = ((V)(Min(ToNum(Get(a_323, "x")), ToNum(Get(b_324, "x")))));
y0_326 = ((V)(Min(ToNum(Get(a_323, "y")), ToNum(Get(b_324, "y")))));
x1_327 = ((V)(Max(ToNum(Call(F_34, V.Undef, Add(Get(a_323, "x"), Get(a_323, "w")))), ToNum(Call(F_34, V.Undef, Add(Get(b_324, "x"), Get(b_324, "w")))))));
y1_328 = ((V)(Max(ToNum(Call(F_34, V.Undef, Add(Get(a_323, "y"), Get(a_323, "h")))), ToNum(Call(F_34, V.Undef, Add(Get(b_324, "y"), Get(b_324, "h")))))));
return Call(fromBounds_41, V.Undef, x0_325, y0_326, x1_327, y1_328);
return default;
}, 2, "unite", false);
mapRect_43 = Fn((V _self329, int _argc330, V m_336, V r_337, V _a334, V _a335, V[] _rest331) => {
V xs_338 = default;
V ys_339 = default;
V pts_340 = default;
V i_341 = default;
V x0_342 = default;
V y0_343 = default;
V x1_344 = default;
V y1_345 = default;
if (!(Truthy(m_336))) {
return r_337;
}
xs_338 = Arr();
ys_339 = Arr();
pts_340 = Arr(Arr(Get(r_337, "x"), Get(r_337, "y")), Arr(Call(F_34, V.Undef, Add(Get(r_337, "x"), Get(r_337, "w"))), Get(r_337, "y")), Arr(Call(F_34, V.Undef, Add(Get(r_337, "x"), Get(r_337, "w"))), Call(F_34, V.Undef, Add(Get(r_337, "y"), Get(r_337, "h")))), Arr(Get(r_337, "x"), Call(F_34, V.Undef, Add(Get(r_337, "y"), Get(r_337, "h")))));
{
i_341 = ((V)(0D));
while (true) {
if (!(LtN(i_341, 4D))) break;
Invoke(xs_338, "push", Call(F_34, V.Undef, Add(((V)(((ToNum(GetIdx(m_336, 0D)) * ToNum(GetIdx(GetK(pts_340, i_341), 0D))) + (ToNum(GetIdx(m_336, 2D)) * ToNum(GetIdx(GetK(pts_340, i_341), 1D)))))), GetIdx(m_336, 4D))));
Invoke(ys_339, "push", Call(F_34, V.Undef, Add(((V)(((ToNum(GetIdx(m_336, 1D)) * ToNum(GetIdx(GetK(pts_340, i_341), 0D))) + (ToNum(GetIdx(m_336, 3D)) * ToNum(GetIdx(GetK(pts_340, i_341), 1D)))))), GetIdx(m_336, 5D))));
PostInc(ref i_341, 1D);
}
}
x0_342 = Invoke(Get(G("Math"), "min"), "apply", V.Null, xs_338);
y0_343 = Invoke(Get(G("Math"), "min"), "apply", V.Null, ys_339);
x1_344 = Invoke(Get(G("Math"), "max"), "apply", V.Null, xs_338);
y1_345 = Invoke(Get(G("Math"), "max"), "apply", V.Null, ys_339);
return Call(fromBounds_41, V.Undef, x0_342, y0_343, x1_344, y1_345);
return default;
}, 2, "mapRect", false);
validUnitDivide_44 = Fn((V _self347, int _argc348, V n_354, V d_355, V _a352, V _a353, V[] _rest349) => {
V r_356 = default;
if (LtN(n_354, 0D)) {
n_354 = ((V)((-ToNum(n_354))));
d_355 = ((V)((-ToNum(d_355))));
}
if (((SEqN(d_355, 0D) || SEqN(n_354, 0D)) || Ge(n_354, d_355))) {
return V.Null;
}
r_356 = Call(F_34, V.Undef, ((V)((ToNum(n_354) / ToNum(d_355)))));
return ((!SEq(r_356, r_356) || SEqN(r_356, 0D)) ? V.Null : r_356);
return default;
}, 2, "validUnitDivide", false);
unitQuadRoots_45 = Fn((V _self357, int _argc358, V A_364, V B_365, V C_366, V _a363, V[] _rest359) => {
V r0_367 = default;
V dr_368 = default;
V R_369 = default;
V Q_370 = default;
V @out_371 = default;
V a_372 = default;
V b_373 = default;
if (SEqN(A_364, 0D)) {
r0_367 = Call(validUnitDivide_44, V.Undef, ((V)((-ToNum(C_366)))), B_365);
return (SEq(r0_367, V.Null) ? Arr() : Arr(r0_367));
}
dr_368 = ((V)(((ToNum(B_365) * ToNum(B_365)) - ((4D * ToNum(A_364)) * ToNum(C_366)))));
if (LtN(dr_368, 0D)) {
return Arr();
}
R_369 = Call(F_34, V.Undef, ((V)(System.Math.Sqrt(ToNum(dr_368)))));
if (!(IsFiniteV(R_369))) {
return Arr();
}
Q_370 = (LtN(B_365, 0D) ? Call(F_34, V.Undef, ((V)((-ToNum(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, ((V)((ToNum(B_365) - ToNum(R_369)))))) / 2D))))))))) : Call(F_34, V.Undef, ((V)((-ToNum(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, Add(B_365, R_369))) / 2D))))))))));
@out_371 = Arr();
a_372 = Call(validUnitDivide_44, V.Undef, Q_370, A_364);
b_373 = Call(validUnitDivide_44, V.Undef, C_366, Q_370);
if (!SEq(a_372, V.Null)) {
Invoke(@out_371, "push", a_372);
}
if (!SEq(b_373, V.Null)) {
Invoke(@out_371, "push", b_373);
}
if (SEqN(Get(@out_371, "length"), 2D)) {
if (Gt(GetIdx(@out_371, 0D), GetIdx(@out_371, 1D))) {
Invoke(@out_371, "reverse");
} else {
if (SEq(GetIdx(@out_371, 0D), GetIdx(@out_371, 1D))) {
Invoke(@out_371, "pop");
}
}
}
return @out_371;
return default;
}, 3, "unitQuadRoots", false);
cubicExtremaT_46 = Fn((V _self374, int _argc375, V a_381, V b_382, V c_383, V d_384, V[] _rest376) => {
return Call(unitQuadRoots_45, V.Undef, Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(d_384) - ToNum(a_381))))), Call(F_34, V.Undef, ((V)((3D * ToNum(Call(F_34, V.Undef, ((V)((ToNum(b_382) - ToNum(c_383)))))))))))), Call(F_34, V.Undef, ((V)((2D * ToNum(Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, ((V)((ToNum(a_381) - ToNum(b_382)))))) - ToNum(b_382))))), c_383))))))), Call(F_34, V.Undef, ((V)((ToNum(b_382) - ToNum(a_381))))));
return default;
}, 4, "cubicExtremaT", false);
evalCubic_47 = Fn((V _self385, int _argc386, V p_392, V t_393, V k_394, V _a391, V[] _rest387) => {
V P0_395 = default;
V P1_396 = default;
V P2_397 = default;
V P3_398 = default;
V A_399 = default;
V B_400 = default;
V C_401 = default;
P0_395 = GetK(GetIdx(p_392, 0D), k_394);
P1_396 = GetK(GetIdx(p_392, 1D), k_394);
P2_397 = GetK(GetIdx(p_392, 2D), k_394);
P3_398 = GetK(GetIdx(p_392, 3D), k_394);
A_399 = Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, Add(P3_398, Call(F_34, V.Undef, ((V)((3D * ToNum(Call(F_34, V.Undef, ((V)((ToNum(P1_396) - ToNum(P2_397))))))))))))) - ToNum(P0_395)))));
B_400 = Call(F_34, V.Undef, ((V)((3D * ToNum(Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(P2_397) - ToNum(Call(F_34, V.Undef, ((V)((2D * ToNum(P1_396)))))))))), P0_395)))))));
C_401 = Call(F_34, V.Undef, ((V)((3D * ToNum(Call(F_34, V.Undef, ((V)((ToNum(P1_396) - ToNum(P0_395))))))))));
return Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(A_399) * ToNum(t_393))))), B_400))) * ToNum(t_393))))), C_401))) * ToNum(t_393))))), P0_395));
return default;
}, 3, "evalCubic", false);
rotM_52 = Fn((V _self402, int _argc403, V deg_409, V _a406, V _a407, V _a408, V[] _rest404) => {
V rad_410 = default;
rad_410 = Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, deg_409)) * ToNum(DEG_51)))));
return Arr(Call(COSZ_49, V.Undef, rad_410), Call(SINZ_48, V.Undef, rad_410));
return default;
}, 1, "rotM", false);
arcToConics_53 = Fn((V _self411, int _argc412, V cur_418, V rx_419, V ry_420, V angle_421, V[] _rest413) => {
V mdx_425 = default;
V mdy_426 = default;
V r1_427 = default;
V tmx_428 = default;
V tmy_429 = default;
V srx_430 = default;
V sry_431 = default;
V sx_432 = default;
V sy_433 = default;
V rs_434 = default;
V irx_435 = default;
V iry_436 = default;
V USX_437 = default;
V UKX_438 = default;
V UKY_439 = default;
V USY_440 = default;
V mapU_441 = default;
V u0_442 = default;
V u1_443 = default;
V dx_444 = default;
V dy_445 = default;
V dd_446 = default;
V sfs_447 = default;
V sf_448 = default;
V ccw_449 = default;
V cx_450 = default;
V cy_451 = default;
V a0x_452 = default;
V a0y_453 = default;
V a1x_454 = default;
V a1y_455 = default;
V th1_456 = default;
V th2_457 = default;
V arc_458 = default;
V PI2_459 = default;
V r2m_460 = default;
V BSX_461 = default;
V BKY_462 = default;
V BKX_463 = default;
V BSY_464 = default;
V mapB_465 = default;
V segs_466 = default;
V tw_467 = default;
V t_468 = default;
V w_469 = default;
V isInt_470 = default;
V expectInts_471 = default;
V @out_472 = default;
V st_473 = default;
V i_474 = default;
V et_475 = default;
V se_476 = default;
V ce_477 = default;
V p1_478 = default;
V p0_479 = default;
V m0_480 = default;
V m1_481 = default;
V large_422 = default;
V sweep_423 = default;
V to_424 = default;
large_422 = (_argc412 > 4 ? _rest413[0] : V.Undef);
sweep_423 = (_argc412 > 5 ? _rest413[1] : V.Undef);
to_424 = (_argc412 > 6 ? _rest413[2] : V.Undef);
if ((!(Truthy(rx_419)) || !(Truthy(ry_420)))) {
return V.Null;
}
if ((SEq(GetIdx(cur_418, 0D), GetIdx(to_424, 0D)) && SEq(GetIdx(cur_418, 1D), GetIdx(to_424, 1D)))) {
return V.Null;
}
rx_419 = Call(F_34, V.Undef, ((V)(System.Math.Abs(ToNum(rx_419)))));
ry_420 = Call(F_34, V.Undef, ((V)(System.Math.Abs(ToNum(ry_420)))));
mdx_425 = Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, ((V)((ToNum(GetIdx(cur_418, 0D)) - ToNum(GetIdx(to_424, 0D))))))) * 0.5))));
mdy_426 = Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, ((V)((ToNum(GetIdx(cur_418, 1D)) - ToNum(GetIdx(to_424, 1D))))))) * 0.5))));
r1_427 = Call(rotM_52, V.Undef, ((V)((-ToNum(angle_421)))));
tmx_428 = Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(mdx_425) * ToNum(GetIdx(r1_427, 0D)))))), Call(F_34, V.Undef, ((V)((ToNum(mdy_426) * (-ToNum(GetIdx(r1_427, 1D)))))))));
tmy_429 = Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(mdy_426) * ToNum(GetIdx(r1_427, 0D)))))), Call(F_34, V.Undef, ((V)((ToNum(mdx_425) * ToNum(GetIdx(r1_427, 1D))))))));
if ((SEqN(GetIdx(r1_427, 1D), 0D) && SEqN(GetIdx(r1_427, 0D), 1D))) {
tmx_428 = mdx_425;
tmy_429 = mdy_426;
}
srx_430 = Call(F_34, V.Undef, ((V)((ToNum(rx_419) * ToNum(rx_419)))));
sry_431 = Call(F_34, V.Undef, ((V)((ToNum(ry_420) * ToNum(ry_420)))));
sx_432 = Call(F_34, V.Undef, ((V)((ToNum(tmx_428) * ToNum(tmx_428)))));
sy_433 = Call(F_34, V.Undef, ((V)((ToNum(tmy_429) * ToNum(tmy_429)))));
rs_434 = Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(sx_432) / ToNum(srx_430))))), Call(F_34, V.Undef, ((V)((ToNum(sy_433) / ToNum(sry_431)))))));
if (GtN(rs_434, 1D)) {
rs_434 = Call(F_34, V.Undef, ((V)(System.Math.Sqrt(ToNum(rs_434)))));
rx_419 = Call(F_34, V.Undef, ((V)((ToNum(rx_419) * ToNum(rs_434)))));
ry_420 = Call(F_34, V.Undef, ((V)((ToNum(ry_420) * ToNum(rs_434)))));
}
irx_435 = Call(F_34, V.Undef, ((V)((1D / ToNum(rx_419)))));
iry_436 = Call(F_34, V.Undef, ((V)((1D / ToNum(ry_420)))));
USX_437 = Call(F_34, V.Undef, ((V)((ToNum(irx_435) * ToNum(GetIdx(r1_427, 0D))))));
UKX_438 = Call(F_34, V.Undef, ((V)((ToNum(irx_435) * (-ToNum(GetIdx(r1_427, 1D)))))));
UKY_439 = Call(F_34, V.Undef, ((V)((ToNum(iry_436) * ToNum(GetIdx(r1_427, 1D))))));
USY_440 = Call(F_34, V.Undef, ((V)((ToNum(iry_436) * ToNum(GetIdx(r1_427, 0D))))));
mapU_441 = Fn((V _self482, int _argc483, V p_489, V _a486, V _a487, V _a488, V[] _rest484) => {
if ((SEqN(GetIdx(r1_427, 1D), 0D) && SEqN(GetIdx(r1_427, 0D), 1D))) {
return Arr(Call(F_34, V.Undef, ((V)((ToNum(GetIdx(p_489, 0D)) * ToNum(irx_435))))), Call(F_34, V.Undef, ((V)((ToNum(GetIdx(p_489, 1D)) * ToNum(iry_436))))));
}
return Arr(Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(GetIdx(p_489, 0D)) * ToNum(USX_437))))), Call(F_34, V.Undef, ((V)((ToNum(GetIdx(p_489, 1D)) * ToNum(UKX_438))))))), Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(GetIdx(p_489, 1D)) * ToNum(USY_440))))), Call(F_34, V.Undef, ((V)((ToNum(GetIdx(p_489, 0D)) * ToNum(UKY_439))))))));
return default;
}, 1, "", false);
u0_442 = Call(mapU_441, V.Undef, cur_418);
u1_443 = Call(mapU_441, V.Undef, to_424);
dx_444 = Call(F_34, V.Undef, ((V)((ToNum(GetIdx(u1_443, 0D)) - ToNum(GetIdx(u0_442, 0D))))));
dy_445 = Call(F_34, V.Undef, ((V)((ToNum(GetIdx(u1_443, 1D)) - ToNum(GetIdx(u0_442, 1D))))));
dd_446 = Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(dx_444) * ToNum(dx_444))))), Call(F_34, V.Undef, ((V)((ToNum(dy_445) * ToNum(dy_445)))))));
sfs_447 = ((V)(Max(ToNum(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, ((V)((1D / ToNum(dd_446)))))) - 0.25))))), 0D)));
sf_448 = Call(F_34, V.Undef, ((V)(System.Math.Sqrt(ToNum(sfs_447)))));
ccw_449 = (!(Truthy(sweep_423)) ? V.True : V.False);
if (!SEq(ccw_449, (!(!(Truthy(large_422))) ? V.True : V.False))) {
sf_448 = ((V)((-ToNum(sf_448))));
}
dx_444 = Call(F_34, V.Undef, ((V)((ToNum(dx_444) * ToNum(sf_448)))));
dy_445 = Call(F_34, V.Undef, ((V)((ToNum(dy_445) * ToNum(sf_448)))));
cx_450 = Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, Add(GetIdx(u0_442, 0D), GetIdx(u1_443, 0D)))) * 0.5))))) - ToNum(dy_445)))));
cy_451 = Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, Add(GetIdx(u0_442, 1D), GetIdx(u1_443, 1D)))) * 0.5)))), dx_444));
a0x_452 = Call(F_34, V.Undef, ((V)((ToNum(GetIdx(u0_442, 0D)) - ToNum(cx_450)))));
a0y_453 = Call(F_34, V.Undef, ((V)((ToNum(GetIdx(u0_442, 1D)) - ToNum(cy_451)))));
a1x_454 = Call(F_34, V.Undef, ((V)((ToNum(GetIdx(u1_443, 0D)) - ToNum(cx_450)))));
a1y_455 = Call(F_34, V.Undef, ((V)((ToNum(GetIdx(u1_443, 1D)) - ToNum(cy_451)))));
th1_456 = Call(F_34, V.Undef, ((V)(FdLibm.Atan2(ToNum(a0y_453), ToNum(a0x_452)))));
th2_457 = Call(F_34, V.Undef, ((V)(FdLibm.Atan2(ToNum(a1y_455), ToNum(a1x_454)))));
arc_458 = Call(F_34, V.Undef, ((V)((ToNum(th2_457) - ToNum(th1_456)))));
PI2_459 = Call(F_34, V.Undef, ((V)((ToNum(PIF_50) * 2D))));
if (Truthy(((LtN(arc_458, 0D) ? V.True : V.False) is var _t490 && !Truthy(_t490) ? _t490 : sweep_423))) {
arc_458 = Call(F_34, V.Undef, Add(arc_458, PI2_459));
} else {
if ((GtN(arc_458, 0D) && !(Truthy(sweep_423)))) {
arc_458 = Call(F_34, V.Undef, ((V)((ToNum(arc_458) - ToNum(PI2_459)))));
}
}
if (Lt(((V)(System.Math.Abs(ToNum(arc_458)))), Call(F_34, V.Undef, ((V)((ToNum(PIF_50) / (1000D * 1000D))))))) {
return V.Null;
}
r2m_460 = Call(rotM_52, V.Undef, angle_421);
BSX_461 = Call(F_34, V.Undef, ((V)((ToNum(GetIdx(r2m_460, 0D)) * ToNum(rx_419)))));
BKY_462 = Call(F_34, V.Undef, ((V)((ToNum(GetIdx(r2m_460, 1D)) * ToNum(rx_419)))));
BKX_463 = Call(F_34, V.Undef, ((V)(((-ToNum(GetIdx(r2m_460, 1D))) * ToNum(ry_420)))));
BSY_464 = Call(F_34, V.Undef, ((V)((ToNum(GetIdx(r2m_460, 0D)) * ToNum(ry_420)))));
mapB_465 = Fn((V _self491, int _argc492, V p_498, V _a495, V _a496, V _a497, V[] _rest493) => {
if ((SEqN(GetIdx(r2m_460, 1D), 0D) && SEqN(GetIdx(r2m_460, 0D), 1D))) {
return Arr(Call(F_34, V.Undef, ((V)((ToNum(GetIdx(p_498, 0D)) * ToNum(rx_419))))), Call(F_34, V.Undef, ((V)((ToNum(GetIdx(p_498, 1D)) * ToNum(ry_420))))));
}
return Arr(Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(GetIdx(p_498, 0D)) * ToNum(BSX_461))))), Call(F_34, V.Undef, ((V)((ToNum(GetIdx(p_498, 1D)) * ToNum(BKX_463))))))), Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(GetIdx(p_498, 1D)) * ToNum(BSY_464))))), Call(F_34, V.Undef, ((V)((ToNum(GetIdx(p_498, 0D)) * ToNum(BKY_462))))))));
return default;
}, 1, "", false);
segs_466 = ((V)(System.Math.Ceiling(System.Math.Abs(ToNum(Call(F_34, V.Undef, ((V)((ToNum(arc_458) / ToNum(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, ((V)((2D * ToNum(PIF_50)))))) / 3D))))))))))))));
tw_467 = Call(F_34, V.Undef, ((V)((ToNum(arc_458) / ToNum(segs_466)))));
t_468 = Call(F_34, V.Undef, ((V)(FdLibm.Tan(ToNum(Call(F_34, V.Undef, ((V)((0.5 * ToNum(tw_467))))))))));
if (!(IsFiniteV(t_468))) {
return Arr();
}
w_469 = Call(F_34, V.Undef, ((V)(System.Math.Sqrt(ToNum(Call(F_34, V.Undef, Add(((V)(0.5)), Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, ((V)(FdLibm.Cos(ToNum(tw_467)))))) * 0.5)))))))))));
isInt_470 = Fn((V _self499, int _argc500, V v_506, V _a503, V _a504, V _a505, V[] _rest501) => {
return (SEqN(v_506, System.Math.Floor(ToNum(v_506))) ? V.True : V.False);
return default;
}, 1, "", false);
expectInts_471 = (((((Le(((V)(System.Math.Abs(ToNum(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, ((V)((ToNum(PIF_50) / 2D))))) - System.Math.Abs(ToNum(tw_467)))))))))), Call(F_34, V.Undef, ((V)((1D / 4096D))))) ? V.True : V.False) is var _t507 && !Truthy(_t507) ? _t507 : Call(isInt_470, V.Undef, rx_419)) is var _t508 && !Truthy(_t508) ? _t508 : Call(isInt_470, V.Undef, ry_420)) is var _t509 && !Truthy(_t509) ? _t509 : Call(isInt_470, V.Undef, GetIdx(to_424, 0D))) is var _t510 && !Truthy(_t510) ? _t510 : Call(isInt_470, V.Undef, GetIdx(to_424, 1D)));
@out_472 = Arr();
st_473 = th1_456;
{
i_474 = ((V)(0D));
while (true) {
if (!(Lt(i_474, segs_466))) break;
et_475 = Call(F_34, V.Undef, Add(st_473, tw_467));
se_476 = Call(SINZ_48, V.Undef, et_475);
ce_477 = Call(COSZ_49, V.Undef, et_475);
p1_478 = Arr(Call(F_34, V.Undef, Add(ce_477, cx_450)), Call(F_34, V.Undef, Add(se_476, cy_451)));
p0_479 = Arr(Call(F_34, V.Undef, Add(GetIdx(p1_478, 0D), Call(F_34, V.Undef, ((V)((ToNum(t_468) * ToNum(se_476))))))), Call(F_34, V.Undef, ((V)((ToNum(GetIdx(p1_478, 1D)) - ToNum(Call(F_34, V.Undef, ((V)((ToNum(t_468) * ToNum(ce_477)))))))))));
m0_480 = Call(mapB_465, V.Undef, p0_479);
m1_481 = Call(mapB_465, V.Undef, p1_478);
if (Truthy(expectInts_471)) {
m0_480 = Arr(((V)(Round(ToNum(GetIdx(m0_480, 0D))))), ((V)(Round(ToNum(GetIdx(m0_480, 1D))))));
m1_481 = Arr(((V)(Round(ToNum(GetIdx(m1_481, 0D))))), ((V)(Round(ToNum(GetIdx(m1_481, 1D))))));
}
Invoke(@out_472, "push", Arr(m0_480, m1_481, w_469));
st_473 = et_475;
PostInc(ref i_474, 1D);
}
}
if (Truthy(Get(@out_472, "length"))) {
SetIdx(GetIdx(@out_472, (ToNum(Get(@out_472, "length")) - 1D)), 1D, Arr(GetIdx(to_424, 0D), GetIdx(to_424, 1D)));
}
return @out_472;
return default;
}, 7, "arcToConics", false);
conicExtremaT_54 = Fn((V _self512, int _argc513, V a_519, V b_520, V c_521, V w_522, V[] _rest514) => {
V P20_523 = default;
V P10_524 = default;
V wP10_525 = default;
V r_526 = default;
P20_523 = Call(F_34, V.Undef, ((V)((ToNum(c_521) - ToNum(a_519)))));
P10_524 = Call(F_34, V.Undef, ((V)((ToNum(b_520) - ToNum(a_519)))));
wP10_525 = Call(F_34, V.Undef, ((V)((ToNum(w_522) * ToNum(P10_524)))));
r_526 = Call(unitQuadRoots_45, V.Undef, Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, ((V)((ToNum(w_522) * ToNum(P20_523)))))) - ToNum(P20_523))))), Call(F_34, V.Undef, ((V)((ToNum(P20_523) - ToNum(Call(F_34, V.Undef, ((V)((2D * ToNum(wP10_525)))))))))), wP10_525);
return (SEqN(Get(r_526, "length"), 1D) ? r_526 : Arr());
return default;
}, 4, "conicExtremaT", false);
evalConic_55 = Fn((V _self527, int _argc528, V p_534, V w_535, V t_536, V k_537, V[] _rest529) => {
V p0_538 = default;
V p1w_539 = default;
V p2_540 = default;
V nA_541 = default;
V nB_542 = default;
V dB_543 = default;
V dA_544 = default;
V num_545 = default;
V den_546 = default;
p0_538 = GetK(GetIdx(p_534, 0D), k_537);
p1w_539 = Call(F_34, V.Undef, ((V)((ToNum(GetK(GetIdx(p_534, 1D), k_537)) * ToNum(w_535)))));
p2_540 = GetK(GetIdx(p_534, 2D), k_537);
nA_541 = Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(p2_540) - ToNum(Call(F_34, V.Undef, ((V)((2D * ToNum(p1w_539)))))))))), p0_538));
nB_542 = Call(F_34, V.Undef, ((V)((2D * ToNum(Call(F_34, V.Undef, ((V)((ToNum(p1w_539) - ToNum(p0_538))))))))));
dB_543 = Call(F_34, V.Undef, ((V)((2D * ToNum(Call(F_34, V.Undef, ((V)((ToNum(w_535) - 1D)))))))));
dA_544 = Call(F_34, V.Undef, ((V)((0D - ToNum(dB_543)))));
num_545 = Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(nA_541) * ToNum(t_536))))), nB_542))) * ToNum(t_536))))), p0_538));
den_546 = Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(dA_544) * ToNum(t_536))))), dB_543))) * ToNum(t_536))))), ((V)(1D))));
return Call(F_34, V.Undef, ((V)((ToNum(num_545) / ToNum(den_546)))));
return default;
}, 4, "evalConic", false);
pathTight_56 = Fn((V _self547, int _argc548, V d_554, V _a551, V _a552, V _a553, V[] _rest549) => {
V tk_555 = default;
V i_556 = default;
V cmd_557 = default;
V cur_558 = default;
V start_559 = default;
V lastC_560 = default;
V lastQ_561 = default;
V segs_562 = default;
V n_563 = default;
V abs_564 = default;
V C_565 = default;
V rel_566 = default;
V p_567 = default;
V hx_568 = default;
V vy_569 = default;
V c1_570 = default;
V c2_571 = default;
V e_572 = default;
V qc_573 = default;
V qe_574 = default;
V rx_575 = default;
V ry_576 = default;
V ang_577 = default;
V lg_578 = default;
V sw_579 = default;
V to_580 = default;
V conics_581 = default;
V from_582 = default;
V k_583 = default;
V first_584 = default;
V x0_585 = default;
V y0_586 = default;
V x1_587 = default;
V y1_588 = default;
V add_589 = default;
V s2_590 = default;
V g_591 = default;
V kts_592 = default;
V jk_593 = default;
V qts_594 = default;
V qa_595 = default;
V qb_596 = default;
V jq_597 = default;
V tq_598 = default;
V ev_599 = default;
V ts_600 = default;
V j_601 = default;
tk_555 = (Invoke(d_554, "match", NewRegExp(RX5, "[a-zA-Z]|[-+]?(?:\\d*\\.\\d+|\\d+\\.?)(?:[eE][-+]?\\d+)?", "g")) is var _t602 && Truthy(_t602) ? _t602 : Arr());
i_556 = ((V)(0D));
cmd_557 = ((V)(""));
cur_558 = Arr(((V)(0D)), ((V)(0D)));
start_559 = Arr(((V)(0D)), ((V)(0D)));
lastC_560 = V.Null;
lastQ_561 = V.Null;
segs_562 = Arr();
n_563 = Fn((V _self603, int _argc604, V _a606, V _a607, V _a608, V _a609, V[] _rest605) => {
return Call(F_34, V.Undef, ((V)(ToNum(GetIdx(tk_555, PostInc(ref i_556, 1D))))));
return default;
}, 0, "", false);
abs_564 = Fn((V _self610, int _argc611, V rel_617, V x_618, V y_619, V _a616, V[] _rest612) => {
return (Truthy(rel_617) ? Arr(Call(F_34, V.Undef, Add(GetIdx(cur_558, 0D), x_618)), Call(F_34, V.Undef, Add(GetIdx(cur_558, 1D), y_619))) : Arr(x_618, y_619));
return default;
}, 3, "", false);
while (Lt(i_556, Get(tk_555, "length"))) {
if (Truthy(Invoke(NewRegExp(RX6, "[a-zA-Z]", ""), "test", GetK(tk_555, i_556)))) {
cmd_557 = GetIdx(tk_555, PostInc(ref i_556, 1D));
}
C_565 = Invoke(cmd_557, "toUpperCase");
rel_566 = (!SEq(cmd_557, C_565) ? V.True : V.False);
if (SEqS(C_565, "Z")) {
Invoke(segs_562, "push", NewObj(1).Put("v", ((V)("Z"))).V);
cur_558 = start_559;
lastC_560 = (lastQ_561 = V.Null);
if ((Lt(i_556, Get(tk_555, "length")) && !(Truthy(Invoke(NewRegExp(RX6, "[a-zA-Z]", ""), "test", GetK(tk_555, i_556)))))) {
PostInc(ref i_556, 1D);
}
continue;
}
if (Ge(i_556, Get(tk_555, "length"))) {
break;
}
if (SEqS(C_565, "M")) {
p_567 = Call(abs_564, V.Undef, rel_566, Call(n_563, V.Undef), Call(n_563, V.Undef));
Invoke(segs_562, "push", NewObj(2).Put("v", ((V)("M"))).Put("p", Arr(p_567)).V);
cur_558 = (start_559 = p_567);
cmd_557 = ((V)((Truthy(rel_566) ? "l" : "L")));
lastC_560 = (lastQ_561 = V.Null);
continue;
}
if (SEqS(C_565, "L")) {
p_567 = Call(abs_564, V.Undef, rel_566, Call(n_563, V.Undef), Call(n_563, V.Undef));
Invoke(segs_562, "push", NewObj(2).Put("v", ((V)("L"))).Put("p", Arr(cur_558, p_567)).V);
cur_558 = p_567;
lastC_560 = (lastQ_561 = V.Null);
continue;
}
if (SEqS(C_565, "H")) {
hx_568 = Call(n_563, V.Undef);
p_567 = Arr((Truthy(rel_566) ? Call(F_34, V.Undef, Add(GetIdx(cur_558, 0D), hx_568)) : hx_568), GetIdx(cur_558, 1D));
Invoke(segs_562, "push", NewObj(2).Put("v", ((V)("L"))).Put("p", Arr(cur_558, p_567)).V);
cur_558 = p_567;
lastC_560 = (lastQ_561 = V.Null);
continue;
}
if (SEqS(C_565, "V")) {
vy_569 = Call(n_563, V.Undef);
p_567 = Arr(GetIdx(cur_558, 0D), (Truthy(rel_566) ? Call(F_34, V.Undef, Add(GetIdx(cur_558, 1D), vy_569)) : vy_569));
Invoke(segs_562, "push", NewObj(2).Put("v", ((V)("L"))).Put("p", Arr(cur_558, p_567)).V);
cur_558 = p_567;
lastC_560 = (lastQ_561 = V.Null);
continue;
}
if ((SEqS(C_565, "C") || SEqS(C_565, "S"))) {

if (SEqS(C_565, "C")) {
c1_570 = Call(abs_564, V.Undef, rel_566, Call(n_563, V.Undef), Call(n_563, V.Undef));
} else {
c1_570 = (Truthy(lastC_560) ? Arr(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, ((V)((2D * ToNum(GetIdx(cur_558, 0D))))))) - ToNum(GetIdx(lastC_560, 0D)))))), Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, ((V)((2D * ToNum(GetIdx(cur_558, 1D))))))) - ToNum(GetIdx(lastC_560, 1D))))))) : cur_558);
}
c2_571 = Call(abs_564, V.Undef, rel_566, Call(n_563, V.Undef), Call(n_563, V.Undef));
e_572 = Call(abs_564, V.Undef, rel_566, Call(n_563, V.Undef), Call(n_563, V.Undef));
Invoke(segs_562, "push", NewObj(2).Put("v", ((V)("C"))).Put("p", Arr(cur_558, c1_570, c2_571, e_572)).V);
lastC_560 = c2_571;
lastQ_561 = V.Null;
cur_558 = e_572;
continue;
}
if ((SEqS(C_565, "Q") || SEqS(C_565, "T"))) {
qc_573 = (SEqS(C_565, "Q") ? Call(abs_564, V.Undef, rel_566, Call(n_563, V.Undef), Call(n_563, V.Undef)) : (Truthy(lastQ_561) ? Arr(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, ((V)((2D * ToNum(GetIdx(cur_558, 0D))))))) - ToNum(GetIdx(lastQ_561, 0D)))))), Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, ((V)((2D * ToNum(GetIdx(cur_558, 1D))))))) - ToNum(GetIdx(lastQ_561, 1D))))))) : cur_558));
qe_574 = Call(abs_564, V.Undef, rel_566, Call(n_563, V.Undef), Call(n_563, V.Undef));
Invoke(segs_562, "push", NewObj(2).Put("v", ((V)("Q"))).Put("p", Arr(cur_558, qc_573, qe_574)).V);
lastQ_561 = qc_573;
lastC_560 = V.Null;
cur_558 = qe_574;
continue;
}
if (SEqS(C_565, "A")) {
rx_575 = Call(n_563, V.Undef);
ry_576 = Call(n_563, V.Undef);
ang_577 = Call(n_563, V.Undef);
lg_578 = Call(n_563, V.Undef);
sw_579 = Call(n_563, V.Undef);
to_580 = Call(abs_564, V.Undef, rel_566, Call(n_563, V.Undef), Call(n_563, V.Undef));
conics_581 = Call(arcToConics_53, V.Undef, cur_558, rx_575, ry_576, ang_577, lg_578, sw_579, to_580);
if (!(Truthy(conics_581))) {
Invoke(segs_562, "push", NewObj(2).Put("v", ((V)("L"))).Put("p", Arr(cur_558, to_580)).V);
} else {
from_582 = cur_558;
{
k_583 = ((V)(0D));
while (true) {
if (!(Lt(k_583, Get(conics_581, "length")))) break;
Invoke(segs_562, "push", NewObj(3).Put("v", ((V)("K"))).Put("p", Arr(from_582, GetIdx(GetK(conics_581, k_583), 0D), GetIdx(GetK(conics_581, k_583), 1D))).Put("w", GetIdx(GetK(conics_581, k_583), 2D)).V);
from_582 = GetIdx(GetK(conics_581, k_583), 1D);
PostInc(ref k_583, 1D);
}
}
}
cur_558 = to_580;
lastC_560 = (lastQ_561 = V.Null);
continue;
}
PostInc(ref i_556, 1D);
}
if (!(Truthy(Get(segs_562, "length")))) {
return V.Null;
}
first_584 = (Truthy(Get(GetIdx(segs_562, 0D), "p")) ? GetIdx(Get(GetIdx(segs_562, 0D), "p"), 0D) : Arr(((V)(0D)), ((V)(0D))));
x0_585 = GetIdx(first_584, 0D);
y0_586 = GetIdx(first_584, 1D);
x1_587 = x0_585;
y1_588 = y0_586;
add_589 = Fn((V _self621, int _argc622, V x_628, V y_629, V _a626, V _a627, V[] _rest623) => {
if (Lt(x_628, x0_585)) {
x0_585 = x_628;
}
if (Gt(x_628, x1_587)) {
x1_587 = x_628;
}
if (Lt(y_629, y0_586)) {
y0_586 = y_629;
}
if (Gt(y_629, y1_588)) {
y1_588 = y_629;
}
return default;
}, 2, "", false);
{
s2_590 = ((V)(0D));
while (true) {
if (!(Lt(s2_590, Get(segs_562, "length")))) break;
g_591 = GetK(segs_562, s2_590);
if (SEqS(Get(g_591, "v"), "M")) {
Call(add_589, V.Undef, GetIdx(GetIdx(Get(g_591, "p"), 0D), 0D), GetIdx(GetIdx(Get(g_591, "p"), 0D), 1D));
} else {
if (SEqS(Get(g_591, "v"), "L")) {
Call(add_589, V.Undef, GetIdx(GetIdx(Get(g_591, "p"), 1D), 0D), GetIdx(GetIdx(Get(g_591, "p"), 1D), 1D));
} else {
if (SEqS(Get(g_591, "v"), "K")) {
kts_592 = Invoke(Call(conicExtremaT_54, V.Undef, GetIdx(GetIdx(Get(g_591, "p"), 0D), 0D), GetIdx(GetIdx(Get(g_591, "p"), 1D), 0D), GetIdx(GetIdx(Get(g_591, "p"), 2D), 0D), Get(g_591, "w")), "concat", Call(conicExtremaT_54, V.Undef, GetIdx(GetIdx(Get(g_591, "p"), 0D), 1D), GetIdx(GetIdx(Get(g_591, "p"), 1D), 1D), GetIdx(GetIdx(Get(g_591, "p"), 2D), 1D), Get(g_591, "w")));
{
jk_593 = ((V)(0D));
while (true) {
if (!(Lt(jk_593, Get(kts_592, "length")))) break;
Call(add_589, V.Undef, Call(evalConic_55, V.Undef, Get(g_591, "p"), Get(g_591, "w"), GetK(kts_592, jk_593), ((V)(0D))), Call(evalConic_55, V.Undef, Get(g_591, "p"), Get(g_591, "w"), GetK(kts_592, jk_593), ((V)(1D))));
PostInc(ref jk_593, 1D);
}
}
Call(add_589, V.Undef, GetIdx(GetIdx(Get(g_591, "p"), 2D), 0D), GetIdx(GetIdx(Get(g_591, "p"), 2D), 1D));
} else {
if (SEqS(Get(g_591, "v"), "Q")) {
qts_594 = Arr();
qa_595 = Call(validUnitDivide_44, V.Undef, Call(F_34, V.Undef, ((V)((ToNum(GetIdx(GetIdx(Get(g_591, "p"), 0D), 0D)) - ToNum(GetIdx(GetIdx(Get(g_591, "p"), 1D), 0D)))))), Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, ((V)((ToNum(GetIdx(GetIdx(Get(g_591, "p"), 0D), 0D)) - ToNum(GetIdx(GetIdx(Get(g_591, "p"), 1D), 0D))))))) - ToNum(GetIdx(GetIdx(Get(g_591, "p"), 1D), 0D)))))), GetIdx(GetIdx(Get(g_591, "p"), 2D), 0D))));
qb_596 = Call(validUnitDivide_44, V.Undef, Call(F_34, V.Undef, ((V)((ToNum(GetIdx(GetIdx(Get(g_591, "p"), 0D), 1D)) - ToNum(GetIdx(GetIdx(Get(g_591, "p"), 1D), 1D)))))), Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, ((V)((ToNum(GetIdx(GetIdx(Get(g_591, "p"), 0D), 1D)) - ToNum(GetIdx(GetIdx(Get(g_591, "p"), 1D), 1D))))))) - ToNum(GetIdx(GetIdx(Get(g_591, "p"), 1D), 1D)))))), GetIdx(GetIdx(Get(g_591, "p"), 2D), 1D))));
if (!SEq(qa_595, V.Null)) {
Invoke(qts_594, "push", qa_595);
}
if (!SEq(qb_596, V.Null)) {
Invoke(qts_594, "push", qb_596);
}
{
jq_597 = ((V)(0D));
while (true) {
if (!(Lt(jq_597, Get(qts_594, "length")))) break;
tq_598 = GetK(qts_594, jq_597);
ev_599 = Fn((V _self633, int _argc634, V k_640, V _a637, V _a638, V _a639, V[] _rest635) => {
V P0_641 = default;
V P1_642 = default;
V P2_643 = default;
V A_644 = default;
V B_645 = default;
P0_641 = GetK(GetIdx(Get(g_591, "p"), 0D), k_640);
P1_642 = GetK(GetIdx(Get(g_591, "p"), 1D), k_640);
P2_643 = GetK(GetIdx(Get(g_591, "p"), 2D), k_640);
A_644 = Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(P2_643) - ToNum(Call(F_34, V.Undef, ((V)((2D * ToNum(P1_642)))))))))), P0_641));
B_645 = Call(F_34, V.Undef, ((V)((2D * ToNum(Call(F_34, V.Undef, ((V)((ToNum(P1_642) - ToNum(P0_641))))))))));
return Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(Call(F_34, V.Undef, Add(Call(F_34, V.Undef, ((V)((ToNum(A_644) * ToNum(tq_598))))), B_645))) * ToNum(tq_598))))), P0_641));
return default;
}, 1, "", false);
Call(add_589, V.Undef, Call(ev_599, V.Undef, ((V)(0D))), Call(ev_599, V.Undef, ((V)(1D))));
PostInc(ref jq_597, 1D);
}
}
Call(add_589, V.Undef, GetIdx(GetIdx(Get(g_591, "p"), 2D), 0D), GetIdx(GetIdx(Get(g_591, "p"), 2D), 1D));
} else {
if (SEqS(Get(g_591, "v"), "C")) {
ts_600 = Invoke(Call(cubicExtremaT_46, V.Undef, GetIdx(GetIdx(Get(g_591, "p"), 0D), 0D), GetIdx(GetIdx(Get(g_591, "p"), 1D), 0D), GetIdx(GetIdx(Get(g_591, "p"), 2D), 0D), GetIdx(GetIdx(Get(g_591, "p"), 3D), 0D)), "concat", Call(cubicExtremaT_46, V.Undef, GetIdx(GetIdx(Get(g_591, "p"), 0D), 1D), GetIdx(GetIdx(Get(g_591, "p"), 1D), 1D), GetIdx(GetIdx(Get(g_591, "p"), 2D), 1D), GetIdx(GetIdx(Get(g_591, "p"), 3D), 1D)));
{
j_601 = ((V)(0D));
while (true) {
if (!(Lt(j_601, Get(ts_600, "length")))) break;
Call(add_589, V.Undef, Call(evalCubic_47, V.Undef, Get(g_591, "p"), GetK(ts_600, j_601), ((V)(0D))), Call(evalCubic_47, V.Undef, Get(g_591, "p"), GetK(ts_600, j_601), ((V)(1D))));
PostInc(ref j_601, 1D);
}
}
Call(add_589, V.Undef, GetIdx(GetIdx(Get(g_591, "p"), 3D), 0D), GetIdx(GetIdx(Get(g_591, "p"), 3D), 1D));
}
}
}
}
}
PostInc(ref s2_590, 1D);
}
}
return Call(fromBounds_41, V.Undef, x0_585, y0_586, x1_587, y1_588);
return default;
}, 1, "pathTight", false);
boxOf_57 = Fn((V _self647, int _argc648, V el_654, V _a651, V _a652, V _a653, V[] _rest649) => {
V tag_655 = default;
V num_656 = default;
V r_657 = default;
V rx_658 = default;
V ry_659 = default;
V x1_660 = default;
V y1_661 = default;
V x2_662 = default;
V y2_663 = default;
V p_664 = default;
V b2_665 = default;
V i_666 = default;
V u_667 = default;
V c_668 = default;
V ch_669 = default;
V cb_670 = default;
tag_655 = Get(el_654, "localName");
num_656 = Fn((V _self671, int _argc672, V k_678, V _a675, V _a676, V _a677, V[] _rest673) => {
return Call(F_34, V.Undef, (((V)(ParseFloat((Invoke(el_654, "getAttribute", k_678) is var _t679 && Truthy(_t679) ? _t679 : ((V)("0")))))) is var _t680 && Truthy(_t680) ? _t680 : ((V)(0D))));
return default;
}, 1, "", false);
if (SEqS(tag_655, "path")) {
return Call(pathTight_56, V.Undef, (Invoke(el_654, "getAttribute", ((V)("d"))) is var _t681 && Truthy(_t681) ? _t681 : ((V)(""))));
}
if (SEqS(tag_655, "rect")) {
return Call(rect_37, V.Undef, Call(num_656, V.Undef, ((V)("x"))), Call(num_656, V.Undef, ((V)("y"))), Call(num_656, V.Undef, ((V)("width"))), Call(num_656, V.Undef, ((V)("height"))));
}
if (SEqS(tag_655, "circle")) {
r_657 = Call(num_656, V.Undef, ((V)("r")));
return Call(rect_37, V.Undef, Call(F_34, V.Undef, ((V)((ToNum(Call(num_656, V.Undef, ((V)("cx")))) - ToNum(r_657))))), Call(F_34, V.Undef, ((V)((ToNum(Call(num_656, V.Undef, ((V)("cy")))) - ToNum(r_657))))), Call(F_34, V.Undef, ((V)((ToNum(r_657) * 2D)))), Call(F_34, V.Undef, ((V)((ToNum(r_657) * 2D)))));
}
if (SEqS(tag_655, "ellipse")) {
rx_658 = Call(num_656, V.Undef, ((V)("rx")));
ry_659 = Call(num_656, V.Undef, ((V)("ry")));
return Call(rect_37, V.Undef, Call(F_34, V.Undef, ((V)((ToNum(Call(num_656, V.Undef, ((V)("cx")))) - ToNum(rx_658))))), Call(F_34, V.Undef, ((V)((ToNum(Call(num_656, V.Undef, ((V)("cy")))) - ToNum(ry_659))))), Call(F_34, V.Undef, ((V)((ToNum(rx_658) * 2D)))), Call(F_34, V.Undef, ((V)((ToNum(ry_659) * 2D)))));
}
if (SEqS(tag_655, "line")) {
x1_660 = Call(num_656, V.Undef, ((V)("x1")));
y1_661 = Call(num_656, V.Undef, ((V)("y1")));
x2_662 = Call(num_656, V.Undef, ((V)("x2")));
y2_663 = Call(num_656, V.Undef, ((V)("y2")));
return Call(rect_37, V.Undef, ((V)(Min(ToNum(x1_660), ToNum(x2_662)))), ((V)(Min(ToNum(y1_661), ToNum(y2_663)))), ((V)(System.Math.Abs((ToNum(x2_662) - ToNum(x1_660))))), ((V)(System.Math.Abs((ToNum(y2_663) - ToNum(y1_661))))));
}
if ((SEqS(tag_655, "polygon") || SEqS(tag_655, "polyline"))) {
p_664 = Invoke(Invoke(Invoke((Invoke(el_654, "getAttribute", ((V)("points"))) is var _t682 && Truthy(_t682) ? _t682 : ((V)(""))), "split", NewRegExp(RX7, "[\\s,]+", "")), "filter", G("Boolean")), "map", G("Number"));
b2_665 = V.Null;
{
i_666 = ((V)(0D));
while (true) {
if (!(Lt(Add(i_666, ((V)(1D))), Get(p_664, "length")))) break;
b2_665 = Call(unite_42, V.Undef, b2_665, Call(rect_37, V.Undef, GetK(p_664, i_666), GetK(p_664, Add(i_666, ((V)(1D)))), ((V)(0D)), ((V)(0D))));
i_666 = Add(i_666, ((V)(2D)));
}
}
return b2_665;
}
if ((((SEqS(tag_655, "g") || SEqS(tag_655, "svg")) || SEqS(tag_655, "a")) || SEqS(tag_655, "switch"))) {
u_667 = V.Null;
{
c_668 = ((V)(0D));
while (true) {
if (!(Lt(c_668, Get(Get(el_654, "childNodes"), "length")))) break;
ch_669 = GetK(Get(el_654, "childNodes"), c_668);
if (Truthy(((!SEqN(Get(ch_669, "nodeType"), 1D) ? V.True : V.False) is var _t685 && Truthy(_t685) ? _t685 : Invoke(NewRegExp(RX8, "^(defs|clipPath|mask|linearGradient|radialGradient|pattern|filter|style|title|desc|metadata|script|symbol|marker)$", ""), "test", Get(ch_669, "localName"))))) {
goto _cont684;
}
if (Truthy((((SEqS(Get(Get(ch_669, "style"), "display"), "none") || SEqS(Invoke(ch_669, "getAttribute", ((V)("display"))), "none")) ? V.True : V.False) is var _t687 && Truthy(_t687) ? _t687 : (Get(root_8, "__cssHidden") is var _t686 && !Truthy(_t686) ? _t686 : Invoke(root_8, "__cssHidden", ch_669))))) {
goto _cont684;
}
cb_670 = Call(boxOf_57, V.Undef, ch_669);
if (Truthy(cb_670)) {
u_667 = Call(unite_42, V.Undef, u_667, Call(mapRect_43, V.Undef, Call(parseTransform_59, V.Undef, Invoke(ch_669, "getAttribute", ((V)("transform")))), cb_670));
}
_cont684: ;
PostInc(ref c_668, 1D);
}
}
return u_667;
}
return V.Null;
return default;
}, 1, "boxOf", false);
mul_58 = Fn((V _self688, int _argc689, V a_695, V c_696, V _a693, V _a694, V[] _rest690) => {
if (!(Truthy(a_695))) {
return c_696;
}
if (!(Truthy(c_696))) {
return a_695;
}
return Arr(((V)(((ToNum(GetIdx(a_695, 0D)) * ToNum(GetIdx(c_696, 0D))) + (ToNum(GetIdx(a_695, 2D)) * ToNum(GetIdx(c_696, 1D)))))), ((V)(((ToNum(GetIdx(a_695, 1D)) * ToNum(GetIdx(c_696, 0D))) + (ToNum(GetIdx(a_695, 3D)) * ToNum(GetIdx(c_696, 1D)))))), ((V)(((ToNum(GetIdx(a_695, 0D)) * ToNum(GetIdx(c_696, 2D))) + (ToNum(GetIdx(a_695, 2D)) * ToNum(GetIdx(c_696, 3D)))))), ((V)(((ToNum(GetIdx(a_695, 1D)) * ToNum(GetIdx(c_696, 2D))) + (ToNum(GetIdx(a_695, 3D)) * ToNum(GetIdx(c_696, 3D)))))), Add(((V)(((ToNum(GetIdx(a_695, 0D)) * ToNum(GetIdx(c_696, 4D))) + (ToNum(GetIdx(a_695, 2D)) * ToNum(GetIdx(c_696, 5D)))))), GetIdx(a_695, 4D)), Add(((V)(((ToNum(GetIdx(a_695, 1D)) * ToNum(GetIdx(c_696, 4D))) + (ToNum(GetIdx(a_695, 3D)) * ToNum(GetIdx(c_696, 5D)))))), GetIdx(a_695, 5D)));
return default;
}, 2, "mul", false);
parseTransform_59 = Fn((V _self697, int _argc698, V s_704, V _a701, V _a702, V _a703, V[] _rest699) => {
V m_705 = default;
V re_706 = default;
V t_707 = default;
V v_708 = default;
V k_709 = default;
V rr_710 = default;
V cs_711 = default;
V sn_712 = default;
if (!(Truthy(s_704))) {
return V.Null;
}
m_705 = V.Null;
re_706 = NewRegExp(RX9, "(matrix|translate|scale|rotate|skewX|skewY)\\s*\\(([^)]*)\\)", "g");
while (Truthy((t_707 = Invoke(re_706, "exec", s_704)))) {
v_708 = Invoke(Invoke(Invoke(GetIdx(t_707, 2D), "split", NewRegExp(RX7, "[\\s,]+", "")), "filter", G("Boolean")), "map", Fn((V _self713, int _argc714, V x_720, V _a717, V _a718, V _a719, V[] _rest715) => {
return Call(F_34, V.Undef, ((V)(ToNum(x_720))));
return default;
}, 1, "", false));
if (SEqS(GetIdx(t_707, 1D), "matrix")) {
k_709 = v_708;
} else {
if (SEqS(GetIdx(t_707, 1D), "translate")) {
k_709 = Arr(((V)(1D)), ((V)(0D)), ((V)(0D)), ((V)(1D)), (GetIdx(v_708, 0D) is var _t721 && Truthy(_t721) ? _t721 : ((V)(0D))), (GetIdx(v_708, 1D) is var _t722 && Truthy(_t722) ? _t722 : ((V)(0D))));
} else {
if (SEqS(GetIdx(t_707, 1D), "scale")) {
k_709 = Arr(GetIdx(v_708, 0D), ((V)(0D)), ((V)(0D)), (GtN(Get(v_708, "length"), 1D) ? GetIdx(v_708, 1D) : GetIdx(v_708, 0D)), ((V)(0D)), ((V)(0D)));
} else {
if (SEqS(GetIdx(t_707, 1D), "rotate")) {
rr_710 = ((V)(((ToNum(GetIdx(v_708, 0D)) * System.Math.PI) / 180D)));
cs_711 = ((V)(FdLibm.Cos(ToNum(rr_710))));
sn_712 = ((V)(FdLibm.Sin(ToNum(rr_710))));
k_709 = Arr(cs_711, sn_712, ((V)((-ToNum(sn_712)))), cs_711, ((V)(0D)), ((V)(0D)));
if (GtN(Get(v_708, "length"), 2D)) {
k_709 = Call(mul_58, V.Undef, Call(mul_58, V.Undef, Arr(((V)(1D)), ((V)(0D)), ((V)(0D)), ((V)(1D)), GetIdx(v_708, 1D), GetIdx(v_708, 2D)), k_709), Arr(((V)(1D)), ((V)(0D)), ((V)(0D)), ((V)(1D)), ((V)((-ToNum(GetIdx(v_708, 1D))))), ((V)((-ToNum(GetIdx(v_708, 2D)))))));
}
} else {
if (SEqS(GetIdx(t_707, 1D), "skewX")) {
k_709 = Arr(((V)(1D)), ((V)(0D)), ((V)(FdLibm.Tan(((ToNum(GetIdx(v_708, 0D)) * System.Math.PI) / 180D)))), ((V)(1D)), ((V)(0D)), ((V)(0D)));
} else {
k_709 = Arr(((V)(1D)), ((V)(FdLibm.Tan(((ToNum(GetIdx(v_708, 0D)) * System.Math.PI) / 180D)))), ((V)(0D)), ((V)(1D)), ((V)(0D)), ((V)(0D)));
}
}
}
}
}
m_705 = Call(mul_58, V.Undef, m_705, k_709);
}
return m_705;
return default;
}, 1, "parseTransform", false);
specified_65 = Fn((V _self723, int _argc724, V el_730, V k_731, V _a728, V _a729, V[] _rest725) => {
V att_732 = default;
V e_733 = default;
V v_734 = default;
att_732 = Call(kebab_14, V.Undef, k_731);
{
e_733 = el_730;
while (true) {
if (!(Truthy((e_733 is var _t736 && !Truthy(_t736) ? _t736 : (SEqN(Get(e_733, "nodeType"), 1D) ? V.True : V.False))))) break;
v_734 = GetK(Get(e_733, "style"), k_731);
if ((v_734.IsNullish || SEqS(v_734, ""))) {
v_734 = Invoke(e_733, "getAttribute", att_732);
}
if (((!v_734.IsNullish && !SEqS(v_734, "")) && !SEqS(v_734, "inherit"))) {
return Invoke(((V)(ToStrS(v_734))), "trim");
}
if ((!(Truthy(GetK(CS_INH_60, k_731))) && !SEqS(v_734, "inherit"))) {
return V.Null;
}
e_733 = Get(e_733, "parentNode");
}
}
return V.Null;
return default;
}, 2, "specified", false);
cssColor_66 = Fn((V _self737, int _argc738, V v_744, V _a741, V _a742, V _a743, V[] _rest739) => {
V s_745 = default;
V c_746 = default;
V a_747 = default;
V m_748 = default;
V h_749 = default;
V p_750 = default;
V q_751 = default;
V H_752 = default;
V S_753 = default;
V L_754 = default;
V hue_755 = default;
s_745 = Invoke(Invoke(((V)(ToStrS(v_744))), "trim"), "toLowerCase");
c_746 = V.Null;
a_747 = ((V)(1D));
if (SEqS(s_745, "transparent")) {
return ((V)("rgba(0, 0, 0, 0)"));
}
if (Truthy(GetK(NAMED_64, s_745))) {
c_746 = GetK(NAMED_64, s_745);
} else {
if (Truthy((m_748 = Invoke(NewRegExp(RX10, "^#([0-9a-f]{3,8})$", ""), "exec", s_745)))) {
h_749 = GetIdx(m_748, 1D);
if ((SEqN(Get(h_749, "length"), 3D) || SEqN(Get(h_749, "length"), 4D))) {
h_749 = Invoke(h_749, "replace", NewRegExp(RX11, ".", "g"), ((V)("$&$&")));
}
if ((!SEqN(Get(h_749, "length"), 6D) && !SEqN(Get(h_749, "length"), 8D))) {
return V.Null;
}
c_746 = Arr(((V)(ParseInt(Invoke(h_749, "slice", ((V)(0D)), ((V)(2D))), ((V)(16D))))), ((V)(ParseInt(Invoke(h_749, "slice", ((V)(2D)), ((V)(4D))), ((V)(16D))))), ((V)(ParseInt(Invoke(h_749, "slice", ((V)(4D)), ((V)(6D))), ((V)(16D))))));
if (SEqN(Get(h_749, "length"), 8D)) {
a_747 = ((V)((ParseInt(Invoke(h_749, "slice", ((V)(6D)), ((V)(8D))), ((V)(16D))) / 255D)));
}
} else {
if (Truthy((m_748 = Invoke(NewRegExp(RX12, "^rgba?\\(([^)]*)\\)$", ""), "exec", s_745)))) {
p_750 = Invoke(Invoke(GetIdx(m_748, 1D), "split", NewRegExp(RX13, "[\\s,\\/]+", "")), "filter", G("Boolean"));
c_746 = Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _self756, int _argc757, V i_763, V _a760, V _a761, V _a762, V[] _rest758) => {
V x_764 = default;
x_764 = (GetK(p_750, i_763) is var _t765 && Truthy(_t765) ? _t765 : ((V)("0")));
return ((V)(Round((SEqS(Invoke(x_764, "slice", ((V)((-1D)))), "%") ? (ParseFloat(x_764) * 2.55) : ParseFloat(x_764)))));
return default;
}, 1, "", false));
if (!GetIdx(p_750, 3D).IsNullish) {
a_747 = ((V)((SEqS(Invoke(GetIdx(p_750, 3D), "slice", ((V)((-1D)))), "%") ? (ParseFloat(GetIdx(p_750, 3D)) / 100D) : ParseFloat(GetIdx(p_750, 3D)))));
}
} else {
if (Truthy((m_748 = Invoke(NewRegExp(RX14, "^hsla?\\(([^)]*)\\)$", ""), "exec", s_745)))) {
q_751 = Invoke(Invoke(GetIdx(m_748, 1D), "split", NewRegExp(RX13, "[\\s,\\/]+", "")), "filter", G("Boolean"));
H_752 = ((V)(((((ParseFloat(GetIdx(q_751, 0D)) % 360D) + 360D) % 360D) / 360D)));
S_753 = ((V)((ParseFloat(GetIdx(q_751, 1D)) / 100D)));
L_754 = ((V)((ParseFloat(GetIdx(q_751, 2D)) / 100D)));
hue_755 = Fn((V _self766, int _argc767, V t_773, V _a770, V _a771, V _a772, V[] _rest768) => {
V Q_774 = default;
V P_775 = default;
t_773 = ((V)((ToNum(Add(t_773, ((V)(1D)))) % 1D)));
Q_774 = ((V)((LtN(L_754, 0.5) ? (ToNum(L_754) * ToNum(Add(((V)(1D)), S_753))) : (ToNum(Add(L_754, S_753)) - (ToNum(L_754) * ToNum(S_753))))));
P_775 = ((V)(((2D * ToNum(L_754)) - ToNum(Q_774))));
return (LtN(t_773, (1D / 6D)) ? Add(P_775, ((V)((((ToNum(Q_774) - ToNum(P_775)) * 6D) * ToNum(t_773))))) : (LtN(t_773, 0.5) ? Q_774 : (LtN(t_773, (2D / 3D)) ? Add(P_775, ((V)((((ToNum(Q_774) - ToNum(P_775)) * ((2D / 3D) - ToNum(t_773))) * 6D)))) : P_775)));
return default;
}, 1, "", false);
c_746 = Invoke(Arr(Call(hue_755, V.Undef, Add(H_752, ((V)((1D / 3D))))), Call(hue_755, V.Undef, H_752), Call(hue_755, V.Undef, ((V)((ToNum(H_752) - (1D / 3D)))))), "map", Fn((V _self776, int _argc777, V x_783, V _a780, V _a781, V _a782, V[] _rest778) => {
return ((V)(Round((ToNum(x_783) * 255D))));
return default;
}, 1, "", false));
if (!GetIdx(q_751, 3D).IsNullish) {
a_747 = ((V)((SEqS(Invoke(GetIdx(q_751, 3D), "slice", ((V)((-1D)))), "%") ? (ParseFloat(GetIdx(q_751, 3D)) / 100D) : ParseFloat(GetIdx(q_751, 3D)))));
}
}
}
}
}
if (Truthy(((!(Truthy(c_746)) ? V.True : V.False) is var _t792 && Truthy(_t792) ? _t792 : Invoke(c_746, "some", Fn((V _self784, int _argc785, V x_791, V _a788, V _a789, V _a790, V[] _rest786) => {
return (!SEq(x_791, x_791) ? V.True : V.False);
return default;
}, 1, "", false))))) {
return V.Null;
}
c_746 = Invoke(c_746, "map", Fn((V _self793, int _argc794, V x_800, V _a797, V _a798, V _a799, V[] _rest795) => {
return ((V)(Max(0D, Min(255D, ToNum(x_800)))));
return default;
}, 1, "", false));
return ((V)(((GeN(a_747, 1D) || !SEq(a_747, a_747)) ? JsStrBuf.Begin().S("rgb(").V(Invoke(c_746, "join", ((V)(", ")))).S(")").End() : JsStrBuf.Begin().S("rgba(").V(Invoke(c_746, "join", ((V)(", ")))).S(", ").N(Max(0D, ToNum(a_747))).S(")").End())));
return default;
}, 1, "cssColor", false);
computed_67 = Fn((V _self801, int _argc802, V el_808, V k_809, V _a806, V _a807, V[] _rest803) => {
V v_810 = default;
V u_811 = default;
V n_812 = default;
V w_813 = default;
v_810 = Call(specified_65, V.Undef, el_808, k_809);
if (SEqS(k_809, "display")) {
return (Truthy(((SEqS(v_810, "none") ? V.True : V.False) is var _t816 && Truthy(_t816) ? _t816 : (Get(root_8, "__cssHidden") is var _t815 && !Truthy(_t815) ? _t815 : Invoke(root_8, "__cssHidden", el_808)))) ? ((V)("none")) : (v_810 is var _t814 && Truthy(_t814) ? _t814 : ((V)("inline"))));
}
if (v_810.IsNullish) {
v_810 = GetK(CS_DEF_61, k_809);
}
if (Truthy(GetK(CS_PAINT_62, k_809))) {
if (SEqS(Invoke(v_810, "toLowerCase"), "currentcolor")) {
return Call(computed_67, V.Undef, el_808, ((V)("color")));
}
u_811 = Invoke(NewRegExp(RX15, "^url\\(\\s*[\"']?([^\"')]+)[\"']?\\s*\\)", ""), "exec", v_810);
if (Truthy(u_811)) {
return ((V)(JsStrBuf.Begin().S("url(\"").V(GetIdx(u_811, 1D)).S("\")").End()));
}
if (SEqS(v_810, "none")) {
return ((V)("none"));
}
return (Call(cssColor_66, V.Undef, v_810) is var _t817 && Truthy(_t817) ? _t817 : v_810);
}
if (Truthy(GetK(CS_NUM_63, k_809))) {
n_812 = ((V)((SEqS(Invoke(v_810, "slice", ((V)((-1D)))), "%") ? (ParseFloat(v_810) / 100D) : ParseFloat(v_810))));
return ((V)(ToStrS(((V)((!SEq(n_812, n_812) ? 1D : Max(0D, Min(1D, ToNum(n_812)))))))));
}
if (SEqS(k_809, "strokeWidth")) {
w_813 = ((V)(ParseFloat(v_810)));
return ((V)(JsStrBuf.Begin().V((!SEq(w_813, w_813) ? ((V)(1D)) : w_813)).S("px").End()));
}
return v_810;
return default;
}, 2, "computed", false);
CStyle_68 = Fn((V _self818, int _argc819, V el_825, V _a822, V _a823, V _a824, V[] _rest820) => {
V st_826 = default;
V k_827 = default;
Object_defineProperty(_self818, ((V)("_el")), NewObj(2).Put("value", el_825).Put("enumerable", (false ? V.True : V.False)).V);
st_826 = (el_825 is var _t828 && !Truthy(_t828) ? _t828 : Get(el_825, "style"));
if (Truthy(st_826)) {
{
foreach (V _k829 in ForInKeys(st_826)) {
k_827 = _k829;
if (Truthy((Invoke(Get(Get(G("Object"), "prototype"), "hasOwnProperty"), "call", st_826, k_827) is var _t830 && !Truthy(_t830) ? _t830 : (!(Truthy(Invoke(Get(Get(G("Object"), "prototype"), "hasOwnProperty"), "call", CS_DEF_61, k_827))) ? V.True : V.False)))) {
SetK(_self818, k_827, GetK(st_826, k_827));
}
}
}
}
return default;
}, 1, "CStyle", false);
Mat_69 = Fn((V _self831, int _argc832, V a_838, V b_839, V c_840, V d_841, V[] _rest833) => {
V e_842 = default;
V f_843 = default;
e_842 = (_argc832 > 4 ? _rest833[0] : V.Undef);
f_843 = (_argc832 > 5 ? _rest833[1] : V.Undef);
Set(_self831, "a", a_838);
Set(_self831, "b", b_839);
Set(_self831, "c", c_840);
Set(_self831, "d", d_841);
Set(_self831, "e", e_842);
Set(_self831, "f", f_843);
return default;
}, 6, "Mat", false);
Pt_70 = Fn((V _self844, int _argc845, V x_851, V y_852, V _a849, V _a850, V[] _rest846) => {
Set(_self844, "x", (((V)(ToNum(x_851))) is var _t853 && Truthy(_t853) ? _t853 : ((V)(0D))));
Set(_self844, "y", (((V)(ToNum(y_852))) is var _t854 && Truthy(_t854) ? _t854 : ((V)(0D))));
Set(_self844, "z", ((V)(0D)));
Set(_self844, "w", ((V)(1D)));
return default;
}, 2, "Pt", false);
geoOf_73 = Fn((V _self855, int _argc856, V el_862, V _a859, V _a860, V _a861, V[] _rest857) => {
V tag_863 = default;
V key_864 = default;
V i_865 = default;
V g_866 = default;
V subs_867 = default;
V len_868 = default;
V x0_869 = default;
V y0_870 = default;
V x1_871 = default;
V y1_872 = default;
V s_873 = default;
V p_874 = default;
V n_875 = default;
V j_876 = default;
tag_863 = Get(el_862, "localName");
if (SEqS(tag_863, "path")) {
key_864 = (Invoke(el_862, "getAttribute", ((V)("d"))) is var _t877 && Truthy(_t877) ? _t877 : ((V)("")));
} else {
if (Truthy(GetK(GEO_ATTRS_72, tag_863))) {
key_864 = ((V)(""));
{
i_865 = ((V)(0D));
while (true) {
if (!(Lt(i_865, Get(GetK(GEO_ATTRS_72, tag_863), "length")))) break;
key_864 = ((V)(JsStrBuf.Begin().V(key_864).V(Invoke(el_862, "getAttribute", GetK(GetK(GEO_ATTRS_72, tag_863), i_865))).S(",").End()));
PostInc(ref i_865, 1D);
}
}
} else {
return V.Null;
}
}
g_866 = Get(el_862, "__geo");
if (Truthy((g_866 is var _t879 && !Truthy(_t879) ? _t879 : (SEq(Get(g_866, "key"), key_864) ? V.True : V.False)))) {
return g_866;
}
subs_867 = (SEqS(tag_863, "path") ? Call(pathSubs_75, V.Undef, key_864) : Call(shapeSubs_74, V.Undef, el_862, tag_863));
len_868 = ((V)(0D));
x0_869 = ((V)(double.PositiveInfinity));
y0_870 = ((V)(double.PositiveInfinity));
x1_871 = ((V)((-double.PositiveInfinity)));
y1_872 = ((V)((-double.PositiveInfinity)));
{
s_873 = ((V)(0D));
while (true) {
if (!(Lt(s_873, Get(subs_867, "length")))) break;
p_874 = Get(GetK(subs_867, s_873), "p");
n_875 = Get(p_874, "length");
{
j_876 = ((V)(0D));
while (true) {
if (!(Lt(j_876, n_875))) break;
if (Lt(GetK(p_874, j_876), x0_869)) {
x0_869 = GetK(p_874, j_876);
}
if (Gt(GetK(p_874, j_876), x1_871)) {
x1_871 = GetK(p_874, j_876);
}
if (Lt(GetK(p_874, Add(j_876, ((V)(1D)))), y0_870)) {
y0_870 = GetK(p_874, Add(j_876, ((V)(1D))));
}
if (Gt(GetK(p_874, Add(j_876, ((V)(1D)))), y1_872)) {
y1_872 = GetK(p_874, Add(j_876, ((V)(1D))));
}
if (GeN(j_876, 2D)) {
len_868 = Add(len_868, ((V)(Hypot((ToNum(GetK(p_874, j_876)) - ToNum(GetIdx(p_874, (ToNum(j_876) - 2D)))), (ToNum(GetK(p_874, Add(j_876, ((V)(1D))))) - ToNum(GetIdx(p_874, (ToNum(j_876) - 1D))))))));
}
j_876 = Add(j_876, ((V)(2D)));
}
}
if (Truthy((Get(GetK(subs_867, s_873), "closed") is var _t882 && !Truthy(_t882) ? _t882 : (GeN(n_875, 4D) ? V.True : V.False)))) {
len_868 = Add(len_868, ((V)(Hypot((ToNum(GetIdx(p_874, 0D)) - ToNum(GetIdx(p_874, (ToNum(n_875) - 2D)))), (ToNum(GetIdx(p_874, 1D)) - ToNum(GetIdx(p_874, (ToNum(n_875) - 1D))))))));
}
PostInc(ref s_873, 1D);
}
}
g_866 = NewObj(8).Put("key", key_864).Put("subs", subs_867).Put("len", len_868).Put("x0", x0_869).Put("y0", y0_870).Put("x1", x1_871).Put("y1", y1_872).Put("rule", (SEqS(Call(computed_67, V.Undef, el_862, ((V)("fillRule"))), "evenodd") ? V.True : V.False)).V;
Set(el_862, "__geo", g_866);
return g_866;
return default;
}, 1, "geoOf", false);
shapeSubs_74 = Fn((V _self883, int _argc884, V el_890, V tag_891, V _a888, V _a889, V[] _rest885) => {
V num_892 = default;
V p_893 = default;
V N_894 = default;
V i_895 = default;
V cx_896 = default;
V cy_897 = default;
V rx_898 = default;
V ry_899 = default;
V t_900 = default;
V x_901 = default;
V y_902 = default;
V w_903 = default;
V h_904 = default;
V rX_905 = default;
V rY_906 = default;
V ax_907 = default;
V ay_908 = default;
V corner_909 = default;
V v_910 = default;
num_892 = Fn((V _self911, int _argc912, V k_918, V _a915, V _a916, V _a917, V[] _rest913) => {
return (((V)(ParseFloat((Invoke(el_890, "getAttribute", k_918) is var _t919 && Truthy(_t919) ? _t919 : ((V)("0")))))) is var _t920 && Truthy(_t920) ? _t920 : ((V)(0D)));
return default;
}, 1, "", false);
p_893 = Arr();
N_894 = ((V)(32D));
if ((SEqS(tag_891, "circle") || SEqS(tag_891, "ellipse"))) {
cx_896 = Call(num_892, V.Undef, ((V)("cx")));
cy_897 = Call(num_892, V.Undef, ((V)("cy")));
rx_898 = (SEqS(tag_891, "circle") ? Call(num_892, V.Undef, ((V)("r"))) : Call(num_892, V.Undef, ((V)("rx"))));
ry_899 = (SEqS(tag_891, "circle") ? rx_898 : Call(num_892, V.Undef, ((V)("ry"))));
if ((!(GtN(rx_898, 0D)) || !(GtN(ry_899, 0D)))) {
return Arr();
}
{
i_895 = ((V)(0D));
while (true) {
if (!(Lt(i_895, N_894))) break;
t_900 = ((V)((((2D * System.Math.PI) * ToNum(i_895)) / ToNum(N_894))));
Invoke(p_893, "push", Add(cx_896, ((V)((ToNum(rx_898) * FdLibm.Cos(ToNum(t_900)))))), Add(cy_897, ((V)((ToNum(ry_899) * FdLibm.Sin(ToNum(t_900)))))));
PostInc(ref i_895, 1D);
}
}
return Arr(NewObj(2).Put("p", p_893).Put("closed", (true ? V.True : V.False)).V);
}
if (SEqS(tag_891, "rect")) {
x_901 = Call(num_892, V.Undef, ((V)("x")));
y_902 = Call(num_892, V.Undef, ((V)("y")));
w_903 = Call(num_892, V.Undef, ((V)("width")));
h_904 = Call(num_892, V.Undef, ((V)("height")));
rX_905 = Invoke(el_890, "getAttribute", ((V)("rx")));
rY_906 = Invoke(el_890, "getAttribute", ((V)("ry")));
if ((!(GtN(w_903, 0D)) || !(GtN(h_904, 0D)))) {
return Arr();
}
ax_907 = ((V)(Min((ToNum(w_903) / 2D), Max(0D, ToNum((((V)(ParseFloat((!rX_905.IsNullish ? rX_905 : rY_906)))) is var _t922 && Truthy(_t922) ? _t922 : ((V)(0D))))))));
ay_908 = ((V)(Min((ToNum(h_904) / 2D), Max(0D, ToNum((((V)(ParseFloat((!rY_906.IsNullish ? rY_906 : rX_905)))) is var _t923 && Truthy(_t923) ? _t923 : ((V)(0D))))))));
if ((!(Truthy(ax_907)) || !(Truthy(ay_908)))) {
return Arr(NewObj(2).Put("p", Arr(x_901, y_902, Add(x_901, w_903), y_902, Add(x_901, w_903), Add(y_902, h_904), x_901, Add(y_902, h_904))).Put("closed", (true ? V.True : V.False)).V);
}
corner_909 = Fn((V _self924, int _argc925, V cx2_931, V cy2_932, V a0_933, V _a930, V[] _rest926) => {
V k_934 = default;
V t2_935 = default;
{
k_934 = ((V)(0D));
while (true) {
if (!(LeN(k_934, 4D))) break;
t2_935 = Add(a0_933, ((V)((((System.Math.PI / 2D) * ToNum(k_934)) / 4D))));
Invoke(p_893, "push", Add(cx2_931, ((V)((ToNum(ax_907) * FdLibm.Cos(ToNum(t2_935)))))), Add(cy2_932, ((V)((ToNum(ay_908) * FdLibm.Sin(ToNum(t2_935)))))));
PostInc(ref k_934, 1D);
}
}
return default;
}, 3, "", false);
Call(corner_909, V.Undef, ((V)((ToNum(Add(x_901, w_903)) - ToNum(ax_907)))), Add(y_902, ay_908), ((V)(((-System.Math.PI) / 2D))));
Call(corner_909, V.Undef, ((V)((ToNum(Add(x_901, w_903)) - ToNum(ax_907)))), ((V)((ToNum(Add(y_902, h_904)) - ToNum(ay_908)))), ((V)(0D)));
Call(corner_909, V.Undef, Add(x_901, ax_907), ((V)((ToNum(Add(y_902, h_904)) - ToNum(ay_908)))), ((V)((System.Math.PI / 2D))));
Call(corner_909, V.Undef, Add(x_901, ax_907), Add(y_902, ay_908), ((V)(System.Math.PI)));
return Arr(NewObj(2).Put("p", p_893).Put("closed", (true ? V.True : V.False)).V);
}
if (SEqS(tag_891, "line")) {
return Arr(NewObj(2).Put("p", Arr(Call(num_892, V.Undef, ((V)("x1"))), Call(num_892, V.Undef, ((V)("y1"))), Call(num_892, V.Undef, ((V)("x2"))), Call(num_892, V.Undef, ((V)("y2"))))).Put("closed", (false ? V.True : V.False)).V);
}
v_910 = Invoke(Invoke(Invoke((Invoke(el_890, "getAttribute", ((V)("points"))) is var _t937 && Truthy(_t937) ? _t937 : ((V)(""))), "split", NewRegExp(RX7, "[\\s,]+", "")), "filter", G("Boolean")), "map", G("Number"));
if (NumTruthy((ToNum(Get(v_910, "length")) % 2D))) {
Invoke(v_910, "pop");
}
return (GeN(Get(v_910, "length"), 4D) ? Arr(NewObj(2).Put("p", v_910).Put("closed", (SEqS(tag_891, "polygon") ? V.True : V.False)).V) : Arr());
return default;
}, 2, "shapeSubs", false);
pathSubs_75 = Fn((V _self938, int _argc939, V d_945, V _a942, V _a943, V _a944, V[] _rest940) => {
V tk_946 = default;
V i_947 = default;
V cmd_948 = default;
V subs_949 = default;
V cur_950 = default;
V x_951 = default;
V y_952 = default;
V sx_953 = default;
V sy_954 = default;
V lcx_955 = default;
V lcy_956 = default;
V lqx_957 = default;
V lqy_958 = default;
V n_959 = default;
V start_960 = default;
V to_961 = default;
V C_962 = default;
V rel_963 = default;
V ox_964 = default;
V oy_965 = default;
V k_966 = default;
V c1x_967 = default;
V c1y_968 = default;
V c2x_969 = default;
V c2y_970 = default;
V ex_971 = default;
V ey_972 = default;
V t_973 = default;
V u_974 = default;
V qx_975 = default;
V qy_976 = default;
V qex_977 = default;
V qey_978 = default;
V t3_979 = default;
V u3_980 = default;
V rx_981 = default;
V ry_982 = default;
V ang_983 = default;
V fa_984 = default;
V fs_985 = default;
V ax_986 = default;
V ay_987 = default;
tk_946 = (Invoke(d_945, "match", NewRegExp(RX5, "[a-zA-Z]|[-+]?(?:\\d*\\.\\d+|\\d+\\.?)(?:[eE][-+]?\\d+)?", "g")) is var _t988 && Truthy(_t988) ? _t988 : Arr());
i_947 = ((V)(0D));
cmd_948 = ((V)(""));
subs_949 = Arr();
cur_950 = V.Null;
x_951 = ((V)(0D));
y_952 = ((V)(0D));
sx_953 = ((V)(0D));
sy_954 = ((V)(0D));
lcx_955 = V.Null;
lcy_956 = ((V)(0D));
lqx_957 = V.Null;
lqy_958 = ((V)(0D));
n_959 = Fn((V _self989, int _argc990, V _a992, V _a993, V _a994, V _a995, V[] _rest991) => {
return ((V)(ToNum(GetIdx(tk_946, PostInc(ref i_947, 1D)))));
return default;
}, 0, "", false);
start_960 = Fn((V _self996, int _argc997, V _a999, V _a1000, V _a1001, V _a1002, V[] _rest998) => {
cur_950 = NewObj(2).Put("p", Arr(x_951, y_952)).Put("closed", (false ? V.True : V.False)).V;
Invoke(subs_949, "push", cur_950);
return default;
}, 0, "", false);
to_961 = Fn((V _self1003, int _argc1004, V nx_1010, V ny_1011, V _a1008, V _a1009, V[] _rest1005) => {
if (!(Truthy(cur_950))) {
Call(start_960, V.Undef);
}
Invoke(Get(cur_950, "p"), "push", nx_1010, ny_1011);
return default;
}, 2, "", false);
while (Lt(i_947, Get(tk_946, "length"))) {
if (Truthy(Invoke(NewRegExp(RX6, "[a-zA-Z]", ""), "test", GetK(tk_946, i_947)))) {
cmd_948 = GetIdx(tk_946, PostInc(ref i_947, 1D));
}
C_962 = Invoke(cmd_948, "toUpperCase");
rel_963 = (!SEq(cmd_948, C_962) ? V.True : V.False);
ox_964 = (Truthy(rel_963) ? x_951 : ((V)(0D)));
oy_965 = (Truthy(rel_963) ? y_952 : ((V)(0D)));
if (SEqS(C_962, "Z")) {
if (Truthy(cur_950)) {
Set(cur_950, "closed", (true ? V.True : V.False));
cur_950 = V.Null;
}
x_951 = sx_953;
y_952 = sy_954;
lcx_955 = (lqx_957 = V.Null);
if ((Lt(i_947, Get(tk_946, "length")) && !(Truthy(Invoke(NewRegExp(RX6, "[a-zA-Z]", ""), "test", GetK(tk_946, i_947)))))) {
PostInc(ref i_947, 1D);
}
continue;
}
if (Ge(i_947, Get(tk_946, "length"))) {
break;
}
if (SEqS(C_962, "M")) {
x_951 = Add(ox_964, Call(n_959, V.Undef));
y_952 = Add(oy_965, Call(n_959, V.Undef));
sx_953 = x_951;
sy_954 = y_952;
Call(start_960, V.Undef);
cmd_948 = ((V)((Truthy(rel_963) ? "l" : "L")));
lcx_955 = (lqx_957 = V.Null);
continue;
}
if (SEqS(C_962, "L")) {
x_951 = Add(ox_964, Call(n_959, V.Undef));
y_952 = Add(oy_965, Call(n_959, V.Undef));
Call(to_961, V.Undef, x_951, y_952);
lcx_955 = (lqx_957 = V.Null);
continue;
}
if (SEqS(C_962, "H")) {
x_951 = Add(ox_964, Call(n_959, V.Undef));
Call(to_961, V.Undef, x_951, y_952);
lcx_955 = (lqx_957 = V.Null);
continue;
}
if (SEqS(C_962, "V")) {
y_952 = Add(oy_965, Call(n_959, V.Undef));
Call(to_961, V.Undef, x_951, y_952);
lcx_955 = (lqx_957 = V.Null);
continue;
}
if ((SEqS(C_962, "C") || SEqS(C_962, "S"))) {

if (SEqS(C_962, "C")) {
c1x_967 = Add(ox_964, Call(n_959, V.Undef));
c1y_968 = Add(oy_965, Call(n_959, V.Undef));
} else {
c1x_967 = (!lcx_955.IsNullish ? ((V)(((2D * ToNum(x_951)) - ToNum(lcx_955)))) : x_951);
c1y_968 = (!lcx_955.IsNullish ? ((V)(((2D * ToNum(y_952)) - ToNum(lcy_956)))) : y_952);
}
c2x_969 = Add(ox_964, Call(n_959, V.Undef));
c2y_970 = Add(oy_965, Call(n_959, V.Undef));
ex_971 = Add(ox_964, Call(n_959, V.Undef));
ey_972 = Add(oy_965, Call(n_959, V.Undef));
{
k_966 = ((V)(1D));
while (true) {
if (!(LeN(k_966, 8D))) break;
t_973 = ((V)((ToNum(k_966) / 8D)));
u_974 = ((V)((1D - ToNum(t_973))));
Call(to_961, V.Undef, ((V)(((((((ToNum(u_974) * ToNum(u_974)) * ToNum(u_974)) * ToNum(x_951)) + ((((3D * ToNum(u_974)) * ToNum(u_974)) * ToNum(t_973)) * ToNum(c1x_967))) + ((((3D * ToNum(u_974)) * ToNum(t_973)) * ToNum(t_973)) * ToNum(c2x_969))) + (((ToNum(t_973) * ToNum(t_973)) * ToNum(t_973)) * ToNum(ex_971))))), ((V)(((((((ToNum(u_974) * ToNum(u_974)) * ToNum(u_974)) * ToNum(y_952)) + ((((3D * ToNum(u_974)) * ToNum(u_974)) * ToNum(t_973)) * ToNum(c1y_968))) + ((((3D * ToNum(u_974)) * ToNum(t_973)) * ToNum(t_973)) * ToNum(c2y_970))) + (((ToNum(t_973) * ToNum(t_973)) * ToNum(t_973)) * ToNum(ey_972))))));
PostInc(ref k_966, 1D);
}
}
lcx_955 = c2x_969;
lcy_956 = c2y_970;
lqx_957 = V.Null;
x_951 = ex_971;
y_952 = ey_972;
continue;
}
if ((SEqS(C_962, "Q") || SEqS(C_962, "T"))) {

if (SEqS(C_962, "Q")) {
qx_975 = Add(ox_964, Call(n_959, V.Undef));
qy_976 = Add(oy_965, Call(n_959, V.Undef));
} else {
qx_975 = (!lqx_957.IsNullish ? ((V)(((2D * ToNum(x_951)) - ToNum(lqx_957)))) : x_951);
qy_976 = (!lqx_957.IsNullish ? ((V)(((2D * ToNum(y_952)) - ToNum(lqy_958)))) : y_952);
}
qex_977 = Add(ox_964, Call(n_959, V.Undef));
qey_978 = Add(oy_965, Call(n_959, V.Undef));
{
k_966 = ((V)(1D));
while (true) {
if (!(LeN(k_966, 6D))) break;
t3_979 = ((V)((ToNum(k_966) / 6D)));
u3_980 = ((V)((1D - ToNum(t3_979))));
Call(to_961, V.Undef, ((V)(((((ToNum(u3_980) * ToNum(u3_980)) * ToNum(x_951)) + (((2D * ToNum(u3_980)) * ToNum(t3_979)) * ToNum(qx_975))) + ((ToNum(t3_979) * ToNum(t3_979)) * ToNum(qex_977))))), ((V)(((((ToNum(u3_980) * ToNum(u3_980)) * ToNum(y_952)) + (((2D * ToNum(u3_980)) * ToNum(t3_979)) * ToNum(qy_976))) + ((ToNum(t3_979) * ToNum(t3_979)) * ToNum(qey_978))))));
PostInc(ref k_966, 1D);
}
}
lqx_957 = qx_975;
lqy_958 = qy_976;
lcx_955 = V.Null;
x_951 = qex_977;
y_952 = qey_978;
continue;
}
if (SEqS(C_962, "A")) {
rx_981 = Call(n_959, V.Undef);
ry_982 = Call(n_959, V.Undef);
ang_983 = Call(n_959, V.Undef);
fa_984 = Call(n_959, V.Undef);
fs_985 = Call(n_959, V.Undef);
ax_986 = Add(ox_964, Call(n_959, V.Undef));
ay_987 = Add(oy_965, Call(n_959, V.Undef));
if (!(Truthy(cur_950))) {
Call(start_960, V.Undef);
}
Call(arcFlat_76, V.Undef, Get(cur_950, "p"), x_951, y_952, rx_981, ry_982, ang_983, (!(!(Truthy(fa_984))) ? V.True : V.False), (!(!(Truthy(fs_985))) ? V.True : V.False), ax_986, ay_987);
x_951 = ax_986;
y_952 = ay_987;
lcx_955 = (lqx_957 = V.Null);
continue;
}
PostInc(ref i_947, 1D);
}
return subs_949;
return default;
}, 1, "pathSubs", false);
arcFlat_76 = Fn((V _self1014, int _argc1015, V @out_1021, V x1_1022, V y1_1023, V rx_1024, V[] _rest1016) => {
V r_1031 = default;
V cs_1032 = default;
V sn_1033 = default;
V dx_1034 = default;
V dy_1035 = default;
V xp_1036 = default;
V yp_1037 = default;
V lam_1038 = default;
V s_1039 = default;
V num_1040 = default;
V den_1041 = default;
V co_1042 = default;
V cxp_1043 = default;
V cyp_1044 = default;
V cx_1045 = default;
V cy_1046 = default;
V ang_1047 = default;
V t1_1048 = default;
V dt_1049 = default;
V steps_1050 = default;
V i_1051 = default;
V t_1052 = default;
V ex_1053 = default;
V ey_1054 = default;
V ry_1025 = default;
V phi_1026 = default;
V fa_1027 = default;
V fs_1028 = default;
V x2_1029 = default;
V y2_1030 = default;
ry_1025 = (_argc1015 > 4 ? _rest1016[0] : V.Undef);
phi_1026 = (_argc1015 > 5 ? _rest1016[1] : V.Undef);
fa_1027 = (_argc1015 > 6 ? _rest1016[2] : V.Undef);
fs_1028 = (_argc1015 > 7 ? _rest1016[3] : V.Undef);
x2_1029 = (_argc1015 > 8 ? _rest1016[4] : V.Undef);
y2_1030 = (_argc1015 > 9 ? _rest1016[5] : V.Undef);
if ((SEq(x1_1022, x2_1029) && SEq(y1_1023, y2_1030))) {
return default;
}
rx_1024 = ((V)(System.Math.Abs(ToNum(rx_1024))));
ry_1025 = ((V)(System.Math.Abs(ToNum(ry_1025))));
if ((!(Truthy(rx_1024)) || !(Truthy(ry_1025)))) {
Invoke(@out_1021, "push", x2_1029, y2_1030);
return default;
}
r_1031 = ((V)(((ToNum(phi_1026) * System.Math.PI) / 180D)));
cs_1032 = ((V)(FdLibm.Cos(ToNum(r_1031))));
sn_1033 = ((V)(FdLibm.Sin(ToNum(r_1031))));
dx_1034 = ((V)(((ToNum(x1_1022) - ToNum(x2_1029)) / 2D)));
dy_1035 = ((V)(((ToNum(y1_1023) - ToNum(y2_1030)) / 2D)));
xp_1036 = ((V)(((ToNum(cs_1032) * ToNum(dx_1034)) + (ToNum(sn_1033) * ToNum(dy_1035)))));
yp_1037 = ((V)((((-ToNum(sn_1033)) * ToNum(dx_1034)) + (ToNum(cs_1032) * ToNum(dy_1035)))));
lam_1038 = ((V)((((ToNum(xp_1036) * ToNum(xp_1036)) / (ToNum(rx_1024) * ToNum(rx_1024))) + ((ToNum(yp_1037) * ToNum(yp_1037)) / (ToNum(ry_1025) * ToNum(ry_1025))))));
if (GtN(lam_1038, 1D)) {
s_1039 = ((V)(System.Math.Sqrt(ToNum(lam_1038))));
rx_1024 = ((V)((ToNum(rx_1024) * ToNum(s_1039))));
ry_1025 = ((V)((ToNum(ry_1025) * ToNum(s_1039))));
}
num_1040 = ((V)((((((ToNum(rx_1024) * ToNum(rx_1024)) * ToNum(ry_1025)) * ToNum(ry_1025)) - (((ToNum(rx_1024) * ToNum(rx_1024)) * ToNum(yp_1037)) * ToNum(yp_1037))) - (((ToNum(ry_1025) * ToNum(ry_1025)) * ToNum(xp_1036)) * ToNum(xp_1036)))));
den_1041 = ((V)(((((ToNum(rx_1024) * ToNum(rx_1024)) * ToNum(yp_1037)) * ToNum(yp_1037)) + (((ToNum(ry_1025) * ToNum(ry_1025)) * ToNum(xp_1036)) * ToNum(xp_1036)))));
co_1042 = ((V)(((Truthy(den_1041) ? System.Math.Sqrt(Max(0D, (ToNum(num_1040) / ToNum(den_1041)))) : 0D) * (SEq(fa_1027, fs_1028) ? (-1D) : 1D))));
cxp_1043 = ((V)((((ToNum(co_1042) * ToNum(rx_1024)) * ToNum(yp_1037)) / ToNum(ry_1025))));
cyp_1044 = ((V)(((((-ToNum(co_1042)) * ToNum(ry_1025)) * ToNum(xp_1036)) / ToNum(rx_1024))));
cx_1045 = ((V)((((ToNum(cs_1032) * ToNum(cxp_1043)) - (ToNum(sn_1033) * ToNum(cyp_1044))) + (ToNum(Add(x1_1022, x2_1029)) / 2D))));
cy_1046 = ((V)((((ToNum(sn_1033) * ToNum(cxp_1043)) + (ToNum(cs_1032) * ToNum(cyp_1044))) + (ToNum(Add(y1_1023, y2_1030)) / 2D))));
ang_1047 = Fn((V _self1055, int _argc1056, V ux_1062, V uy_1063, V vx_1064, V vy_1065, V[] _rest1057) => {
return ((V)(FdLibm.Atan2(((ToNum(ux_1062) * ToNum(vy_1065)) - (ToNum(uy_1063) * ToNum(vx_1064))), ((ToNum(ux_1062) * ToNum(vx_1064)) + (ToNum(uy_1063) * ToNum(vy_1065))))));
return default;
}, 4, "", false);
t1_1048 = Call(ang_1047, V.Undef, ((V)(1D)), ((V)(0D)), ((V)(((ToNum(xp_1036) - ToNum(cxp_1043)) / ToNum(rx_1024)))), ((V)(((ToNum(yp_1037) - ToNum(cyp_1044)) / ToNum(ry_1025)))));
dt_1049 = Call(ang_1047, V.Undef, ((V)(((ToNum(xp_1036) - ToNum(cxp_1043)) / ToNum(rx_1024)))), ((V)(((ToNum(yp_1037) - ToNum(cyp_1044)) / ToNum(ry_1025)))), ((V)((((-ToNum(xp_1036)) - ToNum(cxp_1043)) / ToNum(rx_1024)))), ((V)((((-ToNum(yp_1037)) - ToNum(cyp_1044)) / ToNum(ry_1025)))));
if ((!(Truthy(fs_1028)) && GtN(dt_1049, 0D))) {
dt_1049 = ((V)((ToNum(dt_1049) - (2D * System.Math.PI))));
} else {
if (Truthy((fs_1028 is var _t1066 && !Truthy(_t1066) ? _t1066 : (LtN(dt_1049, 0D) ? V.True : V.False)))) {
dt_1049 = Add(dt_1049, ((V)((2D * System.Math.PI))));
}
}
steps_1050 = ((V)(Max(2D, System.Math.Ceiling((System.Math.Abs(ToNum(dt_1049)) / (System.Math.PI / 8D))))));
{
i_1051 = ((V)(1D));
while (true) {
if (!(Lt(i_1051, steps_1050))) break;
t_1052 = Add(t1_1048, ((V)(((ToNum(dt_1049) * ToNum(i_1051)) / ToNum(steps_1050)))));
ex_1053 = ((V)((ToNum(rx_1024) * FdLibm.Cos(ToNum(t_1052)))));
ey_1054 = ((V)((ToNum(ry_1025) * FdLibm.Sin(ToNum(t_1052)))));
Invoke(@out_1021, "push", Add(((V)(((ToNum(cs_1032) * ToNum(ex_1053)) - (ToNum(sn_1033) * ToNum(ey_1054))))), cx_1045), Add(((V)(((ToNum(sn_1033) * ToNum(ex_1053)) + (ToNum(cs_1032) * ToNum(ey_1054))))), cy_1046));
PostInc(ref i_1051, 1D);
}
}
Invoke(@out_1021, "push", x2_1029, y2_1030);
return default;
}, 10, "arcFlat", false);
Ctx2D_78 = Fn((V _self1068, int _argc1069, V cv_1075, V _a1072, V _a1073, V _a1074, V[] _rest1070) => {
Set(_self1068, "canvas", cv_1075);
Set(_self1068, "fillStyle", ((V)("#000")));
Set(_self1068, "globalAlpha", ((V)(1D)));
return default;
}, 1, "Ctx2D", false);
install_79 = Fn((V _self1076, int _argc1077, V G_1083, V opts_1084, V _a1081, V _a1082, V[] _rest1078) => {
V html_1085 = default;
V head_1086 = default;
V body_1087 = default;
V docListeners_1088 = default;
V document_1089 = default;
V store_1090 = default;
V winListeners_1091 = default;
opts_1084 = (opts_1084 is var _t1092 && Truthy(_t1092) ? _t1092 : NewObj(0).V);
html_1085 = New(Element_18, ((V)("html")), ((V)("http://www.w3.org/1999/xhtml")));
head_1086 = New(Element_18, ((V)("head")), Get(html_1085, "namespaceURI"));
body_1087 = New(Element_18, ((V)("body")), Get(html_1085, "namespaceURI"));
Set(html_1085, "__isRoot", (true ? V.True : V.False));
Invoke(html_1085, "appendChild", head_1086);
Invoke(html_1085, "appendChild", body_1087);
docListeners_1088 = NewObj(0).V;
document_1089 = NewObj(17).Put("nodeType", ((V)(9D))).Put("readyState", ((V)("complete"))).Put("documentElement", html_1085).Put("head", head_1086).Put("body", body_1087).Put("hidden", (false ? V.True : V.False)).Put("visibilityState", ((V)("visible"))).Put("fonts", NewObj(1).Put("ready", Invoke(G("Promise"), "resolve")).V).Put("createElementNS", Fn((V _self1093, int _argc1094, V ns_1100, V tag_1101, V _a1098, V _a1099, V[] _rest1095) => {
return New(Element_18, tag_1101, ns_1100);
return default;
}, 2, "createElementNS", false)).Put("createElement", Fn((V _self1102, int _argc1103, V tag_1109, V _a1106, V _a1107, V _a1108, V[] _rest1104) => {
return New(Element_18, Invoke(((V)(ToStrS(tag_1109))), "toLowerCase"), ((V)("http://www.w3.org/1999/xhtml")));
return default;
}, 1, "createElement", false)).Put("createTextNode", Fn((V _self1110, int _argc1111, V t_1117, V _a1114, V _a1115, V _a1116, V[] _rest1112) => {
return New(Text_11, t_1117);
return default;
}, 1, "createTextNode", false)).Put("createDocumentFragment", Fn((V _self1118, int _argc1119, V _a1121, V _a1122, V _a1123, V _a1124, V[] _rest1120) => {
return New(Fragment_12);
return default;
}, 0, "createDocumentFragment", false)).Put("getElementById", Fn((V _self1125, int _argc1126, V id_1132, V _a1129, V _a1130, V _a1131, V[] _rest1127) => {
return Invoke(html_1085, "querySelector", ((V)(JsStrBuf.Begin().S("#").V(id_1132).End())));
return default;
}, 1, "getElementById", false)).Put("querySelector", Fn((V _self1133, int _argc1134, V s_1140, V _a1137, V _a1138, V _a1139, V[] _rest1135) => {
return Invoke(html_1085, "querySelector", s_1140);
return default;
}, 1, "querySelector", false)).Put("querySelectorAll", Fn((V _self1141, int _argc1142, V s_1148, V _a1145, V _a1146, V _a1147, V[] _rest1143) => {
return Invoke(html_1085, "querySelectorAll", s_1148);
return default;
}, 1, "querySelectorAll", false)).Put("addEventListener", Fn((V _self1149, int _argc1150, V t_1156, V fn_1157, V _a1154, V _a1155, V[] _rest1151) => {
Invoke(SetK(docListeners_1088, t_1156, (GetK(docListeners_1088, t_1156) is var _t1158 && Truthy(_t1158) ? _t1158 : Arr())), "push", fn_1157);
return default;
}, 2, "addEventListener", false)).Put("removeEventListener", Fn((V _self1159, int _argc1160, V _a1162, V _a1163, V _a1164, V _a1165, V[] _rest1161) => {

return default;
}, 0, "removeEventListener", false)).V;
Set(G_1083, "window", G_1083);
Set(G_1083, "self", G_1083);
Set(G_1083, "globalThis", G_1083);
Set(G_1083, "Node", Node_10);
Set(G_1083, "Element", Set(G_1083, "SVGElement", Set(G_1083, "HTMLElement", Element_18)));
Set(G_1083, "Text", Text_11);
Set(G_1083, "DocumentFragment", Fragment_12);
Set(G_1083, "document", document_1089);
Set(G_1083, "navigator", (Get(G_1083, "navigator") is var _t1173 && Truthy(_t1173) ? _t1173 : NewObj(5).Put("userAgent", ((V)("SquishRigHost"))).Put("hardwareConcurrency", ((V)(8D))).Put("deviceMemory", ((V)(4D))).Put("maxTouchPoints", ((V)(5D))).Put("vibrate", Fn((V _self1166, int _argc1167, V _a1169, V _a1170, V _a1171, V _a1172, V[] _rest1168) => {
return (false ? V.True : V.False);
return default;
}, 0, "vibrate", false)).V));
Set(G_1083, "location", (Get(G_1083, "location") is var _t1174 && Truthy(_t1174) ? _t1174 : NewObj(5).Put("protocol", ((V)("app:"))).Put("href", ((V)("app://rig/"))).Put("search", ((V)(""))).Put("hash", ((V)(""))).Put("pathname", ((V)("/"))).V));
store_1090 = NewObj(0).V;
Set(G_1083, "localStorage", (Get(G_1083, "localStorage") is var _t1207 && Truthy(_t1207) ? _t1207 : NewObj(4).Put("getItem", Fn((V _self1175, int _argc1176, V k_1182, V _a1179, V _a1180, V _a1181, V[] _rest1177) => {
return (Truthy(Invoke(Get(Get(G("Object"), "prototype"), "hasOwnProperty"), "call", store_1090, k_1182)) ? GetK(store_1090, k_1182) : V.Null);
return default;
}, 1, "getItem", false)).Put("setItem", Fn((V _self1183, int _argc1184, V k_1190, V v_1191, V _a1188, V _a1189, V[] _rest1185) => {
SetK(store_1090, k_1190, ((V)(ToStrS(v_1191))));
return default;
}, 2, "setItem", false)).Put("removeItem", Fn((V _self1192, int _argc1193, V k_1199, V _a1196, V _a1197, V _a1198, V[] _rest1194) => {
DeleteK(store_1090, k_1199);
return default;
}, 1, "removeItem", false)).Put("clear", Fn((V _self1200, int _argc1201, V _a1203, V _a1204, V _a1205, V _a1206, V[] _rest1202) => {
store_1090 = NewObj(0).V;
return default;
}, 0, "clear", false)).V));
Set(G_1083, "sessionStorage", (Get(G_1083, "sessionStorage") is var _t1208 && Truthy(_t1208) ? _t1208 : Get(G_1083, "localStorage")));
winListeners_1091 = NewObj(0).V;
Set(G_1083, "addEventListener", Fn((V _self1209, int _argc1210, V t_1216, V fn_1217, V _a1214, V _a1215, V[] _rest1211) => {
Invoke(SetK(winListeners_1091, t_1216, (GetK(winListeners_1091, t_1216) is var _t1218 && Truthy(_t1218) ? _t1218 : Arr())), "push", fn_1217);
return default;
}, 2, "", false));
Set(G_1083, "removeEventListener", Fn((V _self1219, int _argc1220, V _a1222, V _a1223, V _a1224, V _a1225, V[] _rest1221) => {

return default;
}, 0, "", false));
Set(G_1083, "dispatchEvent", Fn((V _self1226, int _argc1227, V ev_1233, V _a1230, V _a1231, V _a1232, V[] _rest1228) => {
Invoke(Invoke((GetK(winListeners_1091, Get(ev_1233, "type")) is var _t1242 && Truthy(_t1242) ? _t1242 : Arr()), "slice"), "forEach", Fn((V _self1234, int _argc1235, V f_1241, V _a1238, V _a1239, V _a1240, V[] _rest1236) => {
Call(f_1241, V.Undef, ev_1233);
return default;
}, 1, "", false));
return (true ? V.True : V.False);
return default;
}, 1, "", false));
Set(G_1083, "getComputedStyle", Fn((V _self1243, int _argc1244, V el_1250, V _a1247, V _a1248, V _a1249, V[] _rest1245) => {
return New(CStyle_68, el_1250);
return default;
}, 1, "", false));
Set(G_1083, "DOMPoint", Set(G_1083, "DOMPointReadOnly", Pt_70));
Set(G_1083, "matchMedia", Fn((V _self1251, int _argc1252, V _a1254, V _a1255, V _a1256, V _a1257, V[] _rest1253) => {
return NewObj(4).Put("matches", (false ? V.True : V.False)).Put("addListener", Fn((V _self1258, int _argc1259, V _a1261, V _a1262, V _a1263, V _a1264, V[] _rest1260) => {

return default;
}, 0, "addListener", false)).Put("removeListener", Fn((V _self1265, int _argc1266, V _a1268, V _a1269, V _a1270, V _a1271, V[] _rest1267) => {

return default;
}, 0, "removeListener", false)).Put("addEventListener", Fn((V _self1272, int _argc1273, V _a1275, V _a1276, V _a1277, V _a1278, V[] _rest1274) => {

return default;
}, 0, "addEventListener", false)).V;
return default;
}, 0, "", false));
Set(G_1083, "innerWidth", ((V)(832D)));
Set(G_1083, "innerHeight", ((V)(384D)));
Set(G_1083, "devicePixelRatio", ((V)(2.8125)));
Set(G_1083, "Image", Fn((V _self1279, int _argc1280, V _a1282, V _a1283, V _a1284, V _a1285, V[] _rest1281) => {
V e_1286 = default;
e_1286 = New(Element_18, ((V)("img")), ((V)("http://www.w3.org/1999/xhtml")));
return e_1286;
return default;
}, 0, "", false));
Set(G_1083, "console", (Get(G_1083, "console") is var _t1308 && Truthy(_t1308) ? _t1308 : NewObj(3).Put("log", Fn((V _self1287, int _argc1288, V _a1290, V _a1291, V _a1292, V _a1293, V[] _rest1289) => {

return default;
}, 0, "log", false)).Put("warn", Fn((V _self1294, int _argc1295, V _a1297, V _a1298, V _a1299, V _a1300, V[] _rest1296) => {

return default;
}, 0, "warn", false)).Put("error", Fn((V _self1301, int _argc1302, V _a1304, V _a1305, V _a1306, V _a1307, V[] _rest1303) => {

return default;
}, 0, "error", false)).V));
if (Truthy(Get(opts_1084, "readFile"))) {
Set(G_1083, "fetch", Fn((V _self1309, int _argc1310, V url_1316, V _a1313, V _a1314, V _a1315, V[] _rest1311) => {
V path_1317 = default;
path_1317 = Invoke(GetIdx(Invoke(GetIdx(Invoke(((V)(ToStrS(url_1316))), "split", ((V)("?"))), 0D), "split", ((V)("#"))), 0D), "replace", NewRegExp(RX16, "^\\.\\/", ""), ((V)("")));
return New(G("Promise"), Fn((V _self1318, int _argc1319, V res_1325, V _a1322, V _a1323, V _a1324, V[] _rest1320) => {
V text_1326 = default;
text_1326 = V.Null;
try {
text_1326 = Invoke(opts_1084, "readFile", path_1317);
} catch (System.Exception _ex1327) {
V e_1328 = default;
e_1328 = Caught(_ex1327);
text_1326 = V.Null;
}
Call(res_1325, V.Undef, NewObj(4).Put("ok", (!text_1326.IsNullish ? V.True : V.False)).Put("status", ((V)((!text_1326.IsNullish ? 200D : 404D)))).Put("text", Fn((V _self1329, int _argc1330, V _a1332, V _a1333, V _a1334, V _a1335, V[] _rest1331) => {
return Invoke(G("Promise"), "resolve", (text_1326 is var _t1336 && Truthy(_t1336) ? _t1336 : ((V)(""))));
return default;
}, 0, "text", false)).Put("json", Fn((V _self1337, int _argc1338, V _a1340, V _a1341, V _a1342, V _a1343, V[] _rest1339) => {
return Invoke(G("Promise"), "resolve", Invoke(G("JSON"), "parse", (text_1326 is var _t1344 && Truthy(_t1344) ? _t1344 : ((V)("null")))));
return default;
}, 0, "json", false)).V);
return default;
}, 1, "", false));
return default;
}, 1, "", false));
}
Set(G_1083, "__rigShim", NewObj(4).Put("Element", Element_18).Put("serialize", serialize_33).Put("canvases", CANVASES_77).Put("parseTransform", parseTransform_59).V);
return G_1083;
return default;
}, 2, "install", false);
SVG_NS_9 = ((V)("http://www.w3.org/2000/svg"));
Object_defineProperty(Get(Node_10, "prototype"), ((V)("firstChild")), NewObj(1).Put("get", Fn((V _self1345, int _argc1346, V _a1348, V _a1349, V _a1350, V _a1351, V[] _rest1347) => {
return (GetIdx(Get(_self1345, "childNodes"), 0D) is var _t1352 && Truthy(_t1352) ? _t1352 : V.Null);
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Node_10, "prototype"), ((V)("lastChild")), NewObj(1).Put("get", Fn((V _self1353, int _argc1354, V _a1356, V _a1357, V _a1358, V _a1359, V[] _rest1355) => {
return (GetIdx(Get(_self1353, "childNodes"), (ToNum(Get(Get(_self1353, "childNodes"), "length")) - 1D)) is var _t1360 && Truthy(_t1360) ? _t1360 : V.Null);
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Node_10, "prototype"), ((V)("nextSibling")), NewObj(1).Put("get", Fn((V _self1361, int _argc1362, V _a1364, V _a1365, V _a1366, V _a1367, V[] _rest1363) => {
V p_1368 = default;
V i_1369 = default;
p_1368 = Get(_self1361, "parentNode");
if (!(Truthy(p_1368))) {
return V.Null;
}
i_1369 = Invoke(Get(p_1368, "childNodes"), "indexOf", _self1361);
return (GetK(Get(p_1368, "childNodes"), Add(i_1369, ((V)(1D)))) is var _t1370 && Truthy(_t1370) ? _t1370 : V.Null);
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Node_10, "prototype"), ((V)("previousSibling")), NewObj(1).Put("get", Fn((V _self1371, int _argc1372, V _a1374, V _a1375, V _a1376, V _a1377, V[] _rest1373) => {
V p_1378 = default;
V i_1379 = default;
p_1378 = Get(_self1371, "parentNode");
if (!(Truthy(p_1378))) {
return V.Null;
}
i_1379 = Invoke(Get(p_1378, "childNodes"), "indexOf", _self1371);
return (GtN(i_1379, 0D) ? GetIdx(Get(p_1378, "childNodes"), (ToNum(i_1379) - 1D)) : V.Null);
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Node_10, "prototype"), ((V)("parentElement")), NewObj(1).Put("get", Fn((V _self1380, int _argc1381, V _a1383, V _a1384, V _a1385, V _a1386, V[] _rest1382) => {
return (Truthy((Get(_self1380, "parentNode") is var _t1387 && !Truthy(_t1387) ? _t1387 : (SEqN(Get(Get(_self1380, "parentNode"), "nodeType"), 1D) ? V.True : V.False))) ? Get(_self1380, "parentNode") : V.Null);
return default;
}, 0, "get", false)).V);
Set(Get(Node_10, "prototype"), "appendChild", Fn((V _self1388, int _argc1389, V n_1395, V _a1392, V _a1393, V _a1394, V[] _rest1390) => {
return Invoke(_self1388, "insertBefore", n_1395, V.Null);
return default;
}, 1, "", false));
Set(Get(Node_10, "prototype"), "insertBefore", Fn((V _self1396, int _argc1397, V n_1403, V @ref_1404, V _a1401, V _a1402, V[] _rest1398) => {
V kids_1405 = default;
V k_1406 = default;
V i_1407 = default;
if (SEqN(Get(n_1403, "nodeType"), 11D)) {
kids_1405 = Invoke(Get(n_1403, "childNodes"), "slice");
{
k_1406 = ((V)(0D));
while (true) {
if (!(Lt(k_1406, Get(kids_1405, "length")))) break;
Invoke(_self1396, "insertBefore", GetK(kids_1405, k_1406), @ref_1404);
PostInc(ref k_1406, 1D);
}
}
return n_1403;
}
if (Truthy(Get(n_1403, "parentNode"))) {
Invoke(Get(n_1403, "parentNode"), "removeChild", n_1403);
}
i_1407 = (Truthy(@ref_1404) ? Invoke(Get(_self1396, "childNodes"), "indexOf", @ref_1404) : ((V)((-1D))));
if (LtN(i_1407, 0D)) {
Invoke(Get(_self1396, "childNodes"), "push", n_1403);
} else {
Invoke(Get(_self1396, "childNodes"), "splice", i_1407, ((V)(0D)), n_1403);
}
Set(n_1403, "parentNode", _self1396);
return n_1403;
return default;
}, 2, "", false));
Set(Get(Node_10, "prototype"), "removeChild", Fn((V _self1409, int _argc1410, V n_1416, V _a1413, V _a1414, V _a1415, V[] _rest1411) => {
V i_1417 = default;
i_1417 = Invoke(Get(_self1409, "childNodes"), "indexOf", n_1416);
if (GeN(i_1417, 0D)) {
Invoke(Get(_self1409, "childNodes"), "splice", i_1417, ((V)(1D)));
Set(n_1416, "parentNode", V.Null);
}
return n_1416;
return default;
}, 1, "", false));
Set(Get(Node_10, "prototype"), "replaceChild", Fn((V _self1418, int _argc1419, V n_1425, V old_1426, V _a1423, V _a1424, V[] _rest1420) => {
Invoke(_self1418, "insertBefore", n_1425, old_1426);
return Invoke(_self1418, "removeChild", old_1426);
return default;
}, 2, "", false));
Set(Get(Node_10, "prototype"), "after", Fn((V _self1427, int _argc1428, V _a1430, V _a1431, V _a1432, V _a1433, V[] _rest1429) => {
V p_1435 = default;
V @ref_1436 = default;
V i_1437 = default;
V n_1438 = default;
V _arguments1434 = Arguments(_argc1428, _a1430, _a1431, _a1432, _a1433, _rest1429);
p_1435 = Get(_self1427, "parentNode");
if (!(Truthy(p_1435))) {
return default;
}
@ref_1436 = Get(_self1427, "nextSibling");
{
i_1437 = ((V)(0D));
while (true) {
if (!(Lt(i_1437, Get(_arguments1434, "length")))) break;
n_1438 = GetK(_arguments1434, i_1437);
if (string.Equals(Typeof(n_1438), "string")) {
n_1438 = New(Text_11, n_1438);
}
Invoke(p_1435, "insertBefore", n_1438, @ref_1436);
PostInc(ref i_1437, 1D);
}
}
return default;
}, 0, "", false));
Set(Get(Node_10, "prototype"), "before", Fn((V _self1440, int _argc1441, V _a1443, V _a1444, V _a1445, V _a1446, V[] _rest1442) => {
V p_1448 = default;
V i_1449 = default;
V n_1450 = default;
V _arguments1447 = Arguments(_argc1441, _a1443, _a1444, _a1445, _a1446, _rest1442);
p_1448 = Get(_self1440, "parentNode");
if (!(Truthy(p_1448))) {
return default;
}
{
i_1449 = ((V)(0D));
while (true) {
if (!(Lt(i_1449, Get(_arguments1447, "length")))) break;
n_1450 = GetK(_arguments1447, i_1449);
if (string.Equals(Typeof(n_1450), "string")) {
n_1450 = New(Text_11, n_1450);
}
Invoke(p_1448, "insertBefore", n_1450, _self1440);
PostInc(ref i_1449, 1D);
}
}
return default;
}, 0, "", false));
Set(Get(Node_10, "prototype"), "remove", Fn((V _self1452, int _argc1453, V _a1455, V _a1456, V _a1457, V _a1458, V[] _rest1454) => {
if (Truthy(Get(_self1452, "parentNode"))) {
Invoke(Get(_self1452, "parentNode"), "removeChild", _self1452);
}
return default;
}, 0, "", false));
Set(Get(Node_10, "prototype"), "compareDocumentPosition", Fn((V _self1459, int _argc1460, V other_1466, V _a1463, V _a1464, V _a1465, V[] _rest1461) => {
V a_1467 = default;
V b_1468 = default;
V n_1469 = default;
V i_1470 = default;
V p_1471 = default;
if (SEq(other_1466, _self1459)) {
return ((V)(0D));
}
a_1467 = Arr();
b_1468 = Arr();
n_1469 = _self1459;
while (Truthy(n_1469)) {
Invoke(a_1467, "unshift", n_1469);
n_1469 = Get(n_1469, "parentNode");
}
n_1469 = other_1466;
while (Truthy(n_1469)) {
Invoke(b_1468, "unshift", n_1469);
n_1469 = Get(n_1469, "parentNode");
}
if (!SEq(GetIdx(a_1467, 0D), GetIdx(b_1468, 0D))) {
return ((V)(((double)(ToInt32(1D) | ToInt32(32D)))));
}
i_1470 = ((V)(0D));
while (((Lt(i_1470, Get(a_1467, "length")) && Lt(i_1470, Get(b_1468, "length"))) && SEq(GetK(a_1467, i_1470), GetK(b_1468, i_1470)))) {
PostInc(ref i_1470, 1D);
}
if (SEq(i_1470, Get(a_1467, "length"))) {
return ((V)(((double)(ToInt32(16D) | ToInt32(4D)))));
}
if (SEq(i_1470, Get(b_1468, "length"))) {
return ((V)(((double)(ToInt32(8D) | ToInt32(2D)))));
}
p_1471 = GetIdx(a_1467, (ToNum(i_1470) - 1D));
return ((V)((Gt(Invoke(Get(p_1471, "childNodes"), "indexOf", GetK(b_1468, i_1470)), Invoke(Get(p_1471, "childNodes"), "indexOf", GetK(a_1467, i_1470))) ? 4D : 2D)));
return default;
}, 1, "", false));
Set(Get(Node_10, "prototype"), "contains", Fn((V _self1472, int _argc1473, V n_1479, V _a1476, V _a1477, V _a1478, V[] _rest1474) => {
while (Truthy(n_1479)) {
if (SEq(n_1479, _self1472)) {
return (true ? V.True : V.False);
}
n_1479 = Get(n_1479, "parentNode");
}
return (false ? V.True : V.False);
return default;
}, 1, "", false));
Set(Get(Node_10, "prototype"), "hasChildNodes", Fn((V _self1480, int _argc1481, V _a1483, V _a1484, V _a1485, V _a1486, V[] _rest1482) => {
return (GtN(Get(Get(_self1480, "childNodes"), "length"), 0D) ? V.True : V.False);
return default;
}, 0, "", false));
Set(Text_11, "prototype", Object_create(Get(Node_10, "prototype")));
Object_defineProperty(Get(Text_11, "prototype"), ((V)("textContent")), NewObj(2).Put("get", Fn((V _self1487, int _argc1488, V _a1490, V _a1491, V _a1492, V _a1493, V[] _rest1489) => {
return Get(_self1487, "data");
return default;
}, 0, "get", false)).Put("set", Fn((V _self1494, int _argc1495, V v_1501, V _a1498, V _a1499, V _a1500, V[] _rest1496) => {
Set(_self1494, "data", ((V)(ToStrS(v_1501))));
return default;
}, 1, "set", false)).V);
Object_defineProperty(Get(Text_11, "prototype"), ((V)("nodeValue")), NewObj(2).Put("get", Fn((V _self1502, int _argc1503, V _a1505, V _a1506, V _a1507, V _a1508, V[] _rest1504) => {
return Get(_self1502, "data");
return default;
}, 0, "get", false)).Put("set", Fn((V _self1509, int _argc1510, V v_1516, V _a1513, V _a1514, V _a1515, V[] _rest1511) => {
Set(_self1509, "data", ((V)(ToStrS(v_1516))));
return default;
}, 1, "set", false)).V);
Set(Get(Text_11, "prototype"), "cloneNode", Fn((V _self1517, int _argc1518, V _a1520, V _a1521, V _a1522, V _a1523, V[] _rest1519) => {
return New(Text_11, Get(_self1517, "data"));
return default;
}, 0, "", false));
Set(Fragment_12, "prototype", Object_create(Get(Node_10, "prototype")));
camel_13 = Fn((V _self1524, int _argc1525, V s_1531, V _a1528, V _a1529, V _a1530, V[] _rest1526) => {
return Invoke(Invoke(Invoke(s_1531, "trim"), "replace", NewRegExp(RX18, "^-webkit-", ""), ((V)("webkit-"))), "replace", NewRegExp(RX17, "-([a-z])", "g"), Fn((V _self1532, int _argc1533, V m_1539, V c_1540, V _a1537, V _a1538, V[] _rest1534) => {
return Invoke(c_1540, "toUpperCase");
return default;
}, 2, "", false));
return default;
}, 1, "", false);
kebab_14 = Fn((V _self1541, int _argc1542, V s_1548, V _a1545, V _a1546, V _a1547, V[] _rest1543) => {
return Invoke(Invoke(s_1548, "replace", NewRegExp(RX20, "[A-Z]", "g"), Fn((V _self1549, int _argc1550, V c_1556, V _a1553, V _a1554, V _a1555, V[] _rest1551) => {
return ((V)(JsStrBuf.Begin().S("-").V(Invoke(c_1556, "toLowerCase")).End()));
return default;
}, 1, "", false)), "replace", NewRegExp(RX19, "^webkit-", ""), ((V)("-webkit-")));
return default;
}, 1, "", false);
Object_defineProperty(Get(Style_15, "prototype"), ((V)("cssText")), NewObj(2).Put("get", Fn((V _self1557, int _argc1558, V _a1560, V _a1561, V _a1562, V _a1563, V[] _rest1559) => {
V o_1564 = default;
V k_1565 = default;
o_1564 = Arr();
{
foreach (V _k1566 in ForInKeys(_self1557)) {
k_1565 = _k1566;
if (Truthy(((Invoke(Get(Get(G("Object"), "prototype"), "hasOwnProperty"), "call", _self1557, k_1565) is var _t1567 && !Truthy(_t1567) ? _t1567 : (!SEqS(GetK(_self1557, k_1565), "") ? V.True : V.False)) is var _t1568 && !Truthy(_t1568) ? _t1568 : (!GetK(_self1557, k_1565).IsNullish ? V.True : V.False)))) {
Invoke(o_1564, "push", ((V)(JsStrBuf.Begin().V(Call(kebab_14, V.Undef, k_1565)).S(": ").V(GetK(_self1557, k_1565)).S(";").End())));
}
}
}
return Invoke(o_1564, "join", ((V)(" ")));
return default;
}, 0, "get", false)).Put("set", Fn((V _self1569, int _argc1570, V v_1576, V _a1573, V _a1574, V _a1575, V[] _rest1571) => {
V k_1577 = default;
V parts_1578 = default;
V i_1579 = default;
V j_1580 = default;
{
foreach (V _k1581 in ForInKeys(_self1569)) {
k_1577 = _k1581;
if (Truthy(Invoke(Get(Get(G("Object"), "prototype"), "hasOwnProperty"), "call", _self1569, k_1577))) {
DeleteK(_self1569, k_1577);
}
}
}
parts_1578 = Invoke(((V)(ToStrS(v_1576))), "split", ((V)(";")));
{
i_1579 = ((V)(0D));
while (true) {
if (!(Lt(i_1579, Get(parts_1578, "length")))) break;
j_1580 = Invoke(GetK(parts_1578, i_1579), "indexOf", ((V)(":")));
if (GtN(j_1580, 0D)) {
SetK(_self1569, Call(camel_13, V.Undef, Invoke(GetK(parts_1578, i_1579), "slice", ((V)(0D)), j_1580)), Invoke(Invoke(GetK(parts_1578, i_1579), "slice", Add(j_1580, ((V)(1D)))), "trim"));
}
PostInc(ref i_1579, 1D);
}
}
return default;
}, 1, "set", false)).V);
Set(Get(Style_15, "prototype"), "setProperty", Fn((V _self1583, int _argc1584, V k_1590, V v_1591, V _a1588, V _a1589, V[] _rest1585) => {
SetK(_self1583, Call(camel_13, V.Undef, k_1590), ((V)(ToStrS(v_1591))));
return default;
}, 2, "", false));
Set(Get(Style_15, "prototype"), "getPropertyValue", Fn((V _self1592, int _argc1593, V k_1599, V _a1596, V _a1597, V _a1598, V[] _rest1594) => {
return (GetK(_self1592, Call(camel_13, V.Undef, k_1599)) is var _t1600 && Truthy(_t1600) ? _t1600 : ((V)("")));
return default;
}, 1, "", false));
Set(Get(Style_15, "prototype"), "removeProperty", Fn((V _self1601, int _argc1602, V k_1608, V _a1605, V _a1606, V _a1607, V[] _rest1603) => {
V c_1609 = default;
V v_1610 = default;
c_1609 = Call(camel_13, V.Undef, k_1608);
v_1610 = (GetK(_self1601, c_1609) is var _t1611 && Truthy(_t1611) ? _t1611 : ((V)("")));
DeleteK(_self1601, c_1609);
return v_1610;
return default;
}, 1, "", false));
Set(Get(ClassList_16, "prototype"), "_get", Fn((V _self1612, int _argc1613, V _a1615, V _a1616, V _a1617, V _a1618, V[] _rest1614) => {
return Invoke(Invoke((Invoke(Get(_self1612, "el"), "getAttribute", ((V)("class"))) is var _t1619 && Truthy(_t1619) ? _t1619 : ((V)(""))), "split", NewRegExp(RX2, "\\s+", "")), "filter", G("Boolean"));
return default;
}, 0, "", false));
Set(Get(ClassList_16, "prototype"), "_set", Fn((V _self1620, int _argc1621, V a_1627, V _a1624, V _a1625, V _a1626, V[] _rest1622) => {
Invoke(Get(_self1620, "el"), "setAttribute", ((V)("class")), Invoke(a_1627, "join", ((V)(" "))));
return default;
}, 1, "", false));
Set(Get(ClassList_16, "prototype"), "contains", Fn((V _self1628, int _argc1629, V c_1635, V _a1632, V _a1633, V _a1634, V[] _rest1630) => {
return (GeN(Invoke(Invoke(_self1628, "_get"), "indexOf", c_1635), 0D) ? V.True : V.False);
return default;
}, 1, "", false));
Set(Get(ClassList_16, "prototype"), "add", Fn((V _self1636, int _argc1637, V _a1639, V _a1640, V _a1641, V _a1642, V[] _rest1638) => {
V a_1644 = default;
V i_1645 = default;
V _arguments1643 = Arguments(_argc1637, _a1639, _a1640, _a1641, _a1642, _rest1638);
a_1644 = Invoke(_self1636, "_get");
{
i_1645 = ((V)(0D));
while (true) {
if (!(Lt(i_1645, Get(_arguments1643, "length")))) break;
if (LtN(Invoke(a_1644, "indexOf", GetK(_arguments1643, i_1645)), 0D)) {
Invoke(a_1644, "push", GetK(_arguments1643, i_1645));
}
PostInc(ref i_1645, 1D);
}
}
Invoke(_self1636, "_set", a_1644);
return default;
}, 0, "", false));
Set(Get(ClassList_16, "prototype"), "remove", Fn((V _self1647, int _argc1648, V _a1650, V _a1651, V _a1652, V _a1653, V[] _rest1649) => {
V r_1655 = default;
V _arguments1654 = Arguments(_argc1648, _a1650, _a1651, _a1652, _a1653, _rest1649);
r_1655 = Invoke(Get(Arr(), "slice"), "call", _arguments1654);
Invoke(_self1647, "_set", Invoke(Invoke(_self1647, "_get"), "filter", Fn((V _self1656, int _argc1657, V c_1663, V _a1660, V _a1661, V _a1662, V[] _rest1658) => {
return (LtN(Invoke(r_1655, "indexOf", c_1663), 0D) ? V.True : V.False);
return default;
}, 1, "", false)));
return default;
}, 0, "", false));
Set(Get(ClassList_16, "prototype"), "toggle", Fn((V _self1664, int _argc1665, V c_1671, V on_1672, V _a1669, V _a1670, V[] _rest1666) => {
V has_1673 = default;
has_1673 = Invoke(_self1664, "contains", c_1671);
if (SEq(on_1672, V.Undef)) {
on_1672 = (!(Truthy(has_1673)) ? V.True : V.False);
}
if (Truthy((on_1672 is var _t1674 && !Truthy(_t1674) ? _t1674 : (!(Truthy(has_1673)) ? V.True : V.False)))) {
Invoke(_self1664, "add", c_1671);
}
if (Truthy(((!(Truthy(on_1672)) ? V.True : V.False) is var _t1675 && !Truthy(_t1675) ? _t1675 : has_1673))) {
Invoke(_self1664, "remove", c_1671);
}
return on_1672;
return default;
}, 2, "", false));
NEXT_ID_17 = ((V)(1D));
Set(Element_18, "prototype", Object_create(Get(Node_10, "prototype")));
Set(Get(Element_18, "prototype"), "setAttribute", Fn((V _self1676, int _argc1677, V k_1683, V v_1684, V _a1681, V _a1682, V[] _rest1678) => {
V i_1685 = default;
k_1683 = ((V)(ToStrS(k_1683)));
v_1684 = ((V)(ToStrS(v_1684)));
if (SEqS(k_1683, "style")) {
Set(Get(_self1676, "style"), "cssText", v_1684);
return default;
}
{
i_1685 = ((V)(0D));
while (true) {
if (!(Lt(i_1685, Get(Get(_self1676, "_attrs"), "length")))) break;
if (SEq(GetIdx(GetK(Get(_self1676, "_attrs"), i_1685), 0D), k_1683)) {
SetIdx(GetK(Get(_self1676, "_attrs"), i_1685), 1D, v_1684);
return default;
}
PostInc(ref i_1685, 1D);
}
}
Invoke(Get(_self1676, "_attrs"), "push", Arr(k_1683, v_1684));
return default;
}, 2, "", false));
Set(Get(Element_18, "prototype"), "setAttributeNS", Fn((V _self1687, int _argc1688, V ns_1694, V k_1695, V v_1696, V _a1693, V[] _rest1689) => {
Invoke(_self1687, "setAttribute", k_1695, v_1696);
return default;
}, 3, "", false));
Set(Get(Element_18, "prototype"), "getAttribute", Fn((V _self1697, int _argc1698, V k_1704, V _a1701, V _a1702, V _a1703, V[] _rest1699) => {
V s_1705 = default;
V i_1706 = default;
if (SEqS(k_1704, "style")) {
s_1705 = Get(Get(_self1697, "style"), "cssText");
return (s_1705 is var _t1707 && Truthy(_t1707) ? _t1707 : V.Null);
}
{
i_1706 = ((V)(0D));
while (true) {
if (!(Lt(i_1706, Get(Get(_self1697, "_attrs"), "length")))) break;
if (SEq(GetIdx(GetK(Get(_self1697, "_attrs"), i_1706), 0D), k_1704)) {
return GetIdx(GetK(Get(_self1697, "_attrs"), i_1706), 1D);
}
PostInc(ref i_1706, 1D);
}
}
return V.Null;
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "getAttributeNS", Fn((V _self1709, int _argc1710, V ns_1716, V k_1717, V _a1714, V _a1715, V[] _rest1711) => {
return Invoke(_self1709, "getAttribute", k_1717);
return default;
}, 2, "", false));
Set(Get(Element_18, "prototype"), "hasAttribute", Fn((V _self1718, int _argc1719, V k_1725, V _a1722, V _a1723, V _a1724, V[] _rest1720) => {
return (!SEq(Invoke(_self1718, "getAttribute", k_1725), V.Null) ? V.True : V.False);
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "removeAttribute", Fn((V _self1726, int _argc1727, V k_1733, V _a1730, V _a1731, V _a1732, V[] _rest1728) => {
V i_1734 = default;
if (SEqS(k_1733, "style")) {
Set(Get(_self1726, "style"), "cssText", ((V)("")));
return default;
}
{
i_1734 = ((V)(0D));
while (true) {
if (!(Lt(i_1734, Get(Get(_self1726, "_attrs"), "length")))) break;
if (SEq(GetIdx(GetK(Get(_self1726, "_attrs"), i_1734), 0D), k_1733)) {
Invoke(Get(_self1726, "_attrs"), "splice", i_1734, ((V)(1D)));
return default;
}
PostInc(ref i_1734, 1D);
}
}
return default;
}, 1, "", false));
Object_defineProperty(Get(Element_18, "prototype"), ((V)("attributes")), NewObj(1).Put("get", Fn((V _self1736, int _argc1737, V _a1739, V _a1740, V _a1741, V _a1742, V[] _rest1738) => {
return Invoke(Get(_self1736, "_attrs"), "map", Fn((V _self1743, int _argc1744, V a_1750, V _a1747, V _a1748, V _a1749, V[] _rest1745) => {
return NewObj(4).Put("name", GetIdx(a_1750, 0D)).Put("value", GetIdx(a_1750, 1D)).Put("nodeName", GetIdx(a_1750, 0D)).Put("nodeValue", GetIdx(a_1750, 1D)).V;
return default;
}, 1, "", false));
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("children")), NewObj(1).Put("get", Fn((V _self1751, int _argc1752, V _a1754, V _a1755, V _a1756, V _a1757, V[] _rest1753) => {
return Invoke(Get(_self1751, "childNodes"), "filter", Fn((V _self1758, int _argc1759, V n_1765, V _a1762, V _a1763, V _a1764, V[] _rest1760) => {
return (SEqN(Get(n_1765, "nodeType"), 1D) ? V.True : V.False);
return default;
}, 1, "", false));
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("childElementCount")), NewObj(1).Put("get", Fn((V _self1766, int _argc1767, V _a1769, V _a1770, V _a1771, V _a1772, V[] _rest1768) => {
return Get(Get(_self1766, "children"), "length");
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("firstElementChild")), NewObj(1).Put("get", Fn((V _self1773, int _argc1774, V _a1776, V _a1777, V _a1778, V _a1779, V[] _rest1775) => {
return (GetIdx(Get(_self1773, "children"), 0D) is var _t1780 && Truthy(_t1780) ? _t1780 : V.Null);
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("lastElementChild")), NewObj(1).Put("get", Fn((V _self1781, int _argc1782, V _a1784, V _a1785, V _a1786, V _a1787, V[] _rest1783) => {
V c_1788 = default;
c_1788 = Get(_self1781, "children");
return (GetIdx(c_1788, (ToNum(Get(c_1788, "length")) - 1D)) is var _t1789 && Truthy(_t1789) ? _t1789 : V.Null);
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("classList")), NewObj(1).Put("get", Fn((V _self1790, int _argc1791, V _a1793, V _a1794, V _a1795, V _a1796, V[] _rest1792) => {
return New(ClassList_16, _self1790);
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("id")), NewObj(2).Put("get", Fn((V _self1797, int _argc1798, V _a1800, V _a1801, V _a1802, V _a1803, V[] _rest1799) => {
return (Invoke(_self1797, "getAttribute", ((V)("id"))) is var _t1804 && Truthy(_t1804) ? _t1804 : ((V)("")));
return default;
}, 0, "get", false)).Put("set", Fn((V _self1805, int _argc1806, V v_1812, V _a1809, V _a1810, V _a1811, V[] _rest1807) => {
Invoke(_self1805, "setAttribute", ((V)("id")), v_1812);
return default;
}, 1, "set", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("className")), NewObj(2).Put("get", Fn((V _self1813, int _argc1814, V _a1816, V _a1817, V _a1818, V _a1819, V[] _rest1815) => {
return (Invoke(_self1813, "getAttribute", ((V)("class"))) is var _t1820 && Truthy(_t1820) ? _t1820 : ((V)("")));
return default;
}, 0, "get", false)).Put("set", Fn((V _self1821, int _argc1822, V v_1828, V _a1825, V _a1826, V _a1827, V[] _rest1823) => {
Invoke(_self1821, "setAttribute", ((V)("class")), v_1828);
return default;
}, 1, "set", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("textContent")), NewObj(2).Put("get", Fn((V _self1829, int _argc1830, V _a1832, V _a1833, V _a1834, V _a1835, V[] _rest1831) => {
return Invoke(Invoke(Get(_self1829, "childNodes"), "map", Fn((V _self1836, int _argc1837, V n_1843, V _a1840, V _a1841, V _a1842, V[] _rest1838) => {
return Get(n_1843, "textContent");
return default;
}, 1, "", false)), "join", ((V)("")));
return default;
}, 0, "get", false)).Put("set", Fn((V _self1844, int _argc1845, V v_1851, V _a1848, V _a1849, V _a1850, V[] _rest1846) => {
Invoke(Get(_self1844, "childNodes"), "forEach", Fn((V _self1852, int _argc1853, V n_1859, V _a1856, V _a1857, V _a1858, V[] _rest1854) => {
Set(n_1859, "parentNode", V.Null);
return default;
}, 1, "", false));
Set(_self1844, "childNodes", Arr());
if ((!SEqS(v_1851, "") && !v_1851.IsNullish)) {
Invoke(_self1844, "appendChild", New(Text_11, v_1851));
}
return default;
}, 1, "set", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("innerHTML")), NewObj(2).Put("get", Fn((V _self1860, int _argc1861, V _a1863, V _a1864, V _a1865, V _a1866, V[] _rest1862) => {
return Invoke(Invoke(Get(_self1860, "childNodes"), "map", serialize_33), "join", ((V)("")));
return default;
}, 0, "get", false)).Put("set", Fn((V _self1867, int _argc1868, V v_1874, V _a1871, V _a1872, V _a1873, V[] _rest1869) => {
Invoke(Get(_self1867, "childNodes"), "forEach", Fn((V _self1875, int _argc1876, V n_1882, V _a1879, V _a1880, V _a1881, V[] _rest1877) => {
Set(n_1882, "parentNode", V.Null);
return default;
}, 1, "", false));
Set(_self1867, "childNodes", Arr());
Call(parseInto_30, V.Undef, _self1867, ((V)(ToStrS(v_1874))), Get(_self1867, "namespaceURI"));
return default;
}, 1, "set", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("outerHTML")), NewObj(1).Put("get", Fn((V _self1883, int _argc1884, V _a1886, V _a1887, V _a1888, V _a1889, V[] _rest1885) => {
return Call(serialize_33, V.Undef, _self1883);
return default;
}, 0, "get", false)).V);
Set(Get(Element_18, "prototype"), "cloneNode", Fn((V _self1890, int _argc1891, V deep_1897, V _a1894, V _a1895, V _a1896, V[] _rest1892) => {
V e_1898 = default;
e_1898 = New(Element_18, Get(_self1890, "tagName"), Get(_self1890, "namespaceURI"));
Set(e_1898, "_attrs", Invoke(Get(_self1890, "_attrs"), "map", Fn((V _self1899, int _argc1900, V a_1906, V _a1903, V _a1904, V _a1905, V[] _rest1901) => {
return Arr(GetIdx(a_1906, 0D), GetIdx(a_1906, 1D));
return default;
}, 1, "", false)));
Set(Get(e_1898, "style"), "cssText", Get(Get(_self1890, "style"), "cssText"));
if (Truthy(deep_1897)) {
Invoke(Get(_self1890, "childNodes"), "forEach", Fn((V _self1907, int _argc1908, V c_1914, V _a1911, V _a1912, V _a1913, V[] _rest1909) => {
Invoke(e_1898, "appendChild", Invoke(c_1914, "cloneNode", (true ? V.True : V.False)));
return default;
}, 1, "", false));
}
return e_1898;
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "addEventListener", Fn((V _self1915, int _argc1916, V t_1922, V fn_1923, V _a1920, V _a1921, V[] _rest1917) => {
Invoke(SetK(Get(_self1915, "_listeners"), t_1922, (GetK(Get(_self1915, "_listeners"), t_1922) is var _t1924 && Truthy(_t1924) ? _t1924 : Arr())), "push", fn_1923);
return default;
}, 2, "", false));
Set(Get(Element_18, "prototype"), "removeEventListener", Fn((V _self1925, int _argc1926, V t_1932, V fn_1933, V _a1930, V _a1931, V[] _rest1927) => {
V a_1934 = default;
V i_1935 = default;
a_1934 = GetK(Get(_self1925, "_listeners"), t_1932);
if (Truthy(a_1934)) {
i_1935 = Invoke(a_1934, "indexOf", fn_1933);
if (GeN(i_1935, 0D)) {
Invoke(a_1934, "splice", i_1935, ((V)(1D)));
}
}
return default;
}, 2, "", false));
Set(Get(Element_18, "prototype"), "dispatchEvent", Fn((V _self1936, int _argc1937, V ev_1943, V _a1940, V _a1941, V _a1942, V[] _rest1938) => {
V a_1944 = default;
V i_1945 = default;
Set(ev_1943, "target", (Get(ev_1943, "target") is var _t1946 && Truthy(_t1946) ? _t1946 : _self1936));
a_1944 = Invoke((GetK(Get(_self1936, "_listeners"), Get(ev_1943, "type")) is var _t1947 && Truthy(_t1947) ? _t1947 : Arr()), "slice");
{
i_1945 = ((V)(0D));
while (true) {
if (!(Lt(i_1945, Get(a_1944, "length")))) break;
Invoke(GetK(a_1944, i_1945), "call", _self1936, ev_1943);
PostInc(ref i_1945, 1D);
}
}
return (true ? V.True : V.False);
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "insertAdjacentHTML", Fn((V _self1949, int _argc1950, V where_1956, V html_1957, V _a1954, V _a1955, V[] _rest1951) => {
V f_1958 = default;
f_1958 = New(Fragment_12);
Call(parseInto_30, V.Undef, f_1958, ((V)(ToStrS(html_1957))), Get(_self1949, "namespaceURI"));
if (SEqS(where_1956, "beforeend")) {
Invoke(_self1949, "appendChild", f_1958);
} else {
if (SEqS(where_1956, "afterbegin")) {
Invoke(_self1949, "insertBefore", f_1958, Get(_self1949, "firstChild"));
} else {
if (Truthy(((SEqS(where_1956, "beforebegin") ? V.True : V.False) is var _t1959 && !Truthy(_t1959) ? _t1959 : Get(_self1949, "parentNode")))) {
Invoke(Get(_self1949, "parentNode"), "insertBefore", f_1958, _self1949);
} else {
if (Truthy(((SEqS(where_1956, "afterend") ? V.True : V.False) is var _t1960 && !Truthy(_t1960) ? _t1960 : Get(_self1949, "parentNode")))) {
Invoke(Get(_self1949, "parentNode"), "insertBefore", f_1958, Get(_self1949, "nextSibling"));
}
}
}
}
return default;
}, 2, "", false));
Set(Get(Element_18, "prototype"), "insertAdjacentElement", Fn((V _self1961, int _argc1962, V where_1968, V el_1969, V _a1966, V _a1967, V[] _rest1963) => {
V f_1970 = default;
V h_1971 = default;
f_1970 = New(Fragment_12);
Invoke(f_1970, "appendChild", el_1969);
h_1971 = _self1961;
if (SEqS(where_1968, "beforeend")) {
Invoke(h_1971, "appendChild", el_1969);
} else {
if (SEqS(where_1968, "afterbegin")) {
Invoke(h_1971, "insertBefore", el_1969, Get(h_1971, "firstChild"));
} else {
if (SEqS(where_1968, "beforebegin")) {
Invoke(Get(h_1971, "parentNode"), "insertBefore", el_1969, h_1971);
} else {
Invoke(Get(h_1971, "parentNode"), "insertBefore", el_1969, Get(h_1971, "nextSibling"));
}
}
}
return el_1969;
return default;
}, 2, "", false));
Set(Get(Element_18, "prototype"), "append", Fn((V _self1972, int _argc1973, V _a1975, V _a1976, V _a1977, V _a1978, V[] _rest1974) => {
V i_1980 = default;
V a_1981 = default;
V _arguments1979 = Arguments(_argc1973, _a1975, _a1976, _a1977, _a1978, _rest1974);
{
i_1980 = ((V)(0D));
while (true) {
if (!(Lt(i_1980, Get(_arguments1979, "length")))) break;
a_1981 = GetK(_arguments1979, i_1980);
Invoke(_self1972, "appendChild", (string.Equals(Typeof(a_1981), "string") ? New(Text_11, a_1981) : a_1981));
PostInc(ref i_1980, 1D);
}
}
return default;
}, 0, "", false));
Set(Get(Element_18, "prototype"), "prepend", Fn((V _self1983, int _argc1984, V _a1986, V _a1987, V _a1988, V _a1989, V[] _rest1985) => {
V first_1991 = default;
V i_1992 = default;
V a_1993 = default;
V _arguments1990 = Arguments(_argc1984, _a1986, _a1987, _a1988, _a1989, _rest1985);
first_1991 = Get(_self1983, "firstChild");
{
i_1992 = ((V)(0D));
while (true) {
if (!(Lt(i_1992, Get(_arguments1990, "length")))) break;
a_1993 = GetK(_arguments1990, i_1992);
Invoke(_self1983, "insertBefore", (string.Equals(Typeof(a_1993), "string") ? New(Text_11, a_1993) : a_1993), first_1991);
PostInc(ref i_1992, 1D);
}
}
return default;
}, 0, "", false));
Object_defineProperty(Get(Element_18, "prototype"), ((V)("nextElementSibling")), NewObj(1).Put("get", Fn((V _self1995, int _argc1996, V _a1998, V _a1999, V _a2000, V _a2001, V[] _rest1997) => {
V n_2002 = default;
n_2002 = Get(_self1995, "nextSibling");
while (Truthy((n_2002 is var _t2003 && !Truthy(_t2003) ? _t2003 : (!SEqN(Get(n_2002, "nodeType"), 1D) ? V.True : V.False)))) {
n_2002 = Get(n_2002, "nextSibling");
}
return n_2002;
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("previousElementSibling")), NewObj(1).Put("get", Fn((V _self2004, int _argc2005, V _a2007, V _a2008, V _a2009, V _a2010, V[] _rest2006) => {
V n_2011 = default;
n_2011 = Get(_self2004, "previousSibling");
while (Truthy((n_2011 is var _t2012 && !Truthy(_t2012) ? _t2012 : (!SEqN(Get(n_2011, "nodeType"), 1D) ? V.True : V.False)))) {
n_2011 = Get(n_2011, "previousSibling");
}
return n_2011;
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("ownerSVGElement")), NewObj(1).Put("get", Fn((V _self2013, int _argc2014, V _a2016, V _a2017, V _a2018, V _a2019, V[] _rest2015) => {
V p_2020 = default;
p_2020 = Get(_self2013, "parentNode");
while (Truthy((p_2020 is var _t2021 && !Truthy(_t2021) ? _t2021 : (SEqN(Get(p_2020, "nodeType"), 1D) ? V.True : V.False)))) {
if (SEqS(Get(p_2020, "localName"), "svg")) {
return p_2020;
}
p_2020 = Get(p_2020, "parentNode");
}
return V.Null;
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("isConnected")), NewObj(1).Put("get", Fn((V _self2022, int _argc2023, V _a2025, V _a2026, V _a2027, V _a2028, V[] _rest2024) => {
V p_2029 = default;
p_2029 = _self2022;
while (Truthy(Get(p_2029, "parentNode"))) {
p_2029 = Get(p_2029, "parentNode");
}
return (!(!(Truthy(Get(p_2029, "__isRoot")))) ? V.True : V.False);
return default;
}, 0, "get", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("dataset")), NewObj(1).Put("get", Fn((V _self2030, int _argc2031, V _a2033, V _a2034, V _a2035, V _a2036, V[] _rest2032) => {
V el_2037 = default;
V o_2038 = default;
V a_2039 = default;
V i_2040 = default;
el_2037 = _self2030;
if (string.Equals(GTypeof("Proxy"), "undefined")) {
o_2038 = NewObj(0).V;
a_2039 = (Get(el_2037, "_attrs") is var _t2041 && Truthy(_t2041) ? _t2041 : Arr());
{
i_2040 = ((V)(0D));
while (true) {
if (!(Lt(i_2040, Get(a_2039, "length")))) break;
if (SEqN(Invoke(GetIdx(GetK(a_2039, i_2040), 0D), "indexOf", ((V)("data-"))), 0D)) {
SetK(o_2038, Invoke(Invoke(GetIdx(GetK(a_2039, i_2040), 0D), "slice", ((V)(5D))), "replace", NewRegExp(RX17, "-([a-z])", "g"), Fn((V _self2043, int _argc2044, V m_2050, V c_2051, V _a2048, V _a2049, V[] _rest2045) => {
return Invoke(c_2051, "toUpperCase");
return default;
}, 2, "", false)), GetIdx(GetK(a_2039, i_2040), 1D));
}
PostInc(ref i_2040, 1D);
}
}
return o_2038;
}
return New(G("Proxy"), NewObj(0).V, NewObj(3).Put("get", Fn((V _self2052, int _argc2053, V t_2059, V k_2060, V _a2057, V _a2058, V[] _rest2054) => {
V v_2061 = default;
v_2061 = Invoke(el_2037, "getAttribute", ((V)(JsStrBuf.Begin().S("data-").V(Call(kebab_14, V.Undef, ((V)(ToStrS(k_2060))))).End())));
return (SEq(v_2061, V.Null) ? V.Undef : v_2061);
return default;
}, 2, "get", false)).Put("set", Fn((V _self2062, int _argc2063, V t_2069, V k_2070, V v_2071, V _a2068, V[] _rest2064) => {
Invoke(el_2037, "setAttribute", ((V)(JsStrBuf.Begin().S("data-").V(Call(kebab_14, V.Undef, ((V)(ToStrS(k_2070))))).End())), v_2071);
return (true ? V.True : V.False);
return default;
}, 3, "set", false)).Put("deleteProperty", Fn((V _self2072, int _argc2073, V t_2079, V k_2080, V _a2077, V _a2078, V[] _rest2074) => {
Invoke(el_2037, "removeAttribute", ((V)(JsStrBuf.Begin().S("data-").V(Call(kebab_14, V.Undef, ((V)(ToStrS(k_2080))))).End())));
return (true ? V.True : V.False);
return default;
}, 2, "deleteProperty", false)).V);
return default;
}, 0, "get", false)).V);
Set(Get(Element_18, "prototype"), "setPointerCapture", Fn((V _self2081, int _argc2082, V _a2084, V _a2085, V _a2086, V _a2087, V[] _rest2083) => {

return default;
}, 0, "", false));
Set(Get(Element_18, "prototype"), "releasePointerCapture", Fn((V _self2088, int _argc2089, V _a2091, V _a2092, V _a2093, V _a2094, V[] _rest2090) => {

return default;
}, 0, "", false));
Set(Get(Element_18, "prototype"), "hasPointerCapture", Fn((V _self2095, int _argc2096, V _a2098, V _a2099, V _a2100, V _a2101, V[] _rest2097) => {
return (false ? V.True : V.False);
return default;
}, 0, "", false));
Set(Get(Element_18, "prototype"), "focus", Fn((V _self2102, int _argc2103, V _a2105, V _a2106, V _a2107, V _a2108, V[] _rest2104) => {

return default;
}, 0, "", false));
Set(Get(Element_18, "prototype"), "blur", Fn((V _self2109, int _argc2110, V _a2112, V _a2113, V _a2114, V _a2115, V[] _rest2111) => {

return default;
}, 0, "", false));
Set(Get(Element_18, "prototype"), "getBoundingClientRect", Fn((V _self2116, int _argc2117, V _a2119, V _a2120, V _a2121, V _a2122, V[] _rest2118) => {
V e_2123 = default;
V r_2124 = default;
e_2123 = _self2116;
while (Truthy((e_2123 is var _t2125 && !Truthy(_t2125) ? _t2125 : (!(Truthy(Get(e_2123, "__rect"))) ? V.True : V.False)))) {
e_2123 = Get(e_2123, "parentNode");
}
r_2124 = ((e_2123 is var _t2126 && !Truthy(_t2126) ? _t2126 : Get(e_2123, "__rect")) is var _t2127 && Truthy(_t2127) ? _t2127 : NewObj(4).Put("left", ((V)(0D))).Put("top", ((V)(0D))).Put("width", ((V)(100D))).Put("height", ((V)(100D))).V);
return NewObj(8).Put("left", Get(r_2124, "left")).Put("top", Get(r_2124, "top")).Put("x", Get(r_2124, "left")).Put("y", Get(r_2124, "top")).Put("width", Get(r_2124, "width")).Put("height", Get(r_2124, "height")).Put("right", Add(Get(r_2124, "left"), Get(r_2124, "width"))).Put("bottom", Add(Get(r_2124, "top"), Get(r_2124, "height"))).V;
return default;
}, 0, "", false));
Set(Get(Element_18, "prototype"), "getBBox", Fn((V _self2128, int _argc2129, V _a2131, V _a2132, V _a2133, V _a2134, V[] _rest2130) => {
return Call(bbox_36, V.Undef, _self2128);
return default;
}, 0, "", false));
Set(Get(Element_18, "prototype"), "matches", Fn((V _self2135, int _argc2136, V sel_2142, V _a2139, V _a2140, V _a2141, V[] _rest2137) => {
return Call(matchesList_26, V.Undef, _self2135, Call(parseSelectors_21, V.Undef, sel_2142));
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "closest", Fn((V _self2143, int _argc2144, V sel_2150, V _a2147, V _a2148, V _a2149, V[] _rest2145) => {
V s_2151 = default;
V e_2152 = default;
s_2151 = Call(parseSelectors_21, V.Undef, sel_2150);
e_2152 = _self2143;
while (Truthy((e_2152 is var _t2153 && !Truthy(_t2153) ? _t2153 : (SEqN(Get(e_2152, "nodeType"), 1D) ? V.True : V.False)))) {
if (Truthy(Call(matchesList_26, V.Undef, e_2152, s_2151))) {
return e_2152;
}
e_2152 = Get(e_2152, "parentNode");
}
return V.Null;
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "querySelectorAll", Fn((V _self2154, int _argc2155, V sel_2161, V _a2158, V _a2159, V _a2160, V[] _rest2156) => {
V s_2162 = default;
V @out_2163 = default;
s_2162 = Call(parseSelectors_21, V.Undef, sel_2161);
@out_2163 = Arr();
Call(walk_19, V.Undef, _self2154, Fn((V _self2164, int _argc2165, V e_2171, V _a2168, V _a2169, V _a2170, V[] _rest2166) => {
if (Truthy(Call(matchesList_26, V.Undef, e_2171, s_2162))) {
Invoke(@out_2163, "push", e_2171);
}
return default;
}, 1, "", false));
return @out_2163;
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "querySelector", Fn((V _self2172, int _argc2173, V sel_2179, V _a2176, V _a2177, V _a2178, V[] _rest2174) => {
V s_2180 = default;
V hit_2181 = default;
s_2180 = Call(parseSelectors_21, V.Undef, sel_2179);
hit_2181 = V.Null;
Call(walk_19, V.Undef, _self2172, Fn((V _self2182, int _argc2183, V e_2189, V _a2186, V _a2187, V _a2188, V[] _rest2184) => {
if (Truthy(((!(Truthy(hit_2181)) ? V.True : V.False) is var _t2190 && !Truthy(_t2190) ? _t2190 : Call(matchesList_26, V.Undef, e_2189, s_2180)))) {
hit_2181 = e_2189;
}
return default;
}, 1, "", false));
return hit_2181;
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "getElementsByTagName", Fn((V _self2191, int _argc2192, V t_2198, V _a2195, V _a2196, V _a2197, V[] _rest2193) => {
return Invoke(_self2191, "querySelectorAll", t_2198);
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "getElementById", Fn((V _self2199, int _argc2200, V id_2206, V _a2203, V _a2204, V _a2205, V[] _rest2201) => {
V hit_2207 = default;
hit_2207 = V.Null;
Call(walk_19, V.Undef, _self2199, Fn((V _self2208, int _argc2209, V e_2215, V _a2212, V _a2213, V _a2214, V[] _rest2210) => {
if ((!(Truthy(hit_2207)) && SEq(Invoke(e_2215, "getAttribute", ((V)("id"))), id_2206))) {
hit_2207 = e_2215;
}
return default;
}, 1, "", false));
return hit_2207;
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "getContext", Fn((V _self2216, int _argc2217, V kind_2223, V _a2220, V _a2221, V _a2222, V[] _rest2218) => {
return ((SEqS(kind_2223, "2d") && SEqS(Get(_self2216, "localName"), "canvas")) ? Set(_self2216, "_ctx", (Get(_self2216, "_ctx") is var _t2224 && Truthy(_t2224) ? _t2224 : New(Ctx2D_78, _self2216))) : V.Null);
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "toDataURL", Fn((V _self2225, int _argc2226, V _a2228, V _a2229, V _a2230, V _a2231, V[] _rest2227) => {
V id_2232 = default;
id_2232 = ((V)(JsStrBuf.Begin().S("shim-canvas:").V(Get(_self2225, "__id")).End()));
SetK(CANVASES_77, id_2232, _self2225);
return id_2232;
return default;
}, 0, "", false));
Object_defineProperty(Get(Element_18, "prototype"), ((V)("width")), NewObj(2).Put("get", Fn((V _self2233, int _argc2234, V _a2236, V _a2237, V _a2238, V _a2239, V[] _rest2235) => {
return ((V)(ToNum((Invoke(_self2233, "getAttribute", ((V)("width"))) is var _t2240 && Truthy(_t2240) ? _t2240 : ((V)((SEqS(Get(_self2233, "localName"), "canvas") ? 300D : 0D)))))));
return default;
}, 0, "get", false)).Put("set", Fn((V _self2241, int _argc2242, V v_2248, V _a2245, V _a2246, V _a2247, V[] _rest2243) => {
Invoke(_self2241, "setAttribute", ((V)("width")), v_2248);
return default;
}, 1, "set", false)).V);
Object_defineProperty(Get(Element_18, "prototype"), ((V)("height")), NewObj(2).Put("get", Fn((V _self2249, int _argc2250, V _a2252, V _a2253, V _a2254, V _a2255, V[] _rest2251) => {
return ((V)(ToNum((Invoke(_self2249, "getAttribute", ((V)("height"))) is var _t2256 && Truthy(_t2256) ? _t2256 : ((V)((SEqS(Get(_self2249, "localName"), "canvas") ? 150D : 0D)))))));
return default;
}, 0, "get", false)).Put("set", Fn((V _self2257, int _argc2258, V v_2264, V _a2261, V _a2262, V _a2263, V[] _rest2259) => {
Invoke(_self2257, "setAttribute", ((V)("height")), v_2264);
return default;
}, 1, "set", false)).V);
SEL_CACHE_20 = NewObj(0).V;
VOID_HTML_27 = NewObj(6).Put("br", ((V)(1D))).Put("img", ((V)(1D))).Put("input", ((V)(1D))).Put("hr", ((V)(1D))).Put("meta", ((V)(1D))).Put("link", ((V)(1D))).V;
ENT_28 = NewObj(6).Put("amp", ((V)("&"))).Put("lt", ((V)("<"))).Put("gt", ((V)(">"))).Put("quot", ((V)("\""))).Put("apos", ((V)("'"))).Put("nbsp", ((V)("\u00a0"))).V;
unescape_29 = Fn((V _self2265, int _argc2266, V s_2272, V _a2269, V _a2270, V _a2271, V[] _rest2267) => {
return Invoke(s_2272, "replace", NewRegExp(RX21, "&(#x[0-9a-f]+|#\\d+|[a-z]+);", "gi"), Fn((V _self2273, int _argc2274, V m_2280, V e_2281, V _a2278, V _a2279, V[] _rest2275) => {
if (SEqS(GetIdx(e_2281, 0D), "#")) {
return ((V)(String_fromCharCode(((V)(((SEqS(GetIdx(e_2281, 1D), "x") || SEqS(GetIdx(e_2281, 1D), "X")) ? ParseInt(Invoke(e_2281, "slice", ((V)(2D))), ((V)(16D))) : ToNum(Invoke(e_2281, "slice", ((V)(1D))))))))));
}
return (!GetK(ENT_28, e_2281).IsNullish ? GetK(ENT_28, e_2281) : m_2280);
return default;
}, 2, "", false));
return default;
}, 1, "", false);
escAttr_31 = Fn((V _self2282, int _argc2283, V s_2289, V _a2286, V _a2287, V _a2288, V[] _rest2284) => {
return Invoke(Invoke(Invoke(Invoke(Invoke(s_2289, "replace", NewRegExp(RX26, "&", "g"), ((V)("&amp;"))), "replace", NewRegExp(RX25, "\"", "g"), ((V)("&quot;"))), "replace", NewRegExp(RX24, "\u00a0", "g"), ((V)("&nbsp;"))), "replace", NewRegExp(RX23, "<", "g"), ((V)("&lt;"))), "replace", NewRegExp(RX22, ">", "g"), ((V)("&gt;")));
return default;
}, 1, "", false);
escText_32 = Fn((V _self2290, int _argc2291, V s_2297, V _a2294, V _a2295, V _a2296, V[] _rest2292) => {
return Invoke(Invoke(Invoke(Invoke(s_2297, "replace", NewRegExp(RX26, "&", "g"), ((V)("&amp;"))), "replace", NewRegExp(RX23, "<", "g"), ((V)("&lt;"))), "replace", NewRegExp(RX22, ">", "g"), ((V)("&gt;"))), "replace", NewRegExp(RX24, "\u00a0", "g"), ((V)("&nbsp;")));
return default;
}, 1, "", false);
F_34 = Get(G("Math"), "fround");
Invoke(Arr(((V)("x")), ((V)("y")), ((V)("width")), ((V)("height"))), "forEach", Fn((V _self2298, int _argc2299, V k_2305, V i_2306, V _a2303, V _a2304, V[] _rest2300) => {
Object_defineProperty(Get(SVGRect_35, "prototype"), k_2305, NewObj(3).Put("get", Fn((V _self2307, int _argc2308, V _a2310, V _a2311, V _a2312, V _a2313, V[] _rest2309) => {
return GetK(Get(_self2307, "_r"), i_2306);
return default;
}, 0, "get", false)).Put("set", Fn((V _self2314, int _argc2315, V v_2321, V _a2318, V _a2319, V _a2320, V[] _rest2316) => {
SetK(Get(_self2314, "_r"), i_2306, ((V)(ToNum(v_2321))));
return default;
}, 1, "set", false)).Put("enumerable", (true ? V.True : V.False)).V);
return default;
}, 2, "", false));
Object_defineProperty(Get(SVGRect_35, "prototype"), ((V)("_r")), NewObj(3).Put("writable", (true ? V.True : V.False)).Put("enumerable", (false ? V.True : V.False)).Put("value", V.Null).V);
F32_38 = New(G("Float32Array"), ((V)(1D)));
U32_39 = New(G("Uint32Array"), Get(F32_38, "buffer"));
SINZ_48 = Fn((V _self2322, int _argc2323, V r_2329, V _a2326, V _a2327, V _a2328, V[] _rest2324) => {
V v_2330 = default;
v_2330 = Call(F_34, V.Undef, ((V)(FdLibm.Sin(ToNum(r_2329)))));
return (Le(((V)(System.Math.Abs(ToNum(v_2330)))), Call(F_34, V.Undef, ((V)((1D / 4096D))))) ? ((V)(0D)) : v_2330);
return default;
}, 1, "", false);
COSZ_49 = Fn((V _self2331, int _argc2332, V r_2338, V _a2335, V _a2336, V _a2337, V[] _rest2333) => {
V v_2339 = default;
v_2339 = Call(F_34, V.Undef, ((V)(FdLibm.Cos(ToNum(r_2338)))));
return (Le(((V)(System.Math.Abs(ToNum(v_2339)))), Call(F_34, V.Undef, ((V)((1D / 4096D))))) ? ((V)(0D)) : v_2339);
return default;
}, 1, "", false);
PIF_50 = Call(F_34, V.Undef, ((V)(System.Math.PI)));
DEG_51 = Call(F_34, V.Undef, ((V)((ToNum(PIF_50) / 180D))));
CS_INH_60 = NewObj(11).Put("fill", ((V)(1D))).Put("fillOpacity", ((V)(1D))).Put("fillRule", ((V)(1D))).Put("stroke", ((V)(1D))).Put("strokeWidth", ((V)(1D))).Put("strokeOpacity", ((V)(1D))).Put("strokeDasharray", ((V)(1D))).Put("strokeLinecap", ((V)(1D))).Put("strokeLinejoin", ((V)(1D))).Put("visibility", ((V)(1D))).Put("color", ((V)(1D))).V;
CS_DEF_61 = NewObj(15).Put("fill", ((V)("#000"))).Put("fillOpacity", ((V)("1"))).Put("fillRule", ((V)("nonzero"))).Put("stroke", ((V)("none"))).Put("strokeWidth", ((V)("1"))).Put("strokeOpacity", ((V)("1"))).Put("strokeDasharray", ((V)("none"))).Put("strokeLinecap", ((V)("butt"))).Put("strokeLinejoin", ((V)("miter"))).Put("visibility", ((V)("visible"))).Put("color", ((V)("#000"))).Put("opacity", ((V)("1"))).Put("display", ((V)("inline"))).Put("stopColor", ((V)("#000"))).Put("stopOpacity", ((V)("1"))).V;
CS_PAINT_62 = NewObj(4).Put("fill", ((V)(1D))).Put("stroke", ((V)(1D))).Put("color", ((V)(1D))).Put("stopColor", ((V)(1D))).V;
CS_NUM_63 = NewObj(4).Put("fillOpacity", ((V)(1D))).Put("strokeOpacity", ((V)(1D))).Put("opacity", ((V)(1D))).Put("stopOpacity", ((V)(1D))).V;
NAMED_64 = NewObj(13).Put("black", Arr(((V)(0D)), ((V)(0D)), ((V)(0D)))).Put("white", Arr(((V)(255D)), ((V)(255D)), ((V)(255D)))).Put("red", Arr(((V)(255D)), ((V)(0D)), ((V)(0D)))).Put("green", Arr(((V)(0D)), ((V)(128D)), ((V)(0D)))).Put("blue", Arr(((V)(0D)), ((V)(0D)), ((V)(255D)))).Put("yellow", Arr(((V)(255D)), ((V)(255D)), ((V)(0D)))).Put("orange", Arr(((V)(255D)), ((V)(165D)), ((V)(0D)))).Put("pink", Arr(((V)(255D)), ((V)(192D)), ((V)(203D)))).Put("purple", Arr(((V)(128D)), ((V)(0D)), ((V)(128D)))).Put("brown", Arr(((V)(165D)), ((V)(42D)), ((V)(42D)))).Put("gray", Arr(((V)(128D)), ((V)(128D)), ((V)(128D)))).Put("grey", Arr(((V)(128D)), ((V)(128D)), ((V)(128D)))).Put("gold", Arr(((V)(255D)), ((V)(215D)), ((V)(0D)))).V;
Invoke(Object_keys(CS_DEF_61), "forEach", Fn((V _self2340, int _argc2341, V k_2347, V _a2344, V _a2345, V _a2346, V[] _rest2342) => {
Object_defineProperty(Get(CStyle_68, "prototype"), k_2347, NewObj(2).Put("get", Fn((V _self2348, int _argc2349, V _a2351, V _a2352, V _a2353, V _a2354, V[] _rest2350) => {
return (Truthy((Get(_self2348, "_el") is var _t2355 && !Truthy(_t2355) ? _t2355 : (SEqN(Get(Get(_self2348, "_el"), "nodeType"), 1D) ? V.True : V.False))) ? Call(computed_67, V.Undef, Get(_self2348, "_el"), k_2347) : GetK(CS_DEF_61, k_2347));
return default;
}, 0, "get", false)).Put("enumerable", (true ? V.True : V.False)).V);
return default;
}, 1, "", false));
Set(Get(CStyle_68, "prototype"), "getPropertyValue", Fn((V _self2356, int _argc2357, V k_2363, V _a2360, V _a2361, V _a2362, V[] _rest2358) => {
V c_2364 = default;
c_2364 = Call(camel_13, V.Undef, k_2363);
return (Truthy(Invoke(Get(Get(G("Object"), "prototype"), "hasOwnProperty"), "call", CS_DEF_61, c_2364)) ? GetK(_self2356, c_2364) : (GetK(_self2356, c_2364) is var _t2365 && Truthy(_t2365) ? _t2365 : ((V)(""))));
return default;
}, 1, "", false));
Set(Get(Mat_69, "prototype"), "multiply", Fn((V _self2366, int _argc2367, V o_2373, V _a2370, V _a2371, V _a2372, V[] _rest2368) => {
return New(Mat_69, ((V)(((ToNum(Get(_self2366, "a")) * ToNum(Get(o_2373, "a"))) + (ToNum(Get(_self2366, "c")) * ToNum(Get(o_2373, "b")))))), ((V)(((ToNum(Get(_self2366, "b")) * ToNum(Get(o_2373, "a"))) + (ToNum(Get(_self2366, "d")) * ToNum(Get(o_2373, "b")))))), ((V)(((ToNum(Get(_self2366, "a")) * ToNum(Get(o_2373, "c"))) + (ToNum(Get(_self2366, "c")) * ToNum(Get(o_2373, "d")))))), ((V)(((ToNum(Get(_self2366, "b")) * ToNum(Get(o_2373, "c"))) + (ToNum(Get(_self2366, "d")) * ToNum(Get(o_2373, "d")))))), Add(((V)(((ToNum(Get(_self2366, "a")) * ToNum(Get(o_2373, "e"))) + (ToNum(Get(_self2366, "c")) * ToNum(Get(o_2373, "f")))))), Get(_self2366, "e")), Add(((V)(((ToNum(Get(_self2366, "b")) * ToNum(Get(o_2373, "e"))) + (ToNum(Get(_self2366, "d")) * ToNum(Get(o_2373, "f")))))), Get(_self2366, "f")));
return default;
}, 1, "", false));
Set(Get(Mat_69, "prototype"), "inverse", Fn((V _self2374, int _argc2375, V _a2377, V _a2378, V _a2379, V _a2380, V[] _rest2376) => {
V det_2381 = default;
det_2381 = ((V)(((ToNum(Get(_self2374, "a")) * ToNum(Get(_self2374, "d"))) - (ToNum(Get(_self2374, "b")) * ToNum(Get(_self2374, "c"))))));
if (!(Truthy(det_2381))) {
return New(Mat_69, ((V)(double.NaN)), ((V)(double.NaN)), ((V)(double.NaN)), ((V)(double.NaN)), ((V)(double.NaN)), ((V)(double.NaN)));
}
return New(Mat_69, ((V)((ToNum(Get(_self2374, "d")) / ToNum(det_2381)))), ((V)(((-ToNum(Get(_self2374, "b"))) / ToNum(det_2381)))), ((V)(((-ToNum(Get(_self2374, "c"))) / ToNum(det_2381)))), ((V)((ToNum(Get(_self2374, "a")) / ToNum(det_2381)))), ((V)((((ToNum(Get(_self2374, "c")) * ToNum(Get(_self2374, "f"))) - (ToNum(Get(_self2374, "d")) * ToNum(Get(_self2374, "e")))) / ToNum(det_2381)))), ((V)((((ToNum(Get(_self2374, "b")) * ToNum(Get(_self2374, "e"))) - (ToNum(Get(_self2374, "a")) * ToNum(Get(_self2374, "f")))) / ToNum(det_2381)))));
return default;
}, 0, "", false));
Set(Get(Pt_70, "prototype"), "matrixTransform", Fn((V _self2382, int _argc2383, V m_2389, V _a2386, V _a2387, V _a2388, V[] _rest2384) => {
return New(Pt_70, Add(((V)(((ToNum(Get(m_2389, "a")) * ToNum(Get(_self2382, "x"))) + (ToNum(Get(m_2389, "c")) * ToNum(Get(_self2382, "y")))))), Get(m_2389, "e")), Add(((V)(((ToNum(Get(m_2389, "b")) * ToNum(Get(_self2382, "x"))) + (ToNum(Get(m_2389, "d")) * ToNum(Get(_self2382, "y")))))), Get(m_2389, "f")));
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "getCTM", Fn((V _self2390, int _argc2391, V _a2393, V _a2394, V _a2395, V _a2396, V[] _rest2392) => {
V m_2397 = default;
V e_2398 = default;
V t_2399 = default;
if (!SEq(Get(_self2390, "namespaceURI"), SVG_NS_9)) {
return V.Null;
}
if (SEqS(Get(_self2390, "localName"), "svg")) {
return New(Mat_69, ((V)(1D)), ((V)(0D)), ((V)(0D)), ((V)(1D)), ((V)(0D)), ((V)(0D)));
}
m_2397 = V.Null;
e_2398 = _self2390;
while (Truthy(((e_2398 is var _t2400 && !Truthy(_t2400) ? _t2400 : (SEqN(Get(e_2398, "nodeType"), 1D) ? V.True : V.False)) is var _t2401 && !Truthy(_t2401) ? _t2401 : (!SEqS(Get(e_2398, "localName"), "svg") ? V.True : V.False)))) {
t_2399 = Call(parseTransform_59, V.Undef, Invoke(e_2398, "getAttribute", ((V)("transform"))));
if (Truthy(t_2399)) {
m_2397 = Call(mul_58, V.Undef, t_2399, m_2397);
}
e_2398 = Get(e_2398, "parentNode");
}
if ((!(Truthy(e_2398)) || !SEqN(Get(e_2398, "nodeType"), 1D))) {
return V.Null;
}
m_2397 = (m_2397 is var _t2402 && Truthy(_t2402) ? _t2402 : Arr(((V)(1D)), ((V)(0D)), ((V)(0D)), ((V)(1D)), ((V)(0D)), ((V)(0D))));
return New(Mat_69, GetIdx(m_2397, 0D), GetIdx(m_2397, 1D), GetIdx(m_2397, 2D), GetIdx(m_2397, 3D), GetIdx(m_2397, 4D), GetIdx(m_2397, 5D));
return default;
}, 0, "", false));
Set(Get(Element_18, "prototype"), "getScreenCTM", Get(Get(Element_18, "prototype"), "getCTM"));
hostRect_71 = Get(Get(Element_18, "prototype"), "getBoundingClientRect");
Set(Get(Element_18, "prototype"), "getBoundingClientRect", Fn((V _self2403, int _argc2404, V _a2406, V _a2407, V _a2408, V _a2409, V[] _rest2405) => {
V m_2410 = default;
V b_2411 = default;
V r_2412 = default;
if (((SEq(Get(_self2403, "namespaceURI"), SVG_NS_9) && !SEqS(Get(_self2403, "localName"), "svg")) && !(Truthy(Get(_self2403, "__rect"))))) {
m_2410 = Invoke(_self2403, "getCTM");
if (Truthy(m_2410)) {
b_2411 = Call(boxOf_57, V.Undef, _self2403);
r_2412 = (Truthy(b_2411) ? Call(mapRect_43, V.Undef, Arr(Get(m_2410, "a"), Get(m_2410, "b"), Get(m_2410, "c"), Get(m_2410, "d"), Get(m_2410, "e"), Get(m_2410, "f")), b_2411) : NewObj(4).Put("x", ((V)(0D))).Put("y", ((V)(0D))).Put("w", ((V)(0D))).Put("h", ((V)(0D))).V);
return NewObj(8).Put("left", Get(r_2412, "x")).Put("top", Get(r_2412, "y")).Put("x", Get(r_2412, "x")).Put("y", Get(r_2412, "y")).Put("width", Get(r_2412, "w")).Put("height", Get(r_2412, "h")).Put("right", Add(Get(r_2412, "x"), Get(r_2412, "w"))).Put("bottom", Add(Get(r_2412, "y"), Get(r_2412, "h"))).V;
}
}
return Invoke(hostRect_71, "call", _self2403);
return default;
}, 0, "", false));
GEO_ATTRS_72 = NewObj(6).Put("rect", Arr(((V)("x")), ((V)("y")), ((V)("width")), ((V)("height")), ((V)("rx")), ((V)("ry")))).Put("circle", Arr(((V)("cx")), ((V)("cy")), ((V)("r")))).Put("ellipse", Arr(((V)("cx")), ((V)("cy")), ((V)("rx")), ((V)("ry")))).Put("line", Arr(((V)("x1")), ((V)("y1")), ((V)("x2")), ((V)("y2")))).Put("polygon", Arr(((V)("points")))).Put("polyline", Arr(((V)("points")))).V;
Set(Get(Element_18, "prototype"), "getTotalLength", Fn((V _self2413, int _argc2414, V _a2416, V _a2417, V _a2418, V _a2419, V[] _rest2415) => {
V g_2420 = default;
g_2420 = Call(geoOf_73, V.Undef, _self2413);
return (Truthy(g_2420) ? Get(g_2420, "len") : ((V)(0D)));
return default;
}, 0, "", false));
Set(Get(Element_18, "prototype"), "getPointAtLength", Fn((V _self2421, int _argc2422, V L_2428, V _a2425, V _a2426, V _a2427, V[] _rest2423) => {
V g_2429 = default;
V left_2430 = default;
V last_2431 = default;
V s_2432 = default;
V p_2433 = default;
V n_2434 = default;
V m_2435 = default;
V j_2436 = default;
V ax_2437 = default;
V ay_2438 = default;
V bx_2439 = default;
V by_2440 = default;
V sl_2441 = default;
V f_2442 = default;
g_2429 = Call(geoOf_73, V.Undef, _self2421);
if ((!(Truthy(g_2429)) || !(Truthy(Get(Get(g_2429, "subs"), "length"))))) {
return New(Pt_70, ((V)(0D)), ((V)(0D)));
}
left_2430 = ((V)(Max(0D, Min(ToNum(Get(g_2429, "len")), ToNum((((V)(ToNum(L_2428))) is var _t2443 && Truthy(_t2443) ? _t2443 : ((V)(0D))))))));
last_2431 = V.Null;
{
s_2432 = ((V)(0D));
while (true) {
if (!(Lt(s_2432, Get(Get(g_2429, "subs"), "length")))) break;
p_2433 = Get(GetK(Get(g_2429, "subs"), s_2432), "p");
n_2434 = Get(p_2433, "length");
m_2435 = (Truthy(Get(GetK(Get(g_2429, "subs"), s_2432), "closed")) ? Add(n_2434, ((V)(2D))) : n_2434);
{
j_2436 = ((V)(2D));
while (true) {
if (!(Lt(j_2436, m_2435))) break;
ax_2437 = GetIdx(p_2433, (ToNum(j_2436) - 2D));
ay_2438 = GetIdx(p_2433, (ToNum(j_2436) - 1D));
bx_2439 = GetIdx(p_2433, (ToNum(j_2436) % ToNum(n_2434)));
by_2440 = GetIdx(p_2433, (ToNum(Add(j_2436, ((V)(1D)))) % ToNum(n_2434)));
sl_2441 = ((V)(Hypot((ToNum(bx_2439) - ToNum(ax_2437)), (ToNum(by_2440) - ToNum(ay_2438)))));
if ((Le(left_2430, sl_2441) && GtN(sl_2441, 0D))) {
f_2442 = ((V)((ToNum(left_2430) / ToNum(sl_2441))));
return New(Pt_70, Add(ax_2437, ((V)(((ToNum(bx_2439) - ToNum(ax_2437)) * ToNum(f_2442))))), Add(ay_2438, ((V)(((ToNum(by_2440) - ToNum(ay_2438)) * ToNum(f_2442))))));
}
left_2430 = ((V)((ToNum(left_2430) - ToNum(sl_2441))));
last_2431 = Arr(bx_2439, by_2440);
j_2436 = Add(j_2436, ((V)(2D)));
}
}
PostInc(ref s_2432, 1D);
}
}
return (Truthy(last_2431) ? New(Pt_70, GetIdx(last_2431, 0D), GetIdx(last_2431, 1D)) : New(Pt_70, GetIdx(Get(GetIdx(Get(g_2429, "subs"), 0D), "p"), 0D), GetIdx(Get(GetIdx(Get(g_2429, "subs"), 0D), "p"), 1D)));
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "isPointInFill", Fn((V _self2446, int _argc2447, V pt_2453, V _a2450, V _a2451, V _a2452, V[] _rest2448) => {
V g_2454 = default;
V x_2455 = default;
V y_2456 = default;
V w_2457 = default;
V s_2458 = default;
V p_2459 = default;
V n_2460 = default;
V j_2461 = default;
V x1_2462 = default;
V y1_2463 = default;
V x2_2464 = default;
V y2_2465 = default;
g_2454 = Call(geoOf_73, V.Undef, _self2446);
if ((!(Truthy(g_2454)) || !(Truthy(pt_2453)))) {
return (false ? V.True : V.False);
}
x_2455 = ((V)(ToNum(Get(pt_2453, "x"))));
y_2456 = ((V)(ToNum(Get(pt_2453, "y"))));
if (!((((Ge(x_2455, Get(g_2454, "x0")) && Le(x_2455, Get(g_2454, "x1"))) && Ge(y_2456, Get(g_2454, "y0"))) && Le(y_2456, Get(g_2454, "y1"))))) {
return (false ? V.True : V.False);
}
w_2457 = ((V)(0D));
{
s_2458 = ((V)(0D));
while (true) {
if (!(Lt(s_2458, Get(Get(g_2454, "subs"), "length")))) break;
p_2459 = Get(GetK(Get(g_2454, "subs"), s_2458), "p");
n_2460 = Get(p_2459, "length");
if (LtN(n_2460, 6D)) {
goto _cont2466;
}
{
j_2461 = ((V)(0D));
while (true) {
if (!(Lt(j_2461, n_2460))) break;
x1_2462 = GetK(p_2459, j_2461);
y1_2463 = GetK(p_2459, Add(j_2461, ((V)(1D))));
x2_2464 = GetIdx(p_2459, (ToNum(Add(j_2461, ((V)(2D)))) % ToNum(n_2460)));
y2_2465 = GetIdx(p_2459, (ToNum(Add(j_2461, ((V)(3D)))) % ToNum(n_2460)));
if (Le(y1_2463, y_2456)) {
if ((Gt(y2_2465, y_2456) && ((((ToNum(x2_2464) - ToNum(x1_2462)) * (ToNum(y_2456) - ToNum(y1_2463))) - ((ToNum(x_2455) - ToNum(x1_2462)) * (ToNum(y2_2465) - ToNum(y1_2463)))) > 0D))) {
PostInc(ref w_2457, 1D);
}
} else {
if ((Le(y2_2465, y_2456) && ((((ToNum(x2_2464) - ToNum(x1_2462)) * (ToNum(y_2456) - ToNum(y1_2463))) - ((ToNum(x_2455) - ToNum(x1_2462)) * (ToNum(y2_2465) - ToNum(y1_2463)))) < 0D))) {
PostInc(ref w_2457, -1D);
}
}
j_2461 = Add(j_2461, ((V)(2D)));
}
}
_cont2466: ;
PostInc(ref s_2458, 1D);
}
}
return ((Truthy(Get(g_2454, "rule")) ? ((System.Math.Abs(ToNum(w_2457)) % 2D) == 1D) : !SEqN(w_2457, 0D)) ? V.True : V.False);
return default;
}, 1, "", false));
Set(Get(Element_18, "prototype"), "isPointInStroke", Fn((V _self2468, int _argc2469, V _a2471, V _a2472, V _a2473, V _a2474, V[] _rest2470) => {
return (false ? V.True : V.False);
return default;
}, 0, "", false));
CANVASES_77 = NewObj(0).V;
Set(Get(Ctx2D_78, "prototype"), "createImageData", Fn((V _self2475, int _argc2476, V w_2482, V h_2483, V _a2480, V _a2481, V[] _rest2477) => {
return NewObj(3).Put("width", w_2482).Put("height", h_2483).Put("data", New(G("Uint8ClampedArray"), ((V)(((ToNum(w_2482) * ToNum(h_2483)) * 4D))))).V;
return default;
}, 2, "", false));
Set(Get(Ctx2D_78, "prototype"), "putImageData", Fn((V _self2484, int _argc2485, V im_2491, V _a2488, V _a2489, V _a2490, V[] _rest2486) => {
Set(Get(_self2484, "canvas"), "_pixels", NewObj(3).Put("width", Get(im_2491, "width")).Put("height", Get(im_2491, "height")).Put("data", Get(im_2491, "data")).V);
return default;
}, 1, "", false));
Set(Get(Ctx2D_78, "prototype"), "getImageData", Fn((V _self2492, int _argc2493, V x_2499, V y_2500, V w_2501, V h_2502, V[] _rest2494) => {
V p_2503 = default;
p_2503 = Get(Get(_self2492, "canvas"), "_pixels");
return (Truthy(p_2503) ? NewObj(3).Put("width", Get(p_2503, "width")).Put("height", Get(p_2503, "height")).Put("data", Get(p_2503, "data")).V : Invoke(_self2492, "createImageData", w_2501, h_2502));
return default;
}, 4, "", false));
Set(Get(Ctx2D_78, "prototype"), "createPattern", Fn((V _self2504, int _argc2505, V src_2511, V rep_2512, V _a2509, V _a2510, V[] _rest2506) => {
return NewObj(2).Put("pattern", src_2511).Put("repeat", rep_2512).V;
return default;
}, 2, "", false));
Set(Get(Ctx2D_78, "prototype"), "fillRect", Fn((V _self2513, int _argc2514, V x_2520, V y_2521, V w_2522, V h_2523, V[] _rest2515) => {
if (Truthy((Get(_self2513, "fillStyle") is var _t2524 && !Truthy(_t2524) ? _t2524 : Get(Get(_self2513, "fillStyle"), "pattern")))) {
Set(Get(_self2513, "canvas"), "_tiled", NewObj(3).Put("src", Get(Get(_self2513, "fillStyle"), "pattern")).Put("w", w_2522).Put("h", h_2523).V);
}
return default;
}, 4, "", false));
Invoke(Arr(((V)("clearRect")), ((V)("save")), ((V)("restore")), ((V)("translate")), ((V)("scale")), ((V)("rotate")), ((V)("beginPath")), ((V)("closePath")), ((V)("moveTo")), ((V)("lineTo")), ((V)("arc")), ((V)("fill")), ((V)("stroke")), ((V)("drawImage")), ((V)("setTransform"))), "forEach", Fn((V _self2525, int _argc2526, V k_2532, V _a2529, V _a2530, V _a2531, V[] _rest2527) => {
SetK(Get(Ctx2D_78, "prototype"), k_2532, Fn((V _self2533, int _argc2534, V _a2536, V _a2537, V _a2538, V _a2539, V[] _rest2535) => {

return default;
}, 0, "", false));
return default;
}, 1, "", false));
Set(root_8, "RigDomShim", NewObj(1).Put("install", install_79).V);
return default;
}, 1, "", false), V.Undef, (!string.Equals(GTypeof("globalThis"), "undefined") ? G("globalThis") : GlobalV));
        }
    }
}
