using UnityEngine;

public class tk2dUITextInput : MonoBehaviour
{
	public tk2dUIItem selectionBtn;
	public tk2dTextMesh inputLabel;
	public tk2dTextMesh emptyDisplayLabel;
	public GameObject unSelectedStateGO;
	public GameObject selectedStateGO;
	public GameObject cursor;
	public float fieldLength;
	public int maxCharacterLength;
	public string emptyDisplayText;
	public bool isPasswordField;
	public string passwordChar;
	[SerializeField]
	private tk2dUILayout layoutItem;
	public string SendMessageOnTextChangeMethodName;
}
