using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class Vector3Add : FsmStateAction
	{
		public FsmVector3 vector3Variable;
		public FsmVector3 addVector;
		public bool everyFrame;
		public bool perSecond;
	}
}
