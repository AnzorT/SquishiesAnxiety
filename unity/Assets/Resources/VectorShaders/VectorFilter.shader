// SVG filter primitives as full-target passes (output px quad; _MainTex = in, _SecondTex = in2). Everything between
// ToLinear and ToSrgb is premultiplied linearRGB, the SVG default for filters. VectorRenderer chains the passes.
Shader "Hidden/SquishSquad/VectorFilter"
{
    Properties { _MainTex ("In", 2D) = "black" {} _SecondTex ("In2", 2D) = "black" {} }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        Cull Off ZWrite Off ZTest Always Blend Off
        CGINCLUDE
        #include "UnityCG.cginc"
        float4x4 _PxToClip;
        float4 _Size;                      // target w, h
        sampler2D _MainTex, _SecondTex;
        float4 _M0, _M1, _M2, _M3, _M4;    // colour matrix rows (r, g, b, a), _M4 = offsets
        float4 _K;                         // composite: ka, kb (in, in2 factors use alphas, see Composite); blend mode in _K.x
        float4 _P;                         // per-pass numbers (displacement scale / channels, blur direction and sigma, offset)
        float4 _Img0, _Img1;               // image: px -> uv (2x3 rows)
        float4 _Rect;                      // region clip, px: x0 y0 x1 y1
        float4 _Color;
        struct v2f { float4 pos : SV_POSITION; float2 uv : TEXCOORD0; float2 px : TEXCOORD1; };
        v2f vert (float3 px : POSITION) { v2f o; o.pos = mul(_PxToClip, float4(px.xy, 0, 1)); o.px = px.xy; o.uv = float2(px.x / _Size.x, 1 - px.y / _Size.y); return o; }
        float lin1 (float c) { return c <= 0.04045 ? c / 12.92 : pow((c + 0.055) / 1.055, 2.4); }
        float srgb1 (float c) { return c <= 0.0031308 ? c * 12.92 : 1.055 * pow(c, 1 / 2.4) - 0.055; }
        float3 toLin (float3 c) { return float3(lin1(c.r), lin1(c.g), lin1(c.b)); }
        float3 toSrgb (float3 c) { return float3(srgb1(c.r), srgb1(c.g), srgb1(c.b)); }
        float4 at (sampler2D t, float2 uv) { return tex2Dlod(t, float4(uv, 0, 0)); }
        float4 unpre (float4 c) { return c.a > 0 ? float4(c.rgb / c.a, c.a) : 0; }
        float2 uvOf (float2 px) { return float2(px.x / _Size.x, 1 - px.y / _Size.y); }
        ENDCG
        // 0 ToLinear
        Pass { CGPROGRAM
            #pragma vertex vert
            #pragma fragment f
            float4 f (v2f i) : SV_Target { float4 c = unpre(tex2D(_MainTex, i.uv)); return float4(toLin(saturate(c.rgb)) * c.a, c.a); }
            ENDCG }
        // 1 ToSrgb
        Pass { CGPROGRAM
            #pragma vertex vert
            #pragma fragment f
            float4 f (v2f i) : SV_Target { float4 c = unpre(tex2D(_MainTex, i.uv)); c.a = saturate(c.a); return float4(toSrgb(saturate(c.rgb)) * c.a, c.a); }
            ENDCG }
        // 2 ColorMatrix (on straight colour)
        Pass { CGPROGRAM
            #pragma vertex vert
            #pragma fragment f
            float4 f (v2f i) : SV_Target
            {
                float4 c = unpre(tex2D(_MainTex, i.uv));
                float4 o = float4(dot(_M0, c), dot(_M1, c), dot(_M2, c), dot(_M3, c)) + _M4;
                o = saturate(o);
                return float4(o.rgb * o.a, o.a);
            }
            ENDCG }
        // 3 Composite: in x ka(alpha of in2) + in2 x kb(alpha of in); _K = (op) 0 over 1 in 2 out 3 atop 4 xor
        Pass { CGPROGRAM
            #pragma vertex vert
            #pragma fragment f
            float4 f (v2f i) : SV_Target
            {
                float4 a = tex2D(_MainTex, i.uv), b = tex2D(_SecondTex, i.uv);
                float op = _K.x, ka = 1, kb = 1 - a.a;
                if (op > 0.5 && op < 1.5) { ka = b.a; kb = 0; }
                else if (op > 1.5 && op < 2.5) { ka = 1 - b.a; kb = 0; }
                else if (op > 2.5 && op < 3.5) { ka = b.a; kb = 1 - a.a; }
                else if (op > 3.5) { ka = 1 - b.a; kb = 1 - a.a; }
                return a * ka + b * kb;
            }
            ENDCG }
        // 4 Blend (in over in2): _K.x 0 normal 1 multiply 2 screen
        Pass { CGPROGRAM
            #pragma vertex vert
            #pragma fragment f
            float4 f (v2f i) : SV_Target
            {
                float4 a = tex2D(_MainTex, i.uv), b = tex2D(_SecondTex, i.uv);
                float3 c = (1 - a.a) * b.rgb + a.rgb;
                if (_K.x > 0.5 && _K.x < 1.5) c = (1 - a.a) * b.rgb + (1 - b.a) * a.rgb + a.rgb * b.rgb;
                else if (_K.x > 1.5) c = b.rgb + a.rgb - a.rgb * b.rgb;
                return float4(c, 1 - (1 - a.a) * (1 - b.a));
            }
            ENDCG }
        // 5 Displacement: in moved by in2's channels _P.y (x) / _P.z (y) (0-3 = r g b a), _P.x px of scale
        Pass { CGPROGRAM
            #pragma vertex vert
            #pragma fragment f
            float pick (float4 c, float k) { return k < 0.5 ? c.r : k < 1.5 ? c.g : k < 2.5 ? c.b : c.a; }
            float4 f (v2f i) : SV_Target
            {
                float4 m = tex2D(_SecondTex, i.uv), s = unpre(m);
                float dx = (( _P.y > 2.5 ? m.a : pick(s, _P.y)) - 0.5) * _P.x, dy = ((_P.z > 2.5 ? m.a : pick(s, _P.z)) - 0.5) * _P.x;
                float2 px = i.px + float2(dx, dy);
                if (px.x < 0 || px.y < 0 || px.x > _Size.x || px.y > _Size.y) return 0;
                return at(_MainTex, uvOf(px));
            }
            ENDCG }
        // 6 Gaussian blur along _P.xy (direction in px), sigma _P.z px
        Pass { CGPROGRAM
            #pragma vertex vert
            #pragma fragment f
            float4 f (v2f i) : SV_Target
            {
                float sigma = max(_P.z, 0.001);
                int r = min(48, (int)ceil(sigma * 3));
                float4 sum = 0; float w = 0;
                [loop] for (int k = -48; k <= 48; k++)
                {
                    if (k < -r || k > r) continue;
                    float g = exp(-k * k / (2 * sigma * sigma));
                    sum += at(_MainTex, uvOf(i.px + _P.xy * k)) * g; w += g;
                }
                return sum / w;
            }
            ENDCG }
        // 7 Image: _MainTex at px -> uv (_Img0/_Img1), repeating; straight sRGB in, premultiplied linear out
        Pass { CGPROGRAM
            #pragma vertex vert
            #pragma fragment f
            float4 f (v2f i) : SV_Target
            {
                float2 uv = float2(dot(_Img0.xy, i.px) + _Img0.z, dot(_Img1.xy, i.px) + _Img1.z);
                if (_Img0.w > 0.5 && (uv.x < 0 || uv.y < 0 || uv.x > 1 || uv.y > 1)) return 0;
                float4 c = tex2D(_MainTex, uv * _P.xy);
                return float4(toLin(c.rgb) * c.a, c.a);
            }
            ENDCG }
        // 8 Flood: _Color (straight sRGB + opacity)
        Pass { CGPROGRAM
            #pragma vertex vert
            #pragma fragment f
            float4 f (v2f i) : SV_Target { return float4(toLin(_Color.rgb) * _Color.a, _Color.a); }
            ENDCG }
        // 9 Offset by _P.xy px
        Pass { CGPROGRAM
            #pragma vertex vert
            #pragma fragment f
            float4 f (v2f i) : SV_Target { float2 px = i.px - _P.xy; if (px.x < 0 || px.y < 0 || px.x > _Size.x || px.y > _Size.y) return 0; return tex2D(_MainTex, uvOf(px)); }
            ENDCG }
        // 10 Merge: in over in2
        Pass { CGPROGRAM
            #pragma vertex vert
            #pragma fragment f
            float4 f (v2f i) : SV_Target { float4 a = tex2D(_MainTex, i.uv), b = tex2D(_SecondTex, i.uv); return a + b * (1 - a.a); }
            ENDCG }
        // 11 Region: zero outside _Rect (px)
        Pass { CGPROGRAM
            #pragma vertex vert
            #pragma fragment f
            float4 f (v2f i) : SV_Target
            {
                float inside = step(_Rect.x, i.px.x) * step(i.px.x, _Rect.z) * step(_Rect.y, i.px.y) * step(i.px.y, _Rect.w);
                return tex2D(_MainTex, i.uv) * inside;
            }
            ENDCG }
    }
}
