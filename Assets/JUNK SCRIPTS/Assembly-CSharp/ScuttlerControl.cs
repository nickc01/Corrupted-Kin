using UnityEngine;

public class ScuttlerControl : MonoBehaviour
{
	public bool startIdle;
	public bool startRunning;
	public string killedPDBool;
	public string killsPDBool;
	public string newDataPDBool;
	public string runAnim;
	public string landAnim;
	public GameObject corpsePrefab;
	public GameObject splatEffectChild;
	public GameObject journalUpdateMsgPrefab;
	public AudioSource audioSourcePrefab;
	public AudioEvent bounceSound;
	public TriggerEnterEvent heroAlert;
	public bool healthScuttler;
	public GameObject strikeNailPrefab;
	public GameObject slashImpactPrefab;
	public GameObject fireballHitPrefab;
	public AudioEvent deathSound1;
	public AudioEvent deathSound2;
	public GameObject pool;
	public GameObject screenFlash;
	public Color bloodColor;
}
