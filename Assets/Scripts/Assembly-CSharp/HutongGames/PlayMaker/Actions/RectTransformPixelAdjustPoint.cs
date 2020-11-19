using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class RectTransformPixelAdjustPoint : FsmStateActionAdvanced
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject canvas;
		public FsmVector2 screenPoint;
		public FsmVector2 pixelPoint;
	}
}
