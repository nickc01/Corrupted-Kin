using UnityEngine;

public class DustyPlatform : MonoBehaviour
{
	[SerializeField]
	private float inset;
	[SerializeField]
	private LayerMask dustIgnoredLayers;
	[SerializeField]
	private RandomAudioClipTable dustFallClips;
	[SerializeField]
	private AudioSource dustFallSourcePrefab;
	[SerializeField]
	private ParticleSystem dustPrefab;
	[SerializeField]
	private ParticleSystem rocksPrefab;
	[SerializeField]
	private float dustRateAreaFactor;
	[SerializeField]
	private float dustRateConstant;
	[SerializeField]
	private GameObject streamPrefab;
	[SerializeField]
	private Vector3 streamOffset;
	[SerializeField]
	private float streamEmissionMin;
	[SerializeField]
	private float streamEmissionMax;
	[SerializeField]
	private float rocksChance;
	[SerializeField]
	private float rocksDelay;
	[SerializeField]
	private Transform rockPrefab;
	[SerializeField]
	private int rockCountMin;
	[SerializeField]
	private int rockCountMax;
	[SerializeField]
	private float cooldownDuration;
}
