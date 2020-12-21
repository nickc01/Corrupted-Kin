using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ScaleTime : FsmStateAction
	{
		public FsmFloat timeScale;
		public FsmBool adjustFixedDeltaTime;
		public bool everyFrame;
	}
}
