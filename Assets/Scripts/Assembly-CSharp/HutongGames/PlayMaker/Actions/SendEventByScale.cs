using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class SendEventByScale : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmEventTarget eventTarget;
		public bool xScale;
		public FsmEvent positiveEvent;
		public FsmEvent negativeEvent;
		public Space space;
	}
}
