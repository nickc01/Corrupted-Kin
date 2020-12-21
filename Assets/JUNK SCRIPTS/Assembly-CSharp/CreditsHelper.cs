using UnityEngine;

public class CreditsHelper : MonoBehaviour
{
	public enum CreditsType
	{
		EndCredits = 0,
		MenuCredits = 1,
	}

	public CreditsType creditsType;
	public Animator creditsAnimator;
	public CutsceneHelper cutSceneHelper;
}
