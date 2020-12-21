using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class TransitionToAudioSnapshot : ComponentAction<AudioSource>
	{
		public FsmObject snapshot;
		public FsmFloat transitionTime;
	}
}
