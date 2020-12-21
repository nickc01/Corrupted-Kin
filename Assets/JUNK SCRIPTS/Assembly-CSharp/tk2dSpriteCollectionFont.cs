using System;
using UnityEngine;

[Serializable]
public class tk2dSpriteCollectionFont
{
	public bool active;
	public TextAsset bmFont;
	public Texture2D texture;
	public bool dupeCaps;
	public bool flipTextureY;
	public int charPadX;
	public tk2dFontData data;
	public tk2dFont editorData;
	public int materialId;
	public bool useGradient;
	public Texture2D gradientTexture;
	public int gradientCount;
}
