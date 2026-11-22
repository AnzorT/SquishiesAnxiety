// Stencil-then-cover, step 1: a shape's polygons as triangle fans into the stencil, no colour.
//   pass 0 NonZero: front faces increment, back faces decrement (the winding number)
//   pass 1 EvenOdd: every triangle inverts (the parity)
//   pass 2 Union:   every triangle sets 1 (stroke pieces, clip unions)
// Vertices are in output pixels (y down); _PxToClip maps them (set by VectorRenderer).
Shader "Hidden/SquishSquad/VectorStencil"
{
    SubShader
    {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent" }
        Cull Off ZWrite Off ZTest Always ColorMask 0
        CGINCLUDE
        #include "UnityCG.cginc"
        float4x4 _PxToClip;
        float4 vert (float3 px : POSITION) : SV_POSITION { return mul(_PxToClip, float4(px.xy, 0, 1)); }
        fixed4 frag () : SV_Target { return 0; }
        ENDCG
        Pass { Stencil { Ref 0 Comp Always PassFront IncrWrap PassBack DecrWrap } CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            ENDCG }
        Pass { Stencil { Ref 0 Comp Always Pass Invert } CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            ENDCG }
        Pass { Stencil { Ref 1 Comp Always Pass Replace } CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            ENDCG }
    }
}
