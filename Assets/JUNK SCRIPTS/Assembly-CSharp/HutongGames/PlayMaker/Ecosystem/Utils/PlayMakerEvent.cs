using System;

namespace HutongGames.PlayMaker.Ecosystem.Utils
{
	[Serializable]
	public class PlayMakerEvent
	{
		public string eventName;
		public bool allowLocalEvents;
		public string defaultEventName;
	}
}
