using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class iTweenShakeRotation : iTweenFsmAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString id;
		public FsmVector3 vector;
		public FsmFloat time;
		public FsmFloat delay;
		public iTween.LoopType loopType;
		public Space space;
	}
}
