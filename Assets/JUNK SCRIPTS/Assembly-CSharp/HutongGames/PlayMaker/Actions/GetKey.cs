using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class GetKey : FsmStateAction
	{
		public KeyCode key;
		public FsmBool storeResult;
		public bool everyFrame;
	}
}
