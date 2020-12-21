using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetObjectValue : FsmStateAction
	{
		public FsmObject objectVariable;
		public FsmObject objectValue;
		public bool everyFrame;
	}
}
