using UnityEngine;

public class tk2dUIScrollableArea : MonoBehaviour
{
	public enum Axes
	{
		XAxis = 0,
		YAxis = 1,
	}

	[SerializeField]
	private float contentLength;
	[SerializeField]
	private float visibleAreaLength;
	public GameObject contentContainer;
	public tk2dUIScrollbar scrollBar;
	public tk2dUIItem backgroundUIItem;
	public Axes scrollAxes;
	public bool allowSwipeScrolling;
	public bool allowScrollWheel;
	[SerializeField]
	private tk2dUILayout backgroundLayoutItem;
	[SerializeField]
	private tk2dUILayoutContainer contentLayoutContainer;
	public string SendMessageOnScrollMethodName;
}
