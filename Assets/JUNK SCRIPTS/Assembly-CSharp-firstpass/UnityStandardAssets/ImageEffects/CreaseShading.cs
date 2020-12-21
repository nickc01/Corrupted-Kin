using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	internal class CreaseShading : PostEffectsBase
	{
		public float intensity;
		public int softness;
		public float spread;
		public Shader blurShader;
		public Shader depthFetchShader;
		public Shader creaseApplyShader;
	}
}
