using System;
using UnityEngine;
using UnityEngine.Events;
using WeaverCore.Settings;

[CreateAssetMenu(fileName = "Corrupted Kin Settings", menuName = "Corrupted Kin Settings")]
public class CorruptedKinSettings : GlobalSettings
{
	public override string TabName
	{
		get
		{
			return "Corrupted Kin";
		}
	}

	[Tooltip("This will enable you to fight Corrupted Kin in the arena where you initially fight Lost Kin. The broken vessel corpse in the abyss can be dream nailed as many times as you want")]
	public bool EnableInAbyss = false;

	[Tooltip("Whether custom health should be enabled")]
	[SerializeField]
	[SettingField(EnabledType.Never)]
	bool _customHealth = false;

	[SettingField(EnabledType.MenuOnly)]
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

	[Tooltip(@"What the health of the boss will be set to

For reference, the health values of the boss are:

Attuned : 2900
Ascended : 2950
Radiant : 3000")]
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

