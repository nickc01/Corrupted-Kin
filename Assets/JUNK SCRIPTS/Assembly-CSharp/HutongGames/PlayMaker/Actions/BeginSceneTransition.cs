using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class BeginSceneTransition : FsmStateAction
	{
		public FsmString sceneName;
		public FsmString entryGateName;
		public FsmFloat entryDelay;
		public FsmEnum visualization;
		public bool preventCameraFadeOut;
	}
}
