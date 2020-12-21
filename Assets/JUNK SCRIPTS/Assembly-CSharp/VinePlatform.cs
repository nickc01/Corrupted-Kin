using UnityEngine;

public class VinePlatform : MonoBehaviour
{
	public GameObject platformSprite;
	public GameObject activatedSprite;
	public Collider2D collider;
	public AudioClip playerLandSound;
	public ParticleSystem playerLandParticles;
	public AnimationCurve playerLandAnimCurve;
	public float playerLandAnimLength;
	public bool respondOnLand;
	public TriggerEnterEvent landingDetector;
	public AudioClip landSound;
	public ParticleSystem[] landParticles;
	public GameObject slamEffect;
	public TriggerEnterEvent enemyDetector;
	public bool acidLander;
	public float acidTargetY;
	public AudioClip acidSplashSound;
	public GameObject acidSplashPrefab;
}
