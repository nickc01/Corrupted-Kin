﻿using System;
using UnityEngine;
using UnityEngine.Events;
using WeaverCore.Settings;

[CreateAssetMenu(fileName = "Corrupted Kin Settings", menuName = "Corrupted Kin Settings")]
public class CorruptedKinSettings : Panel
{
	public override string TabName
	{
		get
		{
			return "Corrupted Kin";
		}
	}

	[Tooltip("If set to true, this will permanently enable access to the dream arena in the abyss")]
	public bool EnableInAbyss = false;

	[Tooltip("Whether custom health should be enabled")]
	[SerializeField]
	[SettingField(Visibility.Never)]
	bool _customHealth = false;

	[SettingField(Visibility.MenuOnly)]
	[SettingDescription("Whether custom health should be enabled")]
	public bool CustomHealth
	{
		get
		{
			return _customHealth;
		}
		set
		{
			if (_customHealth != value)
			{
				_customHealth = value;
				if (!InPauseMenu)
				{
					GetElement("CustomHealthValue").Visible = _customHealth;
				}
			}
		}
	}

	[Tooltip("What the health of the boss will be set to")]
	public int CustomHealthValue = 2800;

	protected override void OnPanelOpen()
	{
		var healthElement = GetElement("CustomHealthValue");
		if (!InPauseMenu)
		{
			healthElement.Visible = _customHealth;
			healthElement.MoveToBottom();
		}
		else
		{
			healthElement.Visible = false;
		}
	}
}

