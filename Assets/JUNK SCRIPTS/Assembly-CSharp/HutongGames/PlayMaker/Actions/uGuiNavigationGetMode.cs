using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class uGuiNavigationGetMode : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString navigationMode;
		public FsmEvent automaticEvent;
		public FsmEvent horizontalEvent;
		public FsmEvent verticalEvent;
		public FsmEvent explicitEvent;
		public FsmEvent noNavigationEvent;
	}
}
