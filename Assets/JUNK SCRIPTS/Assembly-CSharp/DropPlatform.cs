using UnityEngine;

public class DropPlatform : MonoBehaviour
{
	public tk2dSpriteAnimator spriteAnimator;
	public string idleAnim;
	public string dropAnim;
	public string raiseAnim;
	public AudioClip landSound;
	public AudioClip dropSound;
	public AudioClip flipUpSound;
	public GameObject strikeEffect;
	public Collider2D collider;
}
