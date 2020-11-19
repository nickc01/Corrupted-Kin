using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class AnimatorPlayStateWait : FsmStateAction
	{
		public FsmOwnerDefault target;
		public FsmString stateName;
		public FsmEvent finishEvent;
	}
}
