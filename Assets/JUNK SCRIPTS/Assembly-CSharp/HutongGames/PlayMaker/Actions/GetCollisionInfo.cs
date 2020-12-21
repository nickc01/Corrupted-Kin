using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetCollisionInfo : FsmStateAction
	{
		public FsmGameObject gameObjectHit;
		public FsmVector3 relativeVelocity;
		public FsmFloat relativeSpeed;
		public FsmVector3 contactPoint;
		public FsmVector3 contactNormal;
		public FsmString physicsMaterialName;
	}
}
