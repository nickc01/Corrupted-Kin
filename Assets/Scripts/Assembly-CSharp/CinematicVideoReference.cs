using UnityEngine;
using UnityEngine.Video;

public class CinematicVideoReference : ScriptableObject
{
	[SerializeField]
	private string videoAssetPath;
	[SerializeField]
	private string audioAssetPath;
	[SerializeField]
	private VideoClip embeddedVideoClip;
}
