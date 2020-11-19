using UnityEngine;
using System;
using System.Collections.Generic;

public class Breakable : MonoBehaviour
{
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

	[SerializeField]
	private Renderer wholeRenderer;
	[SerializeField]
	private GameObject[] wholeParts;
	[SerializeField]
	private GameObject[] remnantParts;
	[SerializeField]
	private List<GameObject> debrisParts;
	[SerializeField]
	private float angleOffset;
	[SerializeField]
	private float inertBackgroundThreshold;
	[SerializeField]
	private float inertForegroundThreshold;
	[SerializeField]
	private Vector3 effectOffset;
	[SerializeField]
	private AudioSource audioSourcePrefab;
	[SerializeField]
	private AudioEvent breakAudioEvent;
	[SerializeField]
	private RandomAudioClipTable breakAudioClipTable;
	[SerializeField]
	private Transform dustHitRegularPrefab;
	[SerializeField]
	private Transform dustHitDownPrefab;
	[SerializeField]
	private float flingSpeedMin;
	[SerializeField]
	private float flingSpeedMax;
	[SerializeField]
	private Transform strikeEffectPrefab;
	[SerializeField]
	private Transform nailHitEffectPrefab;
	[SerializeField]
	private Transform spellHitEffectPrefab;
	[SerializeField]
	private bool preventParticleRotation;
	[SerializeField]
	private GameObject hitEventReciever;
	[SerializeField]
	private bool forwardBreakEvent;
	public Probability.ProbabilityGameObject[] containingParticles;
	public FlingObject[] flingObjectRegister;
}
