using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class TranslateContinuous : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat x;
		public FsmFloat y;
		public FsmInt[] layerMask;
	}
}
