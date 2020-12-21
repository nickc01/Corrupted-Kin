using UnityEngine;
using System;

public class BossDoorCompletionStates : MonoBehaviour
{
	[Serializable]
	public class CompletionState
	{
		public GameObject stateObject;
		public string sendEvent;
	}

	public CompletionState[] completionStates;
	public string stateSeenPlayerData;
}
