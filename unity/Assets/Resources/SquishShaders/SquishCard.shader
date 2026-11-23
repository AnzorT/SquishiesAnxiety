// Squish Time's card (src/components/squishCard.js cardMaterial, with SquishyToy.js's squish spliced into three's
// MeshStandardMaterial), drawn into the stage's supersampled target (Games/Squish/SquishStage.cs). Line by line:
//   vertex   SQUISH_VERTEX_GLSL squishDepth + SQUISH_NORMAL_GLSL (the normal tilted by the dent's Jacobian) +
//            SQUISH_POSITION_GLSL (the push along uSquishDir), then three's normalMatrix / modelViewMatrix / projection
//   fragment three r166 meshphysical.glsl as compiled for the card (CARD_FRAGMENT's sRGB decode of the map and the
//            emissive map, alphaTest, roughness + geometryRoughness, three directional lights with GGX, ambient +
//            hemisphere, no environment), with every light and the emissive already divided by Supersample's HEADROOM
//   output   what an 8-bit sRGB render target stores: the exact sRGB encode (Unity runs in Gamma space, so the
//            target is a plain ARGB32 and the encode is done here; SquishResolve.shader decodes it)
// The C# copy (SquishShaderMath, SquishShade.Fragment) is what tools/unity/squish-test checks against the app.
// Uniforms come from SquishStage (three's matrices; _SqClip already through GL.GetGPUProjectionMatrix).
Shader "Hidden/SquishSquad/SquishCard"
{
    Properties { _MainTex ("Card atlas", 2D) = "white" {} _SqCull ("Cull", Float) = 2 }
    SubShader
    {
        Tags { "RenderType" = "Opaque" }
        Cull [_SqCull] ZWrite On ZTest LEqual Lighting Off Blend Off
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 3.0
            #include "UnityCG.cginc"

            #define SQUISH_MAX 24
            sampler2D _MainTex;
            float4 _SqPress[SQUISH_MAX];
            int _SqCount;
            float4 _SqDir;      // xyz: uSquishDir
            float4 _SqDent;     // uSquishDent: radius, tip, max depth
            float4x4 _SqMV;     // three's modelViewMatrix
            float4x4 _SqNrm;    // three's normalMatrix (upper 3x3)
            float4x4 _SqClip;   // the GPU projection x modelViewMatrix
            float4 _SqLightDir[3], _SqLightCol[3];
            float4 _SqHemiDir, _SqHemiSky, _SqHemiGround, _SqAmbient;
            float4 _SqLook;     // diffuse (CARD_LOOK.lit), emissive (CARD_LOOK.self / HEADROOM), roughness, alphaTest

            struct appdata { float4 vertex : POSITION; float3 normal : NORMAL; float2 uv : TEXCOORD0; };
            struct v2f { float4 pos : SV_POSITION; float2 uv : TEXCOORD0; float3 vNormal : TEXCOORD1; float3 vViewPosition : TEXCOORD2; };

            static float3 squishGrad;
            float squishDepth(float3 p)
            {
                float depth = 0.0;
                squishGrad = float3(0.0, 0.0, 0.0);
                float tip = _SqDent.y;
                float invRadius = 1.0 / _SqDent.x;
                [loop] for (int j = 0; j < SQUISH_MAX; j++)
                {
                    if (j >= _SqCount) break;
                    float3 q = p - _SqPress[j].xyz;
                    float rt = sqrt(dot(q, q) + tip * tip);
                    float f = exp(-(rt - tip) * invRadius) * _SqPress[j].w;
                    depth += f;
                    squishGrad -= q * (f * invRadius / rt);
                }
                return depth;
            }

            v2f vert (appdata v)
            {
                v2f o;
                float3 position = v.vertex.xyz;
                // #include <beginnormal_vertex> + SQUISH_NORMAL_GLSL
                float3 objectNormal = v.normal;
                float squishD = squishDepth(position);
                {
                    float dn = dot(_SqDir.xyz, objectNormal);
                    float den = max(1.0 + dot(_SqDir.xyz, squishGrad), 0.15);
                    objectNormal = normalize(objectNormal - squishGrad * (dn / den));
                }
                float3 transformedNormal = mul((float3x3)_SqNrm, objectNormal);
                o.vNormal = normalize(transformedNormal);
                // #include <begin_vertex> + SQUISH_POSITION_GLSL
                float3 transformed = position;
                transformed += _SqDir.xyz * min(squishD, _SqDent.z);
                float4 mvPosition = mul(_SqMV, float4(transformed, 1.0));
                o.pos = mul(_SqClip, float4(transformed, 1.0));
                o.vViewPosition = -mvPosition.xyz;
                o.uv = v.uv;
                return o;
            }

            #define RECIPROCAL_PI 0.3183098861837907
            float pow2(float x) { return x * x; }
            // CARD_FRAGMENT's decode (three's inline sRGB -> linear)
            float3 decode(float3 c) { return lerp(pow(c * 0.9478672986 + 0.0521327014, 2.4), c * 0.0773993808, step(c, 0.04045)); }
            float3 encodeTarget(float3 c)
            {
                c = saturate(c);
                return lerp(1.055 * pow(c, 0.41666) - 0.055, c * 12.92, step(c, 0.0031308));
            }

            float3 BRDF_GGX(float3 lightDir, float3 viewDir, float3 normal, float roughness)
            {
                const float3 f0 = float3(0.04, 0.04, 0.04);
                const float f90 = 1.0;
                float alpha = pow2(roughness);
                float3 halfDir = normalize(lightDir + viewDir);
                float dotNL = saturate(dot(normal, lightDir));
                float dotNV = saturate(dot(normal, viewDir));
                float dotNH = saturate(dot(normal, halfDir));
                float dotVH = saturate(dot(viewDir, halfDir));
                float fresnel = exp2((-5.55473 * dotVH - 6.98316) * dotVH);
                float3 F = f0 * (1.0 - fresnel) + (f90 * fresnel);
                float a2 = pow2(alpha);
                float gv = dotNL * sqrt(a2 + (1.0 - a2) * pow2(dotNV));
                float gl = dotNV * sqrt(a2 + (1.0 - a2) * pow2(dotNL));
                float V = 0.5 / max(gv + gl, 1e-6);
                float denom = pow2(dotNH) * (a2 - 1.0) + 1.0;
                float D = RECIPROCAL_PI * a2 / pow2(denom);
                return F * (V * D);
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float4 tex = tex2D(_MainTex, i.uv);
                float4 diffuseColor = float4(_SqLook.xxx, 1.0) * float4(decode(tex.rgb), tex.a);
                if (diffuseColor.a < _SqLook.w) discard;
                float3 normal = normalize(i.vNormal);
                float3 nonPerturbedNormal = normal;
                float3 totalEmissiveRadiance = _SqLook.yyy * decode(tex.rgb);
                float3 dxy = max(abs(ddx(nonPerturbedNormal)), abs(ddy(nonPerturbedNormal)));
                float geometryRoughness = max(max(dxy.x, dxy.y), dxy.z);
                float roughness = min(max(_SqLook.z, 0.0525) + geometryRoughness, 1.0);
                float3 viewDir = normalize(i.vViewPosition);
                float3 directDiffuse = 0, directSpecular = 0;
                [unroll] for (int l = 0; l < 3; l++)
                {
                    float dotNL = saturate(dot(normal, _SqLightDir[l].xyz));
                    float3 irradiance = dotNL * _SqLightCol[l].rgb;
                    directSpecular += irradiance * BRDF_GGX(_SqLightDir[l].xyz, viewDir, normal, roughness);
                    directDiffuse += irradiance * RECIPROCAL_PI * diffuseColor.rgb;
                }
                float hemiDiffuseWeight = 0.5 * dot(normal, _SqHemiDir.xyz) + 0.5;
                float3 irr = _SqAmbient.rgb + lerp(_SqHemiGround.rgb, _SqHemiSky.rgb, hemiDiffuseWeight);
                float3 indirectDiffuse = irr * RECIPROCAL_PI * diffuseColor.rgb;
                float3 outgoingLight = directDiffuse + indirectDiffuse + directSpecular + totalEmissiveRadiance;
                return float4(encodeTarget(outgoingLight), 1.0);
            }
            ENDCG
        }
    }
}
