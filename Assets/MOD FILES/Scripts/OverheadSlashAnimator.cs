using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaverCore.Components;

public class OverheadSlashAnimator : WeaverAnimationPlayer
{
	public PolygonCollider2D colliderFor5;
	public PolygonCollider2D colliderFor6;
	public PolygonCollider2D colliderFor7;

	public PolygonCollider2D colliderFor10;
	public PolygonCollider2D colliderFor11;
	public PolygonCollider2D colliderFor12;

	IEnumerable<PolygonCollider2D> colliders
	{
		get
		{
			yield return colliderFor5;
			yield return colliderFor6;
			yield return colliderFor7;

			yield return colliderFor10;
			yield return colliderFor11;
			yield return colliderFor12;

		}
	}

	void EnableAll(bool state)
	{
		foreach (var poly in colliders)
		{
			poly.enabled = state;
		}
	}

	protected override void OnPlayingFrame(int frame)
	{
		EnableAll(false);
		if (frame == 0 || frame == 10)
		{
			colliderFor5.enabled = true;
		}
		else if (frame == 1 || frame == 11)
		{
			colliderFor6.enabled = true;
		}
		else if (frame == 2 || frame == 12)
		{
			colliderFor7.enabled = true;
		}
		else if (frame == 5 || frame == 15)
		{
			colliderFor10.enabled = true;
		}
		else if (frame == 6 || frame == 16)
		{
			colliderFor11.enabled = true;
		}
		else if (frame == 7)
		{
			colliderFor12.enabled = true;
		}
		base.OnPlayingFrame(frame);
	}
}
