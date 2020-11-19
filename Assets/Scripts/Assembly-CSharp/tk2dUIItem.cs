using UnityEngine;

public class tk2dUIItem : MonoBehaviour
{
	public GameObject sendMessageTarget;
	public string SendMessageOnDownMethodName;
	public string SendMessageOnUpMethodName;
	public string SendMessageOnClickMethodName;
	public string SendMessageOnReleaseMethodName;
	[SerializeField]
	private bool isChildOfAnotherUIItem;
	public bool registerPressFromChildren;
	public bool isHoverEnabled;
	public Transform[] editorExtraBounds;
	public Transform[] editorIgnoreBounds;
}
