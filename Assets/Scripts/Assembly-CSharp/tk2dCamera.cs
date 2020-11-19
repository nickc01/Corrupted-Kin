using UnityEngine;

public class tk2dCamera : MonoBehaviour
{
	public int version;
	[SerializeField]
	private tk2dCameraSettings cameraSettings;
	public tk2dCameraResolutionOverride[] resolutionOverride;
	[SerializeField]
	private tk2dCamera inheritSettings;
	public int nativeResolutionWidth;
	public int nativeResolutionHeight;
	[SerializeField]
	private Camera _unityCamera;
	public bool viewportClippingEnabled;
	public Vector4 viewportRegion;
	[SerializeField]
	private float zoomFactor;
	public bool forceResolutionInEditor;
	public Vector2 forceResolution;
}
