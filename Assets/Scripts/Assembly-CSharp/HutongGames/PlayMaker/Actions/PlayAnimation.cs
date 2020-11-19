using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class PlayAnimation : BaseAnimationAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString animName;
		public PlayMode playMode;
		public FsmFloat blendTime;
		public FsmEvent finishEvent;
		public FsmEvent loopEvent;
		public bool stopOnExit;
	}
}
