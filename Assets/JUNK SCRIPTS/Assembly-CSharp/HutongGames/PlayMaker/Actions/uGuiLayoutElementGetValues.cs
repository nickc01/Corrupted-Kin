using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class uGuiLayoutElementGetValues : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmBool ignoreLayout;
		public FsmBool minWidthEnabled;
		public FsmFloat minWidth;
		public FsmBool minHeightEnabled;
		public FsmFloat minHeight;
		public FsmBool preferredWidthEnabled;
		public FsmFloat preferredWidth;
		public FsmBool preferredHeightEnabled;
		public FsmFloat preferredHeight;
		public FsmBool flexibleWidthEnabled;
		public FsmFloat flexibleWidth;
		public FsmBool flexibleHeightEnabled;
		public FsmFloat flexibleHeight;
		public bool everyFrame;
	}
}
