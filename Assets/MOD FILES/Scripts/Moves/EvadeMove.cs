using System.Collections;
using UnityEngine;
using WeaverCore;
using WeaverCore.Utilities;

public class EvadeMove : CorruptedKinMove
{
	[SerializeField] float evadeSpeed = 25f;

	public override IEnumerator DoMove()
	{
		Rigidbody.velocity = default(Vector2);

		//yield return Kin.FacePlayerRoutine();
		yield return Kin.TurnTowardsPlayer();

		var xScale = transform.GetXLocalScale();

		var speed = evadeSpeed * xScale;

		if (Kin.IsFacingRight)
		{
			speed *= -1f;
		}

		yield return Animator.PlayAnimationTillDone("Evade Antic");

		Rigidbody.gravityScale = 0f;
		Rigidbody.velocity = new Vector2(speed, 0f);

		Audio.PlayAtPoint(Kin.JumpSound, transform.position);

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
		Audio.PlayAtPoint(Kin.LandSound, transform.position);

		yield return Animator.PlayAnimationTillDone("Evade Recover");
	}
}
