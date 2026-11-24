// virtual-clock.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_virtual_clock_js
    {

        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V G_8, V _a5, V _a6, V _a7, V[] _rest3) => {
V now_9 = default;
V T0_10 = default;
V seq_11 = default;
V timers_12 = default;
V raf_13 = default;
V rafSeq_14 = default;
V s_15 = default;
V perf_16 = default;
V add_17 = default;
V frame_18 = default;
add_17 = Fn((V _self19, int _argc20, V fn_26, V ms_27, V args_28, V every_29, V[] _rest21) => {
V id_30 = default;
id_30 = ((V)(PreInc(ref seq_11, 1D)));
Invoke(timers_12, "push", NewObj(5).Put("id", id_30).Put("at", Add(now_9, ((V)(Max(0D, ToNum((((V)(ToNum(ms_27))) is var _t31 && Truthy(_t31) ? _t31 : ((V)(0D))))))))).Put("fn", fn_26).Put("args", args_28).Put("every", ((V)((Truthy(every_29) ? Max(1D, ToNum((((V)(ToNum(ms_27))) is var _t32 && Truthy(_t32) ? _t32 : ((V)(0D))))) : 0D)))).V);
return id_30;
return default;
}, 4, "add", false);
frame_18 = Fn((V _self33, int _argc34, V ms_40, V _a37, V _a38, V _a39, V[] _rest35) => {
V end_41 = default;
V next_42 = default;
V i_43 = default;
V q_44 = default;
V j_45 = default;
end_41 = Add(now_9, (ms_40.IsNullish ? ((V)(16D)) : ms_40));
{
while (true) {
next_42 = V.Null;
{
i_43 = ((V)(0D));
while (true) {
if (!(Lt(i_43, Get(timers_12, "length")))) break;
if ((Le(Get(GetK(timers_12, i_43), "at"), end_41) && ((!(Truthy(next_42)) || Lt(Get(GetK(timers_12, i_43), "at"), Get(next_42, "at"))) || (SEq(Get(GetK(timers_12, i_43), "at"), Get(next_42, "at")) && Lt(Get(GetK(timers_12, i_43), "id"), Get(next_42, "id")))))) {
next_42 = GetK(timers_12, i_43);
}
PostInc(ref i_43, 1D);
}
}
if (!(Truthy(next_42))) {
break;
}
now_9 = ((V)(Max(ToNum(now_9), ToNum(Get(next_42, "at")))));
if (Truthy(Get(next_42, "every"))) {
OpSet(next_42, "at", 0, Get(next_42, "every"));
} else {
Invoke(timers_12, "splice", Invoke(timers_12, "indexOf", next_42), ((V)(1D)));
}
try {
Invoke(Get(next_42, "fn"), "apply", G_8, Get(next_42, "args"));
} catch (System.Exception _ex48) {
V e_49 = default;
e_49 = Caught(_ex48);
if (Truthy(Get(G_8, "console"))) {
Invoke(Get(G_8, "console"), "error", e_49);
}
}
}
}
now_9 = end_41;
q_44 = raf_13;
raf_13 = Arr();
{
j_45 = ((V)(0D));
while (true) {
if (!(Lt(j_45, Get(q_44, "length")))) break;
try {
Invoke(GetK(q_44, j_45), "cb", now_9);
} catch (System.Exception _ex51) {
V e_52 = default;
e_52 = Caught(_ex51);
if (Truthy(Get(G_8, "console"))) {
Invoke(Get(G_8, "console"), "error", e_52);
}
}
PostInc(ref j_45, 1D);
}
}
return default;
}, 1, "frame", false);
now_9 = ((V)(0D));
T0_10 = Invoke(G("Date"), "UTC", ((V)(2026D)), ((V)(10D)), ((V)(13D)), ((V)(12D)), ((V)(0D)), ((V)(0D)));
seq_11 = ((V)(0D));
timers_12 = Arr();
raf_13 = Arr();
rafSeq_14 = ((V)(0D));
s_15 = ((V)(49723809D));
Set(G("Math"), "random", Fn((V _self53, int _argc54, V _a56, V _a57, V _a58, V _a59, V[] _rest55) => {
s_15 = ((V)(((double)(ToInt32(ToNum(s_15)) ^ ToInt32(((double)(ToInt32(ToNum(s_15)) << (int)(ToUint32(13D) & 31))))))));
s_15 = ((V)(((double)(ToUint32(ToNum(s_15)) >> (int)(ToUint32(0D) & 31)))));
s_15 = ((V)(((double)(ToInt32(ToNum(s_15)) ^ ToInt32(((double)(ToUint32(ToNum(s_15)) >> (int)(ToUint32(17D) & 31))))))));
s_15 = ((V)(((double)(ToInt32(ToNum(s_15)) ^ ToInt32(((double)(ToInt32(ToNum(s_15)) << (int)(ToUint32(5D) & 31))))))));
s_15 = ((V)(((double)(ToUint32(ToNum(s_15)) >> (int)(ToUint32(0D) & 31)))));
return ((V)((ToNum(s_15) / 4294967296D)));
return default;
}, 0, "", false));
Set(G_8, "__realSetTimeout", (Get(G_8, "__realSetTimeout") is var _t60 && Truthy(_t60) ? _t60 : Get(G_8, "setTimeout")));
perf_16 = (Get(G_8, "performance") is var _t61 && Truthy(_t61) ? _t61 : Set(G_8, "performance", NewObj(0).V));
try {
Set(perf_16, "now", Fn((V _self62, int _argc63, V _a65, V _a66, V _a67, V _a68, V[] _rest64) => {
return now_9;
return default;
}, 0, "", false));
} catch (System.Exception _ex69) {
V e_70 = default;
e_70 = Caught(_ex69);
Object_defineProperty(G_8, ((V)("performance")), NewObj(2).Put("value", NewObj(1).Put("now", Fn((V _self71, int _argc72, V _a74, V _a75, V _a76, V _a77, V[] _rest73) => {
return now_9;
return default;
}, 0, "now", false)).V).Put("configurable", (true ? V.True : V.False)).V);
}
Set(G("Date"), "now", Fn((V _self78, int _argc79, V _a81, V _a82, V _a83, V _a84, V[] _rest80) => {
return Add(T0_10, now_9);
return default;
}, 0, "", false));
Set(G_8, "setTimeout", Fn((V _self85, int _argc86, V fn_92, V ms_93, V _a90, V _a91, V[] _rest87) => {
V _arguments94 = Arguments(_argc86, fn_92, ms_93, _a90, _a91, _rest87);
return Call(add_17, V.Undef, fn_92, ms_93, Invoke(Get(Arr(), "slice"), "call", _arguments94, ((V)(2D))), (false ? V.True : V.False));
return default;
}, 2, "", false));
Set(G_8, "setInterval", Fn((V _self95, int _argc96, V fn_102, V ms_103, V _a100, V _a101, V[] _rest97) => {
V _arguments104 = Arguments(_argc96, fn_102, ms_103, _a100, _a101, _rest97);
return Call(add_17, V.Undef, fn_102, ms_103, Invoke(Get(Arr(), "slice"), "call", _arguments104, ((V)(2D))), (true ? V.True : V.False));
return default;
}, 2, "", false));
Set(G_8, "clearTimeout", Set(G_8, "clearInterval", Fn((V _self105, int _argc106, V id_112, V _a109, V _a110, V _a111, V[] _rest107) => {
V i_113 = default;
{
i_113 = ((V)(0D));
while (true) {
if (!(Lt(i_113, Get(timers_12, "length")))) break;
if (SEq(Get(GetK(timers_12, i_113), "id"), id_112)) {
Invoke(timers_12, "splice", i_113, ((V)(1D)));
return default;
}
PostInc(ref i_113, 1D);
}
}
return default;
}, 1, "", false)));
Set(G_8, "requestAnimationFrame", Fn((V _self115, int _argc116, V cb_122, V _a119, V _a120, V _a121, V[] _rest117) => {
V id_123 = default;
id_123 = ((V)(PreInc(ref rafSeq_14, 1D)));
Invoke(raf_13, "push", NewObj(2).Put("id", id_123).Put("cb", cb_122).V);
return id_123;
return default;
}, 1, "", false));
Set(G_8, "cancelAnimationFrame", Fn((V _self124, int _argc125, V id_131, V _a128, V _a129, V _a130, V[] _rest126) => {
V i_132 = default;
{
i_132 = ((V)(0D));
while (true) {
if (!(Lt(i_132, Get(raf_13, "length")))) break;
if (SEq(Get(GetK(raf_13, i_132), "id"), id_131)) {
Invoke(raf_13, "splice", i_132, ((V)(1D)));
return default;
}
PostInc(ref i_132, 1D);
}
}
return default;
}, 1, "", false));
Set(G_8, "queueMicrotask", (Get(G_8, "queueMicrotask") is var _t142 && Truthy(_t142) ? _t142 : Fn((V _self134, int _argc135, V f_141, V _a138, V _a139, V _a140, V[] _rest136) => {
Invoke(Invoke(G("Promise"), "resolve"), "then", f_141);
return default;
}, 1, "", false)));
Set(G_8, "__clock", NewObj(3).Put("frame", frame_18).Getter("now", Fn((V _self143, int _argc144, V _a146, V _a147, V _a148, V _a149, V[] _rest145) => {
return now_9;
return default;
}, 0, "now", false)).Put("pending", Fn((V _self150, int _argc151, V _a153, V _a154, V _a155, V _a156, V[] _rest152) => {
return NewObj(2).Put("timers", Get(timers_12, "length")).Put("raf", Get(raf_13, "length")).V;
return default;
}, 0, "pending", false)).V);
return default;
}, 1, "", false), V.Undef, (!string.Equals(GTypeof("globalThis"), "undefined") ? G("globalThis") : GlobalV));
        }
    }
}
