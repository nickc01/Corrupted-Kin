using UnityEngine;

public class VibrationPlayer : MonoBehaviour
{
	[SerializeField]
	private VibrationData data;
	[SerializeField]
	private VibrationTarget target;
	[SerializeField]
	private bool playAutomatically;
	[SerializeField]
	private bool isLooping;
	[SerializeField]
	private string vibrationTag;
}
