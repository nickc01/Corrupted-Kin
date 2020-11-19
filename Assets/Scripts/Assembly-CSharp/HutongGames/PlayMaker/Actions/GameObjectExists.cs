using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GameObjectExists : FsmStateAction
	{
		public FsmString objectName;
		public FsmString withTag;
		public FsmBool result;
	}
}
