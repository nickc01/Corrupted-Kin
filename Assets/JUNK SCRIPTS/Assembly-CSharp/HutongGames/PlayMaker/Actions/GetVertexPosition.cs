using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class GetVertexPosition : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmInt vertexIndex;
		public Space space;
		public FsmVector3 storePosition;
		public bool everyFrame;
	}
}
