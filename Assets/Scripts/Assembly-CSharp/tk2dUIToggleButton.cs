using UnityEngine;

public class tk2dUIToggleButton : tk2dUIBaseItemControl
{
	public GameObject offStateGO;
	public GameObject onStateGO;
	public bool activateOnPress;
	[SerializeField]
	private bool isOn;
	public string SendMessageOnToggleMethodName;
}
