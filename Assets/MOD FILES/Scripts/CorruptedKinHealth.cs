using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using WeaverCore.Components;

public class CorruptedKinHealth : EntityHealth
{
	public bool HealthLocked { get; set; }


	public long TimesHit { get; set; }

	protected override int OnHealthUpdate(int newValue)
	{
		TimesHit++;
		if (HealthLocked)
		{
			return Health;
		}
		else
		{
			return base.OnHealthUpdate(newValue);
		}
	}
}

