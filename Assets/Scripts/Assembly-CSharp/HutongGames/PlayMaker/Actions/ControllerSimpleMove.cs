using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class ControllerSimpleMove : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmVector3 moveVector;
		public FsmFloat speed;
		public Space space;
	}
}
