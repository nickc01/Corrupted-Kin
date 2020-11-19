using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ReceivedDamageStay : FsmStateAction
	{
		public FsmString collideTag;
		public FsmEvent sendEvent;
		public FsmString fsmName;
		public FsmGameObject storeGameObject;
		public FsmBool ignoreAcid;
	}
}
