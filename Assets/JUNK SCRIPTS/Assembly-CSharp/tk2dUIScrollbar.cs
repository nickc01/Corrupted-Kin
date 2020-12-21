using UnityEngine;

public class tk2dUIScrollbar : MonoBehaviour
{
	public enum Axes
	{
		XAxis = 0,
		YAxis = 1,
	}

	public tk2dUIItem barUIItem;
	public float scrollBarLength;
	public tk2dUIItem thumbBtn;
	public Transform thumbTransform;
	public float thumbLength;
	public tk2dUIItem upButton;
	public tk2dUIItem downButton;
	public float buttonUpDownScrollDistance;
	public bool allowScrollWheel;
	public Axes scrollAxes;
	public tk2dUIProgressBar highlightProgressBar;
	[SerializeField]
	private tk2dUILayout barLayoutItem;
	public string SendMessageOnScrollMethodName;
}
