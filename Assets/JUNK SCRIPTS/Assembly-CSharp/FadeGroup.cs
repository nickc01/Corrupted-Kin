using UnityEngine;
using TMPro;

public class FadeGroup : MonoBehaviour
{
	public SpriteRenderer[] spriteRenderers;
	public TextMeshPro[] texts;
	public InvAnimateUpAndDown[] animators;
	public float fadeInTime;
	public float fadeOutTime;
	public float fadeOutTimeFast;
	public float fullAlpha;
	public float downAlpha;
	public bool activateTexts;
	public bool disableRenderersOnEnable;
}
