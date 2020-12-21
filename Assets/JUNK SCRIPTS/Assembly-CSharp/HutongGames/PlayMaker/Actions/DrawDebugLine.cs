using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class DrawDebugLine : FsmStateAction
	{
		public FsmGameObject fromObject;
		public FsmVector3 fromPosition;
		public FsmGameObject toObject;
		public FsmVector3 toPosition;
		public FsmColor color;
	}
}
