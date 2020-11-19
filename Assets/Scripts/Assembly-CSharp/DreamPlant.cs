using UnityEngine;

public class DreamPlant : MonoBehaviour
{
	public HeroDetect heroDetector;
	public AudioClip glowSound;
	public ParticleSystem wiltedParticles;
	public ColorFader glowFader;
	public ColorFader completeGlowFader;
	public AudioClip hitSound;
	public GameObject dreamImpact;
	public GameObject dreamAreaEffect;
	public ParticleSystem activateParticles;
	public ParticleSystem activatedParticles;
	public GameObject whiteFlash;
	public AudioClip growChargeSound;
	public AudioClip growSound;
	public ParticleSystem completeChargeParticles;
	public ParticleSystem growParticles;
	public GameObject dreamDialogue;
	public string playerdataBool;
}
