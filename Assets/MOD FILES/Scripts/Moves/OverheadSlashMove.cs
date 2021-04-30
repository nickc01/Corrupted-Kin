using System.Collections;
using UnityEngine;
using WeaverCore;
using WeaverCore.Components;

public class OverheadSlashMove : CorruptedKinMove
{
	[SerializeField] WeaverAnimationPlayer OverheadSlash;
	[Tooltip("The minimum distance between the boss and the player in order for the move to execute")]
	[SerializeField] float MinXDistance = 3.5f;

	[SerializeField] float overheadSlashDelay = 0.65f;

	[SerializeField] BoxCollider2D OverheadSlashRange;

	public bool InSlashRange(Vector3 position)
	{
		var bounds = OverheadSlashRange.bounds;

		return position.x >= bounds.min.x && position.x <= bounds.max.x && position.y >= bounds.min.y && position.y <= bounds.max.y;
	}

	public override IEnumerator DoMove()
	{
		Animator.PlayAnimation("Overhead Antic");
		KinRigidbody.velocity = default(Vector2);

		yield return new WaitForSeconds(overheadSlashDelay);

		OverheadSlash.gameObject.SetActive(true);

		OverheadSlash.PlayAnimation("Overhead Slash");

		Kin.StartBoundRoutine(PlaySlashSounds());

		yield return Animator.PlayAnimationTillDone("Overhead Slashing");

		OverheadSlash.gameObject.SetActive(false);
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

	public override void OnStun()
	{
		OverheadSlash.gameObject.SetActive(false);
		base.OnStun();
	}
}

