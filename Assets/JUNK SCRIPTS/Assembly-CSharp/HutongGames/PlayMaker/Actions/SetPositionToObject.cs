using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetPositionToObject : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject targetObject;
		public FsmFloat xOffset;
		public FsmFloat yOffset;
		public FsmFloat zOffset;
	}
}
