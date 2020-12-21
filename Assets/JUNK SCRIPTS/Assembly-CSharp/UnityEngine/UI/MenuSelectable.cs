using GlobalEnums;
using UnityEngine;

namespace UnityEngine.UI
{
	public class MenuSelectable : Selectable
	{
		public CancelAction cancelAction;
		public Animator leftCursor;
		public Animator rightCursor;
		public Animator selectHighlight;
		public bool playSubmitSound;
		public Animator descriptionText;
	}
}
