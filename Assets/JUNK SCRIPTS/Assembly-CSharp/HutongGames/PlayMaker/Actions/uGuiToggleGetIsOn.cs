using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class uGuiToggleGetIsOn : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmBool value;
		public FsmEvent isOnEvent;
		public FsmEvent isOffEvent;
		public bool everyFrame;
	}
}
