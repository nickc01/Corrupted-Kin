using UnityEngine;
using System.Collections.Generic;

public class tk2dFontData : MonoBehaviour
{
	public int version;
	public float lineHeight;
	public tk2dFontChar[] chars;
	[SerializeField]
	private List<int> charDictKeys;
	[SerializeField]
	private List<tk2dFontChar> charDictValues;
	public string[] fontPlatforms;
	public string[] fontPlatformGUIDs;
	public bool hasPlatformData;
	public bool managedFont;
	public bool needMaterialInstance;
	public bool isPacked;
	public bool premultipliedAlpha;
	public tk2dSpriteCollectionData spriteCollection;
	public bool useDictionary;
	public tk2dFontKerning[] kerning;
	public float largestWidth;
	public Material material;
	public Texture2D gradientTexture;
	public bool textureGradients;
	public int gradientCount;
	public Vector2 texelSize;
	public float invOrthoSize;
	public float halfTargetHeight;
}
