using UnityEngine;

public class tk2dSlicedSprite : tk2dBaseSprite
{
	[SerializeField]
	private Vector2 _dimensions;
	[SerializeField]
	private tk2dBaseSprite.Anchor _anchor;
	[SerializeField]
	private bool _borderOnly;
	[SerializeField]
	private bool legacyMode;
	public float borderTop;
	public float borderBottom;
	public float borderLeft;
	public float borderRight;
	[SerializeField]
	protected bool _createBoxCollider;
}
