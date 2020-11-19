using UnityEngine;
using System;
using System.Collections.Generic;

public class RemapTK2DSpriteAnimator : MonoBehaviour
{
	[Serializable]
	public struct AnimationRemap
	{
		public string sourceClip;
		public string targetClip;
	}

	public tk2dSpriteAnimator sourceAnimator;
	public tk2dSpriteAnimator targetAnimator;
	public bool syncFrames;
	public List<RemapTK2DSpriteAnimator.AnimationRemap> animationsList;
}
