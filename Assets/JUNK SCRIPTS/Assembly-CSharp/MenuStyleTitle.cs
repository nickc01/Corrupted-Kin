using UnityEngine;
using System;

public class MenuStyleTitle : MonoBehaviour
{
	[Serializable]
	public struct TitleSpriteCollection
	{
		public RuntimePlatform[] PlatformWhitelist;
		public Sprite Default;
		public Sprite Chinese;
		public Sprite Russian;
		public Sprite Italian;
		public Sprite Japanese;
		public Sprite Spanish;
		public Sprite Korean;
		public Sprite French;
		public Sprite BrazilianPT;
	}

	public SpriteRenderer Title;
	public TitleSpriteCollection DefaultTitleSprite;
	public TitleSpriteCollection[] TitleSprites;
}
