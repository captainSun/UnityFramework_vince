Shader "Shaders/UI/SpriteOutline"
{
    Properties
    {
        [PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
		_OutlineColor("Outline Color", Color) = (1,1,1,1)
        _OutlineRange("Outline Range", Range(0,10)) = 1
    }
    SubShader
    {
		Tags
		{
			"RenderType" = "Transparent"
		}
 
		Blend SrcAlpha OneMinusSrcAlpha
 
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
 
            #include "UnityCG.cginc"
 
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float4 color    : COLOR;
                float3 normal : NORMAL;
            };
 
            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
                fixed4 color : COLOR;
                float4 worldPosition : TEXCOORD1;
            	float3 normal : NORMAL;
                UNITY_VERTEX_OUTPUT_STEREO
            };

            sampler2D _MainTex;
            
            fixed4 _Color;
            float4 _MainTex_ST;
            float4 _MainTex_TexelSize;
           
			fixed4 _OutlineColor;
            float _OutlineRange;
             v2f vert (appdata v)
            {
               v2f OUT;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(OUT);
                OUT.worldPosition = v.vertex;
                OUT.vertex = UnityObjectToClipPos(OUT.worldPosition);

                OUT.uv = v.uv;

                OUT.color = v.color * _Color;
                return OUT;
            }
 
            fixed4 frag (v2f i) : SV_Target
            {
                fixed4 col = tex2D(_MainTex, i.uv);
				float3 normal = normalize(i.normal);
				float3 viewDir = normalize(UnityWorldSpaceViewDir(i.worldPosition));

				float ndotv = max(pow(-dot(normal, viewDir),_OutlineRange), 0.001);

				fixed4 leftPixel = tex2D(_MainTex, i.uv + float2(-_MainTex_TexelSize.x, 0));
				fixed4 upPixel = tex2D(_MainTex, i.uv + float2(0, _MainTex_TexelSize.y));
				fixed4 rightPixel = tex2D(_MainTex, i.uv + float2(_MainTex_TexelSize.x, 0));
				fixed4 bottomPixel = tex2D(_MainTex, i.uv + float2(0, -_MainTex_TexelSize.y));
            	
				
				//fixed outline = (1 - leftPixel * upPixel * rightPixel * bottomPixel) * col.a ;
                fixed outline = max(max(leftPixel, upPixel), max(rightPixel, bottomPixel)).a - col.a;
            	
                return lerp(col, _OutlineColor, outline);
            }
            ENDCG
        }
    }
}