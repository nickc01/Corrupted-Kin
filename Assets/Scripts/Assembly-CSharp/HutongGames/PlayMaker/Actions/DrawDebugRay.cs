using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class DrawDebugRay : FsmStateAction
	{
		public FsmGameObject fromObject;
		public FsmVector3 fromPosition;
		public FsmVector3 direction;
		public FsmColor color;
	}
}
