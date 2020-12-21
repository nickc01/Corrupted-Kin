using UnityEngine;

public class tk2dAnimatedSprite : tk2dSprite
{
	[SerializeField]
	private tk2dSpriteAnimator _animator;
	[SerializeField]
	private tk2dSpriteAnimation anim;
	[SerializeField]
	private int clipId;
	public bool playAutomatically;
	public bool createCollider;
}
