using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class PlaySound : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmVector3 position;
		public FsmObject clip;
		public FsmFloat volume;
	}
}
