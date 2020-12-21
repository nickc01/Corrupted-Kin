using HutongGames.PlayMaker;
using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	public class DrawTexture : FsmStateAction
	{
		public FsmTexture texture;
		public FsmRect screenRect;
		public FsmFloat left;
		public FsmFloat top;
		public FsmFloat width;
		public FsmFloat height;
		public ScaleMode scaleMode;
		public FsmBool alphaBlend;
		public FsmFloat imageAspect;
		public FsmBool normalized;
	}
}
