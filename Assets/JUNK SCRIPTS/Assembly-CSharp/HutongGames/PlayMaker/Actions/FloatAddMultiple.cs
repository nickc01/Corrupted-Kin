using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FloatAddMultiple : FsmStateAction
	{
		public FsmFloat[] floatVariables;
		public FsmFloat addTo;
		public bool everyFrame;
	}
}
