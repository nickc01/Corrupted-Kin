using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetRaycastAllInfo : FsmStateAction
	{
		public FsmArray storeHitObjects;
		public FsmArray points;
		public FsmArray normals;
		public FsmArray distances;
		public bool everyFrame;
	}
}
