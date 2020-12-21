using UnityEngine;

namespace UnityStandardAssets.ImageEffects
{
	public class ColorCorrectionCurves : PostEffectsBase
	{
		public float saturation;
		public AnimationCurve redChannel;
		public AnimationCurve greenChannel;
		public AnimationCurve blueChannel;
		public bool updateTextures;
		public Shader colorCorrectionCurvesShader;
		public Shader simpleColorCorrectionCurvesShader;
	}
}
