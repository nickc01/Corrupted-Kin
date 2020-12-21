using System;
using UnityEngine;
using System.Collections.Generic;

[Serializable]
public class tk2dSpriteCollectionDefinition
{
	[Serializable]
	public class ColliderData
	{
		public enum Type
		{
			Box = 0,
			Circle = 1,
		}

		public string name;
		public Type type;
		public Vector2 origin;
		public Vector2 size;
		public float angle;
	}

	public enum Anchor
	{
		UpperLeft = 0,
		UpperCenter = 1,
		UpperRight = 2,
		MiddleLeft = 3,
		MiddleCenter = 4,
		MiddleRight = 5,
		LowerLeft = 6,
		LowerCenter = 7,
		LowerRight = 8,
		Custom = 9,
	}

	public enum DiceFilter
	{
		Complete = 0,
		SolidOnly = 1,
		TransparentOnly = 2,
	}

	public enum Pad
	{
		Default = 0,
		BlackZeroAlpha = 1,
		Extend = 2,
		TileXY = 3,
		TileX = 4,
		TileY = 5,
	}

	public enum Source
	{
		Sprite = 0,
		SpriteSheet = 1,
		Font = 2,
	}

	public enum ColliderType
	{
		UserDefined = 0,
		ForceNone = 1,
		BoxTrimmed = 2,
		BoxCustom = 3,
		Polygon = 4,
		Advanced = 5,
	}

	public enum PolygonColliderCap
	{
		None = 0,
		FrontAndBack = 1,
		Front = 2,
		Back = 3,
	}

	public enum ColliderColor
	{
		Default = 0,
		Red = 1,
		White = 2,
		Black = 3,
	}

	public string name;
	public bool disableTrimming;
	public bool additive;
	public Vector3 scale;
	public Texture2D texture;
	public int materialId;
	public Anchor anchor;
	public float anchorX;
	public float anchorY;
	public UnityEngine.Object overrideMesh;
	public bool doubleSidedSprite;
	public bool customSpriteGeometry;
	public tk2dSpriteColliderIsland[] geometryIslands;
	public bool dice;
	public int diceUnitX;
	public int diceUnitY;
	public DiceFilter diceFilter;
	public Pad pad;
	public int extraPadding;
	public Source source;
	public bool fromSpriteSheet;
	public bool hasSpriteSheetId;
	public int spriteSheetId;
	public int spriteSheetX;
	public int spriteSheetY;
	public bool extractRegion;
	public int regionX;
	public int regionY;
	public int regionW;
	public int regionH;
	public int regionId;
	public ColliderType colliderType;
	public List<tk2dSpriteCollectionDefinition.ColliderData> colliderData;
	public Vector2 boxColliderMin;
	public Vector2 boxColliderMax;
	public tk2dSpriteColliderIsland[] polyColliderIslands;
	public PolygonColliderCap polyColliderCap;
	public bool colliderConvex;
	public bool colliderSmoothSphereCollisions;
	public ColliderColor colliderColor;
	public List<tk2dSpriteDefinition.AttachPoint> attachPoints;
}
