using UnityEngine;
using UnityEngine.Audio;

public class TransitionPoint : MonoBehaviour
{
	public bool isADoor;
	public bool dontWalkOutOfDoor;
	public float entryDelay;
	public bool alwaysEnterRight;
	public bool alwaysEnterLeft;
	public bool hardLandOnExit;
	public string targetScene;
	public string entryPoint;
	public Vector2 entryOffset;
	[SerializeField]
	private bool alwaysUnloadUnusedAssets;
	public PlayMakerFSM customFadeFSM;
	public bool nonHazardGate;
	public HazardRespawnMarker respawnMarker;
	public AudioMixerSnapshot atmosSnapshot;
	public AudioMixerSnapshot enviroSnapshot;
	public AudioMixerSnapshot actorSnapshot;
	public AudioMixerSnapshot musicSnapshot;
	public GameManager.SceneLoadVisualizations sceneLoadVisualization;
	public bool customFade;
	public bool forceWaitFetch;
}
