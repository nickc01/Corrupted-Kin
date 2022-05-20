Shader "UI/BlendModes/LinearLight" {
	Properties {
		[PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
		_Color ("Tint", Vector) = (1,1,1,1)
		_StencilComp ("Stencil Comparison", Float) = 8
		_Stencil ("Stencil ID", Float) = 0
		_StencilOp ("Stencil Operation", Float) = 0
		_StencilWriteMask ("Stencil Write Mask", Float) = 255
		_StencilReadMask ("Stencil Read Mask", Float) = 255
		_ColorMask ("Color Mask", Float) = 15
	}
	SubShader {
		LOD 950
		Tags { "IGNOREPROJECTOR" = "true" "PreviewType" = "Plane" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
		GrabPass {
		}
		Pass {
			LOD 950
			Tags { "IGNOREPROJECTOR" = "true" "PreviewType" = "Plane" "QUEUE" = "Transparent" "RenderType" = "Transparent" }
			Blend SrcAlpha OneMinusSrcAlpha, SrcAlpha OneMinusSrcAlpha
			ColorMask 0 -1
			ZWrite Off
			Cull Off
			Stencil {
				ReadMask 0
				WriteMask 0
				Comp Disabled
				Pass Keep
				Fail Keep
				ZFail Keep
			}
			Fog {
				Mode Off
			}
			GpuProgramID 13470
			Program "vp" {
				SubProgram "d3d11 " {
					"vs_4_0
					
					#version 330
					#extension GL_ARB_explicit_attrib_location : require
					#extension GL_ARB_explicit_uniform_location : require
					
					layout(std140) uniform VGlobals {
						vec4 unused_0_0[2];
						vec4 _Color;
					};
					layout(std140) uniform UnityPerDraw {
						mat4x4 unity_ObjectToWorld;
						vec4 unused_1_1[6];
					};
					layout(std140) uniform UnityPerFrame {
						vec4 unused_2_0[17];
						mat4x4 unity_MatrixVP;
						vec4 unused_2_2[2];
					};
					in  vec4 in_POSITION0;
					in  vec4 in_COLOR0;
					in  vec2 in_TEXCOORD0;
					out vec4 vs_COLOR0;
					out vec2 vs_TEXCOORD0;
					out vec4 vs_TEXCOORD1;
					vec4 u_xlat0;
					vec4 u_xlat1;
					void main()
					{
					    u_xlat0 = in_POSITION0.yyyy * unity_ObjectToWorld[1];
					    u_xlat0 = unity_ObjectToWorld[0] * in_POSITION0.xxxx + u_xlat0;
					    u_xlat0 = unity_ObjectToWorld[2] * in_POSITION0.zzzz + u_xlat0;
					    u_xlat0 = u_xlat0 + unity_ObjectToWorld[3];
					    u_xlat1 = u_xlat0.yyyy * unity_MatrixVP[1];
					    u_xlat1 = unity_MatrixVP[0] * u_xlat0.xxxx + u_xlat1;
					    u_xlat1 = unity_MatrixVP[2] * u_xlat0.zzzz + u_xlat1;
					    u_xlat0 = unity_MatrixVP[3] * u_xlat0.wwww + u_xlat1;
					    gl_Position = u_xlat0;
					    vs_TEXCOORD1 = u_xlat0;
					    vs_COLOR0 = in_COLOR0 * _Color;
					    vs_TEXCOORD0.xy = in_TEXCOORD0.xy;
					    return;
					}"
				}
			}
			Program "fp" {
				SubProgram "d3d11 " {
					"ps_4_0
					
					#version 330
					#extension GL_ARB_explicit_attrib_location : require
					#extension GL_ARB_explicit_uniform_location : require
					
					uniform  sampler2D _MainTex;
					uniform  sampler2D _GrabTexture;
					in  vec4 vs_COLOR0;
					in  vec2 vs_TEXCOORD0;
					in  vec4 vs_TEXCOORD1;
					layout(location = 0) out vec4 SV_Target0;
					vec4 u_xlat0;
					vec4 u_xlat10_0;
					vec4 u_xlat1;
					bool u_xlatb1;
					vec3 u_xlat2;
					vec4 u_xlat10_2;
					bvec3 u_xlatb3;
					void main()
					{
					    u_xlat10_0 = texture(_MainTex, vs_TEXCOORD0.xy);
					    u_xlat1 = u_xlat10_0.wxyz * vs_COLOR0.wxyz + vec4(-0.00999999978, -0.5, -0.5, -0.5);
					    u_xlat0 = u_xlat10_0.wxyz * vs_COLOR0.wxyz;
					    u_xlatb1 = u_xlat1.x<0.0;
					    if(((int(u_xlatb1) * int(0xffffffffu)))!=0){discard;}
					    u_xlat2.xy = vs_TEXCOORD1.xy / vs_TEXCOORD1.ww;
					    u_xlat2.xy = u_xlat2.xy + vec2(1.0, 1.0);
					    u_xlat2.x = u_xlat2.x * 0.5;
					    u_xlat2.z = (-u_xlat2.y) * 0.5 + 1.0;
					    u_xlat10_2 = texture(_GrabTexture, u_xlat2.xz);
					    u_xlat1.xyz = u_xlat1.yzw * vec3(2.0, 2.0, 2.0) + u_xlat10_2.xyz;
					    u_xlat2.xyz = u_xlat0.yzw * vec3(2.0, 2.0, 2.0) + u_xlat10_2.xyz;
					    u_xlat2.xyz = u_xlat2.xyz + vec3(-1.0, -1.0, -1.0);
					    u_xlatb3.xyz = lessThan(vec4(0.5, 0.5, 0.5, 0.5), u_xlat0.yzww).xyz;
					    SV_Target0.w = u_xlat0.x;
					    SV_Target0.x = (u_xlatb3.x) ? u_xlat1.x : u_xlat2.x;
					    SV_Target0.y = (u_xlatb3.y) ? u_xlat1.y : u_xlat2.y;
					    SV_Target0.z = (u_xlatb3.z) ? u_xlat1.z : u_xlat2.z;
					    return;
					}"
				}
			}
		}
	}
	Fallback "Sprites/Approximate Linear Light"
}