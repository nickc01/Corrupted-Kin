using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using WeaverCore;

public class OverheadSlashMove : CorruptedKinMove
{
	public override bool MoveEnabled
	{
		get
		{
			return false;
		}
	}

	public override bool ShowsUpInRandomizer
	{
		get
		{
			return false;
		}
	}


	public override bool CanDoAttack()
	{
		if (Kin.OverheadSlashEnabled)
		{
			return Mathf.Abs(Player.Player1.transform.position.x - transform.position.x) <= Kin.MinXDistance;
		}
		else
		{
			return false;
		}
	}

	public override IEnumerator DoMove()
	{
		Animator.PlayAnimation("Overhead Antic");
		Rigidbody.velocity = default(Vector2);

		yield return new WaitForSeconds(0.65f);

		Kin.OverheadSlash.gameObject.SetActive(true);

		Kin.OverheadSlash.PlayAnimation("Overhead Slash");

		Kin.StartBoundRoutine(PlaySlashSounds());

		yield return Animator.PlayAnimationTillDone("Overhead Slashing");

		Kin.OverheadSlash.gameObject.SetActive(false);
	}

	IEnumerator PlaySlashSounds()
	{
		WeaverAudio.PlayAtPoint(Kin.SwordSlashSound, transform.position);

		var data = Animator.AnimationData;
		var clipFps = data.GetClipFPS(Animator.PlayingClip);

		//yield return new WaitUntil(() => Animator.PlayingFrame == 4);
		yield return new WaitForSeconds(3f * (1f / clipFps));

		WeaverAudio.PlayAtPoint(Kin.SwordSlashSound, transform.position);

		//yield return new WaitUntil(() => Animator.PlayingFrame == 9);
		yield return new WaitForSeconds(4f * (1f / clipFps));

		WeaverAudio.PlayAtPoint(Kin.SwordSlashSound, transform.position);

		//yield return new WaitUntil(() => Animator.PlayingFrame == 14);
		yield return new WaitForSeconds(4f * (1f / clipFps));

		WeaverAudio.PlayAtPoint(Kin.SwordSlashSound, transform.position);
	}
}

