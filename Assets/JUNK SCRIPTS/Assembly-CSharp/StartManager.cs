using UnityEngine;
using UnityEngine.UI;
using InControl;

public class StartManager : MonoBehaviour
{
	public Animator startManagerAnimator;
	public Slider progressIndicator;
	[SerializeField]
	private StandaloneLoadingSpinner loadSpinnerPrefab;
	public SpriteRenderer controllerImage;
	public Sprite winController;
	public Sprite osxController;
	public SetTextMeshProGameText controllerNoticeText;
	public CanvasGroup languageSelect;
	public Animator languageAnimator;
	public PreselectOption preselector;
	public CanvasGroup languageConfirm;
	public InControlInputModule inputModule;
	public MenuAudioController uiAudioPlayer;
	public bool showProgessIndicator;
}
