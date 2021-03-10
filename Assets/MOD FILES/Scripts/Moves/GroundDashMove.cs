using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using WeaverCore;
using WeaverCore.Utilities;

public class GroundDashMove : CorruptedKinMove
{
	public override bool MoveEnabled
	{
		get
		{
			return Kin.DashEnabled;
		}
	}

	public override bool ShowsUpInRandomizer
	{
		get
		{
			return true;
		}
	}

	public override bool CanDoAttack()
	{
		var distance = Kin.GetPercentageToBoss(Player.Player1.transform);
		Kin.DrawPercentageLine(0.4f, Player.Player1.transform);
		if (distance > 0.4f)
		{
			return Player.Player1.transform.position.y <= (Kin.floorY + 3f);
		}
		else
		{
			return Kin.BossPositionPercentage > 0.4f && Kin.BossPositionPercentage < 0.6f;
		}
		//return true;
		//return Kin.PlayerZone == CorruptedKin.DistanceZone.CenterZone;
		//return true;
		//Debug.Log("In Adjacent Zone = " + Kin.InAdjacentZone(Kin.CurrentZone, Kin.PlayerZone));
		//Debug.Log("In Low Zone = " + (Player.Player1.transform.position.y <= (Kin.floorY + 3f)));
		//return Kin.InAdjacentZone(Kin.CurrentZone, Kin.PlayerZone) && Player.Player1.transform.position.y <= (Kin.floorY + 3f);
		//return Kin.GetPercentageToBoss(Player.Player1.transform) > 0.4f && Player.Player1.transform.position.y <= (Kin.floorY + 3f);
	}

	public override IEnumerator DoMove()
	{
		if (Kin.GetPercentageToBoss(Player.Player1.transform) > 0.4f && Kin.BossPositionPercentage > 0.4f && Kin.BossPositionPercentage < 0.6f)
		{
			var evadeMove = GetMove<EvadeMove>();
			yield return evadeMove.DoMove();
		}
		Audio.PlayAtPoint(Kin.PrepareSound, transform.position);
		Rigidbody.gravityScale = 0f;

		//yield return Kin.FacePlayerRoutine(false);
		yield return Kin.TurnTowardsPlayer();

		var scale = transform.GetXLocalScale();

		var reverseSpeed = Kin.reverseDashSpeed * scale;

		if (Kin.IsFacingRight)
		{
			reverseSpeed = -reverseSpeed;
		}

		Rigidbody.velocity = new Vector2(reverseSpeed, 0f);

		yield return Animator.PlayAnimationTillDone("Dash Antic 1");

		yield return DoDash();
	}

	public IEnumerator DoDash()
	{
		var scale = transform.GetXLocalScale();

		var speed = Kin.dashSpeed * scale;

		if (!Kin.IsFacingRight)
		{
			speed = -speed;
		}

		Animator.PlayAnimation("Dash Antic 2");

		Rigidbody.velocity = default(Vector2);

		yield return new WaitForSeconds(0.4f);

		Animator.PlayAnimation("Dash Antic 3");

		Audio.PlayAtPoint(Kin.DashSoundEffect, transform.position);

		Kin.DashBurst.SetActive(true);

		Rigidbody.velocity = new Vector2(speed, 0f);

		yield return Animator.PlayAnimationTillDone("Dash Attack 1");

		Audio.PlayAtPoint(Kin.DashSoundEffect, transform.position);

		Kin.DashSlash.SetActive(true);
		Kin.DashSlashHit.SetActive(true);

		yield return Animator.PlayAnimationTillDone("Dash Attack 2");

		Kin.DashSlashHit.SetActive(false);

		yield return Animator.PlayAnimationTillDone("Dash Attack 3");

		Rigidbody.velocity = default(Vector2);

		Rigidbody.gravityScale = Kin.GravityScale;

		if (!Kin.IsGrounded)
		{
			Animator.PlayAnimation("Fall");
			yield return Kin.WaitTillTouchingGround();
		}
		else
		{
			yield return Animator.PlayAnimationTillDone("Dash Recover");
		}

		/*if (WillAirDash)
		{
			//FALL LOGIC
			Animator.PlayAnimation("Fall");
			WillAirDash = false;
			DidAirDash = true;

			yield return WaitTillTouchingGround();

			yield return ToNextAttack();
		}
		else
		{
			yield return Animator.PlayAnimationTillDone("Dash Recover");
			UpdateCounters();
		}*/
	}
}

