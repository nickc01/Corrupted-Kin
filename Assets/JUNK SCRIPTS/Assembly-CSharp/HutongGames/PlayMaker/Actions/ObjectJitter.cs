using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ObjectJitter : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat x;
		public FsmFloat y;
		public FsmFloat z;
		public FsmBool allowMovement;
	}
}
