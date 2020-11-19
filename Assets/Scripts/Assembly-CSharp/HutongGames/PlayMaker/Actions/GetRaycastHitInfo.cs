using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetRaycastHitInfo : FsmStateAction
	{
		public FsmGameObject gameObjectHit;
		public FsmVector3 point;
		public FsmVector3 normal;
		public FsmFloat distance;
		public bool everyFrame;
	}
}
