using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetParticleEmissionSpeed : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat emissionSpeed;
		public bool everyFrame;
	}
}
