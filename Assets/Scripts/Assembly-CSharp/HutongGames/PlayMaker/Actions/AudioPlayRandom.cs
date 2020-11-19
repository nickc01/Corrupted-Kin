using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class AudioPlayRandom : FsmStateAction
	{
		public FsmGameObject gameObject;
		public AudioClip[] audioClips;
		public FsmFloat[] weights;
		public FsmFloat pitchMin;
		public FsmFloat pitchMax;
	}
}
