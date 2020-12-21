using UnityEngine;

public class Grass : MonoBehaviour
{
	[SerializeField]
	private bool isInfectable;
	[SerializeField]
	private float inertBackgroundThreshold;
	[SerializeField]
	private float inertForegroundThreshold;
	[SerializeField]
	private Color infectedColor;
	[SerializeField]
	private bool preventPushAnimation;
	[SerializeField]
	private GameObject slashImpactPrefab;
	[SerializeField]
	private float slashImpactRotationMin;
	[SerializeField]
	private float slashImpactRotationMax;
	[SerializeField]
	private float slashImpactScale;
	[SerializeField]
	private GameObject infectedCutPrefab0;
	[SerializeField]
	private GameObject infectedCutPrefab1;
	[SerializeField]
	private GameObject cutPrefab0;
	[SerializeField]
	private GameObject cutPrefab1;
	[SerializeField]
	private ParticleSystem childParticleSystem;
	[SerializeField]
	private float childParticleSystemDuration;
	[SerializeField]
	private RandomAudioClipTable pushAudioClipTable;
	[SerializeField]
	private RandomAudioClipTable cutAudioClipTable;
}
