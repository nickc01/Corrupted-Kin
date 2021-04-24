﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using WeaverCore.Components;
using WeaverCore.Features;

public class CorruptedKinHealth : EntityHealth
{
	[SerializeField]
	int attunedHealth = 2600;
	[SerializeField]
	int ascendedHealth = 2700;
	[SerializeField]
	int radiantHealth = 2750;


	public bool HealthLocked { get; set; }


	public long TimesHit { get; set; }

	protected override void Awake()
	{
		base.Awake();
		switch (Boss.Diffculty)
		{
			case WeaverCore.Enums.BossDifficulty.Attuned:
				Health = attunedHealth;
				break;
			case WeaverCore.Enums.BossDifficulty.Ascended:
				Health = ascendedHealth;
				break;
			case WeaverCore.Enums.BossDifficulty.Radiant:
				Health = radiantHealth;
				break;
		}
	}

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

