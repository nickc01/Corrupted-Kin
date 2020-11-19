using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class StringSplit : FsmStateAction
	{
		public FsmString stringToSplit;
		public FsmString separators;
		public FsmBool trimStrings;
		public FsmString trimChars;
		public FsmArray stringArray;
	}
}
