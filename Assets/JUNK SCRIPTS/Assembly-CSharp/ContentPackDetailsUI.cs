using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.UI.Extensions;

public class ContentPackDetailsUI : MonoBehaviour
{
	[Serializable]
	public class ContentPackDetails
	{
		public Sprite posterSprite;
		public string titleText;
		[MultilineAttribute]
		public string descriptionText;
		public int menuStyleIndex;
	}

	public ContentPackDetails[] details;
	public Image posterImage;
	public Text titleText;
	public Text descriptionText;
	public SoftMaskScript softMask;
	public ScrollRect scrollRect;
	public string languageSheet;
	public int beforeSpaces;
	public int afterSpaces;
}
