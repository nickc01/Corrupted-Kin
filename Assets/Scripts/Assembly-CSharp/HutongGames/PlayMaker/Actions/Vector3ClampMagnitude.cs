using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class Vector3ClampMagnitude : FsmStateAction
	{
		public FsmVector3 vector3Variable;
		public FsmFloat maxLength;
		public bool everyFrame;
	}
}
