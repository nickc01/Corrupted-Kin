using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetParticleEmissionRate : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat emissionRate;
		public bool everyFrame;
	}
}
