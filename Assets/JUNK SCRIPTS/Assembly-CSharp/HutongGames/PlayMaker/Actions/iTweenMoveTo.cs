using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class iTweenMoveTo : iTweenFsmAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString id;
		public FsmGameObject transformPosition;
		public FsmVector3 vectorPosition;
		public FsmFloat time;
		public FsmFloat delay;
		public FsmFloat speed;
		public Space space;
		public iTween.EaseType easeType;
		public iTween.LoopType loopType;
		public FsmBool orientToPath;
		public FsmGameObject lookAtObject;
		public FsmVector3 lookAtVector;
		public FsmFloat lookTime;
		public iTweenFsmAction.AxisRestriction axis;
		public FsmBool moveToPath;
		public FsmFloat lookAhead;
		public FsmGameObject[] transforms;
		public FsmVector3[] vectors;
		public FsmBool reverse;
	}
}
