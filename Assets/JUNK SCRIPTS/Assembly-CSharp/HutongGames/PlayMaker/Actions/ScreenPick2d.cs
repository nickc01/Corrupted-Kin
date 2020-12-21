using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ScreenPick2d : FsmStateAction
	{
		public FsmVector3 screenVector;
		public FsmFloat screenX;
		public FsmFloat screenY;
		public FsmBool normalized;
		public FsmBool storeDidPickObject;
		public FsmGameObject storeGameObject;
		public FsmVector3 storePoint;
		public FsmInt[] layerMask;
		public FsmBool invertMask;
		public bool everyFrame;
	}
}
