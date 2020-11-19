using UnityEngine;

public class tk2dTiledSprite : tk2dBaseSprite
{
	[SerializeField]
	private Vector2 _dimensions;
	[SerializeField]
	private tk2dBaseSprite.Anchor _anchor;
	[SerializeField]
	protected bool _createBoxCollider;
}
