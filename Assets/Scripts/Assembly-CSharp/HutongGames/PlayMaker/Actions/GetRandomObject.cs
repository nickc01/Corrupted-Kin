using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetRandomObject : FsmStateAction
	{
		public FsmString withTag;
		public FsmGameObject storeResult;
		public bool everyFrame;
	}
}
