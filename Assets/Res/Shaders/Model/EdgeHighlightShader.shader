Shader "Shaders/Model/EdgeHighlightShader"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _OutlineColor ("Outline Color", Color) = (0,0,0,1)
        _OutlineWidth ("Outline Width", Range(0.0, 1.0)) = 0.03
    }
    SubShader
    {
        Tags {"RenderType" = "Opaque" "LightMode" = "UniversalForward"}
        LOD 200

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uv : TEXCOORD0;
                float3 worldPos : TEXCOORD1;
                float3 worldNormal : TEXCOORD2;
            };

            sampler2D _MainTex;
            float4 _Color;
            float4 _OutlineColor;
            float _OutlineWidth;

            v2f vert (appdata v)
            {
                 v2f o;

                // 将顶点坐标从模型空间变换到观察空间
                float4 pos = mul(UNITY_MATRIX_MV, v.vertex);
                // 将法线从模型空间变换到观察空间
                float3 normal = mul((float3x3)UNITY_MATRIX_IT_MV, v.normal);
                // 是为了尽可能避免背面扩张后的顶点挡住正面的面片
                normal.z = 0.5;
                // 将顶点沿法线方向上扩张
                pos = pos + float4(normalize(normal), 0) * _OutlineWidth;
                // 将顶点坐标从观察空间变换到裁剪空间
                o.pos = mul(UNITY_MATRIX_P, pos);

                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                  return fixed4(_OutlineColor.rgb, 1);
                
            }
            ENDCG
        }
        Pass
        {
            Tags { "LightMode" = "SRPDefaultUnlit" }
            
            Cull Back
            
            CGPROGRAM

            // 编译指令，保证在pass中得到Pass中得到正确的光照变量
            #pragma multi_compile_fwdbase

            #pragma vertex vert
            #pragma fragment frag
            
            #include "UnityCG.cginc"
            // #include "Lighting.cginc"
            // #include "AutoLight.cginc"
            // #include "UnityShaderVariables.cginc"
            
            fixed4 _Color;
            sampler2D _MainTex;
            float4 _MainTex_ST;
            
            
            // 应用传递给定点着色器的数据
            struct a2v
            {
                float4 vertex: POSITION; // 语义: 顶点坐标
                float3 normal: NORMAL; // 语义: 法线
                float4 texcoord: TEXCOORD0; // 语义: 纹理坐标
                fixed4 color : COLOR;
            };
            
            // 顶点着色器传递给片元着色器的数据
            // struct v2f
            // {
            //     float4 pos: SV_POSITION; // 语义: 裁剪空间的顶点坐标
            //     float2 uv: TEXCOORD0;
            //     float3 worldNormal: TEXCOORD1;
            //     float3 worldPos: TEXCOORD2;
            //     fixed4 color : COLOR;
            //     float4 vertex : POSITION;
            //     // SHADOW_COORDS(3) // 内置宏：声明一个用于对阴影纹理采样的坐标 (这个宏参数需要是下一个可用的插值寄存器的索引值，这里是3)
            // };
            struct v2f
            {
                float4 pos: SV_POSITION; // 语义: 裁剪空间的顶点坐标
                float2 uv: TEXCOORD0;
                float3 worldNormal: TEXCOORD1;
                float3 worldPos: TEXCOORD2;
                fixed4 color : COLOR;
                // SHADOW_COORDS(3) // 内置宏：声明一个用于对阴影纹理采样的坐标 (这个宏参数需要是下一个可用的插值寄存器的索引值，这里是3)
            };

            // 顶点着色器
            v2f vert(a2v v)
            {
                v2f o;

                // 将顶点坐标从模型空间变换到裁剪空间
                // 等价于o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                o.pos = UnityObjectToClipPos(v.vertex);
                
                // 将法线从模型空间变换到世界空间
                // 等价于o.worldNormal = mul(v.normal, (float3x3)unity_WorldToObject);
                o.worldNormal = UnityObjectToWorldNormal(v.normal);

                // 将顶点坐标从模型空间变换到世界空间
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                
                o.color = v.color * _Color;
                // 内置宏：用于计算声明的阴影纹理坐标
                // TRANSFER_SHADOW(o);
                // 计算纹理坐标(缩放和平移)
                // 等价于o.uv = v.texcoord * _MainTex_ST.xy + _MainTex_ST.zw;
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                return o;
            }

            // 片元着色器
            fixed4 frag(v2f i): SV_TARGET
            {
                fixed4 col = tex2D(_MainTex, i.uv);
                // col +=  i.color * _Color;
                return col;
            }


            ENDCG

        }
    }
     Fallback "Universal Render Pipeline/Lit"
}
