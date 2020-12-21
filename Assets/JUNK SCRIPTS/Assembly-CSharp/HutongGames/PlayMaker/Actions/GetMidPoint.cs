using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetMidPoint : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject target;
		public FsmVector3 midPoint;
		public bool everyFrame;
	}
}
