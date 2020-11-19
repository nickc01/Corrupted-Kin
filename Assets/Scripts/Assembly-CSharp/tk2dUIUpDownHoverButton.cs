using UnityEngine;

public class tk2dUIUpDownHoverButton : tk2dUIBaseItemControl
{
	public GameObject upStateGO;
	public GameObject downStateGO;
	public GameObject hoverOverStateGO;
	[SerializeField]
	private bool useOnReleaseInsteadOfOnUp;
	public string SendMessageOnToggleOverMethodName;
}
