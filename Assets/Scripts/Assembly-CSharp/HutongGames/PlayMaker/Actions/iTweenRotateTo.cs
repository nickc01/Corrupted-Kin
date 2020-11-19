using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class iTweenRotateTo : iTweenFsmAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString id;
		public FsmGameObject transformRotation;
		public FsmVector3 vectorRotation;
		public FsmFloat time;
		public FsmFloat delay;
		public FsmFloat speed;
		public iTween.EaseType easeType;
		public iTween.LoopType loopType;
		public Space space;
	}
}
