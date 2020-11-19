using UnityEngine;

public class BounceShroom : MonoBehaviour
{
	public bool active;
	public GameObject idleParticlePrefab;
	public GameObject bounceSmallPrefab;
	public GameObject bounceLargePrefab;
	public GameObject heroParticlePrefab;
	public string idleAnim;
	public string bobAnim;
	public string bounceAnim;
	public GameObject hitEffect;
	public AudioSource audioSourcePrefab;
	public RandomAudioClipTable hitSound;
}
