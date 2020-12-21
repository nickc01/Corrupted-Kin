using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetMouseButtonDown : FsmStateAction
	{
		public MouseButton button;
		public FsmEvent sendEvent;
		public FsmBool storeResult;
		public bool inUpdateOnly;
	}
}
