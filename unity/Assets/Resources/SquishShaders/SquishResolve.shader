// Supersample.js's final pass (src/components/Supersample.js), line by line: each stage pixel samples the 2x target
// bilinearly at its centre with the sRGB texels decoded first (what a WebGL sRGB8 texture does; Unity in Gamma space
// stores them as plain ARGB32, so the decode is done here, texel by texel), multiplies by HEADROOM (the quad's colour
// 4, 4, 4), applies three's Neutral tone mapping and sRGBTransferOETF, and blends premultiplied (One,
// OneMinusSrcAlpha) over the page: the stage's quad (SquishStage) in the UI camera's scene.
Shader "Hidden/SquishSquad/SquishResolve"
{
    Properties { _MainTex ("Target", 2D) = "black" {} _Headroom ("Headroom", Float) = 4 _Opacity ("Opacity", Float) = 1 }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" "IgnoreProjector" = "True" }
        Cull Off ZWrite Off ZTest Always Lighting Off
        Blend One OneMinusSrcAlpha
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 3.0
            #include "UnityCG.cginc"
            sampler2D _MainTex;
            float4 _MainTex_TexelSize;   // 1/w, 1/h, w, h
            float _Headroom, _Opacity;
            struct v2f { float4 pos : SV_POSITION; float2 uv : TEXCOORD0; };
            v2f vert (appdata_base v) { v2f o; o.pos = UnityObjectToClipPos(v.vertex); o.uv = v.texcoord.xy; return o; }

            float3 decodeExact(float3 c) { return lerp(pow((c + 0.055) / 1.055, 2.4), c / 12.92, step(c, 0.04045)); }
            float4 texel(float2 xy)
            {
                xy = clamp(xy, 0, _MainTex_TexelSize.zw - 1);
                float4 t = tex2Dlod(_MainTex, float4((xy + 0.5) * _MainTex_TexelSize.xy, 0, 0));
                return float4(decodeExact(t.rgb), t.a);
            }
            float3 NeutralToneMapping(float3 color)
            {
                const float StartCompression = 0.8 - 0.04;
                const float Desaturation = 0.15;
                float x = min(color.r, min(color.g, color.b));
                float offset = x < 0.08 ? x - 6.25 * x * x : 0.04;
                color -= offset;
                float peak = max(color.r, max(color.g, color.b));
                if (peak < StartCompression) return color;
                float d = 1. - StartCompression;
                float newPeak = 1. - d * d / (peak + d - StartCompression);
                color *= newPeak / peak;
                float g = 1. - 1. / (Desaturation * (peak - newPeak) + 1.);
                return lerp(color, newPeak.xxx, g);
            }
            float3 sRGBTransferOETF(float3 v) { return lerp(pow(v, 0.41666) * 1.055 - 0.055, v * 12.92, step(v, 0.0031308)); }

            fixed4 frag (v2f i) : SV_Target
            {
                // bilinear at the pixel's centre, on the decoded texels (the target is point-filtered)
                float2 f = i.uv * _MainTex_TexelSize.zw - 0.5;
                float2 b = floor(f), a = f - b;
                float4 c = lerp(lerp(texel(b), texel(b + float2(1, 0)), a.x), lerp(texel(b + float2(0, 1)), texel(b + float2(1, 1)), a.x), a.y);
                float3 rgb = NeutralToneMapping(c.rgb * _Headroom);
                rgb = sRGBTransferOETF(max(rgb, 0));
                return float4(rgb, c.a) * _Opacity;
            }
            ENDCG
        }
    }
}
