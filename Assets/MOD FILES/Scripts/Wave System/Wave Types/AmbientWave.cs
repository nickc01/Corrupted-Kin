﻿using UnityEngine;

public class AmbientWave : MonoBehaviour, IWaveGenerator
{
	[SerializeField]
	[Tooltip("How large the ambient wave will be")]
	Vector2 scale = Vector2.one;
	[SerializeField]
	[Tooltip("How fast the ambient wave moves")]
	float speed = 5f;
	[SerializeField]
	[Tooltip("How fast the wave will oscillate")]
	float oscillationSpeed = 1f;

	float _timer = 0f;
	float _oscillatorTimer = 0f;

	float _oscillator = 1f;

	WaveSystem wave;

	/// <inheritdoc/>
	int IWaveGenerator.Priority
	{
		get
		{
			return int.MinValue;
		}
	}

	void Awake()
	{
		_oscillator = Mathf.Sin(_oscillatorTimer);
		//Automatically add the ambient wave to the wave system if possible
		wave = GetComponentInParent<WaveSystem>();
		if (wave != null)
		{
			wave.AddGenerator(this);
		}
	}

	void Update()
	{
		_timer += Time.deltaTime * speed;

		if (_timer >= 1f * scale.x)
		{
			_timer -= 1f * scale.x;
		}

		_oscillatorTimer += Time.deltaTime * oscillationSpeed;
		if (_oscillatorTimer >= 1f)
		{
			_oscillatorTimer -= 1f;
		}
		_oscillator = Mathf.Sin(_oscillatorTimer * Mathf.PI * 2f);
	}

	/// <inheritdoc/>
	void IWaveGenerator.OnWaveStart(WaveSystem source)
	{
		
	}

	/// <inheritdoc/>
	float IWaveGenerator.Calculate(float x, float previousValue)
	{
		return _oscillator * Mathf.Sin((x + _timer) * Mathf.PI * 2f / scale.x) * scale.y;
	}

	/// <inheritdoc/>
	void IWaveGenerator.OnWaveEnd(WaveSystem source)
	{

	}
}
