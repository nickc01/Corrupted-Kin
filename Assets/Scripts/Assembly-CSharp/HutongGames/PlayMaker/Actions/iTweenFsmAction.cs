using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class iTweenFsmAction : FsmStateAction
	{
		public enum AxisRestriction
		{
			none = 0,
			x = 1,
			y = 2,
			z = 3,
			xy = 4,
			xz = 5,
			yz = 6,
		}

		public FsmEvent startEvent;
		public FsmEvent finishEvent;
		public FsmBool realTime;
		public FsmBool stopOnExit;
		public FsmBool loopDontFinish;
	}
}
