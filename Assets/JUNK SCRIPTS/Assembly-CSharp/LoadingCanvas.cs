using UnityEngine;

public class LoadingCanvas : MonoBehaviour
{
	[SerializeField]
	private GameObject[] visualizationContainers;
	[SerializeField]
	private LoadingSpinner defaultLoadingSpinner;
	[SerializeField]
	private float continueFromSaveDelayAdjustment;
}
