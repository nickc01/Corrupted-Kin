using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using WeaverCore;

public class DownslashMove : CorruptedKinMove
{
	public override bool MoveEnabled
	{
		get
		{
			return Kin.DownslashEnabled;
		}
	}

	public override bool ShowsUpInRandomizer
	{
		get
		{
			return true;
		}
	}

	JumpMove jumpMove;

	public override void OnMoveAwake()
	{
		jumpMove = GetMove<JumpMove>();
	}

	public override bool CanDoAttack()
	{
		return true;
	}

	public override IEnumerator DoMove()
	{
		var destX = Mathf.LerpUnclamped(transform.position.x, Player.Player1.transform.position.x, 2f);


		var jumpRoutine = Kin.StartBoundRoutine(jumpMove.Jump(destX));

		bool downstabbing = false;


		while (Kin.IsRoutineRunning(jumpRoutine))
		{
			var playerPos = Player.Player1.transform.position;

			if (transform.position.y >= Kin.MinDownstabHeight && Mathf.Abs(transform.position.x - playerPos.x) <= Kin.DownstabActivationRange)
			{
				downstabbing = true;
				Kin.StopBoundRoutine(jumpRoutine);
				break;
			}

			yield return null;
		}

		if (downstabbing)
		{
			WeaverAudio.PlayAtPoint(Kin.DownstabPrepareSound, transform.position);
			Rigidbody.velocity = default(Vector2);
			Rigidbody.gravityScale = 0f;
			yield return Animator.PlayAnimationTillDone("Downstab Antic Quick");
			WeaverAudio.PlayAtPoint(Kin.DownstabDashSound, transform.position);
			Animator.PlayAnimation("Downstab");

			Rigidbody.velocity = new Vector2(0f, Kin.DownstabVelocity);
			Rigidbody.gravityScale = Kin.GravityScale;

			Kin.DownstabBurst.SetActive(true);

			yield return Kin.WaitTillTouchingGround();

			WeaverAudio.PlayAtPoint(Kin.DownstabImpactSound, transform.position);
			Rigidbody.velocity = default(Vector2);
			Kin.DownstabSlam.SetActive(true);

			WeaverCam.Instance.Shaker.Shake(WeaverCore.Enums.ShakeType.EnemyKillShake);

			//TODO - SPAWN PROJECTILES

			KinProjectile.Spawn(transform.position + Kin.KinProjectileOffset, new Vector2(21, 0));
			KinProjectile.Spawn(transform.position + Kin.KinProjectileOffset, new Vector2(15, 0));
			KinProjectile.Spawn(transform.position + Kin.KinProjectileOffset, new Vector2(8, 0));
			KinProjectile.Spawn(transform.position + Kin.KinProjectileOffset, new Vector2(-8, 0));
			KinProjectile.Spawn(transform.position + Kin.KinProjectileOffset, new Vector2(-15, 0));
			KinProjectile.Spawn(transform.position + Kin.KinProjectileOffset, new Vector2(-21, 0));

			yield return Animator.PlayAnimationTillDone("Downstab Land");

			Animator.PlayAnimation("Idle");

			yield return new WaitForSeconds(0.35f);
		}
	}

	public override void OnStun()
	{
		Rigidbody.velocity = default(Vector2);
		base.OnStun();
	}
}
