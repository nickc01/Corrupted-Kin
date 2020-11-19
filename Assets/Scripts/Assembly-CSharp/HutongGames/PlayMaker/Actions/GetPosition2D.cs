using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class GetPosition2D : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmVector2 vector;
		public FsmFloat x;
		public FsmFloat y;
		public Space space;
		public bool everyFrame;
	}
}
