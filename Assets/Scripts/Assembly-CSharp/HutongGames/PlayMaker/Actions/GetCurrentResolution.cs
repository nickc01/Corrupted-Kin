using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetCurrentResolution : FsmStateAction
	{
		public FsmFloat width;
		public FsmFloat height;
		public FsmFloat refreshRate;
		public FsmVector3 currentResolution;
	}
}
