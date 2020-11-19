using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class DestroyObject : FsmStateAction
	{
		public FsmGameObject gameObject;
		public FsmFloat delay;
		public FsmBool detachChildren;
	}
}
