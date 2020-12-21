using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetScale : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmVector3 vector;
		public FsmFloat x;
		public FsmFloat y;
		public FsmFloat z;
		public bool everyFrame;
		public bool lateUpdate;
	}
}
