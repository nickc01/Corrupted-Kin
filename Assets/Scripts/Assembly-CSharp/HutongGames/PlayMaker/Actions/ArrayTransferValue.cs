using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ArrayTransferValue : FsmStateAction
	{
		public FsmArray arraySource;
		public FsmArray arrayTarget;
		public FsmInt indexToTransfer;
		public FsmEnum copyType;
		public FsmEnum pasteType;
		public FsmEvent indexOutOfRange;
	}
}
