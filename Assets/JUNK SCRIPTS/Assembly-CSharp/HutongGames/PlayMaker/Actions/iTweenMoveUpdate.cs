using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class iTweenMoveUpdate : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject transformPosition;
		public FsmVector3 vectorPosition;
		public FsmFloat time;
		public Space space;
		public FsmBool orientToPath;
		public FsmGameObject lookAtObject;
		public FsmVector3 lookAtVector;
		public FsmFloat lookTime;
		public iTweenFsmAction.AxisRestriction axis;
	}
}
