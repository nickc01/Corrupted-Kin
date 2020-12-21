using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class Tk2dTextMeshGetProperties : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString text;
		public FsmBool inlineStyling;
		public FsmString anchor;
		public FsmBool kerning;
		public FsmInt maxChars;
		public FsmInt NumDrawnCharacters;
		public FsmColor mainColor;
		public FsmColor gradientColor;
		public FsmBool useGradient;
		public FsmInt textureGradient;
		public FsmVector3 scale;
	}
}
