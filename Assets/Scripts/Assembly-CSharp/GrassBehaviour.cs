using UnityEngine;

public class GrassBehaviour : MonoBehaviour
{
	public float walkReactAmount;
	public AnimationCurve walkReactCurve;
	public float walkReactLength;
	public float attackReactAmount;
	public AnimationCurve attackReactCurve;
	public float attackReactLength;
	public string pushAnim;
	public AudioClip[] pushSounds;
	public AudioClip[] cutPushSounds;
	public AudioClip[] cutSounds;
	public Color infectedColor;
	public bool neverInfected;
}
