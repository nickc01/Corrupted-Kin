using UnityEngine;
using GlobalEnums;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
	public enum SceneLoadVisualizations
	{
		Default = 0,
		Custom = -1,
		Dream = 1,
		Colosseum = 2,
		GrimmDream = 3,
		ContinueFromSave = 4,
		GodsAndGlory = 5,
	}

	public GameState gameState;
	public bool isPaused;
	public string sceneName;
	public string nextSceneName;
	public string entryGateName;
	public float sceneWidth;
	public float sceneHeight;
	public GameConfig gameConfig;
	[SerializeField]
	private AudioManager audioManager;
	[SerializeField]
	public GameSettings gameSettings;
	public TimeScaleIndependentUpdate timeTool;
	public GameObject gameMap;
	public PlayMakerFSM inventoryFSM;
	[SerializeField]
	public PlayerData playerData;
	[SerializeField]
	public SceneData sceneData;
	public int profileID;
	public bool startedOnThisScene;
	public AudioMixerSnapshot actorSnapshotUnpaused;
	public AudioMixerSnapshot actorSnapshotPaused;
	public AudioMixerSnapshot silentSnapshot;
	public AudioMixerSnapshot noMusicSnapshot;
	public MusicCue noMusicCue;
	public AudioMixerSnapshot noAtmosSnapshot;
	[SerializeField]
	private WorldInfo worldInfo;
	[SerializeField]
	private StandaloneLoadingSpinner standaloneLoadingSpinnerPrefab;
}
