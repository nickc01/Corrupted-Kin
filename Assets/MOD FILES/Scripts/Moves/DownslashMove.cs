using System.Collections;
using UnityEngine;
using WeaverCore;

public class DownslashMove : CorruptedKinMove
{
	[SerializeField] float MinDownstabHeight = 33.31f;
	[SerializeField] float DownstabActivationRange = 1.5f;
	[SerializeField] float DownstabVelocity = -60f;
	[SerializeField] AudioClip DownstabPrepareSound;
	[SerializeField] AudioClip DownstabDashSound;
	[SerializeField] AudioClip DownstabImpactSound;
	[SerializeField] GameObject DownstabBurst;
	[SerializeField] GameObject DownstabSlam;
	[SerializeField] Vector3 KinProjectileOffset = new Vector3(0f, -0.5f, 0f);


	JumpMove jump;
	bool downstabbing;

	void Awake()
	{
		jump = GetComponent<JumpMove>();
	}

	public override IEnumerator DoMove()
	{
		var destX = Mathf.LerpUnclamped(transform.position.x, Player.Player1.transform.position.x, 2f);

		downstabbing = false;
		var jumpRoutine = Kin.StartBoundRoutine(jump.Jump(destX));


		while (Kin.IsRoutineRunning(jumpRoutine))
		{
			var playerPos = Player.Player1.transform.position;

			if (transform.position.y >= MinDownstabHeight && Mathf.Abs(transform.position.x - playerPos.x) <= DownstabActivationRange)
			{
				downstabbing = true;
				Kin.StopBoundRoutine(jumpRoutine);
				break;
			}

			yield return null;
		}

		if (downstabbing)
		{
			Audio.PlayAtPoint(DownstabPrepareSound, transform.position);
			Rigidbody.velocity = default(Vector2);
			Rigidbody.gravityScale = 0f;
			yield return Animator.PlayAnimationTillDone("Downstab Antic Quick");
			Audio.PlayAtPoint(DownstabDashSound, transform.position);
			Animator.PlayAnimation("Downstab");

			Rigidbody.velocity = new Vector2(0f, DownstabVelocity);
			Rigidbody.gravityScale = Kin.GravityScale;

			DownstabBurst.SetActive(true);

			yield return Kin.WaitTillTouchingGround();

			Audio.PlayAtPoint(DownstabImpactSound, transform.position);
			Rigidbody.velocity = default(Vector2);
			DownstabSlam.SetActive(true);

			CameraShaker.Instance.Shake(WeaverCore.Enums.ShakeType.EnemyKillShake);

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
		}
	}

	public override void OnStun()
	{
		if (!downstabbing)
		{
			jump.OnStun();
		}
		Rigidbody.velocity = default(Vector2);
		base.OnStun();
	}
}
