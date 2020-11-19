using UnityEngine;
using UnityEngine.UI;

public class AchievementPopup : MonoBehaviour
{
	public Image image;
	public Text nameText;
	public Text descriptionText;
	public float fadeInTime;
	public float holdTime;
	public float fadeOutTime;
	public AudioSource audioPlayerPrefab;
	public AudioEvent sound;
	public Animator fluerAnimator;
	public string fluerCloseName;
}
