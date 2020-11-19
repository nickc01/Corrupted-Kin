using UnityEngine;

public class OpeningSequence : MonoBehaviour
{
	[SerializeField]
	private ChainSequence chainSequence;
	[SerializeField]
	private ThreadPriority streamingLoadPriority;
	[SerializeField]
	private ThreadPriority completedLoadPriority;
	[SerializeField]
	private float skipChargeDuration;
}
