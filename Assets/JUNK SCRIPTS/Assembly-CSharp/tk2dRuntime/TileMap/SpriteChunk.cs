using System;
using UnityEngine;
using System.Collections.Generic;

namespace tk2dRuntime.TileMap
{
	[Serializable]
	public class SpriteChunk
	{
		public int[] spriteIds;
		public GameObject gameObject;
		public Mesh mesh;
		public MeshCollider meshCollider;
		public Mesh colliderMesh;
		public List<EdgeCollider2D> edgeColliders;
	}
}
