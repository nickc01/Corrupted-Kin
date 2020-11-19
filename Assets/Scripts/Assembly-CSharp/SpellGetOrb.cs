using UnityEngine;

public class SpellGetOrb : MonoBehaviour
{
	public SpriteRenderer spriteRenderer;
	public Rigidbody2D rb2d;
	public GameObject trailObject;
	public TrailRenderer trailRenderer;
	public GameObject orbGetObject;
	public ParticleSystem ptIdle;
	public ParticleSystem ptZoom;
	public bool trackToHero;
}
