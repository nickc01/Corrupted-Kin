using UnityEngine;

public class Corpse : MonoBehaviour
{
	[SerializeField]
	protected ParticleSystem corpseFlame;
	[SerializeField]
	protected ParticleSystem corpseSteam;
	[SerializeField]
	protected GameObject landEffects;
	[SerializeField]
	protected AudioSource audioPlayerPrefab;
	[SerializeField]
	protected GameObject deathWaveInfectedPrefab;
	[SerializeField]
	protected GameObject spatterOrangePrefab;
	[SerializeField]
	protected RandomAudioClipTable splatAudioClipTable;
	[SerializeField]
	private int smashBounces;
	[SerializeField]
	private bool breaker;
	[SerializeField]
	private bool bigBreaker;
	[SerializeField]
	private bool chunker;
	[SerializeField]
	private bool deathStun;
	[SerializeField]
	private bool fungusExplode;
	[SerializeField]
	private bool goopExplode;
	[SerializeField]
	private bool hatcher;
	[SerializeField]
	private bool instantChunker;
	[SerializeField]
	private bool massless;
	[SerializeField]
	private bool resetRotation;
	[SerializeField]
	private AudioEvent startAudio;
	[SerializeField]
	private bool spineBurst;
	[SerializeField]
	private bool zomHive;
}
