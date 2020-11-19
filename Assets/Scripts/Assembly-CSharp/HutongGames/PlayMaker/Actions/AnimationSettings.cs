using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class AnimationSettings : BaseAnimationAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString animName;
		public WrapMode wrapMode;
		public AnimationBlendMode blendMode;
		public FsmFloat speed;
		public FsmInt layer;
	}
}
