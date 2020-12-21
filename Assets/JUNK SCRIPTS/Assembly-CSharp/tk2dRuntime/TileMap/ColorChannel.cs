using System;
using UnityEngine;

namespace tk2dRuntime.TileMap
{
	[Serializable]
	public class ColorChannel
	{
		public Color clearColor;
		public ColorChunk[] chunks;
		public int numColumns;
		public int numRows;
		public int divX;
		public int divY;
	}
}
