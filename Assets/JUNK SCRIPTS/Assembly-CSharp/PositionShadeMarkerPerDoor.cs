using UnityEngine;
using System;

public class PositionShadeMarkerPerDoor : MonoBehaviour
{
	[Serializable]
	public struct DoorShadePosition
	{
		public GameObject door;
		public Vector2 position;
	}

	public GameObject shadeMarker;
	public DoorShadePosition[] shadePositions;
}
