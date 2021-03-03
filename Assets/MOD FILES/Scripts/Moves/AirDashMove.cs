using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using WeaverCore;
using WeaverCore.Utilities;

public class AirDashMove : CorruptedKinMove
{
	public override bool MoveEnabled
	{
		get
		{
			return Kin.AirDashEnabled;
		}
	}

	public override bool ShowsUpInRandomizer
	{
		get
		{
			return true;
		}
	}

	GroundDashMove dashMove;
	JumpMove jumpMove;

	public override void OnMoveAwake()
	{
		dashMove = GetMove<GroundDashMove>();
		jumpMove = GetMove<JumpMove>();
		base.OnMoveAwake();
	}

	public override IEnumerator DoMove()
	{
		var jumpRoutine = Kin.StartBoundRoutine(jumpMove.Jump(UnityEngine.Random.Range(Kin.leftX, Kin.rightX)));

		bool airDashing = false;

		while (Kin.IsRoutineRunning(jumpRoutine))
		{
			if (transform.position.y > Kin.AirDashHeight)
			{
				airDashing = true;
				Kin.StopBoundRoutine(jumpRoutine);
			}
			yield return null;
		}

		if (airDashing)
		{
			transform.SetYPosition(Kin.AirDashHeight);
			Rigidbody.gravityScale = 0f;

			//Kin.FacePlayer(false);
			Kin.TurnTowardsPlayer();

			Rigidbody.velocity = default(Vector2);

			yield return Animator.PlayAnimationTillDone("Dash Antic 1");

			yield return dashMove.DoDash();
			//yield return DashPart2();
			//break;
		}
	}

	public override bool CanDoAttack()
	{
		var percentage = Kin.GetPercentageToBoss(Player.Player1.transform);

		Kin.DrawPercentageLine(0.5f, Player.Player1.transform);

		return percentage >= 0.5f;

		//var playerZone = Kin.PlayerZone;
		//return (Kin.InAdjacentZone(Kin.CurrentZone, Kin.PlayerZone) || Kin.InFarCorners(Kin.CurrentZone, Kin.PlayerZone));
		//return playerZone == CorruptedKin.DistanceZone.LeftZone && playerZone == CorruptedKin.DistanceZone.RightZone;
	}
}

