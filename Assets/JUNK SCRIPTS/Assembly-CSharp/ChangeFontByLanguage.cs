using UnityEngine;
using TMPro;

public class ChangeFontByLanguage : MonoBehaviour
{
	public enum FontScaleLangTypes
	{
		None = 0,
		AreaName = 1,
		SubAreaName = 2,
		WideMap = 3,
		CreditsTitle = 4,
		ExcerptAuthor = 5,
	}

	public TMP_FontAsset defaultFont;
	public TMP_FontAsset fontJA;
	public TMP_FontAsset fontRU;
	public TMP_FontAsset fontZH;
	public TMP_FontAsset fontKO;
	public bool onlyOnStart;
	public FontScaleLangTypes fontScaleLangType;
}
