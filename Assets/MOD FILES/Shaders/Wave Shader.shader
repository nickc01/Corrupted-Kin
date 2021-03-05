Shader "Unlit/Wave Shader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_EdgeTex ("Edge Texture", 2D) = "white" {}
		_TilingX ("Tiling X", float) = 1
		_TilingY ("Tiling Y", float) = 1
		_EdgeHeight ("Edge Height", float) = 0.1
		_EdgeZ ("Edge Z", float) = 0.0
		_BlankingColor ("Blanking Color", Color) = (1,1,1,1)
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" }
		LOD 100

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
				//UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};

			/*struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2g
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			struct g2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};*/

			/*struct v2f
			{
				float2 uv : TEXCOORD0;
				UNITY_FOG_COORDS(1)
				float4 vertex : SV_POSITION;
			};*/

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float _TilingX;
			float _TilingY;
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
				//UNITY_TRANSFER_FOG(o,o.vertex);

				o.uv.xy *= float2(_TilingX,_TilingY);
				o.uv.z = v.uv.z;
				return o;
			}

			/*[maxvertexcount(3)]
			void geom(triangle v2g IN[3], inout TriangleStream<g2f> triStream)
			{
				g2f o;

				for (int i = 0; i < 3; i++)
				{
					o.vertex = IN[i].vertex;
					o.vertex.y += _EdgeHeight;
					o.uv = IN[i].uv;
					//o.vertex.y += 1.0;
					//UnityObjectToClipPos(IN[i].vertex);
					//UNITY_TRANSFER_FOG(o, o.vertex);
					//o.uv = TRANSFORM_TEX(IN[i].uv, _MainTex);
					triStream.Append(o);
				}

				triStream.RestartStrip();
			}*/

			fixed4 frag(v2f i) : SV_Target
			{
				// sample the texture
				//fixed4 col = tex2D(_MainTex, i.uv);
				fixed4 col = lerp(tex2D(_MainTex, i.uv),_BlankingColor,clamp(i.uv.z,0,1));
			// apply fog
			//UNITY_APPLY_FOG(i.fogCoord, col);
			return col;
			}
			ENDCG
		}

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
			float _TilingX;
			float _TilingY;
			
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv.xy = TRANSFORM_TEX(v.uv.xy, _EdgeTex);
				//UNITY_TRANSFER_FOG(o,o.vertex);

				o.uv.xy *= float2(_TilingX,_TilingY);
				o.uv.z = v.uv.z;
				return o;
			}
			
			fixed4 frag(v2f i) : SV_Target
			{
				// sample the texture
				fixed4 col = tex2D(_EdgeTex, i.uv.xy);
				// apply fog
				//UNITY_APPLY_FOG(i.fogCoord, col);
				return col;
			}
			ENDCG
		}
	}
}
