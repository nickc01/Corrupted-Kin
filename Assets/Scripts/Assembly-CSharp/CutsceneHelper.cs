using UnityEngine;
using GlobalEnums;

public class CutsceneHelper : MonoBehaviour
{
	public enum NextScene
	{
		SpecifyScene = 0,
		MainMenu = 1,
		PermaDeathUnlock = 2,
		GameCompletionScreen = 3,
		EndCredits = 4,
		MrMushroomUnlock = 5,
		GGReturn = 6,
		MainMenuNoSave = 7,
	}

	public float waitBeforeFadeIn;
	public CameraFadeInType fadeInSpeed;
	public SkipPromptMode skipMode;
	public bool startSkipLocked;
	public bool resetOnStart;
	public NextScene nextSceneType;
	public string nextScene;
}
