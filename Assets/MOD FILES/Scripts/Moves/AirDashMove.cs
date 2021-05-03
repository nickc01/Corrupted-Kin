using System.Collections;
using UnityEngine;
using WeaverCore.Utilities;

public class AirDashMove : CorruptedKinMove
{
	[SerializeField] float AirDashHeight = 31.5f;

	DashSlashMove dashSlash;
	JumpMove jump;
	bool airDashing;

	void Awake()
	{
		dashSlash = GetComponent<DashSlashMove>();
		jump = GetComponent<JumpMove>();
	}


	public override IEnumerator DoMove()
	{
		var jumpRoutine = Kin.StartBoundRoutine(jump.Jump(UnityEngine.Random.Range(Kin.LeftX, Kin.RightX)));

		airDashing = false;

		while (Kin.IsRoutineRunning(jumpRoutine))
		{
			if (transform.position.y > AirDashHeight)
			{
				airDashing = true;
				Kin.StopBoundRoutine(jumpRoutine);
			}
			yield return null;
		}

		if (airDashing)
		{
			transform.SetYPosition(AirDashHeight);
			KinRigidbody.gravityScale = 0f;

			//Kin.FacePlayer(false);
			Kin.TurnTowardsPlayer();

			KinRigidbody.velocity = default(Vector2);

			yield return Animator.PlayAnimationTillDone("Dash Antic 1");

			bool doDash = false;

			if (Kin.BossStage <= 3)
			{
				doDash = UnityEngine.Random.value >= 0.5f;
			}
			else
			{
				doDash = true;
			}

			yield return dashSlash.DoDash(doDash,dashSlash.DefaultDashSpeed,0.25f);
			//yield return DashPart2();
			//break;
		}
	}

	public override void OnStun()
	{
		if (airDashing)
		{
			dashSlash.OnStun();
		}
		else
		{
			jump.OnStun();
		}
	}
}

