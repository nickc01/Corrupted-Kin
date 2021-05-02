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
	[SerializeField]
	[Tooltip("Determines how extreme of a tilt will be applied, in degrees")]
	float tiltAmount = 15f;
	[SerializeField]
	[Tooltip("How fast the wave will tilt to the Tilt Amount")]
	float tiltTime = 1.5f;
	[SerializeField]
	[Tooltip("Determines how the wave will rotate towards the new tilt value")]
	AnimationCurve tiltCurve;

	ParticleSystem bloodParticles;

	Vector3 spawnPosition;

	WaveSystem _system;
	public WaveSystem System
	{
		get
		{
			if (_system == null)
			{
				_system = GetComponent<WaveSystem>();
			}
			return _system;
		}
	}

	void Awake()
	{
		bloodParticles = GetComponentInChildren<ParticleSystem>();
		//Debug.Log("Blod Particles = " + (bloodParticles != null));
		spawnPosition = transform.position;
		transform.position += startPosition;
		StartCoroutine(StartRoutine());
	}

	IEnumerator StartRoutine()
	{
		BeginWaveRumble();
		for (float i = 0; i < interpolationTime; i += Time.deltaTime)
		{
			transform.position = spawnPosition + Vector3.Lerp(startPosition,endPosition,startInterpolationCurve.Evaluate(i / interpolationTime));
			yield return null;
		}
		transform.position = spawnPosition + endPosition;
		EndWaveRumble();
	}

	public void BeginWaveRumble()
	{
		bloodParticles.Play();
	}

	public void EndWaveRumble()
	{
		bloodParticles.Stop();
	}

	public void TiltTowardsLeft()
	{
		TiltToAngle(tiltAmount);
	}

	public void TiltTowardsRight()
	{
		TiltToAngle(-tiltAmount);
	}

	public void ResetTilt()
	{
		TiltToAngle(0f);
	}

	Coroutine tiltRoutine;

	void TiltToAngle(float angle)
	{
		if (tiltRoutine != null)
		{
			StopCoroutine(tiltRoutine);
		}
		tiltRoutine = StartCoroutine(TiltRoutine(angle));
	}

	IEnumerator TiltRoutine(float toAngle)
	{
		BeginWaveRumble();
		Vector3 eulerAngles = transform.eulerAngles;
		float oldAngle = transform.eulerAngles.z;

		if (oldAngle > 180f)
		{
			oldAngle -= 360f;
		}

		for (float t = 0; t < tiltTime; t += Time.deltaTime)
		{
			transform.eulerAngles = new Vector3(eulerAngles.x,eulerAngles.y,Mathf.Lerp(oldAngle,toAngle,tiltCurve.Evaluate(t / tiltTime)));
			yield return null;
		}
		transform.eulerAngles = new Vector3(eulerAngles.x,eulerAngles.y,toAngle);
		tiltRoutine = null;
		EndWaveRumble();
	}

}
