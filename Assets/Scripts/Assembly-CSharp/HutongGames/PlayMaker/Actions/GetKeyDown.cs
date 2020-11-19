using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class GetKeyDown : FsmStateAction
	{
		public KeyCode key;
		public FsmEvent sendEvent;
		public FsmBool storeResult;
	}
}
