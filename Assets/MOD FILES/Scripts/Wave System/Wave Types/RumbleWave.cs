using UnityEngine;

public class RumbleWave : MonoBehaviour, IWaveGenerator
{
	[SerializeField]
	[Tooltip("How large the rumble wave will be")]
	Vector2 scale = Vector2.one;
	[SerializeField]
	[Tooltip("How fast the wave will oscillate")]
	float oscillationSpeed = 1f;

	int IWaveGenerator.Priority
	{
		get
		{
			return -100;
		}
	}

	WaveSystem wave;

	void Awake()
	{
		//_oscillator = Mathf.Sin(_oscillatorTimer);
		wave = GetComponentInParent<WaveSystem>();
		if (wave != null)
		{
			wave.AddGenerator(this);
		}
	}

	float IWaveGenerator.Calculate(float x, float previousValue)
	{
		return previousValue;
	}

	void IWaveGenerator.OnWaveEnd(WaveSystem source)
	{
		
	}

	void IWaveGenerator.OnWaveStart(WaveSystem source)
	{
		
	}
}
