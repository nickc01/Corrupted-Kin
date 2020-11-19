using UnityEngine;

public class DreamPlantOrb : MonoBehaviour
{
	public BasicSpriteAnimator pickupAnim;
	public AudioSource loopSource;
	public AudioSource soundSource;
	public AudioClip collectSound;
	public float basePitch;
	public float increasePitch;
	public float maxPitch;
	public float pitchReturnDelay;
	public GameObject whiteFlash;
	public ParticleSystem pickupParticles;
	public ParticleSystem trailParticles;
	public ParticleSystem activateParticles;
	public AnimationCurve spread1Curve;
	public AnimationCurve spread2Curve;
}
