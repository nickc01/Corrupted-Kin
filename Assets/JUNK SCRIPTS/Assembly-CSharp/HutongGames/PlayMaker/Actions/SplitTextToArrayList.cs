using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class SplitTextToArrayList : ArrayListActions
	{
		public enum SplitSpecialChars
		{
			NewLine = 0,
			Tab = 1,
			Space = 2,
		}

		public enum ArrayMakerParseStringAs
		{
			String = 0,
			Int = 1,
			Float = 2,
		}

		public FsmOwnerDefault gameObject;
		public FsmString reference;
		public FsmInt startIndex;
		public FsmInt parseRange;
		public TextAsset textAsset;
		public FsmString OrThisString;
		public SplitSpecialChars split;
		public FsmString OrThisChar;
		public ArrayMakerParseStringAs parseAsType;
	}
}
