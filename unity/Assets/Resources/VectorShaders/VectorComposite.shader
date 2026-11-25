// A finished layer onto the one below: its pixels x opacity x clip coverage (alpha of _Clip) x mask (luminance x
// alpha of _Mask, zero outside _MaskRect), premultiplied "over". Drawn as a full-target quad in output pixels.
Shader "Hidden/SquishSquad/VectorComposite"
{
    // (no Properties: _MainTex, _Clip and _Mask come as globals from VectorRenderer's command buffer, and a property
    //  declared here would be the material's own default instead: every layer black. _DstBlend is a plain number:
    //  OneMinusSrcAlpha (10), "over"; VectorRenderer's additive copy sets One (1): plus-lighter)
    Properties { _DstBlend ("Dst blend", Float) = 10 }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        Cull Off ZWrite Off ZTest Always
        Blend One [_DstBlend]
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            float4x4 _PxToClip;
            float4 _Size, _MaskRect;
            sampler2D _MainTex, _Clip, _Mask;
            float _Opacity, _UseClip, _UseMask;
            struct v2f { float4 pos : SV_POSITION; float2 px : TEXCOORD0; float2 uv : TEXCOORD1; };
            v2f vert (float3 px : POSITION) { v2f o; o.pos = mul(_PxToClip, float4(px.xy, 0, 1)); o.px = px.xy; o.uv = float2(px.x / _Size.x, 1 - px.y / _Size.y); return o; }
            fixed4 frag (v2f i) : SV_Target
            {
                float4 c = tex2D(_MainTex, i.uv) * _Opacity;
                if (_UseClip > 0.5) c *= tex2D(_Clip, i.uv).a;
                if (_UseMask > 0.5)
                {
                    float4 m = tex2D(_Mask, i.uv);
                    float inside = step(_MaskRect.x, i.px.x) * step(i.px.x, _MaskRect.z) * step(_MaskRect.y, i.px.y) * step(i.px.y, _MaskRect.w);
                    c *= dot(m.rgb, float3(0.2125, 0.7154, 0.0721)) * inside;
                }
                return c;
            }
            ENDCG
        }
    }
}
