using UnityEngine;
using System.Collections.Generic;

public class tk2dBaseSprite : MonoBehaviour
{
	public enum Anchor
	{
		LowerLeft = 0,
		LowerCenter = 1,
		LowerRight = 2,
		MiddleLeft = 3,
		MiddleCenter = 4,
		MiddleRight = 5,
		UpperLeft = 6,
		UpperCenter = 7,
		UpperRight = 8,
	}

	[SerializeField]
	private tk2dSpriteCollectionData collection;
	[SerializeField]
	protected Color _color;
	[SerializeField]
	protected Vector3 _scale;
	[SerializeField]
	protected int _spriteId;
	public BoxCollider2D boxCollider2D;
	public List<PolygonCollider2D> polygonCollider2D;
	public List<EdgeCollider2D> edgeCollider2D;
	public BoxCollider boxCollider;
	public MeshCollider meshCollider;
	public Vector3[] meshColliderPositions;
	public Mesh meshColliderMesh;
	[SerializeField]
	protected int renderLayer;
}
