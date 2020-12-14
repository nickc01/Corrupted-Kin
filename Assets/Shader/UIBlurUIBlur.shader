Shader "UI/Blur/UIBlur" {
	Properties {
		_TintColor ("Tint Color", Vector) = (1,1,1,0.2)
		_Size ("Spacing", Range(0, 70)) = 5
		_Vibrancy ("Vibrancy", Range(0, 2)) = 0.2
		[HideInInspector] _StencilComp ("Stencil Comparison", Float) = 8
		[HideInInspector] _Stencil ("Stencil ID", Float) = 0
		[HideInInspector] _StencilOp ("Stencil Operation", Float) = 0
		[HideInInspector] _StencilWriteMask ("Stencil Write Mask", Float) = 255
		[HideInInspector] _StencilReadMask ("Stencil Read Mask", Float) = 255
	}
	SubShader {
		Tags { "IGNOREPROJECTOR" = "true" "QUEUE" = "Transparent" "RenderType" = "Opaque" }
		GrabPass {
		}
		Pass {
			Name "VERTICAL"
			Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "ALWAYS" "QUEUE" = "Transparent" "RenderType" = "Opaque" }
			Stencil {
				ReadMask 0
				WriteMask 0
				Comp Disabled
				Pass Keep
				Fail Keep
				ZFail Keep
			}
			GpuProgramID 45207
			Program "vp" {
				SubProgram "d3d11" {
					"vs_4_0
					
					#version 330
					#extension GL_ARB_explicit_attrib_location : require
					#extension GL_ARB_explicit_uniform_location : require
					
					layout(std140) uniform UnityPerDraw {
						mat4x4 unity_ObjectToWorld;
						vec4 unused_0_1[6];
					};
					layout(std140) uniform UnityPerFrame {
						vec4 unused_1_0[17];
						mat4x4 unity_MatrixVP;
						vec4 unused_1_2[2];
					};
					in  vec4 in_POSITION0;
					out vec4 vs_TEXCOORD0;
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
					    u_xlat0.xy = u_xlat0.xy * vec2(1.0, -1.0) + u_xlat0.ww;
					    vs_TEXCOORD0.zw = u_xlat0.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy * vec2(0.5, 0.5);
					    return;
					}"
				}
			}
			Program "fp" {
				SubProgram "d3d11" {
					"ps_4_0
					
					#version 330
					#extension GL_ARB_explicit_attrib_location : require
					#extension GL_ARB_explicit_uniform_location : require
					
					layout(std140) uniform PGlobals {
						vec4 unused_0_0[2];
						vec4 _GrabTexture_TexelSize;
						float _Size;
					};
					uniform  sampler2D _GrabTexture;
					in  vec4 vs_TEXCOORD0;
					layout(location = 0) out vec4 SV_Target0;
					vec4 u_xlat0;
					vec4 u_xlat16_0;
					vec4 u_xlat10_0;
					vec4 u_xlat1;
					vec4 u_xlat10_1;
					vec4 u_xlat2;
					vec4 u_xlat10_2;
					vec4 u_xlat16_3;
					vec4 u_xlat10_3;
					void main()
					{
					    u_xlat0.xz = vs_TEXCOORD0.xx;
					    u_xlat1.x = _GrabTexture_TexelSize.y * _Size;
					    u_xlat2 = u_xlat1.xxxx * vec4(-6.44000006, -3.22000003, -4.82999992, -1.61000001) + vs_TEXCOORD0.yyyy;
					    u_xlat1 = u_xlat1.xxxx * vec4(1.61000001, 4.82999992, 3.22000003, 6.44000006) + vs_TEXCOORD0.yyyy;
					    u_xlat0.yw = u_xlat2.xz;
					    u_xlat0 = u_xlat0 / vs_TEXCOORD0.wwww;
					    u_xlat10_3 = texture(_GrabTexture, u_xlat0.zw);
					    u_xlat10_0 = texture(_GrabTexture, u_xlat0.xy);
					    u_xlat16_3 = u_xlat10_3 * vec4(0.0900000036, 0.0900000036, 0.0900000036, 0.0900000036);
					    u_xlat16_0 = u_xlat10_0 * vec4(0.0500000007, 0.0500000007, 0.0500000007, 0.0500000007) + u_xlat16_3;
					    u_xlat2.xz = vs_TEXCOORD0.xx;
					    u_xlat2 = u_xlat2 / vs_TEXCOORD0.wwww;
					    u_xlat10_3 = texture(_GrabTexture, u_xlat2.xy);
					    u_xlat10_2 = texture(_GrabTexture, u_xlat2.zw);
					    u_xlat16_0 = u_xlat10_3 * vec4(0.119999997, 0.119999997, 0.119999997, 0.119999997) + u_xlat16_0;
					    u_xlat16_0 = u_xlat10_2 * vec4(0.150000006, 0.150000006, 0.150000006, 0.150000006) + u_xlat16_0;
					    u_xlat2.xy = vs_TEXCOORD0.xy / vs_TEXCOORD0.ww;
					    u_xlat10_2 = texture(_GrabTexture, u_xlat2.xy);
					    u_xlat16_0 = u_xlat10_2 * vec4(0.180000007, 0.180000007, 0.180000007, 0.180000007) + u_xlat16_0;
					    u_xlat2.yw = u_xlat1.xz;
					    u_xlat2.xz = vs_TEXCOORD0.xx;
					    u_xlat2 = u_xlat2 / vs_TEXCOORD0.wwww;
					    u_xlat10_3 = texture(_GrabTexture, u_xlat2.xy);
					    u_xlat10_2 = texture(_GrabTexture, u_xlat2.zw);
					    u_xlat16_0 = u_xlat10_3 * vec4(0.150000006, 0.150000006, 0.150000006, 0.150000006) + u_xlat16_0;
					    u_xlat16_0 = u_xlat10_2 * vec4(0.119999997, 0.119999997, 0.119999997, 0.119999997) + u_xlat16_0;
					    u_xlat1.xz = vs_TEXCOORD0.xx;
					    u_xlat1 = u_xlat1 / vs_TEXCOORD0.wwww;
					    u_xlat10_2 = texture(_GrabTexture, u_xlat1.xy);
					    u_xlat10_1 = texture(_GrabTexture, u_xlat1.zw);
					    u_xlat16_0 = u_xlat10_2 * vec4(0.0900000036, 0.0900000036, 0.0900000036, 0.0900000036) + u_xlat16_0;
					    SV_Target0 = u_xlat10_1 * vec4(0.0500000007, 0.0500000007, 0.0500000007, 0.0500000007) + u_xlat16_0;
					    return;
					}"
				}
			}
		}
		GrabPass {
		}
		Pass {
			Name "HORIZONTAL"
			Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "ALWAYS" "QUEUE" = "Transparent" "RenderType" = "Opaque" }
			Stencil {
				ReadMask 0
				WriteMask 0
				Comp Disabled
				Pass Keep
				Fail Keep
				ZFail Keep
			}
			GpuProgramID 88377
			Program "vp" {
				SubProgram "d3d11" {
					"vs_4_0
					
					#version 330
					#extension GL_ARB_explicit_attrib_location : require
					#extension GL_ARB_explicit_uniform_location : require
					
					layout(std140) uniform UnityPerDraw {
						mat4x4 unity_ObjectToWorld;
						vec4 unused_0_1[6];
					};
					layout(std140) uniform UnityPerFrame {
						vec4 unused_1_0[17];
						mat4x4 unity_MatrixVP;
						vec4 unused_1_2[2];
					};
					in  vec4 in_POSITION0;
					out vec4 vs_TEXCOORD0;
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
					    u_xlat0.xy = u_xlat0.xy * vec2(1.0, -1.0) + u_xlat0.ww;
					    vs_TEXCOORD0.zw = u_xlat0.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy * vec2(0.5, 0.5);
					    return;
					}"
				}
			}
			Program "fp" {
				SubProgram "d3d11" {
					"ps_4_0
					
					#version 330
					#extension GL_ARB_explicit_attrib_location : require
					#extension GL_ARB_explicit_uniform_location : require
					
					layout(std140) uniform PGlobals {
						vec4 unused_0_0[2];
						vec4 _GrabTexture_TexelSize;
						float _Size;
					};
					uniform  sampler2D _GrabTexture;
					in  vec4 vs_TEXCOORD0;
					layout(location = 0) out vec4 SV_Target0;
					vec4 u_xlat0;
					vec4 u_xlat16_0;
					vec4 u_xlat10_0;
					vec4 u_xlat1;
					vec4 u_xlat10_1;
					vec4 u_xlat2;
					vec4 u_xlat10_2;
					vec4 u_xlat16_3;
					vec4 u_xlat10_3;
					void main()
					{
					    u_xlat0.yw = vs_TEXCOORD0.yy;
					    u_xlat1.x = _GrabTexture_TexelSize.x * _Size;
					    u_xlat2 = u_xlat1.xxxx * vec4(-3.22000003, -6.44000006, -1.61000001, -4.82999992) + vs_TEXCOORD0.xxxx;
					    u_xlat1 = u_xlat1.xxxx * vec4(4.82999992, 1.61000001, 6.44000006, 3.22000003) + vs_TEXCOORD0.xxxx;
					    u_xlat0.xz = u_xlat2.yw;
					    u_xlat0 = u_xlat0 / vs_TEXCOORD0.wwww;
					    u_xlat10_3 = texture(_GrabTexture, u_xlat0.zw);
					    u_xlat10_0 = texture(_GrabTexture, u_xlat0.xy);
					    u_xlat16_3 = u_xlat10_3 * vec4(0.0900000036, 0.0900000036, 0.0900000036, 0.0900000036);
					    u_xlat16_0 = u_xlat10_0 * vec4(0.0500000007, 0.0500000007, 0.0500000007, 0.0500000007) + u_xlat16_3;
					    u_xlat2.yw = vs_TEXCOORD0.yy;
					    u_xlat2 = u_xlat2 / vs_TEXCOORD0.wwww;
					    u_xlat10_3 = texture(_GrabTexture, u_xlat2.xy);
					    u_xlat10_2 = texture(_GrabTexture, u_xlat2.zw);
					    u_xlat16_0 = u_xlat10_3 * vec4(0.119999997, 0.119999997, 0.119999997, 0.119999997) + u_xlat16_0;
					    u_xlat16_0 = u_xlat10_2 * vec4(0.150000006, 0.150000006, 0.150000006, 0.150000006) + u_xlat16_0;
					    u_xlat2.xy = vs_TEXCOORD0.xy / vs_TEXCOORD0.ww;
					    u_xlat10_2 = texture(_GrabTexture, u_xlat2.xy);
					    u_xlat16_0 = u_xlat10_2 * vec4(0.180000007, 0.180000007, 0.180000007, 0.180000007) + u_xlat16_0;
					    u_xlat2.xz = u_xlat1.yw;
					    u_xlat2.yw = vs_TEXCOORD0.yy;
					    u_xlat2 = u_xlat2 / vs_TEXCOORD0.wwww;
					    u_xlat10_3 = texture(_GrabTexture, u_xlat2.xy);
					    u_xlat10_2 = texture(_GrabTexture, u_xlat2.zw);
					    u_xlat16_0 = u_xlat10_3 * vec4(0.150000006, 0.150000006, 0.150000006, 0.150000006) + u_xlat16_0;
					    u_xlat16_0 = u_xlat10_2 * vec4(0.119999997, 0.119999997, 0.119999997, 0.119999997) + u_xlat16_0;
					    u_xlat1.yw = vs_TEXCOORD0.yy;
					    u_xlat1 = u_xlat1 / vs_TEXCOORD0.wwww;
					    u_xlat10_2 = texture(_GrabTexture, u_xlat1.xy);
					    u_xlat10_1 = texture(_GrabTexture, u_xlat1.zw);
					    u_xlat16_0 = u_xlat10_2 * vec4(0.0900000036, 0.0900000036, 0.0900000036, 0.0900000036) + u_xlat16_0;
					    SV_Target0 = u_xlat10_1 * vec4(0.0500000007, 0.0500000007, 0.0500000007, 0.0500000007) + u_xlat16_0;
					    return;
					}"
				}
			}
		}
		GrabPass {
		}
		Pass {
			Name "VERTICAL"
			Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "ALWAYS" "QUEUE" = "Transparent" "RenderType" = "Opaque" }
			Stencil {
				ReadMask 0
				WriteMask 0
				Comp Disabled
				Pass Keep
				Fail Keep
				ZFail Keep
			}
			GpuProgramID 158163
			Program "vp" {
				SubProgram "d3d11" {
					"vs_4_0
					
					#version 330
					#extension GL_ARB_explicit_attrib_location : require
					#extension GL_ARB_explicit_uniform_location : require
					
					layout(std140) uniform UnityPerDraw {
						mat4x4 unity_ObjectToWorld;
						vec4 unused_0_1[6];
					};
					layout(std140) uniform UnityPerFrame {
						vec4 unused_1_0[17];
						mat4x4 unity_MatrixVP;
						vec4 unused_1_2[2];
					};
					in  vec4 in_POSITION0;
					out vec4 vs_TEXCOORD0;
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
					    u_xlat0.xy = u_xlat0.xy * vec2(1.0, -1.0) + u_xlat0.ww;
					    vs_TEXCOORD0.zw = u_xlat0.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy * vec2(0.5, 0.5);
					    return;
					}"
				}
			}
			Program "fp" {
				SubProgram "d3d11" {
					"ps_4_0
					
					#version 330
					#extension GL_ARB_explicit_attrib_location : require
					#extension GL_ARB_explicit_uniform_location : require
					
					layout(std140) uniform PGlobals {
						vec4 unused_0_0[2];
						vec4 _GrabTexture_TexelSize;
						float _Size;
					};
					uniform  sampler2D _GrabTexture;
					in  vec4 vs_TEXCOORD0;
					layout(location = 0) out vec4 SV_Target0;
					vec4 u_xlat0;
					vec4 u_xlat16_0;
					vec4 u_xlat10_0;
					vec4 u_xlat1;
					vec4 u_xlat10_1;
					vec4 u_xlat2;
					vec4 u_xlat10_2;
					vec4 u_xlat3;
					vec4 u_xlat16_3;
					vec4 u_xlat10_3;
					vec4 u_xlat10_4;
					vec2 u_xlat6;
					void main()
					{
					    u_xlat0.xz = vs_TEXCOORD0.xx;
					    u_xlat1.x = _GrabTexture_TexelSize.y * _Size;
					    u_xlat2 = u_xlat1.xxxx * vec4(-4.0, 3.0, -3.0, -2.0) + vs_TEXCOORD0.yyyy;
					    u_xlat0.yw = u_xlat2.xz;
					    u_xlat0 = u_xlat0 / vs_TEXCOORD0.wwww;
					    u_xlat10_3 = texture(_GrabTexture, u_xlat0.zw);
					    u_xlat10_0 = texture(_GrabTexture, u_xlat0.xy);
					    u_xlat16_3 = u_xlat10_3 * vec4(0.0900000036, 0.0900000036, 0.0900000036, 0.0900000036);
					    u_xlat16_0 = u_xlat10_0 * vec4(0.0500000007, 0.0500000007, 0.0500000007, 0.0500000007) + u_xlat16_3;
					    u_xlat3.y = u_xlat2.w;
					    u_xlat3.xz = vs_TEXCOORD0.xx;
					    u_xlat6.xy = u_xlat3.xy / vs_TEXCOORD0.ww;
					    u_xlat10_4 = texture(_GrabTexture, u_xlat6.xy);
					    u_xlat16_0 = u_xlat10_4 * vec4(0.119999997, 0.119999997, 0.119999997, 0.119999997) + u_xlat16_0;
					    u_xlat3.w = (-_GrabTexture_TexelSize.y) * _Size + vs_TEXCOORD0.y;
					    u_xlat6.xy = u_xlat3.zw / vs_TEXCOORD0.ww;
					    u_xlat10_3 = texture(_GrabTexture, u_xlat6.xy);
					    u_xlat16_0 = u_xlat10_3 * vec4(0.150000006, 0.150000006, 0.150000006, 0.150000006) + u_xlat16_0;
					    u_xlat6.xy = vs_TEXCOORD0.xy / vs_TEXCOORD0.ww;
					    u_xlat10_3 = texture(_GrabTexture, u_xlat6.xy);
					    u_xlat16_0 = u_xlat10_3 * vec4(0.180000007, 0.180000007, 0.180000007, 0.180000007) + u_xlat16_0;
					    u_xlat3.y = _GrabTexture_TexelSize.y * _Size + vs_TEXCOORD0.y;
					    u_xlat3.xz = vs_TEXCOORD0.xx;
					    u_xlat6.xy = u_xlat3.xy / vs_TEXCOORD0.ww;
					    u_xlat10_4 = texture(_GrabTexture, u_xlat6.xy);
					    u_xlat16_0 = u_xlat10_4 * vec4(0.150000006, 0.150000006, 0.150000006, 0.150000006) + u_xlat16_0;
					    u_xlat3.w = u_xlat1.x * 2.0 + vs_TEXCOORD0.y;
					    u_xlat2.w = u_xlat1.x * 4.0 + vs_TEXCOORD0.y;
					    u_xlat1.xy = u_xlat3.zw / vs_TEXCOORD0.ww;
					    u_xlat10_1 = texture(_GrabTexture, u_xlat1.xy);
					    u_xlat16_0 = u_xlat10_1 * vec4(0.119999997, 0.119999997, 0.119999997, 0.119999997) + u_xlat16_0;
					    u_xlat2.xz = vs_TEXCOORD0.xx;
					    u_xlat1 = u_xlat2 / vs_TEXCOORD0.wwww;
					    u_xlat10_2 = texture(_GrabTexture, u_xlat1.zw);
					    u_xlat10_1 = texture(_GrabTexture, u_xlat1.xy);
					    u_xlat16_0 = u_xlat10_1 * vec4(0.0900000036, 0.0900000036, 0.0900000036, 0.0900000036) + u_xlat16_0;
					    SV_Target0 = u_xlat10_2 * vec4(0.0500000007, 0.0500000007, 0.0500000007, 0.0500000007) + u_xlat16_0;
					    return;
					}"
				}
			}
		}
		GrabPass {
		}
		Pass {
			Name "HORIZONTAL"
			Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "ALWAYS" "QUEUE" = "Transparent" "RenderType" = "Opaque" }
			Stencil {
				ReadMask 0
				WriteMask 0
				Comp Disabled
				Pass Keep
				Fail Keep
				ZFail Keep
			}
			GpuProgramID 207200
			Program "vp" {
				SubProgram "d3d11" {
					"vs_4_0
					
					#version 330
					#extension GL_ARB_explicit_attrib_location : require
					#extension GL_ARB_explicit_uniform_location : require
					
					layout(std140) uniform UnityPerDraw {
						mat4x4 unity_ObjectToWorld;
						vec4 unused_0_1[6];
					};
					layout(std140) uniform UnityPerFrame {
						vec4 unused_1_0[17];
						mat4x4 unity_MatrixVP;
						vec4 unused_1_2[2];
					};
					in  vec4 in_POSITION0;
					out vec4 vs_TEXCOORD0;
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
					    u_xlat0.xy = u_xlat0.xy * vec2(1.0, -1.0) + u_xlat0.ww;
					    vs_TEXCOORD0.zw = u_xlat0.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy * vec2(0.5, 0.5);
					    return;
					}"
				}
			}
			Program "fp" {
				SubProgram "d3d11" {
					"ps_4_0
					
					#version 330
					#extension GL_ARB_explicit_attrib_location : require
					#extension GL_ARB_explicit_uniform_location : require
					
					layout(std140) uniform PGlobals {
						vec4 unused_0_0[2];
						vec4 _GrabTexture_TexelSize;
						float _Size;
					};
					uniform  sampler2D _GrabTexture;
					in  vec4 vs_TEXCOORD0;
					layout(location = 0) out vec4 SV_Target0;
					vec4 u_xlat0;
					vec4 u_xlat16_0;
					vec4 u_xlat10_0;
					vec4 u_xlat1;
					vec4 u_xlat10_1;
					vec4 u_xlat2;
					vec4 u_xlat10_2;
					vec4 u_xlat3;
					vec4 u_xlat16_3;
					vec4 u_xlat10_3;
					vec4 u_xlat10_4;
					vec2 u_xlat6;
					void main()
					{
					    u_xlat0.yw = vs_TEXCOORD0.yy;
					    u_xlat1.x = _GrabTexture_TexelSize.x * _Size;
					    u_xlat2 = u_xlat1.xxxx * vec4(3.0, -4.0, -3.0, -2.0) + vs_TEXCOORD0.xxxx;
					    u_xlat0.xz = u_xlat2.yz;
					    u_xlat0 = u_xlat0 / vs_TEXCOORD0.wwww;
					    u_xlat10_3 = texture(_GrabTexture, u_xlat0.zw);
					    u_xlat10_0 = texture(_GrabTexture, u_xlat0.xy);
					    u_xlat16_3 = u_xlat10_3 * vec4(0.0900000036, 0.0900000036, 0.0900000036, 0.0900000036);
					    u_xlat16_0 = u_xlat10_0 * vec4(0.0500000007, 0.0500000007, 0.0500000007, 0.0500000007) + u_xlat16_3;
					    u_xlat3.x = u_xlat2.w;
					    u_xlat3.yw = vs_TEXCOORD0.yy;
					    u_xlat6.xy = u_xlat3.xy / vs_TEXCOORD0.ww;
					    u_xlat10_4 = texture(_GrabTexture, u_xlat6.xy);
					    u_xlat16_0 = u_xlat10_4 * vec4(0.119999997, 0.119999997, 0.119999997, 0.119999997) + u_xlat16_0;
					    u_xlat3.z = (-_GrabTexture_TexelSize.x) * _Size + vs_TEXCOORD0.x;
					    u_xlat6.xy = u_xlat3.zw / vs_TEXCOORD0.ww;
					    u_xlat10_3 = texture(_GrabTexture, u_xlat6.xy);
					    u_xlat16_0 = u_xlat10_3 * vec4(0.150000006, 0.150000006, 0.150000006, 0.150000006) + u_xlat16_0;
					    u_xlat6.xy = vs_TEXCOORD0.xy / vs_TEXCOORD0.ww;
					    u_xlat10_3 = texture(_GrabTexture, u_xlat6.xy);
					    u_xlat16_0 = u_xlat10_3 * vec4(0.180000007, 0.180000007, 0.180000007, 0.180000007) + u_xlat16_0;
					    u_xlat3.x = _GrabTexture_TexelSize.x * _Size + vs_TEXCOORD0.x;
					    u_xlat3.yw = vs_TEXCOORD0.yy;
					    u_xlat6.xy = u_xlat3.xy / vs_TEXCOORD0.ww;
					    u_xlat10_4 = texture(_GrabTexture, u_xlat6.xy);
					    u_xlat16_0 = u_xlat10_4 * vec4(0.150000006, 0.150000006, 0.150000006, 0.150000006) + u_xlat16_0;
					    u_xlat3.z = u_xlat1.x * 2.0 + vs_TEXCOORD0.x;
					    u_xlat2.z = u_xlat1.x * 4.0 + vs_TEXCOORD0.x;
					    u_xlat1.xy = u_xlat3.zw / vs_TEXCOORD0.ww;
					    u_xlat10_1 = texture(_GrabTexture, u_xlat1.xy);
					    u_xlat16_0 = u_xlat10_1 * vec4(0.119999997, 0.119999997, 0.119999997, 0.119999997) + u_xlat16_0;
					    u_xlat2.yw = vs_TEXCOORD0.yy;
					    u_xlat1 = u_xlat2 / vs_TEXCOORD0.wwww;
					    u_xlat10_2 = texture(_GrabTexture, u_xlat1.zw);
					    u_xlat10_1 = texture(_GrabTexture, u_xlat1.xy);
					    u_xlat16_0 = u_xlat10_1 * vec4(0.0900000036, 0.0900000036, 0.0900000036, 0.0900000036) + u_xlat16_0;
					    SV_Target0 = u_xlat10_2 * vec4(0.0500000007, 0.0500000007, 0.0500000007, 0.0500000007) + u_xlat16_0;
					    return;
					}"
				}
			}
		}
		GrabPass {
		}
		Pass {
			Tags { "IGNOREPROJECTOR" = "true" "LIGHTMODE" = "ALWAYS" "QUEUE" = "Transparent" "RenderType" = "Opaque" }
			Stencil {
				ReadMask 0
				WriteMask 0
				Comp Disabled
				Pass Keep
				Fail Keep
				ZFail Keep
			}
			GpuProgramID 282517
			Program "vp" {
				SubProgram "d3d11" {
					"vs_4_0
					
					#version 330
					#extension GL_ARB_explicit_attrib_location : require
					#extension GL_ARB_explicit_uniform_location : require
					
					layout(std140) uniform UnityPerDraw {
						mat4x4 unity_ObjectToWorld;
						vec4 unused_0_1[6];
					};
					layout(std140) uniform UnityPerFrame {
						vec4 unused_1_0[17];
						mat4x4 unity_MatrixVP;
						vec4 unused_1_2[2];
					};
					in  vec4 in_POSITION0;
					out vec4 vs_TEXCOORD0;
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
					    u_xlat0.xy = u_xlat0.xy * vec2(1.0, -1.0) + u_xlat0.ww;
					    vs_TEXCOORD0.zw = u_xlat0.zw;
					    vs_TEXCOORD0.xy = u_xlat0.xy * vec2(0.5, 0.5);
					    return;
					}"
				}
			}
			Program "fp" {
				SubProgram "d3d11" {
					"ps_4_0
					
					#version 330
					#extension GL_ARB_explicit_attrib_location : require
					#extension GL_ARB_explicit_uniform_location : require
					
					layout(std140) uniform PGlobals {
						vec4 unused_0_0[2];
						vec4 _TintColor;
						float _Vibrancy;
						vec4 unused_0_3;
					};
					uniform  sampler2D _GrabTexture;
					in  vec4 vs_TEXCOORD0;
					layout(location = 0) out vec4 SV_Target0;
					vec4 u_xlat0;
					vec4 u_xlat1;
					vec2 u_xlat2;
					void main()
					{
					    u_xlat0.x = _Vibrancy + 1.0;
					    u_xlat2.xy = vs_TEXCOORD0.xy / vs_TEXCOORD0.ww;
					    u_xlat1 = texture(_GrabTexture, u_xlat2.xy);
					    u_xlat1.xyz = u_xlat0.xxx * u_xlat1.xyz;
					    u_xlat0 = (-u_xlat1) + _TintColor;
					    SV_Target0 = _TintColor.wwww * u_xlat0 + u_xlat1;
					    return;
					}"
				}
			}
		}
	}
}