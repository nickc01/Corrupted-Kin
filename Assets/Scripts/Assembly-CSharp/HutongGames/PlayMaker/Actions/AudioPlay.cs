using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class AudioPlay : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat volume;
		public FsmObject oneShotClip;
		public FsmEvent finishedEvent;
	}
}
