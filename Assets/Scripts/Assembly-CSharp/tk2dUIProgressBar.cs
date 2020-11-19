using UnityEngine;

public class tk2dUIProgressBar : MonoBehaviour
{
	public Transform scalableBar;
	public tk2dClippedSprite clippedSpriteBar;
	public tk2dSlicedSprite slicedSpriteBar;
	[SerializeField]
	private float percent;
	public GameObject sendMessageTarget;
	public string SendMessageOnProgressCompleteMethodName;
}
