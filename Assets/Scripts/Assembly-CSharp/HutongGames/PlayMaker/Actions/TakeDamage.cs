using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class TakeDamage : FsmStateAction
	{
		public FsmGameObject Target;
		public FsmInt AttackType;
		public FsmBool CircleDirection;
		public FsmInt DamageDealt;
		public FsmFloat Direction;
		public FsmBool IgnoreInvulnerable;
		public FsmFloat MagnitudeMultiplier;
		public FsmFloat MoveAngle;
		public FsmBool MoveDirection;
		public FsmFloat Multiplier;
		public FsmInt SpecialType;
	}
}
