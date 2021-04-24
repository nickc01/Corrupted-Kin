﻿using System.Collections;
using UnityEngine;

public class BurrowWave : MonoBehaviour, IWaveGenerator, IWaveBlankerGenerator
{
	WaveSystem waveSystem;
	//const float E = (float)System.Math.E;

	[SerializeField]
	float dampingFactor = 2.2f;
	[SerializeField]
	float waveHeight = 0f;
	[SerializeField]
	[Range(0f,1f)]
	float visiblity = 0f;

	[SerializeField]
	float fadeInTime = 0.5f;
	[SerializeField]
	AnimationCurve fadeCurve;

	//[SerializeField]
	//float fadeFactor = 2.2f;

	[Space]
	[Header("Particle Systems")]
	[SerializeField]
	ParticleSystem BurrowParticles;
	[SerializeField]
	ParticleSystem BloodParticles;

	Coroutine fadeRoutine;

#if UNITY_EDITOR
	[SerializeField]
	bool debugWave = false;

	void Awake()
	{
		if (debugWave)
		{
			var system = GameObject.FindObjectOfType<WaveSystem>();
			if (system != null)
			{
				system.AddGenerator(this);
			}
		}
	}

#endif

	public int Priority
	{
		get
		{
			return 0;
		}
	}

	public float Calculate(float x, float previousValue)
	{
		return previousValue + (CalcDampedSine(x - transform.position.x) * visiblity);
	}

	float CalcDampedSine(float x)
	{
		var scale = transform.localScale;

		var value = GetDampFactor(Mathf.Abs(x) * scale.x);

		return ((Mathf.Cos(Mathf.Abs(x) * Mathf.PI / 3f) - waveHeight) * scale.y) * GetDampFactor(Mathf.Abs(x) * scale.x * dampingFactor);
		//return ((value - waveHeight) * scale.y) * GetDampFactor(Mathf.Abs(x) * scale.x * dampingFactor);
		//return ((scale.y * Mathf.Pow(E, -dampingFactor * Mathf.Abs(x)) * Mathf.Cos(2f * Mathf.PI * x * scale.x)) - waveHeight) * GetDampFactor(x * fadeFactor);//(1f / ((Mathf.Abs(x) * fadeFactor) + 1));
	}

	float GetDampFactor(float x)
	{
		x = Mathf.Abs(x);
		if (x >= 1f)
		{
			return 1f / (4 * (x - 0.5f));
		}
		else
		{
			return Mathf.Cos(x * Mathf.PI / 3f);
		}
	}

	public void OnWaveEnd(WaveSystem source)
	{
		source.RemoveBlankerGenerator(this);
	}

	public void OnWaveStart(WaveSystem source)
	{
		//Debug.Log("ADDING BURROW WAVE");
		source.AddBlankerGenerator(this);
		waveSystem = source;
	}

	public float GetBlankingColorAtPos(float x, float previousValue)
	{
		return Mathf.Max(previousValue,GetDampFactor((x - transform.position.x) * transform.localScale.x * dampingFactor) * visiblity);
	}


	public void FadeInWave()
	{
		FadeWave(visiblity, 1f);
	}

	public void FadeOutWave()
	{
		FadeWave(visiblity, 0f);
	}

	void FadeWave(float from, float to)
	{
		if (fadeRoutine != null)
		{
			StopCoroutine(fadeRoutine);
		}
		StartCoroutine(FadeRoutine(from, to));
	}

	IEnumerator FadeRoutine(float from, float to)
	{
		for (float t = 0; t < fadeInTime; t += Time.deltaTime)
		{
			visiblity = Mathf.Lerp(from,to,fadeCurve.Evaluate(t / fadeInTime));
			yield return null;
		}

		visiblity = to;

		fadeRoutine = null;
	}

	public void PlayParticles()
	{
		BloodParticles.Play();
		BurrowParticles.Play();
	}

	public void StopParticles()
	{
		BloodParticles.Stop();
		BurrowParticles.Stop();
	}

	public void DestroyWave()
	{
		BloodParticles.Stop();
		BurrowParticles.Stop();
		FadeOutWave();
		Destroy(gameObject, 5f);
	}

	void OnDestroy()
	{
		if (Application.isPlaying)
		{
			waveSystem.RemoveGenerator(this);
		}
	}
}
