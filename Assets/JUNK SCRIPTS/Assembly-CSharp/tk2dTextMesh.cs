using UnityEngine;

public class tk2dTextMesh : MonoBehaviour
{
	[SerializeField]
	private tk2dFontData _font;
	[SerializeField]
	private string _text;
	[SerializeField]
	private Color _color;
	[SerializeField]
	private Color _color2;
	[SerializeField]
	private bool _useGradient;
	[SerializeField]
	private int _textureGradient;
	[SerializeField]
	private TextAnchor _anchor;
	[SerializeField]
	private Vector3 _scale;
	[SerializeField]
	private bool _kerning;
	[SerializeField]
	private int _maxChars;
	[SerializeField]
	private bool _inlineStyling;
	[SerializeField]
	private bool _formatting;
	[SerializeField]
	private int _wordWrapWidth;
	[SerializeField]
	private float spacing;
	[SerializeField]
	private float lineSpacing;
	[SerializeField]
	private tk2dTextMeshData data;
}
