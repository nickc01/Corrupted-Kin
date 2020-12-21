using UnityEngine;

public class GamepadVibration : ScriptableObject
{
	[SerializeField]
	private AnimationCurve smallMotor;
	[SerializeField]
	private AnimationCurve largeMotor;
	[SerializeField]
	private float playbackRate;
}
