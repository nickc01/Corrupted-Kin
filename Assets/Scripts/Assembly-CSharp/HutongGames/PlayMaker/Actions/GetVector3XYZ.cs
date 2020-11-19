using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetVector3XYZ : FsmStateAction
	{
		public FsmVector3 vector3Variable;
		public FsmFloat storeX;
		public FsmFloat storeY;
		public FsmFloat storeZ;
		public bool everyFrame;
	}
}
