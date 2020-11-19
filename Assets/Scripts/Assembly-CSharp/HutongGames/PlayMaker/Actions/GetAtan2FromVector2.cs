using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetAtan2FromVector2 : FsmStateAction
	{
		public FsmVector2 vector2;
		public FsmFloat angle;
		public FsmBool RadToDeg;
		public bool everyFrame;
	}
}
