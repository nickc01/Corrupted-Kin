using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class NetworkDestroy : ComponentAction<NetworkView>
	{
		public FsmOwnerDefault gameObject;
		public FsmBool removeRPCs;
	}
}
