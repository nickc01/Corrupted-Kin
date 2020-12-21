using System;
using UnityEngine;

namespace InControl
{
	[Serializable]
	public class TouchSprite
	{
		[SerializeField]
		private Sprite idleSprite;
		[SerializeField]
		private Sprite busySprite;
		[SerializeField]
		private Color idleColor;
		[SerializeField]
		private Color busyColor;
		[SerializeField]
		private TouchSpriteShape shape;
		[SerializeField]
		private TouchUnitType sizeUnitType;
		[SerializeField]
		private Vector2 size;
		[SerializeField]
		private bool lockAspectRatio;
		[SerializeField]
		private Vector2 worldSize;
	}
}
