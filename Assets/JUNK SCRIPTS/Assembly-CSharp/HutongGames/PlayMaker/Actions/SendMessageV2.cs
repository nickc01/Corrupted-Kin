using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class SendMessageV2 : FsmStateAction
	{
		public enum MessageType
		{
			SendMessage = 0,
			SendMessageUpwards = 1,
			BroadcastMessage = 2,
		}

		public FsmOwnerDefault gameObject;
		public MessageType delivery;
		public SendMessageOptions options;
		public FunctionCall functionCall;
		public bool everyFrame;
	}
}
