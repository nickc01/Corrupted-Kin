using UnityEngine;
using System;
using UnityEngine.UI;

public class MenuButtonList : MonoBehaviour
{
	[Serializable]
	private class Entry
	{
		[SerializeField]
		private Selectable selectable;
		[SerializeField]
		private MenuButtonListCondition condition;
		[SerializeField]
		private bool alsoAffectParent;
	}

	[SerializeField]
	private Entry[] entries;
	[SerializeField]
	private bool isTopLevelMenu;
	[SerializeField]
	private bool skipDisabled;
}
