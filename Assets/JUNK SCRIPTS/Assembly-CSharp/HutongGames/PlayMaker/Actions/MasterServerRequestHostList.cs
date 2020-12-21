using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class MasterServerRequestHostList : FsmStateAction
	{
		public FsmString gameTypeName;
		public FsmEvent HostListArrivedEvent;
	}
}
