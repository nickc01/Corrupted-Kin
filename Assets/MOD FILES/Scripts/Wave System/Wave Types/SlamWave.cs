using UnityEngine;
using WeaverCore.Enums;
using WeaverCore.Utilities;

public class SlamWave : MonoBehaviour, IWaveGenerator
{
	//const float E = (float)System.Math.E;

	[Header("Main Wave")]
	[SerializeField]
[Tooltip(
@"The curve that will determine the wave's velocity at any given point in time.
The wave starts at whatever velocity is at the left end of the curve.
")]
	AnimationCurve velocityCurve;
	[SerializeField]
	[Tooltip("This is multiplied with the value of the Velocity Curve to give the true velocity of the wave")]
	float velocityMultiplier;
	[SerializeField]
	[Tooltip("How long it will take to scroll from left to right in the Velocity Curve")]
	float velocityTime = 3f;
	[SerializeField]
	[Tooltip("This determines the vertical height of the wave based on how fast it's going")]
	float sizeToSpeedRatio = 1f;
	[SerializeField]
	float frontTamperLength = 1f;
	[SerializeField]
	float frontTamperOffset = 0f;
	[SerializeField]
	float backTamperLength = 1f;
	[SerializeField]
	float backTamperOffset = 0f;
	[SerializeField]
	float decayRate = 0.4f;
	[SerializeField]
	[Tooltip("How long the wave will last")]
	float lifeTime = 5f;
	[SerializeField]
	[Tooltip("How long it takes for the wave to fade out")]
	float fadeOutTime = 2f;
	[SerializeField]
	[Tooltip("What the wave will do when it's done")]
	OnDoneBehaviour doneBehaviour;

	[Space]
	[Header("Split")]
	[SerializeField]
	bool doSplit = false;
	[SerializeField]
	int SplitAmount = 4;
	[SerializeField]
	float SplitTime = 3.3f;

	[Space]
	[Header("Blanker")]
	[SerializeField]
	bool doBlanker = false;
	[SerializeField]
	float blankerAcceleration = 8f;
	[SerializeField]
	float blankerTerminalVelocity = 8f;
	[SerializeField]
	float blankerDeacceleration = 8f;
	[SerializeField]
	float blankerSpread = 4f;
	[SerializeField]
	float blankerDecayRate = 1.4f;
	[SerializeField]
	float blankerIntensity = 3f;
	[SerializeField]
	float blankerStartingTime = 0.3f;


	WaveSystem wave;

	float velocityTimer = 0f;
	//float fadeTime = 0f;
	float velocity = 0f;
	float time = 0f;
	float originalPosition = 0f;

	public float SizeToSpeedRatio
	{
		get
		{
			return sizeToSpeedRatio;
		}
		set
		{
			sizeToSpeedRatio = value;
		}
	}

	void Update()
	{
		if (wave != null)
		{
			velocityTimer += Time.deltaTime;
			velocity = velocityCurve.Evaluate(velocityTimer / velocityTime) * velocityMultiplier;
			/*velocity += acceleration * Time.deltaTime;
			if (velocity > terminalVelocity)
			{
				velocity = terminalVelocity;
			}*/
			transform.position = transform.position.With(transform.position.x + (velocity * Time.deltaTime));

			transform.localScale = transform.localScale.With(y: Mathf.Abs(velocity) * sizeToSpeedRatio);

			time += Time.deltaTime;
			//fadeTime += Time.deltaTime / fadeInTime;

			if (time >= lifeTime)
			{
				wave.RemoveGenerator(this);
				doneBehaviour.DoneWithObject(this);
			}
		}
	}

	int IWaveGenerator.Priority
	{
		get
		{
			return 100;
		}
	}

	float IWaveGenerator.Calculate(float x, float previousValue)
	{
		var backTamper = 0f;
		/*if (velocityMultiplier >= 0f)
		{
			backTamper = (x - originalPosition + backTamperOffset) / backTamperLength;
		}
		else
		{
			backTamper = -(x - originalPosition + backTamperOffset) / backTamperLength;
			//Debug.DrawLine(new Vector3(x - originalPosition + backTamperOffset, 0f, 0f), new Vector3(x - originalPosition + backTamperOffset, 100f, 0f), Color.red);
		}*/

		backTamper = (x - originalPosition + backTamperOffset) / backTamperLength;

		//var rawValue = 1f - ((GetDecayedSine(x - transform.position.x) + 1f) / 2f);
		var value = transform.localScale.y * GetDecayedSine((x - transform.position.x) / transform.localScale.x,decayRate) + previousValue;

		return Mathf.Lerp(Mathf.Lerp(Mathf.Lerp(value,previousValue, (x - transform.position.x + frontTamperOffset) / frontTamperLength),previousValue, backTamper),previousValue,Mathf.InverseLerp(lifeTime - fadeOutTime, lifeTime,time));
		//return value;
		/*var mainWave = GenerateMainWave((x - transform.position.x) / transform.localScale.x);

		Debug.Log("Main Wave at = " + ((x - transform.position.x) / transform.localScale.x) + " = " + mainWave);

		return Mathf.Lerp(value,mainWave * transform.localScale.y,mainWave);*/

		//return Mathf.Lerp(Mathf.Lerp(Mathf.Lerp(transform.localScale.y * GetDecayedSine((x - transform.position.x) / transform.localScale.x), previousValue, (x - transform.position.x + frontTamperOffset) / frontTamperLength), previousValue, (x - transform.position.x + backTamperOffset) / backTamperLength), previousValue, 1f - fadeTime) - (wave.transform.position.y - transform.position.y);
	}

	void IWaveGenerator.OnWaveEnd(WaveSystem source)
	{
		wave = null;
	}

	void IWaveGenerator.OnWaveStart(WaveSystem source)
	{
		wave = source;
		originalPosition = transform.position.x;
		transform.localScale = transform.localScale.With(y: 0f);
		if (doSplit)
		{
			wave.AddSplit(originalPosition, SplitAmount, SplitTime);
		}
		if (doBlanker)
		{
			SpawnBlanker(originalPosition);
		}
	}

	public void SpawnBlanker(float x_position)
	{
		wave.AddBlanker(x_position, blankerAcceleration, blankerTerminalVelocity, blankerDeacceleration, blankerIntensity, blankerStartingTime, blankerSpread, blankerDecayRate);
	}

	static float GetDecayedSine(float x, float decayRate = 0.4f)
	{
		if (x == 0)
		{
			return 1f;
		}
		else
		{
			return Mathf.Sin(x * Mathf.PI * 2f) / (x * decayRate);
		}

		//return Mathf.Pow(E, -decayRate * Mathf.Abs(x)) * Mathf.Cos(1.5f * Mathf.PI * x);
	}

	/*static float GenerateMainWave(float x)
	{
		return -Mathf.Pow(2f * x, 2f) + 1f;
	}*/

	/*float Limit(float number, float limit)
	{
		if (number < 0f)
		{
			return number;
		}
		else
		{
			return 10f * (Mathf.Log10(number + 1) / 2.2f);
		}
	}*/
}
