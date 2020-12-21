using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class Vector3Interpolate : FsmStateAction
	{
		public InterpolationType mode;
		public FsmVector3 fromVector;
		public FsmVector3 toVector;
		public FsmFloat time;
		public FsmVector3 storeResult;
		public FsmEvent finishEvent;
		public bool realTime;
	}
}
