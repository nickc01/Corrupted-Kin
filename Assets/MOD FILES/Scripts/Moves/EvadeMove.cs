using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using WeaverCore;
using WeaverCore.Utilities;

public class EvadeMove : CorruptedKinMove
{
	public override bool MoveEnabled
	{
		get
		{
			return Kin.EvadeEnabled;
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
		return false;
	}

	public override IEnumerator DoMove()
	{
		Rigidbody.velocity = default(Vector2);

		//yield return Kin.FacePlayerRoutine();
		yield return Kin.TurnTowardsPlayer();

		var xScale = transform.GetXLocalScale();

		var speed = Kin.evadeSpeed * xScale;

		if (Kin.IsFacingRight)
		{
			speed *= -1f;
		}

		yield return Animator.PlayAnimationTillDone("Evade Antic");

		Rigidbody.gravityScale = 0f;
		Rigidbody.velocity = new Vector2(speed, 0f);

		WeaverAudio.PlayAtPoint(Kin.JumpSound, transform.position);

		Animator.PlayAnimation("Evade");

		for (float timer = 0; timer < 0.19f; timer += Time.deltaTime)
		{
			if (Animator.PlayingClip != "Evade")
			{
				break;
			}
			yield return null;
		}

		Rigidbody.velocity = default(Vector2);
		Rigidbody.gravityScale = Kin.GravityScale;
		WeaverAudio.PlayAtPoint(Kin.LandSound, transform.position);

		yield return Animator.PlayAnimationTillDone("Evade Recover");
	}

	public override void OnStun()
	{
		base.OnStun();
	}
}
