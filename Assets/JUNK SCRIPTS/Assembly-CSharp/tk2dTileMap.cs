using UnityEngine;
using System;
using tk2dRuntime.TileMap;
using System.Collections.Generic;

public class tk2dTileMap : MonoBehaviour
{
	[Serializable]
	public class TilemapPrefabInstance
	{
		public int x;
		public int y;
		public int layer;
		public GameObject instance;
	}

	public string editorDataGUID;
	public tk2dTileMapData data;
	public GameObject renderData;
	[SerializeField]
	private tk2dSpriteCollectionData spriteCollection;
	[SerializeField]
	private int spriteCollectionKey;
	public int width;
	public int height;
	public int partitionSizeX;
	public int partitionSizeY;
	[SerializeField]
	private Layer[] layers;
	[SerializeField]
	private ColorChannel colorChannel;
	[SerializeField]
	private GameObject prefabsRoot;
	[SerializeField]
	private List<tk2dTileMap.TilemapPrefabInstance> tilePrefabsList;
	[SerializeField]
	private bool _inEditMode;
	public string serializedMeshPath;
}
