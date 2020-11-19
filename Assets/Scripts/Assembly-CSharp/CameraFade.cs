using UnityEngine;

public class CameraFade : MonoBehaviour
{
	public enum FadeTypes
	{
		NONE = 0,
		BLACK_TO_CLEAR = 1,
		CLEAR_TO_BLACK = 2,
	}

	public FadeTypes fadeOnStart;
	public float startDelay;
	public float fadeTime;
}
