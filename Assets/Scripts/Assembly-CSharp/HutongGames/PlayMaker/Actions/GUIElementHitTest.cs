using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class GUIElementHitTest : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public Camera camera;
		public FsmVector3 screenPoint;
		public FsmFloat screenX;
		public FsmFloat screenY;
		public FsmBool normalized;
		public FsmEvent hitEvent;
		public FsmBool storeResult;
		public FsmBool everyFrame;
	}
}
