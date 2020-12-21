using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class WalkLeftRight : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public float walkSpeed;
		public bool spriteFacesLeft;
		public FsmString groundLayer;
		public float turnDelay;
		public FsmString walkAnimName;
		public FsmString turnAnimName;
		public FsmBool startLeft;
		public FsmBool startRight;
		public FsmBool keepDirection;
	}
}
