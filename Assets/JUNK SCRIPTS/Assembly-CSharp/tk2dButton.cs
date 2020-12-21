using UnityEngine;

public class tk2dButton : MonoBehaviour
{
	public Camera viewCamera;
	public string buttonDownSprite;
	public string buttonUpSprite;
	public string buttonPressedSprite;
	public AudioClip buttonDownSound;
	public AudioClip buttonUpSound;
	public AudioClip buttonPressedSound;
	public GameObject targetObject;
	public string messageName;
	public float targetScale;
	public float scaleTime;
	public float pressedWaitTime;
}
