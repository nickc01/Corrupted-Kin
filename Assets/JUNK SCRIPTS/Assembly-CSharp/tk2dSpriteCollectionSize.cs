using System;

[Serializable]
public class tk2dSpriteCollectionSize
{
	public enum Type
	{
		Explicit = 0,
		PixelsPerMeter = 1,
	}

	public Type type;
	public float orthoSize;
	public float pixelsPerMeter;
	public float width;
	public float height;
}
