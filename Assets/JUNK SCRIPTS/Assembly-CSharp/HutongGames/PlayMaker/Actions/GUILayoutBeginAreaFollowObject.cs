using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GUILayoutBeginAreaFollowObject : FsmStateAction
	{
		public FsmGameObject gameObject;
		public FsmFloat offsetLeft;
		public FsmFloat offsetTop;
		public FsmFloat width;
		public FsmFloat height;
		public FsmBool normalized;
		public FsmString style;
	}
}
