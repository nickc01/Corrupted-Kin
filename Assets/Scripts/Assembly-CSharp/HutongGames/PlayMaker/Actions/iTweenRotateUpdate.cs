using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class iTweenRotateUpdate : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmGameObject transformRotation;
		public FsmVector3 vectorRotation;
		public FsmFloat time;
		public Space space;
	}
}
