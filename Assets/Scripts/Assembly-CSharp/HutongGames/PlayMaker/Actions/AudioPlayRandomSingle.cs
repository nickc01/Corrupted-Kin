using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class AudioPlayRandomSingle : FsmStateAction
	{
		public FsmGameObject gameObject;
		public FsmObject audioClip;
		public FsmFloat pitchMin;
		public FsmFloat pitchMax;
	}
}
