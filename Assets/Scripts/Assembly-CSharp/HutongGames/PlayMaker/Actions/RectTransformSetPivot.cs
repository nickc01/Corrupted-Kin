using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class RectTransformSetPivot : FsmStateActionAdvanced
	{
		public FsmOwnerDefault gameObject;
		public FsmVector2 pivot;
		public FsmFloat x;
		public FsmFloat y;
	}
}
