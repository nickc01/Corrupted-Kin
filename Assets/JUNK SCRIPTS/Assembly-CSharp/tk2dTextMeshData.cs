using System;
using UnityEngine;

[Serializable]
public class tk2dTextMeshData
{
	public int version;
	public tk2dFontData font;
	public string text;
	public Color color;
	public Color color2;
	public bool useGradient;
	public int textureGradient;
	public TextAnchor anchor;
	public int renderLayer;
	public Vector3 scale;
	public bool kerning;
	public int maxChars;
	public bool inlineStyling;
	public bool formatting;
	public int wordWrapWidth;
	public float spacing;
	public float lineSpacing;
}
