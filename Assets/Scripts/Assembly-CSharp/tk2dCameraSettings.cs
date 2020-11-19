using System;
using UnityEngine;

[Serializable]
public class tk2dCameraSettings
{
	public enum ProjectionType
	{
		Orthographic = 0,
		Perspective = 1,
	}

	public enum OrthographicOrigin
	{
		BottomLeft = 0,
		Center = 1,
	}

	public enum OrthographicType
	{
		PixelsPerMeter = 0,
		OrthographicSize = 1,
	}

	public ProjectionType projection;
	public float orthographicSize;
	public float orthographicPixelsPerMeter;
	public OrthographicOrigin orthographicOrigin;
	public OrthographicType orthographicType;
	public TransparencySortMode transparencySortMode;
	public float fieldOfView;
	public Rect rect;
}
