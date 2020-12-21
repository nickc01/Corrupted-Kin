using UnityEngine;

public class tk2dStaticSpriteBatcher : MonoBehaviour
{
	public enum Flags
	{
		None = 0,
		GenerateCollider = 1,
		FlattenDepth = 2,
		SortToCamera = 4,
	}

	public int version;
	public tk2dBatchedSprite[] batchedSprites;
	public tk2dTextMeshData[] allTextMeshData;
	public tk2dSpriteCollectionData spriteCollection;
	[SerializeField]
	private Flags flags;
	[SerializeField]
	private Vector3 _scale;
}
