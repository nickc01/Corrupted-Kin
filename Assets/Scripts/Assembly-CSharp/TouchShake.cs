using UnityEngine;

public class TouchShake : MonoBehaviour
{
	public SpriteRenderer spriteRenderer;
	public BasicSpriteAnimator anim;
	public tk2dSpriteAnimator tk2dAnim;
	public ParticleSystem particles;
	public int emitParticles;
	public AudioSource audioSourcePrefab;
	public RandomAudioClipTable audioTable;
}
