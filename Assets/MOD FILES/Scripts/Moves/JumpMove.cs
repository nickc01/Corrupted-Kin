using System.Collections;
using UnityEngine;
using WeaverCore;

public class JumpMove : CorruptedKinMove
{
	[SerializeField]
	float JumpHeight = 9.2f;

	public bool IsFalling { get; private set; }

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
		return Jump(UnityEngine.Random.Range(Kin.LeftX, Kin.RightX), JumpHeight);
	}

	public Vector2 CalculateVelocities(float fromX, float toX, float jumpHeight)
	{
		float acceleration = Rigidbody.gravityScale * Physics2D.gravity.y;
		float yVelocity = Mathf.Sqrt(-2 * acceleration * jumpHeight);

		float time = 2f * -yVelocity / acceleration;

		float xVelocity = (toX - fromX) / time;

		return new Vector2(xVelocity, yVelocity);
	}
}

