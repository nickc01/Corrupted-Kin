using UnityEngine;
using InControl;
using GlobalEnums;

public class InputHandler : MonoBehaviour
{
	public BindingSourceType lastActiveController;
	public GamepadType activeGamepadType;
	public GamepadState gamepadState;
	public float inputX;
	public float inputY;
	public bool acceptingInput;
	public bool skippingCutscene;
}
