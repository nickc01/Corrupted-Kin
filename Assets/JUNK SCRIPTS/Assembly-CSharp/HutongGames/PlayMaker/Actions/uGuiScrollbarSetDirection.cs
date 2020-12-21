using HutongGames.PlayMaker;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	public class uGuiScrollbarSetDirection : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public Scrollbar.Direction direction;
		public FsmBool resetOnExit;
	}
}
