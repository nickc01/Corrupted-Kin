using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetMaterialColor : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmInt materialIndex;
		public FsmMaterial material;
		public FsmString namedColor;
		public FsmColor color;
		public FsmEvent fail;
	}
}
