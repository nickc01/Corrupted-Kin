using UnityEngine.EventSystems;
using InControl;

namespace UnityEngine.UI
{
	public class MenuScroller : UIBehaviour
	{
		public ScrollRect scrollRect;
		public Scrollbar scrollbar;
		public HollowKnightInputModule inputModule;
		public float scrollRate;
		public float scrollRepeatRate;
		public float scrollFirstDelay;
	}
}
