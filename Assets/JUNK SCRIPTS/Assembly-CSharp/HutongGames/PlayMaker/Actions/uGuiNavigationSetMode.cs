using HutongGames.PlayMaker;
using UnityEngine.UI;

namespace HutongGames.PlayMaker.Actions
{
	public class uGuiNavigationSetMode : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public Navigation.Mode navigationMode;
		public FsmBool resetOnExit;
	}
}
