using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ReceivedDamage : FsmStateAction
	{
		public FsmString collideTag;
		public FsmEvent sendEvent;
		public FsmString fsmName;
		public FsmGameObject storeGameObject;
		public FsmBool ignoreAcid;
		public FsmBool ignoreWater;
	}
}
