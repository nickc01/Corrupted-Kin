using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetAudioLoop : ComponentAction<AudioSource>
	{
		public FsmOwnerDefault gameObject;
		public FsmBool loop;
	}
}
