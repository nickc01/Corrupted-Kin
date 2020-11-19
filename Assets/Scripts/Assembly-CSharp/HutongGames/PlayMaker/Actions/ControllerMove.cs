using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class ControllerMove : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmVector3 moveVector;
		public Space space;
		public FsmBool perSecond;
	}
}
