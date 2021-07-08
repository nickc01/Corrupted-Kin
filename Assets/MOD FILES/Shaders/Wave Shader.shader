Shader "Unlit/Wave Shader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		[NoScaleOffset] _EdgeTex ("Edge Texture", 2D) = "white" {}
		_EdgeHeight ("Edge Height", float) = 0.1
		_EdgeZ ("Edge Z", float) = 0.0
		_BlankingColor ("Blanking Color", Color) = (1,1,1,1)
	}
	SubShader
	{
		Tags { "Queue" = "Overlay+1" }
		ZTest Always

		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog
			
			#include "UnityCG.cginc"

			struct appdata
			{
				//The position of the vertex
				float4 vertex : POSITION;
				//THIS SERVES A DUAL PURPOSE
				//The first two components are the uv mapping
				//The last component is the percentage of how much the blanking color should apply
				float3 uv : TEXCOORD0;
			};

			struct v2f
			{
				float3 uv : TEXCOORD0;
				//UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			sampler2D _EdgeTex;
			float4 _EdgeTex_ST;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv.xy = TRANSFORM_TEX(v.uv.xy, _EdgeTex);
				o.uv.z = v.uv.z;
				return o;
			}
			
			fixed4 frag(v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_EdgeTex, i.uv.xy);
				return col;
			}
			ENDCG
		}

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			//#pragma geometry geom
			#pragma fragment frag
			// make fog work
			#pragma multi_compile_fog

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float3 uv : TEXCOORD0;
			};

			struct v2f
			{
				float3 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _EdgeHeight;
			float _EdgeZ;
			float4 _BlankingColor;

			v2f vert(appdata v)
			{
				v2f o;

				float4 input = v.vertex;
				input.z += _EdgeZ;
				input.y += _EdgeHeight;
				o.vertex = UnityObjectToClipPos(input);
				o.uv.xy = TRANSFORM_TEX(v.uv.xy, _MainTex);
				o.uv.z = v.uv.z;
				return o;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				fixed4 col = lerp(tex2D(_MainTex, i.uv),_BlankingColor,clamp(i.uv.z,0,1));
				return col;
			}
			ENDCG
		}
	}
}
