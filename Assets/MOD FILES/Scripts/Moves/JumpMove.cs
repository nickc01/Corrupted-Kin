using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using WeaverCore;

public class JumpMove : CorruptedKinMove
{
	//float jumpTime = 0.6f;
	//float jumpHeight = 8.8f;
	public bool IsFalling = false;


	public override void OnMoveAwake()
	{
		//Rigidbody.velocity = CalculateVelocity()
	}

	public override bool CanDoAttack()
	{
		return true;
	}

	public override bool MoveEnabled
	{
		get
		{
			return Kin.JumpEnabled;
		}
	}

	public override bool ShowsUpInRandomizer
	{
		get
		{
			return false;
		}
	}

	public IEnumerator Jump(float toX)
	{
		return Jump(toX, Kin.JumpHeight);
	}

	public IEnumerator Jump(float toX, float jumpHeight)
	{
		return Jump(transform.position.x, toX, jumpHeight);
	}

	public IEnumerator Jump(float fromX, float toX, float jumpHeight)
	{
		IsFalling = false;
		Rigidbody.velocity = default(Vector2);
		yield return Animator.PlayAnimationTillDone("Jump Antic");

		Audio.PlayAtPoint(Kin.JumpSound, transform.position);
		Animator.PlayAnimation("Jump");

		Rigidbody.velocity = CalculateVelocities(fromX, toX, jumpHeight);

		//Wait until the boss is starting to fall back down
		while (Rigidbody.velocity.y > 0f)
		{
			yield return null;
		}

		IsFalling = true;

		while (!Kin.IsGrounded)
		{
			yield return null;
		}

		IsFalling = false;

		Audio.PlayAtPoint(Kin.LandSound, transform.position);
		Rigidbody.velocity = default(Vector2);
		yield return Animator.PlayAnimationTillDone("Land");
	}

	public override IEnumerator DoMove()
	{
		return Jump(UnityEngine.Random.Range(Kin.leftX, Kin.rightX), Kin.JumpHeight);
	}


	public Vector2 CalculateVelocities(float fromX, float toX, float jumpHeight)
	{
		float acceleration = Rigidbody.gravityScale * Physics2D.gravity.y;
		float yVelocity = Mathf.Sqrt(-2 * acceleration * jumpHeight);

		float time = 2f * -yVelocity / acceleration;


		/*Debug.Log("TO X = " + toX);
		Debug.Log("Time = " + time);
		Debug.Log("Acceleration = " + acceleration);
		Debug.Log("Y Velocity = " + yVelocity);
		Debug.Log("Jump Height = " + jumpHeight);*/

		float xVelocity = (toX - fromX) / time;

		return new Vector2(xVelocity,yVelocity);
	}

	/*public override IEnumerator DoMove()
	{
		Rigidbody.velocity = default(Vector2);

		yield return Kin.FacePlayerRoutine(true);
		yield return Animator.PlayAnimationTillDone("Jump Antic");
		float jumpX = 0f;

		WeaverAudio.PlayAtPoint(JumpSound, transform.position);

		Animator.PlayAnimation("Jump");

		var jumpY = jumpHeight;

		Rigidbody.velocity = new Vector2(jumpX, jumpY);

		yield return null;

		bool falling = false;

		while (true)
		{
			yield return null;

			bool aboveDownstabHeight = false;
			bool aboveAirDashHeight = false;

			if (transform.position.y > MinDownstabHeight)
			{
				aboveDownstabHeight = true;
			}
			if (transform.position.y > AirDashHeight)
			{
				aboveAirDashHeight = true;
			}

			if (!falling && Rigidbody.velocity.y < 0f)
			{
				falling = true;
			}

			if (falling && IsGrounded)
			{
				//LAND logic
				WeaverAudio.PlayAtPoint(LandSound, transform.position);
				Rigidbody.velocity = default(Vector2);
				yield return Animator.PlayAnimationTillDone("Land");
				yield return ToNextAttack();
				yield break;
			}

			if (DownStabbing && InDownstabRange && aboveDownstabHeight)
			{
				WeaverAudio.PlayAtPoint(DownstabPrepareSound, transform.position);
				Rigidbody.velocity = default(Vector2);
				Rigidbody.gravityScale = 0f;
				yield return Animator.PlayAnimationTillDone("Downstab Antic Quick");
				WeaverAudio.PlayAtPoint(DownstabDashSound, transform.position);
				Animator.PlayAnimation("Downstab");

				Rigidbody.velocity = new Vector2(0f, -60f);
				Rigidbody.gravityScale = gravityScaleCache;

				DownstabBurst.SetActive(true);

				yield return WaitTillTouchingGround();

				WeaverAudio.PlayAtPoint(DownstabImpactSound, transform.position);
				Rigidbody.velocity = default(Vector2);
				DownstabSlam.SetActive(true);

				WeaverCam.Instance.Shaker.Shake(WeaverCore.Enums.ShakeType.EnemyKillShake);

				//TODO - SPAWN PROJECTILES

				KinProjectile.Spawn(transform.position + KinProjectileOffset, new Vector2(21, 0));
				KinProjectile.Spawn(transform.position + KinProjectileOffset, new Vector2(15, 0));
				KinProjectile.Spawn(transform.position + KinProjectileOffset, new Vector2(8, 0));
				KinProjectile.Spawn(transform.position + KinProjectileOffset, new Vector2(-8, 0));
				KinProjectile.Spawn(transform.position + KinProjectileOffset, new Vector2(-15, 0));
				KinProjectile.Spawn(transform.position + KinProjectileOffset, new Vector2(-21, 0));

				yield return Animator.PlayAnimationTillDone("Downstab Land");

				Animator.PlayAnimation("Idle");

				yield return new WaitForSeconds(0.35f);
				UpdateCounters();
				break;
			}
			if (aboveAirDashHeight && WillAirDash)
			{
				transform.SetYPosition(AirDashHeight);
				Rigidbody.gravityScale = 0f;

				FacePlayer(false);

				Rigidbody.velocity = default(Vector2);

				yield return Animator.PlayAnimationTillDone("Dash Antic 1");

				yield return DashPart2();
				break;
			}
		}
	}*/

	/*public IEnumerator JumpTo(float jumpHeight, float destX)
	{
		yield break;
	}

	public Vector2 CalculateVelocity(float jumpHeight, float fromX, float toX)
	{
		var distance = toX - fromX;

		var xVelocity = distance / jumpTime;

		return new Vector2(xVelocity,13.696f);
	}*/

	public override void OnStun()
	{
		base.OnStun();
	}

	/*public override IEnumerator DoMove()
	{
		throw new NotImplementedException();
	}*/
}

