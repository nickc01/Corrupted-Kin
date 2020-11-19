using UnityEngine;

namespace InControl
{
	public class Touch
	{
		public int fingerId;
		public TouchPhase phase;
		public int tapCount;
		public Vector2 position;
		public Vector2 deltaPosition;
		public Vector2 lastPosition;
		public float deltaTime;
		public ulong updateTick;
		public TouchType type;
		public float altitudeAngle;
		public float azimuthAngle;
		public float maximumPossiblePressure;
		public float pressure;
		public float radius;
		public float radiusVariance;
	}
}
