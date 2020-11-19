using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class ScreenSetResolution : FsmStateAction
	{
		public FsmBool fullScreen;
		public FsmInt width;
		public FsmInt height;
		public FsmInt preferedRefreshRate;
		public FsmVector3 orResolution;
	}
}
