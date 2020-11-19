using UnityEngine;

public class FlipPlatform : MonoBehaviour
{
	public tk2dSpriteAnimator spriteAnimator;
	public AudioClip flipSound;
	public AudioClip flipBackSound;
	public AudioClip hitSound;
	public GameObject strikeEffect;
	public GameObject nailStrikePrefab;
	public ParticleSystem crystalParticles;
	public ParticleSystem crystalHitParticles;
	public GameObject topSpikes;
	public GameObject bottomSpikes;
}
