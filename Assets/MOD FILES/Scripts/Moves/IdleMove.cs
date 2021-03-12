using System.Collections;
using UnityEngine;

public class IdleMove : CorruptedKinMove
{
	[SerializeField]
	float idleMovementSpeedMin = 0.5f;
	[SerializeField]
	float idleMovementSpeedMax = 1.25f;
	[SerializeField]
	float idleTimeMin = 1f;
	[SerializeField]
	float idleTimeMax = 1.5f;

	public override IEnumerator DoMove()
	{
		Animator.PlayAnimation("Walk");

		/*Kin.FacePlayer();

		if (WillEvade && InEvadeRange)
		{
			yield return Evade();
			continue;
		}

		if (WillOverhead & InOverHeadRange)
		{
			yield return Overhead();
			continue;
		}*/

		//Get random walkspeed
		var walkSpeed = UnityEngine.Random.Range(idleMovementSpeedMin, idleMovementSpeedMax);

		//Flip at random
		walkSpeed = UnityEngine.Random.value >= 0.5f ? walkSpeed : -walkSpeed;

		//Rigidbody.velocity = new Vector2(walkSpeed, 0f);
		Rigidbody.velocity = new Vector2(walkSpeed, 0f);

		//yield return Kin.FacePlayerRoutine(true);
		yield return Kin.TurnTowardsPlayer();
		Animator.PlayAnimation("Walk");


		long timesHitBefore = HealthManager.TimesHit;
		var waitTime = UnityEngine.Random.Range(idleTimeMin, idleTimeMax);
		for (float t = 0; t < waitTime; t += Time.deltaTime)
		{
			if (HealthManager.TimesHit > timesHitBefore)
			{
				break;
			}
			yield return null;
		}

		Rigidbody.velocity = new Vector2(0f, 0f);

		/*if (IdleCounter < waitTime)
		{
			waitTime = IdleCounter;
		}
		yield return new WaitForSeconds(waitTime);
		IdleCounter -= waitTime;

		Rigidbody.velocity = new Vector2(0f, 0f);

		yield return DoAttack();*/
	}

	public override void OnStun()
	{
		Rigidbody.velocity = new Vector2(0f, 0f);
	}
}

