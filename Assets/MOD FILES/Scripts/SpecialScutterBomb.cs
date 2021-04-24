using System;
using UnityEngine;

public class SpecialScutterBomb : ScuttlerBomb
{
	[NonSerialized]
	public SpecialMoves SourceMove;

	bool bombActivated = false;

	protected override void Awake()
	{
		base.Awake();
		collider.enabled = false;
		bombActivated = false;
		transform.rotation = Quaternion.Euler(0f, 0f, UnityEngine.Random.Range(0f, 360f));
	}

	protected override void Update()
	{
		base.Update();
		if (!bombActivated && transform.position.y <= SourceMove.ActivationHeight + SourceMove.Kin.FloorY)
		{
			bombActivated = true;
			collider.enabled = true;
		}
	}
}
