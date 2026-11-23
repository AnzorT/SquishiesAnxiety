// One piece of the Game Park's carousel (Menu/ParkCarousel.cs): a picture (straight alpha), a card's own layer
// (premultiplied, _Straight 0) or a game clip (opaque), at _Opacity, times _Bright (CSS filter: brightness on
// premultiplied colour), optionally clipped by a mask picture's alpha (the card's window: uv2 is the mask's uv, outside
// 0..1 nothing shows). Drawn in the scene (object space) or, _IntoRt 1, into a card's layer in its pixels (y down)
// through _ParkPxToClip.
Shader "Hidden/SquishSquad/ParkPiece"
{
    Properties
    {
        _MainTex ("Picture", 2D) = "black" {}
        _Mask ("Mask", 2D) = "white" {}
        _Opacity ("Opacity", Float) = 1
        _Bright ("Brightness", Float) = 1
        _Straight ("Straight alpha", Float) = 1
        _Opaque ("Opaque", Float) = 0
        _UseMask ("Use mask", Float) = 0
        _IntoRt ("Into a layer", Float) = 0
    }
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
            sampler2D _MainTex, _Mask;
            float _Opacity, _Bright, _Straight, _Opaque, _UseMask, _IntoRt;
            float4x4 _ParkPxToClip;
            struct appdata { float4 vertex : POSITION; float2 uv : TEXCOORD0; float2 uv2 : TEXCOORD1; };
            struct v2f { float4 pos : SV_POSITION; float2 uv : TEXCOORD0; float2 uv2 : TEXCOORD1; };
            v2f vert (appdata v)
            {
                v2f o;
                o.pos = _IntoRt > 0.5 ? mul(_ParkPxToClip, float4(v.vertex.xy, 0, 1)) : UnityObjectToClipPos(v.vertex);
                o.uv = v.uv; o.uv2 = v.uv2;
                return o;
            }
            fixed4 frag (v2f i) : SV_Target
            {
                float4 c = tex2D(_MainTex, i.uv);
                if (_Opaque > 0.5) c.a = 1;
                if (_Straight > 0.5) c.rgb *= c.a;
                if (_UseMask > 0.5)
                {
                    float inside = step(0, i.uv2.x) * step(i.uv2.x, 1) * step(0, i.uv2.y) * step(i.uv2.y, 1);
                    c *= tex2D(_Mask, i.uv2).a * inside;
                }
                c.rgb = min(c.rgb * _Bright, c.aaa);
                return c * _Opacity;
            }
            ENDCG
        }
    }
}
