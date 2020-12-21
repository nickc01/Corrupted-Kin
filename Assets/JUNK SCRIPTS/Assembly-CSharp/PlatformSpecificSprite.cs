using UnityEngine;
using System;

public class PlatformSpecificSprite : MonoBehaviour
{
	[Serializable]
	public struct PlatformSpriteMatch
	{
		public RuntimePlatform Platform;
		public Sprite Sprite;
	}

	[SerializeField]
	private SpriteRenderer spriteRenderer;
	[SerializeField]
	private PlatformSpriteMatch[] sprites;
}
