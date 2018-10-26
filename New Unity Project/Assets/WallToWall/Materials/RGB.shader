Shader "Custom/RGB" {
Properties {
     _MainTex ("Base (RGB)", 2D) = "white" {}
        _Color("Color", Color) = (1,1,1,1)
    }

    SubShader {
        Tags { "Queue" = "Transparent" "RenderType" = "Transparent"}
           ZTest Off
        ZWrite On
        Blend One One
        

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            uniform float4 _Color;

            float4 vert(float4 pos : POSITION) : SV_POSITION {
                return UnityObjectToClipPos(pos);
            }

            float4 frag() : SV_TARGET {
                return _Color;
            }
            ENDCG
        }
    }
}