using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class GetKeyUp : FsmStateAction
	{
		public KeyCode key;
		public FsmEvent sendEvent;
		public FsmBool storeResult;
	}
}
