using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class Explosion : FsmStateAction
	{
		public FsmVector3 center;
		public FsmFloat force;
		public FsmFloat radius;
		public FsmFloat upwardsModifier;
		public ForceMode forceMode;
		public FsmInt layer;
		public FsmInt[] layerMask;
		public FsmBool invertMask;
		public bool everyFrame;
	}
}
