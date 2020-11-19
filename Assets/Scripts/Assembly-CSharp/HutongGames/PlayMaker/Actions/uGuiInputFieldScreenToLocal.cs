using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class uGuiInputFieldScreenToLocal : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmVector2 screen;
		public FsmVector2 local;
		public bool everyFrame;
	}
}
