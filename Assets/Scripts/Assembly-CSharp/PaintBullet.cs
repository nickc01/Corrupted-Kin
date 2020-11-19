using UnityEngine;
using System.Collections.Generic;

public class PaintBullet : MonoBehaviour
{
	public float scaleMin;
	public float scaleMax;
	public float stretchFactor;
	public float stretchMinX;
	public float stretchMaxY;
	public AudioSource audioSourcePrefab;
	public List<AudioClip> splatClips;
	public ParticleSystem impactParticle;
	public ParticleSystem trailParticle;
	public GameObject splatEffect;
	public tk2dSprite splatEffectSprite;
	public Color colourBlue;
	public Color colourRed;
	public Color colourPink;
	public int colour;
}
