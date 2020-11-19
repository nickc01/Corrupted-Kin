using UnityEngine;
using UnityEngine.UI;

public class ControllerDetect : MonoBehaviour
{
	public CanvasGroup controllerPrompt;
	public CanvasGroup remapDialog;
	public CanvasGroup menuControls;
	public CanvasGroup remapControls;
	public Selectable controllerMenuPreselect;
	public Selectable remapMenuPreselect;
	public MenuSelectable remapApplyButton;
	public MenuSelectable defaultsButton;
	public MenuButton applyButton;
	public MenuButton remapButton;
	[SerializeField]
	public ControllerImage[] controllerImages;
}
