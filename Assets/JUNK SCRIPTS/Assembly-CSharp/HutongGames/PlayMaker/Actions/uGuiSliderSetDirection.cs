using HutongGames.PlayMaker;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	public class uGuiSliderSetDirection : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public Slider.Direction direction;
		public FsmBool resetOnExit;
	}
}
