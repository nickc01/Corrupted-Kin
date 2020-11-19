using System;

namespace HutongGames.PlayMaker
{
	[Serializable]
	public class LayoutOption
	{
		public enum LayoutOptionType
		{
			Width = 0,
			Height = 1,
			MinWidth = 2,
			MaxWidth = 3,
			MinHeight = 4,
			MaxHeight = 5,
			ExpandWidth = 6,
			ExpandHeight = 7,
		}

		public LayoutOptionType option;
		public FsmFloat floatParam;
		public FsmBool boolParam;
	}
}
