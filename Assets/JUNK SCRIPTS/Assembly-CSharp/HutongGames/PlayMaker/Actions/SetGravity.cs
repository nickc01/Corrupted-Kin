using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetGravity : FsmStateAction
	{
		public FsmVector3 vector;
		public FsmFloat x;
		public FsmFloat y;
		public FsmFloat z;
		public bool everyFrame;
	}
}
