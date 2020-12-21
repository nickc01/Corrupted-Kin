using UnityEngine;

public class tk2dUIToggleButtonGroup : MonoBehaviour
{
	[SerializeField]
	private tk2dUIToggleButton[] toggleBtns;
	public GameObject sendMessageTarget;
	[SerializeField]
	private int selectedIndex;
	public string SendMessageOnChangeMethodName;
}
