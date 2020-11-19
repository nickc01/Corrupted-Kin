using UnityEngine;

public class VisibilityControl : MonoBehaviour
{
	public enum ControlType
	{
		SHOW_AND_HIDE = 0,
		HIDE_ONLY = 1,
	}

	public ControlType controlType;
}
