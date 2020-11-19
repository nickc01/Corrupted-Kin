using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class CheckCollisionSideEnter : FsmStateAction
	{
		public FsmBool topHit;
		public FsmBool rightHit;
		public FsmBool bottomHit;
		public FsmBool leftHit;
		public FsmEvent topHitEvent;
		public FsmEvent rightHitEvent;
		public FsmEvent bottomHitEvent;
		public FsmEvent leftHitEvent;
		public bool otherLayer;
		public int otherLayerNumber;
		public FsmBool ignoreTriggers;
	}
}
