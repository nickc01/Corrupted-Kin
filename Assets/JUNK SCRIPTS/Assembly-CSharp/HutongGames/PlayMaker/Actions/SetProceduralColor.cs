using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetProceduralColor : FsmStateAction
	{
		public FsmMaterial substanceMaterial;
		public FsmString colorProperty;
		public FsmColor colorValue;
		public bool everyFrame;
	}
}
