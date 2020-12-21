using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetPlayerDataVector3 : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmString vector3Name;
		public FsmVector3 value;
	}
}
