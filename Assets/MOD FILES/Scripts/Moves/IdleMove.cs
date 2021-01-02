using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using WeaverCore.Interfaces;

public class IdleMove : CorruptedKinMove
{
	public bool NoWait = false;

	public override bool MoveEnabled
	{
		get
		{
			return true;
		}
	}

	public override bool ShowsUpInRandomizer
	{
		get
		{
			return false;
		}
	}

	public override bool CanDoAttack()
	{
		return true;
	}

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
		var walkSpeed = UnityEngine.Random.Range(Kin.idleMovementSpeedMin, Kin.idleMovementSpeedMax);

		//Flip at random
		walkSpeed = UnityEngine.Random.value >= 0.5f ? walkSpeed : -walkSpeed;

		//Rigidbody.velocity = new Vector2(walkSpeed, 0f);
		Rigidbody.velocity = new Vector2(walkSpeed, 0f);

		//yield return Kin.FacePlayerRoutine(true);
		yield return Kin.TurnTowardsPlayer();
		Animator.PlayAnimation("Walk");

		if (!NoWait)
		{
			long timesHitBefore = HealthManager.TimesHit;
			var waitTime = UnityEngine.Random.Range(Kin.idleTimeMin, Kin.idleTimeMax);
			for (float t = 0; t < waitTime; t += Time.deltaTime)
			{
				if (HealthManager.TimesHit > timesHitBefore)
				{
					break;
				}
				yield return null;
			}
		}
		else
		{
			NoWait = false;
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
		base.OnStun();
	}
}

