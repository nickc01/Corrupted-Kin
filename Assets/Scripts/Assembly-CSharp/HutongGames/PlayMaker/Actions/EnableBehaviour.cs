using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class EnableBehaviour : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString behaviour;
		public Component component;
		public FsmBool enable;
		public FsmBool resetOnExit;
	}
}
