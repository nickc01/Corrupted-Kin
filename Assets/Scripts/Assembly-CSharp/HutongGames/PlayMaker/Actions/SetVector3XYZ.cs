using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetVector3XYZ : FsmStateAction
	{
		public FsmVector3 vector3Variable;
		public FsmVector3 vector3Value;
		public FsmFloat x;
		public FsmFloat y;
		public FsmFloat z;
		public bool everyFrame;
	}
}
