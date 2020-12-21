using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FindGameObject : FsmStateAction
	{
		public FsmString objectName;
		public FsmString withTag;
		public FsmGameObject store;
	}
}
