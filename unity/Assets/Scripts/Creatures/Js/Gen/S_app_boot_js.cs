// app/boot.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_app_boot_js
    {

        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V append_8 = default;
if (_self1.IsNullish) _self1 = GlobalV;
append_8 = Get(Get(G("Node"), "prototype"), "appendChild");
Set(Get(G("Node"), "prototype"), "appendChild", Fn((V _self9, int _argc10, V el_16, V _a13, V _a14, V _a15, V[] _rest11) => {
if (_self9.IsNullish) _self9 = GlobalV;
if (Truthy((((((SEq(_self9, Get(G("document"), "head")) ? V.True : V.False) is var _t17 && !Truthy(_t17) ? _t17 : el_16) is var _t18 && !Truthy(_t18) ? _t18 : (SEqS(Get(el_16, "tagName"), "SCRIPT") ? V.True : V.False)) is var _t19 && !Truthy(_t19) ? _t19 : Get(el_16, "src")) is var _t20 && !Truthy(_t20) ? _t20 : (!(Truthy(Invoke(el_16, "hasAttribute", ((V)("async"))))) ? V.True : V.False)))) {
Set(el_16, "async", (false ? V.True : V.False));
}
return Invoke(append_8, "call", _self9, el_16);
return default;
}, 1, "", false));
return default;
}, 0, "", false), V.Undef);
Call(Fn((V _self21, int _argc22, V _a24, V _a25, V _a26, V _a27, V[] _rest23) => {
V nativeFetch_28 = default;
V TYPES_29 = default;
if (_self21.IsNullish) _self21 = GlobalV;
if ((!SEqS(Get(G("location"), "protocol"), "file:") || !(Truthy(Get(G("window"), "fetch"))))) {
return default;
}
nativeFetch_28 = Invoke(Get(G("window"), "fetch"), "bind", G("window"));
TYPES_29 = NewObj(12).Put("html", ((V)("text/html"))).Put("js", ((V)("text/javascript"))).Put("json", ((V)("application/json"))).Put("csv", ((V)("text/csv"))).Put("svg", ((V)("image/svg+xml"))).Put("css", ((V)("text/css"))).Put("png", ((V)("image/png"))).Put("jpg", ((V)("image/jpeg"))).Put("webp", ((V)("image/webp"))).Put("wav", ((V)("audio/wav"))).Put("mp3", ((V)("audio/mpeg"))).Put("txt", ((V)("text/plain"))).V;
Set(G("window"), "fetch", Fn((V _self30, int _argc31, V input_37, V init_38, V _a35, V _a36, V[] _rest32) => {
V raw_39 = default;
V url_40 = default;
if (_self30.IsNullish) _self30 = GlobalV;
raw_39 = (string.Equals(Typeof(input_37), "string") ? input_37 : (input_37 is var _t41 && !Truthy(_t41) ? _t41 : Get(input_37, "url")));

try {
url_40 = New(G("URL"), raw_39, Get(G("location"), "href"));
} catch (System.Exception _ex42) {
V e_43 = default;
e_43 = Caught(_ex42);
return Call(nativeFetch_28, V.Undef, input_37, init_38);
}
if (!SEqS(Get(url_40, "protocol"), "file:")) {
return Call(nativeFetch_28, V.Undef, input_37, init_38);
}
return New(G("Promise"), Fn((V _self44, int _argc45, V resolve_51, V reject_52, V _a49, V _a50, V[] _rest46) => {
V x_53 = default;
if (_self44.IsNullish) _self44 = GlobalV;
x_53 = New(G("XMLHttpRequest"));
Invoke(x_53, "open", ((V)("GET")), Get(url_40, "href"));
Set(x_53, "responseType", ((V)("arraybuffer")));
Set(x_53, "onload", Fn((V _self54, int _argc55, V _a57, V _a58, V _a59, V _a60, V[] _rest56) => {
V ok_61 = default;
V ext_62 = default;
if (_self54.IsNullish) _self54 = GlobalV;
ok_61 = ((SEqN(Get(x_53, "status"), 0D) || (GeN(Get(x_53, "status"), 200D) && LtN(Get(x_53, "status"), 300D))) ? V.True : V.False);
ext_62 = Invoke((Invoke(Invoke(Get(url_40, "pathname"), "split", ((V)("."))), "pop") is var _t63 && Truthy(_t63) ? _t63 : ((V)(""))), "toLowerCase");
Call(resolve_51, V.Undef, New(G("Response"), (Truthy(ok_61) ? Get(x_53, "response") : V.Null), NewObj(2).Put("status", (Truthy(ok_61) ? ((V)(200D)) : Get(x_53, "status"))).Put("headers", NewObj(1).Put("Content-Type", (GetK(TYPES_29, ext_62) is var _t64 && Truthy(_t64) ? _t64 : ((V)("application/octet-stream")))).V).V));
return default;
}, 0, "", false));
Set(x_53, "onerror", Fn((V _self65, int _argc66, V _a68, V _a69, V _a70, V _a71, V[] _rest67) => {
if (_self65.IsNullish) _self65 = GlobalV;
Call(resolve_51, V.Undef, New(G("Response"), V.Null, NewObj(2).Put("status", ((V)(404D))).Put("statusText", ((V)("Not Found"))).V));
return default;
}, 0, "", false));
Invoke(x_53, "send");
return default;
}, 2, "", false));
return default;
}, 2, "", false));
return default;
}, 0, "", false), V.Undef);
        }
    }
}
