using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class Vector3Lerp : FsmStateAction
	{
		public FsmVector3 fromVector;
		public FsmVector3 toVector;
		public FsmFloat amount;
		public FsmVector3 storeResult;
		public bool everyFrame;
	}
}
