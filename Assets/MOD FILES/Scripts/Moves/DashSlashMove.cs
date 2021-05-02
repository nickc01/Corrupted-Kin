using System.Collections;
using UnityEngine;
using WeaverCore;
using WeaverCore.Utilities;

public class DashSlashMove : CorruptedKinMove
{
	[SerializeField] float dashSpeed = 32f;
	[SerializeField] float reverseDashSpeed = 20f;
	[SerializeField] AudioClip DashSoundEffect;
	[SerializeField] GameObject DashBurst;
	[SerializeField] GameObject DashSlash;
	[SerializeField] GameObject DashSlashHit;

	public float DefaultDashSpeed { get { return dashSpeed; } }

	public IEnumerator DashToPosition(float x_position)
	{
		if (x_position >= Kin.RightX || x_position <= Kin.LeftX)
		{
			throw new System.Exception("The position to dash to is outside the arena");
		}
		WeaverAudio.PlayAtPoint(Kin.PrepareSound, transform.position);
		KinRigidbody.gravityScale = 0f;

		//yield return Kin.FacePlayerRoutine(false);
		//yield return Kin.TurnTowardsPlayer();
		if (x_position >= transform.position.x)
		{
			Renderer.flipX = false;
		}
		else
		{
			Renderer.flipX = true;
		}

		var scale = transform.GetXLocalScale();

		/*var reverseSpeed = reverseDashSpeed * scale;

		if (Kin.IsFacingRight)
		{
			reverseSpeed = -reverseSpeed;
		}

		KinRigidbody.velocity = new Vector2(reverseSpeed, 0f);*/

		yield return Animator.PlayAnimationTillDone("Dash Antic 1");

		var dashTime = Animator.AnimationData.GetClipDuration("Dash Attack 1");

		dashTime += Animator.AnimationData.GetClipDuration("Dash Attack 2");
		dashTime += Animator.AnimationData.GetClipDuration("Dash Attack 3");

		var dashVelocity = Mathf.Abs(x_position - transform.position.x) / dashTime;

		yield return DoDash(false,dashVelocity / transform.GetXLocalScale());
	}

	public override IEnumerator DoMove()
	{
		/*if (Kin.GetPercentageToBoss(Player.Player1.transform) > 0.4f && Kin.BossPositionPercentage > 0.4f && Kin.BossPositionPercentage < 0.6f)
		{
			var evadeMove = GetMove<EvadeMoveOLD>();
			yield return evadeMove.DoMove();
		}*/
		WeaverAudio.PlayAtPoint(Kin.PrepareSound, transform.position);
		KinRigidbody.gravityScale = 0f;

		//yield return Kin.FacePlayerRoutine(false);
		yield return Kin.TurnTowardsPlayer();

		var scale = transform.GetXLocalScale();

		var reverseSpeed = reverseDashSpeed * scale;

		if (Kin.IsFacingRight)
		{
			reverseSpeed = -reverseSpeed;
		}

		KinRigidbody.velocity = new Vector2(reverseSpeed, 0f);

		yield return Animator.PlayAnimationTillDone("Dash Antic 1");

		yield return DoDash(false,dashSpeed);
	}

	public IEnumerator DoDash(bool doDownSlash, float dashSpeed)
	{
		//var limiterRoutine = Kin.StartBoundRoutine(PositionLimiterRoutine());
		var scale = transform.GetXLocalScale();

		var speed = dashSpeed * scale;

		if (!Kin.IsFacingRight)
		{
			speed = -speed;
		}

		Animator.PlayAnimation("Dash Antic 2");

		KinRigidbody.velocity = default(Vector2);

		yield return new WaitForSeconds(0.4f);

		Animator.PlayAnimation("Dash Antic 3");

		WeaverAudio.PlayAtPoint(DashSoundEffect, transform.position);

		DashBurst.SetActive(true);

		KinRigidbody.velocity = new Vector2(speed, 0f);

		yield return Animator.PlayAnimationTillDone("Dash Attack 1");

		WeaverAudio.PlayAtPoint(DashSoundEffect, transform.position);

		DashSlash.SetActive(true);
		DashSlashHit.SetActive(true);

		yield return Animator.PlayAnimationTillDone("Dash Attack 2");

		DashSlashHit.SetActive(false);

		yield return Animator.PlayAnimationTillDone("Dash Attack 3");

		KinRigidbody.velocity = default(Vector2);

		//Kin.StopBoundRoutine(limiterRoutine);

		KinRigidbody.gravityScale = Kin.GravityScale;

		if (doDownSlash)
		{
			var downSlashMove = GetComponent<DownslashMove>();
			yield return downSlashMove.SlamDownwards(Kin.BossStage == 1 || Kin.BossStage == 2,Kin.BossStage >= 3);
			yield return downSlashMove.PlayDownslashLanding();
		}
		else
		{
			if (!Kin.IsGrounded)
			{
				Animator.PlayAnimation("Fall");
				yield return Kin.WaitTillTouchingGround();
			}
			else
			{
				yield return Animator.PlayAnimationTillDone("Dash Recover");
			}
		}
	}

	/*IEnumerator PositionLimiterRoutine()
	{
		while (true)
		{
			yield return null;
			if (transform.position.x > Kin.RightX)
			{
				transform.SetXPosition(Kin.RightX);
			}
			if (transform.position.x < Kin.LeftX)
			{
				transform.SetXPosition(Kin.LeftX);
			}
		}
	}*/

	public override void OnStun()
	{
		//WeaverLog.Log("STUN");
		DashSlashHit.SetActive(false);
		DashSlash.SetActive(false);
		DashBurst.SetActive(false);
		base.OnStun();
	}
}

