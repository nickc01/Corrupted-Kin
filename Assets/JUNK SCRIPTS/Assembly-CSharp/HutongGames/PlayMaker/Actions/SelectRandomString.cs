using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SelectRandomString : FsmStateAction
	{
		public FsmString[] strings;
		public FsmFloat[] weights;
		public FsmString storeString;
	}
}
