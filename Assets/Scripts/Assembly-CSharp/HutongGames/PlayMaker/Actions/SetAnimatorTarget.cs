using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class SetAnimatorTarget : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public AvatarTarget avatarTarget;
		public FsmFloat targetNormalizedTime;
		public bool everyFrame;
	}
}
