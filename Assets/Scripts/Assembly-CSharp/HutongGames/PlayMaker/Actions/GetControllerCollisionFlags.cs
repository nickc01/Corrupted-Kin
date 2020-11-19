using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetControllerCollisionFlags : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmBool isGrounded;
		public FsmBool none;
		public FsmBool sides;
		public FsmBool above;
		public FsmBool below;
	}
}
