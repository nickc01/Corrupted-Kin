using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchingPlayer : MonoBehaviour 
{
	public LayerMask CollisionLayers;

	public bool IsTouchingPlayer { get; private set; }

	void OnTriggerEnter2D(Collider2D collider)
	{
		if ((collider.gameObject.layer & CollisionLayers.value) > 0)
		{
			IsTouchingPlayer = true;
		}
	}

	void OnTriggerExit2D(Collider2D collider)
	{
		if ((collider.gameObject.layer & CollisionLayers.value) > 0)
		{
			IsTouchingPlayer = false;
		}
	}
}
