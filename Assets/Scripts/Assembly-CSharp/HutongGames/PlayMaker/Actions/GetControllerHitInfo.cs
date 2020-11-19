using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetControllerHitInfo : FsmStateAction
	{
		public FsmGameObject gameObjectHit;
		public FsmVector3 contactPoint;
		public FsmVector3 contactNormal;
		public FsmVector3 moveDirection;
		public FsmFloat moveLength;
		public FsmString physicsMaterialName;
	}
}
