using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetTransform : FsmStateAction
	{
		public FsmGameObject gameObject;
		public FsmObject storeTransform;
		public bool everyFrame;
	}
}
