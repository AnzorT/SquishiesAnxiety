// The Best Friend stage's extras on the card (squishCard.js cardState): the crown (MeshBasicMaterial with the crown
// picture, transparent, alphaTest 0.1, double-sided) and the gold glow behind (MeshBasicMaterial 0xffd24a, transparent,
// opacity pulsing, no depth write). Unlit: their linear colour as is (three doesn't divide a basic material by
// Supersample's HEADROOM, so they come out 4x in the resolve, as in the app). Drawn into the same 2x target as the
// card and encoded to sRGB like it; the blend is done on the encoded values (WebGL blends an sRGB target in linear
// light: a small difference at the glow's and the crown's soft edges).
Shader "Hidden/SquishSquad/SquishBasic"
{
    Properties { _MainTex ("Picture", 2D) = "white" {} _Color ("Linear colour", Color) = (1, 1, 1, 1) _AlphaTest ("Alpha test", Float) = 0 }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        Cull Off ZWrite Off ZTest LEqual Lighting Off
        Blend SrcAlpha OneMinusSrcAlpha, One OneMinusSrcAlpha
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            sampler2D _MainTex;
            float4 _Color;
            float _AlphaTest, _Decode;
            float4x4 _SqClip;
            struct appdata { float4 vertex : POSITION; float2 uv : TEXCOORD0; };
            struct v2f { float4 pos : SV_POSITION; float2 uv : TEXCOORD0; };
            v2f vert (appdata v) { v2f o; o.pos = mul(_SqClip, float4(v.vertex.xyz, 1.0)); o.uv = v.uv; return o; }
            float3 decodeExact(float3 c) { return lerp(pow((c + 0.055) / 1.055, 2.4), c / 12.92, step(c, 0.04045)); }
            float3 encodeTarget(float3 c) { c = saturate(c); return lerp(1.055 * pow(c, 0.41666) - 0.055, c * 12.92, step(c, 0.0031308)); }
            fixed4 frag (v2f i) : SV_Target
            {
                float4 t = tex2D(_MainTex, i.uv);
                // the crown is an sRGB texture (three decodes it on sampling)
                if (_Decode > 0.5) t.rgb = decodeExact(t.rgb);
                float4 c = _Color * t;
                if (c.a < _AlphaTest) discard;
                return float4(encodeTarget(c.rgb), c.a);
            }
            ENDCG
        }
    }
}
