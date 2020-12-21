using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class Vector3AddXYZ : FsmStateAction
	{
		public FsmVector3 vector3Variable;
		public FsmFloat addX;
		public FsmFloat addY;
		public FsmFloat addZ;
		public bool everyFrame;
		public bool perSecond;
	}
}
