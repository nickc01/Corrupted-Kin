using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class RectTransformSetSizeDelta : FsmStateActionAdvanced
	{
		public FsmOwnerDefault gameObject;
		public FsmVector2 sizeDelta;
		public FsmFloat x;
		public FsmFloat y;
	}
}
