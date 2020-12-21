using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetCollision2dInfo : FsmStateAction
	{
		public FsmGameObject gameObjectHit;
		public FsmVector3 relativeVelocity;
		public FsmFloat relativeSpeed;
		public FsmVector3 contactPoint;
		public FsmVector3 contactNormal;
		public FsmInt shapeCount;
		public FsmString physics2dMaterialName;
	}
}
