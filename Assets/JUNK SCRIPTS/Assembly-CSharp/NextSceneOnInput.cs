using UnityEngine;
using UnityEngine.Events;

public class NextSceneOnInput : MonoBehaviour
{
	private enum NextSceneType
	{
		GGReturn = 0,
	}

	[SerializeField]
	private UnityEvent onBeforeSave;
	[SerializeField]
	private bool doSaveOnStart;
	[SerializeField]
	private bool acceptingInput;
	[SerializeField]
	private float maxInputBlockDelay;
	[SerializeField]
	private NextSceneType nextSceneType;
}
