using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class NetworkHavePublicIpAddress : FsmStateAction
	{
		public FsmBool havePublicIpAddress;
		public FsmEvent publicIpAddressFoundEvent;
		public FsmEvent publicIpAddressNotFoundEvent;
	}
}
