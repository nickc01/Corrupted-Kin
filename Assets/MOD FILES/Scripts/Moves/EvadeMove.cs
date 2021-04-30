using System.Collections;
using UnityEngine;
using WeaverCore;
using WeaverCore.Enums;
using WeaverCore.Utilities;

public class EvadeMove : CorruptedKinMove
{
	[SerializeField] float evadeSpeed = 25f;
	[SerializeField] float evadeTime = 0.19f;

	[SerializeField] float evadeRange = 1.5f;

	public bool HasRoomToEvade(CardinalDirection evadeDirection)
	{
		switch (evadeDirection)
		{
			case CardinalDirection.Left:
				return transform.position.x - (evadeSpeed * evadeTime) >= Kin.LeftX;
			case CardinalDirection.Right:
				return transform.position.x + (evadeSpeed * evadeTime) <= Kin.RightX;
			default:
				return false;
		}
	}

	public bool IsWithinEvadeRange(Vector3 position)
	{
		Debug.DrawLine(transform.position, transform.position + new Vector3(evadeRange, 0f, 0f), Color.blue, 1f);
		Debug.DrawLine(transform.position, transform.position - new Vector3(evadeRange, 0f, 0f), Color.blue, 1f);

		return position.x >= transform.position.x - evadeRange && position.x <= transform.position.x + evadeRange;
	}

	public override IEnumerator DoMove()
	{
		KinRigidbody.velocity = default(Vector2);

		//yield return Kin.FacePlayerRoutine();
		yield return Kin.TurnTowardsPlayer();

		var xScale = transform.GetXLocalScale();

		var speed = evadeSpeed * xScale;

		if (Kin.IsFacingRight)
		{
			speed *= -1f;
		}

		yield return Animator.PlayAnimationTillDone("Evade Antic");

		KinRigidbody.gravityScale = 0f;
		KinRigidbody.velocity = new Vector2(speed, 0f);

		WeaverAudio.PlayAtPoint(Kin.JumpSound, transform.position);

		Animator.PlayAnimation("Evade");

		for (float timer = 0; timer < evadeTime; timer += Time.deltaTime)
		{
			if (Animator.PlayingClip != "Evade")
			{
				break;
			}
			yield return null;
		}

		KinRigidbody.velocity = default(Vector2);
		KinRigidbody.gravityScale = Kin.GravityScale;
		WeaverAudio.PlayAtPoint(Kin.LandSound, transform.position);

		yield return Animator.PlayAnimationTillDone("Evade Recover");
	}
}
