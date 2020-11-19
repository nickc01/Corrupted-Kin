using UnityEngine;

namespace InControl
{
	public class UnityInputDeviceProfile : UnityInputDeviceProfileBase
	{
		[SerializeField]
		protected string[] JoystickNames;
		[SerializeField]
		protected string[] JoystickRegex;
		[SerializeField]
		protected string LastResortRegex;
	}
}
