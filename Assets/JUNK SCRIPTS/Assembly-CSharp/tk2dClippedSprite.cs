using UnityEngine;

public class tk2dClippedSprite : tk2dBaseSprite
{
	public Vector2 _clipBottomLeft;
	public Vector2 _clipTopRight;
	[SerializeField]
	protected bool _createBoxCollider;
}
