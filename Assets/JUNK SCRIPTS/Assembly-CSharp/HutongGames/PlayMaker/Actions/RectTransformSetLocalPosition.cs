using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class RectTransformSetLocalPosition : FsmStateActionAdvanced
	{
		public FsmOwnerDefault gameObject;
		public FsmVector2 position2d;
		public FsmVector3 position;
		public FsmFloat x;
		public FsmFloat y;
		public FsmFloat z;
	}
}
