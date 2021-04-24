using System.Collections;
using UnityEngine;
using WeaverCore;
using WeaverCore.Utilities;

public class JumpMove : CorruptedKinMove
{
	public float JumpHeight = 9.2f;

	public bool IsFalling { get; private set; }

	public float JumpAnticSpeed { get; set; }

	public bool Jumping { get; private set; }

	void Awake()
	{
		JumpAnticSpeed = 1f;
	}

	public IEnumerator Jump(float toX)
	{
		return Jump(toX, JumpHeight);
	}

	public IEnumerator Jump(float toX, float jumpHeight)
	{
		return Jump(transform.position.x, toX, jumpHeight);
	}

	public IEnumerator Jump(float fromX, float toX, float jumpHeight)
	{
		//var limiterRoutine = Kin.StartBoundRoutine(HorizontalLimiter());
		Jumping = true;
		//Debug.Log("JUMPING!");
		IsFalling = false;
		KinRigidbody.velocity = default(Vector2);
		yield return Animator.PlayAnimationTillDone("Jump Antic");

		Audio.PlayAtPoint(Kin.JumpSound, transform.position);
		Animator.PlayAnimation("Jump");

		KinRigidbody.velocity = CalculateVelocities(fromX, toX, jumpHeight);

		//Debug.Log("Jumping With Velocity = " + KinRigidbody.velocity);
		//Wait until the boss is starting to fall back down
		while (KinRigidbody.velocity.y > 0f)
		{
			if (transform.position.x > Kin.RightX)
			{
				transform.SetXPosition(Kin.RightX);
			}
			else if (transform.position.x < Kin.LeftX)
			{
				transform.SetXPosition(Kin.LeftX);
			}
			yield return null;
		}

		IsFalling = true;

		while (!Kin.IsGrounded)
		{
			if (transform.position.x > Kin.RightX)
			{
				transform.SetXPosition(Kin.RightX);
			}
			else if (transform.position.x < Kin.LeftX)
			{
				transform.SetXPosition(Kin.LeftX);
			}
			yield return null;
		}

		IsFalling = false;

		Audio.PlayAtPoint(Kin.LandSound, transform.position);
		KinRigidbody.velocity = default(Vector2);
		yield return Animator.PlayAnimationTillDone("Land");
		//Kin.StopBoundRoutine(limiterRoutine);
		Jumping = false;
	}

	/*IEnumerator HorizontalLimiter()
	{
		while (true)
		{
			if (transform.position.x > Kin.RightX)
			{
				transform.SetXPosition(Kin.RightX);
			}
			else if (transform.position.x < Kin.LeftX)
			{
				transform.SetXPosition(Kin.LeftX);
			}
			yield return null;
		}
	}*/

	public override IEnumerator DoMove()
	{
		JumpAnticSpeed = 1f;
		return Jump(UnityEngine.Random.Range(Kin.LeftX, Kin.RightX), JumpHeight);
	}

	public Vector2 CalculateVelocities(float fromX, float toX, float jumpHeight)
	{
		float acceleration = KinRigidbody.gravityScale * Physics2D.gravity.y;
		float yVelocity = Mathf.Sqrt(-2 * acceleration * jumpHeight);

		float time = 2f * -yVelocity / acceleration;

		float xVelocity = (toX - fromX) / time;

		return new Vector2(xVelocity, yVelocity);
	}

	public float GetTimeToDestination(float fromX, float toX, float jumpHeight)
	{
		float acceleration = KinRigidbody.gravityScale * Physics2D.gravity.y;
		float yVelocity = Mathf.Sqrt(-2 * acceleration * jumpHeight);

		return 2f * -yVelocity / acceleration;
	}

	public override void OnStun()
	{
		JumpAnticSpeed = 1f;
		Jumping = false;
		IsFalling = false;
		base.OnStun();
	}
}

