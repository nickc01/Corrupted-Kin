using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class uGuiInputFieldGetPlaceHolder : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject placeHolder;
		public FsmBool placeHolderDefined;
		public FsmEvent foundEvent;
		public FsmEvent notFoundEvent;
	}
}
