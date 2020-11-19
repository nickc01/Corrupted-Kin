using System;
using UnityEngine;

[Serializable]
public class tk2dCameraResolutionOverride
{
	public enum MatchByType
	{
		Resolution = 0,
		AspectRatio = 1,
		Wildcard = 2,
	}

	public enum AutoScaleMode
	{
		None = 0,
		FitWidth = 1,
		FitHeight = 2,
		FitVisible = 3,
		StretchToFit = 4,
		ClosestMultipleOfTwo = 5,
		PixelPerfect = 6,
		Fill = 7,
	}

	public enum FitMode
	{
		Constant = 0,
		Center = 1,
	}

	public string name;
	public MatchByType matchBy;
	public int width;
	public int height;
	public float aspectRatioNumerator;
	public float aspectRatioDenominator;
	public float scale;
	public Vector2 offsetPixels;
	public AutoScaleMode autoScaleMode;
	public FitMode fitMode;
}
