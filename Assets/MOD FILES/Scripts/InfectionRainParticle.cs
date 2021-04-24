using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using WeaverCore.Utilities;

[RequireComponent(typeof(PoolableObject))]
[RequireComponent(typeof(AspidShot))]
public class InfectionRainParticle : MonoBehaviour
{
	[NonSerialized]
	public SpecialMoves SourceMove;

	Collider2D rainCollider;
	bool activated = false;

	public Collider2D RainCollider
	{
		get
		{
			return rainCollider;
		}
	}

	public void OnRainStart()
	{
		activated = false;
		if (rainCollider == null)
		{
			rainCollider = GetComponent<Collider2D>();
		}
	}

	float _time = 0f;

	void Update()
	{
		_time += Time.deltaTime;
		if (!activated && transform.position.y <= SourceMove.ActivationHeight + SourceMove.Kin.FloorY)
		{
			rainCollider.enabled = true;
			activated = true;
		}
	}
}

