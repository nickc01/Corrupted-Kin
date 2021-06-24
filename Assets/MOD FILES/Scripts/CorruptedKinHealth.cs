using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using WeaverCore.Components;
using WeaverCore.Features;
using WeaverCore.Settings;

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
		var CKSettings = Panel.GetSettings<CorruptedKinSettings>();
		if (CKSettings != null && CKSettings.CustomHealth)
		{
			Health = CKSettings.CustomHealthValue;
		}
		else
		{
			switch (Boss.Difficulty)
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
	}

	protected override void OnHealthUpdate(int oldValue, int newValue)
	{
		TimesHit++;
		if (HealthLocked)
		{
			//return Health;
			SetHealthInternal(oldValue);
		}
		else
		{
			SetHealthInternal(newValue);
			//return base.OnHealthUpdate(newValue);
		}
	}
}

