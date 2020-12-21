using UnityEngine;

public class MegaJellyZap : MonoBehaviour
{
	public enum Type
	{
		Zap = 0,
		MultiZap = 1,
	}

	public Type type;
	public ParticleSystem ptAttack;
	public ParticleSystem ptAntic;
	public AudioSource audioSourcePrefab;
	public AudioEvent zapBugPt1;
	public AudioEvent zapBugPt2;
	public tk2dSpriteAnimator anim;
}
