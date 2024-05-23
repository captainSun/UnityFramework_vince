Shader "Shaders/Model/Outline"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _OutlineCol("OutlineCol", Color) = (1,0,0,1)  
        _OutlineFactor("OutlineFactor", Range(0,0.1)) = 0.01  
    }
    SubShader
    {
    cull front
        Tags { "RenderType"="Opaque"}
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"
            
            float _OutlineFactor;  
            float4 _OutlineCol;  
            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                // float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert (appdata v)
            {
                //实现方式1
                 // v2f o;
                 // v.vertex.xyz *= _OutlineFactor;
                 // o.vertex = UnityObjectToClipPos(v.vertex);
                 // o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                 // return o;

                //实现方式2
                v2f o;
                // 将顶点坐标从模型空间变换到观察空间
                float4 pos = mul(UNITY_MATRIX_MV, v.vertex);
                // 将法线从模型空间变换到观察空间
                float3 normal = mul((float3x3)UNITY_MATRIX_IT_MV, v.normal);
                // 是为了尽可能避免背面扩张后的顶点挡住正面的面片
                normal.z = 0.5;
                // 将顶点沿法线方向上扩张
                pos = pos + float4(normalize(normal), 0) * _OutlineFactor;
                // 将顶点坐标从观察空间变换到裁剪空间
                o.pos = mul(UNITY_MATRIX_P, pos);
                
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                return _OutlineCol;
            }
            ENDCG
        }
    }
}