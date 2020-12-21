using UnityEngine;

public class tk2dFont : MonoBehaviour
{
	public TextAsset bmFont;
	public Material material;
	public Texture texture;
	public Texture2D gradientTexture;
	public bool dupeCaps;
	public bool flipTextureY;
	public bool proxyFont;
	[SerializeField]
	private bool useTk2dCamera;
	[SerializeField]
	private int targetHeight;
	[SerializeField]
	private float targetOrthoSize;
	public tk2dSpriteCollectionSize sizeDef;
	public int gradientCount;
	public bool manageMaterial;
	public bool loadable;
	public int charPadX;
	public tk2dFontData data;
	public int version;
}
