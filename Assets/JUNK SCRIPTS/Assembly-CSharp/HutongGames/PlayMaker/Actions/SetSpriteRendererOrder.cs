using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetSpriteRendererOrder : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmInt order;
		public FsmFloat delay;
	}
}
