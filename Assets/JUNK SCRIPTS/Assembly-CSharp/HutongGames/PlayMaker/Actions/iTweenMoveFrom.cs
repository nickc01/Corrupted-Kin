using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class iTweenMoveFrom : iTweenFsmAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString id;
		public FsmGameObject transformPosition;
		public FsmVector3 vectorPosition;
		public FsmFloat time;
		public FsmFloat delay;
		public FsmFloat speed;
		public iTween.EaseType easeType;
		public iTween.LoopType loopType;
		public Space space;
		public FsmBool orientToPath;
		public FsmGameObject lookAtObject;
		public FsmVector3 lookAtVector;
		public FsmFloat lookTime;
		public iTweenFsmAction.AxisRestriction axis;
	}
}
