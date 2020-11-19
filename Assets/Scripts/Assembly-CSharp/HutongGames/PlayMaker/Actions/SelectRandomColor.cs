using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SelectRandomColor : FsmStateAction
	{
		public FsmColor[] colors;
		public FsmFloat[] weights;
		public FsmColor storeColor;
	}
}
