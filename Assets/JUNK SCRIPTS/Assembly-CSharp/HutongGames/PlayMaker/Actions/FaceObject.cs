using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FaceObject : FsmStateAction
	{
		public FsmGameObject objectA;
		public FsmGameObject objectB;
		public FsmBool spriteFacesRight;
		public bool playNewAnimation;
		public FsmString newAnimationClip;
		public bool resetFrame;
		public bool everyFrame;
	}
}
