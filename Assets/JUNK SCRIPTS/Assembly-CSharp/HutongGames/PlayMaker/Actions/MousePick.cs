using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class MousePick : FsmStateAction
	{
		public FsmFloat rayDistance;
		public FsmBool storeDidPickObject;
		public FsmGameObject storeGameObject;
		public FsmVector3 storePoint;
		public FsmVector3 storeNormal;
		public FsmFloat storeDistance;
		public FsmInt[] layerMask;
		public FsmBool invertMask;
		public bool everyFrame;
	}
}
