using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetAudioVolume : ComponentAction<AudioSource>
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat volume;
		public bool everyFrame;
	}
}
