using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectionWave : MonoBehaviour 
{
	[Header("Start Parameters")]
	[SerializeField]
	[Tooltip("The starting position of the wave relative to where it spawned")]
	Vector3 startPosition;
	[SerializeField]
	[Tooltip("The end position of the wave relative to where it spawned. When the wave spawns, it will interpolate from the start position to the end position")]
	Vector3 endPosition;
	[SerializeField]
	[Tooltip("How long the starting interpolate will last")]
	float interpolationTime = 4f;
	[SerializeField]
	[Tooltip("Used to control how smooth the interpolation is")]
	AnimationCurve startInterpolationCurve;

	Vector3 spawnPosition;

	void Awake()
	{
		spawnPosition = transform.position;
		transform.position += startPosition;
		StartCoroutine(StartRoutine());
	}

	IEnumerator StartRoutine()
	{
		for (float i = 0; i < interpolationTime; i += Time.deltaTime)
		{
			transform.position = spawnPosition + Vector3.Lerp(startPosition,endPosition,startInterpolationCurve.Evaluate(i / interpolationTime));
			yield return null;
		}
		transform.position = spawnPosition + endPosition;
	}

}
