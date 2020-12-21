using UnityEngine;
using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class SetAudioClip : ComponentAction<AudioSource>
	{
		public FsmOwnerDefault gameObject;
		public FsmObject audioClip;
	}
}
