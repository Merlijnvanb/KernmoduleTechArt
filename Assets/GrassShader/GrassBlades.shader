Shader "Grass/GrassBlades"
{
    Properties
    {
        [HDR] _BaseColor("Base color", Color) = (0, 0.5, 0, 1)
        [HDR] _TipColor("Tip color", Color) = (0, 1, 0, 1)
        _PosterizeSteps("Posterization steps", Float) = 15.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" "RenderPipeline"="UniversalPipeline" "IgnoreProjector"="True" }

        Pass
        {
            
            Name "ForwardLit"
            Tags{"LightMode"="UniversalForward"}
            Cull Off

            HLSLPROGRAM
            #pragma prefer_hlslcc gles
            #pragma exclude_renderers d3d11_9x
            #pragma target 5.0

            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS
            #pragma multi_compile _ _MAIN_LIGHT_SHADOWS_CASCADE
            #pragma multi_compile _ _ADDITIONAL_LIGHTS
            #pragma multi_compile _ _ADDITIONAL_LIGHT_SHADOWS
            #pragma multi_compile _ _SHADOWS_SOFT

            #pragma vertex Vertex
            #pragma fragment Fragment

            #include "GrassBlades.hlsl"

            ENDHLSL
        }
    }
}