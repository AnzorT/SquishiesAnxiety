// Shows a picture on a quad in the scene: a rendered piece (premultiplied colour in a RenderTexture, _Straight 0) or a
// picture with straight alpha (_Straight 1), at _Opacity; its colour times _Tint and saturated by _Sat (both 1: as is;
// the game intro's night light on Mittens, CSS brightness / saturate).
Shader "Hidden/SquishSquad/VectorShow"
{
    Properties { _MainTex ("Picture", 2D) = "black" {} _Opacity ("Opacity", Float) = 1 _Straight ("Straight alpha", Float) = 0 _Tint ("Tint", Color) = (1,1,1,1) _Sat ("Saturation", Float) = 1 }
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
            float _Opacity, _Straight, _Sat;
            fixed4 _Tint;
            struct v2f { float4 pos : SV_POSITION; float2 uv : TEXCOORD0; };
            v2f vert (appdata_base v) { v2f o; o.pos = UnityObjectToClipPos(v.vertex); o.uv = v.texcoord.xy; return o; }
            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 c = tex2D(_MainTex, i.uv);
                if (_Straight > 0.5) c.rgb *= c.a;
                float l = dot(c.rgb, float3(0.2126, 0.7152, 0.0722));
                c.rgb = lerp(float3(l, l, l), c.rgb, _Sat) * _Tint.rgb;
                return c * _Opacity;
            }
            ENDCG
        }
    }
}
