using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetSpriteRendererByColor : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmColor Color;
		public FsmBool EveryFrame;
	}
}
