using UnityEngine;
using System.Collections.Generic;

public class CameraController : MonoBehaviour
{
	public enum CameraMode
	{
		FROZEN = 0,
		FOLLOWING = 1,
		LOCKED = 2,
		PANNING = 3,
		FADEOUT = 4,
		FADEIN = 5,
		PREVIOUS = 6,
	}

	public CameraMode mode;
	public bool atSceneBounds;
	public bool atHorizontalSceneBounds;
	public Vector3 lastFramePosition;
	public Vector2 lastLockPosition;
	public float dampTime;
	public float dampTimeX;
	public float dampTimeY;
	public float dampTimeFalling;
	public float heroBotYLimit;
	public float fallOffset;
	public float fallOffset_multiplier;
	public Vector3 destination;
	public float maxVelocity;
	public float maxVelocityFalling;
	public float lookOffset;
	public Vector2 panToTarget;
	public float sceneWidth;
	public float sceneHeight;
	public float xLimit;
	public float yLimit;
	public Camera cam;
	public tk2dTileMap tilemap;
	public CameraTarget camTarget;
	public List<CameraLockArea> lockZoneList;
	public float xLockMin;
	public float xLockMax;
	public float yLockMin;
	public float yLockMax;
}
