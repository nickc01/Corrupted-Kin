using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class DestroyObjects : FsmStateAction
	{
		public FsmArray gameObjects;
		public FsmFloat delay;
		public FsmBool detachChildren;
	}
}
