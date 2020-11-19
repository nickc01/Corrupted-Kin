using System;
using UnityEngine;

namespace UnityEngine.UI
{
	[Serializable]
	public class SaveSlotButton : MenuButton
	{
		public enum SaveSlot
		{
			SLOT_1 = 0,
			SLOT_2 = 1,
			SLOT_3 = 2,
			SLOT_4 = 3,
		}

		public enum SaveFileStates
		{
			NotStarted = 0,
			OperationInProgress = 1,
			Empty = 2,
			LoadedStats = 3,
			Corrupted = 4,
		}

		public SaveSlot saveSlot;
		public Animator topFleur;
		public Animator highlight;
		public CanvasGroup newGameText;
		public CanvasGroup saveCorruptedText;
		public CanvasGroup loadingText;
		public CanvasGroup activeSaveSlot;
		public CanvasGroup clearSaveButton;
		public CanvasGroup clearSavePrompt;
		public CanvasGroup backgroundCg;
		public CanvasGroup slotNumberText;
		public CanvasGroup myCanvasGroup;
		public CanvasGroup defeatedText;
		public CanvasGroup defeatedBackground;
		public CanvasGroup brokenSteelOrb;
		public Text geoText;
		public Text locationText;
		public Text playTimeText;
		public Text completionText;
		public CanvasGroup normalSoulOrbCg;
		public CanvasGroup hardcoreSoulOrbCg;
		public CanvasGroup ggSoulOrbCg;
		public Image background;
		public Image soulOrbIcon;
		public SaveProfileHealthBar healthSlots;
		public Image geoIcon;
		public SaveProfileMPSlots mpSlots;
		public SaveSlotBackgrounds saveSlots;
		public GameObject clearSaveBlocker;
		public SaveFileStates saveFileState;
		[SerializeField]
		private SaveStats saveStats;
	}
}
