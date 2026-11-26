// The home theater's film on its quad (House/View/HouseMovieView.cs) with the screen tier's CSS filter (movies.js look):
// blur(r) as a 3 x 3 Gaussian of _Blur texels' sigma, then contrast(_Contrast), saturate(_Saturate) and
// brightness(_Bright) as the CSS filter functions compute them (Filter Effects: contrast's (c - 0.5) * k + 0.5, the
// saturate matrix, a scale); the vertex colour's alpha fades it in (the film's own alpha is 1).
Shader "Hidden/SquishSquad/MovieFilm"
{
    Properties { _MainTex ("Film", 2D) = "black" {} _Contrast ("Contrast", Float) = 1 _Saturate ("Saturate", Float) = 1 _Bright ("Brightness", Float) = 1 _Blur ("Blur sigma (texels)", Float) = 0 }
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
            #include "UnityCG.cginc"
            sampler2D _MainTex;
            float4 _MainTex_TexelSize;
            float _Contrast, _Saturate, _Bright, _Blur;
            struct a2v { float4 vertex : POSITION; float2 uv : TEXCOORD0; float4 color : COLOR; };
            struct v2f { float4 pos : SV_POSITION; float2 uv : TEXCOORD0; float4 color : COLOR; };
            v2f vert (a2v v) { v2f o; o.pos = UnityObjectToClipPos(v.vertex); o.uv = v.uv; o.color = v.color; return o; }
            fixed4 frag (v2f i) : SV_Target
            {
                float3 c = tex2D(_MainTex, i.uv).rgb;
                if (_Blur > 0.01)
                {
                    float2 t = _MainTex_TexelSize.xy;
                    float k = 1.0 / (2.0 * _Blur * _Blur), w1 = exp(-k), w2 = exp(-2.0 * k);
                    float3 e = tex2D(_MainTex, i.uv + float2(t.x, 0)).rgb + tex2D(_MainTex, i.uv - float2(t.x, 0)).rgb
                             + tex2D(_MainTex, i.uv + float2(0, t.y)).rgb + tex2D(_MainTex, i.uv - float2(0, t.y)).rgb;
                    float3 d = tex2D(_MainTex, i.uv + t).rgb + tex2D(_MainTex, i.uv - t).rgb
                             + tex2D(_MainTex, i.uv + float2(t.x, -t.y)).rgb + tex2D(_MainTex, i.uv + float2(-t.x, t.y)).rgb;
                    c = (c + w1 * e + w2 * d) / (1.0 + 4.0 * w1 + 4.0 * w2);
                }
                c = saturate((c - 0.5) * _Contrast + 0.5);
                float s = _Saturate;
                float3x3 S = float3x3(0.213 + 0.787 * s, 0.715 - 0.715 * s, 0.072 - 0.072 * s,
                                      0.213 - 0.213 * s, 0.715 + 0.285 * s, 0.072 - 0.072 * s,
                                      0.213 - 0.213 * s, 0.715 - 0.715 * s, 0.072 + 0.928 * s);
                c = saturate(mul(S, c));
                c = saturate(c * _Bright);
                float a = i.color.a;
                return fixed4(c * i.color.rgb * a, a);
            }
            ENDCG
        }
    }
}
