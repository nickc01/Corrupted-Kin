using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetAudioPitch : ComponentAction<AudioSource>
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat pitch;
		public bool everyFrame;
	}
}
