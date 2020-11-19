using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SmoothFollowTarget2D : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject targetObject;
		public float dampTime;
	}
}
