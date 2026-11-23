// Shows a picture on a quad in the scene: a rendered piece (premultiplied colour in a RenderTexture, _Straight 0) or a
// picture with straight alpha (_Straight 1), at _Opacity.
Shader "Hidden/SquishSquad/VectorShow"
{
    Properties { _MainTex ("Picture", 2D) = "black" {} _Opacity ("Opacity", Float) = 1 _Straight ("Straight alpha", Float) = 0 }
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
            float _Opacity, _Straight;
            struct v2f { float4 pos : SV_POSITION; float2 uv : TEXCOORD0; };
            v2f vert (appdata_base v) { v2f o; o.pos = UnityObjectToClipPos(v.vertex); o.uv = v.texcoord.xy; return o; }
            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 c = tex2D(_MainTex, i.uv);
                if (_Straight > 0.5) c.rgb *= c.a;
                return c * _Opacity;
            }
            ENDCG
        }
    }
}
