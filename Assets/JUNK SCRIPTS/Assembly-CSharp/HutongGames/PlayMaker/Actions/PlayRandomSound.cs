using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class PlayRandomSound : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		public FsmVector3 position;
		public AudioClip[] audioClips;
		public FsmFloat[] weights;
		public FsmFloat volume;
	}
}
