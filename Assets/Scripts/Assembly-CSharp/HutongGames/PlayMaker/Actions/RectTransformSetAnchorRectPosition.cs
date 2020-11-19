using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class RectTransformSetAnchorRectPosition : FsmStateActionAdvanced
	{
		public enum AnchorReference
		{
			TopLeft = 0,
			Top = 1,
			TopRight = 2,
			Right = 3,
			BottomRight = 4,
			Bottom = 5,
			BottomLeft = 6,
			Left = 7,
			Center = 8,
		}

		public FsmOwnerDefault gameObject;
		public AnchorReference anchorReference;
		public FsmBool normalized;
		public FsmVector2 anchor;
		public FsmFloat x;
		public FsmFloat y;
	}
}
