using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class iTweenMoveAdd : iTweenFsmAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString id;
		public FsmVector3 vector;
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
