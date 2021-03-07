using UnityEngine;

public class SlamWave : MonoBehaviour, IWaveGenerator
{
	[SerializeField]
	float acceleration = 10f;
	[SerializeField]
	float terminalVelocity = 10f;
	[SerializeField]
	[Tooltip("Once the wave reaches terminal velocity, this will determine how long it will stay at that speed before it deaccelerates")]
	float terminalSpeedTime = 0.5f;
	[SerializeField]
	float deAcceleration = 3f;
	[SerializeField]
	float sizeToSpeedRatio = 1f;

	WaveSystem wave;

	int IWaveGenerator.Priority
	{
		get
		{
			return 100;
		}
	}

	float IWaveGenerator.Calculate(float x, float previousValue)
	{
		return 0f;
	}

	void IWaveGenerator.OnWaveEnd(WaveSystem source)
	{
		
	}

	void IWaveGenerator.OnWaveStart(WaveSystem source)
	{
		wave = source;
	}
}
