using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	public class FastNoise : PostEffectsBase
	{
		public enum FrameMultiple
		{
			Always = 1,
			Half = 2,
			Third = 3,
			Quarter = 4,
			Fifth = 5,
			Sixth = 6,
			Eighth = 8,
			Tenth = 10,
		}

		public FrameMultiple frameRateMultiplier;
		public float intensityMultiplier;
		public float generalIntensity;
		public float blackIntensity;
		public float whiteIntensity;
		public float midGrey;
		public Texture2D noiseTexture;
		public FilterMode filterMode;
		public float softness;
		public float monochromeTiling;
		public Shader noiseShader;
	}
}
