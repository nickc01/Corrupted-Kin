using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeaverCore;
using WeaverCore.Components;
using WeaverCore.Utilities;

/// <summary>
/// Automatically flips an object horizontally depending on the sprite flip of the immediate parent
/// </summary>
public class AutoFlip : MonoBehaviour
{
	public enum FlipMode
	{
		/// <summary>
		/// Flips the sprite on the object
		/// </summary>
		SpriteFlip,
		/// <summary>
		/// Flips the x-scale of the object
		/// </summary>
		ScaleFlip
	}
	[SerializeField]
	[Tooltip("If checked, the object will be unparented when the gameObject is enabled, and reparented when disabled")]
	bool unparent = false;
	[SerializeField]
	bool FlipX = true;
	[SerializeField]
	bool FlipY = false;
	[SerializeField]
	[Tooltip("The type of flip mode to use. Sprite Flip flips the sprite horizontally. Scale Flip flips the x-scale horizontally")]
	FlipMode flipMode = FlipMode.SpriteFlip;



	Transform oldParent;
	Vector3 oldLocalPosition;
	float oldScaleX;
	bool oldFlipXState;

	SpriteRenderer spriteRenderer;

	void OnEnable()
	{
		if (spriteRenderer == null)
		{
			spriteRenderer = GetComponent<SpriteRenderer>();
		}
		oldParent = transform.parent;

		var parentSprite = oldParent.GetComponent<SpriteRenderer>();
		oldLocalPosition = transform.localPosition;
		if (spriteRenderer != null)
		{
			oldFlipXState = spriteRenderer.flipX;
		}
		oldScaleX = transform.localScale.x;

		Debug.Log("Flipping Object " + gameObject.name);

		if (parentSprite != null)
		{
			if (parentSprite.flipX)
			{
				if (flipMode == FlipMode.SpriteFlip)
				{
					spriteRenderer.flipX = !spriteRenderer.flipX;
				}
				else
				{
					transform.localScale = transform.localScale.With(x: -oldScaleX);
				}

				var oldPosition = transform.localPosition;

				if (FlipX)
				{
					oldPosition.x = -oldPosition.x;
				}

				if (FlipY)
				{
					oldPosition.y = -oldPosition.y;
				}

				transform.localPosition = oldPosition;
			}
		}
		if (unparent)
		{
			transform.SetParent(null, true);
		}
	}

	void OnDisable()
	{
		transform.SetParent(oldParent);
		transform.localPosition = oldLocalPosition;
		if (spriteRenderer != null)
		{
			spriteRenderer.flipX = oldFlipXState;
		}
		transform.localScale = transform.localScale.With(x: oldScaleX);
	}
}
