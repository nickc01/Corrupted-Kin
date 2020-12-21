using UnityEngine;
using UnityEngine.UI;

public class BossDoorChallengeUIBindingButton : MonoBehaviour
{
	public Image iconImage;
	public Animator iconAnimator;
	public Sprite selectedSprite;
	public Sprite allSelectedSprite;
	public Animator chainAnimator;
	public GameObject bindAllEffect;
	public AudioSource audioSourcePrefab;
	public AudioEvent selectedSound;
	public AudioEvent deselectedSound;
	public float pitchShiftMin;
	public float pitchShiftMax;
	public int maxAmount;
}
