using UnityEngine;

public class InfectedEnemyEffects : MonoBehaviour
{
	[SerializeField]
	private Vector3 effectOrigin;
	[SerializeField]
	private AudioEvent impactAudio;
	[SerializeField]
	private AudioSource audioSourcePrefab;
	[SerializeField]
	private GameObject hitFlashOrangePrefab;
	[SerializeField]
	private GameObject spatterOrangePrefab;
	[SerializeField]
	private GameObject hitPuffPrefab;
	[SerializeField]
	private bool noBlood;
}
