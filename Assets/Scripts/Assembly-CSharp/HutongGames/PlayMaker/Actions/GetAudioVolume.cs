using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class GetAudioVolume : ComponentAction<AudioSource>
	{
		public FsmOwnerDefault gameObject;
		public FsmFloat storeVolume;
		public bool everyFrame;
	}
}
