using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetRayCastHit2dInfo : FsmStateAction
	{
		public FsmGameObject gameObjectHit;
		public FsmVector2 point;
		public FsmVector3 normal;
		public FsmFloat distance;
		public bool everyFrame;
	}
}
