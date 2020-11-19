using System;
using UnityEngine;

[Serializable]
public class tk2dBatchedSprite
{
	public enum Type
	{
		EmptyGameObject = 0,
		Sprite = 1,
		TiledSprite = 2,
		SlicedSprite = 3,
		ClippedSprite = 4,
		TextMesh = 5,
	}

	public enum Flags
	{
		None = 0,
		Sprite_CreateBoxCollider = 1,
		SlicedSprite_BorderOnly = 2,
	}

	public Type type;
	public string name;
	public int parentId;
	public int spriteId;
	public int xRefId;
	public tk2dSpriteCollectionData spriteCollection;
	public Quaternion rotation;
	public Vector3 position;
	public Vector3 localScale;
	public Color color;
	public Vector3 baseScale;
	public int renderLayer;
	[SerializeField]
	private Vector2 internalData0;
	[SerializeField]
	private Vector2 internalData1;
	[SerializeField]
	private Vector2 internalData2;
	[SerializeField]
	private Vector2 colliderData;
	[SerializeField]
	private string formattedText;
	[SerializeField]
	private Flags flags;
	public tk2dBaseSprite.Anchor anchor;
	public Matrix4x4 relativeMatrix;
}
