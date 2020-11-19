using UnityEngine;

public class JellyEgg : MonoBehaviour
{
	public bool bomb;
	public GameObject explosionObject;
	public ParticleSystem popEffect;
	public GameObject strikeEffect;
	public MeshRenderer meshRenderer;
	public AudioSource audioSource;
	public VibrationData popVibration;
	public CircleCollider2D circleCollider;
	public GameObject falseShiny;
	public GameObject shinyItem;
}
