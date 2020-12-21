using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class AudioPlayerOneShot : FsmStateAction
	{
		public FsmGameObject audioPlayer;
		public FsmGameObject spawnPoint;
		public AudioClip[] audioClips;
		public FsmFloat[] weights;
		public FsmFloat pitchMin;
		public FsmFloat pitchMax;
		public FsmFloat volume;
		public FsmFloat delay;
		public FsmGameObject storePlayer;
	}
}
