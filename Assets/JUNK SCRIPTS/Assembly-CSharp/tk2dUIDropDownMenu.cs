using UnityEngine;

public class tk2dUIDropDownMenu : MonoBehaviour
{
	public tk2dUIItem dropDownButton;
	public tk2dTextMesh selectedTextMesh;
	public float height;
	public tk2dUIDropDownItem dropDownItemTemplate;
	[SerializeField]
	private string[] startingItemList;
	[SerializeField]
	private int startingIndex;
	public string SendMessageOnSelectedItemChangeMethodName;
	[SerializeField]
	private tk2dUILayout menuLayoutItem;
	[SerializeField]
	private tk2dUILayout templateLayoutItem;
}
