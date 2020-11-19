using HutongGames.PlayMaker;

namespace HutongGames.PlayMaker.Actions
{
	public class WWWObject : FsmStateAction
	{
		public FsmString url;
		public FsmString storeText;
		public FsmTexture storeTexture;
		public FsmObject storeMovieTexture;
		public FsmString errorString;
		public FsmFloat progress;
		public FsmEvent isDone;
		public FsmEvent isError;
	}
}
