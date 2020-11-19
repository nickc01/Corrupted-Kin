using UnityEngine;

public class GlobControl : MonoBehaviour
{
	public Renderer rend;
	public float minScale;
	public float maxScale;
	public string landAnim;
	public string wobbleAnim;
	public string breakAnim;
	public AudioSource audioPlayerPrefab;
	public AudioEvent breakSound;
	public Color bloodColorOverride;
	public GameObject splatChild;
	public Collider2D groundCollider;
}
