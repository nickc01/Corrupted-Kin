using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FsmArraySet : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString fsmName;
		public FsmString variableName;
		public FsmString setValue;
		public bool everyFrame;
	}
}
