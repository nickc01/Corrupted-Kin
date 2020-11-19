using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class GetScale : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmVector3 vector;
		public FsmFloat xScale;
		public FsmFloat yScale;
		public FsmFloat zScale;
		public Space space;
		public bool everyFrame;
	}
}
