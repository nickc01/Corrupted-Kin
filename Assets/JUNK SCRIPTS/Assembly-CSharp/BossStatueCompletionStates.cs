using UnityEngine;
using System;

public class BossStatueCompletionStates : MonoBehaviour
{
	[Serializable]
	public struct State
	{
		[SerializeField]
		private GameObject gameObject;
		[SerializeField]
		private string playmakerEvent;
	}

	public BossSummaryBoard bossListSource;
	public State defaultState;
	public State[] tierStates;
	public bool checkTiersAdditive;
}
