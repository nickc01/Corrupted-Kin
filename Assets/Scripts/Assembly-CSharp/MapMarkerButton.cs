using UnityEngine;

public class MapMarkerButton : MonoBehaviour
{
	public enum DisableType
	{
		GameObject = 0,
		SpriteRenderer = 1,
	}

	public int neededMarkerTypes;
	public DisableType disable;
	public bool keepDisabled;
}
