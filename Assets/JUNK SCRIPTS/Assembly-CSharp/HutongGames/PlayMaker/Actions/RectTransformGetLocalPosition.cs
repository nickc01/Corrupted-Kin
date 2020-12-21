using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class RectTransformGetLocalPosition : FsmStateActionAdvanced
	{
		public enum LocalPositionReference
		{
			Anchor = 0,
			CenterPosition = 1,
		}

		public FsmOwnerDefault gameObject;
		public LocalPositionReference reference;
		public FsmVector3 position;
		public FsmVector2 position2d;
		public FsmFloat x;
		public FsmFloat y;
		public FsmFloat z;
	}
}
