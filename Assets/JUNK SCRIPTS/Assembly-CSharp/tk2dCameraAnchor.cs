using UnityEngine;

public class tk2dCameraAnchor : MonoBehaviour
{
	[SerializeField]
	private int anchor;
	[SerializeField]
	private tk2dBaseSprite.Anchor _anchorPoint;
	[SerializeField]
	private bool anchorToNativeBounds;
	[SerializeField]
	private Vector2 offset;
	[SerializeField]
	private tk2dCamera tk2dCamera;
	[SerializeField]
	private Camera _anchorCamera;
}
