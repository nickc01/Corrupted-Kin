using UnityEngine;

public class LightBlurredBackground : MonoBehaviour
{
	[SerializeField]
	private float distantFarClipPlane;
	[SerializeField]
	private int renderTextureWidth;
	[SerializeField]
	private int renderTextureHeight;
	[SerializeField]
	private Material blitMaterial;
	[SerializeField]
	private float clipEpsilon;
	[SerializeField]
	private LayerMask blurPlaneLayer;
}
