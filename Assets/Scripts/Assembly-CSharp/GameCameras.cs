using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class GameCameras : MonoBehaviour
{
	public Camera hudCamera;
	public Camera mainCamera;
	public CameraController cameraController;
	public CameraTarget cameraTarget;
	public ForceCameraAspect forceCameraAspect;
	public PlayMakerFSM cameraFadeFSM;
	public PlayMakerFSM cameraShakeFSM;
	public PlayMakerFSM soulOrbFSM;
	public PlayMakerFSM soulVesselFSM;
	public PlayMakerFSM openStagFSM;
	public ColorCorrectionCurves colorCorrectionCurves;
	public SceneColorManager sceneColorManager;
	public BrightnessEffect brightnessEffect;
	public SceneParticlesController sceneParticlesPrefab;
	public tk2dCamera tk2dCam;
	public GameObject hudCanvas;
	public Transform cameraParent;
	public GeoCounter geoCounter;
}
