using UnityEngine;

public class ObjectBounce : MonoBehaviour
{
	public float bounceFactor;
	public float speedThreshold;
	public bool playSound;
	public AudioClip[] clips;
	public int chanceToPlay;
	public float pitchMin;
	public float pitchMax;
	public bool playAnimationOnBounce;
	public string animationName;
	public float animPause;
	public bool sendFSMEvent;
}
