using UnityEngine;
using System.Collections.Generic;

public class GlowResponse : MonoBehaviour
{
	[SerializeField]
	private SpriteRenderer fadeSprite;
	public List<SpriteRenderer> FadeSprites;
	public float fadeTime;
	public ParticleSystem particles;
	public Light light;
	public AudioSource audioPlayerPrefab;
	public AudioEventRandom soundEffect;
}
