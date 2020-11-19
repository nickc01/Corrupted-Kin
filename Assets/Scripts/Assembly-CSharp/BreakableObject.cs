using UnityEngine;
using System;

public class BreakableObject : MonoBehaviour
{
	[Serializable]
	public class Direction
	{
		public GameObject effectPrefab;
		public Vector3 scale;
		public Vector3 rotation;
		public float minFlingSpeed;
		public float maxFlingSpeed;
		public float minFlingAngle;
		public float maxFlingAngle;
	}

	[Serializable]
	public class FlingObject
	{
		public GameObject referenceObject;
		public int spawnMin;
		public int spawnMax;
		public float speedMin;
		public float speedMax;
		public float angleMin;
		public float angleMax;
		public Vector2 originVariation;
	}

	public GameObject[] flingDebris;
	public float attackMagnitude;
	public Direction right;
	public Direction left;
	public Direction up;
	public Direction down;
	public Probability.ProbabilityGameObject[] containingParticles;
	public FlingObject[] flingObjectRegister;
	public GameObject objectNailEffectPrefab;
	public GameObject midpointNailEffectPrefab;
	public GameObject spellHitEffectPrefab;
	public AudioClip[] cutSound;
	public float pitchMin;
	public float pitchMax;
}
