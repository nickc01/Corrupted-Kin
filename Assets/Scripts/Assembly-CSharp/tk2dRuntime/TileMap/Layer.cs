using System;
using UnityEngine;

namespace tk2dRuntime.TileMap
{
	[Serializable]
	public class Layer
	{
		public int hash;
		public SpriteChannel spriteChannel;
		public int width;
		public int height;
		public int numColumns;
		public int numRows;
		public int divX;
		public int divY;
		public GameObject gameObject;
	}
}
