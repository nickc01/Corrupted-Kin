using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using WeaverCore.DataTypes;
using WeaverCore.Enums;
using WeaverCore.Interfaces;
using WeaverCore.Utilities;

public class EnemyDamager : MonoBehaviour
{
	public int damage = 2;
	public AttackType attackType;
	[HideInInspector]
	public CardinalDirection hitDirection;

	void OnTriggerEnter2D(Collider2D collider)
	{
		var obj = collider.transform;

		while (obj != null)
		{
			IHittable hittable = obj.GetComponent<IHittable>();
			if (hittable != null)
			{
				hittable.Hit(new HitInfo()
				{
					Attacker = gameObject,
					Damage = damage,
					AttackStrength = 1f,
					AttackType = attackType,
					Direction = hitDirection.ToDegrees(),
					IgnoreInvincible = false
				});
			}
			obj = obj.parent;
		}
	}
}

