using System;
using UnityEngine;

[Serializable]
public class tk2dSpriteDefinition
{
	[Serializable]
	public class AttachPoint
	{
		public string name;
		public Vector3 position;
		public float angle;
	}

	public enum FlipMode
	{
		None = 0,
		Tk2d = 1,
		TPackerCW = 2,
	}

	public enum PhysicsEngine
	{
		Physics3D = 0,
		Physics2D = 1,
	}

	public enum ColliderType
	{
		Unset = 0,
		None = 1,
		Box = 2,
		Mesh = 3,
		Custom = 4,
	}

	public string name;
	public Vector3[] boundsData;
	public Vector3[] untrimmedBoundsData;
	public Vector2 texelSize;
	public Vector3[] positions;
	public Vector3[] normals;
	public Vector4[] tangents;
	public Vector2[] uvs;
	public Vector2[] normalizedUvs;
	public int[] indices;
	public Material material;
	public int materialId;
	public string sourceTextureGUID;
	public bool extractRegion;
	public int regionX;
	public int regionY;
	public int regionW;
	public int regionH;
	public FlipMode flipped;
	public bool complexGeometry;
	public PhysicsEngine physicsEngine;
	public ColliderType colliderType;
	public tk2dSpriteColliderDefinition[] customColliders;
	public Vector3[] colliderVertices;
	public int[] colliderIndicesFwd;
	public int[] colliderIndicesBack;
	public bool colliderConvex;
	public bool colliderSmoothSphereCollisions;
	public tk2dCollider2DData[] polygonCollider2D;
	public tk2dCollider2DData[] edgeCollider2D;
	public AttachPoint[] attachPoints;
}
