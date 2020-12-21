using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class PlayRandomAnimation : BaseAnimationAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString[] animations;
		public FsmFloat[] weights;
		public PlayMode playMode;
		public FsmFloat blendTime;
		public FsmEvent finishEvent;
		public FsmEvent loopEvent;
		public bool stopOnExit;
	}
}
