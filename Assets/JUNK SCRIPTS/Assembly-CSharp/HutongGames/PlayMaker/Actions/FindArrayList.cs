using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FindArrayList : CollectionsActions
	{
		public FsmString ArrayListReference;
		public FsmGameObject store;
		public FsmEvent foundEvent;
		public FsmEvent notFoundEvent;
	}
}
