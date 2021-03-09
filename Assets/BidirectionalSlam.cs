using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BidirectionalSlam : MonoBehaviour 
{
	[Header("Wave")]
	[SerializeField]
	WaveSystem wave;

	/*[Space]
	[Header("Splits")]
	[SerializeField]
	bool doSplit = false;
	[SerializeField]
	int SplitAmount = 16;
	[SerializeField]
	float SplitTime = 5f;

	[Space]
	[Header("Blankers")]
	[SerializeField]
	bool doBlankers = false;
	[SerializeField]
	float acceleration;
	[SerializeField]
	float terminalVelocity;
	[SerializeField]
	float deacceleration;
	[SerializeField]
	float spread;
	[SerializeField]
	float decayRate = 0.5f;
	[SerializeField]
	float intensity = 2f;
	[SerializeField]
	float startingTime = 0f;*/

	SlamWave[] slams;

	void Awake()
	{
		slams = GetComponentsInChildren<SlamWave>();
	}

	public void DoSlam()
	{
		foreach (var slam in slams)
		{
			wave.AddGenerator(slam);
		}
		/*if (doSplit)
		{
			wave.AddSplit(transform.position.x, SplitAmount, SplitTime);
		}
		if (doBlankers)
		{
			wave.AddBlanker(transform.position.x, acceleration, terminalVelocity, deacceleration, intensity, startingTime, spread, decayRate);
			wave.AddBlanker(transform.position.x, -acceleration, -terminalVelocity, -deacceleration, intensity, startingTime, spread, decayRate);
		}*/
	}


}
