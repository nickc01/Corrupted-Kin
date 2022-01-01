using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using WeaverCore.Components;
using WeaverCore.Features;
using WeaverCore.Interfaces;
using WeaverCore.Settings;

public class CorruptedKinHealth : EntityHealth
{
    class Modifier : IHealthModifier
    {
		CorruptedKinHealth instance;

		public Modifier(CorruptedKinHealth instance)
        {
			this.instance = instance;
        }

		int IHealthModifier.Priority => 0;

		int IHealthModifier.OnHealthChange(int oldHealth, int newHealth)
		{
			instance.TimesHit++;
			if (instance.HealthLocked)
			{
				return oldHealth;
			}
			else
            {
				return newHealth;
            }
		}
    }


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
		AddModifier(new Modifier(this));
		var CKSettings = GlobalSettings.GetSettings<CorruptedKinSettings>();
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
}

