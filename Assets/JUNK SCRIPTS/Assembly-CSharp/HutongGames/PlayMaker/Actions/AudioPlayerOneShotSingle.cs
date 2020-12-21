using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class AudioPlayerOneShotSingle : FsmStateAction
	{
		public FsmGameObject audioPlayer;
		public FsmGameObject spawnPoint;
		public FsmObject audioClip;
		public FsmFloat pitchMin;
		public FsmFloat pitchMax;
		public FsmFloat volume;
		public FsmFloat delay;
		public FsmGameObject storePlayer;
	}
}
