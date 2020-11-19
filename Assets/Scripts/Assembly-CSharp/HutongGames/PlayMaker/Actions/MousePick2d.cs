using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class MousePick2d : FsmStateAction
	{
		public FsmBool storeDidPickObject;
		public FsmGameObject storeGameObject;
		public FsmVector2 storePoint;
		public FsmInt[] layerMask;
		public FsmBool invertMask;
		public bool everyFrame;
	}
}
