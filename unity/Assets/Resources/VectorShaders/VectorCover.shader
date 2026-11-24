// Stencil-then-cover, step 2: a quad over the shape's box draws its paint where the stencil isn't 0, and clears it.
// Paint (VectorRenderer sets it per draw): 0 solid _Color; 3 a picture (_Img); 1 linear / 2 radial gradient, sampled from row _RampV of
// _Ramp (256 stops' worth of straight sRGB colour per gradient). _G0/_G1: output px -> gradient space (2x3 rows:
// the shape's user space, objectBoundingBox units and the inverse gradientTransform folded in). Output premultiplied.
Shader "Hidden/SquishSquad/VectorCover"
{
    Properties { _Ramp ("Ramp", 2D) = "white" {} _Img ("Image", 2D) = "white" {} }
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        Cull Off ZWrite Off ZTest Always
        Blend One OneMinusSrcAlpha
        Stencil { Ref 0 Comp NotEqual Pass Zero }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            float4x4 _PxToClip;
            sampler2D _Ramp, _Img;
            float _Kind, _Spread, _RampV, _Opacity;
            float4 _Color, _G0, _G1, _Lin, _Rad, _Foc;
            struct v2f { float4 pos : SV_POSITION; float2 px : TEXCOORD0; };
            v2f vert (float3 px : POSITION) { v2f o; o.pos = mul(_PxToClip, float4(px.xy, 0, 1)); o.px = px.xy; return o; }
            float spread (float t)
            {
                if (_Spread > 1.5) return t - floor(t);                       // repeat
                if (_Spread > 0.5) { t = abs(t) % 2; return t > 1 ? 2 - t : t; } // reflect
                return saturate(t);                                           // pad
            }
            fixed4 frag (v2f i) : SV_Target
            {
                float4 c = _Color;
                if (_Kind > 2.5)
                {
                    // a picture (straight alpha), _G0/_G1: px -> its uv
                    c = tex2D(_Img, float2(dot(_G0.xy, i.px) + _G0.z, dot(_G1.xy, i.px) + _G1.z));
                }
                else if (_Kind > 0.5)
                {
                    float2 g = float2(dot(_G0.xy, i.px) + _G0.z, dot(_G1.xy, i.px) + _G1.z);
                    float t;
                    if (_Kind < 1.5)
                    {
                        float2 d = _Lin.zw - _Lin.xy;
                        float l2 = dot(d, d);
                        t = l2 > 0 ? dot(g - _Lin.xy, d) / l2 : 0;
                    }
                    else
                    {
                        // the largest t with g on the circle centred at f + t (c - f), radius t r
                        float2 e = g - _Foc.xy, d = _Rad.xy - _Foc.xy;
                        float r = _Rad.z;
                        if (dot(d, d) < 1e-12) t = length(e) / r;
                        else
                        {
                            float qa = dot(d, d) - r * r, qb = dot(e, d), qc = dot(e, e);
                            if (abs(qa) < 1e-9) t = qb == 0 ? 0 : qc / (2 * qb);
                            else { float disc = qb * qb - qa * qc; t = disc < 0 ? 1 : max((qb + sqrt(max(disc, 0))) / qa, (qb - sqrt(max(disc, 0))) / qa); if (t < 0) t = 1; }
                        }
                    }
                    c = tex2Dlod(_Ramp, float4((spread(t) * 255 + 0.5) / 256, _RampV, 0, 0));
                }
                c.a *= _Opacity;
                c.rgb *= c.a;
                return c;
            }
            ENDCG
        }
    }
}
