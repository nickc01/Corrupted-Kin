using UnityEngine;
using System;

public class ShineAnimSequence : MonoBehaviour
{
	[Serializable]
	public class ShineObject
	{
		public SpriteRenderer renderer;
		public Sprite[] shineSprites;
		public float fps;
	}

	public ShineObject[] shineObjects;
	public float shineDelay;
	public float sequencePauseTime;
}
