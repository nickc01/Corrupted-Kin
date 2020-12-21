using HutongGames.PlayMaker;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	public class uGuiTransitionSetType : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public Selectable.Transition transition;
		public FsmBool resetOnExit;
	}
}
