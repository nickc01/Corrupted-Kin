using UnityEngine;
using System;
using UnityEngine.UI;

public class BossChallengeUI : MonoBehaviour
{
	[Serializable]
	public class ButtonDisplay
	{
		public Image completeImage;
		public Image incompleteImage;
		public MenuSelectable button;
		public float enabledAlpha;
		public float disabledAlpha;
	}

	public Text bossNameText;
	public Text descriptionText;
	public MenuSelectable firstSelected;
	public string closeStateName;
	public ButtonDisplay tier1Button;
	public ButtonDisplay tier2Button;
	public ButtonDisplay tier3Button;
	public GameObject tier3UnlockEffect;
	public float tier3UnlockEffectDelay;
}
