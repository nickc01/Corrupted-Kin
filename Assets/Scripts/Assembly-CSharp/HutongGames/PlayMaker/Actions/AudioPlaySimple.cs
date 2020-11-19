using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class AudioPlaySimple : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat volume;
		public FsmObject oneShotClip;
	}
}
