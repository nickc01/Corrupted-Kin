using UnityEngine;

public class tk2dUIManager : MonoBehaviour
{
	[SerializeField]
	private Camera uiCamera;
	public LayerMask raycastLayerMask;
	public bool areHoverEventsTracked;
	[SerializeField]
	private bool useMultiTouch;
}
