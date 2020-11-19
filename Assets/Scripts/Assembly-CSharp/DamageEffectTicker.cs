using UnityEngine;
using System.Collections.Generic;

public class DamageEffectTicker : MonoBehaviour
{
	public List<GameObject> enemyList;
	public float damageInterval;
	public string damageEvent;
	public ExtraDamageTypes extraDamageType;
}
