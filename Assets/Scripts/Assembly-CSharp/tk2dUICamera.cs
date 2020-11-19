using UnityEngine;

public class tk2dUICamera : MonoBehaviour
{
	public enum tk2dRaycastType
	{
		Physics3D = 0,
		Physics2D = 1,
	}

	[SerializeField]
	private LayerMask raycastLayerMask;
	[SerializeField]
	private tk2dRaycastType raycastType;
}
