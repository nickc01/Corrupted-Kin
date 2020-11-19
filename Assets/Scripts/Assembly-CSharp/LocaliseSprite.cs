using UnityEngine;
using System;
using Language;

public class LocaliseSprite : MonoBehaviour
{
	[Serializable]
	public struct LangSpritePair
	{
		public LanguageCode language;
		public Sprite sprite;
	}

	public LangSpritePair[] sprites;
}
