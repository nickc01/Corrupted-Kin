using UnityEngine;

public class BreakablePole : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer spriteRenderer;
	[SerializeField]
	private Sprite brokenSprite;
	[SerializeField]
	private float inertBackgroundThreshold;
	[SerializeField]
	private float inertForegroundThreshold;
	[SerializeField]
	private AudioSource audioSourcePrefab;
	[SerializeField]
	private RandomAudioClipTable hitClip;
	[SerializeField]
	private GameObject slashImpactPrefab;
	[SerializeField]
	private Rigidbody2D top;
}
