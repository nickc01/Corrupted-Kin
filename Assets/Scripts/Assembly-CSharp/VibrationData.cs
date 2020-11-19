using System;
using UnityEngine;

[Serializable]
public struct VibrationData
{
	[SerializeField]
	private LowFidelityVibrations lowFidelityVibration;
	[SerializeField]
	private TextAsset highFidelityVibration;
	[SerializeField]
	private GamepadVibration gamepadVibration;
}
