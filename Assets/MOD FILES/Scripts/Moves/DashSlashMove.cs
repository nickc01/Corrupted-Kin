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

	public override IEnumerator DoMove()
	{
		/*if (Kin.GetPercentageToBoss(Player.Player1.transform) > 0.4f && Kin.BossPositionPercentage > 0.4f && Kin.BossPositionPercentage < 0.6f)
		{
			var evadeMove = GetMove<EvadeMoveOLD>();
			yield return evadeMove.DoMove();
		}*/
		Audio.PlayAtPoint(Kin.PrepareSound, transform.position);
		Rigidbody.gravityScale = 0f;

		//yield return Kin.FacePlayerRoutine(false);
		yield return Kin.TurnTowardsPlayer();

		var scale = transform.GetXLocalScale();

		var reverseSpeed = reverseDashSpeed * scale;

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

		var speed = dashSpeed * scale;

		if (!Kin.IsFacingRight)
		{
			speed = -speed;
		}

		Animator.PlayAnimation("Dash Antic 2");

		Rigidbody.velocity = default(Vector2);

		yield return new WaitForSeconds(0.4f);

		Animator.PlayAnimation("Dash Antic 3");

		Audio.PlayAtPoint(DashSoundEffect, transform.position);

		DashBurst.SetActive(true);

		Rigidbody.velocity = new Vector2(speed, 0f);

		yield return Animator.PlayAnimationTillDone("Dash Attack 1");

		Audio.PlayAtPoint(DashSoundEffect, transform.position);

		DashSlash.SetActive(true);
		DashSlashHit.SetActive(true);

		yield return Animator.PlayAnimationTillDone("Dash Attack 2");

		DashSlashHit.SetActive(false);

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
	}

	public override void OnStun()
	{
		WeaverLog.Log("STUN");
		DashSlashHit.SetActive(false);
		DashSlash.SetActive(false);
		DashBurst.SetActive(false);
		base.OnStun();
	}
}

