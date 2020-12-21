using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class FadeAudio : ComponentAction<AudioSource>
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat startVolume;
		public FsmFloat endVolume;
		public FsmFloat time;
	}
}
