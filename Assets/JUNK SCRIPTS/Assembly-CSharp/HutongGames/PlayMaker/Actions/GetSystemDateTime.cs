using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetSystemDateTime : FsmStateAction
	{
		public FsmString storeString;
		public FsmString format;
		public bool everyFrame;
	}
}
